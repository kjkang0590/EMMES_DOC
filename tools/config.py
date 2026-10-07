# -*- coding: utf-8 -*-
"""Docs_UI 생성 도구 공통 설정. DB 접속 정보는 환경변수로만 받는다(코드/문서에 저장 금지)."""
import os
import pyodbc

TOOLS = os.path.dirname(os.path.abspath(__file__)).replace('\\', '/')
DOCS = os.path.dirname(TOOLS)                       # .../Docs_UI  (HTML 출력 위치)
ROOT = os.path.dirname(DOCS)                        # .../svn_ENMA_MES
UI = ROOT + '/THiRAMES_UI/wwwroot/view/ngs/mes'     # 문서화 대상 화면
CACHE = TOOLS + '/_cache'                           # 생성물(kb.pkl, 역컴파일 결과) - 버전관리 제외 권장
DEC = CACHE + '/dec'
BIN = ROOT + '/bin/net5'                            # 배포 DLL (역컴파일 대상)
os.makedirs(CACHE, exist_ok=True)

DB_SERVER = os.environ.get('MES_DB_SERVER', '10.130.11.100')
DB_NAME = os.environ.get('MES_DB_NAME', 'EM_MES_DEV')
DB_DRIVER = os.environ.get('MES_DB_DRIVER', 'ODBC Driver 17 for SQL Server')


def connect():
    uid = os.environ.get('MES_DB_UID')
    pwd = os.environ.get('MES_DB_PWD')
    if not uid or not pwd:
        raise SystemExit('환경변수 MES_DB_UID / MES_DB_PWD 를 설정하세요 (읽기 전용 계정). 예) set MES_DB_UID=... & set MES_DB_PWD=...')
    return pyodbc.connect('DRIVER={%s};SERVER=%s;DATABASE=%s;UID=%s;PWD=%s;TrustServerCertificate=yes' % (DB_DRIVER, DB_SERVER, DB_NAME, uid, pwd))
