using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_CodeSave : ModelerRuleBiz<Code>
{
	private int CreateCode(IDbContext dbContext, Code code)
	{
		Code code2 = CODE.GetCode(dbContext, code.Codeid, code.Codeclassid, code.Siteid);
		if (code2 != null)
		{
			UpdateCode(dbContext, code, code2);
			return 2;
		}
		return CODE.UpsertCode(dbContext, RequestType.CREATE, new Code[1] { code }, null, saveHist: true);
	}

	private int DeleteCode(IDbContext dbContext, Code code)
	{
		return CODE.UpsertCode(dbContext, RequestType.DELETE, new Code[1] { code }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Code code)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateCode(dbContext, code));
	}

	public override void DeleteAPI(IDbContext dbContext, Code code)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteCode(dbContext, code));
	}

	public override void UpdateAPI(IDbContext dbContext, Code code)
	{
		UpdateCode(dbContext, code, GetCode4Update(dbContext, code));
	}

	private Code GetCode4Update(IDbContext dbContext, Code code)
	{
		Code code2 = CODE.GetCode(dbContext, code.Codeid, code.Codeclassid, code.Siteid);
		if (code2 == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "CODE", "CODEID: " + code.Codeid + ", CLASSID: " + code.Codeclassid + ", SITEID: " + code.Siteid);
		}
		return code2;
	}

	private void UpdateCode(IDbContext dbContext, Code code, Code codeCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(code.Isusable))
		{
			num += CODE.UpsertCode(dbContext, RequestType.DELETE, new Code[1] { code }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(codeCurrent.Isusable))
		{
			num += CODE.UpsertCode(dbContext, RequestType.UNDELETE, new Code[1] { code }, null, saveHist: true);
			flag = true;
		}
		num += CODE.UpsertCode(dbContext, RequestType.UPDATE, new Code[1] { code }, null, saveHist: true);
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
