using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_UserClassRelSave : ModelerRuleBiz<Userclassrel>
{
	private int CreateUserClassRel(IDbContext dbContext, Userclassrel userClassRel)
	{
		Userclassrel userClassRel4Update = USERCLASSREL.GetUserClassRel4Update(dbContext, userClassRel.Userclassid, userClassRel.Userid, userClassRel.Siteid);
		if (userClassRel4Update != null)
		{
			UpdateUserClassRel(dbContext, userClassRel, userClassRel4Update);
			return 2;
		}
		return USERCLASSREL.UpsertUserClassRel(dbContext, RequestType.CREATE, new Userclassrel[1] { userClassRel }, null, saveHist: true);
	}

	private int DeleteUserClassRel(IDbContext dbContext, Userclassrel userClassRel)
	{
		return USERCLASSREL.UpsertUserClassRel(dbContext, RequestType.DELETE, new Userclassrel[1] { userClassRel }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Userclassrel userclassrel)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateUserClassRel(dbContext, userclassrel));
	}

	public override void DeleteAPI(IDbContext dbContext, Userclassrel userclassrel)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteUserClassRel(dbContext, userclassrel));
	}

	public override void UpdateAPI(IDbContext dbContext, Userclassrel userclassrel)
	{
		UpdateUserClassRel(dbContext, userclassrel, GetUserClassRel4Update(dbContext, userclassrel));
	}

	private Userclassrel GetUserClassRel4Update(IDbContext dbContext, Userclassrel userClassRel)
	{
		Userclassrel userClassRel4Update = USERCLASSREL.GetUserClassRel4Update(dbContext, userClassRel.Userclassid, userClassRel.Userid, userClassRel.Siteid);
		if (userClassRel4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "USERCLASSREL", "USERCLASSID: " + userClassRel.Userclassid + ", USERID: " + userClassRel.Userid + ", SITEID: " + userClassRel.Siteid);
		}
		return userClassRel4Update;
	}

	private void UpdateUserClassRel(IDbContext dbContext, Userclassrel userClassRel, Userclassrel userClassRelCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(userClassRel.Isusable))
		{
			num += USERCLASSREL.UpsertUserClassRel(dbContext, RequestType.DELETE, new Userclassrel[1] { userClassRel }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(userClassRelCurrent.Isusable))
		{
			num += USERCLASSREL.UpsertUserClassRel(dbContext, RequestType.UNDELETE, new Userclassrel[1] { userClassRel }, null, saveHist: true);
			flag = true;
		}
		num += USERCLASSREL.UpsertUserClassRel(dbContext, RequestType.UPDATE, new Userclassrel[1] { userClassRel }, null, saveHist: true);
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
