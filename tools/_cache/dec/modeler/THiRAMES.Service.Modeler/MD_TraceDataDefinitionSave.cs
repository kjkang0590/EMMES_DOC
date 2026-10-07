using CIM.MES.API.DAS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_TraceDataDefinitionSave : ModelerRuleBiz<Tracedatadefinition>
{
	private int CreateTraceDataDefinition(IDbContext dbContext, Tracedatadefinition traceDataDefinition)
	{
		Tracedatadefinition traceDataDefinition2 = TRACEDATADEFINITION.GetTraceDataDefinition(dbContext, traceDataDefinition.Tracedatadefinitionid, traceDataDefinition.Siteid);
		if (traceDataDefinition2 != null)
		{
			UpdateTraceDataDefinition(dbContext, traceDataDefinition, traceDataDefinition2);
			return 2;
		}
		return TRACEDATADEFINITION.UpsertTraceDataDefinition(dbContext, RequestType.CREATE, new Tracedatadefinition[1] { traceDataDefinition }, null, saveHist: true);
	}

	private int DeleteTraceDataDefinition(IDbContext dbContext, Tracedatadefinition traceDataDefinition)
	{
		return TRACEDATADEFINITION.UpsertTraceDataDefinition(dbContext, RequestType.DELETE, new Tracedatadefinition[1] { traceDataDefinition }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Tracedatadefinition tracedatadefinition)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateTraceDataDefinition(dbContext, tracedatadefinition));
	}

	public override void DeleteAPI(IDbContext dbContext, Tracedatadefinition tracedatadefinition)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteTraceDataDefinition(dbContext, tracedatadefinition));
	}

	public override void UpdateAPI(IDbContext dbContext, Tracedatadefinition tracedatadefinition)
	{
		UpdateTraceDataDefinition(dbContext, tracedatadefinition, GetTraceDataDefinition4Update(dbContext, tracedatadefinition));
	}

	private Tracedatadefinition GetTraceDataDefinition4Update(IDbContext dbContext, Tracedatadefinition traceDataDefinition)
	{
		Tracedatadefinition traceDataDefinition4Update = TRACEDATADEFINITION.GetTraceDataDefinition4Update(dbContext, traceDataDefinition.Tracedatadefinitionid, traceDataDefinition.Siteid);
		if (traceDataDefinition4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "TRACEDATADEFINITION", "TRACEDATADEFINITIONID: " + traceDataDefinition.Tracedatadefinitionid + ", SITEID: " + traceDataDefinition.Siteid);
		}
		return traceDataDefinition4Update;
	}

	private void UpdateTraceDataDefinition(IDbContext dbContext, Tracedatadefinition traceDataDefinition, Tracedatadefinition traceDataDefinitionCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(traceDataDefinition.Isusable))
		{
			num += TRACEDATADEFINITION.UpsertTraceDataDefinition(dbContext, RequestType.DELETE, new Tracedatadefinition[1] { traceDataDefinition }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(traceDataDefinitionCurrent.Isusable))
		{
			num += TRACEDATADEFINITION.UpsertTraceDataDefinition(dbContext, RequestType.UNDELETE, new Tracedatadefinition[1] { traceDataDefinition }, null, saveHist: true);
			flag = true;
		}
		num += TRACEDATADEFINITION.UpsertTraceDataDefinition(dbContext, RequestType.UPDATE, new Tracedatadefinition[1] { traceDataDefinition }, null, saveHist: true);
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
