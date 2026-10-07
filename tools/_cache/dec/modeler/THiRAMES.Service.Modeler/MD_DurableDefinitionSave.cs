using CIM.MES.API.RDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_DurableDefinitionSave : ModelerRuleBiz<Durabledefinition>
{
	private int CreateDurableDefinition(IDbContext dbContext, Durabledefinition durableDefinition)
	{
		Durabledefinition durableDefinition2 = DURABLEDEFINITION.GetDurableDefinition(dbContext, durableDefinition.Durabledefinitionid, durableDefinition.Siteid);
		if (durableDefinition2 != null)
		{
			UpdateDurableDefinition(dbContext, durableDefinition, durableDefinition2);
			return 2;
		}
		return DURABLEDEFINITION.UpsertDurableDefinition(dbContext, RequestType.CREATE, new Durabledefinition[1] { durableDefinition }, null, saveHist: true);
	}

	private int DeleteDurableDefinition(IDbContext dbContext, Durabledefinition durableDefinition)
	{
		return DURABLEDEFINITION.UpsertDurableDefinition(dbContext, RequestType.DELETE, new Durabledefinition[1] { durableDefinition }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Durabledefinition durabledefinition)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateDurableDefinition(dbContext, durabledefinition));
	}

	public override void DeleteAPI(IDbContext dbContext, Durabledefinition durabledefinition)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteDurableDefinition(dbContext, durabledefinition));
	}

	public override void UpdateAPI(IDbContext dbContext, Durabledefinition durabledefinition)
	{
		UpdateDurableDefinition(dbContext, durabledefinition, GetDurableDefinition4Update(dbContext, durabledefinition));
	}

	private Durabledefinition GetDurableDefinition4Update(IDbContext dbContext, Durabledefinition durableDefinition)
	{
		Durabledefinition durableDefinition4Update = DURABLEDEFINITION.GetDurableDefinition4Update(dbContext, durableDefinition.Durabledefinitionid, durableDefinition.Siteid);
		if (durableDefinition4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "DURABLEDEFINITION", "DURABLEDEFINITIONID: " + durableDefinition.Durabledefinitionid + ", SITEID: " + durableDefinition.Siteid);
		}
		return durableDefinition4Update;
	}

	private void UpdateDurableDefinition(IDbContext dbContext, Durabledefinition durableDefinition, Durabledefinition durableDefinitionCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(durableDefinition.Isusable))
		{
			num += DURABLEDEFINITION.UpsertDurableDefinition(dbContext, RequestType.DELETE, new Durabledefinition[1] { durableDefinition }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(durableDefinitionCurrent.Isusable))
		{
			num += DURABLEDEFINITION.UpsertDurableDefinition(dbContext, RequestType.UNDELETE, new Durabledefinition[1] { durableDefinition }, null, saveHist: true);
			flag = true;
		}
		num += DURABLEDEFINITION.UpsertDurableDefinition(dbContext, RequestType.UPDATE, new Durabledefinition[1] { durableDefinition }, null, saveHist: true);
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
