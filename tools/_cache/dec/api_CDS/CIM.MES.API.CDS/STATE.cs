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
public class STATE
{
	private static string _sqlGetStateSqlDatabase = "SELECT * FROM CIM_STATE WHERE STATEMODELID=@STATEMODELID AND STATEID=@STATEID AND SITEID=@SITEID";

	private static string _sqlGetState4UpdateSqlDatabase = "SELECT * FROM CIM_STATE WITH(UPDLOCK) WHERE STATEMODELID=@STATEMODELID AND STATEID=@STATEID AND SITEID=@SITEID";

	private static string _sqlSelectStateSqlDatabase = "SELECT * FROM CIM_STATE WHERE STATEMODELID=@STATEMODELID AND STATEID=@STATEID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectState4UpdateSqlDatabase = "SELECT * FROM CIM_STATE WITH(UPDLOCK) WHERE STATEMODELID=@STATEMODELID AND STATEID=@STATEID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetStateOracleDatabase = "SELECT * FROM CIM_STATE WHERE STATEMODELID=:STATEMODELID AND STATEID=:STATEID AND SITEID=:SITEID";

	private static string _sqlGetState4UpdateOracleDatabase = "SELECT * FROM CIM_STATE WHERE STATEMODELID=:STATEMODELID AND STATEID=:STATEID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectStateOracleDatabase = "SELECT * FROM CIM_STATE WHERE STATEMODELID=:STATEMODELID AND STATEID=:STATEID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectState4UpdateOracleDatabase = "SELECT * FROM CIM_STATE WHERE STATEMODELID=:STATEMODELID AND STATEID=:STATEID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(State);

	public static bool CheckStateTransition(IDbContext dbContext, string stateModelId, string stateId, string toStateId, string siteId)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("stateModelId", stateModelId);
		ParamChecker.ArgumentNotNull("stateId", stateId);
		ParamChecker.ArgumentNotNull("toStateId", toStateId);
		ParamChecker.ArgumentNotNull("siteid", siteId);
		if (STATETRANSITION.SelectStateTransition(dbContext, stateModelId, stateId, toStateId, siteId) != null)
		{
			return true;
		}
		return false;
	}

	public static bool CheckStateTransition(IDbContext dbContext, Type stateModelType, string stateId, string toStateId, string siteId)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("stateModelType", stateModelType);
		ParamChecker.ArgumentNotNull("stateId", stateId);
		ParamChecker.ArgumentNotNull("toStateId", toStateId);
		ParamChecker.ArgumentNotNull("siteid", siteId);
		if (STATETRANSITION.SelectStateTransition(dbContext, stateModelType.Name, stateId, toStateId, siteId) != null)
		{
			return true;
		}
		return false;
	}

	public static State GetState(IDbContext dbContext, string statemodelid, string stateid, string siteid)
	{
		string apiName = "GetState";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{statemodelid},{stateid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetStateSqlDatabase : _sqlGetStateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("STATEMODELID", statemodelid, typeOfThis));
		list.Add(dbContext.CreateParameter("STATEID", stateid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_STATE", $"{statemodelid},{stateid},{siteid}"));
		}
		State? result = ContextManager.DirectEntityQuery<State>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{statemodelid},{stateid},{siteid}");
		}
		return result;
	}

	public static State GetState4Update(IDbContext dbContext, string statemodelid, string stateid, string siteid)
	{
		string apiName = "GetState4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{statemodelid},{stateid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetState4UpdateSqlDatabase : _sqlGetState4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("STATEMODELID", statemodelid, typeOfThis));
		list.Add(dbContext.CreateParameter("STATEID", stateid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_STATE", $"{statemodelid},{stateid},{siteid}"));
		}
		State? result = ContextManager.DirectEntityQuery<State>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{statemodelid},{stateid},{siteid}");
		}
		return result;
	}

	public static State SelectState(IDbContext dbContext, string statemodelid, string stateid, string siteid)
	{
		string apiName = "SelectState";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{statemodelid},{stateid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectStateSqlDatabase : _sqlSelectStateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("STATEMODELID", statemodelid, typeOfThis));
		list.Add(dbContext.CreateParameter("STATEID", stateid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_STATE", $"{statemodelid},{stateid},{siteid}"));
		}
		State? result = ContextManager.DirectEntityQuery<State>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{statemodelid},{stateid},{siteid}");
		}
		return result;
	}

	public static State SelectState4Update(IDbContext dbContext, string statemodelid, string stateid, string siteid)
	{
		string apiName = "SelectState4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{statemodelid},{stateid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectState4UpdateSqlDatabase : _sqlSelectState4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("STATEMODELID", statemodelid, typeOfThis));
		list.Add(dbContext.CreateParameter("STATEID", stateid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_STATE", $"{statemodelid},{stateid},{siteid}"));
		}
		State? result = ContextManager.DirectEntityQuery<State>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{statemodelid},{stateid},{siteid}");
		}
		return result;
	}

	public static int UpsertState(IDbContext dbContext, RequestType requestType, State[] stateList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateStateInternal(dbContext, stateList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateState(dbContext, stateList, optionSet, saveHist), 
			RequestType.DELETE => DeleteState(dbContext, stateList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteState(dbContext, stateList, optionSet, saveHist), 
			_ => RealDeleteState(dbContext, stateList, optionSet, saveHist), 
		};
	}

	private static int CreateStateInternal(IDbContext dbContext, State[] stateList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("stateList", stateList);
		string text = "CreateState";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<State> list = new List<State>();
		foreach (State obj in stateList)
		{
			State state = new State();
			obj.CopyColumsTo(state);
			state.Activity = text;
			state.CheckEntityUsable();
			obj.CopyCommonField(state, systemTime, dbContext.Tid, isCreate: true);
			list.Add(state);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateState(IDbContext dbContext, State[] stateList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("stateList", stateList);
		string text = "UpdateState";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<State> list = new List<State>();
		foreach (State state in stateList)
		{
			State state4Update = GetState4Update(dbContext, state.Statemodelid, state.Stateid, state.Siteid);
			if (state4Update == null)
			{
				throw new EntityNotFoundException(typeof(State), $"{state.Statemodelid},{state.Stateid},{state.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(State), $"{state.Statemodelid},{state.Stateid},{state.Siteid}", state4Update.Isusable);
			string activity = state4Update.Activity;
			string customactivity = state4Update.Customactivity;
			string isusable = state4Update.Isusable;
			DateTime? createtime = state4Update.Createtime;
			string creator = state4Update.Creator;
			state.CopyColumsTo(state4Update);
			state4Update.Prevactivity = activity;
			state4Update.Prevcustomactivity = customactivity;
			state4Update.Creator = creator;
			state4Update.Createtime = createtime;
			state4Update.Isusable = isusable;
			state4Update.Activity = text;
			state.CopyCommonField(state4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(state4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteState(IDbContext dbContext, State[] stateList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("stateList", stateList);
		string text = "DeleteState";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<State> list = new List<State>();
		foreach (State state in stateList)
		{
			State state4Update = GetState4Update(dbContext, state.Statemodelid, state.Stateid, state.Siteid);
			if (state4Update == null)
			{
				throw new EntityNotFoundException(typeof(State), $"{state.Statemodelid},{state.Stateid},{state.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(State), $"{state.Statemodelid},{state.Stateid},{state.Siteid}", state4Update.Isusable);
			state4Update.Isusable = "UnUsable";
			state.CopyCommonFieldUpdatePrev(state4Update, systemTime, dbContext.Tid, text);
			state.CopyExtensionCollection(state4Update);
			list.Add(state4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteState(IDbContext dbContext, State[] stateList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("stateList", stateList);
		string text = "UnDeleteState";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<State> list = new List<State>();
		foreach (State state in stateList)
		{
			State state4Update = GetState4Update(dbContext, state.Statemodelid, state.Stateid, state.Siteid);
			if (state4Update == null)
			{
				throw new EntityNotFoundException(typeof(State), $"{state.Statemodelid},{state.Stateid},{state.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(State), $"{state.Statemodelid},{state.Stateid},{state.Siteid}", state4Update.Isusable);
			state4Update.Isusable = "Usable";
			state.CopyCommonFieldUpdatePrev(state4Update, systemTime, dbContext.Tid, text);
			state.CopyExtensionCollection(state4Update);
			list.Add(state4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteState(IDbContext dbContext, State[] stateList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("stateList", stateList);
		string text = "RealDeleteState";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<State> list = new List<State>();
		foreach (State state in stateList)
		{
			State state4Update = GetState4Update(dbContext, state.Statemodelid, state.Stateid, state.Siteid);
			if (state4Update == null)
			{
				throw new EntityNotFoundException(typeof(State), $"{state.Statemodelid},{state.Stateid},{state.Siteid}");
			}
			state.CopyCommonFieldUpdatePrev(state4Update, systemTime, dbContext.Tid, text);
			state.CopyExtensionCollection(state4Update);
			list.Add(state4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
