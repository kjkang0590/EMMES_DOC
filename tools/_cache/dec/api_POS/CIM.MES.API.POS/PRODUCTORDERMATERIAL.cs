using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.POS;

[MESAPI]
public class PRODUCTORDERMATERIAL
{
	private static string _sqlGetProductOrderMaterialSqlDatabase = "SELECT * FROM CIM_PRODUCTORDERMATERIAL WHERE PRODUCTORDERID=@PRODUCTORDERID AND PRODUCTITEMNO=@PRODUCTITEMNO AND SITEID=@SITEID";

	private static string _sqlGetProductOrderMaterial4UpdateSqlDatabase = "SELECT * FROM CIM_PRODUCTORDERMATERIAL WITH(UPDLOCK) WHERE PRODUCTORDERID=@PRODUCTORDERID AND PRODUCTITEMNO=@PRODUCTITEMNO AND SITEID=@SITEID";

	private static string _sqlSelectProductOrderMaterialSqlDatabase = "SELECT * FROM CIM_PRODUCTORDERMATERIAL WHERE PRODUCTORDERID=@PRODUCTORDERID AND PRODUCTITEMNO=@PRODUCTITEMNO AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProductOrderMaterial4UpdateSqlDatabase = "SELECT * FROM CIM_PRODUCTORDERMATERIAL WITH(UPDLOCK) WHERE PRODUCTORDERID=@PRODUCTORDERID AND PRODUCTITEMNO=@PRODUCTITEMNO AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetProductOrderMaterialOracleDatabase = "SELECT * FROM CIM_PRODUCTORDERMATERIAL WHERE PRODUCTORDERID=:PRODUCTORDERID AND PRODUCTITEMNO=:PRODUCTITEMNO AND SITEID=:SITEID";

	private static string _sqlGetProductOrderMaterial4UpdateOracleDatabase = "SELECT * FROM CIM_PRODUCTORDERMATERIAL WHERE PRODUCTORDERID=:PRODUCTORDERID AND PRODUCTITEMNO=:PRODUCTITEMNO AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectProductOrderMaterialOracleDatabase = "SELECT * FROM CIM_PRODUCTORDERMATERIAL WHERE PRODUCTORDERID=:PRODUCTORDERID AND PRODUCTITEMNO=:PRODUCTITEMNO AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProductOrderMaterial4UpdateOracleDatabase = "SELECT * FROM CIM_PRODUCTORDERMATERIAL WHERE PRODUCTORDERID=:PRODUCTORDERID AND PRODUCTITEMNO=:PRODUCTITEMNO AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Productordermaterial);

	public static Productordermaterial GetProductOrderMaterial(IDbContext dbContext, string productorderid, string productitemno, string siteid)
	{
		string apiName = "GetProductOrderMaterial";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productorderid},{productitemno},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProductOrderMaterialSqlDatabase : _sqlGetProductOrderMaterialOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTORDERID", productorderid, typeOfThis));
		list.Add(dbContext.CreateParameter("PRODUCTITEMNO", productitemno, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PRODUCTORDERMATERIAL", $"{productorderid},{productitemno},{siteid}"));
		}
		Productordermaterial? result = ContextManager.DirectEntityQuery<Productordermaterial>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productorderid},{productitemno},{siteid}");
		}
		return result;
	}

	public static Productordermaterial GetProductOrderMaterial4Update(IDbContext dbContext, string productorderid, string productitemno, string siteid)
	{
		string apiName = "GetProductOrderMaterial4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productorderid},{productitemno},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProductOrderMaterial4UpdateSqlDatabase : _sqlGetProductOrderMaterial4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTORDERID", productorderid, typeOfThis));
		list.Add(dbContext.CreateParameter("PRODUCTITEMNO", productitemno, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PRODUCTORDERMATERIAL", $"{productorderid},{productitemno},{siteid}"));
		}
		Productordermaterial? result = ContextManager.DirectEntityQuery<Productordermaterial>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productorderid},{productitemno},{siteid}");
		}
		return result;
	}

	public static Productordermaterial SelectProductOrderMaterial(IDbContext dbContext, string productorderid, string productitemno, string siteid)
	{
		string apiName = "SelectProductOrderMaterial";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productorderid},{productitemno},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProductOrderMaterialSqlDatabase : _sqlSelectProductOrderMaterialOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTORDERID", productorderid, typeOfThis));
		list.Add(dbContext.CreateParameter("PRODUCTITEMNO", productitemno, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PRODUCTORDERMATERIAL", $"{productorderid},{productitemno},{siteid}"));
		}
		Productordermaterial? result = ContextManager.DirectEntityQuery<Productordermaterial>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productorderid},{productitemno},{siteid}");
		}
		return result;
	}

	public static Productordermaterial SelectProductOrderMaterial4Update(IDbContext dbContext, string productorderid, string productitemno, string siteid)
	{
		string apiName = "SelectProductOrderMaterial4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productorderid},{productitemno},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProductOrderMaterial4UpdateSqlDatabase : _sqlSelectProductOrderMaterial4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTORDERID", productorderid, typeOfThis));
		list.Add(dbContext.CreateParameter("PRODUCTITEMNO", productitemno, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PRODUCTORDERMATERIAL", $"{productorderid},{productitemno},{siteid}"));
		}
		Productordermaterial? result = ContextManager.DirectEntityQuery<Productordermaterial>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productorderid},{productitemno},{siteid}");
		}
		return result;
	}

	public static int UpsertProductOrderMaterial(IDbContext dbContext, RequestType requestType, Productordermaterial[] productOrderMaterialList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateProductOrderMaterialInternal(dbContext, productOrderMaterialList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateProductOrderMaterial(dbContext, productOrderMaterialList, optionSet, saveHist), 
			RequestType.DELETE => DeleteProductOrderMaterial(dbContext, productOrderMaterialList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteProductOrderMaterial(dbContext, productOrderMaterialList, optionSet, saveHist), 
			_ => RealDeleteProductOrderMaterial(dbContext, productOrderMaterialList, optionSet, saveHist), 
		};
	}

	private static int CreateProductOrderMaterialInternal(IDbContext dbContext, Productordermaterial[] productOrderMaterialList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productOrderMaterialList", productOrderMaterialList);
		string text = "CreateProductOrderMaterial";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productordermaterial> list = new List<Productordermaterial>();
		foreach (Productordermaterial obj in productOrderMaterialList)
		{
			Productordermaterial productordermaterial = new Productordermaterial();
			obj.CopyColumsTo(productordermaterial);
			productordermaterial.Activity = text;
			productordermaterial.CheckEntityUsable();
			obj.CopyCommonField(productordermaterial, systemTime, dbContext.Tid, isCreate: true);
			list.Add(productordermaterial);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateProductOrderMaterial(IDbContext dbContext, Productordermaterial[] productOrderMaterialList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productOrderMaterialList", productOrderMaterialList);
		string text = "UpdateProductOrderMaterial";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productordermaterial> list = new List<Productordermaterial>();
		foreach (Productordermaterial productordermaterial in productOrderMaterialList)
		{
			Productordermaterial productOrderMaterial4Update = GetProductOrderMaterial4Update(dbContext, productordermaterial.Productorderid, productordermaterial.Productitemno, productordermaterial.Siteid);
			if (productOrderMaterial4Update == null)
			{
				throw new EntityNotFoundException(typeof(Productordermaterial), $"{productordermaterial.Productorderid},{productordermaterial.Productitemno},{productordermaterial.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Productordermaterial), $"{productordermaterial.Productorderid},{productordermaterial.Productitemno},{productordermaterial.Siteid}", productOrderMaterial4Update.Isusable);
			string activity = productOrderMaterial4Update.Activity;
			string customactivity = productOrderMaterial4Update.Customactivity;
			string isusable = productOrderMaterial4Update.Isusable;
			DateTime? createtime = productOrderMaterial4Update.Createtime;
			string creator = productOrderMaterial4Update.Creator;
			productordermaterial.CopyColumsTo(productOrderMaterial4Update);
			productOrderMaterial4Update.Prevactivity = activity;
			productOrderMaterial4Update.Prevcustomactivity = customactivity;
			productOrderMaterial4Update.Creator = creator;
			productOrderMaterial4Update.Createtime = createtime;
			productOrderMaterial4Update.Isusable = isusable;
			productOrderMaterial4Update.Activity = text;
			productordermaterial.CopyCommonField(productOrderMaterial4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(productOrderMaterial4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteProductOrderMaterial(IDbContext dbContext, Productordermaterial[] productOrderMaterialList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productOrderMaterialList", productOrderMaterialList);
		string text = "DeleteProductOrderMaterial";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productordermaterial> list = new List<Productordermaterial>();
		foreach (Productordermaterial productordermaterial in productOrderMaterialList)
		{
			Productordermaterial productOrderMaterial4Update = GetProductOrderMaterial4Update(dbContext, productordermaterial.Productorderid, productordermaterial.Productitemno, productordermaterial.Siteid);
			if (productOrderMaterial4Update == null)
			{
				throw new EntityNotFoundException(typeof(Productordermaterial), $"{productordermaterial.Productorderid},{productordermaterial.Productitemno},{productordermaterial.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Productordermaterial), $"{productordermaterial.Productorderid},{productordermaterial.Productitemno},{productordermaterial.Siteid}", productOrderMaterial4Update.Isusable);
			productOrderMaterial4Update.Isusable = "UnUsable";
			productordermaterial.CopyCommonFieldUpdatePrev(productOrderMaterial4Update, systemTime, dbContext.Tid, text);
			productordermaterial.CopyExtensionCollection(productOrderMaterial4Update);
			list.Add(productOrderMaterial4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteProductOrderMaterial(IDbContext dbContext, Productordermaterial[] productOrderMaterialList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productOrderMaterialList", productOrderMaterialList);
		string text = "UnDeleteProductOrderMaterial";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productordermaterial> list = new List<Productordermaterial>();
		foreach (Productordermaterial productordermaterial in productOrderMaterialList)
		{
			Productordermaterial productOrderMaterial4Update = GetProductOrderMaterial4Update(dbContext, productordermaterial.Productorderid, productordermaterial.Productitemno, productordermaterial.Siteid);
			if (productOrderMaterial4Update == null)
			{
				throw new EntityNotFoundException(typeof(Productordermaterial), $"{productordermaterial.Productorderid},{productordermaterial.Productitemno},{productordermaterial.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Productordermaterial), $"{productordermaterial.Productorderid},{productordermaterial.Productitemno},{productordermaterial.Siteid}", productOrderMaterial4Update.Isusable);
			productOrderMaterial4Update.Isusable = "Usable";
			productordermaterial.CopyCommonFieldUpdatePrev(productOrderMaterial4Update, systemTime, dbContext.Tid, text);
			productordermaterial.CopyExtensionCollection(productOrderMaterial4Update);
			list.Add(productOrderMaterial4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteProductOrderMaterial(IDbContext dbContext, Productordermaterial[] productOrderMaterialList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productOrderMaterialList", productOrderMaterialList);
		string text = "RealDeleteProductOrderMaterial";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productordermaterial> list = new List<Productordermaterial>();
		foreach (Productordermaterial productordermaterial in productOrderMaterialList)
		{
			Productordermaterial productOrderMaterial4Update = GetProductOrderMaterial4Update(dbContext, productordermaterial.Productorderid, productordermaterial.Productitemno, productordermaterial.Siteid);
			if (productOrderMaterial4Update == null)
			{
				throw new EntityNotFoundException(typeof(Productordermaterial), $"{productordermaterial.Productorderid},{productordermaterial.Productitemno},{productordermaterial.Siteid}");
			}
			productordermaterial.CopyCommonFieldUpdatePrev(productOrderMaterial4Update, systemTime, dbContext.Tid, text);
			productordermaterial.CopyExtensionCollection(productOrderMaterial4Update);
			list.Add(productOrderMaterial4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
