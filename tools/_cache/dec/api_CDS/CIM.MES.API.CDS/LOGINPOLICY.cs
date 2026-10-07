using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.CDS;

[MESAPI]
public class LOGINPOLICY
{
	private static string _sqlGetLoginPolicySqlDatabase = "SELECT * FROM CIM_LOGINPOLICY WHERE LOGINDEFINITIONID=@LOGINDEFINITIONID AND SITEID=@SITEID";

	private static string _sqlGetLoginPolicy4UpdateSqlDatabase = "SELECT * FROM CIM_LOGINPOLICY WITH(UPDLOCK) WHERE LOGINDEFINITIONID=@LOGINDEFINITIONID AND SITEID=@SITEID";

	private static string _sqlSelectLoginPolicySqlDatabase = "SELECT * FROM CIM_LOGINPOLICY WHERE LOGINDEFINITIONID=@LOGINDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLoginPolicy4UpdateSqlDatabase = "SELECT * FROM CIM_LOGINPOLICY WITH(UPDLOCK) WHERE LOGINDEFINITIONID=@LOGINDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetLoginPolicyOracleDatabase = "SELECT * FROM CIM_LOGINPOLICY WHERE LOGINDEFINITIONID=:LOGINDEFINITIONID AND SITEID=:SITEID";

	private static string _sqlGetLoginPolicy4UpdateOracleDatabase = "SELECT * FROM CIM_LOGINPOLICY WHERE LOGINDEFINITIONID=:LOGINDEFINITIONID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectLoginPolicyOracleDatabase = "SELECT * FROM CIM_LOGINPOLICY WHERE LOGINDEFINITIONID=:LOGINDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLoginPolicy4UpdateOracleDatabase = "SELECT * FROM CIM_LOGINPOLICY WHERE LOGINDEFINITIONID=:LOGINDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Loginpolicy);

	private static string _sqlSelectPrimaryLoginPolicySqlDatabase = "SELECT * FROM CIM_LOGINPOLICY WHERE SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectPrimaryLoginPolicyOracleDatabase = "SELECT * FROM CIM_LOGINPOLICY WHERE SITEID=:SITEID AND ISUSABLE='Usable'";

	public static Loginpolicy GetLoginPolicy(IDbContext dbContext, string logindefinitionid, string siteid)
	{
		string apiName = "GetLoginPolicy";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{logindefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLoginPolicySqlDatabase : _sqlGetLoginPolicyOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOGINDEFINITIONID", logindefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOGINPOLICY", $"{logindefinitionid},{siteid}"));
		}
		Loginpolicy? result = ContextManager.DirectEntityQuery<Loginpolicy>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{logindefinitionid},{siteid}");
		}
		return result;
	}

	public static Loginpolicy GetLoginPolicy4Update(IDbContext dbContext, string logindefinitionid, string siteid)
	{
		string apiName = "GetLoginPolicy4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{logindefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLoginPolicy4UpdateSqlDatabase : _sqlGetLoginPolicy4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOGINDEFINITIONID", logindefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_LOGINPOLICY", $"{logindefinitionid},{siteid}"));
		}
		Loginpolicy? result = ContextManager.DirectEntityQuery<Loginpolicy>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{logindefinitionid},{siteid}");
		}
		return result;
	}

	public static Loginpolicy SelectLoginPolicy(IDbContext dbContext, string logindefinitionid, string siteid)
	{
		string apiName = "SelectLoginPolicy";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{logindefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLoginPolicySqlDatabase : _sqlSelectLoginPolicyOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOGINDEFINITIONID", logindefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOGINPOLICY", $"{logindefinitionid},{siteid}"));
		}
		Loginpolicy? result = ContextManager.DirectEntityQuery<Loginpolicy>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{logindefinitionid},{siteid}");
		}
		return result;
	}

	public static Loginpolicy SelectLoginPolicy4Update(IDbContext dbContext, string logindefinitionid, string siteid)
	{
		string apiName = "SelectLoginPolicy4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{logindefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLoginPolicy4UpdateSqlDatabase : _sqlSelectLoginPolicy4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOGINDEFINITIONID", logindefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_LOGINPOLICY", $"{logindefinitionid},{siteid}"));
		}
		Loginpolicy? result = ContextManager.DirectEntityQuery<Loginpolicy>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{logindefinitionid},{siteid}");
		}
		return result;
	}

	public static Loginpolicy SelectPrimaryLoginPolicy(IDbContext dbContext, string siteId)
	{
		string apiName = "SelectPrimaryLoginPolicy";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{siteId}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectPrimaryLoginPolicySqlDatabase : _sqlSelectPrimaryLoginPolicyOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		Loginpolicy? result = ContextManager.DirectEntityQuery<Loginpolicy>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{siteId}");
		}
		return result;
	}

	public static int UpsertLoginPolicy(IDbContext dbContext, RequestType requestType, Loginpolicy[] loginPolicyList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateLoginPolicyInternal(dbContext, loginPolicyList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateLoginPolicy(dbContext, loginPolicyList, optionSet, saveHist), 
			RequestType.DELETE => DeleteLoginPolicy(dbContext, loginPolicyList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteLoginPolicy(dbContext, loginPolicyList, optionSet, saveHist), 
			_ => RealDeleteLoginPolicy(dbContext, loginPolicyList, optionSet, saveHist), 
		};
	}

	private static int CreateLoginPolicyInternal(IDbContext dbContext, Loginpolicy[] loginPolicyList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("loginPolicyList", loginPolicyList);
		string text = "CreateLoginPolicy";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Loginpolicy> list = new List<Loginpolicy>();
		foreach (Loginpolicy obj in loginPolicyList)
		{
			Loginpolicy loginpolicy = new Loginpolicy();
			obj.CopyColumsTo(loginpolicy);
			loginpolicy.Activity = text;
			loginpolicy.CheckEntityUsable();
			obj.CopyCommonField(loginpolicy, systemTime, dbContext.Tid, isCreate: true);
			list.Add(loginpolicy);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateLoginPolicy(IDbContext dbContext, Loginpolicy[] loginPolicyList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("loginPolicyList", loginPolicyList);
		string text = "UpdateLoginPolicy";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Loginpolicy> list = new List<Loginpolicy>();
		foreach (Loginpolicy loginpolicy in loginPolicyList)
		{
			Loginpolicy loginPolicy4Update = GetLoginPolicy4Update(dbContext, loginpolicy.Logindefinitionid, loginpolicy.Siteid);
			if (loginPolicy4Update == null)
			{
				throw new EntityNotFoundException(typeof(Loginpolicy), $"{loginpolicy.Logindefinitionid},{loginpolicy.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Loginpolicy), $"{loginpolicy.Logindefinitionid},{loginpolicy.Siteid}", loginPolicy4Update.Isusable);
			string activity = loginPolicy4Update.Activity;
			string customactivity = loginPolicy4Update.Customactivity;
			string isusable = loginPolicy4Update.Isusable;
			DateTime? createtime = loginPolicy4Update.Createtime;
			string creator = loginPolicy4Update.Creator;
			loginpolicy.CopyColumsTo(loginPolicy4Update);
			loginPolicy4Update.Prevactivity = activity;
			loginPolicy4Update.Prevcustomactivity = customactivity;
			loginPolicy4Update.Creator = creator;
			loginPolicy4Update.Createtime = createtime;
			loginPolicy4Update.Isusable = isusable;
			loginPolicy4Update.Activity = text;
			loginpolicy.CopyCommonField(loginPolicy4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(loginPolicy4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteLoginPolicy(IDbContext dbContext, Loginpolicy[] loginPolicyList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("loginPolicyList", loginPolicyList);
		string text = "DeleteLoginPolicy";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Loginpolicy> list = new List<Loginpolicy>();
		foreach (Loginpolicy loginpolicy in loginPolicyList)
		{
			Loginpolicy loginPolicy4Update = GetLoginPolicy4Update(dbContext, loginpolicy.Logindefinitionid, loginpolicy.Siteid);
			if (loginPolicy4Update == null)
			{
				throw new EntityNotFoundException(typeof(Loginpolicy), $"{loginpolicy.Logindefinitionid},{loginpolicy.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Loginpolicy), $"{loginpolicy.Logindefinitionid},{loginpolicy.Siteid}", loginPolicy4Update.Isusable);
			loginPolicy4Update.Isusable = "UnUsable";
			loginpolicy.CopyCommonFieldUpdatePrev(loginPolicy4Update, systemTime, dbContext.Tid, text);
			loginpolicy.CopyExtensionCollection(loginPolicy4Update);
			list.Add(loginPolicy4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteLoginPolicy(IDbContext dbContext, Loginpolicy[] loginPolicyList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("loginPolicyList", loginPolicyList);
		string text = "UnDeleteLoginPolicy";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Loginpolicy> list = new List<Loginpolicy>();
		foreach (Loginpolicy loginpolicy in loginPolicyList)
		{
			Loginpolicy loginPolicy4Update = GetLoginPolicy4Update(dbContext, loginpolicy.Logindefinitionid, loginpolicy.Siteid);
			if (loginPolicy4Update == null)
			{
				throw new EntityNotFoundException(typeof(Loginpolicy), $"{loginpolicy.Logindefinitionid},{loginpolicy.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Loginpolicy), $"{loginpolicy.Logindefinitionid},{loginpolicy.Siteid}", loginPolicy4Update.Isusable);
			loginPolicy4Update.Isusable = "Usable";
			loginpolicy.CopyCommonFieldUpdatePrev(loginPolicy4Update, systemTime, dbContext.Tid, text);
			loginpolicy.CopyExtensionCollection(loginPolicy4Update);
			list.Add(loginPolicy4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteLoginPolicy(IDbContext dbContext, Loginpolicy[] loginPolicyList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("loginPolicyList", loginPolicyList);
		string text = "RealDeleteLoginPolicy";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Loginpolicy> list = new List<Loginpolicy>();
		foreach (Loginpolicy loginpolicy in loginPolicyList)
		{
			Loginpolicy loginPolicy4Update = GetLoginPolicy4Update(dbContext, loginpolicy.Logindefinitionid, loginpolicy.Siteid);
			if (loginPolicy4Update == null)
			{
				throw new EntityNotFoundException(typeof(Loginpolicy), $"{loginpolicy.Logindefinitionid},{loginpolicy.Siteid}");
			}
			loginpolicy.CopyCommonFieldUpdatePrev(loginPolicy4Update, systemTime, dbContext.Tid, text);
			loginpolicy.CopyExtensionCollection(loginPolicy4Update);
			list.Add(loginPolicy4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
