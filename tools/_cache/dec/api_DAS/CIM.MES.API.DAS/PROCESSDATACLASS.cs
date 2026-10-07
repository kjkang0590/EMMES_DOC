using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.DAS;

[MESAPI]
public class PROCESSDATACLASS
{
	private static string _sqlGetProcessDataClassSqlDatabase = "SELECT * FROM CIM_PROCESSDATACLASS WHERE PROCESSDATACLASSID=@PROCESSDATACLASSID AND SITEID=@SITEID";

	private static string _sqlGetProcessDataClass4UpdateSqlDatabase = "SELECT * FROM CIM_PROCESSDATACLASS WITH(UPDLOCK) WHERE PROCESSDATACLASSID=@PROCESSDATACLASSID AND SITEID=@SITEID";

	private static string _sqlSelectProcessDataClassSqlDatabase = "SELECT * FROM CIM_PROCESSDATACLASS WHERE PROCESSDATACLASSID=@PROCESSDATACLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessDataClass4UpdateSqlDatabase = "SELECT * FROM CIM_PROCESSDATACLASS WITH(UPDLOCK) WHERE PROCESSDATACLASSID=@PROCESSDATACLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetProcessDataClassOracleDatabase = "SELECT * FROM CIM_PROCESSDATACLASS WHERE PROCESSDATACLASSID=:PROCESSDATACLASSID AND SITEID=:SITEID";

	private static string _sqlGetProcessDataClass4UpdateOracleDatabase = "SELECT * FROM CIM_PROCESSDATACLASS WHERE PROCESSDATACLASSID=:PROCESSDATACLASSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectProcessDataClassOracleDatabase = "SELECT * FROM CIM_PROCESSDATACLASS WHERE PROCESSDATACLASSID=:PROCESSDATACLASSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessDataClass4UpdateOracleDatabase = "SELECT * FROM CIM_PROCESSDATACLASS WHERE PROCESSDATACLASSID=:PROCESSDATACLASSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Processdataclass);

	public static Processdataclass GetProcessDataClass(IDbContext dbContext, string processdataclassid, string siteid)
	{
		string apiName = "GetProcessDataClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processdataclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProcessDataClassSqlDatabase : _sqlGetProcessDataClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSDATACLASSID", processdataclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PROCESSDATACLASS", $"{processdataclassid},{siteid}"));
		}
		Processdataclass? result = ContextManager.DirectEntityQuery<Processdataclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processdataclassid},{siteid}");
		}
		return result;
	}

	public static Processdataclass GetProcessDataClass4Update(IDbContext dbContext, string processdataclassid, string siteid)
	{
		string apiName = "GetProcessDataClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processdataclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProcessDataClass4UpdateSqlDatabase : _sqlGetProcessDataClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSDATACLASSID", processdataclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PROCESSDATACLASS", $"{processdataclassid},{siteid}"));
		}
		Processdataclass? result = ContextManager.DirectEntityQuery<Processdataclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processdataclassid},{siteid}");
		}
		return result;
	}

	public static Processdataclass SelectProcessDataClass(IDbContext dbContext, string processdataclassid, string siteid)
	{
		string apiName = "SelectProcessDataClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processdataclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessDataClassSqlDatabase : _sqlSelectProcessDataClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSDATACLASSID", processdataclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PROCESSDATACLASS", $"{processdataclassid},{siteid}"));
		}
		Processdataclass? result = ContextManager.DirectEntityQuery<Processdataclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processdataclassid},{siteid}");
		}
		return result;
	}

	public static Processdataclass SelectProcessDataClass4Update(IDbContext dbContext, string processdataclassid, string siteid)
	{
		string apiName = "SelectProcessDataClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processdataclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessDataClass4UpdateSqlDatabase : _sqlSelectProcessDataClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSDATACLASSID", processdataclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PROCESSDATACLASS", $"{processdataclassid},{siteid}"));
		}
		Processdataclass? result = ContextManager.DirectEntityQuery<Processdataclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processdataclassid},{siteid}");
		}
		return result;
	}

	public static int UpsertProcessDataClass(IDbContext dbContext, RequestType requestType, Processdataclass[] processDataClassList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateProcessDataClassInternal(dbContext, processDataClassList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateProcessDataClass(dbContext, processDataClassList, optionSet, saveHist), 
			RequestType.DELETE => DeleteProcessDataClass(dbContext, processDataClassList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteProcessDataClass(dbContext, processDataClassList, optionSet, saveHist), 
			_ => RealDeleteProcessDataClass(dbContext, processDataClassList, optionSet, saveHist), 
		};
	}

	private static int CreateProcessDataClassInternal(IDbContext dbContext, Processdataclass[] processDataClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processDataClassList", processDataClassList);
		string text = "CreateProcessDataClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processdataclass> list = new List<Processdataclass>();
		foreach (Processdataclass obj in processDataClassList)
		{
			Processdataclass processdataclass = new Processdataclass();
			obj.CopyColumsTo(processdataclass);
			processdataclass.Activity = text;
			processdataclass.CheckEntityUsable();
			obj.CopyCommonField(processdataclass, systemTime, dbContext.Tid, isCreate: true);
			list.Add(processdataclass);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateProcessDataClass(IDbContext dbContext, Processdataclass[] processDataClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processDataClassList", processDataClassList);
		string text = "UpdateProcessDataClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processdataclass> list = new List<Processdataclass>();
		foreach (Processdataclass processdataclass in processDataClassList)
		{
			Processdataclass processDataClass4Update = GetProcessDataClass4Update(dbContext, processdataclass.Processdataclassid, processdataclass.Siteid);
			if (processDataClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processdataclass), $"{processdataclass.Processdataclassid},{processdataclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Processdataclass), $"{processdataclass.Processdataclassid},{processdataclass.Siteid}", processDataClass4Update.Isusable);
			string activity = processDataClass4Update.Activity;
			string customactivity = processDataClass4Update.Customactivity;
			string isusable = processDataClass4Update.Isusable;
			DateTime? createtime = processDataClass4Update.Createtime;
			string creator = processDataClass4Update.Creator;
			processdataclass.CopyColumsTo(processDataClass4Update);
			processDataClass4Update.Prevactivity = activity;
			processDataClass4Update.Prevcustomactivity = customactivity;
			processDataClass4Update.Creator = creator;
			processDataClass4Update.Createtime = createtime;
			processDataClass4Update.Isusable = isusable;
			processDataClass4Update.Activity = text;
			processdataclass.CopyCommonField(processDataClass4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(processDataClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteProcessDataClass(IDbContext dbContext, Processdataclass[] processDataClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processDataClassList", processDataClassList);
		string text = "DeleteProcessDataClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processdataclass> list = new List<Processdataclass>();
		foreach (Processdataclass processdataclass in processDataClassList)
		{
			Processdataclass processDataClass4Update = GetProcessDataClass4Update(dbContext, processdataclass.Processdataclassid, processdataclass.Siteid);
			if (processDataClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processdataclass), $"{processdataclass.Processdataclassid},{processdataclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Processdataclass), $"{processdataclass.Processdataclassid},{processdataclass.Siteid}", processDataClass4Update.Isusable);
			processDataClass4Update.Isusable = "UnUsable";
			processdataclass.CopyCommonFieldUpdatePrev(processDataClass4Update, systemTime, dbContext.Tid, text);
			processdataclass.CopyExtensionCollection(processDataClass4Update);
			list.Add(processDataClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteProcessDataClass(IDbContext dbContext, Processdataclass[] processDataClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processDataClassList", processDataClassList);
		string text = "UnDeleteProcessDataClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processdataclass> list = new List<Processdataclass>();
		foreach (Processdataclass processdataclass in processDataClassList)
		{
			Processdataclass processDataClass4Update = GetProcessDataClass4Update(dbContext, processdataclass.Processdataclassid, processdataclass.Siteid);
			if (processDataClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processdataclass), $"{processdataclass.Processdataclassid},{processdataclass.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Processdataclass), $"{processdataclass.Processdataclassid},{processdataclass.Siteid}", processDataClass4Update.Isusable);
			processDataClass4Update.Isusable = "Usable";
			processdataclass.CopyCommonFieldUpdatePrev(processDataClass4Update, systemTime, dbContext.Tid, text);
			processdataclass.CopyExtensionCollection(processDataClass4Update);
			list.Add(processDataClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteProcessDataClass(IDbContext dbContext, Processdataclass[] processDataClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processDataClassList", processDataClassList);
		string text = "RealDeleteProcessDataClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processdataclass> list = new List<Processdataclass>();
		foreach (Processdataclass processdataclass in processDataClassList)
		{
			Processdataclass processDataClass4Update = GetProcessDataClass4Update(dbContext, processdataclass.Processdataclassid, processdataclass.Siteid);
			if (processDataClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processdataclass), $"{processdataclass.Processdataclassid},{processdataclass.Siteid}");
			}
			processdataclass.CopyCommonFieldUpdatePrev(processDataClass4Update, systemTime, dbContext.Tid, text);
			processdataclass.CopyExtensionCollection(processDataClass4Update);
			list.Add(processDataClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
