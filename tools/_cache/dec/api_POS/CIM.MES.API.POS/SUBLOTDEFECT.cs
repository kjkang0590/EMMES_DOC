using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.POS;

[MESAPI]
public class SUBLOTDEFECT
{
	private static string _sqlGetSubLotDefectSqlDatabase = "SELECT * FROM CIM_SUBLOTDEFECT WHERE SUBLOTID=@SUBLOTID AND DEFECTID=@DEFECTID AND PROCESSNODEID=@PROCESSNODEID AND REPEATCOUNT=@REPEATCOUNT AND SITEID=@SITEID";

	private static string _sqlGetSubLotDefect4UpdateSqlDatabase = "SELECT * FROM CIM_SUBLOTDEFECT WITH(UPDLOCK) WHERE SUBLOTID=@SUBLOTID AND DEFECTID=@DEFECTID AND PROCESSNODEID=@PROCESSNODEID AND REPEATCOUNT=@REPEATCOUNT AND SITEID=@SITEID";

	private static string _sqlSelectSubLotDefectSqlDatabase = "SELECT * FROM CIM_SUBLOTDEFECT WHERE SUBLOTID=@SUBLOTID AND DEFECTID=@DEFECTID AND PROCESSNODEID=@PROCESSNODEID AND REPEATCOUNT=@REPEATCOUNT AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectSubLotDefect4UpdateSqlDatabase = "SELECT * FROM CIM_SUBLOTDEFECT WITH(UPDLOCK) WHERE SUBLOTID=@SUBLOTID AND DEFECTID=@DEFECTID AND PROCESSNODEID=@PROCESSNODEID AND REPEATCOUNT=@REPEATCOUNT AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetSubLotDefectOracleDatabase = "SELECT * FROM CIM_SUBLOTDEFECT WHERE SUBLOTID=:SUBLOTID AND DEFECTID=:DEFECTID AND PROCESSNODEID=:PROCESSNODEID AND REPEATCOUNT=:REPEATCOUNT AND SITEID=:SITEID";

	private static string _sqlGetSubLotDefect4UpdateOracleDatabase = "SELECT * FROM CIM_SUBLOTDEFECT WHERE SUBLOTID=:SUBLOTID AND DEFECTID=:DEFECTID AND PROCESSNODEID=:PROCESSNODEID AND REPEATCOUNT=:REPEATCOUNT AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectSubLotDefectOracleDatabase = "SELECT * FROM CIM_SUBLOTDEFECT WHERE SUBLOTID=:SUBLOTID AND DEFECTID=:DEFECTID AND PROCESSNODEID=:PROCESSNODEID AND REPEATCOUNT=:REPEATCOUNT AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectSubLotDefect4UpdateOracleDatabase = "SELECT * FROM CIM_SUBLOTDEFECT WHERE SUBLOTID=:SUBLOTID AND DEFECTID=:DEFECTID AND PROCESSNODEID=:PROCESSNODEID AND REPEATCOUNT=:REPEATCOUNT AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Sublotdefect);

	public static Sublotdefect GetSubLotDefect(IDbContext dbContext, string sublotid, string defectid, string processnodeid, int repeatcount, string siteid)
	{
		string apiName = "GetSubLotDefect";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{sublotid},{defectid},{processnodeid},{repeatcount},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetSubLotDefectSqlDatabase : _sqlGetSubLotDefectOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SUBLOTID", sublotid, typeOfThis));
		list.Add(dbContext.CreateParameter("DEFECTID", defectid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSNODEID", processnodeid, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SUBLOTDEFECT", $"{sublotid},{defectid},{processnodeid},{repeatcount},{siteid}"));
		}
		Sublotdefect result = ContextManager.DirectEntityQuery<Sublotdefect>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{sublotid},{defectid},{processnodeid},{repeatcount},{siteid}");
		}
		return result;
	}

	public static Sublotdefect GetSubLotDefect4Update(IDbContext dbContext, string sublotid, string defectid, string processnodeid, decimal repeatcount, string siteid)
	{
		string apiName = "GetSubLotDefect4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{sublotid},{defectid},{processnodeid},{repeatcount},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetSubLotDefect4UpdateSqlDatabase : _sqlGetSubLotDefect4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SUBLOTID", sublotid, typeOfThis));
		list.Add(dbContext.CreateParameter("DEFECTID", defectid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSNODEID", processnodeid, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_SUBLOTDEFECT", $"{sublotid},{defectid},{processnodeid},{repeatcount},{siteid}"));
		}
		Sublotdefect result = ContextManager.DirectEntityQuery<Sublotdefect>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{sublotid},{defectid},{processnodeid},{repeatcount},{siteid}");
		}
		return result;
	}

	public static Sublotdefect SelectSubLotDefect(IDbContext dbContext, string sublotid, string defectid, string processnodeid, int repeatcount, string siteid)
	{
		string apiName = "SelectSubLotDefect";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{sublotid},{defectid},{processnodeid},{repeatcount},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectSubLotDefectSqlDatabase : _sqlSelectSubLotDefectOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SUBLOTID", sublotid, typeOfThis));
		list.Add(dbContext.CreateParameter("DEFECTID", defectid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSNODEID", processnodeid, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SUBLOTDEFECT", $"{sublotid},{defectid},{processnodeid},{repeatcount},{siteid}"));
		}
		Sublotdefect result = ContextManager.DirectEntityQuery<Sublotdefect>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{sublotid},{defectid},{processnodeid},{repeatcount},{siteid}");
		}
		return result;
	}

	public static Sublotdefect SelectSubLotDefect4Update(IDbContext dbContext, string sublotid, string defectid, string processnodeid, int repeatcount, string siteid)
	{
		string apiName = "SelectSubLotDefect4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{sublotid},{defectid},{processnodeid},{repeatcount},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectSubLotDefect4UpdateSqlDatabase : _sqlSelectSubLotDefect4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SUBLOTID", sublotid, typeOfThis));
		list.Add(dbContext.CreateParameter("DEFECTID", defectid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSNODEID", processnodeid, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_SUBLOTDEFECT", $"{sublotid},{defectid},{processnodeid},{repeatcount},{siteid}"));
		}
		Sublotdefect result = ContextManager.DirectEntityQuery<Sublotdefect>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{sublotid},{defectid},{processnodeid},{repeatcount},{siteid}");
		}
		return result;
	}

	public static int UpsertSubLotDefect(IDbContext dbContext, RequestType requestType, Sublotdefect[] subLotDefectList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateSubLotDefectInternal(dbContext, subLotDefectList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateSubLotDefect(dbContext, subLotDefectList, optionSet, saveHist), 
			RequestType.DELETE => DeleteSubLotDefect(dbContext, subLotDefectList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteSubLotDefect(dbContext, subLotDefectList, optionSet, saveHist), 
			_ => RealDeleteSubLotDefect(dbContext, subLotDefectList, optionSet, saveHist), 
		};
	}

	private static int CreateSubLotDefectInternal(IDbContext dbContext, Sublotdefect[] subLotDefectList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("subLotDefectList", subLotDefectList);
		string text = "CreateSubLotDefect";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Sublotdefect> list = new List<Sublotdefect>();
		foreach (Sublotdefect obj in subLotDefectList)
		{
			Sublotdefect sublotdefect = new Sublotdefect();
			obj.CopyColumsTo(sublotdefect);
			sublotdefect.Activity = text;
			sublotdefect.CheckEntityUsable();
			obj.CopyCommonField(sublotdefect, systemTime, dbContext.Tid, isCreate: true);
			list.Add(sublotdefect);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateSubLotDefect(IDbContext dbContext, Sublotdefect[] subLotDefectList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("subLotDefectList", subLotDefectList);
		string text = "UpdateSubLotDefect";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Sublotdefect> list = new List<Sublotdefect>();
		foreach (Sublotdefect sublotdefect in subLotDefectList)
		{
			Sublotdefect subLotDefect4Update = GetSubLotDefect4Update(dbContext, sublotdefect.Sublotid, sublotdefect.Defectid, sublotdefect.Processnodeid, sublotdefect.Repeatcount, sublotdefect.Siteid);
			if (subLotDefect4Update == null)
			{
				throw new EntityNotFoundException(typeof(Sublotdefect), $"{sublotdefect.Sublotid},{sublotdefect.Defectid},{sublotdefect.Processnodeid},{sublotdefect.Repeatcount},{sublotdefect.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Sublotdefect), $"{sublotdefect.Sublotid},{sublotdefect.Defectid},{sublotdefect.Processnodeid},{sublotdefect.Repeatcount},{sublotdefect.Siteid}", subLotDefect4Update.Isusable);
			string activity = subLotDefect4Update.Activity;
			string customactivity = subLotDefect4Update.Customactivity;
			string isusable = subLotDefect4Update.Isusable;
			DateTime? createtime = subLotDefect4Update.Createtime;
			string creator = subLotDefect4Update.Creator;
			sublotdefect.CopyColumsTo(subLotDefect4Update);
			subLotDefect4Update.Prevactivity = activity;
			subLotDefect4Update.Prevcustomactivity = customactivity;
			subLotDefect4Update.Creator = creator;
			subLotDefect4Update.Createtime = createtime;
			subLotDefect4Update.Isusable = isusable;
			subLotDefect4Update.Activity = text;
			sublotdefect.CopyCommonField(subLotDefect4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(subLotDefect4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteSubLotDefect(IDbContext dbContext, Sublotdefect[] subLotDefectList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("subLotDefectList", subLotDefectList);
		string text = "DeleteSubLotDefect";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Sublotdefect> list = new List<Sublotdefect>();
		foreach (Sublotdefect sublotdefect in subLotDefectList)
		{
			Sublotdefect subLotDefect4Update = GetSubLotDefect4Update(dbContext, sublotdefect.Sublotid, sublotdefect.Defectid, sublotdefect.Processnodeid, sublotdefect.Repeatcount, sublotdefect.Siteid);
			if (subLotDefect4Update == null)
			{
				throw new EntityNotFoundException(typeof(Sublotdefect), $"{sublotdefect.Sublotid},{sublotdefect.Defectid},{sublotdefect.Processnodeid},{sublotdefect.Repeatcount},{sublotdefect.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Sublotdefect), $"{sublotdefect.Sublotid},{sublotdefect.Defectid},{sublotdefect.Processnodeid},{sublotdefect.Repeatcount},{sublotdefect.Siteid}", subLotDefect4Update.Isusable);
			subLotDefect4Update.Isusable = "UnUsable";
			sublotdefect.CopyCommonFieldUpdatePrev(subLotDefect4Update, systemTime, dbContext.Tid, text);
			sublotdefect.CopyExtensionCollection(subLotDefect4Update);
			list.Add(subLotDefect4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteSubLotDefect(IDbContext dbContext, Sublotdefect[] subLotDefectList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("subLotDefectList", subLotDefectList);
		string text = "UnDeleteSubLotDefect";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Sublotdefect> list = new List<Sublotdefect>();
		foreach (Sublotdefect sublotdefect in subLotDefectList)
		{
			Sublotdefect subLotDefect4Update = GetSubLotDefect4Update(dbContext, sublotdefect.Sublotid, sublotdefect.Defectid, sublotdefect.Processnodeid, sublotdefect.Repeatcount, sublotdefect.Siteid);
			if (subLotDefect4Update == null)
			{
				throw new EntityNotFoundException(typeof(Sublotdefect), $"{sublotdefect.Sublotid},{sublotdefect.Defectid},{sublotdefect.Processnodeid},{sublotdefect.Repeatcount},{sublotdefect.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Sublotdefect), $"{sublotdefect.Sublotid},{sublotdefect.Defectid},{sublotdefect.Processnodeid},{sublotdefect.Repeatcount},{sublotdefect.Siteid}", subLotDefect4Update.Isusable);
			subLotDefect4Update.Isusable = "Usable";
			sublotdefect.CopyCommonFieldUpdatePrev(subLotDefect4Update, systemTime, dbContext.Tid, text);
			sublotdefect.CopyExtensionCollection(subLotDefect4Update);
			list.Add(subLotDefect4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteSubLotDefect(IDbContext dbContext, Sublotdefect[] subLotDefectList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("subLotDefectList", subLotDefectList);
		string text = "RealDeleteSubLotDefect";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Sublotdefect> list = new List<Sublotdefect>();
		foreach (Sublotdefect sublotdefect in subLotDefectList)
		{
			Sublotdefect subLotDefect4Update = GetSubLotDefect4Update(dbContext, sublotdefect.Sublotid, sublotdefect.Defectid, sublotdefect.Processnodeid, sublotdefect.Repeatcount, sublotdefect.Siteid);
			if (subLotDefect4Update == null)
			{
				throw new EntityNotFoundException(typeof(Sublotdefect), $"{sublotdefect.Sublotid},{sublotdefect.Defectid},{sublotdefect.Processnodeid},{sublotdefect.Repeatcount},{sublotdefect.Siteid}");
			}
			sublotdefect.CopyCommonFieldUpdatePrev(subLotDefect4Update, systemTime, dbContext.Tid, text);
			sublotdefect.CopyExtensionCollection(subLotDefect4Update);
			list.Add(subLotDefect4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
