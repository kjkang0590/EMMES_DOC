using CIM.MES.API.PPS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_ProductRuleSave : ModelerRuleBiz<Productrule>
{
	private int CreateProductRule(IDbContext dbContext, Productrule productRule)
	{
		Productrule productRule2 = PRODUCTRULE.GetProductRule(dbContext, productRule.Productrulesysid, productRule.Siteid);
		if (productRule2 != null)
		{
			UpdateProductRule(dbContext, productRule, productRule2);
			return 2;
		}
		return PRODUCTRULE.UpsertProductRule(dbContext, RequestType.CREATE, new Productrule[1] { productRule }, null, saveHist: true);
	}

	private int DeleteProductRule(IDbContext dbContext, Productrule productRule)
	{
		return PRODUCTRULE.UpsertProductRule(dbContext, RequestType.DELETE, new Productrule[1] { productRule }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Productrule productrule)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateProductRule(dbContext, productrule));
	}

	public override void DeleteAPI(IDbContext dbContext, Productrule productrule)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteProductRule(dbContext, productrule));
	}

	public override void UpdateAPI(IDbContext dbContext, Productrule productrule)
	{
		UpdateProductRule(dbContext, productrule, GetProductRule4Update(dbContext, productrule));
	}

	private Productrule GetProductRule4Update(IDbContext dbContext, Productrule productRule)
	{
		Productrule productRule4Update = PRODUCTRULE.GetProductRule4Update(dbContext, productRule.Productrulesysid, productRule.Siteid);
		if (productRule4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "PRODUCTRULE", "PRODUCTRULESYSID: " + productRule.Productrulesysid + ", SITEID: " + productRule.Siteid);
		}
		return productRule4Update;
	}

	private void UpdateProductRule(IDbContext dbContext, Productrule productRule, Productrule productRuleCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(productRule.Isusable))
		{
			num += PRODUCTRULE.UpsertProductRule(dbContext, RequestType.DELETE, new Productrule[1] { productRule }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(productRuleCurrent.Isusable))
		{
			num += PRODUCTRULE.UpsertProductRule(dbContext, RequestType.UNDELETE, new Productrule[1] { productRule }, null, saveHist: true);
			flag = true;
		}
		num += PRODUCTRULE.UpsertProductRule(dbContext, RequestType.UPDATE, new Productrule[1] { productRule }, null, saveHist: true);
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
