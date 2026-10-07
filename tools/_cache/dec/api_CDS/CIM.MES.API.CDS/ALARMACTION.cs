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
public class ALARMACTION
{
	private static string _sqlGetAlarmActionSqlDatabase = "SELECT * FROM CIM_ALARMACTION WHERE ALARMACTIONID=@ALARMACTIONID AND SITEID=@SITEID";

	private static string _sqlGetAlarmAction4UpdateSqlDatabase = "SELECT * FROM CIM_ALARMACTION WITH(UPDLOCK) WHERE ALARMACTIONID=@ALARMACTIONID AND SITEID=@SITEID";

	private static string _sqlSelectAlarmActionSqlDatabase = "SELECT * FROM CIM_ALARMACTION WHERE ALARMACTIONID=@ALARMACTIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectAlarmAction4UpdateSqlDatabase = "SELECT * FROM CIM_ALARMACTION WITH(UPDLOCK) WHERE ALARMACTIONID=@ALARMACTIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetAlarmActionOracleDatabase = "SELECT * FROM CIM_ALARMACTION WHERE ALARMACTIONID=:ALARMACTIONID AND SITEID=:SITEID";

	private static string _sqlGetAlarmAction4UpdateOracleDatabase = "SELECT * FROM CIM_ALARMACTION WHERE ALARMACTIONID=:ALARMACTIONID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectAlarmActionOracleDatabase = "SELECT * FROM CIM_ALARMACTION WHERE ALARMACTIONID=:ALARMACTIONID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectAlarmAction4UpdateOracleDatabase = "SELECT * FROM CIM_ALARMACTION WHERE ALARMACTIONID=:ALARMACTIONID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Alarmaction);

	public static Alarmaction GetAlarmAction(IDbContext dbContext, string alarmactionid, string siteid)
	{
		string apiName = "GetAlarmAction";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{alarmactionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetAlarmActionSqlDatabase : _sqlGetAlarmActionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ALARMACTIONID", alarmactionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_ALARMACTION", $"{alarmactionid},{siteid}"));
		}
		IList<Alarmaction> source = ContextManager.DirectEntityQuery<Alarmaction>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{alarmactionid},{siteid}");
		}
		return source.FirstOrDefault();
	}

	public static Alarmaction GetAlarmAction4Update(IDbContext dbContext, string alarmactionid, string siteid)
	{
		string apiName = "GetAlarmAction4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{alarmactionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetAlarmAction4UpdateSqlDatabase : _sqlGetAlarmAction4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ALARMACTIONID", alarmactionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_ALARMACTION", $"{alarmactionid},{siteid}"));
		}
		IList<Alarmaction> source = ContextManager.DirectEntityQuery<Alarmaction>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{alarmactionid},{siteid}");
		}
		return source.FirstOrDefault();
	}

	public static Alarmaction SelectAlarmAction(IDbContext dbContext, string alarmactionid, string siteid)
	{
		string apiName = "SelectAlarmAction";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{alarmactionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectAlarmActionSqlDatabase : _sqlSelectAlarmActionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ALARMACTIONID", alarmactionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_ALARMACTION", $"{alarmactionid},{siteid}"));
		}
		IList<Alarmaction> source = ContextManager.DirectEntityQuery<Alarmaction>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{alarmactionid},{siteid}");
		}
		return source.FirstOrDefault();
	}

	public static Alarmaction SelectAlarmAction4Update(IDbContext dbContext, string alarmactionid, string siteid)
	{
		string apiName = "SelectAlarmAction4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{alarmactionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectAlarmAction4UpdateSqlDatabase : _sqlSelectAlarmAction4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ALARMACTIONID", alarmactionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_ALARMACTION", $"{alarmactionid},{siteid}"));
		}
		IList<Alarmaction> source = ContextManager.DirectEntityQuery<Alarmaction>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{alarmactionid},{siteid}");
		}
		return source.FirstOrDefault();
	}

	public static int UpsertAlarmAction(IDbContext dbContext, RequestType requestType, Alarmaction[] alarmActionList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateAlarmActionInternal(dbContext, alarmActionList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateAlarmAction(dbContext, alarmActionList, optionSet, saveHist), 
			RequestType.DELETE => DeleteAlarmAction(dbContext, alarmActionList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteAlarmAction(dbContext, alarmActionList, optionSet, saveHist), 
			_ => RealDeleteAlarmAction(dbContext, alarmActionList, optionSet, saveHist), 
		};
	}

	private static int CreateAlarmActionInternal(IDbContext dbContext, Alarmaction[] alarmActionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmActionList", alarmActionList);
		string text = "CreateAlarmAction";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarmaction> list = new List<Alarmaction>();
		foreach (Alarmaction obj in alarmActionList)
		{
			Alarmaction alarmaction = new Alarmaction();
			obj.CopyColumsTo(alarmaction);
			alarmaction.Activity = text;
			alarmaction.CheckEntityUsable();
			obj.CopyCommonField(alarmaction, systemTime, dbContext.Tid, isCreate: true);
			list.Add(alarmaction);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateAlarmAction(IDbContext dbContext, Alarmaction[] alarmActionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmActionList", alarmActionList);
		string text = "UpdateAlarmAction";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarmaction> list = new List<Alarmaction>();
		foreach (Alarmaction alarmaction in alarmActionList)
		{
			Alarmaction alarmAction4Update = GetAlarmAction4Update(dbContext, alarmaction.Alarmactionid, alarmaction.Siteid);
			if (alarmAction4Update == null)
			{
				throw new EntityNotFoundException(typeof(Alarmaction), $"{alarmaction.Alarmactionid},{alarmaction.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Alarmaction), $"{alarmaction.Alarmactionid},{alarmaction.Siteid}", alarmAction4Update.Isusable);
			string activity = alarmAction4Update.Activity;
			string customactivity = alarmAction4Update.Customactivity;
			string isusable = alarmAction4Update.Isusable;
			DateTime? createtime = alarmAction4Update.Createtime;
			string creator = alarmAction4Update.Creator;
			alarmaction.CopyColumsTo(alarmAction4Update);
			alarmAction4Update.Prevactivity = activity;
			alarmAction4Update.Prevcustomactivity = customactivity;
			alarmAction4Update.Creator = creator;
			alarmAction4Update.Createtime = createtime;
			alarmAction4Update.Isusable = isusable;
			alarmAction4Update.Activity = text;
			alarmaction.CopyCommonField(alarmAction4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(alarmAction4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteAlarmAction(IDbContext dbContext, Alarmaction[] alarmActionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmActionList", alarmActionList);
		string text = "DeleteAlarmAction";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarmaction> list = new List<Alarmaction>();
		foreach (Alarmaction alarmaction in alarmActionList)
		{
			Alarmaction alarmAction4Update = GetAlarmAction4Update(dbContext, alarmaction.Alarmactionid, alarmaction.Siteid);
			if (alarmAction4Update == null)
			{
				throw new EntityNotFoundException(typeof(Alarmaction), $"{alarmaction.Alarmactionid},{alarmaction.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Alarmaction), $"{alarmaction.Alarmactionid},{alarmaction.Siteid}", alarmAction4Update.Isusable);
			alarmAction4Update.Isusable = "UnUsable";
			alarmaction.CopyCommonFieldUpdatePrev(alarmAction4Update, systemTime, dbContext.Tid, text);
			alarmaction.CopyExtensionCollection(alarmAction4Update);
			list.Add(alarmAction4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteAlarmAction(IDbContext dbContext, Alarmaction[] alarmActionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmActionList", alarmActionList);
		string text = "UnDeleteAlarmAction";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarmaction> list = new List<Alarmaction>();
		foreach (Alarmaction alarmaction in alarmActionList)
		{
			Alarmaction alarmAction4Update = GetAlarmAction4Update(dbContext, alarmaction.Alarmactionid, alarmaction.Siteid);
			if (alarmAction4Update == null)
			{
				throw new EntityNotFoundException(typeof(Alarmaction), $"{alarmaction.Alarmactionid},{alarmaction.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Alarmaction), $"{alarmaction.Alarmactionid},{alarmaction.Siteid}", alarmAction4Update.Isusable);
			alarmAction4Update.Isusable = "Usable";
			alarmaction.CopyCommonFieldUpdatePrev(alarmAction4Update, systemTime, dbContext.Tid, text);
			alarmaction.CopyExtensionCollection(alarmAction4Update);
			list.Add(alarmAction4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteAlarmAction(IDbContext dbContext, Alarmaction[] alarmActionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmActionList", alarmActionList);
		string text = "RealDeleteAlarmAction";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarmaction> list = new List<Alarmaction>();
		foreach (Alarmaction alarmaction in alarmActionList)
		{
			Alarmaction alarmAction4Update = GetAlarmAction4Update(dbContext, alarmaction.Alarmactionid, alarmaction.Siteid);
			if (alarmAction4Update == null)
			{
				throw new EntityNotFoundException(typeof(Alarmaction), $"{alarmaction.Alarmactionid},{alarmaction.Siteid}");
			}
			alarmaction.CopyCommonFieldUpdatePrev(alarmAction4Update, systemTime, dbContext.Tid, text);
			alarmaction.CopyExtensionCollection(alarmAction4Update);
			list.Add(alarmAction4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
