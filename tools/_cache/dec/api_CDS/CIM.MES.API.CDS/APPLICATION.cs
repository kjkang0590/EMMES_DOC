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
public class APPLICATION
{
	private static string _sqlGetApplicationSqlDatabase = "SELECT * FROM CIM_APPLICATION WHERE APPLICATIONID=@APPLICATIONID AND SITEID=@SITEID";

	private static string _sqlGetApplication4UpdateSqlDatabase = "SELECT * FROM CIM_APPLICATION WITH(UPDLOCK) WHERE APPLICATIONID=@APPLICATIONID AND SITEID=@SITEID";

	private static string _sqlSelectApplicationSqlDatabase = "SELECT * FROM CIM_APPLICATION WHERE APPLICATIONID=@APPLICATIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectApplication4UpdateSqlDatabase = "SELECT * FROM CIM_APPLICATION WITH(UPDLOCK) WHERE APPLICATIONID=@APPLICATIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetApplicationOracleDatabase = "SELECT * FROM CIM_APPLICATION WHERE APPLICATIONID=:APPLICATIONID AND SITEID=:SITEID";

	private static string _sqlGetApplication4UpdateOracleDatabase = "SELECT * FROM CIM_APPLICATION WHERE APPLICATIONID=:APPLICATIONID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectApplicationOracleDatabase = "SELECT * FROM CIM_APPLICATION WHERE APPLICATIONID=:APPLICATIONID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectApplication4UpdateOracleDatabase = "SELECT * FROM CIM_APPLICATION WHERE APPLICATIONID=:APPLICATIONID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Application);

	public static Application GetApplication(IDbContext dbContext, string applicationid, string siteid)
	{
		string apiName = "GetApplication";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{applicationid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetApplicationSqlDatabase : _sqlGetApplicationOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("APPLICATIONID", applicationid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_APPLICATION", $"{applicationid},{siteid}"));
		}
		Application? result = ContextManager.DirectEntityQuery<Application>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{applicationid},{siteid}");
		}
		return result;
	}

	public static Application GetApplication4Update(IDbContext dbContext, string applicationid, string siteid)
	{
		string apiName = "GetApplication4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{applicationid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetApplication4UpdateSqlDatabase : _sqlGetApplication4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("APPLICATIONID", applicationid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_APPLICATION", $"{applicationid},{siteid}"));
		}
		Application? result = ContextManager.DirectEntityQuery<Application>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{applicationid},{siteid}");
		}
		return result;
	}

	public static Application SelectApplication(IDbContext dbContext, string applicationid, string siteid)
	{
		string apiName = "SelectApplication";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{applicationid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectApplicationSqlDatabase : _sqlSelectApplicationOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("APPLICATIONID", applicationid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_APPLICATION", $"{applicationid},{siteid}"));
		}
		Application? result = ContextManager.DirectEntityQuery<Application>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{applicationid},{siteid}");
		}
		return result;
	}

	public static Application SelectApplication4Update(IDbContext dbContext, string applicationid, string siteid)
	{
		string apiName = "SelectApplication4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{applicationid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectApplication4UpdateSqlDatabase : _sqlSelectApplication4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("APPLICATIONID", applicationid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_APPLICATION", $"{applicationid},{siteid}"));
		}
		Application? result = ContextManager.DirectEntityQuery<Application>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{applicationid},{siteid}");
		}
		return result;
	}

	public static int UpsertApplication(IDbContext dbContext, RequestType requestType, Application[] applicationList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateApplicationInternal(dbContext, applicationList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateApplication(dbContext, applicationList, optionSet, saveHist), 
			RequestType.DELETE => DeleteApplication(dbContext, applicationList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteApplication(dbContext, applicationList, optionSet, saveHist), 
			_ => RealDeleteApplication(dbContext, applicationList, optionSet, saveHist), 
		};
	}

	private static int CreateApplicationInternal(IDbContext dbContext, Application[] applicationList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("applicationList", applicationList);
		string text = "CreateApplication";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Application> list = new List<Application>();
		foreach (Application obj in applicationList)
		{
			Application application = new Application();
			obj.CopyColumsTo(application);
			application.Activity = text;
			application.CheckEntityUsable();
			obj.CopyCommonField(application, systemTime, dbContext.Tid, isCreate: true);
			list.Add(application);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateApplication(IDbContext dbContext, Application[] applicationList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("applicationList", applicationList);
		string text = "UpdateApplication";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Application> list = new List<Application>();
		foreach (Application application in applicationList)
		{
			Application application4Update = GetApplication4Update(dbContext, application.Applicationid, application.Siteid);
			if (application4Update == null)
			{
				throw new EntityNotFoundException(typeof(Application), $"{application.Applicationid},{application.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Application), $"{application.Applicationid},{application.Siteid}", application4Update.Isusable);
			string activity = application4Update.Activity;
			string customactivity = application4Update.Customactivity;
			string isusable = application4Update.Isusable;
			DateTime? createtime = application4Update.Createtime;
			string creator = application4Update.Creator;
			application.CopyColumsTo(application4Update);
			application4Update.Prevactivity = activity;
			application4Update.Prevcustomactivity = customactivity;
			application4Update.Creator = creator;
			application4Update.Createtime = createtime;
			application4Update.Isusable = isusable;
			application4Update.Activity = text;
			application.CopyCommonField(application4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(application4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteApplication(IDbContext dbContext, Application[] applicationList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("applicationList", applicationList);
		string text = "DeleteApplication";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Application> list = new List<Application>();
		foreach (Application application in applicationList)
		{
			Application application4Update = GetApplication4Update(dbContext, application.Applicationid, application.Siteid);
			if (application4Update == null)
			{
				throw new EntityNotFoundException(typeof(Application), $"{application.Applicationid},{application.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Application), $"{application.Applicationid},{application.Siteid}", application4Update.Isusable);
			application4Update.Isusable = "UnUsable";
			application.CopyCommonFieldUpdatePrev(application4Update, systemTime, dbContext.Tid, text);
			application.CopyExtensionCollection(application4Update);
			list.Add(application4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteApplication(IDbContext dbContext, Application[] applicationList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("applicationList", applicationList);
		string text = "UnDeleteApplication";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Application> list = new List<Application>();
		foreach (Application application in applicationList)
		{
			Application application4Update = GetApplication4Update(dbContext, application.Applicationid, application.Siteid);
			if (application4Update == null)
			{
				throw new EntityNotFoundException(typeof(Application), $"{application.Applicationid},{application.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Application), $"{application.Applicationid},{application.Siteid}", application4Update.Isusable);
			application4Update.Isusable = "Usable";
			application.CopyCommonFieldUpdatePrev(application4Update, systemTime, dbContext.Tid, text);
			application.CopyExtensionCollection(application4Update);
			list.Add(application4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteApplication(IDbContext dbContext, Application[] applicationList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("applicationList", applicationList);
		string text = "RealDeleteApplication";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Application> list = new List<Application>();
		foreach (Application application in applicationList)
		{
			Application application4Update = GetApplication4Update(dbContext, application.Applicationid, application.Siteid);
			if (application4Update == null)
			{
				throw new EntityNotFoundException(typeof(Application), $"{application.Applicationid},{application.Siteid}");
			}
			application.CopyCommonFieldUpdatePrev(application4Update, systemTime, dbContext.Tid, text);
			application.CopyExtensionCollection(application4Update);
			list.Add(application4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
