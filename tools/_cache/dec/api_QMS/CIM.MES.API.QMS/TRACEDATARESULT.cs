using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.QMS;

[MESAPI]
public class TRACEDATARESULT
{
	private static string _sqlGetTraceDataResultSqlDatabase = "SELECT * FROM CIM_TRACEDATARESULT WHERE TRACEDATARESULTSYSID=@TRACEDATARESULTSYSID AND SITEID=@SITEID";

	private static string _sqlGetTraceDataResult4UpdateSqlDatabase = "SELECT * FROM CIM_TRACEDATARESULT WITH(UPDLOCK) WHERE TRACEDATARESULTSYSID=@TRACEDATARESULTSYSID AND SITEID=@SITEID";

	private static string _sqlSelectTraceDataResultSqlDatabase = "SELECT * FROM CIM_TRACEDATARESULT WHERE TRACEDATARESULTSYSID=@TRACEDATARESULTSYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectTraceDataResult4UpdateSqlDatabase = "SELECT * FROM CIM_TRACEDATARESULT WITH(UPDLOCK) WHERE TRACEDATARESULTSYSID=@TRACEDATARESULTSYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetTraceDataResultOracleDatabase = "SELECT * FROM CIM_TRACEDATARESULT WHERE TRACEDATARESULTSYSID=:TRACEDATARESULTSYSID AND SITEID=:SITEID";

	private static string _sqlGetTraceDataResult4UpdateOracleDatabase = "SELECT * FROM CIM_TRACEDATARESULT WHERE TRACEDATARESULTSYSID=:TRACEDATARESULTSYSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectTraceDataResultOracleDatabase = "SELECT * FROM CIM_TRACEDATARESULT WHERE TRACEDATARESULTSYSID=:TRACEDATARESULTSYSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectTraceDataResult4UpdateOracleDatabase = "SELECT * FROM CIM_TRACEDATARESULT WHERE TRACEDATARESULTSYSID=:TRACEDATARESULTSYSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Tracedataresult);

	public static Tracedataresult GetTraceDataResult(IDbContext dbContext, long tracedataresultsysid, string siteid)
	{
		string apiName = "GetTraceDataResult";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tracedataresultsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetTraceDataResultSqlDatabase : _sqlGetTraceDataResultOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TRACEDATARESULTSYSID", tracedataresultsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_TRACEDATARESULT", $"{tracedataresultsysid},{siteid}"));
		}
		Tracedataresult? result = ContextManager.DirectEntityQuery<Tracedataresult>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tracedataresultsysid},{siteid}");
		}
		return result;
	}

	public static Tracedataresult GetTraceDataResult4Update(IDbContext dbContext, long tracedataresultsysid, string siteid)
	{
		string apiName = "GetTraceDataResult4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tracedataresultsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetTraceDataResult4UpdateSqlDatabase : _sqlGetTraceDataResult4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TRACEDATARESULTSYSID", tracedataresultsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_TRACEDATARESULT", $"{tracedataresultsysid},{siteid}"));
		}
		Tracedataresult? result = ContextManager.DirectEntityQuery<Tracedataresult>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tracedataresultsysid},{siteid}");
		}
		return result;
	}

	public static Tracedataresult SelectTraceDataResult(IDbContext dbContext, long tracedataresultsysid, string siteid)
	{
		string apiName = "SelectTraceDataResult";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tracedataresultsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectTraceDataResultSqlDatabase : _sqlSelectTraceDataResultOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TRACEDATARESULTSYSID", tracedataresultsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_TRACEDATARESULT", $"{tracedataresultsysid},{siteid}"));
		}
		Tracedataresult? result = ContextManager.DirectEntityQuery<Tracedataresult>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tracedataresultsysid},{siteid}");
		}
		return result;
	}

	public static Tracedataresult SelectTraceDataResult4Update(IDbContext dbContext, long tracedataresultsysid, string siteid)
	{
		string apiName = "SelectTraceDataResult4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tracedataresultsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectTraceDataResult4UpdateSqlDatabase : _sqlSelectTraceDataResult4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TRACEDATARESULTSYSID", tracedataresultsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_TRACEDATARESULT", $"{tracedataresultsysid},{siteid}"));
		}
		Tracedataresult? result = ContextManager.DirectEntityQuery<Tracedataresult>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tracedataresultsysid},{siteid}");
		}
		return result;
	}

	public static int UpsertTraceDataResult(IDbContext dbContext, RequestType requestType, Tracedataresult[] traceDataResultList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateTraceDataResultInternal(dbContext, traceDataResultList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateTraceDataResult(dbContext, traceDataResultList, optionSet, saveHist), 
			RequestType.DELETE => DeleteTraceDataResult(dbContext, traceDataResultList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteTraceDataResult(dbContext, traceDataResultList, optionSet, saveHist), 
			_ => RealDeleteTraceDataResult(dbContext, traceDataResultList, optionSet, saveHist), 
		};
	}

	private static int CreateTraceDataResultInternal(IDbContext dbContext, Tracedataresult[] traceDataResultList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceDataResultList", traceDataResultList);
		string text = "CreateTraceDataResult";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tracedataresult> list = new List<Tracedataresult>();
		foreach (Tracedataresult obj in traceDataResultList)
		{
			Tracedataresult tracedataresult = new Tracedataresult();
			obj.CopyColumsTo(tracedataresult);
			tracedataresult.Activity = text;
			tracedataresult.CheckEntityUsable();
			obj.CopyCommonField(tracedataresult, systemTime, dbContext.Tid, isCreate: true);
			list.Add(tracedataresult);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateTraceDataResult(IDbContext dbContext, Tracedataresult[] traceDataResultList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceDataResultList", traceDataResultList);
		string text = "UpdateTraceDataResult";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tracedataresult> list = new List<Tracedataresult>();
		foreach (Tracedataresult tracedataresult in traceDataResultList)
		{
			Tracedataresult traceDataResult4Update = GetTraceDataResult4Update(dbContext, tracedataresult.Tracedataresultsysid, tracedataresult.Siteid);
			if (traceDataResult4Update == null)
			{
				throw new EntityNotFoundException(typeof(Tracedataresult), $"{tracedataresult.Tracedataresultsysid},{tracedataresult.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Tracedataresult), $"{tracedataresult.Tracedataresultsysid},{tracedataresult.Siteid}", traceDataResult4Update.Isusable);
			string activity = traceDataResult4Update.Activity;
			string customactivity = traceDataResult4Update.Customactivity;
			string isusable = traceDataResult4Update.Isusable;
			DateTime? createtime = traceDataResult4Update.Createtime;
			string creator = traceDataResult4Update.Creator;
			tracedataresult.CopyColumsTo(traceDataResult4Update);
			traceDataResult4Update.Prevactivity = activity;
			traceDataResult4Update.Prevcustomactivity = customactivity;
			traceDataResult4Update.Creator = creator;
			traceDataResult4Update.Createtime = createtime;
			traceDataResult4Update.Isusable = isusable;
			traceDataResult4Update.Activity = text;
			tracedataresult.CopyCommonField(traceDataResult4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(traceDataResult4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteTraceDataResult(IDbContext dbContext, Tracedataresult[] traceDataResultList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceDataResultList", traceDataResultList);
		string text = "DeleteTraceDataResult";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tracedataresult> list = new List<Tracedataresult>();
		foreach (Tracedataresult tracedataresult in traceDataResultList)
		{
			Tracedataresult traceDataResult4Update = GetTraceDataResult4Update(dbContext, tracedataresult.Tracedataresultsysid, tracedataresult.Siteid);
			if (traceDataResult4Update == null)
			{
				throw new EntityNotFoundException(typeof(Tracedataresult), $"{tracedataresult.Tracedataresultsysid},{tracedataresult.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Tracedataresult), $"{tracedataresult.Tracedataresultsysid},{tracedataresult.Siteid}", traceDataResult4Update.Isusable);
			traceDataResult4Update.Isusable = "UnUsable";
			tracedataresult.CopyCommonFieldUpdatePrev(traceDataResult4Update, systemTime, dbContext.Tid, text);
			tracedataresult.CopyExtensionCollection(traceDataResult4Update);
			list.Add(traceDataResult4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteTraceDataResult(IDbContext dbContext, Tracedataresult[] traceDataResultList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceDataResultList", traceDataResultList);
		string text = "UnDeleteTraceDataResult";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tracedataresult> list = new List<Tracedataresult>();
		foreach (Tracedataresult tracedataresult in traceDataResultList)
		{
			Tracedataresult traceDataResult4Update = GetTraceDataResult4Update(dbContext, tracedataresult.Tracedataresultsysid, tracedataresult.Siteid);
			if (traceDataResult4Update == null)
			{
				throw new EntityNotFoundException(typeof(Tracedataresult), $"{tracedataresult.Tracedataresultsysid},{tracedataresult.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Tracedataresult), $"{tracedataresult.Tracedataresultsysid},{tracedataresult.Siteid}", traceDataResult4Update.Isusable);
			traceDataResult4Update.Isusable = "Usable";
			tracedataresult.CopyCommonFieldUpdatePrev(traceDataResult4Update, systemTime, dbContext.Tid, text);
			tracedataresult.CopyExtensionCollection(traceDataResult4Update);
			list.Add(traceDataResult4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteTraceDataResult(IDbContext dbContext, Tracedataresult[] traceDataResultList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceDataResultList", traceDataResultList);
		string text = "RealDeleteTraceDataResult";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tracedataresult> list = new List<Tracedataresult>();
		foreach (Tracedataresult tracedataresult in traceDataResultList)
		{
			Tracedataresult traceDataResult4Update = GetTraceDataResult4Update(dbContext, tracedataresult.Tracedataresultsysid, tracedataresult.Siteid);
			if (traceDataResult4Update == null)
			{
				throw new EntityNotFoundException(typeof(Tracedataresult), $"{tracedataresult.Tracedataresultsysid},{tracedataresult.Siteid}");
			}
			tracedataresult.CopyCommonFieldUpdatePrev(traceDataResult4Update, systemTime, dbContext.Tid, text);
			tracedataresult.CopyExtensionCollection(traceDataResult4Update);
			list.Add(traceDataResult4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
