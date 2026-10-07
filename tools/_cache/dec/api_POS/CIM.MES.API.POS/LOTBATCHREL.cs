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
public class LOTBATCHREL
{
	private static string _sqlGetLotBatchRelSqlDatabase = "SELECT * FROM CIM_LOTBATCHREL WHERE LOTID=@LOTID AND BATCHID=@BATCHID AND SITEID=@SITEID";

	private static string _sqlGetLotBatchRel4UpdateSqlDatabase = "SELECT * FROM CIM_LOTBATCHREL WITH(UPDLOCK) WHERE LOTID=@LOTID AND BATCHID=@BATCHID AND SITEID=@SITEID";

	private static string _sqlSelectLotBatchRelSqlDatabase = "SELECT * FROM CIM_LOTBATCHREL WHERE LOTID=@LOTID AND BATCHID=@BATCHID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLotBatchRel4UpdateSqlDatabase = "SELECT * FROM CIM_LOTBATCHREL WITH(UPDLOCK) WHERE LOTID=@LOTID AND BATCHID=@BATCHID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetLotBatchRelOracleDatabase = "SELECT * FROM CIM_LOTBATCHREL WHERE LOTID=:LOTID AND BATCHID=:BATCHID AND SITEID=:SITEID";

	private static string _sqlGetLotBatchRel4UpdateOracleDatabase = "SELECT * FROM CIM_LOTBATCHREL WHERE LOTID=:LOTID AND BATCHID=:BATCHID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectLotBatchRelOracleDatabase = "SELECT * FROM CIM_LOTBATCHREL WHERE LOTID=:LOTID AND BATCHID=:BATCHID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLotBatchRel4UpdateOracleDatabase = "SELECT * FROM CIM_LOTBATCHREL WHERE LOTID=:LOTID AND BATCHID=:BATCHID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Lotbatchrel);

	private static string _sqlSelectLotBatchRelAllListWithBatchidSqlDatabase = "SELECT * FROM CIM_LOTBATCHREL WHERE BATCHID=@BATCHID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLotBatchRelAllListWithBatchidOracleDatabase = "SELECT * FROM CIM_LOTBATCHREL WHERE BATCHID=:BATCHID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLotBatchRelAllListWithLotidSqlDatabase = "SELECT * FROM CIM_LOTBATCHREL WHERE LOTID=@LOTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLotBatchRelAllListWithLotidOracleDatabase = "SELECT * FROM CIM_LOTBATCHREL WHERE LOTID=:LOTID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	public static Lotbatchrel GetLotBatchRel(IDbContext dbContext, string lotid, string batchid, string siteid)
	{
		string apiName = "GetLotBatchRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{batchid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLotBatchRelSqlDatabase : _sqlGetLotBatchRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("BATCHID", batchid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOTBATCHREL", $"{lotid},{batchid},{siteid}"));
		}
		Lotbatchrel? result = ContextManager.DirectEntityQuery<Lotbatchrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{batchid},{siteid}");
		}
		return result;
	}

	public static Lotbatchrel GetLotBatchRel4Update(IDbContext dbContext, string lotid, string batchid, string siteid)
	{
		string apiName = "GetLotBatchRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{batchid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLotBatchRel4UpdateSqlDatabase : _sqlGetLotBatchRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("BATCHID", batchid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_LOTBATCHREL", $"{lotid},{batchid},{siteid}"));
		}
		Lotbatchrel? result = ContextManager.DirectEntityQuery<Lotbatchrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{batchid},{siteid}");
		}
		return result;
	}

	public static Lotbatchrel SelectLotBatchRel(IDbContext dbContext, string lotid, string batchid, string siteid)
	{
		string apiName = "SelectLotBatchRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{batchid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotBatchRelSqlDatabase : _sqlSelectLotBatchRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("BATCHID", batchid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOTBATCHREL", $"{lotid},{batchid},{siteid}"));
		}
		Lotbatchrel? result = ContextManager.DirectEntityQuery<Lotbatchrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{batchid},{siteid}");
		}
		return result;
	}

	public static Lotbatchrel SelectLotBatchRel4Update(IDbContext dbContext, string lotid, string batchid, string siteid)
	{
		string apiName = "SelectLotBatchRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{batchid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotBatchRel4UpdateSqlDatabase : _sqlSelectLotBatchRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("BATCHID", batchid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_LOTBATCHREL", $"{lotid},{batchid},{siteid}"));
		}
		Lotbatchrel? result = ContextManager.DirectEntityQuery<Lotbatchrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{batchid},{siteid}");
		}
		return result;
	}

	public static int UpsertLotBatchRel(IDbContext dbContext, RequestType requestType, Lotbatchrel[] lotBatchRelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateLotBatchRelInternal(dbContext, lotBatchRelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateLotBatchRel(dbContext, lotBatchRelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteLotBatchRel(dbContext, lotBatchRelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteLotBatchRel(dbContext, lotBatchRelList, optionSet, saveHist), 
			_ => RealDeleteLotBatchRel(dbContext, lotBatchRelList, optionSet, saveHist), 
		};
	}

	private static int CreateLotBatchRelInternal(IDbContext dbContext, Lotbatchrel[] lotBatchRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotBatchRelList", lotBatchRelList);
		string text = "CreateLotBatchRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotbatchrel> list = new List<Lotbatchrel>();
		foreach (Lotbatchrel obj in lotBatchRelList)
		{
			Lotbatchrel lotbatchrel = new Lotbatchrel();
			obj.CopyColumsTo(lotbatchrel);
			lotbatchrel.Activity = text;
			lotbatchrel.CheckEntityUsable();
			obj.CopyCommonField(lotbatchrel, systemTime, dbContext.Tid, isCreate: true);
			list.Add(lotbatchrel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateLotBatchRel(IDbContext dbContext, Lotbatchrel[] lotBatchRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotBatchRelList", lotBatchRelList);
		string text = "UpdateLotBatchRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotbatchrel> list = new List<Lotbatchrel>();
		foreach (Lotbatchrel lotbatchrel in lotBatchRelList)
		{
			Lotbatchrel lotBatchRel4Update = GetLotBatchRel4Update(dbContext, lotbatchrel.Lotid, lotbatchrel.Batchid, lotbatchrel.Siteid);
			if (lotBatchRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lotbatchrel), $"{lotbatchrel.Lotid},{lotbatchrel.Batchid},{lotbatchrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Lotbatchrel), $"{lotbatchrel.Lotid},{lotbatchrel.Batchid},{lotbatchrel.Siteid}", lotBatchRel4Update.Isusable);
			string activity = lotBatchRel4Update.Activity;
			string customactivity = lotBatchRel4Update.Customactivity;
			string isusable = lotBatchRel4Update.Isusable;
			DateTime? createtime = lotBatchRel4Update.Createtime;
			string creator = lotBatchRel4Update.Creator;
			lotbatchrel.CopyColumsTo(lotBatchRel4Update);
			lotBatchRel4Update.Prevactivity = activity;
			lotBatchRel4Update.Prevcustomactivity = customactivity;
			lotBatchRel4Update.Creator = creator;
			lotBatchRel4Update.Createtime = createtime;
			lotBatchRel4Update.Isusable = isusable;
			lotBatchRel4Update.Activity = text;
			lotbatchrel.CopyCommonField(lotBatchRel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(lotBatchRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteLotBatchRel(IDbContext dbContext, Lotbatchrel[] lotBatchRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotBatchRelList", lotBatchRelList);
		string text = "DeleteLotBatchRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotbatchrel> list = new List<Lotbatchrel>();
		foreach (Lotbatchrel lotbatchrel in lotBatchRelList)
		{
			Lotbatchrel lotBatchRel4Update = GetLotBatchRel4Update(dbContext, lotbatchrel.Lotid, lotbatchrel.Batchid, lotbatchrel.Siteid);
			if (lotBatchRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lotbatchrel), $"{lotbatchrel.Lotid},{lotbatchrel.Batchid},{lotbatchrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Lotbatchrel), $"{lotbatchrel.Lotid},{lotbatchrel.Batchid},{lotbatchrel.Siteid}", lotBatchRel4Update.Isusable);
			lotBatchRel4Update.Isusable = "UnUsable";
			lotbatchrel.CopyCommonFieldUpdatePrev(lotBatchRel4Update, systemTime, dbContext.Tid, text);
			lotbatchrel.CopyExtensionCollection(lotBatchRel4Update);
			list.Add(lotBatchRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteLotBatchRel(IDbContext dbContext, Lotbatchrel[] lotBatchRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotBatchRelList", lotBatchRelList);
		string text = "UnDeleteLotBatchRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotbatchrel> list = new List<Lotbatchrel>();
		foreach (Lotbatchrel lotbatchrel in lotBatchRelList)
		{
			Lotbatchrel lotBatchRel4Update = GetLotBatchRel4Update(dbContext, lotbatchrel.Lotid, lotbatchrel.Batchid, lotbatchrel.Siteid);
			if (lotBatchRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lotbatchrel), $"{lotbatchrel.Lotid},{lotbatchrel.Batchid},{lotbatchrel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Lotbatchrel), $"{lotbatchrel.Lotid},{lotbatchrel.Batchid},{lotbatchrel.Siteid}", lotBatchRel4Update.Isusable);
			lotBatchRel4Update.Isusable = "Usable";
			lotbatchrel.CopyCommonFieldUpdatePrev(lotBatchRel4Update, systemTime, dbContext.Tid, text);
			lotbatchrel.CopyExtensionCollection(lotBatchRel4Update);
			list.Add(lotBatchRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteLotBatchRel(IDbContext dbContext, Lotbatchrel[] lotBatchRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotBatchRelList", lotBatchRelList);
		string text = "RealDeleteLotBatchRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotbatchrel> list = new List<Lotbatchrel>();
		foreach (Lotbatchrel lotbatchrel in lotBatchRelList)
		{
			Lotbatchrel lotBatchRel4Update = GetLotBatchRel4Update(dbContext, lotbatchrel.Lotid, lotbatchrel.Batchid, lotbatchrel.Siteid);
			if (lotBatchRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lotbatchrel), $"{lotbatchrel.Lotid},{lotbatchrel.Batchid},{lotbatchrel.Siteid}");
			}
			lotbatchrel.CopyCommonFieldUpdatePrev(lotBatchRel4Update, systemTime, dbContext.Tid, text);
			lotbatchrel.CopyExtensionCollection(lotBatchRel4Update);
			list.Add(lotBatchRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static IList<Lotbatchrel> SelectLotBatchRelAllListWithBatchid(IDbContext dbContext, string batchid, string siteid)
	{
		string apiName = "SelectLotBatchRelAllListWithBatchid";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{batchid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotBatchRelAllListWithBatchidSqlDatabase : _sqlSelectLotBatchRelAllListWithBatchidOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("BATCHID", batchid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOTBATCHREL", $"{batchid},{siteid}"));
		}
		IList<Lotbatchrel> result = ContextManager.DirectEntityQuery<Lotbatchrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{batchid},{siteid}");
		}
		return result;
	}

	public static IList<Lotbatchrel> SelectLotBatchRelAllListWithLotid(IDbContext dbContext, string lotid, string siteid)
	{
		string apiName = "SelectLotBatchRelAllListWithLotid";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotBatchRelAllListWithLotidSqlDatabase : _sqlSelectLotBatchRelAllListWithLotidOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOTBATCHREL", $"{lotid},{siteid}"));
		}
		IList<Lotbatchrel> result = ContextManager.DirectEntityQuery<Lotbatchrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{siteid}");
		}
		return result;
	}
}
