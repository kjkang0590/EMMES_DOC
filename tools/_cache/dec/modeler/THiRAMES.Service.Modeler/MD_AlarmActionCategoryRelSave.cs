using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_AlarmActionCategoryRelSave : ModelerRuleBiz<Alarmactioncategoryrel>
{
	private int CreateAlarmActionCategoryRel(IDbContext dbContext, Alarmactioncategoryrel alarmActionCategoryRel)
	{
		Alarmactioncategoryrel alarmActionCategoryRel4Update = ALARMACTIONCATEGORYREL.GetAlarmActionCategoryRel4Update(dbContext, alarmActionCategoryRel.Alarmactioncategoryid, alarmActionCategoryRel.Alarmactionid, alarmActionCategoryRel.Siteid);
		if (alarmActionCategoryRel4Update != null)
		{
			UpdateAlarmActionCategoryRel(dbContext, alarmActionCategoryRel, alarmActionCategoryRel4Update);
			return 2;
		}
		return ALARMACTIONCATEGORYREL.UpsertAlarmActionCategoryRel(dbContext, RequestType.CREATE, new Alarmactioncategoryrel[1] { alarmActionCategoryRel }, null, saveHist: true);
	}

	private int DeleteAlarmActionCategoryRel(IDbContext dbContext, Alarmactioncategoryrel alarmActionCategoryRel)
	{
		return ALARMACTIONCATEGORYREL.UpsertAlarmActionCategoryRel(dbContext, RequestType.DELETE, new Alarmactioncategoryrel[1] { alarmActionCategoryRel }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Alarmactioncategoryrel alarmactioncategoryrel)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateAlarmActionCategoryRel(dbContext, alarmactioncategoryrel));
	}

	public override void DeleteAPI(IDbContext dbContext, Alarmactioncategoryrel alarmactioncategoryrel)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteAlarmActionCategoryRel(dbContext, alarmactioncategoryrel));
	}

	public override void UpdateAPI(IDbContext dbContext, Alarmactioncategoryrel alarmactioncategoryrel)
	{
		UpdateAlarmActionCategoryRel(dbContext, alarmactioncategoryrel, GetAlarmActionCategoryRel4Update(dbContext, alarmactioncategoryrel));
	}

	private Alarmactioncategoryrel GetAlarmActionCategoryRel4Update(IDbContext dbContext, Alarmactioncategoryrel alarmActionCategoryRel)
	{
		Alarmactioncategoryrel alarmActionCategoryRel4Update = ALARMACTIONCATEGORYREL.GetAlarmActionCategoryRel4Update(dbContext, alarmActionCategoryRel.Alarmactioncategoryid, alarmActionCategoryRel.Alarmactionid, alarmActionCategoryRel.Siteid);
		if (alarmActionCategoryRel4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "ALARMACTIONCATEGORYREL", "ALARMACTIONCATEGORYID: " + alarmActionCategoryRel.Alarmactioncategoryid + ", ACTIONID: " + alarmActionCategoryRel.Alarmactionid + ", SITEID: " + alarmActionCategoryRel.Siteid);
		}
		return alarmActionCategoryRel4Update;
	}

	private void UpdateAlarmActionCategoryRel(IDbContext dbContext, Alarmactioncategoryrel alarmActionCategoryRel, Alarmactioncategoryrel alarmActionCategoryRelCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(alarmActionCategoryRel.Isusable))
		{
			num += ALARMACTIONCATEGORYREL.UpsertAlarmActionCategoryRel(dbContext, RequestType.DELETE, new Alarmactioncategoryrel[1] { alarmActionCategoryRel }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(alarmActionCategoryRelCurrent.Isusable))
		{
			num += ALARMACTIONCATEGORYREL.UpsertAlarmActionCategoryRel(dbContext, RequestType.UNDELETE, new Alarmactioncategoryrel[1] { alarmActionCategoryRel }, null, saveHist: true);
			flag = true;
		}
		num += ALARMACTIONCATEGORYREL.UpsertAlarmActionCategoryRel(dbContext, RequestType.UPDATE, new Alarmactioncategoryrel[1] { alarmActionCategoryRel }, null, saveHist: true);
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
