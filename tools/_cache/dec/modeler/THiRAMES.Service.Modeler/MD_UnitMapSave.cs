using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_UnitMapSave : ModelerRuleBiz<Unitmap>
{
	private int CreateUnitMap(IDbContext dbContext, Unitmap unitMap)
	{
		Unitmap unitMap4Update = UNITMAP.GetUnitMap4Update(dbContext, unitMap.Fromunitid, unitMap.Tounitid, unitMap.Siteid);
		if (unitMap4Update != null)
		{
			UpdateUnitMap(dbContext, unitMap, unitMap4Update);
			return 2;
		}
		return UNITMAP.UpsertUnitMap(dbContext, RequestType.CREATE, new Unitmap[1] { unitMap }, null, saveHist: true);
	}

	private int DeleteUnitMap(IDbContext dbContext, Unitmap unitMap)
	{
		return UNITMAP.UpsertUnitMap(dbContext, RequestType.DELETE, new Unitmap[1] { unitMap }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Unitmap unitmap)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateUnitMap(dbContext, unitmap));
	}

	public override void DeleteAPI(IDbContext dbContext, Unitmap unitmap)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteUnitMap(dbContext, unitmap));
	}

	public override void UpdateAPI(IDbContext dbContext, Unitmap unitmap)
	{
		UpdateUnitMap(dbContext, unitmap, GetUnitMap4Update(dbContext, unitmap));
	}

	private Unitmap GetUnitMap4Update(IDbContext dbContext, Unitmap unitMap)
	{
		Unitmap unitMap4Update = UNITMAP.GetUnitMap4Update(dbContext, unitMap.Fromunitid, unitMap.Tounitid, unitMap.Siteid);
		if (unitMap4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "UNITMAP", "FROMUNITID: " + unitMap.Fromunitid + ", TOUNITID: " + unitMap.Tounitid + ", SITEID: " + unitMap.Siteid);
		}
		return unitMap4Update;
	}

	private void UpdateUnitMap(IDbContext dbContext, Unitmap unitMap, Unitmap unitMapCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(unitMap.Isusable))
		{
			num += UNITMAP.UpsertUnitMap(dbContext, RequestType.DELETE, new Unitmap[1] { unitMap }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(unitMapCurrent.Isusable))
		{
			num += UNITMAP.UpsertUnitMap(dbContext, RequestType.UNDELETE, new Unitmap[1] { unitMap }, null, saveHist: true);
			flag = true;
		}
		num += UNITMAP.UpsertUnitMap(dbContext, RequestType.UPDATE, new Unitmap[1] { unitMap }, null, saveHist: true);
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
