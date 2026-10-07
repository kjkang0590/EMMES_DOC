using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_AlarmClassSave : ModelerRuleBiz<Alarmclass>
{
	private int CreateAlarmClass(IDbContext dbContext, Alarmclass alarmClass)
	{
		Alarmclass alarmClass4Update = ALARMCLASS.GetAlarmClass4Update(dbContext, alarmClass.Alarmclassid, alarmClass.Siteid);
		if (alarmClass4Update != null)
		{
			UpdateAlarmClass(dbContext, alarmClass, alarmClass4Update);
			return 2;
		}
		return ALARMCLASS.UpsertAlarmClass(dbContext, RequestType.CREATE, new Alarmclass[1] { alarmClass }, null, saveHist: true);
	}

	private int DeleteAlarmClass(IDbContext dbContext, Alarmclass alarmClass)
	{
		return ALARMCLASS.UpsertAlarmClass(dbContext, RequestType.DELETE, new Alarmclass[1] { alarmClass }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Alarmclass alarmclass)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateAlarmClass(dbContext, alarmclass));
	}

	public override void DeleteAPI(IDbContext dbContext, Alarmclass alarmclass)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteAlarmClass(dbContext, alarmclass));
	}

	public override void UpdateAPI(IDbContext dbContext, Alarmclass alarmclass)
	{
		UpdateAlarmClass(dbContext, alarmclass, GetAlarmClass4Update(dbContext, alarmclass));
	}

	private Alarmclass GetAlarmClass4Update(IDbContext dbContext, Alarmclass alarmClass)
	{
		Alarmclass alarmClass4Update = ALARMCLASS.GetAlarmClass4Update(dbContext, alarmClass.Alarmclassid, alarmClass.Siteid);
		if (alarmClass4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "ALARMCLASS", "ALARMCLASSID: " + alarmClass.Alarmclassid + ", SITEID: " + alarmClass.Siteid);
		}
		return alarmClass4Update;
	}

	private void UpdateAlarmClass(IDbContext dbContext, Alarmclass alarmClass, Alarmclass alarmClassCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(alarmClass.Isusable))
		{
			num += ALARMCLASS.UpsertAlarmClass(dbContext, RequestType.DELETE, new Alarmclass[1] { alarmClass }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(alarmClassCurrent.Isusable))
		{
			num += ALARMCLASS.UpsertAlarmClass(dbContext, RequestType.UNDELETE, new Alarmclass[1] { alarmClass }, null, saveHist: true);
			flag = true;
		}
		num += ALARMCLASS.UpsertAlarmClass(dbContext, RequestType.UPDATE, new Alarmclass[1] { alarmClass }, null, saveHist: true);
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
