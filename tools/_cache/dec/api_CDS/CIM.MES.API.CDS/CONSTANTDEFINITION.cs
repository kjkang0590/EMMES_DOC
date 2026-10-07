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
public class CONSTANTDEFINITION
{
	private static string _sqlGetConstantDefinitionSqlDatabase = "SELECT * FROM CIM_CONSTANTDEFINITION WHERE CONSTANTID=@CONSTANTID AND PRODUCT=@PRODUCT AND SITEID=@SITEID";

	private static string _sqlGetConstantDefinition4UpdateSqlDatabase = "SELECT * FROM CIM_CONSTANTDEFINITION WITH(UPDLOCK) WHERE CONSTANTID=@CONSTANTID AND PRODUCT=@PRODUCT AND SITEID=@SITEID";

	private static string _sqlSelectConstantDefinitionSqlDatabase = "SELECT * FROM CIM_CONSTANTDEFINITION WHERE CONSTANTID=@CONSTANTID AND PRODUCT=@PRODUCT AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectConstantDefinition4UpdateSqlDatabase = "SELECT * FROM CIM_CONSTANTDEFINITION WITH(UPDLOCK) WHERE CONSTANTID=@CONSTANTID AND PRODUCT=@PRODUCT AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetConstantDefinitionOracleDatabase = "SELECT * FROM CIM_CONSTANTDEFINITION WHERE CONSTANTID=:CONSTANTID AND PRODUCT=@PRODUCT AND SITEID=:SITEID";

	private static string _sqlGetConstantDefinition4UpdateOracleDatabase = "SELECT * FROM CIM_CONSTANTDEFINITION WHERE CONSTANTID=:CONSTANTID AND PRODUCT=@PRODUCT AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectConstantDefinitionOracleDatabase = "SELECT * FROM CIM_CONSTANTDEFINITION WHERE CONSTANTID=:CONSTANTID AND PRODUCT=@PRODUCT AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectConstantDefinition4UpdateOracleDatabase = "SELECT * FROM CIM_CONSTANTDEFINITION WHERE CONSTANTID=:CONSTANTID AND PRODUCT=@PRODUCT AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Constantdefinition);

	private static string _sqlSelectConstantDefinitionListSqlDatabase = "SELECT * FROM CIM_CONSTANTDEFINITION WHERE PRODUCT=@PRODUCT AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectConstantDefinitionListOracleDatabase = "SELECT * FROM CIM_CONSTANTDEFINITION WHERE PRODUCT=:PRODUCT AND SITEID=:SITEID AND ISUSABLE='Usable'";

	public static Constantdefinition GetConstantDefinition(IDbContext dbContext, string constantid, string product, string siteid)
	{
		string apiName = "GetConstantDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{constantid},{product},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetConstantDefinitionSqlDatabase : _sqlGetConstantDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CONSTANTID", constantid, typeOfThis));
		list.Add(dbContext.CreateParameter("PRODUCT", product, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_CONSTANTDEFINITION", $"{constantid},{product},{siteid}"));
		}
		Constantdefinition? result = ContextManager.DirectEntityQuery<Constantdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{constantid},{product},{siteid}");
		}
		return result;
	}

	public static Constantdefinition GetConstantDefinition4Update(IDbContext dbContext, string constantid, string product, string siteid)
	{
		string apiName = "GetConstantDefinition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{constantid},{product},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetConstantDefinition4UpdateSqlDatabase : _sqlGetConstantDefinition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CONSTANTID", constantid, typeOfThis));
		list.Add(dbContext.CreateParameter("PRODUCT", product, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_CONSTANTDEFINITION", $"{constantid},{product},{siteid}"));
		}
		Constantdefinition? result = ContextManager.DirectEntityQuery<Constantdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{constantid},{product},{siteid}");
		}
		return result;
	}

	public static Constantdefinition SelectConstantDefinition(IDbContext dbContext, string constantid, string product, string siteid)
	{
		string apiName = "SelectConstantDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{constantid},{product},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectConstantDefinitionSqlDatabase : _sqlSelectConstantDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CONSTANTID", constantid, typeOfThis));
		list.Add(dbContext.CreateParameter("PRODUCT", product, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_CONSTANTDEFINITION", $"{constantid},{product},{siteid}"));
		}
		Constantdefinition? result = ContextManager.DirectEntityQuery<Constantdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{constantid},{product},{siteid}");
		}
		return result;
	}

	public static Constantdefinition SelectConstantDefinition4Update(IDbContext dbContext, string constantid, string product, string siteid)
	{
		string apiName = "SelectConstantDefinition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{constantid},{product},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectConstantDefinition4UpdateSqlDatabase : _sqlSelectConstantDefinition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CONSTANTID", constantid, typeOfThis));
		list.Add(dbContext.CreateParameter("PRODUCT", product, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_CONSTANTDEFINITION", $"{constantid},{product},{siteid}"));
		}
		Constantdefinition? result = ContextManager.DirectEntityQuery<Constantdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{constantid},{product},{siteid}");
		}
		return result;
	}

	public static Constantdefinition[] SelectConstantDefinitionList(IDbContext dbContext, string product, string siteid)
	{
		string apiName = "SelectConstantDefinitionList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{product},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectConstantDefinitionListSqlDatabase : _sqlSelectConstantDefinitionListOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCT", product, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_CONSTANTDEFINITION", $"{product},{siteid}"));
		}
		Constantdefinition[] result = ContextManager.DirectEntityQuery<Constantdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{product},{siteid}");
		}
		return result;
	}

	public static int UpsertConstantDefinition(IDbContext dbContext, RequestType requestType, Constantdefinition[] constantDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateConstantDefinitionInternal(dbContext, constantDefinitionList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateConstantDefinition(dbContext, constantDefinitionList, optionSet, saveHist), 
			RequestType.DELETE => DeleteConstantDefinition(dbContext, constantDefinitionList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteConstantDefinition(dbContext, constantDefinitionList, optionSet, saveHist), 
			_ => RealDeleteConstantDefinition(dbContext, constantDefinitionList, optionSet, saveHist), 
		};
	}

	private static int CreateConstantDefinitionInternal(IDbContext dbContext, Constantdefinition[] constantDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("constantDefinitionList", constantDefinitionList);
		string text = "CreateConstantDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Constantdefinition> list = new List<Constantdefinition>();
		foreach (Constantdefinition obj in constantDefinitionList)
		{
			Constantdefinition constantdefinition = new Constantdefinition();
			obj.CopyColumsTo(constantdefinition);
			constantdefinition.Activity = text;
			constantdefinition.CheckEntityUsable();
			obj.CopyCommonField(constantdefinition, systemTime, dbContext.Tid, isCreate: true);
			list.Add(constantdefinition);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateConstantDefinition(IDbContext dbContext, Constantdefinition[] constantDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("constantDefinitionList", constantDefinitionList);
		string text = "UpdateConstantDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Constantdefinition> list = new List<Constantdefinition>();
		foreach (Constantdefinition constantdefinition in constantDefinitionList)
		{
			Constantdefinition constantDefinition4Update = GetConstantDefinition4Update(dbContext, constantdefinition.Constantid, constantdefinition.Product, constantdefinition.Siteid);
			if (constantDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Constantdefinition), $"{constantdefinition.Constantid},{constantdefinition.Product},{constantdefinition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Constantdefinition), $"{constantdefinition.Constantid},{constantdefinition.Product},{constantdefinition.Siteid}", constantDefinition4Update.Isusable);
			string activity = constantDefinition4Update.Activity;
			string customactivity = constantDefinition4Update.Customactivity;
			string isusable = constantDefinition4Update.Isusable;
			DateTime? createtime = constantDefinition4Update.Createtime;
			string creator = constantDefinition4Update.Creator;
			constantdefinition.CopyColumsTo(constantDefinition4Update);
			constantDefinition4Update.Prevactivity = activity;
			constantDefinition4Update.Prevcustomactivity = customactivity;
			constantDefinition4Update.Creator = creator;
			constantDefinition4Update.Createtime = createtime;
			constantDefinition4Update.Isusable = isusable;
			constantDefinition4Update.Activity = text;
			constantdefinition.CopyCommonField(constantDefinition4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(constantDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteConstantDefinition(IDbContext dbContext, Constantdefinition[] constantDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("constantDefinitionList", constantDefinitionList);
		string text = "DeleteConstantDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Constantdefinition> list = new List<Constantdefinition>();
		foreach (Constantdefinition constantdefinition in constantDefinitionList)
		{
			Constantdefinition constantDefinition4Update = GetConstantDefinition4Update(dbContext, constantdefinition.Constantid, constantdefinition.Product, constantdefinition.Siteid);
			if (constantDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Constantdefinition), $"{constantdefinition.Constantid},{constantdefinition.Product},{constantdefinition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Constantdefinition), $"{constantdefinition.Constantid},{constantdefinition.Product},{constantdefinition.Siteid}", constantDefinition4Update.Isusable);
			constantDefinition4Update.Isusable = "UnUsable";
			constantdefinition.CopyCommonFieldUpdatePrev(constantDefinition4Update, systemTime, dbContext.Tid, text);
			constantdefinition.CopyExtensionCollection(constantDefinition4Update);
			list.Add(constantDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteConstantDefinition(IDbContext dbContext, Constantdefinition[] constantDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("constantDefinitionList", constantDefinitionList);
		string text = "UnDeleteConstantDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Constantdefinition> list = new List<Constantdefinition>();
		foreach (Constantdefinition constantdefinition in constantDefinitionList)
		{
			Constantdefinition constantDefinition4Update = GetConstantDefinition4Update(dbContext, constantdefinition.Constantid, constantdefinition.Product, constantdefinition.Siteid);
			if (constantDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Constantdefinition), $"{constantdefinition.Constantid},{constantdefinition.Product},{constantdefinition.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Constantdefinition), $"{constantdefinition.Constantid},{constantdefinition.Product},{constantdefinition.Siteid}", constantDefinition4Update.Isusable);
			constantDefinition4Update.Isusable = "Usable";
			constantdefinition.CopyCommonFieldUpdatePrev(constantDefinition4Update, systemTime, dbContext.Tid, text);
			constantdefinition.CopyExtensionCollection(constantDefinition4Update);
			list.Add(constantDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteConstantDefinition(IDbContext dbContext, Constantdefinition[] constantDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("constantDefinitionList", constantDefinitionList);
		string text = "RealDeleteConstantDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Constantdefinition> list = new List<Constantdefinition>();
		foreach (Constantdefinition constantdefinition in constantDefinitionList)
		{
			Constantdefinition constantDefinition4Update = GetConstantDefinition4Update(dbContext, constantdefinition.Constantid, constantdefinition.Product, constantdefinition.Siteid);
			if (constantDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Constantdefinition), $"{constantdefinition.Constantid},{constantdefinition.Product},{constantdefinition.Siteid}");
			}
			constantdefinition.CopyCommonFieldUpdatePrev(constantDefinition4Update, systemTime, dbContext.Tid, text);
			constantdefinition.CopyExtensionCollection(constantDefinition4Update);
			list.Add(constantDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
