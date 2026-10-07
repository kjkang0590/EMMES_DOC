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
public class SPCDATARESULT
{
	private static string _sqlGetSpcDataResultSqlDatabase = "SELECT * FROM CIM_SPCDATARESULT WHERE SPCDATARESULTSYSID=@SPCDATARESULTSYSID AND SITEID=@SITEID";

	private static string _sqlGetSpcDataResult4UpdateSqlDatabase = "SELECT * FROM CIM_SPCDATARESULT WITH(UPDLOCK) WHERE SPCDATARESULTSYSID=@SPCDATARESULTSYSID AND SITEID=@SITEID";

	private static string _sqlSelectSpcDataResultSqlDatabase = "SELECT * FROM CIM_SPCDATARESULT WHERE SPCDATARESULTSYSID=@SPCDATARESULTSYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectSpcDataResult4UpdateSqlDatabase = "SELECT * FROM CIM_SPCDATARESULT WITH(UPDLOCK) WHERE SPCDATARESULTSYSID=@SPCDATARESULTSYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetSpcDataResultOracleDatabase = "SELECT * FROM CIM_SPCDATARESULT WHERE SPCDATARESULTSYSID=:SPCDATARESULTSYSID AND SITEID=:SITEID";

	private static string _sqlGetSpcDataResult4UpdateOracleDatabase = "SELECT * FROM CIM_SPCDATARESULT WHERE SPCDATARESULTSYSID=:SPCDATARESULTSYSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectSpcDataResultOracleDatabase = "SELECT * FROM CIM_SPCDATARESULT WHERE SPCDATARESULTSYSID=:SPCDATARESULTSYSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectSpcDataResult4UpdateOracleDatabase = "SELECT * FROM CIM_SPCDATARESULT WHERE SPCDATARESULTSYSID=:SPCDATARESULTSYSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Spcdataresult);

	public static Spcdataresult GetSpcDataResult(IDbContext dbContext, long spcdataresultsysid, string siteid)
	{
		string apiName = "GetSpcDataResult";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{spcdataresultsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetSpcDataResultSqlDatabase : _sqlGetSpcDataResultOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SPCDATARESULTSYSID", spcdataresultsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SPCDATARESULT", $"{spcdataresultsysid},{siteid}"));
		}
		Spcdataresult? result = ContextManager.DirectEntityQuery<Spcdataresult>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{spcdataresultsysid},{siteid}");
		}
		return result;
	}

	public static Spcdataresult GetSpcDataResult4Update(IDbContext dbContext, long spcdataresultsysid, string siteid)
	{
		string apiName = "GetSpcDataResult4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{spcdataresultsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetSpcDataResult4UpdateSqlDatabase : _sqlGetSpcDataResult4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SPCDATARESULTSYSID", spcdataresultsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_SPCDATARESULT", $"{spcdataresultsysid},{siteid}"));
		}
		Spcdataresult? result = ContextManager.DirectEntityQuery<Spcdataresult>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{spcdataresultsysid},{siteid}");
		}
		return result;
	}

	public static Spcdataresult SelectSpcDataResult(IDbContext dbContext, long spcdataresultsysid, string siteid)
	{
		string apiName = "SelectSpcDataResult";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{spcdataresultsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectSpcDataResultSqlDatabase : _sqlSelectSpcDataResultOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SPCDATARESULTSYSID", spcdataresultsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SPCDATARESULT", $"{spcdataresultsysid},{siteid}"));
		}
		Spcdataresult? result = ContextManager.DirectEntityQuery<Spcdataresult>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{spcdataresultsysid},{siteid}");
		}
		return result;
	}

	public static Spcdataresult SelectSpcDataResult4Update(IDbContext dbContext, long spcdataresultsysid, string siteid)
	{
		string apiName = "SelectSpcDataResult4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{spcdataresultsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectSpcDataResult4UpdateSqlDatabase : _sqlSelectSpcDataResult4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SPCDATARESULTSYSID", spcdataresultsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_SPCDATARESULT", $"{spcdataresultsysid},{siteid}"));
		}
		Spcdataresult? result = ContextManager.DirectEntityQuery<Spcdataresult>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{spcdataresultsysid},{siteid}");
		}
		return result;
	}

	public static int UpsertSpcDataResult(IDbContext dbContext, RequestType requestType, Spcdataresult[] spcDataResultList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateSpcDataResultInternal(dbContext, spcDataResultList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateSpcDataResult(dbContext, spcDataResultList, optionSet, saveHist), 
			RequestType.DELETE => DeleteSpcDataResult(dbContext, spcDataResultList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteSpcDataResult(dbContext, spcDataResultList, optionSet, saveHist), 
			_ => RealDeleteSpcDataResult(dbContext, spcDataResultList, optionSet, saveHist), 
		};
	}

	private static int CreateSpcDataResultInternal(IDbContext dbContext, Spcdataresult[] spcDataResultList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spcDataResultList", spcDataResultList);
		string text = "CreateSpcDataResult";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spcdataresult> list = new List<Spcdataresult>();
		foreach (Spcdataresult obj in spcDataResultList)
		{
			Spcdataresult spcdataresult = new Spcdataresult();
			obj.CopyColumsTo(spcdataresult);
			spcdataresult.Activity = text;
			spcdataresult.CheckEntityUsable();
			obj.CopyCommonField(spcdataresult, systemTime, dbContext.Tid, isCreate: true);
			list.Add(spcdataresult);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateSpcDataResult(IDbContext dbContext, Spcdataresult[] spcDataResultList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spcDataResultList", spcDataResultList);
		string text = "UpdateSpcDataResult";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spcdataresult> list = new List<Spcdataresult>();
		foreach (Spcdataresult spcdataresult in spcDataResultList)
		{
			Spcdataresult spcDataResult4Update = GetSpcDataResult4Update(dbContext, spcdataresult.Spcdataresultsysid, spcdataresult.Siteid);
			if (spcDataResult4Update == null)
			{
				throw new EntityNotFoundException(typeof(Spcdataresult), $"{spcdataresult.Spcdataresultsysid},{spcdataresult.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Spcdataresult), $"{spcdataresult.Spcdataresultsysid},{spcdataresult.Siteid}", spcDataResult4Update.Isusable);
			string activity = spcDataResult4Update.Activity;
			string customactivity = spcDataResult4Update.Customactivity;
			string isusable = spcDataResult4Update.Isusable;
			DateTime? createtime = spcDataResult4Update.Createtime;
			string creator = spcDataResult4Update.Creator;
			spcdataresult.CopyColumsTo(spcDataResult4Update);
			spcDataResult4Update.Prevactivity = activity;
			spcDataResult4Update.Prevcustomactivity = customactivity;
			spcDataResult4Update.Creator = creator;
			spcDataResult4Update.Createtime = createtime;
			spcDataResult4Update.Isusable = isusable;
			spcDataResult4Update.Activity = text;
			spcdataresult.CopyCommonField(spcDataResult4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(spcDataResult4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteSpcDataResult(IDbContext dbContext, Spcdataresult[] spcDataResultList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spcDataResultList", spcDataResultList);
		string text = "DeleteSpcDataResult";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spcdataresult> list = new List<Spcdataresult>();
		foreach (Spcdataresult spcdataresult in spcDataResultList)
		{
			Spcdataresult spcDataResult4Update = GetSpcDataResult4Update(dbContext, spcdataresult.Spcdataresultsysid, spcdataresult.Siteid);
			if (spcDataResult4Update == null)
			{
				throw new EntityNotFoundException(typeof(Spcdataresult), $"{spcdataresult.Spcdataresultsysid},{spcdataresult.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Spcdataresult), $"{spcdataresult.Spcdataresultsysid},{spcdataresult.Siteid}", spcDataResult4Update.Isusable);
			spcDataResult4Update.Isusable = "UnUsable";
			spcdataresult.CopyCommonFieldUpdatePrev(spcDataResult4Update, systemTime, dbContext.Tid, text);
			spcdataresult.CopyExtensionCollection(spcDataResult4Update);
			list.Add(spcDataResult4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteSpcDataResult(IDbContext dbContext, Spcdataresult[] spcDataResultList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spcDataResultList", spcDataResultList);
		string text = "UnDeleteSpcDataResult";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spcdataresult> list = new List<Spcdataresult>();
		foreach (Spcdataresult spcdataresult in spcDataResultList)
		{
			Spcdataresult spcDataResult4Update = GetSpcDataResult4Update(dbContext, spcdataresult.Spcdataresultsysid, spcdataresult.Siteid);
			if (spcDataResult4Update == null)
			{
				throw new EntityNotFoundException(typeof(Spcdataresult), $"{spcdataresult.Spcdataresultsysid},{spcdataresult.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Spcdataresult), $"{spcdataresult.Spcdataresultsysid},{spcdataresult.Siteid}", spcDataResult4Update.Isusable);
			spcDataResult4Update.Isusable = "Usable";
			spcdataresult.CopyCommonFieldUpdatePrev(spcDataResult4Update, systemTime, dbContext.Tid, text);
			spcdataresult.CopyExtensionCollection(spcDataResult4Update);
			list.Add(spcDataResult4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteSpcDataResult(IDbContext dbContext, Spcdataresult[] spcDataResultList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spcDataResultList", spcDataResultList);
		string text = "RealDeleteSpcDataResult";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spcdataresult> list = new List<Spcdataresult>();
		foreach (Spcdataresult spcdataresult in spcDataResultList)
		{
			Spcdataresult spcDataResult4Update = GetSpcDataResult4Update(dbContext, spcdataresult.Spcdataresultsysid, spcdataresult.Siteid);
			if (spcDataResult4Update == null)
			{
				throw new EntityNotFoundException(typeof(Spcdataresult), $"{spcdataresult.Spcdataresultsysid},{spcdataresult.Siteid}");
			}
			spcdataresult.CopyCommonFieldUpdatePrev(spcDataResult4Update, systemTime, dbContext.Tid, text);
			spcdataresult.CopyExtensionCollection(spcDataResult4Update);
			list.Add(spcDataResult4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
