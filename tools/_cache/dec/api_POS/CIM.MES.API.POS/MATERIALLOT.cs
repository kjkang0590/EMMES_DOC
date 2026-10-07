using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CIM.MES.API.CDS;
using CIM.MES.API.RDS;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.POS;

[MESAPI]
public class MATERIALLOT
{
	private static string _sqlGetMaterialLotSqlDatabase = "SELECT * FROM CIM_MATERIALLOT WHERE MATERIALLOTID=@MATERIALLOTID AND SITEID=@SITEID";

	private static string _sqlGetMaterialLot4UpdateSqlDatabase = "SELECT * FROM CIM_MATERIALLOT WITH(UPDLOCK) WHERE MATERIALLOTID=@MATERIALLOTID AND SITEID=@SITEID";

	private static string _sqlSelectMaterialLotSqlDatabase = "SELECT * FROM CIM_MATERIALLOT WHERE MATERIALLOTID=@MATERIALLOTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMaterialLot4UpdateSqlDatabase = "SELECT * FROM CIM_MATERIALLOT WITH(UPDLOCK) WHERE MATERIALLOTID=@MATERIALLOTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetMaterialLotOracleDatabase = "SELECT * FROM CIM_MATERIALLOT WHERE MATERIALLOTID=:MATERIALLOTID AND SITEID=:SITEID";

	private static string _sqlGetMaterialLot4UpdateOracleDatabase = "SELECT * FROM CIM_MATERIALLOT WHERE MATERIALLOTID=:MATERIALLOTID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectMaterialLotOracleDatabase = "SELECT * FROM CIM_MATERIALLOT WHERE MATERIALLOTID=:MATERIALLOTID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMaterialLot4UpdateOracleDatabase = "SELECT * FROM CIM_MATERIALLOT WHERE MATERIALLOTID=:MATERIALLOTID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Materiallot);

	private static string _sqlSelectMaterialLotListSqlDatabase = "SELECT * FROM CIM_MATERIALLOT WHERE MATERIALLOTID IN (&MATERIALLOTIDLIST) AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMaterialLotList4UpdateSqlDatabase = "SELECT * FROM CIM_MATERIALLOT WITH(UPDLOCK) WHERE MATERIALLOTID IN (&MATERIALLOTIDLIST) AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMaterialLotListOracleDatabase = "SELECT * FROM CIM_MATERIALLOT WHERE MATERIALLOTID IN (&MATERIALLOTIDLIST) AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMaterialLotList4UpdateOracleDatabase = "SELECT * FROM CIM_MATERIALLOT WHERE MATERIALLOTID IN (&MATERIALLOTIDLIST) AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	public static int AssignMaterialLotToCarrier(IDbContext dbContext, Materiallot materialLot, Materiallotcarrierrel[] materialLotCarrierRelList, IOptionSet optionSet, bool saveMaterialLotHist, bool saveMaterialLotCarrierrelHist, bool saveCarrierHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("materialLot", materialLot);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotCarrierRelList", materialLotCarrierRelList);
		string text = "AssignMaterialLotToCarrier";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		int num = 0;
		List<Materiallot> list = new List<Materiallot>();
		List<Materiallotcarrierrel> list2 = new List<Materiallotcarrierrel>();
		List<Carrier> list3 = new List<Carrier>();
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		ParamChecker.ArgumentNotNull("Materiallotid", materialLot.Materiallotid);
		ParamChecker.ArgumentNotNull("Siteid", materialLot.Siteid);
		string materiallotid = materialLot.Materiallotid;
		string siteid = materialLot.Siteid;
		Materiallot materiallot = SelectMaterialLot4Update(dbContext, materiallotid, siteid);
		if (materiallot == null)
		{
			throw new EntityNotFoundException(typeof(Materiallot), materiallotid);
		}
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", materiallot);
		}
		materialLot.CopyCommonFieldUpdatePrev(materiallot, systemTime, tid, text);
		materialLot.CopyExtensionCollection(materiallot);
		list.Add(materiallot);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", materiallot);
		}
		foreach (Materiallotcarrierrel materiallotcarrierrel in materialLotCarrierRelList)
		{
			ParamChecker.ArgumentNotNull("Carrierid", materiallotcarrierrel.Carrierid);
			ParamChecker.ArgumentNotNull("Slotposition", materiallotcarrierrel.Slotposition);
			string carrierid = materiallotcarrierrel.Carrierid;
			Carrier carrier = CARRIER.SelectCarrier4Update(dbContext, carrierid, siteid);
			if (carrier == null)
			{
				throw new EntityNotFoundException(typeof(Carrier), carrierid);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", carrier);
			}
			materiallotcarrierrel.CopyCommonFieldUpdatePrev(carrier, systemTime, tid, text);
			list3.Add(carrier);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", carrier);
			}
			Materiallotcarrierrel materiallotcarrierrel2 = new Materiallotcarrierrel();
			materiallotcarrierrel.CopyColumsTo(materiallotcarrierrel2);
			materiallotcarrierrel2.Materiallotid = materiallotid;
			materiallotcarrierrel2.Carrierid = materiallotcarrierrel.Carrierid;
			materiallotcarrierrel2.Slotposition = materiallotcarrierrel.Slotposition;
			materiallotcarrierrel2.Activity = text;
			materiallotcarrierrel2.Isusable = "Usable";
			materiallotcarrierrel2.Siteid = siteid;
			materiallotcarrierrel.CopyCommonField(materiallotcarrierrel2, systemTime, tid, isCreate: true);
			list2.Add(materiallotcarrierrel2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", materiallotcarrierrel2);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveMaterialLotHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list3.ToArray(), saveCarrierHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list2.ToArray(), saveMaterialLotCarrierrelHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int AssignMaterialLotToDurable(IDbContext dbContext, Materiallot materialLot, Materiallotdurablerel[] materialLotDurableRelList, IOptionSet optionSet, bool saveMaterialLotHist, bool saveMaterialLotDurablerelHist, bool saveDurableHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("materialLot", materialLot);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotDurableRelList", materialLotDurableRelList);
		string text = "AssignMaterialLotToDurable";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		int num = 0;
		List<Materiallot> list = new List<Materiallot>();
		List<Materiallotdurablerel> list2 = new List<Materiallotdurablerel>();
		List<Durable> list3 = new List<Durable>();
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		ParamChecker.ArgumentNotNull("Materiallotid", materialLot.Materiallotid);
		ParamChecker.ArgumentNotNull("Siteid", materialLot.Siteid);
		string materiallotid = materialLot.Materiallotid;
		string siteid = materialLot.Siteid;
		Materiallot materiallot = SelectMaterialLot4Update(dbContext, materiallotid, siteid);
		if (materiallot == null)
		{
			throw new EntityNotFoundException(typeof(Materiallot), materiallotid);
		}
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", materiallot);
		}
		materialLot.CopyCommonFieldUpdatePrev(materiallot, systemTime, tid, text);
		materialLot.CopyExtensionCollection(materiallot);
		list.Add(materiallot);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", materiallot);
		}
		foreach (Materiallotdurablerel materiallotdurablerel in materialLotDurableRelList)
		{
			ParamChecker.ArgumentNotNull("Durableid", materiallotdurablerel.Durableid);
			string durableid = materiallotdurablerel.Durableid;
			Durable durable = DURABLE.SelectDurable4Update(dbContext, durableid, siteid);
			if (durable == null)
			{
				throw new EntityNotFoundException(typeof(Durable), durableid);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", durable);
			}
			materiallotdurablerel.CopyCommonFieldUpdatePrev(durable, systemTime, tid, text);
			list3.Add(durable);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", durable);
			}
			Materiallotdurablerel materiallotdurablerel2 = new Materiallotdurablerel();
			materiallotdurablerel.CopyColumsTo(materiallotdurablerel2);
			materiallotdurablerel2.Durableid = durableid;
			materiallotdurablerel2.Materiallotid = materiallotid;
			materiallotdurablerel2.Activity = text;
			materiallotdurablerel2.Isusable = "Usable";
			materiallotdurablerel2.Siteid = siteid;
			materiallotdurablerel.CopyCommonField(materiallotdurablerel2, systemTime, tid, isCreate: true);
			list2.Add(materiallotdurablerel2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", materiallotdurablerel2);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveMaterialLotHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list3.ToArray(), saveDurableHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list2.ToArray(), saveMaterialLotDurablerelHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int CancelConsumeMaterialLot(IDbContext dbContext, Lot lot, Materiallot[] materialLotList, CancelConsumeMaterialLotOptionSet optionSet, bool saveLotHist, bool saveMaterialLotHist, bool saveLotMaterialLotRelHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("lot", lot);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotList", materialLotList);
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
		ParamChecker.ArgumentNotNull("Subprocessdefinitionid", lot.Subprocessdefinitionid);
		ParamChecker.ArgumentNotNull("Processnodeid", lot.Processnodeid);
		ParamChecker.ArgumentNotNull("Repeatcount", lot.Repeatcount);
		string lotid = lot.Lotid;
		string siteid = lot.Siteid;
		_ = lot.Subprocessdefinitionid;
		string processnodeid = lot.Processnodeid;
		int repeatcount = (lot.Repeatcount.HasValue ? lot.Repeatcount.Value : 0);
		Lot lot2;
		if ((lot2 = LOT.SelectLot4Update(dbContext, lotid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Lot), lotid);
		}
		Materiallot[] materialLotList2 = SelectMaterialLotList4Update(dbContext, materialLotList, siteid).ToArray();
		bool flag = false;
		if (optionSet != null)
		{
			flag = optionSet.CancelTerminateMaterialLotQtyZero;
		}
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
		foreach (Materiallot materiallot in materialLotList)
		{
			ParamChecker.ArgumentNotNull("Materiallotid", materiallot.Materiallotid);
			ParamChecker.ArgumentNotNull("Siteid", materiallot.Siteid);
			string materiallotid = materiallot.Materiallotid;
			_ = materiallot.Siteid;
			Materiallot materiallot2;
			if ((materiallot2 = FindMaterialLot(materialLotList2, materiallotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Materiallot), materiallotid);
			}
			Lotmateriallotrel lotmateriallotrel;
			if ((lotmateriallotrel = LOTMATERIALLOTREL.SelectLotMaterialLotRelWithMaterialLot4Update(dbContext, lotid, materiallotid, processnodeid, repeatcount, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lotmateriallotrel), lotid, materiallotid, processnodeid, repeatcount.ToString());
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
				MesLogger.DebugTidApi(tid, "Before Execute", materiallot2);
			}
			if (flag)
			{
				decimal? qty = materiallot2.Qty;
				if (((qty.GetValueOrDefault() <= default(decimal)) & qty.HasValue) && materiallot2.State == "Terminated")
				{
					materiallot2.State = materiallot2.Prevstate;
					materiallot2.Prevstate = "Terminated";
				}
			}
			materiallot2.Prevqty = materiallot2.Qty;
			materiallot2.Qty = materiallot2.Qty.Add(lotmateriallotrel.Qty);
			materiallot.CopyCommonFieldUpdatePrev(materiallot2, systemTime, tid, text);
			materiallot.CopyExtensionCollection(materiallot2);
			list3.Add(materiallot2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", materiallot2);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list2.ToArray(), saveLotMaterialLotRelHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveLotHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list3.ToArray(), saveMaterialLotHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int CancelScrapMaterialLot(IDbContext dbContext, Materiallot[] materialLotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotList", materialLotList);
		string text = "CancelScrapMaterialLot";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materiallot> list = new List<Materiallot>();
		Materiallot[] materialLotList2 = SelectMaterialLotList4Update(dbContext, materialLotList, materialLotList[0].Siteid).ToArray();
		foreach (Materiallot materiallot in materialLotList)
		{
			ParamChecker.ArgumentNotNull("Materiallotid", materiallot.Materiallotid);
			ParamChecker.ArgumentNotNull("Siteid", materiallot.Siteid);
			_ = materiallot.Siteid;
			string materiallotid = materiallot.Materiallotid;
			Materiallot materiallot2;
			if ((materiallot2 = FindMaterialLot(materialLotList2, materiallotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Materiallot), materiallotid);
			}
			ParamChecker.EntityValidState(typeof(Materiallot), materiallotid, materiallot2.State, "Scrapped");
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", materiallot2);
			}
			decimal valueOrDefault = materiallot2.Prevqty.GetValueOrDefault();
			materiallot2.Prevqty = materiallot2.Qty;
			materiallot2.Qty = valueOrDefault;
			materiallot2.Lossqty = materiallot2.Lossqty.Add(-valueOrDefault);
			string prevstate = materiallot2.Prevstate;
			materiallot2.Prevstate = materiallot2.State;
			materiallot2.State = prevstate;
			materiallot.CopyCommonFieldUpdatePrev(materiallot2, systemTime, tid, text);
			materiallot.CopyExtensionCollection(materiallot2);
			list.Add(materiallot2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", materiallot2);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int CancelTerminateMaterialLot(IDbContext dbContext, Materiallot[] materialLotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotList", materialLotList);
		string text = "CancelTerminateMaterialLot";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materiallot> list = new List<Materiallot>();
		Materiallot[] materialLotList2 = SelectMaterialLotList4Update(dbContext, materialLotList, materialLotList[0].Siteid).ToArray();
		foreach (Materiallot materiallot in materialLotList)
		{
			ParamChecker.ArgumentNotNull("Materiallotid", materiallot.Materiallotid);
			ParamChecker.ArgumentNotNull("Siteid", materiallot.Siteid);
			_ = materiallot.Siteid;
			string materiallotid = materiallot.Materiallotid;
			Materiallot materiallot2;
			if ((materiallot2 = FindMaterialLot(materialLotList2, materiallotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Materiallot), materiallotid);
			}
			ParamChecker.EntityValidState(typeof(Lot), materiallotid, materiallot2.State, "Terminated");
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", materiallot2);
			}
			string prevstate = materiallot2.Prevstate;
			materiallot2.Prevstate = materiallot2.State;
			materiallot2.State = prevstate;
			materiallot.CopyCommonFieldUpdatePrev(materiallot2, systemTime, tid, text);
			materiallot.CopyExtensionCollection(materiallot2);
			list.Add(materiallot2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", materiallot2);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int ChangeMaterialLotQty(IDbContext dbContext, Materiallot[] materialLotList, ChangeMaterialLotQtyOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotList", materialLotList);
		string text = "ChangeMaterialLotQty";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		bool flag = false;
		if (optionSet != null)
		{
			flag = optionSet.TerminateMaterialLotQtyZero;
		}
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materiallot> list = new List<Materiallot>();
		Materiallot[] materialLotList2 = SelectMaterialLotList4Update(dbContext, materialLotList, materialLotList[0].Siteid).ToArray();
		foreach (Materiallot materiallot in materialLotList)
		{
			ParamChecker.ArgumentNotNull("Materiallotid", materiallot.Materiallotid);
			ParamChecker.ArgumentNotNull("Qty", materiallot.Qty);
			ParamChecker.ArgumentNotNull("Siteid", materiallot.Siteid);
			_ = materiallot.Siteid;
			string materiallotid = materiallot.Materiallotid;
			Materiallot materiallot2;
			if ((materiallot2 = FindMaterialLot(materialLotList2, materiallotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Materiallot), materiallotid);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", materiallot2);
			}
			materiallot2.Prevqty = materiallot2.Qty;
			materiallot2.Qty = materiallot.Qty;
			if (flag)
			{
				decimal? qty = materiallot2.Qty;
				if ((qty.GetValueOrDefault() == default(decimal)) & qty.HasValue)
				{
					materiallot2.Prevstate = materiallot2.State;
					materiallot2.State = "Terminated";
				}
			}
			materiallot.CopyCommonFieldUpdatePrev(materiallot2, systemTime, tid, text);
			materiallot.CopyExtensionCollection(materiallot2);
			list.Add(materiallot2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", materiallot2);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int ChangeMaterialLotState(IDbContext dbContext, Materiallot[] materialLotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotList", materialLotList);
		string text = "ChangeMaterialLotState";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materiallot> list = new List<Materiallot>();
		Materiallot[] materialLotList2 = SelectMaterialLotList4Update(dbContext, materialLotList, materialLotList[0].Siteid).ToArray();
		foreach (Materiallot materiallot in materialLotList)
		{
			ParamChecker.ArgumentNotNull("Materiallotid", materiallot.Materiallotid);
			ParamChecker.ArgumentNotNull("State", materiallot.State);
			ParamChecker.ArgumentNotNull("Siteid", materiallot.Siteid);
			string siteid = materiallot.Siteid;
			string materiallotid = materiallot.Materiallotid;
			Materiallot materiallot2;
			if ((materiallot2 = FindMaterialLot(materialLotList2, materiallotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Materiallot), materiallotid);
			}
			if (STATE.SelectState(dbContext, typeof(MaterialState).Name, materiallot.State, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(MaterialState), materiallot.State);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", materiallot2);
			}
			materiallot2.Prevstate = materiallot2.State;
			materiallot2.State = materiallot.State;
			materiallot.CopyCommonFieldUpdatePrev(materiallot2, systemTime, tid, text);
			materiallot.CopyExtensionCollection(materiallot2);
			list.Add(materiallot2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", materiallot2);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int ConsumeMaterialLot(IDbContext dbContext, Lot lot, Materiallot[] materialLotList, ConsumeMaterialLotOptionSet optionSet, bool saveLotHist, bool saveMaterialLotHist, bool saveLotMaterialLotRelHist)
	{
		string text = "ConsumeMaterialLot";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("lot", lot);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotList", materialLotList);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Materiallot> list2 = new List<Materiallot>();
		List<Lotmateriallotrel> list3 = new List<Lotmateriallotrel>();
		List<Lotmateriallotrel> list4 = new List<Lotmateriallotrel>();
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
		Materiallot[] materialLotList2 = SelectMaterialLotList4Update(dbContext, materialLotList, siteid).ToArray();
		string processnodeid = lot2.Processnodeid;
		int repeatcount = (lot2.Repeatcount.HasValue ? lot2.Repeatcount.Value : 0);
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
		int num2;
		if (optionSet != null)
		{
			_ = optionSet.TerminateMaterialLotQtyZero;
			if (0 == 0)
			{
				num2 = (optionSet.TerminateMaterialLotQtyZero ? 1 : 0);
				goto IL_0169;
			}
		}
		num2 = 0;
		goto IL_0169;
		IL_0184:
		int num3;
		bool flag = (byte)num3 != 0;
		bool flag3;
		foreach (Materiallot materiallot in materialLotList)
		{
			ParamChecker.ArgumentNotNull("Materiallotid", materiallot.Materiallotid);
			ParamChecker.ArgumentNotNull("Qty", materiallot.Qty);
			ParamChecker.ArgumentNotNull("Siteid", materiallot.Siteid);
			string materiallotid = materiallot.Materiallotid;
			_ = materiallot.Siteid;
			Materiallot materiallot2 = null;
			Lotmateriallotrel lotmateriallotrel = null;
			bool flag2 = false;
			if ((materiallot2 = FindMaterialLot(materialLotList2, materiallotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Materiallot), materiallotid);
			}
			if (!flag)
			{
				lotmateriallotrel = LOTMATERIALLOTREL.SelectLotMaterialLotRelWithMaterialLot4Update(dbContext, lotid, materiallot2.Materiallotid, processnodeid, repeatcount, siteid);
			}
			Convert.ToDecimal(materiallot.Qty);
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", materiallot2);
			}
			if (lotmateriallotrel != null)
			{
				materiallot2.Qty = materiallot2.Qty.Add(lotmateriallotrel.Qty);
			}
			materiallot2.Prevqty = materiallot2.Qty;
			materiallot2.Qty = materiallot2.Qty.Add(-materiallot.Qty);
			if (flag3)
			{
				decimal? qty = materiallot2.Qty;
				if ((qty.GetValueOrDefault() <= default(decimal)) & qty.HasValue)
				{
					materiallot2.Prevstate = materiallot2.State;
					materiallot2.State = "Terminated";
				}
			}
			materiallot.CopyCommonFieldUpdatePrev(materiallot2, systemTime, tid, text);
			materiallot.CopyExtensionCollection(materiallot2);
			list2.Add(materiallot2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", materiallot2);
			}
			if (lotmateriallotrel != null)
			{
				flag2 = true;
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "Update previous consume information.", lotmateriallotrel);
				}
				if (MesLogger.IsDebugEnabled("API"))
				{
					MesLogger.DebugTidApi(tid, "Before Execute", lotmateriallotrel);
				}
			}
			else
			{
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "Create new consume information.", null);
				}
				lotmateriallotrel = new Lotmateriallotrel();
			}
			lot2.CopySameColumnsTo(lotmateriallotrel, copyExtensionCollection: false);
			lotmateriallotrel.Materiallotid = materiallotid;
			lotmateriallotrel.Qty = materiallot.Qty;
			lotmateriallotrel.Unitid = materiallot.Unitid;
			lotmateriallotrel.Repeatcount = repeatcount;
			if (optionSet?.HASHTABLE != null)
			{
				foreach (object key in optionSet.HASHTABLE.Keys)
				{
					lotmateriallotrel.ValueCollection[key] = optionSet.HASHTABLE[key];
				}
			}
			if (flag2)
			{
				list4.Add(lotmateriallotrel);
			}
			else
			{
				list3.Add(lotmateriallotrel);
			}
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", lotmateriallotrel);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveLotHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveMaterialLotHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list3.ToArray(), saveLotMaterialLotRelHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list4.ToArray(), saveLotMaterialLotRelHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
		IL_0169:
		flag3 = (byte)num2 != 0;
		if (optionSet != null)
		{
			_ = optionSet.IsDuplicateNewConsumeMaterialLot;
			if (0 == 0)
			{
				num3 = (optionSet.IsDuplicateNewConsumeMaterialLot ? 1 : 0);
				goto IL_0184;
			}
		}
		num3 = 0;
		goto IL_0184;
	}

	public static int ConsumeMaterialLotForAdjustment(IDbContext dbContext, Lot lot, Materiallot[] materialLotList, ConsumeMaterialLotOptionSet optionSet, bool saveLotHist, bool saveMaterialLotHist, bool saveLotMaterialLotRelHist)
	{
		string text = "ConsumeMaterialLotForAdjustment";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("lot", lot);
		ParamChecker.ArgumentNotNull("materialLotList", materialLotList);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Materiallot> list2 = new List<Materiallot>();
		List<Lotmateriallotrel> list3 = new List<Lotmateriallotrel>();
		List<Lotmateriallotrel> list4 = new List<Lotmateriallotrel>();
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
		Materiallot[] materialLotList2 = SelectMaterialLotList4Update(dbContext, materialLotList, siteid).ToArray();
		string processnodeid = lot2.Processnodeid;
		int repeatcount = (lot2.Repeatcount.HasValue ? lot2.Repeatcount.Value : 0);
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
		int num2;
		if (optionSet != null)
		{
			_ = optionSet.TerminateMaterialLotQtyZero;
			if (0 == 0)
			{
				num2 = (optionSet.TerminateMaterialLotQtyZero ? 1 : 0);
				goto IL_0169;
			}
		}
		num2 = 0;
		goto IL_0169;
		IL_0184:
		int num3;
		bool flag = (byte)num3 != 0;
		bool flag3;
		foreach (Materiallot materiallot in materialLotList)
		{
			ParamChecker.ArgumentNotNull("Materiallotid", materiallot.Materiallotid);
			ParamChecker.ArgumentNotNull("Qty", materiallot.Qty);
			ParamChecker.ArgumentNotNull("Siteid", materiallot.Siteid);
			string materiallotid = materiallot.Materiallotid;
			_ = materiallot.Siteid;
			Materiallot materiallot2 = null;
			Lotmateriallotrel lotmateriallotrel = null;
			bool flag2 = false;
			if ((materiallot2 = FindMaterialLot(materialLotList2, materiallotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lot), materiallotid);
			}
			if (!flag)
			{
				lotmateriallotrel = LOTMATERIALLOTREL.SelectLotMaterialLotRelWithMaterialLot4Update(dbContext, lotid, materiallotid, processnodeid, repeatcount, siteid);
			}
			Convert.ToDecimal(materiallot.Qty);
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", materiallot2);
			}
			materiallot2.Prevqty = materiallot2.Qty;
			materiallot2.Qty = materiallot2.Qty.Add(-materiallot.Qty);
			if (flag3)
			{
				decimal? qty = materiallot2.Qty;
				if ((qty.GetValueOrDefault() <= default(decimal)) & qty.HasValue)
				{
					materiallot2.Prevstate = materiallot2.State;
					materiallot2.State = "Terminated";
				}
			}
			materiallot.CopyCommonFieldUpdatePrev(materiallot2, systemTime, tid, text);
			materiallot.CopyExtensionCollection(materiallot2);
			list2.Add(materiallot2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", materiallot2);
			}
			if (lotmateriallotrel != null)
			{
				flag2 = true;
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "Update previous consume information.", lotmateriallotrel);
				}
				if (MesLogger.IsDebugEnabled("API"))
				{
					MesLogger.DebugTidApi(tid, "Before Execute", lotmateriallotrel);
				}
			}
			else
			{
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "Create new consume information.", null);
				}
				lotmateriallotrel = new Lotmateriallotrel();
			}
			lot2.CopySameColumnsTo(lotmateriallotrel, copyExtensionCollection: false);
			lotmateriallotrel.Processnodeid = processnodeid;
			lotmateriallotrel.Repeatcount = repeatcount;
			lotmateriallotrel.Materiallotid = materiallotid;
			if (flag2)
			{
				lotmateriallotrel.Qty = lotmateriallotrel.Qty.Add(materiallot.Qty);
			}
			else
			{
				lotmateriallotrel.Qty = materiallot.Qty;
			}
			lotmateriallotrel.Unitid = materiallot.Unitid;
			if (optionSet?.HASHTABLE != null)
			{
				foreach (object key in optionSet.HASHTABLE.Keys)
				{
					lotmateriallotrel.ValueCollection[key] = optionSet.HASHTABLE[key];
				}
			}
			if (flag2)
			{
				list4.Add(lotmateriallotrel);
			}
			else
			{
				list3.Add(lotmateriallotrel);
			}
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", lotmateriallotrel);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveLotHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveMaterialLotHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list3.ToArray(), saveLotMaterialLotRelHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list4.ToArray(), saveLotMaterialLotRelHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
		IL_0169:
		flag3 = (byte)num2 != 0;
		if (optionSet != null)
		{
			_ = optionSet.IsDuplicateNewConsumeMaterialLot;
			if (0 == 0)
			{
				num3 = (optionSet.IsDuplicateNewConsumeMaterialLot ? 1 : 0);
				goto IL_0184;
			}
		}
		num3 = 0;
		goto IL_0184;
	}

	public static int ConvertMaterialLotToLot(IDbContext dbContext, Materiallot[] materialLotList, IOptionSet optionSet, bool saveMaterialHist, bool saveLotHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotList", materialLotList);
		string text = "ConvertMaterialLotToLot";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Materiallot> list2 = new List<Materiallot>();
		Materiallot[] array = SelectMaterialLotList4Update(dbContext, materialLotList, materialLotList[0].Siteid).ToArray();
		if (array.Length < 1)
		{
			throw new EntityNotFoundException(typeof(Materiallot));
		}
		List<Lot> list3 = new List<Lot>();
		Materiallot[] array2 = array;
		foreach (Materiallot materiallot in array2)
		{
			list3.Add(new Lot
			{
				Lotid = materiallot.Sourceinputid,
				Siteid = materiallot.Siteid
			});
		}
		Lot[] lotList = LOT.SelectLotList4Update(dbContext, list3.ToArray(), list3[0].Siteid).ToArray();
		array2 = materialLotList;
		foreach (Materiallot materiallot2 in array2)
		{
			ParamChecker.ArgumentNotNull("Materiallotid", materiallot2.Materiallotid);
			ParamChecker.ArgumentNotNull("State", materiallot2.State);
			ParamChecker.ArgumentNotNull("Siteid", materiallot2.Siteid);
			_ = materiallot2.Siteid;
			string materiallotid = materiallot2.Materiallotid;
			Materiallot materiallot3;
			if ((materiallot3 = FindMaterialLot(array, materiallotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Materiallot), materiallotid);
			}
			string sourceinputid = materiallot3.Sourceinputid;
			ParamChecker.ArgumentNotNull("Sourceinputid", sourceinputid);
			ParamChecker.EntityInvalidState(typeof(Materiallot), materiallot3.Materiallotid, materiallot3.State, "Scrapped", "Terminated");
			Lot lot = LOT.FindLot(lotList, sourceinputid);
			if (lot == null)
			{
				throw new EntityNotFoundException(typeof(Lot), sourceinputid);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", materiallot3);
			}
			materiallot3.Prevstate = materiallot3.State;
			materiallot3.State = "Terminated";
			materiallot2.CopyCommonFieldUpdatePrev(materiallot3, systemTime, tid, text);
			materiallot2.CopyExtensionCollection(materiallot3);
			list2.Add(materiallot3);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", materiallot3);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", lot);
			}
			string prevstate = lot.Prevstate;
			lot.Prevstate = lot.State;
			lot.State = prevstate;
			materiallot2.CopyCommonFieldUpdatePrev(lot, systemTime, tid, text);
			list.Add(lot);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", lot);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveMaterialHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveLotHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int CreateMaterialLot(IDbContext dbContext, Materiallot[] materialLotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotList", materialLotList);
		string text = "CreateMaterialLot";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materiallot> list = new List<Materiallot>();
		foreach (Materiallot materiallot in materialLotList)
		{
			Materiallot materiallot2 = new Materiallot();
			materiallot.CopyColumsTo(materiallot2);
			ParamChecker.ArgumentNotNull("Materiallotid", materiallot2.Materiallotid);
			ParamChecker.ArgumentNotNull("Materialdefinitionid", materiallot2.Materialdefinitionid);
			ParamChecker.ArgumentNotNull("Siteid", materiallot2.Siteid);
			string siteid = materiallot2.Siteid;
			materiallot2.State = EntityHelper.FirstNotNull<string>(materiallot.State, "Created");
			materiallot2.Originalqty = EntityHelper.FirstNotNull<decimal?>(materiallot.Originalqty, materiallot.Qty);
			materiallot2.Activity = text;
			materiallot2.Isusable = "Usable";
			materiallot2.Siteid = siteid;
			materiallot.CopyCommonField(materiallot2, systemTime, tid, isCreate: true);
			list.Add(materiallot2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", materiallot2);
			}
		}
		return num + ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
	}

	public static int DeassignMateriallotFromCarrier(IDbContext dbContext, Materiallot materialLot, Materiallotcarrierrel[] materialLotCarrierRelList, IOptionSet optionSet, bool saveMaterialLotHist, bool saveMaterialLotCarrierRelHist, bool saveCarrierHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("materialLot", materialLot);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotCarrierRelList", materialLotCarrierRelList);
		string text = "DeassignMaterialLotFromCarrier";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		int num = 0;
		List<Materiallot> list = new List<Materiallot>();
		List<Materiallotcarrierrel> list2 = new List<Materiallotcarrierrel>();
		List<Carrier> list3 = new List<Carrier>();
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		ParamChecker.ArgumentNotNull("Materiallotid", materialLot.Materiallotid);
		ParamChecker.ArgumentNotNull("Siteid", materialLot.Siteid);
		string materiallotid = materialLot.Materiallotid;
		string siteid = materialLot.Siteid;
		Materiallot materiallot = SelectMaterialLot4Update(dbContext, materiallotid, siteid);
		if (materiallot == null)
		{
			throw new EntityNotFoundException(typeof(Materiallot), materiallotid);
		}
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", materiallot);
		}
		materialLot.CopyCommonFieldUpdatePrev(materiallot, systemTime, tid, text);
		materialLot.CopyExtensionCollection(materiallot);
		list.Add(materiallot);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", materiallot);
		}
		foreach (Materiallotcarrierrel materiallotcarrierrel in materialLotCarrierRelList)
		{
			ParamChecker.ArgumentNotNull("Carrierid", materiallotcarrierrel.Carrierid);
			ParamChecker.ArgumentNotNull("Slotposition", materiallotcarrierrel.Slotposition);
			string carrierid = materiallotcarrierrel.Carrierid;
			int slotposition = materiallotcarrierrel.Slotposition;
			Carrier carrier = CARRIER.SelectCarrier4Update(dbContext, carrierid, siteid);
			if (carrier == null)
			{
				throw new EntityNotFoundException(typeof(Carrier), carrierid);
			}
			Materiallotcarrierrel materiallotcarrierrel2 = MATERIALLOTCARRIERREL.SelectMaterialLotCarrierRel(dbContext, materiallotid, carrierid, slotposition, siteid);
			if (materiallotcarrierrel2 == null)
			{
				throw new EntityNotFoundException(typeof(Materiallotcarrierrel), materiallotid, carrierid, slotposition.ToString());
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", materiallotcarrierrel2);
			}
			if (materiallotcarrierrel.Assignqty.HasValue && !(materiallotcarrierrel2.Assignqty == materiallotcarrierrel.Assignqty))
			{
				materiallotcarrierrel2.Assignqty = materiallotcarrierrel.Assignqty;
			}
			materiallotcarrierrel.CopyCommonFieldUpdatePrev(materiallotcarrierrel2, systemTime, tid, text);
			materiallotcarrierrel.CopyExtensionCollection(materiallotcarrierrel2);
			list2.Add(materiallotcarrierrel2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", materiallotcarrierrel2);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", carrier);
			}
			materiallotcarrierrel.CopyCommonFieldUpdatePrev(carrier, systemTime, tid, text);
			list3.Add(carrier);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", carrier);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveMaterialLotHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list2.ToArray(), saveMaterialLotCarrierRelHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list3.ToArray(), saveCarrierHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int DeassignMateriallotFromDurable(IDbContext dbContext, Materiallot materialLot, Materiallotdurablerel[] materialLotDurableRelList, IOptionSet optionSet, bool saveMaterialLotHist, bool saveMaterialLotDurableRelHist, bool saveDurableHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("materialLot", materialLot);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotCarrierRelList", materialLotDurableRelList);
		string text = "DeassignMaterialLotFromDurable";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		int num = 0;
		List<Materiallot> list = new List<Materiallot>();
		List<Materiallotdurablerel> list2 = new List<Materiallotdurablerel>();
		List<Durable> list3 = new List<Durable>();
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		ParamChecker.ArgumentNotNull("Materiallotid", materialLot.Materiallotid);
		ParamChecker.ArgumentNotNull("Siteid", materialLot.Siteid);
		string materiallotid = materialLot.Materiallotid;
		string siteid = materialLot.Siteid;
		Materiallot materiallot = SelectMaterialLot4Update(dbContext, materiallotid, siteid);
		if (materiallot == null)
		{
			throw new EntityNotFoundException(typeof(Materiallot), materiallotid);
		}
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", materiallot);
		}
		materialLot.CopyCommonFieldUpdatePrev(materiallot, systemTime, tid, text);
		materialLot.CopyExtensionCollection(materiallot);
		list.Add(materiallot);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", materiallot);
		}
		foreach (Materiallotdurablerel materiallotdurablerel in materialLotDurableRelList)
		{
			ParamChecker.ArgumentNotNull("Durableid", materiallotdurablerel.Durableid);
			string durableid = materiallotdurablerel.Durableid;
			Durable durable = DURABLE.SelectDurable4Update(dbContext, durableid, siteid);
			if (durable == null)
			{
				throw new EntityNotFoundException(typeof(Durable), durableid);
			}
			Materiallotdurablerel materiallotdurablerel2 = MATERIALLOTDURABLEREL.SelectMaterialLotDurableRel4Update(dbContext, materiallotid, durableid, siteid);
			if (materiallotdurablerel2 == null)
			{
				throw new EntityNotFoundException(typeof(Materiallotdurablerel), materiallotid, durableid);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", materiallotdurablerel2);
			}
			materiallotdurablerel.CopyCommonFieldUpdatePrev(materiallotdurablerel2, systemTime, tid, text);
			materiallotdurablerel.CopyExtensionCollection(materiallotdurablerel2);
			list2.Add(materiallotdurablerel2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", materiallotdurablerel2);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", durable);
			}
			materiallotdurablerel.CopyCommonFieldUpdatePrev(durable, systemTime, tid, text);
			list3.Add(durable);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", durable);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveMaterialLotHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list2.ToArray(), saveMaterialLotDurableRelHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list3.ToArray(), saveDurableHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int DekitMaterialLot(IDbContext dbContext, Materiallot[] materialLotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotList", materialLotList);
		string text = "DekitMaterialLot";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materiallot> list = new List<Materiallot>();
		Materiallot[] materialLotList2 = SelectMaterialLotList4Update(dbContext, materialLotList, materialLotList[0].Siteid).ToArray();
		foreach (Materiallot materiallot in materialLotList)
		{
			ParamChecker.ArgumentNotNull("Materiallotid", materiallot.Materiallotid);
			ParamChecker.ArgumentNotNull("Siteid", materiallot.Siteid);
			string materiallotid = materiallot.Materiallotid;
			_ = materiallot.Siteid;
			Materiallot materiallot2;
			if ((materiallot2 = FindMaterialLot(materialLotList2, materiallotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Materiallot), materiallotid);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", materiallot2);
			}
			materiallot2.Equipmentid = null;
			materiallot2.Portid = null;
			materiallot.CopyCommonFieldUpdatePrev(materiallot2, systemTime, tid, text);
			materiallot.CopyExtensionCollection(materiallot2);
			list.Add(materiallot2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", materiallot2);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int HoldMaterialLot(IDbContext dbContext, Materiallot[] materialLotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotList", materialLotList);
		string text = "HoldMaterialLot";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materiallot> list = new List<Materiallot>();
		Materiallot[] materialLotList2 = SelectMaterialLotList4Update(dbContext, materialLotList, materialLotList[0].Siteid).ToArray();
		foreach (Materiallot materiallot in materialLotList)
		{
			ParamChecker.ArgumentNotNull("Materiallotid", materiallot.Materiallotid);
			ParamChecker.ArgumentNotNull("Siteid", materiallot.Siteid);
			string materiallotid = materiallot.Materiallotid;
			_ = materiallot.Siteid;
			Materiallot materiallot2;
			if ((materiallot2 = FindMaterialLot(materialLotList2, materiallotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Materiallot), materiallotid);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", materiallot2);
			}
			materiallot2.Prevstate = materiallot2.State;
			materiallot2.State = "Hold";
			materiallot.CopyCommonFieldUpdatePrev(materiallot2, systemTime, tid, text);
			materiallot.CopyExtensionCollection(materiallot2);
			list.Add(materiallot2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", materiallot2);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int KitMaterialLot(IDbContext dbContext, Materiallot[] materialLotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotList", materialLotList);
		string text = "KitMaterialLot";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materiallot> list = new List<Materiallot>();
		Materiallot[] materialLotList2 = SelectMaterialLotList4Update(dbContext, materialLotList, materialLotList[0].Siteid).ToArray();
		foreach (Materiallot materiallot in materialLotList)
		{
			ParamChecker.ArgumentNotNull("Materiallotid", materiallot.Materiallotid);
			ParamChecker.ArgumentNotNull("Equipmentid", materiallot.Equipmentid);
			ParamChecker.ArgumentNotNull("Siteid", materiallot.Siteid);
			string materiallotid = materiallot.Materiallotid;
			string equipmentid = materiallot.Equipmentid;
			string portid = materiallot.Portid;
			string siteid = materiallot.Siteid;
			Materiallot materiallot2;
			if ((materiallot2 = FindMaterialLot(materialLotList2, materiallotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Materiallot), materiallotid);
			}
			if (EQUIPMENT.SelectEquipment(dbContext, equipmentid, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(Equipment), equipmentid);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", materiallot2);
			}
			materiallot2.Equipmentid = equipmentid;
			materiallot2.Portid = portid;
			materiallot.CopyCommonFieldUpdatePrev(materiallot2, systemTime, tid, text);
			materiallot.CopyExtensionCollection(materiallot2);
			list.Add(materiallot2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", materiallot2);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static Materiallot GetMaterialLot(IDbContext dbContext, string materiallotid, string siteid)
	{
		string apiName = "GetMaterialLot";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{materiallotid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetMaterialLotSqlDatabase : _sqlGetMaterialLotOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MATERIALLOTID", materiallotid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MATERIALLOT", $"{materiallotid},{siteid}"));
		}
		Materiallot? result = ContextManager.DirectEntityQuery<Materiallot>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{materiallotid},{siteid}");
		}
		return result;
	}

	public static Materiallot GetMaterialLot4Update(IDbContext dbContext, string materiallotid, string siteid)
	{
		string apiName = "GetMaterialLot4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{materiallotid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetMaterialLot4UpdateSqlDatabase : _sqlGetMaterialLot4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MATERIALLOTID", materiallotid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_MATERIALLOT", $"{materiallotid},{siteid}"));
		}
		Materiallot? result = ContextManager.DirectEntityQuery<Materiallot>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{materiallotid},{siteid}");
		}
		return result;
	}

	public static Materiallot SelectMaterialLot(IDbContext dbContext, string materiallotid, string siteid)
	{
		string apiName = "SelectMaterialLot";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{materiallotid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMaterialLotSqlDatabase : _sqlSelectMaterialLotOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MATERIALLOTID", materiallotid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MATERIALLOT", $"{materiallotid},{siteid}"));
		}
		Materiallot? result = ContextManager.DirectEntityQuery<Materiallot>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{materiallotid},{siteid}");
		}
		return result;
	}

	public static Materiallot SelectMaterialLot4Update(IDbContext dbContext, string materiallotid, string siteid)
	{
		string apiName = "SelectMaterialLot4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{materiallotid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMaterialLot4UpdateSqlDatabase : _sqlSelectMaterialLot4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MATERIALLOTID", materiallotid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_MATERIALLOT", $"{materiallotid},{siteid}"));
		}
		Materiallot? result = ContextManager.DirectEntityQuery<Materiallot>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{materiallotid},{siteid}");
		}
		return result;
	}

	public static IList<Materiallot> SelectMaterialLotList(IDbContext dbContext, Materiallot[] materialLotList, string siteId)
	{
		string apiName = "SelectMaterialLotList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{materialLotList.Length},{siteId}");
		}
		string value = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMaterialLotListSqlDatabase : _sqlSelectMaterialLotListOracleDatabase);
		value = new StringBuilder(value, 1000).Replace("&MATERIALLOTIDLIST", EntityHelper.ConcatString4InClause(ExtractIdOrderBy(materialLotList))).ToString();
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MATERIALLOT", $"{materialLotList.Length},{siteId}"));
		}
		IList<Materiallot> result = ContextManager.DirectEntityQuery<Materiallot>(dbContext, value, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{materialLotList.Length},{siteId}");
		}
		return result;
	}

	public static IList<Materiallot> SelectMaterialLotList4Update(IDbContext dbContext, Materiallot[] materialLotList, string siteId)
	{
		string apiName = "SelectMaterialLotList4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{materialLotList.Length},{siteId}");
		}
		string value = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMaterialLotList4UpdateSqlDatabase : _sqlSelectMaterialLotList4UpdateOracleDatabase);
		value = new StringBuilder(value, 1000).Replace("&MATERIALLOTIDLIST", EntityHelper.ConcatString4InClause(ExtractIdOrderBy(materialLotList))).ToString();
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_MATERIALLOT", $"{materialLotList.Length},{siteId}"));
		}
		IList<Materiallot> result = ContextManager.DirectEntityQuery<Materiallot>(dbContext, value, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{materialLotList.Length},{siteId}");
		}
		return result;
	}

	public static IList<Materiallot> SelectMaterialLotList4Update(IDbContext dbContext, Lotmateriallotrel[] lotmateriallotList, string siteId)
	{
		string apiName = "SelectMaterialLotList4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotmateriallotList.Length},{siteId}");
		}
		string value = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMaterialLotList4UpdateSqlDatabase : _sqlSelectMaterialLotList4UpdateOracleDatabase);
		value = new StringBuilder(value, 1000).Replace("&MATERIALLOTIDLIST", EntityHelper.ConcatString4InClause(ExtractIdOrderBy(lotmateriallotList))).ToString();
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_MATERIALLOT", $"{lotmateriallotList.Length},{siteId}"));
		}
		IList<Materiallot> result = ContextManager.DirectEntityQuery<Materiallot>(dbContext, value, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotmateriallotList.Length},{siteId}");
		}
		return result;
	}

	public static int UpsertMaterialLot(IDbContext dbContext, RequestType requestType, Materiallot[] materialLotList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateMaterialLotInternal(dbContext, materialLotList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateMaterialLot(dbContext, materialLotList, optionSet, saveHist), 
			RequestType.DELETE => DeleteMaterialLot(dbContext, materialLotList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteMaterialLot(dbContext, materialLotList, optionSet, saveHist), 
			_ => RealDeleteMaterialLot(dbContext, materialLotList, optionSet, saveHist), 
		};
	}

	private static int CreateMaterialLotInternal(IDbContext dbContext, Materiallot[] materialLotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotList", materialLotList);
		string text = "CreateMaterialLot";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materiallot> list = new List<Materiallot>();
		foreach (Materiallot obj in materialLotList)
		{
			Materiallot materiallot = new Materiallot();
			obj.CopyColumsTo(materiallot);
			materiallot.Activity = text;
			materiallot.CheckEntityUsable();
			obj.CopyCommonField(materiallot, systemTime, dbContext.Tid, isCreate: true);
			list.Add(materiallot);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateMaterialLot(IDbContext dbContext, Materiallot[] materialLotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotList", materialLotList);
		string text = "UpdateMaterialLot";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materiallot> list = new List<Materiallot>();
		foreach (Materiallot materiallot in materialLotList)
		{
			Materiallot materialLot4Update = GetMaterialLot4Update(dbContext, materiallot.Materiallotid, materiallot.Siteid);
			if (materialLot4Update == null)
			{
				throw new EntityNotFoundException(typeof(Materiallot), $"{materiallot.Materiallotid},{materiallot.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Materiallot), $"{materiallot.Materiallotid},{materiallot.Siteid}", materialLot4Update.Isusable);
			string activity = materialLot4Update.Activity;
			string customactivity = materialLot4Update.Customactivity;
			string isusable = materialLot4Update.Isusable;
			DateTime? createtime = materialLot4Update.Createtime;
			string creator = materialLot4Update.Creator;
			materiallot.CopyColumsTo(materialLot4Update);
			materialLot4Update.Prevactivity = activity;
			materialLot4Update.Prevcustomactivity = customactivity;
			materialLot4Update.Creator = creator;
			materialLot4Update.Createtime = createtime;
			materialLot4Update.Isusable = isusable;
			materialLot4Update.Activity = text;
			materiallot.CopyCommonField(materialLot4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(materialLot4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteMaterialLot(IDbContext dbContext, Materiallot[] materialLotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotList", materialLotList);
		string text = "DeleteMaterialLot";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materiallot> list = new List<Materiallot>();
		foreach (Materiallot materiallot in materialLotList)
		{
			Materiallot materialLot4Update = GetMaterialLot4Update(dbContext, materiallot.Materiallotid, materiallot.Siteid);
			if (materialLot4Update == null)
			{
				throw new EntityNotFoundException(typeof(Materiallot), $"{materiallot.Materiallotid},{materiallot.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Materiallot), $"{materiallot.Materiallotid},{materiallot.Siteid}", materialLot4Update.Isusable);
			materialLot4Update.Isusable = "UnUsable";
			materiallot.CopyCommonFieldUpdatePrev(materialLot4Update, systemTime, dbContext.Tid, text);
			materiallot.CopyExtensionCollection(materialLot4Update);
			list.Add(materialLot4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteMaterialLot(IDbContext dbContext, Materiallot[] materialLotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotList", materialLotList);
		string text = "UnDeleteMaterialLot";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materiallot> list = new List<Materiallot>();
		foreach (Materiallot materiallot in materialLotList)
		{
			Materiallot materialLot4Update = GetMaterialLot4Update(dbContext, materiallot.Materiallotid, materiallot.Siteid);
			if (materialLot4Update == null)
			{
				throw new EntityNotFoundException(typeof(Materiallot), $"{materiallot.Materiallotid},{materiallot.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Materiallot), $"{materiallot.Materiallotid},{materiallot.Siteid}", materialLot4Update.Isusable);
			materialLot4Update.Isusable = "Usable";
			materiallot.CopyCommonFieldUpdatePrev(materialLot4Update, systemTime, dbContext.Tid, text);
			materiallot.CopyExtensionCollection(materialLot4Update);
			list.Add(materialLot4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteMaterialLot(IDbContext dbContext, Materiallot[] materialLotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotList", materialLotList);
		string text = "RealDeleteMaterialLot";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materiallot> list = new List<Materiallot>();
		foreach (Materiallot materiallot in materialLotList)
		{
			Materiallot materialLot4Update = GetMaterialLot4Update(dbContext, materiallot.Materiallotid, materiallot.Siteid);
			if (materialLot4Update == null)
			{
				throw new EntityNotFoundException(typeof(Materiallot), $"{materiallot.Materiallotid},{materiallot.Siteid}");
			}
			materiallot.CopyCommonFieldUpdatePrev(materialLot4Update, systemTime, dbContext.Tid, text);
			materiallot.CopyExtensionCollection(materialLot4Update);
			list.Add(materialLot4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	internal static string[] ExtractIdOrderBy(Materiallot[] materialLotList)
	{
		return (from p in materialLotList
			select p.Materiallotid into id
			orderby id
			select id).ToArray();
	}

	internal static string[] ExtractIdOrderBy(Lotmateriallotrel[] lotmateriallotrelList)
	{
		return (from p in lotmateriallotrelList
			select p.Materiallotid into id
			group id by id into key
			select key.Key).ToArray();
	}

	public static Materiallot FindMaterialLot(Materiallot[] materialLotList, string materialLotId)
	{
		return materialLotList?.FirstOrDefault((Materiallot item) => item.Materiallotid == materialLotId);
	}

	public static int MergeMaterialLot(IDbContext dbContext, Materiallot parentMaterialLot, Materiallot[] childMaterialLotList, IOptionSet childOptionSet, bool saveHistParent, bool saveHistChild)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("parentMaterialLot", parentMaterialLot);
		ParamChecker.ArgumentNotNullAndHasElement("childMaterialLotList", childMaterialLotList);
		string text = "MergeMaterialLot";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materiallot> list = new List<Materiallot>();
		List<Materiallot> list2 = new List<Materiallot>();
		ParamChecker.ArgumentNotNull("Materiallotid", parentMaterialLot.Materiallotid);
		ParamChecker.ArgumentNotNull("Siteid", parentMaterialLot.Siteid);
		string siteid = parentMaterialLot.Siteid;
		string materiallotid = parentMaterialLot.Materiallotid;
		Materiallot materiallot;
		if ((materiallot = SelectMaterialLot4Update(dbContext, materiallotid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Materiallot), materiallotid);
		}
		Materiallot[] materialLotList = SelectMaterialLotList4Update(dbContext, childMaterialLotList, siteid).ToArray();
		decimal value = default(decimal);
		foreach (Materiallot materiallot2 in childMaterialLotList)
		{
			Materiallot materiallot3 = FindMaterialLot(materialLotList, materiallot2.Materiallotid);
			if (materiallot3 == null)
			{
				throw new EntityNotFoundException(typeof(Materiallot), materiallot2.Materiallotid);
			}
			value += materiallot3.Qty.GetValueOrDefault();
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", materiallot3);
			}
			materiallot3.Mergemateriallotid = materiallot.Materiallotid;
			materiallot3.Prevstate = materiallot3.State;
			materiallot3.State = "Terminated";
			materiallot2.CopyCommonFieldUpdatePrev(materiallot3, systemTime, tid, text);
			materiallot2.CopyExtensionCollection(materiallot3);
			list2.Add(materiallot3);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", materiallot3);
			}
		}
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", materiallot);
		}
		materiallot.Prevqty = materiallot.Qty;
		materiallot.Qty = materiallot.Qty.Add(value);
		parentMaterialLot.CopyCommonFieldUpdatePrev(materiallot, systemTime, tid, text);
		parentMaterialLot.CopyExtensionCollection(materiallot);
		list.Add(materiallot);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", materiallot);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHistParent);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHistChild);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int MoveMaterialLotLocation(IDbContext dbContext, Materiallot[] materialLotList, MoveMaterialLotLocationOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotList", materialLotList);
		string text = "MoveMaterialLotLocation";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materiallot> list = new List<Materiallot>();
		Materiallot[] materialLotList2 = SelectMaterialLotList4Update(dbContext, materialLotList, materialLotList[0].Siteid).ToArray();
		foreach (Materiallot materiallot in materialLotList)
		{
			ParamChecker.ArgumentNotNull("Materiallotid", materiallot.Materiallotid);
			ParamChecker.ArgumentNotNull("Location", materiallot.Location);
			ParamChecker.ArgumentNotNull("Siteid", materiallot.Siteid);
			string materiallotid = materiallot.Materiallotid;
			string location = materiallot.Location;
			DateTime? movetime = materiallot.Movetime;
			DateTime? stockdate = materiallot.Stockdate;
			DateTime? expiredate = materiallot.Expiredate;
			string siteid = materiallot.Siteid;
			Materiallot materiallot2;
			if ((materiallot2 = FindMaterialLot(materialLotList2, materiallotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Materiallot), materiallotid);
			}
			if (FACILITY.SelectFacility(dbContext, location, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(Facility), location);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", materiallot2);
			}
			materiallot2.Prevlocation = materiallot2.Location;
			materiallot2.Location = location;
			if (optionSet.ConvertActiveState && !"Active".Equals(materiallot2.State) && STATETRANSITION.SelectStateTransition(dbContext, "MaterialState", materiallot2.State, "Active", materiallot2.Siteid) != null)
			{
				materiallot2.Prevstate = materiallot2.State;
				materiallot2.State = "Active";
			}
			if (optionSet.UpdateMoveTime)
			{
				if (movetime.HasValue)
				{
					materiallot2.Movetime = movetime;
				}
				else
				{
					materiallot2.Movetime = systemTime;
				}
			}
			if (optionSet.UpdateExpireTime)
			{
				if (expiredate.HasValue)
				{
					materiallot2.Expiredate = expiredate;
				}
				else
				{
					materiallot2.Expiredate = systemTime;
				}
			}
			if (optionSet.UpdateStockDate)
			{
				if (stockdate.HasValue)
				{
					materiallot2.Stockdate = stockdate;
				}
				else
				{
					materiallot2.Stockdate = systemTime;
				}
			}
			materiallot.CopyCommonFieldUpdatePrev(materiallot2, systemTime, tid, text);
			materiallot.CopyExtensionCollection(materiallot2);
			list.Add(materiallot2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", materiallot2);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int MultiDekitMaterialLot(IDbContext dbContext, Materiallot materialLot, Materiallotportrel[] materialLotPortRelList, MultiDekitMaterialLotOptionSet multiDekitMaterialLotOptionSet, bool saveMaterialLotHist, bool saveMaterialLotPortRelHist, bool savePortHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("materialLot", materialLot);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotPortRelList", materialLotPortRelList);
		string text = "MultiDekitMaterialLot";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		int num = 0;
		List<Materiallot> list = new List<Materiallot>();
		List<Materiallotportrel> list2 = new List<Materiallotportrel>();
		List<Port> list3 = new List<Port>();
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num2;
		if (multiDekitMaterialLotOptionSet != null)
		{
			_ = multiDekitMaterialLotOptionSet.IsDeleteMaterialLotEquipmentPortId;
			if (0 == 0)
			{
				num2 = (multiDekitMaterialLotOptionSet.IsDeleteMaterialLotEquipmentPortId ? 1 : 0);
				goto IL_007a;
			}
		}
		num2 = 0;
		goto IL_007a;
		IL_007a:
		bool flag = (byte)num2 != 0;
		ParamChecker.ArgumentNotNull("Materiallotid", materialLot.Materiallotid);
		ParamChecker.ArgumentNotNull("Siteid", materialLot.Siteid);
		string materiallotid = materialLot.Materiallotid;
		string siteid = materialLot.Siteid;
		Materiallot materiallot = SelectMaterialLot4Update(dbContext, materiallotid, siteid);
		if (materiallot == null)
		{
			throw new EntityNotFoundException(typeof(Materiallot), materiallotid);
		}
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", materiallot);
		}
		if (flag)
		{
			materiallot.Equipmentid = null;
			materiallot.Portid = null;
		}
		materialLot.CopyCommonFieldUpdatePrev(materiallot, systemTime, tid, text);
		materialLot.CopyExtensionCollection(materiallot);
		list.Add(materiallot);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", materiallot);
		}
		foreach (Materiallotportrel materiallotportrel in materialLotPortRelList)
		{
			ParamChecker.ArgumentNotNull("Equipmentid", materiallotportrel.Equipmentid);
			ParamChecker.ArgumentNotNull("Portid", materiallotportrel.Portid);
			string equipmentid = materiallotportrel.Equipmentid;
			string portid = materiallotportrel.Portid;
			Port port = PORT.SelectPort4Update(dbContext, equipmentid, portid, siteid);
			if (port == null)
			{
				throw new EntityNotFoundException(typeof(Port), equipmentid, portid);
			}
			Materiallotportrel materiallotportrel2 = MATERIALLOTPORTREL.SelectMaterialLotPortRel4Update(dbContext, materiallotid, equipmentid, portid, siteid);
			if (materiallotportrel2 == null)
			{
				throw new EntityNotFoundException(typeof(Materiallotportrel), materiallotid, equipmentid, portid);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", materiallotportrel2);
			}
			materiallotportrel.CopyCommonFieldUpdatePrev(materiallotportrel2, systemTime, tid, text);
			materiallotportrel.CopyExtensionCollection(materiallotportrel2);
			list2.Add(materiallotportrel2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", materiallotportrel2);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", port);
			}
			materiallotportrel.CopyCommonFieldUpdatePrev(port, systemTime, tid, text);
			list3.Add(port);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", port);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveMaterialLotHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list2.ToArray(), saveMaterialLotPortRelHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list3.ToArray(), savePortHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int MultiKitMaterialLot(IDbContext dbContext, Materiallot materialLot, Materiallotportrel[] materialLotPortRelList, MultiKitMaterialLotOptionSet multiKitMaterialLotOptionSet, bool saveMaterialLotHist, bool saveMaterialLotPortRelHist, bool savePortHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("materialLot", materialLot);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotPortRelList", materialLotPortRelList);
		string text = "MultiKitMaterialLot";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		int num = 0;
		List<Materiallot> list = new List<Materiallot>();
		List<Materiallotportrel> list2 = new List<Materiallotportrel>();
		List<Port> list3 = new List<Port>();
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num2;
		if (multiKitMaterialLotOptionSet != null)
		{
			_ = multiKitMaterialLotOptionSet.AdjustLastMaterialLotPortRel;
			if (0 == 0)
			{
				num2 = (multiKitMaterialLotOptionSet.AdjustLastMaterialLotPortRel ? 1 : 0);
				goto IL_007a;
			}
		}
		num2 = 0;
		goto IL_007a;
		IL_007a:
		bool flag = (byte)num2 != 0;
		ParamChecker.ArgumentNotNull("Materiallotid", materialLot.Materiallotid);
		ParamChecker.ArgumentNotNull("Siteid", materialLot.Siteid);
		string materiallotid = materialLot.Materiallotid;
		string siteid = materialLot.Siteid;
		Materiallot materiallot = SelectMaterialLot4Update(dbContext, materiallotid, siteid);
		if (materiallot == null)
		{
			throw new EntityNotFoundException(typeof(Materiallot), materiallotid);
		}
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", materiallot);
		}
		if (flag)
		{
			materiallot.Equipmentid = materialLotPortRelList[^1].Equipmentid;
			materiallot.Portid = materialLotPortRelList[^1].Portid;
		}
		materialLot.CopyCommonFieldUpdatePrev(materiallot, systemTime, tid, text);
		materialLot.CopyExtensionCollection(materiallot);
		list.Add(materiallot);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", materiallot);
		}
		foreach (Materiallotportrel materiallotportrel in materialLotPortRelList)
		{
			ParamChecker.ArgumentNotNull("Equipmentid", materiallotportrel.Equipmentid);
			ParamChecker.ArgumentNotNull("Portid", materiallotportrel.Portid);
			string equipmentid = materiallotportrel.Equipmentid;
			string portid = materiallotportrel.Portid;
			Port port = PORT.SelectPort4Update(dbContext, equipmentid, portid, siteid);
			if (port == null)
			{
				throw new EntityNotFoundException(typeof(Port), equipmentid, portid);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", port);
			}
			materiallotportrel.CopyCommonFieldUpdatePrev(port, systemTime, tid, text);
			list3.Add(port);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", port);
			}
			Materiallotportrel materiallotportrel2 = new Materiallotportrel();
			materiallotportrel.CopyColumsTo(materiallotportrel2);
			materiallotportrel2.Equipmentid = equipmentid;
			materiallotportrel2.Portid = portid;
			materiallotportrel2.Materiallotid = materiallotid;
			materiallotportrel2.Activity = text;
			materiallotportrel2.Isusable = "Usable";
			materiallotportrel2.Siteid = siteid;
			materiallotportrel.CopyCommonField(materiallotportrel2, systemTime, tid, isCreate: true);
			list2.Add(materiallotportrel2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", materiallotportrel2);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveMaterialLotHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list3.ToArray(), savePortHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list2.ToArray(), saveMaterialLotPortRelHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int ReleaseHoldMaterialLot(IDbContext dbContext, Materiallot[] materialLotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotList", materialLotList);
		string text = "ReleaseHoldMaterialLot";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materiallot> list = new List<Materiallot>();
		Materiallot[] materialLotList2 = SelectMaterialLotList4Update(dbContext, materialLotList, materialLotList[0].Siteid).ToArray();
		foreach (Materiallot materiallot in materialLotList)
		{
			ParamChecker.ArgumentNotNull("Materiallotid", materiallot.Materiallotid);
			ParamChecker.ArgumentNotNull("Siteid", materiallot.Siteid);
			string materiallotid = materiallot.Materiallotid;
			_ = materiallot.Siteid;
			Materiallot materiallot2;
			if ((materiallot2 = FindMaterialLot(materialLotList2, materiallotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Materiallot), materiallotid);
			}
			ParamChecker.EntityValidState(typeof(Materiallot), materiallotid, materiallot2.State, "Hold");
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", materiallot2);
			}
			string prevstate = materiallot2.Prevstate;
			materiallot2.Prevstate = materiallot2.State;
			materiallot2.State = prevstate;
			materiallot.CopyCommonFieldUpdatePrev(materiallot2, systemTime, tid, text);
			materiallot.CopyExtensionCollection(materiallot2);
			list.Add(materiallot2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", materiallot2);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int ScrapMaterialLot(IDbContext dbContext, Materiallot[] materialLotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotList", materialLotList);
		string text = "ScrapMaterialLot";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materiallot> list = new List<Materiallot>();
		Materiallot[] materialLotList2 = SelectMaterialLotList4Update(dbContext, materialLotList, materialLotList[0].Siteid).ToArray();
		foreach (Materiallot materiallot in materialLotList)
		{
			ParamChecker.ArgumentNotNull("Materiallotid", materiallot.Materiallotid);
			ParamChecker.ArgumentNotNull("Siteid", materiallot.Siteid);
			string materiallotid = materiallot.Materiallotid;
			_ = materiallot.Siteid;
			Materiallot materiallot2;
			if ((materiallot2 = FindMaterialLot(materialLotList2, materiallotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Materiallot), materiallotid);
			}
			ParamChecker.EntityInvalidState(typeof(Materiallot), materiallotid, materiallot2.State, "Scrapped");
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", materiallot2);
			}
			decimal valueOrDefault = materiallot2.Qty.GetValueOrDefault();
			materiallot2.Prevqty = materiallot2.Qty;
			materiallot2.Qty = default(decimal);
			materiallot2.Lossqty = materiallot2.Lossqty.Add(valueOrDefault);
			materiallot2.Prevstate = materiallot2.State;
			materiallot2.State = "Scrapped";
			materiallot.CopyCommonFieldUpdatePrev(materiallot2, systemTime, tid, text);
			materiallot.CopyExtensionCollection(materiallot2);
			list.Add(materiallot2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", materiallot2);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int SplitMaterialLot(IDbContext dbContext, Materiallot parentMaterialLot, Materiallot[] childMaterialLotList, IOptionSet splitMaterialLotOptionSet, bool saveHistParent, bool saveHistChild)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("parentMaterialLot", parentMaterialLot);
		ParamChecker.ArgumentNotNullAndHasElement("childMaterialLotList", childMaterialLotList);
		string text = "SplitMaterialLot";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materiallot> list = new List<Materiallot>();
		List<Materiallot> list2 = new List<Materiallot>();
		ParamChecker.ArgumentNotNull("Materiallotid", parentMaterialLot.Materiallotid);
		ParamChecker.ArgumentNotNull("Siteid", parentMaterialLot.Siteid);
		string siteid = parentMaterialLot.Siteid;
		string materiallotid = parentMaterialLot.Materiallotid;
		Materiallot materiallot;
		if ((materiallot = SelectMaterialLot4Update(dbContext, materiallotid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Materiallot), materiallotid);
		}
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", materiallot);
		}
		materiallot.Prevqty = materiallot.Qty;
		Materiallot[] array = childMaterialLotList;
		foreach (Materiallot materiallot2 in array)
		{
			materiallot.Qty = materiallot.Qty.Add(-materiallot2.Qty);
		}
		decimal? qty = materiallot.Qty;
		if ((qty.GetValueOrDefault() < default(decimal)) & qty.HasValue)
		{
			throw new QuantityInvalidException(materiallotid, materiallot.Qty);
		}
		qty = materiallot.Qty;
		if (((qty.GetValueOrDefault() == default(decimal)) & qty.HasValue) && splitMaterialLotOptionSet is SplitMaterialLotOptionSet { TerminateParentQtyZero: not false })
		{
			materiallot.Prevstate = materiallot.State;
			materiallot.State = "Terminated";
		}
		parentMaterialLot.CopyCommonFieldUpdatePrev(materiallot, systemTime, tid, text);
		parentMaterialLot.CopyExtensionCollection(materiallot);
		list.Add(materiallot);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", materiallot);
		}
		array = childMaterialLotList;
		foreach (Materiallot materiallot3 in array)
		{
			ParamChecker.ArgumentNotNull("Materiallotid", materiallot3.Materiallotid);
			ParamChecker.ArgumentNotNull("Siteid", materiallot3.Siteid);
			string siteid2 = EntityHelper.FirstNotNull<string>(materiallot3.Siteid, siteid);
			string materiallotid2 = materiallot3.Materiallotid;
			Materiallot materiallot4 = new Materiallot();
			materiallot.CopyColumsTo(materiallot4);
			materiallot4.Materiallotid = materiallotid2;
			materiallot4.Siteid = siteid2;
			materiallot4.Materiallotname = materiallot3.Materiallotname;
			materiallot4.Prevqty = default(decimal);
			materiallot4.Qty = materiallot3.Qty;
			materiallot4.Originalqty = materiallot3.Qty;
			materiallot4.Parentmateriallotid = materiallotid;
			materiallot4.Rootparentmateriallotid = EntityHelper.FirstNotNull<string>(materiallot4.Rootparentmateriallotid, materiallotid);
			materiallot4.Activity = text;
			materiallot4.Isusable = "Usable";
			materiallot3.CopyCommonField(materiallot4, systemTime, tid, isCreate: true);
			materiallot3.CopyExtensionCollection(materiallot4);
			list2.Add(materiallot4);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", materiallot4);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHistParent);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list2.ToArray(), saveHistChild);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int TerminateMaterialLot(IDbContext dbContext, Materiallot[] materialLotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialLotList", materialLotList);
		string text = "TerminateMaterialLot";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materiallot> list = new List<Materiallot>();
		Materiallot[] materialLotList2 = SelectMaterialLotList4Update(dbContext, materialLotList, materialLotList[0].Siteid).ToArray();
		foreach (Materiallot materiallot in materialLotList)
		{
			ParamChecker.ArgumentNotNull("Materiallotid", materiallot.Materiallotid);
			ParamChecker.ArgumentNotNull("Siteid", materiallot.Siteid);
			string materiallotid = materiallot.Materiallotid;
			_ = materiallot.Siteid;
			Materiallot materiallot2;
			if ((materiallot2 = FindMaterialLot(materialLotList2, materiallotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Materiallot), materiallotid);
			}
			ParamChecker.EntityInvalidState(typeof(Materiallot), materiallotid, materiallot2.State, "Terminated");
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", materiallot2);
			}
			materiallot2.Prevstate = materiallot2.State;
			materiallot2.State = "Terminated";
			materiallot.CopyCommonFieldUpdatePrev(materiallot2, systemTime, tid, text);
			materiallot.CopyExtensionCollection(materiallot2);
			list.Add(materiallot2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", materiallot2);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
