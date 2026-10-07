using System;
using System.Collections.Generic;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace THiRAMES.Service.API;

public class MBOMAPI
{
	private static string _sqlSelectMbomListSqlDatabase = "SELECT MB.*, MD.MATERIALDEFINITIONNAME FROM CIM_MBOM MB INNER JOIN CIM_MATERIALDEFINITION MD ON MB.MATERIALDEFINITIONID = MD.MATERIALDEFINITIONID AND MB.SITEID = MD.SITEID AND MD.ISUSABLE = 'Usable' WHERE MB.PRODUCTRULESYSID = @PRODUCTRULESYSID AND MB.SITEID = @SITEID AND MB.ISUSABLE = 'Usable'";

	private static string _sqlSelectMbomListOracleDatabase = "SELECT MB.*, MD.MATERIALDEFINITIONNAME FROM CIM_MBOM MB INNER JOIN CIM_MATERIALDEFINITION MD ON MB.MATERIALDEFINITIONID = MD.MATERIALDEFINITIONID AND MB.SITEID = MD.SITEID AND MD.ISUSABLE = 'Usable' WHERE MB.PRODUCTRULESYSID = :PRODUCTRULESYSID AND MB.SITEID = :SITEID AND MB.ISUSABLE = 'Usable'";

	private static Type typeOfThis = typeof(Mbom);

	private static string _sqlSelectMbomListByRecipeIdSqlDatabase = "SELECT B.*, RD.EQUIPMENTID FROM CIM_MBOM B INNER JOIN CIM_RECIPEDEFINITION RD ON B.PRODUCTRULESYSID = RD.PRODUCTRULESYSID AND B.SITEID = RD.SITEID AND RD.STATE = 'Active' AND RD.ISUSABLE = 'Usable' WHERE B.RECIPEDEFINITIONID = @RECIPEDEFINITIONID AND B.SITEID = @SITEID AND B.ISUSABLE = 'Usable'";

	private static string _sqlSelectMbomListByRecipeIdOracleDatabase = "SELECT B.*, RD.EQUIPMENTID FROM CIM_MBOM B INNER JOIN CIM_RECIPEDEFINITION RD ON B.PRODUCTRULESYSID = RD.PRODUCTRULESYSID AND B.SITEID = RD.SITEID AND RD.STATE = 'Active' AND RD.ISUSABLE = 'Usable' WHERE B.RECIPEDEFINITIONID = :RECIPEDEFINITIONID AND B.SITEID = :SITEID AND B.ISUSABLE = 'Usable'";

	private static string _sqlSelectMbomListByRecipeParameterSqlDatabase = "\n SELECT B.*, RD.EQUIPMENTID\n   FROM CIM_MBOM B\n  INNER JOIN CIM_RECIPEDEFINITION RD\n    ON B.RECIPEDEFINITIONID = RD.RECIPEDEFINITIONID AND B.PRODUCTRULESYSID = RD.PRODUCTRULESYSID AND B.SITEID = RD.SITEID AND RD.ISUSABLE = 'Usable' AND RD.STATE = 'Active'\n  LEFT JOIN CIM_RECIPEPARAMETER RP\n    ON RP.RECIPEDEFINITIONID = B.RECIPEDEFINITIONID AND RP.SITEID = B.SITEID AND RP.VALIDATIONTYPE = 'Material' AND RP.ISUSABLE = 'Usable'\n WHERE B.RECIPEDEFINITIONID = @RECIPEDEFINITIONID AND B.SITEID = @SITEID AND B.ISUSABLE = 'Usable'\n";

	private static string _sqlSelectMbomListByRecipeParameterOracleDatabase = "\n SELECT B.*, RD.EQUIPMENTID\n  FROM CIM_MBOM B\n INNER JOIN CIM_RECIPEDEFINITION RD\n    ON B.RECIPEDEFINITIONID = RD.RECIPEDEFINITIONID AND B.PRODUCTRULESYSID = RD.PRODUCTRULESYSID AND B.SITEID = RD.SITEID AND RD.ISUSABLE = 'Usable' AND RD.STATE = 'Active'\n  LEFT JOIN CIM_RECIPEPARAMETER RP\n    ON RP.RECIPEDEFINITIONID = B.RECIPEDEFINITIONID AND RP.SITEID = B.SITEID AND RP.VALIDATIONTYPE = 'Material' AND RP.ISUSABLE = 'Usable'\n WHERE B.RECIPEDEFINITIONID = :RECIPEDEFINITIONID AND B.SITEID = :SITEID AND B.ISUSABLE = 'Usable'\n";

	public static IList<Mbom> SelectMbomList(IDbContext dbContext, string productrulesysid, string siteid)
	{
		string apiName = "SelectMbomList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productrulesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMbomListSqlDatabase : _sqlSelectMbomListOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTRULESYSID", productrulesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}", "SELECT", "CIM_MBOM", $"{productrulesysid},{siteid}"));
		}
		IList<Mbom> result = ContextManager.DirectEntityQuery<Mbom>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productrulesysid},{siteid}");
		}
		return result;
	}

	public static IList<Mbom> SelectMbomListByRecipeId(IDbContext dbContext, string recipedefinitionid, string siteid)
	{
		string apiName = "SelectMbomListByRecipeId";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{recipedefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMbomListByRecipeIdSqlDatabase : _sqlSelectMbomListByRecipeIdOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RECIPEDEFINITIONID", recipedefinitionid));
		list.Add(dbContext.CreateParameter("SITEID", siteid));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}", "SELECT", "CIM_MBOM", $"{recipedefinitionid},{siteid}"));
		}
		IList<Mbom> result = ContextManager.DirectEntityQuery<Mbom>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{recipedefinitionid},{siteid}");
		}
		return result;
	}

	public static IList<Mbom> SelectMbomListByRecipeParameter(IDbContext dbContext, string recipedefinitionid, string siteid)
	{
		string apiName = "SelectMbomListByRecipeParameter";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{recipedefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMbomListByRecipeParameterSqlDatabase : _sqlSelectMbomListByRecipeParameterOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RECIPEDEFINITIONID", recipedefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}", "SELECT", "CIM_MBOM", $"{recipedefinitionid},{siteid}"));
		}
		IList<Mbom> result = ContextManager.DirectEntityQuery<Mbom>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{recipedefinitionid},{siteid}");
		}
		return result;
	}
}
