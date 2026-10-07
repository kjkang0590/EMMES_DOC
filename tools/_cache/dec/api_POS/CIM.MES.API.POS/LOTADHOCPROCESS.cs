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
public class LOTADHOCPROCESS
{
	private static string _sqlGetLotAdhocProcessSqlDatabase = "SELECT * FROM CIM_LOTADHOCPROCESS WHERE LOTADHOCPROCESSSYSID=@LOTADHOCPROCESSSYSID AND SITEID=@SITEID";

	private static string _sqlGetLotAdhocProcess4UpdateSqlDatabase = "SELECT * FROM CIM_LOTADHOCPROCESS WITH(UPDLOCK) WHERE LOTADHOCPROCESSSYSID=@LOTADHOCPROCESSSYSID AND SITEID=@SITEID";

	private static string _sqlSelectLotAdhocProcessSqlDatabase = "SELECT * FROM CIM_LOTADHOCPROCESS WHERE LOTADHOCPROCESSSYSID=@LOTADHOCPROCESSSYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLotAdhocProcess4UpdateSqlDatabase = "SELECT * FROM CIM_LOTADHOCPROCESS WITH(UPDLOCK) WHERE LOTADHOCPROCESSSYSID=@LOTADHOCPROCESSSYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetLotAdhocProcessOracleDatabase = "SELECT * FROM CIM_LOTADHOCPROCESS WHERE LOTADHOCPROCESSSYSID=:LOTADHOCPROCESSSYSID AND SITEID=:SITEID";

	private static string _sqlGetLotAdhocProcess4UpdateOracleDatabase = "SELECT * FROM CIM_LOTADHOCPROCESS WHERE LOTADHOCPROCESSSYSID=:LOTADHOCPROCESSSYSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectLotAdhocProcessOracleDatabase = "SELECT * FROM CIM_LOTADHOCPROCESS WHERE LOTADHOCPROCESSSYSID=:LOTADHOCPROCESSSYSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLotAdhocProcess4UpdateOracleDatabase = "SELECT * FROM CIM_LOTADHOCPROCESS WHERE LOTADHOCPROCESSSYSID=:LOTADHOCPROCESSSYSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Lotadhocprocess);

	private static string _sqlGetLotAdhocProcessCountWithAdhocProcessTypeSqlDatabase = "SELECT COUNT(*) FROM CIM_LOTADHOCPROCESS WHERE LOTID=@LOTID AND SITEID=@SITEID AND ADHOCPROCESSTYPE=@ADHOCPROCESSTYPE AND ISUSABLE='Usable'";

	private static string _sqlGetLotAdhocProcessCountWithAdhocProcessTypeOracleDatabase = "SELECT COUNT(*) FROM CIM_LOTADHOCPROCESS WHERE LOTID=:LOTID AND SITEID=:SITEID AND ADHOCPROCESSTYPE=:ADHOCPROCESSTYPE AND ISUSABLE='Usable'";

	private static string _sqlSelectLotAdhocProcessByFinishSqlDatabase = "SELECT * FROM CIM_LOTADHOCPROCESS  WHERE LOTADHOCPROCESSSYSID=@LOTADHOCPROCESSSYSID AND FINISHPROCESSDEFINITIONID=@FINISHPROCESSDEFINITIONID AND FINISHSUBPROCESSDEFINITIONID=@FINISHSUBPROCESSDEFINITIONID AND FINISHPROCESSSEGMENTID=@FINISHPROCESSSEGMENTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLotAdhocProcessByFinishOracleDatabase = "SELECT * FROM CIM_LOTADHOCPROCESS WHERE LOTADHOCPROCESSSYSID=:LOTADHOCPROCESSSYSID AND FINISHPROCESSDEFINITIONID=:FINISHPROCESSDEFINITIONID AND FINISHSUBPROCESSDEFINITIONID=:FINISHSUBPROCESSDEFINITIONID AND FINISHPROCESSSEGMENTID=:FINISHPROCESSSEGMENTID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLotAdhocProcessByLotSqlDatabase = "SELECT * FROM CIM_LOTADHOCPROCESS WHERE LOTID=@LOTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLotAdhocProcessByLotOracleDatabase = "SELECT * FROM CIM_LOTADHOCPROCESS WHERE LOTID=:LOTID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMaxAdhocDepthSqlDatabase = "SELECT MAX(ADHOCDEPTH) FROM CIM_LOTADHOCPROCESS WHERE LOTID=@LOTID AND SITEID=@SITEID AND ADHOCPROCESSTYPE=@ADHOCPROCESSTYPE AND ISUSABLE='Usable'";

	private static string _sqlSelectMaxAdhocDepthOracleDatabase = "SELECT MAX(ADHOCDEPTH) FROM CIM_LOTADHOCPROCESS WHERE LOTID=:LOTID AND SITEID=:SITEID AND ADHOCPROCESSTYPE=:ADHOCPROCESSTYPE AND ISUSABLE='Usable'";

	public static Lotadhocprocess GetLotAdhocProcess(IDbContext dbContext, string lotadhocprocesssysid, string siteid)
	{
		string apiName = "GetLotAdhocProcess";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotadhocprocesssysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLotAdhocProcessSqlDatabase : _sqlGetLotAdhocProcessOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTADHOCPROCESSSYSID", lotadhocprocesssysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOTADHOCPROCESS", $"{lotadhocprocesssysid},{siteid}"));
		}
		Lotadhocprocess? result = ContextManager.DirectEntityQuery<Lotadhocprocess>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotadhocprocesssysid},{siteid}");
		}
		return result;
	}

	public static Lotadhocprocess GetLotAdhocProcess4Update(IDbContext dbContext, string lotadhocprocesssysid, string siteid)
	{
		string apiName = "GetLotAdhocProcess4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotadhocprocesssysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLotAdhocProcess4UpdateSqlDatabase : _sqlGetLotAdhocProcess4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTADHOCPROCESSSYSID", lotadhocprocesssysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_LOTADHOCPROCESS", $"{lotadhocprocesssysid},{siteid}"));
		}
		Lotadhocprocess? result = ContextManager.DirectEntityQuery<Lotadhocprocess>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotadhocprocesssysid},{siteid}");
		}
		return result;
	}

	public static Lotadhocprocess SelectLotAdhocProcess(IDbContext dbContext, string lotadhocprocesssysid, string siteid)
	{
		string apiName = "SelectLotAdhocProcess";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotadhocprocesssysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotAdhocProcessSqlDatabase : _sqlSelectLotAdhocProcessOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTADHOCPROCESSSYSID", lotadhocprocesssysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOTADHOCPROCESS", $"{lotadhocprocesssysid},{siteid}"));
		}
		Lotadhocprocess? result = ContextManager.DirectEntityQuery<Lotadhocprocess>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotadhocprocesssysid},{siteid}");
		}
		return result;
	}

	public static Lotadhocprocess SelectLotAdhocProcess4Update(IDbContext dbContext, string lotadhocprocesssysid, string siteid)
	{
		string apiName = "SelectLotAdhocProcess4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotadhocprocesssysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotAdhocProcess4UpdateSqlDatabase : _sqlSelectLotAdhocProcess4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTADHOCPROCESSSYSID", lotadhocprocesssysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_LOTADHOCPROCESS", $"{lotadhocprocesssysid},{siteid}"));
		}
		Lotadhocprocess? result = ContextManager.DirectEntityQuery<Lotadhocprocess>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotadhocprocesssysid},{siteid}");
		}
		return result;
	}

	public static int UpsertLotAdhocProcess(IDbContext dbContext, RequestType requestType, Lotadhocprocess[] lotAdhocProcessList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateLotAdhocProcessInternal(dbContext, lotAdhocProcessList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateLotAdhocProcess(dbContext, lotAdhocProcessList, optionSet, saveHist), 
			RequestType.DELETE => DeleteLotAdhocProcess(dbContext, lotAdhocProcessList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteLotAdhocProcess(dbContext, lotAdhocProcessList, optionSet, saveHist), 
			_ => RealDeleteLotAdhocProcess(dbContext, lotAdhocProcessList, optionSet, saveHist), 
		};
	}

	private static int CreateLotAdhocProcessInternal(IDbContext dbContext, Lotadhocprocess[] lotAdhocProcessList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotAdhocProcessList", lotAdhocProcessList);
		string text = "CreateLotAdhocProcess";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotadhocprocess> list = new List<Lotadhocprocess>();
		foreach (Lotadhocprocess obj in lotAdhocProcessList)
		{
			Lotadhocprocess lotadhocprocess = new Lotadhocprocess();
			obj.CopyColumsTo(lotadhocprocess);
			lotadhocprocess.Activity = text;
			lotadhocprocess.CheckEntityUsable();
			obj.CopyCommonField(lotadhocprocess, systemTime, dbContext.Tid, isCreate: true);
			list.Add(lotadhocprocess);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateLotAdhocProcess(IDbContext dbContext, Lotadhocprocess[] lotAdhocProcessList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotAdhocProcessList", lotAdhocProcessList);
		string text = "UpdateLotAdhocProcess";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotadhocprocess> list = new List<Lotadhocprocess>();
		foreach (Lotadhocprocess lotadhocprocess in lotAdhocProcessList)
		{
			Lotadhocprocess lotAdhocProcess4Update = GetLotAdhocProcess4Update(dbContext, lotadhocprocess.Lotadhocprocesssysid, lotadhocprocess.Siteid);
			if (lotAdhocProcess4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lotadhocprocess), $"{lotadhocprocess.Lotadhocprocesssysid},{lotadhocprocess.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Lotadhocprocess), $"{lotadhocprocess.Lotadhocprocesssysid},{lotadhocprocess.Siteid}", lotAdhocProcess4Update.Isusable);
			string activity = lotAdhocProcess4Update.Activity;
			string customactivity = lotAdhocProcess4Update.Customactivity;
			string isusable = lotAdhocProcess4Update.Isusable;
			DateTime? createtime = lotAdhocProcess4Update.Createtime;
			string creator = lotAdhocProcess4Update.Creator;
			lotadhocprocess.CopyColumsTo(lotAdhocProcess4Update);
			lotAdhocProcess4Update.Prevactivity = activity;
			lotAdhocProcess4Update.Prevcustomactivity = customactivity;
			lotAdhocProcess4Update.Creator = creator;
			lotAdhocProcess4Update.Createtime = createtime;
			lotAdhocProcess4Update.Isusable = isusable;
			lotAdhocProcess4Update.Activity = text;
			lotadhocprocess.CopyCommonField(lotAdhocProcess4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(lotAdhocProcess4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteLotAdhocProcess(IDbContext dbContext, Lotadhocprocess[] lotAdhocProcessList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotAdhocProcessList", lotAdhocProcessList);
		string text = "DeleteLotAdhocProcess";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotadhocprocess> list = new List<Lotadhocprocess>();
		foreach (Lotadhocprocess lotadhocprocess in lotAdhocProcessList)
		{
			Lotadhocprocess lotAdhocProcess4Update = GetLotAdhocProcess4Update(dbContext, lotadhocprocess.Lotadhocprocesssysid, lotadhocprocess.Siteid);
			if (lotAdhocProcess4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lotadhocprocess), $"{lotadhocprocess.Lotadhocprocesssysid},{lotadhocprocess.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Lotadhocprocess), $"{lotadhocprocess.Lotadhocprocesssysid},{lotadhocprocess.Siteid}", lotAdhocProcess4Update.Isusable);
			lotAdhocProcess4Update.Isusable = "UnUsable";
			lotadhocprocess.CopyCommonFieldUpdatePrev(lotAdhocProcess4Update, systemTime, dbContext.Tid, text);
			lotadhocprocess.CopyExtensionCollection(lotAdhocProcess4Update);
			list.Add(lotAdhocProcess4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteLotAdhocProcess(IDbContext dbContext, Lotadhocprocess[] lotAdhocProcessList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotAdhocProcessList", lotAdhocProcessList);
		string text = "UnDeleteLotAdhocProcess";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotadhocprocess> list = new List<Lotadhocprocess>();
		foreach (Lotadhocprocess lotadhocprocess in lotAdhocProcessList)
		{
			Lotadhocprocess lotAdhocProcess4Update = GetLotAdhocProcess4Update(dbContext, lotadhocprocess.Lotadhocprocesssysid, lotadhocprocess.Siteid);
			if (lotAdhocProcess4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lotadhocprocess), $"{lotadhocprocess.Lotadhocprocesssysid},{lotadhocprocess.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Lotadhocprocess), $"{lotadhocprocess.Lotadhocprocesssysid},{lotadhocprocess.Siteid}", lotAdhocProcess4Update.Isusable);
			lotAdhocProcess4Update.Isusable = "Usable";
			lotadhocprocess.CopyCommonFieldUpdatePrev(lotAdhocProcess4Update, systemTime, dbContext.Tid, text);
			lotadhocprocess.CopyExtensionCollection(lotAdhocProcess4Update);
			list.Add(lotAdhocProcess4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteLotAdhocProcess(IDbContext dbContext, Lotadhocprocess[] lotAdhocProcessList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotAdhocProcessList", lotAdhocProcessList);
		string text = "RealDeleteLotAdhocProcess";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotadhocprocess> list = new List<Lotadhocprocess>();
		foreach (Lotadhocprocess lotadhocprocess in lotAdhocProcessList)
		{
			Lotadhocprocess lotAdhocProcess4Update = GetLotAdhocProcess4Update(dbContext, lotadhocprocess.Lotadhocprocesssysid, lotadhocprocess.Siteid);
			if (lotAdhocProcess4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lotadhocprocess), $"{lotadhocprocess.Lotadhocprocesssysid},{lotadhocprocess.Siteid}");
			}
			lotadhocprocess.CopyCommonFieldUpdatePrev(lotAdhocProcess4Update, systemTime, dbContext.Tid, text);
			lotadhocprocess.CopyExtensionCollection(lotAdhocProcess4Update);
			list.Add(lotAdhocProcess4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int SelectAdhocProcessCountWithAdhocProcessType(IDbContext dbContext, string lotId, string siteId, string adhocProcessType)
	{
		string apiName = "SelectAdhocProcessCountWithAdhocProcessType";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotId},{siteId},{adhocProcessType}");
		}
		string sqlStatement = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLotAdhocProcessCountWithAdhocProcessTypeSqlDatabase : _sqlGetLotAdhocProcessCountWithAdhocProcessTypeOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotId, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		list.Add(dbContext.CreateParameter("ADHOCPROCESSTYPE", adhocProcessType, typeOfThis));
		object obj = dbContext.ExecuteScalar(sqlStatement, list.ToArray());
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotId},{siteId},{adhocProcessType}");
		}
		if (obj != null && obj != DBNull.Value)
		{
			return Convert.ToInt32(obj);
		}
		return 0;
	}

	public static Lotadhocprocess SelectLotAdhocProcess(IDbContext dbContext, string lotAdhocProcessSysId, string finishProcessDefinitionId, string finishSubprocessDefinitionId, string finishProcessSegmentId, string siteId)
	{
		string apiName = "SelectLotAdhocProcess";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotAdhocProcessSysId},{finishProcessDefinitionId},{finishSubprocessDefinitionId},{finishProcessSegmentId},{siteId}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotAdhocProcessByFinishSqlDatabase : _sqlSelectLotAdhocProcessByFinishOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTADHOCPROCESSSYSID", lotAdhocProcessSysId, typeOfThis));
		list.Add(dbContext.CreateParameter("FINISHPROCESSDEFINITIONID", finishProcessDefinitionId, typeOfThis));
		list.Add(dbContext.CreateParameter("FINISHSUBPROCESSDEFINITIONID", finishSubprocessDefinitionId, typeOfThis));
		list.Add(dbContext.CreateParameter("FINISHPROCESSSEGMENTID", finishProcessSegmentId, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		Lotadhocprocess result = ContextManager.DirectEntityQuery<Lotadhocprocess>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotAdhocProcessSysId},{finishProcessDefinitionId},{finishSubprocessDefinitionId},{finishProcessSegmentId},{siteId}");
		}
		return result;
	}

	public static IList<Lotadhocprocess> SelectLotAdhocProcessList(IDbContext dbContext, string lotId, string siteId)
	{
		string apiName = "SelectLotAdhocProcessList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotId},{siteId}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotAdhocProcessByLotSqlDatabase : _sqlSelectLotAdhocProcessByLotOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotId, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		IList<Lotadhocprocess> result = ContextManager.DirectEntityQuery<Lotadhocprocess>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotId},{siteId}");
		}
		return result;
	}

	public static int SelectMaxAdhocDepth(IDbContext dbContext, string lotId, string siteId, string adhocProcessType)
	{
		string apiName = "SelectMaxAdhocDepth";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotId},{siteId},{adhocProcessType}");
		}
		string sqlStatement = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMaxAdhocDepthSqlDatabase : _sqlSelectMaxAdhocDepthOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotId, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		list.Add(dbContext.CreateParameter("ADHOCPROCESSTYPE", adhocProcessType, typeOfThis));
		object obj = dbContext.ExecuteScalar(sqlStatement, list.ToArray());
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotId},{siteId},{adhocProcessType}");
		}
		if (obj != null && obj != DBNull.Value)
		{
			return Convert.ToInt32(obj);
		}
		return 0;
	}
}
