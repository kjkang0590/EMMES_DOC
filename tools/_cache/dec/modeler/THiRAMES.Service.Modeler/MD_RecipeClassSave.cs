using CIM.MES.API.PPS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_RecipeClassSave : ModelerRuleBiz<Recipeclass>
{
	private int CreateRecipeClass(IDbContext dbContext, Recipeclass recipeClass)
	{
		Recipeclass recipeClass2 = RECIPECLASS.GetRecipeClass(dbContext, recipeClass.Recipeclassid, recipeClass.Siteid);
		if (recipeClass2 != null)
		{
			UpdateRecipeClass(dbContext, recipeClass, recipeClass2);
			return 2;
		}
		return RECIPECLASS.UpsertRecipeClass(dbContext, RequestType.CREATE, new Recipeclass[1] { recipeClass }, null, saveHist: true);
	}

	private int DeleteRecipeClass(IDbContext dbContext, Recipeclass recipeClass)
	{
		return RECIPECLASS.UpsertRecipeClass(dbContext, RequestType.DELETE, new Recipeclass[1] { recipeClass }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Recipeclass recipeclass)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateRecipeClass(dbContext, recipeclass));
	}

	public override void DeleteAPI(IDbContext dbContext, Recipeclass recipeclass)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteRecipeClass(dbContext, recipeclass));
	}

	public override void UpdateAPI(IDbContext dbContext, Recipeclass recipeclass)
	{
		UpdateRecipeClass(dbContext, recipeclass, GetRecipeClass4Update(dbContext, recipeclass));
	}

	private Recipeclass GetRecipeClass4Update(IDbContext dbContext, Recipeclass recipeClass)
	{
		Recipeclass recipeClass4Update = RECIPECLASS.GetRecipeClass4Update(dbContext, recipeClass.Recipeclassid, recipeClass.Siteid);
		if (recipeClass4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "RECIPECLASS", "RECIPECLASSID: " + recipeClass.Recipeclassid + ", SITEID: " + recipeClass.Siteid);
		}
		return recipeClass4Update;
	}

	private void UpdateRecipeClass(IDbContext dbContext, Recipeclass recipeClass, Recipeclass recipeClassCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(recipeClass.Isusable))
		{
			num += RECIPECLASS.UpsertRecipeClass(dbContext, RequestType.DELETE, new Recipeclass[1] { recipeClass }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(recipeClassCurrent.Isusable))
		{
			num += RECIPECLASS.UpsertRecipeClass(dbContext, RequestType.UNDELETE, new Recipeclass[1] { recipeClass }, null, saveHist: true);
			flag = true;
		}
		num += RECIPECLASS.UpsertRecipeClass(dbContext, RequestType.UPDATE, new Recipeclass[1] { recipeClass }, null, saveHist: true);
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
