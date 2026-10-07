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
public class RESOURCEDURABLEREL
{
	private static string _sqlGetResourceDurableRelSqlDatabase = "SELECT * FROM CIM_RESOURCEDURABLEREL WHERE RESOURCEID=@RESOURCEID AND DURABLEID=@DURABLEID AND SITEID=@SITEID";

	private static string _sqlGetResourceDurableRel4UpdateSqlDatabase = "SELECT * FROM CIM_RESOURCEDURABLEREL WITH(UPDLOCK) WHERE RESOURCEID=@RESOURCEID AND DURABLEID=@DURABLEID AND SITEID=@SITEID";

	private static string _sqlSelectResourceDurableRelSqlDatabase = "SELECT * FROM CIM_RESOURCEDURABLEREL WHERE RESOURCEID=@RESOURCEID AND DURABLEID=@DURABLEID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectResourceDurableRel4UpdateSqlDatabase = "SELECT * FROM CIM_RESOURCEDURABLEREL WITH(UPDLOCK) WHERE RESOURCEID=@RESOURCEID AND DURABLEID=@DURABLEID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetResourceDurableRelOracleDatabase = "SELECT * FROM CIM_RESOURCEDURABLEREL WHERE RESOURCEID=:RESOURCEID AND DURABLEID=:DURABLEID AND SITEID=:SITEID";

	private static string _sqlGetResourceDurableRel4UpdateOracleDatabase = "SELECT * FROM CIM_RESOURCEDURABLEREL WHERE RESOURCEID=:RESOURCEID AND DURABLEID=:DURABLEID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectResourceDurableRelOracleDatabase = "SELECT * FROM CIM_RESOURCEDURABLEREL WHERE RESOURCEID=:RESOURCEID AND DURABLEID=:DURABLEID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectResourceDurableRel4UpdateOracleDatabase = "SELECT * FROM CIM_RESOURCEDURABLEREL WHERE RESOURCEID=:RESOURCEID AND DURABLEID=:DURABLEID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Resourcedurablerel);

	public static Resourcedurablerel GetResourceDurableRel(IDbContext dbContext, string resourceid, string durableid, string siteid)
	{
		string apiName = "GetResourceDurableRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{resourceid},{durableid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetResourceDurableRelSqlDatabase : _sqlGetResourceDurableRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RESOURCEID", resourceid, typeOfThis));
		list.Add(dbContext.CreateParameter("DURABLEID", durableid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_RESOURCEDURABLEREL", $"{resourceid},{durableid},{siteid}"));
		}
		Resourcedurablerel? result = ContextManager.DirectEntityQuery<Resourcedurablerel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{resourceid},{durableid},{siteid}");
		}
		return result;
	}

	public static Resourcedurablerel GetResourceDurableRel4Update(IDbContext dbContext, string resourceid, string durableid, string siteid)
	{
		string apiName = "GetResourceDurableRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{resourceid},{durableid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetResourceDurableRel4UpdateSqlDatabase : _sqlGetResourceDurableRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RESOURCEID", resourceid, typeOfThis));
		list.Add(dbContext.CreateParameter("DURABLEID", durableid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_RESOURCEDURABLEREL", $"{resourceid},{durableid},{siteid}"));
		}
		Resourcedurablerel? result = ContextManager.DirectEntityQuery<Resourcedurablerel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{resourceid},{durableid},{siteid}");
		}
		return result;
	}

	public static Resourcedurablerel SelectResourceDurableRel(IDbContext dbContext, string resourceid, string durableid, string siteid)
	{
		string apiName = "SelectResourceDurableRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{resourceid},{durableid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectResourceDurableRelSqlDatabase : _sqlSelectResourceDurableRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RESOURCEID", resourceid, typeOfThis));
		list.Add(dbContext.CreateParameter("DURABLEID", durableid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_RESOURCEDURABLEREL", $"{resourceid},{durableid},{siteid}"));
		}
		Resourcedurablerel? result = ContextManager.DirectEntityQuery<Resourcedurablerel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{resourceid},{durableid},{siteid}");
		}
		return result;
	}

	public static Resourcedurablerel SelectResourceDurableRel4Update(IDbContext dbContext, string resourceid, string durableid, string siteid)
	{
		string apiName = "SelectResourceDurableRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{resourceid},{durableid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectResourceDurableRel4UpdateSqlDatabase : _sqlSelectResourceDurableRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RESOURCEID", resourceid, typeOfThis));
		list.Add(dbContext.CreateParameter("DURABLEID", durableid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_RESOURCEDURABLEREL", $"{resourceid},{durableid},{siteid}"));
		}
		Resourcedurablerel? result = ContextManager.DirectEntityQuery<Resourcedurablerel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{resourceid},{durableid},{siteid}");
		}
		return result;
	}

	public static int UpsertResourceDurableRel(IDbContext dbContext, RequestType requestType, Resourcedurablerel[] resourceDurableRelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateResourceDurableRelInternal(dbContext, resourceDurableRelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateResourceDurableRel(dbContext, resourceDurableRelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteResourceDurableRel(dbContext, resourceDurableRelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteResourceDurableRel(dbContext, resourceDurableRelList, optionSet, saveHist), 
			_ => RealDeleteResourceDurableRel(dbContext, resourceDurableRelList, optionSet, saveHist), 
		};
	}

	private static int CreateResourceDurableRelInternal(IDbContext dbContext, Resourcedurablerel[] resourceDurableRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("resourceDurableRelList", resourceDurableRelList);
		string text = "CreateResourceDurableRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Resourcedurablerel> list = new List<Resourcedurablerel>();
		foreach (Resourcedurablerel obj in resourceDurableRelList)
		{
			Resourcedurablerel resourcedurablerel = new Resourcedurablerel();
			obj.CopyColumsTo(resourcedurablerel);
			resourcedurablerel.Activity = text;
			resourcedurablerel.CheckEntityUsable();
			obj.CopyCommonField(resourcedurablerel, systemTime, dbContext.Tid, isCreate: true);
			list.Add(resourcedurablerel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateResourceDurableRel(IDbContext dbContext, Resourcedurablerel[] resourceDurableRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("resourceDurableRelList", resourceDurableRelList);
		string text = "UpdateResourceDurableRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Resourcedurablerel> list = new List<Resourcedurablerel>();
		foreach (Resourcedurablerel resourcedurablerel in resourceDurableRelList)
		{
			Resourcedurablerel resourceDurableRel4Update = GetResourceDurableRel4Update(dbContext, resourcedurablerel.Resourceid, resourcedurablerel.Durableid, resourcedurablerel.Siteid);
			if (resourceDurableRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Resourcedurablerel), $"{resourcedurablerel.Resourceid},{resourcedurablerel.Durableid},{resourcedurablerel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Resourcedurablerel), $"{resourcedurablerel.Resourceid},{resourcedurablerel.Durableid},{resourcedurablerel.Siteid}", resourceDurableRel4Update.Isusable);
			string activity = resourceDurableRel4Update.Activity;
			string customactivity = resourceDurableRel4Update.Customactivity;
			string isusable = resourceDurableRel4Update.Isusable;
			DateTime? createtime = resourceDurableRel4Update.Createtime;
			string creator = resourceDurableRel4Update.Creator;
			resourcedurablerel.CopyColumsTo(resourceDurableRel4Update);
			resourceDurableRel4Update.Prevactivity = activity;
			resourceDurableRel4Update.Prevcustomactivity = customactivity;
			resourceDurableRel4Update.Creator = creator;
			resourceDurableRel4Update.Createtime = createtime;
			resourceDurableRel4Update.Isusable = isusable;
			resourceDurableRel4Update.Activity = text;
			resourcedurablerel.CopyCommonField(resourceDurableRel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(resourceDurableRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteResourceDurableRel(IDbContext dbContext, Resourcedurablerel[] resourceDurableRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("resourceDurableRelList", resourceDurableRelList);
		string text = "DeleteResourceDurableRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Resourcedurablerel> list = new List<Resourcedurablerel>();
		foreach (Resourcedurablerel resourcedurablerel in resourceDurableRelList)
		{
			Resourcedurablerel resourceDurableRel4Update = GetResourceDurableRel4Update(dbContext, resourcedurablerel.Resourceid, resourcedurablerel.Durableid, resourcedurablerel.Siteid);
			if (resourceDurableRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Resourcedurablerel), $"{resourcedurablerel.Resourceid},{resourcedurablerel.Durableid},{resourcedurablerel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Resourcedurablerel), $"{resourcedurablerel.Resourceid},{resourcedurablerel.Durableid},{resourcedurablerel.Siteid}", resourceDurableRel4Update.Isusable);
			resourceDurableRel4Update.Isusable = "UnUsable";
			resourcedurablerel.CopyCommonFieldUpdatePrev(resourceDurableRel4Update, systemTime, dbContext.Tid, text);
			resourcedurablerel.CopyExtensionCollection(resourceDurableRel4Update);
			list.Add(resourceDurableRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteResourceDurableRel(IDbContext dbContext, Resourcedurablerel[] resourceDurableRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("resourceDurableRelList", resourceDurableRelList);
		string text = "UnDeleteResourceDurableRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Resourcedurablerel> list = new List<Resourcedurablerel>();
		foreach (Resourcedurablerel resourcedurablerel in resourceDurableRelList)
		{
			Resourcedurablerel resourceDurableRel4Update = GetResourceDurableRel4Update(dbContext, resourcedurablerel.Resourceid, resourcedurablerel.Durableid, resourcedurablerel.Siteid);
			if (resourceDurableRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Resourcedurablerel), $"{resourcedurablerel.Resourceid},{resourcedurablerel.Durableid},{resourcedurablerel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Resourcedurablerel), $"{resourcedurablerel.Resourceid},{resourcedurablerel.Durableid},{resourcedurablerel.Siteid}", resourceDurableRel4Update.Isusable);
			resourceDurableRel4Update.Isusable = "Usable";
			resourcedurablerel.CopyCommonFieldUpdatePrev(resourceDurableRel4Update, systemTime, dbContext.Tid, text);
			resourcedurablerel.CopyExtensionCollection(resourceDurableRel4Update);
			list.Add(resourceDurableRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteResourceDurableRel(IDbContext dbContext, Resourcedurablerel[] resourceDurableRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("resourceDurableRelList", resourceDurableRelList);
		string text = "RealDeleteResourceDurableRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Resourcedurablerel> list = new List<Resourcedurablerel>();
		foreach (Resourcedurablerel resourcedurablerel in resourceDurableRelList)
		{
			Resourcedurablerel resourceDurableRel4Update = GetResourceDurableRel4Update(dbContext, resourcedurablerel.Resourceid, resourcedurablerel.Durableid, resourcedurablerel.Siteid);
			if (resourceDurableRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Resourcedurablerel), $"{resourcedurablerel.Resourceid},{resourcedurablerel.Durableid},{resourcedurablerel.Siteid}");
			}
			resourcedurablerel.CopyCommonFieldUpdatePrev(resourceDurableRel4Update, systemTime, dbContext.Tid, text);
			resourcedurablerel.CopyExtensionCollection(resourceDurableRel4Update);
			list.Add(resourceDurableRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
