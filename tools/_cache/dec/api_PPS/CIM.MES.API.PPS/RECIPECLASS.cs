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
public class RECIPECLASS
{
	private static string _sqlGetRecipeClassSqlDatabase = "SELECT * FROM CIM_RECIPECLASS WHERE RECIPECLASSID=@RECIPECLASSID AND SITEID=@SITEID";

	private static string _sqlGetRecipeClass4UpdateSqlDatabase = "SELECT * FROM CIM_RECIPECLASS WITH(UPDLOCK) WHERE RECIPECLASSID=@RECIPECLASSID AND SITEID=@SITEID";

	private static string _sqlSelectRecipeClassSqlDatabase = "SELECT * FROM CIM_RECIPECLASS WHERE RECIPECLASSID=@RECIPECLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectRecipeClass4UpdateSqlDatabase = "SELECT * FROM CIM_RECIPECLASS WITH(UPDLOCK) WHERE RECIPECLASSID=@RECIPECLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetRecipeClassOracleDatabase = "SELECT * FROM CIM_RECIPECLASS WHERE RECIPECLASSID=:RECIPECLASSID AND SITEID=:SITEID";

	private static string _sqlGetRecipeClass4UpdateOracleDatabase = "SELECT * FROM CIM_RECIPECLASS WHERE RECIPECLASSID=:RECIPECLASSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectRecipeClassOracleDatabase = "SELECT * FROM CIM_RECIPECLASS WHERE RECIPECLASSID=:RECIPECLASSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectRecipeClass4UpdateOracleDatabase = "SELECT * FROM CIM_RECIPECLASS WHERE RECIPECLASSID=:RECIPECLASSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Recipeclass);

	public static Recipeclass GetRecipeClass(IDbContext dbContext, string recipeclassid, string siteid)
	{
		string apiName = "GetRecipeClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{recipeclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetRecipeClassSqlDatabase : _sqlGetRecipeClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RECIPECLASSID", recipeclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_RECIPECLASS", $"{recipeclassid},{siteid}"));
		}
		Recipeclass? result = ContextManager.DirectEntityQuery<Recipeclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{recipeclassid},{siteid}");
		}
		return result;
	}

	public static Recipeclass GetRecipeClass4Update(IDbContext dbContext, string recipeclassid, string siteid)
	{
		string apiName = "GetRecipeClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{recipeclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetRecipeClass4UpdateSqlDatabase : _sqlGetRecipeClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RECIPECLASSID", recipeclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_RECIPECLASS", $"{recipeclassid},{siteid}"));
		}
		Recipeclass? result = ContextManager.DirectEntityQuery<Recipeclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{recipeclassid},{siteid}");
		}
		return result;
	}

	public static Recipeclass SelectRecipeClass(IDbContext dbContext, string recipeclassid, string siteid)
	{
		string apiName = "SelectRecipeClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{recipeclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectRecipeClassSqlDatabase : _sqlSelectRecipeClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RECIPECLASSID", recipeclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_RECIPECLASS", $"{recipeclassid},{siteid}"));
		}
		Recipeclass? result = ContextManager.DirectEntityQuery<Recipeclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{recipeclassid},{siteid}");
		}
		return result;
	}

	public static Recipeclass SelectRecipeClass4Update(IDbContext dbContext, string recipeclassid, string siteid)
	{
		string apiName = "SelectRecipeClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{recipeclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectRecipeClass4UpdateSqlDatabase : _sqlSelectRecipeClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RECIPECLASSID", recipeclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_RECIPECLASS", $"{recipeclassid},{siteid}"));
		}
		Recipeclass? result = ContextManager.DirectEntityQuery<Recipeclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{recipeclassid},{siteid}");
		}
		return result;
	}

	public static int UpsertRecipeClass(IDbContext dbContext, RequestType requestType, Recipeclass[] recipeClassList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateRecipeClassInternal(dbContext, recipeClassList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateRecipeClass(dbContext, recipeClassList, optionSet, saveHist), 
			RequestType.DELETE => DeleteRecipeClass(dbContext, recipeClassList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteRecipeClass(dbContext, recipeClassList, optionSet, saveHist), 
			_ => RealDeleteRecipeClass(dbContext, recipeClassList, optionSet, saveHist), 
		};
	}

	private static int CreateRecipeClassInternal(IDbContext dbContext, Recipeclass[] recipeClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("recipeClassList", recipeClassList);
		string text = "CreateRecipeClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Recipeclass> list = new List<Recipeclass>();
		foreach (Recipeclass obj in recipeClassList)
		{
			Recipeclass recipeclass = new Recipeclass();
			obj.CopyColumsTo(recipeclass);
			recipeclass.Activity = text;
			recipeclass.CheckEntityUsable();
			obj.CopyCommonField(recipeclass, systemTime, dbContext.Tid, isCreate: true);
			list.Add(recipeclass);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateRecipeClass(IDbContext dbContext, Recipeclass[] recipeClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("recipeClassList", recipeClassList);
		string text = "UpdateRecipeClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Recipeclass> list = new List<Recipeclass>();
		foreach (Recipeclass recipeclass in recipeClassList)
		{
			Recipeclass recipeClass4Update = GetRecipeClass4Update(dbContext, recipeclass.Recipeclassid, recipeclass.Siteid);
			if (recipeClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Recipeclass), $"{recipeclass.Recipeclassid},{recipeclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Recipeclass), $"{recipeclass.Recipeclassid},{recipeclass.Siteid}", recipeClass4Update.Isusable);
			string activity = recipeClass4Update.Activity;
			string customactivity = recipeClass4Update.Customactivity;
			string isusable = recipeClass4Update.Isusable;
			DateTime? createtime = recipeClass4Update.Createtime;
			string creator = recipeClass4Update.Creator;
			recipeclass.CopyColumsTo(recipeClass4Update);
			recipeClass4Update.Prevactivity = activity;
			recipeClass4Update.Prevcustomactivity = customactivity;
			recipeClass4Update.Creator = creator;
			recipeClass4Update.Createtime = createtime;
			recipeClass4Update.Isusable = isusable;
			recipeClass4Update.Activity = text;
			recipeclass.CopyCommonField(recipeClass4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(recipeClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteRecipeClass(IDbContext dbContext, Recipeclass[] recipeClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("recipeClassList", recipeClassList);
		string text = "DeleteRecipeClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Recipeclass> list = new List<Recipeclass>();
		foreach (Recipeclass recipeclass in recipeClassList)
		{
			Recipeclass recipeClass4Update = GetRecipeClass4Update(dbContext, recipeclass.Recipeclassid, recipeclass.Siteid);
			if (recipeClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Recipeclass), $"{recipeclass.Recipeclassid},{recipeclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Recipeclass), $"{recipeclass.Recipeclassid},{recipeclass.Siteid}", recipeClass4Update.Isusable);
			recipeClass4Update.Isusable = "UnUsable";
			recipeclass.CopyCommonFieldUpdatePrev(recipeClass4Update, systemTime, dbContext.Tid, text);
			recipeclass.CopyExtensionCollection(recipeClass4Update);
			list.Add(recipeClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteRecipeClass(IDbContext dbContext, Recipeclass[] recipeClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("recipeClassList", recipeClassList);
		string text = "UnDeleteRecipeClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Recipeclass> list = new List<Recipeclass>();
		foreach (Recipeclass recipeclass in recipeClassList)
		{
			Recipeclass recipeClass4Update = GetRecipeClass4Update(dbContext, recipeclass.Recipeclassid, recipeclass.Siteid);
			if (recipeClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Recipeclass), $"{recipeclass.Recipeclassid},{recipeclass.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Recipeclass), $"{recipeclass.Recipeclassid},{recipeclass.Siteid}", recipeClass4Update.Isusable);
			recipeClass4Update.Isusable = "Usable";
			recipeclass.CopyCommonFieldUpdatePrev(recipeClass4Update, systemTime, dbContext.Tid, text);
			recipeclass.CopyExtensionCollection(recipeClass4Update);
			list.Add(recipeClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteRecipeClass(IDbContext dbContext, Recipeclass[] recipeClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("recipeClassList", recipeClassList);
		string text = "RealDeleteRecipeClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Recipeclass> list = new List<Recipeclass>();
		foreach (Recipeclass recipeclass in recipeClassList)
		{
			Recipeclass recipeClass4Update = GetRecipeClass4Update(dbContext, recipeclass.Recipeclassid, recipeclass.Siteid);
			if (recipeClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Recipeclass), $"{recipeclass.Recipeclassid},{recipeclass.Siteid}");
			}
			recipeclass.CopyCommonFieldUpdatePrev(recipeClass4Update, systemTime, dbContext.Tid, text);
			recipeclass.CopyExtensionCollection(recipeClass4Update);
			list.Add(recipeClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
