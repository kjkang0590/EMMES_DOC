using CIM.MES.API.DAS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_ProcessDataDefinitionSave : ModelerRuleBiz<Processdatadefinition>
{
	private int CreateProcessDataDefinition(IDbContext dbContext, Processdatadefinition processDataDefinition)
	{
		Processdatadefinition processDataDefinition2 = PROCESSDATADEFINITION.GetProcessDataDefinition(dbContext, processDataDefinition.Processdatadefinitionid, processDataDefinition.Siteid);
		if (processDataDefinition2 != null)
		{
			UpdateProcessDataDefinition(dbContext, processDataDefinition, processDataDefinition2);
			return 2;
		}
		return PROCESSDATADEFINITION.UpsertProcessDataDefinition(dbContext, RequestType.CREATE, new Processdatadefinition[1] { processDataDefinition }, null, saveHist: true);
	}

	private int DeleteProcessDataDefinition(IDbContext dbContext, Processdatadefinition processDataDefinition)
	{
		return PROCESSDATADEFINITION.UpsertProcessDataDefinition(dbContext, RequestType.DELETE, new Processdatadefinition[1] { processDataDefinition }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Processdatadefinition processdatadefinition)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateProcessDataDefinition(dbContext, processdatadefinition));
	}

	public override void DeleteAPI(IDbContext dbContext, Processdatadefinition processdatadefinition)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteProcessDataDefinition(dbContext, processdatadefinition));
	}

	public override void UpdateAPI(IDbContext dbContext, Processdatadefinition processdatadefinition)
	{
		UpdateProcessDataDefinition(dbContext, processdatadefinition, GetProcessDataDefinition4Update(dbContext, processdatadefinition));
	}

	private Processdatadefinition GetProcessDataDefinition4Update(IDbContext dbContext, Processdatadefinition processDataDefinition)
	{
		Processdatadefinition processDataDefinition4Update = PROCESSDATADEFINITION.GetProcessDataDefinition4Update(dbContext, processDataDefinition.Processdatadefinitionid, processDataDefinition.Siteid);
		if (processDataDefinition4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "PROCESSDATADEFINITION", "PROCESSDATADEFINITIONID: " + processDataDefinition.Processdatadefinitionid + ", SITEID: " + processDataDefinition.Siteid);
		}
		return processDataDefinition4Update;
	}

	private void UpdateProcessDataDefinition(IDbContext dbContext, Processdatadefinition processDataDefinition, Processdatadefinition processDataDefinitionCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(processDataDefinition.Isusable))
		{
			num += PROCESSDATADEFINITION.UpsertProcessDataDefinition(dbContext, RequestType.DELETE, new Processdatadefinition[1] { processDataDefinition }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(processDataDefinitionCurrent.Isusable))
		{
			num += PROCESSDATADEFINITION.UpsertProcessDataDefinition(dbContext, RequestType.UNDELETE, new Processdatadefinition[1] { processDataDefinition }, null, saveHist: true);
			flag = true;
		}
		num += PROCESSDATADEFINITION.UpsertProcessDataDefinition(dbContext, RequestType.UPDATE, new Processdatadefinition[1] { processDataDefinition }, null, saveHist: true);
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
