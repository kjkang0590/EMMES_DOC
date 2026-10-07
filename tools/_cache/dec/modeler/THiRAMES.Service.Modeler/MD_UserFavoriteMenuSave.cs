using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_UserFavoriteMenuSave : ModelerRuleBiz<Userfavoritemenu>
{
	private int CreateUserfavoritemenu(IDbContext dbContext, Userfavoritemenu userfavoritemenu)
	{
		Userfavoritemenu userFavoriteMenu4Update = USERFAVORITEMENU.GetUserFavoriteMenu4Update(dbContext, userfavoritemenu.Userid, userfavoritemenu.Favoritemenuid, userfavoritemenu.Favoritemenuclassid, userfavoritemenu.Siteid);
		if (userFavoriteMenu4Update != null)
		{
			UpdateUserfavoritemenu(dbContext, userfavoritemenu, userFavoriteMenu4Update);
			return 2;
		}
		return USERFAVORITEMENU.UpsertUserFavoriteMenu(dbContext, RequestType.CREATE, new Userfavoritemenu[1] { userfavoritemenu }, null, saveHist: true);
	}

	private int DeleteUserfavoritemenu(IDbContext dbContext, Userfavoritemenu userfavoritemenu)
	{
		return USERFAVORITEMENU.UpsertUserFavoriteMenu(dbContext, RequestType.DELETE, new Userfavoritemenu[1] { userfavoritemenu }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Userfavoritemenu userfavoritemenu)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateUserfavoritemenu(dbContext, userfavoritemenu));
	}

	public override void DeleteAPI(IDbContext dbContext, Userfavoritemenu userfavoritemenu)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteUserfavoritemenu(dbContext, userfavoritemenu));
	}

	public override void UpdateAPI(IDbContext dbContext, Userfavoritemenu userfavoritemenu)
	{
		UpdateUserfavoritemenu(dbContext, userfavoritemenu, GetUserFavoriteMenu4Update(dbContext, userfavoritemenu));
	}

	private Userfavoritemenu GetUserFavoriteMenu4Update(IDbContext dbContext, Userfavoritemenu userfavoritemenu)
	{
		Userfavoritemenu userFavoriteMenu4Update = USERFAVORITEMENU.GetUserFavoriteMenu4Update(dbContext, userfavoritemenu.Userid, userfavoritemenu.Favoritemenuid, userfavoritemenu.Favoritemenuclassid, userfavoritemenu.Siteid);
		if (userFavoriteMenu4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "USERFAVORITEMENU", "USERID: " + userfavoritemenu.Userid + ", FAVORITEMENUID: " + userfavoritemenu.Favoritemenuid + ", FAVORITEMENUCLASSID: " + userfavoritemenu.Favoritemenuclassid + ", SITEID: " + userfavoritemenu.Siteid);
		}
		return userFavoriteMenu4Update;
	}

	private void UpdateUserfavoritemenu(IDbContext dbContext, Userfavoritemenu userfavoritemenu, Userfavoritemenu storedUserfavoritemenuCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(userfavoritemenu.Isusable))
		{
			num += USERFAVORITEMENU.UpsertUserFavoriteMenu(dbContext, RequestType.DELETE, new Userfavoritemenu[1] { userfavoritemenu }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(storedUserfavoritemenuCurrent.Isusable))
		{
			num += USERFAVORITEMENU.UpsertUserFavoriteMenu(dbContext, RequestType.UNDELETE, new Userfavoritemenu[1] { userfavoritemenu }, null, saveHist: true);
			flag = true;
		}
		num += USERFAVORITEMENU.UpsertUserFavoriteMenu(dbContext, RequestType.UPDATE, new Userfavoritemenu[1] { userfavoritemenu }, null, saveHist: true);
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
