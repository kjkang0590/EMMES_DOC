using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_ConstantDefinitionSave : ModelerRuleBiz<Constantdefinition>
{
	private int CreateConstantDefinition(IDbContext dbContext, Constantdefinition constantdefinition)
	{
		Constantdefinition constantDefinition4Update = CONSTANTDEFINITION.GetConstantDefinition4Update(dbContext, constantdefinition.Constantid, constantdefinition.Product, constantdefinition.Siteid);
		if (constantDefinition4Update != null)
		{
			UpdateConstantDefinition(dbContext, constantdefinition, constantDefinition4Update);
			return 2;
		}
		return CONSTANTDEFINITION.UpsertConstantDefinition(dbContext, RequestType.CREATE, new Constantdefinition[1] { constantdefinition }, null, saveHist: true);
	}

	private int DeleteConstantDefinition(IDbContext dbContext, Constantdefinition constantDefinition)
	{
		return CONSTANTDEFINITION.UpsertConstantDefinition(dbContext, RequestType.DELETE, new Constantdefinition[1] { constantDefinition }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Constantdefinition constantdefinition)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateConstantDefinition(dbContext, constantdefinition));
	}

	public override void DeleteAPI(IDbContext dbContext, Constantdefinition constantdefinition)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteConstantDefinition(dbContext, constantdefinition));
	}

	public override void UpdateAPI(IDbContext dbContext, Constantdefinition constantdefinition)
	{
		UpdateConstantDefinition(dbContext, constantdefinition, GetConstantDefinition4Update(dbContext, constantdefinition));
	}

	private Constantdefinition GetConstantDefinition4Update(IDbContext dbContext, Constantdefinition constantDefinition)
	{
		Constantdefinition constantDefinition4Update = CONSTANTDEFINITION.GetConstantDefinition4Update(dbContext, constantDefinition.Constantid, constantDefinition.Product, constantDefinition.Siteid);
		if (constantDefinition4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_004", "CONSTANTDEFINITION");
		}
		return constantDefinition4Update;
	}

	private void UpdateConstantDefinition(IDbContext dbContext, Constantdefinition constantDefinition, Constantdefinition constantDefinitionCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(constantDefinition.Isusable))
		{
			num += CONSTANTDEFINITION.UpsertConstantDefinition(dbContext, RequestType.DELETE, new Constantdefinition[1] { constantDefinition }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(constantDefinitionCurrent.Isusable))
		{
			num += CONSTANTDEFINITION.UpsertConstantDefinition(dbContext, RequestType.UNDELETE, new Constantdefinition[1] { constantDefinition }, null, saveHist: true);
			flag = true;
		}
		num += CONSTANTDEFINITION.UpsertConstantDefinition(dbContext, RequestType.UPDATE, new Constantdefinition[1] { constantDefinition }, null, saveHist: true);
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
