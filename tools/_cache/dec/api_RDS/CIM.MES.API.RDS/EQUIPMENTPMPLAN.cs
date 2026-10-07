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
public class EQUIPMENTPMPLAN
{
	private static string _sqlGetEquipmentPMPlanSqlDatabase = "SELECT * FROM CIM_EQUIPMENTPMPLAN WHERE EQUIPMENTID=@EQUIPMENTID AND CHECKTYPE=@CHECKTYPE AND CHECKSTARTDATE=@CHECKSTARTDATE AND SITEID=@SITEID";

	private static string _sqlGetEquipmentPMPlan4UpdateSqlDatabase = "SELECT * FROM CIM_EQUIPMENTPMPLAN WITH(UPDLOCK) WHERE EQUIPMENTID=@EQUIPMENTID AND CHECKTYPE=@CHECKTYPE AND CHECKSTARTDATE=@CHECKSTARTDATE AND SITEID=@SITEID";

	private static string _sqlSelectEquipmentPMPlanSqlDatabase = "SELECT * FROM CIM_EQUIPMENTPMPLAN WHERE EQUIPMENTID=@EQUIPMENTID AND CHECKTYPE=@CHECKTYPE AND CHECKSTARTDATE=@CHECKSTARTDATE AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectEquipmentPMPlan4UpdateSqlDatabase = "SELECT * FROM CIM_EQUIPMENTPMPLAN WITH(UPDLOCK) WHERE EQUIPMENTID=@EQUIPMENTID AND CHECKTYPE=@CHECKTYPE AND CHECKSTARTDATE=@CHECKSTARTDATE AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetEquipmentPMPlanOracleDatabase = "SELECT * FROM CIM_EQUIPMENTPMPLAN WHERE EQUIPMENTID=:EQUIPMENTID AND CHECKTYPE=:CHECKTYPE AND CHECKSTARTDATE=:CHECKSTARTDATE AND SITEID=:SITEID";

	private static string _sqlGetEquipmentPMPlan4UpdateOracleDatabase = "SELECT * FROM CIM_EQUIPMENTPMPLAN WHERE EQUIPMENTID=:EQUIPMENTID AND CHECKTYPE=:CHECKTYPE AND CHECKSTARTDATE=:CHECKSTARTDATE AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectEquipmentPMPlanOracleDatabase = "SELECT * FROM CIM_EQUIPMENTPMPLAN WHERE EQUIPMENTID=:EQUIPMENTID AND CHECKTYPE=:CHECKTYPE AND CHECKSTARTDATE=:CHECKSTARTDATE AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectEquipmentPMPlan4UpdateOracleDatabase = "SELECT * FROM CIM_EQUIPMENTPMPLAN WHERE EQUIPMENTID=:EQUIPMENTID AND CHECKTYPE=:CHECKTYPE AND CHECKSTARTDATE=:CHECKSTARTDATE AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Equipmentpmplan);

	public static Equipmentpmplan GetEquipmentPMPlan(IDbContext dbContext, string equipmentid, string checktype, DateTime checkstartdate, string siteid)
	{
		string apiName = "GetEquipmentPMPlan";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentid},{checktype},{checkstartdate},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetEquipmentPMPlanSqlDatabase : _sqlGetEquipmentPMPlanOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("CHECKTYPE", checktype, typeOfThis));
		list.Add(dbContext.CreateParameter("CHECKSTARTDATE", checkstartdate, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_EQUIPMENTPMPLAN", $"{equipmentid},{checktype},{checkstartdate},{siteid}"));
		}
		Equipmentpmplan result = ContextManager.DirectEntityQuery<Equipmentpmplan>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentid},{checktype},{checkstartdate},{siteid}");
		}
		return result;
	}

	public static Equipmentpmplan GetEquipmentPMPlan4Update(IDbContext dbContext, string equipmentid, string checktype, DateTime checkstartdate, string siteid)
	{
		string apiName = "GetEquipmentPMPlan4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentid},{checktype},{checkstartdate},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetEquipmentPMPlan4UpdateSqlDatabase : _sqlGetEquipmentPMPlan4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("CHECKTYPE", checktype, typeOfThis));
		list.Add(dbContext.CreateParameter("CHECKSTARTDATE", checkstartdate, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_EQUIPMENTPMPLAN", $"{equipmentid},{checktype},{checkstartdate},{siteid}"));
		}
		Equipmentpmplan result = ContextManager.DirectEntityQuery<Equipmentpmplan>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentid},{checktype},{checkstartdate},{siteid}");
		}
		return result;
	}

	public static Equipmentpmplan SelectEquipmentPMPlan(IDbContext dbContext, string equipmentid, string checktype, DateTime checkstartdate, string siteid)
	{
		string apiName = "SelectEquipmentPMPlan";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentid},{checktype},{checkstartdate},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectEquipmentPMPlanSqlDatabase : _sqlSelectEquipmentPMPlanOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("CHECKTYPE", checktype, typeOfThis));
		list.Add(dbContext.CreateParameter("CHECKSTARTDATE", checkstartdate, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_EQUIPMENTPMPLAN", $"{equipmentid},{checktype},{checkstartdate},{siteid}"));
		}
		Equipmentpmplan result = ContextManager.DirectEntityQuery<Equipmentpmplan>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentid},{checktype},{checkstartdate},{siteid}");
		}
		return result;
	}

	public static Equipmentpmplan SelectEquipmentPMPlan4Update(IDbContext dbContext, string equipmentid, string checktype, DateTime checkstartdate, string siteid)
	{
		string apiName = "SelectEquipmentPMPlan4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentid},{checktype},{checkstartdate},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectEquipmentPMPlan4UpdateSqlDatabase : _sqlSelectEquipmentPMPlan4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("CHECKTYPE", checktype, typeOfThis));
		list.Add(dbContext.CreateParameter("CHECKSTARTDATE", checkstartdate, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_EQUIPMENTPMPLAN", $"{equipmentid},{checktype},{checkstartdate},{siteid}"));
		}
		Equipmentpmplan result = ContextManager.DirectEntityQuery<Equipmentpmplan>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentid},{checktype},{checkstartdate},{siteid}");
		}
		return result;
	}

	public static int UpsertEquipmentPMPlan(IDbContext dbContext, RequestType requestType, Equipmentpmplan[] equipmentPMPlanList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateEquipmentPMPlanInternal(dbContext, equipmentPMPlanList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateEquipmentPMPlan(dbContext, equipmentPMPlanList, optionSet, saveHist), 
			RequestType.DELETE => DeleteEquipmentPMPlan(dbContext, equipmentPMPlanList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteEquipmentPMPlan(dbContext, equipmentPMPlanList, optionSet, saveHist), 
			_ => RealDeleteEquipmentPMPlan(dbContext, equipmentPMPlanList, optionSet, saveHist), 
		};
	}

	private static int CreateEquipmentPMPlanInternal(IDbContext dbContext, Equipmentpmplan[] equipmentPMPlanList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("equipmentPMPlanList", equipmentPMPlanList);
		string text = "CreateEquipmentPMPlan";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Equipmentpmplan> list = new List<Equipmentpmplan>();
		foreach (Equipmentpmplan obj in equipmentPMPlanList)
		{
			Equipmentpmplan equipmentpmplan = new Equipmentpmplan();
			obj.CopyColumsTo(equipmentpmplan);
			equipmentpmplan.Activity = text;
			equipmentpmplan.CheckEntityUsable();
			obj.CopyCommonField(equipmentpmplan, systemTime, dbContext.Tid, isCreate: true);
			list.Add(equipmentpmplan);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateEquipmentPMPlan(IDbContext dbContext, Equipmentpmplan[] equipmentPMPlanList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("equipmentPMPlanList", equipmentPMPlanList);
		string text = "UpdateEquipmentPMPlan";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Equipmentpmplan> list = new List<Equipmentpmplan>();
		foreach (Equipmentpmplan equipmentpmplan in equipmentPMPlanList)
		{
			Equipmentpmplan equipmentPMPlan4Update = GetEquipmentPMPlan4Update(dbContext, equipmentpmplan.Equipmentid, equipmentpmplan.Checktype, equipmentpmplan.Checkstartdate, equipmentpmplan.Siteid);
			if (equipmentPMPlan4Update == null)
			{
				throw new EntityNotFoundException(typeof(Equipmentpmplan), $"{equipmentpmplan.Equipmentid},{equipmentpmplan.Checktype},{equipmentpmplan.Checkstartdate},{equipmentpmplan.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Equipmentpmplan), $"{equipmentpmplan.Equipmentid},{equipmentpmplan.Checktype},{equipmentpmplan.Checkstartdate},{equipmentpmplan.Siteid}", equipmentPMPlan4Update.Isusable);
			string activity = equipmentPMPlan4Update.Activity;
			string customactivity = equipmentPMPlan4Update.Customactivity;
			string isusable = equipmentPMPlan4Update.Isusable;
			DateTime? createtime = equipmentPMPlan4Update.Createtime;
			string creator = equipmentPMPlan4Update.Creator;
			equipmentpmplan.CopyColumsTo(equipmentPMPlan4Update);
			equipmentPMPlan4Update.Prevactivity = activity;
			equipmentPMPlan4Update.Prevcustomactivity = customactivity;
			equipmentPMPlan4Update.Creator = creator;
			equipmentPMPlan4Update.Createtime = createtime;
			equipmentPMPlan4Update.Isusable = isusable;
			equipmentPMPlan4Update.Activity = text;
			equipmentpmplan.CopyCommonField(equipmentPMPlan4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(equipmentPMPlan4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteEquipmentPMPlan(IDbContext dbContext, Equipmentpmplan[] equipmentPMPlanList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("equipmentPMPlanList", equipmentPMPlanList);
		string text = "DeleteEquipmentPMPlan";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Equipmentpmplan> list = new List<Equipmentpmplan>();
		foreach (Equipmentpmplan equipmentpmplan in equipmentPMPlanList)
		{
			Equipmentpmplan equipmentPMPlan4Update = GetEquipmentPMPlan4Update(dbContext, equipmentpmplan.Equipmentid, equipmentpmplan.Checktype, equipmentpmplan.Checkstartdate, equipmentpmplan.Siteid);
			if (equipmentPMPlan4Update == null)
			{
				throw new EntityNotFoundException(typeof(Equipmentpmplan), $"{equipmentpmplan.Equipmentid},{equipmentpmplan.Checktype},{equipmentpmplan.Checkstartdate},{equipmentpmplan.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Equipmentpmplan), $"{equipmentpmplan.Equipmentid},{equipmentpmplan.Checktype},{equipmentpmplan.Checkstartdate},{equipmentpmplan.Siteid}", equipmentPMPlan4Update.Isusable);
			equipmentPMPlan4Update.Isusable = "UnUsable";
			equipmentpmplan.CopyCommonFieldUpdatePrev(equipmentPMPlan4Update, systemTime, dbContext.Tid, text);
			equipmentpmplan.CopyExtensionCollection(equipmentPMPlan4Update);
			list.Add(equipmentPMPlan4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteEquipmentPMPlan(IDbContext dbContext, Equipmentpmplan[] equipmentPMPlanList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("equipmentPMPlanList", equipmentPMPlanList);
		string text = "UnDeleteEquipmentPMPlan";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Equipmentpmplan> list = new List<Equipmentpmplan>();
		foreach (Equipmentpmplan equipmentpmplan in equipmentPMPlanList)
		{
			Equipmentpmplan equipmentPMPlan4Update = GetEquipmentPMPlan4Update(dbContext, equipmentpmplan.Equipmentid, equipmentpmplan.Checktype, equipmentpmplan.Checkstartdate, equipmentpmplan.Siteid);
			if (equipmentPMPlan4Update == null)
			{
				throw new EntityNotFoundException(typeof(Equipmentpmplan), $"{equipmentpmplan.Equipmentid},{equipmentpmplan.Checktype},{equipmentpmplan.Checkstartdate},{equipmentpmplan.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Equipmentpmplan), $"{equipmentpmplan.Equipmentid},{equipmentpmplan.Checktype},{equipmentpmplan.Checkstartdate},{equipmentpmplan.Siteid}", equipmentPMPlan4Update.Isusable);
			equipmentPMPlan4Update.Isusable = "Usable";
			equipmentpmplan.CopyCommonFieldUpdatePrev(equipmentPMPlan4Update, systemTime, dbContext.Tid, text);
			equipmentpmplan.CopyExtensionCollection(equipmentPMPlan4Update);
			list.Add(equipmentPMPlan4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteEquipmentPMPlan(IDbContext dbContext, Equipmentpmplan[] equipmentPMPlanList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("equipmentPMPlanList", equipmentPMPlanList);
		string text = "RealDeleteEquipmentPMPlan";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Equipmentpmplan> list = new List<Equipmentpmplan>();
		foreach (Equipmentpmplan equipmentpmplan in equipmentPMPlanList)
		{
			Equipmentpmplan equipmentPMPlan4Update = GetEquipmentPMPlan4Update(dbContext, equipmentpmplan.Equipmentid, equipmentpmplan.Checktype, equipmentpmplan.Checkstartdate, equipmentpmplan.Siteid);
			if (equipmentPMPlan4Update == null)
			{
				throw new EntityNotFoundException(typeof(Equipmentpmplan), $"{equipmentpmplan.Equipmentid},{equipmentpmplan.Checktype},{equipmentpmplan.Checkstartdate},{equipmentpmplan.Siteid}");
			}
			equipmentpmplan.CopyCommonFieldUpdatePrev(equipmentPMPlan4Update, systemTime, dbContext.Tid, text);
			equipmentpmplan.CopyExtensionCollection(equipmentPMPlan4Update);
			list.Add(equipmentPMPlan4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
