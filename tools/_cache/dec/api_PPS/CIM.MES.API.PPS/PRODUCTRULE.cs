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
public class PRODUCTRULE
{
	private static string _sqlGetProductRuleSqlDatabase = "SELECT * FROM CIM_PRODUCTRULE WHERE PRODUCTRULESYSID=@PRODUCTRULESYSID AND SITEID=@SITEID";

	private static string _sqlGetProductRule4UpdateSqlDatabase = "SELECT * FROM CIM_PRODUCTRULE WITH(UPDLOCK) WHERE PRODUCTRULESYSID=@PRODUCTRULESYSID AND SITEID=@SITEID";

	private static string _sqlSelectProductRuleSqlDatabase = "SELECT * FROM CIM_PRODUCTRULE WHERE PRODUCTRULESYSID=@PRODUCTRULESYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProductRule4UpdateSqlDatabase = "SELECT * FROM CIM_PRODUCTRULE WITH(UPDLOCK) WHERE PRODUCTRULESYSID=@PRODUCTRULESYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetProductRuleOracleDatabase = "SELECT * FROM CIM_PRODUCTRULE WHERE PRODUCTRULESYSID=:PRODUCTRULESYSID AND SITEID=:SITEID";

	private static string _sqlGetProductRule4UpdateOracleDatabase = "SELECT * FROM CIM_PRODUCTRULE WHERE PRODUCTRULESYSID=:PRODUCTRULESYSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectProductRuleOracleDatabase = "SELECT * FROM CIM_PRODUCTRULE WHERE PRODUCTRULESYSID=:PRODUCTRULESYSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProductRule4UpdateOracleDatabase = "SELECT * FROM CIM_PRODUCTRULE WHERE PRODUCTRULESYSID=:PRODUCTRULESYSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Productrule);

	public static Productrule GetProductRule(IDbContext dbContext, string productrulesysid, string siteid)
	{
		string apiName = "GetProductRule";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productrulesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProductRuleSqlDatabase : _sqlGetProductRuleOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTRULESYSID", productrulesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PRODUCTRULE", $"{productrulesysid},{siteid}"));
		}
		Productrule? result = ContextManager.DirectEntityQuery<Productrule>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productrulesysid},{siteid}");
		}
		return result;
	}

	public static Productrule GetProductRule4Update(IDbContext dbContext, string productrulesysid, string siteid)
	{
		string apiName = "GetProductRule4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productrulesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProductRule4UpdateSqlDatabase : _sqlGetProductRule4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTRULESYSID", productrulesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PRODUCTRULE", $"{productrulesysid},{siteid}"));
		}
		Productrule? result = ContextManager.DirectEntityQuery<Productrule>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productrulesysid},{siteid}");
		}
		return result;
	}

	public static Productrule SelectProductRule(IDbContext dbContext, string productrulesysid, string siteid)
	{
		string apiName = "SelectProductRule";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productrulesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProductRuleSqlDatabase : _sqlSelectProductRuleOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTRULESYSID", productrulesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PRODUCTRULE", $"{productrulesysid},{siteid}"));
		}
		Productrule? result = ContextManager.DirectEntityQuery<Productrule>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productrulesysid},{siteid}");
		}
		return result;
	}

	public static Productrule SelectProductRule4Update(IDbContext dbContext, string productrulesysid, string siteid)
	{
		string apiName = "SelectProductRule4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productrulesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProductRule4UpdateSqlDatabase : _sqlSelectProductRule4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTRULESYSID", productrulesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PRODUCTRULE", $"{productrulesysid},{siteid}"));
		}
		Productrule? result = ContextManager.DirectEntityQuery<Productrule>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productrulesysid},{siteid}");
		}
		return result;
	}

	public static int UpsertProductRule(IDbContext dbContext, RequestType requestType, Productrule[] productRuleList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateProductRuleInternal(dbContext, productRuleList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateProductRule(dbContext, productRuleList, optionSet, saveHist), 
			RequestType.DELETE => DeleteProductRule(dbContext, productRuleList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteProductRule(dbContext, productRuleList, optionSet, saveHist), 
			_ => RealDeleteProductRule(dbContext, productRuleList, optionSet, saveHist), 
		};
	}

	private static int CreateProductRuleInternal(IDbContext dbContext, Productrule[] productRuleList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productRuleList", productRuleList);
		string text = "CreateProductRule";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productrule> list = new List<Productrule>();
		foreach (Productrule obj in productRuleList)
		{
			Productrule productrule = new Productrule();
			obj.CopyColumsTo(productrule);
			productrule.Activity = text;
			productrule.CheckEntityUsable();
			obj.CopyCommonField(productrule, systemTime, dbContext.Tid, isCreate: true);
			list.Add(productrule);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateProductRule(IDbContext dbContext, Productrule[] productRuleList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productRuleList", productRuleList);
		string text = "UpdateProductRule";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productrule> list = new List<Productrule>();
		foreach (Productrule productrule in productRuleList)
		{
			Productrule productRule4Update = GetProductRule4Update(dbContext, productrule.Productrulesysid, productrule.Siteid);
			if (productRule4Update == null)
			{
				throw new EntityNotFoundException(typeof(Productrule), $"{productrule.Productrulesysid},{productrule.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Productrule), $"{productrule.Productrulesysid},{productrule.Siteid}", productRule4Update.Isusable);
			string activity = productRule4Update.Activity;
			string customactivity = productRule4Update.Customactivity;
			string isusable = productRule4Update.Isusable;
			DateTime? createtime = productRule4Update.Createtime;
			string creator = productRule4Update.Creator;
			productrule.CopyColumsTo(productRule4Update);
			productRule4Update.Prevactivity = activity;
			productRule4Update.Prevcustomactivity = customactivity;
			productRule4Update.Creator = creator;
			productRule4Update.Createtime = createtime;
			productRule4Update.Isusable = isusable;
			productRule4Update.Activity = text;
			productrule.CopyCommonField(productRule4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(productRule4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteProductRule(IDbContext dbContext, Productrule[] productRuleList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productRuleList", productRuleList);
		string text = "DeleteProductRule";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productrule> list = new List<Productrule>();
		foreach (Productrule productrule in productRuleList)
		{
			Productrule productRule4Update = GetProductRule4Update(dbContext, productrule.Productrulesysid, productrule.Siteid);
			if (productRule4Update == null)
			{
				throw new EntityNotFoundException(typeof(Productrule), $"{productrule.Productrulesysid},{productrule.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Productrule), $"{productrule.Productrulesysid},{productrule.Siteid}", productRule4Update.Isusable);
			productRule4Update.Isusable = "UnUsable";
			productrule.CopyCommonFieldUpdatePrev(productRule4Update, systemTime, dbContext.Tid, text);
			productrule.CopyExtensionCollection(productRule4Update);
			list.Add(productRule4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteProductRule(IDbContext dbContext, Productrule[] productRuleList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productRuleList", productRuleList);
		string text = "UnDeleteProductRule";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productrule> list = new List<Productrule>();
		foreach (Productrule productrule in productRuleList)
		{
			Productrule productRule4Update = GetProductRule4Update(dbContext, productrule.Productrulesysid, productrule.Siteid);
			if (productRule4Update == null)
			{
				throw new EntityNotFoundException(typeof(Productrule), $"{productrule.Productrulesysid},{productrule.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Productrule), $"{productrule.Productrulesysid},{productrule.Siteid}", productRule4Update.Isusable);
			productRule4Update.Isusable = "Usable";
			productrule.CopyCommonFieldUpdatePrev(productRule4Update, systemTime, dbContext.Tid, text);
			productrule.CopyExtensionCollection(productRule4Update);
			list.Add(productRule4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteProductRule(IDbContext dbContext, Productrule[] productRuleList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productRuleList", productRuleList);
		string text = "RealDeleteProductRule";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productrule> list = new List<Productrule>();
		foreach (Productrule productrule in productRuleList)
		{
			Productrule productRule4Update = GetProductRule4Update(dbContext, productrule.Productrulesysid, productrule.Siteid);
			if (productRule4Update == null)
			{
				throw new EntityNotFoundException(typeof(Productrule), $"{productrule.Productrulesysid},{productrule.Siteid}");
			}
			productrule.CopyCommonFieldUpdatePrev(productRule4Update, systemTime, dbContext.Tid, text);
			productrule.CopyExtensionCollection(productRule4Update);
			list.Add(productRule4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
