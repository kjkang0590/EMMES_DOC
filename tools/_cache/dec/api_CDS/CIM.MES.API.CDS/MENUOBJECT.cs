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
public class MENUOBJECT
{
	private static string _sqlGetMenuObjectSqlDatabase = "SELECT * FROM CIM_MENUOBJECT WHERE OBJECTID=@OBJECTID AND MENUID=@MENUID AND MENUCLASSID=@MENUCLASSID AND SITEID=@SITEID";

	private static string _sqlGetMenuObject4UpdateSqlDatabase = "SELECT * FROM CIM_MENUOBJECT WITH(UPDLOCK) WHERE OBJECTID=@OBJECTID AND MENUID=@MENUID AND MENUCLASSID=@MENUCLASSID AND SITEID=@SITEID";

	private static string _sqlSelectMenuObjectSqlDatabase = "SELECT * FROM CIM_MENUOBJECT WHERE OBJECTID=@OBJECTID AND MENUID=@MENUID AND MENUCLASSID=@MENUCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMenuObject4UpdateSqlDatabase = "SELECT * FROM CIM_MENUOBJECT WITH(UPDLOCK) WHERE OBJECTID=@OBJECTID AND MENUID=@MENUID AND MENUCLASSID=@MENUCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetMenuObjectOracleDatabase = "SELECT * FROM CIM_MENUOBJECT WHERE OBJECTID=:OBJECTID AND MENUID=:MENUID AND MENUCLASSID=:MENUCLASSID AND SITEID=:SITEID";

	private static string _sqlGetMenuObject4UpdateOracleDatabase = "SELECT * FROM CIM_MENUOBJECT WHERE OBJECTID=:OBJECTID AND MENUID=:MENUID AND MENUCLASSID=:MENUCLASSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectMenuObjectOracleDatabase = "SELECT * FROM CIM_MENUOBJECT WHERE OBJECTID=:OBJECTID AND MENUID=:MENUID AND MENUCLASSID=:MENUCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMenuObject4UpdateOracleDatabase = "SELECT * FROM CIM_MENUOBJECT WHERE OBJECTID=:OBJECTID AND MENUID=:MENUID AND MENUCLASSID=:MENUCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Menuobject);

	private static string _sqlSelectMenuObjectListSqlDatabase = "SELECT * FROM CIM_MENUOBJECT WHERE MENUCLASSID=@MENUCLASSID AND MENUID=@MENUID AND SITEID=@SITEID AND ISUSABLE ='Usable'";

	private static string _sqlSelectMenuObjectListOracleDatabase = "SELECT * FROM CIM_MENUOBJECT WHERE MENUCLASSID=:MENUCLASSID AND MENUID=:MENUID AND SITEID=:SITEID AND ISUSABLE ='Usable'";

	public static Menuobject GetMenuObject(IDbContext dbContext, string objectid, string menuid, string menuclassid, string siteid)
	{
		string apiName = "GetMenuObject";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{objectid},{menuid},{menuclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetMenuObjectSqlDatabase : _sqlGetMenuObjectOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("OBJECTID", objectid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUCLASSID", menuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MENUOBJECT", $"{objectid},{menuid},{menuclassid},{siteid}"));
		}
		Menuobject result = ContextManager.DirectEntityQuery<Menuobject>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{objectid},{menuid},{menuclassid},{siteid}");
		}
		return result;
	}

	public static Menuobject GetMenuObject4Update(IDbContext dbContext, string objectid, string menuid, string menuclassid, string siteid)
	{
		string apiName = "GetMenuObject4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{objectid},{menuid},{menuclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetMenuObject4UpdateSqlDatabase : _sqlGetMenuObject4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("OBJECTID", objectid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUCLASSID", menuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_MENUOBJECT", $"{objectid},{menuid},{menuclassid},{siteid}"));
		}
		Menuobject result = ContextManager.DirectEntityQuery<Menuobject>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{objectid},{menuid},{menuclassid},{siteid}");
		}
		return result;
	}

	public static Menuobject SelectMenuObject(IDbContext dbContext, string objectid, string menuid, string menuclassid, string siteid)
	{
		string apiName = "SelectMenuObject";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{objectid},{menuid},{menuclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMenuObjectSqlDatabase : _sqlSelectMenuObjectOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("OBJECTID", objectid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUCLASSID", menuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MENUOBJECT", $"{objectid},{menuid},{menuclassid},{siteid}"));
		}
		Menuobject result = ContextManager.DirectEntityQuery<Menuobject>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{objectid},{menuid},{menuclassid},{siteid}");
		}
		return result;
	}

	public static Menuobject SelectMenuObject4Update(IDbContext dbContext, string objectid, string menuid, string menuclassid, string siteid)
	{
		string apiName = "SelectMenuObject4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{objectid},{menuid},{menuclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMenuObject4UpdateSqlDatabase : _sqlSelectMenuObject4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("OBJECTID", objectid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUCLASSID", menuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_MENUOBJECT", $"{objectid},{menuid},{menuclassid},{siteid}"));
		}
		Menuobject result = ContextManager.DirectEntityQuery<Menuobject>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{objectid},{menuid},{menuclassid},{siteid}");
		}
		return result;
	}

	public static Menuobject[] SelectMenuObjectList(IDbContext dbContext, string menuclassid, string menuid, string siteid)
	{
		string apiName = "SelectMenuObjectList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{menuclassid},{menuid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMenuObjectListSqlDatabase : _sqlSelectMenuObjectListOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUCLASSID", menuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MENUOBJECT", $"{menuclassid},{menuid},{siteid}"));
		}
		IList<Menuobject> source = ContextManager.DirectEntityQuery<Menuobject>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{menuclassid},{menuid},{siteid}");
		}
		return source.ToArray();
	}

	public static int UpsertMenuObject(IDbContext dbContext, RequestType requestType, Menuobject[] menuObjectList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateMenuObjectInternal(dbContext, menuObjectList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateMenuObject(dbContext, menuObjectList, optionSet, saveHist), 
			RequestType.DELETE => DeleteMenuObject(dbContext, menuObjectList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteMenuObject(dbContext, menuObjectList, optionSet, saveHist), 
			_ => RealDeleteMenuObject(dbContext, menuObjectList, optionSet, saveHist), 
		};
	}

	private static int CreateMenuObjectInternal(IDbContext dbContext, Menuobject[] menuObjectList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("menuObjectList", menuObjectList);
		string text = "CreateMenuObject";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Menuobject> list = new List<Menuobject>();
		foreach (Menuobject obj in menuObjectList)
		{
			Menuobject menuobject = new Menuobject();
			obj.CopyColumsTo(menuobject);
			menuobject.Activity = text;
			menuobject.CheckEntityUsable();
			obj.CopyCommonField(menuobject, systemTime, dbContext.Tid, isCreate: true);
			list.Add(menuobject);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateMenuObject(IDbContext dbContext, Menuobject[] menuObjectList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("menuObjectList", menuObjectList);
		string text = "UpdateMenuObject";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Menuobject> list = new List<Menuobject>();
		foreach (Menuobject menuobject in menuObjectList)
		{
			Menuobject menuObject4Update = GetMenuObject4Update(dbContext, menuobject.Objectid, menuobject.Menuid, menuobject.Menuclassid, menuobject.Siteid);
			if (menuObject4Update == null)
			{
				throw new EntityNotFoundException(typeof(Menuobject), $"{menuobject.Objectid},{menuobject.Menuid},{menuobject.Menuclassid},{menuobject.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Menuobject), $"{menuobject.Objectid},{menuobject.Menuid},{menuobject.Menuclassid},{menuobject.Siteid}", menuObject4Update.Isusable);
			string activity = menuObject4Update.Activity;
			string customactivity = menuObject4Update.Customactivity;
			string isusable = menuObject4Update.Isusable;
			DateTime? createtime = menuObject4Update.Createtime;
			string creator = menuObject4Update.Creator;
			menuobject.CopyColumsTo(menuObject4Update);
			menuObject4Update.Prevactivity = activity;
			menuObject4Update.Prevcustomactivity = customactivity;
			menuObject4Update.Creator = creator;
			menuObject4Update.Createtime = createtime;
			menuObject4Update.Isusable = isusable;
			menuObject4Update.Activity = text;
			menuobject.CopyCommonField(menuObject4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(menuObject4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteMenuObject(IDbContext dbContext, Menuobject[] menuObjectList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("menuObjectList", menuObjectList);
		string text = "DeleteMenuObject";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Menuobject> list = new List<Menuobject>();
		foreach (Menuobject menuobject in menuObjectList)
		{
			Menuobject menuObject4Update = GetMenuObject4Update(dbContext, menuobject.Objectid, menuobject.Menuid, menuobject.Menuclassid, menuobject.Siteid);
			if (menuObject4Update == null)
			{
				throw new EntityNotFoundException(typeof(Menuobject), $"{menuobject.Objectid},{menuobject.Menuid},{menuobject.Menuclassid},{menuobject.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Menuobject), $"{menuobject.Objectid},{menuobject.Menuid},{menuobject.Menuclassid},{menuobject.Siteid}", menuObject4Update.Isusable);
			menuObject4Update.Isusable = "UnUsable";
			menuobject.CopyCommonFieldUpdatePrev(menuObject4Update, systemTime, dbContext.Tid, text);
			menuobject.CopyExtensionCollection(menuObject4Update);
			list.Add(menuObject4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteMenuObject(IDbContext dbContext, Menuobject[] menuObjectList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("menuObjectList", menuObjectList);
		string text = "UnDeleteMenuObject";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Menuobject> list = new List<Menuobject>();
		foreach (Menuobject menuobject in menuObjectList)
		{
			Menuobject menuObject4Update = GetMenuObject4Update(dbContext, menuobject.Objectid, menuobject.Menuid, menuobject.Menuclassid, menuobject.Siteid);
			if (menuObject4Update == null)
			{
				throw new EntityNotFoundException(typeof(Menuobject), $"{menuobject.Objectid},{menuobject.Menuid},{menuobject.Menuclassid},{menuobject.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Menuobject), $"{menuobject.Objectid},{menuobject.Menuid},{menuobject.Menuclassid},{menuobject.Siteid}", menuObject4Update.Isusable);
			menuObject4Update.Isusable = "Usable";
			menuobject.CopyCommonFieldUpdatePrev(menuObject4Update, systemTime, dbContext.Tid, text);
			menuobject.CopyExtensionCollection(menuObject4Update);
			list.Add(menuObject4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteMenuObject(IDbContext dbContext, Menuobject[] menuObjectList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("menuObjectList", menuObjectList);
		string text = "RealDeleteMenuObject";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Menuobject> list = new List<Menuobject>();
		foreach (Menuobject menuobject in menuObjectList)
		{
			Menuobject menuObject4Update = GetMenuObject4Update(dbContext, menuobject.Objectid, menuobject.Menuid, menuobject.Menuclassid, menuobject.Siteid);
			if (menuObject4Update == null)
			{
				throw new EntityNotFoundException(typeof(Menuobject), $"{menuobject.Objectid},{menuobject.Menuid},{menuobject.Menuclassid},{menuobject.Siteid}");
			}
			menuobject.CopyCommonFieldUpdatePrev(menuObject4Update, systemTime, dbContext.Tid, text);
			menuobject.CopyExtensionCollection(menuObject4Update);
			list.Add(menuObject4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
