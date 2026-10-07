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
public class INSPITEMCLASS
{
	private static string _sqlGetInspItemClassSqlDatabase = "SELECT * FROM CIM_INSPITEMCLASS WHERE INSPITEMCLASSID=@INSPITEMCLASSID AND SITEID=@SITEID";

	private static string _sqlGetInspItemClass4UpdateSqlDatabase = "SELECT * FROM CIM_INSPITEMCLASS WITH(UPDLOCK) WHERE INSPITEMCLASSID=@INSPITEMCLASSID AND SITEID=@SITEID";

	private static string _sqlSelectInspItemClassSqlDatabase = "SELECT * FROM CIM_INSPITEMCLASS WHERE INSPITEMCLASSID=@INSPITEMCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectInspItemClass4UpdateSqlDatabase = "SELECT * FROM CIM_INSPITEMCLASS WITH(UPDLOCK) WHERE INSPITEMCLASSID=@INSPITEMCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetInspItemClassOracleDatabase = "SELECT * FROM CIM_INSPITEMCLASS WHERE INSPITEMCLASSID=:INSPITEMCLASSID AND SITEID=:SITEID";

	private static string _sqlGetInspItemClass4UpdateOracleDatabase = "SELECT * FROM CIM_INSPITEMCLASS WHERE INSPITEMCLASSID=:INSPITEMCLASSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectInspItemClassOracleDatabase = "SELECT * FROM CIM_INSPITEMCLASS WHERE INSPITEMCLASSID=:INSPITEMCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectInspItemClass4UpdateOracleDatabase = "SELECT * FROM CIM_INSPITEMCLASS WHERE INSPITEMCLASSID=:INSPITEMCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Inspitem);

	public static Inspitemclass GetInspItemClass(IDbContext dbContext, string inspitemclassid, string siteid)
	{
		string apiName = "GetInspItemClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspitemclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetInspItemClassSqlDatabase : _sqlGetInspItemClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPITEMCLASSID", inspitemclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_INSPITEMCLASS", $"{inspitemclassid},{siteid}"));
		}
		Inspitemclass? result = ContextManager.DirectEntityQuery<Inspitemclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspitemclassid},{siteid}");
		}
		return result;
	}

	public static Inspitemclass GetInspItemClass4Update(IDbContext dbContext, string inspitemclassid, string siteid)
	{
		string apiName = "GetInspItemClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspitemclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetInspItemClass4UpdateSqlDatabase : _sqlGetInspItemClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPITEMCLASSID", inspitemclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_INSPITEMCLASS", $"{inspitemclassid},{siteid}"));
		}
		Inspitemclass? result = ContextManager.DirectEntityQuery<Inspitemclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspitemclassid},{siteid}");
		}
		return result;
	}

	public static Inspitemclass SelectInspItemClass(IDbContext dbContext, string inspitemclassid, string siteid)
	{
		string apiName = "SelectInspItemClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspitemclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectInspItemClassSqlDatabase : _sqlSelectInspItemClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPITEMCLASSID", inspitemclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_INSPITEMCLASS", $"{inspitemclassid},{siteid}"));
		}
		Inspitemclass? result = ContextManager.DirectEntityQuery<Inspitemclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspitemclassid},{siteid}");
		}
		return result;
	}

	public static Inspitemclass SelectInspItemClass4Update(IDbContext dbContext, string inspitemclassid, string siteid)
	{
		string apiName = "SelectInspItemClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspitemclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectInspItemClass4UpdateSqlDatabase : _sqlSelectInspItemClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPITEMCLASSID", inspitemclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_INSPITEMCLASS", $"{inspitemclassid},{siteid}"));
		}
		Inspitemclass? result = ContextManager.DirectEntityQuery<Inspitemclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspitemclassid},{siteid}");
		}
		return result;
	}

	public static int UpsertInspItemClass(IDbContext dbContext, RequestType requestType, Inspitemclass[] inspItemClassList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateInspItemClassInternal(dbContext, inspItemClassList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateInspItemClass(dbContext, inspItemClassList, optionSet, saveHist), 
			RequestType.DELETE => DeleteInspItemClass(dbContext, inspItemClassList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteInspItemClass(dbContext, inspItemClassList, optionSet, saveHist), 
			_ => RealDeleteInspItemClass(dbContext, inspItemClassList, optionSet, saveHist), 
		};
	}

	private static int CreateInspItemClassInternal(IDbContext dbContext, Inspitemclass[] inspItemClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspItemClassList", inspItemClassList);
		string text = "CreateInspItemClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspitemclass> list = new List<Inspitemclass>();
		foreach (Inspitemclass obj in inspItemClassList)
		{
			Inspitemclass inspitemclass = new Inspitemclass();
			obj.CopyColumsTo(inspitemclass);
			inspitemclass.Activity = text;
			inspitemclass.CheckEntityUsable();
			obj.CopyCommonField(inspitemclass, systemTime, dbContext.Tid, isCreate: true);
			list.Add(inspitemclass);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateInspItemClass(IDbContext dbContext, Inspitemclass[] inspItemClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspItemClassList", inspItemClassList);
		string text = "UpdateInspItemClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspitemclass> list = new List<Inspitemclass>();
		foreach (Inspitemclass inspitemclass in inspItemClassList)
		{
			Inspitemclass inspItemClass4Update = GetInspItemClass4Update(dbContext, inspitemclass.Inspitemclassid, inspitemclass.Siteid);
			if (inspItemClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Inspitemclass), $"{inspitemclass.Inspitemclassid},{inspitemclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Inspitemclass), $"{inspitemclass.Inspitemclassid},{inspitemclass.Siteid}", inspItemClass4Update.Isusable);
			string activity = inspItemClass4Update.Activity;
			string customactivity = inspItemClass4Update.Customactivity;
			string isusable = inspItemClass4Update.Isusable;
			DateTime? createtime = inspItemClass4Update.Createtime;
			string creator = inspItemClass4Update.Creator;
			inspitemclass.CopyColumsTo(inspItemClass4Update);
			inspItemClass4Update.Prevactivity = activity;
			inspItemClass4Update.Prevcustomactivity = customactivity;
			inspItemClass4Update.Creator = creator;
			inspItemClass4Update.Createtime = createtime;
			inspItemClass4Update.Isusable = isusable;
			inspItemClass4Update.Activity = text;
			inspitemclass.CopyCommonField(inspItemClass4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(inspItemClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteInspItemClass(IDbContext dbContext, Inspitemclass[] inspItemClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspItemClassList", inspItemClassList);
		string text = "DeleteInspItemClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspitemclass> list = new List<Inspitemclass>();
		foreach (Inspitemclass inspitemclass in inspItemClassList)
		{
			Inspitemclass inspItemClass4Update = GetInspItemClass4Update(dbContext, inspitemclass.Inspitemclassid, inspitemclass.Siteid);
			if (inspItemClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Inspitemclass), $"{inspitemclass.Inspitemclassid},{inspitemclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Inspitemclass), $"{inspitemclass.Inspitemclassid},{inspitemclass.Siteid}", inspItemClass4Update.Isusable);
			inspItemClass4Update.Isusable = "UnUsable";
			inspitemclass.CopyCommonFieldUpdatePrev(inspItemClass4Update, systemTime, dbContext.Tid, text);
			inspitemclass.CopyExtensionCollection(inspItemClass4Update);
			list.Add(inspItemClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteInspItemClass(IDbContext dbContext, Inspitemclass[] inspItemClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspItemClassList", inspItemClassList);
		string text = "UnDeleteInspItemClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspitemclass> list = new List<Inspitemclass>();
		foreach (Inspitemclass inspitemclass in inspItemClassList)
		{
			Inspitemclass inspItemClass4Update = GetInspItemClass4Update(dbContext, inspitemclass.Inspitemclassid, inspitemclass.Siteid);
			if (inspItemClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Inspitemclass), $"{inspitemclass.Inspitemclassid},{inspitemclass.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Inspitemclass), $"{inspitemclass.Inspitemclassid},{inspitemclass.Siteid}", inspItemClass4Update.Isusable);
			inspItemClass4Update.Isusable = "Usable";
			inspitemclass.CopyCommonFieldUpdatePrev(inspItemClass4Update, systemTime, dbContext.Tid, text);
			inspitemclass.CopyExtensionCollection(inspItemClass4Update);
			list.Add(inspItemClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteInspItemClass(IDbContext dbContext, Inspitemclass[] inspItemClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspItemClassList", inspItemClassList);
		string text = "RealDeleteInspItemClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspitemclass> list = new List<Inspitemclass>();
		foreach (Inspitemclass inspitemclass in inspItemClassList)
		{
			Inspitemclass inspItemClass4Update = GetInspItemClass4Update(dbContext, inspitemclass.Inspitemclassid, inspitemclass.Siteid);
			if (inspItemClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Inspitemclass), $"{inspitemclass.Inspitemclassid},{inspitemclass.Siteid}");
			}
			inspitemclass.CopyCommonFieldUpdatePrev(inspItemClass4Update, systemTime, dbContext.Tid, text);
			inspitemclass.CopyExtensionCollection(inspItemClass4Update);
			list.Add(inspItemClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
