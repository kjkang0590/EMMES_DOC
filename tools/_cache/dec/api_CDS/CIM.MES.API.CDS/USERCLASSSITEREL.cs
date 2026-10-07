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
public class USERCLASSSITEREL
{
	private static string _sqlGetUserClassSiteRelSqlDatabase = "SELECT * FROM CIM_USERCLASSSITEREL WHERE USERCLASSID=@USERCLASSID AND SITEID=@SITEID";

	private static string _sqlGetUserClassSiteRel4UpdateSqlDatabase = "SELECT * FROM CIM_USERCLASSSITEREL WITH(UPDLOCK) WHERE USERCLASSID=@USERCLASSID AND SITEID=@SITEID";

	private static string _sqlSelectUserClassSiteRelSqlDatabase = "SELECT * FROM CIM_USERCLASSSITEREL WHERE USERCLASSID=@USERCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectUserClassSiteRel4UpdateSqlDatabase = "SELECT * FROM CIM_USERCLASSSITEREL WITH(UPDLOCK) WHERE USERCLASSID=@USERCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetUserClassSiteRelOracleDatabase = "SELECT * FROM CIM_USERCLASSSITEREL WHERE USERCLASSID=:USERCLASSID AND SITEID=:SITEID";

	private static string _sqlGetUserClassSiteRel4UpdateOracleDatabase = "SELECT * FROM CIM_USERCLASSSITEREL WHERE USERCLASSID=:USERCLASSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectUserClassSiteRelOracleDatabase = "SELECT * FROM CIM_USERCLASSSITEREL WHERE USERCLASSID=:USERCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectUserClassSiteRel4UpdateOracleDatabase = "SELECT * FROM CIM_USERCLASSSITEREL WHERE USERCLASSID=:USERCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Userclasssiterel);

	public static Userclasssiterel GetUserClassSiteRel(IDbContext dbContext, string userclassid, string siteid)
	{
		string apiName = "GetUserClassSiteRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetUserClassSiteRelSqlDatabase : _sqlGetUserClassSiteRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERCLASSID", userclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_USERCLASSSITEREL", $"{userclassid},{siteid}"));
		}
		Userclasssiterel? result = ContextManager.DirectEntityQuery<Userclasssiterel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userclassid},{siteid}");
		}
		return result;
	}

	public static Userclasssiterel GetUserClassSiteRel4Update(IDbContext dbContext, string userclassid, string siteid)
	{
		string apiName = "GetUserClassSiteRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetUserClassSiteRel4UpdateSqlDatabase : _sqlGetUserClassSiteRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERCLASSID", userclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_USERCLASSSITEREL", $"{userclassid},{siteid}"));
		}
		Userclasssiterel? result = ContextManager.DirectEntityQuery<Userclasssiterel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userclassid},{siteid}");
		}
		return result;
	}

	public static Userclasssiterel SelectUserClassSiteRel(IDbContext dbContext, string userclassid, string siteid)
	{
		string apiName = "SelectUserClassSiteRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectUserClassSiteRelSqlDatabase : _sqlSelectUserClassSiteRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERCLASSID", userclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_USERCLASSSITEREL", $"{userclassid},{siteid}"));
		}
		Userclasssiterel? result = ContextManager.DirectEntityQuery<Userclasssiterel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userclassid},{siteid}");
		}
		return result;
	}

	public static Userclasssiterel SelectUserClassSiteRel4Update(IDbContext dbContext, string userclassid, string siteid)
	{
		string apiName = "SelectUserClassSiteRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectUserClassSiteRel4UpdateSqlDatabase : _sqlSelectUserClassSiteRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERCLASSID", userclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_USERCLASSSITEREL", $"{userclassid},{siteid}"));
		}
		Userclasssiterel? result = ContextManager.DirectEntityQuery<Userclasssiterel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userclassid},{siteid}");
		}
		return result;
	}

	public static int UpsertUserClassSiteRel(IDbContext dbContext, RequestType requestType, Userclasssiterel[] userClassSiteRelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateUserClassSiteRelInternal(dbContext, userClassSiteRelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateUserClassSiteRel(dbContext, userClassSiteRelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteUserClassSiteRel(dbContext, userClassSiteRelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteUserClassSiteRel(dbContext, userClassSiteRelList, optionSet, saveHist), 
			_ => RealDeleteUserClassSiteRel(dbContext, userClassSiteRelList, optionSet, saveHist), 
		};
	}

	private static int CreateUserClassSiteRelInternal(IDbContext dbContext, Userclasssiterel[] userClassSiteRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userClassSiteRelList", userClassSiteRelList);
		string text = "CreateUserClassSiteRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userclasssiterel> list = new List<Userclasssiterel>();
		foreach (Userclasssiterel obj in userClassSiteRelList)
		{
			Userclasssiterel userclasssiterel = new Userclasssiterel();
			obj.CopyColumsTo(userclasssiterel);
			userclasssiterel.Activity = text;
			userclasssiterel.CheckEntityUsable();
			obj.CopyCommonField(userclasssiterel, systemTime, dbContext.Tid, isCreate: true);
			list.Add(userclasssiterel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateUserClassSiteRel(IDbContext dbContext, Userclasssiterel[] userClassSiteRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userClassSiteRelList", userClassSiteRelList);
		string text = "UpdateUserClassSiteRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userclasssiterel> list = new List<Userclasssiterel>();
		foreach (Userclasssiterel userclasssiterel in userClassSiteRelList)
		{
			Userclasssiterel userClassSiteRel4Update = GetUserClassSiteRel4Update(dbContext, userclasssiterel.Userclassid, userclasssiterel.Siteid);
			if (userClassSiteRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Userclasssiterel), $"{userclasssiterel.Userclassid},{userclasssiterel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Userclasssiterel), $"{userclasssiterel.Userclassid},{userclasssiterel.Siteid}", userClassSiteRel4Update.Isusable);
			string activity = userClassSiteRel4Update.Activity;
			string customactivity = userClassSiteRel4Update.Customactivity;
			string isusable = userClassSiteRel4Update.Isusable;
			DateTime? createtime = userClassSiteRel4Update.Createtime;
			string creator = userClassSiteRel4Update.Creator;
			userclasssiterel.CopyColumsTo(userClassSiteRel4Update);
			userClassSiteRel4Update.Prevactivity = activity;
			userClassSiteRel4Update.Prevcustomactivity = customactivity;
			userClassSiteRel4Update.Creator = creator;
			userClassSiteRel4Update.Createtime = createtime;
			userClassSiteRel4Update.Isusable = isusable;
			userClassSiteRel4Update.Activity = text;
			userclasssiterel.CopyCommonField(userClassSiteRel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(userClassSiteRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteUserClassSiteRel(IDbContext dbContext, Userclasssiterel[] userClassSiteRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userClassSiteRelList", userClassSiteRelList);
		string text = "DeleteUserClassSiteRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userclasssiterel> list = new List<Userclasssiterel>();
		foreach (Userclasssiterel userclasssiterel in userClassSiteRelList)
		{
			Userclasssiterel userClassSiteRel4Update = GetUserClassSiteRel4Update(dbContext, userclasssiterel.Userclassid, userclasssiterel.Siteid);
			if (userClassSiteRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Userclasssiterel), $"{userclasssiterel.Userclassid},{userclasssiterel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Userclasssiterel), $"{userclasssiterel.Userclassid},{userclasssiterel.Siteid}", userClassSiteRel4Update.Isusable);
			userClassSiteRel4Update.Isusable = "UnUsable";
			userclasssiterel.CopyCommonFieldUpdatePrev(userClassSiteRel4Update, systemTime, dbContext.Tid, text);
			userclasssiterel.CopyExtensionCollection(userClassSiteRel4Update);
			list.Add(userClassSiteRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteUserClassSiteRel(IDbContext dbContext, Userclasssiterel[] userClassSiteRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userClassSiteRelList", userClassSiteRelList);
		string text = "UnDeleteUserClassSiteRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userclasssiterel> list = new List<Userclasssiterel>();
		foreach (Userclasssiterel userclasssiterel in userClassSiteRelList)
		{
			Userclasssiterel userClassSiteRel4Update = GetUserClassSiteRel4Update(dbContext, userclasssiterel.Userclassid, userclasssiterel.Siteid);
			if (userClassSiteRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Userclasssiterel), $"{userclasssiterel.Userclassid},{userclasssiterel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Userclasssiterel), $"{userclasssiterel.Userclassid},{userclasssiterel.Siteid}", userClassSiteRel4Update.Isusable);
			userClassSiteRel4Update.Isusable = "Usable";
			userclasssiterel.CopyCommonFieldUpdatePrev(userClassSiteRel4Update, systemTime, dbContext.Tid, text);
			userclasssiterel.CopyExtensionCollection(userClassSiteRel4Update);
			list.Add(userClassSiteRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteUserClassSiteRel(IDbContext dbContext, Userclasssiterel[] userClassSiteRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userClassSiteRelList", userClassSiteRelList);
		string text = "RealDeleteUserClassSiteRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userclasssiterel> list = new List<Userclasssiterel>();
		foreach (Userclasssiterel userclasssiterel in userClassSiteRelList)
		{
			Userclasssiterel userClassSiteRel4Update = GetUserClassSiteRel4Update(dbContext, userclasssiterel.Userclassid, userclasssiterel.Siteid);
			if (userClassSiteRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Userclasssiterel), $"{userclasssiterel.Userclassid},{userclasssiterel.Siteid}");
			}
			userclasssiterel.CopyCommonFieldUpdatePrev(userClassSiteRel4Update, systemTime, dbContext.Tid, text);
			userclasssiterel.CopyExtensionCollection(userClassSiteRel4Update);
			list.Add(userClassSiteRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
