using CIM.MES.API.DAS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_TraceDataClassSave : ModelerRuleBiz<Tracedataclass>
{
	private int CreateTraceDataClass(IDbContext dbContext, Tracedataclass traceDataClass)
	{
		Tracedataclass traceDataClass2 = TRACEDATACLASS.GetTraceDataClass(dbContext, traceDataClass.Tracedataclassid, traceDataClass.Siteid);
		if (traceDataClass2 != null)
		{
			UpdateTraceDataClass(dbContext, traceDataClass, traceDataClass2);
			return 2;
		}
		return TRACEDATACLASS.UpsertTraceDataClass(dbContext, RequestType.CREATE, new Tracedataclass[1] { traceDataClass }, null, saveHist: true);
	}

	private int DeleteTraceDataClass(IDbContext dbContext, Tracedataclass traceDataClass)
	{
		return TRACEDATACLASS.UpsertTraceDataClass(dbContext, RequestType.DELETE, new Tracedataclass[1] { traceDataClass }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Tracedataclass tracedataclass)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateTraceDataClass(dbContext, tracedataclass));
	}

	public override void DeleteAPI(IDbContext dbContext, Tracedataclass tracedataclass)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteTraceDataClass(dbContext, tracedataclass));
	}

	public override void UpdateAPI(IDbContext dbContext, Tracedataclass tracedataclass)
	{
		UpdateTraceDataClass(dbContext, tracedataclass, GetTraceDataClass4Update(dbContext, tracedataclass));
	}

	private Tracedataclass GetTraceDataClass4Update(IDbContext dbContext, Tracedataclass traceDataClass)
	{
		Tracedataclass traceDataClass4Update = TRACEDATACLASS.GetTraceDataClass4Update(dbContext, traceDataClass.Tracedataclassid, traceDataClass.Siteid);
		if (traceDataClass4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "TRACEDATACLASS", "TRACEDATACLASSID: " + traceDataClass.Tracedataclassid + ", SITEID: " + traceDataClass.Siteid);
		}
		return traceDataClass4Update;
	}

	private void UpdateTraceDataClass(IDbContext dbContext, Tracedataclass traceDataClass, Tracedataclass traceDataClassCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(traceDataClass.Isusable))
		{
			num += TRACEDATACLASS.UpsertTraceDataClass(dbContext, RequestType.DELETE, new Tracedataclass[1] { traceDataClass }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("Usable".Equals(traceDataClass.Isusable))
		{
			num += TRACEDATACLASS.UpsertTraceDataClass(dbContext, RequestType.UNDELETE, new Tracedataclass[1] { traceDataClass }, null, saveHist: true);
			flag = true;
		}
		num += TRACEDATACLASS.UpsertTraceDataClass(dbContext, RequestType.UPDATE, new Tracedataclass[1] { traceDataClass }, null, saveHist: true);
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
