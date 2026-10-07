using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.CDS;

[MESAPI]
public class MENU
{
	private static string _sqlGetMenuSqlDatabase = "SELECT * FROM CIM_MENU WHERE MENUID=@MENUID AND MENUCLASSID=@MENUCLASSID AND SITEID=@SITEID";

	private static string _sqlGetMenu4UpdateSqlDatabase = "SELECT * FROM CIM_MENU WITH(UPDLOCK) WHERE MENUID=@MENUID AND MENUCLASSID=@MENUCLASSID AND SITEID=@SITEID";

	private static string _sqlSelectMenuSqlDatabase = "SELECT * FROM CIM_MENU WHERE MENUID=@MENUID AND MENUCLASSID=@MENUCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMenu4UpdateSqlDatabase = "SELECT * FROM CIM_MENU WITH(UPDLOCK) WHERE MENUID=@MENUID AND MENUCLASSID=@MENUCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetMenuOracleDatabase = "SELECT * FROM CIM_MENU WHERE MENUID=:MENUID AND MENUCLASSID=:MENUCLASSID AND SITEID=:SITEID";

	private static string _sqlGetMenu4UpdateOracleDatabase = "SELECT * FROM CIM_MENU WHERE MENUID=:MENUID AND MENUCLASSID=:MENUCLASSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectMenuOracleDatabase = "SELECT * FROM CIM_MENU WHERE MENUID=:MENUID AND MENUCLASSID=:MENUCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMenu4UpdateOracleDatabase = "SELECT * FROM CIM_MENU WHERE MENUID=:MENUID AND MENUCLASSID=:MENUCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Menu);

	private static string _sqlGetMenu4UserClassMenuRelSqlDatabase = "SELECT B.MENUID                     AS MENUID\n              ,B.MENUNAME                   AS MENUNAME\n              ,B.MENUTYPE                   AS MENUTYPE\n              ,B.PARENTID                   AS PARENTID\n              ,B.CONTROLTYPE                AS CONTROLTYPE\n              ,B.VIEWID                     AS VIEWID\n              ,B.SEQUENCE                   AS SEQUENCE\n              ,B.DEPTH                      AS DEPTH\n          FROM CIM_USERCLASSMENUREL A \n              ,CIM_MENU B \n         WHERE 1 = 1\n           AND A.ISUSABLE       = 'Usable'\n           AND A.MENUCLASSID    = @MENUCLASSID\n           AND A.MENUCLASSID    = B.MENUCLASSID\n           AND A.SITEID         = B.SITEID\n           AND A.MENUID         = B.MENUID\n           AND A.ISUSABLE       = B.ISUSABLE\n           AND A.SITEID         = @SITEID\n           AND A.USERCLASSID    = @USERCLASSID\n        ORDER BY B.DEPTH\n                ,B.SEQUENCE";

	private static string _sqlGetMenu4UserClassMenuRelOracleDatabase = "SELECT B.MENUID                     AS MENUID\n              ,B.MENUNAME                   AS MENUNAME\n              ,B.MENUTYPE                   AS MENUTYPE\n              ,B.PARENTID                   AS PARENTID\n              ,B.CONTROLTYPE                AS CONTROLTYPE\n              ,B.VIEWID                     AS VIEWID\n              ,B.SEQUENCE                   AS SEQUENCE\n              ,B.DEPTH                      AS DEPTH\n          FROM CIM_USERCLASSMENUREL A\n              ,CIM_MENU B\n         WHERE 1 = 1\n           AND A.ISUSABLE       = 'Usable'\n           AND A.MENUCLASSID    = :MENUCLASSID\n           AND A.MENUCLASSID    = B.MENUCLASSID\nAND A.SITEID         = B.SITEID\n           AND A.MENUID         = B.MENUID\n           AND A.ISUSABLE       = B.ISUSABLE\n           AND A.SITEID         = :SITEID\n           AND A.USERCLASSID    = :USERCLASSID\n        ORDER BY B.DEPTH\n                ,B.SEQUENCE";

	private static string _sqlGetMenu4UserMenuRelSqlDatabase = "SELECT B.MENUID                     AS MENUID\n              ,B.MENUNAME                   AS MENUNAME\n              ,B.MENUTYPE                   AS MENUTYPE\n              ,B.PARENTID                   AS PARENTID\n              ,B.CONTROLTYPE                AS CONTROLTYPE\n              ,B.VIEWID                     AS VIEWID\n              ,B.SEQUENCE                   AS SEQUENCE\n              ,B.DEPTH                      AS DEPTH\n          FROM CIM_USERMENUREL A \n              ,CIM_MENU B \n         WHERE 1 = 1\n           AND A.ISUSABLE       = 'Usable'\n           AND A.MENUCLASSID    = @MENUCLASSID\n           AND A.MENUCLASSID    = B.MENUCLASSID\n           AND A.MENUID         = B.MENUID\nAND A.SITEID         = B.SITEID\n           AND A.ISUSABLE       = B.ISUSABLE\n           AND A.USERID         = @USERID\n           AND A.SITEID         = @SITEID\n        ORDER BY B.DEPTH\n                ,B.SEQUENCE";

	private static string _sqlGetMenu4UserMenuRelOracleDatabase = "SELECT B.MENUID                     AS MENUID\n              ,B.MENUNAME                   AS MENUNAME\n              ,B.MENUTYPE                   AS MENUTYPE\n              ,B.PARENTID                   AS PARENTID\n              ,B.CONTROLTYPE                AS CONTROLTYPE\n              ,B.VIEWID                     AS VIEWID\n              ,B.SEQUENCE                   AS SEQUENCE\n              ,B.DEPTH                      AS DEPTH\n          FROM CIM_USERMENUREL A\n              ,CIM_MENU B\n         WHERE 1 = 1\n           AND A.ISUSABLE       = 'Usable'\n           AND A.MENUCLASSID    = :MENUCLASSID\n           AND A.MENUCLASSID    = B.MENUCLASSID\nAND A.SITEID         = B.SITEID\n           AND A.MENUID         = B.MENUID\n           AND A.ISUSABLE       = B.ISUSABLE\n           AND A.USERID         = :USERID\n           AND A.SITEID         = :SITEID\n        ORDER BY B.DEPTH\n                ,B.SEQUENCE";

	private static string _sqlGetMenu4UserFavoriteMenuSqlDatabase = "SELECT B.MENUID                     AS MENUID\n              ,B.MENUNAME                   AS MENUNAME\n              ,B.MENUTYPE                   AS MENUTYPE\n              ,A.PARENTID                   AS PARENTID\n              ,B.CONTROLTYPE                AS CONTROLTYPE\n              ,B.VIEWID                     AS VIEWID\n              ,B.SEQUENCE                   AS SEQUENCE\n              ,B.DEPTH                      AS DEPTH\n          FROM CIM_USERFAVORITEMENU A \n              ,CIM_MENU B \n         WHERE 1 = 1\n           AND A.ISUSABLE               = 'Usable'\n           AND A.FAVORITEMENUCLASSID    = @MENUCLASSID\n           AND A.FAVORITEMENUCLASSID    = B.MENUCLASSID\nAND A.SITEID         = B.SITEID\n           AND A.FAVORITEMENUID         = B.MENUID\n           AND A.ISUSABLE               = B.ISUSABLE\n           AND A.SITEID                 = @SITEID\n           AND A.USERID                 = @USERID\n        ORDER BY B.DEPTH\n                ,B.SEQUENCE";

	private static string _sqlGetMenu4UserFavoriteMenuOracleDatabase = "SELECT B.MENUID                     AS MENUID\n              ,B.MENUNAME                   AS MENUNAME\n              ,B.MENUTYPE                   AS MENUTYPE\n              ,A.PARENTID                   AS PARENTID\n              ,B.CONTROLTYPE                AS CONTROLTYPE\n              ,B.VIEWID                     AS VIEWID\n              ,B.SEQUENCE                   AS SEQUENCE\n              ,B.DEPTH                      AS DEPTH\n          FROM CIM_USERFAVORITEMENU A\n              ,CIM_MENU B\n         WHERE 1 = 1\n           AND A.ISUSABLE               = 'Usable'\n           AND A.FAVORITEMENUCLASSID    = :MENUCLASSID\n           AND A.FAVORITEMENUCLASSID    = B.MENUCLASSID\n           AND A.FAVORITEMENUID         = B.MENUID\nAND A.SITEID         = B.SITEID\n           AND A.ISUSABLE               = B.ISUSABLE\n           AND A.SITEID                 = :SITEID\n           AND A.USERID                 = :USERID\n        ORDER BY B.DEPTH\n                ,B.SEQUENCE";

	private static Type typeOfUserFavoritMenu = typeof(Userfavoritemenu);

	private static Type typeOfUserClassMenuRel = typeof(Userclassmenurel);

	private static Type typeOfUserMenuRel = typeof(Userclassmenurel);

	public static Menu GetMenu(IDbContext dbContext, string menuid, string menuclassid, string siteid)
	{
		string apiName = "GetMenu";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{menuid},{menuclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetMenuSqlDatabase : _sqlGetMenuOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUCLASSID", menuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MENU", $"{menuid},{menuclassid},{siteid}"));
		}
		Menu? result = ContextManager.DirectEntityQuery<Menu>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{menuid},{menuclassid},{siteid}");
		}
		return result;
	}

	public static Menu GetMenu4Update(IDbContext dbContext, string menuid, string menuclassid, string siteid)
	{
		string apiName = "GetMenu4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{menuid},{menuclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetMenu4UpdateSqlDatabase : _sqlGetMenu4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUCLASSID", menuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_MENU", $"{menuid},{menuclassid},{siteid}"));
		}
		Menu? result = ContextManager.DirectEntityQuery<Menu>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{menuid},{menuclassid},{siteid}");
		}
		return result;
	}

	public static Menu SelectMenu(IDbContext dbContext, string menuid, string menuclassid, string siteid)
	{
		string apiName = "SelectMenu";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{menuid},{menuclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMenuSqlDatabase : _sqlSelectMenuOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUCLASSID", menuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MENU", $"{menuid},{menuclassid},{siteid}"));
		}
		Menu? result = ContextManager.DirectEntityQuery<Menu>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{menuid},{menuclassid},{siteid}");
		}
		return result;
	}

	public static Menu SelectMenu4Update(IDbContext dbContext, string menuid, string menuclassid, string siteid)
	{
		string apiName = "SelectMenu4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{menuid},{menuclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMenu4UpdateSqlDatabase : _sqlSelectMenu4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUCLASSID", menuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_MENU", $"{menuid},{menuclassid},{siteid}"));
		}
		Menu? result = ContextManager.DirectEntityQuery<Menu>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{menuid},{menuclassid},{siteid}");
		}
		return result;
	}

	public static IList<Menu> GetMenu4UserClassMenuRel(IDbContext dbContext, string userClassid, string menuclassid, string siteid)
	{
		string apiName = "GetMenu4UserClassMenuRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userClassid},{menuclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetMenu4UserClassMenuRelSqlDatabase : _sqlGetMenu4UserClassMenuRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERCLASSID", userClassid, typeOfUserClassMenuRel));
		list.Add(dbContext.CreateParameter("MENUCLASSID", menuclassid, typeOfUserClassMenuRel));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfUserClassMenuRel));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MENU", $"{userClassid},{menuclassid},{siteid}"));
		}
		IList<Menu> result = ContextManager.DirectEntityQuery<Menu>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userClassid},{menuclassid},{siteid}");
		}
		return result;
	}

	public static IList<Menu> GetMenu4UserMenuRel(IDbContext dbContext, string userid, string menuclassid, string siteid)
	{
		string apiName = "GetMenu4UserMenuRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userid},{menuclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetMenu4UserMenuRelSqlDatabase : _sqlGetMenu4UserMenuRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfUserMenuRel));
		list.Add(dbContext.CreateParameter("MENUCLASSID", menuclassid, typeOfUserMenuRel));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfUserMenuRel));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MENU", $"{userid},{menuclassid},{siteid}"));
		}
		IList<Menu> result = ContextManager.DirectEntityQuery<Menu>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userid},{menuclassid},{siteid}");
		}
		return result;
	}

	public static IList<Menu> GetMenu4UserFavoriteMenu(IDbContext dbContext, string userid, string menuclassid, string siteid)
	{
		string apiName = "GetMenu4UserFavoriteMenu";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userid},{menuclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetMenu4UserFavoriteMenuSqlDatabase : _sqlGetMenu4UserFavoriteMenuOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfUserFavoritMenu));
		list.Add(dbContext.CreateParameter("MENUCLASSID", menuclassid, typeOfUserFavoritMenu));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfUserFavoritMenu));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MENU", $"{userid},{menuclassid},{siteid}"));
		}
		IList<Menu> result = ContextManager.DirectEntityQuery<Menu>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userid},{menuclassid},{siteid}");
		}
		return result;
	}

	public static IList<Menu> GetMenu4UserClassJoinUserMenuRel(IDbContext dbContext, string userClassId, string userId, string menuclassid, string siteid)
	{
		string apiName = "GetMenu4UserClassJoinUserMenuRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userClassId},{userId},{menuclassid},{siteid}");
		}
		IList<Menu> menu4UserClassMenuRel = GetMenu4UserClassMenuRel(dbContext, userClassId, menuclassid, siteid);
		IList<Menu> menu4UserMenuRel = GetMenu4UserMenuRel(dbContext, userId, menuclassid, siteid);
		if (menu4UserMenuRel != null || menu4UserMenuRel.Count > 0)
		{
			foreach (Menu item in menu4UserMenuRel)
			{
				if (menu4UserClassMenuRel.Where((Menu e) => e.Menuid == item.Menuid).Count() <= 0)
				{
					menu4UserClassMenuRel.Add(item);
				}
			}
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userClassId},{userId},{menuclassid},{siteid}");
		}
		return menu4UserClassMenuRel;
	}

	public static IList<Menu> GetMenu4UserClassJoinUserMenuRelJoinUserFavoriteMenu(IDbContext dbContext, string userClassId, string userId, string menuclassid, string siteid)
	{
		string apiName = "GetMenu4UserClassJoinUserMenuRelJoinUserFavoriteMenu";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userClassId},{userId},{menuclassid},{siteid}");
		}
		IList<Menu> menu4UserClassMenuRel = GetMenu4UserClassMenuRel(dbContext, userClassId, menuclassid, siteid);
		IList<Menu> menu4UserMenuRel = GetMenu4UserMenuRel(dbContext, userId, menuclassid, siteid);
		IList<Menu> menu4UserFavoriteMenu = GetMenu4UserFavoriteMenu(dbContext, userId, menuclassid, siteid);
		if (menu4UserMenuRel != null || menu4UserMenuRel.Count > 0)
		{
			foreach (Menu item in menu4UserMenuRel)
			{
				if (menu4UserClassMenuRel.Where((Menu e) => e.Menuid == item.Menuid).Count() <= 0)
				{
					menu4UserClassMenuRel.Add(item);
				}
			}
		}
		if (menu4UserFavoriteMenu != null || menu4UserFavoriteMenu.Count > 0)
		{
			foreach (Menu item2 in menu4UserFavoriteMenu)
			{
				menu4UserClassMenuRel.Add(item2);
			}
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userClassId},{userId},{menuclassid},{siteid}");
		}
		return menu4UserClassMenuRel;
	}

	public static IList<Menu> GetMenu4UserClassRelJoinMenuRel(IDbContext dbContext, string menuClassId, string userId, string siteId)
	{
		string apiName = "GetMenu4UserClassRelJoinMenuRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userId},{menuClassId},{siteId}");
		}
		IList<Userclassrel> list = USER.SelectUserClassRelList(dbContext, userId, siteId);
		IList<Menu> list2 = new List<Menu>();
		foreach (Userclassrel item3 in list)
		{
			foreach (Menu item in GetMenu4UserClassMenuRel(dbContext, item3.Userclassid, menuClassId, siteId))
			{
				if (list2.Where((Menu e) => e.Menuid == item.Menuid).Count() <= 0)
				{
					list2.Add(item);
				}
			}
		}
		IList<Menu> menu4UserMenuRel = GetMenu4UserMenuRel(dbContext, userId, menuClassId, siteId);
		if (menu4UserMenuRel != null || menu4UserMenuRel.Count > 0)
		{
			foreach (Menu item2 in menu4UserMenuRel)
			{
				if (list2.Where((Menu e) => e.Menuid == item2.Menuid).Count() <= 0)
				{
					list2.Add(item2);
				}
			}
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userId},{menuClassId},{siteId}");
		}
		return list2;
	}

	public static int UpsertMenu(IDbContext dbContext, RequestType requestType, Menu[] menuList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateMenuInternal(dbContext, menuList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateMenu(dbContext, menuList, optionSet, saveHist), 
			RequestType.DELETE => DeleteMenu(dbContext, menuList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteMenu(dbContext, menuList, optionSet, saveHist), 
			_ => RealDeleteMenu(dbContext, menuList, optionSet, saveHist), 
		};
	}

	private static int CreateMenuInternal(IDbContext dbContext, Menu[] menuList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("menuList", menuList);
		string text = "CreateMenu";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Menu> list = new List<Menu>();
		foreach (Menu obj in menuList)
		{
			Menu menu = new Menu();
			obj.CopyColumsTo(menu);
			menu.Activity = text;
			menu.CheckEntityUsable();
			obj.CopyCommonField(menu, systemTime, dbContext.Tid, isCreate: true);
			list.Add(menu);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateMenu(IDbContext dbContext, Menu[] menuList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("menuList", menuList);
		string text = "UpdateMenu";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Menu> list = new List<Menu>();
		foreach (Menu menu in menuList)
		{
			Menu menu4Update = GetMenu4Update(dbContext, menu.Menuid, menu.Menuclassid, menu.Siteid);
			if (menu4Update == null)
			{
				throw new EntityNotFoundException(typeof(Menu), $"{menu.Menuid},{menu.Menuclassid},{menu.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Menu), $"{menu.Menuid},{menu.Menuclassid},{menu.Siteid}", menu4Update.Isusable);
			string activity = menu4Update.Activity;
			string customactivity = menu4Update.Customactivity;
			string isusable = menu4Update.Isusable;
			DateTime? createtime = menu4Update.Createtime;
			string creator = menu4Update.Creator;
			menu.CopyColumsTo(menu4Update);
			menu4Update.Prevactivity = activity;
			menu4Update.Prevcustomactivity = customactivity;
			menu4Update.Creator = creator;
			menu4Update.Createtime = createtime;
			menu4Update.Isusable = isusable;
			menu4Update.Activity = text;
			menu.CopyCommonField(menu4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(menu4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteMenu(IDbContext dbContext, Menu[] menuList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("menuList", menuList);
		string text = "DeleteMenu";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Menu> list = new List<Menu>();
		foreach (Menu menu in menuList)
		{
			Menu menu4Update = GetMenu4Update(dbContext, menu.Menuid, menu.Menuclassid, menu.Siteid);
			if (menu4Update == null)
			{
				throw new EntityNotFoundException(typeof(Menu), $"{menu.Menuid},{menu.Menuclassid},{menu.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Menu), $"{menu.Menuid},{menu.Menuclassid},{menu.Siteid}", menu4Update.Isusable);
			menu4Update.Isusable = "UnUsable";
			menu.CopyCommonFieldUpdatePrev(menu4Update, systemTime, dbContext.Tid, text);
			menu.CopyExtensionCollection(menu4Update);
			list.Add(menu4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteMenu(IDbContext dbContext, Menu[] menuList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("menuList", menuList);
		string text = "UnDeleteMenu";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Menu> list = new List<Menu>();
		foreach (Menu menu in menuList)
		{
			Menu menu4Update = GetMenu4Update(dbContext, menu.Menuid, menu.Menuclassid, menu.Siteid);
			if (menu4Update == null)
			{
				throw new EntityNotFoundException(typeof(Menu), $"{menu.Menuid},{menu.Menuclassid},{menu.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Menu), $"{menu.Menuid},{menu.Menuclassid},{menu.Siteid}", menu4Update.Isusable);
			menu4Update.Isusable = "Usable";
			menu.CopyCommonFieldUpdatePrev(menu4Update, systemTime, dbContext.Tid, text);
			menu.CopyExtensionCollection(menu4Update);
			list.Add(menu4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteMenu(IDbContext dbContext, Menu[] menuList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("menuList", menuList);
		string text = "RealDeleteMenu";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Menu> list = new List<Menu>();
		foreach (Menu menu in menuList)
		{
			Menu menu4Update = GetMenu4Update(dbContext, menu.Menuid, menu.Menuclassid, menu.Siteid);
			if (menu4Update == null)
			{
				throw new EntityNotFoundException(typeof(Menu), $"{menu.Menuid},{menu.Menuclassid},{menu.Siteid}");
			}
			menu.CopyCommonFieldUpdatePrev(menu4Update, systemTime, dbContext.Tid, text);
			menu.CopyExtensionCollection(menu4Update);
			list.Add(menu4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
