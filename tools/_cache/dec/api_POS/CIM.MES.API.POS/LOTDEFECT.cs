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
public class LOTDEFECT
{
	private static string _sqlGetLotDefectSqlDatabase = "SELECT * FROM CIM_LOTDEFECT WHERE LOTID=@LOTID AND DEFECTID=@DEFECTID AND PROCESSNODEID=@PROCESSNODEID AND REPEATCOUNT=@REPEATCOUNT AND SITEID=@SITEID";

	private static string _sqlGetLotDefect4UpdateSqlDatabase = "SELECT * FROM CIM_LOTDEFECT WITH(UPDLOCK) WHERE LOTID=@LOTID AND DEFECTID=@DEFECTID AND PROCESSNODEID=@PROCESSNODEID AND REPEATCOUNT=@REPEATCOUNT AND SITEID=@SITEID";

	private static string _sqlSelectLotDefectSqlDatabase = "SELECT * FROM CIM_LOTDEFECT WHERE LOTID=@LOTID AND DEFECTID=@DEFECTID AND PROCESSNODEID=@PROCESSNODEID AND REPEATCOUNT=@REPEATCOUNT AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLotDefect4UpdateSqlDatabase = "SELECT * FROM CIM_LOTDEFECT WITH(UPDLOCK) WHERE LOTID=@LOTID AND DEFECTID=@DEFECTID AND PROCESSNODEID=@PROCESSNODEID AND REPEATCOUNT=@REPEATCOUNT AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetLotDefectOracleDatabase = "SELECT * FROM CIM_LOTDEFECT WHERE LOTID=:LOTID AND DEFECTID=:DEFECTID AND PROCESSNODEID=:PROCESSNODEID AND REPEATCOUNT=:REPEATCOUNT AND SITEID=:SITEID";

	private static string _sqlGetLotDefect4UpdateOracleDatabase = "SELECT * FROM CIM_LOTDEFECT WHERE LOTID=:LOTID AND DEFECTID=:DEFECTID AND PROCESSNODEID=:PROCESSNODEID AND REPEATCOUNT=:REPEATCOUNT AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectLotDefectOracleDatabase = "SELECT * FROM CIM_LOTDEFECT WHERE LOTID=:LOTID AND DEFECTID=:DEFECTID AND PROCESSNODEID=:PROCESSNODEID AND REPEATCOUNT=:REPEATCOUNT AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLotDefect4UpdateOracleDatabase = "SELECT * FROM CIM_LOTDEFECT WHERE LOTID=:LOTID AND DEFECTID=:DEFECTID AND PROCESSNODEID=:PROCESSNODEID AND REPEATCOUNT=:REPEATCOUNT AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Lotdefect);

	private static string _sqlSelectLotDefectAllListSqlDatabase = "SELECT * FROM CIM_LOTDEFECT WHERE LOTID=@LOTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLotDefectAllListOracleDatabase = "SELECT * FROM CIM_LOTDEFECT WHERE LOTID=:LOTID AND AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLotDefectWithProcessNodeListSqlDatabase = "SELECT * FROM CIM_LOTDEFECT WHERE LOTID=@LOTID AND PROCESSNODEID=@PROCESSNODEID AND REPEATCOUNT=@REPEATCOUNT AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLotDefectWithProcessNodeListOracleDatabase = "SELECT * FROM CIM_LOTDEFECT WHERE LOTID=:LOTID AND PROCESSNODEID=:PROCESSNODEID AND REPEATCOUNT=:REPEATCOUNT AND SITEID=:SITEID AND ISUSABLE='Usable'";

	public static int CancelDefectLot(IDbContext dbContext, Lot lot, Lotdefect[] lotDefectList, CancelDefectLotOptionSet cancelDefectLotoptionSet, bool saveLotHist, bool saveDefectHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("lot", lot);
		ParamChecker.ArgumentNotNullAndHasElement("lotDefectList", lotDefectList);
		string text = "CancelDefectLot";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		bool flag = cancelDefectLotoptionSet?.ExceptLotQtyWithDefectQty ?? true;
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Lotdefect> list2 = new List<Lotdefect>();
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		ParamChecker.ArgumentNotNull("Lotid", lot.Lotid);
		ParamChecker.ArgumentNotNull("Siteid", lot.Siteid);
		string lotid = lot.Lotid;
		string siteid = lot.Siteid;
		Lot lot2 = LOT.SelectLot4Update(dbContext, lotid, siteid);
		if (lot2 == null)
		{
			throw new EntityNotFoundException(typeof(Lot), lotid);
		}
		decimal num2 = default(decimal);
		foreach (Lotdefect lotdefect in lotDefectList)
		{
			ParamChecker.ArgumentNotNull("Defectid", lotdefect.Defectid);
			ParamChecker.ArgumentNotNull("Processnodeid", lotdefect.Processnodeid);
			ParamChecker.ArgumentNotNull("Repeatcount", lotdefect.Repeatcount);
			Lotdefect lotdefect2 = null;
			if ((lotdefect2 = SelectLotDefect(dbContext, lotid, lotdefect.Defectid, lotdefect.Processnodeid, lotdefect.Repeatcount, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lotdefect), lotdefect.Lotid);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", lotdefect2);
			}
			num2 += lotdefect2.Defectqty;
			lotdefect.CopyCommonFieldUpdatePrev(lotdefect2, systemTime, tid, text);
			lotdefect.CopyExtensionCollection(lotdefect2);
			list2.Add(lotdefect2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", lotdefect2);
			}
		}
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", $"Lotid={lot2.Lotid} Defectqty={lot2.Defectqty}");
		}
		if (!flag)
		{
			lot2.Defectqty = lot2.Defectqty.Add(-num2);
			lot2.Qty = lot2.Qty.Add(num2);
		}
		lot.CopyCommonFieldUpdatePrev(lot2, systemTime, tid, text);
		lot.CopyExtensionCollection(lot2);
		list.Add(lot2);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", $"Lotid={lot2.Lotid} Defectqty={lot2.Defectqty}");
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveLotHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list2.ToArray(), saveDefectHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int DefectLot(IDbContext dbContext, Lot lot, Lotdefect[] lotDefectList, DefectLotOptionSet defectLotOptionSet, bool saveLotHist, bool saveDefectHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("lot", lot);
		ParamChecker.ArgumentNotNullAndHasElement("lotDefectList", lotDefectList);
		string text = "DefectLot";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		bool flag = defectLotOptionSet?.ExceptLotQtyWithDefectQty ?? false;
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Lotdefect> list2 = new List<Lotdefect>();
		List<Lotdefect> list3 = new List<Lotdefect>();
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		ParamChecker.ArgumentNotNull("Lotid", lot.Lotid);
		ParamChecker.ArgumentNotNull("Siteid", lot.Siteid);
		string lotid = lot.Lotid;
		string siteid = lot.Siteid;
		Lot lot2;
		if ((lot2 = LOT.SelectLot4Update(dbContext, lotid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Lot), lotid);
		}
		string productdefinitionid = lot2.Productdefinitionid;
		string processdefinitionid = lot2.Processdefinitionid;
		string processnodeid = lot2.Processnodeid;
		int repeatcount = (lot2.Repeatcount.HasValue ? lot2.Repeatcount.Value : 0);
		string processsegmentid = lot2.Processsegmentid;
		decimal value = default(decimal);
		foreach (Lotdefect lotdefect in lotDefectList)
		{
			ParamChecker.ArgumentNotNull("Defectid", lotdefect.Defectid);
			ParamChecker.ArgumentNotNull("Defectqty", lotdefect.Defectqty);
			string defectid = lotdefect.Defectid;
			decimal repeatcount2 = lotdefect.Repeatcount;
			Lotdefect lotdefect2;
			if ((lotdefect2 = SelectLotDefect4Update(dbContext, lotid, defectid, processnodeid, repeatcount2, siteid)) != null)
			{
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "Update previous Lotdefect information.", lotdefect2);
				}
				if (MesLogger.IsDebugEnabled("API"))
				{
					MesLogger.DebugTidApi(tid, "Before Execute", lotdefect2);
				}
				lot2.Defectqty = lot2.Defectqty.Add(-lotdefect2.Defectqty);
				value += lotdefect.Defectqty;
				lotdefect2.Defectqty = lotdefect.Defectqty;
				lotdefect2.Unitid = lotdefect.Unitid;
				lotdefect.CopyCommonFieldUpdatePrev(lotdefect2, systemTime, tid, text);
				lotdefect.CopyExtensionCollection(lotdefect2);
				list3.Add(lotdefect2);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Execute", lotdefect2);
				}
				continue;
			}
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "Create new Lotdefect information.", null);
			}
			value += lotdefect.Defectqty;
			Lotdefect lotdefect3 = new Lotdefect();
			lotdefect.CopyColumsTo(lotdefect3);
			lotdefect3.Lotid = lotid;
			lotdefect3.Productdefinitionid = productdefinitionid;
			lotdefect3.Processdefinitionid = processdefinitionid;
			lotdefect3.Processnodeid = processnodeid;
			lotdefect3.Repeatcount = repeatcount;
			lotdefect3.Processsegmentid = processsegmentid;
			lotdefect3.Siteid = siteid;
			lotdefect3.Defectqty = lotdefect.Defectqty;
			lotdefect3.Unitid = lotdefect.Unitid;
			lotdefect3.Isusable = "Usable";
			lotdefect3.Activity = text;
			lotdefect.CopyCommonField(lotdefect3, systemTime, tid, isCreate: true);
			list2.Add(lotdefect3);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", lotdefect3);
			}
		}
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", $"Lotid={lot2.Lotid} Defectqty={lot2.Defectqty}");
		}
		lot2.Defectqty = lot2.Defectqty.Add(value);
		if (!flag)
		{
			lot2.Qty -= (decimal?)value;
		}
		lot.CopyCommonFieldUpdatePrev(lot2, systemTime, tid, text);
		lot.CopyExtensionCollection(lot2);
		list.Add(lot2);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", $"Lotid={lot2.Lotid} Defectqty={lot2.Defectqty}");
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveLotHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list2.ToArray(), saveDefectHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list3.ToArray(), saveDefectHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static Lotdefect GetLotDefect(IDbContext dbContext, string lotid, string defectid, string processnodeid, int repeatcount, string siteid)
	{
		string apiName = "GetLotDefect";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{defectid},{processnodeid},{repeatcount},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLotDefectSqlDatabase : _sqlGetLotDefectOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("DEFECTID", defectid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSNODEID", processnodeid, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOTDEFECT", $"{lotid},{defectid},{processnodeid},{repeatcount},{siteid}"));
		}
		Lotdefect result = ContextManager.DirectEntityQuery<Lotdefect>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{defectid},{processnodeid},{repeatcount},{siteid}");
		}
		return result;
	}

	public static Lotdefect GetLotDefect4Update(IDbContext dbContext, string lotid, string defectid, string processnodeid, int repeatcount, string siteid)
	{
		string apiName = "GetLotDefect4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{defectid},{processnodeid},{repeatcount},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLotDefect4UpdateSqlDatabase : _sqlGetLotDefect4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("DEFECTID", defectid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSNODEID", processnodeid, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_LOTDEFECT", $"{lotid},{defectid},{processnodeid},{repeatcount},{siteid}"));
		}
		Lotdefect result = ContextManager.DirectEntityQuery<Lotdefect>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{defectid},{processnodeid},{repeatcount},{siteid}");
		}
		return result;
	}

	public static Lotdefect SelectLotDefect(IDbContext dbContext, string lotid, string defectid, string processnodeid, decimal repeatcount, string siteid)
	{
		string apiName = "SelectLotDefect";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{defectid},{processnodeid},{repeatcount},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotDefectSqlDatabase : _sqlSelectLotDefectOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("DEFECTID", defectid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSNODEID", processnodeid, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOTDEFECT", $"{lotid},{defectid},{processnodeid},{repeatcount},{siteid}"));
		}
		Lotdefect result = ContextManager.DirectEntityQuery<Lotdefect>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{defectid},{processnodeid},{repeatcount},{siteid}");
		}
		return result;
	}

	public static Lotdefect SelectLotDefect4Update(IDbContext dbContext, string lotid, string defectid, string processnodeid, decimal repeatcount, string siteid)
	{
		string apiName = "SelectLotDefect4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{defectid},{processnodeid},{repeatcount},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotDefect4UpdateSqlDatabase : _sqlSelectLotDefect4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("DEFECTID", defectid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSNODEID", processnodeid, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_LOTDEFECT", $"{lotid},{defectid},{processnodeid},{repeatcount},{siteid}"));
		}
		Lotdefect result = ContextManager.DirectEntityQuery<Lotdefect>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{defectid},{processnodeid},{repeatcount},{siteid}");
		}
		return result;
	}

	public static int UpsertLotDefect(IDbContext dbContext, RequestType requestType, Lotdefect[] lotDefectList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateLotDefectInternal(dbContext, lotDefectList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateLotDefect(dbContext, lotDefectList, optionSet, saveHist), 
			RequestType.DELETE => DeleteLotDefect(dbContext, lotDefectList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteLotDefect(dbContext, lotDefectList, optionSet, saveHist), 
			_ => RealDeleteLotDefect(dbContext, lotDefectList, optionSet, saveHist), 
		};
	}

	private static int CreateLotDefectInternal(IDbContext dbContext, Lotdefect[] lotDefectList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotDefectList", lotDefectList);
		string text = "CreateLotDefect";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotdefect> list = new List<Lotdefect>();
		foreach (Lotdefect obj in lotDefectList)
		{
			Lotdefect lotdefect = new Lotdefect();
			obj.CopyColumsTo(lotdefect);
			lotdefect.Activity = text;
			lotdefect.CheckEntityUsable();
			obj.CopyCommonField(lotdefect, systemTime, dbContext.Tid, isCreate: true);
			list.Add(lotdefect);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateLotDefect(IDbContext dbContext, Lotdefect[] lotDefectList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotDefectList", lotDefectList);
		string text = "UpdateLotDefect";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotdefect> list = new List<Lotdefect>();
		foreach (Lotdefect lotdefect in lotDefectList)
		{
			Lotdefect lotDefect4Update = GetLotDefect4Update(dbContext, lotdefect.Lotid, lotdefect.Defectid, lotdefect.Processnodeid, lotdefect.Repeatcount, lotdefect.Siteid);
			if (lotDefect4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lotdefect), $"{lotdefect.Lotid},{lotdefect.Defectid},{lotdefect.Processnodeid},{lotdefect.Repeatcount},{lotdefect.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Lotdefect), $"{lotdefect.Lotid},{lotdefect.Defectid},{lotdefect.Processnodeid},{lotdefect.Repeatcount},{lotdefect.Siteid}", lotDefect4Update.Isusable);
			string activity = lotDefect4Update.Activity;
			string customactivity = lotDefect4Update.Customactivity;
			string isusable = lotDefect4Update.Isusable;
			DateTime? createtime = lotDefect4Update.Createtime;
			string creator = lotDefect4Update.Creator;
			lotdefect.CopyColumsTo(lotDefect4Update);
			lotDefect4Update.Prevactivity = activity;
			lotDefect4Update.Prevcustomactivity = customactivity;
			lotDefect4Update.Creator = creator;
			lotDefect4Update.Createtime = createtime;
			lotDefect4Update.Isusable = isusable;
			lotDefect4Update.Activity = text;
			lotdefect.CopyCommonField(lotDefect4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(lotDefect4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteLotDefect(IDbContext dbContext, Lotdefect[] lotDefectList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotDefectList", lotDefectList);
		string text = "DeleteLotDefect";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotdefect> list = new List<Lotdefect>();
		foreach (Lotdefect lotdefect in lotDefectList)
		{
			Lotdefect lotDefect4Update = GetLotDefect4Update(dbContext, lotdefect.Lotid, lotdefect.Defectid, lotdefect.Processnodeid, lotdefect.Repeatcount, lotdefect.Siteid);
			if (lotDefect4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lotdefect), $"{lotdefect.Lotid},{lotdefect.Defectid},{lotdefect.Processnodeid},{lotdefect.Repeatcount},{lotdefect.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Lotdefect), $"{lotdefect.Lotid},{lotdefect.Defectid},{lotdefect.Processnodeid},{lotdefect.Repeatcount},{lotdefect.Siteid}", lotDefect4Update.Isusable);
			lotDefect4Update.Isusable = "UnUsable";
			lotdefect.CopyCommonFieldUpdatePrev(lotDefect4Update, systemTime, dbContext.Tid, text);
			lotdefect.CopyExtensionCollection(lotDefect4Update);
			list.Add(lotDefect4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteLotDefect(IDbContext dbContext, Lotdefect[] lotDefectList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotDefectList", lotDefectList);
		string text = "UnDeleteLotDefect";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotdefect> list = new List<Lotdefect>();
		foreach (Lotdefect lotdefect in lotDefectList)
		{
			Lotdefect lotDefect4Update = GetLotDefect4Update(dbContext, lotdefect.Lotid, lotdefect.Defectid, lotdefect.Processnodeid, lotdefect.Repeatcount, lotdefect.Siteid);
			if (lotDefect4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lotdefect), $"{lotdefect.Lotid},{lotdefect.Defectid},{lotdefect.Processnodeid},{lotdefect.Repeatcount},{lotdefect.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Lotdefect), $"{lotdefect.Lotid},{lotdefect.Defectid},{lotdefect.Processnodeid},{lotdefect.Repeatcount},{lotdefect.Siteid}", lotDefect4Update.Isusable);
			lotDefect4Update.Isusable = "Usable";
			lotdefect.CopyCommonFieldUpdatePrev(lotDefect4Update, systemTime, dbContext.Tid, text);
			lotdefect.CopyExtensionCollection(lotDefect4Update);
			list.Add(lotDefect4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteLotDefect(IDbContext dbContext, Lotdefect[] lotDefectList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotDefectList", lotDefectList);
		string text = "RealDeleteLotDefect";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotdefect> list = new List<Lotdefect>();
		foreach (Lotdefect lotdefect in lotDefectList)
		{
			Lotdefect lotDefect4Update = GetLotDefect4Update(dbContext, lotdefect.Lotid, lotdefect.Defectid, lotdefect.Processnodeid, lotdefect.Repeatcount, lotdefect.Siteid);
			if (lotDefect4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lotdefect), $"{lotdefect.Lotid},{lotdefect.Defectid},{lotdefect.Processnodeid},{lotdefect.Repeatcount},{lotdefect.Siteid}");
			}
			lotdefect.CopyCommonFieldUpdatePrev(lotDefect4Update, systemTime, dbContext.Tid, text);
			lotdefect.CopyExtensionCollection(lotDefect4Update);
			list.Add(lotDefect4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static IList<Lotdefect> SelectLotDefectAllList(IDbContext dbContext, string lotid, string siteid)
	{
		string apiName = "SelectLotDefectAllList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotDefectAllListSqlDatabase : _sqlSelectLotDefectAllListOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOTDEFECT", $"{lotid},{siteid}"));
		}
		IList<Lotdefect> result = ContextManager.DirectEntityQuery<Lotdefect>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{siteid}");
		}
		return result;
	}

	public static IList<Lotdefect> SelectLotDefectWithProcessNodeList(IDbContext dbContext, string lotid, string processnodeid, int repeatcount, string siteid)
	{
		string apiName = "SelectLotDefectAllList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{processnodeid},{repeatcount},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotDefectWithProcessNodeListSqlDatabase : _sqlSelectLotDefectWithProcessNodeListOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSNODEID", processnodeid, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOTDEFECT", $"{lotid},{processnodeid},{repeatcount},{siteid}"));
		}
		IList<Lotdefect> result = ContextManager.DirectEntityQuery<Lotdefect>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{processnodeid},{repeatcount},{siteid}");
		}
		return result;
	}
}
