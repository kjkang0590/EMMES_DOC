using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.DAS;

[MESAPI]
public class PROCESSDATA
{
	private static string _sqlGetProcessDataSqlDatabase = "SELECT * FROM CIM_PROCESSDATA WHERE PROCESSDATAID=@PROCESSDATAID AND SITEID=@SITEID";

	private static string _sqlGetProcessData4UpdateSqlDatabase = "SELECT * FROM CIM_PROCESSDATA WITH(UPDLOCK) WHERE PROCESSDATAID=@PROCESSDATAID AND SITEID=@SITEID";

	private static string _sqlSelectProcessDataSqlDatabase = "SELECT * FROM CIM_PROCESSDATA WHERE PROCESSDATAID=@PROCESSDATAID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessData4UpdateSqlDatabase = "SELECT * FROM CIM_PROCESSDATA WITH(UPDLOCK) WHERE PROCESSDATAID=@PROCESSDATAID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetProcessDataOracleDatabase = "SELECT * FROM CIM_PROCESSDATA WHERE PROCESSDATAID=:PROCESSDATAID AND SITEID=:SITEID";

	private static string _sqlGetProcessData4UpdateOracleDatabase = "SELECT * FROM CIM_PROCESSDATA WHERE PROCESSDATAID=:PROCESSDATAID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectProcessDataOracleDatabase = "SELECT * FROM CIM_PROCESSDATA WHERE PROCESSDATAID=:PROCESSDATAID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessData4UpdateOracleDatabase = "SELECT * FROM CIM_PROCESSDATA WHERE PROCESSDATAID=:PROCESSDATAID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Processdata);

	public static int CreateProcessData(IDbContext dbContext, Processdata processData, Dictionary<string, string> inputData)
	{
		IList<Processdataparameter> list = PROCESSDATAPARAMETER.SelectProcessDataParameterList(dbContext, processData.Processdatadefinitionid, processData.Siteid);
		if (list == null || list.Count < 1)
		{
			return 0;
		}
		TextInfo textInfo = Thread.CurrentThread.CurrentCulture.TextInfo;
		foreach (Processdataparameter item in list)
		{
			if (inputData.ContainsKey(item.Processdataparameterid))
			{
				processData.GetType().GetProperty(textInfo.ToTitleCase(item.Datamappingcolumn.ToLower())).SetValue(processData, inputData[item.Processdataparameterid], null);
			}
		}
		return CreateProcessDataInternal(dbContext, new Processdata[1] { processData }, null, saveHist: false);
	}

	public static Processdata GetProcessData(IDbContext dbContext, long processdataid, string siteid)
	{
		string apiName = "GetProcessData";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processdataid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProcessDataSqlDatabase : _sqlGetProcessDataOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSDATAID", processdataid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PROCESSDATA", $"{processdataid},{siteid}"));
		}
		Processdata? result = ContextManager.DirectEntityQuery<Processdata>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processdataid},{siteid}");
		}
		return result;
	}

	public static Processdata GetProcessData4Update(IDbContext dbContext, long processdataid, string siteid)
	{
		string apiName = "GetProcessData4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processdataid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProcessData4UpdateSqlDatabase : _sqlGetProcessData4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSDATAID", processdataid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PROCESSDATA", $"{processdataid},{siteid}"));
		}
		Processdata? result = ContextManager.DirectEntityQuery<Processdata>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processdataid},{siteid}");
		}
		return result;
	}

	public static Processdata SelectProcessData(IDbContext dbContext, long processdataid, string siteid)
	{
		string apiName = "SelectProcessData";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processdataid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessDataSqlDatabase : _sqlSelectProcessDataOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSDATAID", processdataid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PROCESSDATA", $"{processdataid},{siteid}"));
		}
		Processdata? result = ContextManager.DirectEntityQuery<Processdata>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processdataid},{siteid}");
		}
		return result;
	}

	public static Processdata SelectProcessData4Update(IDbContext dbContext, long processdataid, string siteid)
	{
		string apiName = "SelectProcessData4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processdataid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessData4UpdateSqlDatabase : _sqlSelectProcessData4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSDATAID", processdataid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PROCESSDATA", $"{processdataid},{siteid}"));
		}
		Processdata? result = ContextManager.DirectEntityQuery<Processdata>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processdataid},{siteid}");
		}
		return result;
	}

	public static int UpsertProcessData(IDbContext dbContext, RequestType requestType, Processdata[] processDataList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateProcessDataInternal(dbContext, processDataList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateProcessData(dbContext, processDataList, optionSet, saveHist), 
			RequestType.DELETE => DeleteProcessData(dbContext, processDataList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteProcessData(dbContext, processDataList, optionSet, saveHist), 
			_ => RealDeleteProcessData(dbContext, processDataList, optionSet, saveHist), 
		};
	}

	private static int CreateProcessDataInternal(IDbContext dbContext, Processdata[] processDataList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processDataList", processDataList);
		string text = "CreateProcessData";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processdata> list = new List<Processdata>();
		foreach (Processdata obj in processDataList)
		{
			Processdata processdata = new Processdata();
			obj.CopyColumsTo(processdata);
			processdata.Activity = text;
			processdata.CheckEntityUsable();
			obj.CopyCommonField(processdata, systemTime, dbContext.Tid, isCreate: true);
			list.Add(processdata);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateProcessData(IDbContext dbContext, Processdata[] processDataList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processDataList", processDataList);
		string text = "UpdateProcessData";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processdata> list = new List<Processdata>();
		foreach (Processdata processdata in processDataList)
		{
			Processdata processData4Update = GetProcessData4Update(dbContext, processdata.Processdataid, processdata.Siteid);
			if (processData4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processdata), $"{processdata.Processdataid},{processdata.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Processdata), $"{processdata.Processdataid},{processdata.Siteid}", processData4Update.Isusable);
			string activity = processData4Update.Activity;
			string customactivity = processData4Update.Customactivity;
			string isusable = processData4Update.Isusable;
			DateTime? createtime = processData4Update.Createtime;
			string creator = processData4Update.Creator;
			processdata.CopyColumsTo(processData4Update);
			processData4Update.Prevactivity = activity;
			processData4Update.Prevcustomactivity = customactivity;
			processData4Update.Creator = creator;
			processData4Update.Createtime = createtime;
			processData4Update.Isusable = isusable;
			processData4Update.Activity = text;
			processdata.CopyCommonField(processData4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(processData4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteProcessData(IDbContext dbContext, Processdata[] processDataList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processDataList", processDataList);
		string text = "DeleteProcessData";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processdata> list = new List<Processdata>();
		foreach (Processdata processdata in processDataList)
		{
			Processdata processData4Update = GetProcessData4Update(dbContext, processdata.Processdataid, processdata.Siteid);
			if (processData4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processdata), $"{processdata.Processdataid},{processdata.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Processdata), $"{processdata.Processdataid},{processdata.Siteid}", processData4Update.Isusable);
			processData4Update.Isusable = "UnUsable";
			processdata.CopyCommonFieldUpdatePrev(processData4Update, systemTime, dbContext.Tid, text);
			processdata.CopyExtensionCollection(processData4Update);
			list.Add(processData4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteProcessData(IDbContext dbContext, Processdata[] processDataList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processDataList", processDataList);
		string text = "UnDeleteProcessData";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processdata> list = new List<Processdata>();
		foreach (Processdata processdata in processDataList)
		{
			Processdata processData4Update = GetProcessData4Update(dbContext, processdata.Processdataid, processdata.Siteid);
			if (processData4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processdata), $"{processdata.Processdataid},{processdata.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Processdata), $"{processdata.Processdataid},{processdata.Siteid}", processData4Update.Isusable);
			processData4Update.Isusable = "Usable";
			processdata.CopyCommonFieldUpdatePrev(processData4Update, systemTime, dbContext.Tid, text);
			processdata.CopyExtensionCollection(processData4Update);
			list.Add(processData4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteProcessData(IDbContext dbContext, Processdata[] processDataList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processDataList", processDataList);
		string text = "RealDeleteProcessData";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processdata> list = new List<Processdata>();
		foreach (Processdata processdata in processDataList)
		{
			Processdata processData4Update = GetProcessData4Update(dbContext, processdata.Processdataid, processdata.Siteid);
			if (processData4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processdata), $"{processdata.Processdataid},{processdata.Siteid}");
			}
			processdata.CopyCommonFieldUpdatePrev(processData4Update, systemTime, dbContext.Tid, text);
			processdata.CopyExtensionCollection(processData4Update);
			list.Add(processData4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
