using System.Collections.Generic;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace THiRAMES.Service.API;

public class LOTAPI
{
	private static string _sqlSelectLotListByCarrierIdSqlDatabase = "\n        SELECT L.*\n        FROM CIM_LOTCARRIERREL LCR \n        INNER JOIN CIM_LOT L\n\t        ON LCR.LOTID = L.LOTID  AND LCR.SITEID = L.SITEID \n        WHERE LCR.CARRIERID = @CARRIERID AND L.SITEID = @SITEID AND L.ISUSABLE = 'Usable'\n        ";

	private static string _sqlSelectLotListByCarrierIdOracleDatabase = "\n        SELECT L.*\n        FROM CIM_LOTCARRIERREL LCR \n        INNER JOIN CIM_LOT L\n\t        ON LCR.LOTID = L.LOTID  AND LCR.SITEID = L.SITEID \n        WHERE LCR.CARRIERID = :CARRIERID AND L.SITEID = :SITEID AND L.ISUSABLE = 'Usable'\n        ";

	private static string _sqlSelectLotListByParentlotIdSqlDatabase = "SELECT * FROM CIM_LOT WHERE PARENTLOTID = @PARENTLOTID AND SITEID = @SITEID AND ISUSABLE = 'Usable'";

	private static string _sqlSelectLotListByParentlotIdOracleDatabase = "SELECT * FROM CIM_LOT WHERE PARENTLOTID = :PARENTLOTID AND SITEID = :SITEID AND ISUSABLE = 'Usable'";

	public static IList<Lot> SelectLotListByCarrierId(IDbContext dbContext, string CarrierId, string siteid)
	{
		string apiName = "SelectLotListByCarrierId";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{CarrierId},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotListByCarrierIdSqlDatabase : _sqlSelectLotListByCarrierIdOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CARRIERID", CarrierId));
		list.Add(dbContext.CreateParameter("SITEID", siteid));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}", "SELECT", "CIM_LOT", $"{CarrierId},{siteid}"));
		}
		IList<Lot> result = ContextManager.DirectEntityQuery<Lot>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{CarrierId},{siteid}");
		}
		return result;
	}

	public static IList<Lot> SelectLotListByParentlotId(IDbContext dbContext, string parentlotid, string siteid)
	{
		string apiName = "SelectLotListByParentlotId";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{parentlotid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotListByParentlotIdSqlDatabase : _sqlSelectLotListByParentlotIdOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PARENTLOTID", parentlotid));
		list.Add(dbContext.CreateParameter("SITEID", siteid));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}", "SELECT", "CIM_LOT", $"{parentlotid},{siteid}"));
		}
		IList<Lot> result = ContextManager.DirectEntityQuery<Lot>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{parentlotid},{siteid}");
		}
		return result;
	}
}
