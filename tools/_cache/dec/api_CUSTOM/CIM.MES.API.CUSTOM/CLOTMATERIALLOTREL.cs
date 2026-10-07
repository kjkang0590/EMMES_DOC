using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.API.POS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.CUSTOM;

[MESAPI]
public class CLOTMATERIALLOTREL
{
	public static int ConsumeLot(IDbContext dbContext, Lot lot, Lot[] materialLotList, ConsumeMaterialLotOptionSet optionSet, bool saveLotHist, bool saveMaterialLotHist, bool saveLotMaterialLotRelHist)
	{
		string text = "ConsumeLot";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("lot", lot);
		ParamChecker.ArgumentNotNull("materialLotList", materialLotList);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Lot> list2 = new List<Lot>();
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
		Lot[] lotList = LOT.SelectLotList4Update(dbContext, materialLotList, siteid).ToArray();
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
		bool flag = false;
		if (optionSet != null)
		{
			flag = optionSet.TerminateMaterialLotQtyZero;
		}
		foreach (Lot lot3 in materialLotList)
		{
			ParamChecker.ArgumentNotNull("Materiallotid", lot3.Lotid);
			ParamChecker.ArgumentNotNull("Qty", lot3.Qty);
			ParamChecker.ArgumentNotNull("Siteid", lot3.Siteid);
			string lotid2 = lot3.Lotid;
			_ = lot3.Siteid;
			bool flag2 = false;
			Lot lot4;
			if ((lot4 = LOT.FindLot(lotList, lotid2)) == null)
			{
				throw new EntityNotFoundException(typeof(Lot), lotid2);
			}
			Lotmateriallotrel lotmateriallotrel = LOTMATERIALLOTREL.SelectLotMaterialLotRelWithMaterialLot4Update(dbContext, lotid, lotid2, processnodeid, repeatcount, siteid);
			Convert.ToDecimal(lot3.Qty);
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", lot4);
			}
			if (lotmateriallotrel != null)
			{
				lot4.Qty = lot4.Qty.Add(lotmateriallotrel.Qty);
			}
			lot4.Prevqty = lot4.Qty;
			lot4.Qty = lot4.Qty.Add(-lot3.Qty);
			if (flag)
			{
				decimal? qty = lot4.Qty;
				if ((qty.GetValueOrDefault() == default(decimal)) & qty.HasValue)
				{
					lot4.Prevstate = lot4.State;
					lot4.State = "Terminated";
				}
			}
			lot3.CopyCommonFieldUpdatePrev(lot4, systemTime, tid, text);
			lot3.CopyExtensionCollection(lot4);
			list2.Add(lot4);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", lot4);
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
			lotmateriallotrel.Materiallotid = lotid2;
			lotmateriallotrel.Qty = lot3.Qty;
			lotmateriallotrel.Unitid = lot3.Unitid;
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
	}

	public static int ConsumeLotForAdjustment(IDbContext dbContext, Lot lot, Lot[] materialLotList, ConsumeMaterialLotOptionSet optionSet, bool saveLotHist, bool saveMaterialLotHist, bool saveLotMaterialLotRelHist)
	{
		string text = "ConsumeLotForAdjustment";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("lot", lot);
		ParamChecker.ArgumentNotNull("materialLotList", materialLotList);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Lot> list2 = new List<Lot>();
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
		Lot[] lotList = LOT.SelectLotList4Update(dbContext, materialLotList, siteid).ToArray();
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
		bool flag = false;
		if (optionSet != null)
		{
			flag = optionSet.TerminateMaterialLotQtyZero;
		}
		foreach (Lot lot3 in materialLotList)
		{
			ParamChecker.ArgumentNotNull("Materiallotid", lot3.Lotid);
			ParamChecker.ArgumentNotNull("Qty", lot3.Qty);
			ParamChecker.ArgumentNotNull("Siteid", lot3.Siteid);
			string lotid2 = lot3.Lotid;
			_ = lot3.Siteid;
			bool flag2 = false;
			Lot lot4;
			if ((lot4 = LOT.FindLot(lotList, lotid2)) == null)
			{
				throw new EntityNotFoundException(typeof(Lot), lotid2);
			}
			Lotmateriallotrel lotmateriallotrel = LOTMATERIALLOTREL.SelectLotMaterialLotRelWithMaterialLot4Update(dbContext, lotid, lotid2, processnodeid, repeatcount, siteid);
			Convert.ToDecimal(lot3.Qty);
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", lot4);
			}
			lot4.Prevqty = lot4.Qty;
			lot4.Qty = lot4.Qty.Add(-lot3.Qty);
			if (flag)
			{
				decimal? qty = lot4.Qty;
				if ((qty.GetValueOrDefault() == default(decimal)) & qty.HasValue)
				{
					lot4.Prevstate = lot4.State;
					lot4.State = "Terminated";
				}
			}
			lot3.CopyCommonFieldUpdatePrev(lot4, systemTime, tid, text);
			lot3.CopyExtensionCollection(lot4);
			list2.Add(lot4);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", lot4);
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
			lotmateriallotrel.Materiallotid = lotid2;
			if (flag2)
			{
				lotmateriallotrel.Qty = lotmateriallotrel.Qty.Add(lot3.Qty);
			}
			else
			{
				lotmateriallotrel.Qty = lot3.Qty;
			}
			lotmateriallotrel.Unitid = lot3.Unitid;
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
	}
}
