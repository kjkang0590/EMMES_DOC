using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.QMS;

[MESAPI]
public class SPCITEMSPEC
{
	private static string _sqlGetSpcItemSpecSqlDatabase = "SELECT * FROM CIM_SPCITEMSPEC WHERE SPCITEMSPECSYSID=@SPCITEMSPECSYSID AND SITEID=@SITEID";

	private static string _sqlGetSpcItemSpec4UpdateSqlDatabase = "SELECT * FROM CIM_SPCITEMSPEC WITH(UPDLOCK) WHERE SPCITEMSPECSYSID=@SPCITEMSPECSYSID AND SITEID=@SITEID";

	private static string _sqlSelectSpcItemSpecSqlDatabase = "SELECT * FROM CIM_SPCITEMSPEC WHERE SPCITEMSPECSYSID=@SPCITEMSPECSYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectSpcItemSpec4UpdateSqlDatabase = "SELECT * FROM CIM_SPCITEMSPEC WITH(UPDLOCK) WHERE SPCITEMSPECSYSID=@SPCITEMSPECSYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetSpcItemSpecOracleDatabase = "SELECT * FROM CIM_SPCITEMSPEC WHERE SPCITEMSPECSYSID=:SPCITEMSPECSYSID AND SITEID=:SITEID";

	private static string _sqlGetSpcItemSpec4UpdateOracleDatabase = "SELECT * FROM CIM_SPCITEMSPEC WHERE SPCITEMSPECSYSID=:SPCITEMSPECSYSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectSpcItemSpecOracleDatabase = "SELECT * FROM CIM_SPCITEMSPEC WHERE SPCITEMSPECSYSID=:SPCITEMSPECSYSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectSpcItemSpec4UpdateOracleDatabase = "SELECT * FROM CIM_SPCITEMSPEC WHERE SPCITEMSPECSYSID=:SPCITEMSPECSYSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Spcitemspec);

	public static Spcitemspec GetSpcItemSpec(IDbContext dbContext, long spcitemspecsysid, string siteid)
	{
		string apiName = "GetSpcItemSpec";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{spcitemspecsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetSpcItemSpecSqlDatabase : _sqlGetSpcItemSpecOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SPCITEMSPECSYSID", spcitemspecsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SPCITEMSPEC", $"{spcitemspecsysid},{siteid}"));
		}
		Spcitemspec? result = ContextManager.DirectEntityQuery<Spcitemspec>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{spcitemspecsysid},{siteid}");
		}
		return result;
	}

	public static Spcitemspec GetSpcItemSpec4Update(IDbContext dbContext, long spcitemspecsysid, string siteid)
	{
		string apiName = "GetSpcItemSpec4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{spcitemspecsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetSpcItemSpec4UpdateSqlDatabase : _sqlGetSpcItemSpec4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SPCITEMSPECSYSID", spcitemspecsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_SPCITEMSPEC", $"{spcitemspecsysid},{siteid}"));
		}
		Spcitemspec? result = ContextManager.DirectEntityQuery<Spcitemspec>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{spcitemspecsysid},{siteid}");
		}
		return result;
	}

	public static Spcitemspec SelectSpcItemSpec(IDbContext dbContext, long spcitemspecsysid, string siteid)
	{
		string apiName = "SelectSpcItemSpec";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{spcitemspecsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectSpcItemSpecSqlDatabase : _sqlSelectSpcItemSpecOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SPCITEMSPECSYSID", spcitemspecsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SPCITEMSPEC", $"{spcitemspecsysid},{siteid}"));
		}
		Spcitemspec? result = ContextManager.DirectEntityQuery<Spcitemspec>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{spcitemspecsysid},{siteid}");
		}
		return result;
	}

	public static Spcitemspec SelectSpcItemSpec4Update(IDbContext dbContext, long spcitemspecsysid, string siteid)
	{
		string apiName = "SelectSpcItemSpec4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{spcitemspecsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectSpcItemSpec4UpdateSqlDatabase : _sqlSelectSpcItemSpec4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SPCITEMSPECSYSID", spcitemspecsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_SPCITEMSPEC", $"{spcitemspecsysid},{siteid}"));
		}
		Spcitemspec? result = ContextManager.DirectEntityQuery<Spcitemspec>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{spcitemspecsysid},{siteid}");
		}
		return result;
	}

	public static int UpsertSpcItemSpec(IDbContext dbContext, RequestType requestType, Spcitemspec[] spcItemSpecList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateSpcItemSpecInternal(dbContext, spcItemSpecList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateSpcItemSpec(dbContext, spcItemSpecList, optionSet, saveHist), 
			RequestType.DELETE => DeleteSpcItemSpec(dbContext, spcItemSpecList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteSpcItemSpec(dbContext, spcItemSpecList, optionSet, saveHist), 
			_ => RealDeleteSpcItemSpec(dbContext, spcItemSpecList, optionSet, saveHist), 
		};
	}

	private static int CreateSpcItemSpecInternal(IDbContext dbContext, Spcitemspec[] spcItemSpecList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spcItemSpecList", spcItemSpecList);
		string text = "CreateSpcItemSpec";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spcitemspec> list = new List<Spcitemspec>();
		foreach (Spcitemspec obj in spcItemSpecList)
		{
			Spcitemspec spcitemspec = new Spcitemspec();
			obj.CopyColumsTo(spcitemspec);
			spcitemspec.Activity = text;
			spcitemspec.CheckEntityUsable();
			obj.CopyCommonField(spcitemspec, systemTime, dbContext.Tid, isCreate: true);
			list.Add(spcitemspec);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateSpcItemSpec(IDbContext dbContext, Spcitemspec[] spcItemSpecList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spcItemSpecList", spcItemSpecList);
		string text = "UpdateSpcItemSpec";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spcitemspec> list = new List<Spcitemspec>();
		foreach (Spcitemspec spcitemspec in spcItemSpecList)
		{
			Spcitemspec spcItemSpec4Update = GetSpcItemSpec4Update(dbContext, spcitemspec.Spcitemspecsysid, spcitemspec.Siteid);
			if (spcItemSpec4Update == null)
			{
				throw new EntityNotFoundException(typeof(Spcitemspec), $"{spcitemspec.Spcitemspecsysid},{spcitemspec.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Spcitemspec), $"{spcitemspec.Spcitemspecsysid},{spcitemspec.Siteid}", spcItemSpec4Update.Isusable);
			string activity = spcItemSpec4Update.Activity;
			string customactivity = spcItemSpec4Update.Customactivity;
			string isusable = spcItemSpec4Update.Isusable;
			DateTime? createtime = spcItemSpec4Update.Createtime;
			string creator = spcItemSpec4Update.Creator;
			spcitemspec.CopyColumsTo(spcItemSpec4Update);
			spcItemSpec4Update.Prevactivity = activity;
			spcItemSpec4Update.Prevcustomactivity = customactivity;
			spcItemSpec4Update.Creator = creator;
			spcItemSpec4Update.Createtime = createtime;
			spcItemSpec4Update.Isusable = isusable;
			spcItemSpec4Update.Activity = text;
			spcitemspec.CopyCommonField(spcItemSpec4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(spcItemSpec4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteSpcItemSpec(IDbContext dbContext, Spcitemspec[] spcItemSpecList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spcItemSpecList", spcItemSpecList);
		string text = "DeleteSpcItemSpec";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spcitemspec> list = new List<Spcitemspec>();
		foreach (Spcitemspec spcitemspec in spcItemSpecList)
		{
			Spcitemspec spcItemSpec4Update = GetSpcItemSpec4Update(dbContext, spcitemspec.Spcitemspecsysid, spcitemspec.Siteid);
			if (spcItemSpec4Update == null)
			{
				throw new EntityNotFoundException(typeof(Spcitemspec), $"{spcitemspec.Spcitemspecsysid},{spcitemspec.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Spcitemspec), $"{spcitemspec.Spcitemspecsysid},{spcitemspec.Siteid}", spcItemSpec4Update.Isusable);
			spcItemSpec4Update.Isusable = "UnUsable";
			spcitemspec.CopyCommonFieldUpdatePrev(spcItemSpec4Update, systemTime, dbContext.Tid, text);
			spcitemspec.CopyExtensionCollection(spcItemSpec4Update);
			list.Add(spcItemSpec4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteSpcItemSpec(IDbContext dbContext, Spcitemspec[] spcItemSpecList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spcItemSpecList", spcItemSpecList);
		string text = "UnDeleteSpcItemSpec";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spcitemspec> list = new List<Spcitemspec>();
		foreach (Spcitemspec spcitemspec in spcItemSpecList)
		{
			Spcitemspec spcItemSpec4Update = GetSpcItemSpec4Update(dbContext, spcitemspec.Spcitemspecsysid, spcitemspec.Siteid);
			if (spcItemSpec4Update == null)
			{
				throw new EntityNotFoundException(typeof(Spcitemspec), $"{spcitemspec.Spcitemspecsysid},{spcitemspec.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Spcitemspec), $"{spcitemspec.Spcitemspecsysid},{spcitemspec.Siteid}", spcItemSpec4Update.Isusable);
			spcItemSpec4Update.Isusable = "Usable";
			spcitemspec.CopyCommonFieldUpdatePrev(spcItemSpec4Update, systemTime, dbContext.Tid, text);
			spcitemspec.CopyExtensionCollection(spcItemSpec4Update);
			list.Add(spcItemSpec4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteSpcItemSpec(IDbContext dbContext, Spcitemspec[] spcItemSpecList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spcItemSpecList", spcItemSpecList);
		string text = "RealDeleteSpcItemSpec";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spcitemspec> list = new List<Spcitemspec>();
		foreach (Spcitemspec spcitemspec in spcItemSpecList)
		{
			Spcitemspec spcItemSpec4Update = GetSpcItemSpec4Update(dbContext, spcitemspec.Spcitemspecsysid, spcitemspec.Siteid);
			if (spcItemSpec4Update == null)
			{
				throw new EntityNotFoundException(typeof(Spcitemspec), $"{spcitemspec.Spcitemspecsysid},{spcitemspec.Siteid}");
			}
			spcitemspec.CopyCommonFieldUpdatePrev(spcItemSpec4Update, systemTime, dbContext.Tid, text);
			spcitemspec.CopyExtensionCollection(spcItemSpec4Update);
			list.Add(spcItemSpec4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
