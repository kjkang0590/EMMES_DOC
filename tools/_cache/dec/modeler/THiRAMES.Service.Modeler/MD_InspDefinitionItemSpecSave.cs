using System.Linq;
using CIM.MES.API.QMS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_InspDefinitionItemSpecSave : ModelerRuleBiz<Inspdefinitionitemspec>
{
	public override void CreateAPI(IDbContext dbContext, Inspdefinitionitemspec inspdefinitionitemspec)
	{
		Inspdefinitionitemspec inspDefinitionItemSpec4Update = INSPDEFINITIONITEMSPEC.GetInspDefinitionItemSpec4Update(dbContext, inspdefinitionitemspec.Inspdefinitionitemspecsysid, inspdefinitionitemspec.Siteid);
		if (inspDefinitionItemSpec4Update != null)
		{
			UpdateInspdefinitionItemSpec(dbContext, inspdefinitionitemspec, inspDefinitionItemSpec4Update);
			return;
		}
		inspdefinitionitemspec.Inspdefinitionitemspecsysid = CreateInspdefinitionItemSpecSysId(dbContext, inspdefinitionitemspec.Inspdefinitionsysid);
		DBTransactionCheck(ACTIVITY, 2, CreateInspdefinitionItemSpec(dbContext, inspdefinitionitemspec));
	}

	private int CreateInspdefinitionItemSpec(IDbContext dbContext, Inspdefinitionitemspec InspDefinitionItemSpec)
	{
		return INSPDEFINITIONITEMSPEC.UpsertInspDefinitionItemSpec(dbContext, RequestType.CREATE, new Inspdefinitionitemspec[1] { InspDefinitionItemSpec }, null, saveHist: true);
	}

	private string CreateInspdefinitionItemSpecSysId(IDbContext dbContext, string itemid)
	{
		return GenerateIdPattern(dbContext, "INSPDEFINITIONITEMSPECSYSID", 1, itemid)[0];
	}

	public override void DeleteAPI(IDbContext dbContext, Inspdefinitionitemspec inspdefinitionitemspec)
	{
		GetInspdefinitionItemSpec4Update(dbContext, inspdefinitionitemspec);
		DBTransactionCheck(ACTIVITY, 2, DeleteInspdefinitionItemSpec(dbContext, inspdefinitionitemspec));
	}

	private int DeleteInspdefinitionItemSpec(IDbContext dbContext, Inspdefinitionitemspec InspDefinitionItemSpec)
	{
		return INSPDEFINITIONITEMSPEC.UpsertInspDefinitionItemSpec(dbContext, RequestType.DELETE, new Inspdefinitionitemspec[1] { InspDefinitionItemSpec }, null, saveHist: true);
	}

	public override void MessageValidation(IDbContext dbContext)
	{
		base.WEBDATA.WebdataMessage("SITEID", "INSPDEFINITIONSYSID", "INSPITEMID", "REV", "ISMANDATORY");
	}

	public override void Process(IDbContext dbContext)
	{
		if (base.WEBDATA.Count < 1)
		{
			return;
		}
		Inspdefinitionitemspec[] webdata = GetWebdata(dbContext);
		if ((from g in webdata
			group g by g.Inspdefinitionsysid).ToDictionary((IGrouping<string, Inspdefinitionitemspec> g) => g.Key, (IGrouping<string, Inspdefinitionitemspec> g) => g.ToList()).Count > 1)
		{
			throw new MesMultiLanguageException("");
		}
		Inspdefinitionitemspec[] array = webdata;
		foreach (Inspdefinitionitemspec inspdefinitionitemspec in array)
		{
			switch (inspdefinitionitemspec.ValueCollection["_ROW_STATE"] as string)
			{
			case "A":
				SetCommonData(dbContext, inspdefinitionitemspec, ACTIVITY, RequestType.CREATE, base.RequestData.TID);
				CreateAPI(dbContext, inspdefinitionitemspec);
				break;
			case "U":
				SetCommonData(dbContext, inspdefinitionitemspec, ACTIVITY, RequestType.UPDATE, base.RequestData.TID);
				UpdateAPI(dbContext, inspdefinitionitemspec);
				break;
			case "D":
				SetCommonData(dbContext, inspdefinitionitemspec, ACTIVITY, RequestType.DELETE, base.RequestData.TID);
				DeleteAPI(dbContext, inspdefinitionitemspec);
				break;
			case "RD":
				SetCommonData(dbContext, inspdefinitionitemspec, ACTIVITY, RequestType.REALDELETE, base.RequestData.TID);
				RealDeleteAPI(dbContext, inspdefinitionitemspec);
				break;
			default:
				throw new MesMultiLanguageException("E_MES_MODELER_003", "_ROW_STATE", inspdefinitionitemspec.ValueCollection["_ROW_STATE"].ToString());
			}
		}
	}

	public override void RealDeleteAPI(IDbContext dbContext, Inspdefinitionitemspec inspdefinitionitemspec)
	{
		DBTransactionCheck(ACTIVITY, 2, RealDeleteInspdefinitionItemSpec(dbContext, inspdefinitionitemspec));
	}

	private int RealDeleteInspdefinitionItemSpec(IDbContext dbContext, Inspdefinitionitemspec InspDefinitionItemSpec)
	{
		return INSPDEFINITIONITEMSPEC.UpsertInspDefinitionItemSpec(dbContext, RequestType.REALDELETE, new Inspdefinitionitemspec[1] { InspDefinitionItemSpec }, null, saveHist: true);
	}

	public override void UpdateAPI(IDbContext dbContext, Inspdefinitionitemspec inspdefinitionitemspec)
	{
		Inspdefinitionitemspec inspdefinitionItemSpec4Update = GetInspdefinitionItemSpec4Update(dbContext, inspdefinitionitemspec);
		UpdateInspdefinitionItemSpec(dbContext, inspdefinitionitemspec, inspdefinitionItemSpec4Update);
	}

	private Inspdefinitionitemspec GetInspdefinitionItemSpec4Update(IDbContext dbContext, Inspdefinitionitemspec inspDefinitionItemSpec)
	{
		Inspdefinitionitemspec inspDefinitionItemSpec4Update = INSPDEFINITIONITEMSPEC.GetInspDefinitionItemSpec4Update(dbContext, inspDefinitionItemSpec.Inspdefinitionitemspecsysid, inspDefinitionItemSpec.Siteid);
		if (inspDefinitionItemSpec4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_004", "INSPDEFINITIONITEMSPECSYSID: " + inspDefinitionItemSpec.Inspdefinitionitemspecsysid + ", SITEID: " + inspDefinitionItemSpec.Siteid);
		}
		return inspDefinitionItemSpec4Update;
	}

	private void UpdateInspdefinitionItemSpec(IDbContext dbContext, Inspdefinitionitemspec inspDefinitionItemSpec, Inspdefinitionitemspec inspDefinitionItemSpecCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(inspDefinitionItemSpec.Isusable))
		{
			num += INSPDEFINITIONITEMSPEC.UpsertInspDefinitionItemSpec(dbContext, RequestType.DELETE, new Inspdefinitionitemspec[1] { inspDefinitionItemSpec }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(inspDefinitionItemSpecCurrent.Isusable))
		{
			num += INSPDEFINITIONITEMSPEC.UpsertInspDefinitionItemSpec(dbContext, RequestType.UNDELETE, new Inspdefinitionitemspec[1] { inspDefinitionItemSpec }, null, saveHist: true);
			flag = true;
		}
		num += INSPDEFINITIONITEMSPEC.UpsertInspDefinitionItemSpec(dbContext, RequestType.UPDATE, new Inspdefinitionitemspec[1] { inspDefinitionItemSpec }, null, saveHist: true);
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
