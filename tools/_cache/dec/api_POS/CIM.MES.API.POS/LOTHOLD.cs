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
public class LOTHOLD
{
	private static string _sqlGetLotHoldSqlDatabase = "SELECT * FROM CIM_LOTHOLD WHERE LOTID=@LOTID AND HOLDCODE=@HOLDCODE AND SITEID=@SITEID";

	private static string _sqlGetLotHold4UpdateSqlDatabase = "SELECT * FROM CIM_LOTHOLD WITH(UPDLOCK) WHERE LOTID=@LOTID AND HOLDCODE=@HOLDCODE AND SITEID=@SITEID";

	private static string _sqlSelectLotHoldSqlDatabase = "SELECT * FROM CIM_LOTHOLD WHERE LOTID=@LOTID AND HOLDCODE=@HOLDCODE AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLotHold4UpdateSqlDatabase = "SELECT * FROM CIM_LOTHOLD WITH(UPDLOCK) WHERE LOTID=@LOTID AND HOLDCODE=@HOLDCODE AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetLotHoldOracleDatabase = "SELECT * FROM CIM_LOTHOLD WHERE LOTID=:LOTID AND HOLDCODE=:HOLDCODE AND SITEID=:SITEID";

	private static string _sqlGetLotHold4UpdateOracleDatabase = "SELECT * FROM CIM_LOTHOLD WHERE LOTID=:LOTID AND HOLDCODE=:HOLDCODE AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectLotHoldOracleDatabase = "SELECT * FROM CIM_LOTHOLD WHERE LOTID=:LOTID AND HOLDCODE=:HOLDCODE AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLotHold4UpdateOracleDatabase = "SELECT * FROM CIM_LOTHOLD WHERE LOTID=:LOTID AND HOLDCODE=:HOLDCODE AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Lothold);

	private static string _sqlGetLotHoldByLotSqlDatabase = "SELECT * FROM CIM_LOTHOLD WHERE LOTID=@LOTID AND SITEID=@SITEID";

	private static string _sqlGetLotHoldByLotOracleDatabase = "SELECT * FROM CIM_LOTHOLD WHERE LOTID=:LOTID AND SITEID=:SITEID";

	private static string _sqlGetLotHoldTotalCountSqlDatabase = "SELECT COUNT(1) FROM CIM_LOTHOLD WHERE LOTID=@LOTID AND SITEID=@SITEID";

	private static string _sqlGetLotHoldTotalCountOracleDatabase = "SELECT COUNT(1) FROM CIM_LOTHOLD WHERE LOTID=:LOTID AND SITEID=:SITEID";

	public static Lothold GetLotHold(IDbContext dbContext, string lotid, string holdcode, string siteid)
	{
		string apiName = "GetLotHold";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{holdcode},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLotHoldSqlDatabase : _sqlGetLotHoldOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("HOLDCODE", holdcode, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOTHOLD", $"{lotid},{holdcode},{siteid}"));
		}
		Lothold? result = ContextManager.DirectEntityQuery<Lothold>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{holdcode},{siteid}");
		}
		return result;
	}

	public static Lothold GetLotHold4Update(IDbContext dbContext, string lotid, string holdcode, string siteid)
	{
		string apiName = "GetLotHold4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{holdcode},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLotHold4UpdateSqlDatabase : _sqlGetLotHold4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("HOLDCODE", holdcode, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_LOTHOLD", $"{lotid},{holdcode},{siteid}"));
		}
		Lothold? result = ContextManager.DirectEntityQuery<Lothold>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{holdcode},{siteid}");
		}
		return result;
	}

	public static Lothold SelectLotHold(IDbContext dbContext, string lotid, string holdcode, string siteid)
	{
		string apiName = "SelectLotHold";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{holdcode},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotHoldSqlDatabase : _sqlSelectLotHoldOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("HOLDCODE", holdcode, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOTHOLD", $"{lotid},{holdcode},{siteid}"));
		}
		Lothold? result = ContextManager.DirectEntityQuery<Lothold>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{holdcode},{siteid}");
		}
		return result;
	}

	public static Lothold SelectLotHold4Update(IDbContext dbContext, string lotid, string holdcode, string siteid)
	{
		string apiName = "SelectLotHold4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{holdcode},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotHold4UpdateSqlDatabase : _sqlSelectLotHold4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("HOLDCODE", holdcode, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_LOTHOLD", $"{lotid},{holdcode},{siteid}"));
		}
		Lothold? result = ContextManager.DirectEntityQuery<Lothold>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{holdcode},{siteid}");
		}
		return result;
	}

	public static IList<Lothold> GetLotHoldList(IDbContext dbContext, string lotId, string siteId)
	{
		string apiName = "GetLotHoldList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotId},{siteId}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLotHoldByLotSqlDatabase : _sqlGetLotHoldByLotOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotId, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOTHOLD", $"{lotId},{siteId}"));
		}
		IList<Lothold> result = ContextManager.DirectEntityQuery<Lothold>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotId},{siteId}");
		}
		return result;
	}

	public static int GetLotHoldTotalCount(IDbContext dbContext, string lotId, string siteId)
	{
		string apiName = "GetLotHoldTotalCount";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotId},{siteId}");
		}
		string sqlStatement = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLotHoldTotalCountSqlDatabase : _sqlGetLotHoldTotalCountOracleDatabase);
		MesParameter[] mesParameters = new MesParameter[2]
		{
			dbContext.CreateParameter("LOTID", lotId, typeOfThis),
			dbContext.CreateParameter("SITEID", siteId, typeOfThis)
		};
		object obj = dbContext.ExecuteScalar(sqlStatement, mesParameters);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotId},{siteId}");
		}
		if (obj != null && obj != DBNull.Value)
		{
			return Convert.ToInt32(obj);
		}
		return 0;
	}

	public static int UpsertLotHold(IDbContext dbContext, RequestType requestType, Lothold[] lotHoldList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateLotHoldInternal(dbContext, lotHoldList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateLotHold(dbContext, lotHoldList, optionSet, saveHist), 
			RequestType.DELETE => DeleteLotHold(dbContext, lotHoldList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteLotHold(dbContext, lotHoldList, optionSet, saveHist), 
			_ => RealDeleteLotHold(dbContext, lotHoldList, optionSet, saveHist), 
		};
	}

	private static int CreateLotHoldInternal(IDbContext dbContext, Lothold[] lotHoldList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotHoldList", lotHoldList);
		string text = "CreateLotHold";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lothold> list = new List<Lothold>();
		foreach (Lothold obj in lotHoldList)
		{
			Lothold lothold = new Lothold();
			obj.CopyColumsTo(lothold);
			lothold.Activity = text;
			lothold.CheckEntityUsable();
			obj.CopyCommonField(lothold, systemTime, dbContext.Tid, isCreate: true);
			list.Add(lothold);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateLotHold(IDbContext dbContext, Lothold[] lotHoldList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotHoldList", lotHoldList);
		string text = "UpdateLotHold";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lothold> list = new List<Lothold>();
		foreach (Lothold lothold in lotHoldList)
		{
			Lothold lotHold4Update = GetLotHold4Update(dbContext, lothold.Lotid, lothold.Holdcode, lothold.Siteid);
			if (lotHold4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lothold), $"{lothold.Lotid},{lothold.Holdcode},{lothold.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Lothold), $"{lothold.Lotid},{lothold.Holdcode},{lothold.Siteid}", lotHold4Update.Isusable);
			string activity = lotHold4Update.Activity;
			string customactivity = lotHold4Update.Customactivity;
			string isusable = lotHold4Update.Isusable;
			DateTime? createtime = lotHold4Update.Createtime;
			string creator = lotHold4Update.Creator;
			lothold.CopyColumsTo(lotHold4Update);
			lotHold4Update.Prevactivity = activity;
			lotHold4Update.Prevcustomactivity = customactivity;
			lotHold4Update.Creator = creator;
			lotHold4Update.Createtime = createtime;
			lotHold4Update.Isusable = isusable;
			lotHold4Update.Activity = text;
			lothold.CopyCommonField(lotHold4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(lotHold4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteLotHold(IDbContext dbContext, Lothold[] lotHoldList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotHoldList", lotHoldList);
		string text = "DeleteLotHold";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lothold> list = new List<Lothold>();
		foreach (Lothold lothold in lotHoldList)
		{
			Lothold lotHold4Update = GetLotHold4Update(dbContext, lothold.Lotid, lothold.Holdcode, lothold.Siteid);
			if (lotHold4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lothold), $"{lothold.Lotid},{lothold.Holdcode},{lothold.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Lothold), $"{lothold.Lotid},{lothold.Holdcode},{lothold.Siteid}", lotHold4Update.Isusable);
			lotHold4Update.Isusable = "UnUsable";
			lothold.CopyCommonFieldUpdatePrev(lotHold4Update, systemTime, dbContext.Tid, text);
			lothold.CopyExtensionCollection(lotHold4Update);
			list.Add(lotHold4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteLotHold(IDbContext dbContext, Lothold[] lotHoldList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotHoldList", lotHoldList);
		string text = "UnDeleteLotHold";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lothold> list = new List<Lothold>();
		foreach (Lothold lothold in lotHoldList)
		{
			Lothold lotHold4Update = GetLotHold4Update(dbContext, lothold.Lotid, lothold.Holdcode, lothold.Siteid);
			if (lotHold4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lothold), $"{lothold.Lotid},{lothold.Holdcode},{lothold.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Lothold), $"{lothold.Lotid},{lothold.Holdcode},{lothold.Siteid}", lotHold4Update.Isusable);
			lotHold4Update.Isusable = "Usable";
			lothold.CopyCommonFieldUpdatePrev(lotHold4Update, systemTime, dbContext.Tid, text);
			lothold.CopyExtensionCollection(lotHold4Update);
			list.Add(lotHold4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteLotHold(IDbContext dbContext, Lothold[] lotHoldList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotHoldList", lotHoldList);
		string text = "RealDeleteLotHold";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lothold> list = new List<Lothold>();
		foreach (Lothold lothold in lotHoldList)
		{
			Lothold lotHold4Update = GetLotHold4Update(dbContext, lothold.Lotid, lothold.Holdcode, lothold.Siteid);
			if (lotHold4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lothold), $"{lothold.Lotid},{lothold.Holdcode},{lothold.Siteid}");
			}
			lothold.CopyCommonFieldUpdatePrev(lotHold4Update, systemTime, dbContext.Tid, text);
			lothold.CopyExtensionCollection(lotHold4Update);
			list.Add(lotHold4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
