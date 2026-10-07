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
public class LOTCARRIERREL
{
	private static string _sqlGetLotCarrierRelSqlDatabase = "SELECT * FROM CIM_LOTCARRIERREL WHERE LOTID=@LOTID AND CARRIERID=@CARRIERID AND SLOTPOSITION=@SLOTPOSITION AND SITEID=@SITEID";

	private static string _sqlGetLotCarrierRel4UpdateSqlDatabase = "SELECT * FROM CIM_LOTCARRIERREL WITH(UPDLOCK) WHERE LOTID=@LOTID AND CARRIERID=@CARRIERID AND SLOTPOSITION=@SLOTPOSITION AND SITEID=@SITEID";

	private static string _sqlSelectLotCarrierRelSqlDatabase = "SELECT * FROM CIM_LOTCARRIERREL WHERE LOTID=@LOTID AND CARRIERID=@CARRIERID AND SLOTPOSITION=@SLOTPOSITION AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLotCarrierRel4UpdateSqlDatabase = "SELECT * FROM CIM_LOTCARRIERREL WITH(UPDLOCK) WHERE LOTID=@LOTID AND CARRIERID=@CARRIERID AND SLOTPOSITION=@SLOTPOSITION AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetLotCarrierRelOracleDatabase = "SELECT * FROM CIM_LOTCARRIERREL WHERE LOTID=:LOTID AND CARRIERID=:CARRIERID AND SLOTPOSITION=:SLOTPOSITION AND SITEID=:SITEID";

	private static string _sqlGetLotCarrierRel4UpdateOracleDatabase = "SELECT * FROM CIM_LOTCARRIERREL WHERE LOTID=:LOTID AND CARRIERID=:CARRIERID AND SLOTPOSITION=:SLOTPOSITION AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectLotCarrierRelOracleDatabase = "SELECT * FROM CIM_LOTCARRIERREL WHERE LOTID=:LOTID AND CARRIERID=:CARRIERID AND SLOTPOSITION=:SLOTPOSITION AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLotCarrierRel4UpdateOracleDatabase = "SELECT * FROM CIM_LOTCARRIERREL WHERE LOTID=:LOTID AND CARRIERID=:CARRIERID AND SLOTPOSITION=:SLOTPOSITION AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Lotcarrierrel);

	private static string _sqlGetLotCarrierRelListByLotSqlDatabase = "SELECT * FROM CIM_LOTCARRIERREL WHERE LOTID=@LOTID AND SITEID=@SITEID";

	private static string _sqlGetLotCarrierRelListByLotOracleDatabase = "SELECT * FROM CIM_LOTCARRIERREL WHERE LOTID=:LOTID AND SITEID=:SITEID";

	private static string _sqlGetLotCarrierRelListByLotCarrierSqlDatabase = "SELECT * FROM CIM_LOTCARRIERREL WHERE LOTID=@LOTID AND CARRIERID=@CARRIERID AND SITEID=@SITEID";

	private static string _sqlGetLotCarrierRelListByLotCarrierOracleDatabase = "SELECT * FROM CIM_LOTCARRIERREL WHERE LOTID=:LOTID AND CARRIERID=:CARRIERID AND SITEID=:SITEID";

	private static string _sqlGetLotCarrierRelListByCarrierSqlDatabase = "SELECT * FROM CIM_LOTCARRIERREL WHERE CARRIERID=@CARRIERID AND SITEID=@SITEID";

	private static string _sqlSelectLotCarrierRelListByCarrierSqlDatabase = "SELECT * FROM CIM_LOTCARRIERREL WHERE CARRIERID=@CARRIERID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetLotCarrierRelListByCarrierOracleDatabase = "SELECT * FROM CIM_LOTCARRIERREL WHERE CARRIERID=:CARRIERID AND SITEID=:SITEID";

	private static string _sqlSelectLotCarrierRelListByCarrierOracleDatabase = "SELECT * FROM CIM_LOTCARRIERREL WHERE CARRIERID=:CARRIERID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	public static Lotcarrierrel GetLotCarrierRel(IDbContext dbContext, string lotid, string carrierid, int slotposition, string siteid)
	{
		string apiName = "GetLotCarrierRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{carrierid},{slotposition},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLotCarrierRelSqlDatabase : _sqlGetLotCarrierRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("CARRIERID", carrierid, typeOfThis));
		list.Add(dbContext.CreateParameter("SLOTPOSITION", slotposition, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOTCARRIERREL", $"{lotid},{carrierid},{slotposition},{siteid}"));
		}
		Lotcarrierrel result = ContextManager.DirectEntityQuery<Lotcarrierrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{carrierid},{slotposition},{siteid}");
		}
		return result;
	}

	public static Lotcarrierrel GetLotCarrierRel4Update(IDbContext dbContext, string lotid, string carrierid, int slotposition, string siteid)
	{
		string apiName = "GetLotCarrierRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{carrierid},{slotposition},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLotCarrierRel4UpdateSqlDatabase : _sqlGetLotCarrierRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("CARRIERID", carrierid, typeOfThis));
		list.Add(dbContext.CreateParameter("SLOTPOSITION", slotposition, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_LOTCARRIERREL", $"{lotid},{carrierid},{slotposition},{siteid}"));
		}
		Lotcarrierrel result = ContextManager.DirectEntityQuery<Lotcarrierrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{carrierid},{slotposition},{siteid}");
		}
		return result;
	}

	public static Lotcarrierrel SelectLotCarrierRel(IDbContext dbContext, string lotid, string carrierid, int slotposition, string siteid)
	{
		string apiName = "SelectLotCarrierRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{carrierid},{slotposition},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotCarrierRelSqlDatabase : _sqlSelectLotCarrierRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("CARRIERID", carrierid, typeOfThis));
		list.Add(dbContext.CreateParameter("SLOTPOSITION", slotposition, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOTCARRIERREL", $"{lotid},{carrierid},{slotposition},{siteid}"));
		}
		Lotcarrierrel result = ContextManager.DirectEntityQuery<Lotcarrierrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{carrierid},{slotposition},{siteid}");
		}
		return result;
	}

	public static Lotcarrierrel SelectLotCarrierRel4Update(IDbContext dbContext, string lotid, string carrierid, int slotposition, string siteid)
	{
		string apiName = "SelectLotCarrierRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{carrierid},{slotposition},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotCarrierRel4UpdateSqlDatabase : _sqlSelectLotCarrierRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("CARRIERID", carrierid, typeOfThis));
		list.Add(dbContext.CreateParameter("SLOTPOSITION", slotposition, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_LOTCARRIERREL", $"{lotid},{carrierid},{slotposition},{siteid}"));
		}
		Lotcarrierrel result = ContextManager.DirectEntityQuery<Lotcarrierrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{carrierid},{slotposition},{siteid}");
		}
		return result;
	}

	public static IList<Lotcarrierrel> GetLotCarrierRelList(IDbContext dbContext, string lotId, string siteId)
	{
		string apiName = "GetLotCarrierRelList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotId},{siteId}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLotCarrierRelListByLotSqlDatabase : _sqlGetLotCarrierRelListByLotOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotId, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOTCARRIERREL", $"{lotId},{siteId}"));
		}
		IList<Lotcarrierrel> result = ContextManager.DirectEntityQuery<Lotcarrierrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotId},{siteId}");
		}
		return result;
	}

	public static IList<Lotcarrierrel> GetLotCarrierRelList(IDbContext dbContext, string lotId, string carrierId, string siteId)
	{
		string apiName = "GetLotCarrierRelList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotId},{carrierId},{siteId}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLotCarrierRelListByLotCarrierSqlDatabase : _sqlGetLotCarrierRelListByLotCarrierOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotId, typeOfThis));
		list.Add(dbContext.CreateParameter("CARRIERID", carrierId, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOTCARRIERREL", $"{lotId},{carrierId},{siteId}"));
		}
		IList<Lotcarrierrel> result = ContextManager.DirectEntityQuery<Lotcarrierrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotId},{carrierId},{siteId}");
		}
		return result;
	}

	public static IList<Lotcarrierrel> GetLotCarrierRelListByCarrier(IDbContext dbContext, string carrierId, string siteId)
	{
		string apiName = "GetLotCarrierRelListByCarrier";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{carrierId},{siteId}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLotCarrierRelListByCarrierSqlDatabase : _sqlGetLotCarrierRelListByCarrierOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CARRIERID", carrierId, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOTCARRIERREL", $"{carrierId},{siteId}"));
		}
		IList<Lotcarrierrel> result = ContextManager.DirectEntityQuery<Lotcarrierrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{carrierId},{siteId}");
		}
		return result;
	}

	public static IList<Lotcarrierrel> SelectLotCarrierRelListByCarrier(IDbContext dbContext, string carrierId, string siteId)
	{
		string apiName = "SelectLotCarrierRelListByCarrier";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{carrierId},{siteId}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotCarrierRelListByCarrierSqlDatabase : _sqlSelectLotCarrierRelListByCarrierOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CARRIERID", carrierId, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOTCARRIERREL", $"{carrierId},{siteId}"));
		}
		IList<Lotcarrierrel> result = ContextManager.DirectEntityQuery<Lotcarrierrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{carrierId},{siteId}");
		}
		return result;
	}

	public static int UpsertLotCarrierRel(IDbContext dbContext, RequestType requestType, Lotcarrierrel[] lotCarrierRelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateLotCarrierRelInternal(dbContext, lotCarrierRelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateLotCarrierRel(dbContext, lotCarrierRelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteLotCarrierRel(dbContext, lotCarrierRelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteLotCarrierRel(dbContext, lotCarrierRelList, optionSet, saveHist), 
			_ => RealDeleteLotCarrierRel(dbContext, lotCarrierRelList, optionSet, saveHist), 
		};
	}

	private static int CreateLotCarrierRelInternal(IDbContext dbContext, Lotcarrierrel[] lotCarrierRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotCarrierRelList", lotCarrierRelList);
		string text = "CreateLotCarrierRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotcarrierrel> list = new List<Lotcarrierrel>();
		foreach (Lotcarrierrel obj in lotCarrierRelList)
		{
			Lotcarrierrel lotcarrierrel = new Lotcarrierrel();
			obj.CopyColumsTo(lotcarrierrel);
			lotcarrierrel.Activity = text;
			lotcarrierrel.CheckEntityUsable();
			obj.CopyCommonField(lotcarrierrel, systemTime, dbContext.Tid, isCreate: true);
			list.Add(lotcarrierrel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateLotCarrierRel(IDbContext dbContext, Lotcarrierrel[] lotCarrierRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotCarrierRelList", lotCarrierRelList);
		string text = "UpdateLotCarrierRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotcarrierrel> list = new List<Lotcarrierrel>();
		foreach (Lotcarrierrel lotcarrierrel in lotCarrierRelList)
		{
			Lotcarrierrel lotCarrierRel4Update = GetLotCarrierRel4Update(dbContext, lotcarrierrel.Lotid, lotcarrierrel.Carrierid, lotcarrierrel.Slotposition, lotcarrierrel.Siteid);
			if (lotCarrierRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lotcarrierrel), $"{lotcarrierrel.Lotid},{lotcarrierrel.Carrierid},{lotcarrierrel.Slotposition},{lotcarrierrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Lotcarrierrel), $"{lotcarrierrel.Lotid},{lotcarrierrel.Carrierid},{lotcarrierrel.Slotposition},{lotcarrierrel.Siteid}", lotCarrierRel4Update.Isusable);
			string activity = lotCarrierRel4Update.Activity;
			string customactivity = lotCarrierRel4Update.Customactivity;
			string isusable = lotCarrierRel4Update.Isusable;
			DateTime? createtime = lotCarrierRel4Update.Createtime;
			string creator = lotCarrierRel4Update.Creator;
			lotcarrierrel.CopyColumsTo(lotCarrierRel4Update);
			lotCarrierRel4Update.Prevactivity = activity;
			lotCarrierRel4Update.Prevcustomactivity = customactivity;
			lotCarrierRel4Update.Creator = creator;
			lotCarrierRel4Update.Createtime = createtime;
			lotCarrierRel4Update.Isusable = isusable;
			lotCarrierRel4Update.Activity = text;
			lotcarrierrel.CopyCommonField(lotCarrierRel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(lotCarrierRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteLotCarrierRel(IDbContext dbContext, Lotcarrierrel[] lotCarrierRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotCarrierRelList", lotCarrierRelList);
		string text = "DeleteLotCarrierRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotcarrierrel> list = new List<Lotcarrierrel>();
		foreach (Lotcarrierrel lotcarrierrel in lotCarrierRelList)
		{
			Lotcarrierrel lotCarrierRel4Update = GetLotCarrierRel4Update(dbContext, lotcarrierrel.Lotid, lotcarrierrel.Carrierid, lotcarrierrel.Slotposition, lotcarrierrel.Siteid);
			if (lotCarrierRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lotcarrierrel), $"{lotcarrierrel.Lotid},{lotcarrierrel.Carrierid},{lotcarrierrel.Slotposition},{lotcarrierrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Lotcarrierrel), $"{lotcarrierrel.Lotid},{lotcarrierrel.Carrierid},{lotcarrierrel.Slotposition},{lotcarrierrel.Siteid}", lotCarrierRel4Update.Isusable);
			lotCarrierRel4Update.Isusable = "UnUsable";
			lotcarrierrel.CopyCommonFieldUpdatePrev(lotCarrierRel4Update, systemTime, dbContext.Tid, text);
			lotcarrierrel.CopyExtensionCollection(lotCarrierRel4Update);
			list.Add(lotCarrierRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteLotCarrierRel(IDbContext dbContext, Lotcarrierrel[] lotCarrierRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotCarrierRelList", lotCarrierRelList);
		string text = "UnDeleteLotCarrierRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotcarrierrel> list = new List<Lotcarrierrel>();
		foreach (Lotcarrierrel lotcarrierrel in lotCarrierRelList)
		{
			Lotcarrierrel lotCarrierRel4Update = GetLotCarrierRel4Update(dbContext, lotcarrierrel.Lotid, lotcarrierrel.Carrierid, lotcarrierrel.Slotposition, lotcarrierrel.Siteid);
			if (lotCarrierRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lotcarrierrel), $"{lotcarrierrel.Lotid},{lotcarrierrel.Carrierid},{lotcarrierrel.Slotposition},{lotcarrierrel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Lotcarrierrel), $"{lotcarrierrel.Lotid},{lotcarrierrel.Carrierid},{lotcarrierrel.Slotposition},{lotcarrierrel.Siteid}", lotCarrierRel4Update.Isusable);
			lotCarrierRel4Update.Isusable = "Usable";
			lotcarrierrel.CopyCommonFieldUpdatePrev(lotCarrierRel4Update, systemTime, dbContext.Tid, text);
			lotcarrierrel.CopyExtensionCollection(lotCarrierRel4Update);
			list.Add(lotCarrierRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteLotCarrierRel(IDbContext dbContext, Lotcarrierrel[] lotCarrierRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotCarrierRelList", lotCarrierRelList);
		string text = "RealDeleteLotCarrierRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotcarrierrel> list = new List<Lotcarrierrel>();
		foreach (Lotcarrierrel lotcarrierrel in lotCarrierRelList)
		{
			Lotcarrierrel lotCarrierRel4Update = GetLotCarrierRel4Update(dbContext, lotcarrierrel.Lotid, lotcarrierrel.Carrierid, lotcarrierrel.Slotposition, lotcarrierrel.Siteid);
			if (lotCarrierRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lotcarrierrel), $"{lotcarrierrel.Lotid},{lotcarrierrel.Carrierid},{lotcarrierrel.Slotposition},{lotcarrierrel.Siteid}");
			}
			lotcarrierrel.CopyCommonFieldUpdatePrev(lotCarrierRel4Update, systemTime, dbContext.Tid, text);
			lotcarrierrel.CopyExtensionCollection(lotCarrierRel4Update);
			list.Add(lotCarrierRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	internal static string[] GetDistinctCarrierList(Lotcarrierrel[] lotCarrierRelList)
	{
		return lotCarrierRelList.Select((Lotcarrierrel rel) => rel.Carrierid).Distinct().ToArray();
	}

	internal static Lotcarrierrel[] GetCarrierrelListByCarrier(Lotcarrierrel[] lotCarrierRelList, string carrierId)
	{
		return lotCarrierRelList.Where((Lotcarrierrel rel) => rel.Carrierid == carrierId).ToArray();
	}
}
