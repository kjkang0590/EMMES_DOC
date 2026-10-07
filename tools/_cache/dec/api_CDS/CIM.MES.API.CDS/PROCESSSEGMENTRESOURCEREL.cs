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
public class PROCESSSEGMENTRESOURCEREL
{
	private static string _sqlGetProcessSegmentResourceRelSqlDatabase = "SELECT * FROM CIM_PROCESSSEGMENTRESOURCEREL WHERE PROCESSSEGMENTID=@PROCESSSEGMENTID AND RESOURCEID=@RESOURCEID AND PRODUCTDEFINITIONID=@PRODUCTDEFINITIONID AND PROCESSDEFINITIONID=@PROCESSDEFINITIONID AND WORKSETID=@WORKSETID AND SITEID=@SITEID";

	private static string _sqlGetProcessSegmentResourceRel4UpdateSqlDatabase = "SELECT * FROM CIM_PROCESSSEGMENTRESOURCEREL WITH(UPDLOCK) WHERE PROCESSSEGMENTID=@PROCESSSEGMENTID AND RESOURCEID=@RESOURCEID AND PRODUCTDEFINITIONID=@PRODUCTDEFINITIONID AND PROCESSDEFINITIONID=@PROCESSDEFINITIONID AND WORKSETID=@WORKSETID AND SITEID=@SITEID";

	private static string _sqlSelectProcessSegmentResourceRelSqlDatabase = "SELECT * FROM CIM_PROCESSSEGMENTRESOURCEREL WHERE PROCESSSEGMENTID=@PROCESSSEGMENTID AND RESOURCEID=@RESOURCEID AND PRODUCTDEFINITIONID=@PRODUCTDEFINITIONID AND PROCESSDEFINITIONID=@PROCESSDEFINITIONID AND WORKSETID=@WORKSETID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessSegmentResourceRel4UpdateSqlDatabase = "SELECT * FROM CIM_PROCESSSEGMENTRESOURCEREL WITH(UPDLOCK) WHERE PROCESSSEGMENTID=@PROCESSSEGMENTID AND RESOURCEID=@RESOURCEID AND PRODUCTDEFINITIONID=@PRODUCTDEFINITIONID AND PROCESSDEFINITIONID=@PROCESSDEFINITIONID AND WORKSETID=@WORKSETID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetProcessSegmentResourceRelOracleDatabase = "SELECT * FROM CIM_PROCESSSEGMENTRESOURCEREL WHERE PROCESSSEGMENTID=:PROCESSSEGMENTID AND RESOURCEID=:RESOURCEID AND PRODUCTDEFINITIONID=:PRODUCTDEFINITIONID AND PROCESSDEFINITIONID=:PROCESSDEFINITIONID AND WORKSETID=:WORKSETID AND SITEID=:SITEID";

	private static string _sqlGetProcessSegmentResourceRel4UpdateOracleDatabase = "SELECT * FROM CIM_PROCESSSEGMENTRESOURCEREL WHERE PROCESSSEGMENTID=:PROCESSSEGMENTID AND RESOURCEID=:RESOURCEID AND PRODUCTDEFINITIONID=:PRODUCTDEFINITIONID AND PROCESSDEFINITIONID=:PROCESSDEFINITIONID AND WORKSETID=:WORKSETID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectProcessSegmentResourceRelOracleDatabase = "SELECT * FROM CIM_PROCESSSEGMENTRESOURCEREL WHERE PROCESSSEGMENTID=:PROCESSSEGMENTID AND RESOURCEID=:RESOURCEID AND PRODUCTDEFINITIONID=:PRODUCTDEFINITIONID AND PROCESSDEFINITIONID=:PROCESSDEFINITIONID AND WORKSETID=:WORKSETID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessSegmentResourceRel4UpdateOracleDatabase = "SELECT * FROM CIM_PROCESSSEGMENTRESOURCEREL WHERE PROCESSSEGMENTID=:PROCESSSEGMENTID AND RESOURCEID=:RESOURCEID AND PRODUCTDEFINITIONID=:PRODUCTDEFINITIONID AND PROCESSDEFINITIONID=:PROCESSDEFINITIONID AND WORKSETID=:WORKSETID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Processsegmentresourcerel);

	public static Processsegmentresourcerel GetProcessSegmentResourceRel(IDbContext dbContext, string processsegmentid, string resourceid, string productdefinitionid, string processdefinitionid, string worksetid, string siteid)
	{
		string apiName = "GetProcessSegmentResourceRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processsegmentid},{resourceid},{productdefinitionid},{processdefinitionid},{worksetid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProcessSegmentResourceRelSqlDatabase : _sqlGetProcessSegmentResourceRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("RESOURCEID", resourceid, typeOfThis));
		list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", productdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSDEFINITIONID", processdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("WORKSETID", worksetid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PROCESSSEGMENTRESOURCEREL", $"{processsegmentid},{resourceid},{productdefinitionid},{processdefinitionid},{worksetid},{siteid}"));
		}
		Processsegmentresourcerel result = ContextManager.DirectEntityQuery<Processsegmentresourcerel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processsegmentid},{resourceid},{productdefinitionid},{processdefinitionid},{worksetid},{siteid}");
		}
		return result;
	}

	public static Processsegmentresourcerel GetProcessSegmentResourceRel4Update(IDbContext dbContext, string processsegmentid, string resourceid, string productdefinitionid, string processdefinitionid, string worksetid, string siteid)
	{
		string apiName = "GetProcessSegmentResourceRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processsegmentid},{resourceid},{productdefinitionid},{processdefinitionid},{worksetid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProcessSegmentResourceRel4UpdateSqlDatabase : _sqlGetProcessSegmentResourceRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("RESOURCEID", resourceid, typeOfThis));
		list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", productdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSDEFINITIONID", processdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("WORKSETID", worksetid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PROCESSSEGMENTRESOURCEREL", $"{processsegmentid},{resourceid},{productdefinitionid},{processdefinitionid},{worksetid},{siteid}"));
		}
		Processsegmentresourcerel result = ContextManager.DirectEntityQuery<Processsegmentresourcerel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processsegmentid},{resourceid},{productdefinitionid},{processdefinitionid},{worksetid},{siteid}");
		}
		return result;
	}

	public static Processsegmentresourcerel SelectProcessSegmentResourceRel(IDbContext dbContext, string processsegmentid, string resourceid, string productdefinitionid, string processdefinitionid, string worksetid, string siteid)
	{
		string apiName = "SelectProcessSegmentResourceRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processsegmentid},{resourceid},{productdefinitionid},{processdefinitionid},{worksetid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessSegmentResourceRelSqlDatabase : _sqlSelectProcessSegmentResourceRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("RESOURCEID", resourceid, typeOfThis));
		list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", productdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSDEFINITIONID", processdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("WORKSETID", worksetid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PROCESSSEGMENTRESOURCEREL", $"{processsegmentid},{resourceid},{productdefinitionid},{processdefinitionid},{worksetid},{siteid}"));
		}
		Processsegmentresourcerel result = ContextManager.DirectEntityQuery<Processsegmentresourcerel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processsegmentid},{resourceid},{productdefinitionid},{processdefinitionid},{worksetid},{siteid}");
		}
		return result;
	}

	public static Processsegmentresourcerel SelectProcessSegmentResourceRel4Update(IDbContext dbContext, string processsegmentid, string resourceid, string productdefinitionid, string processdefinitionid, string worksetid, string siteid)
	{
		string apiName = "SelectProcessSegmentResourceRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processsegmentid},{resourceid},{productdefinitionid},{processdefinitionid},{worksetid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessSegmentResourceRel4UpdateSqlDatabase : _sqlSelectProcessSegmentResourceRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("RESOURCEID", resourceid, typeOfThis));
		list.Add(dbContext.CreateParameter("PRODUCTDEFINITIONID", productdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSDEFINITIONID", processdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("WORKSETID", worksetid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PROCESSSEGMENTRESOURCEREL", $"{processsegmentid},{resourceid},{productdefinitionid},{processdefinitionid},{worksetid},{siteid}"));
		}
		Processsegmentresourcerel result = ContextManager.DirectEntityQuery<Processsegmentresourcerel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processsegmentid},{resourceid},{productdefinitionid},{processdefinitionid},{worksetid},{siteid}");
		}
		return result;
	}

	public static int UpsertProcessSegmentResourceRel(IDbContext dbContext, RequestType requestType, Processsegmentresourcerel[] processSegmentResourceRelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateProcessSegmentResourceRelInternal(dbContext, processSegmentResourceRelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateProcessSegmentResourceRel(dbContext, processSegmentResourceRelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteProcessSegmentResourceRel(dbContext, processSegmentResourceRelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteProcessSegmentResourceRel(dbContext, processSegmentResourceRelList, optionSet, saveHist), 
			_ => RealDeleteProcessSegmentResourceRel(dbContext, processSegmentResourceRelList, optionSet, saveHist), 
		};
	}

	private static int CreateProcessSegmentResourceRelInternal(IDbContext dbContext, Processsegmentresourcerel[] processSegmentResourceRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processSegmentResourceRelList", processSegmentResourceRelList);
		string text = "CreateProcessSegmentResourceRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processsegmentresourcerel> list = new List<Processsegmentresourcerel>();
		foreach (Processsegmentresourcerel obj in processSegmentResourceRelList)
		{
			Processsegmentresourcerel processsegmentresourcerel = new Processsegmentresourcerel();
			obj.CopyColumsTo(processsegmentresourcerel);
			processsegmentresourcerel.Activity = text;
			processsegmentresourcerel.CheckEntityUsable();
			obj.CopyCommonField(processsegmentresourcerel, systemTime, dbContext.Tid, isCreate: true);
			list.Add(processsegmentresourcerel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateProcessSegmentResourceRel(IDbContext dbContext, Processsegmentresourcerel[] processSegmentResourceRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processSegmentResourceRelList", processSegmentResourceRelList);
		string text = "UpdateProcessSegmentResourceRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processsegmentresourcerel> list = new List<Processsegmentresourcerel>();
		foreach (Processsegmentresourcerel processsegmentresourcerel in processSegmentResourceRelList)
		{
			Processsegmentresourcerel processSegmentResourceRel4Update = GetProcessSegmentResourceRel4Update(dbContext, processsegmentresourcerel.Processsegmentid, processsegmentresourcerel.Resourceid, processsegmentresourcerel.Productdefinitionid, processsegmentresourcerel.Processdefinitionid, processsegmentresourcerel.Worksetid, processsegmentresourcerel.Siteid);
			if (processSegmentResourceRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentresourcerel), $"{processsegmentresourcerel.Processsegmentid},{processsegmentresourcerel.Resourceid},{processsegmentresourcerel.Productdefinitionid},{processsegmentresourcerel.Processdefinitionid},{processsegmentresourcerel.Worksetid},{processsegmentresourcerel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Processsegmentresourcerel), $"{processsegmentresourcerel.Processsegmentid},{processsegmentresourcerel.Resourceid},{processsegmentresourcerel.Productdefinitionid},{processsegmentresourcerel.Processdefinitionid},{processsegmentresourcerel.Worksetid},{processsegmentresourcerel.Siteid}", processSegmentResourceRel4Update.Isusable);
			string activity = processSegmentResourceRel4Update.Activity;
			string customactivity = processSegmentResourceRel4Update.Customactivity;
			string isusable = processSegmentResourceRel4Update.Isusable;
			DateTime? createtime = processSegmentResourceRel4Update.Createtime;
			string creator = processSegmentResourceRel4Update.Creator;
			processsegmentresourcerel.CopyColumsTo(processSegmentResourceRel4Update);
			processSegmentResourceRel4Update.Prevactivity = activity;
			processSegmentResourceRel4Update.Prevcustomactivity = customactivity;
			processSegmentResourceRel4Update.Creator = creator;
			processSegmentResourceRel4Update.Createtime = createtime;
			processSegmentResourceRel4Update.Isusable = isusable;
			processSegmentResourceRel4Update.Activity = text;
			processsegmentresourcerel.CopyCommonField(processSegmentResourceRel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(processSegmentResourceRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteProcessSegmentResourceRel(IDbContext dbContext, Processsegmentresourcerel[] processSegmentResourceRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processSegmentResourceRelList", processSegmentResourceRelList);
		string text = "DeleteProcessSegmentResourceRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processsegmentresourcerel> list = new List<Processsegmentresourcerel>();
		foreach (Processsegmentresourcerel processsegmentresourcerel in processSegmentResourceRelList)
		{
			Processsegmentresourcerel processSegmentResourceRel4Update = GetProcessSegmentResourceRel4Update(dbContext, processsegmentresourcerel.Processsegmentid, processsegmentresourcerel.Resourceid, processsegmentresourcerel.Productdefinitionid, processsegmentresourcerel.Processdefinitionid, processsegmentresourcerel.Worksetid, processsegmentresourcerel.Siteid);
			if (processSegmentResourceRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentresourcerel), $"{processsegmentresourcerel.Processsegmentid},{processsegmentresourcerel.Resourceid},{processsegmentresourcerel.Productdefinitionid},{processsegmentresourcerel.Processdefinitionid},{processsegmentresourcerel.Worksetid},{processsegmentresourcerel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Processsegmentresourcerel), $"{processsegmentresourcerel.Processsegmentid},{processsegmentresourcerel.Resourceid},{processsegmentresourcerel.Productdefinitionid},{processsegmentresourcerel.Processdefinitionid},{processsegmentresourcerel.Worksetid},{processsegmentresourcerel.Siteid}", processSegmentResourceRel4Update.Isusable);
			processSegmentResourceRel4Update.Isusable = "UnUsable";
			processsegmentresourcerel.CopyCommonFieldUpdatePrev(processSegmentResourceRel4Update, systemTime, dbContext.Tid, text);
			processsegmentresourcerel.CopyExtensionCollection(processSegmentResourceRel4Update);
			list.Add(processSegmentResourceRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteProcessSegmentResourceRel(IDbContext dbContext, Processsegmentresourcerel[] processSegmentResourceRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processSegmentResourceRelList", processSegmentResourceRelList);
		string text = "UnDeleteProcessSegmentResourceRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processsegmentresourcerel> list = new List<Processsegmentresourcerel>();
		foreach (Processsegmentresourcerel processsegmentresourcerel in processSegmentResourceRelList)
		{
			Processsegmentresourcerel processSegmentResourceRel4Update = GetProcessSegmentResourceRel4Update(dbContext, processsegmentresourcerel.Processsegmentid, processsegmentresourcerel.Resourceid, processsegmentresourcerel.Productdefinitionid, processsegmentresourcerel.Processdefinitionid, processsegmentresourcerel.Worksetid, processsegmentresourcerel.Siteid);
			if (processSegmentResourceRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentresourcerel), $"{processsegmentresourcerel.Processsegmentid},{processsegmentresourcerel.Resourceid},{processsegmentresourcerel.Productdefinitionid},{processsegmentresourcerel.Processdefinitionid},{processsegmentresourcerel.Worksetid},{processsegmentresourcerel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Processsegmentresourcerel), $"{processsegmentresourcerel.Processsegmentid},{processsegmentresourcerel.Resourceid},{processsegmentresourcerel.Productdefinitionid},{processsegmentresourcerel.Processdefinitionid},{processsegmentresourcerel.Worksetid},{processsegmentresourcerel.Siteid}", processSegmentResourceRel4Update.Isusable);
			processSegmentResourceRel4Update.Isusable = "Usable";
			processsegmentresourcerel.CopyCommonFieldUpdatePrev(processSegmentResourceRel4Update, systemTime, dbContext.Tid, text);
			processsegmentresourcerel.CopyExtensionCollection(processSegmentResourceRel4Update);
			list.Add(processSegmentResourceRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteProcessSegmentResourceRel(IDbContext dbContext, Processsegmentresourcerel[] processSegmentResourceRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processSegmentResourceRelList", processSegmentResourceRelList);
		string text = "RealDeleteProcessSegmentResourceRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processsegmentresourcerel> list = new List<Processsegmentresourcerel>();
		foreach (Processsegmentresourcerel processsegmentresourcerel in processSegmentResourceRelList)
		{
			Processsegmentresourcerel processSegmentResourceRel4Update = GetProcessSegmentResourceRel4Update(dbContext, processsegmentresourcerel.Processsegmentid, processsegmentresourcerel.Resourceid, processsegmentresourcerel.Productdefinitionid, processsegmentresourcerel.Processdefinitionid, processsegmentresourcerel.Worksetid, processsegmentresourcerel.Siteid);
			if (processSegmentResourceRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentresourcerel), $"{processsegmentresourcerel.Processsegmentid},{processsegmentresourcerel.Resourceid},{processsegmentresourcerel.Productdefinitionid},{processsegmentresourcerel.Processdefinitionid},{processsegmentresourcerel.Worksetid},{processsegmentresourcerel.Siteid}");
			}
			processsegmentresourcerel.CopyCommonFieldUpdatePrev(processSegmentResourceRel4Update, systemTime, dbContext.Tid, text);
			processsegmentresourcerel.CopyExtensionCollection(processSegmentResourceRel4Update);
			list.Add(processSegmentResourceRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
