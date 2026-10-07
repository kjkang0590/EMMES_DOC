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
public class HELPDICTIONARY
{
	private static string _sqlGetHelpDictionarySqlDatabase = "SELECT * FROM CIM_HELPDICTIONARY WHERE HELPDICTIONARYID=@HELPDICTIONARYID AND HELPDICTIONARYCLASSID=@HELPDICTIONARYCLASSID AND LANGUAGETYPE=@LANGUAGETYPE AND SITEID=@SITEID";

	private static string _sqlGetHelpDictionary4UpdateSqlDatabase = "SELECT * FROM CIM_HELPDICTIONARY WITH(UPDLOCK) WHERE HELPDICTIONARYID=@HELPDICTIONARYID AND HELPDICTIONARYCLASSID=@HELPDICTIONARYCLASSID AND LANGUAGETYPE=@LANGUAGETYPE AND SITEID=@SITEID";

	private static string _sqlSelectHelpDictionarySqlDatabase = "SELECT * FROM CIM_HELPDICTIONARY WHERE HELPDICTIONARYID=@HELPDICTIONARYID AND HELPDICTIONARYCLASSID=@HELPDICTIONARYCLASSID AND LANGUAGETYPE=@LANGUAGETYPE AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectHelpDictionary4UpdateSqlDatabase = "SELECT * FROM CIM_HELPDICTIONARY WITH(UPDLOCK) WHERE HELPDICTIONARYID=@HELPDICTIONARYID AND HELPDICTIONARYCLASSID=@HELPDICTIONARYCLASSID AND LANGUAGETYPE=@LANGUAGETYPE AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetHelpDictionaryOracleDatabase = "SELECT * FROM CIM_HELPDICTIONARY WHERE HELPDICTIONARYID=:HELPDICTIONARYID AND HELPDICTIONARYCLASSID=:HELPDICTIONARYCLASSID AND LANGUAGETYPE=:LANGUAGETYPE AND SITEID=:SITEID";

	private static string _sqlGetHelpDictionary4UpdateOracleDatabase = "SELECT * FROM CIM_HELPDICTIONARY WHERE HELPDICTIONARYID=:HELPDICTIONARYID AND HELPDICTIONARYCLASSID=:HELPDICTIONARYCLASSID AND LANGUAGETYPE=:LANGUAGETYPE AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectHelpDictionaryOracleDatabase = "SELECT * FROM CIM_HELPDICTIONARY WHERE HELPDICTIONARYID=:HELPDICTIONARYID AND HELPDICTIONARYCLASSID=:HELPDICTIONARYCLASSID AND LANGUAGETYPE=:LANGUAGETYPE AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectHelpDictionary4UpdateOracleDatabase = "SELECT * FROM CIM_HELPDICTIONARY WHERE HELPDICTIONARYID=:HELPDICTIONARYID AND HELPDICTIONARYCLASSID=:HELPDICTIONARYCLASSID AND LANGUAGETYPE=:LANGUAGETYPE AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Helpdictionary);

	public static Helpdictionary GetHelpDictionary(IDbContext dbContext, string helpdictionaryid, string helpdictionaryclassid, string languagetype, string siteid)
	{
		string apiName = "GetHelpDictionary";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{helpdictionaryid},{helpdictionaryclassid},{languagetype},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetHelpDictionarySqlDatabase : _sqlGetHelpDictionaryOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("HELPDICTIONARYID", helpdictionaryid, typeOfThis));
		list.Add(dbContext.CreateParameter("HELPDICTIONARYCLASSID", helpdictionaryclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("LANGUAGETYPE", languagetype, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_HELPDICTIONARY", $"{helpdictionaryid},{helpdictionaryclassid},{languagetype},{siteid}"));
		}
		Helpdictionary result = ContextManager.DirectEntityQuery<Helpdictionary>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{helpdictionaryid},{helpdictionaryclassid},{languagetype},{siteid}");
		}
		return result;
	}

	public static Helpdictionary GetHelpDictionary4Update(IDbContext dbContext, string helpdictionaryid, string helpdictionaryclassid, string languagetype, string siteid)
	{
		string apiName = "GetHelpDictionary4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{helpdictionaryid},{helpdictionaryclassid},{languagetype},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetHelpDictionary4UpdateSqlDatabase : _sqlGetHelpDictionary4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("HELPDICTIONARYID", helpdictionaryid, typeOfThis));
		list.Add(dbContext.CreateParameter("HELPDICTIONARYCLASSID", helpdictionaryclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("LANGUAGETYPE", languagetype, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_HELPDICTIONARY", $"{helpdictionaryid},{helpdictionaryclassid},{languagetype},{siteid}"));
		}
		Helpdictionary result = ContextManager.DirectEntityQuery<Helpdictionary>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{helpdictionaryid},{helpdictionaryclassid},{languagetype},{siteid}");
		}
		return result;
	}

	public static Helpdictionary SelectHelpDictionary(IDbContext dbContext, string helpdictionaryid, string helpdictionaryclassid, string languagetype, string siteid)
	{
		string apiName = "SelectHelpDictionary";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{helpdictionaryid},{helpdictionaryclassid},{languagetype},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectHelpDictionarySqlDatabase : _sqlSelectHelpDictionaryOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("HELPDICTIONARYID", helpdictionaryid, typeOfThis));
		list.Add(dbContext.CreateParameter("HELPDICTIONARYCLASSID", helpdictionaryclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("LANGUAGETYPE", languagetype, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_HELPDICTIONARY", $"{helpdictionaryid},{helpdictionaryclassid},{languagetype},{siteid}"));
		}
		Helpdictionary result = ContextManager.DirectEntityQuery<Helpdictionary>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{helpdictionaryid},{helpdictionaryclassid},{languagetype},{siteid}");
		}
		return result;
	}

	public static Helpdictionary SelectHelpDictionary4Update(IDbContext dbContext, string helpdictionaryid, string helpdictionaryclassid, string languagetype, string siteid)
	{
		string apiName = "SelectHelpDictionary4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{helpdictionaryid},{helpdictionaryclassid},{languagetype},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectHelpDictionary4UpdateSqlDatabase : _sqlSelectHelpDictionary4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("HELPDICTIONARYID", helpdictionaryid, typeOfThis));
		list.Add(dbContext.CreateParameter("HELPDICTIONARYCLASSID", helpdictionaryclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("LANGUAGETYPE", languagetype, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_HELPDICTIONARY", $"{helpdictionaryid},{helpdictionaryclassid},{languagetype},{siteid}"));
		}
		Helpdictionary result = ContextManager.DirectEntityQuery<Helpdictionary>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{helpdictionaryid},{helpdictionaryclassid},{languagetype},{siteid}");
		}
		return result;
	}

	public static int UpsertHelpDictionary(IDbContext dbContext, RequestType requestType, Helpdictionary[] helpDictionaryList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateHelpDictionaryInternal(dbContext, helpDictionaryList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateHelpDictionary(dbContext, helpDictionaryList, optionSet, saveHist), 
			RequestType.DELETE => DeleteHelpDictionary(dbContext, helpDictionaryList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteHelpDictionary(dbContext, helpDictionaryList, optionSet, saveHist), 
			_ => RealDeleteHelpDictionary(dbContext, helpDictionaryList, optionSet, saveHist), 
		};
	}

	private static int CreateHelpDictionaryInternal(IDbContext dbContext, Helpdictionary[] helpDictionaryList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("helpDictionaryList", helpDictionaryList);
		string text = "CreateHelpDictionary";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Helpdictionary> list = new List<Helpdictionary>();
		foreach (Helpdictionary obj in helpDictionaryList)
		{
			Helpdictionary helpdictionary = new Helpdictionary();
			obj.CopyColumsTo(helpdictionary);
			helpdictionary.Activity = text;
			helpdictionary.CheckEntityUsable();
			obj.CopyCommonField(helpdictionary, systemTime, dbContext.Tid, isCreate: true);
			list.Add(helpdictionary);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateHelpDictionary(IDbContext dbContext, Helpdictionary[] helpDictionaryList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("helpDictionaryList", helpDictionaryList);
		string text = "UpdateHelpDictionary";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Helpdictionary> list = new List<Helpdictionary>();
		foreach (Helpdictionary helpdictionary in helpDictionaryList)
		{
			Helpdictionary helpDictionary4Update = GetHelpDictionary4Update(dbContext, helpdictionary.Helpdictionaryid, helpdictionary.Helpdictionaryclassid, helpdictionary.Languagetype, helpdictionary.Siteid);
			if (helpDictionary4Update == null)
			{
				throw new EntityNotFoundException(typeof(Helpdictionary), $"{helpdictionary.Helpdictionaryid},{helpdictionary.Helpdictionaryclassid},{helpdictionary.Languagetype},{helpdictionary.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Helpdictionary), $"{helpdictionary.Helpdictionaryid},{helpdictionary.Helpdictionaryclassid},{helpdictionary.Languagetype},{helpdictionary.Siteid}", helpDictionary4Update.Isusable);
			string activity = helpDictionary4Update.Activity;
			string customactivity = helpDictionary4Update.Customactivity;
			string isusable = helpDictionary4Update.Isusable;
			DateTime? createtime = helpDictionary4Update.Createtime;
			string creator = helpDictionary4Update.Creator;
			helpdictionary.CopyColumsTo(helpDictionary4Update);
			helpDictionary4Update.Prevactivity = activity;
			helpDictionary4Update.Prevcustomactivity = customactivity;
			helpDictionary4Update.Creator = creator;
			helpDictionary4Update.Createtime = createtime;
			helpDictionary4Update.Isusable = isusable;
			helpDictionary4Update.Activity = text;
			helpdictionary.CopyCommonField(helpDictionary4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(helpDictionary4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteHelpDictionary(IDbContext dbContext, Helpdictionary[] helpDictionaryList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("helpDictionaryList", helpDictionaryList);
		string text = "DeleteHelpDictionary";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Helpdictionary> list = new List<Helpdictionary>();
		foreach (Helpdictionary helpdictionary in helpDictionaryList)
		{
			Helpdictionary helpDictionary4Update = GetHelpDictionary4Update(dbContext, helpdictionary.Helpdictionaryid, helpdictionary.Helpdictionaryclassid, helpdictionary.Languagetype, helpdictionary.Siteid);
			if (helpDictionary4Update == null)
			{
				throw new EntityNotFoundException(typeof(Helpdictionary), $"{helpdictionary.Helpdictionaryid},{helpdictionary.Helpdictionaryclassid},{helpdictionary.Languagetype},{helpdictionary.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Helpdictionary), $"{helpdictionary.Helpdictionaryid},{helpdictionary.Helpdictionaryclassid},{helpdictionary.Languagetype},{helpdictionary.Siteid}", helpDictionary4Update.Isusable);
			helpDictionary4Update.Isusable = "UnUsable";
			helpdictionary.CopyCommonFieldUpdatePrev(helpDictionary4Update, systemTime, dbContext.Tid, text);
			helpdictionary.CopyExtensionCollection(helpDictionary4Update);
			list.Add(helpDictionary4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteHelpDictionary(IDbContext dbContext, Helpdictionary[] helpDictionaryList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("helpDictionaryList", helpDictionaryList);
		string text = "UnDeleteHelpDictionary";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Helpdictionary> list = new List<Helpdictionary>();
		foreach (Helpdictionary helpdictionary in helpDictionaryList)
		{
			Helpdictionary helpDictionary4Update = GetHelpDictionary4Update(dbContext, helpdictionary.Helpdictionaryid, helpdictionary.Helpdictionaryclassid, helpdictionary.Languagetype, helpdictionary.Siteid);
			if (helpDictionary4Update == null)
			{
				throw new EntityNotFoundException(typeof(Helpdictionary), $"{helpdictionary.Helpdictionaryid},{helpdictionary.Helpdictionaryclassid},{helpdictionary.Languagetype},{helpdictionary.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Helpdictionary), $"{helpdictionary.Helpdictionaryid},{helpdictionary.Helpdictionaryclassid},{helpdictionary.Languagetype},{helpdictionary.Siteid}", helpDictionary4Update.Isusable);
			helpDictionary4Update.Isusable = "Usable";
			helpdictionary.CopyCommonFieldUpdatePrev(helpDictionary4Update, systemTime, dbContext.Tid, text);
			helpdictionary.CopyExtensionCollection(helpDictionary4Update);
			list.Add(helpDictionary4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteHelpDictionary(IDbContext dbContext, Helpdictionary[] helpDictionaryList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("helpDictionaryList", helpDictionaryList);
		string text = "RealDeleteHelpDictionary";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Helpdictionary> list = new List<Helpdictionary>();
		foreach (Helpdictionary helpdictionary in helpDictionaryList)
		{
			Helpdictionary helpDictionary4Update = GetHelpDictionary4Update(dbContext, helpdictionary.Helpdictionaryid, helpdictionary.Helpdictionaryclassid, helpdictionary.Languagetype, helpdictionary.Siteid);
			if (helpDictionary4Update == null)
			{
				throw new EntityNotFoundException(typeof(Helpdictionary), $"{helpdictionary.Helpdictionaryid},{helpdictionary.Helpdictionaryclassid},{helpdictionary.Languagetype},{helpdictionary.Siteid}");
			}
			helpdictionary.CopyCommonFieldUpdatePrev(helpDictionary4Update, systemTime, dbContext.Tid, text);
			helpdictionary.CopyExtensionCollection(helpDictionary4Update);
			list.Add(helpDictionary4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
