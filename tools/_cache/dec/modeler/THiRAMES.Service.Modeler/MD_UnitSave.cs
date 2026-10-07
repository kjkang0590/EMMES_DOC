using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_UnitSave : ModelerRuleBiz<Unit>
{
	private int CreateUnit(IDbContext dbContext, Unit unit)
	{
		Unit unit4Update = UNIT.GetUnit4Update(dbContext, unit.Unitid, unit.Siteid);
		if (unit4Update != null)
		{
			UpdateUnit(dbContext, unit, unit4Update);
			return 2;
		}
		return UNIT.UpsertUnit(dbContext, RequestType.CREATE, new Unit[1] { unit }, null, saveHist: true);
	}

	private int DeleteUnit(IDbContext dbContext, Unit unit)
	{
		return UNIT.UpsertUnit(dbContext, RequestType.DELETE, new Unit[1] { unit }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Unit unit)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateUnit(dbContext, unit));
	}

	public override void DeleteAPI(IDbContext dbContext, Unit unit)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteUnit(dbContext, unit));
	}

	public override void UpdateAPI(IDbContext dbContext, Unit unit)
	{
		UpdateUnit(dbContext, unit, GetUnit4Update(dbContext, unit));
	}

	private Unit GetUnit4Update(IDbContext dbContext, Unit unit)
	{
		Unit unit4Update = UNIT.GetUnit4Update(dbContext, unit.Unitid, unit.Siteid);
		if (unit4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "UNIT", "UNITID: " + unit.Unitid + ", SITEID: " + unit.Siteid);
		}
		return unit4Update;
	}

	private void UpdateUnit(IDbContext dbContext, Unit unit, Unit unitCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(unit.Isusable))
		{
			num += UNIT.UpsertUnit(dbContext, RequestType.DELETE, new Unit[1] { unit }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(unitCurrent.Isusable))
		{
			num += UNIT.UpsertUnit(dbContext, RequestType.UNDELETE, new Unit[1] { unit }, null, saveHist: true);
			flag = true;
		}
		num += UNIT.UpsertUnit(dbContext, RequestType.UPDATE, new Unit[1] { unit }, null, saveHist: true);
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
