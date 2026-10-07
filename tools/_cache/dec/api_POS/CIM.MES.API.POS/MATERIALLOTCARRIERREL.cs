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
public class MATERIALLOTCARRIERREL
{
	private static string _sqlGetMaterialLotCarrierRelSqlDatabase = "SELECT * FROM CIM_MATERIALLOTCARRIERREL WHERE MATERIALLOTID=@MATERIALLOTID AND CARRIERID=@CARRIERID AND SLOTPOSITION=@SLOTPOSITION AND SITEID=@SITEID";

	private static string _sqlGetMaterialLotCarrierRel4UpdateSqlDatabase = "SELECT * FROM CIM_MATERIALLOTCARRIERREL WITH(UPDLOCK) WHERE MATERIALLOTID=@MATERIALLOTID AND CARRIERID=@CARRIERID AND SLOTPOSITION=@SLOTPOSITION AND SITEID=@SITEID";

	private static string _sqlSelectMaterialLotCarrierRelSqlDatabase = "SELECT * FROM CIM_MATERIALLOTCARRIERREL WHERE MATERIALLOTID=@MATERIALLOTID AND CARRIERID=@CARRIERID AND SLOTPOSITION=@SLOTPOSITION AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMaterialLotCarrierRel4UpdateSqlDatabase = "SELECT * FROM CIM_MATERIALLOTCARRIERREL WITH(UPDLOCK) WHERE MATERIALLOTID=@MATERIALLOTID AND CARRIERID=@CARRIERID AND SLOTPOSITION=@SLOTPOSITION AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetMaterialLotCarrierRelOracleDatabase = "SELECT * FROM CIM_MATERIALLOTCARRIERREL WHERE MATERIALLOTID=:MATERIALLOTID AND CARRIERID=:CARRIERID AND SLOTPOSITION=:SLOTPOSITION AND SITEID=:SITEID";

	private static string _sqlGetMaterialLotCarrierRel4UpdateOracleDatabase = "SELECT * FROM CIM_MATERIALLOTCARRIERREL WHERE MATERIALLOTID=:MATERIALLOTID AND CARRIERID=:CARRIERID AND SLOTPOSITION=:SLOTPOSITION AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectMaterialLotCarrierRelOracleDatabase = "SELECT * FROM CIM_MATERIALLOTCARRIERREL WHERE MATERIALLOTID=:MATERIALLOTID AND CARRIERID=:CARRIERID AND SLOTPOSITION=:SLOTPOSITION AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMaterialLotCarrierRel4UpdateOracleDatabase = "SELECT * FROM CIM_MATERIALLOTCARRIERREL WHERE MATERIALLOTID=:MATERIALLOTID AND CARRIERID=:CARRIERID AND SLOTPOSITION=:SLOTPOSITION AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Materiallotcarrierrel);

	public static Materiallotcarrierrel GetMaterialLotCarrierRel(IDbContext dbContext, string materiallotid, string carrierid, int slotposition, string siteid)
	{
		string apiName = "GetMaterialLotCarrierRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{materiallotid},{carrierid},{slotposition},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetMaterialLotCarrierRelSqlDatabase : _sqlGetMaterialLotCarrierRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MATERIALLOTID", materiallotid, typeOfThis));
		list.Add(dbContext.CreateParameter("CARRIERID", carrierid, typeOfThis));
		list.Add(dbContext.CreateParameter("SLOTPOSITION", slotposition, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MATERIALLOTCARRIERREL", $"{materiallotid},{carrierid},{slotposition},{siteid}"));
		}
		Materiallotcarrierrel result = ContextManager.DirectEntityQuery<Materiallotcarrierrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{materiallotid},{carrierid},{slotposition},{siteid}");
		}
		return result;
	}

	public static Materiallotcarrierrel GetMaterialLotCarrierRel4Update(IDbContext dbContext, string materiallotid, string carrierid, int slotposition, string siteid)
	{
		string apiName = "GetMaterialLotCarrierRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{materiallotid},{carrierid},{slotposition},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetMaterialLotCarrierRel4UpdateSqlDatabase : _sqlGetMaterialLotCarrierRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MATERIALLOTID", materiallotid, typeOfThis));
		list.Add(dbContext.CreateParameter("CARRIERID", carrierid, typeOfThis));
		list.Add(dbContext.CreateParameter("SLOTPOSITION", slotposition, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_MATERIALLOTCARRIERREL", $"{materiallotid},{carrierid},{slotposition},{siteid}"));
		}
		Materiallotcarrierrel result = ContextManager.DirectEntityQuery<Materiallotcarrierrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{materiallotid},{carrierid},{slotposition},{siteid}");
		}
		return result;
	}

	public static Materiallotcarrierrel SelectMaterialLotCarrierRel(IDbContext dbContext, string materiallotid, string carrierid, int slotposition, string siteid)
	{
		string apiName = "SelectMaterialLotCarrierRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{materiallotid},{carrierid},{slotposition},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMaterialLotCarrierRelSqlDatabase : _sqlSelectMaterialLotCarrierRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MATERIALLOTID", materiallotid, typeOfThis));
		list.Add(dbContext.CreateParameter("CARRIERID", carrierid, typeOfThis));
		list.Add(dbContext.CreateParameter("SLOTPOSITION", slotposition, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MATERIALLOTCARRIERREL", $"{materiallotid},{carrierid},{slotposition},{siteid}"));
		}
		Materiallotcarrierrel result = ContextManager.DirectEntityQuery<Materiallotcarrierrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{materiallotid},{carrierid},{slotposition},{siteid}");
		}
		return result;
	}

	public static Materiallotcarrierrel SelectMaterialLotCarrierRel4Update(IDbContext dbContext, string materiallotid, string carrierid, int slotposition, string siteid)
	{
		string apiName = "SelectMaterialLotCarrierRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{materiallotid},{carrierid},{slotposition},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMaterialLotCarrierRel4UpdateSqlDatabase : _sqlSelectMaterialLotCarrierRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MATERIALLOTID", materiallotid, typeOfThis));
		list.Add(dbContext.CreateParameter("CARRIERID", carrierid, typeOfThis));
		list.Add(dbContext.CreateParameter("SLOTPOSITION", slotposition, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_MATERIALLOTCARRIERREL", $"{materiallotid},{carrierid},{slotposition},{siteid}"));
		}
		Materiallotcarrierrel result = ContextManager.DirectEntityQuery<Materiallotcarrierrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{materiallotid},{carrierid},{slotposition},{siteid}");
		}
		return result;
	}

	public static int UpsertMaterialLotCarrierRel(IDbContext dbContext, RequestType requestType, Materiallotcarrierrel[] materialLotCarrierRelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateMaterialLotCarrierRelInternal(dbContext, materialLotCarrierRelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateMaterialLotCarrierRel(dbContext, materialLotCarrierRelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteMaterialLotCarrierRel(dbContext, materialLotCarrierRelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteMaterialLotCarrierRel(dbContext, materialLotCarrierRelList, optionSet, saveHist), 
			_ => RealDeleteMaterialLotCarrierRel(dbContext, materialLotCarrierRelList, optionSet, saveHist), 
		};
	}

	private static int CreateMaterialLotCarrierRelInternal(IDbContext dbContext, Materiallotcarrierrel[] materialLotCarrierRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotCarrierRelList", materialLotCarrierRelList);
		string text = "CreateMaterialLotCarrierRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materiallotcarrierrel> list = new List<Materiallotcarrierrel>();
		foreach (Materiallotcarrierrel obj in materialLotCarrierRelList)
		{
			Materiallotcarrierrel materiallotcarrierrel = new Materiallotcarrierrel();
			obj.CopyColumsTo(materiallotcarrierrel);
			materiallotcarrierrel.Activity = text;
			materiallotcarrierrel.CheckEntityUsable();
			obj.CopyCommonField(materiallotcarrierrel, systemTime, dbContext.Tid, isCreate: true);
			list.Add(materiallotcarrierrel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateMaterialLotCarrierRel(IDbContext dbContext, Materiallotcarrierrel[] materialLotCarrierRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotCarrierRelList", materialLotCarrierRelList);
		string text = "UpdateMaterialLotCarrierRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materiallotcarrierrel> list = new List<Materiallotcarrierrel>();
		foreach (Materiallotcarrierrel materiallotcarrierrel in materialLotCarrierRelList)
		{
			Materiallotcarrierrel materialLotCarrierRel4Update = GetMaterialLotCarrierRel4Update(dbContext, materiallotcarrierrel.Materiallotid, materiallotcarrierrel.Carrierid, materiallotcarrierrel.Slotposition, materiallotcarrierrel.Siteid);
			if (materialLotCarrierRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Materiallotcarrierrel), $"{materiallotcarrierrel.Materiallotid},{materiallotcarrierrel.Carrierid},{materiallotcarrierrel.Slotposition},{materiallotcarrierrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Materiallotcarrierrel), $"{materiallotcarrierrel.Materiallotid},{materiallotcarrierrel.Carrierid},{materiallotcarrierrel.Slotposition},{materiallotcarrierrel.Siteid}", materialLotCarrierRel4Update.Isusable);
			string activity = materialLotCarrierRel4Update.Activity;
			string customactivity = materialLotCarrierRel4Update.Customactivity;
			string isusable = materialLotCarrierRel4Update.Isusable;
			DateTime? createtime = materialLotCarrierRel4Update.Createtime;
			string creator = materialLotCarrierRel4Update.Creator;
			materiallotcarrierrel.CopyColumsTo(materialLotCarrierRel4Update);
			materialLotCarrierRel4Update.Prevactivity = activity;
			materialLotCarrierRel4Update.Prevcustomactivity = customactivity;
			materialLotCarrierRel4Update.Creator = creator;
			materialLotCarrierRel4Update.Createtime = createtime;
			materialLotCarrierRel4Update.Isusable = isusable;
			materialLotCarrierRel4Update.Activity = text;
			materiallotcarrierrel.CopyCommonField(materialLotCarrierRel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(materialLotCarrierRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteMaterialLotCarrierRel(IDbContext dbContext, Materiallotcarrierrel[] materialLotCarrierRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotCarrierRelList", materialLotCarrierRelList);
		string text = "DeleteMaterialLotCarrierRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materiallotcarrierrel> list = new List<Materiallotcarrierrel>();
		foreach (Materiallotcarrierrel materiallotcarrierrel in materialLotCarrierRelList)
		{
			Materiallotcarrierrel materialLotCarrierRel4Update = GetMaterialLotCarrierRel4Update(dbContext, materiallotcarrierrel.Materiallotid, materiallotcarrierrel.Carrierid, materiallotcarrierrel.Slotposition, materiallotcarrierrel.Siteid);
			if (materialLotCarrierRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Materiallotcarrierrel), $"{materiallotcarrierrel.Materiallotid},{materiallotcarrierrel.Carrierid},{materiallotcarrierrel.Slotposition},{materiallotcarrierrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Materiallotcarrierrel), $"{materiallotcarrierrel.Materiallotid},{materiallotcarrierrel.Carrierid},{materiallotcarrierrel.Slotposition},{materiallotcarrierrel.Siteid}", materialLotCarrierRel4Update.Isusable);
			materialLotCarrierRel4Update.Isusable = "UnUsable";
			materiallotcarrierrel.CopyCommonFieldUpdatePrev(materialLotCarrierRel4Update, systemTime, dbContext.Tid, text);
			materiallotcarrierrel.CopyExtensionCollection(materialLotCarrierRel4Update);
			list.Add(materialLotCarrierRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteMaterialLotCarrierRel(IDbContext dbContext, Materiallotcarrierrel[] materialLotCarrierRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotCarrierRelList", materialLotCarrierRelList);
		string text = "UnDeleteMaterialLotCarrierRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materiallotcarrierrel> list = new List<Materiallotcarrierrel>();
		foreach (Materiallotcarrierrel materiallotcarrierrel in materialLotCarrierRelList)
		{
			Materiallotcarrierrel materialLotCarrierRel4Update = GetMaterialLotCarrierRel4Update(dbContext, materiallotcarrierrel.Materiallotid, materiallotcarrierrel.Carrierid, materiallotcarrierrel.Slotposition, materiallotcarrierrel.Siteid);
			if (materialLotCarrierRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Materiallotcarrierrel), $"{materiallotcarrierrel.Materiallotid},{materiallotcarrierrel.Carrierid},{materiallotcarrierrel.Slotposition},{materiallotcarrierrel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Materiallotcarrierrel), $"{materiallotcarrierrel.Materiallotid},{materiallotcarrierrel.Carrierid},{materiallotcarrierrel.Slotposition},{materiallotcarrierrel.Siteid}", materialLotCarrierRel4Update.Isusable);
			materialLotCarrierRel4Update.Isusable = "Usable";
			materiallotcarrierrel.CopyCommonFieldUpdatePrev(materialLotCarrierRel4Update, systemTime, dbContext.Tid, text);
			materiallotcarrierrel.CopyExtensionCollection(materialLotCarrierRel4Update);
			list.Add(materialLotCarrierRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteMaterialLotCarrierRel(IDbContext dbContext, Materiallotcarrierrel[] materialLotCarrierRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotCarrierRelList", materialLotCarrierRelList);
		string text = "RealDeleteMaterialLotCarrierRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materiallotcarrierrel> list = new List<Materiallotcarrierrel>();
		foreach (Materiallotcarrierrel materiallotcarrierrel in materialLotCarrierRelList)
		{
			Materiallotcarrierrel materialLotCarrierRel4Update = GetMaterialLotCarrierRel4Update(dbContext, materiallotcarrierrel.Materiallotid, materiallotcarrierrel.Carrierid, materiallotcarrierrel.Slotposition, materiallotcarrierrel.Siteid);
			if (materialLotCarrierRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Materiallotcarrierrel), $"{materiallotcarrierrel.Materiallotid},{materiallotcarrierrel.Carrierid},{materiallotcarrierrel.Slotposition},{materiallotcarrierrel.Siteid}");
			}
			materiallotcarrierrel.CopyCommonFieldUpdatePrev(materialLotCarrierRel4Update, systemTime, dbContext.Tid, text);
			materiallotcarrierrel.CopyExtensionCollection(materialLotCarrierRel4Update);
			list.Add(materialLotCarrierRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
