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
public class TRACEDATA
{
	private static string _sqlGetTraceDataSqlDatabase = "SELECT * FROM CIM_TRACEDATA WHERE TRACEDATAID=@TRACEDATAID AND SITEID=@SITEID";

	private static string _sqlGetTraceData4UpdateSqlDatabase = "SELECT * FROM CIM_TRACEDATA WITH(UPDLOCK) WHERE TRACEDATAID=@TRACEDATAID AND SITEID=@SITEID";

	private static string _sqlSelectTraceDataSqlDatabase = "SELECT * FROM CIM_TRACEDATA WHERE TRACEDATAID=@TRACEDATAID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectTraceData4UpdateSqlDatabase = "SELECT * FROM CIM_TRACEDATA WITH(UPDLOCK) WHERE TRACEDATAID=@TRACEDATAID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetTraceDataOracleDatabase = "SELECT * FROM CIM_TRACEDATA WHERE TRACEDATAID=:TRACEDATAID AND SITEID=:SITEID";

	private static string _sqlGetTraceData4UpdateOracleDatabase = "SELECT * FROM CIM_TRACEDATA WHERE TRACEDATAID=:TRACEDATAID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectTraceDataOracleDatabase = "SELECT * FROM CIM_TRACEDATA WHERE TRACEDATAID=:TRACEDATAID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectTraceData4UpdateOracleDatabase = "SELECT * FROM CIM_TRACEDATA WHERE TRACEDATAID=:TRACEDATAID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Tracedata);

	public static int CreateTraceData(IDbContext dbContext, Tracedata traceData, Dictionary<string, string> inputData)
	{
		IList<Tracedataparameter> list = TRACEDATAPARAMETER.SelectTraceDataParameter(dbContext, traceData.Tracedatadefinitionid, traceData.Siteid);
		if (list == null || list.Count < 1)
		{
			return 0;
		}
		TextInfo textInfo = Thread.CurrentThread.CurrentCulture.TextInfo;
		foreach (Tracedataparameter item in list)
		{
			if (inputData.ContainsKey(item.Tracedataparameterid))
			{
				traceData.GetType().GetProperty(textInfo.ToTitleCase(item.Datamappingcolumn.ToLower())).SetValue(traceData, inputData[item.Tracedataparameterid], null);
			}
		}
		return CreateTraceDataInternal(dbContext, new Tracedata[1] { traceData }, null, saveHist: false);
	}

	public static Tracedata GetTraceData(IDbContext dbContext, long tracedataid, string siteid)
	{
		string apiName = "GetTraceData";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tracedataid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetTraceDataSqlDatabase : _sqlGetTraceDataOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TRACEDATAID", tracedataid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_TRACEDATA", $"{tracedataid},{siteid}"));
		}
		Tracedata? result = ContextManager.DirectEntityQuery<Tracedata>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tracedataid},{siteid}");
		}
		return result;
	}

	public static Tracedata GetTraceData4Update(IDbContext dbContext, long tracedataid, string siteid)
	{
		string apiName = "GetTraceData4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tracedataid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetTraceData4UpdateSqlDatabase : _sqlGetTraceData4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TRACEDATAID", tracedataid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_TRACEDATA", $"{tracedataid},{siteid}"));
		}
		Tracedata? result = ContextManager.DirectEntityQuery<Tracedata>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tracedataid},{siteid}");
		}
		return result;
	}

	public static Tracedata SelectTraceData(IDbContext dbContext, long tracedataid, string siteid)
	{
		string apiName = "SelectTraceData";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tracedataid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectTraceDataSqlDatabase : _sqlSelectTraceDataOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TRACEDATAID", tracedataid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_TRACEDATA", $"{tracedataid},{siteid}"));
		}
		Tracedata? result = ContextManager.DirectEntityQuery<Tracedata>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tracedataid},{siteid}");
		}
		return result;
	}

	public static Tracedata SelectTraceData4Update(IDbContext dbContext, long tracedataid, string siteid)
	{
		string apiName = "SelectTraceData4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tracedataid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectTraceData4UpdateSqlDatabase : _sqlSelectTraceData4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TRACEDATAID", tracedataid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_TRACEDATA", $"{tracedataid},{siteid}"));
		}
		Tracedata? result = ContextManager.DirectEntityQuery<Tracedata>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tracedataid},{siteid}");
		}
		return result;
	}

	public static int UpsertTraceData(IDbContext dbContext, RequestType requestType, Tracedata[] traceDataList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateTraceDataInternal(dbContext, traceDataList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateTraceData(dbContext, traceDataList, optionSet, saveHist), 
			RequestType.DELETE => DeleteTraceData(dbContext, traceDataList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteTraceData(dbContext, traceDataList, optionSet, saveHist), 
			_ => RealDeleteTraceData(dbContext, traceDataList, optionSet, saveHist), 
		};
	}

	private static int CreateTraceDataInternal(IDbContext dbContext, Tracedata[] traceDataList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceDataList", traceDataList);
		string text = "CreateTraceData";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tracedata> list = new List<Tracedata>();
		foreach (Tracedata obj in traceDataList)
		{
			Tracedata tracedata = new Tracedata();
			obj.CopyColumsTo(tracedata);
			tracedata.Activity = text;
			tracedata.CheckEntityUsable();
			obj.CopyCommonField(tracedata, systemTime, dbContext.Tid, isCreate: true);
			list.Add(tracedata);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateTraceData(IDbContext dbContext, Tracedata[] traceDataList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceDataList", traceDataList);
		string text = "UpdateTraceData";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tracedata> list = new List<Tracedata>();
		foreach (Tracedata tracedata in traceDataList)
		{
			Tracedata traceData4Update = GetTraceData4Update(dbContext, tracedata.Tracedataid, tracedata.Siteid);
			if (traceData4Update == null)
			{
				throw new EntityNotFoundException(typeof(Tracedata), $"{tracedata.Tracedataid},{tracedata.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Tracedata), $"{tracedata.Tracedataid},{tracedata.Siteid}", traceData4Update.Isusable);
			string activity = traceData4Update.Activity;
			string customactivity = traceData4Update.Customactivity;
			string isusable = traceData4Update.Isusable;
			DateTime? createtime = traceData4Update.Createtime;
			string creator = traceData4Update.Creator;
			tracedata.CopyColumsTo(traceData4Update);
			traceData4Update.Prevactivity = activity;
			traceData4Update.Prevcustomactivity = customactivity;
			traceData4Update.Creator = creator;
			traceData4Update.Createtime = createtime;
			traceData4Update.Isusable = isusable;
			traceData4Update.Activity = text;
			tracedata.CopyCommonField(traceData4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(traceData4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteTraceData(IDbContext dbContext, Tracedata[] traceDataList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceDataList", traceDataList);
		string text = "DeleteTraceData";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tracedata> list = new List<Tracedata>();
		foreach (Tracedata tracedata in traceDataList)
		{
			Tracedata traceData4Update = GetTraceData4Update(dbContext, tracedata.Tracedataid, tracedata.Siteid);
			if (traceData4Update == null)
			{
				throw new EntityNotFoundException(typeof(Tracedata), $"{tracedata.Tracedataid},{tracedata.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Tracedata), $"{tracedata.Tracedataid},{tracedata.Siteid}", traceData4Update.Isusable);
			traceData4Update.Isusable = "UnUsable";
			tracedata.CopyCommonFieldUpdatePrev(traceData4Update, systemTime, dbContext.Tid, text);
			tracedata.CopyExtensionCollection(traceData4Update);
			list.Add(traceData4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteTraceData(IDbContext dbContext, Tracedata[] traceDataList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceDataList", traceDataList);
		string text = "UnDeleteTraceData";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tracedata> list = new List<Tracedata>();
		foreach (Tracedata tracedata in traceDataList)
		{
			Tracedata traceData4Update = GetTraceData4Update(dbContext, tracedata.Tracedataid, tracedata.Siteid);
			if (traceData4Update == null)
			{
				throw new EntityNotFoundException(typeof(Tracedata), $"{tracedata.Tracedataid},{tracedata.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Tracedata), $"{tracedata.Tracedataid},{tracedata.Siteid}", traceData4Update.Isusable);
			traceData4Update.Isusable = "Usable";
			tracedata.CopyCommonFieldUpdatePrev(traceData4Update, systemTime, dbContext.Tid, text);
			tracedata.CopyExtensionCollection(traceData4Update);
			list.Add(traceData4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteTraceData(IDbContext dbContext, Tracedata[] traceDataList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceDataList", traceDataList);
		string text = "RealDeleteTraceData";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tracedata> list = new List<Tracedata>();
		foreach (Tracedata tracedata in traceDataList)
		{
			Tracedata traceData4Update = GetTraceData4Update(dbContext, tracedata.Tracedataid, tracedata.Siteid);
			if (traceData4Update == null)
			{
				throw new EntityNotFoundException(typeof(Tracedata), $"{tracedata.Tracedataid},{tracedata.Siteid}");
			}
			tracedata.CopyCommonFieldUpdatePrev(traceData4Update, systemTime, dbContext.Tid, text);
			tracedata.CopyExtensionCollection(traceData4Update);
			list.Add(traceData4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
