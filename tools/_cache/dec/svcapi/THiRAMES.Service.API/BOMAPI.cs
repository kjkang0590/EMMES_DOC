using System;
using System.Collections.Generic;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace THiRAMES.Service.API;

public class BOMAPI
{
	private static string _sqlSelectBomIdListbyProductDefinitionIdSqlDatabase = "SELECT * FROM CIM_BOM WHERE PRODUCTDEFINITIONID=@PRODUCTDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectBomIdListbyProductDefinitionIdOracleDatabase = "SELECT * FROM CIM_BOM WHERE PRODUCTDEFINITIONID=:PRODUCTDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static Type typeOfThis = typeof(Bom);

	public static IList<Bom> SelectBomIdListbyProductDefinitionId(IDbContext dbContext, string productdefinitionid, string siteid)
	{
		string apiName = "SelectBomIdListbyProductDefinitionId";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectBomIdListbyProductDefinitionIdSqlDatabase : _sqlSelectBomIdListbyProductDefinitionIdOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", productdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}", "SELECT", "CIM_BOM", $"{productdefinitionid},{siteid}"));
		}
		IList<Bom> result = ContextManager.DirectEntityQuery<Bom>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productdefinitionid},{siteid}");
		}
		return result;
	}
}
