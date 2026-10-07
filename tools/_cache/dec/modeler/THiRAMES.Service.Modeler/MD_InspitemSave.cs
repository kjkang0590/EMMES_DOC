using CIM.MES.API.QMS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_InspitemSave : ModelerRuleBiz<Inspitem>
{
	public override void CreateAPI(IDbContext dbContext, Inspitem inspitem)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateInspitem(dbContext, inspitem));
	}

	private int CreateInspitem(IDbContext dbContext, Inspitem inspItem)
	{
		Inspitem inspItem4Update = INSPITEM.GetInspItem4Update(dbContext, inspItem.Inspitemid, inspItem.Siteid);
		if (inspItem4Update != null)
		{
			UpdateInspitem(dbContext, inspItem, inspItem4Update);
			return 2;
		}
		return INSPITEM.UpsertInspItem(dbContext, RequestType.CREATE, new Inspitem[1] { inspItem }, null, saveHist: true);
	}

	public override void DeleteAPI(IDbContext dbContext, Inspitem inspitem)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteInspitem(dbContext, inspitem));
	}

	private int DeleteInspitem(IDbContext dbContext, Inspitem InspItem)
	{
		return INSPITEM.UpsertInspItem(dbContext, RequestType.DELETE, new Inspitem[1] { InspItem }, null, saveHist: true);
	}

	public override void MessageValidation(IDbContext dbContext)
	{
		base.WEBDATA.WebdataMessage("SITEID", "INSPITEMID");
	}

	public override void RealDeleteAPI(IDbContext dbContext, Inspitem inspItem)
	{
		DBTransactionCheck(ACTIVITY, 2, RealDeleteInspitem(dbContext, inspItem));
	}

	private int RealDeleteInspitem(IDbContext dbContext, Inspitem inspItem)
	{
		return INSPITEM.UpsertInspItem(dbContext, RequestType.REALDELETE, new Inspitem[1] { inspItem }, null, saveHist: true);
	}

	public override void UpdateAPI(IDbContext dbContext, Inspitem inspItem)
	{
		Inspitem inspitem4Update = GetInspitem4Update(dbContext, inspItem);
		UpdateInspitem(dbContext, inspItem, inspitem4Update);
	}

	private Inspitem GetInspitem4Update(IDbContext dbContext, Inspitem inspItem)
	{
		Inspitem inspItem4Update = INSPITEM.GetInspItem4Update(dbContext, inspItem.Inspitemid, inspItem.Siteid);
		if (inspItem4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_004", "INSPITEM");
		}
		return inspItem4Update;
	}

	private void UpdateInspitem(IDbContext dbContext, Inspitem InspItem, Inspitem InspItemCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(InspItem.Isusable))
		{
			num += INSPITEM.UpsertInspItem(dbContext, RequestType.DELETE, new Inspitem[1] { InspItem }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(InspItemCurrent.Isusable))
		{
			num += INSPITEM.UpsertInspItem(dbContext, RequestType.UNDELETE, new Inspitem[1] { InspItem }, null, saveHist: true);
			flag = true;
		}
		num += INSPITEM.UpsertInspItem(dbContext, RequestType.UPDATE, new Inspitem[1] { InspItem }, null, saveHist: true);
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
