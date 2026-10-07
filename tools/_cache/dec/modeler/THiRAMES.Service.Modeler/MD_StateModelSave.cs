using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_StateModelSave : ModelerRuleBiz<Statemodel>
{
	private int CreateStateModel(IDbContext dbContext, Statemodel stateModel)
	{
		Statemodel stateModel4Update = STATEMODEL.GetStateModel4Update(dbContext, stateModel.Statemodelid, stateModel.Siteid);
		if (stateModel4Update != null)
		{
			UpdateStateModel(dbContext, stateModel, stateModel4Update);
			return 2;
		}
		return STATEMODEL.UpsertStateModel(dbContext, RequestType.CREATE, new Statemodel[1] { stateModel }, null, saveHist: true);
	}

	private int DeleteStateModel(IDbContext dbContext, Statemodel stateModel)
	{
		return STATEMODEL.UpsertStateModel(dbContext, RequestType.DELETE, new Statemodel[1] { stateModel }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Statemodel statemodel)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateStateModel(dbContext, statemodel));
	}

	public override void DeleteAPI(IDbContext dbContext, Statemodel statemodel)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteStateModel(dbContext, statemodel));
	}

	public override void UpdateAPI(IDbContext dbContext, Statemodel statemodel)
	{
		UpdateStateModel(dbContext, statemodel, GetStateModel4Update(dbContext, statemodel));
	}

	private Statemodel GetStateModel4Update(IDbContext dbContext, Statemodel stateModel)
	{
		Statemodel stateModel4Update = STATEMODEL.GetStateModel4Update(dbContext, stateModel.Statemodelid, stateModel.Siteid);
		if (stateModel4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "STATEMODEL", "STATEMODELID: " + stateModel.Statemodelid + ", SITEID:" + stateModel.Siteid);
		}
		return stateModel4Update;
	}

	private void UpdateStateModel(IDbContext dbContext, Statemodel stateModel, Statemodel stateModelCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(stateModel.Isusable))
		{
			num += STATEMODEL.UpsertStateModel(dbContext, RequestType.DELETE, new Statemodel[1] { stateModel }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(stateModelCurrent.Isusable))
		{
			num += STATEMODEL.UpsertStateModel(dbContext, RequestType.UNDELETE, new Statemodel[1] { stateModel }, null, saveHist: true);
			flag = true;
		}
		num += STATEMODEL.UpsertStateModel(dbContext, RequestType.UPDATE, new Statemodel[1] { stateModel }, null, saveHist: true);
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
