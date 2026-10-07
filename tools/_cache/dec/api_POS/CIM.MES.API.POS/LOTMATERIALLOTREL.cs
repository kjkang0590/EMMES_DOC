using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.POS;

[MESAPI]
public class LOTMATERIALLOTREL
{
	private static string _sqlGetLotMaterialLotRelSqlDatabase = "SELECT * FROM CIM_LOTMATERIALLOTREL WHERE CONSUMEID=@CONSUMEID";

	private static string _sqlSelectLotMaterialLotRelSqlDatabase = "SELECT * FROM CIM_LOTMATERIALLOTREL WHERE CONSUMEID=@CONSUMEID AND ISUSABLE='Usable'";

	private static string _sqlGetLotMaterialLotRel4UpdateSqlDatabase = "SELECT * FROM CIM_LOTMATERIALLOTREL WITH(UPDLOCK) WHERE CONSUMEID=@CONSUMEID";

	private static string _sqlSelectLotMaterialLotRel4UpdateSqlDatabase = "SELECT * FROM CIM_LOTMATERIALLOTREL WITH(UPDLOCK) WHERE CONSUMEID=@CONSUMEID AND ISUSABLE='Usable'";

	private static string _sqlGetLotMaterialLotRelOracleDatabase = "SELECT * FROM CIM_LOTMATERIALLOTREL WHERE CONSUMEID=@CONSUMEID";

	private static string _sqlGetLotMaterialLotRel4UpdateOracleDatabase = "SELECT * FROM CIM_LOTMATERIALLOTREL WHERE CONSUMEID=@CONSUMEID FOR UPDATE";

	private static string _sqlSelectLotMaterialLotRelOracleDatabase = "SELECT * FROM CIM_LOTMATERIALLOTREL WHERE CONSUMEID=@CONSUMEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLotMaterialLotRel4UpdateOracleDatabase = "SELECT * FROM CIM_LOTMATERIALLOTREL WHERE CONSUMEID=@CONSUMEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Lotmateriallotrel);

	private static string _sqlSelectLotMaterialLotRelWithConsumeidList4UpdateSqlDatabase = "SELECT * FROM CIM_LOTMATERIALLOTREL WITH(UPDLOCK) WHERE CONSUMEID IN (&CONSUMEIDLIST) AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLotMaterialLotRelWithConsumeidList4UpdateOracleDatabase = "SELECT * FROM CIM_LOTMATERIALLOTREL WHERE CONSUMEID IN (&CONSUMEIDLIST) AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static string _sqlSelectLotMaterialLotRelWithMaterialLot4UpdateSqlDatabase = "SELECT * FROM CIM_LOTMATERIALLOTREL WITH(UPDLOCK) WHERE LOTID=@LOTID AND MATERIALLOTID=@MATERIALLOTID AND PROCESSNODEID=@PROCESSNODEID AND REPEATCOUNT=@REPEATCOUNT AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLotMaterialLotRelWithMaterialLot4UpdateOracleDatabase = "SELECT * FROM CIM_LOTMATERIALLOTREL WHERE LOTID=:LOTID AND MATERIALLOTID=:MATERIALLOTID AND PROCESSNODEID=:PROCESSNODEID AND REPEATCOUNT=:REPEATCOUNT AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static string _sqlSelectLotMaterialLotRelWithProcessnodeidList4Update4UpdateSqlDatabase = "SELECT * FROM CIM_LOTMATERIALLOTREL WHERE LOTID=@LOTID AND PROCESSNODEID=@PROCESSNODEID AND REPEATCOUNT=@REPEATCOUNT AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLotMaterialLotRelWithProcessnodeidList4UpdateOracleDatabase = "SELECT * FROM CIM_LOTMATERIALLOTREL WHERE LOTID=:LOTID AND PROCESSNODEID=:PROCESSNODEID AND REPEATCOUNT=:REPEATCOUNT AND SITEID=:SITEID AND ISUSABLE='Usable'";

	public static int CancelConsumeMaterialLot(IDbContext dbContext, Lot lot, long[] consumeIdList, CancelConsumeMaterialLotOptionSet optionSet, bool saveLotHist, bool saveMaterialLotHist, bool saveLotMaterialLotRelHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("lot", lot);
		ParamChecker.ArgumentNotNull(consumeIdList);
		string text = "CancelConsumeMaterialLot";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Lotmateriallotrel> list2 = new List<Lotmateriallotrel>();
		List<Materiallot> list3 = new List<Materiallot>();
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		ParamChecker.ArgumentNotNull("Lotid", lot.Lotid);
		ParamChecker.ArgumentNotNull("Siteid", lot.Siteid);
		bool flag = false;
		if (optionSet != null)
		{
			flag = optionSet.CancelTerminateMaterialLotQtyZero;
		}
		string lotid = lot.Lotid;
		string siteid = lot.Siteid;
		Lot lot2;
		if ((lot2 = LOT.SelectLot4Update(dbContext, lotid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Lot), lotid);
		}
		Lotmateriallotrel[] array = SelectLotMaterialLotRelWithConsumeidList4Update(dbContext, consumeIdList, siteid).ToArray();
		ParamChecker.ArgumentSameValue("Consume DataCheck", consumeIdList.Length, array.Length);
		Materiallot[] materialLotList = MATERIALLOT.SelectMaterialLotList4Update(dbContext, array, siteid).ToArray();
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", lot2);
		}
		lot.CopyCommonFieldUpdatePrev(lot2, systemTime, tid, text);
		lot.CopyExtensionCollection(lot2);
		list.Add(lot2);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", lot2);
		}
		for (int i = 0; i < consumeIdList.Length; i++)
		{
			long num2 = consumeIdList[i];
			ParamChecker.ArgumentNotNull("Consumeid", num2);
			ParamChecker.ArgumentNotNull("Siteid", siteid);
			Lotmateriallotrel lotmateriallotrel;
			if ((lotmateriallotrel = FindLotMaterialLotRel(array, num2)) == null)
			{
				throw new EntityNotFoundException(typeof(Lotmateriallotrel), num2.ToString());
			}
			Materiallot materiallot;
			if ((materiallot = MATERIALLOT.FindMaterialLot(materialLotList, lotmateriallotrel.Materiallotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Materiallot), lotmateriallotrel.Materiallotid);
			}
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "Delete previous consume information.", lotmateriallotrel);
			}
			lot.CopyCommonFieldUpdatePrev(lotmateriallotrel, systemTime, tid, text);
			list2.Add(lotmateriallotrel);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", lotmateriallotrel);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", materiallot);
			}
			if (flag)
			{
				decimal? qty = materiallot.Qty;
				if (((qty.GetValueOrDefault() <= default(decimal)) & qty.HasValue) && materiallot.State == "Terminated")
				{
					materiallot.State = materiallot.Prevstate;
					materiallot.Prevstate = "Terminated";
				}
			}
			materiallot.Prevqty = materiallot.Qty;
			materiallot.Qty = materiallot.Qty.Add(lotmateriallotrel.Qty);
			materiallot.CopyCommonFieldUpdatePrev(materiallot, systemTime, tid, text);
			list3.Add(materiallot);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", materiallot);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list2.ToArray(), saveLotMaterialLotRelHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveLotHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list3.ToArray(), saveMaterialLotHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static Lotmateriallotrel GetLotMaterialLotRel(IDbContext dbContext, long consumeid)
	{
		string apiName = "GetLotMaterialLotRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{consumeid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLotMaterialLotRelSqlDatabase : _sqlGetLotMaterialLotRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CONSUMEID", consumeid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOTMATERIALLOTREL", $"{consumeid}"));
		}
		Lotmateriallotrel? result = ContextManager.DirectEntityQuery<Lotmateriallotrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{consumeid}");
		}
		return result;
	}

	public static Lotmateriallotrel GetLotMaterialLotRel4Update(IDbContext dbContext, long consumeid)
	{
		string apiName = "GetLotMaterialLotRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{consumeid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLotMaterialLotRel4UpdateSqlDatabase : _sqlGetLotMaterialLotRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CONSUMEID", consumeid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_LOTMATERIALLOTREL", $"{consumeid}"));
		}
		Lotmateriallotrel? result = ContextManager.DirectEntityQuery<Lotmateriallotrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{consumeid}");
		}
		return result;
	}

	public static Lotmateriallotrel SelectLotMaterialLotRel(IDbContext dbContext, long consumeid)
	{
		string apiName = "SelectLotMaterialLotRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{consumeid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotMaterialLotRelSqlDatabase : _sqlSelectLotMaterialLotRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CONSUMEID", consumeid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOTMATERIALLOTREL", $"{consumeid}"));
		}
		Lotmateriallotrel? result = ContextManager.DirectEntityQuery<Lotmateriallotrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{consumeid}");
		}
		return result;
	}

	public static Lotmateriallotrel SelectLotMaterialLotRel4Update(IDbContext dbContext, long consumeid)
	{
		string apiName = "SelectLotMaterialLotRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{consumeid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotMaterialLotRel4UpdateSqlDatabase : _sqlSelectLotMaterialLotRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CONSUMEID", consumeid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_LOTMATERIALLOTREL", $"{consumeid}"));
		}
		Lotmateriallotrel? result = ContextManager.DirectEntityQuery<Lotmateriallotrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{consumeid}");
		}
		return result;
	}

	public static int UpsertLotMaterialLotRel(IDbContext dbContext, RequestType requestType, Lotmateriallotrel[] lotMaterialLotRelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateLotMaterialLotRelInternal(dbContext, lotMaterialLotRelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateLotMaterialLotRel(dbContext, lotMaterialLotRelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteLotMaterialLotRel(dbContext, lotMaterialLotRelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteLotMaterialLotRel(dbContext, lotMaterialLotRelList, optionSet, saveHist), 
			_ => RealDeleteLotMaterialLotRel(dbContext, lotMaterialLotRelList, optionSet, saveHist), 
		};
	}

	private static int CreateLotMaterialLotRelInternal(IDbContext dbContext, Lotmateriallotrel[] lotMaterialLotRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotMaterialLotRelList", lotMaterialLotRelList);
		string text = "CreateLotMaterialLotRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotmateriallotrel> list = new List<Lotmateriallotrel>();
		foreach (Lotmateriallotrel obj in lotMaterialLotRelList)
		{
			Lotmateriallotrel lotmateriallotrel = new Lotmateriallotrel();
			obj.CopyColumsTo(lotmateriallotrel);
			lotmateriallotrel.Activity = text;
			lotmateriallotrel.CheckEntityUsable();
			obj.CopyCommonField(lotmateriallotrel, systemTime, dbContext.Tid, isCreate: true);
			list.Add(lotmateriallotrel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateLotMaterialLotRel(IDbContext dbContext, Lotmateriallotrel[] lotMaterialLotRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotMaterialLotRelList", lotMaterialLotRelList);
		string text = "UpdateLotMaterialLotRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotmateriallotrel> list = new List<Lotmateriallotrel>();
		foreach (Lotmateriallotrel lotmateriallotrel in lotMaterialLotRelList)
		{
			Lotmateriallotrel lotMaterialLotRel4Update = GetLotMaterialLotRel4Update(dbContext, lotmateriallotrel.Consumeid);
			if (lotMaterialLotRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lotmateriallotrel), $"{lotmateriallotrel.Consumeid}");
			}
			ParamChecker.EntityUsable(typeof(Lotmateriallotrel), $"{lotmateriallotrel.Consumeid}", lotMaterialLotRel4Update.Isusable);
			string activity = lotMaterialLotRel4Update.Activity;
			string customactivity = lotMaterialLotRel4Update.Customactivity;
			string isusable = lotMaterialLotRel4Update.Isusable;
			DateTime? createtime = lotMaterialLotRel4Update.Createtime;
			string creator = lotMaterialLotRel4Update.Creator;
			lotmateriallotrel.CopyColumsTo(lotMaterialLotRel4Update);
			lotMaterialLotRel4Update.Prevactivity = activity;
			lotMaterialLotRel4Update.Prevcustomactivity = customactivity;
			lotMaterialLotRel4Update.Creator = creator;
			lotMaterialLotRel4Update.Createtime = createtime;
			lotMaterialLotRel4Update.Isusable = isusable;
			lotMaterialLotRel4Update.Activity = text;
			lotmateriallotrel.CopyCommonField(lotMaterialLotRel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(lotMaterialLotRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteLotMaterialLotRel(IDbContext dbContext, Lotmateriallotrel[] lotMaterialLotRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotMaterialLotRelList", lotMaterialLotRelList);
		string text = "DeleteLotMaterialLotRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotmateriallotrel> list = new List<Lotmateriallotrel>();
		foreach (Lotmateriallotrel lotmateriallotrel in lotMaterialLotRelList)
		{
			Lotmateriallotrel lotMaterialLotRel4Update = GetLotMaterialLotRel4Update(dbContext, lotmateriallotrel.Consumeid);
			if (lotMaterialLotRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lotmateriallotrel), $"{lotmateriallotrel.Consumeid}");
			}
			ParamChecker.EntityUsable(typeof(Lotmateriallotrel), $"{lotmateriallotrel.Consumeid}", lotMaterialLotRel4Update.Isusable);
			lotMaterialLotRel4Update.Isusable = "UnUsable";
			lotmateriallotrel.CopyCommonFieldUpdatePrev(lotMaterialLotRel4Update, systemTime, dbContext.Tid, text);
			lotmateriallotrel.CopyExtensionCollection(lotMaterialLotRel4Update);
			list.Add(lotMaterialLotRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteLotMaterialLotRel(IDbContext dbContext, Lotmateriallotrel[] lotMaterialLotRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotMaterialLotRelList", lotMaterialLotRelList);
		string text = "UnDeleteLotMaterialLotRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotmateriallotrel> list = new List<Lotmateriallotrel>();
		foreach (Lotmateriallotrel lotmateriallotrel in lotMaterialLotRelList)
		{
			Lotmateriallotrel lotMaterialLotRel4Update = GetLotMaterialLotRel4Update(dbContext, lotmateriallotrel.Consumeid);
			if (lotMaterialLotRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lotmateriallotrel), $"{lotmateriallotrel.Consumeid}");
			}
			ParamChecker.EntityUnUsable(typeof(Lotmateriallotrel), $"{lotmateriallotrel.Consumeid}", lotMaterialLotRel4Update.Isusable);
			lotMaterialLotRel4Update.Isusable = "Usable";
			lotmateriallotrel.CopyCommonFieldUpdatePrev(lotMaterialLotRel4Update, systemTime, dbContext.Tid, text);
			lotmateriallotrel.CopyExtensionCollection(lotMaterialLotRel4Update);
			list.Add(lotMaterialLotRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteLotMaterialLotRel(IDbContext dbContext, Lotmateriallotrel[] lotMaterialLotRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotMaterialLotRelList", lotMaterialLotRelList);
		string text = "RealDeleteLotMaterialLotRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotmateriallotrel> list = new List<Lotmateriallotrel>();
		foreach (Lotmateriallotrel lotmateriallotrel in lotMaterialLotRelList)
		{
			Lotmateriallotrel lotMaterialLotRel4Update = GetLotMaterialLotRel4Update(dbContext, lotmateriallotrel.Consumeid);
			if (lotMaterialLotRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lotmateriallotrel), $"{lotmateriallotrel.Consumeid}");
			}
			lotmateriallotrel.CopyCommonFieldUpdatePrev(lotMaterialLotRel4Update, systemTime, dbContext.Tid, text);
			lotmateriallotrel.CopyExtensionCollection(lotMaterialLotRel4Update);
			list.Add(lotMaterialLotRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static IList<Lotmateriallotrel> SelectLotMaterialLotRelWithConsumeidList4Update(IDbContext dbContext, long[] consumeidList, string siteid)
	{
		string apiName = "SelectLotMaterialLotRelWithMaterialLot4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{consumeidList.Length}");
		}
		string value = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotMaterialLotRelWithConsumeidList4UpdateSqlDatabase : _sqlSelectLotMaterialLotRelWithConsumeidList4UpdateOracleDatabase);
		value = new StringBuilder(value, 1000).Replace("&CONSUMEIDLIST", EntityHelper.ConcatString4InClause(ExtractIdOrderBy(consumeidList))).ToString();
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_LOTMATERIALLOTREL", $"{consumeidList.Length},{siteid}"));
		}
		IList<Lotmateriallotrel> result = ContextManager.DirectEntityQuery<Lotmateriallotrel>(dbContext, value, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{consumeidList.Length},{siteid}");
		}
		return result;
	}

	internal static long[] ExtractIdOrderBy(long[] consumeidList)
	{
		return consumeidList.OrderBy((long id) => id).ToArray();
	}

	public static Lotmateriallotrel FindLotMaterialLotRel(Lotmateriallotrel[] lotMaterialLotList, long consumeid)
	{
		return lotMaterialLotList?.FirstOrDefault((Lotmateriallotrel item) => item.Consumeid == consumeid);
	}

	public static Lotmateriallotrel SelectLotMaterialLotRelWithMaterialLot4Update(IDbContext dbContext, string lotid, string materiallotid, string processnodeid, int repeatcount, string siteid)
	{
		string apiName = "SelectLotMaterialLotRelWithMaterialLot4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{materiallotid},{processnodeid},{repeatcount},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotMaterialLotRelWithMaterialLot4UpdateSqlDatabase : _sqlSelectLotMaterialLotRelWithMaterialLot4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("MATERIALLOTID", materiallotid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSNODEID", processnodeid, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_LOTMATERIALLOTREL", $"{lotid},{materiallotid},{processnodeid},{repeatcount},{siteid}"));
		}
		IList<Lotmateriallotrel> list2 = ContextManager.DirectEntityQuery<Lotmateriallotrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{materiallotid},{processnodeid},{repeatcount},{siteid}");
		}
		if (list2.Count < 1)
		{
			return null;
		}
		long max = list2.Max((Lotmateriallotrel r) => r.Consumeid);
		return list2.Where((Lotmateriallotrel r) => r.Consumeid == max).FirstOrDefault();
	}

	public static IList<Lotmateriallotrel> SelectLotMaterialLotRelWithProcessnodeidList4Update(IDbContext dbContext, string lotid, string processnodeid, int repeatcount, string siteid)
	{
		string apiName = "SelectLotMaterialLotRelWithProcessnodeidList4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{processnodeid},{repeatcount},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotMaterialLotRelWithProcessnodeidList4Update4UpdateSqlDatabase : _sqlSelectLotMaterialLotRelWithProcessnodeidList4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSNODEID", processnodeid, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOTMATERIALLOTREL", $"{lotid},{processnodeid},{repeatcount},{siteid}"));
		}
		IList<Lotmateriallotrel> result = ContextManager.DirectEntityQuery<Lotmateriallotrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{processnodeid},{repeatcount},{siteid}");
		}
		return result;
	}
}
