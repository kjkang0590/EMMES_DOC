using CIM.MES.API.RDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_MaterialClassSave : ModelerRuleBiz<Materialclass>
{
	private int CreateMaterialClass(IDbContext dbContext, Materialclass materialClass)
	{
		Materialclass materialClass2 = MATERIALCLASS.GetMaterialClass(dbContext, materialClass.Materialclassid, materialClass.Siteid);
		if (materialClass2 != null)
		{
			UpdateMaterialClass(dbContext, materialClass, materialClass2);
			return 2;
		}
		return MATERIALCLASS.UpsertMaterialClass(dbContext, RequestType.CREATE, new Materialclass[1] { materialClass }, null, saveHist: true);
	}

	private int DeleteMaterialClass(IDbContext dbContext, Materialclass materialClass)
	{
		return MATERIALCLASS.UpsertMaterialClass(dbContext, RequestType.DELETE, new Materialclass[1] { materialClass }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Materialclass materialclass)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateMaterialClass(dbContext, materialclass));
	}

	public override void DeleteAPI(IDbContext dbContext, Materialclass materialclass)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteMaterialClass(dbContext, materialclass));
	}

	public override void UpdateAPI(IDbContext dbContext, Materialclass materialclass)
	{
		UpdateMaterialClass(dbContext, materialclass, GetMaterialClass4Update(dbContext, materialclass));
	}

	private Materialclass GetMaterialClass4Update(IDbContext dbContext, Materialclass materialClass)
	{
		Materialclass materialClass4Update = MATERIALCLASS.GetMaterialClass4Update(dbContext, materialClass.Materialclassid, materialClass.Siteid);
		if (materialClass4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "MATERIALCLASS", "MATERIALCLASSID: " + materialClass.Materialclassid + ", SITEID: " + materialClass.Siteid);
		}
		return materialClass4Update;
	}

	private void UpdateMaterialClass(IDbContext dbContext, Materialclass materialClass, Materialclass materialClassCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(materialClass.Isusable))
		{
			num += MATERIALCLASS.UpsertMaterialClass(dbContext, RequestType.DELETE, new Materialclass[1] { materialClass }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(materialClassCurrent.Isusable))
		{
			num += MATERIALCLASS.UpsertMaterialClass(dbContext, RequestType.UNDELETE, new Materialclass[1] { materialClass }, null, saveHist: true);
			flag = true;
		}
		num += MATERIALCLASS.UpsertMaterialClass(dbContext, RequestType.UPDATE, new Materialclass[1] { materialClass }, null, saveHist: true);
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
