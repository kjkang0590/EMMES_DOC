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
public class WORKCALENDARDEFINITION
{
	private static string _sqlGetWorkCalendarDefinitionSqlDatabase = "SELECT * FROM CIM_WORKCALENDARDEFINITION WHERE WORKCALENDARDEFINITIONSYSID=@WORKCALENDARDEFINITIONSYSID AND SITEID=@SITEID";

	private static string _sqlGetWorkCalendarDefinition4UpdateSqlDatabase = "SELECT * FROM CIM_WORKCALENDARDEFINITION WITH(UPDLOCK) WHERE WORKCALENDARDEFINITIONSYSID=@WORKCALENDARDEFINITIONSYSID AND SITEID=@SITEID";

	private static string _sqlSelectWorkCalendarDefinitionSqlDatabase = "SELECT * FROM CIM_WORKCALENDARDEFINITION WHERE WORKCALENDARDEFINITIONSYSID=@WORKCALENDARDEFINITIONSYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectWorkCalendarDefinition4UpdateSqlDatabase = "SELECT * FROM CIM_WORKCALENDARDEFINITION WITH(UPDLOCK) WHERE WORKCALENDARDEFINITIONSYSID=@WORKCALENDARDEFINITIONSYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetWorkCalendarDefinitionOracleDatabase = "SELECT * FROM CIM_WORKCALENDARDEFINITION WHERE WORKCALENDARDEFINITIONSYSID=:WORKCALENDARDEFINITIONSYSID AND SITEID=:SITEID";

	private static string _sqlGetWorkCalendarDefinition4UpdateOracleDatabase = "SELECT * FROM CIM_WORKCALENDARDEFINITION WHERE WORKCALENDARDEFINITIONSYSID=:WORKCALENDARDEFINITIONSYSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectWorkCalendarDefinitionOracleDatabase = "SELECT * FROM CIM_WORKCALENDARDEFINITION WHERE WORKCALENDARDEFINITIONSYSID=:WORKCALENDARDEFINITIONSYSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectWorkCalendarDefinition4UpdateOracleDatabase = "SELECT * FROM CIM_WORKCALENDARDEFINITION WHERE WORKCALENDARDEFINITIONSYSID=:WORKCALENDARDEFINITIONSYSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Workcalendardefinition);

	public static Workcalendardefinition GetWorkCalendarDefinition(IDbContext dbContext, string workcalendardefinitionsysid, string siteid)
	{
		string apiName = "GetWorkCalendarDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{workcalendardefinitionsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetWorkCalendarDefinitionSqlDatabase : _sqlGetWorkCalendarDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("WORKCALENDARDEFINITIONSYSID", workcalendardefinitionsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_WORKCALENDARDEFINITION", $"{workcalendardefinitionsysid},{siteid}"));
		}
		Workcalendardefinition? result = ContextManager.DirectEntityQuery<Workcalendardefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{workcalendardefinitionsysid},{siteid}");
		}
		return result;
	}

	public static Workcalendardefinition GetWorkCalendarDefinition4Update(IDbContext dbContext, string workcalendardefinitionsysid, string siteid)
	{
		string apiName = "GetWorkCalendarDefinition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{workcalendardefinitionsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetWorkCalendarDefinition4UpdateSqlDatabase : _sqlGetWorkCalendarDefinition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("WORKCALENDARDEFINITIONSYSID", workcalendardefinitionsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_WORKCALENDARDEFINITION", $"{workcalendardefinitionsysid},{siteid}"));
		}
		Workcalendardefinition? result = ContextManager.DirectEntityQuery<Workcalendardefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{workcalendardefinitionsysid},{siteid}");
		}
		return result;
	}

	public static Workcalendardefinition SelectWorkCalendarDefinition(IDbContext dbContext, string workcalendardefinitionsysid, string siteid)
	{
		string apiName = "SelectWorkCalendarDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{workcalendardefinitionsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectWorkCalendarDefinitionSqlDatabase : _sqlSelectWorkCalendarDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("WORKCALENDARDEFINITIONSYSID", workcalendardefinitionsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_WORKCALENDARDEFINITION", $"{workcalendardefinitionsysid},{siteid}"));
		}
		Workcalendardefinition? result = ContextManager.DirectEntityQuery<Workcalendardefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{workcalendardefinitionsysid},{siteid}");
		}
		return result;
	}

	public static Workcalendardefinition SelectWorkCalendarDefinition4Update(IDbContext dbContext, string workcalendardefinitionsysid, string siteid)
	{
		string apiName = "SelectWorkCalendarDefinition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{workcalendardefinitionsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectWorkCalendarDefinition4UpdateSqlDatabase : _sqlSelectWorkCalendarDefinition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("WORKCALENDARDEFINITIONSYSID", workcalendardefinitionsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_WORKCALENDARDEFINITION", $"{workcalendardefinitionsysid},{siteid}"));
		}
		Workcalendardefinition? result = ContextManager.DirectEntityQuery<Workcalendardefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{workcalendardefinitionsysid},{siteid}");
		}
		return result;
	}

	public static int UpsertWorkCalendarDefinition(IDbContext dbContext, RequestType requestType, Workcalendardefinition[] workCalendarDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateWorkCalendarDefinitionInternal(dbContext, workCalendarDefinitionList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateWorkCalendarDefinition(dbContext, workCalendarDefinitionList, optionSet, saveHist), 
			RequestType.DELETE => DeleteWorkCalendarDefinition(dbContext, workCalendarDefinitionList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteWorkCalendarDefinition(dbContext, workCalendarDefinitionList, optionSet, saveHist), 
			_ => RealDeleteWorkCalendarDefinition(dbContext, workCalendarDefinitionList, optionSet, saveHist), 
		};
	}

	private static int CreateWorkCalendarDefinitionInternal(IDbContext dbContext, Workcalendardefinition[] workCalendarDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("workCalendarDefinitionList", workCalendarDefinitionList);
		string text = "CreateWorkCalendarDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Workcalendardefinition> list = new List<Workcalendardefinition>();
		foreach (Workcalendardefinition obj in workCalendarDefinitionList)
		{
			Workcalendardefinition workcalendardefinition = new Workcalendardefinition();
			obj.CopyColumsTo(workcalendardefinition);
			workcalendardefinition.Activity = text;
			workcalendardefinition.CheckEntityUsable();
			obj.CopyCommonField(workcalendardefinition, systemTime, dbContext.Tid, isCreate: true);
			list.Add(workcalendardefinition);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateWorkCalendarDefinition(IDbContext dbContext, Workcalendardefinition[] workCalendarDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("workCalendarDefinitionList", workCalendarDefinitionList);
		string text = "UpdateWorkCalendarDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Workcalendardefinition> list = new List<Workcalendardefinition>();
		foreach (Workcalendardefinition workcalendardefinition in workCalendarDefinitionList)
		{
			Workcalendardefinition workCalendarDefinition4Update = GetWorkCalendarDefinition4Update(dbContext, workcalendardefinition.Workcalendardefinitionsysid, workcalendardefinition.Siteid);
			if (workCalendarDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Workcalendardefinition), $"{workcalendardefinition.Workcalendardefinitionsysid},{workcalendardefinition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Workcalendardefinition), $"{workcalendardefinition.Workcalendardefinitionsysid},{workcalendardefinition.Siteid}", workCalendarDefinition4Update.Isusable);
			string activity = workCalendarDefinition4Update.Activity;
			string customactivity = workCalendarDefinition4Update.Customactivity;
			string isusable = workCalendarDefinition4Update.Isusable;
			DateTime? createtime = workCalendarDefinition4Update.Createtime;
			string creator = workCalendarDefinition4Update.Creator;
			workcalendardefinition.CopyColumsTo(workCalendarDefinition4Update);
			workCalendarDefinition4Update.Prevactivity = activity;
			workCalendarDefinition4Update.Prevcustomactivity = customactivity;
			workCalendarDefinition4Update.Creator = creator;
			workCalendarDefinition4Update.Createtime = createtime;
			workCalendarDefinition4Update.Isusable = isusable;
			workCalendarDefinition4Update.Activity = text;
			workcalendardefinition.CopyCommonField(workCalendarDefinition4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(workCalendarDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteWorkCalendarDefinition(IDbContext dbContext, Workcalendardefinition[] workCalendarDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("workCalendarDefinitionList", workCalendarDefinitionList);
		string text = "DeleteWorkCalendarDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Workcalendardefinition> list = new List<Workcalendardefinition>();
		foreach (Workcalendardefinition workcalendardefinition in workCalendarDefinitionList)
		{
			Workcalendardefinition workCalendarDefinition4Update = GetWorkCalendarDefinition4Update(dbContext, workcalendardefinition.Workcalendardefinitionsysid, workcalendardefinition.Siteid);
			if (workCalendarDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Workcalendardefinition), $"{workcalendardefinition.Workcalendardefinitionsysid},{workcalendardefinition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Workcalendardefinition), $"{workcalendardefinition.Workcalendardefinitionsysid},{workcalendardefinition.Siteid}", workCalendarDefinition4Update.Isusable);
			workCalendarDefinition4Update.Isusable = "UnUsable";
			workcalendardefinition.CopyCommonFieldUpdatePrev(workCalendarDefinition4Update, systemTime, dbContext.Tid, text);
			workcalendardefinition.CopyExtensionCollection(workCalendarDefinition4Update);
			list.Add(workCalendarDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteWorkCalendarDefinition(IDbContext dbContext, Workcalendardefinition[] workCalendarDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("workCalendarDefinitionList", workCalendarDefinitionList);
		string text = "UnDeleteWorkCalendarDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Workcalendardefinition> list = new List<Workcalendardefinition>();
		foreach (Workcalendardefinition workcalendardefinition in workCalendarDefinitionList)
		{
			Workcalendardefinition workCalendarDefinition4Update = GetWorkCalendarDefinition4Update(dbContext, workcalendardefinition.Workcalendardefinitionsysid, workcalendardefinition.Siteid);
			if (workCalendarDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Workcalendardefinition), $"{workcalendardefinition.Workcalendardefinitionsysid},{workcalendardefinition.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Workcalendardefinition), $"{workcalendardefinition.Workcalendardefinitionsysid},{workcalendardefinition.Siteid}", workCalendarDefinition4Update.Isusable);
			workCalendarDefinition4Update.Isusable = "Usable";
			workcalendardefinition.CopyCommonFieldUpdatePrev(workCalendarDefinition4Update, systemTime, dbContext.Tid, text);
			workcalendardefinition.CopyExtensionCollection(workCalendarDefinition4Update);
			list.Add(workCalendarDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteWorkCalendarDefinition(IDbContext dbContext, Workcalendardefinition[] workCalendarDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("workCalendarDefinitionList", workCalendarDefinitionList);
		string text = "RealDeleteWorkCalendarDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Workcalendardefinition> list = new List<Workcalendardefinition>();
		foreach (Workcalendardefinition workcalendardefinition in workCalendarDefinitionList)
		{
			Workcalendardefinition workCalendarDefinition4Update = GetWorkCalendarDefinition4Update(dbContext, workcalendardefinition.Workcalendardefinitionsysid, workcalendardefinition.Siteid);
			if (workCalendarDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Workcalendardefinition), $"{workcalendardefinition.Workcalendardefinitionsysid},{workcalendardefinition.Siteid}");
			}
			workcalendardefinition.CopyCommonFieldUpdatePrev(workCalendarDefinition4Update, systemTime, dbContext.Tid, text);
			workcalendardefinition.CopyExtensionCollection(workCalendarDefinition4Update);
			list.Add(workCalendarDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
