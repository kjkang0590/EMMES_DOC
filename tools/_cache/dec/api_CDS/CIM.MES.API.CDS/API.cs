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
public class API
{
	private static string _sqlGetApiSqlDatabase = "SELECT * FROM CIM_API WHERE APIID=@APIID AND APIVERSION=@APIVERSION AND SITEID=@SITEID";

	private static string _sqlGetApi4UpdateSqlDatabase = "SELECT * FROM CIM_API WITH(UPDLOCK) WHERE APIID=@APIID AND APIVERSION=@APIVERSION AND SITEID=@SITEID";

	private static string _sqlSelectApiSqlDatabase = "SELECT * FROM CIM_API WHERE APIID=@APIID AND APIVERSION=@APIVERSION AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectApi4UpdateSqlDatabase = "SELECT * FROM CIM_API WITH(UPDLOCK) WHERE APIID=@APIID AND APIVERSION=@APIVERSION AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetApiOracleDatabase = "SELECT * FROM CIM_API WHERE APIID=:APIID AND APIVERSION=:APIVERSION AND SITEID=:SITEID";

	private static string _sqlGetApi4UpdateOracleDatabase = "SELECT * FROM CIM_API WHERE APIID=:APIID AND APIVERSION=:APIVERSION AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectApiOracleDatabase = "SELECT * FROM CIM_API WHERE APIID=:APIID AND APIVERSION=:APIVERSION AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectApi4UpdateOracleDatabase = "SELECT * FROM CIM_API WHERE APIID=:APIID AND APIVERSION=:APIVERSION AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Api);

	public static bool CheckAllowHoldLot(IDbContext dbContext, string apiid, int apiversion, string siteid)
	{
		string apiName = "CheckAllowHoldLot";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{apiid},{apiversion},{siteid}");
		}
		bool result = false;
		Api api = SelectApiFromCache(dbContext, apiid, apiversion, siteid);
		if (api == null)
		{
			return result;
		}
		result = api.Allowholdlot == "Y";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{apiid},{apiversion},{siteid}");
		}
		return result;
	}

	public static bool CheckAllowHoldProducedMaterial(IDbContext dbContext, string apiid, int apiversion, string siteid)
	{
		string apiName = "CheckAllowHoldProducedMaterial";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{apiid},{apiversion},{siteid}");
		}
		bool result = false;
		Api api = SelectApiFromCache(dbContext, apiid, apiversion, siteid);
		if (api == null)
		{
			return result;
		}
		result = api.Allowholdproducedmaterial == "Y";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{apiid},{apiversion},{siteid}");
		}
		return result;
	}

	public static Api GetApi(IDbContext dbContext, string apiid, int apiversion, string siteid)
	{
		string apiName = "GetApi";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{apiid},{apiversion},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetApiSqlDatabase : _sqlGetApiOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("APIID", apiid, typeOfThis));
		list.Add(dbContext.CreateParameter("APIVERSION", apiversion, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_API", $"{apiid},{apiversion},{siteid}"));
		}
		Api? result = ContextManager.DirectEntityQuery<Api>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{apiid},{apiversion},{siteid}");
		}
		return result;
	}

	public static Api GetApi4Update(IDbContext dbContext, string apiid, decimal apiversion, string siteid)
	{
		string apiName = "GetApi4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{apiid},{apiversion},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetApi4UpdateSqlDatabase : _sqlGetApi4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("APIID", apiid, typeOfThis));
		list.Add(dbContext.CreateParameter("APIVERSION", apiversion, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_API", $"{apiid},{apiversion},{siteid}"));
		}
		Api? result = ContextManager.DirectEntityQuery<Api>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{apiid},{apiversion},{siteid}");
		}
		return result;
	}

	public static Api SelectApi(IDbContext dbContext, string apiid, int apiversion, string siteid)
	{
		string apiName = "SelectApi";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{apiid},{apiversion},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectApiSqlDatabase : _sqlSelectApiOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("APIID", apiid, typeOfThis));
		list.Add(dbContext.CreateParameter("APIVERSION", apiversion, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_API", $"{apiid},{apiversion},{siteid}"));
		}
		Api? result = ContextManager.DirectEntityQuery<Api>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{apiid},{apiversion},{siteid}");
		}
		return result;
	}

	public static Api SelectApi4Update(IDbContext dbContext, string apiid, int apiversion, string siteid)
	{
		string apiName = "SelectApi4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{apiid},{apiversion},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectApi4UpdateSqlDatabase : _sqlSelectApi4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("APIID", apiid, typeOfThis));
		list.Add(dbContext.CreateParameter("APIVERSION", apiversion, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_API", $"{apiid},{apiversion},{siteid}"));
		}
		Api? result = ContextManager.DirectEntityQuery<Api>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{apiid},{apiversion},{siteid}");
		}
		return result;
	}

	public static Api SelectApiFromCache(IDbContext dbContext, string apiid, int apiversion, string siteid)
	{
		string apiName = "GetApiObjectFromCache";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{apiid},{apiversion},{siteid}");
		}
		_ = dbContext.Name;
		Api? result = dbContext.Cache.Api.FirstOrDefault((Api db) => db.Apiid == apiid && db.Apiversion == apiversion && db.Siteid == siteid && db.Isusable == "Usable");
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{apiid},{apiversion},{siteid}");
		}
		return result;
	}

	public static int UpsertApi(IDbContext dbContext, RequestType requestType, Api[] apiList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateApiInternal(dbContext, apiList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateApi(dbContext, apiList, optionSet, saveHist), 
			RequestType.DELETE => DeleteApi(dbContext, apiList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteApi(dbContext, apiList, optionSet, saveHist), 
			_ => RealDeleteApi(dbContext, apiList, optionSet, saveHist), 
		};
	}

	private static int CreateApiInternal(IDbContext dbContext, Api[] apiList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("apiList", apiList);
		string text = "CreateApi";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Api> list = new List<Api>();
		foreach (Api obj in apiList)
		{
			Api api = new Api();
			obj.CopyColumsTo(api);
			api.Activity = text;
			api.CheckEntityUsable();
			obj.CopyCommonField(api, systemTime, dbContext.Tid, isCreate: true);
			list.Add(api);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateApi(IDbContext dbContext, Api[] apiList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("apiList", apiList);
		string text = "UpdateApi";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Api> list = new List<Api>();
		foreach (Api api in apiList)
		{
			Api api4Update = GetApi4Update(dbContext, api.Apiid, api.Apiversion, api.Siteid);
			if (api4Update == null)
			{
				throw new EntityNotFoundException(typeof(Api), $"{api.Apiid},{api.Apiversion},{api.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Api), $"{api.Apiid},{api.Apiversion},{api.Siteid}", api4Update.Isusable);
			string activity = api4Update.Activity;
			string customactivity = api4Update.Customactivity;
			string isusable = api4Update.Isusable;
			DateTime? createtime = api4Update.Createtime;
			string creator = api4Update.Creator;
			api.CopyColumsTo(api4Update);
			api4Update.Prevactivity = activity;
			api4Update.Prevcustomactivity = customactivity;
			api4Update.Creator = creator;
			api4Update.Createtime = createtime;
			api4Update.Isusable = isusable;
			api4Update.Activity = text;
			api.CopyCommonField(api4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(api4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteApi(IDbContext dbContext, Api[] apiList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("apiList", apiList);
		string text = "DeleteApi";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Api> list = new List<Api>();
		foreach (Api api in apiList)
		{
			Api api4Update = GetApi4Update(dbContext, api.Apiid, api.Apiversion, api.Siteid);
			if (api4Update == null)
			{
				throw new EntityNotFoundException(typeof(Api), $"{api.Apiid},{api.Apiversion},{api.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Api), $"{api.Apiid},{api.Apiversion},{api.Siteid}", api4Update.Isusable);
			api4Update.Isusable = "UnUsable";
			api.CopyCommonFieldUpdatePrev(api4Update, systemTime, dbContext.Tid, text);
			api.CopyExtensionCollection(api4Update);
			list.Add(api4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteApi(IDbContext dbContext, Api[] apiList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("apiList", apiList);
		string text = "UnDeleteApi";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Api> list = new List<Api>();
		foreach (Api api in apiList)
		{
			Api api4Update = GetApi4Update(dbContext, api.Apiid, api.Apiversion, api.Siteid);
			if (api4Update == null)
			{
				throw new EntityNotFoundException(typeof(Api), $"{api.Apiid},{api.Apiversion},{api.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Api), $"{api.Apiid},{api.Apiversion},{api.Siteid}", api4Update.Isusable);
			api4Update.Isusable = "Usable";
			api.CopyCommonFieldUpdatePrev(api4Update, systemTime, dbContext.Tid, text);
			api.CopyExtensionCollection(api4Update);
			list.Add(api4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteApi(IDbContext dbContext, Api[] apiList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("apiList", apiList);
		string text = "RealDeleteApi";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Api> list = new List<Api>();
		foreach (Api api in apiList)
		{
			Api api4Update = GetApi4Update(dbContext, api.Apiid, api.Apiversion, api.Siteid);
			if (api4Update == null)
			{
				throw new EntityNotFoundException(typeof(Api), $"{api.Apiid},{api.Apiversion},{api.Siteid}");
			}
			api.CopyCommonFieldUpdatePrev(api4Update, systemTime, dbContext.Tid, text);
			api.CopyExtensionCollection(api4Update);
			list.Add(api4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
