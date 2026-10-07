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
public class PROCESSDATASOURCE
{
	private static string _sqlGetProcessDataSourceSqlDatabase = "SELECT * FROM CIM_PROCESSDATASOURCE WHERE PROCESSDATASOURCESYSID=@PROCESSDATASOURCESYSID AND SITEID=@SITEID";

	private static string _sqlGetProcessDataSource4UpdateSqlDatabase = "SELECT * FROM CIM_PROCESSDATASOURCE WITH(UPDLOCK) WHERE PROCESSDATASOURCESYSID=@PROCESSDATASOURCESYSID AND SITEID=@SITEID";

	private static string _sqlSelectProcessDataSourceSqlDatabase = "SELECT * FROM CIM_PROCESSDATASOURCE WHERE PROCESSDATASOURCESYSID=@PROCESSDATASOURCESYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessDataSource4UpdateSqlDatabase = "SELECT * FROM CIM_PROCESSDATASOURCE WITH(UPDLOCK) WHERE PROCESSDATASOURCESYSID=@PROCESSDATASOURCESYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetProcessDataSourceOracleDatabase = "SELECT * FROM CIM_PROCESSDATASOURCE WHERE PROCESSDATASOURCESYSID=:PROCESSDATASOURCESYSID AND SITEID=:SITEID";

	private static string _sqlGetProcessDataSource4UpdateOracleDatabase = "SELECT * FROM CIM_PROCESSDATASOURCE WHERE PROCESSDATASOURCESYSID=:PROCESSDATASOURCESYSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectProcessDataSourceOracleDatabase = "SELECT * FROM CIM_PROCESSDATASOURCE WHERE PROCESSDATASOURCESYSID=:PROCESSDATASOURCESYSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessDataSource4UpdateOracleDatabase = "SELECT * FROM CIM_PROCESSDATASOURCE WHERE PROCESSDATASOURCESYSID=:PROCESSDATASOURCESYSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Processdatasource);

	public static Processdatasource GetProcessDataSource(IDbContext dbContext, long processdatasourcesysid, string siteid)
	{
		string apiName = "GetProcessDataSource";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processdatasourcesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProcessDataSourceSqlDatabase : _sqlGetProcessDataSourceOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSDATASOURCESYSID", processdatasourcesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PROCESSDATASOURCE", $"{processdatasourcesysid},{siteid}"));
		}
		Processdatasource? result = ContextManager.DirectEntityQuery<Processdatasource>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processdatasourcesysid},{siteid}");
		}
		return result;
	}

	public static Processdatasource GetProcessDataSource4Update(IDbContext dbContext, long processdatasourcesysid, string siteid)
	{
		string apiName = "GetProcessDataSource4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processdatasourcesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProcessDataSource4UpdateSqlDatabase : _sqlGetProcessDataSource4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSDATASOURCESYSID", processdatasourcesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PROCESSDATASOURCE", $"{processdatasourcesysid},{siteid}"));
		}
		Processdatasource? result = ContextManager.DirectEntityQuery<Processdatasource>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processdatasourcesysid},{siteid}");
		}
		return result;
	}

	public static Processdatasource SelectProcessDataSource(IDbContext dbContext, long processdatasourcesysid, string siteid)
	{
		string apiName = "SelectProcessDataSource";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processdatasourcesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessDataSourceSqlDatabase : _sqlSelectProcessDataSourceOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSDATASOURCESYSID", processdatasourcesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PROCESSDATASOURCE", $"{processdatasourcesysid},{siteid}"));
		}
		Processdatasource? result = ContextManager.DirectEntityQuery<Processdatasource>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processdatasourcesysid},{siteid}");
		}
		return result;
	}

	public static Processdatasource SelectProcessDataSource4Update(IDbContext dbContext, long processdatasourcesysid, string siteid)
	{
		string apiName = "SelectProcessDataSource4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processdatasourcesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessDataSource4UpdateSqlDatabase : _sqlSelectProcessDataSource4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSDATASOURCESYSID", processdatasourcesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PROCESSDATASOURCE", $"{processdatasourcesysid},{siteid}"));
		}
		Processdatasource? result = ContextManager.DirectEntityQuery<Processdatasource>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processdatasourcesysid},{siteid}");
		}
		return result;
	}

	public static int UpsertProcessDataSource(IDbContext dbContext, RequestType requestType, Processdatasource[] processDataSourceList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateProcessDataSourceInternal(dbContext, processDataSourceList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateProcessDataSource(dbContext, processDataSourceList, optionSet, saveHist), 
			RequestType.DELETE => DeleteProcessDataSource(dbContext, processDataSourceList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteProcessDataSource(dbContext, processDataSourceList, optionSet, saveHist), 
			_ => RealDeleteProcessDataSource(dbContext, processDataSourceList, optionSet, saveHist), 
		};
	}

	private static int CreateProcessDataSourceInternal(IDbContext dbContext, Processdatasource[] processDataSourceList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processDataSourceList", processDataSourceList);
		string text = "CreateProcessDataSource";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processdatasource> list = new List<Processdatasource>();
		foreach (Processdatasource obj in processDataSourceList)
		{
			Processdatasource processdatasource = new Processdatasource();
			obj.CopyColumsTo(processdatasource);
			processdatasource.Activity = text;
			processdatasource.CheckEntityUsable();
			obj.CopyCommonField(processdatasource, systemTime, dbContext.Tid, isCreate: true);
			list.Add(processdatasource);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateProcessDataSource(IDbContext dbContext, Processdatasource[] processDataSourceList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processDataSourceList", processDataSourceList);
		string text = "UpdateProcessDataSource";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processdatasource> list = new List<Processdatasource>();
		foreach (Processdatasource processdatasource in processDataSourceList)
		{
			Processdatasource processDataSource4Update = GetProcessDataSource4Update(dbContext, processdatasource.Processdatasourcesysid, processdatasource.Siteid);
			if (processDataSource4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processdatasource), $"{processdatasource.Processdatasourcesysid},{processdatasource.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Processdatasource), $"{processdatasource.Processdatasourcesysid},{processdatasource.Siteid}", processDataSource4Update.Isusable);
			string activity = processDataSource4Update.Activity;
			string customactivity = processDataSource4Update.Customactivity;
			string isusable = processDataSource4Update.Isusable;
			DateTime? createtime = processDataSource4Update.Createtime;
			string creator = processDataSource4Update.Creator;
			processdatasource.CopyColumsTo(processDataSource4Update);
			processDataSource4Update.Prevactivity = activity;
			processDataSource4Update.Prevcustomactivity = customactivity;
			processDataSource4Update.Creator = creator;
			processDataSource4Update.Createtime = createtime;
			processDataSource4Update.Isusable = isusable;
			processDataSource4Update.Activity = text;
			processdatasource.CopyCommonField(processDataSource4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(processDataSource4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteProcessDataSource(IDbContext dbContext, Processdatasource[] processDataSourceList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processDataSourceList", processDataSourceList);
		string text = "DeleteProcessDataSource";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processdatasource> list = new List<Processdatasource>();
		foreach (Processdatasource processdatasource in processDataSourceList)
		{
			Processdatasource processDataSource4Update = GetProcessDataSource4Update(dbContext, processdatasource.Processdatasourcesysid, processdatasource.Siteid);
			if (processDataSource4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processdatasource), $"{processdatasource.Processdatasourcesysid},{processdatasource.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Processdatasource), $"{processdatasource.Processdatasourcesysid},{processdatasource.Siteid}", processDataSource4Update.Isusable);
			processDataSource4Update.Isusable = "UnUsable";
			processdatasource.CopyCommonFieldUpdatePrev(processDataSource4Update, systemTime, dbContext.Tid, text);
			processdatasource.CopyExtensionCollection(processDataSource4Update);
			list.Add(processDataSource4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteProcessDataSource(IDbContext dbContext, Processdatasource[] processDataSourceList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processDataSourceList", processDataSourceList);
		string text = "UnDeleteProcessDataSource";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processdatasource> list = new List<Processdatasource>();
		foreach (Processdatasource processdatasource in processDataSourceList)
		{
			Processdatasource processDataSource4Update = GetProcessDataSource4Update(dbContext, processdatasource.Processdatasourcesysid, processdatasource.Siteid);
			if (processDataSource4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processdatasource), $"{processdatasource.Processdatasourcesysid},{processdatasource.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Processdatasource), $"{processdatasource.Processdatasourcesysid},{processdatasource.Siteid}", processDataSource4Update.Isusable);
			processDataSource4Update.Isusable = "Usable";
			processdatasource.CopyCommonFieldUpdatePrev(processDataSource4Update, systemTime, dbContext.Tid, text);
			processdatasource.CopyExtensionCollection(processDataSource4Update);
			list.Add(processDataSource4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteProcessDataSource(IDbContext dbContext, Processdatasource[] processDataSourceList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processDataSourceList", processDataSourceList);
		string text = "RealDeleteProcessDataSource";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processdatasource> list = new List<Processdatasource>();
		foreach (Processdatasource processdatasource in processDataSourceList)
		{
			Processdatasource processDataSource4Update = GetProcessDataSource4Update(dbContext, processdatasource.Processdatasourcesysid, processdatasource.Siteid);
			if (processDataSource4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processdatasource), $"{processdatasource.Processdatasourcesysid},{processdatasource.Siteid}");
			}
			processdatasource.CopyCommonFieldUpdatePrev(processDataSource4Update, systemTime, dbContext.Tid, text);
			processdatasource.CopyExtensionCollection(processDataSource4Update);
			list.Add(processDataSource4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
