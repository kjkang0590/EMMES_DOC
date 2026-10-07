using CIM.MES.API.PMS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_ProcessNodeSave : ModelerRuleBiz<Processnode>
{
	private int CreateProcessNode(IDbContext dbContext, Processnode processNode)
	{
		Processnode processNode2 = PROCESSNODE.GetProcessNode(dbContext, processNode.Processnodeid, processNode.Siteid);
		if (processNode2 != null)
		{
			UpdateProcessNode(dbContext, processNode, processNode2);
			return 2;
		}
		return PROCESSNODE.UpsertProcessNode(dbContext, RequestType.CREATE, new Processnode[1] { processNode }, null, saveHist: true);
	}

	private int DeleteProcessNode(IDbContext dbContext, Processnode processNode)
	{
		return PROCESSNODE.UpsertProcessNode(dbContext, RequestType.DELETE, new Processnode[1] { processNode }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Processnode processnode)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateProcessNode(dbContext, processnode));
	}

	public override void DeleteAPI(IDbContext dbContext, Processnode processnode)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteProcessNode(dbContext, processnode));
	}

	public override void UpdateAPI(IDbContext dbContext, Processnode processnode)
	{
		UpdateProcessNode(dbContext, processnode, GetProcessNode4Update(dbContext, processnode));
	}

	private Processnode GetProcessNode4Update(IDbContext dbContext, Processnode processNode)
	{
		Processnode processNode4Update = PROCESSNODE.GetProcessNode4Update(dbContext, processNode.Processnodeid, processNode.Siteid);
		if (processNode4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "PROCESSNODE", "PROCESSNODEID: " + processNode.Processnodeid + ", SITEID: " + processNode.Siteid);
		}
		return processNode4Update;
	}

	private void UpdateProcessNode(IDbContext dbContext, Processnode processNode, Processnode processNodeCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(processNode.Isusable))
		{
			num += PROCESSNODE.UpsertProcessNode(dbContext, RequestType.DELETE, new Processnode[1] { processNode }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(processNodeCurrent.Isusable))
		{
			num += PROCESSNODE.UpsertProcessNode(dbContext, RequestType.UNDELETE, new Processnode[1] { processNode }, null, saveHist: true);
			flag = true;
		}
		num += PROCESSNODE.UpsertProcessNode(dbContext, RequestType.UPDATE, new Processnode[1] { processNode }, null, saveHist: true);
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
