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
public class EQUIPMENTUSERREL
{
	private static string _sqlGetEquipmentUserRelSqlDatabase = "SELECT * FROM CIM_EQUIPMENTUSERREL WHERE EQUIPMENTID=@EQUIPMENTID AND USERID=@USERID AND SITEID=@SITEID";

	private static string _sqlGetEquipmentUserRel4UpdateSqlDatabase = "SELECT * FROM CIM_EQUIPMENTUSERREL WITH(UPDLOCK) WHERE EQUIPMENTID=@EQUIPMENTID AND USERID=@USERID AND SITEID=@SITEID";

	private static string _sqlSelectEquipmentUserRelSqlDatabase = "SELECT * FROM CIM_EQUIPMENTUSERREL WHERE EQUIPMENTID=@EQUIPMENTID AND USERID=@USERID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectEquipmentUserRel4UpdateSqlDatabase = "SELECT * FROM CIM_EQUIPMENTUSERREL WITH(UPDLOCK) WHERE EQUIPMENTID=@EQUIPMENTID AND USERID=@USERID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetEquipmentUserRelOracleDatabase = "SELECT * FROM CIM_EQUIPMENTUSERREL WHERE EQUIPMENTID=:EQUIPMENTID AND USERID=:USERID AND SITEID=:SITEID";

	private static string _sqlGetEquipmentUserRel4UpdateOracleDatabase = "SELECT * FROM CIM_EQUIPMENTUSERREL WHERE EQUIPMENTID=:EQUIPMENTID AND USERID=:USERID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectEquipmentUserRelOracleDatabase = "SELECT * FROM CIM_EQUIPMENTUSERREL WHERE EQUIPMENTID=:EQUIPMENTID AND USERID=:USERID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectEquipmentUserRel4UpdateOracleDatabase = "SELECT * FROM CIM_EQUIPMENTUSERREL WHERE EQUIPMENTID=:EQUIPMENTID AND USERID=:USERID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Equipmentuserrel);

	public static Equipmentuserrel GetEquipmentUserRel(IDbContext dbContext, string equipmentid, string userid, string siteid)
	{
		string apiName = "GetEquipmentUserRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentid},{userid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetEquipmentUserRelSqlDatabase : _sqlGetEquipmentUserRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_EQUIPMENTUSERREL", $"{equipmentid},{userid},{siteid}"));
		}
		Equipmentuserrel? result = ContextManager.DirectEntityQuery<Equipmentuserrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentid},{userid},{siteid}");
		}
		return result;
	}

	public static Equipmentuserrel GetEquipmentUserRel4Update(IDbContext dbContext, string equipmentid, string userid, string siteid)
	{
		string apiName = "GetEquipmentUserRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentid},{userid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetEquipmentUserRel4UpdateSqlDatabase : _sqlGetEquipmentUserRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_EQUIPMENTUSERREL", $"{equipmentid},{userid},{siteid}"));
		}
		Equipmentuserrel? result = ContextManager.DirectEntityQuery<Equipmentuserrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentid},{userid},{siteid}");
		}
		return result;
	}

	public static Equipmentuserrel SelectEquipmentUserRel(IDbContext dbContext, string equipmentid, string userid, string siteid)
	{
		string apiName = "SelectEquipmentUserRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentid},{userid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectEquipmentUserRelSqlDatabase : _sqlSelectEquipmentUserRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_EQUIPMENTUSERREL", $"{equipmentid},{userid},{siteid}"));
		}
		Equipmentuserrel? result = ContextManager.DirectEntityQuery<Equipmentuserrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentid},{userid},{siteid}");
		}
		return result;
	}

	public static Equipmentuserrel SelectEquipmentUserRel4Update(IDbContext dbContext, string equipmentid, string userid, string siteid)
	{
		string apiName = "SelectEquipmentUserRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentid},{userid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectEquipmentUserRel4UpdateSqlDatabase : _sqlSelectEquipmentUserRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_EQUIPMENTUSERREL", $"{equipmentid},{userid},{siteid}"));
		}
		Equipmentuserrel? result = ContextManager.DirectEntityQuery<Equipmentuserrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentid},{userid},{siteid}");
		}
		return result;
	}

	public static int UpsertEquipmentUserRel(IDbContext dbContext, RequestType requestType, Equipmentuserrel[] equipmentUserRelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateEquipmentUserRelInternal(dbContext, equipmentUserRelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateEquipmentUserRel(dbContext, equipmentUserRelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteEquipmentUserRel(dbContext, equipmentUserRelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteEquipmentUserRel(dbContext, equipmentUserRelList, optionSet, saveHist), 
			_ => RealDeleteEquipmentUserRel(dbContext, equipmentUserRelList, optionSet, saveHist), 
		};
	}

	private static int CreateEquipmentUserRelInternal(IDbContext dbContext, Equipmentuserrel[] equipmentUserRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("equipmentUserRelList", equipmentUserRelList);
		string text = "CreateEquipmentUserRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Equipmentuserrel> list = new List<Equipmentuserrel>();
		foreach (Equipmentuserrel obj in equipmentUserRelList)
		{
			Equipmentuserrel equipmentuserrel = new Equipmentuserrel();
			obj.CopyColumsTo(equipmentuserrel);
			equipmentuserrel.Activity = text;
			equipmentuserrel.CheckEntityUsable();
			obj.CopyCommonField(equipmentuserrel, systemTime, dbContext.Tid, isCreate: true);
			list.Add(equipmentuserrel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateEquipmentUserRel(IDbContext dbContext, Equipmentuserrel[] equipmentUserRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("equipmentUserRelList", equipmentUserRelList);
		string text = "UpdateEquipmentUserRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Equipmentuserrel> list = new List<Equipmentuserrel>();
		foreach (Equipmentuserrel equipmentuserrel in equipmentUserRelList)
		{
			Equipmentuserrel equipmentUserRel4Update = GetEquipmentUserRel4Update(dbContext, equipmentuserrel.Equipmentid, equipmentuserrel.Userid, equipmentuserrel.Siteid);
			if (equipmentUserRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Equipmentuserrel), $"{equipmentuserrel.Equipmentid},{equipmentuserrel.Userid},{equipmentuserrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Equipmentuserrel), $"{equipmentuserrel.Equipmentid},{equipmentuserrel.Userid},{equipmentuserrel.Siteid}", equipmentUserRel4Update.Isusable);
			string activity = equipmentUserRel4Update.Activity;
			string customactivity = equipmentUserRel4Update.Customactivity;
			string isusable = equipmentUserRel4Update.Isusable;
			DateTime? createtime = equipmentUserRel4Update.Createtime;
			string creator = equipmentUserRel4Update.Creator;
			equipmentuserrel.CopyColumsTo(equipmentUserRel4Update);
			equipmentUserRel4Update.Prevactivity = activity;
			equipmentUserRel4Update.Prevcustomactivity = customactivity;
			equipmentUserRel4Update.Creator = creator;
			equipmentUserRel4Update.Createtime = createtime;
			equipmentUserRel4Update.Isusable = isusable;
			equipmentUserRel4Update.Activity = text;
			equipmentuserrel.CopyCommonField(equipmentUserRel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(equipmentUserRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteEquipmentUserRel(IDbContext dbContext, Equipmentuserrel[] equipmentUserRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("equipmentUserRelList", equipmentUserRelList);
		string text = "DeleteEquipmentUserRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Equipmentuserrel> list = new List<Equipmentuserrel>();
		foreach (Equipmentuserrel equipmentuserrel in equipmentUserRelList)
		{
			Equipmentuserrel equipmentUserRel4Update = GetEquipmentUserRel4Update(dbContext, equipmentuserrel.Equipmentid, equipmentuserrel.Userid, equipmentuserrel.Siteid);
			if (equipmentUserRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Equipmentuserrel), $"{equipmentuserrel.Equipmentid},{equipmentuserrel.Userid},{equipmentuserrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Equipmentuserrel), $"{equipmentuserrel.Equipmentid},{equipmentuserrel.Userid},{equipmentuserrel.Siteid}", equipmentUserRel4Update.Isusable);
			equipmentUserRel4Update.Isusable = "UnUsable";
			equipmentuserrel.CopyCommonFieldUpdatePrev(equipmentUserRel4Update, systemTime, dbContext.Tid, text);
			equipmentuserrel.CopyExtensionCollection(equipmentUserRel4Update);
			list.Add(equipmentUserRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteEquipmentUserRel(IDbContext dbContext, Equipmentuserrel[] equipmentUserRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("equipmentUserRelList", equipmentUserRelList);
		string text = "UnDeleteEquipmentUserRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Equipmentuserrel> list = new List<Equipmentuserrel>();
		foreach (Equipmentuserrel equipmentuserrel in equipmentUserRelList)
		{
			Equipmentuserrel equipmentUserRel4Update = GetEquipmentUserRel4Update(dbContext, equipmentuserrel.Equipmentid, equipmentuserrel.Userid, equipmentuserrel.Siteid);
			if (equipmentUserRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Equipmentuserrel), $"{equipmentuserrel.Equipmentid},{equipmentuserrel.Userid},{equipmentuserrel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Equipmentuserrel), $"{equipmentuserrel.Equipmentid},{equipmentuserrel.Userid},{equipmentuserrel.Siteid}", equipmentUserRel4Update.Isusable);
			equipmentUserRel4Update.Isusable = "Usable";
			equipmentuserrel.CopyCommonFieldUpdatePrev(equipmentUserRel4Update, systemTime, dbContext.Tid, text);
			equipmentuserrel.CopyExtensionCollection(equipmentUserRel4Update);
			list.Add(equipmentUserRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteEquipmentUserRel(IDbContext dbContext, Equipmentuserrel[] equipmentUserRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("equipmentUserRelList", equipmentUserRelList);
		string text = "RealDeleteEquipmentUserRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Equipmentuserrel> list = new List<Equipmentuserrel>();
		foreach (Equipmentuserrel equipmentuserrel in equipmentUserRelList)
		{
			Equipmentuserrel equipmentUserRel4Update = GetEquipmentUserRel4Update(dbContext, equipmentuserrel.Equipmentid, equipmentuserrel.Userid, equipmentuserrel.Siteid);
			if (equipmentUserRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Equipmentuserrel), $"{equipmentuserrel.Equipmentid},{equipmentuserrel.Userid},{equipmentuserrel.Siteid}");
			}
			equipmentuserrel.CopyCommonFieldUpdatePrev(equipmentUserRel4Update, systemTime, dbContext.Tid, text);
			equipmentuserrel.CopyExtensionCollection(equipmentUserRel4Update);
			list.Add(equipmentUserRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
