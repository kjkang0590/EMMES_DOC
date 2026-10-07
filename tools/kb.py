# -*- coding: utf-8 -*-
"""Knowledge-base builder: DB (widgets, stored queries, menus, tables) + C# sources + decompiled framework."""
import os, re, json, pyodbc, glob, pickle
import config

ROOT = config.ROOT
SVC = ROOT + '/THiRAMES_Service'
DEC = config.DEC
OUT = config.CACHE + '/kb.pkl'

conn = config.connect()
cu = conn.cursor()
kb = {}

# ---- tables / columns / pk
tables = {}
for t, in cu.execute("select name from sys.tables union select name from sys.views").fetchall():
    tables[t.upper()] = t
cols = {}
for t, c, dt, ln in cu.execute("select TABLE_NAME,COLUMN_NAME,DATA_TYPE,CHARACTER_MAXIMUM_LENGTH from INFORMATION_SCHEMA.COLUMNS order by TABLE_NAME,ORDINAL_POSITION").fetchall():
    cols.setdefault(t.upper(), []).append((c, dt, ln))
pks = {}
for t, c in cu.execute("""select tc.TABLE_NAME,kcu.COLUMN_NAME from INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc
 join INFORMATION_SCHEMA.KEY_COLUMN_USAGE kcu on tc.CONSTRAINT_NAME=kcu.CONSTRAINT_NAME and tc.TABLE_NAME=kcu.TABLE_NAME
 where tc.CONSTRAINT_TYPE='PRIMARY KEY' order by kcu.ORDINAL_POSITION""").fetchall():
    pks.setdefault(t.upper(), []).append(c)
tdesc = {}
try:
    for t, d in cu.execute("select o.name, cast(ep.value as nvarchar(500)) from sys.extended_properties ep join sys.objects o on o.object_id=ep.major_id where ep.minor_id=0 and ep.name='MS_Description'").fetchall():
        tdesc[t.upper()] = d
except Exception:
    pass
kb['tables'] = tables; kb['cols'] = cols; kb['pks'] = pks; kb['tdesc'] = tdesc

# ---- 한글 표시명 (CIM_MULTILANGUAGE, LANGUAGE=KOR). FRONT 우선
ml = {}
for k, t, d in cu.execute("select LANGUAGECODEID,CODETYPE,LANGUAGECODEDATA from CIM_MULTILANGUAGE where LANGUAGE='KOR' and LANGUAGECODEDATA is not null order by case CODETYPE when 'FRONT' then 0 when 'MES' then 1 else 2 end").fetchall():
    ml.setdefault(k.strip().upper(), d.strip())
kb['ml'] = ml

# ---- widgets
widgets = {}
for r in cu.execute("select WIDGETID,WIDGETNAME,WIDGETTYPE,GRIDPROPERTY,COLUMNPROPERTY,SEARCHFILTER,PROCESSTRAN from CIM_WIDGET").fetchall():
    widgets[r[0]] = dict(id=r[0], name=r[1], type=r[2], grid=r[3], col=r[4], sf=r[5], pt=r[6])
kb['widgets'] = widgets

# ---- stored queries
sq = {}
for r in cu.execute("select STOREDQUERYID,STOREDQUERYVERSION,STOREDQUERYCLASSID,STOREDQUERYNAME,COMMANDTYPE,QUERYSTRING from CIM_STOREDQUERY").fetchall():
    sq.setdefault(r[0], []).append(dict(id=r[0], ver=r[1], cls=r[2], name=r[3], cmd=r[4], sql=r[5] or ''))
kb['sq'] = sq

# ---- menus
menus = {}
for r in cu.execute("select MENUID,MENUCLASSID,MENUNAME,MENUTYPE,VIEWID,PARENTID,SEQUENCE,DEPTH from CIM_MENU").fetchall():
    menus[(r[0], r[1])] = dict(id=r[0], cls=r[1], name=r[2], type=r[3], view=r[4], parent=r[5], seq=r[6], depth=r[7])
kb['menus'] = menus

# ---- modeler queries (decompiled resources)
mq = {}
for f in glob.glob(DEC + '/out/THiRAMES.Service.Modeler.Query.*') + glob.glob(DEC + '/out/Select*') + glob.glob(DEC + '/out/Cache*'):
    if os.path.isdir(f):
        continue
    nm = os.path.basename(f)
    key = nm.split('.')[-1]
    key = re.sub(r'_SqlDatabase$', '', key)
    try:
        mq[key.upper()] = dict(id=key, sql=open(f, encoding='utf-8', errors='replace').read(), src=nm)
    except Exception:
        pass
kb['mq'] = mq

# ---- decompiled rules (modeler) + API classes
rules = {}
for f in glob.glob(DEC + '/modeler/**/*.cs', recursive=True) + glob.glob(DEC + '/svcapi/**/*.cs', recursive=True):
    txt = open(f, encoding='utf-8', errors='replace').read()
    for m in re.finditer(r'class\s+(\w+)\s*(?::\s*([\w<>,\s\.]+?))?\s*\{', txt):
        rules.setdefault(m.group(1), []).append(dict(file=f, base=(m.group(2) or '').strip(), text=txt, kind='modeler'))
api = {}
for d in glob.glob(DEC + '/api_*'):
    for f in glob.glob(d + '/**/*.cs', recursive=True):
        txt = open(f, encoding='utf-8', errors='replace').read()
        for m in re.finditer(r'public\s+(?:static\s+)?class\s+(\w+)', txt):
            api[m.group(1).upper()] = dict(file=f, text=txt, dll=os.path.basename(d))
kb['rules'] = rules; kb['api'] = api

# ---- repo C# sources
cs_classes = {}   # class -> list(dict(file,text,proj))
methods = {}      # method name -> list(dict(cls,file,body))
constmap = {}     # QueryId constants
skip = ('\\obj\\', '/obj/', '.svn', '/bin/', '\\bin\\')
files = []
for dp, dn, fn in os.walk(SVC):
    dn[:] = [d for d in dn if d not in ('obj', '.svn', 'bin', '.codegraph', '.omo', '.vscode', 'nuget')]
    for f in fn:
        if f.endswith('.cs'):
            files.append(os.path.join(dp, f).replace('\\', '/'))

def brace_body(txt, start):
    i = txt.find('{', start)
    if i < 0:
        return ''
    depth = 0
    for j in range(i, len(txt)):
        c = txt[j]
        if c == '{':
            depth += 1
        elif c == '}':
            depth -= 1
            if depth == 0:
                return txt[i:j + 1]
    return txt[i:]

meth_re = re.compile(r'(?:public|internal|protected|private)\s+(?:static\s+|virtual\s+|override\s+|async\s+)*[\w<>\[\],\.\? ]+?\s+(\w+)\s*\([^;{}]*?\)\s*(?:where [^{]+)?\{')
for f in files:
    try:
        txt = open(f, encoding='utf-8-sig', errors='replace').read()
    except Exception:
        continue
    proj = f[len(SVC) + 1:].split('/')[0]
    for m in re.finditer(r'\bclass\s+(\w+)', txt):
        cs_classes.setdefault(m.group(1), []).append(dict(file=f, text=txt, proj=proj))
    for m in re.finditer(r'public\s+const\s+string\s+(\w+)\s*=\s*"([^"]+)"', txt):
        constmap.setdefault(m.group(1), m.group(2))
    cm = [(m.start(), m.group(1)) for m in re.finditer(r'\bclass\s+(\w+)', txt)]
    for m in meth_re.finditer(txt):
        if m.group(1) in ('if', 'for', 'foreach', 'while', 'switch', 'using', 'lock', 'catch'):
            continue
        cls = ''
        for pos, nm in cm:
            if pos < m.start():
                cls = nm
        body = brace_body(txt, m.end() - 1)
        methods.setdefault(m.group(1), []).append(dict(cls=cls, file=f, body=body, proj=proj))
kb['cs_classes'] = cs_classes; kb['methods'] = methods; kb['constmap'] = constmap
pickle.dump(kb, open(OUT, 'wb'))
print('tables', len(tables), 'widgets', len(widgets), 'sq', len(sq), 'mq', len(mq), 'rules', len(rules), 'api', len(api),
      'cs classes', len(cs_classes), 'methods', len(methods), 'const', len(constmap), 'menus', len(menus))
