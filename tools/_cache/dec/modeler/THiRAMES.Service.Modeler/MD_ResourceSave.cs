using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_ResourceSave : ModelerRuleBiz<Resource>
{
	private int CreateResource(IDbContext dbContext, Resource resource)
	{
		Resource resource4Update = RESOURCE.GetResource4Update(dbContext, resource.Resourceid, resource.Siteid);
		if (resource4Update != null)
		{
			UpdateResource(dbContext, resource, resource4Update);
			return 2;
		}
		return RESOURCE.UpsertResource(dbContext, RequestType.CREATE, new Resource[1] { resource }, null, saveHist: true);
	}

	private int DeleteResource(IDbContext dbContext, Resource resource)
	{
		return RESOURCE.UpsertResource(dbContext, RequestType.DELETE, new Resource[1] { resource }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Resource resource)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateResource(dbContext, resource));
	}

	public override void DeleteAPI(IDbContext dbContext, Resource resource)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteResource(dbContext, resource));
	}

	public override void UpdateAPI(IDbContext dbContext, Resource resource)
	{
		UpdateResource(dbContext, resource, GetResource4Update(dbContext, resource));
	}

	private Resource GetResource4Update(IDbContext dbContext, Resource resource)
	{
		Resource resource4Update = RESOURCE.GetResource4Update(dbContext, resource.Resourceid, resource.Siteid);
		if (resource4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "RESOURCE", "RESOURCEID: " + resource.Resourceid + ", SITEID: " + resource.Siteid);
		}
		return resource4Update;
	}

	private void UpdateResource(IDbContext dbContext, Resource resource, Resource resourceCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(resource.Isusable))
		{
			num += RESOURCE.UpsertResource(dbContext, RequestType.DELETE, new Resource[1] { resource }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(resourceCurrent.Isusable))
		{
			num += RESOURCE.UpsertResource(dbContext, RequestType.UNDELETE, new Resource[1] { resource }, null, saveHist: true);
			flag = true;
		}
		num += RESOURCE.UpsertResource(dbContext, RequestType.UPDATE, new Resource[1] { resource }, null, saveHist: true);
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
