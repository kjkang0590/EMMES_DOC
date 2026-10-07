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
public class DURABLEDEFINITION
{
	private static string _sqlGetDurableDefinitionSqlDatabase = "SELECT * FROM CIM_DURABLEDEFINITION WHERE DURABLEDEFINITIONID=@DURABLEDEFINITIONID AND SITEID=@SITEID";

	private static string _sqlGetDurableDefinition4UpdateSqlDatabase = "SELECT * FROM CIM_DURABLEDEFINITION WITH(UPDLOCK) WHERE DURABLEDEFINITIONID=@DURABLEDEFINITIONID AND SITEID=@SITEID";

	private static string _sqlSelectDurableDefinitionSqlDatabase = "SELECT * FROM CIM_DURABLEDEFINITION WHERE DURABLEDEFINITIONID=@DURABLEDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectDurableDefinition4UpdateSqlDatabase = "SELECT * FROM CIM_DURABLEDEFINITION WITH(UPDLOCK) WHERE DURABLEDEFINITIONID=@DURABLEDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetDurableDefinitionOracleDatabase = "SELECT * FROM CIM_DURABLEDEFINITION WHERE DURABLEDEFINITIONID=:DURABLEDEFINITIONID AND SITEID=:SITEID";

	private static string _sqlGetDurableDefinition4UpdateOracleDatabase = "SELECT * FROM CIM_DURABLEDEFINITION WHERE DURABLEDEFINITIONID=:DURABLEDEFINITIONID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectDurableDefinitionOracleDatabase = "SELECT * FROM CIM_DURABLEDEFINITION WHERE DURABLEDEFINITIONID=:DURABLEDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectDurableDefinition4UpdateOracleDatabase = "SELECT * FROM CIM_DURABLEDEFINITION WHERE DURABLEDEFINITIONID=:DURABLEDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Durabledefinition);

	public static Durabledefinition GetDurableDefinition(IDbContext dbContext, string durabledefinitionid, string siteid)
	{
		string apiName = "GetDurableDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{durabledefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetDurableDefinitionSqlDatabase : _sqlGetDurableDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DURABLEDEFINITIONID", durabledefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_DURABLEDEFINITION", $"{durabledefinitionid},{siteid}"));
		}
		Durabledefinition? result = ContextManager.DirectEntityQuery<Durabledefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{durabledefinitionid},{siteid}");
		}
		return result;
	}

	public static Durabledefinition GetDurableDefinition4Update(IDbContext dbContext, string durabledefinitionid, string siteid)
	{
		string apiName = "GetDurableDefinition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{durabledefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetDurableDefinition4UpdateSqlDatabase : _sqlGetDurableDefinition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DURABLEDEFINITIONID", durabledefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_DURABLEDEFINITION", $"{durabledefinitionid},{siteid}"));
		}
		Durabledefinition? result = ContextManager.DirectEntityQuery<Durabledefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{durabledefinitionid},{siteid}");
		}
		return result;
	}

	public static Durabledefinition SelectDurableDefinition(IDbContext dbContext, string durabledefinitionid, string siteid)
	{
		string apiName = "SelectDurableDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{durabledefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectDurableDefinitionSqlDatabase : _sqlSelectDurableDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DURABLEDEFINITIONID", durabledefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_DURABLEDEFINITION", $"{durabledefinitionid},{siteid}"));
		}
		Durabledefinition? result = ContextManager.DirectEntityQuery<Durabledefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{durabledefinitionid},{siteid}");
		}
		return result;
	}

	public static Durabledefinition SelectDurableDefinition4Update(IDbContext dbContext, string durabledefinitionid, string siteid)
	{
		string apiName = "SelectDurableDefinition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{durabledefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectDurableDefinition4UpdateSqlDatabase : _sqlSelectDurableDefinition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DURABLEDEFINITIONID", durabledefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_DURABLEDEFINITION", $"{durabledefinitionid},{siteid}"));
		}
		Durabledefinition? result = ContextManager.DirectEntityQuery<Durabledefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{durabledefinitionid},{siteid}");
		}
		return result;
	}

	public static int UpsertDurableDefinition(IDbContext dbContext, RequestType requestType, Durabledefinition[] durableDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateDurableDefinitionInternal(dbContext, durableDefinitionList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateDurableDefinition(dbContext, durableDefinitionList, optionSet, saveHist), 
			RequestType.DELETE => DeleteDurableDefinition(dbContext, durableDefinitionList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteDurableDefinition(dbContext, durableDefinitionList, optionSet, saveHist), 
			_ => RealDeleteDurableDefinition(dbContext, durableDefinitionList, optionSet, saveHist), 
		};
	}

	private static int CreateDurableDefinitionInternal(IDbContext dbContext, Durabledefinition[] durableDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("durableDefinitionList", durableDefinitionList);
		string text = "CreateDurableDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Durabledefinition> list = new List<Durabledefinition>();
		foreach (Durabledefinition obj in durableDefinitionList)
		{
			Durabledefinition durabledefinition = new Durabledefinition();
			obj.CopyColumsTo(durabledefinition);
			durabledefinition.Activity = text;
			durabledefinition.CheckEntityUsable();
			obj.CopyCommonField(durabledefinition, systemTime, dbContext.Tid, isCreate: true);
			list.Add(durabledefinition);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateDurableDefinition(IDbContext dbContext, Durabledefinition[] durableDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("durableDefinitionList", durableDefinitionList);
		string text = "UpdateDurableDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Durabledefinition> list = new List<Durabledefinition>();
		foreach (Durabledefinition durabledefinition in durableDefinitionList)
		{
			Durabledefinition durableDefinition4Update = GetDurableDefinition4Update(dbContext, durabledefinition.Durabledefinitionid, durabledefinition.Siteid);
			if (durableDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Durabledefinition), $"{durabledefinition.Durabledefinitionid},{durabledefinition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Durabledefinition), $"{durabledefinition.Durabledefinitionid},{durabledefinition.Siteid}", durableDefinition4Update.Isusable);
			string activity = durableDefinition4Update.Activity;
			string customactivity = durableDefinition4Update.Customactivity;
			string isusable = durableDefinition4Update.Isusable;
			DateTime? createtime = durableDefinition4Update.Createtime;
			string creator = durableDefinition4Update.Creator;
			durabledefinition.CopyColumsTo(durableDefinition4Update);
			durableDefinition4Update.Prevactivity = activity;
			durableDefinition4Update.Prevcustomactivity = customactivity;
			durableDefinition4Update.Creator = creator;
			durableDefinition4Update.Createtime = createtime;
			durableDefinition4Update.Isusable = isusable;
			durableDefinition4Update.Activity = text;
			durabledefinition.CopyCommonField(durableDefinition4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(durableDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteDurableDefinition(IDbContext dbContext, Durabledefinition[] durableDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("durableDefinitionList", durableDefinitionList);
		string text = "DeleteDurableDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Durabledefinition> list = new List<Durabledefinition>();
		foreach (Durabledefinition durabledefinition in durableDefinitionList)
		{
			Durabledefinition durableDefinition4Update = GetDurableDefinition4Update(dbContext, durabledefinition.Durabledefinitionid, durabledefinition.Siteid);
			if (durableDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Durabledefinition), $"{durabledefinition.Durabledefinitionid},{durabledefinition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Durabledefinition), $"{durabledefinition.Durabledefinitionid},{durabledefinition.Siteid}", durableDefinition4Update.Isusable);
			durableDefinition4Update.Isusable = "UnUsable";
			durabledefinition.CopyCommonFieldUpdatePrev(durableDefinition4Update, systemTime, dbContext.Tid, text);
			durabledefinition.CopyExtensionCollection(durableDefinition4Update);
			list.Add(durableDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteDurableDefinition(IDbContext dbContext, Durabledefinition[] durableDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("durableDefinitionList", durableDefinitionList);
		string text = "UnDeleteDurableDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Durabledefinition> list = new List<Durabledefinition>();
		foreach (Durabledefinition durabledefinition in durableDefinitionList)
		{
			Durabledefinition durableDefinition4Update = GetDurableDefinition4Update(dbContext, durabledefinition.Durabledefinitionid, durabledefinition.Siteid);
			if (durableDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Durabledefinition), $"{durabledefinition.Durabledefinitionid},{durabledefinition.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Durabledefinition), $"{durabledefinition.Durabledefinitionid},{durabledefinition.Siteid}", durableDefinition4Update.Isusable);
			durableDefinition4Update.Isusable = "Usable";
			durabledefinition.CopyCommonFieldUpdatePrev(durableDefinition4Update, systemTime, dbContext.Tid, text);
			durabledefinition.CopyExtensionCollection(durableDefinition4Update);
			list.Add(durableDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteDurableDefinition(IDbContext dbContext, Durabledefinition[] durableDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("durableDefinitionList", durableDefinitionList);
		string text = "RealDeleteDurableDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Durabledefinition> list = new List<Durabledefinition>();
		foreach (Durabledefinition durabledefinition in durableDefinitionList)
		{
			Durabledefinition durableDefinition4Update = GetDurableDefinition4Update(dbContext, durabledefinition.Durabledefinitionid, durabledefinition.Siteid);
			if (durableDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Durabledefinition), $"{durabledefinition.Durabledefinitionid},{durabledefinition.Siteid}");
			}
			durabledefinition.CopyCommonFieldUpdatePrev(durableDefinition4Update, systemTime, dbContext.Tid, text);
			durabledefinition.CopyExtensionCollection(durableDefinition4Update);
			list.Add(durableDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
