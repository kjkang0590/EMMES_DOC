using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.API.PPS;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;
using CIM.Util.SPC;

namespace CIM.MES.API.POS;

public class SPCITEM
{
	private static string _sqlGetSpcItemSqlDatabaseByProductRuleKey = "SELECT * FROM CIM_SPCITEM WHERE SITEID=@SITEID";

	private static string _sqlSelectSpcItemSqlDatabaseByProductRuleKey = "SELECT * FROM CIM_SPCITEM WHERE SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetSpcItemOracleDatabaseByProductRuleKey = "SELECT * FROM CIM_SPCITEM WHERE SITEID=:SITEID";

	private static string _sqlSelectSpcItemOracleDatabaseByProductRuleKey = "SELECT * FROM CIM_SPCITEM WHERE SITEID=:SITEID AND ISUSABLE='Usable'";

	private static Type typeOfThis = typeof(Spcitem);

	public static Spcitem GetSpcItemListByProductRuleKey(IDbContext dbContext, string spcItemId, string productDefinitionId, string processDefinitionId, string subProcessDefinitionId, string processSegmentId, string equipmentId, string siteid)
	{
		string apiName = "GetSpcItemListByProductRuleKey";
		string arg = string.Join(",", processDefinitionId, processDefinitionId, subProcessDefinitionId, processSegmentId, equipmentId, siteid);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{arg},");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetSpcItemSqlDatabaseByProductRuleKey : _sqlGetSpcItemOracleDatabaseByProductRuleKey);
		List<MesParameter> list = ChangeSqlParameterByProductRulekey(dbContext, spcItemId, productDefinitionId, processDefinitionId, subProcessDefinitionId, processSegmentId, equipmentId, siteid);
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		foreach (MesParameter item in list)
		{
			dictionary.Add(item.ParameterName, Convert.ToString(item.Value));
		}
		sql = SpcUtil.AddSqlCondition(dbContext.DbType.ToString(), sql, dictionary);
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SPCITEM", $"{arg},"));
		}
		IList<Spcitem> list2 = ContextManager.DirectEntityQuery<Spcitem>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (list2.Count >= 2)
		{
			throw new DuplicatedSpcItemException(spcItemId);
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{arg},");
		}
		return list2.FirstOrDefault();
	}

	public static Spcitem SelectSpcItemListByProductRuleKey(IDbContext dbContext, string spcItemId, string productDefinitionId, string processDefinitionId, string subProcessDefinitionId, string processSegmentId, string equipmentId, string siteid)
	{
		string apiName = "SelectSpcItemListByProductRuleKey";
		string arg = string.Join(",", processDefinitionId, processDefinitionId, subProcessDefinitionId, processSegmentId, equipmentId, siteid);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{arg},");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectSpcItemSqlDatabaseByProductRuleKey : _sqlSelectSpcItemOracleDatabaseByProductRuleKey);
		List<MesParameter> list = ChangeSqlParameterByProductRulekey(dbContext, spcItemId, productDefinitionId, processDefinitionId, subProcessDefinitionId, processSegmentId, equipmentId, siteid);
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		foreach (MesParameter item in list)
		{
			dictionary.Add(item.ParameterName, Convert.ToString(item.Value));
		}
		sql = SpcUtil.AddSqlCondition(dbContext.DbType.ToString(), sql, dictionary);
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SPCITEM", $"{arg},"));
		}
		IList<Spcitem> list2 = ContextManager.DirectEntityQuery<Spcitem>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (list2.Count >= 2)
		{
			throw new DuplicatedSpcItemException(spcItemId);
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{arg},");
		}
		return list2.FirstOrDefault();
	}

	private static List<MesParameter> ChangeSqlParameterByProductRulekey(IDbContext dbContext, string spcItemId, string productDefinitionId, string processDefinitionId, string subProcessDefinitionId, string processSegmentId, string equipmentId, string siteId)
	{
		Productrulekey productrulekey = PRODUCTRULEKEY.SelectProductRuleKey(dbContext, "SPC", siteId);
		if (productrulekey == null)
		{
			new EntityNotFoundException(typeof(Productrulekey), "SPC");
		}
		List<MesParameter> list = new List<MesParameter>();
		if ("Y".Equals(productrulekey.Isproductdefinitionid))
		{
			list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", productDefinitionId, typeOfThis));
		}
		if ("Y".Equals(productrulekey.Isprocessdefinitionid))
		{
			list.Add(dbContext.CreateParameter("PROCESSDEFINITIONID", processDefinitionId, typeOfThis));
		}
		if ("Y".Equals(productrulekey.Issubprocessdefinitionid))
		{
			list.Add(dbContext.CreateParameter("SUBPROCESSDEFINITIONID", subProcessDefinitionId, typeOfThis));
		}
		if ("Y".Equals(productrulekey.Isprocessnodeid))
		{
			list.Add(dbContext.CreateParameter("MEASURESEGMENTID", processSegmentId, typeOfThis));
		}
		if ("Y".Equals(productrulekey.Isequipmentid))
		{
			list.Add(dbContext.CreateParameter("MEASUREEQUIPMENTID", equipmentId, typeOfThis));
		}
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		list.Add(dbContext.CreateParameter("SPCITEMID", spcItemId, typeOfThis));
		return list;
	}
}
