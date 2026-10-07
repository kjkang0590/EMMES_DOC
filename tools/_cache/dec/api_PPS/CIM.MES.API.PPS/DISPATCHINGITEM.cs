using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.PPS;

[MESAPI]
public class DISPATCHINGITEM
{
	private static string _sqlGetDispatchingItemSqlDatabase = "SELECT * FROM CIM_DISPATCHINGITEM WHERE DISPATCHINGITEMID=@DISPATCHINGITEMID AND ITEMTYPE=@ITEMTYPE AND SITEID=@SITEID";

	private static string _sqlGetDispatchingItem4UpdateSqlDatabase = "SELECT * FROM CIM_DISPATCHINGITEM WITH(UPDLOCK) WHERE DISPATCHINGITEMID=@DISPATCHINGITEMID AND ITEMTYPE=@ITEMTYPE AND SITEID=@SITEID";

	private static string _sqlSelectDispatchingItemSqlDatabase = "SELECT * FROM CIM_DISPATCHINGITEM WHERE DISPATCHINGITEMID=@DISPATCHINGITEMID AND ITEMTYPE=@ITEMTYPE AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectDispatchingItem4UpdateSqlDatabase = "SELECT * FROM CIM_DISPATCHINGITEM WITH(UPDLOCK) WHERE DISPATCHINGITEMID=@DISPATCHINGITEMID AND ITEMTYPE=@ITEMTYPE AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetDispatchingItemOracleDatabase = "SELECT * FROM CIM_DISPATCHINGITEM WHERE DISPATCHINGITEMID=:DISPATCHINGITEMID AND ITEMTYPE=:ITEMTYPE AND SITEID=:SITEID";

	private static string _sqlGetDispatchingItem4UpdateOracleDatabase = "SELECT * FROM CIM_DISPATCHINGITEM WHERE DISPATCHINGITEMID=:DISPATCHINGITEMID AND ITEMTYPE=:ITEMTYPE AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectDispatchingItemOracleDatabase = "SELECT * FROM CIM_DISPATCHINGITEM WHERE DISPATCHINGITEMID=:DISPATCHINGITEMID AND ITEMTYPE=:ITEMTYPE AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectDispatchingItem4UpdateOracleDatabase = "SELECT * FROM CIM_DISPATCHINGITEM WHERE DISPATCHINGITEMID=:DISPATCHINGITEMID AND ITEMTYPE=:ITEMTYPE AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Dispatchingitem);

	public static Dispatchingitem GetDispatchingItem(IDbContext dbContext, string dispatchingitemid, string itemtype, string siteid)
	{
		string apiName = "GetDispatchingItem";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{dispatchingitemid},{itemtype},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetDispatchingItemSqlDatabase : _sqlGetDispatchingItemOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DISPATCHINGITEMID", dispatchingitemid, typeOfThis));
		list.Add(dbContext.CreateParameter("ITEMTYPE", itemtype, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_DISPATCHINGITEM", $"{dispatchingitemid},{itemtype},{siteid}"));
		}
		Dispatchingitem? result = ContextManager.DirectEntityQuery<Dispatchingitem>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{dispatchingitemid},{itemtype},{siteid}");
		}
		return result;
	}

	public static Dispatchingitem GetDispatchingItem4Update(IDbContext dbContext, string dispatchingitemid, string itemtype, string siteid)
	{
		string apiName = "GetDispatchingItem4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{dispatchingitemid},{itemtype},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetDispatchingItem4UpdateSqlDatabase : _sqlGetDispatchingItem4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DISPATCHINGITEMID", dispatchingitemid, typeOfThis));
		list.Add(dbContext.CreateParameter("ITEMTYPE", itemtype, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_DISPATCHINGITEM", $"{dispatchingitemid},{itemtype},{siteid}"));
		}
		Dispatchingitem? result = ContextManager.DirectEntityQuery<Dispatchingitem>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{dispatchingitemid},{itemtype},{siteid}");
		}
		return result;
	}

	public static Dispatchingitem SelectDispatchingItem(IDbContext dbContext, string dispatchingitemid, string itemtype, string siteid)
	{
		string apiName = "SelectDispatchingItem";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{dispatchingitemid},{itemtype},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectDispatchingItemSqlDatabase : _sqlSelectDispatchingItemOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DISPATCHINGITEMID", dispatchingitemid, typeOfThis));
		list.Add(dbContext.CreateParameter("ITEMTYPE", itemtype, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_DISPATCHINGITEM", $"{dispatchingitemid},{itemtype},{siteid}"));
		}
		Dispatchingitem? result = ContextManager.DirectEntityQuery<Dispatchingitem>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{dispatchingitemid},{itemtype},{siteid}");
		}
		return result;
	}

	public static Dispatchingitem SelectDispatchingItem4Update(IDbContext dbContext, string dispatchingitemid, string itemtype, string siteid)
	{
		string apiName = "SelectDispatchingItem4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{dispatchingitemid},{itemtype},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectDispatchingItem4UpdateSqlDatabase : _sqlSelectDispatchingItem4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DISPATCHINGITEMID", dispatchingitemid, typeOfThis));
		list.Add(dbContext.CreateParameter("ITEMTYPE", itemtype, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_DISPATCHINGITEM", $"{dispatchingitemid},{itemtype},{siteid}"));
		}
		Dispatchingitem? result = ContextManager.DirectEntityQuery<Dispatchingitem>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{dispatchingitemid},{itemtype},{siteid}");
		}
		return result;
	}

	public static int UpsertDispatchingItem(IDbContext dbContext, RequestType requestType, Dispatchingitem[] dispatchingItemList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateDispatchingItemInternal(dbContext, dispatchingItemList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateDispatchingItem(dbContext, dispatchingItemList, optionSet, saveHist), 
			RequestType.DELETE => DeleteDispatchingItem(dbContext, dispatchingItemList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteDispatchingItem(dbContext, dispatchingItemList, optionSet, saveHist), 
			_ => RealDeleteDispatchingItem(dbContext, dispatchingItemList, optionSet, saveHist), 
		};
	}

	private static int CreateDispatchingItemInternal(IDbContext dbContext, Dispatchingitem[] dispatchingItemList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("dispatchingItemList", dispatchingItemList);
		string text = "CreateDispatchingItem";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Dispatchingitem> list = new List<Dispatchingitem>();
		foreach (Dispatchingitem obj in dispatchingItemList)
		{
			Dispatchingitem dispatchingitem = new Dispatchingitem();
			obj.CopyColumsTo(dispatchingitem);
			dispatchingitem.Activity = text;
			dispatchingitem.CheckEntityUsable();
			obj.CopyCommonField(dispatchingitem, systemTime, dbContext.Tid, isCreate: true);
			list.Add(dispatchingitem);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateDispatchingItem(IDbContext dbContext, Dispatchingitem[] dispatchingItemList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("dispatchingItemList", dispatchingItemList);
		string text = "UpdateDispatchingItem";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Dispatchingitem> list = new List<Dispatchingitem>();
		foreach (Dispatchingitem dispatchingitem in dispatchingItemList)
		{
			Dispatchingitem dispatchingItem4Update = GetDispatchingItem4Update(dbContext, dispatchingitem.Dispatchingitemid, dispatchingitem.Itemtype, dispatchingitem.Siteid);
			if (dispatchingItem4Update == null)
			{
				throw new EntityNotFoundException(typeof(Dispatchingitem), $"{dispatchingitem.Dispatchingitemid},{dispatchingitem.Itemtype},{dispatchingitem.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Dispatchingitem), $"{dispatchingitem.Dispatchingitemid},{dispatchingitem.Itemtype},{dispatchingitem.Siteid}", dispatchingItem4Update.Isusable);
			string activity = dispatchingItem4Update.Activity;
			string customactivity = dispatchingItem4Update.Customactivity;
			string isusable = dispatchingItem4Update.Isusable;
			DateTime? createtime = dispatchingItem4Update.Createtime;
			string creator = dispatchingItem4Update.Creator;
			dispatchingitem.CopyColumsTo(dispatchingItem4Update);
			dispatchingItem4Update.Prevactivity = activity;
			dispatchingItem4Update.Prevcustomactivity = customactivity;
			dispatchingItem4Update.Creator = creator;
			dispatchingItem4Update.Createtime = createtime;
			dispatchingItem4Update.Isusable = isusable;
			dispatchingItem4Update.Activity = text;
			dispatchingitem.CopyCommonField(dispatchingItem4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(dispatchingItem4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteDispatchingItem(IDbContext dbContext, Dispatchingitem[] dispatchingItemList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("dispatchingItemList", dispatchingItemList);
		string text = "DeleteDispatchingItem";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Dispatchingitem> list = new List<Dispatchingitem>();
		foreach (Dispatchingitem dispatchingitem in dispatchingItemList)
		{
			Dispatchingitem dispatchingItem4Update = GetDispatchingItem4Update(dbContext, dispatchingitem.Dispatchingitemid, dispatchingitem.Itemtype, dispatchingitem.Siteid);
			if (dispatchingItem4Update == null)
			{
				throw new EntityNotFoundException(typeof(Dispatchingitem), $"{dispatchingitem.Dispatchingitemid},{dispatchingitem.Itemtype},{dispatchingitem.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Dispatchingitem), $"{dispatchingitem.Dispatchingitemid},{dispatchingitem.Itemtype},{dispatchingitem.Siteid}", dispatchingItem4Update.Isusable);
			dispatchingItem4Update.Isusable = "UnUsable";
			dispatchingitem.CopyCommonFieldUpdatePrev(dispatchingItem4Update, systemTime, dbContext.Tid, text);
			dispatchingitem.CopyExtensionCollection(dispatchingItem4Update);
			list.Add(dispatchingItem4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteDispatchingItem(IDbContext dbContext, Dispatchingitem[] dispatchingItemList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("dispatchingItemList", dispatchingItemList);
		string text = "UnDeleteDispatchingItem";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Dispatchingitem> list = new List<Dispatchingitem>();
		foreach (Dispatchingitem dispatchingitem in dispatchingItemList)
		{
			Dispatchingitem dispatchingItem4Update = GetDispatchingItem4Update(dbContext, dispatchingitem.Dispatchingitemid, dispatchingitem.Itemtype, dispatchingitem.Siteid);
			if (dispatchingItem4Update == null)
			{
				throw new EntityNotFoundException(typeof(Dispatchingitem), $"{dispatchingitem.Dispatchingitemid},{dispatchingitem.Itemtype},{dispatchingitem.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Dispatchingitem), $"{dispatchingitem.Dispatchingitemid},{dispatchingitem.Itemtype},{dispatchingitem.Siteid}", dispatchingItem4Update.Isusable);
			dispatchingItem4Update.Isusable = "Usable";
			dispatchingitem.CopyCommonFieldUpdatePrev(dispatchingItem4Update, systemTime, dbContext.Tid, text);
			dispatchingitem.CopyExtensionCollection(dispatchingItem4Update);
			list.Add(dispatchingItem4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteDispatchingItem(IDbContext dbContext, Dispatchingitem[] dispatchingItemList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("dispatchingItemList", dispatchingItemList);
		string text = "RealDeleteDispatchingItem";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Dispatchingitem> list = new List<Dispatchingitem>();
		foreach (Dispatchingitem dispatchingitem in dispatchingItemList)
		{
			Dispatchingitem dispatchingItem4Update = GetDispatchingItem4Update(dbContext, dispatchingitem.Dispatchingitemid, dispatchingitem.Itemtype, dispatchingitem.Siteid);
			if (dispatchingItem4Update == null)
			{
				throw new EntityNotFoundException(typeof(Dispatchingitem), $"{dispatchingitem.Dispatchingitemid},{dispatchingitem.Itemtype},{dispatchingitem.Siteid}");
			}
			dispatchingitem.CopyCommonFieldUpdatePrev(dispatchingItem4Update, systemTime, dbContext.Tid, text);
			dispatchingitem.CopyExtensionCollection(dispatchingItem4Update);
			list.Add(dispatchingItem4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
