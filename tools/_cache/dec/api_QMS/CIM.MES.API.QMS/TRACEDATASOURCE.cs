using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.QMS;

[MESAPI]
public class TRACEDATASOURCE
{
	private static string _sqlGetTraceDataSourceSqlDatabase = "SELECT * FROM CIM_TRACEDATASOURCE WHERE TRACEDATASOURCESYSID=@TRACEDATASOURCESYSID AND SITEID=@SITEID";

	private static string _sqlGetTraceDataSource4UpdateSqlDatabase = "SELECT * FROM CIM_TRACEDATASOURCE WITH(UPDLOCK) WHERE TRACEDATASOURCESYSID=@TRACEDATASOURCESYSID AND SITEID=@SITEID";

	private static string _sqlSelectTraceDataSourceSqlDatabase = "SELECT * FROM CIM_TRACEDATASOURCE WHERE TRACEDATASOURCESYSID=@TRACEDATASOURCESYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectTraceDataSource4UpdateSqlDatabase = "SELECT * FROM CIM_TRACEDATASOURCE WITH(UPDLOCK) WHERE TRACEDATASOURCESYSID=@TRACEDATASOURCESYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetTraceDataSourceOracleDatabase = "SELECT * FROM CIM_TRACEDATASOURCE WHERE TRACEDATASOURCESYSID=:TRACEDATASOURCESYSID AND SITEID=:SITEID";

	private static string _sqlGetTraceDataSource4UpdateOracleDatabase = "SELECT * FROM CIM_TRACEDATASOURCE WHERE TRACEDATASOURCESYSID=:TRACEDATASOURCESYSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectTraceDataSourceOracleDatabase = "SELECT * FROM CIM_TRACEDATASOURCE WHERE TRACEDATASOURCESYSID=:TRACEDATASOURCESYSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectTraceDataSource4UpdateOracleDatabase = "SELECT * FROM CIM_TRACEDATASOURCE WHERE TRACEDATASOURCESYSID=:TRACEDATASOURCESYSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Tracedatasource);

	public static Tracedatasource GetTraceDataSource(IDbContext dbContext, long tracedatasourcesysid, string siteid)
	{
		string apiName = "GetTraceDataSource";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tracedatasourcesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetTraceDataSourceSqlDatabase : _sqlGetTraceDataSourceOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TRACEDATASOURCESYSID", tracedatasourcesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_TRACEDATASOURCE", $"{tracedatasourcesysid},{siteid}"));
		}
		Tracedatasource? result = ContextManager.DirectEntityQuery<Tracedatasource>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tracedatasourcesysid},{siteid}");
		}
		return result;
	}

	public static Tracedatasource GetTraceDataSource4Update(IDbContext dbContext, long tracedatasourcesysid, string siteid)
	{
		string apiName = "GetTraceDataSource4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tracedatasourcesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetTraceDataSource4UpdateSqlDatabase : _sqlGetTraceDataSource4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TRACEDATASOURCESYSID", tracedatasourcesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_TRACEDATASOURCE", $"{tracedatasourcesysid},{siteid}"));
		}
		Tracedatasource? result = ContextManager.DirectEntityQuery<Tracedatasource>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tracedatasourcesysid},{siteid}");
		}
		return result;
	}

	public static Tracedatasource SelectTraceDataSource(IDbContext dbContext, long tracedatasourcesysid, string siteid)
	{
		string apiName = "SelectTraceDataSource";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tracedatasourcesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectTraceDataSourceSqlDatabase : _sqlSelectTraceDataSourceOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TRACEDATASOURCESYSID", tracedatasourcesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_TRACEDATASOURCE", $"{tracedatasourcesysid},{siteid}"));
		}
		Tracedatasource? result = ContextManager.DirectEntityQuery<Tracedatasource>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tracedatasourcesysid},{siteid}");
		}
		return result;
	}

	public static Tracedatasource SelectTraceDataSource4Update(IDbContext dbContext, long tracedatasourcesysid, string siteid)
	{
		string apiName = "SelectTraceDataSource4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tracedatasourcesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectTraceDataSource4UpdateSqlDatabase : _sqlSelectTraceDataSource4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TRACEDATASOURCESYSID", tracedatasourcesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_TRACEDATASOURCE", $"{tracedatasourcesysid},{siteid}"));
		}
		Tracedatasource? result = ContextManager.DirectEntityQuery<Tracedatasource>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tracedatasourcesysid},{siteid}");
		}
		return result;
	}

	public static int UpsertTraceDataSource(IDbContext dbContext, RequestType requestType, Tracedatasource[] traceDataSourceList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateTraceDataSourceInternal(dbContext, traceDataSourceList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateTraceDataSource(dbContext, traceDataSourceList, optionSet, saveHist), 
			RequestType.DELETE => DeleteTraceDataSource(dbContext, traceDataSourceList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteTraceDataSource(dbContext, traceDataSourceList, optionSet, saveHist), 
			_ => RealDeleteTraceDataSource(dbContext, traceDataSourceList, optionSet, saveHist), 
		};
	}

	private static int CreateTraceDataSourceInternal(IDbContext dbContext, Tracedatasource[] traceDataSourceList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceDataSourceList", traceDataSourceList);
		string text = "CreateTraceDataSource";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tracedatasource> list = new List<Tracedatasource>();
		foreach (Tracedatasource obj in traceDataSourceList)
		{
			Tracedatasource tracedatasource = new Tracedatasource();
			obj.CopyColumsTo(tracedatasource);
			tracedatasource.Activity = text;
			tracedatasource.CheckEntityUsable();
			obj.CopyCommonField(tracedatasource, systemTime, dbContext.Tid, isCreate: true);
			list.Add(tracedatasource);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateTraceDataSource(IDbContext dbContext, Tracedatasource[] traceDataSourceList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceDataSourceList", traceDataSourceList);
		string text = "UpdateTraceDataSource";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tracedatasource> list = new List<Tracedatasource>();
		foreach (Tracedatasource tracedatasource in traceDataSourceList)
		{
			Tracedatasource traceDataSource4Update = GetTraceDataSource4Update(dbContext, tracedatasource.Tracedatasourcesysid, tracedatasource.Siteid);
			if (traceDataSource4Update == null)
			{
				throw new EntityNotFoundException(typeof(Tracedatasource), $"{tracedatasource.Tracedatasourcesysid},{tracedatasource.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Tracedatasource), $"{tracedatasource.Tracedatasourcesysid},{tracedatasource.Siteid}", traceDataSource4Update.Isusable);
			string activity = traceDataSource4Update.Activity;
			string customactivity = traceDataSource4Update.Customactivity;
			string isusable = traceDataSource4Update.Isusable;
			DateTime? createtime = traceDataSource4Update.Createtime;
			string creator = traceDataSource4Update.Creator;
			tracedatasource.CopyColumsTo(traceDataSource4Update);
			traceDataSource4Update.Prevactivity = activity;
			traceDataSource4Update.Prevcustomactivity = customactivity;
			traceDataSource4Update.Creator = creator;
			traceDataSource4Update.Createtime = createtime;
			traceDataSource4Update.Isusable = isusable;
			traceDataSource4Update.Activity = text;
			tracedatasource.CopyCommonField(traceDataSource4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(traceDataSource4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteTraceDataSource(IDbContext dbContext, Tracedatasource[] traceDataSourceList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceDataSourceList", traceDataSourceList);
		string text = "DeleteTraceDataSource";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tracedatasource> list = new List<Tracedatasource>();
		foreach (Tracedatasource tracedatasource in traceDataSourceList)
		{
			Tracedatasource traceDataSource4Update = GetTraceDataSource4Update(dbContext, tracedatasource.Tracedatasourcesysid, tracedatasource.Siteid);
			if (traceDataSource4Update == null)
			{
				throw new EntityNotFoundException(typeof(Tracedatasource), $"{tracedatasource.Tracedatasourcesysid},{tracedatasource.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Tracedatasource), $"{tracedatasource.Tracedatasourcesysid},{tracedatasource.Siteid}", traceDataSource4Update.Isusable);
			traceDataSource4Update.Isusable = "UnUsable";
			tracedatasource.CopyCommonFieldUpdatePrev(traceDataSource4Update, systemTime, dbContext.Tid, text);
			tracedatasource.CopyExtensionCollection(traceDataSource4Update);
			list.Add(traceDataSource4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteTraceDataSource(IDbContext dbContext, Tracedatasource[] traceDataSourceList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceDataSourceList", traceDataSourceList);
		string text = "UnDeleteTraceDataSource";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tracedatasource> list = new List<Tracedatasource>();
		foreach (Tracedatasource tracedatasource in traceDataSourceList)
		{
			Tracedatasource traceDataSource4Update = GetTraceDataSource4Update(dbContext, tracedatasource.Tracedatasourcesysid, tracedatasource.Siteid);
			if (traceDataSource4Update == null)
			{
				throw new EntityNotFoundException(typeof(Tracedatasource), $"{tracedatasource.Tracedatasourcesysid},{tracedatasource.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Tracedatasource), $"{tracedatasource.Tracedatasourcesysid},{tracedatasource.Siteid}", traceDataSource4Update.Isusable);
			traceDataSource4Update.Isusable = "Usable";
			tracedatasource.CopyCommonFieldUpdatePrev(traceDataSource4Update, systemTime, dbContext.Tid, text);
			tracedatasource.CopyExtensionCollection(traceDataSource4Update);
			list.Add(traceDataSource4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteTraceDataSource(IDbContext dbContext, Tracedatasource[] traceDataSourceList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceDataSourceList", traceDataSourceList);
		string text = "RealDeleteTraceDataSource";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tracedatasource> list = new List<Tracedatasource>();
		foreach (Tracedatasource tracedatasource in traceDataSourceList)
		{
			Tracedatasource traceDataSource4Update = GetTraceDataSource4Update(dbContext, tracedatasource.Tracedatasourcesysid, tracedatasource.Siteid);
			if (traceDataSource4Update == null)
			{
				throw new EntityNotFoundException(typeof(Tracedatasource), $"{tracedatasource.Tracedatasourcesysid},{tracedatasource.Siteid}");
			}
			tracedatasource.CopyCommonFieldUpdatePrev(traceDataSource4Update, systemTime, dbContext.Tid, text);
			tracedatasource.CopyExtensionCollection(traceDataSource4Update);
			list.Add(traceDataSource4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
