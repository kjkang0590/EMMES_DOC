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
public class MATERIALLOTDURABLEREL
{
	private static string _sqlGetMaterialLotDurableRelSqlDatabase = "SELECT * FROM CIM_MATERIALLOTDURABLEREL WHERE MATERIALLOTID=@MATERIALLOTID AND DURABLEID=@DURABLEID AND SITEID=@SITEID";

	private static string _sqlGetMaterialLotDurableRel4UpdateSqlDatabase = "SELECT * FROM CIM_MATERIALLOTDURABLEREL WITH(UPDLOCK) WHERE MATERIALLOTID=@MATERIALLOTID AND DURABLEID=@DURABLEID AND SITEID=@SITEID";

	private static string _sqlSelectMaterialLotDurableRelSqlDatabase = "SELECT * FROM CIM_MATERIALLOTDURABLEREL WHERE MATERIALLOTID=@MATERIALLOTID AND DURABLEID=@DURABLEID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMaterialLotDurableRel4UpdateSqlDatabase = "SELECT * FROM CIM_MATERIALLOTDURABLEREL WITH(UPDLOCK) WHERE MATERIALLOTID=@MATERIALLOTID AND DURABLEID=@DURABLEID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetMaterialLotDurableRelOracleDatabase = "SELECT * FROM CIM_MATERIALLOTDURABLEREL WHERE MATERIALLOTID=:MATERIALLOTID AND DURABLEID=:DURABLEID AND SITEID=:SITEID";

	private static string _sqlGetMaterialLotDurableRel4UpdateOracleDatabase = "SELECT * FROM CIM_MATERIALLOTDURABLEREL WHERE MATERIALLOTID=:MATERIALLOTID AND DURABLEID=:DURABLEID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectMaterialLotDurableRelOracleDatabase = "SELECT * FROM CIM_MATERIALLOTDURABLEREL WHERE MATERIALLOTID=:MATERIALLOTID AND DURABLEID=:DURABLEID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMaterialLotDurableRel4UpdateOracleDatabase = "SELECT * FROM CIM_MATERIALLOTDURABLEREL WHERE MATERIALLOTID=:MATERIALLOTID AND DURABLEID=:DURABLEID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Materiallotdurablerel);

	public static Materiallotdurablerel GetMaterialLotDurableRel(IDbContext dbContext, string materiallotid, string durableid, string siteid)
	{
		string apiName = "GetMaterialLotDurableRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{materiallotid},{durableid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetMaterialLotDurableRelSqlDatabase : _sqlGetMaterialLotDurableRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MATERIALLOTID", materiallotid, typeOfThis));
		list.Add(dbContext.CreateParameter("DURABLEID", durableid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MATERIALLOTDURABLEREL", $"{materiallotid},{durableid},{siteid}"));
		}
		Materiallotdurablerel? result = ContextManager.DirectEntityQuery<Materiallotdurablerel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{materiallotid},{durableid},{siteid}");
		}
		return result;
	}

	public static Materiallotdurablerel GetMaterialLotDurableRel4Update(IDbContext dbContext, string materiallotid, string durableid, string siteid)
	{
		string apiName = "GetMaterialLotDurableRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{materiallotid},{durableid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetMaterialLotDurableRel4UpdateSqlDatabase : _sqlGetMaterialLotDurableRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MATERIALLOTID", materiallotid, typeOfThis));
		list.Add(dbContext.CreateParameter("DURABLEID", durableid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_MATERIALLOTDURABLEREL", $"{materiallotid},{durableid},{siteid}"));
		}
		Materiallotdurablerel? result = ContextManager.DirectEntityQuery<Materiallotdurablerel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{materiallotid},{durableid},{siteid}");
		}
		return result;
	}

	public static Materiallotdurablerel SelectMaterialLotDurableRel(IDbContext dbContext, string materiallotid, string durableid, string siteid)
	{
		string apiName = "SelectMaterialLotDurableRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{materiallotid},{durableid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMaterialLotDurableRelSqlDatabase : _sqlSelectMaterialLotDurableRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MATERIALLOTID", materiallotid, typeOfThis));
		list.Add(dbContext.CreateParameter("DURABLEID", durableid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MATERIALLOTDURABLEREL", $"{materiallotid},{durableid},{siteid}"));
		}
		Materiallotdurablerel? result = ContextManager.DirectEntityQuery<Materiallotdurablerel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{materiallotid},{durableid},{siteid}");
		}
		return result;
	}

	public static Materiallotdurablerel SelectMaterialLotDurableRel4Update(IDbContext dbContext, string materiallotid, string durableid, string siteid)
	{
		string apiName = "SelectMaterialLotDurableRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{materiallotid},{durableid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMaterialLotDurableRel4UpdateSqlDatabase : _sqlSelectMaterialLotDurableRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MATERIALLOTID", materiallotid, typeOfThis));
		list.Add(dbContext.CreateParameter("DURABLEID", durableid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_MATERIALLOTDURABLEREL", $"{materiallotid},{durableid},{siteid}"));
		}
		Materiallotdurablerel? result = ContextManager.DirectEntityQuery<Materiallotdurablerel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{materiallotid},{durableid},{siteid}");
		}
		return result;
	}

	public static int UpsertMaterialLotDurableRel(IDbContext dbContext, RequestType requestType, Materiallotdurablerel[] materialLotDurableRelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateMaterialLotDurableRelInternal(dbContext, materialLotDurableRelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateMaterialLotDurableRel(dbContext, materialLotDurableRelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteMaterialLotDurableRel(dbContext, materialLotDurableRelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteMaterialLotDurableRel(dbContext, materialLotDurableRelList, optionSet, saveHist), 
			_ => RealDeleteMaterialLotDurableRel(dbContext, materialLotDurableRelList, optionSet, saveHist), 
		};
	}

	private static int CreateMaterialLotDurableRelInternal(IDbContext dbContext, Materiallotdurablerel[] materialLotDurableRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotDurableRelList", materialLotDurableRelList);
		string text = "CreateMaterialLotDurableRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materiallotdurablerel> list = new List<Materiallotdurablerel>();
		foreach (Materiallotdurablerel obj in materialLotDurableRelList)
		{
			Materiallotdurablerel materiallotdurablerel = new Materiallotdurablerel();
			obj.CopyColumsTo(materiallotdurablerel);
			materiallotdurablerel.Activity = text;
			materiallotdurablerel.CheckEntityUsable();
			obj.CopyCommonField(materiallotdurablerel, systemTime, dbContext.Tid, isCreate: true);
			list.Add(materiallotdurablerel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateMaterialLotDurableRel(IDbContext dbContext, Materiallotdurablerel[] materialLotDurableRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotDurableRelList", materialLotDurableRelList);
		string text = "UpdateMaterialLotDurableRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materiallotdurablerel> list = new List<Materiallotdurablerel>();
		foreach (Materiallotdurablerel materiallotdurablerel in materialLotDurableRelList)
		{
			Materiallotdurablerel materialLotDurableRel4Update = GetMaterialLotDurableRel4Update(dbContext, materiallotdurablerel.Materiallotid, materiallotdurablerel.Durableid, materiallotdurablerel.Siteid);
			if (materialLotDurableRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Materiallotdurablerel), $"{materiallotdurablerel.Materiallotid},{materiallotdurablerel.Durableid},{materiallotdurablerel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Materiallotdurablerel), $"{materiallotdurablerel.Materiallotid},{materiallotdurablerel.Durableid},{materiallotdurablerel.Siteid}", materialLotDurableRel4Update.Isusable);
			string activity = materialLotDurableRel4Update.Activity;
			string customactivity = materialLotDurableRel4Update.Customactivity;
			string isusable = materialLotDurableRel4Update.Isusable;
			DateTime? createtime = materialLotDurableRel4Update.Createtime;
			string creator = materialLotDurableRel4Update.Creator;
			materiallotdurablerel.CopyColumsTo(materialLotDurableRel4Update);
			materialLotDurableRel4Update.Prevactivity = activity;
			materialLotDurableRel4Update.Prevcustomactivity = customactivity;
			materialLotDurableRel4Update.Creator = creator;
			materialLotDurableRel4Update.Createtime = createtime;
			materialLotDurableRel4Update.Isusable = isusable;
			materialLotDurableRel4Update.Activity = text;
			materiallotdurablerel.CopyCommonField(materialLotDurableRel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(materialLotDurableRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteMaterialLotDurableRel(IDbContext dbContext, Materiallotdurablerel[] materialLotDurableRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotDurableRelList", materialLotDurableRelList);
		string text = "DeleteMaterialLotDurableRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materiallotdurablerel> list = new List<Materiallotdurablerel>();
		foreach (Materiallotdurablerel materiallotdurablerel in materialLotDurableRelList)
		{
			Materiallotdurablerel materialLotDurableRel4Update = GetMaterialLotDurableRel4Update(dbContext, materiallotdurablerel.Materiallotid, materiallotdurablerel.Durableid, materiallotdurablerel.Siteid);
			if (materialLotDurableRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Materiallotdurablerel), $"{materiallotdurablerel.Materiallotid},{materiallotdurablerel.Durableid},{materiallotdurablerel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Materiallotdurablerel), $"{materiallotdurablerel.Materiallotid},{materiallotdurablerel.Durableid},{materiallotdurablerel.Siteid}", materialLotDurableRel4Update.Isusable);
			materialLotDurableRel4Update.Isusable = "UnUsable";
			materiallotdurablerel.CopyCommonFieldUpdatePrev(materialLotDurableRel4Update, systemTime, dbContext.Tid, text);
			materiallotdurablerel.CopyExtensionCollection(materialLotDurableRel4Update);
			list.Add(materialLotDurableRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteMaterialLotDurableRel(IDbContext dbContext, Materiallotdurablerel[] materialLotDurableRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotDurableRelList", materialLotDurableRelList);
		string text = "UnDeleteMaterialLotDurableRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materiallotdurablerel> list = new List<Materiallotdurablerel>();
		foreach (Materiallotdurablerel materiallotdurablerel in materialLotDurableRelList)
		{
			Materiallotdurablerel materialLotDurableRel4Update = GetMaterialLotDurableRel4Update(dbContext, materiallotdurablerel.Materiallotid, materiallotdurablerel.Durableid, materiallotdurablerel.Siteid);
			if (materialLotDurableRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Materiallotdurablerel), $"{materiallotdurablerel.Materiallotid},{materiallotdurablerel.Durableid},{materiallotdurablerel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Materiallotdurablerel), $"{materiallotdurablerel.Materiallotid},{materiallotdurablerel.Durableid},{materiallotdurablerel.Siteid}", materialLotDurableRel4Update.Isusable);
			materialLotDurableRel4Update.Isusable = "Usable";
			materiallotdurablerel.CopyCommonFieldUpdatePrev(materialLotDurableRel4Update, systemTime, dbContext.Tid, text);
			materiallotdurablerel.CopyExtensionCollection(materialLotDurableRel4Update);
			list.Add(materialLotDurableRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteMaterialLotDurableRel(IDbContext dbContext, Materiallotdurablerel[] materialLotDurableRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotDurableRelList", materialLotDurableRelList);
		string text = "RealDeleteMaterialLotDurableRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materiallotdurablerel> list = new List<Materiallotdurablerel>();
		foreach (Materiallotdurablerel materiallotdurablerel in materialLotDurableRelList)
		{
			Materiallotdurablerel materialLotDurableRel4Update = GetMaterialLotDurableRel4Update(dbContext, materiallotdurablerel.Materiallotid, materiallotdurablerel.Durableid, materiallotdurablerel.Siteid);
			if (materialLotDurableRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Materiallotdurablerel), $"{materiallotdurablerel.Materiallotid},{materiallotdurablerel.Durableid},{materiallotdurablerel.Siteid}");
			}
			materiallotdurablerel.CopyCommonFieldUpdatePrev(materialLotDurableRel4Update, systemTime, dbContext.Tid, text);
			materiallotdurablerel.CopyExtensionCollection(materialLotDurableRel4Update);
			list.Add(materialLotDurableRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
