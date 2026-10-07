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
public class RESOURCEUSERREL
{
	private static string _sqlGetResourceUserRelSqlDatabase = "SELECT * FROM CIM_RESOURCEUSERREL WHERE RESOURCEID=@RESOURCEID AND USERID=@USERID AND SITEID=@SITEID";

	private static string _sqlGetResourceUserRel4UpdateSqlDatabase = "SELECT * FROM CIM_RESOURCEUSERREL WITH(UPDLOCK) WHERE RESOURCEID=@RESOURCEID AND USERID=@USERID AND SITEID=@SITEID";

	private static string _sqlSelectResourceUserRelSqlDatabase = "SELECT * FROM CIM_RESOURCEUSERREL WHERE RESOURCEID=@RESOURCEID AND USERID=@USERID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectResourceUserRel4UpdateSqlDatabase = "SELECT * FROM CIM_RESOURCEUSERREL WITH(UPDLOCK) WHERE RESOURCEID=@RESOURCEID AND USERID=@USERID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetResourceUserRelOracleDatabase = "SELECT * FROM CIM_RESOURCEUSERREL WHERE RESOURCEID=:RESOURCEID AND USERID=:USERID AND SITEID=:SITEID";

	private static string _sqlGetResourceUserRel4UpdateOracleDatabase = "SELECT * FROM CIM_RESOURCEUSERREL WHERE RESOURCEID=:RESOURCEID AND USERID=:USERID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectResourceUserRelOracleDatabase = "SELECT * FROM CIM_RESOURCEUSERREL WHERE RESOURCEID=:RESOURCEID AND USERID=:USERID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectResourceUserRel4UpdateOracleDatabase = "SELECT * FROM CIM_RESOURCEUSERREL WHERE RESOURCEID=:RESOURCEID AND USERID=:USERID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Resourceuserrel);

	public static Resourceuserrel GetResourceUserRel(IDbContext dbContext, string resourceid, string userid, string siteid)
	{
		string apiName = "GetResourceUserRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{resourceid},{userid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetResourceUserRelSqlDatabase : _sqlGetResourceUserRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RESOURCEID", resourceid, typeOfThis));
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_RESOURCEUSERREL", $"{resourceid},{userid},{siteid}"));
		}
		Resourceuserrel? result = ContextManager.DirectEntityQuery<Resourceuserrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{resourceid},{userid},{siteid}");
		}
		return result;
	}

	public static Resourceuserrel GetResourceUserRel4Update(IDbContext dbContext, string resourceid, string userid, string siteid)
	{
		string apiName = "GetResourceUserRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{resourceid},{userid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetResourceUserRel4UpdateSqlDatabase : _sqlGetResourceUserRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RESOURCEID", resourceid, typeOfThis));
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_RESOURCEUSERREL", $"{resourceid},{userid},{siteid}"));
		}
		Resourceuserrel? result = ContextManager.DirectEntityQuery<Resourceuserrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{resourceid},{userid},{siteid}");
		}
		return result;
	}

	public static Resourceuserrel SelectResourceUserRel(IDbContext dbContext, string resourceid, string userid, string siteid)
	{
		string apiName = "SelectResourceUserRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{resourceid},{userid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectResourceUserRelSqlDatabase : _sqlSelectResourceUserRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RESOURCEID", resourceid, typeOfThis));
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_RESOURCEUSERREL", $"{resourceid},{userid},{siteid}"));
		}
		Resourceuserrel? result = ContextManager.DirectEntityQuery<Resourceuserrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{resourceid},{userid},{siteid}");
		}
		return result;
	}

	public static Resourceuserrel SelectResourceUserRel4Update(IDbContext dbContext, string resourceid, string userid, string siteid)
	{
		string apiName = "SelectResourceUserRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{resourceid},{userid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectResourceUserRel4UpdateSqlDatabase : _sqlSelectResourceUserRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RESOURCEID", resourceid, typeOfThis));
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_RESOURCEUSERREL", $"{resourceid},{userid},{siteid}"));
		}
		Resourceuserrel? result = ContextManager.DirectEntityQuery<Resourceuserrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{resourceid},{userid},{siteid}");
		}
		return result;
	}

	public static int UpsertResourceUserRel(IDbContext dbContext, RequestType requestType, Resourceuserrel[] resourceUserRelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateResourceUserRelInternal(dbContext, resourceUserRelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateResourceUserRel(dbContext, resourceUserRelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteResourceUserRel(dbContext, resourceUserRelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteResourceUserRel(dbContext, resourceUserRelList, optionSet, saveHist), 
			_ => RealDeleteResourceUserRel(dbContext, resourceUserRelList, optionSet, saveHist), 
		};
	}

	private static int CreateResourceUserRelInternal(IDbContext dbContext, Resourceuserrel[] resourceUserRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("resourceUserRelList", resourceUserRelList);
		string text = "CreateResourceUserRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Resourceuserrel> list = new List<Resourceuserrel>();
		foreach (Resourceuserrel obj in resourceUserRelList)
		{
			Resourceuserrel resourceuserrel = new Resourceuserrel();
			obj.CopyColumsTo(resourceuserrel);
			resourceuserrel.Activity = text;
			resourceuserrel.CheckEntityUsable();
			obj.CopyCommonField(resourceuserrel, systemTime, dbContext.Tid, isCreate: true);
			list.Add(resourceuserrel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateResourceUserRel(IDbContext dbContext, Resourceuserrel[] resourceUserRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("resourceUserRelList", resourceUserRelList);
		string text = "UpdateResourceUserRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Resourceuserrel> list = new List<Resourceuserrel>();
		foreach (Resourceuserrel resourceuserrel in resourceUserRelList)
		{
			Resourceuserrel resourceUserRel4Update = GetResourceUserRel4Update(dbContext, resourceuserrel.Resourceid, resourceuserrel.Userid, resourceuserrel.Siteid);
			if (resourceUserRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Resourceuserrel), $"{resourceuserrel.Resourceid},{resourceuserrel.Userid},{resourceuserrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Resourceuserrel), $"{resourceuserrel.Resourceid},{resourceuserrel.Userid},{resourceuserrel.Siteid}", resourceUserRel4Update.Isusable);
			string activity = resourceUserRel4Update.Activity;
			string customactivity = resourceUserRel4Update.Customactivity;
			string isusable = resourceUserRel4Update.Isusable;
			DateTime? createtime = resourceUserRel4Update.Createtime;
			string creator = resourceUserRel4Update.Creator;
			resourceuserrel.CopyColumsTo(resourceUserRel4Update);
			resourceUserRel4Update.Prevactivity = activity;
			resourceUserRel4Update.Prevcustomactivity = customactivity;
			resourceUserRel4Update.Creator = creator;
			resourceUserRel4Update.Createtime = createtime;
			resourceUserRel4Update.Isusable = isusable;
			resourceUserRel4Update.Activity = text;
			resourceuserrel.CopyCommonField(resourceUserRel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(resourceUserRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteResourceUserRel(IDbContext dbContext, Resourceuserrel[] resourceUserRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("resourceUserRelList", resourceUserRelList);
		string text = "DeleteResourceUserRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Resourceuserrel> list = new List<Resourceuserrel>();
		foreach (Resourceuserrel resourceuserrel in resourceUserRelList)
		{
			Resourceuserrel resourceUserRel4Update = GetResourceUserRel4Update(dbContext, resourceuserrel.Resourceid, resourceuserrel.Userid, resourceuserrel.Siteid);
			if (resourceUserRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Resourceuserrel), $"{resourceuserrel.Resourceid},{resourceuserrel.Userid},{resourceuserrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Resourceuserrel), $"{resourceuserrel.Resourceid},{resourceuserrel.Userid},{resourceuserrel.Siteid}", resourceUserRel4Update.Isusable);
			resourceUserRel4Update.Isusable = "UnUsable";
			resourceuserrel.CopyCommonFieldUpdatePrev(resourceUserRel4Update, systemTime, dbContext.Tid, text);
			resourceuserrel.CopyExtensionCollection(resourceUserRel4Update);
			list.Add(resourceUserRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteResourceUserRel(IDbContext dbContext, Resourceuserrel[] resourceUserRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("resourceUserRelList", resourceUserRelList);
		string text = "UnDeleteResourceUserRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Resourceuserrel> list = new List<Resourceuserrel>();
		foreach (Resourceuserrel resourceuserrel in resourceUserRelList)
		{
			Resourceuserrel resourceUserRel4Update = GetResourceUserRel4Update(dbContext, resourceuserrel.Resourceid, resourceuserrel.Userid, resourceuserrel.Siteid);
			if (resourceUserRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Resourceuserrel), $"{resourceuserrel.Resourceid},{resourceuserrel.Userid},{resourceuserrel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Resourceuserrel), $"{resourceuserrel.Resourceid},{resourceuserrel.Userid},{resourceuserrel.Siteid}", resourceUserRel4Update.Isusable);
			resourceUserRel4Update.Isusable = "Usable";
			resourceuserrel.CopyCommonFieldUpdatePrev(resourceUserRel4Update, systemTime, dbContext.Tid, text);
			resourceuserrel.CopyExtensionCollection(resourceUserRel4Update);
			list.Add(resourceUserRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteResourceUserRel(IDbContext dbContext, Resourceuserrel[] resourceUserRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("resourceUserRelList", resourceUserRelList);
		string text = "RealDeleteResourceUserRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Resourceuserrel> list = new List<Resourceuserrel>();
		foreach (Resourceuserrel resourceuserrel in resourceUserRelList)
		{
			Resourceuserrel resourceUserRel4Update = GetResourceUserRel4Update(dbContext, resourceuserrel.Resourceid, resourceuserrel.Userid, resourceuserrel.Siteid);
			if (resourceUserRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Resourceuserrel), $"{resourceuserrel.Resourceid},{resourceuserrel.Userid},{resourceuserrel.Siteid}");
			}
			resourceuserrel.CopyCommonFieldUpdatePrev(resourceUserRel4Update, systemTime, dbContext.Tid, text);
			resourceuserrel.CopyExtensionCollection(resourceUserRel4Update);
			list.Add(resourceUserRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
