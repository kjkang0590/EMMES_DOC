using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.QMS;

[MESAPI]
public class INSPREQ
{
	private static string _sqlGetInspReqSqlDatabase = "SELECT * FROM CIM_INSPREQ WHERE INSPREQNO=@INSPREQNO AND SITEID=@SITEID";

	private static string _sqlGetInspReq4UpdateSqlDatabase = "SELECT * FROM CIM_INSPREQ WITH(UPDLOCK) WHERE INSPREQNO=@INSPREQNO AND SITEID=@SITEID";

	private static string _sqlSelectInspReqSqlDatabase = "SELECT * FROM CIM_INSPREQ WHERE INSPREQNO=@INSPREQNO AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectInspReq4UpdateSqlDatabase = "SELECT * FROM CIM_INSPREQ WITH(UPDLOCK) WHERE INSPREQNO=@INSPREQNO AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetInspReqOracleDatabase = "SELECT * FROM CIM_INSPREQ WHERE INSPREQNO=:INSPREQNO AND SITEID=:SITEID";

	private static string _sqlGetInspReq4UpdateOracleDatabase = "SELECT * FROM CIM_INSPREQ WHERE INSPREQNO=:INSPREQNO AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectInspReqOracleDatabase = "SELECT * FROM CIM_INSPREQ WHERE INSPREQNO=:INSPREQNO AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectInspReq4UpdateOracleDatabase = "SELECT * FROM CIM_INSPREQ WHERE INSPREQNO=:INSPREQNO AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Inspreq);

	private static string _sqlSelectInspReqListSqlDatabase = "SELECT * FROM CIM_INSPREQ WHERE INSPREQNO IN (&INSPREQNOLIST) AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectInspReqList4UpdateSqlDatabase = "SELECT * FROM CIM_INSPREQ WITH(UPDLOCK) WHERE INSPREQNO IN (&INSPREQNOLIST) AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectInspReqListOracleDatabase = "SELECT * FROM CIM_INSPREQ WHERE INSPREQNO IN (&INSPREQNOLIST) AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectInspReqList4UpdateOracleDatabase = "SELECT * FROM CIM_INSPREQ WHERE INSPREQNO IN (&INSPREQNOLIST) AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static string _sqlSelectInspReqListByLotidSqlDatabase = "SELECT R.* FROM CIM_INSPREQ R INNER JOIN CIM_INSPREQLOT L ON R.INSPREQNO=L.INSPREQNO AND R.SITEID=L.SITEID AND R.ISUSABLE='Usable' WHERE L.INSPLOTID IN (&INSPLOTIDLIST) AND L.SITEID=@SITEID AND L.ISUSABLE='Usable'";

	private static string _sqlSelectInspReqListByLotidOracleDatabase = "SELECT R.* FROM CIM_INSPREQ R INNER JOIN CIM_INSPREQLOT L ON R.INSPREQNO=L.INSPREQNO AND R.SITEID=L.SITEID AND R.ISUSABLE='Usable' WHERE L.INSPLOTID IN (&INSPLOTIDLIST) AND L.SITEID=:SITEID AND L.ISUSABLE='Usable'";

	private static string _sqlSelectInspReqListByLotidInsptypeSqlDatabase = "SELECT R.* FROM CIM_INSPREQ R INNER JOIN CIM_INSPREQLOT L ON R.INSPREQNO=L.INSPREQNO AND R.INSPTYPE=@INSPTYPE AND R.SITEID=L.SITEID AND R.ISUSABLE='Usable' WHERE L.INSPLOTID=@INSPLOTID AND L.SITEID=@SITEID AND L.ISUSABLE='Usable'";

	private static string _sqlSelectInspReqListByLotidInsptypeOracleDatabase = "SELECT R.* FROM CIM_INSPREQ R INNER JOIN CIM_INSPREQLOT L ON R.INSPREQNO=L.INSPREQNO AND R.INSPTYPE=:INSPTYPE AND R.SITEID=L.SITEID AND R.ISUSABLE='Usable' WHERE L.INSPLOTID=:INSPLOTID AND L.SITEID=:SITEID AND L.ISUSABLE='Usable'";

	public static int ChangeInspReqState(IDbContext dbContext, Inspreq[] inspReqList, ChangeInspReqStateOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspReqList", inspReqList);
		string text = "ChangeInspReqState";
		bool flag = optionSet?.SaveReqdatetimeWorktime ?? false;
		_ = optionSet?.SaveReceptdatetimeWorktime;
		_ = optionSet?.SaveFinaldatetimeWorktime;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspreq> list = new List<Inspreq>();
		string siteid = inspReqList[0].Siteid;
		Inspreq[] inspreqList = SelectInspReqList4Update(dbContext, inspReqList.Select((Inspreq inspreq) => inspreq.Inspreqno).ToArray(), siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"InspReq Count={inspReqList.Length}");
		}
		foreach (Inspreq inspreq2 in inspReqList)
		{
			ParamChecker.ArgumentNotNull("Inspreqno", inspreq2.Inspreqno);
			ParamChecker.ArgumentNotNull("State", inspreq2.State);
			ParamChecker.ArgumentNotNull("Siteid", inspreq2.Siteid);
			string inspreqno = inspreq2.Inspreqno;
			string state = inspreq2.State;
			Inspreq inspreq3 = null;
			if ((inspreq3 = FindInspreq(inspreqList, inspreqno)) == null)
			{
				throw new EntityNotFoundException(typeof(Inspreq), inspreqno);
			}
			if (STATE.SelectState(dbContext, typeof(InspReqState).Name, state, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(InspReqState), state);
			}
			inspreq3.State = state;
			if ("Request".Equals(inspreq3.State))
			{
				if (!inspreq2.Reqdatetime.HasValue)
				{
					inspreq3.Reqdatetime = (flag ? new DateTime?(systemTime) : inspreq2.Reqdatetime);
				}
				inspreq3.Receptdatetime = null;
				inspreq3.Finaldatetime = null;
				inspreq3.Finaljudge = null;
			}
			if ("Recept".Equals(inspreq3.State))
			{
				if (!inspreq2.Receptdatetime.HasValue)
				{
					inspreq3.Receptdatetime = (flag ? new DateTime?(systemTime) : inspreq2.Receptdatetime);
				}
				inspreq3.Finaldatetime = null;
				inspreq3.Finaljudge = null;
			}
			if ("Compeleted".Equals(inspreq3.State))
			{
				if (!inspreq2.Finaldatetime.HasValue)
				{
					inspreq3.Finaldatetime = (flag ? new DateTime?(systemTime) : inspreq2.Finaldatetime);
				}
				inspreq3.Finaljudge = inspreq2.Finaljudge;
			}
			inspreq2.CopyCommonFieldUpdatePrev(inspreq3, systemTime, tid, text);
			inspreq2.CopyExtensionCollection(inspreq3);
			list.Add(inspreq3);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", $"Inspreqno={inspreq3.Inspreqno} Prevstate={state} State={state}");
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static Inspreq GetInspReq(IDbContext dbContext, string inspreqno, string siteid)
	{
		string apiName = "GetInspReq";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspreqno},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetInspReqSqlDatabase : _sqlGetInspReqOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPREQNO", inspreqno, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_INSPREQ", $"{inspreqno},{siteid}"));
		}
		Inspreq? result = ContextManager.DirectEntityQuery<Inspreq>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspreqno},{siteid}");
		}
		return result;
	}

	public static Inspreq GetInspReq4Update(IDbContext dbContext, string inspreqno, string siteid)
	{
		string apiName = "GetInspReq4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspreqno},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetInspReq4UpdateSqlDatabase : _sqlGetInspReq4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPREQNO", inspreqno, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_INSPREQ", $"{inspreqno},{siteid}"));
		}
		Inspreq? result = ContextManager.DirectEntityQuery<Inspreq>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspreqno},{siteid}");
		}
		return result;
	}

	public static Inspreq SelectInspReq(IDbContext dbContext, string inspreqno, string siteid)
	{
		string apiName = "SelectInspReq";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspreqno},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectInspReqSqlDatabase : _sqlSelectInspReqOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPREQNO", inspreqno, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_INSPREQ", $"{inspreqno},{siteid}"));
		}
		Inspreq? result = ContextManager.DirectEntityQuery<Inspreq>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspreqno},{siteid}");
		}
		return result;
	}

	public static Inspreq SelectInspReq4Update(IDbContext dbContext, string inspreqno, string siteid)
	{
		string apiName = "SelectInspReq4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspreqno},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectInspReq4UpdateSqlDatabase : _sqlSelectInspReq4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPREQNO", inspreqno, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_INSPREQ", $"{inspreqno},{siteid}"));
		}
		Inspreq? result = ContextManager.DirectEntityQuery<Inspreq>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspreqno},{siteid}");
		}
		return result;
	}

	public static IList<Inspreq> SelectInspReqList(IDbContext dbContext, string[] inspreqList, string siteId)
	{
		string apiName = "SelectInspReqList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspreqList.Length},{siteId}");
		}
		string value = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectInspReqListSqlDatabase : _sqlSelectInspReqListOracleDatabase);
		value = new StringBuilder(value, 1000).Replace("&INSPREQNOLIST", EntityHelper.ConcatString4InClause(ExtractIdOrderBy(inspreqList))).ToString();
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_INSPREQ", $"{inspreqList.Length},{siteId}"));
		}
		IList<Inspreq> result = ContextManager.DirectEntityQuery<Inspreq>(dbContext, value, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspreqList.Length},{siteId}");
		}
		return result;
	}

	public static IList<Inspreq> SelectInspReqList4Update(IDbContext dbContext, string[] inspreqList, string siteId)
	{
		string apiName = "SelectInspReqList4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspreqList.Length},{siteId}");
		}
		string value = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectInspReqList4UpdateSqlDatabase : _sqlSelectInspReqList4UpdateOracleDatabase);
		value = new StringBuilder(value, 1000).Replace("&INSPREQNOLIST", EntityHelper.ConcatString4InClause(ExtractIdOrderBy(inspreqList))).ToString();
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_INSPREQ", $"{inspreqList.Length},{siteId}"));
		}
		IList<Inspreq> result = ContextManager.DirectEntityQuery<Inspreq>(dbContext, value, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspreqList.Length},{siteId}");
		}
		return result;
	}

	public static IList<Inspreq> SelectInspReqListByLotid(IDbContext dbContext, string[] inspLotidList, string siteid)
	{
		string apiName = "SelectInspReqListByLotid";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspLotidList.Length},{siteid}");
		}
		string value = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectInspReqListByLotidSqlDatabase : _sqlSelectInspReqListByLotidOracleDatabase);
		value = new StringBuilder(value, 1000).Replace("&INSPLOTIDLIST", EntityHelper.ConcatString4InClause(ExtractIdOrderBy(inspLotidList))).ToString();
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_INSPREQ", $"{inspLotidList.Length},{siteid}"));
		}
		IList<Inspreq> result = ContextManager.DirectEntityQuery<Inspreq>(dbContext, value, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspLotidList.Length},{siteid}");
		}
		return result;
	}

	public static IList<Inspreq> SelectInspReqListByLotidInsptype(IDbContext dbContext, string inspLotid, string insptype, string siteid)
	{
		string apiName = "SelectInspReqListByLotidInsptype";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspLotid},{insptype},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectInspReqListByLotidInsptypeSqlDatabase : _sqlSelectInspReqListByLotidInsptypeOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPLOTID", inspLotid, typeOfThis));
		list.Add(dbContext.CreateParameter("INSPTYPE", insptype, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_INSPREQ", $"{inspLotid},{insptype},{siteid}"));
		}
		IList<Inspreq> result = ContextManager.DirectEntityQuery<Inspreq>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspLotid},{insptype},{siteid}");
		}
		return result;
	}

	public static int UpsertInspReq(IDbContext dbContext, RequestType requestType, Inspreq[] inspReqList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateInspReqInternal(dbContext, inspReqList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateInspReq(dbContext, inspReqList, optionSet, saveHist), 
			RequestType.DELETE => DeleteInspReq(dbContext, inspReqList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteInspReq(dbContext, inspReqList, optionSet, saveHist), 
			_ => RealDeleteInspReq(dbContext, inspReqList, optionSet, saveHist), 
		};
	}

	private static int CreateInspReqInternal(IDbContext dbContext, Inspreq[] inspReqList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspReqList", inspReqList);
		string text = "CreateInspReq";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspreq> list = new List<Inspreq>();
		foreach (Inspreq obj in inspReqList)
		{
			Inspreq inspreq = new Inspreq();
			obj.CopyColumsTo(inspreq);
			inspreq.Activity = text;
			inspreq.CheckEntityUsable();
			obj.CopyCommonField(inspreq, systemTime, dbContext.Tid, isCreate: true);
			list.Add(inspreq);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateInspReq(IDbContext dbContext, Inspreq[] inspReqList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspReqList", inspReqList);
		string text = "UpdateInspReq";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspreq> list = new List<Inspreq>();
		foreach (Inspreq inspreq in inspReqList)
		{
			Inspreq inspReq4Update = GetInspReq4Update(dbContext, inspreq.Inspreqno, inspreq.Siteid);
			if (inspReq4Update == null)
			{
				throw new EntityNotFoundException(typeof(Inspreq), $"{inspreq.Inspreqno},{inspreq.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Inspreq), $"{inspreq.Inspreqno},{inspreq.Siteid}", inspReq4Update.Isusable);
			string activity = inspReq4Update.Activity;
			string customactivity = inspReq4Update.Customactivity;
			string isusable = inspReq4Update.Isusable;
			DateTime? createtime = inspReq4Update.Createtime;
			string creator = inspReq4Update.Creator;
			inspreq.CopyColumsTo(inspReq4Update);
			inspReq4Update.Prevactivity = activity;
			inspReq4Update.Prevcustomactivity = customactivity;
			inspReq4Update.Creator = creator;
			inspReq4Update.Createtime = createtime;
			inspReq4Update.Isusable = isusable;
			inspReq4Update.Activity = text;
			inspreq.CopyCommonField(inspReq4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(inspReq4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteInspReq(IDbContext dbContext, Inspreq[] inspReqList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspReqList", inspReqList);
		string text = "DeleteInspReq";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspreq> list = new List<Inspreq>();
		foreach (Inspreq inspreq in inspReqList)
		{
			Inspreq inspReq4Update = GetInspReq4Update(dbContext, inspreq.Inspreqno, inspreq.Siteid);
			if (inspReq4Update == null)
			{
				throw new EntityNotFoundException(typeof(Inspreq), $"{inspreq.Inspreqno},{inspreq.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Inspreq), $"{inspreq.Inspreqno},{inspreq.Siteid}", inspReq4Update.Isusable);
			inspReq4Update.Isusable = "UnUsable";
			inspreq.CopyCommonFieldUpdatePrev(inspReq4Update, systemTime, dbContext.Tid, text);
			inspreq.CopyExtensionCollection(inspReq4Update);
			list.Add(inspReq4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteInspReq(IDbContext dbContext, Inspreq[] inspReqList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspReqList", inspReqList);
		string text = "UnDeleteInspReq";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspreq> list = new List<Inspreq>();
		foreach (Inspreq inspreq in inspReqList)
		{
			Inspreq inspReq4Update = GetInspReq4Update(dbContext, inspreq.Inspreqno, inspreq.Siteid);
			if (inspReq4Update == null)
			{
				throw new EntityNotFoundException(typeof(Inspreq), $"{inspreq.Inspreqno},{inspreq.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Inspreq), $"{inspreq.Inspreqno},{inspreq.Siteid}", inspReq4Update.Isusable);
			inspReq4Update.Isusable = "Usable";
			inspreq.CopyCommonFieldUpdatePrev(inspReq4Update, systemTime, dbContext.Tid, text);
			inspreq.CopyExtensionCollection(inspReq4Update);
			list.Add(inspReq4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteInspReq(IDbContext dbContext, Inspreq[] inspReqList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspReqList", inspReqList);
		string text = "RealDeleteInspReq";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspreq> list = new List<Inspreq>();
		foreach (Inspreq inspreq in inspReqList)
		{
			Inspreq inspReq4Update = GetInspReq4Update(dbContext, inspreq.Inspreqno, inspreq.Siteid);
			if (inspReq4Update == null)
			{
				throw new EntityNotFoundException(typeof(Inspreq), $"{inspreq.Inspreqno},{inspreq.Siteid}");
			}
			inspreq.CopyCommonFieldUpdatePrev(inspReq4Update, systemTime, dbContext.Tid, text);
			inspreq.CopyExtensionCollection(inspReq4Update);
			list.Add(inspReq4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	internal static string[] ExtractIdOrderBy(string[] inspreqList)
	{
		return (from id in inspreqList
			select (id) into id
			orderby id
			select id).ToArray();
	}

	public static Inspreq FindInspreq(Inspreq[] inspreqList, string inspreqno)
	{
		return inspreqList?.FirstOrDefault((Inspreq inspreq) => inspreq.Inspreqno == inspreqno);
	}
}
