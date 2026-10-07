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
public class ALARMACTIONCATEGORY
{
	private static string _sqlGetAlarmActionCategorySqlDatabase = "SELECT * FROM CIM_ALARMACTIONCATEGORY WHERE ALARMACTIONCATEGORYID=@ALARMACTIONCATEGORYID AND SITEID=@SITEID";

	private static string _sqlGetAlarmActionCategory4UpdateSqlDatabase = "SELECT * FROM CIM_ALARMACTIONCATEGORY WITH(UPDLOCK) WHERE ALARMACTIONCATEGORYID=@ALARMACTIONCATEGORYID AND SITEID=@SITEID";

	private static string _sqlSelectAlarmActionCategorySqlDatabase = "SELECT * FROM CIM_ALARMACTIONCATEGORY WHERE ALARMACTIONCATEGORYID=@ALARMACTIONCATEGORYID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectAlarmActionCategory4UpdateSqlDatabase = "SELECT * FROM CIM_ALARMACTIONCATEGORY WITH(UPDLOCK) WHERE ALARMACTIONCATEGORYID=@ALARMACTIONCATEGORYID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetAlarmActionCategoryOracleDatabase = "SELECT * FROM CIM_ALARMACTIONCATEGORY WHERE ALARMACTIONCATEGORYID=:ALARMACTIONCATEGORYID AND SITEID=:SITEID";

	private static string _sqlGetAlarmActionCategory4UpdateOracleDatabase = "SELECT * FROM CIM_ALARMACTIONCATEGORY WHERE ALARMACTIONCATEGORYID=:ALARMACTIONCATEGORYID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectAlarmActionCategoryOracleDatabase = "SELECT * FROM CIM_ALARMACTIONCATEGORY WHERE ALARMACTIONCATEGORYID=:ALARMACTIONCATEGORYID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectAlarmActionCategory4UpdateOracleDatabase = "SELECT * FROM CIM_ALARMACTIONCATEGORY WHERE ALARMACTIONCATEGORYID=:ALARMACTIONCATEGORYID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Alarmactioncategory);

	public static Alarmactioncategory GetAlarmActionCategory(IDbContext dbContext, string alarmactioncategoryid, string siteid)
	{
		string apiName = "GetAlarmActionCategory";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{alarmactioncategoryid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetAlarmActionCategorySqlDatabase : _sqlGetAlarmActionCategoryOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ALARMACTIONCATEGORYID", alarmactioncategoryid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_ALARMACTIONCATEGORY", $"{alarmactioncategoryid},{siteid}"));
		}
		Alarmactioncategory? result = ContextManager.DirectEntityQuery<Alarmactioncategory>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{alarmactioncategoryid},{siteid}");
		}
		return result;
	}

	public static Alarmactioncategory GetAlarmActionCategory4Update(IDbContext dbContext, string alarmactioncategoryid, string siteid)
	{
		string apiName = "GetAlarmActionCategory4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{alarmactioncategoryid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetAlarmActionCategory4UpdateSqlDatabase : _sqlGetAlarmActionCategory4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ALARMACTIONCATEGORYID", alarmactioncategoryid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_ALARMACTIONCATEGORY", $"{alarmactioncategoryid},{siteid}"));
		}
		Alarmactioncategory? result = ContextManager.DirectEntityQuery<Alarmactioncategory>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{alarmactioncategoryid},{siteid}");
		}
		return result;
	}

	public static Alarmactioncategory SelectAlarmActionCategory(IDbContext dbContext, string alarmactioncategoryid, string siteid)
	{
		string apiName = "SelectAlarmActionCategory";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{alarmactioncategoryid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectAlarmActionCategorySqlDatabase : _sqlSelectAlarmActionCategoryOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ALARMACTIONCATEGORYID", alarmactioncategoryid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_ALARMACTIONCATEGORY", $"{alarmactioncategoryid},{siteid}"));
		}
		Alarmactioncategory? result = ContextManager.DirectEntityQuery<Alarmactioncategory>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{alarmactioncategoryid},{siteid}");
		}
		return result;
	}

	public static Alarmactioncategory SelectAlarmActionCategory4Update(IDbContext dbContext, string alarmactioncategoryid, string siteid)
	{
		string apiName = "SelectAlarmActionCategory4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{alarmactioncategoryid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectAlarmActionCategory4UpdateSqlDatabase : _sqlSelectAlarmActionCategory4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ALARMACTIONCATEGORYID", alarmactioncategoryid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_ALARMACTIONCATEGORY", $"{alarmactioncategoryid},{siteid}"));
		}
		Alarmactioncategory? result = ContextManager.DirectEntityQuery<Alarmactioncategory>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{alarmactioncategoryid},{siteid}");
		}
		return result;
	}

	public static int UpsertAlarmActionCategory(IDbContext dbContext, RequestType requestType, Alarmactioncategory[] alarmActionCategoryList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateAlarmActionCategoryInternal(dbContext, alarmActionCategoryList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateAlarmActionCategory(dbContext, alarmActionCategoryList, optionSet, saveHist), 
			RequestType.DELETE => DeleteAlarmActionCategory(dbContext, alarmActionCategoryList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteAlarmActionCategory(dbContext, alarmActionCategoryList, optionSet, saveHist), 
			_ => RealDeleteAlarmActionCategory(dbContext, alarmActionCategoryList, optionSet, saveHist), 
		};
	}

	private static int CreateAlarmActionCategoryInternal(IDbContext dbContext, Alarmactioncategory[] alarmActionCategoryList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmActionCategoryList", alarmActionCategoryList);
		string text = "CreateAlarmActionCategory";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarmactioncategory> list = new List<Alarmactioncategory>();
		foreach (Alarmactioncategory obj in alarmActionCategoryList)
		{
			Alarmactioncategory alarmactioncategory = new Alarmactioncategory();
			obj.CopyColumsTo(alarmactioncategory);
			alarmactioncategory.Activity = text;
			alarmactioncategory.CheckEntityUsable();
			obj.CopyCommonField(alarmactioncategory, systemTime, dbContext.Tid, isCreate: true);
			list.Add(alarmactioncategory);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateAlarmActionCategory(IDbContext dbContext, Alarmactioncategory[] alarmActionCategoryList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmActionCategoryList", alarmActionCategoryList);
		string text = "UpdateAlarmActionCategory";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarmactioncategory> list = new List<Alarmactioncategory>();
		foreach (Alarmactioncategory alarmactioncategory in alarmActionCategoryList)
		{
			Alarmactioncategory alarmActionCategory4Update = GetAlarmActionCategory4Update(dbContext, alarmactioncategory.Alarmactioncategoryid, alarmactioncategory.Siteid);
			if (alarmActionCategory4Update == null)
			{
				throw new EntityNotFoundException(typeof(Alarmactioncategory), $"{alarmactioncategory.Alarmactioncategoryid},{alarmactioncategory.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Alarmactioncategory), $"{alarmactioncategory.Alarmactioncategoryid},{alarmactioncategory.Siteid}", alarmActionCategory4Update.Isusable);
			string activity = alarmActionCategory4Update.Activity;
			string customactivity = alarmActionCategory4Update.Customactivity;
			string isusable = alarmActionCategory4Update.Isusable;
			DateTime? createtime = alarmActionCategory4Update.Createtime;
			string creator = alarmActionCategory4Update.Creator;
			alarmactioncategory.CopyColumsTo(alarmActionCategory4Update);
			alarmActionCategory4Update.Prevactivity = activity;
			alarmActionCategory4Update.Prevcustomactivity = customactivity;
			alarmActionCategory4Update.Creator = creator;
			alarmActionCategory4Update.Createtime = createtime;
			alarmActionCategory4Update.Isusable = isusable;
			alarmActionCategory4Update.Activity = text;
			alarmactioncategory.CopyCommonField(alarmActionCategory4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(alarmActionCategory4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteAlarmActionCategory(IDbContext dbContext, Alarmactioncategory[] alarmActionCategoryList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmActionCategoryList", alarmActionCategoryList);
		string text = "DeleteAlarmActionCategory";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarmactioncategory> list = new List<Alarmactioncategory>();
		foreach (Alarmactioncategory alarmactioncategory in alarmActionCategoryList)
		{
			Alarmactioncategory alarmActionCategory4Update = GetAlarmActionCategory4Update(dbContext, alarmactioncategory.Alarmactioncategoryid, alarmactioncategory.Siteid);
			if (alarmActionCategory4Update == null)
			{
				throw new EntityNotFoundException(typeof(Alarmactioncategory), $"{alarmactioncategory.Alarmactioncategoryid},{alarmactioncategory.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Alarmactioncategory), $"{alarmactioncategory.Alarmactioncategoryid},{alarmactioncategory.Siteid}", alarmActionCategory4Update.Isusable);
			alarmActionCategory4Update.Isusable = "UnUsable";
			alarmactioncategory.CopyCommonFieldUpdatePrev(alarmActionCategory4Update, systemTime, dbContext.Tid, text);
			alarmactioncategory.CopyExtensionCollection(alarmActionCategory4Update);
			list.Add(alarmActionCategory4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteAlarmActionCategory(IDbContext dbContext, Alarmactioncategory[] alarmActionCategoryList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmActionCategoryList", alarmActionCategoryList);
		string text = "UnDeleteAlarmActionCategory";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarmactioncategory> list = new List<Alarmactioncategory>();
		foreach (Alarmactioncategory alarmactioncategory in alarmActionCategoryList)
		{
			Alarmactioncategory alarmActionCategory4Update = GetAlarmActionCategory4Update(dbContext, alarmactioncategory.Alarmactioncategoryid, alarmactioncategory.Siteid);
			if (alarmActionCategory4Update == null)
			{
				throw new EntityNotFoundException(typeof(Alarmactioncategory), dbContext.Log(alarmactioncategory));
			}
			ParamChecker.EntityUnUsable(typeof(Alarmactioncategory), dbContext.Log(alarmactioncategory), alarmActionCategory4Update.Isusable);
			alarmActionCategory4Update.Isusable = "Usable";
			alarmactioncategory.CopyCommonFieldUpdatePrev(alarmActionCategory4Update, systemTime, dbContext.Tid, text);
			alarmactioncategory.CopyExtensionCollection(alarmActionCategory4Update);
			list.Add(alarmActionCategory4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteAlarmActionCategory(IDbContext dbContext, Alarmactioncategory[] alarmActionCategoryList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmActionCategoryList", alarmActionCategoryList);
		string text = "RealDeleteAlarmActionCategory";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarmactioncategory> list = new List<Alarmactioncategory>();
		foreach (Alarmactioncategory alarmactioncategory in alarmActionCategoryList)
		{
			Alarmactioncategory alarmActionCategory4Update = GetAlarmActionCategory4Update(dbContext, alarmactioncategory.Alarmactioncategoryid, alarmactioncategory.Siteid);
			if (alarmActionCategory4Update == null)
			{
				throw new EntityNotFoundException(typeof(Alarmactioncategory), $"{alarmactioncategory.Alarmactioncategoryid},{alarmactioncategory.Siteid}");
			}
			alarmactioncategory.CopyCommonFieldUpdatePrev(alarmActionCategory4Update, systemTime, dbContext.Tid, text);
			alarmactioncategory.CopyExtensionCollection(alarmActionCategory4Update);
			list.Add(alarmActionCategory4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
