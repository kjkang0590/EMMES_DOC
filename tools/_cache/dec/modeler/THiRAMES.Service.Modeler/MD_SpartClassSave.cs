using CIM.MES.API.RDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_SpartClassSave : ModelerRuleBiz<Spartclass>
{
	private int CreateSpartClass(IDbContext dbContext, Spartclass spartClass)
	{
		Spartclass spartClass2 = SPARTCLASS.GetSpartClass(dbContext, spartClass.Spartclassid, spartClass.Siteid);
		if (spartClass2 != null)
		{
			UpdateSpartClass(dbContext, spartClass, spartClass2);
			return 2;
		}
		return SPARTCLASS.UpsertSpartClass(dbContext, RequestType.CREATE, new Spartclass[1] { spartClass }, null, saveHist: true);
	}

	private int DeleteSpartClass(IDbContext dbContext, Spartclass spartClass)
	{
		return SPARTCLASS.UpsertSpartClass(dbContext, RequestType.DELETE, new Spartclass[1] { spartClass }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Spartclass spartclass)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateSpartClass(dbContext, spartclass));
	}

	public override void DeleteAPI(IDbContext dbContext, Spartclass spartclass)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteSpartClass(dbContext, spartclass));
	}

	public override void UpdateAPI(IDbContext dbContext, Spartclass spartclass)
	{
		UpdateSpartClass(dbContext, spartclass, GetSpartClass4Update(dbContext, spartclass));
	}

	private Spartclass GetSpartClass4Update(IDbContext dbContext, Spartclass spartClass)
	{
		Spartclass spartClass4Update = SPARTCLASS.GetSpartClass4Update(dbContext, spartClass.Spartclassid, spartClass.Siteid);
		if (spartClass4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "SPARTCLASS", "SPARTCLASSID: " + spartClass.Spartclassid + ", SITEID: " + spartClass.Siteid);
		}
		return spartClass4Update;
	}

	private void UpdateSpartClass(IDbContext dbContext, Spartclass spartClass, Spartclass spartClassCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(spartClass.Isusable))
		{
			num += SPARTCLASS.UpsertSpartClass(dbContext, RequestType.DELETE, new Spartclass[1] { spartClass }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(spartClassCurrent.Isusable))
		{
			num += SPARTCLASS.UpsertSpartClass(dbContext, RequestType.UNDELETE, new Spartclass[1] { spartClass }, null, saveHist: true);
			flag = true;
		}
		num += SPARTCLASS.UpsertSpartClass(dbContext, RequestType.UPDATE, new Spartclass[1] { spartClass }, null, saveHist: true);
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
