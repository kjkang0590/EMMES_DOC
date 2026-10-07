using CIM.MES.API.RDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_SpartDefinitionSave : ModelerRuleBiz<Spartdefinition>
{
	private int CreateSpartDefinition(IDbContext dbContext, Spartdefinition spartDefinition)
	{
		Spartdefinition spartDefinition2 = SPARTDEFINITION.GetSpartDefinition(dbContext, spartDefinition.Spartdefinitionid, spartDefinition.Siteid);
		if (spartDefinition2 != null)
		{
			UpdateSpartDefinition(dbContext, spartDefinition, spartDefinition2);
			return 2;
		}
		return SPARTDEFINITION.UpsertSpartDefinition(dbContext, RequestType.CREATE, new Spartdefinition[1] { spartDefinition }, null, saveHist: true);
	}

	private int DeleteSpartDefinition(IDbContext dbContext, Spartdefinition spartDefinition)
	{
		return SPARTDEFINITION.UpsertSpartDefinition(dbContext, RequestType.DELETE, new Spartdefinition[1] { spartDefinition }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Spartdefinition spartdefinition)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateSpartDefinition(dbContext, spartdefinition));
	}

	public override void DeleteAPI(IDbContext dbContext, Spartdefinition spartdefinition)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteSpartDefinition(dbContext, spartdefinition));
	}

	public override void UpdateAPI(IDbContext dbContext, Spartdefinition spartdefinition)
	{
		UpdateSpartDefinition(dbContext, spartdefinition, GetSpartDefinition4Update(dbContext, spartdefinition));
	}

	private Spartdefinition GetSpartDefinition4Update(IDbContext dbContext, Spartdefinition spartDefinition)
	{
		Spartdefinition spartDefinition4Update = SPARTDEFINITION.GetSpartDefinition4Update(dbContext, spartDefinition.Spartdefinitionid, spartDefinition.Siteid);
		if (spartDefinition4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "SPARTDEFINITION", "SPARTDEFINITIONID: " + spartDefinition.Spartdefinitionid + ", SITEID: " + spartDefinition.Siteid);
		}
		return spartDefinition4Update;
	}

	private void UpdateSpartDefinition(IDbContext dbContext, Spartdefinition spartDefinition, Spartdefinition spartDefinitionCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(spartDefinition.Isusable))
		{
			num += SPARTDEFINITION.UpsertSpartDefinition(dbContext, RequestType.DELETE, new Spartdefinition[1] { spartDefinition }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(spartDefinitionCurrent.Isusable))
		{
			num += SPARTDEFINITION.UpsertSpartDefinition(dbContext, RequestType.UNDELETE, new Spartdefinition[1] { spartDefinition }, null, saveHist: true);
			flag = true;
		}
		num += SPARTDEFINITION.UpsertSpartDefinition(dbContext, RequestType.UPDATE, new Spartdefinition[1] { spartDefinition }, null, saveHist: true);
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
