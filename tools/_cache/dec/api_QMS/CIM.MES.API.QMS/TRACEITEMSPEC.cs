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
public class TRACEITEMSPEC
{
	private static string _sqlGetTraceItemSpecSqlDatabase = "SELECT * FROM CIM_TRACEITEMSPEC WHERE EQUIPMENTID=@EQUIPMENTID AND TRACEITEMDEFINITIONID=@TRACEITEMDEFINITIONID AND TRACEITEMID=@TRACEITEMID AND SITEID=@SITEID";

	private static string _sqlGetTraceItemSpec4UpdateSqlDatabase = "SELECT * FROM CIM_TRACEITEMSPEC WITH(UPDLOCK) WHERE EQUIPMENTID=@EQUIPMENTID AND TRACEITEMDEFINITIONID=@TRACEITEMDEFINITIONID AND TRACEITEMID=@TRACEITEMID AND SITEID=@SITEID";

	private static string _sqlSelectTraceItemSpecSqlDatabase = "SELECT * FROM CIM_TRACEITEMSPEC WHERE EQUIPMENTID=@EQUIPMENTID AND TRACEITEMDEFINITIONID=@TRACEITEMDEFINITIONID AND TRACEITEMID=@TRACEITEMID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectTraceItemSpec4UpdateSqlDatabase = "SELECT * FROM CIM_TRACEITEMSPEC WITH(UPDLOCK) WHERE EQUIPMENTID=@EQUIPMENTID AND TRACEITEMDEFINITIONID=@TRACEITEMDEFINITIONID AND TRACEITEMID=@TRACEITEMID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetTraceItemSpecOracleDatabase = "SELECT * FROM CIM_TRACEITEMSPEC WHERE EQUIPMENTID=:EQUIPMENTID AND TRACEITEMDEFINITIONID=:TRACEITEMDEFINITIONID AND TRACEITEMID=:TRACEITEMID AND SITEID=:SITEID";

	private static string _sqlGetTraceItemSpec4UpdateOracleDatabase = "SELECT * FROM CIM_TRACEITEMSPEC WHERE EQUIPMENTID=:EQUIPMENTID AND TRACEITEMDEFINITIONID=:TRACEITEMDEFINITIONID AND TRACEITEMID=:TRACEITEMID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectTraceItemSpecOracleDatabase = "SELECT * FROM CIM_TRACEITEMSPEC WHERE EQUIPMENTID=:EQUIPMENTID AND TRACEITEMDEFINITIONID=:TRACEITEMDEFINITIONID AND TRACEITEMID=:TRACEITEMID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectTraceItemSpec4UpdateOracleDatabase = "SELECT * FROM CIM_TRACEITEMSPEC WHERE EQUIPMENTID=:EQUIPMENTID AND TRACEITEMDEFINITIONID=:TRACEITEMDEFINITIONID AND TRACEITEMID=:TRACEITEMID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Traceitemspec);

	public static Traceitemspec GetTraceItemSpec(IDbContext dbContext, string equipmentid, string traceitemdefinitionid, string traceitemid, string siteid)
	{
		string apiName = "GetTraceItemSpec";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentid},{traceitemdefinitionid},{traceitemid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetTraceItemSpecSqlDatabase : _sqlGetTraceItemSpecOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("TRACEITEMDEFINITIONID", traceitemdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("TRACEITEMID", traceitemid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_TRACEITEMSPEC", $"{equipmentid},{traceitemdefinitionid},{traceitemid},{siteid}"));
		}
		Traceitemspec result = ContextManager.DirectEntityQuery<Traceitemspec>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentid},{traceitemdefinitionid},{traceitemid},{siteid}");
		}
		return result;
	}

	public static Traceitemspec GetTraceItemSpec4Update(IDbContext dbContext, string equipmentid, string traceitemdefinitionid, string traceitemid, string siteid)
	{
		string apiName = "GetTraceItemSpec4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentid},{traceitemdefinitionid},{traceitemid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetTraceItemSpec4UpdateSqlDatabase : _sqlGetTraceItemSpec4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("TRACEITEMDEFINITIONID", traceitemdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("TRACEITEMID", traceitemid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_TRACEITEMSPEC", $"{equipmentid},{traceitemdefinitionid},{traceitemid},{siteid}"));
		}
		Traceitemspec result = ContextManager.DirectEntityQuery<Traceitemspec>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentid},{traceitemdefinitionid},{traceitemid},{siteid}");
		}
		return result;
	}

	public static Traceitemspec SelectTraceItemSpec(IDbContext dbContext, string equipmentid, string traceitemdefinitionid, string traceitemid, string siteid)
	{
		string apiName = "SelectTraceItemSpec";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentid},{traceitemdefinitionid},{traceitemid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectTraceItemSpecSqlDatabase : _sqlSelectTraceItemSpecOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("TRACEITEMDEFINITIONID", traceitemdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("TRACEITEMID", traceitemid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_TRACEITEMSPEC", $"{equipmentid},{traceitemdefinitionid},{traceitemid},{siteid}"));
		}
		Traceitemspec result = ContextManager.DirectEntityQuery<Traceitemspec>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentid},{traceitemdefinitionid},{traceitemid},{siteid}");
		}
		return result;
	}

	public static Traceitemspec SelectTraceItemSpec4Update(IDbContext dbContext, string equipmentid, string traceitemdefinitionid, string traceitemid, string siteid)
	{
		string apiName = "SelectTraceItemSpec4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentid},{traceitemdefinitionid},{traceitemid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectTraceItemSpec4UpdateSqlDatabase : _sqlSelectTraceItemSpec4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("TRACEITEMDEFINITIONID", traceitemdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("TRACEITEMID", traceitemid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_TRACEITEMSPEC", $"{equipmentid},{traceitemdefinitionid},{traceitemid},{siteid}"));
		}
		Traceitemspec result = ContextManager.DirectEntityQuery<Traceitemspec>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentid},{traceitemdefinitionid},{traceitemid},{siteid}");
		}
		return result;
	}

	public static int UpsertTraceItemSpec(IDbContext dbContext, RequestType requestType, Traceitemspec[] traceItemSpecList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateTraceItemSpecInternal(dbContext, traceItemSpecList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateTraceItemSpec(dbContext, traceItemSpecList, optionSet, saveHist), 
			RequestType.DELETE => DeleteTraceItemSpec(dbContext, traceItemSpecList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteTraceItemSpec(dbContext, traceItemSpecList, optionSet, saveHist), 
			_ => RealDeleteTraceItemSpec(dbContext, traceItemSpecList, optionSet, saveHist), 
		};
	}

	private static int CreateTraceItemSpecInternal(IDbContext dbContext, Traceitemspec[] traceItemSpecList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceItemSpecList", traceItemSpecList);
		string text = "CreateTraceItemSpec";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Traceitemspec> list = new List<Traceitemspec>();
		foreach (Traceitemspec obj in traceItemSpecList)
		{
			Traceitemspec traceitemspec = new Traceitemspec();
			obj.CopyColumsTo(traceitemspec);
			traceitemspec.Activity = text;
			traceitemspec.CheckEntityUsable();
			obj.CopyCommonField(traceitemspec, systemTime, dbContext.Tid, isCreate: true);
			list.Add(traceitemspec);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateTraceItemSpec(IDbContext dbContext, Traceitemspec[] traceItemSpecList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceItemSpecList", traceItemSpecList);
		string text = "UpdateTraceItemSpec";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Traceitemspec> list = new List<Traceitemspec>();
		foreach (Traceitemspec traceitemspec in traceItemSpecList)
		{
			Traceitemspec traceItemSpec4Update = GetTraceItemSpec4Update(dbContext, traceitemspec.Equipmentid, traceitemspec.Traceitemdefinitionid, traceitemspec.Traceitemid, traceitemspec.Siteid);
			if (traceItemSpec4Update == null)
			{
				throw new EntityNotFoundException(typeof(Traceitemspec), $"{traceitemspec.Equipmentid},{traceitemspec.Traceitemdefinitionid},{traceitemspec.Traceitemid},{traceitemspec.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Traceitemspec), $"{traceitemspec.Equipmentid},{traceitemspec.Traceitemdefinitionid},{traceitemspec.Traceitemid},{traceitemspec.Siteid}", traceItemSpec4Update.Isusable);
			string activity = traceItemSpec4Update.Activity;
			string customactivity = traceItemSpec4Update.Customactivity;
			string isusable = traceItemSpec4Update.Isusable;
			DateTime? createtime = traceItemSpec4Update.Createtime;
			string creator = traceItemSpec4Update.Creator;
			traceitemspec.CopyColumsTo(traceItemSpec4Update);
			traceItemSpec4Update.Prevactivity = activity;
			traceItemSpec4Update.Prevcustomactivity = customactivity;
			traceItemSpec4Update.Creator = creator;
			traceItemSpec4Update.Createtime = createtime;
			traceItemSpec4Update.Isusable = isusable;
			traceItemSpec4Update.Activity = text;
			traceitemspec.CopyCommonField(traceItemSpec4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(traceItemSpec4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteTraceItemSpec(IDbContext dbContext, Traceitemspec[] traceItemSpecList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceItemSpecList", traceItemSpecList);
		string text = "DeleteTraceItemSpec";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Traceitemspec> list = new List<Traceitemspec>();
		foreach (Traceitemspec traceitemspec in traceItemSpecList)
		{
			Traceitemspec traceItemSpec4Update = GetTraceItemSpec4Update(dbContext, traceitemspec.Equipmentid, traceitemspec.Traceitemdefinitionid, traceitemspec.Traceitemid, traceitemspec.Siteid);
			if (traceItemSpec4Update == null)
			{
				throw new EntityNotFoundException(typeof(Traceitemspec), $"{traceitemspec.Equipmentid},{traceitemspec.Traceitemdefinitionid},{traceitemspec.Traceitemid},{traceitemspec.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Traceitemspec), $"{traceitemspec.Equipmentid},{traceitemspec.Traceitemdefinitionid},{traceitemspec.Traceitemid},{traceitemspec.Siteid}", traceItemSpec4Update.Isusable);
			traceItemSpec4Update.Isusable = "UnUsable";
			traceitemspec.CopyCommonFieldUpdatePrev(traceItemSpec4Update, systemTime, dbContext.Tid, text);
			traceitemspec.CopyExtensionCollection(traceItemSpec4Update);
			list.Add(traceItemSpec4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteTraceItemSpec(IDbContext dbContext, Traceitemspec[] traceItemSpecList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceItemSpecList", traceItemSpecList);
		string text = "UnDeleteTraceItemSpec";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Traceitemspec> list = new List<Traceitemspec>();
		foreach (Traceitemspec traceitemspec in traceItemSpecList)
		{
			Traceitemspec traceItemSpec4Update = GetTraceItemSpec4Update(dbContext, traceitemspec.Equipmentid, traceitemspec.Traceitemdefinitionid, traceitemspec.Traceitemid, traceitemspec.Siteid);
			if (traceItemSpec4Update == null)
			{
				throw new EntityNotFoundException(typeof(Traceitemspec), $"{traceitemspec.Equipmentid},{traceitemspec.Traceitemdefinitionid},{traceitemspec.Traceitemid},{traceitemspec.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Traceitemspec), $"{traceitemspec.Equipmentid},{traceitemspec.Traceitemdefinitionid},{traceitemspec.Traceitemid},{traceitemspec.Siteid}", traceItemSpec4Update.Isusable);
			traceItemSpec4Update.Isusable = "Usable";
			traceitemspec.CopyCommonFieldUpdatePrev(traceItemSpec4Update, systemTime, dbContext.Tid, text);
			traceitemspec.CopyExtensionCollection(traceItemSpec4Update);
			list.Add(traceItemSpec4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteTraceItemSpec(IDbContext dbContext, Traceitemspec[] traceItemSpecList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceItemSpecList", traceItemSpecList);
		string text = "RealDeleteTraceItemSpec";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Traceitemspec> list = new List<Traceitemspec>();
		foreach (Traceitemspec traceitemspec in traceItemSpecList)
		{
			Traceitemspec traceItemSpec4Update = GetTraceItemSpec4Update(dbContext, traceitemspec.Equipmentid, traceitemspec.Traceitemdefinitionid, traceitemspec.Traceitemid, traceitemspec.Siteid);
			if (traceItemSpec4Update == null)
			{
				throw new EntityNotFoundException(typeof(Traceitemspec), $"{traceitemspec.Equipmentid},{traceitemspec.Traceitemdefinitionid},{traceitemspec.Traceitemid},{traceitemspec.Siteid}");
			}
			traceitemspec.CopyCommonFieldUpdatePrev(traceItemSpec4Update, systemTime, dbContext.Tid, text);
			traceitemspec.CopyExtensionCollection(traceItemSpec4Update);
			list.Add(traceItemSpec4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
