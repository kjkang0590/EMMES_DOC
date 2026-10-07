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
public class USERCLASS
{
	private static string _sqlGetUserClassSqlDatabase = "SELECT * FROM CIM_USERCLASS WHERE USERCLASSID=@USERCLASSID AND SITEID=@SITEID";

	private static string _sqlGetUserClass4UpdateSqlDatabase = "SELECT * FROM CIM_USERCLASS WITH(UPDLOCK) WHERE USERCLASSID=@USERCLASSID AND SITEID=@SITEID";

	private static string _sqlSelectUserClassSqlDatabase = "SELECT * FROM CIM_USERCLASS WHERE USERCLASSID=@USERCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectUserClass4UpdateSqlDatabase = "SELECT * FROM CIM_USERCLASS WITH(UPDLOCK) WHERE USERCLASSID=@USERCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetUserClassOracleDatabase = "SELECT * FROM CIM_USERCLASS WHERE USERCLASSID=:USERCLASSID AND SITEID=:SITEID";

	private static string _sqlGetUserClass4UpdateOracleDatabase = "SELECT * FROM CIM_USERCLASS WHERE USERCLASSID=:USERCLASSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectUserClassOracleDatabase = "SELECT * FROM CIM_USERCLASS WHERE USERCLASSID=:USERCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectUserClass4UpdateOracleDatabase = "SELECT * FROM CIM_USERCLASS WHERE USERCLASSID=:USERCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Userclass);

	public static Userclass GetUserClass(IDbContext dbContext, string userclassid, string siteid)
	{
		string apiName = "GetUserClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetUserClassSqlDatabase : _sqlGetUserClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERCLASSID", userclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_USERCLASS", $"{userclassid},{siteid}"));
		}
		Userclass? result = ContextManager.DirectEntityQuery<Userclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userclassid},{siteid}");
		}
		return result;
	}

	public static Userclass GetUserClass4Update(IDbContext dbContext, string userclassid, string siteid)
	{
		string apiName = "GetUserClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetUserClass4UpdateSqlDatabase : _sqlGetUserClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERCLASSID", userclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_USERCLASS", $"{userclassid},{siteid}"));
		}
		Userclass? result = ContextManager.DirectEntityQuery<Userclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userclassid},{siteid}");
		}
		return result;
	}

	public static Userclass SelectUserClass(IDbContext dbContext, string userclassid, string siteid)
	{
		string apiName = "SelectUserClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectUserClassSqlDatabase : _sqlSelectUserClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERCLASSID", userclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_USERCLASS", $"{userclassid},{siteid}"));
		}
		Userclass? result = ContextManager.DirectEntityQuery<Userclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userclassid},{siteid}");
		}
		return result;
	}

	public static Userclass SelectUserClass4Update(IDbContext dbContext, string userclassid, string siteid)
	{
		string apiName = "SelectUserClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectUserClass4UpdateSqlDatabase : _sqlSelectUserClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERCLASSID", userclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_USERCLASS", $"{userclassid},{siteid}"));
		}
		Userclass? result = ContextManager.DirectEntityQuery<Userclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userclassid},{siteid}");
		}
		return result;
	}

	public static int UpsertUserClass(IDbContext dbContext, RequestType requestType, Userclass[] userClassList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateUserClassInternal(dbContext, userClassList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateUserClass(dbContext, userClassList, optionSet, saveHist), 
			RequestType.DELETE => DeleteUserClass(dbContext, userClassList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteUserClass(dbContext, userClassList, optionSet, saveHist), 
			_ => RealDeleteUserClass(dbContext, userClassList, optionSet, saveHist), 
		};
	}

	private static int CreateUserClassInternal(IDbContext dbContext, Userclass[] userClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userClassList", userClassList);
		string text = "CreateUserClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userclass> list = new List<Userclass>();
		foreach (Userclass obj in userClassList)
		{
			Userclass userclass = new Userclass();
			obj.CopyColumsTo(userclass);
			userclass.Activity = text;
			userclass.CheckEntityUsable();
			obj.CopyCommonField(userclass, systemTime, dbContext.Tid, isCreate: true);
			list.Add(userclass);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateUserClass(IDbContext dbContext, Userclass[] userClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userClassList", userClassList);
		string text = "UpdateUserClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userclass> list = new List<Userclass>();
		foreach (Userclass userclass in userClassList)
		{
			Userclass userClass4Update = GetUserClass4Update(dbContext, userclass.Userclassid, userclass.Siteid);
			if (userClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Userclass), $"{userclass.Userclassid},{userclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Userclass), $"{userclass.Userclassid},{userclass.Siteid}", userClass4Update.Isusable);
			string activity = userClass4Update.Activity;
			string customactivity = userClass4Update.Customactivity;
			string isusable = userClass4Update.Isusable;
			DateTime? createtime = userClass4Update.Createtime;
			string creator = userClass4Update.Creator;
			userclass.CopyColumsTo(userClass4Update);
			userClass4Update.Prevactivity = activity;
			userClass4Update.Prevcustomactivity = customactivity;
			userClass4Update.Creator = creator;
			userClass4Update.Createtime = createtime;
			userClass4Update.Isusable = isusable;
			userClass4Update.Activity = text;
			userclass.CopyCommonField(userClass4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(userClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteUserClass(IDbContext dbContext, Userclass[] userClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userClassList", userClassList);
		string text = "DeleteUserClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userclass> list = new List<Userclass>();
		foreach (Userclass userclass in userClassList)
		{
			Userclass userClass4Update = GetUserClass4Update(dbContext, userclass.Userclassid, userclass.Siteid);
			if (userClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Userclass), $"{userclass.Userclassid},{userclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Userclass), $"{userclass.Userclassid},{userclass.Siteid}", userClass4Update.Isusable);
			userClass4Update.Isusable = "UnUsable";
			userclass.CopyCommonFieldUpdatePrev(userClass4Update, systemTime, dbContext.Tid, text);
			userclass.CopyExtensionCollection(userClass4Update);
			list.Add(userClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteUserClass(IDbContext dbContext, Userclass[] userClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userClassList", userClassList);
		string text = "UnDeleteUserClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userclass> list = new List<Userclass>();
		foreach (Userclass userclass in userClassList)
		{
			Userclass userClass4Update = GetUserClass4Update(dbContext, userclass.Userclassid, userclass.Siteid);
			if (userClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Userclass), $"{userclass.Userclassid},{userclass.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Userclass), $"{userclass.Userclassid},{userclass.Siteid}", userClass4Update.Isusable);
			userClass4Update.Isusable = "Usable";
			userclass.CopyCommonFieldUpdatePrev(userClass4Update, systemTime, dbContext.Tid, text);
			userclass.CopyExtensionCollection(userClass4Update);
			list.Add(userClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteUserClass(IDbContext dbContext, Userclass[] userClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userClassList", userClassList);
		string text = "RealDeleteUserClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userclass> list = new List<Userclass>();
		foreach (Userclass userclass in userClassList)
		{
			Userclass userClass4Update = GetUserClass4Update(dbContext, userclass.Userclassid, userclass.Siteid);
			if (userClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Userclass), $"{userclass.Userclassid},{userclass.Siteid}");
			}
			userclass.CopyCommonFieldUpdatePrev(userClass4Update, systemTime, dbContext.Tid, text);
			userclass.CopyExtensionCollection(userClass4Update);
			list.Add(userClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
