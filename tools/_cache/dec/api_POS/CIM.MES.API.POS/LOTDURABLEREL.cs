using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.POS;

[MESAPI]
public class LOTDURABLEREL
{
	private static string _sqlGetLotDurableRelSqlDatabase = "SELECT * FROM CIM_LOTDURABLEREL WHERE LOTID=@LOTID AND DURABLEID=@DURABLEID AND PROCESSSEGMENTID=@PROCESSSEGMENTID AND REPEATCOUNT=@REPEATCOUNT AND SITEID=@SITEID";

	private static string _sqlGetLotDurableRel4UpdateSqlDatabase = "SELECT * FROM CIM_LOTDURABLEREL WITH(UPDLOCK) WHERE LOTID=@LOTID AND DURABLEID=@DURABLEID AND PROCESSSEGMENTID=@PROCESSSEGMENTID AND REPEATCOUNT=@REPEATCOUNT AND SITEID=@SITEID";

	private static string _sqlSelectLotDurableRelSqlDatabase = "SELECT * FROM CIM_LOTDURABLEREL WHERE LOTID=@LOTID AND DURABLEID=@DURABLEID AND PROCESSSEGMENTID=@PROCESSSEGMENTID AND REPEATCOUNT=@REPEATCOUNT AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLotDurableRel4UpdateSqlDatabase = "SELECT * FROM CIM_LOTDURABLEREL WITH(UPDLOCK) WHERE LOTID=@LOTID AND DURABLEID=@DURABLEID AND PROCESSSEGMENTID=@PROCESSSEGMENTID AND REPEATCOUNT=@REPEATCOUNT AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetLotDurableRelOracleDatabase = "SELECT * FROM CIM_LOTDURABLEREL WHERE LOTID=:LOTID AND DURABLEID=:DURABLEID AND PROCESSSEGMENTID=:PROCESSSEGMENTID AND REPEATCOUNT=:REPEATCOUNT AND SITEID=:SITEID";

	private static string _sqlGetLotDurableRel4UpdateOracleDatabase = "SELECT * FROM CIM_LOTDURABLEREL WHERE LOTID=:LOTID AND DURABLEID=:DURABLEID AND PROCESSSEGMENTID=:PROCESSSEGMENTID AND REPEATCOUNT=:REPEATCOUNT AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectLotDurableRelOracleDatabase = "SELECT * FROM CIM_LOTDURABLEREL WHERE LOTID=:LOTID AND DURABLEID=:DURABLEID AND PROCESSSEGMENTID=:PROCESSSEGMENTID AND REPEATCOUNT=:REPEATCOUNT AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLotDurableRel4UpdateOracleDatabase = "SELECT * FROM CIM_LOTDURABLEREL WHERE LOTID=:LOTID AND DURABLEID=:DURABLEID AND PROCESSSEGMENTID=:PROCESSSEGMENTID AND REPEATCOUNT=:REPEATCOUNT AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Lotdurablerel);

	private static string _sqlSelectLotDurableRelListSqlDatabase = "SELECT * FROM CIM_LOTDURABLEREL WHERE LOTID IN (&LOTIDLIST) AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectLotDurableRelListOracleDatabase = "SELECT * FROM CIM_LOTDURABLEREL WHERE LOTID IN (&LOTIDLIST) AND SITEID=:SITEID AND ISUSABLE='Usable'";

	public static Lotdurablerel GetLotDurableRel(IDbContext dbContext, string lotid, string durableid, string processnodeid, int repeatcount, string siteid)
	{
		string apiName = "GetLotDurableRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{durableid},{processnodeid},{repeatcount},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLotDurableRelSqlDatabase : _sqlGetLotDurableRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("DURABLEID", durableid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSNODEID", processnodeid, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOTDURABLEREL", $"{lotid},{durableid},{processnodeid},{repeatcount},{siteid}"));
		}
		Lotdurablerel result = ContextManager.DirectEntityQuery<Lotdurablerel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{durableid},{processnodeid},{repeatcount},{siteid}");
		}
		return result;
	}

	public static Lotdurablerel GetLotDurableRel4Update(IDbContext dbContext, string lotid, string durableid, string processnodeid, int repeatcount, string siteid)
	{
		string apiName = "GetLotDurableRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{durableid},{processnodeid},{repeatcount},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetLotDurableRel4UpdateSqlDatabase : _sqlGetLotDurableRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("DURABLEID", durableid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSNODEID", processnodeid, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_LOTDURABLEREL", $"{lotid},{durableid},{processnodeid},{repeatcount},{siteid}"));
		}
		Lotdurablerel result = ContextManager.DirectEntityQuery<Lotdurablerel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{durableid},{processnodeid},{repeatcount},{siteid}");
		}
		return result;
	}

	public static Lotdurablerel SelectLotDurableRel(IDbContext dbContext, string lotid, string durableid, string processnodeid, int repeatcount, string siteid)
	{
		string apiName = "SelectLotDurableRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{durableid},{processnodeid},{repeatcount},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotDurableRelSqlDatabase : _sqlSelectLotDurableRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("DURABLEID", durableid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSNODEID", processnodeid, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOTDURABLEREL", $"{lotid},{durableid},{processnodeid},{repeatcount},{siteid}"));
		}
		Lotdurablerel result = ContextManager.DirectEntityQuery<Lotdurablerel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{durableid},{processnodeid},{repeatcount},{siteid}");
		}
		return result;
	}

	public static Lotdurablerel SelectLotDurableRel4Update(IDbContext dbContext, string lotid, string durableid, string processnodeid, int repeatcount, string siteid)
	{
		string apiName = "SelectLotDurableRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotid},{durableid},{processnodeid},{repeatcount},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotDurableRel4UpdateSqlDatabase : _sqlSelectLotDurableRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("LOTID", lotid, typeOfThis));
		list.Add(dbContext.CreateParameter("DURABLEID", durableid, typeOfThis));
		list.Add(dbContext.CreateParameter("PROCESSNODEID", processnodeid, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_LOTDURABLEREL", $"{lotid},{durableid},{processnodeid},{repeatcount},{siteid}"));
		}
		Lotdurablerel result = ContextManager.DirectEntityQuery<Lotdurablerel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotid},{durableid},{processnodeid},{repeatcount},{siteid}");
		}
		return result;
	}

	public static IList<Lotdurablerel> SelectLotDurableRelList(IDbContext dbContext, Lot[] lotList, string siteId)
	{
		string apiName = "SelectLotDurableRelList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{lotList.Length},{siteId}");
		}
		string value = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectLotDurableRelListSqlDatabase : _sqlSelectLotDurableRelListOracleDatabase);
		value = new StringBuilder(value, 1000).Replace("&LOTIDLIST", EntityHelper.ConcatString4InClause(LOT.ExtractIdOrderBy(lotList))).ToString();
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_LOTDURABLEREL", $"{lotList.Length},{siteId}"));
		}
		IList<Lotdurablerel> result = ContextManager.DirectEntityQuery<Lotdurablerel>(dbContext, value, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{lotList.Length},{siteId}");
		}
		return result;
	}

	public static int UpsertLotDurableRel(IDbContext dbContext, RequestType requestType, Lotdurablerel[] lotDurableRelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateLotDurableRelInternal(dbContext, lotDurableRelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateLotDurableRel(dbContext, lotDurableRelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteLotDurableRel(dbContext, lotDurableRelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteLotDurableRel(dbContext, lotDurableRelList, optionSet, saveHist), 
			_ => RealDeleteLotDurableRel(dbContext, lotDurableRelList, optionSet, saveHist), 
		};
	}

	private static int CreateLotDurableRelInternal(IDbContext dbContext, Lotdurablerel[] lotDurableRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotDurableRelList", lotDurableRelList);
		string text = "CreateLotDurableRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotdurablerel> list = new List<Lotdurablerel>();
		foreach (Lotdurablerel obj in lotDurableRelList)
		{
			Lotdurablerel lotdurablerel = new Lotdurablerel();
			obj.CopyColumsTo(lotdurablerel);
			lotdurablerel.Activity = text;
			lotdurablerel.CheckEntityUsable();
			obj.CopyCommonField(lotdurablerel, systemTime, dbContext.Tid, isCreate: true);
			list.Add(lotdurablerel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateLotDurableRel(IDbContext dbContext, Lotdurablerel[] lotDurableRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotDurableRelList", lotDurableRelList);
		string text = "UpdateLotDurableRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotdurablerel> list = new List<Lotdurablerel>();
		foreach (Lotdurablerel lotdurablerel in lotDurableRelList)
		{
			Lotdurablerel lotDurableRel4Update = GetLotDurableRel4Update(dbContext, lotdurablerel.Lotid, lotdurablerel.Durableid, lotdurablerel.Processnodeid, lotdurablerel.Repeatcount, lotdurablerel.Siteid);
			if (lotDurableRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lotdurablerel), $"{lotdurablerel.Lotid},{lotdurablerel.Durableid},{lotdurablerel.Processnodeid},{lotdurablerel.Repeatcount},{lotdurablerel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Lotdurablerel), $"{lotdurablerel.Lotid},{lotdurablerel.Durableid},{lotdurablerel.Processnodeid},{lotdurablerel.Repeatcount},{lotdurablerel.Siteid}", lotDurableRel4Update.Isusable);
			string activity = lotDurableRel4Update.Activity;
			string customactivity = lotDurableRel4Update.Customactivity;
			string isusable = lotDurableRel4Update.Isusable;
			DateTime? createtime = lotDurableRel4Update.Createtime;
			string creator = lotDurableRel4Update.Creator;
			lotdurablerel.CopyColumsTo(lotDurableRel4Update);
			lotDurableRel4Update.Prevactivity = activity;
			lotDurableRel4Update.Prevcustomactivity = customactivity;
			lotDurableRel4Update.Creator = creator;
			lotDurableRel4Update.Createtime = createtime;
			lotDurableRel4Update.Isusable = isusable;
			lotDurableRel4Update.Activity = text;
			lotdurablerel.CopyCommonField(lotDurableRel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(lotDurableRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteLotDurableRel(IDbContext dbContext, Lotdurablerel[] lotDurableRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotDurableRelList", lotDurableRelList);
		string text = "DeleteLotDurableRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotdurablerel> list = new List<Lotdurablerel>();
		foreach (Lotdurablerel lotdurablerel in lotDurableRelList)
		{
			Lotdurablerel lotDurableRel4Update = GetLotDurableRel4Update(dbContext, lotdurablerel.Lotid, lotdurablerel.Durableid, lotdurablerel.Processnodeid, lotdurablerel.Repeatcount, lotdurablerel.Siteid);
			if (lotDurableRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lotdurablerel), $"{lotdurablerel.Lotid},{lotdurablerel.Durableid},{lotdurablerel.Processnodeid},{lotdurablerel.Repeatcount},{lotdurablerel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Lotdurablerel), $"{lotdurablerel.Lotid},{lotdurablerel.Durableid},{lotdurablerel.Processnodeid},{lotdurablerel.Repeatcount},{lotdurablerel.Siteid}", lotDurableRel4Update.Isusable);
			lotDurableRel4Update.Isusable = "UnUsable";
			lotdurablerel.CopyCommonFieldUpdatePrev(lotDurableRel4Update, systemTime, dbContext.Tid, text);
			lotdurablerel.CopyExtensionCollection(lotDurableRel4Update);
			list.Add(lotDurableRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteLotDurableRel(IDbContext dbContext, Lotdurablerel[] lotDurableRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotDurableRelList", lotDurableRelList);
		string text = "UnDeleteLotDurableRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotdurablerel> list = new List<Lotdurablerel>();
		foreach (Lotdurablerel lotdurablerel in lotDurableRelList)
		{
			Lotdurablerel lotDurableRel4Update = GetLotDurableRel4Update(dbContext, lotdurablerel.Lotid, lotdurablerel.Durableid, lotdurablerel.Processnodeid, lotdurablerel.Repeatcount, lotdurablerel.Siteid);
			if (lotDurableRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lotdurablerel), $"{lotdurablerel.Lotid},{lotdurablerel.Durableid},{lotdurablerel.Processnodeid},{lotdurablerel.Repeatcount},{lotdurablerel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Lotdurablerel), $"{lotdurablerel.Lotid},{lotdurablerel.Durableid},{lotdurablerel.Processnodeid},{lotdurablerel.Repeatcount},{lotdurablerel.Siteid}", lotDurableRel4Update.Isusable);
			lotDurableRel4Update.Isusable = "Usable";
			lotdurablerel.CopyCommonFieldUpdatePrev(lotDurableRel4Update, systemTime, dbContext.Tid, text);
			lotdurablerel.CopyExtensionCollection(lotDurableRel4Update);
			list.Add(lotDurableRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteLotDurableRel(IDbContext dbContext, Lotdurablerel[] lotDurableRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("lotDurableRelList", lotDurableRelList);
		string text = "RealDeleteLotDurableRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Lotdurablerel> list = new List<Lotdurablerel>();
		foreach (Lotdurablerel lotdurablerel in lotDurableRelList)
		{
			Lotdurablerel lotDurableRel4Update = GetLotDurableRel4Update(dbContext, lotdurablerel.Lotid, lotdurablerel.Durableid, lotdurablerel.Processnodeid, lotdurablerel.Repeatcount, lotdurablerel.Siteid);
			if (lotDurableRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Lotdurablerel), $"{lotdurablerel.Lotid},{lotdurablerel.Durableid},{lotdurablerel.Processnodeid},{lotdurablerel.Repeatcount},{lotdurablerel.Siteid}");
			}
			lotdurablerel.CopyCommonFieldUpdatePrev(lotDurableRel4Update, systemTime, dbContext.Tid, text);
			lotdurablerel.CopyExtensionCollection(lotDurableRel4Update);
			list.Add(lotDurableRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
