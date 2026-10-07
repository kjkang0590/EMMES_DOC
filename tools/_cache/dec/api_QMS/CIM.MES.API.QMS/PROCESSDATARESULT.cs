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
public class PROCESSDATARESULT
{
	private static string _sqlGetProcessDataResultSqlDatabase = "SELECT * FROM CIM_PROCESSDATARESULT WHERE PROCESSDATARESULTSYSID=@PROCESSDATARESULTSYSID AND SITEID=@SITEID";

	private static string _sqlGetProcessDataResult4UpdateSqlDatabase = "SELECT * FROM CIM_PROCESSDATARESULT WITH(UPDLOCK) WHERE PROCESSDATARESULTSYSID=@PROCESSDATARESULTSYSID AND SITEID=@SITEID";

	private static string _sqlSelectProcessDataResultSqlDatabase = "SELECT * FROM CIM_PROCESSDATARESULT WHERE PROCESSDATARESULTSYSID=@PROCESSDATARESULTSYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessDataResult4UpdateSqlDatabase = "SELECT * FROM CIM_PROCESSDATARESULT WITH(UPDLOCK) WHERE PROCESSDATARESULTSYSID=@PROCESSDATARESULTSYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetProcessDataResultOracleDatabase = "SELECT * FROM CIM_PROCESSDATARESULT WHERE PROCESSDATARESULTSYSID=:PROCESSDATARESULTSYSID AND SITEID=:SITEID";

	private static string _sqlGetProcessDataResult4UpdateOracleDatabase = "SELECT * FROM CIM_PROCESSDATARESULT WHERE PROCESSDATARESULTSYSID=:PROCESSDATARESULTSYSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectProcessDataResultOracleDatabase = "SELECT * FROM CIM_PROCESSDATARESULT WHERE PROCESSDATARESULTSYSID=:PROCESSDATARESULTSYSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessDataResult4UpdateOracleDatabase = "SELECT * FROM CIM_PROCESSDATARESULT WHERE PROCESSDATARESULTSYSID=:PROCESSDATARESULTSYSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Processdataresult);

	public static Processdataresult GetProcessDataResult(IDbContext dbContext, long processdataresultsysid, string siteid)
	{
		string apiName = "GetProcessDataResult";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processdataresultsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProcessDataResultSqlDatabase : _sqlGetProcessDataResultOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSDATARESULTSYSID", processdataresultsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PROCESSDATARESULT", $"{processdataresultsysid},{siteid}"));
		}
		Processdataresult? result = ContextManager.DirectEntityQuery<Processdataresult>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processdataresultsysid},{siteid}");
		}
		return result;
	}

	public static Processdataresult GetProcessDataResult4Update(IDbContext dbContext, long processdataresultsysid, string siteid)
	{
		string apiName = "GetProcessDataResult4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processdataresultsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProcessDataResult4UpdateSqlDatabase : _sqlGetProcessDataResult4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSDATARESULTSYSID", processdataresultsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PROCESSDATARESULT", $"{processdataresultsysid},{siteid}"));
		}
		Processdataresult? result = ContextManager.DirectEntityQuery<Processdataresult>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processdataresultsysid},{siteid}");
		}
		return result;
	}

	public static Processdataresult SelectProcessDataResult(IDbContext dbContext, long processdataresultsysid, string siteid)
	{
		string apiName = "SelectProcessDataResult";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processdataresultsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessDataResultSqlDatabase : _sqlSelectProcessDataResultOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSDATARESULTSYSID", processdataresultsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PROCESSDATARESULT", $"{processdataresultsysid},{siteid}"));
		}
		Processdataresult? result = ContextManager.DirectEntityQuery<Processdataresult>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processdataresultsysid},{siteid}");
		}
		return result;
	}

	public static Processdataresult SelectProcessDataResult4Update(IDbContext dbContext, long processdataresultsysid, string siteid)
	{
		string apiName = "SelectProcessDataResult4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processdataresultsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessDataResult4UpdateSqlDatabase : _sqlSelectProcessDataResult4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSDATARESULTSYSID", processdataresultsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PROCESSDATARESULT", $"{processdataresultsysid},{siteid}"));
		}
		Processdataresult? result = ContextManager.DirectEntityQuery<Processdataresult>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processdataresultsysid},{siteid}");
		}
		return result;
	}

	public static int UpsertProcessDataResult(IDbContext dbContext, RequestType requestType, Processdataresult[] processDataResultList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateProcessDataResultInternal(dbContext, processDataResultList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateProcessDataResult(dbContext, processDataResultList, optionSet, saveHist), 
			RequestType.DELETE => DeleteProcessDataResult(dbContext, processDataResultList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteProcessDataResult(dbContext, processDataResultList, optionSet, saveHist), 
			_ => RealDeleteProcessDataResult(dbContext, processDataResultList, optionSet, saveHist), 
		};
	}

	private static int CreateProcessDataResultInternal(IDbContext dbContext, Processdataresult[] processDataResultList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processDataResultList", processDataResultList);
		string text = "CreateProcessDataResult";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processdataresult> list = new List<Processdataresult>();
		foreach (Processdataresult obj in processDataResultList)
		{
			Processdataresult processdataresult = new Processdataresult();
			obj.CopyColumsTo(processdataresult);
			processdataresult.Activity = text;
			processdataresult.CheckEntityUsable();
			obj.CopyCommonField(processdataresult, systemTime, dbContext.Tid, isCreate: true);
			list.Add(processdataresult);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateProcessDataResult(IDbContext dbContext, Processdataresult[] processDataResultList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processDataResultList", processDataResultList);
		string text = "UpdateProcessDataResult";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processdataresult> list = new List<Processdataresult>();
		foreach (Processdataresult processdataresult in processDataResultList)
		{
			Processdataresult processDataResult4Update = GetProcessDataResult4Update(dbContext, processdataresult.Processdataresultsysid, processdataresult.Siteid);
			if (processDataResult4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processdataresult), $"{processdataresult.Processdataresultsysid},{processdataresult.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Processdataresult), $"{processdataresult.Processdataresultsysid},{processdataresult.Siteid}", processDataResult4Update.Isusable);
			string activity = processDataResult4Update.Activity;
			string customactivity = processDataResult4Update.Customactivity;
			string isusable = processDataResult4Update.Isusable;
			DateTime? createtime = processDataResult4Update.Createtime;
			string creator = processDataResult4Update.Creator;
			processdataresult.CopyColumsTo(processDataResult4Update);
			processDataResult4Update.Prevactivity = activity;
			processDataResult4Update.Prevcustomactivity = customactivity;
			processDataResult4Update.Creator = creator;
			processDataResult4Update.Createtime = createtime;
			processDataResult4Update.Isusable = isusable;
			processDataResult4Update.Activity = text;
			processdataresult.CopyCommonField(processDataResult4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(processDataResult4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteProcessDataResult(IDbContext dbContext, Processdataresult[] processDataResultList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processDataResultList", processDataResultList);
		string text = "DeleteProcessDataResult";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processdataresult> list = new List<Processdataresult>();
		foreach (Processdataresult processdataresult in processDataResultList)
		{
			Processdataresult processDataResult4Update = GetProcessDataResult4Update(dbContext, processdataresult.Processdataresultsysid, processdataresult.Siteid);
			if (processDataResult4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processdataresult), $"{processdataresult.Processdataresultsysid},{processdataresult.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Processdataresult), $"{processdataresult.Processdataresultsysid},{processdataresult.Siteid}", processDataResult4Update.Isusable);
			processDataResult4Update.Isusable = "UnUsable";
			processdataresult.CopyCommonFieldUpdatePrev(processDataResult4Update, systemTime, dbContext.Tid, text);
			processdataresult.CopyExtensionCollection(processDataResult4Update);
			list.Add(processDataResult4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteProcessDataResult(IDbContext dbContext, Processdataresult[] processDataResultList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processDataResultList", processDataResultList);
		string text = "UnDeleteProcessDataResult";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processdataresult> list = new List<Processdataresult>();
		foreach (Processdataresult processdataresult in processDataResultList)
		{
			Processdataresult processDataResult4Update = GetProcessDataResult4Update(dbContext, processdataresult.Processdataresultsysid, processdataresult.Siteid);
			if (processDataResult4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processdataresult), $"{processdataresult.Processdataresultsysid},{processdataresult.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Processdataresult), $"{processdataresult.Processdataresultsysid},{processdataresult.Siteid}", processDataResult4Update.Isusable);
			processDataResult4Update.Isusable = "Usable";
			processdataresult.CopyCommonFieldUpdatePrev(processDataResult4Update, systemTime, dbContext.Tid, text);
			processdataresult.CopyExtensionCollection(processDataResult4Update);
			list.Add(processDataResult4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteProcessDataResult(IDbContext dbContext, Processdataresult[] processDataResultList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processDataResultList", processDataResultList);
		string text = "RealDeleteProcessDataResult";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processdataresult> list = new List<Processdataresult>();
		foreach (Processdataresult processdataresult in processDataResultList)
		{
			Processdataresult processDataResult4Update = GetProcessDataResult4Update(dbContext, processdataresult.Processdataresultsysid, processdataresult.Siteid);
			if (processDataResult4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processdataresult), $"{processdataresult.Processdataresultsysid},{processdataresult.Siteid}");
			}
			processdataresult.CopyCommonFieldUpdatePrev(processDataResult4Update, systemTime, dbContext.Tid, text);
			processdataresult.CopyExtensionCollection(processDataResult4Update);
			list.Add(processDataResult4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
