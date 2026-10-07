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
public class INSPDEFINITIONRULE
{
	private static string _sqlGetInspDefinitionRuleSqlDatabase = "SELECT * FROM CIM_INSPDEFINITIONRULE WHERE INSPDEFINITIONRULEID=@INSPDEFINITIONRULEID AND SITEID=@SITEID";

	private static string _sqlGetInspDefinitionRule4UpdateSqlDatabase = "SELECT * FROM CIM_INSPDEFINITIONRULE WITH(UPDLOCK) WHERE INSPDEFINITIONRULEID=@INSPDEFINITIONRULEID AND SITEID=@SITEID";

	private static string _sqlSelectInspDefinitionRuleSqlDatabase = "SELECT * FROM CIM_INSPDEFINITIONRULE WHERE INSPDEFINITIONRULEID=@INSPDEFINITIONRULEID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectInspDefinitionRule4UpdateSqlDatabase = "SELECT * FROM CIM_INSPDEFINITIONRULE WITH(UPDLOCK) WHERE INSPDEFINITIONRULEID=@INSPDEFINITIONRULEID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetInspDefinitionRuleOracleDatabase = "SELECT * FROM CIM_INSPDEFINITIONRULE WHERE INSPDEFINITIONRULEID=:INSPDEFINITIONRULEID AND SITEID=:SITEID";

	private static string _sqlGetInspDefinitionRule4UpdateOracleDatabase = "SELECT * FROM CIM_INSPDEFINITIONRULE WHERE INSPDEFINITIONRULEID=:INSPDEFINITIONRULEID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectInspDefinitionRuleOracleDatabase = "SELECT * FROM CIM_INSPDEFINITIONRULE WHERE INSPDEFINITIONRULEID=:INSPDEFINITIONRULEID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectInspDefinitionRule4UpdateOracleDatabase = "SELECT * FROM CIM_INSPDEFINITIONRULE WHERE INSPDEFINITIONRULEID=:INSPDEFINITIONRULEID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Inspdefinitionrule);

	public static Inspdefinitionrule GetInspDefinitionRule(IDbContext dbContext, string inspdefinitionruleid, string siteid)
	{
		string apiName = "GetInspDefinitionRule";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspdefinitionruleid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetInspDefinitionRuleSqlDatabase : _sqlGetInspDefinitionRuleOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPDEFINITIONRULEID", inspdefinitionruleid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_INSPDEFINITIONRULE", $"{inspdefinitionruleid},{siteid}"));
		}
		Inspdefinitionrule? result = ContextManager.DirectEntityQuery<Inspdefinitionrule>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspdefinitionruleid},{siteid}");
		}
		return result;
	}

	public static Inspdefinitionrule GetInspDefinitionRule4Update(IDbContext dbContext, string inspdefinitionruleid, string siteid)
	{
		string apiName = "GetInspDefinitionRule4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspdefinitionruleid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetInspDefinitionRule4UpdateSqlDatabase : _sqlGetInspDefinitionRule4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPDEFINITIONRULEID", inspdefinitionruleid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_INSPDEFINITIONRULE", $"{inspdefinitionruleid},{siteid}"));
		}
		Inspdefinitionrule? result = ContextManager.DirectEntityQuery<Inspdefinitionrule>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspdefinitionruleid},{siteid}");
		}
		return result;
	}

	public static Inspdefinitionrule SelectInspDefinitionRule(IDbContext dbContext, string inspdefinitionruleid, string siteid)
	{
		string apiName = "SelectInspDefinitionRule";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspdefinitionruleid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectInspDefinitionRuleSqlDatabase : _sqlSelectInspDefinitionRuleOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPDEFINITIONRULEID", inspdefinitionruleid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_INSPDEFINITIONRULE", $"{inspdefinitionruleid},{siteid}"));
		}
		Inspdefinitionrule? result = ContextManager.DirectEntityQuery<Inspdefinitionrule>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspdefinitionruleid},{siteid}");
		}
		return result;
	}

	public static Inspdefinitionrule SelectInspDefinitionRule4Update(IDbContext dbContext, string inspdefinitionruleid, string siteid)
	{
		string apiName = "SelectInspDefinitionRule4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspdefinitionruleid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectInspDefinitionRule4UpdateSqlDatabase : _sqlSelectInspDefinitionRule4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPDEFINITIONRULEID", inspdefinitionruleid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_INSPDEFINITIONRULE", $"{inspdefinitionruleid},{siteid}"));
		}
		Inspdefinitionrule? result = ContextManager.DirectEntityQuery<Inspdefinitionrule>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspdefinitionruleid},{siteid}");
		}
		return result;
	}

	public static int UpsertInspDefinitionRule(IDbContext dbContext, RequestType requestType, Inspdefinitionrule[] inspDefinitionRuleList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateInspDefinitionRuleInternal(dbContext, inspDefinitionRuleList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateInspDefinitionRule(dbContext, inspDefinitionRuleList, optionSet, saveHist), 
			RequestType.DELETE => DeleteInspDefinitionRule(dbContext, inspDefinitionRuleList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteInspDefinitionRule(dbContext, inspDefinitionRuleList, optionSet, saveHist), 
			_ => RealDeleteInspDefinitionRule(dbContext, inspDefinitionRuleList, optionSet, saveHist), 
		};
	}

	private static int CreateInspDefinitionRuleInternal(IDbContext dbContext, Inspdefinitionrule[] inspDefinitionRuleList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspDefinitionRuleList", inspDefinitionRuleList);
		string text = "CreateInspDefinitionRule";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspdefinitionrule> list = new List<Inspdefinitionrule>();
		foreach (Inspdefinitionrule obj in inspDefinitionRuleList)
		{
			Inspdefinitionrule inspdefinitionrule = new Inspdefinitionrule();
			obj.CopyColumsTo(inspdefinitionrule);
			inspdefinitionrule.Activity = text;
			inspdefinitionrule.CheckEntityUsable();
			obj.CopyCommonField(inspdefinitionrule, systemTime, dbContext.Tid, isCreate: true);
			list.Add(inspdefinitionrule);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateInspDefinitionRule(IDbContext dbContext, Inspdefinitionrule[] inspDefinitionRuleList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspDefinitionRuleList", inspDefinitionRuleList);
		string text = "UpdateInspDefinitionRule";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspdefinitionrule> list = new List<Inspdefinitionrule>();
		foreach (Inspdefinitionrule inspdefinitionrule in inspDefinitionRuleList)
		{
			Inspdefinitionrule inspDefinitionRule4Update = GetInspDefinitionRule4Update(dbContext, inspdefinitionrule.Inspdefinitionruleid, inspdefinitionrule.Siteid);
			if (inspDefinitionRule4Update == null)
			{
				throw new EntityNotFoundException(typeof(Inspdefinitionrule), $"{inspdefinitionrule.Inspdefinitionruleid},{inspdefinitionrule.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Inspdefinitionrule), $"{inspdefinitionrule.Inspdefinitionruleid},{inspdefinitionrule.Siteid}", inspDefinitionRule4Update.Isusable);
			string activity = inspDefinitionRule4Update.Activity;
			string customactivity = inspDefinitionRule4Update.Customactivity;
			string isusable = inspDefinitionRule4Update.Isusable;
			DateTime? createtime = inspDefinitionRule4Update.Createtime;
			string creator = inspDefinitionRule4Update.Creator;
			inspdefinitionrule.CopyColumsTo(inspDefinitionRule4Update);
			inspDefinitionRule4Update.Prevactivity = activity;
			inspDefinitionRule4Update.Prevcustomactivity = customactivity;
			inspDefinitionRule4Update.Creator = creator;
			inspDefinitionRule4Update.Createtime = createtime;
			inspDefinitionRule4Update.Isusable = isusable;
			inspDefinitionRule4Update.Activity = text;
			inspdefinitionrule.CopyCommonField(inspDefinitionRule4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(inspDefinitionRule4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteInspDefinitionRule(IDbContext dbContext, Inspdefinitionrule[] inspDefinitionRuleList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspDefinitionRuleList", inspDefinitionRuleList);
		string text = "DeleteInspDefinitionRule";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspdefinitionrule> list = new List<Inspdefinitionrule>();
		foreach (Inspdefinitionrule inspdefinitionrule in inspDefinitionRuleList)
		{
			Inspdefinitionrule inspDefinitionRule4Update = GetInspDefinitionRule4Update(dbContext, inspdefinitionrule.Inspdefinitionruleid, inspdefinitionrule.Siteid);
			if (inspDefinitionRule4Update == null)
			{
				throw new EntityNotFoundException(typeof(Inspdefinitionrule), $"{inspdefinitionrule.Inspdefinitionruleid},{inspdefinitionrule.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Inspdefinitionrule), $"{inspdefinitionrule.Inspdefinitionruleid},{inspdefinitionrule.Siteid}", inspDefinitionRule4Update.Isusable);
			inspDefinitionRule4Update.Isusable = "UnUsable";
			inspdefinitionrule.CopyCommonFieldUpdatePrev(inspDefinitionRule4Update, systemTime, dbContext.Tid, text);
			inspdefinitionrule.CopyExtensionCollection(inspDefinitionRule4Update);
			list.Add(inspDefinitionRule4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteInspDefinitionRule(IDbContext dbContext, Inspdefinitionrule[] inspDefinitionRuleList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspDefinitionRuleList", inspDefinitionRuleList);
		string text = "UnDeleteInspDefinitionRule";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspdefinitionrule> list = new List<Inspdefinitionrule>();
		foreach (Inspdefinitionrule inspdefinitionrule in inspDefinitionRuleList)
		{
			Inspdefinitionrule inspDefinitionRule4Update = GetInspDefinitionRule4Update(dbContext, inspdefinitionrule.Inspdefinitionruleid, inspdefinitionrule.Siteid);
			if (inspDefinitionRule4Update == null)
			{
				throw new EntityNotFoundException(typeof(Inspdefinitionrule), $"{inspdefinitionrule.Inspdefinitionruleid},{inspdefinitionrule.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Inspdefinitionrule), $"{inspdefinitionrule.Inspdefinitionruleid},{inspdefinitionrule.Siteid}", inspDefinitionRule4Update.Isusable);
			inspDefinitionRule4Update.Isusable = "Usable";
			inspdefinitionrule.CopyCommonFieldUpdatePrev(inspDefinitionRule4Update, systemTime, dbContext.Tid, text);
			inspdefinitionrule.CopyExtensionCollection(inspDefinitionRule4Update);
			list.Add(inspDefinitionRule4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteInspDefinitionRule(IDbContext dbContext, Inspdefinitionrule[] inspDefinitionRuleList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspDefinitionRuleList", inspDefinitionRuleList);
		string text = "RealDeleteInspDefinitionRule";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspdefinitionrule> list = new List<Inspdefinitionrule>();
		foreach (Inspdefinitionrule inspdefinitionrule in inspDefinitionRuleList)
		{
			Inspdefinitionrule inspDefinitionRule4Update = GetInspDefinitionRule4Update(dbContext, inspdefinitionrule.Inspdefinitionruleid, inspdefinitionrule.Siteid);
			if (inspDefinitionRule4Update == null)
			{
				throw new EntityNotFoundException(typeof(Inspdefinitionrule), $"{inspdefinitionrule.Inspdefinitionruleid},{inspdefinitionrule.Siteid}");
			}
			inspdefinitionrule.CopyCommonFieldUpdatePrev(inspDefinitionRule4Update, systemTime, dbContext.Tid, text);
			inspdefinitionrule.CopyExtensionCollection(inspDefinitionRule4Update);
			list.Add(inspDefinitionRule4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
