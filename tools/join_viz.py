# -*- coding: utf-8 -*-
"""SQL join structure -> inline SVG."""
import re, html
import analyze as A
import config

KW = {'WITH', 'ON', 'WHERE', 'INNER', 'LEFT', 'RIGHT', 'FULL', 'CROSS', 'JOIN', 'GROUP', 'ORDER', 'UNION', 'HAVING', 'OUTER', 'SET', 'SELECT', 'AND', 'OR', 'USING'}
JOIN_RE = re.compile(r'\b(FROM|(?:INNER|LEFT(?:\s+OUTER)?|RIGHT(?:\s+OUTER)?|FULL(?:\s+OUTER)?|CROSS)?\s*JOIN)\s+([\w\.\[\]#]+)(?:\s+(?:AS\s+)?(\w+))?', re.I)
END_RE = re.compile(r'\b(INNER|LEFT|RIGHT|FULL|CROSS|JOIN|WHERE|GROUP|ORDER|UNION|HAVING)\b', re.I)
PAIR_RE = re.compile(r'(\w+)\.(\w+)\s*=\s*(\w+)\.(\w+)')

SUB_START = re.compile(r'\(\s*SELECT\b', re.I)
KEEP_PREV = {'FROM', 'JOIN', 'IN', 'EXISTS', 'APPLY', 'UNION', 'ALL', 'ANY', 'SOME', 'AS', 'ON', 'WHERE', 'AND', 'OR', 'NOT', 'HAVING', '=', '<', '>', '<>', '!=', '>=', '<='}

def strip_select_list_subqueries(s):
    """SELECT 목록에서 값을 가져오는 스칼라 서브쿼리( (SELECT ... FROM 마스터) AS XXXNAME )를 NULL로 치환"""
    out = []
    i = 0
    while True:
        m = SUB_START.search(s, i)
        if not m:
            out.append(s[i:])
            break
        before = s[i:m.start()]
        prev = (s[:m.start()].rstrip()[-12:]) if s[:m.start()].strip() else ''
        pm = re.search(r'([A-Za-z_]+|[=<>!,+(]+)$', prev)
        ptok = pm.group(1).upper() if pm else ''
        # 스칼라(목록용): 바로 앞이 ',', 'SELECT', 'THEN', 'ELSE', '+', 또는 함수 호출 '(' / 'WHEN'
        scalar = ptok in (',', 'SELECT', 'THEN', 'ELSE', '+', 'WHEN', '(') or ptok.endswith(',') or ptok.endswith('(')
        if ptok in KEEP_PREV or not scalar:
            out.append(s[i:m.end()])
            i = m.end()
            continue
        # 짝이 맞는 ')' 찾기
        depth = 0
        j = m.start()
        while j < len(s):
            if s[j] == '(':
                depth += 1
            elif s[j] == ')':
                depth -= 1
                if depth == 0:
                    break
            j += 1
        out.append(before + ' NULL ')
        i = j + 1
    return ''.join(out)

def parse_joins(sql):
    s = A.strip_sql(sql)
    s = re.sub(r"'[^']*'", "''", s)
    s = strip_select_list_subqueries(s)
    nodes = {}      # alias -> table
    order = []
    edges = []
    last = None
    for m in JOIN_RE.finditer(s):
        kind = re.sub(r'\s+', ' ', m.group(1).upper())
        raw = m.group(2)
        if raw.upper() in KW:
            continue
        tname = A.clean_name(raw)
        alias = m.group(3)
        if alias and alias.upper() in KW:
            alias = None
        alias = alias or tname
        if alias not in nodes:
            nodes[alias] = tname; order.append(alias)
        if kind == 'FROM':
            last = alias if last is None or True else last
            first = alias
            continue
        jt = 'LEFT' if kind.startswith('LEFT') else 'RIGHT' if kind.startswith('RIGHT') else 'FULL' if kind.startswith('FULL') else 'CROSS' if kind.startswith('CROSS') else 'INNER'
        rest = s[m.end():]
        on = ''
        mo = re.match(r'\s*(?:WITH\s*\([^)]*\)\s*)?ON\b(.*)', rest, re.S | re.I)
        if mo:
            body = mo.group(1)
            e = END_RE.search(body)
            on = body[:e.start()] if e else body[:300]
            depth = 0
            for i, ch in enumerate(on):
                if ch == '(':
                    depth += 1
                elif ch == ')':
                    depth -= 1
                    if depth < 0:
                        on = on[:i]; break
        pairs = PAIR_RE.findall(on)
        targets = []
        for a1, c1, a2, c2 in pairs:
            if a1 == alias and a2 != alias and a2 in nodes:
                targets.append((a2, '%s = %s.%s' % (c1, a2, c2)))
            elif a2 == alias and a1 != alias and a1 in nodes:
                targets.append((a1, '%s = %s.%s' % (c2, a1, c1)))
        if not targets and last and last != alias:
            targets = [(last, '')]
        seen = {}
        for t, lab in targets:
            seen.setdefault(t, []).append(lab)
        for t, labs in seen.items():
            edges.append(dict(a=t, b=alias, type=jt, cols=[x for x in labs if x]))
        last = alias
    return nodes, order, edges, s

FORCE_NAME = {'CIM_CODE', 'CIM_STATE', 'CIM_MATERIALDEFINITION', 'CIM_PRODUCTDEFINITION', 'CIM_PROCESSSEGMENT', 'CIM_EQUIPMENT'}   # 항상 명칭 조회용으로 간주
import pyodbc
_c = config.connect()
IDENT = {r[0].upper() for r in _c.cursor().execute("select distinct t.name from sys.identity_columns ic join sys.tables t on t.object_id=ic.object_id")}
_c.close()
AUDIT_DT = {'CREATETIME', 'MODIFYTIME', 'LASTEVENTTIME'}
DT_TYPES = {'date', 'datetime', 'datetime2', 'smalldatetime', 'datetimeoffset'}
_master = {}
KEEP = {'CIM_ALARM', 'CIM_INSPRESULT', 'CIM_LOTHOLD', 'CIM_LOTTRACE', 'CIM_LOTBATCHREL', 'CIM_LOTCARRIERREL'}   # 마스터 판정 예외(항상 표시)

def is_master(t):
    """일자 컬럼(감사 컬럼 제외)과 자동증가(IDENTITY) 컬럼이 모두 없는 테이블"""
    t = t.upper()
    if t in KEEP:
        return False
    if t in _master:
        return _master[t]
    cols = A.COLS.get(t)
    r = False
    if cols and t in A.TABLES and not t.startswith('V_'):
        has_dt = any(c[0].upper() not in AUDIT_DT and (c[1] in DT_TYPES or re.search(r'(DATE|TIME)$', c[0], re.I)) for c in cols)
        r = (not has_dt) and (t not in IDENT)
    _master[t] = r
    return r

NAME_RE = re.compile(r'(NAME|DESC|DESCRIPTION|TEXT|LABEL)$', re.I)

def drop_name_only(nodes, order, edges, s):
    """명칭 조회만을 위한 조인(참조 컬럼이 *NAME 류뿐이고 다른 조인의 대상도 아님) 제외"""
    dropped = []
    base = order[0] if order else None
    for alias in list(order):
        if alias == base:
            continue
        mine = [e for e in edges if e['b'] == alias]
        forced = nodes[alias] in FORCE_NAME
        master = is_master(nodes[alias]) and not any(e['a'] == alias for e in edges)
        if not forced and (not mine or any(e['a'] == alias for e in edges)) and not (mine and is_master(nodes[alias]) and not any(e['a'] == alias for e in edges)):
            continue
        refs = re.findall(r'\b' + re.escape(alias) + r'\.(\w+)', s)
        on_cols = set()
        for e in mine:
            for c in e['cols']:
                m = re.match(r'(\w+) = ', c)
                if m:
                    on_cols.add(m.group(1).upper())
        other = [r for r in refs if r.upper() not in on_cols]
        if forced or master or (other and all(NAME_RE.search(r) for r in other)):
            dropped.append(nodes[alias])
            order.remove(alias)
            edges[:] = [e for e in edges if e['b'] != alias and e['a'] != alias]
            del nodes[alias]
    return dropped


def classify(sql):
    """조회 테이블 리스트용: [(table, role)] role: 메인/조인/제외/쓰기/참조"""
    nodes, order, edges, ssql = parse_joins(sql)
    allo = [(a, nodes[a]) for a in order]
    n2, o2, e2 = dict(nodes), list(order), [dict(e) for e in edges]
    dropped_t = drop_name_only(n2, o2, e2, ssql)
    kept = {n2[a] for a in o2}
    out = []
    for i, (a, t) in enumerate(allo):
        if i == 0:
            role = '메인'
        elif t in kept:
            role = '조인'
        else:
            role = '제외'
        if not any(x[0] == t for x in out):
            out.append((t, role))
    r, w, f, p = A.sql_info(sql)
    for t in w:
        out = [x for x in out if x[0] != t] + [(t, '쓰기')]
    for t in r:
        if not any(x[0] == t for x in out):
            out.append((t, '참조'))
    return out

def table_list_html(groups):
    """groups: list of (label, sql)"""
    rows = []
    for label, sql in groups:
        items = classify(sql)
        if not items:
            continue
        chips = []
        for t, role in items:
            cls = {'메인': 'main', '조인': 'join', '제외': 'excl', '쓰기': 'wr', '참조': 'ref'}[role]
            chips.append('<a class="tc %s" href="../tables.html#%s" title="%s">%s<i>%s</i></a>' % (cls, html.escape(t), role, html.escape(t), role))
        rows.append('<div class="tlrow"><span class="tllab">%s</span>%s</div>' % (html.escape(label), ''.join(chips)))
    if not rows:
        return ''
    return '<details class="joinviz" open><summary><b>조회 테이블 리스트</b> <small class="muted">메인 / 조인 / 제외(마스터·명칭 조회용) / 쓰기</small></summary>%s</details>' % ''.join(rows)

def render(sql, title=''):
    nodes, order, edges, ssql = parse_joins(sql)
    dropped = drop_name_only(nodes, order, edges, ssql)
    if not nodes:
        return ''
    adj = {}
    for e in edges:
        adj.setdefault(e['a'], set()).add(e['b']); adj.setdefault(e['b'], set()).add(e['a'])
    depth = {}
    for root in order:
        if root in depth:
            continue
        depth[root] = 0
        q = [root]
        while q:
            x = q.pop(0)
            for y in sorted(adj.get(x, ())):
                if y not in depth:
                    depth[y] = depth[x] + 1; q.append(y)
    # ON lines per joined node
    onl = {}
    for e in edges:
        for c in e['cols']:
            ln = c
            if ln not in onl.setdefault(e['b'], []):
                onl[e['b']].append(ln)
    cols = {}
    for a in order:
        cols.setdefault(depth[a], []).append(a)
    GX, GY = 90, 30
    LH = 15
    nh = {a: 44 + (LH * (len(onl[a]) + 1) if onl.get(a) else 0) for a in order}
    def tw(txt, px):
        return sum(px * 1.7 if ord(ch) > 0x2E80 else px for ch in txt)
    nw = {}
    for a in order:
        t = nodes[a]
        w = max([tw(t, 7.4), tw(('alias ' + a) if a != t else '기준 테이블', 7.0)] + [tw('   ' + c, 6.8) for c in onl.get(a, [])])
        nw[a] = int(max(170, w + 24))
    colw = {d: max(nw[a] for a in lst) for d, lst in cols.items()}
    colx = {}
    x = 16
    for d in sorted(cols):
        colx[d] = x; x += colw[d] + GX
    pos = {}
    colh = {}
    for d, lst in cols.items():
        y = 16
        for a in lst:
            pos[a] = (colx[d], y)
            y += nh[a] + GY
        colh[d] = y - GY + 16
    width = x - GX + 16
    height = max(colh.values())
    esc = html.escape
    out = ['<svg class="jv" viewBox="0 0 %d %d" width="%d" height="%d" role="img" aria-label="조인 구조도">' % (width, height, width, height)]
    for e in edges:
        x1, y1 = pos[e['a']]; x2, y2 = pos[e['b']]
        h1, h2 = nh[e['a']], nh[e['b']]
        if x1 == x2:
            sx, sy, ex, ey = x1 + nw[e['a']], y1 + 22, x2 + nw[e['b']], y2 + 22
            path = 'M%d %d C%d %d %d %d %d %d' % (sx, sy, sx + 40, sy, ex + 40, ey, ex, ey)
            lx, ly = sx + 40, (sy + ey) / 2
        else:
            if x2 > x1:
                sx, ex = x1 + nw[e['a']], x2
            else:
                sx, ex = x1, x2 + nw[e['b']]
            sy, ey = y1 + 22, y2 + 22
            mx = (sx + ex) / 2
            path = 'M%d %d C%d %d %d %d %d %d' % (sx, sy, mx, sy, mx, ey, ex, ey)
            lx, ly = mx, (sy + ey) / 2
        out.append('<path class="edge e-%s" d="%s"/>' % (e['type'].lower(), path))
        out.append('<text class="elab" x="%d" y="%d" text-anchor="middle">%s</text>' % (lx, ly - 4, esc(e['type'])))
    for a in order:
        x, y = pos[a]
        t = nodes[a]
        known = t in A.TABLES
        base = (a == order[0])
        out.append('<g class="node%s%s"><rect x="%d" y="%d" width="%d" height="%d" rx="7"/>' % (' base' if base else '', '' if known else ' unk', x, y, nw[a], nh[a]))
        out.append('<text x="%d" y="%d" class="t1">%s</text>' % (x + 10, y + 19, esc(t)))
        out.append('<text x="%d" y="%d" class="t2">%s</text>' % (x + 10, y + 36, esc(('alias ' + a) if a != t else ('기준 테이블' if base else ''))))
        if onl.get(a):
            jts = []
            for e_ in edges:
                if e_['b'] == a and e_['type'] not in jts:
                    jts.append(e_['type'])
            out.append('<text x="%d" y="%d" class="t2 jt">%s</text>' % (x + 10, y + 36 + LH, esc(' / '.join(jts) if jts else 'ON')))
            for i, ln in enumerate(onl[a]):
                out.append('<text x="%d" y="%d" class="t3">%s</text>' % (x + 28, y + 36 + LH * (i + 2), esc(ln)))
        out.append('</g>')
    out.append('</svg>')
    legend = '<div class="jlegend"><span class="lg inner"></span>INNER JOIN <span class="lg left"></span>LEFT JOIN <span class="lg base"></span>기준(FROM) 테이블 <small class="muted">· 박스 안 ON 줄은 해당 테이블의 조인 조건 (정적 분석, 서브쿼리/UNION은 근사)</small>' + ('<br><small class="muted">마스터/명칭 조회용 조인 제외(기준 테이블 제외): %s</small>' % ', '.join(dict.fromkeys(dropped)) if dropped else '') + '</div>'
    return '<details class="joinviz" open><summary><b>%s조인 구조도</b> <small class="muted">테이블 %d · 조인 %d</small></summary><div class="wrap">%s</div>%s</details>' % (title, len(nodes), len(edges), ''.join(out), legend)

CSS = """
.tlrow{margin:6px 0}.tllab{display:inline-block;min-width:110px;color:var(--mut);font-size:12px;margin-right:6px}
a.tc{display:inline-block;font:12px Consolas,monospace;padding:1px 8px;margin:2px 4px 2px 0;border-radius:6px;border:1px solid var(--bd);background:var(--card);color:var(--fg)}
a.tc i{font:normal 10.5px "Malgun Gothic",sans-serif;margin-left:5px;color:var(--mut)}
a.tc.main{border:2px solid var(--ac)}a.tc.join{border-color:var(--ac)}a.tc.excl{border-style:dashed;opacity:.65}a.tc.wr{border-color:var(--w)}a.tc.wr i{color:var(--w)}

svg.jv{max-width:none}
svg.jv .node rect{fill:var(--card);stroke:var(--bd);stroke-width:1.5}
svg.jv .node.base rect{stroke:var(--ac);stroke-width:2.5}
svg.jv .node.unk rect{stroke-dasharray:4 3}
svg.jv .t1{font:600 12px Consolas,monospace;fill:var(--fg)}svg.jv .t2.jt{font-weight:700;fill:var(--ac)}svg.jv .t3{font:11px Consolas,monospace;fill:var(--ac)}svg.jv .t2{font:11px "Malgun Gothic",sans-serif;fill:var(--mut)}
svg.jv .edge{fill:none;stroke-width:2}
svg.jv .e-inner{stroke:var(--ac)}svg.jv .e-left,svg.jv .e-right,svg.jv .e-full{stroke:var(--r);stroke-dasharray:6 4}svg.jv .e-cross{stroke:var(--w)}
svg.jv .elab{font:10.5px Consolas,monospace;fill:var(--mut);paint-order:stroke;stroke:var(--bg);stroke-width:4px}
.jlegend{font-size:12px;margin-top:6px}.lg{display:inline-block;width:22px;height:0;border-top:2px solid;vertical-align:middle;margin:0 4px 0 12px}
.lg.inner{border-color:var(--ac)}.lg.left{border-color:var(--r);border-top-style:dashed}.lg.base{border:2px solid var(--ac);height:8px;width:14px;border-radius:3px}
"""


def _split_top(s, sep=','):
    parts, cur, depth = [], '', 0
    for ch in s:
        if ch == '(':
            depth += 1
        elif ch == ')':
            depth -= 1
        if ch == sep and depth == 0:
            parts.append(cur); cur = ''
        else:
            cur += ch
    if cur.strip():
        parts.append(cur)
    return parts

def _select_list(s):
    m = re.search(r'\bSELECT\b', s, re.I)
    if not m:
        return ''
    i = m.end()
    depth = 0
    for j in range(i, len(s)):
        c = s[j]
        if c == '(':
            depth += 1
        elif c == ')':
            depth -= 1
        elif depth == 0 and re.match(r'\bFROM\b', s[j:j + 5], re.I) and (j == 0 or not s[j - 1].isalnum() and s[j - 1] != '_'):
            return s[i:j]
    return s[i:]

SYS_TBL = re.compile(r'(CIM|CUS|CST|RPT|V)_', re.I)

def _outer_from_source(s, sel_end):
    """최상위 FROM 대상이 파생 테이블 '( SELECT .. ) alias' 또는 함수 호출 'fn(..) alias' 인 경우
    returns (kind, name_or_innersql, alias, rest_after) / 아니면 None"""
    m = re.compile(r'\s*\bFROM\s+', re.I).match(s, sel_end)
    if not m:
        return None
    i = m.end()
    fm = re.compile(r'([\w\.\[\]]+)\s*\(').match(s, i)
    if s[i:i + 1] == '(':
        kind, start, name = 'sub', i, None
    elif fm:
        kind, start, name = 'func', fm.end() - 1, A.clean_name(fm.group(1))
    else:
        return None
    depth = 0
    for j in range(start, len(s)):
        if s[j] == '(':
            depth += 1
        elif s[j] == ')':
            depth -= 1
            if depth == 0:
                break
    else:
        return None
    am = re.compile(r'\s*(?:AS\s+)?(\w+)', re.I).match(s, j + 1)
    alias = am.group(1) if am and am.group(1).upper() not in KW else None
    rest = s[am.end():] if am and alias else s[j + 1:]
    inner = s[start + 1:j] if kind == 'sub' else name
    return kind, inner, alias, rest

def main_info(sql):
    """그리드 컬럼 강조용: 쿼리 SELECT 결과 중 메인(기준) 테이블에서 오는 출력 컬럼명 집합.
    returns (table, set(UPPER names)) or None"""
    nodes, order, edges, s = parse_joins(sql)
    if not order:
        return None
    sel = _select_list(s)
    sel = re.sub(r'^\s*(?:DISTINCT|ALL)\b|^\s*TOP\s*\(?\d+\)?(?:\s+PERCENT)?', '', sel.strip(), flags=re.I)
    sm = re.search(r'\bSELECT\b', s, re.I)
    src = _outer_from_source(s, sm.end() + len(_select_list(s))) if sm else None
    if src and (src[2] or src[0] == 'sub'):
        kind, inner, dalias, rest = src
        if kind == 'sub':
            im = main_info(inner)
            if im:
                table, innames = im
            else:
                table, innames = None, None
        else:
            table, innames = inner, None          # 함수: 별칭 컬럼 전부 메인 취급
        if table:
            names = set()
            joined = bool(re.search(r'\bJOIN\b', rest, re.I))
            for item in _split_top(sel):
                it = item.strip()
                if not it:
                    continue
                if re.fullmatch(r'(?:\*|%s\.\*)' % re.escape(dalias or '#NONE#'), it, re.I):
                    if innames:
                        names |= innames
                    continue
                m1 = re.fullmatch(r'(?:(\w+)\.)?(\w+)(?:\s+(?:AS\s+)?\[?(\w+)\]?)?', it, re.I)
                if not m1 or (m1.group(1) is None and joined):
                    continue
                if m1.group(1) is not None and (dalias is None or m1.group(1) != dalias):
                    continue
                if m1.group(1) is None and m1.group(3) is None and m1.group(2).upper() in KW:
                    continue
                col = m1.group(2).upper()
                if innames is None or col in innames:
                    names.add((m1.group(3) or m1.group(2)).upper())
            return table, names
    cands = []
    for pred in (lambda t: t in A.TABLES or SYS_TBL.match(t), lambda t: t in A.TABLES):   # 시스템 테이블(spt_values 등)은 메인에서 제외
        c = next((a for a in order if pred(nodes[a])), None)
        if c and c not in cands:
            cands.append(c)
    res = None
    for base in cands or [order[0]]:
        res = _main_cols(nodes, base, sel)
        if res[1]:
            break
    return res

def _main_cols(nodes, base, sel):
    table = nodes[base]
    cols = {c[0].upper() for c in A.COLS.get(table, [])}   # DB에 없는 테이블이면 비어 있음(별칭 기준으로만 판정)
    names = set()
    single = len(nodes) == 1
    for item in _split_top(sel):
        it = item.strip()
        if not it:
            continue
        if re.fullmatch(r'\*', it) and single:
            names |= cols; continue
        m = re.fullmatch(r'(\w+)\.\*', it)
        if m:
            if m.group(1) == base:
                names |= cols
            continue
        am = re.search(r'(?:\bAS\s+|\s)\[?([A-Za-z_]\w*)\]?\s*$', it)
        refs = re.findall(r'\b(\w+)\.(\w+)\b', it)
        aliases = {a for a, _ in refs}
        out = None
        if re.fullmatch(r'\w+\.\w+', it):
            out = it.split('.')[1]
        elif am and (re.search(r'\bAS\b', it, re.I) or re.fullmatch(r'[\w\.]+\s+\w+', it)):
            out = am.group(1)
        elif re.fullmatch(r'\w+', it):
            out = it
        if out is None:
            continue
        if refs:
            if aliases == {base}:
                names.add(out.upper())
        elif (re.fullmatch(r'\w+', it) or (not refs and am and re.fullmatch(r'\w+\s+(?:AS\s+)?\[?\w+\]?', it, re.I))) and it.split()[0].upper() in cols:
            others = set()
            for a_, t_ in nodes.items():
                if a_ != base and t_ in A.TABLES:
                    others |= {c[0].upper() for c in A.COLS.get(t_, [])}
            if single or it.split()[0].upper() not in others:
                names.add(out.upper())
    return table, names
