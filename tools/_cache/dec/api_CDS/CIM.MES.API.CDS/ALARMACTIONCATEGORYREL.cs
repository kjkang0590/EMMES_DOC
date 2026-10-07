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
public class ALARMACTIONCATEGORYREL
{
	private static string _sqlGetAlarmActionCategoryRelSqlDatabase = "SELECT * FROM CIM_ALARMACTIONCATEGORYREL WHERE ALARMACTIONCATEGORYID=@ALARMACTIONCATEGORYID AND ALARMACTIONID=@ALARMACTIONID AND SITEID=@SITEID";

	private static string _sqlGetAlarmActionCategoryRel4UpdateSqlDatabase = "SELECT * FROM CIM_ALARMACTIONCATEGORYREL WITH(UPDLOCK) WHERE ALARMACTIONCATEGORYID=@ALARMACTIONCATEGORYID AND ALARMACTIONID=@ALARMACTIONID AND SITEID=@SITEID";

	private static string _sqlSelectAlarmActionCategoryRelSqlDatabase = "SELECT * FROM CIM_ALARMACTIONCATEGORYREL WHERE ALARMACTIONCATEGORYID=@ALARMACTIONCATEGORYID AND ALARMACTIONID=@ALARMACTIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectAlarmActionCategoryRel4UpdateSqlDatabase = "SELECT * FROM CIM_ALARMACTIONCATEGORYREL WITH(UPDLOCK) WHERE ALARMACTIONCATEGORYID=@ALARMACTIONCATEGORYID AND ALARMACTIONID=@ALARMACTIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetAlarmActionCategoryRelOracleDatabase = "SELECT * FROM CIM_ALARMACTIONCATEGORYREL WHERE ALARMACTIONCATEGORYID=:ALARMACTIONCATEGORYID AND ALARMACTIONID=:ALARMACTIONID AND SITEID=:SITEID";

	private static string _sqlGetAlarmActionCategoryRel4UpdateOracleDatabase = "SELECT * FROM CIM_ALARMACTIONCATEGORYREL WHERE ALARMACTIONCATEGORYID=:ALARMACTIONCATEGORYID AND ALARMACTIONID=:ALARMACTIONID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectAlarmActionCategoryRelOracleDatabase = "SELECT * FROM CIM_ALARMACTIONCATEGORYREL WHERE ALARMACTIONCATEGORYID=:ALARMACTIONCATEGORYID AND ALARMACTIONID=:ALARMACTIONID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectAlarmActionCategoryRel4UpdateOracleDatabase = "SELECT * FROM CIM_ALARMACTIONCATEGORYREL WHERE ALARMACTIONCATEGORYID=:ALARMACTIONCATEGORYID AND ALARMACTIONID=:ALARMACTIONID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Alarmactioncategoryrel);

	public static Alarmactioncategoryrel GetAlarmActionCategoryRel(IDbContext dbContext, string alarmactioncategoryid, string alarmactionid, string siteid)
	{
		string apiName = "GetAlarmActionCategoryRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{alarmactioncategoryid},{alarmactionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetAlarmActionCategoryRelSqlDatabase : _sqlGetAlarmActionCategoryRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ALARMACTIONCATEGORYID", alarmactioncategoryid, typeOfThis));
		list.Add(dbContext.CreateParameter("ALARMACTIONID", alarmactionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_ALARMACTIONCATEGORYREL", $"{alarmactioncategoryid},{alarmactionid},{siteid}"));
		}
		Alarmactioncategoryrel? result = ContextManager.DirectEntityQuery<Alarmactioncategoryrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{alarmactioncategoryid},{alarmactionid},{siteid}");
		}
		return result;
	}

	public static Alarmactioncategoryrel GetAlarmActionCategoryRel4Update(IDbContext dbContext, string alarmactioncategoryid, string alarmactionid, string siteid)
	{
		string apiName = "GetAlarmActionCategoryRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{alarmactioncategoryid},{alarmactionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetAlarmActionCategoryRel4UpdateSqlDatabase : _sqlGetAlarmActionCategoryRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ALARMACTIONCATEGORYID", alarmactioncategoryid, typeOfThis));
		list.Add(dbContext.CreateParameter("ALARMACTIONID", alarmactionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_ALARMACTIONCATEGORYREL", $"{alarmactioncategoryid},{alarmactionid},{siteid}"));
		}
		Alarmactioncategoryrel? result = ContextManager.DirectEntityQuery<Alarmactioncategoryrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{alarmactioncategoryid},{alarmactionid},{siteid}");
		}
		return result;
	}

	public static Alarmactioncategoryrel SelectAlarmActionCategoryRel(IDbContext dbContext, string alarmactioncategoryid, string alarmactionid, string siteid)
	{
		string apiName = "SelectAlarmActionCategoryRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{alarmactioncategoryid},{alarmactionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectAlarmActionCategoryRelSqlDatabase : _sqlSelectAlarmActionCategoryRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ALARMACTIONCATEGORYID", alarmactioncategoryid, typeOfThis));
		list.Add(dbContext.CreateParameter("ALARMACTIONID", alarmactionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_ALARMACTIONCATEGORYREL", $"{alarmactioncategoryid},{alarmactionid},{siteid}"));
		}
		Alarmactioncategoryrel? result = ContextManager.DirectEntityQuery<Alarmactioncategoryrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{alarmactioncategoryid},{alarmactionid},{siteid}");
		}
		return result;
	}

	public static Alarmactioncategoryrel SelectAlarmActionCategoryRel4Update(IDbContext dbContext, string alarmactioncategoryid, string alarmactionid, string siteid)
	{
		string apiName = "SelectAlarmActionCategoryRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{alarmactioncategoryid},{alarmactionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectAlarmActionCategoryRel4UpdateSqlDatabase : _sqlSelectAlarmActionCategoryRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ALARMACTIONCATEGORYID", alarmactioncategoryid, typeOfThis));
		list.Add(dbContext.CreateParameter("ALARMACTIONID", alarmactionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_ALARMACTIONCATEGORYREL", $"{alarmactioncategoryid},{alarmactionid},{siteid}"));
		}
		Alarmactioncategoryrel? result = ContextManager.DirectEntityQuery<Alarmactioncategoryrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{alarmactioncategoryid},{alarmactionid},{siteid}");
		}
		return result;
	}

	public static int UpsertAlarmActionCategoryRel(IDbContext dbContext, RequestType requestType, Alarmactioncategoryrel[] alarmActionCategoryRelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateAlarmActionCategoryRelInternal(dbContext, alarmActionCategoryRelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateAlarmActionCategoryRel(dbContext, alarmActionCategoryRelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteAlarmActionCategoryRel(dbContext, alarmActionCategoryRelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteAlarmActionCategoryRel(dbContext, alarmActionCategoryRelList, optionSet, saveHist), 
			_ => RealDeleteAlarmActionCategoryRel(dbContext, alarmActionCategoryRelList, optionSet, saveHist), 
		};
	}

	private static int CreateAlarmActionCategoryRelInternal(IDbContext dbContext, Alarmactioncategoryrel[] alarmActionCategoryRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmActionCategoryRelList", alarmActionCategoryRelList);
		string text = "CreateAlarmActionCategoryRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarmactioncategoryrel> list = new List<Alarmactioncategoryrel>();
		foreach (Alarmactioncategoryrel obj in alarmActionCategoryRelList)
		{
			Alarmactioncategoryrel alarmactioncategoryrel = new Alarmactioncategoryrel();
			obj.CopyColumsTo(alarmactioncategoryrel);
			alarmactioncategoryrel.Activity = text;
			alarmactioncategoryrel.CheckEntityUsable();
			obj.CopyCommonField(alarmactioncategoryrel, systemTime, dbContext.Tid, isCreate: true);
			list.Add(alarmactioncategoryrel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateAlarmActionCategoryRel(IDbContext dbContext, Alarmactioncategoryrel[] alarmActionCategoryRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmActionCategoryRelList", alarmActionCategoryRelList);
		string text = "UpdateAlarmActionCategoryRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarmactioncategoryrel> list = new List<Alarmactioncategoryrel>();
		foreach (Alarmactioncategoryrel alarmactioncategoryrel in alarmActionCategoryRelList)
		{
			Alarmactioncategoryrel alarmActionCategoryRel4Update = GetAlarmActionCategoryRel4Update(dbContext, alarmactioncategoryrel.Alarmactioncategoryid, alarmactioncategoryrel.Alarmactionid, alarmactioncategoryrel.Siteid);
			if (alarmActionCategoryRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Alarmactioncategoryrel), $"{alarmactioncategoryrel.Alarmactioncategoryid},{alarmactioncategoryrel.Alarmactionid},{alarmactioncategoryrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Alarmactioncategoryrel), $"{alarmactioncategoryrel.Alarmactioncategoryid},{alarmactioncategoryrel.Alarmactionid},{alarmactioncategoryrel.Siteid}", alarmActionCategoryRel4Update.Isusable);
			string activity = alarmActionCategoryRel4Update.Activity;
			string customactivity = alarmActionCategoryRel4Update.Customactivity;
			string isusable = alarmActionCategoryRel4Update.Isusable;
			DateTime? createtime = alarmActionCategoryRel4Update.Createtime;
			string creator = alarmActionCategoryRel4Update.Creator;
			alarmactioncategoryrel.CopyColumsTo(alarmActionCategoryRel4Update);
			alarmActionCategoryRel4Update.Prevactivity = activity;
			alarmActionCategoryRel4Update.Prevcustomactivity = customactivity;
			alarmActionCategoryRel4Update.Creator = creator;
			alarmActionCategoryRel4Update.Createtime = createtime;
			alarmActionCategoryRel4Update.Isusable = isusable;
			alarmActionCategoryRel4Update.Activity = text;
			alarmactioncategoryrel.CopyCommonField(alarmActionCategoryRel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(alarmActionCategoryRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteAlarmActionCategoryRel(IDbContext dbContext, Alarmactioncategoryrel[] alarmActionCategoryRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmActionCategoryRelList", alarmActionCategoryRelList);
		string text = "DeleteAlarmActionCategoryRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarmactioncategoryrel> list = new List<Alarmactioncategoryrel>();
		foreach (Alarmactioncategoryrel alarmactioncategoryrel in alarmActionCategoryRelList)
		{
			Alarmactioncategoryrel alarmActionCategoryRel4Update = GetAlarmActionCategoryRel4Update(dbContext, alarmactioncategoryrel.Alarmactioncategoryid, alarmactioncategoryrel.Alarmactionid, alarmactioncategoryrel.Siteid);
			if (alarmActionCategoryRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Alarmactioncategoryrel), $"{alarmactioncategoryrel.Alarmactioncategoryid},{alarmactioncategoryrel.Alarmactionid},{alarmactioncategoryrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Alarmactioncategoryrel), $"{alarmactioncategoryrel.Alarmactioncategoryid},{alarmactioncategoryrel.Alarmactionid},{alarmactioncategoryrel.Siteid}", alarmActionCategoryRel4Update.Isusable);
			alarmActionCategoryRel4Update.Isusable = "UnUsable";
			alarmactioncategoryrel.CopyCommonFieldUpdatePrev(alarmActionCategoryRel4Update, systemTime, dbContext.Tid, text);
			alarmactioncategoryrel.CopyExtensionCollection(alarmActionCategoryRel4Update);
			list.Add(alarmActionCategoryRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteAlarmActionCategoryRel(IDbContext dbContext, Alarmactioncategoryrel[] alarmActionCategoryRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmActionCategoryRelList", alarmActionCategoryRelList);
		string text = "UnDeleteAlarmActionCategoryRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarmactioncategoryrel> list = new List<Alarmactioncategoryrel>();
		foreach (Alarmactioncategoryrel alarmactioncategoryrel in alarmActionCategoryRelList)
		{
			Alarmactioncategoryrel alarmActionCategoryRel4Update = GetAlarmActionCategoryRel4Update(dbContext, alarmactioncategoryrel.Alarmactioncategoryid, alarmactioncategoryrel.Alarmactionid, alarmactioncategoryrel.Siteid);
			if (alarmActionCategoryRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Alarmactioncategoryrel), $"{alarmactioncategoryrel.Alarmactioncategoryid},{alarmactioncategoryrel.Alarmactionid},{alarmactioncategoryrel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Alarmactioncategoryrel), $"{alarmactioncategoryrel.Alarmactioncategoryid},{alarmactioncategoryrel.Alarmactionid},{alarmactioncategoryrel.Siteid}", alarmActionCategoryRel4Update.Isusable);
			alarmActionCategoryRel4Update.Isusable = "Usable";
			alarmactioncategoryrel.CopyCommonFieldUpdatePrev(alarmActionCategoryRel4Update, systemTime, dbContext.Tid, text);
			alarmactioncategoryrel.CopyExtensionCollection(alarmActionCategoryRel4Update);
			list.Add(alarmActionCategoryRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteAlarmActionCategoryRel(IDbContext dbContext, Alarmactioncategoryrel[] alarmActionCategoryRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmActionCategoryRelList", alarmActionCategoryRelList);
		string text = "RealDeleteAlarmActionCategoryRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarmactioncategoryrel> list = new List<Alarmactioncategoryrel>();
		foreach (Alarmactioncategoryrel alarmactioncategoryrel in alarmActionCategoryRelList)
		{
			Alarmactioncategoryrel alarmActionCategoryRel4Update = GetAlarmActionCategoryRel4Update(dbContext, alarmactioncategoryrel.Alarmactioncategoryid, alarmactioncategoryrel.Alarmactionid, alarmactioncategoryrel.Siteid);
			if (alarmActionCategoryRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Alarmactioncategoryrel), $"{alarmactioncategoryrel.Alarmactioncategoryid},{alarmactioncategoryrel.Alarmactionid},{alarmactioncategoryrel.Siteid}");
			}
			alarmactioncategoryrel.CopyCommonFieldUpdatePrev(alarmActionCategoryRel4Update, systemTime, dbContext.Tid, text);
			alarmactioncategoryrel.CopyExtensionCollection(alarmActionCategoryRel4Update);
			list.Add(alarmActionCategoryRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
