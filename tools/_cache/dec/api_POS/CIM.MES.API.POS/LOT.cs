using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CIM.MES.API.CDS;
using CIM.MES.API.PMS;
using CIM.MES.API.PPS;
using CIM.MES.API.RDS;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.POS;

[MESAPI]
public class LOT
{
	private static string _formatCancelConvertLotToMaterialLotBulk = "MaterialLotid={0} Materialdefinitionid={1} Location={2} Qty={3}";

	private static string _formatConvertLotToMaterialLotBulk = "Lotid={0} Processsegmentid={1} Location={2} Qty={3}";

	private static string _sqlGetLotSqlDatabase = "SELECT * FROM CIM_LOT WHERE LOTID=@LOTID AND SITEID=@SITEID";

	private static string _sqlGetLot4UpdateSqlDatabase = "SELECT * FROM CIM_LOT WITH(UPDLOCK) WHERE LOTID=@LOTID AND SITEID=@SITEID";

	private static string _sqlSelectLotSqlDatabase = "SELECT * FROM CIM_LOT WHERE LOTID=@LOTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLot4UpdateSqlDatabase = "SELECT * FROM CIM_LOT WITH(UPDLOCK) WHERE LOTID=@LOTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetLotOracleDatabase = "SELECT * FROM CIM_LOT WHERE LOTID=:LOTID AND SITEID=:SITEID";

	private static string _sqlGetLot4UpdateOracleDatabase = "SELECT * FROM CIM_LOT WHERE LOTID=:LOTID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectLotOracleDatabase = "SELECT * FROM CIM_LOT WHERE LOTID=:LOTID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLot4UpdateOracleDatabase = "SELECT * FROM CIM_LOT WHERE LOTID=:LOTID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Lot);

	private static string _sqlSelectLotListSqlDatabase = "SELECT * FROM CIM_LOT WHERE LOTID IN (&LOTIDLIST) AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLotList4UpdateSqlDatabase = "SELECT * FROM CIM_LOT WITH(UPDLOCK) WHERE LOTID IN (&LOTIDLIST) AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLotListOracleDatabase = "SELECT * FROM CIM_LOT WHERE LOTID IN (&LOTIDLIST) AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLotList4UpdateOracleDatabase = "SELECT * FROM CIM_LOT WHERE LOTID IN (&LOTIDLIST) AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static string _sqlSelectLotListWithNotStateSqlDatabase = "SELECT * FROM CIM_LOT WHERE LOTID IN (&LOTIDLIST) AND SITEID=@SITEID AND STATE NOT IN (&STATE) AND ISUSABLE='Usable'";

	private static string _sqlSelectLotListWithNotState4UpdateSqlDatabase = "SELECT * FROM CIM_LOT WITH(UPDLOCK) WHERE LOTID IN (&LOTIDLIST) AND SITEID=@SITEID AND STATE NOT IN (&STATE) AND ISUSABLE='Usable'";

	private static string _sqlSelectLotListWithNotStateOracleDatabase = "SELECT * FROM CIM_LOT WHERE LOTID IN (&LOTIDLIST) AND SITEID=:SITEID AND STATE NOT IN (&STATE) AND ISUSABLE='Usable'";

	private static string _sqlSelectLotListWithNotState4UpdateOracleDatabase = "SELECT * FROM CIM_LOT WHERE LOTID IN (&LOTIDLIST) AND SITEID=:SITEID AND STATE NOT IN (&STATE) AND ISUSABLE='Usable' FOR UPDATE";

	private static string _sqlSelectLotListWithStateSqlDatabase = "SELECT * FROM CIM_LOT WHERE LOTID IN (&LOTIDLIST) AND SITEID=@SITEID AND STATE IN (&STATE) AND ISUSABLE='Usable'";

	private static string _sqlSelectLotListWithState4UpdateSqlDatabase = "SELECT * FROM CIM_LOT WITH(UPDLOCK) WHERE LOTID IN (&LOTIDLIST) AND SITEID=@SITEID AND STATE IN (&STATE) AND ISUSABLE='Usable'";

	private static string _sqlSelectLotListWithStateOracleDatabase = "SELECT * FROM CIM_LOT WHERE LOTID IN (&LOTIDLIST) AND SITEID=:SITEID AND STATE IN (&STATE) AND ISUSABLE='Usable'";

	private static string _sqlSelectLotListWithState4UpdateOracleDatabase = "SELECT * FROM CIM_LOT WHERE LOTID IN (&LOTIDLIST) AND SITEID=:SITEID AND STATE IN (&STATE) AND ISUSABLE='Usable' FOR UPDATE";

	private static string _formatTrackInOutInfoLot = "Lotid={0} Processsegmentid={1} Equipmentid={2} Location={3} Grade={4} Qty={5} Submaterialqty={6} Lossqty={7} Nextprocesssegmentid={8} Trackinuser={9} Trackintime={10} Trackoutuser={11} Trackouttime={12} Processstarttime={13} Processendtime={14}";

	private static string _formatProcessChangeLot = "Lotid={0} State={1} Processingstate={2} Processsegmentid={3} Processsegmentruleid={4} Rulesequence={5} Nextprocesssegmentid={6}";

	private static string _formatTrackInOutInfoProducedMaterial = "Producedmaterialid={0} Processsegmentid={1} Equipmentid={2} Location={3} Grade={4} Submaterialqty={5} Trackinuser={6} Trackintime={7} Trackoutuser={8} Trackouttime={9} Processstarttime={10} Processendtime={11}";

	private static string _formatTrackInOutInfoLotBulk = "Lotid={0} Processsegmentid={1} Equipmentid={2} Location={3} Grade={4} Qty={5} Submaterialqty={6} Lossqty={7} Nextprocesssegmentid={8} Trackinuser={9} Trackintime={10} Trackoutuser={11} Trackouttime={12} Processstarttime={13} Processendtime={14}";

	private static string _formatProcessChangeLotBulk = "Lotid={0} State={1} Processingstate={2} Processsegmentid={3} Processsegmentruleid={4} Rulesequence={5} Nextprocesssegmentid={6}";

	private static string _formatTrackInOutInfoProducedMaterialBulk = "Producedmaterialid={0} Processsegmentid={1} Equipmentid={2} Location={3} Grade={4} Submaterialqty={5} Trackinuser={6} Trackintime={7} Trackoutuser={8} Trackouttime={9} Processstarttime={10} Processendtime={11}";

	public static int AssignLotBatchRelBulk(IDbContext dbContext, Lot[] lotList, Batch batch, Lotbatchrel[] lotbatchrelList, IOptionSet optionSet, bool saveLotHist, bool saveLotbatchrrelHist, bool saveBatchHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		object[] objectList = lotList;
		ParamChecker.ArgumentNotNull("lotList", objectList);
		ParamChecker.ArgumentNotNull("carrier", batch);
		objectList = lotbatchrelList;
		ParamChecker.ArgumentNotNull("lotbatchrelList", objectList);
		string text = "AssignLotBatchRelBulk";
		int apiVersion = 1;
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		string tid = dbContext.Tid;
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Batch> list2 = new List<Batch>();
		List<Lotbatchrel> list3 = new List<Lotbatchrel>();
		List<Lotbatchrel> list4 = new List<Lotbatchrel>();
		string siteid = lotbatchrelList[0].Siteid;
		Dictionary<string, Lotbatchrel[]> dictionary = (from g in lotbatchrelList
			group g by g.Lotid).ToDictionary((IGrouping<string, Lotbatchrel> g) => g.Key, (IGrouping<string, Lotbatchrel> g) => g.ToArray());
		string[] first = ExtractIdOrderBy(lotList);
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		if (lotList.Length > array.Length)
		{
			throw new EntityNotFoundException(typeof(Lot), first.Except(ExtractIdOrderBy(array.ToArray())).ToString());
		}
		if (!ValidateAllowHoldLotBulk(dbContext, text, apiVersion, array))
		{
			throw new EntityIsHoldException(typeof(Lot), "," + dictionary.Keys.ToArray());
		}
		IList<Lot> list5 = SelectLotListAlive4Update(dbContext, array, siteid);
		if (array.Length > list5.Count)
		{
			throw new EntityNotFoundException(typeof(Lot), first.Except(ExtractIdOrderBy(list5.ToArray())).ToString());
		}
		Dictionary<string, Lot[]> dictionary2 = (from lot in array
			group lot by lot.Processnodeid).ToDictionary((IGrouping<string, Lot> g) => g.Key, (IGrouping<string, Lot> g) => g.ToArray());
		if (dictionary2.Count > 1)
		{
			throw new InvalidNotSameProcessnodeException(typeof(Lot), dictionary2.Keys.ToArray());
		}
		foreach (Lot inputLot in lotList)
		{
			Lot lot2 = array.Where((Lot lot) => lot.Lotid == inputLot.Lotid && lot.Siteid == inputLot.Siteid).FirstOrDefault();
			UpdateUserColumns(text, inputLot, lot2);
			inputLot.CopyCommonFieldUpdatePrev(lot2, systemTime, tid, text);
			inputLot.CopyExtensionCollection(lot2);
			list.Add(lot2);
		}
		ParamChecker.ArgumentNotNull("Batchid", batch.Batchid);
		ParamChecker.ArgumentNotNull("Siteid", batch.Siteid);
		string batchid = batch.Batchid;
		Batch batch2 = BATCH.SelectBatch4Update(dbContext, batchid, batch.Siteid);
		if (batch2 == null)
		{
			throw new EntityNotFoundException(typeof(Batch), batchid);
		}
		if (batch.Qty.HasValue && !(batch2.Qty == batch.Qty))
		{
			batch2.Qty = batch.Qty;
		}
		batch.CopyCommonFieldUpdatePrev(batch2, systemTime, tid, text);
		batch.CopyExtensionCollection(batch2);
		list2.Add(batch2);
		foreach (Lotbatchrel inputLotbatchrel in lotbatchrelList)
		{
			ParamChecker.ArgumentNotNull("Lotid", inputLotbatchrel.Lotid);
			ParamChecker.ArgumentNotNull("Batchid", inputLotbatchrel.Batchid);
			ParamChecker.ArgumentNotNull("Qty", inputLotbatchrel.Qty);
			ParamChecker.ArgumentNotNull("Siteid", inputLotbatchrel.Siteid);
			string lotid = inputLotbatchrel.Lotid;
			string batchid2 = inputLotbatchrel.Batchid;
			if (!batchid.Equals(inputLotbatchrel.Batchid))
			{
				throw new ObjectComparedInvalidException("Batchid", batchid, inputLotbatchrel.Batchid);
			}
			if (!siteid.Equals(inputLotbatchrel.Siteid))
			{
				throw new ObjectComparedInvalidException("Siteid", siteid, inputLotbatchrel.Siteid);
			}
			if (lotList.Where((Lot lot) => lot.Lotid == inputLotbatchrel.Lotid && lot.Siteid == inputLotbatchrel.Siteid).FirstOrDefault() == null)
			{
				throw new InvalidAssignLotBatchRelException(inputLotbatchrel.Lotid, inputLotbatchrel.Batchid, inputLotbatchrel.Siteid);
			}
			Lotbatchrel lotBatchRel = LOTBATCHREL.GetLotBatchRel(dbContext, lotid, batchid2, siteid);
			bool flag = lotBatchRel != null;
			Lotbatchrel lotbatchrel = new Lotbatchrel();
			if (flag)
			{
				lotBatchRel.CopyColumsTo(lotbatchrel);
			}
			else
			{
				inputLotbatchrel.CopyColumsTo(lotbatchrel);
			}
			if (inputLotbatchrel.Qty.HasValue && !(lotbatchrel.Qty == inputLotbatchrel.Qty))
			{
				lotbatchrel.Qty = inputLotbatchrel.Qty;
			}
			lotbatchrel.Prevactivity = null;
			lotbatchrel.Activity = "AssignLotBatchRel";
			lotbatchrel.Isusable = "Usable";
			lotbatchrel.Siteid = siteid;
			inputLotbatchrel.CopyCommonField(lotbatchrel, systemTime, tid, isCreate: true);
			lotbatchrel.Customactivity = EntityHelper.FirstNotNull<string>(inputLotbatchrel.Customactivity, lotbatchrel.Activity);
			if (flag)
			{
				list3.Add(lotbatchrel);
			}
			else
			{
				list4.Add(lotbatchrel);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveLotHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveBatchHist);
		if (list3.Count > 0)
		{
			num += ContextManager.BulkUpdateEntityFullColumn(dbContext, list3[0], list3.ToArray(), null, saveLotbatchrrelHist);
		}
		if (list4.Count > 0)
		{
			num += ContextManager.BulkCreateEntityFullColumn(dbContext, list4.ToArray(), saveLotbatchrrelHist);
		}
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int AssignLotToCarrier(IDbContext dbContext, Lot lot, Carrier carrier, Lotcarrierrel[] lotcarrierrelList, IOptionSet optionSet, bool saveLotHist, bool saveLotCarrierrelHist, bool saveCarrierHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("lot", lot);
		ParamChecker.ArgumentNotNull("carrier", carrier);
		ParamChecker.ArgumentNotNull("lotcarrierrelList", lotcarrierrelList);
		string text = "AssignLotToCarrier";
		int apiVersion = 1;
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		string tid = dbContext.Tid;
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Carrier> list2 = new List<Carrier>();
		List<Lotcarrierrel> list3 = new List<Lotcarrierrel>();
		List<Lotcarrierrel> list4 = new List<Lotcarrierrel>();
		ParamChecker.ArgumentNotNull("Lotid", lot.Lotid);
		ParamChecker.ArgumentNotNull("Siteid", lot.Siteid);
		string lotid = lot.Lotid;
		string siteid = lot.Siteid;
		Lot lot2;
		if ((lot2 = SelectLot4Update(dbContext, lotid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Lot), lotid);
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTid("API", tid, string.Format("{0} {1}", "Select4Update", lot2));
		}
		if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot))
		{
			throw new EntityIsHoldException(typeof(Lot), lot.Lotid);
		}
		lot.CopyCommonFieldUpdatePrev(lot2, systemTime, tid, text);
		lot.CopyExtensionCollection(lot2);
		list.Add(lot2);
		ParamChecker.ArgumentNotNull("Carrierid", carrier.Carrierid);
		ParamChecker.ArgumentNotNull("Siteid", carrier.Siteid);
		string carrierid = carrier.Carrierid;
		Carrier carrier2 = CARRIER.SelectCarrier(dbContext, carrierid, siteid);
		if (carrier2 == null)
		{
			throw new EntityNotFoundException(typeof(Carrier), carrierid);
		}
		if (carrier.Assignqty.HasValue && !(carrier2.Assignqty == carrier.Assignqty))
		{
			carrier2.Assignqty = carrier.Assignqty;
		}
		if (carrier.Loadstate != null && carrier2.Loadstate != carrier.Loadstate)
		{
			carrier2.Loadstate = carrier.Loadstate;
		}
		carrier.CopyCommonFieldUpdatePrev(carrier2, systemTime, tid, text);
		carrier.CopyExtensionCollection(carrier2);
		list2.Add(carrier2);
		foreach (Lotcarrierrel lotcarrierrel in lotcarrierrelList)
		{
			ParamChecker.ArgumentNotNull("Lotid", lotcarrierrel.Lotid);
			ParamChecker.ArgumentNotNull("Carrierid", lotcarrierrel.Carrierid);
			ParamChecker.ArgumentNotNull("Slotposition", lotcarrierrel.Slotposition);
			ParamChecker.ArgumentNotNull("Siteid", lotcarrierrel.Siteid);
			string lotid2 = lotcarrierrel.Lotid;
			string carrierid2 = lotcarrierrel.Carrierid;
			int slotposition = lotcarrierrel.Slotposition;
			if (!lotid.Equals(lotcarrierrel.Lotid))
			{
				throw new ObjectComparedInvalidException("Lotid", lotid, lotcarrierrel.Lotid);
			}
			if (!carrierid.Equals(lotcarrierrel.Carrierid))
			{
				throw new ObjectComparedInvalidException("Carrierid", carrierid, lotcarrierrel.Carrierid);
			}
			if (!siteid.Equals(lotcarrierrel.Siteid))
			{
				throw new ObjectComparedInvalidException("Siteid", siteid, lotcarrierrel.Siteid);
			}
			Lotcarrierrel lotCarrierRel = LOTCARRIERREL.GetLotCarrierRel(dbContext, lotid2, carrierid2, slotposition, siteid);
			bool flag = lotCarrierRel != null;
			Lotcarrierrel lotcarrierrel2 = new Lotcarrierrel();
			if (flag)
			{
				lotCarrierRel.CopyColumsTo(lotcarrierrel2);
			}
			else
			{
				lotcarrierrel.CopyColumsTo(lotcarrierrel2);
			}
			if (lotcarrierrel.Assignqty.HasValue && !(lotcarrierrel2.Assignqty == lotcarrierrel.Assignqty))
			{
				lotcarrierrel2.Assignqty = lotcarrierrel.Assignqty;
			}
			lotcarrierrel2.Prevactivity = null;
			lotcarrierrel2.Activity = "AssignLotToCarrier";
			lotcarrierrel2.Isusable = "Usable";
			lotcarrierrel2.Siteid = siteid;
			lotcarrierrel.CopyCommonField(lotcarrierrel2, systemTime, tid, isCreate: true);
			lotcarrierrel2.Customactivity = EntityHelper.FirstNotNull<string>(lotcarrierrel.Customactivity, lotcarrierrel2.Activity);
			if (flag)
			{
				list3.Add(lotcarrierrel2);
			}
			else
			{
				list4.Add(lotcarrierrel2);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveLotHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveCarrierHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list3.ToArray(), saveLotCarrierrelHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list4.ToArray(), saveLotCarrierrelHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int AssignLotToCarrierBulk(IDbContext dbContext, Lot[] lotList, Carrier carrier, Lotcarrierrel[] lotcarrierrelList, IOptionSet optionSet, bool saveLotHist, bool saveLotCarrierrelHist, bool saveCarrierHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		object[] objectList = lotList;
		ParamChecker.ArgumentNotNull("lotList", objectList);
		ParamChecker.ArgumentNotNull("carrier", carrier);
		objectList = lotcarrierrelList;
		ParamChecker.ArgumentNotNull("lotcarrierrelList", objectList);
		string text = "AssignLotToCarrier";
		int apiVersion = 1;
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		string tid = dbContext.Tid;
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Carrier> list2 = new List<Carrier>();
		List<Lotcarrierrel> list3 = new List<Lotcarrierrel>();
		List<Lotcarrierrel> list4 = new List<Lotcarrierrel>();
		string siteid = lotcarrierrelList[0].Siteid;
		Dictionary<string, Lotcarrierrel[]> dictionary = (from g in lotcarrierrelList
			group g by g.Lotid).ToDictionary((IGrouping<string, Lotcarrierrel> g) => g.Key, (IGrouping<string, Lotcarrierrel> g) => g.ToArray());
		string[] first = ExtractIdOrderBy(lotList);
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		if (lotList.Length > array.Length)
		{
			throw new EntityNotFoundException(typeof(Lot), first.Except(ExtractIdOrderBy(array.ToArray())).ToString());
		}
		if (!ValidateAllowHoldLotBulk(dbContext, text, apiVersion, array))
		{
			throw new EntityIsHoldException(typeof(Lot), "," + dictionary.Keys.ToArray());
		}
		IList<Lot> list5 = SelectLotListAlive4Update(dbContext, array, siteid);
		if (array.Length > list5.Count)
		{
			throw new EntityNotFoundException(typeof(Lot), first.Except(ExtractIdOrderBy(list5.ToArray())).ToString());
		}
		Dictionary<string, Lot[]> dictionary2 = (from lot in array
			group lot by lot.Processnodeid).ToDictionary((IGrouping<string, Lot> g) => g.Key, (IGrouping<string, Lot> g) => g.ToArray());
		if (dictionary2.Count > 1)
		{
			throw new InvalidNotSameProcessnodeException(typeof(Lot), dictionary2.Keys.ToArray());
		}
		foreach (Lot inputLot in lotList)
		{
			Lot lot2 = array.Where((Lot lot) => lot.Lotid == inputLot.Lotid && lot.Siteid == inputLot.Siteid).FirstOrDefault();
			UpdateUserColumns(text, inputLot, lot2);
			inputLot.CopyCommonFieldUpdatePrev(lot2, systemTime, tid, text);
			inputLot.CopyExtensionCollection(lot2);
			list.Add(lot2);
		}
		ParamChecker.ArgumentNotNull("Carrierid", carrier.Carrierid);
		ParamChecker.ArgumentNotNull("Siteid", carrier.Siteid);
		string carrierid = carrier.Carrierid;
		Carrier carrier2 = CARRIER.SelectCarrier(dbContext, carrierid, carrier.Siteid);
		if (carrier2 == null)
		{
			throw new EntityNotFoundException(typeof(Carrier), carrierid);
		}
		if (carrier.Assignqty.HasValue && !(carrier2.Assignqty == carrier.Assignqty))
		{
			carrier2.Assignqty = carrier.Assignqty;
		}
		if (carrier.Loadstate != null && carrier2.Loadstate != carrier.Loadstate)
		{
			carrier2.Loadstate = carrier.Loadstate;
		}
		carrier.CopyCommonFieldUpdatePrev(carrier2, systemTime, tid, text);
		carrier.CopyExtensionCollection(carrier2);
		list2.Add(carrier2);
		foreach (Lotcarrierrel inputLotcarrierrel in lotcarrierrelList)
		{
			ParamChecker.ArgumentNotNull("Lotid", inputLotcarrierrel.Lotid);
			ParamChecker.ArgumentNotNull("Carrierid", inputLotcarrierrel.Carrierid);
			ParamChecker.ArgumentNotNull("Slotposition", inputLotcarrierrel.Slotposition);
			ParamChecker.ArgumentNotNull("Siteid", inputLotcarrierrel.Siteid);
			string lotid = inputLotcarrierrel.Lotid;
			string carrierid2 = inputLotcarrierrel.Carrierid;
			int slotposition = inputLotcarrierrel.Slotposition;
			if (!carrierid.Equals(inputLotcarrierrel.Carrierid))
			{
				throw new ObjectComparedInvalidException("Carrierid", carrierid, inputLotcarrierrel.Carrierid);
			}
			if (!siteid.Equals(inputLotcarrierrel.Siteid))
			{
				throw new ObjectComparedInvalidException("Siteid", siteid, inputLotcarrierrel.Siteid);
			}
			if (lotList.Where((Lot lot) => lot.Lotid == inputLotcarrierrel.Lotid && lot.Siteid == inputLotcarrierrel.Siteid).FirstOrDefault() == null)
			{
				throw new InvalidAssignCarrierException(inputLotcarrierrel.Lotid, inputLotcarrierrel.Carrierid, inputLotcarrierrel.Slotposition);
			}
			Lotcarrierrel lotCarrierRel = LOTCARRIERREL.GetLotCarrierRel(dbContext, lotid, carrierid2, slotposition, siteid);
			bool flag = lotCarrierRel != null;
			Lotcarrierrel lotcarrierrel = new Lotcarrierrel();
			if (flag)
			{
				lotCarrierRel.CopyColumsTo(lotcarrierrel);
			}
			else
			{
				inputLotcarrierrel.CopyColumsTo(lotcarrierrel);
			}
			if (inputLotcarrierrel.Assignqty.HasValue && !(lotcarrierrel.Assignqty == inputLotcarrierrel.Assignqty))
			{
				lotcarrierrel.Assignqty = inputLotcarrierrel.Assignqty;
			}
			lotcarrierrel.Prevactivity = null;
			lotcarrierrel.Activity = "AssignLotToCarrier";
			lotcarrierrel.Isusable = "Usable";
			lotcarrierrel.Siteid = siteid;
			inputLotcarrierrel.CopyCommonField(lotcarrierrel, systemTime, tid, isCreate: true);
			lotcarrierrel.Customactivity = EntityHelper.FirstNotNull<string>(inputLotcarrierrel.Customactivity, lotcarrierrel.Activity);
			if (flag)
			{
				list3.Add(lotcarrierrel);
			}
			else
			{
				list4.Add(lotcarrierrel);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveLotHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveLotHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveCarrierHist);
		if (list3.Count > 0)
		{
			num += ContextManager.BulkUpdateEntityFullColumn(dbContext, list3[0], list3.ToArray(), null, saveLotCarrierrelHist);
		}
		if (list4.Count > 0)
		{
			num += ContextManager.BulkCreateEntityFullColumn(dbContext, list4.ToArray(), saveLotCarrierrelHist);
		}
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int AssignProducedMaterial(IDbContext dbContext, Lot lot, Producedmaterial[] inputProducedMaterialList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("lot", lot);
		ParamChecker.ArgumentNotNull("lot.Lotid", lot.Lotid);
		ParamChecker.ArgumentNotNull("lot.Siteid", lot.Siteid);
		ParamChecker.ArgumentNotNullAndHasElement("inputProducedMaterialList", inputProducedMaterialList);
		string text = "AssignProducedMaterial";
		int apiVersion = 1;
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		string tid = dbContext.Tid;
		string lotid = lot.Lotid;
		string siteid = lot.Siteid;
		Lot lot2;
		if ((lot2 = SelectLot4Update(dbContext, lotid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Lot), lotid);
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", lot2);
		}
		Producedmaterial[] array = PRODUCEDMATERIAL.SelectProducedMaterialList4Update(dbContext, inputProducedMaterialList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTid(tid, "Select4Update", $"Lotid={lot2.Lotid} ProducedMaterial Count={array.Length}");
		}
		if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot))
		{
			throw new EntityIsHoldException(typeof(Lot), lot.Lotid);
		}
		string[] countableProducedMaterialGradeIdList = getCountableProducedMaterialGradeIdList(dbContext, siteid);
		string[] countableSubproducedMaterialGradeIdList = getCountableSubproducedMaterialGradeIdList(dbContext, siteid);
		foreach (Producedmaterial producedmaterial in inputProducedMaterialList)
		{
			string producedmaterialid = producedmaterial.Producedmaterialid;
			Producedmaterial producedmaterial2 = null;
			if ((producedmaterial2 = PRODUCEDMATERIAL.FindProducedMaterial(array, producedmaterialid)) == null)
			{
				throw new EntityNotFoundException(typeof(Producedmaterial), producedmaterialid);
			}
			if (!PRODUCEDMATERIAL.ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, producedmaterial2))
			{
				throw new EntityIsHoldException(typeof(Producedmaterial), producedmaterial.Producedmaterialid);
			}
			if (string.IsNullOrEmpty(producedmaterial2.Lotid))
			{
				producedmaterial2.Prevlotid = producedmaterial2.Lotid;
				producedmaterial2.Lotid = lotid;
			}
			else if (producedmaterial2.Lotid != lotid)
			{
				throw new ProducedMaterialOfDifferentLotException(producedmaterialid, producedmaterial2.Lotid);
			}
			producedmaterial2.Productorderid = producedmaterial.Productorderid;
			producedmaterial2.Workorderid = producedmaterial.Workorderid;
			if (producedmaterial2.Location != producedmaterial.Location)
			{
				producedmaterial2.Prevlocation = producedmaterial2.Location;
				producedmaterial2.Location = producedmaterial.Location;
			}
			if (producedmaterial2.Equipmentid != producedmaterial.Equipmentid)
			{
				producedmaterial2.Prevequipmentid = producedmaterial2.Equipmentid;
				producedmaterial2.Equipmentid = producedmaterial.Equipmentid;
			}
			PRODUCEDMATERIAL.InheritLotProcessInfo(lot2, producedmaterial2);
			producedmaterial.CopyCommonFieldUpdatePrev(producedmaterial2, systemTime, tid, text);
			producedmaterial.CopyExtensionCollection(producedmaterial2);
			list2.Add(producedmaterial2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={producedmaterial2.Producedmaterialid} Prevlotid={producedmaterial2.Prevlotid} Lotid={producedmaterial2.Lotid}");
			}
		}
		decimal lotQty = GetLotQty(dbContext, countableProducedMaterialGradeIdList, array.ToArray());
		decimal subProducedMaterialQty = GetSubProducedMaterialQty(dbContext, countableSubproducedMaterialGradeIdList, array.ToArray());
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "CalcQty", $"Lotid={lot2.Lotid} Change Qty={lotQty} Submaterialqty={subProducedMaterialQty}");
		}
		lot2.Prevqty = lot2.Qty;
		lot2.Qty = lot2.Qty.Add(lotQty);
		lot2.Prevsubmaterialqty = lot2.Submaterialqty;
		lot2.Submaterialqty = lot2.Submaterialqty.Add(subProducedMaterialQty);
		lot.CopyCommonFieldUpdatePrev(lot2, systemTime, tid, text);
		lot.CopyExtensionCollection(lot2);
		list.Add(lot2);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", lot2);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int CancelConvertLotToMaterialLot(IDbContext dbContext, Materiallot[] materialLotList, Lot[] lotList, CancelConvertLotMaterialLotBulkOptionSet optionSet, bool saveLotHist, bool saveMaterialLotHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		object[] objectList = materialLotList;
		ParamChecker.ArgumentNotNull("materialLotList", objectList);
		objectList = lotList;
		ParamChecker.ArgumentNotNull("lotList", objectList);
		objectList = lotList;
		object[] arr = objectList;
		objectList = materialLotList;
		ParamChecker.ArraySameLength(arr, objectList);
		string text = "CancelConvertLotToMaterialLot";
		int apiVersion = 1;
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		int num = 0;
		string[] bulkColumnList = optionSet?.BulkColumnList;
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		List<Materiallot> list = new List<Materiallot>();
		List<Lot> list2 = new List<Lot>();
		for (int i = 0; i < materialLotList.Length; i++)
		{
			Lot lot = lotList[i];
			Materiallot materiallot = materialLotList[i];
			ParamChecker.ArgumentNotNull("Lotid", lot.Lotid);
			ParamChecker.ArgumentNotNull("Siteid", lot.Siteid);
			ParamChecker.ArgumentNotNull("Materialotid", materiallot.Materiallotid);
			ParamChecker.ArgumentNotNull("Materialdefinitionid", materiallot.Materialdefinitionid);
			string lotid = lot.Lotid;
			string siteid = lot.Siteid;
			string materiallotid = materiallot.Materiallotid;
			_ = materiallot.Materialdefinitionid;
			Lot lot2 = null;
			Materiallot materiallot2 = null;
			if ((lot2 = SelectLot4Update(dbContext, lotid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lot), lotid);
			}
			ParamChecker.EntityValidState(typeof(Lot), lot2.Lotid, lot2.State, "Converted");
			if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot2))
			{
				throw new EntityIsHoldException(typeof(Lot), lotid);
			}
			if ((materiallot2 = MATERIALLOT.SelectMaterialLot4Update(dbContext, materiallotid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Materiallot), materiallotid);
			}
			ParamChecker.EntityValidState(typeof(Materiallot), materiallot2.Materiallotid, materiallot2.State, "Active");
			if (lot2.Lotid != materiallot2.Materiallotid)
			{
				throw new EntityInfomationDiffException("LOTID", lot2.Lotid, materiallot2.Materiallotid);
			}
			if (lot2.Productdefinitionid != materiallot2.Materialdefinitionid)
			{
				throw new EntityInfomationDiffException("PRODUCTDEFINITIONID", lot2.Productdefinitionid, materiallot2.Materialdefinitionid);
			}
			if (lot2.Location != materiallot2.Location)
			{
				throw new EntityInfomationDiffException("LOCATION", lot2.Location, materiallot2.Location);
			}
			if (!(lot2.Qty == materiallot2.Qty))
			{
				throw new EntityInfomationDiffException("QTY", lot2.Qty?.ToString(), materiallot2.Qty?.ToString());
			}
			materiallot2.Prevstate = materiallot2.State;
			materiallot2.State = "Terminated";
			materiallot2.CopyCommonFieldUpdatePrev(lot2, systemTime, dbContext.Tid, text);
			materiallot.CopyExtensionCollection(materiallot2);
			list.Add(materiallot2);
			lot2.State = lot2.Prevstate;
			lot.CopyCommonFieldUpdatePrev(lot2, systemTime, dbContext.Tid, text);
			lot.CopyExtensionCollection(lot2);
			list2.Add(lot2);
		}
		num += ContextManager.BulkUpdateEntityFullColumn(dbContext, list[0], list.ToArray(), bulkColumnList, saveMaterialLotHist);
		num += ContextManager.BulkUpdateEntityFullColumn(dbContext, list2[0], list2.ToArray(), bulkColumnList, saveLotHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int CancelConvertLotToMaterialLotBulk(IDbContext dbContext, Materiallot[] materialLotList, Lot[] lotList, IOptionSet optionSet, bool saveLotHist, bool saveMaterialLotHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		object[] objectList = materialLotList;
		ParamChecker.ArgumentNotNull("materialLotList", objectList);
		objectList = lotList;
		ParamChecker.ArgumentNotNull("lotList", objectList);
		objectList = lotList;
		object[] arr = objectList;
		objectList = materialLotList;
		ParamChecker.ArraySameLength(arr, objectList);
		string text = "CancelConvertLotToMaterialLot";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		int num = 0;
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		string siteid = lotList[0].Siteid;
		string[] first = ExtractIdOrderBy(lotList);
		ExtractIdOrderBy(materialLotList);
		new List<Materiallot>();
		new List<Lot>();
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		if (lotList.Length > array.Length)
		{
			throw new EntityNotFoundException(typeof(Lot), first.Except(ExtractIdOrderBy(array)).ToString());
		}
		if (!ValidateAllowHoldLotBulk(dbContext, text, apiVersion, array))
		{
			Lot[] lotList2 = array.Where((Lot v) => v.Ishold == "Y").ToArray();
			throw new EntityIsHoldException(typeof(Lot), EntityHelper.ConcatString4InClause(ExtractIdOrderBy(lotList2)));
		}
		Materiallot[] array2 = MATERIALLOT.SelectMaterialLotList4Update(dbContext, materialLotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "SelectMaterialLotList4Update", $"MaterialLotList Count={array2.Length}");
		}
		if (materialLotList.Length != array2.Length)
		{
			throw new EntityNotFoundException(typeof(Lot), first.Except(ExtractIdOrderBy(array2)).ToString());
		}
		for (int i = 0; i < array2.Length; i++)
		{
			if (array[i].Lotid != array2[i].Materiallotid)
			{
				throw new EntityInfomationDiffException("LOTID", array[i].Lotid, array2[i].Materiallotid);
			}
			if (array[i].Productdefinitionid != array2[i].Materialdefinitionid)
			{
				throw new EntityInfomationDiffException("PRODUCTDEFINITIONID", array[i].Productdefinitionid, array2[i].Materialdefinitionid);
			}
			if (!(array[i].Qty == array2[i].Qty))
			{
				throw new EntityInfomationDiffException("QTY", array[i].Qty?.ToString(), array2[i].Qty?.ToString());
			}
		}
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", ConvertLotToMaterialLotBulk(array));
		}
		Lot lot = lotList[0];
		Materiallot materiallot = materialLotList[0];
		ParamChecker.ArgumentNotNull("Lotid", lot.Lotid);
		ParamChecker.ArgumentNotNull("Siteid", lot.Siteid);
		ParamChecker.ArgumentNotNull("Materiallotid", materiallot.Materiallotid);
		string lotid = lot.Lotid;
		string materiallotid = materiallot.Materiallotid;
		Lot lot2 = null;
		Materiallot materiallot2 = null;
		if ((lot2 = SelectLot4Update(dbContext, lotid, lot.Siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Lot), lotid);
		}
		ParamChecker.EntityValidState(typeof(Lot), lot2.Lotid, lot2.State, "Converted");
		if ((materiallot2 = MATERIALLOT.SelectMaterialLot4Update(dbContext, materiallotid, materiallot.Siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Materiallot), materiallotid);
		}
		if (lot2.Lotid != materiallot2.Materiallotid)
		{
			throw new EntityInfomationDiffException("LOTID", lot2.Lotid, materiallot2.Materiallotid);
		}
		if (lot2.Productdefinitionid != materiallot2.Materialdefinitionid)
		{
			throw new EntityInfomationDiffException("PRODUCTDEFINITIONID", lot2.Productdefinitionid, materiallot2.Materialdefinitionid);
		}
		if (!(lot2.Qty == materiallot2.Qty))
		{
			throw new EntityInfomationDiffException("QTY", lot2.Qty?.ToString(), materiallot2.Qty?.ToString());
		}
		materiallot2.Prevstate = materiallot2.State;
		materiallot2.State = "Terminated";
		materiallot2.CopyCommonFieldUpdatePrev(materiallot2, systemTime, dbContext.Tid, text);
		materiallot.CopyExtensionCollection(materiallot2);
		lot2.Prevstate = lot2.State;
		lot2.State = "Finished";
		lot.CopyCommonFieldUpdatePrev(lot2, systemTime, dbContext.Tid, text);
		lot.CopyExtensionCollection(lot2);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, array2.ToArray(), saveMaterialLotHist);
		num += ContextManager.BulkUpdateEntityFullColumn(dbContext, lot2, array, null, saveLotHist);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", ConvertLotToMaterialLotBulk(array));
		}
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	internal static string CancelConvertLotToMaterialLotBulk(Materiallot[] materialLot)
	{
		return string.Format(_formatConvertLotToMaterialLotBulk, EntityHelper.ConcatString4InClause(ExtractIdOrderBy(materialLot)), EntityHelper.ConcatString4InClause((from p in materialLot
			select p.Materiallotid into id
			orderby id
			select id).ToArray()), EntityHelper.ConcatString4InClause((from p in materialLot
			select p.Materialdefinitionid into id
			orderby id
			select id).ToArray()), EntityHelper.ConcatString4InClause((from p in materialLot
			select p.Location into id
			orderby id
			select id).ToArray()), EntityHelper.ConcatString4InClause((from p in materialLot
			select p.Qty.ToString() into id
			orderby id
			select id).ToArray()));
	}

	public static int CancelFinishLot(IDbContext dbContext, Lot[] lotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotList", lotList);
		string text = "CancelFinishLot";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		string tid = dbContext.Tid;
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		string siteid = lotList[0].Siteid;
		List<Producedmaterial> list3 = new List<Producedmaterial>();
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		Lot[] array2 = array;
		foreach (Lot lot in array2)
		{
			Producedmaterial[] array3 = PRODUCEDMATERIAL.SelectProducedMaterialListByLotWithState4Update(dbContext, lot.Lotid, new string[1] { "Finished" }, siteid).ToArray();
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lot.Lotid} ProducedMaterial Count={array3.Length}");
			}
			list3.AddRange(array3);
		}
		array2 = lotList;
		foreach (Lot lot2 in array2)
		{
			ParamChecker.ArgumentNotNull("Lotid", lot2.Lotid);
			ParamChecker.ArgumentNotNull("Siteid", lot2.Siteid);
			string lotid = lot2.Lotid;
			string text2 = null;
			Lot lot3 = null;
			if ((lot3 = FindLot(array, lotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lot), lotid);
			}
			ParamChecker.EntityValidState(typeof(Lot), lotid, lot3.State, "Finished");
			text2 = lot3.Tid;
			MesLogger.InfoTidApi(tid, "Cancel Tid", text2);
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", lot3);
			}
			string prevstate = lot3.Prevstate;
			lot3.Prevstate = lot3.State;
			lot3.State = prevstate;
			lot2.CopyCommonFieldUpdatePrev(lot3, systemTime, tid, text);
			lot2.CopyExtensionCollection(lot3);
			list.Add(lot3);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", lot3);
			}
			foreach (Producedmaterial item in PRODUCEDMATERIAL.FindProducedMaterialList(list3.ToArray(), lotid))
			{
				string producedmaterialid = item.Producedmaterialid;
				if (item.Tid != text2)
				{
					MesLogger.InfoTidApi(tid, "Skip Cancel", $"Producedmaterialid={producedmaterialid} Tid={item.Tid} is different from Lot");
					continue;
				}
				ParamChecker.EntityValidState(typeof(Producedmaterial), item.Producedmaterialid, item.State, "Finished");
				ParamChecker.EntityUsable(typeof(Producedmaterial), item.Producedmaterialid, item.Isusable);
				if (MesLogger.IsDebugEnabled("API"))
				{
					MesLogger.DebugTidApi(tid, "Before Execute", item);
				}
				string prevstate2 = item.Prevstate;
				item.Prevstate = item.State;
				item.State = prevstate2;
				lot2.CopyCommonFieldUpdatePrev(item, systemTime, tid, text);
				list2.Add(item);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Execute", item);
				}
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int CancelFinishLot(IDbContext dbContext, Lot inputLot, Producedmaterial[] producedMaterialList, IOptionSet optionSet, bool saveHist)
	{
		string text = "CancelFinishLot";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("lot", inputLot);
		ParamChecker.ArgumentNotNull("Lotid", inputLot.Lotid);
		ParamChecker.ArgumentNotNull("Siteid", inputLot.Siteid);
		ParamChecker.ArgumentNotNullAndHasElement("producedMaterialList", producedMaterialList);
		string tid = dbContext.Tid;
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		string lotid = inputLot.Lotid;
		string siteid = inputLot.Siteid;
		Lot lot;
		if ((lot = SelectLot4Update(dbContext, lotid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Lot), lotid);
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", lot);
		}
		Producedmaterial[] array = PRODUCEDMATERIAL.SelectProducedMaterialList4Update(dbContext, producedMaterialList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lotid} ProducedMaterial Count={array.Length}");
		}
		ParamChecker.EntityValidState(typeof(Lot), lotid, lot.State, "Finished");
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", lot);
		}
		string prevstate = lot.Prevstate;
		lot.Prevstate = lot.State;
		lot.State = prevstate;
		inputLot.CopyCommonFieldUpdatePrev(lot, systemTime, tid, text);
		inputLot.CopyExtensionCollection(lot);
		list.Add(lot);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", lot);
		}
		foreach (Producedmaterial producedmaterial in producedMaterialList)
		{
			string producedmaterialid = producedmaterial.Producedmaterialid;
			Producedmaterial producedmaterial2;
			if ((producedmaterial2 = PRODUCEDMATERIAL.FindProducedMaterial(array, producedmaterialid)) == null)
			{
				throw new EntityNotFoundException(typeof(Producedmaterial), producedmaterialid);
			}
			ParamChecker.EntityValidState(typeof(Producedmaterial), producedmaterialid, producedmaterial2.State, "Finished");
			ParamChecker.EntityUsable(typeof(Producedmaterial), producedmaterialid, producedmaterial2.Isusable);
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", producedmaterial2);
			}
			string prevstate2 = producedmaterial2.Prevstate;
			producedmaterial2.Prevstate = producedmaterial2.State;
			producedmaterial2.State = prevstate2;
			producedmaterial.CopyCommonFieldUpdatePrev(producedmaterial2, systemTime, tid, text);
			producedmaterial.CopyExtensionCollection(producedmaterial2);
			list2.Add(producedmaterial2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", producedmaterial2);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int CancelScrapLot(IDbContext dbContext, Lot[] lotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotList", lotList);
		string text = "CancelScrapLot";
		string tid = dbContext.Tid;
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		string siteid = lotList[0].Siteid;
		List<Producedmaterial> list3 = new List<Producedmaterial>();
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		Lot[] array2 = array;
		foreach (Lot lot in array2)
		{
			Producedmaterial[] array3 = PRODUCEDMATERIAL.SelectProducedMaterialListByLotWithState4Update(dbContext, lot.Lotid, new string[1] { "Scrapped" }, siteid).ToArray();
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lot.Lotid} ProducedMaterial Count={array3.Length}");
			}
			list3.AddRange(array3);
		}
		array2 = lotList;
		foreach (Lot lot2 in array2)
		{
			ParamChecker.ArgumentNotNull("Lotid", lot2.Lotid);
			ParamChecker.ArgumentNotNull("Siteid", lot2.Siteid);
			string lotid = lot2.Lotid;
			string text2 = null;
			Lot lot3 = null;
			if ((lot3 = FindLot(array, lotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lot), lotid);
			}
			ParamChecker.EntityValidState(typeof(Lot), lotid, lot3.State, "Scrapped");
			text2 = lot3.Tid;
			MesLogger.InfoTidApi(tid, "Cancel Tid", text2);
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", lot3);
			}
			decimal? prevqty = lot3.Prevqty;
			decimal? prevsubmaterialqty = lot3.Prevsubmaterialqty;
			lot3.Prevqty = lot3.Qty;
			lot3.Qty = prevqty;
			lot3.Prevsubmaterialqty = lot3.Submaterialqty;
			lot3.Submaterialqty = prevsubmaterialqty;
			decimal? prevlossqty = lot3.Prevlossqty;
			lot3.Prevlossqty = lot3.Lossqty;
			lot3.Lossqty = prevlossqty;
			string prevstate = lot3.Prevstate;
			lot3.Prevstate = lot3.State;
			lot3.State = prevstate;
			lot2.CopyCommonFieldUpdatePrev(lot3, systemTime, tid, text);
			lot2.CopyExtensionCollection(lot3);
			list.Add(lot3);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", lot3);
			}
			foreach (Producedmaterial item in PRODUCEDMATERIAL.FindProducedMaterialList(list3.ToArray(), lotid))
			{
				string producedmaterialid = item.Producedmaterialid;
				if (item.Tid != text2)
				{
					MesLogger.InfoTidApi(tid, "Skip Cancel", $"Producedmaterialid={producedmaterialid} Tid={item.Tid} is different from Lot");
					continue;
				}
				ParamChecker.EntityValidState(typeof(Producedmaterial), item.Producedmaterialid, item.State, "Scrapped");
				ParamChecker.EntityUsable(typeof(Producedmaterial), item.Producedmaterialid, item.Isusable);
				if (MesLogger.IsDebugEnabled("API"))
				{
					MesLogger.DebugTidApi(tid, "Before Execute", item);
				}
				string prevstate2 = item.Prevstate;
				item.Prevstate = item.State;
				item.State = prevstate2;
				lot2.CopyCommonFieldUpdatePrev(item, systemTime, tid, text);
				list2.Add(item);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Execute", item);
				}
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int CancelScrapLot(IDbContext dbContext, Lot inputLot, Producedmaterial[] producedMaterialList, IOptionSet optionSet, bool saveHist)
	{
		string text = "CancelScrapLot";
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		ParamChecker.ArgumentNotNull("inputLot", inputLot);
		ParamChecker.ArgumentNotNull("Lotid", inputLot.Lotid);
		ParamChecker.ArgumentNotNull("Siteid", inputLot.Siteid);
		ParamChecker.ArgumentNotNullAndHasElement("producedMaterialList", producedMaterialList);
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		string lotid = inputLot.Lotid;
		string siteid = inputLot.Siteid;
		Lot lot = null;
		if ((lot = SelectLot4Update(dbContext, lotid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Lot), lotid);
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", lot);
		}
		Producedmaterial[] array = PRODUCEDMATERIAL.SelectProducedMaterialList4Update(dbContext, producedMaterialList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lot.Lotid} ProducedMaterial Count={array.Length}");
		}
		string[] countableProducedMaterialGradeIdList = getCountableProducedMaterialGradeIdList(dbContext, siteid);
		string[] countableSubproducedMaterialGradeIdList = getCountableSubproducedMaterialGradeIdList(dbContext, siteid);
		foreach (Producedmaterial producedmaterial in producedMaterialList)
		{
			ParamChecker.ArgumentNotNull("Lotid", producedmaterial.Lotid);
			ParamChecker.ArgumentNotNull("Siteid", producedmaterial.Siteid);
			ParamChecker.ArgumentNotNull("Producedmaterialid", producedmaterial.Producedmaterialid);
			string producedmaterialid = producedmaterial.Producedmaterialid;
			Producedmaterial producedmaterial2 = null;
			if ((producedmaterial2 = PRODUCEDMATERIAL.FindProducedMaterial(array, producedmaterialid)) == null)
			{
				throw new EntityNotFoundException(typeof(Producedmaterial), producedmaterialid);
			}
			ParamChecker.EntityValidState(typeof(Producedmaterial), producedmaterialid, producedmaterial2.State, "Scrapped");
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", $"Producedmaterialid={producedmaterial2.Producedmaterialid} Prevstate={producedmaterial2.Prevstate} State={producedmaterial2.State} Prevcarrierid={producedmaterial2.Prevcarrierid} Carrierid={producedmaterial2.Carrierid} Prevslotno={producedmaterial2.Prevslotno} Slotno={producedmaterial2.Slotno}");
			}
			string prevstate = producedmaterial2.Prevstate;
			producedmaterial2.Prevstate = producedmaterial2.State;
			producedmaterial2.State = prevstate;
			producedmaterial2.Prevslotno = producedmaterial2.Slotno;
			producedmaterial2.Slotno = producedmaterial.Slotno;
			producedmaterial2.Prevcarrierid = producedmaterial2.Carrierid;
			producedmaterial2.Carrierid = producedmaterial.Carrierid;
			producedmaterial.CopyCommonFieldUpdatePrev(producedmaterial2, systemTime, tid, text);
			producedmaterial.CopyExtensionCollection(producedmaterial2);
			list2.Add(producedmaterial2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={producedmaterial2.Producedmaterialid} Prevcarrierid={producedmaterial2.Prevcarrierid} Carrierid={producedmaterial2.Carrierid} Prevslotno={producedmaterial2.Prevslotno} Slotno={producedmaterial2.Slotno}");
			}
		}
		ParamChecker.EntityValidState(typeof(Lot), lotid, lot.State, "Scrapped", "Active", "Created");
		decimal lotQty = GetLotQty(dbContext, countableProducedMaterialGradeIdList, list2.ToArray());
		decimal subProducedMaterialQty = GetSubProducedMaterialQty(dbContext, countableSubproducedMaterialGradeIdList, list2.ToArray());
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "CalcQty", $"Lotid={lot.Lotid} Change Qty={lotQty} Submaterialqty={subProducedMaterialQty}");
		}
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", lot);
		}
		if (lot.State == "Scrapped")
		{
			string prevstate2 = lot.Prevstate;
			lot.Prevstate = lot.State;
			lot.State = prevstate2;
		}
		lot.Prevqty = lot.Qty;
		lot.Qty = lot.Qty.Add(lotQty);
		lot.Prevsubmaterialqty = lot.Submaterialqty;
		lot.Submaterialqty = lot.Submaterialqty.Add(subProducedMaterialQty);
		lot.Prevlossqty = lot.Lossqty;
		lot.Lossqty = lot.Lossqty.Add(-lotQty);
		inputLot.CopyCommonFieldUpdatePrev(lot, systemTime, tid, text);
		inputLot.CopyExtensionCollection(lot);
		list.Add(lot);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", lot);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int CancelShipLot(IDbContext dbContext, Lot[] lotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotList", lotList);
		string text = "CancelShipLot";
		string tid = dbContext.Tid;
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		string siteid = lotList[0].Siteid;
		List<Producedmaterial> list3 = new List<Producedmaterial>();
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		Lot[] array2 = array;
		foreach (Lot lot in array2)
		{
			Producedmaterial[] array3 = PRODUCEDMATERIAL.SelectProducedMaterialListByLotWithState4Update(dbContext, lot.Lotid, new string[1] { "Shipped" }, siteid).ToArray();
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lot.Lotid} ProducedMaterial Count={array3.Length}");
			}
			list3.AddRange(array3);
		}
		array2 = lotList;
		foreach (Lot lot2 in array2)
		{
			ParamChecker.ArgumentNotNull("Lotid", lot2.Lotid);
			ParamChecker.ArgumentNotNull("Siteid", lot2.Siteid);
			string lotid = lot2.Lotid;
			string text2 = null;
			Lot lot3 = null;
			if ((lot3 = FindLot(array, lotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lot), lotid);
			}
			ParamChecker.EntityValidState(typeof(Lot), lotid, lot3.State, "Shipped");
			text2 = lot3.Tid;
			MesLogger.InfoTidApi(tid, "Cancel Tid", text2);
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", lot3);
			}
			string prevstate = lot3.Prevstate;
			lot3.Prevstate = lot3.State;
			lot3.State = prevstate;
			lot2.CopyCommonFieldUpdatePrev(lot3, systemTime, tid, text);
			lot2.CopyExtensionCollection(lot3);
			list.Add(lot3);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", lot3);
			}
			foreach (Producedmaterial item in PRODUCEDMATERIAL.FindProducedMaterialList(list3.ToArray(), lotid))
			{
				string producedmaterialid = item.Producedmaterialid;
				if (item.Tid != text2)
				{
					MesLogger.InfoTidApi(tid, "Skip Cancel", $"Producedmaterialid={producedmaterialid} Tid={item.Tid} is different from Lot");
					continue;
				}
				ParamChecker.EntityValidState(typeof(Producedmaterial), item.Producedmaterialid, item.State, "Shipped");
				ParamChecker.EntityUsable(typeof(Producedmaterial), item.Producedmaterialid, item.Isusable);
				if (MesLogger.IsDebugEnabled("API"))
				{
					MesLogger.DebugTidApi(tid, "Before Execute", item);
				}
				string prevstate2 = item.Prevstate;
				item.Prevstate = item.State;
				item.State = prevstate2;
				lot2.CopyCommonFieldUpdatePrev(item, systemTime, tid, text);
				list2.Add(item);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Execute", item);
				}
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int CancelStartLot(IDbContext dbContext, Lot[] lotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("lotList", lotList);
		string text = "CancelStartLot";
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		string siteid = lotList[0].Siteid;
		List<Producedmaterial> list3 = new List<Producedmaterial>();
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		Lot[] array2 = array;
		foreach (Lot lot in array2)
		{
			Producedmaterial[] array3 = PRODUCEDMATERIAL.SelectProducedMaterialListByLotWithState4Update(dbContext, lot.Lotid, new string[1] { "Active" }, siteid).ToArray();
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lot.Lotid} ProducedMaterial Count={array3.Length}");
			}
			list3.AddRange(array3);
		}
		array2 = lotList;
		foreach (Lot lot2 in array2)
		{
			ParamChecker.ArgumentNotNull("Lotid", lot2.Lotid);
			ParamChecker.ArgumentNotNull("Siteid", lot2.Siteid);
			string lotid = lot2.Lotid;
			string text2 = null;
			Lot lot3 = null;
			if ((lot3 = FindLot(array, lotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lot), lotid);
			}
			ParamChecker.EntityValidState(typeof(Lot), lotid, lot3.State, "Active");
			text2 = lot3.Tid;
			MesLogger.InfoTidApi(tid, "Cancel Tid", text2);
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", lot3);
			}
			string prevstate = lot3.Prevstate;
			lot3.Prevstate = lot3.State;
			lot3.State = prevstate;
			lot3.Processingstate = null;
			lot3.Prevsubprocessdefinitionid = lot3.Subprocessdefinitionid;
			lot3.Subprocessdefinitionid = null;
			lot3.Prevprocesssegmentid = lot3.Processsegmentid;
			lot3.Processsegmentid = null;
			lot3.Prevprocessnodeid = lot3.Processnodeid;
			lot3.Processnodeid = null;
			lot3.Processsegmentruleid = null;
			lot3.Rulesequence = null;
			lot2.CopyCommonFieldUpdatePrev(lot3, systemTime, tid, text);
			lot2.CopyExtensionCollection(lot3);
			list.Add(lot3);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", lot3);
			}
			foreach (Producedmaterial item in PRODUCEDMATERIAL.FindProducedMaterialList(list3.ToArray(), lotid))
			{
				string producedmaterialid = item.Producedmaterialid;
				if (item.Tid != text2)
				{
					MesLogger.InfoTidApi(tid, "Skip Cancel", $"Producedmaterialid={producedmaterialid} Tid={item.Tid} is different from Lot");
					continue;
				}
				ParamChecker.EntityValidState(typeof(Producedmaterial), item.Producedmaterialid, item.State, "Active");
				ParamChecker.EntityUsable(typeof(Producedmaterial), item.Producedmaterialid, item.Isusable);
				if (MesLogger.IsDebugEnabled("API"))
				{
					MesLogger.DebugTidApi(tid, "Before Execute", item);
				}
				string prevstate2 = item.Prevstate;
				item.Prevstate = item.State;
				item.State = prevstate2;
				PRODUCEDMATERIAL.InheritLotProcessInfo(lot3, item);
				lot2.CopyCommonFieldUpdatePrev(item, systemTime, tid, text);
				list2.Add(item);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Execute", item);
				}
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int CancelTerminateLot(IDbContext dbContext, Lot[] lotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotList", lotList);
		string text = "CancelTerminateLot";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		string siteid = lotList[0].Siteid;
		List<Producedmaterial> list3 = new List<Producedmaterial>();
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		Lot[] array2 = array;
		foreach (Lot lot in array2)
		{
			Producedmaterial[] array3 = PRODUCEDMATERIAL.SelectProducedMaterialListByLotWithState4Update(dbContext, lot.Lotid, new string[1] { "Terminated" }, siteid).ToArray();
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lot.Lotid} ProducedMaterial Count={array3.Length}");
			}
			list3.AddRange(array3);
		}
		array2 = lotList;
		foreach (Lot lot2 in array2)
		{
			ParamChecker.ArgumentNotNull("Lotid", lot2.Lotid);
			ParamChecker.ArgumentNotNull("Siteid", lot2.Siteid);
			string lotid = lot2.Lotid;
			string text2 = null;
			Lot lot3 = null;
			if ((lot3 = FindLot(array, lotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lot), lotid);
			}
			ParamChecker.EntityValidState(typeof(Lot), lotid, lot3.State, "Terminated");
			text2 = lot3.Tid;
			MesLogger.InfoTidApi(tid, "Cancel Tid", text2);
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", lot3);
			}
			decimal? prevqty = lot3.Prevqty;
			decimal? prevsubmaterialqty = lot3.Prevsubmaterialqty;
			lot3.Prevqty = lot3.Qty;
			lot3.Qty = prevqty;
			lot3.Prevsubmaterialqty = lot3.Submaterialqty;
			lot3.Submaterialqty = prevsubmaterialqty;
			string prevstate = lot3.Prevstate;
			lot3.Prevstate = lot3.State;
			lot3.State = prevstate;
			lot2.CopyCommonFieldUpdatePrev(lot3, systemTime, tid, text);
			lot2.CopyExtensionCollection(lot3);
			list.Add(lot3);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", lot3);
			}
			foreach (Producedmaterial item in PRODUCEDMATERIAL.FindProducedMaterialList(list3.ToArray(), lotid))
			{
				string producedmaterialid = item.Producedmaterialid;
				if (item.Tid != text2)
				{
					MesLogger.InfoTidApi(tid, "Skip Cancel", $"Producedmaterialid={producedmaterialid} Tid={item.Tid} is different from Lot");
					continue;
				}
				ParamChecker.EntityValidState(typeof(Producedmaterial), item.Producedmaterialid, item.State, "Terminated");
				ParamChecker.EntityUsable(typeof(Producedmaterial), item.Producedmaterialid, item.Isusable);
				if (MesLogger.IsDebugEnabled("API"))
				{
					MesLogger.DebugTidApi(tid, "Before Execute", item);
				}
				string prevstate2 = item.Prevstate;
				item.Prevstate = item.State;
				item.State = prevstate2;
				lot2.CopyCommonFieldUpdatePrev(item, systemTime, tid, text);
				list2.Add(item);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Execute", item);
				}
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int CancelTrackInLot(IDbContext dbContext, Lot[] lotList, CancelTrackInOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotList", lotList);
		string text = "CancelTrackInLot";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		string siteid = lotList[0].Siteid;
		List<Producedmaterial> list3 = new List<Producedmaterial>();
		bool flag = optionSet?.KeepEquipmentId ?? false;
		bool flag2 = optionSet?.KeepEquipmentId ?? false;
		bool flag3 = optionSet?.TrackingHistory ?? true;
		bool flag4 = optionSet?.KeepRepeatcount ?? false;
		_ = optionSet?.BulkColumnList;
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		Lot[] array2 = array;
		foreach (Lot lot in array2)
		{
			Producedmaterial[] array3 = PRODUCEDMATERIAL.SelectProducedMaterialListByLotWithState4Update(dbContext, lot.Lotid, new string[1] { "Active" }, siteid).ToArray();
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lot.Lotid} ProducedMaterial Count={array3.Length}");
			}
			list3.AddRange(array3);
		}
		array2 = lotList;
		foreach (Lot lot2 in array2)
		{
			ParamChecker.ArgumentNotNull("Lotid", lot2.Lotid);
			ParamChecker.ArgumentNotNull("Siteid", lot2.Siteid);
			string lotid = lot2.Lotid;
			string text2 = null;
			Lot lot3 = null;
			if ((lot3 = FindLot(array, lotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lot), lotid);
			}
			if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot3))
			{
				throw new EntityIsHoldException(typeof(Lot), lotid);
			}
			text2 = lot3.Tid;
			MesLogger.InfoTidApi(tid, "Cancel Tid", text2);
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", LogInfoTrackInOutLot(lot3));
			}
			string processsegmentid = lot3.Processsegmentid;
			int valueOrDefault = lot3.Rulesequence.GetValueOrDefault();
			Processsegmentruleclsrel processsegmentruleclsrel = PROCESSSEGMENTRULECLSREL.SelectPrevProcessSegmentRule(dbContext, processsegmentid, valueOrDefault, siteid);
			if (processsegmentruleclsrel == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentruleclsrel), processsegmentid + ":" + valueOrDefault);
			}
			Processsegmentrule processsegmentrule = PROCESSSEGMENTRULE.SelectProcessSegmentRule(dbContext, processsegmentruleclsrel.Processsegmentruleid, siteid);
			if (processsegmentrule == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentrule), processsegmentruleclsrel.Processsegmentruleid);
			}
			ParamChecker.EntityValidState(typeof(Processsegmentrule), "Systemruleid", processsegmentrule.Systemruleid, "TrackIn");
			if (!flag)
			{
				lot3.Equipmentid = null;
			}
			if (!flag2)
			{
				lot3.Portid = null;
			}
			if (!flag4)
			{
				if (!lot3.Repeatcount.HasValue || lot3.Repeatcount < 1)
				{
					lot3.Repeatcount = 0;
				}
				else
				{
					lot3.Repeatcount--;
				}
			}
			lot3.Trackintime = null;
			lot3.Trackinuser = null;
			if (processsegmentruleclsrel != null)
			{
				lot3.Processsegmentruleid = processsegmentruleclsrel.Processsegmentruleid;
				lot3.Rulesequence = processsegmentruleclsrel.Rulesequence;
				if (processsegmentruleclsrel.Isstart == "Y")
				{
					lot3.Processingstate = "WaitForRule";
				}
				else
				{
					lot3.Processingstate = "ProcessingRule";
				}
			}
			lot2.CopyCommonFieldUpdatePrev(lot3, systemTime, tid, text);
			lot2.CopyExtensionCollection(lot3);
			list.Add(lot3);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", LogInfoTrackInOutLot(lot3));
			}
			foreach (Producedmaterial item in PRODUCEDMATERIAL.FindProducedMaterialList(list3.ToArray(), lotid))
			{
				string producedmaterialid = item.Producedmaterialid;
				if (item.Tid != text2)
				{
					MesLogger.InfoTidApi(tid, "Skip Cancel", $"Producedmaterialid={producedmaterialid} Tid={item.Tid} is different from Lot");
					continue;
				}
				if (!PRODUCEDMATERIAL.ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, item))
				{
					throw new EntityIsHoldException(typeof(Producedmaterial), producedmaterialid);
				}
				if (MesLogger.IsDebugEnabled("API"))
				{
					MesLogger.DebugTidApi(tid, "Before Execute", LogInfoTrackInOutProducedMaterial(item));
				}
				PRODUCEDMATERIAL.InheritLotProcessInfo(lot3, item);
				lot2.CopyCommonFieldUpdatePrev(item, systemTime, tid, text);
				list2.Add(item);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Execute", LogInfoTrackInOutProducedMaterial(item));
				}
			}
			if (flag3)
			{
				num += LOTTRACKING.CancelTrackinLotTracking(dbContext, lot3);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int CancelTrackInLotBulk(IDbContext dbContext, Lot[] lotList, CancelTrackInOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotList", lotList);
		string text = "CancelTrackInLotBulk";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		string siteid = lotList[0].Siteid;
		List<Producedmaterial> list3 = new List<Producedmaterial>();
		bool flag = optionSet?.KeepEquipmentId ?? false;
		bool flag2 = optionSet?.KeepEquipmentId ?? false;
		bool flag3 = optionSet?.TrackingHistory ?? true;
		bool flag4 = optionSet?.KeepRepeatcount ?? false;
		string[] bulkColumnList = optionSet?.BulkColumnList;
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		Lot[] array2 = array;
		foreach (Lot lot in array2)
		{
			Producedmaterial[] array3 = PRODUCEDMATERIAL.SelectProducedMaterialListByLotWithState4Update(dbContext, lot.Lotid, new string[1] { "Active" }, siteid).ToArray();
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lot.Lotid} ProducedMaterial Count={array3.Length}");
			}
			list3.AddRange(array3);
		}
		array2 = lotList;
		foreach (Lot lot2 in array2)
		{
			ParamChecker.ArgumentNotNull("Lotid", lot2.Lotid);
			ParamChecker.ArgumentNotNull("Siteid", lot2.Siteid);
			string lotid = lot2.Lotid;
			string text2 = null;
			Lot lot3 = null;
			if ((lot3 = FindLot(array, lotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lot), lotid);
			}
			if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot3))
			{
				throw new EntityIsHoldException(typeof(Lot), lotid);
			}
			text2 = lot3.Tid;
			MesLogger.InfoTidApi(tid, "Cancel Tid", text2);
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", LogInfoTrackInOutLot(lot3));
			}
			string processsegmentid = lot3.Processsegmentid;
			int valueOrDefault = lot3.Rulesequence.GetValueOrDefault();
			Processsegmentruleclsrel processsegmentruleclsrel = PROCESSSEGMENTRULECLSREL.SelectPrevProcessSegmentRule(dbContext, processsegmentid, valueOrDefault, siteid);
			if (processsegmentruleclsrel == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentruleclsrel), processsegmentid + ":" + valueOrDefault);
			}
			Processsegmentrule processsegmentrule = PROCESSSEGMENTRULE.SelectProcessSegmentRule(dbContext, processsegmentruleclsrel.Processsegmentruleid, siteid);
			if (processsegmentrule == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentrule), processsegmentruleclsrel.Processsegmentruleid);
			}
			ParamChecker.EntityValidState(typeof(Processsegmentrule), "Systemruleid", processsegmentrule.Systemruleid, "TrackIn");
			if (!flag)
			{
				lot3.Equipmentid = null;
			}
			if (!flag2)
			{
				lot3.Portid = null;
			}
			if (!flag4)
			{
				if (!lot3.Repeatcount.HasValue || lot3.Repeatcount < 1)
				{
					lot3.Repeatcount = 0;
				}
				else
				{
					lot3.Repeatcount--;
				}
			}
			lot3.Trackintime = null;
			lot3.Trackinuser = null;
			if (processsegmentruleclsrel != null)
			{
				lot3.Processsegmentruleid = processsegmentruleclsrel.Processsegmentruleid;
				lot3.Rulesequence = processsegmentruleclsrel.Rulesequence;
				if (processsegmentruleclsrel.Isstart == "Y")
				{
					lot3.Processingstate = "WaitForRule";
				}
				else
				{
					lot3.Processingstate = "ProcessingRule";
				}
			}
			lot2.CopyCommonFieldUpdatePrev(lot3, systemTime, tid, text);
			lot2.CopyExtensionCollection(lot3);
			list.Add(lot3);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", LogInfoTrackInOutLot(lot3));
			}
			foreach (Producedmaterial item in PRODUCEDMATERIAL.FindProducedMaterialList(list3.ToArray(), lotid))
			{
				string producedmaterialid = item.Producedmaterialid;
				if (item.Tid != text2)
				{
					MesLogger.InfoTidApi(tid, "Skip Cancel", $"Producedmaterialid={producedmaterialid} Tid={item.Tid} is different from Lot");
					continue;
				}
				if (!PRODUCEDMATERIAL.ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, item))
				{
					throw new EntityIsHoldException(typeof(Producedmaterial), producedmaterialid);
				}
				if (MesLogger.IsDebugEnabled("API"))
				{
					MesLogger.DebugTidApi(tid, "Before Execute", LogInfoTrackInOutProducedMaterial(item));
				}
				PRODUCEDMATERIAL.InheritLotProcessInfo(lot3, item);
				lot2.CopyCommonFieldUpdatePrev(item, systemTime, tid, text);
				list2.Add(item);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Execute", LogInfoTrackInOutProducedMaterial(item));
				}
			}
			if (flag3)
			{
				num += LOTTRACKING.CancelTrackinLotTracking(dbContext, lot3);
			}
		}
		num += ContextManager.BulkUpdateEntityFullColumn(dbContext, list[0], list.ToArray(), bulkColumnList, saveHist);
		if (list2.Count > 0)
		{
			num += ContextManager.BulkUpdateEntityFullColumn(dbContext, list2[0], list2.ToArray(), bulkColumnList, saveHist);
		}
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int ChangeGradeLot(IDbContext dbContext, Lot[] lotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotList", lotList);
		string text = "ChangeGradeLot";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		string siteid = lotList[0].Siteid;
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		foreach (Lot lot in lotList)
		{
			ParamChecker.ArgumentNotNull("Lotid", lot.Lotid);
			ParamChecker.ArgumentNotNull("Siteid", lot.Siteid);
			ParamChecker.ArgumentNotNull("Grade", lot.Grade);
			string lotid = lot.Lotid;
			Lot lot2;
			if ((lot2 = FindLot(array, lotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lot), lotid);
			}
			if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot2))
			{
				throw new EntityIsHoldException(typeof(Lot), lotid);
			}
			lot2.Prevgrade = lot2.Grade;
			lot2.Grade = lot.Grade;
			lot.CopyCommonFieldUpdatePrev(lot2, systemTime, tid, text);
			lot.CopyExtensionCollection(lot2);
			list.Add(lot2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", lot2);
			}
		}
		if (list.Count > 0)
		{
			num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		}
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int ChangeGradeLot(IDbContext dbContext, Lot inputLot, Producedmaterial[] inputProducedMaterialList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("inputLot", inputLot);
		ParamChecker.ArgumentNotNullAndHasElement("inputProducedMaterialList", inputProducedMaterialList);
		string text = "ChangeGradeLot";
		int apiVersion = 2;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		int num = 0;
		ParamChecker.ArgumentNotNull("Lotid", inputLot.Lotid);
		ParamChecker.ArgumentNotNull("Siteid", inputLot.Siteid);
		ParamChecker.ArgumentNotNull("Grade", inputLot.Grade);
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		string lotid = inputLot.Lotid;
		string siteid = inputLot.Siteid;
		Lot lot;
		if ((lot = SelectLot4Update(dbContext, lotid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Lot), lotid);
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", lot);
		}
		Producedmaterial[] array = PRODUCEDMATERIAL.SelectProducedMaterialList4Update(dbContext, inputProducedMaterialList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lot.Lotid} ProducedMaterial Count={array.Length}");
		}
		if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot))
		{
			throw new EntityIsHoldException(typeof(Lot), lotid);
		}
		string[] countableProducedMaterialGradeIdList = getCountableProducedMaterialGradeIdList(dbContext, siteid);
		string[] countableSubproducedMaterialGradeIdList = getCountableSubproducedMaterialGradeIdList(dbContext, siteid);
		decimal lotQty = GetLotQty(dbContext, countableProducedMaterialGradeIdList, array.ToArray());
		decimal subProducedMaterialQty = GetSubProducedMaterialQty(dbContext, countableSubproducedMaterialGradeIdList, array.ToArray());
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "CalcQty", $"Lotid={lot.Lotid} Minus Qty={lotQty} Submaterialqty={subProducedMaterialQty}");
		}
		foreach (Producedmaterial producedmaterial in inputProducedMaterialList)
		{
			string producedmaterialid = producedmaterial.Producedmaterialid;
			ParamChecker.ArgumentNotNull("Producedmaterialid", producedmaterialid);
			Producedmaterial producedmaterial2;
			if ((producedmaterial2 = PRODUCEDMATERIAL.FindProducedMaterial(array.ToArray(), producedmaterialid)) == null)
			{
				throw new EntityNotFoundException(typeof(Producedmaterial), producedmaterialid);
			}
			if (!PRODUCEDMATERIAL.ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, producedmaterial2))
			{
				throw new EntityIsHoldException(typeof(Producedmaterial), producedmaterialid);
			}
			producedmaterial2.Prevgrade = producedmaterial2.Grade;
			producedmaterial2.Grade = producedmaterial.Grade;
			producedmaterial2.Prevsubmaterialgrade = producedmaterial2.Submaterialgrade;
			producedmaterial2.Submaterialgrade = producedmaterial.Submaterialgrade;
			producedmaterial2.Prevsubmaterialqty = producedmaterial2.Submaterialqty;
			producedmaterial2.Submaterialqty = PRODUCEDMATERIAL.GetSubProducedMaterialQty(dbContext, countableSubproducedMaterialGradeIdList, producedmaterial2);
			producedmaterial.CopyCommonFieldUpdatePrev(producedmaterial2, systemTime, tid, text);
			producedmaterial.CopyExtensionCollection(producedmaterial2);
			list2.Add(producedmaterial2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", producedmaterial2);
			}
		}
		decimal lotQty2 = GetLotQty(dbContext, countableProducedMaterialGradeIdList, array.ToArray());
		decimal subProducedMaterialQty2 = GetSubProducedMaterialQty(dbContext, countableSubproducedMaterialGradeIdList, array.ToArray());
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "CalcQty", $"Lotid={lot.Lotid} Plus Qty={lotQty2} Submaterialqty={subProducedMaterialQty2}");
		}
		decimal num2 = lotQty2 - lotQty;
		decimal num3 = subProducedMaterialQty2 - subProducedMaterialQty;
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "CalcQty", $"Lotid={lot.Lotid} Change Qty={num2} Submaterialqty={num3}");
		}
		lot.Prevgrade = lot.Grade;
		lot.Grade = inputLot.Grade;
		lot.Prevqty = lot.Qty;
		lot.Qty = lot.Qty.Add(num2);
		lot.Prevsubmaterialqty = lot.Submaterialqty;
		lot.Submaterialqty = lot.Submaterialqty.Add(num3);
		inputLot.CopyCommonFieldUpdatePrev(lot, systemTime, tid, text);
		inputLot.CopyExtensionCollection(lot);
		list.Add(lot);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", lot);
		}
		if (list.Count > 0)
		{
			num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		}
		if (list2.Count > 0)
		{
			num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHist);
		}
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int ChangeLotQty(IDbContext dbContext, Lot[] lotList, ChangeLotQtyOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotList", lotList);
		string text = "ChangeLotQty";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		bool flag = optionSet?.TerminateLotQtyZero ?? false;
		int num = 0;
		List<Lot> list = new List<Lot>();
		string siteid = lotList[0].Siteid;
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		foreach (Lot lot in lotList)
		{
			ParamChecker.ArgumentNotNull("Lotid", lot.Lotid);
			ParamChecker.ArgumentNotNull("Siteid", lot.Siteid);
			ParamChecker.ArgumentNotNull("Qty", lot.Qty);
			ParamChecker.ArgumentNotNull("Submaterialqty", lot.Submaterialqty);
			string lotid = lot.Lotid;
			Lot lot2;
			if ((lot2 = FindLot(array, lotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lot), lotid);
			}
			if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot2))
			{
				throw new EntityIsHoldException(typeof(Lot), lotid);
			}
			lot2.Prevqty = lot2.Qty;
			lot2.Qty = lot.Qty;
			lot2.Prevsubmaterialqty = lot2.Submaterialqty;
			lot2.Submaterialqty = lot.Submaterialqty;
			decimal? qty = lot2.Qty;
			if ((qty.GetValueOrDefault() < default(decimal)) & qty.HasValue)
			{
				throw new QuantityInvalidException(lot2.Lotid, lot2.Qty);
			}
			qty = lot2.Submaterialqty;
			if ((qty.GetValueOrDefault() < default(decimal)) & qty.HasValue)
			{
				throw new QuantityInvalidException(lot2.Lotid, lot2.Submaterialqty);
			}
			if (flag)
			{
				qty = lot2.Qty;
				if ((qty.GetValueOrDefault() == default(decimal)) & qty.HasValue)
				{
					lot2.Prevstate = lot2.State;
					lot2.State = "Terminated";
				}
			}
			lot.CopyCommonFieldUpdatePrev(lot2, systemTime, tid, text);
			lot.CopyExtensionCollection(lot2);
			list.Add(lot2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", lot2);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int ChangeLotState(IDbContext dbContext, Lot[] lotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("lotList", lotList);
		string text = "ChangeLotState";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		string siteid = lotList[0].Siteid;
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		foreach (Lot lot in lotList)
		{
			ParamChecker.ArgumentNotNull("Lotid", lot.Lotid);
			ParamChecker.ArgumentNotNull("State", lot.State);
			ParamChecker.ArgumentNotNull("Siteid", lot.Siteid);
			string lotid = lot.Lotid;
			string state = lot.State;
			Lot lot2 = null;
			if ((lot2 = FindLot(array, lotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lot), lotid);
			}
			if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot2))
			{
				throw new EntityIsHoldException(typeof(Lot), lotid);
			}
			if (STATE.SelectState(dbContext, typeof(LotState).Name, state, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(LotState), state);
			}
			lot2.Prevstate = lot2.State;
			lot2.State = state;
			lot.CopyCommonFieldUpdatePrev(lot2, systemTime, tid, text);
			lot.CopyExtensionCollection(lot2);
			list.Add(lot2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", $"Lotid={lot2.Lotid} Prevstate={lot2.Prevstate} State={lot2.State}");
			}
		}
		if (list.Count > 0)
		{
			num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		}
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int ChangeProductdefinitionLot(IDbContext dbContext, Lot[] lotList, ChangeProductdefinitionLotOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("lotList", lotList);
		string text = "ChangeProductdefinition";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		string siteid = lotList[0].Siteid;
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		foreach (Lot lot in lotList)
		{
			ParamChecker.ArgumentNotNull("Lotid", lot.Lotid);
			ParamChecker.ArgumentNotNull("State", lot.State);
			ParamChecker.ArgumentNotNull("Siteid", lot.Siteid);
			string lotid = lot.Lotid;
			string state = lot.State;
			Lot lot2 = null;
			if ((lot2 = FindLot(array, lotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lot), lotid);
			}
			if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot2))
			{
				throw new EntityIsHoldException(typeof(Lot), lotid);
			}
			if (STATE.SelectState(dbContext, typeof(LotState).Name, state, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(LotState), state);
			}
			lot2.Prevstate = lot2.State;
			lot2.State = state;
			lot.CopyCommonFieldUpdatePrev(lot2, systemTime, tid, text);
			lot.CopyExtensionCollection(lot2);
			list.Add(lot2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", $"Lotid={lot2.Lotid} Prevstate={lot2.Prevstate} State={lot2.State}");
			}
		}
		if (list.Count > 0)
		{
			num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		}
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int ConvertLotToLot(IDbContext dbContext, Lot[] lotList, Lot[] convertLotList, ConvertLotToLotOptionSet convertLotToLotOptionSet, bool saveLotHist, bool saveConvertLotHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		object[] objectList = lotList;
		ParamChecker.ArgumentNotNull("lotList", objectList);
		objectList = convertLotList;
		ParamChecker.ArgumentNotNull("convertLotList", objectList);
		objectList = lotList;
		object[] arr = objectList;
		objectList = convertLotList;
		ParamChecker.ArraySameLength(arr, objectList);
		string text = "ConvertLotToLot";
		int apiVersion = 1;
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		int num = 0;
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		bool flag = convertLotToLotOptionSet?.MoveToFirstSegment ?? false;
		bool flag2 = convertLotToLotOptionSet?.ProcessdefinitionWithoutState ?? false;
		List<Lot> list = new List<Lot>();
		List<Lot> list2 = new List<Lot>();
		foreach (Lot inputLot in lotList)
		{
			Lot lot2 = convertLotList.Where((Lot lot) => lot.Parentlotid == inputLot.Lotid && lot.Siteid == inputLot.Siteid).FirstOrDefault();
			ParamChecker.ArgumentNotNull("Lotid", inputLot.Lotid);
			ParamChecker.ArgumentNotNull("Siteid", inputLot.Siteid);
			ParamChecker.ArgumentNotNull("lotid", lot2?.Lotid);
			string lotid = inputLot.Lotid;
			string siteid = inputLot.Siteid;
			string lotid2 = lot2.Lotid;
			Lot lot3 = null;
			Processdefinition processdefinition = null;
			Processnode processnode = null;
			Processsegment processsegment = null;
			if ((lot3 = SelectLot4Update(dbContext, lotid, inputLot.Siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lot), lotid);
			}
			ParamChecker.EntityValidState(typeof(Lot), lot3.Lotid, lot3.State, "Created", "Active");
			if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot3))
			{
				throw new EntityIsHoldException(typeof(Lot), lotid);
			}
			Lotcarrierrel lotcarrierrel = LOTCARRIERREL.GetLotCarrierRelList(dbContext, lot3.Lotid, lot3.Siteid).FirstOrDefault();
			if (lotcarrierrel != null)
			{
				throw new InvalidAssignCarrierException(lotcarrierrel.Lotid, lotcarrierrel.Carrierid, lotcarrierrel.Slotposition);
			}
			Lotdurablerel lotdurablerel = LOTDURABLEREL.SelectLotDurableRelList(dbContext, lotList, lot3.Siteid).FirstOrDefault();
			if (lotdurablerel != null)
			{
				throw new InvalidAssignDurableException(lotdurablerel.Lotid, lotdurablerel.Equipmentid, lotdurablerel.Durableid);
			}
			Lot lot4 = new Lot();
			lot4.Lotid = lotid2;
			lot4.Siteid = siteid;
			lot2.CopyColumsTo(lot4);
			string productdefinitionid = lot4.Productdefinitionid;
			if (PRODUCTDEFINITION.SelectProductDefinition(dbContext, productdefinitionid, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(Productdefinition), productdefinitionid);
			}
			string processdefinitionid = lot4.Processdefinitionid;
			Productprocessrel productprocessrel;
			if (string.IsNullOrEmpty(processdefinitionid))
			{
				if ((productprocessrel = PRODUCTPROCESSREL.SelectProductProcessRelDefault(dbContext, productdefinitionid, siteid)) == null)
				{
					throw new EntityNotFoundException(typeof(Productprocessrel), productdefinitionid);
				}
				processdefinitionid = productprocessrel.Processdefinitionid;
			}
			else if ((productprocessrel = PRODUCTPROCESSREL.SelectProductProcessRel(dbContext, productdefinitionid, processdefinitionid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Productprocessrel), productdefinitionid + "-" + processdefinitionid);
			}
			if (!flag2)
			{
				processdefinition = PROCESSDEFINITION.SelectProcessDefinition(dbContext, processdefinitionid, siteid);
				if ("Created".Equals(processdefinition.State))
				{
					throw new EntityStateInvalidException(typeof(ProcessdefinitionState), "processdefinition", processdefinition.State);
				}
			}
			lot4.Location = EntityHelper.FirstNotNull<string>(lot2.Location, lot3.Location);
			lot4.Qty = EntityHelper.FirstNotNull<decimal?>(lot2.Qty, lot3.Qty);
			lot4.Originalqty = EntityHelper.FirstNotNull<decimal?>(lot4.Originalqty, lot3.Qty);
			lot4.State = EntityHelper.FirstNotNull<string>(lot2.State, "Created");
			lot4.Parentlotid = lotid;
			lot4.Isusable = "Usable";
			if (flag)
			{
				if ((processnode = PROCESSNODE.SelectProcessStartSegmentNode(dbContext, processdefinitionid, siteid)) == null)
				{
					throw new StartSegmentNodeNotFoundException(processdefinitionid);
				}
				if ((processsegment = PROCESSSEGMENT.SelectProcessSegment(dbContext, processnode.Processsegmentid, siteid)) == null)
				{
					throw new EntityNotFoundException(typeof(Processsegment), processnode.Processsegmentid);
				}
				lot4.Processdefinitionid = processdefinitionid;
				lot4.Mainprocessdefinitionid = processdefinitionid;
				lot4.Processingstate = "WaitForRule";
				lot4.Prevsubprocessdefinitionid = null;
				lot4.Subprocessdefinitionid = processnode.Processdefinitionid;
				lot4.Prevprocesssegmentid = null;
				lot4.Processsegmentid = processsegment.Processsegmentid;
				lot4.Prevprocessnodeid = null;
				lot4.Processnodeid = processnode.Processnodeid;
				Processsegmentruleclsrel processsegmentruleclsrel;
				if ((processsegmentruleclsrel = PROCESSSEGMENTRULECLSREL.SelectFirstProcessSegmentRuleByRuleCls(dbContext, processsegment.Processsegmentruleclsid, siteid)) == null)
				{
					throw new EntityNotFoundException(typeof(Processsegmentruleclsrel), processsegment.Processsegmentruleclsid, siteid);
				}
				lot4.Processsegmentruleid = processsegmentruleclsrel.Processsegmentruleid;
				lot4.Rulesequence = processsegmentruleclsrel.Rulesequence;
			}
			list.Add(lot4);
			lot3.Prevstate = lot3.State;
			lot3.State = "Converted";
			inputLot.CopyCommonFieldUpdatePrev(lot3, systemTime, dbContext.Tid, text);
			inputLot.CopyExtensionCollection(lot3);
			list2.Add(lot3);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveLotHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveConvertLotHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int ConvertLotToMaterialLot(IDbContext dbContext, Lot[] lotList, Materiallot[] materialLotList, IOptionSet optionSet, bool saveLotHist, bool saveMaterialLotHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		object[] objectList = lotList;
		ParamChecker.ArgumentNotNull("lotList", objectList);
		objectList = materialLotList;
		ParamChecker.ArgumentNotNull("materialLotList", objectList);
		objectList = lotList;
		object[] arr = objectList;
		objectList = materialLotList;
		ParamChecker.ArraySameLength(arr, objectList);
		string text = "ConvertLotToMaterialLot";
		int apiVersion = 1;
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		int num = 0;
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		List<Materiallot> list = new List<Materiallot>();
		List<Lot> list2 = new List<Lot>();
		for (int i = 0; i < lotList.Length; i++)
		{
			Lot lot = lotList[i];
			Materiallot materiallot = materialLotList[i];
			ParamChecker.ArgumentNotNull("Lotid", lot.Lotid);
			ParamChecker.ArgumentNotNull("Siteid", lot.Siteid);
			ParamChecker.ArgumentNotNull("Materialotid", materiallot.Materiallotid);
			ParamChecker.ArgumentNotNull("Materialdefinitionid", materiallot.Materialdefinitionid);
			string lotid = lot.Lotid;
			string siteid = lot.Siteid;
			string materiallotid = materiallot.Materiallotid;
			_ = materiallot.Materialdefinitionid;
			Lot lot2 = null;
			if ((lot2 = SelectLot4Update(dbContext, lotid, lot.Siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lot), lotid);
			}
			ParamChecker.EntityInvalidState(typeof(Lot), lot2.Lotid, lot2.State, "Created", "Converted", "Scrapped", "Terminated", "Shipped");
			if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot2))
			{
				throw new EntityIsHoldException(typeof(Lot), lotid);
			}
			Materiallot materiallot2 = new Materiallot();
			materiallot2.Materiallotid = materiallotid;
			materiallot2.Siteid = siteid;
			materiallot.CopyColumsTo(materiallot2);
			materiallot2.Location = EntityHelper.FirstNotNull<string>(materiallot.Location, lot2.Location);
			materiallot2.Qty = EntityHelper.FirstNotNull<decimal?>(materiallot.Qty, lot2.Qty);
			materiallot2.Sourceinputid = lotid;
			list.Add(materiallot2);
			lot2.Prevstate = lot2.State;
			lot2.State = "Converted";
			lot.CopyCommonFieldUpdatePrev(lot2, systemTime, dbContext.Tid, text);
			lot.CopyExtensionCollection(lot2);
			list2.Add(lot2);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveLotHist);
		num += MATERIALLOT.CreateMaterialLot(dbContext, list.ToArray(), null, saveMaterialLotHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int ConvertLotToMaterialLotBulk(IDbContext dbContext, Lot[] lotList, Materiallot[] materialLotList, ConvertLotMaterialLotBulkOptionSet optionSet, bool saveLotHist, bool saveMaterialLotHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		object[] objectList = lotList;
		ParamChecker.ArgumentNotNull("lotList", objectList);
		objectList = materialLotList;
		ParamChecker.ArgumentNotNull("materialLotList", objectList);
		objectList = lotList;
		object[] arr = objectList;
		objectList = materialLotList;
		ParamChecker.ArraySameLength(arr, objectList);
		string text = "ConvertLotToMaterialLot";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		int num = 0;
		string[] bulkColumnList = optionSet?.BulkColumnList;
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		string siteid = lotList[0].Siteid;
		string[] first = ExtractIdOrderBy(lotList);
		ExtractIdOrderBy(materialLotList);
		List<Materiallot> list = new List<Materiallot>();
		List<Lot> list2 = new List<Lot>();
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		if (lotList.Length > array.Length)
		{
			throw new EntityNotFoundException(typeof(Lot), first.Except(ExtractIdOrderBy(array)).ToString());
		}
		if (!ValidateAllowHoldLotBulk(dbContext, text, apiVersion, array))
		{
			Lot[] lotList2 = array.Where((Lot v) => v.Ishold == "Y").ToArray();
			throw new EntityIsHoldException(typeof(Lot), EntityHelper.ConcatString4InClause(ExtractIdOrderBy(lotList2)));
		}
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", ConvertLotToMaterialLotBulk(array));
		}
		Lot lot = lotList[0];
		Materiallot materiallot = materialLotList[0];
		ParamChecker.ArgumentNotNull("Lotid", lot.Lotid);
		ParamChecker.ArgumentNotNull("Siteid", lot.Siteid);
		ParamChecker.ArgumentNotNull("Materiallotid", materiallot.Materiallotid);
		string lotid = lot.Lotid;
		string materiallotid = materiallot.Materiallotid;
		Lot lot2 = null;
		if ((lot2 = SelectLot4Update(dbContext, lotid, lot.Siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Lot), lotid);
		}
		ParamChecker.EntityInvalidState(typeof(Lot), lot2.Lotid, lot2.State, "Created", "Converted", "Scrapped", "Terminated", "Shipped");
		Materiallot createMaterialLot = new Materiallot();
		createMaterialLot.Materiallotid = materiallotid;
		createMaterialLot.Siteid = siteid;
		materiallot.CopyColumsTo(createMaterialLot);
		createMaterialLot.Location = EntityHelper.FirstNotNull<string>(materiallot.Location, lot2.Location);
		createMaterialLot.Qty = EntityHelper.FirstNotNull<decimal?>(materiallot.Qty, lot2.Qty);
		createMaterialLot.Sourceinputid = lotid;
		list.Add(createMaterialLot);
		list.AddRange(materialLotList.ToList().FindAll((Materiallot m) => m.Materiallotid != createMaterialLot.Materiallotid));
		lot2.Prevstate = lot2.State;
		lot2.State = "Converted";
		lot.CopyCommonFieldUpdatePrev(lot2, systemTime, dbContext.Tid, text);
		lot.CopyExtensionCollection(lot2);
		list2.Add(lot2);
		num += ContextManager.BulkUpdateEntityFullColumn(dbContext, lot2, array, bulkColumnList, saveLotHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist: false);
		if (list.Count > 0)
		{
			num += ContextManager.BulkUpdateEntityFullColumn(dbContext, list[0], list.ToArray(), bulkColumnList, saveMaterialLotHist);
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", ConvertLotToMaterialLotBulk(array));
		}
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	internal static string ConvertLotToMaterialLotBulk(Lot[] lotList)
	{
		return string.Format(_formatConvertLotToMaterialLotBulk, EntityHelper.ConcatString4InClause(ExtractIdOrderBy(lotList)), EntityHelper.ConcatString4InClause((from p in lotList
			select p.Lotid into id
			orderby id
			select id).ToArray()), EntityHelper.ConcatString4InClause((from p in lotList
			select p.Processsegmentid into id
			orderby id
			select id).ToArray()), EntityHelper.ConcatString4InClause((from p in lotList
			select p.Location into id
			orderby id
			select id).ToArray()), EntityHelper.ConcatString4InClause((from p in lotList
			select p.Qty.ToString() into id
			orderby id
			select id).ToArray()));
	}

	public static int CreateFutureAction(IDbContext dbContext, Lot lot, Lotfutureaction[] lotfutureactionList, IOptionSet optionSet, bool saveLotHist, bool saveFutureActionHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("lot", lot);
		ParamChecker.ArgumentNotNullAndHasElement("lotfutureactionList", lotfutureactionList);
		ParamChecker.ArgumentNotNull("Siteid", lot.Siteid);
		string text = "CreateFutureAction";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Lotfutureaction> list2 = new List<Lotfutureaction>();
		ParamChecker.ArgumentNotNull("Lotid", lot.Lotid);
		string lotid = lot.Lotid;
		string siteid = lot.Siteid;
		Lot lot2;
		if ((lot2 = SelectLot4Update(dbContext, lotid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Lot), lotid);
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", lot2);
		}
		if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot2))
		{
			throw new EntityIsHoldException(typeof(Lot), lotid);
		}
		lot2.Isreservedfutureaction = "Y";
		lot.CopyCommonFieldUpdatePrev(lot2, systemTime, tid, text);
		lot.CopyExtensionCollection(lot2);
		list.Add(lot2);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", lot2);
		}
		foreach (Lotfutureaction lotfutureaction in lotfutureactionList)
		{
			Lotfutureaction lotfutureaction2 = new Lotfutureaction();
			lotfutureaction.CopyColumsTo(lotfutureaction2);
			ParamChecker.ArgumentNotNull("Actiontype", lotfutureaction2.Actiontype);
			ParamChecker.ArgumentNotNull("Actionprocessdefinitionid", lotfutureaction2.Actionprocessdefinitionid);
			ParamChecker.ArgumentNotNull("Actionprocesssegmentid", lotfutureaction2.Actionprocesssegmentid);
			ParamChecker.ArgumentNotNull("Actionproductdefinitionid", lotfutureaction2.Actionproductdefinitionid);
			lotfutureaction2.Lotfutureactionsysid = ContextManager.GetNextTID();
			lotfutureaction2.Lotid = lotid;
			lotfutureaction2.Lotcurrentqty = lot2.Qty;
			lotfutureaction2.Setproductdefinitionid = lot2.Productdefinitionid;
			lotfutureaction2.Setprocessdefinitionid = lot2.Processdefinitionid;
			lotfutureaction2.Setsubprocessdefinitionid = lot2.Subprocessdefinitionid;
			lotfutureaction2.Setprocesssegmentid = lot2.Processsegmentid;
			lotfutureaction2.Isprocesssegmentstart = "Y";
			lotfutureaction2.Prevactivity = null;
			lotfutureaction2.Activity = text;
			lotfutureaction2.Isusable = "Usable";
			lotfutureaction2.Siteid = siteid;
			lotfutureaction2.Modifier = EntityHelper.FirstNotNull<string>(lot.Creator, lot.Modifier);
			lotfutureaction.CopyCommonField(lotfutureaction2, systemTime, tid, isCreate: true);
			lotfutureaction2.Customactivity = EntityHelper.FirstNotNull<string>(lotfutureaction.Customactivity, lotfutureaction2.Activity);
			list2.Add(lotfutureaction2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", lotfutureaction2);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveLotHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list2.ToArray(), saveFutureActionHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int PrevCreateLot(IDbContext dbContext, Lot[] lotList, CreateLotOptionSet createLotOptionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("lotList", lotList);
		string text = "CreateLot";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		int num = 0;
		List<Lot> list = new List<Lot>();
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		bool flag = createLotOptionSet?.MoveToFirstSegment ?? false;
		bool flag2 = createLotOptionSet?.ProcessdefinitionWithoutState ?? false;
		foreach (Lot lot in lotList)
		{
			ParamChecker.ArgumentNotNull("Lotid", lot.Lotid);
			ParamChecker.ArgumentNotNull("Productdefinitionid", lot.Productdefinitionid);
			ParamChecker.ArgumentNotNull("Siteid", lot.Siteid);
			Processdefinition processdefinition = null;
			Processnode processnode = null;
			Processsegment processsegment = null;
			Lot lot2 = new Lot();
			lot.CopyColumsTo(lot2);
			list.Add(lot2);
			string siteid = lot2.Siteid;
			_ = lot2.Lotid;
			string productdefinitionid = lot2.Productdefinitionid;
			Productdefinition productdefinition;
			if ((productdefinition = PRODUCTDEFINITION.SelectProductDefinition(dbContext, productdefinitionid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Productdefinition), productdefinitionid);
			}
			string processdefinitionid = lot2.Processdefinitionid;
			Productprocessrel productprocessrel;
			if (string.IsNullOrEmpty(processdefinitionid))
			{
				if ((productprocessrel = PRODUCTPROCESSREL.SelectProductProcessRelDefault(dbContext, productdefinitionid, siteid)) == null)
				{
					throw new EntityNotFoundException(typeof(Productprocessrel), productdefinitionid);
				}
				processdefinitionid = productprocessrel.Processdefinitionid;
			}
			else if ((productprocessrel = PRODUCTPROCESSREL.SelectProductProcessRel(dbContext, productdefinitionid, processdefinitionid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Productprocessrel), productdefinitionid + "-" + processdefinitionid);
			}
			if (!flag2)
			{
				processdefinition = PROCESSDEFINITION.SelectProcessDefinition(dbContext, processdefinitionid, siteid);
				if ("Created".Equals(processdefinition.State))
				{
					throw new EntityStateInvalidException(typeof(ProcessdefinitionState), "processdefinition", processdefinition.State);
				}
			}
			string location = lot2.Location;
			if (!string.IsNullOrEmpty(location) && FACILITY.SelectFacility(dbContext, location, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(Facility), location);
			}
			string productorderid = lot2.Productorderid;
			if (!string.IsNullOrEmpty(productorderid) && PRODUCTORDER.SelectProductOrder(dbContext, productorderid, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(Productorder), productorderid);
			}
			if (flag)
			{
				if ((processnode = PROCESSNODE.SelectProcessStartSegmentNode(dbContext, processdefinitionid, siteid)) == null)
				{
					throw new StartSegmentNodeNotFoundException(processdefinitionid);
				}
				if ((processsegment = PROCESSSEGMENT.SelectProcessSegment(dbContext, processnode.Processsegmentid, siteid)) == null)
				{
					throw new EntityNotFoundException(typeof(Processsegment), processnode.Processsegmentid);
				}
			}
			lot2.State = EntityHelper.FirstNotNull<string>(lot.State, "Created");
			lot2.Isusable = "Usable";
			lot2.Prevactivity = null;
			lot2.Activity = text;
			lot2.Processingstate = "WaitForSegment";
			lot2.Processdefinitionid = processdefinitionid;
			lot2.Mainprocessdefinitionid = processdefinitionid;
			lot2.Producttype = EntityHelper.FirstNotNull<string>(lot.Producttype, productdefinition.Producttype);
			lot2.Materialtype = EntityHelper.FirstNotNull<string>(lot.Materialtype, productdefinition.Materialtype);
			lot2.Submaterialtype = EntityHelper.FirstNotNull<string>(lot.Materialtype, productdefinition.Submaterialtype);
			lot2.Originalqty = EntityHelper.FirstNotNull<decimal?>(lot.Originalqty, lot.Qty, productdefinition.Qty);
			lot2.Qty = lot.Qty;
			lot2.Ishold = "N";
			lot2.Isreservedfutureaction = "N";
			lot2.Isrework = "N";
			if (flag)
			{
				lot2.Processingstate = "WaitForRule";
				lot2.Prevsubprocessdefinitionid = null;
				lot2.Subprocessdefinitionid = processnode.Processdefinitionid;
				lot2.Prevprocesssegmentid = null;
				lot2.Processsegmentid = processsegment.Processsegmentid;
				lot2.Prevprocessnodeid = null;
				lot2.Processnodeid = processnode.Processnodeid;
				Processsegmentruleclsrel processsegmentruleclsrel;
				if ((processsegmentruleclsrel = PROCESSSEGMENTRULECLSREL.SelectFirstProcessSegmentRuleByRuleCls(dbContext, processsegment.Processsegmentruleclsid, siteid)) == null)
				{
					throw new EntityNotFoundException(typeof(Processsegmentruleclsrel), processsegment.Processsegmentruleclsid, siteid);
				}
				lot2.Processsegmentruleid = processsegmentruleclsrel.Processsegmentruleid;
				lot2.Rulesequence = processsegmentruleclsrel.Rulesequence;
			}
			lot.CopyCommonField(lot2, systemTime, tid, isCreate: true);
			lot2.Customactivity = EntityHelper.FirstNotNull<string>(lot.Customactivity, lot2.Activity);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", lot2);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int CreateLot(IDbContext dbContext, Lot[] lotList, CreateLotOptionSet createLotOptionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("lotList", lotList);
		string text = "CreateLot";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		int num = 0;
		List<Lot> list = new List<Lot>();
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		bool flag = createLotOptionSet?.MoveToFirstSegment ?? false;
		foreach (Lot lot in lotList)
		{
			ParamChecker.ArgumentNotNull("Lotid", lot.Lotid);
			ParamChecker.ArgumentNotNull("Productdefinitionid", lot.Productdefinitionid);
			ParamChecker.ArgumentNotNull("Siteid", lot.Siteid);
			Processnode processnode = null;
			Processsegment processsegment = null;
			Lot lot2 = new Lot();
			lot.CopyColumsTo(lot2);
			list.Add(lot2);
			string siteid = lot2.Siteid;
			_ = lot2.Lotid;
			string productdefinitionid = lot2.Productdefinitionid;
			Productdefinition productdefinition;
			if ((productdefinition = PRODUCTDEFINITION.SelectProductDefinition(dbContext, productdefinitionid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Productdefinition), productdefinitionid);
			}
			string processdefinitionid = lot2.Processdefinitionid;
			Productprocessrel productprocessrel;
			if (string.IsNullOrEmpty(processdefinitionid))
			{
				if ((productprocessrel = PRODUCTPROCESSREL.SelectProductProcessRelDefault(dbContext, productdefinitionid, siteid)) == null)
				{
					throw new EntityNotFoundException(typeof(Productprocessrel), productdefinitionid);
				}
				processdefinitionid = productprocessrel.Processdefinitionid;
			}
			else if ((productprocessrel = PRODUCTPROCESSREL.SelectProductProcessRel(dbContext, productdefinitionid, processdefinitionid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Productprocessrel), productdefinitionid + "-" + processdefinitionid);
			}
			string location = lot2.Location;
			if (!string.IsNullOrEmpty(location) && FACILITY.SelectFacility(dbContext, location, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(Facility), location);
			}
			string productorderid = lot2.Productorderid;
			if (!string.IsNullOrEmpty(productorderid) && PRODUCTORDER.SelectProductOrder(dbContext, productorderid, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(Productorder), productorderid);
			}
			if (flag)
			{
				if ((processnode = PROCESSNODE.SelectProcessStartSegmentNode(dbContext, processdefinitionid, siteid)) == null)
				{
					throw new StartSegmentNodeNotFoundException(processdefinitionid);
				}
				if ((processsegment = PROCESSSEGMENT.SelectProcessSegment(dbContext, processnode.Processsegmentid, siteid)) == null)
				{
					throw new EntityNotFoundException(typeof(Processsegment), processnode.Processsegmentid);
				}
			}
			lot2.State = EntityHelper.FirstNotNull<string>(lot.State, "Created");
			lot2.Isusable = "Usable";
			lot2.Prevactivity = null;
			lot2.Activity = text;
			lot2.Processingstate = "WaitForSegment";
			lot2.Processdefinitionid = processdefinitionid;
			lot2.Mainprocessdefinitionid = processdefinitionid;
			lot2.Producttype = EntityHelper.FirstNotNull<string>(lot.Producttype, productdefinition.Producttype);
			lot2.Materialtype = EntityHelper.FirstNotNull<string>(lot.Materialtype, productdefinition.Materialtype);
			lot2.Submaterialtype = EntityHelper.FirstNotNull<string>(lot.Materialtype, productdefinition.Submaterialtype);
			lot2.Originalqty = EntityHelper.FirstNotNull<decimal?>(lot.Originalqty, lot.Qty, productdefinition.Qty);
			lot2.Qty = lot.Qty;
			lot2.Ishold = "N";
			lot2.Isreservedfutureaction = "N";
			lot2.Isrework = "N";
			if (flag)
			{
				lot2.Processingstate = "WaitForRule";
				lot2.Prevsubprocessdefinitionid = null;
				lot2.Subprocessdefinitionid = processnode.Processdefinitionid;
				lot2.Prevprocesssegmentid = null;
				lot2.Processsegmentid = processsegment.Processsegmentid;
				lot2.Prevprocessnodeid = null;
				lot2.Processnodeid = processnode.Processnodeid;
				Processsegmentruleclsrel processsegmentruleclsrel;
				if ((processsegmentruleclsrel = PROCESSSEGMENTRULECLSREL.SelectFirstProcessSegmentRuleByRuleCls(dbContext, processsegment.Processsegmentruleclsid, siteid)) == null)
				{
					throw new EntityNotFoundException(typeof(Processsegmentruleclsrel), processsegment.Processsegmentruleclsid, siteid);
				}
				lot2.Processsegmentruleid = processsegmentruleclsrel.Processsegmentruleid;
				lot2.Rulesequence = processsegmentruleclsrel.Rulesequence;
			}
			lot.CopyCommonField(lot2, systemTime, tid, isCreate: true);
			lot2.Customactivity = EntityHelper.FirstNotNull<string>(lot.Customactivity, lot2.Activity);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", lot2);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int PrevCreateLot(IDbContext dbContext, Lot inputLot, Producedmaterial[] producedMaterialList, CreateLotOptionSet createLotOptionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("inputLot", inputLot);
		string text = "CreateLot";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		ParamChecker.ArgumentNotNull("inputLot", inputLot);
		ParamChecker.ArgumentNotNullAndHasElement("producedMaterialList", producedMaterialList);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		bool flag = createLotOptionSet?.MoveToFirstSegment ?? false;
		ParamChecker.ArgumentNotNull("Lotid", inputLot.Lotid);
		ParamChecker.ArgumentNotNull("Productdefinitionid", inputLot.Productdefinitionid);
		ParamChecker.ArgumentNotNull("Siteid", inputLot.Siteid);
		Processnode processnode = null;
		Processsegment processsegment = null;
		Lot lot = new Lot();
		inputLot.CopyColumsTo(lot);
		list.Add(lot);
		string siteid = lot.Siteid;
		_ = lot.Lotid;
		string productdefinitionid = lot.Productdefinitionid;
		Productdefinition productdefinition;
		if ((productdefinition = PRODUCTDEFINITION.SelectProductDefinition(dbContext, productdefinitionid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Productdefinition), productdefinitionid);
		}
		string processdefinitionid = lot.Processdefinitionid;
		Productprocessrel productprocessrel;
		if (string.IsNullOrEmpty(processdefinitionid))
		{
			if ((productprocessrel = PRODUCTPROCESSREL.SelectProductProcessRelDefault(dbContext, productdefinitionid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Productprocessrel), productdefinitionid);
			}
			processdefinitionid = productprocessrel.Processdefinitionid;
		}
		else if ((productprocessrel = PRODUCTPROCESSREL.SelectProductProcessRel(dbContext, productdefinitionid, processdefinitionid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Productprocessrel), productdefinitionid + "-" + processdefinitionid);
		}
		string location = lot.Location;
		if (!string.IsNullOrEmpty(location) && FACILITY.SelectFacility(dbContext, location, siteid) == null)
		{
			throw new EntityNotFoundException(typeof(Facility), location);
		}
		string productorderid = lot.Productorderid;
		if (!string.IsNullOrEmpty(productorderid) && PRODUCTORDER.SelectProductOrder(dbContext, productorderid, siteid) == null)
		{
			throw new EntityNotFoundException(typeof(Productorder), productorderid);
		}
		if (flag)
		{
			if ((processnode = PROCESSNODE.SelectProcessStartSegmentNode(dbContext, processdefinitionid, siteid)) == null)
			{
				throw new StartSegmentNodeNotFoundException(processdefinitionid);
			}
			if ((processsegment = PROCESSSEGMENT.SelectProcessSegment(dbContext, processnode.Processsegmentid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Processsegment), processnode.Processsegmentid);
			}
		}
		string text2 = lot.Grade;
		if (!string.IsNullOrEmpty(text2))
		{
			Gradedefinition gradedefinition;
			if ((gradedefinition = GRADEDEFINITION.SelectGradeDefinition(dbContext, "Lot", text2, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Gradedefinition), text2);
			}
		}
		else
		{
			Gradedefinition gradedefinition;
			if ((gradedefinition = GRADEDEFINITION.SelectDefaultGradeDefinition(dbContext, "Lot", siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Gradedefinition), "GradeType", "Lot");
			}
			text2 = gradedefinition.Gradeid;
		}
		string[] countableProducedMaterialGradeIdList = getCountableProducedMaterialGradeIdList(dbContext, siteid);
		string[] countableSubproducedMaterialGradeIdList = getCountableSubproducedMaterialGradeIdList(dbContext, siteid);
		lot.State = EntityHelper.FirstNotNull<string>(inputLot.State, "Created");
		lot.Isusable = "Usable";
		lot.Prevactivity = null;
		lot.Activity = text;
		lot.Processingstate = "WaitForSegment";
		lot.Processdefinitionid = processdefinitionid;
		lot.Mainprocessdefinitionid = processdefinitionid;
		lot.Producttype = EntityHelper.FirstNotNull<string>(inputLot.Producttype, productdefinition.Producttype);
		lot.Materialtype = EntityHelper.FirstNotNull<string>(inputLot.Materialtype, productdefinition.Materialtype);
		lot.Submaterialtype = EntityHelper.FirstNotNull<string>(inputLot.Materialtype, productdefinition.Submaterialtype);
		lot.Originalqty = EntityHelper.FirstNotNull<decimal?>(inputLot.Originalqty, inputLot.Qty, productdefinition.Qty);
		lot.Grade = text2;
		lot.Qty = inputLot.Qty;
		lot.Ishold = "N";
		lot.Isreservedfutureaction = "N";
		lot.Isrework = "N";
		if (flag)
		{
			lot.Processingstate = "WaitForRule";
			lot.Prevsubprocessdefinitionid = null;
			lot.Subprocessdefinitionid = processnode.Processdefinitionid;
			lot.Prevprocesssegmentid = null;
			lot.Processsegmentid = processsegment.Processsegmentid;
			lot.Prevprocessnodeid = null;
			lot.Processnodeid = processnode.Processnodeid;
			Processsegmentruleclsrel processsegmentruleclsrel;
			if ((processsegmentruleclsrel = PROCESSSEGMENTRULECLSREL.SelectFirstProcessSegmentRuleByRuleCls(dbContext, processsegment.Processsegmentruleclsid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentruleclsrel), processsegment.Processsegmentruleclsid, siteid);
			}
			lot.Processsegmentruleid = processsegmentruleclsrel.Processsegmentruleid;
			lot.Rulesequence = processsegmentruleclsrel.Rulesequence;
		}
		inputLot.CopyCommonField(lot, systemTime, tid, isCreate: true);
		lot.Customactivity = EntityHelper.FirstNotNull<string>(inputLot.Customactivity, lot.Activity);
		Gradedefinition gradedefinition2 = GRADEDEFINITION.SelectDefaultGradeDefinition(dbContext, "Producedmaterial", siteid);
		Gradedefinition gradedefinition3 = GRADEDEFINITION.SelectDefaultGradeDefinition(dbContext, "Subproducedmaterial", siteid);
		string text3 = "";
		string materialtype = productdefinition.Materialtype;
		string producttype = productdefinition.Producttype;
		decimal? submaterialqty = productdefinition.Submaterialqty;
		string submaterialtype = productdefinition.Submaterialtype;
		string gradeId = "";
		if (gradedefinition2 != null)
		{
			text3 = gradedefinition2.Gradeid;
		}
		if (gradedefinition3 != null)
		{
			gradeId = gradedefinition3.Gradeid;
		}
		List<Producedmaterial> list3 = new List<Producedmaterial>();
		foreach (Producedmaterial producedmaterial in producedMaterialList)
		{
			ParamChecker.ArgumentNotNull(producedmaterial.Producedmaterialid);
			Producedmaterial producedmaterial2 = new Producedmaterial();
			producedmaterial.CopyColumsTo(producedmaterial2);
			list2.Add(producedmaterial2);
			list3.Add(producedmaterial2);
			_ = producedmaterial2.Producedmaterialid;
			string carrierid = producedmaterial2.Carrierid;
			int? slotno = producedmaterial2.Slotno;
			if (slotno.HasValue)
			{
				_ = (decimal)slotno.GetValueOrDefault();
			}
			if (!string.IsNullOrEmpty(carrierid) && CARRIER.SelectCarrier(dbContext, carrierid, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(Carrier), carrierid);
			}
			producedmaterial2.Lotid = lot.Lotid;
			producedmaterial2.Siteid = lot.Siteid;
			producedmaterial2.State = EntityHelper.FirstNotNull<string>(producedmaterial.State, "Created");
			producedmaterial2.Materialtype = EntityHelper.FirstNotNull<string>(producedmaterial.Materialtype, materialtype);
			producedmaterial2.Producttype = EntityHelper.FirstNotNull<string>(producedmaterial.Producttype, producttype);
			producedmaterial2.Submaterialoriginalqty = EntityHelper.FirstNotNull<decimal?>(producedmaterial.Submaterialoriginalqty, submaterialqty);
			producedmaterial2.Submaterialtype = EntityHelper.FirstNotNull<string>(producedmaterial.Submaterialtype, submaterialtype);
			producedmaterial2.Grade = EntityHelper.FirstNotNull<string>(producedmaterial.Grade, text3);
			producedmaterial2.Submaterialoriginalqty = EntityHelper.FirstNotNull<decimal?>(producedmaterial.Submaterialoriginalqty, submaterialqty);
			producedmaterial2.Submaterialqty = EntityHelper.FirstNotNull<decimal?>(producedmaterial.Submaterialqty, producedmaterial2.Submaterialoriginalqty);
			string text4 = GRADEDEFINITION.GenerateSubMaterialGradeString(gradeId, producedmaterial2.Submaterialqty);
			producedmaterial2.Submaterialgrade = EntityHelper.FirstNotNull<string>(producedmaterial.Submaterialgrade, text4);
			producedmaterial2.Ishold = "N";
			producedmaterial2.Isrework = "N";
			producedmaterial2.Productorderid = EntityHelper.FirstNotNull<string>(producedmaterial.Productorderid, lot.Productorderid);
			producedmaterial2.Workorderid = EntityHelper.FirstNotNull<string>(producedmaterial.Workorderid, lot.Workorderid);
			producedmaterial2.Location = EntityHelper.FirstNotNull<string>(producedmaterial.Location, lot.Location);
			producedmaterial2.Equipmentid = EntityHelper.FirstNotNull<string>(producedmaterial.Equipmentid, lot.Equipmentid);
			PRODUCEDMATERIAL.InheritLotProcessInfo(lot, producedmaterial2);
			producedmaterial2.Isusable = "Usable";
			producedmaterial2.Prevactivity = null;
			producedmaterial2.Activity = text;
			producedmaterial.CopyCommonField(producedmaterial2, systemTime, tid, isCreate: true);
			producedmaterial2.Customactivity = EntityHelper.FirstNotNull<string>(producedmaterial.Customactivity, producedmaterial2.Activity);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", producedmaterial2);
			}
		}
		lot.Qty = GetLotQty(dbContext, countableProducedMaterialGradeIdList, list3.ToArray());
		lot.Originalqty = EntityHelper.FirstNotNull<decimal?>(inputLot.Originalqty, lot.Qty);
		lot.Submaterialqty = GetSubProducedMaterialQty(dbContext, countableSubproducedMaterialGradeIdList, list3.ToArray());
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", lot);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list2.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int CreateLot(IDbContext dbContext, Lot inputLot, Producedmaterial[] producedMaterialList, CreateLotOptionSet createLotOptionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("inputLot", inputLot);
		string text = "CreateLot";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		ParamChecker.ArgumentNotNull("inputLot", inputLot);
		ParamChecker.ArgumentNotNullAndHasElement("producedMaterialList", producedMaterialList);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		bool flag = createLotOptionSet?.MoveToFirstSegment ?? false;
		ParamChecker.ArgumentNotNull("Lotid", inputLot.Lotid);
		ParamChecker.ArgumentNotNull("Productdefinitionid", inputLot.Productdefinitionid);
		ParamChecker.ArgumentNotNull("Siteid", inputLot.Siteid);
		Processnode processnode = null;
		Processsegment processsegment = null;
		Lot lot = new Lot();
		inputLot.CopyColumsTo(lot);
		list.Add(lot);
		string siteid = lot.Siteid;
		_ = lot.Lotid;
		string productdefinitionid = lot.Productdefinitionid;
		Productdefinition productdefinition;
		if ((productdefinition = PRODUCTDEFINITION.SelectProductDefinition(dbContext, productdefinitionid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Productdefinition), productdefinitionid);
		}
		string processdefinitionid = lot.Processdefinitionid;
		Productprocessrel productprocessrel;
		if (string.IsNullOrEmpty(processdefinitionid))
		{
			if ((productprocessrel = PRODUCTPROCESSREL.SelectProductProcessRelDefault(dbContext, productdefinitionid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Productprocessrel), productdefinitionid);
			}
			processdefinitionid = productprocessrel.Processdefinitionid;
		}
		else if ((productprocessrel = PRODUCTPROCESSREL.SelectProductProcessRel(dbContext, productdefinitionid, processdefinitionid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Productprocessrel), productdefinitionid + "-" + processdefinitionid);
		}
		string location = lot.Location;
		if (!string.IsNullOrEmpty(location) && FACILITY.SelectFacility(dbContext, location, siteid) == null)
		{
			throw new EntityNotFoundException(typeof(Facility), location);
		}
		string productorderid = lot.Productorderid;
		if (!string.IsNullOrEmpty(productorderid) && PRODUCTORDER.SelectProductOrder(dbContext, productorderid, siteid) == null)
		{
			throw new EntityNotFoundException(typeof(Productorder), productorderid);
		}
		if (flag)
		{
			if ((processnode = PROCESSNODE.SelectProcessStartSegmentNode(dbContext, processdefinitionid, siteid)) == null)
			{
				throw new StartSegmentNodeNotFoundException(processdefinitionid);
			}
			if ((processsegment = PROCESSSEGMENT.SelectProcessSegment(dbContext, processnode.Processsegmentid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Processsegment), processnode.Processsegmentid);
			}
		}
		string[] countableProducedMaterialGradeIdList = getCountableProducedMaterialGradeIdList(dbContext, siteid);
		string[] countableSubproducedMaterialGradeIdList = getCountableSubproducedMaterialGradeIdList(dbContext, siteid);
		lot.State = EntityHelper.FirstNotNull<string>(inputLot.State, "Created");
		lot.Isusable = "Usable";
		lot.Prevactivity = null;
		lot.Activity = text;
		lot.Processingstate = "WaitForSegment";
		lot.Processdefinitionid = processdefinitionid;
		lot.Mainprocessdefinitionid = processdefinitionid;
		lot.Producttype = EntityHelper.FirstNotNull<string>(inputLot.Producttype, productdefinition.Producttype);
		lot.Materialtype = EntityHelper.FirstNotNull<string>(inputLot.Materialtype, productdefinition.Materialtype);
		lot.Submaterialtype = EntityHelper.FirstNotNull<string>(inputLot.Materialtype, productdefinition.Submaterialtype);
		lot.Originalqty = EntityHelper.FirstNotNull<decimal?>(inputLot.Originalqty, inputLot.Qty, productdefinition.Qty);
		lot.Qty = inputLot.Qty;
		lot.Ishold = "N";
		lot.Isreservedfutureaction = "N";
		lot.Isrework = "N";
		if (flag)
		{
			lot.Processingstate = "WaitForRule";
			lot.Prevsubprocessdefinitionid = null;
			lot.Subprocessdefinitionid = processnode.Processdefinitionid;
			lot.Prevprocesssegmentid = null;
			lot.Processsegmentid = processsegment.Processsegmentid;
			lot.Prevprocessnodeid = null;
			lot.Processnodeid = processnode.Processnodeid;
			Processsegmentruleclsrel processsegmentruleclsrel;
			if ((processsegmentruleclsrel = PROCESSSEGMENTRULECLSREL.SelectFirstProcessSegmentRuleByRuleCls(dbContext, processsegment.Processsegmentruleclsid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentruleclsrel), processsegment.Processsegmentruleclsid, siteid);
			}
			lot.Processsegmentruleid = processsegmentruleclsrel.Processsegmentruleid;
			lot.Rulesequence = processsegmentruleclsrel.Rulesequence;
		}
		inputLot.CopyCommonField(lot, systemTime, tid, isCreate: true);
		lot.Customactivity = EntityHelper.FirstNotNull<string>(inputLot.Customactivity, lot.Activity);
		Gradedefinition gradedefinition = GRADEDEFINITION.SelectDefaultGradeDefinition(dbContext, "Producedmaterial", siteid);
		Gradedefinition gradedefinition2 = GRADEDEFINITION.SelectDefaultGradeDefinition(dbContext, "Subproducedmaterial", siteid);
		string text2 = "";
		string materialtype = productdefinition.Materialtype;
		string producttype = productdefinition.Producttype;
		decimal? submaterialqty = productdefinition.Submaterialqty;
		string submaterialtype = productdefinition.Submaterialtype;
		string gradeId = "";
		if (gradedefinition != null)
		{
			text2 = gradedefinition.Gradeid;
		}
		if (gradedefinition2 != null)
		{
			gradeId = gradedefinition2.Gradeid;
		}
		List<Producedmaterial> list3 = new List<Producedmaterial>();
		foreach (Producedmaterial producedmaterial in producedMaterialList)
		{
			ParamChecker.ArgumentNotNull(producedmaterial.Producedmaterialid);
			Producedmaterial producedmaterial2 = new Producedmaterial();
			producedmaterial.CopyColumsTo(producedmaterial2);
			list2.Add(producedmaterial2);
			list3.Add(producedmaterial2);
			_ = producedmaterial2.Producedmaterialid;
			string carrierid = producedmaterial2.Carrierid;
			int? slotno = producedmaterial2.Slotno;
			if (slotno.HasValue)
			{
				_ = (decimal)slotno.GetValueOrDefault();
			}
			if (!string.IsNullOrEmpty(carrierid) && CARRIER.SelectCarrier(dbContext, carrierid, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(Carrier), carrierid);
			}
			producedmaterial2.Lotid = lot.Lotid;
			producedmaterial2.Siteid = lot.Siteid;
			producedmaterial2.State = EntityHelper.FirstNotNull<string>(producedmaterial.State, "Created");
			producedmaterial2.Materialtype = EntityHelper.FirstNotNull<string>(producedmaterial.Materialtype, materialtype);
			producedmaterial2.Producttype = EntityHelper.FirstNotNull<string>(producedmaterial.Producttype, producttype);
			producedmaterial2.Submaterialoriginalqty = EntityHelper.FirstNotNull<decimal?>(producedmaterial.Submaterialoriginalqty, submaterialqty);
			producedmaterial2.Submaterialtype = EntityHelper.FirstNotNull<string>(producedmaterial.Submaterialtype, submaterialtype);
			producedmaterial2.Grade = EntityHelper.FirstNotNull<string>(producedmaterial.Grade, text2);
			producedmaterial2.Submaterialoriginalqty = EntityHelper.FirstNotNull<decimal?>(producedmaterial.Submaterialoriginalqty, submaterialqty);
			producedmaterial2.Submaterialqty = EntityHelper.FirstNotNull<decimal?>(producedmaterial.Submaterialqty, producedmaterial2.Submaterialoriginalqty);
			string text3 = GRADEDEFINITION.GenerateSubMaterialGradeString(gradeId, producedmaterial2.Submaterialqty);
			producedmaterial2.Submaterialgrade = EntityHelper.FirstNotNull<string>(producedmaterial.Submaterialgrade, text3);
			producedmaterial2.Ishold = "N";
			producedmaterial2.Isrework = "N";
			producedmaterial2.Productorderid = EntityHelper.FirstNotNull<string>(producedmaterial.Productorderid, lot.Productorderid);
			producedmaterial2.Workorderid = EntityHelper.FirstNotNull<string>(producedmaterial.Workorderid, lot.Workorderid);
			producedmaterial2.Location = EntityHelper.FirstNotNull<string>(producedmaterial.Location, lot.Location);
			producedmaterial2.Equipmentid = EntityHelper.FirstNotNull<string>(producedmaterial.Equipmentid, lot.Equipmentid);
			PRODUCEDMATERIAL.InheritLotProcessInfo(lot, producedmaterial2);
			producedmaterial2.Isusable = "Usable";
			producedmaterial2.Prevactivity = null;
			producedmaterial2.Activity = text;
			producedmaterial.CopyCommonField(producedmaterial2, systemTime, tid, isCreate: true);
			producedmaterial2.Customactivity = EntityHelper.FirstNotNull<string>(producedmaterial.Customactivity, producedmaterial2.Activity);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", producedmaterial2);
			}
		}
		lot.Qty = GetLotQty(dbContext, countableProducedMaterialGradeIdList, list3.ToArray());
		lot.Originalqty = EntityHelper.FirstNotNull<decimal?>(inputLot.Originalqty, lot.Qty);
		lot.Submaterialqty = GetSubProducedMaterialQty(dbContext, countableSubproducedMaterialGradeIdList, list3.ToArray());
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", lot);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list2.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int DeassignLotFromBatchBulk(IDbContext dbContext, Lot[] lotList, Batch batch, Lotbatchrel[] lotbatchrelList, IOptionSet optionSet, bool saveLotHist, bool saveLotbatchrelHist, bool saveBatchHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		object[] objectList = lotList;
		ParamChecker.ArgumentNotNullAndHasElement("lotList", objectList);
		ParamChecker.ArgumentNotNull("batch", batch);
		objectList = lotbatchrelList;
		ParamChecker.ArgumentNotNullAndHasElement("lotbatchrelList", objectList);
		string text = "DeassignLotBatchRel";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		ParamChecker.ArgumentNotNull("batch", batch);
		ParamChecker.ArgumentNotNull("Batchid", batch.Batchid);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		List<Batch> list3 = new List<Batch>();
		List<Lotbatchrel> list4 = new List<Lotbatchrel>();
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		string siteid = lotbatchrelList[0].Siteid;
		Dictionary<string, Lotbatchrel[]> dictionary = (from g in lotbatchrelList
			group g by g.Lotid).ToDictionary((IGrouping<string, Lotbatchrel> g) => g.Key, (IGrouping<string, Lotbatchrel> g) => g.ToArray());
		string[] first = ExtractIdOrderBy(lotList);
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		if (!ValidateAllowHoldLotBulk(dbContext, text, apiVersion, array))
		{
			throw new EntityIsHoldException(typeof(Lot), "," + dictionary.Keys.ToArray());
		}
		IList<Lot> list5 = SelectLotListAlive4Update(dbContext, array, siteid);
		if (array.Length > list5.Count)
		{
			throw new EntityNotFoundException(typeof(Lot), first.Except(ExtractIdOrderBy(list5.ToArray())).ToString());
		}
		Dictionary<string, Lot[]> dictionary2 = (from lot in array
			group lot by lot.Processnodeid).ToDictionary((IGrouping<string, Lot> g) => g.Key, (IGrouping<string, Lot> g) => g.ToArray());
		if (dictionary2.Count > 1)
		{
			throw new InvalidNotSameProcessnodeException(typeof(Lot), dictionary2.Keys.ToArray());
		}
		foreach (Lot inputLot in lotList)
		{
			Lot lot2 = array.Where((Lot lot) => lot.Lotid == inputLot.Lotid && lot.Siteid == inputLot.Siteid).FirstOrDefault();
			UpdateUserColumns(text, inputLot, lot2);
			inputLot.CopyCommonFieldUpdatePrev(lot2, systemTime, tid, text);
			inputLot.CopyExtensionCollection(lot2);
			list.Add(lot2);
		}
		foreach (Lot item in list)
		{
			Producedmaterial[] array2 = PRODUCEDMATERIAL.SelectProducedMaterialListAliveByLot4Update(dbContext, item.Lotid, item.Siteid).ToArray();
			foreach (Producedmaterial producedmaterial in array2)
			{
				if (!(producedmaterial.Batchid != batch.Batchid))
				{
					if (!PRODUCEDMATERIAL.ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, producedmaterial))
					{
						throw new EntityIsHoldException(typeof(Producedmaterial), producedmaterial.Producedmaterialid);
					}
					if (MesLogger.IsDebugEnabled("API"))
					{
						MesLogger.DebugTidApi(tid, "Before Execute", $"Producedmaterialid={producedmaterial.Producedmaterialid} Lotid={producedmaterial.Lotid} Batchid={producedmaterial.Batchid}");
					}
					producedmaterial.Batchid = null;
					item.CopyCommonFieldUpdatePrev(producedmaterial, systemTime, tid, text);
					list2.Add(producedmaterial);
					if (MesLogger.IsInfoEnabled("API"))
					{
						MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={producedmaterial.Producedmaterialid} Lotid={producedmaterial.Lotid} Batchid={producedmaterial.Batchid}");
					}
				}
			}
		}
		Batch batch2 = BATCH.SelectBatch(dbContext, batch.Batchid, batch.Siteid);
		if (batch2 == null)
		{
			throw new EntityNotFoundException(typeof(Batch), batch.Batchid);
		}
		if (batch.Qty.HasValue && !(batch2.Qty == batch.Qty))
		{
			batch2.Qty = batch.Qty;
		}
		batch.CopyCommonFieldUpdatePrev(batch2, systemTime, tid, text);
		batch.CopyExtensionCollection(batch2);
		list3.Add(batch2);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", batch2);
		}
		Lotbatchrel[] source = LOTBATCHREL.SelectLotBatchRelAllListWithBatchid(dbContext, batch.Batchid, batch.Siteid).ToArray();
		foreach (Lotbatchrel inputLotbatchrel in lotbatchrelList)
		{
			ParamChecker.ArgumentNotNull("Lotid", inputLotbatchrel.Lotid);
			ParamChecker.ArgumentNotNull("Batchid", inputLotbatchrel.Batchid);
			ParamChecker.ArgumentNotNull("Siteid", inputLotbatchrel.Siteid);
			if (!batch.Batchid.Equals(inputLotbatchrel.Batchid))
			{
				throw new ObjectComparedInvalidException("Batchid", batch.Batchid, inputLotbatchrel.Batchid);
			}
			if (!batch.Siteid.Equals(inputLotbatchrel.Siteid))
			{
				throw new ObjectComparedInvalidException("Siteid", batch.Siteid, inputLotbatchrel.Siteid);
			}
			if (lotList.Where((Lot lot) => lot.Lotid == inputLotbatchrel.Lotid && lot.Siteid == inputLotbatchrel.Siteid).FirstOrDefault() == null)
			{
				throw new InvalidAssignLotBatchRelException(inputLotbatchrel.Lotid, inputLotbatchrel.Batchid, inputLotbatchrel.Siteid);
			}
			Lotbatchrel lotbatchrel = source.Where((Lotbatchrel lcr) => lcr.Lotid == inputLotbatchrel.Lotid && lcr.Batchid == inputLotbatchrel.Batchid && lcr.Siteid == inputLotbatchrel.Siteid).FirstOrDefault();
			if (lotbatchrel == null)
			{
				throw new EntityNotFoundException(typeof(Lotbatchrel), inputLotbatchrel.Lotid, inputLotbatchrel.Batchid, inputLotbatchrel.Siteid);
			}
			inputLotbatchrel.CopyCommonFieldUpdatePrev(lotbatchrel, systemTime, tid, text);
			inputLotbatchrel.CopyExtensionCollection(lotbatchrel);
			lotbatchrel.Isusable = "UnUsable";
			list4.Add(lotbatchrel);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", lotbatchrel);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveLotHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveLotHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list3.ToArray(), saveBatchHist);
		num += ContextManager.BulkDeleteEntityFullColumn(dbContext, list4.ToArray(), saveLotbatchrelHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int DeassignLotFromCarrier(IDbContext dbContext, Lot lot, Carrier carrier, Lotcarrierrel[] lotcarrierrelList, IOptionSet optionSet, bool saveLotHist, bool saveLotCarrierrelHist, bool saveCarrierHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotcarrierrelList", lotcarrierrelList);
		string text = "DeassignLotFromCarrier";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		ParamChecker.ArgumentNotNull("lot", lot);
		ParamChecker.ArgumentNotNull("carrier", carrier);
		ParamChecker.ArgumentNotNull("Carrierid", carrier.Carrierid);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		List<Carrier> list3 = new List<Carrier>();
		List<Lotcarrierrel> list4 = new List<Lotcarrierrel>();
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		ParamChecker.ArgumentNotNull("Lotid", lot.Lotid);
		ParamChecker.ArgumentNotNull("Siteid", lot.Siteid);
		string lotid = lot.Lotid;
		string siteid = lot.Siteid;
		string carrierid = carrier.Carrierid;
		Lot lot2;
		if ((lot2 = SelectLot4Update(dbContext, lotid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Lot), lotid);
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", lot2);
		}
		Producedmaterial[] array = PRODUCEDMATERIAL.SelectProducedMaterialListAliveByLot4Update(dbContext, lotid, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lot2.Lotid} ProducedMaterial Count={array.Length}");
		}
		if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot2))
		{
			throw new EntityIsHoldException(typeof(Lot), lotid);
		}
		lot.CopyCommonFieldUpdatePrev(lot2, systemTime, tid, text);
		lot.CopyExtensionCollection(lot2);
		list.Add(lot2);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", lot2);
		}
		Producedmaterial[] array2 = array;
		foreach (Producedmaterial producedmaterial in array2)
		{
			if (!(producedmaterial.Carrierid != carrierid))
			{
				if (!PRODUCEDMATERIAL.ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, producedmaterial))
				{
					throw new EntityIsHoldException(typeof(Producedmaterial), producedmaterial.Producedmaterialid);
				}
				if (MesLogger.IsDebugEnabled("API"))
				{
					MesLogger.DebugTidApi(tid, "Before Execute", $"Producedmaterialid={producedmaterial.Producedmaterialid} Prevcarrierid={producedmaterial.Prevcarrierid} Carrierid={producedmaterial.Carrierid} Prevslotno={producedmaterial.Prevslotno} Slotno={producedmaterial.Slotno}");
				}
				producedmaterial.Prevcarrierid = producedmaterial.Carrierid;
				producedmaterial.Carrierid = null;
				producedmaterial.Prevslotno = producedmaterial.Slotno;
				producedmaterial.Slotno = 0;
				lot.CopyCommonFieldUpdatePrev(producedmaterial, systemTime, tid, text);
				list2.Add(producedmaterial);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={producedmaterial.Producedmaterialid} Prevcarrierid={producedmaterial.Prevcarrierid} Carrierid={producedmaterial.Carrierid} Prevslotno={producedmaterial.Prevslotno} Slotno={producedmaterial.Slotno}");
				}
			}
		}
		Carrier carrier2 = CARRIER.SelectCarrier4Update(dbContext, carrierid, siteid);
		if (carrier2 == null)
		{
			throw new EntityNotFoundException(typeof(Carrier), carrierid);
		}
		if (carrier.Assignqty.HasValue && !(carrier2.Assignqty == carrier.Assignqty))
		{
			carrier2.Assignqty = carrier.Assignqty;
		}
		if (carrier.Loadstate != null && carrier2.Loadstate != carrier.Loadstate)
		{
			carrier2.Loadstate = carrier.Loadstate;
		}
		carrier.CopyCommonFieldUpdatePrev(carrier2, systemTime, tid, text);
		carrier.CopyExtensionCollection(carrier2);
		list3.Add(carrier2);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", carrier2);
		}
		foreach (Lotcarrierrel lotcarrierrel in lotcarrierrelList)
		{
			ParamChecker.ArgumentNotNull("Lotid", lotcarrierrel.Lotid);
			ParamChecker.ArgumentNotNull("Carrierid", lotcarrierrel.Carrierid);
			ParamChecker.ArgumentNotNull("Slotposition", lotcarrierrel.Slotposition);
			ParamChecker.ArgumentNotNull("Siteid", lotcarrierrel.Siteid);
			int slotposition = lotcarrierrel.Slotposition;
			if (!lotid.Equals(lotcarrierrel.Lotid))
			{
				throw new ObjectComparedInvalidException("Lotid", lotid, lotcarrierrel.Lotid);
			}
			if (!carrierid.Equals(lotcarrierrel.Carrierid))
			{
				throw new ObjectComparedInvalidException("Carrierid", carrierid, lotcarrierrel.Carrierid);
			}
			if (!siteid.Equals(lotcarrierrel.Siteid))
			{
				throw new ObjectComparedInvalidException("Siteid", siteid, lotcarrierrel.Siteid);
			}
			Lotcarrierrel lotcarrierrel2 = LOTCARRIERREL.SelectLotCarrierRel(dbContext, lotid, carrierid, slotposition, siteid);
			if (lotcarrierrel2 == null)
			{
				throw new EntityNotFoundException(typeof(Lotcarrierrel), lotid, carrierid, slotposition.ToString());
			}
			lotcarrierrel.CopyCommonFieldUpdatePrev(lotcarrierrel2, systemTime, tid, text);
			lotcarrierrel.CopyExtensionCollection(lotcarrierrel2);
			list4.Add(lotcarrierrel2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", lotcarrierrel2);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveLotHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveLotHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list3.ToArray(), saveCarrierHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list4.ToArray(), saveLotCarrierrelHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int DeassignLotFromCarrierBulk(IDbContext dbContext, Lot[] lotList, Carrier carrier, Lotcarrierrel[] lotcarrierrelList, IOptionSet optionSet, bool saveLotHist, bool saveLotCarrierrelHist, bool saveCarrierHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		object[] objectList = lotList;
		ParamChecker.ArgumentNotNullAndHasElement("lotList", objectList);
		objectList = lotcarrierrelList;
		ParamChecker.ArgumentNotNullAndHasElement("lotcarrierrelList", objectList);
		string text = "DeassignLotFromCarrier";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		ParamChecker.ArgumentNotNull("carrier", carrier);
		ParamChecker.ArgumentNotNull("Carrierid", carrier.Carrierid);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		List<Carrier> list3 = new List<Carrier>();
		List<Lotcarrierrel> list4 = new List<Lotcarrierrel>();
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		string siteid = lotcarrierrelList[0].Siteid;
		Dictionary<string, Lotcarrierrel[]> dictionary = (from g in lotcarrierrelList
			group g by g.Lotid).ToDictionary((IGrouping<string, Lotcarrierrel> g) => g.Key, (IGrouping<string, Lotcarrierrel> g) => g.ToArray());
		string[] first = ExtractIdOrderBy(lotList);
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		if (!ValidateAllowHoldLotBulk(dbContext, text, apiVersion, array))
		{
			throw new EntityIsHoldException(typeof(Lot), "," + dictionary.Keys.ToArray());
		}
		IList<Lot> list5 = SelectLotListAlive4Update(dbContext, array, siteid);
		if (array.Length > list5.Count)
		{
			throw new EntityNotFoundException(typeof(Lot), first.Except(ExtractIdOrderBy(list5.ToArray())).ToString());
		}
		Dictionary<string, Lot[]> dictionary2 = (from lot in array
			group lot by lot.Processnodeid).ToDictionary((IGrouping<string, Lot> g) => g.Key, (IGrouping<string, Lot> g) => g.ToArray());
		if (dictionary2.Count > 1)
		{
			throw new InvalidNotSameProcessnodeException(typeof(Lot), dictionary2.Keys.ToArray());
		}
		foreach (Lot inputLot in lotList)
		{
			Lot lot2 = array.Where((Lot lot) => lot.Lotid == inputLot.Lotid && lot.Siteid == inputLot.Siteid).FirstOrDefault();
			UpdateUserColumns(text, inputLot, lot2);
			inputLot.CopyCommonFieldUpdatePrev(lot2, systemTime, tid, text);
			inputLot.CopyExtensionCollection(lot2);
			list.Add(lot2);
		}
		foreach (Lot item in list)
		{
			Producedmaterial[] array2 = PRODUCEDMATERIAL.SelectProducedMaterialListAliveByLot4Update(dbContext, item.Lotid, item.Siteid).ToArray();
			foreach (Producedmaterial producedmaterial in array2)
			{
				if (!(producedmaterial.Carrierid != carrier.Carrierid))
				{
					if (!PRODUCEDMATERIAL.ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, producedmaterial))
					{
						throw new EntityIsHoldException(typeof(Producedmaterial), producedmaterial.Producedmaterialid);
					}
					if (MesLogger.IsDebugEnabled("API"))
					{
						MesLogger.DebugTidApi(tid, "Before Execute", $"Producedmaterialid={producedmaterial.Producedmaterialid} Prevcarrierid={producedmaterial.Prevcarrierid} Carrierid={producedmaterial.Carrierid} Prevslotno={producedmaterial.Prevslotno} Slotno={producedmaterial.Slotno}");
					}
					producedmaterial.Prevcarrierid = producedmaterial.Carrierid;
					producedmaterial.Carrierid = null;
					producedmaterial.Prevslotno = producedmaterial.Slotno;
					producedmaterial.Slotno = 0;
					item.CopyCommonFieldUpdatePrev(producedmaterial, systemTime, tid, text);
					list2.Add(producedmaterial);
					if (MesLogger.IsInfoEnabled("API"))
					{
						MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={producedmaterial.Producedmaterialid} Prevcarrierid={producedmaterial.Prevcarrierid} Carrierid={producedmaterial.Carrierid} Prevslotno={producedmaterial.Prevslotno} Slotno={producedmaterial.Slotno}");
					}
				}
			}
		}
		Carrier carrier2 = CARRIER.SelectCarrier4Update(dbContext, carrier.Carrierid, carrier.Siteid);
		if (carrier2 == null)
		{
			throw new EntityNotFoundException(typeof(Carrier), carrier.Carrierid);
		}
		if (carrier.Assignqty.HasValue && !(carrier2.Assignqty == carrier.Assignqty))
		{
			carrier2.Assignqty = carrier.Assignqty;
		}
		if (carrier.Loadstate != null && carrier2.Loadstate != carrier.Loadstate)
		{
			carrier2.Loadstate = carrier.Loadstate;
		}
		carrier.CopyCommonFieldUpdatePrev(carrier2, systemTime, tid, text);
		carrier.CopyExtensionCollection(carrier2);
		list3.Add(carrier2);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", carrier2);
		}
		Lotcarrierrel[] source = LOTCARRIERREL.SelectLotCarrierRelListByCarrier(dbContext, carrier.Carrierid, carrier.Siteid).ToArray();
		foreach (Lotcarrierrel inputLotcarrierrel in lotcarrierrelList)
		{
			ParamChecker.ArgumentNotNull("Lotid", inputLotcarrierrel.Lotid);
			ParamChecker.ArgumentNotNull("Carrierid", inputLotcarrierrel.Carrierid);
			ParamChecker.ArgumentNotNull("Slotposition", inputLotcarrierrel.Slotposition);
			ParamChecker.ArgumentNotNull("Siteid", inputLotcarrierrel.Siteid);
			if (!carrier.Carrierid.Equals(inputLotcarrierrel.Carrierid))
			{
				throw new ObjectComparedInvalidException("Carrierid", carrier.Carrierid, inputLotcarrierrel.Carrierid);
			}
			if (!carrier.Siteid.Equals(inputLotcarrierrel.Siteid))
			{
				throw new ObjectComparedInvalidException("Siteid", carrier.Siteid, inputLotcarrierrel.Siteid);
			}
			if (lotList.Where((Lot lot) => lot.Lotid == inputLotcarrierrel.Lotid && lot.Siteid == inputLotcarrierrel.Siteid).FirstOrDefault() == null)
			{
				throw new InvalidAssignCarrierException(inputLotcarrierrel.Lotid, inputLotcarrierrel.Carrierid, inputLotcarrierrel.Slotposition);
			}
			Lotcarrierrel lotcarrierrel = source.Where((Lotcarrierrel lcr) => lcr.Lotid == inputLotcarrierrel.Lotid && lcr.Carrierid == inputLotcarrierrel.Carrierid && lcr.Slotposition == inputLotcarrierrel.Slotposition && lcr.Siteid == inputLotcarrierrel.Siteid).FirstOrDefault();
			if (lotcarrierrel == null)
			{
				throw new EntityNotFoundException(typeof(Lotcarrierrel), inputLotcarrierrel.Lotid, inputLotcarrierrel.Carrierid, inputLotcarrierrel.Slotposition.ToString());
			}
			inputLotcarrierrel.CopyCommonFieldUpdatePrev(lotcarrierrel, systemTime, tid, text);
			inputLotcarrierrel.CopyExtensionCollection(lotcarrierrel);
			lotcarrierrel.Isusable = "UnUsable";
			list4.Add(lotcarrierrel);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", lotcarrierrel);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveLotHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveLotHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list3.ToArray(), saveCarrierHist);
		num += ContextManager.BulkDeleteEntityFullColumn(dbContext, list4.ToArray(), saveLotCarrierrelHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int DeassignProducedMaterial(IDbContext dbContext, Lot lot, Producedmaterial[] producedMaterialList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		string text = "DeassignProducedMaterial";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		int num = 0;
		ParamChecker.ArgumentNotNull("lot", lot);
		ParamChecker.ArgumentNotNull("lot.Lotid", lot.Lotid);
		ParamChecker.ArgumentNotNull("lot.Siteid", lot.Siteid);
		ParamChecker.ArgumentNotNullAndHasElement("inputProducedMaterialList", producedMaterialList);
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		string lotid = lot.Lotid;
		string siteid = lot.Siteid;
		Lot lot2 = null;
		if ((lot2 = SelectLot4Update(dbContext, lotid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Lot), lotid);
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", lot2);
		}
		Producedmaterial[] array = PRODUCEDMATERIAL.SelectProducedMaterialList4Update(dbContext, producedMaterialList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lot2.Lotid} ProducedMaterial Count={array.Length}");
		}
		if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot2))
		{
			throw new EntityIsHoldException(typeof(Lot), lotid);
		}
		string[] countableProducedMaterialGradeIdList = getCountableProducedMaterialGradeIdList(dbContext, siteid);
		string[] countableSubproducedMaterialGradeIdList = getCountableSubproducedMaterialGradeIdList(dbContext, siteid);
		foreach (Producedmaterial producedmaterial in producedMaterialList)
		{
			string producedmaterialid = producedmaterial.Producedmaterialid;
			ParamChecker.ArgumentNotNull("Producedmaterialid", producedmaterialid);
			Producedmaterial producedmaterial2 = null;
			if ((producedmaterial2 = PRODUCEDMATERIAL.FindProducedMaterial(array, producedmaterialid)) == null)
			{
				throw new EntityNotFoundException(typeof(Producedmaterial), producedmaterialid);
			}
			if (!PRODUCEDMATERIAL.ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, producedmaterial2))
			{
				throw new EntityIsHoldException(typeof(Producedmaterial), producedmaterial.Producedmaterialid);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", $"Producedmaterialid={producedmaterial2.Producedmaterialid} Prevlotid={producedmaterial2.Prevlotid} Lotid={producedmaterial2.Lotid} Prevslotno={producedmaterial2.Prevslotno} Slotno={producedmaterial2.Slotno} Prevcarrierid={producedmaterial2.Prevcarrierid} Carrierid={producedmaterial2.Carrierid}");
			}
			producedmaterial2.Prevlotid = producedmaterial2.Lotid;
			producedmaterial2.Lotid = null;
			producedmaterial2.Prevslotno = producedmaterial2.Slotno;
			producedmaterial2.Slotno = 0;
			producedmaterial2.Prevcarrierid = producedmaterial2.Carrierid;
			producedmaterial2.Carrierid = null;
			producedmaterial.CopyCommonFieldUpdatePrev(producedmaterial2, systemTime, tid, text);
			producedmaterial.CopyExtensionCollection(producedmaterial2);
			list2.Add(producedmaterial2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={producedmaterial2.Producedmaterialid} Prevlotid={producedmaterial2.Prevlotid} Lotid={producedmaterial2.Lotid} Prevslotno={producedmaterial2.Prevslotno} Slotno={producedmaterial2.Slotno} Prevcarrierid={producedmaterial2.Prevcarrierid} Carrierid={producedmaterial2.Carrierid}");
			}
		}
		decimal lotQty = GetLotQty(dbContext, countableProducedMaterialGradeIdList, array.ToArray());
		decimal subProducedMaterialQty = GetSubProducedMaterialQty(dbContext, countableSubproducedMaterialGradeIdList, array.ToArray());
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "CalcQty", $"Lotid={lot2.Lotid} Change Qty={lotQty} Submaterialqty={subProducedMaterialQty}");
		}
		lot2.Prevqty = lot2.Qty;
		lot2.Qty = lot2.Qty.Add(-lotQty);
		lot2.Prevsubmaterialqty = lot2.Submaterialqty;
		lot2.Submaterialqty = lot2.Submaterialqty.Add(-subProducedMaterialQty);
		lot.CopyCommonFieldUpdatePrev(lot2, systemTime, tid, text);
		lot.CopyExtensionCollection(lot2);
		list.Add(lot2);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", lot2);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int DispatchWorkLot(IDbContext dbContext, Lot[] lotList, DispatchWorkLotOptionSet optionSet, bool saveHistManualDispatch)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotList", lotList);
		string text = "DispatchWorkLot";
		int apiVersion = 2;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		bool flag = optionSet?.ValidateSegmentRuleId ?? false;
		string text2 = optionSet?.ProcessSegmentRuleId;
		_ = optionSet?.SaveHistAutoDispatch;
		_ = optionSet?.CustomActivityAutoDispatch;
		_ = optionSet?.SaveHistFinishLot;
		_ = optionSet?.CustomActivityFinishLot;
		if (optionSet != null && optionSet.ModifytimeFinishLot != DateTime.MinValue)
		{
			_ = optionSet.ModifytimeFinishLot;
		}
		bool saveHistReworkFinishLot = optionSet?.SaveHistReworkFinishLot ?? false;
		string customActivityReworkFinishLot = optionSet?.CustomActivityReworkFinishLot;
		DateTime modifyTimeReworkFinishLot = ((optionSet != null && optionSet.ModifytimeReworkFinishLot != DateTime.MinValue) ? optionSet.ModifytimeReworkFinishLot : systemTime);
		_ = optionSet?.SaveHistRunFutureAction;
		_ = optionSet?.CustomActivityRunFutureAction;
		if (optionSet != null && optionSet.ModifytimeRunFutureAction != DateTime.MinValue)
		{
			_ = optionSet.ModifytimeRunFutureAction;
		}
		bool saveHistSegmentInjectFinishLot = optionSet?.SaveHistSegmentInjectFinishLot ?? false;
		string customActivitySegmentInjectFinishLot = optionSet?.CustomActivitySegmentInjectFinishLot;
		DateTime modifyTimeSegmentInjectFinishLot = ((optionSet != null && optionSet.ModifytimeSegmentInjectFinishLot != DateTime.MinValue) ? optionSet.ModifytimeSegmentInjectFinishLot : systemTime);
		if (flag)
		{
			ParamChecker.ArgumentNotNull("DispatchWorkLotOptionSet.ProcessSegmentRuleId", text2);
		}
		int num = 0;
		foreach (Lot lot in lotList)
		{
			ParamChecker.ArgumentNotNull("Lotid", lot.Lotid);
			ParamChecker.ArgumentNotNull("Siteid", lot.Siteid);
			string siteid = lot.Siteid;
			string lotid = lot.Lotid;
			Lot lot2;
			if ((lot2 = SelectLot(dbContext, lotid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lot), lotid);
			}
			_ = lot2.Processnodeid;
			ParamChecker.EntityUsable(typeof(Lot), lotid, lot2.Isusable);
			if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot2))
			{
				throw new EntityIsHoldException(typeof(Lot), lotid);
			}
			string processdefinitionid = lot2.Processdefinitionid;
			string subprocessdefinitionid = lot2.Subprocessdefinitionid;
			string processsegmentid = lot2.Processsegmentid;
			string processsegmentruleid = lot2.Processsegmentruleid;
			int? rulesequence = lot2.Rulesequence;
			ParamChecker.ArgumentNotNull("currProcessDefinitionId", processdefinitionid);
			ParamChecker.ArgumentNotNull("CurrSubprocessDefinitionId", subprocessdefinitionid);
			ParamChecker.ArgumentNotNull("currProcessSegmentId", processsegmentid);
			if (flag)
			{
				ParamChecker.EntityValidState(typeof(Lot), "Processsegmentruleid", text2, processsegmentruleid);
			}
			if (lot2.Processingstate == "WaitForRule" || lot2.Processingstate == "ProcessingRule")
			{
				ParamChecker.ArgumentNotNull("currProcesssegmentruleid", processsegmentruleid);
				ParamChecker.ArgumentNotNull("currRulesequence", rulesequence);
				Processsegmentruleclsrel processsegmentruleclsrel = PROCESSSEGMENTRULECLSREL.SelectProcessSegmentRuleClsRelBySegmentId(dbContext, processsegmentid, processsegmentruleid, siteid);
				if (processsegmentruleclsrel == null)
				{
					throw new EntityNotFoundException(typeof(Processsegmentruleclsrel), "Curr Rule :: " + processsegmentid + ":" + processsegmentruleid);
				}
				if (processsegmentruleclsrel.Isend == "N")
				{
					Processsegmentruleclsrel processsegmentruleclsrel2 = PROCESSSEGMENTRULECLSREL.SelectNextProcessSegmentRule(dbContext, processsegmentid, rulesequence.Value, siteid);
					if (processsegmentruleclsrel2 == null)
					{
						Type typeFromHandle = typeof(Processsegmentruleclsrel);
						string[] array = new string[1];
						int? num2 = rulesequence;
						array[0] = "Next Rule :: " + processsegmentid + ":" + num2;
						throw new EntityNotFoundException(typeFromHandle, array);
					}
					num += RuleChangeProcessingRule(dbContext, lot, lot2, processsegmentruleclsrel2, systemTime, saveHistManualDispatch);
				}
				else
				{
					num += RuleChangeWaitForSegment(dbContext, lot, lot2, systemTime, saveHistManualDispatch);
					Lotadhocprocess lotAdhocProcess = GetLotAdhocProcess(dbContext, lot2, fetchCustomColumns: true);
					num = ((lotAdhocProcess == null) ? (num + SegmentChangeNextSegment(dbContext, lot, lot2, dispatchForce: false, systemTime, saveHistManualDispatch, optionSet)) : (num + RunLotAdhocAction(dbContext, lot, lot2, lotAdhocProcess, customActivityReworkFinishLot, saveHistReworkFinishLot, modifyTimeReworkFinishLot, customActivitySegmentInjectFinishLot, saveHistSegmentInjectFinishLot, modifyTimeSegmentInjectFinishLot)));
				}
			}
			else
			{
				num += SegmentChangeNextSegment(dbContext, lot, lot2, dispatchForce: true, systemTime, saveHistManualDispatch, optionSet);
			}
		}
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RuleChangeProcessingRule(IDbContext dbContext, Lot inputLot, Lot storedLot, Processsegmentruleclsrel nextRule, DateTime workTime, bool saveHistChangeSegmentRule)
	{
		string tid = dbContext.Tid;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		int num = 0;
		storedLot.Processingstate = "ProcessingRule";
		storedLot.Processsegmentruleid = nextRule.Processsegmentruleid;
		storedLot.Rulesequence = nextRule.Rulesequence;
		inputLot.CopyCommonFieldUpdatePrev(storedLot, workTime, tid, "DispatchWorkLot");
		inputLot.CopyExtensionCollection(storedLot);
		list.Add(storedLot);
		Producedmaterial[] array = PRODUCEDMATERIAL.SelectProducedMaterialListAliveByLot4Update(dbContext, storedLot.Lotid, storedLot.Siteid).ToArray();
		foreach (Producedmaterial producedmaterial in array)
		{
			PRODUCEDMATERIAL.InheritLotProcessInfo(storedLot, producedmaterial);
			inputLot.CopyCommonFieldUpdatePrev(producedmaterial, workTime, tid, "DispatchWorkLot");
			list2.Add(producedmaterial);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHistChangeSegmentRule);
		return num + ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHistChangeSegmentRule);
	}

	private static int RuleChangeWaitForSegment(IDbContext dbContext, Lot inputLot, Lot storedLot, DateTime workTime, bool saveHistChangeSegmentRule)
	{
		string tid = dbContext.Tid;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		int num = 0;
		storedLot.Processingstate = "WaitForSegment";
		storedLot.Processsegmentruleid = null;
		storedLot.Rulesequence = null;
		inputLot.CopyCommonFieldUpdatePrev(storedLot, workTime, tid, "DispatchWorkLot");
		inputLot.CopyExtensionCollection(storedLot);
		list.Add(storedLot);
		Producedmaterial[] array = PRODUCEDMATERIAL.SelectProducedMaterialListAliveByLot4Update(dbContext, storedLot.Lotid, storedLot.Siteid).ToArray();
		foreach (Producedmaterial producedmaterial in array)
		{
			PRODUCEDMATERIAL.InheritLotProcessInfo(storedLot, producedmaterial);
			inputLot.CopyCommonFieldUpdatePrev(producedmaterial, workTime, tid, "DispatchWorkLot");
			list2.Add(producedmaterial);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHistChangeSegmentRule);
		return num + ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHistChangeSegmentRule);
	}

	private static int SegmentChangeNextSegment(IDbContext dbContext, Lot inputLot, Lot storedLot, bool dispatchForce, DateTime workTime, bool saveHistManualDispatch, DispatchWorkLotOptionSet optionSet)
	{
		bool flag = optionSet?.SaveHistAutoDispatch ?? false;
		string text = optionSet?.CustomActivityAutoDispatch;
		DateTime dateTime = ((optionSet != null && optionSet.ModifytimeAutoDispatch != DateTime.MinValue) ? optionSet.ModifytimeAutoDispatch : workTime);
		bool saveHistFinishLot = optionSet?.SaveHistFinishLot ?? false;
		string customActivityFinishLot = optionSet?.CustomActivityFinishLot;
		DateTime modifyTimeRunLotFinish = ((optionSet != null && optionSet.ModifytimeFinishLot != DateTime.MinValue) ? optionSet.ModifytimeFinishLot : workTime);
		bool saveHistFutureAction = optionSet?.SaveHistRunFutureAction ?? false;
		string customActivityFutureAction = optionSet?.CustomActivityRunFutureAction;
		DateTime modifyTimeFutureAction = ((optionSet != null && optionSet.ModifytimeRunFutureAction != DateTime.MinValue) ? optionSet.ModifytimeRunFutureAction : workTime);
		int num = 0;
		_ = storedLot.Lotid;
		string siteid = storedLot.Siteid;
		string processdefinitionid = storedLot.Processdefinitionid;
		string processnodeid = storedLot.Processnodeid;
		bool saveHist = (dispatchForce ? saveHistManualDispatch : flag);
		if (dispatchForce)
		{
			_ = inputLot.Customactivity;
		}
		Processnode processnode = null;
		Processnode processnode2 = null;
		if (string.IsNullOrEmpty(storedLot.Nextprocesssegmentid))
		{
			if ((processnode2 = PROCESSNODE.SelectNextSegmentNodeSingle(dbContext, processdefinitionid, processnodeid, "PASS", siteid)) == null)
			{
				if ((processnode = PROCESSNODE.SelectProcessNode(dbContext, processnodeid, siteid)) == null)
				{
					throw new EntityNotFoundException(typeof(Processnode), processnodeid);
				}
				if (processnode.Isendnode == "Y")
				{
					return num + RunLotFinish(dbContext, inputLot, storedLot, customActivityFinishLot, saveHistFinishLot, modifyTimeRunLotFinish);
				}
				throw new NextNodeNotFoundException(processdefinitionid, processnodeid);
			}
		}
		else if ((processnode2 = PROCESSNODE.SelectNextSegmentNodeSingleBySegment(dbContext, processdefinitionid, processnodeid, storedLot.Nextprocesssegmentid, siteid)) == null)
		{
			throw new NextNodeSegmentNotFoundException(processdefinitionid, processnodeid, storedLot.Nextprocesssegmentid);
		}
		if (processnode2 == null)
		{
			return num;
		}
		if (!dispatchForce)
		{
			if (processnode == null && (processnode = PROCESSNODE.SelectProcessNode(dbContext, processnodeid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Processnode), processnodeid);
			}
			if (!IsAutoDispatch(dbContext, processdefinitionid, processnode, processnode2, siteid))
			{
				return num;
			}
		}
		string tid = dbContext.Tid;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		string processnodeid2 = processnode2.Processnodeid;
		string processsegmentid = processnode2.Processsegmentid;
		string processdefinitionid2 = processnode2.Processdefinitionid;
		Processsegmentruleclsrel processsegmentruleclsrel = PROCESSSEGMENTRULECLSREL.SelectFirstProcessSegmentRule(dbContext, processsegmentid, siteid);
		if (processsegmentruleclsrel == null)
		{
			throw new EntityNotFoundException(typeof(Processsegmentruleclsrel), processsegmentid);
		}
		storedLot.Processingstate = "WaitForRule";
		storedLot.Processsegmentruleid = processsegmentruleclsrel.Processsegmentruleid;
		storedLot.Rulesequence = processsegmentruleclsrel.Rulesequence;
		storedLot.Prevsubprocessdefinitionid = storedLot.Subprocessdefinitionid;
		storedLot.Subprocessdefinitionid = processdefinitionid2;
		storedLot.Prevprocesssegmentid = storedLot.Processsegmentid;
		storedLot.Processsegmentid = processsegmentid;
		storedLot.Prevprocessnodeid = storedLot.Processnodeid;
		storedLot.Processnodeid = processnodeid2;
		storedLot.Nextprocesssegmentid = null;
		storedLot.Nextsubprocessdefinitionid = null;
		storedLot.Receivedtime = EntityHelper.FirstNotNull<DateTime>(storedLot.Modifytime, dateTime);
		inputLot.CopyCommonFieldUpdatePrev(storedLot, dateTime, tid, "DispatchWorkLot");
		inputLot.CopyExtensionCollection(storedLot);
		list.Add(storedLot);
		Producedmaterial[] array = PRODUCEDMATERIAL.SelectProducedMaterialListAliveByLot4Update(dbContext, storedLot.Lotid, storedLot.Siteid).ToArray();
		foreach (Producedmaterial producedmaterial in array)
		{
			PRODUCEDMATERIAL.InheritLotProcessInfo(storedLot, producedmaterial);
			inputLot.CopyCommonFieldUpdatePrev(producedmaterial, dateTime, tid, "DispatchWorkLot");
			list2.Add(producedmaterial);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHist);
		if (LOTFUTUREACTION.GetLotFutureActionCountCurrentSegmentRule(dbContext, storedLot) > 0)
		{
			num += RunLotFutureAction(dbContext, inputLot, "Y", customActivityFutureAction, saveHistFutureAction, modifyTimeFutureAction);
		}
		return num;
	}

	private static bool IsAutoDispatch(IDbContext dbContext, string topProcessDefinitionId, Processnode currSegmentNode, Processnode nextSegmentNode, string siteId)
	{
		Processnode processnode;
		Processnode processnode2;
		if (currSegmentNode.Processdefinitionid == nextSegmentNode.Processdefinitionid)
		{
			processnode = currSegmentNode;
			processnode2 = nextSegmentNode;
		}
		else
		{
			if (currSegmentNode.Processdefinitionid == topProcessDefinitionId)
			{
				processnode = currSegmentNode;
			}
			else if ((processnode = PROCESSNODE.SelectProcessDefinitionNode(dbContext, topProcessDefinitionId, currSegmentNode.Processdefinitionid, siteId)) == null)
			{
				throw new ProcessNodeNotFoundException(topProcessDefinitionId, currSegmentNode.Processdefinitionid);
			}
			if (nextSegmentNode.Processdefinitionid == topProcessDefinitionId)
			{
				processnode2 = nextSegmentNode;
			}
			else if ((processnode2 = PROCESSNODE.SelectProcessDefinitionNode(dbContext, topProcessDefinitionId, nextSegmentNode.Processdefinitionid, siteId)) == null)
			{
				throw new ProcessNodeNotFoundException(topProcessDefinitionId, nextSegmentNode.Processdefinitionid);
			}
		}
		return (PROCESSPATH.SelectProcessPathByNextNode(dbContext, processnode.Processnodeid, processnode2.Processnodeid, siteId) ?? throw new ProcessPathNotFoundException(processnode.Processnodeid, processnode2.Processnodeid)).Isautodispatch == "Y";
	}

	private static int RunLotFinish(IDbContext dbContext, Lot inputLot, Lot storedLot, string customActivityFinishLot, bool saveHistFinishLot, DateTime modifyTimeRunLotFinish)
	{
		string tid = dbContext.Tid;
		Lot lot = new Lot();
		lot.Lotid = inputLot.Lotid;
		lot.Siteid = inputLot.Siteid;
		inputLot.CopyCommonFieldUpdatePrev(lot, modifyTimeRunLotFinish, tid, "DispatchWorkLot");
		lot.Modifytime = modifyTimeRunLotFinish;
		lot.Customactivity = customActivityFinishLot;
		if (!"Active".Equals(storedLot.State))
		{
			return 0;
		}
		return FinishLot(dbContext, new Lot[1] { lot }, null, saveHistFinishLot);
	}

	private static int RunLotFinishBulk(IDbContext dbContext, Lot[] storedLotList, string customActivityFinishLot, bool saveHistFinishLot, DateTime modifyTimeRunLotFinish)
	{
		string tid = dbContext.Tid;
		storedLotList[0].CopyCommonFieldUpdatePrev(storedLotList[0], modifyTimeRunLotFinish, tid, "DispatchWorkLot");
		storedLotList[0].Modifytime = modifyTimeRunLotFinish;
		storedLotList[0].Customactivity = customActivityFinishLot;
		return FinishLotBulk(dbContext, storedLotList, null, saveHistFinishLot);
	}

	private static int RunLotFutureAction(IDbContext dbContext, Lot inputLot, string Isprocesssegmentstart, string customActivityFutureAction, bool saveHistFutureAction, DateTime modifyTimeFutureAction)
	{
		string tid = dbContext.Tid;
		Lot lot = new Lot();
		lot.Lotid = inputLot.Lotid;
		lot.Siteid = inputLot.Siteid;
		inputLot.CopyCommonFieldUpdatePrev(lot, modifyTimeFutureAction, tid, "DispatchWorkLot");
		lot.Modifytime = modifyTimeFutureAction;
		lot.Customactivity = customActivityFutureAction;
		return RunFutureAction(dbContext, new Lot[1] { lot }, null, saveHistFutureAction);
	}

	private static Lotadhocprocess GetLotAdhocProcess(IDbContext dbContext, Lot storedLot, bool fetchCustomColumns)
	{
		if (string.IsNullOrEmpty(storedLot.Adhocprocesssysid))
		{
			return null;
		}
		return LOTADHOCPROCESS.SelectLotAdhocProcess(dbContext, storedLot.Adhocprocesssysid, storedLot.Processdefinitionid, storedLot.Subprocessdefinitionid, storedLot.Processsegmentid, storedLot.Siteid);
	}

	private static int RunLotAdhocAction(IDbContext dbContext, Lot inputLot, Lot storedLot, Lotadhocprocess lotAdhocProcess, string customActivityReworkFinishLot, bool saveHistReworkFinishLot, DateTime modifyTimeReworkFinishLot, string customActivitySegmentInjectFinishLot, bool saveHistSegmentInjectFinishLot, DateTime modifyTimeSegmentInjectFinishLot)
	{
		int num = 0;
		string tid = dbContext.Tid;
		if (lotAdhocProcess.Adhocprocesstype == "Rework")
		{
			Lot lot = new Lot();
			lot.Lotid = inputLot.Lotid;
			lot.Siteid = inputLot.Siteid;
			inputLot.CopyCommonFieldUpdatePrev(lot, modifyTimeReworkFinishLot, tid, "DispatchWorkLot");
			lot.Modifytime = modifyTimeReworkFinishLot;
			lot.Customactivity = customActivityReworkFinishLot;
			return ReworkFinishLot(dbContext, new Lot[1] { lot }, null, saveHistReworkFinishLot);
		}
		Lot lot2 = new Lot();
		lot2.Lotid = inputLot.Lotid;
		lot2.Siteid = inputLot.Siteid;
		inputLot.CopyCommonFieldUpdatePrev(lot2, modifyTimeSegmentInjectFinishLot, tid, "DispatchWorkLot");
		lot2.Modifytime = modifyTimeSegmentInjectFinishLot;
		lot2.Customactivity = customActivitySegmentInjectFinishLot;
		return SegmentInjectFinishLot(dbContext, new Lot[1] { lot2 }, null, saveHistSegmentInjectFinishLot);
	}

	private static int DispatchWorkLotPOST(IDbContext dbContext, Lot inputLot, Lot storedLot, bool needAdhocProcess, Lotadhocprocess lotAdhocProcess, bool needFinishLot, bool needFutureAction, bool saveHistFinishLot, string customActivityFinishLot, DateTime modifyTimeFinishLot, bool saveHistReworkFinishLot, string customActivityReworkFinishLot, DateTime modifyTimeReworkFinishLot, bool saveHistSegmentInjectFinishLot, string customActivitySegmentInjectFinishLot, DateTime modifyTimeSegmentInjectFinishLot, bool saveHistFutureAction, string customActivityFutureAction, DateTime modifyTimeFutureAction)
	{
		int num = 0;
		if (needFinishLot)
		{
			num += RunLotFinish(dbContext, inputLot, storedLot, customActivityFinishLot, saveHistFinishLot, modifyTimeFinishLot);
		}
		else if (needAdhocProcess)
		{
			num += RunLotAdhocAction(dbContext, inputLot, storedLot, lotAdhocProcess, customActivityReworkFinishLot, saveHistReworkFinishLot, modifyTimeReworkFinishLot, customActivitySegmentInjectFinishLot, saveHistSegmentInjectFinishLot, modifyTimeSegmentInjectFinishLot);
		}
		else if (needFutureAction)
		{
			string isprocesssegmentstart = ((storedLot.Processingstate == "WaitForRule") ? "Y" : "N");
			num += RunLotFutureAction(dbContext, inputLot, isprocesssegmentstart, customActivityFutureAction, saveHistFutureAction, modifyTimeFutureAction);
		}
		return num;
	}

	private static int DispatchWorkLotPOSTBulk(IDbContext dbContext, Lot[] storedLotList, bool needFinishLot, bool saveHistFinishLot, string customActivityFinishLot, DateTime modifyTimeFinishLot)
	{
		int num = 0;
		if (needFinishLot)
		{
			num += RunLotFinishBulk(dbContext, storedLotList, customActivityFinishLot, saveHistFinishLot, modifyTimeFinishLot);
		}
		return num;
	}

	private static void DispatchWorkLotPRE(IDbContext dbContext, Lot storedLot, Producedmaterial[] storedProducedMaterialList, DateTime workTime, out bool needAdhocProcess, out Lotadhocprocess lotAdhocProcess, out bool needFinishLot, out bool needFutureAction)
	{
		needAdhocProcess = false;
		lotAdhocProcess = null;
		needFinishLot = false;
		needFutureAction = false;
		string siteid = storedLot.Siteid;
		string lotid = storedLot.Lotid;
		_ = storedLot.Processnodeid;
		string processdefinitionid = storedLot.Processdefinitionid;
		string subprocessdefinitionid = storedLot.Subprocessdefinitionid;
		string processsegmentid = storedLot.Processsegmentid;
		string processsegmentruleid = storedLot.Processsegmentruleid;
		int? rulesequence = storedLot.Rulesequence;
		ParamChecker.ArgumentNotNull("currProcessDefinitionId", processdefinitionid);
		ParamChecker.ArgumentNotNull("CurrSubprocessDefinitionId", subprocessdefinitionid);
		ParamChecker.ArgumentNotNull("currProcessSegmentId", processsegmentid);
		ParamChecker.EntityValidState(typeof(Lot), lotid, storedLot.Processingstate, "WaitForRule", "ProcessingRule");
		Processsegmentruleclsrel processsegmentruleclsrel = PROCESSSEGMENTRULECLSREL.SelectProcessSegmentRuleClsRelBySegmentId(dbContext, processsegmentid, processsegmentruleid, siteid);
		if (processsegmentruleclsrel == null)
		{
			throw new EntityNotFoundException(typeof(Processsegmentruleclsrel), "Curr Rule :: " + processsegmentid + ":" + processsegmentruleid);
		}
		if (processsegmentruleclsrel.Isend == "N")
		{
			Processsegmentruleclsrel processsegmentruleclsrel2 = PROCESSSEGMENTRULECLSREL.SelectNextProcessSegmentRule(dbContext, processsegmentid, rulesequence.Value, siteid);
			if (processsegmentruleclsrel2 == null)
			{
				Type typeFromHandle = typeof(Processsegmentruleclsrel);
				string[] array = new string[1];
				int? num = rulesequence;
				array[0] = "Next Rule :: " + processsegmentid + ":" + num;
				throw new EntityNotFoundException(typeFromHandle, array);
			}
			RuleChangeProcessingRuleUpdate(dbContext, ref storedLot, ref storedProducedMaterialList, processsegmentruleclsrel2);
		}
		else
		{
			RuleChangeWaitForSegmentUpdate(dbContext, ref storedLot, ref storedProducedMaterialList);
			lotAdhocProcess = GetLotAdhocProcess(dbContext, storedLot, fetchCustomColumns: true);
			if (lotAdhocProcess != null)
			{
				needAdhocProcess = true;
				SegmentChangeNextSegmentUpdateAdhoc(dbContext, lotAdhocProcess, ref storedLot, ref storedProducedMaterialList, workTime);
			}
			else
			{
				SegmentChangeNextSegmentUpdate(dbContext, ref storedLot, ref storedProducedMaterialList, workTime, out needFinishLot, out needFutureAction);
			}
		}
	}

	private static void DispatchWorkLotPREBulk(IDbContext dbContext, Lot[] storedLotList, Producedmaterial[] storedProducedMaterialList, DateTime workTime, out bool needFinishLot)
	{
		needFinishLot = false;
		string siteid = storedLotList[0].Siteid;
		string lotid = storedLotList[0].Lotid;
		_ = storedLotList[0].Processnodeid;
		string processdefinitionid = storedLotList[0].Processdefinitionid;
		string subprocessdefinitionid = storedLotList[0].Subprocessdefinitionid;
		string processsegmentid = storedLotList[0].Processsegmentid;
		string processsegmentruleid = storedLotList[0].Processsegmentruleid;
		int? rulesequence = storedLotList[0].Rulesequence;
		ParamChecker.ArgumentNotNull("currProcessDefinitionId", processdefinitionid);
		ParamChecker.ArgumentNotNull("CurrSubprocessDefinitionId", subprocessdefinitionid);
		ParamChecker.ArgumentNotNull("currProcessSegmentId", processsegmentid);
		ParamChecker.EntityValidState(typeof(Lot), lotid, storedLotList[0].Processingstate, "WaitForRule", "ProcessingRule");
		Processsegmentruleclsrel processsegmentruleclsrel = PROCESSSEGMENTRULECLSREL.SelectProcessSegmentRuleClsRelBySegmentId(dbContext, processsegmentid, processsegmentruleid, siteid);
		if (processsegmentruleclsrel == null)
		{
			throw new EntityNotFoundException(typeof(Processsegmentruleclsrel), "Curr Rule :: " + processsegmentid + ":" + processsegmentruleid);
		}
		if (processsegmentruleclsrel.Isend == "N")
		{
			Processsegmentruleclsrel processsegmentruleclsrel2 = PROCESSSEGMENTRULECLSREL.SelectNextProcessSegmentRule(dbContext, processsegmentid, rulesequence.Value, siteid);
			if (processsegmentruleclsrel2 == null)
			{
				Type typeFromHandle = typeof(Processsegmentruleclsrel);
				string[] array = new string[1];
				int? num = rulesequence;
				array[0] = "Next Rule :: " + processsegmentid + ":" + num;
				throw new EntityNotFoundException(typeFromHandle, array);
			}
			RuleChangeProcessingRuleUpdate(dbContext, ref storedLotList[0], ref storedProducedMaterialList, processsegmentruleclsrel2);
		}
		else
		{
			RuleChangeWaitForSegmentUpdate(dbContext, ref storedLotList[0], ref storedProducedMaterialList);
			SegmentChangeNextSegmentUpdateBulk(dbContext, ref storedLotList[0], ref storedProducedMaterialList, workTime, out needFinishLot);
		}
	}

	private static void RuleChangeProcessingRuleUpdate(IDbContext dbContext, ref Lot storedLot, ref Producedmaterial[] storedProducedMaterialList, Processsegmentruleclsrel nextRule)
	{
		storedLot.Processingstate = "ProcessingRule";
		storedLot.Processsegmentruleid = nextRule.Processsegmentruleid;
		storedLot.Rulesequence = nextRule.Rulesequence;
		Producedmaterial[] array = storedProducedMaterialList;
		foreach (Producedmaterial childProducedMaterial in array)
		{
			PRODUCEDMATERIAL.InheritLotProcessInfo(storedLot, childProducedMaterial);
		}
	}

	private static void RuleChangeWaitForSegmentUpdate(IDbContext dbContext, ref Lot storedLot, ref Producedmaterial[] storedProducedMaterialList)
	{
		storedLot.Processingstate = "WaitForSegment";
		storedLot.Processsegmentruleid = null;
		storedLot.Rulesequence = null;
		Producedmaterial[] array = storedProducedMaterialList;
		foreach (Producedmaterial childProducedMaterial in array)
		{
			PRODUCEDMATERIAL.InheritLotProcessInfo(storedLot, childProducedMaterial);
		}
	}

	private static void SegmentChangeNextSegmentUpdate(IDbContext dbContext, ref Lot storedLot, ref Producedmaterial[] storedProducedMaterialList, DateTime workTime, out bool needFinishLot, out bool needFutureAction)
	{
		_ = storedLot.Lotid;
		string siteid = storedLot.Siteid;
		string processdefinitionid = storedLot.Processdefinitionid;
		string processnodeid = storedLot.Processnodeid;
		needFinishLot = false;
		needFutureAction = false;
		Processnode processnode = null;
		Processnode processnode2 = null;
		if (string.IsNullOrEmpty(storedLot.Nextprocesssegmentid))
		{
			if ((processnode2 = PROCESSNODE.SelectNextSegmentNodeSingle(dbContext, processdefinitionid, processnodeid, "PASS", siteid)) == null)
			{
				if ((processnode = PROCESSNODE.SelectProcessNode(dbContext, processnodeid, siteid)) == null)
				{
					throw new EntityNotFoundException(typeof(Processnode), processnodeid);
				}
				if (processnode.Isendnode == "Y")
				{
					needFinishLot = true;
					return;
				}
				throw new NextNodeNotFoundException(processdefinitionid, processnodeid);
			}
		}
		else if ((processnode2 = PROCESSNODE.SelectNextSegmentNodeSingleBySegment(dbContext, processdefinitionid, processnodeid, storedLot.Nextprocesssegmentid, siteid)) == null)
		{
			throw new NextNodeSegmentNotFoundException(processdefinitionid, processnodeid, storedLot.Nextprocesssegmentid);
		}
		if (processnode2 == null)
		{
			return;
		}
		if (processnode == null && (processnode = PROCESSNODE.SelectProcessNode(dbContext, processnodeid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Processnode), processnodeid);
		}
		if (IsAutoDispatch(dbContext, processdefinitionid, processnode, processnode2, siteid))
		{
			string processnodeid2 = processnode2.Processnodeid;
			string processsegmentid = processnode2.Processsegmentid;
			string processdefinitionid2 = processnode2.Processdefinitionid;
			Processsegmentruleclsrel processsegmentruleclsrel = PROCESSSEGMENTRULECLSREL.SelectFirstProcessSegmentRule(dbContext, processsegmentid, siteid);
			if (processsegmentruleclsrel == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentruleclsrel), processsegmentid);
			}
			storedLot.Processingstate = "WaitForRule";
			storedLot.Processsegmentruleid = processsegmentruleclsrel.Processsegmentruleid;
			storedLot.Rulesequence = processsegmentruleclsrel.Rulesequence;
			storedLot.Prevsubprocessdefinitionid = storedLot.Subprocessdefinitionid;
			storedLot.Subprocessdefinitionid = processdefinitionid2;
			storedLot.Prevprocesssegmentid = storedLot.Processsegmentid;
			storedLot.Processsegmentid = processsegmentid;
			storedLot.Prevprocessnodeid = storedLot.Processnodeid;
			storedLot.Processnodeid = processnodeid2;
			storedLot.Nextprocesssegmentid = null;
			storedLot.Nextsubprocessdefinitionid = null;
			storedLot.Receivedtime = EntityHelper.FirstNotNull<DateTime>(storedLot.Modifytime, workTime);
			Producedmaterial[] array = storedProducedMaterialList;
			foreach (Producedmaterial childProducedMaterial in array)
			{
				PRODUCEDMATERIAL.InheritLotProcessInfo(storedLot, childProducedMaterial);
			}
			if (LOTFUTUREACTION.GetLotFutureActionCountCurrentSegmentRule(dbContext, storedLot) > 0)
			{
				needFutureAction = true;
			}
		}
	}

	private static void SegmentChangeNextSegmentUpdateBulk(IDbContext dbContext, ref Lot storedLot, ref Producedmaterial[] storedProducedMaterialList, DateTime workTime, out bool needFinishLot)
	{
		_ = storedLot.Lotid;
		string siteid = storedLot.Siteid;
		string processdefinitionid = storedLot.Processdefinitionid;
		string processnodeid = storedLot.Processnodeid;
		needFinishLot = false;
		Processnode processnode = null;
		Processnode processnode2 = null;
		if (string.IsNullOrEmpty(storedLot.Nextprocesssegmentid))
		{
			if ((processnode2 = PROCESSNODE.SelectNextSegmentNodeSingle(dbContext, processdefinitionid, processnodeid, "PASS", siteid)) == null)
			{
				if ((processnode = PROCESSNODE.SelectProcessNode(dbContext, processnodeid, siteid)) == null)
				{
					throw new EntityNotFoundException(typeof(Processnode), processnodeid);
				}
				if (processnode.Isendnode == "Y")
				{
					needFinishLot = true;
					return;
				}
				throw new NextNodeNotFoundException(processdefinitionid, processnodeid);
			}
		}
		else if ((processnode2 = PROCESSNODE.SelectNextSegmentNodeSingleBySegment(dbContext, processdefinitionid, processnodeid, storedLot.Nextprocesssegmentid, siteid)) == null)
		{
			throw new NextNodeSegmentNotFoundException(processdefinitionid, processnodeid, storedLot.Nextprocesssegmentid);
		}
		if (processnode2 == null)
		{
			return;
		}
		if (processnode == null && (processnode = PROCESSNODE.SelectProcessNode(dbContext, processnodeid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Processnode), processnodeid);
		}
		if (IsAutoDispatch(dbContext, processdefinitionid, processnode, processnode2, siteid))
		{
			string processnodeid2 = processnode2.Processnodeid;
			string processsegmentid = processnode2.Processsegmentid;
			string processdefinitionid2 = processnode2.Processdefinitionid;
			Processsegmentruleclsrel processsegmentruleclsrel = PROCESSSEGMENTRULECLSREL.SelectFirstProcessSegmentRule(dbContext, processsegmentid, siteid);
			if (processsegmentruleclsrel == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentruleclsrel), processsegmentid);
			}
			storedLot.Processingstate = "WaitForRule";
			storedLot.Processsegmentruleid = processsegmentruleclsrel.Processsegmentruleid;
			storedLot.Rulesequence = processsegmentruleclsrel.Rulesequence;
			storedLot.Prevsubprocessdefinitionid = storedLot.Subprocessdefinitionid;
			storedLot.Subprocessdefinitionid = processdefinitionid2;
			storedLot.Prevprocesssegmentid = storedLot.Processsegmentid;
			storedLot.Processsegmentid = processsegmentid;
			storedLot.Prevprocessnodeid = storedLot.Processnodeid;
			storedLot.Processnodeid = processnodeid2;
			storedLot.Nextprocesssegmentid = null;
			storedLot.Nextsubprocessdefinitionid = null;
			storedLot.Trackintime = null;
			storedLot.Trackinuser = null;
			storedLot.Trackouttime = null;
			storedLot.Trackoutuser = null;
			storedLot.Receivedtime = EntityHelper.FirstNotNull<DateTime>(storedLot.Modifytime, workTime);
			Producedmaterial[] array = storedProducedMaterialList;
			foreach (Producedmaterial childProducedMaterial in array)
			{
				PRODUCEDMATERIAL.InheritLotProcessInfo(storedLot, childProducedMaterial);
			}
		}
	}

	private static void SegmentChangeNextSegmentUpdateAdhoc(IDbContext dbContext, Lotadhocprocess lotAdhocProcess, ref Lot storedLot, ref Producedmaterial[] storedProducedMaterialList, DateTime workTime)
	{
		_ = storedLot.Lotid;
		string siteid = storedLot.Siteid;
		_ = storedLot.Processdefinitionid;
		_ = storedLot.Processnodeid;
		Processsegment processsegment;
		if ((processsegment = PROCESSSEGMENT.SelectProcessSegment(dbContext, lotAdhocProcess.Returnprocesssegmentid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Lotadhocprocess), storedLot.Adhocprocesssysid);
		}
		Processsegmentruleclsrel processsegmentruleclsrel;
		if ((processsegmentruleclsrel = PROCESSSEGMENTRULECLSREL.SelectFirstProcessSegmentRuleByRuleCls(dbContext, processsegment.Processsegmentruleclsid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Processsegmentruleclsrel), processsegment.Processsegmentruleclsid);
		}
		Processnode processnode;
		if ((processnode = PROCESSNODE.SelectProcessSegmentNode(dbContext, lotAdhocProcess.Returnprocessdefinitionid, lotAdhocProcess.Returnsubprocessdefinitionid, lotAdhocProcess.Returnprocesssegmentid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Processnode), lotAdhocProcess.Returnprocessdefinitionid + ":" + lotAdhocProcess.Returnsubprocessdefinitionid + ":" + lotAdhocProcess.Returnprocesssegmentid);
		}
		storedLot.Prevprocessdefinitionid = storedLot.Processdefinitionid;
		storedLot.Processdefinitionid = lotAdhocProcess.Returnprocessdefinitionid;
		storedLot.Prevsubprocessdefinitionid = storedLot.Subprocessdefinitionid;
		storedLot.Subprocessdefinitionid = lotAdhocProcess.Returnsubprocessdefinitionid;
		storedLot.Prevprocesssegmentid = storedLot.Processsegmentid;
		storedLot.Processsegmentid = lotAdhocProcess.Returnprocesssegmentid;
		storedLot.Prevprocessnodeid = storedLot.Processnodeid;
		storedLot.Processnodeid = processnode.Processnodeid;
		storedLot.Nextprocesssegmentid = null;
		storedLot.Nextsubprocessdefinitionid = null;
		storedLot.Processingstate = "WaitForRule";
		storedLot.Processsegmentruleid = processsegmentruleclsrel.Processsegmentruleid;
		storedLot.Rulesequence = processsegmentruleclsrel.Rulesequence;
		storedLot.Receivedtime = EntityHelper.FirstNotNull<DateTime>(storedLot.Modifytime, workTime);
		if (storedLot.Location != lotAdhocProcess.Returnlocation)
		{
			storedLot.Prevlocation = storedLot.Location;
			storedLot.Location = lotAdhocProcess.Returnlocation;
		}
		Producedmaterial[] array = storedProducedMaterialList;
		foreach (Producedmaterial childProducedMaterial in array)
		{
			PRODUCEDMATERIAL.InheritLotProcessInfo(storedLot, childProducedMaterial);
		}
	}

	public static int FinishLot(IDbContext dbContext, Lot[] lotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotList", lotList);
		ParamChecker.ArgumentNotNull("TID", dbContext.Tid);
		string text = "FinishLot";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		string siteid = lotList[0].Siteid;
		List<Producedmaterial> list3 = new List<Producedmaterial>();
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		Lot[] array2 = array;
		foreach (Lot lot in array2)
		{
			Producedmaterial[] array3 = PRODUCEDMATERIAL.SelectProducedMaterialListAliveByLot4Update(dbContext, lot.Lotid, siteid).ToArray();
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lot.Lotid} ProducedMaterial Count={array3.Length}");
			}
			list3.AddRange(array3);
		}
		array2 = lotList;
		foreach (Lot lot2 in array2)
		{
			ParamChecker.ArgumentNotNull("Lotid", lot2.Lotid);
			ParamChecker.ArgumentNotNull("Siteid", lot2.Siteid);
			string lotid = lot2.Lotid;
			DateTime? lotfinishedtime = EntityHelper.FirstNotNull<DateTime?>(lot2.Lotfinishedtime, lot2.Modifytime, systemTime);
			Lot lot3;
			if ((lot3 = FindLot(array, lotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lot), lotid);
			}
			if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot3))
			{
				throw new EntityIsHoldException(typeof(Lot), lotid);
			}
			ParamChecker.EntityInvalidState(typeof(Lot), "State", lot3.State, "Finished");
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", $"Lotid={lot3.Lotid} Prevstate={lot3.Prevstate} State={lot3.State} Lotfinishedtime={lot3.Lotfinishedtime}");
			}
			lot3.Lotfinishedtime = lotfinishedtime;
			lot3.Prevstate = lot3.State;
			lot3.State = "Finished";
			lot2.CopyCommonFieldUpdatePrev(lot3, systemTime, tid, text);
			lot2.CopyExtensionCollection(lot3);
			list.Add(lot3);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", $"Lotid={lot3.Lotid} Prevstate={lot3.Prevstate} State={lot3.State} Lotfinishedtime={lot3.Lotfinishedtime}");
			}
			foreach (Producedmaterial item in PRODUCEDMATERIAL.FindProducedMaterialList(list3.ToArray(), lotid))
			{
				if (!PRODUCEDMATERIAL.ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, item))
				{
					throw new EntityIsHoldException(typeof(Producedmaterial), item.Producedmaterialid);
				}
				ParamChecker.EntityInvalidState(typeof(Producedmaterial), "State", item.State, "Shipped");
				if (MesLogger.IsDebugEnabled("API"))
				{
					MesLogger.DebugTidApi(tid, "Before Execute", $"Producedmaterialid={item.Lotid} Prevstate={item.Prevstate} State={item.State} Lotfinishedtime={item.Lotfinishedtime}");
				}
				item.Lotfinishedtime = lotfinishedtime;
				item.Prevstate = item.State;
				item.State = "Finished";
				item.CopyCommonFieldUpdatePrev(item, systemTime, tid, text);
				list2.Add(item);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={item.Lotid} Prevstate={item.Prevstate} State={item.State} Lotfinishedtime={item.Lotfinishedtime}");
				}
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int FinishLotBulk(IDbContext dbContext, Lot[] lotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		object[] objectList = lotList;
		ParamChecker.ArgumentNotNullAndHasElement("lotList", objectList);
		ParamChecker.ArgumentNotNull("TID", dbContext.Tid);
		string text = "FinishLot";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		new List<Producedmaterial>();
		string[] first = ExtractIdOrderBy(lotList);
		string siteid = lotList[0].Siteid;
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		if (lotList.Length > array.Length)
		{
			throw new EntityNotFoundException(typeof(Lot), first.Except(ExtractIdOrderBy(array.ToArray())).ToString());
		}
		Producedmaterial[] array2 = PRODUCEDMATERIAL.SelectProducedMaterialListByLotWithNotState4BulkUpdate(dbContext, array, new string[2] { "Scrapped", "Terminated" }, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={EntityHelper.ConcatString4InClause(ExtractIdOrderBy(array))} ProducedMaterial Count={array2.Length}");
		}
		list2.AddRange(array2);
		objectList = ExtractIdOrderBy(lotList);
		ParamChecker.ArgumentNotNull("Lotid", objectList);
		ParamChecker.ArgumentNotNull("Siteid", siteid);
		DateTime? lotfinishedtime = EntityHelper.FirstNotNull<DateTime?>(array[0].Lotfinishedtime, array[0].Modifytime, systemTime);
		IList<Lot> list3 = SelectLotListAlive4Update(dbContext, array, siteid);
		if (array.Length > list3.Count)
		{
			throw new EntityNotFoundException(typeof(Lot), first.Except(ExtractIdOrderBy(list3.ToArray())).ToString());
		}
		if (!ValidateAllowHoldLotBulk(dbContext, text, apiVersion, array))
		{
			Lot[] lotList2 = array.Where((Lot v) => v.Ishold == "Y").ToArray();
			throw new EntityIsHoldException(typeof(Lot), EntityHelper.ConcatString4InClause(ExtractIdOrderBy(lotList2)));
		}
		if ((from p in array
			select p.State into id
			orderby id
			select id).Distinct().ToArray().Length > 1)
		{
			throw new Exception("Lot의 상태가 Finish할 수 있는 상태가 아님");
		}
		ParamChecker.EntityInvalidState(typeof(Lot), "State", array[0].State, "Finished");
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", $"Lotid={EntityHelper.ConcatString4InClause((from p in array
				select p.Lotid into id
				orderby id
				select id).ToArray())} Prevstate={EntityHelper.ConcatString4InClause((from p in array
				select p.Prevstate into id
				orderby id
				select id).ToArray())} State={EntityHelper.ConcatString4InClause((from p in array
				select p.State into id
				orderby id
				select id).ToArray())} Lotfinishedtime={EntityHelper.ConcatString4InClause((from p in array
				select p.Lotfinishedtime.ToString() into id
				orderby id
				select id).ToArray())}");
		}
		Lot obj = lotList[0];
		array[0].Lotfinishedtime = lotfinishedtime;
		array[0].Prevstate = array[0].State;
		array[0].State = "Finished";
		obj.CopyCommonFieldUpdatePrev(array[0], systemTime, tid, text);
		obj.CopyExtensionCollection(array[0]);
		list.Add(array[0]);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", $"Lotid={EntityHelper.ConcatString4InClause((from p in array
				select p.Lotid into id
				orderby id
				select id).ToArray())} Prevstate={EntityHelper.ConcatString4InClause((from p in array
				select p.Prevstate into id
				orderby id
				select id).ToArray())} State={EntityHelper.ConcatString4InClause((from p in array
				select p.State into id
				orderby id
				select id).ToArray())} Lotfinishedtime={EntityHelper.ConcatString4InClause((from p in array
				select p.Lotfinishedtime.ToString() into id
				orderby id
				select id).ToArray())}");
		}
		if (array2.Length != 0)
		{
			if (!PRODUCEDMATERIAL.ValidateAllowHoldProducedMaterialBulk(dbContext, text, apiVersion, array2))
			{
				Producedmaterial[] source = array2.Where((Producedmaterial v) => v.Ishold == "Y").ToArray();
				throw new EntityIsHoldException(typeof(Producedmaterial), EntityHelper.ConcatString4InClause((from p in source
					select p.Producedmaterialid into id
					orderby id
					select id).ToArray()));
			}
			ParamChecker.EntityInvalidState(typeof(Producedmaterial), "State", array2[0].State, "Shipped");
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", $"Producedmaterialid={EntityHelper.ConcatString4InClause((from p in array2
					select p.Lotid into id
					orderby id
					select id).ToArray())} Prevstate={EntityHelper.ConcatString4InClause((from p in array2
					select p.Prevstate into id
					orderby id
					select id).ToArray())} State={EntityHelper.ConcatString4InClause((from p in array2
					select p.State into id
					orderby id
					select id).ToArray())} Lotfinishedtime={EntityHelper.ConcatString4InClause((from p in array2
					select p.Lotfinishedtime.ToString() into id
					orderby id
					select id).ToArray())}");
			}
			array2[0].Lotfinishedtime = lotfinishedtime;
			array2[0].Prevstate = array2[0].State;
			array2[0].State = "Finished";
			array2[0].CopyCommonFieldUpdatePrev(array2[0], systemTime, tid, text);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={EntityHelper.ConcatString4InClause((from p in array2
					select p.Lotid into id
					orderby id
					select id).ToArray())} Prevstate={EntityHelper.ConcatString4InClause((from p in array2
					select p.Prevstate into id
					orderby id
					select id).ToArray())} State={EntityHelper.ConcatString4InClause((from p in array2
					select p.State into id
					orderby id
					select id).ToArray())} Lotfinishedtime={EntityHelper.ConcatString4InClause((from p in array2
					select p.Lotfinishedtime.ToString() into id
					orderby id
					select id).ToArray())}");
			}
		}
		num += ContextManager.BulkUpdateEntityFullColumn(dbContext, array[0], array, null, saveHist);
		num += ContextManager.BulkUpdateEntityFullColumn(dbContext, array2[0], array2, null, saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int HoldLot(IDbContext dbContext, Lot lot, Lothold[] lotHoldList, IOptionSet optionSet, bool saveLotHist, bool saveHoldHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotHoldList", lotHoldList);
		string text = "HoldLot";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		ParamChecker.ArgumentNotNull("lot", lot);
		ParamChecker.ArgumentNotNull("Lotid", lot.Lotid);
		ParamChecker.ArgumentNotNull("Siteid", lot.Siteid);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		List<Lothold> list3 = new List<Lothold>();
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		string lotid = lot.Lotid;
		string siteid = lot.Siteid;
		Lot lot2;
		if ((lot2 = SelectLot4Update(dbContext, lotid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Lot), lotid);
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", lot2);
		}
		Producedmaterial[] array = PRODUCEDMATERIAL.SelectProducedMaterialListAliveByLot4Update(dbContext, lotid, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTid(tid, "Select4Update", $"Lotid={lot2.Lotid} ProducedMaterial Count={array.Length}");
		}
		if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot))
		{
			throw new EntityIsHoldException(typeof(Lot), lot.Lotid);
		}
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", $"Lotid={lot2.Lotid} Ishold={lot2.Ishold}");
		}
		lot2.Ishold = "Y";
		lot.CopyCommonFieldUpdatePrev(lot2, systemTime, tid, text);
		lot.CopyExtensionCollection(lot2);
		list.Add(lot2);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", $"Lotid={lot2.Lotid} Ishold={lot2.Ishold}");
		}
		Producedmaterial[] array2 = array;
		foreach (Producedmaterial producedmaterial in array2)
		{
			_ = producedmaterial.Producedmaterialid;
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", $"Producedmaterialid={producedmaterial.Producedmaterialid} Ishold={producedmaterial.Ishold}");
			}
			producedmaterial.Ishold = "Y";
			lot.CopyCommonFieldUpdatePrev(producedmaterial, systemTime, tid, text);
			list2.Add(producedmaterial);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={producedmaterial.Producedmaterialid} Ishold={producedmaterial.Ishold}");
			}
		}
		ParamCheckSameHoldCodeExist(lotHoldList);
		foreach (Lothold lothold in lotHoldList)
		{
			ParamChecker.ArgumentNotNull("Lotid", lothold.Lotid);
			ParamChecker.ArgumentNotNull("Holdcode", lothold.Holdcode);
			string holdcode = lothold.Holdcode;
			if (lotid != lothold.Lotid)
			{
				throw new ArgumentException("Both lot id's is different.");
			}
			Lothold lothold2 = new Lothold();
			lothold.CopyColumsTo(lothold2);
			lothold2.Lotid = lotid;
			lothold2.Siteid = siteid;
			lothold2.Holdcode = holdcode;
			lothold2.Processnodeid = EntityHelper.FirstNotNull<string>(lothold.Processnodeid, lot2.Processnodeid);
			lothold2.Repeatcount = lot2.Repeatcount;
			lothold2.Productdefinitionid = EntityHelper.FirstNotNull<string>(lothold.Productdefinitionid, lot2.Productdefinitionid);
			lothold2.Processdefinitionid = EntityHelper.FirstNotNull<string>(lothold.Processdefinitionid, lot2.Processdefinitionid);
			lothold2.Subprocessdefinitionid = EntityHelper.FirstNotNull<string>(lothold.Subprocessdefinitionid, lot2.Subprocessdefinitionid);
			lothold2.Processsegmentid = EntityHelper.FirstNotNull<string>(lothold.Processsegmentid, lot2.Processsegmentid);
			lothold2.Equipmentid = EntityHelper.FirstNotNull<string>(lothold.Equipmentid, lot2.Equipmentid);
			lothold2.Alarmid = lothold.Alarmid;
			lothold2.Prevactivity = null;
			lothold2.Activity = text;
			lothold2.Isusable = "Usable";
			lothold2.Siteid = siteid;
			lothold.CopyCommonField(lothold2, systemTime, tid, isCreate: true);
			lothold2.Customactivity = EntityHelper.FirstNotNull<string>(lothold.Customactivity, lothold2.Activity);
			list3.Add(lothold2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", $"Lotid={lothold2.Lotid} Holdcode={lothold2.Holdcode}");
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveLotHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveLotHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list3.ToArray(), saveHoldHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static void ParamCheckSameHoldCodeExist(Lothold[] lotHoldList)
	{
		List<string> list = new List<string>();
		foreach (Lothold lothold in lotHoldList)
		{
			ParamChecker.ArgumentNotNull("hold", lothold);
			ParamChecker.ArgumentNotNull("holdcode", lothold.Holdcode);
			string holdcode = lothold.Holdcode;
			if (list.Contains(holdcode))
			{
				throw new DuplicatedHoldCodeExistException(holdcode);
			}
			list.Add(holdcode);
		}
	}

	internal static void ValidateParameterProducedMaterial(string apiName, string lotId, Producedmaterial[] inputProducedMaterialList, Producedmaterial[] storedProducedMaterialList)
	{
		if (inputProducedMaterialList == null || inputProducedMaterialList.Length == 0)
		{
			throw new NotEnoughParameterProducedMaterialException(apiName, lotId);
		}
		if (storedProducedMaterialList == null || storedProducedMaterialList.Length == 0)
		{
			throw new LotHasNoProducedMaterialException(apiName, lotId);
		}
		Producedmaterial[] array = inputProducedMaterialList;
		foreach (Producedmaterial input2 in array)
		{
			if (storedProducedMaterialList.FirstOrDefault((Producedmaterial stored) => stored.Producedmaterialid == input2.Producedmaterialid && stored.Siteid == input2.Siteid) == null)
			{
				throw new TooManyParameterProducedMaterialException(apiName, lotId, input2.Producedmaterialid);
			}
		}
		array = storedProducedMaterialList;
		foreach (Producedmaterial stored2 in array)
		{
			if (inputProducedMaterialList.FirstOrDefault((Producedmaterial input) => input.Producedmaterialid == stored2.Producedmaterialid && input.Siteid == stored2.Siteid) == null)
			{
				throw new NotEnoughStoredProducedMaterialException(apiName, lotId, stored2.Producedmaterialid);
			}
		}
	}

	public static decimal GetLotQty(IDbContext dbContext, string[] countableProducedMaterialGradeIdList, Producedmaterial[] producedMaterialList)
	{
		ParamChecker.ArgumentNotNullAndHasElement("producedMaterialList", producedMaterialList);
		_ = producedMaterialList[0].Siteid;
		decimal result = default(decimal);
		foreach (Producedmaterial producedmaterial in producedMaterialList)
		{
			if (!(producedmaterial.State == "Scrapped") && !(producedmaterial.State == "Terminated") && countableProducedMaterialGradeIdList.Contains(producedmaterial.Grade))
			{
				++result;
			}
		}
		return result;
	}

	public static decimal GetSubProducedMaterialQty(IDbContext dbContext, string[] countableSubproducedMaterialGradeIdList, Producedmaterial[] producedMaterialList)
	{
		ParamChecker.ArgumentNotNullAndHasElement("producedMaterialList", producedMaterialList);
		_ = producedMaterialList[0].Siteid;
		decimal result = default(decimal);
		foreach (Producedmaterial producedmaterial in producedMaterialList)
		{
			if (producedmaterial.State == "Scrapped" || producedmaterial.State == "Terminated" || string.IsNullOrEmpty(producedmaterial.Submaterialgrade))
			{
				continue;
			}
			string[] array = Array.ConvertAll(producedmaterial.Submaterialgrade.ToCharArray(), (char ch) => ch.ToString());
			foreach (string value in array)
			{
				if (countableSubproducedMaterialGradeIdList.Contains(value))
				{
					++result;
				}
			}
		}
		return result;
	}

	public static string[] getCountableProducedMaterialGradeIdList(IDbContext dbContext, string siteId)
	{
		IList<string> list = GRADEDEFINITION.SelectCountableGradeIdList(dbContext, "Producedmaterial", siteId);
		if (list == null)
		{
			return new string[0];
		}
		return list.ToArray();
	}

	public static string[] getCountableSubproducedMaterialGradeIdList(IDbContext dbContext, string siteId)
	{
		IList<string> list = GRADEDEFINITION.SelectCountableGradeIdList(dbContext, "Subproducedmaterial", siteId);
		if (list == null)
		{
			return new string[0];
		}
		return list.ToArray();
	}

	internal static void UpdateUserColumns(string activity, Lot input, Lot stored)
	{
		stored.Customerid = input.Customerid;
		stored.Defectqty = input.Defectqty;
		stored.Duedate = input.Duedate;
		stored.Lotname = input.Lotname;
		stored.Portid = input.Portid;
		stored.Priority = input.Priority;
		stored.Processendtime = input.Processendtime;
		stored.Processingspeed = input.Processingspeed;
		stored.Processstarttime = input.Processstarttime;
		stored.Processstepid = input.Processstepid;
		stored.Productorderid = input.Productorderid;
		stored.Receivedtime = input.Receivedtime;
		stored.Replotid = input.Replotid;
		stored.Reservedequipmentid = input.Reservedequipmentid;
		stored.Sourcebatchid = input.Sourcebatchid;
		stored.Sourceinputid = input.Sourceinputid;
		stored.Trackintime = input.Trackintime;
		stored.Trackinuser = input.Trackinuser;
		stored.Trackouttime = input.Trackouttime;
		stored.Trackoutuser = input.Trackoutuser;
		stored.Unitid = input.Unitid;
		stored.Vendorid = input.Vendorid;
		stored.Workorderid = input.Workorderid;
		if (stored.Grade != input.Grade)
		{
			stored.Prevgrade = stored.Grade;
			stored.Grade = input.Grade;
		}
		if (stored.Equipmentid != input.Equipmentid)
		{
			stored.Prevequipmentid = stored.Equipmentid;
			stored.Equipmentid = input.Equipmentid;
		}
		if (stored.Location != input.Location)
		{
			stored.Prevlocation = stored.Location;
			stored.Location = input.Location;
		}
		if (stored.Producttype != input.Producttype)
		{
			stored.Prevproducttype = stored.Producttype;
			stored.Producttype = input.Producttype;
		}
		if (stored.Materialtype != input.Materialtype)
		{
			stored.Prevmaterialtype = stored.Materialtype;
			stored.Materialtype = input.Materialtype;
		}
		if (stored.Submaterialtype != input.Submaterialtype)
		{
			stored.Prevsubmaterialtype = stored.Submaterialtype;
			stored.Submaterialtype = input.Submaterialtype;
		}
		if (!(stored.Lossqty == input.Lossqty))
		{
			stored.Prevlossqty = stored.Lossqty;
			stored.Lossqty = input.Lossqty;
		}
		if (!(stored.Qty == input.Qty))
		{
			stored.Prevqty = stored.Qty;
			stored.Qty = input.Qty;
		}
		if (!(stored.Submaterialqty == input.Submaterialqty))
		{
			stored.Prevsubmaterialqty = stored.Submaterialqty;
			stored.Submaterialqty = input.Submaterialqty;
		}
		if (stored.Recipedefinitionid != input.Recipedefinitionid)
		{
			stored.Prevrecipedefinitionid = stored.Recipedefinitionid;
			stored.Recipedefinitionid = input.Recipedefinitionid;
		}
	}

	public static Lot GetLot(IDbContext dbContext, string lotid, string siteid)
	{
		string apiName = "GetLot";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLotSqlDatabase : _sqlGetLotOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOT", $"{lotid},{siteid}"));
		}
		Lot? result = ContextManager.DirectEntityQuery<Lot>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{siteid}");
		}
		return result;
	}

	public static Lot GetLot4Update(IDbContext dbContext, string lotid, string siteid)
	{
		string apiName = "GetLot4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLot4UpdateSqlDatabase : _sqlGetLot4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_LOT", $"{lotid},{siteid}"));
		}
		Lot? result = ContextManager.DirectEntityQuery<Lot>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{siteid}");
		}
		return result;
	}

	public static Lot SelectLot(IDbContext dbContext, string lotid, string siteid)
	{
		string apiName = "SelectLot";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotSqlDatabase : _sqlSelectLotOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOT", $"{lotid},{siteid}"));
		}
		Lot? result = ContextManager.DirectEntityQuery<Lot>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{siteid}");
		}
		return result;
	}

	public static Lot SelectLot4Update(IDbContext dbContext, string lotid, string siteid)
	{
		string apiName = "SelectLot4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLot4UpdateSqlDatabase : _sqlSelectLot4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_LOT", $"{lotid},{siteid}"));
		}
		Lot? result = ContextManager.DirectEntityQuery<Lot>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{siteid}");
		}
		return result;
	}

	public static IList<Lot> SelectLotList(IDbContext dbContext, Lot[] lotList, string siteId)
	{
		string apiName = "SelectLotList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotList.Length},{siteId}");
		}
		string value = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotListSqlDatabase : _sqlSelectLotListOracleDatabase);
		value = new StringBuilder(value, 1000).Replace("&LOTIDLIST", EntityHelper.ConcatString4InClause(ExtractIdOrderBy(lotList))).ToString();
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOT", $"{lotList.Length},{siteId}"));
		}
		IList<Lot> result = ContextManager.DirectEntityQuery<Lot>(dbContext, value, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotList.Length},{siteId}");
		}
		return result;
	}

	public static IList<Lot> SelectLotList4Update(IDbContext dbContext, Lot[] lotList, string siteId)
	{
		string apiName = "SelectLotList4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotList.Length},{siteId}");
		}
		string value = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotList4UpdateSqlDatabase : _sqlSelectLotList4UpdateOracleDatabase);
		value = new StringBuilder(value, 1000).Replace("&LOTIDLIST", EntityHelper.ConcatString4InClause(ExtractIdOrderBy(lotList))).ToString();
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_LOT", $"{lotList.Length},{siteId}"));
		}
		IList<Lot> result = ContextManager.DirectEntityQuery<Lot>(dbContext, value, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotList.Length},{siteId}");
		}
		return result;
	}

	public static IList<Lot> SelectLotListAlive(IDbContext dbContext, Lot[] lotList, string siteId)
	{
		string apiName = "SelectLotListAlive";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotList.Length},{siteId}");
		}
		IList<Lot> result = SelectLotListWithNotState(dbContext, lotList, new string[2] { "Scrapped", "Terminated" }, siteId);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotList.Length},{siteId}");
		}
		return result;
	}

	public static IList<Lot> SelectLotListAlive4Update(IDbContext dbContext, Lot[] lotList, string siteId)
	{
		string apiName = "SelectLotListAlive4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotList.Length},{siteId}");
		}
		IList<Lot> result = SelectLotListWithNotState4Update(dbContext, lotList, new string[2] { "Scrapped", "Terminated" }, siteId);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotList.Length},{siteId}");
		}
		return result;
	}

	public static IList<Lot> SelectLotListWithNotState(IDbContext dbContext, Lot[] lotList, string[] invalidStateList, string siteId)
	{
		string apiName = "SelectLotListWithNotState";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotList.Length},{siteId}");
		}
		string value = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotListWithNotStateSqlDatabase : _sqlSelectLotListWithNotStateOracleDatabase);
		value = new StringBuilder(value, 1000).Replace("&LOTIDLIST", EntityHelper.ConcatString4InClause(ExtractIdOrderBy(lotList))).Replace("&STATE", EntityHelper.ConcatString4InClause(invalidStateList)).ToString();
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOT", $"{lotList.Length},{siteId}"));
		}
		IList<Lot> result = ContextManager.DirectEntityQuery<Lot>(dbContext, value, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotList.Length},{siteId}");
		}
		return result;
	}

	public static IList<Lot> SelectLotListWithNotState4Update(IDbContext dbContext, Lot[] lotList, string[] invalidStateList, string siteId)
	{
		string apiName = "SelectLotListWithNotState4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotList.Length},{siteId}");
		}
		string value = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotListWithNotState4UpdateSqlDatabase : _sqlSelectLotListWithNotState4UpdateOracleDatabase);
		value = new StringBuilder(value, 1000).Replace("&LOTIDLIST", EntityHelper.ConcatString4InClause(ExtractIdOrderBy(lotList))).Replace("&STATE", EntityHelper.ConcatString4InClause(invalidStateList)).ToString();
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_LOT", $"{lotList.Length},{siteId}"));
		}
		IList<Lot> result = ContextManager.DirectEntityQuery<Lot>(dbContext, value, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotList.Length},{siteId}");
		}
		return result;
	}

	public static IList<Lot> SelectLotListWithState(IDbContext dbContext, Lot[] lotList, string[] validStateList, string siteId)
	{
		string apiName = "SelectLotListWithState";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotList.Length},{siteId}");
		}
		string value = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotListWithStateSqlDatabase : _sqlSelectLotListWithStateOracleDatabase);
		value = new StringBuilder(value, 1000).Replace("&LOTIDLIST", EntityHelper.ConcatString4InClause(ExtractIdOrderBy(lotList))).Replace("&STATE", EntityHelper.ConcatString4InClause(validStateList)).ToString();
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOT", $"{lotList.Length},{siteId}"));
		}
		IList<Lot> result = ContextManager.DirectEntityQuery<Lot>(dbContext, value, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotList.Length},{siteId}");
		}
		return result;
	}

	public static IList<Lot> SelectLotListWithState4Update(IDbContext dbContext, Lot[] lotList, string[] validStateList, string siteId)
	{
		string apiName = "SelectLotListWithState4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotList.Length},{siteId}");
		}
		string value = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotListWithState4UpdateSqlDatabase : _sqlSelectLotListWithState4UpdateOracleDatabase);
		value = new StringBuilder(value, 1000).Replace("&LOTIDLIST", EntityHelper.ConcatString4InClause(ExtractIdOrderBy(lotList))).Replace("&STATE", EntityHelper.ConcatString4InClause(validStateList)).ToString();
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_LOT", $"{lotList.Length},{siteId}"));
		}
		IList<Lot> result = ContextManager.DirectEntityQuery<Lot>(dbContext, value, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotList.Length},{siteId}");
		}
		return result;
	}

	public static int UpsertLot(IDbContext dbContext, RequestType requestType, Lot[] lotList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateLotInternal(dbContext, lotList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateLot(dbContext, lotList, optionSet, saveHist), 
			RequestType.DELETE => DeleteLot(dbContext, lotList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteLot(dbContext, lotList, optionSet, saveHist), 
			_ => RealDeleteLot(dbContext, lotList, optionSet, saveHist), 
		};
	}

	private static int CreateLotInternal(IDbContext dbContext, Lot[] lotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotList", lotList);
		string text = "CreateLot";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		foreach (Lot obj in lotList)
		{
			Lot lot = new Lot();
			obj.CopyColumsTo(lot);
			lot.Activity = text;
			lot.CheckEntityUsable();
			obj.CopyCommonField(lot, systemTime, dbContext.Tid, isCreate: true);
			list.Add(lot);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateLot(IDbContext dbContext, Lot[] lotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotList", lotList);
		string text = "UpdateLot";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		foreach (Lot lot in lotList)
		{
			Lot lot4Update = GetLot4Update(dbContext, lot.Lotid, lot.Siteid);
			if (lot4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lot), $"{lot.Lotid},{lot.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Lot), $"{lot.Lotid},{lot.Siteid}", lot4Update.Isusable);
			string activity = lot4Update.Activity;
			string customactivity = lot4Update.Customactivity;
			string isusable = lot4Update.Isusable;
			DateTime? createtime = lot4Update.Createtime;
			string creator = lot4Update.Creator;
			lot.CopyColumsTo(lot4Update);
			lot4Update.Prevactivity = activity;
			lot4Update.Prevcustomactivity = customactivity;
			lot4Update.Creator = creator;
			lot4Update.Createtime = createtime;
			lot4Update.Isusable = isusable;
			lot4Update.Activity = text;
			lot.CopyCommonField(lot4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(lot4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteLot(IDbContext dbContext, Lot[] lotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotList", lotList);
		string text = "DeleteLot";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		foreach (Lot lot in lotList)
		{
			Lot lot4Update = GetLot4Update(dbContext, lot.Lotid, lot.Siteid);
			if (lot4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lot), $"{lot.Lotid},{lot.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Lot), $"{lot.Lotid},{lot.Siteid}", lot4Update.Isusable);
			lot4Update.Isusable = "UnUsable";
			lot.CopyCommonFieldUpdatePrev(lot4Update, systemTime, dbContext.Tid, text);
			lot.CopyExtensionCollection(lot4Update);
			list.Add(lot4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteLot(IDbContext dbContext, Lot[] lotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotList", lotList);
		string text = "UnDeleteLot";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		foreach (Lot lot in lotList)
		{
			Lot lot4Update = GetLot4Update(dbContext, lot.Lotid, lot.Siteid);
			if (lot4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lot), $"{lot.Lotid},{lot.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Lot), $"{lot.Lotid},{lot.Siteid}", lot4Update.Isusable);
			lot4Update.Isusable = "Usable";
			lot.CopyCommonFieldUpdatePrev(lot4Update, systemTime, dbContext.Tid, text);
			lot.CopyExtensionCollection(lot4Update);
			list.Add(lot4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteLot(IDbContext dbContext, Lot[] lotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotList", lotList);
		string text = "RealDeleteLot";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		foreach (Lot lot in lotList)
		{
			Lot lot4Update = GetLot4Update(dbContext, lot.Lotid, lot.Siteid);
			if (lot4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lot), $"{lot.Lotid},{lot.Siteid}");
			}
			lot.CopyCommonFieldUpdatePrev(lot4Update, systemTime, dbContext.Tid, text);
			lot.CopyExtensionCollection(lot4Update);
			list.Add(lot4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int UpsertLotBulk(IDbContext dbContext, RequestType requestType, Lot[] lotList, LotUpsertOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateLotInternalBulk(dbContext, lotList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateLotBulk(dbContext, lotList, optionSet, saveHist), 
			RequestType.DELETE => DeleteLotBulk(dbContext, lotList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteLotBulk(dbContext, lotList, optionSet, saveHist), 
			_ => RealDeleteLotBulk(dbContext, lotList, optionSet, saveHist), 
		};
	}

	private static int CreateLotInternalBulk(IDbContext dbContext, Lot[] lotList, LotUpsertOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotList", lotList);
		string text = "CreateLotBulk";
		string tid = dbContext.Tid;
		_ = optionSet?.BulkColumnList;
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		string[] first = ExtractIdOrderBy(lotList);
		string siteid = lotList[0].Siteid;
		int num = 0;
		List<Lot> list = new List<Lot>();
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		if (lotList.Length > array.Length)
		{
			throw new EntityNotFoundException(typeof(Lot), first.Except(ExtractIdOrderBy(array.ToArray())).ToString());
		}
		foreach (Lot obj in lotList)
		{
			Lot lot = new Lot();
			obj.CopyColumsTo(lot);
			lot.Activity = text;
			lot.CheckEntityUsable();
			obj.CopyCommonField(lot, systemTime, dbContext.Tid, isCreate: true);
			list.Add(lot);
		}
		num += ContextManager.BulkCreateEntityFullColumn(dbContext, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateLotBulk(IDbContext dbContext, Lot[] lotList, LotUpsertOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotList", lotList);
		string text = "UpdateLotBulk";
		string tid = dbContext.Tid;
		string[] bulkColumnList = optionSet?.BulkColumnList;
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		string[] first = ExtractIdOrderBy(lotList);
		string siteid = lotList[0].Siteid;
		int num = 0;
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		if (lotList.Length > array.Length)
		{
			throw new EntityNotFoundException(typeof(Lot), first.Except(ExtractIdOrderBy(array.ToArray())).ToString());
		}
		List<Lot> list = new List<Lot>();
		foreach (Lot inputLot in lotList)
		{
			Lot lot2 = array.Where((Lot lot) => lot.Lotid == inputLot.Lotid && lot.Siteid == inputLot.Siteid).FirstOrDefault();
			if (lot2 == null)
			{
				throw new EntityNotFoundException(typeof(Lot), $"{inputLot.Lotid},{inputLot.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Lot), $"{inputLot.Lotid},{inputLot.Siteid}", lot2.Isusable);
			string activity = lot2.Activity;
			string customactivity = lot2.Customactivity;
			string isusable = lot2.Isusable;
			DateTime? createtime = lot2.Createtime;
			string creator = lot2.Creator;
			inputLot.CopyColumsTo(lot2);
			lot2.Prevactivity = activity;
			lot2.Prevcustomactivity = customactivity;
			lot2.Creator = creator;
			lot2.Createtime = createtime;
			lot2.Isusable = isusable;
			lot2.Activity = text;
			inputLot.CopyCommonField(lot2, systemTime, dbContext.Tid, isCreate: false);
			list.Add(lot2);
		}
		num += ContextManager.BulkUpdateEntityFullColumn(dbContext, list[0], list.ToArray(), bulkColumnList, saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteLotBulk(IDbContext dbContext, Lot[] lotList, LotUpsertOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotList", lotList);
		string text = "DeleteLotBulk";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		string[] first = ExtractIdOrderBy(lotList);
		string siteid = lotList[0].Siteid;
		int num = 0;
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		if (lotList.Length > array.Length)
		{
			throw new EntityNotFoundException(typeof(Lot), first.Except(ExtractIdOrderBy(array.ToArray())).ToString());
		}
		List<Lot> list = new List<Lot>();
		foreach (Lot inputLot in lotList)
		{
			Lot lot2 = array.Where((Lot lot) => lot.Lotid == inputLot.Lotid && lot.Siteid == inputLot.Siteid).FirstOrDefault();
			if (lot2 == null)
			{
				throw new EntityNotFoundException(typeof(Lot), $"{inputLot.Lotid},{inputLot.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Lot), $"{inputLot.Lotid},{inputLot.Siteid}", lot2.Isusable);
			lot2.Isusable = "UnUsable";
			inputLot.CopyCommonFieldUpdatePrev(lot2, systemTime, dbContext.Tid, text);
			inputLot.CopyExtensionCollection(lot2);
			list.Add(lot2);
		}
		num += ContextManager.BulkUpdateEntityFullColumn(dbContext, list[0], list.ToArray(), null, saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteLotBulk(IDbContext dbContext, Lot[] lotList, LotUpsertOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotList", lotList);
		string text = "UnDeleteLot";
		string tid = dbContext.Tid;
		string[] bulkColumnList = optionSet?.BulkColumnList;
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		string[] first = ExtractIdOrderBy(lotList);
		string siteid = lotList[0].Siteid;
		int num = 0;
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		if (lotList.Length > array.Length)
		{
			throw new EntityNotFoundException(typeof(Lot), first.Except(ExtractIdOrderBy(array.ToArray())).ToString());
		}
		List<Lot> list = new List<Lot>();
		foreach (Lot inputLot in lotList)
		{
			Lot lot2 = array.Where((Lot lot) => lot.Lotid == inputLot.Lotid && lot.Siteid == inputLot.Siteid).FirstOrDefault();
			if (lot2 == null)
			{
				throw new EntityNotFoundException(typeof(Lot), $"{inputLot.Lotid},{inputLot.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Lot), $"{inputLot.Lotid},{inputLot.Siteid}", lot2.Isusable);
			lot2.Isusable = "Usable";
			inputLot.CopyCommonFieldUpdatePrev(lot2, systemTime, dbContext.Tid, text);
			inputLot.CopyExtensionCollection(lot2);
			list.Add(lot2);
		}
		num += ContextManager.BulkUpdateEntityFullColumn(dbContext, list[0], list.ToArray(), bulkColumnList, saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteLotBulk(IDbContext dbContext, Lot[] lotList, LotUpsertOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotList", lotList);
		string text = "RealDeleteLot";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		string[] first = ExtractIdOrderBy(lotList);
		string siteid = lotList[0].Siteid;
		int num = 0;
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		if (lotList.Length > array.Length)
		{
			throw new EntityNotFoundException(typeof(Lot), first.Except(ExtractIdOrderBy(array.ToArray())).ToString());
		}
		List<Lot> list = new List<Lot>();
		foreach (Lot inputLot in lotList)
		{
			Lot lot2 = array.Where((Lot lot) => lot.Lotid == inputLot.Lotid && lot.Siteid == inputLot.Siteid).FirstOrDefault();
			if (lot2 == null)
			{
				throw new EntityNotFoundException(typeof(Lot), $"{inputLot.Lotid},{inputLot.Siteid}");
			}
			inputLot.CopyCommonFieldUpdatePrev(lot2, systemTime, dbContext.Tid, text);
			inputLot.CopyExtensionCollection(lot2);
			list.Add(lot2);
		}
		num += ContextManager.BulkDeleteEntityFullColumn(dbContext, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	internal static string[] ExtractIdOrderBy(Lot[] lotList)
	{
		return (from p in lotList
			select p.Lotid into id
			orderby id
			select id).ToArray();
	}

	internal static string[] ExtractIdOrderBy(Materiallot[] materiallotList)
	{
		return (from p in materiallotList
			select p.Materiallotid into id
			orderby id
			select id).ToArray();
	}

	internal static Lot[] ExtractIdOrderBy(Lotcarrierrel[] lotcarrierrelList)
	{
		return (from p in lotcarrierrelList
			select p.Lotid into id
			orderby id
			select id).Cast<Lot>().ToArray();
	}

	public static Lot FindLot(Lot[] lotList, string lotId)
	{
		return lotList?.FirstOrDefault((Lot item) => item.Lotid == lotId);
	}

	public static int MergeLot(IDbContext dbContext, Lot parentLot, Lot[] childLotList, IOptionSet childOptionSet, bool saveHistParent, bool saveHistChild)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("parentLot", parentLot);
		ParamChecker.ArgumentNotNullAndHasElement("childLotList", childLotList);
		string text = "MergeLot";
		string tid = dbContext.Tid;
		int apiVersion = 1;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		ParamChecker.ArgumentNotNull("parentLot.Lotid", parentLot.Lotid);
		ParamChecker.ArgumentNotNull("parentLot.Siteid", parentLot.Siteid);
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Lot> list2 = new List<Lot>();
		List<Producedmaterial> list3 = new List<Producedmaterial>();
		List<Carrier> list4 = new List<Carrier>();
		List<Lotcarrierrel> list5 = new List<Lotcarrierrel>();
		string lotid = parentLot.Lotid;
		string siteid = parentLot.Siteid;
		Lot lot = null;
		Lot[] array = null;
		List<Producedmaterial> list6 = new List<Producedmaterial>();
		if ((lot = SelectLot4Update(dbContext, lotid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Lot), lotid);
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", lot);
		}
		array = SelectLotList4Update(dbContext, childLotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		Lot[] array2 = array;
		foreach (Lot lot2 in array2)
		{
			Producedmaterial[] array3 = PRODUCEDMATERIAL.SelectProducedMaterialListAliveByLot4Update(dbContext, lot2.Lotid, siteid).ToArray();
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lot2.Lotid} ProducedMaterial Count={array3.Length}");
			}
			list6.AddRange(array3);
		}
		if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot))
		{
			throw new EntityIsHoldException(typeof(Lot), lotid);
		}
		parentLot.CopyCommonFieldUpdatePrev(lot, systemTime, tid, text);
		parentLot.CopyExtensionCollection(lot);
		list.Add(lot);
		array2 = array;
		foreach (Lot lot3 in array2)
		{
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", $"Lotid={lot.Lotid} State={lot.State} Childlotid={lot.Childlotid} Qty={lot.Qty} Submaterialqty={lot.Submaterialqty}");
			}
			decimal valueOrDefault = lot3.Qty.GetValueOrDefault();
			decimal valueOrDefault2 = lot3.Submaterialqty.GetValueOrDefault();
			lot.Childlotid = lot3.Lotid;
			lot.Prevqty = lot.Qty;
			lot.Qty = lot.Qty.Add(valueOrDefault);
			lot.Prevsubmaterialqty = lot.Submaterialqty;
			lot.Submaterialqty = lot.Submaterialqty.Add(valueOrDefault2);
			decimal? qty = lot.Qty;
			if ((qty.GetValueOrDefault() < default(decimal)) & qty.HasValue)
			{
				throw new QuantityInvalidException(lotid, lot.Qty);
			}
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", $"Lotid={lot.Lotid} State={lot.State} Childlotid={lot.Childlotid} Qty={lot.Qty} Submaterialqty={lot.Submaterialqty}");
			}
			num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHistParent);
		}
		array2 = childLotList;
		foreach (Lot lot4 in array2)
		{
			string lotid2 = lot4.Lotid;
			Lot lot5;
			if ((lot5 = FindLot(array, lotid2)) == null)
			{
				throw new EntityNotFoundException(typeof(Lot), lotid2);
			}
			if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot5))
			{
				throw new EntityIsHoldException(typeof(Lot), lot5.Lotid);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", lot5);
			}
			lot5.Mergelotid = lot.Lotid;
			lot5.Prevqty = lot5.Qty;
			lot5.Qty = default(decimal);
			lot5.Prevsubmaterialqty = lot5.Submaterialqty;
			lot5.Submaterialqty = default(decimal);
			lot5.Prevstate = lot5.State;
			lot5.State = "Terminated";
			lot4.CopyCommonFieldUpdatePrev(lot5, systemTime, tid, text);
			lot4.CopyExtensionCollection(lot5);
			list2.Add(lot5);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", lot5);
			}
			foreach (Producedmaterial item in PRODUCEDMATERIAL.FindProducedMaterialList(list6.ToArray(), lotid2))
			{
				string producedmaterialid = item.Producedmaterialid;
				ParamChecker.ArgumentNotNull("childProducedMaterialId", producedmaterialid);
				if (!PRODUCEDMATERIAL.ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, item))
				{
					throw new EntityIsHoldException(typeof(Producedmaterial), producedmaterialid);
				}
				if (MesLogger.IsDebugEnabled("API"))
				{
					MesLogger.DebugTidApi(tid, "Before Execute", $"Producedmaterialid={item.Producedmaterialid} Prevlotid={item.Prevlotid} Lotid={item.Lotid}");
				}
				item.Prevlotid = item.Lotid;
				item.Lotid = lotid;
				lot4.CopyCommonFieldUpdatePrev(item, systemTime, tid, text);
				list3.Add(item);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={item.Producedmaterialid} Prevlotid={item.Prevlotid} Lotid={item.Lotid}");
				}
			}
			Lotcarrierrel[] array4 = LOTCARRIERREL.GetLotCarrierRelList(dbContext, lotid2, siteid).ToArray();
			string[] distinctCarrierList = LOTCARRIERREL.GetDistinctCarrierList(array4);
			foreach (string carrierid in distinctCarrierList)
			{
				Carrier carrier = CARRIER.SelectCarrier4Update(dbContext, carrierid, siteid);
				lot4.CopyCommonFieldUpdatePrev(carrier, systemTime, tid, text);
				list4.Add(carrier);
			}
			Lotcarrierrel[] array5 = array4;
			foreach (Lotcarrierrel lotcarrierrel in array5)
			{
				lot4.CopyCommonFieldUpdatePrev(lotcarrierrel, systemTime, tid, text);
				list5.Add(lotcarrierrel);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHistChild);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list3.ToArray(), saveHistChild);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list4.ToArray(), saveHistChild);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list5.ToArray(), saveHistChild);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int MergeLot(IDbContext dbContext, Lot parentLot, Lot childLot, Producedmaterial[] childProducedMaterialList, IOptionSet childOptionSet, bool saveHistParent, bool saveHistChild, bool saveHistChildLotcarrierrel, bool saveHistChildCarrier)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("parentLot", parentLot);
		ParamChecker.ArgumentNotNull("childLot", childLot);
		ParamChecker.ArgumentNotNullAndHasElement("childProducedMaterialList", childProducedMaterialList);
		string text = "MergeLot";
		string tid = dbContext.Tid;
		int apiVersion = 2;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		ParamChecker.ArgumentNotNull("parentLot.Lotid", parentLot.Lotid);
		ParamChecker.ArgumentNotNull("parentLot.Siteid", parentLot.Siteid);
		ParamChecker.ArgumentNotNull("childLot.Lotid", childLot.Lotid);
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Lot> list2 = new List<Lot>();
		List<Producedmaterial> list3 = new List<Producedmaterial>();
		string lotid = parentLot.Lotid;
		string lotid2 = childLot.Lotid;
		string siteid = parentLot.Siteid;
		Lot lot = null;
		Lot lot2 = null;
		if ((lot = SelectLot4Update(dbContext, lotid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Lot), lotid);
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", lot);
		}
		if ((lot2 = SelectLot4Update(dbContext, lotid2, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Lot), lotid2);
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", lot2);
		}
		Producedmaterial[] array = PRODUCEDMATERIAL.SelectProducedMaterialListAliveByLot4Update(dbContext, lotid2, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lotid} ProducedMaterial Count={array.Length}");
		}
		if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot))
		{
			throw new EntityIsHoldException(typeof(Lot), lotid);
		}
		if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot2))
		{
			throw new EntityIsHoldException(typeof(Lot), lotid2);
		}
		ValidateParameterProducedMaterial(text, lotid2, childProducedMaterialList, array.ToArray());
		decimal valueOrDefault = childLot.Qty.GetValueOrDefault();
		decimal valueOrDefault2 = childLot.Submaterialqty.GetValueOrDefault();
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", lot);
		}
		lot.Childlotid = lotid2;
		lot.Prevqty = lot.Qty;
		lot.Qty = lot.Qty.Add(valueOrDefault);
		lot.Prevsubmaterialqty = lot.Submaterialqty;
		lot.Submaterialqty = lot.Submaterialqty.Add(valueOrDefault2);
		parentLot.CopyCommonFieldUpdatePrev(lot, systemTime, tid, text);
		parentLot.CopyExtensionCollection(lot);
		list.Add(lot);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", lot);
		}
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", lot2);
		}
		lot2.Mergelotid = lotid;
		lot2.Prevstate = lot2.State;
		lot2.State = "Terminated";
		lot2.Prevqty = lot2.Qty;
		lot2.Qty = default(decimal);
		lot2.Prevsubmaterialqty = lot2.Submaterialqty;
		lot2.Submaterialqty = default(decimal);
		childLot.CopyCommonFieldUpdatePrev(lot2, systemTime, tid, text);
		childLot.CopyExtensionCollection(lot2);
		list2.Add(lot2);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", lot2);
		}
		foreach (Producedmaterial producedmaterial in childProducedMaterialList)
		{
			string producedmaterialid = producedmaterial.Producedmaterialid;
			ParamChecker.ArgumentNotNull("childProducedMaterialId", producedmaterialid);
			Producedmaterial producedmaterial2 = PRODUCEDMATERIAL.FindProducedMaterial(array, producedmaterialid);
			if (producedmaterial2 == null)
			{
				throw new EntityNotFoundException(typeof(Producedmaterial), producedmaterialid);
			}
			if (!PRODUCEDMATERIAL.ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, producedmaterial2))
			{
				throw new EntityIsHoldException(typeof(Producedmaterial), producedmaterialid);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", $"Producedmaterialid={producedmaterial2.Producedmaterialid} Prevlotid={producedmaterial2.Prevlotid} Lotid={producedmaterial2.Lotid} Slotno={producedmaterial2.Slotno} Carrierid={producedmaterial2.Carrierid}");
			}
			producedmaterial2.Prevlotid = producedmaterial2.Lotid;
			producedmaterial2.Lotid = lotid;
			producedmaterial2.Prevslotno = producedmaterial2.Slotno;
			producedmaterial2.Slotno = producedmaterial.Slotno;
			producedmaterial2.Prevcarrierid = producedmaterial2.Carrierid;
			producedmaterial2.Carrierid = producedmaterial.Carrierid;
			producedmaterial.CopyCommonFieldUpdatePrev(producedmaterial2, systemTime, tid, text);
			producedmaterial.CopyExtensionCollection(producedmaterial2);
			list3.Add(producedmaterial2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={producedmaterial2.Producedmaterialid} Prevlotid={producedmaterial2.Prevlotid} Lotid={producedmaterial2.Lotid} Slotno={producedmaterial2.Slotno} Carrierid={producedmaterial2.Carrierid}");
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHistParent);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHistChild);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list3.ToArray(), saveHistParent);
		List<Carrier> list4 = new List<Carrier>();
		List<Lotcarrierrel> list5 = new List<Lotcarrierrel>();
		Lotcarrierrel[] array2 = LOTCARRIERREL.GetLotCarrierRelList(dbContext, lotid2, siteid).ToArray();
		string[] distinctCarrierList = LOTCARRIERREL.GetDistinctCarrierList(array2);
		foreach (string carrierid in distinctCarrierList)
		{
			Carrier carrier = CARRIER.SelectCarrier4Update(dbContext, carrierid, siteid);
			childLot.CopyCommonFieldUpdatePrev(carrier, systemTime, tid, text);
			list4.Add(carrier);
		}
		Lotcarrierrel[] array3 = array2;
		foreach (Lotcarrierrel lotcarrierrel in array3)
		{
			childLot.CopyCommonFieldUpdatePrev(lotcarrierrel, systemTime, tid, text);
			list5.Add(lotcarrierrel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list4.ToArray(), saveHistChildCarrier);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list5.ToArray(), saveHistChildLotcarrierrel);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int MoveLotLocation(IDbContext dbContext, Lot[] lotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotList", lotList);
		string text = "MoveLotLocation";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		string siteid = lotList[0].Siteid;
		List<Producedmaterial> list3 = new List<Producedmaterial>();
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		Lot[] array2 = array;
		foreach (Lot lot in array2)
		{
			Producedmaterial[] array3 = PRODUCEDMATERIAL.SelectProducedMaterialListAliveByLot4Update(dbContext, lot.Lotid, siteid).ToArray();
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lot.Lotid} ProducedMaterial Count={array3.Length}");
			}
			list3.AddRange(array3);
		}
		array2 = lotList;
		foreach (Lot lot2 in array2)
		{
			ParamChecker.ArgumentNotNull("Lotid", lot2.Lotid);
			ParamChecker.ArgumentNotNull("Location", lot2.Location);
			ParamChecker.ArgumentNotNull("Siteid", lot2.Siteid);
			string lotid = lot2.Lotid;
			string location = lot2.Location;
			Lot lot3;
			if ((lot3 = FindLot(array, lotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lot), lotid);
			}
			if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot3))
			{
				throw new EntityIsHoldException(typeof(Lot), lotid);
			}
			if (FACILITY.SelectFacility(dbContext, location, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(Facility), location);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", $"Lotid={lot3.Lotid} Prevlocation={lot3.Prevlocation} Location={lot3.Location}");
			}
			lot3.Prevlocation = lot3.Location;
			lot3.Location = location;
			lot2.CopyCommonFieldUpdatePrev(lot3, systemTime, tid, text);
			lot2.CopyExtensionCollection(lot3);
			list.Add(lot3);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", $"Lotid={lot3.Lotid} Prevlocation={lot3.Prevlocation} Location={lot3.Location}");
			}
			foreach (Producedmaterial item in PRODUCEDMATERIAL.FindProducedMaterialList(list3.ToArray(), lotid))
			{
				if (!PRODUCEDMATERIAL.ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, item))
				{
					throw new EntityIsHoldException(typeof(Producedmaterial), item.Producedmaterialid);
				}
				if (MesLogger.IsDebugEnabled("API"))
				{
					MesLogger.DebugTidApi(tid, "Before Execute", $"Producedmaterialid={item.Producedmaterialid} Prevlocation={item.Prevlocation} Location={item.Location}");
				}
				item.Prevlocation = item.Prevlocation;
				item.Location = location;
				lot2.CopyCommonFieldUpdatePrev(item, systemTime, tid, text);
				list2.Add(item);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={item.Producedmaterialid} Prevlocation={item.Prevlocation} Location={item.Location}");
				}
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int ReassignLot(IDbContext dbContext, Lot[] lotList, ReassignLotOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotList", lotList);
		string text = "ReassignLot";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		bool saveHistFutureAction = optionSet?.SaveHistRunFutureAction ?? false;
		string customActivityFutureAction = optionSet?.CustomActivityRunFutureAction;
		DateTime modifyTimeFutureAction = ((optionSet != null && optionSet.ModifytimeRunFutureAction != DateTime.MinValue) ? optionSet.ModifytimeRunFutureAction : systemTime);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		string siteid = lotList[0].Siteid;
		List<Producedmaterial> list3 = new List<Producedmaterial>();
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		Lot[] array2 = array;
		foreach (Lot lot in array2)
		{
			Producedmaterial[] array3 = PRODUCEDMATERIAL.SelectProducedMaterialListAliveByLot4Update(dbContext, lot.Lotid, siteid).ToArray();
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lot.Lotid} ProducedMaterial Count={array3.Length}");
			}
			list3.AddRange(array3);
		}
		array2 = lotList;
		foreach (Lot lot2 in array2)
		{
			ParamChecker.ArgumentNotNull("Lotid", lot2.Lotid);
			ParamChecker.ArgumentNotNull("Productdefinitionid", lot2.Productdefinitionid);
			ParamChecker.ArgumentNotNull("Processdefinitionid", lot2.Processdefinitionid);
			ParamChecker.ArgumentNotNull("Siteid", lot2.Siteid);
			string lotid = lot2.Lotid;
			string productdefinitionid = lot2.Productdefinitionid;
			string processdefinitionid = lot2.Processdefinitionid;
			string processsegmentid = lot2.Processsegmentid;
			string subprocessdefinitionid = lot2.Subprocessdefinitionid;
			Processnode processnode = null;
			Processsegment processsegment = null;
			Processsegmentruleclsrel processsegmentruleclsrel = null;
			Lot lot3;
			if ((lot3 = FindLot(array, lotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lot), lotid);
			}
			if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot3))
			{
				throw new EntityIsHoldException(typeof(Lot), lotid);
			}
			ParamChecker.EntityInvalidState(typeof(Lot), lotid, lot3.Processingstate, "ProcessingRule");
			if (PRODUCTDEFINITION.SelectProductDefinition(dbContext, productdefinitionid, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(Productdefinition), productdefinitionid);
			}
			if (PRODUCTPROCESSREL.SelectProductProcessRel(dbContext, productdefinitionid, processdefinitionid, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(Productprocessrel), productdefinitionid + "-" + processdefinitionid);
			}
			if (string.IsNullOrEmpty(processsegmentid))
			{
				if ((processnode = PROCESSNODE.SelectProcessStartSegmentNode(dbContext, processdefinitionid, siteid)) == null)
				{
					throw new StartSegmentNodeNotFoundException(processdefinitionid);
				}
				if ((processsegment = PROCESSSEGMENT.SelectProcessSegment(dbContext, processnode.Processsegmentid, siteid)) == null)
				{
					throw new EntityNotFoundException(typeof(Processsegment), processnode.Processsegmentid);
				}
			}
			else
			{
				if ((processnode = PROCESSNODE.SelectProcessSegmentNode(dbContext, processdefinitionid, processsegmentid, siteid)) == null)
				{
					throw new EntityNotFoundException(typeof(Processnode), lot3.Processdefinitionid + ":" + processsegmentid);
				}
				if ((processsegment = PROCESSSEGMENT.SelectProcessSegment(dbContext, processnode.Processsegmentid, siteid)) == null)
				{
					throw new EntityNotFoundException(typeof(Processsegment), processnode.Processsegmentid);
				}
			}
			if ((processsegmentruleclsrel = PROCESSSEGMENTRULECLSREL.SelectFirstProcessSegmentRuleByRuleCls(dbContext, processsegment.Processsegmentruleclsid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Processsegment), processsegment.Processsegmentruleclsid);
			}
			ParamChecker.EntityUsable(typeof(Processsegment), processnode.Processsegmentid, processsegment.Isusable);
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", $"Lotid={lot3.Lotid} Producttype={lot3.Producttype} Processingstate={lot3.Processingstate} Location={lot3.Location} Productorderid={lot3.Productorderid} Workorderid={lot3.Workorderid} Mainprocessdefinitionid={lot3.Mainprocessdefinitionid} Productdefinitionid={lot3.Productdefinitionid} Processdefinitionid={lot3.Processdefinitionid} Subprocessdefinitionid={lot3.Subprocessdefinitionid} Processsegmentid={lot3.Processsegmentid} Processsegmentruleid={lot3.Processsegmentruleid}");
			}
			lot3.Prevproducttype = lot3.Producttype;
			lot3.Producttype = lot2.Producttype;
			lot3.Productorderid = lot2.Productorderid;
			lot3.Workorderid = lot2.Workorderid;
			lot3.Mainprocessdefinitionid = processdefinitionid;
			lot3.Prevproductdefinitionid = lot3.Productdefinitionid;
			lot3.Productdefinitionid = productdefinitionid;
			lot3.Prevprocessdefinitionid = lot3.Processdefinitionid;
			lot3.Processdefinitionid = processdefinitionid;
			if (!string.IsNullOrEmpty(subprocessdefinitionid))
			{
				lot3.Prevsubprocessdefinitionid = lot3.Subprocessdefinitionid;
				lot3.Subprocessdefinitionid = subprocessdefinitionid;
			}
			else if (processnode.Processdefinitionid != processdefinitionid)
			{
				lot3.Prevsubprocessdefinitionid = lot3.Subprocessdefinitionid;
				lot3.Subprocessdefinitionid = processnode.Processdefinitionid;
			}
			lot3.Prevprocesssegmentid = lot3.Processsegmentid;
			lot3.Processsegmentid = processsegment.Processsegmentid;
			lot3.Processsegmentruleid = processsegmentruleclsrel.Processsegmentruleid;
			lot3.Rulesequence = processsegmentruleclsrel.Rulesequence;
			lot3.Prevprocessnodeid = lot3.Processnodeid;
			lot3.Processnodeid = processnode.Processnodeid;
			lot3.Processingstate = "WaitForRule";
			lot3.Receivedtime = EntityHelper.FirstNotNull<DateTime>(lot2.Modifytime, systemTime);
			if (lot3.Location != lot2.Location)
			{
				lot3.Prevlocation = lot3.Location;
				lot3.Location = lot2.Location;
			}
			lot2.CopyCommonFieldUpdatePrev(lot3, systemTime, tid, text);
			lot2.CopyExtensionCollection(lot3);
			list.Add(lot3);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", $"Lotid={lot3.Lotid} Producttype={lot3.Producttype} Processingstate={lot3.Processingstate} Location={lot3.Location} Productorderid={lot3.Productorderid} Workorderid={lot3.Workorderid} Mainprocessdefinitionid={lot3.Mainprocessdefinitionid} Productdefinitionid={lot3.Productdefinitionid} Processdefinitionid={lot3.Processdefinitionid} Subprocessdefinitionid={lot3.Subprocessdefinitionid} Processsegmentid={lot3.Processsegmentid} Processsegmentruleid={lot3.Processsegmentruleid}");
			}
			foreach (Producedmaterial item in PRODUCEDMATERIAL.FindProducedMaterialList(list3.ToArray(), lotid))
			{
				if (!PRODUCEDMATERIAL.ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, item))
				{
					throw new EntityIsHoldException(typeof(Producedmaterial), item.Producedmaterialid);
				}
				if (MesLogger.IsDebugEnabled("API"))
				{
					MesLogger.DebugTidApi(tid, "Before Execute", $"Producedmaterialid={item.Producedmaterialid} Processingstate={item.Processingstate} Location={item.Location} Productdefinitionid={item.Productdefinitionid} Processdefinitionid={item.Processdefinitionid} Subprocessdefinitionid={item.Subprocessdefinitionid} Processsegmentid={item.Processsegmentid} Processnodeid={item.Processnodeid}");
				}
				PRODUCEDMATERIAL.InheritLotProcessInfo(lot3, item);
				if (item.Location != lot2.Location)
				{
					item.Prevlocation = item.Location;
					item.Location = lot2.Location;
				}
				item.Prevproductdefinitionid = lot3.Prevproductdefinitionid;
				item.Productdefinitionid = lot3.Productdefinitionid;
				lot2.CopyCommonFieldUpdatePrev(item, systemTime, tid, text);
				list2.Add(item);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={item.Producedmaterialid} Processingstate={item.Processingstate} Location={item.Location} Productdefinitionid={item.Productdefinitionid} Processdefinitionid={item.Processdefinitionid} Subprocessdefinitionid={item.Subprocessdefinitionid} Processsegmentid={item.Processsegmentid} Processnodeid={item.Processnodeid}");
				}
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHist);
		foreach (Lot item2 in list)
		{
			if (LOTFUTUREACTION.GetLotFutureActionCountCurrentSegmentRule(dbContext, item2) > 0)
			{
				RunLotFutureAction(dbContext, item2, "Y", customActivityFutureAction, saveHistFutureAction, modifyTimeFutureAction);
			}
		}
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int ReceiveLot(IDbContext dbContext, Lot inputLot, Producedmaterial[] producedMaterialList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("inputLot", inputLot);
		string text = "ReceiveLot";
		int apiVersion = 1;
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		ParamChecker.ArgumentNotNull("lotid", inputLot.Lotid);
		ParamChecker.ArgumentNotNull("siteId", inputLot.Siteid);
		string tid = dbContext.Tid;
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Lot> list2 = new List<Lot>();
		List<Producedmaterial> list3 = new List<Producedmaterial>();
		List<Producedmaterial> list4 = new List<Producedmaterial>();
		string lotid = inputLot.Lotid;
		string siteid = inputLot.Siteid;
		Lot lot = null;
		Producedmaterial[] array = new Producedmaterial[0];
		lot = SelectLot4Update(dbContext, lotid, siteid);
		if (lot != null)
		{
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "Select4Update", lot);
			}
		}
		else if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "No storedLot exists. Need create Lot", lotid);
		}
		if (producedMaterialList != null && producedMaterialList.Length != 0)
		{
			array = PRODUCEDMATERIAL.SelectProducedMaterialList4Update(dbContext, producedMaterialList, siteid).ToArray();
			if (array.Length != 0)
			{
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lotid} ProducedMaterial Count={array.Length}");
				}
			}
			else if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "No storedProducedMaterial exists. Need create ProducedMaterial", lotid);
			}
		}
		else if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "No input ProducedMaterial", lotid);
		}
		if (lot == null)
		{
			Lot lot2 = new Lot();
			inputLot.CopyColumsTo(lot2);
			lot2.Activity = text;
			inputLot.CopyCommonField(lot2, systemTime, tid, isCreate: true);
			lot2.Customactivity = EntityHelper.FirstNotNull<string>(inputLot.Customactivity, lot2.Activity);
			list.Add(lot2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", lot2);
			}
		}
		else
		{
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", lot);
			}
			lot.Activity = text;
			inputLot.CopyCommonFieldUpdatePrev(lot, systemTime, tid, text);
			inputLot.CopyColumsTo(lot);
			list2.Add(lot);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", lot);
			}
		}
		if (producedMaterialList != null)
		{
			foreach (Producedmaterial producedmaterial in producedMaterialList)
			{
				string producedmaterialid = producedmaterial.Producedmaterialid;
				ParamChecker.ArgumentNotNull("Producedmaterialid", producedmaterialid);
				Producedmaterial producedmaterial2 = null;
				producedmaterial2 = PRODUCEDMATERIAL.FindProducedMaterial(array, producedmaterialid);
				if (producedmaterial2 == null)
				{
					Producedmaterial producedmaterial3 = new Producedmaterial();
					producedmaterial.CopyColumsTo(producedmaterial3);
					producedmaterial3.State = EntityHelper.FirstNotNull<string>(producedmaterial.State, "Active");
					producedmaterial3.Activity = text;
					producedmaterial3.Isusable = "Usable";
					producedmaterial.CopyCommonField(producedmaterial3, systemTime, tid, isCreate: true);
					producedmaterial3.Customactivity = EntityHelper.FirstNotNull<string>(producedmaterial.Customactivity, producedmaterial3.Activity);
					list3.Add(producedmaterial3);
					if (MesLogger.IsInfoEnabled("API"))
					{
						MesLogger.InfoTidApi(tid, "After Execute", producedmaterial3);
					}
					continue;
				}
				if (!PRODUCEDMATERIAL.ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, producedmaterial2))
				{
					throw new EntityIsHoldException(typeof(Producedmaterial), producedmaterialid);
				}
				if (MesLogger.IsDebugEnabled("API"))
				{
					MesLogger.DebugTidApi(tid, "Before Execute", producedmaterial2);
				}
				producedmaterial.CopyColumsTo(producedmaterial2);
				producedmaterial2.State = EntityHelper.FirstNotNull<string>(producedmaterial.State, "Active");
				producedmaterial2.Activity = text;
				producedmaterial2.Isusable = "Usable";
				producedmaterial.CopyCommonFieldUpdatePrev(producedmaterial2, systemTime, tid, text);
				list4.Add(producedmaterial2);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Execute", producedmaterial2);
				}
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list3.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list4.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int ReleaseFutureAction(IDbContext dbContext, Lot lot, Lotfutureaction[] lotfutureactionList, IOptionSet optionSet, bool saveLotHist, bool saveFutureActionHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("lot", lot);
		ParamChecker.ArgumentNotNullAndHasElement("lotfutureactionList", lotfutureactionList);
		string text = "ReleaseFutureAction";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		ParamChecker.ArgumentNotNull("Lotid", lot.Lotid);
		ParamChecker.ArgumentNotNull("Siteid", lot.Siteid);
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Lotfutureaction> list2 = new List<Lotfutureaction>();
		string lotid = lot.Lotid;
		string siteid = lot.Siteid;
		Lot lot2;
		if ((lot2 = SelectLot4Update(dbContext, lotid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Lot), lotid);
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTid("API", tid, string.Format("{0} {1}", "Select4Update", lot2));
		}
		if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot))
		{
			throw new EntityIsHoldException(typeof(Lot), lot.Lotid);
		}
		foreach (Lotfutureaction lotfutureaction in lotfutureactionList)
		{
			ParamChecker.ArgumentNotNull("Actiontype", lotfutureaction.Actiontype);
			ParamChecker.ArgumentNotNull("Actionproductdefinitionid", lotfutureaction.Actionproductdefinitionid);
			ParamChecker.ArgumentNotNull("Actionprocessdefinitionid", lotfutureaction.Actionprocessdefinitionid);
			ParamChecker.ArgumentNotNull("Actionsubprocessdefinitionid", lotfutureaction.Actionsubprocessdefinitionid);
			ParamChecker.ArgumentNotNull("Actionprocesssegmentid", lotfutureaction.Actionprocesssegmentid);
			lotfutureaction.Siteid = siteid;
			lotfutureaction.Lotid = lotid;
			IList<Lotfutureaction> list3 = null;
			if ((list3 = LOTFUTUREACTION.GetLotFutureActionList(dbContext, lotfutureaction)).Count == 0)
			{
				throw new EntityNotFoundException(typeof(Lotfutureaction), lotfutureaction.Lotid);
			}
			foreach (Lotfutureaction item in list3)
			{
				lotfutureaction.CopyCommonFieldUpdatePrev(item, systemTime, tid, text);
				lotfutureaction.CopyExtensionCollection(item);
				list2.Add(item);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Execute", item);
				}
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list2.ToArray(), saveFutureActionHist);
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", $"Lotid={lot2.Lotid} Isreservedfutureaction={lot2.Isreservedfutureaction}");
		}
		Lotfutureaction lotfutureaction2 = new Lotfutureaction();
		lotfutureaction2.Lotid = lotid;
		lotfutureaction2.Siteid = siteid;
		if (LOTFUTUREACTION.GetLotFutureActionCount(dbContext, lotfutureaction2) == 0)
		{
			lot2.Isreservedfutureaction = "N";
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "No Lotfutureaction remains", $"Lotid={lot2.Lotid} Isreservedfutureaction={lot2.Isreservedfutureaction}");
			}
		}
		lot.CopyCommonFieldUpdatePrev(lot2, systemTime, tid, text);
		lot.CopyExtensionCollection(lot2);
		list.Add(lot2);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", $"Lotid={lot2.Lotid} Isreservedfutureaction={lot2.Isreservedfutureaction}");
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveLotHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int ReleaseHoldLot(IDbContext dbContext, Lot lot, Lothold[] lotHoldList, IOptionSet optionSet, bool saveLotHist, bool saveHoldHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("lot", lot);
		ParamChecker.ArgumentNotNullAndHasElement("lotHoldList", lotHoldList);
		string text = "ReleaseHoldLot";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		ParamChecker.ArgumentNotNull("Lotid", lot.Lotid);
		ParamChecker.ArgumentNotNull("Siteid", lot.Siteid);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		List<Lothold> list3 = new List<Lothold>();
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		string lotid = lot.Lotid;
		string siteid = lot.Siteid;
		Lot lot2;
		if ((lot2 = SelectLot4Update(dbContext, lotid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Lot), lotid);
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", lot2);
		}
		Producedmaterial[] array = PRODUCEDMATERIAL.SelectProducedMaterialListAliveByLot4Update(dbContext, lotid, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lot2.Lotid} ProducedMaterial Count={array.Length}");
		}
		ParamChecker.EntityValidState(typeof(Lot), "Ishold", lot2.Ishold, "Y");
		IList<Lothold> list4 = new List<Lothold>();
		bool flag = false;
		if (lotHoldList.Length == 1 && string.IsNullOrEmpty(lotHoldList[0].Holdcode))
		{
			list4 = LOTHOLD.GetLotHoldList(dbContext, lotid, siteid);
			flag = true;
		}
		else
		{
			List<string> list5 = new List<string>();
			for (int i = 0; i < lotHoldList.Length; i++)
			{
				string holdcode = lotHoldList[i].Holdcode;
				ParamChecker.ArgumentNotNull("holdCode", holdcode);
				if (list5.Contains(holdcode))
				{
					throw new ArgumentException($"Duplicated HOLDCODE={holdcode} found");
				}
				list5.Add(holdcode);
			}
			foreach (string item in list5)
			{
				Lothold lotHold = LOTHOLD.GetLotHold(dbContext, lotid, item, siteid);
				if (lotHold == null)
				{
					throw new EntityNotFoundException(typeof(Lothold), lotid + "." + item);
				}
				list4.Add(lotHold);
			}
		}
		for (int j = 0; j < list4.Count; j++)
		{
			Lothold lothold = list4[j];
			Lothold lothold2 = (flag ? lotHoldList[0] : lotHoldList[j]);
			lothold.Releaseuser = EntityHelper.FirstNotNull<string>(lothold2.Releaseuser, lot.Modifier);
			lothold.Releasecode = lothold2.Releasecode;
			lothold2.CopyCommonFieldUpdatePrev(lothold, systemTime, tid, text);
			lothold2.CopyExtensionCollection(lothold);
			list3.Add(lothold);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", lothold);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list3.ToArray(), saveHoldHist);
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", $"Lotid={lot2.Lotid} Ishold={lot2.Ishold}");
		}
		if (LOTHOLD.GetLotHoldTotalCount(dbContext, lotid, siteid) == 0)
		{
			lot2.Ishold = "N";
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "No Lothold remains", $"Lotid={lot2.Lotid} Ishold={lot2.Ishold}");
			}
		}
		lot.CopyCommonFieldUpdatePrev(lot2, systemTime, tid, text);
		lot.CopyExtensionCollection(lot2);
		list.Add(lot2);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", $"Lotid={lot2.Lotid} Ishold={lot2.Ishold}");
		}
		if (lot2.Ishold == "N")
		{
			Producedmaterial[] array2 = array;
			foreach (Producedmaterial producedmaterial in array2)
			{
				if (producedmaterial.Ishold != "Y")
				{
					if (MesLogger.IsInfoEnabled("API"))
					{
						MesLogger.InfoTidApi(tid, "Skip Execute", $"Producedmaterialid={producedmaterial.Producedmaterialid} Ishold={producedmaterial.Ishold}");
					}
					continue;
				}
				if (MesLogger.IsDebugEnabled("API"))
				{
					MesLogger.DebugTidApi(tid, "Before Execute", $"Producedmaterialid={producedmaterial.Producedmaterialid} Ishold={producedmaterial.Ishold}");
				}
				_ = producedmaterial.Producedmaterialid;
				producedmaterial.Ishold = lot2.Ishold;
				lot.CopyCommonFieldUpdatePrev(producedmaterial, systemTime, tid, text);
				list2.Add(producedmaterial);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={producedmaterial.Producedmaterialid} Ishold={producedmaterial.Ishold}");
				}
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveLotHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveLotHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int RepositionLot(IDbContext dbContext, Lot[] lotList, RepositionLotOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotList", lotList);
		string text = "RepositionLot";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		bool saveHistFutureAction = optionSet?.SaveHistRunFutureAction ?? false;
		string customActivityFutureAction = optionSet?.CustomActivityRunFutureAction;
		DateTime modifyTimeFutureAction = ((optionSet != null && optionSet.ModifytimeRunFutureAction != DateTime.MinValue) ? optionSet.ModifytimeRunFutureAction : systemTime);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		string siteid = lotList[0].Siteid;
		List<Producedmaterial> list3 = new List<Producedmaterial>();
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		Lot[] array2 = array;
		foreach (Lot lot in array2)
		{
			Producedmaterial[] array3 = PRODUCEDMATERIAL.SelectProducedMaterialListAliveByLot4Update(dbContext, lot.Lotid, siteid).ToArray();
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lot.Lotid} ProducedMaterial Count={array3.Length}");
			}
			list3.AddRange(array3);
		}
		array2 = lotList;
		foreach (Lot lot2 in array2)
		{
			ParamChecker.ArgumentNotNull("Lotid", lot2.Lotid);
			ParamChecker.ArgumentNotNull("Processsegmentid", lot2.Processsegmentid);
			ParamChecker.ArgumentNotNull("Siteid", lot2.Siteid);
			string lotid = lot2.Lotid;
			string processsegmentid = lot2.Processsegmentid;
			string subprocessdefinitionid = lot2.Subprocessdefinitionid;
			Lot lot3;
			if ((lot3 = FindLot(array, lotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lot), lotid);
			}
			if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot3))
			{
				throw new EntityIsHoldException(typeof(Lot), lotid);
			}
			ParamChecker.EntityInvalidState(typeof(Lot), lotid, lot3.Processingstate, "ProcessingRule");
			Processnode processnode;
			if (string.IsNullOrEmpty(subprocessdefinitionid))
			{
				if ((processnode = PROCESSNODE.SelectProcessSegmentNode(dbContext, lot3.Processdefinitionid, processsegmentid, siteid)) == null)
				{
					throw new EntityNotFoundException(typeof(Processnode), lot3.Processdefinitionid + ":" + processsegmentid);
				}
			}
			else if ((processnode = PROCESSNODE.SelectProcessSegmentNode(dbContext, lot3.Processdefinitionid, subprocessdefinitionid, processsegmentid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Processnode), lot3.Processdefinitionid + ":" + processsegmentid);
			}
			Processsegment processsegment;
			if ((processsegment = PROCESSSEGMENT.SelectProcessSegment(dbContext, processnode.Processsegmentid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Processsegment), processnode.Processsegmentid);
			}
			Processsegmentruleclsrel processsegmentruleclsrel;
			if ((processsegmentruleclsrel = PROCESSSEGMENTRULECLSREL.SelectFirstProcessSegmentRuleByRuleCls(dbContext, processsegment.Processsegmentruleclsid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Processsegment), processsegment.Processsegmentruleclsid);
			}
			ParamChecker.EntityUsable(typeof(Processsegment), processsegment.Processsegmentid, processsegment.Isusable);
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", $"Lotid={lot3.Lotid} Prevprocesssegmentid={lot3.Prevprocesssegmentid} Processsegmentid={lot3.Processsegmentid} Prevlocation={lot3.Prevlocation} Location={lot3.Location}");
			}
			lot3.Prevsubprocessdefinitionid = lot3.Subprocessdefinitionid;
			lot3.Subprocessdefinitionid = processnode.Processdefinitionid;
			lot3.Prevprocesssegmentid = lot3.Processsegmentid;
			lot3.Processsegmentid = processnode.Processsegmentid;
			lot3.Prevprocessnodeid = lot3.Processnodeid;
			lot3.Processnodeid = processnode.Processnodeid;
			lot3.Processsegmentruleid = processsegmentruleclsrel.Processsegmentruleid;
			lot3.Rulesequence = processsegmentruleclsrel.Rulesequence;
			lot3.Processingstate = "WaitForRule";
			lot3.Nextprocesssegmentid = null;
			lot3.Nextsubprocessdefinitionid = null;
			lot3.Receivedtime = EntityHelper.FirstNotNull<DateTime>(lot2.Modifytime, systemTime);
			if (lot3.Location != lot2.Location)
			{
				lot3.Prevlocation = lot3.Location;
				lot3.Location = lot2.Location;
			}
			lot2.CopyCommonFieldUpdatePrev(lot3, systemTime, tid, text);
			lot2.CopyExtensionCollection(lot3);
			list.Add(lot3);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", $"Lotid={lot3.Lotid} Prevprocesssegmentid={lot3.Prevprocesssegmentid} Processsegmentid={lot3.Processsegmentid} Prevlocation={lot3.Prevlocation} Location={lot3.Location}");
			}
			foreach (Producedmaterial item in PRODUCEDMATERIAL.FindProducedMaterialList(list3.ToArray(), lotid))
			{
				if (!PRODUCEDMATERIAL.ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, item))
				{
					throw new EntityIsHoldException(typeof(Producedmaterial), item.Producedmaterialid);
				}
				if (MesLogger.IsDebugEnabled("API"))
				{
					MesLogger.DebugTidApi(tid, "Before Execute", $"Producedmaterialid={item.Producedmaterialid} Prevprocesssegmentid={item.Prevprocesssegmentid} Processsegmentid={item.Processsegmentid} Prevlocation={item.Prevlocation} Location={item.Location}");
				}
				PRODUCEDMATERIAL.InheritLotProcessInfo(lot3, item);
				if (item.Location != lot2.Location)
				{
					item.Prevlocation = item.Location;
					item.Location = lot2.Location;
				}
				lot2.CopyCommonFieldUpdatePrev(item, systemTime, tid, text);
				list2.Add(item);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={item.Producedmaterialid} Prevprocesssegmentid={item.Prevprocesssegmentid} Processsegmentid={item.Processsegmentid} Prevlocation={item.Prevlocation} Location={item.Location}");
				}
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHist);
		foreach (Lot item2 in list)
		{
			if (LOTFUTUREACTION.GetLotFutureActionCountCurrentSegmentRule(dbContext, item2) > 0)
			{
				RunLotFutureAction(dbContext, item2, "Y", customActivityFutureAction, saveHistFutureAction, modifyTimeFutureAction);
			}
		}
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int RepositionRule(IDbContext dbContext, Lot[] lotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotList", lotList);
		string text = "RepositionRule";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		string siteid = lotList[0].Siteid;
		List<Producedmaterial> list3 = new List<Producedmaterial>();
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		Lot[] array2 = array;
		foreach (Lot lot in array2)
		{
			Producedmaterial[] array3 = PRODUCEDMATERIAL.SelectProducedMaterialListAliveByLot4Update(dbContext, lot.Lotid, siteid).ToArray();
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lot.Lotid} ProducedMaterial Count={array3.Length}");
			}
			list3.AddRange(array3);
		}
		array2 = lotList;
		foreach (Lot lot2 in array2)
		{
			ParamChecker.ArgumentNotNull("Lotid", lot2.Lotid);
			ParamChecker.ArgumentNotNull("Processsegmentruleid", lot2.Processsegmentruleid);
			ParamChecker.ArgumentNotNull("Siteid", lot2.Siteid);
			string lotid = lot2.Lotid;
			string processsegmentruleid = lot2.Processsegmentruleid;
			Lot lot3;
			if ((lot3 = FindLot(array, lotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lot), lotid);
			}
			if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot3))
			{
				throw new EntityIsHoldException(typeof(Lot), lotid);
			}
			ParamChecker.EntityInvalidState(typeof(Lot), lotid, lot3.Processingstate, "WaitForSegment");
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", $"Lotid={lot3.Lotid} Processsegmentruleid={lot3.Processsegmentruleid} Rulesequence={lot3.Rulesequence} Processingstate={lot3.Processingstate}");
			}
			string processsegmentid = lot3.Processsegmentid;
			Processsegment processsegment = PROCESSSEGMENT.SelectProcessSegment(dbContext, processsegmentid, siteid);
			if (processsegment == null)
			{
				throw new EntityNotFoundException(typeof(Processsegment), processsegmentid);
			}
			string processsegmentruleclsid = processsegment.Processsegmentruleclsid;
			Processsegmentruleclsrel processsegmentruleclsrel = PROCESSSEGMENTRULECLSREL.SelectProcessSegmentRuleClsRel(dbContext, processsegmentruleclsid, processsegmentruleid, siteid);
			if (processsegmentruleclsrel == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentruleclsrel), processsegmentruleid);
			}
			lot3.Processsegmentruleid = processsegmentruleid;
			lot3.Rulesequence = processsegmentruleclsrel.Rulesequence;
			if (processsegmentruleclsrel.Isstart == "Y")
			{
				lot3.Processingstate = "WaitForRule";
			}
			else
			{
				lot3.Processingstate = "ProcessingRule";
			}
			lot2.CopyCommonFieldUpdatePrev(lot3, systemTime, tid, text);
			lot2.CopyExtensionCollection(lot3);
			list.Add(lot3);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", $"Lotid={lot3.Lotid} Prevprocesssegmentid={lot3.Prevprocesssegmentid} Processsegmentid={lot3.Processsegmentid} Prevlocation={lot3.Prevlocation} Location={lot3.Location}");
			}
			foreach (Producedmaterial item in PRODUCEDMATERIAL.FindProducedMaterialList(list3.ToArray(), lotid))
			{
				if (!PRODUCEDMATERIAL.ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, item))
				{
					throw new EntityIsHoldException(typeof(Producedmaterial), item.Producedmaterialid);
				}
				if (MesLogger.IsDebugEnabled("API"))
				{
					MesLogger.DebugTidApi(tid, "Before Execute", $"Producedmaterialid={item.Producedmaterialid} Processingstate={item.Processingstate}");
				}
				item.Processingstate = lot3.Processingstate;
				lot2.CopyCommonFieldUpdatePrev(item, systemTime, tid, text);
				list2.Add(item);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={item.Producedmaterialid} Processingstate={item.Processingstate}");
				}
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int ReworkFinishLot(IDbContext dbContext, Lot[] lotList, ReworkFinishLotOptionSet optionSet, bool saveHist)
	{
		return ReworkFinishLot(dbContext, lotList, null, optionSet, saveHist);
	}

	public static int ReworkFinishLot(IDbContext dbContext, Lot[] lotList, Lotadhocprocess[] manualReturnProcessList, ReworkFinishLotOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		object[] objectList = lotList;
		ParamChecker.ArgumentNotNullAndHasElement("lotList", objectList);
		string text = "ReworkFinishLot";
		int apiVersion = 2;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		bool flag = false;
		if (manualReturnProcessList != null)
		{
			objectList = lotList;
			object[] arr = objectList;
			objectList = manualReturnProcessList;
			ParamChecker.ArraySameLength(arr, objectList);
			flag = true;
		}
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		bool saveHistFutureAction = optionSet?.SaveHistRunFutureAction ?? false;
		string customActivityFutureAction = optionSet?.CustomActivityRunFutureAction;
		DateTime modifyTimeFutureAction = ((optionSet != null && optionSet.ModifytimeRunFutureAction != DateTime.MinValue) ? optionSet.ModifytimeRunFutureAction : systemTime);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		List<Lotadhocprocess> list3 = new List<Lotadhocprocess>();
		string siteid = lotList[0].Siteid;
		List<Producedmaterial> list4 = new List<Producedmaterial>();
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		Lot[] array2 = array;
		foreach (Lot lot in array2)
		{
			Producedmaterial[] array3 = PRODUCEDMATERIAL.SelectProducedMaterialListAliveByLot4Update(dbContext, lot.Lotid, siteid).ToArray();
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lot.Lotid} ProducedMaterial Count={array3.Length}");
			}
			list4.AddRange(array3);
		}
		for (int j = 0; j < lotList.Length; j++)
		{
			Lot lot2 = lotList[j];
			Lotadhocprocess lotadhocprocess = null;
			ParamChecker.ArgumentNotNull("Lotid", lot2.Lotid);
			ParamChecker.ArgumentNotNull("Siteid", lot2.Siteid);
			if (flag)
			{
				lotadhocprocess = manualReturnProcessList[j];
				ParamChecker.ArgumentNotNull("manualReturnProcess.Returnprocessdefinitionid", lotadhocprocess.Returnprocessdefinitionid);
				ParamChecker.ArgumentNotNull("manualReturnProcess.Returnsubprocessdefinitionid", lotadhocprocess.Returnsubprocessdefinitionid);
				ParamChecker.ArgumentNotNull("manualReturnProcess.Returnprocesssegmentid", lotadhocprocess.Returnprocesssegmentid);
			}
			siteid = lot2.Siteid;
			string lotid = lot2.Lotid;
			Lot lot3;
			if ((lot3 = FindLot(array, lotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lot), lotid);
			}
			if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot3))
			{
				throw new EntityIsHoldException(typeof(Lot), lotid);
			}
			ParamChecker.EntityInvalidState(typeof(Lot), lotid, lot3.Processingstate, "ProcessingRule");
			if (string.IsNullOrEmpty(lot3.Adhocprocesssysid))
			{
				throw new LotNotInAdhocProcess(lotid, "Rework");
			}
			Lotadhocprocess lotadhocprocess2;
			if ((lotadhocprocess2 = LOTADHOCPROCESS.SelectLotAdhocProcess(dbContext, lot3.Adhocprocesssysid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lotadhocprocess), lot3.Adhocprocesssysid);
			}
			ParamChecker.EntityValidState(typeof(LOTADHOCPROCESS), "Adhocprocesstype", lotadhocprocess2.Adhocprocesstype, "Rework");
			if (flag)
			{
				lotadhocprocess2.Returnprocessdefinitionid = lotadhocprocess.Returnprocessdefinitionid;
				lotadhocprocess2.Returnsubprocessdefinitionid = lotadhocprocess.Returnsubprocessdefinitionid;
				lotadhocprocess2.Returnprocesssegmentid = lotadhocprocess.Returnprocesssegmentid;
				lotadhocprocess2.Returnlocation = lotadhocprocess.Returnlocation;
				lotadhocprocess.CopyCommonFieldUpdatePrev(lotadhocprocess2, systemTime, tid, text);
				lotadhocprocess.CopyExtensionCollection(lotadhocprocess2);
				list3.Add(lotadhocprocess2);
			}
			Processsegment processsegment;
			if ((processsegment = PROCESSSEGMENT.SelectProcessSegment(dbContext, lotadhocprocess2.Returnprocesssegmentid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lotadhocprocess), lot3.Adhocprocesssysid);
			}
			Processsegmentruleclsrel processsegmentruleclsrel;
			if ((processsegmentruleclsrel = PROCESSSEGMENTRULECLSREL.SelectFirstProcessSegmentRuleByRuleCls(dbContext, processsegment.Processsegmentruleclsid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentruleclsrel), processsegment.Processsegmentruleclsid);
			}
			Processnode processnode;
			if ((processnode = PROCESSNODE.SelectProcessSegmentNode(dbContext, lotadhocprocess2.Returnprocessdefinitionid, lotadhocprocess2.Returnsubprocessdefinitionid, lotadhocprocess2.Returnprocesssegmentid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Processnode), lotadhocprocess2.Returnprocessdefinitionid + ":" + lotadhocprocess2.Returnsubprocessdefinitionid + ":" + lotadhocprocess2.Returnprocesssegmentid);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", $"Lotid={lot3.Lotid} Adhocprocesssysid={lot3.Adhocprocesssysid} Reworkcount={lot3.Reworkcount} Totreworkcount={lot3.Totreworkcount} Processsegmentid={lot3.Processsegmentid} Location={lot3.Location}");
			}
			lot3.Adhocprocesssysid = lotadhocprocess2.Setlotadhocprocesssysid;
			lot3.Prevprocessdefinitionid = lot3.Processdefinitionid;
			lot3.Prevsubprocessdefinitionid = lot3.Subprocessdefinitionid;
			lot3.Prevprocesssegmentid = lot3.Processsegmentid;
			lot3.Prevprocessnodeid = lot3.Processnodeid;
			lot3.Processdefinitionid = lotadhocprocess2.Returnprocessdefinitionid;
			lot3.Subprocessdefinitionid = lotadhocprocess2.Returnsubprocessdefinitionid;
			lot3.Processsegmentid = lotadhocprocess2.Returnprocesssegmentid;
			lot3.Processnodeid = processnode.Processnodeid;
			lot3.Processsegmentruleid = processsegmentruleclsrel.Processsegmentruleid;
			lot3.Rulesequence = processsegmentruleclsrel.Rulesequence;
			lot3.Processingstate = "WaitForRule";
			lot3.Receivedtime = EntityHelper.FirstNotNull<DateTime>(lot2.Modifytime, systemTime);
			if (lot3.Location != lotadhocprocess2.Returnlocation)
			{
				lot3.Prevlocation = lot3.Location;
				lot3.Location = lotadhocprocess2.Returnlocation;
			}
			lot3.Reworkcount = lot3.Reworkcount.Add(-1);
			lot3.Totreworkcount = lot3.Totreworkcount.Add(1);
			int num2 = LOTADHOCPROCESS.SelectAdhocProcessCountWithAdhocProcessType(dbContext, lotid, siteid, "Rework") - 1;
			lot3.Isrework = ((num2 <= 0) ? "N" : "Y");
			lot2.CopyCommonFieldUpdatePrev(lot3, systemTime, tid, text);
			lot2.CopyExtensionCollection(lot3);
			list.Add(lot3);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", $"Lotid={lot3.Lotid} Adhocprocesssysid={lot3.Adhocprocesssysid} Reworkcount={lot3.Reworkcount} Totreworkcount={lot3.Totreworkcount} Processsegmentid={lot3.Processsegmentid} Location={lot3.Location}");
			}
			if (!flag)
			{
				lot2.CopyCommonFieldUpdatePrev(lotadhocprocess2, systemTime, tid, text);
				list3.Add(lotadhocprocess2);
			}
			foreach (Producedmaterial item in PRODUCEDMATERIAL.FindProducedMaterialList(list4.ToArray(), lotid))
			{
				if (!PRODUCEDMATERIAL.ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, item))
				{
					throw new EntityIsHoldException(typeof(Producedmaterial), item.Producedmaterialid);
				}
				if (MesLogger.IsDebugEnabled("API"))
				{
					MesLogger.DebugTidApi(tid, "Before Execute", $"Producedmaterialid={item.Producedmaterialid} Processsegmentid={item.Processsegmentid} Location={item.Location}");
				}
				item.Isrework = lot3.Isrework;
				PRODUCEDMATERIAL.InheritLotProcessInfo(lot3, item);
				if (item.Location != lot3.Location)
				{
					item.Prevlocation = item.Location;
					item.Location = lot3.Location;
				}
				lot2.CopyCommonFieldUpdatePrev(item, systemTime, tid, text);
				list2.Add(item);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={item.Producedmaterialid} Processsegmentid={item.Processsegmentid} Location={item.Location}");
				}
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list3.ToArray(), saveHist);
		foreach (Lot item2 in list)
		{
			if (LOTFUTUREACTION.GetLotFutureActionCountCurrentSegmentRule(dbContext, item2) > 0)
			{
				RunLotFutureAction(dbContext, item2, "Y", customActivityFutureAction, saveHistFutureAction, modifyTimeFutureAction);
			}
		}
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int ReworkStartLot(IDbContext dbContext, Lot[] lotList, Lotadhocprocess[] adhocProcessList, ReworkStartLotOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		object[] objectList = lotList;
		ParamChecker.ArgumentNotNullAndHasElement("lotList", objectList);
		objectList = adhocProcessList;
		ParamChecker.ArgumentNotNullAndHasElement("adhocProcessList", objectList);
		objectList = lotList;
		object[] arr = objectList;
		objectList = adhocProcessList;
		ParamChecker.ArraySameLength(arr, objectList);
		string text = "ReworkStartLot";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		bool saveHistFutureAction = optionSet?.SaveHistRunFutureAction ?? false;
		string customActivityFutureAction = optionSet?.CustomActivityRunFutureAction;
		DateTime modifyTimeFutureAction = ((optionSet != null && optionSet.ModifytimeRunFutureAction != DateTime.MinValue) ? optionSet.ModifytimeRunFutureAction : systemTime);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		List<Lotadhocprocess> list3 = new List<Lotadhocprocess>();
		string siteid = lotList[0].Siteid;
		List<Producedmaterial> list4 = new List<Producedmaterial>();
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		Lot[] array2 = array;
		foreach (Lot lot in array2)
		{
			Producedmaterial[] array3 = PRODUCEDMATERIAL.SelectProducedMaterialListAliveByLot4Update(dbContext, lot.Lotid, siteid).ToArray();
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lot.Lotid} ProducedMaterial Count={array3.Length}");
			}
			list4.AddRange(array3);
		}
		for (int j = 0; j < lotList.Length; j++)
		{
			Lot lot2 = lotList[j];
			Lotadhocprocess lotadhocprocess = adhocProcessList[j];
			ParamChecker.ArgumentNotNull("Lotid", lot2.Lotid);
			ParamChecker.ArgumentNotNull("Siteid", lot2.Siteid);
			ParamChecker.ArgumentNotNull("Startprocessdefinitionid", lotadhocprocess.Startprocessdefinitionid);
			ParamChecker.ArgumentNotNull("Startsubprocessdefinitionid", lotadhocprocess.Startsubprocessdefinitionid);
			ParamChecker.ArgumentNotNull("Startprocesssegmentid", lotadhocprocess.Startprocesssegmentid);
			ParamChecker.ArgumentNotNull("Finishprocessdefinitionid", lotadhocprocess.Finishprocessdefinitionid);
			ParamChecker.ArgumentNotNull("Finishsubprocessdefinitionid", lotadhocprocess.Finishsubprocessdefinitionid);
			ParamChecker.ArgumentNotNull("Finishprocesssegmentid", lotadhocprocess.Finishprocesssegmentid);
			ParamChecker.ArgumentNotNull("Returnprocessdefinitionid", lotadhocprocess.Returnprocessdefinitionid);
			ParamChecker.ArgumentNotNull("Returnsubprocessdefinitionid", lotadhocprocess.Returnsubprocessdefinitionid);
			ParamChecker.ArgumentNotNull("Returnprocesssegmentid", lotadhocprocess.Returnprocesssegmentid);
			siteid = lot2.Siteid;
			string lotid = lot2.Lotid;
			Lot lot3;
			if ((lot3 = FindLot(array, lotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lot), lotid);
			}
			if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot3))
			{
				throw new EntityIsHoldException(typeof(Lot), lotid);
			}
			ParamChecker.EntityInvalidState(typeof(Lot), lotid, lot3.Processingstate, "ProcessingRule");
			string nextTID = ContextManager.GetNextTID();
			int num2 = LOTADHOCPROCESS.SelectMaxAdhocDepth(dbContext, lotid, siteid, "Rework") + 1;
			Processsegmentruleclsrel processsegmentruleclsrel = null;
			if (PROCESSDEFINITION.SelectProcessDefinition(dbContext, lotadhocprocess.Startprocessdefinitionid, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(Processdefinition), lotadhocprocess.Startprocessdefinitionid);
			}
			Processsegment processsegment;
			if ((processsegment = PROCESSSEGMENT.SelectProcessSegment(dbContext, lotadhocprocess.Startprocesssegmentid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Processsegment), lotadhocprocess.Startprocesssegmentid);
			}
			if ((processsegmentruleclsrel = PROCESSSEGMENTRULECLSREL.SelectFirstProcessSegmentRuleByRuleCls(dbContext, processsegment.Processsegmentruleclsid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentruleclsrel), processsegment.Processsegmentruleclsid);
			}
			if (PROCESSDEFINITION.SelectProcessDefinition(dbContext, lotadhocprocess.Finishprocessdefinitionid, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(Processdefinition), lotadhocprocess.Finishprocessdefinitionid);
			}
			if ((processsegment = PROCESSSEGMENT.SelectProcessSegment(dbContext, lotadhocprocess.Finishprocesssegmentid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Processsegment), lotadhocprocess.Finishprocesssegmentid);
			}
			if (PROCESSDEFINITION.SelectProcessDefinition(dbContext, lotadhocprocess.Returnprocessdefinitionid, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(Processdefinition), lotadhocprocess.Returnprocessdefinitionid);
			}
			if ((processsegment = PROCESSSEGMENT.SelectProcessSegment(dbContext, lotadhocprocess.Returnprocesssegmentid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Processsegment), lotadhocprocess.Returnprocesssegmentid);
			}
			if (!string.IsNullOrEmpty(lotadhocprocess.Returnlocation) && FACILITY.SelectFacility(dbContext, lotadhocprocess.Returnlocation, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(Facility), lotadhocprocess.Returnlocation);
			}
			Lotadhocprocess lotadhocprocess2 = new Lotadhocprocess();
			lotadhocprocess2.Lotadhocprocesssysid = nextTID;
			lotadhocprocess2.Lotid = lotid;
			lotadhocprocess2.Siteid = siteid;
			lotadhocprocess2.Setlotadhocprocesssysid = lot3.Adhocprocesssysid;
			lotadhocprocess2.Setprocessdefinitionid = lot3.Processdefinitionid;
			lotadhocprocess2.Setsubprocessdefinitionid = lot3.Subprocessdefinitionid;
			lotadhocprocess2.Setprocesssegmentid = lot3.Processsegmentid;
			lotadhocprocess2.Startprocessdefinitionid = lotadhocprocess.Startprocessdefinitionid;
			lotadhocprocess2.Startsubprocessdefinitionid = lotadhocprocess.Startsubprocessdefinitionid;
			lotadhocprocess2.Startprocesssegmentid = lotadhocprocess.Startprocesssegmentid;
			lotadhocprocess2.Finishprocessdefinitionid = lotadhocprocess.Finishprocessdefinitionid;
			lotadhocprocess2.Finishsubprocessdefinitionid = lotadhocprocess.Finishsubprocessdefinitionid;
			lotadhocprocess2.Finishprocesssegmentid = lotadhocprocess.Finishprocesssegmentid;
			lotadhocprocess2.Returnprocessdefinitionid = lotadhocprocess.Returnprocessdefinitionid;
			lotadhocprocess2.Returnsubprocessdefinitionid = lotadhocprocess.Returnsubprocessdefinitionid;
			lotadhocprocess2.Returnprocesssegmentid = lotadhocprocess.Returnprocesssegmentid;
			lotadhocprocess2.Returnlocation = lotadhocprocess.Returnlocation;
			lotadhocprocess2.Adhocdepth = num2;
			lotadhocprocess2.Adhocprocesstype = "Rework";
			lotadhocprocess2.Isusable = "Usable";
			lotadhocprocess2.Prevactivity = null;
			lotadhocprocess2.Activity = text;
			lotadhocprocess2.Prevcustomactivity = null;
			lotadhocprocess.CopyCommonField(lotadhocprocess2, systemTime, tid, isCreate: true);
			lotadhocprocess2.Customactivity = EntityHelper.FirstNotNull<string>(lotadhocprocess.Customactivity, lotadhocprocess2.Activity);
			lotadhocprocess.CopyExtensionCollection(lotadhocprocess2);
			list3.Add(lotadhocprocess2);
			Processnode processnode = PROCESSNODE.SelectProcessSegmentNode(dbContext, lotadhocprocess.Startprocessdefinitionid, lotadhocprocess.Startsubprocessdefinitionid, lotadhocprocess.Startprocesssegmentid, siteid);
			if (processnode == null)
			{
				throw new EntityNotFoundException(typeof(Processnode), lotadhocprocess.Startprocessdefinitionid + ":" + lotadhocprocess.Startsubprocessdefinitionid + ":" + lotadhocprocess.Startprocesssegmentid);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", $"Lotid={lot3.Lotid} Adhocprocesssysid={lot3.Adhocprocesssysid} Reworkcount={lot3.Reworkcount} Processsegmentid={lot3.Processsegmentid} Location={lot3.Location}");
			}
			lot3.Adhocprocesssysid = nextTID;
			lot3.Prevprocessdefinitionid = lot3.Processdefinitionid;
			lot3.Prevsubprocessdefinitionid = lot3.Subprocessdefinitionid;
			lot3.Prevprocesssegmentid = lot3.Processsegmentid;
			lot3.Prevprocessnodeid = lot3.Processnodeid;
			lot3.Processdefinitionid = lotadhocprocess.Startprocessdefinitionid;
			lot3.Subprocessdefinitionid = lotadhocprocess.Startsubprocessdefinitionid;
			lot3.Processsegmentid = lotadhocprocess.Startprocesssegmentid;
			lot3.Processnodeid = processnode.Processnodeid;
			lot3.Processsegmentruleid = processsegmentruleclsrel.Processsegmentruleid;
			lot3.Rulesequence = processsegmentruleclsrel.Rulesequence;
			lot3.Processingstate = "WaitForRule";
			lot3.Receivedtime = EntityHelper.FirstNotNull<DateTime>(lot2.Modifytime, systemTime);
			lot3.Isrework = "Y";
			lot3.Reworkcount = num2;
			if (lot3.Location != lot2.Location)
			{
				lot3.Prevlocation = lot3.Location;
				lot3.Location = lot2.Location;
			}
			lot2.CopyCommonFieldUpdatePrev(lot3, systemTime, tid, text);
			lot2.CopyExtensionCollection(lot3);
			list.Add(lot3);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", $"Lotid={lot3.Lotid} Adhocprocesssysid={lot3.Adhocprocesssysid} Reworkcount={lot3.Reworkcount} Processsegmentid={lot3.Processsegmentid} Location={lot3.Location}");
			}
			foreach (Producedmaterial item in PRODUCEDMATERIAL.FindProducedMaterialList(list4.ToArray(), lotid))
			{
				if (!PRODUCEDMATERIAL.ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, item))
				{
					throw new EntityIsHoldException(typeof(Producedmaterial), item.Producedmaterialid);
				}
				if (MesLogger.IsDebugEnabled("API"))
				{
					MesLogger.DebugTidApi(tid, "Before Execute", $"Producedmaterialid={item.Producedmaterialid} Processsegmentid={item.Processsegmentid} Location={item.Location}");
				}
				item.Isrework = "Y";
				PRODUCEDMATERIAL.InheritLotProcessInfo(lot3, item);
				if (item.Location != lot2.Location)
				{
					item.Prevlocation = item.Location;
					item.Location = lot2.Location;
				}
				lot2.CopyCommonFieldUpdatePrev(item, systemTime, tid, text);
				list2.Add(item);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={item.Producedmaterialid} Processsegmentid={item.Processsegmentid} Location={item.Location}");
				}
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list3.ToArray(), saveHist);
		foreach (Lot item2 in list)
		{
			if (LOTFUTUREACTION.GetLotFutureActionCountCurrentSegmentRule(dbContext, item2) > 0)
			{
				RunLotFutureAction(dbContext, item2, "Y", customActivityFutureAction, saveHistFutureAction, modifyTimeFutureAction);
			}
		}
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int RunFutureAction(IDbContext dbContext, Lot[] lotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotList", lotList);
		string text = "RunFutureAction";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Lotfutureaction> list2 = new List<Lotfutureaction>();
		string siteid = lotList[0].Siteid;
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		foreach (Lot lot in lotList)
		{
			ParamChecker.ArgumentNotNull("Lotid", lot.Lotid);
			ParamChecker.ArgumentNotNull("Siteid", lot.Siteid);
			siteid = lot.Siteid;
			string lotid = lot.Lotid;
			Lot lot2;
			if ((lot2 = FindLot(array, lotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lot), lotid);
			}
			if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot2))
			{
				throw new EntityIsHoldException(typeof(Lot), lotid);
			}
			Lotfutureaction lotfutureaction = new Lotfutureaction();
			lotfutureaction.Lotid = lot2.Lotid;
			lotfutureaction.Siteid = lot2.Siteid;
			lotfutureaction.Actionproductdefinitionid = lot2.Productdefinitionid;
			lotfutureaction.Actionprocessdefinitionid = lot2.Processdefinitionid;
			lotfutureaction.Actionprocesssegmentid = lot2.Processsegmentid;
			lotfutureaction.Actionsubprocessdefinitionid = lot2.Subprocessdefinitionid;
			IList<Lotfutureaction> lotFutureActionList = LOTFUTUREACTION.GetLotFutureActionList(dbContext, lotfutureaction);
			if (lotFutureActionList.Count == 0)
			{
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "Future Action Not Found", $"Lotid={lot2.Lotid}");
				}
				continue;
			}
			foreach (Lotfutureaction item in lotFutureActionList)
			{
				if ((item.Isprocesssegmentstart == "Y" && lot2.Processingstate == "WaitForRule") || (item.Isprocesssegmentstart == "N" && lot2.Processingstate == "WaitForSegment"))
				{
					Lot lot3 = new Lot();
					lot3.Siteid = siteid;
					lot3.Lotid = lotid;
					if (MesLogger.IsDebugEnabled("API"))
					{
						MesLogger.DebugTidApi(tid, "Before Execute", $"Lotid={item.Lotid} Actiontype={item.Actiontype}");
					}
					if (item.Actiontype == "HoldLot")
					{
						Lothold lothold = new Lothold();
						lothold.Lotid = lotid;
						lothold.Siteid = siteid;
						lothold.Customactivity = item.Actionactivityoverride;
						lothold.Holdcode = item.Actionreasoncode;
						lothold.Description = item.Actiondescription;
						lothold.Comments = item.Actioncomments;
						num += HoldLot(dbContext, lot3, new Lothold[1] { lothold }, null, saveHist, saveHist);
					}
					lot.CopyCommonFieldUpdatePrev(item, systemTime, tid, text);
					list2.Add(item);
					if (MesLogger.IsInfoEnabled("API"))
					{
						MesLogger.InfoTidApi(tid, "After Execute", $"Lotid={item.Lotid} Actiontype={item.Actiontype}");
					}
				}
			}
			num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list2.ToArray(), saveHist);
			Lotfutureaction lotfutureaction2 = new Lotfutureaction();
			lotfutureaction2.Lotid = lotid;
			lotfutureaction2.Siteid = siteid;
			lot2 = SelectLot4Update(dbContext, lotid, siteid);
			if (LOTFUTUREACTION.GetLotFutureActionCount(dbContext, lotfutureaction2) == 0)
			{
				lot2.Isreservedfutureaction = "N";
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "No Lotfutureaction remains", $"Lotid={lot2.Lotid} Isreservedfutureaction={lot2.Isreservedfutureaction}");
				}
			}
			lot.CopyCommonFieldUpdatePrev(lot2, systemTime, tid, text);
			lot.CopyExtensionCollection(lot2);
			list.Add(lot2);
			num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		}
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int ScrapLot(IDbContext dbContext, Lot[] lotList, ScrapLotOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotList", lotList);
		string text = "ScrapLot";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		List<Carrier> list3 = new List<Carrier>();
		List<Lotcarrierrel> list4 = new List<Lotcarrierrel>();
		string siteid = lotList[0].Siteid;
		List<Producedmaterial> list5 = new List<Producedmaterial>();
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		Lot[] array2 = array;
		foreach (Lot lot in array2)
		{
			Producedmaterial[] array3 = PRODUCEDMATERIAL.SelectProducedMaterialListAliveByLot4Update(dbContext, lot.Lotid, siteid).ToArray();
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lot.Lotid} ProducedMaterial Count={array3.Length}");
			}
			list5.AddRange(array3);
		}
		array2 = lotList;
		foreach (Lot lot2 in array2)
		{
			ParamChecker.ArgumentNotNull("Lotid", lot2.Lotid);
			ParamChecker.ArgumentNotNull("Siteid", lot2.Siteid);
			string lotid = lot2.Lotid;
			Lot lot3 = null;
			if ((lot3 = FindLot(array, lotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lot), lotid);
			}
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "Select4Update", lot3);
			}
			Producedmaterial[] array4 = PRODUCEDMATERIAL.FindProducedMaterialList(list5.ToArray(), lotid).ToArray();
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lot3.Lotid} ProducedMaterial Count={array4.Length}");
			}
			if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot3))
			{
				throw new EntityIsHoldException(typeof(Lot), lotid);
			}
			ParamChecker.EntityInvalidState(typeof(Lot), "State", lot3.State, "Scrapped");
			decimal valueOrDefault = lot3.Qty.GetValueOrDefault();
			decimal valueOrDefault2 = lot3.Submaterialqty.GetValueOrDefault();
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "CalcQty", $"Lotid={lot3.Lotid} Minus Qty={valueOrDefault} Submaterialqty={valueOrDefault2}");
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", $"Lotid={lot3.Lotid} State={lot3.State} Lossqty={lot3.Lossqty} Qty={lot3.Qty} Submaterialqty={lot3.Submaterialqty}");
			}
			lot3.Prevstate = lot3.State;
			lot3.State = "Scrapped";
			lot3.Prevlossqty = lot3.Lossqty;
			lot3.Lossqty = lot3.Lossqty.Add(valueOrDefault);
			lot3.Prevqty = lot3.Qty;
			lot3.Qty = lot3.Qty.Add(-valueOrDefault);
			lot3.Prevsubmaterialqty = lot3.Submaterialqty;
			lot3.Submaterialqty = lot3.Submaterialqty.Add(-valueOrDefault2);
			lot2.CopyCommonFieldUpdatePrev(lot3, systemTime, tid, text);
			lot2.CopyExtensionCollection(lot3);
			list.Add(lot3);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", $"Lotid={lot3.Lotid} State={lot3.State} Lossqty={lot3.Lossqty} Qty={lot3.Qty} Submaterialqty={lot3.Submaterialqty}");
			}
			Producedmaterial[] array5 = array4;
			foreach (Producedmaterial producedmaterial in array5)
			{
				_ = producedmaterial.Producedmaterialid;
				if (!PRODUCEDMATERIAL.ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, producedmaterial))
				{
					throw new EntityIsHoldException(typeof(Producedmaterial), producedmaterial.Producedmaterialid);
				}
				ParamChecker.EntityInvalidState(typeof(Producedmaterial), "State", producedmaterial.State, "Scrapped");
				if (MesLogger.IsDebugEnabled("API"))
				{
					MesLogger.DebugTidApi(tid, "Before Execute", $"Producedmaterialid={producedmaterial.Producedmaterialid} State={producedmaterial.State} Slotno={producedmaterial.Slotno} Carrierid={producedmaterial.Carrierid}");
				}
				producedmaterial.Prevstate = producedmaterial.State;
				producedmaterial.State = "Scrapped";
				producedmaterial.Prevslotno = producedmaterial.Slotno;
				producedmaterial.Slotno = 0;
				producedmaterial.Prevcarrierid = producedmaterial.Carrierid;
				producedmaterial.Carrierid = null;
				lot2.CopyCommonFieldUpdatePrev(producedmaterial, systemTime, tid, text);
				list2.Add(producedmaterial);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={producedmaterial.Producedmaterialid} State={producedmaterial.State} Slotno={producedmaterial.Slotno} Carrierid={producedmaterial.Carrierid}");
				}
			}
			Lotcarrierrel[] array6 = LOTCARRIERREL.GetLotCarrierRelList(dbContext, lotid, siteid).ToArray();
			string[] distinctCarrierList = LOTCARRIERREL.GetDistinctCarrierList(array6);
			foreach (string carrierid in distinctCarrierList)
			{
				Carrier carrier = CARRIER.SelectCarrier4Update(dbContext, carrierid, siteid);
				lot2.CopyCommonFieldUpdatePrev(carrier, systemTime, tid, text);
				list3.Add(carrier);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Execute Carrier", $"Carrierid={carrier.Carrierid}");
				}
			}
			Lotcarrierrel[] array7 = array6;
			foreach (Lotcarrierrel lotcarrierrel in array7)
			{
				lot2.CopyCommonFieldUpdatePrev(lotcarrierrel, systemTime, tid, text);
				list4.Add(lotcarrierrel);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Execute Lotcarrierrel", $"Lotid={lotcarrierrel.Lotid} Carrierid={lotcarrierrel.Carrierid} Slotposition={lotcarrierrel.Slotposition}");
				}
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list3.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list4.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int ScrapLot(IDbContext dbContext, Lot inputLot, Producedmaterial[] inputProducedMaterialList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("inputLot", inputLot);
		ParamChecker.ArgumentNotNull("Lotid", inputLot.Lotid);
		ParamChecker.ArgumentNotNull("Siteid", inputLot.Siteid);
		ParamChecker.ArgumentNotNullAndHasElement("inputProducedMaterialList", inputProducedMaterialList);
		string text = "ScrapLot";
		int apiVersion = 2;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		List<Carrier> list3 = new List<Carrier>();
		List<Lotcarrierrel> list4 = new List<Lotcarrierrel>();
		string lotid = inputLot.Lotid;
		string siteid = inputLot.Siteid;
		Lot lot = null;
		bool flag = false;
		if ((lot = SelectLot4Update(dbContext, lotid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Lot), lotid);
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", lot);
		}
		Producedmaterial[] array = PRODUCEDMATERIAL.SelectProducedMaterialListAliveByLot4Update(dbContext, lotid, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lot.Lotid} ProducedMaterial Count={array.Length}");
		}
		if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot))
		{
			throw new EntityIsHoldException(typeof(Lot), lotid);
		}
		ParamChecker.EntityInvalidState(typeof(Lot), "State", lot.State, "Scrapped");
		string[] countableProducedMaterialGradeIdList = getCountableProducedMaterialGradeIdList(dbContext, siteid);
		string[] countableSubproducedMaterialGradeIdList = getCountableSubproducedMaterialGradeIdList(dbContext, siteid);
		List<Producedmaterial> list5 = new List<Producedmaterial>();
		List<Producedmaterial> list6 = new List<Producedmaterial>();
		Producedmaterial[] array2 = inputProducedMaterialList;
		foreach (Producedmaterial producedmaterial in array2)
		{
			Producedmaterial producedmaterial2 = PRODUCEDMATERIAL.FindProducedMaterial(array, producedmaterial.Producedmaterialid);
			if (producedmaterial2 == null)
			{
				throw new EntityNotFoundException(typeof(Producedmaterial), producedmaterial.Producedmaterialid);
			}
			list6.Add(producedmaterial2);
		}
		array2 = array;
		foreach (Producedmaterial producedmaterial3 in array2)
		{
			if (PRODUCEDMATERIAL.FindProducedMaterial(list6.ToArray(), producedmaterial3.Producedmaterialid) == null)
			{
				list5.Add(producedmaterial3);
			}
		}
		if (list5.Count == 0)
		{
			flag = true;
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "No alive Producedmaterial remains", $"Lotid={lot.Lotid}");
			}
		}
		decimal lotQty = GetLotQty(dbContext, countableProducedMaterialGradeIdList, list6.ToArray());
		decimal subProducedMaterialQty = GetSubProducedMaterialQty(dbContext, countableSubproducedMaterialGradeIdList, list6.ToArray());
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "CalcQty", $"Lotid={lot.Lotid} Minus Qty={lotQty} Submaterialqty={subProducedMaterialQty}");
		}
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", $"Lotid={lot.Lotid} State={lot.State} Lossqty={lot.Lossqty} Qty={lot.Qty} Submaterialqty={lot.Submaterialqty}");
		}
		if (flag)
		{
			lot.Prevstate = lot.State;
			lot.State = "Scrapped";
		}
		lot.Prevlossqty = lot.Lossqty;
		lot.Lossqty = lot.Lossqty.Add(lotQty);
		lot.Prevqty = lot.Qty;
		lot.Qty = lot.Qty.Add(-lotQty);
		lot.Prevsubmaterialqty = lot.Submaterialqty;
		lot.Submaterialqty = lot.Submaterialqty.Add(-subProducedMaterialQty);
		if (flag)
		{
			lot.Prevactivity = lot.Activity;
			lot.Activity = text;
		}
		lot.Prevcustomactivity = lot.Customactivity;
		inputLot.CopyCommonField(lot, systemTime, tid, isCreate: false);
		lot.Customactivity = EntityHelper.FirstNotNull<string>(inputLot.Customactivity, lot.Activity);
		inputLot.CopyExtensionCollection(lot);
		list.Add(lot);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", $"Lotid={lot.Lotid} State={lot.State} Lossqty={lot.Lossqty} Qty={lot.Qty} Submaterialqty={lot.Submaterialqty}");
		}
		array2 = inputProducedMaterialList;
		foreach (Producedmaterial producedmaterial4 in array2)
		{
			string producedmaterialid = producedmaterial4.Producedmaterialid;
			Producedmaterial producedmaterial5 = PRODUCEDMATERIAL.FindProducedMaterial(list6.ToArray(), producedmaterialid);
			if (!PRODUCEDMATERIAL.ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, producedmaterial5))
			{
				throw new EntityIsHoldException(typeof(Producedmaterial), producedmaterial5.Producedmaterialid);
			}
			ParamChecker.EntityInvalidState(typeof(Producedmaterial), "State", producedmaterial5.State, "Scrapped");
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", $"Producedmaterialid={producedmaterial5.Producedmaterialid} State={producedmaterial5.State} Slotno={producedmaterial5.Slotno} Carrierid={producedmaterial5.Carrierid}");
			}
			producedmaterial5.Prevstate = producedmaterial5.State;
			producedmaterial5.State = "Scrapped";
			producedmaterial5.Prevslotno = producedmaterial5.Slotno;
			producedmaterial5.Slotno = 0;
			producedmaterial5.Prevcarrierid = producedmaterial5.Carrierid;
			producedmaterial5.Carrierid = null;
			producedmaterial4.CopyCommonFieldUpdatePrev(producedmaterial5, systemTime, tid, text);
			producedmaterial4.CopyExtensionCollection(producedmaterial5);
			list2.Add(producedmaterial5);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={producedmaterial5.Producedmaterialid} State={producedmaterial5.State} Slotno={producedmaterial5.Slotno} Carrierid={producedmaterial5.Carrierid}");
			}
		}
		if (flag)
		{
			Lotcarrierrel[] array3 = LOTCARRIERREL.GetLotCarrierRelList(dbContext, lotid, siteid).ToArray();
			string[] distinctCarrierList = LOTCARRIERREL.GetDistinctCarrierList(array3);
			foreach (string carrierid in distinctCarrierList)
			{
				Carrier carrier = CARRIER.SelectCarrier4Update(dbContext, carrierid, siteid);
				inputLot.CopyCommonFieldUpdatePrev(carrier, systemTime, tid, text);
				list3.Add(carrier);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Execute Carrier", $"Carrierid={carrier.Carrierid}");
				}
			}
			Lotcarrierrel[] array4 = array3;
			foreach (Lotcarrierrel lotcarrierrel in array4)
			{
				inputLot.CopyCommonFieldUpdatePrev(lotcarrierrel, systemTime, tid, text);
				list4.Add(lotcarrierrel);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Execute Lotcarrierrel", $"Lotid={lotcarrierrel.Lotid} Carrierid={lotcarrierrel.Carrierid} Slotposition={lotcarrierrel.Slotposition}");
				}
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list3.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list4.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int SegmentInjectFinishLot(IDbContext dbContext, Lot[] lotList, SegmentInjectFinishLotOptionSet optionSet, bool saveHist)
	{
		return SegmentInjectFinishLot(dbContext, lotList, null, optionSet, saveHist);
	}

	public static int SegmentInjectFinishLot(IDbContext dbContext, Lot[] lotList, Lotadhocprocess[] manualReturnProcessList, SegmentInjectFinishLotOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		object[] objectList = lotList;
		ParamChecker.ArgumentNotNull("lotList", objectList);
		string text = "SegmentInjectFinishLot";
		int apiVersion = 2;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		bool flag = false;
		if (manualReturnProcessList != null)
		{
			objectList = lotList;
			object[] arr = objectList;
			objectList = manualReturnProcessList;
			ParamChecker.ArraySameLength(arr, objectList);
			flag = true;
		}
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		bool saveHistFutureAction = optionSet?.SaveHistRunFutureAction ?? false;
		string customActivityFutureAction = optionSet?.CustomActivityRunFutureAction;
		DateTime modifyTimeFutureAction = ((optionSet != null && optionSet.ModifytimeRunFutureAction != DateTime.MinValue) ? optionSet.ModifytimeRunFutureAction : systemTime);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		List<Lotadhocprocess> list3 = new List<Lotadhocprocess>();
		string siteid = lotList[0].Siteid;
		List<Producedmaterial> list4 = new List<Producedmaterial>();
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		Lot[] array2 = array;
		foreach (Lot lot in array2)
		{
			Producedmaterial[] array3 = PRODUCEDMATERIAL.SelectProducedMaterialListAliveByLot4Update(dbContext, lot.Lotid, siteid).ToArray();
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lot.Lotid} ProducedMaterial Count={array3.Length}");
			}
			list4.AddRange(array3);
		}
		for (int j = 0; j < lotList.Length; j++)
		{
			Lot lot2 = lotList[j];
			Lotadhocprocess lotadhocprocess = null;
			ParamChecker.ArgumentNotNull("Lotid", lot2.Lotid);
			ParamChecker.ArgumentNotNull("Siteid", lot2.Siteid);
			if (flag)
			{
				lotadhocprocess = manualReturnProcessList[j];
				ParamChecker.ArgumentNotNull("manualReturnProcess.Returnprocessdefinitionid", lotadhocprocess.Returnprocessdefinitionid);
				ParamChecker.ArgumentNotNull("manualReturnProcess.Returnsubprocessdefinitionid", lotadhocprocess.Returnsubprocessdefinitionid);
				ParamChecker.ArgumentNotNull("manualReturnProcess.Returnprocesssegmentid", lotadhocprocess.Returnprocesssegmentid);
			}
			siteid = lot2.Siteid;
			string lotid = lot2.Lotid;
			Lot lot3;
			if ((lot3 = FindLot(array, lotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lot), lotid);
			}
			if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot3))
			{
				throw new EntityIsHoldException(typeof(Lot), lotid);
			}
			ParamChecker.EntityInvalidState(typeof(Lot), lotid, lot3.Processingstate, "ProcessingRule");
			if (string.IsNullOrEmpty(lot3.Adhocprocesssysid))
			{
				throw new LotNotInAdhocProcess(lotid, "SegmentInject");
			}
			Lotadhocprocess lotadhocprocess2;
			if ((lotadhocprocess2 = LOTADHOCPROCESS.SelectLotAdhocProcess(dbContext, lot3.Adhocprocesssysid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lotadhocprocess), lot3.Adhocprocesssysid);
			}
			ParamChecker.EntityValidState(typeof(LOTADHOCPROCESS), "Adhocprocesstype", lotadhocprocess2.Adhocprocesstype, "SegmentInject");
			if (flag)
			{
				lotadhocprocess2.Returnprocessdefinitionid = lotadhocprocess.Returnprocessdefinitionid;
				lotadhocprocess2.Returnsubprocessdefinitionid = lotadhocprocess.Returnsubprocessdefinitionid;
				lotadhocprocess2.Returnprocesssegmentid = lotadhocprocess.Returnprocesssegmentid;
				lotadhocprocess2.Returnlocation = lotadhocprocess.Returnlocation;
				lotadhocprocess.CopyCommonFieldUpdatePrev(lotadhocprocess2, systemTime, tid, text);
				lotadhocprocess.CopyExtensionCollection(lotadhocprocess2);
				list3.Add(lotadhocprocess2);
			}
			Processsegment processsegment;
			if ((processsegment = PROCESSSEGMENT.SelectProcessSegment(dbContext, lotadhocprocess2.Returnprocesssegmentid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lotadhocprocess), lot3.Adhocprocesssysid);
			}
			Processsegmentruleclsrel processsegmentruleclsrel;
			if ((processsegmentruleclsrel = PROCESSSEGMENTRULECLSREL.SelectFirstProcessSegmentRuleByRuleCls(dbContext, processsegment.Processsegmentruleclsid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentruleclsrel), processsegment.Processsegmentruleclsid);
			}
			Processnode processnode;
			if ((processnode = PROCESSNODE.SelectProcessSegmentNode(dbContext, lotadhocprocess2.Returnprocessdefinitionid, lotadhocprocess2.Returnsubprocessdefinitionid, lotadhocprocess2.Returnprocesssegmentid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Processnode), lotadhocprocess2.Returnprocessdefinitionid + ":" + lotadhocprocess2.Returnsubprocessdefinitionid + ":" + lotadhocprocess2.Returnprocesssegmentid);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", $"Lotid={lot3.Lotid} Adhocprocesssysid={lot3.Adhocprocesssysid} Processsegmentid={lot3.Processsegmentid} Location={lot3.Location}");
			}
			lot3.Adhocprocesssysid = lotadhocprocess2.Setlotadhocprocesssysid;
			lot3.Prevprocessdefinitionid = lot3.Processdefinitionid;
			lot3.Prevsubprocessdefinitionid = lot3.Subprocessdefinitionid;
			lot3.Prevprocesssegmentid = lot3.Processsegmentid;
			lot3.Prevprocessnodeid = lot3.Processnodeid;
			lot3.Processdefinitionid = lotadhocprocess2.Returnprocessdefinitionid;
			lot3.Subprocessdefinitionid = lotadhocprocess2.Returnsubprocessdefinitionid;
			lot3.Processsegmentid = lotadhocprocess2.Returnprocesssegmentid;
			lot3.Processnodeid = processnode.Processnodeid;
			lot3.Processsegmentruleid = processsegmentruleclsrel.Processsegmentruleid;
			lot3.Rulesequence = processsegmentruleclsrel.Rulesequence;
			lot3.Processingstate = "WaitForRule";
			lot3.Receivedtime = EntityHelper.FirstNotNull<DateTime>(lot2.Modifytime, systemTime);
			if (lot3.Location != lotadhocprocess2.Returnlocation)
			{
				lot3.Prevlocation = lot3.Location;
				lot3.Location = lotadhocprocess2.Returnlocation;
			}
			lot2.CopyCommonFieldUpdatePrev(lot3, systemTime, tid, text);
			lot2.CopyExtensionCollection(lot3);
			list.Add(lot3);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", $"Lotid={lot3.Lotid} Adhocprocesssysid={lot3.Adhocprocesssysid} Processsegmentid={lot3.Processsegmentid} Location={lot3.Location}");
			}
			if (!flag)
			{
				lot2.CopyCommonFieldUpdatePrev(lotadhocprocess2, systemTime, tid, text);
				list3.Add(lotadhocprocess2);
			}
			foreach (Producedmaterial item in PRODUCEDMATERIAL.FindProducedMaterialList(list4.ToArray(), lotid))
			{
				if (!PRODUCEDMATERIAL.ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, item))
				{
					throw new EntityIsHoldException(typeof(Producedmaterial), item.Producedmaterialid);
				}
				if (MesLogger.IsDebugEnabled("API"))
				{
					MesLogger.DebugTidApi(tid, "Before Execute", $"Producedmaterialid={item.Producedmaterialid} Processsegmentid={item.Processsegmentid} Location={item.Location}");
				}
				PRODUCEDMATERIAL.InheritLotProcessInfo(lot3, item);
				if (item.Location != lot3.Location)
				{
					item.Prevlocation = item.Location;
					item.Location = lot3.Location;
				}
				lot2.CopyCommonFieldUpdatePrev(item, systemTime, tid, text);
				list2.Add(item);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={item.Producedmaterialid} Processsegmentid={item.Processsegmentid} Location={item.Location}");
				}
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list3.ToArray(), saveHist);
		foreach (Lot item2 in list)
		{
			if (LOTFUTUREACTION.GetLotFutureActionCountCurrentSegmentRule(dbContext, item2) > 0)
			{
				RunLotFutureAction(dbContext, item2, "Y", customActivityFutureAction, saveHistFutureAction, modifyTimeFutureAction);
			}
		}
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int SegmentInjectStartLot(IDbContext dbContext, Lot[] lotList, Lotadhocprocess[] adhocProcessList, SegmentInjectStartLotOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		object[] objectList = lotList;
		ParamChecker.ArgumentNotNullAndHasElement("lotList", objectList);
		objectList = adhocProcessList;
		ParamChecker.ArgumentNotNullAndHasElement("adhocProcessList", objectList);
		objectList = lotList;
		object[] arr = objectList;
		objectList = adhocProcessList;
		ParamChecker.ArraySameLength(arr, objectList);
		string text = "SegmentInjectStartLot";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		bool saveHistFutureAction = optionSet?.SaveHistRunFutureAction ?? false;
		string customActivityFutureAction = optionSet?.CustomActivityRunFutureAction;
		DateTime modifyTimeFutureAction = ((optionSet != null && optionSet.ModifytimeRunFutureAction != DateTime.MinValue) ? optionSet.ModifytimeRunFutureAction : systemTime);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		List<Lotadhocprocess> list3 = new List<Lotadhocprocess>();
		string siteid = lotList[0].Siteid;
		List<Producedmaterial> list4 = new List<Producedmaterial>();
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		Lot[] array2 = array;
		foreach (Lot lot in array2)
		{
			Producedmaterial[] array3 = PRODUCEDMATERIAL.SelectProducedMaterialListAliveByLot4Update(dbContext, lot.Lotid, siteid).ToArray();
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lot.Lotid} ProducedMaterial Count={array3.Length}");
			}
			list4.AddRange(array3);
		}
		for (int j = 0; j < lotList.Length; j++)
		{
			Lot lot2 = lotList[j];
			Lotadhocprocess lotadhocprocess = adhocProcessList[j];
			ParamChecker.ArgumentNotNull("Lotid", lot2.Lotid);
			ParamChecker.ArgumentNotNull("Siteid", lot2.Siteid);
			ParamChecker.ArgumentNotNull("Startprocessdefinitionid", lotadhocprocess.Startprocessdefinitionid);
			ParamChecker.ArgumentNotNull("Startsubprocessdefinitionid", lotadhocprocess.Startsubprocessdefinitionid);
			ParamChecker.ArgumentNotNull("Startprocesssegmentid", lotadhocprocess.Startprocesssegmentid);
			ParamChecker.ArgumentNotNull("Finishprocessdefinitionid", lotadhocprocess.Finishprocessdefinitionid);
			ParamChecker.ArgumentNotNull("Finishsubprocessdefinitionid", lotadhocprocess.Finishsubprocessdefinitionid);
			ParamChecker.ArgumentNotNull("Finishprocesssegmentid", lotadhocprocess.Finishprocesssegmentid);
			ParamChecker.ArgumentNotNull("Returnprocessdefinitionid", lotadhocprocess.Returnprocessdefinitionid);
			ParamChecker.ArgumentNotNull("Returnsubprocessdefinitionid", lotadhocprocess.Returnsubprocessdefinitionid);
			ParamChecker.ArgumentNotNull("Returnprocesssegmentid", lotadhocprocess.Returnprocesssegmentid);
			siteid = lot2.Siteid;
			string lotid = lot2.Lotid;
			Lot lot3;
			if ((lot3 = FindLot(array, lotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lot), lotid);
			}
			if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot3))
			{
				throw new EntityIsHoldException(typeof(Lot), lotid);
			}
			ParamChecker.EntityInvalidState(typeof(Lot), lotid, lot3.Processingstate, "ProcessingRule");
			string nextTID = ContextManager.GetNextTID();
			int adhocdepth = LOTADHOCPROCESS.SelectMaxAdhocDepth(dbContext, lotid, siteid, "SegmentInject") + 1;
			Processsegmentruleclsrel processsegmentruleclsrel = null;
			if (PROCESSDEFINITION.SelectProcessDefinition(dbContext, lotadhocprocess.Startprocessdefinitionid, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(Processdefinition), lotadhocprocess.Startprocessdefinitionid);
			}
			Processsegment processsegment;
			if ((processsegment = PROCESSSEGMENT.SelectProcessSegment(dbContext, lotadhocprocess.Startprocesssegmentid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Processsegment), lotadhocprocess.Startprocesssegmentid);
			}
			if ((processsegmentruleclsrel = PROCESSSEGMENTRULECLSREL.SelectFirstProcessSegmentRuleByRuleCls(dbContext, processsegment.Processsegmentruleclsid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentruleclsrel), processsegment.Processsegmentruleclsid);
			}
			if (PROCESSDEFINITION.SelectProcessDefinition(dbContext, lotadhocprocess.Finishprocessdefinitionid, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(Processdefinition), lotadhocprocess.Finishprocessdefinitionid);
			}
			if ((processsegment = PROCESSSEGMENT.SelectProcessSegment(dbContext, lotadhocprocess.Finishprocesssegmentid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Processsegment), lotadhocprocess.Finishprocesssegmentid);
			}
			if (PROCESSDEFINITION.SelectProcessDefinition(dbContext, lotadhocprocess.Returnprocessdefinitionid, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(Processdefinition), lotadhocprocess.Returnprocessdefinitionid);
			}
			if ((processsegment = PROCESSSEGMENT.SelectProcessSegment(dbContext, lotadhocprocess.Returnprocesssegmentid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Processsegment), lotadhocprocess.Returnprocesssegmentid);
			}
			if (!string.IsNullOrEmpty(lotadhocprocess.Returnlocation) && FACILITY.SelectFacility(dbContext, lotadhocprocess.Returnlocation, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(Facility), lotadhocprocess.Returnlocation);
			}
			Lotadhocprocess lotadhocprocess2 = new Lotadhocprocess();
			lotadhocprocess2.Lotadhocprocesssysid = nextTID;
			lotadhocprocess2.Lotid = lotid;
			lotadhocprocess2.Siteid = siteid;
			lotadhocprocess2.Setlotadhocprocesssysid = lot3.Adhocprocesssysid;
			lotadhocprocess2.Setprocessdefinitionid = lot3.Processdefinitionid;
			lotadhocprocess2.Setsubprocessdefinitionid = lot3.Subprocessdefinitionid;
			lotadhocprocess2.Setprocesssegmentid = lot3.Processsegmentid;
			lotadhocprocess2.Startprocessdefinitionid = lotadhocprocess.Startprocessdefinitionid;
			lotadhocprocess2.Startsubprocessdefinitionid = lotadhocprocess.Startsubprocessdefinitionid;
			lotadhocprocess2.Startprocesssegmentid = lotadhocprocess.Startprocesssegmentid;
			lotadhocprocess2.Finishprocessdefinitionid = lotadhocprocess.Finishprocessdefinitionid;
			lotadhocprocess2.Finishsubprocessdefinitionid = lotadhocprocess.Finishsubprocessdefinitionid;
			lotadhocprocess2.Finishprocesssegmentid = lotadhocprocess.Finishprocesssegmentid;
			lotadhocprocess2.Returnprocessdefinitionid = lotadhocprocess.Returnprocessdefinitionid;
			lotadhocprocess2.Returnsubprocessdefinitionid = lotadhocprocess.Returnsubprocessdefinitionid;
			lotadhocprocess2.Returnprocesssegmentid = lotadhocprocess.Returnprocesssegmentid;
			lotadhocprocess2.Returnlocation = lotadhocprocess.Returnlocation;
			lotadhocprocess2.Adhocdepth = adhocdepth;
			lotadhocprocess2.Adhocprocesstype = "SegmentInject";
			lotadhocprocess2.Isusable = "Usable";
			lotadhocprocess2.Prevactivity = null;
			lotadhocprocess2.Activity = text;
			lotadhocprocess2.Prevcustomactivity = null;
			lotadhocprocess.CopyCommonField(lotadhocprocess2, systemTime, tid, isCreate: true);
			lotadhocprocess2.Customactivity = EntityHelper.FirstNotNull<string>(lotadhocprocess.Customactivity, lotadhocprocess2.Activity);
			lotadhocprocess.CopyExtensionCollection(lotadhocprocess2);
			list3.Add(lotadhocprocess2);
			Processnode processnode = PROCESSNODE.SelectProcessSegmentNode(dbContext, lotadhocprocess.Startprocessdefinitionid, lotadhocprocess.Startsubprocessdefinitionid, lotadhocprocess.Startprocesssegmentid, siteid);
			if (processnode == null)
			{
				throw new EntityNotFoundException(typeof(Processnode), lotadhocprocess.Startprocessdefinitionid + ":" + lotadhocprocess.Startsubprocessdefinitionid + ":" + lotadhocprocess.Startprocesssegmentid);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", $"Lotid={lot3.Lotid} Adhocprocesssysid={lot3.Adhocprocesssysid} Processsegmentid={lot3.Processsegmentid} Location={lot3.Location}");
			}
			lot3.Adhocprocesssysid = nextTID;
			lot3.Prevprocessdefinitionid = lot3.Processdefinitionid;
			lot3.Prevsubprocessdefinitionid = lot3.Subprocessdefinitionid;
			lot3.Prevprocesssegmentid = lot3.Processsegmentid;
			lot3.Prevprocessnodeid = lot3.Processnodeid;
			lot3.Processdefinitionid = lotadhocprocess.Startprocessdefinitionid;
			lot3.Subprocessdefinitionid = lotadhocprocess.Startsubprocessdefinitionid;
			lot3.Processsegmentid = lotadhocprocess.Startprocesssegmentid;
			lot3.Processnodeid = processnode.Processnodeid;
			lot3.Processsegmentruleid = processsegmentruleclsrel.Processsegmentruleid;
			lot3.Rulesequence = processsegmentruleclsrel.Rulesequence;
			lot3.Processingstate = "WaitForRule";
			lot3.Receivedtime = EntityHelper.FirstNotNull<DateTime>(lot2.Modifytime, systemTime);
			if (lot3.Location != lot2.Location)
			{
				lot3.Prevlocation = lot3.Location;
				lot3.Location = lot2.Location;
			}
			lot2.CopyCommonFieldUpdatePrev(lot3, systemTime, tid, text);
			lot2.CopyExtensionCollection(lot3);
			list.Add(lot3);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", $"Lotid={lot3.Lotid} Adhocprocesssysid={lot3.Adhocprocesssysid} Processsegmentid={lot3.Processsegmentid} Location={lot3.Location}");
			}
			foreach (Producedmaterial item in PRODUCEDMATERIAL.FindProducedMaterialList(list4.ToArray(), lotid))
			{
				if (!PRODUCEDMATERIAL.ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, item))
				{
					throw new EntityIsHoldException(typeof(Producedmaterial), item.Producedmaterialid);
				}
				if (MesLogger.IsDebugEnabled("API"))
				{
					MesLogger.DebugTidApi(tid, "Before Execute", $"Producedmaterialid={item.Producedmaterialid} Processsegmentid={item.Processsegmentid} Location={item.Location}");
				}
				PRODUCEDMATERIAL.InheritLotProcessInfo(lot3, item);
				if (item.Location != lot2.Location)
				{
					item.Prevlocation = item.Location;
					item.Location = lot2.Location;
				}
				lot2.CopyCommonFieldUpdatePrev(item, systemTime, tid, text);
				list2.Add(item);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={item.Producedmaterialid} Processsegmentid={item.Processsegmentid} Location={item.Location}");
				}
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list3.ToArray(), saveHist);
		foreach (Lot item2 in list)
		{
			if (LOTFUTUREACTION.GetLotFutureActionCountCurrentSegmentRule(dbContext, item2) > 0)
			{
				RunLotFutureAction(dbContext, item2, "Y", customActivityFutureAction, saveHistFutureAction, modifyTimeFutureAction);
			}
		}
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int ShipLot(IDbContext dbContext, Lot[] lotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotList", lotList);
		string text = "ShipLot";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		string siteid = lotList[0].Siteid;
		List<Producedmaterial> list3 = new List<Producedmaterial>();
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		Lot[] array2 = array;
		foreach (Lot lot in array2)
		{
			Producedmaterial[] array3 = PRODUCEDMATERIAL.SelectProducedMaterialListAliveByLot4Update(dbContext, lot.Lotid, siteid).ToArray();
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lot.Lotid} ProducedMaterial Count={array3.Length}");
			}
			list3.AddRange(array3);
		}
		array2 = lotList;
		foreach (Lot lot2 in array2)
		{
			ParamChecker.ArgumentNotNull("Lotid", lot2.Lotid);
			ParamChecker.ArgumentNotNull("Siteid", lot2.Siteid);
			string lotid = lot2.Lotid;
			Lot lot3 = null;
			DateTime? lotshippedtime = EntityHelper.FirstNotNull<DateTime?>(lot2.Lotfinishedtime, lot2.Modifytime, systemTime);
			if ((lot3 = FindLot(array, lotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lot), lotid);
			}
			if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot3))
			{
				throw new EntityIsHoldException(typeof(Lot), lotid);
			}
			ParamChecker.EntityInvalidState(typeof(Lot), "State", lot3.State, "Shipped");
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", lot3);
			}
			lot3.Lotshippedtime = lotshippedtime;
			lot3.Prevstate = lot3.State;
			lot3.State = "Shipped";
			lot2.CopyCommonFieldUpdatePrev(lot3, systemTime, tid, text);
			lot2.CopyExtensionCollection(lot3);
			list.Add(lot3);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", lot3);
			}
			foreach (Producedmaterial item in PRODUCEDMATERIAL.FindProducedMaterialList(list3.ToArray(), lotid))
			{
				if (!PRODUCEDMATERIAL.ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, item))
				{
					throw new EntityIsHoldException(typeof(Producedmaterial), item.Producedmaterialid);
				}
				ParamChecker.EntityInvalidState(typeof(Producedmaterial), "State", item.State, "Shipped");
				if (MesLogger.IsDebugEnabled("API"))
				{
					MesLogger.DebugTidApi(tid, "Before Execute", item);
				}
				item.Lotshippedtime = lotshippedtime;
				item.Prevstate = item.State;
				item.State = "Shipped";
				lot2.CopyCommonFieldUpdatePrev(item, systemTime, tid, text);
				list2.Add(item);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Execute", item);
				}
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int SplitLot(IDbContext dbContext, Lot parentLot, Lot[] childLotList, SplitLotOptionSet splitLotOptionSet, bool saveHistParent, bool saveHistChild)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("parentLot", parentLot);
		ParamChecker.ArgumentNotNullAndHasElement("childLot", childLotList);
		string text = "SplitLot";
		string tid = dbContext.Tid;
		int apiVersion = 1;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		ParamChecker.ArgumentNotNull("parentLot.Lotid", parentLot.Lotid);
		ParamChecker.ArgumentNotNull("parentLot.Siteid", parentLot.Siteid);
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Lot> list2 = new List<Lot>();
		new List<Producedmaterial>();
		string lotid = parentLot.Lotid;
		string siteid = parentLot.Siteid;
		bool flag = splitLotOptionSet?.TerminateParentQtyZero ?? false;
		Lot lot;
		if ((lot = SelectLot4Update(dbContext, lotid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Lot), lotid);
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", lot);
		}
		if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot))
		{
			throw new EntityIsHoldException(typeof(Lot), lotid);
		}
		Lot[] array = childLotList;
		foreach (Lot lot2 in array)
		{
			ParamChecker.ArgumentNotNull("Lotid", lot2.Lotid);
			string lotid2 = lot2.Lotid;
			decimal valueOrDefault = lot2.Qty.GetValueOrDefault();
			decimal valueOrDefault2 = lot2.Submaterialqty.GetValueOrDefault();
			Lot lot3 = new Lot();
			lot.CopyColumsTo(lot3);
			lot3.Lotid = lotid2;
			lot3.Siteid = siteid;
			lot3.Lotname = lot2.Lotname;
			lot3.Rootparentlotid = EntityHelper.FirstNotNull<string>(lot3.Rootparentlotid, lotid);
			lot3.Parentlotid = lotid;
			lot3.Childlotid = null;
			lot3.Originalqty = valueOrDefault;
			lot3.Prevqty = default(decimal);
			lot3.Qty = valueOrDefault;
			lot3.Prevsubmaterialqty = default(decimal);
			lot3.Submaterialqty = valueOrDefault2;
			lot3.Activity = text;
			lot3.Isusable = "Usable";
			lot2.CopyCommonField(lot3, systemTime, tid, isCreate: true);
			lot3.Customactivity = EntityHelper.FirstNotNull<string>(lot2.Customactivity, lot3.Activity);
			lot2.CopyExtensionCollection(lot3);
			list2.Add(lot3);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", lot3);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list2.ToArray(), saveHistChild);
		parentLot.CopyCommonFieldUpdatePrev(lot, systemTime, tid, text);
		parentLot.CopyExtensionCollection(lot);
		list.Add(lot);
		array = childLotList;
		foreach (Lot lot4 in array)
		{
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", $"Lotid={lot.Lotid} State={lot.State} Childlotid={lot.Childlotid} Qty={lot.Qty} Submaterialqty={lot.Submaterialqty}");
			}
			decimal valueOrDefault3 = lot4.Qty.GetValueOrDefault();
			decimal valueOrDefault4 = lot4.Submaterialqty.GetValueOrDefault();
			lot.Childlotid = lot4.Lotid;
			lot.Prevqty = lot.Qty;
			lot.Qty = lot.Qty.Add(-valueOrDefault3);
			lot.Prevsubmaterialqty = lot.Submaterialqty;
			lot.Submaterialqty = lot.Submaterialqty.Add(-valueOrDefault4);
			decimal? qty = lot.Qty;
			if ((qty.GetValueOrDefault() < default(decimal)) & qty.HasValue)
			{
				throw new QuantityInvalidException(lotid, lot.Qty);
			}
			qty = lot.Qty;
			if (((qty.GetValueOrDefault() == default(decimal)) & qty.HasValue) && flag)
			{
				lot.Prevstate = lot.State;
				lot.State = "Terminated";
			}
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", $"Lotid={lot.Lotid} State={lot.State} Childlotid={lot.Childlotid} Qty={lot.Qty} Submaterialqty={lot.Submaterialqty}");
			}
			num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHistParent);
		}
		if (lot.State == "Terminated")
		{
			List<Carrier> list3 = new List<Carrier>();
			List<Lotcarrierrel> list4 = new List<Lotcarrierrel>();
			Lotcarrierrel[] array2 = LOTCARRIERREL.GetLotCarrierRelList(dbContext, lotid, siteid).ToArray();
			string[] distinctCarrierList = LOTCARRIERREL.GetDistinctCarrierList(array2);
			foreach (string carrierid in distinctCarrierList)
			{
				Carrier carrier = CARRIER.SelectCarrier4Update(dbContext, carrierid, siteid);
				parentLot.CopyCommonFieldUpdatePrev(carrier, systemTime, tid, text);
				list3.Add(carrier);
			}
			Lotcarrierrel[] array3 = array2;
			foreach (Lotcarrierrel lotcarrierrel in array3)
			{
				parentLot.CopyCommonFieldUpdatePrev(lotcarrierrel, systemTime, tid, text);
				list4.Add(lotcarrierrel);
			}
			num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list3.ToArray(), saveHistParent);
			num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list4.ToArray(), saveHistParent);
		}
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int SplitLot(IDbContext dbContext, Lot parentLot, Lot childLot, Producedmaterial[] childProducedMaterialList, SplitLotOptionSet splitLotOptionSet, bool saveHistParent, bool saveHistChild)
	{
		string text = "SplitLot";
		string tid = dbContext.Tid;
		int apiVersion = 2;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("parentLot", parentLot);
		ParamChecker.ArgumentNotNull("parentLot.Lotid", parentLot.Lotid);
		ParamChecker.ArgumentNotNull("parentLot.Siteid", parentLot.Siteid);
		ParamChecker.ArgumentNotNull("childLot", childLot);
		ParamChecker.ArgumentNotNull("childLot.Lotid", childLot.Lotid);
		ParamChecker.ArgumentNotNullAndHasElement("childProducedMaterialList", childProducedMaterialList);
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Lot> list2 = new List<Lot>();
		List<Producedmaterial> list3 = new List<Producedmaterial>();
		string lotid = parentLot.Lotid;
		string siteid = parentLot.Siteid;
		bool flag = splitLotOptionSet?.TerminateParentQtyZero ?? false;
		Lot lot;
		if ((lot = SelectLot4Update(dbContext, lotid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Lot), lotid);
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", lot);
		}
		Producedmaterial[] array = PRODUCEDMATERIAL.SelectProducedMaterialList4Update(dbContext, childProducedMaterialList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lotid} ProducedMaterial Count={array.Length}");
		}
		if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot))
		{
			throw new EntityIsHoldException(typeof(Lot), lotid);
		}
		string[] countableProducedMaterialGradeIdList = getCountableProducedMaterialGradeIdList(dbContext, parentLot.Siteid);
		string[] countableSubproducedMaterialGradeIdList = getCountableSubproducedMaterialGradeIdList(dbContext, parentLot.Siteid);
		decimal lotQty = GetLotQty(dbContext, countableProducedMaterialGradeIdList, array.ToArray());
		decimal subProducedMaterialQty = GetSubProducedMaterialQty(dbContext, countableSubproducedMaterialGradeIdList, array.ToArray());
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "CalcQty", $"Lotid={lotid} Change Qty={lotQty} Submaterialqty={subProducedMaterialQty}");
		}
		string lotid2 = childLot.Lotid;
		Lot lot2 = new Lot();
		lot.CopyColumsTo(lot2);
		lot2.Lotid = lotid2;
		lot2.Siteid = siteid;
		lot2.Lotname = childLot.Lotname;
		lot2.Rootparentlotid = EntityHelper.FirstNotNull<string>(lot2.Rootparentlotid, lotid);
		lot2.Parentlotid = lotid;
		lot2.Childlotid = null;
		lot2.Originalqty = lotQty;
		lot2.Prevqty = default(decimal);
		lot2.Qty = lotQty;
		lot2.Prevsubmaterialqty = default(decimal);
		lot2.Submaterialqty = subProducedMaterialQty;
		lot2.Activity = text;
		lot2.Isusable = "Usable";
		childLot.CopyCommonField(lot2, systemTime, tid, isCreate: true);
		lot2.Customactivity = EntityHelper.FirstNotNull<string>(childLot.Customactivity, lot2.Activity);
		childLot.CopyExtensionCollection(lot2);
		list2.Add(lot2);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", lot2);
		}
		foreach (Producedmaterial producedmaterial in childProducedMaterialList)
		{
			string producedmaterialid = producedmaterial.Producedmaterialid;
			ParamChecker.ArgumentNotNull("childProducedMaterialId", producedmaterialid);
			Producedmaterial producedmaterial2 = PRODUCEDMATERIAL.FindProducedMaterial(array, producedmaterialid);
			if (producedmaterial2 == null)
			{
				throw new EntityNotFoundException(typeof(Producedmaterial), producedmaterialid);
			}
			if (!PRODUCEDMATERIAL.ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, producedmaterial))
			{
				throw new EntityIsHoldException(typeof(Producedmaterial), producedmaterialid);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", $"Producedmaterialid={producedmaterial2.Producedmaterialid} Prevlotid={producedmaterial2.Prevlotid} Lotid={producedmaterial2.Lotid}");
			}
			producedmaterial2.Prevlotid = producedmaterial2.Lotid;
			producedmaterial2.Lotid = lotid2;
			producedmaterial.CopyCommonFieldUpdatePrev(producedmaterial2, systemTime, tid, text);
			producedmaterial.CopyExtensionCollection(producedmaterial2);
			list3.Add(producedmaterial2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={producedmaterial2.Producedmaterialid} Prevlotid={producedmaterial2.Prevlotid} Lotid={producedmaterial2.Lotid}");
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list2.ToArray(), saveHistChild);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list3.ToArray(), saveHistChild);
		lot.Childlotid = childLot.Lotid;
		lot.Prevqty = lot.Qty;
		lot.Qty = lot.Qty.Add(-lotQty);
		lot.Prevsubmaterialqty = lot.Submaterialqty;
		lot.Submaterialqty = lot.Submaterialqty.Add(-subProducedMaterialQty);
		decimal? qty = lot.Qty;
		if ((qty.GetValueOrDefault() < default(decimal)) & qty.HasValue)
		{
			throw new QuantityInvalidException(lotid, lot.Qty);
		}
		qty = lot.Qty;
		if (((qty.GetValueOrDefault() == default(decimal)) & qty.HasValue) && flag)
		{
			lot.Prevstate = lot.State;
			lot.State = "Terminated";
		}
		parentLot.CopyCommonFieldUpdatePrev(lot, systemTime, tid, text);
		parentLot.CopyExtensionCollection(lot);
		list.Add(lot);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", lot);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHistParent);
		if (lot.State == "Terminated")
		{
			List<Carrier> list4 = new List<Carrier>();
			List<Lotcarrierrel> list5 = new List<Lotcarrierrel>();
			Lotcarrierrel[] array2 = LOTCARRIERREL.GetLotCarrierRelList(dbContext, lotid, siteid).ToArray();
			string[] distinctCarrierList = LOTCARRIERREL.GetDistinctCarrierList(array2);
			foreach (string carrierid in distinctCarrierList)
			{
				Carrier carrier = CARRIER.SelectCarrier4Update(dbContext, carrierid, siteid);
				parentLot.CopyCommonFieldUpdatePrev(carrier, systemTime, tid, text);
				list4.Add(carrier);
			}
			Lotcarrierrel[] array3 = array2;
			foreach (Lotcarrierrel lotcarrierrel in array3)
			{
				parentLot.CopyCommonFieldUpdatePrev(lotcarrierrel, systemTime, tid, text);
				list5.Add(lotcarrierrel);
			}
			num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list4.ToArray(), saveHistParent);
			num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list5.ToArray(), saveHistParent);
		}
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int SplitLot(IDbContext dbContext, Lot parentLot, Lot childLot, Producedmaterial[] childProducedMaterialList, Lotcarrierrel[] childLotcarrierrelList, Carrier childCarrier, SplitLotOptionSet splitLotOptionSet, bool saveHistParent, bool saveHistChild, bool saveHistChildLotCarrierrel, bool saveHistChildCarrier)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("parentLot", parentLot);
		ParamChecker.ArgumentNotNull("childLot", childLot);
		object[] objectList = childProducedMaterialList;
		ParamChecker.ArgumentNotNullAndHasElement("childProducedMaterialList", objectList);
		objectList = childLotcarrierrelList;
		ParamChecker.ArgumentNotNullAndHasElement("childLotcarrierrelList", objectList);
		ParamChecker.ArgumentNotNull("childCarrier", childCarrier);
		string text = "SplitLot";
		string tid = dbContext.Tid;
		int apiVersion = 3;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		ParamChecker.ArgumentNotNull("parentLot.Lotid", parentLot.Lotid);
		ParamChecker.ArgumentNotNull("parentLot.Siteid", parentLot.Siteid);
		ParamChecker.ArgumentNotNull("childLot.Lotid", childLot.Lotid);
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Lot> list2 = new List<Lot>();
		List<Producedmaterial> list3 = new List<Producedmaterial>();
		List<Carrier> list4 = new List<Carrier>();
		List<Lotcarrierrel> list5 = new List<Lotcarrierrel>();
		string lotid = parentLot.Lotid;
		string siteid = parentLot.Siteid;
		bool flag = splitLotOptionSet?.TerminateParentQtyZero ?? false;
		Lot lot;
		if ((lot = SelectLot4Update(dbContext, lotid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Lot), lotid);
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", lot);
		}
		Producedmaterial[] array = PRODUCEDMATERIAL.SelectProducedMaterialList4Update(dbContext, childProducedMaterialList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lotid} ProducedMaterial Count={array.Length}");
		}
		if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot))
		{
			throw new EntityIsHoldException(typeof(Lot), lotid);
		}
		string[] countableProducedMaterialGradeIdList = getCountableProducedMaterialGradeIdList(dbContext, parentLot.Siteid);
		string[] countableSubproducedMaterialGradeIdList = getCountableSubproducedMaterialGradeIdList(dbContext, parentLot.Siteid);
		decimal lotQty = GetLotQty(dbContext, countableProducedMaterialGradeIdList, array.ToArray());
		decimal subProducedMaterialQty = GetSubProducedMaterialQty(dbContext, countableSubproducedMaterialGradeIdList, array.ToArray());
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "CalcQty", $"Lotid={lotid} Change Qty={lotQty} Submaterialqty={subProducedMaterialQty}");
		}
		string lotid2 = childLot.Lotid;
		Lot lot2 = new Lot();
		lot.CopyColumsTo(lot2);
		lot2.Lotid = lotid2;
		lot2.Siteid = siteid;
		lot2.Lotname = childLot.Lotname;
		lot2.Rootparentlotid = EntityHelper.FirstNotNull<string>(lot2.Rootparentlotid, lotid);
		lot2.Parentlotid = lotid;
		lot2.Childlotid = null;
		lot2.Originalqty = lotQty;
		lot2.Prevqty = default(decimal);
		lot2.Qty = lotQty;
		lot2.Prevsubmaterialqty = default(decimal);
		lot2.Submaterialqty = subProducedMaterialQty;
		lot2.Activity = text;
		lot2.Isusable = "Usable";
		childLot.CopyCommonField(lot2, systemTime, tid, isCreate: true);
		lot2.Customactivity = EntityHelper.FirstNotNull<string>(childLot.Customactivity, lot2.Activity);
		childLot.CopyExtensionCollection(lot2);
		list2.Add(lot2);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", lot2);
		}
		foreach (Producedmaterial producedmaterial in childProducedMaterialList)
		{
			string producedmaterialid = producedmaterial.Producedmaterialid;
			ParamChecker.ArgumentNotNull("childProducedMaterialId", producedmaterialid);
			Producedmaterial producedmaterial2 = PRODUCEDMATERIAL.FindProducedMaterial(array, producedmaterialid);
			if (producedmaterial2 == null)
			{
				throw new EntityNotFoundException(typeof(Producedmaterial), producedmaterialid);
			}
			if (!PRODUCEDMATERIAL.ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, producedmaterial))
			{
				throw new EntityIsHoldException(typeof(Producedmaterial), producedmaterialid);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", $"Producedmaterialid={producedmaterial2.Producedmaterialid} Prevlotid={producedmaterial2.Prevlotid} Lotid={producedmaterial2.Lotid} Slotno={producedmaterial2.Slotno}, Carrierid={producedmaterial2.Carrierid}");
			}
			producedmaterial2.Prevlotid = producedmaterial2.Lotid;
			producedmaterial2.Lotid = lotid2;
			producedmaterial2.Prevslotno = producedmaterial2.Slotno;
			producedmaterial2.Slotno = producedmaterial.Slotno;
			producedmaterial2.Prevcarrierid = producedmaterial2.Carrierid;
			producedmaterial2.Carrierid = producedmaterial.Carrierid;
			producedmaterial.CopyCommonFieldUpdatePrev(producedmaterial2, systemTime, tid, text);
			producedmaterial.CopyExtensionCollection(producedmaterial2);
			list3.Add(producedmaterial2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={producedmaterial2.Producedmaterialid} Prevlotid={producedmaterial2.Prevlotid} Lotid={producedmaterial2.Lotid} Slotno={producedmaterial2.Slotno}, Carrierid={producedmaterial2.Carrierid}");
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list2.ToArray(), saveHistChild);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list3.ToArray(), saveHistChild);
		lot.Childlotid = childLot.Lotid;
		lot.Prevqty = lot.Qty;
		lot.Qty = lot.Qty.Add(-lotQty);
		lot.Prevsubmaterialqty = lot.Submaterialqty;
		lot.Submaterialqty = lot.Submaterialqty.Add(-subProducedMaterialQty);
		decimal? qty = lot.Qty;
		if ((qty.GetValueOrDefault() < default(decimal)) & qty.HasValue)
		{
			throw new QuantityInvalidException(lotid, lot.Qty);
		}
		qty = lot.Qty;
		if (((qty.GetValueOrDefault() == default(decimal)) & qty.HasValue) && flag)
		{
			lot.Prevstate = lot.State;
			lot.State = "Terminated";
		}
		parentLot.CopyCommonFieldUpdatePrev(lot, systemTime, tid, text);
		parentLot.CopyExtensionCollection(lot);
		list.Add(lot);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", lot);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHistParent);
		if (lot.State == "Terminated")
		{
			List<Carrier> list6 = new List<Carrier>();
			List<Lotcarrierrel> list7 = new List<Lotcarrierrel>();
			Lotcarrierrel[] array2 = LOTCARRIERREL.GetLotCarrierRelList(dbContext, lotid, siteid).ToArray();
			string[] distinctCarrierList = LOTCARRIERREL.GetDistinctCarrierList(array2);
			foreach (string carrierid in distinctCarrierList)
			{
				Carrier carrier = CARRIER.SelectCarrier4Update(dbContext, carrierid, siteid);
				parentLot.CopyCommonFieldUpdatePrev(carrier, systemTime, tid, text);
				list6.Add(carrier);
			}
			Lotcarrierrel[] array3 = array2;
			foreach (Lotcarrierrel lotcarrierrel in array3)
			{
				parentLot.CopyCommonFieldUpdatePrev(lotcarrierrel, systemTime, tid, text);
				list7.Add(lotcarrierrel);
			}
			num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list6.ToArray(), saveHistParent);
			num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list7.ToArray(), saveHistParent);
		}
		string carrierid2 = childCarrier.Carrierid;
		Carrier carrier2 = CARRIER.SelectCarrier4Update(dbContext, carrierid2, siteid);
		if (carrier2 == null)
		{
			throw new EntityNotFoundException(typeof(Carrier), carrierid2);
		}
		if (childCarrier.Assignqty.HasValue && !(carrier2.Assignqty == childCarrier.Assignqty))
		{
			carrier2.Assignqty = childCarrier.Assignqty;
		}
		if (childCarrier.Loadstate != null && carrier2.Loadstate != childCarrier.Loadstate)
		{
			carrier2.Loadstate = childCarrier.Loadstate;
		}
		childCarrier.CopyCommonFieldUpdatePrev(carrier2, systemTime, tid, text);
		childCarrier.CopyExtensionCollection(carrier2);
		list4.Add(carrier2);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", carrier2);
		}
		foreach (Lotcarrierrel lotcarrierrel2 in childLotcarrierrelList)
		{
			ParamChecker.ArgumentNotNull("Lotid", lotcarrierrel2.Lotid);
			ParamChecker.ArgumentNotNull("Carrierid", lotcarrierrel2.Carrierid);
			ParamChecker.ArgumentNotNull("Slotposition", lotcarrierrel2.Slotposition);
			ParamChecker.ArgumentNotNull("Siteid", lotcarrierrel2.Siteid);
			if (lotid2 != lotcarrierrel2.Lotid)
			{
				throw new ObjectComparedInvalidException("childLotId", lotid2, lotcarrierrel2.Lotid);
			}
			if (carrierid2 != lotcarrierrel2.Carrierid)
			{
				throw new ObjectComparedInvalidException("childCarrierId", carrierid2, lotcarrierrel2.Carrierid);
			}
			Lotcarrierrel lotcarrierrel3 = new Lotcarrierrel();
			lotcarrierrel2.CopyColumsTo(lotcarrierrel3);
			lotcarrierrel3.Slotposition = 1;
			lotcarrierrel3.Assignqty = 1;
			lotcarrierrel3.Prevactivity = null;
			lotcarrierrel3.Activity = text;
			lotcarrierrel3.Isusable = "Usable";
			lotcarrierrel3.Siteid = siteid;
			lotcarrierrel2.CopyCommonField(lotcarrierrel3, systemTime, tid, isCreate: true);
			lotcarrierrel3.Customactivity = EntityHelper.FirstNotNull<string>(lotcarrierrel2.Customactivity, lotcarrierrel3.Activity);
			list5.Add(lotcarrierrel3);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", lotcarrierrel3);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list4.ToArray(), saveHistChildCarrier);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list5.ToArray(), saveHistChildLotCarrierrel);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int StartLot(IDbContext dbContext, Lot[] lotList, StartLotOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotList", lotList);
		string text = "StartLot";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		bool flag = optionSet?.MoveToSpecifiedSegment ?? false;
		bool flag2 = optionSet?.ProcessdefinitionWithoutState ?? false;
		string siteid = lotList[0].Siteid;
		List<Producedmaterial> list3 = new List<Producedmaterial>();
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		Lot[] array2 = array;
		foreach (Lot lot in array2)
		{
			Producedmaterial[] array3 = PRODUCEDMATERIAL.SelectProducedMaterialListAliveByLot4Update(dbContext, lot.Lotid, siteid).ToArray();
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lot.Lotid} ProducedMaterial Count={array3.Length}");
			}
			list3.AddRange(array3);
		}
		array2 = lotList;
		foreach (Lot lot2 in array2)
		{
			ParamChecker.ArgumentNotNull("Lotid", lot2.Lotid);
			ParamChecker.ArgumentNotNull("Siteid", lot2.Siteid);
			if (flag)
			{
				ParamChecker.ArgumentNotNull("Subprocessdefinitionid", lot2.Subprocessdefinitionid);
				ParamChecker.ArgumentNotNull("Processsegmentid", lot2.Processsegmentid);
				ParamChecker.ArgumentNotNull("Processsegmentruleid", lot2.Processsegmentruleid);
			}
			if (!flag2)
			{
				ParamChecker.ArgumentNotNull("Processdefinitionid", lot2.Processdefinitionid);
			}
			string lotid = lot2.Lotid;
			Lot lot3 = null;
			Processnode processnode = null;
			Processsegment processsegment = null;
			Processsegmentruleclsrel processsegmentruleclsrel = null;
			bool flag3 = false;
			Processdefinition processdefinition = null;
			if ((lot3 = FindLot(array, lotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lot), lotid);
			}
			if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot3))
			{
				throw new EntityIsHoldException(typeof(Lot), lotid);
			}
			ParamChecker.EntityInvalidState(typeof(Lot), "State", lot3.State, "Active");
			if (!flag2)
			{
				processdefinition = PROCESSDEFINITION.SelectProcessDefinition(dbContext, lot3.Processdefinitionid, siteid);
				if ("Created".Equals(processdefinition.State))
				{
					throw new EntityStateInvalidException(typeof(ProcessdefinitionState), "processdefinition", processdefinition.State);
				}
			}
			flag3 = string.IsNullOrEmpty(lot3.Processsegmentid);
			if (flag)
			{
				if ((processnode = PROCESSNODE.SelectProcessSegmentNode(dbContext, lot2.Processdefinitionid, lot2.Subprocessdefinitionid, lot2.Processsegmentid, siteid)) == null)
				{
					throw new ProcessNodeSegmentNotFoundException(lot2.Processdefinitionid, lot2.Subprocessdefinitionid, lot2.Processsegmentid);
				}
				if ((processsegment = PROCESSSEGMENT.SelectProcessSegment(dbContext, processnode.Processsegmentid, siteid)) == null)
				{
					throw new EntityNotFoundException(typeof(Processsegment), processnode.Processsegmentid);
				}
				processsegmentruleclsrel = PROCESSSEGMENTRULECLSREL.GetProcessSegmentRuleClsRel(dbContext, processsegment.Processsegmentruleclsid, lot2.Processsegmentruleid, siteid);
				if (processsegmentruleclsrel == null)
				{
					throw new EntityNotFoundException(typeof(Processsegmentruleclsrel), processnode.Processsegmentid);
				}
			}
			else if (flag3)
			{
				if ((processnode = PROCESSNODE.SelectProcessStartSegmentNode(dbContext, lot3.Processdefinitionid, siteid)) == null)
				{
					throw new StartSegmentNodeNotFoundException(lot3.Processdefinitionid);
				}
				if ((processsegment = PROCESSSEGMENT.SelectProcessSegment(dbContext, processnode.Processsegmentid, siteid)) == null)
				{
					throw new EntityNotFoundException(typeof(Processsegment), processnode.Processsegmentid);
				}
				processsegmentruleclsrel = PROCESSSEGMENTRULECLSREL.SelectFirstProcessSegmentRuleByRuleCls(dbContext, processsegment.Processsegmentruleclsid, siteid);
				if (processsegmentruleclsrel == null)
				{
					throw new EntityNotFoundException(typeof(Processsegmentruleclsrel), processnode.Processsegmentid);
				}
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", LogInfoProcessChangeLot(lot3));
			}
			lot3.Prevstate = lot3.State;
			lot3.State = "Active";
			lot3.Duedate = lot2.Duedate;
			if (flag)
			{
				if (processsegmentruleclsrel.Isstart == "Y")
				{
					lot3.Processingstate = "WaitForRule";
				}
				else
				{
					lot3.Processingstate = "ProcessingRule";
				}
				lot3.Prevsubprocessdefinitionid = null;
				lot3.Subprocessdefinitionid = processnode.Processdefinitionid;
				lot3.Prevprocesssegmentid = null;
				lot3.Processsegmentid = processsegment.Processsegmentid;
				lot3.Prevprocessnodeid = null;
				lot3.Processnodeid = processnode.Processnodeid;
				lot3.Processsegmentruleid = processsegmentruleclsrel.Processsegmentruleid;
				lot3.Rulesequence = processsegmentruleclsrel.Rulesequence;
			}
			else if (flag3)
			{
				lot3.Processingstate = "WaitForRule";
				lot3.Prevsubprocessdefinitionid = null;
				lot3.Subprocessdefinitionid = processnode.Processdefinitionid;
				lot3.Prevprocesssegmentid = null;
				lot3.Processsegmentid = processsegment.Processsegmentid;
				lot3.Prevprocessnodeid = null;
				lot3.Processnodeid = processnode.Processnodeid;
				lot3.Processsegmentruleid = processsegmentruleclsrel.Processsegmentruleid;
				lot3.Rulesequence = processsegmentruleclsrel.Rulesequence;
			}
			lot2.CopyCommonFieldUpdatePrev(lot3, systemTime, tid, text);
			lot2.CopyExtensionCollection(lot3);
			list.Add(lot3);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", LogInfoProcessChangeLot(lot3));
			}
			foreach (Producedmaterial item in PRODUCEDMATERIAL.FindProducedMaterialList(list3.ToArray(), lotid))
			{
				_ = item.Producedmaterialid;
				if (!PRODUCEDMATERIAL.ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, item))
				{
					throw new EntityIsHoldException(typeof(Producedmaterial), item.Producedmaterialid);
				}
				ParamChecker.EntityInvalidState(typeof(Producedmaterial), "State", item.State, "Active");
				if (MesLogger.IsDebugEnabled("API"))
				{
					MesLogger.DebugTidApi(tid, "Before Execute", item);
				}
				item.Prevstate = item.State;
				item.State = "Active";
				item.Duedate = lot3.Duedate;
				PRODUCEDMATERIAL.InheritLotProcessInfo(lot3, item);
				lot2.CopyCommonFieldUpdatePrev(item, systemTime, tid, text);
				list2.Add(item);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Execute", item);
				}
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int StartLot(IDbContext dbContext, Lot inputLot, Producedmaterial[] inputProducedMaterialList, StartLotOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("inputLot", inputLot);
		string text = "StartLot";
		int apiVersion = 2;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		ParamChecker.ArgumentNotNull("Lotid", inputLot.Lotid);
		ParamChecker.ArgumentNotNull("Siteid", inputLot.Siteid);
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		bool flag = optionSet?.MoveToSpecifiedSegment ?? false;
		bool flag2 = optionSet?.ProcessdefinitionWithoutState ?? false;
		if (flag)
		{
			ParamChecker.ArgumentNotNull("Subprocessdefinitionid", inputLot.Subprocessdefinitionid);
			ParamChecker.ArgumentNotNull("Processsegmentid", inputLot.Processsegmentid);
			ParamChecker.ArgumentNotNull("Processsegmentruleid", inputLot.Processsegmentruleid);
		}
		if (!flag2)
		{
			ParamChecker.ArgumentNotNull("Processdefinitionid", inputLot.Processdefinitionid);
		}
		string lotid = inputLot.Lotid;
		string siteid = inputLot.Siteid;
		Lot lot = null;
		Processnode processnode = null;
		Processsegment processsegment = null;
		Processsegmentruleclsrel processsegmentruleclsrel = null;
		bool flag3 = false;
		Processdefinition processdefinition = null;
		if ((lot = SelectLot4Update(dbContext, lotid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Lot), lotid);
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", lot);
		}
		Producedmaterial[] array = PRODUCEDMATERIAL.SelectProducedMaterialListAliveByLot4Update(dbContext, lotid, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lot.Lotid} ProducedMaterial Count={array.Length}");
		}
		if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot))
		{
			throw new EntityIsHoldException(typeof(Lot), lotid);
		}
		ValidateParameterProducedMaterial(text, lotid, inputProducedMaterialList, array.ToArray());
		if (!flag2)
		{
			processdefinition = PROCESSDEFINITION.SelectProcessDefinition(dbContext, lot.Processdefinitionid, siteid);
			if ("Created".Equals(processdefinition.State))
			{
				throw new EntityStateInvalidException(typeof(ProcessdefinitionState), "processdefinition", processdefinition.State);
			}
		}
		flag3 = string.IsNullOrEmpty(lot.Processsegmentid);
		if (flag)
		{
			if ((processnode = PROCESSNODE.SelectProcessSegmentNode(dbContext, inputLot.Processdefinitionid, inputLot.Subprocessdefinitionid, inputLot.Processsegmentid, siteid)) == null)
			{
				throw new ProcessNodeSegmentNotFoundException(inputLot.Processdefinitionid, inputLot.Subprocessdefinitionid, inputLot.Processsegmentid);
			}
			if ((processsegment = PROCESSSEGMENT.SelectProcessSegment(dbContext, processnode.Processsegmentid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Processsegment), processnode.Processsegmentid);
			}
			processsegmentruleclsrel = PROCESSSEGMENTRULECLSREL.GetProcessSegmentRuleClsRel(dbContext, processsegment.Processsegmentruleclsid, inputLot.Processsegmentruleid, siteid);
			if (processsegmentruleclsrel == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentruleclsrel), processnode.Processsegmentid);
			}
		}
		else if (flag3)
		{
			if ((processnode = PROCESSNODE.SelectProcessStartSegmentNode(dbContext, lot.Processdefinitionid, siteid)) == null)
			{
				throw new StartSegmentNodeNotFoundException(lot.Processdefinitionid);
			}
			if ((processsegment = PROCESSSEGMENT.SelectProcessSegment(dbContext, processnode.Processsegmentid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Processsegment), processnode.Processsegmentid);
			}
			processsegmentruleclsrel = PROCESSSEGMENTRULECLSREL.SelectFirstProcessSegmentRuleByRuleCls(dbContext, processsegment.Processsegmentruleclsid, siteid);
			if (processsegmentruleclsrel == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentruleclsrel), processnode.Processsegmentid);
			}
		}
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", LogInfoProcessChangeLot(lot));
		}
		lot.Prevstate = lot.State;
		lot.State = "Active";
		lot.Duedate = inputLot.Duedate;
		if (flag)
		{
			if (processsegmentruleclsrel.Isstart == "Y")
			{
				lot.Processingstate = "WaitForRule";
			}
			else
			{
				lot.Processingstate = "ProcessingRule";
			}
			lot.Prevsubprocessdefinitionid = null;
			lot.Subprocessdefinitionid = processnode.Processdefinitionid;
			lot.Prevprocesssegmentid = null;
			lot.Processsegmentid = processsegment.Processsegmentid;
			lot.Prevprocessnodeid = null;
			lot.Processnodeid = processnode.Processnodeid;
			lot.Processsegmentruleid = processsegmentruleclsrel.Processsegmentruleid;
			lot.Rulesequence = processsegmentruleclsrel.Rulesequence;
		}
		else if (flag3)
		{
			lot.Processingstate = "WaitForRule";
			lot.Prevsubprocessdefinitionid = null;
			lot.Subprocessdefinitionid = processnode.Processdefinitionid;
			lot.Prevprocesssegmentid = null;
			lot.Processsegmentid = processsegment.Processsegmentid;
			lot.Prevprocessnodeid = null;
			lot.Processnodeid = processnode.Processnodeid;
			lot.Processsegmentruleid = processsegmentruleclsrel.Processsegmentruleid;
			lot.Rulesequence = processsegmentruleclsrel.Rulesequence;
		}
		inputLot.CopyCommonFieldUpdatePrev(lot, systemTime, tid, text);
		inputLot.CopyExtensionCollection(lot);
		list.Add(lot);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", LogInfoProcessChangeLot(lot));
		}
		foreach (Producedmaterial producedmaterial in inputProducedMaterialList)
		{
			string producedmaterialid = producedmaterial.Producedmaterialid;
			Producedmaterial producedmaterial2 = PRODUCEDMATERIAL.FindProducedMaterial(array, producedmaterialid);
			if (!PRODUCEDMATERIAL.ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, producedmaterial2))
			{
				throw new EntityIsHoldException(typeof(Producedmaterial), producedmaterial2.Producedmaterialid);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", producedmaterial2);
			}
			producedmaterial2.Prevstate = producedmaterial2.State;
			producedmaterial2.State = "Active";
			producedmaterial2.Duedate = EntityHelper.FirstNotNull<DateTime?>(producedmaterial.Duedate, inputLot.Duedate);
			PRODUCEDMATERIAL.InheritLotProcessInfo(lot, producedmaterial2);
			producedmaterial.CopyCommonFieldUpdatePrev(producedmaterial2, systemTime, tid, text);
			producedmaterial.CopyExtensionCollection(producedmaterial2);
			list2.Add(producedmaterial2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", producedmaterial2);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int TerminateLot(IDbContext dbContext, Lot[] lotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotList", lotList);
		string text = "TerminateLot";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		List<Carrier> list3 = new List<Carrier>();
		List<Lotcarrierrel> list4 = new List<Lotcarrierrel>();
		string siteid = lotList[0].Siteid;
		List<Producedmaterial> list5 = new List<Producedmaterial>();
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		Lot[] array2 = array;
		foreach (Lot lot in array2)
		{
			Producedmaterial[] array3 = PRODUCEDMATERIAL.SelectProducedMaterialListAliveByLot4Update(dbContext, lot.Lotid, siteid).ToArray();
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lot.Lotid} ProducedMaterial Count={array3.Length}");
			}
			list5.AddRange(array3);
		}
		array2 = lotList;
		foreach (Lot lot2 in array2)
		{
			ParamChecker.ArgumentNotNull("Lotid", lot2.Lotid);
			ParamChecker.ArgumentNotNull("Siteid", lot2.Siteid);
			string lotid = lot2.Lotid;
			Lot lot3 = null;
			if ((lot3 = FindLot(array, lotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lot), lotid);
			}
			if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot3))
			{
				throw new EntityIsHoldException(typeof(Lot), lotid);
			}
			ParamChecker.EntityInvalidState(typeof(Lot), "State", lot3.State, "Terminated");
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", lot3);
			}
			lot3.Prevstate = lot3.State;
			lot3.State = "Terminated";
			lot3.Prevqty = lot3.Qty;
			lot3.Qty = default(decimal);
			lot3.Prevsubmaterialqty = lot3.Submaterialqty;
			lot3.Submaterialqty = default(decimal);
			lot3.Prevactivity = lot3.Activity;
			lot3.Activity = text;
			lot3.Prevcustomactivity = lot3.Customactivity;
			lot2.CopyExtensionCollection(lot3);
			lot2.CopyCommonFieldUpdatePrev(lot3, systemTime, tid, text);
			list.Add(lot3);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", lot3);
			}
			foreach (Producedmaterial item in PRODUCEDMATERIAL.FindProducedMaterialList(list5.ToArray(), lotid))
			{
				if (!PRODUCEDMATERIAL.ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, item))
				{
					throw new EntityIsHoldException(typeof(Producedmaterial), item.Producedmaterialid);
				}
				ParamChecker.EntityInvalidState(typeof(Producedmaterial), "State", item.State, "Terminated");
				if (MesLogger.IsDebugEnabled("API"))
				{
					MesLogger.DebugTidApi(tid, "Before Execute", $"Producedmaterialid={item.Producedmaterialid} State={item.State} Prevcarrierid={item.Prevcarrierid} Carrierid={item.Carrierid} Prevslotno={item.Prevslotno} Slotno={item.Slotno}");
				}
				item.Prevstate = item.State;
				item.State = "Terminated";
				item.Prevslotno = item.Slotno;
				item.Slotno = 0;
				item.Prevcarrierid = item.Carrierid;
				item.Carrierid = null;
				lot2.CopyCommonFieldUpdatePrev(item, systemTime, tid, text);
				list2.Add(item);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={item.Producedmaterialid} State={item.State} Prevcarrierid={item.Prevcarrierid} Carrierid={item.Carrierid} Prevslotno={item.Prevslotno} Slotno={item.Slotno}");
				}
			}
			Lotcarrierrel[] array4 = LOTCARRIERREL.GetLotCarrierRelList(dbContext, lotid, siteid).ToArray();
			string[] distinctCarrierList = LOTCARRIERREL.GetDistinctCarrierList(array4);
			foreach (string carrierid in distinctCarrierList)
			{
				Carrier carrier = CARRIER.SelectCarrier4Update(dbContext, carrierid, siteid);
				lot2.CopyCommonFieldUpdatePrev(carrier, systemTime, tid, text);
				list3.Add(carrier);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Execute", carrier);
				}
			}
			Lotcarrierrel[] array5 = array4;
			foreach (Lotcarrierrel lotcarrierrel in array5)
			{
				lot2.CopyCommonFieldUpdatePrev(lotcarrierrel, systemTime, tid, text);
				list4.Add(lotcarrierrel);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Execute", lotcarrierrel);
				}
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list3.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list4.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int TrackInLot(IDbContext dbContext, Lot[] lotList, TrackInOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotList", lotList);
		string text = "TrackInLot";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		bool flag = optionSet?.ValidateEquipment ?? false;
		bool flag2 = optionSet?.ValidatePort ?? false;
		bool saveHistFinishLot = optionSet?.SaveHistFinishLot ?? false;
		string customActivityFinishLot = optionSet?.CustomActivityFinishLot;
		DateTime modifyTimeFinishLot = ((optionSet != null && optionSet.ModifytimeFinishLot != DateTime.MinValue) ? optionSet.ModifytimeFinishLot : systemTime);
		bool saveHistReworkFinishLot = optionSet?.SaveHistReworkFinishLot ?? false;
		string customActivityReworkFinishLot = optionSet?.CustomActivityReworkFinishLot;
		DateTime modifyTimeReworkFinishLot = ((optionSet != null && optionSet.ModifytimeReworkFinishLot != DateTime.MinValue) ? optionSet.ModifytimeReworkFinishLot : systemTime);
		bool saveHistFutureAction = optionSet?.SaveHistRunFutureAction ?? false;
		string customActivityFutureAction = optionSet?.CustomActivityRunFutureAction;
		DateTime modifyTimeFutureAction = ((optionSet != null && optionSet.ModifytimeRunFutureAction != DateTime.MinValue) ? optionSet.ModifytimeRunFutureAction : systemTime);
		bool saveHistSegmentInjectFinishLot = optionSet?.SaveHistSegmentInjectFinishLot ?? false;
		string customActivitySegmentInjectFinishLot = optionSet?.CustomActivitySegmentInjectFinishLot;
		DateTime modifyTimeSegmentInjectFinishLot = ((optionSet != null && optionSet.ModifytimeSegmentInjectFinishLot != DateTime.MinValue) ? optionSet.ModifytimeSegmentInjectFinishLot : systemTime);
		bool flag3 = optionSet?.TrackingHistory ?? true;
		bool flag4 = optionSet?.SaveTrackinWorktime ?? true;
		string siteid = lotList[0].Siteid;
		List<Producedmaterial> list = new List<Producedmaterial>();
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		Lot[] array2 = array;
		foreach (Lot lot in array2)
		{
			Producedmaterial[] array3 = PRODUCEDMATERIAL.SelectProducedMaterialListAliveByLot4Update(dbContext, lot.Lotid, siteid).ToArray();
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lot.Lotid} ProducedMaterial Count={array3.Length}");
			}
			list.AddRange(array3);
		}
		array2 = lotList;
		foreach (Lot lot2 in array2)
		{
			List<Lot> list2 = new List<Lot>();
			List<Producedmaterial> list3 = new List<Producedmaterial>();
			ParamChecker.ArgumentNotNull("Lotid", lot2.Lotid);
			ParamChecker.ArgumentNotNull("Siteid", lot2.Siteid);
			string lotid = lot2.Lotid;
			bool flag5 = false;
			Lot lot3;
			if ((lot3 = FindLot(array, lotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lot), lotid);
			}
			if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot3))
			{
				throw new EntityIsHoldException(typeof(Lot), lotid);
			}
			if (!string.IsNullOrEmpty(lot2.Equipmentid) && flag && EQUIPMENT.SelectEquipment(dbContext, lot2.Equipmentid, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(Equipment), lot2.Equipmentid);
			}
			if (!string.IsNullOrEmpty(lot2.Portid) && flag2 && PORT.SelectPort(dbContext, lot2.Equipmentid, lot2.Portid, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(Port), lot2.Portid);
			}
			if (flag4 && !lot2.Trackintime.HasValue)
			{
				lot2.Trackintime = systemTime;
			}
			Processsegmentrule processsegmentrule = PROCESSSEGMENTRULE.SelectProcessSegmentRule(dbContext, lot3.Processsegmentruleid, siteid);
			if (processsegmentrule == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentrule), lot3.Processsegmentruleid);
			}
			ParamChecker.EntityValidState(typeof(Processsegmentrule), "Systemruleid", processsegmentrule.Systemruleid, "TrackIn");
			flag5 = processsegmentrule.Ismandatory == "Y";
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", LogInfoTrackInOutLot(lot3));
			}
			if (int.TryParse(lot3.Repeatcount?.ToString(), out var result))
			{
				lot3.Repeatcount = result + 1;
			}
			else
			{
				lot3.Repeatcount = 1;
			}
			UpdateUserColumns(text, lot2, lot3);
			lot2.CopyCommonFieldUpdatePrev(lot3, systemTime, tid, text);
			lot2.CopyExtensionCollection(lot3);
			list2.Add(lot3);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", LogInfoTrackInOutLot(lot3));
			}
			foreach (Producedmaterial item in PRODUCEDMATERIAL.FindProducedMaterialList(list.ToArray(), lotid))
			{
				_ = item.Producedmaterialid;
				if (!PRODUCEDMATERIAL.ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, item))
				{
					throw new EntityIsHoldException(typeof(Producedmaterial), item.Producedmaterialid);
				}
				if (MesLogger.IsDebugEnabled("API"))
				{
					MesLogger.DebugTidApi(tid, "Before Execute", LogInfoTrackInOutProducedMaterial(item));
				}
				PRODUCEDMATERIAL.UpdateUserColumnsFromLot(text, lot2, item);
				lot2.CopyCommonFieldUpdatePrev(item, systemTime, tid, text);
				list3.Add(item);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Execute", LogInfoTrackInOutProducedMaterial(item));
				}
			}
			bool needAdhocProcess = false;
			Lotadhocprocess lotAdhocProcess = null;
			bool needFinishLot = false;
			bool needFutureAction = false;
			if (flag5)
			{
				if (MesLogger.IsDebugEnabled("API"))
				{
					MesLogger.DebugTidApi(tid, "Before Dispatch PRE", LogInfoProcessChangeLot(lot3));
				}
				DispatchWorkLotPRE(dbContext, lot3, list3.ToArray(), systemTime, out needAdhocProcess, out lotAdhocProcess, out needFinishLot, out needFutureAction);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Dispatch PRE", LogInfoProcessChangeLot(lot3));
				}
			}
			num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHist);
			num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list3.ToArray(), saveHist);
			if (flag3)
			{
				num += LOTTRACKING.TrackinLotTracking(dbContext, lot3);
			}
			if (flag5)
			{
				DispatchWorkLotPOST(dbContext, lot2, lot3, needAdhocProcess, lotAdhocProcess, needFinishLot, needFutureAction, saveHistFinishLot, customActivityFinishLot, modifyTimeFinishLot, saveHistReworkFinishLot, customActivityReworkFinishLot, modifyTimeReworkFinishLot, saveHistSegmentInjectFinishLot, customActivitySegmentInjectFinishLot, modifyTimeSegmentInjectFinishLot, saveHistFutureAction, customActivityFutureAction, modifyTimeFutureAction);
			}
		}
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int TrackInLot(IDbContext dbContext, Lot inputLot, Producedmaterial[] inputProducedMaterialList, TrackInOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("inputLot", inputLot);
		ParamChecker.ArgumentNotNullAndHasElement("inputProducedMaterialList", inputProducedMaterialList);
		string text = "TrackInLot";
		int apiVersion = 2;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		ParamChecker.ArgumentNotNull("Lotid", inputLot.Lotid);
		ParamChecker.ArgumentNotNull("Siteid", inputLot.Siteid);
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		bool flag = optionSet?.ValidateEquipment ?? false;
		bool flag2 = optionSet?.ValidatePort ?? false;
		bool saveHistFinishLot = optionSet?.SaveHistFinishLot ?? false;
		string customActivityFinishLot = optionSet?.CustomActivityFinishLot;
		DateTime modifyTimeFinishLot = ((optionSet != null && optionSet.ModifytimeFinishLot != DateTime.MinValue) ? optionSet.ModifytimeFinishLot : systemTime);
		bool saveHistReworkFinishLot = optionSet?.SaveHistReworkFinishLot ?? false;
		string customActivityReworkFinishLot = optionSet?.CustomActivityReworkFinishLot;
		DateTime modifyTimeReworkFinishLot = ((optionSet != null && optionSet.ModifytimeReworkFinishLot != DateTime.MinValue) ? optionSet.ModifytimeReworkFinishLot : systemTime);
		bool saveHistFutureAction = optionSet?.SaveHistRunFutureAction ?? false;
		string customActivityFutureAction = optionSet?.CustomActivityRunFutureAction;
		DateTime modifyTimeFutureAction = ((optionSet != null && optionSet.ModifytimeRunFutureAction != DateTime.MinValue) ? optionSet.ModifytimeRunFutureAction : systemTime);
		bool saveHistSegmentInjectFinishLot = optionSet?.SaveHistSegmentInjectFinishLot ?? false;
		string customActivitySegmentInjectFinishLot = optionSet?.CustomActivitySegmentInjectFinishLot;
		DateTime modifyTimeSegmentInjectFinishLot = ((optionSet != null && optionSet.ModifytimeSegmentInjectFinishLot != DateTime.MinValue) ? optionSet.ModifytimeSegmentInjectFinishLot : systemTime);
		bool flag3 = optionSet?.TrackingHistory ?? true;
		string lotid = inputLot.Lotid;
		string siteid = inputLot.Siteid;
		bool flag4 = false;
		Lot lot;
		if ((lot = SelectLot4Update(dbContext, lotid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Lot), lotid);
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", lot);
		}
		Producedmaterial[] array = PRODUCEDMATERIAL.SelectProducedMaterialListAliveByLot4Update(dbContext, lotid, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lot.Lotid} ProducedMaterial Count={array.Length}");
		}
		if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot))
		{
			throw new EntityIsHoldException(typeof(Lot), lotid);
		}
		ValidateParameterProducedMaterial(text, lotid, inputProducedMaterialList, array.ToArray());
		if (!string.IsNullOrEmpty(inputLot.Equipmentid) && flag && EQUIPMENT.SelectEquipment(dbContext, inputLot.Equipmentid, siteid) == null)
		{
			throw new EntityNotFoundException(typeof(Equipment), inputLot.Equipmentid);
		}
		if (!string.IsNullOrEmpty(inputLot.Portid) && flag2 && PORT.SelectPort(dbContext, inputLot.Equipmentid, inputLot.Portid, siteid) == null)
		{
			throw new EntityNotFoundException(typeof(Port), inputLot.Portid);
		}
		Processsegmentrule processsegmentrule = PROCESSSEGMENTRULE.SelectProcessSegmentRule(dbContext, lot.Processsegmentruleid, siteid);
		if (processsegmentrule == null)
		{
			throw new EntityNotFoundException(typeof(Processsegmentrule), lot.Processsegmentruleid);
		}
		ParamChecker.EntityValidState(typeof(Processsegmentrule), "Systemruleid", processsegmentrule.Systemruleid, "TrackIn");
		flag4 = processsegmentrule.Ismandatory == "Y";
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", LogInfoTrackInOutLot(lot));
		}
		if (int.TryParse(lot.Repeatcount?.ToString(), out var result))
		{
			lot.Repeatcount = result + 1;
		}
		else
		{
			lot.Repeatcount = 1;
		}
		UpdateUserColumns(text, inputLot, lot);
		inputLot.CopyCommonFieldUpdatePrev(lot, systemTime, tid, text);
		inputLot.CopyExtensionCollection(lot);
		list.Add(lot);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", LogInfoTrackInOutLot(lot));
		}
		foreach (Producedmaterial producedmaterial in inputProducedMaterialList)
		{
			string producedmaterialid = producedmaterial.Producedmaterialid;
			Producedmaterial producedmaterial2 = PRODUCEDMATERIAL.FindProducedMaterial(array, producedmaterialid);
			if (!PRODUCEDMATERIAL.ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, producedmaterial2))
			{
				throw new EntityIsHoldException(typeof(Producedmaterial), producedmaterial2.Producedmaterialid);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", LogInfoTrackInOutProducedMaterial(producedmaterial2));
			}
			PRODUCEDMATERIAL.UpdateUserColumns(text, producedmaterial, producedmaterial2);
			producedmaterial.CopyCommonFieldUpdatePrev(producedmaterial2, systemTime, tid, text);
			producedmaterial.CopyExtensionCollection(producedmaterial2);
			list2.Add(producedmaterial2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", LogInfoTrackInOutProducedMaterial(producedmaterial2));
			}
		}
		bool needAdhocProcess = false;
		Lotadhocprocess lotAdhocProcess = null;
		bool needFinishLot = false;
		bool needFutureAction = false;
		if (flag4)
		{
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Dispatch PRE", LogInfoProcessChangeLot(lot));
			}
			DispatchWorkLotPRE(dbContext, lot, list2.ToArray(), systemTime, out needAdhocProcess, out lotAdhocProcess, out needFinishLot, out needFutureAction);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Dispatch PRE", LogInfoProcessChangeLot(lot));
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHist);
		if (flag3)
		{
			LOTTRACKING.TrackinLotTracking(dbContext, lot);
		}
		if (flag4)
		{
			DispatchWorkLotPOST(dbContext, inputLot, lot, needAdhocProcess, lotAdhocProcess, needFinishLot, needFutureAction, saveHistFinishLot, customActivityFinishLot, modifyTimeFinishLot, saveHistReworkFinishLot, customActivityReworkFinishLot, modifyTimeReworkFinishLot, saveHistSegmentInjectFinishLot, customActivitySegmentInjectFinishLot, modifyTimeSegmentInjectFinishLot, saveHistFutureAction, customActivityFutureAction, modifyTimeFutureAction);
		}
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	internal static string LogInfoTrackInOutLot(Lot lot)
	{
		return string.Format(_formatTrackInOutInfoLot, lot.Lotid, lot.Processsegmentid, lot.Equipmentid, lot.Location, lot.Grade, lot.Qty, lot.Submaterialqty, lot.Lossqty, lot.Nextprocesssegmentid, lot.Trackinuser, lot.Trackintime, lot.Trackoutuser, lot.Trackouttime, lot.Processstarttime, lot.Processendtime);
	}

	internal static string LogInfoProcessChangeLot(Lot lot)
	{
		return string.Format(_formatProcessChangeLot, lot.Lotid, lot.State, lot.Processingstate, lot.Processsegmentid, lot.Processsegmentruleid, lot.Rulesequence, lot.Nextprocesssegmentid);
	}

	internal static string LogInfoTrackInOutProducedMaterial(Producedmaterial producedMaterial)
	{
		return string.Format(_formatTrackInOutInfoProducedMaterial, producedMaterial.Producedmaterialid, producedMaterial.Processsegmentid, producedMaterial.Equipmentid, producedMaterial.Location, producedMaterial.Grade, producedMaterial.Submaterialqty, producedMaterial.Trackinuser, producedMaterial.Trackintime, producedMaterial.Trackoutuser, producedMaterial.Trackouttime, producedMaterial.Processstarttime, producedMaterial.Processendtime);
	}

	public static int TrackInLotBulk(IDbContext dbContext, Lot[] lotList, TrackInOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		object[] objectList = lotList;
		ParamChecker.ArgumentNotNullAndHasElement("lotList", objectList);
		string text = "TrackInLotBulk";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		bool flag = optionSet?.ValidateEquipment ?? false;
		bool flag2 = optionSet?.ValidatePort ?? false;
		bool saveHistFinishLot = optionSet?.SaveHistFinishLot ?? false;
		string customActivityFinishLot = optionSet?.CustomActivityFinishLot;
		DateTime modifyTimeFinishLot = ((optionSet != null && optionSet.ModifytimeFinishLot != DateTime.MinValue) ? optionSet.ModifytimeFinishLot : systemTime);
		bool saveHistReworkFinishLot = optionSet?.SaveHistReworkFinishLot ?? false;
		string customActivityReworkFinishLot = optionSet?.CustomActivityReworkFinishLot;
		DateTime modifyTimeReworkFinishLot = ((optionSet != null && optionSet.ModifytimeReworkFinishLot != DateTime.MinValue) ? optionSet.ModifytimeReworkFinishLot : systemTime);
		bool saveHistFutureAction = optionSet?.SaveHistRunFutureAction ?? false;
		string customActivityFutureAction = optionSet?.CustomActivityRunFutureAction;
		DateTime modifyTimeFutureAction = ((optionSet != null && optionSet.ModifytimeRunFutureAction != DateTime.MinValue) ? optionSet.ModifytimeRunFutureAction : systemTime);
		bool saveHistSegmentInjectFinishLot = optionSet?.SaveHistSegmentInjectFinishLot ?? false;
		string customActivitySegmentInjectFinishLot = optionSet?.CustomActivitySegmentInjectFinishLot;
		DateTime modifyTimeSegmentInjectFinishLot = ((optionSet != null && optionSet.ModifytimeSegmentInjectFinishLot != DateTime.MinValue) ? optionSet.ModifytimeSegmentInjectFinishLot : systemTime);
		bool flag3 = optionSet?.TrackingHistory ?? true;
		bool flag4 = optionSet?.SaveTrackinWorktime ?? true;
		string[] bulkColumnList = optionSet?.BulkColumnList;
		string siteid = lotList[0].Siteid;
		new List<Producedmaterial>();
		new List<Lot>();
		new List<Producedmaterial>();
		objectList = ExtractIdOrderBy(lotList);
		ParamChecker.ArgumentNotNull("Lotid", objectList);
		ParamChecker.ArgumentNotNull("Siteid", siteid);
		string[] first = ExtractIdOrderBy(lotList);
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		if (lotList.Length > array.Length)
		{
			throw new EntityNotFoundException(typeof(Lot), first.Except(ExtractIdOrderBy(array.ToArray())).ToString());
		}
		Producedmaterial[] array2 = PRODUCEDMATERIAL.SelectProducedMaterialListByLotWithNotState4BulkUpdate(dbContext, array, new string[2] { "Scrapped", "Terminated" }, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={EntityHelper.ConcatString4InClause(ExtractIdOrderBy(array))} ProducedMaterial Count={array2.Length}");
		}
		IList<Lot> list = SelectLotListAlive4Update(dbContext, array, siteid);
		if (array.Length > list.Count)
		{
			throw new EntityNotFoundException(typeof(Lot), first.Except(ExtractIdOrderBy(list.ToArray())).ToString());
		}
		if (!ValidateAllowHoldLotBulk(dbContext, text, apiVersion, array))
		{
			Lot[] lotList2 = array.Where((Lot v) => v.Ishold == "Y").ToArray();
			throw new EntityIsHoldException(typeof(Lot), EntityHelper.ConcatString4InClause(ExtractIdOrderBy(lotList2)));
		}
		string[] array3 = (from p in lotList
			select p.Equipmentid into id
			orderby id
			select id).Distinct().ToArray();
		if (!string.IsNullOrEmpty(array3[0]) && flag)
		{
			if (array3.Length > 1)
			{
				throw new Exception($"{EntityHelper.ConcatString4InClause(array3)}등의 다중 설비로 Bulk TrackIn을 시도함");
			}
			if (EQUIPMENT.SelectEquipment(dbContext, array3[0], siteid) == null)
			{
				throw new EntityNotFoundException(typeof(Equipment), array3[0]);
			}
		}
		string[] array4 = (from p in lotList
			select p.Portid into id
			orderby id
			select id).Distinct().ToArray();
		if (!string.IsNullOrEmpty(array4[0]) && flag2)
		{
			string[] array5 = array4;
			foreach (string text2 in array5)
			{
				if (PORT.SelectPort(dbContext, array3[0], text2, siteid) == null)
				{
					throw new EntityNotFoundException(typeof(Port), text2);
				}
			}
		}
		string[] array6 = (from p in array
			select p.Processsegmentruleid into id
			orderby id
			select id).Distinct().ToArray();
		if (array6.Length > 1)
		{
			throw new Exception("여러개의 공정으로 Bulk TrackIn을 시도함");
		}
		Processsegmentrule processsegmentrule = PROCESSSEGMENTRULE.SelectProcessSegmentRule(dbContext, array6[0], siteid);
		if (processsegmentrule == null)
		{
			throw new EntityNotFoundException(typeof(Processsegmentrule), array6[0]);
		}
		ParamChecker.EntityValidState(typeof(Processsegmentrule), "Systemruleid", processsegmentrule.Systemruleid, "TrackIn");
		bool num2 = processsegmentrule.Ismandatory == "Y";
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", LogInfoTrackInOutLotListBulk(array));
		}
		Lot lot = lotList[0];
		if (flag4 && !lot.Trackintime.HasValue)
		{
			lot.Trackintime = systemTime;
		}
		UpdateUserColumns(text, lot, array[0]);
		lot.CopyCommonFieldUpdatePrev(array[0], systemTime, tid, text);
		lot.CopyExtensionCollection(array[0]);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", LogInfoTrackInOutLotListBulk(array));
		}
		if (array2.Length != 0)
		{
			_ = array2[0].Producedmaterialid;
			if (!PRODUCEDMATERIAL.ValidateAllowHoldProducedMaterialBulk(dbContext, text, apiVersion, array2))
			{
				throw new EntityIsHoldException(objectName: EntityHelper.ConcatString4InClause((from p in array2.Where((Producedmaterial v) => v.Ishold == "Y").ToArray()
					select p.Producedmaterialid into id
					orderby id
					select id).ToArray()), paramType: typeof(Producedmaterial));
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", LogInfoTrackInOutProducedMaterialBulk(array2));
			}
			PRODUCEDMATERIAL.UpdateUserColumnsFromLot(text, lot, array2[0]);
			lot.CopyCommonFieldUpdatePrev(array2[0], systemTime, tid, text);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", LogInfoTrackInOutProducedMaterialBulk(array2));
			}
		}
		bool needAdhocProcess = false;
		Lotadhocprocess lotAdhocProcess = null;
		bool needFinishLot = false;
		bool needFutureAction = false;
		if (num2)
		{
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Dispatch PRE", LogInfoProcessChangeLotBulk(array));
			}
			DispatchWorkLotPRE(dbContext, array[0], array2, systemTime, out needAdhocProcess, out lotAdhocProcess, out needFinishLot, out needFutureAction);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Dispatch PRE", LogInfoProcessChangeLotBulk(array));
			}
		}
		num += ContextManager.BulkUpdateEntityFullColumn(dbContext, array[0], array, bulkColumnList, saveHist);
		if (array2.Length != 0)
		{
			num += ContextManager.BulkUpdateEntityFullColumn(dbContext, array2[0], array2, bulkColumnList, saveHist);
		}
		if (flag3)
		{
			LOTTRACKING.TrackinLotTrackingBulk(dbContext, array);
		}
		if (num2)
		{
			DispatchWorkLotPOST(dbContext, lot, array[0], needAdhocProcess, lotAdhocProcess, needFinishLot, needFutureAction, saveHistFinishLot, customActivityFinishLot, modifyTimeFinishLot, saveHistReworkFinishLot, customActivityReworkFinishLot, modifyTimeReworkFinishLot, saveHistSegmentInjectFinishLot, customActivitySegmentInjectFinishLot, modifyTimeSegmentInjectFinishLot, saveHistFutureAction, customActivityFutureAction, modifyTimeFutureAction);
		}
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	internal static string LogInfoTrackInOutLotListBulk(Lot[] lotList)
	{
		return string.Format(_formatTrackInOutInfoLotBulk, EntityHelper.ConcatString4InClause(ExtractIdOrderBy(lotList)), EntityHelper.ConcatString4InClause((from p in lotList
			select p.Processsegmentid into id
			orderby id
			select id).ToArray()), EntityHelper.ConcatString4InClause((from p in lotList
			select p.Equipmentid into id
			orderby id
			select id).ToArray()), EntityHelper.ConcatString4InClause((from p in lotList
			select p.Location into id
			orderby id
			select id).ToArray()), EntityHelper.ConcatString4InClause((from p in lotList
			select p.Grade into id
			orderby id
			select id).ToArray()), EntityHelper.ConcatString4InClause((from p in lotList
			select p.Qty.ToString() into id
			orderby id
			select id).ToArray()), EntityHelper.ConcatString4InClause((from p in lotList
			select p.Submaterialqty.ToString() into id
			orderby id
			select id).ToArray()), EntityHelper.ConcatString4InClause((from p in lotList
			select p.Lossqty.ToString() into id
			orderby id
			select id).ToArray()), EntityHelper.ConcatString4InClause((from p in lotList
			select p.Nextprocesssegmentid into id
			orderby id
			select id).ToArray()), EntityHelper.ConcatString4InClause((from p in lotList
			select p.Trackinuser into id
			orderby id
			select id).ToArray()), EntityHelper.ConcatString4InClause((from p in lotList
			select p.Trackintime.ToString() into id
			orderby id
			select id).ToArray()), EntityHelper.ConcatString4InClause((from p in lotList
			select p.Trackoutuser into id
			orderby id
			select id).ToArray()), EntityHelper.ConcatString4InClause((from p in lotList
			select p.Trackouttime.ToString() into id
			orderby id
			select id).ToArray()), EntityHelper.ConcatString4InClause((from p in lotList
			select p.Processstarttime.ToString() into id
			orderby id
			select id).ToArray()), EntityHelper.ConcatString4InClause((from p in lotList
			select p.Processendtime.ToString() into id
			orderby id
			select id).ToArray()));
	}

	internal static string LogInfoProcessChangeLotBulk(Lot[] lotList)
	{
		return string.Format(_formatProcessChangeLotBulk, EntityHelper.ConcatString4InClause(ExtractIdOrderBy(lotList)), EntityHelper.ConcatString4InClause((from p in lotList
			select p.State into id
			orderby id
			select id).ToArray()), EntityHelper.ConcatString4InClause((from p in lotList
			select p.Processingstate into id
			orderby id
			select id).ToArray()), EntityHelper.ConcatString4InClause((from p in lotList
			select p.Processsegmentid into id
			orderby id
			select id).ToArray()), EntityHelper.ConcatString4InClause((from p in lotList
			select p.Processsegmentruleid into id
			orderby id
			select id).ToArray()), EntityHelper.ConcatString4InClause((from p in lotList
			select p.Rulesequence.ToString() into id
			orderby id
			select id).ToArray()), EntityHelper.ConcatString4InClause((from p in lotList
			select p.Nextprocesssegmentid into id
			orderby id
			select id).ToArray()));
	}

	internal static string LogInfoTrackInOutProducedMaterialBulk(Producedmaterial[] producedMaterialList)
	{
		return string.Format(_formatTrackInOutInfoProducedMaterialBulk, EntityHelper.ConcatString4InClause((from p in producedMaterialList
			select p.Producedmaterialid into id
			orderby id
			select id).ToArray()), EntityHelper.ConcatString4InClause((from p in producedMaterialList
			select p.Processsegmentid into id
			orderby id
			select id).ToArray()), EntityHelper.ConcatString4InClause((from p in producedMaterialList
			select p.Equipmentid into id
			orderby id
			select id).ToArray()), EntityHelper.ConcatString4InClause((from p in producedMaterialList
			select p.Location into id
			orderby id
			select id).ToArray()), EntityHelper.ConcatString4InClause((from p in producedMaterialList
			select p.Grade into id
			orderby id
			select id).ToArray()), EntityHelper.ConcatString4InClause((from p in producedMaterialList
			select p.Submaterialqty.ToString() into id
			orderby id
			select id).ToArray()), EntityHelper.ConcatString4InClause((from p in producedMaterialList
			select p.Trackinuser into id
			orderby id
			select id).ToArray()), EntityHelper.ConcatString4InClause((from p in producedMaterialList
			select p.Trackintime.ToString() into id
			orderby id
			select id).ToArray()), EntityHelper.ConcatString4InClause((from p in producedMaterialList
			select p.Trackoutuser into id
			orderby id
			select id).ToArray()), EntityHelper.ConcatString4InClause((from p in producedMaterialList
			select p.Trackouttime.ToString() into id
			orderby id
			select id).ToArray()), EntityHelper.ConcatString4InClause((from p in producedMaterialList
			select p.Processstarttime.ToString() into id
			orderby id
			select id).ToArray()), EntityHelper.ConcatString4InClause((from p in producedMaterialList
			select p.Processendtime.ToString() into id
			orderby id
			select id).ToArray()));
	}

	public static int TrackOutLot(IDbContext dbContext, Lot[] lotList, TrackOutOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotList", lotList);
		string text = "TrackOutLot";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		bool flag = optionSet?.ValidateEquipment ?? false;
		bool flag2 = optionSet?.ValidatePort ?? false;
		bool saveHistFinishLot = optionSet?.SaveHistFinishLot ?? false;
		string customActivityFinishLot = optionSet?.CustomActivityFinishLot;
		DateTime modifyTimeFinishLot = ((optionSet != null && optionSet.ModifytimeFinishLot != DateTime.MinValue) ? optionSet.ModifytimeFinishLot : systemTime);
		bool saveHistReworkFinishLot = optionSet?.SaveHistReworkFinishLot ?? false;
		string customActivityReworkFinishLot = optionSet?.CustomActivityReworkFinishLot;
		DateTime modifyTimeReworkFinishLot = ((optionSet != null && optionSet.ModifytimeReworkFinishLot != DateTime.MinValue) ? optionSet.ModifytimeReworkFinishLot : systemTime);
		bool saveHistFutureAction = optionSet?.SaveHistRunFutureAction ?? false;
		string customActivityFutureAction = optionSet?.CustomActivityRunFutureAction;
		DateTime modifyTimeFutureAction = ((optionSet != null && optionSet.ModifytimeRunFutureAction != DateTime.MinValue) ? optionSet.ModifytimeRunFutureAction : systemTime);
		bool saveHistSegmentInjectFinishLot = optionSet?.SaveHistSegmentInjectFinishLot ?? false;
		string customActivitySegmentInjectFinishLot = optionSet?.CustomActivitySegmentInjectFinishLot;
		DateTime modifyTimeSegmentInjectFinishLot = ((optionSet != null && optionSet.ModifytimeSegmentInjectFinishLot != DateTime.MinValue) ? optionSet.ModifytimeSegmentInjectFinishLot : systemTime);
		bool flag3 = optionSet?.SaveHistWaitForSegment ?? false;
		bool flag4 = optionSet?.TrackingHistory ?? true;
		bool flag5 = optionSet?.SaveTrackoutWorktime ?? true;
		bool flag6 = optionSet?.UpdateOriginalQty ?? false;
		string siteid = lotList[0].Siteid;
		List<Producedmaterial> list = new List<Producedmaterial>();
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		Lot[] array2 = array;
		foreach (Lot lot in array2)
		{
			Producedmaterial[] array3 = PRODUCEDMATERIAL.SelectProducedMaterialListAliveByLot4Update(dbContext, lot.Lotid, siteid).ToArray();
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lot.Lotid} ProducedMaterial Count={array3.Length}");
			}
			list.AddRange(array3);
		}
		array2 = lotList;
		foreach (Lot lot2 in array2)
		{
			List<Lot> list2 = new List<Lot>();
			List<Producedmaterial> list3 = new List<Producedmaterial>();
			ParamChecker.ArgumentNotNull("Lotid", lot2.Lotid);
			ParamChecker.ArgumentNotNull("Siteid", lot2.Siteid);
			string lotid = lot2.Lotid;
			bool flag7 = false;
			Lot lot3 = new Lot();
			Lot lot4;
			if ((lot4 = FindLot(array, lotid)) == null)
			{
				throw new EntityNotFoundException(typeof(Lot), lotid);
			}
			if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot4))
			{
				throw new EntityIsHoldException(typeof(Lot), lotid);
			}
			if (!string.IsNullOrEmpty(lot2.Equipmentid) && flag && EQUIPMENT.SelectEquipment(dbContext, lot2.Equipmentid, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(Equipment), lot2.Equipmentid);
			}
			if (!string.IsNullOrEmpty(lot2.Portid) && flag2 && PORT.SelectPort(dbContext, lot2.Equipmentid, lot2.Portid, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(Port), lot2.Portid);
			}
			if (flag5 && !lot2.Trackouttime.HasValue)
			{
				lot2.Trackouttime = systemTime;
			}
			int num2;
			if (lot4.Originalqty.HasValue)
			{
				decimal? originalqty = lot4.Originalqty;
				num2 = (((originalqty.GetValueOrDefault() == default(decimal)) & originalqty.HasValue) ? 1 : 0);
			}
			else
			{
				num2 = 1;
			}
			if (((uint)num2 & (flag6 ? 1u : 0u)) != 0)
			{
				lot4.Originalqty = lot2.Originalqty;
			}
			Processsegmentrule processsegmentrule = PROCESSSEGMENTRULE.SelectProcessSegmentRule(dbContext, lot4.Processsegmentruleid, siteid);
			if (processsegmentrule == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentrule), lot4.Processsegmentruleid);
			}
			ParamChecker.EntityValidState(typeof(Processsegmentrule), "Systemruleid", processsegmentrule.Systemruleid, "TrackOut");
			flag7 = processsegmentrule.Ismandatory == "Y";
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", LogInfoTrackInOutLot(lot4));
			}
			lot4.CopySameColumnsTo(lot3);
			UpdateUserColumns(text, lot2, lot4);
			lot4.Nextprocesssegmentid = lot2.Nextprocesssegmentid;
			lot4.Nextsubprocessdefinitionid = lot2.Nextsubprocessdefinitionid;
			lot2.CopyCommonFieldUpdatePrev(lot4, systemTime, tid, text);
			lot2.CopyExtensionCollection(lot4);
			list2.Add(lot4);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", LogInfoTrackInOutLot(lot4));
			}
			foreach (Producedmaterial item in PRODUCEDMATERIAL.FindProducedMaterialList(list.ToArray(), lotid))
			{
				_ = item.Producedmaterialid;
				if (!PRODUCEDMATERIAL.ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, item))
				{
					throw new EntityIsHoldException(typeof(Producedmaterial), item.Producedmaterialid);
				}
				if (MesLogger.IsDebugEnabled("API"))
				{
					MesLogger.DebugTidApi(tid, "Before Execute", LogInfoTrackInOutProducedMaterial(item));
				}
				PRODUCEDMATERIAL.UpdateUserColumnsFromLot(text, lot2, item);
				lot2.CopyCommonFieldUpdatePrev(item, systemTime, tid, text);
				list3.Add(item);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Execute", LogInfoTrackInOutProducedMaterial(item));
				}
			}
			bool needAdhocProcess = false;
			Lotadhocprocess lotAdhocProcess = null;
			bool needFinishLot = false;
			bool needFutureAction = false;
			if (flag3)
			{
				string processingstate = lot4.Processingstate;
				string processsegmentruleid = lot4.Processsegmentruleid;
				int? rulesequence = lot4.Rulesequence;
				lot4.Processingstate = "WaitForSegment";
				lot4.Processsegmentruleid = null;
				lot4.Rulesequence = null;
				num += ContextManager.UpsertEntityWithFullColumnOnlyHist(dbContext, list2.ToArray());
				lot4.Processingstate = processingstate;
				lot4.Processsegmentruleid = processsegmentruleid;
				lot4.Rulesequence = rulesequence;
			}
			if (flag7)
			{
				if (MesLogger.IsDebugEnabled("API"))
				{
					MesLogger.DebugTidApi(tid, "Before Dispatch PRE", LogInfoProcessChangeLot(lot4));
				}
				DispatchWorkLotPRE(dbContext, lot4, list3.ToArray(), systemTime, out needAdhocProcess, out lotAdhocProcess, out needFinishLot, out needFutureAction);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Dispatch PRE", LogInfoProcessChangeLot(lot4));
				}
			}
			num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHist);
			num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list3.ToArray(), saveHist);
			if (flag4)
			{
				num += LOTTRACKING.TrackoutLotTracking(dbContext, lot3, optionSet);
			}
			if (flag7)
			{
				DispatchWorkLotPOST(dbContext, lot2, lot4, needAdhocProcess, lotAdhocProcess, needFinishLot, needFutureAction, saveHistFinishLot, customActivityFinishLot, modifyTimeFinishLot, saveHistReworkFinishLot, customActivityReworkFinishLot, modifyTimeReworkFinishLot, saveHistSegmentInjectFinishLot, customActivitySegmentInjectFinishLot, modifyTimeSegmentInjectFinishLot, saveHistFutureAction, customActivityFutureAction, modifyTimeFutureAction);
			}
		}
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int TrackOutLot(IDbContext dbContext, Lot inputLot, Producedmaterial[] inputProducedMaterialList, TrackOutOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("inputLot", inputLot);
		string text = "TrackOutLot";
		int apiVersion = 2;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		ParamChecker.ArgumentNotNull("Lotid", inputLot.Lotid);
		ParamChecker.ArgumentNotNull("Siteid", inputLot.Siteid);
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		bool flag = optionSet?.ValidateEquipment ?? false;
		bool flag2 = optionSet?.ValidatePort ?? false;
		bool saveHistFinishLot = optionSet?.SaveHistFinishLot ?? false;
		string customActivityFinishLot = optionSet?.CustomActivityFinishLot;
		DateTime modifyTimeFinishLot = ((optionSet != null && optionSet.ModifytimeFinishLot != DateTime.MinValue) ? optionSet.ModifytimeFinishLot : systemTime);
		bool saveHistReworkFinishLot = optionSet?.SaveHistReworkFinishLot ?? false;
		string customActivityReworkFinishLot = optionSet?.CustomActivityReworkFinishLot;
		DateTime modifyTimeReworkFinishLot = ((optionSet != null && optionSet.ModifytimeReworkFinishLot != DateTime.MinValue) ? optionSet.ModifytimeReworkFinishLot : systemTime);
		bool saveHistFutureAction = optionSet?.SaveHistRunFutureAction ?? false;
		string customActivityFutureAction = optionSet?.CustomActivityRunFutureAction;
		DateTime modifyTimeFutureAction = ((optionSet != null && optionSet.ModifytimeRunFutureAction != DateTime.MinValue) ? optionSet.ModifytimeRunFutureAction : systemTime);
		bool saveHistSegmentInjectFinishLot = optionSet?.SaveHistSegmentInjectFinishLot ?? false;
		string customActivitySegmentInjectFinishLot = optionSet?.CustomActivitySegmentInjectFinishLot;
		DateTime modifyTimeSegmentInjectFinishLot = ((optionSet != null && optionSet.ModifytimeSegmentInjectFinishLot != DateTime.MinValue) ? optionSet.ModifytimeSegmentInjectFinishLot : systemTime);
		bool flag3 = optionSet?.TrackingHistory ?? true;
		bool flag4 = optionSet?.SaveTrackoutWorktime ?? true;
		bool flag5 = optionSet?.UpdateOriginalQty ?? false;
		string lotid = inputLot.Lotid;
		string siteid = inputLot.Siteid;
		bool flag6 = false;
		Lot lot = new Lot();
		Lot lot2;
		if ((lot2 = SelectLot4Update(dbContext, lotid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Lot), lotid);
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", lot2);
		}
		Producedmaterial[] array = PRODUCEDMATERIAL.SelectProducedMaterialListAliveByLot4Update(dbContext, lotid, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lot2.Lotid} ProducedMaterial Count={array.Length}");
		}
		if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot2))
		{
			throw new EntityIsHoldException(typeof(Lot), lotid);
		}
		ValidateParameterProducedMaterial(text, lotid, inputProducedMaterialList, array.ToArray());
		if (!string.IsNullOrEmpty(inputLot.Equipmentid) && flag && EQUIPMENT.SelectEquipment(dbContext, inputLot.Equipmentid, siteid) == null)
		{
			throw new EntityNotFoundException(typeof(Equipment), inputLot.Equipmentid);
		}
		if (!string.IsNullOrEmpty(inputLot.Portid) && flag2 && PORT.SelectPort(dbContext, inputLot.Equipmentid, inputLot.Portid, siteid) == null)
		{
			throw new EntityNotFoundException(typeof(Port), inputLot.Portid);
		}
		if (flag4 && !inputLot.Trackouttime.HasValue)
		{
			inputLot.Trackouttime = systemTime;
		}
		int num2;
		if (lot2.Originalqty.HasValue)
		{
			decimal? originalqty = lot2.Originalqty;
			num2 = (((originalqty.GetValueOrDefault() == default(decimal)) & originalqty.HasValue) ? 1 : 0);
		}
		else
		{
			num2 = 1;
		}
		if (((uint)num2 & (flag5 ? 1u : 0u)) != 0)
		{
			lot2.Originalqty = inputLot.Originalqty;
		}
		Processsegmentrule processsegmentrule = PROCESSSEGMENTRULE.SelectProcessSegmentRule(dbContext, lot2.Processsegmentruleid, siteid);
		if (processsegmentrule == null)
		{
			throw new EntityNotFoundException(typeof(Processsegmentrule), lot2.Processsegmentruleid);
		}
		ParamChecker.EntityValidState(typeof(Processsegmentrule), "Systemruleid", processsegmentrule.Systemruleid, "TrackOut");
		flag6 = processsegmentrule.Ismandatory == "Y";
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", LogInfoTrackInOutLot(lot2));
		}
		UpdateUserColumns(text, inputLot, lot2);
		lot2.CopySameColumnsTo(lot);
		inputLot.CopyCommonFieldUpdatePrev(lot, systemTime, tid, text);
		inputLot.CopyExtensionCollection(lot);
		lot2.Nextprocesssegmentid = inputLot.Nextprocesssegmentid;
		lot2.Nextsubprocessdefinitionid = inputLot.Nextsubprocessdefinitionid;
		inputLot.CopyCommonFieldUpdatePrev(lot2, systemTime, tid, text);
		inputLot.CopyExtensionCollection(lot2);
		list.Add(lot2);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", LogInfoTrackInOutLot(lot2));
		}
		foreach (Producedmaterial producedmaterial in inputProducedMaterialList)
		{
			string producedmaterialid = producedmaterial.Producedmaterialid;
			Producedmaterial producedmaterial2 = PRODUCEDMATERIAL.FindProducedMaterial(array, producedmaterialid);
			if (!PRODUCEDMATERIAL.ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, producedmaterial2))
			{
				throw new EntityIsHoldException(typeof(Producedmaterial), producedmaterial2.Producedmaterialid);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", LogInfoTrackInOutProducedMaterial(producedmaterial2));
			}
			PRODUCEDMATERIAL.UpdateUserColumns(text, producedmaterial, producedmaterial2);
			producedmaterial.CopyCommonFieldUpdatePrev(producedmaterial2, systemTime, tid, text);
			producedmaterial.CopyExtensionCollection(producedmaterial2);
			list2.Add(producedmaterial2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", LogInfoTrackInOutProducedMaterial(producedmaterial2));
			}
		}
		bool needAdhocProcess = false;
		Lotadhocprocess lotAdhocProcess = null;
		bool needFinishLot = false;
		bool needFutureAction = false;
		if (flag6)
		{
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Dispatch PRE", LogInfoProcessChangeLot(lot2));
			}
			DispatchWorkLotPRE(dbContext, lot2, list2.ToArray(), systemTime, out needAdhocProcess, out lotAdhocProcess, out needFinishLot, out needFutureAction);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Dispatch PRE", LogInfoProcessChangeLot(lot2));
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHist);
		if (flag3)
		{
			num += LOTTRACKING.TrackoutLotTracking(dbContext, lot, optionSet);
		}
		if (flag6)
		{
			DispatchWorkLotPOST(dbContext, inputLot, lot2, needAdhocProcess, lotAdhocProcess, needFinishLot, needFutureAction, saveHistFinishLot, customActivityFinishLot, modifyTimeFinishLot, saveHistReworkFinishLot, customActivityReworkFinishLot, modifyTimeReworkFinishLot, saveHistSegmentInjectFinishLot, customActivitySegmentInjectFinishLot, modifyTimeSegmentInjectFinishLot, saveHistFutureAction, customActivityFutureAction, modifyTimeFutureAction);
		}
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int TrackOutLotBulk(IDbContext dbContext, Lot[] lotList, TrackOutOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		object[] objectList = lotList;
		ParamChecker.ArgumentNotNullAndHasElement("lotList", objectList);
		string text = "TrackOutLotBulk";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		bool flag = optionSet?.ValidateEquipment ?? false;
		bool flag2 = optionSet?.ValidatePort ?? false;
		bool saveHistFinishLot = optionSet?.SaveHistFinishLot ?? false;
		string customActivityFinishLot = optionSet?.CustomActivityFinishLot;
		DateTime modifyTimeFinishLot = ((optionSet != null && optionSet.ModifytimeFinishLot != DateTime.MinValue) ? optionSet.ModifytimeFinishLot : systemTime);
		_ = optionSet?.SaveHistReworkFinishLot;
		_ = optionSet?.CustomActivityReworkFinishLot;
		if (optionSet != null && optionSet.ModifytimeReworkFinishLot != DateTime.MinValue)
		{
			_ = optionSet.ModifytimeReworkFinishLot;
		}
		_ = optionSet?.SaveHistRunFutureAction;
		_ = optionSet?.CustomActivityRunFutureAction;
		if (optionSet != null && optionSet.ModifytimeRunFutureAction != DateTime.MinValue)
		{
			_ = optionSet.ModifytimeRunFutureAction;
		}
		_ = optionSet?.SaveHistSegmentInjectFinishLot;
		_ = optionSet?.CustomActivitySegmentInjectFinishLot;
		if (optionSet != null && optionSet.ModifytimeSegmentInjectFinishLot != DateTime.MinValue)
		{
			_ = optionSet.ModifytimeSegmentInjectFinishLot;
		}
		bool flag3 = optionSet?.SaveHistWaitForSegment ?? false;
		bool flag4 = optionSet?.TrackingHistory ?? true;
		bool flag5 = optionSet?.SaveTrackoutWorktime ?? true;
		string[] bulkColumnList = optionSet?.BulkColumnList;
		bool flag6 = optionSet?.UpdateOriginalQty ?? false;
		string[] first = ExtractIdOrderBy(lotList);
		string siteid = lotList[0].Siteid;
		Lot lot = new Lot();
		new List<Producedmaterial>();
		Lot[] array = SelectLotList4Update(dbContext, lotList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lot Count={array.Length}");
		}
		if (lotList.Length > array.Length)
		{
			throw new EntityNotFoundException(typeof(Lot), first.Except(ExtractIdOrderBy(array.ToArray())).ToString());
		}
		Producedmaterial[] array2 = PRODUCEDMATERIAL.SelectProducedMaterialListByLotWithNotState4BulkUpdate(dbContext, array, new string[2] { "Scrapped", "Terminated" }, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={EntityHelper.ConcatString4InClause(ExtractIdOrderBy(array))} ProducedMaterial Count={array2.Length}");
		}
		new List<Lot>();
		new List<Producedmaterial>();
		objectList = ExtractIdOrderBy(lotList);
		ParamChecker.ArgumentNotNull("Lotid", objectList);
		ParamChecker.ArgumentNotNull("Siteid", siteid);
		IList<Lot> list = SelectLotListAlive4Update(dbContext, array, siteid);
		if (array.Length > list.Count)
		{
			throw new EntityNotFoundException(typeof(Lot), first.Except(ExtractIdOrderBy(list.ToArray())).ToString());
		}
		if (!ValidateAllowHoldLotBulk(dbContext, text, apiVersion, array))
		{
			Lot[] lotList2 = array.Where((Lot v) => v.Ishold == "Y").ToArray();
			throw new EntityIsHoldException(typeof(Lot), EntityHelper.ConcatString4InClause(ExtractIdOrderBy(lotList2)));
		}
		string[] array3 = (from p in lotList
			select p.Equipmentid into id
			orderby id
			select id).Distinct().ToArray();
		if (!string.IsNullOrEmpty(array3[0]) && flag)
		{
			if (array3.Length > 1)
			{
				throw new Exception($"{EntityHelper.ConcatString4InClause(array3)}등의 다중 설비로 Bulk TrackOut을 시도함");
			}
			if (EQUIPMENT.SelectEquipment(dbContext, array3[0], siteid) == null)
			{
				throw new EntityNotFoundException(typeof(Equipment), array3[0]);
			}
		}
		string[] array4 = (from p in lotList
			select p.Portid into id
			orderby id
			select id).Distinct().ToArray();
		if (!string.IsNullOrEmpty(array4[0]) && flag2)
		{
			string[] array5 = array4;
			foreach (string text2 in array5)
			{
				if (PORT.SelectPort(dbContext, array3[0], text2, siteid) == null)
				{
					throw new EntityNotFoundException(typeof(Port), text2);
				}
			}
		}
		string[] array6 = (from p in array
			select p.Processsegmentruleid into id
			orderby id
			select id).Distinct().ToArray();
		if (array6.Length > 1)
		{
			throw new Exception("여러개의 공정으로 Bulk TrackOut을 시도함");
		}
		Processsegmentrule processsegmentrule = PROCESSSEGMENTRULE.SelectProcessSegmentRule(dbContext, array6[0], siteid);
		if (processsegmentrule == null)
		{
			throw new EntityNotFoundException(typeof(Processsegmentrule), array6[0]);
		}
		ParamChecker.EntityValidState(typeof(Processsegmentrule), "Systemruleid", processsegmentrule.Systemruleid, "TrackOut");
		bool num2 = processsegmentrule.Ismandatory == "Y";
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", LogInfoTrackInOutLotListBulk(array));
		}
		Lot lot2 = lotList[0];
		if (flag5 && !lot2.Trackouttime.HasValue)
		{
			lot2.Trackouttime = systemTime;
		}
		int num3;
		if (array[0].Originalqty.HasValue)
		{
			decimal? originalqty = array[0].Originalqty;
			num3 = (((originalqty.GetValueOrDefault() == default(decimal)) & originalqty.HasValue) ? 1 : 0);
		}
		else
		{
			num3 = 1;
		}
		if (((uint)num3 & (flag6 ? 1u : 0u)) != 0)
		{
			array[0].Originalqty = lot2.Originalqty;
		}
		array[0].CopySameColumnsTo(lot);
		UpdateUserColumns(text, lot2, array[0]);
		array[0].Nextprocesssegmentid = lot2.Nextprocesssegmentid;
		array[0].Nextsubprocessdefinitionid = lot2.Nextsubprocessdefinitionid;
		lot2.CopyCommonFieldUpdatePrev(array[0], systemTime, tid, text);
		lot2.CopyExtensionCollection(array[0]);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", LogInfoTrackInOutLotListBulk(array));
		}
		if (array2.Length != 0)
		{
			_ = array2[0].Producedmaterialid;
			if (!PRODUCEDMATERIAL.ValidateAllowHoldProducedMaterialBulk(dbContext, text, apiVersion, array2))
			{
				throw new EntityIsHoldException(objectName: EntityHelper.ConcatString4InClause((from p in array2.Where((Producedmaterial v) => v.Ishold == "Y").ToArray()
					select p.Producedmaterialid into id
					orderby id
					select id).ToArray()), paramType: typeof(Producedmaterial));
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", LogInfoTrackInOutProducedMaterialBulk(array2));
			}
			PRODUCEDMATERIAL.UpdateUserColumnsFromLot(text, lot2, array2[0]);
			lot2.CopyCommonFieldUpdatePrev(array2[0], systemTime, tid, text);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", LogInfoTrackInOutProducedMaterialBulk(array2));
			}
		}
		bool needAdhocProcess = false;
		Lotadhocprocess lotAdhocProcess = null;
		bool needFinishLot = false;
		bool needFutureAction = false;
		if (flag3)
		{
			string processingstate = array[0].Processingstate;
			string processsegmentruleid = array[0].Processsegmentruleid;
			int? rulesequence = array[0].Rulesequence;
			array[0].Processingstate = "WaitForSegment";
			array[0].Processsegmentruleid = null;
			array[0].Rulesequence = null;
			num += ContextManager.UpsertOnlyHistBulkQuery(dbContext, array);
			array[0].Processingstate = processingstate;
			array[0].Processsegmentruleid = processsegmentruleid;
			array[0].Rulesequence = rulesequence;
		}
		if (num2)
		{
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Dispatch PRE", LogInfoProcessChangeLotBulk(array));
			}
			DispatchWorkLotPRE(dbContext, array[0], array2, systemTime, out needAdhocProcess, out lotAdhocProcess, out needFinishLot, out needFutureAction);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Dispatch PRE", LogInfoProcessChangeLotBulk(array));
			}
		}
		num += ContextManager.BulkUpdateEntityFullColumn(dbContext, array[0], array, bulkColumnList, saveHist);
		if (array2.Length != 0)
		{
			num += ContextManager.BulkUpdateEntityFullColumn(dbContext, array2[0], array2, bulkColumnList, saveHist);
		}
		if (flag4)
		{
			LOTTRACKING.TrackoutLotTrackingBulk(dbContext, lot, array, optionSet);
		}
		if (num2)
		{
			DispatchWorkLotPOSTBulk(dbContext, array, needFinishLot, saveHistFinishLot, customActivityFinishLot, modifyTimeFinishLot);
		}
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int TransferLot(IDbContext dbContext, Lot sourceLot, Lot destLot, Producedmaterial[] destProducedMaterialList, TransferLotOptionSet transferLotOptionSet, bool saveHistSource, bool saveHistDest)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("sourceLot", sourceLot);
		ParamChecker.ArgumentNotNull("destLot", destLot);
		ParamChecker.ArgumentNotNullAndHasElement("destProducedMaterialList", destProducedMaterialList);
		string text = "TransferLot";
		string tid = dbContext.Tid;
		int apiVersion = 1;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		string lotid = sourceLot.Lotid;
		string lotid2 = destLot.Lotid;
		string siteid = sourceLot.Siteid;
		bool flag = transferLotOptionSet?.TerminateSourceQtyZero ?? false;
		Lot lot;
		if ((lot = SelectLot4Update(dbContext, lotid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Lot), lotid);
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", lot);
		}
		Producedmaterial[] array = PRODUCEDMATERIAL.SelectProducedMaterialList4Update(dbContext, destProducedMaterialList, siteid).ToArray();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", $"Lotid={lotid} ProducedMaterial Count={array.Length}");
		}
		Lot lot2;
		if ((lot2 = SelectLot4Update(dbContext, lotid2, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Lot), lotid2);
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "Select4Update", lot2);
		}
		if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot))
		{
			throw new EntityIsHoldException(typeof(Lot), lotid);
		}
		if (!ValidateAllowHoldLot(dbContext, text, apiVersion, lot2))
		{
			throw new EntityIsHoldException(typeof(Lot), lotid2);
		}
		string[] countableProducedMaterialGradeIdList = getCountableProducedMaterialGradeIdList(dbContext, sourceLot.Siteid);
		string[] countableSubproducedMaterialGradeIdList = getCountableSubproducedMaterialGradeIdList(dbContext, sourceLot.Siteid);
		decimal lotQty = GetLotQty(dbContext, countableProducedMaterialGradeIdList, array.ToArray());
		decimal subProducedMaterialQty = GetSubProducedMaterialQty(dbContext, countableSubproducedMaterialGradeIdList, array.ToArray());
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "CalcQty", $"Lotid={lot.Lotid} Change Qty={lotQty} Submaterialqty={subProducedMaterialQty}");
		}
		lot.Prevqty = lot.Qty;
		lot.Qty = lot.Qty.Add(-lotQty);
		lot.Prevsubmaterialqty = lot.Submaterialqty;
		lot.Submaterialqty = lot.Submaterialqty.Add(-subProducedMaterialQty);
		decimal? qty = lot.Qty;
		if ((qty.GetValueOrDefault() < default(decimal)) & qty.HasValue)
		{
			throw new QuantityInvalidException(lotid, lot.Qty);
		}
		qty = lot.Qty;
		if (((qty.GetValueOrDefault() == default(decimal)) & qty.HasValue) && flag)
		{
			lot.Prevstate = lot.State;
			lot.State = "Terminated";
		}
		sourceLot.CopyCommonFieldUpdatePrev(lot, systemTime, tid, text);
		sourceLot.CopyExtensionCollection(lot);
		list.Add(lot);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", lot);
		}
		foreach (Producedmaterial producedmaterial in destProducedMaterialList)
		{
			string producedmaterialid = producedmaterial.Producedmaterialid;
			ParamChecker.ArgumentNotNull("destProducedMaterialId", producedmaterialid);
			Producedmaterial producedmaterial2 = PRODUCEDMATERIAL.FindProducedMaterial(array, producedmaterialid);
			if (producedmaterial2 == null)
			{
				throw new EntityNotFoundException(typeof(Producedmaterial), producedmaterialid);
			}
			if (!PRODUCEDMATERIAL.ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, producedmaterial2))
			{
				throw new EntityIsHoldException(typeof(Producedmaterial), producedmaterialid);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", $"Producedmaterialid={producedmaterial2.Producedmaterialid} Prevlotid={producedmaterial2.Prevlotid} Lotid={producedmaterial2.Lotid} Slotno={producedmaterial2.Slotno} Carrierid={producedmaterial2.Carrierid}");
			}
			producedmaterial2.Prevlotid = producedmaterial2.Lotid;
			producedmaterial2.Lotid = lotid2;
			producedmaterial2.Prevslotno = producedmaterial2.Slotno;
			producedmaterial2.Slotno = producedmaterial.Slotno;
			producedmaterial2.Prevcarrierid = producedmaterial2.Carrierid;
			producedmaterial2.Carrierid = producedmaterial.Carrierid;
			producedmaterial.CopyCommonFieldUpdatePrev(producedmaterial2, systemTime, tid, text);
			producedmaterial.CopyExtensionCollection(producedmaterial2);
			list2.Add(producedmaterial2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={producedmaterial2.Producedmaterialid} Prevlotid={producedmaterial2.Prevlotid} Lotid={producedmaterial2.Lotid} Slotno={producedmaterial2.Slotno} Carrierid={producedmaterial2.Carrierid}");
			}
		}
		lot2.Prevqty = lot2.Qty;
		lot2.Qty = lot2.Qty.Add(lotQty);
		lot2.Prevsubmaterialqty = lot2.Submaterialqty;
		lot2.Submaterialqty = lot2.Submaterialqty.Add(subProducedMaterialQty);
		destLot.CopyCommonFieldUpdatePrev(lot2, systemTime, tid, text);
		destLot.CopyExtensionCollection(lot2);
		list.Add(lot2);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", lot2);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHistDest);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHistDest);
		if (lot.State == "Terminated")
		{
			List<Carrier> list3 = new List<Carrier>();
			List<Lotcarrierrel> list4 = new List<Lotcarrierrel>();
			Lotcarrierrel[] array2 = LOTCARRIERREL.GetLotCarrierRelList(dbContext, lotid, siteid).ToArray();
			string[] distinctCarrierList = LOTCARRIERREL.GetDistinctCarrierList(array2);
			foreach (string carrierid in distinctCarrierList)
			{
				Carrier carrier = CARRIER.SelectCarrier4Update(dbContext, carrierid, siteid);
				sourceLot.CopyCommonFieldUpdatePrev(carrier, systemTime, tid, text);
				list3.Add(carrier);
			}
			Lotcarrierrel[] array3 = array2;
			foreach (Lotcarrierrel lotcarrierrel in array3)
			{
				sourceLot.CopyCommonFieldUpdatePrev(lotcarrierrel, systemTime, tid, text);
				list4.Add(lotcarrierrel);
			}
			num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list3.ToArray(), saveHistSource);
			num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list4.ToArray(), saveHistSource);
		}
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int UseDurable(IDbContext dbContext, Lot lot, Lotdurablerel[] lotdurablerelList, IOptionSet optionSet, bool saveLotHist, bool saveDurableHist, bool saveLotDurableRelHist)
	{
		string apiName = "UseDurable";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(apiName));
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("lot", lot);
		ParamChecker.ArgumentNotNull("lotdurablerelList", lotdurablerelList);
		ParamChecker.ArgumentNotNull("Siteid", lot.Siteid);
		int num = 0;
		List<Lot> list = new List<Lot>();
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		ParamChecker.ArgumentNotNull("Lotid", lot.Lotid);
		string lotid = lot.Lotid;
		int repeatcount = 0;
		string siteid = lot.Siteid;
		Lot lot2 = SelectLot(dbContext, lotid, siteid);
		if (lot2 == null)
		{
			throw new EntityNotFoundException(typeof(Lot), lotid);
		}
		string processnodeid = lot2.Processnodeid;
		string processsegmentid = lot2.Processsegmentid;
		if (lot2.Repeatcount.HasValue)
		{
			repeatcount = lot2.Repeatcount.Value;
		}
		lot2.Prevactivity = lot2.Activity;
		lot2.Activity = "UseDurable";
		lot2.Prevcustomactivity = lot2.Customactivity;
		lot.CopyExtensionCollection(lot2);
		lot.CopyCommonField(lot2, systemTime, dbContext.Tid, isCreate: false);
		lot2.Customactivity = EntityHelper.FirstNotNull<string>(lot.Customactivity, lot2.Activity);
		list.Add(lot2);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveLotHist);
		foreach (Lotdurablerel lotdurablerel in lotdurablerelList)
		{
			List<Lotdurablerel> list2 = new List<Lotdurablerel>();
			List<Durable> list3 = new List<Durable>();
			ParamChecker.ArgumentNotNull("Durableid", lotdurablerel.Durableid);
			ParamChecker.ArgumentNotNull("Repeatcount", lotdurablerel.Repeatcount);
			string durableid = lotdurablerel.Durableid;
			Durable durable = null;
			if ((durable = DURABLE.SelectDurable(dbContext, durableid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Durable), durableid);
			}
			ParamChecker.EntityUsable(typeof(Durable), durableid, durable.Isusable);
			Lotdurablerel lotdurablerel2 = new Lotdurablerel();
			lotdurablerel.CopyColumsTo(lotdurablerel2);
			lotdurablerel2.Lotid = lotid;
			lotdurablerel2.Processnodeid = processnodeid;
			lotdurablerel2.Repeatcount = repeatcount;
			lotdurablerel2.Processsegmentid = processsegmentid;
			lotdurablerel2.Processdefinitionid = lot2.Processdefinitionid;
			lotdurablerel2.Productdefinitionid = lot2.Productdefinitionid;
			lotdurablerel2.Equipmentid = lot2.Equipmentid;
			lotdurablerel2.Location = lot2.Location;
			lotdurablerel2.Prevactivity = null;
			lotdurablerel2.Activity = "UseDurable";
			lotdurablerel2.Isusable = "Usable";
			lotdurablerel2.Siteid = siteid;
			lot.CopyCommonField(lotdurablerel2, systemTime, dbContext.Tid, isCreate: true);
			lotdurablerel2.Customactivity = EntityHelper.FirstNotNull<string>(lot.Customactivity, lotdurablerel2.Activity);
			list2.Add(lotdurablerel2);
			durable.Prevactivity = durable.Activity;
			durable.Activity = "UseDurable";
			durable.Prevcustomactivity = durable.Customactivity;
			if (durable.Usagetype.Equals("COUNT") && lotdurablerel2.Durableuseqty.HasValue)
			{
				durable.Usagecount += Convert.ToInt32(lotdurablerel2.Durableuseqty);
			}
			lot.CopyCommonField(durable, systemTime, dbContext.Tid, isCreate: false);
			durable.Customactivity = EntityHelper.FirstNotNull<string>(lot.Customactivity, durable.Activity);
			list3.Add(durable);
			num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list2.ToArray(), saveLotDurableRelHist);
			num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list3.ToArray(), saveDurableHist);
		}
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(apiName));
		return num;
	}

	public static bool ValidateAllowHoldLot(IDbContext dbContext, string apiId, int apiVersion, Lot lot)
	{
		string ishold = lot.Ishold;
		string siteid = lot.Siteid;
		if (ishold != "Y")
		{
			return true;
		}
		return CIM.MES.API.CDS.API.CheckAllowHoldLot(dbContext, apiId, apiVersion, siteid);
	}

	public static bool ValidateAllowHoldLotBulk(IDbContext dbContext, string apiId, int apiVersion, Lot[] lotList)
	{
		string siteid = lotList[0].Siteid;
		if (lotList.Where((Lot v) => v.Ishold == "Y").ToArray().Length == 0)
		{
			return true;
		}
		return CIM.MES.API.CDS.API.CheckAllowHoldLot(dbContext, apiId, apiVersion, siteid);
	}
}
