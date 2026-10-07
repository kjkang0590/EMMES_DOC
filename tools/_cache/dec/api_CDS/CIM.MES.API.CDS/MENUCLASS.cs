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
public class MENUCLASS
{
	private static string _sqlGetMenuClassSqlDatabase = "SELECT * FROM CIM_MENUCLASS WHERE MENUCLASSID=@MENUCLASSID AND SITEID=@SITEID";

	private static string _sqlGetMenuClass4UpdateSqlDatabase = "SELECT * FROM CIM_MENUCLASS WITH(UPDLOCK) WHERE MENUCLASSID=@MENUCLASSID AND SITEID=@SITEID";

	private static string _sqlSelectMenuClassSqlDatabase = "SELECT * FROM CIM_MENUCLASS WHERE MENUCLASSID=@MENUCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMenuClass4UpdateSqlDatabase = "SELECT * FROM CIM_MENUCLASS WITH(UPDLOCK) WHERE MENUCLASSID=@MENUCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetMenuClassOracleDatabase = "SELECT * FROM CIM_MENUCLASS WHERE MENUCLASSID=:MENUCLASSID AND SITEID=:SITEID";

	private static string _sqlGetMenuClass4UpdateOracleDatabase = "SELECT * FROM CIM_MENUCLASS WHERE MENUCLASSID=:MENUCLASSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectMenuClassOracleDatabase = "SELECT * FROM CIM_MENUCLASS WHERE MENUCLASSID=:MENUCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMenuClass4UpdateOracleDatabase = "SELECT * FROM CIM_MENUCLASS WHERE MENUCLASSID=:MENUCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Menuclass);

	public static Menuclass GetMenuClass(IDbContext dbContext, string menuclassid, string siteid)
	{
		string apiName = "GetMenuClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{menuclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetMenuClassSqlDatabase : _sqlGetMenuClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MENUCLASSID", menuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MENUCLASS", $"{menuclassid},{siteid}"));
		}
		Menuclass? result = ContextManager.DirectEntityQuery<Menuclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{menuclassid},{siteid}");
		}
		return result;
	}

	public static Menuclass GetMenuClass4Update(IDbContext dbContext, string menuclassid, string siteid)
	{
		string apiName = "GetMenuClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{menuclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetMenuClass4UpdateSqlDatabase : _sqlGetMenuClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MENUCLASSID", menuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_MENUCLASS", $"{menuclassid},{siteid}"));
		}
		Menuclass? result = ContextManager.DirectEntityQuery<Menuclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{menuclassid},{siteid}");
		}
		return result;
	}

	public static Menuclass SelectMenuClass(IDbContext dbContext, string menuclassid, string siteid)
	{
		string apiName = "SelectMenuClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{menuclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMenuClassSqlDatabase : _sqlSelectMenuClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MENUCLASSID", menuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MENUCLASS", $"{menuclassid},{siteid}"));
		}
		Menuclass? result = ContextManager.DirectEntityQuery<Menuclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{menuclassid},{siteid}");
		}
		return result;
	}

	public static Menuclass SelectMenuClass4Update(IDbContext dbContext, string menuclassid, string siteid)
	{
		string apiName = "SelectMenuClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{menuclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMenuClass4UpdateSqlDatabase : _sqlSelectMenuClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MENUCLASSID", menuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_MENUCLASS", $"{menuclassid},{siteid}"));
		}
		Menuclass? result = ContextManager.DirectEntityQuery<Menuclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{menuclassid},{siteid}");
		}
		return result;
	}

	public static int UpsertMenuClass(IDbContext dbContext, RequestType requestType, Menuclass[] menuClassList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateMenuClassInternal(dbContext, menuClassList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateMenuClass(dbContext, menuClassList, optionSet, saveHist), 
			RequestType.DELETE => DeleteMenuClass(dbContext, menuClassList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteMenuClass(dbContext, menuClassList, optionSet, saveHist), 
			_ => RealDeleteMenuClass(dbContext, menuClassList, optionSet, saveHist), 
		};
	}

	private static int CreateMenuClassInternal(IDbContext dbContext, Menuclass[] menuClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("menuClassList", menuClassList);
		string text = "CreateMenuClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Menuclass> list = new List<Menuclass>();
		foreach (Menuclass obj in menuClassList)
		{
			Menuclass menuclass = new Menuclass();
			obj.CopyColumsTo(menuclass);
			menuclass.Activity = text;
			menuclass.CheckEntityUsable();
			obj.CopyCommonField(menuclass, systemTime, dbContext.Tid, isCreate: true);
			list.Add(menuclass);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateMenuClass(IDbContext dbContext, Menuclass[] menuClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("menuClassList", menuClassList);
		string text = "UpdateMenuClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Menuclass> list = new List<Menuclass>();
		foreach (Menuclass menuclass in menuClassList)
		{
			Menuclass menuClass4Update = GetMenuClass4Update(dbContext, menuclass.Menuclassid, menuclass.Siteid);
			if (menuClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Menuclass), $"{menuclass.Menuclassid},{menuclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Menuclass), $"{menuclass.Menuclassid},{menuclass.Siteid}", menuClass4Update.Isusable);
			string activity = menuClass4Update.Activity;
			string customactivity = menuClass4Update.Customactivity;
			string isusable = menuClass4Update.Isusable;
			DateTime? createtime = menuClass4Update.Createtime;
			string creator = menuClass4Update.Creator;
			menuclass.CopyColumsTo(menuClass4Update);
			menuClass4Update.Prevactivity = activity;
			menuClass4Update.Prevcustomactivity = customactivity;
			menuClass4Update.Creator = creator;
			menuClass4Update.Createtime = createtime;
			menuClass4Update.Isusable = isusable;
			menuClass4Update.Activity = text;
			menuclass.CopyCommonField(menuClass4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(menuClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteMenuClass(IDbContext dbContext, Menuclass[] menuClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("menuClassList", menuClassList);
		string text = "DeleteMenuClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Menuclass> list = new List<Menuclass>();
		foreach (Menuclass menuclass in menuClassList)
		{
			Menuclass menuClass4Update = GetMenuClass4Update(dbContext, menuclass.Menuclassid, menuclass.Siteid);
			if (menuClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Menuclass), $"{menuclass.Menuclassid},{menuclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Menuclass), $"{menuclass.Menuclassid},{menuclass.Siteid}", menuClass4Update.Isusable);
			menuClass4Update.Isusable = "UnUsable";
			menuclass.CopyCommonFieldUpdatePrev(menuClass4Update, systemTime, dbContext.Tid, text);
			menuclass.CopyExtensionCollection(menuClass4Update);
			list.Add(menuClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteMenuClass(IDbContext dbContext, Menuclass[] menuClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("menuClassList", menuClassList);
		string text = "UnDeleteMenuClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Menuclass> list = new List<Menuclass>();
		foreach (Menuclass menuclass in menuClassList)
		{
			Menuclass menuClass4Update = GetMenuClass4Update(dbContext, menuclass.Menuclassid, menuclass.Siteid);
			if (menuClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Menuclass), $"{menuclass.Menuclassid},{menuclass.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Menuclass), $"{menuclass.Menuclassid},{menuclass.Siteid}", menuClass4Update.Isusable);
			menuClass4Update.Isusable = "Usable";
			menuclass.CopyCommonFieldUpdatePrev(menuClass4Update, systemTime, dbContext.Tid, text);
			menuclass.CopyExtensionCollection(menuClass4Update);
			list.Add(menuClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteMenuClass(IDbContext dbContext, Menuclass[] menuClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("menuClassList", menuClassList);
		string text = "RealDeleteMenuClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Menuclass> list = new List<Menuclass>();
		foreach (Menuclass menuclass in menuClassList)
		{
			Menuclass menuClass4Update = GetMenuClass4Update(dbContext, menuclass.Menuclassid, menuclass.Siteid);
			if (menuClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Menuclass), $"{menuclass.Menuclassid},{menuclass.Siteid}");
			}
			menuclass.CopyCommonFieldUpdatePrev(menuClass4Update, systemTime, dbContext.Tid, text);
			menuclass.CopyExtensionCollection(menuClass4Update);
			list.Add(menuClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
