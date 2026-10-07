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
public class DISPATCHINGITEMSET
{
	private static string _sqlGetDispatchingItemSetSqlDatabase = "SELECT * FROM CIM_DISPATCHINGITEMSET WHERE DISPATCHINGITEMSETID=@DISPATCHINGITEMSETID AND DISPATCHINGITEMID=@DISPATCHINGITEMID AND SITEID=@SITEID";

	private static string _sqlGetDispatchingItemSet4UpdateSqlDatabase = "SELECT * FROM CIM_DISPATCHINGITEMSET WITH(UPDLOCK) WHERE DISPATCHINGITEMSETID=@DISPATCHINGITEMSETID AND DISPATCHINGITEMID=@DISPATCHINGITEMID AND SITEID=@SITEID";

	private static string _sqlSelectDispatchingItemSetSqlDatabase = "SELECT * FROM CIM_DISPATCHINGITEMSET WHERE DISPATCHINGITEMSETID=@DISPATCHINGITEMSETID AND DISPATCHINGITEMID=@DISPATCHINGITEMID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectDispatchingItemSet4UpdateSqlDatabase = "SELECT * FROM CIM_DISPATCHINGITEMSET WITH(UPDLOCK) WHERE DISPATCHINGITEMSETID=@DISPATCHINGITEMSETID AND DISPATCHINGITEMID=@DISPATCHINGITEMID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetDispatchingItemSetOracleDatabase = "SELECT * FROM CIM_DISPATCHINGITEMSET WHERE DISPATCHINGITEMSETID=:DISPATCHINGITEMSETID AND DISPATCHINGITEMID=:DISPATCHINGITEMID AND SITEID=:SITEID";

	private static string _sqlGetDispatchingItemSet4UpdateOracleDatabase = "SELECT * FROM CIM_DISPATCHINGITEMSET WHERE DISPATCHINGITEMSETID=:DISPATCHINGITEMSETID AND DISPATCHINGITEMID=:DISPATCHINGITEMID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectDispatchingItemSetOracleDatabase = "SELECT * FROM CIM_DISPATCHINGITEMSET WHERE DISPATCHINGITEMSETID=:DISPATCHINGITEMSETID AND DISPATCHINGITEMID=:DISPATCHINGITEMID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectDispatchingItemSet4UpdateOracleDatabase = "SELECT * FROM CIM_DISPATCHINGITEMSET WHERE DISPATCHINGITEMSETID=:DISPATCHINGITEMSETID AND DISPATCHINGITEMID=:DISPATCHINGITEMID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Dispatchingitemset);

	public static Dispatchingitemset GetDispatchingItemSet(IDbContext dbContext, string dispatchingitemsetid, string dispatchingitemid, string siteid)
	{
		string apiName = "GetDispatchingItemSet";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{dispatchingitemsetid},{dispatchingitemid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetDispatchingItemSetSqlDatabase : _sqlGetDispatchingItemSetOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DISPATCHINGITEMSETID", dispatchingitemsetid, typeOfThis));
		list.Add(dbContext.CreateParameter("DISPATCHINGITEMID", dispatchingitemid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_DISPATCHINGITEMSET", $"{dispatchingitemsetid},{dispatchingitemid},{siteid}"));
		}
		Dispatchingitemset? result = ContextManager.DirectEntityQuery<Dispatchingitemset>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{dispatchingitemsetid},{dispatchingitemid},{siteid}");
		}
		return result;
	}

	public static Dispatchingitemset GetDispatchingItemSet4Update(IDbContext dbContext, string dispatchingitemsetid, string dispatchingitemid, string siteid)
	{
		string apiName = "GetDispatchingItemSet4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{dispatchingitemsetid},{dispatchingitemid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetDispatchingItemSet4UpdateSqlDatabase : _sqlGetDispatchingItemSet4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DISPATCHINGITEMSETID", dispatchingitemsetid, typeOfThis));
		list.Add(dbContext.CreateParameter("DISPATCHINGITEMID", dispatchingitemid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_DISPATCHINGITEMSET", $"{dispatchingitemsetid},{dispatchingitemid},{siteid}"));
		}
		Dispatchingitemset? result = ContextManager.DirectEntityQuery<Dispatchingitemset>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{dispatchingitemsetid},{dispatchingitemid},{siteid}");
		}
		return result;
	}

	public static Dispatchingitemset SelectDispatchingItemSet(IDbContext dbContext, string dispatchingitemsetid, string dispatchingitemid, string siteid)
	{
		string apiName = "SelectDispatchingItemSet";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{dispatchingitemsetid},{dispatchingitemid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectDispatchingItemSetSqlDatabase : _sqlSelectDispatchingItemSetOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DISPATCHINGITEMSETID", dispatchingitemsetid, typeOfThis));
		list.Add(dbContext.CreateParameter("DISPATCHINGITEMID", dispatchingitemid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_DISPATCHINGITEMSET", $"{dispatchingitemsetid},{dispatchingitemid},{siteid}"));
		}
		Dispatchingitemset? result = ContextManager.DirectEntityQuery<Dispatchingitemset>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{dispatchingitemsetid},{dispatchingitemid},{siteid}");
		}
		return result;
	}

	public static Dispatchingitemset SelectDispatchingItemSet4Update(IDbContext dbContext, string dispatchingitemsetid, string dispatchingitemid, string siteid)
	{
		string apiName = "SelectDispatchingItemSet4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{dispatchingitemsetid},{dispatchingitemid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectDispatchingItemSet4UpdateSqlDatabase : _sqlSelectDispatchingItemSet4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DISPATCHINGITEMSETID", dispatchingitemsetid, typeOfThis));
		list.Add(dbContext.CreateParameter("DISPATCHINGITEMID", dispatchingitemid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_DISPATCHINGITEMSET", $"{dispatchingitemsetid},{dispatchingitemid},{siteid}"));
		}
		Dispatchingitemset? result = ContextManager.DirectEntityQuery<Dispatchingitemset>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{dispatchingitemsetid},{dispatchingitemid},{siteid}");
		}
		return result;
	}

	public static int UpsertDispatchingItemSet(IDbContext dbContext, RequestType requestType, Dispatchingitemset[] dispatchingItemSetList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateDispatchingItemSetInternal(dbContext, dispatchingItemSetList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateDispatchingItemSet(dbContext, dispatchingItemSetList, optionSet, saveHist), 
			RequestType.DELETE => DeleteDispatchingItemSet(dbContext, dispatchingItemSetList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteDispatchingItemSet(dbContext, dispatchingItemSetList, optionSet, saveHist), 
			_ => RealDeleteDispatchingItemSet(dbContext, dispatchingItemSetList, optionSet, saveHist), 
		};
	}

	private static int CreateDispatchingItemSetInternal(IDbContext dbContext, Dispatchingitemset[] dispatchingItemSetList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("dispatchingItemSetList", dispatchingItemSetList);
		string text = "CreateDispatchingItemSet";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Dispatchingitemset> list = new List<Dispatchingitemset>();
		foreach (Dispatchingitemset obj in dispatchingItemSetList)
		{
			Dispatchingitemset dispatchingitemset = new Dispatchingitemset();
			obj.CopyColumsTo(dispatchingitemset);
			dispatchingitemset.Activity = text;
			dispatchingitemset.CheckEntityUsable();
			obj.CopyCommonField(dispatchingitemset, systemTime, dbContext.Tid, isCreate: true);
			list.Add(dispatchingitemset);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateDispatchingItemSet(IDbContext dbContext, Dispatchingitemset[] dispatchingItemSetList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("dispatchingItemSetList", dispatchingItemSetList);
		string text = "UpdateDispatchingItemSet";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Dispatchingitemset> list = new List<Dispatchingitemset>();
		foreach (Dispatchingitemset dispatchingitemset in dispatchingItemSetList)
		{
			Dispatchingitemset dispatchingItemSet4Update = GetDispatchingItemSet4Update(dbContext, dispatchingitemset.Dispatchingitemsetid, dispatchingitemset.Dispatchingitemid, dispatchingitemset.Siteid);
			if (dispatchingItemSet4Update == null)
			{
				throw new EntityNotFoundException(typeof(Dispatchingitemset), $"{dispatchingitemset.Dispatchingitemsetid},{dispatchingitemset.Dispatchingitemid},{dispatchingitemset.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Dispatchingitemset), $"{dispatchingitemset.Dispatchingitemsetid},{dispatchingitemset.Dispatchingitemid},{dispatchingitemset.Siteid}", dispatchingItemSet4Update.Isusable);
			string activity = dispatchingItemSet4Update.Activity;
			string customactivity = dispatchingItemSet4Update.Customactivity;
			string isusable = dispatchingItemSet4Update.Isusable;
			DateTime? createtime = dispatchingItemSet4Update.Createtime;
			string creator = dispatchingItemSet4Update.Creator;
			dispatchingitemset.CopyColumsTo(dispatchingItemSet4Update);
			dispatchingItemSet4Update.Prevactivity = activity;
			dispatchingItemSet4Update.Prevcustomactivity = customactivity;
			dispatchingItemSet4Update.Creator = creator;
			dispatchingItemSet4Update.Createtime = createtime;
			dispatchingItemSet4Update.Isusable = isusable;
			dispatchingItemSet4Update.Activity = text;
			dispatchingitemset.CopyCommonField(dispatchingItemSet4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(dispatchingItemSet4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteDispatchingItemSet(IDbContext dbContext, Dispatchingitemset[] dispatchingItemSetList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("dispatchingItemSetList", dispatchingItemSetList);
		string text = "DeleteDispatchingItemSet";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Dispatchingitemset> list = new List<Dispatchingitemset>();
		foreach (Dispatchingitemset dispatchingitemset in dispatchingItemSetList)
		{
			Dispatchingitemset dispatchingItemSet4Update = GetDispatchingItemSet4Update(dbContext, dispatchingitemset.Dispatchingitemsetid, dispatchingitemset.Dispatchingitemid, dispatchingitemset.Siteid);
			if (dispatchingItemSet4Update == null)
			{
				throw new EntityNotFoundException(typeof(Dispatchingitemset), $"{dispatchingitemset.Dispatchingitemsetid},{dispatchingitemset.Dispatchingitemid},{dispatchingitemset.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Dispatchingitemset), $"{dispatchingitemset.Dispatchingitemsetid},{dispatchingitemset.Dispatchingitemid},{dispatchingitemset.Siteid}", dispatchingItemSet4Update.Isusable);
			dispatchingItemSet4Update.Isusable = "UnUsable";
			dispatchingitemset.CopyCommonFieldUpdatePrev(dispatchingItemSet4Update, systemTime, dbContext.Tid, text);
			dispatchingitemset.CopyExtensionCollection(dispatchingItemSet4Update);
			list.Add(dispatchingItemSet4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteDispatchingItemSet(IDbContext dbContext, Dispatchingitemset[] dispatchingItemSetList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("dispatchingItemSetList", dispatchingItemSetList);
		string text = "UnDeleteDispatchingItemSet";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Dispatchingitemset> list = new List<Dispatchingitemset>();
		foreach (Dispatchingitemset dispatchingitemset in dispatchingItemSetList)
		{
			Dispatchingitemset dispatchingItemSet4Update = GetDispatchingItemSet4Update(dbContext, dispatchingitemset.Dispatchingitemsetid, dispatchingitemset.Dispatchingitemid, dispatchingitemset.Siteid);
			if (dispatchingItemSet4Update == null)
			{
				throw new EntityNotFoundException(typeof(Dispatchingitemset), $"{dispatchingitemset.Dispatchingitemsetid},{dispatchingitemset.Dispatchingitemid},{dispatchingitemset.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Dispatchingitemset), $"{dispatchingitemset.Dispatchingitemsetid},{dispatchingitemset.Dispatchingitemid},{dispatchingitemset.Siteid}", dispatchingItemSet4Update.Isusable);
			dispatchingItemSet4Update.Isusable = "Usable";
			dispatchingitemset.CopyCommonFieldUpdatePrev(dispatchingItemSet4Update, systemTime, dbContext.Tid, text);
			dispatchingitemset.CopyExtensionCollection(dispatchingItemSet4Update);
			list.Add(dispatchingItemSet4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteDispatchingItemSet(IDbContext dbContext, Dispatchingitemset[] dispatchingItemSetList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("dispatchingItemSetList", dispatchingItemSetList);
		string text = "RealDeleteDispatchingItemSet";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Dispatchingitemset> list = new List<Dispatchingitemset>();
		foreach (Dispatchingitemset dispatchingitemset in dispatchingItemSetList)
		{
			Dispatchingitemset dispatchingItemSet4Update = GetDispatchingItemSet4Update(dbContext, dispatchingitemset.Dispatchingitemsetid, dispatchingitemset.Dispatchingitemid, dispatchingitemset.Siteid);
			if (dispatchingItemSet4Update == null)
			{
				throw new EntityNotFoundException(typeof(Dispatchingitemset), $"{dispatchingitemset.Dispatchingitemsetid},{dispatchingitemset.Dispatchingitemid},{dispatchingitemset.Siteid}");
			}
			dispatchingitemset.CopyCommonFieldUpdatePrev(dispatchingItemSet4Update, systemTime, dbContext.Tid, text);
			dispatchingitemset.CopyExtensionCollection(dispatchingItemSet4Update);
			list.Add(dispatchingItemSet4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
