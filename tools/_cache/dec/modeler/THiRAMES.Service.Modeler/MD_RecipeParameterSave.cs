using CIM.MES.API.PPS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_RecipeParameterSave : ModelerRuleBiz<Recipeparameter>
{
	private int CreateRecipeParameter(IDbContext dbContext, Recipeparameter recipeParameter)
	{
		Recipeparameter recipeParameter2 = RECIPEPARAMETER.GetRecipeParameter(dbContext, recipeParameter.Recipeparameterid, recipeParameter.Recipedefinitionid, recipeParameter.Siteid);
		if (recipeParameter2 != null)
		{
			UpdateRecipeParameter(dbContext, recipeParameter, recipeParameter2);
			return 2;
		}
		return RECIPEPARAMETER.UpsertRecipeParameter(dbContext, RequestType.CREATE, new Recipeparameter[1] { recipeParameter }, null, saveHist: true);
	}

	private int DeleteRecipeParameter(IDbContext dbContext, Recipeparameter recipeParameter)
	{
		return RECIPEPARAMETER.UpsertRecipeParameter(dbContext, RequestType.DELETE, new Recipeparameter[1] { recipeParameter }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Recipeparameter recipeparameter)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateRecipeParameter(dbContext, recipeparameter));
	}

	public override void DeleteAPI(IDbContext dbContext, Recipeparameter recipeparameter)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteRecipeParameter(dbContext, recipeparameter));
	}

	public override void UpdateAPI(IDbContext dbContext, Recipeparameter recipeparameter)
	{
		UpdateRecipeParameter(dbContext, recipeparameter, GetRecipeParameter4Update(dbContext, recipeparameter));
	}

	private Recipeparameter GetRecipeParameter4Update(IDbContext dbContext, Recipeparameter recipeParameter)
	{
		Recipeparameter recipeParameter4Update = RECIPEPARAMETER.GetRecipeParameter4Update(dbContext, recipeParameter.Recipeparameterid, recipeParameter.Recipedefinitionid, recipeParameter.Siteid);
		if (recipeParameter4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "RECIPEPARAMETER", "RECIPEPARAMETERID: " + recipeParameter.Recipeparameterid + ", RECIPEDEFINITIONID: " + recipeParameter.Recipedefinitionid + ", SITEID: " + recipeParameter.Siteid);
		}
		return recipeParameter4Update;
	}

	private void UpdateRecipeParameter(IDbContext dbContext, Recipeparameter recipeParameter, Recipeparameter recipeParameterCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(recipeParameter.Isusable))
		{
			num += RECIPEPARAMETER.UpsertRecipeParameter(dbContext, RequestType.DELETE, new Recipeparameter[1] { recipeParameter }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(recipeParameterCurrent.Isusable))
		{
			num += RECIPEPARAMETER.UpsertRecipeParameter(dbContext, RequestType.UNDELETE, new Recipeparameter[1] { recipeParameter }, null, saveHist: true);
			flag = true;
		}
		num += RECIPEPARAMETER.UpsertRecipeParameter(dbContext, RequestType.UPDATE, new Recipeparameter[1] { recipeParameter }, null, saveHist: true);
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
