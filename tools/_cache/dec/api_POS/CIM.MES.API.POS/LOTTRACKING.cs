using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.POS;

[MESAPI]
public class LOTTRACKING
{
	private static string _sqlGetLotTrackingSqlDatabase = "SELECT * FROM CIM_LOTTRACKING WHERE LOTID=@LOTID AND PROCESSNODEID=@PROCESSNODEID AND REPEATCOUNT=@REPEATCOUNT AND SITEID=@SITEID ORDER BY MODIFYTIME DESC ";

	private static string _sqlGetLotTrackingOracleDatabase = "SELECT * FROM CIM_LOTTRACKING WHERE LOTID=:LOTID AND PROCESSNODEID=:PROCESSNODEID AND REPEATCOUNT=:REPEATCOUNT AND SITEID=:SITEID ORDER BY MODIFYTIME DESC";

	private static string _sqlGetLotTracking4UpdateSqlDatabase = "SELECT * FROM CIM_LOTTRACKING WITH(UPDLOCK) WHERE LOTID=@LOTID AND PROCESSNODEID=@PROCESSNODEID AND REPEATCOUNT=@REPEATCOUNT AND SITEID=@SITEID";

	private static string _sqlGetLotTracking4UpdateOracleDatabase = "SELECT * FROM CIM_LOTTRACKING WHERE LOTID=:LOTID AND PROCESSNODEID=:PROCESSNODEID AND REPEATCOUNT=:REPEATCOUNT AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlGetLastLotTrackingSqlDatabase = "SELECT * FROM CIM_LOTTRACKING WHERE LOTID=@LOTID AND SITEID=@SITEID ORDER BY MODIFYTIME DESC ";

	private static string _sqlGetLastLotTrackingOracleDatabase = "SELECT * FROM CIM_LOTTRACKING WHERE LOTID=:LOTID AND SITEID=:SITEID ORDER BY MODIFYTIME DESC";

	private static Type typeOfThis = typeof(Lottracking);

	public static Lottracking GetLotTracking(IDbContext dbContext, string lotId, string processNodeId, int repeatcount, string siteId)
	{
		string apiName = "GetLotTracking";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotId},{processNodeId},{repeatcount},{siteId}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLotTrackingSqlDatabase : _sqlGetLotTrackingOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotId, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSNODEID", processNodeId, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOTTRACKING", $"{lotId},{processNodeId},{repeatcount},{siteId}"));
		}
		Lottracking result = ContextManager.DirectEntityQuery<Lottracking>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotId},{processNodeId},{repeatcount},{siteId}");
		}
		return result;
	}

	public static Lottracking GetLotTracking4Update(IDbContext dbContext, string lotId, string processNodeId, int repeatcount, string siteId)
	{
		string apiName = "GetLotTracking4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotId},{processNodeId},{repeatcount},{siteId}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLotTracking4UpdateSqlDatabase : _sqlGetLotTracking4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotId, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSNODEID", processNodeId, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_LOTTRACKING", $"{lotId},{processNodeId},{repeatcount},{siteId}"));
		}
		Lottracking result = ContextManager.DirectEntityQuery<Lottracking>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotId},{processNodeId},{repeatcount},{siteId}");
		}
		return result;
	}

	public static Lottracking GetLastLotTracking(IDbContext dbContext, string lotId, string siteId)
	{
		string apiName = "GetLastLotTracking";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotId},{siteId}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLastLotTrackingSqlDatabase : _sqlGetLastLotTrackingOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotId, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOTTRACKING", $"{lotId},{siteId}"));
		}
		Lottracking? result = ContextManager.DirectEntityQuery<Lottracking>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotId},{siteId}");
		}
		return result;
	}

	public static int TrackinLotTracking(IDbContext dbContext, Lot lot, Lot? storedLot = null)
	{
		int num = 0;
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("lot", lot);
		if (storedLot == null)
		{
			storedLot = LOT.GetLot(dbContext, lot.Lotid, lot.Siteid);
		}
		if (storedLot == null)
		{
			throw new EntityNotFoundException(typeof(Lot), $"{storedLot.Lotid},{storedLot.Siteid}");
		}
		ParamChecker.EntityUsable(typeof(Lot), $"{storedLot.Lotid},{storedLot.Siteid}", storedLot.Isusable);
		int num2 = (storedLot.Repeatcount.HasValue ? storedLot.Repeatcount.Value : 0);
		Lottracking lotTracking = GetLotTracking(dbContext, lot.Lotid, lot.Processnodeid, num2, lot.Siteid);
		if (lotTracking == null)
		{
			lotTracking = new Lottracking
			{
				Lotid = lot.Lotid,
				Processnodeid = storedLot.Processnodeid,
				Repeatcount = num2,
				Processdefinitionid = storedLot.Processdefinitionid,
				Processsegmentid = storedLot.Processsegmentid,
				Productdefinitionid = storedLot.Productdefinitionid,
				Recipedefinitionid = storedLot.Recipedefinitionid,
				State = storedLot.State,
				Trackintime = storedLot.Trackintime,
				Trackinstate = storedLot.State,
				Trackinequipmentid = storedLot.Equipmentid,
				Trackinuserid = storedLot.Modifier,
				Trackinqty = storedLot.Qty,
				Trackouttime = null,
				Trackoutequipmentid = null,
				Trackoutuserid = null,
				Trackoutqty = null,
				Defectqty = null,
				Unitid = storedLot.Unitid,
				Isusable = storedLot.Isusable,
				Siteid = storedLot.Siteid
			};
			storedLot.CopyCommonFieldUpdatePrev(lotTracking, lot.Modifytime, lot.Tid, lot.Activity);
			SetValueCollection(dbContext, storedLot, lotTracking);
			return num + CreateLotTrackingInternal(dbContext, new Lottracking[1] { lotTracking });
		}
		lotTracking.Processdefinitionid = storedLot.Processdefinitionid;
		lotTracking.Processsegmentid = storedLot.Processsegmentid;
		lotTracking.Productdefinitionid = storedLot.Productdefinitionid;
		lotTracking.Recipedefinitionid = storedLot.Recipedefinitionid;
		lotTracking.State = storedLot.State;
		lotTracking.Trackintime = storedLot.Trackintime;
		lotTracking.Trackinstate = storedLot.State;
		lotTracking.Trackinequipmentid = storedLot.Equipmentid;
		lotTracking.Trackinuserid = storedLot.Modifier;
		lotTracking.Trackinqty = storedLot.Qty;
		lotTracking.Trackouttime = null;
		lotTracking.Trackoutequipmentid = null;
		lotTracking.Trackoutuserid = null;
		lotTracking.Trackoutqty = null;
		lotTracking.Defectqty = null;
		lotTracking.Unitid = storedLot.Unitid;
		lotTracking.Isusable = storedLot.Isusable;
		lotTracking.Siteid = storedLot.Siteid;
		storedLot.CopyCommonFieldUpdatePrev(lotTracking, lot.Modifytime, lot.Tid, lot.Activity);
		SetValueCollection(dbContext, storedLot, lotTracking);
		return num + ExecuteLotTracking(dbContext, new Lottracking[1] { lotTracking });
	}

	private static void SetValueCollection(IDbContext dbContext, Lot lot, Lottracking lottracking)
	{
		Tablecolumn[] array = dbContext.Cache.FindTableColumn(lottracking.TableName)?.ToArray();
		if (array != null && array.Length < 1)
		{
			return;
		}
		foreach (Tablecolumn item in array.Where((Tablecolumn c) => "EXT".Equals(c.Columntype)))
		{
			lottracking.SetValue(item.Columnname, lot.GetValue(item.Columnname));
		}
	}

	internal static int TrackinLotTrackingBulk(IDbContext dbContext, Lot[] lotList)
	{
		int result = 0;
		Lot storedLot = lotList[0];
		foreach (Lot lot in lotList)
		{
			TrackinLotTracking(dbContext, lot, storedLot);
		}
		return result;
	}

	public static int CancelTrackinLotTracking(IDbContext dbContext, Lot lot)
	{
		int num = 0;
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("lot", lot);
		Lot lot2 = LOT.GetLot(dbContext, lot.Lotid, lot.Siteid);
		if (lot2 == null)
		{
			throw new EntityNotFoundException(typeof(Lot), $"{lot2.Lotid},{lot2.Siteid}");
		}
		ParamChecker.EntityUsable(typeof(Lot), $"{lot2.Lotid},{lot2.Siteid}", lot2.Isusable);
		int num2 = (lot2.Repeatcount.HasValue ? lot2.Repeatcount.Value : 0);
		Lottracking lastLotTracking = GetLastLotTracking(dbContext, lot2.Lotid, lot2.Siteid);
		if (lastLotTracking == null)
		{
			return num;
		}
		if (lot2.Processnodeid != lastLotTracking.Processnodeid && num2 == lastLotTracking.Repeatcount)
		{
			return num;
		}
		if (!lastLotTracking.Trackouttime.HasValue)
		{
			string text = "RealDeleteLotTracking";
			MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
			lot.CopyCommonFieldUpdatePrev(lastLotTracking, lot.Modifytime, lot.Tid, text);
			SetValueCollection(dbContext, lot, lastLotTracking);
			num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, new Lottracking[1] { lastLotTracking }, saveHist: false);
			MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		}
		return num;
	}

	public static int TrackoutLotTracking(IDbContext dbContext, Lot lot, TrackOutOptionSet optionSet)
	{
		int num = 0;
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("lot", lot);
		Lot lot2 = LOT.GetLot(dbContext, lot.Lotid, lot.Siteid);
		if (lot2 == null)
		{
			throw new EntityNotFoundException(typeof(Lot), $"{lot2.Lotid},{lot2.Siteid}");
		}
		int num2 = (lot2.Repeatcount.HasValue ? lot2.Repeatcount.Value : 0);
		string equipmentid = lot2.Equipmentid;
		if ((optionSet == null || optionSet.TrackingHistoryEmptyEquipmentLotEquipment) && string.IsNullOrEmpty(equipmentid))
		{
			equipmentid = lot.Equipmentid;
		}
		decimal value = default(decimal);
		IList<Lotdefect> list = LOTDEFECT.SelectLotDefectWithProcessNodeList(dbContext, lot2.Lotid, lot2.Processnodeid, lot2.Repeatcount.HasValue ? lot2.Repeatcount.Value : 0, lot2.Siteid);
		if (list != null)
		{
			value = list.Sum((Lotdefect lot) => lot.Defectqty);
		}
		Lottracking lotTracking = GetLotTracking(dbContext, lot.Lotid, lot.Processnodeid, num2, lot.Siteid);
		if (lotTracking == null)
		{
			lotTracking = new Lottracking
			{
				Lotid = lot.Lotid,
				Processnodeid = lot.Processnodeid,
				Repeatcount = num2,
				Processdefinitionid = lot.Processdefinitionid,
				Processsegmentid = lot.Processsegmentid,
				Productdefinitionid = lot.Productdefinitionid,
				Recipedefinitionid = lot.Recipedefinitionid,
				State = lot2.State,
				Trackintime = lot2.Trackintime,
				Trackinstate = lot2.State,
				Trackinequipmentid = lot2.Equipmentid,
				Trackinuserid = lot2.Trackinuser,
				Trackinqty = lot2.Qty,
				Trackouttime = lot2.Trackouttime,
				Trackoutstate = lot2.State,
				Trackoutequipmentid = equipmentid,
				Trackoutuserid = lot.Modifier,
				Trackoutqty = lot2.Qty,
				Defectqty = value,
				Unitid = lot2.Unitid,
				Isusable = lot.Isusable,
				Siteid = lot.Siteid
			};
			lot.CopyCommonFieldUpdatePrev(lotTracking, lot.Modifytime, lot.Tid, "TrackoutLot");
			SetValueCollection(dbContext, lot, lotTracking);
			return num + CreateLotTrackingInternal(dbContext, new Lottracking[1] { lotTracking });
		}
		lotTracking.Recipedefinitionid = lot2.Recipedefinitionid;
		lotTracking.State = lot2.State;
		lotTracking.Trackouttime = lot2.Trackouttime;
		lotTracking.Trackoutstate = lot2.State;
		lotTracking.Trackoutequipmentid = equipmentid;
		lotTracking.Trackoutuserid = lot.Modifier;
		lotTracking.Trackoutqty = lot2.Qty;
		lotTracking.Defectqty = value;
		lotTracking.Unitid = lot2.Unitid;
		lotTracking.Isusable = lot.Isusable;
		lotTracking.Siteid = lot.Siteid;
		lot2.CopyCommonFieldUpdatePrev(lotTracking, lot2.Modifytime, lot2.Tid, lot2.Activity);
		SetValueCollection(dbContext, lot, lotTracking);
		return num + ExecuteLotTracking(dbContext, new Lottracking[1] { lotTracking });
	}

	internal static int TrackoutLotTrackingBulk(IDbContext dbContext, Lot lot, Lot[] lotList, TrackOutOptionSet optionSet)
	{
		int result = 0;
		foreach (Lot lot2 in lotList)
		{
			lot.CopySameColumnsTo(lot2);
			TrackoutLotTracking(dbContext, lot2, optionSet);
		}
		return result;
	}

	private static int CreateLotTrackingInternal(IDbContext dbContext, Lottracking[] lottrackingList)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lottrackingList", lottrackingList);
		string text = "CreateLotTracking";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lottracking> list = new List<Lottracking>();
		foreach (Lottracking lottracking in lottrackingList)
		{
			Lottracking dest = new Lottracking();
			lottracking.CopySameColumnsTo(dest);
			lottracking.CopyCommonFieldUpdatePrev(dest, systemTime, dbContext.Tid, text);
			lottracking.CopyExtensionCollection(dest);
			list.Add(lottracking);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist: false);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int ExecuteLotTracking(IDbContext dbContext, Lottracking[] lottrackingList)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lottrackingList", lottrackingList);
		string text = "UpdateLotTracking";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lottracking> list = new List<Lottracking>();
		foreach (Lottracking lottracking in lottrackingList)
		{
			Lottracking lottracking2 = new Lottracking();
			lottracking.CopySameColumnsTo(lottracking2);
			ParamChecker.EntityUsable(typeof(Lottracking), $"{lottracking.Lotid},{lottracking.Processnodeid},{lottracking.Repeatcount},{lottracking.Siteid}", lottracking.Isusable);
			lottracking.CopyCommonFieldUpdatePrev(lottracking2, systemTime, dbContext.Tid, text);
			lottracking.CopyExtensionCollection(lottracking2);
			list.Add(lottracking2);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist: false);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int UpdateLotTracking(IDbContext dbContext, Lottracking[] lotTrackingList)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotTrackingList", lotTrackingList);
		string text = "ModifyLotTracking";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lottracking> list = new List<Lottracking>();
		foreach (Lottracking lottracking in lotTrackingList)
		{
			Lottracking lottracking2 = new Lottracking();
			lottracking.CopySameColumnsTo(lottracking2);
			ParamChecker.EntityUsable(typeof(Lottracking), $"{lottracking.Lotid},{lottracking.Processnodeid},{lottracking.Repeatcount},{lottracking.Siteid}", lottracking.Isusable);
			lottracking.CopyCommonFieldUpdatePrev(lottracking2, systemTime, dbContext.Tid, text);
			lottracking.CopyExtensionCollection(lottracking2);
			list.Add(lottracking2);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist: false);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
