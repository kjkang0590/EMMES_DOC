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
public class RECIPEITEM
{
	private static string _sqlGetRecipeItemSqlDatabase = "SELECT * FROM CIM_RECIPEITEM WHERE RECIPEITEMID=@RECIPEITEMID AND SITEID=@SITEID";

	private static string _sqlGetRecipeItem4UpdateSqlDatabase = "SELECT * FROM CIM_RECIPEITEM WITH(UPDLOCK) WHERE RECIPEITEMID=@RECIPEITEMID AND SITEID=@SITEID";

	private static string _sqlSelectRecipeItemSqlDatabase = "SELECT * FROM CIM_RECIPEITEM WHERE RECIPEITEMID=@RECIPEITEMID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectRecipeItem4UpdateSqlDatabase = "SELECT * FROM CIM_RECIPEITEM WITH(UPDLOCK) WHERE RECIPEITEMID=@RECIPEITEMID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetRecipeItemOracleDatabase = "SELECT * FROM CIM_RECIPEITEM WHERE RECIPEITEMID=:RECIPEITEMID AND SITEID=:SITEID";

	private static string _sqlGetRecipeItem4UpdateOracleDatabase = "SELECT * FROM CIM_RECIPEITEM WHERE RECIPEITEMID=:RECIPEITEMID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectRecipeItemOracleDatabase = "SELECT * FROM CIM_RECIPEITEM WHERE RECIPEITEMID=:RECIPEITEMID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectRecipeItem4UpdateOracleDatabase = "SELECT * FROM CIM_RECIPEITEM WHERE RECIPEITEMID=:RECIPEITEMID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static string _sqlSelectRecipeItemByRecipeDefinitionIdSqlDatabase = "SELECT * FROM CIM_RECIPEITEM WHERE RECIPEDEFINITIONID=@RECIPEDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectRecipeItemByRecipeDefinitionIdOracleDatabase = "SELECT * FROM CIM_RECIPEITEM WHERE RECIPEDEFINITIONID=:RECIPEDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static Type typeOfThis = typeof(Recipeitem);

	public static Recipeitem GetRecipeItem(IDbContext dbContext, string recipeitemid, string siteid)
	{
		string apiName = "GetRecipeItem";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{recipeitemid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetRecipeItemSqlDatabase : _sqlGetRecipeItemOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RECIPEITEMID", recipeitemid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_RECIPEITEM", $"{recipeitemid},{siteid}"));
		}
		Recipeitem? result = ContextManager.DirectEntityQuery<Recipeitem>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{recipeitemid},{siteid}");
		}
		return result;
	}

	public static Recipeitem GetRecipeItem4Update(IDbContext dbContext, string recipeitemid, string siteid)
	{
		string apiName = "GetRecipeItem4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{recipeitemid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetRecipeItem4UpdateSqlDatabase : _sqlGetRecipeItem4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RECIPEITEMID", recipeitemid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_RECIPEITEM", $"{recipeitemid},{siteid}"));
		}
		Recipeitem? result = ContextManager.DirectEntityQuery<Recipeitem>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{recipeitemid},{siteid}");
		}
		return result;
	}

	public static Recipeitem SelectRecipeItem(IDbContext dbContext, string recipeitemid, string siteid)
	{
		string apiName = "SelectRecipeItem";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{recipeitemid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectRecipeItemSqlDatabase : _sqlSelectRecipeItemOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RECIPEITEMID", recipeitemid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_RECIPEITEM", $"{recipeitemid},{siteid}"));
		}
		Recipeitem? result = ContextManager.DirectEntityQuery<Recipeitem>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{recipeitemid},{siteid}");
		}
		return result;
	}

	public static Recipeitem SelectRecipeItem4Update(IDbContext dbContext, string recipeitemid, string siteid)
	{
		string apiName = "SelectRecipeItem4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{recipeitemid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectRecipeItem4UpdateSqlDatabase : _sqlSelectRecipeItem4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RECIPEITEMID", recipeitemid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_RECIPEITEM", $"{recipeitemid},{siteid}"));
		}
		Recipeitem? result = ContextManager.DirectEntityQuery<Recipeitem>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{recipeitemid},{siteid}");
		}
		return result;
	}

	public static int UpsertRecipeItem(IDbContext dbContext, RequestType requestType, Recipeitem[] recipeItemList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateRecipeItemInternal(dbContext, recipeItemList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateRecipeItem(dbContext, recipeItemList, optionSet, saveHist), 
			RequestType.DELETE => DeleteRecipeItem(dbContext, recipeItemList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteRecipeItem(dbContext, recipeItemList, optionSet, saveHist), 
			_ => RealDeleteRecipeItem(dbContext, recipeItemList, optionSet, saveHist), 
		};
	}

	private static int CreateRecipeItemInternal(IDbContext dbContext, Recipeitem[] recipeItemList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("recipeItemList", recipeItemList);
		string text = "CreateRecipeItem";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Recipeitem> list = new List<Recipeitem>();
		foreach (Recipeitem obj in recipeItemList)
		{
			Recipeitem recipeitem = new Recipeitem();
			obj.CopyColumsTo(recipeitem);
			recipeitem.Activity = text;
			recipeitem.CheckEntityUsable();
			obj.CopyCommonField(recipeitem, systemTime, dbContext.Tid, isCreate: true);
			list.Add(recipeitem);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateRecipeItem(IDbContext dbContext, Recipeitem[] recipeItemList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("recipeItemList", recipeItemList);
		string text = "UpdateRecipeItem";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Recipeitem> list = new List<Recipeitem>();
		foreach (Recipeitem recipeitem in recipeItemList)
		{
			Recipeitem recipeItem4Update = GetRecipeItem4Update(dbContext, recipeitem.Recipeitemid, recipeitem.Siteid);
			if (recipeItem4Update == null)
			{
				throw new EntityNotFoundException(typeof(Recipeitem), $"{recipeitem.Recipeitemid},{recipeitem.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Recipeitem), $"{recipeitem.Recipeitemid},{recipeitem.Siteid}", recipeItem4Update.Isusable);
			string activity = recipeItem4Update.Activity;
			string customactivity = recipeItem4Update.Customactivity;
			string isusable = recipeItem4Update.Isusable;
			DateTime? createtime = recipeItem4Update.Createtime;
			string creator = recipeItem4Update.Creator;
			recipeitem.CopyColumsTo(recipeItem4Update);
			recipeItem4Update.Prevactivity = activity;
			recipeItem4Update.Prevcustomactivity = customactivity;
			recipeItem4Update.Creator = creator;
			recipeItem4Update.Createtime = createtime;
			recipeItem4Update.Isusable = isusable;
			recipeItem4Update.Activity = text;
			recipeitem.CopyCommonField(recipeItem4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(recipeItem4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteRecipeItem(IDbContext dbContext, Recipeitem[] recipeItemList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("recipeItemList", recipeItemList);
		string text = "DeleteRecipeItem";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Recipeitem> list = new List<Recipeitem>();
		foreach (Recipeitem recipeitem in recipeItemList)
		{
			Recipeitem recipeItem4Update = GetRecipeItem4Update(dbContext, recipeitem.Recipeitemid, recipeitem.Siteid);
			if (recipeItem4Update == null)
			{
				throw new EntityNotFoundException(typeof(Recipeitem), $"{recipeitem.Recipeitemid},{recipeitem.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Recipeitem), $"{recipeitem.Recipeitemid},{recipeitem.Siteid}", recipeItem4Update.Isusable);
			recipeItem4Update.Isusable = "UnUsable";
			recipeitem.CopyCommonFieldUpdatePrev(recipeItem4Update, systemTime, dbContext.Tid, text);
			recipeitem.CopyExtensionCollection(recipeItem4Update);
			list.Add(recipeItem4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteRecipeItem(IDbContext dbContext, Recipeitem[] recipeItemList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("recipeItemList", recipeItemList);
		string text = "UnDeleteRecipeItem";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Recipeitem> list = new List<Recipeitem>();
		foreach (Recipeitem recipeitem in recipeItemList)
		{
			Recipeitem recipeItem4Update = GetRecipeItem4Update(dbContext, recipeitem.Recipeitemid, recipeitem.Siteid);
			if (recipeItem4Update == null)
			{
				throw new EntityNotFoundException(typeof(Recipeitem), $"{recipeitem.Recipeitemid},{recipeitem.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Recipeitem), $"{recipeitem.Recipeitemid},{recipeitem.Siteid}", recipeItem4Update.Isusable);
			recipeItem4Update.Isusable = "Usable";
			recipeitem.CopyCommonFieldUpdatePrev(recipeItem4Update, systemTime, dbContext.Tid, text);
			recipeitem.CopyExtensionCollection(recipeItem4Update);
			list.Add(recipeItem4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteRecipeItem(IDbContext dbContext, Recipeitem[] recipeItemList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("recipeItemList", recipeItemList);
		string text = "RealDeleteRecipeItem";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Recipeitem> list = new List<Recipeitem>();
		foreach (Recipeitem recipeitem in recipeItemList)
		{
			Recipeitem recipeItem4Update = GetRecipeItem4Update(dbContext, recipeitem.Recipeitemid, recipeitem.Siteid);
			if (recipeItem4Update == null)
			{
				throw new EntityNotFoundException(typeof(Recipeitem), $"{recipeitem.Recipeitemid},{recipeitem.Siteid}");
			}
			recipeitem.CopyCommonFieldUpdatePrev(recipeItem4Update, systemTime, dbContext.Tid, text);
			recipeitem.CopyExtensionCollection(recipeItem4Update);
			list.Add(recipeItem4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
