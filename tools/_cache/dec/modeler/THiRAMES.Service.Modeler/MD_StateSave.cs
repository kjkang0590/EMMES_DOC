using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_StateSave : ModelerRuleBiz<State>
{
	private int CreateState(IDbContext dbContext, State state)
	{
		State state2 = STATE.GetState(dbContext, state.Statemodelid, state.Stateid, state.Siteid);
		if (state2 != null)
		{
			UpdateState(dbContext, state, state2);
			return 2;
		}
		return STATE.UpsertState(dbContext, RequestType.CREATE, new State[1] { state }, null, saveHist: true);
	}

	private int DeleteState(IDbContext dbContext, State state)
	{
		return STATE.UpsertState(dbContext, RequestType.DELETE, new State[1] { state }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, State state)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateState(dbContext, state));
	}

	public override void DeleteAPI(IDbContext dbContext, State state)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteState(dbContext, state));
	}

	public override void UpdateAPI(IDbContext dbContext, State state)
	{
		UpdateState(dbContext, state, GetState4Update(dbContext, state));
	}

	private State GetState4Update(IDbContext dbContext, State state)
	{
		State state4Update = STATE.GetState4Update(dbContext, state.Statemodelid, state.Stateid, state.Siteid);
		if (state4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_004", "STATE", "STATEMODELID: " + state.Statemodelid + ", STATEID: " + state.Stateid + ", SITEID: " + state.Siteid);
		}
		return state4Update;
	}

	private void UpdateState(IDbContext dbContext, State state, State stateCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(state.Isusable))
		{
			num += STATE.UpsertState(dbContext, RequestType.DELETE, new State[1] { state }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(stateCurrent.Isusable))
		{
			num += STATE.UpsertState(dbContext, RequestType.UNDELETE, new State[1] { state }, null, saveHist: true);
			flag = true;
		}
		num += STATE.UpsertState(dbContext, RequestType.UPDATE, new State[1] { state }, null, saveHist: true);
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
