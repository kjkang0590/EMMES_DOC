using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_ResourceEquipmentRelSave : ModelerRuleBiz<Resourceequipmentrel>
{
	private int CreateResourceEquipmentRel(IDbContext dbContext, Resourceequipmentrel resourceEquipmentRel)
	{
		Resourceequipmentrel resourceEquipmentRel4Update = RESOURCEEQUIPMENTREL.GetResourceEquipmentRel4Update(dbContext, resourceEquipmentRel.Resourceid, resourceEquipmentRel.Equipmentid, resourceEquipmentRel.Siteid);
		if (resourceEquipmentRel4Update != null)
		{
			UpdateResourceEquipmentRel(dbContext, resourceEquipmentRel, resourceEquipmentRel4Update);
			return 2;
		}
		return RESOURCEEQUIPMENTREL.UpsertResourceEquipmentRel(dbContext, RequestType.CREATE, new Resourceequipmentrel[1] { resourceEquipmentRel }, null, saveHist: true);
	}

	private int DeleteResourceEquipmentRel(IDbContext dbContext, Resourceequipmentrel resourceEquipmentRel)
	{
		return RESOURCEEQUIPMENTREL.UpsertResourceEquipmentRel(dbContext, RequestType.DELETE, new Resourceequipmentrel[1] { resourceEquipmentRel }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Resourceequipmentrel resourceequipmentrel)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateResourceEquipmentRel(dbContext, resourceequipmentrel));
	}

	public override void DeleteAPI(IDbContext dbContext, Resourceequipmentrel resourceequipmentrel)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteResourceEquipmentRel(dbContext, resourceequipmentrel));
	}

	public override void UpdateAPI(IDbContext dbContext, Resourceequipmentrel resourceequipmentrel)
	{
		UpdateResourceEquipmentRel(dbContext, resourceequipmentrel, GetResourceEquipmentRel4Update(dbContext, resourceequipmentrel));
	}

	private Resourceequipmentrel GetResourceEquipmentRel4Update(IDbContext dbContext, Resourceequipmentrel resourceEquipmentRel)
	{
		Resourceequipmentrel resourceEquipmentRel4Update = RESOURCEEQUIPMENTREL.GetResourceEquipmentRel4Update(dbContext, resourceEquipmentRel.Resourceid, resourceEquipmentRel.Equipmentid, resourceEquipmentRel.Siteid);
		if (resourceEquipmentRel4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "RESOURCEEQUIPMENTREL", "RESOURCEID: " + resourceEquipmentRel.Resourceid + ", EQUIPMENTID: " + resourceEquipmentRel.Equipmentid + ", SITEID: " + resourceEquipmentRel.Siteid);
		}
		return resourceEquipmentRel4Update;
	}

	private void UpdateResourceEquipmentRel(IDbContext dbContext, Resourceequipmentrel resourceEquipmentRel, Resourceequipmentrel resourceEquipmentRelCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(resourceEquipmentRel.Isusable))
		{
			num += RESOURCEEQUIPMENTREL.UpsertResourceEquipmentRel(dbContext, RequestType.DELETE, new Resourceequipmentrel[1] { resourceEquipmentRel }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(resourceEquipmentRelCurrent.Isusable))
		{
			num += RESOURCEEQUIPMENTREL.UpsertResourceEquipmentRel(dbContext, RequestType.UNDELETE, new Resourceequipmentrel[1] { resourceEquipmentRel }, null, saveHist: true);
			flag = true;
		}
		num += RESOURCEEQUIPMENTREL.UpsertResourceEquipmentRel(dbContext, RequestType.UPDATE, new Resourceequipmentrel[1] { resourceEquipmentRel }, null, saveHist: true);
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
