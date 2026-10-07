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
public class PRODUCTRULEKEY
{
	private static string _sqlGetProductRuleKeySqlDatabase = "SELECT * FROM CIM_PRODUCTRULEKEY WHERE PRODUCTRULETYPE=@PRODUCTRULETYPE AND SITEID=@SITEID";

	private static string _sqlGetProductRuleKey4UpdateSqlDatabase = "SELECT * FROM CIM_PRODUCTRULEKEY WITH(UPDLOCK) WHERE PRODUCTRULETYPE=@PRODUCTRULETYPE AND SITEID=@SITEID";

	private static string _sqlSelectProductRuleKeySqlDatabase = "SELECT * FROM CIM_PRODUCTRULEKEY WHERE PRODUCTRULETYPE=@PRODUCTRULETYPE AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProductRuleKey4UpdateSqlDatabase = "SELECT * FROM CIM_PRODUCTRULEKEY WITH(UPDLOCK) WHERE PRODUCTRULETYPE=@PRODUCTRULETYPE AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetProductRuleKeyOracleDatabase = "SELECT * FROM CIM_PRODUCTRULEKEY WHERE PRODUCTRULETYPE=:PRODUCTRULETYPE AND SITEID=:SITEID";

	private static string _sqlGetProductRuleKey4UpdateOracleDatabase = "SELECT * FROM CIM_PRODUCTRULEKEY WHERE PRODUCTRULETYPE=:PRODUCTRULETYPE AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectProductRuleKeyOracleDatabase = "SELECT * FROM CIM_PRODUCTRULEKEY WHERE PRODUCTRULETYPE=:PRODUCTRULETYPE AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProductRuleKey4UpdateOracleDatabase = "SELECT * FROM CIM_PRODUCTRULEKEY WHERE PRODUCTRULETYPE=:PRODUCTRULETYPE AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Productrulekey);

	public static Productrulekey GetProductRuleKey(IDbContext dbContext, string productruletype, string siteid)
	{
		string apiName = "GetProductRuleKey";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productruletype},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProductRuleKeySqlDatabase : _sqlGetProductRuleKeyOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTRULETYPE", productruletype, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PRODUCTRULEKEY", $"{productruletype},{siteid}"));
		}
		Productrulekey? result = ContextManager.DirectEntityQuery<Productrulekey>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productruletype},{siteid}");
		}
		return result;
	}

	public static Productrulekey GetProductRuleKey4Update(IDbContext dbContext, string productruletype, string siteid)
	{
		string apiName = "GetProductRuleKey4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productruletype},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProductRuleKey4UpdateSqlDatabase : _sqlGetProductRuleKey4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTRULETYPE", productruletype, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PRODUCTRULEKEY", $"{productruletype},{siteid}"));
		}
		Productrulekey? result = ContextManager.DirectEntityQuery<Productrulekey>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productruletype},{siteid}");
		}
		return result;
	}

	public static Productrulekey SelectProductRuleKey(IDbContext dbContext, string productruletype, string siteid)
	{
		string apiName = "SelectProductRuleKey";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productruletype},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProductRuleKeySqlDatabase : _sqlSelectProductRuleKeyOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTRULETYPE", productruletype, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PRODUCTRULEKEY", $"{productruletype},{siteid}"));
		}
		Productrulekey? result = ContextManager.DirectEntityQuery<Productrulekey>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productruletype},{siteid}");
		}
		return result;
	}

	public static Productrulekey SelectProductRuleKey4Update(IDbContext dbContext, string productruletype, string siteid)
	{
		string apiName = "SelectProductRuleKey4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productruletype},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProductRuleKey4UpdateSqlDatabase : _sqlSelectProductRuleKey4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTRULETYPE", productruletype, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PRODUCTRULEKEY", $"{productruletype},{siteid}"));
		}
		Productrulekey? result = ContextManager.DirectEntityQuery<Productrulekey>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productruletype},{siteid}");
		}
		return result;
	}

	public static int UpsertProductRuleKey(IDbContext dbContext, RequestType requestType, Productrulekey[] productRuleKeyList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateProductRuleKeyInternal(dbContext, productRuleKeyList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateProductRuleKey(dbContext, productRuleKeyList, optionSet, saveHist), 
			RequestType.DELETE => DeleteProductRuleKey(dbContext, productRuleKeyList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteProductRuleKey(dbContext, productRuleKeyList, optionSet, saveHist), 
			_ => RealDeleteProductRuleKey(dbContext, productRuleKeyList, optionSet, saveHist), 
		};
	}

	private static int CreateProductRuleKeyInternal(IDbContext dbContext, Productrulekey[] productRuleKeyList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productRuleKeyList", productRuleKeyList);
		string text = "CreateProductRuleKey";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productrulekey> list = new List<Productrulekey>();
		foreach (Productrulekey obj in productRuleKeyList)
		{
			Productrulekey productrulekey = new Productrulekey();
			obj.CopyColumsTo(productrulekey);
			productrulekey.Activity = text;
			productrulekey.CheckEntityUsable();
			obj.CopyCommonField(productrulekey, systemTime, dbContext.Tid, isCreate: true);
			list.Add(productrulekey);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateProductRuleKey(IDbContext dbContext, Productrulekey[] productRuleKeyList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productRuleKeyList", productRuleKeyList);
		string text = "UpdateProductRuleKey";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productrulekey> list = new List<Productrulekey>();
		foreach (Productrulekey productrulekey in productRuleKeyList)
		{
			Productrulekey productRuleKey4Update = GetProductRuleKey4Update(dbContext, productrulekey.Productruletype, productrulekey.Siteid);
			if (productRuleKey4Update == null)
			{
				throw new EntityNotFoundException(typeof(Productrulekey), $"{productrulekey.Productruletype},{productrulekey.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Productrulekey), $"{productrulekey.Productruletype},{productrulekey.Siteid}", productRuleKey4Update.Isusable);
			string activity = productRuleKey4Update.Activity;
			string customactivity = productRuleKey4Update.Customactivity;
			string isusable = productRuleKey4Update.Isusable;
			DateTime? createtime = productRuleKey4Update.Createtime;
			string creator = productRuleKey4Update.Creator;
			productrulekey.CopyColumsTo(productRuleKey4Update);
			productRuleKey4Update.Prevactivity = activity;
			productRuleKey4Update.Prevcustomactivity = customactivity;
			productRuleKey4Update.Creator = creator;
			productRuleKey4Update.Createtime = createtime;
			productRuleKey4Update.Isusable = isusable;
			productRuleKey4Update.Activity = text;
			productrulekey.CopyCommonField(productRuleKey4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(productRuleKey4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteProductRuleKey(IDbContext dbContext, Productrulekey[] productRuleKeyList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productRuleKeyList", productRuleKeyList);
		string text = "DeleteProductRuleKey";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productrulekey> list = new List<Productrulekey>();
		foreach (Productrulekey productrulekey in productRuleKeyList)
		{
			Productrulekey productRuleKey4Update = GetProductRuleKey4Update(dbContext, productrulekey.Productruletype, productrulekey.Siteid);
			if (productRuleKey4Update == null)
			{
				throw new EntityNotFoundException(typeof(Productrulekey), $"{productrulekey.Productruletype},{productrulekey.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Productrulekey), $"{productrulekey.Productruletype},{productrulekey.Siteid}", productRuleKey4Update.Isusable);
			productRuleKey4Update.Isusable = "UnUsable";
			productrulekey.CopyCommonFieldUpdatePrev(productRuleKey4Update, systemTime, dbContext.Tid, text);
			productrulekey.CopyExtensionCollection(productRuleKey4Update);
			list.Add(productRuleKey4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteProductRuleKey(IDbContext dbContext, Productrulekey[] productRuleKeyList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productRuleKeyList", productRuleKeyList);
		string text = "UnDeleteProductRuleKey";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productrulekey> list = new List<Productrulekey>();
		foreach (Productrulekey productrulekey in productRuleKeyList)
		{
			Productrulekey productRuleKey4Update = GetProductRuleKey4Update(dbContext, productrulekey.Productruletype, productrulekey.Siteid);
			if (productRuleKey4Update == null)
			{
				throw new EntityNotFoundException(typeof(Productrulekey), $"{productrulekey.Productruletype},{productrulekey.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Productrulekey), $"{productrulekey.Productruletype},{productrulekey.Siteid}", productRuleKey4Update.Isusable);
			productRuleKey4Update.Isusable = "Usable";
			productrulekey.CopyCommonFieldUpdatePrev(productRuleKey4Update, systemTime, dbContext.Tid, text);
			productrulekey.CopyExtensionCollection(productRuleKey4Update);
			list.Add(productRuleKey4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteProductRuleKey(IDbContext dbContext, Productrulekey[] productRuleKeyList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productRuleKeyList", productRuleKeyList);
		string text = "RealDeleteProductRuleKey";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productrulekey> list = new List<Productrulekey>();
		foreach (Productrulekey productrulekey in productRuleKeyList)
		{
			Productrulekey productRuleKey4Update = GetProductRuleKey4Update(dbContext, productrulekey.Productruletype, productrulekey.Siteid);
			if (productRuleKey4Update == null)
			{
				throw new EntityNotFoundException(typeof(Productrulekey), $"{productrulekey.Productruletype},{productrulekey.Siteid}");
			}
			productrulekey.CopyCommonFieldUpdatePrev(productRuleKey4Update, systemTime, dbContext.Tid, text);
			productrulekey.CopyExtensionCollection(productRuleKey4Update);
			list.Add(productRuleKey4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
