using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_AlarmActionCategorySave : ModelerRuleBiz<Alarmactioncategory>
{
	private int CreateAlarmActionCategory(IDbContext dbContext, Alarmactioncategory alarmActionCategory)
	{
		Alarmactioncategory alarmActionCategory4Update = ALARMACTIONCATEGORY.GetAlarmActionCategory4Update(dbContext, alarmActionCategory.Alarmactioncategoryid, alarmActionCategory.Siteid);
		if (alarmActionCategory4Update != null)
		{
			UpdateAlarmActionCategory(dbContext, alarmActionCategory, alarmActionCategory4Update);
			return 2;
		}
		return ALARMACTIONCATEGORY.UpsertAlarmActionCategory(dbContext, RequestType.CREATE, new Alarmactioncategory[1] { alarmActionCategory }, null, saveHist: true);
	}

	private int DeleteAlarmActionCategory(IDbContext dbContext, Alarmactioncategory alarmActionCategory)
	{
		return ALARMACTIONCATEGORY.UpsertAlarmActionCategory(dbContext, RequestType.DELETE, new Alarmactioncategory[1] { alarmActionCategory }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Alarmactioncategory alarmactioncategory)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateAlarmActionCategory(dbContext, alarmactioncategory));
	}

	public override void DeleteAPI(IDbContext dbContext, Alarmactioncategory alarmactioncategory)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteAlarmActionCategory(dbContext, alarmactioncategory));
	}

	public override void UpdateAPI(IDbContext dbContext, Alarmactioncategory alarmactioncategory)
	{
		UpdateAlarmActionCategory(dbContext, alarmactioncategory, GetAlarmActionCategory4Update(dbContext, alarmactioncategory));
	}

	private Alarmactioncategory GetAlarmActionCategory4Update(IDbContext dbContext, Alarmactioncategory alarmActionCategory)
	{
		Alarmactioncategory alarmActionCategory4Update = ALARMACTIONCATEGORY.GetAlarmActionCategory4Update(dbContext, alarmActionCategory.Alarmactioncategoryid, alarmActionCategory.Siteid);
		if (alarmActionCategory4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "ALARMACTIONCATEGORY", "ALARMACTIONCATEGORYID: " + alarmActionCategory.Alarmactioncategoryid + ", SITEID: " + alarmActionCategory.Siteid);
		}
		return alarmActionCategory4Update;
	}

	private void UpdateAlarmActionCategory(IDbContext dbContext, Alarmactioncategory alarmActionCategory, Alarmactioncategory alarmActionCategoryCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(alarmActionCategory.Isusable))
		{
			num += ALARMACTIONCATEGORY.UpsertAlarmActionCategory(dbContext, RequestType.DELETE, new Alarmactioncategory[1] { alarmActionCategory }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(alarmActionCategoryCurrent.Isusable))
		{
			num += ALARMACTIONCATEGORY.UpsertAlarmActionCategory(dbContext, RequestType.UNDELETE, new Alarmactioncategory[1] { alarmActionCategory }, null, saveHist: true);
			flag = true;
		}
		num += ALARMACTIONCATEGORY.UpsertAlarmActionCategory(dbContext, RequestType.UPDATE, new Alarmactioncategory[1] { alarmActionCategory }, null, saveHist: true);
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
