using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.POS;

[MESAPI]
public class DELIVERYORDER
{
	private static string _sqlGetDeliveryOrderSqlDatabase = "SELECT * FROM CIM_DELIVERYORDER WHERE DELIVERYORDERID=@DELIVERYORDERID AND DELIVERYITEMNO=@DELIVERYITEMNO AND SITEID=@SITEID";

	private static string _sqlGetDeliveryOrder4UpdateSqlDatabase = "SELECT * FROM CIM_DELIVERYORDER WITH(UPDLOCK) WHERE DELIVERYORDERID=@DELIVERYORDERID AND DELIVERYITEMNO=@DELIVERYITEMNO AND SITEID=@SITEID";

	private static string _sqlSelectDeliveryOrderSqlDatabase = "SELECT * FROM CIM_DELIVERYORDER WHERE DELIVERYORDERID=@DELIVERYORDERID AND DELIVERYITEMNO=@DELIVERYITEMNO AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectDeliveryOrder4UpdateSqlDatabase = "SELECT * FROM CIM_DELIVERYORDER WITH(UPDLOCK) WHERE DELIVERYORDERID=@DELIVERYORDERID AND DELIVERYITEMNO=@DELIVERYITEMNO AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetDeliveryOrderOracleDatabase = "SELECT * FROM CIM_DELIVERYORDER WHERE DELIVERYORDERID=:DELIVERYORDERID AND DELIVERYITEMNO=:DELIVERYITEMNO AND SITEID=:SITEID";

	private static string _sqlGetDeliveryOrder4UpdateOracleDatabase = "SELECT * FROM CIM_DELIVERYORDER WHERE DELIVERYORDERID=:DELIVERYORDERID AND DELIVERYITEMNO=:DELIVERYITEMNO AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectDeliveryOrderOracleDatabase = "SELECT * FROM CIM_DELIVERYORDER WHERE DELIVERYORDERID=:DELIVERYORDERID AND DELIVERYITEMNO=:DELIVERYITEMNO AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectDeliveryOrder4UpdateOracleDatabase = "SELECT * FROM CIM_DELIVERYORDER WHERE DELIVERYORDERID=:DELIVERYORDERID AND DELIVERYITEMNO=:DELIVERYITEMNO AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Deliveryorder);

	private static string _sqlSelectDeliveryOrderListSqlDatabase = "SELECT * FROM CIM_DELIVERYORDER WHERE DELIVERYORDERID IN (&DELIVERYORDERLIST) AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectDeliveryOrderList4UpdateSqlDatabase = "SELECT * FROM CIM_DELIVERYORDER WITH(UPDLOCK) WHERE DELIVERYORDERID IN (&DELIVERYORDERLIST) AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectDeliveryOrderListOracleDatabase = "SELECT * FROM CIM_DELIVERYORDER WHERE DELIVERYORDERID IN (&DELIVERYORDERLIST) AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectDeliveryOrderList4UpdateOracleDatabase = "SELECT * FROM CIM_DELIVERYORDER WHERE DELIVERYORDERID IN (&DELIVERYORDERLIST) AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	public static int ChangeDeliveryOrderState(IDbContext dbContext, Deliveryorder[] deliveryorderList, ChangeDeliveryOrderStateOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("deliveryorderList", deliveryorderList);
		string text = "ChangeDeliveryOrderState";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Deliveryorder> list = new List<Deliveryorder>();
		bool validationStateModel = optionSet.ValidationStateModel;
		string siteid = deliveryorderList[0].Siteid;
		Deliveryorder[] array = SelectDeliveryOrderList4Update(dbContext, deliveryorderList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "SelectDeliveryOrderList4Update", $"DeliveryOrder Count={array.Length}");
		}
		foreach (Deliveryorder deliveryorder in deliveryorderList)
		{
			ParamChecker.ArgumentNotNull("Deliveryorderid", deliveryorder.Deliveryorderid);
			ParamChecker.ArgumentNotNull("State", deliveryorder.State);
			ParamChecker.ArgumentNotNull("Siteid", deliveryorder.Siteid);
			string deliveryorderid = deliveryorder.Deliveryorderid;
			string state = deliveryorder.State;
			Deliveryorder deliveryorder2 = null;
			if ((deliveryorder2 = FindDeliveryorder(array, deliveryorderid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lot), deliveryorderid);
			}
			if (STATE.SelectState(dbContext, typeof(DeliveryOrderState).Name, state, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(DeliveryOrderState), state);
			}
			if (validationStateModel && STATETRANSITION.SelectStateTransition(dbContext, "DeliveryOrderState", deliveryorder2.State, state, siteid) == null)
			{
				throw new StateTransitionNotDefinedException("DeliveryOrderState", deliveryorder2.State, state);
			}
			deliveryorder2.Prevstate = deliveryorder2.State;
			deliveryorder2.State = state;
			deliveryorder.CopyCommonFieldUpdatePrev(deliveryorder2, systemTime, tid, text);
			deliveryorder.CopyExtensionCollection(deliveryorder2);
			list.Add(deliveryorder2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", $"Deliveryorderid={deliveryorder2.Deliveryorderid} Prevstate={deliveryorder2.Prevstate} State={deliveryorder2.State}");
			}
		}
		if (list.Count > 0)
		{
			num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		}
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int CreateDeliveryOrder(IDbContext dbContext, Deliveryorder[] deliveryOrderList, CreateDeliveryOrderStateOptionSet optionSet, bool saveHist)
	{
		return CreateDeliveryOrderInternal(dbContext, deliveryOrderList, optionSet, saveHist);
	}

	public static Deliveryorder GetDeliveryOrder(IDbContext dbContext, string deliveryorderid, string deliveryitemno, string siteid)
	{
		string apiName = "GetDeliveryOrder";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{deliveryorderid},{deliveryitemno},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetDeliveryOrderSqlDatabase : _sqlGetDeliveryOrderOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DELIVERYORDERID", deliveryorderid, typeOfThis));
		list.Add(dbContext.CreateParameter("DELIVERYITEMNO", deliveryitemno, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_DELIVERYORDER", $"{deliveryorderid},{deliveryitemno},{siteid}"));
		}
		Deliveryorder? result = ContextManager.DirectEntityQuery<Deliveryorder>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{deliveryorderid},{deliveryitemno},{siteid}");
		}
		return result;
	}

	public static Deliveryorder GetDeliveryOrder4Update(IDbContext dbContext, string deliveryorderid, string deliveryitemno, string siteid)
	{
		string apiName = "GetDeliveryOrder4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{deliveryorderid},{deliveryitemno},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetDeliveryOrder4UpdateSqlDatabase : _sqlGetDeliveryOrder4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DELIVERYORDERID", deliveryorderid, typeOfThis));
		list.Add(dbContext.CreateParameter("DELIVERYITEMNO", deliveryitemno, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_DELIVERYORDER", $"{deliveryorderid},{deliveryitemno},{siteid}"));
		}
		Deliveryorder? result = ContextManager.DirectEntityQuery<Deliveryorder>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{deliveryorderid},{deliveryitemno},{siteid}");
		}
		return result;
	}

	public static Deliveryorder SelectDeliveryOrder(IDbContext dbContext, string deliveryorderid, string deliveryitemno, string siteid)
	{
		string apiName = "SelectDeliveryOrder";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{deliveryorderid},{deliveryitemno},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectDeliveryOrderSqlDatabase : _sqlSelectDeliveryOrderOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DELIVERYORDERID", deliveryorderid, typeOfThis));
		list.Add(dbContext.CreateParameter("DELIVERYITEMNO", deliveryitemno, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_DELIVERYORDER", $"{deliveryorderid},{deliveryitemno},{siteid}"));
		}
		Deliveryorder? result = ContextManager.DirectEntityQuery<Deliveryorder>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{deliveryorderid},{deliveryitemno},{siteid}");
		}
		return result;
	}

	public static Deliveryorder SelectDeliveryOrder4Update(IDbContext dbContext, string deliveryorderid, string deliveryitemno, string siteid)
	{
		string apiName = "SelectDeliveryOrder4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{deliveryorderid},{deliveryitemno},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectDeliveryOrder4UpdateSqlDatabase : _sqlSelectDeliveryOrder4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DELIVERYORDERID", deliveryorderid, typeOfThis));
		list.Add(dbContext.CreateParameter("DELIVERYITEMNO", deliveryitemno, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_DELIVERYORDER", $"{deliveryorderid},{deliveryitemno},{siteid}"));
		}
		Deliveryorder? result = ContextManager.DirectEntityQuery<Deliveryorder>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{deliveryorderid},{deliveryitemno},{siteid}");
		}
		return result;
	}

	public static int UpsertDeliveryOrder(IDbContext dbContext, RequestType requestType, Deliveryorder[] deliveryOrderList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateDeliveryOrderInternal(dbContext, deliveryOrderList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateDeliveryOrder(dbContext, deliveryOrderList, optionSet, saveHist), 
			RequestType.DELETE => DeleteDeliveryOrder(dbContext, deliveryOrderList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteDeliveryOrder(dbContext, deliveryOrderList, optionSet, saveHist), 
			_ => RealDeleteDeliveryOrder(dbContext, deliveryOrderList, optionSet, saveHist), 
		};
	}

	private static int CreateDeliveryOrderInternal(IDbContext dbContext, Deliveryorder[] deliveryOrderList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("deliveryOrderList", deliveryOrderList);
		string text = "CreateDeliveryOrder";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Deliveryorder> list = new List<Deliveryorder>();
		foreach (Deliveryorder obj in deliveryOrderList)
		{
			Deliveryorder deliveryorder = new Deliveryorder();
			obj.CopyColumsTo(deliveryorder);
			deliveryorder.Activity = text;
			deliveryorder.CheckEntityUsable();
			obj.CopyCommonField(deliveryorder, systemTime, dbContext.Tid, isCreate: true);
			list.Add(deliveryorder);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateDeliveryOrder(IDbContext dbContext, Deliveryorder[] deliveryOrderList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("deliveryOrderList", deliveryOrderList);
		string text = "UpdateDeliveryOrder";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Deliveryorder> list = new List<Deliveryorder>();
		foreach (Deliveryorder deliveryorder in deliveryOrderList)
		{
			Deliveryorder deliveryOrder4Update = GetDeliveryOrder4Update(dbContext, deliveryorder.Deliveryorderid, deliveryorder.Deliveryitemno, deliveryorder.Siteid);
			if (deliveryOrder4Update == null)
			{
				throw new EntityNotFoundException(typeof(Deliveryorder), $"{deliveryorder.Deliveryorderid},{deliveryorder.Deliveryitemno},{deliveryorder.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Deliveryorder), $"{deliveryorder.Deliveryorderid},{deliveryorder.Deliveryitemno},{deliveryorder.Siteid}", deliveryOrder4Update.Isusable);
			string activity = deliveryOrder4Update.Activity;
			string customactivity = deliveryOrder4Update.Customactivity;
			string isusable = deliveryOrder4Update.Isusable;
			DateTime? createtime = deliveryOrder4Update.Createtime;
			string creator = deliveryOrder4Update.Creator;
			deliveryorder.CopyColumsTo(deliveryOrder4Update);
			deliveryOrder4Update.Prevactivity = activity;
			deliveryOrder4Update.Prevcustomactivity = customactivity;
			deliveryOrder4Update.Creator = creator;
			deliveryOrder4Update.Createtime = createtime;
			deliveryOrder4Update.Isusable = isusable;
			deliveryOrder4Update.Activity = text;
			deliveryorder.CopyCommonField(deliveryOrder4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(deliveryOrder4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteDeliveryOrder(IDbContext dbContext, Deliveryorder[] deliveryOrderList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("deliveryOrderList", deliveryOrderList);
		string text = "DeleteDeliveryOrder";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Deliveryorder> list = new List<Deliveryorder>();
		foreach (Deliveryorder deliveryorder in deliveryOrderList)
		{
			Deliveryorder deliveryOrder4Update = GetDeliveryOrder4Update(dbContext, deliveryorder.Deliveryorderid, deliveryorder.Deliveryitemno, deliveryorder.Siteid);
			if (deliveryOrder4Update == null)
			{
				throw new EntityNotFoundException(typeof(Deliveryorder), $"{deliveryorder.Deliveryorderid},{deliveryorder.Deliveryitemno},{deliveryorder.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Deliveryorder), $"{deliveryorder.Deliveryorderid},{deliveryorder.Deliveryitemno},{deliveryorder.Siteid}", deliveryOrder4Update.Isusable);
			deliveryOrder4Update.Isusable = "UnUsable";
			deliveryorder.CopyCommonFieldUpdatePrev(deliveryOrder4Update, systemTime, dbContext.Tid, text);
			deliveryorder.CopyExtensionCollection(deliveryOrder4Update);
			list.Add(deliveryOrder4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteDeliveryOrder(IDbContext dbContext, Deliveryorder[] deliveryOrderList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("deliveryOrderList", deliveryOrderList);
		string text = "UnDeleteDeliveryOrder";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Deliveryorder> list = new List<Deliveryorder>();
		foreach (Deliveryorder deliveryorder in deliveryOrderList)
		{
			Deliveryorder deliveryOrder4Update = GetDeliveryOrder4Update(dbContext, deliveryorder.Deliveryorderid, deliveryorder.Deliveryitemno, deliveryorder.Siteid);
			if (deliveryOrder4Update == null)
			{
				throw new EntityNotFoundException(typeof(Deliveryorder), $"{deliveryorder.Deliveryorderid},{deliveryorder.Deliveryitemno},{deliveryorder.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Deliveryorder), $"{deliveryorder.Deliveryorderid},{deliveryorder.Deliveryitemno},{deliveryorder.Siteid}", deliveryOrder4Update.Isusable);
			deliveryOrder4Update.Isusable = "Usable";
			deliveryorder.CopyCommonFieldUpdatePrev(deliveryOrder4Update, systemTime, dbContext.Tid, text);
			deliveryorder.CopyExtensionCollection(deliveryOrder4Update);
			list.Add(deliveryOrder4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteDeliveryOrder(IDbContext dbContext, Deliveryorder[] deliveryOrderList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("deliveryOrderList", deliveryOrderList);
		string text = "RealDeleteDeliveryOrder";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Deliveryorder> list = new List<Deliveryorder>();
		foreach (Deliveryorder deliveryorder in deliveryOrderList)
		{
			Deliveryorder deliveryOrder4Update = GetDeliveryOrder4Update(dbContext, deliveryorder.Deliveryorderid, deliveryorder.Deliveryitemno, deliveryorder.Siteid);
			if (deliveryOrder4Update == null)
			{
				throw new EntityNotFoundException(typeof(Deliveryorder), $"{deliveryorder.Deliveryorderid},{deliveryorder.Deliveryitemno},{deliveryorder.Siteid}");
			}
			deliveryorder.CopyCommonFieldUpdatePrev(deliveryOrder4Update, systemTime, dbContext.Tid, text);
			deliveryorder.CopyExtensionCollection(deliveryOrder4Update);
			list.Add(deliveryOrder4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	internal static string[] ExtractIdOrderBy(Deliveryorder[] deliveryorderList)
	{
		return (from p in deliveryorderList
			select p.Deliveryorderid into id
			orderby id
			select id).ToArray();
	}

	public static Deliveryorder FindDeliveryorder(Deliveryorder[] deliveryorderidList, string deliveryorderid)
	{
		return deliveryorderidList?.FirstOrDefault((Deliveryorder item) => item.Deliveryorderid == deliveryorderid);
	}

	public static IList<Deliveryorder> SelectDeliveryOrderList(IDbContext dbContext, Deliveryorder[] deliveryorderList, string siteId)
	{
		string apiName = "SelectDeliveryOrderList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{deliveryorderList.Length},{siteId}");
		}
		string value = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectDeliveryOrderListSqlDatabase : _sqlSelectDeliveryOrderListOracleDatabase);
		value = new StringBuilder(value, 1000).Replace("&DELIVERYORDERLIST", EntityHelper.ConcatString4InClause(ExtractIdOrderBy(deliveryorderList))).ToString();
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_DELIVERYORDER", $"{deliveryorderList.Length},{siteId}"));
		}
		IList<Deliveryorder> result = ContextManager.DirectEntityQuery<Deliveryorder>(dbContext, value, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{deliveryorderList.Length},{siteId}");
		}
		return result;
	}

	public static IList<Deliveryorder> SelectDeliveryOrderList4Update(IDbContext dbContext, Deliveryorder[] deliveryorderList, string siteId)
	{
		string apiName = "SelectDeliveryOrderList4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{deliveryorderList.Length},{siteId}");
		}
		string value = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectDeliveryOrderList4UpdateSqlDatabase : _sqlSelectDeliveryOrderList4UpdateOracleDatabase);
		value = new StringBuilder(value, 1000).Replace("&DELIVERYORDERLIST", EntityHelper.ConcatString4InClause(ExtractIdOrderBy(deliveryorderList))).ToString();
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_DELIVERYORDER", $"{deliveryorderList.Length},{siteId}"));
		}
		IList<Deliveryorder> result = ContextManager.DirectEntityQuery<Deliveryorder>(dbContext, value, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{deliveryorderList.Length},{siteId}");
		}
		return result;
	}
}
