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
public class TRACEDATADEFINITION
{
	private static string _sqlGetTraceDataDefinitionSqlDatabase = "SELECT * FROM CIM_TRACEDATADEFINITION WHERE TRACEDATADEFINITIONID=@TRACEDATADEFINITIONID AND SITEID=@SITEID";

	private static string _sqlGetTraceDataDefinition4UpdateSqlDatabase = "SELECT * FROM CIM_TRACEDATADEFINITION WITH(UPDLOCK) WHERE TRACEDATADEFINITIONID=@TRACEDATADEFINITIONID AND SITEID=@SITEID";

	private static string _sqlSelectTraceDataDefinitionSqlDatabase = "SELECT * FROM CIM_TRACEDATADEFINITION WHERE TRACEDATADEFINITIONID=@TRACEDATADEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectTraceDataDefinition4UpdateSqlDatabase = "SELECT * FROM CIM_TRACEDATADEFINITION WITH(UPDLOCK) WHERE TRACEDATADEFINITIONID=@TRACEDATADEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetTraceDataDefinitionOracleDatabase = "SELECT * FROM CIM_TRACEDATADEFINITION WHERE TRACEDATADEFINITIONID=:TRACEDATADEFINITIONID AND SITEID=:SITEID";

	private static string _sqlGetTraceDataDefinition4UpdateOracleDatabase = "SELECT * FROM CIM_TRACEDATADEFINITION WHERE TRACEDATADEFINITIONID=:TRACEDATADEFINITIONID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectTraceDataDefinitionOracleDatabase = "SELECT * FROM CIM_TRACEDATADEFINITION WHERE TRACEDATADEFINITIONID=:TRACEDATADEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectTraceDataDefinition4UpdateOracleDatabase = "SELECT * FROM CIM_TRACEDATADEFINITION WHERE TRACEDATADEFINITIONID=:TRACEDATADEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Tracedatadefinition);

	public static Tracedatadefinition GetTraceDataDefinition(IDbContext dbContext, string tracedatadefinitionid, string siteid)
	{
		string apiName = "GetTraceDataDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tracedatadefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetTraceDataDefinitionSqlDatabase : _sqlGetTraceDataDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TRACEDATADEFINITIONID", tracedatadefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_TRACEDATADEFINITION", $"{tracedatadefinitionid},{siteid}"));
		}
		Tracedatadefinition? result = ContextManager.DirectEntityQuery<Tracedatadefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tracedatadefinitionid},{siteid}");
		}
		return result;
	}

	public static Tracedatadefinition GetTraceDataDefinition4Update(IDbContext dbContext, string tracedatadefinitionid, string siteid)
	{
		string apiName = "GetTraceDataDefinition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tracedatadefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetTraceDataDefinition4UpdateSqlDatabase : _sqlGetTraceDataDefinition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TRACEDATADEFINITIONID", tracedatadefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_TRACEDATADEFINITION", $"{tracedatadefinitionid},{siteid}"));
		}
		Tracedatadefinition? result = ContextManager.DirectEntityQuery<Tracedatadefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tracedatadefinitionid},{siteid}");
		}
		return result;
	}

	public static Tracedatadefinition SelectTraceDataDefinition(IDbContext dbContext, string tracedatadefinitionid, string siteid)
	{
		string apiName = "SelectTraceDataDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tracedatadefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectTraceDataDefinitionSqlDatabase : _sqlSelectTraceDataDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TRACEDATADEFINITIONID", tracedatadefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_TRACEDATADEFINITION", $"{tracedatadefinitionid},{siteid}"));
		}
		Tracedatadefinition? result = ContextManager.DirectEntityQuery<Tracedatadefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tracedatadefinitionid},{siteid}");
		}
		return result;
	}

	public static Tracedatadefinition SelectTraceDataDefinition4Update(IDbContext dbContext, string tracedatadefinitionid, string siteid)
	{
		string apiName = "SelectTraceDataDefinition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tracedatadefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectTraceDataDefinition4UpdateSqlDatabase : _sqlSelectTraceDataDefinition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TRACEDATADEFINITIONID", tracedatadefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_TRACEDATADEFINITION", $"{tracedatadefinitionid},{siteid}"));
		}
		Tracedatadefinition? result = ContextManager.DirectEntityQuery<Tracedatadefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tracedatadefinitionid},{siteid}");
		}
		return result;
	}

	public static int UpsertTraceDataDefinition(IDbContext dbContext, RequestType requestType, Tracedatadefinition[] traceDataDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateTraceDataDefinitionInternal(dbContext, traceDataDefinitionList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateTraceDataDefinition(dbContext, traceDataDefinitionList, optionSet, saveHist), 
			RequestType.DELETE => DeleteTraceDataDefinition(dbContext, traceDataDefinitionList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteTraceDataDefinition(dbContext, traceDataDefinitionList, optionSet, saveHist), 
			_ => RealDeleteTraceDataDefinition(dbContext, traceDataDefinitionList, optionSet, saveHist), 
		};
	}

	private static int CreateTraceDataDefinitionInternal(IDbContext dbContext, Tracedatadefinition[] traceDataDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceDataDefinitionList", traceDataDefinitionList);
		string text = "CreateTraceDataDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tracedatadefinition> list = new List<Tracedatadefinition>();
		foreach (Tracedatadefinition obj in traceDataDefinitionList)
		{
			Tracedatadefinition tracedatadefinition = new Tracedatadefinition();
			obj.CopyColumsTo(tracedatadefinition);
			tracedatadefinition.Activity = text;
			tracedatadefinition.CheckEntityUsable();
			obj.CopyCommonField(tracedatadefinition, systemTime, dbContext.Tid, isCreate: true);
			list.Add(tracedatadefinition);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateTraceDataDefinition(IDbContext dbContext, Tracedatadefinition[] traceDataDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceDataDefinitionList", traceDataDefinitionList);
		string text = "UpdateTraceDataDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tracedatadefinition> list = new List<Tracedatadefinition>();
		foreach (Tracedatadefinition tracedatadefinition in traceDataDefinitionList)
		{
			Tracedatadefinition traceDataDefinition4Update = GetTraceDataDefinition4Update(dbContext, tracedatadefinition.Tracedatadefinitionid, tracedatadefinition.Siteid);
			if (traceDataDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Tracedatadefinition), $"{tracedatadefinition.Tracedatadefinitionid},{tracedatadefinition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Tracedatadefinition), $"{tracedatadefinition.Tracedatadefinitionid},{tracedatadefinition.Siteid}", traceDataDefinition4Update.Isusable);
			string activity = traceDataDefinition4Update.Activity;
			string customactivity = traceDataDefinition4Update.Customactivity;
			string isusable = traceDataDefinition4Update.Isusable;
			DateTime? createtime = traceDataDefinition4Update.Createtime;
			string creator = traceDataDefinition4Update.Creator;
			tracedatadefinition.CopyColumsTo(traceDataDefinition4Update);
			traceDataDefinition4Update.Prevactivity = activity;
			traceDataDefinition4Update.Prevcustomactivity = customactivity;
			traceDataDefinition4Update.Creator = creator;
			traceDataDefinition4Update.Createtime = createtime;
			traceDataDefinition4Update.Isusable = isusable;
			traceDataDefinition4Update.Activity = text;
			tracedatadefinition.CopyCommonField(traceDataDefinition4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(traceDataDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteTraceDataDefinition(IDbContext dbContext, Tracedatadefinition[] traceDataDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceDataDefinitionList", traceDataDefinitionList);
		string text = "DeleteTraceDataDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tracedatadefinition> list = new List<Tracedatadefinition>();
		foreach (Tracedatadefinition tracedatadefinition in traceDataDefinitionList)
		{
			Tracedatadefinition traceDataDefinition4Update = GetTraceDataDefinition4Update(dbContext, tracedatadefinition.Tracedatadefinitionid, tracedatadefinition.Siteid);
			if (traceDataDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Tracedatadefinition), $"{tracedatadefinition.Tracedatadefinitionid},{tracedatadefinition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Tracedatadefinition), $"{tracedatadefinition.Tracedatadefinitionid},{tracedatadefinition.Siteid}", traceDataDefinition4Update.Isusable);
			traceDataDefinition4Update.Isusable = "UnUsable";
			tracedatadefinition.CopyCommonFieldUpdatePrev(traceDataDefinition4Update, systemTime, dbContext.Tid, text);
			tracedatadefinition.CopyExtensionCollection(traceDataDefinition4Update);
			list.Add(traceDataDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteTraceDataDefinition(IDbContext dbContext, Tracedatadefinition[] traceDataDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceDataDefinitionList", traceDataDefinitionList);
		string text = "UnDeleteTraceDataDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tracedatadefinition> list = new List<Tracedatadefinition>();
		foreach (Tracedatadefinition tracedatadefinition in traceDataDefinitionList)
		{
			Tracedatadefinition traceDataDefinition4Update = GetTraceDataDefinition4Update(dbContext, tracedatadefinition.Tracedatadefinitionid, tracedatadefinition.Siteid);
			if (traceDataDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Tracedatadefinition), $"{tracedatadefinition.Tracedatadefinitionid},{tracedatadefinition.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Tracedatadefinition), $"{tracedatadefinition.Tracedatadefinitionid},{tracedatadefinition.Siteid}", traceDataDefinition4Update.Isusable);
			traceDataDefinition4Update.Isusable = "Usable";
			tracedatadefinition.CopyCommonFieldUpdatePrev(traceDataDefinition4Update, systemTime, dbContext.Tid, text);
			tracedatadefinition.CopyExtensionCollection(traceDataDefinition4Update);
			list.Add(traceDataDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteTraceDataDefinition(IDbContext dbContext, Tracedatadefinition[] traceDataDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceDataDefinitionList", traceDataDefinitionList);
		string text = "RealDeleteTraceDataDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tracedatadefinition> list = new List<Tracedatadefinition>();
		foreach (Tracedatadefinition tracedatadefinition in traceDataDefinitionList)
		{
			Tracedatadefinition traceDataDefinition4Update = GetTraceDataDefinition4Update(dbContext, tracedatadefinition.Tracedatadefinitionid, tracedatadefinition.Siteid);
			if (traceDataDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Tracedatadefinition), $"{tracedatadefinition.Tracedatadefinitionid},{tracedatadefinition.Siteid}");
			}
			tracedatadefinition.CopyCommonFieldUpdatePrev(traceDataDefinition4Update, systemTime, dbContext.Tid, text);
			tracedatadefinition.CopyExtensionCollection(traceDataDefinition4Update);
			list.Add(traceDataDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
