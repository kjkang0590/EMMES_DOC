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
public class MESSAGESETDICTIONARY
{
	private static string _sqlGetMessageSetDictionarySqlDatabase = "SELECT * FROM CIM_MESSAGESETDICTIONARY WHERE SERVICENAME=@SERVICENAME AND BIZNAME=@BIZNAME AND SETNAME=@SETNAME AND PARAMETERNAME=@PARAMETERNAME AND SITEID=@SITEID";

	private static string _sqlGetMessageSetDictionary4UpdateSqlDatabase = "SELECT * FROM CIM_MESSAGESETDICTIONARY WITH(UPDLOCK) WHERE SERVICENAME=@SERVICENAME AND BIZNAME=@BIZNAME AND SETNAME=@SETNAME AND PARAMETERNAME=@PARAMETERNAME AND SITEID=@SITEID";

	private static string _sqlSelectMessageSetDictionarySqlDatabase = "SELECT * FROM CIM_MESSAGESETDICTIONARY WHERE SERVICENAME=@SERVICENAME AND BIZNAME=@BIZNAME AND SETNAME=@SETNAME AND PARAMETERNAME=@PARAMETERNAME AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMessageSetDictionary4UpdateSqlDatabase = "SELECT * FROM CIM_MESSAGESETDICTIONARY WITH(UPDLOCK) WHERE SERVICENAME=@SERVICENAME AND BIZNAME=@BIZNAME AND SETNAME=@SETNAME AND PARAMETERNAME=@PARAMETERNAME AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetMessageSetDictionaryOracleDatabase = "SELECT * FROM CIM_MESSAGESETDICTIONARY WHERE SERVICENAME=:SERVICENAME AND BIZNAME=:BIZNAME AND SETNAME=:SETNAME AND PARAMETERNAME=:PARAMETERNAME AND SITEID=:SITEID";

	private static string _sqlGetMessageSetDictionary4UpdateOracleDatabase = "SELECT * FROM CIM_MESSAGESETDICTIONARY WHERE SERVICENAME=:SERVICENAME AND BIZNAME=:BIZNAME AND SETNAME=:SETNAME AND PARAMETERNAME=:PARAMETERNAME AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectMessageSetDictionaryOracleDatabase = "SELECT * FROM CIM_MESSAGESETDICTIONARY WHERE SERVICENAME=:SERVICENAME AND BIZNAME=:BIZNAME AND SETNAME=:SETNAME AND PARAMETERNAME=:PARAMETERNAME AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMessageSetDictionary4UpdateOracleDatabase = "SELECT * FROM CIM_MESSAGESETDICTIONARY WHERE SERVICENAME=:SERVICENAME AND BIZNAME=:BIZNAME AND SETNAME=:SETNAME AND PARAMETERNAME=:PARAMETERNAME AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Messagesetdictionary);

	public static Messagesetdictionary GetMessageSetDictionary(IDbContext dbContext, string servicename, string bizname, string setname, string parametername, string siteid)
	{
		string apiName = "GetMessageSetDictionary";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{servicename},{bizname},{setname},{parametername},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetMessageSetDictionarySqlDatabase : _sqlGetMessageSetDictionaryOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SERVICENAME", servicename, typeOfThis));
		list.Add(dbContext.CreateParameter("BIZNAME", bizname, typeOfThis));
		list.Add(dbContext.CreateParameter("SETNAME", setname, typeOfThis));
		list.Add(dbContext.CreateParameter("PARAMETERNAME", parametername, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MESSAGESETDICTIONARY", $"{servicename},{bizname},{setname},{parametername},{siteid}"));
		}
		Messagesetdictionary result = ContextManager.DirectEntityQuery<Messagesetdictionary>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{servicename},{bizname},{setname},{parametername},{siteid}");
		}
		return result;
	}

	public static Messagesetdictionary GetMessageSetDictionary4Update(IDbContext dbContext, string servicename, string bizname, string setname, string parametername, string siteid)
	{
		string apiName = "GetMessageSetDictionary4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{servicename},{bizname},{setname},{parametername},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetMessageSetDictionary4UpdateSqlDatabase : _sqlGetMessageSetDictionary4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SERVICENAME", servicename, typeOfThis));
		list.Add(dbContext.CreateParameter("BIZNAME", bizname, typeOfThis));
		list.Add(dbContext.CreateParameter("SETNAME", setname, typeOfThis));
		list.Add(dbContext.CreateParameter("PARAMETERNAME", parametername, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_MESSAGESETDICTIONARY", $"{servicename},{bizname},{setname},{parametername},{siteid}"));
		}
		Messagesetdictionary result = ContextManager.DirectEntityQuery<Messagesetdictionary>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{servicename},{bizname},{setname},{parametername},{siteid}");
		}
		return result;
	}

	public static Messagesetdictionary SelectMessageSetDictionary(IDbContext dbContext, string servicename, string bizname, string setname, string parametername, string siteid)
	{
		string apiName = "SelectMessageSetDictionary";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{servicename},{bizname},{setname},{parametername},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMessageSetDictionarySqlDatabase : _sqlSelectMessageSetDictionaryOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SERVICENAME", servicename, typeOfThis));
		list.Add(dbContext.CreateParameter("BIZNAME", bizname, typeOfThis));
		list.Add(dbContext.CreateParameter("SETNAME", setname, typeOfThis));
		list.Add(dbContext.CreateParameter("PARAMETERNAME", parametername, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MESSAGESETDICTIONARY", $"{servicename},{bizname},{setname},{parametername},{siteid}"));
		}
		Messagesetdictionary result = ContextManager.DirectEntityQuery<Messagesetdictionary>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{servicename},{bizname},{setname},{parametername},{siteid}");
		}
		return result;
	}

	public static Messagesetdictionary SelectMessageSetDictionary4Update(IDbContext dbContext, string servicename, string bizname, string setname, string parametername, string siteid)
	{
		string apiName = "SelectMessageSetDictionary4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{servicename},{bizname},{setname},{parametername},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMessageSetDictionary4UpdateSqlDatabase : _sqlSelectMessageSetDictionary4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SERVICENAME", servicename, typeOfThis));
		list.Add(dbContext.CreateParameter("BIZNAME", bizname, typeOfThis));
		list.Add(dbContext.CreateParameter("SETNAME", setname, typeOfThis));
		list.Add(dbContext.CreateParameter("PARAMETERNAME", parametername, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_MESSAGESETDICTIONARY", $"{servicename},{bizname},{setname},{parametername},{siteid}"));
		}
		Messagesetdictionary result = ContextManager.DirectEntityQuery<Messagesetdictionary>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{servicename},{bizname},{setname},{parametername},{siteid}");
		}
		return result;
	}

	public static int UpsertMessageSetDictionary(IDbContext dbContext, RequestType requestType, Messagesetdictionary[] messageSetDictionaryList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateMessageSetDictionaryInternal(dbContext, messageSetDictionaryList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateMessageSetDictionary(dbContext, messageSetDictionaryList, optionSet, saveHist), 
			RequestType.DELETE => DeleteMessageSetDictionary(dbContext, messageSetDictionaryList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteMessageSetDictionary(dbContext, messageSetDictionaryList, optionSet, saveHist), 
			_ => RealDeleteMessageSetDictionary(dbContext, messageSetDictionaryList, optionSet, saveHist), 
		};
	}

	private static int CreateMessageSetDictionaryInternal(IDbContext dbContext, Messagesetdictionary[] messageSetDictionaryList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("messageSetDictionaryList", messageSetDictionaryList);
		string text = "CreateMessageSetDictionary";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Messagesetdictionary> list = new List<Messagesetdictionary>();
		foreach (Messagesetdictionary obj in messageSetDictionaryList)
		{
			Messagesetdictionary messagesetdictionary = new Messagesetdictionary();
			obj.CopyColumsTo(messagesetdictionary);
			messagesetdictionary.Activity = text;
			messagesetdictionary.CheckEntityUsable();
			obj.CopyCommonField(messagesetdictionary, systemTime, dbContext.Tid, isCreate: true);
			list.Add(messagesetdictionary);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateMessageSetDictionary(IDbContext dbContext, Messagesetdictionary[] messageSetDictionaryList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("messageSetDictionaryList", messageSetDictionaryList);
		string text = "UpdateMessageSetDictionary";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Messagesetdictionary> list = new List<Messagesetdictionary>();
		foreach (Messagesetdictionary messagesetdictionary in messageSetDictionaryList)
		{
			Messagesetdictionary messageSetDictionary4Update = GetMessageSetDictionary4Update(dbContext, messagesetdictionary.Servicename, messagesetdictionary.Bizname, messagesetdictionary.Setname, messagesetdictionary.Parametername, messagesetdictionary.Siteid);
			if (messageSetDictionary4Update == null)
			{
				throw new EntityNotFoundException(typeof(Messagesetdictionary), $"{messagesetdictionary.Servicename},{messagesetdictionary.Bizname},{messagesetdictionary.Setname},{messagesetdictionary.Parametername},{messagesetdictionary.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Messagesetdictionary), $"{messagesetdictionary.Servicename},{messagesetdictionary.Bizname},{messagesetdictionary.Setname},{messagesetdictionary.Parametername},{messagesetdictionary.Siteid}", messageSetDictionary4Update.Isusable);
			string activity = messageSetDictionary4Update.Activity;
			string customactivity = messageSetDictionary4Update.Customactivity;
			string isusable = messageSetDictionary4Update.Isusable;
			DateTime? createtime = messageSetDictionary4Update.Createtime;
			string creator = messageSetDictionary4Update.Creator;
			messagesetdictionary.CopyColumsTo(messageSetDictionary4Update);
			messageSetDictionary4Update.Prevactivity = activity;
			messageSetDictionary4Update.Prevcustomactivity = customactivity;
			messageSetDictionary4Update.Creator = creator;
			messageSetDictionary4Update.Createtime = createtime;
			messageSetDictionary4Update.Isusable = isusable;
			messageSetDictionary4Update.Activity = text;
			messagesetdictionary.CopyCommonField(messageSetDictionary4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(messageSetDictionary4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteMessageSetDictionary(IDbContext dbContext, Messagesetdictionary[] messageSetDictionaryList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("messageSetDictionaryList", messageSetDictionaryList);
		string text = "DeleteMessageSetDictionary";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Messagesetdictionary> list = new List<Messagesetdictionary>();
		foreach (Messagesetdictionary messagesetdictionary in messageSetDictionaryList)
		{
			Messagesetdictionary messageSetDictionary4Update = GetMessageSetDictionary4Update(dbContext, messagesetdictionary.Servicename, messagesetdictionary.Bizname, messagesetdictionary.Setname, messagesetdictionary.Parametername, messagesetdictionary.Siteid);
			if (messageSetDictionary4Update == null)
			{
				throw new EntityNotFoundException(typeof(Messagesetdictionary), $"{messagesetdictionary.Servicename},{messagesetdictionary.Bizname},{messagesetdictionary.Setname},{messagesetdictionary.Parametername},{messagesetdictionary.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Messagesetdictionary), $"{messagesetdictionary.Servicename},{messagesetdictionary.Bizname},{messagesetdictionary.Setname},{messagesetdictionary.Parametername},{messagesetdictionary.Siteid}", messageSetDictionary4Update.Isusable);
			messageSetDictionary4Update.Isusable = "UnUsable";
			messagesetdictionary.CopyCommonFieldUpdatePrev(messageSetDictionary4Update, systemTime, dbContext.Tid, text);
			messagesetdictionary.CopyExtensionCollection(messageSetDictionary4Update);
			list.Add(messageSetDictionary4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteMessageSetDictionary(IDbContext dbContext, Messagesetdictionary[] messageSetDictionaryList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("messageSetDictionaryList", messageSetDictionaryList);
		string text = "UnDeleteMessageSetDictionary";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Messagesetdictionary> list = new List<Messagesetdictionary>();
		foreach (Messagesetdictionary messagesetdictionary in messageSetDictionaryList)
		{
			Messagesetdictionary messageSetDictionary4Update = GetMessageSetDictionary4Update(dbContext, messagesetdictionary.Servicename, messagesetdictionary.Bizname, messagesetdictionary.Setname, messagesetdictionary.Parametername, messagesetdictionary.Siteid);
			if (messageSetDictionary4Update == null)
			{
				throw new EntityNotFoundException(typeof(Messagesetdictionary), $"{messagesetdictionary.Servicename},{messagesetdictionary.Bizname},{messagesetdictionary.Setname},{messagesetdictionary.Parametername},{messagesetdictionary.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Messagesetdictionary), $"{messagesetdictionary.Servicename},{messagesetdictionary.Bizname},{messagesetdictionary.Setname},{messagesetdictionary.Parametername},{messagesetdictionary.Siteid}", messageSetDictionary4Update.Isusable);
			messageSetDictionary4Update.Isusable = "Usable";
			messagesetdictionary.CopyCommonFieldUpdatePrev(messageSetDictionary4Update, systemTime, dbContext.Tid, text);
			messagesetdictionary.CopyExtensionCollection(messageSetDictionary4Update);
			list.Add(messageSetDictionary4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteMessageSetDictionary(IDbContext dbContext, Messagesetdictionary[] messageSetDictionaryList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("messageSetDictionaryList", messageSetDictionaryList);
		string text = "RealDeleteMessageSetDictionary";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Messagesetdictionary> list = new List<Messagesetdictionary>();
		foreach (Messagesetdictionary messagesetdictionary in messageSetDictionaryList)
		{
			Messagesetdictionary messageSetDictionary4Update = GetMessageSetDictionary4Update(dbContext, messagesetdictionary.Servicename, messagesetdictionary.Bizname, messagesetdictionary.Setname, messagesetdictionary.Parametername, messagesetdictionary.Siteid);
			if (messageSetDictionary4Update == null)
			{
				throw new EntityNotFoundException(typeof(Messagesetdictionary), $"{messagesetdictionary.Servicename},{messagesetdictionary.Bizname},{messagesetdictionary.Setname},{messagesetdictionary.Parametername},{messagesetdictionary.Siteid}");
			}
			messagesetdictionary.CopyCommonFieldUpdatePrev(messageSetDictionary4Update, systemTime, dbContext.Tid, text);
			messagesetdictionary.CopyExtensionCollection(messageSetDictionary4Update);
			list.Add(messageSetDictionary4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
