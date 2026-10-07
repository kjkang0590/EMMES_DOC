using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_SiteSave : ModelerRuleBiz<Site>
{
	public override void CreateAPI(IDbContext dbContext, Site site)
	{
		if (SITE.GetSite(dbContext, site.Siteid) != null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_002", "SITE", "SITEID: " + site.Siteid);
		}
		int count = SITE.UpsertSite(dbContext, RequestType.CREATE, new Site[1] { site }, null, saveHist: true);
		DBTransactionCheck(ACTIVITY, 2, count);
	}

	public override void UpdateAPI(IDbContext dbContext, Site site)
	{
		int num = 0;
		if ("UnUsable".Equals(site.Isusable))
		{
			num += SITE.UpsertSite(dbContext, RequestType.DELETE, new Site[1] { site }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		Site site4Update = SITE.GetSite4Update(dbContext, site.Siteid);
		if (site4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_004", "SITE");
		}
		if ("UnUsable".Equals(site4Update.Isusable))
		{
			num += SITE.UpsertSite(dbContext, RequestType.UNDELETE, new Site[1] { site }, null, saveHist: true);
			flag = true;
		}
		num += SITE.UpsertSite(dbContext, RequestType.UPDATE, new Site[1] { site }, null, saveHist: true);
		if (flag)
		{
			DBTransactionCheck(ACTIVITY, 4, num);
		}
		else
		{
			DBTransactionCheck(ACTIVITY, 2, num);
		}
	}

	public override void DeleteAPI(IDbContext dbContext, Site site)
	{
		int count = SITE.UpsertSite(dbContext, RequestType.DELETE, new Site[1] { site }, null, saveHist: true);
		DBTransactionCheck(ACTIVITY, 2, count);
	}
}
