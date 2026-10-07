using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.PMS;

[MESAPI]
public class PROCESSSEGMENT
{
	private static string _sqlGetProcessSegmentSqlDatabase = "SELECT * FROM CIM_PROCESSSEGMENT WHERE PROCESSSEGMENTID=@PROCESSSEGMENTID AND SITEID=@SITEID";

	private static string _sqlGetProcessSegment4UpdateSqlDatabase = "SELECT * FROM CIM_PROCESSSEGMENT WITH(UPDLOCK) WHERE PROCESSSEGMENTID=@PROCESSSEGMENTID AND SITEID=@SITEID";

	private static string _sqlSelectProcessSegmentSqlDatabase = "SELECT * FROM CIM_PROCESSSEGMENT WHERE PROCESSSEGMENTID=@PROCESSSEGMENTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessSegment4UpdateSqlDatabase = "SELECT * FROM CIM_PROCESSSEGMENT WITH(UPDLOCK) WHERE PROCESSSEGMENTID=@PROCESSSEGMENTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetProcessSegmentOracleDatabase = "SELECT * FROM CIM_PROCESSSEGMENT WHERE PROCESSSEGMENTID=:PROCESSSEGMENTID AND SITEID=:SITEID";

	private static string _sqlGetProcessSegment4UpdateOracleDatabase = "SELECT * FROM CIM_PROCESSSEGMENT WHERE PROCESSSEGMENTID=:PROCESSSEGMENTID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectProcessSegmentOracleDatabase = "SELECT * FROM CIM_PROCESSSEGMENT WHERE PROCESSSEGMENTID=:PROCESSSEGMENTID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessSegment4UpdateOracleDatabase = "SELECT * FROM CIM_PROCESSSEGMENT WHERE PROCESSSEGMENTID=:PROCESSSEGMENTID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Processsegment);

	public static Processsegment GetProcessSegment(IDbContext dbContext, string processsegmentid, string siteid)
	{
		string apiName = "GetProcessSegment";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processsegmentid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProcessSegmentSqlDatabase : _sqlGetProcessSegmentOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PROCESSSEGMENT", $"{processsegmentid},{siteid}"));
		}
		Processsegment? result = ContextManager.DirectEntityQuery<Processsegment>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processsegmentid},{siteid}");
		}
		return result;
	}

	public static Processsegment GetProcessSegment4Update(IDbContext dbContext, string processsegmentid, string siteid)
	{
		string apiName = "GetProcessSegment4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processsegmentid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProcessSegment4UpdateSqlDatabase : _sqlGetProcessSegment4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PROCESSSEGMENT", $"{processsegmentid},{siteid}"));
		}
		Processsegment? result = ContextManager.DirectEntityQuery<Processsegment>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processsegmentid},{siteid}");
		}
		return result;
	}

	public static Processsegment SelectProcessSegment(IDbContext dbContext, string processsegmentid, string siteid)
	{
		string apiName = "SelectProcessSegment";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processsegmentid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessSegmentSqlDatabase : _sqlSelectProcessSegmentOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PROCESSSEGMENT", $"{processsegmentid},{siteid}"));
		}
		Processsegment? result = ContextManager.DirectEntityQuery<Processsegment>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processsegmentid},{siteid}");
		}
		return result;
	}

	public static Processsegment SelectProcessSegment4Update(IDbContext dbContext, string processsegmentid, string siteid)
	{
		string apiName = "SelectProcessSegment4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processsegmentid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessSegment4UpdateSqlDatabase : _sqlSelectProcessSegment4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PROCESSSEGMENT", $"{processsegmentid},{siteid}"));
		}
		Processsegment? result = ContextManager.DirectEntityQuery<Processsegment>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processsegmentid},{siteid}");
		}
		return result;
	}

	public static int UpsertProcessSegment(IDbContext dbContext, RequestType requestType, Processsegment[] processSegmentList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateProcessSegmentInternal(dbContext, processSegmentList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateProcessSegment(dbContext, processSegmentList, optionSet, saveHist), 
			RequestType.DELETE => DeleteProcessSegment(dbContext, processSegmentList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteProcessSegment(dbContext, processSegmentList, optionSet, saveHist), 
			_ => RealDeleteProcessSegment(dbContext, processSegmentList, optionSet, saveHist), 
		};
	}

	private static int CreateProcessSegmentInternal(IDbContext dbContext, Processsegment[] processSegmentList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processSegmentList", processSegmentList);
		string text = "CreateProcessSegment";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processsegment> list = new List<Processsegment>();
		foreach (Processsegment obj in processSegmentList)
		{
			Processsegment processsegment = new Processsegment();
			obj.CopyColumsTo(processsegment);
			processsegment.Activity = text;
			processsegment.CheckEntityUsable();
			obj.CopyCommonField(processsegment, systemTime, dbContext.Tid, isCreate: true);
			list.Add(processsegment);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateProcessSegment(IDbContext dbContext, Processsegment[] processSegmentList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processSegmentList", processSegmentList);
		string text = "UpdateProcessSegment";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processsegment> list = new List<Processsegment>();
		foreach (Processsegment processsegment in processSegmentList)
		{
			Processsegment processSegment4Update = GetProcessSegment4Update(dbContext, processsegment.Processsegmentid, processsegment.Siteid);
			if (processSegment4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processsegment), $"{processsegment.Processsegmentid},{processsegment.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Processsegment), $"{processsegment.Processsegmentid},{processsegment.Siteid}", processSegment4Update.Isusable);
			string activity = processSegment4Update.Activity;
			string customactivity = processSegment4Update.Customactivity;
			string isusable = processSegment4Update.Isusable;
			DateTime? createtime = processSegment4Update.Createtime;
			string creator = processSegment4Update.Creator;
			processsegment.CopyColumsTo(processSegment4Update);
			processSegment4Update.Prevactivity = activity;
			processSegment4Update.Prevcustomactivity = customactivity;
			processSegment4Update.Creator = creator;
			processSegment4Update.Createtime = createtime;
			processSegment4Update.Isusable = isusable;
			processSegment4Update.Activity = text;
			processsegment.CopyCommonField(processSegment4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(processSegment4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteProcessSegment(IDbContext dbContext, Processsegment[] processSegmentList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processSegmentList", processSegmentList);
		string text = "DeleteProcessSegment";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processsegment> list = new List<Processsegment>();
		foreach (Processsegment processsegment in processSegmentList)
		{
			Processsegment processSegment4Update = GetProcessSegment4Update(dbContext, processsegment.Processsegmentid, processsegment.Siteid);
			if (processSegment4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processsegment), $"{processsegment.Processsegmentid},{processsegment.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Processsegment), $"{processsegment.Processsegmentid},{processsegment.Siteid}", processSegment4Update.Isusable);
			processSegment4Update.Isusable = "UnUsable";
			processsegment.CopyCommonFieldUpdatePrev(processSegment4Update, systemTime, dbContext.Tid, text);
			processsegment.CopyExtensionCollection(processSegment4Update);
			list.Add(processSegment4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteProcessSegment(IDbContext dbContext, Processsegment[] processSegmentList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processSegmentList", processSegmentList);
		string text = "UnDeleteProcessSegment";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processsegment> list = new List<Processsegment>();
		foreach (Processsegment processsegment in processSegmentList)
		{
			Processsegment processSegment4Update = GetProcessSegment4Update(dbContext, processsegment.Processsegmentid, processsegment.Siteid);
			if (processSegment4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processsegment), $"{processsegment.Processsegmentid},{processsegment.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Processsegment), $"{processsegment.Processsegmentid},{processsegment.Siteid}", processSegment4Update.Isusable);
			processSegment4Update.Isusable = "Usable";
			processsegment.CopyCommonFieldUpdatePrev(processSegment4Update, systemTime, dbContext.Tid, text);
			processsegment.CopyExtensionCollection(processSegment4Update);
			list.Add(processSegment4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteProcessSegment(IDbContext dbContext, Processsegment[] processSegmentList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processSegmentList", processSegmentList);
		string text = "RealDeleteProcessSegment";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processsegment> list = new List<Processsegment>();
		foreach (Processsegment processsegment in processSegmentList)
		{
			Processsegment processSegment4Update = GetProcessSegment4Update(dbContext, processsegment.Processsegmentid, processsegment.Siteid);
			if (processSegment4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processsegment), $"{processsegment.Processsegmentid},{processsegment.Siteid}");
			}
			processsegment.CopyCommonFieldUpdatePrev(processSegment4Update, systemTime, dbContext.Tid, text);
			processsegment.CopyExtensionCollection(processSegment4Update);
			list.Add(processSegment4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static IList<Processsegment> SelectNextProcessSegmentList(IDbContext dbContext, string topProcessDefinitionId, string processNodeId, string processPathType, string siteId)
	{
		string apiName = "SelectNextProcessSegmentList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{topProcessDefinitionId}.{processNodeId}.{processPathType}.{siteId}");
		}
		List<Processsegment> list = new List<Processsegment>();
		foreach (Processnode item in PROCESSNODE.SelectNextSegmentNodeList(dbContext, topProcessDefinitionId, processNodeId, processPathType, siteId))
		{
			Processsegment processsegment = SelectProcessSegment(dbContext, item.Processsegmentid, siteId);
			if (processsegment != null)
			{
				list.Add(processsegment);
			}
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{topProcessDefinitionId}.{processNodeId}.{processPathType}.{siteId}");
		}
		return list;
	}

	public static Processsegment SelectNextProcessSegmentSingle(IDbContext dbContext, string topProcessDefinitionId, string processNodeId, string pathType, string siteId)
	{
		string apiName = "SelectNextProcessSegmentSingle";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{topProcessDefinitionId}.{processNodeId}.{pathType}.{siteId}");
		}
		Processnode processnode = PROCESSNODE.SelectNextSegmentNodeSingle(dbContext, topProcessDefinitionId, processNodeId, pathType, siteId);
		Processsegment result = null;
		if (processnode != null)
		{
			result = SelectProcessSegment(dbContext, processnode.Processsegmentid, siteId);
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{topProcessDefinitionId}.{processNodeId}.{pathType}.{siteId}");
		}
		return result;
	}

	public static IList<Processsegment> SelectProcessSegmentList(IDbContext dbContext, string topProcessDefinitionId, string siteId)
	{
		string apiName = "SelectProcessSegmentList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{topProcessDefinitionId}.{siteId}");
		}
		List<Processsegment> list = new List<Processsegment>();
		foreach (Processnode item in PROCESSNODE.SelectProcessNodeList(dbContext, topProcessDefinitionId, siteId, "S", searchSubProcess: true))
		{
			Processsegment processsegment = SelectProcessSegment(dbContext, item.Processsegmentid, siteId);
			if (processsegment != null)
			{
				list.Add(processsegment);
			}
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{topProcessDefinitionId}.{siteId}");
		}
		return list;
	}
}
