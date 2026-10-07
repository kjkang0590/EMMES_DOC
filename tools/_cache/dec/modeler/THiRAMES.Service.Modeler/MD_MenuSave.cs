using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_MenuSave : ModelerRuleBiz<Menu>
{
	private int CreateMenu(IDbContext dbContext, Menu menu)
	{
		Menu menu4Update = MENU.GetMenu4Update(dbContext, menu.Menuid, menu.Menuclassid, menu.Siteid);
		if (menu4Update != null)
		{
			UpdateMenu(dbContext, menu, menu4Update);
			return 2;
		}
		return MENU.UpsertMenu(dbContext, RequestType.CREATE, new Menu[1] { menu }, null, saveHist: true);
	}

	private int DeleteMenu(IDbContext dbContext, Menu menu)
	{
		return MENU.UpsertMenu(dbContext, RequestType.DELETE, new Menu[1] { menu }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Menu menu)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateMenu(dbContext, menu));
	}

	public override void DeleteAPI(IDbContext dbContext, Menu menu)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteMenu(dbContext, menu));
	}

	public override void UpdateAPI(IDbContext dbContext, Menu menu)
	{
		UpdateMenu(dbContext, menu, GetMenu4Update(dbContext, menu));
	}

	private Menu GetMenu4Update(IDbContext dbContext, Menu menu)
	{
		Menu menu4Update = MENU.GetMenu4Update(dbContext, menu.Menuid, menu.Menuclassid, menu.Siteid);
		if (menu4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "MENU", "MENUID: " + menu.Menuid + ", MENUCLASSID: " + menu.Menuclassid + ", SITEID: " + menu.Siteid);
		}
		return menu4Update;
	}

	private void UpdateMenu(IDbContext dbContext, Menu menu, Menu menuCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(menu.Isusable))
		{
			num += MENU.UpsertMenu(dbContext, RequestType.DELETE, new Menu[1] { menu }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(menuCurrent.Isusable))
		{
			num += MENU.UpsertMenu(dbContext, RequestType.UNDELETE, new Menu[1] { menu }, null, saveHist: true);
			flag = true;
		}
		num += MENU.UpsertMenu(dbContext, RequestType.UPDATE, new Menu[1] { menu }, null, saveHist: true);
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
