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
public class RECIPEPARAMETER
{
	private static string _sqlGetRecipeParameterSqlDatabase = "SELECT * FROM CIM_RECIPEPARAMETER WHERE RECIPEPARAMETERID=@RECIPEPARAMETERID AND RECIPEDEFINITIONID=@RECIPEDEFINITIONID AND SITEID=@SITEID";

	private static string _sqlGetRecipeParameter4UpdateSqlDatabase = "SELECT * FROM CIM_RECIPEPARAMETER WITH(UPDLOCK) WHERE RECIPEPARAMETERID=@RECIPEPARAMETERID AND RECIPEDEFINITIONID=@RECIPEDEFINITIONID AND SITEID=@SITEID";

	private static string _sqlSelectRecipeParameterSqlDatabase = "SELECT * FROM CIM_RECIPEPARAMETER WHERE RECIPEPARAMETERID=@RECIPEPARAMETERID AND RECIPEDEFINITIONID=@RECIPEDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectRecipeParameter4UpdateSqlDatabase = "SELECT * FROM CIM_RECIPEPARAMETER WITH(UPDLOCK) WHERE RECIPEPARAMETERID=@RECIPEPARAMETERID AND RECIPEDEFINITIONID=@RECIPEDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetRecipeParameterOracleDatabase = "SELECT * FROM CIM_RECIPEPARAMETER WHERE RECIPEPARAMETERID=:RECIPEPARAMETERID AND RECIPEDEFINITIONID=:RECIPEDEFINITIONID AND SITEID=:SITEID";

	private static string _sqlGetRecipeParameter4UpdateOracleDatabase = "SELECT * FROM CIM_RECIPEPARAMETER WHERE RECIPEPARAMETERID=:RECIPEPARAMETERID AND RECIPEDEFINITIONID=:RECIPEDEFINITIONID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectRecipeParameterOracleDatabase = "SELECT * FROM CIM_RECIPEPARAMETER WHERE RECIPEPARAMETERID=:RECIPEPARAMETERID AND RECIPEDEFINITIONID=:RECIPEDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectRecipeParameter4UpdateOracleDatabase = "SELECT * FROM CIM_RECIPEPARAMETER WHERE RECIPEPARAMETERID=:RECIPEPARAMETERID AND RECIPEDEFINITIONID=:RECIPEDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static string _sqlGetRecipeParameterByRecipeDefinitionIdSqlDatabase = "SELECT * FROM CIM_RECIPEPARAMETER WHERE RECIPEDEFINITIONID=@RECIPEDEFINITIONID AND SITEID=@SITEID";

	private static string _sqlSelectRecipeParameterByRecipeDefinitionIdSqlDatabase = "SELECT * FROM CIM_RECIPEPARAMETER WHERE RECIPEDEFINITIONID=@RECIPEDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlRecipeParameterByRecipeDefinitionIdOracleDatabase = "SELECT * FROM CIM_RECIPEPARAMETER WHERE RECIPEDEFINITIONID=:RECIPEDEFINITIONID AND SITEID=:SITEID";

	private static string _sqlSelectRecipeParameterByRecipeDefinitionIdOracleDatabase = "SELECT * FROM CIM_RECIPEPARAMETER WHERE RECIPEDEFINITIONID=:RECIPEDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetRecipeParameterListSqlDatabase = "SELECT * FROM CIM_RECIPEPARAMETER WHERE RECIPECLASSID=@RECIPECLASSID AND RECIPEDEFINITIONID=@RECIPEDEFINITIONID AND SITEID=@SITEID";

	private static string _sqlGetRecipeParameterListOracleDatabase = "SELECT * FROM CIM_RECIPEPARAMETER WHERE RECIPECLASSID=:RECIPECLASSID AND RECIPEDEFINITIONID=:RECIPEDEFINITIONID  AND SITEID=:SITEID";

	private static Type typeOfThis = typeof(Recipeparameter);

	public static Recipeparameter GetRecipeParameter(IDbContext dbContext, string recipeparameterid, string recipedefinitionid, string siteid)
	{
		string apiName = "GetRecipeParameter";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{recipeparameterid},{recipedefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetRecipeParameterSqlDatabase : _sqlGetRecipeParameterOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RECIPEPARAMETERID", recipeparameterid, typeOfThis));
		list.Add(dbContext.CreateParameter("RECIPEDEFINITIONID", recipedefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_RECIPEPARAMETER", $"{recipeparameterid},{recipedefinitionid},{siteid}"));
		}
		Recipeparameter? result = ContextManager.DirectEntityQuery<Recipeparameter>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{recipeparameterid},{recipedefinitionid},{siteid}");
		}
		return result;
	}

	public static Recipeparameter GetRecipeParameter4Update(IDbContext dbContext, string recipeparameterid, string recipedefinitionid, string siteid)
	{
		string apiName = "GetRecipeParameter4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{recipeparameterid},{recipedefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetRecipeParameter4UpdateSqlDatabase : _sqlGetRecipeParameter4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RECIPEPARAMETERID", recipeparameterid, typeOfThis));
		list.Add(dbContext.CreateParameter("RECIPEDEFINITIONID", recipedefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_RECIPEPARAMETER", $"{recipeparameterid},{recipedefinitionid},{siteid}"));
		}
		Recipeparameter? result = ContextManager.DirectEntityQuery<Recipeparameter>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{recipeparameterid},{recipedefinitionid},{siteid}");
		}
		return result;
	}

	public static Recipeparameter SelectRecipeParameter(IDbContext dbContext, string recipeparameterid, string recipedefinitionid, string siteid)
	{
		string apiName = "SelectRecipeParameter";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{recipeparameterid},{recipedefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectRecipeParameterSqlDatabase : _sqlSelectRecipeParameterOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RECIPEPARAMETERID", recipeparameterid, typeOfThis));
		list.Add(dbContext.CreateParameter("RECIPEDEFINITIONID", recipedefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_RECIPEPARAMETER", $"{recipeparameterid},{recipedefinitionid},{siteid}"));
		}
		Recipeparameter? result = ContextManager.DirectEntityQuery<Recipeparameter>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{recipeparameterid},{recipedefinitionid},{siteid}");
		}
		return result;
	}

	public static Recipeparameter SelectRecipeParameter4Update(IDbContext dbContext, string recipeparameterid, string recipedefinitionid, string siteid)
	{
		string apiName = "SelectRecipeParameter4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{recipeparameterid},{recipedefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectRecipeParameter4UpdateSqlDatabase : _sqlSelectRecipeParameter4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RECIPEPARAMETERID", recipeparameterid, typeOfThis));
		list.Add(dbContext.CreateParameter("RECIPEDEFINITIONID", recipedefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_RECIPEPARAMETER", $"{recipeparameterid},{recipedefinitionid},{siteid}"));
		}
		Recipeparameter? result = ContextManager.DirectEntityQuery<Recipeparameter>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{recipeparameterid},{recipedefinitionid},{siteid}");
		}
		return result;
	}

	public static IList<Recipeparameter> GetRecipeParameterByRecipeDefinitionId(IDbContext dbContext, string recipedefinitionid, string siteid)
	{
		string apiName = "GetRecipeParameterByRecipeDefinitionId";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{recipedefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetRecipeParameterByRecipeDefinitionIdSqlDatabase : _sqlRecipeParameterByRecipeDefinitionIdOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RECIPEDEFINITIONID", recipedefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_RECIPEPARAMETER", $"{recipedefinitionid},{siteid}"));
		}
		IList<Recipeparameter> result = ContextManager.DirectEntityQuery<Recipeparameter>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{recipedefinitionid},{siteid}");
		}
		return result;
	}

	public static IList<Recipeparameter> SelectRecipeParameterByRecipeDefinitionId(IDbContext dbContext, string recipedefinitionid, string siteid)
	{
		string apiName = "SelectRecipeParameterByRecipeDefinitionId";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{recipedefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectRecipeParameterByRecipeDefinitionIdSqlDatabase : _sqlSelectRecipeParameterByRecipeDefinitionIdOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RECIPEDEFINITIONID", recipedefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_RECIPEPARAMETER", $"{recipedefinitionid},{siteid}"));
		}
		IList<Recipeparameter> result = ContextManager.DirectEntityQuery<Recipeparameter>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{recipedefinitionid},{siteid}");
		}
		return result;
	}

	public static IList<Recipeparameter> GetRecipeParameterList(IDbContext dbContext, string recipeclassid, string recipedefinitionid, string siteid)
	{
		string apiName = "GetRecipeParameter";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{recipeclassid},{recipedefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetRecipeParameterListSqlDatabase : _sqlGetRecipeParameterListOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RECIPECLASSID", recipeclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("RECIPEDEFINITIONID", recipedefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_RECIPEPARAMETER", $"{recipeclassid},{recipedefinitionid},{siteid}"));
		}
		IList<Recipeparameter> result = ContextManager.DirectEntityQuery<Recipeparameter>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{recipeclassid},{recipedefinitionid},{siteid}");
		}
		return result;
	}

	public static int UpsertRecipeParameter(IDbContext dbContext, RequestType requestType, Recipeparameter[] recipeParameterList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateRecipeParameterInternal(dbContext, recipeParameterList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateRecipeParameter(dbContext, recipeParameterList, optionSet, saveHist), 
			RequestType.DELETE => DeleteRecipeParameter(dbContext, recipeParameterList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteRecipeParameter(dbContext, recipeParameterList, optionSet, saveHist), 
			_ => RealDeleteRecipeParameter(dbContext, recipeParameterList, optionSet, saveHist), 
		};
	}

	private static int CreateRecipeParameterInternal(IDbContext dbContext, Recipeparameter[] recipeParameterList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("recipeParameterList", recipeParameterList);
		string text = "CreateRecipeParameter";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Recipeparameter> list = new List<Recipeparameter>();
		foreach (Recipeparameter obj in recipeParameterList)
		{
			Recipeparameter recipeparameter = new Recipeparameter();
			obj.CopyColumsTo(recipeparameter);
			recipeparameter.Activity = text;
			recipeparameter.CheckEntityUsable();
			obj.CopyCommonField(recipeparameter, systemTime, dbContext.Tid, isCreate: true);
			list.Add(recipeparameter);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateRecipeParameter(IDbContext dbContext, Recipeparameter[] recipeParameterList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("recipeParameterList", recipeParameterList);
		string text = "UpdateRecipeParameter";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Recipeparameter> list = new List<Recipeparameter>();
		foreach (Recipeparameter recipeparameter in recipeParameterList)
		{
			Recipeparameter recipeParameter4Update = GetRecipeParameter4Update(dbContext, recipeparameter.Recipeparameterid, recipeparameter.Recipedefinitionid, recipeparameter.Siteid);
			if (recipeParameter4Update == null)
			{
				throw new EntityNotFoundException(typeof(Recipeparameter), $"{recipeparameter.Recipeparameterid},{recipeparameter.Recipedefinitionid},{recipeparameter.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Recipeparameter), $"{recipeparameter.Recipeparameterid},{recipeparameter.Recipedefinitionid},{recipeparameter.Siteid}", recipeParameter4Update.Isusable);
			string activity = recipeParameter4Update.Activity;
			string customactivity = recipeParameter4Update.Customactivity;
			string isusable = recipeParameter4Update.Isusable;
			DateTime? createtime = recipeParameter4Update.Createtime;
			string creator = recipeParameter4Update.Creator;
			recipeparameter.CopyColumsTo(recipeParameter4Update);
			recipeParameter4Update.Prevactivity = activity;
			recipeParameter4Update.Prevcustomactivity = customactivity;
			recipeParameter4Update.Creator = creator;
			recipeParameter4Update.Createtime = createtime;
			recipeParameter4Update.Isusable = isusable;
			recipeParameter4Update.Activity = text;
			recipeparameter.CopyCommonField(recipeParameter4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(recipeParameter4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteRecipeParameter(IDbContext dbContext, Recipeparameter[] recipeParameterList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("recipeParameterList", recipeParameterList);
		string text = "DeleteRecipeParameter";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Recipeparameter> list = new List<Recipeparameter>();
		foreach (Recipeparameter recipeparameter in recipeParameterList)
		{
			Recipeparameter recipeParameter4Update = GetRecipeParameter4Update(dbContext, recipeparameter.Recipeparameterid, recipeparameter.Recipedefinitionid, recipeparameter.Siteid);
			if (recipeParameter4Update == null)
			{
				throw new EntityNotFoundException(typeof(Recipeparameter), $"{recipeparameter.Recipeparameterid},{recipeparameter.Recipedefinitionid},{recipeparameter.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Recipeparameter), $"{recipeparameter.Recipeparameterid},{recipeparameter.Recipedefinitionid},{recipeparameter.Siteid}", recipeParameter4Update.Isusable);
			recipeParameter4Update.Isusable = "UnUsable";
			recipeparameter.CopyCommonFieldUpdatePrev(recipeParameter4Update, systemTime, dbContext.Tid, text);
			recipeparameter.CopyExtensionCollection(recipeParameter4Update);
			list.Add(recipeParameter4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteRecipeParameter(IDbContext dbContext, Recipeparameter[] recipeParameterList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("recipeParameterList", recipeParameterList);
		string text = "UnDeleteRecipeParameter";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Recipeparameter> list = new List<Recipeparameter>();
		foreach (Recipeparameter recipeparameter in recipeParameterList)
		{
			Recipeparameter recipeParameter4Update = GetRecipeParameter4Update(dbContext, recipeparameter.Recipeparameterid, recipeparameter.Recipedefinitionid, recipeparameter.Siteid);
			if (recipeParameter4Update == null)
			{
				throw new EntityNotFoundException(typeof(Recipeparameter), $"{recipeparameter.Recipeparameterid},{recipeparameter.Recipedefinitionid},{recipeparameter.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Recipeparameter), $"{recipeparameter.Recipeparameterid},{recipeparameter.Recipedefinitionid},{recipeparameter.Siteid}", recipeParameter4Update.Isusable);
			recipeParameter4Update.Isusable = "Usable";
			recipeparameter.CopyCommonFieldUpdatePrev(recipeParameter4Update, systemTime, dbContext.Tid, text);
			recipeparameter.CopyExtensionCollection(recipeParameter4Update);
			list.Add(recipeParameter4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteRecipeParameter(IDbContext dbContext, Recipeparameter[] recipeParameterList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("recipeParameterList", recipeParameterList);
		string text = "RealDeleteRecipeParameter";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Recipeparameter> list = new List<Recipeparameter>();
		foreach (Recipeparameter recipeparameter in recipeParameterList)
		{
			Recipeparameter recipeParameter4Update = GetRecipeParameter4Update(dbContext, recipeparameter.Recipeparameterid, recipeparameter.Recipedefinitionid, recipeparameter.Siteid);
			if (recipeParameter4Update == null)
			{
				throw new EntityNotFoundException(typeof(Recipeparameter), $"{recipeparameter.Recipeparameterid},{recipeparameter.Recipedefinitionid},{recipeparameter.Siteid}");
			}
			recipeparameter.CopyCommonFieldUpdatePrev(recipeParameter4Update, systemTime, dbContext.Tid, text);
			recipeparameter.CopyExtensionCollection(recipeParameter4Update);
			list.Add(recipeParameter4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
