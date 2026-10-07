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
public class FACILITYCLASS
{
	private static string _sqlGetFacilityClassSqlDatabase = "SELECT * FROM CIM_FACILITYCLASS WHERE FACILITYCLASSID=@FACILITYCLASSID AND SITEID=@SITEID";

	private static string _sqlGetFacilityClass4UpdateSqlDatabase = "SELECT * FROM CIM_FACILITYCLASS WITH(UPDLOCK) WHERE FACILITYCLASSID=@FACILITYCLASSID AND SITEID=@SITEID";

	private static string _sqlSelectFacilityClassSqlDatabase = "SELECT * FROM CIM_FACILITYCLASS WHERE FACILITYCLASSID=@FACILITYCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectFacilityClass4UpdateSqlDatabase = "SELECT * FROM CIM_FACILITYCLASS WITH(UPDLOCK) WHERE FACILITYCLASSID=@FACILITYCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetFacilityClassOracleDatabase = "SELECT * FROM CIM_FACILITYCLASS WHERE FACILITYCLASSID=:FACILITYCLASSID AND SITEID=:SITEID";

	private static string _sqlGetFacilityClass4UpdateOracleDatabase = "SELECT * FROM CIM_FACILITYCLASS WHERE FACILITYCLASSID=:FACILITYCLASSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectFacilityClassOracleDatabase = "SELECT * FROM CIM_FACILITYCLASS WHERE FACILITYCLASSID=:FACILITYCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectFacilityClass4UpdateOracleDatabase = "SELECT * FROM CIM_FACILITYCLASS WHERE FACILITYCLASSID=:FACILITYCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Facilityclass);

	public static Facilityclass GetFacilityClass(IDbContext dbContext, string facilityclassid, string siteid)
	{
		string apiName = "GetFacilityClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{facilityclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetFacilityClassSqlDatabase : _sqlGetFacilityClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("FACILITYCLASSID", facilityclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_FACILITYCLASS", $"{facilityclassid},{siteid}"));
		}
		Facilityclass? result = ContextManager.DirectEntityQuery<Facilityclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{facilityclassid},{siteid}");
		}
		return result;
	}

	public static Facilityclass GetFacilityClass4Update(IDbContext dbContext, string facilityclassid, string siteid)
	{
		string apiName = "GetFacilityClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{facilityclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetFacilityClass4UpdateSqlDatabase : _sqlGetFacilityClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("FACILITYCLASSID", facilityclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_FACILITYCLASS", $"{facilityclassid},{siteid}"));
		}
		Facilityclass? result = ContextManager.DirectEntityQuery<Facilityclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{facilityclassid},{siteid}");
		}
		return result;
	}

	public static Facilityclass SelectFacilityClass(IDbContext dbContext, string facilityclassid, string siteid)
	{
		string apiName = "SelectFacilityClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{facilityclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectFacilityClassSqlDatabase : _sqlSelectFacilityClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("FACILITYCLASSID", facilityclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_FACILITYCLASS", $"{facilityclassid},{siteid}"));
		}
		Facilityclass? result = ContextManager.DirectEntityQuery<Facilityclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{facilityclassid},{siteid}");
		}
		return result;
	}

	public static Facilityclass SelectFacilityClass4Update(IDbContext dbContext, string facilityclassid, string siteid)
	{
		string apiName = "SelectFacilityClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{facilityclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectFacilityClass4UpdateSqlDatabase : _sqlSelectFacilityClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("FACILITYCLASSID", facilityclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_FACILITYCLASS", $"{facilityclassid},{siteid}"));
		}
		Facilityclass? result = ContextManager.DirectEntityQuery<Facilityclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{facilityclassid},{siteid}");
		}
		return result;
	}

	public static int UpsertFacilityClass(IDbContext dbContext, RequestType requestType, Facilityclass[] facilityClassList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateFacilityClassInternal(dbContext, facilityClassList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateFacilityClass(dbContext, facilityClassList, optionSet, saveHist), 
			RequestType.DELETE => DeleteFacilityClass(dbContext, facilityClassList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteFacilityClass(dbContext, facilityClassList, optionSet, saveHist), 
			_ => RealDeleteFacilityClass(dbContext, facilityClassList, optionSet, saveHist), 
		};
	}

	private static int CreateFacilityClassInternal(IDbContext dbContext, Facilityclass[] facilityClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("facilityClassList", facilityClassList);
		string text = "CreateFacilityClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Facilityclass> list = new List<Facilityclass>();
		foreach (Facilityclass obj in facilityClassList)
		{
			Facilityclass facilityclass = new Facilityclass();
			obj.CopyColumsTo(facilityclass);
			facilityclass.Activity = text;
			facilityclass.CheckEntityUsable();
			obj.CopyCommonField(facilityclass, systemTime, dbContext.Tid, isCreate: true);
			list.Add(facilityclass);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateFacilityClass(IDbContext dbContext, Facilityclass[] facilityClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("facilityClassList", facilityClassList);
		string text = "UpdateFacilityClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Facilityclass> list = new List<Facilityclass>();
		foreach (Facilityclass facilityclass in facilityClassList)
		{
			Facilityclass facilityClass4Update = GetFacilityClass4Update(dbContext, facilityclass.Facilityclassid, facilityclass.Siteid);
			if (facilityClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Facilityclass), $"{facilityclass.Facilityclassid},{facilityclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Facilityclass), $"{facilityclass.Facilityclassid},{facilityclass.Siteid}", facilityClass4Update.Isusable);
			string activity = facilityClass4Update.Activity;
			string customactivity = facilityClass4Update.Customactivity;
			string isusable = facilityClass4Update.Isusable;
			DateTime? createtime = facilityClass4Update.Createtime;
			string creator = facilityClass4Update.Creator;
			facilityclass.CopyColumsTo(facilityClass4Update);
			facilityClass4Update.Prevactivity = activity;
			facilityClass4Update.Prevcustomactivity = customactivity;
			facilityClass4Update.Creator = creator;
			facilityClass4Update.Createtime = createtime;
			facilityClass4Update.Isusable = isusable;
			facilityClass4Update.Activity = text;
			facilityclass.CopyCommonField(facilityClass4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(facilityClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteFacilityClass(IDbContext dbContext, Facilityclass[] facilityClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("facilityClassList", facilityClassList);
		string text = "DeleteFacilityClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Facilityclass> list = new List<Facilityclass>();
		foreach (Facilityclass facilityclass in facilityClassList)
		{
			Facilityclass facilityClass4Update = GetFacilityClass4Update(dbContext, facilityclass.Facilityclassid, facilityclass.Siteid);
			if (facilityClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Facilityclass), $"{facilityclass.Facilityclassid},{facilityclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Facilityclass), $"{facilityclass.Facilityclassid},{facilityclass.Siteid}", facilityClass4Update.Isusable);
			facilityClass4Update.Isusable = "UnUsable";
			facilityclass.CopyCommonFieldUpdatePrev(facilityClass4Update, systemTime, dbContext.Tid, text);
			facilityclass.CopyExtensionCollection(facilityClass4Update);
			list.Add(facilityClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteFacilityClass(IDbContext dbContext, Facilityclass[] facilityClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("facilityClassList", facilityClassList);
		string text = "UnDeleteFacilityClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Facilityclass> list = new List<Facilityclass>();
		foreach (Facilityclass facilityclass in facilityClassList)
		{
			Facilityclass facilityClass4Update = GetFacilityClass4Update(dbContext, facilityclass.Facilityclassid, facilityclass.Siteid);
			if (facilityClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Facilityclass), $"{facilityclass.Facilityclassid},{facilityclass.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Facilityclass), $"{facilityclass.Facilityclassid},{facilityclass.Siteid}", facilityClass4Update.Isusable);
			facilityClass4Update.Isusable = "Usable";
			facilityclass.CopyCommonFieldUpdatePrev(facilityClass4Update, systemTime, dbContext.Tid, text);
			facilityclass.CopyExtensionCollection(facilityClass4Update);
			list.Add(facilityClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteFacilityClass(IDbContext dbContext, Facilityclass[] facilityClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("facilityClassList", facilityClassList);
		string text = "RealDeleteFacilityClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Facilityclass> list = new List<Facilityclass>();
		foreach (Facilityclass facilityclass in facilityClassList)
		{
			Facilityclass facilityClass4Update = GetFacilityClass4Update(dbContext, facilityclass.Facilityclassid, facilityclass.Siteid);
			if (facilityClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Facilityclass), $"{facilityclass.Facilityclassid},{facilityclass.Siteid}");
			}
			facilityclass.CopyCommonFieldUpdatePrev(facilityClass4Update, systemTime, dbContext.Tid, text);
			facilityclass.CopyExtensionCollection(facilityClass4Update);
			list.Add(facilityClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
