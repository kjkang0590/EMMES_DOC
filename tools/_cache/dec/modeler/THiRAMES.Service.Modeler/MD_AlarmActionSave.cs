using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_AlarmActionSave : ModelerRuleBiz<Alarmaction>
{
	private int CreateAlarmAction(IDbContext dbContext, Alarmaction alarmAction)
	{
		Alarmaction alarmAction4Update = ALARMACTION.GetAlarmAction4Update(dbContext, alarmAction.Alarmactionid, alarmAction.Siteid);
		if (alarmAction4Update != null)
		{
			UpdateAlarmAction(dbContext, alarmAction, alarmAction4Update);
			return 2;
		}
		return ALARMACTION.UpsertAlarmAction(dbContext, RequestType.CREATE, new Alarmaction[1] { alarmAction }, null, saveHist: true);
	}

	private int DeleteAlarmAction(IDbContext dbContext, Alarmaction alarmAction)
	{
		return ALARMACTION.UpsertAlarmAction(dbContext, RequestType.DELETE, new Alarmaction[1] { alarmAction }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Alarmaction alarmaction)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateAlarmAction(dbContext, alarmaction));
	}

	public override void DeleteAPI(IDbContext dbContext, Alarmaction alarmaction)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteAlarmAction(dbContext, alarmaction));
	}

	public override void UpdateAPI(IDbContext dbContext, Alarmaction alarmaction)
	{
		UpdateAlarmAction(dbContext, alarmaction, GetAlarmAction4Update(dbContext, alarmaction));
	}

	private Alarmaction GetAlarmAction4Update(IDbContext dbContext, Alarmaction alarmAction)
	{
		Alarmaction alarmAction4Update = ALARMACTION.GetAlarmAction4Update(dbContext, alarmAction.Alarmactionid, alarmAction.Siteid);
		if (alarmAction4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "ALARMACTION", "ALARMACTIONID: " + alarmAction.Alarmactionid + ", SITEID: " + alarmAction.Siteid + " ");
		}
		return alarmAction4Update;
	}

	private void UpdateAlarmAction(IDbContext dbContext, Alarmaction alarmAction, Alarmaction alarmActionCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(alarmAction.Isusable))
		{
			num += ALARMACTION.UpsertAlarmAction(dbContext, RequestType.DELETE, new Alarmaction[1] { alarmAction }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(alarmActionCurrent.Isusable))
		{
			num += ALARMACTION.UpsertAlarmAction(dbContext, RequestType.UNDELETE, new Alarmaction[1] { alarmAction }, null, saveHist: true);
			flag = true;
		}
		num += ALARMACTION.UpsertAlarmAction(dbContext, RequestType.UPDATE, new Alarmaction[1] { alarmAction }, null, saveHist: true);
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
