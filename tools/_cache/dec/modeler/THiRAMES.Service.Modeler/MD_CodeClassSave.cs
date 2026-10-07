using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_CodeClassSave : ModelerRuleBiz<Codeclass>
{
	public void CopyCodeClass(IDbContext dbContext, Codeclass codeclass)
	{
		string oldCode = codeclass.ValueCollection["OLDCODE"].ToString();
		string newCode = codeclass.ValueCollection["NEWCODE"].ToString();
		string newName = codeclass.ValueCollection["NEWNAME"].ToString();
		string siteId = codeclass.ValidatedValue("SITEID");
		CopyCodeClass(dbContext, newCode, newName, siteId);
		CopyCode(dbContext, newCode, oldCode, siteId);
	}

	private void CopyCodeClass(IDbContext dbContext, string newCode, string newName, string siteId)
	{
		Codeclass codeclass = new Codeclass();
		codeclass.Codeclassid = newCode;
		codeclass.Codeclassname = newName;
		codeclass.Siteid = siteId;
		SetCommonData(dbContext, codeclass, ACTIVITY, RequestType.CREATE, base.RequestData.TID);
		DBTransactionCheck(ACTIVITY, 2, CODECLASS.UpsertCodeClass(dbContext, RequestType.CREATE, new Codeclass[1] { codeclass }, null, saveHist: true));
	}

	private void CopyCode(IDbContext dbContext, string newCode, string oldCode, string siteId)
	{
		foreach (Code item in CODE.SelectCodeList(dbContext, oldCode, siteId))
		{
			item.Codeclassid = newCode;
			SetCommonData(dbContext, item, ACTIVITY, RequestType.CREATE, base.RequestData.TID);
			DBTransactionCheck(ACTIVITY, 2, CODE.UpsertCode(dbContext, RequestType.CREATE, new Code[1] { item }, null, saveHist: true));
		}
	}

	private int CreateCodeClass(IDbContext dbContext, Codeclass codeClass)
	{
		Codeclass codeClass4Update = CODECLASS.GetCodeClass4Update(dbContext, codeClass.Codeclassid, codeClass.Siteid);
		if (codeClass4Update != null)
		{
			UpdateCodeClass(dbContext, codeClass, codeClass4Update);
			return 2;
		}
		return CODECLASS.UpsertCodeClass(dbContext, RequestType.CREATE, new Codeclass[1] { codeClass }, null, saveHist: true);
	}

	private int DeleteCodeClass(IDbContext dbContext, Codeclass codeClass)
	{
		return CODECLASS.UpsertCodeClass(dbContext, RequestType.DELETE, new Codeclass[1] { codeClass }, null, saveHist: true);
	}

	public override void Process(IDbContext dbContext)
	{
		Codeclass[] webdata = GetWebdata(dbContext);
		foreach (Codeclass codeclass in webdata)
		{
			switch (codeclass.ValueCollection["_ROW_STATE"] as string)
			{
			case "A":
				SetCommonData(dbContext, codeclass, ACTIVITY, RequestType.CREATE, base.RequestData.TID);
				CreateAPI(dbContext, codeclass);
				break;
			case "U":
				SetCommonData(dbContext, codeclass, ACTIVITY, RequestType.UPDATE, base.RequestData.TID);
				UpdateAPI(dbContext, codeclass);
				break;
			case "D":
				SetCommonData(dbContext, codeclass, ACTIVITY, RequestType.DELETE, base.RequestData.TID);
				DeleteAPI(dbContext, codeclass);
				break;
			case "RD":
				SetCommonData(dbContext, codeclass, ACTIVITY, RequestType.REALDELETE, base.RequestData.TID);
				RealDeleteAPI(dbContext, codeclass);
				break;
			case "C":
				CopyCodeClass(dbContext, codeclass);
				break;
			default:
				throw new MesMultiLanguageException("E_MES_MODELER_003", "_ROW_STATE", codeclass.ValueCollection["_ROW_STATE"].ToString());
			}
		}
	}

	public override void CreateAPI(IDbContext dbContext, Codeclass codeclass)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateCodeClass(dbContext, codeclass));
	}

	public override void DeleteAPI(IDbContext dbContext, Codeclass codeclass)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteCodeClass(dbContext, codeclass));
	}

	public override void UpdateAPI(IDbContext dbContext, Codeclass codeclass)
	{
		UpdateCodeClass(dbContext, codeclass, GetCodeClass4Update(dbContext, codeclass));
	}

	private Codeclass GetCodeClass4Update(IDbContext dbContext, Codeclass codeClass)
	{
		Codeclass codeClass4Update = CODECLASS.GetCodeClass4Update(dbContext, codeClass.Codeclassid, codeClass.Siteid);
		if (codeClass4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "CODECLASS", "CODECLASSID: " + codeClass.Codeclassid + ", SITEID: " + codeClass.Siteid);
		}
		return codeClass4Update;
	}

	private void UpdateCodeClass(IDbContext dbContext, Codeclass codeClass, Codeclass codeClassCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(codeClass.Isusable))
		{
			num += CODECLASS.UpsertCodeClass(dbContext, RequestType.DELETE, new Codeclass[1] { codeClass }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(codeClassCurrent.Isusable))
		{
			num += CODECLASS.UpsertCodeClass(dbContext, RequestType.UNDELETE, new Codeclass[1] { codeClass }, null, saveHist: true);
			flag = true;
		}
		num += CODECLASS.UpsertCodeClass(dbContext, RequestType.UPDATE, new Codeclass[1] { codeClass }, null, saveHist: true);
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
