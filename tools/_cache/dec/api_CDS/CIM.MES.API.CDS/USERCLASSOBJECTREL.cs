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
public class USERCLASSOBJECTREL
{
	private static string _sqlGetUserClassObjectRelSqlDatabase = "SELECT * FROM CIM_USERCLASSOBJECTREL WHERE USERCLASSID=@USERCLASSID AND OBJECTID=@OBJECTID AND MENUID=@MENUID AND MENUCLASSID=@MENUCLASSID AND SITEID=@SITEID";

	private static string _sqlGetUserClassObjectRel4UpdateSqlDatabase = "SELECT * FROM CIM_USERCLASSOBJECTREL WITH(UPDLOCK) WHERE USERCLASSID=@USERCLASSID AND OBJECTID=@OBJECTID AND MENUID=@MENUID AND MENUCLASSID=@MENUCLASSID AND SITEID=@SITEID";

	private static string _sqlSelectUserClassObjectRelSqlDatabase = "SELECT * FROM CIM_USERCLASSOBJECTREL WHERE USERCLASSID=@USERCLASSID AND OBJECTID=@OBJECTID AND MENUID=@MENUID AND MENUCLASSID=@MENUCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectUserClassObjectRel4UpdateSqlDatabase = "SELECT * FROM CIM_USERCLASSOBJECTREL WITH(UPDLOCK) WHERE USERCLASSID=@USERCLASSID AND OBJECTID=@OBJECTID AND MENUID=@MENUID AND MENUCLASSID=@MENUCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetUserClassObjectRelOracleDatabase = "SELECT * FROM CIM_USERCLASSOBJECTREL WHERE USERCLASSID=:USERCLASSID AND OBJECTID=:OBJECTID AND MENUID=:MENUID AND MENUCLASSID=:MENUCLASSID AND SITEID=:SITEID";

	private static string _sqlGetUserClassObjectRel4UpdateOracleDatabase = "SELECT * FROM CIM_USERCLASSOBJECTREL WHERE USERCLASSID=:USERCLASSID AND OBJECTID=:OBJECTID AND MENUID=:MENUID AND MENUCLASSID=:MENUCLASSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectUserClassObjectRelOracleDatabase = "SELECT * FROM CIM_USERCLASSOBJECTREL WHERE USERCLASSID=:USERCLASSID AND OBJECTID=:OBJECTID AND MENUID=:MENUID AND MENUCLASSID=:MENUCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectUserClassObjectRel4UpdateOracleDatabase = "SELECT * FROM CIM_USERCLASSOBJECTREL WHERE USERCLASSID=:USERCLASSID AND OBJECTID=:OBJECTID AND MENUID=:MENUID AND MENUCLASSID=:MENUCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Userclassobjectrel);

	public static Userclassobjectrel GetUserClassObjectRel(IDbContext dbContext, string userclassid, string objectid, string menuid, string menuclassid, string siteid)
	{
		string apiName = "GetUserClassObjectRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userclassid},{objectid},{menuid},{menuclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetUserClassObjectRelSqlDatabase : _sqlGetUserClassObjectRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERCLASSID", userclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("OBJECTID", objectid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUCLASSID", menuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_USERCLASSOBJECTREL", $"{userclassid},{objectid},{menuid},{menuclassid},{siteid}"));
		}
		Userclassobjectrel result = ContextManager.DirectEntityQuery<Userclassobjectrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userclassid},{objectid},{menuid},{menuclassid},{siteid}");
		}
		return result;
	}

	public static Userclassobjectrel GetUserClassObjectRel4Update(IDbContext dbContext, string userclassid, string objectid, string menuid, string menuclassid, string siteid)
	{
		string apiName = "GetUserClassObjectRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userclassid},{objectid},{menuid},{menuclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetUserClassObjectRel4UpdateSqlDatabase : _sqlGetUserClassObjectRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERCLASSID", userclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("OBJECTID", objectid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUCLASSID", menuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_USERCLASSOBJECTREL", $"{userclassid},{objectid},{menuid},{menuclassid},{siteid}"));
		}
		Userclassobjectrel result = ContextManager.DirectEntityQuery<Userclassobjectrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userclassid},{objectid},{menuid},{menuclassid},{siteid}");
		}
		return result;
	}

	public static Userclassobjectrel SelectUserClassObjectRel(IDbContext dbContext, string userclassid, string objectid, string menuid, string menuclassid, string siteid)
	{
		string apiName = "SelectUserClassObjectRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userclassid},{objectid},{menuid},{menuclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectUserClassObjectRelSqlDatabase : _sqlSelectUserClassObjectRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERCLASSID", userclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("OBJECTID", objectid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUCLASSID", menuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_USERCLASSOBJECTREL", $"{userclassid},{objectid},{menuid},{menuclassid},{siteid}"));
		}
		Userclassobjectrel result = ContextManager.DirectEntityQuery<Userclassobjectrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userclassid},{objectid},{menuid},{menuclassid},{siteid}");
		}
		return result;
	}

	public static Userclassobjectrel SelectUserClassObjectRel4Update(IDbContext dbContext, string userclassid, string objectid, string menuid, string menuclassid, string siteid)
	{
		string apiName = "SelectUserClassObjectRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userclassid},{objectid},{menuid},{menuclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectUserClassObjectRel4UpdateSqlDatabase : _sqlSelectUserClassObjectRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERCLASSID", userclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("OBJECTID", objectid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUCLASSID", menuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_USERCLASSOBJECTREL", $"{userclassid},{objectid},{menuid},{menuclassid},{siteid}"));
		}
		Userclassobjectrel result = ContextManager.DirectEntityQuery<Userclassobjectrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userclassid},{objectid},{menuid},{menuclassid},{siteid}");
		}
		return result;
	}

	public static int UpsertUserClassObjectRel(IDbContext dbContext, RequestType requestType, Userclassobjectrel[] userClassObjectRelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateUserClassObjectRelInternal(dbContext, userClassObjectRelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateUserClassObjectRel(dbContext, userClassObjectRelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteUserClassObjectRel(dbContext, userClassObjectRelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteUserClassObjectRel(dbContext, userClassObjectRelList, optionSet, saveHist), 
			_ => RealDeleteUserClassObjectRel(dbContext, userClassObjectRelList, optionSet, saveHist), 
		};
	}

	private static int CreateUserClassObjectRelInternal(IDbContext dbContext, Userclassobjectrel[] userClassObjectRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userClassObjectRelList", userClassObjectRelList);
		string text = "CreateUserClassObjectRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userclassobjectrel> list = new List<Userclassobjectrel>();
		foreach (Userclassobjectrel obj in userClassObjectRelList)
		{
			Userclassobjectrel userclassobjectrel = new Userclassobjectrel();
			obj.CopyColumsTo(userclassobjectrel);
			userclassobjectrel.Activity = text;
			userclassobjectrel.CheckEntityUsable();
			obj.CopyCommonField(userclassobjectrel, systemTime, dbContext.Tid, isCreate: true);
			list.Add(userclassobjectrel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateUserClassObjectRel(IDbContext dbContext, Userclassobjectrel[] userClassObjectRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userClassObjectRelList", userClassObjectRelList);
		string text = "UpdateUserClassObjectRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userclassobjectrel> list = new List<Userclassobjectrel>();
		foreach (Userclassobjectrel userclassobjectrel in userClassObjectRelList)
		{
			Userclassobjectrel userClassObjectRel4Update = GetUserClassObjectRel4Update(dbContext, userclassobjectrel.Userclassid, userclassobjectrel.Objectid, userclassobjectrel.Menuid, userclassobjectrel.Menuclassid, userclassobjectrel.Siteid);
			if (userClassObjectRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Userclassobjectrel), $"{userclassobjectrel.Userclassid},{userclassobjectrel.Objectid},{userclassobjectrel.Menuid},{userclassobjectrel.Menuclassid},{userclassobjectrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Userclassobjectrel), $"{userclassobjectrel.Userclassid},{userclassobjectrel.Objectid},{userclassobjectrel.Menuid},{userclassobjectrel.Menuclassid},{userclassobjectrel.Siteid}", userClassObjectRel4Update.Isusable);
			string activity = userClassObjectRel4Update.Activity;
			string customactivity = userClassObjectRel4Update.Customactivity;
			string isusable = userClassObjectRel4Update.Isusable;
			DateTime? createtime = userClassObjectRel4Update.Createtime;
			string creator = userClassObjectRel4Update.Creator;
			userclassobjectrel.CopyColumsTo(userClassObjectRel4Update);
			userClassObjectRel4Update.Prevactivity = activity;
			userClassObjectRel4Update.Prevcustomactivity = customactivity;
			userClassObjectRel4Update.Creator = creator;
			userClassObjectRel4Update.Createtime = createtime;
			userClassObjectRel4Update.Isusable = isusable;
			userClassObjectRel4Update.Activity = text;
			userclassobjectrel.CopyCommonField(userClassObjectRel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(userClassObjectRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteUserClassObjectRel(IDbContext dbContext, Userclassobjectrel[] userClassObjectRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userClassObjectRelList", userClassObjectRelList);
		string text = "DeleteUserClassObjectRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userclassobjectrel> list = new List<Userclassobjectrel>();
		foreach (Userclassobjectrel userclassobjectrel in userClassObjectRelList)
		{
			Userclassobjectrel userClassObjectRel4Update = GetUserClassObjectRel4Update(dbContext, userclassobjectrel.Userclassid, userclassobjectrel.Objectid, userclassobjectrel.Menuid, userclassobjectrel.Menuclassid, userclassobjectrel.Siteid);
			if (userClassObjectRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Userclassobjectrel), $"{userclassobjectrel.Userclassid},{userclassobjectrel.Objectid},{userclassobjectrel.Menuid},{userclassobjectrel.Menuclassid},{userclassobjectrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Userclassobjectrel), $"{userclassobjectrel.Userclassid},{userclassobjectrel.Objectid},{userclassobjectrel.Menuid},{userclassobjectrel.Menuclassid},{userclassobjectrel.Siteid}", userClassObjectRel4Update.Isusable);
			userClassObjectRel4Update.Isusable = "UnUsable";
			userclassobjectrel.CopyCommonFieldUpdatePrev(userClassObjectRel4Update, systemTime, dbContext.Tid, text);
			userclassobjectrel.CopyExtensionCollection(userClassObjectRel4Update);
			list.Add(userClassObjectRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteUserClassObjectRel(IDbContext dbContext, Userclassobjectrel[] userClassObjectRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userClassObjectRelList", userClassObjectRelList);
		string text = "UnDeleteUserClassObjectRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userclassobjectrel> list = new List<Userclassobjectrel>();
		foreach (Userclassobjectrel userclassobjectrel in userClassObjectRelList)
		{
			Userclassobjectrel userClassObjectRel4Update = GetUserClassObjectRel4Update(dbContext, userclassobjectrel.Userclassid, userclassobjectrel.Objectid, userclassobjectrel.Menuid, userclassobjectrel.Menuclassid, userclassobjectrel.Siteid);
			if (userClassObjectRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Userclassobjectrel), $"{userclassobjectrel.Userclassid},{userclassobjectrel.Objectid},{userclassobjectrel.Menuid},{userclassobjectrel.Menuclassid},{userclassobjectrel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Userclassobjectrel), $"{userclassobjectrel.Userclassid},{userclassobjectrel.Objectid},{userclassobjectrel.Menuid},{userclassobjectrel.Menuclassid},{userclassobjectrel.Siteid}", userClassObjectRel4Update.Isusable);
			userClassObjectRel4Update.Isusable = "Usable";
			userclassobjectrel.CopyCommonFieldUpdatePrev(userClassObjectRel4Update, systemTime, dbContext.Tid, text);
			userclassobjectrel.CopyExtensionCollection(userClassObjectRel4Update);
			list.Add(userClassObjectRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteUserClassObjectRel(IDbContext dbContext, Userclassobjectrel[] userClassObjectRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userClassObjectRelList", userClassObjectRelList);
		string text = "RealDeleteUserClassObjectRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userclassobjectrel> list = new List<Userclassobjectrel>();
		foreach (Userclassobjectrel userclassobjectrel in userClassObjectRelList)
		{
			Userclassobjectrel userClassObjectRel4Update = GetUserClassObjectRel4Update(dbContext, userclassobjectrel.Userclassid, userclassobjectrel.Objectid, userclassobjectrel.Menuid, userclassobjectrel.Menuclassid, userclassobjectrel.Siteid);
			if (userClassObjectRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Userclassobjectrel), $"{userclassobjectrel.Userclassid},{userclassobjectrel.Objectid},{userclassobjectrel.Menuid},{userclassobjectrel.Menuclassid},{userclassobjectrel.Siteid}");
			}
			userclassobjectrel.CopyCommonFieldUpdatePrev(userClassObjectRel4Update, systemTime, dbContext.Tid, text);
			userclassobjectrel.CopyExtensionCollection(userClassObjectRel4Update);
			list.Add(userClassObjectRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
