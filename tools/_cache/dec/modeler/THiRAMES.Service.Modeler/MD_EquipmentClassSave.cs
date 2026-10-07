using CIM.MES.API.RDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_EquipmentClassSave : ModelerRuleBiz<Equipmentclass>
{
	private int CreateEquipmentClass(IDbContext dbContext, Equipmentclass equipmentClass)
	{
		Equipmentclass equipmentClass2 = EQUIPMENTCLASS.GetEquipmentClass(dbContext, equipmentClass.Equipmentclassid, equipmentClass.Siteid);
		if (equipmentClass2 != null)
		{
			UpdateEquipmentClass(dbContext, equipmentClass, equipmentClass2);
			return 2;
		}
		return EQUIPMENTCLASS.UpsertEquipmentClass(dbContext, RequestType.CREATE, new Equipmentclass[1] { equipmentClass }, null, saveHist: true);
	}

	private int DeleteEquipmentClass(IDbContext dbContext, Equipmentclass equipmentClass)
	{
		return EQUIPMENTCLASS.UpsertEquipmentClass(dbContext, RequestType.DELETE, new Equipmentclass[1] { equipmentClass }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Equipmentclass equipmentclass)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateEquipmentClass(dbContext, equipmentclass));
	}

	public override void DeleteAPI(IDbContext dbContext, Equipmentclass equipmentclass)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteEquipmentClass(dbContext, equipmentclass));
	}

	public override void UpdateAPI(IDbContext dbContext, Equipmentclass equipmentclass)
	{
		UpdateEquipmentClass(dbContext, equipmentclass, GetEquipmentClass4Update(dbContext, equipmentclass));
	}

	private Equipmentclass GetEquipmentClass4Update(IDbContext dbContext, Equipmentclass equipmentClass)
	{
		Equipmentclass equipmentClass4Update = EQUIPMENTCLASS.GetEquipmentClass4Update(dbContext, equipmentClass.Equipmentclassid, equipmentClass.Siteid);
		if (equipmentClass4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "EQUIPMENTCLASS", "EQUIPMENTCLASSID: " + equipmentClass.Equipmentclassid + ", SITEID: " + equipmentClass.Siteid);
		}
		return equipmentClass4Update;
	}

	private void UpdateEquipmentClass(IDbContext dbContext, Equipmentclass equipmentClass, Equipmentclass equipmentClassCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(equipmentClass.Isusable))
		{
			num += EQUIPMENTCLASS.UpsertEquipmentClass(dbContext, RequestType.DELETE, new Equipmentclass[1] { equipmentClass }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(equipmentClassCurrent.Isusable))
		{
			num += EQUIPMENTCLASS.UpsertEquipmentClass(dbContext, RequestType.UNDELETE, new Equipmentclass[1] { equipmentClass }, null, saveHist: true);
			flag = true;
		}
		num += EQUIPMENTCLASS.UpsertEquipmentClass(dbContext, RequestType.UPDATE, new Equipmentclass[1] { equipmentClass }, null, saveHist: true);
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
