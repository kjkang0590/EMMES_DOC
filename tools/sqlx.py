# -*- coding: utf-8 -*-
"""C# 소스/역컴파일 코드에서 SQL 문자열 추출."""
import re

LIT_RE = re.compile(r'@"((?:[^"]|"")*)"|"((?:[^"\\\n]|\\.)*)"')
SQL_LIKE = re.compile(r'SELECT[\s\S]*FROM|INSERT\s+INTO|UPDATE[\s\S]*SET|DELETE\s+FROM', re.I)

def sql_literals(text):
    out = []
    for m in LIT_RE.finditer(text):
        lit = (m.group(1) if m.group(1) is not None else m.group(2) or '').replace('""', '"')
        if len(lit) > 25 and SQL_LIKE.search(lit) and lit not in out:
            out.append(lit)
    return out

def sql_field(name, ctx):
    m = re.search(r'\b' + re.escape(name) + r'\s*=\s*(.*?);', ctx, re.S)
    if not m:
        return ''
    parts = []
    for x in LIT_RE.finditer(m.group(1)):
        parts.append((x.group(1) if x.group(1) is not None else x.group(2) or '').replace('""', '"'))
    return ''.join(parts)

def field_names(text):
    return [n for n in dict.fromkeys(re.findall(r'\b(_sql\w+)\b', text)) if not n.lower().endswith('oracledatabase')]

def brace_body(txt, start):
    i = txt.find('{', start)
    if i < 0:
        return ''
    depth = 0
    for j in range(i, len(txt)):
        if txt[j] == '{':
            depth += 1
        elif txt[j] == '}':
            depth -= 1
            if depth == 0:
                return txt[i:j + 1]
    return txt[i:]

def api_method_sqls(api_text, method):
    """역컴파일된 API 클래스에서 method 본문이 쓰는 SQL(SqlDatabase용) 문자열"""
    out = []
    for m in re.finditer(r'public\s+static\s+[^\n(]*?\b' + re.escape(method) + r'\s*\(', api_text):
        body = brace_body(api_text, m.end())
        for nm in field_names(body):
            lit = sql_field(nm, api_text)
            if len(lit) > 15 and lit not in out:
                out.append(lit)
    return out
