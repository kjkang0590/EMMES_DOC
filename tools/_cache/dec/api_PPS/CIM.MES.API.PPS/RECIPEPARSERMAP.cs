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
public class RECIPEPARSERMAP
{
	private static string _sqlGetRecipeParserMapSqlDatabase = "SELECT * FROM CIM_RECIPEPARSERMAP WHERE PARSERID=@PARSERID AND SITEID=@SITEID";

	private static string _sqlGetRecipeParserMap4UpdateSqlDatabase = "SELECT * FROM CIM_RECIPEPARSERMAP WITH(UPDLOCK) WHERE PARSERID=@PARSERID AND SITEID=@SITEID";

	private static string _sqlSelectRecipeParserMapSqlDatabase = "SELECT * FROM CIM_RECIPEPARSERMAP WHERE PARSERID=@PARSERID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectRecipeParserMap4UpdateSqlDatabase = "SELECT * FROM CIM_RECIPEPARSERMAP WITH(UPDLOCK) WHERE PARSERID=@PARSERID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetRecipeParserMapOracleDatabase = "SELECT * FROM CIM_RECIPEPARSERMAP WHERE PARSERID=:PARSERID AND SITEID=:SITEID";

	private static string _sqlGetRecipeParserMap4UpdateOracleDatabase = "SELECT * FROM CIM_RECIPEPARSERMAP WHERE PARSERID=:PARSERID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectRecipeParserMapOracleDatabase = "SELECT * FROM CIM_RECIPEPARSERMAP WHERE PARSERID=:PARSERID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectRecipeParserMap4UpdateOracleDatabase = "SELECT * FROM CIM_RECIPEPARSERMAP WHERE PARSERID=:PARSERID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static string _sqlSelectRecipeParserMapByRecipeDefinitionIdSqlDatabase = "SELECT * FROM CIM_RECIPEPARSERMAP WHERE RECIPEDEFINITIONID=@RECIPEDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectRecipeParserMapByRecipeDefinitionIdOracleDatabase = "SELECT * FROM CIM_RECIPEPARSERMAP WHERE RECIPEDEFINITIONID=:RECIPEDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static Type typeOfThis = typeof(Recipeparsermap);

	public static Recipeparsermap GetRecipeParserMap(IDbContext dbContext, long parserid, string siteid)
	{
		string apiName = "GetRecipeParserMap";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{parserid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetRecipeParserMapSqlDatabase : _sqlGetRecipeParserMapOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PARSERID", parserid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_RECIPEPARSERMAP", $"{parserid},{siteid}"));
		}
		Recipeparsermap? result = ContextManager.DirectEntityQuery<Recipeparsermap>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{parserid},{siteid}");
		}
		return result;
	}

	public static Recipeparsermap GetRecipeParserMap4Update(IDbContext dbContext, long parserid, string siteid)
	{
		string apiName = "GetRecipeParserMap4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{parserid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetRecipeParserMap4UpdateSqlDatabase : _sqlGetRecipeParserMap4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PARSERID", parserid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_RECIPEPARSERMAP", $"{parserid},{siteid}"));
		}
		Recipeparsermap? result = ContextManager.DirectEntityQuery<Recipeparsermap>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{parserid},{siteid}");
		}
		return result;
	}

	public static Recipeparsermap SelectRecipeParserMap(IDbContext dbContext, long parserid, string siteid)
	{
		string apiName = "SelectRecipeParserMap";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{parserid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectRecipeParserMapSqlDatabase : _sqlSelectRecipeParserMapOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PARSERID", parserid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_RECIPEPARSERMAP", $"{parserid},{siteid}"));
		}
		Recipeparsermap? result = ContextManager.DirectEntityQuery<Recipeparsermap>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{parserid},{siteid}");
		}
		return result;
	}

	public static Recipeparsermap SelectRecipeParserMap4Update(IDbContext dbContext, long parserid, string siteid)
	{
		string apiName = "SelectRecipeParserMap4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{parserid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectRecipeParserMap4UpdateSqlDatabase : _sqlSelectRecipeParserMap4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PARSERID", parserid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_RECIPEPARSERMAP", $"{parserid},{siteid}"));
		}
		Recipeparsermap? result = ContextManager.DirectEntityQuery<Recipeparsermap>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{parserid},{siteid}");
		}
		return result;
	}

	public static Recipeparsermap SelectRecipeParserMapByRecipeDefinitionId(IDbContext dbContext, string recipedefinitionid, string siteid)
	{
		string apiName = "SelectRecipeParserMapByRecipeDefinitionId";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{recipedefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectRecipeParserMapByRecipeDefinitionIdSqlDatabase : _sqlSelectRecipeParserMapByRecipeDefinitionIdOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RECIPEDEFINITIONID", recipedefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_RECIPEPARSERMAP", $"{recipedefinitionid},{siteid}"));
		}
		Recipeparsermap? result = ContextManager.DirectEntityQuery<Recipeparsermap>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{recipedefinitionid},{siteid}");
		}
		return result;
	}

	public static int UpsertRecipeParserMap(IDbContext dbContext, RequestType requestType, Recipeparsermap[] recipeParserMapList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateRecipeParserMapInternal(dbContext, recipeParserMapList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateRecipeParserMap(dbContext, recipeParserMapList, optionSet, saveHist), 
			RequestType.DELETE => DeleteRecipeParserMap(dbContext, recipeParserMapList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteRecipeParserMap(dbContext, recipeParserMapList, optionSet, saveHist), 
			_ => RealDeleteRecipeParserMap(dbContext, recipeParserMapList, optionSet, saveHist), 
		};
	}

	private static int CreateRecipeParserMapInternal(IDbContext dbContext, Recipeparsermap[] recipeParserMapList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("recipeParserMapList", recipeParserMapList);
		string text = "CreateRecipeParserMap";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Recipeparsermap> list = new List<Recipeparsermap>();
		foreach (Recipeparsermap obj in recipeParserMapList)
		{
			Recipeparsermap recipeparsermap = new Recipeparsermap();
			obj.CopyColumsTo(recipeparsermap);
			recipeparsermap.Activity = text;
			recipeparsermap.CheckEntityUsable();
			obj.CopyCommonField(recipeparsermap, systemTime, dbContext.Tid, isCreate: true);
			list.Add(recipeparsermap);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateRecipeParserMap(IDbContext dbContext, Recipeparsermap[] recipeParserMapList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("recipeParserMapList", recipeParserMapList);
		string text = "UpdateRecipeParserMap";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Recipeparsermap> list = new List<Recipeparsermap>();
		foreach (Recipeparsermap recipeparsermap in recipeParserMapList)
		{
			Recipeparsermap recipeParserMap4Update = GetRecipeParserMap4Update(dbContext, recipeparsermap.Parserid, recipeparsermap.Siteid);
			if (recipeParserMap4Update == null)
			{
				throw new EntityNotFoundException(typeof(Recipeparsermap), $"{recipeparsermap.Parserid},{recipeparsermap.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Recipeparsermap), $"{recipeparsermap.Parserid},{recipeparsermap.Siteid}", recipeParserMap4Update.Isusable);
			string activity = recipeParserMap4Update.Activity;
			string customactivity = recipeParserMap4Update.Customactivity;
			string isusable = recipeParserMap4Update.Isusable;
			DateTime? createtime = recipeParserMap4Update.Createtime;
			string creator = recipeParserMap4Update.Creator;
			recipeparsermap.CopyColumsTo(recipeParserMap4Update);
			recipeParserMap4Update.Prevactivity = activity;
			recipeParserMap4Update.Prevcustomactivity = customactivity;
			recipeParserMap4Update.Creator = creator;
			recipeParserMap4Update.Createtime = createtime;
			recipeParserMap4Update.Isusable = isusable;
			recipeParserMap4Update.Activity = text;
			recipeparsermap.CopyCommonField(recipeParserMap4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(recipeParserMap4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteRecipeParserMap(IDbContext dbContext, Recipeparsermap[] recipeParserMapList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("recipeParserMapList", recipeParserMapList);
		string text = "DeleteRecipeParserMap";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Recipeparsermap> list = new List<Recipeparsermap>();
		foreach (Recipeparsermap recipeparsermap in recipeParserMapList)
		{
			Recipeparsermap recipeParserMap4Update = GetRecipeParserMap4Update(dbContext, recipeparsermap.Parserid, recipeparsermap.Siteid);
			if (recipeParserMap4Update == null)
			{
				throw new EntityNotFoundException(typeof(Recipeparsermap), $"{recipeparsermap.Parserid},{recipeparsermap.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Recipeparsermap), $"{recipeparsermap.Parserid},{recipeparsermap.Siteid}", recipeParserMap4Update.Isusable);
			recipeParserMap4Update.Isusable = "UnUsable";
			recipeparsermap.CopyCommonFieldUpdatePrev(recipeParserMap4Update, systemTime, dbContext.Tid, text);
			recipeparsermap.CopyExtensionCollection(recipeParserMap4Update);
			list.Add(recipeParserMap4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteRecipeParserMap(IDbContext dbContext, Recipeparsermap[] recipeParserMapList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("recipeParserMapList", recipeParserMapList);
		string text = "UnDeleteRecipeParserMap";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Recipeparsermap> list = new List<Recipeparsermap>();
		foreach (Recipeparsermap recipeparsermap in recipeParserMapList)
		{
			Recipeparsermap recipeParserMap4Update = GetRecipeParserMap4Update(dbContext, recipeparsermap.Parserid, recipeparsermap.Siteid);
			if (recipeParserMap4Update == null)
			{
				throw new EntityNotFoundException(typeof(Recipeparsermap), $"{recipeparsermap.Parserid},{recipeparsermap.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Recipeparsermap), $"{recipeparsermap.Parserid},{recipeparsermap.Siteid}", recipeParserMap4Update.Isusable);
			recipeParserMap4Update.Isusable = "Usable";
			recipeparsermap.CopyCommonFieldUpdatePrev(recipeParserMap4Update, systemTime, dbContext.Tid, text);
			recipeparsermap.CopyExtensionCollection(recipeParserMap4Update);
			list.Add(recipeParserMap4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteRecipeParserMap(IDbContext dbContext, Recipeparsermap[] recipeParserMapList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("recipeParserMapList", recipeParserMapList);
		string text = "RealDeleteRecipeParserMap";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Recipeparsermap> list = new List<Recipeparsermap>();
		foreach (Recipeparsermap recipeparsermap in recipeParserMapList)
		{
			Recipeparsermap recipeParserMap4Update = GetRecipeParserMap4Update(dbContext, recipeparsermap.Parserid, recipeparsermap.Siteid);
			if (recipeParserMap4Update == null)
			{
				throw new EntityNotFoundException(typeof(Recipeparsermap), $"{recipeparsermap.Parserid},{recipeparsermap.Siteid}");
			}
			recipeparsermap.CopyCommonFieldUpdatePrev(recipeParserMap4Update, systemTime, dbContext.Tid, text);
			recipeparsermap.CopyExtensionCollection(recipeParserMap4Update);
			list.Add(recipeParserMap4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
