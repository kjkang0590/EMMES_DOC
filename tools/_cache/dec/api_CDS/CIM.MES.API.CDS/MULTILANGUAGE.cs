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
public class MULTILANGUAGE
{
	private static string _sqlGetMultiLanguageSqlDatabase = "SELECT * FROM CIM_MULTILANGUAGE WHERE LANGUAGECODEID=@LANGUAGECODEID AND CODETYPE=@CODETYPE AND LANGUAGE=@LANGUAGE AND SITEID=@SITEID";

	private static string _sqlGetMultiLanguage4UpdateSqlDatabase = "SELECT * FROM CIM_MULTILANGUAGE WITH(UPDLOCK) WHERE LANGUAGECODEID=@LANGUAGECODEID AND CODETYPE=@CODETYPE AND LANGUAGE=@LANGUAGE AND SITEID=@SITEID";

	private static string _sqlSelectMultiLanguageSqlDatabase = "SELECT * FROM CIM_MULTILANGUAGE WHERE LANGUAGECODEID=@LANGUAGECODEID AND CODETYPE=@CODETYPE AND LANGUAGE=@LANGUAGE AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMultiLanguage4UpdateSqlDatabase = "SELECT * FROM CIM_MULTILANGUAGE WITH(UPDLOCK) WHERE LANGUAGECODEID=@LANGUAGECODEID AND CODETYPE=@CODETYPE AND LANGUAGE=@LANGUAGE AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetMultiLanguageOracleDatabase = "SELECT * FROM CIM_MULTILANGUAGE WHERE LANGUAGECODEID=:LANGUAGECODEID AND CODETYPE=:CODETYPE AND LANGUAGE=:LANGUAGE AND SITEID=:SITEID";

	private static string _sqlGetMultiLanguage4UpdateOracleDatabase = "SELECT * FROM CIM_MULTILANGUAGE WHERE LANGUAGECODEID=:LANGUAGECODEID AND CODETYPE=:CODETYPE AND LANGUAGE=:LANGUAGE AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectMultiLanguageOracleDatabase = "SELECT * FROM CIM_MULTILANGUAGE WHERE LANGUAGECODEID=:LANGUAGECODEID AND CODETYPE=:CODETYPE AND LANGUAGE=:LANGUAGE AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMultiLanguage4UpdateOracleDatabase = "SELECT * FROM CIM_MULTILANGUAGE WHERE LANGUAGECODEID=:LANGUAGECODEID AND CODETYPE=:CODETYPE AND LANGUAGE=:LANGUAGE AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Multilanguage);

	private static string _sqlSelectMultiLanguageAllSqlDatabase = "SELECT * FROM CIM_MULTILANGUAGE WHERE CODETYPE=@CODETYPE AND LANGUAGE=@LANGUAGE AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMultiLanguageAllOracleDatabase = "SELECT * FROM CIM_MULTILANGUAGE WHERE CODETYPE=:CODETYPE AND LANGUAGE=:LANGUAGE AND SITEID=:SITEID AND ISUSABLE='Usable'";

	public static Multilanguage GetMultiLanguage(IDbContext dbContext, string languagecodeid, string codetype, string language, string siteid)
	{
		string apiName = "GetMultiLanguage";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{languagecodeid},{codetype},{language},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetMultiLanguageSqlDatabase : _sqlGetMultiLanguageOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LANGUAGECODEID", languagecodeid, typeOfThis));
		list.Add(dbContext.CreateParameter("CODETYPE", codetype, typeOfThis));
		list.Add(dbContext.CreateParameter("LANGUAGE", language, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MULTILANGUAGE", $"{languagecodeid},{codetype},{language},{siteid}"));
		}
		Multilanguage result = ContextManager.DirectEntityQuery<Multilanguage>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{languagecodeid},{codetype},{language},{siteid}");
		}
		return result;
	}

	public static Multilanguage GetMultiLanguage4Update(IDbContext dbContext, string languagecodeid, string codetype, string language, string siteid)
	{
		string apiName = "GetMultiLanguage4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{languagecodeid},{codetype},{language},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetMultiLanguage4UpdateSqlDatabase : _sqlGetMultiLanguage4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LANGUAGECODEID", languagecodeid, typeOfThis));
		list.Add(dbContext.CreateParameter("CODETYPE", codetype, typeOfThis));
		list.Add(dbContext.CreateParameter("LANGUAGE", language, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_MULTILANGUAGE", $"{languagecodeid},{codetype},{language},{siteid}"));
		}
		Multilanguage result = ContextManager.DirectEntityQuery<Multilanguage>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{languagecodeid},{codetype},{language},{siteid}");
		}
		return result;
	}

	public static Multilanguage SelectMultiLanguage(IDbContext dbContext, string languagecodeid, string codetype, string language, string siteid)
	{
		string apiName = "SelectMultiLanguage";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{languagecodeid},{codetype},{language},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMultiLanguageSqlDatabase : _sqlSelectMultiLanguageOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LANGUAGECODEID", languagecodeid, typeOfThis));
		list.Add(dbContext.CreateParameter("CODETYPE", codetype, typeOfThis));
		list.Add(dbContext.CreateParameter("LANGUAGE", language, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MULTILANGUAGE", $"{languagecodeid},{codetype},{language},{siteid}"));
		}
		Multilanguage result = ContextManager.DirectEntityQuery<Multilanguage>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{languagecodeid},{codetype},{language},{siteid}");
		}
		return result;
	}

	public static Multilanguage SelectMultiLanguage4Update(IDbContext dbContext, string languagecodeid, string codetype, string language, string siteid)
	{
		string apiName = "SelectMultiLanguage4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{languagecodeid},{codetype},{language},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMultiLanguage4UpdateSqlDatabase : _sqlSelectMultiLanguage4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LANGUAGECODEID", languagecodeid, typeOfThis));
		list.Add(dbContext.CreateParameter("CODETYPE", codetype, typeOfThis));
		list.Add(dbContext.CreateParameter("LANGUAGE", language, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_MULTILANGUAGE", $"{languagecodeid},{codetype},{language},{siteid}"));
		}
		Multilanguage result = ContextManager.DirectEntityQuery<Multilanguage>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{languagecodeid},{codetype},{language},{siteid}");
		}
		return result;
	}

	public static int UpsertMultiLanguage(IDbContext dbContext, RequestType requestType, Multilanguage[] multiLanguageList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateMultiLanguageInternal(dbContext, multiLanguageList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateMultiLanguage(dbContext, multiLanguageList, optionSet, saveHist), 
			RequestType.DELETE => DeleteMultiLanguage(dbContext, multiLanguageList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteMultiLanguage(dbContext, multiLanguageList, optionSet, saveHist), 
			_ => RealDeleteMultiLanguage(dbContext, multiLanguageList, optionSet, saveHist), 
		};
	}

	private static int CreateMultiLanguageInternal(IDbContext dbContext, Multilanguage[] multiLanguageList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("multiLanguageList", multiLanguageList);
		string text = "CreateMultiLanguage";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Multilanguage> list = new List<Multilanguage>();
		foreach (Multilanguage obj in multiLanguageList)
		{
			Multilanguage multilanguage = new Multilanguage();
			obj.CopyColumsTo(multilanguage);
			multilanguage.Activity = text;
			multilanguage.CheckEntityUsable();
			obj.CopyCommonField(multilanguage, systemTime, dbContext.Tid, isCreate: true);
			list.Add(multilanguage);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateMultiLanguage(IDbContext dbContext, Multilanguage[] multiLanguageList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("multiLanguageList", multiLanguageList);
		string text = "UpdateMultiLanguage";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Multilanguage> list = new List<Multilanguage>();
		foreach (Multilanguage multilanguage in multiLanguageList)
		{
			Multilanguage multiLanguage4Update = GetMultiLanguage4Update(dbContext, multilanguage.Languagecodeid, multilanguage.Codetype, multilanguage.Language, multilanguage.Siteid);
			if (multiLanguage4Update == null)
			{
				throw new EntityNotFoundException(typeof(Multilanguage), $"{multilanguage.Languagecodeid},{multilanguage.Codetype},{multilanguage.Language},{multilanguage.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Multilanguage), $"{multilanguage.Languagecodeid},{multilanguage.Codetype},{multilanguage.Language},{multilanguage.Siteid}", multiLanguage4Update.Isusable);
			string activity = multiLanguage4Update.Activity;
			string customactivity = multiLanguage4Update.Customactivity;
			string isusable = multiLanguage4Update.Isusable;
			DateTime? createtime = multiLanguage4Update.Createtime;
			string creator = multiLanguage4Update.Creator;
			multilanguage.CopyColumsTo(multiLanguage4Update);
			multiLanguage4Update.Prevactivity = activity;
			multiLanguage4Update.Prevcustomactivity = customactivity;
			multiLanguage4Update.Creator = creator;
			multiLanguage4Update.Createtime = createtime;
			multiLanguage4Update.Isusable = isusable;
			multiLanguage4Update.Activity = text;
			multilanguage.CopyCommonField(multiLanguage4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(multiLanguage4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteMultiLanguage(IDbContext dbContext, Multilanguage[] multiLanguageList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("multiLanguageList", multiLanguageList);
		string text = "DeleteMultiLanguage";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Multilanguage> list = new List<Multilanguage>();
		foreach (Multilanguage multilanguage in multiLanguageList)
		{
			Multilanguage multiLanguage4Update = GetMultiLanguage4Update(dbContext, multilanguage.Languagecodeid, multilanguage.Codetype, multilanguage.Language, multilanguage.Siteid);
			if (multiLanguage4Update == null)
			{
				throw new EntityNotFoundException(typeof(Multilanguage), $"{multilanguage.Languagecodeid},{multilanguage.Codetype},{multilanguage.Language},{multilanguage.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Multilanguage), $"{multilanguage.Languagecodeid},{multilanguage.Codetype},{multilanguage.Language},{multilanguage.Siteid}", multiLanguage4Update.Isusable);
			multiLanguage4Update.Isusable = "UnUsable";
			multilanguage.CopyCommonFieldUpdatePrev(multiLanguage4Update, systemTime, dbContext.Tid, text);
			multilanguage.CopyExtensionCollection(multiLanguage4Update);
			list.Add(multiLanguage4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteMultiLanguage(IDbContext dbContext, Multilanguage[] multiLanguageList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("multiLanguageList", multiLanguageList);
		string text = "UnDeleteMultiLanguage";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Multilanguage> list = new List<Multilanguage>();
		foreach (Multilanguage multilanguage in multiLanguageList)
		{
			Multilanguage multiLanguage4Update = GetMultiLanguage4Update(dbContext, multilanguage.Languagecodeid, multilanguage.Codetype, multilanguage.Language, multilanguage.Siteid);
			if (multiLanguage4Update == null)
			{
				throw new EntityNotFoundException(typeof(Multilanguage), $"{multilanguage.Languagecodeid},{multilanguage.Codetype},{multilanguage.Language},{multilanguage.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Multilanguage), $"{multilanguage.Languagecodeid},{multilanguage.Codetype},{multilanguage.Language},{multilanguage.Siteid}", multiLanguage4Update.Isusable);
			multiLanguage4Update.Isusable = "Usable";
			multilanguage.CopyCommonFieldUpdatePrev(multiLanguage4Update, systemTime, dbContext.Tid, text);
			multilanguage.CopyExtensionCollection(multiLanguage4Update);
			list.Add(multiLanguage4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteMultiLanguage(IDbContext dbContext, Multilanguage[] multiLanguageList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("multiLanguageList", multiLanguageList);
		string text = "RealDeleteMultiLanguage";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Multilanguage> list = new List<Multilanguage>();
		foreach (Multilanguage multilanguage in multiLanguageList)
		{
			Multilanguage multiLanguage4Update = GetMultiLanguage4Update(dbContext, multilanguage.Languagecodeid, multilanguage.Codetype, multilanguage.Language, multilanguage.Siteid);
			if (multiLanguage4Update == null)
			{
				throw new EntityNotFoundException(typeof(Multilanguage), $"{multilanguage.Languagecodeid},{multilanguage.Codetype},{multilanguage.Language},{multilanguage.Siteid}");
			}
			multilanguage.CopyCommonFieldUpdatePrev(multiLanguage4Update, systemTime, dbContext.Tid, text);
			multilanguage.CopyExtensionCollection(multiLanguage4Update);
			list.Add(multiLanguage4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static Multilanguage[] SelectMultiLanguageAll(IDbContext dbContext, string codetype, string language, string siteid)
	{
		string apiName = "SelectMultiLanguageAll";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{codetype},{language},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMultiLanguageAllSqlDatabase : _sqlSelectMultiLanguageAllOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CODETYPE", codetype, typeOfThis));
		list.Add(dbContext.CreateParameter("LANGUAGE", language, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MULTILANGUAGE", $"{codetype},{language},{siteid}"));
		}
		IList<Multilanguage> source = ContextManager.DirectEntityQuery<Multilanguage>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{codetype},{language},{siteid}");
		}
		return source.ToArray();
	}
}
