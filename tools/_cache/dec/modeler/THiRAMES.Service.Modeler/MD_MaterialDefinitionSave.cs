using CIM.MES.API.RDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_MaterialDefinitionSave : ModelerRuleBiz<Materialdefinition>
{
	private int CreateMaterialDefinition(IDbContext dbContext, Materialdefinition materialDefinition)
	{
		Materialdefinition materialDefinition2 = MATERIALDEFINITION.GetMaterialDefinition(dbContext, materialDefinition.Materialdefinitionid, materialDefinition.Siteid);
		if (materialDefinition2 != null)
		{
			UpdateMaterialDefinition(dbContext, materialDefinition, materialDefinition2);
			return 2;
		}
		return MATERIALDEFINITION.UpsertMaterialDefinition(dbContext, RequestType.CREATE, new Materialdefinition[1] { materialDefinition }, null, saveHist: true);
	}

	private int DeleteMaterialDefinition(IDbContext dbContext, Materialdefinition materialDefinition)
	{
		return MATERIALDEFINITION.UpsertMaterialDefinition(dbContext, RequestType.DELETE, new Materialdefinition[1] { materialDefinition }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Materialdefinition materialdefinition)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateMaterialDefinition(dbContext, materialdefinition));
	}

	public override void DeleteAPI(IDbContext dbContext, Materialdefinition materialdefinition)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteMaterialDefinition(dbContext, materialdefinition));
	}

	public override void UpdateAPI(IDbContext dbContext, Materialdefinition materialdefinition)
	{
		UpdateMaterialDefinition(dbContext, materialdefinition, GetMaterialDefinition4Update(dbContext, materialdefinition));
	}

	private Materialdefinition GetMaterialDefinition4Update(IDbContext dbContext, Materialdefinition materialDefinition)
	{
		Materialdefinition materialDefinition4Update = MATERIALDEFINITION.GetMaterialDefinition4Update(dbContext, materialDefinition.Materialdefinitionid, materialDefinition.Siteid);
		if (materialDefinition4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "MATERIALDEFINITION", "MATERIALDEFINITIONID: " + materialDefinition.Materialdefinitionid + ", SITEID: " + materialDefinition.Siteid);
		}
		return materialDefinition4Update;
	}

	private void UpdateMaterialDefinition(IDbContext dbContext, Materialdefinition materialDefinition, Materialdefinition materialDefinitionCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(materialDefinition.Isusable))
		{
			num += MATERIALDEFINITION.UpsertMaterialDefinition(dbContext, RequestType.DELETE, new Materialdefinition[1] { materialDefinition }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(materialDefinitionCurrent.Isusable))
		{
			num += MATERIALDEFINITION.UpsertMaterialDefinition(dbContext, RequestType.UNDELETE, new Materialdefinition[1] { materialDefinition }, null, saveHist: true);
			flag = true;
		}
		num += MATERIALDEFINITION.UpsertMaterialDefinition(dbContext, RequestType.UPDATE, new Materialdefinition[1] { materialDefinition }, null, saveHist: true);
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
