using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.POS;

[MESAPI]
public class LOGIN
{
	private static string _sqlGetLoginSqlDatabase = "SELECT * FROM CIM_LOGIN WHERE USERID=@USERID AND LOGINSYSTEM=@LOGINSYSTEM AND SITEID=@SITEID";

	private static string _sqlGetLogin4UpdateSqlDatabase = "SELECT * FROM CIM_LOGIN WITH(UPDLOCK) WHERE USERID=@USERID AND LOGINSYSTEM=@LOGINSYSTEM AND SITEID=@SITEID";

	private static string _sqlSelectLoginSqlDatabase = "SELECT * FROM CIM_LOGIN WHERE USERID=@USERID AND LOGINSYSTEM=@LOGINSYSTEM AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLogin4UpdateSqlDatabase = "SELECT * FROM CIM_LOGIN WITH(UPDLOCK) WHERE USERID=@USERID AND LOGINSYSTEM=@LOGINSYSTEM AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetLoginOracleDatabase = "SELECT * FROM CIM_LOGIN WHERE USERID=:USERID AND LOGINSYSTEM=:LOGINSYSTEM AND SITEID=:SITEID";

	private static string _sqlGetLogin4UpdateOracleDatabase = "SELECT * FROM CIM_LOGIN WHERE USERID=:USERID AND LOGINSYSTEM=:LOGINSYSTEM AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectLoginOracleDatabase = "SELECT * FROM CIM_LOGIN WHERE USERID=:USERID AND LOGINSYSTEM=:LOGINSYSTEM AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLogin4UpdateOracleDatabase = "SELECT * FROM CIM_LOGIN WHERE USERID=:USERID AND LOGINSYSTEM=:LOGINSYSTEM AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Login);

	public static Login GetLogin(IDbContext dbContext, string userid, string loginsystem, string siteid)
	{
		string apiName = "GetLogin";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userid},{loginsystem},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLoginSqlDatabase : _sqlGetLoginOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("LOGINSYSTEM", loginsystem, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOGIN", $"{userid},{loginsystem},{siteid}"));
		}
		Login? result = ContextManager.DirectEntityQuery<Login>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userid},{loginsystem},{siteid}");
		}
		return result;
	}

	public static Login GetLogin4Update(IDbContext dbContext, string userid, string loginsystem, string siteid)
	{
		string apiName = "GetLogin4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userid},{loginsystem},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLogin4UpdateSqlDatabase : _sqlGetLogin4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("LOGINSYSTEM", loginsystem, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_LOGIN", $"{userid},{loginsystem},{siteid}"));
		}
		Login? result = ContextManager.DirectEntityQuery<Login>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userid},{loginsystem},{siteid}");
		}
		return result;
	}

	public static Login SelectLogin(IDbContext dbContext, string userid, string loginsystem, string siteid)
	{
		string apiName = "SelectLogin";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userid},{loginsystem},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLoginSqlDatabase : _sqlSelectLoginOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("LOGINSYSTEM", loginsystem, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOGIN", $"{userid},{loginsystem},{siteid}"));
		}
		Login? result = ContextManager.DirectEntityQuery<Login>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userid},{loginsystem},{siteid}");
		}
		return result;
	}

	public static Login SelectLogin4Update(IDbContext dbContext, string userid, string loginsystem, string siteid)
	{
		string apiName = "SelectLogin4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userid},{loginsystem},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLogin4UpdateSqlDatabase : _sqlSelectLogin4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERID", userid, typeOfThis));
		list.Add(dbContext.CreateParameter("LOGINSYSTEM", loginsystem, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_LOGIN", $"{userid},{loginsystem},{siteid}"));
		}
		Login? result = ContextManager.DirectEntityQuery<Login>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userid},{loginsystem},{siteid}");
		}
		return result;
	}

	public static int UpsertLogin(IDbContext dbContext, RequestType requestType, Login[] loginList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateLoginInternal(dbContext, loginList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateLogin(dbContext, loginList, optionSet, saveHist), 
			RequestType.DELETE => DeleteLogin(dbContext, loginList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteLogin(dbContext, loginList, optionSet, saveHist), 
			_ => RealDeleteLogin(dbContext, loginList, optionSet, saveHist), 
		};
	}

	private static int CreateLoginInternal(IDbContext dbContext, Login[] loginList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("loginList", loginList);
		string text = "CreateLogin";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Login> list = new List<Login>();
		foreach (Login obj in loginList)
		{
			Login login = new Login();
			obj.CopyColumsTo(login);
			login.Activity = text;
			login.CheckEntityUsable();
			obj.CopyCommonField(login, systemTime, dbContext.Tid, isCreate: true);
			list.Add(login);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateLogin(IDbContext dbContext, Login[] loginList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("loginList", loginList);
		string text = "UpdateLogin";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Login> list = new List<Login>();
		foreach (Login login in loginList)
		{
			Login login4Update = GetLogin4Update(dbContext, login.Userid, login.Loginsystem, login.Siteid);
			if (login4Update == null)
			{
				throw new EntityNotFoundException(typeof(Login), $"{login.Userid},{login.Loginsystem},{login.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Login), $"{login.Userid},{login.Loginsystem},{login.Siteid}", login4Update.Isusable);
			string activity = login4Update.Activity;
			string customactivity = login4Update.Customactivity;
			string isusable = login4Update.Isusable;
			DateTime? createtime = login4Update.Createtime;
			string creator = login4Update.Creator;
			login.CopyColumsTo(login4Update);
			login4Update.Prevactivity = activity;
			login4Update.Prevcustomactivity = customactivity;
			login4Update.Creator = creator;
			login4Update.Createtime = createtime;
			login4Update.Isusable = isusable;
			login4Update.Activity = text;
			login.CopyCommonField(login4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(login4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteLogin(IDbContext dbContext, Login[] loginList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("loginList", loginList);
		string text = "DeleteLogin";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Login> list = new List<Login>();
		foreach (Login login in loginList)
		{
			Login login4Update = GetLogin4Update(dbContext, login.Userid, login.Loginsystem, login.Siteid);
			if (login4Update == null)
			{
				throw new EntityNotFoundException(typeof(Login), $"{login.Userid},{login.Loginsystem},{login.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Login), $"{login.Userid},{login.Loginsystem},{login.Siteid}", login4Update.Isusable);
			login4Update.Isusable = "UnUsable";
			login.CopyCommonFieldUpdatePrev(login4Update, systemTime, dbContext.Tid, text);
			login.CopyExtensionCollection(login4Update);
			list.Add(login4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteLogin(IDbContext dbContext, Login[] loginList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("loginList", loginList);
		string text = "UnDeleteLogin";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Login> list = new List<Login>();
		foreach (Login login in loginList)
		{
			Login login4Update = GetLogin4Update(dbContext, login.Userid, login.Loginsystem, login.Siteid);
			if (login4Update == null)
			{
				throw new EntityNotFoundException(typeof(Login), $"{login.Userid},{login.Loginsystem},{login.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Login), $"{login.Userid},{login.Loginsystem},{login.Siteid}", login4Update.Isusable);
			login4Update.Isusable = "Usable";
			login.CopyCommonFieldUpdatePrev(login4Update, systemTime, dbContext.Tid, text);
			login.CopyExtensionCollection(login4Update);
			list.Add(login4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteLogin(IDbContext dbContext, Login[] loginList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("loginList", loginList);
		string text = "RealDeleteLogin";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Login> list = new List<Login>();
		foreach (Login login in loginList)
		{
			Login login4Update = GetLogin4Update(dbContext, login.Userid, login.Loginsystem, login.Siteid);
			if (login4Update == null)
			{
				throw new EntityNotFoundException(typeof(Login), $"{login.Userid},{login.Loginsystem},{login.Siteid}");
			}
			login.CopyCommonFieldUpdatePrev(login4Update, systemTime, dbContext.Tid, text);
			login.CopyExtensionCollection(login4Update);
			list.Add(login4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static (string code, string[] parameter, bool result) UserLogin(IDbContext dbContext, User inuser, string loginSystem, string ipaddress, bool saveUserHist, bool saveLoginHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("user", inuser);
		string apiName = "UserLogin";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(apiName));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<User> list = new List<User>();
		string item = string.Empty;
		string[] item2 = new string[0];
		bool flag = true;
		ParamChecker.ArgumentNotNull("userid", inuser.Userid);
		ParamChecker.ArgumentNotNull("password", inuser.Password);
		ParamChecker.ArgumentNotNull("siteid", inuser.Siteid);
		ParamChecker.ArgumentNotNull("loginSystem", loginSystem);
		User user = new User
		{
			Userid = inuser.Userid,
			Password = inuser.Password,
			Siteid = inuser.Siteid
		};
		Login source = new Login
		{
			Userid = inuser.Userid,
			Siteid = inuser.Siteid,
			Loginsystem = loginSystem,
			Ipaddress = ipaddress
		};
		User user2;
		if ((user2 = USER.SelectUser4Update(dbContext, user.Userid, user.Siteid)) == null)
		{
			throw new EntityNotFoundException(typeof(User), $"{user.Userid},{user.Siteid}");
		}
		Loginpolicy loginpolicy = LOGINPOLICY.SelectPrimaryLoginPolicy(dbContext, user.Siteid);
		if (loginpolicy == null)
		{
			throw new EntityNotFoundException(typeof(Loginpolicy), user.Siteid);
		}
		if (user2.Passworduseflag != "Y")
		{
			throw new LoginDeniedException(user.Userid);
		}
		if (user.Password == user2.Password)
		{
			Login login = new Login();
			source.CopySameColumnsTo(login, copyExtensionCollection: false);
			login.Userid = user.Userid;
			login.Loginsystem = loginSystem;
			login.Macaddress = string.Empty;
			login.Ipaddress = ipaddress;
			login.Siteid = user.Siteid;
			login.Pcname = string.Empty;
			login.Loginretrycount = 0;
			Login login4Update;
			if ((login4Update = GetLogin4Update(dbContext, user.Userid, loginSystem, user.Siteid)) != null)
			{
				num += UpsertLogin(dbContext, RequestType.REALDELETE, new Login[1] { login4Update }, null, saveLoginHist);
			}
			num += UpsertLogin(dbContext, RequestType.CREATE, new Login[1] { login }, null, saveLoginHist);
			flag = true;
		}
		else
		{
			int value = 1;
			Login login4Update2;
			if ((login4Update2 = GetLogin4Update(dbContext, user.Userid, loginSystem, user.Siteid)) != null)
			{
				value = ((!login4Update2.Loginretrycount.HasValue) ? 1 : (login4Update2.Loginretrycount.Value + 1));
				num += UpsertLogin(dbContext, RequestType.REALDELETE, new Login[1] { login4Update2 }, null, saveLoginHist);
			}
			Login login2 = new Login();
			source.CopySameColumnsTo(login2, copyExtensionCollection: false);
			login2.Userid = user.Userid;
			login2.Loginsystem = loginSystem;
			login2.Macaddress = string.Empty;
			login2.Ipaddress = ipaddress;
			login2.Siteid = user.Siteid;
			login2.Pcname = string.Empty;
			login2.Loginretrycount = value;
			num += UpsertLogin(dbContext, RequestType.CREATE, new Login[1] { login2 }, null, saveLoginHist);
			flag = false;
			item = "MES-0154";
			item2 = new string[1] { user.Userid };
		}
		if (loginpolicy.Passwordchangeperiod.HasValue && loginpolicy.Passwordchangeperiod > 0 && user2.Passwordregisterdate.HasValue && user2.Passwordregisterdate.Value != DateTime.MinValue && !string.IsNullOrEmpty(loginpolicy.Passwordchangeunit))
		{
			decimal value2 = loginpolicy.Passwordchangeperiod.Value;
			DateTime value3 = user2.Passwordregisterdate.Value;
			int days = TimeHelper.GetPlusTime(EntityHelper.ConvertEnum(loginpolicy.Passwordchangeunit, TimeUnit.DAY), value3, value2).Subtract(systemTime).Days;
			if (days < 0)
			{
				item = "MES-0155";
				item2 = new string[1] { user.Userid };
				flag = false;
			}
			else if (days < 7)
			{
				item = "MES-0156";
				item2 = new string[2]
				{
					user.Userid,
					days.ToString()
				};
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveUserHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(apiName));
		return (code: item, parameter: item2, result: flag);
	}

	public static bool UserLogOut(IDbContext dbContext, string userId, string siteId, string loginSystem)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		string apiName = "UserLogout";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(apiName));
		ContextManager.GetSystemTime(dbContext);
		int num = 0;
		bool result = true;
		ParamChecker.ArgumentNotNull("userId", userId);
		ParamChecker.ArgumentNotNull("siteId", siteId);
		ParamChecker.ArgumentNotNull("loginSystem", loginSystem);
		Login login4Update;
		if ((login4Update = GetLogin4Update(dbContext, userId, loginSystem, siteId)) != null)
		{
			num += UpsertLogin(dbContext, RequestType.REALDELETE, new Login[1] { login4Update }, null, saveHist: true);
		}
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(apiName));
		return result;
	}
}
