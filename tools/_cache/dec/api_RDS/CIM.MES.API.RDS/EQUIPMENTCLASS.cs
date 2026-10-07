using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.RDS;

[MESAPI]
public class EQUIPMENTCLASS
{
	private static string _sqlGetEquipmentClassSqlDatabase = "SELECT * FROM CIM_EQUIPMENTCLASS WHERE EQUIPMENTCLASSID=@EQUIPMENTCLASSID AND SITEID=@SITEID";

	private static string _sqlGetEquipmentClass4UpdateSqlDatabase = "SELECT * FROM CIM_EQUIPMENTCLASS WITH(UPDLOCK) WHERE EQUIPMENTCLASSID=@EQUIPMENTCLASSID AND SITEID=@SITEID";

	private static string _sqlSelectEquipmentClassSqlDatabase = "SELECT * FROM CIM_EQUIPMENTCLASS WHERE EQUIPMENTCLASSID=@EQUIPMENTCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectEquipmentClass4UpdateSqlDatabase = "SELECT * FROM CIM_EQUIPMENTCLASS WITH(UPDLOCK) WHERE EQUIPMENTCLASSID=@EQUIPMENTCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetEquipmentClassOracleDatabase = "SELECT * FROM CIM_EQUIPMENTCLASS WHERE EQUIPMENTCLASSID=:EQUIPMENTCLASSID AND SITEID=:SITEID";

	private static string _sqlGetEquipmentClass4UpdateOracleDatabase = "SELECT * FROM CIM_EQUIPMENTCLASS WHERE EQUIPMENTCLASSID=:EQUIPMENTCLASSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectEquipmentClassOracleDatabase = "SELECT * FROM CIM_EQUIPMENTCLASS WHERE EQUIPMENTCLASSID=:EQUIPMENTCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectEquipmentClass4UpdateOracleDatabase = "SELECT * FROM CIM_EQUIPMENTCLASS WHERE EQUIPMENTCLASSID=:EQUIPMENTCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Equipmentclass);

	public static Equipmentclass GetEquipmentClass(IDbContext dbContext, string equipmentclassid, string siteid)
	{
		string apiName = "GetEquipmentClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetEquipmentClassSqlDatabase : _sqlGetEquipmentClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTCLASSID", equipmentclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_EQUIPMENTCLASS", $"{equipmentclassid},{siteid}"));
		}
		Equipmentclass? result = ContextManager.DirectEntityQuery<Equipmentclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentclassid},{siteid}");
		}
		return result;
	}

	public static Equipmentclass GetEquipmentClass4Update(IDbContext dbContext, string equipmentclassid, string siteid)
	{
		string apiName = "GetEquipmentClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetEquipmentClass4UpdateSqlDatabase : _sqlGetEquipmentClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTCLASSID", equipmentclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_EQUIPMENTCLASS", $"{equipmentclassid},{siteid}"));
		}
		Equipmentclass? result = ContextManager.DirectEntityQuery<Equipmentclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentclassid},{siteid}");
		}
		return result;
	}

	public static Equipmentclass SelectEquipmentClass(IDbContext dbContext, string equipmentclassid, string siteid)
	{
		string apiName = "SelectEquipmentClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectEquipmentClassSqlDatabase : _sqlSelectEquipmentClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTCLASSID", equipmentclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_EQUIPMENTCLASS", $"{equipmentclassid},{siteid}"));
		}
		Equipmentclass? result = ContextManager.DirectEntityQuery<Equipmentclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentclassid},{siteid}");
		}
		return result;
	}

	public static Equipmentclass SelectEquipmentClass4Update(IDbContext dbContext, string equipmentclassid, string siteid)
	{
		string apiName = "SelectEquipmentClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectEquipmentClass4UpdateSqlDatabase : _sqlSelectEquipmentClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTCLASSID", equipmentclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_EQUIPMENTCLASS", $"{equipmentclassid},{siteid}"));
		}
		Equipmentclass? result = ContextManager.DirectEntityQuery<Equipmentclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentclassid},{siteid}");
		}
		return result;
	}

	public static int UpsertEquipmentClass(IDbContext dbContext, RequestType requestType, Equipmentclass[] equipmentClassList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateEquipmentClassInternal(dbContext, equipmentClassList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateEquipmentClass(dbContext, equipmentClassList, optionSet, saveHist), 
			RequestType.DELETE => DeleteEquipmentClass(dbContext, equipmentClassList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteEquipmentClass(dbContext, equipmentClassList, optionSet, saveHist), 
			_ => RealDeleteEquipmentClass(dbContext, equipmentClassList, optionSet, saveHist), 
		};
	}

	private static int CreateEquipmentClassInternal(IDbContext dbContext, Equipmentclass[] equipmentClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("equipmentClassList", equipmentClassList);
		string text = "CreateEquipmentClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Equipmentclass> list = new List<Equipmentclass>();
		foreach (Equipmentclass obj in equipmentClassList)
		{
			Equipmentclass equipmentclass = new Equipmentclass();
			obj.CopyColumsTo(equipmentclass);
			equipmentclass.Activity = text;
			equipmentclass.CheckEntityUsable();
			obj.CopyCommonField(equipmentclass, systemTime, dbContext.Tid, isCreate: true);
			list.Add(equipmentclass);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateEquipmentClass(IDbContext dbContext, Equipmentclass[] equipmentClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("equipmentClassList", equipmentClassList);
		string text = "UpdateEquipmentClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Equipmentclass> list = new List<Equipmentclass>();
		foreach (Equipmentclass equipmentclass in equipmentClassList)
		{
			Equipmentclass equipmentClass4Update = GetEquipmentClass4Update(dbContext, equipmentclass.Equipmentclassid, equipmentclass.Siteid);
			if (equipmentClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Equipmentclass), $"{equipmentclass.Equipmentclassid},{equipmentclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Equipmentclass), $"{equipmentclass.Equipmentclassid},{equipmentclass.Siteid}", equipmentClass4Update.Isusable);
			string activity = equipmentClass4Update.Activity;
			string customactivity = equipmentClass4Update.Customactivity;
			string isusable = equipmentClass4Update.Isusable;
			DateTime? createtime = equipmentClass4Update.Createtime;
			string creator = equipmentClass4Update.Creator;
			equipmentclass.CopyColumsTo(equipmentClass4Update);
			equipmentClass4Update.Prevactivity = activity;
			equipmentClass4Update.Prevcustomactivity = customactivity;
			equipmentClass4Update.Creator = creator;
			equipmentClass4Update.Createtime = createtime;
			equipmentClass4Update.Isusable = isusable;
			equipmentClass4Update.Activity = text;
			equipmentclass.CopyCommonField(equipmentClass4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(equipmentClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteEquipmentClass(IDbContext dbContext, Equipmentclass[] equipmentClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("equipmentClassList", equipmentClassList);
		string text = "DeleteEquipmentClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Equipmentclass> list = new List<Equipmentclass>();
		foreach (Equipmentclass equipmentclass in equipmentClassList)
		{
			Equipmentclass equipmentClass4Update = GetEquipmentClass4Update(dbContext, equipmentclass.Equipmentclassid, equipmentclass.Siteid);
			if (equipmentClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Equipmentclass), $"{equipmentclass.Equipmentclassid},{equipmentclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Equipmentclass), $"{equipmentclass.Equipmentclassid},{equipmentclass.Siteid}", equipmentClass4Update.Isusable);
			equipmentClass4Update.Isusable = "UnUsable";
			equipmentclass.CopyCommonFieldUpdatePrev(equipmentClass4Update, systemTime, dbContext.Tid, text);
			equipmentclass.CopyExtensionCollection(equipmentClass4Update);
			list.Add(equipmentClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteEquipmentClass(IDbContext dbContext, Equipmentclass[] equipmentClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("equipmentClassList", equipmentClassList);
		string text = "UnDeleteEquipmentClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Equipmentclass> list = new List<Equipmentclass>();
		foreach (Equipmentclass equipmentclass in equipmentClassList)
		{
			Equipmentclass equipmentClass4Update = GetEquipmentClass4Update(dbContext, equipmentclass.Equipmentclassid, equipmentclass.Siteid);
			if (equipmentClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Equipmentclass), $"{equipmentclass.Equipmentclassid},{equipmentclass.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Equipmentclass), $"{equipmentclass.Equipmentclassid},{equipmentclass.Siteid}", equipmentClass4Update.Isusable);
			equipmentClass4Update.Isusable = "Usable";
			equipmentclass.CopyCommonFieldUpdatePrev(equipmentClass4Update, systemTime, dbContext.Tid, text);
			equipmentclass.CopyExtensionCollection(equipmentClass4Update);
			list.Add(equipmentClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteEquipmentClass(IDbContext dbContext, Equipmentclass[] equipmentClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("equipmentClassList", equipmentClassList);
		string text = "RealDeleteEquipmentClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Equipmentclass> list = new List<Equipmentclass>();
		foreach (Equipmentclass equipmentclass in equipmentClassList)
		{
			Equipmentclass equipmentClass4Update = GetEquipmentClass4Update(dbContext, equipmentclass.Equipmentclassid, equipmentclass.Siteid);
			if (equipmentClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Equipmentclass), $"{equipmentclass.Equipmentclassid},{equipmentclass.Siteid}");
			}
			equipmentclass.CopyCommonFieldUpdatePrev(equipmentClass4Update, systemTime, dbContext.Tid, text);
			equipmentclass.CopyExtensionCollection(equipmentClass4Update);
			list.Add(equipmentClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
