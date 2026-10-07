using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CIM.MES.API.CDS;
using CIM.MES.API.PMS;
using CIM.MES.API.PPS;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.POS;

[MESAPI]
public class PRODUCEDMATERIAL
{
	private static string _sqlGetProducedMaterialSqlDatabase = "SELECT * FROM CIM_PRODUCEDMATERIAL WHERE PRODUCEDMATERIALID=@PRODUCEDMATERIALID AND SITEID=@SITEID";

	private static string _sqlGetProducedMaterial4UpdateSqlDatabase = "SELECT * FROM CIM_PRODUCEDMATERIAL WITH(UPDLOCK) WHERE PRODUCEDMATERIALID=@PRODUCEDMATERIALID AND SITEID=@SITEID";

	private static string _sqlSelectProducedMaterialSqlDatabase = "SELECT * FROM CIM_PRODUCEDMATERIAL WHERE PRODUCEDMATERIALID=@PRODUCEDMATERIALID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProducedMaterial4UpdateSqlDatabase = "SELECT * FROM CIM_PRODUCEDMATERIAL WITH(UPDLOCK) WHERE PRODUCEDMATERIALID=@PRODUCEDMATERIALID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetProducedMaterialOracleDatabase = "SELECT * FROM CIM_PRODUCEDMATERIAL WHERE PRODUCEDMATERIALID=:PRODUCEDMATERIALID AND SITEID=:SITEID";

	private static string _sqlGetProducedMaterial4UpdateOracleDatabase = "SELECT * FROM CIM_PRODUCEDMATERIAL WHERE PRODUCEDMATERIALID=:PRODUCEDMATERIALID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectProducedMaterialOracleDatabase = "SELECT * FROM CIM_PRODUCEDMATERIAL WHERE PRODUCEDMATERIALID=:PRODUCEDMATERIALID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProducedMaterial4UpdateOracleDatabase = "SELECT * FROM CIM_PRODUCEDMATERIAL WHERE PRODUCEDMATERIALID=:PRODUCEDMATERIALID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Producedmaterial);

	private static string _sqlSelectProducedMaterialListSqlDatabase = "SELECT * FROM CIM_PRODUCEDMATERIAL WHERE PRODUCEDMATERIALID IN (&PRODUCEDMATERIALIDLIST) AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProducedMaterialList4UpdateSqlDatabase = "SELECT * FROM CIM_PRODUCEDMATERIAL WITH(UPDLOCK) WHERE PRODUCEDMATERIALID IN (&PRODUCEDMATERIALIDLIST) AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProducedMaterialListOracleDatabase = "SELECT * FROM CIM_PRODUCEDMATERIAL WHERE PRODUCEDMATERIALID IN (&PRODUCEDMATERIALIDLIST) AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProducedMaterialList4UpdateOracleDatabase = "SELECT * FROM CIM_PRODUCEDMATERIAL WHERE PRODUCEDMATERIALID IN (&PRODUCEDMATERIALIDLIST) AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static string _sqlSelectProducedMaterialListByLotWithNotStateSqlDatabase = "SELECT * FROM CIM_PRODUCEDMATERIAL WHERE PRODUCEDMATERIALID IN (SELECT PRODUCEDMATERIALID FROM CIM_PRODUCEDMATERIAL WHERE LOTID=@LOTID AND SITEID=@SITEID AND ISUSABLE='Usable') AND SITEID=@SITEID AND STATE NOT IN (&STATE) AND ISUSABLE='Usable'";

	private static string _sqlSelectProducedMaterialListByLotWithNotState4UpdateSqlDatabase = "SELECT * FROM CIM_PRODUCEDMATERIAL WITH(UPDLOCK) WHERE PRODUCEDMATERIALID IN (SELECT PRODUCEDMATERIALID FROM CIM_PRODUCEDMATERIAL WHERE LOTID=@LOTID AND SITEID=@SITEID AND ISUSABLE='Usable') AND SITEID=@SITEID AND STATE NOT IN (&STATE) AND ISUSABLE='Usable'";

	private static string _sqlSelectProducedMaterialListByLotWithNotStateOracleDatabase = "SELECT * FROM CIM_PRODUCEDMATERIAL WHERE PRODUCEDMATERIALID IN (SELECT PRODUCEDMATERIALID FROM CIM_PRODUCEDMATERIAL WHERE LOTID=:LOTID AND SITEID=:SITEID AND ISUSABLE='Usable') AND SITEID=:SITEID AND STATE NOT IN (&STATE) AND ISUSABLE='Usable' ORDER BY PRODUCEDMATERIALID, SITEID";

	private static string _sqlSelectProducedMaterialListByLotWithNotState4UpdateOracleDatabase = "SELECT * FROM CIM_PRODUCEDMATERIAL WHERE PRODUCEDMATERIALID IN (SELECT PRODUCEDMATERIALID FROM CIM_PRODUCEDMATERIAL WHERE LOTID=:LOTID AND SITEID=:SITEID AND ISUSABLE='Usable') AND SITEID=:SITEID AND STATE NOT IN (&STATE) AND ISUSABLE='Usable' FOR UPDATE";

	private static string _sqlSelectProducedMaterialListByLotWithNotState4BulkUpdateSqlDatabase = "SELECT * FROM CIM_PRODUCEDMATERIAL WITH(UPDLOCK) WHERE PRODUCEDMATERIALID IN (SELECT PRODUCEDMATERIALID FROM CIM_PRODUCEDMATERIAL WHERE LOTID IN (&LOTID) AND SITEID=&SITEID AND ISUSABLE='Usable') AND SITEID=&SITEID AND STATE NOT IN (&STATE) AND ISUSABLE='Usable'";

	private static string _sqlSelectProducedMaterialListByLotWithNotState4BulkUpdateOracleDatabase = "SELECT * FROM CIM_PRODUCEDMATERIAL WHERE PRODUCEDMATERIALID IN (SELECT PRODUCEDMATERIALID FROM CIM_PRODUCEDMATERIAL WHERE LOTID IN (&LOTID) AND SITEID=&SITEID AND ISUSABLE='Usable') AND SITEID=&SITEID AND STATE NOT IN (&STATE) AND ISUSABLE='Usable' FOR UPDATE";

	private static string _sqlSelectProducedMaterialListByLotWithStateSqlDatabase = "SELECT * FROM CIM_PRODUCEDMATERIAL WHERE PRODUCEDMATERIALID IN (SELECT PRODUCEDMATERIALID FROM CIM_PRODUCEDMATERIAL WHERE LOTID=@LOTID AND SITEID=@SITEID AND ISUSABLE='Usable') AND SITEID=@SITEID AND STATE IN (&STATE) AND ISUSABLE='Usable'";

	private static string _sqlSelectProducedMaterialListByLotWithState4UpdateSqlDatabase = "SELECT * FROM CIM_PRODUCEDMATERIAL WITH(UPDLOCK) WHERE PRODUCEDMATERIALID IN (SELECT PRODUCEDMATERIALID FROM CIM_PRODUCEDMATERIAL WHERE LOTID=@LOTID AND SITEID=@SITEID AND ISUSABLE='Usable') AND SITEID=@SITEID AND STATE IN (&STATE) AND ISUSABLE='Usable'";

	private static string _sqlSelectProducedMaterialListByLotWithStateOracleDatabase = "SELECT * FROM CIM_PRODUCEDMATERIAL WHERE PRODUCEDMATERIALID IN (SELECT PRODUCEDMATERIALID FROM CIM_PRODUCEDMATERIAL WHERE LOTID=:LOTID AND SITEID=:SITEID AND ISUSABLE='Usable') AND SITEID=:SITEID AND STATE IN (&STATE) AND ISUSABLE='Usable'";

	private static string _sqlSelectProducedMaterialListByLotWithState4UpdateOracleDatabase = "SELECT * FROM CIM_PRODUCEDMATERIAL WHERE PRODUCEDMATERIALID IN (SELECT PRODUCEDMATERIALID FROM CIM_PRODUCEDMATERIAL WHERE LOTID=:LOTID AND SITEID=:SITEID AND ISUSABLE='Usable') AND SITEID=:SITEID AND STATE IN (&STATE) AND ISUSABLE='Usable' FOR UPDATE";

	private static string _sqlSelectProducedMaterialListWithNotStateSqlDatabase = "SELECT * FROM CIM_PRODUCEDMATERIAL WHERE PRODUCEDMATERIALID IN (&PRODUCEDMATERIALIDLIST) AND SITEID=@SITEID AND STATE NOT IN (&STATE) AND ISUSABLE='Usable'";

	private static string _sqlSelectProducedMaterialListWithNotState4UpdateSqlDatabase = "SELECT * FROM CIM_PRODUCEDMATERIAL WITH(UPDLOCK) WHERE PRODUCEDMATERIALID IN (&PRODUCEDMATERIALIDLIST) AND SITEID=@SITEID AND STATE NOT IN (&STATE) AND ISUSABLE='Usable'";

	private static string _sqlSelectProducedMaterialListWithNotStateOracleDatabase = "SELECT * FROM CIM_PRODUCEDMATERIAL WHERE PRODUCEDMATERIALID IN (&PRODUCEDMATERIALIDLIST) AND SITEID=:SITEID AND STATE NOT IN (&STATE) AND ISUSABLE='Usable'";

	private static string _sqlSelectProducedMaterialListWithNotState4UpdateOracleDatabase = "SELECT * FROM CIM_PRODUCEDMATERIAL WHERE PRODUCEDMATERIALID IN (&PRODUCEDMATERIALIDLIST) AND SITEID=:SITEID AND STATE NOT IN (&STATE) AND ISUSABLE='Usable' FOR UPDATE";

	private static string _sqlSelectProducedMaterialListWithStateSqlDatabase = "SELECT * FROM CIM_PRODUCEDMATERIAL WHERE PRODUCEDMATERIALID IN (&PRODUCEDMATERIALIDLIST) AND SITEID=@SITEID AND STATE IN (&STATE) AND ISUSABLE='Usable'";

	private static string _sqlSelectProducedMaterialListWithState4UpdateSqlDatabase = "SELECT * FROM CIM_PRODUCEDMATERIAL WITH(UPDLOCK) WHERE PRODUCEDMATERIALID IN (&PRODUCEDMATERIALIDLIST) AND SITEID=@SITEID AND STATE IN (&STATE) AND ISUSABLE='Usable'";

	private static string _sqlSelectProducedMaterialListWithStateOracleDatabase = "SELECT * FROM CIM_PRODUCEDMATERIAL WHERE PRODUCEDMATERIALID IN (&PRODUCEDMATERIALIDLIST) AND SITEID=:SITEID AND STATE IN (&STATE) AND ISUSABLE='Usable'";

	private static string _sqlSelectProducedMaterialListWithState4UpdateOracleDatabase = "SELECT * FROM CIM_PRODUCEDMATERIAL WHERE PRODUCEDMATERIALID IN (&PRODUCEDMATERIALIDLIST) AND SITEID=:SITEID AND STATE IN (&STATE) AND ISUSABLE='Usable' FOR UPDATE";

	public static int AssignCarrierProducedMaterial(IDbContext dbContext, Producedmaterial[] producedMaterialList, Carrier carrier, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("producedMaterialList", producedMaterialList);
		ParamChecker.ArgumentNotNull("carrier", carrier);
		string text = "AssignCarrierProducedMaterial";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		int num = 0;
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		List<Producedmaterial> list = new List<Producedmaterial>();
		List<Carrier> list2 = new List<Carrier>();
		_ = producedMaterialList[0].Lotid;
		string siteid = producedMaterialList[0].Siteid;
		Carrier carrier2 = null;
		if (GetCountCarrierId(producedMaterialList) != 1)
		{
			throw new ProducedMaterialNotInSameCarrierException();
		}
		Producedmaterial[] producedmaterialList = SelectProducedMaterialList4Update(dbContext, producedMaterialList, siteid).ToArray();
		if ((carrier2 = CARRIER.SelectCarrier4Update(dbContext, carrier.Carrierid, carrier.Siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Carrier), carrier.Carrierid);
		}
		foreach (Producedmaterial producedmaterial in producedMaterialList)
		{
			ParamChecker.ArgumentNotNull("Producedmaterialid", producedmaterial.Producedmaterialid);
			ParamChecker.ArgumentNotNull("Siteid", producedmaterial.Siteid);
			ParamChecker.ArgumentNotNull("Carrierid", producedmaterial.Carrierid);
			ParamChecker.ArgumentNotNull("Slotno", producedmaterial.Slotno);
			Producedmaterial producedmaterial2 = null;
			if ((producedmaterial2 = FindProducedMaterial(producedmaterialList, producedmaterial.Producedmaterialid)) == null)
			{
				throw new EntityNotFoundException(typeof(Producedmaterial), producedmaterial.Producedmaterialid);
			}
			if (!ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, producedmaterial2))
			{
				throw new EntityIsHoldException(typeof(Producedmaterial), producedmaterial.Producedmaterialid);
			}
			if (!string.IsNullOrEmpty(producedmaterial2.Carrierid))
			{
				throw new ProducedMaterialAlreadyAssignedToCarrier(producedmaterial2.Producedmaterialid, producedmaterial2.Carrierid);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", $"Producedmaterialid={producedmaterial2.Producedmaterialid} Prevcarrierid={producedmaterial2.Prevcarrierid} Carrierid={producedmaterial2.Carrierid} Prevslotno={producedmaterial2.Prevslotno} Slotno={producedmaterial2.Slotno}");
			}
			producedmaterial2.Carrierid = carrier.Carrierid;
			producedmaterial2.Slotno = producedmaterial.Slotno;
			producedmaterial.CopyCommonFieldUpdatePrev(producedmaterial2, systemTime, tid, text);
			producedmaterial.CopyExtensionCollection(producedmaterial2);
			list.Add(producedmaterial2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={producedmaterial2.Producedmaterialid} Prevcarrierid={producedmaterial2.Prevcarrierid} Carrierid={producedmaterial2.Carrierid} Prevslotno={producedmaterial2.Prevslotno} Slotno={producedmaterial2.Slotno}");
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", carrier2);
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
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", carrier2);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int CancelScrapProducedMaterial(IDbContext dbContext, Producedmaterial[] producedMaterialList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("producedMaterialList", producedMaterialList);
		string text = "CancelScrapProducedMaterial";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		string lotid = producedMaterialList[0].Lotid;
		string siteid = producedMaterialList[0].Siteid;
		Lot lot = null;
		if (GetCountLotId(producedMaterialList) != 1)
		{
			throw new EmptyEntityException(typeof(Producedmaterial), "LOTID: " + lotid);
		}
		ParamChecker.ArgumentNotNull("Lotid", lotid);
		ParamChecker.ArgumentNotNull("Siteid", siteid);
		if ((lot = LOT.SelectLot4Update(dbContext, lotid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Lot), lotid);
		}
		Producedmaterial[] producedmaterialList = SelectProducedMaterialList4Update(dbContext, producedMaterialList, siteid).ToArray();
		string[] countableProducedMaterialGradeIdList = LOT.getCountableProducedMaterialGradeIdList(dbContext, siteid);
		string[] countableSubproducedMaterialGradeIdList = LOT.getCountableSubproducedMaterialGradeIdList(dbContext, siteid);
		foreach (Producedmaterial producedmaterial in producedMaterialList)
		{
			ParamChecker.ArgumentNotNull("Lotid", producedmaterial.Lotid);
			ParamChecker.ArgumentNotNull("Siteid", producedmaterial.Siteid);
			ParamChecker.ArgumentNotNull("Producedmaterialid", producedmaterial.Producedmaterialid);
			string producedmaterialid = producedmaterial.Producedmaterialid;
			Producedmaterial producedmaterial2 = null;
			if ((producedmaterial2 = FindProducedMaterial(producedmaterialList, producedmaterialid)) == null)
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
		decimal lotQty = LOT.GetLotQty(dbContext, countableProducedMaterialGradeIdList, list2.ToArray());
		decimal subProducedMaterialQty = LOT.GetSubProducedMaterialQty(dbContext, countableSubproducedMaterialGradeIdList, list2.ToArray());
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
		producedMaterialList[0].CopyCommonFieldUpdatePrev(lot, systemTime, tid, text);
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

	public static int ChangeGradeProducedMaterial(IDbContext dbContext, Producedmaterial[] inputProducedMaterialList, ChangeGradeProducedMaterialOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inputProducedMaterialList", inputProducedMaterialList);
		string text = "ChangeGradeProducedMaterial";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		int num = 0;
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		if (GetCountLotId(inputProducedMaterialList) != 1)
		{
			throw new ProducedMaterialNotInSameLotException();
		}
		Producedmaterial producedmaterial = inputProducedMaterialList[0];
		string lotid = producedmaterial.Lotid;
		string siteid = producedmaterial.Siteid;
		Lot lot;
		if ((lot = LOT.SelectLot4Update(dbContext, lotid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Lot), lotid);
		}
		Producedmaterial[] source = SelectProducedMaterialList4Update(dbContext, inputProducedMaterialList, siteid).ToArray();
		if (!LOT.ValidateAllowHoldLot(dbContext, text, apiVersion, lot))
		{
			throw new EntityIsHoldException(typeof(Lot), lotid);
		}
		string[] countableProducedMaterialGradeIdList = LOT.getCountableProducedMaterialGradeIdList(dbContext, siteid);
		string[] countableSubproducedMaterialGradeIdList = LOT.getCountableSubproducedMaterialGradeIdList(dbContext, siteid);
		decimal lotQty = LOT.GetLotQty(dbContext, countableProducedMaterialGradeIdList, source.ToArray());
		decimal subProducedMaterialQty = LOT.GetSubProducedMaterialQty(dbContext, countableSubproducedMaterialGradeIdList, source.ToArray());
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "CalcQty", $"Lotid={lot.Lotid} Minus Qty={lotQty} Submaterialqty={subProducedMaterialQty}");
		}
		foreach (Producedmaterial producedmaterial2 in inputProducedMaterialList)
		{
			string producedmaterialid = producedmaterial2.Producedmaterialid;
			ParamChecker.ArgumentNotNull("Producedmaterialid", producedmaterialid);
			Producedmaterial producedmaterial3;
			if ((producedmaterial3 = FindProducedMaterial(source.ToArray(), producedmaterialid)) == null)
			{
				throw new EntityNotFoundException(typeof(Producedmaterial), producedmaterialid);
			}
			if (!ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, producedmaterial3))
			{
				throw new EntityIsHoldException(typeof(Producedmaterial), producedmaterialid);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", producedmaterial3);
			}
			producedmaterial3.Prevgrade = producedmaterial3.Grade;
			producedmaterial3.Grade = producedmaterial2.Grade;
			producedmaterial3.Prevsubmaterialgrade = producedmaterial3.Submaterialgrade;
			producedmaterial3.Submaterialgrade = producedmaterial2.Submaterialgrade;
			producedmaterial3.Prevsubmaterialqty = producedmaterial3.Submaterialqty;
			producedmaterial3.Submaterialqty = GetSubProducedMaterialQty(dbContext, countableSubproducedMaterialGradeIdList, producedmaterial3);
			producedmaterial2.CopyCommonFieldUpdatePrev(producedmaterial3, systemTime, tid, text);
			producedmaterial2.CopyExtensionCollection(producedmaterial3);
			list2.Add(producedmaterial3);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", producedmaterial3);
			}
		}
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", lot);
		}
		decimal lotQty2 = LOT.GetLotQty(dbContext, countableProducedMaterialGradeIdList, source.ToArray());
		decimal subProducedMaterialQty2 = LOT.GetSubProducedMaterialQty(dbContext, countableSubproducedMaterialGradeIdList, source.ToArray());
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
		lot.Prevqty = lot.Qty;
		lot.Qty = lot.Qty.Add(num2);
		lot.Prevsubmaterialqty = lot.Submaterialqty;
		lot.Submaterialqty = lot.Submaterialqty.Add(num3);
		producedmaterial.CopyCommonFieldUpdatePrev(lot, systemTime, tid, text);
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

	public static int ChangeSlotProducedMaterial(IDbContext dbContext, Producedmaterial[] producedMaterialList, Carrier carrier, IOptionSet optionSet, bool saveHist)
	{
		string text = "ChangeSlotProducedMaterial";
		int apiVersion = 1;
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		int num = 0;
		ParamChecker.ArgumentNotNullAndHasElement("producedMaterialList", producedMaterialList);
		ParamChecker.ArgumentNotNull("carrier", carrier);
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		List<Producedmaterial> list = new List<Producedmaterial>();
		List<Carrier> list2 = new List<Carrier>();
		_ = producedMaterialList[0].Lotid;
		string siteid = producedMaterialList[0].Siteid;
		Carrier carrier2 = null;
		if (GetCountCarrierId(producedMaterialList) != 1)
		{
			throw new ProducedMaterialNotInSameCarrierException();
		}
		Producedmaterial[] producedmaterialList = SelectProducedMaterialList4Update(dbContext, producedMaterialList, siteid).ToArray();
		if ((carrier2 = CARRIER.SelectCarrier4Update(dbContext, carrier.Carrierid, carrier.Siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Carrier), carrier.Carrierid);
		}
		foreach (Producedmaterial producedmaterial in producedMaterialList)
		{
			ParamChecker.ArgumentNotNull("Producedmaterialid", producedmaterial.Producedmaterialid);
			ParamChecker.ArgumentNotNull("Siteid", producedmaterial.Siteid);
			ParamChecker.ArgumentNotNull("Carrierid", producedmaterial.Carrierid);
			ParamChecker.ArgumentNotNull("Slotno", producedmaterial.Slotno);
			Producedmaterial producedmaterial2 = null;
			if ((producedmaterial2 = FindProducedMaterial(producedmaterialList, producedmaterial.Producedmaterialid)) == null)
			{
				throw new EntityNotFoundException(typeof(Producedmaterial), producedmaterial.Producedmaterialid);
			}
			if (!ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, producedmaterial2))
			{
				throw new EntityIsHoldException(typeof(Producedmaterial), producedmaterial.Producedmaterialid);
			}
			if (string.IsNullOrEmpty(producedmaterial2.Carrierid))
			{
				throw new ProducedMaterialNotAssignedToCarrier(producedmaterial2.Producedmaterialid);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", $"Producedmaterialid={producedmaterial2.Producedmaterialid} Prevcarrierid={producedmaterial2.Prevcarrierid} Carrierid={producedmaterial2.Carrierid} Prevslotno={producedmaterial2.Prevslotno} Slotno={producedmaterial2.Slotno}");
			}
			producedmaterial2.Prevcarrierid = producedmaterial2.Carrierid;
			producedmaterial2.Carrierid = carrier.Carrierid;
			producedmaterial2.Prevslotno = producedmaterial2.Slotno;
			producedmaterial2.Slotno = producedmaterial.Slotno;
			producedmaterial.CopyCommonFieldUpdatePrev(producedmaterial2, systemTime, tid, text);
			producedmaterial.CopyExtensionCollection(producedmaterial2);
			list.Add(producedmaterial2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={producedmaterial2.Producedmaterialid} Prevcarrierid={producedmaterial2.Prevcarrierid} Carrierid={producedmaterial2.Carrierid} Prevslotno={producedmaterial2.Prevslotno} Slotno={producedmaterial2.Slotno}");
			}
		}
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", carrier2);
		}
		carrier.CopyCommonFieldUpdatePrev(carrier2, systemTime, tid, text);
		carrier.CopyExtensionCollection(carrier2);
		list2.Add(carrier2);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", carrier2);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int ConsumeProducedMaterial(IDbContext dbContext, Producedmaterial sourceProducedMaterial, Producedmaterial targetProducedMaterial, ConsumeProducedMaterialOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("sourceProducedMaterial", sourceProducedMaterial);
		ParamChecker.ArgumentNotNull("targetProducedMaterial", targetProducedMaterial);
		string text = "ConsumeProducedMaterial";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		int num = 0;
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		bool flag = optionSet?.TerminateLotQtyZero ?? false;
		string lotid = sourceProducedMaterial.Lotid;
		string siteid = sourceProducedMaterial.Siteid;
		Lot lot = null;
		Producedmaterial producedmaterial = null;
		Producedmaterial producedmaterial2 = null;
		if ((lot = LOT.SelectLot4Update(dbContext, lotid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Lot), lotid);
		}
		if ((producedmaterial = SelectProducedMaterial4Update(dbContext, sourceProducedMaterial.Producedmaterialid, sourceProducedMaterial.Siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Producedmaterial), sourceProducedMaterial.Producedmaterialid);
		}
		if ((producedmaterial2 = SelectProducedMaterial4Update(dbContext, targetProducedMaterial.Producedmaterialid, targetProducedMaterial.Siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Producedmaterial), targetProducedMaterial.Producedmaterialid);
		}
		if (!LOT.ValidateAllowHoldLot(dbContext, text, apiVersion, lot))
		{
			throw new EntityIsHoldException(typeof(Lot), lotid);
		}
		if (!ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, producedmaterial))
		{
			throw new EntityIsHoldException(typeof(Producedmaterial), producedmaterial.Producedmaterialid);
		}
		if (!ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, producedmaterial2))
		{
			throw new EntityIsHoldException(typeof(Producedmaterial), producedmaterial2.Producedmaterialid);
		}
		string[] countableProducedMaterialGradeIdList = LOT.getCountableProducedMaterialGradeIdList(dbContext, sourceProducedMaterial.Siteid);
		string[] countableSubproducedMaterialGradeIdList = LOT.getCountableSubproducedMaterialGradeIdList(dbContext, sourceProducedMaterial.Siteid);
		decimal lotQty = LOT.GetLotQty(dbContext, countableProducedMaterialGradeIdList, new Producedmaterial[1] { producedmaterial });
		decimal subProducedMaterialQty = LOT.GetSubProducedMaterialQty(dbContext, countableSubproducedMaterialGradeIdList, new Producedmaterial[1] { producedmaterial });
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "CalcQty", $"Lotid={lot.Lotid} Change Qty={lotQty} Submaterialqty={subProducedMaterialQty}");
		}
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", lot);
		}
		lot.Prevqty = lot.Qty;
		lot.Qty = lot.Qty.Add(-lotQty);
		lot.Prevsubmaterialqty = lot.Submaterialqty;
		lot.Submaterialqty = lot.Submaterialqty.Add(-subProducedMaterialQty);
		decimal? qty = lot.Qty;
		if (((qty.GetValueOrDefault() == default(decimal)) & qty.HasValue) && flag)
		{
			lot.Prevstate = lot.State;
			lot.State = "Terminated";
		}
		sourceProducedMaterial.CopyCommonFieldUpdatePrev(lot, systemTime, tid, text);
		list.Add(lot);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", lot);
		}
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", $"Producedmaterialid={producedmaterial.Producedmaterialid} Prevcarrierid={producedmaterial.Prevcarrierid} Carrierid={producedmaterial.Carrierid} Prevslotno={producedmaterial.Prevslotno} Slotno={producedmaterial.Slotno}");
		}
		producedmaterial.Prevstate = sourceProducedMaterial.State;
		producedmaterial.State = "Terminated";
		producedmaterial.Prevslotno = producedmaterial.Slotno;
		producedmaterial.Slotno = 0;
		producedmaterial.Prevcarrierid = producedmaterial.Carrierid;
		producedmaterial.Carrierid = null;
		sourceProducedMaterial.CopyCommonFieldUpdatePrev(producedmaterial, systemTime, tid, text);
		sourceProducedMaterial.CopyExtensionCollection(producedmaterial);
		list2.Add(producedmaterial);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={producedmaterial.Producedmaterialid} Prevcarrierid={producedmaterial.Prevcarrierid} Carrierid={producedmaterial.Carrierid} Prevslotno={producedmaterial.Prevslotno} Slotno={producedmaterial.Slotno}");
		}
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", $"Producedmaterialid={producedmaterial2.Producedmaterialid} Prevcarrierid={producedmaterial2.Prevcarrierid} Carrierid={producedmaterial2.Carrierid} Prevslotno={producedmaterial2.Prevslotno} Slotno={producedmaterial2.Slotno}");
		}
		targetProducedMaterial.CopyCommonFieldUpdatePrev(producedmaterial2, systemTime, tid, text);
		targetProducedMaterial.CopyExtensionCollection(producedmaterial2);
		list2.Add(producedmaterial2);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={producedmaterial2.Producedmaterialid} Prevcarrierid={producedmaterial2.Prevcarrierid} Carrierid={producedmaterial2.Carrierid} Prevslotno={producedmaterial2.Prevslotno} Slotno={producedmaterial2.Slotno}");
		}
		List<Carrier> list3 = new List<Carrier>();
		List<Lotcarrierrel> list4 = new List<Lotcarrierrel>();
		if (lot.State == "Terminated")
		{
			Lotcarrierrel[] array = LOTCARRIERREL.GetLotCarrierRelList(dbContext, lotid, siteid).ToArray();
			string[] distinctCarrierList = LOTCARRIERREL.GetDistinctCarrierList(array);
			foreach (string carrierid in distinctCarrierList)
			{
				Carrier carrier = CARRIER.SelectCarrier4Update(dbContext, carrierid, siteid);
				if (MesLogger.IsDebugEnabled("API"))
				{
					MesLogger.DebugTidApi(tid, "Before Execute", carrier);
				}
				sourceProducedMaterial.CopyCommonFieldUpdatePrev(carrier, systemTime, tid, text);
				list3.Add(carrier);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Execute", carrier);
				}
			}
			Lotcarrierrel[] array2 = array;
			foreach (Lotcarrierrel lotcarrierrel in array2)
			{
				if (MesLogger.IsDebugEnabled("API"))
				{
					MesLogger.DebugTidApi(tid, "Before Execute", lotcarrierrel);
				}
				sourceProducedMaterial.CopyCommonFieldUpdatePrev(lotcarrierrel, systemTime, tid, text);
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
		return num + ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list4.ToArray(), saveHist);
	}

	public static int ConvertProducedMaterialToLot(IDbContext dbContext, Producedmaterial[] producedMaterialList, Lot lot, ConvertProducedMaterialToLotOptionSet convertProducedMaterialToLotOptionSet, bool saveLotHist, bool saveProducedMaterialHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("producedMaterialList", producedMaterialList);
		ParamChecker.ArgumentNotNull("lot", lot);
		string text = "ConvertProducedMaterialToLot";
		int apiVersion = 1;
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		string tid = dbContext.Tid;
		int num = 0;
		List<Producedmaterial> list = new List<Producedmaterial>();
		List<Lot> list2 = new List<Lot>();
		List<Lot> list3 = new List<Lot>();
		int num2;
		if (convertProducedMaterialToLotOptionSet != null)
		{
			_ = convertProducedMaterialToLotOptionSet.ValidateDuplication;
			if (0 == 0)
			{
				num2 = (convertProducedMaterialToLotOptionSet.ValidateDuplication ? 1 : 0);
				goto IL_0082;
			}
		}
		num2 = 0;
		goto IL_0082;
		IL_013f:
		int num3;
		bool flag = (byte)num3 != 0;
		int num4;
		if (convertProducedMaterialToLotOptionSet != null)
		{
			_ = convertProducedMaterialToLotOptionSet.AdjustLastProducedMaterial;
			if (0 == 0)
			{
				num4 = (convertProducedMaterialToLotOptionSet.AdjustLastProducedMaterial ? 1 : 0);
				goto IL_015a;
			}
		}
		num4 = 0;
		goto IL_015a;
		IL_00d3:
		int num5;
		bool flag2 = (byte)num5 != 0;
		int num6;
		if (convertProducedMaterialToLotOptionSet != null)
		{
			_ = convertProducedMaterialToLotOptionSet.ValidateDuplicationByLocation;
			if (0 == 0)
			{
				num6 = (convertProducedMaterialToLotOptionSet.ValidateDuplicationByLocation ? 1 : 0);
				goto IL_00ee;
			}
		}
		num6 = 0;
		goto IL_00ee;
		IL_009d:
		int num7;
		bool flag3 = (byte)num7 != 0;
		int num8;
		if (convertProducedMaterialToLotOptionSet != null)
		{
			_ = convertProducedMaterialToLotOptionSet.ValidateDuplicationByProcessNodeId;
			if (0 == 0)
			{
				num8 = (convertProducedMaterialToLotOptionSet.ValidateDuplicationByProcessNodeId ? 1 : 0);
				goto IL_00b8;
			}
		}
		num8 = 0;
		goto IL_00b8;
		IL_0082:
		bool flag4 = (byte)num2 != 0;
		if (convertProducedMaterialToLotOptionSet != null)
		{
			_ = convertProducedMaterialToLotOptionSet.ValidateDuplicationByProcessSegmentId;
			if (0 == 0)
			{
				num7 = (convertProducedMaterialToLotOptionSet.ValidateDuplicationByProcessSegmentId ? 1 : 0);
				goto IL_009d;
			}
		}
		num7 = 0;
		goto IL_009d;
		IL_00b8:
		bool flag5 = (byte)num8 != 0;
		if (convertProducedMaterialToLotOptionSet != null)
		{
			_ = convertProducedMaterialToLotOptionSet.ValidateDuplicationByProcessDefinitionId;
			if (0 == 0)
			{
				num5 = (convertProducedMaterialToLotOptionSet.ValidateDuplicationByProcessDefinitionId ? 1 : 0);
				goto IL_00d3;
			}
		}
		num5 = 0;
		goto IL_00d3;
		IL_015a:
		bool flag6 = (byte)num4 != 0;
		string siteid = producedMaterialList[0].Siteid;
		Producedmaterial[] producedmaterialList = SelectProducedMaterialList4Update(dbContext, producedMaterialList, siteid).ToArray();
		foreach (Producedmaterial producedmaterial in producedMaterialList)
		{
			ParamChecker.ArgumentNotNull("Productdefinitionid", producedmaterial.Productdefinitionid);
			ParamChecker.ArgumentNotNull("Siteid", producedmaterial.Siteid);
			string producedmaterialid = producedmaterial.Producedmaterialid;
			Producedmaterial producedmaterial2;
			if ((producedmaterial2 = FindProducedMaterial(producedmaterialList, producedmaterialid)) == null)
			{
				throw new EntityNotFoundException(typeof(Producedmaterial), producedmaterialid);
			}
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTid("API", tid, string.Format("{0} {1}", "Select4Update", producedmaterial2));
			}
			if (!ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, producedmaterial))
			{
				throw new EntityIsHoldException(typeof(Producedmaterial), producedmaterialid);
			}
			producedmaterial2.Prevstate = producedmaterial2.State;
			producedmaterial2.State = "Converted";
			producedmaterial.CopyCommonFieldUpdatePrev(producedmaterial2, systemTime, tid, text);
			producedmaterial.CopyExtensionCollection(producedmaterial2);
			list.Add(producedmaterial2);
		}
		ParamChecker.ArgumentNotNull("Lotid", lot.Lotid);
		ParamChecker.ArgumentNotNull("Siteid", lot.Siteid);
		string lotid = lot.Lotid;
		if (!siteid.Equals(lot.Siteid))
		{
			throw new ObjectComparedInvalidException("Siteid", siteid, lot.Siteid);
		}
		Lot lot4Update = LOT.GetLot4Update(dbContext, lotid, siteid);
		Lot lot2 = new Lot();
		bool flag7;
		string[] validState;
		if (lot4Update != null)
		{
			if (!flag4)
			{
				throw new EntityAlreadyExistsException(typeof(Lot), lotid);
			}
			if (flag3)
			{
				ParamChecker.ArgumentSameValue("Processsegmentid", lot.Productdefinitionid, lot4Update.Productdefinitionid);
			}
			if (flag5)
			{
				ParamChecker.ArgumentSameValue("Processnodeid", lot.Processnodeid, lot4Update.Processnodeid);
			}
			if (flag2)
			{
				ParamChecker.ArgumentSameValue("Processdefinitionid", lot.Processdefinitionid, lot4Update.Processdefinitionid);
			}
			if (flag7)
			{
				ParamChecker.ArgumentSameValue("Location", lot.Location, lot4Update.Location);
			}
			ParamChecker.EntityValidState(typeof(Lot), lot4Update.Lotid, lot4Update.State, validState);
		}
		else
		{
			lot.CopyColumsTo(lot2);
			string processsegmentid;
			string processnodeid;
			string processdefinitionid;
			string location;
			string producedmaterialid2;
			if (flag6)
			{
				processsegmentid = producedMaterialList[^1].Processsegmentid;
				processnodeid = producedMaterialList[^1].Processnodeid;
				processdefinitionid = producedMaterialList[^1].Processdefinitionid;
				location = producedMaterialList[^1].Location;
				producedmaterialid2 = producedMaterialList[^1].Producedmaterialid;
			}
			else
			{
				processsegmentid = producedMaterialList[0].Processsegmentid;
				processnodeid = producedMaterialList[0].Processnodeid;
				processdefinitionid = producedMaterialList[0].Processdefinitionid;
				location = producedMaterialList[0].Location;
				producedmaterialid2 = producedMaterialList[0].Producedmaterialid;
			}
			lot2.Processsegmentid = EntityHelper.FirstNotNull<string>(lot.Processsegmentid, processsegmentid);
			lot2.Processnodeid = EntityHelper.FirstNotNull<string>(lot.Processnodeid, processnodeid);
			lot2.Processdefinitionid = EntityHelper.FirstNotNull<string>(lot.Processdefinitionid, processdefinitionid);
			lot2.Location = EntityHelper.FirstNotNull<string>(lot.Location, location);
			lot2.Sourceinputid = producedmaterialid2;
			lot2.State = "Created";
			lot2.Activity = text;
			lot2.Isusable = "Usable";
			lot.CopyCommonField(lot2, systemTime, dbContext.Tid, isCreate: true);
			list2.Add(lot2);
			if (flag)
			{
				lot2.Prevstate = lot2.State;
				lot2.State = "Active";
				lot2.CopyCommonFieldUpdatePrev(lot2, systemTime, tid, text);
				list3.Add(lot2);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveProducedMaterialHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list2.ToArray(), saveLotHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list3.ToArray(), saveLotHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
		IL_00ee:
		flag7 = (byte)num6 != 0;
		validState = ((convertProducedMaterialToLotOptionSet?.ValidateDuplicationByState != null) ? convertProducedMaterialToLotOptionSet.ValidateDuplicationByState : new string[3] { "Active", "Created", "Hold" });
		if (convertProducedMaterialToLotOptionSet != null)
		{
			_ = convertProducedMaterialToLotOptionSet.ConvertActiveState;
			if (0 == 0)
			{
				num3 = (convertProducedMaterialToLotOptionSet.ConvertActiveState ? 1 : 0);
				goto IL_013f;
			}
		}
		num3 = 0;
		goto IL_013f;
	}

	public static int CreateProducedMaterial(IDbContext dbContext, Producedmaterial[] producedMaterialList, CreateProducedMaterialOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("producedMaterialList", producedMaterialList);
		string text = "CreateProducedMaterial";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		int num = 0;
		List<Producedmaterial> list = new List<Producedmaterial>();
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		bool flag = optionSet?.ValidateFK ?? false;
		foreach (Producedmaterial producedmaterial in producedMaterialList)
		{
			ParamChecker.ArgumentNotNull("Producedmaterialid", producedmaterial.Producedmaterialid);
			ParamChecker.ArgumentNotNull("Siteid", producedmaterial.Siteid);
			Producedmaterial producedmaterial2 = new Producedmaterial();
			producedmaterial.CopyColumsTo(producedmaterial2);
			_ = producedmaterial2.Siteid;
			_ = producedmaterial2.Producedmaterialid;
			if (flag)
			{
				ValidateFK(dbContext, producedmaterial2);
			}
			producedmaterial2.Prevstate = null;
			producedmaterial2.State = EntityHelper.FirstNotNull<string>(producedmaterial.State, "Created");
			producedmaterial2.Ishold = "N";
			producedmaterial2.Isrework = "N";
			producedmaterial2.Isusable = "Usable";
			producedmaterial2.Activity = text;
			producedmaterial.CopyCommonField(producedmaterial2, systemTime, tid, isCreate: true);
			list.Add(producedmaterial2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", producedmaterial2);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int CreateProducedMaterial(IDbContext dbContext, Lot lot, Producedmaterial[] producedMaterialList, CreateProducedMaterialOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("lot", lot);
		ParamChecker.ArgumentNotNull("Lotid", lot.Lotid);
		ParamChecker.ArgumentNotNull("Siteid", lot.Siteid);
		ParamChecker.ArgumentNotNullAndHasElement("producedMaterialList", producedMaterialList);
		string text = "CreateProducedMaterial";
		int apiVersion = 2;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		bool flag = optionSet?.ValidateFK ?? false;
		string lotid = lot.Lotid;
		string siteid = lot.Siteid;
		Lot lot2;
		if ((lot2 = LOT.SelectLot4Update(dbContext, lotid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Lot), lotid);
		}
		Productdefinition productdefinition;
		if ((productdefinition = PRODUCTDEFINITION.SelectProductDefinition(dbContext, lot2.Productdefinitionid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Productdefinition), lot2.Productdefinitionid);
		}
		string[] countableProducedMaterialGradeIdList = LOT.getCountableProducedMaterialGradeIdList(dbContext, siteid);
		string[] countableSubproducedMaterialGradeIdList = LOT.getCountableSubproducedMaterialGradeIdList(dbContext, siteid);
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
		foreach (Producedmaterial producedmaterial in producedMaterialList)
		{
			ParamChecker.ArgumentNotNull("Producedmaterialid", producedmaterial.Producedmaterialid);
			Producedmaterial producedmaterial2 = new Producedmaterial();
			producedmaterial.CopyColumsTo(producedmaterial2);
			producedmaterial2.Lotid = lotid;
			producedmaterial2.Siteid = siteid;
			_ = producedmaterial2.Producedmaterialid;
			if (flag)
			{
				ValidateFK(dbContext, producedmaterial2);
			}
			producedmaterial2.State = EntityHelper.FirstNotNull<string>(producedmaterial.State, "Created");
			producedmaterial2.Materialtype = EntityHelper.FirstNotNull<string>(producedmaterial.Materialtype, materialtype);
			producedmaterial2.Producttype = EntityHelper.FirstNotNull<string>(producedmaterial.Producttype, producttype);
			producedmaterial2.Submaterialoriginalqty = EntityHelper.FirstNotNull<decimal?>(producedmaterial.Submaterialoriginalqty, submaterialqty);
			producedmaterial2.Submaterialtype = EntityHelper.FirstNotNull<string>(producedmaterial.Submaterialtype, submaterialtype);
			producedmaterial2.Grade = EntityHelper.FirstNotNull<string>(producedmaterial.Grade, text2);
			producedmaterial2.Submaterialoriginalqty = EntityHelper.FirstNotNull<decimal?>(producedmaterial.Submaterialoriginalqty, submaterialqty, default(decimal));
			producedmaterial2.Prevsubmaterialqty = default(decimal);
			producedmaterial2.Submaterialqty = EntityHelper.FirstNotNull<decimal?>(producedmaterial.Submaterialqty, producedmaterial2.Submaterialoriginalqty, default(decimal));
			string text3 = GRADEDEFINITION.GenerateSubMaterialGradeString(gradeId, producedmaterial2.Submaterialqty);
			producedmaterial2.Submaterialgrade = EntityHelper.FirstNotNull<string>(false, producedmaterial.Submaterialgrade, text3);
			producedmaterial2.Ishold = "N";
			producedmaterial2.Isrework = "N";
			producedmaterial2.Productorderid = EntityHelper.FirstNotNull<string>(producedmaterial.Productorderid, lot2.Productorderid);
			producedmaterial2.Workorderid = EntityHelper.FirstNotNull<string>(producedmaterial.Workorderid, lot2.Workorderid);
			producedmaterial2.Location = EntityHelper.FirstNotNull<string>(producedmaterial.Location, lot2.Location);
			producedmaterial2.Equipmentid = EntityHelper.FirstNotNull<string>(producedmaterial.Equipmentid, lot2.Equipmentid);
			InheritLotProcessInfo(lot2, producedmaterial2);
			producedmaterial2.Isusable = "Usable";
			producedmaterial2.Activity = text;
			producedmaterial.CopyCommonField(producedmaterial2, systemTime, tid, isCreate: true);
			list2.Add(producedmaterial2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", producedmaterial2);
			}
		}
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", lot2);
		}
		if (!LOT.ValidateAllowHoldLot(dbContext, text, apiVersion, lot2))
		{
			throw new EntityIsHoldException(typeof(Lot), lotid);
		}
		decimal lotQty = LOT.GetLotQty(dbContext, countableProducedMaterialGradeIdList, list2.ToArray());
		decimal subProducedMaterialQty = LOT.GetSubProducedMaterialQty(dbContext, countableSubproducedMaterialGradeIdList, list2.ToArray());
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
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list2.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static void ValidateFK(IDbContext dbContext, Producedmaterial producedMaterial)
	{
		string siteid = producedMaterial.Siteid;
		if (!string.IsNullOrEmpty(producedMaterial.Productdefinitionid) && PRODUCTDEFINITION.SelectProductDefinition(dbContext, producedMaterial.Productdefinitionid, siteid) == null)
		{
			throw new EntityNotFoundException(typeof(Productdefinition), producedMaterial.Productdefinitionid);
		}
		if (!string.IsNullOrEmpty(producedMaterial.Processdefinitionid) && PROCESSDEFINITION.SelectProcessDefinition(dbContext, producedMaterial.Processdefinitionid, siteid) == null)
		{
			throw new EntityNotFoundException(typeof(Processdefinition), producedMaterial.Processdefinitionid);
		}
		if (!string.IsNullOrEmpty(producedMaterial.Location) && FACILITY.SelectFacility(dbContext, producedMaterial.Location, siteid) == null)
		{
			throw new EntityNotFoundException(typeof(Facility), producedMaterial.Location);
		}
		if (!string.IsNullOrEmpty(producedMaterial.Productorderid) && PRODUCTORDER.SelectProductOrder(dbContext, producedMaterial.Productorderid, siteid) == null)
		{
			throw new EntityNotFoundException(typeof(Productorder), producedMaterial.Productorderid);
		}
	}

	public static int DeassignCarrierProducedMaterial(IDbContext dbContext, Producedmaterial[] producedMaterialList, Carrier carrier, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("producedMaterialList", producedMaterialList);
		ParamChecker.ArgumentNotNull("carrier", carrier);
		string text = "DeassignCarrierProducedMaterial";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		int num = 0;
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		List<Producedmaterial> list = new List<Producedmaterial>();
		List<Carrier> list2 = new List<Carrier>();
		_ = producedMaterialList[0].Lotid;
		string siteid = producedMaterialList[0].Siteid;
		Carrier carrier2 = null;
		Producedmaterial[] producedmaterialList = SelectProducedMaterialList4Update(dbContext, producedMaterialList, siteid).ToArray();
		if ((carrier2 = CARRIER.SelectCarrier4Update(dbContext, carrier.Carrierid, carrier.Siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Carrier), carrier.Carrierid);
		}
		foreach (Producedmaterial producedmaterial in producedMaterialList)
		{
			ParamChecker.ArgumentNotNull("Producedmaterialid", producedmaterial.Producedmaterialid);
			ParamChecker.ArgumentNotNull("Siteid", producedmaterial.Siteid);
			Producedmaterial producedmaterial2 = null;
			if ((producedmaterial2 = FindProducedMaterial(producedmaterialList, producedmaterial.Producedmaterialid)) == null)
			{
				throw new EntityNotFoundException(typeof(Producedmaterial), producedmaterial.Producedmaterialid);
			}
			if (!ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, producedmaterial2))
			{
				throw new EntityIsHoldException(typeof(Producedmaterial), producedmaterial.Producedmaterialid);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", $"Producedmaterialid={producedmaterial2.Producedmaterialid} Prevcarrierid={producedmaterial2.Prevcarrierid} Carrierid={producedmaterial2.Carrierid} Prevslotno={producedmaterial2.Prevslotno} Slotno={producedmaterial2.Slotno}");
			}
			producedmaterial2.Prevcarrierid = producedmaterial2.Carrierid;
			producedmaterial2.Carrierid = null;
			producedmaterial2.Prevslotno = producedmaterial2.Slotno;
			producedmaterial2.Slotno = null;
			producedmaterial.CopyCommonFieldUpdatePrev(producedmaterial2, systemTime, dbContext.Tid, text);
			producedmaterial.CopyExtensionCollection(producedmaterial2);
			list.Add(producedmaterial2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={producedmaterial2.Producedmaterialid} Prevcarrierid={producedmaterial2.Prevcarrierid} Carrierid={producedmaterial2.Carrierid} Prevslotno={producedmaterial2.Prevslotno} Slotno={producedmaterial2.Slotno}");
			}
		}
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", carrier2);
		}
		if (carrier.Assignqty.HasValue && !(carrier2.Assignqty == carrier.Assignqty))
		{
			carrier2.Assignqty = carrier.Assignqty;
		}
		if (carrier.Loadstate != null && carrier2.Loadstate != carrier.Loadstate)
		{
			carrier2.Loadstate = carrier.Loadstate;
		}
		carrier.CopyCommonFieldUpdatePrev(carrier2, systemTime, dbContext.Tid, text);
		carrier.CopyExtensionCollection(carrier2);
		list2.Add(carrier2);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", carrier2);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int GetSubProducedMaterialQty(IDbContext dbContext, string[] countableSubproducedMaterialGradeIdList, Producedmaterial producedMaterial)
	{
		ParamChecker.ArgumentNotNull("producedMaterial", producedMaterial);
		if (producedMaterial.State == "Scrapped" || producedMaterial.State == "Terminated")
		{
			return 0;
		}
		if (string.IsNullOrEmpty(producedMaterial.Submaterialgrade))
		{
			return 0;
		}
		string[] array = Array.ConvertAll(producedMaterial.Submaterialgrade.ToCharArray(), (char ch) => ch.ToString());
		int num = 0;
		string[] array2 = array;
		foreach (string value in array2)
		{
			if (countableSubproducedMaterialGradeIdList.Contains(value))
			{
				num++;
			}
		}
		return num;
	}

	public static int HoldProducedMaterial(IDbContext dbContext, Producedmaterial[] producedMaterialList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("producedMaterialList", producedMaterialList);
		string text = "HoldProducedMaterial";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		string tid = dbContext.Tid;
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Producedmaterial> list = new List<Producedmaterial>();
		_ = producedMaterialList[0].Lotid;
		string siteid = producedMaterialList[0].Siteid;
		Producedmaterial[] producedmaterialList = SelectProducedMaterialList4Update(dbContext, producedMaterialList, siteid).ToArray();
		foreach (Producedmaterial producedmaterial in producedMaterialList)
		{
			ParamChecker.ArgumentNotNull("Producedmaterialid", producedmaterial.Producedmaterialid);
			ParamChecker.ArgumentNotNull("Siteid", producedmaterial.Siteid);
			Producedmaterial producedmaterial2 = null;
			if ((producedmaterial2 = FindProducedMaterial(producedmaterialList, producedmaterial.Producedmaterialid)) == null)
			{
				throw new EntityNotFoundException(typeof(Producedmaterial), producedmaterial.Producedmaterialid);
			}
			ParamChecker.EntityValidState(typeof(Producedmaterial), producedmaterial2.Producedmaterialid, producedmaterial2.State, "Active", "Created");
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", $"Producedmaterialid={producedmaterial2.Producedmaterialid} Ishold={producedmaterial2.Ishold}");
			}
			producedmaterial2.Ishold = "Y";
			producedmaterial.CopyCommonFieldUpdatePrev(producedmaterial2, systemTime, tid, text);
			producedmaterial.CopyExtensionCollection(producedmaterial2);
			list.Add(producedmaterial2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={producedmaterial2.Producedmaterialid} Ishold={producedmaterial2.Ishold}");
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	internal static void InheritLotProcessInfo(Lot parentLot, Producedmaterial childProducedMaterial)
	{
		childProducedMaterial.Prevprocessdefinitionid = parentLot.Prevprocessdefinitionid;
		childProducedMaterial.Prevsubprocessdefinitionid = parentLot.Prevsubprocessdefinitionid;
		childProducedMaterial.Prevprocesssegmentid = parentLot.Prevprocesssegmentid;
		childProducedMaterial.Prevprocessnodeid = parentLot.Prevprocessnodeid;
		childProducedMaterial.Processdefinitionid = parentLot.Processdefinitionid;
		childProducedMaterial.Subprocessdefinitionid = parentLot.Subprocessdefinitionid;
		childProducedMaterial.Processsegmentid = parentLot.Processsegmentid;
		childProducedMaterial.Processnodeid = parentLot.Processnodeid;
		childProducedMaterial.Processingstate = parentLot.Processingstate;
	}

	public static Producedmaterial GetProducedMaterial(IDbContext dbContext, string producedmaterialid, string siteid)
	{
		string apiName = "GetProducedMaterial";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{producedmaterialid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProducedMaterialSqlDatabase : _sqlGetProducedMaterialOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCEDMATERIALID", producedmaterialid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PRODUCEDMATERIAL", $"{producedmaterialid},{siteid}"));
		}
		Producedmaterial? result = ContextManager.DirectEntityQuery<Producedmaterial>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{producedmaterialid},{siteid}");
		}
		return result;
	}

	public static Producedmaterial GetProducedMaterial4Update(IDbContext dbContext, string producedmaterialid, string siteid)
	{
		string apiName = "GetProducedMaterial4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{producedmaterialid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProducedMaterial4UpdateSqlDatabase : _sqlGetProducedMaterial4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCEDMATERIALID", producedmaterialid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PRODUCEDMATERIAL", $"{producedmaterialid},{siteid}"));
		}
		Producedmaterial? result = ContextManager.DirectEntityQuery<Producedmaterial>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{producedmaterialid},{siteid}");
		}
		return result;
	}

	public static Producedmaterial SelectProducedMaterial(IDbContext dbContext, string producedmaterialid, string siteid)
	{
		string apiName = "SelectProducedMaterial";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{producedmaterialid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProducedMaterialSqlDatabase : _sqlSelectProducedMaterialOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCEDMATERIALID", producedmaterialid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PRODUCEDMATERIAL", $"{producedmaterialid},{siteid}"));
		}
		Producedmaterial? result = ContextManager.DirectEntityQuery<Producedmaterial>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{producedmaterialid},{siteid}");
		}
		return result;
	}

	public static Producedmaterial SelectProducedMaterial4Update(IDbContext dbContext, string producedmaterialid, string siteid)
	{
		string apiName = "SelectProducedMaterial4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{producedmaterialid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProducedMaterial4UpdateSqlDatabase : _sqlSelectProducedMaterial4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCEDMATERIALID", producedmaterialid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PRODUCEDMATERIAL", $"{producedmaterialid},{siteid}"));
		}
		Producedmaterial? result = ContextManager.DirectEntityQuery<Producedmaterial>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{producedmaterialid},{siteid}");
		}
		return result;
	}

	public static IList<Producedmaterial> SelectProducedMaterialList(IDbContext dbContext, Producedmaterial[] producedMaterialList, string siteId)
	{
		string apiName = "SelectProducedMaterialList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{producedMaterialList.Length},{siteId}");
		}
		string value = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProducedMaterialListSqlDatabase : _sqlSelectProducedMaterialListOracleDatabase);
		value = new StringBuilder(value, 1000).Replace("&PRODUCEDMATERIALIDLIST", EntityHelper.ConcatString4InClause(ExtractIdOrderBy(producedMaterialList))).ToString();
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PRODUCEDMATERIAL", $"{producedMaterialList.Length},{siteId}"));
		}
		IList<Producedmaterial> result = ContextManager.DirectEntityQuery<Producedmaterial>(dbContext, value, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{producedMaterialList.Length},{siteId}");
		}
		return result;
	}

	public static IList<Producedmaterial> SelectProducedMaterialList4Update(IDbContext dbContext, Producedmaterial[] producedMaterialList, string siteId)
	{
		string apiName = "SelectProducedMaterialList4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{producedMaterialList.Length},{siteId}");
		}
		string value = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProducedMaterialList4UpdateSqlDatabase : _sqlSelectProducedMaterialList4UpdateOracleDatabase);
		value = new StringBuilder(value, 1000).Replace("&PRODUCEDMATERIALIDLIST", EntityHelper.ConcatString4InClause(ExtractIdOrderBy(producedMaterialList))).ToString();
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PRODUCEDMATERIAL", $"{producedMaterialList.Length},{siteId}"));
		}
		IList<Producedmaterial> result = ContextManager.DirectEntityQuery<Producedmaterial>(dbContext, value, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{producedMaterialList.Length},{siteId}");
		}
		return result;
	}

	public static IList<Producedmaterial> SelectProducedMaterialListAlive(IDbContext dbContext, Producedmaterial[] producedMaterialList, string siteId)
	{
		string apiName = "SelectProducedMaterialListAlive";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{producedMaterialList.Length},{siteId}");
		}
		IList<Producedmaterial> result = SelectProducedMaterialListWithNotState(dbContext, producedMaterialList, new string[2] { "Scrapped", "Terminated" }, siteId);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{producedMaterialList.Length},{siteId}");
		}
		return result;
	}

	public static IList<Producedmaterial> SelectProducedMaterialListAlive4Update(IDbContext dbContext, Producedmaterial[] producedMaterialList, string siteId)
	{
		string apiName = "SelectProducedMaterialListAlive4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{producedMaterialList.Length},{siteId}");
		}
		IList<Producedmaterial> result = SelectProducedMaterialListWithNotState4Update(dbContext, producedMaterialList, new string[2] { "Scrapped", "Terminated" }, siteId);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{producedMaterialList.Length},{siteId}");
		}
		return result;
	}

	public static IList<Producedmaterial> SelectProducedMaterialListAliveByLot(IDbContext dbContext, string lotId, string siteId)
	{
		string apiName = "SelectProducedMaterialListAliveByLot";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotId},{siteId}");
		}
		IList<Producedmaterial> result = SelectProducedMaterialListByLotWithNotState(dbContext, lotId, new string[2] { "Scrapped", "Terminated" }, siteId);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotId},{siteId}");
		}
		return result;
	}

	public static IList<Producedmaterial> SelectProducedMaterialListAliveByLot4Update(IDbContext dbContext, string lotId, string siteId)
	{
		string apiName = "SelectProducedMaterialListAliveByLot4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotId},{siteId}");
		}
		IList<Producedmaterial> result = SelectProducedMaterialListByLotWithNotState4Update(dbContext, lotId, new string[2] { "Scrapped", "Terminated" }, siteId);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotId},{siteId}");
		}
		return result;
	}

	public static IList<Producedmaterial> SelectProducedMaterialListByLotWithNotState(IDbContext dbContext, string lotId, string[] invalidStateList, string siteId)
	{
		string apiName = "SelectProducedMaterialListByLotWithNotState";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotId},{siteId}");
		}
		string value = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProducedMaterialListByLotWithNotStateSqlDatabase : _sqlSelectProducedMaterialListByLotWithNotStateOracleDatabase);
		value = new StringBuilder(value, 1000).Replace("&STATE", EntityHelper.ConcatString4InClause(invalidStateList)).ToString();
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotId, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PRODUCEDMATERIAL", $"{lotId},{siteId}"));
		}
		IList<Producedmaterial> result = ContextManager.DirectEntityQuery<Producedmaterial>(dbContext, value, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotId},{siteId}");
		}
		return result;
	}

	public static IList<Producedmaterial> SelectProducedMaterialListByLotWithNotState4Update(IDbContext dbContext, string lotId, string[] invalidStateList, string siteId)
	{
		string apiName = "SelectProducedMaterialListByLotWithNotState4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotId},{siteId}");
		}
		string value = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProducedMaterialListByLotWithNotState4UpdateSqlDatabase : _sqlSelectProducedMaterialListByLotWithNotState4UpdateOracleDatabase);
		value = new StringBuilder(value, 1000).Replace("&STATE", EntityHelper.ConcatString4InClause(invalidStateList)).ToString();
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotId, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PRODUCEDMATERIAL", $"{lotId},{siteId}"));
		}
		IList<Producedmaterial> result = ContextManager.DirectEntityQuery<Producedmaterial>(dbContext, value, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotId},{siteId}");
		}
		return result;
	}

	public static IList<Producedmaterial> SelectProducedMaterialListByLotWithNotState4BulkUpdate(IDbContext dbContext, Lot[] lotList, string[] invalidStateList, string siteId)
	{
		string apiName = "SelectProducedMaterialListByLotWithNotState4BulkUpdate";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{EntityHelper.ConcatString4InClause(ExtractIdOrderBy(lotList))},{siteId}");
		}
		string value = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProducedMaterialListByLotWithNotState4BulkUpdateSqlDatabase : _sqlSelectProducedMaterialListByLotWithNotState4BulkUpdateOracleDatabase);
		value = new StringBuilder(value, 1000).Replace("&LOTID", EntityHelper.ConcatString4InClause(ExtractIdOrderBy(lotList))).ToString();
		value = new StringBuilder(value, 1000).Replace("&STATE", EntityHelper.ConcatString4InClause(invalidStateList)).ToString();
		value = new StringBuilder(value, 1000).Replace("&SITEID", "'" + siteId + "'").ToString();
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PRODUCEDMATERIAL", $"{EntityHelper.ConcatString4InClause(ExtractIdOrderBy(lotList))},{siteId}"));
		}
		IList<Producedmaterial> result = ContextManager.DirectEntityQuery<Producedmaterial>(dbContext, value);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{EntityHelper.ConcatString4InClause(ExtractIdOrderBy(lotList))},{siteId}");
		}
		return result;
	}

	internal static string[] ExtractIdOrderBy(Lot[] lotList)
	{
		return (from p in lotList
			select p.Lotid into id
			orderby id
			select id).ToArray();
	}

	public static IList<Producedmaterial> SelectProducedMaterialListByLotWithState(IDbContext dbContext, string lotId, string[] validStateList, string siteId)
	{
		string apiName = "SelectProducedMaterialListByLotWithState";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotId},{siteId}");
		}
		string value = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProducedMaterialListByLotWithStateSqlDatabase : _sqlSelectProducedMaterialListByLotWithStateOracleDatabase);
		value = new StringBuilder(value, 1000).Replace("&STATE", EntityHelper.ConcatString4InClause(validStateList)).ToString();
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotId, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PRODUCEDMATERIAL", $"{lotId},{siteId}"));
		}
		IList<Producedmaterial> result = ContextManager.DirectEntityQuery<Producedmaterial>(dbContext, value, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotId},{siteId}");
		}
		return result;
	}

	public static IList<Producedmaterial> SelectProducedMaterialListByLotWithState4Update(IDbContext dbContext, string lotId, string[] validStateList, string siteId)
	{
		string apiName = "SelectProducedMaterialListByLotWithState4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotId},{siteId}");
		}
		string value = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProducedMaterialListByLotWithState4UpdateSqlDatabase : _sqlSelectProducedMaterialListByLotWithState4UpdateOracleDatabase);
		value = new StringBuilder(value, 1000).Replace("&STATE", EntityHelper.ConcatString4InClause(validStateList)).ToString();
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotId, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PRODUCEDMATERIAL", $"{lotId},{siteId}"));
		}
		IList<Producedmaterial> result = ContextManager.DirectEntityQuery<Producedmaterial>(dbContext, value, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotId},{siteId}");
		}
		return result;
	}

	public static IList<Producedmaterial> SelectProducedMaterialListWithNotState(IDbContext dbContext, Producedmaterial[] producedMaterialList, string[] invalidStateList, string siteId)
	{
		string apiName = "SelectProducedMaterialListWithNotState";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{producedMaterialList.Length},{siteId}");
		}
		string value = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProducedMaterialListWithNotStateSqlDatabase : _sqlSelectProducedMaterialListWithNotStateOracleDatabase);
		value = new StringBuilder(value, 1000).Replace("&PRODUCEDMATERIALIDLIST", EntityHelper.ConcatString4InClause(ExtractIdOrderBy(producedMaterialList))).Replace("&STATE", EntityHelper.ConcatString4InClause(invalidStateList)).ToString();
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PRODUCEDMATERIAL", $"{producedMaterialList.Length},{siteId}"));
		}
		IList<Producedmaterial> result = ContextManager.DirectEntityQuery<Producedmaterial>(dbContext, value, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{producedMaterialList.Length},{siteId}");
		}
		return result;
	}

	public static IList<Producedmaterial> SelectProducedMaterialListWithNotState4Update(IDbContext dbContext, Producedmaterial[] producedMaterialList, string[] invalidStateList, string siteId)
	{
		string apiName = "SelectProducedMaterialListWithNotState4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{producedMaterialList.Length},{siteId}");
		}
		string value = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProducedMaterialListWithNotState4UpdateSqlDatabase : _sqlSelectProducedMaterialListWithNotState4UpdateOracleDatabase);
		value = new StringBuilder(value, 1000).Replace("&PRODUCEDMATERIALIDLIST", EntityHelper.ConcatString4InClause(ExtractIdOrderBy(producedMaterialList))).Replace("&STATE", EntityHelper.ConcatString4InClause(invalidStateList)).ToString();
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PRODUCEDMATERIAL", $"{producedMaterialList.Length},{siteId}"));
		}
		IList<Producedmaterial> result = ContextManager.DirectEntityQuery<Producedmaterial>(dbContext, value, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{producedMaterialList.Length},{siteId}");
		}
		return result;
	}

	public static IList<Producedmaterial> SelectProducedMaterialListWithState(IDbContext dbContext, Producedmaterial[] producedMaterialList, string[] validStateList, string siteId)
	{
		string apiName = "SelectProducedMaterialListWithState";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{producedMaterialList.Length},{siteId}");
		}
		string value = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProducedMaterialListWithStateSqlDatabase : _sqlSelectProducedMaterialListWithStateOracleDatabase);
		value = new StringBuilder(value, 1000).Replace("&PRODUCEDMATERIALIDLIST", EntityHelper.ConcatString4InClause(ExtractIdOrderBy(producedMaterialList))).Replace("&STATE", EntityHelper.ConcatString4InClause(validStateList)).ToString();
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PRODUCEDMATERIAL", $"{producedMaterialList.Length},{siteId}"));
		}
		IList<Producedmaterial> result = ContextManager.DirectEntityQuery<Producedmaterial>(dbContext, value, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{producedMaterialList.Length},{siteId}");
		}
		return result;
	}

	public static IList<Producedmaterial> SelectProducedMaterialListWithState4Update(IDbContext dbContext, Producedmaterial[] producedMaterialList, string[] validStateList, string siteId)
	{
		string apiName = "SelectProducedMaterialListWithState4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{producedMaterialList.Length},{siteId}");
		}
		string value = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProducedMaterialListWithState4UpdateSqlDatabase : _sqlSelectProducedMaterialListWithState4UpdateOracleDatabase);
		value = new StringBuilder(value, 1000).Replace("&PRODUCEDMATERIALIDLIST", EntityHelper.ConcatString4InClause(ExtractIdOrderBy(producedMaterialList))).Replace("&STATE", EntityHelper.ConcatString4InClause(validStateList)).ToString();
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PRODUCEDMATERIAL", $"{producedMaterialList.Length},{siteId}"));
		}
		IList<Producedmaterial> result = ContextManager.DirectEntityQuery<Producedmaterial>(dbContext, value, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{producedMaterialList.Length},{siteId}");
		}
		return result;
	}

	internal static void UpdateUserColumns(string activity, Producedmaterial input, Producedmaterial stored)
	{
		stored.Batchid = input.Batchid;
		stored.Childproducedmaterialid = input.Childproducedmaterialid;
		stored.Equipmentrecipeid = input.Equipmentrecipeid;
		stored.Finishedtime = input.Finishedtime;
		stored.Priority = input.Priority;
		stored.Processendtime = input.Processendtime;
		stored.Processstarttime = input.Processstarttime;
		stored.Productorderid = input.Productorderid;
		stored.Trackintime = input.Trackintime;
		stored.Trackinuser = input.Trackinuser;
		stored.Trackouttime = input.Trackouttime;
		stored.Trackoutuser = input.Trackoutuser;
		stored.Usedcount = input.Usedcount;
		stored.Workorderid = input.Workorderid;
		stored.Duedate = input.Duedate;
		if (stored.Carrierid != input.Carrierid)
		{
			stored.Prevcarrierid = stored.Carrierid;
			stored.Carrierid = input.Carrierid;
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
		if (stored.Producttype != input.Producttype)
		{
			stored.Prevproducttype = stored.Producttype;
			stored.Producttype = input.Producttype;
		}
		if (stored.Slotno != input.Slotno)
		{
			stored.Prevslotno = stored.Slotno;
			stored.Slotno = input.Slotno;
		}
		if (stored.Grade != input.Grade)
		{
			stored.Prevgrade = stored.Grade;
			stored.Grade = input.Grade;
		}
		if (stored.Submaterialgrade != input.Submaterialgrade)
		{
			stored.Prevsubmaterialgrade = stored.Submaterialgrade;
			stored.Submaterialgrade = input.Submaterialgrade;
		}
		if (!(stored.Submaterialqty == input.Submaterialqty))
		{
			stored.Prevsubmaterialqty = stored.Submaterialqty;
			stored.Submaterialqty = input.Submaterialqty;
		}
	}

	internal static void UpdateUserColumnsFromLot(string activity, Lot input, Producedmaterial stored)
	{
		stored.Trackintime = input.Trackintime;
		stored.Trackinuser = input.Trackinuser;
		stored.Trackouttime = input.Trackouttime;
		stored.Trackoutuser = input.Trackoutuser;
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
	}

	public static int UpsertProducedMaterial(IDbContext dbContext, RequestType requestType, Producedmaterial[] producedMaterialList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateProducedMaterialInternal(dbContext, producedMaterialList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateProducedMaterial(dbContext, producedMaterialList, optionSet, saveHist), 
			RequestType.DELETE => DeleteProducedMaterial(dbContext, producedMaterialList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteProducedMaterial(dbContext, producedMaterialList, optionSet, saveHist), 
			_ => RealDeleteProducedMaterial(dbContext, producedMaterialList, optionSet, saveHist), 
		};
	}

	private static int CreateProducedMaterialInternal(IDbContext dbContext, Producedmaterial[] producedMaterialList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("producedMaterialList", producedMaterialList);
		string text = "CreateProducedMaterial";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Producedmaterial> list = new List<Producedmaterial>();
		foreach (Producedmaterial obj in producedMaterialList)
		{
			Producedmaterial producedmaterial = new Producedmaterial();
			obj.CopyColumsTo(producedmaterial);
			producedmaterial.Activity = text;
			producedmaterial.CheckEntityUsable();
			obj.CopyCommonField(producedmaterial, systemTime, dbContext.Tid, isCreate: true);
			list.Add(producedmaterial);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateProducedMaterial(IDbContext dbContext, Producedmaterial[] producedMaterialList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("producedMaterialList", producedMaterialList);
		string text = "UpdateProducedMaterial";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Producedmaterial> list = new List<Producedmaterial>();
		foreach (Producedmaterial producedmaterial in producedMaterialList)
		{
			Producedmaterial producedMaterial4Update = GetProducedMaterial4Update(dbContext, producedmaterial.Producedmaterialid, producedmaterial.Siteid);
			if (producedMaterial4Update == null)
			{
				throw new EntityNotFoundException(typeof(Producedmaterial), $"{producedmaterial.Producedmaterialid},{producedmaterial.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Producedmaterial), $"{producedmaterial.Producedmaterialid},{producedmaterial.Siteid}", producedMaterial4Update.Isusable);
			string activity = producedMaterial4Update.Activity;
			string customactivity = producedMaterial4Update.Customactivity;
			string isusable = producedMaterial4Update.Isusable;
			DateTime? createtime = producedMaterial4Update.Createtime;
			string creator = producedMaterial4Update.Creator;
			producedmaterial.CopyColumsTo(producedMaterial4Update);
			producedMaterial4Update.Prevactivity = activity;
			producedMaterial4Update.Prevcustomactivity = customactivity;
			producedMaterial4Update.Creator = creator;
			producedMaterial4Update.Createtime = createtime;
			producedMaterial4Update.Isusable = isusable;
			producedMaterial4Update.Activity = text;
			producedmaterial.CopyCommonField(producedMaterial4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(producedMaterial4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteProducedMaterial(IDbContext dbContext, Producedmaterial[] producedMaterialList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("producedMaterialList", producedMaterialList);
		string text = "DeleteProducedMaterial";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Producedmaterial> list = new List<Producedmaterial>();
		foreach (Producedmaterial producedmaterial in producedMaterialList)
		{
			Producedmaterial producedMaterial4Update = GetProducedMaterial4Update(dbContext, producedmaterial.Producedmaterialid, producedmaterial.Siteid);
			if (producedMaterial4Update == null)
			{
				throw new EntityNotFoundException(typeof(Producedmaterial), $"{producedmaterial.Producedmaterialid},{producedmaterial.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Producedmaterial), $"{producedmaterial.Producedmaterialid},{producedmaterial.Siteid}", producedMaterial4Update.Isusable);
			producedMaterial4Update.Isusable = "UnUsable";
			producedmaterial.CopyCommonFieldUpdatePrev(producedMaterial4Update, systemTime, dbContext.Tid, text);
			producedmaterial.CopyExtensionCollection(producedMaterial4Update);
			list.Add(producedMaterial4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteProducedMaterial(IDbContext dbContext, Producedmaterial[] producedMaterialList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("producedMaterialList", producedMaterialList);
		string text = "UnDeleteProducedMaterial";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Producedmaterial> list = new List<Producedmaterial>();
		foreach (Producedmaterial producedmaterial in producedMaterialList)
		{
			Producedmaterial producedMaterial4Update = GetProducedMaterial4Update(dbContext, producedmaterial.Producedmaterialid, producedmaterial.Siteid);
			if (producedMaterial4Update == null)
			{
				throw new EntityNotFoundException(typeof(Producedmaterial), $"{producedmaterial.Producedmaterialid},{producedmaterial.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Producedmaterial), $"{producedmaterial.Producedmaterialid},{producedmaterial.Siteid}", producedMaterial4Update.Isusable);
			producedMaterial4Update.Isusable = "Usable";
			producedmaterial.CopyCommonFieldUpdatePrev(producedMaterial4Update, systemTime, dbContext.Tid, text);
			producedmaterial.CopyExtensionCollection(producedMaterial4Update);
			list.Add(producedMaterial4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteProducedMaterial(IDbContext dbContext, Producedmaterial[] producedMaterialList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("producedMaterialList", producedMaterialList);
		string text = "RealDeleteProducedMaterial";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Producedmaterial> list = new List<Producedmaterial>();
		foreach (Producedmaterial producedmaterial in producedMaterialList)
		{
			Producedmaterial producedMaterial4Update = GetProducedMaterial4Update(dbContext, producedmaterial.Producedmaterialid, producedmaterial.Siteid);
			if (producedMaterial4Update == null)
			{
				throw new EntityNotFoundException(typeof(Producedmaterial), $"{producedmaterial.Producedmaterialid},{producedmaterial.Siteid}");
			}
			producedmaterial.CopyCommonFieldUpdatePrev(producedMaterial4Update, systemTime, dbContext.Tid, text);
			producedmaterial.CopyExtensionCollection(producedMaterial4Update);
			list.Add(producedMaterial4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	internal static string[] ExtractIdOrderBy(Producedmaterial[] producedMaterialList)
	{
		return (from p in producedMaterialList
			select p.Producedmaterialid into id
			orderby id
			select id).ToArray();
	}

	public static Producedmaterial FindProducedMaterial(Producedmaterial[] producedmaterialList, string producedMaterialId)
	{
		return producedmaterialList?.FirstOrDefault((Producedmaterial item) => item.Producedmaterialid == producedMaterialId);
	}

	public static IList<Producedmaterial> FindProducedMaterialList(Producedmaterial[] producedmaterialList, string lotId)
	{
		if (producedmaterialList == null)
		{
			return new List<Producedmaterial>();
		}
		return producedmaterialList.Where((Producedmaterial item) => item.Lotid == lotId).ToList();
	}

	internal static IList<Producedmaterial> FilterProducedMaterialListByTid(Producedmaterial[] producedmMaterialList, string tid)
	{
		return producedmMaterialList.Where((Producedmaterial prod) => prod.Tid == tid).ToList();
	}

	internal static int GetCountLotId(Producedmaterial[] producedmMaterialList)
	{
		if (producedmMaterialList == null || producedmMaterialList.Length == 0)
		{
			return 0;
		}
		return (from prod in producedmMaterialList
			where !string.IsNullOrEmpty(prod.Lotid)
			select prod.Lotid).Distinct().Count();
	}

	internal static int GetCountCarrierId(Producedmaterial[] producedmMaterialList)
	{
		if (producedmMaterialList == null || producedmMaterialList.Length == 0)
		{
			return 0;
		}
		return (from prod in producedmMaterialList
			where !string.IsNullOrEmpty(prod.Carrierid)
			select prod.Carrierid).Distinct().Count();
	}

	public static int RecreateProducedMaterial(IDbContext dbContext, Producedmaterial[] sourceProducedMaterialList, Producedmaterial[] targetProducedMaterialList, RecreateProducedMaterialOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		object[] objectList = sourceProducedMaterialList;
		ParamChecker.ArgumentNotNullAndHasElement("sourceProducedMaterialList", objectList);
		objectList = targetProducedMaterialList;
		ParamChecker.ArgumentNotNullAndHasElement("targetProducedMaterialList", objectList);
		objectList = sourceProducedMaterialList;
		object[] arr = objectList;
		objectList = targetProducedMaterialList;
		ParamChecker.ArraySameLength(arr, objectList);
		string text = "RecreateProducedMaterial";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		int num = 0;
		Producedmaterial producedmaterial = sourceProducedMaterialList[0];
		Producedmaterial producedmaterial2 = targetProducedMaterialList[0];
		ParamChecker.ArgumentNotNull("firstSourceProducedMaterial.Lotid", producedmaterial.Lotid);
		ParamChecker.ArgumentNotNull("firstSourceProducedMaterial.Siteid", producedmaterial.Siteid);
		ParamChecker.ArgumentNotNull("firstTargetProducedMaterial.Lotid", producedmaterial2.Lotid);
		ParamChecker.ArgumentNotNull("firstTargetProducedMaterial.Siteid", producedmaterial2.Siteid);
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		List<Producedmaterial> list = new List<Producedmaterial>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		string siteid = producedmaterial.Siteid;
		_ = producedmaterial2.Siteid;
		_ = producedmaterial.Lotid;
		Producedmaterial[] producedmaterialList = SelectProducedMaterialList4Update(dbContext, sourceProducedMaterialList, siteid).ToArray();
		for (int i = 0; i < sourceProducedMaterialList.Length; i++)
		{
			Producedmaterial producedmaterial3 = sourceProducedMaterialList[i];
			Producedmaterial producedmaterial4 = targetProducedMaterialList[i];
			string producedmaterialid = producedmaterial3.Producedmaterialid;
			_ = producedmaterial4.Producedmaterialid;
			ParamChecker.ArgumentNotNull("targetProducedMaterialid", producedmaterial4.Producedmaterialid);
			ParamChecker.ArgumentNotNull("sourceProducedMaterialid", producedmaterial3.Producedmaterialid);
			Producedmaterial producedmaterial5;
			if ((producedmaterial5 = FindProducedMaterial(producedmaterialList, producedmaterialid)) == null)
			{
				throw new EntityNotFoundException(typeof(Producedmaterial), producedmaterialid);
			}
			if (!ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, producedmaterial5))
			{
				throw new EntityIsHoldException(typeof(Producedmaterial), producedmaterialid);
			}
			Producedmaterial producedmaterial6 = new Producedmaterial();
			producedmaterial4.CopyColumsTo(producedmaterial6, copyExtensionCollection: true);
			producedmaterial6.Prevactivity = producedmaterial5.Activity;
			producedmaterial6.Activity = text;
			producedmaterial6.Prevcustomactivity = producedmaterial5.Customactivity;
			producedmaterial4.CopyCommonField(producedmaterial6, systemTime, tid, isCreate: false);
			list2.Add(producedmaterial6);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", producedmaterial6);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", $"Producedmaterialid={producedmaterial5.Producedmaterialid} Prevlotid={producedmaterial5.Prevlotid} Lotid={producedmaterial5.Lotid} Prevstate={producedmaterial5.Prevstate} State={producedmaterial5.State}");
			}
			producedmaterial5.Prevlotid = producedmaterial3.Lotid;
			producedmaterial5.Lotid = null;
			producedmaterial5.Prevstate = producedmaterial5.State;
			producedmaterial5.State = "Terminated";
			producedmaterial3.CopyCommonFieldUpdatePrev(producedmaterial5, systemTime, tid, text);
			producedmaterial3.CopyExtensionCollection(producedmaterial5);
			list.Add(producedmaterial5);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={producedmaterial5.Producedmaterialid} Prevlotid={producedmaterial5.Prevlotid} Lotid={producedmaterial5.Lotid} Prevstate={producedmaterial5.Prevstate} State={producedmaterial5.State}");
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list2.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int ReleaseProducedMaterial(IDbContext dbContext, Producedmaterial[] producedMaterialList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("producedMaterialList", producedMaterialList);
		string text = "ReleaseProducedMaterial";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		int num = 0;
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		List<Producedmaterial> list = new List<Producedmaterial>();
		_ = producedMaterialList[0].Lotid;
		string siteid = producedMaterialList[0].Siteid;
		Producedmaterial[] producedmaterialList = SelectProducedMaterialList4Update(dbContext, producedMaterialList, siteid).ToArray();
		foreach (Producedmaterial producedmaterial in producedMaterialList)
		{
			ParamChecker.ArgumentNotNull("Producedmaterialid", producedmaterial.Producedmaterialid);
			ParamChecker.ArgumentNotNull("Siteid", producedmaterial.Siteid);
			Producedmaterial producedmaterial2 = null;
			if ((producedmaterial2 = FindProducedMaterial(producedmaterialList, producedmaterial.Producedmaterialid)) == null)
			{
				throw new EntityNotFoundException(typeof(Producedmaterial), producedmaterial.Producedmaterialid);
			}
			ParamChecker.EntityValidState(typeof(Producedmaterial), "Ishold", producedmaterial2.Ishold, "Y");
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", $"Producedmaterialid={producedmaterial2.Producedmaterialid} Ishold={producedmaterial2.Ishold}");
			}
			producedmaterial2.Ishold = "N";
			producedmaterial2.Prevactivity = producedmaterial2.Activity;
			producedmaterial2.Activity = text;
			producedmaterial2.Prevcustomactivity = producedmaterial2.Customactivity;
			producedmaterial.CopyCommonField(producedmaterial2, systemTime, tid, isCreate: false);
			producedmaterial2.Customactivity = EntityHelper.FirstNotNull<string>(producedmaterial.Customactivity, producedmaterial2.Activity);
			producedmaterial.CopyExtensionCollection(producedmaterial2);
			list.Add(producedmaterial2);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={producedmaterial2.Producedmaterialid} Ishold={producedmaterial2.Ishold}");
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int ScrapProducedMaterial(IDbContext dbContext, Producedmaterial[] inputProducedMaterialList, ScrapProducedMaterialOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inputProducedMaterialList", inputProducedMaterialList);
		string text = "ScrapProducedMaterial";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		List<Carrier> list3 = new List<Carrier>();
		List<Lotcarrierrel> list4 = new List<Lotcarrierrel>();
		ParamChecker.ArgumentNotNull("Lotid", inputProducedMaterialList[0].Lotid);
		ParamChecker.ArgumentNotNull("Siteid", inputProducedMaterialList[0].Siteid);
		Producedmaterial producedmaterial = inputProducedMaterialList[0];
		string lotid = producedmaterial.Lotid;
		string siteid = producedmaterial.Siteid;
		Lot lot = null;
		bool flag = false;
		decimal num2 = default(decimal);
		decimal num3 = default(decimal);
		if ((lot = LOT.SelectLot4Update(dbContext, lotid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Lot), lotid);
		}
		Producedmaterial[] array = SelectProducedMaterialListAliveByLot4Update(dbContext, lotid, siteid).ToArray();
		if (!LOT.ValidateAllowHoldLot(dbContext, text, apiVersion, lot))
		{
			throw new EntityIsHoldException(typeof(Lot), lotid);
		}
		string[] countableProducedMaterialGradeIdList = LOT.getCountableProducedMaterialGradeIdList(dbContext, siteid);
		string[] countableSubproducedMaterialGradeIdList = LOT.getCountableSubproducedMaterialGradeIdList(dbContext, siteid);
		List<Producedmaterial> list5 = new List<Producedmaterial>();
		List<Producedmaterial> list6 = new List<Producedmaterial>();
		Producedmaterial[] array2 = inputProducedMaterialList;
		foreach (Producedmaterial producedmaterial2 in array2)
		{
			Producedmaterial producedmaterial3 = FindProducedMaterial(array, producedmaterial2.Producedmaterialid);
			if (producedmaterial3 == null)
			{
				throw new EntityNotFoundException(typeof(Producedmaterial), producedmaterial2.Producedmaterialid);
			}
			list6.Add(producedmaterial3);
		}
		array2 = array;
		foreach (Producedmaterial producedmaterial4 in array2)
		{
			if (FindProducedMaterial(list6.ToArray(), producedmaterial4.Producedmaterialid) == null)
			{
				list5.Add(producedmaterial4);
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
		num2 = LOT.GetLotQty(dbContext, countableProducedMaterialGradeIdList, list6.ToArray());
		num3 = LOT.GetSubProducedMaterialQty(dbContext, countableSubproducedMaterialGradeIdList, list6.ToArray());
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "CalcQty", $"Lotid={lot.Lotid} Minus Qty={num2} Submaterialqty={num3}");
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
		lot.Lossqty = lot.Lossqty.Add(num2);
		lot.Prevqty = lot.Qty;
		lot.Qty = lot.Qty.Add(-num2);
		lot.Prevsubmaterialqty = lot.Submaterialqty;
		lot.Submaterialqty = lot.Submaterialqty.Add(-num3);
		producedmaterial.CopyCommonFieldUpdatePrev(lot, systemTime, tid, text);
		list.Add(lot);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", $"Lotid={lot.Lotid} State={lot.State} Lossqty={lot.Lossqty} Qty={lot.Qty} Submaterialqty={lot.Submaterialqty}");
		}
		array2 = inputProducedMaterialList;
		foreach (Producedmaterial producedmaterial5 in array2)
		{
			string producedmaterialid = producedmaterial5.Producedmaterialid;
			Producedmaterial producedmaterial6 = FindProducedMaterial(list6.ToArray(), producedmaterialid);
			if (!ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, producedmaterial6))
			{
				throw new EntityIsHoldException(typeof(Producedmaterial), producedmaterial6.Producedmaterialid);
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", $"Producedmaterialid={producedmaterial6.Producedmaterialid} State={producedmaterial6.State} Slotno={producedmaterial6.Slotno} Carrierid={producedmaterial6.Carrierid}");
			}
			producedmaterial6.Prevstate = producedmaterial6.State;
			producedmaterial6.State = "Scrapped";
			producedmaterial6.Prevslotno = producedmaterial6.Slotno;
			producedmaterial6.Slotno = 0;
			producedmaterial6.Prevcarrierid = producedmaterial6.Carrierid;
			producedmaterial6.Carrierid = null;
			producedmaterial5.CopyCommonFieldUpdatePrev(producedmaterial6, systemTime, tid, text);
			producedmaterial5.CopyExtensionCollection(producedmaterial6);
			list2.Add(producedmaterial6);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={producedmaterial6.Producedmaterialid} State={producedmaterial6.State} Slotno={producedmaterial6.Slotno} Carrierid={producedmaterial6.Carrierid}");
			}
		}
		if (flag)
		{
			Lotcarrierrel[] array3 = LOTCARRIERREL.GetLotCarrierRelList(dbContext, lotid, siteid).ToArray();
			string[] distinctCarrierList = LOTCARRIERREL.GetDistinctCarrierList(array3);
			foreach (string carrierid in distinctCarrierList)
			{
				Carrier carrier = CARRIER.SelectCarrier4Update(dbContext, carrierid, siteid);
				if (MesLogger.IsDebugEnabled("API"))
				{
					MesLogger.DebugTidApi(tid, "Before Execute Carrier", carrier);
				}
				producedmaterial.CopyCommonFieldUpdatePrev(carrier, systemTime, tid, text);
				list3.Add(carrier);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.DebugTidApi(tid, "After Execute Carrier", carrier);
				}
			}
			Lotcarrierrel[] array4 = array3;
			foreach (Lotcarrierrel lotcarrierrel in array4)
			{
				if (MesLogger.IsDebugEnabled("API"))
				{
					MesLogger.DebugTidApi(tid, "After Execute Lotcarrierrel", lotcarrierrel);
				}
				producedmaterial.CopyCommonFieldUpdatePrev(lotcarrierrel, systemTime, tid, text);
				list4.Add(lotcarrierrel);
				if (MesLogger.IsInfoEnabled("API"))
				{
					MesLogger.InfoTidApi(tid, "After Execute Lotcarrierrel", lotcarrierrel);
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

	public static int SeparateProducedMaterial(IDbContext dbContext, Producedmaterial parentProducedMaterial, Producedmaterial[] childProducedMaterialList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("parentProducedMaterial", parentProducedMaterial);
		ParamChecker.ArgumentNotNullAndHasElement("childProducedMaterialList", childProducedMaterialList);
		ParamChecker.ArgumentNotNull("parentLotid", parentProducedMaterial.Lotid);
		ParamChecker.ArgumentNotNull("parentProducedMaterialid", parentProducedMaterial.Producedmaterialid);
		ParamChecker.ArgumentNotNull("parentSiteid", parentProducedMaterial.Siteid);
		string text = "SeparateProducedMaterial";
		int apiVersion = 1;
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		int num = 0;
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		string lotid = parentProducedMaterial.Lotid;
		string siteid = parentProducedMaterial.Siteid;
		string producedmaterialid = parentProducedMaterial.Producedmaterialid;
		Lot lot = null;
		Producedmaterial producedmaterial = null;
		List<Lot> list = new List<Lot>();
		List<Producedmaterial> list2 = new List<Producedmaterial>();
		List<Producedmaterial> list3 = new List<Producedmaterial>();
		if ((lot = LOT.SelectLot4Update(dbContext, lotid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Lot), lotid);
		}
		if ((producedmaterial = SelectProducedMaterial4Update(dbContext, producedmaterialid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Producedmaterial), producedmaterialid);
		}
		if (!LOT.ValidateAllowHoldLot(dbContext, text, apiVersion, lot))
		{
			throw new EntityIsHoldException(typeof(Lot), lotid);
		}
		if (!ValidateAllowHoldProducedMaterial(dbContext, text, apiVersion, producedmaterial))
		{
			throw new EntityIsHoldException(typeof(Producedmaterial), producedmaterial.Producedmaterialid);
		}
		string[] countableProducedMaterialGradeIdList = LOT.getCountableProducedMaterialGradeIdList(dbContext, siteid);
		string[] countableSubproducedMaterialGradeIdList = LOT.getCountableSubproducedMaterialGradeIdList(dbContext, siteid);
		decimal lotQty = LOT.GetLotQty(dbContext, countableProducedMaterialGradeIdList, new Producedmaterial[1] { parentProducedMaterial });
		decimal subProducedMaterialQty = LOT.GetSubProducedMaterialQty(dbContext, countableSubproducedMaterialGradeIdList, new Producedmaterial[1] { parentProducedMaterial });
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "CalcQty", $"Lotid={lot.Lotid} Minus Qty={lotQty} Submaterialqty={subProducedMaterialQty}");
		}
		decimal num2 = default(decimal);
		decimal num3 = default(decimal);
		decimal num4 = default(decimal);
		decimal num5 = default(decimal);
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", $"Producedmaterialid={producedmaterial.Producedmaterialid} Prevlotid={producedmaterial.Prevlotid} Lotid={producedmaterial.Lotid} Prevstate={producedmaterial.Prevstate} State={producedmaterial.State}");
		}
		producedmaterial.Prevlotid = producedmaterial.Lotid;
		producedmaterial.Lotid = null;
		producedmaterial.Prevstate = producedmaterial.State;
		producedmaterial.State = "Terminated";
		parentProducedMaterial.CopyCommonFieldUpdatePrev(producedmaterial, systemTime, tid, text);
		parentProducedMaterial.CopyExtensionCollection(producedmaterial);
		list2.Add(producedmaterial);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={producedmaterial.Producedmaterialid} Prevlotid={producedmaterial.Prevlotid} Lotid={producedmaterial.Lotid} Prevstate={producedmaterial.Prevstate} State={producedmaterial.State}");
		}
		List<Producedmaterial> list4 = new List<Producedmaterial>();
		foreach (Producedmaterial producedmaterial2 in childProducedMaterialList)
		{
			Producedmaterial producedmaterial3 = new Producedmaterial();
			producedmaterial2.CopyColumsTo(producedmaterial3);
			ParamChecker.ArgumentNotNull("childLotid", producedmaterial3.Lotid);
			ParamChecker.ArgumentNotNull("childProducedmaterialid", producedmaterial3.Producedmaterialid);
			ParamChecker.ArgumentNotNull("childSiteId", producedmaterial3.Siteid);
			_ = producedmaterial3.Producedmaterialid;
			string lotid2 = producedmaterial3.Lotid;
			if (lotid != lotid2)
			{
				throw new ProducedMaterialNotInSameLotListException(lotid, lotid2);
			}
			producedmaterial3.Parentproducedmaterialid = producedmaterialid;
			producedmaterial3.Prevmaterialtype = producedmaterial.Materialtype;
			producedmaterial3.Prevsubmaterialtype = producedmaterial.Submaterialtype;
			producedmaterial3.Prevproducttype = producedmaterial.Producttype;
			producedmaterial3.Prevgrade = producedmaterial.Grade;
			producedmaterial3.Prevsubmaterialgrade = producedmaterial.Submaterialgrade;
			int subProducedMaterialQty2 = GetSubProducedMaterialQty(dbContext, countableSubproducedMaterialGradeIdList, producedmaterial2);
			producedmaterial3.Prevsubmaterialqty = producedmaterial.Submaterialqty;
			producedmaterial3.Submaterialqty = subProducedMaterialQty2;
			producedmaterial3.Submaterialoriginalqty = subProducedMaterialQty2;
			list4.Add(producedmaterial3);
			producedmaterial3.Activity = text;
			producedmaterial3.Isusable = "Usable";
			producedmaterial2.CopyCommonField(producedmaterial3, systemTime, tid, isCreate: true);
			list3.Add(producedmaterial3);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", $"Producedmaterialid={producedmaterial3.Producedmaterialid} Prevgrade={producedmaterial3.Prevgrade} Grade={producedmaterial3.Grade} Prevsubmaterialqty={producedmaterial3.Prevsubmaterialqty} Submaterialqty={producedmaterial3.Submaterialqty}");
			}
		}
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "Before Execute", lot);
		}
		num2 = LOT.GetLotQty(dbContext, countableProducedMaterialGradeIdList, list4.ToArray());
		num3 = LOT.GetSubProducedMaterialQty(dbContext, countableSubproducedMaterialGradeIdList, list4.ToArray());
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "CalcQty", $"Lotid={lot.Lotid} Plus Qty={num2} Submaterialqty={num3}");
		}
		num4 = -lotQty + num2;
		num5 = -subProducedMaterialQty + num3;
		if (MesLogger.IsDebugEnabled("API"))
		{
			MesLogger.DebugTidApi(tid, "CalcQty", $"Lotid={lot.Lotid} Change Qty={num4} Submaterialqty={num5}");
		}
		lot.Prevqty = lot.Qty;
		lot.Qty = lot.Qty.Add(num4);
		lot.Prevsubmaterialqty = lot.Submaterialqty;
		lot.Submaterialqty = lot.Submaterialqty.Add(num5);
		parentProducedMaterial.CopyCommonFieldUpdatePrev(lot, systemTime, tid, text);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(tid, "After Execute", lot);
		}
		list.Add(lot);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list2.ToArray(), saveHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list3.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static bool ValidateAllowHoldProducedMaterial(IDbContext dbContext, string apiId, int apiVersion, Producedmaterial producedMaterial)
	{
		string ishold = producedMaterial.Ishold;
		string siteid = producedMaterial.Siteid;
		if (ishold != "Y")
		{
			return true;
		}
		return CIM.MES.API.CDS.API.CheckAllowHoldProducedMaterial(dbContext, apiId, apiVersion, siteid);
	}

	public static bool ValidateAllowHoldProducedMaterialBulk(IDbContext dbContext, string apiId, int apiVersion, Producedmaterial[] producedMaterialList)
	{
		string siteid = producedMaterialList[0].Siteid;
		if (producedMaterialList.Where((Producedmaterial v) => v.Ishold == "Y").ToArray().Length == 0)
		{
			return true;
		}
		return CIM.MES.API.CDS.API.CheckAllowHoldProducedMaterial(dbContext, apiId, apiVersion, siteid);
	}
}
