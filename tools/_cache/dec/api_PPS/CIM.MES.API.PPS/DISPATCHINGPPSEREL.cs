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
public class DISPATCHINGPPSEREL
{
	private static string _sqlGetDispatchingPPSERelSqlDatabase = "SELECT * FROM CIM_DISPATCHINGPPSEREL WHERE PRODUCTRULESYSID=@PRODUCTRULESYSID AND DISPATCHINGITEMSETID=@DISPATCHINGITEMSETID AND SITEID=@SITEID";

	private static string _sqlGetDispatchingPPSERel4UpdateSqlDatabase = "SELECT * FROM CIM_DISPATCHINGPPSEREL WITH(UPDLOCK) WHERE PRODUCTRULESYSID=@PRODUCTRULESYSID AND DISPATCHINGITEMSETID=@DISPATCHINGITEMSETID AND SITEID=@SITEID";

	private static string _sqlSelectDispatchingPPSERelSqlDatabase = "SELECT * FROM CIM_DISPATCHINGPPSEREL WHERE PRODUCTRULESYSID=@PRODUCTRULESYSID AND DISPATCHINGITEMSETID=@DISPATCHINGITEMSETID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectDispatchingPPSERel4UpdateSqlDatabase = "SELECT * FROM CIM_DISPATCHINGPPSEREL WITH(UPDLOCK) WHERE PRODUCTRULESYSID=@PRODUCTRULESYSID AND DISPATCHINGITEMSETID=@DISPATCHINGITEMSETID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetDispatchingPPSERelOracleDatabase = "SELECT * FROM CIM_DISPATCHINGPPSEREL WHERE PRODUCTRULESYSID=:PRODUCTRULESYSID AND DISPATCHINGITEMSETID=:DISPATCHINGITEMSETID AND SITEID=:SITEID";

	private static string _sqlGetDispatchingPPSERel4UpdateOracleDatabase = "SELECT * FROM CIM_DISPATCHINGPPSEREL WHERE PRODUCTRULESYSID=:PRODUCTRULESYSID AND DISPATCHINGITEMSETID=:DISPATCHINGITEMSETID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectDispatchingPPSERelOracleDatabase = "SELECT * FROM CIM_DISPATCHINGPPSEREL WHERE PRODUCTRULESYSID=:PRODUCTRULESYSID AND DISPATCHINGITEMSETID=:DISPATCHINGITEMSETID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectDispatchingPPSERel4UpdateOracleDatabase = "SELECT * FROM CIM_DISPATCHINGPPSEREL WHERE PRODUCTRULESYSID=:PRODUCTRULESYSID AND DISPATCHINGITEMSETID=:DISPATCHINGITEMSETID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Dispatchingppserel);

	public static Dispatchingppserel GetDispatchingPPSERel(IDbContext dbContext, string productrulesysid, string dispatchingitemsetid, string siteid)
	{
		string apiName = "GetDispatchingPPSERel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productrulesysid},{dispatchingitemsetid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetDispatchingPPSERelSqlDatabase : _sqlGetDispatchingPPSERelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTRULESYSID", productrulesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("DISPATCHINGITEMSETID", dispatchingitemsetid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_DISPATCHINGPPSEREL", $"{productrulesysid},{dispatchingitemsetid},{siteid}"));
		}
		Dispatchingppserel? result = ContextManager.DirectEntityQuery<Dispatchingppserel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productrulesysid},{dispatchingitemsetid},{siteid}");
		}
		return result;
	}

	public static Dispatchingppserel GetDispatchingPPSERel4Update(IDbContext dbContext, string productrulesysid, string dispatchingitemsetid, string siteid)
	{
		string apiName = "GetDispatchingPPSERel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productrulesysid},{dispatchingitemsetid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetDispatchingPPSERel4UpdateSqlDatabase : _sqlGetDispatchingPPSERel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTRULESYSID", productrulesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("DISPATCHINGITEMSETID", dispatchingitemsetid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_DISPATCHINGPPSEREL", $"{productrulesysid},{dispatchingitemsetid},{siteid}"));
		}
		Dispatchingppserel? result = ContextManager.DirectEntityQuery<Dispatchingppserel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productrulesysid},{dispatchingitemsetid},{siteid}");
		}
		return result;
	}

	public static Dispatchingppserel SelectDispatchingPPSERel(IDbContext dbContext, string productrulesysid, string dispatchingitemsetid, string siteid)
	{
		string apiName = "SelectDispatchingPPSERel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productrulesysid},{dispatchingitemsetid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectDispatchingPPSERelSqlDatabase : _sqlSelectDispatchingPPSERelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTRULESYSID", productrulesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("DISPATCHINGITEMSETID", dispatchingitemsetid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_DISPATCHINGPPSEREL", $"{productrulesysid},{dispatchingitemsetid},{siteid}"));
		}
		Dispatchingppserel? result = ContextManager.DirectEntityQuery<Dispatchingppserel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productrulesysid},{dispatchingitemsetid},{siteid}");
		}
		return result;
	}

	public static Dispatchingppserel SelectDispatchingPPSERel4Update(IDbContext dbContext, string productrulesysid, string dispatchingitemsetid, string siteid)
	{
		string apiName = "SelectDispatchingPPSERel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productrulesysid},{dispatchingitemsetid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectDispatchingPPSERel4UpdateSqlDatabase : _sqlSelectDispatchingPPSERel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTRULESYSID", productrulesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("DISPATCHINGITEMSETID", dispatchingitemsetid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_DISPATCHINGPPSEREL", $"{productrulesysid},{dispatchingitemsetid},{siteid}"));
		}
		Dispatchingppserel? result = ContextManager.DirectEntityQuery<Dispatchingppserel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productrulesysid},{dispatchingitemsetid},{siteid}");
		}
		return result;
	}

	public static int UpsertDispatchingPPSERel(IDbContext dbContext, RequestType requestType, Dispatchingppserel[] dispatchingPPSERelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateDispatchingPPSERelInternal(dbContext, dispatchingPPSERelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateDispatchingPPSERel(dbContext, dispatchingPPSERelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteDispatchingPPSERel(dbContext, dispatchingPPSERelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteDispatchingPPSERel(dbContext, dispatchingPPSERelList, optionSet, saveHist), 
			_ => RealDeleteDispatchingPPSERel(dbContext, dispatchingPPSERelList, optionSet, saveHist), 
		};
	}

	private static int CreateDispatchingPPSERelInternal(IDbContext dbContext, Dispatchingppserel[] dispatchingPPSERelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("dispatchingPPSERelList", dispatchingPPSERelList);
		string text = "CreateDispatchingPPSERel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Dispatchingppserel> list = new List<Dispatchingppserel>();
		foreach (Dispatchingppserel obj in dispatchingPPSERelList)
		{
			Dispatchingppserel dispatchingppserel = new Dispatchingppserel();
			obj.CopyColumsTo(dispatchingppserel);
			dispatchingppserel.Activity = text;
			dispatchingppserel.CheckEntityUsable();
			obj.CopyCommonField(dispatchingppserel, systemTime, dbContext.Tid, isCreate: true);
			list.Add(dispatchingppserel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateDispatchingPPSERel(IDbContext dbContext, Dispatchingppserel[] dispatchingPPSERelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("dispatchingPPSERelList", dispatchingPPSERelList);
		string text = "UpdateDispatchingPPSERel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Dispatchingppserel> list = new List<Dispatchingppserel>();
		foreach (Dispatchingppserel dispatchingppserel in dispatchingPPSERelList)
		{
			Dispatchingppserel dispatchingPPSERel4Update = GetDispatchingPPSERel4Update(dbContext, dispatchingppserel.Productrulesysid, dispatchingppserel.Dispatchingitemsetid, dispatchingppserel.Siteid);
			if (dispatchingPPSERel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Dispatchingppserel), $"{dispatchingppserel.Productrulesysid},{dispatchingppserel.Dispatchingitemsetid},{dispatchingppserel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Dispatchingppserel), $"{dispatchingppserel.Productrulesysid},{dispatchingppserel.Dispatchingitemsetid},{dispatchingppserel.Siteid}", dispatchingPPSERel4Update.Isusable);
			string activity = dispatchingPPSERel4Update.Activity;
			string customactivity = dispatchingPPSERel4Update.Customactivity;
			string isusable = dispatchingPPSERel4Update.Isusable;
			DateTime? createtime = dispatchingPPSERel4Update.Createtime;
			string creator = dispatchingPPSERel4Update.Creator;
			dispatchingppserel.CopyColumsTo(dispatchingPPSERel4Update);
			dispatchingPPSERel4Update.Prevactivity = activity;
			dispatchingPPSERel4Update.Prevcustomactivity = customactivity;
			dispatchingPPSERel4Update.Creator = creator;
			dispatchingPPSERel4Update.Createtime = createtime;
			dispatchingPPSERel4Update.Isusable = isusable;
			dispatchingPPSERel4Update.Activity = text;
			dispatchingppserel.CopyCommonField(dispatchingPPSERel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(dispatchingPPSERel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteDispatchingPPSERel(IDbContext dbContext, Dispatchingppserel[] dispatchingPPSERelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("dispatchingPPSERelList", dispatchingPPSERelList);
		string text = "DeleteDispatchingPPSERel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Dispatchingppserel> list = new List<Dispatchingppserel>();
		foreach (Dispatchingppserel dispatchingppserel in dispatchingPPSERelList)
		{
			Dispatchingppserel dispatchingPPSERel4Update = GetDispatchingPPSERel4Update(dbContext, dispatchingppserel.Productrulesysid, dispatchingppserel.Dispatchingitemsetid, dispatchingppserel.Siteid);
			if (dispatchingPPSERel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Dispatchingppserel), $"{dispatchingppserel.Productrulesysid},{dispatchingppserel.Dispatchingitemsetid},{dispatchingppserel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Dispatchingppserel), $"{dispatchingppserel.Productrulesysid},{dispatchingppserel.Dispatchingitemsetid},{dispatchingppserel.Siteid}", dispatchingPPSERel4Update.Isusable);
			dispatchingPPSERel4Update.Isusable = "UnUsable";
			dispatchingppserel.CopyCommonFieldUpdatePrev(dispatchingPPSERel4Update, systemTime, dbContext.Tid, text);
			dispatchingppserel.CopyExtensionCollection(dispatchingPPSERel4Update);
			list.Add(dispatchingPPSERel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteDispatchingPPSERel(IDbContext dbContext, Dispatchingppserel[] dispatchingPPSERelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("dispatchingPPSERelList", dispatchingPPSERelList);
		string text = "UnDeleteDispatchingPPSERel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Dispatchingppserel> list = new List<Dispatchingppserel>();
		foreach (Dispatchingppserel dispatchingppserel in dispatchingPPSERelList)
		{
			Dispatchingppserel dispatchingPPSERel4Update = GetDispatchingPPSERel4Update(dbContext, dispatchingppserel.Productrulesysid, dispatchingppserel.Dispatchingitemsetid, dispatchingppserel.Siteid);
			if (dispatchingPPSERel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Dispatchingppserel), $"{dispatchingppserel.Productrulesysid},{dispatchingppserel.Dispatchingitemsetid},{dispatchingppserel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Dispatchingppserel), $"{dispatchingppserel.Productrulesysid},{dispatchingppserel.Dispatchingitemsetid},{dispatchingppserel.Siteid}", dispatchingPPSERel4Update.Isusable);
			dispatchingPPSERel4Update.Isusable = "Usable";
			dispatchingppserel.CopyCommonFieldUpdatePrev(dispatchingPPSERel4Update, systemTime, dbContext.Tid, text);
			dispatchingppserel.CopyExtensionCollection(dispatchingPPSERel4Update);
			list.Add(dispatchingPPSERel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteDispatchingPPSERel(IDbContext dbContext, Dispatchingppserel[] dispatchingPPSERelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("dispatchingPPSERelList", dispatchingPPSERelList);
		string text = "RealDeleteDispatchingPPSERel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Dispatchingppserel> list = new List<Dispatchingppserel>();
		foreach (Dispatchingppserel dispatchingppserel in dispatchingPPSERelList)
		{
			Dispatchingppserel dispatchingPPSERel4Update = GetDispatchingPPSERel4Update(dbContext, dispatchingppserel.Productrulesysid, dispatchingppserel.Dispatchingitemsetid, dispatchingppserel.Siteid);
			if (dispatchingPPSERel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Dispatchingppserel), $"{dispatchingppserel.Productrulesysid},{dispatchingppserel.Dispatchingitemsetid},{dispatchingppserel.Siteid}");
			}
			dispatchingppserel.CopyCommonFieldUpdatePrev(dispatchingPPSERel4Update, systemTime, dbContext.Tid, text);
			dispatchingppserel.CopyExtensionCollection(dispatchingPPSERel4Update);
			list.Add(dispatchingPPSERel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
