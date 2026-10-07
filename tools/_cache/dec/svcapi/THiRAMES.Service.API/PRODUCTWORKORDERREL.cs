using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace THiRAMES.Service.API;

[MESAPI]
public class PRODUCTWORKORDERREL
{
	private static string _sqlGetProductworkorderrelSqlDatabase = "SELECT * FROM CUS_PRODUCTWORKORDERREL WHERE PRODUCTDEFINITIONID=@PRODUCTDEFINITIONID AND WORKORDERPRODUCTITEMID=@WORKORDERPRODUCTITEMID AND SITEID=@SITEID";

	private static string _sqlGetProductworkorderrel4UpdateSqlDatabase = "SELECT * FROM CUS_PRODUCTWORKORDERREL WITH(UPDLOCK) WHERE PRODUCTDEFINITIONID=@PRODUCTDEFINITIONID AND WORKORDERPRODUCTITEMID=@WORKORDERPRODUCTITEMID AND SITEID=@SITEID";

	private static string _sqlSelectProductworkorderrelSqlDatabase = "SELECT * FROM CUS_PRODUCTWORKORDERREL WHERE PRODUCTDEFINITIONID=@PRODUCTDEFINITIONID AND WORKORDERPRODUCTITEMID=@WORKORDERPRODUCTITEMID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProductworkorderrel4UpdateSqlDatabase = "SELECT * FROM CUS_PRODUCTWORKORDERREL WITH(UPDLOCK) WHERE PRODUCTDEFINITIONID=@PRODUCTDEFINITIONID AND WORKORDERPRODUCTITEMID=@WORKORDERPRODUCTITEMID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetProductworkorderrelOracleDatabase = "SELECT * FROM CUS_PRODUCTWORKORDERREL WHERE PRODUCTDEFINITIONID=:PRODUCTDEFINITIONID AND WORKORDERPRODUCTITEMID=:WORKORDERPRODUCTITEMID AND SITEID=:SITEID";

	private static string _sqlGetProductworkorderrel4UpdateOracleDatabase = "SELECT * FROM CUS_PRODUCTWORKORDERREL WHERE PRODUCTDEFINITIONID=:PRODUCTDEFINITIONID AND WORKORDERPRODUCTITEMID=:WORKORDERPRODUCTITEMID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectProductworkorderrelOracleDatabase = "SELECT * FROM CUS_PRODUCTWORKORDERREL WHERE PRODUCTDEFINITIONID=:PRODUCTDEFINITIONID AND WORKORDERPRODUCTITEMID=:WORKORDERPRODUCTITEMID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProductworkorderrel4UpdateOracleDatabase = "SELECT * FROM CUS_PRODUCTWORKORDERREL WHERE PRODUCTDEFINITIONID=:PRODUCTDEFINITIONID AND WORKORDERPRODUCTITEMID=:WORKORDERPRODUCTITEMID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Productworkorderrel);

	public static Productworkorderrel GetProductworkorderrel(IDbContext dbContext, string productdefinitionid, string workorderproductitemid, string siteid)
	{
		string apiName = "GetProductworkorderrel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productdefinitionid},{workorderproductitemid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProductworkorderrelSqlDatabase : _sqlGetProductworkorderrelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", productdefinitionid));
		list.Add(dbContext.CreateParameter("WORKORDERPRODUCTITEMID", workorderproductitemid));
		list.Add(dbContext.CreateParameter("SITEID", siteid));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CUS_PRODUCTWORKORDERREL", $"{productdefinitionid},{workorderproductitemid},{siteid}"));
		}
		Productworkorderrel result = ContextManager.DirectEntityQuery<Productworkorderrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productdefinitionid},{workorderproductitemid},{siteid}");
		}
		return result;
	}

	public static Productworkorderrel GetProductworkorderrel4Update(IDbContext dbContext, string productdefinitionid, string workorderproductitemid, string siteid)
	{
		string apiName = "GetProductworkorderrel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productdefinitionid},{workorderproductitemid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProductworkorderrel4UpdateSqlDatabase : _sqlGetProductworkorderrel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", productdefinitionid));
		list.Add(dbContext.CreateParameter("WORKORDERPRODUCTITEMID", workorderproductitemid));
		list.Add(dbContext.CreateParameter("SITEID", siteid));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CUS_PRODUCTWORKORDERREL", $"{productdefinitionid},{workorderproductitemid},{siteid}"));
		}
		Productworkorderrel result = ContextManager.DirectEntityQuery<Productworkorderrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productdefinitionid},{workorderproductitemid},{siteid}");
		}
		return result;
	}

	public static Productworkorderrel SelectProductworkorderrel(IDbContext dbContext, string productdefinitionid, string workorderproductitemid, string siteid)
	{
		string apiName = "SelectProductworkorderrel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productdefinitionid},{workorderproductitemid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProductworkorderrelSqlDatabase : _sqlSelectProductworkorderrelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", productdefinitionid));
		list.Add(dbContext.CreateParameter("WORKORDERPRODUCTITEMID", workorderproductitemid));
		list.Add(dbContext.CreateParameter("SITEID", siteid));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CUS_PRODUCTWORKORDERREL", $"{productdefinitionid},{workorderproductitemid},{siteid}"));
		}
		Productworkorderrel result = ContextManager.DirectEntityQuery<Productworkorderrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productdefinitionid},{workorderproductitemid},{siteid}");
		}
		return result;
	}

	public static Productworkorderrel SelectProductworkorderrel4Update(IDbContext dbContext, string productdefinitionid, string workorderproductitemid, string siteid)
	{
		string apiName = "SelectProductworkorderrel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productdefinitionid},{workorderproductitemid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProductworkorderrel4UpdateSqlDatabase : _sqlSelectProductworkorderrel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", productdefinitionid));
		list.Add(dbContext.CreateParameter("WORKORDERPRODUCTITEMID", workorderproductitemid));
		list.Add(dbContext.CreateParameter("SITEID", siteid));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CUS_PRODUCTWORKORDERREL", $"{productdefinitionid},{workorderproductitemid},{siteid}"));
		}
		Productworkorderrel result = ContextManager.DirectEntityQuery<Productworkorderrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productdefinitionid},{workorderproductitemid},{siteid}");
		}
		return result;
	}

	public static int UpsertProductworkorderrel(IDbContext dbContext, RequestType requestType, Productworkorderrel[] productworkorderrelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateProductworkorderrelInternal(dbContext, productworkorderrelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateProductworkorderrel(dbContext, productworkorderrelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteProductworkorderrel(dbContext, productworkorderrelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteProductworkorderrel(dbContext, productworkorderrelList, optionSet, saveHist), 
			_ => RealDeleteProductworkorderrel(dbContext, productworkorderrelList, optionSet, saveHist), 
		};
	}

	private static int CreateProductworkorderrelInternal(IDbContext dbContext, Productworkorderrel[] productworkorderrelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productworkorderrelList", productworkorderrelList);
		string text = "CreateProductworkorderrel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productworkorderrel> list = new List<Productworkorderrel>();
		foreach (Productworkorderrel productworkorderrel in productworkorderrelList)
		{
			Productworkorderrel productworkorderrel2 = new Productworkorderrel();
			productworkorderrel.CopyColumsTo(productworkorderrel2);
			productworkorderrel2.Activity = text;
			productworkorderrel2.CheckEntityUsable();
			productworkorderrel.CopyCommonField(productworkorderrel2, systemTime, dbContext.Tid, isCreate: true);
			list.Add(productworkorderrel2);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateProductworkorderrel(IDbContext dbContext, Productworkorderrel[] productworkorderrelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productworkorderrelList", productworkorderrelList);
		string text = "UpdateProductworkorderrel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productworkorderrel> list = new List<Productworkorderrel>();
		foreach (Productworkorderrel productworkorderrel in productworkorderrelList)
		{
			Productworkorderrel productworkorderrel4Update = GetProductworkorderrel4Update(dbContext, productworkorderrel.Productdefinitionid, productworkorderrel.Workorderproductitemid, productworkorderrel.Siteid);
			if (productworkorderrel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Productworkorderrel), $"{productworkorderrel.Productdefinitionid},{productworkorderrel.Workorderproductitemid},{productworkorderrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Productworkorderrel), $"{productworkorderrel.Productdefinitionid},{productworkorderrel.Workorderproductitemid},{productworkorderrel.Siteid}", productworkorderrel4Update.Isusable);
			string activity = productworkorderrel4Update.Activity;
			string customactivity = productworkorderrel4Update.Customactivity;
			string isusable = productworkorderrel4Update.Isusable;
			DateTime? createtime = productworkorderrel4Update.Createtime;
			string creator = productworkorderrel4Update.Creator;
			productworkorderrel.CopyColumsTo(productworkorderrel4Update);
			productworkorderrel4Update.Prevactivity = activity;
			productworkorderrel4Update.Prevcustomactivity = customactivity;
			productworkorderrel4Update.Creator = creator;
			productworkorderrel4Update.Createtime = createtime;
			productworkorderrel4Update.Isusable = isusable;
			productworkorderrel4Update.Activity = text;
			productworkorderrel.CopyCommonField(productworkorderrel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(productworkorderrel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteProductworkorderrel(IDbContext dbContext, Productworkorderrel[] productworkorderrelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productworkorderrelList", productworkorderrelList);
		string text = "DeleteProductworkorderrel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productworkorderrel> list = new List<Productworkorderrel>();
		foreach (Productworkorderrel productworkorderrel in productworkorderrelList)
		{
			Productworkorderrel productworkorderrel4Update = GetProductworkorderrel4Update(dbContext, productworkorderrel.Productdefinitionid, productworkorderrel.Workorderproductitemid, productworkorderrel.Siteid);
			if (productworkorderrel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Productworkorderrel), $"{productworkorderrel.Productdefinitionid},{productworkorderrel.Workorderproductitemid},{productworkorderrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Productworkorderrel), $"{productworkorderrel.Productdefinitionid},{productworkorderrel.Workorderproductitemid},{productworkorderrel.Siteid}", productworkorderrel4Update.Isusable);
			productworkorderrel4Update.Isusable = "UnUsable";
			productworkorderrel.CopyCommonFieldUpdatePrev(productworkorderrel4Update, systemTime, dbContext.Tid, text);
			productworkorderrel.CopyExtensionCollection(productworkorderrel4Update);
			list.Add(productworkorderrel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteProductworkorderrel(IDbContext dbContext, Productworkorderrel[] productworkorderrelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productworkorderrelList", productworkorderrelList);
		string text = "UnDeleteProductworkorderrel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productworkorderrel> list = new List<Productworkorderrel>();
		foreach (Productworkorderrel productworkorderrel in productworkorderrelList)
		{
			Productworkorderrel productworkorderrel4Update = GetProductworkorderrel4Update(dbContext, productworkorderrel.Productdefinitionid, productworkorderrel.Workorderproductitemid, productworkorderrel.Siteid);
			if (productworkorderrel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Productworkorderrel), $"{productworkorderrel.Productdefinitionid},{productworkorderrel.Workorderproductitemid},{productworkorderrel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Productworkorderrel), $"{productworkorderrel.Productdefinitionid},{productworkorderrel.Workorderproductitemid},{productworkorderrel.Siteid}", productworkorderrel4Update.Isusable);
			productworkorderrel4Update.Isusable = "Usable";
			productworkorderrel.CopyCommonFieldUpdatePrev(productworkorderrel4Update, systemTime, dbContext.Tid, text);
			productworkorderrel.CopyExtensionCollection(productworkorderrel4Update);
			list.Add(productworkorderrel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteProductworkorderrel(IDbContext dbContext, Productworkorderrel[] productworkorderrelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("productworkorderrelList", productworkorderrelList);
		string text = "RealDeleteProductworkorderrel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Productworkorderrel> list = new List<Productworkorderrel>();
		foreach (Productworkorderrel productworkorderrel in productworkorderrelList)
		{
			Productworkorderrel productworkorderrel4Update = GetProductworkorderrel4Update(dbContext, productworkorderrel.Productdefinitionid, productworkorderrel.Workorderproductitemid, productworkorderrel.Siteid);
			if (productworkorderrel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Productworkorderrel), $"{productworkorderrel.Productdefinitionid},{productworkorderrel.Workorderproductitemid},{productworkorderrel.Siteid}");
			}
			productworkorderrel.CopyCommonFieldUpdatePrev(productworkorderrel4Update, systemTime, dbContext.Tid, text);
			productworkorderrel.CopyExtensionCollection(productworkorderrel4Update);
			list.Add(productworkorderrel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
[Table("CUS_PRODUCTWORKORDERREL")]
public class Productworkorderrel : EntityTemplate
{
	public override string TableName => "CUS_PRODUCTWORKORDERREL";

	public override string GroupName => "CUS_PRODUCTWORKORDERREL";

	public override string TableType => "MAIN";

	[Key]
	[Column("PRODUCTDEFINITIONID")]
	[StringLength(40)]
	public string Productdefinitionid { get; set; }

	[Key]
	[Column("WORKORDERPRODUCTITEMID")]
	[StringLength(40)]
	public string Workorderproductitemid { get; set; }

	[Key]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Column("UISEQUENCE", TypeName = "numeric(4, 0)")]
	public int? Uisequence { get; set; }

	[Column("SCHEDULEUNIT")]
	[StringLength(40)]
	public string Scheduleunit { get; set; }
}
