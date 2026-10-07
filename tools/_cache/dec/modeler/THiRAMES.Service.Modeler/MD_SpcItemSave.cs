using CIM.MES.API.QMS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_SpcItemSave : ModelerRuleBiz<Spcitem>
{
	private int CreateSpcItem(IDbContext dbContext, Spcitem spcItem)
	{
		Spcitem spcItem2 = SPCITEM.GetSpcItem(dbContext, spcItem.Spcitemsysid, spcItem.Siteid);
		if (spcItem2 != null)
		{
			UpdateSpcItem(dbContext, spcItem, spcItem2);
			return 2;
		}
		return SPCITEM.UpsertSpcItem(dbContext, RequestType.CREATE, new Spcitem[1] { spcItem }, null, saveHist: true);
	}

	private int DeleteSpcItem(IDbContext dbContext, Spcitem spcItem)
	{
		return SPCITEM.UpsertSpcItem(dbContext, RequestType.DELETE, new Spcitem[1] { spcItem }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Spcitem spcitem)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateSpcItem(dbContext, spcitem));
	}

	public override void DeleteAPI(IDbContext dbContext, Spcitem spcitem)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteSpcItem(dbContext, spcitem));
	}

	public override void UpdateAPI(IDbContext dbContext, Spcitem spcitem)
	{
		UpdateSpcItem(dbContext, spcitem, GetSpcItem4Update(dbContext, spcitem));
	}

	private Spcitem GetSpcItem4Update(IDbContext dbContext, Spcitem spcItem)
	{
		Spcitem spcItem4Update = SPCITEM.GetSpcItem4Update(dbContext, spcItem.Spcitemsysid, spcItem.Siteid);
		if (spcItem4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "SPCITEM", $"SPCITEMSYSID: {spcItem.Spcitemsysid}, SITEID: {spcItem.Siteid}");
		}
		return spcItem4Update;
	}

	private void UpdateSpcItem(IDbContext dbContext, Spcitem spcItem, Spcitem spcItemCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(spcItem.Isusable))
		{
			num += SPCITEM.UpsertSpcItem(dbContext, RequestType.DELETE, new Spcitem[1] { spcItem }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(spcItemCurrent.Isusable))
		{
			num += SPCITEM.UpsertSpcItem(dbContext, RequestType.UNDELETE, new Spcitem[1] { spcItem }, null, saveHist: true);
			flag = true;
		}
		num += SPCITEM.UpsertSpcItem(dbContext, RequestType.UPDATE, new Spcitem[1] { spcItem }, null, saveHist: true);
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
