using CIM.MES.API.PMS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_ProcessSegmentSave : ModelerRuleBiz<Processsegment>
{
	private int CreateProcessSegment(IDbContext dbContext, Processsegment processSegment)
	{
		Processsegment processSegment2 = PROCESSSEGMENT.GetProcessSegment(dbContext, processSegment.Processsegmentid, processSegment.Siteid);
		if (processSegment2 != null)
		{
			UpdateProcessSegment(dbContext, processSegment, processSegment2);
			return 2;
		}
		return PROCESSSEGMENT.UpsertProcessSegment(dbContext, RequestType.CREATE, new Processsegment[1] { processSegment }, null, saveHist: true);
	}

	private int DeleteProcessSegment(IDbContext dbContext, Processsegment processSegment)
	{
		return PROCESSSEGMENT.UpsertProcessSegment(dbContext, RequestType.DELETE, new Processsegment[1] { processSegment }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Processsegment processsegment)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateProcessSegment(dbContext, processsegment));
	}

	public override void DeleteAPI(IDbContext dbContext, Processsegment processsegment)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteProcessSegment(dbContext, processsegment));
	}

	public override void UpdateAPI(IDbContext dbContext, Processsegment processsegment)
	{
		UpdateProcessSegment(dbContext, processsegment, GetProcessSegment4Update(dbContext, processsegment));
	}

	private Processsegment GetProcessSegment4Update(IDbContext dbContext, Processsegment processSegment)
	{
		Processsegment processSegment4Update = PROCESSSEGMENT.GetProcessSegment4Update(dbContext, processSegment.Processsegmentid, processSegment.Siteid);
		if (processSegment4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "PROCESSSEGMENT", "PROCESSSEGMENTID: " + processSegment.Processsegmentid + ", SITEID: " + processSegment.Siteid);
		}
		return processSegment4Update;
	}

	private void UpdateProcessSegment(IDbContext dbContext, Processsegment processSegment, Processsegment processSegmentCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(processSegment.Isusable))
		{
			num += PROCESSSEGMENT.UpsertProcessSegment(dbContext, RequestType.DELETE, new Processsegment[1] { processSegment }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(processSegmentCurrent.Isusable))
		{
			num += PROCESSSEGMENT.UpsertProcessSegment(dbContext, RequestType.UNDELETE, new Processsegment[1] { processSegment }, null, saveHist: true);
			flag = true;
		}
		num += PROCESSSEGMENT.UpsertProcessSegment(dbContext, RequestType.UPDATE, new Processsegment[1] { processSegment }, null, saveHist: true);
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
