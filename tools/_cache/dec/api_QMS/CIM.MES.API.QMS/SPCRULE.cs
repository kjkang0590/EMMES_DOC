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
public class SPCRULE
{
	private static string _sqlGetSpcRuleSqlDatabase = "SELECT * FROM CIM_SPCRULE WHERE SPCRULESYSID=@SPCRULESYSID AND SITEID=@SITEID";

	private static string _sqlGetSpcRule4UpdateSqlDatabase = "SELECT * FROM CIM_SPCRULE WITH(UPDLOCK) WHERE SPCRULESYSID=@SPCRULESYSID AND SITEID=@SITEID";

	private static string _sqlSelectSpcRuleSqlDatabase = "SELECT * FROM CIM_SPCRULE WHERE SPCRULESYSID=@SPCRULESYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectSpcRule4UpdateSqlDatabase = "SELECT * FROM CIM_SPCRULE WITH(UPDLOCK) WHERE SPCRULESYSID=@SPCRULESYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetSpcRuleOracleDatabase = "SELECT * FROM CIM_SPCRULE WHERE SPCRULESYSID=:SPCRULESYSID AND SITEID=:SITEID";

	private static string _sqlGetSpcRule4UpdateOracleDatabase = "SELECT * FROM CIM_SPCRULE WHERE SPCRULESYSID=:SPCRULESYSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectSpcRuleOracleDatabase = "SELECT * FROM CIM_SPCRULE WHERE SPCRULESYSID=:SPCRULESYSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectSpcRule4UpdateOracleDatabase = "SELECT * FROM CIM_SPCRULE WHERE SPCRULESYSID=:SPCRULESYSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Spcrule);

	public static Spcrule GetSpcRule(IDbContext dbContext, long spcrulesysid, string siteid)
	{
		string apiName = "GetSpcRule";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{spcrulesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetSpcRuleSqlDatabase : _sqlGetSpcRuleOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SPCRULESYSID", spcrulesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SPCRULE", $"{spcrulesysid},{siteid}"));
		}
		Spcrule? result = ContextManager.DirectEntityQuery<Spcrule>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{spcrulesysid},{siteid}");
		}
		return result;
	}

	public static Spcrule GetSpcRule4Update(IDbContext dbContext, long spcrulesysid, string siteid)
	{
		string apiName = "GetSpcRule4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{spcrulesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetSpcRule4UpdateSqlDatabase : _sqlGetSpcRule4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SPCRULESYSID", spcrulesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_SPCRULE", $"{spcrulesysid},{siteid}"));
		}
		Spcrule? result = ContextManager.DirectEntityQuery<Spcrule>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{spcrulesysid},{siteid}");
		}
		return result;
	}

	public static Spcrule SelectSpcRule(IDbContext dbContext, long spcrulesysid, string siteid)
	{
		string apiName = "SelectSpcRule";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{spcrulesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectSpcRuleSqlDatabase : _sqlSelectSpcRuleOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SPCRULESYSID", spcrulesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SPCRULE", $"{spcrulesysid},{siteid}"));
		}
		Spcrule? result = ContextManager.DirectEntityQuery<Spcrule>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{spcrulesysid},{siteid}");
		}
		return result;
	}

	public static Spcrule SelectSpcRule4Update(IDbContext dbContext, long spcrulesysid, string siteid)
	{
		string apiName = "SelectSpcRule4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{spcrulesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectSpcRule4UpdateSqlDatabase : _sqlSelectSpcRule4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SPCRULESYSID", spcrulesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_SPCRULE", $"{spcrulesysid},{siteid}"));
		}
		Spcrule? result = ContextManager.DirectEntityQuery<Spcrule>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{spcrulesysid},{siteid}");
		}
		return result;
	}

	public static int UpsertSpcRule(IDbContext dbContext, RequestType requestType, Spcrule[] spcRuleList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateSpcRuleInternal(dbContext, spcRuleList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateSpcRule(dbContext, spcRuleList, optionSet, saveHist), 
			RequestType.DELETE => DeleteSpcRule(dbContext, spcRuleList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteSpcRule(dbContext, spcRuleList, optionSet, saveHist), 
			_ => RealDeleteSpcRule(dbContext, spcRuleList, optionSet, saveHist), 
		};
	}

	private static int CreateSpcRuleInternal(IDbContext dbContext, Spcrule[] spcRuleList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spcRuleList", spcRuleList);
		string text = "CreateSpcRule";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spcrule> list = new List<Spcrule>();
		foreach (Spcrule obj in spcRuleList)
		{
			Spcrule spcrule = new Spcrule();
			obj.CopyColumsTo(spcrule);
			spcrule.Activity = text;
			spcrule.CheckEntityUsable();
			obj.CopyCommonField(spcrule, systemTime, dbContext.Tid, isCreate: true);
			list.Add(spcrule);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateSpcRule(IDbContext dbContext, Spcrule[] spcRuleList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spcRuleList", spcRuleList);
		string text = "UpdateSpcRule";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spcrule> list = new List<Spcrule>();
		foreach (Spcrule spcrule in spcRuleList)
		{
			Spcrule spcRule4Update = GetSpcRule4Update(dbContext, spcrule.Spcrulesysid, spcrule.Siteid);
			if (spcRule4Update == null)
			{
				throw new EntityNotFoundException(typeof(Spcrule), $"{spcrule.Spcrulesysid},{spcrule.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Spcrule), $"{spcrule.Spcrulesysid},{spcrule.Siteid}", spcRule4Update.Isusable);
			string activity = spcRule4Update.Activity;
			string customactivity = spcRule4Update.Customactivity;
			string isusable = spcRule4Update.Isusable;
			DateTime? createtime = spcRule4Update.Createtime;
			string creator = spcRule4Update.Creator;
			spcrule.CopyColumsTo(spcRule4Update);
			spcRule4Update.Prevactivity = activity;
			spcRule4Update.Prevcustomactivity = customactivity;
			spcRule4Update.Creator = creator;
			spcRule4Update.Createtime = createtime;
			spcRule4Update.Isusable = isusable;
			spcRule4Update.Activity = text;
			spcrule.CopyCommonField(spcRule4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(spcRule4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteSpcRule(IDbContext dbContext, Spcrule[] spcRuleList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spcRuleList", spcRuleList);
		string text = "DeleteSpcRule";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spcrule> list = new List<Spcrule>();
		foreach (Spcrule spcrule in spcRuleList)
		{
			Spcrule spcRule4Update = GetSpcRule4Update(dbContext, spcrule.Spcrulesysid, spcrule.Siteid);
			if (spcRule4Update == null)
			{
				throw new EntityNotFoundException(typeof(Spcrule), $"{spcrule.Spcrulesysid},{spcrule.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Spcrule), $"{spcrule.Spcrulesysid},{spcrule.Siteid}", spcRule4Update.Isusable);
			spcRule4Update.Isusable = "UnUsable";
			spcrule.CopyCommonFieldUpdatePrev(spcRule4Update, systemTime, dbContext.Tid, text);
			spcrule.CopyExtensionCollection(spcRule4Update);
			list.Add(spcRule4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteSpcRule(IDbContext dbContext, Spcrule[] spcRuleList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spcRuleList", spcRuleList);
		string text = "UnDeleteSpcRule";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spcrule> list = new List<Spcrule>();
		foreach (Spcrule spcrule in spcRuleList)
		{
			Spcrule spcRule4Update = GetSpcRule4Update(dbContext, spcrule.Spcrulesysid, spcrule.Siteid);
			if (spcRule4Update == null)
			{
				throw new EntityNotFoundException(typeof(Spcrule), $"{spcrule.Spcrulesysid},{spcrule.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Spcrule), $"{spcrule.Spcrulesysid},{spcrule.Siteid}", spcRule4Update.Isusable);
			spcRule4Update.Isusable = "Usable";
			spcrule.CopyCommonFieldUpdatePrev(spcRule4Update, systemTime, dbContext.Tid, text);
			spcrule.CopyExtensionCollection(spcRule4Update);
			list.Add(spcRule4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteSpcRule(IDbContext dbContext, Spcrule[] spcRuleList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spcRuleList", spcRuleList);
		string text = "RealDeleteSpcRule";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spcrule> list = new List<Spcrule>();
		foreach (Spcrule spcrule in spcRuleList)
		{
			Spcrule spcRule4Update = GetSpcRule4Update(dbContext, spcrule.Spcrulesysid, spcrule.Siteid);
			if (spcRule4Update == null)
			{
				throw new EntityNotFoundException(typeof(Spcrule), $"{spcrule.Spcrulesysid},{spcrule.Siteid}");
			}
			spcrule.CopyCommonFieldUpdatePrev(spcRule4Update, systemTime, dbContext.Tid, text);
			spcrule.CopyExtensionCollection(spcRule4Update);
			list.Add(spcRule4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
