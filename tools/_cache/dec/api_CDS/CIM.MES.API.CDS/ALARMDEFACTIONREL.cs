using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;
using CIM.Util.SPC;

namespace CIM.MES.API.CDS;

[MESAPI]
public class ALARMDEFACTIONREL
{
	private static string _sqlGetAlarmDefActionRelSqlDatabase = "SELECT * FROM CIM_ALARMDEFACTIONREL WHERE ALARMDEFINITIONID=@ALARMDEFINITIONID AND ALARMSOURCEID=@ALARMSOURCEID AND ALARMTYPE=@ALARMTYPE AND ALARMACTIONID=@ALARMACTIONID AND SITEID=@SITEID";

	private static string _sqlGetAlarmDefActionRel4UpdateSqlDatabase = "SELECT * FROM CIM_ALARMDEFACTIONREL WITH(UPDLOCK) WHERE ALARMDEFINITIONID=@ALARMDEFINITIONID AND ALARMSOURCEID=@ALARMSOURCEID AND ALARMTYPE=@ALARMTYPE AND ALARMACTIONID=@ALARMACTIONID AND SITEID=@SITEID";

	private static string _sqlSelectAlarmDefActionRelSqlDatabase = "SELECT * FROM CIM_ALARMDEFACTIONREL WHERE ALARMDEFINITIONID=@ALARMDEFINITIONID AND ALARMSOURCEID=@ALARMSOURCEID AND ALARMTYPE=@ALARMTYPE AND ALARMACTIONID=@ALARMACTIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectAlarmDefActionRel4UpdateSqlDatabase = "SELECT * FROM CIM_ALARMDEFACTIONREL WITH(UPDLOCK) WHERE ALARMDEFINITIONID=@ALARMDEFINITIONID AND ALARMSOURCEID=@ALARMSOURCEID AND ALARMTYPE=@ALARMTYPE AND ALARMACTIONID=@ALARMACTIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetAlarmDefActionRelOracleDatabase = "SELECT * FROM CIM_ALARMDEFACTIONREL WHERE ALARMDEFINITIONID=:ALARMDEFINITIONID AND ALARMSOURCEID=:ALARMSOURCEID AND ALARMTYPE=:ALARMTYPE AND ALARMACTIONID=:ALARMACTIONID AND SITEID=:SITEID";

	private static string _sqlGetAlarmDefActionRel4UpdateOracleDatabase = "SELECT * FROM CIM_ALARMDEFACTIONREL WHERE ALARMDEFINITIONID=:ALARMDEFINITIONID AND ALARMSOURCEID=:ALARMSOURCEID AND ALARMTYPE=:ALARMTYPE AND ALARMACTIONID=:ALARMACTIONID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectAlarmDefActionRelOracleDatabase = "SELECT * FROM CIM_ALARMDEFACTIONREL WHERE ALARMDEFINITIONID=:ALARMDEFINITIONID AND ALARMSOURCEID=:ALARMSOURCEID AND ALARMTYPE=:ALARMTYPE AND ALARMACTIONID=:ALARMACTIONID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectAlarmDefActionRel4UpdateOracleDatabase = "SELECT * FROM CIM_ALARMDEFACTIONREL WHERE ALARMDEFINITIONID=:ALARMDEFINITIONID AND ALARMSOURCEID=:ALARMSOURCEID AND ALARMTYPE=:ALARMTYPE AND ALARMACTIONID=:ALARMACTIONID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Alarmdefactionrel);

	private static string _sqlGetAlarmDefActionRelSqlDatabaseDynamicCondition = "SELECT * FROM CIM_ALARMDEFACTIONREL WHERE SITEID=@SITEID";

	private static string _sqlSelectAlarmDefActionRelSqlDatabaseDynamicCondition = "SELECT * FROM CIM_ALARMDEFACTIONREL WHERE SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetAlarmDefActionRelOracleDatabaseDynamicCondition = "SELECT * FROM CIM_ALARMDEFACTIONREL WHERE SITEID=:SITEID";

	private static string _sqlSelectAlarmDefActionRelOracleDatabaseDynamicCondition = "SELECT * FROM CIM_ALARMDEFACTIONREL WHERE SITEID=:SITEID AND ISUSABLE='Usable'";

	public static Alarmdefactionrel GetAlarmDefActionRel(IDbContext dbContext, string alarmdefinitionid, string alarmsourceid, string alarmtype, string alarmactionid, string siteid)
	{
		string apiName = "GetAlarmDefActionRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{alarmdefinitionid},{alarmsourceid},{alarmtype},{alarmactionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetAlarmDefActionRelSqlDatabase : _sqlGetAlarmDefActionRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ALARMDEFINITIONID", alarmdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("ALARMSOURCEID", alarmsourceid, typeOfThis));
		list.Add(dbContext.CreateParameter("ALARMTYPE", alarmtype, typeOfThis));
		list.Add(dbContext.CreateParameter("ALARMACTIONID", alarmactionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_ALARMDEFACTIONREL", $"{alarmdefinitionid},{alarmsourceid},{alarmtype},{alarmactionid},{siteid}"));
		}
		Alarmdefactionrel result = ContextManager.DirectEntityQuery<Alarmdefactionrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{alarmdefinitionid},{alarmsourceid},{alarmtype},{alarmactionid},{siteid}");
		}
		return result;
	}

	public static Alarmdefactionrel GetAlarmDefActionRel4Update(IDbContext dbContext, string alarmdefinitionid, string alarmsourceid, string alarmtype, string alarmactionid, string siteid)
	{
		string apiName = "GetAlarmDefActionRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{alarmdefinitionid},{alarmsourceid},{alarmtype},{alarmactionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetAlarmDefActionRel4UpdateSqlDatabase : _sqlGetAlarmDefActionRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ALARMDEFINITIONID", alarmdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("ALARMSOURCEID", alarmsourceid, typeOfThis));
		list.Add(dbContext.CreateParameter("ALARMTYPE", alarmtype, typeOfThis));
		list.Add(dbContext.CreateParameter("ALARMACTIONID", alarmactionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_ALARMDEFACTIONREL", $"{alarmdefinitionid},{alarmsourceid},{alarmtype},{alarmactionid},{siteid}"));
		}
		Alarmdefactionrel result = ContextManager.DirectEntityQuery<Alarmdefactionrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{alarmdefinitionid},{alarmsourceid},{alarmtype},{alarmactionid},{siteid}");
		}
		return result;
	}

	public static Alarmdefactionrel SelectAlarmDefActionRel(IDbContext dbContext, string alarmdefinitionid, string alarmsourceid, string alarmtype, string alarmactionid, string siteid)
	{
		string apiName = "SelectAlarmDefActionRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{alarmdefinitionid},{alarmsourceid},{alarmtype},{alarmactionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectAlarmDefActionRelSqlDatabase : _sqlSelectAlarmDefActionRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ALARMDEFINITIONID", alarmdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("ALARMSOURCEID", alarmsourceid, typeOfThis));
		list.Add(dbContext.CreateParameter("ALARMTYPE", alarmtype, typeOfThis));
		list.Add(dbContext.CreateParameter("ALARMACTIONID", alarmactionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_ALARMDEFACTIONREL", $"{alarmdefinitionid},{alarmsourceid},{alarmtype},{alarmactionid},{siteid}"));
		}
		Alarmdefactionrel result = ContextManager.DirectEntityQuery<Alarmdefactionrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{alarmdefinitionid},{alarmsourceid},{alarmtype},{alarmactionid},{siteid}");
		}
		return result;
	}

	public static Alarmdefactionrel SelectAlarmDefActionRel4Update(IDbContext dbContext, string alarmdefinitionid, string alarmsourceid, string alarmtype, string alarmactionid, string siteid)
	{
		string apiName = "SelectAlarmDefActionRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{alarmdefinitionid},{alarmsourceid},{alarmtype},{alarmactionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectAlarmDefActionRel4UpdateSqlDatabase : _sqlSelectAlarmDefActionRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ALARMDEFINITIONID", alarmdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("ALARMSOURCEID", alarmsourceid, typeOfThis));
		list.Add(dbContext.CreateParameter("ALARMTYPE", alarmtype, typeOfThis));
		list.Add(dbContext.CreateParameter("ALARMACTIONID", alarmactionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_ALARMDEFACTIONREL", $"{alarmdefinitionid},{alarmsourceid},{alarmtype},{alarmactionid},{siteid}"));
		}
		Alarmdefactionrel result = ContextManager.DirectEntityQuery<Alarmdefactionrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{alarmdefinitionid},{alarmsourceid},{alarmtype},{alarmactionid},{siteid}");
		}
		return result;
	}

	public static int UpsertAlarmDefActionRel(IDbContext dbContext, RequestType requestType, Alarmdefactionrel[] alarmDefActionRelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateAlarmDefActionRelInternal(dbContext, alarmDefActionRelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateAlarmDefActionRel(dbContext, alarmDefActionRelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteAlarmDefActionRel(dbContext, alarmDefActionRelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteAlarmDefActionRel(dbContext, alarmDefActionRelList, optionSet, saveHist), 
			_ => RealDeleteAlarmDefActionRel(dbContext, alarmDefActionRelList, optionSet, saveHist), 
		};
	}

	private static int CreateAlarmDefActionRelInternal(IDbContext dbContext, Alarmdefactionrel[] alarmDefActionRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmDefActionRelList", alarmDefActionRelList);
		string text = "CreateAlarmDefActionRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarmdefactionrel> list = new List<Alarmdefactionrel>();
		foreach (Alarmdefactionrel obj in alarmDefActionRelList)
		{
			Alarmdefactionrel alarmdefactionrel = new Alarmdefactionrel();
			obj.CopyColumsTo(alarmdefactionrel);
			alarmdefactionrel.Activity = text;
			alarmdefactionrel.CheckEntityUsable();
			obj.CopyCommonField(alarmdefactionrel, systemTime, dbContext.Tid, isCreate: true);
			list.Add(alarmdefactionrel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateAlarmDefActionRel(IDbContext dbContext, Alarmdefactionrel[] alarmDefActionRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmDefActionRelList", alarmDefActionRelList);
		string text = "UpdateAlarmDefActionRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarmdefactionrel> list = new List<Alarmdefactionrel>();
		foreach (Alarmdefactionrel alarmdefactionrel in alarmDefActionRelList)
		{
			Alarmdefactionrel alarmDefActionRel4Update = GetAlarmDefActionRel4Update(dbContext, alarmdefactionrel.Alarmdefinitionid, alarmdefactionrel.Alarmsourceid, alarmdefactionrel.Alarmtype, alarmdefactionrel.Alarmactionid, alarmdefactionrel.Siteid);
			if (alarmDefActionRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Alarmdefactionrel), $"{alarmdefactionrel.Alarmdefinitionid},{alarmdefactionrel.Alarmsourceid},{alarmdefactionrel.Alarmtype},{alarmdefactionrel.Alarmactionid},{alarmdefactionrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Alarmdefactionrel), $"{alarmdefactionrel.Alarmdefinitionid},{alarmdefactionrel.Alarmsourceid},{alarmdefactionrel.Alarmtype},{alarmdefactionrel.Alarmactionid},{alarmdefactionrel.Siteid}", alarmDefActionRel4Update.Isusable);
			string activity = alarmDefActionRel4Update.Activity;
			string customactivity = alarmDefActionRel4Update.Customactivity;
			string isusable = alarmDefActionRel4Update.Isusable;
			DateTime? createtime = alarmDefActionRel4Update.Createtime;
			string creator = alarmDefActionRel4Update.Creator;
			alarmdefactionrel.CopyColumsTo(alarmDefActionRel4Update);
			alarmDefActionRel4Update.Prevactivity = activity;
			alarmDefActionRel4Update.Prevcustomactivity = customactivity;
			alarmDefActionRel4Update.Creator = creator;
			alarmDefActionRel4Update.Createtime = createtime;
			alarmDefActionRel4Update.Isusable = isusable;
			alarmDefActionRel4Update.Activity = text;
			alarmdefactionrel.CopyCommonField(alarmDefActionRel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(alarmDefActionRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteAlarmDefActionRel(IDbContext dbContext, Alarmdefactionrel[] alarmDefActionRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmDefActionRelList", alarmDefActionRelList);
		string text = "DeleteAlarmDefActionRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarmdefactionrel> list = new List<Alarmdefactionrel>();
		foreach (Alarmdefactionrel alarmdefactionrel in alarmDefActionRelList)
		{
			Alarmdefactionrel alarmDefActionRel4Update = GetAlarmDefActionRel4Update(dbContext, alarmdefactionrel.Alarmdefinitionid, alarmdefactionrel.Alarmsourceid, alarmdefactionrel.Alarmtype, alarmdefactionrel.Alarmactionid, alarmdefactionrel.Siteid);
			if (alarmDefActionRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Alarmdefactionrel), $"{alarmdefactionrel.Alarmdefinitionid},{alarmdefactionrel.Alarmsourceid},{alarmdefactionrel.Alarmtype},{alarmdefactionrel.Alarmactionid},{alarmdefactionrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Alarmdefactionrel), $"{alarmdefactionrel.Alarmdefinitionid},{alarmdefactionrel.Alarmsourceid},{alarmdefactionrel.Alarmtype},{alarmdefactionrel.Alarmactionid},{alarmdefactionrel.Siteid}", alarmDefActionRel4Update.Isusable);
			alarmDefActionRel4Update.Isusable = "UnUsable";
			alarmdefactionrel.CopyCommonFieldUpdatePrev(alarmDefActionRel4Update, systemTime, dbContext.Tid, text);
			alarmdefactionrel.CopyExtensionCollection(alarmDefActionRel4Update);
			list.Add(alarmDefActionRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteAlarmDefActionRel(IDbContext dbContext, Alarmdefactionrel[] alarmDefActionRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmDefActionRelList", alarmDefActionRelList);
		string text = "UnDeleteAlarmDefActionRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarmdefactionrel> list = new List<Alarmdefactionrel>();
		foreach (Alarmdefactionrel alarmdefactionrel in alarmDefActionRelList)
		{
			Alarmdefactionrel alarmDefActionRel4Update = GetAlarmDefActionRel4Update(dbContext, alarmdefactionrel.Alarmdefinitionid, alarmdefactionrel.Alarmsourceid, alarmdefactionrel.Alarmtype, alarmdefactionrel.Alarmactionid, alarmdefactionrel.Siteid);
			if (alarmDefActionRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Alarmdefactionrel), $"{alarmdefactionrel.Alarmdefinitionid},{alarmdefactionrel.Alarmsourceid},{alarmdefactionrel.Alarmtype},{alarmdefactionrel.Alarmactionid},{alarmdefactionrel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Alarmdefactionrel), $"{alarmdefactionrel.Alarmdefinitionid},{alarmdefactionrel.Alarmsourceid},{alarmdefactionrel.Alarmtype},{alarmdefactionrel.Alarmactionid},{alarmdefactionrel.Siteid}", alarmDefActionRel4Update.Isusable);
			alarmDefActionRel4Update.Isusable = "Usable";
			alarmdefactionrel.CopyCommonFieldUpdatePrev(alarmDefActionRel4Update, systemTime, dbContext.Tid, text);
			alarmdefactionrel.CopyExtensionCollection(alarmDefActionRel4Update);
			list.Add(alarmDefActionRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteAlarmDefActionRel(IDbContext dbContext, Alarmdefactionrel[] alarmDefActionRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmDefActionRelList", alarmDefActionRelList);
		string text = "RealDeleteAlarmDefActionRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarmdefactionrel> list = new List<Alarmdefactionrel>();
		foreach (Alarmdefactionrel alarmdefactionrel in alarmDefActionRelList)
		{
			Alarmdefactionrel alarmDefActionRel4Update = GetAlarmDefActionRel4Update(dbContext, alarmdefactionrel.Alarmdefinitionid, alarmdefactionrel.Alarmsourceid, alarmdefactionrel.Alarmtype, alarmdefactionrel.Alarmactionid, alarmdefactionrel.Siteid);
			if (alarmDefActionRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Alarmdefactionrel), $"{alarmdefactionrel.Alarmdefinitionid},{alarmdefactionrel.Alarmsourceid},{alarmdefactionrel.Alarmtype},{alarmdefactionrel.Alarmactionid},{alarmdefactionrel.Siteid}");
			}
			alarmdefactionrel.CopyCommonFieldUpdatePrev(alarmDefActionRel4Update, systemTime, dbContext.Tid, text);
			alarmdefactionrel.CopyExtensionCollection(alarmDefActionRel4Update);
			list.Add(alarmDefActionRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static IList<Alarmdefactionrel> GetAlarmDefActionRelWithDynamicCondition(IDbContext dbContext, Dictionary<string, string> dynamicCondition, string siteid)
	{
		string apiName = "GetAlarmDefActionRelWithDynamicCondition";
		string strKeyFieldInfo = string.Join(",", dynamicCondition.ToArray());
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{strKeyFieldInfo},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetAlarmDefActionRelSqlDatabaseDynamicCondition : _sqlGetAlarmDefActionRelOracleDatabaseDynamicCondition);
		sql = SpcUtil.AddSqlCondition(dbContext.DbType.ToString(), sql, dynamicCondition);
		List<MesParameter> parameters = new List<MesParameter>();
		dynamicCondition.Add("SITEID", siteid);
		ExtendCondition(dbContext, dynamicCondition, out parameters, out strKeyFieldInfo);
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_ALARMDEFACTIONREL", $"{strKeyFieldInfo},{siteid}"));
		}
		IList<Alarmdefactionrel> result = ContextManager.DirectEntityQuery<Alarmdefactionrel>(dbContext, sql, parameters.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{strKeyFieldInfo},{siteid}");
		}
		return result;
	}

	public static IList<Alarmdefactionrel> SelectAlarmDefActionRelWithDynamicCondition(IDbContext dbContext, Dictionary<string, string> dynamicCondition, string siteid)
	{
		string apiName = "SelectAlarmDefActionRel";
		string strKeyFieldInfo = string.Join(",", dynamicCondition.ToArray());
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{strKeyFieldInfo},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectAlarmDefActionRelSqlDatabaseDynamicCondition : _sqlSelectAlarmDefActionRelOracleDatabaseDynamicCondition);
		sql = SpcUtil.AddSqlCondition(dbContext.DbType.ToString(), sql, dynamicCondition);
		dynamicCondition.Add("SITEID", siteid);
		ExtendCondition(dbContext, dynamicCondition, out var parameters, out strKeyFieldInfo);
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_ALARMDEFACTIONREL", $"{strKeyFieldInfo},{siteid}"));
		}
		IList<Alarmdefactionrel> result = ContextManager.DirectEntityQuery<Alarmdefactionrel>(dbContext, sql, parameters.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{strKeyFieldInfo},{siteid}");
		}
		return result;
	}

	private static void ExtendCondition(IDbContext dbContext, Dictionary<string, string> dynamicCondition, out List<MesParameter> parameters, out string strKeyFieldInfo)
	{
		parameters = new List<MesParameter>();
		List<string> list = new List<string>();
		strKeyFieldInfo = null;
		foreach (string key in dynamicCondition.Keys)
		{
			parameters.Add(dbContext.CreateParameter(key, dynamicCondition[key], typeOfThis));
			list.Add(key + ":" + dynamicCondition[key]);
		}
		strKeyFieldInfo = string.Join(",", list.ToArray());
	}
}
