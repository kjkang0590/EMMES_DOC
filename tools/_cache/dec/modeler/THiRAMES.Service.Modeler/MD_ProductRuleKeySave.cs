using CIM.MES.API.PPS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_ProductRuleKeySave : ModelerRuleBiz<Productrulekey>
{
	private int CreateProductRuleKey(IDbContext dbContext, Productrulekey productRuleKey)
	{
		Productrulekey productRuleKey2 = PRODUCTRULEKEY.GetProductRuleKey(dbContext, productRuleKey.Productruletype, productRuleKey.Siteid);
		if (productRuleKey2 != null)
		{
			UpdateProductRuleKey(dbContext, productRuleKey, productRuleKey2);
			return 2;
		}
		return PRODUCTRULEKEY.UpsertProductRuleKey(dbContext, RequestType.CREATE, new Productrulekey[1] { productRuleKey }, null, saveHist: true);
	}

	private int DeleteProductRuleKey(IDbContext dbContext, Productrulekey productRuleKey)
	{
		return PRODUCTRULEKEY.UpsertProductRuleKey(dbContext, RequestType.DELETE, new Productrulekey[1] { productRuleKey }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Productrulekey productrulekey)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateProductRuleKey(dbContext, productrulekey));
	}

	public override void DeleteAPI(IDbContext dbContext, Productrulekey productrulekey)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteProductRuleKey(dbContext, productrulekey));
	}

	public override void UpdateAPI(IDbContext dbContext, Productrulekey productrulekey)
	{
		UpdateProductRuleKey(dbContext, productrulekey, GetProductRuleKey4Update(dbContext, productrulekey));
	}

	private Productrulekey GetProductRuleKey4Update(IDbContext dbContext, Productrulekey productRuleKey)
	{
		Productrulekey productRuleKey4Update = PRODUCTRULEKEY.GetProductRuleKey4Update(dbContext, productRuleKey.Productruletype, productRuleKey.Siteid);
		if (productRuleKey4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "PRODUCTRULEKEY", "PRODUCTRULETYPE: " + productRuleKey.Productruletype + ", SITEID: " + productRuleKey.Siteid);
		}
		return productRuleKey4Update;
	}

	private void UpdateProductRuleKey(IDbContext dbContext, Productrulekey productRuleKey, Productrulekey productRuleKeyCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(productRuleKey.Isusable))
		{
			num += PRODUCTRULEKEY.UpsertProductRuleKey(dbContext, RequestType.DELETE, new Productrulekey[1] { productRuleKey }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(productRuleKeyCurrent.Isusable))
		{
			num += PRODUCTRULEKEY.UpsertProductRuleKey(dbContext, RequestType.UNDELETE, new Productrulekey[1] { productRuleKey }, null, saveHist: true);
			flag = true;
		}
		num += PRODUCTRULEKEY.UpsertProductRuleKey(dbContext, RequestType.UPDATE, new Productrulekey[1] { productRuleKey }, null, saveHist: true);
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
