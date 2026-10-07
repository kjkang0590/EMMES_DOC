using System;
using System.Collections.Generic;
using System.Data;
using CIM.MES.API.PPS;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.CUSTOM;

[MESAPI]
public class CPRODUCTRULE
{
	private static string _sqlGetRelationTableListSqlDatabase = "\n            SELECT * \n              FROM {0} \n             WHERE SITEID=@SITEID\n               AND ISUSABLE='Usable'\n               AND PRODUCTRULESYSID = @PRODUCTRULESYSID";

	private static string _sqlGetRelationTableListOracleDatabase = "\n            SELECT * \n              FROM {0}\n             WHERE SITEID=:SITEID\n               AND ISUSABLE='Usable'\n               AND PRODUCTRULESYSID = :PRODUCTRULESYSID ";

	private static string _sqlGetRelationTableList4UpdateSqlDatabase = "\n            SELECT * \n              FROM {0} WITH(UPDLOCK)\n             WHERE SITEID=@SITEID\n               AND ISUSABLE='Usable'\n               AND PRODUCTRULESYSID = @PRODUCTRULESYSID";

	private static string _sqlGetRealtionTableList4UpdateOracleDatabase = "\n            SELECT * \n              FROM {0}\n             WHERE SITEID=:SITEID\n               AND ISUSABLE='Usable'\n               AND PRODUCTRULESYSID = :PRODUCTRULESYSID FOR UPDATE";

	private static string _sqlGetProductRuleOracleDatabase = "\n                    SELECT * \n                      FROM CIM_PRODUCTRULE \n                     WHERE SITEID=:SITEID \n                       AND ISUSABLE='Usable'\n                       AND PRODUCTRULETYPE=:PRODUCTRULETYPE\n                       AND (NVL(:PRODUCTCLASSID,'A')='A'         OR PRODUCTCLASSID=:PRODUCTCLASSID)\n                       AND (NVL(:PRODUCTDEFINITIONID,'A')='A'    OR PRODUCTDEFINITIONID=:PRODUCTDEFINITIONID)\n                       AND (NVL(:PROCESSDEFINITIONID,'A')='A'    OR PROCESSDEFINITIONID=:PROCESSDEFINITIONID)\n                       AND (NVL(:SUBPROCESSDEFINITIONID,'A')='A' OR SUBPROCESSDEFINITIONID=:SUBPROCESSDEFINITIONID)\n                       AND (NVL(:PROCESSNODEID,'A')='A'       OR PROCESSNODEID=:PROCESSNODEID)\n                       AND (NVL(:EQUIPMENTID,'A')='A'            OR EQUIPMENTID=:EQUIPMENTID)\n                       AND (NVL(:PROCESSSEGMENTRULEID,'A')='A'   OR PROCESSSEGMENTRULEID=:PROCESSSEGMENTRULEID)\n                       AND (NVL(:PRODUCTRULETYPE,'A')='A'        OR PRODUCTRULETYPE=:PRODUCTRULETYPE)\n                       AND ROWNUM=1";

	private static string _sqlGetProductRule4UpdateOracleDatabase = "\n                    SELECT * \n                      FROM CIM_PRODUCTRULE \n                     WHERE SITEID=:SITEID \n                       AND ISUSABLE='Usable'\n                       AND PRODUCTRULETYPE=:PRODUCTRULETYPE\n                       AND (NVL(:PRODUCTCLASSID,'A')='A'         OR PRODUCTCLASSID=:PRODUCTCLASSID)\n                       AND (NVL(:PRODUCTDEFINITIONID,'A')='A'    OR PRODUCTDEFINITIONID=:PRODUCTDEFINITIONID)\n                       AND (NVL(:PROCESSDEFINITIONID,'A')='A'    OR PROCESSDEFINITIONID=:PROCESSDEFINITIONID)\n                       AND (NVL(:SUBPROCESSDEFINITIONID,'A')='A' OR SUBPROCESSDEFINITIONID=:SUBPROCESSDEFINITIONID)\n                       AND (NVL(:PROCESSNODEID,'A')='A'       OR PROCESSNODEID=:PROCESSNODEID)\n                       AND (NVL(:EQUIPMENTID,'A')='A'            OR EQUIPMENTID=:EQUIPMENTID)\n                       AND (NVL(:PROCESSSEGMENTRULEID,'A')='A'   OR PROCESSSEGMENTRULEID=:PROCESSSEGMENTRULEID)\n                       AND (NVL(:PRODUCTRULETYPE,'A')='A'        OR PRODUCTRULETYPE=:PRODUCTRULETYPE)\n                       AND ROWNUM=1 FOR UPDATE";

	private static string _sqlGetProductRuleSqlDatabase = "\n                    SELECT TOP 1 * \n                      FROM CIM_PRODUCTRULE \n                     WHERE SITEID=@SITEID \n                       AND ISUSABLE='Usable'\n                       AND PRODUCTRULETYPE=@PRODUCTRULETYPE\n                       AND (ISNULL(@PRODUCTCLASSID,'A')='A'         OR PRODUCTCLASSID=@PRODUCTCLASSID)\n                       AND (ISNULL(@PRODUCTDEFINITIONID,'A')='A'    OR PRODUCTDEFINITIONID=@PRODUCTDEFINITIONID)\n                       AND (ISNULL(@PROCESSDEFINITIONID,'A')='A'    OR PROCESSDEFINITIONID=@PROCESSDEFINITIONID)\n                       AND (ISNULL(@SUBPROCESSDEFINITIONID,'A')='A' OR SUBPROCESSDEFINITIONID=@SUBPROCESSDEFINITIONID)\n                       AND (ISNULL(@PROCESSNODEID,'A')='A'       OR PROCESSNODEID=@PROCESSNODEID)\n                       AND (ISNULL(@EQUIPMENTID,'A')='A'            OR EQUIPMENTID=@EQUIPMENTID)\n                       AND (ISNULL(@PROCESSSEGMENTRULEID,'A')='A'   OR PROCESSSEGMENTRULEID=@PROCESSSEGMENTRULEID)\n                       AND (ISNULL(@PRODUCTRULETYPE,'A')='A'        OR PRODUCTRULETYPE=@PRODUCTRULETYPE)";

	private static string _sqlGetProductRule4UpdateSqlDatabase = "\n                    SELECT TOP 1 * \n                      FROM CIM_PRODUCTRULE WITH(UPDLOCK)\n                     WHERE SITEID=@SITEID \n                       AND ISUSABLE='Usable'\n                       AND PRODUCTRULETYPE=@PRODUCTRULETYPE\n                       AND (ISNULL(@PRODUCTCLASSID,'A')='A'         OR PRODUCTCLASSID=@PRODUCTCLASSID)\n                       AND (ISNULL(@PRODUCTDEFINITIONID,'A')='A'    OR PRODUCTDEFINITIONID=@PRODUCTDEFINITIONID)\n                       AND (ISNULL(@PROCESSDEFINITIONID,'A')='A'    OR PROCESSDEFINITIONID=@PROCESSDEFINITIONID)\n                       AND (ISNULL(@SUBPROCESSDEFINITIONID,'A')='A' OR SUBPROCESSDEFINITIONID=@SUBPROCESSDEFINITIONID)\n                       AND (ISNULL(@PROCESSNODEID,'A')='A'       OR PROCESSNODEID=@PROCESSNODEID)\n                       AND (ISNULL(@EQUIPMENTID,'A')='A'            OR EQUIPMENTID=@EQUIPMENTID)\n                       AND (ISNULL(@PROCESSSEGMENTRULEID,'A')='A'   OR PROCESSSEGMENTRULEID=@PROCESSSEGMENTRULEID)\n                       AND (ISNULL(@PRODUCTRULETYPE,'A')='A'        OR PRODUCTRULETYPE=@PRODUCTRULETYPE)";

	private static Type typeOfThis = typeof(Productrule);

	public static DataTable GetProductRuleDataList4UPDATE(IDbContext dbContext, string productRuleType, string productDefinitionId, string productClassId, string processDefinitionId, string subProcessDefinitionId, string processNodeId, string equipmentId, string processSegmentRuleId, string siteId)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("productRuleType", productRuleType);
		ParamChecker.ArgumentNotNull("siteId", siteId);
		string apiName = "GetProductRuleDataTableList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productRuleType},{siteId}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProductRule4UpdateSqlDatabase : _sqlGetProductRule4UpdateOracleDatabase);
		Productrulekey productrulekey = null;
		DataTable dataTable = new DataTable();
		if ((productrulekey = PRODUCTRULEKEY.GetProductRuleKey(dbContext, productRuleType, siteId)) == null)
		{
			throw new EntityNotFoundException(typeof(Productrulekey), productRuleType);
		}
		string text = ((productrulekey.Isproductclassid == null) ? "" : productrulekey.Isproductclassid);
		string text2 = ((productrulekey.Isproductdefinitionid == null) ? "" : productrulekey.Isproductdefinitionid);
		string text3 = ((productrulekey.Isprocessdefinitionid == null) ? "" : productrulekey.Isprocessdefinitionid);
		string text4 = ((productrulekey.Issubprocessdefinitionid == null) ? "" : productrulekey.Issubprocessdefinitionid);
		string text5 = ((productrulekey.Isprocessnodeid == null) ? "" : productrulekey.Isprocessnodeid);
		string text6 = ((productrulekey.Isequipmentid == null) ? "" : productrulekey.Isequipmentid);
		string text7 = ((productrulekey.Isprocesssegmentruleid == null) ? "" : productrulekey.Isprocesssegmentruleid);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		list.Add(dbContext.CreateParameter("PRODUCTRULETYPE", productRuleType, typeOfThis));
		if (!string.IsNullOrEmpty(productClassId) && text.Equals("Y"))
		{
			list.Add(dbContext.CreateParameter("PRODUCTCLASSID", productClassId, typeOfThis));
		}
		else
		{
			if (string.IsNullOrEmpty(productClassId) && text.Equals("Y"))
			{
				throw new ArgumentException("productClassId is null or empty");
			}
			list.Add(dbContext.CreateParameter("PRODUCTCLASSID", null, typeOfThis));
		}
		if (!string.IsNullOrEmpty(productDefinitionId) && text2.Equals("Y"))
		{
			list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", productDefinitionId, typeOfThis));
		}
		else
		{
			if (string.IsNullOrEmpty(productDefinitionId) && text2.Equals("Y"))
			{
				throw new ArgumentException("productDefinitionId is null or empty");
			}
			list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", null, typeOfThis));
		}
		if (!string.IsNullOrEmpty(processDefinitionId) && text3.Equals("Y"))
		{
			list.Add(dbContext.CreateParameter("PROCESSDEFINITIONID", processDefinitionId, typeOfThis));
		}
		else
		{
			if (string.IsNullOrEmpty(processDefinitionId) && text3.Equals("Y"))
			{
				throw new ArgumentException("processDefinitionId is null or empty");
			}
			list.Add(dbContext.CreateParameter("PROCESSDEFINITIONID", null, typeOfThis));
		}
		if (!string.IsNullOrEmpty(subProcessDefinitionId) && text4.Equals("Y"))
		{
			list.Add(dbContext.CreateParameter("SUBPROCESSDEFINITIONID", subProcessDefinitionId, typeOfThis));
		}
		else
		{
			if (string.IsNullOrEmpty(subProcessDefinitionId) && text4.Equals("Y"))
			{
				throw new ArgumentException("subProcessDefinitionId is null or empty");
			}
			list.Add(dbContext.CreateParameter("SUBPROCESSDEFINITIONID", null, typeOfThis));
		}
		if (!string.IsNullOrEmpty(processNodeId) && text5.Equals("Y"))
		{
			list.Add(dbContext.CreateParameter("PROCESSNODEID", processNodeId, typeOfThis));
		}
		else
		{
			if (string.IsNullOrEmpty(processNodeId) && text5.Equals("Y"))
			{
				throw new ArgumentException("processNodeId is null or empty");
			}
			list.Add(dbContext.CreateParameter("PROCESSNODEID", null, typeOfThis));
		}
		if (!string.IsNullOrEmpty(equipmentId) && text6.Equals("Y"))
		{
			list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentId, typeOfThis));
		}
		else
		{
			if (string.IsNullOrEmpty(equipmentId) && text6.Equals("Y"))
			{
				throw new ArgumentException("equipmentId is null or empty");
			}
			list.Add(dbContext.CreateParameter("EQUIPMENTID", null, typeOfThis));
		}
		if (!string.IsNullOrEmpty(processSegmentRuleId) && text7.Equals("Y"))
		{
			list.Add(dbContext.CreateParameter("PROCESSSEGMENTRULEID", processSegmentRuleId, typeOfThis));
		}
		else
		{
			if (string.IsNullOrEmpty(processSegmentRuleId) && text7.Equals("Y"))
			{
				throw new ArgumentException("processSegmentRuleId is null or empty");
			}
			list.Add(dbContext.CreateParameter("PROCESSSEGMENTRULEID", null, typeOfThis));
		}
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "GET", "CIM_PRODUCTRULE", $"{productRuleType},{siteId}"));
		}
		IList<Productrule> list2 = ContextManager.DirectEntityQuery<Productrule>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		string format = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetRelationTableList4UpdateSqlDatabase : _sqlGetRealtionTableList4UpdateOracleDatabase);
		if (list2.Count > 0)
		{
			if (productrulekey.Relationtype.Equals("RELATIONTABLE"))
			{
				List<MesParameter> list3 = new List<MesParameter>();
				list3.Add(dbContext.CreateParameter("PRODUCTRULESYSID", list2[0].Productrulesysid, typeOfThis));
				list3.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
				dataTable = dbContext.ExecuteDataTable(string.Format(format, productrulekey.Relationtable), CommandType.Text, list3.ToArray());
			}
			else if (productrulekey.Relationtype.Equals("PARAMETER"))
			{
				dataTable.Columns.Add("PARAMETERTYPE");
				dataTable.Columns.Add("PARAMETERVALUE");
				DataRow row = dataTable.NewRow();
				dataTable.Rows.InsertAt(row, 0);
				dataTable.Rows[0]["PARAMETERTYPE"] = list2[0].Parametertype;
				dataTable.Rows[0]["PARAMETERVALUE"] = list2[0].Parametervalue;
			}
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productRuleType},{siteId}");
		}
		return dataTable;
	}

	public static DataTable GetProductRuleDataList(IDbContext dbContext, string productRuleType, string productDefinitionId, string productClassId, string processDefinitionId, string subProcessDefinitionId, string processNodeId, string equipmentId, string processSegmentRuleId, string siteId)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("productRuleType", productRuleType);
		ParamChecker.ArgumentNotNull("siteId", siteId);
		string apiName = "GetProductRuleDataTableList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productRuleType},{siteId}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProductRuleSqlDatabase : _sqlGetProductRuleOracleDatabase);
		Productrulekey productrulekey = null;
		DataTable dataTable = new DataTable();
		if ((productrulekey = PRODUCTRULEKEY.GetProductRuleKey(dbContext, productRuleType, siteId)) == null)
		{
			throw new EntityNotFoundException(typeof(Productrulekey), productRuleType);
		}
		string text = ((productrulekey.Isproductclassid == null) ? "" : productrulekey.Isproductclassid);
		string text2 = ((productrulekey.Isproductdefinitionid == null) ? "" : productrulekey.Isproductdefinitionid);
		string text3 = ((productrulekey.Isprocessdefinitionid == null) ? "" : productrulekey.Isprocessdefinitionid);
		string text4 = ((productrulekey.Issubprocessdefinitionid == null) ? "" : productrulekey.Issubprocessdefinitionid);
		string text5 = ((productrulekey.Isprocessnodeid == null) ? "" : productrulekey.Isprocessnodeid);
		string text6 = ((productrulekey.Isequipmentid == null) ? "" : productrulekey.Isequipmentid);
		string text7 = ((productrulekey.Isprocesssegmentruleid == null) ? "" : productrulekey.Isprocesssegmentruleid);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		list.Add(dbContext.CreateParameter("PRODUCTRULETYPE", productRuleType, typeOfThis));
		if (!string.IsNullOrEmpty(productClassId) && text.Equals("Y"))
		{
			list.Add(dbContext.CreateParameter("PRODUCTCLASSID", productClassId, typeOfThis));
		}
		else
		{
			if (string.IsNullOrEmpty(productClassId) && text.Equals("Y"))
			{
				throw new ArgumentException("productClassId is null or empty");
			}
			list.Add(dbContext.CreateParameter("PRODUCTCLASSID", null, typeOfThis));
		}
		if (!string.IsNullOrEmpty(productDefinitionId) && text2.Equals("Y"))
		{
			list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", productDefinitionId, typeOfThis));
		}
		else
		{
			if (string.IsNullOrEmpty(productDefinitionId) && text2.Equals("Y"))
			{
				throw new ArgumentException("productDefinitionId is null or empty");
			}
			list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", null, typeOfThis));
		}
		if (!string.IsNullOrEmpty(processDefinitionId) && text3.Equals("Y"))
		{
			list.Add(dbContext.CreateParameter("PROCESSDEFINITIONID", processDefinitionId, typeOfThis));
		}
		else
		{
			if (string.IsNullOrEmpty(processDefinitionId) && text3.Equals("Y"))
			{
				throw new ArgumentException("processDefinitionId is null or empty");
			}
			list.Add(dbContext.CreateParameter("PROCESSDEFINITIONID", null, typeOfThis));
		}
		if (!string.IsNullOrEmpty(subProcessDefinitionId) && text4.Equals("Y"))
		{
			list.Add(dbContext.CreateParameter("SUBPROCESSDEFINITIONID", subProcessDefinitionId, typeOfThis));
		}
		else
		{
			if (string.IsNullOrEmpty(subProcessDefinitionId) && text4.Equals("Y"))
			{
				throw new ArgumentException("subProcessDefinitionId is null or empty");
			}
			list.Add(dbContext.CreateParameter("SUBPROCESSDEFINITIONID", null, typeOfThis));
		}
		if (!string.IsNullOrEmpty(processNodeId) && text5.Equals("Y"))
		{
			list.Add(dbContext.CreateParameter("PROCESSNODEID", processNodeId, typeOfThis));
		}
		else
		{
			if (string.IsNullOrEmpty(processNodeId) && text5.Equals("Y"))
			{
				throw new ArgumentException("processNodeId is null or empty");
			}
			list.Add(dbContext.CreateParameter("PROCESSNODEID", null, typeOfThis));
		}
		if (!string.IsNullOrEmpty(equipmentId) && text6.Equals("Y"))
		{
			list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentId, typeOfThis));
		}
		else
		{
			if (string.IsNullOrEmpty(equipmentId) && text6.Equals("Y"))
			{
				throw new ArgumentException("equipmentId is null or empty");
			}
			list.Add(dbContext.CreateParameter("EQUIPMENTID", null, typeOfThis));
		}
		if (!string.IsNullOrEmpty(processSegmentRuleId) && text7.Equals("Y"))
		{
			list.Add(dbContext.CreateParameter("PROCESSSEGMENTRULEID", processSegmentRuleId, typeOfThis));
		}
		else
		{
			if (string.IsNullOrEmpty(processSegmentRuleId) && text7.Equals("Y"))
			{
				throw new ArgumentException("processSegmentRuleId is null or empty");
			}
			list.Add(dbContext.CreateParameter("PROCESSSEGMENTRULEID", null, typeOfThis));
		}
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "GET", "CIM_PRODUCTRULE", $"{productRuleType},{siteId}"));
		}
		IList<Productrule> list2 = ContextManager.DirectEntityQuery<Productrule>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		string format = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetRelationTableListSqlDatabase : _sqlGetRelationTableListOracleDatabase);
		if (list2.Count > 0)
		{
			if (productrulekey.Relationtype.Equals("RELATIONTABLE"))
			{
				List<MesParameter> list3 = new List<MesParameter>();
				list3.Add(dbContext.CreateParameter("PRODUCTRULESYSID", list2[0].Productrulesysid, typeOfThis));
				list3.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
				dataTable = dbContext.ExecuteDataTable(string.Format(format, productrulekey.Relationtable), CommandType.Text, list3.ToArray());
			}
			else if (productrulekey.Relationtype.Equals("PARAMETER"))
			{
				dataTable.Columns.Add("PARAMETERTYPE");
				dataTable.Columns.Add("PARAMETERVALUE");
				DataRow row = dataTable.NewRow();
				dataTable.Rows.InsertAt(row, 0);
				dataTable.Rows[0]["PARAMETERTYPE"] = list2[0].Parametertype;
				dataTable.Rows[0]["PARAMETERVALUE"] = list2[0].Parametervalue;
			}
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productRuleType},{siteId}");
		}
		return dataTable;
	}
}
