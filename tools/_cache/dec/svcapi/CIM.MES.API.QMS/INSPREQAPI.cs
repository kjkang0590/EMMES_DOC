using System;
using System.Collections.Generic;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.QMS;

public class INSPREQAPI
{
	private static string _sqlSelectInspreqListByPurchaseorderSqlDatabase = "\nSELECT R.* FROM CIM_INSPREQ R WHERE EXISTS (\n \tSELECT 1 FROM CIM_MATERIALLOT M INNER JOIN CIM_INSPREQLOT L ON L.INSPLOTID = M.MATERIALLOTID AND L.SITEID = M.SITEID AND M.ISUSABLE ='Usable' AND L.INSPREQNO = R.INSPREQNO AND L.SITEID = R.SITEID WHERE M.PURCHASEORDERITEMNO = @PURCHASEORDERITEMNO AND M.SITEID = @SITEID AND M.ISUSABLE ='Usable'\n  )\n  AND R.INSPTYPE = @INSPTYPE AND R.SITEID = @SITEID AND R.ISUSABLE ='Usable'\n";

	private static string _sqlSelectInspreqListByPurchaseorderOracleDatabase = "\nSELECT R.* FROM CIM_INSPREQ R WHERE EXISTS (\n \tSELECT 1 FROM CIM_MATERIALLOT M INNER JOIN CIM_INSPREQLOT L ON L.INSPLOTID = M.MATERIALLOTID AND L.SITEID = M.SITEID AND M.ISUSABLE ='Usable' AND L.INSPREQNO = R.INSPREQNO AND L.SITEID = R.SITEID WHERE M.PURCHASEORDERITEMNO = :PURCHASEORDERITEMNO AND M.SITEID = :SITEID AND M.ISUSABLE ='Usable'\n  )\n  AND R.INSPTYPE = :INSPTYPE AND R.SITEID = :SITEID AND R.ISUSABLE ='Usable'\n";

	private static Type typeOfThis = typeof(Inspreq);

	public static IList<Inspreq> SelectInspreqListByPurchaseorderitemno(IDbContext dbContext, string insptype, string purchaseorderitemno, string siteid)
	{
		string apiName = "SelectInspreqListByPurchaseorderitemno";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{purchaseorderitemno},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectInspreqListByPurchaseorderSqlDatabase : _sqlSelectInspreqListByPurchaseorderOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPTYPE", insptype, typeOfThis));
		list.Add(dbContext.CreateParameter("PURCHASEORDERITEMNO", purchaseorderitemno, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_INSPREQ", $"{purchaseorderitemno},{siteid}"));
		}
		IList<Inspreq> result = ContextManager.DirectEntityQuery<Inspreq>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{purchaseorderitemno},{siteid}");
		}
		return result;
	}
}
