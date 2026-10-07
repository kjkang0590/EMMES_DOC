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
public class PROCESSITEMSPEC
{
	private static string _sqlGetProcessItemSpecSqlDatabase = "SELECT * FROM CIM_PROCESSITEMSPEC WHERE PRODUCTDEFINITIONID=@PRODUCTDEFINITIONID AND PROCESSDEFINITIONID=@PROCESSDEFINITIONID AND PROCESSSEGMENTID=@PROCESSSEGMENTID AND EQUIPMENTID=@EQUIPMENTID AND LOTTYPE=@LOTTYPE AND PROCESSITEMDEFINITIONID=@PROCESSITEMDEFINITIONID AND PROCESSITEMID=@PROCESSITEMID AND SITEID=@SITEID";

	private static string _sqlGetProcessItemSpec4UpdateSqlDatabase = "SELECT * FROM CIM_PROCESSITEMSPEC WITH(UPDLOCK) WHERE PRODUCTDEFINITIONID=@PRODUCTDEFINITIONID AND PROCESSDEFINITIONID=@PROCESSDEFINITIONID AND PROCESSSEGMENTID=@PROCESSSEGMENTID AND EQUIPMENTID=@EQUIPMENTID AND LOTTYPE=@LOTTYPE AND PROCESSITEMDEFINITIONID=@PROCESSITEMDEFINITIONID AND PROCESSITEMID=@PROCESSITEMID AND SITEID=@SITEID";

	private static string _sqlSelectProcessItemSpecSqlDatabase = "SELECT * FROM CIM_PROCESSITEMSPEC WHERE PRODUCTDEFINITIONID=@PRODUCTDEFINITIONID AND PROCESSDEFINITIONID=@PROCESSDEFINITIONID AND PROCESSSEGMENTID=@PROCESSSEGMENTID AND EQUIPMENTID=@EQUIPMENTID AND LOTTYPE=@LOTTYPE AND PROCESSITEMDEFINITIONID=@PROCESSITEMDEFINITIONID AND PROCESSITEMID=@PROCESSITEMID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessItemSpec4UpdateSqlDatabase = "SELECT * FROM CIM_PROCESSITEMSPEC WITH(UPDLOCK) WHERE PRODUCTDEFINITIONID=@PRODUCTDEFINITIONID AND PROCESSDEFINITIONID=@PROCESSDEFINITIONID AND PROCESSSEGMENTID=@PROCESSSEGMENTID AND EQUIPMENTID=@EQUIPMENTID AND LOTTYPE=@LOTTYPE AND PROCESSITEMDEFINITIONID=@PROCESSITEMDEFINITIONID AND PROCESSITEMID=@PROCESSITEMID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetProcessItemSpecOracleDatabase = "SELECT * FROM CIM_PROCESSITEMSPEC WHERE PRODUCTDEFINITIONID=:PRODUCTDEFINITIONID AND PROCESSDEFINITIONID=:PROCESSDEFINITIONID AND PROCESSSEGMENTID=:PROCESSSEGMENTID AND EQUIPMENTID=:EQUIPMENTID AND LOTTYPE=:LOTTYPE AND PROCESSITEMDEFINITIONID=:PROCESSITEMDEFINITIONID AND PROCESSITEMID=:PROCESSITEMID AND SITEID=:SITEID";

	private static string _sqlGetProcessItemSpec4UpdateOracleDatabase = "SELECT * FROM CIM_PROCESSITEMSPEC WHERE PRODUCTDEFINITIONID=:PRODUCTDEFINITIONID AND PROCESSDEFINITIONID=:PROCESSDEFINITIONID AND PROCESSSEGMENTID=:PROCESSSEGMENTID AND EQUIPMENTID=:EQUIPMENTID AND LOTTYPE=:LOTTYPE AND PROCESSITEMDEFINITIONID=:PROCESSITEMDEFINITIONID AND PROCESSITEMID=:PROCESSITEMID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectProcessItemSpecOracleDatabase = "SELECT * FROM CIM_PROCESSITEMSPEC WHERE PRODUCTDEFINITIONID=:PRODUCTDEFINITIONID AND PROCESSDEFINITIONID=:PROCESSDEFINITIONID AND PROCESSSEGMENTID=:PROCESSSEGMENTID AND EQUIPMENTID=:EQUIPMENTID AND LOTTYPE=:LOTTYPE AND PROCESSITEMDEFINITIONID=:PROCESSITEMDEFINITIONID AND PROCESSITEMID=:PROCESSITEMID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessItemSpec4UpdateOracleDatabase = "SELECT * FROM CIM_PROCESSITEMSPEC WHERE PRODUCTDEFINITIONID=:PRODUCTDEFINITIONID AND PROCESSDEFINITIONID=:PROCESSDEFINITIONID AND PROCESSSEGMENTID=:PROCESSSEGMENTID AND EQUIPMENTID=:EQUIPMENTID AND LOTTYPE=:LOTTYPE AND PROCESSITEMDEFINITIONID=:PROCESSITEMDEFINITIONID AND PROCESSITEMID=:PROCESSITEMID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Processitemspec);

	public static Processitemspec GetProcessItemSpec(IDbContext dbContext, string productdefinitionid, string processdefinitionid, string processsegmentid, string equipmentid, string lottype, string processitemdefinitionid, string processitemid, string siteid)
	{
		string apiName = "GetProcessItemSpec";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productdefinitionid},{processdefinitionid},{processsegmentid},{equipmentid},{lottype},{processitemdefinitionid},{processitemid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProcessItemSpecSqlDatabase : _sqlGetProcessItemSpecOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", productdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSDEFINITIONID", processdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("LOTTYPE", lottype, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSITEMDEFINITIONID", processitemdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSITEMID", processitemid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PROCESSITEMSPEC", $"{productdefinitionid},{processdefinitionid},{processsegmentid},{equipmentid},{lottype},{processitemdefinitionid},{processitemid},{siteid}"));
		}
		Processitemspec result = ContextManager.DirectEntityQuery<Processitemspec>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productdefinitionid},{processdefinitionid},{processsegmentid},{equipmentid},{lottype},{processitemdefinitionid},{processitemid},{siteid}");
		}
		return result;
	}

	public static Processitemspec GetProcessItemSpec4Update(IDbContext dbContext, string productdefinitionid, string processdefinitionid, string processsegmentid, string equipmentid, string lottype, string processitemdefinitionid, string processitemid, string siteid)
	{
		string apiName = "GetProcessItemSpec4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productdefinitionid},{processdefinitionid},{processsegmentid},{equipmentid},{lottype},{processitemdefinitionid},{processitemid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProcessItemSpec4UpdateSqlDatabase : _sqlGetProcessItemSpec4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", productdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSDEFINITIONID", processdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("LOTTYPE", lottype, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSITEMDEFINITIONID", processitemdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSITEMID", processitemid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PROCESSITEMSPEC", $"{productdefinitionid},{processdefinitionid},{processsegmentid},{equipmentid},{lottype},{processitemdefinitionid},{processitemid},{siteid}"));
		}
		Processitemspec result = ContextManager.DirectEntityQuery<Processitemspec>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productdefinitionid},{processdefinitionid},{processsegmentid},{equipmentid},{lottype},{processitemdefinitionid},{processitemid},{siteid}");
		}
		return result;
	}

	public static Processitemspec SelectProcessItemSpec(IDbContext dbContext, string productdefinitionid, string processdefinitionid, string processsegmentid, string equipmentid, string lottype, string processitemdefinitionid, string processitemid, string siteid)
	{
		string apiName = "SelectProcessItemSpec";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productdefinitionid},{processdefinitionid},{processsegmentid},{equipmentid},{lottype},{processitemdefinitionid},{processitemid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessItemSpecSqlDatabase : _sqlSelectProcessItemSpecOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", productdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSDEFINITIONID", processdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("LOTTYPE", lottype, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSITEMDEFINITIONID", processitemdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSITEMID", processitemid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PROCESSITEMSPEC", $"{productdefinitionid},{processdefinitionid},{processsegmentid},{equipmentid},{lottype},{processitemdefinitionid},{processitemid},{siteid}"));
		}
		Processitemspec result = ContextManager.DirectEntityQuery<Processitemspec>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productdefinitionid},{processdefinitionid},{processsegmentid},{equipmentid},{lottype},{processitemdefinitionid},{processitemid},{siteid}");
		}
		return result;
	}

	public static Processitemspec SelectProcessItemSpec4Update(IDbContext dbContext, string productdefinitionid, string processdefinitionid, string processsegmentid, string equipmentid, string lottype, string processitemdefinitionid, string processitemid, string siteid)
	{
		string apiName = "SelectProcessItemSpec4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productdefinitionid},{processdefinitionid},{processsegmentid},{equipmentid},{lottype},{processitemdefinitionid},{processitemid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessItemSpec4UpdateSqlDatabase : _sqlSelectProcessItemSpec4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", productdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSDEFINITIONID", processdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("LOTTYPE", lottype, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSITEMDEFINITIONID", processitemdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSITEMID", processitemid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PROCESSITEMSPEC", $"{productdefinitionid},{processdefinitionid},{processsegmentid},{equipmentid},{lottype},{processitemdefinitionid},{processitemid},{siteid}"));
		}
		Processitemspec result = ContextManager.DirectEntityQuery<Processitemspec>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productdefinitionid},{processdefinitionid},{processsegmentid},{equipmentid},{lottype},{processitemdefinitionid},{processitemid},{siteid}");
		}
		return result;
	}

	public static int UpsertProcessItemSpec(IDbContext dbContext, RequestType requestType, Processitemspec[] processItemSpecList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateProcessItemSpecInternal(dbContext, processItemSpecList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateProcessItemSpec(dbContext, processItemSpecList, optionSet, saveHist), 
			RequestType.DELETE => DeleteProcessItemSpec(dbContext, processItemSpecList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteProcessItemSpec(dbContext, processItemSpecList, optionSet, saveHist), 
			_ => RealDeleteProcessItemSpec(dbContext, processItemSpecList, optionSet, saveHist), 
		};
	}

	private static int CreateProcessItemSpecInternal(IDbContext dbContext, Processitemspec[] processItemSpecList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processItemSpecList", processItemSpecList);
		string text = "CreateProcessItemSpec";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processitemspec> list = new List<Processitemspec>();
		foreach (Processitemspec obj in processItemSpecList)
		{
			Processitemspec processitemspec = new Processitemspec();
			obj.CopyColumsTo(processitemspec);
			processitemspec.Activity = text;
			processitemspec.CheckEntityUsable();
			obj.CopyCommonField(processitemspec, systemTime, dbContext.Tid, isCreate: true);
			list.Add(processitemspec);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateProcessItemSpec(IDbContext dbContext, Processitemspec[] processItemSpecList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processItemSpecList", processItemSpecList);
		string text = "UpdateProcessItemSpec";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processitemspec> list = new List<Processitemspec>();
		foreach (Processitemspec processitemspec in processItemSpecList)
		{
			Processitemspec processItemSpec4Update = GetProcessItemSpec4Update(dbContext, processitemspec.Productdefinitionid, processitemspec.Processdefinitionid, processitemspec.Processsegmentid, processitemspec.Equipmentid, processitemspec.Lottype, processitemspec.Processitemdefinitionid, processitemspec.Processitemid, processitemspec.Siteid);
			if (processItemSpec4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processitemspec), $"{processitemspec.Productdefinitionid},{processitemspec.Processdefinitionid},{processitemspec.Processsegmentid},{processitemspec.Equipmentid},{processitemspec.Lottype},{processitemspec.Processitemdefinitionid},{processitemspec.Processitemid},{processitemspec.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Processitemspec), $"{processitemspec.Productdefinitionid},{processitemspec.Processdefinitionid},{processitemspec.Processsegmentid},{processitemspec.Equipmentid},{processitemspec.Lottype},{processitemspec.Processitemdefinitionid},{processitemspec.Processitemid},{processitemspec.Siteid}", processItemSpec4Update.Isusable);
			string activity = processItemSpec4Update.Activity;
			string customactivity = processItemSpec4Update.Customactivity;
			string isusable = processItemSpec4Update.Isusable;
			DateTime? createtime = processItemSpec4Update.Createtime;
			string creator = processItemSpec4Update.Creator;
			processitemspec.CopyColumsTo(processItemSpec4Update);
			processItemSpec4Update.Prevactivity = activity;
			processItemSpec4Update.Prevcustomactivity = customactivity;
			processItemSpec4Update.Creator = creator;
			processItemSpec4Update.Createtime = createtime;
			processItemSpec4Update.Isusable = isusable;
			processItemSpec4Update.Activity = text;
			processitemspec.CopyCommonField(processItemSpec4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(processItemSpec4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteProcessItemSpec(IDbContext dbContext, Processitemspec[] processItemSpecList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processItemSpecList", processItemSpecList);
		string text = "DeleteProcessItemSpec";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processitemspec> list = new List<Processitemspec>();
		foreach (Processitemspec processitemspec in processItemSpecList)
		{
			Processitemspec processItemSpec4Update = GetProcessItemSpec4Update(dbContext, processitemspec.Productdefinitionid, processitemspec.Processdefinitionid, processitemspec.Processsegmentid, processitemspec.Equipmentid, processitemspec.Lottype, processitemspec.Processitemdefinitionid, processitemspec.Processitemid, processitemspec.Siteid);
			if (processItemSpec4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processitemspec), $"{processitemspec.Productdefinitionid},{processitemspec.Processdefinitionid},{processitemspec.Processsegmentid},{processitemspec.Equipmentid},{processitemspec.Lottype},{processitemspec.Processitemdefinitionid},{processitemspec.Processitemid},{processitemspec.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Processitemspec), $"{processitemspec.Productdefinitionid},{processitemspec.Processdefinitionid},{processitemspec.Processsegmentid},{processitemspec.Equipmentid},{processitemspec.Lottype},{processitemspec.Processitemdefinitionid},{processitemspec.Processitemid},{processitemspec.Siteid}", processItemSpec4Update.Isusable);
			processItemSpec4Update.Isusable = "UnUsable";
			processitemspec.CopyCommonFieldUpdatePrev(processItemSpec4Update, systemTime, dbContext.Tid, text);
			processitemspec.CopyExtensionCollection(processItemSpec4Update);
			list.Add(processItemSpec4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteProcessItemSpec(IDbContext dbContext, Processitemspec[] processItemSpecList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processItemSpecList", processItemSpecList);
		string text = "UnDeleteProcessItemSpec";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processitemspec> list = new List<Processitemspec>();
		foreach (Processitemspec processitemspec in processItemSpecList)
		{
			Processitemspec processItemSpec4Update = GetProcessItemSpec4Update(dbContext, processitemspec.Productdefinitionid, processitemspec.Processdefinitionid, processitemspec.Processsegmentid, processitemspec.Equipmentid, processitemspec.Lottype, processitemspec.Processitemdefinitionid, processitemspec.Processitemid, processitemspec.Siteid);
			if (processItemSpec4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processitemspec), $"{processitemspec.Productdefinitionid},{processitemspec.Processdefinitionid},{processitemspec.Processsegmentid},{processitemspec.Equipmentid},{processitemspec.Lottype},{processitemspec.Processitemdefinitionid},{processitemspec.Processitemid},{processitemspec.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Processitemspec), $"{processitemspec.Productdefinitionid},{processitemspec.Processdefinitionid},{processitemspec.Processsegmentid},{processitemspec.Equipmentid},{processitemspec.Lottype},{processitemspec.Processitemdefinitionid},{processitemspec.Processitemid},{processitemspec.Siteid}", processItemSpec4Update.Isusable);
			processItemSpec4Update.Isusable = "Usable";
			processitemspec.CopyCommonFieldUpdatePrev(processItemSpec4Update, systemTime, dbContext.Tid, text);
			processitemspec.CopyExtensionCollection(processItemSpec4Update);
			list.Add(processItemSpec4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteProcessItemSpec(IDbContext dbContext, Processitemspec[] processItemSpecList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processItemSpecList", processItemSpecList);
		string text = "RealDeleteProcessItemSpec";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processitemspec> list = new List<Processitemspec>();
		foreach (Processitemspec processitemspec in processItemSpecList)
		{
			Processitemspec processItemSpec4Update = GetProcessItemSpec4Update(dbContext, processitemspec.Productdefinitionid, processitemspec.Processdefinitionid, processitemspec.Processsegmentid, processitemspec.Equipmentid, processitemspec.Lottype, processitemspec.Processitemdefinitionid, processitemspec.Processitemid, processitemspec.Siteid);
			if (processItemSpec4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processitemspec), $"{processitemspec.Productdefinitionid},{processitemspec.Processdefinitionid},{processitemspec.Processsegmentid},{processitemspec.Equipmentid},{processitemspec.Lottype},{processitemspec.Processitemdefinitionid},{processitemspec.Processitemid},{processitemspec.Siteid}");
			}
			processitemspec.CopyCommonFieldUpdatePrev(processItemSpec4Update, systemTime, dbContext.Tid, text);
			processitemspec.CopyExtensionCollection(processItemSpec4Update);
			list.Add(processItemSpec4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
