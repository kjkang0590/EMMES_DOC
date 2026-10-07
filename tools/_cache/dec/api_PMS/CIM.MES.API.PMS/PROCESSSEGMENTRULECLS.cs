using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.PMS;

[MESAPI]
public class PROCESSSEGMENTRULECLS
{
	private static string _sqlGetProcessSegmentRuleClsSqlDatabase = "SELECT * FROM CIM_PROCESSSEGMENTRULECLS WHERE PROCESSSEGMENTRULECLSID=@PROCESSSEGMENTRULECLSID AND SITEID=@SITEID";

	private static string _sqlGetProcessSegmentRuleCls4UpdateSqlDatabase = "SELECT * FROM CIM_PROCESSSEGMENTRULECLS WITH(UPDLOCK) WHERE PROCESSSEGMENTRULECLSID=@PROCESSSEGMENTRULECLSID AND SITEID=@SITEID";

	private static string _sqlSelectProcessSegmentRuleClsSqlDatabase = "SELECT * FROM CIM_PROCESSSEGMENTRULECLS WHERE PROCESSSEGMENTRULECLSID=@PROCESSSEGMENTRULECLSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessSegmentRuleCls4UpdateSqlDatabase = "SELECT * FROM CIM_PROCESSSEGMENTRULECLS WITH(UPDLOCK) WHERE PROCESSSEGMENTRULECLSID=@PROCESSSEGMENTRULECLSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetProcessSegmentRuleClsOracleDatabase = "SELECT * FROM CIM_PROCESSSEGMENTRULECLS WHERE PROCESSSEGMENTRULECLSID=:PROCESSSEGMENTRULECLSID AND SITEID=:SITEID";

	private static string _sqlGetProcessSegmentRuleCls4UpdateOracleDatabase = "SELECT * FROM CIM_PROCESSSEGMENTRULECLS WHERE PROCESSSEGMENTRULECLSID=:PROCESSSEGMENTRULECLSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectProcessSegmentRuleClsOracleDatabase = "SELECT * FROM CIM_PROCESSSEGMENTRULECLS WHERE PROCESSSEGMENTRULECLSID=:PROCESSSEGMENTRULECLSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessSegmentRuleCls4UpdateOracleDatabase = "SELECT * FROM CIM_PROCESSSEGMENTRULECLS WHERE PROCESSSEGMENTRULECLSID=:PROCESSSEGMENTRULECLSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Processsegmentrulecls);

	public static Processsegmentrulecls GetProcessSegmentRuleCls(IDbContext dbContext, string processsegmentruleclsid, string siteid)
	{
		string apiName = "GetProcessSegmentRuleCls";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processsegmentruleclsid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProcessSegmentRuleClsSqlDatabase : _sqlGetProcessSegmentRuleClsOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTRULECLSID", processsegmentruleclsid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PROCESSSEGMENTRULECLS", $"{processsegmentruleclsid},{siteid}"));
		}
		Processsegmentrulecls? result = ContextManager.DirectEntityQuery<Processsegmentrulecls>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processsegmentruleclsid},{siteid}");
		}
		return result;
	}

	public static Processsegmentrulecls GetProcessSegmentRuleCls4Update(IDbContext dbContext, string processsegmentruleclsid, string siteid)
	{
		string apiName = "GetProcessSegmentRuleCls4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processsegmentruleclsid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProcessSegmentRuleCls4UpdateSqlDatabase : _sqlGetProcessSegmentRuleCls4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTRULECLSID", processsegmentruleclsid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PROCESSSEGMENTRULECLS", $"{processsegmentruleclsid},{siteid}"));
		}
		Processsegmentrulecls? result = ContextManager.DirectEntityQuery<Processsegmentrulecls>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processsegmentruleclsid},{siteid}");
		}
		return result;
	}

	public static Processsegmentrulecls SelectProcessSegmentRuleCls(IDbContext dbContext, string processsegmentruleclsid, string siteid)
	{
		string apiName = "SelectProcessSegmentRuleCls";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processsegmentruleclsid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessSegmentRuleClsSqlDatabase : _sqlSelectProcessSegmentRuleClsOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTRULECLSID", processsegmentruleclsid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PROCESSSEGMENTRULECLS", $"{processsegmentruleclsid},{siteid}"));
		}
		Processsegmentrulecls? result = ContextManager.DirectEntityQuery<Processsegmentrulecls>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processsegmentruleclsid},{siteid}");
		}
		return result;
	}

	public static Processsegmentrulecls SelectProcessSegmentRuleCls4Update(IDbContext dbContext, string processsegmentruleclsid, string siteid)
	{
		string apiName = "SelectProcessSegmentRuleCls4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processsegmentruleclsid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessSegmentRuleCls4UpdateSqlDatabase : _sqlSelectProcessSegmentRuleCls4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTRULECLSID", processsegmentruleclsid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PROCESSSEGMENTRULECLS", $"{processsegmentruleclsid},{siteid}"));
		}
		Processsegmentrulecls? result = ContextManager.DirectEntityQuery<Processsegmentrulecls>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processsegmentruleclsid},{siteid}");
		}
		return result;
	}

	public static int UpsertProcessSegmentRuleCls(IDbContext dbContext, RequestType requestType, Processsegmentrulecls[] processSegmentRuleClsList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateProcessSegmentRuleClsInternal(dbContext, processSegmentRuleClsList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateProcessSegmentRuleCls(dbContext, processSegmentRuleClsList, optionSet, saveHist), 
			RequestType.DELETE => DeleteProcessSegmentRuleCls(dbContext, processSegmentRuleClsList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteProcessSegmentRuleCls(dbContext, processSegmentRuleClsList, optionSet, saveHist), 
			_ => RealDeleteProcessSegmentRuleCls(dbContext, processSegmentRuleClsList, optionSet, saveHist), 
		};
	}

	private static int CreateProcessSegmentRuleClsInternal(IDbContext dbContext, Processsegmentrulecls[] processSegmentRuleClsList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processSegmentRuleClsList", processSegmentRuleClsList);
		string text = "CreateProcessSegmentRuleCls";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processsegmentrulecls> list = new List<Processsegmentrulecls>();
		foreach (Processsegmentrulecls obj in processSegmentRuleClsList)
		{
			Processsegmentrulecls processsegmentrulecls = new Processsegmentrulecls();
			obj.CopyColumsTo(processsegmentrulecls);
			processsegmentrulecls.Activity = text;
			processsegmentrulecls.CheckEntityUsable();
			obj.CopyCommonField(processsegmentrulecls, systemTime, dbContext.Tid, isCreate: true);
			list.Add(processsegmentrulecls);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateProcessSegmentRuleCls(IDbContext dbContext, Processsegmentrulecls[] processSegmentRuleClsList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processSegmentRuleClsList", processSegmentRuleClsList);
		string text = "UpdateProcessSegmentRuleCls";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processsegmentrulecls> list = new List<Processsegmentrulecls>();
		foreach (Processsegmentrulecls processsegmentrulecls in processSegmentRuleClsList)
		{
			Processsegmentrulecls processSegmentRuleCls4Update = GetProcessSegmentRuleCls4Update(dbContext, processsegmentrulecls.Processsegmentruleclsid, processsegmentrulecls.Siteid);
			if (processSegmentRuleCls4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentrulecls), $"{processsegmentrulecls.Processsegmentruleclsid},{processsegmentrulecls.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Processsegmentrulecls), $"{processsegmentrulecls.Processsegmentruleclsid},{processsegmentrulecls.Siteid}", processSegmentRuleCls4Update.Isusable);
			string activity = processSegmentRuleCls4Update.Activity;
			string customactivity = processSegmentRuleCls4Update.Customactivity;
			string isusable = processSegmentRuleCls4Update.Isusable;
			DateTime? createtime = processSegmentRuleCls4Update.Createtime;
			string creator = processSegmentRuleCls4Update.Creator;
			processsegmentrulecls.CopyColumsTo(processSegmentRuleCls4Update);
			processSegmentRuleCls4Update.Prevactivity = activity;
			processSegmentRuleCls4Update.Prevcustomactivity = customactivity;
			processSegmentRuleCls4Update.Creator = creator;
			processSegmentRuleCls4Update.Createtime = createtime;
			processSegmentRuleCls4Update.Isusable = isusable;
			processSegmentRuleCls4Update.Activity = text;
			processsegmentrulecls.CopyCommonField(processSegmentRuleCls4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(processSegmentRuleCls4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteProcessSegmentRuleCls(IDbContext dbContext, Processsegmentrulecls[] processSegmentRuleClsList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processSegmentRuleClsList", processSegmentRuleClsList);
		string text = "DeleteProcessSegmentRuleCls";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processsegmentrulecls> list = new List<Processsegmentrulecls>();
		foreach (Processsegmentrulecls processsegmentrulecls in processSegmentRuleClsList)
		{
			Processsegmentrulecls processSegmentRuleCls4Update = GetProcessSegmentRuleCls4Update(dbContext, processsegmentrulecls.Processsegmentruleclsid, processsegmentrulecls.Siteid);
			if (processSegmentRuleCls4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentrulecls), $"{processsegmentrulecls.Processsegmentruleclsid},{processsegmentrulecls.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Processsegmentrulecls), $"{processsegmentrulecls.Processsegmentruleclsid},{processsegmentrulecls.Siteid}", processSegmentRuleCls4Update.Isusable);
			processSegmentRuleCls4Update.Isusable = "UnUsable";
			processsegmentrulecls.CopyCommonFieldUpdatePrev(processSegmentRuleCls4Update, systemTime, dbContext.Tid, text);
			processsegmentrulecls.CopyExtensionCollection(processSegmentRuleCls4Update);
			list.Add(processSegmentRuleCls4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteProcessSegmentRuleCls(IDbContext dbContext, Processsegmentrulecls[] processSegmentRuleClsList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processSegmentRuleClsList", processSegmentRuleClsList);
		string text = "UnDeleteProcessSegmentRuleCls";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processsegmentrulecls> list = new List<Processsegmentrulecls>();
		foreach (Processsegmentrulecls processsegmentrulecls in processSegmentRuleClsList)
		{
			Processsegmentrulecls processSegmentRuleCls4Update = GetProcessSegmentRuleCls4Update(dbContext, processsegmentrulecls.Processsegmentruleclsid, processsegmentrulecls.Siteid);
			if (processSegmentRuleCls4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentrulecls), $"{processsegmentrulecls.Processsegmentruleclsid},{processsegmentrulecls.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Processsegmentrulecls), $"{processsegmentrulecls.Processsegmentruleclsid},{processsegmentrulecls.Siteid}", processSegmentRuleCls4Update.Isusable);
			processSegmentRuleCls4Update.Isusable = "Usable";
			processsegmentrulecls.CopyCommonFieldUpdatePrev(processSegmentRuleCls4Update, systemTime, dbContext.Tid, text);
			processsegmentrulecls.CopyExtensionCollection(processSegmentRuleCls4Update);
			list.Add(processSegmentRuleCls4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteProcessSegmentRuleCls(IDbContext dbContext, Processsegmentrulecls[] processSegmentRuleClsList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processSegmentRuleClsList", processSegmentRuleClsList);
		string text = "RealDeleteProcessSegmentRuleCls";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processsegmentrulecls> list = new List<Processsegmentrulecls>();
		foreach (Processsegmentrulecls processsegmentrulecls in processSegmentRuleClsList)
		{
			Processsegmentrulecls processSegmentRuleCls4Update = GetProcessSegmentRuleCls4Update(dbContext, processsegmentrulecls.Processsegmentruleclsid, processsegmentrulecls.Siteid);
			if (processSegmentRuleCls4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentrulecls), $"{processsegmentrulecls.Processsegmentruleclsid},{processsegmentrulecls.Siteid}");
			}
			processsegmentrulecls.CopyCommonFieldUpdatePrev(processSegmentRuleCls4Update, systemTime, dbContext.Tid, text);
			processsegmentrulecls.CopyExtensionCollection(processSegmentRuleCls4Update);
			list.Add(processSegmentRuleCls4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
