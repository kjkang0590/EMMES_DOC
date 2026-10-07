using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_AlarmDefinitionSave : ModelerRuleBiz<Alarmdefinition>
{
	private int CreateAlarmDefinition(IDbContext dbContext, Alarmdefinition alarmDefinition)
	{
		Alarmdefinition alarmDefinition4Update = ALARMDEFINITION.GetAlarmDefinition4Update(dbContext, alarmDefinition.Alarmdefinitionid, alarmDefinition.Alarmsourceid, alarmDefinition.Alarmtype, alarmDefinition.Siteid);
		if (alarmDefinition4Update != null)
		{
			UpdateAlarmDefinition(dbContext, alarmDefinition, alarmDefinition4Update);
			return 2;
		}
		return ALARMDEFINITION.UpsertAlarmDefinition(dbContext, RequestType.CREATE, new Alarmdefinition[1] { alarmDefinition }, null, saveHist: true);
	}

	private int DeleteAlarmDefinition(IDbContext dbContext, Alarmdefinition alarmDefinition)
	{
		return ALARMDEFINITION.UpsertAlarmDefinition(dbContext, RequestType.DELETE, new Alarmdefinition[1] { alarmDefinition }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Alarmdefinition alarmdefinition)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateAlarmDefinition(dbContext, alarmdefinition));
	}

	public override void DeleteAPI(IDbContext dbContext, Alarmdefinition alarmdefinition)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteAlarmDefinition(dbContext, alarmdefinition));
	}

	public override void UpdateAPI(IDbContext dbContext, Alarmdefinition alarmdefinition)
	{
		UpdateAlarmDefinition(dbContext, alarmdefinition, GetAlarmDefinition4Update(dbContext, alarmdefinition));
	}

	private Alarmdefinition GetAlarmDefinition4Update(IDbContext dbContext, Alarmdefinition alarmDefinition)
	{
		Alarmdefinition alarmDefinition4Update = ALARMDEFINITION.GetAlarmDefinition4Update(dbContext, alarmDefinition.Alarmdefinitionid, alarmDefinition.Alarmsourceid, alarmDefinition.Alarmtype, alarmDefinition.Siteid);
		if (alarmDefinition4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "ALARMDEFINITION", "ALARMDEFINITIONID: " + alarmDefinition.Alarmdefinitionid + ", ALARMSOURCEID: " + alarmDefinition.Alarmsourceid + ", ALARMTYPE: " + alarmDefinition.Alarmtype + ", SITEID: " + alarmDefinition.Siteid);
		}
		return alarmDefinition4Update;
	}

	private void UpdateAlarmDefinition(IDbContext dbContext, Alarmdefinition alarmDefinition, Alarmdefinition alarmDefinitionCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(alarmDefinition.Isusable))
		{
			num += ALARMDEFINITION.UpsertAlarmDefinition(dbContext, RequestType.DELETE, new Alarmdefinition[1] { alarmDefinition }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(alarmDefinitionCurrent.Isusable))
		{
			num += ALARMDEFINITION.UpsertAlarmDefinition(dbContext, RequestType.UNDELETE, new Alarmdefinition[1] { alarmDefinition }, null, saveHist: true);
			flag = true;
		}
		num += ALARMDEFINITION.UpsertAlarmDefinition(dbContext, RequestType.UPDATE, new Alarmdefinition[1] { alarmDefinition }, null, saveHist: true);
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
