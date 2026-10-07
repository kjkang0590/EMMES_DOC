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
public class BOM
{
	private static string _sqlGetBomSqlDatabase = "SELECT * FROM CIM_BOM WHERE BOMID=@BOMID AND SITEID=@SITEID";

	private static string _sqlGetBom4UpdateSqlDatabase = "SELECT * FROM CIM_BOM WITH(UPDLOCK) WHERE BOMID=@BOMID AND SITEID=@SITEID";

	private static string _sqlSelectBomSqlDatabase = "SELECT * FROM CIM_BOM WHERE BOMID=@BOMID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectBom4UpdateSqlDatabase = "SELECT * FROM CIM_BOM WITH(UPDLOCK) WHERE BOMID=@BOMID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetBomOracleDatabase = "SELECT * FROM CIM_BOM WHERE BOMID=:BOMID AND SITEID=:SITEID";

	private static string _sqlGetBom4UpdateOracleDatabase = "SELECT * FROM CIM_BOM WHERE BOMID=:BOMID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectBomOracleDatabase = "SELECT * FROM CIM_BOM WHERE BOMID=:BOMID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectBom4UpdateOracleDatabase = "SELECT * FROM CIM_BOM WHERE BOMID=:BOMID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Bom);

	public static Bom GetBom(IDbContext dbContext, string bomid, string siteid)
	{
		string apiName = "GetBom";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{bomid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetBomSqlDatabase : _sqlGetBomOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("BOMID", bomid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_BOM", $"{bomid},{siteid}"));
		}
		Bom? result = ContextManager.DirectEntityQuery<Bom>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{bomid},{siteid}");
		}
		return result;
	}

	public static Bom GetBom4Update(IDbContext dbContext, string bomid, string siteid)
	{
		string apiName = "GetBom4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{bomid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetBom4UpdateSqlDatabase : _sqlGetBom4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("BOMID", bomid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_BOM", $"{bomid},{siteid}"));
		}
		Bom? result = ContextManager.DirectEntityQuery<Bom>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{bomid},{siteid}");
		}
		return result;
	}

	public static Bom SelectBom(IDbContext dbContext, string bomid, string siteid)
	{
		string apiName = "SelectBom";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{bomid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectBomSqlDatabase : _sqlSelectBomOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("BOMID", bomid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_BOM", $"{bomid},{siteid}"));
		}
		Bom? result = ContextManager.DirectEntityQuery<Bom>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{bomid},{siteid}");
		}
		return result;
	}

	public static Bom SelectBom4Update(IDbContext dbContext, string bomid, string siteid)
	{
		string apiName = "SelectBom4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{bomid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectBom4UpdateSqlDatabase : _sqlSelectBom4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("BOMID", bomid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_BOM", $"{bomid},{siteid}"));
		}
		Bom? result = ContextManager.DirectEntityQuery<Bom>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{bomid},{siteid}");
		}
		return result;
	}

	public static int UpsertBom(IDbContext dbContext, RequestType requestType, Bom[] bomList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateBomInternal(dbContext, bomList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateBom(dbContext, bomList, optionSet, saveHist), 
			RequestType.DELETE => DeleteBom(dbContext, bomList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteBom(dbContext, bomList, optionSet, saveHist), 
			_ => RealDeleteBom(dbContext, bomList, optionSet, saveHist), 
		};
	}

	private static int CreateBomInternal(IDbContext dbContext, Bom[] bomList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("bomList", bomList);
		string text = "CreateBom";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Bom> list = new List<Bom>();
		foreach (Bom obj in bomList)
		{
			Bom bom = new Bom();
			obj.CopyColumsTo(bom);
			bom.Activity = text;
			bom.CheckEntityUsable();
			obj.CopyCommonField(bom, systemTime, dbContext.Tid, isCreate: true);
			list.Add(bom);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateBom(IDbContext dbContext, Bom[] bomList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("bomList", bomList);
		string text = "UpdateBom";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Bom> list = new List<Bom>();
		foreach (Bom bom in bomList)
		{
			Bom bom4Update = GetBom4Update(dbContext, bom.Bomid, bom.Siteid);
			if (bom4Update == null)
			{
				throw new EntityNotFoundException(typeof(Bom), $"{bom.Bomid},{bom.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Bom), $"{bom.Bomid},{bom.Siteid}", bom4Update.Isusable);
			string activity = bom4Update.Activity;
			string customactivity = bom4Update.Customactivity;
			string isusable = bom4Update.Isusable;
			DateTime? createtime = bom4Update.Createtime;
			string creator = bom4Update.Creator;
			bom.CopyColumsTo(bom4Update);
			bom4Update.Prevactivity = activity;
			bom4Update.Prevcustomactivity = customactivity;
			bom4Update.Creator = creator;
			bom4Update.Createtime = createtime;
			bom4Update.Isusable = isusable;
			bom4Update.Activity = text;
			bom.CopyCommonField(bom4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(bom4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteBom(IDbContext dbContext, Bom[] bomList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("bomList", bomList);
		string text = "DeleteBom";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Bom> list = new List<Bom>();
		foreach (Bom bom in bomList)
		{
			Bom bom4Update = GetBom4Update(dbContext, bom.Bomid, bom.Siteid);
			if (bom4Update == null)
			{
				throw new EntityNotFoundException(typeof(Bom), $"{bom.Bomid},{bom.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Bom), $"{bom.Bomid},{bom.Siteid}", bom4Update.Isusable);
			bom4Update.Isusable = "UnUsable";
			bom.CopyCommonFieldUpdatePrev(bom4Update, systemTime, dbContext.Tid, text);
			bom.CopyExtensionCollection(bom4Update);
			list.Add(bom4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteBom(IDbContext dbContext, Bom[] bomList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("bomList", bomList);
		string text = "UnDeleteBom";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Bom> list = new List<Bom>();
		foreach (Bom bom in bomList)
		{
			Bom bom4Update = GetBom4Update(dbContext, bom.Bomid, bom.Siteid);
			if (bom4Update == null)
			{
				throw new EntityNotFoundException(typeof(Bom), $"{bom.Bomid},{bom.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Bom), $"{bom.Bomid},{bom.Siteid}", bom4Update.Isusable);
			bom4Update.Isusable = "Usable";
			bom.CopyCommonFieldUpdatePrev(bom4Update, systemTime, dbContext.Tid, text);
			bom.CopyExtensionCollection(bom4Update);
			list.Add(bom4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteBom(IDbContext dbContext, Bom[] bomList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("bomList", bomList);
		string text = "RealDeleteBom";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Bom> list = new List<Bom>();
		foreach (Bom bom in bomList)
		{
			Bom bom4Update = GetBom4Update(dbContext, bom.Bomid, bom.Siteid);
			if (bom4Update == null)
			{
				throw new EntityNotFoundException(typeof(Bom), $"{bom.Bomid},{bom.Siteid}");
			}
			bom.CopyCommonFieldUpdatePrev(bom4Update, systemTime, dbContext.Tid, text);
			bom.CopyExtensionCollection(bom4Update);
			list.Add(bom4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
