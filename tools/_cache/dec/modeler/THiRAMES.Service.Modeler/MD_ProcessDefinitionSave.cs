using CIM.MES.API.PMS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_ProcessDefinitionSave : ModelerRuleBiz<Processdefinition>
{
	private int CreateProcessDefinition(IDbContext dbContext, Processdefinition processDefinition)
	{
		Processdefinition processDefinition2 = PROCESSDEFINITION.GetProcessDefinition(dbContext, processDefinition.Processdefinitionid, processDefinition.Siteid);
		if (processDefinition2 != null)
		{
			UpdateProcessDefinition(dbContext, processDefinition, processDefinition2);
			return 2;
		}
		return PROCESSDEFINITION.UpsertProcessDefinition(dbContext, RequestType.CREATE, new Processdefinition[1] { processDefinition }, null, saveHist: true);
	}

	private int DeleteProcessDefinition(IDbContext dbContext, Processdefinition processDefinition)
	{
		return PROCESSDEFINITION.UpsertProcessDefinition(dbContext, RequestType.DELETE, new Processdefinition[1] { processDefinition }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Processdefinition processdefinition)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateProcessDefinition(dbContext, processdefinition));
	}

	public override void DeleteAPI(IDbContext dbContext, Processdefinition processdefinition)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteProcessDefinition(dbContext, processdefinition));
	}

	public override void UpdateAPI(IDbContext dbContext, Processdefinition processdefinition)
	{
		UpdateProcessDefinition(dbContext, processdefinition, GetProcessDefinition4Update(dbContext, processdefinition));
	}

	private Processdefinition GetProcessDefinition4Update(IDbContext dbContext, Processdefinition processDefinition)
	{
		Processdefinition processDefinition4Update = PROCESSDEFINITION.GetProcessDefinition4Update(dbContext, processDefinition.Processdefinitionid, processDefinition.Siteid);
		if (processDefinition4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "PROCESSDEFINITION", "PROCESSDEFINITIONID: " + processDefinition.Processdefinitionid + ", SITEID: " + processDefinition.Siteid);
		}
		return processDefinition4Update;
	}

	private void UpdateProcessDefinition(IDbContext dbContext, Processdefinition processDefinition, Processdefinition processDefinitionCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(processDefinition.Isusable))
		{
			num += PROCESSDEFINITION.UpsertProcessDefinition(dbContext, RequestType.DELETE, new Processdefinition[1] { processDefinition }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(processDefinitionCurrent.Isusable))
		{
			num += PROCESSDEFINITION.UpsertProcessDefinition(dbContext, RequestType.UNDELETE, new Processdefinition[1] { processDefinition }, null, saveHist: true);
			flag = true;
		}
		num += PROCESSDEFINITION.UpsertProcessDefinition(dbContext, RequestType.UPDATE, new Processdefinition[1] { processDefinition }, null, saveHist: true);
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
