using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_UserSave : ModelerRuleBiz<User>
{
	private int CreateUser(IDbContext dbContext, User user)
	{
		User user4Update = USER.GetUser4Update(dbContext, user.Userid, user.Siteid);
		if (user4Update != null)
		{
			UpdateUser(dbContext, user, user4Update);
			return 2;
		}
		return USER.UpsertUser(dbContext, RequestType.CREATE, new User[1] { user }, null, saveHist: true);
	}

	private int DeleteUser(IDbContext dbContext, User user)
	{
		return USER.UpsertUser(dbContext, RequestType.DELETE, new User[1] { user }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, User user)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateUser(dbContext, user));
	}

	public override void DeleteAPI(IDbContext dbContext, User user)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteUser(dbContext, user));
	}

	public override void UpdateAPI(IDbContext dbContext, User user)
	{
		UpdateUser(dbContext, user, GetUser4Update(dbContext, user));
	}

	private User GetUser4Update(IDbContext dbContext, User user)
	{
		User user4Update = USER.GetUser4Update(dbContext, user.Userid, user.Siteid);
		if (user4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "USER", "USERID: " + user.Userid + ", SITEID: " + user.Siteid);
		}
		return user4Update;
	}

	private void UpdateUser(IDbContext dbContext, User user, User userCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(user.Isusable))
		{
			num += USER.UpsertUser(dbContext, RequestType.DELETE, new User[1] { user }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(userCurrent.Isusable))
		{
			num += USER.UpsertUser(dbContext, RequestType.UNDELETE, new User[1] { user }, null, saveHist: true);
			flag = true;
		}
		num += USER.UpsertUser(dbContext, RequestType.UPDATE, new User[1] { user }, null, saveHist: true);
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
