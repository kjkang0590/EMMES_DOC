using CIM.MES.API.RDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_DurableClassSave : ModelerRuleBiz<Durableclass>
{
	private int CreateDurableClass(IDbContext dbContext, Durableclass durableClass)
	{
		Durableclass durableClass2 = DURABLECLASS.GetDurableClass(dbContext, durableClass.Durableclassid, durableClass.Siteid);
		if (durableClass2 != null)
		{
			UpdateDurableClass(dbContext, durableClass, durableClass2);
			return 2;
		}
		return DURABLECLASS.UpsertDurableClass(dbContext, RequestType.CREATE, new Durableclass[1] { durableClass }, null, saveHist: true);
	}

	private int DeleteDurableClass(IDbContext dbContext, Durableclass durableClass)
	{
		return DURABLECLASS.UpsertDurableClass(dbContext, RequestType.DELETE, new Durableclass[1] { durableClass }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Durableclass durableclass)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateDurableClass(dbContext, durableclass));
	}

	public override void DeleteAPI(IDbContext dbContext, Durableclass durableclass)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteDurableClass(dbContext, durableclass));
	}

	public override void UpdateAPI(IDbContext dbContext, Durableclass durableclass)
	{
		UpdateDurableClass(dbContext, durableclass, GetDurableClass4Update(dbContext, durableclass));
	}

	private Durableclass GetDurableClass4Update(IDbContext dbContext, Durableclass durableClass)
	{
		Durableclass durableClass4Update = DURABLECLASS.GetDurableClass4Update(dbContext, durableClass.Durableclassid, durableClass.Siteid);
		if (durableClass4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "DURABLECLASS", "DURABLECLASSID: " + durableClass.Durableclassid + ", SITEID: " + durableClass.Siteid);
		}
		return durableClass4Update;
	}

	private void UpdateDurableClass(IDbContext dbContext, Durableclass durableClass, Durableclass durableClassCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(durableClass.Isusable))
		{
			num += DURABLECLASS.UpsertDurableClass(dbContext, RequestType.DELETE, new Durableclass[1] { durableClass }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(durableClassCurrent.Isusable))
		{
			num += DURABLECLASS.UpsertDurableClass(dbContext, RequestType.UNDELETE, new Durableclass[1] { durableClass }, null, saveHist: true);
			flag = true;
		}
		num += DURABLECLASS.UpsertDurableClass(dbContext, RequestType.UPDATE, new Durableclass[1] { durableClass }, null, saveHist: true);
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
