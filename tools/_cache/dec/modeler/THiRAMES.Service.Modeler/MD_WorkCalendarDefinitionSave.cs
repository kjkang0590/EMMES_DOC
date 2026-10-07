using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_WorkCalendarDefinitionSave : ModelerRuleBiz<Workcalendardefinition>
{
	private int CreateWorkCalendarDefinition(IDbContext dbContext, Workcalendardefinition workCalendarDefinition)
	{
		Workcalendardefinition workCalendarDefinition4Update = WORKCALENDARDEFINITION.GetWorkCalendarDefinition4Update(dbContext, workCalendarDefinition.Workcalendardefinitionsysid, workCalendarDefinition.Siteid);
		if (workCalendarDefinition4Update != null)
		{
			UpdateWorkCalendarDefinition(dbContext, workCalendarDefinition, workCalendarDefinition4Update);
			return 2;
		}
		return WORKCALENDARDEFINITION.UpsertWorkCalendarDefinition(dbContext, RequestType.CREATE, new Workcalendardefinition[1] { workCalendarDefinition }, null, saveHist: true);
	}

	private int DeleteWorkCalendarDefinition(IDbContext dbContext, Workcalendardefinition workCalendarDefinition)
	{
		return WORKCALENDARDEFINITION.UpsertWorkCalendarDefinition(dbContext, RequestType.DELETE, new Workcalendardefinition[1] { workCalendarDefinition }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Workcalendardefinition workcalendardefinition)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateWorkCalendarDefinition(dbContext, workcalendardefinition));
	}

	public override void DeleteAPI(IDbContext dbContext, Workcalendardefinition workcalendardefinition)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteWorkCalendarDefinition(dbContext, workcalendardefinition));
	}

	public override void UpdateAPI(IDbContext dbContext, Workcalendardefinition workcalendardefinition)
	{
		UpdateWorkCalendarDefinition(dbContext, workcalendardefinition, GetWorkCalendarDefinition4Update(dbContext, workcalendardefinition));
	}

	private Workcalendardefinition GetWorkCalendarDefinition4Update(IDbContext dbContext, Workcalendardefinition workCalendarDefinition)
	{
		Workcalendardefinition workCalendarDefinition4Update = WORKCALENDARDEFINITION.GetWorkCalendarDefinition4Update(dbContext, workCalendarDefinition.Workcalendardefinitionsysid, workCalendarDefinition.Siteid);
		if (workCalendarDefinition4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "WORKCALENDARDEFINITION", "WORKCALENDARDEFINITIONSYSID: " + workCalendarDefinition.Workcalendardefinitionsysid + ", SITEID: " + workCalendarDefinition.Siteid);
		}
		return workCalendarDefinition4Update;
	}

	private void UpdateWorkCalendarDefinition(IDbContext dbContext, Workcalendardefinition workCalendarDefinition, Workcalendardefinition workCalendarDefinitionCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(workCalendarDefinition.Isusable))
		{
			num += WORKCALENDARDEFINITION.UpsertWorkCalendarDefinition(dbContext, RequestType.DELETE, new Workcalendardefinition[1] { workCalendarDefinition }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(workCalendarDefinitionCurrent.Isusable))
		{
			num += WORKCALENDARDEFINITION.UpsertWorkCalendarDefinition(dbContext, RequestType.UNDELETE, new Workcalendardefinition[1] { workCalendarDefinition }, null, saveHist: true);
			flag = true;
		}
		num += WORKCALENDARDEFINITION.UpsertWorkCalendarDefinition(dbContext, RequestType.UPDATE, new Workcalendardefinition[1] { workCalendarDefinition }, null, saveHist: true);
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
