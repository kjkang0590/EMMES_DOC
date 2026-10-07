using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.QMS;

[MESAPI]
public class TROUBLEDEFINITION
{
	private static string _sqlGetTroubleDefinitionSqlDatabase = "SELECT * FROM CIM_TROUBLEDEFINITION WHERE TROUBLEDEFINITIONID=@TROUBLEDEFINITIONID AND SITEID=@SITEID";

	private static string _sqlGetTroubleDefinition4UpdateSqlDatabase = "SELECT * FROM CIM_TROUBLEDEFINITION WITH(UPDLOCK) WHERE TROUBLEDEFINITIONID=@TROUBLEDEFINITIONID AND SITEID=@SITEID";

	private static string _sqlSelectTroubleDefinitionSqlDatabase = "SELECT * FROM CIM_TROUBLEDEFINITION WHERE TROUBLEDEFINITIONID=@TROUBLEDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectTroubleDefinition4UpdateSqlDatabase = "SELECT * FROM CIM_TROUBLEDEFINITION WITH(UPDLOCK) WHERE TROUBLEDEFINITIONID=@TROUBLEDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetTroubleDefinitionOracleDatabase = "SELECT * FROM CIM_TROUBLEDEFINITION WHERE TROUBLEDEFINITIONID=:TROUBLEDEFINITIONID AND SITEID=:SITEID";

	private static string _sqlGetTroubleDefinition4UpdateOracleDatabase = "SELECT * FROM CIM_TROUBLEDEFINITION WHERE TROUBLEDEFINITIONID=:TROUBLEDEFINITIONID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectTroubleDefinitionOracleDatabase = "SELECT * FROM CIM_TROUBLEDEFINITION WHERE TROUBLEDEFINITIONID=:TROUBLEDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectTroubleDefinition4UpdateOracleDatabase = "SELECT * FROM CIM_TROUBLEDEFINITION WHERE TROUBLEDEFINITIONID=:TROUBLEDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Troubledefinition);

	public static Troubledefinition GetTroubleDefinition(IDbContext dbContext, string troubledefinitionid, string siteid)
	{
		string apiName = "GetTroubleDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{troubledefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetTroubleDefinitionSqlDatabase : _sqlGetTroubleDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TROUBLEDEFINITIONID", troubledefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_TROUBLEDEFINITION", $"{troubledefinitionid},{siteid}"));
		}
		Troubledefinition? result = ContextManager.DirectEntityQuery<Troubledefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{troubledefinitionid},{siteid}");
		}
		return result;
	}

	public static Troubledefinition GetTroubleDefinition4Update(IDbContext dbContext, string troubledefinitionid, string siteid)
	{
		string apiName = "GetTroubleDefinition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{troubledefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetTroubleDefinition4UpdateSqlDatabase : _sqlGetTroubleDefinition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TROUBLEDEFINITIONID", troubledefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_TROUBLEDEFINITION", $"{troubledefinitionid},{siteid}"));
		}
		Troubledefinition? result = ContextManager.DirectEntityQuery<Troubledefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{troubledefinitionid},{siteid}");
		}
		return result;
	}

	public static Troubledefinition SelectTroubleDefinition(IDbContext dbContext, string troubledefinitionid, string siteid)
	{
		string apiName = "SelectTroubleDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{troubledefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectTroubleDefinitionSqlDatabase : _sqlSelectTroubleDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TROUBLEDEFINITIONID", troubledefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_TROUBLEDEFINITION", $"{troubledefinitionid},{siteid}"));
		}
		Troubledefinition? result = ContextManager.DirectEntityQuery<Troubledefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{troubledefinitionid},{siteid}");
		}
		return result;
	}

	public static Troubledefinition SelectTroubleDefinition4Update(IDbContext dbContext, string troubledefinitionid, string siteid)
	{
		string apiName = "SelectTroubleDefinition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{troubledefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectTroubleDefinition4UpdateSqlDatabase : _sqlSelectTroubleDefinition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TROUBLEDEFINITIONID", troubledefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_TROUBLEDEFINITION", $"{troubledefinitionid},{siteid}"));
		}
		Troubledefinition? result = ContextManager.DirectEntityQuery<Troubledefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{troubledefinitionid},{siteid}");
		}
		return result;
	}

	public static int UpsertTroubleDefinition(IDbContext dbContext, RequestType requestType, Troubledefinition[] troubleDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateTroubleDefinitionInternal(dbContext, troubleDefinitionList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateTroubleDefinition(dbContext, troubleDefinitionList, optionSet, saveHist), 
			RequestType.DELETE => DeleteTroubleDefinition(dbContext, troubleDefinitionList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteTroubleDefinition(dbContext, troubleDefinitionList, optionSet, saveHist), 
			_ => RealDeleteTroubleDefinition(dbContext, troubleDefinitionList, optionSet, saveHist), 
		};
	}

	private static int CreateTroubleDefinitionInternal(IDbContext dbContext, Troubledefinition[] troubleDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("troubleDefinitionList", troubleDefinitionList);
		string text = "CreateTroubleDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Troubledefinition> list = new List<Troubledefinition>();
		foreach (Troubledefinition obj in troubleDefinitionList)
		{
			Troubledefinition troubledefinition = new Troubledefinition();
			obj.CopyColumsTo(troubledefinition);
			troubledefinition.Activity = text;
			troubledefinition.CheckEntityUsable();
			obj.CopyCommonField(troubledefinition, systemTime, dbContext.Tid, isCreate: true);
			list.Add(troubledefinition);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateTroubleDefinition(IDbContext dbContext, Troubledefinition[] troubleDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("troubleDefinitionList", troubleDefinitionList);
		string text = "UpdateTroubleDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Troubledefinition> list = new List<Troubledefinition>();
		foreach (Troubledefinition troubledefinition in troubleDefinitionList)
		{
			Troubledefinition troubleDefinition4Update = GetTroubleDefinition4Update(dbContext, troubledefinition.Troubledefinitionid, troubledefinition.Siteid);
			if (troubleDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Troubledefinition), $"{troubledefinition.Troubledefinitionid},{troubledefinition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Troubledefinition), $"{troubledefinition.Troubledefinitionid},{troubledefinition.Siteid}", troubleDefinition4Update.Isusable);
			string activity = troubleDefinition4Update.Activity;
			string customactivity = troubleDefinition4Update.Customactivity;
			string isusable = troubleDefinition4Update.Isusable;
			DateTime? createtime = troubleDefinition4Update.Createtime;
			string creator = troubleDefinition4Update.Creator;
			troubledefinition.CopyColumsTo(troubleDefinition4Update);
			troubleDefinition4Update.Prevactivity = activity;
			troubleDefinition4Update.Prevcustomactivity = customactivity;
			troubleDefinition4Update.Creator = creator;
			troubleDefinition4Update.Createtime = createtime;
			troubleDefinition4Update.Isusable = isusable;
			troubleDefinition4Update.Activity = text;
			troubledefinition.CopyCommonField(troubleDefinition4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(troubleDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteTroubleDefinition(IDbContext dbContext, Troubledefinition[] troubleDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("troubleDefinitionList", troubleDefinitionList);
		string text = "DeleteTroubleDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Troubledefinition> list = new List<Troubledefinition>();
		foreach (Troubledefinition troubledefinition in troubleDefinitionList)
		{
			Troubledefinition troubleDefinition4Update = GetTroubleDefinition4Update(dbContext, troubledefinition.Troubledefinitionid, troubledefinition.Siteid);
			if (troubleDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Troubledefinition), $"{troubledefinition.Troubledefinitionid},{troubledefinition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Troubledefinition), $"{troubledefinition.Troubledefinitionid},{troubledefinition.Siteid}", troubleDefinition4Update.Isusable);
			troubleDefinition4Update.Isusable = "UnUsable";
			troubledefinition.CopyCommonFieldUpdatePrev(troubleDefinition4Update, systemTime, dbContext.Tid, text);
			troubledefinition.CopyExtensionCollection(troubleDefinition4Update);
			list.Add(troubleDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteTroubleDefinition(IDbContext dbContext, Troubledefinition[] troubleDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("troubleDefinitionList", troubleDefinitionList);
		string text = "UnDeleteTroubleDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Troubledefinition> list = new List<Troubledefinition>();
		foreach (Troubledefinition troubledefinition in troubleDefinitionList)
		{
			Troubledefinition troubleDefinition4Update = GetTroubleDefinition4Update(dbContext, troubledefinition.Troubledefinitionid, troubledefinition.Siteid);
			if (troubleDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Troubledefinition), $"{troubledefinition.Troubledefinitionid},{troubledefinition.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Troubledefinition), $"{troubledefinition.Troubledefinitionid},{troubledefinition.Siteid}", troubleDefinition4Update.Isusable);
			troubleDefinition4Update.Isusable = "Usable";
			troubledefinition.CopyCommonFieldUpdatePrev(troubleDefinition4Update, systemTime, dbContext.Tid, text);
			troubledefinition.CopyExtensionCollection(troubleDefinition4Update);
			list.Add(troubleDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteTroubleDefinition(IDbContext dbContext, Troubledefinition[] troubleDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("troubleDefinitionList", troubleDefinitionList);
		string text = "RealDeleteTroubleDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Troubledefinition> list = new List<Troubledefinition>();
		foreach (Troubledefinition troubledefinition in troubleDefinitionList)
		{
			Troubledefinition troubleDefinition4Update = GetTroubleDefinition4Update(dbContext, troubledefinition.Troubledefinitionid, troubledefinition.Siteid);
			if (troubleDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Troubledefinition), $"{troubledefinition.Troubledefinitionid},{troubledefinition.Siteid}");
			}
			troubledefinition.CopyCommonFieldUpdatePrev(troubleDefinition4Update, systemTime, dbContext.Tid, text);
			troubledefinition.CopyExtensionCollection(troubleDefinition4Update);
			list.Add(troubleDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
