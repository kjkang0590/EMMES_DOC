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
public class INSPREQLOT
{
	private static string _sqlGetInspReqLotSqlDatabase = "SELECT * FROM CIM_INSPREQLOT WHERE INSPREQNO=@INSPREQNO AND INSPTARGET=@INSPTARGET AND INSPLOTID=@INSPLOTID AND REPEATCOUNT=@REPEATCOUNT AND SITEID=@SITEID";

	private static string _sqlGetInspReqLot4UpdateSqlDatabase = "SELECT * FROM CIM_INSPREQLOT WITH(UPDLOCK) WHERE INSPREQNO=@INSPREQNO AND INSPTARGET=@INSPTARGET AND INSPLOTID=@INSPLOTID AND REPEATCOUNT=@REPEATCOUNT AND SITEID=@SITEID";

	private static string _sqlSelectInspReqLotSqlDatabase = "SELECT * FROM CIM_INSPREQLOT WHERE INSPREQNO=@INSPREQNO AND INSPTARGET=@INSPTARGET AND INSPLOTID=@INSPLOTID AND REPEATCOUNT=@REPEATCOUNT AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectInspReqLot4UpdateSqlDatabase = "SELECT * FROM CIM_INSPREQLOT WITH(UPDLOCK) WHERE INSPREQNO=@INSPREQNO AND INSPTARGET=@INSPTARGET AND INSPLOTID=@INSPLOTID AND REPEATCOUNT=@REPEATCOUNT AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetInspReqLotOracleDatabase = "SELECT * FROM CIM_INSPREQLOT WHERE INSPREQNO=:INSPREQNO AND INSPTARGET=:INSPTARGET AND INSPLOTID=:INSPLOTID AND REPEATCOUNT=:REPEATCOUNT AND SITEID=:SITEID";

	private static string _sqlGetInspReqLot4UpdateOracleDatabase = "SELECT * FROM CIM_INSPREQLOT WHERE INSPREQNO=:INSPREQNO AND INSPTARGET=:INSPTARGET AND INSPLOTID=:INSPLOTID AND REPEATCOUNT=:REPEATCOUNT AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectInspReqLotOracleDatabase = "SELECT * FROM CIM_INSPREQLOT WHERE INSPREQNO=:INSPREQNO AND INSPTARGET=:INSPTARGET AND INSPLOTID=:INSPLOTID AND REPEATCOUNT=:REPEATCOUNT AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectInspReqLot4UpdateOracleDatabase = "SELECT * FROM CIM_INSPREQLOT WHERE INSPREQNO=:INSPREQNO AND INSPTARGET=:INSPTARGET AND INSPLOTID=:INSPLOTID AND REPEATCOUNT=:REPEATCOUNT AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Inspreqlot);

	private static string _sqlSelectInspReqLotListByRepeatcountSqlDatabase = "SELECT * FROM CIM_INSPREQLOT WHERE INSPREQNO=@INSPREQNO AND REPEATCOUNT=@REPEATCOUNT AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectInspReqLotListByRepeatcountOracleDatabase = "SELECT * FROM CIM_INSPREQLOT WHERE INSPREQNO=:INSPREQNO AND REPEATCOUNT=:REPEATCOUNT AND SITEID=:SITEID AND ISUSABLE='Usable'";

	public static Inspreqlot GetInspReqLot(IDbContext dbContext, string inspreqno, string insptarget, string insplotid, int repeatcount, string siteid)
	{
		string apiName = "GetInspReqLot";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspreqno},{insptarget},{insplotid},{repeatcount},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetInspReqLotSqlDatabase : _sqlGetInspReqLotOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPREQNO", inspreqno, typeOfThis));
		list.Add(dbContext.CreateParameter("INSPTARGET", insptarget, typeOfThis));
		list.Add(dbContext.CreateParameter("INSPLOTID", insplotid, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_INSPREQLOT", $"{inspreqno},{insptarget},{insplotid},{repeatcount},{siteid}"));
		}
		Inspreqlot result = ContextManager.DirectEntityQuery<Inspreqlot>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspreqno},{insptarget},{insplotid},{repeatcount},{siteid}");
		}
		return result;
	}

	public static Inspreqlot GetInspReqLot4Update(IDbContext dbContext, string inspreqno, string insptarget, string insplotid, int repeatcount, string siteid)
	{
		string apiName = "GetInspReqLot4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspreqno},{insptarget},{insplotid},{repeatcount},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetInspReqLot4UpdateSqlDatabase : _sqlGetInspReqLot4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPREQNO", inspreqno, typeOfThis));
		list.Add(dbContext.CreateParameter("INSPTARGET", insptarget, typeOfThis));
		list.Add(dbContext.CreateParameter("INSPLOTID", insplotid, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_INSPREQLOT", $"{inspreqno},{insptarget},{insplotid},{repeatcount},{siteid}"));
		}
		Inspreqlot result = ContextManager.DirectEntityQuery<Inspreqlot>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspreqno},{insptarget},{insplotid},{repeatcount},{siteid}");
		}
		return result;
	}

	public static Inspreqlot SelectInspReqLot(IDbContext dbContext, string inspreqno, string insptarget, string insplotid, int repeatcount, string siteid)
	{
		string apiName = "SelectInspReqLot";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspreqno},{insptarget},{insplotid},{repeatcount},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectInspReqLotSqlDatabase : _sqlSelectInspReqLotOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPREQNO", inspreqno, typeOfThis));
		list.Add(dbContext.CreateParameter("INSPTARGET", insptarget, typeOfThis));
		list.Add(dbContext.CreateParameter("INSPLOTID", insplotid, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_INSPREQLOT", $"{inspreqno},{insptarget},{insplotid},{repeatcount},{siteid}"));
		}
		Inspreqlot result = ContextManager.DirectEntityQuery<Inspreqlot>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspreqno},{insptarget},{insplotid},{repeatcount},{siteid}");
		}
		return result;
	}

	public static Inspreqlot SelectInspReqLot4Update(IDbContext dbContext, string inspreqno, string insptarget, string insplotid, int repeatcount, string siteid)
	{
		string apiName = "SelectInspReqLot4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspreqno},{insptarget},{insplotid},{repeatcount},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectInspReqLot4UpdateSqlDatabase : _sqlSelectInspReqLot4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPREQNO", inspreqno, typeOfThis));
		list.Add(dbContext.CreateParameter("INSPTARGET", insptarget, typeOfThis));
		list.Add(dbContext.CreateParameter("INSPLOTID", insplotid, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_INSPREQLOT", $"{inspreqno},{insptarget},{insplotid},{repeatcount},{siteid}"));
		}
		Inspreqlot result = ContextManager.DirectEntityQuery<Inspreqlot>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspreqno},{insptarget},{insplotid},{repeatcount},{siteid}");
		}
		return result;
	}

	public static IList<Inspreqlot> SelectInspReqLotListByRepeatcount(IDbContext dbContext, string inspreqno, int repeatcount, string siteid)
	{
		string apiName = "SelectInspReqLotListByInspReq";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspreqno},{repeatcount},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectInspReqLotListByRepeatcountSqlDatabase : _sqlSelectInspReqLotListByRepeatcountOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPREQNO", inspreqno, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_INSPREQLOT", $"{inspreqno},{repeatcount},{siteid}"));
		}
		IList<Inspreqlot> result = ContextManager.DirectEntityQuery<Inspreqlot>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspreqno},{repeatcount},{siteid}");
		}
		return result;
	}

	public static int UpsertInspReqLot(IDbContext dbContext, RequestType requestType, Inspreqlot[] inspReqLotList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateInspReqLotInternal(dbContext, inspReqLotList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateInspReqLot(dbContext, inspReqLotList, optionSet, saveHist), 
			RequestType.DELETE => DeleteInspReqLot(dbContext, inspReqLotList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteInspReqLot(dbContext, inspReqLotList, optionSet, saveHist), 
			_ => RealDeleteInspReqLot(dbContext, inspReqLotList, optionSet, saveHist), 
		};
	}

	private static int CreateInspReqLotInternal(IDbContext dbContext, Inspreqlot[] inspReqLotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspReqLotList", inspReqLotList);
		string text = "CreateInspReqLot";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspreqlot> list = new List<Inspreqlot>();
		foreach (Inspreqlot obj in inspReqLotList)
		{
			Inspreqlot inspreqlot = new Inspreqlot();
			obj.CopyColumsTo(inspreqlot);
			inspreqlot.Activity = text;
			inspreqlot.CheckEntityUsable();
			obj.CopyCommonField(inspreqlot, systemTime, dbContext.Tid, isCreate: true);
			list.Add(inspreqlot);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateInspReqLot(IDbContext dbContext, Inspreqlot[] inspReqLotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspReqLotList", inspReqLotList);
		string text = "UpdateInspReqLot";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspreqlot> list = new List<Inspreqlot>();
		foreach (Inspreqlot inspreqlot in inspReqLotList)
		{
			Inspreqlot inspReqLot4Update = GetInspReqLot4Update(dbContext, inspreqlot.Inspreqno, inspreqlot.Insptarget, inspreqlot.Insplotid, inspreqlot.Repeatcount, inspreqlot.Siteid);
			if (inspReqLot4Update == null)
			{
				throw new EntityNotFoundException(typeof(Inspreqlot), $"{inspreqlot.Inspreqno},{inspreqlot.Insptarget},{inspreqlot.Insplotid},{inspreqlot.Repeatcount},{inspreqlot.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Inspreqlot), $"{inspreqlot.Inspreqno},{inspreqlot.Insptarget},{inspreqlot.Insplotid},{inspreqlot.Repeatcount},{inspreqlot.Siteid}", inspReqLot4Update.Isusable);
			string activity = inspReqLot4Update.Activity;
			string customactivity = inspReqLot4Update.Customactivity;
			string isusable = inspReqLot4Update.Isusable;
			DateTime? createtime = inspReqLot4Update.Createtime;
			string creator = inspReqLot4Update.Creator;
			inspreqlot.CopyColumsTo(inspReqLot4Update);
			inspReqLot4Update.Prevactivity = activity;
			inspReqLot4Update.Prevcustomactivity = customactivity;
			inspReqLot4Update.Creator = creator;
			inspReqLot4Update.Createtime = createtime;
			inspReqLot4Update.Isusable = isusable;
			inspReqLot4Update.Activity = text;
			inspreqlot.CopyCommonField(inspReqLot4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(inspReqLot4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteInspReqLot(IDbContext dbContext, Inspreqlot[] inspReqLotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspReqLotList", inspReqLotList);
		string text = "DeleteInspReqLot";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspreqlot> list = new List<Inspreqlot>();
		foreach (Inspreqlot inspreqlot in inspReqLotList)
		{
			Inspreqlot inspReqLot4Update = GetInspReqLot4Update(dbContext, inspreqlot.Inspreqno, inspreqlot.Insptarget, inspreqlot.Insplotid, inspreqlot.Repeatcount, inspreqlot.Siteid);
			if (inspReqLot4Update == null)
			{
				throw new EntityNotFoundException(typeof(Inspreqlot), $"{inspreqlot.Inspreqno},{inspreqlot.Insptarget},{inspreqlot.Insplotid},{inspreqlot.Repeatcount},{inspreqlot.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Inspreqlot), $"{inspreqlot.Inspreqno},{inspreqlot.Insptarget},{inspreqlot.Insplotid},{inspreqlot.Repeatcount},{inspreqlot.Siteid}", inspReqLot4Update.Isusable);
			inspReqLot4Update.Isusable = "UnUsable";
			inspreqlot.CopyCommonFieldUpdatePrev(inspReqLot4Update, systemTime, dbContext.Tid, text);
			inspreqlot.CopyExtensionCollection(inspReqLot4Update);
			list.Add(inspReqLot4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteInspReqLot(IDbContext dbContext, Inspreqlot[] inspReqLotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspReqLotList", inspReqLotList);
		string text = "UnDeleteInspReqLot";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspreqlot> list = new List<Inspreqlot>();
		foreach (Inspreqlot inspreqlot in inspReqLotList)
		{
			Inspreqlot inspReqLot4Update = GetInspReqLot4Update(dbContext, inspreqlot.Inspreqno, inspreqlot.Insptarget, inspreqlot.Insplotid, inspreqlot.Repeatcount, inspreqlot.Siteid);
			if (inspReqLot4Update == null)
			{
				throw new EntityNotFoundException(typeof(Inspreqlot), $"{inspreqlot.Inspreqno},{inspreqlot.Insptarget},{inspreqlot.Insplotid},{inspreqlot.Repeatcount},{inspreqlot.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Inspreqlot), $"{inspreqlot.Inspreqno},{inspreqlot.Insptarget},{inspreqlot.Insplotid},{inspreqlot.Repeatcount},{inspreqlot.Siteid}", inspReqLot4Update.Isusable);
			inspReqLot4Update.Isusable = "Usable";
			inspreqlot.CopyCommonFieldUpdatePrev(inspReqLot4Update, systemTime, dbContext.Tid, text);
			inspreqlot.CopyExtensionCollection(inspReqLot4Update);
			list.Add(inspReqLot4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteInspReqLot(IDbContext dbContext, Inspreqlot[] inspReqLotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspReqLotList", inspReqLotList);
		string text = "RealDeleteInspReqLot";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspreqlot> list = new List<Inspreqlot>();
		foreach (Inspreqlot inspreqlot in inspReqLotList)
		{
			Inspreqlot inspReqLot4Update = GetInspReqLot4Update(dbContext, inspreqlot.Inspreqno, inspreqlot.Insptarget, inspreqlot.Insplotid, inspreqlot.Repeatcount, inspreqlot.Siteid);
			if (inspReqLot4Update == null)
			{
				throw new EntityNotFoundException(typeof(Inspreqlot), $"{inspreqlot.Inspreqno},{inspreqlot.Insptarget},{inspreqlot.Insplotid},{inspreqlot.Repeatcount},{inspreqlot.Siteid}");
			}
			inspreqlot.CopyCommonFieldUpdatePrev(inspReqLot4Update, systemTime, dbContext.Tid, text);
			inspreqlot.CopyExtensionCollection(inspReqLot4Update);
			list.Add(inspReqLot4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
