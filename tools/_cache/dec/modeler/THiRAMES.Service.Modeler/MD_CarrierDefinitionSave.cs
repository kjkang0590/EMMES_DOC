using CIM.MES.API.RDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_CarrierDefinitionSave : ModelerRuleBiz<Carrierdefinition>
{
	private int CreateCarrierDefinition(IDbContext dbContext, Carrierdefinition carrierDefinition)
	{
		Carrierdefinition carrierDefinition2 = CARRIERDEFINITION.GetCarrierDefinition(dbContext, carrierDefinition.Carrierdefinitionid, carrierDefinition.Siteid);
		if (carrierDefinition2 != null)
		{
			UpdateCarrierDefinition(dbContext, carrierDefinition, carrierDefinition2);
			return 2;
		}
		return CARRIERDEFINITION.UpsertCarrierDefinition(dbContext, RequestType.CREATE, new Carrierdefinition[1] { carrierDefinition }, null, saveHist: true);
	}

	private int DeleteCarrierDefinition(IDbContext dbContext, Carrierdefinition carrierDefinition)
	{
		return CARRIERDEFINITION.UpsertCarrierDefinition(dbContext, RequestType.DELETE, new Carrierdefinition[1] { carrierDefinition }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Carrierdefinition carrierdefinition)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateCarrierDefinition(dbContext, carrierdefinition));
	}

	public override void DeleteAPI(IDbContext dbContext, Carrierdefinition carrierdefinition)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteCarrierDefinition(dbContext, carrierdefinition));
	}

	public override void UpdateAPI(IDbContext dbContext, Carrierdefinition carrierdefinition)
	{
		UpdateCarrierDefinition(dbContext, carrierdefinition, GetCarrierDefinition4Update(dbContext, carrierdefinition));
	}

	private Carrierdefinition GetCarrierDefinition4Update(IDbContext dbContext, Carrierdefinition carrierDefinition)
	{
		Carrierdefinition carrierDefinition4Update = CARRIERDEFINITION.GetCarrierDefinition4Update(dbContext, carrierDefinition.Carrierdefinitionid, carrierDefinition.Siteid);
		if (carrierDefinition4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "CARRIERDEFINITION", "CARRIERDEFINITIONID: " + carrierDefinition.Carrierdefinitionid + ", SITEID: " + carrierDefinition.Siteid);
		}
		return carrierDefinition4Update;
	}

	private void UpdateCarrierDefinition(IDbContext dbContext, Carrierdefinition carrierDefinition, Carrierdefinition carrierDefinitionCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(carrierDefinition.Isusable))
		{
			num += CARRIERDEFINITION.UpsertCarrierDefinition(dbContext, RequestType.DELETE, new Carrierdefinition[1] { carrierDefinition }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(carrierDefinitionCurrent.Isusable))
		{
			num += CARRIERDEFINITION.UpsertCarrierDefinition(dbContext, RequestType.UNDELETE, new Carrierdefinition[1] { carrierDefinition }, null, saveHist: true);
			flag = true;
		}
		num += CARRIERDEFINITION.UpsertCarrierDefinition(dbContext, RequestType.UPDATE, new Carrierdefinition[1] { carrierDefinition }, null, saveHist: true);
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
