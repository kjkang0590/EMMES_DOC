using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.POS;

[MESAPI]
public class EVENTLOG
{
	private static string _sqlGetEventLogSqlDatabase = "SELECT * FROM CIM_EVENTLOG WHERE TRACETYPE=@TRACETYPE AND BIZID=@BIZID AND EVENTID=@EVENTID AND SITEID=@SITEID";

	private static string _sqlGetEventLog4UpdateSqlDatabase = "SELECT * FROM CIM_EVENTLOG WITH(UPDLOCK) WHERE TRACETYPE=@TRACETYPE AND BIZID=@BIZID AND EVENTID=@EVENTID AND SITEID=@SITEID";

	private static string _sqlSelectEventLogSqlDatabase = "SELECT * FROM CIM_EVENTLOG WHERE TRACETYPE=@TRACETYPE AND BIZID=@BIZID AND EVENTID=@EVENTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectEventLog4UpdateSqlDatabase = "SELECT * FROM CIM_EVENTLOG WITH(UPDLOCK) WHERE TRACETYPE=@TRACETYPE AND BIZID=@BIZID AND EVENTID=@EVENTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetEventLogOracleDatabase = "SELECT * FROM CIM_EVENTLOG WHERE TRACETYPE=:TRACETYPE AND BIZID=:BIZID AND EVENTID=:EVENTID AND SITEID=:SITEID";

	private static string _sqlGetEventLog4UpdateOracleDatabase = "SELECT * FROM CIM_EVENTLOG WHERE TRACETYPE=:TRACETYPE AND BIZID=:BIZID AND EVENTID=:EVENTID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectEventLogOracleDatabase = "SELECT * FROM CIM_EVENTLOG WHERE TRACETYPE=:TRACETYPE AND BIZID=:BIZID AND EVENTID=:EVENTID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectEventLog4UpdateOracleDatabase = "SELECT * FROM CIM_EVENTLOG WHERE TRACETYPE=:TRACETYPE AND BIZID=:BIZID AND EVENTID=:EVENTID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Eventlog);

	private static string _sqlSelectEventLogListSqlDatabase = "SELECT * FROM CIM_EVENTLOG WHERE TRACETYPE=@TRACETYPE AND BIZID=@BIZID AND SITEID=@SITEID";

	private static string _sqlSelectEventLogListOracleDatabase = "SELECT * FROM CIM_EVENTLOG WHERE TRACETYPE=:TRACETYPE AND BIZID=:BIZID AND SITEID=:SITEID";

	public static Eventlog GetEventLog(IDbContext dbContext, string tracetype, string bizid, string eventid, string siteid)
	{
		string apiName = "GetEventLog";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tracetype},{bizid},{eventid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetEventLogSqlDatabase : _sqlGetEventLogOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TRACETYPE", tracetype, typeOfThis));
		list.Add(dbContext.CreateParameter("BIZID", bizid, typeOfThis));
		list.Add(dbContext.CreateParameter("EVENTID", eventid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_EVENTLOG", $"{tracetype},{bizid},{eventid},{siteid}"));
		}
		Eventlog result = ContextManager.DirectEntityQuery<Eventlog>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tracetype},{bizid},{eventid},{siteid}");
		}
		return result;
	}

	public static Eventlog GetEventLog4Update(IDbContext dbContext, string tracetype, string bizid, string eventid, string siteid)
	{
		string apiName = "GetEventLog4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tracetype},{bizid},{eventid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetEventLog4UpdateSqlDatabase : _sqlGetEventLog4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TRACETYPE", tracetype, typeOfThis));
		list.Add(dbContext.CreateParameter("BIZID", bizid, typeOfThis));
		list.Add(dbContext.CreateParameter("EVENTID", eventid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_EVENTLOG", $"{tracetype},{bizid},{eventid},{siteid}"));
		}
		Eventlog result = ContextManager.DirectEntityQuery<Eventlog>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tracetype},{bizid},{eventid},{siteid}");
		}
		return result;
	}

	public static Eventlog SelectEventLog(IDbContext dbContext, string tracetype, string bizid, string eventid, string siteid)
	{
		string apiName = "SelectEventLog";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tracetype},{bizid},{eventid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectEventLogSqlDatabase : _sqlSelectEventLogOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TRACETYPE", tracetype, typeOfThis));
		list.Add(dbContext.CreateParameter("BIZID", bizid, typeOfThis));
		list.Add(dbContext.CreateParameter("EVENTID", eventid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_EVENTLOG", $"{tracetype},{bizid},{eventid},{siteid}"));
		}
		Eventlog result = ContextManager.DirectEntityQuery<Eventlog>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tracetype},{bizid},{eventid},{siteid}");
		}
		return result;
	}

	public static Eventlog SelectEventLog4Update(IDbContext dbContext, string tracetype, string bizid, string eventid, string siteid)
	{
		string apiName = "SelectEventLog4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tracetype},{bizid},{eventid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectEventLog4UpdateSqlDatabase : _sqlSelectEventLog4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TRACETYPE", tracetype, typeOfThis));
		list.Add(dbContext.CreateParameter("BIZID", bizid, typeOfThis));
		list.Add(dbContext.CreateParameter("EVENTID", eventid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_EVENTLOG", $"{tracetype},{bizid},{eventid},{siteid}"));
		}
		Eventlog result = ContextManager.DirectEntityQuery<Eventlog>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tracetype},{bizid},{eventid},{siteid}");
		}
		return result;
	}

	public static int UpsertEventLog(IDbContext dbContext, RequestType requestType, Eventlog[] eventLogList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateEventLogInternal(dbContext, eventLogList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateEventLog(dbContext, eventLogList, optionSet, saveHist), 
			RequestType.DELETE => DeleteEventLog(dbContext, eventLogList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteEventLog(dbContext, eventLogList, optionSet, saveHist), 
			_ => RealDeleteEventLog(dbContext, eventLogList, optionSet, saveHist), 
		};
	}

	private static int CreateEventLogInternal(IDbContext dbContext, Eventlog[] eventLogList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("eventLogList", eventLogList);
		string text = "CreateEventLog";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Eventlog> list = new List<Eventlog>();
		foreach (Eventlog obj in eventLogList)
		{
			Eventlog eventlog = new Eventlog();
			obj.CopyColumsTo(eventlog);
			eventlog.Activity = text;
			eventlog.CheckEntityUsable();
			obj.CopyCommonField(eventlog, systemTime, dbContext.Tid, isCreate: true);
			list.Add(eventlog);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateEventLog(IDbContext dbContext, Eventlog[] eventLogList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("eventLogList", eventLogList);
		string text = "UpdateEventLog";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Eventlog> list = new List<Eventlog>();
		foreach (Eventlog eventlog in eventLogList)
		{
			Eventlog eventLog4Update = GetEventLog4Update(dbContext, eventlog.Tracetype, eventlog.Bizid, eventlog.Eventid, eventlog.Siteid);
			if (eventLog4Update == null)
			{
				throw new EntityNotFoundException(typeof(Eventlog), $"{eventlog.Tracetype},{eventlog.Bizid},{eventlog.Eventid},{eventlog.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Eventlog), $"{eventlog.Tracetype},{eventlog.Bizid},{eventlog.Eventid},{eventlog.Siteid}", eventLog4Update.Isusable);
			string activity = eventLog4Update.Activity;
			string customactivity = eventLog4Update.Customactivity;
			string isusable = eventLog4Update.Isusable;
			DateTime? createtime = eventLog4Update.Createtime;
			string creator = eventLog4Update.Creator;
			eventlog.CopyColumsTo(eventLog4Update);
			eventLog4Update.Prevactivity = activity;
			eventLog4Update.Prevcustomactivity = customactivity;
			eventLog4Update.Creator = creator;
			eventLog4Update.Createtime = createtime;
			eventLog4Update.Isusable = isusable;
			eventLog4Update.Activity = text;
			eventlog.CopyCommonField(eventLog4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(eventLog4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteEventLog(IDbContext dbContext, Eventlog[] eventLogList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("eventLogList", eventLogList);
		string text = "DeleteEventLog";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Eventlog> list = new List<Eventlog>();
		foreach (Eventlog eventlog in eventLogList)
		{
			Eventlog eventLog4Update = GetEventLog4Update(dbContext, eventlog.Tracetype, eventlog.Bizid, eventlog.Eventid, eventlog.Siteid);
			if (eventLog4Update == null)
			{
				throw new EntityNotFoundException(typeof(Eventlog), $"{eventlog.Tracetype},{eventlog.Bizid},{eventlog.Eventid},{eventlog.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Eventlog), $"{eventlog.Tracetype},{eventlog.Bizid},{eventlog.Eventid},{eventlog.Siteid}", eventLog4Update.Isusable);
			eventLog4Update.Isusable = "UnUsable";
			eventlog.CopyCommonFieldUpdatePrev(eventLog4Update, systemTime, dbContext.Tid, text);
			eventlog.CopyExtensionCollection(eventLog4Update);
			list.Add(eventLog4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteEventLog(IDbContext dbContext, Eventlog[] eventLogList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("eventLogList", eventLogList);
		string text = "UnDeleteEventLog";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Eventlog> list = new List<Eventlog>();
		foreach (Eventlog eventlog in eventLogList)
		{
			Eventlog eventLog4Update = GetEventLog4Update(dbContext, eventlog.Tracetype, eventlog.Bizid, eventlog.Eventid, eventlog.Siteid);
			if (eventLog4Update == null)
			{
				throw new EntityNotFoundException(typeof(Eventlog), $"{eventlog.Tracetype},{eventlog.Bizid},{eventlog.Eventid},{eventlog.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Eventlog), $"{eventlog.Tracetype},{eventlog.Bizid},{eventlog.Eventid},{eventlog.Siteid}", eventLog4Update.Isusable);
			eventLog4Update.Isusable = "Usable";
			eventlog.CopyCommonFieldUpdatePrev(eventLog4Update, systemTime, dbContext.Tid, text);
			eventlog.CopyExtensionCollection(eventLog4Update);
			list.Add(eventLog4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteEventLog(IDbContext dbContext, Eventlog[] eventLogList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("eventLogList", eventLogList);
		string text = "RealDeleteEventLog";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Eventlog> list = new List<Eventlog>();
		foreach (Eventlog eventlog in eventLogList)
		{
			Eventlog eventLog4Update = GetEventLog4Update(dbContext, eventlog.Tracetype, eventlog.Bizid, eventlog.Eventid, eventlog.Siteid);
			if (eventLog4Update == null)
			{
				throw new EntityNotFoundException(typeof(Eventlog), $"{eventlog.Tracetype},{eventlog.Bizid},{eventlog.Eventid},{eventlog.Siteid}");
			}
			eventlog.CopyCommonFieldUpdatePrev(eventLog4Update, systemTime, dbContext.Tid, text);
			eventlog.CopyExtensionCollection(eventLog4Update);
			list.Add(eventLog4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static IList<Eventlog> SelectEventLogList(IDbContext dbContext, string traceType, string bizId, string siteId)
	{
		string apiName = "SelectEventLogList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{traceType},{bizId},{siteId}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectEventLogListSqlDatabase : _sqlSelectEventLogListOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TRACETYPE", traceType, typeOfThis));
		list.Add(dbContext.CreateParameter("BIZID", bizId, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		IList<Eventlog> result = ContextManager.DirectEntityQuery<Eventlog>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{traceType},{bizId},{siteId}");
		}
		return result;
	}
}
