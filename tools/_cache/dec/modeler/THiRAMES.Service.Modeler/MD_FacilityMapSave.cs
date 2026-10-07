using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_FacilityMapSave : ModelerRuleBiz<Facilitymap>
{
	private int CreateFacilityMap(IDbContext dbContext, Facilitymap facilityMap)
	{
		Facilitymap facilityMap2 = FACILITYMAP.GetFacilityMap(dbContext, facilityMap.Facilityid, facilityMap.Parentfacilityid, facilityMap.Siteid);
		if (facilityMap2 != null)
		{
			UpdateFacilityMap(dbContext, facilityMap, facilityMap2);
			return 2;
		}
		return FACILITYMAP.UpsertFacilityMap(dbContext, RequestType.CREATE, new Facilitymap[1] { facilityMap }, null, saveHist: true);
	}

	private int DeleteFacilityMap(IDbContext dbContext, Facilitymap facilityMap)
	{
		return FACILITYMAP.UpsertFacilityMap(dbContext, RequestType.DELETE, new Facilitymap[1] { facilityMap }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Facilitymap facilityMap)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateFacilityMap(dbContext, facilityMap));
	}

	public override void DeleteAPI(IDbContext dbContext, Facilitymap facilityMap)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteFacilityMap(dbContext, facilityMap));
	}

	public override void UpdateAPI(IDbContext dbContext, Facilitymap facilityMap)
	{
		UpdateFacilityMap(dbContext, facilityMap, GetFacilityMap4Update(dbContext, facilityMap));
	}

	private Facilitymap GetFacilityMap4Update(IDbContext dbContext, Facilitymap facilityMap)
	{
		Facilitymap facilityMap4Update = FACILITYMAP.GetFacilityMap4Update(dbContext, facilityMap.Facilityid, facilityMap.Parentfacilityid, facilityMap.Siteid);
		if (facilityMap4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "FACILITYMAP", "FACILITYID: " + facilityMap.Facilityid + ", PARENTFACILITYID: " + facilityMap.Parentfacilityid + ", SITEID: " + facilityMap.Siteid);
		}
		return facilityMap4Update;
	}

	private void UpdateFacilityMap(IDbContext dbContext, Facilitymap facilityMap, Facilitymap facilityMapCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(facilityMap.Isusable))
		{
			num += FACILITYMAP.UpsertFacilityMap(dbContext, RequestType.DELETE, new Facilitymap[1] { facilityMap }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(facilityMapCurrent.Isusable))
		{
			num += FACILITYMAP.UpsertFacilityMap(dbContext, RequestType.UNDELETE, new Facilitymap[1] { facilityMap }, null, saveHist: true);
			flag = true;
		}
		num += FACILITYMAP.UpsertFacilityMap(dbContext, RequestType.UPDATE, new Facilitymap[1] { facilityMap }, null, saveHist: true);
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
