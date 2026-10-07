using CIM.MES.API.PPS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_BomSave : ModelerRuleBiz<Bom>
{
	private int CreateBom(IDbContext dbContext, Bom bom)
	{
		Bom bom2 = BOM.GetBom(dbContext, bom.Bomid, bom.Siteid);
		if (bom2 != null)
		{
			UpdateBom(dbContext, bom, bom2);
			return 2;
		}
		return BOM.UpsertBom(dbContext, RequestType.CREATE, new Bom[1] { bom }, null, saveHist: true);
	}

	private int DeleteBom(IDbContext dbContext, Bom bom)
	{
		return BOM.UpsertBom(dbContext, RequestType.DELETE, new Bom[1] { bom }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Bom bom)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateBom(dbContext, bom));
	}

	public override void DeleteAPI(IDbContext dbContext, Bom bom)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteBom(dbContext, bom));
	}

	public override void UpdateAPI(IDbContext dbContext, Bom bom)
	{
		UpdateBom(dbContext, bom, GetBom4Update(dbContext, bom));
	}

	private Bom GetBom4Update(IDbContext dbContext, Bom bom)
	{
		Bom bom4Update = BOM.GetBom4Update(dbContext, bom.Bomid, bom.Siteid);
		if (bom4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "BOM", "BOMID: " + bom.Bomid + ", SITEID: " + bom.Siteid);
		}
		return bom4Update;
	}

	private void UpdateBom(IDbContext dbContext, Bom bom, Bom bomCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(bom.Isusable))
		{
			num += BOM.UpsertBom(dbContext, RequestType.DELETE, new Bom[1] { bom }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(bomCurrent.Isusable))
		{
			num += BOM.UpsertBom(dbContext, RequestType.UNDELETE, new Bom[1] { bom }, null, saveHist: true);
			flag = true;
		}
		num += BOM.UpsertBom(dbContext, RequestType.UPDATE, new Bom[1] { bom }, null, saveHist: true);
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
