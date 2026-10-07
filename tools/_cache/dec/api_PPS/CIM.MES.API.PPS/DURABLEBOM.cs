using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.PPS;

[MESAPI]
public class DURABLEBOM
{
	private static string _sqlGetDurableBomSqlDatabase = "SELECT * FROM CIM_DURABLEBOM WHERE BOMID=@BOMID AND SITEID=@SITEID";

	private static string _sqlGetDurableBom4UpdateSqlDatabase = "SELECT * FROM CIM_DURABLEBOM WITH(UPDLOCK) WHERE BOMID=@BOMID AND SITEID=@SITEID";

	private static string _sqlSelectDurableBomSqlDatabase = "SELECT * FROM CIM_DURABLEBOM WHERE BOMID=@BOMID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectDurableBom4UpdateSqlDatabase = "SELECT * FROM CIM_DURABLEBOM WITH(UPDLOCK) WHERE BOMID=@BOMID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetDurableBomOracleDatabase = "SELECT * FROM CIM_DURABLEBOM WHERE BOMID=:BOMID AND SITEID=:SITEID";

	private static string _sqlGetDurableBom4UpdateOracleDatabase = "SELECT * FROM CIM_DURABLEBOM WHERE BOMID=:BOMID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectDurableBomOracleDatabase = "SELECT * FROM CIM_DURABLEBOM WHERE BOMID=:BOMID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectDurableBom4UpdateOracleDatabase = "SELECT * FROM CIM_DURABLEBOM WHERE BOMID=:BOMID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Durablebom);

	public static Durablebom GetDurableBom(IDbContext dbContext, string bomid, string siteid)
	{
		string apiName = "GetDurableBom";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{bomid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetDurableBomSqlDatabase : _sqlGetDurableBomOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("BOMID", bomid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_DURABLEBOM", $"{bomid},{siteid}"));
		}
		Durablebom? result = ContextManager.DirectEntityQuery<Durablebom>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{bomid},{siteid}");
		}
		return result;
	}

	public static Durablebom GetDurableBom4Update(IDbContext dbContext, string bomid, string siteid)
	{
		string apiName = "GetDurableBom4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{bomid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetDurableBom4UpdateSqlDatabase : _sqlGetDurableBom4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("BOMID", bomid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_DURABLEBOM", $"{bomid},{siteid}"));
		}
		Durablebom? result = ContextManager.DirectEntityQuery<Durablebom>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{bomid},{siteid}");
		}
		return result;
	}

	public static Durablebom SelectDurableBom(IDbContext dbContext, string bomid, string siteid)
	{
		string apiName = "SelectDurableBom";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{bomid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectDurableBomSqlDatabase : _sqlSelectDurableBomOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("BOMID", bomid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_DURABLEBOM", $"{bomid},{siteid}"));
		}
		Durablebom? result = ContextManager.DirectEntityQuery<Durablebom>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{bomid},{siteid}");
		}
		return result;
	}

	public static Durablebom SelectDurableBom4Update(IDbContext dbContext, string bomid, string siteid)
	{
		string apiName = "SelectDurableBom4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{bomid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectDurableBom4UpdateSqlDatabase : _sqlSelectDurableBom4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("BOMID", bomid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_DURABLEBOM", $"{bomid},{siteid}"));
		}
		Durablebom? result = ContextManager.DirectEntityQuery<Durablebom>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{bomid},{siteid}");
		}
		return result;
	}

	public static int UpsertDurableBom(IDbContext dbContext, RequestType requestType, Durablebom[] durableBomList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateDurableBomInternal(dbContext, durableBomList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateDurableBom(dbContext, durableBomList, optionSet, saveHist), 
			RequestType.DELETE => DeleteDurableBom(dbContext, durableBomList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteDurableBom(dbContext, durableBomList, optionSet, saveHist), 
			_ => RealDeleteDurableBom(dbContext, durableBomList, optionSet, saveHist), 
		};
	}

	private static int CreateDurableBomInternal(IDbContext dbContext, Durablebom[] durableBomList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("durableBomList", durableBomList);
		string text = "CreateDurableBom";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Durablebom> list = new List<Durablebom>();
		foreach (Durablebom obj in durableBomList)
		{
			Durablebom durablebom = new Durablebom();
			obj.CopyColumsTo(durablebom);
			durablebom.Activity = text;
			durablebom.CheckEntityUsable();
			obj.CopyCommonField(durablebom, systemTime, dbContext.Tid, isCreate: true);
			list.Add(durablebom);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateDurableBom(IDbContext dbContext, Durablebom[] durableBomList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("durableBomList", durableBomList);
		string text = "UpdateDurableBom";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Durablebom> list = new List<Durablebom>();
		foreach (Durablebom durablebom in durableBomList)
		{
			Durablebom durableBom4Update = GetDurableBom4Update(dbContext, durablebom.Bomid, durablebom.Siteid);
			if (durableBom4Update == null)
			{
				throw new EntityNotFoundException(typeof(Durablebom), $"{durablebom.Bomid},{durablebom.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Durablebom), $"{durablebom.Bomid},{durablebom.Siteid}", durableBom4Update.Isusable);
			string activity = durableBom4Update.Activity;
			string customactivity = durableBom4Update.Customactivity;
			string isusable = durableBom4Update.Isusable;
			DateTime? createtime = durableBom4Update.Createtime;
			string creator = durableBom4Update.Creator;
			durablebom.CopyColumsTo(durableBom4Update);
			durableBom4Update.Prevactivity = activity;
			durableBom4Update.Prevcustomactivity = customactivity;
			durableBom4Update.Creator = creator;
			durableBom4Update.Createtime = createtime;
			durableBom4Update.Isusable = isusable;
			durableBom4Update.Activity = text;
			durablebom.CopyCommonField(durableBom4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(durableBom4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteDurableBom(IDbContext dbContext, Durablebom[] durableBomList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("durableBomList", durableBomList);
		string text = "DeleteDurableBom";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Durablebom> list = new List<Durablebom>();
		foreach (Durablebom durablebom in durableBomList)
		{
			Durablebom durableBom4Update = GetDurableBom4Update(dbContext, durablebom.Bomid, durablebom.Siteid);
			if (durableBom4Update == null)
			{
				throw new EntityNotFoundException(typeof(Durablebom), $"{durablebom.Bomid},{durablebom.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Durablebom), $"{durablebom.Bomid},{durablebom.Siteid}", durableBom4Update.Isusable);
			durableBom4Update.Isusable = "UnUsable";
			durablebom.CopyCommonFieldUpdatePrev(durableBom4Update, systemTime, dbContext.Tid, text);
			durablebom.CopyExtensionCollection(durableBom4Update);
			list.Add(durableBom4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteDurableBom(IDbContext dbContext, Durablebom[] durableBomList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("durableBomList", durableBomList);
		string text = "UnDeleteDurableBom";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Durablebom> list = new List<Durablebom>();
		foreach (Durablebom durablebom in durableBomList)
		{
			Durablebom durableBom4Update = GetDurableBom4Update(dbContext, durablebom.Bomid, durablebom.Siteid);
			if (durableBom4Update == null)
			{
				throw new EntityNotFoundException(typeof(Durablebom), $"{durablebom.Bomid},{durablebom.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Durablebom), $"{durablebom.Bomid},{durablebom.Siteid}", durableBom4Update.Isusable);
			durableBom4Update.Isusable = "Usable";
			durablebom.CopyCommonFieldUpdatePrev(durableBom4Update, systemTime, dbContext.Tid, text);
			durablebom.CopyExtensionCollection(durableBom4Update);
			list.Add(durableBom4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteDurableBom(IDbContext dbContext, Durablebom[] durableBomList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("durableBomList", durableBomList);
		string text = "RealDeleteDurableBom";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Durablebom> list = new List<Durablebom>();
		foreach (Durablebom durablebom in durableBomList)
		{
			Durablebom durableBom4Update = GetDurableBom4Update(dbContext, durablebom.Bomid, durablebom.Siteid);
			if (durableBom4Update == null)
			{
				throw new EntityNotFoundException(typeof(Durablebom), $"{durablebom.Bomid},{durablebom.Siteid}");
			}
			durablebom.CopyCommonFieldUpdatePrev(durableBom4Update, systemTime, dbContext.Tid, text);
			durablebom.CopyExtensionCollection(durableBom4Update);
			list.Add(durableBom4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
