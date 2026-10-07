using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_UserObjectRelSave : ModelerRuleBiz<Userobjectrel>
{
	private int CreateUserObjectRel(IDbContext dbContext, Userobjectrel userObjectRel)
	{
		Userobjectrel userObjectRel4Update = USEROBJECTREL.GetUserObjectRel4Update(dbContext, userObjectRel.Userid, userObjectRel.Objectid, userObjectRel.Menuid, userObjectRel.Menuclassid, userObjectRel.Siteid);
		if (userObjectRel4Update != null)
		{
			UpdateUserObjectRel(dbContext, userObjectRel, userObjectRel4Update);
			return 2;
		}
		return USEROBJECTREL.UpsertUserObjectRel(dbContext, RequestType.CREATE, new Userobjectrel[1] { userObjectRel }, null, saveHist: true);
	}

	private int DeleteUserObjectRel(IDbContext dbContext, Userobjectrel userObjectRel)
	{
		return USEROBJECTREL.UpsertUserObjectRel(dbContext, RequestType.DELETE, new Userobjectrel[1] { userObjectRel }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Userobjectrel userobjectrel)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateUserObjectRel(dbContext, userobjectrel));
	}

	public override void DeleteAPI(IDbContext dbContext, Userobjectrel userobjectrel)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteUserObjectRel(dbContext, userobjectrel));
	}

	public override void UpdateAPI(IDbContext dbContext, Userobjectrel userobjectrel)
	{
		UpdateUserObjectRel(dbContext, userobjectrel, GetUserObjectRel4Update(dbContext, userobjectrel));
	}

	private Userobjectrel GetUserObjectRel4Update(IDbContext dbContext, Userobjectrel userObjectRel)
	{
		Userobjectrel userObjectRel4Update = USEROBJECTREL.GetUserObjectRel4Update(dbContext, userObjectRel.Userid, userObjectRel.Objectid, userObjectRel.Menuid, userObjectRel.Menuclassid, userObjectRel.Siteid);
		if (userObjectRel4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "USEROBJECTREL", "USERID: " + userObjectRel.Userid + ", OBJECTID: " + userObjectRel.Objectid + ", MENUID: " + userObjectRel.Menuid + ", MENUCLASSID: " + userObjectRel.Menuclassid + ", SITEID: " + userObjectRel.Siteid);
		}
		return userObjectRel4Update;
	}

	private void UpdateUserObjectRel(IDbContext dbContext, Userobjectrel userObjectRel, Userobjectrel userObjectRelCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(userObjectRel.Isusable))
		{
			num += USEROBJECTREL.UpsertUserObjectRel(dbContext, RequestType.DELETE, new Userobjectrel[1] { userObjectRel }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(userObjectRelCurrent.Isusable))
		{
			num += USEROBJECTREL.UpsertUserObjectRel(dbContext, RequestType.UNDELETE, new Userobjectrel[1] { userObjectRel }, null, saveHist: true);
			flag = true;
		}
		num += USEROBJECTREL.UpsertUserObjectRel(dbContext, RequestType.UPDATE, new Userobjectrel[1] { userObjectRel }, null, saveHist: true);
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
