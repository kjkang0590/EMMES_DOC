using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.QMS;

[MESAPI]
public class INSPRESULT
{
	private static string _sqlGetInspResultSqlDatabase = "SELECT * FROM CIM_INSPRESULT WHERE INSPREQNO=@INSPREQNO AND INSPTARGET=@INSPTARGET AND INSPLOTID=@INSPLOTID AND INSPDEFINITIONITEMSPECSYSID=@INSPDEFINITIONITEMSPECSYSID AND REPEATCOUNT=@REPEATCOUNT AND SITEID=@SITEID";

	private static string _sqlGetInspResult4UpdateSqlDatabase = "SELECT * FROM CIM_INSPRESULT WITH(UPDLOCK) WHERE INSPREQNO=@INSPREQNO AND INSPTARGET=@INSPTARGET AND INSPLOTID=@INSPLOTID AND INSPDEFINITIONITEMSPECSYSID=@INSPDEFINITIONITEMSPECSYSID AND REPEATCOUNT=@REPEATCOUNT AND SITEID=@SITEID";

	private static string _sqlSelectInspResultSqlDatabase = "SELECT * FROM CIM_INSPRESULT WHERE INSPREQNO=@INSPREQNO AND INSPTARGET=@INSPTARGET AND INSPLOTID=@INSPLOTID AND INSPDEFINITIONITEMSPECSYSID=@INSPDEFINITIONITEMSPECSYSID AND REPEATCOUNT=@REPEATCOUNT AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectInspResult4UpdateSqlDatabase = "SELECT * FROM CIM_INSPRESULT WITH(UPDLOCK) WHERE INSPREQNO=@INSPREQNO AND INSPTARGET=@INSPTARGET AND INSPLOTID=@INSPLOTID AND INSPDEFINITIONITEMSPECSYSID=@INSPDEFINITIONITEMSPECSYSID AND REPEATCOUNT=@REPEATCOUNT AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetInspResultOracleDatabase = "SELECT * FROM CIM_INSPRESULT WHERE INSPREQNO=:INSPREQNO AND INSPTARGET=:INSPTARGET AND INSPLOTID=:INSPLOTID AND INSPDEFINITIONITEMSPECSYSID=:INSPDEFINITIONITEMSPECSYSID AND REPEATCOUNT=:REPEATCOUNT AND SITEID=:SITEID";

	private static string _sqlGetInspResult4UpdateOracleDatabase = "SELECT * FROM CIM_INSPRESULT WHERE INSPREQNO=:INSPREQNO AND INSPTARGET=:INSPTARGET AND INSPLOTID=:INSPLOTID AND INSPDEFINITIONITEMSPECSYSID=:INSPDEFINITIONITEMSPECSYSID AND REPEATCOUNT=:REPEATCOUNT AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectInspResultOracleDatabase = "SELECT * FROM CIM_INSPRESULT WHERE INSPREQNO=:INSPREQNO AND INSPTARGET=:INSPTARGET AND INSPLOTID=:INSPLOTID AND INSPDEFINITIONITEMSPECSYSID=:INSPDEFINITIONITEMSPECSYSID AND REPEATCOUNT=:REPEATCOUNT AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectInspResult4UpdateOracleDatabase = "SELECT * FROM CIM_INSPRESULT WHERE INSPREQNO=:INSPREQNO AND INSPTARGET=:INSPTARGET AND INSPLOTID=:INSPLOTID AND INSPDEFINITIONITEMSPECSYSID=:INSPDEFINITIONITEMSPECSYSID AND REPEATCOUNT=:REPEATCOUNT AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Inspresult);

	private static string _sqlSelectInspResultListByLotidRepeatcountSqlDatabase = "SELECT * FROM CIM_INSPRESULT WHERE INSPREQNO=@INSPREQNO AND INSPLOTID=@INSPLOTID AND REPEATCOUNT=@REPEATCOUNT AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectInspResultListByLotidRepeatcountOracleDatabase = "SELECT * FROM CIM_INSPRESULT WHERE INSPREQNO=:INSPREQNO AND INSPLOTID=:INSPLOTID AND REPEATCOUNT=:REPEATCOUNT AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectInspResultListByRepeatcountSqlDatabase = "SELECT * FROM CIM_INSPRESULT WHERE INSPREQNO=@INSPREQNO AND REPEATCOUNT=@REPEATCOUNT AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectInspResultListByRepeatcountOracleDatabase = "SELECT * FROM CIM_INSPRESULT WHERE INSPREQNO=:INSPREQNO AND REPEATCOUNT=:REPEATCOUNT AND SITEID=:SITEID AND ISUSABLE='Usable'";

	public static Inspresult GetInspResult(IDbContext dbContext, string inspreqno, string insptarget, string insplotid, string inspdefinitionitemspecsysid, int repeatcount, string siteid)
	{
		string apiName = "GetInspResult";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspreqno},{insptarget},{insplotid},{inspdefinitionitemspecsysid},{repeatcount},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetInspResultSqlDatabase : _sqlGetInspResultOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPREQNO", inspreqno, typeOfThis));
		list.Add(dbContext.CreateParameter("INSPTARGET", insptarget, typeOfThis));
		list.Add(dbContext.CreateParameter("INSPLOTID", insplotid, typeOfThis));
		list.Add(dbContext.CreateParameter("INSPDEFINITIONITEMSPECSYSID", inspdefinitionitemspecsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_INSPRESULT", $"{inspreqno},{insptarget},{insplotid},{inspdefinitionitemspecsysid},{repeatcount},{siteid}"));
		}
		Inspresult result = ContextManager.DirectEntityQuery<Inspresult>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspreqno},{insptarget},{insplotid},{inspdefinitionitemspecsysid},{repeatcount},{siteid}");
		}
		return result;
	}

	public static Inspresult GetInspResult4Update(IDbContext dbContext, string inspreqno, string insptarget, string insplotid, string inspdefinitionitemspecsysid, int repeatcount, string siteid)
	{
		string apiName = "GetInspResult4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspreqno},{insptarget},{insplotid},{inspdefinitionitemspecsysid},{repeatcount},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetInspResult4UpdateSqlDatabase : _sqlGetInspResult4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPREQNO", inspreqno, typeOfThis));
		list.Add(dbContext.CreateParameter("INSPTARGET", insptarget, typeOfThis));
		list.Add(dbContext.CreateParameter("INSPLOTID", insplotid, typeOfThis));
		list.Add(dbContext.CreateParameter("INSPDEFINITIONITEMSPECSYSID", inspdefinitionitemspecsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_INSPRESULT", $"{inspreqno},{insptarget},{insplotid},{inspdefinitionitemspecsysid},{repeatcount},{siteid}"));
		}
		Inspresult result = ContextManager.DirectEntityQuery<Inspresult>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspreqno},{insptarget},{insplotid},{inspdefinitionitemspecsysid},{repeatcount},{siteid}");
		}
		return result;
	}

	public static Inspresult SelectInspResult(IDbContext dbContext, string inspreqno, string insptarget, string insplotid, string inspdefinitionitemspecsysid, int repeatcount, string siteid)
	{
		string apiName = "SelectInspResult";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspreqno},{insptarget},{insplotid},{inspdefinitionitemspecsysid},{repeatcount},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectInspResultSqlDatabase : _sqlSelectInspResultOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPREQNO", inspreqno, typeOfThis));
		list.Add(dbContext.CreateParameter("INSPTARGET", insptarget, typeOfThis));
		list.Add(dbContext.CreateParameter("INSPLOTID", insplotid, typeOfThis));
		list.Add(dbContext.CreateParameter("INSPDEFINITIONITEMSPECSYSID", inspdefinitionitemspecsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_INSPRESULT", $"{inspreqno},{insptarget},{insplotid},{inspdefinitionitemspecsysid},{repeatcount},{siteid}"));
		}
		Inspresult result = ContextManager.DirectEntityQuery<Inspresult>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspreqno},{insptarget},{insplotid},{inspdefinitionitemspecsysid},{repeatcount},{siteid}");
		}
		return result;
	}

	public static Inspresult SelectInspResult4Update(IDbContext dbContext, string inspreqno, string insptarget, string insplotid, string inspdefinitionitemspecsysid, int repeatcount, string siteid)
	{
		string apiName = "SelectInspResult4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspreqno},{insptarget},{insplotid},{inspdefinitionitemspecsysid},{repeatcount},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectInspResult4UpdateSqlDatabase : _sqlSelectInspResult4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPREQNO", inspreqno, typeOfThis));
		list.Add(dbContext.CreateParameter("INSPTARGET", insptarget, typeOfThis));
		list.Add(dbContext.CreateParameter("INSPLOTID", insplotid, typeOfThis));
		list.Add(dbContext.CreateParameter("INSPDEFINITIONITEMSPECSYSID", inspdefinitionitemspecsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_INSPRESULT", $"{inspreqno},{insptarget},{insplotid},{inspdefinitionitemspecsysid},{repeatcount},{siteid}"));
		}
		Inspresult result = ContextManager.DirectEntityQuery<Inspresult>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspreqno},{insptarget},{insplotid},{inspdefinitionitemspecsysid},{repeatcount},{siteid}");
		}
		return result;
	}

	public static IList<Inspresult> SelectInspResultListByLotidRepeatcount(IDbContext dbContext, string inspreqno, string inspLotId, int repeatcount, string siteid)
	{
		string apiName = "SelectInspResultListByLotidRepeatcount";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspreqno},{inspLotId},{repeatcount},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectInspResultListByLotidRepeatcountSqlDatabase : _sqlSelectInspResultListByLotidRepeatcountOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPREQNO", inspreqno, typeOfThis));
		list.Add(dbContext.CreateParameter("INSPLOTID", inspLotId, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_INSPRESULT", $"{inspreqno},{inspLotId},{repeatcount},{siteid}"));
		}
		IList<Inspresult> result = ContextManager.DirectEntityQuery<Inspresult>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspreqno},{inspLotId},{repeatcount},{siteid}");
		}
		return result;
	}

	public static IList<Inspresult> SelectInspResultListByRepeatcount(IDbContext dbContext, string inspreqno, int repeatcount, string siteid)
	{
		string apiName = "SelectInspResultListByRepeatcount";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspreqno},{repeatcount},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectInspResultListByRepeatcountSqlDatabase : _sqlSelectInspResultListByRepeatcountOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPREQNO", inspreqno, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_INSPRESULT", $"{inspreqno},{repeatcount},{siteid}"));
		}
		IList<Inspresult> result = ContextManager.DirectEntityQuery<Inspresult>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspreqno},{repeatcount},{siteid}");
		}
		return result;
	}

	public static int UpsertInspResult(IDbContext dbContext, RequestType requestType, Inspresult[] inspResultList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateInspResultInternal(dbContext, inspResultList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateInspResult(dbContext, inspResultList, optionSet, saveHist), 
			RequestType.DELETE => DeleteInspResult(dbContext, inspResultList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteInspResult(dbContext, inspResultList, optionSet, saveHist), 
			_ => RealDeleteInspResult(dbContext, inspResultList, optionSet, saveHist), 
		};
	}

	private static int CreateInspResultInternal(IDbContext dbContext, Inspresult[] inspResultList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspResultList", inspResultList);
		string text = "CreateInspResult";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspresult> list = new List<Inspresult>();
		foreach (Inspresult obj in inspResultList)
		{
			Inspresult inspresult = new Inspresult();
			obj.CopyColumsTo(inspresult);
			inspresult.Activity = text;
			inspresult.CheckEntityUsable();
			obj.CopyCommonField(inspresult, systemTime, dbContext.Tid, isCreate: true);
			list.Add(inspresult);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateInspResult(IDbContext dbContext, Inspresult[] inspResultList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspResultList", inspResultList);
		string text = "UpdateInspResult";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspresult> list = new List<Inspresult>();
		foreach (Inspresult inspresult in inspResultList)
		{
			Inspresult inspResult4Update = GetInspResult4Update(dbContext, inspresult.Inspreqno, inspresult.Insptarget, inspresult.Insplotid, inspresult.Inspdefinitionitemspecsysid, inspresult.Repeatcount, inspresult.Siteid);
			if (inspResult4Update == null)
			{
				throw new EntityNotFoundException(typeof(Inspresult), $"{inspresult.Inspreqno},{inspresult.Insptarget},{inspresult.Insplotid},{inspresult.Inspdefinitionitemspecsysid},{inspresult.Repeatcount},{inspresult.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Inspresult), $"{inspresult.Inspreqno},{inspresult.Insptarget},{inspresult.Insplotid},{inspresult.Inspdefinitionitemspecsysid},{inspresult.Repeatcount},{inspresult.Siteid}", inspResult4Update.Isusable);
			string activity = inspResult4Update.Activity;
			string customactivity = inspResult4Update.Customactivity;
			string isusable = inspResult4Update.Isusable;
			DateTime? createtime = inspResult4Update.Createtime;
			string creator = inspResult4Update.Creator;
			inspresult.CopyColumsTo(inspResult4Update);
			inspResult4Update.Prevactivity = activity;
			inspResult4Update.Prevcustomactivity = customactivity;
			inspResult4Update.Creator = creator;
			inspResult4Update.Createtime = createtime;
			inspResult4Update.Isusable = isusable;
			inspResult4Update.Activity = text;
			inspresult.CopyCommonField(inspResult4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(inspResult4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteInspResult(IDbContext dbContext, Inspresult[] inspResultList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspResultList", inspResultList);
		string text = "DeleteInspResult";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspresult> list = new List<Inspresult>();
		foreach (Inspresult inspresult in inspResultList)
		{
			Inspresult inspResult4Update = GetInspResult4Update(dbContext, inspresult.Inspreqno, inspresult.Insptarget, inspresult.Insplotid, inspresult.Inspdefinitionitemspecsysid, inspresult.Repeatcount, inspresult.Siteid);
			if (inspResult4Update == null)
			{
				throw new EntityNotFoundException(typeof(Inspresult), $"{inspresult.Inspreqno},{inspresult.Insptarget},{inspresult.Insplotid},{inspresult.Inspdefinitionitemspecsysid},{inspresult.Repeatcount},{inspresult.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Inspresult), $"{inspresult.Inspreqno},{inspresult.Insptarget},{inspresult.Insplotid},{inspresult.Inspdefinitionitemspecsysid},{inspresult.Repeatcount},{inspresult.Siteid}", inspResult4Update.Isusable);
			inspResult4Update.Isusable = "UnUsable";
			inspresult.CopyCommonFieldUpdatePrev(inspResult4Update, systemTime, dbContext.Tid, text);
			inspresult.CopyExtensionCollection(inspResult4Update);
			list.Add(inspResult4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteInspResult(IDbContext dbContext, Inspresult[] inspResultList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspResultList", inspResultList);
		string text = "UnDeleteInspResult";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspresult> list = new List<Inspresult>();
		foreach (Inspresult inspresult in inspResultList)
		{
			Inspresult inspResult4Update = GetInspResult4Update(dbContext, inspresult.Inspreqno, inspresult.Insptarget, inspresult.Insplotid, inspresult.Inspdefinitionitemspecsysid, inspresult.Repeatcount, inspresult.Siteid);
			if (inspResult4Update == null)
			{
				throw new EntityNotFoundException(typeof(Inspresult), $"{inspresult.Inspreqno},{inspresult.Insptarget},{inspresult.Insplotid},{inspresult.Inspdefinitionitemspecsysid},{inspresult.Repeatcount},{inspresult.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Inspresult), $"{inspresult.Inspreqno},{inspresult.Insptarget},{inspresult.Insplotid},{inspresult.Inspdefinitionitemspecsysid},{inspresult.Repeatcount},{inspresult.Siteid}", inspResult4Update.Isusable);
			inspResult4Update.Isusable = "Usable";
			inspresult.CopyCommonFieldUpdatePrev(inspResult4Update, systemTime, dbContext.Tid, text);
			inspresult.CopyExtensionCollection(inspResult4Update);
			list.Add(inspResult4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteInspResult(IDbContext dbContext, Inspresult[] inspResultList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspResultList", inspResultList);
		string text = "RealDeleteInspResult";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspresult> list = new List<Inspresult>();
		foreach (Inspresult inspresult in inspResultList)
		{
			Inspresult inspResult4Update = GetInspResult4Update(dbContext, inspresult.Inspreqno, inspresult.Insptarget, inspresult.Insplotid, inspresult.Inspdefinitionitemspecsysid, inspresult.Repeatcount, inspresult.Siteid);
			if (inspResult4Update == null)
			{
				throw new EntityNotFoundException(typeof(Inspresult), $"{inspresult.Inspreqno},{inspresult.Insptarget},{inspresult.Inspdefinitionitemspecsysid},{inspresult.Insplotid},{inspresult.Repeatcount},{inspresult.Siteid}");
			}
			inspresult.CopyCommonFieldUpdatePrev(inspResult4Update, systemTime, dbContext.Tid, text);
			inspresult.CopyExtensionCollection(inspResult4Update);
			list.Add(inspResult4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
