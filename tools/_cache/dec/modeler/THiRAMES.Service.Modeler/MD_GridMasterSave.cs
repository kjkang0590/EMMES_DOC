using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_GridMasterSave : ModelerRuleBiz<Gridmaster>
{
	private int CreateGridMaster(IDbContext dbContext, Gridmaster gridMaster)
	{
		Gridmaster gridMaster4Update = GRIDMASTER.GetGridMaster4Update(dbContext, gridMaster.Menuid, gridMaster.Gridid, gridMaster.Columnname, gridMaster.Siteid);
		if (gridMaster4Update != null)
		{
			UpdateGridMaster(dbContext, gridMaster, gridMaster4Update);
			return 2;
		}
		return GRIDMASTER.UpsertGridMaster(dbContext, RequestType.CREATE, new Gridmaster[1] { gridMaster }, null, saveHist: true);
	}

	private int DeleteGridMaster(IDbContext dbContext, Gridmaster gridMaster)
	{
		return GRIDMASTER.UpsertGridMaster(dbContext, RequestType.DELETE, new Gridmaster[1] { gridMaster }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Gridmaster gridmaster)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateGridMaster(dbContext, gridmaster));
	}

	public override void DeleteAPI(IDbContext dbContext, Gridmaster gridmaster)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteGridMaster(dbContext, gridmaster));
	}

	public override void UpdateAPI(IDbContext dbContext, Gridmaster gridmaster)
	{
		UpdateGridMaster(dbContext, gridmaster, GetGridMaster4Update(dbContext, gridmaster));
	}

	private Gridmaster GetGridMaster4Update(IDbContext dbContext, Gridmaster gridMaster)
	{
		Gridmaster gridMaster4Update = GRIDMASTER.GetGridMaster4Update(dbContext, gridMaster.Menuid, gridMaster.Gridid, gridMaster.Columnname, gridMaster.Siteid);
		if (gridMaster4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "GRIDMASTER", "MENUID: " + gridMaster.Menuid + ", GRIDID: " + gridMaster.Gridid + ", COLUMNNAME: " + gridMaster.Columnname + ", SITEID: " + gridMaster.Siteid);
		}
		return gridMaster4Update;
	}

	private void UpdateGridMaster(IDbContext dbContext, Gridmaster gridMaster, Gridmaster gridMasterCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(gridMaster.Isusable))
		{
			num += GRIDMASTER.UpsertGridMaster(dbContext, RequestType.DELETE, new Gridmaster[1] { gridMaster }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(gridMasterCurrent.Isusable))
		{
			num += GRIDMASTER.UpsertGridMaster(dbContext, RequestType.UNDELETE, new Gridmaster[1] { gridMaster }, null, saveHist: true);
			flag = true;
		}
		num += GRIDMASTER.UpsertGridMaster(dbContext, RequestType.UPDATE, new Gridmaster[1] { gridMaster }, null, saveHist: true);
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
