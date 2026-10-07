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
public class USERCLASSPPSEREL
{
	private static string _sqlGetUserClassPPSERelSqlDatabase = "SELECT * FROM CIM_USERCLASSPPSEREL WHERE USERCLASSID=@USERCLASSID AND PROCESSSEGMENTID=@PROCESSSEGMENTID AND EQUIPMENTID=@EQUIPMENTID AND SITEID=@SITEID";

	private static string _sqlGetUserClassPPSERel4UpdateSqlDatabase = "SELECT * FROM CIM_USERCLASSPPSEREL WITH(UPDLOCK) WHERE USERCLASSID=@USERCLASSID AND PROCESSSEGMENTID=@PROCESSSEGMENTID AND EQUIPMENTID=@EQUIPMENTID AND SITEID=@SITEID";

	private static string _sqlSelectUserClassPPSERelSqlDatabase = "SELECT * FROM CIM_USERCLASSPPSEREL WHERE USERCLASSID=@USERCLASSID AND PROCESSSEGMENTID=@PROCESSSEGMENTID AND EQUIPMENTID=@EQUIPMENTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectUserClassPPSERel4UpdateSqlDatabase = "SELECT * FROM CIM_USERCLASSPPSEREL WITH(UPDLOCK) WHERE USERCLASSID=@USERCLASSID AND PROCESSSEGMENTID=@PROCESSSEGMENTID AND EQUIPMENTID=@EQUIPMENTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetUserClassPPSERelOracleDatabase = "SELECT * FROM CIM_USERCLASSPPSEREL WHERE USERCLASSID=:USERCLASSID AND PROCESSSEGMENTID=:PROCESSSEGMENTID AND EQUIPMENTID=:EQUIPMENTID AND SITEID=:SITEID";

	private static string _sqlGetUserClassPPSERel4UpdateOracleDatabase = "SELECT * FROM CIM_USERCLASSPPSEREL WHERE USERCLASSID=:USERCLASSID AND PROCESSSEGMENTID=:PROCESSSEGMENTID AND EQUIPMENTID=:EQUIPMENTID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectUserClassPPSERelOracleDatabase = "SELECT * FROM CIM_USERCLASSPPSEREL WHERE USERCLASSID=:USERCLASSID AND PROCESSSEGMENTID=:PROCESSSEGMENTID AND EQUIPMENTID=:EQUIPMENTID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectUserClassPPSERel4UpdateOracleDatabase = "SELECT * FROM CIM_USERCLASSPPSEREL WHERE USERCLASSID=:USERCLASSID AND PROCESSSEGMENTID=:PROCESSSEGMENTID AND EQUIPMENTID=:EQUIPMENTID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Userclassppserel);

	public static Userclassppserel GetUserClassPPSERel(IDbContext dbContext, string userclassid, string processsegmentid, string equipmentid, string siteid)
	{
		string apiName = "GetUserClassPPSERel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userclassid},{processsegmentid},{equipmentid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetUserClassPPSERelSqlDatabase : _sqlGetUserClassPPSERelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERCLASSID", userclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_USERCLASSPPSEREL", $"{userclassid},{processsegmentid},{equipmentid},{siteid}"));
		}
		Userclassppserel result = ContextManager.DirectEntityQuery<Userclassppserel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userclassid},{processsegmentid},{equipmentid},{siteid}");
		}
		return result;
	}

	public static Userclassppserel GetUserClassPPSERel4Update(IDbContext dbContext, string userclassid, string processsegmentid, string equipmentid, string siteid)
	{
		string apiName = "GetUserClassPPSERel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userclassid},{processsegmentid},{equipmentid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetUserClassPPSERel4UpdateSqlDatabase : _sqlGetUserClassPPSERel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERCLASSID", userclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_USERCLASSPPSEREL", $"{userclassid},{processsegmentid},{equipmentid},{siteid}"));
		}
		Userclassppserel result = ContextManager.DirectEntityQuery<Userclassppserel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userclassid},{processsegmentid},{equipmentid},{siteid}");
		}
		return result;
	}

	public static Userclassppserel SelectUserClassPPSERel(IDbContext dbContext, string userclassid, string processsegmentid, string equipmentid, string siteid)
	{
		string apiName = "SelectUserClassPPSERel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userclassid},{processsegmentid},{equipmentid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectUserClassPPSERelSqlDatabase : _sqlSelectUserClassPPSERelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERCLASSID", userclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_USERCLASSPPSEREL", $"{userclassid},{processsegmentid},{equipmentid},{siteid}"));
		}
		Userclassppserel result = ContextManager.DirectEntityQuery<Userclassppserel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userclassid},{processsegmentid},{equipmentid},{siteid}");
		}
		return result;
	}

	public static Userclassppserel SelectUserClassPPSERel4Update(IDbContext dbContext, string userclassid, string processsegmentid, string equipmentid, string siteid)
	{
		string apiName = "SelectUserClassPPSERel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{userclassid},{processsegmentid},{equipmentid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectUserClassPPSERel4UpdateSqlDatabase : _sqlSelectUserClassPPSERel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("USERCLASSID", userclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_USERCLASSPPSEREL", $"{userclassid},{processsegmentid},{equipmentid},{siteid}"));
		}
		Userclassppserel result = ContextManager.DirectEntityQuery<Userclassppserel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{userclassid},{processsegmentid},{equipmentid},{siteid}");
		}
		return result;
	}

	public static int UpsertUserClassPPSERel(IDbContext dbContext, RequestType requestType, Userclassppserel[] userClassPPSERelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateUserClassPPSERelInternal(dbContext, userClassPPSERelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateUserClassPPSERel(dbContext, userClassPPSERelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteUserClassPPSERel(dbContext, userClassPPSERelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteUserClassPPSERel(dbContext, userClassPPSERelList, optionSet, saveHist), 
			_ => RealDeleteUserClassPPSERel(dbContext, userClassPPSERelList, optionSet, saveHist), 
		};
	}

	private static int CreateUserClassPPSERelInternal(IDbContext dbContext, Userclassppserel[] userClassPPSERelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userClassPPSERelList", userClassPPSERelList);
		string text = "CreateUserClassPPSERel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userclassppserel> list = new List<Userclassppserel>();
		foreach (Userclassppserel obj in userClassPPSERelList)
		{
			Userclassppserel userclassppserel = new Userclassppserel();
			obj.CopyColumsTo(userclassppserel);
			userclassppserel.Activity = text;
			userclassppserel.CheckEntityUsable();
			obj.CopyCommonField(userclassppserel, systemTime, dbContext.Tid, isCreate: true);
			list.Add(userclassppserel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateUserClassPPSERel(IDbContext dbContext, Userclassppserel[] userClassPPSERelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userClassPPSERelList", userClassPPSERelList);
		string text = "UpdateUserClassPPSERel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userclassppserel> list = new List<Userclassppserel>();
		foreach (Userclassppserel userclassppserel in userClassPPSERelList)
		{
			Userclassppserel userClassPPSERel4Update = GetUserClassPPSERel4Update(dbContext, userclassppserel.Userclassid, userclassppserel.Processsegmentid, userclassppserel.Equipmentid, userclassppserel.Siteid);
			if (userClassPPSERel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Userclassppserel), $"{userclassppserel.Userclassid},{userclassppserel.Processsegmentid},{userclassppserel.Equipmentid},{userclassppserel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Userclassppserel), $"{userclassppserel.Userclassid},{userclassppserel.Processsegmentid},{userclassppserel.Equipmentid},{userclassppserel.Siteid}", userClassPPSERel4Update.Isusable);
			string activity = userClassPPSERel4Update.Activity;
			string customactivity = userClassPPSERel4Update.Customactivity;
			string isusable = userClassPPSERel4Update.Isusable;
			DateTime? createtime = userClassPPSERel4Update.Createtime;
			string creator = userClassPPSERel4Update.Creator;
			userclassppserel.CopyColumsTo(userClassPPSERel4Update);
			userClassPPSERel4Update.Prevactivity = activity;
			userClassPPSERel4Update.Prevcustomactivity = customactivity;
			userClassPPSERel4Update.Creator = creator;
			userClassPPSERel4Update.Createtime = createtime;
			userClassPPSERel4Update.Isusable = isusable;
			userClassPPSERel4Update.Activity = text;
			userclassppserel.CopyCommonField(userClassPPSERel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(userClassPPSERel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteUserClassPPSERel(IDbContext dbContext, Userclassppserel[] userClassPPSERelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userClassPPSERelList", userClassPPSERelList);
		string text = "DeleteUserClassPPSERel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userclassppserel> list = new List<Userclassppserel>();
		foreach (Userclassppserel userclassppserel in userClassPPSERelList)
		{
			Userclassppserel userClassPPSERel4Update = GetUserClassPPSERel4Update(dbContext, userclassppserel.Userclassid, userclassppserel.Processsegmentid, userclassppserel.Equipmentid, userclassppserel.Siteid);
			if (userClassPPSERel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Userclassppserel), $"{userclassppserel.Userclassid},{userclassppserel.Processsegmentid},{userclassppserel.Equipmentid},{userclassppserel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Userclassppserel), $"{userclassppserel.Userclassid},{userclassppserel.Processsegmentid},{userclassppserel.Equipmentid},{userclassppserel.Siteid}", userClassPPSERel4Update.Isusable);
			userClassPPSERel4Update.Isusable = "UnUsable";
			userclassppserel.CopyCommonFieldUpdatePrev(userClassPPSERel4Update, systemTime, dbContext.Tid, text);
			userclassppserel.CopyExtensionCollection(userClassPPSERel4Update);
			list.Add(userClassPPSERel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteUserClassPPSERel(IDbContext dbContext, Userclassppserel[] userClassPPSERelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userClassPPSERelList", userClassPPSERelList);
		string text = "UnDeleteUserClassPPSERel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userclassppserel> list = new List<Userclassppserel>();
		foreach (Userclassppserel userclassppserel in userClassPPSERelList)
		{
			Userclassppserel userClassPPSERel4Update = GetUserClassPPSERel4Update(dbContext, userclassppserel.Userclassid, userclassppserel.Processsegmentid, userclassppserel.Equipmentid, userclassppserel.Siteid);
			if (userClassPPSERel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Userclassppserel), $"{userclassppserel.Userclassid},{userclassppserel.Processsegmentid},{userclassppserel.Equipmentid},{userclassppserel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Userclassppserel), $"{userclassppserel.Userclassid},{userclassppserel.Processsegmentid},{userclassppserel.Equipmentid},{userclassppserel.Siteid}", userClassPPSERel4Update.Isusable);
			userClassPPSERel4Update.Isusable = "Usable";
			userclassppserel.CopyCommonFieldUpdatePrev(userClassPPSERel4Update, systemTime, dbContext.Tid, text);
			userclassppserel.CopyExtensionCollection(userClassPPSERel4Update);
			list.Add(userClassPPSERel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteUserClassPPSERel(IDbContext dbContext, Userclassppserel[] userClassPPSERelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("userClassPPSERelList", userClassPPSERelList);
		string text = "RealDeleteUserClassPPSERel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Userclassppserel> list = new List<Userclassppserel>();
		foreach (Userclassppserel userclassppserel in userClassPPSERelList)
		{
			Userclassppserel userClassPPSERel4Update = GetUserClassPPSERel4Update(dbContext, userclassppserel.Userclassid, userclassppserel.Processsegmentid, userclassppserel.Equipmentid, userclassppserel.Siteid);
			if (userClassPPSERel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Userclassppserel), $"{userclassppserel.Userclassid},{userclassppserel.Processsegmentid},{userclassppserel.Equipmentid},{userclassppserel.Siteid}");
			}
			userclassppserel.CopyCommonFieldUpdatePrev(userClassPPSERel4Update, systemTime, dbContext.Tid, text);
			userclassppserel.CopyExtensionCollection(userClassPPSERel4Update);
			list.Add(userClassPPSERel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
