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
public class SYSTEMSTATISTICS
{
	private static string _sqlGetSystemStatisticsSqlDatabase = "SELECT * FROM CIM_SYSTEMSTATISTICS WHERE USERID=@USERID AND MENUID=@MENUID AND USERCLASSID=@USERCLASSID AND SITEID=@SITEID AND TID=@TID";

	private static string _sqlGetSystemStatistics4UpdateSqlDatabase = "SELECT * FROM CIM_SYSTEMSTATISTICS WITH(UPDLOCK) WHERE USERID=@USERID AND MENUID=@MENUID AND USERCLASSID=@USERCLASSID AND SITEID=@SITEID AND TID=@TID";

	private static string _sqlSelectSystemStatisticsSqlDatabase = "SELECT * FROM CIM_SYSTEMSTATISTICS WHERE USERID=@USERID AND MENUID=@MENUID AND USERCLASSID=@USERCLASSID AND SITEID=@SITEID AND TID=@TID AND ISUSABLE='Usable'";

	private static string _sqlSelectSystemStatistics4UpdateSqlDatabase = "SELECT * FROM CIM_SYSTEMSTATISTICS WITH(UPDLOCK) WHERE USERID=@USERID AND MENUID=@MENUID AND USERCLASSID=@USERCLASSID AND SITEID=@SITEID AND TID=@TID AND ISUSABLE='Usable'";

	private static string _sqlGetSystemStatisticsOracleDatabase = "SELECT * FROM CIM_SYSTEMSTATISTICS WHERE USERID=:USERID AND MENUID=:MENUID AND USERCLASSID=:USERCLASSID AND SITEID=:SITEID AND TID=:TID";

	private static string _sqlGetSystemStatistics4UpdateOracleDatabase = "SELECT * FROM CIM_SYSTEMSTATISTICS WHERE USERID=:USERID AND MENUID=:MENUID AND USERCLASSID=:USERCLASSID AND SITEID=:SITEID AND TID=:TID FOR UPDATE";

	private static string _sqlSelectSystemStatisticsOracleDatabase = "SELECT * FROM CIM_SYSTEMSTATISTICS WHERE USERID=:USERID AND MENUID=:MENUID AND USERCLASSID=:USERCLASSID AND SITEID=:SITEID AND TID=:TID AND ISUSABLE='Usable'";

	private static string _sqlSelectSystemStatistics4UpdateOracleDatabase = "SELECT * FROM CIM_SYSTEMSTATISTICS WHERE USERID=:USERID AND MENUID=:MENUID AND USERCLASSID=:USERCLASSID AND SITEID=:SITEID AND TID=:TID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Systemstatistics);

	public static Systemstatistics GetSystemStatistics(IDbContext dbContext, string userid, string menuid, string userclassid, string siteid, string tid)
	{
		string apiName = "GetSystemStatistics";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userid},{menuid},{userclassid},{siteid},{tid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetSystemStatisticsSqlDatabase : _sqlGetSystemStatisticsOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("USERCLASSID", userclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		list.Add(dbContext.CreateParameter("TID", tid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SYSTEMSTATISTICS", $"{userid},{menuid},{userclassid},{siteid},{tid}"));
		}
		Systemstatistics result = ContextManager.DirectEntityQuery<Systemstatistics>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userid},{menuid},{userclassid},{siteid},{tid}");
		}
		return result;
	}

	public static Systemstatistics GetSystemStatistics4Update(IDbContext dbContext, string userid, string menuid, string userclassid, string siteid, string tid)
	{
		string apiName = "GetSystemStatistics4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userid},{menuid},{userclassid},{siteid},{tid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetSystemStatistics4UpdateSqlDatabase : _sqlGetSystemStatistics4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("USERCLASSID", userclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		list.Add(dbContext.CreateParameter("TID", tid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_SYSTEMSTATISTICS", $"{userid},{menuid},{userclassid},{siteid},{tid}"));
		}
		Systemstatistics result = ContextManager.DirectEntityQuery<Systemstatistics>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userid},{menuid},{userclassid},{siteid},{tid}");
		}
		return result;
	}

	public static Systemstatistics SelectSystemStatistics(IDbContext dbContext, string userid, string menuid, string userclassid, string siteid, string tid)
	{
		string apiName = "SelectSystemStatistics";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userid},{menuid},{userclassid},{siteid},{tid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectSystemStatisticsSqlDatabase : _sqlSelectSystemStatisticsOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("USERCLASSID", userclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		list.Add(dbContext.CreateParameter("TID", tid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SYSTEMSTATISTICS", $"{userid},{menuid},{userclassid},{siteid},{tid}"));
		}
		Systemstatistics result = ContextManager.DirectEntityQuery<Systemstatistics>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userid},{menuid},{userclassid},{siteid},{tid}");
		}
		return result;
	}

	public static Systemstatistics SelectSystemStatistics4Update(IDbContext dbContext, string userid, string menuid, string userclassid, string siteid, string tid)
	{
		string apiName = "SelectSystemStatistics4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userid},{menuid},{userclassid},{siteid},{tid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectSystemStatistics4UpdateSqlDatabase : _sqlSelectSystemStatistics4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("USERCLASSID", userclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		list.Add(dbContext.CreateParameter("TID", tid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_SYSTEMSTATISTICS", $"{userid},{menuid},{userclassid},{siteid},{tid}"));
		}
		Systemstatistics result = ContextManager.DirectEntityQuery<Systemstatistics>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userid},{menuid},{userclassid},{siteid},{tid}");
		}
		return result;
	}

	public static int UpsertSystemStatistics(IDbContext dbContext, RequestType requestType, Systemstatistics[] systemStatisticsList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateSystemStatisticsInternal(dbContext, systemStatisticsList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateSystemStatistics(dbContext, systemStatisticsList, optionSet, saveHist), 
			RequestType.DELETE => DeleteSystemStatistics(dbContext, systemStatisticsList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteSystemStatistics(dbContext, systemStatisticsList, optionSet, saveHist), 
			_ => RealDeleteSystemStatistics(dbContext, systemStatisticsList, optionSet, saveHist), 
		};
	}

	private static int CreateSystemStatisticsInternal(IDbContext dbContext, Systemstatistics[] systemStatisticsList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("systemStatisticsList", systemStatisticsList);
		string text = "CreateSystemStatistics";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Systemstatistics> list = new List<Systemstatistics>();
		foreach (Systemstatistics obj in systemStatisticsList)
		{
			Systemstatistics systemstatistics = new Systemstatistics();
			obj.CopyColumsTo(systemstatistics);
			systemstatistics.Activity = text;
			systemstatistics.CheckEntityUsable();
			obj.CopyCommonField(systemstatistics, systemTime, dbContext.Tid, isCreate: true);
			list.Add(systemstatistics);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateSystemStatistics(IDbContext dbContext, Systemstatistics[] systemStatisticsList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("systemStatisticsList", systemStatisticsList);
		string text = "UpdateSystemStatistics";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Systemstatistics> list = new List<Systemstatistics>();
		foreach (Systemstatistics systemstatistics in systemStatisticsList)
		{
			Systemstatistics systemStatistics4Update = GetSystemStatistics4Update(dbContext, systemstatistics.Userid, systemstatistics.Menuid, systemstatistics.Userclassid, systemstatistics.Siteid, systemstatistics.Tid);
			if (systemStatistics4Update == null)
			{
				throw new EntityNotFoundException(typeof(Systemstatistics), $"{systemstatistics.Userid},{systemstatistics.Menuid},{systemstatistics.Userclassid},{systemstatistics.Siteid},{systemstatistics.Tid}");
			}
			ParamChecker.EntityUsable(typeof(Systemstatistics), $"{systemstatistics.Userid},{systemstatistics.Menuid},{systemstatistics.Userclassid},{systemstatistics.Siteid},{systemstatistics.Tid}", systemStatistics4Update.Isusable);
			string activity = systemStatistics4Update.Activity;
			string customactivity = systemStatistics4Update.Customactivity;
			string isusable = systemStatistics4Update.Isusable;
			DateTime? createtime = systemStatistics4Update.Createtime;
			string creator = systemStatistics4Update.Creator;
			systemstatistics.CopyColumsTo(systemStatistics4Update);
			systemStatistics4Update.Prevactivity = activity;
			systemStatistics4Update.Prevcustomactivity = customactivity;
			systemStatistics4Update.Creator = creator;
			systemStatistics4Update.Createtime = createtime;
			systemStatistics4Update.Isusable = isusable;
			systemStatistics4Update.Activity = text;
			systemstatistics.CopyCommonField(systemStatistics4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(systemStatistics4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteSystemStatistics(IDbContext dbContext, Systemstatistics[] systemStatisticsList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("systemStatisticsList", systemStatisticsList);
		string text = "DeleteSystemStatistics";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Systemstatistics> list = new List<Systemstatistics>();
		foreach (Systemstatistics systemstatistics in systemStatisticsList)
		{
			Systemstatistics systemStatistics4Update = GetSystemStatistics4Update(dbContext, systemstatistics.Userid, systemstatistics.Menuid, systemstatistics.Userclassid, systemstatistics.Siteid, systemstatistics.Tid);
			if (systemStatistics4Update == null)
			{
				throw new EntityNotFoundException(typeof(Systemstatistics), $"{systemstatistics.Userid},{systemstatistics.Menuid},{systemstatistics.Userclassid},{systemstatistics.Siteid},{systemstatistics.Tid}");
			}
			ParamChecker.EntityUsable(typeof(Systemstatistics), $"{systemstatistics.Userid},{systemstatistics.Menuid},{systemstatistics.Userclassid},{systemstatistics.Siteid},{systemstatistics.Tid}", systemStatistics4Update.Isusable);
			systemStatistics4Update.Isusable = "UnUsable";
			systemstatistics.CopyCommonFieldUpdatePrev(systemStatistics4Update, systemTime, dbContext.Tid, text);
			systemstatistics.CopyExtensionCollection(systemStatistics4Update);
			list.Add(systemStatistics4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteSystemStatistics(IDbContext dbContext, Systemstatistics[] systemStatisticsList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("systemStatisticsList", systemStatisticsList);
		string text = "UnDeleteSystemStatistics";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Systemstatistics> list = new List<Systemstatistics>();
		foreach (Systemstatistics systemstatistics in systemStatisticsList)
		{
			Systemstatistics systemStatistics4Update = GetSystemStatistics4Update(dbContext, systemstatistics.Userid, systemstatistics.Menuid, systemstatistics.Userclassid, systemstatistics.Siteid, systemstatistics.Tid);
			if (systemStatistics4Update == null)
			{
				throw new EntityNotFoundException(typeof(Systemstatistics), $"{systemstatistics.Userid},{systemstatistics.Menuid},{systemstatistics.Userclassid},{systemstatistics.Siteid},{systemstatistics.Tid}");
			}
			ParamChecker.EntityUnUsable(typeof(Systemstatistics), $"{systemstatistics.Userid},{systemstatistics.Menuid},{systemstatistics.Userclassid},{systemstatistics.Siteid},{systemstatistics.Tid}", systemStatistics4Update.Isusable);
			systemStatistics4Update.Isusable = "Usable";
			systemstatistics.CopyCommonFieldUpdatePrev(systemStatistics4Update, systemTime, dbContext.Tid, text);
			systemstatistics.CopyExtensionCollection(systemStatistics4Update);
			list.Add(systemStatistics4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteSystemStatistics(IDbContext dbContext, Systemstatistics[] systemStatisticsList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("systemStatisticsList", systemStatisticsList);
		string text = "RealDeleteSystemStatistics";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Systemstatistics> list = new List<Systemstatistics>();
		foreach (Systemstatistics systemstatistics in systemStatisticsList)
		{
			Systemstatistics systemStatistics4Update = GetSystemStatistics4Update(dbContext, systemstatistics.Userid, systemstatistics.Menuid, systemstatistics.Userclassid, systemstatistics.Siteid, systemstatistics.Tid);
			if (systemStatistics4Update == null)
			{
				throw new EntityNotFoundException(typeof(Systemstatistics), $"{systemstatistics.Userid},{systemstatistics.Menuid},{systemstatistics.Userclassid},{systemstatistics.Siteid},{systemstatistics.Tid}");
			}
			systemstatistics.CopyCommonFieldUpdatePrev(systemStatistics4Update, systemTime, dbContext.Tid, text);
			systemstatistics.CopyExtensionCollection(systemStatistics4Update);
			list.Add(systemStatistics4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
