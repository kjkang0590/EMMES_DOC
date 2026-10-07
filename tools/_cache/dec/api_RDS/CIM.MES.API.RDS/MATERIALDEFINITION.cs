using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.RDS;

[MESAPI]
public class MATERIALDEFINITION
{
	private static string _sqlGetMaterialDefinitionSqlDatabase = "SELECT * FROM CIM_MATERIALDEFINITION WHERE MATERIALDEFINITIONID=@MATERIALDEFINITIONID AND SITEID=@SITEID";

	private static string _sqlGetMaterialDefinition4UpdateSqlDatabase = "SELECT * FROM CIM_MATERIALDEFINITION WITH(UPDLOCK) WHERE MATERIALDEFINITIONID=@MATERIALDEFINITIONID AND SITEID=@SITEID";

	private static string _sqlSelectMaterialDefinitionSqlDatabase = "SELECT * FROM CIM_MATERIALDEFINITION WHERE MATERIALDEFINITIONID=@MATERIALDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMaterialDefinition4UpdateSqlDatabase = "SELECT * FROM CIM_MATERIALDEFINITION WITH(UPDLOCK) WHERE MATERIALDEFINITIONID=@MATERIALDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetMaterialDefinitionOracleDatabase = "SELECT * FROM CIM_MATERIALDEFINITION WHERE MATERIALDEFINITIONID=:MATERIALDEFINITIONID AND SITEID=:SITEID";

	private static string _sqlGetMaterialDefinition4UpdateOracleDatabase = "SELECT * FROM CIM_MATERIALDEFINITION WHERE MATERIALDEFINITIONID=:MATERIALDEFINITIONID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectMaterialDefinitionOracleDatabase = "SELECT * FROM CIM_MATERIALDEFINITION WHERE MATERIALDEFINITIONID=:MATERIALDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMaterialDefinition4UpdateOracleDatabase = "SELECT * FROM CIM_MATERIALDEFINITION WHERE MATERIALDEFINITIONID=:MATERIALDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Materialdefinition);

	public static Materialdefinition GetMaterialDefinition(IDbContext dbContext, string materialdefinitionid, string siteid)
	{
		string apiName = "GetMaterialDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{materialdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetMaterialDefinitionSqlDatabase : _sqlGetMaterialDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MATERIALDEFINITIONID", materialdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MATERIALDEFINITION", $"{materialdefinitionid},{siteid}"));
		}
		Materialdefinition? result = ContextManager.DirectEntityQuery<Materialdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{materialdefinitionid},{siteid}");
		}
		return result;
	}

	public static Materialdefinition GetMaterialDefinition4Update(IDbContext dbContext, string materialdefinitionid, string siteid)
	{
		string apiName = "GetMaterialDefinition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{materialdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetMaterialDefinition4UpdateSqlDatabase : _sqlGetMaterialDefinition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MATERIALDEFINITIONID", materialdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_MATERIALDEFINITION", $"{materialdefinitionid},{siteid}"));
		}
		Materialdefinition? result = ContextManager.DirectEntityQuery<Materialdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{materialdefinitionid},{siteid}");
		}
		return result;
	}

	public static Materialdefinition SelectMaterialDefinition(IDbContext dbContext, string materialdefinitionid, string siteid)
	{
		string apiName = "SelectMaterialDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{materialdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMaterialDefinitionSqlDatabase : _sqlSelectMaterialDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MATERIALDEFINITIONID", materialdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MATERIALDEFINITION", $"{materialdefinitionid},{siteid}"));
		}
		Materialdefinition? result = ContextManager.DirectEntityQuery<Materialdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{materialdefinitionid},{siteid}");
		}
		return result;
	}

	public static Materialdefinition SelectMaterialDefinition4Update(IDbContext dbContext, string materialdefinitionid, string siteid)
	{
		string apiName = "SelectMaterialDefinition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{materialdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMaterialDefinition4UpdateSqlDatabase : _sqlSelectMaterialDefinition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MATERIALDEFINITIONID", materialdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_MATERIALDEFINITION", $"{materialdefinitionid},{siteid}"));
		}
		Materialdefinition? result = ContextManager.DirectEntityQuery<Materialdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{materialdefinitionid},{siteid}");
		}
		return result;
	}

	public static int UpsertMaterialDefinition(IDbContext dbContext, RequestType requestType, Materialdefinition[] materialDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateMaterialDefinitionInternal(dbContext, materialDefinitionList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateMaterialDefinition(dbContext, materialDefinitionList, optionSet, saveHist), 
			RequestType.DELETE => DeleteMaterialDefinition(dbContext, materialDefinitionList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteMaterialDefinition(dbContext, materialDefinitionList, optionSet, saveHist), 
			_ => RealDeleteMaterialDefinition(dbContext, materialDefinitionList, optionSet, saveHist), 
		};
	}

	private static int CreateMaterialDefinitionInternal(IDbContext dbContext, Materialdefinition[] materialDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialDefinitionList", materialDefinitionList);
		string text = "CreateMaterialDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materialdefinition> list = new List<Materialdefinition>();
		foreach (Materialdefinition obj in materialDefinitionList)
		{
			Materialdefinition materialdefinition = new Materialdefinition();
			obj.CopyColumsTo(materialdefinition);
			materialdefinition.Activity = text;
			materialdefinition.CheckEntityUsable();
			obj.CopyCommonField(materialdefinition, systemTime, dbContext.Tid, isCreate: true);
			list.Add(materialdefinition);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateMaterialDefinition(IDbContext dbContext, Materialdefinition[] materialDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialDefinitionList", materialDefinitionList);
		string text = "UpdateMaterialDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materialdefinition> list = new List<Materialdefinition>();
		foreach (Materialdefinition materialdefinition in materialDefinitionList)
		{
			Materialdefinition materialDefinition4Update = GetMaterialDefinition4Update(dbContext, materialdefinition.Materialdefinitionid, materialdefinition.Siteid);
			if (materialDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Materialdefinition), $"{materialdefinition.Materialdefinitionid},{materialdefinition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Materialdefinition), $"{materialdefinition.Materialdefinitionid},{materialdefinition.Siteid}", materialDefinition4Update.Isusable);
			string activity = materialDefinition4Update.Activity;
			string customactivity = materialDefinition4Update.Customactivity;
			string isusable = materialDefinition4Update.Isusable;
			DateTime? createtime = materialDefinition4Update.Createtime;
			string creator = materialDefinition4Update.Creator;
			materialdefinition.CopyColumsTo(materialDefinition4Update);
			materialDefinition4Update.Prevactivity = activity;
			materialDefinition4Update.Prevcustomactivity = customactivity;
			materialDefinition4Update.Creator = creator;
			materialDefinition4Update.Createtime = createtime;
			materialDefinition4Update.Isusable = isusable;
			materialDefinition4Update.Activity = text;
			materialdefinition.CopyCommonField(materialDefinition4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(materialDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteMaterialDefinition(IDbContext dbContext, Materialdefinition[] materialDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialDefinitionList", materialDefinitionList);
		string text = "DeleteMaterialDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materialdefinition> list = new List<Materialdefinition>();
		foreach (Materialdefinition materialdefinition in materialDefinitionList)
		{
			Materialdefinition materialDefinition4Update = GetMaterialDefinition4Update(dbContext, materialdefinition.Materialdefinitionid, materialdefinition.Siteid);
			if (materialDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Materialdefinition), $"{materialdefinition.Materialdefinitionid},{materialdefinition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Materialdefinition), $"{materialdefinition.Materialdefinitionid},{materialdefinition.Siteid}", materialDefinition4Update.Isusable);
			materialDefinition4Update.Isusable = "UnUsable";
			materialdefinition.CopyCommonFieldUpdatePrev(materialDefinition4Update, systemTime, dbContext.Tid, text);
			materialdefinition.CopyExtensionCollection(materialDefinition4Update);
			list.Add(materialDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteMaterialDefinition(IDbContext dbContext, Materialdefinition[] materialDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialDefinitionList", materialDefinitionList);
		string text = "UnDeleteMaterialDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materialdefinition> list = new List<Materialdefinition>();
		foreach (Materialdefinition materialdefinition in materialDefinitionList)
		{
			Materialdefinition materialDefinition4Update = GetMaterialDefinition4Update(dbContext, materialdefinition.Materialdefinitionid, materialdefinition.Siteid);
			if (materialDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Materialdefinition), $"{materialdefinition.Materialdefinitionid},{materialdefinition.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Materialdefinition), $"{materialdefinition.Materialdefinitionid},{materialdefinition.Siteid}", materialDefinition4Update.Isusable);
			materialDefinition4Update.Isusable = "Usable";
			materialdefinition.CopyCommonFieldUpdatePrev(materialDefinition4Update, systemTime, dbContext.Tid, text);
			materialdefinition.CopyExtensionCollection(materialDefinition4Update);
			list.Add(materialDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteMaterialDefinition(IDbContext dbContext, Materialdefinition[] materialDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialDefinitionList", materialDefinitionList);
		string text = "RealDeleteMaterialDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materialdefinition> list = new List<Materialdefinition>();
		foreach (Materialdefinition materialdefinition in materialDefinitionList)
		{
			Materialdefinition materialDefinition4Update = GetMaterialDefinition4Update(dbContext, materialdefinition.Materialdefinitionid, materialdefinition.Siteid);
			if (materialDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Materialdefinition), $"{materialdefinition.Materialdefinitionid},{materialdefinition.Siteid}");
			}
			materialdefinition.CopyCommonFieldUpdatePrev(materialDefinition4Update, systemTime, dbContext.Tid, text);
			materialdefinition.CopyExtensionCollection(materialDefinition4Update);
			list.Add(materialDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
