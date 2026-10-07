using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_UserMenuRelSave : ModelerRuleBiz<Usermenurel>
{
	private int CreateUserMenuRel(IDbContext dbContext, Usermenurel userMenuRel)
	{
		Usermenurel userMenuRel4Update = USERMENUREL.GetUserMenuRel4Update(dbContext, userMenuRel.Userid, userMenuRel.Menuid, userMenuRel.Menuclassid, userMenuRel.Siteid);
		if (userMenuRel4Update != null)
		{
			UpdateUserMenuRel(dbContext, userMenuRel, userMenuRel4Update);
			return 2;
		}
		return USERMENUREL.UpsertUserMenuRel(dbContext, RequestType.CREATE, new Usermenurel[1] { userMenuRel }, null, saveHist: true);
	}

	private int DeleteUserMenuRel(IDbContext dbContext, Usermenurel userMenuRel)
	{
		return USERMENUREL.UpsertUserMenuRel(dbContext, RequestType.DELETE, new Usermenurel[1] { userMenuRel }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Usermenurel usermenurel)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateUserMenuRel(dbContext, usermenurel));
	}

	public override void DeleteAPI(IDbContext dbContext, Usermenurel usermenurel)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteUserMenuRel(dbContext, usermenurel));
	}

	public override void UpdateAPI(IDbContext dbContext, Usermenurel usermenurel)
	{
		UpdateUserMenuRel(dbContext, usermenurel, GetUserMenuRel4Update(dbContext, usermenurel));
	}

	private Usermenurel GetUserMenuRel4Update(IDbContext dbContext, Usermenurel userMenuRel)
	{
		Usermenurel userMenuRel4Update = USERMENUREL.GetUserMenuRel4Update(dbContext, userMenuRel.Userid, userMenuRel.Menuid, userMenuRel.Menuclassid, userMenuRel.Siteid);
		if (userMenuRel4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "USERMENUREL", "USERID: " + userMenuRel.Userid + ", MENUID: " + userMenuRel.Menuid + ", MENUCLASSID: " + userMenuRel.Menuclassid + ", SITEID: " + userMenuRel.Siteid);
		}
		return userMenuRel4Update;
	}

	private void UpdateUserMenuRel(IDbContext dbContext, Usermenurel userMenuRel, Usermenurel userMenuRelCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(userMenuRel.Isusable))
		{
			num += USERMENUREL.UpsertUserMenuRel(dbContext, RequestType.DELETE, new Usermenurel[1] { userMenuRel }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(userMenuRelCurrent.Isusable))
		{
			num += USERMENUREL.UpsertUserMenuRel(dbContext, RequestType.UNDELETE, new Usermenurel[1] { userMenuRel }, null, saveHist: true);
			flag = true;
		}
		num += USERMENUREL.UpsertUserMenuRel(dbContext, RequestType.UPDATE, new Usermenurel[1] { userMenuRel }, null, saveHist: true);
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
