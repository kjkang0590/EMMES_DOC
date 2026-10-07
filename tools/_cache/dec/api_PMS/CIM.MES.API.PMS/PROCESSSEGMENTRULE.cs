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
public class PROCESSSEGMENTRULE
{
	private static string _sqlGetProcessSegmentRuleSqlDatabase = "SELECT * FROM CIM_PROCESSSEGMENTRULE WHERE PROCESSSEGMENTRULEID=@PROCESSSEGMENTRULEID AND SITEID=@SITEID";

	private static string _sqlGetProcessSegmentRule4UpdateSqlDatabase = "SELECT * FROM CIM_PROCESSSEGMENTRULE WITH(UPDLOCK) WHERE PROCESSSEGMENTRULEID=@PROCESSSEGMENTRULEID AND SITEID=@SITEID";

	private static string _sqlSelectProcessSegmentRuleSqlDatabase = "SELECT * FROM CIM_PROCESSSEGMENTRULE WHERE PROCESSSEGMENTRULEID=@PROCESSSEGMENTRULEID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessSegmentRule4UpdateSqlDatabase = "SELECT * FROM CIM_PROCESSSEGMENTRULE WITH(UPDLOCK) WHERE PROCESSSEGMENTRULEID=@PROCESSSEGMENTRULEID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetProcessSegmentRuleOracleDatabase = "SELECT * FROM CIM_PROCESSSEGMENTRULE WHERE PROCESSSEGMENTRULEID=:PROCESSSEGMENTRULEID AND SITEID=:SITEID";

	private static string _sqlGetProcessSegmentRule4UpdateOracleDatabase = "SELECT * FROM CIM_PROCESSSEGMENTRULE WHERE PROCESSSEGMENTRULEID=:PROCESSSEGMENTRULEID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectProcessSegmentRuleOracleDatabase = "SELECT * FROM CIM_PROCESSSEGMENTRULE WHERE PROCESSSEGMENTRULEID=:PROCESSSEGMENTRULEID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessSegmentRule4UpdateOracleDatabase = "SELECT * FROM CIM_PROCESSSEGMENTRULE WHERE PROCESSSEGMENTRULEID=:PROCESSSEGMENTRULEID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Processsegmentrule);

	public static Processsegmentrule GetProcessSegmentRule(IDbContext dbContext, string processsegmentruleid, string siteid)
	{
		string apiName = "GetProcessSegmentRule";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processsegmentruleid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProcessSegmentRuleSqlDatabase : _sqlGetProcessSegmentRuleOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTRULEID", processsegmentruleid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PROCESSSEGMENTRULE", $"{processsegmentruleid},{siteid}"));
		}
		Processsegmentrule? result = ContextManager.DirectEntityQuery<Processsegmentrule>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processsegmentruleid},{siteid}");
		}
		return result;
	}

	public static Processsegmentrule GetProcessSegmentRule4Update(IDbContext dbContext, string processsegmentruleid, string siteid)
	{
		string apiName = "GetProcessSegmentRule4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processsegmentruleid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProcessSegmentRule4UpdateSqlDatabase : _sqlGetProcessSegmentRule4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTRULEID", processsegmentruleid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PROCESSSEGMENTRULE", $"{processsegmentruleid},{siteid}"));
		}
		Processsegmentrule? result = ContextManager.DirectEntityQuery<Processsegmentrule>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processsegmentruleid},{siteid}");
		}
		return result;
	}

	public static Processsegmentrule SelectProcessSegmentRule(IDbContext dbContext, string processsegmentruleid, string siteid)
	{
		string apiName = "SelectProcessSegmentRule";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processsegmentruleid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessSegmentRuleSqlDatabase : _sqlSelectProcessSegmentRuleOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTRULEID", processsegmentruleid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PROCESSSEGMENTRULE", $"{processsegmentruleid},{siteid}"));
		}
		Processsegmentrule? result = ContextManager.DirectEntityQuery<Processsegmentrule>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processsegmentruleid},{siteid}");
		}
		return result;
	}

	public static Processsegmentrule SelectProcessSegmentRule4Update(IDbContext dbContext, string processsegmentruleid, string siteid)
	{
		string apiName = "SelectProcessSegmentRule4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processsegmentruleid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessSegmentRule4UpdateSqlDatabase : _sqlSelectProcessSegmentRule4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTRULEID", processsegmentruleid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PROCESSSEGMENTRULE", $"{processsegmentruleid},{siteid}"));
		}
		Processsegmentrule? result = ContextManager.DirectEntityQuery<Processsegmentrule>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processsegmentruleid},{siteid}");
		}
		return result;
	}

	public static int UpsertProcessSegmentRule(IDbContext dbContext, RequestType requestType, Processsegmentrule[] processSegmentRuleList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateProcessSegmentRuleInternal(dbContext, processSegmentRuleList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateProcessSegmentRule(dbContext, processSegmentRuleList, optionSet, saveHist), 
			RequestType.DELETE => DeleteProcessSegmentRule(dbContext, processSegmentRuleList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteProcessSegmentRule(dbContext, processSegmentRuleList, optionSet, saveHist), 
			_ => RealDeleteProcessSegmentRule(dbContext, processSegmentRuleList, optionSet, saveHist), 
		};
	}

	private static int CreateProcessSegmentRuleInternal(IDbContext dbContext, Processsegmentrule[] processSegmentRuleList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processSegmentRuleList", processSegmentRuleList);
		string text = "CreateProcessSegmentRule";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processsegmentrule> list = new List<Processsegmentrule>();
		foreach (Processsegmentrule obj in processSegmentRuleList)
		{
			Processsegmentrule processsegmentrule = new Processsegmentrule();
			obj.CopyColumsTo(processsegmentrule);
			processsegmentrule.Activity = text;
			processsegmentrule.CheckEntityUsable();
			obj.CopyCommonField(processsegmentrule, systemTime, dbContext.Tid, isCreate: true);
			list.Add(processsegmentrule);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateProcessSegmentRule(IDbContext dbContext, Processsegmentrule[] processSegmentRuleList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processSegmentRuleList", processSegmentRuleList);
		string text = "UpdateProcessSegmentRule";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processsegmentrule> list = new List<Processsegmentrule>();
		foreach (Processsegmentrule processsegmentrule in processSegmentRuleList)
		{
			Processsegmentrule processSegmentRule4Update = GetProcessSegmentRule4Update(dbContext, processsegmentrule.Processsegmentruleid, processsegmentrule.Siteid);
			if (processSegmentRule4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentrule), $"{processsegmentrule.Processsegmentruleid},{processsegmentrule.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Processsegmentrule), $"{processsegmentrule.Processsegmentruleid},{processsegmentrule.Siteid}", processSegmentRule4Update.Isusable);
			string activity = processSegmentRule4Update.Activity;
			string customactivity = processSegmentRule4Update.Customactivity;
			string isusable = processSegmentRule4Update.Isusable;
			DateTime? createtime = processSegmentRule4Update.Createtime;
			string creator = processSegmentRule4Update.Creator;
			processsegmentrule.CopyColumsTo(processSegmentRule4Update);
			processSegmentRule4Update.Prevactivity = activity;
			processSegmentRule4Update.Prevcustomactivity = customactivity;
			processSegmentRule4Update.Creator = creator;
			processSegmentRule4Update.Createtime = createtime;
			processSegmentRule4Update.Isusable = isusable;
			processSegmentRule4Update.Activity = text;
			processsegmentrule.CopyCommonField(processSegmentRule4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(processSegmentRule4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteProcessSegmentRule(IDbContext dbContext, Processsegmentrule[] processSegmentRuleList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processSegmentRuleList", processSegmentRuleList);
		string text = "DeleteProcessSegmentRule";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processsegmentrule> list = new List<Processsegmentrule>();
		foreach (Processsegmentrule processsegmentrule in processSegmentRuleList)
		{
			Processsegmentrule processSegmentRule4Update = GetProcessSegmentRule4Update(dbContext, processsegmentrule.Processsegmentruleid, processsegmentrule.Siteid);
			if (processSegmentRule4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentrule), $"{processsegmentrule.Processsegmentruleid},{processsegmentrule.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Processsegmentrule), $"{processsegmentrule.Processsegmentruleid},{processsegmentrule.Siteid}", processSegmentRule4Update.Isusable);
			processSegmentRule4Update.Isusable = "UnUsable";
			processsegmentrule.CopyCommonFieldUpdatePrev(processSegmentRule4Update, systemTime, dbContext.Tid, text);
			processsegmentrule.CopyExtensionCollection(processSegmentRule4Update);
			list.Add(processSegmentRule4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteProcessSegmentRule(IDbContext dbContext, Processsegmentrule[] processSegmentRuleList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processSegmentRuleList", processSegmentRuleList);
		string text = "UnDeleteProcessSegmentRule";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processsegmentrule> list = new List<Processsegmentrule>();
		foreach (Processsegmentrule processsegmentrule in processSegmentRuleList)
		{
			Processsegmentrule processSegmentRule4Update = GetProcessSegmentRule4Update(dbContext, processsegmentrule.Processsegmentruleid, processsegmentrule.Siteid);
			if (processSegmentRule4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentrule), $"{processsegmentrule.Processsegmentruleid},{processsegmentrule.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Processsegmentrule), $"{processsegmentrule.Processsegmentruleid},{processsegmentrule.Siteid}", processSegmentRule4Update.Isusable);
			processSegmentRule4Update.Isusable = "Usable";
			processsegmentrule.CopyCommonFieldUpdatePrev(processSegmentRule4Update, systemTime, dbContext.Tid, text);
			processsegmentrule.CopyExtensionCollection(processSegmentRule4Update);
			list.Add(processSegmentRule4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteProcessSegmentRule(IDbContext dbContext, Processsegmentrule[] processSegmentRuleList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processSegmentRuleList", processSegmentRuleList);
		string text = "RealDeleteProcessSegmentRule";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processsegmentrule> list = new List<Processsegmentrule>();
		foreach (Processsegmentrule processsegmentrule in processSegmentRuleList)
		{
			Processsegmentrule processSegmentRule4Update = GetProcessSegmentRule4Update(dbContext, processsegmentrule.Processsegmentruleid, processsegmentrule.Siteid);
			if (processSegmentRule4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentrule), $"{processsegmentrule.Processsegmentruleid},{processsegmentrule.Siteid}");
			}
			processsegmentrule.CopyCommonFieldUpdatePrev(processSegmentRule4Update, systemTime, dbContext.Tid, text);
			processsegmentrule.CopyExtensionCollection(processSegmentRule4Update);
			list.Add(processSegmentRule4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
