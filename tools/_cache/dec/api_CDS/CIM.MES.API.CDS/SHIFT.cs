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
public class SHIFT
{
	private static string _sqlGetShiftSqlDatabase = "SELECT * FROM CIM_SHIFT WHERE SHIFTID=@SHIFTID AND SITEID=@SITEID";

	private static string _sqlGetShift4UpdateSqlDatabase = "SELECT * FROM CIM_SHIFT WITH(UPDLOCK) WHERE SHIFTID=@SHIFTID AND SITEID=@SITEID";

	private static string _sqlSelectShiftSqlDatabase = "SELECT * FROM CIM_SHIFT WHERE SHIFTID=@SHIFTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectShift4UpdateSqlDatabase = "SELECT * FROM CIM_SHIFT WITH(UPDLOCK) WHERE SHIFTID=@SHIFTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetShiftOracleDatabase = "SELECT * FROM CIM_SHIFT WHERE SHIFTID=:SHIFTID AND SITEID=:SITEID";

	private static string _sqlGetShift4UpdateOracleDatabase = "SELECT * FROM CIM_SHIFT WHERE SHIFTID=:SHIFTID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectShiftOracleDatabase = "SELECT * FROM CIM_SHIFT WHERE SHIFTID=:SHIFTID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectShift4UpdateOracleDatabase = "SELECT * FROM CIM_SHIFT WHERE SHIFTID=:SHIFTID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Shift);

	public static Shift GetShift(IDbContext dbContext, string shiftid, string siteid)
	{
		string apiName = "GetShift";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{shiftid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetShiftSqlDatabase : _sqlGetShiftOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SHIFTID", shiftid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SHIFT", $"{shiftid},{siteid}"));
		}
		Shift? result = ContextManager.DirectEntityQuery<Shift>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{shiftid},{siteid}");
		}
		return result;
	}

	public static Shift GetShift4Update(IDbContext dbContext, string shiftid, string siteid)
	{
		string apiName = "GetShift4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{shiftid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetShift4UpdateSqlDatabase : _sqlGetShift4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SHIFTID", shiftid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_SHIFT", $"{shiftid},{siteid}"));
		}
		Shift? result = ContextManager.DirectEntityQuery<Shift>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{shiftid},{siteid}");
		}
		return result;
	}

	public static Shift SelectShift(IDbContext dbContext, string shiftid, string siteid)
	{
		string apiName = "SelectShift";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{shiftid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectShiftSqlDatabase : _sqlSelectShiftOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SHIFTID", shiftid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SHIFT", $"{shiftid},{siteid}"));
		}
		Shift? result = ContextManager.DirectEntityQuery<Shift>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{shiftid},{siteid}");
		}
		return result;
	}

	public static Shift SelectShift4Update(IDbContext dbContext, string shiftid, string siteid)
	{
		string apiName = "SelectShift4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{shiftid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectShift4UpdateSqlDatabase : _sqlSelectShift4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SHIFTID", shiftid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_SHIFT", $"{shiftid},{siteid}"));
		}
		Shift? result = ContextManager.DirectEntityQuery<Shift>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{shiftid},{siteid}");
		}
		return result;
	}

	public static int UpsertShift(IDbContext dbContext, RequestType requestType, Shift[] shiftList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateShiftInternal(dbContext, shiftList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateShift(dbContext, shiftList, optionSet, saveHist), 
			RequestType.DELETE => DeleteShift(dbContext, shiftList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteShift(dbContext, shiftList, optionSet, saveHist), 
			_ => RealDeleteShift(dbContext, shiftList, optionSet, saveHist), 
		};
	}

	private static int CreateShiftInternal(IDbContext dbContext, Shift[] shiftList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("shiftList", shiftList);
		string text = "CreateShift";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Shift> list = new List<Shift>();
		foreach (Shift obj in shiftList)
		{
			Shift shift = new Shift();
			obj.CopyColumsTo(shift);
			shift.Activity = text;
			shift.CheckEntityUsable();
			obj.CopyCommonField(shift, systemTime, dbContext.Tid, isCreate: true);
			list.Add(shift);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateShift(IDbContext dbContext, Shift[] shiftList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("shiftList", shiftList);
		string text = "UpdateShift";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Shift> list = new List<Shift>();
		foreach (Shift shift in shiftList)
		{
			Shift shift4Update = GetShift4Update(dbContext, shift.Shiftid, shift.Siteid);
			if (shift4Update == null)
			{
				throw new EntityNotFoundException(typeof(Shift), $"{shift.Shiftid},{shift.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Shift), $"{shift.Shiftid},{shift.Siteid}", shift4Update.Isusable);
			string activity = shift4Update.Activity;
			string customactivity = shift4Update.Customactivity;
			string isusable = shift4Update.Isusable;
			DateTime? createtime = shift4Update.Createtime;
			string creator = shift4Update.Creator;
			shift.CopyColumsTo(shift4Update);
			shift4Update.Prevactivity = activity;
			shift4Update.Prevcustomactivity = customactivity;
			shift4Update.Creator = creator;
			shift4Update.Createtime = createtime;
			shift4Update.Isusable = isusable;
			shift4Update.Activity = text;
			shift.CopyCommonField(shift4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(shift4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteShift(IDbContext dbContext, Shift[] shiftList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("shiftList", shiftList);
		string text = "DeleteShift";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Shift> list = new List<Shift>();
		foreach (Shift shift in shiftList)
		{
			Shift shift4Update = GetShift4Update(dbContext, shift.Shiftid, shift.Siteid);
			if (shift4Update == null)
			{
				throw new EntityNotFoundException(typeof(Shift), $"{shift.Shiftid},{shift.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Shift), $"{shift.Shiftid},{shift.Siteid}", shift4Update.Isusable);
			shift4Update.Isusable = "UnUsable";
			shift.CopyCommonFieldUpdatePrev(shift4Update, systemTime, dbContext.Tid, text);
			shift.CopyExtensionCollection(shift4Update);
			list.Add(shift4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteShift(IDbContext dbContext, Shift[] shiftList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("shiftList", shiftList);
		string text = "UnDeleteShift";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Shift> list = new List<Shift>();
		foreach (Shift shift in shiftList)
		{
			Shift shift4Update = GetShift4Update(dbContext, shift.Shiftid, shift.Siteid);
			if (shift4Update == null)
			{
				throw new EntityNotFoundException(typeof(Shift), $"{shift.Shiftid},{shift.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Shift), $"{shift.Shiftid},{shift.Siteid}", shift4Update.Isusable);
			shift4Update.Isusable = "Usable";
			shift.CopyCommonFieldUpdatePrev(shift4Update, systemTime, dbContext.Tid, text);
			shift.CopyExtensionCollection(shift4Update);
			list.Add(shift4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteShift(IDbContext dbContext, Shift[] shiftList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("shiftList", shiftList);
		string text = "RealDeleteShift";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Shift> list = new List<Shift>();
		foreach (Shift shift in shiftList)
		{
			Shift shift4Update = GetShift4Update(dbContext, shift.Shiftid, shift.Siteid);
			if (shift4Update == null)
			{
				throw new EntityNotFoundException(typeof(Shift), $"{shift.Shiftid},{shift.Siteid}");
			}
			shift.CopyCommonFieldUpdatePrev(shift4Update, systemTime, dbContext.Tid, text);
			shift.CopyExtensionCollection(shift4Update);
			list.Add(shift4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
