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
public class PRODUCTDEFINITION
{
	private static string _sqlGetProductDefinitionSqlDatabase = "SELECT * FROM CIM_PRODUCTDEFINITION WHERE PRODUCTDEFINITIONID=@PRODUCTDEFINITIONID AND SITEID=@SITEID";

	private static string _sqlGetProductDefinition4UpdateSqlDatabase = "SELECT * FROM CIM_PRODUCTDEFINITION WITH(UPDLOCK) WHERE PRODUCTDEFINITIONID=@PRODUCTDEFINITIONID AND SITEID=@SITEID";

	private static string _sqlSelectProductDefinitionSqlDatabase = "SELECT * FROM CIM_PRODUCTDEFINITION WHERE PRODUCTDEFINITIONID=@PRODUCTDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProductDefinition4UpdateSqlDatabase = "SELECT * FROM CIM_PRODUCTDEFINITION WITH(UPDLOCK) WHERE PRODUCTDEFINITIONID=@PRODUCTDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetProductDefinitionOracleDatabase = "SELECT * FROM CIM_PRODUCTDEFINITION WHERE PRODUCTDEFINITIONID=:PRODUCTDEFINITIONID AND SITEID=:SITEID";

	private static string _sqlGetProductDefinition4UpdateOracleDatabase = "SELECT * FROM CIM_PRODUCTDEFINITION WHERE PRODUCTDEFINITIONID=:PRODUCTDEFINITIONID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectProductDefinitionOracleDatabase = "SELECT * FROM CIM_PRODUCTDEFINITION WHERE PRODUCTDEFINITIONID=:PRODUCTDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProductDefinition4UpdateOracleDatabase = "SELECT * FROM CIM_PRODUCTDEFINITION WHERE PRODUCTDEFINITIONID=:PRODUCTDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Productdefinition);

	public static Productdefinition GetProductDefinition(IDbContext dbContext, string productdefinitionid, string siteid)
	{
		string apiName = "GetProductDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProductDefinitionSqlDatabase : _sqlGetProductDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", productdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PRODUCTDEFINITION", $"{productdefinitionid},{siteid}"));
		}
		Productdefinition? result = ContextManager.DirectEntityQuery<Productdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productdefinitionid},{siteid}");
		}
		return result;
	}

	public static Productdefinition GetProductDefinition4Update(IDbContext dbContext, string productdefinitionid, string siteid)
	{
		string apiName = "GetProductDefinition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProductDefinition4UpdateSqlDatabase : _sqlGetProductDefinition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", productdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PRODUCTDEFINITION", $"{productdefinitionid},{siteid}"));
		}
		Productdefinition? result = ContextManager.DirectEntityQuery<Productdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productdefinitionid},{siteid}");
		}
		return result;
	}

	public static Productdefinition SelectProductDefinition(IDbContext dbContext, string productdefinitionid, string siteid)
	{
		string apiName = "SelectProductDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProductDefinitionSqlDatabase : _sqlSelectProductDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", productdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PRODUCTDEFINITION", $"{productdefinitionid},{siteid}"));
		}
		Productdefinition? result = ContextManager.DirectEntityQuery<Productdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productdefinitionid},{siteid}");
		}
		return result;
	}

	public static Productdefinition SelectProductDefinition4Update(IDbContext dbContext, string productdefinitionid, string siteid)
	{
		string apiName = "SelectProductDefinition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProductDefinition4UpdateSqlDatabase : _sqlSelectProductDefinition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", productdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PRODUCTDEFINITION", $"{productdefinitionid},{siteid}"));
		}
		Productdefinition? result = ContextManager.DirectEntityQuery<Productdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productdefinitionid},{siteid}");
		}
		return result;
	}

	public static int UpsertProductDefinition(IDbContext dbContext, RequestType requestType, Productdefinition[] productDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateProductDefinitionInternal(dbContext, productDefinitionList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateProductDefinition(dbContext, productDefinitionList, optionSet, saveHist), 
			RequestType.DELETE => DeleteProductDefinition(dbContext, productDefinitionList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteProductDefinition(dbContext, productDefinitionList, optionSet, saveHist), 
			_ => RealDeleteProductDefinition(dbContext, productDefinitionList, optionSet, saveHist), 
		};
	}

	private static int CreateProductDefinitionInternal(IDbContext dbContext, Productdefinition[] productDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productDefinitionList", productDefinitionList);
		string text = "CreateProductDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productdefinition> list = new List<Productdefinition>();
		foreach (Productdefinition obj in productDefinitionList)
		{
			Productdefinition productdefinition = new Productdefinition();
			obj.CopyColumsTo(productdefinition);
			productdefinition.Activity = text;
			productdefinition.CheckEntityUsable();
			obj.CopyCommonField(productdefinition, systemTime, dbContext.Tid, isCreate: true);
			list.Add(productdefinition);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateProductDefinition(IDbContext dbContext, Productdefinition[] productDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productDefinitionList", productDefinitionList);
		string text = "UpdateProductDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productdefinition> list = new List<Productdefinition>();
		foreach (Productdefinition productdefinition in productDefinitionList)
		{
			Productdefinition productDefinition4Update = GetProductDefinition4Update(dbContext, productdefinition.Productdefinitionid, productdefinition.Siteid);
			if (productDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Productdefinition), $"{productdefinition.Productdefinitionid},{productdefinition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Productdefinition), $"{productdefinition.Productdefinitionid},{productdefinition.Siteid}", productDefinition4Update.Isusable);
			string activity = productDefinition4Update.Activity;
			string customactivity = productDefinition4Update.Customactivity;
			string isusable = productDefinition4Update.Isusable;
			DateTime? createtime = productDefinition4Update.Createtime;
			string creator = productDefinition4Update.Creator;
			productdefinition.CopyColumsTo(productDefinition4Update);
			productDefinition4Update.Prevactivity = activity;
			productDefinition4Update.Prevcustomactivity = customactivity;
			productDefinition4Update.Creator = creator;
			productDefinition4Update.Createtime = createtime;
			productDefinition4Update.Isusable = isusable;
			productDefinition4Update.Activity = text;
			productdefinition.CopyCommonField(productDefinition4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(productDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteProductDefinition(IDbContext dbContext, Productdefinition[] productDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productDefinitionList", productDefinitionList);
		string text = "DeleteProductDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productdefinition> list = new List<Productdefinition>();
		foreach (Productdefinition productdefinition in productDefinitionList)
		{
			Productdefinition productDefinition4Update = GetProductDefinition4Update(dbContext, productdefinition.Productdefinitionid, productdefinition.Siteid);
			if (productDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Productdefinition), $"{productdefinition.Productdefinitionid},{productdefinition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Productdefinition), $"{productdefinition.Productdefinitionid},{productdefinition.Siteid}", productDefinition4Update.Isusable);
			productDefinition4Update.Isusable = "UnUsable";
			productdefinition.CopyCommonFieldUpdatePrev(productDefinition4Update, systemTime, dbContext.Tid, text);
			productdefinition.CopyExtensionCollection(productDefinition4Update);
			list.Add(productDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteProductDefinition(IDbContext dbContext, Productdefinition[] productDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productDefinitionList", productDefinitionList);
		string text = "UnDeleteProductDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productdefinition> list = new List<Productdefinition>();
		foreach (Productdefinition productdefinition in productDefinitionList)
		{
			Productdefinition productDefinition4Update = GetProductDefinition4Update(dbContext, productdefinition.Productdefinitionid, productdefinition.Siteid);
			if (productDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Productdefinition), $"{productdefinition.Productdefinitionid},{productdefinition.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Productdefinition), $"{productdefinition.Productdefinitionid},{productdefinition.Siteid}", productDefinition4Update.Isusable);
			productDefinition4Update.Isusable = "Usable";
			productdefinition.CopyCommonFieldUpdatePrev(productDefinition4Update, systemTime, dbContext.Tid, text);
			productdefinition.CopyExtensionCollection(productDefinition4Update);
			list.Add(productDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteProductDefinition(IDbContext dbContext, Productdefinition[] productDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productDefinitionList", productDefinitionList);
		string text = "RealDeleteProductDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productdefinition> list = new List<Productdefinition>();
		foreach (Productdefinition productdefinition in productDefinitionList)
		{
			Productdefinition productDefinition4Update = GetProductDefinition4Update(dbContext, productdefinition.Productdefinitionid, productdefinition.Siteid);
			if (productDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Productdefinition), $"{productdefinition.Productdefinitionid},{productdefinition.Siteid}");
			}
			productdefinition.CopyCommonFieldUpdatePrev(productDefinition4Update, systemTime, dbContext.Tid, text);
			productdefinition.CopyExtensionCollection(productDefinition4Update);
			list.Add(productDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
