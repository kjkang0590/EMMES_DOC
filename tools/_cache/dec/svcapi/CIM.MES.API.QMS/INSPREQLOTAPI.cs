using System;
using System.Collections.Generic;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.QMS;

public class INSPREQLOTAPI
{
	private static string _sqlSelectInsReqLotExistByBatchIdSqlDatabase = "\n        SELECT RL.*\n        FROM CIM_INSPREQLOT RL\n        INNER JOIN CIM_INSPREQ R \n\t        ON  RL.INSPREQNO = R.INSPREQNO\n\t        AND R.ISUSABLE = 'Usable'\n            AND RL.SITEID = R.SITEID\n        WHERE RL.BATCHID = @BATCHID\n        \tAND R.STATE <> 'Close'\n        \tAND RL.ISUSABLE = 'Usable'\n\t\t\tAND R.SITEID = @SITEID\n        ";

	private static string _sqlSelectInsReqLotExistByBatchIdOracleDatabase = "\n        SELECT RL.*\n        FROM CIM_INSPREQLOT RL\n        INNER JOIN CIM_INSPREQ R \n\t        ON  RL.INSPREQNO = R.INSPREQNO\n\t        AND R.ISUSABLE = 'Usable'\n            AND RL.SITEID = R.SITEID\n        WHERE RL.BATCHID = :BATCHID\n        \tAND R.STATE <> 'Close'\n        \tAND RL.ISUSABLE = 'Usable'\n\t\t\tAND R.SITEID = :SITEID\n        ";

	private static Type typeOfThis = typeof(Inspreqlot);

	public static IList<Inspreqlot> SelectInsReqLotExistByBatchId(IDbContext dbContext, string batchid, string siteid)
	{
		string apiName = "SelectInsReqLotExistByBatchId";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{batchid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectInsReqLotExistByBatchIdSqlDatabase : _sqlSelectInsReqLotExistByBatchIdOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("BATCHID", batchid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_INSPREQLOT", $"{batchid},{siteid}"));
		}
		IList<Inspreqlot> result = ContextManager.DirectEntityQuery<Inspreqlot>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{batchid},{siteid}");
		}
		return result;
	}
}
