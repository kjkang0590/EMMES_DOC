using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.POS;

[MESAPI]
public class WORKORDER
{
	private static string _sqlGetWorkOrderSqlDatabase = "SELECT * FROM CIM_WORKORDER WHERE WORKORDERID=@WORKORDERID AND SITEID=@SITEID";

	private static string _sqlGetWorkOrder4UpdateSqlDatabase = "SELECT * FROM CIM_WORKORDER WITH(UPDLOCK) WHERE WORKORDERID=@WORKORDERID AND SITEID=@SITEID";

	private static string _sqlSelectWorkOrderSqlDatabase = "SELECT * FROM CIM_WORKORDER WHERE WORKORDERID=@WORKORDERID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectWorkOrder4UpdateSqlDatabase = "SELECT * FROM CIM_WORKORDER WITH(UPDLOCK) WHERE WORKORDERID=@WORKORDERID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetWorkOrderOracleDatabase = "SELECT * FROM CIM_WORKORDER WHERE WORKORDERID=:WORKORDERID AND SITEID=:SITEID";

	private static string _sqlGetWorkOrder4UpdateOracleDatabase = "SELECT * FROM CIM_WORKORDER WHERE WORKORDERID=:WORKORDERID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectWorkOrderOracleDatabase = "SELECT * FROM CIM_WORKORDER WHERE WORKORDERID=:WORKORDERID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectWorkOrder4UpdateOracleDatabase = "SELECT * FROM CIM_WORKORDER WHERE WORKORDERID=:WORKORDERID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Workorder);

	private static string _sqlGetWorkOrderListByProductOrderSqlDatabase = "SELECT * FROM CIM_WORKORDER WHERE PRODUCTORDERID=@PRODUCTORDERID AND SITEID=@SITEID";

	private static string _sqlGetWorkOrderListByProductOrderOracleDatabase = "SELECT * FROM CIM_WORKORDER WHERE PRODUCTORDERID=:PRODUCTORDERID AND SITEID=:SITEID";

	private static string _sqlSelectWorkOrderListByProductOrderSqlDatabase = "SELECT * FROM CIM_WORKORDER WHERE PRODUCTORDERID=@PRODUCTORDERID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectWorkOrderListByProductOrderOracleDatabase = "SELECT * FROM CIM_WORKORDER WHERE PRODUCTORDERID=:PRODUCTORDERID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	public static int ChangeWorkOrderState(IDbContext dbContext, Workorder[] workOrderList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("entities", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("workOrderList", workOrderList);
		string text = "ChangeWorkOrderState";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Workorder> list = new List<Workorder>();
		foreach (Workorder workorder in workOrderList)
		{
			ParamChecker.ArgumentNotNull("Workorderid", workorder.Workorderid);
			ParamChecker.ArgumentNotNull("State", workorder.State);
			ParamChecker.ArgumentNotNull("Siteid", workorder.Siteid);
			string workorderid = workorder.Workorderid;
			string state = workorder.State;
			string siteid = workorder.Siteid;
			Workorder workorder2;
			if ((workorder2 = SelectWorkOrder4Update(dbContext, workorderid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Workorder), string.Format(workorderid, siteid));
			}
			if (STATE.SelectState(dbContext, typeof(WorkOrderState).Name, state, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(WorkOrderState), state);
			}
			workorder2.Prevstate = workorder2.State;
			workorder2.State = state;
			workorder.CopyCommonFieldUpdatePrev(workorder2, systemTime, dbContext.Tid, text);
			workorder.CopyExtensionCollection(workorder2);
			list.Add(workorder2);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int CreateWorkOrder(IDbContext dbContext, Workorder[] workOrderList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("workOrderList", workOrderList);
		string text = "CreateWorkOrder";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Workorder> list = new List<Workorder>();
		foreach (Workorder obj in workOrderList)
		{
			Workorder workorder = new Workorder();
			obj.CopyColumsTo(workorder);
			workorder.State = "Created";
			workorder.Activity = text;
			workorder.Isusable = "Usable";
			obj.CopyCommonField(workorder, systemTime, dbContext.Tid, isCreate: true);
			list.Add(workorder);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static Workorder GetWorkOrder(IDbContext dbContext, string workorderid, string siteid)
	{
		string apiName = "GetWorkOrder";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{workorderid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetWorkOrderSqlDatabase : _sqlGetWorkOrderOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("WORKORDERID", workorderid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_WORKORDER", $"{workorderid},{siteid}"));
		}
		Workorder? result = ContextManager.DirectEntityQuery<Workorder>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{workorderid},{siteid}");
		}
		return result;
	}

	public static Workorder GetWorkOrder4Update(IDbContext dbContext, string workorderid, string siteid)
	{
		string apiName = "GetWorkOrder4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{workorderid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetWorkOrder4UpdateSqlDatabase : _sqlGetWorkOrder4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("WORKORDERID", workorderid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_WORKORDER", $"{workorderid},{siteid}"));
		}
		Workorder? result = ContextManager.DirectEntityQuery<Workorder>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{workorderid},{siteid}");
		}
		return result;
	}

	public static Workorder SelectWorkOrder(IDbContext dbContext, string workorderid, string siteid)
	{
		string apiName = "SelectWorkOrder";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{workorderid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectWorkOrderSqlDatabase : _sqlSelectWorkOrderOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("WORKORDERID", workorderid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_WORKORDER", $"{workorderid},{siteid}"));
		}
		Workorder? result = ContextManager.DirectEntityQuery<Workorder>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{workorderid},{siteid}");
		}
		return result;
	}

	public static Workorder SelectWorkOrder4Update(IDbContext dbContext, string workorderid, string siteid)
	{
		string apiName = "SelectWorkOrder4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{workorderid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectWorkOrder4UpdateSqlDatabase : _sqlSelectWorkOrder4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("WORKORDERID", workorderid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_WORKORDER", $"{workorderid},{siteid}"));
		}
		Workorder? result = ContextManager.DirectEntityQuery<Workorder>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{workorderid},{siteid}");
		}
		return result;
	}

	public static IList<Workorder> GetWorkOrderListByProductOrder(IDbContext dbContext, string productorderid, string siteid)
	{
		string apiName = "GetWorkOrderListByProductOrder";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productorderid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetWorkOrderListByProductOrderSqlDatabase : _sqlGetWorkOrderListByProductOrderOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTORDERID", productorderid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_WORKORDER", $"{productorderid},{siteid}"));
		}
		IList<Workorder> result = ContextManager.DirectEntityQuery<Workorder>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productorderid},{siteid}");
		}
		return result;
	}

	public static IList<Workorder> SelectWorkOrderListByProductOrder(IDbContext dbContext, string productorderid, string siteid)
	{
		string apiName = "SelectWorkOrderListByProductOrder";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productorderid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectWorkOrderListByProductOrderSqlDatabase : _sqlSelectWorkOrderListByProductOrderOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTORDERID", productorderid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_WORKORDER", $"{productorderid},{siteid}"));
		}
		IList<Workorder> result = ContextManager.DirectEntityQuery<Workorder>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productorderid},{siteid}");
		}
		return result;
	}

	public static int UpsertWorkOrder(IDbContext dbContext, RequestType requestType, Workorder[] workOrderList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateWorkOrderInternal(dbContext, workOrderList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateWorkOrder(dbContext, workOrderList, optionSet, saveHist), 
			RequestType.DELETE => DeleteWorkOrder(dbContext, workOrderList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteWorkOrder(dbContext, workOrderList, optionSet, saveHist), 
			_ => RealDeleteWorkOrder(dbContext, workOrderList, optionSet, saveHist), 
		};
	}

	private static int CreateWorkOrderInternal(IDbContext dbContext, Workorder[] workOrderList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("workOrderList", workOrderList);
		string text = "CreateWorkOrder";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Workorder> list = new List<Workorder>();
		foreach (Workorder obj in workOrderList)
		{
			Workorder workorder = new Workorder();
			obj.CopyColumsTo(workorder);
			workorder.Activity = text;
			workorder.CheckEntityUsable();
			obj.CopyCommonField(workorder, systemTime, dbContext.Tid, isCreate: true);
			list.Add(workorder);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateWorkOrder(IDbContext dbContext, Workorder[] workOrderList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("workOrderList", workOrderList);
		string text = "UpdateWorkOrder";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Workorder> list = new List<Workorder>();
		foreach (Workorder workorder in workOrderList)
		{
			Workorder workOrder4Update = GetWorkOrder4Update(dbContext, workorder.Workorderid, workorder.Siteid);
			if (workOrder4Update == null)
			{
				throw new EntityNotFoundException(typeof(Workorder), $"{workorder.Workorderid},{workorder.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Workorder), $"{workorder.Workorderid},{workorder.Siteid}", workOrder4Update.Isusable);
			string activity = workOrder4Update.Activity;
			string customactivity = workOrder4Update.Customactivity;
			string isusable = workOrder4Update.Isusable;
			DateTime? createtime = workOrder4Update.Createtime;
			string creator = workOrder4Update.Creator;
			workorder.CopyColumsTo(workOrder4Update);
			workOrder4Update.Prevactivity = activity;
			workOrder4Update.Prevcustomactivity = customactivity;
			workOrder4Update.Creator = creator;
			workOrder4Update.Createtime = createtime;
			workOrder4Update.Isusable = isusable;
			workOrder4Update.Activity = text;
			workorder.CopyCommonField(workOrder4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(workOrder4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteWorkOrder(IDbContext dbContext, Workorder[] workOrderList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("workOrderList", workOrderList);
		string text = "DeleteWorkOrder";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Workorder> list = new List<Workorder>();
		foreach (Workorder workorder in workOrderList)
		{
			Workorder workOrder4Update = GetWorkOrder4Update(dbContext, workorder.Workorderid, workorder.Siteid);
			if (workOrder4Update == null)
			{
				throw new EntityNotFoundException(typeof(Workorder), $"{workorder.Workorderid},{workorder.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Workorder), $"{workorder.Workorderid},{workorder.Siteid}", workOrder4Update.Isusable);
			workOrder4Update.Isusable = "UnUsable";
			workorder.CopyCommonFieldUpdatePrev(workOrder4Update, systemTime, dbContext.Tid, text);
			workorder.CopyExtensionCollection(workOrder4Update);
			list.Add(workOrder4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteWorkOrder(IDbContext dbContext, Workorder[] workOrderList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("workOrderList", workOrderList);
		string text = "UnDeleteWorkOrder";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Workorder> list = new List<Workorder>();
		foreach (Workorder workorder in workOrderList)
		{
			Workorder workOrder4Update = GetWorkOrder4Update(dbContext, workorder.Workorderid, workorder.Siteid);
			if (workOrder4Update == null)
			{
				throw new EntityNotFoundException(typeof(Workorder), $"{workorder.Workorderid},{workorder.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Workorder), $"{workorder.Workorderid},{workorder.Siteid}", workOrder4Update.Isusable);
			workOrder4Update.Isusable = "Usable";
			workorder.CopyCommonFieldUpdatePrev(workOrder4Update, systemTime, dbContext.Tid, text);
			workorder.CopyExtensionCollection(workOrder4Update);
			list.Add(workOrder4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteWorkOrder(IDbContext dbContext, Workorder[] workOrderList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("workOrderList", workOrderList);
		string text = "RealDeleteWorkOrder";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Workorder> list = new List<Workorder>();
		foreach (Workorder workorder in workOrderList)
		{
			Workorder workOrder4Update = GetWorkOrder4Update(dbContext, workorder.Workorderid, workorder.Siteid);
			if (workOrder4Update == null)
			{
				throw new EntityNotFoundException(typeof(Workorder), $"{workorder.Workorderid},{workorder.Siteid}");
			}
			workorder.CopyCommonFieldUpdatePrev(workOrder4Update, systemTime, dbContext.Tid, text);
			workorder.CopyExtensionCollection(workOrder4Update);
			list.Add(workOrder4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
