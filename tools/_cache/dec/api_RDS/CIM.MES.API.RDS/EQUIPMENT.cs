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
public class EQUIPMENT
{
	private static string _sqlGetEquipmentSqlDatabase = "SELECT * FROM CIM_EQUIPMENT WHERE EQUIPMENTID=@EQUIPMENTID AND SITEID=@SITEID";

	private static string _sqlGetEquipment4UpdateSqlDatabase = "SELECT * FROM CIM_EQUIPMENT WITH(UPDLOCK) WHERE EQUIPMENTID=@EQUIPMENTID AND SITEID=@SITEID";

	private static string _sqlSelectEquipmentSqlDatabase = "SELECT * FROM CIM_EQUIPMENT WHERE EQUIPMENTID=@EQUIPMENTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectEquipment4UpdateSqlDatabase = "SELECT * FROM CIM_EQUIPMENT WITH(UPDLOCK) WHERE EQUIPMENTID=@EQUIPMENTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetEquipmentOracleDatabase = "SELECT * FROM CIM_EQUIPMENT WHERE EQUIPMENTID=:EQUIPMENTID AND SITEID=:SITEID";

	private static string _sqlGetEquipment4UpdateOracleDatabase = "SELECT * FROM CIM_EQUIPMENT WHERE EQUIPMENTID=:EQUIPMENTID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectEquipmentOracleDatabase = "SELECT * FROM CIM_EQUIPMENT WHERE EQUIPMENTID=:EQUIPMENTID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectEquipment4UpdateOracleDatabase = "SELECT * FROM CIM_EQUIPMENT WHERE EQUIPMENTID=:EQUIPMENTID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Equipment);

	private static string _sqlSelectEquipmentList4UpdateSqlDatabase = "SELECT * FROM CIM_EQUIPMENT WITH(UPDLOCK) WHERE EQUIPMENTID IN (&EQUIPMENTIDLIST) AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectEquipmentList4UpdateOracleDatabase = "SELECT * FROM CIM_EQUIPMENT WHERE EQUIPMENTID IN (&EQUIPMENTIDLIST) AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	public static int ChangeEquipmentState(IDbContext dbContext, Equipment[] equipmentList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("equipmentList", equipmentList);
		string text = "ChangeEquipmentState";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Equipment> list = new List<Equipment>();
		string siteid = equipmentList[0].Siteid;
		Equipment[] equipmentList2 = SelectEquipmentList4Update(dbContext, equipmentList, siteid).ToArray();
		foreach (Equipment equipment in equipmentList)
		{
			DateTime modifytime = equipment.Modifytime;
			string state = equipment.State;
			string operationmode = equipment.Operationmode;
			string processstate = equipment.Processstate;
			string controlmode = equipment.Controlmode;
			_ = equipment.Statetime;
			_ = equipment.Operationmodetime;
			_ = equipment.Processstatetime;
			_ = equipment.Controlmodetime;
			ParamChecker.ArgumentNotNull("Equipmentid", equipment.Equipmentid);
			ParamChecker.ArgumentNotNull("Siteid", equipment.Siteid);
			Equipment equipment2 = FindEquipment(equipmentList2, equipment.Equipmentid);
			if (equipment2 == null)
			{
				throw new EntityNotFoundException(typeof(Equipment), $"{equipment.Equipmentid},{siteid}");
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", equipment2);
			}
			if (!string.IsNullOrEmpty(state) && equipment2.State != state)
			{
				equipment2.Prevstate = equipment2.State;
				equipment2.State = state;
				equipment2.Prevstatetime = equipment2.Statetime;
				equipment2.Statetime = EntityHelper.FirstNotNull<DateTime?>(equipment.Statetime, modifytime);
			}
			if (!string.IsNullOrEmpty(controlmode) && equipment2.Controlmode != controlmode)
			{
				equipment2.Prevcontrolmode = equipment2.Controlmode;
				equipment2.Controlmode = controlmode;
				equipment2.Prevcontrolmodetime = equipment2.Controlmodetime;
				equipment2.Controlmodetime = EntityHelper.FirstNotNull<DateTime?>(equipment.Controlmodetime, modifytime);
			}
			if (!string.IsNullOrEmpty(processstate) && equipment2.Processstate != processstate)
			{
				equipment2.Prevprocessstate = equipment2.Processstate;
				equipment2.Processstate = processstate;
				equipment2.Prevprocessstatetime = equipment2.Processstatetime;
				equipment2.Processstatetime = EntityHelper.FirstNotNull<DateTime?>(equipment.Processstatetime, modifytime);
			}
			if (!string.IsNullOrEmpty(operationmode) && equipment2.Operationmode != operationmode)
			{
				equipment2.Prevoperationmode = equipment2.Operationmode;
				equipment2.Operationmode = operationmode;
				equipment2.Prevoperationmodetime = equipment2.Operationmodetime;
				equipment2.Operationmodetime = EntityHelper.FirstNotNull<DateTime?>(equipment.Operationmodetime, modifytime);
			}
			equipment.CopyCommonFieldUpdatePrev(equipment2, systemTime, tid, text);
			equipment.CopyExtensionCollection(equipment2);
			list.Add(equipment2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", equipment2);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static Equipment GetEquipment(IDbContext dbContext, string equipmentid, string siteid)
	{
		string apiName = "GetEquipment";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetEquipmentSqlDatabase : _sqlGetEquipmentOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_EQUIPMENT", $"{equipmentid},{siteid}"));
		}
		Equipment? result = ContextManager.DirectEntityQuery<Equipment>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentid},{siteid}");
		}
		return result;
	}

	public static Equipment GetEquipment4Update(IDbContext dbContext, string equipmentid, string siteid)
	{
		string apiName = "GetEquipment4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetEquipment4UpdateSqlDatabase : _sqlGetEquipment4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_EQUIPMENT", $"{equipmentid},{siteid}"));
		}
		Equipment? result = ContextManager.DirectEntityQuery<Equipment>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentid},{siteid}");
		}
		return result;
	}

	public static Equipment SelectEquipment(IDbContext dbContext, string equipmentid, string siteid)
	{
		string apiName = "SelectEquipment";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectEquipmentSqlDatabase : _sqlSelectEquipmentOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_EQUIPMENT", $"{equipmentid},{siteid}"));
		}
		Equipment? result = ContextManager.DirectEntityQuery<Equipment>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentid},{siteid}");
		}
		return result;
	}

	public static Equipment SelectEquipment4Update(IDbContext dbContext, string equipmentid, string siteid)
	{
		string apiName = "SelectEquipment4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectEquipment4UpdateSqlDatabase : _sqlSelectEquipment4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_EQUIPMENT", $"{equipmentid},{siteid}"));
		}
		Equipment? result = ContextManager.DirectEntityQuery<Equipment>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentid},{siteid}");
		}
		return result;
	}

	public static IList<Equipment> SelectEquipmentList4Update(IDbContext dbContext, Equipment[] equipmentList, string siteId)
	{
		string apiName = "SelectEquipmentList4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentList.Length},{siteId}");
		}
		string text = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectEquipmentList4UpdateSqlDatabase : _sqlSelectEquipmentList4UpdateOracleDatabase);
		text = text.Replace("&EQUIPMENTIDLIST", EntityHelper.ConcatString4InClause(ExtractIdOrderBy(equipmentList)));
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_EQUIPMENT", $"{equipmentList.Length},{siteId}"));
		}
		IList<Equipment> result = ContextManager.DirectEntityQuery<Equipment>(dbContext, text, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentList.Length},{siteId}");
		}
		return result;
	}

	public static int UpsertEquipment(IDbContext dbContext, RequestType requestType, Equipment[] equipmentList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateEquipmentInternal(dbContext, equipmentList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateEquipment(dbContext, equipmentList, optionSet, saveHist), 
			RequestType.DELETE => DeleteEquipment(dbContext, equipmentList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteEquipment(dbContext, equipmentList, optionSet, saveHist), 
			_ => RealDeleteEquipment(dbContext, equipmentList, optionSet, saveHist), 
		};
	}

	private static int CreateEquipmentInternal(IDbContext dbContext, Equipment[] equipmentList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("equipmentList", equipmentList);
		string text = "CreateEquipment";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Equipment> list = new List<Equipment>();
		foreach (Equipment obj in equipmentList)
		{
			Equipment equipment = new Equipment();
			obj.CopyColumsTo(equipment);
			equipment.Activity = text;
			equipment.CheckEntityUsable();
			obj.CopyCommonField(equipment, systemTime, dbContext.Tid, isCreate: true);
			list.Add(equipment);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateEquipment(IDbContext dbContext, Equipment[] equipmentList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("equipmentList", equipmentList);
		string text = "UpdateEquipment";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Equipment> list = new List<Equipment>();
		foreach (Equipment equipment in equipmentList)
		{
			Equipment equipment4Update = GetEquipment4Update(dbContext, equipment.Equipmentid, equipment.Siteid);
			if (equipment4Update == null)
			{
				throw new EntityNotFoundException(typeof(Equipment), $"{equipment.Equipmentid},{equipment.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Equipment), $"{equipment.Equipmentid},{equipment.Siteid}", equipment4Update.Isusable);
			string activity = equipment4Update.Activity;
			string customactivity = equipment4Update.Customactivity;
			string isusable = equipment4Update.Isusable;
			DateTime? createtime = equipment4Update.Createtime;
			string creator = equipment4Update.Creator;
			equipment.CopyColumsTo(equipment4Update);
			equipment4Update.Prevactivity = activity;
			equipment4Update.Prevcustomactivity = customactivity;
			equipment4Update.Creator = creator;
			equipment4Update.Createtime = createtime;
			equipment4Update.Isusable = isusable;
			equipment4Update.Activity = text;
			equipment.CopyCommonField(equipment4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(equipment4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteEquipment(IDbContext dbContext, Equipment[] equipmentList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("equipmentList", equipmentList);
		string text = "DeleteEquipment";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Equipment> list = new List<Equipment>();
		foreach (Equipment equipment in equipmentList)
		{
			Equipment equipment4Update = GetEquipment4Update(dbContext, equipment.Equipmentid, equipment.Siteid);
			if (equipment4Update == null)
			{
				throw new EntityNotFoundException(typeof(Equipment), $"{equipment.Equipmentid},{equipment.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Equipment), $"{equipment.Equipmentid},{equipment.Siteid}", equipment4Update.Isusable);
			equipment4Update.Isusable = "UnUsable";
			equipment.CopyCommonFieldUpdatePrev(equipment4Update, systemTime, dbContext.Tid, text);
			equipment.CopyExtensionCollection(equipment4Update);
			list.Add(equipment4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteEquipment(IDbContext dbContext, Equipment[] equipmentList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("equipmentList", equipmentList);
		string text = "UnDeleteEquipment";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Equipment> list = new List<Equipment>();
		foreach (Equipment equipment in equipmentList)
		{
			Equipment equipment4Update = GetEquipment4Update(dbContext, equipment.Equipmentid, equipment.Siteid);
			if (equipment4Update == null)
			{
				throw new EntityNotFoundException(typeof(Equipment), $"{equipment.Equipmentid},{equipment.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Equipment), $"{equipment.Equipmentid},{equipment.Siteid}", equipment4Update.Isusable);
			equipment4Update.Isusable = "Usable";
			equipment.CopyCommonFieldUpdatePrev(equipment4Update, systemTime, dbContext.Tid, text);
			equipment.CopyExtensionCollection(equipment4Update);
			list.Add(equipment4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteEquipment(IDbContext dbContext, Equipment[] equipmentList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("equipmentList", equipmentList);
		string text = "RealDeleteEquipment";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Equipment> list = new List<Equipment>();
		foreach (Equipment equipment in equipmentList)
		{
			Equipment equipment4Update = GetEquipment4Update(dbContext, equipment.Equipmentid, equipment.Siteid);
			if (equipment4Update == null)
			{
				throw new EntityNotFoundException(typeof(Equipment), $"{equipment.Equipmentid},{equipment.Siteid}");
			}
			equipment.CopyCommonFieldUpdatePrev(equipment4Update, systemTime, dbContext.Tid, text);
			equipment.CopyExtensionCollection(equipment4Update);
			list.Add(equipment4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	internal static string[] ExtractIdOrderBy(Equipment[] equipmentList)
	{
		return (from p in equipmentList
			select p.Equipmentid into id
			orderby id
			select id).ToArray();
	}

	public static Equipment FindEquipment(Equipment[] equipmentList, string equipmentId)
	{
		return equipmentList?.FirstOrDefault((Equipment item) => item.Equipmentid == equipmentId);
	}
}
