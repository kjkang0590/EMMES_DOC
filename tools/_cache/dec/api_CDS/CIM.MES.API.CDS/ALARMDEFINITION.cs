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
public class ALARMDEFINITION
{
	private static string _sqlGetAlarmDefinitionSqlDatabase = "SELECT * FROM CIM_ALARMDEFINITION WHERE ALARMDEFINITIONID=@ALARMDEFINITIONID AND ALARMSOURCEID=@ALARMSOURCEID AND ALARMTYPE=@ALARMTYPE AND SITEID=@SITEID";

	private static string _sqlGetAlarmDefinition4UpdateSqlDatabase = "SELECT * FROM CIM_ALARMDEFINITION WITH(UPDLOCK) WHERE ALARMDEFINITIONID=@ALARMDEFINITIONID AND ALARMSOURCEID=@ALARMSOURCEID AND ALARMTYPE=@ALARMTYPE AND SITEID=@SITEID";

	private static string _sqlSelectAlarmDefinitionSqlDatabase = "SELECT * FROM CIM_ALARMDEFINITION WHERE ALARMDEFINITIONID=@ALARMDEFINITIONID AND ALARMSOURCEID=@ALARMSOURCEID AND ALARMTYPE=@ALARMTYPE AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectAlarmDefinition4UpdateSqlDatabase = "SELECT * FROM CIM_ALARMDEFINITION WITH(UPDLOCK) WHERE ALARMDEFINITIONID=@ALARMDEFINITIONID AND ALARMSOURCEID=@ALARMSOURCEID AND ALARMTYPE=@ALARMTYPE AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetAlarmDefinitionOracleDatabase = "SELECT * FROM CIM_ALARMDEFINITION WHERE ALARMDEFINITIONID=:ALARMDEFINITIONID AND ALARMSOURCEID=:ALARMSOURCEID AND ALARMTYPE=:ALARMTYPE AND SITEID=:SITEID";

	private static string _sqlGetAlarmDefinition4UpdateOracleDatabase = "SELECT * FROM CIM_ALARMDEFINITION WHERE ALARMDEFINITIONID=:ALARMDEFINITIONID AND ALARMSOURCEID=:ALARMSOURCEID AND ALARMTYPE=:ALARMTYPE AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectAlarmDefinitionOracleDatabase = "SELECT * FROM CIM_ALARMDEFINITION WHERE ALARMDEFINITIONID=:ALARMDEFINITIONID AND ALARMSOURCEID=:ALARMSOURCEID AND ALARMTYPE=:ALARMTYPE AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectAlarmDefinition4UpdateOracleDatabase = "SELECT * FROM CIM_ALARMDEFINITION WHERE ALARMDEFINITIONID=:ALARMDEFINITIONID AND ALARMSOURCEID=:ALARMSOURCEID AND ALARMTYPE=:ALARMTYPE AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Alarmdefinition);

	public static Alarmdefinition GetAlarmDefinition(IDbContext dbContext, string alarmdefinitionid, string alarmsourceid, string alarmtype, string siteid)
	{
		string apiName = "GetAlarmDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{alarmdefinitionid},{alarmsourceid},{alarmtype},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetAlarmDefinitionSqlDatabase : _sqlGetAlarmDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ALARMDEFINITIONID", alarmdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("ALARMSOURCEID", alarmsourceid, typeOfThis));
		list.Add(dbContext.CreateParameter("ALARMTYPE", alarmtype, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_ALARMDEFINITION", $"{alarmdefinitionid},{alarmsourceid},{alarmtype},{siteid}"));
		}
		Alarmdefinition result = ContextManager.DirectEntityQuery<Alarmdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{alarmdefinitionid},{alarmsourceid},{alarmtype},{siteid}");
		}
		return result;
	}

	public static Alarmdefinition GetAlarmDefinition4Update(IDbContext dbContext, string alarmdefinitionid, string alarmsourceid, string alarmtype, string siteid)
	{
		string apiName = "GetAlarmDefinition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{alarmdefinitionid},{alarmsourceid},{alarmtype},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetAlarmDefinition4UpdateSqlDatabase : _sqlGetAlarmDefinition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ALARMDEFINITIONID", alarmdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("ALARMSOURCEID", alarmsourceid, typeOfThis));
		list.Add(dbContext.CreateParameter("ALARMTYPE", alarmtype, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_ALARMDEFINITION", $"{alarmdefinitionid},{alarmsourceid},{alarmtype},{siteid}"));
		}
		Alarmdefinition result = ContextManager.DirectEntityQuery<Alarmdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{alarmdefinitionid},{alarmsourceid},{alarmtype},{siteid}");
		}
		return result;
	}

	public static Alarmdefinition SelectAlarmDefinition(IDbContext dbContext, string alarmdefinitionid, string alarmsourceid, string alarmtype, string siteid)
	{
		string apiName = "SelectAlarmDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{alarmdefinitionid},{alarmsourceid},{alarmtype},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectAlarmDefinitionSqlDatabase : _sqlSelectAlarmDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ALARMDEFINITIONID", alarmdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("ALARMSOURCEID", alarmsourceid, typeOfThis));
		list.Add(dbContext.CreateParameter("ALARMTYPE", alarmtype, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_ALARMDEFINITION", $"{alarmdefinitionid},{alarmsourceid},{alarmtype},{siteid}"));
		}
		Alarmdefinition result = ContextManager.DirectEntityQuery<Alarmdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{alarmdefinitionid},{alarmsourceid},{alarmtype},{siteid}");
		}
		return result;
	}

	public static Alarmdefinition SelectAlarmDefinition4Update(IDbContext dbContext, string alarmdefinitionid, string alarmsourceid, string alarmtype, string siteid)
	{
		string apiName = "SelectAlarmDefinition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{alarmdefinitionid},{alarmsourceid},{alarmtype},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectAlarmDefinition4UpdateSqlDatabase : _sqlSelectAlarmDefinition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ALARMDEFINITIONID", alarmdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("ALARMSOURCEID", alarmsourceid, typeOfThis));
		list.Add(dbContext.CreateParameter("ALARMTYPE", alarmtype, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_ALARMDEFINITION", $"{alarmdefinitionid},{alarmsourceid},{alarmtype},{siteid}"));
		}
		Alarmdefinition result = ContextManager.DirectEntityQuery<Alarmdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{alarmdefinitionid},{alarmsourceid},{alarmtype},{siteid}");
		}
		return result;
	}

	public static int UpsertAlarmDefinition(IDbContext dbContext, RequestType requestType, Alarmdefinition[] alarmDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateAlarmDefinitionInternal(dbContext, alarmDefinitionList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateAlarmDefinition(dbContext, alarmDefinitionList, optionSet, saveHist), 
			RequestType.DELETE => DeleteAlarmDefinition(dbContext, alarmDefinitionList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteAlarmDefinition(dbContext, alarmDefinitionList, optionSet, saveHist), 
			_ => RealDeleteAlarmDefinition(dbContext, alarmDefinitionList, optionSet, saveHist), 
		};
	}

	private static int CreateAlarmDefinitionInternal(IDbContext dbContext, Alarmdefinition[] alarmDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmDefinitionList", alarmDefinitionList);
		string text = "CreateAlarmDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarmdefinition> list = new List<Alarmdefinition>();
		foreach (Alarmdefinition obj in alarmDefinitionList)
		{
			Alarmdefinition alarmdefinition = new Alarmdefinition();
			obj.CopyColumsTo(alarmdefinition);
			alarmdefinition.Activity = text;
			alarmdefinition.CheckEntityUsable();
			obj.CopyCommonField(alarmdefinition, systemTime, dbContext.Tid, isCreate: true);
			list.Add(alarmdefinition);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateAlarmDefinition(IDbContext dbContext, Alarmdefinition[] alarmDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmDefinitionList", alarmDefinitionList);
		string text = "UpdateAlarmDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarmdefinition> list = new List<Alarmdefinition>();
		foreach (Alarmdefinition alarmdefinition in alarmDefinitionList)
		{
			Alarmdefinition alarmDefinition4Update = GetAlarmDefinition4Update(dbContext, alarmdefinition.Alarmdefinitionid, alarmdefinition.Alarmsourceid, alarmdefinition.Alarmtype, alarmdefinition.Siteid);
			if (alarmDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Alarmdefinition), $"{alarmdefinition.Alarmdefinitionid},{alarmdefinition.Alarmsourceid},{alarmdefinition.Alarmtype},{alarmdefinition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Alarmdefinition), $"{alarmdefinition.Alarmdefinitionid},{alarmdefinition.Alarmsourceid},{alarmdefinition.Alarmtype},{alarmdefinition.Siteid}", alarmDefinition4Update.Isusable);
			string activity = alarmDefinition4Update.Activity;
			string customactivity = alarmDefinition4Update.Customactivity;
			string isusable = alarmDefinition4Update.Isusable;
			DateTime? createtime = alarmDefinition4Update.Createtime;
			string creator = alarmDefinition4Update.Creator;
			alarmdefinition.CopyColumsTo(alarmDefinition4Update);
			alarmDefinition4Update.Prevactivity = activity;
			alarmDefinition4Update.Prevcustomactivity = customactivity;
			alarmDefinition4Update.Creator = creator;
			alarmDefinition4Update.Createtime = createtime;
			alarmDefinition4Update.Isusable = isusable;
			alarmDefinition4Update.Activity = text;
			alarmdefinition.CopyCommonField(alarmDefinition4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(alarmDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteAlarmDefinition(IDbContext dbContext, Alarmdefinition[] alarmDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmDefinitionList", alarmDefinitionList);
		string text = "DeleteAlarmDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarmdefinition> list = new List<Alarmdefinition>();
		foreach (Alarmdefinition alarmdefinition in alarmDefinitionList)
		{
			Alarmdefinition alarmDefinition4Update = GetAlarmDefinition4Update(dbContext, alarmdefinition.Alarmdefinitionid, alarmdefinition.Alarmsourceid, alarmdefinition.Alarmtype, alarmdefinition.Siteid);
			if (alarmDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Alarmdefinition), $"{alarmdefinition.Alarmdefinitionid},{alarmdefinition.Alarmsourceid},{alarmdefinition.Alarmtype},{alarmdefinition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Alarmdefinition), $"{alarmdefinition.Alarmdefinitionid},{alarmdefinition.Alarmsourceid},{alarmdefinition.Alarmtype},{alarmdefinition.Siteid}", alarmDefinition4Update.Isusable);
			alarmDefinition4Update.Isusable = "UnUsable";
			alarmdefinition.CopyCommonFieldUpdatePrev(alarmDefinition4Update, systemTime, dbContext.Tid, text);
			alarmdefinition.CopyExtensionCollection(alarmDefinition4Update);
			list.Add(alarmDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteAlarmDefinition(IDbContext dbContext, Alarmdefinition[] alarmDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmDefinitionList", alarmDefinitionList);
		string text = "UnDeleteAlarmDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarmdefinition> list = new List<Alarmdefinition>();
		foreach (Alarmdefinition alarmdefinition in alarmDefinitionList)
		{
			Alarmdefinition alarmDefinition4Update = GetAlarmDefinition4Update(dbContext, alarmdefinition.Alarmdefinitionid, alarmdefinition.Alarmsourceid, alarmdefinition.Alarmtype, alarmdefinition.Siteid);
			if (alarmDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Alarmdefinition), $"{alarmdefinition.Alarmdefinitionid},{alarmdefinition.Alarmsourceid},{alarmdefinition.Alarmtype},{alarmdefinition.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Alarmdefinition), $"{alarmdefinition.Alarmdefinitionid},{alarmdefinition.Alarmsourceid},{alarmdefinition.Alarmtype},{alarmdefinition.Siteid}", alarmDefinition4Update.Isusable);
			alarmDefinition4Update.Isusable = "Usable";
			alarmdefinition.CopyCommonFieldUpdatePrev(alarmDefinition4Update, systemTime, dbContext.Tid, text);
			alarmdefinition.CopyExtensionCollection(alarmDefinition4Update);
			list.Add(alarmDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteAlarmDefinition(IDbContext dbContext, Alarmdefinition[] alarmDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmDefinitionList", alarmDefinitionList);
		string text = "RealDeleteAlarmDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarmdefinition> list = new List<Alarmdefinition>();
		foreach (Alarmdefinition alarmdefinition in alarmDefinitionList)
		{
			Alarmdefinition alarmDefinition4Update = GetAlarmDefinition4Update(dbContext, alarmdefinition.Alarmdefinitionid, alarmdefinition.Alarmsourceid, alarmdefinition.Alarmtype, alarmdefinition.Siteid);
			if (alarmDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Alarmdefinition), $"{alarmdefinition.Alarmdefinitionid},{alarmdefinition.Alarmsourceid},{alarmdefinition.Alarmtype},{alarmdefinition.Siteid}");
			}
			alarmdefinition.CopyCommonFieldUpdatePrev(alarmDefinition4Update, systemTime, dbContext.Tid, text);
			alarmdefinition.CopyExtensionCollection(alarmDefinition4Update);
			list.Add(alarmDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
