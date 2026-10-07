using CIM.MES.API.PMS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_ProcessSegmentEquipmentRelSave : ModelerRuleBiz<Processsegmentequipmentrel>
{
	private int CreateProcessSegmentEquipmentRel(IDbContext dbContext, Processsegmentequipmentrel processSegmentEquipmentRel)
	{
		Processsegmentequipmentrel processSegmentEquipmentRel2 = PROCESSSEGMENTEQUIPMENTREL.GetProcessSegmentEquipmentRel(dbContext, processSegmentEquipmentRel.Processsegmentid, processSegmentEquipmentRel.Equipmentid, processSegmentEquipmentRel.Siteid);
		if (processSegmentEquipmentRel2 != null)
		{
			UpdateProcessSegmentEquipmentRel(dbContext, processSegmentEquipmentRel, processSegmentEquipmentRel2);
			return 2;
		}
		return PROCESSSEGMENTEQUIPMENTREL.UpsertProcessSegmentEquipmentRel(dbContext, RequestType.CREATE, new Processsegmentequipmentrel[1] { processSegmentEquipmentRel }, null, saveHist: false);
	}

	private int DeleteProcessSegmentEquipmentRel(IDbContext dbContext, Processsegmentequipmentrel processSegmentEquipmentRel)
	{
		return PROCESSSEGMENTEQUIPMENTREL.UpsertProcessSegmentEquipmentRel(dbContext, RequestType.DELETE, new Processsegmentequipmentrel[1] { processSegmentEquipmentRel }, null, saveHist: false);
	}

	public override void CreateAPI(IDbContext dbContext, Processsegmentequipmentrel processsegmentequipmentrel)
	{
		DBTransactionCheck(ACTIVITY, 1, CreateProcessSegmentEquipmentRel(dbContext, processsegmentequipmentrel));
	}

	public override void DeleteAPI(IDbContext dbContext, Processsegmentequipmentrel processsegmentequipmentrel)
	{
		DBTransactionCheck(ACTIVITY, 1, DeleteProcessSegmentEquipmentRel(dbContext, processsegmentequipmentrel));
	}

	public override void UpdateAPI(IDbContext dbContext, Processsegmentequipmentrel processsegmentequipmentrel)
	{
		UpdateProcessSegmentEquipmentRel(dbContext, processsegmentequipmentrel, GetProcessSegmentEquipmentRel4Update(dbContext, processsegmentequipmentrel));
	}

	private Processsegmentequipmentrel GetProcessSegmentEquipmentRel4Update(IDbContext dbContext, Processsegmentequipmentrel processSegmentEquipmentRel)
	{
		Processsegmentequipmentrel processSegmentEquipmentRel4Update = PROCESSSEGMENTEQUIPMENTREL.GetProcessSegmentEquipmentRel4Update(dbContext, processSegmentEquipmentRel.Processsegmentid, processSegmentEquipmentRel.Equipmentid, processSegmentEquipmentRel.Siteid);
		if (processSegmentEquipmentRel4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "PROCESSSEGMENTEQUIPMENTREL", "PROCESSSEGMENTID: " + processSegmentEquipmentRel.Processsegmentid + ", EQUIPMENTID: " + processSegmentEquipmentRel.Equipmentid + ", SITEID: " + processSegmentEquipmentRel.Siteid);
		}
		return processSegmentEquipmentRel4Update;
	}

	private void UpdateProcessSegmentEquipmentRel(IDbContext dbContext, Processsegmentequipmentrel processSegmentEquipmentRel, Processsegmentequipmentrel processSegmentEquipmentRelCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(processSegmentEquipmentRel.Isusable))
		{
			num += PROCESSSEGMENTEQUIPMENTREL.UpsertProcessSegmentEquipmentRel(dbContext, RequestType.DELETE, new Processsegmentequipmentrel[1] { processSegmentEquipmentRel }, null, saveHist: false);
			DBTransactionCheck(ACTIVITY, 1, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(processSegmentEquipmentRelCurrent.Isusable))
		{
			num += PROCESSSEGMENTEQUIPMENTREL.UpsertProcessSegmentEquipmentRel(dbContext, RequestType.UNDELETE, new Processsegmentequipmentrel[1] { processSegmentEquipmentRel }, null, saveHist: false);
			flag = true;
		}
		num += PROCESSSEGMENTEQUIPMENTREL.UpsertProcessSegmentEquipmentRel(dbContext, RequestType.UPDATE, new Processsegmentequipmentrel[1] { processSegmentEquipmentRel }, null, saveHist: false);
		if (flag)
		{
			DBTransactionCheck(ACTIVITY, 2, num);
		}
		else
		{
			DBTransactionCheck(ACTIVITY, 1, num);
		}
	}
}
