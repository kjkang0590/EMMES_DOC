using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.RDS;

[MESAPI]
public class SPARTDEFINITION
{
	private static string _sqlGetSpartDefinitionSqlDatabase = "SELECT * FROM CIM_SPARTDEFINITION WHERE SPARTDEFINITIONID=@SPARTDEFINITIONID AND SITEID=@SITEID";

	private static string _sqlGetSpartDefinition4UpdateSqlDatabase = "SELECT * FROM CIM_SPARTDEFINITION WITH(UPDLOCK) WHERE SPARTDEFINITIONID=@SPARTDEFINITIONID AND SITEID=@SITEID";

	private static string _sqlSelectSpartDefinitionSqlDatabase = "SELECT * FROM CIM_SPARTDEFINITION WHERE SPARTDEFINITIONID=@SPARTDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectSpartDefinition4UpdateSqlDatabase = "SELECT * FROM CIM_SPARTDEFINITION WITH(UPDLOCK) WHERE SPARTDEFINITIONID=@SPARTDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetSpartDefinitionOracleDatabase = "SELECT * FROM CIM_SPARTDEFINITION WHERE SPARTDEFINITIONID=:SPARTDEFINITIONID AND SITEID=:SITEID";

	private static string _sqlGetSpartDefinition4UpdateOracleDatabase = "SELECT * FROM CIM_SPARTDEFINITION WHERE SPARTDEFINITIONID=:SPARTDEFINITIONID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectSpartDefinitionOracleDatabase = "SELECT * FROM CIM_SPARTDEFINITION WHERE SPARTDEFINITIONID=:SPARTDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectSpartDefinition4UpdateOracleDatabase = "SELECT * FROM CIM_SPARTDEFINITION WHERE SPARTDEFINITIONID=:SPARTDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Spartdefinition);

	public static Spartdefinition GetSpartDefinition(IDbContext dbContext, string spartdefinitionid, string siteid)
	{
		string apiName = "GetSpartDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{spartdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetSpartDefinitionSqlDatabase : _sqlGetSpartDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SPARTDEFINITIONID", spartdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SPARTDEFINITION", $"{spartdefinitionid},{siteid}"));
		}
		Spartdefinition? result = ContextManager.DirectEntityQuery<Spartdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{spartdefinitionid},{siteid}");
		}
		return result;
	}

	public static Spartdefinition GetSpartDefinition4Update(IDbContext dbContext, string spartdefinitionid, string siteid)
	{
		string apiName = "GetSpartDefinition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{spartdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetSpartDefinition4UpdateSqlDatabase : _sqlGetSpartDefinition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SPARTDEFINITIONID", spartdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_SPARTDEFINITION", $"{spartdefinitionid},{siteid}"));
		}
		Spartdefinition? result = ContextManager.DirectEntityQuery<Spartdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{spartdefinitionid},{siteid}");
		}
		return result;
	}

	public static Spartdefinition SelectSpartDefinition(IDbContext dbContext, string spartdefinitionid, string siteid)
	{
		string apiName = "SelectSpartDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{spartdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectSpartDefinitionSqlDatabase : _sqlSelectSpartDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SPARTDEFINITIONID", spartdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SPARTDEFINITION", $"{spartdefinitionid},{siteid}"));
		}
		Spartdefinition? result = ContextManager.DirectEntityQuery<Spartdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{spartdefinitionid},{siteid}");
		}
		return result;
	}

	public static Spartdefinition SelectSpartDefinition4Update(IDbContext dbContext, string spartdefinitionid, string siteid)
	{
		string apiName = "SelectSpartDefinition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{spartdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectSpartDefinition4UpdateSqlDatabase : _sqlSelectSpartDefinition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SPARTDEFINITIONID", spartdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_SPARTDEFINITION", $"{spartdefinitionid},{siteid}"));
		}
		Spartdefinition? result = ContextManager.DirectEntityQuery<Spartdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{spartdefinitionid},{siteid}");
		}
		return result;
	}

	public static int UpsertSpartDefinition(IDbContext dbContext, RequestType requestType, Spartdefinition[] spartDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateSpartDefinitionInternal(dbContext, spartDefinitionList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateSpartDefinition(dbContext, spartDefinitionList, optionSet, saveHist), 
			RequestType.DELETE => DeleteSpartDefinition(dbContext, spartDefinitionList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteSpartDefinition(dbContext, spartDefinitionList, optionSet, saveHist), 
			_ => RealDeleteSpartDefinition(dbContext, spartDefinitionList, optionSet, saveHist), 
		};
	}

	private static int CreateSpartDefinitionInternal(IDbContext dbContext, Spartdefinition[] spartDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spartDefinitionList", spartDefinitionList);
		string text = "CreateSpartDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spartdefinition> list = new List<Spartdefinition>();
		foreach (Spartdefinition obj in spartDefinitionList)
		{
			Spartdefinition spartdefinition = new Spartdefinition();
			obj.CopyColumsTo(spartdefinition);
			spartdefinition.Activity = text;
			spartdefinition.CheckEntityUsable();
			obj.CopyCommonField(spartdefinition, systemTime, dbContext.Tid, isCreate: true);
			list.Add(spartdefinition);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateSpartDefinition(IDbContext dbContext, Spartdefinition[] spartDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spartDefinitionList", spartDefinitionList);
		string text = "UpdateSpartDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spartdefinition> list = new List<Spartdefinition>();
		foreach (Spartdefinition spartdefinition in spartDefinitionList)
		{
			Spartdefinition spartDefinition4Update = GetSpartDefinition4Update(dbContext, spartdefinition.Spartdefinitionid, spartdefinition.Siteid);
			if (spartDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Spartdefinition), $"{spartdefinition.Spartdefinitionid},{spartdefinition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Spartdefinition), $"{spartdefinition.Spartdefinitionid},{spartdefinition.Siteid}", spartDefinition4Update.Isusable);
			string activity = spartDefinition4Update.Activity;
			string customactivity = spartDefinition4Update.Customactivity;
			string isusable = spartDefinition4Update.Isusable;
			DateTime? createtime = spartDefinition4Update.Createtime;
			string creator = spartDefinition4Update.Creator;
			spartdefinition.CopyColumsTo(spartDefinition4Update);
			spartDefinition4Update.Prevactivity = activity;
			spartDefinition4Update.Prevcustomactivity = customactivity;
			spartDefinition4Update.Creator = creator;
			spartDefinition4Update.Createtime = createtime;
			spartDefinition4Update.Isusable = isusable;
			spartDefinition4Update.Activity = text;
			spartdefinition.CopyCommonField(spartDefinition4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(spartDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteSpartDefinition(IDbContext dbContext, Spartdefinition[] spartDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spartDefinitionList", spartDefinitionList);
		string text = "DeleteSpartDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spartdefinition> list = new List<Spartdefinition>();
		foreach (Spartdefinition spartdefinition in spartDefinitionList)
		{
			Spartdefinition spartDefinition4Update = GetSpartDefinition4Update(dbContext, spartdefinition.Spartdefinitionid, spartdefinition.Siteid);
			if (spartDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Spartdefinition), $"{spartdefinition.Spartdefinitionid},{spartdefinition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Spartdefinition), $"{spartdefinition.Spartdefinitionid},{spartdefinition.Siteid}", spartDefinition4Update.Isusable);
			spartDefinition4Update.Isusable = "UnUsable";
			spartdefinition.CopyCommonFieldUpdatePrev(spartDefinition4Update, systemTime, dbContext.Tid, text);
			spartdefinition.CopyExtensionCollection(spartDefinition4Update);
			list.Add(spartDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteSpartDefinition(IDbContext dbContext, Spartdefinition[] spartDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spartDefinitionList", spartDefinitionList);
		string text = "UnDeleteSpartDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spartdefinition> list = new List<Spartdefinition>();
		foreach (Spartdefinition spartdefinition in spartDefinitionList)
		{
			Spartdefinition spartDefinition4Update = GetSpartDefinition4Update(dbContext, spartdefinition.Spartdefinitionid, spartdefinition.Siteid);
			if (spartDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Spartdefinition), $"{spartdefinition.Spartdefinitionid},{spartdefinition.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Spartdefinition), $"{spartdefinition.Spartdefinitionid},{spartdefinition.Siteid}", spartDefinition4Update.Isusable);
			spartDefinition4Update.Isusable = "Usable";
			spartdefinition.CopyCommonFieldUpdatePrev(spartDefinition4Update, systemTime, dbContext.Tid, text);
			spartdefinition.CopyExtensionCollection(spartDefinition4Update);
			list.Add(spartDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteSpartDefinition(IDbContext dbContext, Spartdefinition[] spartDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spartDefinitionList", spartDefinitionList);
		string text = "RealDeleteSpartDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spartdefinition> list = new List<Spartdefinition>();
		foreach (Spartdefinition spartdefinition in spartDefinitionList)
		{
			Spartdefinition spartDefinition4Update = GetSpartDefinition4Update(dbContext, spartdefinition.Spartdefinitionid, spartdefinition.Siteid);
			if (spartDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Spartdefinition), $"{spartdefinition.Spartdefinitionid},{spartdefinition.Siteid}");
			}
			spartdefinition.CopyCommonFieldUpdatePrev(spartDefinition4Update, systemTime, dbContext.Tid, text);
			spartdefinition.CopyExtensionCollection(spartDefinition4Update);
			list.Add(spartDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
