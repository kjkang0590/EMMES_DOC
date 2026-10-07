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
public class GRIDMASTER
{
	private static string _sqlGetGridMasterSqlDatabase = "SELECT * FROM CIM_GRIDMASTER WHERE MENUID=@MENUID AND GRIDID=@GRIDID AND COLUMNNAME=@COLUMNNAME AND SITEID=@SITEID";

	private static string _sqlGetGridMaster4UpdateSqlDatabase = "SELECT * FROM CIM_GRIDMASTER WITH(UPDLOCK) WHERE MENUID=@MENUID AND GRIDID=@GRIDID AND COLUMNNAME=@COLUMNNAME AND SITEID=@SITEID";

	private static string _sqlSelectGridMasterSqlDatabase = "SELECT * FROM CIM_GRIDMASTER WHERE MENUID=@MENUID AND GRIDID=@GRIDID AND COLUMNNAME=@COLUMNNAME AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectGridMaster4UpdateSqlDatabase = "SELECT * FROM CIM_GRIDMASTER WITH(UPDLOCK) WHERE MENUID=@MENUID AND GRIDID=@GRIDID AND COLUMNNAME=@COLUMNNAME AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetGridMasterOracleDatabase = "SELECT * FROM CIM_GRIDMASTER WHERE MENUID=:MENUID AND GRIDID=:GRIDID AND COLUMNNAME=:COLUMNNAME AND SITEID=:SITEID";

	private static string _sqlGetGridMaster4UpdateOracleDatabase = "SELECT * FROM CIM_GRIDMASTER WHERE MENUID=:MENUID AND GRIDID=:GRIDID AND COLUMNNAME=:COLUMNNAME AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectGridMasterOracleDatabase = "SELECT * FROM CIM_GRIDMASTER WHERE MENUID=:MENUID AND GRIDID=:GRIDID AND COLUMNNAME=:COLUMNNAME AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectGridMaster4UpdateOracleDatabase = "SELECT * FROM CIM_GRIDMASTER WHERE MENUID=:MENUID AND GRIDID=:GRIDID AND COLUMNNAME=:COLUMNNAME AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Gridmaster);

	public static Gridmaster GetGridMaster(IDbContext dbContext, string menuid, string gridid, string columnname, string siteid)
	{
		string apiName = "GetGridMaster";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{menuid},{gridid},{columnname},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetGridMasterSqlDatabase : _sqlGetGridMasterOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("GRIDID", gridid, typeOfThis));
		list.Add(dbContext.CreateParameter("COLUMNNAME", columnname, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_GRIDMASTER", $"{menuid},{gridid},{columnname},{siteid}"));
		}
		Gridmaster result = ContextManager.DirectEntityQuery<Gridmaster>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{menuid},{gridid},{columnname},{siteid}");
		}
		return result;
	}

	public static Gridmaster GetGridMaster4Update(IDbContext dbContext, string menuid, string gridid, string columnname, string siteid)
	{
		string apiName = "GetGridMaster4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{menuid},{gridid},{columnname},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetGridMaster4UpdateSqlDatabase : _sqlGetGridMaster4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("GRIDID", gridid, typeOfThis));
		list.Add(dbContext.CreateParameter("COLUMNNAME", columnname, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_GRIDMASTER", $"{menuid},{gridid},{columnname},{siteid}"));
		}
		Gridmaster result = ContextManager.DirectEntityQuery<Gridmaster>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{menuid},{gridid},{columnname},{siteid}");
		}
		return result;
	}

	public static Gridmaster SelectGridMaster(IDbContext dbContext, string menuid, string gridid, string columnname, string siteid)
	{
		string apiName = "SelectGridMaster";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{menuid},{gridid},{columnname},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectGridMasterSqlDatabase : _sqlSelectGridMasterOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("GRIDID", gridid, typeOfThis));
		list.Add(dbContext.CreateParameter("COLUMNNAME", columnname, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_GRIDMASTER", $"{menuid},{gridid},{columnname},{siteid}"));
		}
		Gridmaster result = ContextManager.DirectEntityQuery<Gridmaster>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{menuid},{gridid},{columnname},{siteid}");
		}
		return result;
	}

	public static Gridmaster SelectGridMaster4Update(IDbContext dbContext, string menuid, string gridid, string columnname, string siteid)
	{
		string apiName = "SelectGridMaster4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{menuid},{gridid},{columnname},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectGridMaster4UpdateSqlDatabase : _sqlSelectGridMaster4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("GRIDID", gridid, typeOfThis));
		list.Add(dbContext.CreateParameter("COLUMNNAME", columnname, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_GRIDMASTER", $"{menuid},{gridid},{columnname},{siteid}"));
		}
		Gridmaster result = ContextManager.DirectEntityQuery<Gridmaster>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{menuid},{gridid},{columnname},{siteid}");
		}
		return result;
	}

	public static int UpsertGridMaster(IDbContext dbContext, RequestType requestType, Gridmaster[] gridMasterList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateGridMasterInternal(dbContext, gridMasterList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateGridMaster(dbContext, gridMasterList, optionSet, saveHist), 
			RequestType.DELETE => DeleteGridMaster(dbContext, gridMasterList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteGridMaster(dbContext, gridMasterList, optionSet, saveHist), 
			_ => RealDeleteGridMaster(dbContext, gridMasterList, optionSet, saveHist), 
		};
	}

	private static int CreateGridMasterInternal(IDbContext dbContext, Gridmaster[] gridMasterList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("gridMasterList", gridMasterList);
		string text = "CreateGridMaster";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Gridmaster> list = new List<Gridmaster>();
		foreach (Gridmaster obj in gridMasterList)
		{
			Gridmaster gridmaster = new Gridmaster();
			obj.CopyColumsTo(gridmaster);
			gridmaster.Activity = text;
			gridmaster.CheckEntityUsable();
			obj.CopyCommonField(gridmaster, systemTime, dbContext.Tid, isCreate: true);
			list.Add(gridmaster);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateGridMaster(IDbContext dbContext, Gridmaster[] gridMasterList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("gridMasterList", gridMasterList);
		string text = "UpdateGridMaster";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Gridmaster> list = new List<Gridmaster>();
		foreach (Gridmaster gridmaster in gridMasterList)
		{
			Gridmaster gridMaster4Update = GetGridMaster4Update(dbContext, gridmaster.Menuid, gridmaster.Gridid, gridmaster.Columnname, gridmaster.Siteid);
			if (gridMaster4Update == null)
			{
				throw new EntityNotFoundException(typeof(Gridmaster), $"{gridmaster.Menuid},{gridmaster.Gridid},{gridmaster.Columnname},{gridmaster.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Gridmaster), $"{gridmaster.Menuid},{gridmaster.Gridid},{gridmaster.Columnname},{gridmaster.Siteid}", gridMaster4Update.Isusable);
			string activity = gridMaster4Update.Activity;
			string customactivity = gridMaster4Update.Customactivity;
			string isusable = gridMaster4Update.Isusable;
			DateTime? createtime = gridMaster4Update.Createtime;
			string creator = gridMaster4Update.Creator;
			gridmaster.CopyColumsTo(gridMaster4Update);
			gridMaster4Update.Prevactivity = activity;
			gridMaster4Update.Prevcustomactivity = customactivity;
			gridMaster4Update.Creator = creator;
			gridMaster4Update.Createtime = createtime;
			gridMaster4Update.Isusable = isusable;
			gridMaster4Update.Activity = text;
			gridmaster.CopyCommonField(gridMaster4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(gridMaster4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteGridMaster(IDbContext dbContext, Gridmaster[] gridMasterList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("gridMasterList", gridMasterList);
		string text = "DeleteGridMaster";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Gridmaster> list = new List<Gridmaster>();
		foreach (Gridmaster gridmaster in gridMasterList)
		{
			Gridmaster gridMaster4Update = GetGridMaster4Update(dbContext, gridmaster.Menuid, gridmaster.Gridid, gridmaster.Columnname, gridmaster.Siteid);
			if (gridMaster4Update == null)
			{
				throw new EntityNotFoundException(typeof(Gridmaster), $"{gridmaster.Menuid},{gridmaster.Gridid},{gridmaster.Columnname},{gridmaster.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Gridmaster), $"{gridmaster.Menuid},{gridmaster.Gridid},{gridmaster.Columnname},{gridmaster.Siteid}", gridMaster4Update.Isusable);
			gridMaster4Update.Isusable = "UnUsable";
			gridmaster.CopyCommonFieldUpdatePrev(gridMaster4Update, systemTime, dbContext.Tid, text);
			gridmaster.CopyExtensionCollection(gridMaster4Update);
			list.Add(gridMaster4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteGridMaster(IDbContext dbContext, Gridmaster[] gridMasterList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("gridMasterList", gridMasterList);
		string text = "UnDeleteGridMaster";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Gridmaster> list = new List<Gridmaster>();
		foreach (Gridmaster gridmaster in gridMasterList)
		{
			Gridmaster gridMaster4Update = GetGridMaster4Update(dbContext, gridmaster.Menuid, gridmaster.Gridid, gridmaster.Columnname, gridmaster.Siteid);
			if (gridMaster4Update == null)
			{
				throw new EntityNotFoundException(typeof(Gridmaster), $"{gridmaster.Menuid},{gridmaster.Gridid},{gridmaster.Columnname},{gridmaster.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Gridmaster), $"{gridmaster.Menuid},{gridmaster.Gridid},{gridmaster.Columnname},{gridmaster.Siteid}", gridMaster4Update.Isusable);
			gridMaster4Update.Isusable = "Usable";
			gridmaster.CopyCommonFieldUpdatePrev(gridMaster4Update, systemTime, dbContext.Tid, text);
			gridmaster.CopyExtensionCollection(gridMaster4Update);
			list.Add(gridMaster4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteGridMaster(IDbContext dbContext, Gridmaster[] gridMasterList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("gridMasterList", gridMasterList);
		string text = "RealDeleteGridMaster";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Gridmaster> list = new List<Gridmaster>();
		foreach (Gridmaster gridmaster in gridMasterList)
		{
			Gridmaster gridMaster4Update = GetGridMaster4Update(dbContext, gridmaster.Menuid, gridmaster.Gridid, gridmaster.Columnname, gridmaster.Siteid);
			if (gridMaster4Update == null)
			{
				throw new EntityNotFoundException(typeof(Gridmaster), $"{gridmaster.Menuid},{gridmaster.Gridid},{gridmaster.Columnname},{gridmaster.Siteid}");
			}
			gridmaster.CopyCommonFieldUpdatePrev(gridMaster4Update, systemTime, dbContext.Tid, text);
			gridmaster.CopyExtensionCollection(gridMaster4Update);
			list.Add(gridMaster4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
