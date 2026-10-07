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
public class USERCLASSMENUREL
{
	private static string _sqlGetUserClassMenuRelSqlDatabase = "SELECT * FROM CIM_USERCLASSMENUREL WHERE USERCLASSID=@USERCLASSID AND MENUID=@MENUID AND MENUCLASSID=@MENUCLASSID AND SITEID=@SITEID";

	private static string _sqlGetUserClassMenuRel4UpdateSqlDatabase = "SELECT * FROM CIM_USERCLASSMENUREL WITH(UPDLOCK) WHERE USERCLASSID=@USERCLASSID AND MENUID=@MENUID AND MENUCLASSID=@MENUCLASSID AND SITEID=@SITEID";

	private static string _sqlSelectUserClassMenuRelSqlDatabase = "SELECT * FROM CIM_USERCLASSMENUREL WHERE USERCLASSID=@USERCLASSID AND MENUID=@MENUID AND MENUCLASSID=@MENUCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectUserClassMenuRel4UpdateSqlDatabase = "SELECT * FROM CIM_USERCLASSMENUREL WITH(UPDLOCK) WHERE USERCLASSID=@USERCLASSID AND MENUID=@MENUID AND MENUCLASSID=@MENUCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetUserClassMenuRelOracleDatabase = "SELECT * FROM CIM_USERCLASSMENUREL WHERE USERCLASSID=:USERCLASSID AND MENUID=:MENUID AND MENUCLASSID=:MENUCLASSID AND SITEID=:SITEID";

	private static string _sqlGetUserClassMenuRel4UpdateOracleDatabase = "SELECT * FROM CIM_USERCLASSMENUREL WHERE USERCLASSID=:USERCLASSID AND MENUID=:MENUID AND MENUCLASSID=:MENUCLASSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectUserClassMenuRelOracleDatabase = "SELECT * FROM CIM_USERCLASSMENUREL WHERE USERCLASSID=:USERCLASSID AND MENUID=:MENUID AND MENUCLASSID=:MENUCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectUserClassMenuRel4UpdateOracleDatabase = "SELECT * FROM CIM_USERCLASSMENUREL WHERE USERCLASSID=:USERCLASSID AND MENUID=:MENUID AND MENUCLASSID=:MENUCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Userclassmenurel);

	public static Userclassmenurel GetUserClassMenuRel(IDbContext dbContext, string userclassid, string menuid, string menuclassid, string siteid)
	{
		string apiName = "GetUserClassMenuRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userclassid},{menuid},{menuclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetUserClassMenuRelSqlDatabase : _sqlGetUserClassMenuRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERCLASSID", userclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUCLASSID", menuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_USERCLASSMENUREL", $"{userclassid},{menuid},{menuclassid},{siteid}"));
		}
		Userclassmenurel result = ContextManager.DirectEntityQuery<Userclassmenurel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userclassid},{menuid},{menuclassid},{siteid}");
		}
		return result;
	}

	public static Userclassmenurel GetUserClassMenuRel4Update(IDbContext dbContext, string userclassid, string menuid, string menuclassid, string siteid)
	{
		string apiName = "GetUserClassMenuRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userclassid},{menuid},{menuclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetUserClassMenuRel4UpdateSqlDatabase : _sqlGetUserClassMenuRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERCLASSID", userclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUCLASSID", menuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_USERCLASSMENUREL", $"{userclassid},{menuid},{menuclassid},{siteid}"));
		}
		Userclassmenurel result = ContextManager.DirectEntityQuery<Userclassmenurel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userclassid},{menuid},{menuclassid},{siteid}");
		}
		return result;
	}

	public static Userclassmenurel SelectUserClassMenuRel(IDbContext dbContext, string userclassid, string menuid, string menuclassid, string siteid)
	{
		string apiName = "SelectUserClassMenuRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userclassid},{menuid},{menuclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectUserClassMenuRelSqlDatabase : _sqlSelectUserClassMenuRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERCLASSID", userclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUCLASSID", menuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_USERCLASSMENUREL", $"{userclassid},{menuid},{menuclassid},{siteid}"));
		}
		Userclassmenurel result = ContextManager.DirectEntityQuery<Userclassmenurel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userclassid},{menuid},{menuclassid},{siteid}");
		}
		return result;
	}

	public static Userclassmenurel SelectUserClassMenuRel4Update(IDbContext dbContext, string userclassid, string menuid, string menuclassid, string siteid)
	{
		string apiName = "SelectUserClassMenuRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userclassid},{menuid},{menuclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectUserClassMenuRel4UpdateSqlDatabase : _sqlSelectUserClassMenuRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERCLASSID", userclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUCLASSID", menuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_USERCLASSMENUREL", $"{userclassid},{menuid},{menuclassid},{siteid}"));
		}
		Userclassmenurel result = ContextManager.DirectEntityQuery<Userclassmenurel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userclassid},{menuid},{menuclassid},{siteid}");
		}
		return result;
	}

	public static int UpsertUserClassMenuRel(IDbContext dbContext, RequestType requestType, Userclassmenurel[] userClassMenuRelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateUserClassMenuRelInternal(dbContext, userClassMenuRelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateUserClassMenuRel(dbContext, userClassMenuRelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteUserClassMenuRel(dbContext, userClassMenuRelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteUserClassMenuRel(dbContext, userClassMenuRelList, optionSet, saveHist), 
			_ => RealDeleteUserClassMenuRel(dbContext, userClassMenuRelList, optionSet, saveHist), 
		};
	}

	private static int CreateUserClassMenuRelInternal(IDbContext dbContext, Userclassmenurel[] userClassMenuRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userClassMenuRelList", userClassMenuRelList);
		string text = "CreateUserClassMenuRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userclassmenurel> list = new List<Userclassmenurel>();
		foreach (Userclassmenurel obj in userClassMenuRelList)
		{
			Userclassmenurel userclassmenurel = new Userclassmenurel();
			obj.CopyColumsTo(userclassmenurel);
			userclassmenurel.Activity = text;
			userclassmenurel.CheckEntityUsable();
			obj.CopyCommonField(userclassmenurel, systemTime, dbContext.Tid, isCreate: true);
			list.Add(userclassmenurel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateUserClassMenuRel(IDbContext dbContext, Userclassmenurel[] userClassMenuRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userClassMenuRelList", userClassMenuRelList);
		string text = "UpdateUserClassMenuRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userclassmenurel> list = new List<Userclassmenurel>();
		foreach (Userclassmenurel userclassmenurel in userClassMenuRelList)
		{
			Userclassmenurel userClassMenuRel4Update = GetUserClassMenuRel4Update(dbContext, userclassmenurel.Userclassid, userclassmenurel.Menuid, userclassmenurel.Menuclassid, userclassmenurel.Siteid);
			if (userClassMenuRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Userclassmenurel), $"{userclassmenurel.Userclassid},{userclassmenurel.Menuid},{userclassmenurel.Menuclassid},{userclassmenurel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Userclassmenurel), $"{userclassmenurel.Userclassid},{userclassmenurel.Menuid},{userclassmenurel.Menuclassid},{userclassmenurel.Siteid}", userClassMenuRel4Update.Isusable);
			string activity = userClassMenuRel4Update.Activity;
			string customactivity = userClassMenuRel4Update.Customactivity;
			string isusable = userClassMenuRel4Update.Isusable;
			DateTime? createtime = userClassMenuRel4Update.Createtime;
			string creator = userClassMenuRel4Update.Creator;
			userclassmenurel.CopyColumsTo(userClassMenuRel4Update);
			userClassMenuRel4Update.Prevactivity = activity;
			userClassMenuRel4Update.Prevcustomactivity = customactivity;
			userClassMenuRel4Update.Creator = creator;
			userClassMenuRel4Update.Createtime = createtime;
			userClassMenuRel4Update.Isusable = isusable;
			userClassMenuRel4Update.Activity = text;
			userclassmenurel.CopyCommonField(userClassMenuRel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(userClassMenuRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteUserClassMenuRel(IDbContext dbContext, Userclassmenurel[] userClassMenuRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userClassMenuRelList", userClassMenuRelList);
		string text = "DeleteUserClassMenuRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userclassmenurel> list = new List<Userclassmenurel>();
		foreach (Userclassmenurel userclassmenurel in userClassMenuRelList)
		{
			Userclassmenurel userClassMenuRel4Update = GetUserClassMenuRel4Update(dbContext, userclassmenurel.Userclassid, userclassmenurel.Menuid, userclassmenurel.Menuclassid, userclassmenurel.Siteid);
			if (userClassMenuRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Userclassmenurel), $"{userclassmenurel.Userclassid},{userclassmenurel.Menuid},{userclassmenurel.Menuclassid},{userclassmenurel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Userclassmenurel), $"{userclassmenurel.Userclassid},{userclassmenurel.Menuid},{userclassmenurel.Menuclassid},{userclassmenurel.Siteid}", userClassMenuRel4Update.Isusable);
			userClassMenuRel4Update.Isusable = "UnUsable";
			userclassmenurel.CopyCommonFieldUpdatePrev(userClassMenuRel4Update, systemTime, dbContext.Tid, text);
			userclassmenurel.CopyExtensionCollection(userClassMenuRel4Update);
			list.Add(userClassMenuRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteUserClassMenuRel(IDbContext dbContext, Userclassmenurel[] userClassMenuRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userClassMenuRelList", userClassMenuRelList);
		string text = "UnDeleteUserClassMenuRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userclassmenurel> list = new List<Userclassmenurel>();
		foreach (Userclassmenurel userclassmenurel in userClassMenuRelList)
		{
			Userclassmenurel userClassMenuRel4Update = GetUserClassMenuRel4Update(dbContext, userclassmenurel.Userclassid, userclassmenurel.Menuid, userclassmenurel.Menuclassid, userclassmenurel.Siteid);
			if (userClassMenuRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Userclassmenurel), $"{userclassmenurel.Userclassid},{userclassmenurel.Menuid},{userclassmenurel.Menuclassid},{userclassmenurel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Userclassmenurel), $"{userclassmenurel.Userclassid},{userclassmenurel.Menuid},{userclassmenurel.Menuclassid},{userclassmenurel.Siteid}", userClassMenuRel4Update.Isusable);
			userClassMenuRel4Update.Isusable = "Usable";
			userclassmenurel.CopyCommonFieldUpdatePrev(userClassMenuRel4Update, systemTime, dbContext.Tid, text);
			userclassmenurel.CopyExtensionCollection(userClassMenuRel4Update);
			list.Add(userClassMenuRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteUserClassMenuRel(IDbContext dbContext, Userclassmenurel[] userClassMenuRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userClassMenuRelList", userClassMenuRelList);
		string text = "RealDeleteUserClassMenuRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userclassmenurel> list = new List<Userclassmenurel>();
		foreach (Userclassmenurel userclassmenurel in userClassMenuRelList)
		{
			Userclassmenurel userClassMenuRel4Update = GetUserClassMenuRel4Update(dbContext, userclassmenurel.Userclassid, userclassmenurel.Menuid, userclassmenurel.Menuclassid, userclassmenurel.Siteid);
			if (userClassMenuRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Userclassmenurel), $"{userclassmenurel.Userclassid},{userclassmenurel.Menuid},{userclassmenurel.Menuclassid},{userclassmenurel.Siteid}");
			}
			userclassmenurel.CopyCommonFieldUpdatePrev(userClassMenuRel4Update, systemTime, dbContext.Tid, text);
			userclassmenurel.CopyExtensionCollection(userClassMenuRel4Update);
			list.Add(userClassMenuRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
