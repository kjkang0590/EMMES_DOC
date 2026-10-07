using CIM.MES.API.DAS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_ProcessDataClassSave : ModelerRuleBiz<Processdataclass>
{
	private int CreateProcessDataClass(IDbContext dbContext, Processdataclass processDataClass)
	{
		Processdataclass processDataClass2 = PROCESSDATACLASS.GetProcessDataClass(dbContext, processDataClass.Processdataclassid, processDataClass.Siteid);
		if (processDataClass2 != null)
		{
			UpdateProcessDataClass(dbContext, processDataClass, processDataClass2);
			return 2;
		}
		return PROCESSDATACLASS.UpsertProcessDataClass(dbContext, RequestType.CREATE, new Processdataclass[1] { processDataClass }, null, saveHist: true);
	}

	private int DeleteProcessDataClass(IDbContext dbContext, Processdataclass processDataClass)
	{
		return PROCESSDATACLASS.UpsertProcessDataClass(dbContext, RequestType.DELETE, new Processdataclass[1] { processDataClass }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Processdataclass processdataclass)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateProcessDataClass(dbContext, processdataclass));
	}

	public override void DeleteAPI(IDbContext dbContext, Processdataclass processdataclass)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteProcessDataClass(dbContext, processdataclass));
	}

	public override void UpdateAPI(IDbContext dbContext, Processdataclass processdataclass)
	{
		UpdateProcessDataClass(dbContext, processdataclass, GetProcessDataClass4Update(dbContext, processdataclass));
	}

	private Processdataclass GetProcessDataClass4Update(IDbContext dbContext, Processdataclass processDataClass)
	{
		Processdataclass processDataClass4Update = PROCESSDATACLASS.GetProcessDataClass4Update(dbContext, processDataClass.Processdataclassid, processDataClass.Siteid);
		if (processDataClass4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "PROCESSDATACLASS", "PROCESSDATACLASSID: " + processDataClass.Processdataclassid + ", SITEID: " + processDataClass.Siteid);
		}
		return processDataClass4Update;
	}

	private void UpdateProcessDataClass(IDbContext dbContext, Processdataclass processDataClass, Processdataclass processDataClassCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(processDataClass.Isusable))
		{
			num += PROCESSDATACLASS.UpsertProcessDataClass(dbContext, RequestType.DELETE, new Processdataclass[1] { processDataClass }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(processDataClassCurrent.Isusable))
		{
			num += PROCESSDATACLASS.UpsertProcessDataClass(dbContext, RequestType.UNDELETE, new Processdataclass[1] { processDataClass }, null, saveHist: true);
			flag = true;
		}
		num += PROCESSDATACLASS.UpsertProcessDataClass(dbContext, RequestType.UPDATE, new Processdataclass[1] { processDataClass }, null, saveHist: true);
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
