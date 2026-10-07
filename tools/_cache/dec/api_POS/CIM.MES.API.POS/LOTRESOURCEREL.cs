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
public class LOTRESOURCEREL
{
	private static string _sqlGetLotResourceRelSqlDatabase = "SELECT * FROM CIM_LOTRESOURCEREL WHERE LOTID=@LOTID AND RESOURCEID=@RESOURCEID AND RESOURCERELID=@RESOURCERELID AND PROCESSNODEID=@PROCESSNODEID AND REPEATCOUNT=@REPEATCOUNT AND SITEID=@SITEID";

	private static string _sqlGetLotResourceRel4UpdateSqlDatabase = "SELECT * FROM CIM_LOTRESOURCEREL WITH(UPDLOCK) WHERE LOTID=@LOTID AND RESOURCEID=@RESOURCEID AND RESOURCERELID=@RESOURCERELID AND PROCESSNODEID=@PROCESSNODEID AND REPEATCOUNT=@REPEATCOUNT AND SITEID=@SITEID";

	private static string _sqlSelectLotResourceRelSqlDatabase = "SELECT * FROM CIM_LOTRESOURCEREL WHERE LOTID=@LOTID AND RESOURCEID=@RESOURCEID AND RESOURCERELID=@RESOURCERELID AND PROCESSNODEID=@PROCESSNODEID AND REPEATCOUNT=@REPEATCOUNT AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLotResourceRel4UpdateSqlDatabase = "SELECT * FROM CIM_LOTRESOURCEREL WITH(UPDLOCK) WHERE LOTID=@LOTID AND RESOURCEID=@RESOURCEID AND RESOURCERELID=@RESOURCERELID AND PROCESSNODEID=@PROCESSNODEID AND REPEATCOUNT=@REPEATCOUNT AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetLotResourceRelOracleDatabase = "SELECT * FROM CIM_LOTRESOURCEREL WHERE LOTID=:LOTID AND RESOURCEID=:RESOURCEID AND RESOURCERELID=:RESOURCERELID AND PROCESSNODEID=:PROCESSNODEID AND REPEATCOUNT=:REPEATCOUNT AND SITEID=:SITEID";

	private static string _sqlGetLotResourceRel4UpdateOracleDatabase = "SELECT * FROM CIM_LOTRESOURCEREL WHERE LOTID=:LOTID AND RESOURCEID=:RESOURCEID AND RESOURCERELID=:RESOURCERELID AND PROCESSNODEID=:PROCESSNODEID AND REPEATCOUNT=:REPEATCOUNT AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectLotResourceRelOracleDatabase = "SELECT * FROM CIM_LOTRESOURCEREL WHERE LOTID=:LOTID AND RESOURCEID=:RESOURCEID AND RESOURCERELID=:RESOURCERELID AND PROCESSNODEID=:PROCESSNODEID AND REPEATCOUNT=:REPEATCOUNT AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLotResourceRel4UpdateOracleDatabase = "SELECT * FROM CIM_LOTRESOURCEREL WHERE LOTID=:LOTID AND RESOURCEID=:RESOURCEID AND RESOURCERELID=:RESOURCERELID AND PROCESSNODEID=:PROCESSNODEID AND REPEATCOUNT=:REPEATCOUNT AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Lotresourcerel);

	public static Lotresourcerel GetLotResourceRel(IDbContext dbContext, string lotid, string resourceid, string resourcerelid, string processnodeid, decimal repeatcount, string siteid)
	{
		string apiName = "GetLotResourceRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{resourceid},{resourcerelid},{processnodeid},{repeatcount},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLotResourceRelSqlDatabase : _sqlGetLotResourceRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("RESOURCEID", resourceid, typeOfThis));
		list.Add(dbContext.CreateParameter("RESOURCERELID", resourcerelid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSNODEID", processnodeid, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOTRESOURCEREL", $"{lotid},{resourceid},{resourcerelid},{processnodeid},{repeatcount},{siteid}"));
		}
		Lotresourcerel result = ContextManager.DirectEntityQuery<Lotresourcerel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{resourceid},{resourcerelid},{processnodeid},{repeatcount},{siteid}");
		}
		return result;
	}

	public static Lotresourcerel GetLotResourceRel4Update(IDbContext dbContext, string lotid, string resourceid, string resourcerelid, string processnodeid, decimal repeatcount, string siteid)
	{
		string apiName = "GetLotResourceRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{resourceid},{resourcerelid},{processnodeid},{repeatcount},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLotResourceRel4UpdateSqlDatabase : _sqlGetLotResourceRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("RESOURCEID", resourceid, typeOfThis));
		list.Add(dbContext.CreateParameter("RESOURCERELID", resourcerelid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSNODEID", processnodeid, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_LOTRESOURCEREL", $"{lotid},{resourceid},{resourcerelid},{processnodeid},{repeatcount},{siteid}"));
		}
		Lotresourcerel result = ContextManager.DirectEntityQuery<Lotresourcerel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{resourceid},{resourcerelid},{processnodeid},{repeatcount},{siteid}");
		}
		return result;
	}

	public static Lotresourcerel SelectLotResourceRel(IDbContext dbContext, string lotid, string resourceid, string resourcerelid, string processnodeid, decimal repeatcount, string siteid)
	{
		string apiName = "SelectLotResourceRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{resourceid},{resourcerelid},{processnodeid},{repeatcount},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotResourceRelSqlDatabase : _sqlSelectLotResourceRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("RESOURCEID", resourceid, typeOfThis));
		list.Add(dbContext.CreateParameter("RESOURCERELID", resourcerelid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSNODEID", processnodeid, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOTRESOURCEREL", $"{lotid},{resourceid},{resourcerelid},{processnodeid},{repeatcount},{siteid}"));
		}
		Lotresourcerel result = ContextManager.DirectEntityQuery<Lotresourcerel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{resourceid},{resourcerelid},{processnodeid},{repeatcount},{siteid}");
		}
		return result;
	}

	public static Lotresourcerel SelectLotResourceRel4Update(IDbContext dbContext, string lotid, string resourceid, string resourcerelid, string processnodeid, decimal repeatcount, string siteid)
	{
		string apiName = "SelectLotResourceRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{resourceid},{resourcerelid},{processnodeid},{repeatcount},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotResourceRel4UpdateSqlDatabase : _sqlSelectLotResourceRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("RESOURCEID", resourceid, typeOfThis));
		list.Add(dbContext.CreateParameter("RESOURCERELID", resourcerelid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSNODEID", processnodeid, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_LOTRESOURCEREL", $"{lotid},{resourceid},{resourcerelid},{processnodeid},{repeatcount},{siteid}"));
		}
		Lotresourcerel result = ContextManager.DirectEntityQuery<Lotresourcerel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{resourceid},{resourcerelid},{processnodeid},{repeatcount},{siteid}");
		}
		return result;
	}

	public static int UpsertLotResourceRel(IDbContext dbContext, RequestType requestType, Lotresourcerel[] lotResourceRelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateLotResourceRelInternal(dbContext, lotResourceRelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateLotResourceRel(dbContext, lotResourceRelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteLotResourceRel(dbContext, lotResourceRelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteLotResourceRel(dbContext, lotResourceRelList, optionSet, saveHist), 
			_ => RealDeleteLotResourceRel(dbContext, lotResourceRelList, optionSet, saveHist), 
		};
	}

	private static int CreateLotResourceRelInternal(IDbContext dbContext, Lotresourcerel[] lotResourceRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotResourceRelList", lotResourceRelList);
		string text = "CreateLotResourceRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotresourcerel> list = new List<Lotresourcerel>();
		foreach (Lotresourcerel obj in lotResourceRelList)
		{
			Lotresourcerel lotresourcerel = new Lotresourcerel();
			obj.CopyColumsTo(lotresourcerel);
			lotresourcerel.Activity = text;
			lotresourcerel.CheckEntityUsable();
			obj.CopyCommonField(lotresourcerel, systemTime, dbContext.Tid, isCreate: true);
			list.Add(lotresourcerel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateLotResourceRel(IDbContext dbContext, Lotresourcerel[] lotResourceRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotResourceRelList", lotResourceRelList);
		string text = "UpdateLotResourceRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotresourcerel> list = new List<Lotresourcerel>();
		foreach (Lotresourcerel lotresourcerel in lotResourceRelList)
		{
			Lotresourcerel lotResourceRel4Update = GetLotResourceRel4Update(dbContext, lotresourcerel.Lotid, lotresourcerel.Resourceid, lotresourcerel.Resourcerelid, lotresourcerel.Processnodeid, lotresourcerel.Repeatcount, lotresourcerel.Siteid);
			if (lotResourceRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lotresourcerel), $"{lotresourcerel.Lotid},{lotresourcerel.Resourceid},{lotresourcerel.Resourcerelid},{lotresourcerel.Processnodeid},{lotresourcerel.Repeatcount},{lotresourcerel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Lotresourcerel), $"{lotresourcerel.Lotid},{lotresourcerel.Resourceid},{lotresourcerel.Resourcerelid},{lotresourcerel.Processnodeid},{lotresourcerel.Repeatcount},{lotresourcerel.Siteid}", lotResourceRel4Update.Isusable);
			string activity = lotResourceRel4Update.Activity;
			string customactivity = lotResourceRel4Update.Customactivity;
			string isusable = lotResourceRel4Update.Isusable;
			DateTime? createtime = lotResourceRel4Update.Createtime;
			string creator = lotResourceRel4Update.Creator;
			lotresourcerel.CopyColumsTo(lotResourceRel4Update);
			lotResourceRel4Update.Prevactivity = activity;
			lotResourceRel4Update.Prevcustomactivity = customactivity;
			lotResourceRel4Update.Creator = creator;
			lotResourceRel4Update.Createtime = createtime;
			lotResourceRel4Update.Isusable = isusable;
			lotResourceRel4Update.Activity = text;
			lotresourcerel.CopyCommonField(lotResourceRel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(lotResourceRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteLotResourceRel(IDbContext dbContext, Lotresourcerel[] lotResourceRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotResourceRelList", lotResourceRelList);
		string text = "DeleteLotResourceRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotresourcerel> list = new List<Lotresourcerel>();
		foreach (Lotresourcerel lotresourcerel in lotResourceRelList)
		{
			Lotresourcerel lotResourceRel4Update = GetLotResourceRel4Update(dbContext, lotresourcerel.Lotid, lotresourcerel.Resourceid, lotresourcerel.Resourcerelid, lotresourcerel.Processnodeid, lotresourcerel.Repeatcount, lotresourcerel.Siteid);
			if (lotResourceRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lotresourcerel), $"{lotresourcerel.Lotid},{lotresourcerel.Resourceid},{lotresourcerel.Resourcerelid},{lotresourcerel.Processnodeid},{lotresourcerel.Repeatcount},{lotresourcerel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Lotresourcerel), $"{lotresourcerel.Lotid},{lotresourcerel.Resourceid},{lotresourcerel.Resourcerelid},{lotresourcerel.Processnodeid},{lotresourcerel.Repeatcount},{lotresourcerel.Siteid}", lotResourceRel4Update.Isusable);
			lotResourceRel4Update.Isusable = "UnUsable";
			lotresourcerel.CopyCommonFieldUpdatePrev(lotResourceRel4Update, systemTime, dbContext.Tid, text);
			lotresourcerel.CopyExtensionCollection(lotResourceRel4Update);
			list.Add(lotResourceRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteLotResourceRel(IDbContext dbContext, Lotresourcerel[] lotResourceRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotResourceRelList", lotResourceRelList);
		string text = "UnDeleteLotResourceRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotresourcerel> list = new List<Lotresourcerel>();
		foreach (Lotresourcerel lotresourcerel in lotResourceRelList)
		{
			Lotresourcerel lotResourceRel4Update = GetLotResourceRel4Update(dbContext, lotresourcerel.Lotid, lotresourcerel.Resourceid, lotresourcerel.Resourcerelid, lotresourcerel.Processnodeid, lotresourcerel.Repeatcount, lotresourcerel.Siteid);
			if (lotResourceRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lotresourcerel), $"{lotresourcerel.Lotid},{lotresourcerel.Resourceid},{lotresourcerel.Resourcerelid},{lotresourcerel.Processnodeid},{lotresourcerel.Repeatcount},{lotresourcerel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Lotresourcerel), $"{lotresourcerel.Lotid},{lotresourcerel.Resourceid},{lotresourcerel.Resourcerelid},{lotresourcerel.Processnodeid},{lotresourcerel.Repeatcount},{lotresourcerel.Siteid}", lotResourceRel4Update.Isusable);
			lotResourceRel4Update.Isusable = "Usable";
			lotresourcerel.CopyCommonFieldUpdatePrev(lotResourceRel4Update, systemTime, dbContext.Tid, text);
			lotresourcerel.CopyExtensionCollection(lotResourceRel4Update);
			list.Add(lotResourceRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteLotResourceRel(IDbContext dbContext, Lotresourcerel[] lotResourceRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotResourceRelList", lotResourceRelList);
		string text = "RealDeleteLotResourceRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotresourcerel> list = new List<Lotresourcerel>();
		foreach (Lotresourcerel lotresourcerel in lotResourceRelList)
		{
			Lotresourcerel lotResourceRel4Update = GetLotResourceRel4Update(dbContext, lotresourcerel.Lotid, lotresourcerel.Resourceid, lotresourcerel.Resourcerelid, lotresourcerel.Processnodeid, lotresourcerel.Repeatcount, lotresourcerel.Siteid);
			if (lotResourceRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lotresourcerel), $"{lotresourcerel.Lotid},{lotresourcerel.Resourceid},{lotresourcerel.Resourcerelid},{lotresourcerel.Processnodeid},{lotresourcerel.Repeatcount},{lotresourcerel.Siteid}");
			}
			lotresourcerel.CopyCommonFieldUpdatePrev(lotResourceRel4Update, systemTime, dbContext.Tid, text);
			lotresourcerel.CopyExtensionCollection(lotResourceRel4Update);
			list.Add(lotResourceRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
