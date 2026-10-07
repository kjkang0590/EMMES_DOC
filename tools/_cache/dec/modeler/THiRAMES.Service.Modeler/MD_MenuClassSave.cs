using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_MenuClassSave : ModelerRuleBiz<Menuclass>
{
	private int CreateMenuClass(IDbContext dbContext, Menuclass menuClass)
	{
		Menuclass menuClass4Update = MENUCLASS.GetMenuClass4Update(dbContext, menuClass.Menuclassid, menuClass.Siteid);
		if (menuClass4Update != null)
		{
			UpdateMenuClass(dbContext, menuClass, menuClass4Update);
			return 2;
		}
		return MENUCLASS.UpsertMenuClass(dbContext, RequestType.CREATE, new Menuclass[1] { menuClass }, null, saveHist: true);
	}

	private int DeleteMenuClass(IDbContext dbContext, Menuclass menuClass)
	{
		return MENUCLASS.UpsertMenuClass(dbContext, RequestType.DELETE, new Menuclass[1] { menuClass }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Menuclass menuclass)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateMenuClass(dbContext, menuclass));
	}

	public override void DeleteAPI(IDbContext dbContext, Menuclass menuclass)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteMenuClass(dbContext, menuclass));
	}

	public override void UpdateAPI(IDbContext dbContext, Menuclass menuclass)
	{
		UpdateMenuClass(dbContext, menuclass, GetMenuClass4Update(dbContext, menuclass));
	}

	private Menuclass GetMenuClass4Update(IDbContext dbContext, Menuclass menuClass)
	{
		Menuclass menuClass4Update = MENUCLASS.GetMenuClass4Update(dbContext, menuClass.Menuclassid, menuClass.Siteid);
		if (menuClass4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "MENUCLASS", "MENUCLASSID: " + menuClass.Menuclassid + ", SITEID: " + menuClass.Siteid);
		}
		return menuClass4Update;
	}

	private void UpdateMenuClass(IDbContext dbContext, Menuclass menuClass, Menuclass menuClassCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(menuClass.Isusable))
		{
			num += MENUCLASS.UpsertMenuClass(dbContext, RequestType.DELETE, new Menuclass[1] { menuClass }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(menuClassCurrent.Isusable))
		{
			num += MENUCLASS.UpsertMenuClass(dbContext, RequestType.UNDELETE, new Menuclass[1] { menuClass }, null, saveHist: true);
			flag = true;
		}
		num += MENUCLASS.UpsertMenuClass(dbContext, RequestType.UPDATE, new Menuclass[1] { menuClass }, null, saveHist: true);
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
