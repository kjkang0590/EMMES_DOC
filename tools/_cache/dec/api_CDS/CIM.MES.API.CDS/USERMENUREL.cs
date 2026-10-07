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
public class USERMENUREL
{
	private static string _sqlGetUserMenuRelSqlDatabase = "SELECT * FROM CIM_USERMENUREL WHERE USERID=@USERID AND MENUID=@MENUID AND MENUCLASSID=@MENUCLASSID AND SITEID=@SITEID";

	private static string _sqlGetUserMenuRel4UpdateSqlDatabase = "SELECT * FROM CIM_USERMENUREL WITH(UPDLOCK) WHERE USERID=@USERID AND MENUID=@MENUID AND MENUCLASSID=@MENUCLASSID AND SITEID=@SITEID";

	private static string _sqlSelectUserMenuRelSqlDatabase = "SELECT * FROM CIM_USERMENUREL WHERE USERID=@USERID AND MENUID=@MENUID AND MENUCLASSID=@MENUCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectUserMenuRel4UpdateSqlDatabase = "SELECT * FROM CIM_USERMENUREL WITH(UPDLOCK) WHERE USERID=@USERID AND MENUID=@MENUID AND MENUCLASSID=@MENUCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetUserMenuRelOracleDatabase = "SELECT * FROM CIM_USERMENUREL WHERE USERID=:USERID AND MENUID=:MENUID AND MENUCLASSID=:MENUCLASSID AND SITEID=:SITEID";

	private static string _sqlGetUserMenuRel4UpdateOracleDatabase = "SELECT * FROM CIM_USERMENUREL WHERE USERID=:USERID AND MENUID=:MENUID AND MENUCLASSID=:MENUCLASSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectUserMenuRelOracleDatabase = "SELECT * FROM CIM_USERMENUREL WHERE USERID=:USERID AND MENUID=:MENUID AND MENUCLASSID=:MENUCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectUserMenuRel4UpdateOracleDatabase = "SELECT * FROM CIM_USERMENUREL WHERE USERID=:USERID AND MENUID=:MENUID AND MENUCLASSID=:MENUCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Usermenurel);

	public static Usermenurel GetUserMenuRel(IDbContext dbContext, string userid, string menuid, string menuclassid, string siteid)
	{
		string apiName = "GetUserMenuRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userid},{menuid},{menuclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetUserMenuRelSqlDatabase : _sqlGetUserMenuRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUCLASSID", menuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_USERMENUREL", $"{userid},{menuid},{menuclassid},{siteid}"));
		}
		Usermenurel result = ContextManager.DirectEntityQuery<Usermenurel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userid},{menuid},{menuclassid},{siteid}");
		}
		return result;
	}

	public static Usermenurel GetUserMenuRel4Update(IDbContext dbContext, string userid, string menuid, string menuclassid, string siteid)
	{
		string apiName = "GetUserMenuRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userid},{menuid},{menuclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetUserMenuRel4UpdateSqlDatabase : _sqlGetUserMenuRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUCLASSID", menuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_USERMENUREL", $"{userid},{menuid},{menuclassid},{siteid}"));
		}
		Usermenurel result = ContextManager.DirectEntityQuery<Usermenurel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userid},{menuid},{menuclassid},{siteid}");
		}
		return result;
	}

	public static Usermenurel SelectUserMenuRel(IDbContext dbContext, string userid, string menuid, string menuclassid, string siteid)
	{
		string apiName = "SelectUserMenuRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userid},{menuid},{menuclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectUserMenuRelSqlDatabase : _sqlSelectUserMenuRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUCLASSID", menuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_USERMENUREL", $"{userid},{menuid},{menuclassid},{siteid}"));
		}
		Usermenurel result = ContextManager.DirectEntityQuery<Usermenurel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userid},{menuid},{menuclassid},{siteid}");
		}
		return result;
	}

	public static Usermenurel SelectUserMenuRel4Update(IDbContext dbContext, string userid, string menuid, string menuclassid, string siteid)
	{
		string apiName = "SelectUserMenuRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userid},{menuid},{menuclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectUserMenuRel4UpdateSqlDatabase : _sqlSelectUserMenuRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("MENUCLASSID", menuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_USERMENUREL", $"{userid},{menuid},{menuclassid},{siteid}"));
		}
		Usermenurel result = ContextManager.DirectEntityQuery<Usermenurel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userid},{menuid},{menuclassid},{siteid}");
		}
		return result;
	}

	public static int UpsertUserMenuRel(IDbContext dbContext, RequestType requestType, Usermenurel[] userMenuRelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateUserMenuRelInternal(dbContext, userMenuRelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateUserMenuRel(dbContext, userMenuRelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteUserMenuRel(dbContext, userMenuRelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteUserMenuRel(dbContext, userMenuRelList, optionSet, saveHist), 
			_ => RealDeleteUserMenuRel(dbContext, userMenuRelList, optionSet, saveHist), 
		};
	}

	private static int CreateUserMenuRelInternal(IDbContext dbContext, Usermenurel[] userMenuRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userMenuRelList", userMenuRelList);
		string text = "CreateUserMenuRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Usermenurel> list = new List<Usermenurel>();
		foreach (Usermenurel obj in userMenuRelList)
		{
			Usermenurel usermenurel = new Usermenurel();
			obj.CopyColumsTo(usermenurel);
			usermenurel.Activity = text;
			usermenurel.CheckEntityUsable();
			obj.CopyCommonField(usermenurel, systemTime, dbContext.Tid, isCreate: true);
			list.Add(usermenurel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateUserMenuRel(IDbContext dbContext, Usermenurel[] userMenuRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userMenuRelList", userMenuRelList);
		string text = "UpdateUserMenuRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Usermenurel> list = new List<Usermenurel>();
		foreach (Usermenurel usermenurel in userMenuRelList)
		{
			Usermenurel userMenuRel4Update = GetUserMenuRel4Update(dbContext, usermenurel.Userid, usermenurel.Menuid, usermenurel.Menuclassid, usermenurel.Siteid);
			if (userMenuRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Usermenurel), $"{usermenurel.Userid},{usermenurel.Menuid},{usermenurel.Menuclassid},{usermenurel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Usermenurel), $"{usermenurel.Userid},{usermenurel.Menuid},{usermenurel.Menuclassid},{usermenurel.Siteid}", userMenuRel4Update.Isusable);
			string activity = userMenuRel4Update.Activity;
			string customactivity = userMenuRel4Update.Customactivity;
			string isusable = userMenuRel4Update.Isusable;
			DateTime? createtime = userMenuRel4Update.Createtime;
			string creator = userMenuRel4Update.Creator;
			usermenurel.CopyColumsTo(userMenuRel4Update);
			userMenuRel4Update.Prevactivity = activity;
			userMenuRel4Update.Prevcustomactivity = customactivity;
			userMenuRel4Update.Creator = creator;
			userMenuRel4Update.Createtime = createtime;
			userMenuRel4Update.Isusable = isusable;
			userMenuRel4Update.Activity = text;
			usermenurel.CopyCommonField(userMenuRel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(userMenuRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteUserMenuRel(IDbContext dbContext, Usermenurel[] userMenuRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userMenuRelList", userMenuRelList);
		string text = "DeleteUserMenuRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Usermenurel> list = new List<Usermenurel>();
		foreach (Usermenurel usermenurel in userMenuRelList)
		{
			Usermenurel userMenuRel4Update = GetUserMenuRel4Update(dbContext, usermenurel.Userid, usermenurel.Menuid, usermenurel.Menuclassid, usermenurel.Siteid);
			if (userMenuRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Usermenurel), $"{usermenurel.Userid},{usermenurel.Menuid},{usermenurel.Menuclassid},{usermenurel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Usermenurel), $"{usermenurel.Userid},{usermenurel.Menuid},{usermenurel.Menuclassid},{usermenurel.Siteid}", userMenuRel4Update.Isusable);
			userMenuRel4Update.Isusable = "UnUsable";
			usermenurel.CopyCommonFieldUpdatePrev(userMenuRel4Update, systemTime, dbContext.Tid, text);
			usermenurel.CopyExtensionCollection(userMenuRel4Update);
			list.Add(userMenuRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteUserMenuRel(IDbContext dbContext, Usermenurel[] userMenuRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userMenuRelList", userMenuRelList);
		string text = "UnDeleteUserMenuRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Usermenurel> list = new List<Usermenurel>();
		foreach (Usermenurel usermenurel in userMenuRelList)
		{
			Usermenurel userMenuRel4Update = GetUserMenuRel4Update(dbContext, usermenurel.Userid, usermenurel.Menuid, usermenurel.Menuclassid, usermenurel.Siteid);
			if (userMenuRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Usermenurel), $"{usermenurel.Userid},{usermenurel.Menuid},{usermenurel.Menuclassid},{usermenurel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Usermenurel), $"{usermenurel.Userid},{usermenurel.Menuid},{usermenurel.Menuclassid},{usermenurel.Siteid}", userMenuRel4Update.Isusable);
			userMenuRel4Update.Isusable = "Usable";
			usermenurel.CopyCommonFieldUpdatePrev(userMenuRel4Update, systemTime, dbContext.Tid, text);
			usermenurel.CopyExtensionCollection(userMenuRel4Update);
			list.Add(userMenuRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteUserMenuRel(IDbContext dbContext, Usermenurel[] userMenuRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userMenuRelList", userMenuRelList);
		string text = "RealDeleteUserMenuRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Usermenurel> list = new List<Usermenurel>();
		foreach (Usermenurel usermenurel in userMenuRelList)
		{
			Usermenurel userMenuRel4Update = GetUserMenuRel4Update(dbContext, usermenurel.Userid, usermenurel.Menuid, usermenurel.Menuclassid, usermenurel.Siteid);
			if (userMenuRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Usermenurel), $"{usermenurel.Userid},{usermenurel.Menuid},{usermenurel.Menuclassid},{usermenurel.Siteid}");
			}
			usermenurel.CopyCommonFieldUpdatePrev(userMenuRel4Update, systemTime, dbContext.Tid, text);
			usermenurel.CopyExtensionCollection(userMenuRel4Update);
			list.Add(userMenuRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
