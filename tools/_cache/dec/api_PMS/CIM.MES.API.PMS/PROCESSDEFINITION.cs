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
public class PROCESSDEFINITION
{
	private static string _sqlGetProcessDefinitionSqlDatabase = "SELECT * FROM CIM_PROCESSDEFINITION WHERE PROCESSDEFINITIONID=@PROCESSDEFINITIONID AND SITEID=@SITEID";

	private static string _sqlGetProcessDefinition4UpdateSqlDatabase = "SELECT * FROM CIM_PROCESSDEFINITION WITH(UPDLOCK) WHERE PROCESSDEFINITIONID=@PROCESSDEFINITIONID AND SITEID=@SITEID";

	private static string _sqlSelectProcessDefinitionSqlDatabase = "SELECT * FROM CIM_PROCESSDEFINITION WHERE PROCESSDEFINITIONID=@PROCESSDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessDefinition4UpdateSqlDatabase = "SELECT * FROM CIM_PROCESSDEFINITION WITH(UPDLOCK) WHERE PROCESSDEFINITIONID=@PROCESSDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetProcessDefinitionOracleDatabase = "SELECT * FROM CIM_PROCESSDEFINITION WHERE PROCESSDEFINITIONID=:PROCESSDEFINITIONID AND SITEID=:SITEID";

	private static string _sqlGetProcessDefinition4UpdateOracleDatabase = "SELECT * FROM CIM_PROCESSDEFINITION WHERE PROCESSDEFINITIONID=:PROCESSDEFINITIONID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectProcessDefinitionOracleDatabase = "SELECT * FROM CIM_PROCESSDEFINITION WHERE PROCESSDEFINITIONID=:PROCESSDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessDefinition4UpdateOracleDatabase = "SELECT * FROM CIM_PROCESSDEFINITION WHERE PROCESSDEFINITIONID=:PROCESSDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Processdefinition);

	public static Processdefinition GetProcessDefinition(IDbContext dbContext, string processdefinitionid, string siteid)
	{
		string apiName = "GetProcessDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProcessDefinitionSqlDatabase : _sqlGetProcessDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSDEFINITIONID", processdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PROCESSDEFINITION", $"{processdefinitionid},{siteid}"));
		}
		Processdefinition? result = ContextManager.DirectEntityQuery<Processdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processdefinitionid},{siteid}");
		}
		return result;
	}

	public static Processdefinition GetProcessDefinition4Update(IDbContext dbContext, string processdefinitionid, string siteid)
	{
		string apiName = "GetProcessDefinition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProcessDefinition4UpdateSqlDatabase : _sqlGetProcessDefinition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSDEFINITIONID", processdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PROCESSDEFINITION", $"{processdefinitionid},{siteid}"));
		}
		Processdefinition? result = ContextManager.DirectEntityQuery<Processdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processdefinitionid},{siteid}");
		}
		return result;
	}

	public static Processdefinition SelectProcessDefinition(IDbContext dbContext, string processdefinitionid, string siteid)
	{
		string apiName = "SelectProcessDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessDefinitionSqlDatabase : _sqlSelectProcessDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSDEFINITIONID", processdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PROCESSDEFINITION", $"{processdefinitionid},{siteid}"));
		}
		Processdefinition? result = ContextManager.DirectEntityQuery<Processdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processdefinitionid},{siteid}");
		}
		return result;
	}

	public static Processdefinition SelectProcessDefinition4Update(IDbContext dbContext, string processdefinitionid, string siteid)
	{
		string apiName = "SelectProcessDefinition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessDefinition4UpdateSqlDatabase : _sqlSelectProcessDefinition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSDEFINITIONID", processdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PROCESSDEFINITION", $"{processdefinitionid},{siteid}"));
		}
		Processdefinition? result = ContextManager.DirectEntityQuery<Processdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processdefinitionid},{siteid}");
		}
		return result;
	}

	public static int UpsertProcessDefinition(IDbContext dbContext, RequestType requestType, Processdefinition[] processDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateProcessDefinitionInternal(dbContext, processDefinitionList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateProcessDefinition(dbContext, processDefinitionList, optionSet, saveHist), 
			RequestType.DELETE => DeleteProcessDefinition(dbContext, processDefinitionList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteProcessDefinition(dbContext, processDefinitionList, optionSet, saveHist), 
			_ => RealDeleteProcessDefinition(dbContext, processDefinitionList, optionSet, saveHist), 
		};
	}

	private static int CreateProcessDefinitionInternal(IDbContext dbContext, Processdefinition[] processDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processDefinitionList", processDefinitionList);
		string text = "CreateProcessDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processdefinition> list = new List<Processdefinition>();
		foreach (Processdefinition obj in processDefinitionList)
		{
			Processdefinition processdefinition = new Processdefinition();
			obj.CopyColumsTo(processdefinition);
			processdefinition.Activity = text;
			processdefinition.CheckEntityUsable();
			obj.CopyCommonField(processdefinition, systemTime, dbContext.Tid, isCreate: true);
			list.Add(processdefinition);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateProcessDefinition(IDbContext dbContext, Processdefinition[] processDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processDefinitionList", processDefinitionList);
		string text = "UpdateProcessDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processdefinition> list = new List<Processdefinition>();
		foreach (Processdefinition processdefinition in processDefinitionList)
		{
			Processdefinition processDefinition4Update = GetProcessDefinition4Update(dbContext, processdefinition.Processdefinitionid, processdefinition.Siteid);
			if (processDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processdefinition), $"{processdefinition.Processdefinitionid},{processdefinition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Processdefinition), $"{processdefinition.Processdefinitionid},{processdefinition.Siteid}", processDefinition4Update.Isusable);
			string activity = processDefinition4Update.Activity;
			string customactivity = processDefinition4Update.Customactivity;
			string isusable = processDefinition4Update.Isusable;
			DateTime? createtime = processDefinition4Update.Createtime;
			string creator = processDefinition4Update.Creator;
			processdefinition.CopyColumsTo(processDefinition4Update);
			processDefinition4Update.Prevactivity = activity;
			processDefinition4Update.Prevcustomactivity = customactivity;
			processDefinition4Update.Creator = creator;
			processDefinition4Update.Createtime = createtime;
			processDefinition4Update.Isusable = isusable;
			processDefinition4Update.Activity = text;
			processdefinition.CopyCommonField(processDefinition4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(processDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteProcessDefinition(IDbContext dbContext, Processdefinition[] processDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processDefinitionList", processDefinitionList);
		string text = "DeleteProcessDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processdefinition> list = new List<Processdefinition>();
		foreach (Processdefinition processdefinition in processDefinitionList)
		{
			Processdefinition processDefinition4Update = GetProcessDefinition4Update(dbContext, processdefinition.Processdefinitionid, processdefinition.Siteid);
			if (processDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processdefinition), $"{processdefinition.Processdefinitionid},{processdefinition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Processdefinition), $"{processdefinition.Processdefinitionid},{processdefinition.Siteid}", processDefinition4Update.Isusable);
			processDefinition4Update.Isusable = "UnUsable";
			processdefinition.CopyCommonFieldUpdatePrev(processDefinition4Update, systemTime, dbContext.Tid, text);
			processdefinition.CopyExtensionCollection(processDefinition4Update);
			list.Add(processDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteProcessDefinition(IDbContext dbContext, Processdefinition[] processDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processDefinitionList", processDefinitionList);
		string text = "UnDeleteProcessDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processdefinition> list = new List<Processdefinition>();
		foreach (Processdefinition processdefinition in processDefinitionList)
		{
			Processdefinition processDefinition4Update = GetProcessDefinition4Update(dbContext, processdefinition.Processdefinitionid, processdefinition.Siteid);
			if (processDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processdefinition), $"{processdefinition.Processdefinitionid},{processdefinition.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Processdefinition), $"{processdefinition.Processdefinitionid},{processdefinition.Siteid}", processDefinition4Update.Isusable);
			processDefinition4Update.Isusable = "Usable";
			processdefinition.CopyCommonFieldUpdatePrev(processDefinition4Update, systemTime, dbContext.Tid, text);
			processdefinition.CopyExtensionCollection(processDefinition4Update);
			list.Add(processDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteProcessDefinition(IDbContext dbContext, Processdefinition[] processDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processDefinitionList", processDefinitionList);
		string text = "RealDeleteProcessDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processdefinition> list = new List<Processdefinition>();
		foreach (Processdefinition processdefinition in processDefinitionList)
		{
			Processdefinition processDefinition4Update = GetProcessDefinition4Update(dbContext, processdefinition.Processdefinitionid, processdefinition.Siteid);
			if (processDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processdefinition), $"{processdefinition.Processdefinitionid},{processdefinition.Siteid}");
			}
			processdefinition.CopyCommonFieldUpdatePrev(processDefinition4Update, systemTime, dbContext.Tid, text);
			processdefinition.CopyExtensionCollection(processDefinition4Update);
			list.Add(processDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
