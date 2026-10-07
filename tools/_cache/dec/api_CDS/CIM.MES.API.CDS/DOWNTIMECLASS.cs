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
public class DOWNTIMECLASS
{
	private static string _sqlGetDowntimeClassSqlDatabase = "SELECT * FROM CIM_DOWNTIMECLASS WHERE DOWNTIMECLASSID=@DOWNTIMECLASSID AND SITEID=@SITEID";

	private static string _sqlGetDowntimeClass4UpdateSqlDatabase = "SELECT * FROM CIM_DOWNTIMECLASS WITH(UPDLOCK) WHERE DOWNTIMECLASSID=@DOWNTIMECLASSID AND SITEID=@SITEID";

	private static string _sqlSelectDowntimeClassSqlDatabase = "SELECT * FROM CIM_DOWNTIMECLASS WHERE DOWNTIMECLASSID=@DOWNTIMECLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectDowntimeClass4UpdateSqlDatabase = "SELECT * FROM CIM_DOWNTIMECLASS WITH(UPDLOCK) WHERE DOWNTIMECLASSID=@DOWNTIMECLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetDowntimeClassOracleDatabase = "SELECT * FROM CIM_DOWNTIMECLASS WHERE DOWNTIMECLASSID=:DOWNTIMECLASSID AND SITEID=:SITEID";

	private static string _sqlGetDowntimeClass4UpdateOracleDatabase = "SELECT * FROM CIM_DOWNTIMECLASS WHERE DOWNTIMECLASSID=:DOWNTIMECLASSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectDowntimeClassOracleDatabase = "SELECT * FROM CIM_DOWNTIMECLASS WHERE DOWNTIMECLASSID=:DOWNTIMECLASSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectDowntimeClass4UpdateOracleDatabase = "SELECT * FROM CIM_DOWNTIMECLASS WHERE DOWNTIMECLASSID=:DOWNTIMECLASSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Downtimeclass);

	public static Downtimeclass GetDowntimeClass(IDbContext dbContext, string downtimeclassid, string siteid)
	{
		string apiName = "GetDowntimeClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{downtimeclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetDowntimeClassSqlDatabase : _sqlGetDowntimeClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DOWNTIMECLASSID", downtimeclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_DOWNTIMECLASS", $"{downtimeclassid},{siteid}"));
		}
		Downtimeclass? result = ContextManager.DirectEntityQuery<Downtimeclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{downtimeclassid},{siteid}");
		}
		return result;
	}

	public static Downtimeclass GetDowntimeClass4Update(IDbContext dbContext, string downtimeclassid, string siteid)
	{
		string apiName = "GetDowntimeClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{downtimeclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetDowntimeClass4UpdateSqlDatabase : _sqlGetDowntimeClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DOWNTIMECLASSID", downtimeclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_DOWNTIMECLASS", $"{downtimeclassid},{siteid}"));
		}
		Downtimeclass? result = ContextManager.DirectEntityQuery<Downtimeclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{downtimeclassid},{siteid}");
		}
		return result;
	}

	public static Downtimeclass SelectDowntimeClass(IDbContext dbContext, string downtimeclassid, string siteid)
	{
		string apiName = "SelectDowntimeClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{downtimeclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectDowntimeClassSqlDatabase : _sqlSelectDowntimeClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DOWNTIMECLASSID", downtimeclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_DOWNTIMECLASS", $"{downtimeclassid},{siteid}"));
		}
		Downtimeclass? result = ContextManager.DirectEntityQuery<Downtimeclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{downtimeclassid},{siteid}");
		}
		return result;
	}

	public static Downtimeclass SelectDowntimeClass4Update(IDbContext dbContext, string downtimeclassid, string siteid)
	{
		string apiName = "SelectDowntimeClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{downtimeclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectDowntimeClass4UpdateSqlDatabase : _sqlSelectDowntimeClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DOWNTIMECLASSID", downtimeclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_DOWNTIMECLASS", $"{downtimeclassid},{siteid}"));
		}
		Downtimeclass? result = ContextManager.DirectEntityQuery<Downtimeclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{downtimeclassid},{siteid}");
		}
		return result;
	}

	public static int UpsertDowntimeClass(IDbContext dbContext, RequestType requestType, Downtimeclass[] downtimeClassList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateDowntimeClassInternal(dbContext, downtimeClassList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateDowntimeClass(dbContext, downtimeClassList, optionSet, saveHist), 
			RequestType.DELETE => DeleteDowntimeClass(dbContext, downtimeClassList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteDowntimeClass(dbContext, downtimeClassList, optionSet, saveHist), 
			_ => RealDeleteDowntimeClass(dbContext, downtimeClassList, optionSet, saveHist), 
		};
	}

	private static int CreateDowntimeClassInternal(IDbContext dbContext, Downtimeclass[] downtimeClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("downtimeClassList", downtimeClassList);
		string text = "CreateDowntimeClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Downtimeclass> list = new List<Downtimeclass>();
		foreach (Downtimeclass obj in downtimeClassList)
		{
			Downtimeclass downtimeclass = new Downtimeclass();
			obj.CopyColumsTo(downtimeclass);
			downtimeclass.Activity = text;
			downtimeclass.CheckEntityUsable();
			obj.CopyCommonField(downtimeclass, systemTime, dbContext.Tid, isCreate: true);
			list.Add(downtimeclass);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateDowntimeClass(IDbContext dbContext, Downtimeclass[] downtimeClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("downtimeClassList", downtimeClassList);
		string text = "UpdateDowntimeClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Downtimeclass> list = new List<Downtimeclass>();
		foreach (Downtimeclass downtimeclass in downtimeClassList)
		{
			Downtimeclass downtimeClass4Update = GetDowntimeClass4Update(dbContext, downtimeclass.Downtimeclassid, downtimeclass.Siteid);
			if (downtimeClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Downtimeclass), $"{downtimeclass.Downtimeclassid},{downtimeclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Downtimeclass), $"{downtimeclass.Downtimeclassid},{downtimeclass.Siteid}", downtimeClass4Update.Isusable);
			string activity = downtimeClass4Update.Activity;
			string customactivity = downtimeClass4Update.Customactivity;
			string isusable = downtimeClass4Update.Isusable;
			DateTime? createtime = downtimeClass4Update.Createtime;
			string creator = downtimeClass4Update.Creator;
			downtimeclass.CopyColumsTo(downtimeClass4Update);
			downtimeClass4Update.Prevactivity = activity;
			downtimeClass4Update.Prevcustomactivity = customactivity;
			downtimeClass4Update.Creator = creator;
			downtimeClass4Update.Createtime = createtime;
			downtimeClass4Update.Isusable = isusable;
			downtimeClass4Update.Activity = text;
			downtimeclass.CopyCommonField(downtimeClass4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(downtimeClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteDowntimeClass(IDbContext dbContext, Downtimeclass[] downtimeClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("downtimeClassList", downtimeClassList);
		string text = "DeleteDowntimeClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Downtimeclass> list = new List<Downtimeclass>();
		foreach (Downtimeclass downtimeclass in downtimeClassList)
		{
			Downtimeclass downtimeClass4Update = GetDowntimeClass4Update(dbContext, downtimeclass.Downtimeclassid, downtimeclass.Siteid);
			if (downtimeClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Downtimeclass), $"{downtimeclass.Downtimeclassid},{downtimeclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Downtimeclass), $"{downtimeclass.Downtimeclassid},{downtimeclass.Siteid}", downtimeClass4Update.Isusable);
			downtimeClass4Update.Isusable = "UnUsable";
			downtimeclass.CopyCommonFieldUpdatePrev(downtimeClass4Update, systemTime, dbContext.Tid, text);
			downtimeclass.CopyExtensionCollection(downtimeClass4Update);
			list.Add(downtimeClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteDowntimeClass(IDbContext dbContext, Downtimeclass[] downtimeClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("downtimeClassList", downtimeClassList);
		string text = "UnDeleteDowntimeClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Downtimeclass> list = new List<Downtimeclass>();
		foreach (Downtimeclass downtimeclass in downtimeClassList)
		{
			Downtimeclass downtimeClass4Update = GetDowntimeClass4Update(dbContext, downtimeclass.Downtimeclassid, downtimeclass.Siteid);
			if (downtimeClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Downtimeclass), $"{downtimeclass.Downtimeclassid},{downtimeclass.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Downtimeclass), $"{downtimeclass.Downtimeclassid},{downtimeclass.Siteid}", downtimeClass4Update.Isusable);
			downtimeClass4Update.Isusable = "Usable";
			downtimeclass.CopyCommonFieldUpdatePrev(downtimeClass4Update, systemTime, dbContext.Tid, text);
			downtimeclass.CopyExtensionCollection(downtimeClass4Update);
			list.Add(downtimeClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteDowntimeClass(IDbContext dbContext, Downtimeclass[] downtimeClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("downtimeClassList", downtimeClassList);
		string text = "RealDeleteDowntimeClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Downtimeclass> list = new List<Downtimeclass>();
		foreach (Downtimeclass downtimeclass in downtimeClassList)
		{
			Downtimeclass downtimeClass4Update = GetDowntimeClass4Update(dbContext, downtimeclass.Downtimeclassid, downtimeclass.Siteid);
			if (downtimeClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Downtimeclass), $"{downtimeclass.Downtimeclassid},{downtimeclass.Siteid}");
			}
			downtimeclass.CopyCommonFieldUpdatePrev(downtimeClass4Update, systemTime, dbContext.Tid, text);
			downtimeclass.CopyExtensionCollection(downtimeClass4Update);
			list.Add(downtimeClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
