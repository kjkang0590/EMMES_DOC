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
public class PRODUCTPROCESSREL
{
	private static string _sqlGetProductProcessRelSqlDatabase = "SELECT * FROM CIM_PRODUCTPROCESSREL WHERE PRODUCTDEFINITIONID=@PRODUCTDEFINITIONID AND PROCESSDEFINITIONID=@PROCESSDEFINITIONID AND SITEID=@SITEID";

	private static string _sqlGetProductProcessRel4UpdateSqlDatabase = "SELECT * FROM CIM_PRODUCTPROCESSREL WITH(UPDLOCK) WHERE PRODUCTDEFINITIONID=@PRODUCTDEFINITIONID AND PROCESSDEFINITIONID=@PROCESSDEFINITIONID AND SITEID=@SITEID";

	private static string _sqlSelectProductProcessRelSqlDatabase = "SELECT * FROM CIM_PRODUCTPROCESSREL WHERE PRODUCTDEFINITIONID=@PRODUCTDEFINITIONID AND PROCESSDEFINITIONID=@PROCESSDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProductProcessRel4UpdateSqlDatabase = "SELECT * FROM CIM_PRODUCTPROCESSREL WITH(UPDLOCK) WHERE PRODUCTDEFINITIONID=@PRODUCTDEFINITIONID AND PROCESSDEFINITIONID=@PROCESSDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetProductProcessRelOracleDatabase = "SELECT * FROM CIM_PRODUCTPROCESSREL WHERE PRODUCTDEFINITIONID=:PRODUCTDEFINITIONID AND PROCESSDEFINITIONID=:PROCESSDEFINITIONID AND SITEID=:SITEID";

	private static string _sqlGetProductProcessRel4UpdateOracleDatabase = "SELECT * FROM CIM_PRODUCTPROCESSREL WHERE PRODUCTDEFINITIONID=:PRODUCTDEFINITIONID AND PROCESSDEFINITIONID=:PROCESSDEFINITIONID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectProductProcessRelOracleDatabase = "SELECT * FROM CIM_PRODUCTPROCESSREL WHERE PRODUCTDEFINITIONID=:PRODUCTDEFINITIONID AND PROCESSDEFINITIONID=:PROCESSDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProductProcessRel4UpdateOracleDatabase = "SELECT * FROM CIM_PRODUCTPROCESSREL WHERE PRODUCTDEFINITIONID=:PRODUCTDEFINITIONID AND PROCESSDEFINITIONID=:PROCESSDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Productprocessrel);

	private static string _sqlSelectProductProcessRelDefaultSqlDatabase = "SELECT * FROM CIM_PRODUCTPROCESSREL WHERE PRODUCTDEFINITIONID=@PRODUCTDEFINITIONID AND ISDEFAULT='Y' AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProductProcessRelDefaultOracleDatabase = "SELECT * FROM CIM_PRODUCTPROCESSREL WHERE PRODUCTDEFINITIONID=:PRODUCTDEFINITIONID AND ISDEFAULT='Y' AND SITEID=:SITEID AND ISUSABLE='Usable'";

	public static Productprocessrel GetProductProcessRel(IDbContext dbContext, string productdefinitionid, string processdefinitionid, string siteid)
	{
		string apiName = "GetProductProcessRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productdefinitionid},{processdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProductProcessRelSqlDatabase : _sqlGetProductProcessRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", productdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSDEFINITIONID", processdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PRODUCTPROCESSREL", $"{productdefinitionid},{processdefinitionid},{siteid}"));
		}
		Productprocessrel? result = ContextManager.DirectEntityQuery<Productprocessrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productdefinitionid},{processdefinitionid},{siteid}");
		}
		return result;
	}

	public static Productprocessrel GetProductProcessRel4Update(IDbContext dbContext, string productdefinitionid, string processdefinitionid, string siteid)
	{
		string apiName = "GetProductProcessRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productdefinitionid},{processdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProductProcessRel4UpdateSqlDatabase : _sqlGetProductProcessRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", productdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSDEFINITIONID", processdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PRODUCTPROCESSREL", $"{productdefinitionid},{processdefinitionid},{siteid}"));
		}
		Productprocessrel? result = ContextManager.DirectEntityQuery<Productprocessrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productdefinitionid},{processdefinitionid},{siteid}");
		}
		return result;
	}

	public static Productprocessrel SelectProductProcessRel(IDbContext dbContext, string productdefinitionid, string processdefinitionid, string siteid)
	{
		string apiName = "SelectProductProcessRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productdefinitionid},{processdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProductProcessRelSqlDatabase : _sqlSelectProductProcessRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", productdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSDEFINITIONID", processdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PRODUCTPROCESSREL", $"{productdefinitionid},{processdefinitionid},{siteid}"));
		}
		Productprocessrel? result = ContextManager.DirectEntityQuery<Productprocessrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productdefinitionid},{processdefinitionid},{siteid}");
		}
		return result;
	}

	public static Productprocessrel SelectProductProcessRel4Update(IDbContext dbContext, string productdefinitionid, string processdefinitionid, string siteid)
	{
		string apiName = "SelectProductProcessRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productdefinitionid},{processdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProductProcessRel4UpdateSqlDatabase : _sqlSelectProductProcessRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", productdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSDEFINITIONID", processdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PRODUCTPROCESSREL", $"{productdefinitionid},{processdefinitionid},{siteid}"));
		}
		Productprocessrel? result = ContextManager.DirectEntityQuery<Productprocessrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productdefinitionid},{processdefinitionid},{siteid}");
		}
		return result;
	}

	public static int UpsertProductProcessRel(IDbContext dbContext, RequestType requestType, Productprocessrel[] productProcessRelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateProductProcessRelInternal(dbContext, productProcessRelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateProductProcessRel(dbContext, productProcessRelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteProductProcessRel(dbContext, productProcessRelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteProductProcessRel(dbContext, productProcessRelList, optionSet, saveHist), 
			_ => RealDeleteProductProcessRel(dbContext, productProcessRelList, optionSet, saveHist), 
		};
	}

	private static int CreateProductProcessRelInternal(IDbContext dbContext, Productprocessrel[] productProcessRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productProcessRelList", productProcessRelList);
		string text = "CreateProductProcessRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productprocessrel> list = new List<Productprocessrel>();
		foreach (Productprocessrel obj in productProcessRelList)
		{
			Productprocessrel productprocessrel = new Productprocessrel();
			obj.CopyColumsTo(productprocessrel);
			productprocessrel.Activity = text;
			productprocessrel.CheckEntityUsable();
			obj.CopyCommonField(productprocessrel, systemTime, dbContext.Tid, isCreate: true);
			list.Add(productprocessrel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateProductProcessRel(IDbContext dbContext, Productprocessrel[] productProcessRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productProcessRelList", productProcessRelList);
		string text = "UpdateProductProcessRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productprocessrel> list = new List<Productprocessrel>();
		foreach (Productprocessrel productprocessrel in productProcessRelList)
		{
			Productprocessrel productProcessRel4Update = GetProductProcessRel4Update(dbContext, productprocessrel.Productdefinitionid, productprocessrel.Processdefinitionid, productprocessrel.Siteid);
			if (productProcessRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Productprocessrel), $"{productprocessrel.Productdefinitionid},{productprocessrel.Processdefinitionid},{productprocessrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Productprocessrel), $"{productprocessrel.Productdefinitionid},{productprocessrel.Processdefinitionid},{productprocessrel.Siteid}", productProcessRel4Update.Isusable);
			string activity = productProcessRel4Update.Activity;
			string customactivity = productProcessRel4Update.Customactivity;
			string isusable = productProcessRel4Update.Isusable;
			DateTime? createtime = productProcessRel4Update.Createtime;
			string creator = productProcessRel4Update.Creator;
			productprocessrel.CopyColumsTo(productProcessRel4Update);
			productProcessRel4Update.Prevactivity = activity;
			productProcessRel4Update.Prevcustomactivity = customactivity;
			productProcessRel4Update.Creator = creator;
			productProcessRel4Update.Createtime = createtime;
			productProcessRel4Update.Isusable = isusable;
			productProcessRel4Update.Activity = text;
			productprocessrel.CopyCommonField(productProcessRel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(productProcessRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteProductProcessRel(IDbContext dbContext, Productprocessrel[] productProcessRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productProcessRelList", productProcessRelList);
		string text = "DeleteProductProcessRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productprocessrel> list = new List<Productprocessrel>();
		foreach (Productprocessrel productprocessrel in productProcessRelList)
		{
			Productprocessrel productProcessRel4Update = GetProductProcessRel4Update(dbContext, productprocessrel.Productdefinitionid, productprocessrel.Processdefinitionid, productprocessrel.Siteid);
			if (productProcessRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Productprocessrel), $"{productprocessrel.Productdefinitionid},{productprocessrel.Processdefinitionid},{productprocessrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Productprocessrel), $"{productprocessrel.Productdefinitionid},{productprocessrel.Processdefinitionid},{productprocessrel.Siteid}", productProcessRel4Update.Isusable);
			productProcessRel4Update.Isusable = "UnUsable";
			productprocessrel.CopyCommonFieldUpdatePrev(productProcessRel4Update, systemTime, dbContext.Tid, text);
			productprocessrel.CopyExtensionCollection(productProcessRel4Update);
			list.Add(productProcessRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteProductProcessRel(IDbContext dbContext, Productprocessrel[] productProcessRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productProcessRelList", productProcessRelList);
		string text = "UnDeleteProductProcessRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productprocessrel> list = new List<Productprocessrel>();
		foreach (Productprocessrel productprocessrel in productProcessRelList)
		{
			Productprocessrel productProcessRel4Update = GetProductProcessRel4Update(dbContext, productprocessrel.Productdefinitionid, productprocessrel.Processdefinitionid, productprocessrel.Siteid);
			if (productProcessRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Productprocessrel), $"{productprocessrel.Productdefinitionid},{productprocessrel.Processdefinitionid},{productprocessrel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Productprocessrel), $"{productprocessrel.Productdefinitionid},{productprocessrel.Processdefinitionid},{productprocessrel.Siteid}", productProcessRel4Update.Isusable);
			productProcessRel4Update.Isusable = "Usable";
			productprocessrel.CopyCommonFieldUpdatePrev(productProcessRel4Update, systemTime, dbContext.Tid, text);
			productprocessrel.CopyExtensionCollection(productProcessRel4Update);
			list.Add(productProcessRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteProductProcessRel(IDbContext dbContext, Productprocessrel[] productProcessRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productProcessRelList", productProcessRelList);
		string text = "RealDeleteProductProcessRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productprocessrel> list = new List<Productprocessrel>();
		foreach (Productprocessrel productprocessrel in productProcessRelList)
		{
			Productprocessrel productProcessRel4Update = GetProductProcessRel4Update(dbContext, productprocessrel.Productdefinitionid, productprocessrel.Processdefinitionid, productprocessrel.Siteid);
			if (productProcessRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Productprocessrel), $"{productprocessrel.Productdefinitionid},{productprocessrel.Processdefinitionid},{productprocessrel.Siteid}");
			}
			productprocessrel.CopyCommonFieldUpdatePrev(productProcessRel4Update, systemTime, dbContext.Tid, text);
			productprocessrel.CopyExtensionCollection(productProcessRel4Update);
			list.Add(productProcessRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static Productprocessrel SelectProductProcessRelDefault(IDbContext dbContext, string productDefinitionId, string siteId)
	{
		string apiName = "SelectProductProcessRelDefault";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productDefinitionId}.{siteId}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProductProcessRelDefaultSqlDatabase : _sqlSelectProductProcessRelDefaultOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", productDefinitionId, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		Productprocessrel? result = ContextManager.DirectEntityQuery<Productprocessrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productDefinitionId}.{siteId}");
		}
		return result;
	}
}
