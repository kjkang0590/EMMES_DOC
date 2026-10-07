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
public class SPCITEM
{
	private static string _sqlGetSpcItemSqlDatabase = "SELECT * FROM CIM_SPCITEM WHERE SPCITEMSYSID=@SPCITEMSYSID AND SITEID=@SITEID";

	private static string _sqlGetSpcItem4UpdateSqlDatabase = "SELECT * FROM CIM_SPCITEM WITH(UPDLOCK) WHERE SPCITEMSYSID=@SPCITEMSYSID AND SITEID=@SITEID";

	private static string _sqlSelectSpcItemSqlDatabase = "SELECT * FROM CIM_SPCITEM WHERE SPCITEMSYSID=@SPCITEMSYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectSpcItem4UpdateSqlDatabase = "SELECT * FROM CIM_SPCITEM WITH(UPDLOCK) WHERE SPCITEMSYSID=@SPCITEMSYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetSpcItemOracleDatabase = "SELECT * FROM CIM_SPCITEM WHERE SPCITEMSYSID=:SPCITEMSYSID AND SITEID=:SITEID";

	private static string _sqlGetSpcItem4UpdateOracleDatabase = "SELECT * FROM CIM_SPCITEM WHERE SPCITEMSYSID=:SPCITEMSYSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectSpcItemOracleDatabase = "SELECT * FROM CIM_SPCITEM WHERE SPCITEMSYSID=:SPCITEMSYSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectSpcItem4UpdateOracleDatabase = "SELECT * FROM CIM_SPCITEM WHERE SPCITEMSYSID=:SPCITEMSYSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Spcitem);

	public static Spcitem GetSpcItem(IDbContext dbContext, long spcitemsysid, string siteid)
	{
		string apiName = "GetSpcItem";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{spcitemsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetSpcItemSqlDatabase : _sqlGetSpcItemOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SPCITEMSYSID", spcitemsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SPCITEM", $"{spcitemsysid},{siteid}"));
		}
		Spcitem? result = ContextManager.DirectEntityQuery<Spcitem>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{spcitemsysid},{siteid}");
		}
		return result;
	}

	public static Spcitem GetSpcItem4Update(IDbContext dbContext, long spcitemsysid, string siteid)
	{
		string apiName = "GetSpcItem4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{spcitemsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetSpcItem4UpdateSqlDatabase : _sqlGetSpcItem4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SPCITEMSYSID", spcitemsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_SPCITEM", $"{spcitemsysid},{siteid}"));
		}
		Spcitem? result = ContextManager.DirectEntityQuery<Spcitem>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{spcitemsysid},{siteid}");
		}
		return result;
	}

	public static Spcitem SelectSpcItem(IDbContext dbContext, long spcitemsysid, string siteid)
	{
		string apiName = "SelectSpcItem";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{spcitemsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectSpcItemSqlDatabase : _sqlSelectSpcItemOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SPCITEMSYSID", spcitemsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SPCITEM", $"{spcitemsysid},{siteid}"));
		}
		Spcitem? result = ContextManager.DirectEntityQuery<Spcitem>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{spcitemsysid},{siteid}");
		}
		return result;
	}

	public static Spcitem SelectSpcItem4Update(IDbContext dbContext, long spcitemsysid, string siteid)
	{
		string apiName = "SelectSpcItem4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{spcitemsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectSpcItem4UpdateSqlDatabase : _sqlSelectSpcItem4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SPCITEMSYSID", spcitemsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_SPCITEM", $"{spcitemsysid},{siteid}"));
		}
		Spcitem? result = ContextManager.DirectEntityQuery<Spcitem>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{spcitemsysid},{siteid}");
		}
		return result;
	}

	public static int UpsertSpcItem(IDbContext dbContext, RequestType requestType, Spcitem[] spcItemList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateSpcItemInternal(dbContext, spcItemList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateSpcItem(dbContext, spcItemList, optionSet, saveHist), 
			RequestType.DELETE => DeleteSpcItem(dbContext, spcItemList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteSpcItem(dbContext, spcItemList, optionSet, saveHist), 
			_ => RealDeleteSpcItem(dbContext, spcItemList, optionSet, saveHist), 
		};
	}

	private static int CreateSpcItemInternal(IDbContext dbContext, Spcitem[] spcItemList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spcItemList", spcItemList);
		string text = "CreateSpcItem";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spcitem> list = new List<Spcitem>();
		foreach (Spcitem obj in spcItemList)
		{
			Spcitem spcitem = new Spcitem();
			obj.CopyColumsTo(spcitem);
			spcitem.Activity = text;
			spcitem.CheckEntityUsable();
			obj.CopyCommonField(spcitem, systemTime, dbContext.Tid, isCreate: true);
			list.Add(spcitem);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateSpcItem(IDbContext dbContext, Spcitem[] spcItemList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spcItemList", spcItemList);
		string text = "UpdateSpcItem";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spcitem> list = new List<Spcitem>();
		foreach (Spcitem spcitem in spcItemList)
		{
			Spcitem spcItem4Update = GetSpcItem4Update(dbContext, spcitem.Spcitemsysid, spcitem.Siteid);
			if (spcItem4Update == null)
			{
				throw new EntityNotFoundException(typeof(Spcitem), $"{spcitem.Spcitemsysid},{spcitem.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Spcitem), $"{spcitem.Spcitemsysid},{spcitem.Siteid}", spcItem4Update.Isusable);
			string activity = spcItem4Update.Activity;
			string customactivity = spcItem4Update.Customactivity;
			string isusable = spcItem4Update.Isusable;
			DateTime? createtime = spcItem4Update.Createtime;
			string creator = spcItem4Update.Creator;
			spcitem.CopyColumsTo(spcItem4Update);
			spcItem4Update.Prevactivity = activity;
			spcItem4Update.Prevcustomactivity = customactivity;
			spcItem4Update.Creator = creator;
			spcItem4Update.Createtime = createtime;
			spcItem4Update.Isusable = isusable;
			spcItem4Update.Activity = text;
			spcitem.CopyCommonField(spcItem4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(spcItem4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteSpcItem(IDbContext dbContext, Spcitem[] spcItemList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spcItemList", spcItemList);
		string text = "DeleteSpcItem";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spcitem> list = new List<Spcitem>();
		foreach (Spcitem spcitem in spcItemList)
		{
			Spcitem spcItem4Update = GetSpcItem4Update(dbContext, spcitem.Spcitemsysid, spcitem.Siteid);
			if (spcItem4Update == null)
			{
				throw new EntityNotFoundException(typeof(Spcitem), $"{spcitem.Spcitemsysid},{spcitem.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Spcitem), $"{spcitem.Spcitemsysid},{spcitem.Siteid}", spcItem4Update.Isusable);
			spcItem4Update.Isusable = "UnUsable";
			spcitem.CopyCommonFieldUpdatePrev(spcItem4Update, systemTime, dbContext.Tid, text);
			spcitem.CopyExtensionCollection(spcItem4Update);
			list.Add(spcItem4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteSpcItem(IDbContext dbContext, Spcitem[] spcItemList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spcItemList", spcItemList);
		string text = "UnDeleteSpcItem";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spcitem> list = new List<Spcitem>();
		foreach (Spcitem spcitem in spcItemList)
		{
			Spcitem spcItem4Update = GetSpcItem4Update(dbContext, spcitem.Spcitemsysid, spcitem.Siteid);
			if (spcItem4Update == null)
			{
				throw new EntityNotFoundException(typeof(Spcitem), $"{spcitem.Spcitemsysid},{spcitem.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Spcitem), $"{spcitem.Spcitemsysid},{spcitem.Siteid}", spcItem4Update.Isusable);
			spcItem4Update.Isusable = "Usable";
			spcitem.CopyCommonFieldUpdatePrev(spcItem4Update, systemTime, dbContext.Tid, text);
			spcitem.CopyExtensionCollection(spcItem4Update);
			list.Add(spcItem4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteSpcItem(IDbContext dbContext, Spcitem[] spcItemList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spcItemList", spcItemList);
		string text = "RealDeleteSpcItem";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spcitem> list = new List<Spcitem>();
		foreach (Spcitem spcitem in spcItemList)
		{
			Spcitem spcItem4Update = GetSpcItem4Update(dbContext, spcitem.Spcitemsysid, spcitem.Siteid);
			if (spcItem4Update == null)
			{
				throw new EntityNotFoundException(typeof(Spcitem), $"{spcitem.Spcitemsysid},{spcitem.Siteid}");
			}
			spcitem.CopyCommonFieldUpdatePrev(spcItem4Update, systemTime, dbContext.Tid, text);
			spcitem.CopyExtensionCollection(spcItem4Update);
			list.Add(spcItem4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
