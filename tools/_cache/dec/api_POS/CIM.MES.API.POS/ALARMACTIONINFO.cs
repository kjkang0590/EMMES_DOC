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
public class ALARMACTIONINFO
{
	private static string _sqlGetAlarmActionInfoSqlDatabase = "SELECT * FROM CIM_ALARMACTIONINFO WHERE ALARMACTIONINFOSYSID=@ALARMACTIONINFOSYSID AND SITEID=@SITEID";

	private static string _sqlGetAlarmActionInfo4UpdateSqlDatabase = "SELECT * FROM CIM_ALARMACTIONINFO WITH(UPDLOCK) WHERE ALARMACTIONINFOSYSID=@ALARMACTIONINFOSYSID AND SITEID=@SITEID";

	private static string _sqlSelectAlarmActionInfoSqlDatabase = "SELECT * FROM CIM_ALARMACTIONINFO WHERE ALARMACTIONINFOSYSID=@ALARMACTIONINFOSYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectAlarmActionInfo4UpdateSqlDatabase = "SELECT * FROM CIM_ALARMACTIONINFO WITH(UPDLOCK) WHERE ALARMACTIONINFOSYSID=@ALARMACTIONINFOSYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetAlarmActionInfoOracleDatabase = "SELECT * FROM CIM_ALARMACTIONINFO WHERE ALARMACTIONINFOSYSID=:ALARMACTIONINFOSYSID AND SITEID=:SITEID";

	private static string _sqlGetAlarmActionInfo4UpdateOracleDatabase = "SELECT * FROM CIM_ALARMACTIONINFO WHERE ALARMACTIONINFOSYSID=:ALARMACTIONINFOSYSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectAlarmActionInfoOracleDatabase = "SELECT * FROM CIM_ALARMACTIONINFO WHERE ALARMACTIONINFOSYSID=:ALARMACTIONINFOSYSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectAlarmActionInfo4UpdateOracleDatabase = "SELECT * FROM CIM_ALARMACTIONINFO WHERE ALARMACTIONINFOSYSID=:ALARMACTIONINFOSYSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Alarmactioninfo);

	public static Alarmactioninfo GetAlarmActionInfo(IDbContext dbContext, string alarmactioninfosysid, string siteid)
	{
		string apiName = "GetAlarmActionInfo";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{alarmactioninfosysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetAlarmActionInfoSqlDatabase : _sqlGetAlarmActionInfoOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ALARMACTIONINFOSYSID", alarmactioninfosysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_ALARMACTIONINFO", $"{alarmactioninfosysid},{siteid}"));
		}
		Alarmactioninfo? result = ContextManager.DirectEntityQuery<Alarmactioninfo>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{alarmactioninfosysid},{siteid}");
		}
		return result;
	}

	public static Alarmactioninfo GetAlarmActionInfo4Update(IDbContext dbContext, string alarmactioninfosysid, string siteid)
	{
		string apiName = "GetAlarmActionInfo4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{alarmactioninfosysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetAlarmActionInfo4UpdateSqlDatabase : _sqlGetAlarmActionInfo4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ALARMACTIONINFOSYSID", alarmactioninfosysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_ALARMACTIONINFO", $"{alarmactioninfosysid},{siteid}"));
		}
		Alarmactioninfo? result = ContextManager.DirectEntityQuery<Alarmactioninfo>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{alarmactioninfosysid},{siteid}");
		}
		return result;
	}

	public static Alarmactioninfo SelectAlarmActionInfo(IDbContext dbContext, string alarmactioninfosysid, string siteid)
	{
		string apiName = "SelectAlarmActionInfo";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{alarmactioninfosysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectAlarmActionInfoSqlDatabase : _sqlSelectAlarmActionInfoOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ALARMACTIONINFOSYSID", alarmactioninfosysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_ALARMACTIONINFO", $"{alarmactioninfosysid},{siteid}"));
		}
		Alarmactioninfo? result = ContextManager.DirectEntityQuery<Alarmactioninfo>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{alarmactioninfosysid},{siteid}");
		}
		return result;
	}

	public static Alarmactioninfo SelectAlarmActionInfo4Update(IDbContext dbContext, string alarmactioninfosysid, string siteid)
	{
		string apiName = "SelectAlarmActionInfo4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{alarmactioninfosysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectAlarmActionInfo4UpdateSqlDatabase : _sqlSelectAlarmActionInfo4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ALARMACTIONINFOSYSID", alarmactioninfosysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_ALARMACTIONINFO", $"{alarmactioninfosysid},{siteid}"));
		}
		Alarmactioninfo? result = ContextManager.DirectEntityQuery<Alarmactioninfo>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{alarmactioninfosysid},{siteid}");
		}
		return result;
	}

	public static int UpsertAlarmActionInfo(IDbContext dbContext, RequestType requestType, Alarmactioninfo[] alarmActionInfoList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateAlarmActionInfoInternal(dbContext, alarmActionInfoList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateAlarmActionInfo(dbContext, alarmActionInfoList, optionSet, saveHist), 
			RequestType.DELETE => DeleteAlarmActionInfo(dbContext, alarmActionInfoList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteAlarmActionInfo(dbContext, alarmActionInfoList, optionSet, saveHist), 
			_ => RealDeleteAlarmActionInfo(dbContext, alarmActionInfoList, optionSet, saveHist), 
		};
	}

	private static int CreateAlarmActionInfoInternal(IDbContext dbContext, Alarmactioninfo[] alarmActionInfoList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmActionInfoList", alarmActionInfoList);
		string text = "CreateAlarmActionInfo";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarmactioninfo> list = new List<Alarmactioninfo>();
		foreach (Alarmactioninfo obj in alarmActionInfoList)
		{
			Alarmactioninfo alarmactioninfo = new Alarmactioninfo();
			obj.CopyColumsTo(alarmactioninfo);
			alarmactioninfo.Activity = text;
			alarmactioninfo.CheckEntityUsable();
			obj.CopyCommonField(alarmactioninfo, systemTime, dbContext.Tid, isCreate: true);
			list.Add(alarmactioninfo);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateAlarmActionInfo(IDbContext dbContext, Alarmactioninfo[] alarmActionInfoList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmActionInfoList", alarmActionInfoList);
		string text = "UpdateAlarmActionInfo";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarmactioninfo> list = new List<Alarmactioninfo>();
		foreach (Alarmactioninfo alarmactioninfo in alarmActionInfoList)
		{
			Alarmactioninfo alarmActionInfo4Update = GetAlarmActionInfo4Update(dbContext, alarmactioninfo.Alarmactioninfosysid, alarmactioninfo.Siteid);
			if (alarmActionInfo4Update == null)
			{
				throw new EntityNotFoundException(typeof(Alarmactioninfo), $"{alarmactioninfo.Alarmactioninfosysid},{alarmactioninfo.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Alarmactioninfo), $"{alarmactioninfo.Alarmactioninfosysid},{alarmactioninfo.Siteid}", alarmActionInfo4Update.Isusable);
			string activity = alarmActionInfo4Update.Activity;
			string customactivity = alarmActionInfo4Update.Customactivity;
			string isusable = alarmActionInfo4Update.Isusable;
			DateTime? createtime = alarmActionInfo4Update.Createtime;
			string creator = alarmActionInfo4Update.Creator;
			alarmactioninfo.CopyColumsTo(alarmActionInfo4Update);
			alarmActionInfo4Update.Prevactivity = activity;
			alarmActionInfo4Update.Prevcustomactivity = customactivity;
			alarmActionInfo4Update.Creator = creator;
			alarmActionInfo4Update.Createtime = createtime;
			alarmActionInfo4Update.Isusable = isusable;
			alarmActionInfo4Update.Activity = text;
			alarmactioninfo.CopyCommonField(alarmActionInfo4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(alarmActionInfo4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteAlarmActionInfo(IDbContext dbContext, Alarmactioninfo[] alarmActionInfoList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmActionInfoList", alarmActionInfoList);
		string text = "DeleteAlarmActionInfo";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarmactioninfo> list = new List<Alarmactioninfo>();
		foreach (Alarmactioninfo alarmactioninfo in alarmActionInfoList)
		{
			Alarmactioninfo alarmActionInfo4Update = GetAlarmActionInfo4Update(dbContext, alarmactioninfo.Alarmactioninfosysid, alarmactioninfo.Siteid);
			if (alarmActionInfo4Update == null)
			{
				throw new EntityNotFoundException(typeof(Alarmactioninfo), $"{alarmactioninfo.Alarmactioninfosysid},{alarmactioninfo.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Alarmactioninfo), $"{alarmactioninfo.Alarmactioninfosysid},{alarmactioninfo.Siteid}", alarmActionInfo4Update.Isusable);
			alarmActionInfo4Update.Isusable = "UnUsable";
			alarmactioninfo.CopyCommonFieldUpdatePrev(alarmActionInfo4Update, systemTime, dbContext.Tid, text);
			alarmactioninfo.CopyExtensionCollection(alarmActionInfo4Update);
			list.Add(alarmActionInfo4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteAlarmActionInfo(IDbContext dbContext, Alarmactioninfo[] alarmActionInfoList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmActionInfoList", alarmActionInfoList);
		string text = "UnDeleteAlarmActionInfo";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarmactioninfo> list = new List<Alarmactioninfo>();
		foreach (Alarmactioninfo alarmactioninfo in alarmActionInfoList)
		{
			Alarmactioninfo alarmActionInfo4Update = GetAlarmActionInfo4Update(dbContext, alarmactioninfo.Alarmactioninfosysid, alarmactioninfo.Siteid);
			if (alarmActionInfo4Update == null)
			{
				throw new EntityNotFoundException(typeof(Alarmactioninfo), $"{alarmactioninfo.Alarmactioninfosysid},{alarmactioninfo.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Alarmactioninfo), $"{alarmactioninfo.Alarmactioninfosysid},{alarmactioninfo.Siteid}", alarmActionInfo4Update.Isusable);
			alarmActionInfo4Update.Isusable = "Usable";
			alarmactioninfo.CopyCommonFieldUpdatePrev(alarmActionInfo4Update, systemTime, dbContext.Tid, text);
			alarmactioninfo.CopyExtensionCollection(alarmActionInfo4Update);
			list.Add(alarmActionInfo4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteAlarmActionInfo(IDbContext dbContext, Alarmactioninfo[] alarmActionInfoList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmActionInfoList", alarmActionInfoList);
		string text = "RealDeleteAlarmActionInfo";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarmactioninfo> list = new List<Alarmactioninfo>();
		foreach (Alarmactioninfo alarmactioninfo in alarmActionInfoList)
		{
			Alarmactioninfo alarmActionInfo4Update = GetAlarmActionInfo4Update(dbContext, alarmactioninfo.Alarmactioninfosysid, alarmactioninfo.Siteid);
			if (alarmActionInfo4Update == null)
			{
				throw new EntityNotFoundException(typeof(Alarmactioninfo), $"{alarmactioninfo.Alarmactioninfosysid},{alarmactioninfo.Siteid}");
			}
			alarmactioninfo.CopyCommonFieldUpdatePrev(alarmActionInfo4Update, systemTime, dbContext.Tid, text);
			alarmactioninfo.CopyExtensionCollection(alarmActionInfo4Update);
			list.Add(alarmActionInfo4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
