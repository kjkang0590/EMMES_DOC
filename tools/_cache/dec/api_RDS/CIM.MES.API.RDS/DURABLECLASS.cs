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
public class DURABLECLASS
{
	private static string _sqlGetDurableClassSqlDatabase = "SELECT * FROM CIM_DURABLECLASS WHERE DURABLECLASSID=@DURABLECLASSID AND SITEID=@SITEID";

	private static string _sqlGetDurableClass4UpdateSqlDatabase = "SELECT * FROM CIM_DURABLECLASS WITH(UPDLOCK) WHERE DURABLECLASSID=@DURABLECLASSID AND SITEID=@SITEID";

	private static string _sqlSelectDurableClassSqlDatabase = "SELECT * FROM CIM_DURABLECLASS WHERE DURABLECLASSID=@DURABLECLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectDurableClass4UpdateSqlDatabase = "SELECT * FROM CIM_DURABLECLASS WITH(UPDLOCK) WHERE DURABLECLASSID=@DURABLECLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetDurableClassOracleDatabase = "SELECT * FROM CIM_DURABLECLASS WHERE DURABLECLASSID=:DURABLECLASSID AND SITEID=:SITEID";

	private static string _sqlGetDurableClass4UpdateOracleDatabase = "SELECT * FROM CIM_DURABLECLASS WHERE DURABLECLASSID=:DURABLECLASSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectDurableClassOracleDatabase = "SELECT * FROM CIM_DURABLECLASS WHERE DURABLECLASSID=:DURABLECLASSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectDurableClass4UpdateOracleDatabase = "SELECT * FROM CIM_DURABLECLASS WHERE DURABLECLASSID=:DURABLECLASSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Durableclass);

	public static Durableclass GetDurableClass(IDbContext dbContext, string durableclassid, string siteid)
	{
		string apiName = "GetDurableClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{durableclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetDurableClassSqlDatabase : _sqlGetDurableClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DURABLECLASSID", durableclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_DURABLECLASS", $"{durableclassid},{siteid}"));
		}
		Durableclass? result = ContextManager.DirectEntityQuery<Durableclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{durableclassid},{siteid}");
		}
		return result;
	}

	public static Durableclass GetDurableClass4Update(IDbContext dbContext, string durableclassid, string siteid)
	{
		string apiName = "GetDurableClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{durableclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetDurableClass4UpdateSqlDatabase : _sqlGetDurableClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DURABLECLASSID", durableclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_DURABLECLASS", $"{durableclassid},{siteid}"));
		}
		Durableclass? result = ContextManager.DirectEntityQuery<Durableclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{durableclassid},{siteid}");
		}
		return result;
	}

	public static Durableclass SelectDurableClass(IDbContext dbContext, string durableclassid, string siteid)
	{
		string apiName = "SelectDurableClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{durableclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectDurableClassSqlDatabase : _sqlSelectDurableClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DURABLECLASSID", durableclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_DURABLECLASS", $"{durableclassid},{siteid}"));
		}
		Durableclass? result = ContextManager.DirectEntityQuery<Durableclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{durableclassid},{siteid}");
		}
		return result;
	}

	public static Durableclass SelectDurableClass4Update(IDbContext dbContext, string durableclassid, string siteid)
	{
		string apiName = "SelectDurableClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{durableclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectDurableClass4UpdateSqlDatabase : _sqlSelectDurableClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DURABLECLASSID", durableclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_DURABLECLASS", $"{durableclassid},{siteid}"));
		}
		Durableclass? result = ContextManager.DirectEntityQuery<Durableclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{durableclassid},{siteid}");
		}
		return result;
	}

	public static int UpsertDurableClass(IDbContext dbContext, RequestType requestType, Durableclass[] durableClassList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateDurableClassInternal(dbContext, durableClassList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateDurableClass(dbContext, durableClassList, optionSet, saveHist), 
			RequestType.DELETE => DeleteDurableClass(dbContext, durableClassList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteDurableClass(dbContext, durableClassList, optionSet, saveHist), 
			_ => RealDeleteDurableClass(dbContext, durableClassList, optionSet, saveHist), 
		};
	}

	private static int CreateDurableClassInternal(IDbContext dbContext, Durableclass[] durableClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("durableClassList", durableClassList);
		string text = "CreateDurableClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Durableclass> list = new List<Durableclass>();
		foreach (Durableclass obj in durableClassList)
		{
			Durableclass durableclass = new Durableclass();
			obj.CopyColumsTo(durableclass);
			durableclass.Activity = text;
			durableclass.CheckEntityUsable();
			obj.CopyCommonField(durableclass, systemTime, dbContext.Tid, isCreate: true);
			list.Add(durableclass);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateDurableClass(IDbContext dbContext, Durableclass[] durableClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("durableClassList", durableClassList);
		string text = "UpdateDurableClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Durableclass> list = new List<Durableclass>();
		foreach (Durableclass durableclass in durableClassList)
		{
			Durableclass durableClass4Update = GetDurableClass4Update(dbContext, durableclass.Durableclassid, durableclass.Siteid);
			if (durableClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Durableclass), $"{durableclass.Durableclassid},{durableclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Durableclass), $"{durableclass.Durableclassid},{durableclass.Siteid}", durableClass4Update.Isusable);
			string activity = durableClass4Update.Activity;
			string customactivity = durableClass4Update.Customactivity;
			string isusable = durableClass4Update.Isusable;
			DateTime? createtime = durableClass4Update.Createtime;
			string creator = durableClass4Update.Creator;
			durableclass.CopyColumsTo(durableClass4Update);
			durableClass4Update.Prevactivity = activity;
			durableClass4Update.Prevcustomactivity = customactivity;
			durableClass4Update.Creator = creator;
			durableClass4Update.Createtime = createtime;
			durableClass4Update.Isusable = isusable;
			durableClass4Update.Activity = text;
			durableclass.CopyCommonField(durableClass4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(durableClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteDurableClass(IDbContext dbContext, Durableclass[] durableClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("durableClassList", durableClassList);
		string text = "DeleteDurableClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Durableclass> list = new List<Durableclass>();
		foreach (Durableclass durableclass in durableClassList)
		{
			Durableclass durableClass4Update = GetDurableClass4Update(dbContext, durableclass.Durableclassid, durableclass.Siteid);
			if (durableClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Durableclass), $"{durableclass.Durableclassid},{durableclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Durableclass), $"{durableclass.Durableclassid},{durableclass.Siteid}", durableClass4Update.Isusable);
			durableClass4Update.Isusable = "UnUsable";
			durableclass.CopyCommonFieldUpdatePrev(durableClass4Update, systemTime, dbContext.Tid, text);
			durableclass.CopyExtensionCollection(durableClass4Update);
			list.Add(durableClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteDurableClass(IDbContext dbContext, Durableclass[] durableClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("durableClassList", durableClassList);
		string text = "UnDeleteDurableClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Durableclass> list = new List<Durableclass>();
		foreach (Durableclass durableclass in durableClassList)
		{
			Durableclass durableClass4Update = GetDurableClass4Update(dbContext, durableclass.Durableclassid, durableclass.Siteid);
			if (durableClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Durableclass), $"{durableclass.Durableclassid},{durableclass.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Durableclass), $"{durableclass.Durableclassid},{durableclass.Siteid}", durableClass4Update.Isusable);
			durableClass4Update.Isusable = "Usable";
			durableclass.CopyCommonFieldUpdatePrev(durableClass4Update, systemTime, dbContext.Tid, text);
			durableclass.CopyExtensionCollection(durableClass4Update);
			list.Add(durableClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteDurableClass(IDbContext dbContext, Durableclass[] durableClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("durableClassList", durableClassList);
		string text = "RealDeleteDurableClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Durableclass> list = new List<Durableclass>();
		foreach (Durableclass durableclass in durableClassList)
		{
			Durableclass durableClass4Update = GetDurableClass4Update(dbContext, durableclass.Durableclassid, durableclass.Siteid);
			if (durableClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Durableclass), $"{durableclass.Durableclassid},{durableclass.Siteid}");
			}
			durableclass.CopyCommonFieldUpdatePrev(durableClass4Update, systemTime, dbContext.Tid, text);
			durableclass.CopyExtensionCollection(durableClass4Update);
			list.Add(durableClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
