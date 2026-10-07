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
public class DOWNTIMECODE
{
	private static string _sqlGetDowntimeCodeSqlDatabase = "SELECT * FROM CIM_DOWNTIMECODE WHERE DOWNTIMEID=@DOWNTIMEID AND SITEID=@SITEID";

	private static string _sqlGetDowntimeCode4UpdateSqlDatabase = "SELECT * FROM CIM_DOWNTIMECODE WITH(UPDLOCK) WHERE DOWNTIMEID=@DOWNTIMEID AND SITEID=@SITEID";

	private static string _sqlSelectDowntimeCodeSqlDatabase = "SELECT * FROM CIM_DOWNTIMECODE WHERE DOWNTIMEID=@DOWNTIMEID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectDowntimeCode4UpdateSqlDatabase = "SELECT * FROM CIM_DOWNTIMECODE WITH(UPDLOCK) WHERE DOWNTIMEID=@DOWNTIMEID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetDowntimeCodeOracleDatabase = "SELECT * FROM CIM_DOWNTIMECODE WHERE DOWNTIMEID=:DOWNTIMEID AND SITEID=:SITEID";

	private static string _sqlGetDowntimeCode4UpdateOracleDatabase = "SELECT * FROM CIM_DOWNTIMECODE WHERE DOWNTIMEID=:DOWNTIMEID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectDowntimeCodeOracleDatabase = "SELECT * FROM CIM_DOWNTIMECODE WHERE DOWNTIMEID=:DOWNTIMEID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectDowntimeCode4UpdateOracleDatabase = "SELECT * FROM CIM_DOWNTIMECODE WHERE DOWNTIMEID=:DOWNTIMEID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Downtimecode);

	public static Downtimecode GetDowntimeCode(IDbContext dbContext, string downtimeid, string siteid)
	{
		string apiName = "GetDowntimeCode";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{downtimeid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetDowntimeCodeSqlDatabase : _sqlGetDowntimeCodeOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DOWNTIMEID", downtimeid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_DOWNTIMECODE", $"{downtimeid},{siteid}"));
		}
		Downtimecode? result = ContextManager.DirectEntityQuery<Downtimecode>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{downtimeid},{siteid}");
		}
		return result;
	}

	public static Downtimecode GetDowntimeCode4Update(IDbContext dbContext, string downtimeid, string siteid)
	{
		string apiName = "GetDowntimeCode4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{downtimeid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetDowntimeCode4UpdateSqlDatabase : _sqlGetDowntimeCode4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DOWNTIMEID", downtimeid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_DOWNTIMECODE", $"{downtimeid},{siteid}"));
		}
		Downtimecode? result = ContextManager.DirectEntityQuery<Downtimecode>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{downtimeid},{siteid}");
		}
		return result;
	}

	public static Downtimecode SelectDowntimeCode(IDbContext dbContext, string downtimeid, string siteid)
	{
		string apiName = "SelectDowntimeCode";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{downtimeid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectDowntimeCodeSqlDatabase : _sqlSelectDowntimeCodeOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DOWNTIMEID", downtimeid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_DOWNTIMECODE", $"{downtimeid},{siteid}"));
		}
		Downtimecode? result = ContextManager.DirectEntityQuery<Downtimecode>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{downtimeid},{siteid}");
		}
		return result;
	}

	public static Downtimecode SelectDowntimeCode4Update(IDbContext dbContext, string downtimeid, string siteid)
	{
		string apiName = "SelectDowntimeCode4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{downtimeid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectDowntimeCode4UpdateSqlDatabase : _sqlSelectDowntimeCode4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DOWNTIMEID", downtimeid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_DOWNTIMECODE", $"{downtimeid},{siteid}"));
		}
		Downtimecode? result = ContextManager.DirectEntityQuery<Downtimecode>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{downtimeid},{siteid}");
		}
		return result;
	}

	public static int UpsertDowntimeCode(IDbContext dbContext, RequestType requestType, Downtimecode[] downtimeCodeList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateDowntimeCodeInternal(dbContext, downtimeCodeList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateDowntimeCode(dbContext, downtimeCodeList, optionSet, saveHist), 
			RequestType.DELETE => DeleteDowntimeCode(dbContext, downtimeCodeList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteDowntimeCode(dbContext, downtimeCodeList, optionSet, saveHist), 
			_ => RealDeleteDowntimeCode(dbContext, downtimeCodeList, optionSet, saveHist), 
		};
	}

	private static int CreateDowntimeCodeInternal(IDbContext dbContext, Downtimecode[] downtimeCodeList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("downtimeCodeList", downtimeCodeList);
		string text = "CreateDowntimeCode";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Downtimecode> list = new List<Downtimecode>();
		foreach (Downtimecode obj in downtimeCodeList)
		{
			Downtimecode downtimecode = new Downtimecode();
			obj.CopyColumsTo(downtimecode);
			downtimecode.Activity = text;
			downtimecode.CheckEntityUsable();
			obj.CopyCommonField(downtimecode, systemTime, dbContext.Tid, isCreate: true);
			list.Add(downtimecode);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateDowntimeCode(IDbContext dbContext, Downtimecode[] downtimeCodeList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("downtimeCodeList", downtimeCodeList);
		string text = "UpdateDowntimeCode";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Downtimecode> list = new List<Downtimecode>();
		foreach (Downtimecode downtimecode in downtimeCodeList)
		{
			Downtimecode downtimeCode4Update = GetDowntimeCode4Update(dbContext, downtimecode.Downtimeid, downtimecode.Siteid);
			if (downtimeCode4Update == null)
			{
				throw new EntityNotFoundException(typeof(Downtimecode), $"{downtimecode.Downtimeid},{downtimecode.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Downtimecode), $"{downtimecode.Downtimeid},{downtimecode.Siteid}", downtimeCode4Update.Isusable);
			string activity = downtimeCode4Update.Activity;
			string customactivity = downtimeCode4Update.Customactivity;
			string isusable = downtimeCode4Update.Isusable;
			DateTime? createtime = downtimeCode4Update.Createtime;
			string creator = downtimeCode4Update.Creator;
			downtimecode.CopyColumsTo(downtimeCode4Update);
			downtimeCode4Update.Prevactivity = activity;
			downtimeCode4Update.Prevcustomactivity = customactivity;
			downtimeCode4Update.Creator = creator;
			downtimeCode4Update.Createtime = createtime;
			downtimeCode4Update.Isusable = isusable;
			downtimeCode4Update.Activity = text;
			downtimecode.CopyCommonField(downtimeCode4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(downtimeCode4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteDowntimeCode(IDbContext dbContext, Downtimecode[] downtimeCodeList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("downtimeCodeList", downtimeCodeList);
		string text = "DeleteDowntimeCode";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Downtimecode> list = new List<Downtimecode>();
		foreach (Downtimecode downtimecode in downtimeCodeList)
		{
			Downtimecode downtimeCode4Update = GetDowntimeCode4Update(dbContext, downtimecode.Downtimeid, downtimecode.Siteid);
			if (downtimeCode4Update == null)
			{
				throw new EntityNotFoundException(typeof(Downtimecode), $"{downtimecode.Downtimeid},{downtimecode.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Downtimecode), $"{downtimecode.Downtimeid},{downtimecode.Siteid}", downtimeCode4Update.Isusable);
			downtimeCode4Update.Isusable = "UnUsable";
			downtimecode.CopyCommonFieldUpdatePrev(downtimeCode4Update, systemTime, dbContext.Tid, text);
			downtimecode.CopyExtensionCollection(downtimeCode4Update);
			list.Add(downtimeCode4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteDowntimeCode(IDbContext dbContext, Downtimecode[] downtimeCodeList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("downtimeCodeList", downtimeCodeList);
		string text = "UnDeleteDowntimeCode";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Downtimecode> list = new List<Downtimecode>();
		foreach (Downtimecode downtimecode in downtimeCodeList)
		{
			Downtimecode downtimeCode4Update = GetDowntimeCode4Update(dbContext, downtimecode.Downtimeid, downtimecode.Siteid);
			if (downtimeCode4Update == null)
			{
				throw new EntityNotFoundException(typeof(Downtimecode), $"{downtimecode.Downtimeid},{downtimecode.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Downtimecode), $"{downtimecode.Downtimeid},{downtimecode.Siteid}", downtimeCode4Update.Isusable);
			downtimeCode4Update.Isusable = "Usable";
			downtimecode.CopyCommonFieldUpdatePrev(downtimeCode4Update, systemTime, dbContext.Tid, text);
			downtimecode.CopyExtensionCollection(downtimeCode4Update);
			list.Add(downtimeCode4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteDowntimeCode(IDbContext dbContext, Downtimecode[] downtimeCodeList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("downtimeCodeList", downtimeCodeList);
		string text = "RealDeleteDowntimeCode";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Downtimecode> list = new List<Downtimecode>();
		foreach (Downtimecode downtimecode in downtimeCodeList)
		{
			Downtimecode downtimeCode4Update = GetDowntimeCode4Update(dbContext, downtimecode.Downtimeid, downtimecode.Siteid);
			if (downtimeCode4Update == null)
			{
				throw new EntityNotFoundException(typeof(Downtimecode), $"{downtimecode.Downtimeid},{downtimecode.Siteid}");
			}
			downtimecode.CopyCommonFieldUpdatePrev(downtimeCode4Update, systemTime, dbContext.Tid, text);
			downtimecode.CopyExtensionCollection(downtimeCode4Update);
			list.Add(downtimeCode4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
