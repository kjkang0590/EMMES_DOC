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
public class UNIT
{
	private static string _sqlGetUnitSqlDatabase = "SELECT * FROM CIM_UNIT WHERE UNITID=@UNITID AND SITEID=@SITEID";

	private static string _sqlGetUnit4UpdateSqlDatabase = "SELECT * FROM CIM_UNIT WITH(UPDLOCK) WHERE UNITID=@UNITID AND SITEID=@SITEID";

	private static string _sqlSelectUnitSqlDatabase = "SELECT * FROM CIM_UNIT WHERE UNITID=@UNITID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectUnit4UpdateSqlDatabase = "SELECT * FROM CIM_UNIT WITH(UPDLOCK) WHERE UNITID=@UNITID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetUnitOracleDatabase = "SELECT * FROM CIM_UNIT WHERE UNITID=:UNITID AND SITEID=:SITEID";

	private static string _sqlGetUnit4UpdateOracleDatabase = "SELECT * FROM CIM_UNIT WHERE UNITID=:UNITID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectUnitOracleDatabase = "SELECT * FROM CIM_UNIT WHERE UNITID=:UNITID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectUnit4UpdateOracleDatabase = "SELECT * FROM CIM_UNIT WHERE UNITID=:UNITID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Unit);

	public static Unit GetUnit(IDbContext dbContext, string unitid, string siteid)
	{
		string apiName = "GetUnit";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{unitid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetUnitSqlDatabase : _sqlGetUnitOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("UNITID", unitid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_UNIT", $"{unitid},{siteid}"));
		}
		Unit? result = ContextManager.DirectEntityQuery<Unit>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{unitid},{siteid}");
		}
		return result;
	}

	public static Unit GetUnit4Update(IDbContext dbContext, string unitid, string siteid)
	{
		string apiName = "GetUnit4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{unitid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetUnit4UpdateSqlDatabase : _sqlGetUnit4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("UNITID", unitid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_UNIT", $"{unitid},{siteid}"));
		}
		Unit? result = ContextManager.DirectEntityQuery<Unit>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{unitid},{siteid}");
		}
		return result;
	}

	public static Unit SelectUnit(IDbContext dbContext, string unitid, string siteid)
	{
		string apiName = "SelectUnit";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{unitid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectUnitSqlDatabase : _sqlSelectUnitOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("UNITID", unitid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_UNIT", $"{unitid},{siteid}"));
		}
		Unit? result = ContextManager.DirectEntityQuery<Unit>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{unitid},{siteid}");
		}
		return result;
	}

	public static Unit SelectUnit4Update(IDbContext dbContext, string unitid, string siteid)
	{
		string apiName = "SelectUnit4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{unitid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectUnit4UpdateSqlDatabase : _sqlSelectUnit4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("UNITID", unitid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_UNIT", $"{unitid},{siteid}"));
		}
		Unit? result = ContextManager.DirectEntityQuery<Unit>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{unitid},{siteid}");
		}
		return result;
	}

	public static int UpsertUnit(IDbContext dbContext, RequestType requestType, Unit[] unitList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateUnitInternal(dbContext, unitList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateUnit(dbContext, unitList, optionSet, saveHist), 
			RequestType.DELETE => DeleteUnit(dbContext, unitList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteUnit(dbContext, unitList, optionSet, saveHist), 
			_ => RealDeleteUnit(dbContext, unitList, optionSet, saveHist), 
		};
	}

	private static int CreateUnitInternal(IDbContext dbContext, Unit[] unitList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("unitList", unitList);
		string text = "CreateUnit";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Unit> list = new List<Unit>();
		foreach (Unit obj in unitList)
		{
			Unit unit = new Unit();
			obj.CopyColumsTo(unit);
			unit.Activity = text;
			unit.CheckEntityUsable();
			obj.CopyCommonField(unit, systemTime, dbContext.Tid, isCreate: true);
			list.Add(unit);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateUnit(IDbContext dbContext, Unit[] unitList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("unitList", unitList);
		string text = "UpdateUnit";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Unit> list = new List<Unit>();
		foreach (Unit unit in unitList)
		{
			Unit unit4Update = GetUnit4Update(dbContext, unit.Unitid, unit.Siteid);
			if (unit4Update == null)
			{
				throw new EntityNotFoundException(typeof(Unit), $"{unit.Unitid},{unit.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Unit), $"{unit.Unitid},{unit.Siteid}", unit4Update.Isusable);
			string activity = unit4Update.Activity;
			string customactivity = unit4Update.Customactivity;
			string isusable = unit4Update.Isusable;
			DateTime? createtime = unit4Update.Createtime;
			string creator = unit4Update.Creator;
			unit.CopyColumsTo(unit4Update);
			unit4Update.Prevactivity = activity;
			unit4Update.Prevcustomactivity = customactivity;
			unit4Update.Creator = creator;
			unit4Update.Createtime = createtime;
			unit4Update.Isusable = isusable;
			unit4Update.Activity = text;
			unit.CopyCommonField(unit4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(unit4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteUnit(IDbContext dbContext, Unit[] unitList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("unitList", unitList);
		string text = "DeleteUnit";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Unit> list = new List<Unit>();
		foreach (Unit unit in unitList)
		{
			Unit unit4Update = GetUnit4Update(dbContext, unit.Unitid, unit.Siteid);
			if (unit4Update == null)
			{
				throw new EntityNotFoundException(typeof(Unit), $"{unit.Unitid},{unit.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Unit), $"{unit.Unitid},{unit.Siteid}", unit4Update.Isusable);
			unit4Update.Isusable = "UnUsable";
			unit.CopyCommonFieldUpdatePrev(unit4Update, systemTime, dbContext.Tid, text);
			unit.CopyExtensionCollection(unit4Update);
			list.Add(unit4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteUnit(IDbContext dbContext, Unit[] unitList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("unitList", unitList);
		string text = "UnDeleteUnit";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Unit> list = new List<Unit>();
		foreach (Unit unit in unitList)
		{
			Unit unit4Update = GetUnit4Update(dbContext, unit.Unitid, unit.Siteid);
			if (unit4Update == null)
			{
				throw new EntityNotFoundException(typeof(Unit), $"{unit.Unitid},{unit.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Unit), $"{unit.Unitid},{unit.Siteid}", unit4Update.Isusable);
			unit4Update.Isusable = "Usable";
			unit.CopyCommonFieldUpdatePrev(unit4Update, systemTime, dbContext.Tid, text);
			unit.CopyExtensionCollection(unit4Update);
			list.Add(unit4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteUnit(IDbContext dbContext, Unit[] unitList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("unitList", unitList);
		string text = "RealDeleteUnit";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Unit> list = new List<Unit>();
		foreach (Unit unit in unitList)
		{
			Unit unit4Update = GetUnit4Update(dbContext, unit.Unitid, unit.Siteid);
			if (unit4Update == null)
			{
				throw new EntityNotFoundException(typeof(Unit), $"{unit.Unitid},{unit.Siteid}");
			}
			unit.CopyCommonFieldUpdatePrev(unit4Update, systemTime, dbContext.Tid, text);
			unit.CopyExtensionCollection(unit4Update);
			list.Add(unit4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
