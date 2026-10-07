using CIM.MES.API.PMS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_ProcessSegmentRuleSave : ModelerRuleBiz<Processsegmentrule>
{
	private int CreateProcessSegmentRule(IDbContext dbContext, Processsegmentrule processSegmentRule)
	{
		Processsegmentrule processSegmentRule2 = PROCESSSEGMENTRULE.GetProcessSegmentRule(dbContext, processSegmentRule.Processsegmentruleid, processSegmentRule.Siteid);
		if (processSegmentRule2 != null)
		{
			UpdateProcessSegmentRule(dbContext, processSegmentRule, processSegmentRule2);
			return 2;
		}
		return PROCESSSEGMENTRULE.UpsertProcessSegmentRule(dbContext, RequestType.CREATE, new Processsegmentrule[1] { processSegmentRule }, null, saveHist: true);
	}

	private int DeleteProcessSegmentRule(IDbContext dbContext, Processsegmentrule processSegmentRule)
	{
		return PROCESSSEGMENTRULE.UpsertProcessSegmentRule(dbContext, RequestType.DELETE, new Processsegmentrule[1] { processSegmentRule }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Processsegmentrule processsegmentrule)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateProcessSegmentRule(dbContext, processsegmentrule));
	}

	public override void DeleteAPI(IDbContext dbContext, Processsegmentrule processsegmentrule)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteProcessSegmentRule(dbContext, processsegmentrule));
	}

	public override void UpdateAPI(IDbContext dbContext, Processsegmentrule processsegmentrule)
	{
		UpdateProcessSegmentRule(dbContext, processsegmentrule, GetProcessSegmentRule4Update(dbContext, processsegmentrule));
	}

	private Processsegmentrule GetProcessSegmentRule4Update(IDbContext dbContext, Processsegmentrule processSegmentRule)
	{
		Processsegmentrule processSegmentRule4Update = PROCESSSEGMENTRULE.GetProcessSegmentRule4Update(dbContext, processSegmentRule.Processsegmentruleid, processSegmentRule.Siteid);
		if (processSegmentRule4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "PROCESSSEGMENTRULE", "PROCESSSEGMENTRULEID: " + processSegmentRule.Processsegmentruleid + ", SITEID: " + processSegmentRule.Siteid);
		}
		return processSegmentRule4Update;
	}

	private void UpdateProcessSegmentRule(IDbContext dbContext, Processsegmentrule processSegmentRule, Processsegmentrule processSegmentRuleCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(processSegmentRule.Isusable))
		{
			num += PROCESSSEGMENTRULE.UpsertProcessSegmentRule(dbContext, RequestType.DELETE, new Processsegmentrule[1] { processSegmentRule }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(processSegmentRuleCurrent.Isusable))
		{
			num += PROCESSSEGMENTRULE.UpsertProcessSegmentRule(dbContext, RequestType.UNDELETE, new Processsegmentrule[1] { processSegmentRule }, null, saveHist: true);
			flag = true;
		}
		num += PROCESSSEGMENTRULE.UpsertProcessSegmentRule(dbContext, RequestType.UPDATE, new Processsegmentrule[1] { processSegmentRule }, null, saveHist: true);
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
