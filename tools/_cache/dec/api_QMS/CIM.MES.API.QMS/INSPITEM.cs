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
public class INSPITEM
{
	private static string _sqlGetInspItemSqlDatabase = "SELECT * FROM CIM_INSPITEM WHERE INSPITEMID=@INSPITEMID AND SITEID=@SITEID";

	private static string _sqlGetInspItem4UpdateSqlDatabase = "SELECT * FROM CIM_INSPITEM WITH(UPDLOCK) WHERE INSPITEMID=@INSPITEMID AND SITEID=@SITEID";

	private static string _sqlSelectInspItemSqlDatabase = "SELECT * FROM CIM_INSPITEM WHERE INSPITEMID=@INSPITEMID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectInspItem4UpdateSqlDatabase = "SELECT * FROM CIM_INSPITEM WITH(UPDLOCK) WHERE INSPITEMID=@INSPITEMID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetInspItemOracleDatabase = "SELECT * FROM CIM_INSPITEM WHERE INSPITEMID=:INSPITEMID AND SITEID=:SITEID";

	private static string _sqlGetInspItem4UpdateOracleDatabase = "SELECT * FROM CIM_INSPITEM WHERE INSPITEMID=:INSPITEMID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectInspItemOracleDatabase = "SELECT * FROM CIM_INSPITEM WHERE INSPITEMID=:INSPITEMID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectInspItem4UpdateOracleDatabase = "SELECT * FROM CIM_INSPITEM WHERE INSPITEMID=:INSPITEMID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Inspitem);

	public static Inspitem GetInspItem(IDbContext dbContext, string inspitemid, string siteid)
	{
		string apiName = "GetInspItem";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspitemid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetInspItemSqlDatabase : _sqlGetInspItemOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPITEMID", inspitemid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_INSPITEM", $"{inspitemid},{siteid}"));
		}
		Inspitem? result = ContextManager.DirectEntityQuery<Inspitem>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspitemid},{siteid}");
		}
		return result;
	}

	public static Inspitem GetInspItem4Update(IDbContext dbContext, string inspitemid, string siteid)
	{
		string apiName = "GetInspItem4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspitemid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetInspItem4UpdateSqlDatabase : _sqlGetInspItem4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPITEMID", inspitemid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_INSPITEM", $"{inspitemid},{siteid}"));
		}
		Inspitem? result = ContextManager.DirectEntityQuery<Inspitem>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspitemid},{siteid}");
		}
		return result;
	}

	public static Inspitem SelectInspItem(IDbContext dbContext, string inspitemid, string siteid)
	{
		string apiName = "SelectInspItem";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspitemid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectInspItemSqlDatabase : _sqlSelectInspItemOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPITEMID", inspitemid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_INSPITEM", $"{inspitemid},{siteid}"));
		}
		Inspitem? result = ContextManager.DirectEntityQuery<Inspitem>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspitemid},{siteid}");
		}
		return result;
	}

	public static Inspitem SelectInspItem4Update(IDbContext dbContext, string inspitemid, string siteid)
	{
		string apiName = "SelectInspItem4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspitemid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectInspItem4UpdateSqlDatabase : _sqlSelectInspItem4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPITEMID", inspitemid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_INSPITEM", $"{inspitemid},{siteid}"));
		}
		Inspitem? result = ContextManager.DirectEntityQuery<Inspitem>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspitemid},{siteid}");
		}
		return result;
	}

	public static int UpsertInspItem(IDbContext dbContext, RequestType requestType, Inspitem[] inspItemList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateInspItemInternal(dbContext, inspItemList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateInspItem(dbContext, inspItemList, optionSet, saveHist), 
			RequestType.DELETE => DeleteInspItem(dbContext, inspItemList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteInspItem(dbContext, inspItemList, optionSet, saveHist), 
			_ => RealDeleteInspItem(dbContext, inspItemList, optionSet, saveHist), 
		};
	}

	private static int CreateInspItemInternal(IDbContext dbContext, Inspitem[] inspItemList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspItemList", inspItemList);
		string text = "CreateInspItem";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspitem> list = new List<Inspitem>();
		foreach (Inspitem obj in inspItemList)
		{
			Inspitem inspitem = new Inspitem();
			obj.CopyColumsTo(inspitem);
			inspitem.Activity = text;
			inspitem.CheckEntityUsable();
			obj.CopyCommonField(inspitem, systemTime, dbContext.Tid, isCreate: true);
			list.Add(inspitem);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateInspItem(IDbContext dbContext, Inspitem[] inspItemList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspItemList", inspItemList);
		string text = "UpdateInspItem";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspitem> list = new List<Inspitem>();
		foreach (Inspitem inspitem in inspItemList)
		{
			Inspitem inspItem4Update = GetInspItem4Update(dbContext, inspitem.Inspitemid, inspitem.Siteid);
			if (inspItem4Update == null)
			{
				throw new EntityNotFoundException(typeof(Inspitem), $"{inspitem.Inspitemid},{inspitem.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Inspitem), $"{inspitem.Inspitemid},{inspitem.Siteid}", inspItem4Update.Isusable);
			string activity = inspItem4Update.Activity;
			string customactivity = inspItem4Update.Customactivity;
			string isusable = inspItem4Update.Isusable;
			DateTime? createtime = inspItem4Update.Createtime;
			string creator = inspItem4Update.Creator;
			inspitem.CopyColumsTo(inspItem4Update);
			inspItem4Update.Prevactivity = activity;
			inspItem4Update.Prevcustomactivity = customactivity;
			inspItem4Update.Creator = creator;
			inspItem4Update.Createtime = createtime;
			inspItem4Update.Isusable = isusable;
			inspItem4Update.Activity = text;
			inspitem.CopyCommonField(inspItem4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(inspItem4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteInspItem(IDbContext dbContext, Inspitem[] inspItemList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspItemList", inspItemList);
		string text = "DeleteInspItem";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspitem> list = new List<Inspitem>();
		foreach (Inspitem inspitem in inspItemList)
		{
			Inspitem inspItem4Update = GetInspItem4Update(dbContext, inspitem.Inspitemid, inspitem.Siteid);
			if (inspItem4Update == null)
			{
				throw new EntityNotFoundException(typeof(Inspitem), $"{inspitem.Inspitemid},{inspitem.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Inspitem), $"{inspitem.Inspitemid},{inspitem.Siteid}", inspItem4Update.Isusable);
			inspItem4Update.Isusable = "UnUsable";
			inspitem.CopyCommonFieldUpdatePrev(inspItem4Update, systemTime, dbContext.Tid, text);
			inspitem.CopyExtensionCollection(inspItem4Update);
			list.Add(inspItem4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteInspItem(IDbContext dbContext, Inspitem[] inspItemList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspItemList", inspItemList);
		string text = "UnDeleteInspItem";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspitem> list = new List<Inspitem>();
		foreach (Inspitem inspitem in inspItemList)
		{
			Inspitem inspItem4Update = GetInspItem4Update(dbContext, inspitem.Inspitemid, inspitem.Siteid);
			if (inspItem4Update == null)
			{
				throw new EntityNotFoundException(typeof(Inspitem), $"{inspitem.Inspitemid},{inspitem.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Inspitem), $"{inspitem.Inspitemid},{inspitem.Siteid}", inspItem4Update.Isusable);
			inspItem4Update.Isusable = "Usable";
			inspitem.CopyCommonFieldUpdatePrev(inspItem4Update, systemTime, dbContext.Tid, text);
			inspitem.CopyExtensionCollection(inspItem4Update);
			list.Add(inspItem4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteInspItem(IDbContext dbContext, Inspitem[] inspItemList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspItemList", inspItemList);
		string text = "RealDeleteInspItem";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspitem> list = new List<Inspitem>();
		foreach (Inspitem inspitem in inspItemList)
		{
			Inspitem inspItem4Update = GetInspItem4Update(dbContext, inspitem.Inspitemid, inspitem.Siteid);
			if (inspItem4Update == null)
			{
				throw new EntityNotFoundException(typeof(Inspitem), $"{inspitem.Inspitemid},{inspitem.Siteid}");
			}
			inspitem.CopyCommonFieldUpdatePrev(inspItem4Update, systemTime, dbContext.Tid, text);
			inspitem.CopyExtensionCollection(inspItem4Update);
			list.Add(inspItem4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
