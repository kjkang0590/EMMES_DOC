# -*- coding: utf-8 -*-
"""배포 DLL(bin/net5)을 ilspycmd 로 역컴파일하여 _cache/dec 에 저장.
필요: dotnet tool install -g ilspycmd  (현재 .NET 런타임이 6.0이 아니면 DOTNET_ROLL_FORWARD=Major 사용)
"""
import os, subprocess, sys
import config

TARGETS = {
    'out': 'THiRAMES.Service.Modeler.MSSQL.2ndBattery.dll',   # Modeler 내장 조회 쿼리(SQL 리소스)
    'modeler': 'THiRAMES.Service.Modeler.2ndBattery.dll',      # MD_*Save 등 Modeler Rule
    'svcapi': 'THiRAMES.Service.API.2ndBattery.dll',
    'api_CDS': 'CIM.MES.API.CDS.dll', 'api_PMS': 'CIM.MES.API.PMS.dll', 'api_POS': 'CIM.MES.API.POS.dll',
    'api_PPS': 'CIM.MES.API.PPS.dll', 'api_QMS': 'CIM.MES.API.QMS.dll', 'api_RDS': 'CIM.MES.API.RDS.dll',
    'api_DAS': 'CIM.MES.API.DAS.dll', 'api_CUSTOM': 'CIM.MES.API.CUSTOM.dll',
}

env = dict(os.environ, DOTNET_ROLL_FORWARD='Major')
for out, dll in TARGETS.items():
    dst = os.path.join(config.DEC, out)
    if os.path.isdir(dst) and os.listdir(dst):
        print('skip (exists):', out)
        continue
    print('decompile', dll, '->', out)
    r = subprocess.run(['ilspycmd', '-p', '-o', dst, os.path.join(config.BIN, dll)], env=env, capture_output=True, text=True)
    if r.returncode != 0:
        print('  FAILED:', r.stderr[:300], file=sys.stderr)
