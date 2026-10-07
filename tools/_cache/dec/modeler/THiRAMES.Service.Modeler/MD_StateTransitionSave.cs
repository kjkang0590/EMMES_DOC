using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_StateTransitionSave : ModelerRuleBiz<Statetransition>
{
	private int CreateStateTransition(IDbContext dbContext, Statetransition stateTransition)
	{
		Statetransition stateTransition4Update = STATETRANSITION.GetStateTransition4Update(dbContext, stateTransition.Statemodelid, stateTransition.Stateid, stateTransition.Tostateid, stateTransition.Siteid);
		if (stateTransition4Update != null)
		{
			UpdateStateTransition(dbContext, stateTransition, stateTransition4Update);
			return 2;
		}
		return STATETRANSITION.UpsertStateTransition(dbContext, RequestType.CREATE, new Statetransition[1] { stateTransition }, null, saveHist: true);
	}

	private int DeleteStateTransition(IDbContext dbContext, Statetransition stateTransition)
	{
		return STATETRANSITION.UpsertStateTransition(dbContext, RequestType.DELETE, new Statetransition[1] { stateTransition }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Statetransition statetransition)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateStateTransition(dbContext, statetransition));
	}

	public override void DeleteAPI(IDbContext dbContext, Statetransition statetransition)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteStateTransition(dbContext, statetransition));
	}

	public override void UpdateAPI(IDbContext dbContext, Statetransition statetransition)
	{
		UpdateStateTransition(dbContext, statetransition, GetStateTransition4Update(dbContext, statetransition));
	}

	private Statetransition GetStateTransition4Update(IDbContext dbContext, Statetransition stateTransition)
	{
		Statetransition stateTransition4Update = STATETRANSITION.GetStateTransition4Update(dbContext, stateTransition.Statemodelid, stateTransition.Stateid, stateTransition.Tostateid, stateTransition.Siteid);
		if (stateTransition4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "STATETRANSITION", "STATEMODELID: " + stateTransition.Statemodelid + ", STATEID: " + stateTransition.Stateid + ", SITEID: " + stateTransition.Siteid);
		}
		return stateTransition4Update;
	}

	private void UpdateStateTransition(IDbContext dbContext, Statetransition stateTransition, Statetransition stateTransitionCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(stateTransition.Isusable))
		{
			num += STATETRANSITION.UpsertStateTransition(dbContext, RequestType.DELETE, new Statetransition[1] { stateTransition }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(stateTransitionCurrent.Isusable))
		{
			num += STATETRANSITION.UpsertStateTransition(dbContext, RequestType.UNDELETE, new Statetransition[1] { stateTransition }, null, saveHist: true);
			flag = true;
		}
		num += STATETRANSITION.UpsertStateTransition(dbContext, RequestType.UPDATE, new Statetransition[1] { stateTransition }, null, saveHist: true);
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
