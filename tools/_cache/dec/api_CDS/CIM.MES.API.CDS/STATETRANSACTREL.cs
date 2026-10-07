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
public class STATETRANSACTREL
{
	private static string _sqlGetStateTransActRelSqlDatabase = "SELECT * FROM CIM_STATETRANSACTREL WHERE STATEMODELID=@STATEMODELID AND STATEID=@STATEID AND TOSTATEID=@TOSTATEID AND ACTIONID=@ACTIONID AND SITEID=@SITEID";

	private static string _sqlGetStateTransActRel4UpdateSqlDatabase = "SELECT * FROM CIM_STATETRANSACTREL WITH(UPDLOCK) WHERE STATEMODELID=@STATEMODELID AND STATEID=@STATEID AND TOSTATEID=@TOSTATEID AND ACTIONID=@ACTIONID AND SITEID=@SITEID";

	private static string _sqlSelectStateTransActRelSqlDatabase = "SELECT * FROM CIM_STATETRANSACTREL WHERE STATEMODELID=@STATEMODELID AND STATEID=@STATEID AND TOSTATEID=@TOSTATEID AND ACTIONID=@ACTIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectStateTransActRel4UpdateSqlDatabase = "SELECT * FROM CIM_STATETRANSACTREL WITH(UPDLOCK) WHERE STATEMODELID=@STATEMODELID AND STATEID=@STATEID AND TOSTATEID=@TOSTATEID AND ACTIONID=@ACTIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetStateTransActRelOracleDatabase = "SELECT * FROM CIM_STATETRANSACTREL WHERE STATEMODELID=:STATEMODELID AND STATEID=:STATEID AND TOSTATEID=:TOSTATEID AND ACTIONID=:ACTIONID AND SITEID=:SITEID";

	private static string _sqlGetStateTransActRel4UpdateOracleDatabase = "SELECT * FROM CIM_STATETRANSACTREL WHERE STATEMODELID=:STATEMODELID AND STATEID=:STATEID AND TOSTATEID=:TOSTATEID AND ACTIONID=:ACTIONID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectStateTransActRelOracleDatabase = "SELECT * FROM CIM_STATETRANSACTREL WHERE STATEMODELID=:STATEMODELID AND STATEID=:STATEID AND TOSTATEID=:TOSTATEID AND ACTIONID=:ACTIONID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectStateTransActRel4UpdateOracleDatabase = "SELECT * FROM CIM_STATETRANSACTREL WHERE STATEMODELID=:STATEMODELID AND STATEID=:STATEID AND TOSTATEID=:TOSTATEID AND ACTIONID=:ACTIONID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Statetransactrel);

	private static string _sqlSelectStateTransActRelListSqlDatabase = "SELECT * FROM CIM_STATETRANSACTREL WHERE STATEMODELID = @STATEMODELID AND STATEID = @STATEID AND TOSTATEID = @TOSTATEID AND SITEID = @SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectStateTransActRelList4UpdateSqlDatabase = "SELECT * FROM CIM_STATETRANSACTREL WITH (UPDLOCK) WHERE STATEMODELID = @STATEMODELID AND STATEID = @STATEID AND TOSTATEID = @TOSTATEID AND SITEID = @SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectStateTransActRelListOracleDatabase = "SELECT * FROM CIM_STATETRANSACTREL WHERE STATEMODELID = :STATEMODELID AND STATEID = :STATEID AND TOSTATEID = :TOSTATEID AND SITEID = :SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectStateTransActRelList4UpdateOracleDatabase = "SELECT * FROM CIM_STATETRANSACTREL WHERE STATEMODELID = :STATEMODELID AND STATEID = :STATEID AND TOSTATEID = :TOSTATEID AND SITEID = :SITEID AND ISUSABLE='Usable' FOR UPDATE";

	public static Statetransactrel GetStateTransActRel(IDbContext dbContext, string statemodelid, string stateid, string tostateid, string actionid, string siteid)
	{
		string apiName = "GetStateTransActRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{statemodelid},{stateid},{tostateid},{actionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetStateTransActRelSqlDatabase : _sqlGetStateTransActRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("STATEMODELID", statemodelid, typeOfThis));
		list.Add(dbContext.CreateParameter("STATEID", stateid, typeOfThis));
		list.Add(dbContext.CreateParameter("TOSTATEID", tostateid, typeOfThis));
		list.Add(dbContext.CreateParameter("ACTIONID", actionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_STATETRANSACTREL", $"{statemodelid},{stateid},{tostateid},{actionid},{siteid}"));
		}
		Statetransactrel result = ContextManager.DirectEntityQuery<Statetransactrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{statemodelid},{stateid},{tostateid},{actionid},{siteid}");
		}
		return result;
	}

	public static Statetransactrel GetStateTransActRel4Update(IDbContext dbContext, string statemodelid, string stateid, string tostateid, string actionid, string siteid)
	{
		string apiName = "GetStateTransActRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{statemodelid},{stateid},{tostateid},{actionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetStateTransActRel4UpdateSqlDatabase : _sqlGetStateTransActRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("STATEMODELID", statemodelid, typeOfThis));
		list.Add(dbContext.CreateParameter("STATEID", stateid, typeOfThis));
		list.Add(dbContext.CreateParameter("TOSTATEID", tostateid, typeOfThis));
		list.Add(dbContext.CreateParameter("ACTIONID", actionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_STATETRANSACTREL", $"{statemodelid},{stateid},{tostateid},{actionid},{siteid}"));
		}
		Statetransactrel result = ContextManager.DirectEntityQuery<Statetransactrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{statemodelid},{stateid},{tostateid},{actionid},{siteid}");
		}
		return result;
	}

	public static Statetransactrel SelectStateTransActRel(IDbContext dbContext, string statemodelid, string stateid, string tostateid, string actionid, string siteid)
	{
		string apiName = "SelectStateTransActRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{statemodelid},{stateid},{tostateid},{actionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectStateTransActRelSqlDatabase : _sqlSelectStateTransActRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("STATEMODELID", statemodelid, typeOfThis));
		list.Add(dbContext.CreateParameter("STATEID", stateid, typeOfThis));
		list.Add(dbContext.CreateParameter("TOSTATEID", tostateid, typeOfThis));
		list.Add(dbContext.CreateParameter("ACTIONID", actionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_STATETRANSACTREL", $"{statemodelid},{stateid},{tostateid},{actionid},{siteid}"));
		}
		Statetransactrel result = ContextManager.DirectEntityQuery<Statetransactrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{statemodelid},{stateid},{tostateid},{actionid},{siteid}");
		}
		return result;
	}

	public static Statetransactrel SelectStateTransActRel4Update(IDbContext dbContext, string statemodelid, string stateid, string tostateid, string actionid, string siteid)
	{
		string apiName = "SelectStateTransActRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{statemodelid},{stateid},{tostateid},{actionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectStateTransActRel4UpdateSqlDatabase : _sqlSelectStateTransActRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("STATEMODELID", statemodelid, typeOfThis));
		list.Add(dbContext.CreateParameter("STATEID", stateid, typeOfThis));
		list.Add(dbContext.CreateParameter("TOSTATEID", tostateid, typeOfThis));
		list.Add(dbContext.CreateParameter("ACTIONID", actionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_STATETRANSACTREL", $"{statemodelid},{stateid},{tostateid},{actionid},{siteid}"));
		}
		Statetransactrel result = ContextManager.DirectEntityQuery<Statetransactrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{statemodelid},{stateid},{tostateid},{actionid},{siteid}");
		}
		return result;
	}

	public static IList<Statetransactrel> SelectStateTransActRelList(IDbContext dbContext, string stateModelId, string stateId, string toStateId, string siteId)
	{
		string apiName = "SelectStateTransActRelList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{stateModelId},{stateId},{toStateId},{siteId}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectStateTransActRelListSqlDatabase : _sqlSelectStateTransActRelListOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("STATEMODELID", stateModelId, typeOfThis));
		list.Add(dbContext.CreateParameter("STATEID", stateId, typeOfThis));
		list.Add(dbContext.CreateParameter("TOSTATEID", toStateId, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_STATETRANSACTREL", $"{stateModelId},{stateId},{toStateId},{siteId}"));
		}
		IList<Statetransactrel> result = ContextManager.DirectEntityQuery<Statetransactrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{stateModelId},{stateId},{toStateId},{siteId}");
		}
		return result;
	}

	public static IList<Statetransactrel> SelectStateTransActRelList4Update(IDbContext dbContext, string stateModelId, string stateId, string toStateId, string siteId)
	{
		string apiName = "SelectStateTransActRelList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{stateModelId},{stateId},{toStateId},{siteId}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectStateTransActRelList4UpdateSqlDatabase : _sqlSelectStateTransActRelList4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("STATEMODELID", stateModelId, typeOfThis));
		list.Add(dbContext.CreateParameter("STATEID", stateId, typeOfThis));
		list.Add(dbContext.CreateParameter("TOSTATEID", toStateId, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_STATETRANSACTREL", $"{stateModelId},{stateId},{toStateId},{siteId}"));
		}
		IList<Statetransactrel> result = ContextManager.DirectEntityQuery<Statetransactrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{stateModelId},{stateId},{toStateId},{siteId}");
		}
		return result;
	}

	public static int UpsertStateTransActRel(IDbContext dbContext, RequestType requestType, Statetransactrel[] stateTransActRelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateStateTransActRelInternal(dbContext, stateTransActRelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateStateTransActRel(dbContext, stateTransActRelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteStateTransActRel(dbContext, stateTransActRelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteStateTransActRel(dbContext, stateTransActRelList, optionSet, saveHist), 
			_ => RealDeleteStateTransActRel(dbContext, stateTransActRelList, optionSet, saveHist), 
		};
	}

	private static int CreateStateTransActRelInternal(IDbContext dbContext, Statetransactrel[] stateTransActRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("stateTransActRelList", stateTransActRelList);
		string text = "CreateStateTransActRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Statetransactrel> list = new List<Statetransactrel>();
		foreach (Statetransactrel obj in stateTransActRelList)
		{
			Statetransactrel statetransactrel = new Statetransactrel();
			obj.CopyColumsTo(statetransactrel);
			statetransactrel.Activity = text;
			statetransactrel.CheckEntityUsable();
			obj.CopyCommonField(statetransactrel, systemTime, dbContext.Tid, isCreate: true);
			list.Add(statetransactrel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateStateTransActRel(IDbContext dbContext, Statetransactrel[] stateTransActRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("stateTransActRelList", stateTransActRelList);
		string text = "UpdateStateTransActRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Statetransactrel> list = new List<Statetransactrel>();
		foreach (Statetransactrel statetransactrel in stateTransActRelList)
		{
			Statetransactrel stateTransActRel4Update = GetStateTransActRel4Update(dbContext, statetransactrel.Statemodelid, statetransactrel.Stateid, statetransactrel.Tostateid, statetransactrel.Actionid, statetransactrel.Siteid);
			if (stateTransActRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Statetransactrel), $"{statetransactrel.Statemodelid},{statetransactrel.Stateid},{statetransactrel.Tostateid},{statetransactrel.Actionid},{statetransactrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Statetransactrel), $"{statetransactrel.Statemodelid},{statetransactrel.Stateid},{statetransactrel.Tostateid},{statetransactrel.Actionid},{statetransactrel.Siteid}", stateTransActRel4Update.Isusable);
			string activity = stateTransActRel4Update.Activity;
			string customactivity = stateTransActRel4Update.Customactivity;
			string isusable = stateTransActRel4Update.Isusable;
			DateTime? createtime = stateTransActRel4Update.Createtime;
			string creator = stateTransActRel4Update.Creator;
			statetransactrel.CopyColumsTo(stateTransActRel4Update);
			stateTransActRel4Update.Prevactivity = activity;
			stateTransActRel4Update.Prevcustomactivity = customactivity;
			stateTransActRel4Update.Creator = creator;
			stateTransActRel4Update.Createtime = createtime;
			stateTransActRel4Update.Isusable = isusable;
			stateTransActRel4Update.Activity = text;
			statetransactrel.CopyCommonField(stateTransActRel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(stateTransActRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteStateTransActRel(IDbContext dbContext, Statetransactrel[] stateTransActRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("stateTransActRelList", stateTransActRelList);
		string text = "DeleteStateTransActRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Statetransactrel> list = new List<Statetransactrel>();
		foreach (Statetransactrel statetransactrel in stateTransActRelList)
		{
			Statetransactrel stateTransActRel4Update = GetStateTransActRel4Update(dbContext, statetransactrel.Statemodelid, statetransactrel.Stateid, statetransactrel.Tostateid, statetransactrel.Actionid, statetransactrel.Siteid);
			if (stateTransActRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Statetransactrel), $"{statetransactrel.Statemodelid},{statetransactrel.Stateid},{statetransactrel.Tostateid},{statetransactrel.Actionid},{statetransactrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Statetransactrel), $"{statetransactrel.Statemodelid},{statetransactrel.Stateid},{statetransactrel.Tostateid},{statetransactrel.Actionid},{statetransactrel.Siteid}", stateTransActRel4Update.Isusable);
			stateTransActRel4Update.Isusable = "UnUsable";
			statetransactrel.CopyCommonFieldUpdatePrev(stateTransActRel4Update, systemTime, dbContext.Tid, text);
			statetransactrel.CopyExtensionCollection(stateTransActRel4Update);
			list.Add(stateTransActRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteStateTransActRel(IDbContext dbContext, Statetransactrel[] stateTransActRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("stateTransActRelList", stateTransActRelList);
		string text = "UnDeleteStateTransActRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Statetransactrel> list = new List<Statetransactrel>();
		foreach (Statetransactrel statetransactrel in stateTransActRelList)
		{
			Statetransactrel stateTransActRel4Update = GetStateTransActRel4Update(dbContext, statetransactrel.Statemodelid, statetransactrel.Stateid, statetransactrel.Tostateid, statetransactrel.Actionid, statetransactrel.Siteid);
			if (stateTransActRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Statetransactrel), $"{statetransactrel.Statemodelid},{statetransactrel.Stateid},{statetransactrel.Tostateid},{statetransactrel.Actionid},{statetransactrel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Statetransactrel), $"{statetransactrel.Statemodelid},{statetransactrel.Stateid},{statetransactrel.Tostateid},{statetransactrel.Actionid},{statetransactrel.Siteid}", stateTransActRel4Update.Isusable);
			stateTransActRel4Update.Isusable = "Usable";
			statetransactrel.CopyCommonFieldUpdatePrev(stateTransActRel4Update, systemTime, dbContext.Tid, text);
			statetransactrel.CopyExtensionCollection(stateTransActRel4Update);
			list.Add(stateTransActRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteStateTransActRel(IDbContext dbContext, Statetransactrel[] stateTransActRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("stateTransActRelList", stateTransActRelList);
		string text = "RealDeleteStateTransActRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Statetransactrel> list = new List<Statetransactrel>();
		foreach (Statetransactrel statetransactrel in stateTransActRelList)
		{
			Statetransactrel stateTransActRel4Update = GetStateTransActRel4Update(dbContext, statetransactrel.Statemodelid, statetransactrel.Stateid, statetransactrel.Tostateid, statetransactrel.Actionid, statetransactrel.Siteid);
			if (stateTransActRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Statetransactrel), $"{statetransactrel.Statemodelid},{statetransactrel.Stateid},{statetransactrel.Tostateid},{statetransactrel.Actionid},{statetransactrel.Siteid}");
			}
			statetransactrel.CopyCommonFieldUpdatePrev(stateTransActRel4Update, systemTime, dbContext.Tid, text);
			statetransactrel.CopyExtensionCollection(stateTransActRel4Update);
			list.Add(stateTransActRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
