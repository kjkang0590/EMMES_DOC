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
public class ENUMCLASS
{
	private static string _sqlGetEnumClassSqlDatabase = "SELECT * FROM CIM_ENUMCLASS WHERE ENUMCLASSID=@ENUMCLASSID AND SITEID=@SITEID";

	private static string _sqlGetEnumClass4UpdateSqlDatabase = "SELECT * FROM CIM_ENUMCLASS WITH(UPDLOCK) WHERE ENUMCLASSID=@ENUMCLASSID AND SITEID=@SITEID";

	private static string _sqlSelectEnumClassSqlDatabase = "SELECT * FROM CIM_ENUMCLASS WHERE ENUMCLASSID=@ENUMCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectEnumClass4UpdateSqlDatabase = "SELECT * FROM CIM_ENUMCLASS WITH(UPDLOCK) WHERE ENUMCLASSID=@ENUMCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetEnumClassOracleDatabase = "SELECT * FROM CIM_ENUMCLASS WHERE ENUMCLASSID=:ENUMCLASSID AND SITEID=:SITEID";

	private static string _sqlGetEnumClass4UpdateOracleDatabase = "SELECT * FROM CIM_ENUMCLASS WHERE ENUMCLASSID=:ENUMCLASSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectEnumClassOracleDatabase = "SELECT * FROM CIM_ENUMCLASS WHERE ENUMCLASSID=:ENUMCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectEnumClass4UpdateOracleDatabase = "SELECT * FROM CIM_ENUMCLASS WHERE ENUMCLASSID=:ENUMCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Enumclass);

	public static Enumclass GetEnumClass(IDbContext dbContext, string enumclassid, string siteid)
	{
		string apiName = "GetEnumClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{enumclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetEnumClassSqlDatabase : _sqlGetEnumClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ENUMCLASSID", enumclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_ENUMCLASS", $"{enumclassid},{siteid}"));
		}
		IList<Enumclass> source = ContextManager.DirectEntityQuery<Enumclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{enumclassid},{siteid}");
		}
		return source.FirstOrDefault();
	}

	public static Enumclass GetEnumClass4Update(IDbContext dbContext, string enumclassid, string siteid)
	{
		string apiName = "GetEnumClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{enumclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetEnumClass4UpdateSqlDatabase : _sqlGetEnumClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ENUMCLASSID", enumclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_ENUMCLASS", $"{enumclassid},{siteid}"));
		}
		IList<Enumclass> source = ContextManager.DirectEntityQuery<Enumclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{enumclassid},{siteid}");
		}
		return source.FirstOrDefault();
	}

	public static Enumclass SelectEnumClass(IDbContext dbContext, string enumclassid, string siteid)
	{
		string apiName = "SelectEnumClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{enumclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectEnumClassSqlDatabase : _sqlSelectEnumClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ENUMCLASSID", enumclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_ENUMCLASS", $"{enumclassid},{siteid}"));
		}
		IList<Enumclass> source = ContextManager.DirectEntityQuery<Enumclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{enumclassid},{siteid}");
		}
		return source.FirstOrDefault();
	}

	public static Enumclass SelectEnumClass4Update(IDbContext dbContext, string enumclassid, string siteid)
	{
		string apiName = "SelectEnumClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{enumclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectEnumClass4UpdateSqlDatabase : _sqlSelectEnumClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ENUMCLASSID", enumclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_ENUMCLASS", $"{enumclassid},{siteid}"));
		}
		IList<Enumclass> source = ContextManager.DirectEntityQuery<Enumclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{enumclassid},{siteid}");
		}
		return source.FirstOrDefault();
	}

	public static int UpsertEnumClass(IDbContext dbContext, RequestType requestType, Enumclass[] enumClassList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateEnumClassInternal(dbContext, enumClassList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateEnumClass(dbContext, enumClassList, optionSet, saveHist), 
			RequestType.DELETE => DeleteEnumClass(dbContext, enumClassList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteEnumClass(dbContext, enumClassList, optionSet, saveHist), 
			_ => RealDeleteEnumClass(dbContext, enumClassList, optionSet, saveHist), 
		};
	}

	private static int CreateEnumClassInternal(IDbContext dbContext, Enumclass[] enumClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("enumClassList", enumClassList);
		string text = "CreateEnumClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Enumclass> list = new List<Enumclass>();
		foreach (Enumclass obj in enumClassList)
		{
			Enumclass enumclass = new Enumclass();
			obj.CopyColumsTo(enumclass);
			enumclass.Activity = text;
			enumclass.CheckEntityUsable();
			obj.CopyCommonField(enumclass, systemTime, dbContext.Tid, isCreate: true);
			list.Add(enumclass);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateEnumClass(IDbContext dbContext, Enumclass[] enumClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("enumClassList", enumClassList);
		string text = "UpdateEnumClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Enumclass> list = new List<Enumclass>();
		foreach (Enumclass enumclass in enumClassList)
		{
			Enumclass enumClass4Update = GetEnumClass4Update(dbContext, enumclass.Enumclassid, enumclass.Siteid);
			if (enumClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Enumclass), $"{enumclass.Enumclassid},{enumclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Enumclass), $"{enumclass.Enumclassid},{enumclass.Siteid}", enumClass4Update.Isusable);
			string activity = enumClass4Update.Activity;
			string customactivity = enumClass4Update.Customactivity;
			string isusable = enumClass4Update.Isusable;
			DateTime? createtime = enumClass4Update.Createtime;
			string creator = enumClass4Update.Creator;
			enumclass.CopyColumsTo(enumClass4Update);
			enumClass4Update.Prevactivity = activity;
			enumClass4Update.Prevcustomactivity = customactivity;
			enumClass4Update.Creator = creator;
			enumClass4Update.Createtime = createtime;
			enumClass4Update.Isusable = isusable;
			enumClass4Update.Activity = text;
			enumclass.CopyCommonField(enumClass4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(enumClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteEnumClass(IDbContext dbContext, Enumclass[] enumClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("enumClassList", enumClassList);
		string text = "DeleteEnumClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Enumclass> list = new List<Enumclass>();
		foreach (Enumclass enumclass in enumClassList)
		{
			Enumclass enumClass4Update = GetEnumClass4Update(dbContext, enumclass.Enumclassid, enumclass.Siteid);
			if (enumClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Enumclass), $"{enumclass.Enumclassid},{enumclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Enumclass), $"{enumclass.Enumclassid},{enumclass.Siteid}", enumClass4Update.Isusable);
			enumClass4Update.Isusable = "UnUsable";
			enumclass.CopyCommonFieldUpdatePrev(enumClass4Update, systemTime, dbContext.Tid, text);
			enumclass.CopyExtensionCollection(enumClass4Update);
			list.Add(enumClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteEnumClass(IDbContext dbContext, Enumclass[] enumClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("enumClassList", enumClassList);
		string text = "UnDeleteEnumClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Enumclass> list = new List<Enumclass>();
		foreach (Enumclass enumclass in enumClassList)
		{
			Enumclass enumClass4Update = GetEnumClass4Update(dbContext, enumclass.Enumclassid, enumclass.Siteid);
			if (enumClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Enumclass), $"{enumclass.Enumclassid},{enumclass.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Enumclass), $"{enumclass.Enumclassid},{enumclass.Siteid}", enumClass4Update.Isusable);
			enumClass4Update.Isusable = "Usable";
			enumclass.CopyCommonFieldUpdatePrev(enumClass4Update, systemTime, dbContext.Tid, text);
			enumclass.CopyExtensionCollection(enumClass4Update);
			list.Add(enumClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteEnumClass(IDbContext dbContext, Enumclass[] enumClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("enumClassList", enumClassList);
		string text = "RealDeleteEnumClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Enumclass> list = new List<Enumclass>();
		foreach (Enumclass enumclass in enumClassList)
		{
			Enumclass enumClass4Update = GetEnumClass4Update(dbContext, enumclass.Enumclassid, enumclass.Siteid);
			if (enumClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Enumclass), $"{enumclass.Enumclassid},{enumclass.Siteid}");
			}
			enumclass.CopyCommonFieldUpdatePrev(enumClass4Update, systemTime, dbContext.Tid, text);
			enumclass.CopyExtensionCollection(enumClass4Update);
			list.Add(enumClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
