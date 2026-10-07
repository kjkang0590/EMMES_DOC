using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_UserClassSave : ModelerRuleBiz<Userclass>
{
	private int CreateUserClass(IDbContext dbContext, Userclass userClass)
	{
		Userclass userClass4Update = USERCLASS.GetUserClass4Update(dbContext, userClass.Userclassid, userClass.Siteid);
		if (userClass4Update != null)
		{
			UpdateUserClass(dbContext, userClass, userClass4Update);
			return 2;
		}
		return USERCLASS.UpsertUserClass(dbContext, RequestType.CREATE, new Userclass[1] { userClass }, null, saveHist: true);
	}

	private int DeleteUserClass(IDbContext dbContext, Userclass userClass)
	{
		return USERCLASS.UpsertUserClass(dbContext, RequestType.DELETE, new Userclass[1] { userClass }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Userclass userclass)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateUserClass(dbContext, userclass));
	}

	public override void DeleteAPI(IDbContext dbContext, Userclass userclass)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteUserClass(dbContext, userclass));
	}

	public override void UpdateAPI(IDbContext dbContext, Userclass userclass)
	{
		UpdateUserClass(dbContext, userclass, GetUserClass4Update(dbContext, userclass));
	}

	private Userclass GetUserClass4Update(IDbContext dbContext, Userclass userClass)
	{
		Userclass userClass4Update = USERCLASS.GetUserClass4Update(dbContext, userClass.Userclassid, userClass.Siteid);
		if (userClass4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "USERCLASS", "USERCLASSID: " + userClass.Userclassid + ", SITEID: " + userClass.Siteid);
		}
		return userClass4Update;
	}

	private void UpdateUserClass(IDbContext dbContext, Userclass userClass, Userclass userClassCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(userClass.Isusable))
		{
			num += USERCLASS.UpsertUserClass(dbContext, RequestType.DELETE, new Userclass[1] { userClass }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(userClassCurrent.Isusable))
		{
			num += USERCLASS.UpsertUserClass(dbContext, RequestType.UNDELETE, new Userclass[1] { userClass }, null, saveHist: true);
			flag = true;
		}
		num += USERCLASS.UpsertUserClass(dbContext, RequestType.UPDATE, new Userclass[1] { userClass }, null, saveHist: true);
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
