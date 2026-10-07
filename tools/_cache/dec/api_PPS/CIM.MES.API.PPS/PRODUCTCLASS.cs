using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.PPS;

[MESAPI]
public class PRODUCTCLASS
{
	private static string _sqlGetProductClassSqlDatabase = "SELECT * FROM CIM_PRODUCTCLASS WHERE PRODUCTCLASSID=@PRODUCTCLASSID AND SITEID=@SITEID";

	private static string _sqlGetProductClass4UpdateSqlDatabase = "SELECT * FROM CIM_PRODUCTCLASS WITH(UPDLOCK) WHERE PRODUCTCLASSID=@PRODUCTCLASSID AND SITEID=@SITEID";

	private static string _sqlSelectProductClassSqlDatabase = "SELECT * FROM CIM_PRODUCTCLASS WHERE PRODUCTCLASSID=@PRODUCTCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProductClass4UpdateSqlDatabase = "SELECT * FROM CIM_PRODUCTCLASS WITH(UPDLOCK) WHERE PRODUCTCLASSID=@PRODUCTCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetProductClassOracleDatabase = "SELECT * FROM CIM_PRODUCTCLASS WHERE PRODUCTCLASSID=:PRODUCTCLASSID AND SITEID=:SITEID";

	private static string _sqlGetProductClass4UpdateOracleDatabase = "SELECT * FROM CIM_PRODUCTCLASS WHERE PRODUCTCLASSID=:PRODUCTCLASSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectProductClassOracleDatabase = "SELECT * FROM CIM_PRODUCTCLASS WHERE PRODUCTCLASSID=:PRODUCTCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProductClass4UpdateOracleDatabase = "SELECT * FROM CIM_PRODUCTCLASS WHERE PRODUCTCLASSID=:PRODUCTCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Productclass);

	public static Productclass GetProductClass(IDbContext dbContext, string productclassid, string siteid)
	{
		string apiName = "GetProductClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProductClassSqlDatabase : _sqlGetProductClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTCLASSID", productclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PRODUCTCLASS", $"{productclassid},{siteid}"));
		}
		Productclass? result = ContextManager.DirectEntityQuery<Productclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productclassid},{siteid}");
		}
		return result;
	}

	public static Productclass GetProductClass4Update(IDbContext dbContext, string productclassid, string siteid)
	{
		string apiName = "GetProductClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProductClass4UpdateSqlDatabase : _sqlGetProductClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTCLASSID", productclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PRODUCTCLASS", $"{productclassid},{siteid}"));
		}
		Productclass? result = ContextManager.DirectEntityQuery<Productclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productclassid},{siteid}");
		}
		return result;
	}

	public static Productclass SelectProductClass(IDbContext dbContext, string productclassid, string siteid)
	{
		string apiName = "SelectProductClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProductClassSqlDatabase : _sqlSelectProductClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTCLASSID", productclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PRODUCTCLASS", $"{productclassid},{siteid}"));
		}
		Productclass? result = ContextManager.DirectEntityQuery<Productclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productclassid},{siteid}");
		}
		return result;
	}

	public static Productclass SelectProductClass4Update(IDbContext dbContext, string productclassid, string siteid)
	{
		string apiName = "SelectProductClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProductClass4UpdateSqlDatabase : _sqlSelectProductClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTCLASSID", productclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PRODUCTCLASS", $"{productclassid},{siteid}"));
		}
		Productclass? result = ContextManager.DirectEntityQuery<Productclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productclassid},{siteid}");
		}
		return result;
	}

	public static int UpsertProductClass(IDbContext dbContext, RequestType requestType, Productclass[] productClassList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateProductClassInternal(dbContext, productClassList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateProductClass(dbContext, productClassList, optionSet, saveHist), 
			RequestType.DELETE => DeleteProductClass(dbContext, productClassList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteProductClass(dbContext, productClassList, optionSet, saveHist), 
			_ => RealDeleteProductClass(dbContext, productClassList, optionSet, saveHist), 
		};
	}

	private static int CreateProductClassInternal(IDbContext dbContext, Productclass[] productClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productClassList", productClassList);
		string text = "CreateProductClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productclass> list = new List<Productclass>();
		foreach (Productclass obj in productClassList)
		{
			Productclass productclass = new Productclass();
			obj.CopyColumsTo(productclass);
			productclass.Activity = text;
			productclass.CheckEntityUsable();
			obj.CopyCommonField(productclass, systemTime, dbContext.Tid, isCreate: true);
			list.Add(productclass);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateProductClass(IDbContext dbContext, Productclass[] productClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productClassList", productClassList);
		string text = "UpdateProductClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productclass> list = new List<Productclass>();
		foreach (Productclass productclass in productClassList)
		{
			Productclass productClass4Update = GetProductClass4Update(dbContext, productclass.Productclassid, productclass.Siteid);
			if (productClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Productclass), $"{productclass.Productclassid},{productclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Productclass), $"{productclass.Productclassid},{productclass.Siteid}", productClass4Update.Isusable);
			string activity = productClass4Update.Activity;
			string customactivity = productClass4Update.Customactivity;
			string isusable = productClass4Update.Isusable;
			DateTime? createtime = productClass4Update.Createtime;
			string creator = productClass4Update.Creator;
			productclass.CopyColumsTo(productClass4Update);
			productClass4Update.Prevactivity = activity;
			productClass4Update.Prevcustomactivity = customactivity;
			productClass4Update.Creator = creator;
			productClass4Update.Createtime = createtime;
			productClass4Update.Isusable = isusable;
			productClass4Update.Activity = text;
			productclass.CopyCommonField(productClass4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(productClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteProductClass(IDbContext dbContext, Productclass[] productClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productClassList", productClassList);
		string text = "DeleteProductClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productclass> list = new List<Productclass>();
		foreach (Productclass productclass in productClassList)
		{
			Productclass productClass4Update = GetProductClass4Update(dbContext, productclass.Productclassid, productclass.Siteid);
			if (productClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Productclass), $"{productclass.Productclassid},{productclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Productclass), $"{productclass.Productclassid},{productclass.Siteid}", productClass4Update.Isusable);
			productClass4Update.Isusable = "UnUsable";
			productclass.CopyCommonFieldUpdatePrev(productClass4Update, systemTime, dbContext.Tid, text);
			productclass.CopyExtensionCollection(productClass4Update);
			list.Add(productClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteProductClass(IDbContext dbContext, Productclass[] productClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productClassList", productClassList);
		string text = "UnDeleteProductClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productclass> list = new List<Productclass>();
		foreach (Productclass productclass in productClassList)
		{
			Productclass productClass4Update = GetProductClass4Update(dbContext, productclass.Productclassid, productclass.Siteid);
			if (productClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Productclass), $"{productclass.Productclassid},{productclass.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Productclass), $"{productclass.Productclassid},{productclass.Siteid}", productClass4Update.Isusable);
			productClass4Update.Isusable = "Usable";
			productclass.CopyCommonFieldUpdatePrev(productClass4Update, systemTime, dbContext.Tid, text);
			productclass.CopyExtensionCollection(productClass4Update);
			list.Add(productClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteProductClass(IDbContext dbContext, Productclass[] productClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productClassList", productClassList);
		string text = "RealDeleteProductClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productclass> list = new List<Productclass>();
		foreach (Productclass productclass in productClassList)
		{
			Productclass productClass4Update = GetProductClass4Update(dbContext, productclass.Productclassid, productclass.Siteid);
			if (productClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Productclass), $"{productclass.Productclassid},{productclass.Siteid}");
			}
			productclass.CopyCommonFieldUpdatePrev(productClass4Update, systemTime, dbContext.Tid, text);
			productclass.CopyExtensionCollection(productClass4Update);
			list.Add(productClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
