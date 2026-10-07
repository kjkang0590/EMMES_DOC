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
public class USERFAVORITEMENU
{
	private static string _sqlGetUserFavoriteMenuSqlDatabase = "SELECT * FROM CIM_USERFAVORITEMENU WHERE USERID=@USERID AND FAVORITEMENUID=@FAVORITEMENUID AND FAVORITEMENUCLASSID=@FAVORITEMENUCLASSID AND SITEID=@SITEID";

	private static string _sqlGetUserFavoriteMenu4UpdateSqlDatabase = "SELECT * FROM CIM_USERFAVORITEMENU WITH(UPDLOCK) WHERE USERID=@USERID AND FAVORITEMENUID=@FAVORITEMENUID AND FAVORITEMENUCLASSID=@FAVORITEMENUCLASSID AND SITEID=@SITEID";

	private static string _sqlSelectUserFavoriteMenuSqlDatabase = "SELECT * FROM CIM_USERFAVORITEMENU WHERE USERID=@USERID AND FAVORITEMENUID=@FAVORITEMENUID AND FAVORITEMENUCLASSID=@FAVORITEMENUCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectUserFavoriteMenu4UpdateSqlDatabase = "SELECT * FROM CIM_USERFAVORITEMENU WITH(UPDLOCK) WHERE USERID=@USERID AND FAVORITEMENUID=@FAVORITEMENUID AND FAVORITEMENUCLASSID=@FAVORITEMENUCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetUserFavoriteMenuOracleDatabase = "SELECT * FROM CIM_USERFAVORITEMENU WHERE USERID=:USERID AND FAVORITEMENUID=:FAVORITEMENUID AND FAVORITEMENUCLASSID=:FAVORITEMENUCLASSID AND SITEID=:SITEID";

	private static string _sqlGetUserFavoriteMenu4UpdateOracleDatabase = "SELECT * FROM CIM_USERFAVORITEMENU WHERE USERID=:USERID AND FAVORITEMENUID=:FAVORITEMENUID AND FAVORITEMENUCLASSID=:FAVORITEMENUCLASSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectUserFavoriteMenuOracleDatabase = "SELECT * FROM CIM_USERFAVORITEMENU WHERE USERID=:USERID AND FAVORITEMENUID=:FAVORITEMENUID AND FAVORITEMENUCLASSID=:FAVORITEMENUCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectUserFavoriteMenu4UpdateOracleDatabase = "SELECT * FROM CIM_USERFAVORITEMENU WHERE USERID=:USERID AND FAVORITEMENUID=:FAVORITEMENUID AND FAVORITEMENUCLASSID=:FAVORITEMENUCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Userfavoritemenu);

	public static Userfavoritemenu GetUserFavoriteMenu(IDbContext dbContext, string userid, string favoritemenuid, string favoritemenuclassid, string siteid)
	{
		string apiName = "GetUserFavoriteMenu";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userid},{favoritemenuid},{favoritemenuclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetUserFavoriteMenuSqlDatabase : _sqlGetUserFavoriteMenuOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("FAVORITEMENUID", favoritemenuid, typeOfThis));
		list.Add(dbContext.CreateParameter("FAVORITEMENUCLASSID", favoritemenuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_USERFAVORITEMENU", $"{userid},{favoritemenuid},{favoritemenuclassid},{siteid}"));
		}
		Userfavoritemenu result = ContextManager.DirectEntityQuery<Userfavoritemenu>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userid},{favoritemenuid},{favoritemenuclassid},{siteid}");
		}
		return result;
	}

	public static Userfavoritemenu GetUserFavoriteMenu4Update(IDbContext dbContext, string userid, string favoritemenuid, string favoritemenuclassid, string siteid)
	{
		string apiName = "GetUserFavoriteMenu4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userid},{favoritemenuid},{favoritemenuclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetUserFavoriteMenu4UpdateSqlDatabase : _sqlGetUserFavoriteMenu4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("FAVORITEMENUID", favoritemenuid, typeOfThis));
		list.Add(dbContext.CreateParameter("FAVORITEMENUCLASSID", favoritemenuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_USERFAVORITEMENU", $"{userid},{favoritemenuid},{favoritemenuclassid},{siteid}"));
		}
		Userfavoritemenu result = ContextManager.DirectEntityQuery<Userfavoritemenu>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userid},{favoritemenuid},{favoritemenuclassid},{siteid}");
		}
		return result;
	}

	public static Userfavoritemenu SelectUserFavoriteMenu(IDbContext dbContext, string userid, string favoritemenuid, string favoritemenuclassid, string siteid)
	{
		string apiName = "SelectUserFavoriteMenu";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userid},{favoritemenuid},{favoritemenuclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectUserFavoriteMenuSqlDatabase : _sqlSelectUserFavoriteMenuOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("FAVORITEMENUID", favoritemenuid, typeOfThis));
		list.Add(dbContext.CreateParameter("FAVORITEMENUCLASSID", favoritemenuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_USERFAVORITEMENU", $"{userid},{favoritemenuid},{favoritemenuclassid},{siteid}"));
		}
		Userfavoritemenu result = ContextManager.DirectEntityQuery<Userfavoritemenu>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userid},{favoritemenuid},{favoritemenuclassid},{siteid}");
		}
		return result;
	}

	public static Userfavoritemenu SelectUserFavoriteMenu4Update(IDbContext dbContext, string userid, string favoritemenuid, string favoritemenuclassid, string siteid)
	{
		string apiName = "SelectUserFavoriteMenu4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userid},{favoritemenuid},{favoritemenuclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectUserFavoriteMenu4UpdateSqlDatabase : _sqlSelectUserFavoriteMenu4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("FAVORITEMENUID", favoritemenuid, typeOfThis));
		list.Add(dbContext.CreateParameter("FAVORITEMENUCLASSID", favoritemenuclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_USERFAVORITEMENU", $"{userid},{favoritemenuid},{favoritemenuclassid},{siteid}"));
		}
		Userfavoritemenu result = ContextManager.DirectEntityQuery<Userfavoritemenu>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userid},{favoritemenuid},{favoritemenuclassid},{siteid}");
		}
		return result;
	}

	public static int UpsertUserFavoriteMenu(IDbContext dbContext, RequestType requestType, Userfavoritemenu[] userFavoriteMenuList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateUserFavoriteMenuInternal(dbContext, userFavoriteMenuList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateUserFavoriteMenu(dbContext, userFavoriteMenuList, optionSet, saveHist), 
			RequestType.DELETE => DeleteUserFavoriteMenu(dbContext, userFavoriteMenuList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteUserFavoriteMenu(dbContext, userFavoriteMenuList, optionSet, saveHist), 
			_ => RealDeleteUserFavoriteMenu(dbContext, userFavoriteMenuList, optionSet, saveHist), 
		};
	}

	private static int CreateUserFavoriteMenuInternal(IDbContext dbContext, Userfavoritemenu[] userFavoriteMenuList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userFavoriteMenuList", userFavoriteMenuList);
		string text = "CreateUserFavoriteMenu";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userfavoritemenu> list = new List<Userfavoritemenu>();
		foreach (Userfavoritemenu obj in userFavoriteMenuList)
		{
			Userfavoritemenu userfavoritemenu = new Userfavoritemenu();
			obj.CopyColumsTo(userfavoritemenu);
			userfavoritemenu.Activity = text;
			userfavoritemenu.CheckEntityUsable();
			obj.CopyCommonField(userfavoritemenu, systemTime, dbContext.Tid, isCreate: true);
			list.Add(userfavoritemenu);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateUserFavoriteMenu(IDbContext dbContext, Userfavoritemenu[] userFavoriteMenuList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userFavoriteMenuList", userFavoriteMenuList);
		string text = "UpdateUserFavoriteMenu";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userfavoritemenu> list = new List<Userfavoritemenu>();
		foreach (Userfavoritemenu userfavoritemenu in userFavoriteMenuList)
		{
			Userfavoritemenu userFavoriteMenu4Update = GetUserFavoriteMenu4Update(dbContext, userfavoritemenu.Userid, userfavoritemenu.Favoritemenuid, userfavoritemenu.Favoritemenuclassid, userfavoritemenu.Siteid);
			if (userFavoriteMenu4Update == null)
			{
				throw new EntityNotFoundException(typeof(Userfavoritemenu), $"{userfavoritemenu.Userid},{userfavoritemenu.Favoritemenuid},{userfavoritemenu.Favoritemenuclassid},{userfavoritemenu.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Userfavoritemenu), $"{userfavoritemenu.Userid},{userfavoritemenu.Favoritemenuid},{userfavoritemenu.Favoritemenuclassid},{userfavoritemenu.Siteid}", userFavoriteMenu4Update.Isusable);
			string activity = userFavoriteMenu4Update.Activity;
			string customactivity = userFavoriteMenu4Update.Customactivity;
			string isusable = userFavoriteMenu4Update.Isusable;
			DateTime? createtime = userFavoriteMenu4Update.Createtime;
			string creator = userFavoriteMenu4Update.Creator;
			userfavoritemenu.CopyColumsTo(userFavoriteMenu4Update);
			userFavoriteMenu4Update.Prevactivity = activity;
			userFavoriteMenu4Update.Prevcustomactivity = customactivity;
			userFavoriteMenu4Update.Creator = creator;
			userFavoriteMenu4Update.Createtime = createtime;
			userFavoriteMenu4Update.Isusable = isusable;
			userFavoriteMenu4Update.Activity = text;
			userfavoritemenu.CopyCommonField(userFavoriteMenu4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(userFavoriteMenu4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteUserFavoriteMenu(IDbContext dbContext, Userfavoritemenu[] userFavoriteMenuList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userFavoriteMenuList", userFavoriteMenuList);
		string text = "DeleteUserFavoriteMenu";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userfavoritemenu> list = new List<Userfavoritemenu>();
		foreach (Userfavoritemenu userfavoritemenu in userFavoriteMenuList)
		{
			Userfavoritemenu userFavoriteMenu4Update = GetUserFavoriteMenu4Update(dbContext, userfavoritemenu.Userid, userfavoritemenu.Favoritemenuid, userfavoritemenu.Favoritemenuclassid, userfavoritemenu.Siteid);
			if (userFavoriteMenu4Update == null)
			{
				throw new EntityNotFoundException(typeof(Userfavoritemenu), $"{userfavoritemenu.Userid},{userfavoritemenu.Favoritemenuid},{userfavoritemenu.Favoritemenuclassid},{userfavoritemenu.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Userfavoritemenu), $"{userfavoritemenu.Userid},{userfavoritemenu.Favoritemenuid},{userfavoritemenu.Favoritemenuclassid},{userfavoritemenu.Siteid}", userFavoriteMenu4Update.Isusable);
			userFavoriteMenu4Update.Isusable = "UnUsable";
			userfavoritemenu.CopyCommonFieldUpdatePrev(userFavoriteMenu4Update, systemTime, dbContext.Tid, text);
			userfavoritemenu.CopyExtensionCollection(userFavoriteMenu4Update);
			list.Add(userFavoriteMenu4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteUserFavoriteMenu(IDbContext dbContext, Userfavoritemenu[] userFavoriteMenuList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userFavoriteMenuList", userFavoriteMenuList);
		string text = "UnDeleteUserFavoriteMenu";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userfavoritemenu> list = new List<Userfavoritemenu>();
		foreach (Userfavoritemenu userfavoritemenu in userFavoriteMenuList)
		{
			Userfavoritemenu userFavoriteMenu4Update = GetUserFavoriteMenu4Update(dbContext, userfavoritemenu.Userid, userfavoritemenu.Favoritemenuid, userfavoritemenu.Favoritemenuclassid, userfavoritemenu.Siteid);
			if (userFavoriteMenu4Update == null)
			{
				throw new EntityNotFoundException(typeof(Userfavoritemenu), $"{userfavoritemenu.Userid},{userfavoritemenu.Favoritemenuid},{userfavoritemenu.Favoritemenuclassid},{userfavoritemenu.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Userfavoritemenu), $"{userfavoritemenu.Userid},{userfavoritemenu.Favoritemenuid},{userfavoritemenu.Favoritemenuclassid},{userfavoritemenu.Siteid}", userFavoriteMenu4Update.Isusable);
			userFavoriteMenu4Update.Isusable = "Usable";
			userfavoritemenu.CopyCommonFieldUpdatePrev(userFavoriteMenu4Update, systemTime, dbContext.Tid, text);
			userfavoritemenu.CopyExtensionCollection(userFavoriteMenu4Update);
			list.Add(userFavoriteMenu4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteUserFavoriteMenu(IDbContext dbContext, Userfavoritemenu[] userFavoriteMenuList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userFavoriteMenuList", userFavoriteMenuList);
		string text = "RealDeleteUserFavoriteMenu";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userfavoritemenu> list = new List<Userfavoritemenu>();
		foreach (Userfavoritemenu userfavoritemenu in userFavoriteMenuList)
		{
			Userfavoritemenu userFavoriteMenu4Update = GetUserFavoriteMenu4Update(dbContext, userfavoritemenu.Userid, userfavoritemenu.Favoritemenuid, userfavoritemenu.Favoritemenuclassid, userfavoritemenu.Siteid);
			if (userFavoriteMenu4Update == null)
			{
				throw new EntityNotFoundException(typeof(Userfavoritemenu), $"{userfavoritemenu.Userid},{userfavoritemenu.Favoritemenuid},{userfavoritemenu.Favoritemenuclassid},{userfavoritemenu.Siteid}");
			}
			userfavoritemenu.CopyCommonFieldUpdatePrev(userFavoriteMenu4Update, systemTime, dbContext.Tid, text);
			userfavoritemenu.CopyExtensionCollection(userFavoriteMenu4Update);
			list.Add(userFavoriteMenu4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
