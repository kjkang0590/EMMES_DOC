using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.CDS;

[MESAPI]
public class CUSTOMER
{
	private static string _sqlGetCustomerSqlDatabase = "SELECT * FROM CIM_CUSTOMER WHERE CUSTOMERID=@CUSTOMERID AND SITEID=@SITEID";

	private static string _sqlGetCustomer4UpdateSqlDatabase = "SELECT * FROM CIM_CUSTOMER WITH(UPDLOCK) WHERE CUSTOMERID=@CUSTOMERID AND SITEID=@SITEID";

	private static string _sqlSelectCustomerSqlDatabase = "SELECT * FROM CIM_CUSTOMER WHERE CUSTOMERID=@CUSTOMERID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectCustomer4UpdateSqlDatabase = "SELECT * FROM CIM_CUSTOMER WITH(UPDLOCK) WHERE CUSTOMERID=@CUSTOMERID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetCustomerOracleDatabase = "SELECT * FROM CIM_CUSTOMER WHERE CUSTOMERID=:CUSTOMERID AND SITEID=:SITEID";

	private static string _sqlGetCustomer4UpdateOracleDatabase = "SELECT * FROM CIM_CUSTOMER WHERE CUSTOMERID=:CUSTOMERID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectCustomerOracleDatabase = "SELECT * FROM CIM_CUSTOMER WHERE CUSTOMERID=:CUSTOMERID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectCustomer4UpdateOracleDatabase = "SELECT * FROM CIM_CUSTOMER WHERE CUSTOMERID=:CUSTOMERID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Customer);

	public static Customer GetCustomer(IDbContext dbContext, string customerid, string siteid)
	{
		string apiName = "GetCustomer";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{customerid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetCustomerSqlDatabase : _sqlGetCustomerOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CUSTOMERID", customerid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_CUSTOMER", $"{customerid},{siteid}"));
		}
		Customer? result = ContextManager.DirectEntityQuery<Customer>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{customerid},{siteid}");
		}
		return result;
	}

	public static Customer GetCustomer4Update(IDbContext dbContext, string customerid, string siteid)
	{
		string apiName = "GetCustomer4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{customerid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetCustomer4UpdateSqlDatabase : _sqlGetCustomer4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CUSTOMERID", customerid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_CUSTOMER", $"{customerid},{siteid}"));
		}
		Customer? result = ContextManager.DirectEntityQuery<Customer>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{customerid},{siteid}");
		}
		return result;
	}

	public static Customer SelectCustomer(IDbContext dbContext, string customerid, string siteid)
	{
		string apiName = "SelectCustomer";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{customerid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectCustomerSqlDatabase : _sqlSelectCustomerOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CUSTOMERID", customerid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_CUSTOMER", $"{customerid},{siteid}"));
		}
		Customer? result = ContextManager.DirectEntityQuery<Customer>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{customerid},{siteid}");
		}
		return result;
	}

	public static Customer SelectCustomer4Update(IDbContext dbContext, string customerid, string siteid)
	{
		string apiName = "SelectCustomer4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{customerid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectCustomer4UpdateSqlDatabase : _sqlSelectCustomer4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CUSTOMERID", customerid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_CUSTOMER", $"{customerid},{siteid}"));
		}
		Customer? result = ContextManager.DirectEntityQuery<Customer>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{customerid},{siteid}");
		}
		return result;
	}

	public static int UpsertCustomer(IDbContext dbContext, RequestType requestType, Customer[] customerList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateCustomerInternal(dbContext, customerList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateCustomer(dbContext, customerList, optionSet, saveHist), 
			RequestType.DELETE => DeleteCustomer(dbContext, customerList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteCustomer(dbContext, customerList, optionSet, saveHist), 
			_ => RealDeleteCustomer(dbContext, customerList, optionSet, saveHist), 
		};
	}

	private static int CreateCustomerInternal(IDbContext dbContext, Customer[] customerList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("customerList", customerList);
		string text = "CreateCustomer";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Customer> list = new List<Customer>();
		foreach (Customer obj in customerList)
		{
			Customer customer = new Customer();
			obj.CopyColumsTo(customer);
			customer.Activity = text;
			customer.CheckEntityUsable();
			obj.CopyCommonField(customer, systemTime, dbContext.Tid, isCreate: true);
			list.Add(customer);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateCustomer(IDbContext dbContext, Customer[] customerList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("customerList", customerList);
		string text = "UpdateCustomer";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Customer> list = new List<Customer>();
		foreach (Customer customer in customerList)
		{
			Customer customer4Update = GetCustomer4Update(dbContext, customer.Customerid, customer.Siteid);
			if (customer4Update == null)
			{
				throw new EntityNotFoundException(typeof(Customer), $"{customer.Customerid},{customer.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Customer), $"{customer.Customerid},{customer.Siteid}", customer4Update.Isusable);
			string activity = customer4Update.Activity;
			string customactivity = customer4Update.Customactivity;
			string isusable = customer4Update.Isusable;
			DateTime? createtime = customer4Update.Createtime;
			string creator = customer4Update.Creator;
			customer.CopyColumsTo(customer4Update);
			customer4Update.Prevactivity = activity;
			customer4Update.Prevcustomactivity = customactivity;
			customer4Update.Creator = creator;
			customer4Update.Createtime = createtime;
			customer4Update.Isusable = isusable;
			customer4Update.Activity = text;
			customer.CopyCommonField(customer4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(customer4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteCustomer(IDbContext dbContext, Customer[] customerList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("customerList", customerList);
		string text = "DeleteCustomer";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Customer> list = new List<Customer>();
		foreach (Customer customer in customerList)
		{
			Customer customer4Update = GetCustomer4Update(dbContext, customer.Customerid, customer.Siteid);
			if (customer4Update == null)
			{
				throw new EntityNotFoundException(typeof(Customer), $"{customer.Customerid},{customer.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Customer), $"{customer.Customerid},{customer.Siteid}", customer4Update.Isusable);
			customer4Update.Isusable = "UnUsable";
			customer.CopyCommonFieldUpdatePrev(customer4Update, systemTime, dbContext.Tid, text);
			customer.CopyExtensionCollection(customer4Update);
			list.Add(customer4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteCustomer(IDbContext dbContext, Customer[] customerList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("customerList", customerList);
		string text = "UnDeleteCustomer";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Customer> list = new List<Customer>();
		foreach (Customer customer in customerList)
		{
			Customer customer4Update = GetCustomer4Update(dbContext, customer.Customerid, customer.Siteid);
			if (customer4Update == null)
			{
				throw new EntityNotFoundException(typeof(Customer), $"{customer.Customerid},{customer.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Customer), $"{customer.Customerid},{customer.Siteid}", customer4Update.Isusable);
			customer4Update.Isusable = "Usable";
			customer.CopyCommonFieldUpdatePrev(customer4Update, systemTime, dbContext.Tid, text);
			customer.CopyExtensionCollection(customer4Update);
			list.Add(customer4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteCustomer(IDbContext dbContext, Customer[] customerList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("customerList", customerList);
		string text = "RealDeleteCustomer";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Customer> list = new List<Customer>();
		foreach (Customer customer in customerList)
		{
			Customer customer4Update = GetCustomer4Update(dbContext, customer.Customerid, customer.Siteid);
			if (customer4Update == null)
			{
				throw new EntityNotFoundException(typeof(Customer), $"{customer.Customerid},{customer.Siteid}");
			}
			customer.CopyCommonFieldUpdatePrev(customer4Update, systemTime, dbContext.Tid, text);
			customer.CopyExtensionCollection(customer4Update);
			list.Add(customer4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
