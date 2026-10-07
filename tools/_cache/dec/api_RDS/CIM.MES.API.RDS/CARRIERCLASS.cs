using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.RDS;

[MESAPI]
public class CARRIERCLASS
{
	private static string _sqlGetCarrierClassSqlDatabase = "SELECT * FROM CIM_CARRIERCLASS WHERE CARRIERCLASSID=@CARRIERCLASSID AND SITEID=@SITEID";

	private static string _sqlGetCarrierClass4UpdateSqlDatabase = "SELECT * FROM CIM_CARRIERCLASS WITH(UPDLOCK) WHERE CARRIERCLASSID=@CARRIERCLASSID AND SITEID=@SITEID";

	private static string _sqlSelectCarrierClassSqlDatabase = "SELECT * FROM CIM_CARRIERCLASS WHERE CARRIERCLASSID=@CARRIERCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectCarrierClass4UpdateSqlDatabase = "SELECT * FROM CIM_CARRIERCLASS WITH(UPDLOCK) WHERE CARRIERCLASSID=@CARRIERCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetCarrierClassOracleDatabase = "SELECT * FROM CIM_CARRIERCLASS WHERE CARRIERCLASSID=:CARRIERCLASSID AND SITEID=:SITEID";

	private static string _sqlGetCarrierClass4UpdateOracleDatabase = "SELECT * FROM CIM_CARRIERCLASS WHERE CARRIERCLASSID=:CARRIERCLASSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectCarrierClassOracleDatabase = "SELECT * FROM CIM_CARRIERCLASS WHERE CARRIERCLASSID=:CARRIERCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectCarrierClass4UpdateOracleDatabase = "SELECT * FROM CIM_CARRIERCLASS WHERE CARRIERCLASSID=:CARRIERCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Carrierclass);

	public static Carrierclass GetCarrierClass(IDbContext dbContext, string carrierclassid, string siteid)
	{
		string apiName = "GetCarrierClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{carrierclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetCarrierClassSqlDatabase : _sqlGetCarrierClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CARRIERCLASSID", carrierclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_CARRIERCLASS", $"{carrierclassid},{siteid}"));
		}
		Carrierclass? result = ContextManager.DirectEntityQuery<Carrierclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{carrierclassid},{siteid}");
		}
		return result;
	}

	public static Carrierclass GetCarrierClass4Update(IDbContext dbContext, string carrierclassid, string siteid)
	{
		string apiName = "GetCarrierClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{carrierclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetCarrierClass4UpdateSqlDatabase : _sqlGetCarrierClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CARRIERCLASSID", carrierclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_CARRIERCLASS", $"{carrierclassid},{siteid}"));
		}
		Carrierclass? result = ContextManager.DirectEntityQuery<Carrierclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{carrierclassid},{siteid}");
		}
		return result;
	}

	public static Carrierclass SelectCarrierClass(IDbContext dbContext, string carrierclassid, string siteid)
	{
		string apiName = "SelectCarrierClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{carrierclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectCarrierClassSqlDatabase : _sqlSelectCarrierClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CARRIERCLASSID", carrierclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_CARRIERCLASS", $"{carrierclassid},{siteid}"));
		}
		Carrierclass? result = ContextManager.DirectEntityQuery<Carrierclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{carrierclassid},{siteid}");
		}
		return result;
	}

	public static Carrierclass SelectCarrierClass4Update(IDbContext dbContext, string carrierclassid, string siteid)
	{
		string apiName = "SelectCarrierClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{carrierclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectCarrierClass4UpdateSqlDatabase : _sqlSelectCarrierClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CARRIERCLASSID", carrierclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_CARRIERCLASS", $"{carrierclassid},{siteid}"));
		}
		Carrierclass? result = ContextManager.DirectEntityQuery<Carrierclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{carrierclassid},{siteid}");
		}
		return result;
	}

	public static int UpsertCarrierClass(IDbContext dbContext, RequestType requestType, Carrierclass[] carrierClassList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateCarrierClassInternal(dbContext, carrierClassList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateCarrierClass(dbContext, carrierClassList, optionSet, saveHist), 
			RequestType.DELETE => DeleteCarrierClass(dbContext, carrierClassList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteCarrierClass(dbContext, carrierClassList, optionSet, saveHist), 
			_ => RealDeleteCarrierClass(dbContext, carrierClassList, optionSet, saveHist), 
		};
	}

	private static int CreateCarrierClassInternal(IDbContext dbContext, Carrierclass[] carrierClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("carrierClassList", carrierClassList);
		string text = "CreateCarrierClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Carrierclass> list = new List<Carrierclass>();
		foreach (Carrierclass obj in carrierClassList)
		{
			Carrierclass carrierclass = new Carrierclass();
			obj.CopyColumsTo(carrierclass);
			carrierclass.Activity = text;
			carrierclass.CheckEntityUsable();
			obj.CopyCommonField(carrierclass, systemTime, dbContext.Tid, isCreate: true);
			list.Add(carrierclass);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateCarrierClass(IDbContext dbContext, Carrierclass[] carrierClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("carrierClassList", carrierClassList);
		string text = "UpdateCarrierClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Carrierclass> list = new List<Carrierclass>();
		foreach (Carrierclass carrierclass in carrierClassList)
		{
			Carrierclass carrierClass4Update = GetCarrierClass4Update(dbContext, carrierclass.Carrierclassid, carrierclass.Siteid);
			if (carrierClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Carrierclass), $"{carrierclass.Carrierclassid},{carrierclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Carrierclass), $"{carrierclass.Carrierclassid},{carrierclass.Siteid}", carrierClass4Update.Isusable);
			string activity = carrierClass4Update.Activity;
			string customactivity = carrierClass4Update.Customactivity;
			string isusable = carrierClass4Update.Isusable;
			DateTime? createtime = carrierClass4Update.Createtime;
			string creator = carrierClass4Update.Creator;
			carrierclass.CopyColumsTo(carrierClass4Update);
			carrierClass4Update.Prevactivity = activity;
			carrierClass4Update.Prevcustomactivity = customactivity;
			carrierClass4Update.Creator = creator;
			carrierClass4Update.Createtime = createtime;
			carrierClass4Update.Isusable = isusable;
			carrierClass4Update.Activity = text;
			carrierclass.CopyCommonField(carrierClass4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(carrierClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteCarrierClass(IDbContext dbContext, Carrierclass[] carrierClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("carrierClassList", carrierClassList);
		string text = "DeleteCarrierClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Carrierclass> list = new List<Carrierclass>();
		foreach (Carrierclass carrierclass in carrierClassList)
		{
			Carrierclass carrierClass4Update = GetCarrierClass4Update(dbContext, carrierclass.Carrierclassid, carrierclass.Siteid);
			if (carrierClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Carrierclass), $"{carrierclass.Carrierclassid},{carrierclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Carrierclass), $"{carrierclass.Carrierclassid},{carrierclass.Siteid}", carrierClass4Update.Isusable);
			carrierClass4Update.Isusable = "UnUsable";
			carrierclass.CopyCommonFieldUpdatePrev(carrierClass4Update, systemTime, dbContext.Tid, text);
			carrierclass.CopyExtensionCollection(carrierClass4Update);
			list.Add(carrierClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteCarrierClass(IDbContext dbContext, Carrierclass[] carrierClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("carrierClassList", carrierClassList);
		string text = "UnDeleteCarrierClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Carrierclass> list = new List<Carrierclass>();
		foreach (Carrierclass carrierclass in carrierClassList)
		{
			Carrierclass carrierClass4Update = GetCarrierClass4Update(dbContext, carrierclass.Carrierclassid, carrierclass.Siteid);
			if (carrierClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Carrierclass), $"{carrierclass.Carrierclassid},{carrierclass.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Carrierclass), $"{carrierclass.Carrierclassid},{carrierclass.Siteid}", carrierClass4Update.Isusable);
			carrierClass4Update.Isusable = "Usable";
			carrierclass.CopyCommonFieldUpdatePrev(carrierClass4Update, systemTime, dbContext.Tid, text);
			carrierclass.CopyExtensionCollection(carrierClass4Update);
			list.Add(carrierClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteCarrierClass(IDbContext dbContext, Carrierclass[] carrierClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("carrierClassList", carrierClassList);
		string text = "RealDeleteCarrierClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Carrierclass> list = new List<Carrierclass>();
		foreach (Carrierclass carrierclass in carrierClassList)
		{
			Carrierclass carrierClass4Update = GetCarrierClass4Update(dbContext, carrierclass.Carrierclassid, carrierclass.Siteid);
			if (carrierClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Carrierclass), $"{carrierclass.Carrierclassid},{carrierclass.Siteid}");
			}
			carrierclass.CopyCommonFieldUpdatePrev(carrierClass4Update, systemTime, dbContext.Tid, text);
			carrierclass.CopyExtensionCollection(carrierClass4Update);
			list.Add(carrierClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
