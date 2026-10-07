using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.CDS;

[MESAPI]
public class DEFECT
{
	private static string _sqlGetDefectSqlDatabase = "SELECT * FROM CIM_DEFECT WHERE DEFECTID=@DEFECTID AND SITEID=@SITEID";

	private static string _sqlGetDefect4UpdateSqlDatabase = "SELECT * FROM CIM_DEFECT WITH(UPDLOCK) WHERE DEFECTID=@DEFECTID AND SITEID=@SITEID";

	private static string _sqlSelectDefectSqlDatabase = "SELECT * FROM CIM_DEFECT WHERE DEFECTID=@DEFECTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectDefect4UpdateSqlDatabase = "SELECT * FROM CIM_DEFECT WITH(UPDLOCK) WHERE DEFECTID=@DEFECTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetDefectOracleDatabase = "SELECT * FROM CIM_DEFECT WHERE DEFECTID=:DEFECTID AND SITEID=:SITEID";

	private static string _sqlGetDefect4UpdateOracleDatabase = "SELECT * FROM CIM_DEFECT WHERE DEFECTID=:DEFECTID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectDefectOracleDatabase = "SELECT * FROM CIM_DEFECT WHERE DEFECTID=:DEFECTID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectDefect4UpdateOracleDatabase = "SELECT * FROM CIM_DEFECT WHERE DEFECTID=:DEFECTID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Defect);

	public static Defect GetDefect(IDbContext dbContext, string defectid, string siteid)
	{
		string apiName = "GetDefect";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{defectid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetDefectSqlDatabase : _sqlGetDefectOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DEFECTID", defectid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_DEFECT", $"{defectid},{siteid}"));
		}
		Defect? result = ContextManager.DirectEntityQuery<Defect>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{defectid},{siteid}");
		}
		return result;
	}

	public static Defect GetDefect4Update(IDbContext dbContext, string defectid, string siteid)
	{
		string apiName = "GetDefect4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{defectid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetDefect4UpdateSqlDatabase : _sqlGetDefect4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DEFECTID", defectid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_DEFECT", $"{defectid},{siteid}"));
		}
		Defect? result = ContextManager.DirectEntityQuery<Defect>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{defectid},{siteid}");
		}
		return result;
	}

	public static Defect SelectDefect(IDbContext dbContext, string defectid, string siteid)
	{
		string apiName = "SelectDefect";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{defectid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectDefectSqlDatabase : _sqlSelectDefectOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DEFECTID", defectid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_DEFECT", $"{defectid},{siteid}"));
		}
		Defect? result = ContextManager.DirectEntityQuery<Defect>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{defectid},{siteid}");
		}
		return result;
	}

	public static Defect SelectDefect4Update(IDbContext dbContext, string defectid, string siteid)
	{
		string apiName = "SelectDefect4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{defectid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectDefect4UpdateSqlDatabase : _sqlSelectDefect4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DEFECTID", defectid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_DEFECT", $"{defectid},{siteid}"));
		}
		Defect? result = ContextManager.DirectEntityQuery<Defect>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{defectid},{siteid}");
		}
		return result;
	}

	public static int UpsertDefect(IDbContext dbContext, RequestType requestType, Defect[] defectList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateDefectInternal(dbContext, defectList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateDefect(dbContext, defectList, optionSet, saveHist), 
			RequestType.DELETE => DeleteDefect(dbContext, defectList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteDefect(dbContext, defectList, optionSet, saveHist), 
			_ => RealDeleteDefect(dbContext, defectList, optionSet, saveHist), 
		};
	}

	private static int CreateDefectInternal(IDbContext dbContext, Defect[] defectList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("defectList", defectList);
		string text = "CreateDefect";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Defect> list = new List<Defect>();
		foreach (Defect obj in defectList)
		{
			Defect defect = new Defect();
			obj.CopyColumsTo(defect);
			defect.Activity = text;
			defect.CheckEntityUsable();
			obj.CopyCommonField(defect, systemTime, dbContext.Tid, isCreate: true);
			list.Add(defect);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateDefect(IDbContext dbContext, Defect[] defectList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("defectList", defectList);
		string text = "UpdateDefect";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Defect> list = new List<Defect>();
		foreach (Defect defect in defectList)
		{
			Defect defect4Update = GetDefect4Update(dbContext, defect.Defectid, defect.Siteid);
			if (defect4Update == null)
			{
				throw new EntityNotFoundException(typeof(Defect), $"{defect.Defectid},{defect.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Defect), $"{defect.Defectid},{defect.Siteid}", defect4Update.Isusable);
			string activity = defect4Update.Activity;
			string customactivity = defect4Update.Customactivity;
			string isusable = defect4Update.Isusable;
			DateTime? createtime = defect4Update.Createtime;
			string creator = defect4Update.Creator;
			defect.CopyColumsTo(defect4Update);
			defect4Update.Prevactivity = activity;
			defect4Update.Prevcustomactivity = customactivity;
			defect4Update.Creator = creator;
			defect4Update.Createtime = createtime;
			defect4Update.Isusable = isusable;
			defect4Update.Activity = text;
			defect.CopyCommonField(defect4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(defect4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteDefect(IDbContext dbContext, Defect[] defectList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("defectList", defectList);
		string text = "DeleteDefect";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Defect> list = new List<Defect>();
		foreach (Defect defect in defectList)
		{
			Defect defect4Update = GetDefect4Update(dbContext, defect.Defectid, defect.Siteid);
			if (defect4Update == null)
			{
				throw new EntityNotFoundException(typeof(Defect), $"{defect.Defectid},{defect.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Defect), $"{defect.Defectid},{defect.Siteid}", defect4Update.Isusable);
			defect4Update.Isusable = "UnUsable";
			defect.CopyCommonFieldUpdatePrev(defect4Update, systemTime, dbContext.Tid, text);
			defect.CopyExtensionCollection(defect4Update);
			list.Add(defect4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteDefect(IDbContext dbContext, Defect[] defectList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("defectList", defectList);
		string text = "UnDeleteDefect";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Defect> list = new List<Defect>();
		foreach (Defect defect in defectList)
		{
			Defect defect4Update = GetDefect4Update(dbContext, defect.Defectid, defect.Siteid);
			if (defect4Update == null)
			{
				throw new EntityNotFoundException(typeof(Defect), $"{defect.Defectid},{defect.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Defect), $"{defect.Defectid},{defect.Siteid}", defect4Update.Isusable);
			defect4Update.Isusable = "Usable";
			defect.CopyCommonFieldUpdatePrev(defect4Update, systemTime, dbContext.Tid, text);
			defect.CopyExtensionCollection(defect4Update);
			list.Add(defect4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteDefect(IDbContext dbContext, Defect[] defectList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("defectList", defectList);
		string text = "RealDeleteDefect";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Defect> list = new List<Defect>();
		foreach (Defect defect in defectList)
		{
			Defect defect4Update = GetDefect4Update(dbContext, defect.Defectid, defect.Siteid);
			if (defect4Update == null)
			{
				throw new EntityNotFoundException(typeof(Defect), $"{defect.Defectid},{defect.Siteid}");
			}
			defect.CopyCommonFieldUpdatePrev(defect4Update, systemTime, dbContext.Tid, text);
			defect.CopyExtensionCollection(defect4Update);
			list.Add(defect4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
