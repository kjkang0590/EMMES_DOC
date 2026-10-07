using CIM.MES.API.RDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_EquipmentSave : ModelerRuleBiz<Equipment>
{
	private int CreateEquipment(IDbContext dbContext, Equipment equipment)
	{
		Equipment equipment2 = EQUIPMENT.GetEquipment(dbContext, equipment.Equipmentid, equipment.Siteid);
		if (equipment2 != null)
		{
			UpdateEquipment(dbContext, equipment, equipment2);
			return 2;
		}
		return EQUIPMENT.UpsertEquipment(dbContext, RequestType.CREATE, new Equipment[1] { equipment }, null, saveHist: true);
	}

	private int DeleteEquipment(IDbContext dbContext, Equipment equipment)
	{
		return EQUIPMENT.UpsertEquipment(dbContext, RequestType.DELETE, new Equipment[1] { equipment }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Equipment equipment)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateEquipment(dbContext, equipment));
	}

	public override void DeleteAPI(IDbContext dbContext, Equipment equipment)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteEquipment(dbContext, equipment));
	}

	public override void UpdateAPI(IDbContext dbContext, Equipment equipment)
	{
		UpdateEquipment(dbContext, equipment, GetEquipment4Update(dbContext, equipment));
	}

	private Equipment GetEquipment4Update(IDbContext dbContext, Equipment equipment)
	{
		Equipment equipment4Update = EQUIPMENT.GetEquipment4Update(dbContext, equipment.Equipmentid, equipment.Siteid);
		if (equipment4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "EQUIPMENT", "EQUIPMENTID: " + equipment.Equipmentid + ", SITEID: " + equipment.Siteid);
		}
		return equipment4Update;
	}

	private void UpdateEquipment(IDbContext dbContext, Equipment equipment, Equipment equipmentCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(equipment.Isusable))
		{
			num += EQUIPMENT.UpsertEquipment(dbContext, RequestType.DELETE, new Equipment[1] { equipment }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(equipmentCurrent.Isusable))
		{
			num += EQUIPMENT.UpsertEquipment(dbContext, RequestType.UNDELETE, new Equipment[1] { equipment }, null, saveHist: true);
			flag = true;
		}
		num += EQUIPMENT.UpsertEquipment(dbContext, RequestType.UPDATE, new Equipment[1] { equipment }, null, saveHist: true);
		if (flag)
		{
			DBTransactionCheck(ACTIVITY, 4, num);
		}
		else
		{
			DBTransactionCheck(ACTIVITY, 2, num);
		}
	}
}
