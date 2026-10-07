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
public class LOTFUTUREACTION
{
	private static string _sqlGetLotFutureActionCountSqlDatabase = "SELECT COUNT(*) FROM CIM_LOTFUTUREACTION  WHERE LOTID=@LOTID AND SITEID=@SITEID AND ISUSABLE='Usable' AND (CASE WHEN (((@ACTIONTYPE IS NULL) OR (@ACTIONTYPE='')) OR (ACTIONTYPE=@ACTIONTYPE)) THEN 1 ELSE 0 END) = 1 AND (CASE WHEN (((@ACTIONPRODUCTDEFINITIONID IS NULL) OR (@ACTIONPRODUCTDEFINITIONID='')) OR (ACTIONPRODUCTDEFINITIONID=@ACTIONPRODUCTDEFINITIONID)) THEN 1 ELSE 0 END) = 1 AND (CASE WHEN (((@ACTIONPROCESSDEFINITIONID IS NULL) OR (@ACTIONPROCESSDEFINITIONID='')) OR (ACTIONPROCESSDEFINITIONID=@ACTIONPROCESSDEFINITIONID)) THEN 1 ELSE 0 END) = 1 AND (CASE WHEN (((@ACTIONSUBPROCESSDEFINITIONID IS NULL) OR (@ACTIONSUBPROCESSDEFINITIONID='')) OR (ACTIONSUBPROCESSDEFINITIONID=@ACTIONSUBPROCESSDEFINITIONID)) THEN 1 ELSE 0 END) = 1 AND (CASE WHEN (((@ACTIONPROCESSSEGMENTID IS NULL) OR (@ACTIONPROCESSSEGMENTID='')) OR (ACTIONPROCESSSEGMENTID=@ACTIONPROCESSSEGMENTID)) THEN 1 ELSE 0 END) = 1";

	private static string _sqlGetLotFutureActionCountOracleDatabase = "SELECT COUNT(*) FROM CIM_LOTFUTUREACTION WHERE LOTID=:LOTID AND SITEID=:SITEID AND ISUSABLE='Usable' AND (CASE WHEN (((:ACTIONTYPE IS NULL) OR (:ACTIONTYPE='')) OR (ACTIONTYPE=:ACTIONTYPE)) THEN 1 ELSE 0 END) = 1 AND (CASE WHEN (((:ACTIONPRODUCTDEFINITIONID IS NULL) OR (:ACTIONPRODUCTDEFINITIONID='')) OR (ACTIONPRODUCTDEFINITIONID=:ACTIONPRODUCTDEFINITIONID)) THEN 1 ELSE 0 END) = 1 AND (CASE WHEN (((:ACTIONPROCESSDEFINITIONID IS NULL) OR (:ACTIONPROCESSDEFINITIONID='')) OR (ACTIONPROCESSDEFINITIONID=:ACTIONPROCESSDEFINITIONID)) THEN 1 ELSE 0 END) = 1 AND (CASE WHEN (((:ACTIONSUBPROCESSDEFINITIONID IS NULL) OR (:ACTIONSUBPROCESSDEFINITIONID='')) OR (ACTIONSUBPROCESSDEFINITIONID=:ACTIONSUBPROCESSDEFINITIONID)) THEN 1 ELSE 0 END) = 1 AND (CASE WHEN (((:ACTIONPROCESSSEGMENTID IS NULL) OR (:ACTIONPROCESSSEGMENTID='')) OR (ACTIONPROCESSSEGMENTID=:ACTIONPROCESSSEGMENTID)) THEN 1 ELSE 0 END) = 1";

	private static Type typeOfThis = typeof(Lotfutureaction);

	private static string _sqlGetLotFutureActionCountCurrentSegmentRuleSqlDatabase = "SELECT COUNT(*) FROM CIM_LOTFUTUREACTION  WHERE LOTID=@LOTID AND SITEID=@SITEID AND ISUSABLE='Usable' AND (CASE WHEN (((@ACTIONPRODUCTDEFINITIONID IS NULL) OR (@ACTIONPRODUCTDEFINITIONID='')) OR (ACTIONPRODUCTDEFINITIONID=@ACTIONPRODUCTDEFINITIONID)) THEN 1 ELSE 0 END) = 1 AND (CASE WHEN (((@ACTIONPROCESSDEFINITIONID IS NULL) OR (@ACTIONPROCESSDEFINITIONID='')) OR (ACTIONPROCESSDEFINITIONID=@ACTIONPROCESSDEFINITIONID)) THEN 1 ELSE 0 END) = 1 AND (CASE WHEN (((@ACTIONSUBPROCESSDEFINITIONID IS NULL) OR (@ACTIONSUBPROCESSDEFINITIONID='')) OR (ACTIONSUBPROCESSDEFINITIONID=@ACTIONSUBPROCESSDEFINITIONID)) THEN 1 ELSE 0 END) = 1 AND (CASE WHEN (((@ACTIONPROCESSSEGMENTID IS NULL) OR (@ACTIONPROCESSSEGMENTID='')) OR (ACTIONPROCESSSEGMENTID=@ACTIONPROCESSSEGMENTID)) THEN 1 ELSE 0 END) = 1 AND ((@PROCESSINGSTATE='WaitForRule' AND ISPROCESSSEGMENTSTART='Y') OR (@PROCESSINGSTATE='WaitForSegment' AND ISPROCESSSEGMENTSTART='N'))";

	private static string _sqlGetLotFutureActionCountCurrentSegmentRuleOracleDatabase = "SELECT COUNT(*) FROM CIM_LOTFUTUREACTION WHERE LOTID=:LOTID AND SITEID=:SITEID AND ISUSABLE='Usable' AND (CASE WHEN (((:ACTIONPRODUCTDEFINITIONID IS NULL) OR (:ACTIONPRODUCTDEFINITIONID='')) OR (ACTIONPRODUCTDEFINITIONID=:ACTIONPRODUCTDEFINITIONID)) THEN 1 ELSE 0 END) = 1 AND (CASE WHEN (((:ACTIONPROCESSDEFINITIONID IS NULL) OR (:ACTIONPROCESSDEFINITIONID='')) OR (ACTIONPROCESSDEFINITIONID=:ACTIONPROCESSDEFINITIONID)) THEN 1 ELSE 0 END) = 1 AND (CASE WHEN (((:ACTIONSUBPROCESSDEFINITIONID IS NULL) OR (:ACTIONSUBPROCESSDEFINITIONID='')) OR (ACTIONSUBPROCESSDEFINITIONID=:ACTIONSUBPROCESSDEFINITIONID)) THEN 1 ELSE 0 END) = 1 AND (CASE WHEN (((:ACTIONPROCESSSEGMENTID IS NULL) OR (:ACTIONPROCESSSEGMENTID='')) OR (ACTIONPROCESSSEGMENTID=:ACTIONPROCESSSEGMENTID)) THEN 1 ELSE 0 END) = 1 AND ((:PROCESSINGSTATE='WaitForRule' AND ISPROCESSSEGMENTSTART='Y') OR (:PROCESSINGSTATE='WaitForSegment' AND ISPROCESSSEGMENTSTART='N'))";

	private static string _sqlGetLotFutureActionListSqlDatabase = "SELECT * FROM CIM_LOTFUTUREACTION  WHERE LOTID=@LOTID AND SITEID=@SITEID AND ISUSABLE='Usable' AND (CASE WHEN (((@ACTIONTYPE IS NULL) OR (@ACTIONTYPE='')) OR (ACTIONTYPE=@ACTIONTYPE)) THEN 1 ELSE 0 END) = 1 AND (CASE WHEN (((@ACTIONPRODUCTDEFINITIONID IS NULL) OR (@ACTIONPRODUCTDEFINITIONID='')) OR (ACTIONPRODUCTDEFINITIONID=@ACTIONPRODUCTDEFINITIONID)) THEN 1 ELSE 0 END) = 1 AND (CASE WHEN (((@ACTIONPROCESSDEFINITIONID IS NULL) OR (@ACTIONPROCESSDEFINITIONID='')) OR (ACTIONPROCESSDEFINITIONID=@ACTIONPROCESSDEFINITIONID)) THEN 1 ELSE 0 END) = 1 AND (CASE WHEN (((@ACTIONSUBPROCESSDEFINITIONID IS NULL) OR (@ACTIONSUBPROCESSDEFINITIONID='')) OR (ACTIONSUBPROCESSDEFINITIONID=@ACTIONSUBPROCESSDEFINITIONID)) THEN 1 ELSE 0 END) = 1 AND (CASE WHEN (((@ACTIONPROCESSSEGMENTID IS NULL) OR (@ACTIONPROCESSSEGMENTID='')) OR (ACTIONPROCESSSEGMENTID=@ACTIONPROCESSSEGMENTID)) THEN 1 ELSE 0 END) = 1";

	private static string _sqlGetLotFutureActionListOracleDatabase = "SELECT * FROM CIM_LOTFUTUREACTION WHERE LOTID=:LOTID AND SITEID=:SITEID AND ISUSABLE='Usable' AND (CASE WHEN (((:ACTIONTYPE IS NULL) OR (:ACTIONTYPE='')) OR (ACTIONTYPE=:ACTIONTYPE)) THEN 1 ELSE 0 END) = 1 AND (CASE WHEN (((:ACTIONPRODUCTDEFINITIONID IS NULL) OR (:ACTIONPRODUCTDEFINITIONID='')) OR (ACTIONPRODUCTDEFINITIONID=:ACTIONPRODUCTDEFINITIONID)) THEN 1 ELSE 0 END) = 1 AND (CASE WHEN (((:ACTIONPROCESSDEFINITIONID IS NULL) OR (:ACTIONPROCESSDEFINITIONID='')) OR (ACTIONPROCESSDEFINITIONID=:ACTIONPROCESSDEFINITIONID)) THEN 1 ELSE 0 END) = 1 AND (CASE WHEN (((:ACTIONSUBPROCESSDEFINITIONID IS NULL) OR (:ACTIONSUBPROCESSDEFINITIONID='')) OR (ACTIONSUBPROCESSDEFINITIONID=:ACTIONSUBPROCESSDEFINITIONID)) THEN 1 ELSE 0 END) = 1 AND (CASE WHEN (((:ACTIONPROCESSSEGMENTID IS NULL) OR (:ACTIONPROCESSSEGMENTID='')) OR (ACTIONPROCESSSEGMENTID=:ACTIONPROCESSSEGMENTID)) THEN 1 ELSE 0 END) = 1";

	private static string _sqlGetLotFutureActionSqlDatabase = "SELECT * FROM CIM_LOTFUTUREACTION WHERE LOTFUTUREACTIONSYSID=@LOTFUTUREACTIONSYSID AND SITEID=@SITEID";

	private static string _sqlGetLotFutureAction4UpdateSqlDatabase = "SELECT * FROM CIM_LOTFUTUREACTION WITH(UPDLOCK) WHERE LOTFUTUREACTIONSYSID=@LOTFUTUREACTIONSYSID AND SITEID=@SITEID";

	private static string _sqlSelectLotFutureActionSqlDatabase = "SELECT * FROM CIM_LOTFUTUREACTION WHERE LOTFUTUREACTIONSYSID=@LOTFUTUREACTIONSYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLotFutureAction4UpdateSqlDatabase = "SELECT * FROM CIM_LOTFUTUREACTION WITH(UPDLOCK) WHERE LOTFUTUREACTIONSYSID=@LOTFUTUREACTIONSYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetLotFutureActionOracleDatabase = "SELECT * FROM CIM_LOTFUTUREACTION WHERE LOTFUTUREACTIONSYSID=:LOTFUTUREACTIONSYSID AND SITEID=:SITEID";

	private static string _sqlGetLotFutureAction4UpdateOracleDatabase = "SELECT * FROM CIM_LOTFUTUREACTION WHERE LOTFUTUREACTIONSYSID=:LOTFUTUREACTIONSYSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectLotFutureActionOracleDatabase = "SELECT * FROM CIM_LOTFUTUREACTION WHERE LOTFUTUREACTIONSYSID=:LOTFUTUREACTIONSYSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLotFutureAction4UpdateOracleDatabase = "SELECT * FROM CIM_LOTFUTUREACTION WHERE LOTFUTUREACTIONSYSID=:LOTFUTUREACTIONSYSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	public static int GetLotFutureActionCount(IDbContext dbContext, Lotfutureaction inputLotfutureaction)
	{
		string apiName = "GetLotFutureActionCount";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inputLotfutureaction.Lotid},{inputLotfutureaction.Siteid}");
		}
		string sqlStatement = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLotFutureActionCountSqlDatabase : _sqlGetLotFutureActionCountOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", inputLotfutureaction.Lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", inputLotfutureaction.Siteid, typeOfThis));
		list.Add(dbContext.CreateParameter("ACTIONTYPE", inputLotfutureaction.Actiontype, typeOfThis));
		list.Add(dbContext.CreateParameter("ACTIONPRODUCTDEFINITIONID", inputLotfutureaction.Actionproductdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("ACTIONPROCESSDEFINITIONID", inputLotfutureaction.Actionprocessdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("ACTIONSUBPROCESSDEFINITIONID", inputLotfutureaction.Actionsubprocessdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("ACTIONPROCESSSEGMENTID", inputLotfutureaction.Actionprocesssegmentid, typeOfThis));
		object obj = dbContext.ExecuteScalar(sqlStatement, list.ToArray());
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inputLotfutureaction.Lotid},{inputLotfutureaction.Siteid}");
		}
		if (obj != null && obj != DBNull.Value)
		{
			return Convert.ToInt32(obj);
		}
		return 0;
	}

	internal static int GetLotFutureActionCountCurrentSegmentRule(IDbContext dbContext, Lot lot)
	{
		string apiName = "GetLotFutureActionCountCurrentSegmentRule";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lot.Lotid},{lot.Siteid}");
		}
		string sqlStatement = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLotFutureActionCountCurrentSegmentRuleSqlDatabase : _sqlGetLotFutureActionCountCurrentSegmentRuleOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lot.Lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", lot.Siteid, typeOfThis));
		list.Add(dbContext.CreateParameter("ACTIONPRODUCTDEFINITIONID", lot.Productdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("ACTIONPROCESSDEFINITIONID", lot.Processdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("ACTIONSUBPROCESSDEFINITIONID", lot.Subprocessdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("ACTIONPROCESSSEGMENTID", lot.Processsegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSINGSTATE", lot.Processingstate, typeOfThis));
		object obj = dbContext.ExecuteScalar(sqlStatement, list.ToArray());
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lot.Lotid},{lot.Siteid}");
		}
		if (obj != null && obj != DBNull.Value)
		{
			return Convert.ToInt32(obj);
		}
		return 0;
	}

	public static IList<Lotfutureaction> GetLotFutureActionList(IDbContext dbContext, Lotfutureaction inputLotfutureaction)
	{
		string apiName = "GetLotFutureActionList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inputLotfutureaction.Lotid},{inputLotfutureaction.Siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLotFutureActionListSqlDatabase : _sqlGetLotFutureActionListOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", inputLotfutureaction.Lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", inputLotfutureaction.Siteid, typeOfThis));
		list.Add(dbContext.CreateParameter("ACTIONTYPE", inputLotfutureaction.Actiontype, typeOfThis));
		list.Add(dbContext.CreateParameter("ACTIONPRODUCTDEFINITIONID", inputLotfutureaction.Actionproductdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("ACTIONPROCESSDEFINITIONID", inputLotfutureaction.Actionprocessdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("ACTIONSUBPROCESSDEFINITIONID", inputLotfutureaction.Actionsubprocessdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("ACTIONPROCESSSEGMENTID", inputLotfutureaction.Actionprocesssegmentid, typeOfThis));
		IList<Lotfutureaction> result = ContextManager.DirectEntityQuery<Lotfutureaction>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inputLotfutureaction.Lotid},{inputLotfutureaction.Siteid}");
		}
		return result;
	}

	public static Lotfutureaction GetLotFutureAction(IDbContext dbContext, string lotfutureactionsysid, string siteid)
	{
		string apiName = "GetLotFutureAction";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotfutureactionsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLotFutureActionSqlDatabase : _sqlGetLotFutureActionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTFUTUREACTIONSYSID", lotfutureactionsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOTFUTUREACTION", $"{lotfutureactionsysid},{siteid}"));
		}
		Lotfutureaction? result = ContextManager.DirectEntityQuery<Lotfutureaction>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotfutureactionsysid},{siteid}");
		}
		return result;
	}

	public static Lotfutureaction GetLotFutureAction4Update(IDbContext dbContext, string lotfutureactionsysid, string siteid)
	{
		string apiName = "GetLotFutureAction4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotfutureactionsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLotFutureAction4UpdateSqlDatabase : _sqlGetLotFutureAction4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTFUTUREACTIONSYSID", lotfutureactionsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_LOTFUTUREACTION", $"{lotfutureactionsysid},{siteid}"));
		}
		Lotfutureaction? result = ContextManager.DirectEntityQuery<Lotfutureaction>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotfutureactionsysid},{siteid}");
		}
		return result;
	}

	public static Lotfutureaction SelectLotFutureAction(IDbContext dbContext, string lotfutureactionsysid, string siteid)
	{
		string apiName = "SelectLotFutureAction";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotfutureactionsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotFutureActionSqlDatabase : _sqlSelectLotFutureActionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTFUTUREACTIONSYSID", lotfutureactionsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOTFUTUREACTION", $"{lotfutureactionsysid},{siteid}"));
		}
		Lotfutureaction? result = ContextManager.DirectEntityQuery<Lotfutureaction>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotfutureactionsysid},{siteid}");
		}
		return result;
	}

	public static Lotfutureaction SelectLotFutureAction4Update(IDbContext dbContext, string lotfutureactionsysid, string siteid)
	{
		string apiName = "SelectLotFutureAction4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotfutureactionsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotFutureAction4UpdateSqlDatabase : _sqlSelectLotFutureAction4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTFUTUREACTIONSYSID", lotfutureactionsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_LOTFUTUREACTION", $"{lotfutureactionsysid},{siteid}"));
		}
		Lotfutureaction? result = ContextManager.DirectEntityQuery<Lotfutureaction>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotfutureactionsysid},{siteid}");
		}
		return result;
	}

	public static int UpsertLotFutureAction(IDbContext dbContext, RequestType requestType, Lotfutureaction[] lotFutureActionList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateLotFutureActionInternal(dbContext, lotFutureActionList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateLotFutureAction(dbContext, lotFutureActionList, optionSet, saveHist), 
			RequestType.DELETE => DeleteLotFutureAction(dbContext, lotFutureActionList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteLotFutureAction(dbContext, lotFutureActionList, optionSet, saveHist), 
			_ => RealDeleteLotFutureAction(dbContext, lotFutureActionList, optionSet, saveHist), 
		};
	}

	private static int CreateLotFutureActionInternal(IDbContext dbContext, Lotfutureaction[] lotFutureActionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotFutureActionList", lotFutureActionList);
		string text = "CreateLotFutureAction";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotfutureaction> list = new List<Lotfutureaction>();
		foreach (Lotfutureaction obj in lotFutureActionList)
		{
			Lotfutureaction lotfutureaction = new Lotfutureaction();
			obj.CopyColumsTo(lotfutureaction);
			lotfutureaction.Activity = text;
			lotfutureaction.CheckEntityUsable();
			obj.CopyCommonField(lotfutureaction, systemTime, dbContext.Tid, isCreate: true);
			list.Add(lotfutureaction);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateLotFutureAction(IDbContext dbContext, Lotfutureaction[] lotFutureActionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotFutureActionList", lotFutureActionList);
		string text = "UpdateLotFutureAction";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotfutureaction> list = new List<Lotfutureaction>();
		foreach (Lotfutureaction lotfutureaction in lotFutureActionList)
		{
			Lotfutureaction lotFutureAction4Update = GetLotFutureAction4Update(dbContext, lotfutureaction.Lotfutureactionsysid, lotfutureaction.Siteid);
			if (lotFutureAction4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lotfutureaction), $"{lotfutureaction.Lotfutureactionsysid},{lotfutureaction.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Lotfutureaction), $"{lotfutureaction.Lotfutureactionsysid},{lotfutureaction.Siteid}", lotFutureAction4Update.Isusable);
			string activity = lotFutureAction4Update.Activity;
			string customactivity = lotFutureAction4Update.Customactivity;
			string isusable = lotFutureAction4Update.Isusable;
			DateTime? createtime = lotFutureAction4Update.Createtime;
			string creator = lotFutureAction4Update.Creator;
			lotfutureaction.CopyColumsTo(lotFutureAction4Update);
			lotFutureAction4Update.Prevactivity = activity;
			lotFutureAction4Update.Prevcustomactivity = customactivity;
			lotFutureAction4Update.Creator = creator;
			lotFutureAction4Update.Createtime = createtime;
			lotFutureAction4Update.Isusable = isusable;
			lotFutureAction4Update.Activity = text;
			lotfutureaction.CopyCommonField(lotFutureAction4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(lotFutureAction4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteLotFutureAction(IDbContext dbContext, Lotfutureaction[] lotFutureActionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotFutureActionList", lotFutureActionList);
		string text = "DeleteLotFutureAction";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotfutureaction> list = new List<Lotfutureaction>();
		foreach (Lotfutureaction lotfutureaction in lotFutureActionList)
		{
			Lotfutureaction lotFutureAction4Update = GetLotFutureAction4Update(dbContext, lotfutureaction.Lotfutureactionsysid, lotfutureaction.Siteid);
			if (lotFutureAction4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lotfutureaction), $"{lotfutureaction.Lotfutureactionsysid},{lotfutureaction.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Lotfutureaction), $"{lotfutureaction.Lotfutureactionsysid},{lotfutureaction.Siteid}", lotFutureAction4Update.Isusable);
			lotFutureAction4Update.Isusable = "UnUsable";
			lotfutureaction.CopyCommonFieldUpdatePrev(lotFutureAction4Update, systemTime, dbContext.Tid, text);
			lotfutureaction.CopyExtensionCollection(lotFutureAction4Update);
			list.Add(lotFutureAction4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteLotFutureAction(IDbContext dbContext, Lotfutureaction[] lotFutureActionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotFutureActionList", lotFutureActionList);
		string text = "UnDeleteLotFutureAction";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotfutureaction> list = new List<Lotfutureaction>();
		foreach (Lotfutureaction lotfutureaction in lotFutureActionList)
		{
			Lotfutureaction lotFutureAction4Update = GetLotFutureAction4Update(dbContext, lotfutureaction.Lotfutureactionsysid, lotfutureaction.Siteid);
			if (lotFutureAction4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lotfutureaction), $"{lotfutureaction.Lotfutureactionsysid},{lotfutureaction.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Lotfutureaction), $"{lotfutureaction.Lotfutureactionsysid},{lotfutureaction.Siteid}", lotFutureAction4Update.Isusable);
			lotFutureAction4Update.Isusable = "Usable";
			lotfutureaction.CopyCommonFieldUpdatePrev(lotFutureAction4Update, systemTime, dbContext.Tid, text);
			lotfutureaction.CopyExtensionCollection(lotFutureAction4Update);
			list.Add(lotFutureAction4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteLotFutureAction(IDbContext dbContext, Lotfutureaction[] lotFutureActionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotFutureActionList", lotFutureActionList);
		string text = "RealDeleteLotFutureAction";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotfutureaction> list = new List<Lotfutureaction>();
		foreach (Lotfutureaction lotfutureaction in lotFutureActionList)
		{
			Lotfutureaction lotFutureAction4Update = GetLotFutureAction4Update(dbContext, lotfutureaction.Lotfutureactionsysid, lotfutureaction.Siteid);
			if (lotFutureAction4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lotfutureaction), $"{lotfutureaction.Lotfutureactionsysid},{lotfutureaction.Siteid}");
			}
			lotfutureaction.CopyCommonFieldUpdatePrev(lotFutureAction4Update, systemTime, dbContext.Tid, text);
			lotfutureaction.CopyExtensionCollection(lotFutureAction4Update);
			list.Add(lotFutureAction4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
