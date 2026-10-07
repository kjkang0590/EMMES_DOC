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
public class EQUIPMENTDURABLEREL
{
	private static string _sqlGetEquipmentDurableRelSqlDatabase = "SELECT * FROM CIM_EQUIPMENTDURABLEREL WHERE EQUIPMENTID=@EQUIPMENTID AND DURABLEID=@DURABLEID AND SITEID=@SITEID";

	private static string _sqlGetEquipmentDurableRel4UpdateSqlDatabase = "SELECT * FROM CIM_EQUIPMENTDURABLEREL WITH(UPDLOCK) WHERE EQUIPMENTID=@EQUIPMENTID AND DURABLEID=@DURABLEID AND SITEID=@SITEID";

	private static string _sqlSelectEquipmentDurableRelSqlDatabase = "SELECT * FROM CIM_EQUIPMENTDURABLEREL WHERE EQUIPMENTID=@EQUIPMENTID AND DURABLEID=@DURABLEID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectEquipmentDurableRel4UpdateSqlDatabase = "SELECT * FROM CIM_EQUIPMENTDURABLEREL WITH(UPDLOCK) WHERE EQUIPMENTID=@EQUIPMENTID AND DURABLEID=@DURABLEID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetEquipmentDurableRelOracleDatabase = "SELECT * FROM CIM_EQUIPMENTDURABLEREL WHERE EQUIPMENTID=:EQUIPMENTID AND DURABLEID=:DURABLEID AND SITEID=:SITEID";

	private static string _sqlGetEquipmentDurableRel4UpdateOracleDatabase = "SELECT * FROM CIM_EQUIPMENTDURABLEREL WHERE EQUIPMENTID=:EQUIPMENTID AND DURABLEID=:DURABLEID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectEquipmentDurableRelOracleDatabase = "SELECT * FROM CIM_EQUIPMENTDURABLEREL WHERE EQUIPMENTID=:EQUIPMENTID AND DURABLEID=:DURABLEID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectEquipmentDurableRel4UpdateOracleDatabase = "SELECT * FROM CIM_EQUIPMENTDURABLEREL WHERE EQUIPMENTID=:EQUIPMENTID AND DURABLEID=:DURABLEID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Equipmentdurablerel);

	public static Equipmentdurablerel GetEquipmentDurableRel(IDbContext dbContext, string equipmentid, string durableid, string siteid)
	{
		string apiName = "GetEquipmentDurableRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentid},{durableid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetEquipmentDurableRelSqlDatabase : _sqlGetEquipmentDurableRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("DURABLEID", durableid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_EQUIPMENTDURABLEREL", $"{equipmentid},{durableid},{siteid}"));
		}
		Equipmentdurablerel? result = ContextManager.DirectEntityQuery<Equipmentdurablerel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentid},{durableid},{siteid}");
		}
		return result;
	}

	public static Equipmentdurablerel GetEquipmentDurableRel4Update(IDbContext dbContext, string equipmentid, string durableid, string siteid)
	{
		string apiName = "GetEquipmentDurableRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentid},{durableid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetEquipmentDurableRel4UpdateSqlDatabase : _sqlGetEquipmentDurableRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("DURABLEID", durableid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_EQUIPMENTDURABLEREL", $"{equipmentid},{durableid},{siteid}"));
		}
		Equipmentdurablerel? result = ContextManager.DirectEntityQuery<Equipmentdurablerel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentid},{durableid},{siteid}");
		}
		return result;
	}

	public static Equipmentdurablerel SelectEquipmentDurableRel(IDbContext dbContext, string equipmentid, string durableid, string siteid)
	{
		string apiName = "SelectEquipmentDurableRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentid},{durableid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectEquipmentDurableRelSqlDatabase : _sqlSelectEquipmentDurableRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("DURABLEID", durableid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_EQUIPMENTDURABLEREL", $"{equipmentid},{durableid},{siteid}"));
		}
		Equipmentdurablerel? result = ContextManager.DirectEntityQuery<Equipmentdurablerel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentid},{durableid},{siteid}");
		}
		return result;
	}

	public static Equipmentdurablerel SelectEquipmentDurableRel4Update(IDbContext dbContext, string equipmentid, string durableid, string siteid)
	{
		string apiName = "SelectEquipmentDurableRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentid},{durableid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectEquipmentDurableRel4UpdateSqlDatabase : _sqlSelectEquipmentDurableRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("DURABLEID", durableid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_EQUIPMENTDURABLEREL", $"{equipmentid},{durableid},{siteid}"));
		}
		Equipmentdurablerel? result = ContextManager.DirectEntityQuery<Equipmentdurablerel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentid},{durableid},{siteid}");
		}
		return result;
	}

	public static int UpsertEquipmentDurableRel(IDbContext dbContext, RequestType requestType, Equipmentdurablerel[] equipmentDurableRelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateEquipmentDurableRelInternal(dbContext, equipmentDurableRelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateEquipmentDurableRel(dbContext, equipmentDurableRelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteEquipmentDurableRel(dbContext, equipmentDurableRelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteEquipmentDurableRel(dbContext, equipmentDurableRelList, optionSet, saveHist), 
			_ => RealDeleteEquipmentDurableRel(dbContext, equipmentDurableRelList, optionSet, saveHist), 
		};
	}

	private static int CreateEquipmentDurableRelInternal(IDbContext dbContext, Equipmentdurablerel[] equipmentDurableRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("equipmentDurableRelList", equipmentDurableRelList);
		string text = "CreateEquipmentDurableRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Equipmentdurablerel> list = new List<Equipmentdurablerel>();
		foreach (Equipmentdurablerel obj in equipmentDurableRelList)
		{
			Equipmentdurablerel equipmentdurablerel = new Equipmentdurablerel();
			obj.CopyColumsTo(equipmentdurablerel);
			equipmentdurablerel.Activity = text;
			equipmentdurablerel.CheckEntityUsable();
			obj.CopyCommonField(equipmentdurablerel, systemTime, dbContext.Tid, isCreate: true);
			list.Add(equipmentdurablerel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateEquipmentDurableRel(IDbContext dbContext, Equipmentdurablerel[] equipmentDurableRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("equipmentDurableRelList", equipmentDurableRelList);
		string text = "UpdateEquipmentDurableRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Equipmentdurablerel> list = new List<Equipmentdurablerel>();
		foreach (Equipmentdurablerel equipmentdurablerel in equipmentDurableRelList)
		{
			Equipmentdurablerel equipmentDurableRel4Update = GetEquipmentDurableRel4Update(dbContext, equipmentdurablerel.Equipmentid, equipmentdurablerel.Durableid, equipmentdurablerel.Siteid);
			if (equipmentDurableRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Equipmentdurablerel), $"{equipmentdurablerel.Equipmentid},{equipmentdurablerel.Durableid},{equipmentdurablerel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Equipmentdurablerel), $"{equipmentdurablerel.Equipmentid},{equipmentdurablerel.Durableid},{equipmentdurablerel.Siteid}", equipmentDurableRel4Update.Isusable);
			string activity = equipmentDurableRel4Update.Activity;
			string customactivity = equipmentDurableRel4Update.Customactivity;
			string isusable = equipmentDurableRel4Update.Isusable;
			DateTime? createtime = equipmentDurableRel4Update.Createtime;
			string creator = equipmentDurableRel4Update.Creator;
			equipmentdurablerel.CopyColumsTo(equipmentDurableRel4Update);
			equipmentDurableRel4Update.Prevactivity = activity;
			equipmentDurableRel4Update.Prevcustomactivity = customactivity;
			equipmentDurableRel4Update.Creator = creator;
			equipmentDurableRel4Update.Createtime = createtime;
			equipmentDurableRel4Update.Isusable = isusable;
			equipmentDurableRel4Update.Activity = text;
			equipmentdurablerel.CopyCommonField(equipmentDurableRel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(equipmentDurableRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteEquipmentDurableRel(IDbContext dbContext, Equipmentdurablerel[] equipmentDurableRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("equipmentDurableRelList", equipmentDurableRelList);
		string text = "DeleteEquipmentDurableRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Equipmentdurablerel> list = new List<Equipmentdurablerel>();
		foreach (Equipmentdurablerel equipmentdurablerel in equipmentDurableRelList)
		{
			Equipmentdurablerel equipmentDurableRel4Update = GetEquipmentDurableRel4Update(dbContext, equipmentdurablerel.Equipmentid, equipmentdurablerel.Durableid, equipmentdurablerel.Siteid);
			if (equipmentDurableRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Equipmentdurablerel), $"{equipmentdurablerel.Equipmentid},{equipmentdurablerel.Durableid},{equipmentdurablerel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Equipmentdurablerel), $"{equipmentdurablerel.Equipmentid},{equipmentdurablerel.Durableid},{equipmentdurablerel.Siteid}", equipmentDurableRel4Update.Isusable);
			equipmentDurableRel4Update.Isusable = "UnUsable";
			equipmentdurablerel.CopyCommonFieldUpdatePrev(equipmentDurableRel4Update, systemTime, dbContext.Tid, text);
			equipmentdurablerel.CopyExtensionCollection(equipmentDurableRel4Update);
			list.Add(equipmentDurableRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteEquipmentDurableRel(IDbContext dbContext, Equipmentdurablerel[] equipmentDurableRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("equipmentDurableRelList", equipmentDurableRelList);
		string text = "UnDeleteEquipmentDurableRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Equipmentdurablerel> list = new List<Equipmentdurablerel>();
		foreach (Equipmentdurablerel equipmentdurablerel in equipmentDurableRelList)
		{
			Equipmentdurablerel equipmentDurableRel4Update = GetEquipmentDurableRel4Update(dbContext, equipmentdurablerel.Equipmentid, equipmentdurablerel.Durableid, equipmentdurablerel.Siteid);
			if (equipmentDurableRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Equipmentdurablerel), $"{equipmentdurablerel.Equipmentid},{equipmentdurablerel.Durableid},{equipmentdurablerel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Equipmentdurablerel), $"{equipmentdurablerel.Equipmentid},{equipmentdurablerel.Durableid},{equipmentdurablerel.Siteid}", equipmentDurableRel4Update.Isusable);
			equipmentDurableRel4Update.Isusable = "Usable";
			equipmentdurablerel.CopyCommonFieldUpdatePrev(equipmentDurableRel4Update, systemTime, dbContext.Tid, text);
			equipmentdurablerel.CopyExtensionCollection(equipmentDurableRel4Update);
			list.Add(equipmentDurableRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteEquipmentDurableRel(IDbContext dbContext, Equipmentdurablerel[] equipmentDurableRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("equipmentDurableRelList", equipmentDurableRelList);
		string text = "RealDeleteEquipmentDurableRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Equipmentdurablerel> list = new List<Equipmentdurablerel>();
		foreach (Equipmentdurablerel equipmentdurablerel in equipmentDurableRelList)
		{
			Equipmentdurablerel equipmentDurableRel4Update = GetEquipmentDurableRel4Update(dbContext, equipmentdurablerel.Equipmentid, equipmentdurablerel.Durableid, equipmentdurablerel.Siteid);
			if (equipmentDurableRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Equipmentdurablerel), $"{equipmentdurablerel.Equipmentid},{equipmentdurablerel.Durableid},{equipmentdurablerel.Siteid}");
			}
			equipmentdurablerel.CopyCommonFieldUpdatePrev(equipmentDurableRel4Update, systemTime, dbContext.Tid, text);
			equipmentdurablerel.CopyExtensionCollection(equipmentDurableRel4Update);
			list.Add(equipmentDurableRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
