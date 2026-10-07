using System;
using System.Collections.Generic;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace THiRAMES.Service.API;

public class CARRIERBOMAPI
{
	private static string _sqlSelectCarrierBomIdListbyProductDefinitionIdSqlDatabase = "SELECT * FROM CIM_CARRIERBOM WHERE PRODUCTDEFINITIONID=@PRODUCTDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectCarrierBomIdListbyProductDefinitionIdOracleDatabase = "SELECT * FROM CIM_CARRIERBOM WHERE PRODUCTDEFINITIONID=:PRODUCTDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static Type typeOfThis = typeof(Carrierbom);

	public static IList<Carrierbom> SelectCarrierBomIdListbyProductDefinitionId(IDbContext dbContext, string productdefinitionid, string siteid)
	{
		string apiName = "SelectCarrierBomIdListbyProductDefinitionId";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectCarrierBomIdListbyProductDefinitionIdSqlDatabase : _sqlSelectCarrierBomIdListbyProductDefinitionIdOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", productdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}", "SELECT", "CIM_CARRIERBOM", $"{productdefinitionid},{siteid}"));
		}
		IList<Carrierbom> result = ContextManager.DirectEntityQuery<Carrierbom>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productdefinitionid},{siteid}");
		}
		return result;
	}
}
