# Docs_UI 조인 구조도 / 서비스 문서 생성 규칙

Docs_UI 문서를 만들 때 적용한 규칙 모음입니다. 규칙을 바꾸면 문서를 다시 생성해야 합니다.
(생성 스크립트: `tools/` — 사용법은 `tools/README.md`. 규칙 상수는 `tools/join_viz.py` 의 `FORCE_NAME`, `KEEP` 등)

- 기준 화면: `THiRAMES_UI/wwwroot/view/ngs/mes` (282 페이지)
- 서비스: `THiRAMES_Service` + 배포 DLL(`bin/net5`) 역컴파일
- DB: `EM_MES_DEV` (10.130.11.100) — 접속 계정은 문서에 포함하지 않음

---

## 1. 서비스 해석 규칙

| 구분 | 설명 |
|---|---|
| 조회 서비스 (Query) | `...$RuleMultiInquiry$<클래스>$<쿼리ID>$<버전>` 형태. DB `CIM_STOREDQUERY` → 없으면 Modeler 내장 쿼리(`THiRAMES.Service.Modeler.MSSQL` DLL 리소스) 순으로 SQL 조회 |
| 저장/실행 서비스 (Rule) | `<Command>/<조회ID>` 의 `<Command>` 또는 `ajax('C'/'U'/'D', 'Name$Class')`. C# Business 클래스(소스) → 없으면 Modeler Rule(DLL 역컴파일) |
| 위젯 정의 | `CIM_WIDGET` (`WIDGETID = 페이지ID + 위젯번호`)의 `actionId`, 검색조건(콤보), 컬럼 |
| 파라메터 | 쿼리: SQL의 `@PARAM`/`:PARAM` (주석 `--Param :` 우선). Rule: `//Param :` 주석, `nameof(Columns.X)`. JS가 추가로 넘기는 값은 "UI 전달"로 구분 |
| 테이블 | SQL의 FROM/JOIN(읽기), INSERT/UPDATE/DELETE/MERGE(쓰기). Rule은 코드 정적 분석 기반 **추정** |
| 함수/SP/View | DB `sys.sql_modules` 정의를 최대 3단계 전개하여 테이블·구조도 포함. 정의가 DB에 없는 SP는 "정의를 찾지 못함"으로 표시 |
| Rule 내부 쿼리 | Rule/Manager 호출 체인(3단계)에서 `QueryId` 상수·쿼리ID 문자열로 호출되는 저장 쿼리 |
| Rule 코드 내 SQL | C# 문자열 SQL, `THiRAMES.Service.API`의 `_sql*` 필드, 프레임워크 API(`CIM.MES.API.*`) 메서드 SQL(SqlDatabase용만, Oracle 제외) |

## 2. 조인 구조도 표시 규칙

### 2.1 표현
- 박스 = 테이블, 파란 굵은 테두리 = **기준(FROM) 테이블**, 점선 테두리 = DB에 없는 이름(임시테이블/CTE 등)
- 박스 내용: 테이블명 → `alias X` → **조인 종류(INNER / LEFT …)** → 조인 조건 컬럼(한 줄에 한 조건, 들여쓰기)
- 선: 파란 실선 = INNER, 초록 점선 = LEFT/RIGHT/FULL. 선 위에는 조인 종류만 표시 (ON 컬럼은 박스 안)
- 박스 크기는 글자(테이블명, alias, 조건)가 모두 보이도록 자동 조정, 조건 개수 제한 없음
- 메인(기준) 테이블은 조인이 모두 제외되어도, 단일 테이블 쿼리여도 **항상 표시**
- 제외된 테이블은 구조도 하단 범례에 `마스터/명칭 조회용 조인 제외(기준 테이블 제외): ...` 로 표기

### 2.2 구조도에서 제외하는 조인 대상 (기준 테이블에는 적용하지 않음)

**(a) 항상 제외 — 고정 목록 (`FORCE_NAME`)**

| 테이블 |
|---|
| `CIM_CODE` |
| `CIM_STATE` |
| `CIM_MATERIALDEFINITION` |
| `CIM_PRODUCTDEFINITION` |
| `CIM_PROCESSSEGMENT` |
| `CIM_EQUIPMENT` |

**(b) 마스터 테이블 자동 제외**
- 마스터 판정: **일자 컬럼이 없고** **자동증가(IDENTITY) 컬럼이 없는** 테이블
  - 일자 컬럼 = 타입이 `date/datetime/datetime2/smalldatetime/datetimeoffset` 이거나 컬럼명이 `DATE`/`TIME` 으로 끝나는 컬럼
  - 모든 테이블 공통 감사 컬럼(`CREATETIME`, `MODIFYTIME`, `LASTEVENTTIME`)은 일자 컬럼으로 보지 않음
- 단, **다른 테이블이 이 테이블을 거쳐 조인하는 연결 고리**면 제외하지 않음 (뒤쪽 테이블이 끊기므로)
- 마스터 판정 **예외(항상 표시)** — `KEEP` 목록:

| 테이블 |
|---|
| `CIM_ALARM` |
| `CIM_INSPRESULT` |
| `CIM_LOTHOLD` |
| `CIM_LOTTRACE` |
| `CIM_LOTBATCHREL` |
| `CIM_LOTCARRIERREL` |

**(c) 명칭 조회용 조인 자동 제외**
- 그 테이블에서 참조하는 컬럼이 `*NAME`, `*DESC`, `*DESCRIPTION`, `*TEXT`, `*LABEL` 뿐이고(자신의 ON 컬럼 제외), 다른 조인의 대상이 아닌 경우

**(d) SELECT 목록의 스칼라 서브쿼리**
- `SELECT` 목록에서 값을 가져오는 `(SELECT ... FROM ...) AS XXXNAME`, `ISNULL((SELECT ...),'')`, `CASE ... THEN (SELECT ...)` 은 구조도에서 제외
- 판정: `(SELECT` 바로 앞 토큰이 `,` `SELECT` `THEN` `ELSE` `WHEN` `+` 또는 함수 호출의 `(`
- 유지: `WHERE ... IN/EXISTS/= (SELECT ...)`, FROM/JOIN 절 서브쿼리, CTE
- 구조도에서만 제외하며, 그 서브쿼리가 읽는 테이블은 `테이블` 항목에는 계속 표시

## 3. 문서 항목 구성 (Query / Rule)

- **Query (조회 서비스)** 항목의 `테이블` 칸: 조회/쓰기 전체 테이블을 나열. 쿼리 본문 → `└ 함수/SP/View` 별로 줄 분리, 기준 테이블에 `메인` 표시, 제외된 테이블도 모두 포함
- 구조도 → SQL 보기 → (함수/SP/View 구조도 및 정의 보기)
- **Rule** 항목: 구현 위치, 파라메터, 관련 테이블(추정), 호출 체인, `Rule 내부 호출 쿼리`(구조도 포함), `Rule 코드 내 SQL`(출처 표기, 조인 있는 SQL은 펼침 / 단일 테이블 단순 SQL은 묶어서 접힘)
- "2. 서비스 상세"의 각 서비스 항목은 기본 **펼침**

## 4. 한계 / 주의

- SQL 정적 분석 결과이므로 서브쿼리·UNION·동적 SQL·임시테이블 흐름은 근사
- `string.Format`/변수로 조립되는 C# SQL, Oracle 전용 SQL은 제외
- Rule의 테이블(읽기/쓰기)은 호출 체인 분석 기반 추정 (실제와 다를 수 있음)
- DB에 정의가 없는 SP(리포트 계열 등)는 구조도를 그리지 못함 — 해당 DB 접속 정보가 있으면 확장 가능
