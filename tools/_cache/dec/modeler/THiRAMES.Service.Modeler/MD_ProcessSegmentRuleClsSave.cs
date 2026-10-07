using CIM.MES.API.PMS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_ProcessSegmentRuleClsSave : ModelerRuleBiz<Processsegmentrulecls>
{
	private int CreateProcessSegmentRuleCls(IDbContext dbContext, Processsegmentrulecls processSegmentRuleCls)
	{
		Processsegmentrulecls processSegmentRuleCls2 = PROCESSSEGMENTRULECLS.GetProcessSegmentRuleCls(dbContext, processSegmentRuleCls.Processsegmentruleclsid, processSegmentRuleCls.Siteid);
		if (processSegmentRuleCls2 != null)
		{
			UpdateProcessSegmentRuleCls(dbContext, processSegmentRuleCls, processSegmentRuleCls2);
			return 2;
		}
		return PROCESSSEGMENTRULECLS.UpsertProcessSegmentRuleCls(dbContext, RequestType.CREATE, new Processsegmentrulecls[1] { processSegmentRuleCls }, null, saveHist: true);
	}

	private int DeleteProcessSegmentRuleCls(IDbContext dbContext, Processsegmentrulecls processSegmentRuleCls)
	{
		return PROCESSSEGMENTRULECLS.UpsertProcessSegmentRuleCls(dbContext, RequestType.DELETE, new Processsegmentrulecls[1] { processSegmentRuleCls }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Processsegmentrulecls processsegmentrulecls)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateProcessSegmentRuleCls(dbContext, processsegmentrulecls));
	}

	public override void DeleteAPI(IDbContext dbContext, Processsegmentrulecls processsegmentrulecls)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteProcessSegmentRuleCls(dbContext, processsegmentrulecls));
	}

	public override void UpdateAPI(IDbContext dbContext, Processsegmentrulecls processsegmentrulecls)
	{
		UpdateProcessSegmentRuleCls(dbContext, processsegmentrulecls, GetProcessSegmentRuleCls4Update(dbContext, processsegmentrulecls));
	}

	private Processsegmentrulecls GetProcessSegmentRuleCls4Update(IDbContext dbContext, Processsegmentrulecls processSegmentRuleCls)
	{
		Processsegmentrulecls processSegmentRuleCls4Update = PROCESSSEGMENTRULECLS.GetProcessSegmentRuleCls4Update(dbContext, processSegmentRuleCls.Processsegmentruleclsid, processSegmentRuleCls.Siteid);
		if (processSegmentRuleCls4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "PROCESSSEGMENTRULECLS", "PROCESSSEGMENTRULECLSID: " + processSegmentRuleCls.Processsegmentruleclsid + ", SITEID: " + processSegmentRuleCls.Siteid);
		}
		return processSegmentRuleCls4Update;
	}

	private void UpdateProcessSegmentRuleCls(IDbContext dbContext, Processsegmentrulecls processSegmentRuleCls, Processsegmentrulecls processSegmentRuleClsCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(processSegmentRuleCls.Isusable))
		{
			num += PROCESSSEGMENTRULECLS.UpsertProcessSegmentRuleCls(dbContext, RequestType.DELETE, new Processsegmentrulecls[1] { processSegmentRuleCls }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(processSegmentRuleClsCurrent.Isusable))
		{
			num += PROCESSSEGMENTRULECLS.UpsertProcessSegmentRuleCls(dbContext, RequestType.UNDELETE, new Processsegmentrulecls[1] { processSegmentRuleCls }, null, saveHist: true);
			flag = true;
		}
		num += PROCESSSEGMENTRULECLS.UpsertProcessSegmentRuleCls(dbContext, RequestType.UPDATE, new Processsegmentrulecls[1] { processSegmentRuleCls }, null, saveHist: true);
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
