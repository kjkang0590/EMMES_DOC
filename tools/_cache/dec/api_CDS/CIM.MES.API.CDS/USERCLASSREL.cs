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
public class USERCLASSREL
{
	private static string _sqlGetUserClassRelSqlDatabase = "SELECT * FROM CIM_USERCLASSREL WHERE USERCLASSID=@USERCLASSID AND USERID=@USERID AND SITEID=@SITEID";

	private static string _sqlGetUserClassRel4UpdateSqlDatabase = "SELECT * FROM CIM_USERCLASSREL WITH(UPDLOCK) WHERE USERCLASSID=@USERCLASSID AND USERID=@USERID AND SITEID=@SITEID";

	private static string _sqlSelectUserClassRelSqlDatabase = "SELECT * FROM CIM_USERCLASSREL WHERE USERCLASSID=@USERCLASSID AND USERID=@USERID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectUserClassRel4UpdateSqlDatabase = "SELECT * FROM CIM_USERCLASSREL WITH(UPDLOCK) WHERE USERCLASSID=@USERCLASSID AND USERID=@USERID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetUserClassRelOracleDatabase = "SELECT * FROM CIM_USERCLASSREL WHERE USERCLASSID=:USERCLASSID AND USERID=:USERID AND SITEID=:SITEID";

	private static string _sqlGetUserClassRel4UpdateOracleDatabase = "SELECT * FROM CIM_USERCLASSREL WHERE USERCLASSID=:USERCLASSID AND USERID=:USERID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectUserClassRelOracleDatabase = "SELECT * FROM CIM_USERCLASSREL WHERE USERCLASSID=:USERCLASSID AND USERID=:USERID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectUserClassRel4UpdateOracleDatabase = "SELECT * FROM CIM_USERCLASSREL WHERE USERCLASSID=:USERCLASSID AND USERID=:USERID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Userclassrel);

	public static Userclassrel GetUserClassRel(IDbContext dbContext, string userclassid, string userid, string siteid)
	{
		string apiName = "GetUserClassRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userclassid},{userid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetUserClassRelSqlDatabase : _sqlGetUserClassRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERCLASSID", userclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_USERCLASSREL", $"{userclassid},{userid},{siteid}"));
		}
		Userclassrel? result = ContextManager.DirectEntityQuery<Userclassrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userclassid},{userid},{siteid}");
		}
		return result;
	}

	public static Userclassrel GetUserClassRel4Update(IDbContext dbContext, string userclassid, string userid, string siteid)
	{
		string apiName = "GetUserClassRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userclassid},{userid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetUserClassRel4UpdateSqlDatabase : _sqlGetUserClassRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERCLASSID", userclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_USERCLASSREL", $"{userclassid},{userid},{siteid}"));
		}
		Userclassrel? result = ContextManager.DirectEntityQuery<Userclassrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userclassid},{userid},{siteid}");
		}
		return result;
	}

	public static Userclassrel SelectUserClassRel(IDbContext dbContext, string userclassid, string userid, string siteid)
	{
		string apiName = "SelectUserClassRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userclassid},{userid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectUserClassRelSqlDatabase : _sqlSelectUserClassRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERCLASSID", userclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_USERCLASSREL", $"{userclassid},{userid},{siteid}"));
		}
		Userclassrel? result = ContextManager.DirectEntityQuery<Userclassrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userclassid},{userid},{siteid}");
		}
		return result;
	}

	public static Userclassrel SelectUserClassRel4Update(IDbContext dbContext, string userclassid, string userid, string siteid)
	{
		string apiName = "SelectUserClassRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userclassid},{userid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectUserClassRel4UpdateSqlDatabase : _sqlSelectUserClassRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERCLASSID", userclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_USERCLASSREL", $"{userclassid},{userid},{siteid}"));
		}
		Userclassrel? result = ContextManager.DirectEntityQuery<Userclassrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userclassid},{userid},{siteid}");
		}
		return result;
	}

	public static int UpsertUserClassRel(IDbContext dbContext, RequestType requestType, Userclassrel[] userClassRelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateUserClassRelInternal(dbContext, userClassRelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateUserClassRel(dbContext, userClassRelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteUserClassRel(dbContext, userClassRelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteUserClassRel(dbContext, userClassRelList, optionSet, saveHist), 
			_ => RealDeleteUserClassRel(dbContext, userClassRelList, optionSet, saveHist), 
		};
	}

	private static int CreateUserClassRelInternal(IDbContext dbContext, Userclassrel[] userClassRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userClassRelList", userClassRelList);
		string text = "CreateUserClassRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userclassrel> list = new List<Userclassrel>();
		foreach (Userclassrel obj in userClassRelList)
		{
			Userclassrel userclassrel = new Userclassrel();
			obj.CopyColumsTo(userclassrel);
			userclassrel.Activity = text;
			userclassrel.CheckEntityUsable();
			obj.CopyCommonField(userclassrel, systemTime, dbContext.Tid, isCreate: true);
			list.Add(userclassrel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateUserClassRel(IDbContext dbContext, Userclassrel[] userClassRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userClassRelList", userClassRelList);
		string text = "UpdateUserClassRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userclassrel> list = new List<Userclassrel>();
		foreach (Userclassrel userclassrel in userClassRelList)
		{
			Userclassrel userClassRel4Update = GetUserClassRel4Update(dbContext, userclassrel.Userclassid, userclassrel.Userid, userclassrel.Siteid);
			if (userClassRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Userclassrel), $"{userclassrel.Userclassid},{userclassrel.Userid},{userclassrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Userclassrel), $"{userclassrel.Userclassid},{userclassrel.Userid},{userclassrel.Siteid}", userClassRel4Update.Isusable);
			string activity = userClassRel4Update.Activity;
			string customactivity = userClassRel4Update.Customactivity;
			string isusable = userClassRel4Update.Isusable;
			DateTime? createtime = userClassRel4Update.Createtime;
			string creator = userClassRel4Update.Creator;
			userclassrel.CopyColumsTo(userClassRel4Update);
			userClassRel4Update.Prevactivity = activity;
			userClassRel4Update.Prevcustomactivity = customactivity;
			userClassRel4Update.Creator = creator;
			userClassRel4Update.Createtime = createtime;
			userClassRel4Update.Isusable = isusable;
			userClassRel4Update.Activity = text;
			userclassrel.CopyCommonField(userClassRel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(userClassRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteUserClassRel(IDbContext dbContext, Userclassrel[] userClassRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userClassRelList", userClassRelList);
		string text = "DeleteUserClassRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userclassrel> list = new List<Userclassrel>();
		foreach (Userclassrel userclassrel in userClassRelList)
		{
			Userclassrel userClassRel4Update = GetUserClassRel4Update(dbContext, userclassrel.Userclassid, userclassrel.Userid, userclassrel.Siteid);
			if (userClassRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Userclassrel), $"{userclassrel.Userclassid},{userclassrel.Userid},{userclassrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Userclassrel), $"{userclassrel.Userclassid},{userclassrel.Userid},{userclassrel.Siteid}", userClassRel4Update.Isusable);
			userClassRel4Update.Isusable = "UnUsable";
			userclassrel.CopyCommonFieldUpdatePrev(userClassRel4Update, systemTime, dbContext.Tid, text);
			userclassrel.CopyExtensionCollection(userClassRel4Update);
			list.Add(userClassRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteUserClassRel(IDbContext dbContext, Userclassrel[] userClassRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userClassRelList", userClassRelList);
		string text = "UnDeleteUserClassRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userclassrel> list = new List<Userclassrel>();
		foreach (Userclassrel userclassrel in userClassRelList)
		{
			Userclassrel userClassRel4Update = GetUserClassRel4Update(dbContext, userclassrel.Userclassid, userclassrel.Userid, userclassrel.Siteid);
			if (userClassRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Userclassrel), $"{userclassrel.Userclassid},{userclassrel.Userid},{userclassrel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Userclassrel), $"{userclassrel.Userclassid},{userclassrel.Userid},{userclassrel.Siteid}", userClassRel4Update.Isusable);
			userClassRel4Update.Isusable = "Usable";
			userclassrel.CopyCommonFieldUpdatePrev(userClassRel4Update, systemTime, dbContext.Tid, text);
			userclassrel.CopyExtensionCollection(userClassRel4Update);
			list.Add(userClassRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteUserClassRel(IDbContext dbContext, Userclassrel[] userClassRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userClassRelList", userClassRelList);
		string text = "RealDeleteUserClassRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userclassrel> list = new List<Userclassrel>();
		foreach (Userclassrel userclassrel in userClassRelList)
		{
			Userclassrel userClassRel4Update = GetUserClassRel4Update(dbContext, userclassrel.Userclassid, userclassrel.Userid, userclassrel.Siteid);
			if (userClassRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Userclassrel), $"{userclassrel.Userclassid},{userclassrel.Userid},{userclassrel.Siteid}");
			}
			userclassrel.CopyCommonFieldUpdatePrev(userClassRel4Update, systemTime, dbContext.Tid, text);
			userclassrel.CopyExtensionCollection(userClassRel4Update);
			list.Add(userClassRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
