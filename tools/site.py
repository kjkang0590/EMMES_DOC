# -*- coding: utf-8 -*-
import json, html, os
import analyze as A
import join_viz
import config
OUT = config.DOCS
esc = lambda s: html.escape(str(s if s is not None else ''), quote=True)
ix = json.load(open(OUT + '/_index.json', encoding='utf-8'))
tu = json.load(open(OUT + '/_tables.json', encoding='utf-8'))
FN = {'common': '공통 팝업/컴포넌트', 'dashboard': '대시보드', 'EM': 'EM 설비관리', 'MD': 'MD 기준정보', 'OP': 'OP 운영',
      'PM': 'PM 생산관리', 'PP': 'PP 생산계획', 'QM': 'QM 품질관리', 'RP': 'RP 리포트', 'RT': 'RT 실시간/조회', 'SM': 'SM 시스템관리', '_root': '기타(루트)'}
ORDER = ['MD', 'PP', 'PM', 'QM', 'EM', 'SM', 'RP', 'RT', 'OP', 'common', 'dashboard', '_root']

CSS = """
:root{--bg:#f6f7f9;--fg:#1d2330;--mut:#6b7385;--card:#fff;--bd:#dfe3ea;--ac:#2456d6;--r:#0f7b4f;--w:#c2410c;--code:#eef1f6}
@media (prefers-color-scheme:dark){:root{--bg:#12151c;--fg:#e6e9f0;--mut:#9aa3b5;--card:#1a1f2a;--bd:#2b3242;--ac:#7aa2ff;--r:#4ade80;--w:#fb923c;--code:#252c3b}}
*{box-sizing:border-box}body{margin:0;background:var(--bg);color:var(--fg);font:14px/1.55 "Malgun Gothic","Apple SD Gothic Neo",system-ui,sans-serif}
a{color:var(--ac);text-decoration:none}a:hover{text-decoration:underline}
.top{display:flex;gap:18px;padding:10px 20px;background:var(--card);border-bottom:1px solid var(--bd);position:sticky;top:0;z-index:5}
main{max-width:1500px;margin:0 auto;padding:20px}
h1{font-size:22px;margin:6px 0 14px}h1 small{color:var(--mut);font-weight:400;font-size:14px;margin-left:8px}
h2{font-size:17px;margin:28px 0 10px;padding-bottom:6px;border-bottom:2px solid var(--bd)}h4{margin:12px 0 6px}
code{background:var(--code);padding:1px 5px;border-radius:4px;font:12px/1.4 Consolas,monospace;word-break:break-all}
code.ui{opacity:.75;border:1px dashed var(--bd)}
.wrapc{word-break:break-all;font-family:Consolas,monospace;font-size:12px}
.muted,small{color:var(--mut)}
.wrap{overflow-x:auto}
table{border-collapse:collapse;width:100%}
table.kv th{width:140px;text-align:left;vertical-align:top;color:var(--mut);font-weight:600;padding:5px 10px 5px 0}table.kv td{padding:5px 0}
table.grid{background:var(--card);border:1px solid var(--bd)}
table.grid th{background:var(--code);text-align:left;padding:7px 9px;font-size:12px;white-space:nowrap;border-bottom:1px solid var(--bd)}
table.grid td{padding:7px 9px;border-top:1px solid var(--bd);vertical-align:top}
table.grid td.params{max-width:420px}
table.sm td,table.sm th{padding:4px 8px;font-size:12px}
.tag{display:inline-block;font-size:11px;padding:0 6px;border-radius:9px;color:#fff;margin-right:3px}.tag.rule{background:#7c3aed}.tag.q{background:#0e7490}
.b{display:inline-block;font-size:10.5px;padding:0 6px;border-radius:9px;margin-left:4px;border:1px solid}.b.r{color:var(--r);border-color:var(--r)}.b.w{color:var(--w);border-color:var(--w)}.b.u{color:var(--mut);border-color:var(--mut)}.b.m{color:var(--ac);border-color:var(--ac);font-weight:700}
a.tbl{font:12px Consolas,monospace}
.chip{display:inline-block;background:var(--code);border-radius:12px;padding:1px 9px;margin:1px 3px 1px 0;font-size:12px}
details{background:var(--card);border:1px solid var(--bd);border-radius:8px;padding:8px 12px;margin:8px 0}summary{cursor:pointer}
pre{background:var(--code);padding:10px;border-radius:6px;overflow:auto;font:12px/1.5 Consolas,monospace}
tr.mainc td{background:color-mix(in srgb,var(--ac) 14%,transparent);font-weight:600}
.mainmark{background:color-mix(in srgb,var(--ac) 14%,transparent);font-weight:700;padding:0 6px;border-radius:4px}
p.usedby{margin:6px 0 10px;font-size:13px}
tr:target td{outline:2px solid var(--ac);outline-offset:-2px}
details.svc:target{border-color:var(--ac)}
footer{margin:36px 0 10px;color:var(--mut);font-size:12px}
.cards{display:grid;grid-template-columns:repeat(auto-fill,minmax(300px,1fr));gap:8px}
.card{background:var(--card);border:1px solid var(--bd);border-radius:8px;padding:8px 12px;display:block;color:var(--fg)}
.card:hover{border-color:var(--ac);text-decoration:none}.card b{display:block}.card span{color:var(--mut);font-size:12px}
input.q{width:100%;max-width:520px;padding:9px 12px;border:1px solid var(--bd);border-radius:8px;background:var(--card);color:var(--fg);font-size:14px}
@media(max-width:700px){main{padding:12px}.top{padding:8px 12px}}
"""
open(OUT + '/style.css', 'w', encoding='utf-8').write(CSS + join_viz.CSS)

# ---- index
h = ['<!DOCTYPE html><html lang="ko"><head><meta charset="utf-8"><meta name="viewport" content="width=device-width,initial-scale=1"><title>THiRAMES MES UI 페이지 문서</title><link rel="stylesheet" href="style.css"></head><body>']
h.append('<header class="top"><b>THiRAMES MES 페이지별 서비스 문서</b><a href="tables.html">테이블 색인</a></header><main>')
total = sum(len(v) for v in ix.values())
h.append('<h1>THiRAMES MES UI 페이지 문서 <small>%d 페이지</small></h1>' % total)
h.append('<p class="muted">기준: <code>THiRAMES_UI/wwwroot/view/ngs/mes</code> · 서비스: <code>THiRAMES_Service</code> + 배포 DLL(<code>bin/net5</code>) · DB: <code>EM_MES_DEV</code> (10.130.11.100)<br>'
         '각 페이지에서 <b>기능별 호출 서비스 / 파라메터 / DB 테이블</b>을 확인할 수 있습니다. 조회 서비스는 DB의 저장 쿼리(CIM_STOREDQUERY)·Modeler 내장 쿼리, 저장/실행 서비스는 C# Rule 클래스에 해당합니다.</p>')
h.append('<input class="q" id="q" placeholder="페이지ID / 화면명 / 테이블 검색..." autofocus>')
for f in ORDER:
    if f not in ix:
        continue
    lst = sorted(ix[f], key=lambda x: x['stem'])
    h.append('<h2 class="grp">%s <small>%d</small></h2><div class="cards">' % (esc(FN.get(f, f)), len(lst)))
    for p in lst:
        h.append('<a class="card" data-s="%s" href="%s/%s.html"><b>%s</b><span>%s · 호출 %d · 서비스 %d · 테이블 %d</span></a>' % (
            esc((p['stem'] + ' ' + p['title'] + ' ' + ' '.join(p['tables'])).lower()), esc(f), esc(p['stem']), esc(p['title']), esc(p['stem']), p['rows'], p['svcs'], len(p['tables'])))
    h.append('</div>')
h.append("""</main><script>
const q=document.getElementById('q');q.addEventListener('input',()=>{const v=q.value.trim().toLowerCase();
document.querySelectorAll('.card').forEach(c=>{c.style.display=(!v||c.dataset.s.includes(v))?'':'none'});
document.querySelectorAll('.grp').forEach(g=>{const n=g.nextElementSibling;g.style.display=[...n.children].some(c=>c.style.display!=='none')?'':'none';n.style.display=g.style.display});});
</script></body></html>""")
open(OUT + '/index.html', 'w', encoding='utf-8').write(''.join(h))

# ---- table index
title = {}
for f, lst in ix.items():
    for p in lst:
        title[p['stem']] = (f, p['title'])
t = ['<!DOCTYPE html><html lang="ko"><head><meta charset="utf-8"><meta name="viewport" content="width=device-width,initial-scale=1"><title>테이블 색인</title><link rel="stylesheet" href="style.css"></head><body>']
t.append('<header class="top"><a href="index.html">← 전체 목록</a><b>테이블 색인</b></header><main><h1>테이블 → 사용 페이지 색인 <small>%d 테이블</small></h1>' % len(tu))
t.append('<input class="q" id="q" placeholder="테이블명 검색...">')
for tb in sorted(tu):
    cols = A.COLS.get(tb, [])
    pk = A.PKS.get(tb, [])
    t.append('<details class="tb" id="%s" data-s="%s"><summary><b>%s</b> <small>%d개 페이지 · 컬럼 %d</small></summary>' % (esc(tb), esc(tb.lower()), esc(tb), len(tu[tb]), len(cols)))
    if cols:
        t.append('<p class="wrapc">%s</p>' % ', '.join(('<b>%s</b>' % esc(c[0])) if c[0] in pk else esc(c[0]) for c in cols if c[0] not in A.AUDIT))
    t.append('<p>')
    for pg, ms in sorted(tu[tb].items()):
        f, ti = title.get(pg, ('', pg))
        mm = set(ms) - {'?'}
        b = ('<span class="b w">쓰기</span>' if 'W' in mm else '') + ('<span class="b r">읽기</span>' if 'R' in mm else '') or '<span class="b u">참조</span>'
        t.append('<a class="chip" href="%s/%s.html">%s · %s</a>%s ' % (esc(f), esc(pg), esc(pg), esc(ti), b))
    t.append('</p></details>')
t.append("""</main><script>const q=document.getElementById('q');q.addEventListener('input',()=>{const v=q.value.trim().toLowerCase();
document.querySelectorAll('details.tb').forEach(d=>{d.style.display=(!v||d.dataset.s.includes(v))?'':'none'});});
if(location.hash){const e=document.getElementById(decodeURIComponent(location.hash.slice(1)));if(e){e.open=true;e.scrollIntoView();}}
</script></body></html>""")
open(OUT + '/tables.html', 'w', encoding='utf-8').write(''.join(t))
print('ok', total, len(tu))
