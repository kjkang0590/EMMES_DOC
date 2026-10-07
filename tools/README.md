# Docs_UI 생성 도구

`Docs_UI` 의 HTML 문서를 만드는 스크립트입니다. 규칙은 `../JOIN_RULES.md` 참고.

## 준비
- Python 3 + `pyodbc`, ODBC Driver 17 for SQL Server
- (역컴파일용) `dotnet tool install -g ilspycmd`  (.NET 6 런타임이 없으면 `DOTNET_ROLL_FORWARD=Major` 필요 - decompile.py가 자동 지정)
- DB 읽기 전용 계정을 **환경변수**로 지정 (코드/문서에 저장하지 않음)

```
set MES_DB_UID=<읽기전용 계정>
set MES_DB_PWD=<비밀번호>
rem 선택: MES_DB_SERVER(기본 10.130.11.100), MES_DB_NAME(기본 EM_MES_DEV)
```

## 실행
```
cd Docs_UI\tools
python run_all.py                    # 역컴파일(최초 1회, 이후 자동 skip) + kb + 페이지 + 색인
python run_all.py --skip-decompile   # 역컴파일 생략
```

## 구성
| 파일 | 역할 |
|---|---|
| `config.py` | 경로/DB 접속 설정 (접속 계정은 환경변수) |
| `decompile.py` | `bin/net5` DLL → `_cache/dec` 역컴파일 (Modeler 쿼리/Rule, 프레임워크 API) |
| `kb.py` | DB(위젯, 저장 쿼리, 메뉴, 테이블/컬럼) + C# 소스 + 역컴파일 결과를 `_cache/kb.pkl` 로 수집 |
| `analyze.py` | 서비스 해석(쿼리/Rule), 호출 체인·테이블 추정, 화면 JS/위젯 파싱 |
| `sqlx.py` | C#/역컴파일 코드에서 SQL 문자열 추출 |
| `join_viz.py` | SQL 조인 분석 및 SVG 구조도, 제외 규칙(`FORCE_NAME`, `KEEP`, 마스터 판정 등) |
| `gen.py` | 페이지별 HTML 생성 |
| `site.py` | `index.html`, `tables.html`, `style.css` 생성 |
| `run_all.py` | 전체 순서 실행 |

## 규칙 변경
- 항상 제외 테이블: `join_viz.py` 의 `FORCE_NAME`
- 마스터 판정 예외(항상 표시): `join_viz.py` 의 `KEEP`
- 변경 후 `python run_all.py --skip-decompile` 로 재생성

## 버전관리
- `_cache/` (kb.pkl, 역컴파일 결과 약 25MB)는 생성물이므로 버전관리에서 제외하세요 (svn: `svn propset svn:ignore _cache .`).
