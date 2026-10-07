using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;
using CIM.Util.SPC;

namespace CIM.MES.API.QMS;

[MESAPI]
public class SPCDATAQUEUE
{
	private static string _sqlGetSpcDataQueueSqlDatabaseDynamicCondition = "SELECT * FROM CIM_SPCDATAQUEUE WHERE SITEID=@SITEID";

	private static string _sqlSelectSpcDataQueueSqlDatabaseDynamicCondition = "SELECT * FROM CIM_SPCDATAQUEUE WHERE SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetSpcDataQueueOracleDatabaseDynamicCondition = "SELECT * FROM CIM_SPCDATAQUEUE WHERE SITEID=:SITEID";

	private static string _sqlSelectSpcDataQueueOracleDatabaseDynamicCondition = "SELECT * FROM CIM_SPCDATAQUEUE WHERE SITEID=:SITEID AND ISUSABLE='Usable'";

	private static Type typeOfThis = typeof(Spcdataqueue);

	private static string _sqlGetSpcDataQueueSqlDatabase = "SELECT * FROM CIM_SPCDATAQUEUE WHERE SPCDATAQUEUESYSID=@SPCDATAQUEUESYSID AND SITEID=@SITEID";

	private static string _sqlGetSpcDataQueue4UpdateSqlDatabase = "SELECT * FROM CIM_SPCDATAQUEUE WITH(UPDLOCK) WHERE SPCDATAQUEUESYSID=@SPCDATAQUEUESYSID AND SITEID=@SITEID";

	private static string _sqlSelectSpcDataQueueSqlDatabase = "SELECT * FROM CIM_SPCDATAQUEUE WHERE SPCDATAQUEUESYSID=@SPCDATAQUEUESYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectSpcDataQueue4UpdateSqlDatabase = "SELECT * FROM CIM_SPCDATAQUEUE WITH(UPDLOCK) WHERE SPCDATAQUEUESYSID=@SPCDATAQUEUESYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetSpcDataQueueOracleDatabase = "SELECT * FROM CIM_SPCDATAQUEUE WHERE SPCDATAQUEUESYSID=:SPCDATAQUEUESYSID AND SITEID=:SITEID";

	private static string _sqlGetSpcDataQueue4UpdateOracleDatabase = "SELECT * FROM CIM_SPCDATAQUEUE WHERE SPCDATAQUEUESYSID=:SPCDATAQUEUESYSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectSpcDataQueueOracleDatabase = "SELECT * FROM CIM_SPCDATAQUEUE WHERE SPCDATAQUEUESYSID=:SPCDATAQUEUESYSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectSpcDataQueue4UpdateOracleDatabase = "SELECT * FROM CIM_SPCDATAQUEUE WHERE SPCDATAQUEUESYSID=:SPCDATAQUEUESYSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	public static IList<Spcdataqueue> GetSpcDataQueueWithDynamicCondition(IDbContext dbContext, Dictionary<string, string> dynamicCondition, string siteid)
	{
		string apiName = "GetSpcDataQueueWithDynamicCondition";
		string strKeyFieldInfo = string.Join(",", dynamicCondition.ToArray());
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{strKeyFieldInfo},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetSpcDataQueueSqlDatabaseDynamicCondition : _sqlGetSpcDataQueueOracleDatabaseDynamicCondition);
		sql = SpcUtil.AddSqlCondition(dbContext.DbType.ToString(), sql, dynamicCondition);
		dynamicCondition.Add("SITEID", siteid);
		ExtendCondition(dbContext, dynamicCondition, out var parameters, out strKeyFieldInfo);
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SPCDATAQUEUE", $"{strKeyFieldInfo},{siteid}"));
		}
		IList<Spcdataqueue> result = ContextManager.DirectEntityQuery<Spcdataqueue>(dbContext, sql, parameters.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{strKeyFieldInfo},{siteid}");
		}
		return result;
	}

	public static IList<Spcdataqueue> SelectSpcDataQueueWithDynamicCondition(IDbContext dbContext, Dictionary<string, string> dynamicCondition, string siteid)
	{
		string apiName = "SelectSpcDataQueueWithDynamicCondition";
		string strKeyFieldInfo = string.Join(",", dynamicCondition.ToArray());
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{strKeyFieldInfo},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectSpcDataQueueSqlDatabaseDynamicCondition : _sqlSelectSpcDataQueueOracleDatabaseDynamicCondition);
		sql = SpcUtil.AddSqlCondition(dbContext.DbType.ToString(), sql, dynamicCondition);
		dynamicCondition.Add("SITEID", siteid);
		ExtendCondition(dbContext, dynamicCondition, out var parameters, out strKeyFieldInfo);
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SPCDATAQUEUE", $"{strKeyFieldInfo},{siteid}"));
		}
		IList<Spcdataqueue> result = ContextManager.DirectEntityQuery<Spcdataqueue>(dbContext, sql, parameters.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{strKeyFieldInfo},{siteid}");
		}
		return result;
	}

	private static void ExtendCondition(IDbContext dbContext, Dictionary<string, string> dynamicCondition, out List<MesParameter> parameters, out string strKeyFieldInfo)
	{
		parameters = new List<MesParameter>();
		List<string> list = new List<string>();
		strKeyFieldInfo = null;
		foreach (string key in dynamicCondition.Keys)
		{
			parameters.Add(dbContext.CreateParameter(key, dynamicCondition[key], typeOfThis));
			list.Add(key + ":" + dynamicCondition[key]);
		}
		strKeyFieldInfo = string.Join(",", list.ToArray());
	}

	public static Spcdataqueue GetSpcDataQueue(IDbContext dbContext, long spcdataqueuesysid, string siteid)
	{
		string apiName = "GetSpcDataQueue";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{spcdataqueuesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetSpcDataQueueSqlDatabase : _sqlGetSpcDataQueueOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SPCDATAQUEUESYSID", spcdataqueuesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SPCDATAQUEUE", $"{spcdataqueuesysid},{siteid}"));
		}
		Spcdataqueue? result = ContextManager.DirectEntityQuery<Spcdataqueue>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{spcdataqueuesysid},{siteid}");
		}
		return result;
	}

	public static Spcdataqueue GetSpcDataQueue4Update(IDbContext dbContext, long spcdataqueuesysid, string siteid)
	{
		string apiName = "GetSpcDataQueue4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{spcdataqueuesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetSpcDataQueue4UpdateSqlDatabase : _sqlGetSpcDataQueue4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SPCDATAQUEUESYSID", spcdataqueuesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_SPCDATAQUEUE", $"{spcdataqueuesysid},{siteid}"));
		}
		Spcdataqueue? result = ContextManager.DirectEntityQuery<Spcdataqueue>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{spcdataqueuesysid},{siteid}");
		}
		return result;
	}

	public static Spcdataqueue SelectSpcDataQueue(IDbContext dbContext, long spcdataqueuesysid, string siteid)
	{
		string apiName = "SelectSpcDataQueue";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{spcdataqueuesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectSpcDataQueueSqlDatabase : _sqlSelectSpcDataQueueOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SPCDATAQUEUESYSID", spcdataqueuesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SPCDATAQUEUE", $"{spcdataqueuesysid},{siteid}"));
		}
		Spcdataqueue? result = ContextManager.DirectEntityQuery<Spcdataqueue>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{spcdataqueuesysid},{siteid}");
		}
		return result;
	}

	public static Spcdataqueue SelectSpcDataQueue4Update(IDbContext dbContext, long spcdataqueuesysid, string siteid)
	{
		string apiName = "SelectSpcDataQueue4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{spcdataqueuesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectSpcDataQueue4UpdateSqlDatabase : _sqlSelectSpcDataQueue4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SPCDATAQUEUESYSID", spcdataqueuesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_SPCDATAQUEUE", $"{spcdataqueuesysid},{siteid}"));
		}
		Spcdataqueue? result = ContextManager.DirectEntityQuery<Spcdataqueue>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{spcdataqueuesysid},{siteid}");
		}
		return result;
	}

	public static int UpsertSpcDataQueue(IDbContext dbContext, RequestType requestType, Spcdataqueue[] spcDataQueueList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateSpcDataQueueInternal(dbContext, spcDataQueueList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateSpcDataQueue(dbContext, spcDataQueueList, optionSet, saveHist), 
			RequestType.DELETE => DeleteSpcDataQueue(dbContext, spcDataQueueList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteSpcDataQueue(dbContext, spcDataQueueList, optionSet, saveHist), 
			_ => RealDeleteSpcDataQueue(dbContext, spcDataQueueList, optionSet, saveHist), 
		};
	}

	private static int CreateSpcDataQueueInternal(IDbContext dbContext, Spcdataqueue[] spcDataQueueList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spcDataQueueList", spcDataQueueList);
		string text = "CreateSpcDataQueue";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spcdataqueue> list = new List<Spcdataqueue>();
		foreach (Spcdataqueue obj in spcDataQueueList)
		{
			Spcdataqueue spcdataqueue = new Spcdataqueue();
			obj.CopyColumsTo(spcdataqueue);
			spcdataqueue.Activity = text;
			spcdataqueue.CheckEntityUsable();
			obj.CopyCommonField(spcdataqueue, systemTime, dbContext.Tid, isCreate: true);
			list.Add(spcdataqueue);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateSpcDataQueue(IDbContext dbContext, Spcdataqueue[] spcDataQueueList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spcDataQueueList", spcDataQueueList);
		string text = "UpdateSpcDataQueue";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spcdataqueue> list = new List<Spcdataqueue>();
		foreach (Spcdataqueue spcdataqueue in spcDataQueueList)
		{
			Spcdataqueue spcDataQueue4Update = GetSpcDataQueue4Update(dbContext, spcdataqueue.Spcdataqueuesysid, spcdataqueue.Siteid);
			if (spcDataQueue4Update == null)
			{
				throw new EntityNotFoundException(typeof(Spcdataqueue), $"{spcdataqueue.Spcdataqueuesysid},{spcdataqueue.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Spcdataqueue), $"{spcdataqueue.Spcdataqueuesysid},{spcdataqueue.Siteid}", spcDataQueue4Update.Isusable);
			string activity = spcDataQueue4Update.Activity;
			string customactivity = spcDataQueue4Update.Customactivity;
			string isusable = spcDataQueue4Update.Isusable;
			DateTime? createtime = spcDataQueue4Update.Createtime;
			string creator = spcDataQueue4Update.Creator;
			spcdataqueue.CopyColumsTo(spcDataQueue4Update);
			spcDataQueue4Update.Prevactivity = activity;
			spcDataQueue4Update.Prevcustomactivity = customactivity;
			spcDataQueue4Update.Creator = creator;
			spcDataQueue4Update.Createtime = createtime;
			spcDataQueue4Update.Isusable = isusable;
			spcDataQueue4Update.Activity = text;
			spcdataqueue.CopyCommonField(spcDataQueue4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(spcDataQueue4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteSpcDataQueue(IDbContext dbContext, Spcdataqueue[] spcDataQueueList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spcDataQueueList", spcDataQueueList);
		string text = "DeleteSpcDataQueue";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spcdataqueue> list = new List<Spcdataqueue>();
		foreach (Spcdataqueue spcdataqueue in spcDataQueueList)
		{
			Spcdataqueue spcDataQueue4Update = GetSpcDataQueue4Update(dbContext, spcdataqueue.Spcdataqueuesysid, spcdataqueue.Siteid);
			if (spcDataQueue4Update == null)
			{
				throw new EntityNotFoundException(typeof(Spcdataqueue), $"{spcdataqueue.Spcdataqueuesysid},{spcdataqueue.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Spcdataqueue), $"{spcdataqueue.Spcdataqueuesysid},{spcdataqueue.Siteid}", spcDataQueue4Update.Isusable);
			spcDataQueue4Update.Isusable = "UnUsable";
			spcdataqueue.CopyCommonFieldUpdatePrev(spcDataQueue4Update, systemTime, dbContext.Tid, text);
			spcdataqueue.CopyExtensionCollection(spcDataQueue4Update);
			list.Add(spcDataQueue4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteSpcDataQueue(IDbContext dbContext, Spcdataqueue[] spcDataQueueList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spcDataQueueList", spcDataQueueList);
		string text = "UnDeleteSpcDataQueue";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spcdataqueue> list = new List<Spcdataqueue>();
		foreach (Spcdataqueue spcdataqueue in spcDataQueueList)
		{
			Spcdataqueue spcDataQueue4Update = GetSpcDataQueue4Update(dbContext, spcdataqueue.Spcdataqueuesysid, spcdataqueue.Siteid);
			if (spcDataQueue4Update == null)
			{
				throw new EntityNotFoundException(typeof(Spcdataqueue), $"{spcdataqueue.Spcdataqueuesysid},{spcdataqueue.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Spcdataqueue), $"{spcdataqueue.Spcdataqueuesysid},{spcdataqueue.Siteid}", spcDataQueue4Update.Isusable);
			spcDataQueue4Update.Isusable = "Usable";
			spcdataqueue.CopyCommonFieldUpdatePrev(spcDataQueue4Update, systemTime, dbContext.Tid, text);
			spcdataqueue.CopyExtensionCollection(spcDataQueue4Update);
			list.Add(spcDataQueue4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteSpcDataQueue(IDbContext dbContext, Spcdataqueue[] spcDataQueueList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spcDataQueueList", spcDataQueueList);
		string text = "RealDeleteSpcDataQueue";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spcdataqueue> list = new List<Spcdataqueue>();
		foreach (Spcdataqueue spcdataqueue in spcDataQueueList)
		{
			Spcdataqueue spcDataQueue4Update = GetSpcDataQueue4Update(dbContext, spcdataqueue.Spcdataqueuesysid, spcdataqueue.Siteid);
			if (spcDataQueue4Update == null)
			{
				throw new EntityNotFoundException(typeof(Spcdataqueue), $"{spcdataqueue.Spcdataqueuesysid},{spcdataqueue.Siteid}");
			}
			spcdataqueue.CopyCommonFieldUpdatePrev(spcDataQueue4Update, systemTime, dbContext.Tid, text);
			spcdataqueue.CopyExtensionCollection(spcDataQueue4Update);
			list.Add(spcDataQueue4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
