using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_ResourceDurableRelSave : ModelerRuleBiz<Resourcedurablerel>
{
	private int CreateResourceDurableRel(IDbContext dbContext, Resourcedurablerel resourceDurableRel)
	{
		Resourcedurablerel resourceDurableRel4Update = RESOURCEDURABLEREL.GetResourceDurableRel4Update(dbContext, resourceDurableRel.Resourceid, resourceDurableRel.Durableid, resourceDurableRel.Siteid);
		if (resourceDurableRel4Update != null)
		{
			UpdateResourceDurableRel(dbContext, resourceDurableRel, resourceDurableRel4Update);
			return 2;
		}
		return RESOURCEDURABLEREL.UpsertResourceDurableRel(dbContext, RequestType.CREATE, new Resourcedurablerel[1] { resourceDurableRel }, null, saveHist: true);
	}

	private int DeleteResourceDurableRel(IDbContext dbContext, Resourcedurablerel resourceDurableRel)
	{
		return RESOURCEDURABLEREL.UpsertResourceDurableRel(dbContext, RequestType.DELETE, new Resourcedurablerel[1] { resourceDurableRel }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Resourcedurablerel resourcedurablerel)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateResourceDurableRel(dbContext, resourcedurablerel));
	}

	public override void DeleteAPI(IDbContext dbContext, Resourcedurablerel resourcedurablerel)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteResourceDurableRel(dbContext, resourcedurablerel));
	}

	public override void UpdateAPI(IDbContext dbContext, Resourcedurablerel resourcedurablerel)
	{
		UpdateResourceDurableRel(dbContext, resourcedurablerel, GetResourceDurableRel4Update(dbContext, resourcedurablerel));
	}

	private Resourcedurablerel GetResourceDurableRel4Update(IDbContext dbContext, Resourcedurablerel resourceDurableRel)
	{
		Resourcedurablerel resourceDurableRel4Update = RESOURCEDURABLEREL.GetResourceDurableRel4Update(dbContext, resourceDurableRel.Resourceid, resourceDurableRel.Durableid, resourceDurableRel.Siteid);
		if (resourceDurableRel4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "RESOURCEDURABLEREL", "RESOURCEID: " + resourceDurableRel.Resourceid + ", DURABLEID: " + resourceDurableRel.Durableid + ", SITEID: " + resourceDurableRel.Siteid);
		}
		return resourceDurableRel4Update;
	}

	private void UpdateResourceDurableRel(IDbContext dbContext, Resourcedurablerel resourceDurableRel, Resourcedurablerel resourceDurableRelCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(resourceDurableRel.Isusable))
		{
			num += RESOURCEDURABLEREL.UpsertResourceDurableRel(dbContext, RequestType.DELETE, new Resourcedurablerel[1] { resourceDurableRel }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(resourceDurableRelCurrent.Isusable))
		{
			num += RESOURCEDURABLEREL.UpsertResourceDurableRel(dbContext, RequestType.UNDELETE, new Resourcedurablerel[1] { resourceDurableRel }, null, saveHist: true);
			flag = true;
		}
		num += RESOURCEDURABLEREL.UpsertResourceDurableRel(dbContext, RequestType.UPDATE, new Resourcedurablerel[1] { resourceDurableRel }, null, saveHist: true);
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
