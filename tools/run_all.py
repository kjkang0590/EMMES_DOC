# -*- coding: utf-8 -*-
"""전체 재생성: (선택) 역컴파일 → kb 구축 → 페이지 HTML → 색인/CSS.
사용: python run_all.py [--skip-decompile]
"""
import os, subprocess, sys
import config

here = config.TOOLS
py = sys.executable
steps = [] if '--skip-decompile' in sys.argv else [['decompile.py']]
steps += [['kb.py'], ['gen.py'], ['site.py']]
for s in steps:
    print('==', ' '.join(s))
    r = subprocess.run([py] + s, cwd=here)
    if r.returncode:
        sys.exit(r.returncode)
# 중간 산출물 정리
for f in ('_index.json', '_tables.json'):
    p = os.path.join(config.DOCS, f)
    if os.path.exists(p):
        os.remove(p)
print('done ->', config.DOCS)
