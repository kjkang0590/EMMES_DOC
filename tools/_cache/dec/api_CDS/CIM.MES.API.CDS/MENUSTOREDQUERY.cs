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
public class MENUSTOREDQUERY
{
	private static string _sqlGetMenuStoredQuerySqlDatabase = "SELECT * FROM CIM_MENUSTOREDQUERY WHERE MENUID=@MENUID AND MENUCLASSID=@MENUCLASSID AND STOREDQUERYID=@STOREDQUERYID AND STOREDQUERYVERSION=@STOREDQUERYVERSION AND STOREDQUERYCLASSID=@STOREDQUERYCLASSID AND SITEID=@SITEID";

	private static string _sqlGetMenuStoredQuery4UpdateSqlDatabase = "SELECT * FROM CIM_MENUSTOREDQUERY WITH(UPDLOCK) WHERE MENUID=@MENUID AND MENUCLASSID=@MENUCLASSID AND STOREDQUERYID=@STOREDQUERYID AND STOREDQUERYVERSION=@STOREDQUERYVERSION AND STOREDQUERYCLASSID=@STOREDQUERYCLASSID AND SITEID=@SITEID";

	private static string _sqlSelectMenuStoredQuerySqlDatabase = "SELECT * FROM CIM_MENUSTOREDQUERY WHERE MENUID=@MENUID AND MENUCLASSID=@MENUCLASSID AND STOREDQUERYID=@STOREDQUERYID AND STOREDQUERYVERSION=@STOREDQUERYVERSION AND STOREDQUERYCLASSID=@STOREDQUERYCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMenuStoredQuery4UpdateSqlDatabase = "SELECT * FROM CIM_MENUSTOREDQUERY WITH(UPDLOCK) WHERE MENUID=@MENUID AND MENUCLASSID=@MENUCLASSID AND STOREDQUERYID=@STOREDQUERYID AND STOREDQUERYVERSION=@STOREDQUERYVERSION AND STOREDQUERYCLASSID=@STOREDQUERYCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetMenuStoredQueryOracleDatabase = "SELECT * FROM CIM_MENUSTOREDQUERY WHERE MENUID=@MENUID AND MENUCLASSID=@MENUCLASSID AND STOREDQUERYID=:STOREDQUERYID AND STOREDQUERYVERSION=:STOREDQUERYVERSION AND STOREDQUERYCLASSID=:STOREDQUERYCLASSID AND SITEID=:SITEID";

	private static string _sqlGetMenuStoredQuery4UpdateOracleDatabase = "SELECT * FROM CIM_MENUSTOREDQUERY WHERE MENUID=@MENUID AND MENUCLASSID=@MENUCLASSID AND STOREDQUERYID=:STOREDQUERYID AND STOREDQUERYVERSION=:STOREDQUERYVERSION AND STOREDQUERYCLASSID=:STOREDQUERYCLASSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectMenuStoredQueryOracleDatabase = "SELECT * FROM CIM_MENUSTOREDQUERY WHERE MENUID=@MENUID AND MENUCLASSID=@MENUCLASSID AND STOREDQUERYID=:STOREDQUERYID AND STOREDQUERYVERSION=:STOREDQUERYVERSION AND STOREDQUERYCLASSID=:STOREDQUERYCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMenuStoredQuery4UpdateOracleDatabase = "SELECT * FROM CIM_MENUSTOREDQUERY WHERE MENUID=@MENUID AND MENUCLASSID=@MENUCLASSID AND STOREDQUERYID=:STOREDQUERYID AND STOREDQUERYVERSION=:STOREDQUERYVERSION AND STOREDQUERYCLASSID=:STOREDQUERYCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Menustoredquery);

	public static Menustoredquery GetMenuStoredQuery(IDbContext dbContext, string menuid, string menuclassid, string storedqueryid, string storedqueryversion, string storedqueryclassid, string siteid)
	{
		string apiName = "GetMenuStoredQuery";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{menuid},{menuclassid},{storedqueryid},{storedqueryversion},{storedqueryclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetMenuStoredQuerySqlDatabase : _sqlGetMenuStoredQueryOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUCLASSID", menuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("STOREDQUERYID", storedqueryid, typeOfThis));
		list.Add(dbContext.CreateParameter("STOREDQUERYVERSION", storedqueryversion, typeOfThis));
		list.Add(dbContext.CreateParameter("STOREDQUERYCLASSID", storedqueryclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MENUSTOREDQUERY", $"{menuid},{menuclassid},{storedqueryid},{storedqueryversion},{storedqueryclassid},{siteid}"));
		}
		Menustoredquery result = ContextManager.DirectEntityQuery<Menustoredquery>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{menuid},{menuclassid},{storedqueryid},{storedqueryversion},{storedqueryclassid},{siteid}");
		}
		return result;
	}

	public static Menustoredquery GetMenuStoredQuery4Update(IDbContext dbContext, string menuid, string menuclassid, string storedqueryid, string storedqueryversion, string storedqueryclassid, string siteid)
	{
		string apiName = "GetMenuStoredQuery4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{menuid},{menuclassid},{storedqueryid},{storedqueryversion},{storedqueryclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetMenuStoredQuery4UpdateSqlDatabase : _sqlGetMenuStoredQuery4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUCLASSID", menuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("STOREDQUERYID", storedqueryid, typeOfThis));
		list.Add(dbContext.CreateParameter("STOREDQUERYVERSION", storedqueryversion, typeOfThis));
		list.Add(dbContext.CreateParameter("STOREDQUERYCLASSID", storedqueryclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_MENUSTOREDQUERY", $"{menuid},{menuclassid},{storedqueryid},{storedqueryversion},{storedqueryclassid},{siteid}"));
		}
		Menustoredquery result = ContextManager.DirectEntityQuery<Menustoredquery>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{menuid},{menuclassid},{storedqueryid},{storedqueryversion},{storedqueryclassid},{siteid}");
		}
		return result;
	}

	public static Storedquery SelectMenuStoredQuery(IDbContext dbContext, string menuid, string menuclassid, string storedqueryid, string storedqueryversion, string storedqueryclassid, string siteid)
	{
		string apiName = "SelectMenuStoredQuery";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{menuid},{menuclassid},{storedqueryid},{storedqueryversion},{storedqueryclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMenuStoredQuerySqlDatabase : _sqlSelectMenuStoredQueryOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUCLASSID", menuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("STOREDQUERYID", storedqueryid, typeOfThis));
		list.Add(dbContext.CreateParameter("STOREDQUERYVERSION", storedqueryversion, typeOfThis));
		list.Add(dbContext.CreateParameter("STOREDQUERYCLASSID", storedqueryclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_STOREDQUERY", $"{menuid},{menuclassid},{storedqueryid},{storedqueryversion},{storedqueryclassid},{siteid}"));
		}
		Storedquery result = ContextManager.DirectEntityQuery<Storedquery>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{menuid},{menuclassid},{storedqueryid},{storedqueryversion},{storedqueryclassid},{siteid}");
		}
		return result;
	}

	public static Storedquery SelectMenuStoredQuery4Update(IDbContext dbContext, string menuid, string menuclassid, string storedqueryid, string storedqueryversion, string storedqueryclassid, string siteid)
	{
		string apiName = "SelectMenuStoredQuery4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{menuid},{menuclassid},{storedqueryid},{storedqueryversion},{storedqueryclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMenuStoredQuery4UpdateSqlDatabase : _sqlSelectMenuStoredQuery4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUCLASSID", menuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("STOREDQUERYID", storedqueryid, typeOfThis));
		list.Add(dbContext.CreateParameter("STOREDQUERYVERSION", storedqueryversion, typeOfThis));
		list.Add(dbContext.CreateParameter("STOREDQUERYCLASSID", storedqueryclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_STOREDQUERY", $"{menuid},{menuclassid},{storedqueryid},{storedqueryversion},{storedqueryclassid},{siteid}"));
		}
		Storedquery result = ContextManager.DirectEntityQuery<Storedquery>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{menuid},{menuclassid},{storedqueryid},{storedqueryversion},{storedqueryclassid},{siteid}");
		}
		return result;
	}

	public static int UpsertMenuStoredQuery(IDbContext dbContext, RequestType requestType, Menustoredquery[] menuStoredQueryList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateMenuStoredQueryInternal(dbContext, menuStoredQueryList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateMenuStoredQuery(dbContext, menuStoredQueryList, optionSet, saveHist), 
			RequestType.DELETE => DeleteMenuStoredQuery(dbContext, menuStoredQueryList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteMenuStoredQuery(dbContext, menuStoredQueryList, optionSet, saveHist), 
			_ => RealDeleteMenuStoredQuery(dbContext, menuStoredQueryList, optionSet, saveHist), 
		};
	}

	private static int CreateMenuStoredQueryInternal(IDbContext dbContext, Menustoredquery[] menuStoredQueryList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("menuStoredQueryList", menuStoredQueryList);
		string text = "CreateMenuStoredQuery";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Menustoredquery> list = new List<Menustoredquery>();
		foreach (Menustoredquery obj in menuStoredQueryList)
		{
			Menustoredquery menustoredquery = new Menustoredquery();
			obj.CopyColumsTo(menustoredquery);
			menustoredquery.Activity = text;
			menustoredquery.CheckEntityUsable();
			obj.CopyCommonField(menustoredquery, systemTime, dbContext.Tid, isCreate: true);
			list.Add(menustoredquery);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateMenuStoredQuery(IDbContext dbContext, Menustoredquery[] menuStoredQueryList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("menuStoredQueryList", menuStoredQueryList);
		string text = "UpdateMenuStoredQuery";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Menustoredquery> list = new List<Menustoredquery>();
		foreach (Menustoredquery menustoredquery in menuStoredQueryList)
		{
			Menustoredquery menuStoredQuery4Update = GetMenuStoredQuery4Update(dbContext, menustoredquery.Menuid, menustoredquery.Menuclassid, menustoredquery.Storedqueryid, menustoredquery.Storedqueryversion, menustoredquery.Storedqueryclassid, menustoredquery.Siteid);
			if (menuStoredQuery4Update == null)
			{
				throw new EntityNotFoundException(typeof(Menustoredquery), $"{menustoredquery.Menuid},{menustoredquery.Menuclassid},{menustoredquery.Storedqueryid},{menustoredquery.Storedqueryversion},{menustoredquery.Storedqueryclassid},{menustoredquery.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Menustoredquery), $"{menustoredquery.Menuid},{menustoredquery.Menuclassid},{menustoredquery.Storedqueryid},{menustoredquery.Storedqueryversion},{menustoredquery.Storedqueryclassid},{menustoredquery.Siteid}", menuStoredQuery4Update.Isusable);
			string activity = menuStoredQuery4Update.Activity;
			string customactivity = menuStoredQuery4Update.Customactivity;
			string isusable = menuStoredQuery4Update.Isusable;
			DateTime? createtime = menuStoredQuery4Update.Createtime;
			string creator = menuStoredQuery4Update.Creator;
			menustoredquery.CopyColumsTo(menuStoredQuery4Update);
			menuStoredQuery4Update.Prevactivity = activity;
			menuStoredQuery4Update.Prevcustomactivity = customactivity;
			menuStoredQuery4Update.Creator = creator;
			menuStoredQuery4Update.Createtime = createtime;
			menuStoredQuery4Update.Isusable = isusable;
			menuStoredQuery4Update.Activity = text;
			menustoredquery.CopyCommonField(menuStoredQuery4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(menuStoredQuery4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteMenuStoredQuery(IDbContext dbContext, Menustoredquery[] menuStoredQueryList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("menuStoredQueryList", menuStoredQueryList);
		string text = "DeleteMenuStoredQuery";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Menustoredquery> list = new List<Menustoredquery>();
		foreach (Menustoredquery menustoredquery in menuStoredQueryList)
		{
			Menustoredquery menuStoredQuery4Update = GetMenuStoredQuery4Update(dbContext, menustoredquery.Menuid, menustoredquery.Menuclassid, menustoredquery.Storedqueryid, menustoredquery.Storedqueryversion, menustoredquery.Storedqueryclassid, menustoredquery.Siteid);
			if (menuStoredQuery4Update == null)
			{
				throw new EntityNotFoundException(typeof(Menustoredquery), $"{menustoredquery.Menuid},{menustoredquery.Menuclassid},{menustoredquery.Storedqueryid},{menustoredquery.Storedqueryversion},{menustoredquery.Storedqueryclassid},{menustoredquery.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Menustoredquery), $"{menustoredquery.Menuid},{menustoredquery.Menuclassid},{menustoredquery.Storedqueryid},{menustoredquery.Storedqueryversion},{menustoredquery.Storedqueryclassid},{menustoredquery.Siteid}", menuStoredQuery4Update.Isusable);
			menuStoredQuery4Update.Isusable = "UnUsable";
			menustoredquery.CopyCommonFieldUpdatePrev(menuStoredQuery4Update, systemTime, dbContext.Tid, text);
			menustoredquery.CopyExtensionCollection(menuStoredQuery4Update);
			list.Add(menuStoredQuery4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteMenuStoredQuery(IDbContext dbContext, Menustoredquery[] menuStoredQueryList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("menuStoredQueryList", menuStoredQueryList);
		string text = "UnDeleteMenuStoredQuery";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Menustoredquery> list = new List<Menustoredquery>();
		foreach (Menustoredquery menustoredquery in menuStoredQueryList)
		{
			Menustoredquery menuStoredQuery4Update = GetMenuStoredQuery4Update(dbContext, menustoredquery.Menuid, menustoredquery.Menuclassid, menustoredquery.Storedqueryid, menustoredquery.Storedqueryversion, menustoredquery.Storedqueryclassid, menustoredquery.Siteid);
			if (menuStoredQuery4Update == null)
			{
				throw new EntityNotFoundException(typeof(Menustoredquery), $"{menustoredquery.Menuid},{menustoredquery.Menuclassid},{menustoredquery.Storedqueryid},{menustoredquery.Storedqueryversion},{menustoredquery.Storedqueryclassid},{menustoredquery.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Menustoredquery), $"{menustoredquery.Menuid},{menustoredquery.Menuclassid},{menustoredquery.Storedqueryid},{menustoredquery.Storedqueryversion},{menustoredquery.Storedqueryclassid},{menustoredquery.Siteid}", menuStoredQuery4Update.Isusable);
			menuStoredQuery4Update.Isusable = "Usable";
			menustoredquery.CopyCommonFieldUpdatePrev(menuStoredQuery4Update, systemTime, dbContext.Tid, text);
			menustoredquery.CopyExtensionCollection(menuStoredQuery4Update);
			list.Add(menuStoredQuery4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteMenuStoredQuery(IDbContext dbContext, Menustoredquery[] menuStoredQueryList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("menuStoredQueryList", menuStoredQueryList);
		string text = "RealDeleteMenuStoredQuery";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Menustoredquery> list = new List<Menustoredquery>();
		foreach (Menustoredquery menustoredquery in menuStoredQueryList)
		{
			Menustoredquery menuStoredQuery4Update = GetMenuStoredQuery4Update(dbContext, menustoredquery.Menuid, menustoredquery.Menuclassid, menustoredquery.Storedqueryid, menustoredquery.Storedqueryversion, menustoredquery.Storedqueryclassid, menustoredquery.Siteid);
			if (menuStoredQuery4Update == null)
			{
				throw new EntityNotFoundException(typeof(Menustoredquery), $"{menustoredquery.Menuid},{menustoredquery.Menuclassid},{menustoredquery.Storedqueryid},{menustoredquery.Storedqueryversion},{menustoredquery.Storedqueryclassid},{menustoredquery.Siteid}");
			}
			menustoredquery.CopyCommonFieldUpdatePrev(menuStoredQuery4Update, systemTime, dbContext.Tid, text);
			menustoredquery.CopyExtensionCollection(menuStoredQuery4Update);
			list.Add(menuStoredQuery4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
