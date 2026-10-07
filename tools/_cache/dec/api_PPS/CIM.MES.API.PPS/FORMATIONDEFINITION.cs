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
public class FORMATIONDEFINITION
{
	private static string _sqlGetFormationDefinitionSqlDatabase = "SELECT * FROM CIM_FORMATIONDEFINITION WHERE FORMATIONDEFINITIONID=@FORMATIONDEFINITIONID AND FORMATIONVERSION=@FORMATIONVERSION AND SITEID=@SITEID";

	private static string _sqlGetFormationDefinition4UpdateSqlDatabase = "SELECT * FROM CIM_FORMATIONDEFINITION WITH(UPDLOCK) WHERE FORMATIONDEFINITIONID=@FORMATIONDEFINITIONID AND FORMATIONVERSION=@FORMATIONVERSION AND SITEID=@SITEID";

	private static string _sqlSelectFormationDefinitionSqlDatabase = "SELECT * FROM CIM_FORMATIONDEFINITION WHERE FORMATIONDEFINITIONID=@FORMATIONDEFINITIONID AND FORMATIONVERSION=@FORMATIONVERSION AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectFormationDefinition4UpdateSqlDatabase = "SELECT * FROM CIM_FORMATIONDEFINITION WITH(UPDLOCK) WHERE FORMATIONDEFINITIONID=@FORMATIONDEFINITIONID AND FORMATIONVERSION=@FORMATIONVERSION AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetFormationDefinitionOracleDatabase = "SELECT * FROM CIM_FORMATIONDEFINITION WHERE FORMATIONDEFINITIONID=:FORMATIONDEFINITIONID AND FORMATIONVERSION=:FORMATIONVERSION AND SITEID=:SITEID";

	private static string _sqlGetFormationDefinition4UpdateOracleDatabase = "SELECT * FROM CIM_FORMATIONDEFINITION WHERE FORMATIONDEFINITIONID=:FORMATIONDEFINITIONID AND FORMATIONVERSION=:FORMATIONVERSION AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectFormationDefinitionOracleDatabase = "SELECT * FROM CIM_FORMATIONDEFINITION WHERE FORMATIONDEFINITIONID=:FORMATIONDEFINITIONID AND FORMATIONVERSION=:FORMATIONVERSION AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectFormationDefinition4UpdateOracleDatabase = "SELECT * FROM CIM_FORMATIONDEFINITION WHERE FORMATIONDEFINITIONID=:FORMATIONDEFINITIONID AND FORMATIONVERSION=:FORMATIONVERSION AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Formationdefinition);

	private static string _sqlSelectFormationDefinitionListSqlDatabase = "SELECT * FROM CIM_FORMATIONDEFINITION WHERE FORMATIONDEFINITIONID=@FORMATIONDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectFormationDefinitionListOracleDatabase = "SELECT * FROM CIM_FORMATIONDEFINITION WHERE FORMATIONDEFINITIONID=:FORMATIONDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	public static Formationdefinition GetFormationDefinition(IDbContext dbContext, string formationdefinitionid, string formationversion, string siteid)
	{
		string apiName = "GetFormationDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{formationdefinitionid},{formationversion},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetFormationDefinitionSqlDatabase : _sqlGetFormationDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("FORMATIONDEFINITIONID", formationdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("FORMATIONVERSION", formationversion, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_FORMATIONDEFINITION", $"{formationdefinitionid},{formationversion},{siteid}"));
		}
		Formationdefinition? result = ContextManager.DirectEntityQuery<Formationdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{formationdefinitionid},{formationversion},{siteid}");
		}
		return result;
	}

	public static Formationdefinition GetFormationDefinition4Update(IDbContext dbContext, string formationdefinitionid, string formationversion, string siteid)
	{
		string apiName = "GetFormationDefinition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{formationdefinitionid},{formationversion},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetFormationDefinition4UpdateSqlDatabase : _sqlGetFormationDefinition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("FORMATIONDEFINITIONID", formationdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("FORMATIONVERSION", formationversion, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_FORMATIONDEFINITION", $"{formationdefinitionid},{formationversion},{siteid}"));
		}
		Formationdefinition? result = ContextManager.DirectEntityQuery<Formationdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{formationdefinitionid},{formationversion},{siteid}");
		}
		return result;
	}

	public static Formationdefinition SelectFormationDefinition(IDbContext dbContext, string formationdefinitionid, string formationversion, string siteid)
	{
		string apiName = "SelectFormationDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{formationdefinitionid},{formationversion},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectFormationDefinitionSqlDatabase : _sqlSelectFormationDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("FORMATIONDEFINITIONID", formationdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("FORMATIONVERSION", formationversion, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_FORMATIONDEFINITION", $"{formationdefinitionid},{formationversion},{siteid}"));
		}
		Formationdefinition? result = ContextManager.DirectEntityQuery<Formationdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{formationdefinitionid},{formationversion},{siteid}");
		}
		return result;
	}

	public static Formationdefinition SelectFormationDefinition4Update(IDbContext dbContext, string formationdefinitionid, string formationversion, string siteid)
	{
		string apiName = "SelectFormationDefinition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{formationdefinitionid},{formationversion},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectFormationDefinition4UpdateSqlDatabase : _sqlSelectFormationDefinition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("FORMATIONDEFINITIONID", formationdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("FORMATIONVERSION", formationversion, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_FORMATIONDEFINITION", $"{formationdefinitionid},{formationversion},{siteid}"));
		}
		Formationdefinition? result = ContextManager.DirectEntityQuery<Formationdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{formationdefinitionid},{formationversion},{siteid}");
		}
		return result;
	}

	public static IList<Formationdefinition> SelectFormationDefinitionList(IDbContext dbContext, string formationdefinitionid, string siteid)
	{
		string apiName = "SelectFormationDefinitionList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{formationdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectFormationDefinitionListSqlDatabase : _sqlSelectFormationDefinitionListOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("FORMATIONDEFINITIONID", formationdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_FORMATIONDEFINITION", $"{formationdefinitionid},{siteid}"));
		}
		IList<Formationdefinition> result = ContextManager.DirectEntityQuery<Formationdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{formationdefinitionid},{siteid}");
		}
		return result;
	}

	public static int UpsertFormationDefinition(IDbContext dbContext, RequestType requestType, Formationdefinition[] FormationDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateFormationDefinitionInternal(dbContext, FormationDefinitionList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateFormationDefinition(dbContext, FormationDefinitionList, optionSet, saveHist), 
			RequestType.DELETE => DeleteFormationDefinition(dbContext, FormationDefinitionList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteFormationDefinition(dbContext, FormationDefinitionList, optionSet, saveHist), 
			_ => RealDeleteFormationDefinition(dbContext, FormationDefinitionList, optionSet, saveHist), 
		};
	}

	private static int CreateFormationDefinitionInternal(IDbContext dbContext, Formationdefinition[] FormationDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("FormationDefinitionList", FormationDefinitionList);
		string text = "CreateFormationDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Formationdefinition> list = new List<Formationdefinition>();
		foreach (Formationdefinition obj in FormationDefinitionList)
		{
			Formationdefinition formationdefinition = new Formationdefinition();
			obj.CopyColumsTo(formationdefinition);
			formationdefinition.Activity = text;
			formationdefinition.CheckEntityUsable();
			obj.CopyCommonField(formationdefinition, systemTime, dbContext.Tid, isCreate: true);
			list.Add(formationdefinition);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateFormationDefinition(IDbContext dbContext, Formationdefinition[] FormationDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("FormationDefinitionList", FormationDefinitionList);
		string text = "UpdateFormationDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Formationdefinition> list = new List<Formationdefinition>();
		foreach (Formationdefinition formationdefinition in FormationDefinitionList)
		{
			Formationdefinition formationDefinition4Update = GetFormationDefinition4Update(dbContext, formationdefinition.Formationdefinitionid, formationdefinition.Formationversion, formationdefinition.Siteid);
			if (formationDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Formationdefinition), $"{formationdefinition.Formationdefinitionid},{formationdefinition.Formationversion},{formationdefinition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Formationdefinition), $"{formationdefinition.Formationdefinitionid},{formationdefinition.Formationversion},{formationdefinition.Siteid}", formationDefinition4Update.Isusable);
			string activity = formationDefinition4Update.Activity;
			string customactivity = formationDefinition4Update.Customactivity;
			string isusable = formationDefinition4Update.Isusable;
			DateTime? createtime = formationDefinition4Update.Createtime;
			string creator = formationDefinition4Update.Creator;
			formationdefinition.CopyColumsTo(formationDefinition4Update);
			formationDefinition4Update.Prevactivity = activity;
			formationDefinition4Update.Prevcustomactivity = customactivity;
			formationDefinition4Update.Creator = creator;
			formationDefinition4Update.Createtime = createtime;
			formationDefinition4Update.Isusable = isusable;
			formationDefinition4Update.Activity = text;
			formationdefinition.CopyCommonField(formationDefinition4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(formationDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteFormationDefinition(IDbContext dbContext, Formationdefinition[] FormationDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("FormationDefinitionList", FormationDefinitionList);
		string text = "DeleteFormationDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Formationdefinition> list = new List<Formationdefinition>();
		foreach (Formationdefinition formationdefinition in FormationDefinitionList)
		{
			Formationdefinition formationDefinition4Update = GetFormationDefinition4Update(dbContext, formationdefinition.Formationdefinitionid, formationdefinition.Formationversion, formationdefinition.Siteid);
			if (formationDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Formationdefinition), $"{formationdefinition.Formationdefinitionid},{formationdefinition.Formationversion},{formationdefinition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Formationdefinition), $"{formationdefinition.Formationdefinitionid},{formationdefinition.Formationversion},{formationdefinition.Siteid}", formationDefinition4Update.Isusable);
			formationDefinition4Update.Isusable = "UnUsable";
			formationdefinition.CopyCommonFieldUpdatePrev(formationDefinition4Update, systemTime, dbContext.Tid, text);
			formationdefinition.CopyExtensionCollection(formationDefinition4Update);
			list.Add(formationDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteFormationDefinition(IDbContext dbContext, Formationdefinition[] FormationDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("FormationDefinitionList", FormationDefinitionList);
		string text = "UnDeleteFormationDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Formationdefinition> list = new List<Formationdefinition>();
		foreach (Formationdefinition formationdefinition in FormationDefinitionList)
		{
			Formationdefinition formationDefinition4Update = GetFormationDefinition4Update(dbContext, formationdefinition.Formationdefinitionid, formationdefinition.Formationversion, formationdefinition.Siteid);
			if (formationDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Formationdefinition), $"{formationdefinition.Formationdefinitionid},{formationdefinition.Formationversion},{formationdefinition.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Formationdefinition), $"{formationdefinition.Formationdefinitionid},{formationdefinition.Formationversion},{formationdefinition.Siteid}", formationDefinition4Update.Isusable);
			formationDefinition4Update.Isusable = "Usable";
			formationdefinition.CopyCommonFieldUpdatePrev(formationDefinition4Update, systemTime, dbContext.Tid, text);
			formationdefinition.CopyExtensionCollection(formationDefinition4Update);
			list.Add(formationDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteFormationDefinition(IDbContext dbContext, Formationdefinition[] FormationDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("FormationDefinitionList", FormationDefinitionList);
		string text = "RealDeleteFormationDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Formationdefinition> list = new List<Formationdefinition>();
		foreach (Formationdefinition formationdefinition in FormationDefinitionList)
		{
			Formationdefinition formationDefinition4Update = GetFormationDefinition4Update(dbContext, formationdefinition.Formationdefinitionid, formationdefinition.Formationversion, formationdefinition.Siteid);
			if (formationDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Formationdefinition), $"{formationdefinition.Formationdefinitionid},{formationdefinition.Formationversion},{formationdefinition.Siteid}");
			}
			formationdefinition.CopyCommonFieldUpdatePrev(formationDefinition4Update, systemTime, dbContext.Tid, text);
			formationdefinition.CopyExtensionCollection(formationDefinition4Update);
			list.Add(formationDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
