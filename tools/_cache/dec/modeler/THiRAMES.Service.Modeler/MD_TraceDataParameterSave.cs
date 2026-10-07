using CIM.MES.API.DAS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_TraceDataParameterSave : ModelerRuleBiz<Tracedataparameter>
{
	private int CreateTraceDataParameter(IDbContext dbContext, Tracedataparameter traceDataParameter)
	{
		Tracedataparameter traceDataParameter2 = TRACEDATAPARAMETER.GetTraceDataParameter(dbContext, traceDataParameter.Tracedataparameterid, traceDataParameter.Tracedatadefinitionid, traceDataParameter.Siteid);
		if (traceDataParameter2 != null)
		{
			UpdateTraceDataParameter(dbContext, traceDataParameter, traceDataParameter2);
			return 2;
		}
		return TRACEDATAPARAMETER.UpsertTraceDataParameter(dbContext, RequestType.CREATE, new Tracedataparameter[1] { traceDataParameter }, null, saveHist: true);
	}

	private int DeleteTraceDataParameter(IDbContext dbContext, Tracedataparameter traceDataParameter)
	{
		return TRACEDATAPARAMETER.UpsertTraceDataParameter(dbContext, RequestType.DELETE, new Tracedataparameter[1] { traceDataParameter }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Tracedataparameter tracedataparameter)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateTraceDataParameter(dbContext, tracedataparameter));
	}

	public override void DeleteAPI(IDbContext dbContext, Tracedataparameter tracedataparameter)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteTraceDataParameter(dbContext, tracedataparameter));
	}

	public override void UpdateAPI(IDbContext dbContext, Tracedataparameter tracedataparameter)
	{
		UpdateTraceDataParameter(dbContext, tracedataparameter, GetTraceDataParameter4Update(dbContext, tracedataparameter));
	}

	private Tracedataparameter GetTraceDataParameter4Update(IDbContext dbContext, Tracedataparameter traceDataParameter)
	{
		Tracedataparameter traceDataParameter4Update = TRACEDATAPARAMETER.GetTraceDataParameter4Update(dbContext, traceDataParameter.Tracedataparameterid, traceDataParameter.Tracedatadefinitionid, traceDataParameter.Siteid);
		if (traceDataParameter4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "TRACEDATAPARAMETER", "TRACEDATAPARAMETERID: " + traceDataParameter.Tracedataparameterid + ", TRACEDATADEFINITIONID: " + traceDataParameter.Tracedatadefinitionid + ", SITEID: " + traceDataParameter.Siteid);
		}
		return traceDataParameter4Update;
	}

	private void UpdateTraceDataParameter(IDbContext dbContext, Tracedataparameter traceDataParameter, Tracedataparameter traceDataParameterCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(traceDataParameter.Isusable))
		{
			num += TRACEDATAPARAMETER.UpsertTraceDataParameter(dbContext, RequestType.DELETE, new Tracedataparameter[1] { traceDataParameter }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(traceDataParameterCurrent.Isusable))
		{
			num += TRACEDATAPARAMETER.UpsertTraceDataParameter(dbContext, RequestType.UNDELETE, new Tracedataparameter[1] { traceDataParameter }, null, saveHist: true);
			flag = true;
		}
		num += TRACEDATAPARAMETER.UpsertTraceDataParameter(dbContext, RequestType.UPDATE, new Tracedataparameter[1] { traceDataParameter }, null, saveHist: true);
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
