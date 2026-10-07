using System;
using System.Collections.Generic;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace THiRAMES.Service.API;

public class DURABLEBOMAPI
{
	private static string _sqlSelectDurableBomIdListbyProductDefinitionIdSqlDatabase = "SELECT * FROM CIM_DURABLEBOM WHERE PRODUCTDEFINITIONID=@PRODUCTDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectDurableBomIdListbyProductDefinitionIdOracleDatabase = "SELECT * FROM CIM_DURABLEBOM WHERE PRODUCTDEFINITIONID=:PRODUCTDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static Type typeOfThis = typeof(Durablebom);

	public static IList<Durablebom> SelectDurableBomIdListbyProductDefinitionId(IDbContext dbContext, string productdefinitionid, string siteid)
	{
		string apiName = "SelectDurableBomIdListbyProductDefinitionId";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectDurableBomIdListbyProductDefinitionIdSqlDatabase : _sqlSelectDurableBomIdListbyProductDefinitionIdOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", productdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}", "SELECT", "CIM_DURABLEBOM", $"{productdefinitionid},{siteid}"));
		}
		IList<Durablebom> result = ContextManager.DirectEntityQuery<Durablebom>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productdefinitionid},{siteid}");
		}
		return result;
	}
}
