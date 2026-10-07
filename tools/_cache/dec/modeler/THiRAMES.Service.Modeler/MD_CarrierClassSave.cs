using CIM.MES.API.RDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_CarrierClassSave : ModelerRuleBiz<Carrierclass>
{
	private int CreateCarrierClass(IDbContext dbContext, Carrierclass carrierClass)
	{
		Carrierclass carrierClass2 = CARRIERCLASS.GetCarrierClass(dbContext, carrierClass.Carrierclassid, carrierClass.Siteid);
		if (carrierClass2 != null)
		{
			UpdateCarrierClass(dbContext, carrierClass, carrierClass2);
			return 2;
		}
		return CARRIERCLASS.UpsertCarrierClass(dbContext, RequestType.CREATE, new Carrierclass[1] { carrierClass }, null, saveHist: true);
	}

	private int DeleteCarrierClass(IDbContext dbContext, Carrierclass carrierClass)
	{
		return CARRIERCLASS.UpsertCarrierClass(dbContext, RequestType.DELETE, new Carrierclass[1] { carrierClass }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Carrierclass carrierclass)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateCarrierClass(dbContext, carrierclass));
	}

	public override void DeleteAPI(IDbContext dbContext, Carrierclass carrierclass)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteCarrierClass(dbContext, carrierclass));
	}

	public override void UpdateAPI(IDbContext dbContext, Carrierclass carrierclass)
	{
		UpdateCarrierClass(dbContext, carrierclass, GetCarrierClass4Update(dbContext, carrierclass));
	}

	private Carrierclass GetCarrierClass4Update(IDbContext dbContext, Carrierclass carrierClass)
	{
		Carrierclass carrierClass4Update = CARRIERCLASS.GetCarrierClass4Update(dbContext, carrierClass.Carrierclassid, carrierClass.Siteid);
		if (carrierClass4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "CARRIERCLASS", "CARRIERCLASSID: " + carrierClass.Carrierclassid + ", SITEID: " + carrierClass.Siteid);
		}
		return carrierClass4Update;
	}

	private void UpdateCarrierClass(IDbContext dbContext, Carrierclass carrierClass, Carrierclass carrierClassCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(carrierClass.Isusable))
		{
			num += CARRIERCLASS.UpsertCarrierClass(dbContext, RequestType.DELETE, new Carrierclass[1] { carrierClass }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(carrierClassCurrent.Isusable))
		{
			num += CARRIERCLASS.UpsertCarrierClass(dbContext, RequestType.UNDELETE, new Carrierclass[1] { carrierClass }, null, saveHist: true);
			flag = true;
		}
		num += CARRIERCLASS.UpsertCarrierClass(dbContext, RequestType.UPDATE, new Carrierclass[1] { carrierClass }, null, saveHist: true);
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
