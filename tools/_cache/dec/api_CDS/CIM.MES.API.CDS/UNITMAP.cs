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
public class UNITMAP
{
	private static string _sqlGetUnitMapSqlDatabase = "SELECT * FROM CIM_UNITMAP WHERE FROMUNITID=@FROMUNITID AND TOUNITID=@TOUNITID AND SITEID=@SITEID";

	private static string _sqlGetUnitMap4UpdateSqlDatabase = "SELECT * FROM CIM_UNITMAP WITH(UPDLOCK) WHERE FROMUNITID=@FROMUNITID AND TOUNITID=@TOUNITID AND SITEID=@SITEID";

	private static string _sqlSelectUnitMapSqlDatabase = "SELECT * FROM CIM_UNITMAP WHERE FROMUNITID=@FROMUNITID AND TOUNITID=@TOUNITID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectUnitMap4UpdateSqlDatabase = "SELECT * FROM CIM_UNITMAP WITH(UPDLOCK) WHERE FROMUNITID=@FROMUNITID AND TOUNITID=@TOUNITID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetUnitMapOracleDatabase = "SELECT * FROM CIM_UNITMAP WHERE FROMUNITID=:FROMUNITID AND TOUNITID=:TOUNITID AND SITEID=:SITEID";

	private static string _sqlGetUnitMap4UpdateOracleDatabase = "SELECT * FROM CIM_UNITMAP WHERE FROMUNITID=:FROMUNITID AND TOUNITID=:TOUNITID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectUnitMapOracleDatabase = "SELECT * FROM CIM_UNITMAP WHERE FROMUNITID=:FROMUNITID AND TOUNITID=:TOUNITID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectUnitMap4UpdateOracleDatabase = "SELECT * FROM CIM_UNITMAP WHERE FROMUNITID=:FROMUNITID AND TOUNITID=:TOUNITID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Unitmap);

	public static Unitmap GetUnitMap(IDbContext dbContext, string fromunitid, string tounitid, string siteid)
	{
		string apiName = "GetUnitMap";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{fromunitid},{tounitid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetUnitMapSqlDatabase : _sqlGetUnitMapOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("FROMUNITID", fromunitid, typeOfThis));
		list.Add(dbContext.CreateParameter("TOUNITID", tounitid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_UNITMAP", $"{fromunitid},{tounitid},{siteid}"));
		}
		Unitmap? result = ContextManager.DirectEntityQuery<Unitmap>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{fromunitid},{tounitid},{siteid}");
		}
		return result;
	}

	public static Unitmap GetUnitMap4Update(IDbContext dbContext, string fromunitid, string tounitid, string siteid)
	{
		string apiName = "GetUnitMap4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{fromunitid},{tounitid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetUnitMap4UpdateSqlDatabase : _sqlGetUnitMap4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("FROMUNITID", fromunitid, typeOfThis));
		list.Add(dbContext.CreateParameter("TOUNITID", tounitid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_UNITMAP", $"{fromunitid},{tounitid},{siteid}"));
		}
		Unitmap? result = ContextManager.DirectEntityQuery<Unitmap>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{fromunitid},{tounitid},{siteid}");
		}
		return result;
	}

	public static Unitmap SelectUnitMap(IDbContext dbContext, string fromunitid, string tounitid, string siteid)
	{
		string apiName = "SelectUnitMap";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{fromunitid},{tounitid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectUnitMapSqlDatabase : _sqlSelectUnitMapOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("FROMUNITID", fromunitid, typeOfThis));
		list.Add(dbContext.CreateParameter("TOUNITID", tounitid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_UNITMAP", $"{fromunitid},{tounitid},{siteid}"));
		}
		Unitmap? result = ContextManager.DirectEntityQuery<Unitmap>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{fromunitid},{tounitid},{siteid}");
		}
		return result;
	}

	public static Unitmap SelectUnitMap4Update(IDbContext dbContext, string fromunitid, string tounitid, string siteid)
	{
		string apiName = "SelectUnitMap4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{fromunitid},{tounitid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectUnitMap4UpdateSqlDatabase : _sqlSelectUnitMap4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("FROMUNITID", fromunitid, typeOfThis));
		list.Add(dbContext.CreateParameter("TOUNITID", tounitid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_UNITMAP", $"{fromunitid},{tounitid},{siteid}"));
		}
		Unitmap? result = ContextManager.DirectEntityQuery<Unitmap>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{fromunitid},{tounitid},{siteid}");
		}
		return result;
	}

	public static int UpsertUnitMap(IDbContext dbContext, RequestType requestType, Unitmap[] unitMapList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateUnitMapInternal(dbContext, unitMapList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateUnitMap(dbContext, unitMapList, optionSet, saveHist), 
			RequestType.DELETE => DeleteUnitMap(dbContext, unitMapList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteUnitMap(dbContext, unitMapList, optionSet, saveHist), 
			_ => RealDeleteUnitMap(dbContext, unitMapList, optionSet, saveHist), 
		};
	}

	private static int CreateUnitMapInternal(IDbContext dbContext, Unitmap[] unitMapList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("unitMapList", unitMapList);
		string text = "CreateUnitMap";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Unitmap> list = new List<Unitmap>();
		foreach (Unitmap obj in unitMapList)
		{
			Unitmap unitmap = new Unitmap();
			obj.CopyColumsTo(unitmap);
			unitmap.Activity = text;
			unitmap.CheckEntityUsable();
			obj.CopyCommonField(unitmap, systemTime, dbContext.Tid, isCreate: true);
			list.Add(unitmap);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateUnitMap(IDbContext dbContext, Unitmap[] unitMapList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("unitMapList", unitMapList);
		string text = "UpdateUnitMap";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Unitmap> list = new List<Unitmap>();
		foreach (Unitmap unitmap in unitMapList)
		{
			Unitmap unitMap4Update = GetUnitMap4Update(dbContext, unitmap.Fromunitid, unitmap.Tounitid, unitmap.Siteid);
			if (unitMap4Update == null)
			{
				throw new EntityNotFoundException(typeof(Unitmap), $"{unitmap.Fromunitid},{unitmap.Tounitid},{unitmap.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Unitmap), $"{unitmap.Fromunitid},{unitmap.Tounitid},{unitmap.Siteid}", unitMap4Update.Isusable);
			string activity = unitMap4Update.Activity;
			string customactivity = unitMap4Update.Customactivity;
			string isusable = unitMap4Update.Isusable;
			DateTime? createtime = unitMap4Update.Createtime;
			string creator = unitMap4Update.Creator;
			unitmap.CopyColumsTo(unitMap4Update);
			unitMap4Update.Prevactivity = activity;
			unitMap4Update.Prevcustomactivity = customactivity;
			unitMap4Update.Creator = creator;
			unitMap4Update.Createtime = createtime;
			unitMap4Update.Isusable = isusable;
			unitMap4Update.Activity = text;
			unitmap.CopyCommonField(unitMap4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(unitMap4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteUnitMap(IDbContext dbContext, Unitmap[] unitMapList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("unitMapList", unitMapList);
		string text = "DeleteUnitMap";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Unitmap> list = new List<Unitmap>();
		foreach (Unitmap unitmap in unitMapList)
		{
			Unitmap unitMap4Update = GetUnitMap4Update(dbContext, unitmap.Fromunitid, unitmap.Tounitid, unitmap.Siteid);
			if (unitMap4Update == null)
			{
				throw new EntityNotFoundException(typeof(Unitmap), $"{unitmap.Fromunitid},{unitmap.Tounitid},{unitmap.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Unitmap), $"{unitmap.Fromunitid},{unitmap.Tounitid},{unitmap.Siteid}", unitMap4Update.Isusable);
			unitMap4Update.Isusable = "UnUsable";
			unitmap.CopyCommonFieldUpdatePrev(unitMap4Update, systemTime, dbContext.Tid, text);
			unitmap.CopyExtensionCollection(unitMap4Update);
			list.Add(unitMap4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteUnitMap(IDbContext dbContext, Unitmap[] unitMapList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("unitMapList", unitMapList);
		string text = "UnDeleteUnitMap";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Unitmap> list = new List<Unitmap>();
		foreach (Unitmap unitmap in unitMapList)
		{
			Unitmap unitMap4Update = GetUnitMap4Update(dbContext, unitmap.Fromunitid, unitmap.Tounitid, unitmap.Siteid);
			if (unitMap4Update == null)
			{
				throw new EntityNotFoundException(typeof(Unitmap), $"{unitmap.Fromunitid},{unitmap.Tounitid},{unitmap.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Unitmap), $"{unitmap.Fromunitid},{unitmap.Tounitid},{unitmap.Siteid}", unitMap4Update.Isusable);
			unitMap4Update.Isusable = "Usable";
			unitmap.CopyCommonFieldUpdatePrev(unitMap4Update, systemTime, dbContext.Tid, text);
			unitmap.CopyExtensionCollection(unitMap4Update);
			list.Add(unitMap4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteUnitMap(IDbContext dbContext, Unitmap[] unitMapList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("unitMapList", unitMapList);
		string text = "RealDeleteUnitMap";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Unitmap> list = new List<Unitmap>();
		foreach (Unitmap unitmap in unitMapList)
		{
			Unitmap unitMap4Update = GetUnitMap4Update(dbContext, unitmap.Fromunitid, unitmap.Tounitid, unitmap.Siteid);
			if (unitMap4Update == null)
			{
				throw new EntityNotFoundException(typeof(Unitmap), $"{unitmap.Fromunitid},{unitmap.Tounitid},{unitmap.Siteid}");
			}
			unitmap.CopyCommonFieldUpdatePrev(unitMap4Update, systemTime, dbContext.Tid, text);
			unitmap.CopyExtensionCollection(unitMap4Update);
			list.Add(unitMap4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
