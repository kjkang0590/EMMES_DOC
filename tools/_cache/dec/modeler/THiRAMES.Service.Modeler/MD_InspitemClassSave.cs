using CIM.MES.API.QMS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_InspitemClassSave : ModelerRuleBiz<Inspitemclass>
{
	public override void CreateAPI(IDbContext dbContext, Inspitemclass inspItemclass)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateInspitemclass(dbContext, inspItemclass));
	}

	private int CreateInspitemclass(IDbContext dbContext, Inspitemclass inspItemclass)
	{
		Inspitemclass inspItemClass4Update = INSPITEMCLASS.GetInspItemClass4Update(dbContext, inspItemclass.Inspitemclassid, inspItemclass.Siteid);
		if (inspItemClass4Update != null)
		{
			UpdateInspitemclass(dbContext, inspItemclass, inspItemClass4Update);
			return 2;
		}
		return INSPITEMCLASS.UpsertInspItemClass(dbContext, RequestType.CREATE, new Inspitemclass[1] { inspItemclass }, null, saveHist: true);
	}

	public override void DeleteAPI(IDbContext dbContext, Inspitemclass inspItemclass)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteInspitemclass(dbContext, inspItemclass));
	}

	private int DeleteInspitemclass(IDbContext dbContext, Inspitemclass inspItemclass)
	{
		return INSPITEMCLASS.UpsertInspItemClass(dbContext, RequestType.DELETE, new Inspitemclass[1] { inspItemclass }, null, saveHist: true);
	}

	public override void MessageValidation(IDbContext dbContext)
	{
		base.WEBDATA.WebdataMessage("SITEID", "INSPITEMCLASSID");
	}

	public override void RealDeleteAPI(IDbContext dbContext, Inspitemclass inspItemclass)
	{
		DBTransactionCheck(ACTIVITY, 2, RealDeleteInspitemclass(dbContext, inspItemclass));
	}

	private int RealDeleteInspitemclass(IDbContext dbContext, Inspitemclass inspItemclass)
	{
		return INSPITEMCLASS.UpsertInspItemClass(dbContext, RequestType.REALDELETE, new Inspitemclass[1] { inspItemclass }, null, saveHist: true);
	}

	public override void UpdateAPI(IDbContext dbContext, Inspitemclass inspItemclass)
	{
		Inspitemclass inspitemclass4Update = GetInspitemclass4Update(dbContext, inspItemclass);
		UpdateInspitemclass(dbContext, inspItemclass, inspitemclass4Update);
	}

	private Inspitemclass GetInspitemclass4Update(IDbContext dbContext, Inspitemclass inspItemclass)
	{
		Inspitemclass inspItemClass4Update = INSPITEMCLASS.GetInspItemClass4Update(dbContext, inspItemclass.Inspitemclassid, inspItemclass.Siteid);
		if (inspItemClass4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_004", "Inspitemclass");
		}
		return inspItemClass4Update;
	}

	private void UpdateInspitemclass(IDbContext dbContext, Inspitemclass inspItemclass, Inspitemclass inspItemclassCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(inspItemclass.Isusable))
		{
			num += INSPITEMCLASS.UpsertInspItemClass(dbContext, RequestType.DELETE, new Inspitemclass[1] { inspItemclass }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(inspItemclassCurrent.Isusable))
		{
			num += INSPITEMCLASS.UpsertInspItemClass(dbContext, RequestType.UNDELETE, new Inspitemclass[1] { inspItemclass }, null, saveHist: true);
			flag = true;
		}
		num += INSPITEMCLASS.UpsertInspItemClass(dbContext, RequestType.UPDATE, new Inspitemclass[1] { inspItemclass }, null, saveHist: true);
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
