using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.POS;

[MESAPI]
public class MATERIALLOTPORTREL
{
	private static string _sqlGetMaterialLotPortRelSqlDatabase = "SELECT * FROM CIM_MATERIALLOTPORTREL WHERE MATERIALLOTID=@MATERIALLOTID AND EQUIPMENTID=@EQUIPMENTID AND PORTID=@PORTID AND SITEID=@SITEID";

	private static string _sqlGetMaterialLotPortRel4UpdateSqlDatabase = "SELECT * FROM CIM_MATERIALLOTPORTREL WITH(UPDLOCK) WHERE MATERIALLOTID=@MATERIALLOTID AND EQUIPMENTID=@EQUIPMENTID AND PORTID=@PORTID AND SITEID=@SITEID";

	private static string _sqlSelectMaterialLotPortRelSqlDatabase = "SELECT * FROM CIM_MATERIALLOTPORTREL WHERE MATERIALLOTID=@MATERIALLOTID AND EQUIPMENTID=@EQUIPMENTID AND PORTID=@PORTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMaterialLotPortRel4UpdateSqlDatabase = "SELECT * FROM CIM_MATERIALLOTPORTREL WITH(UPDLOCK) WHERE MATERIALLOTID=@MATERIALLOTID AND EQUIPMENTID=@EQUIPMENTID AND PORTID=@PORTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetMaterialLotPortRelOracleDatabase = "SELECT * FROM CIM_MATERIALLOTPORTREL WHERE MATERIALLOTID=:MATERIALLOTID AND EQUIPMENTID=:EQUIPMENTID AND PORTID=:PORTID AND SITEID=:SITEID";

	private static string _sqlGetMaterialLotPortRel4UpdateOracleDatabase = "SELECT * FROM CIM_MATERIALLOTPORTREL WHERE MATERIALLOTID=:MATERIALLOTID AND EQUIPMENTID=:EQUIPMENTID AND PORTID=:PORTID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectMaterialLotPortRelOracleDatabase = "SELECT * FROM CIM_MATERIALLOTPORTREL WHERE MATERIALLOTID=:MATERIALLOTID AND EQUIPMENTID=:EQUIPMENTID AND PORTID=:PORTID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMaterialLotPortRel4UpdateOracleDatabase = "SELECT * FROM CIM_MATERIALLOTPORTREL WHERE MATERIALLOTID=:MATERIALLOTID AND EQUIPMENTID=:EQUIPMENTID AND PORTID=:PORTID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Materiallotportrel);

	private static string _sqlSelectMaterialLotPortRelListByEquipmentIdSqlDatabase = "SELECT * FROM CIM_MATERIALLOTPORTREL WHERE EQUIPMENTID=@EQUIPMENTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMaterialLotPortRelListByEquipmentIdOracleDatabase = "SELECT * FROM CIM_MATERIALLOTPORTREL WHERE EQUIPMENTID=:EQUIPMENTID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMaterialLotPortRelListByEquipmentPortIdSqlDatabase = "SELECT * FROM CIM_MATERIALLOTPORTREL WHERE EQUIPMENTID=@EQUIPMENTID AND PORTID=@PORTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMaterialLotPortRelListByEquipmentPortId4UpdateSqlDatabase = "SELECT * FROM CIM_MATERIALLOTPORTREL WITH(UPDLOCK) WHERE EQUIPMENTID=@EQUIPMENTID AND PORTID=@PORTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMaterialLotPortRelListByEquipmentPortIdOracleDatabase = "SELECT * FROM CIM_MATERIALLOTPORTREL WHERE EQUIPMENTID=:EQUIPMENTID AND PORTID=:PORTID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMaterialLotPortRelListByEquipmentPortId4UpdateOracleDatabase = "SELECT * FROM CIM_MATERIALLOTPORTREL WHERE EQUIPMENTID=:EQUIPMENTID AND PORTID=:PORTID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static string _sqlSelectMaterialLotPortRelListByMaterialLotIdSqlDatabase = "SELECT * FROM CIM_MATERIALLOTPORTREL WHERE MATERIALLOTID=@MATERIALLOTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMaterialLotPortRelListByMaterialLotId4UpdateSqlDatabase = "SELECT * FROM CIM_MATERIALLOTPORTREL WITH(UPDLOCK) WHERE MATERIALLOTID=@MATERIALLOTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMaterialLotPortRelListByMaterialLotIdOracleDatabase = "SELECT * FROM CIM_MATERIALLOTPORTREL WHERE MATERIALLOTID=:MATERIALLOTID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMaterialLotPortRelListByMaterialLotId4UpdateOracleDatabase = "SELECT * FROM CIM_MATERIALLOTPORTREL WHERE MATERIALLOTID=:MATERIALLOTID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	public static Materiallotportrel GetMaterialLotPortRel(IDbContext dbContext, string materiallotid, string equipmentid, string portid, string siteid)
	{
		string apiName = "GetMaterialLotPortRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{materiallotid},{equipmentid},{portid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetMaterialLotPortRelSqlDatabase : _sqlGetMaterialLotPortRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MATERIALLOTID", materiallotid, typeOfThis));
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("PORTID", portid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MATERIALLOTPORTREL", $"{materiallotid},{equipmentid},{portid},{siteid}"));
		}
		Materiallotportrel result = ContextManager.DirectEntityQuery<Materiallotportrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{materiallotid},{equipmentid},{portid},{siteid}");
		}
		return result;
	}

	public static Materiallotportrel GetMaterialLotPortRel4Update(IDbContext dbContext, string materiallotid, string equipmentid, string portid, string siteid)
	{
		string apiName = "GetMaterialLotPortRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{materiallotid},{equipmentid},{portid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetMaterialLotPortRel4UpdateSqlDatabase : _sqlGetMaterialLotPortRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MATERIALLOTID", materiallotid, typeOfThis));
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("PORTID", portid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_MATERIALLOTPORTREL", $"{materiallotid},{equipmentid},{portid},{siteid}"));
		}
		Materiallotportrel result = ContextManager.DirectEntityQuery<Materiallotportrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{materiallotid},{equipmentid},{portid},{siteid}");
		}
		return result;
	}

	public static Materiallotportrel SelectMaterialLotPortRel(IDbContext dbContext, string materiallotid, string equipmentid, string portid, string siteid)
	{
		string apiName = "SelectMaterialLotPortRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{materiallotid},{equipmentid},{portid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMaterialLotPortRelSqlDatabase : _sqlSelectMaterialLotPortRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MATERIALLOTID", materiallotid, typeOfThis));
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("PORTID", portid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MATERIALLOTPORTREL", $"{materiallotid},{equipmentid},{portid},{siteid}"));
		}
		Materiallotportrel result = ContextManager.DirectEntityQuery<Materiallotportrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{materiallotid},{equipmentid},{portid},{siteid}");
		}
		return result;
	}

	public static Materiallotportrel SelectMaterialLotPortRel4Update(IDbContext dbContext, string materiallotid, string equipmentid, string portid, string siteid)
	{
		string apiName = "SelectMaterialLotPortRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{materiallotid},{equipmentid},{portid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMaterialLotPortRel4UpdateSqlDatabase : _sqlSelectMaterialLotPortRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MATERIALLOTID", materiallotid, typeOfThis));
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("PORTID", portid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_MATERIALLOTPORTREL", $"{materiallotid},{equipmentid},{portid},{siteid}"));
		}
		Materiallotportrel result = ContextManager.DirectEntityQuery<Materiallotportrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{materiallotid},{equipmentid},{portid},{siteid}");
		}
		return result;
	}

	public static int UpsertMaterialLotPortRel(IDbContext dbContext, RequestType requestType, Materiallotportrel[] materialLotPortRelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateMaterialLotPortRelInternal(dbContext, materialLotPortRelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateMaterialLotPortRel(dbContext, materialLotPortRelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteMaterialLotPortRel(dbContext, materialLotPortRelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteMaterialLotPortRel(dbContext, materialLotPortRelList, optionSet, saveHist), 
			_ => RealDeleteMaterialLotPortRel(dbContext, materialLotPortRelList, optionSet, saveHist), 
		};
	}

	private static int CreateMaterialLotPortRelInternal(IDbContext dbContext, Materiallotportrel[] materialLotPortRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotPortRelList", materialLotPortRelList);
		string text = "CreateMaterialLotPortRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materiallotportrel> list = new List<Materiallotportrel>();
		foreach (Materiallotportrel obj in materialLotPortRelList)
		{
			Materiallotportrel materiallotportrel = new Materiallotportrel();
			obj.CopyColumsTo(materiallotportrel);
			materiallotportrel.Activity = text;
			materiallotportrel.CheckEntityUsable();
			obj.CopyCommonField(materiallotportrel, systemTime, dbContext.Tid, isCreate: true);
			list.Add(materiallotportrel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateMaterialLotPortRel(IDbContext dbContext, Materiallotportrel[] materialLotPortRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotPortRelList", materialLotPortRelList);
		string text = "UpdateMaterialLotPortRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materiallotportrel> list = new List<Materiallotportrel>();
		foreach (Materiallotportrel materiallotportrel in materialLotPortRelList)
		{
			Materiallotportrel materialLotPortRel4Update = GetMaterialLotPortRel4Update(dbContext, materiallotportrel.Materiallotid, materiallotportrel.Equipmentid, materiallotportrel.Portid, materiallotportrel.Siteid);
			if (materialLotPortRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Materiallotportrel), $"{materiallotportrel.Materiallotid},{materiallotportrel.Equipmentid},{materiallotportrel.Portid},{materiallotportrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Materiallotportrel), $"{materiallotportrel.Materiallotid},{materiallotportrel.Equipmentid},{materiallotportrel.Portid},{materiallotportrel.Siteid}", materialLotPortRel4Update.Isusable);
			string activity = materialLotPortRel4Update.Activity;
			string customactivity = materialLotPortRel4Update.Customactivity;
			string isusable = materialLotPortRel4Update.Isusable;
			DateTime? createtime = materialLotPortRel4Update.Createtime;
			string creator = materialLotPortRel4Update.Creator;
			materiallotportrel.CopyColumsTo(materialLotPortRel4Update);
			materialLotPortRel4Update.Prevactivity = activity;
			materialLotPortRel4Update.Prevcustomactivity = customactivity;
			materialLotPortRel4Update.Creator = creator;
			materialLotPortRel4Update.Createtime = createtime;
			materialLotPortRel4Update.Isusable = isusable;
			materialLotPortRel4Update.Activity = text;
			materiallotportrel.CopyCommonField(materialLotPortRel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(materialLotPortRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteMaterialLotPortRel(IDbContext dbContext, Materiallotportrel[] materialLotPortRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotPortRelList", materialLotPortRelList);
		string text = "DeleteMaterialLotPortRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materiallotportrel> list = new List<Materiallotportrel>();
		foreach (Materiallotportrel materiallotportrel in materialLotPortRelList)
		{
			Materiallotportrel materialLotPortRel4Update = GetMaterialLotPortRel4Update(dbContext, materiallotportrel.Materiallotid, materiallotportrel.Equipmentid, materiallotportrel.Portid, materiallotportrel.Siteid);
			if (materialLotPortRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Materiallotportrel), $"{materiallotportrel.Materiallotid},{materiallotportrel.Equipmentid},{materiallotportrel.Portid},{materiallotportrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Materiallotportrel), $"{materiallotportrel.Materiallotid},{materiallotportrel.Equipmentid},{materiallotportrel.Portid},{materiallotportrel.Siteid}", materialLotPortRel4Update.Isusable);
			materialLotPortRel4Update.Isusable = "UnUsable";
			materiallotportrel.CopyCommonFieldUpdatePrev(materialLotPortRel4Update, systemTime, dbContext.Tid, text);
			materiallotportrel.CopyExtensionCollection(materialLotPortRel4Update);
			list.Add(materialLotPortRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteMaterialLotPortRel(IDbContext dbContext, Materiallotportrel[] materialLotPortRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotPortRelList", materialLotPortRelList);
		string text = "UnDeleteMaterialLotPortRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materiallotportrel> list = new List<Materiallotportrel>();
		foreach (Materiallotportrel materiallotportrel in materialLotPortRelList)
		{
			Materiallotportrel materialLotPortRel4Update = GetMaterialLotPortRel4Update(dbContext, materiallotportrel.Materiallotid, materiallotportrel.Equipmentid, materiallotportrel.Portid, materiallotportrel.Siteid);
			if (materialLotPortRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Materiallotportrel), $"{materiallotportrel.Materiallotid},{materiallotportrel.Equipmentid},{materiallotportrel.Portid},{materiallotportrel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Materiallotportrel), $"{materiallotportrel.Materiallotid},{materiallotportrel.Equipmentid},{materiallotportrel.Portid},{materiallotportrel.Siteid}", materialLotPortRel4Update.Isusable);
			materialLotPortRel4Update.Isusable = "Usable";
			materiallotportrel.CopyCommonFieldUpdatePrev(materialLotPortRel4Update, systemTime, dbContext.Tid, text);
			materiallotportrel.CopyExtensionCollection(materialLotPortRel4Update);
			list.Add(materialLotPortRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteMaterialLotPortRel(IDbContext dbContext, Materiallotportrel[] materialLotPortRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotPortRelList", materialLotPortRelList);
		string text = "RealDeleteMaterialLotPortRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materiallotportrel> list = new List<Materiallotportrel>();
		foreach (Materiallotportrel materiallotportrel in materialLotPortRelList)
		{
			Materiallotportrel materialLotPortRel4Update = GetMaterialLotPortRel4Update(dbContext, materiallotportrel.Materiallotid, materiallotportrel.Equipmentid, materiallotportrel.Portid, materiallotportrel.Siteid);
			if (materialLotPortRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Materiallotportrel), $"{materiallotportrel.Materiallotid},{materiallotportrel.Equipmentid},{materiallotportrel.Portid},{materiallotportrel.Siteid}");
			}
			materiallotportrel.CopyCommonFieldUpdatePrev(materialLotPortRel4Update, systemTime, dbContext.Tid, text);
			materiallotportrel.CopyExtensionCollection(materialLotPortRel4Update);
			list.Add(materialLotPortRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static IList<Materiallotportrel> SelectMaterialLotPortRelListByEquipmentId(IDbContext dbContext, string equipmentid, string siteid)
	{
		string apiName = "SelectMaterialLotPortRelListByEquipmentId";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMaterialLotPortRelListByEquipmentIdSqlDatabase : _sqlSelectMaterialLotPortRelListByEquipmentIdOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MATERIALLOTPORTREL", $"{equipmentid},{siteid}"));
		}
		IList<Materiallotportrel> result = ContextManager.DirectEntityQuery<Materiallotportrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentid},{siteid}");
		}
		return result;
	}

	public static IList<Materiallotportrel> SelectMaterialLotPortRelListByEquipmentPortId(IDbContext dbContext, string equipmentid, string portid, string siteid)
	{
		string apiName = "SelectMaterialLotPortRelListByEquipmentPortId";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentid},{portid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMaterialLotPortRelListByEquipmentPortIdSqlDatabase : _sqlSelectMaterialLotPortRelListByEquipmentPortIdOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("PORTID", portid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MATERIALLOTPORTREL", $"{equipmentid},{portid},{siteid}"));
		}
		IList<Materiallotportrel> result = ContextManager.DirectEntityQuery<Materiallotportrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentid},{portid},{siteid}");
		}
		return result;
	}

	public static IList<Materiallotportrel> SelectMaterialLotPortRelListByEquipmentPortId4Update(IDbContext dbContext, string equipmentid, string portid, string siteid)
	{
		string apiName = "SelectMaterialLotPortRelListByEquipmentPortId4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentid},{portid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMaterialLotPortRelListByEquipmentPortId4UpdateSqlDatabase : _sqlSelectMaterialLotPortRelListByEquipmentPortId4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("PORTID", portid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_MATERIALLOTPORTREL", $"{equipmentid},{portid},{siteid}"));
		}
		IList<Materiallotportrel> result = ContextManager.DirectEntityQuery<Materiallotportrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentid},{portid},{siteid}");
		}
		return result;
	}

	public static IList<Materiallotportrel> SelectMaterialLotPortRelListByMaterialLotId(IDbContext dbContext, string materiallotid, string siteid)
	{
		string apiName = "SelectMaterialLotPortRelListByMaterialLotId";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{materiallotid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMaterialLotPortRelListByMaterialLotIdSqlDatabase : _sqlSelectMaterialLotPortRelListByMaterialLotIdOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MATERIALLOTID", materiallotid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MATERIALLOTPORTREL", $"{materiallotid},{siteid}"));
		}
		IList<Materiallotportrel> result = ContextManager.DirectEntityQuery<Materiallotportrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{materiallotid},{siteid}");
		}
		return result;
	}

	public static IList<Materiallotportrel> SelectMaterialLotPortRelListByMaterialLotId4Update(IDbContext dbContext, string materiallotid, string siteid)
	{
		string apiName = "SelectMaterialLotPortRelListByMaterialLotId4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{materiallotid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMaterialLotPortRelListByMaterialLotId4UpdateSqlDatabase : _sqlSelectMaterialLotPortRelListByMaterialLotId4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MATERIALLOTID", materiallotid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_MATERIALLOTPORTREL", $"{materiallotid},{siteid}"));
		}
		IList<Materiallotportrel> result = ContextManager.DirectEntityQuery<Materiallotportrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{materiallotid},{siteid}");
		}
		return result;
	}
}
