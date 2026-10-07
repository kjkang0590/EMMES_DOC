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
public class MATERIALCLASS
{
	private static string _sqlGetMaterialClassSqlDatabase = "SELECT * FROM CIM_MATERIALCLASS WHERE MATERIALCLASSID=@MATERIALCLASSID AND SITEID=@SITEID";

	private static string _sqlGetMaterialClass4UpdateSqlDatabase = "SELECT * FROM CIM_MATERIALCLASS WITH(UPDLOCK) WHERE MATERIALCLASSID=@MATERIALCLASSID AND SITEID=@SITEID";

	private static string _sqlSelectMaterialClassSqlDatabase = "SELECT * FROM CIM_MATERIALCLASS WHERE MATERIALCLASSID=@MATERIALCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMaterialClass4UpdateSqlDatabase = "SELECT * FROM CIM_MATERIALCLASS WITH(UPDLOCK) WHERE MATERIALCLASSID=@MATERIALCLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetMaterialClassOracleDatabase = "SELECT * FROM CIM_MATERIALCLASS WHERE MATERIALCLASSID=:MATERIALCLASSID AND SITEID=:SITEID";

	private static string _sqlGetMaterialClass4UpdateOracleDatabase = "SELECT * FROM CIM_MATERIALCLASS WHERE MATERIALCLASSID=:MATERIALCLASSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectMaterialClassOracleDatabase = "SELECT * FROM CIM_MATERIALCLASS WHERE MATERIALCLASSID=:MATERIALCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMaterialClass4UpdateOracleDatabase = "SELECT * FROM CIM_MATERIALCLASS WHERE MATERIALCLASSID=:MATERIALCLASSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Materialclass);

	public static Materialclass GetMaterialClass(IDbContext dbContext, string materialclassid, string siteid)
	{
		string apiName = "GetMaterialClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{materialclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetMaterialClassSqlDatabase : _sqlGetMaterialClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MATERIALCLASSID", materialclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MATERIALCLASS", $"{materialclassid},{siteid}"));
		}
		Materialclass? result = ContextManager.DirectEntityQuery<Materialclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{materialclassid},{siteid}");
		}
		return result;
	}

	public static Materialclass GetMaterialClass4Update(IDbContext dbContext, string materialclassid, string siteid)
	{
		string apiName = "GetMaterialClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{materialclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetMaterialClass4UpdateSqlDatabase : _sqlGetMaterialClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MATERIALCLASSID", materialclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_MATERIALCLASS", $"{materialclassid},{siteid}"));
		}
		Materialclass? result = ContextManager.DirectEntityQuery<Materialclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{materialclassid},{siteid}");
		}
		return result;
	}

	public static Materialclass SelectMaterialClass(IDbContext dbContext, string materialclassid, string siteid)
	{
		string apiName = "SelectMaterialClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{materialclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMaterialClassSqlDatabase : _sqlSelectMaterialClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MATERIALCLASSID", materialclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MATERIALCLASS", $"{materialclassid},{siteid}"));
		}
		Materialclass? result = ContextManager.DirectEntityQuery<Materialclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{materialclassid},{siteid}");
		}
		return result;
	}

	public static Materialclass SelectMaterialClass4Update(IDbContext dbContext, string materialclassid, string siteid)
	{
		string apiName = "SelectMaterialClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{materialclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMaterialClass4UpdateSqlDatabase : _sqlSelectMaterialClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MATERIALCLASSID", materialclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_MATERIALCLASS", $"{materialclassid},{siteid}"));
		}
		Materialclass? result = ContextManager.DirectEntityQuery<Materialclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{materialclassid},{siteid}");
		}
		return result;
	}

	public static int UpsertMaterialClass(IDbContext dbContext, RequestType requestType, Materialclass[] materialClassList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateMaterialClassInternal(dbContext, materialClassList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateMaterialClass(dbContext, materialClassList, optionSet, saveHist), 
			RequestType.DELETE => DeleteMaterialClass(dbContext, materialClassList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteMaterialClass(dbContext, materialClassList, optionSet, saveHist), 
			_ => RealDeleteMaterialClass(dbContext, materialClassList, optionSet, saveHist), 
		};
	}

	private static int CreateMaterialClassInternal(IDbContext dbContext, Materialclass[] materialClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialClassList", materialClassList);
		string text = "CreateMaterialClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materialclass> list = new List<Materialclass>();
		foreach (Materialclass obj in materialClassList)
		{
			Materialclass materialclass = new Materialclass();
			obj.CopyColumsTo(materialclass);
			materialclass.Activity = text;
			materialclass.CheckEntityUsable();
			obj.CopyCommonField(materialclass, systemTime, dbContext.Tid, isCreate: true);
			list.Add(materialclass);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateMaterialClass(IDbContext dbContext, Materialclass[] materialClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialClassList", materialClassList);
		string text = "UpdateMaterialClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materialclass> list = new List<Materialclass>();
		foreach (Materialclass materialclass in materialClassList)
		{
			Materialclass materialClass4Update = GetMaterialClass4Update(dbContext, materialclass.Materialclassid, materialclass.Siteid);
			if (materialClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Materialclass), $"{materialclass.Materialclassid},{materialclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Materialclass), $"{materialclass.Materialclassid},{materialclass.Siteid}", materialClass4Update.Isusable);
			string activity = materialClass4Update.Activity;
			string customactivity = materialClass4Update.Customactivity;
			string isusable = materialClass4Update.Isusable;
			DateTime? createtime = materialClass4Update.Createtime;
			string creator = materialClass4Update.Creator;
			materialclass.CopyColumsTo(materialClass4Update);
			materialClass4Update.Prevactivity = activity;
			materialClass4Update.Prevcustomactivity = customactivity;
			materialClass4Update.Creator = creator;
			materialClass4Update.Createtime = createtime;
			materialClass4Update.Isusable = isusable;
			materialClass4Update.Activity = text;
			materialclass.CopyCommonField(materialClass4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(materialClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteMaterialClass(IDbContext dbContext, Materialclass[] materialClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialClassList", materialClassList);
		string text = "DeleteMaterialClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materialclass> list = new List<Materialclass>();
		foreach (Materialclass materialclass in materialClassList)
		{
			Materialclass materialClass4Update = GetMaterialClass4Update(dbContext, materialclass.Materialclassid, materialclass.Siteid);
			if (materialClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Materialclass), $"{materialclass.Materialclassid},{materialclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Materialclass), $"{materialclass.Materialclassid},{materialclass.Siteid}", materialClass4Update.Isusable);
			materialClass4Update.Isusable = "UnUsable";
			materialclass.CopyCommonFieldUpdatePrev(materialClass4Update, systemTime, dbContext.Tid, text);
			materialclass.CopyExtensionCollection(materialClass4Update);
			list.Add(materialClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteMaterialClass(IDbContext dbContext, Materialclass[] materialClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialClassList", materialClassList);
		string text = "UnDeleteMaterialClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materialclass> list = new List<Materialclass>();
		foreach (Materialclass materialclass in materialClassList)
		{
			Materialclass materialClass4Update = GetMaterialClass4Update(dbContext, materialclass.Materialclassid, materialclass.Siteid);
			if (materialClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Materialclass), $"{materialclass.Materialclassid},{materialclass.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Materialclass), $"{materialclass.Materialclassid},{materialclass.Siteid}", materialClass4Update.Isusable);
			materialClass4Update.Isusable = "Usable";
			materialclass.CopyCommonFieldUpdatePrev(materialClass4Update, systemTime, dbContext.Tid, text);
			materialclass.CopyExtensionCollection(materialClass4Update);
			list.Add(materialClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteMaterialClass(IDbContext dbContext, Materialclass[] materialClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("materialClassList", materialClassList);
		string text = "RealDeleteMaterialClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Materialclass> list = new List<Materialclass>();
		foreach (Materialclass materialclass in materialClassList)
		{
			Materialclass materialClass4Update = GetMaterialClass4Update(dbContext, materialclass.Materialclassid, materialclass.Siteid);
			if (materialClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Materialclass), $"{materialclass.Materialclassid},{materialclass.Siteid}");
			}
			materialclass.CopyCommonFieldUpdatePrev(materialClass4Update, systemTime, dbContext.Tid, text);
			materialclass.CopyExtensionCollection(materialClass4Update);
			list.Add(materialClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
