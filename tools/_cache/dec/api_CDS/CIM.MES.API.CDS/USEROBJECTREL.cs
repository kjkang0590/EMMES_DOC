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
public class USEROBJECTREL
{
	private static string _sqlGetUserObjectRelSqlDatabase = "SELECT * FROM CIM_USEROBJECTREL WHERE USERID=@USERID AND OBJECTID=@OBJECTID AND MENUID=@MENUID AND MENUCLASSID=@MENUCLASSID AND SITEID=@SITEID";

	private static string _sqlGetUserObjectRel4UpdateSqlDatabase = "SELECT * FROM CIM_USEROBJECTREL WITH(UPDLOCK) WHERE USERID=@USERID AND OBJECTID=@OBJECTID AND MENUID=@MENUID AND MENUCLASSID=@MENUCLASSID AND SITEID=@SITEID";

	private static string _sqlSelectUserObjectRelSqlDatabase = "SELECT * FROM CIM_USEROBJECTREL WHERE USERID=@USERID AND OBJECTID=@OBJECTID AND MENUID=@MENUID AND MENUCLASSID=@MENUCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectUserObjectRel4UpdateSqlDatabase = "SELECT * FROM CIM_USEROBJECTREL WITH(UPDLOCK) WHERE USERID=@USERID AND OBJECTID=@OBJECTID AND MENUID=@MENUID AND MENUCLASSID=@MENUCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetUserObjectRelOracleDatabase = "SELECT * FROM CIM_USEROBJECTREL WHERE USERID=:USERID AND OBJECTID=:OBJECTID AND MENUID=:MENUID AND MENUCLASSID=:MENUCLASSID AND SITEID=:SITEID";

	private static string _sqlGetUserObjectRel4UpdateOracleDatabase = "SELECT * FROM CIM_USEROBJECTREL WHERE USERID=:USERID AND OBJECTID=:OBJECTID AND MENUID=:MENUID AND MENUCLASSID=:MENUCLASSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectUserObjectRelOracleDatabase = "SELECT * FROM CIM_USEROBJECTREL WHERE USERID=:USERID AND OBJECTID=:OBJECTID AND MENUID=:MENUID AND MENUCLASSID=:MENUCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectUserObjectRel4UpdateOracleDatabase = "SELECT * FROM CIM_USEROBJECTREL WHERE USERID=:USERID AND OBJECTID=:OBJECTID AND MENUID=:MENUID AND MENUCLASSID=:MENUCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Userobjectrel);

	public static Userobjectrel GetUserObjectRel(IDbContext dbContext, string userid, string objectid, string menuid, string menuclassid, string siteid)
	{
		string apiName = "GetUserObjectRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userid},{objectid},{menuid},{menuclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetUserObjectRelSqlDatabase : _sqlGetUserObjectRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("OBJECTID", objectid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUCLASSID", menuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_USEROBJECTREL", $"{userid},{objectid},{menuid},{menuclassid},{siteid}"));
		}
		Userobjectrel result = ContextManager.DirectEntityQuery<Userobjectrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userid},{objectid},{menuid},{menuclassid},{siteid}");
		}
		return result;
	}

	public static Userobjectrel GetUserObjectRel4Update(IDbContext dbContext, string userid, string objectid, string menuid, string menuclassid, string siteid)
	{
		string apiName = "GetUserObjectRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userid},{objectid},{menuid},{menuclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetUserObjectRel4UpdateSqlDatabase : _sqlGetUserObjectRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("OBJECTID", objectid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUCLASSID", menuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_USEROBJECTREL", $"{userid},{objectid},{menuid},{menuclassid},{siteid}"));
		}
		Userobjectrel result = ContextManager.DirectEntityQuery<Userobjectrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userid},{objectid},{menuid},{menuclassid},{siteid}");
		}
		return result;
	}

	public static Userobjectrel SelectUserObjectRel(IDbContext dbContext, string userid, string objectid, string menuid, string menuclassid, string siteid)
	{
		string apiName = "SelectUserObjectRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userid},{objectid},{menuid},{menuclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectUserObjectRelSqlDatabase : _sqlSelectUserObjectRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("OBJECTID", objectid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUCLASSID", menuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_USEROBJECTREL", $"{userid},{objectid},{menuid},{menuclassid},{siteid}"));
		}
		Userobjectrel result = ContextManager.DirectEntityQuery<Userobjectrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userid},{objectid},{menuid},{menuclassid},{siteid}");
		}
		return result;
	}

	public static Userobjectrel SelectUserObjectRel4Update(IDbContext dbContext, string userid, string objectid, string menuid, string menuclassid, string siteid)
	{
		string apiName = "SelectUserObjectRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userid},{objectid},{menuid},{menuclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectUserObjectRel4UpdateSqlDatabase : _sqlSelectUserObjectRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("OBJECTID", objectid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUCLASSID", menuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_USEROBJECTREL", $"{userid},{objectid},{menuid},{menuclassid},{siteid}"));
		}
		Userobjectrel result = ContextManager.DirectEntityQuery<Userobjectrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userid},{objectid},{menuid},{menuclassid},{siteid}");
		}
		return result;
	}

	public static int UpsertUserObjectRel(IDbContext dbContext, RequestType requestType, Userobjectrel[] userObjectRelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateUserObjectRelInternal(dbContext, userObjectRelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateUserObjectRel(dbContext, userObjectRelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteUserObjectRel(dbContext, userObjectRelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteUserObjectRel(dbContext, userObjectRelList, optionSet, saveHist), 
			_ => RealDeleteUserObjectRel(dbContext, userObjectRelList, optionSet, saveHist), 
		};
	}

	private static int CreateUserObjectRelInternal(IDbContext dbContext, Userobjectrel[] userObjectRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userObjectRelList", userObjectRelList);
		string text = "CreateUserObjectRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userobjectrel> list = new List<Userobjectrel>();
		foreach (Userobjectrel obj in userObjectRelList)
		{
			Userobjectrel userobjectrel = new Userobjectrel();
			obj.CopyColumsTo(userobjectrel);
			userobjectrel.Activity = text;
			userobjectrel.CheckEntityUsable();
			obj.CopyCommonField(userobjectrel, systemTime, dbContext.Tid, isCreate: true);
			list.Add(userobjectrel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateUserObjectRel(IDbContext dbContext, Userobjectrel[] userObjectRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userObjectRelList", userObjectRelList);
		string text = "UpdateUserObjectRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userobjectrel> list = new List<Userobjectrel>();
		foreach (Userobjectrel userobjectrel in userObjectRelList)
		{
			Userobjectrel userObjectRel4Update = GetUserObjectRel4Update(dbContext, userobjectrel.Userid, userobjectrel.Objectid, userobjectrel.Menuid, userobjectrel.Menuclassid, userobjectrel.Siteid);
			if (userObjectRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Userobjectrel), $"{userobjectrel.Userid},{userobjectrel.Objectid},{userobjectrel.Menuid},{userobjectrel.Menuclassid},{userobjectrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Userobjectrel), $"{userobjectrel.Userid},{userobjectrel.Objectid},{userobjectrel.Menuid},{userobjectrel.Menuclassid},{userobjectrel.Siteid}", userObjectRel4Update.Isusable);
			string activity = userObjectRel4Update.Activity;
			string customactivity = userObjectRel4Update.Customactivity;
			string isusable = userObjectRel4Update.Isusable;
			DateTime? createtime = userObjectRel4Update.Createtime;
			string creator = userObjectRel4Update.Creator;
			userobjectrel.CopyColumsTo(userObjectRel4Update);
			userObjectRel4Update.Prevactivity = activity;
			userObjectRel4Update.Prevcustomactivity = customactivity;
			userObjectRel4Update.Creator = creator;
			userObjectRel4Update.Createtime = createtime;
			userObjectRel4Update.Isusable = isusable;
			userObjectRel4Update.Activity = text;
			userobjectrel.CopyCommonField(userObjectRel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(userObjectRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteUserObjectRel(IDbContext dbContext, Userobjectrel[] userObjectRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userObjectRelList", userObjectRelList);
		string text = "DeleteUserObjectRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userobjectrel> list = new List<Userobjectrel>();
		foreach (Userobjectrel userobjectrel in userObjectRelList)
		{
			Userobjectrel userObjectRel4Update = GetUserObjectRel4Update(dbContext, userobjectrel.Userid, userobjectrel.Objectid, userobjectrel.Menuid, userobjectrel.Menuclassid, userobjectrel.Siteid);
			if (userObjectRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Userobjectrel), $"{userobjectrel.Userid},{userobjectrel.Objectid},{userobjectrel.Menuid},{userobjectrel.Menuclassid},{userobjectrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Userobjectrel), $"{userobjectrel.Userid},{userobjectrel.Objectid},{userobjectrel.Menuid},{userobjectrel.Menuclassid},{userobjectrel.Siteid}", userObjectRel4Update.Isusable);
			userObjectRel4Update.Isusable = "UnUsable";
			userobjectrel.CopyCommonFieldUpdatePrev(userObjectRel4Update, systemTime, dbContext.Tid, text);
			userobjectrel.CopyExtensionCollection(userObjectRel4Update);
			list.Add(userObjectRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteUserObjectRel(IDbContext dbContext, Userobjectrel[] userObjectRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userObjectRelList", userObjectRelList);
		string text = "UnDeleteUserObjectRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userobjectrel> list = new List<Userobjectrel>();
		foreach (Userobjectrel userobjectrel in userObjectRelList)
		{
			Userobjectrel userObjectRel4Update = GetUserObjectRel4Update(dbContext, userobjectrel.Userid, userobjectrel.Objectid, userobjectrel.Menuid, userobjectrel.Menuclassid, userobjectrel.Siteid);
			if (userObjectRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Userobjectrel), $"{userobjectrel.Userid},{userobjectrel.Objectid},{userobjectrel.Menuid},{userobjectrel.Menuclassid},{userobjectrel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Userobjectrel), $"{userobjectrel.Userid},{userobjectrel.Objectid},{userobjectrel.Menuid},{userobjectrel.Menuclassid},{userobjectrel.Siteid}", userObjectRel4Update.Isusable);
			userObjectRel4Update.Isusable = "Usable";
			userobjectrel.CopyCommonFieldUpdatePrev(userObjectRel4Update, systemTime, dbContext.Tid, text);
			userobjectrel.CopyExtensionCollection(userObjectRel4Update);
			list.Add(userObjectRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteUserObjectRel(IDbContext dbContext, Userobjectrel[] userObjectRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userObjectRelList", userObjectRelList);
		string text = "RealDeleteUserObjectRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userobjectrel> list = new List<Userobjectrel>();
		foreach (Userobjectrel userobjectrel in userObjectRelList)
		{
			Userobjectrel userObjectRel4Update = GetUserObjectRel4Update(dbContext, userobjectrel.Userid, userobjectrel.Objectid, userobjectrel.Menuid, userobjectrel.Menuclassid, userobjectrel.Siteid);
			if (userObjectRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Userobjectrel), $"{userobjectrel.Userid},{userobjectrel.Objectid},{userobjectrel.Menuid},{userobjectrel.Menuclassid},{userobjectrel.Siteid}");
			}
			userobjectrel.CopyCommonFieldUpdatePrev(userObjectRel4Update, systemTime, dbContext.Tid, text);
			userobjectrel.CopyExtensionCollection(userObjectRel4Update);
			list.Add(userObjectRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
