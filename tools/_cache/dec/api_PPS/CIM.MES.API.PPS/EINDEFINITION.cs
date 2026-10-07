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
public class EINDEFINITION
{
	private static string _sqlGetEinDefinitionSqlDatabase = "SELECT * FROM CIM_EINDEFINITION WHERE PRODUCTRULESYSID=@PRODUCTRULESYSID AND LANGUAGETYPE=@LANGUAGETYPE AND SITEID=@SITEID";

	private static string _sqlGetEinDefinition4UpdateSqlDatabase = "SELECT * FROM CIM_EINDEFINITION WITH(UPDLOCK) WHERE PRODUCTRULESYSID=@PRODUCTRULESYSID AND LANGUAGETYPE=@LANGUAGETYPE AND SITEID=@SITEID";

	private static string _sqlSelectEinDefinitionSqlDatabase = "SELECT * FROM CIM_EINDEFINITION WHERE PRODUCTRULESYSID=@PRODUCTRULESYSID AND LANGUAGETYPE=@LANGUAGETYPE AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectEinDefinition4UpdateSqlDatabase = "SELECT * FROM CIM_EINDEFINITION WITH(UPDLOCK) WHERE PRODUCTRULESYSID=@PRODUCTRULESYSID AND LANGUAGETYPE=@LANGUAGETYPE AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetEinDefinitionOracleDatabase = "SELECT * FROM CIM_EINDEFINITION WHERE PRODUCTRULESYSID=:PRODUCTRULESYSID AND LANGUAGETYPE=:LANGUAGETYPE AND SITEID=:SITEID";

	private static string _sqlGetEinDefinition4UpdateOracleDatabase = "SELECT * FROM CIM_EINDEFINITION WHERE PRODUCTRULESYSID=:PRODUCTRULESYSID AND LANGUAGETYPE=:LANGUAGETYPE AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectEinDefinitionOracleDatabase = "SELECT * FROM CIM_EINDEFINITION WHERE PRODUCTRULESYSID=:PRODUCTRULESYSID AND LANGUAGETYPE=:LANGUAGETYPE AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectEinDefinition4UpdateOracleDatabase = "SELECT * FROM CIM_EINDEFINITION WHERE PRODUCTRULESYSID=:PRODUCTRULESYSID AND LANGUAGETYPE=:LANGUAGETYPE AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Eindefinition);

	public static Eindefinition GetEinDefinition(IDbContext dbContext, string productrulesysid, string languagetype, string siteid)
	{
		string apiName = "GetEinDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productrulesysid},{languagetype},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetEinDefinitionSqlDatabase : _sqlGetEinDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTRULESYSID", productrulesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("LANGUAGETYPE", languagetype, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_EINDEFINITION", $"{productrulesysid},{languagetype},{siteid}"));
		}
		Eindefinition? result = ContextManager.DirectEntityQuery<Eindefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productrulesysid},{languagetype},{siteid}");
		}
		return result;
	}

	public static Eindefinition GetEinDefinition4Update(IDbContext dbContext, string productrulesysid, string languagetype, string siteid)
	{
		string apiName = "GetEinDefinition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productrulesysid},{languagetype},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetEinDefinition4UpdateSqlDatabase : _sqlGetEinDefinition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTRULESYSID", productrulesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("LANGUAGETYPE", languagetype, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_EINDEFINITION", $"{productrulesysid},{languagetype},{siteid}"));
		}
		Eindefinition? result = ContextManager.DirectEntityQuery<Eindefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productrulesysid},{languagetype},{siteid}");
		}
		return result;
	}

	public static Eindefinition SelectEinDefinition(IDbContext dbContext, string productrulesysid, string languagetype, string siteid)
	{
		string apiName = "SelectEinDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productrulesysid},{languagetype},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectEinDefinitionSqlDatabase : _sqlSelectEinDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTRULESYSID", productrulesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("LANGUAGETYPE", languagetype, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_EINDEFINITION", $"{productrulesysid},{languagetype},{siteid}"));
		}
		Eindefinition? result = ContextManager.DirectEntityQuery<Eindefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productrulesysid},{languagetype},{siteid}");
		}
		return result;
	}

	public static Eindefinition SelectEinDefinition4Update(IDbContext dbContext, string productrulesysid, string languagetype, string siteid)
	{
		string apiName = "SelectEinDefinition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productrulesysid},{languagetype},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectEinDefinition4UpdateSqlDatabase : _sqlSelectEinDefinition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTRULESYSID", productrulesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("LANGUAGETYPE", languagetype, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_EINDEFINITION", $"{productrulesysid},{languagetype},{siteid}"));
		}
		Eindefinition? result = ContextManager.DirectEntityQuery<Eindefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productrulesysid},{languagetype},{siteid}");
		}
		return result;
	}

	public static int UpsertEinDefinition(IDbContext dbContext, RequestType requestType, Eindefinition[] einDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateEinDefinitionInternal(dbContext, einDefinitionList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateEinDefinition(dbContext, einDefinitionList, optionSet, saveHist), 
			RequestType.DELETE => DeleteEinDefinition(dbContext, einDefinitionList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteEinDefinition(dbContext, einDefinitionList, optionSet, saveHist), 
			_ => RealDeleteEinDefinition(dbContext, einDefinitionList, optionSet, saveHist), 
		};
	}

	private static int CreateEinDefinitionInternal(IDbContext dbContext, Eindefinition[] einDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("einDefinitionList", einDefinitionList);
		string text = "CreateEinDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Eindefinition> list = new List<Eindefinition>();
		foreach (Eindefinition obj in einDefinitionList)
		{
			Eindefinition eindefinition = new Eindefinition();
			obj.CopyColumsTo(eindefinition);
			eindefinition.Activity = text;
			eindefinition.CheckEntityUsable();
			obj.CopyCommonField(eindefinition, systemTime, dbContext.Tid, isCreate: true);
			list.Add(eindefinition);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateEinDefinition(IDbContext dbContext, Eindefinition[] einDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("einDefinitionList", einDefinitionList);
		string text = "UpdateEinDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Eindefinition> list = new List<Eindefinition>();
		foreach (Eindefinition eindefinition in einDefinitionList)
		{
			Eindefinition einDefinition4Update = GetEinDefinition4Update(dbContext, eindefinition.Productrulesysid, eindefinition.Languagetype, eindefinition.Siteid);
			if (einDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Eindefinition), $"{eindefinition.Productrulesysid},{eindefinition.Languagetype},{eindefinition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Eindefinition), $"{eindefinition.Productrulesysid},{eindefinition.Languagetype},{eindefinition.Siteid}", einDefinition4Update.Isusable);
			string activity = einDefinition4Update.Activity;
			string customactivity = einDefinition4Update.Customactivity;
			string isusable = einDefinition4Update.Isusable;
			DateTime? createtime = einDefinition4Update.Createtime;
			string creator = einDefinition4Update.Creator;
			eindefinition.CopyColumsTo(einDefinition4Update);
			einDefinition4Update.Prevactivity = activity;
			einDefinition4Update.Prevcustomactivity = customactivity;
			einDefinition4Update.Creator = creator;
			einDefinition4Update.Createtime = createtime;
			einDefinition4Update.Isusable = isusable;
			einDefinition4Update.Activity = text;
			eindefinition.CopyCommonField(einDefinition4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(einDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteEinDefinition(IDbContext dbContext, Eindefinition[] einDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("einDefinitionList", einDefinitionList);
		string text = "DeleteEinDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Eindefinition> list = new List<Eindefinition>();
		foreach (Eindefinition eindefinition in einDefinitionList)
		{
			Eindefinition einDefinition4Update = GetEinDefinition4Update(dbContext, eindefinition.Productrulesysid, eindefinition.Languagetype, eindefinition.Siteid);
			if (einDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Eindefinition), $"{eindefinition.Productrulesysid},{eindefinition.Languagetype},{eindefinition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Eindefinition), $"{eindefinition.Productrulesysid},{eindefinition.Languagetype},{eindefinition.Siteid}", einDefinition4Update.Isusable);
			einDefinition4Update.Isusable = "UnUsable";
			eindefinition.CopyCommonFieldUpdatePrev(einDefinition4Update, systemTime, dbContext.Tid, text);
			eindefinition.CopyExtensionCollection(einDefinition4Update);
			list.Add(einDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteEinDefinition(IDbContext dbContext, Eindefinition[] einDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("einDefinitionList", einDefinitionList);
		string text = "UnDeleteEinDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Eindefinition> list = new List<Eindefinition>();
		foreach (Eindefinition eindefinition in einDefinitionList)
		{
			Eindefinition einDefinition4Update = GetEinDefinition4Update(dbContext, eindefinition.Productrulesysid, eindefinition.Languagetype, eindefinition.Siteid);
			if (einDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Eindefinition), $"{eindefinition.Productrulesysid},{eindefinition.Languagetype},{eindefinition.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Eindefinition), $"{eindefinition.Productrulesysid},{eindefinition.Languagetype},{eindefinition.Siteid}", einDefinition4Update.Isusable);
			einDefinition4Update.Isusable = "Usable";
			eindefinition.CopyCommonFieldUpdatePrev(einDefinition4Update, systemTime, dbContext.Tid, text);
			eindefinition.CopyExtensionCollection(einDefinition4Update);
			list.Add(einDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteEinDefinition(IDbContext dbContext, Eindefinition[] einDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("einDefinitionList", einDefinitionList);
		string text = "RealDeleteEinDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Eindefinition> list = new List<Eindefinition>();
		foreach (Eindefinition eindefinition in einDefinitionList)
		{
			Eindefinition einDefinition4Update = GetEinDefinition4Update(dbContext, eindefinition.Productrulesysid, eindefinition.Languagetype, eindefinition.Siteid);
			if (einDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Eindefinition), $"{eindefinition.Productrulesysid},{eindefinition.Languagetype},{eindefinition.Siteid}");
			}
			eindefinition.CopyCommonFieldUpdatePrev(einDefinition4Update, systemTime, dbContext.Tid, text);
			eindefinition.CopyExtensionCollection(einDefinition4Update);
			list.Add(einDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
