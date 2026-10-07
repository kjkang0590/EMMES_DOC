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
public class DEFECTCLASS
{
	private static string _sqlGetDefectClassSqlDatabase = "SELECT * FROM CIM_DEFECTCLASS WHERE DEFECTCLASSID=@DEFECTCLASSID AND SITEID=@SITEID";

	private static string _sqlGetDefectClass4UpdateSqlDatabase = "SELECT * FROM CIM_DEFECTCLASS WITH(UPDLOCK) WHERE DEFECTCLASSID=@DEFECTCLASSID AND SITEID=@SITEID";

	private static string _sqlSelectDefectClassSqlDatabase = "SELECT * FROM CIM_DEFECTCLASS WHERE DEFECTCLASSID=@DEFECTCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectDefectClass4UpdateSqlDatabase = "SELECT * FROM CIM_DEFECTCLASS WITH(UPDLOCK) WHERE DEFECTCLASSID=@DEFECTCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetDefectClassOracleDatabase = "SELECT * FROM CIM_DEFECTCLASS WHERE DEFECTCLASSID=:DEFECTCLASSID AND SITEID=:SITEID";

	private static string _sqlGetDefectClass4UpdateOracleDatabase = "SELECT * FROM CIM_DEFECTCLASS WHERE DEFECTCLASSID=:DEFECTCLASSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectDefectClassOracleDatabase = "SELECT * FROM CIM_DEFECTCLASS WHERE DEFECTCLASSID=:DEFECTCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectDefectClass4UpdateOracleDatabase = "SELECT * FROM CIM_DEFECTCLASS WHERE DEFECTCLASSID=:DEFECTCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Defectclass);

	public static Defectclass GetDefectClass(IDbContext dbContext, string defectclassid, string siteid)
	{
		string apiName = "GetDefectClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{defectclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetDefectClassSqlDatabase : _sqlGetDefectClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DEFECTCLASSID", defectclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_DEFECTCLASS", $"{defectclassid},{siteid}"));
		}
		Defectclass? result = ContextManager.DirectEntityQuery<Defectclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{defectclassid},{siteid}");
		}
		return result;
	}

	public static Defectclass GetDefectClass4Update(IDbContext dbContext, string defectclassid, string siteid)
	{
		string apiName = "GetDefectClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{defectclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetDefectClass4UpdateSqlDatabase : _sqlGetDefectClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DEFECTCLASSID", defectclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_DEFECTCLASS", $"{defectclassid},{siteid}"));
		}
		Defectclass? result = ContextManager.DirectEntityQuery<Defectclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{defectclassid},{siteid}");
		}
		return result;
	}

	public static Defectclass SelectDefectClass(IDbContext dbContext, string defectclassid, string siteid)
	{
		string apiName = "SelectDefectClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{defectclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectDefectClassSqlDatabase : _sqlSelectDefectClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DEFECTCLASSID", defectclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_DEFECTCLASS", $"{defectclassid},{siteid}"));
		}
		Defectclass? result = ContextManager.DirectEntityQuery<Defectclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{defectclassid},{siteid}");
		}
		return result;
	}

	public static Defectclass SelectDefectClass4Update(IDbContext dbContext, string defectclassid, string siteid)
	{
		string apiName = "SelectDefectClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{defectclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectDefectClass4UpdateSqlDatabase : _sqlSelectDefectClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DEFECTCLASSID", defectclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_DEFECTCLASS", $"{defectclassid},{siteid}"));
		}
		Defectclass? result = ContextManager.DirectEntityQuery<Defectclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{defectclassid},{siteid}");
		}
		return result;
	}

	public static int UpsertDefectClass(IDbContext dbContext, RequestType requestType, Defectclass[] defectClassList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateDefectClassInternal(dbContext, defectClassList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateDefectClass(dbContext, defectClassList, optionSet, saveHist), 
			RequestType.DELETE => DeleteDefectClass(dbContext, defectClassList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteDefectClass(dbContext, defectClassList, optionSet, saveHist), 
			_ => RealDeleteDefectClass(dbContext, defectClassList, optionSet, saveHist), 
		};
	}

	private static int CreateDefectClassInternal(IDbContext dbContext, Defectclass[] defectClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("defectClassList", defectClassList);
		string text = "CreateDefectClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Defectclass> list = new List<Defectclass>();
		foreach (Defectclass obj in defectClassList)
		{
			Defectclass defectclass = new Defectclass();
			obj.CopyColumsTo(defectclass);
			defectclass.Activity = text;
			defectclass.CheckEntityUsable();
			obj.CopyCommonField(defectclass, systemTime, dbContext.Tid, isCreate: true);
			list.Add(defectclass);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateDefectClass(IDbContext dbContext, Defectclass[] defectClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("defectClassList", defectClassList);
		string text = "UpdateDefectClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Defectclass> list = new List<Defectclass>();
		foreach (Defectclass defectclass in defectClassList)
		{
			Defectclass defectClass4Update = GetDefectClass4Update(dbContext, defectclass.Defectclassid, defectclass.Siteid);
			if (defectClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Defectclass), $"{defectclass.Defectclassid},{defectclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Defectclass), $"{defectclass.Defectclassid},{defectclass.Siteid}", defectClass4Update.Isusable);
			string activity = defectClass4Update.Activity;
			string customactivity = defectClass4Update.Customactivity;
			string isusable = defectClass4Update.Isusable;
			DateTime? createtime = defectClass4Update.Createtime;
			string creator = defectClass4Update.Creator;
			defectclass.CopyColumsTo(defectClass4Update);
			defectClass4Update.Prevactivity = activity;
			defectClass4Update.Prevcustomactivity = customactivity;
			defectClass4Update.Creator = creator;
			defectClass4Update.Createtime = createtime;
			defectClass4Update.Isusable = isusable;
			defectClass4Update.Activity = text;
			defectclass.CopyCommonField(defectClass4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(defectClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteDefectClass(IDbContext dbContext, Defectclass[] defectClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("defectClassList", defectClassList);
		string text = "DeleteDefectClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Defectclass> list = new List<Defectclass>();
		foreach (Defectclass defectclass in defectClassList)
		{
			Defectclass defectClass4Update = GetDefectClass4Update(dbContext, defectclass.Defectclassid, defectclass.Siteid);
			if (defectClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Defectclass), $"{defectclass.Defectclassid},{defectclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Defectclass), $"{defectclass.Defectclassid},{defectclass.Siteid}", defectClass4Update.Isusable);
			defectClass4Update.Isusable = "UnUsable";
			defectclass.CopyCommonFieldUpdatePrev(defectClass4Update, systemTime, dbContext.Tid, text);
			defectclass.CopyExtensionCollection(defectClass4Update);
			list.Add(defectClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteDefectClass(IDbContext dbContext, Defectclass[] defectClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("defectClassList", defectClassList);
		string text = "UnDeleteDefectClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Defectclass> list = new List<Defectclass>();
		foreach (Defectclass defectclass in defectClassList)
		{
			Defectclass defectClass4Update = GetDefectClass4Update(dbContext, defectclass.Defectclassid, defectclass.Siteid);
			if (defectClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Defectclass), $"{defectclass.Defectclassid},{defectclass.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Defectclass), $"{defectclass.Defectclassid},{defectclass.Siteid}", defectClass4Update.Isusable);
			defectClass4Update.Isusable = "Usable";
			defectclass.CopyCommonFieldUpdatePrev(defectClass4Update, systemTime, dbContext.Tid, text);
			defectclass.CopyExtensionCollection(defectClass4Update);
			list.Add(defectClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteDefectClass(IDbContext dbContext, Defectclass[] defectClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("defectClassList", defectClassList);
		string text = "RealDeleteDefectClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Defectclass> list = new List<Defectclass>();
		foreach (Defectclass defectclass in defectClassList)
		{
			Defectclass defectClass4Update = GetDefectClass4Update(dbContext, defectclass.Defectclassid, defectclass.Siteid);
			if (defectClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Defectclass), $"{defectclass.Defectclassid},{defectclass.Siteid}");
			}
			defectclass.CopyCommonFieldUpdatePrev(defectClass4Update, systemTime, dbContext.Tid, text);
			defectclass.CopyExtensionCollection(defectClass4Update);
			list.Add(defectClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
