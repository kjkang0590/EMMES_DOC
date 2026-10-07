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
public class ENUMDEFINITION
{
	private static string _sqlGetEnumDefinitionSqlDatabase = "SELECT * FROM CIM_ENUMDEFINITION WHERE ENUMCLASSID=@ENUMCLASSID AND ENUMDEFINITIONID=@ENUMDEFINITIONID AND SITEID=@SITEID";

	private static string _sqlGetEnumDefinition4UpdateSqlDatabase = "SELECT * FROM CIM_ENUMDEFINITION WITH(UPDLOCK) WHERE ENUMCLASSID=@ENUMCLASSID AND ENUMDEFINITIONID=@ENUMDEFINITIONID AND SITEID=@SITEID";

	private static string _sqlSelectEnumDefinitionSqlDatabase = "SELECT * FROM CIM_ENUMDEFINITION WHERE ENUMCLASSID=@ENUMCLASSID AND ENUMDEFINITIONID=@ENUMDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectEnumDefinition4UpdateSqlDatabase = "SELECT * FROM CIM_ENUMDEFINITION WITH(UPDLOCK) WHERE ENUMCLASSID=@ENUMCLASSID AND ENUMDEFINITIONID=@ENUMDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetEnumDefinitionOracleDatabase = "SELECT * FROM CIM_ENUMDEFINITION WHERE ENUMCLASSID=:ENUMCLASSID AND ENUMDEFINITIONID=:ENUMDEFINITIONID AND SITEID=:SITEID";

	private static string _sqlGetEnumDefinition4UpdateOracleDatabase = "SELECT * FROM CIM_ENUMDEFINITION WHERE ENUMCLASSID=:ENUMCLASSID AND ENUMDEFINITIONID=:ENUMDEFINITIONID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectEnumDefinitionOracleDatabase = "SELECT * FROM CIM_ENUMDEFINITION WHERE ENUMCLASSID=:ENUMCLASSID AND ENUMDEFINITIONID=:ENUMDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectEnumDefinition4UpdateOracleDatabase = "SELECT * FROM CIM_ENUMDEFINITION WHERE ENUMCLASSID=:ENUMCLASSID AND ENUMDEFINITIONID=:ENUMDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Enumdefinition);

	public static Enumdefinition GetEnumDefinition(IDbContext dbContext, string enumclassid, string enumdefinitionid, string siteid)
	{
		string apiName = "GetEnumDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{enumclassid},{enumdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetEnumDefinitionSqlDatabase : _sqlGetEnumDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ENUMCLASSID", enumclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("ENUMDEFINITIONID", enumdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_ENUMDEFINITION", $"{enumclassid},{enumdefinitionid},{siteid}"));
		}
		Enumdefinition? result = ContextManager.DirectEntityQuery<Enumdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{enumclassid},{enumdefinitionid},{siteid}");
		}
		return result;
	}

	public static Enumdefinition GetEnumDefinition4Update(IDbContext dbContext, string enumclassid, string enumdefinitionid, string siteid)
	{
		string apiName = "GetEnumDefinition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{enumclassid},{enumdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetEnumDefinition4UpdateSqlDatabase : _sqlGetEnumDefinition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ENUMCLASSID", enumclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("ENUMDEFINITIONID", enumdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_ENUMDEFINITION", $"{enumclassid},{enumdefinitionid},{siteid}"));
		}
		Enumdefinition? result = ContextManager.DirectEntityQuery<Enumdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{enumclassid},{enumdefinitionid},{siteid}");
		}
		return result;
	}

	public static Enumdefinition SelectEnumDefinition(IDbContext dbContext, string enumclassid, string enumdefinitionid, string siteid)
	{
		string apiName = "SelectEnumDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{enumclassid},{enumdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectEnumDefinitionSqlDatabase : _sqlSelectEnumDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ENUMCLASSID", enumclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("ENUMDEFINITIONID", enumdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_ENUMDEFINITION", $"{enumclassid},{enumdefinitionid},{siteid}"));
		}
		Enumdefinition? result = ContextManager.DirectEntityQuery<Enumdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{enumclassid},{enumdefinitionid},{siteid}");
		}
		return result;
	}

	public static Enumdefinition SelectEnumDefinition4Update(IDbContext dbContext, string enumclassid, string enumdefinitionid, string siteid)
	{
		string apiName = "SelectEnumDefinition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{enumclassid},{enumdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectEnumDefinition4UpdateSqlDatabase : _sqlSelectEnumDefinition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ENUMCLASSID", enumclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("ENUMDEFINITIONID", enumdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_ENUMDEFINITION", $"{enumclassid},{enumdefinitionid},{siteid}"));
		}
		Enumdefinition? result = ContextManager.DirectEntityQuery<Enumdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{enumclassid},{enumdefinitionid},{siteid}");
		}
		return result;
	}

	public static int UpsertEnumDefinition(IDbContext dbContext, RequestType requestType, Enumdefinition[] enumDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateEnumDefinitionInternal(dbContext, enumDefinitionList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateEnumDefinition(dbContext, enumDefinitionList, optionSet, saveHist), 
			RequestType.DELETE => DeleteEnumDefinition(dbContext, enumDefinitionList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteEnumDefinition(dbContext, enumDefinitionList, optionSet, saveHist), 
			_ => RealDeleteEnumDefinition(dbContext, enumDefinitionList, optionSet, saveHist), 
		};
	}

	private static int CreateEnumDefinitionInternal(IDbContext dbContext, Enumdefinition[] enumDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("enumDefinitionList", enumDefinitionList);
		string text = "CreateEnumDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Enumdefinition> list = new List<Enumdefinition>();
		foreach (Enumdefinition obj in enumDefinitionList)
		{
			Enumdefinition enumdefinition = new Enumdefinition();
			obj.CopyColumsTo(enumdefinition);
			enumdefinition.Activity = text;
			enumdefinition.CheckEntityUsable();
			obj.CopyCommonField(enumdefinition, systemTime, dbContext.Tid, isCreate: true);
			list.Add(enumdefinition);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateEnumDefinition(IDbContext dbContext, Enumdefinition[] enumDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("enumDefinitionList", enumDefinitionList);
		string text = "UpdateEnumDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Enumdefinition> list = new List<Enumdefinition>();
		foreach (Enumdefinition enumdefinition in enumDefinitionList)
		{
			Enumdefinition enumDefinition4Update = GetEnumDefinition4Update(dbContext, enumdefinition.Enumclassid, enumdefinition.Enumdefinitionid, enumdefinition.Siteid);
			if (enumDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Enumdefinition), $"{enumdefinition.Enumclassid},{enumdefinition.Enumdefinitionid},{enumdefinition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Enumdefinition), $"{enumdefinition.Enumclassid},{enumdefinition.Enumdefinitionid},{enumdefinition.Siteid}", enumDefinition4Update.Isusable);
			string activity = enumDefinition4Update.Activity;
			string customactivity = enumDefinition4Update.Customactivity;
			string isusable = enumDefinition4Update.Isusable;
			DateTime? createtime = enumDefinition4Update.Createtime;
			string creator = enumDefinition4Update.Creator;
			enumdefinition.CopyColumsTo(enumDefinition4Update);
			enumDefinition4Update.Prevactivity = activity;
			enumDefinition4Update.Prevcustomactivity = customactivity;
			enumDefinition4Update.Creator = creator;
			enumDefinition4Update.Createtime = createtime;
			enumDefinition4Update.Isusable = isusable;
			enumDefinition4Update.Activity = text;
			enumdefinition.CopyCommonField(enumDefinition4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(enumDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteEnumDefinition(IDbContext dbContext, Enumdefinition[] enumDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("enumDefinitionList", enumDefinitionList);
		string text = "DeleteEnumDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Enumdefinition> list = new List<Enumdefinition>();
		foreach (Enumdefinition enumdefinition in enumDefinitionList)
		{
			Enumdefinition enumDefinition4Update = GetEnumDefinition4Update(dbContext, enumdefinition.Enumclassid, enumdefinition.Enumdefinitionid, enumdefinition.Siteid);
			if (enumDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Enumdefinition), $"{enumdefinition.Enumclassid},{enumdefinition.Enumdefinitionid},{enumdefinition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Enumdefinition), $"{enumdefinition.Enumclassid},{enumdefinition.Enumdefinitionid},{enumdefinition.Siteid}", enumDefinition4Update.Isusable);
			enumDefinition4Update.Isusable = "UnUsable";
			enumdefinition.CopyCommonFieldUpdatePrev(enumDefinition4Update, systemTime, dbContext.Tid, text);
			enumdefinition.CopyExtensionCollection(enumDefinition4Update);
			list.Add(enumDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteEnumDefinition(IDbContext dbContext, Enumdefinition[] enumDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("enumDefinitionList", enumDefinitionList);
		string text = "UnDeleteEnumDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Enumdefinition> list = new List<Enumdefinition>();
		foreach (Enumdefinition enumdefinition in enumDefinitionList)
		{
			Enumdefinition enumDefinition4Update = GetEnumDefinition4Update(dbContext, enumdefinition.Enumclassid, enumdefinition.Enumdefinitionid, enumdefinition.Siteid);
			if (enumDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Enumdefinition), $"{enumdefinition.Enumclassid},{enumdefinition.Enumdefinitionid},{enumdefinition.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Enumdefinition), $"{enumdefinition.Enumclassid},{enumdefinition.Enumdefinitionid},{enumdefinition.Siteid}", enumDefinition4Update.Isusable);
			enumDefinition4Update.Isusable = "Usable";
			enumdefinition.CopyCommonFieldUpdatePrev(enumDefinition4Update, systemTime, dbContext.Tid, text);
			enumdefinition.CopyExtensionCollection(enumDefinition4Update);
			list.Add(enumDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteEnumDefinition(IDbContext dbContext, Enumdefinition[] enumDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("enumDefinitionList", enumDefinitionList);
		string text = "RealDeleteEnumDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Enumdefinition> list = new List<Enumdefinition>();
		foreach (Enumdefinition enumdefinition in enumDefinitionList)
		{
			Enumdefinition enumDefinition4Update = GetEnumDefinition4Update(dbContext, enumdefinition.Enumclassid, enumdefinition.Enumdefinitionid, enumdefinition.Siteid);
			if (enumDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Enumdefinition), $"{enumdefinition.Enumclassid},{enumdefinition.Enumdefinitionid},{enumdefinition.Siteid}");
			}
			enumdefinition.CopyCommonFieldUpdatePrev(enumDefinition4Update, systemTime, dbContext.Tid, text);
			enumdefinition.CopyExtensionCollection(enumDefinition4Update);
			list.Add(enumDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
