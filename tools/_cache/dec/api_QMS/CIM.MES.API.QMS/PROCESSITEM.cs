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
public class PROCESSITEM
{
	private static string _sqlGetProcessItemSqlDatabase = "SELECT * FROM CIM_PROCESSITEM WHERE PRODUCTDEFINITIONID=@PRODUCTDEFINITIONID AND PROCESSDEFINITIONID=@PROCESSDEFINITIONID AND PROCESSSEGMENTID=@PROCESSSEGMENTID AND EQUIPMENTID=@EQUIPMENTID AND LOTTYPE=@LOTTYPE AND PROCESSITEMDEFINITIONID=@PROCESSITEMDEFINITIONID AND SITEID=@SITEID";

	private static string _sqlGetProcessItem4UpdateSqlDatabase = "SELECT * FROM CIM_PROCESSITEM WITH(UPDLOCK) WHERE PRODUCTDEFINITIONID=@PRODUCTDEFINITIONID AND PROCESSDEFINITIONID=@PROCESSDEFINITIONID AND PROCESSSEGMENTID=@PROCESSSEGMENTID AND EQUIPMENTID=@EQUIPMENTID AND LOTTYPE=@LOTTYPE AND PROCESSITEMDEFINITIONID=@PROCESSITEMDEFINITIONID AND SITEID=@SITEID";

	private static string _sqlSelectProcessItemSqlDatabase = "SELECT * FROM CIM_PROCESSITEM WHERE PRODUCTDEFINITIONID=@PRODUCTDEFINITIONID AND PROCESSDEFINITIONID=@PROCESSDEFINITIONID AND PROCESSSEGMENTID=@PROCESSSEGMENTID AND EQUIPMENTID=@EQUIPMENTID AND LOTTYPE=@LOTTYPE AND PROCESSITEMDEFINITIONID=@PROCESSITEMDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessItem4UpdateSqlDatabase = "SELECT * FROM CIM_PROCESSITEM WITH(UPDLOCK) WHERE PRODUCTDEFINITIONID=@PRODUCTDEFINITIONID AND PROCESSDEFINITIONID=@PROCESSDEFINITIONID AND PROCESSSEGMENTID=@PROCESSSEGMENTID AND EQUIPMENTID=@EQUIPMENTID AND LOTTYPE=@LOTTYPE AND PROCESSITEMDEFINITIONID=@PROCESSITEMDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetProcessItemOracleDatabase = "SELECT * FROM CIM_PROCESSITEM WHERE PRODUCTDEFINITIONID=:PRODUCTDEFINITIONID AND PROCESSDEFINITIONID=:PROCESSDEFINITIONID AND PROCESSSEGMENTID=:PROCESSSEGMENTID AND EQUIPMENTID=:EQUIPMENTID AND LOTTYPE=:LOTTYPE AND PROCESSITEMDEFINITIONID=:PROCESSITEMDEFINITIONID AND SITEID=:SITEID";

	private static string _sqlGetProcessItem4UpdateOracleDatabase = "SELECT * FROM CIM_PROCESSITEM WHERE PRODUCTDEFINITIONID=:PRODUCTDEFINITIONID AND PROCESSDEFINITIONID=:PROCESSDEFINITIONID AND PROCESSSEGMENTID=:PROCESSSEGMENTID AND EQUIPMENTID=:EQUIPMENTID AND LOTTYPE=:LOTTYPE AND PROCESSITEMDEFINITIONID=:PROCESSITEMDEFINITIONID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectProcessItemOracleDatabase = "SELECT * FROM CIM_PROCESSITEM WHERE PRODUCTDEFINITIONID=:PRODUCTDEFINITIONID AND PROCESSDEFINITIONID=:PROCESSDEFINITIONID AND PROCESSSEGMENTID=:PROCESSSEGMENTID AND EQUIPMENTID=:EQUIPMENTID AND LOTTYPE=:LOTTYPE AND PROCESSITEMDEFINITIONID=:PROCESSITEMDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessItem4UpdateOracleDatabase = "SELECT * FROM CIM_PROCESSITEM WHERE PRODUCTDEFINITIONID=:PRODUCTDEFINITIONID AND PROCESSDEFINITIONID=:PROCESSDEFINITIONID AND PROCESSSEGMENTID=:PROCESSSEGMENTID AND EQUIPMENTID=:EQUIPMENTID AND LOTTYPE=:LOTTYPE AND PROCESSITEMDEFINITIONID=:PROCESSITEMDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Processitem);

	public static Processitem GetProcessItem(IDbContext dbContext, string productdefinitionid, string processdefinitionid, string processsegmentid, string equipmentid, string lottype, string processitemdefinitionid, string siteid)
	{
		string apiName = "GetProcessItem";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productdefinitionid},{processdefinitionid},{processsegmentid},{equipmentid},{lottype},{processitemdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProcessItemSqlDatabase : _sqlGetProcessItemOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", productdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSDEFINITIONID", processdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("LOTTYPE", lottype, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSITEMDEFINITIONID", processitemdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PROCESSITEM", $"{productdefinitionid},{processdefinitionid},{processsegmentid},{equipmentid},{lottype},{processitemdefinitionid},{siteid}"));
		}
		Processitem result = ContextManager.DirectEntityQuery<Processitem>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productdefinitionid},{processdefinitionid},{processsegmentid},{equipmentid},{lottype},{processitemdefinitionid},{siteid}");
		}
		return result;
	}

	public static Processitem GetProcessItem4Update(IDbContext dbContext, string productdefinitionid, string processdefinitionid, string processsegmentid, string equipmentid, string lottype, string processitemdefinitionid, string siteid)
	{
		string apiName = "GetProcessItem4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productdefinitionid},{processdefinitionid},{processsegmentid},{equipmentid},{lottype},{processitemdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProcessItem4UpdateSqlDatabase : _sqlGetProcessItem4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", productdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSDEFINITIONID", processdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("LOTTYPE", lottype, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSITEMDEFINITIONID", processitemdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PROCESSITEM", $"{productdefinitionid},{processdefinitionid},{processsegmentid},{equipmentid},{lottype},{processitemdefinitionid},{siteid}"));
		}
		Processitem result = ContextManager.DirectEntityQuery<Processitem>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productdefinitionid},{processdefinitionid},{processsegmentid},{equipmentid},{lottype},{processitemdefinitionid},{siteid}");
		}
		return result;
	}

	public static Processitem SelectProcessItem(IDbContext dbContext, string productdefinitionid, string processdefinitionid, string processsegmentid, string equipmentid, string lottype, string processitemdefinitionid, string siteid)
	{
		string apiName = "SelectProcessItem";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productdefinitionid},{processdefinitionid},{processsegmentid},{equipmentid},{lottype},{processitemdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessItemSqlDatabase : _sqlSelectProcessItemOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", productdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSDEFINITIONID", processdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("LOTTYPE", lottype, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSITEMDEFINITIONID", processitemdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PROCESSITEM", $"{productdefinitionid},{processdefinitionid},{processsegmentid},{equipmentid},{lottype},{processitemdefinitionid},{siteid}"));
		}
		Processitem result = ContextManager.DirectEntityQuery<Processitem>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productdefinitionid},{processdefinitionid},{processsegmentid},{equipmentid},{lottype},{processitemdefinitionid},{siteid}");
		}
		return result;
	}

	public static Processitem SelectProcessItem4Update(IDbContext dbContext, string productdefinitionid, string processdefinitionid, string processsegmentid, string equipmentid, string lottype, string processitemdefinitionid, string siteid)
	{
		string apiName = "SelectProcessItem4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productdefinitionid},{processdefinitionid},{processsegmentid},{equipmentid},{lottype},{processitemdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessItem4UpdateSqlDatabase : _sqlSelectProcessItem4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", productdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSDEFINITIONID", processdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("LOTTYPE", lottype, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSITEMDEFINITIONID", processitemdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PROCESSITEM", $"{productdefinitionid},{processdefinitionid},{processsegmentid},{equipmentid},{lottype},{processitemdefinitionid},{siteid}"));
		}
		Processitem result = ContextManager.DirectEntityQuery<Processitem>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productdefinitionid},{processdefinitionid},{processsegmentid},{equipmentid},{lottype},{processitemdefinitionid},{siteid}");
		}
		return result;
	}

	public static int UpsertProcessItem(IDbContext dbContext, RequestType requestType, Processitem[] processItemList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateProcessItemInternal(dbContext, processItemList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateProcessItem(dbContext, processItemList, optionSet, saveHist), 
			RequestType.DELETE => DeleteProcessItem(dbContext, processItemList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteProcessItem(dbContext, processItemList, optionSet, saveHist), 
			_ => RealDeleteProcessItem(dbContext, processItemList, optionSet, saveHist), 
		};
	}

	private static int CreateProcessItemInternal(IDbContext dbContext, Processitem[] processItemList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processItemList", processItemList);
		string text = "CreateProcessItem";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processitem> list = new List<Processitem>();
		foreach (Processitem obj in processItemList)
		{
			Processitem processitem = new Processitem();
			obj.CopyColumsTo(processitem);
			processitem.Activity = text;
			processitem.CheckEntityUsable();
			obj.CopyCommonField(processitem, systemTime, dbContext.Tid, isCreate: true);
			list.Add(processitem);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateProcessItem(IDbContext dbContext, Processitem[] processItemList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processItemList", processItemList);
		string text = "UpdateProcessItem";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processitem> list = new List<Processitem>();
		foreach (Processitem processitem in processItemList)
		{
			Processitem processItem4Update = GetProcessItem4Update(dbContext, processitem.Productdefinitionid, processitem.Processdefinitionid, processitem.Processsegmentid, processitem.Equipmentid, processitem.Lottype, processitem.Processitemdefinitionid, processitem.Siteid);
			if (processItem4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processitem), $"{processitem.Productdefinitionid},{processitem.Processdefinitionid},{processitem.Processsegmentid},{processitem.Equipmentid},{processitem.Lottype},{processitem.Processitemdefinitionid},{processitem.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Processitem), $"{processitem.Productdefinitionid},{processitem.Processdefinitionid},{processitem.Processsegmentid},{processitem.Equipmentid},{processitem.Lottype},{processitem.Processitemdefinitionid},{processitem.Siteid}", processItem4Update.Isusable);
			string activity = processItem4Update.Activity;
			string customactivity = processItem4Update.Customactivity;
			string isusable = processItem4Update.Isusable;
			DateTime? createtime = processItem4Update.Createtime;
			string creator = processItem4Update.Creator;
			processitem.CopyColumsTo(processItem4Update);
			processItem4Update.Prevactivity = activity;
			processItem4Update.Prevcustomactivity = customactivity;
			processItem4Update.Creator = creator;
			processItem4Update.Createtime = createtime;
			processItem4Update.Isusable = isusable;
			processItem4Update.Activity = text;
			processitem.CopyCommonField(processItem4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(processItem4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteProcessItem(IDbContext dbContext, Processitem[] processItemList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processItemList", processItemList);
		string text = "DeleteProcessItem";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processitem> list = new List<Processitem>();
		foreach (Processitem processitem in processItemList)
		{
			Processitem processItem4Update = GetProcessItem4Update(dbContext, processitem.Productdefinitionid, processitem.Processdefinitionid, processitem.Processsegmentid, processitem.Equipmentid, processitem.Lottype, processitem.Processitemdefinitionid, processitem.Siteid);
			if (processItem4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processitem), $"{processitem.Productdefinitionid},{processitem.Processdefinitionid},{processitem.Processsegmentid},{processitem.Equipmentid},{processitem.Lottype},{processitem.Processitemdefinitionid},{processitem.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Processitem), $"{processitem.Productdefinitionid},{processitem.Processdefinitionid},{processitem.Processsegmentid},{processitem.Equipmentid},{processitem.Lottype},{processitem.Processitemdefinitionid},{processitem.Siteid}", processItem4Update.Isusable);
			processItem4Update.Isusable = "UnUsable";
			processitem.CopyCommonFieldUpdatePrev(processItem4Update, systemTime, dbContext.Tid, text);
			processitem.CopyExtensionCollection(processItem4Update);
			list.Add(processItem4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteProcessItem(IDbContext dbContext, Processitem[] processItemList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processItemList", processItemList);
		string text = "UnDeleteProcessItem";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processitem> list = new List<Processitem>();
		foreach (Processitem processitem in processItemList)
		{
			Processitem processItem4Update = GetProcessItem4Update(dbContext, processitem.Productdefinitionid, processitem.Processdefinitionid, processitem.Processsegmentid, processitem.Equipmentid, processitem.Lottype, processitem.Processitemdefinitionid, processitem.Siteid);
			if (processItem4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processitem), $"{processitem.Productdefinitionid},{processitem.Processdefinitionid},{processitem.Processsegmentid},{processitem.Equipmentid},{processitem.Lottype},{processitem.Processitemdefinitionid},{processitem.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Processitem), $"{processitem.Productdefinitionid},{processitem.Processdefinitionid},{processitem.Processsegmentid},{processitem.Equipmentid},{processitem.Lottype},{processitem.Processitemdefinitionid},{processitem.Siteid}", processItem4Update.Isusable);
			processItem4Update.Isusable = "Usable";
			processitem.CopyCommonFieldUpdatePrev(processItem4Update, systemTime, dbContext.Tid, text);
			processitem.CopyExtensionCollection(processItem4Update);
			list.Add(processItem4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteProcessItem(IDbContext dbContext, Processitem[] processItemList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processItemList", processItemList);
		string text = "RealDeleteProcessItem";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processitem> list = new List<Processitem>();
		foreach (Processitem processitem in processItemList)
		{
			Processitem processItem4Update = GetProcessItem4Update(dbContext, processitem.Productdefinitionid, processitem.Processdefinitionid, processitem.Processsegmentid, processitem.Equipmentid, processitem.Lottype, processitem.Processitemdefinitionid, processitem.Siteid);
			if (processItem4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processitem), $"{processitem.Productdefinitionid},{processitem.Processdefinitionid},{processitem.Processsegmentid},{processitem.Equipmentid},{processitem.Lottype},{processitem.Processitemdefinitionid},{processitem.Siteid}");
			}
			processitem.CopyCommonFieldUpdatePrev(processItem4Update, systemTime, dbContext.Tid, text);
			processitem.CopyExtensionCollection(processItem4Update);
			list.Add(processItem4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
