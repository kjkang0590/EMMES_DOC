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
public class STATETRANSITION
{
	private static string _sqlGetStateTransitionSqlDatabase = "SELECT * FROM CIM_STATETRANSITION WHERE STATEMODELID=@STATEMODELID AND STATEID=@STATEID AND TOSTATEID=@TOSTATEID AND SITEID=@SITEID";

	private static string _sqlGetStateTransition4UpdateSqlDatabase = "SELECT * FROM CIM_STATETRANSITION WITH(UPDLOCK) WHERE STATEMODELID=@STATEMODELID AND STATEID=@STATEID AND TOSTATEID=@TOSTATEID AND SITEID=@SITEID";

	private static string _sqlSelectStateTransitionSqlDatabase = "SELECT * FROM CIM_STATETRANSITION WHERE STATEMODELID=@STATEMODELID AND STATEID=@STATEID AND TOSTATEID=@TOSTATEID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectStateTransition4UpdateSqlDatabase = "SELECT * FROM CIM_STATETRANSITION WITH(UPDLOCK) WHERE STATEMODELID=@STATEMODELID AND STATEID=@STATEID AND TOSTATEID=@TOSTATEID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetStateTransitionOracleDatabase = "SELECT * FROM CIM_STATETRANSITION WHERE STATEMODELID=:STATEMODELID AND STATEID=:STATEID AND TOSTATEID=:TOSTATEID AND SITEID=:SITEID";

	private static string _sqlGetStateTransition4UpdateOracleDatabase = "SELECT * FROM CIM_STATETRANSITION WHERE STATEMODELID=:STATEMODELID AND STATEID=:STATEID AND TOSTATEID=:TOSTATEID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectStateTransitionOracleDatabase = "SELECT * FROM CIM_STATETRANSITION WHERE STATEMODELID=:STATEMODELID AND STATEID=:STATEID AND TOSTATEID=:TOSTATEID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectStateTransition4UpdateOracleDatabase = "SELECT * FROM CIM_STATETRANSITION WHERE STATEMODELID=:STATEMODELID AND STATEID=:STATEID AND TOSTATEID=:TOSTATEID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Statetransition);

	private static string _sqlSelectStateTransitionListSqlDatabase = "SELECT * FROM CIM_STATETRANSITION WHERE STATEMODELID = @STATEMODELID AND STATEID = @STATEID AND ISDEFAULT = @ISDEFAULT AND SITEID = @SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectStateTransitionList4UpdateSqlDatabase = "SELECT * FROM CIM_STATETRANSITION WITH(UPDLOCK) WHERE STATEMODELID = @STATEMODELID AND STATEID = @STATEID AND ISDEFAULT = @ISDEFAULT AND SITEID = @SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectStateTransitionListOracleDatabase = "SELECT * FROM CIM_STATETRANSITION WHERE STATEMODELID = :STATEMODELID AND STATEID = :STATEID AND ISDEFAULT = :ISDEFAULT AND SITEID = :SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectStateTransitionList4UpdateOracleDatabase = "SELECT * FROM CIM_STATETRANSITION WHERE STATEMODELID = :STATEMODELID AND STATEID = :STATEID AND ISDEFAULT = :ISDEFAULT AND SITEID = :SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static string _sqlSelectStateTransitionListAllSqlDatabase = "SELECT * FROM CIM_STATETRANSITION WHERE STATEMODELID = @STATEMODELID AND STATEID = @STATEID AND SITEID = @SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectStateTransitionListAll4UpdateSqlDatabase = "SELECT * FROM CIM_STATETRANSITION WITH(UPDLOCK) WHERE STATEMODELID = @STATEMODELID AND STATEID = @STATEID AND SITEID = @SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectStateTransitionListAllOracleDatabase = "SELECT * FROM CIM_STATETRANSITION WHERE STATEMODELID = :STATEMODELID AND STATEID = :STATEID AND SITEID = :SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectStateTransitionListAll4UpdateOracleDatabase = "SELECT * FROM CIM_STATETRANSITION WHERE STATEMODELID = :STATEMODELID AND STATEID = :STATEID AND SITEID = :SITEID AND ISUSABLE='Usable' FOR UPDATE";

	public static Statetransition GetStateTransition(IDbContext dbContext, string statemodelid, string stateid, string tostateid, string siteid)
	{
		string apiName = "GetStateTransition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{statemodelid},{stateid},{tostateid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetStateTransitionSqlDatabase : _sqlGetStateTransitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("STATEMODELID", statemodelid, typeOfThis));
		list.Add(dbContext.CreateParameter("STATEID", stateid, typeOfThis));
		list.Add(dbContext.CreateParameter("TOSTATEID", tostateid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_STATETRANSITION", $"{statemodelid},{stateid},{tostateid},{siteid}"));
		}
		Statetransition result = ContextManager.DirectEntityQuery<Statetransition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{statemodelid},{stateid},{tostateid},{siteid}");
		}
		return result;
	}

	public static Statetransition GetStateTransition4Update(IDbContext dbContext, string statemodelid, string stateid, string tostateid, string siteid)
	{
		string apiName = "GetStateTransition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{statemodelid},{stateid},{tostateid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetStateTransition4UpdateSqlDatabase : _sqlGetStateTransition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("STATEMODELID", statemodelid, typeOfThis));
		list.Add(dbContext.CreateParameter("STATEID", stateid, typeOfThis));
		list.Add(dbContext.CreateParameter("TOSTATEID", tostateid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_STATETRANSITION", $"{statemodelid},{stateid},{tostateid},{siteid}"));
		}
		Statetransition result = ContextManager.DirectEntityQuery<Statetransition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{statemodelid},{stateid},{tostateid},{siteid}");
		}
		return result;
	}

	public static Statetransition SelectStateTransition(IDbContext dbContext, string statemodelid, string stateid, string tostateid, string siteid)
	{
		string apiName = "SelectStateTransition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{statemodelid},{stateid},{tostateid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectStateTransitionSqlDatabase : _sqlSelectStateTransitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("STATEMODELID", statemodelid, typeOfThis));
		list.Add(dbContext.CreateParameter("STATEID", stateid, typeOfThis));
		list.Add(dbContext.CreateParameter("TOSTATEID", tostateid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_STATETRANSITION", $"{statemodelid},{stateid},{tostateid},{siteid}"));
		}
		Statetransition result = ContextManager.DirectEntityQuery<Statetransition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{statemodelid},{stateid},{tostateid},{siteid}");
		}
		return result;
	}

	public static Statetransition SelectStateTransition4Update(IDbContext dbContext, string statemodelid, string stateid, string tostateid, string siteid)
	{
		string apiName = "SelectStateTransition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{statemodelid},{stateid},{tostateid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectStateTransition4UpdateSqlDatabase : _sqlSelectStateTransition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("STATEMODELID", statemodelid, typeOfThis));
		list.Add(dbContext.CreateParameter("STATEID", stateid, typeOfThis));
		list.Add(dbContext.CreateParameter("TOSTATEID", tostateid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_STATETRANSITION", $"{statemodelid},{stateid},{tostateid},{siteid}"));
		}
		Statetransition result = ContextManager.DirectEntityQuery<Statetransition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{statemodelid},{stateid},{tostateid},{siteid}");
		}
		return result;
	}

	public static IList<Statetransition> SelectStateTransitionList(IDbContext dbContext, string stateModelId, string stateId, bool stateDirection, string siteId)
	{
		string apiName = "SelectStateTransitionList";
		string text = (stateDirection ? "Y" : "N");
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{stateModelId},{stateId},{text},{siteId}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectStateTransitionListSqlDatabase : _sqlSelectStateTransitionListOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("STATEMODELID", stateModelId, typeOfThis));
		list.Add(dbContext.CreateParameter("STATEID", stateId, typeOfThis));
		list.Add(dbContext.CreateParameter("ISDEFAULT", text, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_STATETRANSITION", $"{stateModelId},{stateId},{text},{siteId}"));
		}
		IList<Statetransition> result = ContextManager.DirectEntityQuery<Statetransition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{stateModelId},{stateId},{text},{siteId}");
		}
		return result;
	}

	public static IList<Statetransition> SelectStateTransitionListForUpdate(IDbContext dbContext, string stateModelId, string stateId, bool stateDirection, string siteId)
	{
		string apiName = "SelectStateTransitionList";
		string text = (stateDirection ? "Y" : "N");
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{stateModelId},{stateId},{text},{siteId}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectStateTransitionList4UpdateSqlDatabase : _sqlSelectStateTransitionList4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("STATEMODELID", stateModelId, typeOfThis));
		list.Add(dbContext.CreateParameter("STATEID", stateId, typeOfThis));
		list.Add(dbContext.CreateParameter("ISDEFAULT", text, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_STATETRANSITION", $"{stateModelId},{stateId},{text},{siteId}"));
		}
		IList<Statetransition> result = ContextManager.DirectEntityQuery<Statetransition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{stateModelId},{stateId},{text},{siteId}");
		}
		return result;
	}

	public static IList<Statetransition> SelectStateTransitionListAll(IDbContext dbContext, string stateModelId, string stateId, string siteId)
	{
		string apiName = "SelectStateTransitionListAll";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{stateModelId},{stateId},{siteId}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectStateTransitionListAllSqlDatabase : _sqlSelectStateTransitionListAllOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("STATEMODELID", stateModelId, typeOfThis));
		list.Add(dbContext.CreateParameter("STATEID", stateId, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_STATETRANSITION", $"{stateModelId},{stateId},{siteId}"));
		}
		IList<Statetransition> result = ContextManager.DirectEntityQuery<Statetransition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{stateModelId},{stateId},{siteId}");
		}
		return result;
	}

	public static IList<Statetransition> SelectStateTransitionListAllForUpdate(IDbContext dbContext, string stateModelId, string stateId, string siteId)
	{
		string apiName = "SelectStateTransitionListAll";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{stateModelId},{stateId},{siteId}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectStateTransitionListAll4UpdateSqlDatabase : _sqlSelectStateTransitionListAll4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("STATEMODELID", stateModelId, typeOfThis));
		list.Add(dbContext.CreateParameter("STATEID", stateId, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_STATETRANSITION", $"{stateModelId},{stateId},{siteId}"));
		}
		IList<Statetransition> result = ContextManager.DirectEntityQuery<Statetransition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{stateModelId},{stateId},{siteId}");
		}
		return result;
	}

	public static int UpsertStateTransition(IDbContext dbContext, RequestType requestType, Statetransition[] stateTransitionList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateStateTransitionInternal(dbContext, stateTransitionList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateStateTransition(dbContext, stateTransitionList, optionSet, saveHist), 
			RequestType.DELETE => DeleteStateTransition(dbContext, stateTransitionList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteStateTransition(dbContext, stateTransitionList, optionSet, saveHist), 
			_ => RealDeleteStateTransition(dbContext, stateTransitionList, optionSet, saveHist), 
		};
	}

	private static int CreateStateTransitionInternal(IDbContext dbContext, Statetransition[] stateTransitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("stateTransitionList", stateTransitionList);
		string text = "CreateStateTransition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Statetransition> list = new List<Statetransition>();
		foreach (Statetransition obj in stateTransitionList)
		{
			Statetransition statetransition = new Statetransition();
			obj.CopyColumsTo(statetransition);
			statetransition.Activity = text;
			statetransition.CheckEntityUsable();
			obj.CopyCommonField(statetransition, systemTime, dbContext.Tid, isCreate: true);
			list.Add(statetransition);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateStateTransition(IDbContext dbContext, Statetransition[] stateTransitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("stateTransitionList", stateTransitionList);
		string text = "UpdateStateTransition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Statetransition> list = new List<Statetransition>();
		foreach (Statetransition statetransition in stateTransitionList)
		{
			Statetransition stateTransition4Update = GetStateTransition4Update(dbContext, statetransition.Statemodelid, statetransition.Stateid, statetransition.Tostateid, statetransition.Siteid);
			if (stateTransition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Statetransition), $"{statetransition.Statemodelid},{statetransition.Stateid},{statetransition.Tostateid},{statetransition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Statetransition), $"{statetransition.Statemodelid},{statetransition.Stateid},{statetransition.Tostateid},{statetransition.Siteid}", stateTransition4Update.Isusable);
			string activity = stateTransition4Update.Activity;
			string customactivity = stateTransition4Update.Customactivity;
			string isusable = stateTransition4Update.Isusable;
			DateTime? createtime = stateTransition4Update.Createtime;
			string creator = stateTransition4Update.Creator;
			statetransition.CopyColumsTo(stateTransition4Update);
			stateTransition4Update.Prevactivity = activity;
			stateTransition4Update.Prevcustomactivity = customactivity;
			stateTransition4Update.Creator = creator;
			stateTransition4Update.Createtime = createtime;
			stateTransition4Update.Isusable = isusable;
			stateTransition4Update.Activity = text;
			statetransition.CopyCommonField(stateTransition4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(stateTransition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteStateTransition(IDbContext dbContext, Statetransition[] stateTransitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("stateTransitionList", stateTransitionList);
		string text = "DeleteStateTransition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Statetransition> list = new List<Statetransition>();
		foreach (Statetransition statetransition in stateTransitionList)
		{
			Statetransition stateTransition4Update = GetStateTransition4Update(dbContext, statetransition.Statemodelid, statetransition.Stateid, statetransition.Tostateid, statetransition.Siteid);
			if (stateTransition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Statetransition), $"{statetransition.Statemodelid},{statetransition.Stateid},{statetransition.Tostateid},{statetransition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Statetransition), $"{statetransition.Statemodelid},{statetransition.Stateid},{statetransition.Tostateid},{statetransition.Siteid}", stateTransition4Update.Isusable);
			stateTransition4Update.Isusable = "UnUsable";
			statetransition.CopyCommonFieldUpdatePrev(stateTransition4Update, systemTime, dbContext.Tid, text);
			statetransition.CopyExtensionCollection(stateTransition4Update);
			list.Add(stateTransition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteStateTransition(IDbContext dbContext, Statetransition[] stateTransitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("stateTransitionList", stateTransitionList);
		string text = "UnDeleteStateTransition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Statetransition> list = new List<Statetransition>();
		foreach (Statetransition statetransition in stateTransitionList)
		{
			Statetransition stateTransition4Update = GetStateTransition4Update(dbContext, statetransition.Statemodelid, statetransition.Stateid, statetransition.Tostateid, statetransition.Siteid);
			if (stateTransition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Statetransition), $"{statetransition.Statemodelid},{statetransition.Stateid},{statetransition.Tostateid},{statetransition.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Statetransition), $"{statetransition.Statemodelid},{statetransition.Stateid},{statetransition.Tostateid},{statetransition.Siteid}", stateTransition4Update.Isusable);
			stateTransition4Update.Isusable = "Usable";
			statetransition.CopyCommonFieldUpdatePrev(stateTransition4Update, systemTime, dbContext.Tid, text);
			statetransition.CopyExtensionCollection(stateTransition4Update);
			list.Add(stateTransition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteStateTransition(IDbContext dbContext, Statetransition[] stateTransitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("stateTransitionList", stateTransitionList);
		string text = "RealDeleteStateTransition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Statetransition> list = new List<Statetransition>();
		foreach (Statetransition statetransition in stateTransitionList)
		{
			Statetransition stateTransition4Update = GetStateTransition4Update(dbContext, statetransition.Statemodelid, statetransition.Stateid, statetransition.Tostateid, statetransition.Siteid);
			if (stateTransition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Statetransition), $"{statetransition.Statemodelid},{statetransition.Stateid},{statetransition.Tostateid},{statetransition.Siteid}");
			}
			statetransition.CopyCommonFieldUpdatePrev(stateTransition4Update, systemTime, dbContext.Tid, text);
			statetransition.CopyExtensionCollection(stateTransition4Update);
			list.Add(stateTransition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
