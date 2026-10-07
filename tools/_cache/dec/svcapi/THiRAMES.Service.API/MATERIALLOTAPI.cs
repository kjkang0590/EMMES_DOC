using System;
using System.Collections.Generic;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace THiRAMES.Service.API;

public class MATERIALLOTAPI
{
	private static string _sqlSelectMaterialLotByEquipmentIdSqlDatabase = "SELECT  ML.* FROM CIM_MATERIALLOT ML INNER JOIN CIM_MATERIALDEFINITION MD ON AND MD.MATERIALDEFINITIONID = ML.MATERIALDEFINITIONID AND MD.SITEID = ML.SITEID AND MD.ISUSABLE = 'Usable' WHERE ML.EQUIPMENTID = @EQUIPMENTID AND ML.SITEID = @SITEID AND ML.STATE = 'Active' AND ML.ISUSABLE = 'Usable'";

	private static string _sqlSelectMaterialLotByEquipmentIdOracleDatabase = "SELECT  ML.* FROM CIM_MATERIALLOT ML INNER JOIN CIM_MATERIALDEFINITION MD ON AND MD.MATERIALDEFINITIONID = ML.MATERIALDEFINITIONID AND MD.SITEID = ML.SITEID AND MD.ISUSABLE = 'Usable' WHERE ML.EQUIPMENTID = :EQUIPMENTID AND ML.SITEID = :SITEID AND ML.STATE = 'Active' AND ML.ISUSABLE = 'Usable'";

	private static string _sqlSelectMaterialLotByInboxSqlDatabase = "SELECT * FROM CIM_MATERIALLOT WHERE INBOX = @INBOX AND SITEID = @SITEID AND ISUSABLE = 'Usable'";

	private static string _sqlSelectMaterialLotByInboxOracleDatabase = "SELECT * FROM CIM_MATERIALLOT WHERE INBOX = :INBOX AND SITEID = :SITEID AND ISUSABLE = 'Usable'";

	private static string _sqlSelectMaterialLotByOutboxSqlDatabase = "SELECT * FROM CIM_MATERIALLOT WHERE OUTBOX = @OUTBOX AND SITEID = @SITEID AND ISUSABLE = 'Usable'";

	private static string _sqlSelectMaterialLotByOutboxOracleDatabase = "SELECT * FROM CIM_MATERIALLOT WHERE OUTBOX = :OUTBOX AND SITEID = :SITEID AND ISUSABLE = 'Usable'";

	private static string _sqlSelectMaterialLotByPalletSqlDatabase = "SELECT * FROM CIM_MATERIALLOT WHERE PALLETID = @PALLETID AND SITEID = @SITEID AND ISUSABLE = 'Usable'";

	private static string _sqlSelectMaterialLotByPalletOracleDatabase = "SELECT * FROM CIM_MATERIALLOT WHERE PALLETID = :PALLETID AND SITEID = :SITEID AND ISUSABLE = 'Usable'";

	private static string _sqlSelectMaterialLotListByMaterialLotPortRelSqlDatabase = "SELECT ML.*, MP.EQUIPMENTID AS KITEQUIPMENTID, MP.PORTID AS KITPORTID FROM CIM_MATERIALLOTPORTREL MP INNER JOIN CIM_MATERIALLOT ML ON MP.MATERIALLOTID = ML.MATERIALLOTID AND MP.SITEID = ML.SITEID AND MP.ISUSABLE ='Usable' WHERE MP.EQUIPMENTID = @EQUIPMENTID AND ML.SITEID = @SITEID AND ML.ISUSABLE = 'Usable'";

	private static string _sqlSelectMaterialLotListByMaterialLotPortRelOracleDatabase = "SELECT ML.*, MP.EQUIPMENTID AS KITEQUIPMENTID, MP.PORTID AS KITPORTID FROM CIM_MATERIALLOTPORTREL MP INNER JOIN CIM_MATERIALLOT ML ON MP.MATERIALLOTID = ML.MATERIALLOTID AND MP.SITEID = ML.SITEID AND MP.ISUSABLE ='Usable' WHERE MP.EQUIPMENTID = :EQUIPMENTID AND ML.SITEID = :SITEID AND ML.ISUSABLE = 'Usable'";

	private static string _sqlSelectMaterialLotListByMbomSqlDatabase = "\nSELECT ML.SITEID, ML.MATERIALDEFINITIONID, MPR.MATERIALLOTID, MPR.KITTINGTIME AS FIFOTIME, MPR.PORTID, ML.QTY, ML.LOCATION\n  FROM CIM_MATERIALLOTPORTREL MPR\n INNER JOIN CIM_MATERIALLOT ML\n    ON MPR.MATERIALLOTID = ML.MATERIALLOTID AND MPR.SITEID = ML.SITEID AND ML.STATE = 'Active' AND ML.ISUSABLE = 'Usable'\n   AND MPR.EQUIPMENTID = @EQUIPMENTID AND ML.MATERIALDEFINITIONID = @MATERIALDEFINITIONID \n WHERE ISNULL(MPR.PORTID, '-') = @PORTID AND ML.SITEID = @SITEID AND ML.ISUSABLE = 'Usable' \n   AND (@KITTINGYN = 'Y') \n UNION ALL \nSELECT ML.SITEID, ML.MATERIALDEFINITIONID, MATERIALLOTID, ML.STOCKDATE AS FIFOTIME, '-' AS PORTID, ML.QTY, ML.LOCATION \n  FROM CIM_MATERIALLOT ML\n WHERE ML.MATERIALDEFINITIONID = @MATERIALDEFINITIONID AND ML.LOCATION = @LOCATION AND ML.SITEID = @SITEID AND ML.STATE = 'Active' AND ML.ISUSABLE = 'Usable' \n    AND (@KITTINGYN = 'N')\n";

	private static string _sqlSelectMaterialLotListByMbomOracleDatabase = "\nSELECT ML.SITEID, ML.MATERIALDEFINITIONID, MPR.MATERIALLOTID, MPR.KITTINGTIME AS FIFOTIME, MPR.PORTID, ML.QTY, ML.LOCATION\n  FROM CIM_MATERIALLOTPORTREL MPR\n INNER JOIN CIM_MATERIALLOT ML\n    ON MPR.MATERIALLOTID = ML.MATERIALLOTID AND MPR.SITEID = ML.SITEID AND ML.STATE = 'Active' AND ML.ISUSABLE = 'Usable'\n   AND MPR.EQUIPMENTID = :EQUIPMENTID AND ML.MATERIALDEFINITIONID = :MATERIALDEFINITIONID \n WHERE NVL(MPR.PORTID, '-') = :PORTID AND ML.SITEID = :SITEID AND ML.ISUSABLE = 'Usable'\n   AND (:KITTINGYN = 'Y')\n UNION ALL \nSELECT ML.SITEID, ML.MATERIALDEFINITIONID, MATERIALLOTID, ML.STOCKDATE AS FIFOTIME, '-' AS PORTID, ML.QTY, ML.LOCATION \n  FROM CIM_MATERIALLOT ML\n WHERE ML.MATERIALDEFINITIONID = :MATERIALDEFINITIONID AND ML.LOCATION = :LOCATION AND ML.SITEID = :SITEID AND ML.STATE = 'Active' AND ML.ISUSABLE = 'Usable' \n   AND (:KITTINGYN = 'N')\n";

	private static Type typeOfThis = typeof(Materiallot);

	private static string _sqlSelectMaterialLotListByPurchaseorderIQCSqlDatabase = "SELECT * FROM CIM_MATERIALLOT WHERE PURCHASEORDERITEMNO = @PURCHASEORDERITEMNO AND SITEID = @SITEID AND ISUSABLE = 'Usable'";

	private static string _sqlSelectMaterialLotListByPurchaseorderIQCOracleDatabase = "SELECT * FROM CIM_MATERIALLOT WHERE PURCHASEORDERITEMNO = :PURCHASEORDERITEMNO AND SITEID = :SITEID AND ISUSABLE = 'Usable'";

	private static string _sqlSelectMaterialLotPortRelListByEquipmentPortIdMaterialdefinitionidSqlDatabase = "SELECT ML.* FROM CIM_MATERIALLOTPORTREL MP INNER JOIN CIM_MATERIALLOT ML ON MP.MATERIALLOTID = ML.MATERIALLOTID AND MP.SITEID = ML.SITEID AND ML.MATERIALDEFINITIONID = @MATERIALDEFINITIONID AND MP.ISUSABLE ='Usable' WHERE MP.EQUIPMENTID = @EQUIPMENTID AND MP.PORTID = @PORTID AND ML.SITEID = @SITEID AND ML.ISUSABLE = 'Usable'";

	private static string _sqlSelectMaterialLotPortRelListByEquipmentPortIdMaterialdefinitionidOracleDatabase = "SELECT ML.* FROM CIM_MATERIALLOTPORTREL MP INNER JOIN CIM_MATERIALLOT ML ON MP.MATERIALLOTID = ML.MATERIALLOTID AND MP.SITEID = ML.SITEID AND ML.MATERIALDEFINITIONID = :MATERIALDEFINITIONID AND MP.ISUSABLE ='Usable' WHERE MP.EQUIPMENTID = :EQUIPMENTID AND MP.PORTID = :PORTID AND ML.SITEID = :SITEID AND ML.ISUSABLE = 'Usable'";

	public static IList<Materiallot> SelectMaterialLotByEquipmentId(IDbContext dbContext, string equipmentid, string siteid)
	{
		string apiName = "SelectMaterialLotByEquipmentId";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMaterialLotByEquipmentIdSqlDatabase : _sqlSelectMaterialLotByEquipmentIdOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid));
		list.Add(dbContext.CreateParameter("SITEID", siteid));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MBOM", $"{equipmentid},{siteid}"));
		}
		IList<Materiallot> result = ContextManager.DirectEntityQuery<Materiallot>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentid},{siteid}");
		}
		return result;
	}

	public static IList<Materiallot> SelectMaterialLotByInbox(IDbContext dbContext, string inbox, string siteid)
	{
		string apiName = "SelectMaterialLotByInbox";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inbox},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMaterialLotByInboxSqlDatabase : _sqlSelectMaterialLotByInboxOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INBOX", inbox));
		list.Add(dbContext.CreateParameter("SITEID", siteid));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MATERIALLOT", $"{inbox},{siteid}"));
		}
		IList<Materiallot> result = ContextManager.DirectEntityQuery<Materiallot>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inbox},{siteid}");
		}
		return result;
	}

	public static IList<Materiallot> SelectMaterialLotByOutbox(IDbContext dbContext, string outbox, string siteid)
	{
		string apiName = "SelectMaterialLotByOutbox";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{outbox},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMaterialLotByOutboxSqlDatabase : _sqlSelectMaterialLotByOutboxOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("OUTBOX", outbox));
		list.Add(dbContext.CreateParameter("SITEID", siteid));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MATERIALLOT", $"{outbox},{siteid}"));
		}
		IList<Materiallot> result = ContextManager.DirectEntityQuery<Materiallot>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{outbox},{siteid}");
		}
		return result;
	}

	public static IList<Materiallot> SelectMaterialLotByPalletid(IDbContext dbContext, string palletid, string siteid)
	{
		string apiName = "SelectMaterialLotByPalletid";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{palletid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMaterialLotByPalletSqlDatabase : _sqlSelectMaterialLotByPalletOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PALLETID", palletid));
		list.Add(dbContext.CreateParameter("SITEID", siteid));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MATERIALLOT", $"{palletid},{siteid}"));
		}
		IList<Materiallot> result = ContextManager.DirectEntityQuery<Materiallot>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{palletid},{siteid}");
		}
		return result;
	}

	public static IList<Materiallot> SelectMaterialLotListByMaterialLotPortRel(IDbContext dbContext, string equipmentid, string siteid)
	{
		string apiName = "SelectMaterialLotListByMaterialLotPortRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMaterialLotListByMaterialLotPortRelSqlDatabase : _sqlSelectMaterialLotListByMaterialLotPortRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid));
		list.Add(dbContext.CreateParameter("SITEID", siteid));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MATERIALLOT", $"{equipmentid},{siteid}"));
		}
		IList<Materiallot> result = ContextManager.DirectEntityQuery<Materiallot>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentid},{siteid}");
		}
		return result;
	}

	public static IList<Materiallot> SelectMaterialLotListByMbom(IDbContext dbContext, string materialdefinitionid, string equipmentid, string port, string kittingyn, string location, string siteid)
	{
		string apiName = "SelectMaterialLotListByMbom";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{materialdefinitionid},{equipmentid},{port},{kittingyn},{location},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMaterialLotListByMbomSqlDatabase : _sqlSelectMaterialLotListByMbomOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MATERIALDEFINITIONID", materialdefinitionid));
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid));
		list.Add(dbContext.CreateParameter("PORTID", string.IsNullOrEmpty(port) ? "-" : port));
		list.Add(dbContext.CreateParameter("KITTINGYN", "Y".Equals(kittingyn) ? "Y" : "N"));
		list.Add(dbContext.CreateParameter("LOCATION", location));
		list.Add(dbContext.CreateParameter("SITEID", siteid));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MBOM", $"{materialdefinitionid},{equipmentid},{port},{kittingyn},{location},{siteid}"));
		}
		IList<Materiallot> result = ContextManager.DirectEntityQuery<Materiallot>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{materialdefinitionid},{equipmentid},{port},{kittingyn},{location},{siteid}");
		}
		return result;
	}

	public static IList<Materiallot> SelectMaterialLotListByPurchaseorderitemno(IDbContext dbContext, string purchaseorderitemno, string siteid)
	{
		string apiName = "SelectMaterialLotListByPurchaseorderitemno";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{purchaseorderitemno},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMaterialLotListByPurchaseorderIQCSqlDatabase : _sqlSelectMaterialLotListByPurchaseorderIQCOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PURCHASEORDERITEMNO", purchaseorderitemno, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MATERIALLOT", $"{purchaseorderitemno},{siteid}"));
		}
		IList<Materiallot> result = ContextManager.DirectEntityQuery<Materiallot>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{purchaseorderitemno},{siteid}");
		}
		return result;
	}

	public static IList<Materiallot> SelectMaterialLotPortRelListByEquipmentPortIdMaterialdefinitionid(IDbContext dbContext, string equipmentid, string port, string materialdefinitionid, string siteid)
	{
		string apiName = "SelectMaterialLotPortRelListByEquipmentPortIdMaterialdefinitionid";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentid},{port},{materialdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMaterialLotPortRelListByEquipmentPortIdMaterialdefinitionidSqlDatabase : _sqlSelectMaterialLotPortRelListByEquipmentPortIdMaterialdefinitionidOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid));
		list.Add(dbContext.CreateParameter("PORTID", port));
		list.Add(dbContext.CreateParameter("MATERIALDEFINITIONID", materialdefinitionid));
		list.Add(dbContext.CreateParameter("SITEID", siteid));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MATERIALLOT", $"{equipmentid},{port},{materialdefinitionid},{siteid}"));
		}
		IList<Materiallot> result = ContextManager.DirectEntityQuery<Materiallot>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentid},{port},{materialdefinitionid},{siteid}");
		}
		return result;
	}
}
