using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_DefectClassSave : ModelerRuleBiz<Defectclass>
{
	private int CreateDefectClass(IDbContext dbContext, Defectclass defectClass)
	{
		Defectclass defectClass4Update = DEFECTCLASS.GetDefectClass4Update(dbContext, defectClass.Defectclassid, defectClass.Siteid);
		if (defectClass4Update != null)
		{
			UpdateDefectClass(dbContext, defectClass, defectClass4Update);
			return 2;
		}
		return DEFECTCLASS.UpsertDefectClass(dbContext, RequestType.CREATE, new Defectclass[1] { defectClass }, null, saveHist: true);
	}

	private int DeleteDefectClass(IDbContext dbContext, Defectclass defectClass)
	{
		return DEFECTCLASS.UpsertDefectClass(dbContext, RequestType.DELETE, new Defectclass[1] { defectClass }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Defectclass defectclass)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateDefectClass(dbContext, defectclass));
	}

	public override void DeleteAPI(IDbContext dbContext, Defectclass defectclass)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteDefectClass(dbContext, defectclass));
	}

	public override void UpdateAPI(IDbContext dbContext, Defectclass defectclass)
	{
		UpdateDefectClass(dbContext, defectclass, GetDefectClass4Update(dbContext, defectclass));
	}

	private Defectclass GetDefectClass4Update(IDbContext dbContext, Defectclass defectClass)
	{
		Defectclass defectClass4Update = DEFECTCLASS.GetDefectClass4Update(dbContext, defectClass.Defectclassid, defectClass.Siteid);
		if (defectClass4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "DEFECTCLASS", "DEFECTCLASSID: " + defectClass.Defectclassid + ", SITEID: " + defectClass.Siteid);
		}
		return defectClass4Update;
	}

	private void UpdateDefectClass(IDbContext dbContext, Defectclass defectClass, Defectclass defectClassCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(defectClass.Isusable))
		{
			num += DEFECTCLASS.UpsertDefectClass(dbContext, RequestType.DELETE, new Defectclass[1] { defectClass }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(defectClassCurrent.Isusable))
		{
			num += DEFECTCLASS.UpsertDefectClass(dbContext, RequestType.UNDELETE, new Defectclass[1] { defectClass }, null, saveHist: true);
			flag = true;
		}
		num += DEFECTCLASS.UpsertDefectClass(dbContext, RequestType.UPDATE, new Defectclass[1] { defectClass }, null, saveHist: true);
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
