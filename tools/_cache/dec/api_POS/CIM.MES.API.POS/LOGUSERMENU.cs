using System;
using System.Collections.Generic;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.POS;

public class LOGUSERMENU
{
	public static int CreateLogusermenuInternal(IDbContext dbContext, Logusermenu logusermenu)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("logusermenu", logusermenu);
		string text = "CreateLogusermenu";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		List<Logusermenu> list = new List<Logusermenu>();
		Logusermenu logusermenu2 = new Logusermenu();
		logusermenu.CopyColumsTo(logusermenu2);
		logusermenu2.Activity = text;
		logusermenu2.CheckEntityUsable();
		logusermenu.CopyCommonField(logusermenu2, systemTime, dbContext.Tid, isCreate: true);
		logusermenu2.Logdatetime = systemTime;
		list.Add(logusermenu2);
		int result = 0 + ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist: false);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return result;
	}
}
