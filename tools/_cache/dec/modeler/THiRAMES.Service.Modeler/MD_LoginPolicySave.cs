using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_LoginPolicySave : ModelerRuleBiz<Loginpolicy>
{
	private int CreateLoginPolicy(IDbContext dbContext, Loginpolicy inputLoginPolicy)
	{
		Loginpolicy loginPolicy4Update = LOGINPOLICY.GetLoginPolicy4Update(dbContext, inputLoginPolicy.Logindefinitionid, inputLoginPolicy.Siteid);
		if (loginPolicy4Update != null)
		{
			SetCommonData(dbContext, inputLoginPolicy, ACTIVITY, RequestType.UPDATE);
			UpdateLoginPolicy(dbContext, inputLoginPolicy, loginPolicy4Update);
			return 2;
		}
		SetCommonData(dbContext, inputLoginPolicy, ACTIVITY, RequestType.CREATE);
		return LOGINPOLICY.UpsertLoginPolicy(dbContext, RequestType.CREATE, new Loginpolicy[1] { inputLoginPolicy }, null, saveHist: true);
	}

	private int DeleteLoginPolicy(IDbContext dbContext, Loginpolicy loginPolicy)
	{
		return LOGINPOLICY.UpsertLoginPolicy(dbContext, RequestType.DELETE, new Loginpolicy[1] { loginPolicy }, null, saveHist: true);
	}

	public override void MessageValidation(IDbContext dbContext)
	{
		base.WEBDATA.WebdataMessage("SITEID", "LOGINDEFINITIONID", "LOGINRETRYCOUNT", "PASSWORDCHANGEPERIOD", "PASSWORDCHANGEUNIT", "PASSWORDMINLENGTH", "PASSWORDPATTERN", "ISCREATETEMPPASSWORD", "ISCHANGEABLEPASSWORD", "ISINITIALIZABLEPASSWORD", "AUTHORITYUSERCLASSID");
	}

	public override void Process(IDbContext dbContext)
	{
		Loginpolicy[] webdata = GetWebdata(dbContext);
		foreach (Loginpolicy inputLoginPolicy in webdata)
		{
			CreateLoginPolicy(dbContext, inputLoginPolicy);
		}
	}

	public override void CreateAPI(IDbContext dbContext, Loginpolicy loginpolicy)
	{
	}

	public override void DeleteAPI(IDbContext dbContext, Loginpolicy loginpolicy)
	{
	}

	public override void UpdateAPI(IDbContext dbContext, Loginpolicy loginpolicy)
	{
	}

	private Loginpolicy GetLoginPolicy4Update(IDbContext dbContext, Loginpolicy loginPolicy)
	{
		return LOGINPOLICY.GetLoginPolicy4Update(dbContext, loginPolicy.Logindefinitionid, loginPolicy.Siteid);
	}

	private void UpdateLoginPolicy(IDbContext dbContext, Loginpolicy loginPolicy, Loginpolicy loginPolicyCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(loginPolicy.Isusable))
		{
			num += LOGINPOLICY.UpsertLoginPolicy(dbContext, RequestType.DELETE, new Loginpolicy[1] { loginPolicy }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(loginPolicyCurrent.Isusable))
		{
			num += LOGINPOLICY.UpsertLoginPolicy(dbContext, RequestType.UNDELETE, new Loginpolicy[1] { loginPolicy }, null, saveHist: true);
			flag = true;
		}
		num += LOGINPOLICY.UpsertLoginPolicy(dbContext, RequestType.UPDATE, new Loginpolicy[1] { loginPolicy }, null, saveHist: true);
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
