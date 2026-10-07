using CIM.MES.API.PPS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_ProductProcessRelSave : ModelerRuleBiz<Productprocessrel>
{
	private int CreateProductProcessRel(IDbContext dbContext, Productprocessrel productProcessRel)
	{
		Productprocessrel productProcessRel2 = PRODUCTPROCESSREL.GetProductProcessRel(dbContext, productProcessRel.Productdefinitionid, productProcessRel.Processdefinitionid, productProcessRel.Siteid);
		if (productProcessRel2 != null)
		{
			UpdateProductProcessRel(dbContext, productProcessRel, productProcessRel2);
			return 2;
		}
		return PRODUCTPROCESSREL.UpsertProductProcessRel(dbContext, RequestType.CREATE, new Productprocessrel[1] { productProcessRel }, null, saveHist: false);
	}

	private int DeleteProductProcessRel(IDbContext dbContext, Productprocessrel productProcessRel)
	{
		return PRODUCTPROCESSREL.UpsertProductProcessRel(dbContext, RequestType.DELETE, new Productprocessrel[1] { productProcessRel }, null, saveHist: false);
	}

	public override void CreateAPI(IDbContext dbContext, Productprocessrel productprocessrel)
	{
		DBTransactionCheck(ACTIVITY, 1, CreateProductProcessRel(dbContext, productprocessrel));
	}

	public override void DeleteAPI(IDbContext dbContext, Productprocessrel productprocessrel)
	{
		DBTransactionCheck(ACTIVITY, 1, DeleteProductProcessRel(dbContext, productprocessrel));
	}

	public override void UpdateAPI(IDbContext dbContext, Productprocessrel productprocessrel)
	{
		UpdateProductProcessRel(dbContext, productprocessrel, GetProductProcessRel4Update(dbContext, productprocessrel));
	}

	private Productprocessrel GetProductProcessRel4Update(IDbContext dbContext, Productprocessrel productProcessRel)
	{
		Productprocessrel productProcessRel4Update = PRODUCTPROCESSREL.GetProductProcessRel4Update(dbContext, productProcessRel.Productdefinitionid, productProcessRel.Processdefinitionid, productProcessRel.Siteid);
		if (productProcessRel4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "PRODUCTPROCESSREL", "PRODUCTDEFINITIONID: " + productProcessRel.Productdefinitionid + ", PROCESSDEFINITIONID: " + productProcessRel.Processdefinitionid + ", SITEID: " + productProcessRel.Siteid);
		}
		return productProcessRel4Update;
	}

	private void UpdateProductProcessRel(IDbContext dbContext, Productprocessrel productProcessRel, Productprocessrel productProcessRelCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(productProcessRel.Isusable))
		{
			num += PRODUCTPROCESSREL.UpsertProductProcessRel(dbContext, RequestType.DELETE, new Productprocessrel[1] { productProcessRel }, null, saveHist: false);
			DBTransactionCheck(ACTIVITY, 1, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(productProcessRelCurrent.Isusable))
		{
			num += PRODUCTPROCESSREL.UpsertProductProcessRel(dbContext, RequestType.UNDELETE, new Productprocessrel[1] { productProcessRel }, null, saveHist: false);
			flag = true;
		}
		num += PRODUCTPROCESSREL.UpsertProductProcessRel(dbContext, RequestType.UPDATE, new Productprocessrel[1] { productProcessRel }, null, saveHist: false);
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
