using CIM.MES.API.QMS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_InspDefinitionSave : ModelerRuleBiz<Inspdefinition>
{
	public override void CreateAPI(IDbContext dbContext, Inspdefinition inspDefinition)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateInspdefinition(dbContext, inspDefinition));
	}

	private int CreateInspdefinition(IDbContext dbContext, Inspdefinition inspDefinition)
	{
		Inspdefinition inspDefinition4Update = INSPDEFINITION.GetInspDefinition4Update(dbContext, inspDefinition.Inspdefinitionsysid, inspDefinition.Siteid);
		if (inspDefinition4Update != null)
		{
			UpdateInspdefinition(dbContext, inspDefinition, inspDefinition4Update);
			return 2;
		}
		inspDefinition.Inspdefinitionsysid = CreateInspdefinitionSysId(dbContext, inspDefinition.Insptype);
		return INSPDEFINITION.UpsertInspDefinition(dbContext, RequestType.CREATE, new Inspdefinition[1] { inspDefinition }, null, saveHist: true);
	}

	private string CreateInspdefinitionSysId(IDbContext dbContext, string itemId)
	{
		return GenerateIdPattern(dbContext, "INSPDEFINITIONSYSID", 1, itemId)[0];
	}

	public override void DeleteAPI(IDbContext dbContext, Inspdefinition inspDefinition)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteInspdefinition(dbContext, inspDefinition));
	}

	private int DeleteInspdefinition(IDbContext dbContext, Inspdefinition InspDefinition)
	{
		return INSPDEFINITION.UpsertInspDefinition(dbContext, RequestType.DELETE, new Inspdefinition[1] { InspDefinition }, null, saveHist: true);
	}

	public override void MessageValidation(IDbContext dbContext)
	{
		base.WEBDATA.WebdataMessage("SITEID", "COPERATOR", "ITEMID", "INSPTYPE", "REV", "INSPSPEC");
	}

	public override void Process(IDbContext dbContext)
	{
		Inspdefinition[] webdata = GetWebdata(dbContext);
		foreach (Inspdefinition inspdefinition in webdata)
		{
			switch (inspdefinition.ValueCollection["_ROW_STATE"] as string)
			{
			case "A":
				SetCommonData(dbContext, inspdefinition, ACTIVITY, RequestType.CREATE, base.RequestData.TID);
				CreateAPI(dbContext, inspdefinition);
				break;
			case "U":
				SetCommonData(dbContext, inspdefinition, ACTIVITY, RequestType.UPDATE, base.RequestData.TID);
				UpdateAPI(dbContext, inspdefinition);
				break;
			case "D":
				SetCommonData(dbContext, inspdefinition, ACTIVITY, RequestType.DELETE, base.RequestData.TID);
				DeleteAPI(dbContext, inspdefinition);
				break;
			case "RD":
				SetCommonData(dbContext, inspdefinition, ACTIVITY, RequestType.REALDELETE, base.RequestData.TID);
				RealDeleteAPI(dbContext, inspdefinition);
				break;
			default:
				throw new MesMultiLanguageException("E_MES_MODELER_003", "_ROW_STATE", inspdefinition.ValueCollection["_ROW_STATE"].ToString());
			}
		}
	}

	public override void RealDeleteAPI(IDbContext dbContext, Inspdefinition inspDefinition)
	{
		DBTransactionCheck(ACTIVITY, 2, RealDeleteInspdefinition(dbContext, inspDefinition));
	}

	private int RealDeleteInspdefinition(IDbContext dbContext, Inspdefinition InspDefinition)
	{
		return INSPDEFINITION.UpsertInspDefinition(dbContext, RequestType.REALDELETE, new Inspdefinition[1] { InspDefinition }, null, saveHist: true);
	}

	public override void UpdateAPI(IDbContext dbContext, Inspdefinition inspDefinition)
	{
		Inspdefinition inspdefinition4Update = GetInspdefinition4Update(dbContext, inspDefinition);
		UpdateInspdefinition(dbContext, inspDefinition, inspdefinition4Update);
	}

	private Inspdefinition GetInspdefinition4Update(IDbContext dbContext, Inspdefinition InspDefinition)
	{
		Inspdefinition inspDefinition4Update = INSPDEFINITION.GetInspDefinition4Update(dbContext, InspDefinition.Inspdefinitionsysid, InspDefinition.Siteid);
		if (inspDefinition4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_004", "INSPDEFINITION");
		}
		return inspDefinition4Update;
	}

	private void UpdateInspdefinition(IDbContext dbContext, Inspdefinition InspDefinition, Inspdefinition InspDefinitionCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(InspDefinition.Isusable))
		{
			num += INSPDEFINITION.UpsertInspDefinition(dbContext, RequestType.DELETE, new Inspdefinition[1] { InspDefinition }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(InspDefinitionCurrent.Isusable))
		{
			num += INSPDEFINITION.UpsertInspDefinition(dbContext, RequestType.UNDELETE, new Inspdefinition[1] { InspDefinition }, null, saveHist: true);
			flag = true;
		}
		num += INSPDEFINITION.UpsertInspDefinition(dbContext, RequestType.UPDATE, new Inspdefinition[1] { InspDefinition }, null, saveHist: true);
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
