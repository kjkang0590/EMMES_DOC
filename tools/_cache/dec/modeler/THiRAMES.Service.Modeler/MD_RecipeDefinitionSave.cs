using CIM.MES.API.PPS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_RecipeDefinitionSave : ModelerRuleBiz<Recipedefinition>
{
	private int CreateRecipeDefinition(IDbContext dbContext, Recipedefinition recipeDefinition)
	{
		Recipedefinition recipeDefinition2 = RECIPEDEFINITION.GetRecipeDefinition(dbContext, recipeDefinition.Recipedefinitionid, recipeDefinition.Siteid);
		if (recipeDefinition2 != null)
		{
			UpdateRecipeDefinition(dbContext, recipeDefinition, recipeDefinition2);
			return 2;
		}
		return RECIPEDEFINITION.UpsertRecipeDefinition(dbContext, RequestType.CREATE, new Recipedefinition[1] { recipeDefinition }, null, saveHist: true);
	}

	private int DeleteRecipeDefinition(IDbContext dbContext, Recipedefinition recipeDefinition)
	{
		return RECIPEDEFINITION.UpsertRecipeDefinition(dbContext, RequestType.DELETE, new Recipedefinition[1] { recipeDefinition }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Recipedefinition recipedefinition)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateRecipeDefinition(dbContext, recipedefinition));
	}

	public override void DeleteAPI(IDbContext dbContext, Recipedefinition recipedefinition)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteRecipeDefinition(dbContext, recipedefinition));
	}

	public override void UpdateAPI(IDbContext dbContext, Recipedefinition recipedefinition)
	{
		UpdateRecipeDefinition(dbContext, recipedefinition, GetRecipeDefinition4Update(dbContext, recipedefinition));
	}

	private Recipedefinition GetRecipeDefinition4Update(IDbContext dbContext, Recipedefinition recipeDefinition)
	{
		Recipedefinition recipeDefinition4Update = RECIPEDEFINITION.GetRecipeDefinition4Update(dbContext, recipeDefinition.Recipedefinitionid, recipeDefinition.Siteid);
		if (recipeDefinition4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "RECIPEDEFINITION", "RECIPEDEFINITIONID: " + recipeDefinition.Recipedefinitionid + ", SITEID: " + recipeDefinition.Siteid);
		}
		return recipeDefinition4Update;
	}

	private void UpdateRecipeDefinition(IDbContext dbContext, Recipedefinition recipeDefinition, Recipedefinition recipeDefinitionCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(recipeDefinition.Isusable))
		{
			num += RECIPEDEFINITION.UpsertRecipeDefinition(dbContext, RequestType.DELETE, new Recipedefinition[1] { recipeDefinition }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(recipeDefinitionCurrent.Isusable))
		{
			num += RECIPEDEFINITION.UpsertRecipeDefinition(dbContext, RequestType.UNDELETE, new Recipedefinition[1] { recipeDefinition }, null, saveHist: true);
			flag = true;
		}
		num += RECIPEDEFINITION.UpsertRecipeDefinition(dbContext, RequestType.UPDATE, new Recipedefinition[1] { recipeDefinition }, null, saveHist: true);
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
