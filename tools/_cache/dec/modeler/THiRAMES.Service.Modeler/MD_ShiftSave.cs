using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_ShiftSave : ModelerRuleBiz<Shift>
{
	private int CreateShift(IDbContext dbContext, Shift shift)
	{
		Shift shift4Update = SHIFT.GetShift4Update(dbContext, shift.Shiftid, shift.Siteid);
		if (shift4Update != null)
		{
			UpdateShift(dbContext, shift, shift4Update);
			return 2;
		}
		return SHIFT.UpsertShift(dbContext, RequestType.CREATE, new Shift[1] { shift }, null, saveHist: true);
	}

	private int DeleteShift(IDbContext dbContext, Shift shift)
	{
		return SHIFT.UpsertShift(dbContext, RequestType.DELETE, new Shift[1] { shift }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Shift shift)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateShift(dbContext, shift));
	}

	public override void DeleteAPI(IDbContext dbContext, Shift shift)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteShift(dbContext, shift));
	}

	public override void UpdateAPI(IDbContext dbContext, Shift shift)
	{
		UpdateShift(dbContext, shift, GetShift4Update(dbContext, shift));
	}

	private Shift GetShift4Update(IDbContext dbContext, Shift shift)
	{
		Shift shift4Update = SHIFT.GetShift4Update(dbContext, shift.Shiftid, shift.Siteid);
		if (shift4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "SHIFT", "SHIFTID: " + shift.Shiftid + ", SITEID: " + shift.Siteid);
		}
		return shift4Update;
	}

	private void UpdateShift(IDbContext dbContext, Shift shift, Shift shiftCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(shift.Isusable))
		{
			num += SHIFT.UpsertShift(dbContext, RequestType.DELETE, new Shift[1] { shift }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(shiftCurrent.Isusable))
		{
			num += SHIFT.UpsertShift(dbContext, RequestType.UNDELETE, new Shift[1] { shift }, null, saveHist: true);
			flag = true;
		}
		num += SHIFT.UpsertShift(dbContext, RequestType.UPDATE, new Shift[1] { shift }, null, saveHist: true);
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
