using CIM.MES.API.PMS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_ProcessSegmentRuleClsRelSave : ModelerRuleBiz<Processsegmentruleclsrel>
{
	private int CreateProcessSegmentRuleClsRel(IDbContext dbContext, Processsegmentruleclsrel processSegmentRuleClsRel)
	{
		Processsegmentruleclsrel processSegmentRuleClsRel2 = PROCESSSEGMENTRULECLSREL.GetProcessSegmentRuleClsRel(dbContext, processSegmentRuleClsRel.Processsegmentruleclsid, processSegmentRuleClsRel.Processsegmentruleid, processSegmentRuleClsRel.Siteid);
		if (processSegmentRuleClsRel2 != null)
		{
			UpdateProcessSegmentRuleClsRel(dbContext, processSegmentRuleClsRel, processSegmentRuleClsRel2);
			return 2;
		}
		return PROCESSSEGMENTRULECLSREL.UpsertProcessSegmentRuleClsRel(dbContext, RequestType.CREATE, new Processsegmentruleclsrel[1] { processSegmentRuleClsRel }, null, saveHist: false);
	}

	private int DeleteProcessSegmentRuleClsRel(IDbContext dbContext, Processsegmentruleclsrel processSegmentRuleClsRel)
	{
		return PROCESSSEGMENTRULECLSREL.UpsertProcessSegmentRuleClsRel(dbContext, RequestType.DELETE, new Processsegmentruleclsrel[1] { processSegmentRuleClsRel }, null, saveHist: false);
	}

	public override void CreateAPI(IDbContext dbContext, Processsegmentruleclsrel processsegmentruleclsrel)
	{
		DBTransactionCheck(ACTIVITY, 1, CreateProcessSegmentRuleClsRel(dbContext, processsegmentruleclsrel));
	}

	public override void DeleteAPI(IDbContext dbContext, Processsegmentruleclsrel processsegmentruleclsrel)
	{
		DBTransactionCheck(ACTIVITY, 1, DeleteProcessSegmentRuleClsRel(dbContext, processsegmentruleclsrel));
	}

	public override void UpdateAPI(IDbContext dbContext, Processsegmentruleclsrel processsegmentruleclsrel)
	{
		UpdateProcessSegmentRuleClsRel(dbContext, processsegmentruleclsrel, GetProcessSegmentRuleClsRel4Update(dbContext, processsegmentruleclsrel));
	}

	private Processsegmentruleclsrel GetProcessSegmentRuleClsRel4Update(IDbContext dbContext, Processsegmentruleclsrel processSegmentRuleClsRel)
	{
		Processsegmentruleclsrel processSegmentRuleClsRel4Update = PROCESSSEGMENTRULECLSREL.GetProcessSegmentRuleClsRel4Update(dbContext, processSegmentRuleClsRel.Processsegmentruleclsid, processSegmentRuleClsRel.Processsegmentruleid, processSegmentRuleClsRel.Siteid);
		if (processSegmentRuleClsRel4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "PROCESSSEGMENTRULECLSREL", "PROCESSSEGMENTRULECLSID: " + processSegmentRuleClsRel.Processsegmentruleclsid + ", PROCESSSEGMENTRULEID: " + processSegmentRuleClsRel.Processsegmentruleid + ", SITEID: " + processSegmentRuleClsRel.Siteid);
		}
		return processSegmentRuleClsRel4Update;
	}

	private void UpdateProcessSegmentRuleClsRel(IDbContext dbContext, Processsegmentruleclsrel processSegmentRuleClsRel, Processsegmentruleclsrel processSegmentRuleClsRelCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(processSegmentRuleClsRel.Isusable))
		{
			num += PROCESSSEGMENTRULECLSREL.UpsertProcessSegmentRuleClsRel(dbContext, RequestType.DELETE, new Processsegmentruleclsrel[1] { processSegmentRuleClsRel }, null, saveHist: false);
			DBTransactionCheck(ACTIVITY, 1, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(processSegmentRuleClsRelCurrent.Isusable))
		{
			num += PROCESSSEGMENTRULECLSREL.UpsertProcessSegmentRuleClsRel(dbContext, RequestType.UNDELETE, new Processsegmentruleclsrel[1] { processSegmentRuleClsRel }, null, saveHist: false);
			flag = true;
		}
		num += PROCESSSEGMENTRULECLSREL.UpsertProcessSegmentRuleClsRel(dbContext, RequestType.UPDATE, new Processsegmentruleclsrel[1] { processSegmentRuleClsRel }, null, saveHist: false);
		if (flag)
		{
			DBTransactionCheck(ACTIVITY, 2, num);
		}
		else
		{
			DBTransactionCheck(ACTIVITY, 1, num);
		}
	}
}
