using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.PMS;

[MESAPI]
public class PROCESSPATH
{
	private static string _sqlGetProcessPathSqlDatabase = "SELECT * FROM CIM_PROCESSPATH WHERE PROCESSPATHID=@PROCESSPATHID AND PROCESSNODEID=@PROCESSNODEID AND SITEID=@SITEID";

	private static string _sqlGetProcessPath4UpdateSqlDatabase = "SELECT * FROM CIM_PROCESSPATH WITH(UPDLOCK) WHERE PROCESSPATHID=@PROCESSPATHID AND PROCESSNODEID=@PROCESSNODEID AND SITEID=@SITEID";

	private static string _sqlSelectProcessPathSqlDatabase = "SELECT * FROM CIM_PROCESSPATH WHERE PROCESSPATHID=@PROCESSPATHID AND PROCESSNODEID=@PROCESSNODEID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessPath4UpdateSqlDatabase = "SELECT * FROM CIM_PROCESSPATH WITH(UPDLOCK) WHERE PROCESSPATHID=@PROCESSPATHID AND PROCESSNODEID=@PROCESSNODEID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetProcessPathOracleDatabase = "SELECT * FROM CIM_PROCESSPATH WHERE PROCESSPATHID=:PROCESSPATHID AND PROCESSNODEID=:PROCESSNODEID AND SITEID=:SITEID";

	private static string _sqlGetProcessPath4UpdateOracleDatabase = "SELECT * FROM CIM_PROCESSPATH WHERE PROCESSPATHID=:PROCESSPATHID AND PROCESSNODEID=:PROCESSNODEID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectProcessPathOracleDatabase = "SELECT * FROM CIM_PROCESSPATH WHERE PROCESSPATHID=:PROCESSPATHID AND PROCESSNODEID=:PROCESSNODEID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessPath4UpdateOracleDatabase = "SELECT * FROM CIM_PROCESSPATH WHERE PROCESSPATHID=:PROCESSPATHID AND PROCESSNODEID=:PROCESSNODEID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Processpath);

	private static string _selectProcessPathByNextNodeSqlDatabase = "SELECT * FROM CIM_PROCESSPATH WHERE PROCESSNODEID=@PROCESSNODEID AND NEXTPROCESSNODEID=@NEXTPROCESSNODEID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _selectProcessPathByNextNodeOracleDatabase = "SELECT * FROM CIM_PROCESSPATH WHERE PROCESSNODEID=:PROCESSNODEID AND NEXTPROCESSNODEID=:NEXTPROCESSNODEID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _selectProcessPathIdByProcessDefinitionSqlDatabase = "SELECT P.* FROM CIM_PROCESSPATH P INNER JOIN CIM_PROCESSNODE N ON P.PROCESSNODEID = N.PROCESSNODEID AND P.SITEID = N.SITEID AND N.PROCESSDEFINITIONID = @PROCESSDEFINITIONID AND N.SITEID = @SITEID AND N.ISUSABLE ='Usable'";

	private static string _selectProcessPathIdByProcessDefinitionOracleDatabase = "SELECT P.* FROM CIM_PROCESSPATH P INNER JOIN CIM_PROCESSNODE N ON P.PROCESSNODEID = N.PROCESSNODEID AND P.SITEID = N.SITEID AND N.PROCESSDEFINITIONID = :PROCESSDEFINITIONID AND N.SITEID = :SITEID AND N.ISUSABLE ='Usable'";

	public static Processpath GetProcessPath(IDbContext dbContext, string processpathid, string processnodeid, string siteid)
	{
		string apiName = "GetProcessPath";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processpathid},{processnodeid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProcessPathSqlDatabase : _sqlGetProcessPathOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSPATHID", processpathid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSNODEID", processnodeid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PROCESSPATH", $"{processpathid},{processnodeid},{siteid}"));
		}
		Processpath? result = ContextManager.DirectEntityQuery<Processpath>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processpathid},{processnodeid},{siteid}");
		}
		return result;
	}

	public static Processpath GetProcessPath4Update(IDbContext dbContext, string processpathid, string processnodeid, string siteid)
	{
		string apiName = "GetProcessPath4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processpathid},{processnodeid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProcessPath4UpdateSqlDatabase : _sqlGetProcessPath4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSPATHID", processpathid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSNODEID", processnodeid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PROCESSPATH", $"{processpathid},{processnodeid},{siteid}"));
		}
		Processpath? result = ContextManager.DirectEntityQuery<Processpath>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processpathid},{processnodeid},{siteid}");
		}
		return result;
	}

	public static Processpath SelectProcessPath(IDbContext dbContext, string processpathid, string processnodeid, string siteid)
	{
		string apiName = "SelectProcessPath";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processpathid},{processnodeid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessPathSqlDatabase : _sqlSelectProcessPathOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSPATHID", processpathid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSNODEID", processnodeid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PROCESSPATH", $"{processpathid},{processnodeid},{siteid}"));
		}
		Processpath? result = ContextManager.DirectEntityQuery<Processpath>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processpathid},{processnodeid},{siteid}");
		}
		return result;
	}

	public static Processpath SelectProcessPath4Update(IDbContext dbContext, string processpathid, string processnodeid, string siteid)
	{
		string apiName = "SelectProcessPath4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processpathid},{processnodeid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessPath4UpdateSqlDatabase : _sqlSelectProcessPath4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSPATHID", processpathid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSNODEID", processnodeid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PROCESSPATH", $"{processpathid},{processnodeid},{siteid}"));
		}
		Processpath? result = ContextManager.DirectEntityQuery<Processpath>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processpathid},{processnodeid},{siteid}");
		}
		return result;
	}

	public static int UpsertProcessPath(IDbContext dbContext, RequestType requestType, Processpath[] processPathList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateProcessPathInternal(dbContext, processPathList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateProcessPath(dbContext, processPathList, optionSet, saveHist), 
			RequestType.DELETE => DeleteProcessPath(dbContext, processPathList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteProcessPath(dbContext, processPathList, optionSet, saveHist), 
			_ => RealDeleteProcessPath(dbContext, processPathList, optionSet, saveHist), 
		};
	}

	private static int CreateProcessPathInternal(IDbContext dbContext, Processpath[] processPathList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processPathList", processPathList);
		string text = "CreateProcessPath";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processpath> list = new List<Processpath>();
		foreach (Processpath obj in processPathList)
		{
			Processpath processpath = new Processpath();
			obj.CopyColumsTo(processpath);
			processpath.Activity = text;
			processpath.CheckEntityUsable();
			obj.CopyCommonField(processpath, systemTime, dbContext.Tid, isCreate: true);
			list.Add(processpath);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateProcessPath(IDbContext dbContext, Processpath[] processPathList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processPathList", processPathList);
		string text = "UpdateProcessPath";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processpath> list = new List<Processpath>();
		foreach (Processpath processpath in processPathList)
		{
			Processpath processPath4Update = GetProcessPath4Update(dbContext, processpath.Processpathid, processpath.Processnodeid, processpath.Siteid);
			if (processPath4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processpath), $"{processpath.Processpathid},{processpath.Processnodeid},{processpath.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Processpath), $"{processpath.Processpathid},{processpath.Processnodeid},{processpath.Siteid}", processPath4Update.Isusable);
			string activity = processPath4Update.Activity;
			string customactivity = processPath4Update.Customactivity;
			string isusable = processPath4Update.Isusable;
			DateTime? createtime = processPath4Update.Createtime;
			string creator = processPath4Update.Creator;
			processpath.CopyColumsTo(processPath4Update);
			processPath4Update.Prevactivity = activity;
			processPath4Update.Prevcustomactivity = customactivity;
			processPath4Update.Creator = creator;
			processPath4Update.Createtime = createtime;
			processPath4Update.Isusable = isusable;
			processPath4Update.Activity = text;
			processpath.CopyCommonField(processPath4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(processPath4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteProcessPath(IDbContext dbContext, Processpath[] processPathList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processPathList", processPathList);
		string text = "DeleteProcessPath";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processpath> list = new List<Processpath>();
		foreach (Processpath processpath in processPathList)
		{
			Processpath processPath4Update = GetProcessPath4Update(dbContext, processpath.Processpathid, processpath.Processnodeid, processpath.Siteid);
			if (processPath4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processpath), $"{processpath.Processpathid},{processpath.Processnodeid},{processpath.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Processpath), $"{processpath.Processpathid},{processpath.Processnodeid},{processpath.Siteid}", processPath4Update.Isusable);
			processPath4Update.Isusable = "UnUsable";
			processpath.CopyCommonFieldUpdatePrev(processPath4Update, systemTime, dbContext.Tid, text);
			processpath.CopyExtensionCollection(processPath4Update);
			list.Add(processPath4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteProcessPath(IDbContext dbContext, Processpath[] processPathList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processPathList", processPathList);
		string text = "UnDeleteProcessPath";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processpath> list = new List<Processpath>();
		foreach (Processpath processpath in processPathList)
		{
			Processpath processPath4Update = GetProcessPath4Update(dbContext, processpath.Processpathid, processpath.Processnodeid, processpath.Siteid);
			if (processPath4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processpath), $"{processpath.Processpathid},{processpath.Processnodeid},{processpath.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Processpath), $"{processpath.Processpathid},{processpath.Processnodeid},{processpath.Siteid}", processPath4Update.Isusable);
			processPath4Update.Isusable = "Usable";
			processpath.CopyCommonFieldUpdatePrev(processPath4Update, systemTime, dbContext.Tid, text);
			processpath.CopyExtensionCollection(processPath4Update);
			list.Add(processPath4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteProcessPath(IDbContext dbContext, Processpath[] processPathList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processPathList", processPathList);
		string text = "RealDeleteProcessPath";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processpath> list = new List<Processpath>();
		foreach (Processpath processpath in processPathList)
		{
			Processpath processPath4Update = GetProcessPath4Update(dbContext, processpath.Processpathid, processpath.Processnodeid, processpath.Siteid);
			if (processPath4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processpath), $"{processpath.Processpathid},{processpath.Processnodeid},{processpath.Siteid}");
			}
			processpath.CopyCommonFieldUpdatePrev(processPath4Update, systemTime, dbContext.Tid, text);
			processpath.CopyExtensionCollection(processPath4Update);
			list.Add(processPath4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static Processpath SelectProcessPathByNextNode(IDbContext dbContext, string processNodeId, string nextProcessNodeId, string siteid)
	{
		string apiName = "SelectProcessPathByNextNode";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processNodeId},{nextProcessNodeId},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _selectProcessPathByNextNodeSqlDatabase : _selectProcessPathByNextNodeOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSNODEID", processNodeId, typeOfThis));
		list.Add(dbContext.CreateParameter("NEXTPROCESSNODEID", nextProcessNodeId, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PROCESSPATH", $"{processNodeId},{nextProcessNodeId},{siteid}"));
		}
		Processpath? result = ContextManager.DirectEntityQuery<Processpath>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processNodeId},{nextProcessNodeId},{siteid}");
		}
		return result;
	}

	public static IList<Processpath> SelectProcessPathIdByProcessDefinition(IDbContext dbContext, string processDefinitionId, string siteid)
	{
		string apiName = "SelectProcessPathByNextNode";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processDefinitionId},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _selectProcessPathIdByProcessDefinitionSqlDatabase : _selectProcessPathIdByProcessDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSDEFINITIONID", processDefinitionId, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}", "SELECT", "CIM_PROCESSPATH", $"{processDefinitionId},{siteid}"));
		}
		IList<Processpath> result = ContextManager.DirectEntityQuery<Processpath>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processDefinitionId},{siteid}");
		}
		return result;
	}
}
