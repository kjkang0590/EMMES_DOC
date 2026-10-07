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
public class CARRIERBOM
{
	private static string _sqlGetCarrierBomSqlDatabase = "SELECT * FROM CIM_CARRIERBOM WHERE BOMID=@BOMID AND SITEID=@SITEID";

	private static string _sqlGetCarrierBom4UpdateSqlDatabase = "SELECT * FROM CIM_CARRIERBOM WITH(UPDLOCK) WHERE BOMID=@BOMID AND SITEID=@SITEID";

	private static string _sqlSelectCarrierBomSqlDatabase = "SELECT * FROM CIM_CARRIERBOM WHERE BOMID=@BOMID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectCarrierBom4UpdateSqlDatabase = "SELECT * FROM CIM_CARRIERBOM WITH(UPDLOCK) WHERE BOMID=@BOMID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetCarrierBomOracleDatabase = "SELECT * FROM CIM_CARRIERBOM WHERE BOMID=:BOMID AND SITEID=:SITEID";

	private static string _sqlGetCarrierBom4UpdateOracleDatabase = "SELECT * FROM CIM_CARRIERBOM WHERE BOMID=:BOMID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectCarrierBomOracleDatabase = "SELECT * FROM CIM_CARRIERBOM WHERE BOMID=:BOMID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectCarrierBom4UpdateOracleDatabase = "SELECT * FROM CIM_CARRIERBOM WHERE BOMID=:BOMID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Carrierbom);

	public static Carrierbom GetCarrierBom(IDbContext dbContext, string bomid, string siteid)
	{
		string apiName = "GetCarrierBom";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{bomid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetCarrierBomSqlDatabase : _sqlGetCarrierBomOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("BOMID", bomid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_CARRIERBOM", $"{bomid},{siteid}"));
		}
		Carrierbom? result = ContextManager.DirectEntityQuery<Carrierbom>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{bomid},{siteid}");
		}
		return result;
	}

	public static Carrierbom GetCarrierBom4Update(IDbContext dbContext, string bomid, string siteid)
	{
		string apiName = "GetCarrierBom4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{bomid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetCarrierBom4UpdateSqlDatabase : _sqlGetCarrierBom4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("BOMID", bomid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_CARRIERBOM", $"{bomid},{siteid}"));
		}
		Carrierbom? result = ContextManager.DirectEntityQuery<Carrierbom>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{bomid},{siteid}");
		}
		return result;
	}

	public static Carrierbom SelectCarrierBom(IDbContext dbContext, string bomid, string siteid)
	{
		string apiName = "SelectCarrierBom";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{bomid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectCarrierBomSqlDatabase : _sqlSelectCarrierBomOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("BOMID", bomid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_CARRIERBOM", $"{bomid},{siteid}"));
		}
		Carrierbom? result = ContextManager.DirectEntityQuery<Carrierbom>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{bomid},{siteid}");
		}
		return result;
	}

	public static Carrierbom SelectCarrierBom4Update(IDbContext dbContext, string bomid, string siteid)
	{
		string apiName = "SelectCarrierBom4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{bomid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectCarrierBom4UpdateSqlDatabase : _sqlSelectCarrierBom4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("BOMID", bomid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_CARRIERBOM", $"{bomid},{siteid}"));
		}
		Carrierbom? result = ContextManager.DirectEntityQuery<Carrierbom>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{bomid},{siteid}");
		}
		return result;
	}

	public static int UpsertCarrierBom(IDbContext dbContext, RequestType requestType, Carrierbom[] carrierBomList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateCarrierBomInternal(dbContext, carrierBomList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateCarrierBom(dbContext, carrierBomList, optionSet, saveHist), 
			RequestType.DELETE => DeleteCarrierBom(dbContext, carrierBomList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteCarrierBom(dbContext, carrierBomList, optionSet, saveHist), 
			_ => RealDeleteCarrierBom(dbContext, carrierBomList, optionSet, saveHist), 
		};
	}

	private static int CreateCarrierBomInternal(IDbContext dbContext, Carrierbom[] carrierBomList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("carrierBomList", carrierBomList);
		string text = "CreateCarrierBom";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Carrierbom> list = new List<Carrierbom>();
		foreach (Carrierbom obj in carrierBomList)
		{
			Carrierbom carrierbom = new Carrierbom();
			obj.CopyColumsTo(carrierbom);
			carrierbom.Activity = text;
			carrierbom.CheckEntityUsable();
			obj.CopyCommonField(carrierbom, systemTime, dbContext.Tid, isCreate: true);
			list.Add(carrierbom);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateCarrierBom(IDbContext dbContext, Carrierbom[] carrierBomList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("carrierBomList", carrierBomList);
		string text = "UpdateCarrierBom";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Carrierbom> list = new List<Carrierbom>();
		foreach (Carrierbom carrierbom in carrierBomList)
		{
			Carrierbom carrierBom4Update = GetCarrierBom4Update(dbContext, carrierbom.Bomid, carrierbom.Siteid);
			if (carrierBom4Update == null)
			{
				throw new EntityNotFoundException(typeof(Carrierbom), $"{carrierbom.Bomid},{carrierbom.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Carrierbom), $"{carrierbom.Bomid},{carrierbom.Siteid}", carrierBom4Update.Isusable);
			string activity = carrierBom4Update.Activity;
			string customactivity = carrierBom4Update.Customactivity;
			string isusable = carrierBom4Update.Isusable;
			DateTime? createtime = carrierBom4Update.Createtime;
			string creator = carrierBom4Update.Creator;
			carrierbom.CopyColumsTo(carrierBom4Update);
			carrierBom4Update.Prevactivity = activity;
			carrierBom4Update.Prevcustomactivity = customactivity;
			carrierBom4Update.Creator = creator;
			carrierBom4Update.Createtime = createtime;
			carrierBom4Update.Isusable = isusable;
			carrierBom4Update.Activity = text;
			carrierbom.CopyCommonField(carrierBom4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(carrierBom4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteCarrierBom(IDbContext dbContext, Carrierbom[] carrierBomList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("carrierBomList", carrierBomList);
		string text = "DeleteCarrierBom";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Carrierbom> list = new List<Carrierbom>();
		foreach (Carrierbom carrierbom in carrierBomList)
		{
			Carrierbom carrierBom4Update = GetCarrierBom4Update(dbContext, carrierbom.Bomid, carrierbom.Siteid);
			if (carrierBom4Update == null)
			{
				throw new EntityNotFoundException(typeof(Carrierbom), $"{carrierbom.Bomid},{carrierbom.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Carrierbom), $"{carrierbom.Bomid},{carrierbom.Siteid}", carrierBom4Update.Isusable);
			carrierBom4Update.Isusable = "UnUsable";
			carrierbom.CopyCommonFieldUpdatePrev(carrierBom4Update, systemTime, dbContext.Tid, text);
			carrierbom.CopyExtensionCollection(carrierBom4Update);
			list.Add(carrierBom4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteCarrierBom(IDbContext dbContext, Carrierbom[] carrierBomList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("carrierBomList", carrierBomList);
		string text = "UnDeleteCarrierBom";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Carrierbom> list = new List<Carrierbom>();
		foreach (Carrierbom carrierbom in carrierBomList)
		{
			Carrierbom carrierBom4Update = GetCarrierBom4Update(dbContext, carrierbom.Bomid, carrierbom.Siteid);
			if (carrierBom4Update == null)
			{
				throw new EntityNotFoundException(typeof(Carrierbom), $"{carrierbom.Bomid},{carrierbom.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Carrierbom), $"{carrierbom.Bomid},{carrierbom.Siteid}", carrierBom4Update.Isusable);
			carrierBom4Update.Isusable = "Usable";
			carrierbom.CopyCommonFieldUpdatePrev(carrierBom4Update, systemTime, dbContext.Tid, text);
			carrierbom.CopyExtensionCollection(carrierBom4Update);
			list.Add(carrierBom4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteCarrierBom(IDbContext dbContext, Carrierbom[] carrierBomList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("carrierBomList", carrierBomList);
		string text = "RealDeleteCarrierBom";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Carrierbom> list = new List<Carrierbom>();
		foreach (Carrierbom carrierbom in carrierBomList)
		{
			Carrierbom carrierBom4Update = GetCarrierBom4Update(dbContext, carrierbom.Bomid, carrierbom.Siteid);
			if (carrierBom4Update == null)
			{
				throw new EntityNotFoundException(typeof(Carrierbom), $"{carrierbom.Bomid},{carrierbom.Siteid}");
			}
			carrierbom.CopyCommonFieldUpdatePrev(carrierBom4Update, systemTime, dbContext.Tid, text);
			carrierbom.CopyExtensionCollection(carrierBom4Update);
			list.Add(carrierBom4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
