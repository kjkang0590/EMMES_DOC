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
public class LOTSUMMARY
{
	private static string _sqlGetLotSummarySqlDatabase = "SELECT * FROM CIM_LOTSUMMARY WHERE LOTID=@LOTID AND PRODUCTDEFINITIONID=@PRODUCTDEFINITIONID AND PRODUCTORDERID=@PRODUCTORDERID AND PROCESSDEFINITIONID=@PROCESSDEFINITIONID AND SUBPROCESSDEFINITIONID=@SUBPROCESSDEFINITIONID AND PROCESSSEGMENTID=@PROCESSSEGMENTID AND REPEATCOUNT=@REPEATCOUNT AND SITEID=@SITEID";

	private static string _sqlGetLotSummary4UpdateSqlDatabase = "SELECT * FROM CIM_LOTSUMMARY WITH(UPDLOCK) WHERE LOTID=@LOTID AND PRODUCTDEFINITIONID=@PRODUCTDEFINITIONID AND PRODUCTORDERID=@PRODUCTORDERID AND PROCESSDEFINITIONID=@PROCESSDEFINITIONID AND SUBPROCESSDEFINITIONID=@SUBPROCESSDEFINITIONID AND PROCESSSEGMENTID=@PROCESSSEGMENTID AND REPEATCOUNT=@REPEATCOUNT AND SITEID=@SITEID";

	private static string _sqlSelectLotSummarySqlDatabase = "SELECT * FROM CIM_LOTSUMMARY WHERE LOTID=@LOTID AND PRODUCTDEFINITIONID=@PRODUCTDEFINITIONID AND PRODUCTORDERID=@PRODUCTORDERID AND PROCESSDEFINITIONID=@PROCESSDEFINITIONID AND SUBPROCESSDEFINITIONID=@SUBPROCESSDEFINITIONID AND PROCESSSEGMENTID=@PROCESSSEGMENTID AND REPEATCOUNT=@REPEATCOUNT AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLotSummary4UpdateSqlDatabase = "SELECT * FROM CIM_LOTSUMMARY WITH(UPDLOCK) WHERE LOTID=@LOTID AND PRODUCTDEFINITIONID=@PRODUCTDEFINITIONID AND PRODUCTORDERID=@PRODUCTORDERID AND PROCESSDEFINITIONID=@PROCESSDEFINITIONID AND SUBPROCESSDEFINITIONID=@SUBPROCESSDEFINITIONID AND PROCESSSEGMENTID=@PROCESSSEGMENTID AND REPEATCOUNT=@REPEATCOUNT AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetLotSummaryOracleDatabase = "SELECT * FROM CIM_LOTSUMMARY WHERE LOTID=:LOTID AND PRODUCTDEFINITIONID=:PRODUCTDEFINITIONID AND PRODUCTORDERID=:PRODUCTORDERID AND PROCESSDEFINITIONID=:PROCESSDEFINITIONID AND SUBPROCESSDEFINITIONID=:SUBPROCESSDEFINITIONID AND PROCESSSEGMENTID=:PROCESSSEGMENTID AND REPEATCOUNT=:REPEATCOUNT AND SITEID=:SITEID";

	private static string _sqlGetLotSummary4UpdateOracleDatabase = "SELECT * FROM CIM_LOTSUMMARY WHERE LOTID=:LOTID AND PRODUCTDEFINITIONID=:PRODUCTDEFINITIONID AND PRODUCTORDERID=:PRODUCTORDERID AND PROCESSDEFINITIONID=:PROCESSDEFINITIONID AND SUBPROCESSDEFINITIONID=:SUBPROCESSDEFINITIONID AND PROCESSSEGMENTID=:PROCESSSEGMENTID AND REPEATCOUNT=:REPEATCOUNT AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectLotSummaryOracleDatabase = "SELECT * FROM CIM_LOTSUMMARY WHERE LOTID=:LOTID AND PRODUCTDEFINITIONID=:PRODUCTDEFINITIONID AND PRODUCTORDERID=:PRODUCTORDERID AND PROCESSDEFINITIONID=:PROCESSDEFINITIONID AND SUBPROCESSDEFINITIONID=:SUBPROCESSDEFINITIONID AND PROCESSSEGMENTID=:PROCESSSEGMENTID AND REPEATCOUNT=:REPEATCOUNT AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLotSummary4UpdateOracleDatabase = "SELECT * FROM CIM_LOTSUMMARY WHERE LOTID=:LOTID AND PRODUCTDEFINITIONID=:PRODUCTDEFINITIONID AND PRODUCTORDERID=:PRODUCTORDERID AND PROCESSDEFINITIONID=:PROCESSDEFINITIONID AND SUBPROCESSDEFINITIONID=:SUBPROCESSDEFINITIONID AND PROCESSSEGMENTID=:PROCESSSEGMENTID AND REPEATCOUNT=:REPEATCOUNT AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Lotsummary);

	public static Lotsummary GetLotSummary(IDbContext dbContext, string lotid, string productdefinitionid, string productorderid, string processdefinitionid, string subprocessdefinitionid, string processsegmentid, int repeatcount, string siteid)
	{
		string apiName = "GetLotSummary";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{productdefinitionid},{productorderid},{processdefinitionid},{subprocessdefinitionid},{processsegmentid},{repeatcount},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLotSummarySqlDatabase : _sqlGetLotSummaryOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", productdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("PRODUCTORDERID", productorderid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSDEFINITIONID", processdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SUBPROCESSDEFINITIONID", subprocessdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOTSUMMARY", $"{lotid},{productdefinitionid},{productorderid},{processdefinitionid},{subprocessdefinitionid},{processsegmentid},{repeatcount},{siteid}"));
		}
		Lotsummary result = ContextManager.DirectEntityQuery<Lotsummary>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{productdefinitionid},{productorderid},{processdefinitionid},{subprocessdefinitionid},{processsegmentid},{repeatcount},{siteid}");
		}
		return result;
	}

	public static Lotsummary GetLotSummary4Update(IDbContext dbContext, string lotid, string productdefinitionid, string productorderid, string processdefinitionid, string subprocessdefinitionid, string processsegmentid, int repeatcount, string siteid)
	{
		string apiName = "GetLotSummary4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{productdefinitionid},{productorderid},{processdefinitionid},{subprocessdefinitionid},{processsegmentid},{repeatcount},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLotSummary4UpdateSqlDatabase : _sqlGetLotSummary4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", productdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("PRODUCTORDERID", productorderid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSDEFINITIONID", processdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SUBPROCESSDEFINITIONID", subprocessdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_LOTSUMMARY", $"{lotid},{productdefinitionid},{productorderid},{processdefinitionid},{subprocessdefinitionid},{processsegmentid},{repeatcount},{siteid}"));
		}
		Lotsummary result = ContextManager.DirectEntityQuery<Lotsummary>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{productdefinitionid},{productorderid},{processdefinitionid},{subprocessdefinitionid},{processsegmentid},{repeatcount},{siteid}");
		}
		return result;
	}

	public static Lotsummary SelectLotSummary(IDbContext dbContext, string lotid, string productdefinitionid, string productorderid, string processdefinitionid, string subprocessdefinitionid, string processsegmentid, int repeatcount, string siteid)
	{
		string apiName = "SelectLotSummary";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{productdefinitionid},{productorderid},{processdefinitionid},{subprocessdefinitionid},{processsegmentid},{repeatcount},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotSummarySqlDatabase : _sqlSelectLotSummaryOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", productdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("PRODUCTORDERID", productorderid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSDEFINITIONID", processdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SUBPROCESSDEFINITIONID", subprocessdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOTSUMMARY", $"{lotid},{productdefinitionid},{productorderid},{processdefinitionid},{subprocessdefinitionid},{processsegmentid},{repeatcount},{siteid}"));
		}
		Lotsummary result = ContextManager.DirectEntityQuery<Lotsummary>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{productdefinitionid},{productorderid},{processdefinitionid},{subprocessdefinitionid},{processsegmentid},{repeatcount},{siteid}");
		}
		return result;
	}

	public static Lotsummary SelectLotSummary4Update(IDbContext dbContext, string lotid, string productdefinitionid, string productorderid, string processdefinitionid, string subprocessdefinitionid, string processsegmentid, int repeatcount, string siteid)
	{
		string apiName = "SelectLotSummary4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{productdefinitionid},{productorderid},{processdefinitionid},{subprocessdefinitionid},{processsegmentid},{repeatcount},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotSummary4UpdateSqlDatabase : _sqlSelectLotSummary4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", productdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("PRODUCTORDERID", productorderid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSDEFINITIONID", processdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SUBPROCESSDEFINITIONID", subprocessdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_LOTSUMMARY", $"{lotid},{productdefinitionid},{productorderid},{processdefinitionid},{subprocessdefinitionid},{processsegmentid},{repeatcount},{siteid}"));
		}
		Lotsummary result = ContextManager.DirectEntityQuery<Lotsummary>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{productdefinitionid},{productorderid},{processdefinitionid},{subprocessdefinitionid},{processsegmentid},{repeatcount},{siteid}");
		}
		return result;
	}

	public static int UpsertLotSummary(IDbContext dbContext, RequestType requestType, Lotsummary[] lotSummaryList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateLotSummaryInternal(dbContext, lotSummaryList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateLotSummary(dbContext, lotSummaryList, optionSet, saveHist), 
			RequestType.DELETE => DeleteLotSummary(dbContext, lotSummaryList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteLotSummary(dbContext, lotSummaryList, optionSet, saveHist), 
			_ => RealDeleteLotSummary(dbContext, lotSummaryList, optionSet, saveHist), 
		};
	}

	private static int CreateLotSummaryInternal(IDbContext dbContext, Lotsummary[] lotSummaryList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotSummaryList", lotSummaryList);
		string text = "CreateLotSummary";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotsummary> list = new List<Lotsummary>();
		foreach (Lotsummary obj in lotSummaryList)
		{
			Lotsummary lotsummary = new Lotsummary();
			obj.CopyColumsTo(lotsummary);
			lotsummary.Activity = text;
			lotsummary.CheckEntityUsable();
			obj.CopyCommonField(lotsummary, systemTime, dbContext.Tid, isCreate: true);
			list.Add(lotsummary);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateLotSummary(IDbContext dbContext, Lotsummary[] lotSummaryList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotSummaryList", lotSummaryList);
		string text = "UpdateLotSummary";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotsummary> list = new List<Lotsummary>();
		foreach (Lotsummary lotsummary in lotSummaryList)
		{
			Lotsummary lotSummary4Update = GetLotSummary4Update(dbContext, lotsummary.Lotid, lotsummary.Productdefinitionid, lotsummary.Productorderid, lotsummary.Processdefinitionid, lotsummary.Subprocessdefinitionid, lotsummary.Processsegmentid, lotsummary.Repeatcount, lotsummary.Siteid);
			if (lotSummary4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lotsummary), $"{lotsummary.Lotid},{lotsummary.Productdefinitionid},{lotsummary.Productorderid},{lotsummary.Processdefinitionid},{lotsummary.Subprocessdefinitionid},{lotsummary.Processsegmentid},{lotsummary.Repeatcount},{lotsummary.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Lotsummary), $"{lotsummary.Lotid},{lotsummary.Productdefinitionid},{lotsummary.Productorderid},{lotsummary.Processdefinitionid},{lotsummary.Subprocessdefinitionid},{lotsummary.Processsegmentid},{lotsummary.Repeatcount},{lotsummary.Siteid}", lotSummary4Update.Isusable);
			string activity = lotSummary4Update.Activity;
			string customactivity = lotSummary4Update.Customactivity;
			string isusable = lotSummary4Update.Isusable;
			DateTime? createtime = lotSummary4Update.Createtime;
			string creator = lotSummary4Update.Creator;
			lotsummary.CopyColumsTo(lotSummary4Update);
			lotSummary4Update.Prevactivity = activity;
			lotSummary4Update.Prevcustomactivity = customactivity;
			lotSummary4Update.Creator = creator;
			lotSummary4Update.Createtime = createtime;
			lotSummary4Update.Isusable = isusable;
			lotSummary4Update.Activity = text;
			lotsummary.CopyCommonField(lotSummary4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(lotSummary4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteLotSummary(IDbContext dbContext, Lotsummary[] lotSummaryList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotSummaryList", lotSummaryList);
		string text = "DeleteLotSummary";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotsummary> list = new List<Lotsummary>();
		foreach (Lotsummary lotsummary in lotSummaryList)
		{
			Lotsummary lotSummary4Update = GetLotSummary4Update(dbContext, lotsummary.Lotid, lotsummary.Productdefinitionid, lotsummary.Productorderid, lotsummary.Processdefinitionid, lotsummary.Subprocessdefinitionid, lotsummary.Processsegmentid, lotsummary.Repeatcount, lotsummary.Siteid);
			if (lotSummary4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lotsummary), $"{lotsummary.Lotid},{lotsummary.Productdefinitionid},{lotsummary.Productorderid},{lotsummary.Processdefinitionid},{lotsummary.Subprocessdefinitionid},{lotsummary.Processsegmentid},{lotsummary.Repeatcount},{lotsummary.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Lotsummary), $"{lotsummary.Lotid},{lotsummary.Productdefinitionid},{lotsummary.Productorderid},{lotsummary.Processdefinitionid},{lotsummary.Subprocessdefinitionid},{lotsummary.Processsegmentid},{lotsummary.Repeatcount},{lotsummary.Siteid}", lotSummary4Update.Isusable);
			lotSummary4Update.Isusable = "UnUsable";
			lotsummary.CopyCommonFieldUpdatePrev(lotSummary4Update, systemTime, dbContext.Tid, text);
			lotsummary.CopyExtensionCollection(lotSummary4Update);
			list.Add(lotSummary4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteLotSummary(IDbContext dbContext, Lotsummary[] lotSummaryList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotSummaryList", lotSummaryList);
		string text = "UnDeleteLotSummary";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotsummary> list = new List<Lotsummary>();
		foreach (Lotsummary lotsummary in lotSummaryList)
		{
			Lotsummary lotSummary4Update = GetLotSummary4Update(dbContext, lotsummary.Lotid, lotsummary.Productdefinitionid, lotsummary.Productorderid, lotsummary.Processdefinitionid, lotsummary.Subprocessdefinitionid, lotsummary.Processsegmentid, lotsummary.Repeatcount, lotsummary.Siteid);
			if (lotSummary4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lotsummary), $"{lotsummary.Lotid},{lotsummary.Productdefinitionid},{lotsummary.Productorderid},{lotsummary.Processdefinitionid},{lotsummary.Subprocessdefinitionid},{lotsummary.Processsegmentid},{lotsummary.Repeatcount},{lotsummary.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Lotsummary), $"{lotsummary.Lotid},{lotsummary.Productdefinitionid},{lotsummary.Productorderid},{lotsummary.Processdefinitionid},{lotsummary.Subprocessdefinitionid},{lotsummary.Processsegmentid},{lotsummary.Repeatcount},{lotsummary.Siteid}", lotSummary4Update.Isusable);
			lotSummary4Update.Isusable = "Usable";
			lotsummary.CopyCommonFieldUpdatePrev(lotSummary4Update, systemTime, dbContext.Tid, text);
			lotsummary.CopyExtensionCollection(lotSummary4Update);
			list.Add(lotSummary4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteLotSummary(IDbContext dbContext, Lotsummary[] lotSummaryList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotSummaryList", lotSummaryList);
		string text = "RealDeleteLotSummary";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotsummary> list = new List<Lotsummary>();
		foreach (Lotsummary lotsummary in lotSummaryList)
		{
			Lotsummary lotSummary4Update = GetLotSummary4Update(dbContext, lotsummary.Lotid, lotsummary.Productdefinitionid, lotsummary.Productorderid, lotsummary.Processdefinitionid, lotsummary.Subprocessdefinitionid, lotsummary.Processsegmentid, lotsummary.Repeatcount, lotsummary.Siteid);
			if (lotSummary4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lotsummary), $"{lotsummary.Lotid},{lotsummary.Productdefinitionid},{lotsummary.Productorderid},{lotsummary.Processdefinitionid},{lotsummary.Subprocessdefinitionid},{lotsummary.Processsegmentid},{lotsummary.Repeatcount},{lotsummary.Siteid}");
			}
			lotsummary.CopyCommonFieldUpdatePrev(lotSummary4Update, systemTime, dbContext.Tid, text);
			lotsummary.CopyExtensionCollection(lotSummary4Update);
			list.Add(lotSummary4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
