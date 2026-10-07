using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.DAS;

[MESAPI]
public class TRACEDATACLASS
{
	private static string _sqlGetTraceDataClassSqlDatabase = "SELECT * FROM CIM_TRACEDATACLASS WHERE TRACEDATACLASSID=@TRACEDATACLASSID AND SITEID=@SITEID";

	private static string _sqlGetTraceDataClass4UpdateSqlDatabase = "SELECT * FROM CIM_TRACEDATACLASS WITH(UPDLOCK) WHERE TRACEDATACLASSID=@TRACEDATACLASSID AND SITEID=@SITEID";

	private static string _sqlSelectTraceDataClassSqlDatabase = "SELECT * FROM CIM_TRACEDATACLASS WHERE TRACEDATACLASSID=@TRACEDATACLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectTraceDataClass4UpdateSqlDatabase = "SELECT * FROM CIM_TRACEDATACLASS WITH(UPDLOCK) WHERE TRACEDATACLASSID=@TRACEDATACLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetTraceDataClassOracleDatabase = "SELECT * FROM CIM_TRACEDATACLASS WHERE TRACEDATACLASSID=:TRACEDATACLASSID AND SITEID=:SITEID";

	private static string _sqlGetTraceDataClass4UpdateOracleDatabase = "SELECT * FROM CIM_TRACEDATACLASS WHERE TRACEDATACLASSID=:TRACEDATACLASSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectTraceDataClassOracleDatabase = "SELECT * FROM CIM_TRACEDATACLASS WHERE TRACEDATACLASSID=:TRACEDATACLASSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectTraceDataClass4UpdateOracleDatabase = "SELECT * FROM CIM_TRACEDATACLASS WHERE TRACEDATACLASSID=:TRACEDATACLASSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Tracedataclass);

	public static Tracedataclass GetTraceDataClass(IDbContext dbContext, string tracedataclassid, string siteid)
	{
		string apiName = "GetTraceDataClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tracedataclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetTraceDataClassSqlDatabase : _sqlGetTraceDataClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TRACEDATACLASSID", tracedataclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_TRACEDATACLASS", $"{tracedataclassid},{siteid}"));
		}
		Tracedataclass? result = ContextManager.DirectEntityQuery<Tracedataclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tracedataclassid},{siteid}");
		}
		return result;
	}

	public static Tracedataclass GetTraceDataClass4Update(IDbContext dbContext, string tracedataclassid, string siteid)
	{
		string apiName = "GetTraceDataClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tracedataclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetTraceDataClass4UpdateSqlDatabase : _sqlGetTraceDataClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TRACEDATACLASSID", tracedataclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_TRACEDATACLASS", $"{tracedataclassid},{siteid}"));
		}
		Tracedataclass? result = ContextManager.DirectEntityQuery<Tracedataclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tracedataclassid},{siteid}");
		}
		return result;
	}

	public static Tracedataclass SelectTraceDataClass(IDbContext dbContext, string tracedataclassid, string siteid)
	{
		string apiName = "SelectTraceDataClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tracedataclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectTraceDataClassSqlDatabase : _sqlSelectTraceDataClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TRACEDATACLASSID", tracedataclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_TRACEDATACLASS", $"{tracedataclassid},{siteid}"));
		}
		Tracedataclass? result = ContextManager.DirectEntityQuery<Tracedataclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tracedataclassid},{siteid}");
		}
		return result;
	}

	public static Tracedataclass SelectTraceDataClass4Update(IDbContext dbContext, string tracedataclassid, string siteid)
	{
		string apiName = "SelectTraceDataClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tracedataclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectTraceDataClass4UpdateSqlDatabase : _sqlSelectTraceDataClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TRACEDATACLASSID", tracedataclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_TRACEDATACLASS", $"{tracedataclassid},{siteid}"));
		}
		Tracedataclass? result = ContextManager.DirectEntityQuery<Tracedataclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tracedataclassid},{siteid}");
		}
		return result;
	}

	public static int UpsertTraceDataClass(IDbContext dbContext, RequestType requestType, Tracedataclass[] traceDataClassList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateTraceDataClassInternal(dbContext, traceDataClassList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateTraceDataClass(dbContext, traceDataClassList, optionSet, saveHist), 
			RequestType.DELETE => DeleteTraceDataClass(dbContext, traceDataClassList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteTraceDataClass(dbContext, traceDataClassList, optionSet, saveHist), 
			_ => RealDeleteTraceDataClass(dbContext, traceDataClassList, optionSet, saveHist), 
		};
	}

	private static int CreateTraceDataClassInternal(IDbContext dbContext, Tracedataclass[] traceDataClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceDataClassList", traceDataClassList);
		string text = "CreateTraceDataClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tracedataclass> list = new List<Tracedataclass>();
		foreach (Tracedataclass obj in traceDataClassList)
		{
			Tracedataclass tracedataclass = new Tracedataclass();
			obj.CopyColumsTo(tracedataclass);
			tracedataclass.Activity = text;
			tracedataclass.CheckEntityUsable();
			obj.CopyCommonField(tracedataclass, systemTime, dbContext.Tid, isCreate: true);
			list.Add(tracedataclass);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateTraceDataClass(IDbContext dbContext, Tracedataclass[] traceDataClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceDataClassList", traceDataClassList);
		string text = "UpdateTraceDataClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tracedataclass> list = new List<Tracedataclass>();
		foreach (Tracedataclass tracedataclass in traceDataClassList)
		{
			Tracedataclass traceDataClass4Update = GetTraceDataClass4Update(dbContext, tracedataclass.Tracedataclassid, tracedataclass.Siteid);
			if (traceDataClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Tracedataclass), $"{tracedataclass.Tracedataclassid},{tracedataclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Tracedataclass), $"{tracedataclass.Tracedataclassid},{tracedataclass.Siteid}", traceDataClass4Update.Isusable);
			string activity = traceDataClass4Update.Activity;
			string customactivity = traceDataClass4Update.Customactivity;
			string isusable = traceDataClass4Update.Isusable;
			DateTime? createtime = traceDataClass4Update.Createtime;
			string creator = traceDataClass4Update.Creator;
			tracedataclass.CopyColumsTo(traceDataClass4Update);
			traceDataClass4Update.Prevactivity = activity;
			traceDataClass4Update.Prevcustomactivity = customactivity;
			traceDataClass4Update.Creator = creator;
			traceDataClass4Update.Createtime = createtime;
			traceDataClass4Update.Isusable = isusable;
			traceDataClass4Update.Activity = text;
			tracedataclass.CopyCommonField(traceDataClass4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(traceDataClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteTraceDataClass(IDbContext dbContext, Tracedataclass[] traceDataClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceDataClassList", traceDataClassList);
		string text = "DeleteTraceDataClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tracedataclass> list = new List<Tracedataclass>();
		foreach (Tracedataclass tracedataclass in traceDataClassList)
		{
			Tracedataclass traceDataClass4Update = GetTraceDataClass4Update(dbContext, tracedataclass.Tracedataclassid, tracedataclass.Siteid);
			if (traceDataClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Tracedataclass), $"{tracedataclass.Tracedataclassid},{tracedataclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Tracedataclass), $"{tracedataclass.Tracedataclassid},{tracedataclass.Siteid}", traceDataClass4Update.Isusable);
			traceDataClass4Update.Isusable = "UnUsable";
			tracedataclass.CopyCommonFieldUpdatePrev(traceDataClass4Update, systemTime, dbContext.Tid, text);
			tracedataclass.CopyExtensionCollection(traceDataClass4Update);
			list.Add(traceDataClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteTraceDataClass(IDbContext dbContext, Tracedataclass[] traceDataClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceDataClassList", traceDataClassList);
		string text = "UnDeleteTraceDataClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tracedataclass> list = new List<Tracedataclass>();
		foreach (Tracedataclass tracedataclass in traceDataClassList)
		{
			Tracedataclass traceDataClass4Update = GetTraceDataClass4Update(dbContext, tracedataclass.Tracedataclassid, tracedataclass.Siteid);
			if (traceDataClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Tracedataclass), $"{tracedataclass.Tracedataclassid},{tracedataclass.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Tracedataclass), $"{tracedataclass.Tracedataclassid},{tracedataclass.Siteid}", traceDataClass4Update.Isusable);
			traceDataClass4Update.Isusable = "Usable";
			tracedataclass.CopyCommonFieldUpdatePrev(traceDataClass4Update, systemTime, dbContext.Tid, text);
			tracedataclass.CopyExtensionCollection(traceDataClass4Update);
			list.Add(traceDataClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteTraceDataClass(IDbContext dbContext, Tracedataclass[] traceDataClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceDataClassList", traceDataClassList);
		string text = "RealDeleteTraceDataClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tracedataclass> list = new List<Tracedataclass>();
		foreach (Tracedataclass tracedataclass in traceDataClassList)
		{
			Tracedataclass traceDataClass4Update = GetTraceDataClass4Update(dbContext, tracedataclass.Tracedataclassid, tracedataclass.Siteid);
			if (traceDataClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Tracedataclass), $"{tracedataclass.Tracedataclassid},{tracedataclass.Siteid}");
			}
			tracedataclass.CopyCommonFieldUpdatePrev(traceDataClass4Update, systemTime, dbContext.Tid, text);
			tracedataclass.CopyExtensionCollection(traceDataClass4Update);
			list.Add(traceDataClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
