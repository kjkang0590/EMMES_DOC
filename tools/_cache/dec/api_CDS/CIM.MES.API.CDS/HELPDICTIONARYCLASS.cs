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
public class HELPDICTIONARYCLASS
{
	private static string _sqlGetHelpDictionaryClassSqlDatabase = "SELECT * FROM CIM_HELPDICTIONARYCLASS WHERE HELPDICTIONARYCLASSID=@HELPDICTIONARYCLASSID AND SITEID=@SITEID";

	private static string _sqlGetHelpDictionaryClass4UpdateSqlDatabase = "SELECT * FROM CIM_HELPDICTIONARYCLASS WITH(UPDLOCK) WHERE HELPDICTIONARYCLASSID=@HELPDICTIONARYCLASSID AND SITEID=@SITEID";

	private static string _sqlSelectHelpDictionaryClassSqlDatabase = "SELECT * FROM CIM_HELPDICTIONARYCLASS WHERE HELPDICTIONARYCLASSID=@HELPDICTIONARYCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectHelpDictionaryClass4UpdateSqlDatabase = "SELECT * FROM CIM_HELPDICTIONARYCLASS WITH(UPDLOCK) WHERE HELPDICTIONARYCLASSID=@HELPDICTIONARYCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetHelpDictionaryClassOracleDatabase = "SELECT * FROM CIM_HELPDICTIONARYCLASS WHERE HELPDICTIONARYCLASSID=:HELPDICTIONARYCLASSID AND SITEID=:SITEID";

	private static string _sqlGetHelpDictionaryClass4UpdateOracleDatabase = "SELECT * FROM CIM_HELPDICTIONARYCLASS WHERE HELPDICTIONARYCLASSID=:HELPDICTIONARYCLASSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectHelpDictionaryClassOracleDatabase = "SELECT * FROM CIM_HELPDICTIONARYCLASS WHERE HELPDICTIONARYCLASSID=:HELPDICTIONARYCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectHelpDictionaryClass4UpdateOracleDatabase = "SELECT * FROM CIM_HELPDICTIONARYCLASS WHERE HELPDICTIONARYCLASSID=:HELPDICTIONARYCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Helpdictionaryclass);

	public static Helpdictionaryclass GetHelpDictionaryClass(IDbContext dbContext, string helpdictionaryclassid, string siteid)
	{
		string apiName = "GetHelpDictionaryClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{helpdictionaryclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetHelpDictionaryClassSqlDatabase : _sqlGetHelpDictionaryClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("HELPDICTIONARYCLASSID", helpdictionaryclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_HELPDICTIONARYCLASS", $"{helpdictionaryclassid},{siteid}"));
		}
		Helpdictionaryclass? result = ContextManager.DirectEntityQuery<Helpdictionaryclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{helpdictionaryclassid},{siteid}");
		}
		return result;
	}

	public static Helpdictionaryclass GetHelpDictionaryClass4Update(IDbContext dbContext, string helpdictionaryclassid, string siteid)
	{
		string apiName = "GetHelpDictionaryClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{helpdictionaryclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetHelpDictionaryClass4UpdateSqlDatabase : _sqlGetHelpDictionaryClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("HELPDICTIONARYCLASSID", helpdictionaryclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_HELPDICTIONARYCLASS", $"{helpdictionaryclassid},{siteid}"));
		}
		Helpdictionaryclass? result = ContextManager.DirectEntityQuery<Helpdictionaryclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{helpdictionaryclassid},{siteid}");
		}
		return result;
	}

	public static Helpdictionaryclass SelectHelpDictionaryClass(IDbContext dbContext, string helpdictionaryclassid, string siteid)
	{
		string apiName = "SelectHelpDictionaryClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{helpdictionaryclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectHelpDictionaryClassSqlDatabase : _sqlSelectHelpDictionaryClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("HELPDICTIONARYCLASSID", helpdictionaryclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_HELPDICTIONARYCLASS", $"{helpdictionaryclassid},{siteid}"));
		}
		Helpdictionaryclass? result = ContextManager.DirectEntityQuery<Helpdictionaryclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{helpdictionaryclassid},{siteid}");
		}
		return result;
	}

	public static Helpdictionaryclass SelectHelpDictionaryClass4Update(IDbContext dbContext, string helpdictionaryclassid, string siteid)
	{
		string apiName = "SelectHelpDictionaryClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{helpdictionaryclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectHelpDictionaryClass4UpdateSqlDatabase : _sqlSelectHelpDictionaryClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("HELPDICTIONARYCLASSID", helpdictionaryclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_HELPDICTIONARYCLASS", $"{helpdictionaryclassid},{siteid}"));
		}
		Helpdictionaryclass? result = ContextManager.DirectEntityQuery<Helpdictionaryclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{helpdictionaryclassid},{siteid}");
		}
		return result;
	}

	public static int UpsertHelpDictionaryClass(IDbContext dbContext, RequestType requestType, Helpdictionaryclass[] helpDictionaryClassList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateHelpDictionaryClassInternal(dbContext, helpDictionaryClassList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateHelpDictionaryClass(dbContext, helpDictionaryClassList, optionSet, saveHist), 
			RequestType.DELETE => DeleteHelpDictionaryClass(dbContext, helpDictionaryClassList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteHelpDictionaryClass(dbContext, helpDictionaryClassList, optionSet, saveHist), 
			_ => RealDeleteHelpDictionaryClass(dbContext, helpDictionaryClassList, optionSet, saveHist), 
		};
	}

	private static int CreateHelpDictionaryClassInternal(IDbContext dbContext, Helpdictionaryclass[] helpDictionaryClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("helpDictionaryClassList", helpDictionaryClassList);
		string text = "CreateHelpDictionaryClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Helpdictionaryclass> list = new List<Helpdictionaryclass>();
		foreach (Helpdictionaryclass obj in helpDictionaryClassList)
		{
			Helpdictionaryclass helpdictionaryclass = new Helpdictionaryclass();
			obj.CopyColumsTo(helpdictionaryclass);
			helpdictionaryclass.Activity = text;
			helpdictionaryclass.CheckEntityUsable();
			obj.CopyCommonField(helpdictionaryclass, systemTime, dbContext.Tid, isCreate: true);
			list.Add(helpdictionaryclass);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateHelpDictionaryClass(IDbContext dbContext, Helpdictionaryclass[] helpDictionaryClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("helpDictionaryClassList", helpDictionaryClassList);
		string text = "UpdateHelpDictionaryClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Helpdictionaryclass> list = new List<Helpdictionaryclass>();
		foreach (Helpdictionaryclass helpdictionaryclass in helpDictionaryClassList)
		{
			Helpdictionaryclass helpDictionaryClass4Update = GetHelpDictionaryClass4Update(dbContext, helpdictionaryclass.Helpdictionaryclassid, helpdictionaryclass.Siteid);
			if (helpDictionaryClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Helpdictionaryclass), $"{helpdictionaryclass.Helpdictionaryclassid},{helpdictionaryclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Helpdictionaryclass), $"{helpdictionaryclass.Helpdictionaryclassid},{helpdictionaryclass.Siteid}", helpDictionaryClass4Update.Isusable);
			string activity = helpDictionaryClass4Update.Activity;
			string customactivity = helpDictionaryClass4Update.Customactivity;
			string isusable = helpDictionaryClass4Update.Isusable;
			DateTime? createtime = helpDictionaryClass4Update.Createtime;
			string creator = helpDictionaryClass4Update.Creator;
			helpdictionaryclass.CopyColumsTo(helpDictionaryClass4Update);
			helpDictionaryClass4Update.Prevactivity = activity;
			helpDictionaryClass4Update.Prevcustomactivity = customactivity;
			helpDictionaryClass4Update.Creator = creator;
			helpDictionaryClass4Update.Createtime = createtime;
			helpDictionaryClass4Update.Isusable = isusable;
			helpDictionaryClass4Update.Activity = text;
			helpdictionaryclass.CopyCommonField(helpDictionaryClass4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(helpDictionaryClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteHelpDictionaryClass(IDbContext dbContext, Helpdictionaryclass[] helpDictionaryClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("helpDictionaryClassList", helpDictionaryClassList);
		string text = "DeleteHelpDictionaryClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Helpdictionaryclass> list = new List<Helpdictionaryclass>();
		foreach (Helpdictionaryclass helpdictionaryclass in helpDictionaryClassList)
		{
			Helpdictionaryclass helpDictionaryClass4Update = GetHelpDictionaryClass4Update(dbContext, helpdictionaryclass.Helpdictionaryclassid, helpdictionaryclass.Siteid);
			if (helpDictionaryClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Helpdictionaryclass), $"{helpdictionaryclass.Helpdictionaryclassid},{helpdictionaryclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Helpdictionaryclass), $"{helpdictionaryclass.Helpdictionaryclassid},{helpdictionaryclass.Siteid}", helpDictionaryClass4Update.Isusable);
			helpDictionaryClass4Update.Isusable = "UnUsable";
			helpdictionaryclass.CopyCommonFieldUpdatePrev(helpDictionaryClass4Update, systemTime, dbContext.Tid, text);
			helpdictionaryclass.CopyExtensionCollection(helpDictionaryClass4Update);
			list.Add(helpDictionaryClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteHelpDictionaryClass(IDbContext dbContext, Helpdictionaryclass[] helpDictionaryClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("helpDictionaryClassList", helpDictionaryClassList);
		string text = "UnDeleteHelpDictionaryClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Helpdictionaryclass> list = new List<Helpdictionaryclass>();
		foreach (Helpdictionaryclass helpdictionaryclass in helpDictionaryClassList)
		{
			Helpdictionaryclass helpDictionaryClass4Update = GetHelpDictionaryClass4Update(dbContext, helpdictionaryclass.Helpdictionaryclassid, helpdictionaryclass.Siteid);
			if (helpDictionaryClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Helpdictionaryclass), $"{helpdictionaryclass.Helpdictionaryclassid},{helpdictionaryclass.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Helpdictionaryclass), $"{helpdictionaryclass.Helpdictionaryclassid},{helpdictionaryclass.Siteid}", helpDictionaryClass4Update.Isusable);
			helpDictionaryClass4Update.Isusable = "Usable";
			helpdictionaryclass.CopyCommonFieldUpdatePrev(helpDictionaryClass4Update, systemTime, dbContext.Tid, text);
			helpdictionaryclass.CopyExtensionCollection(helpDictionaryClass4Update);
			list.Add(helpDictionaryClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteHelpDictionaryClass(IDbContext dbContext, Helpdictionaryclass[] helpDictionaryClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("helpDictionaryClassList", helpDictionaryClassList);
		string text = "RealDeleteHelpDictionaryClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Helpdictionaryclass> list = new List<Helpdictionaryclass>();
		foreach (Helpdictionaryclass helpdictionaryclass in helpDictionaryClassList)
		{
			Helpdictionaryclass helpDictionaryClass4Update = GetHelpDictionaryClass4Update(dbContext, helpdictionaryclass.Helpdictionaryclassid, helpdictionaryclass.Siteid);
			if (helpDictionaryClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Helpdictionaryclass), $"{helpdictionaryclass.Helpdictionaryclassid},{helpdictionaryclass.Siteid}");
			}
			helpdictionaryclass.CopyCommonFieldUpdatePrev(helpDictionaryClass4Update, systemTime, dbContext.Tid, text);
			helpdictionaryclass.CopyExtensionCollection(helpDictionaryClass4Update);
			list.Add(helpDictionaryClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
