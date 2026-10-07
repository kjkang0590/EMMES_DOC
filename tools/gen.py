# -*- coding: utf-8 -*-
import os, re, html, json, sys
import analyze as A
import join_viz

import config
UI = config.UI
OUT = config.DOCS
kb = A.kb
MENUS = kb['menus']
WIDGETS = kb['widgets']

def esc(s):
    return html.escape(str(s if s is not None else ''), quote=True)

FOLDER_NAMES = {
    'common': '공통 팝업/컴포넌트', 'dashboard': '대시보드', 'EM': 'EM 설비관리', 'MD': 'MD 기준정보', 'OP': 'OP 운영',
    'PM': 'PM 생산관리', 'PP': 'PP 생산계획', 'QM': 'QM 품질관리', 'RP': 'RP 리포트', 'RT': 'RT 실시간/조회', 'SM': 'SM 시스템관리', '_root': '기타(루트)'}

# ---- menu lookup by view path
view2menu = {}
for k, m in MENUS.items():
    if m['view']:
        view2menu[m['view'].lower()] = m
def breadcrumb(m):
    out = []
    cur = m; guard = 0
    while cur and guard < 8:
        out.append(cur['name']); guard += 1
        cur = MENUS.get((cur['parent'], cur['cls'])) if cur['parent'] else None
    return ' > '.join(reversed(out))

# ---- enumerate pages
pages = []
for dp, dn, fn in os.walk(UI):
    rel = os.path.relpath(dp, UI).replace('\\', '/')
    parts = rel.split('/')
    top = '_root' if rel == '.' else parts[0]
    if top == 'dashboard' and rel != 'dashboard':
        continue
    for f in sorted(fn):
        if not f.endswith('.html'):
            continue
        stem = f[:-5]
        pages.append(dict(folder=top, stem=stem, html=os.path.join(dp, f).replace('\\', '/'),
                          js=os.path.join(dp, stem + '.js').replace('\\', '/'), rel=('' if rel == '.' else rel + '/') + f))
common_names = sorted({p['stem'] for p in pages if p['folder'] == 'common'}, key=lambda x: -len(x))

def read(p):
    try:
        return open(p, encoding='utf-8-sig', errors='replace').read()
    except Exception:
        return ''

KIND = {'R': '조회', 'C': '등록/실행', 'U': '수정', 'D': '삭제'}
BTN_LABEL = {'findBtn': '조회', 'upsertBtn': '저장', 'delNewSoftBtn': '행삭제', 'addBottomBtn': '행추가', 'excelNcDownBtn': '엑셀 다운로드',
             'excelDownBtn': '엑셀 다운로드', 'excelUpBtn': '엑셀 업로드', 'btn_init': '초기화'}

def tbl_cells(tw):
    """tw: dict table-> set of modes -> html"""
    out = []
    for t in sorted(tw):
        modes = tw[t]
        mm = set(modes) - {'?'}
        if 'W' in mm:
            b = '<span class="b w">쓰기</span>'
            if 'R' in mm:
                b += '<span class="b r">읽기</span>'
        elif 'R' in mm:
            b = '<span class="b r">읽기</span>'
        else:
            b = '<span class="b u">참조</span>'
        out.append('<a class="tbl" href="../tables.html#%s">%s</a>%s' % (esc(t), esc(t), b))
    return '<br>'.join(out)

all_table_usage = {}   # table -> set((pagekey, mode))

def svc_tables(res):
    tw = {}
    q = res.get('query')
    if q:
        for t in q['tables_r']:
            tw.setdefault(t, set()).add('R')
        for t in q['tables_w']:
            tw.setdefault(t, set()).add('W')
    c = res.get('cmd')
    if c:
        for t, ms in c['tables'].items():
            tw.setdefault(t, set()).update(ms)
        for sq_ in c.get('sqls', []):
            r_, w_, f_, p_ = A.sql_info(sq_)
            for t in r_:
                tw.setdefault(t, set()).add('R')
            for t in w_:
                tw.setdefault(t, set()).add('W')
        for qid in c.get('queries', []):
            rq = A.resolve_query(qid)
            for t in rq['tables_r']:
                tw.setdefault(t, set()).add('R')
            for t in rq['tables_w']:
                tw.setdefault(t, set()).add('W')
    return tw

svc_registry = {}   # per page: key -> idx
def svc_key(res):
    q = res['query']; c = res['cmd']
    return (c['id'] if c else '') + '|' + (q['id'] if q else '')

def query_tables_html(q):
    """Query 항목의 '테이블' 표현: 쿼리 본문 + 함수/SP/View 별로 전체 조회/쓰기 테이블"""
    lines = []
    def line(label, sql):
        items = join_viz.classify(sql)
        if not items:
            return
        chips = []
        for t, role in items:
            b = ''
            if role == '메인':
                b += '<span class="b m">메인</span>'
            b += '<span class="b w">쓰기</span>' if role == '쓰기' else '<span class="b r">읽기</span>'
            chips.append('<a class="tbl" href="../tables.html#%s">%s</a>%s' % (esc(t), esc(t), b))
        lines.append('<div>%s%s</div>' % (('<small class="muted">%s</small> ' % esc(label)) if label else '', ' &nbsp; '.join(chips)))
    if q.get('sql'):
        line('', q['sql'])
    for o in q.get('objs', []):
        line('└ %s %s :' % (o['type'], o['name']), o['sql'])
    return ''.join(lines)

def query_viz(q):
    """테이블 리스트 + 조인 구조도(+함수/SP) + SQL 원문"""
    o_ = []
    if not q.get('sql'):
        return ''
    o_.append(join_viz.render(q['sql']))
    for o in q.get('objs', []):
        o_.append(join_viz.render(o['sql'], title='%s <code>%s</code> 의 ' % (o['type'], esc(o['name']))))
    if q.get('missing_objs'):
        o_.append('<p class="muted">DB(EM_MES_DEV)에서 정의를 찾지 못한 함수/SP: %s (다른 DB·외부 모듈에 있을 수 있어 조인 구조를 표시하지 못했습니다)</p>' % ' '.join('<code>%s</code>' % esc(x) for x in q['missing_objs']))
    o_.append('<details class="sql"><summary>SQL 보기</summary><pre>%s</pre></details>' % esc(q['sql'].strip()))
    for o in q.get('objs', []):
        o_.append('<details class="sql"><summary>%s %s 정의 보기</summary><pre>%s</pre></details>' % (esc(o['type']), esc(o['name']), esc(o['sql'].strip())))
    return ''.join(o_)

def embedded_query(sql):
    r, w, f, p = A.sql_info(sql)
    objs = A.sql_objects(sql)
    return dict(sql=sql, objs=objs, missing_objs=A.missing_objects(sql), params=p, tables_r=sorted(set(r) | {t for o in objs for t in o['reads']}), tables_w=sorted(set(w) | {t for o in objs for t in o['writes']}))

def render_page(pg):
    js = read(pg['js']); hm = read(pg['html'])
    stem = pg['stem']
    title = ''
    mpath = '/view/ngs/mes/' + pg['rel']
    menu = view2menu.get(mpath.lower())
    mt = re.search(r'<!--\s*(.*?)\s*-->', hm[:400])
    if menu:
        title = menu['name']
    elif mt and not mt.group(1).lower().startswith('doctype'):
        title = mt.group(1)
    data_page = re.search(r'data-page="(\w+)"', hm)
    # widget ids
    wids = []
    for m in re.finditer(r"""ngsWidget\.init\(\s*(\d+)\s*,\s*['"](\w+)['"]\s*,\s*(['"](\w+)['"]|[\w\.]+)""", js):
        pid = m.group(4) or (data_page.group(1) if data_page else stem)
        wid = pid + m.group(1)
        if wid not in wids:
            wids.append(wid)
    if not wids:
        for k in WIDGETS:
            if k.startswith(stem) and re.match(r'^(_\w*?)?\d+$', k[len(stem):]):
                wids.append(k)
    missing = [w for w in wids if w not in WIDGETS]
    wids = [w for w in wids if w in WIDGETS]
    if not title and wids:
        title = WIDGETS[wids[0]]['name'].split('_')[0]
    if not title:
        title = stem
    wparsed = [A.parse_widget(WIDGETS[w]) for w in wids]
    calls, all_refs = A.parse_js(js) if js else ([], [])
    ret_body = A.func_body(js, 'retrieveCallInit') if js else ''
    ret_keys = A.keys_in(ret_body) if ret_body else []

    rows = []      # dict(func, kind, refs, params, note)
    seen = set()
    def add(func, kind, refs, params, note=''):
        k = (func, kind, tuple(refs))
        if k in seen:
            return
        seen.add(k)
        rows.append(dict(func=func, kind=kind, refs=refs, params=params, note=note))

    for gi, w in enumerate(wparsed):
        gno = w['id']
        wlabel = '그리드 %s (%s)' % (gno, w['name'])
        action = w['action']
        if action:
            cmd, qcls, qid, qver, qp = A.parse_ref(action)
            fparams = [f['field'] for f in w['filters'] if f['type'] == 'FILTER']
            if qid:
                add('조회 - ' + wlabel, 'R 조회', [action.split('/', 1)[-1] if cmd else action], list(dict.fromkeys(qp + fparams + ret_keys)),
                    '조회 버튼(findBtn)/마스터-디테일 행선택 시 호출')
            if cmd:
                editable = [c['field'] for c in w['cols'] if c['edit'] or c['new'] or c['must']]
                add('저장/삭제 - ' + wlabel, 'C/U/D 저장', [cmd], editable + ['_ROW_STATE(A/U/D)'],
                    '저장 버튼(upsertBtn): 추가(A)/수정(U)/삭제(D) 행을 WEBDATA로 전송')
        for f in w['filters']:
            if f['dd']:
                add('검색조건 콤보 - %s (%s)' % (f['field'], f['head'] or w['name']), 'R 조회', [f['dd']], A.parse_ref(f['dd'])[4])
        for c in w['cols']:
            if c['dd']:
                add('컬럼 콤보/코드 - %s (%s)' % (c['field'], c['head']), 'R 조회', [c['dd']], A.parse_ref(c['dd'])[4])
    for c in calls:
        refs = c['refs'] or []
        lab = c['label'] or '-'
        func = lab + (' : ' + c['comment'] if c['comment'] else '')
        if not refs:
            continue
        for r in refs:
            add(func, KIND.get(c['type'], c['type']) + (' (변수 URL 추정)' if c['indirect'] else ''), [r], c['keys'], 'JS ngsWidget.ajax(%s)' % c['type'])
    # JS referenced but not through direct ajax
    used = {r for row in rows for r in row['refs']}
    for w in wparsed:
        used.add(w['action'])
        for f in w['filters']:
            used.add(f['dd'])
        for c in w['cols']:
            used.add(c['dd'])
    for r in all_refs:
        if r not in used and r.strip() and not any(r.split('?')[0] == u.split('?')[0] or r.split('?')[0] in u.split('?')[0] for u in used if u):
            add('기타 참조 (JS 문자열)', '참조', [r], A.parse_ref(r)[4], '')

    # 조회 - 그리드 기능을 맨 위(순번 상단)에 표시 (나머지는 기존 순서 유지)
    rows.sort(key=lambda r: 0 if r['func'].startswith('조회 - 그리드') else 1)
    # resolve
    svcs = {}   # key -> (idx, res)
    for row in rows:
        row['res'] = []
        for r in row['refs']:
            res = A.resolve(r)
            k = svc_key(res)
            if k not in svcs:
                svcs[k] = (len(svcs) + 1, res)
            row['res'].append((svcs[k][0], res))

    # buttons in html
    btns = []
    for m in re.finditer(r'id="(\w*[Bb]tn\w*)"', hm):
        bid = m.group(1)
        seg = hm[m.end():m.end() + 500]
        t = re.search(r'multi-lang[^>]*>\s*([^<\s][^<]*?)\s*<', seg)
        base = re.sub(r'\d+$', '', bid)
        lab = BTN_LABEL.get(base) or (t.group(1) if t else '')
        btns.append((bid, lab))
    popups = [n for n in common_names if len(n) >= 5 and re.search(r'(?<![\w])' + re.escape(n) + r'(?![\w])', js + hm) and n != stem]

    # ---- html
    h = []
    ph = lambda s: h.append(s)
    ph('<!DOCTYPE html><html lang="ko"><head><meta charset="utf-8"><meta name="viewport" content="width=device-width,initial-scale=1">')
    ph('<title>%s - %s</title><link rel="stylesheet" href="../style.css"></head><body>' % (esc(stem), esc(title)))
    ph('<header class="top"><a href="../index.html">← 전체 목록</a><a href="../tables.html">테이블 색인</a></header><main>')
    ph('<h1>%s <small>%s</small></h1>' % (esc(title), esc(stem)))
    ph('<table class="kv"><tr><th>화면 경로</th><td><code>THiRAMES_UI/wwwroot/view/ngs/mes/%s</code></td></tr>' % esc(pg['rel']))
    if menu:
        ph('<tr><th>메뉴 경로</th><td>%s <small>(MENUID: %s)</small></td></tr>' % (esc(breadcrumb(menu)), esc(menu['id'])))
    ph('<tr><th>화면 구분</th><td>%s</td></tr>' % esc(FOLDER_NAMES.get(pg['folder'], pg['folder'])))
    ph('<tr><th>위젯(Grid)</th><td>%s</td></tr>' % (', '.join('<code>%s</code>' % esc(w['id']) for w in wparsed) or '없음 (JS 직접 호출 또는 정적 화면)'))
    if missing:
        ph('<tr><th>미등록 위젯</th><td>%s <small class="muted">(JS에서 init 하나 DB CIM_WIDGET에 정의가 없음 → 조회/저장 서비스는 JS·호출 화면에서 전달)</small></td></tr>' % ', '.join('<code>%s</code>' % esc(w) for w in missing))
    if btns:
        ph('<tr><th>화면 버튼</th><td>%s</td></tr>' % ' '.join('<span class="chip">%s%s</span>' % (esc(b), (' · ' + esc(l)) if l else '') for b, l in btns))
    if popups:
        ph('<tr><th>연계 팝업(common)</th><td>%s</td></tr>' % ' '.join('<a class="chip" href="../common/%s.html">%s</a>' % (esc(p), esc(p)) for p in popups))
    ph('</table>')

    ph('<h2>1. 기능별 호출 서비스 / 파라메터 / 테이블</h2>')
    if not rows:
        ph('<p class="muted">서비스 호출이 없는 정적 화면이거나 위젯/JS에서 서비스 참조를 찾지 못했습니다.</p>')
    else:
        ph('<div class="wrap"><table class="grid"><thead><tr><th>#</th><th>기능</th><th>구분</th><th>호출 서비스</th><th>파라메터</th><th>DB 테이블</th></tr></thead><tbody>')
        for i, row in enumerate(rows, 1):
            sv = []; tw = {}
            for idx, res in row['res']:
                q = res['query']; c = res['cmd']
                if c:
                    sv.append('<a href="#svc-%d"><span class="tag rule">Rule</span> <code>%s</code></a>' % (idx, esc(c['id'])))
                if q:
                    sv.append('<a href="#svc-%d"><span class="tag q">Query</span> <code>%s</code></a> <small>%s</small>' % (idx, esc(q['id']), esc(q['cls'] or '')))
                for t, ms in svc_tables(res).items():
                    tw.setdefault(t, set()).update(ms)
            # params: prefer sql params, then UI params
            plist = []
            for idx, res in row['res']:
                q = res['query']; c = res['cmd']
                if q and not c:
                    for p in q['params']:
                        if p not in plist:
                            plist.append(p)
                if c and c['params']:
                    for p in c['params']:
                        if p not in plist:
                            plist.append(p)
            ui_only = [p for p in row['params'] if p not in plist]
            pcell = ''
            if plist:
                pcell += ' '.join('<code>%s</code>' % esc(p) for p in plist)
            if ui_only:
                pcell += ('<br>' if pcell else '') + '<span class="muted">UI 전달:</span> ' + ' '.join('<code class="ui">%s</code>' % esc(p) for p in ui_only)
            if not pcell:
                pcell = '<span class="muted">-</span>'
            for t, ms in tw.items():
                for m_ in (ms or {'?'}):
                    all_table_usage.setdefault(t, {}).setdefault(stem, set()).add(m_)
            ph('<tr id="fn-%d"><td>%d</td><td>%s%s</td><td>%s</td><td>%s</td><td class="params">%s</td><td>%s</td></tr>' % (
                i, i, esc(row['func']), ('<br><small class="muted">%s</small>' % esc(row['note'])) if row['note'] else '', esc(row['kind']),
                '<br>'.join(sv), pcell, tbl_cells(tw) or '<span class="muted">-</span>'))
        ph('</tbody></table></div>')

    ph('<h2>2. 서비스 상세</h2>')
    if not svcs:
        ph('<p class="muted">-</p>')
    for k, (idx, res) in sorted(svcs.items(), key=lambda x: x[1][0]):
        q = res['query']; c = res['cmd']
        # 그리드 조회와 연결된 서비스만 기본 펼침 (그 외 서비스·내부 쿼리는 접힘)
        gopen = any(r_['func'].startswith('조회 - 그리드') and any(ix_ == idx for ix_, _ in r_['res']) for r_ in rows)
        _op = ' open' if gopen else ''
        ph('<details id="svc-%d" class="svc"%s><summary><b>#%d</b> %s</summary>' % (idx, _op, idx, ' + '.join(
            ([('Rule <code>%s</code>' % esc(c['id']))] if c else []) + ([('Query <code>%s</code>' % esc(q['id']))] if q else []))))
        used = [(i_, r_['func'], r_['kind']) for i_, r_ in enumerate(rows, 1) if any(ix_ == idx for ix_, _ in r_['res'])]
        if used:
            ph('<p class="usedby"><b>연결된 기능</b> (1번 표): %s</p>' % ' '.join(
                '<a class="chip" href="#fn-%d">#%d %s</a>' % (i_, i_, esc(f_)) for i_, f_, k_ in used))
        if c:
            ph('<h4>Rule (저장/실행 서비스) : %s</h4><ul>' % esc(c['id']))
            ph('<li>구현 위치: %s%s</li>' % (esc(c['src']), (' - <code>%s</code>' % esc(c['file'])) if c['file'] else ''))
            if c.get('summary'):
                ph('<li>설명: %s</li>' % esc(c['summary']))
            if c.get('entity'):
                ph('<li>대상 엔티티: <code>%s</code>%s</li>' % (esc(c['entity']), (' / PK: ' + ', '.join('<code>%s</code>' % esc(x) for x in c.get('pk', []))) if c.get('pk') else ''))
            if c['params']:
                ph('<li>입력 파라메터(WEBDATA): %s</li>' % ' '.join('<code>%s</code>' % esc(p) for p in c['params']))
            if c['tables']:
                ph('<li>관련 테이블(코드 분석 기반): <br>%s</li>' % tbl_cells(c['tables']))
            if c.get('queries'):
                ph('<li>내부 호출 쿼리: %s</li>' % ' '.join('<code>%s</code>' % esc(x) for x in c['queries']))
            if c.get('sqls'):
                ph('<li>C# 코드 내 SQL 문자열: %d건</li>' % len(c['sqls']))
            if c.get('calls'):
                names = []
                for n, cl, pj in c['calls']:
                    s = '%s.%s' % (cl, n)
                    if s not in names:
                        names.append(s)
                ph('<li>호출 체인(Service 메서드): <small>%s</small></li>' % esc(', '.join(names[:25])))
            ph('</ul>')
            for qid in c.get('queries', []):
                rq = A.resolve_query(qid)
                tcount = len(set(rq['tables_r']) | set(rq['tables_w']))
                ph('<details class="svc"%s><summary>Rule 내부 호출 쿼리 <code>%s</code> <small class="muted">(%s · 테이블 %d)</small></summary>' % (_op, esc(qid), esc(rq['src'] or '정의 미확인'), tcount))
                if rq['params']:
                    ph('<p>쿼리 파라메터: %s</p>' % ' '.join('<code>%s</code>' % esc(p) for p in rq['params']))
                ph('<ul><li>테이블: %s</li></ul>' % query_tables_html(rq))
                ph(query_viz(rq))
                ph('</details>')
            multi, simple = [], []
            for sq_ in c.get('sqls', []):
                eq = embedded_query(sq_)
                nodes_, order_, edges_, s_ = join_viz.parse_joins(sq_)
                (multi if (edges_ or eq['objs']) else simple).append((sq_, eq))
            def _emit(i, sq_, eq, opened):
                lab = c.get('sqlsrc', {}).get(sq_, 'C# 코드 내 SQL')
                ph('<details class="svc"%s><summary>Rule 코드 내 SQL #%d <small class="muted">(%s · 테이블 %d)</small></summary>' % (
                    ' open' if opened else '', i, esc(lab), len(set(eq['tables_r']) | set(eq['tables_w']))))
                ph('<ul><li>테이블: %s</li></ul>' % (query_tables_html(eq) or '-'))
                ph(query_viz(eq))
                ph('</details>')
            for i, (sq_, eq) in enumerate(multi, 1):
                _emit(i, sq_, eq, gopen)
            if simple:
                ph('<details class="svc"><summary>Rule 코드 내 단순 SQL(단일 테이블) %d건 <small class="muted">- 펼쳐서 확인</small></summary>' % len(simple))
                for j, (sq_, eq) in enumerate(simple, len(multi) + 1):
                    _emit(j, sq_, eq, False)
                ph('</details>')
        if q:
            ph('<h4>Query (조회 서비스) : %s</h4><ul>' % esc(q['id']))
            ph('<li>ID 구성: <code>%s</code> / 클래스 <code>%s</code> / 버전 <code>%s</code></li>' % (esc(q['id']), esc(q['cls']), esc(q['ver'])))
            ph('<li>정의 위치: %s</li>' % esc(q['src']))
            if q['name']:
                ph('<li>쿼리명: %s</li>' % esc(q['name']))
            if q['params']:
                ph('<li>쿼리 파라메터: %s</li>' % ' '.join('<code>%s</code>' % esc(p) for p in q['params']))
            if q['tables_r'] or q['tables_w']:
                tw = {}
                for t in q['tables_r']:
                    tw.setdefault(t, set()).add('R')
                for t in q['tables_w']:
                    tw.setdefault(t, set()).add('W')
                ph('<li>테이블(조회/쓰기 전체, 함수·SP 포함): %s</li>' % (query_tables_html(q) or tbl_cells(tw)))
            if q['funcs']:
                ph('<li>함수/SP: %s</li>' % ' '.join('<code>%s</code>' % esc(x) for x in q['funcs']))
            ph('</ul>')
            ph(query_viz(q))
        ph('</details>')

    ph('<h2>3. 그리드 / 검색조건 정의</h2>')
    if not wparsed:
        ph('<p class="muted">-</p>')
    for w in wparsed:
        ph('<details><summary><b>%s</b> %s — 컬럼 %d, 검색조건 %d</summary>' % (esc(w['id']), esc(w['name']), len(w['cols']), len(w['filters'])))
        if w['action']:
            ph('<p>actionId: <code class="wrapc">%s</code></p>' % esc(w['action']))
        else:
            ph('<p class="muted">actionId 미정의 - 조회/저장 서비스는 JS 또는 호출 화면(팝업 파라메터)에서 동적으로 지정됩니다.</p>')
        if w['buttons']:
            ph('<p>ACTION 버튼 컬럼: %s</p>' % ' '.join('<code>%s</code>' % esc(b) for b in w['buttons'] if b))
        if w['filters']:
            ph('<h4>검색조건</h4><table class="grid sm"><thead><tr><th>필드</th><th>유형</th><th>표시명</th><th>표시명(한글)</th><th>콤보 서비스</th></tr></thead><tbody>')
            for f in w['filters']:
                ph('<tr><td><code>%s</code></td><td>%s</td><td>%s</td><td><b>%s</b></td><td class="wrapc">%s</td></tr>' % (esc(f['field']), esc(f['type']), esc(f['head']), esc(A.kor(f['head'], f['field'])), esc(f['dd'])))
            ph('</tbody></table>')
        mainset, maintab = set(), ''
        if w['action']:
            _cmd, _qc, _qid, _qv, _qp = A.parse_ref(w['action'])
            if _qid:
                _rq = A.resolve_query(_qid, _qc, _qv)
                if _rq.get('sql'):
                    _mi = join_viz.main_info(_rq['sql'])
                    if _mi:
                        maintab, mainset = _mi
                elif _rq.get('tables_r'):
                    # 정의 미확인(프레임워크 내장 GRD_*, CDS_*) → 쿼리 ID 명명규칙으로 추정한 테이블을 메인으로 간주
                    maintab = _rq['tables_r'][0]
                    mainset = {c[0].upper() for c in A.COLS.get(maintab, [])}
        if maintab:
            ph('<p class="muted">조회 쿼리의 메인 테이블 <a class="tbl" href="../tables.html#%s">%s</a>%s 에서 오는 컬럼은 <span class="mainmark">강조</span> 표시됩니다 (%d개 / %d개)</p>' % (
                esc(maintab), esc(maintab), ('' if _rq.get('sql') else ' (쿼리 정의 미확인 - ID 명명규칙 기반 추정)'), sum(1 for c in w['cols'] if (c['field'] or '').upper() in mainset), len(w['cols'])))
        if w['cols']:
            ph('<h4>컬럼</h4><table class="grid sm"><thead><tr><th>필드</th><th>표시명</th><th>표시명(한글)</th><th>편집</th><th>필수</th><th>콤보 서비스</th></tr></thead><tbody>')
            for c in w['cols']:
                _ism = (c['field'] or '').upper() in mainset
                ph('<tr%s><td><code>%s</code>%s</td><td>%s</td><td><b>%s</b></td><td>%s</td><td>%s</td><td class="wrapc">%s</td></tr>' % (
                    ' class="mainc"' if _ism else '', esc(c['field']), ' <span class="b m">메인</span>' if _ism else '', esc(c['head']), esc(A.kor(c['head'], c['field'])), 'Y' if (c['edit'] or c['new']) else '', 'Y' if c['must'] else '', esc(c['dd'])))
            ph('</tbody></table>')
        ph('</details>')
    ph('<footer>자동 생성 문서 · DB: EM_MES_DEV (10.130.11.100) · 소스: THiRAMES_UI / THiRAMES_Service · "추정"/"코드 분석 기반" 표기는 정적 분석 결과이므로 실제 동작과 다를 수 있습니다.</footer>')
    ph('</main></body></html>')
    return title, ''.join(h), dict(rows=len(rows), svcs=len(svcs), widgets=len(wparsed), menu=bool(menu), tables=sorted({t for r in rows for _, res in r['res'] for t in svc_tables(res)}))

def main(limit=None, only=None):
    os.makedirs(OUT, exist_ok=True)
    index = {}
    n = 0
    for pg in pages:
        if only and pg['stem'] not in only:
            continue
        if limit and n >= limit:
            break
        n += 1
        try:
            title, doc, meta = render_page(pg)
        except Exception as e:
            import traceback; traceback.print_exc()
            print('FAIL', pg['rel']); continue
        d = os.path.join(OUT, pg['folder'])
        os.makedirs(d, exist_ok=True)
        open(os.path.join(d, pg['stem'] + '.html'), 'w', encoding='utf-8').write(doc)
        index.setdefault(pg['folder'], []).append(dict(stem=pg['stem'], title=title, **meta))
    json.dump(index, open(os.path.join(OUT, '_index.json'), 'w', encoding='utf-8'), ensure_ascii=False)
    json.dump({t: {p: sorted(m) for p, m in v.items()} for t, v in all_table_usage.items()}, open(os.path.join(OUT, '_tables.json'), 'w', encoding='utf-8'), ensure_ascii=False)
    print('pages', n)

if __name__ == '__main__':
    only = sys.argv[1:] or None
    main(only=only)
