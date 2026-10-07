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
public class ALARMCLASS
{
	private static string _sqlGetAlarmClassSqlDatabase = "SELECT * FROM CIM_ALARMCLASS WHERE ALARMCLASSID=@ALARMCLASSID AND SITEID=@SITEID";

	private static string _sqlGetAlarmClass4UpdateSqlDatabase = "SELECT * FROM CIM_ALARMCLASS WITH(UPDLOCK) WHERE ALARMCLASSID=@ALARMCLASSID AND SITEID=@SITEID";

	private static string _sqlSelectAlarmClassSqlDatabase = "SELECT * FROM CIM_ALARMCLASS WHERE ALARMCLASSID=@ALARMCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectAlarmClass4UpdateSqlDatabase = "SELECT * FROM CIM_ALARMCLASS WITH(UPDLOCK) WHERE ALARMCLASSID=@ALARMCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetAlarmClassOracleDatabase = "SELECT * FROM CIM_ALARMCLASS WHERE ALARMCLASSID=:ALARMCLASSID AND SITEID=:SITEID";

	private static string _sqlGetAlarmClass4UpdateOracleDatabase = "SELECT * FROM CIM_ALARMCLASS WHERE ALARMCLASSID=:ALARMCLASSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectAlarmClassOracleDatabase = "SELECT * FROM CIM_ALARMCLASS WHERE ALARMCLASSID=:ALARMCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectAlarmClass4UpdateOracleDatabase = "SELECT * FROM CIM_ALARMCLASS WHERE ALARMCLASSID=:ALARMCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Alarmclass);

	public static Alarmclass GetAlarmClass(IDbContext dbContext, string alarmclassid, string siteid)
	{
		string apiName = "GetAlarmClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{alarmclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetAlarmClassSqlDatabase : _sqlGetAlarmClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ALARMCLASSID", alarmclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_ALARMCLASS", $"{alarmclassid},{siteid}"));
		}
		Alarmclass? result = ContextManager.DirectEntityQuery<Alarmclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{alarmclassid},{siteid}");
		}
		return result;
	}

	public static Alarmclass GetAlarmClass4Update(IDbContext dbContext, string alarmclassid, string siteid)
	{
		string apiName = "GetAlarmClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{alarmclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetAlarmClass4UpdateSqlDatabase : _sqlGetAlarmClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ALARMCLASSID", alarmclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_ALARMCLASS", $"{alarmclassid},{siteid}"));
		}
		Alarmclass? result = ContextManager.DirectEntityQuery<Alarmclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{alarmclassid},{siteid}");
		}
		return result;
	}

	public static Alarmclass SelectAlarmClass(IDbContext dbContext, string alarmclassid, string siteid)
	{
		string apiName = "SelectAlarmClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{alarmclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectAlarmClassSqlDatabase : _sqlSelectAlarmClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ALARMCLASSID", alarmclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_ALARMCLASS", $"{alarmclassid},{siteid}"));
		}
		Alarmclass? result = ContextManager.DirectEntityQuery<Alarmclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{alarmclassid},{siteid}");
		}
		return result;
	}

	public static Alarmclass SelectAlarmClass4Update(IDbContext dbContext, string alarmclassid, string siteid)
	{
		string apiName = "SelectAlarmClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{alarmclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectAlarmClass4UpdateSqlDatabase : _sqlSelectAlarmClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ALARMCLASSID", alarmclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_ALARMCLASS", $"{alarmclassid},{siteid}"));
		}
		Alarmclass? result = ContextManager.DirectEntityQuery<Alarmclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{alarmclassid},{siteid}");
		}
		return result;
	}

	public static int UpsertAlarmClass(IDbContext dbContext, RequestType requestType, Alarmclass[] alarmClassList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateAlarmClassInternal(dbContext, alarmClassList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateAlarmClass(dbContext, alarmClassList, optionSet, saveHist), 
			RequestType.DELETE => DeleteAlarmClass(dbContext, alarmClassList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteAlarmClass(dbContext, alarmClassList, optionSet, saveHist), 
			_ => RealDeleteAlarmClass(dbContext, alarmClassList, optionSet, saveHist), 
		};
	}

	private static int CreateAlarmClassInternal(IDbContext dbContext, Alarmclass[] alarmClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmClassList", alarmClassList);
		string text = "CreateAlarmClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarmclass> list = new List<Alarmclass>();
		foreach (Alarmclass obj in alarmClassList)
		{
			Alarmclass alarmclass = new Alarmclass();
			obj.CopyColumsTo(alarmclass);
			alarmclass.Activity = text;
			alarmclass.CheckEntityUsable();
			obj.CopyCommonField(alarmclass, systemTime, dbContext.Tid, isCreate: true);
			list.Add(alarmclass);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateAlarmClass(IDbContext dbContext, Alarmclass[] alarmClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmClassList", alarmClassList);
		string text = "UpdateAlarmClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarmclass> list = new List<Alarmclass>();
		foreach (Alarmclass alarmclass in alarmClassList)
		{
			Alarmclass alarmClass4Update = GetAlarmClass4Update(dbContext, alarmclass.Alarmclassid, alarmclass.Siteid);
			if (alarmClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Alarmclass), $"{alarmclass.Alarmclassid},{alarmclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Alarmclass), $"{alarmclass.Alarmclassid},{alarmclass.Siteid}", alarmClass4Update.Isusable);
			string activity = alarmClass4Update.Activity;
			string customactivity = alarmClass4Update.Customactivity;
			string isusable = alarmClass4Update.Isusable;
			DateTime? createtime = alarmClass4Update.Createtime;
			string creator = alarmClass4Update.Creator;
			alarmclass.CopyColumsTo(alarmClass4Update);
			alarmClass4Update.Prevactivity = activity;
			alarmClass4Update.Prevcustomactivity = customactivity;
			alarmClass4Update.Creator = creator;
			alarmClass4Update.Createtime = createtime;
			alarmClass4Update.Isusable = isusable;
			alarmClass4Update.Activity = text;
			alarmclass.CopyCommonField(alarmClass4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(alarmClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteAlarmClass(IDbContext dbContext, Alarmclass[] alarmClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmClassList", alarmClassList);
		string text = "DeleteAlarmClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarmclass> list = new List<Alarmclass>();
		foreach (Alarmclass alarmclass in alarmClassList)
		{
			Alarmclass alarmClass4Update = GetAlarmClass4Update(dbContext, alarmclass.Alarmclassid, alarmclass.Siteid);
			if (alarmClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Alarmclass), $"{alarmclass.Alarmclassid},{alarmclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Alarmclass), $"{alarmclass.Alarmclassid},{alarmclass.Siteid}", alarmClass4Update.Isusable);
			alarmClass4Update.Isusable = "UnUsable";
			alarmclass.CopyCommonFieldUpdatePrev(alarmClass4Update, systemTime, dbContext.Tid, text);
			alarmclass.CopyExtensionCollection(alarmClass4Update);
			list.Add(alarmClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteAlarmClass(IDbContext dbContext, Alarmclass[] alarmClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmClassList", alarmClassList);
		string text = "UnDeleteAlarmClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarmclass> list = new List<Alarmclass>();
		foreach (Alarmclass alarmclass in alarmClassList)
		{
			Alarmclass alarmClass4Update = GetAlarmClass4Update(dbContext, alarmclass.Alarmclassid, alarmclass.Siteid);
			if (alarmClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Alarmclass), $"{alarmclass.Alarmclassid},{alarmclass.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Alarmclass), $"{alarmclass.Alarmclassid},{alarmclass.Siteid}", alarmClass4Update.Isusable);
			alarmClass4Update.Isusable = "Usable";
			alarmclass.CopyCommonFieldUpdatePrev(alarmClass4Update, systemTime, dbContext.Tid, text);
			alarmclass.CopyExtensionCollection(alarmClass4Update);
			list.Add(alarmClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteAlarmClass(IDbContext dbContext, Alarmclass[] alarmClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmClassList", alarmClassList);
		string text = "RealDeleteAlarmClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarmclass> list = new List<Alarmclass>();
		foreach (Alarmclass alarmclass in alarmClassList)
		{
			Alarmclass alarmClass4Update = GetAlarmClass4Update(dbContext, alarmclass.Alarmclassid, alarmclass.Siteid);
			if (alarmClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Alarmclass), $"{alarmclass.Alarmclassid},{alarmclass.Siteid}");
			}
			alarmclass.CopyCommonFieldUpdatePrev(alarmClass4Update, systemTime, dbContext.Tid, text);
			alarmclass.CopyExtensionCollection(alarmClass4Update);
			list.Add(alarmClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
