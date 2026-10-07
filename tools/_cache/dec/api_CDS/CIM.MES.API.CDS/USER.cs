using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;
using CIM.Util.Security;

namespace CIM.MES.API.CDS;

[MESAPI]
public class USER
{
	private static string _sqlGetUserSqlDatabase = "SELECT * FROM CIM_USER WHERE USERID=@USERID AND SITEID=@SITEID";

	private static string _sqlGetUser4UpdateSqlDatabase = "SELECT * FROM CIM_USER WITH(UPDLOCK) WHERE USERID=@USERID AND SITEID=@SITEID";

	private static string _sqlSelectUserSqlDatabase = "SELECT * FROM CIM_USER WHERE USERID=@USERID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectUser4UpdateSqlDatabase = "SELECT * FROM CIM_USER WITH(UPDLOCK) WHERE USERID=@USERID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetUserOracleDatabase = "SELECT * FROM CIM_USER WHERE USERID=:USERID AND SITEID=:SITEID";

	private static string _sqlGetUser4UpdateOracleDatabase = "SELECT * FROM CIM_USER WHERE USERID=:USERID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectUserOracleDatabase = "SELECT * FROM CIM_USER WHERE USERID=:USERID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectUser4UpdateOracleDatabase = "SELECT * FROM CIM_USER WHERE USERID=:USERID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(User);

	private static string _sqlSelectUserClassRelListSqlDatabase = "SELECT * FROM CIM_USERCLASSREL WHERE USERID=@USERID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectUserClassRelListOracleDatabase = "SELECT * FROM CIM_USERCLASSREL WHERE USERID=:USERID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectUserClassRelListByDivisionSqlDatabase = "\n            SELECT DISTINCT M.MENUID\n            ,M.MENUCLASSID\n            ,M.SITEID\n            ,ISNULL(CM.LANGUAGECODEDATA,M.MENUNAME) AS MENUNAME\n            ,M.MENUTYPE\n            ,M.CONTROLTYPE\n            ,M.VIEWID\n            ,M.VIEWTYPE\n            ,M.PARENTID\n            ,M.SEQUENCE\n            ,M.DEPTH \n              FROM CIM_USERCLASSREL UCR\n             INNER JOIN CIM_USERCLASSMENUREL UCMR\n \t            ON UCR.USERCLASSID = UCMR.USERCLASSID AND UCR.SITEID = UCMR.SITEID AND UCMR.ISUSABLE ='Usable'\n             INNER JOIN CIM_USERCLASS UC\n \t            ON UCMR.USERCLASSID = UC.USERCLASSID AND UCMR.SITEID = UC.SITEID AND UC.DIVISION=@DIVISION AND UC.ISUSABLE ='Usable'\n             INNER JOIN CIM_MENU M\n \t            ON UCMR.MENUID = M.MENUID AND UCMR.MENUCLASSID = M.MENUCLASSID AND UCMR.SITEID = M.SITEID AND M.ISUSABLE ='Usable'\n             LEFT JOIN CIM_MULTILANGUAGE CM\n \t            ON UCR.SITEID = CM.SITEID AND M.MENUID = CM.LANGUAGECODEID AND CM.CODETYPE = 'MENU' AND CM.LANGUAGE = @LANGUAGE AND CM.ISUSABLE ='Usable'\n             WHERE UCR.USERID=@USERID\n               AND UCR.SITEID=@SITEID\n               AND UCR.ISUSABLE='Usable'\n                ";

	private static string _sqlSelectUserClassRelListByDivisionOracleDatabase = "\n            SELECT DISTINCT M.MENUID\n            ,M.MENUCLASSID\n            ,M.SITEID\n            ,NVL(CM.LANGUAGECODEDATA,M.MENUNAME) AS MENUNAME\n            ,M.MENUTYPE\n            ,M.CONTROLTYPE\n            ,M.VIEWID\n            ,M.VIEWTYPE\n            ,M.PARENTID\n            ,M.SEQUENCE\n            ,M.DEPTH \n              FROM CIM_USERCLASSREL UCR\n             INNER JOIN CIM_USERCLASSMENUREL UCMR\n \t            ON UCR.USERCLASSID = UCMR.USERCLASSID AND UCR.SITEID = UCMR.SITEID AND UCMR.ISUSABLE ='Usable'\n             INNER JOIN CIM_USERCLASS UC\n \t            ON UCMR.USERCLASSID = UC.USERCLASSID AND UCMR.SITEID = UC.SITEID AND UC.DIVISION=:DIVISION AND UC.ISUSABLE ='Usable'\n             INNER JOIN CIM_MENU M\n \t            ON UCMR.MENUID = M.MENUID AND UCMR.MENUCLASSID = M.MENUCLASSID AND UCMR.SITEID = M.SITEID AND M.ISUSABLE ='Usable'\n             LEFT JOIN CIM_MULTILANGUAGE CM\n \t            ON UCR.SITEID = CM.SITEID AND M.MENUID = CM.LANGUAGECODEID AND CM.CODETYPE = 'MENU' AND CM.LANGUAGE = :LANGUAGE AND CM.ISUSABLE ='Usable'\n             WHERE UCR.USERID=:USERID\n               AND UCR.SITEID=:SITEID\n               AND UCR.ISUSABLE='Usable'\n            ";

	private static string _sqlSelectUserFavoriteMenuListSqlDatabase = "\nSELECT F.* \n  FROM CIM_USER U\n INNER JOIN CIM_USERFAVORITEMENU F\n \tON U.USERID=F.USERID AND U.SITEID=F.SITEID AND F.ISUSABLE='Usable'\n INNER JOIN CIM_MENU M\n \tON F.MENUID=M.MENUID AND F.MENUCLASSID=M.MENUCLASSID AND F.SITEID=M.SITEID AND M.ISUSABLE='Usable'\n WHERE U.USERID=@USERID\n   AND U.SITEID=@SITEID\n   AND U.ISUSABLE='Usable'\n";

	private static string _sqlSelectUserFavoriteMenuListOracleDatabase = "\nSELECT F.* \n  FROM CIM_USER U\n INNER JOIN CIM_USERFAVORITEMENU F\n \tON U.USERID= F.USERID AND U.SITEID=F.SITEID AND F.ISUSABLE='Usable'\n INNER JOIN CIM_MENU M\n \tON F.MENUID= M.MENUID AND F.MENUCLASSID=M.MENUCLASSID AND F.SITEID=M.SITEID AND M.ISUSABLE='Usable'\n WHERE U.USERID=:USERID\n   AND U.SITEID=:SITEID\n   AND U.ISUSABLE = 'Usable'\n";

	private static string _sqlSelectUserMenuListSqlDatabase = "\nSELECT M.* \n  FROM CIM_USER U\n INNER JOIN CIM_USERCLASSREL CR\n \tON U.USERID = CR.USERID AND U.SITEID = CR.SITEID AND CR.ISUSABLE ='Usable'\n INNER JOIN CIM_USERCLASSMENUREL R\n \tON CR.USERCLASSID = R.USERCLASSID AND CR.SITEID = R.SITEID AND R.ISUSABLE ='Usable'\n INNER JOIN CIM_USERCLASS C\n \tON CR.DIVISION = @DIVISION AND CR.USERCLASSID = C.USERCLASSID AND CR.SITEID = C.SITEID AND C.ISUSABLE ='Usable'\n INNER JOIN CIM_MENU M \n \tON R.MENUID = M.MENUID AND R.MENUCLASSID = M.MENUCLASSID AND R.SITEID = M.SITEID AND M.ISUSABLE ='Usable'\n WHERE U.USERID = @USERID\n   AND U.SITEID = @SITEID\n   AND U.ISUSABLE ='Usable'\n";

	private static string _sqlSelectUserMenuListOracleDatabase = "\nSELECT M.* \n  FROM CIM_USER U\n INNER JOIN CIM_USERCLASSREL CR\n \tON U.USERID = CR.USERID AND U.SITEID = CR.SITEID AND CR.ISUSABLE ='Usable'\n INNER JOIN CIM_USERCLASSMENUREL R\n \tON CR.USERCLASSID = R.USERCLASSID AND CR.SITEID = R.SITEID AND R.ISUSABLE ='Usable'\n INNER JOIN CIM_USERCLASS C\n \tON CR.DIVISION = :DIVISION AND CR.USERCLASSID = C.USERCLASSID AND CR.SITEID = C.SITEID AND C.ISUSABLE ='Usable'\n INNER JOIN CIM_MENU M \n \tON R.MENUID = M.MENUID AND R.MENUCLASSID = M.MENUCLASSID AND R.SITEID = M.SITEID AND M.ISUSABLE ='Usable'\n WHERE U.USERID = :USERID\n   AND U.SITEID = :SITEID\n   AND U.ISUSABLE ='Usable'\n";

	public static int ChangePassword(IDbContext dbContext, User inputUser, string changePassword, ChangePasswordOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("inputUser", inputUser);
		ParamChecker.ArgumentNotNull("changePassword", changePassword);
		string text = "ChangePassword";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(text), $"{inputUser}");
		}
		bool flag = optionSet?.InitializePassword ?? false;
		string siteid = inputUser.Siteid;
		string userid = inputUser.Userid;
		string password = inputUser.Password;
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		List<User> list = new List<User>();
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_USER", $"{userid},{siteid}"));
		}
		User user;
		if ((user = SelectUser4Update(dbContext, userid, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(User), userid);
		}
		Loginpolicy loginpolicy;
		if ((loginpolicy = LOGINPOLICY.SelectPrimaryLoginPolicy(dbContext, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(Loginpolicy), siteid);
		}
		if (!flag && password != user.Password)
		{
			throw new PasswordMismatchException(userid);
		}
		decimal? num = loginpolicy.Passwordminlength;
		if (num.HasValue)
		{
			decimal num2 = changePassword.Length;
			decimal? num3 = num;
			if ((num2 < num3.GetValueOrDefault()) & num3.HasValue)
			{
				throw new ArgumentException($"Your password must be at least {num} characters");
			}
		}
		user.Passwordregisterdate = systemTime;
		user.Passworduseflag = "Y";
		user.Password = changePassword;
		user.Loginretrycount = 0;
		user.Activity = "ChangePassword";
		inputUser.CopyCommonFieldUpdatePrev(user, systemTime, dbContext.Tid, text);
		list.Add(user);
		int result = ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(text), $"{userid}");
		}
		return result;
	}

	public static int CreateUser(IDbContext dbContext, User[] userList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userList", userList);
		string text = "CreateUser";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<User> list = new List<User>();
		foreach (User obj in userList)
		{
			User user = new User();
			obj.CopyColumsTo(user);
			user.Activity = text;
			user.Isusable = "Usable";
			obj.CopyCommonField(user, systemTime, dbContext.Tid, isCreate: true);
			list.Add(user);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static User GetUser(IDbContext dbContext, string userid, string siteid)
	{
		string apiName = "GetUser";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetUserSqlDatabase : _sqlGetUserOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_USER", $"{userid},{siteid}"));
		}
		User? result = ContextManager.DirectEntityQuery<User>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userid},{siteid}");
		}
		return result;
	}

	public static User GetUser4Update(IDbContext dbContext, string userid, string siteid)
	{
		string apiName = "GetUser4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetUser4UpdateSqlDatabase : _sqlGetUser4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_USER", $"{userid},{siteid}"));
		}
		User? result = ContextManager.DirectEntityQuery<User>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userid},{siteid}");
		}
		return result;
	}

	public static User SelectUser(IDbContext dbContext, string userid, string siteid)
	{
		string apiName = "SelectUser";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectUserSqlDatabase : _sqlSelectUserOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_USER", $"{userid},{siteid}"));
		}
		User? result = ContextManager.DirectEntityQuery<User>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userid},{siteid}");
		}
		return result;
	}

	public static User SelectUser4Update(IDbContext dbContext, string userid, string siteid)
	{
		string apiName = "SelectUser4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectUser4UpdateSqlDatabase : _sqlSelectUser4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_USER", $"{userid},{siteid}"));
		}
		User? result = ContextManager.DirectEntityQuery<User>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userid},{siteid}");
		}
		return result;
	}

	public static IList<Userclassrel> SelectUserClassRelList(IDbContext dbContext, string userid, string siteid)
	{
		string apiName = "SelectUserClassRelList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectUserClassRelListSqlDatabase : _sqlSelectUserClassRelListOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		IList<Userclassrel> source = ContextManager.DirectEntityQuery<Userclassrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userid},{siteid}");
		}
		return source.ToList();
	}

	public static IList<Menu> SelectUserClassObjectRelByDivision(IDbContext dbContext, string division, string userid, string language, string siteid)
	{
		string apiName = "SelectUserClassObjectRelByDivision";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{division},{userid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectUserClassRelListByDivisionSqlDatabase : _sqlSelectUserClassRelListByDivisionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LANGUAGE", language, typeOfThis));
		list.Add(dbContext.CreateParameter("DIVISION", division, typeOfThis));
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		IList<Menu> source = ContextManager.DirectEntityQuery<Menu>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{division},{userid},{siteid}");
		}
		return source.ToList();
	}

	public static IList<Userfavoritemenu> SelectUserFavoriteMenuList(IDbContext dbContext, string userid, string siteid)
	{
		string apiName = "SelectUserFavoriteMenuList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectUserFavoriteMenuListSqlDatabase : _sqlSelectUserFavoriteMenuListOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		IList<Userfavoritemenu> source = ContextManager.DirectEntityQuery<Userfavoritemenu>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userid},{siteid}");
		}
		return source.ToList();
	}

	public static Menu[] SelectUserMenuList(IDbContext dbContext, string division, string userid, string siteid)
	{
		string apiName = "SelectUserMenuList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{division},{userid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectUserMenuListSqlDatabase : _sqlSelectUserMenuListOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DIVISION", division, typeOfThis));
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MENU", $"{division},{userid},{siteid}"));
		}
		IList<Menu> source = ContextManager.DirectEntityQuery<Menu>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{division},{userid},{siteid}");
		}
		return source.ToArray();
	}

	public static int UpsertUser(IDbContext dbContext, RequestType requestType, User[] userList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateUserInternal(dbContext, userList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateUser(dbContext, userList, optionSet, saveHist), 
			RequestType.DELETE => DeleteUser(dbContext, userList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteUser(dbContext, userList, optionSet, saveHist), 
			_ => RealDeleteUser(dbContext, userList, optionSet, saveHist), 
		};
	}

	private static int CreateUserInternal(IDbContext dbContext, User[] userList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userList", userList);
		string text = "CreateUser";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<User> list = new List<User>();
		foreach (User user in userList)
		{
			User user2 = new User();
			user.CopyColumsTo(user2);
			user2.Password = HMAC256Crypto.Encrypt(user.Password);
			user2.Passworduseflag = "Y";
			user2.Activity = text;
			user2.CheckEntityUsable();
			user.CopyCommonField(user2, systemTime, dbContext.Tid, isCreate: true);
			list.Add(user2);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateUser(IDbContext dbContext, User[] userList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userList", userList);
		string text = "UpdateUser";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<User> list = new List<User>();
		foreach (User user in userList)
		{
			User user4Update = GetUser4Update(dbContext, user.Userid, user.Siteid);
			if (user4Update == null)
			{
				throw new EntityNotFoundException(typeof(User), $"{user.Userid},{user.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(User), $"{user.Userid},{user.Siteid}", user4Update.Isusable);
			string activity = user4Update.Activity;
			string customactivity = user4Update.Customactivity;
			string isusable = user4Update.Isusable;
			DateTime? createtime = user4Update.Createtime;
			string creator = user4Update.Creator;
			string password = user4Update.Password;
			user.CopyColumsTo(user4Update);
			user4Update.Prevactivity = activity;
			user4Update.Prevcustomactivity = customactivity;
			user4Update.Creator = creator;
			user4Update.Createtime = createtime;
			user4Update.Isusable = isusable;
			user4Update.Password = password;
			user4Update.Activity = text;
			user.CopyCommonField(user4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(user4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteUser(IDbContext dbContext, User[] userList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userList", userList);
		string text = "DeleteUser";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<User> list = new List<User>();
		foreach (User user in userList)
		{
			User user4Update = GetUser4Update(dbContext, user.Userid, user.Siteid);
			if (user4Update == null)
			{
				throw new EntityNotFoundException(typeof(User), $"{user.Userid},{user.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(User), $"{user.Userid},{user.Siteid}", user4Update.Isusable);
			user4Update.Isusable = "UnUsable";
			user.CopyCommonFieldUpdatePrev(user4Update, systemTime, dbContext.Tid, text);
			user.CopyExtensionCollection(user4Update);
			list.Add(user4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteUser(IDbContext dbContext, User[] userList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userList", userList);
		string text = "UnDeleteUser";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<User> list = new List<User>();
		foreach (User user in userList)
		{
			User user4Update = GetUser4Update(dbContext, user.Userid, user.Siteid);
			if (user4Update == null)
			{
				throw new EntityNotFoundException(typeof(User), $"{user.Userid},{user.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(User), $"{user.Userid},{user.Siteid}", user4Update.Isusable);
			user4Update.Isusable = "Usable";
			user.CopyCommonFieldUpdatePrev(user4Update, systemTime, dbContext.Tid, text);
			user.CopyExtensionCollection(user4Update);
			list.Add(user4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteUser(IDbContext dbContext, User[] userList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userList", userList);
		string text = "RealDeleteUser";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<User> list = new List<User>();
		foreach (User user in userList)
		{
			User user4Update = GetUser4Update(dbContext, user.Userid, user.Siteid);
			if (user4Update == null)
			{
				throw new EntityNotFoundException(typeof(User), $"{user.Userid},{user.Siteid}");
			}
			user.CopyCommonFieldUpdatePrev(user4Update, systemTime, dbContext.Tid, text);
			user.CopyExtensionCollection(user4Update);
			list.Add(user4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static bool VerifyPassword(IDbContext dbContext, string userId, string siteid, string plainTextPassword)
	{
		string apiName = "VerifyPassword";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userId},{siteid},{plainTextPassword}");
		}
		User user;
		if ((user = SelectUser(dbContext, userId, siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(User), userId);
		}
		return plainTextPassword == user.Password;
	}
}
