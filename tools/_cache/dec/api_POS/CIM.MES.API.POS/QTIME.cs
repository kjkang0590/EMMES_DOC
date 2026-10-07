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
public class QTIME
{
	private static string _sqlGetQtimeSqlDatabase = "SELECT * FROM CIM_QTIME WHERE LOTID=@LOTID AND PROCESSSEGMENTID=@PROCESSSEGMENTID AND TOPROCESSSEGMENTID=@TOPROCESSSEGMENTID AND SITEID=@SITEID";

	private static string _sqlGetQtime4UpdateSqlDatabase = "SELECT * FROM CIM_QTIME WITH(UPDLOCK) WHERE LOTID=@LOTID AND PROCESSSEGMENTID=@PROCESSSEGMENTID AND TOPROCESSSEGMENTID=@TOPROCESSSEGMENTID AND SITEID=@SITEID";

	private static string _sqlSelectQtimeSqlDatabase = "SELECT * FROM CIM_QTIME WHERE LOTID=@LOTID AND PROCESSSEGMENTID=@PROCESSSEGMENTID AND TOPROCESSSEGMENTID=@TOPROCESSSEGMENTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectQtime4UpdateSqlDatabase = "SELECT * FROM CIM_QTIME WITH(UPDLOCK) WHERE LOTID=@LOTID AND PROCESSSEGMENTID=@PROCESSSEGMENTID AND TOPROCESSSEGMENTID=@TOPROCESSSEGMENTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetQtimeOracleDatabase = "SELECT * FROM CIM_QTIME WHERE LOTID=:LOTID AND PROCESSSEGMENTID=:PROCESSSEGMENTID AND TOPROCESSSEGMENTID=:TOPROCESSSEGMENTID AND SITEID=:SITEID";

	private static string _sqlGetQtime4UpdateOracleDatabase = "SELECT * FROM CIM_QTIME WHERE LOTID=:LOTID AND PROCESSSEGMENTID=:PROCESSSEGMENTID AND TOPROCESSSEGMENTID=:TOPROCESSSEGMENTID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectQtimeOracleDatabase = "SELECT * FROM CIM_QTIME WHERE LOTID=:LOTID AND PROCESSSEGMENTID=:PROCESSSEGMENTID AND TOPROCESSSEGMENTID=:TOPROCESSSEGMENTID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectQtime4UpdateOracleDatabase = "SELECT * FROM CIM_QTIME WHERE LOTID=:LOTID AND PROCESSSEGMENTID=:PROCESSSEGMENTID AND TOPROCESSSEGMENTID=:TOPROCESSSEGMENTID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Qtime);

	public static Qtime GetQtime(IDbContext dbContext, string lotid, string processsegmentid, string toprocesssegmentid, string siteid)
	{
		string apiName = "GetQtime";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{processsegmentid},{toprocesssegmentid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetQtimeSqlDatabase : _sqlGetQtimeOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("TOPROCESSSEGMENTID", toprocesssegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_QTIME", $"{lotid},{processsegmentid},{toprocesssegmentid},{siteid}"));
		}
		Qtime result = ContextManager.DirectEntityQuery<Qtime>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{processsegmentid},{toprocesssegmentid},{siteid}");
		}
		return result;
	}

	public static Qtime GetQtime4Update(IDbContext dbContext, string lotid, string processsegmentid, string toprocesssegmentid, string siteid)
	{
		string apiName = "GetQtime4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{processsegmentid},{toprocesssegmentid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetQtime4UpdateSqlDatabase : _sqlGetQtime4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("TOPROCESSSEGMENTID", toprocesssegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_QTIME", $"{lotid},{processsegmentid},{toprocesssegmentid},{siteid}"));
		}
		Qtime result = ContextManager.DirectEntityQuery<Qtime>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{processsegmentid},{toprocesssegmentid},{siteid}");
		}
		return result;
	}

	public static Qtime SelectQtime(IDbContext dbContext, string lotid, string processsegmentid, string toprocesssegmentid, string siteid)
	{
		string apiName = "SelectQtime";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{processsegmentid},{toprocesssegmentid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectQtimeSqlDatabase : _sqlSelectQtimeOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("TOPROCESSSEGMENTID", toprocesssegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_QTIME", $"{lotid},{processsegmentid},{toprocesssegmentid},{siteid}"));
		}
		Qtime result = ContextManager.DirectEntityQuery<Qtime>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{processsegmentid},{toprocesssegmentid},{siteid}");
		}
		return result;
	}

	public static Qtime SelectQtime4Update(IDbContext dbContext, string lotid, string processsegmentid, string toprocesssegmentid, string siteid)
	{
		string apiName = "SelectQtime4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{processsegmentid},{toprocesssegmentid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectQtime4UpdateSqlDatabase : _sqlSelectQtime4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("TOPROCESSSEGMENTID", toprocesssegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_QTIME", $"{lotid},{processsegmentid},{toprocesssegmentid},{siteid}"));
		}
		Qtime result = ContextManager.DirectEntityQuery<Qtime>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{processsegmentid},{toprocesssegmentid},{siteid}");
		}
		return result;
	}

	public static int UpsertQtime(IDbContext dbContext, RequestType requestType, Qtime[] qtimeList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateQtimeInternal(dbContext, qtimeList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateQtime(dbContext, qtimeList, optionSet, saveHist), 
			RequestType.DELETE => DeleteQtime(dbContext, qtimeList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteQtime(dbContext, qtimeList, optionSet, saveHist), 
			_ => RealDeleteQtime(dbContext, qtimeList, optionSet, saveHist), 
		};
	}

	private static int CreateQtimeInternal(IDbContext dbContext, Qtime[] qtimeList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("qtimeList", qtimeList);
		string text = "CreateQtime";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Qtime> list = new List<Qtime>();
		foreach (Qtime obj in qtimeList)
		{
			Qtime qtime = new Qtime();
			obj.CopyColumsTo(qtime);
			qtime.Activity = text;
			qtime.CheckEntityUsable();
			obj.CopyCommonField(qtime, systemTime, dbContext.Tid, isCreate: true);
			list.Add(qtime);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateQtime(IDbContext dbContext, Qtime[] qtimeList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("qtimeList", qtimeList);
		string text = "UpdateQtime";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Qtime> list = new List<Qtime>();
		foreach (Qtime qtime in qtimeList)
		{
			Qtime qtime4Update = GetQtime4Update(dbContext, qtime.Lotid, qtime.Processsegmentid, qtime.Toprocesssegmentid, qtime.Siteid);
			if (qtime4Update == null)
			{
				throw new EntityNotFoundException(typeof(Qtime), $"{qtime.Lotid},{qtime.Processsegmentid},{qtime.Toprocesssegmentid},{qtime.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Qtime), $"{qtime.Lotid},{qtime.Processsegmentid},{qtime.Toprocesssegmentid},{qtime.Siteid}", qtime4Update.Isusable);
			string activity = qtime4Update.Activity;
			string customactivity = qtime4Update.Customactivity;
			string isusable = qtime4Update.Isusable;
			DateTime? createtime = qtime4Update.Createtime;
			string creator = qtime4Update.Creator;
			qtime.CopyColumsTo(qtime4Update);
			qtime4Update.Prevactivity = activity;
			qtime4Update.Prevcustomactivity = customactivity;
			qtime4Update.Creator = creator;
			qtime4Update.Createtime = createtime;
			qtime4Update.Isusable = isusable;
			qtime4Update.Activity = text;
			qtime.CopyCommonField(qtime4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(qtime4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteQtime(IDbContext dbContext, Qtime[] qtimeList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("qtimeList", qtimeList);
		string text = "DeleteQtime";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Qtime> list = new List<Qtime>();
		foreach (Qtime qtime in qtimeList)
		{
			Qtime qtime4Update = GetQtime4Update(dbContext, qtime.Lotid, qtime.Processsegmentid, qtime.Toprocesssegmentid, qtime.Siteid);
			if (qtime4Update == null)
			{
				throw new EntityNotFoundException(typeof(Qtime), $"{qtime.Lotid},{qtime.Processsegmentid},{qtime.Toprocesssegmentid},{qtime.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Qtime), $"{qtime.Lotid},{qtime.Processsegmentid},{qtime.Toprocesssegmentid},{qtime.Siteid}", qtime4Update.Isusable);
			qtime4Update.Isusable = "UnUsable";
			qtime.CopyCommonFieldUpdatePrev(qtime4Update, systemTime, dbContext.Tid, text);
			qtime.CopyExtensionCollection(qtime4Update);
			list.Add(qtime4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteQtime(IDbContext dbContext, Qtime[] qtimeList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("qtimeList", qtimeList);
		string text = "UnDeleteQtime";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Qtime> list = new List<Qtime>();
		foreach (Qtime qtime in qtimeList)
		{
			Qtime qtime4Update = GetQtime4Update(dbContext, qtime.Lotid, qtime.Processsegmentid, qtime.Toprocesssegmentid, qtime.Siteid);
			if (qtime4Update == null)
			{
				throw new EntityNotFoundException(typeof(Qtime), $"{qtime.Lotid},{qtime.Processsegmentid},{qtime.Toprocesssegmentid},{qtime.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Qtime), $"{qtime.Lotid},{qtime.Processsegmentid},{qtime.Toprocesssegmentid},{qtime.Siteid}", qtime4Update.Isusable);
			qtime4Update.Isusable = "Usable";
			qtime.CopyCommonFieldUpdatePrev(qtime4Update, systemTime, dbContext.Tid, text);
			qtime.CopyExtensionCollection(qtime4Update);
			list.Add(qtime4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteQtime(IDbContext dbContext, Qtime[] qtimeList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("qtimeList", qtimeList);
		string text = "RealDeleteQtime";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Qtime> list = new List<Qtime>();
		foreach (Qtime qtime in qtimeList)
		{
			Qtime qtime4Update = GetQtime4Update(dbContext, qtime.Lotid, qtime.Processsegmentid, qtime.Toprocesssegmentid, qtime.Siteid);
			if (qtime4Update == null)
			{
				throw new EntityNotFoundException(typeof(Qtime), $"{qtime.Lotid},{qtime.Processsegmentid},{qtime.Toprocesssegmentid},{qtime.Siteid}");
			}
			qtime.CopyCommonFieldUpdatePrev(qtime4Update, systemTime, dbContext.Tid, text);
			qtime.CopyExtensionCollection(qtime4Update);
			list.Add(qtime4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
