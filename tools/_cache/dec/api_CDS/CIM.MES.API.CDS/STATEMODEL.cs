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
public class STATEMODEL
{
	private static string _sqlGetStateModelSqlDatabase = "SELECT * FROM CIM_STATEMODEL WHERE STATEMODELID=@STATEMODELID AND SITEID=@SITEID";

	private static string _sqlGetStateModel4UpdateSqlDatabase = "SELECT * FROM CIM_STATEMODEL WITH(UPDLOCK) WHERE STATEMODELID=@STATEMODELID AND SITEID=@SITEID";

	private static string _sqlSelectStateModelSqlDatabase = "SELECT * FROM CIM_STATEMODEL WHERE STATEMODELID=@STATEMODELID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectStateModel4UpdateSqlDatabase = "SELECT * FROM CIM_STATEMODEL WITH(UPDLOCK) WHERE STATEMODELID=@STATEMODELID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetStateModelOracleDatabase = "SELECT * FROM CIM_STATEMODEL WHERE STATEMODELID=:STATEMODELID AND SITEID=:SITEID";

	private static string _sqlGetStateModel4UpdateOracleDatabase = "SELECT * FROM CIM_STATEMODEL WHERE STATEMODELID=:STATEMODELID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectStateModelOracleDatabase = "SELECT * FROM CIM_STATEMODEL WHERE STATEMODELID=:STATEMODELID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectStateModel4UpdateOracleDatabase = "SELECT * FROM CIM_STATEMODEL WHERE STATEMODELID=:STATEMODELID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Statemodel);

	public static Statemodel GetStateModel(IDbContext dbContext, string statemodelid, string siteid)
	{
		string apiName = "GetStateModel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{statemodelid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetStateModelSqlDatabase : _sqlGetStateModelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("STATEMODELID", statemodelid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_STATEMODEL", $"{statemodelid},{siteid}"));
		}
		Statemodel? result = ContextManager.DirectEntityQuery<Statemodel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{statemodelid},{siteid}");
		}
		return result;
	}

	public static Statemodel GetStateModel4Update(IDbContext dbContext, string statemodelid, string siteid)
	{
		string apiName = "GetStateModel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{statemodelid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetStateModel4UpdateSqlDatabase : _sqlGetStateModel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("STATEMODELID", statemodelid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_STATEMODEL", $"{statemodelid},{siteid}"));
		}
		Statemodel? result = ContextManager.DirectEntityQuery<Statemodel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{statemodelid},{siteid}");
		}
		return result;
	}

	public static Statemodel SelectStateModel(IDbContext dbContext, string statemodelid, string siteid)
	{
		string apiName = "SelectStateModel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{statemodelid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectStateModelSqlDatabase : _sqlSelectStateModelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("STATEMODELID", statemodelid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_STATEMODEL", $"{statemodelid},{siteid}"));
		}
		Statemodel? result = ContextManager.DirectEntityQuery<Statemodel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{statemodelid},{siteid}");
		}
		return result;
	}

	public static Statemodel SelectStateModel4Update(IDbContext dbContext, string statemodelid, string siteid)
	{
		string apiName = "SelectStateModel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{statemodelid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectStateModel4UpdateSqlDatabase : _sqlSelectStateModel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("STATEMODELID", statemodelid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_STATEMODEL", $"{statemodelid},{siteid}"));
		}
		Statemodel? result = ContextManager.DirectEntityQuery<Statemodel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{statemodelid},{siteid}");
		}
		return result;
	}

	public static int UpsertStateModel(IDbContext dbContext, RequestType requestType, Statemodel[] stateModelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateStateModelInternal(dbContext, stateModelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateStateModel(dbContext, stateModelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteStateModel(dbContext, stateModelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteStateModel(dbContext, stateModelList, optionSet, saveHist), 
			_ => RealDeleteStateModel(dbContext, stateModelList, optionSet, saveHist), 
		};
	}

	private static int CreateStateModelInternal(IDbContext dbContext, Statemodel[] stateModelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("stateModelList", stateModelList);
		string text = "CreateStateModel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Statemodel> list = new List<Statemodel>();
		foreach (Statemodel obj in stateModelList)
		{
			Statemodel statemodel = new Statemodel();
			obj.CopyColumsTo(statemodel);
			statemodel.Activity = text;
			statemodel.CheckEntityUsable();
			obj.CopyCommonField(statemodel, systemTime, dbContext.Tid, isCreate: true);
			list.Add(statemodel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateStateModel(IDbContext dbContext, Statemodel[] stateModelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("stateModelList", stateModelList);
		string text = "UpdateStateModel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Statemodel> list = new List<Statemodel>();
		foreach (Statemodel statemodel in stateModelList)
		{
			Statemodel stateModel4Update = GetStateModel4Update(dbContext, statemodel.Statemodelid, statemodel.Siteid);
			if (stateModel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Statemodel), $"{statemodel.Statemodelid},{statemodel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Statemodel), $"{statemodel.Statemodelid},{statemodel.Siteid}", stateModel4Update.Isusable);
			string activity = stateModel4Update.Activity;
			string customactivity = stateModel4Update.Customactivity;
			string isusable = stateModel4Update.Isusable;
			DateTime? createtime = stateModel4Update.Createtime;
			string creator = stateModel4Update.Creator;
			statemodel.CopyColumsTo(stateModel4Update);
			stateModel4Update.Prevactivity = activity;
			stateModel4Update.Prevcustomactivity = customactivity;
			stateModel4Update.Creator = creator;
			stateModel4Update.Createtime = createtime;
			stateModel4Update.Isusable = isusable;
			stateModel4Update.Activity = text;
			statemodel.CopyCommonField(stateModel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(stateModel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteStateModel(IDbContext dbContext, Statemodel[] stateModelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("stateModelList", stateModelList);
		string text = "DeleteStateModel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Statemodel> list = new List<Statemodel>();
		foreach (Statemodel statemodel in stateModelList)
		{
			Statemodel stateModel4Update = GetStateModel4Update(dbContext, statemodel.Statemodelid, statemodel.Siteid);
			if (stateModel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Statemodel), $"{statemodel.Statemodelid},{statemodel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Statemodel), $"{statemodel.Statemodelid},{statemodel.Siteid}", stateModel4Update.Isusable);
			stateModel4Update.Isusable = "UnUsable";
			statemodel.CopyCommonFieldUpdatePrev(stateModel4Update, systemTime, dbContext.Tid, text);
			statemodel.CopyExtensionCollection(stateModel4Update);
			list.Add(stateModel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteStateModel(IDbContext dbContext, Statemodel[] stateModelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("stateModelList", stateModelList);
		string text = "UnDeleteStateModel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Statemodel> list = new List<Statemodel>();
		foreach (Statemodel statemodel in stateModelList)
		{
			Statemodel stateModel4Update = GetStateModel4Update(dbContext, statemodel.Statemodelid, statemodel.Siteid);
			if (stateModel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Statemodel), $"{statemodel.Statemodelid},{statemodel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Statemodel), $"{statemodel.Statemodelid},{statemodel.Siteid}", stateModel4Update.Isusable);
			stateModel4Update.Isusable = "Usable";
			statemodel.CopyCommonFieldUpdatePrev(stateModel4Update, systemTime, dbContext.Tid, text);
			statemodel.CopyExtensionCollection(stateModel4Update);
			list.Add(stateModel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteStateModel(IDbContext dbContext, Statemodel[] stateModelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("stateModelList", stateModelList);
		string text = "RealDeleteStateModel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Statemodel> list = new List<Statemodel>();
		foreach (Statemodel statemodel in stateModelList)
		{
			Statemodel stateModel4Update = GetStateModel4Update(dbContext, statemodel.Statemodelid, statemodel.Siteid);
			if (stateModel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Statemodel), $"{statemodel.Statemodelid},{statemodel.Siteid}");
			}
			statemodel.CopyCommonFieldUpdatePrev(stateModel4Update, systemTime, dbContext.Tid, text);
			statemodel.CopyExtensionCollection(stateModel4Update);
			list.Add(stateModel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
