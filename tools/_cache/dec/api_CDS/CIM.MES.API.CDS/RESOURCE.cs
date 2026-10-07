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
public class RESOURCE
{
	private static string _sqlGetResourceSqlDatabase = "SELECT * FROM CIM_RESOURCE WHERE RESOURCEID=@RESOURCEID AND SITEID=@SITEID";

	private static string _sqlGetResource4UpdateSqlDatabase = "SELECT * FROM CIM_RESOURCE WITH(UPDLOCK) WHERE RESOURCEID=@RESOURCEID AND SITEID=@SITEID";

	private static string _sqlSelectResourceSqlDatabase = "SELECT * FROM CIM_RESOURCE WHERE RESOURCEID=@RESOURCEID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectResource4UpdateSqlDatabase = "SELECT * FROM CIM_RESOURCE WITH(UPDLOCK) WHERE RESOURCEID=@RESOURCEID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetResourceOracleDatabase = "SELECT * FROM CIM_RESOURCE WHERE RESOURCEID=:RESOURCEID AND SITEID=:SITEID";

	private static string _sqlGetResource4UpdateOracleDatabase = "SELECT * FROM CIM_RESOURCE WHERE RESOURCEID=:RESOURCEID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectResourceOracleDatabase = "SELECT * FROM CIM_RESOURCE WHERE RESOURCEID=:RESOURCEID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectResource4UpdateOracleDatabase = "SELECT * FROM CIM_RESOURCE WHERE RESOURCEID=:RESOURCEID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Resource);

	public static Resource GetResource(IDbContext dbContext, string resourceid, string siteid)
	{
		string apiName = "GetResource";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{resourceid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetResourceSqlDatabase : _sqlGetResourceOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RESOURCEID", resourceid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_RESOURCE", $"{resourceid},{siteid}"));
		}
		Resource? result = ContextManager.DirectEntityQuery<Resource>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{resourceid},{siteid}");
		}
		return result;
	}

	public static Resource GetResource4Update(IDbContext dbContext, string resourceid, string siteid)
	{
		string apiName = "GetResource4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{resourceid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetResource4UpdateSqlDatabase : _sqlGetResource4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RESOURCEID", resourceid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_RESOURCE", $"{resourceid},{siteid}"));
		}
		Resource? result = ContextManager.DirectEntityQuery<Resource>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{resourceid},{siteid}");
		}
		return result;
	}

	public static Resource SelectResource(IDbContext dbContext, string resourceid, string siteid)
	{
		string apiName = "SelectResource";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{resourceid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectResourceSqlDatabase : _sqlSelectResourceOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RESOURCEID", resourceid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_RESOURCE", $"{resourceid},{siteid}"));
		}
		Resource? result = ContextManager.DirectEntityQuery<Resource>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{resourceid},{siteid}");
		}
		return result;
	}

	public static Resource SelectResource4Update(IDbContext dbContext, string resourceid, string siteid)
	{
		string apiName = "SelectResource4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{resourceid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectResource4UpdateSqlDatabase : _sqlSelectResource4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RESOURCEID", resourceid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_RESOURCE", $"{resourceid},{siteid}"));
		}
		Resource? result = ContextManager.DirectEntityQuery<Resource>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{resourceid},{siteid}");
		}
		return result;
	}

	public static int UpsertResource(IDbContext dbContext, RequestType requestType, Resource[] resourceList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateResourceInternal(dbContext, resourceList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateResource(dbContext, resourceList, optionSet, saveHist), 
			RequestType.DELETE => DeleteResource(dbContext, resourceList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteResource(dbContext, resourceList, optionSet, saveHist), 
			_ => RealDeleteResource(dbContext, resourceList, optionSet, saveHist), 
		};
	}

	private static int CreateResourceInternal(IDbContext dbContext, Resource[] resourceList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("resourceList", resourceList);
		string text = "CreateResource";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Resource> list = new List<Resource>();
		foreach (Resource obj in resourceList)
		{
			Resource resource = new Resource();
			obj.CopyColumsTo(resource);
			resource.Activity = text;
			resource.CheckEntityUsable();
			obj.CopyCommonField(resource, systemTime, dbContext.Tid, isCreate: true);
			list.Add(resource);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateResource(IDbContext dbContext, Resource[] resourceList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("resourceList", resourceList);
		string text = "UpdateResource";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Resource> list = new List<Resource>();
		foreach (Resource resource in resourceList)
		{
			Resource resource4Update = GetResource4Update(dbContext, resource.Resourceid, resource.Siteid);
			if (resource4Update == null)
			{
				throw new EntityNotFoundException(typeof(Resource), $"{resource.Resourceid},{resource.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Resource), $"{resource.Resourceid},{resource.Siteid}", resource4Update.Isusable);
			string activity = resource4Update.Activity;
			string customactivity = resource4Update.Customactivity;
			string isusable = resource4Update.Isusable;
			DateTime? createtime = resource4Update.Createtime;
			string creator = resource4Update.Creator;
			resource.CopyColumsTo(resource4Update);
			resource4Update.Prevactivity = activity;
			resource4Update.Prevcustomactivity = customactivity;
			resource4Update.Creator = creator;
			resource4Update.Createtime = createtime;
			resource4Update.Isusable = isusable;
			resource4Update.Activity = text;
			resource.CopyCommonField(resource4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(resource4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteResource(IDbContext dbContext, Resource[] resourceList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("resourceList", resourceList);
		string text = "DeleteResource";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Resource> list = new List<Resource>();
		foreach (Resource resource in resourceList)
		{
			Resource resource4Update = GetResource4Update(dbContext, resource.Resourceid, resource.Siteid);
			if (resource4Update == null)
			{
				throw new EntityNotFoundException(typeof(Resource), $"{resource.Resourceid},{resource.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Resource), $"{resource.Resourceid},{resource.Siteid}", resource4Update.Isusable);
			resource4Update.Isusable = "UnUsable";
			resource.CopyCommonFieldUpdatePrev(resource4Update, systemTime, dbContext.Tid, text);
			resource.CopyExtensionCollection(resource4Update);
			list.Add(resource4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteResource(IDbContext dbContext, Resource[] resourceList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("resourceList", resourceList);
		string text = "UnDeleteResource";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Resource> list = new List<Resource>();
		foreach (Resource resource in resourceList)
		{
			Resource resource4Update = GetResource4Update(dbContext, resource.Resourceid, resource.Siteid);
			if (resource4Update == null)
			{
				throw new EntityNotFoundException(typeof(Resource), $"{resource.Resourceid},{resource.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Resource), $"{resource.Resourceid},{resource.Siteid}", resource4Update.Isusable);
			resource4Update.Isusable = "Usable";
			resource.CopyCommonFieldUpdatePrev(resource4Update, systemTime, dbContext.Tid, text);
			resource.CopyExtensionCollection(resource4Update);
			list.Add(resource4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteResource(IDbContext dbContext, Resource[] resourceList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("resourceList", resourceList);
		string text = "RealDeleteResource";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Resource> list = new List<Resource>();
		foreach (Resource resource in resourceList)
		{
			Resource resource4Update = GetResource4Update(dbContext, resource.Resourceid, resource.Siteid);
			if (resource4Update == null)
			{
				throw new EntityNotFoundException(typeof(Resource), $"{resource.Resourceid},{resource.Siteid}");
			}
			resource.CopyCommonFieldUpdatePrev(resource4Update, systemTime, dbContext.Tid, text);
			resource.CopyExtensionCollection(resource4Update);
			list.Add(resource4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
