using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.RDS;

[MESAPI]
public class SPARTCLASS
{
	private static string _sqlGetSpartClassSqlDatabase = "SELECT * FROM CIM_SPARTCLASS WHERE SPARTCLASSID=@SPARTCLASSID AND SITEID=@SITEID";

	private static string _sqlGetSpartClass4UpdateSqlDatabase = "SELECT * FROM CIM_SPARTCLASS WITH(UPDLOCK) WHERE SPARTCLASSID=@SPARTCLASSID AND SITEID=@SITEID";

	private static string _sqlSelectSpartClassSqlDatabase = "SELECT * FROM CIM_SPARTCLASS WHERE SPARTCLASSID=@SPARTCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectSpartClass4UpdateSqlDatabase = "SELECT * FROM CIM_SPARTCLASS WITH(UPDLOCK) WHERE SPARTCLASSID=@SPARTCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetSpartClassOracleDatabase = "SELECT * FROM CIM_SPARTCLASS WHERE SPARTCLASSID=:SPARTCLASSID AND SITEID=:SITEID";

	private static string _sqlGetSpartClass4UpdateOracleDatabase = "SELECT * FROM CIM_SPARTCLASS WHERE SPARTCLASSID=:SPARTCLASSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectSpartClassOracleDatabase = "SELECT * FROM CIM_SPARTCLASS WHERE SPARTCLASSID=:SPARTCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectSpartClass4UpdateOracleDatabase = "SELECT * FROM CIM_SPARTCLASS WHERE SPARTCLASSID=:SPARTCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Spartclass);

	public static Spartclass GetSpartClass(IDbContext dbContext, string spartclassid, string siteid)
	{
		string apiName = "GetSpartClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{spartclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetSpartClassSqlDatabase : _sqlGetSpartClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SPARTCLASSID", spartclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SPARTCLASS", $"{spartclassid},{siteid}"));
		}
		Spartclass? result = ContextManager.DirectEntityQuery<Spartclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{spartclassid},{siteid}");
		}
		return result;
	}

	public static Spartclass GetSpartClass4Update(IDbContext dbContext, string spartclassid, string siteid)
	{
		string apiName = "GetSpartClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{spartclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetSpartClass4UpdateSqlDatabase : _sqlGetSpartClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SPARTCLASSID", spartclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_SPARTCLASS", $"{spartclassid},{siteid}"));
		}
		Spartclass? result = ContextManager.DirectEntityQuery<Spartclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{spartclassid},{siteid}");
		}
		return result;
	}

	public static Spartclass SelectSpartClass(IDbContext dbContext, string spartclassid, string siteid)
	{
		string apiName = "SelectSpartClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{spartclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectSpartClassSqlDatabase : _sqlSelectSpartClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SPARTCLASSID", spartclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SPARTCLASS", $"{spartclassid},{siteid}"));
		}
		Spartclass? result = ContextManager.DirectEntityQuery<Spartclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{spartclassid},{siteid}");
		}
		return result;
	}

	public static Spartclass SelectSpartClass4Update(IDbContext dbContext, string spartclassid, string siteid)
	{
		string apiName = "SelectSpartClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{spartclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectSpartClass4UpdateSqlDatabase : _sqlSelectSpartClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SPARTCLASSID", spartclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_SPARTCLASS", $"{spartclassid},{siteid}"));
		}
		Spartclass? result = ContextManager.DirectEntityQuery<Spartclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{spartclassid},{siteid}");
		}
		return result;
	}

	public static int UpsertSpartClass(IDbContext dbContext, RequestType requestType, Spartclass[] spartClassList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateSpartClassInternal(dbContext, spartClassList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateSpartClass(dbContext, spartClassList, optionSet, saveHist), 
			RequestType.DELETE => DeleteSpartClass(dbContext, spartClassList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteSpartClass(dbContext, spartClassList, optionSet, saveHist), 
			_ => RealDeleteSpartClass(dbContext, spartClassList, optionSet, saveHist), 
		};
	}

	private static int CreateSpartClassInternal(IDbContext dbContext, Spartclass[] spartClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spartClassList", spartClassList);
		string text = "CreateSpartClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spartclass> list = new List<Spartclass>();
		foreach (Spartclass obj in spartClassList)
		{
			Spartclass spartclass = new Spartclass();
			obj.CopyColumsTo(spartclass);
			spartclass.Activity = text;
			spartclass.CheckEntityUsable();
			obj.CopyCommonField(spartclass, systemTime, dbContext.Tid, isCreate: true);
			list.Add(spartclass);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateSpartClass(IDbContext dbContext, Spartclass[] spartClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spartClassList", spartClassList);
		string text = "UpdateSpartClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spartclass> list = new List<Spartclass>();
		foreach (Spartclass spartclass in spartClassList)
		{
			Spartclass spartClass4Update = GetSpartClass4Update(dbContext, spartclass.Spartclassid, spartclass.Siteid);
			if (spartClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Spartclass), $"{spartclass.Spartclassid},{spartclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Spartclass), $"{spartclass.Spartclassid},{spartclass.Siteid}", spartClass4Update.Isusable);
			string activity = spartClass4Update.Activity;
			string customactivity = spartClass4Update.Customactivity;
			string isusable = spartClass4Update.Isusable;
			DateTime? createtime = spartClass4Update.Createtime;
			string creator = spartClass4Update.Creator;
			spartclass.CopyColumsTo(spartClass4Update);
			spartClass4Update.Prevactivity = activity;
			spartClass4Update.Prevcustomactivity = customactivity;
			spartClass4Update.Creator = creator;
			spartClass4Update.Createtime = createtime;
			spartClass4Update.Isusable = isusable;
			spartClass4Update.Activity = text;
			spartclass.CopyCommonField(spartClass4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(spartClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteSpartClass(IDbContext dbContext, Spartclass[] spartClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spartClassList", spartClassList);
		string text = "DeleteSpartClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spartclass> list = new List<Spartclass>();
		foreach (Spartclass spartclass in spartClassList)
		{
			Spartclass spartClass4Update = GetSpartClass4Update(dbContext, spartclass.Spartclassid, spartclass.Siteid);
			if (spartClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Spartclass), $"{spartclass.Spartclassid},{spartclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Spartclass), $"{spartclass.Spartclassid},{spartclass.Siteid}", spartClass4Update.Isusable);
			spartClass4Update.Isusable = "UnUsable";
			spartclass.CopyCommonFieldUpdatePrev(spartClass4Update, systemTime, dbContext.Tid, text);
			spartclass.CopyExtensionCollection(spartClass4Update);
			list.Add(spartClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteSpartClass(IDbContext dbContext, Spartclass[] spartClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spartClassList", spartClassList);
		string text = "UnDeleteSpartClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spartclass> list = new List<Spartclass>();
		foreach (Spartclass spartclass in spartClassList)
		{
			Spartclass spartClass4Update = GetSpartClass4Update(dbContext, spartclass.Spartclassid, spartclass.Siteid);
			if (spartClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Spartclass), $"{spartclass.Spartclassid},{spartclass.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Spartclass), $"{spartclass.Spartclassid},{spartclass.Siteid}", spartClass4Update.Isusable);
			spartClass4Update.Isusable = "Usable";
			spartclass.CopyCommonFieldUpdatePrev(spartClass4Update, systemTime, dbContext.Tid, text);
			spartclass.CopyExtensionCollection(spartClass4Update);
			list.Add(spartClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteSpartClass(IDbContext dbContext, Spartclass[] spartClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spartClassList", spartClassList);
		string text = "RealDeleteSpartClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spartclass> list = new List<Spartclass>();
		foreach (Spartclass spartclass in spartClassList)
		{
			Spartclass spartClass4Update = GetSpartClass4Update(dbContext, spartclass.Spartclassid, spartclass.Siteid);
			if (spartClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Spartclass), $"{spartclass.Spartclassid},{spartclass.Siteid}");
			}
			spartclass.CopyCommonFieldUpdatePrev(spartClass4Update, systemTime, dbContext.Tid, text);
			spartclass.CopyExtensionCollection(spartClass4Update);
			list.Add(spartClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
