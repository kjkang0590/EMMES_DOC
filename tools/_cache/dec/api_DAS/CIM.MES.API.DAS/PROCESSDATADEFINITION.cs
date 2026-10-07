using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.DAS;

[MESAPI]
public class PROCESSDATADEFINITION
{
	private static string _sqlGetProcessDataDefinitionSqlDatabase = "SELECT * FROM CIM_PROCESSDATADEFINITION WHERE PROCESSDATADEFINITIONID=@PROCESSDATADEFINITIONID AND SITEID=@SITEID";

	private static string _sqlGetProcessDataDefinition4UpdateSqlDatabase = "SELECT * FROM CIM_PROCESSDATADEFINITION WITH(UPDLOCK) WHERE PROCESSDATADEFINITIONID=@PROCESSDATADEFINITIONID AND SITEID=@SITEID";

	private static string _sqlSelectProcessDataDefinitionSqlDatabase = "SELECT * FROM CIM_PROCESSDATADEFINITION WHERE PROCESSDATADEFINITIONID=@PROCESSDATADEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessDataDefinition4UpdateSqlDatabase = "SELECT * FROM CIM_PROCESSDATADEFINITION WITH(UPDLOCK) WHERE PROCESSDATADEFINITIONID=@PROCESSDATADEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetProcessDataDefinitionOracleDatabase = "SELECT * FROM CIM_PROCESSDATADEFINITION WHERE PROCESSDATADEFINITIONID=:PROCESSDATADEFINITIONID AND SITEID=:SITEID";

	private static string _sqlGetProcessDataDefinition4UpdateOracleDatabase = "SELECT * FROM CIM_PROCESSDATADEFINITION WHERE PROCESSDATADEFINITIONID=:PROCESSDATADEFINITIONID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectProcessDataDefinitionOracleDatabase = "SELECT * FROM CIM_PROCESSDATADEFINITION WHERE PROCESSDATADEFINITIONID=:PROCESSDATADEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessDataDefinition4UpdateOracleDatabase = "SELECT * FROM CIM_PROCESSDATADEFINITION WHERE PROCESSDATADEFINITIONID=:PROCESSDATADEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Processdatadefinition);

	private static string _sqlListProcessDataParameterSqlDatabase = "SELECT * FROM CIM_PROCESSDATADEFINITION WHERE PROCESSDATACLASSID=@PROCESSDATACLASSID AND SITEID=@SITEID";

	private static string _sqlListProcessDataParameterOracleDatabase = "SELECT * FROM CIM_PROCESSDATADEFINITION WHERE PROCESSDATACLASSID=:PROCESSDATACLASSID AND SITEID=:SITEID";

	public static Processdatadefinition GetProcessDataDefinition(IDbContext dbContext, string processdatadefinitionid, string siteid)
	{
		string apiName = "GetProcessDataDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processdatadefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProcessDataDefinitionSqlDatabase : _sqlGetProcessDataDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSDATADEFINITIONID", processdatadefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PROCESSDATADEFINITION", $"{processdatadefinitionid},{siteid}"));
		}
		Processdatadefinition? result = ContextManager.DirectEntityQuery<Processdatadefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processdatadefinitionid},{siteid}");
		}
		return result;
	}

	public static Processdatadefinition GetProcessDataDefinition4Update(IDbContext dbContext, string processdatadefinitionid, string siteid)
	{
		string apiName = "GetProcessDataDefinition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processdatadefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProcessDataDefinition4UpdateSqlDatabase : _sqlGetProcessDataDefinition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSDATADEFINITIONID", processdatadefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PROCESSDATADEFINITION", $"{processdatadefinitionid},{siteid}"));
		}
		Processdatadefinition? result = ContextManager.DirectEntityQuery<Processdatadefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processdatadefinitionid},{siteid}");
		}
		return result;
	}

	public static Processdatadefinition SelectProcessDataDefinition(IDbContext dbContext, string processdatadefinitionid, string siteid)
	{
		string apiName = "SelectProcessDataDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processdatadefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessDataDefinitionSqlDatabase : _sqlSelectProcessDataDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSDATADEFINITIONID", processdatadefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PROCESSDATADEFINITION", $"{processdatadefinitionid},{siteid}"));
		}
		Processdatadefinition? result = ContextManager.DirectEntityQuery<Processdatadefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processdatadefinitionid},{siteid}");
		}
		return result;
	}

	public static Processdatadefinition SelectProcessDataDefinition4Update(IDbContext dbContext, string processdatadefinitionid, string siteid)
	{
		string apiName = "SelectProcessDataDefinition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processdatadefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessDataDefinition4UpdateSqlDatabase : _sqlSelectProcessDataDefinition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSDATADEFINITIONID", processdatadefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PROCESSDATADEFINITION", $"{processdatadefinitionid},{siteid}"));
		}
		Processdatadefinition? result = ContextManager.DirectEntityQuery<Processdatadefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processdatadefinitionid},{siteid}");
		}
		return result;
	}

	public static IList<Processdatadefinition> SelectProcessDataDefinitionList(IDbContext dbContext, string processdataclassid, string siteid)
	{
		string apiName = "SelectProcessDataDefinitionList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processdataclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlListProcessDataParameterSqlDatabase : _sqlListProcessDataParameterOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSDATACLASSID", processdataclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PROCESSDATADEFINITION", $"{processdataclassid},{siteid}"));
		}
		IList<Processdatadefinition> result = ContextManager.DirectEntityQuery<Processdatadefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processdataclassid},{siteid}");
		}
		return result;
	}

	public static int UpsertProcessDataDefinition(IDbContext dbContext, RequestType requestType, Processdatadefinition[] processDataDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateProcessDataDefinitionInternal(dbContext, processDataDefinitionList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateProcessDataDefinition(dbContext, processDataDefinitionList, optionSet, saveHist), 
			RequestType.DELETE => DeleteProcessDataDefinition(dbContext, processDataDefinitionList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteProcessDataDefinition(dbContext, processDataDefinitionList, optionSet, saveHist), 
			_ => RealDeleteProcessDataDefinition(dbContext, processDataDefinitionList, optionSet, saveHist), 
		};
	}

	private static int CreateProcessDataDefinitionInternal(IDbContext dbContext, Processdatadefinition[] processDataDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processDataDefinitionList", processDataDefinitionList);
		string text = "CreateProcessDataDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processdatadefinition> list = new List<Processdatadefinition>();
		foreach (Processdatadefinition obj in processDataDefinitionList)
		{
			Processdatadefinition processdatadefinition = new Processdatadefinition();
			obj.CopyColumsTo(processdatadefinition);
			processdatadefinition.Activity = text;
			processdatadefinition.CheckEntityUsable();
			obj.CopyCommonField(processdatadefinition, systemTime, dbContext.Tid, isCreate: true);
			list.Add(processdatadefinition);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateProcessDataDefinition(IDbContext dbContext, Processdatadefinition[] processDataDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processDataDefinitionList", processDataDefinitionList);
		string text = "UpdateProcessDataDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processdatadefinition> list = new List<Processdatadefinition>();
		foreach (Processdatadefinition processdatadefinition in processDataDefinitionList)
		{
			Processdatadefinition processDataDefinition4Update = GetProcessDataDefinition4Update(dbContext, processdatadefinition.Processdatadefinitionid, processdatadefinition.Siteid);
			if (processDataDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processdatadefinition), $"{processdatadefinition.Processdatadefinitionid},{processdatadefinition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Processdatadefinition), $"{processdatadefinition.Processdatadefinitionid},{processdatadefinition.Siteid}", processDataDefinition4Update.Isusable);
			string activity = processDataDefinition4Update.Activity;
			string customactivity = processDataDefinition4Update.Customactivity;
			string isusable = processDataDefinition4Update.Isusable;
			DateTime? createtime = processDataDefinition4Update.Createtime;
			string creator = processDataDefinition4Update.Creator;
			processdatadefinition.CopyColumsTo(processDataDefinition4Update);
			processDataDefinition4Update.Prevactivity = activity;
			processDataDefinition4Update.Prevcustomactivity = customactivity;
			processDataDefinition4Update.Creator = creator;
			processDataDefinition4Update.Createtime = createtime;
			processDataDefinition4Update.Isusable = isusable;
			processDataDefinition4Update.Activity = text;
			processdatadefinition.CopyCommonField(processDataDefinition4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(processDataDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteProcessDataDefinition(IDbContext dbContext, Processdatadefinition[] processDataDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processDataDefinitionList", processDataDefinitionList);
		string text = "DeleteProcessDataDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processdatadefinition> list = new List<Processdatadefinition>();
		foreach (Processdatadefinition processdatadefinition in processDataDefinitionList)
		{
			Processdatadefinition processDataDefinition4Update = GetProcessDataDefinition4Update(dbContext, processdatadefinition.Processdatadefinitionid, processdatadefinition.Siteid);
			if (processDataDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processdatadefinition), $"{processdatadefinition.Processdatadefinitionid},{processdatadefinition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Processdatadefinition), $"{processdatadefinition.Processdatadefinitionid},{processdatadefinition.Siteid}", processDataDefinition4Update.Isusable);
			processDataDefinition4Update.Isusable = "UnUsable";
			processdatadefinition.CopyCommonFieldUpdatePrev(processDataDefinition4Update, systemTime, dbContext.Tid, text);
			processdatadefinition.CopyExtensionCollection(processDataDefinition4Update);
			list.Add(processDataDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteProcessDataDefinition(IDbContext dbContext, Processdatadefinition[] processDataDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processDataDefinitionList", processDataDefinitionList);
		string text = "UnDeleteProcessDataDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processdatadefinition> list = new List<Processdatadefinition>();
		foreach (Processdatadefinition processdatadefinition in processDataDefinitionList)
		{
			Processdatadefinition processDataDefinition4Update = GetProcessDataDefinition4Update(dbContext, processdatadefinition.Processdatadefinitionid, processdatadefinition.Siteid);
			if (processDataDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processdatadefinition), $"{processdatadefinition.Processdatadefinitionid},{processdatadefinition.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Processdatadefinition), $"{processdatadefinition.Processdatadefinitionid},{processdatadefinition.Siteid}", processDataDefinition4Update.Isusable);
			processDataDefinition4Update.Isusable = "Usable";
			processdatadefinition.CopyCommonFieldUpdatePrev(processDataDefinition4Update, systemTime, dbContext.Tid, text);
			processdatadefinition.CopyExtensionCollection(processDataDefinition4Update);
			list.Add(processDataDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteProcessDataDefinition(IDbContext dbContext, Processdatadefinition[] processDataDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processDataDefinitionList", processDataDefinitionList);
		string text = "RealDeleteProcessDataDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processdatadefinition> list = new List<Processdatadefinition>();
		foreach (Processdatadefinition processdatadefinition in processDataDefinitionList)
		{
			Processdatadefinition processDataDefinition4Update = GetProcessDataDefinition4Update(dbContext, processdatadefinition.Processdatadefinitionid, processdatadefinition.Siteid);
			if (processDataDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processdatadefinition), $"{processdatadefinition.Processdatadefinitionid},{processdatadefinition.Siteid}");
			}
			processdatadefinition.CopyCommonFieldUpdatePrev(processDataDefinition4Update, systemTime, dbContext.Tid, text);
			processdatadefinition.CopyExtensionCollection(processDataDefinition4Update);
			list.Add(processDataDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
