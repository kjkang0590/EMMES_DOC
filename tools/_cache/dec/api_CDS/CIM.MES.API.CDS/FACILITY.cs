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
public class FACILITY
{
	private static string _sqlGetFacilitySqlDatabase = "SELECT * FROM CIM_FACILITY WHERE FACILITYID=@FACILITYID AND SITEID=@SITEID";

	private static string _sqlGetFacility4UpdateSqlDatabase = "SELECT * FROM CIM_FACILITY WITH(UPDLOCK) WHERE FACILITYID=@FACILITYID AND SITEID=@SITEID";

	private static string _sqlSelectFacilitySqlDatabase = "SELECT * FROM CIM_FACILITY WHERE FACILITYID=@FACILITYID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectFacility4UpdateSqlDatabase = "SELECT * FROM CIM_FACILITY WITH(UPDLOCK) WHERE FACILITYID=@FACILITYID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetFacilityOracleDatabase = "SELECT * FROM CIM_FACILITY WHERE FACILITYID=:FACILITYID AND SITEID=:SITEID";

	private static string _sqlGetFacility4UpdateOracleDatabase = "SELECT * FROM CIM_FACILITY WHERE FACILITYID=:FACILITYID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectFacilityOracleDatabase = "SELECT * FROM CIM_FACILITY WHERE FACILITYID=:FACILITYID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectFacility4UpdateOracleDatabase = "SELECT * FROM CIM_FACILITY WHERE FACILITYID=:FACILITYID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Facility);

	private static string _sqlGetFacilityListSqlDatabase = "SELECT * FROM CIM_FACILITY WHERE FACILITYCLASSID=@FACILITYCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetFacilityListOracleDatabase = "SELECT * FROM CIM_FACILITY WHERE FACILITYCLASSID=:FACILITYCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	public static Facility GetFacility(IDbContext dbContext, string facilityid, string siteid)
	{
		string apiName = "GetFacility";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{facilityid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetFacilitySqlDatabase : _sqlGetFacilityOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("FACILITYID", facilityid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_FACILITY", $"{facilityid},{siteid}"));
		}
		Facility? result = ContextManager.DirectEntityQuery<Facility>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{facilityid},{siteid}");
		}
		return result;
	}

	public static Facility GetFacility4Update(IDbContext dbContext, string facilityid, string siteid)
	{
		string apiName = "GetFacility4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{facilityid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetFacility4UpdateSqlDatabase : _sqlGetFacility4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("FACILITYID", facilityid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_FACILITY", $"{facilityid},{siteid}"));
		}
		Facility? result = ContextManager.DirectEntityQuery<Facility>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{facilityid},{siteid}");
		}
		return result;
	}

	public static Facility SelectFacility(IDbContext dbContext, string facilityid, string siteid)
	{
		string apiName = "SelectFacility";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{facilityid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectFacilitySqlDatabase : _sqlSelectFacilityOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("FACILITYID", facilityid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_FACILITY", $"{facilityid},{siteid}"));
		}
		Facility? result = ContextManager.DirectEntityQuery<Facility>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{facilityid},{siteid}");
		}
		return result;
	}

	public static Facility SelectFacility4Update(IDbContext dbContext, string facilityid, string siteid)
	{
		string apiName = "SelectFacility4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{facilityid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectFacility4UpdateSqlDatabase : _sqlSelectFacility4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("FACILITYID", facilityid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_FACILITY", $"{facilityid},{siteid}"));
		}
		Facility? result = ContextManager.DirectEntityQuery<Facility>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{facilityid},{siteid}");
		}
		return result;
	}

	public static IList<Facility> SelectFacilityList(IDbContext dbContext, string facilityclassid, string siteid)
	{
		string apiName = "SelectFacilityList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{facilityclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetFacilityListSqlDatabase : _sqlGetFacilityListOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("FACILITYCLASSID", facilityclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		IList<Facility> source = ContextManager.DirectEntityQuery<Facility>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{facilityclassid},{siteid}");
		}
		return source.ToList();
	}

	public static int UpsertFacility(IDbContext dbContext, RequestType requestType, Facility[] facilityList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateFacilityInternal(dbContext, facilityList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateFacility(dbContext, facilityList, optionSet, saveHist), 
			RequestType.DELETE => DeleteFacility(dbContext, facilityList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteFacility(dbContext, facilityList, optionSet, saveHist), 
			_ => RealDeleteFacility(dbContext, facilityList, optionSet, saveHist), 
		};
	}

	private static int CreateFacilityInternal(IDbContext dbContext, Facility[] facilityList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("facilityList", facilityList);
		string text = "CreateFacility";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Facility> list = new List<Facility>();
		foreach (Facility obj in facilityList)
		{
			Facility facility = new Facility();
			obj.CopyColumsTo(facility);
			facility.Activity = text;
			facility.CheckEntityUsable();
			obj.CopyCommonField(facility, systemTime, dbContext.Tid, isCreate: true);
			list.Add(facility);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateFacility(IDbContext dbContext, Facility[] facilityList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("facilityList", facilityList);
		string text = "UpdateFacility";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Facility> list = new List<Facility>();
		foreach (Facility facility in facilityList)
		{
			Facility facility4Update = GetFacility4Update(dbContext, facility.Facilityid, facility.Siteid);
			if (facility4Update == null)
			{
				throw new EntityNotFoundException(typeof(Facility), $"{facility.Facilityid},{facility.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Facility), $"{facility.Facilityid},{facility.Siteid}", facility4Update.Isusable);
			string activity = facility4Update.Activity;
			string customactivity = facility4Update.Customactivity;
			string isusable = facility4Update.Isusable;
			DateTime? createtime = facility4Update.Createtime;
			string creator = facility4Update.Creator;
			facility.CopyColumsTo(facility4Update);
			facility4Update.Prevactivity = activity;
			facility4Update.Prevcustomactivity = customactivity;
			facility4Update.Creator = creator;
			facility4Update.Createtime = createtime;
			facility4Update.Isusable = isusable;
			facility4Update.Activity = text;
			facility.CopyCommonField(facility4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(facility4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteFacility(IDbContext dbContext, Facility[] facilityList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("facilityList", facilityList);
		string text = "DeleteFacility";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Facility> list = new List<Facility>();
		foreach (Facility facility in facilityList)
		{
			Facility facility4Update = GetFacility4Update(dbContext, facility.Facilityid, facility.Siteid);
			if (facility4Update == null)
			{
				throw new EntityNotFoundException(typeof(Facility), $"{facility.Facilityid},{facility.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Facility), $"{facility.Facilityid},{facility.Siteid}", facility4Update.Isusable);
			facility4Update.Isusable = "UnUsable";
			facility.CopyCommonFieldUpdatePrev(facility4Update, systemTime, dbContext.Tid, text);
			facility.CopyExtensionCollection(facility4Update);
			list.Add(facility4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteFacility(IDbContext dbContext, Facility[] facilityList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("facilityList", facilityList);
		string text = "UnDeleteFacility";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Facility> list = new List<Facility>();
		foreach (Facility facility in facilityList)
		{
			Facility facility4Update = GetFacility4Update(dbContext, facility.Facilityid, facility.Siteid);
			if (facility4Update == null)
			{
				throw new EntityNotFoundException(typeof(Facility), $"{facility.Facilityid},{facility.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Facility), $"{facility.Facilityid},{facility.Siteid}", facility4Update.Isusable);
			facility4Update.Isusable = "Usable";
			facility.CopyCommonFieldUpdatePrev(facility4Update, systemTime, dbContext.Tid, text);
			facility.CopyExtensionCollection(facility4Update);
			list.Add(facility4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteFacility(IDbContext dbContext, Facility[] facilityList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("facilityList", facilityList);
		string text = "RealDeleteFacility";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Facility> list = new List<Facility>();
		foreach (Facility facility in facilityList)
		{
			Facility facility4Update = GetFacility4Update(dbContext, facility.Facilityid, facility.Siteid);
			if (facility4Update == null)
			{
				throw new EntityNotFoundException(typeof(Facility), $"{facility.Facilityid},{facility.Siteid}");
			}
			facility.CopyCommonFieldUpdatePrev(facility4Update, systemTime, dbContext.Tid, text);
			facility.CopyExtensionCollection(facility4Update);
			list.Add(facility4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
