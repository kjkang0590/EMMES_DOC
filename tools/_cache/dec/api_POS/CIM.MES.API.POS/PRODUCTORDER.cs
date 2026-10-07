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
public class PRODUCTORDER
{
	private static string _sqlGetProductOrderSqlDatabase = "SELECT * FROM CIM_PRODUCTORDER WHERE PRODUCTORDERID=@PRODUCTORDERID AND SITEID=@SITEID";

	private static string _sqlGetProductOrder4UpdateSqlDatabase = "SELECT * FROM CIM_PRODUCTORDER WITH(UPDLOCK) WHERE PRODUCTORDERID=@PRODUCTORDERID AND SITEID=@SITEID";

	private static string _sqlSelectProductOrderSqlDatabase = "SELECT * FROM CIM_PRODUCTORDER WHERE PRODUCTORDERID=@PRODUCTORDERID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProductOrder4UpdateSqlDatabase = "SELECT * FROM CIM_PRODUCTORDER WITH(UPDLOCK) WHERE PRODUCTORDERID=@PRODUCTORDERID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetProductOrderOracleDatabase = "SELECT * FROM CIM_PRODUCTORDER WHERE PRODUCTORDERID=:PRODUCTORDERID AND SITEID=:SITEID";

	private static string _sqlGetProductOrder4UpdateOracleDatabase = "SELECT * FROM CIM_PRODUCTORDER WHERE PRODUCTORDERID=:PRODUCTORDERID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectProductOrderOracleDatabase = "SELECT * FROM CIM_PRODUCTORDER WHERE PRODUCTORDERID=:PRODUCTORDERID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProductOrder4UpdateOracleDatabase = "SELECT * FROM CIM_PRODUCTORDER WHERE PRODUCTORDERID=:PRODUCTORDERID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Productorder);

	private static string _sqlGetProductOrderListByWorkOrderSqlDatabase = "SELECT * FROM CIM_PRODUCTORDER PO WHERE EXISTS ( SELECT 1 FROM CIM_WORKORDER WHERE PRODUCTORDERID = PO.PRODUCTORDERID AND SITEID = PO.SITEID AND WORKORDERID=@WORKORDERID AND SITEID=@SITEID)";

	private static string _sqlSelectProductOrderListByWorkOrderSqlDatabase = "SELECT * FROM CIM_PRODUCTORDER PO WHERE EXISTS ( SELECT 1 FROM CIM_WORKORDER WHERE PRODUCTORDERID = PO.PRODUCTORDERID AND SITEID = PO.SITEID AND WORKORDERID=@WORKORDERID AND SITEID=@SITEID AND ISUSABLE='Usable') AND ISUSABLE='Usable'";

	private static string _sqlGetProductOrderListByWorkOrderOracleDatabase = "SELECT * FROM CIM_PRODUCTORDER PO WHERE EXISTS ( SELECT 1 FROM CIM_WORKORDER WHERE PRODUCTORDERID = PO.PRODUCTORDERID AND SITEID = PO.SITEID AND WORKORDERID=:WORKORDERID AND SITEID=:SITEID)";

	private static string _sqlSelectProductOrderListByWorkOrderOracleDatabase = "SELECT * FROM CIM_PRODUCTORDER PO WHERE EXISTS ( SELECT 1 FROM CIM_WORKORDER WHERE PRODUCTORDERID = PO.PRODUCTORDERID AND SITEID = PO.SITEID AND WORKORDERID=:WORKORDERID AND SITEID=:SITEID AND ISUSABLE='Usable') AND ISUSABLE='Usable'";

	public static int ChangeProductOrderState(IDbContext dbContext, Productorder[] productOrderList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productOrderList", productOrderList);
		string text = "ChangeProductOrderState";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productorder> list = new List<Productorder>();
		foreach (Productorder productorder in productOrderList)
		{
			ParamChecker.ArgumentNotNull("Productorderid", productorder.Productorderid);
			ParamChecker.ArgumentNotNull("State", productorder.State);
			ParamChecker.ArgumentNotNull("Siteid", productorder.Siteid);
			string productorderid = productorder.Productorderid;
			string state = productorder.State;
			string siteid = productorder.Siteid;
			Productorder productorder2;
			if ((productorder2 = SelectProductOrder4Update(dbContext, productorderid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Productorder), productorderid);
			}
			if (STATE.SelectState(dbContext, typeof(ProductOrderState).Name, state, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(ProductOrderState), state);
			}
			productorder2.Prevstate = productorder2.State;
			productorder2.State = state;
			productorder.CopyCommonFieldUpdatePrev(productorder2, systemTime, dbContext.Tid, text);
			productorder.CopyExtensionCollection(productorder2);
			list.Add(productorder2);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int CreateProductOrder(IDbContext dbContext, Productorder[] productOrderList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productOrderList", productOrderList);
		string text = "CreateProductOrder";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productorder> list = new List<Productorder>();
		foreach (Productorder obj in productOrderList)
		{
			Productorder productorder = new Productorder();
			obj.CopyColumsTo(productorder);
			productorder.State = "Created";
			productorder.Activity = text;
			productorder.Isusable = "Usable";
			obj.CopyCommonField(productorder, systemTime, dbContext.Tid, isCreate: true);
			list.Add(productorder);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static Productorder GetProductOrder(IDbContext dbContext, string productorderid, string siteid)
	{
		string apiName = "GetProductOrder";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productorderid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProductOrderSqlDatabase : _sqlGetProductOrderOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTORDERID", productorderid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PRODUCTORDER", $"{productorderid},{siteid}"));
		}
		Productorder? result = ContextManager.DirectEntityQuery<Productorder>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productorderid},{siteid}");
		}
		return result;
	}

	public static Productorder GetProductOrder4Update(IDbContext dbContext, string productorderid, string siteid)
	{
		string apiName = "GetProductOrder4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productorderid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProductOrder4UpdateSqlDatabase : _sqlGetProductOrder4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTORDERID", productorderid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PRODUCTORDER", $"{productorderid},{siteid}"));
		}
		Productorder? result = ContextManager.DirectEntityQuery<Productorder>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productorderid},{siteid}");
		}
		return result;
	}

	public static Productorder SelectProductOrder(IDbContext dbContext, string productorderid, string siteid)
	{
		string apiName = "SelectProductOrder";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productorderid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProductOrderSqlDatabase : _sqlSelectProductOrderOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTORDERID", productorderid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PRODUCTORDER", $"{productorderid},{siteid}"));
		}
		Productorder? result = ContextManager.DirectEntityQuery<Productorder>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productorderid},{siteid}");
		}
		return result;
	}

	public static Productorder SelectProductOrder4Update(IDbContext dbContext, string productorderid, string siteid)
	{
		string apiName = "SelectProductOrder4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productorderid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProductOrder4UpdateSqlDatabase : _sqlSelectProductOrder4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTORDERID", productorderid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PRODUCTORDER", $"{productorderid},{siteid}"));
		}
		Productorder? result = ContextManager.DirectEntityQuery<Productorder>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productorderid},{siteid}");
		}
		return result;
	}

	public static IList<Productorder> GetProductOrderListByWorkOrder(IDbContext dbContext, string workorderid, string siteid)
	{
		string apiName = "GetProductOrderListByWorkOrder";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{workorderid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProductOrderListByWorkOrderSqlDatabase : _sqlGetProductOrderListByWorkOrderOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("WORKORDERID", workorderid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PRODUCTORDER", $"{workorderid},{siteid}"));
		}
		IList<Productorder> result = ContextManager.DirectEntityQuery<Productorder>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{workorderid},{siteid}");
		}
		return result;
	}

	public static IList<Productorder> SelectProductOrderListByWorkOrder(IDbContext dbContext, string workorderid, string siteid)
	{
		string apiName = "SelectProductOrderListByWorkOrder";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{workorderid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProductOrderListByWorkOrderSqlDatabase : _sqlSelectProductOrderListByWorkOrderOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("WORKORDERID", workorderid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PRODUCTORDER", $"{workorderid},{siteid}"));
		}
		IList<Productorder> result = ContextManager.DirectEntityQuery<Productorder>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{workorderid},{siteid}");
		}
		return result;
	}

	public static int UpsertProductOrder(IDbContext dbContext, RequestType requestType, Productorder[] productOrderList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateProductOrderInternal(dbContext, productOrderList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateProductOrder(dbContext, productOrderList, optionSet, saveHist), 
			RequestType.DELETE => DeleteProductOrder(dbContext, productOrderList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteProductOrder(dbContext, productOrderList, optionSet, saveHist), 
			_ => RealDeleteProductOrder(dbContext, productOrderList, optionSet, saveHist), 
		};
	}

	private static int CreateProductOrderInternal(IDbContext dbContext, Productorder[] productOrderList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productOrderList", productOrderList);
		string text = "CreateProductOrder";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productorder> list = new List<Productorder>();
		foreach (Productorder obj in productOrderList)
		{
			Productorder productorder = new Productorder();
			obj.CopyColumsTo(productorder);
			productorder.Activity = text;
			productorder.CheckEntityUsable();
			obj.CopyCommonField(productorder, systemTime, dbContext.Tid, isCreate: true);
			list.Add(productorder);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateProductOrder(IDbContext dbContext, Productorder[] productOrderList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productOrderList", productOrderList);
		string text = "UpdateProductOrder";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productorder> list = new List<Productorder>();
		foreach (Productorder productorder in productOrderList)
		{
			Productorder productOrder4Update = GetProductOrder4Update(dbContext, productorder.Productorderid, productorder.Siteid);
			if (productOrder4Update == null)
			{
				throw new EntityNotFoundException(typeof(Productorder), $"{productorder.Productorderid},{productorder.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Productorder), $"{productorder.Productorderid},{productorder.Siteid}", productOrder4Update.Isusable);
			string activity = productOrder4Update.Activity;
			string customactivity = productOrder4Update.Customactivity;
			string isusable = productOrder4Update.Isusable;
			DateTime? createtime = productOrder4Update.Createtime;
			string creator = productOrder4Update.Creator;
			productorder.CopyColumsTo(productOrder4Update);
			productOrder4Update.Prevactivity = activity;
			productOrder4Update.Prevcustomactivity = customactivity;
			productOrder4Update.Creator = creator;
			productOrder4Update.Createtime = createtime;
			productOrder4Update.Isusable = isusable;
			productOrder4Update.Activity = text;
			productorder.CopyCommonField(productOrder4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(productOrder4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteProductOrder(IDbContext dbContext, Productorder[] productOrderList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productOrderList", productOrderList);
		string text = "DeleteProductOrder";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productorder> list = new List<Productorder>();
		foreach (Productorder productorder in productOrderList)
		{
			Productorder productOrder4Update = GetProductOrder4Update(dbContext, productorder.Productorderid, productorder.Siteid);
			if (productOrder4Update == null)
			{
				throw new EntityNotFoundException(typeof(Productorder), $"{productorder.Productorderid},{productorder.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Productorder), $"{productorder.Productorderid},{productorder.Siteid}", productOrder4Update.Isusable);
			productOrder4Update.Isusable = "UnUsable";
			productorder.CopyCommonFieldUpdatePrev(productOrder4Update, systemTime, dbContext.Tid, text);
			productorder.CopyExtensionCollection(productOrder4Update);
			list.Add(productOrder4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteProductOrder(IDbContext dbContext, Productorder[] productOrderList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productOrderList", productOrderList);
		string text = "UnDeleteProductOrder";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productorder> list = new List<Productorder>();
		foreach (Productorder productorder in productOrderList)
		{
			Productorder productOrder4Update = GetProductOrder4Update(dbContext, productorder.Productorderid, productorder.Siteid);
			if (productOrder4Update == null)
			{
				throw new EntityNotFoundException(typeof(Productorder), $"{productorder.Productorderid},{productorder.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Productorder), $"{productorder.Productorderid},{productorder.Siteid}", productOrder4Update.Isusable);
			productOrder4Update.Isusable = "Usable";
			productorder.CopyCommonFieldUpdatePrev(productOrder4Update, systemTime, dbContext.Tid, text);
			productorder.CopyExtensionCollection(productOrder4Update);
			list.Add(productOrder4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteProductOrder(IDbContext dbContext, Productorder[] productOrderList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productOrderList", productOrderList);
		string text = "RealDeleteProductOrder";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productorder> list = new List<Productorder>();
		foreach (Productorder productorder in productOrderList)
		{
			Productorder productOrder4Update = GetProductOrder4Update(dbContext, productorder.Productorderid, productorder.Siteid);
			if (productOrder4Update == null)
			{
				throw new EntityNotFoundException(typeof(Productorder), $"{productorder.Productorderid},{productorder.Siteid}");
			}
			productorder.CopyCommonFieldUpdatePrev(productOrder4Update, systemTime, dbContext.Tid, text);
			productorder.CopyExtensionCollection(productOrder4Update);
			list.Add(productOrder4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
