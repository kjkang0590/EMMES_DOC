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
public class TRACEITEM
{
	private static string _sqlGetTraceItemSqlDatabase = "SELECT * FROM CIM_TRACEITEM WHERE EQUIPMENTID=@EQUIPMENTID AND TRACEITEMDEFINITIONID=@TRACEITEMDEFINITIONID AND SITEID=@SITEID";

	private static string _sqlGetTraceItem4UpdateSqlDatabase = "SELECT * FROM CIM_TRACEITEM WITH(UPDLOCK) WHERE EQUIPMENTID=@EQUIPMENTID AND TRACEITEMDEFINITIONID=@TRACEITEMDEFINITIONID AND SITEID=@SITEID";

	private static string _sqlSelectTraceItemSqlDatabase = "SELECT * FROM CIM_TRACEITEM WHERE EQUIPMENTID=@EQUIPMENTID AND TRACEITEMDEFINITIONID=@TRACEITEMDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectTraceItem4UpdateSqlDatabase = "SELECT * FROM CIM_TRACEITEM WITH(UPDLOCK) WHERE EQUIPMENTID=@EQUIPMENTID AND TRACEITEMDEFINITIONID=@TRACEITEMDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetTraceItemOracleDatabase = "SELECT * FROM CIM_TRACEITEM WHERE EQUIPMENTID=:EQUIPMENTID AND TRACEITEMDEFINITIONID=:TRACEITEMDEFINITIONID AND SITEID=:SITEID";

	private static string _sqlGetTraceItem4UpdateOracleDatabase = "SELECT * FROM CIM_TRACEITEM WHERE EQUIPMENTID=:EQUIPMENTID AND TRACEITEMDEFINITIONID=:TRACEITEMDEFINITIONID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectTraceItemOracleDatabase = "SELECT * FROM CIM_TRACEITEM WHERE EQUIPMENTID=:EQUIPMENTID AND TRACEITEMDEFINITIONID=:TRACEITEMDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectTraceItem4UpdateOracleDatabase = "SELECT * FROM CIM_TRACEITEM WHERE EQUIPMENTID=:EQUIPMENTID AND TRACEITEMDEFINITIONID=:TRACEITEMDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Traceitem);

	public static Traceitem GetTraceItem(IDbContext dbContext, string equipmentid, string traceitemdefinitionid, string siteid)
	{
		string apiName = "GetTraceItem";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentid},{traceitemdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetTraceItemSqlDatabase : _sqlGetTraceItemOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("TRACEITEMDEFINITIONID", traceitemdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_TRACEITEM", $"{equipmentid},{traceitemdefinitionid},{siteid}"));
		}
		Traceitem? result = ContextManager.DirectEntityQuery<Traceitem>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentid},{traceitemdefinitionid},{siteid}");
		}
		return result;
	}

	public static Traceitem GetTraceItem4Update(IDbContext dbContext, string equipmentid, string traceitemdefinitionid, string siteid)
	{
		string apiName = "GetTraceItem4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentid},{traceitemdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetTraceItem4UpdateSqlDatabase : _sqlGetTraceItem4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("TRACEITEMDEFINITIONID", traceitemdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_TRACEITEM", $"{equipmentid},{traceitemdefinitionid},{siteid}"));
		}
		Traceitem? result = ContextManager.DirectEntityQuery<Traceitem>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentid},{traceitemdefinitionid},{siteid}");
		}
		return result;
	}

	public static Traceitem SelectTraceItem(IDbContext dbContext, string equipmentid, string traceitemdefinitionid, string siteid)
	{
		string apiName = "SelectTraceItem";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentid},{traceitemdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectTraceItemSqlDatabase : _sqlSelectTraceItemOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("TRACEITEMDEFINITIONID", traceitemdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_TRACEITEM", $"{equipmentid},{traceitemdefinitionid},{siteid}"));
		}
		Traceitem? result = ContextManager.DirectEntityQuery<Traceitem>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentid},{traceitemdefinitionid},{siteid}");
		}
		return result;
	}

	public static Traceitem SelectTraceItem4Update(IDbContext dbContext, string equipmentid, string traceitemdefinitionid, string siteid)
	{
		string apiName = "SelectTraceItem4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentid},{traceitemdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectTraceItem4UpdateSqlDatabase : _sqlSelectTraceItem4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("TRACEITEMDEFINITIONID", traceitemdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_TRACEITEM", $"{equipmentid},{traceitemdefinitionid},{siteid}"));
		}
		Traceitem? result = ContextManager.DirectEntityQuery<Traceitem>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentid},{traceitemdefinitionid},{siteid}");
		}
		return result;
	}

	public static int UpsertTraceItem(IDbContext dbContext, RequestType requestType, Traceitem[] traceItemList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateTraceItemInternal(dbContext, traceItemList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateTraceItem(dbContext, traceItemList, optionSet, saveHist), 
			RequestType.DELETE => DeleteTraceItem(dbContext, traceItemList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteTraceItem(dbContext, traceItemList, optionSet, saveHist), 
			_ => RealDeleteTraceItem(dbContext, traceItemList, optionSet, saveHist), 
		};
	}

	private static int CreateTraceItemInternal(IDbContext dbContext, Traceitem[] traceItemList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceItemList", traceItemList);
		string text = "CreateTraceItem";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Traceitem> list = new List<Traceitem>();
		foreach (Traceitem obj in traceItemList)
		{
			Traceitem traceitem = new Traceitem();
			obj.CopyColumsTo(traceitem);
			traceitem.Activity = text;
			traceitem.CheckEntityUsable();
			obj.CopyCommonField(traceitem, systemTime, dbContext.Tid, isCreate: true);
			list.Add(traceitem);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateTraceItem(IDbContext dbContext, Traceitem[] traceItemList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceItemList", traceItemList);
		string text = "UpdateTraceItem";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Traceitem> list = new List<Traceitem>();
		foreach (Traceitem traceitem in traceItemList)
		{
			Traceitem traceItem4Update = GetTraceItem4Update(dbContext, traceitem.Equipmentid, traceitem.Traceitemdefinitionid, traceitem.Siteid);
			if (traceItem4Update == null)
			{
				throw new EntityNotFoundException(typeof(Traceitem), $"{traceitem.Equipmentid},{traceitem.Traceitemdefinitionid},{traceitem.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Traceitem), $"{traceitem.Equipmentid},{traceitem.Traceitemdefinitionid},{traceitem.Siteid}", traceItem4Update.Isusable);
			string activity = traceItem4Update.Activity;
			string customactivity = traceItem4Update.Customactivity;
			string isusable = traceItem4Update.Isusable;
			DateTime? createtime = traceItem4Update.Createtime;
			string creator = traceItem4Update.Creator;
			traceitem.CopyColumsTo(traceItem4Update);
			traceItem4Update.Prevactivity = activity;
			traceItem4Update.Prevcustomactivity = customactivity;
			traceItem4Update.Creator = creator;
			traceItem4Update.Createtime = createtime;
			traceItem4Update.Isusable = isusable;
			traceItem4Update.Activity = text;
			traceitem.CopyCommonField(traceItem4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(traceItem4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteTraceItem(IDbContext dbContext, Traceitem[] traceItemList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceItemList", traceItemList);
		string text = "DeleteTraceItem";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Traceitem> list = new List<Traceitem>();
		foreach (Traceitem traceitem in traceItemList)
		{
			Traceitem traceItem4Update = GetTraceItem4Update(dbContext, traceitem.Equipmentid, traceitem.Traceitemdefinitionid, traceitem.Siteid);
			if (traceItem4Update == null)
			{
				throw new EntityNotFoundException(typeof(Traceitem), $"{traceitem.Equipmentid},{traceitem.Traceitemdefinitionid},{traceitem.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Traceitem), $"{traceitem.Equipmentid},{traceitem.Traceitemdefinitionid},{traceitem.Siteid}", traceItem4Update.Isusable);
			traceItem4Update.Isusable = "UnUsable";
			traceitem.CopyCommonFieldUpdatePrev(traceItem4Update, systemTime, dbContext.Tid, text);
			traceitem.CopyExtensionCollection(traceItem4Update);
			list.Add(traceItem4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteTraceItem(IDbContext dbContext, Traceitem[] traceItemList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceItemList", traceItemList);
		string text = "UnDeleteTraceItem";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Traceitem> list = new List<Traceitem>();
		foreach (Traceitem traceitem in traceItemList)
		{
			Traceitem traceItem4Update = GetTraceItem4Update(dbContext, traceitem.Equipmentid, traceitem.Traceitemdefinitionid, traceitem.Siteid);
			if (traceItem4Update == null)
			{
				throw new EntityNotFoundException(typeof(Traceitem), $"{traceitem.Equipmentid},{traceitem.Traceitemdefinitionid},{traceitem.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Traceitem), $"{traceitem.Equipmentid},{traceitem.Traceitemdefinitionid},{traceitem.Siteid}", traceItem4Update.Isusable);
			traceItem4Update.Isusable = "Usable";
			traceitem.CopyCommonFieldUpdatePrev(traceItem4Update, systemTime, dbContext.Tid, text);
			traceitem.CopyExtensionCollection(traceItem4Update);
			list.Add(traceItem4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteTraceItem(IDbContext dbContext, Traceitem[] traceItemList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceItemList", traceItemList);
		string text = "RealDeleteTraceItem";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Traceitem> list = new List<Traceitem>();
		foreach (Traceitem traceitem in traceItemList)
		{
			Traceitem traceItem4Update = GetTraceItem4Update(dbContext, traceitem.Equipmentid, traceitem.Traceitemdefinitionid, traceitem.Siteid);
			if (traceItem4Update == null)
			{
				throw new EntityNotFoundException(typeof(Traceitem), $"{traceitem.Equipmentid},{traceitem.Traceitemdefinitionid},{traceitem.Siteid}");
			}
			traceitem.CopyCommonFieldUpdatePrev(traceItem4Update, systemTime, dbContext.Tid, text);
			traceitem.CopyExtensionCollection(traceItem4Update);
			list.Add(traceItem4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
