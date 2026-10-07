using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_MenuObjectSave : ModelerRuleBiz<Menuobject>
{
	private int CreateMenuObject(IDbContext dbContext, Menuobject menuObject)
	{
		Menuobject menuObject4Update = MENUOBJECT.GetMenuObject4Update(dbContext, menuObject.Objectid, menuObject.Menuid, menuObject.Menuclassid, menuObject.Siteid);
		if (menuObject4Update != null)
		{
			UpdateMenuObject(dbContext, menuObject, menuObject4Update);
			return 2;
		}
		return MENUOBJECT.UpsertMenuObject(dbContext, RequestType.CREATE, new Menuobject[1] { menuObject }, null, saveHist: true);
	}

	private int DeleteMenuObject(IDbContext dbContext, Menuobject menuObject)
	{
		return MENUOBJECT.UpsertMenuObject(dbContext, RequestType.DELETE, new Menuobject[1] { menuObject }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Menuobject menuobject)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateMenuObject(dbContext, menuobject));
	}

	public override void DeleteAPI(IDbContext dbContext, Menuobject menuobject)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteMenuObject(dbContext, menuobject));
	}

	public override void UpdateAPI(IDbContext dbContext, Menuobject menuobject)
	{
		UpdateMenuObject(dbContext, menuobject, GetMenuObject4Update(dbContext, menuobject));
	}

	private Menuobject GetMenuObject4Update(IDbContext dbContext, Menuobject menuObject)
	{
		Menuobject menuObject4Update = MENUOBJECT.GetMenuObject4Update(dbContext, menuObject.Objectid, menuObject.Menuid, menuObject.Menuclassid, menuObject.Siteid);
		if (menuObject4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "MENUOBJECT", "OBJECTID: " + menuObject.Objectid + ", MENUID: " + menuObject.Menuid + ", MENUCLASSID: " + menuObject.Menuclassid + ", SITEID: " + menuObject.Siteid);
		}
		return menuObject4Update;
	}

	private void UpdateMenuObject(IDbContext dbContext, Menuobject menuObject, Menuobject menuObjectCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(menuObject.Isusable))
		{
			DBTransactionCheck(ACTIVITY, 2, MENUOBJECT.UpsertMenuObject(dbContext, RequestType.DELETE, new Menuobject[1] { menuObject }, null, saveHist: true));
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(menuObjectCurrent.Isusable))
		{
			num += MENUOBJECT.UpsertMenuObject(dbContext, RequestType.UNDELETE, new Menuobject[1] { menuObject }, null, saveHist: true);
			flag = true;
		}
		num += MENUOBJECT.UpsertMenuObject(dbContext, RequestType.UPDATE, new Menuobject[1] { menuObject }, null, saveHist: true);
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
