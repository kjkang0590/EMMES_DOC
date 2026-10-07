using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;
using CIM.Util.SPC;

namespace CIM.MES.API.QMS;

[MESAPI]
public class SPCDATASOURCE
{
	private static string _sqlGetSpcDataSourceListSqlDatabase = "SELECT * FROM CIM_SPCDATASOURCE WHERE SITEID = @SITEID";

	private static string _sqlSelectSpcDataSourceListSqlDatabase = "SELECT * FROM CIM_SPCDATASOURCE WHERE SITEID = @SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetSpcDataSourceListOracleDatabase = "SELECT * FROM CIM_SPCDATASOURCE WHERE SITEID = :SITEID";

	private static string _sqlSelectSpcDataSourceListOracleDatabase = "SELECT * FROM CIM_SPCDATASOURCE WHERE SITEID = :SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetSpcDataSourceSqlDatabase = "SELECT * FROM CIM_SPCDATASOURCE WHERE SPCDATASOURCESYSID=@SPCDATASOURCESYSID AND SITEID=@SITEID";

	private static string _sqlGetSpcDataSource4UpdateSqlDatabase = "SELECT * FROM CIM_SPCDATASOURCE WITH(UPDLOCK) WHERE SPCDATASOURCESYSID=@SPCDATASOURCESYSID AND SITEID=@SITEID";

	private static string _sqlSelectSpcDataSourceSqlDatabase = "SELECT * FROM CIM_SPCDATASOURCE WHERE SPCDATASOURCESYSID=@SPCDATASOURCESYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectSpcDataSource4UpdateSqlDatabase = "SELECT * FROM CIM_SPCDATASOURCE WITH(UPDLOCK) WHERE SPCDATASOURCESYSID=@SPCDATASOURCESYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetSpcDataSourceOracleDatabase = "SELECT * FROM CIM_SPCDATASOURCE WHERE SPCDATASOURCESYSID=:SPCDATASOURCESYSID AND SITEID=:SITEID";

	private static string _sqlGetSpcDataSource4UpdateOracleDatabase = "SELECT * FROM CIM_SPCDATASOURCE WHERE SPCDATASOURCESYSID=:SPCDATASOURCESYSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectSpcDataSourceOracleDatabase = "SELECT * FROM CIM_SPCDATASOURCE WHERE SPCDATASOURCESYSID=:SPCDATASOURCESYSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectSpcDataSource4UpdateOracleDatabase = "SELECT * FROM CIM_SPCDATASOURCE WHERE SPCDATASOURCESYSID=:SPCDATASOURCESYSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Spcdatasource);

	public static List<Spcdatasource> GetSpcDataSourceList(IDbContext dbContext, Dictionary<string, string> dynamicCondition, string siteId)
	{
		string apiName = "GetSpcDataSourceList";
		string strKeyFieldInfo = string.Join(",", dynamicCondition.ToArray());
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{strKeyFieldInfo}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetSpcDataSourceListSqlDatabase : _sqlGetSpcDataSourceListOracleDatabase);
		sql = SpcUtil.AddSqlCondition(dbContext.DbType.ToString(), sql, dynamicCondition);
		dynamicCondition.Add("SITEID", siteId);
		ExtendCondition(dbContext, dynamicCondition, out var parameters, out strKeyFieldInfo);
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SPCDATASOURCE", strKeyFieldInfo));
		}
		IList<Spcdatasource> source = ContextManager.DirectEntityQuery<Spcdatasource>(dbContext, sql, parameters.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{strKeyFieldInfo}");
		}
		return source.ToList();
	}

	public static List<Spcdatasource> SelectSpcDataSourceList(IDbContext dbContext, Dictionary<string, string> dynamicCondition, string siteId)
	{
		string apiName = "SelectSpcDataSourceList";
		string strKeyFieldInfo = string.Join(",", dynamicCondition.ToArray());
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{dynamicCondition}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectSpcDataSourceListSqlDatabase : _sqlSelectSpcDataSourceListOracleDatabase);
		sql = SpcUtil.AddSqlCondition(dbContext.DbType.ToString(), sql, dynamicCondition);
		dynamicCondition.Add("SITEID", siteId);
		ExtendCondition(dbContext, dynamicCondition, out var parameters, out strKeyFieldInfo);
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SPCDATASOURCE", strKeyFieldInfo));
		}
		IList<Spcdatasource> source = ContextManager.DirectEntityQuery<Spcdatasource>(dbContext, sql, parameters.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{strKeyFieldInfo}");
		}
		return source.ToList();
	}

	private static void ExtendCondition(IDbContext dbContext, Dictionary<string, string> dynamicCondition, out List<MesParameter> parameters, out string strKeyFieldInfo)
	{
		parameters = new List<MesParameter>();
		List<string> list = new List<string>();
		strKeyFieldInfo = null;
		foreach (string key in dynamicCondition.Keys)
		{
			parameters.Add(dbContext.CreateParameter(key, dynamicCondition[key]));
			list.Add(key + ":" + dynamicCondition[key]);
		}
		strKeyFieldInfo = string.Join(",", list.ToArray());
	}

	public static Spcdatasource GetSpcDataSource(IDbContext dbContext, long spcdatasourcesysid, string siteid)
	{
		string apiName = "GetSpcDataSource";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{spcdatasourcesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetSpcDataSourceSqlDatabase : _sqlGetSpcDataSourceOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SPCDATASOURCESYSID", spcdatasourcesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SPCDATASOURCE", $"{spcdatasourcesysid},{siteid}"));
		}
		Spcdatasource? result = ContextManager.DirectEntityQuery<Spcdatasource>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{spcdatasourcesysid},{siteid}");
		}
		return result;
	}

	public static Spcdatasource GetSpcDataSource4Update(IDbContext dbContext, long spcdatasourcesysid, string siteid)
	{
		string apiName = "GetSpcDataSource4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{spcdatasourcesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetSpcDataSource4UpdateSqlDatabase : _sqlGetSpcDataSource4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SPCDATASOURCESYSID", spcdatasourcesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_SPCDATASOURCE", $"{spcdatasourcesysid},{siteid}"));
		}
		Spcdatasource? result = ContextManager.DirectEntityQuery<Spcdatasource>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{spcdatasourcesysid},{siteid}");
		}
		return result;
	}

	public static Spcdatasource SelectSpcDataSource(IDbContext dbContext, long spcdatasourcesysid, string siteid)
	{
		string apiName = "SelectSpcDataSource";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{spcdatasourcesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectSpcDataSourceSqlDatabase : _sqlSelectSpcDataSourceOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SPCDATASOURCESYSID", spcdatasourcesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SPCDATASOURCE", $"{spcdatasourcesysid},{siteid}"));
		}
		Spcdatasource? result = ContextManager.DirectEntityQuery<Spcdatasource>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{spcdatasourcesysid},{siteid}");
		}
		return result;
	}

	public static Spcdatasource SelectSpcDataSource4Update(IDbContext dbContext, long spcdatasourcesysid, string siteid)
	{
		string apiName = "SelectSpcDataSource4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{spcdatasourcesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectSpcDataSource4UpdateSqlDatabase : _sqlSelectSpcDataSource4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SPCDATASOURCESYSID", spcdatasourcesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_SPCDATASOURCE", $"{spcdatasourcesysid},{siteid}"));
		}
		Spcdatasource? result = ContextManager.DirectEntityQuery<Spcdatasource>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{spcdatasourcesysid},{siteid}");
		}
		return result;
	}

	public static int UpsertSpcDataSource(IDbContext dbContext, RequestType requestType, Spcdatasource[] spcDataSourceList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateSpcDataSourceInternal(dbContext, spcDataSourceList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateSpcDataSource(dbContext, spcDataSourceList, optionSet, saveHist), 
			RequestType.DELETE => DeleteSpcDataSource(dbContext, spcDataSourceList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteSpcDataSource(dbContext, spcDataSourceList, optionSet, saveHist), 
			_ => RealDeleteSpcDataSource(dbContext, spcDataSourceList, optionSet, saveHist), 
		};
	}

	private static int CreateSpcDataSourceInternal(IDbContext dbContext, Spcdatasource[] spcDataSourceList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spcDataSourceList", spcDataSourceList);
		string text = "CreateSpcDataSource";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spcdatasource> list = new List<Spcdatasource>();
		foreach (Spcdatasource obj in spcDataSourceList)
		{
			Spcdatasource spcdatasource = new Spcdatasource();
			obj.CopyColumsTo(spcdatasource);
			spcdatasource.Activity = text;
			spcdatasource.CheckEntityUsable();
			obj.CopyCommonField(spcdatasource, systemTime, dbContext.Tid, isCreate: true);
			list.Add(spcdatasource);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateSpcDataSource(IDbContext dbContext, Spcdatasource[] spcDataSourceList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spcDataSourceList", spcDataSourceList);
		string text = "UpdateSpcDataSource";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spcdatasource> list = new List<Spcdatasource>();
		foreach (Spcdatasource spcdatasource in spcDataSourceList)
		{
			Spcdatasource spcDataSource4Update = GetSpcDataSource4Update(dbContext, spcdatasource.Spcdatasourcesysid, spcdatasource.Siteid);
			if (spcDataSource4Update == null)
			{
				throw new EntityNotFoundException(typeof(Spcdatasource), $"{spcdatasource.Spcdatasourcesysid},{spcdatasource.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Spcdatasource), $"{spcdatasource.Spcdatasourcesysid},{spcdatasource.Siteid}", spcDataSource4Update.Isusable);
			string activity = spcDataSource4Update.Activity;
			string customactivity = spcDataSource4Update.Customactivity;
			string isusable = spcDataSource4Update.Isusable;
			DateTime? createtime = spcDataSource4Update.Createtime;
			string creator = spcDataSource4Update.Creator;
			spcdatasource.CopyColumsTo(spcDataSource4Update);
			spcDataSource4Update.Prevactivity = activity;
			spcDataSource4Update.Prevcustomactivity = customactivity;
			spcDataSource4Update.Creator = creator;
			spcDataSource4Update.Createtime = createtime;
			spcDataSource4Update.Isusable = isusable;
			spcDataSource4Update.Activity = text;
			spcdatasource.CopyCommonField(spcDataSource4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(spcDataSource4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteSpcDataSource(IDbContext dbContext, Spcdatasource[] spcDataSourceList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spcDataSourceList", spcDataSourceList);
		string text = "DeleteSpcDataSource";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spcdatasource> list = new List<Spcdatasource>();
		foreach (Spcdatasource spcdatasource in spcDataSourceList)
		{
			Spcdatasource spcDataSource4Update = GetSpcDataSource4Update(dbContext, spcdatasource.Spcdatasourcesysid, spcdatasource.Siteid);
			if (spcDataSource4Update == null)
			{
				throw new EntityNotFoundException(typeof(Spcdatasource), $"{spcdatasource.Spcdatasourcesysid},{spcdatasource.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Spcdatasource), $"{spcdatasource.Spcdatasourcesysid},{spcdatasource.Siteid}", spcDataSource4Update.Isusable);
			spcDataSource4Update.Isusable = "UnUsable";
			spcdatasource.CopyCommonFieldUpdatePrev(spcDataSource4Update, systemTime, dbContext.Tid, text);
			spcdatasource.CopyExtensionCollection(spcDataSource4Update);
			list.Add(spcDataSource4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteSpcDataSource(IDbContext dbContext, Spcdatasource[] spcDataSourceList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spcDataSourceList", spcDataSourceList);
		string text = "UnDeleteSpcDataSource";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spcdatasource> list = new List<Spcdatasource>();
		foreach (Spcdatasource spcdatasource in spcDataSourceList)
		{
			Spcdatasource spcDataSource4Update = GetSpcDataSource4Update(dbContext, spcdatasource.Spcdatasourcesysid, spcdatasource.Siteid);
			if (spcDataSource4Update == null)
			{
				throw new EntityNotFoundException(typeof(Spcdatasource), $"{spcdatasource.Spcdatasourcesysid},{spcdatasource.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Spcdatasource), $"{spcdatasource.Spcdatasourcesysid},{spcdatasource.Siteid}", spcDataSource4Update.Isusable);
			spcDataSource4Update.Isusable = "Usable";
			spcdatasource.CopyCommonFieldUpdatePrev(spcDataSource4Update, systemTime, dbContext.Tid, text);
			spcdatasource.CopyExtensionCollection(spcDataSource4Update);
			list.Add(spcDataSource4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteSpcDataSource(IDbContext dbContext, Spcdatasource[] spcDataSourceList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spcDataSourceList", spcDataSourceList);
		string text = "RealDeleteSpcDataSource";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spcdatasource> list = new List<Spcdatasource>();
		foreach (Spcdatasource spcdatasource in spcDataSourceList)
		{
			Spcdatasource spcDataSource4Update = GetSpcDataSource4Update(dbContext, spcdatasource.Spcdatasourcesysid, spcdatasource.Siteid);
			if (spcDataSource4Update == null)
			{
				throw new EntityNotFoundException(typeof(Spcdatasource), $"{spcdatasource.Spcdatasourcesysid},{spcdatasource.Siteid}");
			}
			spcdatasource.CopyCommonFieldUpdatePrev(spcDataSource4Update, systemTime, dbContext.Tid, text);
			spcdatasource.CopyExtensionCollection(spcDataSource4Update);
			list.Add(spcDataSource4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
