using CIM.MES.API.PPS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_MbomSave : ModelerRuleBiz<Mbom>
{
	private int CreateMbom(IDbContext dbContext, Mbom mbom)
	{
		Mbom mbom2 = MBOM.GetMbom(dbContext, mbom.Productrulesysid, mbom.Mbomsysid, mbom.Siteid);
		if (mbom2 != null)
		{
			UpdateMbom(dbContext, mbom, mbom2);
			return 2;
		}
		return MBOM.UpsertMbom(dbContext, RequestType.CREATE, new Mbom[1] { mbom }, null, saveHist: true);
	}

	private int DeleteMbom(IDbContext dbContext, Mbom mbom)
	{
		return MBOM.UpsertMbom(dbContext, RequestType.DELETE, new Mbom[1] { mbom }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Mbom mbom)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateMbom(dbContext, mbom));
	}

	public override void DeleteAPI(IDbContext dbContext, Mbom mbom)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteMbom(dbContext, mbom));
	}

	public override void UpdateAPI(IDbContext dbContext, Mbom mbom)
	{
		UpdateMbom(dbContext, mbom, GetMbom4Update(dbContext, mbom));
	}

	private Mbom GetMbom4Update(IDbContext dbContext, Mbom mbom)
	{
		Mbom mbom4Update = MBOM.GetMbom4Update(dbContext, mbom.Productrulesysid, mbom.Mbomsysid, mbom.Siteid);
		if (mbom4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "MBOM", "PRODUCTRULESYSID: " + mbom.Productrulesysid + ", MBOMSYSID: " + mbom.Mbomsysid + ", SITEID: " + mbom.Siteid);
		}
		return mbom4Update;
	}

	private void UpdateMbom(IDbContext dbContext, Mbom mbom, Mbom mbomCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(mbom.Isusable))
		{
			num += MBOM.UpsertMbom(dbContext, RequestType.DELETE, new Mbom[1] { mbom }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(mbomCurrent.Isusable))
		{
			num += MBOM.UpsertMbom(dbContext, RequestType.UNDELETE, new Mbom[1] { mbom }, null, saveHist: true);
			flag = true;
		}
		num += MBOM.UpsertMbom(dbContext, RequestType.UPDATE, new Mbom[1] { mbom }, null, saveHist: true);
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
