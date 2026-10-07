using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_FacilityClassSave : ModelerRuleBiz<Facilityclass>
{
	public override void CreateAPI(IDbContext dbContext, Facilityclass facilityClass)
	{
		Facilityclass facilityClass2 = FACILITYCLASS.GetFacilityClass(dbContext, facilityClass.Facilityclassid, facilityClass.Siteid);
		if (facilityClass2 != null)
		{
			UpdateFacilityClass(dbContext, facilityClass, facilityClass2);
			return;
		}
		int count = FACILITYCLASS.UpsertFacilityClass(dbContext, RequestType.CREATE, new Facilityclass[1] { facilityClass }, null, saveHist: true);
		DBTransactionCheck(ACTIVITY, 2, count);
	}

	public override void DeleteAPI(IDbContext dbContext, Facilityclass facilityClass)
	{
		int count = FACILITYCLASS.UpsertFacilityClass(dbContext, RequestType.DELETE, new Facilityclass[1] { facilityClass }, null, saveHist: true);
		DBTransactionCheck(ACTIVITY, 2, count);
	}

	public override void UpdateAPI(IDbContext dbContext, Facilityclass facilityClass)
	{
		UpdateFacilityClass(dbContext, facilityClass, GetFacilityClass4Update(dbContext, facilityClass));
	}

	private Facilityclass GetFacilityClass4Update(IDbContext dbContext, Facilityclass facilityClass)
	{
		Facilityclass facilityClass2 = FACILITYCLASS.GetFacilityClass(dbContext, facilityClass.Facilityclassid, facilityClass.Siteid);
		if (facilityClass2 == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "FACILITYCLASS", "FACILITYCLASSID: " + facilityClass.Facilityclassid + ", SITEID: " + facilityClass.Siteid);
		}
		return facilityClass2;
	}

	private void UpdateFacilityClass(IDbContext dbContext, Facilityclass facilityClass, Facilityclass facilityClassCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(facilityClass.Isusable))
		{
			num += FACILITYCLASS.UpsertFacilityClass(dbContext, RequestType.DELETE, new Facilityclass[1] { facilityClass }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(facilityClassCurrent.Isusable))
		{
			num += FACILITYCLASS.UpsertFacilityClass(dbContext, RequestType.UNDELETE, new Facilityclass[1] { facilityClass }, null, saveHist: true);
			flag = true;
		}
		num += FACILITYCLASS.UpsertFacilityClass(dbContext, RequestType.UPDATE, new Facilityclass[1] { facilityClass }, null, saveHist: true);
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
