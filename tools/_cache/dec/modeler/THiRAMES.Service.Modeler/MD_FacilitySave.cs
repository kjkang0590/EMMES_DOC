using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_FacilitySave : ModelerRuleBiz<Facility>
{
	public override void CreateAPI(IDbContext dbContext, Facility facility)
	{
		Facility facility2 = FACILITY.GetFacility(dbContext, facility.Facilityid, facility.Siteid);
		if (facility2 != null)
		{
			UpdateFacility(dbContext, facility, facility2);
			return;
		}
		int count = FACILITY.UpsertFacility(dbContext, RequestType.CREATE, new Facility[1] { facility }, null, saveHist: true);
		DBTransactionCheck(ACTIVITY, 2, count);
	}

	public override void DeleteAPI(IDbContext dbContext, Facility facility)
	{
		int count = FACILITY.UpsertFacility(dbContext, RequestType.DELETE, new Facility[1] { facility }, null, saveHist: true);
		DBTransactionCheck(ACTIVITY, 2, count);
	}

	public override void UpdateAPI(IDbContext dbContext, Facility facility)
	{
		UpdateFacility(dbContext, facility, GetFacility4Update(dbContext, facility));
	}

	private Facility GetFacility4Update(IDbContext dbContext, Facility facility)
	{
		Facility facility2 = FACILITY.GetFacility(dbContext, facility.Facilityid, facility.Siteid);
		if (facility2 == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "FACILITY", "FACILITYID: " + facility.Facilityid + ", SITEID: " + facility.Siteid);
		}
		return facility2;
	}

	private void UpdateFacility(IDbContext dbContext, Facility facility, Facility facilityCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(facility.Isusable))
		{
			num += FACILITY.UpsertFacility(dbContext, RequestType.DELETE, new Facility[1] { facility }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(facilityCurrent.Isusable))
		{
			num += FACILITY.UpsertFacility(dbContext, RequestType.UNDELETE, new Facility[1] { facility }, null, saveHist: true);
			flag = true;
		}
		num += FACILITY.UpsertFacility(dbContext, RequestType.UPDATE, new Facility[1] { facility }, null, saveHist: true);
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
