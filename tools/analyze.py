# -*- coding: utf-8 -*-
"""Service resolution + page parsing."""
import re, json, pickle, os
import sqlx
import config
from urllib.parse import parse_qsl

HERE = os.path.dirname(os.path.abspath(__file__))
kb = pickle.load(open(config.CACHE + '/kb.pkl', 'rb'))
TABLES = kb['tables']; COLS = kb['cols']; PKS = kb['pks']
SQ = kb['sq']; MQ = kb['mq']; RULES = kb['rules']; API = kb['api']
CS = kb['cs_classes']; METHODS = kb['methods']; CONST = kb['constmap']
SQ_CI = {k.upper(): v for k, v in SQ.items()}

import pyodbc as _pyodbc
_mc = config.connect()
MODS = {}
for _n, _t, _d in _mc.cursor().execute("select o.name,o.type_desc,m.definition from sys.sql_modules m join sys.objects o on o.object_id=m.object_id").fetchall():
    MODS[_n.upper()] = dict(name=_n, type={'SQL_STORED_PROCEDURE': 'Stored Procedure', 'SQL_TABLE_VALUED_FUNCTION': '테이블 반환 함수', 'SQL_SCALAR_FUNCTION': '스칼라 함수', 'VIEW': 'View'}.get(_t, _t), sql=_d or '')
_mc.close()
ML = kb.get('ml', {})
def kor(*keys):
    for k in keys:
        if k and k.strip().upper() in ML:
            return ML[k.strip().upper()]
    return ''

AUDIT = {'ACTIVITY', 'PREVACTIVITY', 'CUSTOMACTIVITY', 'PREVCUSTOMACTIVITY', 'REASONCODE', 'COMMENTS', 'CREATOR', 'CREATETIME',
         'MODIFIER', 'MODIFYTIME', 'LASTEVENTTIME', 'TID'}
STOP_ENT = {'String', 'Int32', 'Decimal', 'DataTable', 'DataRow', 'Columns', 'Object', 'List', 'Dictionary', 'Exception', 'DateTime', 'Boolean', 'Task'}

def strip_sql(sql):
    s = re.sub(r'/\*.*?\*/', ' ', sql, flags=re.S)
    s = re.sub(r'--[^\n]*', ' ', s)
    return s

def clean_name(n):
    n = n.replace('[', '').replace(']', '')
    n = n.split('.')[-1]
    return n.upper()

def sql_info(sql):
    s = strip_sql(sql)
    s2 = re.sub(r"'[^']*'", "''", s)
    reads, writes, funcs = set(), set(), set()
    for m in re.finditer(r'\b(INSERT\s+INTO|UPDATE|DELETE\s+FROM|DELETE|MERGE\s+INTO|MERGE|TRUNCATE\s+TABLE)\s+([\w\.\[\]#]+)', s2, re.I):
        n = clean_name(m.group(2))
        if n in TABLES:
            writes.add(n)
    for m in re.finditer(r'\b(FROM|JOIN)\s+([\w\.\[\]#]+)', s2, re.I):
        n = clean_name(m.group(2))
        if n in TABLES and n not in writes:
            reads.add(n)
    for m in re.finditer(r'[\w\[\]]+', s2):
        n = clean_name(m.group(0))
        if n in TABLES and n not in writes and n not in reads and (n.startswith(('CIM_', 'CST_', 'IFS_', 'IFR_', 'RPS_', 'RPT_', 'CUS_'))):
            reads.add(n)
    for m in re.finditer(r'\bdbo\.(\w+)\s*\(', s2, re.I):
        funcs.add(m.group(1))
    for m in re.finditer(r'(?<![\w\.])(FN_\w+)\s*\(', s2, re.I):
        funcs.add(m.group(1))
    for m in re.finditer(r'\bEXEC(?:UTE)?\s+([\w\.]+)', s2, re.I):
        funcs.add('EXEC ' + m.group(1))
    declared = {m.group(1).upper() for m in re.finditer(r'DECLARE\s+@(\w+)', s2, re.I)}
    params = []
    for m in re.finditer(r'(?<![@\w])@(\w+)', s2):
        p = m.group(1)
        if p.upper() not in declared and p not in params:
            params.append(p)
    for m in re.finditer(r'(?<![:\w]):([A-Za-z_]\w*)', s2):
        if m.group(1) not in params:
            params.append(m.group(1))
    return sorted(reads), sorted(writes), sorted(funcs), params

def sql_objects(sql, depth=0, seen=None):
    """SQL이 호출하는 함수/SP/View 정의를 DB에서 읽어 재귀 전개 (최대 3단계). list of dict(name,type,sql,reads,writes,depth)"""
    seen = seen if seen is not None else set()
    out = []
    s = strip_sql(sql)
    r, w, funcs, _ = sql_info(sql)
    names = []
    for f in funcs:
        names.append(re.sub(r'^EXEC\s+', '', f).split('.')[-1].upper())
    for t in r:
        if t in MODS and MODS[t]['type'] == 'View':
            names.append(t)
    m = re.fullmatch(r'\s*(?:EXEC(?:UTE)?\s+)?(?:dbo\.)?(\w+)\s*;?\s*', s, re.I)
    if m:
        names.append(m.group(1).upper())
    for n in names:
        if n in seen or n not in MODS or depth >= 3:
            continue
        seen.add(n)
        o = MODS[n]
        rr, ww, ff, _ = sql_info(o['sql'])
        out.append(dict(name=o['name'], type=o['type'], sql=o['sql'], reads=rr, writes=ww, depth=depth))
        out.extend(sql_objects(o['sql'], depth + 1, seen))
    return out

def missing_objects(sql):
    s = strip_sql(sql)
    r, w, funcs, _ = sql_info(sql)
    names = [re.sub(r'^EXEC\s+', '', f).split('.')[-1] for f in funcs]
    m = re.fullmatch(r'\s*(?:EXEC(?:UTE)?\s+)?(?:dbo\.)?(\w+)\s*;?\s*', s, re.I)
    if m:
        names.append(m.group(1))
    out = []
    for n in names:
        if n.upper() not in MODS and n.upper() not in ('SP_EXECUTESQL',) and n not in out:
            out.append(n)
    return out

def comment_params(sql):
    m = re.search(r'--\s*Param\s*:\s*(.+)', sql, re.I)
    if m:
        return [x.strip() for x in re.split(r'[,\s]+', m.group(1).strip()) if x.strip()]
    return []

def entity_tables(name):
    n = name.upper()
    out = []
    cands = [n]
    if n.startswith('CST') and not n.startswith('CST_'):
        cands.append(n[3:])
    for c in cands:
        for p in ('CIM_', 'CST_', 'IFS_', 'IFR_', 'CUS_'):
            t = p + c
            if t in TABLES and not t.endswith('HIST'):
                out.append(t)
    return out

def guess_modeler_table(qid):
    m = re.match(r'^(?:CDS|RDS|GRD|PMS|POS|PPS|QMS|DAS)_(\w+?)_\d+', qid)
    if m:
        return entity_tables(m.group(1))
    m = re.match(r'^(?:CDS|RDS|GRD|PMS|POS|PPS|QMS|DAS)_([A-Za-z]+?)(?:List|Combo)?$', qid)
    if m:
        return entity_tables(m.group(1))
    return []

# ---------------- service resolution
class Svc(dict):
    pass

_svc_cache = {}

def parse_ref(ref):
    """returns (cmd, qcls, qid, qver, qparams) any may be None"""
    r = ref.strip().strip('`\'"')
    qs = ''
    if '?' in r:
        r, qs = r.split('?', 1)
    qparams = [k for k, _ in parse_qsl(qs, keep_blank_values=True)]
    cmd = qcls = qid = qver = None
    if '/' in r:
        cmd, r = r.split('/', 1)
    parts = r.split('$')
    if 'RuleMultiInquiry' in parts:
        i = parts.index('RuleMultiInquiry')
        if len(parts) >= i + 4:
            qcls, qid, qver = parts[i + 1], parts[i + 2], parts[i + 3]
        if cmd is None and False:
            pass
    elif len(parts) == 2 and cmd is None:
        if parts[0] in SQ or parts[0].upper() in SQ_CI:
            qcls, qid, qver = parts[1], parts[0], None
        else:
            cmd = parts[0]; qcls = parts[1]
    elif len(parts) == 1 and cmd is None and re.match(r'^\w+$', r) and r != '_':
        cmd = r
    return cmd, qcls, qid, qver, qparams

def resolve_query(qid, qcls=None, qver=None):
    info = Svc(kind='QUERY', id=qid, cls=qcls, ver=qver, tables_r=[], tables_w=[], funcs=[], params=[], sql='', src='', found=False, name='', objs=[])
    lst = SQ.get(qid) or SQ_CI.get(qid.upper())
    if lst:
        pick = None
        for x in lst:
            if (qver is None or x['ver'] == qver) and (qcls is None or x['cls'] == qcls):
                pick = x; break
        pick = pick or lst[0]
        sql = pick['sql']
        info.update(found=True, src='DB 저장 쿼리 (CIM_STOREDQUERY)', sql=sql, name=pick['name'] or '', cls=pick['cls'], ver=pick['ver'])
        if (pick['cmd'] or '').upper().startswith('STOREDPROC'):
            info['src'] += ' / Stored Procedure'
        r, w, f, p = sql_info(sql)
        cp = comment_params(sql)
        objs = sql_objects(sql)
        info['missing_objs'] = missing_objects(sql)
        r = sorted(set(r) | {t for o in objs for t in o['reads']})
        w = sorted(set(w) | {t for o in objs for t in o['writes']})
        info.update(tables_r=r, tables_w=w, funcs=f, params=cp or p, objs=objs)
        return info
    m = MQ.get(qid.upper())
    if m:
        r, w, f, p = sql_info(m['sql'])
        objs = sql_objects(m['sql'])
        r = sorted(set(r) | {t for o in objs for t in o['reads']})
        w = sorted(set(w) | {t for o in objs for t in o['writes']})
        info.update(found=True, src='Modeler 내장 쿼리 (THiRAMES.Service.Modeler.MSSQL DLL)', sql=m['sql'], tables_r=r, tables_w=w, funcs=f, params=p, objs=objs)
        return info
    g = guess_modeler_table(qid)
    info.update(src='정의 미확인 (프레임워크 내장/외부 정의) - 쿼리 ID 명명규칙으로 테이블 추정' if g else '정의 미확인', tables_r=g)
    return info

def get_ent_from_base(base):
    m = re.search(r'<\s*(\w+)\s*>', base or '')
    return m.group(1) if m else None

_ftxt = {}
def file_text(path):
    if path not in _ftxt:
        try:
            _ftxt[path] = open(path, encoding='utf-8-sig', errors='replace').read()
        except Exception:
            _ftxt[path] = ''
    return _ftxt[path]

def analyze_text(text, acc, depth, seen, ctx=''):
    text = re.sub(r'/\*.*?\*/', ' ', text, flags=re.S)
    text = re.sub(r'(?m)^\s*//.*$', ' ', text)
    text = re.sub(r'(?m)(?<=[;{}])\s*//[^"\n]*$', ' ', text)
    for m in re.finditer(r'\b((?:CIM|CST|IFS|IFR|CUS|RPS|RPT)_[A-Z0-9_]+)\b', text):
        n = m.group(1)
        if n in TABLES and not n.endswith('HIST'):
            acc['tables'].setdefault(n, set()).add('?')
    def _addsql(lit, label):
        if lit not in acc['sqls']:
            acc['sqls'].append(lit)
            acc['sqlsrc'][lit] = label
    for lit in sqlx.sql_literals(text):
        _addsql(lit, 'C# 코드 내 SQL 문자열')
    if ctx:
        for nm in sqlx.field_names(text):
            lit = sqlx.sql_field(nm, ctx)
            if len(lit) > 25:
                _addsql(lit, 'API 클래스 SQL (' + nm + ')')
    for m in re.finditer(r'\b([A-Z][A-Z0-9]{2,})\.(\w+)\s*\(', text):
        a_ = API.get(m.group(1))
        if a_:
            for lit in sqlx.api_method_sqls(a_['text'], m.group(2)):
                _addsql(lit, '%s.%s (CIM.MES.API 프레임워크)' % (m.group(1), m.group(2)))
    for m in re.finditer(r'QueryId\.(\w+)', text):
        v = CONST.get(m.group(1))
        if v:
            acc['queries'].add(v)
    for lit in set(re.findall(r'"([A-Za-z_]\w{5,})"', text)):
        if lit in SQ:
            acc['queries'].add(lit)
    for m in re.finditer(r'\b(Upsert|Create|Update|Delete|Insert|Save|Remove|Get|Select|Find|Change)(?:List)?(?:4Update)?([A-Z]\w+?)(?:ByKey|List|Info|4Update)?\s*\(', text):
        verb, ent = m.group(1), m.group(2)
        ts = entity_tables(ent)
        for t in ts:
            acc['tables'].setdefault(t, set()).add('W' if verb in ('Upsert', 'Create', 'Update', 'Delete', 'Insert', 'Save', 'Remove', 'Change') else 'R')
    for m in re.finditer(r'(?:<|new\s+)(\w+)(?:>|\(|\[)', text):
        e = m.group(1)
        if e in STOP_ENT:
            continue
        for t in entity_tables(e):
            acc['tables'].setdefault(t, set()).add('?')
    for m in re.finditer(r'\b([A-Z][A-Z0-9]{2,})\.(Upsert|Create|Update|Delete|Insert|Get|Select|Find)\w*\s*\(', text):
        for t in entity_tables(m.group(1)):
            acc['tables'].setdefault(t, set()).add('W' if m.group(2) in ('Upsert', 'Create', 'Update', 'Delete', 'Insert') else 'R')
    if depth >= 3:
        return
    for m in re.finditer(r'(?<![\w])(?:[\w\.]+\.)?([A-Z]\w{3,})\s*(?:<[^>]*>)?\s*\(', text):
        name = m.group(1)
        if name in seen or name not in METHODS:
            continue
        cands = [c for c in METHODS[name] if c['cls'] not in ('BizRuleBase', 'BizEISRuleBase', 'BizFileRuleBase', 'ManagerBase')]
        if len(cands) > 3 or not cands or name in ('Parse', 'ToString', 'Add', 'Remove', 'Select'):
            continue
        seen.add(name)
        for c in cands:
            acc['calls'].append((name, c['cls'], c['proj']))
            analyze_text(c['body'], acc, depth + 1, seen, file_text(c['file']))

def resolve_rule(cmd, qcls=None):
    key = ('R', cmd)
    if key in _svc_cache:
        return _svc_cache[key]
    info = Svc(kind='RULE', id=cmd, cls=qcls, tables={}, params=[], queries=[], calls=[], src='', found=False, file='', summary='')
    cands = [c for c in CS.get(cmd, []) if re.search(r'Rule(Base)?|Biz', c['text'])]
    if cands:
        c = cands[0]
        txt = c['text']
        m = re.search(r'class\s+' + re.escape(cmd) + r'\b.*?\n(.*)', txt, re.S)
        body_start = txt.find('class ' + cmd)
        body = txt[body_start:] if body_start >= 0 else txt
        info.update(found=True, src='C# 소스 (' + c['proj'] + ')', file=c['file'].split('THiRAMES_Service/')[-1])
        p = re.search(r'//\s*Param\s*:\s*(.+)', body)
        params = []
        if p:
            params = [x.strip() for x in re.split(r'[,\s]+', p.group(1)) if x.strip()]
        for x in re.findall(r'nameof\(\s*Columns\.(\w+)\s*\)', body):
            if x not in params:
                params.append(x)
        for x in re.findall(r'(?:CancelLotType|UserConsts)\.(\w+)', body):
            if x not in params:
                params.append(x)
        sm = re.search(r'///\s*<summary>\s*(.*?)\s*///\s*</summary>', txt[:body_start + 400] if body_start > 0 else txt, re.S)
        if sm:
            info['summary'] = re.sub(r'\s*///\s*', ' ', sm.group(1)).strip()
        acc = dict(tables={}, queries=set(), calls=[], sqls=[], sqlsrc={})
        analyze_text(body, acc, 0, set())
        info.update(params=params, tables=acc['tables'], queries=sorted(acc['queries']), calls=acc['calls'], sqls=acc['sqls'], sqlsrc=acc['sqlsrc'])
    else:
        rl = RULES.get(cmd)
        if rl:
            rr = rl[0]
            txt = rr['text']
            info.update(found=True, src='THiRAMES.Service.Modeler 내장 Rule (DLL 역분석)', file=os.path.basename(rr['file']))
            ent = get_ent_from_base(rr['base'])
            acc = dict(tables={}, queries=set(), calls=[], sqls=[], sqlsrc={})
            analyze_text(txt, acc, 2, set())
            if ent:
                for t in entity_tables(ent):
                    acc['tables'].setdefault(t, set()).add('W')
                    info['params'] = [c[0] for c in COLS.get(t, []) if c[0] not in AUDIT]
                    info['pk'] = PKS.get(t, [])
            acc['tables'].pop('CIM_API', None)
            info.update(tables=acc['tables'], queries=sorted(acc['queries']), calls=acc['calls'], sqls=acc['sqls'], sqlsrc=acc['sqlsrc'])
            info['entity'] = ent
        else:
            info['src'] = '구현 미확인 (소스/배포 DLL에서 정의를 찾지 못함 - 미사용·삭제된 서비스이거나 외부 모듈일 수 있음)'
    _svc_cache[key] = info
    return info

def resolve(ref):
    cmd, qcls, qid, qver, qparams = parse_ref(ref)
    res = dict(ref=ref, cmd=None, query=None, qparams=qparams)
    if qid:
        res['query'] = resolve_query(qid, qcls, qver)
    if cmd:
        res['cmd'] = resolve_rule(cmd, qcls if not qid else None)
    return res

# ---------------- page parsing
SVC_LIT = re.compile(r"""['"`]([\w\.]*(?:\$[\w\.]+)+(?:\?[^'"`]*)?|\w+/[\w\.]+\$[^'"`\s]+)['"`]""")

def js_functions_index(js):
    pat = re.compile(r"""(\w+)\s*:\s*function\s*\(|function\s+(\w+)\s*\(|\$\(\s*['"]([^'"]+)['"]\s*\)\s*\.\s*(?:on\(\s*['"](\w+)['"]|(click|change|dblclick)\s*\()|\$\(document\)\s*\.on\(\s*['"](\w+)['"]\s*,\s*['"]([^'"]+)['"]""")
    out = []
    for m in pat.finditer(js):
        if m.group(1):
            lab = m.group(1)
        elif m.group(2):
            lab = m.group(2)
        elif m.group(3):
            lab = m.group(3) + ' ' + (m.group(4) or m.group(5))
        else:
            lab = m.group(7) + ' ' + m.group(6)
        if lab in ('after', 'success', 'error', 'callback', 'then', 'done', 'fail', 'complete', 'onConfirm', 'preConfirm', 'beforeSend', 'ok', 'confirm', 'cancel'):
            continue
        out.append((m.start(), lab))
    return out

def split_args(s, start):
    """s[start] is just after '('. returns list of arg strings (top-level) and end index."""
    args = []; cur = ''; depth = 0; i = start; q = None
    while i < len(s):
        c = s[i]
        if q:
            cur += c
            if c == '\\':
                cur += s[i + 1]; i += 1
            elif c == q:
                q = None
        elif c in '\'"`':
            q = c; cur += c
        elif c in '([{':
            depth += 1; cur += c
        elif c in ')]}':
            if depth == 0:
                args.append(cur.strip()); return args, i
            depth -= 1; cur += c
        elif c == ',' and depth == 0:
            args.append(cur.strip()); cur = ''
        else:
            cur += c
        i += 1
    return args, i

def keys_in(text):
    ks = []
    for m in re.finditer(r"""\b(?:[\w\$\.\[\]]*[pP]aram\w*|WEBDATA\w*|data\w*|item\w*|obj\w*|row\w*)\s*(?:\.|\[\s*['"])([A-Z][A-Z0-9_]{2,})(?:['"]\s*\])?\s*=[^=]""", text):
        ks.append(m.group(1))
    for m in re.finditer(r"""['"]([A-Z][A-Z0-9_]{2,})['"]\s*:""", text):
        ks.append(m.group(1))
    for m in re.finditer(r"""[\{\s,]([A-Z][A-Z0-9_]{2,})\s*:\s*[\$\w'"\[\(]""", text):
        ks.append(m.group(1))
    out = []
    for k in ks:
        if k not in out and k not in ('COMMAND', 'CONTEXTNAME', 'WEBDATA') and not k.startswith(('TIT_', 'MSG_', 'BTN_', 'LBL_')):
            out.append(k)
    return out

def func_body(js, name):
    m = re.search(r'\b' + re.escape(name) + r'\s*:\s*function\s*\([^)]*\)\s*\{', js)
    if not m:
        return ''
    depth = 0
    for j in range(m.end() - 1, len(js)):
        if js[j] == '{':
            depth += 1
        elif js[j] == '}':
            depth -= 1
            if depth == 0:
                return js[m.end():j]
    return js[m.end():]

def resolve_url_expr(expr, js, pos):
    lits = SVC_LIT.findall(expr)
    if lits:
        return lits, False
    # identifier / template referencing variable
    names = re.findall(r'\$\{(\w+)\}|^(\w+)$', expr.strip())
    var = None
    for a, b in names:
        var = a or b
    if var:
        pre = js[:pos]
        best = None
        for m in re.finditer(r'\b' + re.escape(var) + r"""\s*=\s*([`'"][^`'"]+[`'"])""", pre):
            best = m.group(1)
        if best:
            return SVC_LIT.findall(best) or [best.strip('`\'"')], True
        # nearest preceding service literal
        last = None
        for m in SVC_LIT.finditer(pre[-4000:]):
            last = m.group(1)
        if last:
            return [last], True
    return [], False

def parse_js(js):
    calls = []
    labs = js_functions_index(js)
    for m in re.finditer(r'\.ajax\s*\(', js):
        args, end = split_args(js, m.end())
        if len(args) < 3:
            continue
        tm = re.match(r"""^['"`](\w)['"`]$""", args[1].strip())
        if not tm:
            continue
        typ = tm.group(1)
        pos = m.start()
        refs, indirect = resolve_url_expr(args[2], js, pos)
        # label
        lab = ''
        for p, l in labs:
            if p < pos:
                lab = l
        fstart = max([p for p, l in labs if p < pos] or [max(0, pos - 1500)])
        window = js[max(0, pos - 1800):pos]
        pa = args[3] if len(args) > 3 else ''
        keys = keys_in(window)
        # comments right above
        pre = js[max(0, pos - 400):pos].splitlines()
        cm = ''
        for ln in reversed(pre[-6:]):
            t = ln.strip()
            if t.startswith('//'):
                cm = t.lstrip('/ ').strip(); break
            if t and not t.startswith('let') and not t.startswith('const') and not t.startswith('var'):
                pass
        calls.append(dict(type=typ, refs=refs, indirect=indirect, label=lab, keys=keys, comment=cm, pos=pos, expr=args[2][:160], param=pa))
    all_refs = []
    for m in SVC_LIT.finditer(js):
        if m.group(1) not in all_refs:
            all_refs.append(m.group(1))
    return calls, all_refs

def jload(s, default):
    try:
        return json.loads(s) if s else default
    except Exception:
        return default

def parse_widget(w):
    g = jload(w['grid'], {})
    cols = jload(w['col'], [])
    sf = jload(w['sf'], [])
    action = g.get('actionId', '') or ''
    out = dict(id=w['id'], name=w['name'], type=w['type'], action=action, cols=[], filters=[], buttons=[], link=[])
    for c in cols if isinstance(cols, list) else []:
        ct = c.get('columnType')
        if ct in ('COLUMN', 'COL_CHK', 'COL_CAL', 'COL_CAL2', 'COL_INPUT_BTN', 'COL_COM', 'COL_BTN', 'COL_STEP'):
            out['cols'].append(dict(field=c.get('dataField'), head=c.get('KORHeaderText') or c.get('headerText') or c.get('HeaderText') or '',
                                    type=ct, edit=bool(c.get('editable')), new=bool(c.get('isNewRowEditable')), must=bool(c.get('widgetMandatory')),
                                    vis=c.get('visible', True), dd=c.get('dropDown') if isinstance(c.get('dropDown'), str) and '$' in (c.get('dropDown') or '') else ''))
        elif ct == 'ACTION':
            out['buttons'].append(c.get('dataField'))
            dd = c.get('dropDown')
            if dd:
                out['link'].append(dd)
    for f in sf if isinstance(sf, list) else []:
        if f.get('dataField'):
            dd = f.get('dropDown')
            out['filters'].append(dict(field=f.get('dataField'), type=f.get('columnType'), head=f.get('KORHeaderText') or f.get('headerText') or '',
                                       dd=dd if isinstance(dd, str) and '$' in dd else ''))
    return out
