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
public class SITE
{
	private static string _sqlGetSiteSqlDatabase = "SELECT * FROM CIM_SITE WHERE SITEID=@SITEID";

	private static string _sqlGetSite4UpdateSqlDatabase = "SELECT * FROM CIM_SITE WITH(UPDLOCK) WHERE SITEID=@SITEID";

	private static string _sqlSelectSiteSqlDatabase = "SELECT * FROM CIM_SITE WHERE SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectSite4UpdateSqlDatabase = "SELECT * FROM CIM_SITE WITH(UPDLOCK) WHERE SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetSiteOracleDatabase = "SELECT * FROM CIM_SITE WHERE SITEID=:SITEID";

	private static string _sqlGetSite4UpdateOracleDatabase = "SELECT * FROM CIM_SITE WHERE SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectSiteOracleDatabase = "SELECT * FROM CIM_SITE WHERE SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectSite4UpdateOracleDatabase = "SELECT * FROM CIM_SITE WHERE SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static string _sqlSelectSiteAllSqlDatabase = "SELECT * FROM CIM_SITE WHERE ISUSABLE='Usable'";

	private static string _sqlSelectSiteAllOracleDatabase = "SELECT * FROM CIM_SITE WHERE ISUSABLE='Usable'";

	private static Type typeOfThis = typeof(Site);

	public static Site GetSite(IDbContext dbContext, string siteid)
	{
		string apiName = "GetSite";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetSiteSqlDatabase : _sqlGetSiteOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SITE", $"{siteid}"));
		}
		Site? result = ContextManager.DirectEntityQuery<Site>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{siteid}");
		}
		return result;
	}

	public static Site GetSite4Update(IDbContext dbContext, string siteid)
	{
		string apiName = "GetSite4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetSite4UpdateSqlDatabase : _sqlGetSite4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_SITE", $"{siteid}"));
		}
		Site? result = ContextManager.DirectEntityQuery<Site>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{siteid}");
		}
		return result;
	}

	public static Site SelectSite(IDbContext dbContext, string siteid)
	{
		string apiName = "SelectSite";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectSiteSqlDatabase : _sqlSelectSiteOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SITE", $"{siteid}"));
		}
		Site? result = ContextManager.DirectEntityQuery<Site>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{siteid}");
		}
		return result;
	}

	public static Site SelectSite4Update(IDbContext dbContext, string siteid)
	{
		string apiName = "SelectSite4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectSite4UpdateSqlDatabase : _sqlSelectSite4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_SITE", $"{siteid}"));
		}
		Site? result = ContextManager.DirectEntityQuery<Site>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{siteid}");
		}
		return result;
	}

	public static Site[] SelectSiteAll(IDbContext dbContext)
	{
		string apiName = "SelectSite";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), string.Empty);
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectSiteAllSqlDatabase : _sqlSelectSiteAllOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SITE", $"{string.Empty}"));
		}
		IList<Site> list2 = ContextManager.DirectEntityQuery<Site>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{string.Empty}");
		}
		return list2?.ToArray();
	}

	public static int UpsertSite(IDbContext dbContext, RequestType requestType, Site[] siteList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateSiteInternal(dbContext, siteList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateSite(dbContext, siteList, optionSet, saveHist), 
			RequestType.DELETE => DeleteSite(dbContext, siteList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteSite(dbContext, siteList, optionSet, saveHist), 
			_ => RealDeleteSite(dbContext, siteList, optionSet, saveHist), 
		};
	}

	private static int CreateSiteInternal(IDbContext dbContext, Site[] siteList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("siteList", siteList);
		string text = "CreateSite";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Site> list = new List<Site>();
		foreach (Site obj in siteList)
		{
			Site site = new Site();
			obj.CopyColumsTo(site);
			site.Activity = text;
			site.CheckEntityUsable();
			obj.CopyCommonField(site, systemTime, dbContext.Tid, isCreate: true);
			list.Add(site);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateSite(IDbContext dbContext, Site[] siteList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("siteList", siteList);
		string text = "UpdateSite";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Site> list = new List<Site>();
		foreach (Site site in siteList)
		{
			Site site4Update = GetSite4Update(dbContext, site.Siteid);
			if (site4Update == null)
			{
				throw new EntityNotFoundException(typeof(Site), $"{site.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Site), $"{site.Siteid}", site4Update.Isusable);
			string activity = site4Update.Activity;
			string customactivity = site4Update.Customactivity;
			string isusable = site4Update.Isusable;
			DateTime? createtime = site4Update.Createtime;
			string creator = site4Update.Creator;
			site.CopyColumsTo(site4Update);
			site4Update.Prevactivity = activity;
			site4Update.Prevcustomactivity = customactivity;
			site4Update.Creator = creator;
			site4Update.Createtime = createtime;
			site4Update.Isusable = isusable;
			site4Update.Activity = text;
			site.CopyCommonField(site4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(site4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteSite(IDbContext dbContext, Site[] siteList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("siteList", siteList);
		string text = "DeleteSite";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Site> list = new List<Site>();
		foreach (Site site in siteList)
		{
			Site site4Update = GetSite4Update(dbContext, site.Siteid);
			if (site4Update == null)
			{
				throw new EntityNotFoundException(typeof(Site), $"{site.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Site), $"{site.Siteid}", site4Update.Isusable);
			site4Update.Isusable = "UnUsable";
			site.CopyCommonFieldUpdatePrev(site4Update, systemTime, dbContext.Tid, text);
			site.CopyExtensionCollection(site4Update);
			list.Add(site4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteSite(IDbContext dbContext, Site[] siteList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("siteList", siteList);
		string text = "UnDeleteSite";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Site> list = new List<Site>();
		foreach (Site site in siteList)
		{
			Site site4Update = GetSite4Update(dbContext, site.Siteid);
			if (site4Update == null)
			{
				throw new EntityNotFoundException(typeof(Site), $"{site.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Site), $"{site.Siteid}", site4Update.Isusable);
			site4Update.Isusable = "Usable";
			site.CopyCommonFieldUpdatePrev(site4Update, systemTime, dbContext.Tid, text);
			site.CopyExtensionCollection(site4Update);
			list.Add(site4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteSite(IDbContext dbContext, Site[] siteList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("siteList", siteList);
		string text = "RealDeleteSite";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Site> list = new List<Site>();
		foreach (Site site in siteList)
		{
			Site site4Update = GetSite4Update(dbContext, site.Siteid);
			if (site4Update == null)
			{
				throw new EntityNotFoundException(typeof(Site), $"{site.Siteid}");
			}
			site.CopyCommonFieldUpdatePrev(site4Update, systemTime, dbContext.Tid, text);
			site.CopyExtensionCollection(site4Update);
			list.Add(site4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
