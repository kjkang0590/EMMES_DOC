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
public class PROCESSSEGMENTRULECLSREL
{
	private static string _sqlGetProcessSegmentRuleClsRelSqlDatabase = "SELECT * FROM CIM_PROCESSSEGMENTRULECLSREL WHERE PROCESSSEGMENTRULECLSID=@PROCESSSEGMENTRULECLSID AND PROCESSSEGMENTRULEID=@PROCESSSEGMENTRULEID AND SITEID=@SITEID";

	private static string _sqlGetProcessSegmentRuleClsRel4UpdateSqlDatabase = "SELECT * FROM CIM_PROCESSSEGMENTRULECLSREL WITH(UPDLOCK) WHERE PROCESSSEGMENTRULECLSID=@PROCESSSEGMENTRULECLSID AND PROCESSSEGMENTRULEID=@PROCESSSEGMENTRULEID AND SITEID=@SITEID";

	private static string _sqlSelectProcessSegmentRuleClsRelSqlDatabase = "SELECT * FROM CIM_PROCESSSEGMENTRULECLSREL WHERE PROCESSSEGMENTRULECLSID=@PROCESSSEGMENTRULECLSID AND PROCESSSEGMENTRULEID=@PROCESSSEGMENTRULEID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessSegmentRuleClsRel4UpdateSqlDatabase = "SELECT * FROM CIM_PROCESSSEGMENTRULECLSREL WITH(UPDLOCK) WHERE PROCESSSEGMENTRULECLSID=@PROCESSSEGMENTRULECLSID AND PROCESSSEGMENTRULEID=@PROCESSSEGMENTRULEID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetProcessSegmentRuleClsRelOracleDatabase = "SELECT * FROM CIM_PROCESSSEGMENTRULECLSREL WHERE PROCESSSEGMENTRULECLSID=:PROCESSSEGMENTRULECLSID AND PROCESSSEGMENTRULEID=:PROCESSSEGMENTRULEID AND SITEID=:SITEID";

	private static string _sqlGetProcessSegmentRuleClsRel4UpdateOracleDatabase = "SELECT * FROM CIM_PROCESSSEGMENTRULECLSREL WHERE PROCESSSEGMENTRULECLSID=:PROCESSSEGMENTRULECLSID AND PROCESSSEGMENTRULEID=:PROCESSSEGMENTRULEID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectProcessSegmentRuleClsRelOracleDatabase = "SELECT * FROM CIM_PROCESSSEGMENTRULECLSREL WHERE PROCESSSEGMENTRULECLSID=:PROCESSSEGMENTRULECLSID AND PROCESSSEGMENTRULEID=:PROCESSSEGMENTRULEID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessSegmentRuleClsRel4UpdateOracleDatabase = "SELECT * FROM CIM_PROCESSSEGMENTRULECLSREL WHERE PROCESSSEGMENTRULECLSID=:PROCESSSEGMENTRULECLSID AND PROCESSSEGMENTRULEID=:PROCESSSEGMENTRULEID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Processsegmentruleclsrel);

	private static string _sqlSelectFirstProcessSegmentRuleSqlDatabase = "SELECT R.* FROM CIM_PROCESSSEGMENTRULECLSREL R  JOIN CIM_PROCESSSEGMENT S  ON R.PROCESSSEGMENTRULECLSID=S.PROCESSSEGMENTRULECLSID WHERE R.ISUSABLE='Usable' AND R.SITEID=@SITEID AND R.ISSTART='Y' AND R.RULESEQUENCE <> 0 AND S.PROCESSSEGMENTID=@PROCESSSEGMENTID AND S.SITEID=@SITEID AND S.ISUSABLE='Usable'";

	private static string _sqlSelectFirstProcessSegmentRuleOracleDatabase = "SELECT R.* FROM CIM_PROCESSSEGMENTRULECLSREL R JOIN CIM_PROCESSSEGMENT S ON R.PROCESSSEGMENTRULECLSID=S.PROCESSSEGMENTRULECLSID WHERE R.ISUSABLE='Usable' AND R.SITEID=:SITEID AND R.ISSTART='Y' AND R.RULESEQUENCE <> 0 AND S.PROCESSSEGMENTID=:PROCESSSEGMENTID AND S.SITEID=:SITEID AND S.ISUSABLE='Usable'";

	private static string _sqlSelectFirstProcessSegmentRuleByRuleClsSqlDatabase = "SELECT * FROM CIM_PROCESSSEGMENTRULECLSREL  WHERE PROCESSSEGMENTRULECLSID=@PROCESSSEGMENTRULECLSID AND ISSTART='Y' AND ISUSABLE='Usable' AND SITEID=@SITEID";

	private static string _sqlSelectFirstProcessSegmentRuleByRuleClsOracleDatabase = "SELECT * FROM CIM_PROCESSSEGMENTRULECLSREL WHERE PROCESSSEGMENTRULECLSID=:PROCESSSEGMENTRULECLSID AND ISSTART='Y' AND ISUSABLE='Usable' AND SITEID=:SITEID";

	private static string _sqlSelectNextProcessSegmentRuleSqlDatabase = "SELECT R.* FROM CIM_PROCESSSEGMENTRULECLSREL R INNER JOIN CIM_PROCESSSEGMENT S  ON R.PROCESSSEGMENTRULECLSID=S.PROCESSSEGMENTRULECLSID AND R.SITEID=S.SITEID AND S.PROCESSSEGMENTID=@PROCESSSEGMENTID AND S.ISUSABLE='Usable' WHERE R.SITEID=@SITEID AND R.ISUSABLE='Usable' AND R.RULESEQUENCE > @RULESEQUENCE ORDER BY R.RULESEQUENCE ASC";

	private static string _sqlSelectNextProcessSegmentRuleOracleDatabase = "SELECT R.* FROM CIM_PROCESSSEGMENTRULECLSREL R JOIN CIM_PROCESSSEGMENT S ON R.PROCESSSEGMENTRULECLSID=S.PROCESSSEGMENTRULECLSID AND R.SITEID=S.SITEID AND S.PROCESSSEGMENTID=:PROCESSSEGMENTID AND S.ISUSABLE='Usable' WHERE R.SITEID=:SITEID AND R.ISUSABLE='Usable' AND R.RULESEQUENCE > :RULESEQUENCE ORDER BY R.RULESEQUENCE ASC";

	private static Type typeOfProcessSegment = typeof(Processsegment);

	private static string _sqlSelectPrevProcessSegmentRuleSqlDatabase = "SELECT R.* FROM CIM_PROCESSSEGMENTRULECLSREL R    JOIN CIM_PROCESSSEGMENT S   ON R.PROCESSSEGMENTRULECLSID=S.PROCESSSEGMENTRULECLSID AND R.SITEID=S.SITEID AND S.PROCESSSEGMENTID=@PROCESSSEGMENTID AND S.ISUSABLE='Usable' WHERE R.SITEID=@SITEID AND R.ISUSABLE='Usable' AND R.RULESEQUENCE < @RULESEQUENCE ORDER BY R.RULESEQUENCE DESC";

	private static string _sqlSelectPrevProcessSegmentRuleOracleDatabase = "SELECT R.* FROM CIM_PROCESSSEGMENTRULECLSREL R JOIN CIM_PROCESSSEGMENT S ON R.PROCESSSEGMENTRULECLSID=S.PROCESSSEGMENTRULECLSID AND R.SITEID=S.SITEID AND S.PROCESSSEGMENTID=:PROCESSSEGMENTID AND S.ISUSABLE='Usable' WHERE R.SITEID=:SITEID AND R.ISUSABLE='Usable' AND R.RULESEQUENCE < :RULESEQUENCE ORDER BY R.RULESEQUENCE DESC";

	private static string _sqlSelectProcessSegmentRuleClsRelBySegmentIdSqlDatabase = "SELECT R.* FROM CIM_PROCESSSEGMENTRULECLSREL R  JOIN CIM_PROCESSSEGMENT S  ON R.PROCESSSEGMENTRULECLSID=S.PROCESSSEGMENTRULECLSID AND R.SITEID=S.SITEID AND S.PROCESSSEGMENTID=@PROCESSSEGMENTID AND S.ISUSABLE='Usable' WHERE R.PROCESSSEGMENTRULEID=@PROCESSSEGMENTRULEID AND R.SITEID=@SITEID AND R.ISUSABLE='Usable'";

	private static string _sqlSelectProcessSegmentRuleClsRelBySegmentIdOracleDatabase = "SELECT R.* FROM CIM_PROCESSSEGMENTRULECLSREL R JOIN CIM_PROCESSSEGMENT S ON R.PROCESSSEGMENTRULECLSID=S.PROCESSSEGMENTRULECLSID AND R.SITEID=S.SITEID AND S.PROCESSSEGMENTID=:PROCESSSEGMENTID AND S.ISUSABLE='Usable' WHERE R.PROCESSSEGMENTRULEID=:PROCESSSEGMENTRULEID AND R.SITEID=:SITEID AND R.ISUSABLE='Usable'";

	public static Processsegmentruleclsrel GetProcessSegmentRuleClsRel(IDbContext dbContext, string processsegmentruleclsid, string processsegmentruleid, string siteid)
	{
		string apiName = "GetProcessSegmentRuleClsRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processsegmentruleclsid},{processsegmentruleid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProcessSegmentRuleClsRelSqlDatabase : _sqlGetProcessSegmentRuleClsRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTRULECLSID", processsegmentruleclsid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTRULEID", processsegmentruleid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PROCESSSEGMENTRULECLSREL", $"{processsegmentruleclsid},{processsegmentruleid},{siteid}"));
		}
		Processsegmentruleclsrel? result = ContextManager.DirectEntityQuery<Processsegmentruleclsrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processsegmentruleclsid},{processsegmentruleid},{siteid}");
		}
		return result;
	}

	public static Processsegmentruleclsrel GetProcessSegmentRuleClsRel4Update(IDbContext dbContext, string processsegmentruleclsid, string processsegmentruleid, string siteid)
	{
		string apiName = "GetProcessSegmentRuleClsRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processsegmentruleclsid},{processsegmentruleid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProcessSegmentRuleClsRel4UpdateSqlDatabase : _sqlGetProcessSegmentRuleClsRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTRULECLSID", processsegmentruleclsid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTRULEID", processsegmentruleid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PROCESSSEGMENTRULECLSREL", $"{processsegmentruleclsid},{processsegmentruleid},{siteid}"));
		}
		Processsegmentruleclsrel? result = ContextManager.DirectEntityQuery<Processsegmentruleclsrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processsegmentruleclsid},{processsegmentruleid},{siteid}");
		}
		return result;
	}

	public static Processsegmentruleclsrel SelectProcessSegmentRuleClsRel(IDbContext dbContext, string processsegmentruleclsid, string processsegmentruleid, string siteid)
	{
		string apiName = "SelectProcessSegmentRuleClsRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processsegmentruleclsid},{processsegmentruleid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessSegmentRuleClsRelSqlDatabase : _sqlSelectProcessSegmentRuleClsRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTRULECLSID", processsegmentruleclsid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTRULEID", processsegmentruleid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PROCESSSEGMENTRULECLSREL", $"{processsegmentruleclsid},{processsegmentruleid},{siteid}"));
		}
		Processsegmentruleclsrel? result = ContextManager.DirectEntityQuery<Processsegmentruleclsrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processsegmentruleclsid},{processsegmentruleid},{siteid}");
		}
		return result;
	}

	public static Processsegmentruleclsrel SelectProcessSegmentRuleClsRel4Update(IDbContext dbContext, string processsegmentruleclsid, string processsegmentruleid, string siteid)
	{
		string apiName = "SelectProcessSegmentRuleClsRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processsegmentruleclsid},{processsegmentruleid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessSegmentRuleClsRel4UpdateSqlDatabase : _sqlSelectProcessSegmentRuleClsRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTRULECLSID", processsegmentruleclsid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTRULEID", processsegmentruleid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PROCESSSEGMENTRULECLSREL", $"{processsegmentruleclsid},{processsegmentruleid},{siteid}"));
		}
		Processsegmentruleclsrel? result = ContextManager.DirectEntityQuery<Processsegmentruleclsrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processsegmentruleclsid},{processsegmentruleid},{siteid}");
		}
		return result;
	}

	public static int UpsertProcessSegmentRuleClsRel(IDbContext dbContext, RequestType requestType, Processsegmentruleclsrel[] processSegmentRuleClsRelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateProcessSegmentRuleClsRelInternal(dbContext, processSegmentRuleClsRelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateProcessSegmentRuleClsRel(dbContext, processSegmentRuleClsRelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteProcessSegmentRuleClsRel(dbContext, processSegmentRuleClsRelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteProcessSegmentRuleClsRel(dbContext, processSegmentRuleClsRelList, optionSet, saveHist), 
			_ => RealDeleteProcessSegmentRuleClsRel(dbContext, processSegmentRuleClsRelList, optionSet, saveHist), 
		};
	}

	private static int CreateProcessSegmentRuleClsRelInternal(IDbContext dbContext, Processsegmentruleclsrel[] processSegmentRuleClsRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processSegmentRuleClsRelList", processSegmentRuleClsRelList);
		string text = "CreateProcessSegmentRuleClsRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processsegmentruleclsrel> list = new List<Processsegmentruleclsrel>();
		foreach (Processsegmentruleclsrel obj in processSegmentRuleClsRelList)
		{
			Processsegmentruleclsrel processsegmentruleclsrel = new Processsegmentruleclsrel();
			obj.CopyColumsTo(processsegmentruleclsrel);
			processsegmentruleclsrel.Activity = text;
			processsegmentruleclsrel.CheckEntityUsable();
			obj.CopyCommonField(processsegmentruleclsrel, systemTime, dbContext.Tid, isCreate: true);
			list.Add(processsegmentruleclsrel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateProcessSegmentRuleClsRel(IDbContext dbContext, Processsegmentruleclsrel[] processSegmentRuleClsRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processSegmentRuleClsRelList", processSegmentRuleClsRelList);
		string text = "UpdateProcessSegmentRuleClsRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processsegmentruleclsrel> list = new List<Processsegmentruleclsrel>();
		foreach (Processsegmentruleclsrel processsegmentruleclsrel in processSegmentRuleClsRelList)
		{
			Processsegmentruleclsrel processSegmentRuleClsRel4Update = GetProcessSegmentRuleClsRel4Update(dbContext, processsegmentruleclsrel.Processsegmentruleclsid, processsegmentruleclsrel.Processsegmentruleid, processsegmentruleclsrel.Siteid);
			if (processSegmentRuleClsRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentruleclsrel), $"{processsegmentruleclsrel.Processsegmentruleclsid},{processsegmentruleclsrel.Processsegmentruleid},{processsegmentruleclsrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Processsegmentruleclsrel), $"{processsegmentruleclsrel.Processsegmentruleclsid},{processsegmentruleclsrel.Processsegmentruleid},{processsegmentruleclsrel.Siteid}", processSegmentRuleClsRel4Update.Isusable);
			string activity = processSegmentRuleClsRel4Update.Activity;
			string customactivity = processSegmentRuleClsRel4Update.Customactivity;
			string isusable = processSegmentRuleClsRel4Update.Isusable;
			DateTime? createtime = processSegmentRuleClsRel4Update.Createtime;
			string creator = processSegmentRuleClsRel4Update.Creator;
			processsegmentruleclsrel.CopyColumsTo(processSegmentRuleClsRel4Update);
			processSegmentRuleClsRel4Update.Prevactivity = activity;
			processSegmentRuleClsRel4Update.Prevcustomactivity = customactivity;
			processSegmentRuleClsRel4Update.Creator = creator;
			processSegmentRuleClsRel4Update.Createtime = createtime;
			processSegmentRuleClsRel4Update.Isusable = isusable;
			processSegmentRuleClsRel4Update.Activity = text;
			processsegmentruleclsrel.CopyCommonField(processSegmentRuleClsRel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(processSegmentRuleClsRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteProcessSegmentRuleClsRel(IDbContext dbContext, Processsegmentruleclsrel[] processSegmentRuleClsRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processSegmentRuleClsRelList", processSegmentRuleClsRelList);
		string text = "DeleteProcessSegmentRuleClsRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processsegmentruleclsrel> list = new List<Processsegmentruleclsrel>();
		foreach (Processsegmentruleclsrel processsegmentruleclsrel in processSegmentRuleClsRelList)
		{
			Processsegmentruleclsrel processSegmentRuleClsRel4Update = GetProcessSegmentRuleClsRel4Update(dbContext, processsegmentruleclsrel.Processsegmentruleclsid, processsegmentruleclsrel.Processsegmentruleid, processsegmentruleclsrel.Siteid);
			if (processSegmentRuleClsRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentruleclsrel), $"{processsegmentruleclsrel.Processsegmentruleclsid},{processsegmentruleclsrel.Processsegmentruleid},{processsegmentruleclsrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Processsegmentruleclsrel), $"{processsegmentruleclsrel.Processsegmentruleclsid},{processsegmentruleclsrel.Processsegmentruleid},{processsegmentruleclsrel.Siteid}", processSegmentRuleClsRel4Update.Isusable);
			processSegmentRuleClsRel4Update.Isusable = "UnUsable";
			processsegmentruleclsrel.CopyCommonFieldUpdatePrev(processSegmentRuleClsRel4Update, systemTime, dbContext.Tid, text);
			processsegmentruleclsrel.CopyExtensionCollection(processSegmentRuleClsRel4Update);
			list.Add(processSegmentRuleClsRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteProcessSegmentRuleClsRel(IDbContext dbContext, Processsegmentruleclsrel[] processSegmentRuleClsRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processSegmentRuleClsRelList", processSegmentRuleClsRelList);
		string text = "UnDeleteProcessSegmentRuleClsRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processsegmentruleclsrel> list = new List<Processsegmentruleclsrel>();
		foreach (Processsegmentruleclsrel processsegmentruleclsrel in processSegmentRuleClsRelList)
		{
			Processsegmentruleclsrel processSegmentRuleClsRel4Update = GetProcessSegmentRuleClsRel4Update(dbContext, processsegmentruleclsrel.Processsegmentruleclsid, processsegmentruleclsrel.Processsegmentruleid, processsegmentruleclsrel.Siteid);
			if (processSegmentRuleClsRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentruleclsrel), $"{processsegmentruleclsrel.Processsegmentruleclsid},{processsegmentruleclsrel.Processsegmentruleid},{processsegmentruleclsrel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Processsegmentruleclsrel), $"{processsegmentruleclsrel.Processsegmentruleclsid},{processsegmentruleclsrel.Processsegmentruleid},{processsegmentruleclsrel.Siteid}", processSegmentRuleClsRel4Update.Isusable);
			processSegmentRuleClsRel4Update.Isusable = "Usable";
			processsegmentruleclsrel.CopyCommonFieldUpdatePrev(processSegmentRuleClsRel4Update, systemTime, dbContext.Tid, text);
			processsegmentruleclsrel.CopyExtensionCollection(processSegmentRuleClsRel4Update);
			list.Add(processSegmentRuleClsRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteProcessSegmentRuleClsRel(IDbContext dbContext, Processsegmentruleclsrel[] processSegmentRuleClsRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processSegmentRuleClsRelList", processSegmentRuleClsRelList);
		string text = "RealDeleteProcessSegmentRuleClsRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processsegmentruleclsrel> list = new List<Processsegmentruleclsrel>();
		foreach (Processsegmentruleclsrel processsegmentruleclsrel in processSegmentRuleClsRelList)
		{
			Processsegmentruleclsrel processSegmentRuleClsRel4Update = GetProcessSegmentRuleClsRel4Update(dbContext, processsegmentruleclsrel.Processsegmentruleclsid, processsegmentruleclsrel.Processsegmentruleid, processsegmentruleclsrel.Siteid);
			if (processSegmentRuleClsRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentruleclsrel), $"{processsegmentruleclsrel.Processsegmentruleclsid},{processsegmentruleclsrel.Processsegmentruleid},{processsegmentruleclsrel.Siteid}");
			}
			processsegmentruleclsrel.CopyCommonFieldUpdatePrev(processSegmentRuleClsRel4Update, systemTime, dbContext.Tid, text);
			processsegmentruleclsrel.CopyExtensionCollection(processSegmentRuleClsRel4Update);
			list.Add(processSegmentRuleClsRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static Processsegmentruleclsrel SelectFirstProcessSegmentRule(IDbContext dbContext, string processSegmentId, string siteId)
	{
		string apiName = "SelectFirstProcessSegmentRule";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processSegmentId}.{siteId}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectFirstProcessSegmentRuleSqlDatabase : _sqlSelectFirstProcessSegmentRuleOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processSegmentId, typeOfProcessSegment));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfProcessSegment));
		Processsegmentruleclsrel? result = ContextManager.DirectEntityQuery<Processsegmentruleclsrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processSegmentId}.{siteId}");
		}
		return result;
	}

	public static Processsegmentruleclsrel SelectFirstProcessSegmentRuleByRuleCls(IDbContext dbContext, string processSegmentRuleClsId, string siteId)
	{
		string apiName = "SelectFirstProcessSegmentRuleByRuleCls";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processSegmentRuleClsId}.{siteId}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectFirstProcessSegmentRuleByRuleClsSqlDatabase : _sqlSelectFirstProcessSegmentRuleByRuleClsOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTRULECLSID", processSegmentRuleClsId, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		Processsegmentruleclsrel? result = ContextManager.DirectEntityQuery<Processsegmentruleclsrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processSegmentRuleClsId}.{siteId}");
		}
		return result;
	}

	public static Processsegmentruleclsrel SelectNextProcessSegmentRule(IDbContext dbContext, string processSegmentId, int ruleSequence, string siteId)
	{
		string apiName = "SelectNextProcessSegmentRule";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processSegmentId}.{ruleSequence}.{siteId}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectNextProcessSegmentRuleSqlDatabase : _sqlSelectNextProcessSegmentRuleOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processSegmentId, typeOfProcessSegment));
		list.Add(dbContext.CreateParameter("RULESEQUENCE", ruleSequence, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		Processsegmentruleclsrel? result = ContextManager.DirectEntityQuery<Processsegmentruleclsrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processSegmentId}.{ruleSequence}.{siteId}");
		}
		return result;
	}

	public static Processsegmentruleclsrel SelectPrevProcessSegmentRule(IDbContext dbContext, string processSegmentId, int ruleSequence, string siteId)
	{
		string apiName = "SelectPrevProcessSegmentRule";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processSegmentId}.{ruleSequence}.{siteId}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectPrevProcessSegmentRuleSqlDatabase : _sqlSelectPrevProcessSegmentRuleOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processSegmentId, typeOfProcessSegment));
		list.Add(dbContext.CreateParameter("RULESEQUENCE", ruleSequence, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		Processsegmentruleclsrel? result = ContextManager.DirectEntityQuery<Processsegmentruleclsrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processSegmentId}.{ruleSequence}.{siteId}");
		}
		return result;
	}

	public static Processsegmentruleclsrel SelectProcessSegmentRuleClsRelBySegmentId(IDbContext dbContext, string processSegmentId, string processSegmentRuleId, string siteId)
	{
		string apiName = "SelectProcessSegmentRuleClsRelBySegmentId";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processSegmentId}.{processSegmentRuleId}.{siteId}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessSegmentRuleClsRelBySegmentIdSqlDatabase : _sqlSelectProcessSegmentRuleClsRelBySegmentIdOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processSegmentId, typeOfProcessSegment));
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTRULEID", processSegmentRuleId, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		Processsegmentruleclsrel? result = ContextManager.DirectEntityQuery<Processsegmentruleclsrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processSegmentId}.{processSegmentRuleId}.{siteId}");
		}
		return result;
	}
}
