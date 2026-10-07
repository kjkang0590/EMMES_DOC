using System;
using System.Collections.Generic;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.POS;

public class BATCHAPI
{
	private static string _sqlGetBatchListByProductorderSqlDatabase = "SELECT * FROM CIM_BATCH WHERE PRODUCTORDERID=@PRODUCTORDERID AND SITEID=@SITEID";

	private static string _sqlSelectBatchListByProductorderSqlDatabase = "SELECT * FROM CIM_BATCH WHERE PRODUCTORDERID=@PRODUCTORDERID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetBatchListByProductorderOracleDatabase = "SELECT * FROM CIM_BATCH WHERE PRODUCTORDERID=:PRODUCTORDERID AND SITEID=:SITEID";

	private static string _sqlSelectBatchListByProductorderOracleDatabase = "SELECT * FROM CIM_BATCH WHERE PRODUCTORDERID=:PRODUCTORDERID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static Type typeOfThis = typeof(Batch);

	private static string _sqlGetBatchListByWorkorderSqlDatabase = "SELECT * FROM CIM_BATCH WHERE WORKORDERID=@WORKORDERID AND SITEID=@SITEID";

	private static string _sqlSelectBatchListByWorkorderSqlDatabase = "SELECT * FROM CIM_BATCH WHERE WORKORDERID=@WORKORDERID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetBatchListByWorkorderOracleDatabase = "SELECT * FROM CIM_BATCH WHERE WORKORDERID=:WORKORDERID AND SITEID=:SITEID";

	private static string _sqlSelectBatchListByWorkorderOracleDatabase = "SELECT * FROM CIM_BATCH WHERE WORKORDERID=:WORKORDERID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	public static IList<Batch> GetBatchListByProductorder(IDbContext dbContext, string productorderid, string siteid)
	{
		string apiName = "GetBatchListByProductorder";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productorderid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetBatchListByProductorderSqlDatabase : _sqlGetBatchListByProductorderOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("WORKORDERID", productorderid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_BATCH", $"{productorderid},{siteid}"));
		}
		IList<Batch> result = ContextManager.DirectEntityQuery<Batch>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productorderid},{siteid}");
		}
		return result;
	}

	public static IList<Batch> SelectBatchListByProductorder(IDbContext dbContext, string productorderid, string siteid)
	{
		string apiName = "SelectBatchListByProductorder";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productorderid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectBatchListByProductorderSqlDatabase : _sqlSelectBatchListByProductorderOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("WORKORDERID", productorderid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_BATCH", $"{productorderid},{siteid}"));
		}
		IList<Batch> result = ContextManager.DirectEntityQuery<Batch>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productorderid},{siteid}");
		}
		return result;
	}

	public static IList<Batch> GetBatchListByWorkorder(IDbContext dbContext, string workorderid, string siteid)
	{
		string apiName = "GetBatchListByWorkorder";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{workorderid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetBatchListByWorkorderSqlDatabase : _sqlGetBatchListByWorkorderOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("WORKORDERID", workorderid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_BATCH", $"{workorderid},{siteid}"));
		}
		IList<Batch> result = ContextManager.DirectEntityQuery<Batch>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{workorderid},{siteid}");
		}
		return result;
	}

	public static IList<Batch> SelectBatchListByWorkorder(IDbContext dbContext, string workorderid, string siteid)
	{
		string apiName = "SelectBatchListByWorkorder";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{workorderid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectBatchListByWorkorderSqlDatabase : _sqlSelectBatchListByWorkorderOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("WORKORDERID", workorderid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_BATCH", $"{workorderid},{siteid}"));
		}
		IList<Batch> result = ContextManager.DirectEntityQuery<Batch>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{workorderid},{siteid}");
		}
		return result;
	}
}
