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
public class FACILITYMAP
{
	private static string _sqlGetFacilityMapSqlDatabase = "SELECT * FROM CIM_FACILITYMAP WHERE FACILITYID=@FACILITYID AND PARENTFACILITYID=@PARENTFACILITYID AND SITEID=@SITEID";

	private static string _sqlGetFacilityMap4UpdateSqlDatabase = "SELECT * FROM CIM_FACILITYMAP WITH(UPDLOCK) WHERE FACILITYID=@FACILITYID AND PARENTFACILITYID=@PARENTFACILITYID AND SITEID=@SITEID";

	private static string _sqlSelectFacilityMapSqlDatabase = "SELECT * FROM CIM_FACILITYMAP WHERE FACILITYID=@FACILITYID AND PARENTFACILITYID=@PARENTFACILITYID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectFacilityMap4UpdateSqlDatabase = "SELECT * FROM CIM_FACILITYMAP WITH(UPDLOCK) WHERE FACILITYID=@FACILITYID AND PARENTFACILITYID=@PARENTFACILITYID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetFacilityMapOracleDatabase = "SELECT * FROM CIM_FACILITYMAP WHERE FACILITYID=:FACILITYID AND PARENTFACILITYID=:PARENTFACILITYID AND SITEID=:SITEID";

	private static string _sqlGetFacilityMap4UpdateOracleDatabase = "SELECT * FROM CIM_FACILITYMAP WHERE FACILITYID=:FACILITYID AND PARENTFACILITYID=:PARENTFACILITYID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectFacilityMapOracleDatabase = "SELECT * FROM CIM_FACILITYMAP WHERE FACILITYID=:FACILITYID AND PARENTFACILITYID=:PARENTFACILITYID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectFacilityMap4UpdateOracleDatabase = "SELECT * FROM CIM_FACILITYMAP WHERE FACILITYID=:FACILITYID AND PARENTFACILITYID=:PARENTFACILITYID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Facilitymap);

	public static Facilitymap GetFacilityMap(IDbContext dbContext, string facilityid, string parentfacilityid, string siteid)
	{
		string apiName = "GetFacilityMap";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{facilityid},{parentfacilityid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetFacilityMapSqlDatabase : _sqlGetFacilityMapOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("FACILITYID", facilityid, typeOfThis));
		list.Add(dbContext.CreateParameter("PARENTFACILITYID", parentfacilityid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_FACILITYMAP", $"{facilityid},{parentfacilityid},{siteid}"));
		}
		Facilitymap? result = ContextManager.DirectEntityQuery<Facilitymap>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{facilityid},{parentfacilityid},{siteid}");
		}
		return result;
	}

	public static Facilitymap GetFacilityMap4Update(IDbContext dbContext, string facilityid, string parentfacilityid, string siteid)
	{
		string apiName = "GetFacilityMap4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{facilityid},{parentfacilityid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetFacilityMap4UpdateSqlDatabase : _sqlGetFacilityMap4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("FACILITYID", facilityid, typeOfThis));
		list.Add(dbContext.CreateParameter("PARENTFACILITYID", parentfacilityid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_FACILITYMAP", $"{facilityid},{parentfacilityid},{siteid}"));
		}
		Facilitymap? result = ContextManager.DirectEntityQuery<Facilitymap>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{facilityid},{parentfacilityid},{siteid}");
		}
		return result;
	}

	public static Facilitymap SelectFacilityMap(IDbContext dbContext, string facilityid, string parentfacilityid, string siteid)
	{
		string apiName = "SelectFacilityMap";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{facilityid},{parentfacilityid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectFacilityMapSqlDatabase : _sqlSelectFacilityMapOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("FACILITYID", facilityid, typeOfThis));
		list.Add(dbContext.CreateParameter("PARENTFACILITYID", parentfacilityid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_FACILITYMAP", $"{facilityid},{parentfacilityid},{siteid}"));
		}
		Facilitymap? result = ContextManager.DirectEntityQuery<Facilitymap>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{facilityid},{parentfacilityid},{siteid}");
		}
		return result;
	}

	public static Facilitymap SelectFacilityMap4Update(IDbContext dbContext, string facilityid, string parentfacilityid, string siteid)
	{
		string apiName = "SelectFacilityMap4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{facilityid},{parentfacilityid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectFacilityMap4UpdateSqlDatabase : _sqlSelectFacilityMap4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("FACILITYID", facilityid, typeOfThis));
		list.Add(dbContext.CreateParameter("PARENTFACILITYID", parentfacilityid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_FACILITYMAP", $"{facilityid},{parentfacilityid},{siteid}"));
		}
		Facilitymap? result = ContextManager.DirectEntityQuery<Facilitymap>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{facilityid},{parentfacilityid},{siteid}");
		}
		return result;
	}

	public static int UpsertFacilityMap(IDbContext dbContext, RequestType requestType, Facilitymap[] facilityMapList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateFacilityMapInternal(dbContext, facilityMapList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateFacilityMap(dbContext, facilityMapList, optionSet, saveHist), 
			RequestType.DELETE => DeleteFacilityMap(dbContext, facilityMapList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteFacilityMap(dbContext, facilityMapList, optionSet, saveHist), 
			_ => RealDeleteFacilityMap(dbContext, facilityMapList, optionSet, saveHist), 
		};
	}

	private static int CreateFacilityMapInternal(IDbContext dbContext, Facilitymap[] facilityMapList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("facilityMapList", facilityMapList);
		string text = "CreateFacilityMap";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Facilitymap> list = new List<Facilitymap>();
		foreach (Facilitymap obj in facilityMapList)
		{
			Facilitymap facilitymap = new Facilitymap();
			obj.CopyColumsTo(facilitymap);
			facilitymap.Activity = text;
			facilitymap.CheckEntityUsable();
			obj.CopyCommonField(facilitymap, systemTime, dbContext.Tid, isCreate: true);
			list.Add(facilitymap);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateFacilityMap(IDbContext dbContext, Facilitymap[] facilityMapList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("facilityMapList", facilityMapList);
		string text = "UpdateFacilityMap";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Facilitymap> list = new List<Facilitymap>();
		foreach (Facilitymap facilitymap in facilityMapList)
		{
			Facilitymap facilityMap4Update = GetFacilityMap4Update(dbContext, facilitymap.Facilityid, facilitymap.Parentfacilityid, facilitymap.Siteid);
			if (facilityMap4Update == null)
			{
				throw new EntityNotFoundException(typeof(Facilitymap), $"{facilitymap.Facilityid},{facilitymap.Parentfacilityid},{facilitymap.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Facilitymap), $"{facilitymap.Facilityid},{facilitymap.Parentfacilityid},{facilitymap.Siteid}", facilityMap4Update.Isusable);
			string activity = facilityMap4Update.Activity;
			string customactivity = facilityMap4Update.Customactivity;
			string isusable = facilityMap4Update.Isusable;
			DateTime? createtime = facilityMap4Update.Createtime;
			string creator = facilityMap4Update.Creator;
			facilitymap.CopyColumsTo(facilityMap4Update);
			facilityMap4Update.Prevactivity = activity;
			facilityMap4Update.Prevcustomactivity = customactivity;
			facilityMap4Update.Creator = creator;
			facilityMap4Update.Createtime = createtime;
			facilityMap4Update.Isusable = isusable;
			facilityMap4Update.Activity = text;
			facilitymap.CopyCommonField(facilityMap4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(facilityMap4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteFacilityMap(IDbContext dbContext, Facilitymap[] facilityMapList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("facilityMapList", facilityMapList);
		string text = "DeleteFacilityMap";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Facilitymap> list = new List<Facilitymap>();
		foreach (Facilitymap facilitymap in facilityMapList)
		{
			Facilitymap facilityMap4Update = GetFacilityMap4Update(dbContext, facilitymap.Facilityid, facilitymap.Parentfacilityid, facilitymap.Siteid);
			if (facilityMap4Update == null)
			{
				throw new EntityNotFoundException(typeof(Facilitymap), $"{facilitymap.Facilityid},{facilitymap.Parentfacilityid},{facilitymap.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Facilitymap), $"{facilitymap.Facilityid},{facilitymap.Parentfacilityid},{facilitymap.Siteid}", facilityMap4Update.Isusable);
			facilityMap4Update.Isusable = "UnUsable";
			facilitymap.CopyCommonFieldUpdatePrev(facilityMap4Update, systemTime, dbContext.Tid, text);
			facilitymap.CopyExtensionCollection(facilityMap4Update);
			list.Add(facilityMap4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteFacilityMap(IDbContext dbContext, Facilitymap[] facilityMapList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("facilityMapList", facilityMapList);
		string text = "UnDeleteFacilityMap";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Facilitymap> list = new List<Facilitymap>();
		foreach (Facilitymap facilitymap in facilityMapList)
		{
			Facilitymap facilityMap4Update = GetFacilityMap4Update(dbContext, facilitymap.Facilityid, facilitymap.Parentfacilityid, facilitymap.Siteid);
			if (facilityMap4Update == null)
			{
				throw new EntityNotFoundException(typeof(Facilitymap), $"{facilitymap.Facilityid},{facilitymap.Parentfacilityid},{facilitymap.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Facilitymap), $"{facilitymap.Facilityid},{facilitymap.Parentfacilityid},{facilitymap.Siteid}", facilityMap4Update.Isusable);
			facilityMap4Update.Isusable = "Usable";
			facilitymap.CopyCommonFieldUpdatePrev(facilityMap4Update, systemTime, dbContext.Tid, text);
			facilitymap.CopyExtensionCollection(facilityMap4Update);
			list.Add(facilityMap4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteFacilityMap(IDbContext dbContext, Facilitymap[] facilityMapList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("facilityMapList", facilityMapList);
		string text = "RealDeleteFacilityMap";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Facilitymap> list = new List<Facilitymap>();
		foreach (Facilitymap facilitymap in facilityMapList)
		{
			Facilitymap facilityMap4Update = GetFacilityMap4Update(dbContext, facilitymap.Facilityid, facilitymap.Parentfacilityid, facilitymap.Siteid);
			if (facilityMap4Update == null)
			{
				throw new EntityNotFoundException(typeof(Facilitymap), $"{facilitymap.Facilityid},{facilitymap.Parentfacilityid},{facilitymap.Siteid}");
			}
			facilitymap.CopyCommonFieldUpdatePrev(facilityMap4Update, systemTime, dbContext.Tid, text);
			facilitymap.CopyExtensionCollection(facilityMap4Update);
			list.Add(facilityMap4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
