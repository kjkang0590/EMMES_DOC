using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.PPS;

[MESAPI]
public class RECIPEDEFINITION
{
	private static string _sqlGetRecipeDefinitionSqlDatabase = "SELECT * FROM CIM_RECIPEDEFINITION WHERE RECIPEDEFINITIONID=@RECIPEDEFINITIONID AND SITEID=@SITEID";

	private static string _sqlGetRecipeDefinition4UpdateSqlDatabase = "SELECT * FROM CIM_RECIPEDEFINITION WITH(UPDLOCK) WHERE RECIPEDEFINITIONID=@RECIPEDEFINITIONID AND SITEID=@SITEID";

	private static string _sqlSelectRecipeDefinitionSqlDatabase = "SELECT * FROM CIM_RECIPEDEFINITION WHERE RECIPEDEFINITIONID=@RECIPEDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectRecipeDefinition4UpdateSqlDatabase = "SELECT * FROM CIM_RECIPEDEFINITION WITH(UPDLOCK) WHERE RECIPEDEFINITIONID=@RECIPEDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetRecipeDefinitionOracleDatabase = "SELECT * FROM CIM_RECIPEDEFINITION WHERE RECIPEDEFINITIONID=:RECIPEDEFINITIONID AND SITEID=:SITEID";

	private static string _sqlGetRecipeDefinition4UpdateOracleDatabase = "SELECT * FROM CIM_RECIPEDEFINITION WHERE RECIPEDEFINITIONID=:RECIPEDEFINITIONID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectRecipeDefinitionOracleDatabase = "SELECT * FROM CIM_RECIPEDEFINITION WHERE RECIPEDEFINITIONID=:RECIPEDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectRecipeDefinition4UpdateOracleDatabase = "SELECT * FROM CIM_RECIPEDEFINITION WHERE RECIPEDEFINITIONID=:RECIPEDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Recipedefinition);

	private static string _sqlGetRecipeDefinitionNameSqlDatabase = "SELECT * FROM CIM_RECIPEDEFINITION WHERE RECIPEDEFINITIONNAME = @RECIPEDEFINITIONNAME AND SITEID=@SITEID";

	private static string _sqlSelectRecipeDefinitionNameSqlDatabase = "SELECT * FROM CIM_RECIPEDEFINITION WHERE RECIPEDEFINITIONNAME = @RECIPEDEFINITIONNAME AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetRecipeDefinitionNameOracleDatabase = "SELECT * FROM CIM_RECIPEDEFINITION WHERE RECIPEDEFINITIONNAME = :RECIPEDEFINITIONNAME AND SITEID=:SITEID";

	private static string _sqlSelectRecipeDefinitionNameOracleDatabase = "SELECT * FROM CIM_RECIPEDEFINITION WHERE RECIPEDEFINITIONNAME = :RECIPEDEFINITIONNAME AND SITEID=:SITEID AND ISUSABLE='Usable'";

	public static Recipedefinition GetRecipeDefinition(IDbContext dbContext, string recipedefinitionid, string siteid)
	{
		string apiName = "GetRecipeDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{recipedefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetRecipeDefinitionSqlDatabase : _sqlGetRecipeDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RECIPEDEFINITIONID", recipedefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_RECIPEDEFINITION", $"{recipedefinitionid},{siteid}"));
		}
		Recipedefinition? result = ContextManager.DirectEntityQuery<Recipedefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{recipedefinitionid},{siteid}");
		}
		return result;
	}

	public static Recipedefinition GetRecipeDefinition4Update(IDbContext dbContext, string recipedefinitionid, string siteid)
	{
		string apiName = "GetRecipeDefinition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{recipedefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetRecipeDefinition4UpdateSqlDatabase : _sqlGetRecipeDefinition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RECIPEDEFINITIONID", recipedefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_RECIPEDEFINITION", $"{recipedefinitionid},{siteid}"));
		}
		Recipedefinition? result = ContextManager.DirectEntityQuery<Recipedefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{recipedefinitionid},{siteid}");
		}
		return result;
	}

	public static Recipedefinition SelectRecipeDefinition(IDbContext dbContext, string recipedefinitionid, string siteid)
	{
		string apiName = "SelectRecipeDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{recipedefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectRecipeDefinitionSqlDatabase : _sqlSelectRecipeDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RECIPEDEFINITIONID", recipedefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_RECIPEDEFINITION", $"{recipedefinitionid},{siteid}"));
		}
		Recipedefinition? result = ContextManager.DirectEntityQuery<Recipedefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{recipedefinitionid},{siteid}");
		}
		return result;
	}

	public static Recipedefinition SelectRecipeDefinition4Update(IDbContext dbContext, string recipedefinitionid, string siteid)
	{
		string apiName = "SelectRecipeDefinition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{recipedefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectRecipeDefinition4UpdateSqlDatabase : _sqlSelectRecipeDefinition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RECIPEDEFINITIONID", recipedefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_RECIPEDEFINITION", $"{recipedefinitionid},{siteid}"));
		}
		Recipedefinition? result = ContextManager.DirectEntityQuery<Recipedefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{recipedefinitionid},{siteid}");
		}
		return result;
	}

	public static IList<Recipedefinition> GetRecipeDefinitionNameList(IDbContext dbContext, string recipeDefinitionName, string siteid)
	{
		string apiName = "GetRecipeDefinitionNameList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{recipeDefinitionName},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetRecipeDefinitionNameSqlDatabase : _sqlGetRecipeDefinitionNameOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RECIPEDEFINITIONNAME", recipeDefinitionName, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_RECIPEDEFINITION", $"{recipeDefinitionName},{siteid}"));
		}
		IList<Recipedefinition> result = ContextManager.DirectEntityQuery<Recipedefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{recipeDefinitionName},{siteid}");
		}
		return result;
	}

	public static IList<Recipedefinition> SelectRecipeDefinitionNameList(IDbContext dbContext, string recipeDefinitionName, string siteid)
	{
		string apiName = "SelectRecipeDefinitionNameList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{recipeDefinitionName},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectRecipeDefinitionNameSqlDatabase : _sqlSelectRecipeDefinitionNameOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RECIPEDEFINITIONNAME", recipeDefinitionName, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_RECIPEDEFINITION", $"{recipeDefinitionName},{siteid}"));
		}
		IList<Recipedefinition> result = ContextManager.DirectEntityQuery<Recipedefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{recipeDefinitionName},{siteid}");
		}
		return result;
	}

	public static int UpsertRecipeDefinition(IDbContext dbContext, RequestType requestType, Recipedefinition[] recipeDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateRecipeDefinitionInternal(dbContext, recipeDefinitionList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateRecipeDefinition(dbContext, recipeDefinitionList, optionSet, saveHist), 
			RequestType.DELETE => DeleteRecipeDefinition(dbContext, recipeDefinitionList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteRecipeDefinition(dbContext, recipeDefinitionList, optionSet, saveHist), 
			_ => RealDeleteRecipeDefinition(dbContext, recipeDefinitionList, optionSet, saveHist), 
		};
	}

	private static int CreateRecipeDefinitionInternal(IDbContext dbContext, Recipedefinition[] recipeDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("recipeDefinitionList", recipeDefinitionList);
		string text = "CreateRecipeDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Recipedefinition> list = new List<Recipedefinition>();
		foreach (Recipedefinition obj in recipeDefinitionList)
		{
			Recipedefinition recipedefinition = new Recipedefinition();
			obj.CopyColumsTo(recipedefinition);
			recipedefinition.Activity = text;
			recipedefinition.CheckEntityUsable();
			obj.CopyCommonField(recipedefinition, systemTime, dbContext.Tid, isCreate: true);
			list.Add(recipedefinition);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateRecipeDefinition(IDbContext dbContext, Recipedefinition[] recipeDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("recipeDefinitionList", recipeDefinitionList);
		string text = "UpdateRecipeDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Recipedefinition> list = new List<Recipedefinition>();
		foreach (Recipedefinition recipedefinition in recipeDefinitionList)
		{
			Recipedefinition recipeDefinition4Update = GetRecipeDefinition4Update(dbContext, recipedefinition.Recipedefinitionid, recipedefinition.Siteid);
			if (recipeDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Recipedefinition), $"{recipedefinition.Recipedefinitionid},{recipedefinition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Recipedefinition), $"{recipedefinition.Recipedefinitionid},{recipedefinition.Siteid}", recipeDefinition4Update.Isusable);
			string activity = recipeDefinition4Update.Activity;
			string customactivity = recipeDefinition4Update.Customactivity;
			string isusable = recipeDefinition4Update.Isusable;
			DateTime? createtime = recipeDefinition4Update.Createtime;
			string creator = recipeDefinition4Update.Creator;
			recipedefinition.CopyColumsTo(recipeDefinition4Update);
			recipeDefinition4Update.Prevactivity = activity;
			recipeDefinition4Update.Prevcustomactivity = customactivity;
			recipeDefinition4Update.Creator = creator;
			recipeDefinition4Update.Createtime = createtime;
			recipeDefinition4Update.Isusable = isusable;
			recipeDefinition4Update.Activity = text;
			recipedefinition.CopyCommonField(recipeDefinition4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(recipeDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteRecipeDefinition(IDbContext dbContext, Recipedefinition[] recipeDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("recipeDefinitionList", recipeDefinitionList);
		string text = "DeleteRecipeDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Recipedefinition> list = new List<Recipedefinition>();
		foreach (Recipedefinition recipedefinition in recipeDefinitionList)
		{
			Recipedefinition recipeDefinition4Update = GetRecipeDefinition4Update(dbContext, recipedefinition.Recipedefinitionid, recipedefinition.Siteid);
			if (recipeDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Recipedefinition), $"{recipedefinition.Recipedefinitionid},{recipedefinition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Recipedefinition), $"{recipedefinition.Recipedefinitionid},{recipedefinition.Siteid}", recipeDefinition4Update.Isusable);
			recipeDefinition4Update.Isusable = "UnUsable";
			recipedefinition.CopyCommonFieldUpdatePrev(recipeDefinition4Update, systemTime, dbContext.Tid, text);
			recipedefinition.CopyExtensionCollection(recipeDefinition4Update);
			list.Add(recipeDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteRecipeDefinition(IDbContext dbContext, Recipedefinition[] recipeDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("recipeDefinitionList", recipeDefinitionList);
		string text = "UnDeleteRecipeDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Recipedefinition> list = new List<Recipedefinition>();
		foreach (Recipedefinition recipedefinition in recipeDefinitionList)
		{
			Recipedefinition recipeDefinition4Update = GetRecipeDefinition4Update(dbContext, recipedefinition.Recipedefinitionid, recipedefinition.Siteid);
			if (recipeDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Recipedefinition), $"{recipedefinition.Recipedefinitionid},{recipedefinition.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Recipedefinition), $"{recipedefinition.Recipedefinitionid},{recipedefinition.Siteid}", recipeDefinition4Update.Isusable);
			recipeDefinition4Update.Isusable = "Usable";
			recipedefinition.CopyCommonFieldUpdatePrev(recipeDefinition4Update, systemTime, dbContext.Tid, text);
			recipedefinition.CopyExtensionCollection(recipeDefinition4Update);
			list.Add(recipeDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteRecipeDefinition(IDbContext dbContext, Recipedefinition[] recipeDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("recipeDefinitionList", recipeDefinitionList);
		string text = "RealDeleteRecipeDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Recipedefinition> list = new List<Recipedefinition>();
		foreach (Recipedefinition recipedefinition in recipeDefinitionList)
		{
			Recipedefinition recipeDefinition4Update = GetRecipeDefinition4Update(dbContext, recipedefinition.Recipedefinitionid, recipedefinition.Siteid);
			if (recipeDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Recipedefinition), $"{recipedefinition.Recipedefinitionid},{recipedefinition.Siteid}");
			}
			recipedefinition.CopyCommonFieldUpdatePrev(recipeDefinition4Update, systemTime, dbContext.Tid, text);
			recipedefinition.CopyExtensionCollection(recipeDefinition4Update);
			list.Add(recipeDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
