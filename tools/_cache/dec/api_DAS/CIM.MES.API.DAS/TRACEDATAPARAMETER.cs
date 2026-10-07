using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.DAS;

[MESAPI]
public class TRACEDATAPARAMETER
{
	private static string _sqlListTraceDataParameterSqlDatabase = "SELECT * FROM CIM_TRACEDATAPARAMETER WHERE TRACEDATADEFINITIONID=@TRACEDATADEFINITIONID AND SITEID=@SITEID";

	private static string _sqlListTraceDataParameterOracleDatabase = "SELECT * FROM CIM_TRACEDATAPARAMETER WHERE TRACEDATADEFINITIONID=:TRACEDATADEFINITIONID AND SITEID=:SITEID";

	private static Type typeOfThis = typeof(Tracedataparameter);

	private static string _sqlGetTraceDataParameterSqlDatabase = "SELECT * FROM CIM_TRACEDATAPARAMETER WHERE TRACEDATAPARAMETERID=@TRACEDATAPARAMETERID AND TRACEDATADEFINITIONID=@TRACEDATADEFINITIONID AND SITEID=@SITEID";

	private static string _sqlGetTraceDataParameter4UpdateSqlDatabase = "SELECT * FROM CIM_TRACEDATAPARAMETER WITH(UPDLOCK) WHERE TRACEDATAPARAMETERID=@TRACEDATAPARAMETERID AND TRACEDATADEFINITIONID=@TRACEDATADEFINITIONID AND SITEID=@SITEID";

	private static string _sqlSelectTraceDataParameterSqlDatabase = "SELECT * FROM CIM_TRACEDATAPARAMETER WHERE TRACEDATAPARAMETERID=@TRACEDATAPARAMETERID AND TRACEDATADEFINITIONID=@TRACEDATADEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectTraceDataParameter4UpdateSqlDatabase = "SELECT * FROM CIM_TRACEDATAPARAMETER WITH(UPDLOCK) WHERE TRACEDATAPARAMETERID=@TRACEDATAPARAMETERID AND TRACEDATADEFINITIONID=@TRACEDATADEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetTraceDataParameterOracleDatabase = "SELECT * FROM CIM_TRACEDATAPARAMETER WHERE TRACEDATAPARAMETERID=:TRACEDATAPARAMETERID AND TRACEDATADEFINITIONID=:TRACEDATADEFINITIONID AND SITEID=:SITEID";

	private static string _sqlGetTraceDataParameter4UpdateOracleDatabase = "SELECT * FROM CIM_TRACEDATAPARAMETER WHERE TRACEDATAPARAMETERID=:TRACEDATAPARAMETERID AND TRACEDATADEFINITIONID=:TRACEDATADEFINITIONID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectTraceDataParameterOracleDatabase = "SELECT * FROM CIM_TRACEDATAPARAMETER WHERE TRACEDATAPARAMETERID=:TRACEDATAPARAMETERID AND TRACEDATADEFINITIONID=:TRACEDATADEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectTraceDataParameter4UpdateOracleDatabase = "SELECT * FROM CIM_TRACEDATAPARAMETER WHERE TRACEDATAPARAMETERID=:TRACEDATAPARAMETERID AND TRACEDATADEFINITIONID=:TRACEDATADEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	public static IList<Tracedataparameter> SelectTraceDataParameter(IDbContext dbContext, string tracedatadefinitionid, string siteid)
	{
		string apiName = "SelectTraceDataParameter";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tracedatadefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlListTraceDataParameterSqlDatabase : _sqlListTraceDataParameterOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TRACEDATADEFINITIONID", tracedatadefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_TRACEDATAPARAMETER", $"{tracedatadefinitionid},{siteid}"));
		}
		IList<Tracedataparameter> result = ContextManager.DirectEntityQuery<Tracedataparameter>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tracedatadefinitionid},{siteid}");
		}
		return result;
	}

	public static Tracedataparameter GetTraceDataParameter(IDbContext dbContext, string tracedataparameterid, string tracedatadefinitionid, string siteid)
	{
		string apiName = "GetTraceDataParameter";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tracedataparameterid},{tracedatadefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetTraceDataParameterSqlDatabase : _sqlGetTraceDataParameterOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TRACEDATAPARAMETERID", tracedataparameterid, typeOfThis));
		list.Add(dbContext.CreateParameter("TRACEDATADEFINITIONID", tracedatadefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_TRACEDATAPARAMETER", $"{tracedataparameterid},{tracedatadefinitionid},{siteid}"));
		}
		Tracedataparameter? result = ContextManager.DirectEntityQuery<Tracedataparameter>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tracedataparameterid},{tracedatadefinitionid},{siteid}");
		}
		return result;
	}

	public static Tracedataparameter GetTraceDataParameter4Update(IDbContext dbContext, string tracedataparameterid, string tracedatadefinitionid, string siteid)
	{
		string apiName = "GetTraceDataParameter4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tracedataparameterid},{tracedatadefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetTraceDataParameter4UpdateSqlDatabase : _sqlGetTraceDataParameter4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TRACEDATAPARAMETERID", tracedataparameterid, typeOfThis));
		list.Add(dbContext.CreateParameter("TRACEDATADEFINITIONID", tracedatadefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_TRACEDATAPARAMETER", $"{tracedataparameterid},{tracedatadefinitionid},{siteid}"));
		}
		Tracedataparameter? result = ContextManager.DirectEntityQuery<Tracedataparameter>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tracedataparameterid},{tracedatadefinitionid},{siteid}");
		}
		return result;
	}

	public static Tracedataparameter SelectTraceDataParameter(IDbContext dbContext, string tracedataparameterid, string tracedatadefinitionid, string siteid)
	{
		string apiName = "SelectTraceDataParameter";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tracedataparameterid},{tracedatadefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectTraceDataParameterSqlDatabase : _sqlSelectTraceDataParameterOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TRACEDATAPARAMETERID", tracedataparameterid, typeOfThis));
		list.Add(dbContext.CreateParameter("TRACEDATADEFINITIONID", tracedatadefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_TRACEDATAPARAMETER", $"{tracedataparameterid},{tracedatadefinitionid},{siteid}"));
		}
		Tracedataparameter? result = ContextManager.DirectEntityQuery<Tracedataparameter>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tracedataparameterid},{tracedatadefinitionid},{siteid}");
		}
		return result;
	}

	public static Tracedataparameter SelectTraceDataParameter4Update(IDbContext dbContext, string tracedataparameterid, string tracedatadefinitionid, string siteid)
	{
		string apiName = "SelectTraceDataParameter4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tracedataparameterid},{tracedatadefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectTraceDataParameter4UpdateSqlDatabase : _sqlSelectTraceDataParameter4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TRACEDATAPARAMETERID", tracedataparameterid, typeOfThis));
		list.Add(dbContext.CreateParameter("TRACEDATADEFINITIONID", tracedatadefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_TRACEDATAPARAMETER", $"{tracedataparameterid},{tracedatadefinitionid},{siteid}"));
		}
		Tracedataparameter? result = ContextManager.DirectEntityQuery<Tracedataparameter>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tracedataparameterid},{tracedatadefinitionid},{siteid}");
		}
		return result;
	}

	public static int UpsertTraceDataParameter(IDbContext dbContext, RequestType requestType, Tracedataparameter[] traceDataParameterList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateTraceDataParameterInternal(dbContext, traceDataParameterList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateTraceDataParameter(dbContext, traceDataParameterList, optionSet, saveHist), 
			RequestType.DELETE => DeleteTraceDataParameter(dbContext, traceDataParameterList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteTraceDataParameter(dbContext, traceDataParameterList, optionSet, saveHist), 
			_ => RealDeleteTraceDataParameter(dbContext, traceDataParameterList, optionSet, saveHist), 
		};
	}

	private static int CreateTraceDataParameterInternal(IDbContext dbContext, Tracedataparameter[] traceDataParameterList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceDataParameterList", traceDataParameterList);
		string text = "CreateTraceDataParameter";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tracedataparameter> list = new List<Tracedataparameter>();
		foreach (Tracedataparameter obj in traceDataParameterList)
		{
			Tracedataparameter tracedataparameter = new Tracedataparameter();
			obj.CopyColumsTo(tracedataparameter);
			tracedataparameter.Activity = text;
			tracedataparameter.CheckEntityUsable();
			obj.CopyCommonField(tracedataparameter, systemTime, dbContext.Tid, isCreate: true);
			list.Add(tracedataparameter);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateTraceDataParameter(IDbContext dbContext, Tracedataparameter[] traceDataParameterList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceDataParameterList", traceDataParameterList);
		string text = "UpdateTraceDataParameter";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tracedataparameter> list = new List<Tracedataparameter>();
		foreach (Tracedataparameter tracedataparameter in traceDataParameterList)
		{
			Tracedataparameter traceDataParameter4Update = GetTraceDataParameter4Update(dbContext, tracedataparameter.Tracedataparameterid, tracedataparameter.Tracedatadefinitionid, tracedataparameter.Siteid);
			if (traceDataParameter4Update == null)
			{
				throw new EntityNotFoundException(typeof(Tracedataparameter), $"{tracedataparameter.Tracedataparameterid},{tracedataparameter.Tracedatadefinitionid},{tracedataparameter.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Tracedataparameter), $"{tracedataparameter.Tracedataparameterid},{tracedataparameter.Tracedatadefinitionid},{tracedataparameter.Siteid}", traceDataParameter4Update.Isusable);
			string activity = traceDataParameter4Update.Activity;
			string customactivity = traceDataParameter4Update.Customactivity;
			string isusable = traceDataParameter4Update.Isusable;
			DateTime? createtime = traceDataParameter4Update.Createtime;
			string creator = traceDataParameter4Update.Creator;
			tracedataparameter.CopyColumsTo(traceDataParameter4Update);
			traceDataParameter4Update.Prevactivity = activity;
			traceDataParameter4Update.Prevcustomactivity = customactivity;
			traceDataParameter4Update.Creator = creator;
			traceDataParameter4Update.Createtime = createtime;
			traceDataParameter4Update.Isusable = isusable;
			traceDataParameter4Update.Activity = text;
			tracedataparameter.CopyCommonField(traceDataParameter4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(traceDataParameter4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteTraceDataParameter(IDbContext dbContext, Tracedataparameter[] traceDataParameterList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceDataParameterList", traceDataParameterList);
		string text = "DeleteTraceDataParameter";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tracedataparameter> list = new List<Tracedataparameter>();
		foreach (Tracedataparameter tracedataparameter in traceDataParameterList)
		{
			Tracedataparameter traceDataParameter4Update = GetTraceDataParameter4Update(dbContext, tracedataparameter.Tracedataparameterid, tracedataparameter.Tracedatadefinitionid, tracedataparameter.Siteid);
			if (traceDataParameter4Update == null)
			{
				throw new EntityNotFoundException(typeof(Tracedataparameter), $"{tracedataparameter.Tracedataparameterid},{tracedataparameter.Tracedatadefinitionid},{tracedataparameter.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Tracedataparameter), $"{tracedataparameter.Tracedataparameterid},{tracedataparameter.Tracedatadefinitionid},{tracedataparameter.Siteid}", traceDataParameter4Update.Isusable);
			traceDataParameter4Update.Isusable = "UnUsable";
			tracedataparameter.CopyCommonFieldUpdatePrev(traceDataParameter4Update, systemTime, dbContext.Tid, text);
			tracedataparameter.CopyExtensionCollection(traceDataParameter4Update);
			list.Add(traceDataParameter4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteTraceDataParameter(IDbContext dbContext, Tracedataparameter[] traceDataParameterList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceDataParameterList", traceDataParameterList);
		string text = "UnDeleteTraceDataParameter";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tracedataparameter> list = new List<Tracedataparameter>();
		foreach (Tracedataparameter tracedataparameter in traceDataParameterList)
		{
			Tracedataparameter traceDataParameter4Update = GetTraceDataParameter4Update(dbContext, tracedataparameter.Tracedataparameterid, tracedataparameter.Tracedatadefinitionid, tracedataparameter.Siteid);
			if (traceDataParameter4Update == null)
			{
				throw new EntityNotFoundException(typeof(Tracedataparameter), $"{tracedataparameter.Tracedataparameterid},{tracedataparameter.Tracedatadefinitionid},{tracedataparameter.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Tracedataparameter), $"{tracedataparameter.Tracedataparameterid},{tracedataparameter.Tracedatadefinitionid},{tracedataparameter.Siteid}", traceDataParameter4Update.Isusable);
			traceDataParameter4Update.Isusable = "Usable";
			tracedataparameter.CopyCommonFieldUpdatePrev(traceDataParameter4Update, systemTime, dbContext.Tid, text);
			tracedataparameter.CopyExtensionCollection(traceDataParameter4Update);
			list.Add(traceDataParameter4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteTraceDataParameter(IDbContext dbContext, Tracedataparameter[] traceDataParameterList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("traceDataParameterList", traceDataParameterList);
		string text = "RealDeleteTraceDataParameter";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tracedataparameter> list = new List<Tracedataparameter>();
		foreach (Tracedataparameter tracedataparameter in traceDataParameterList)
		{
			Tracedataparameter traceDataParameter4Update = GetTraceDataParameter4Update(dbContext, tracedataparameter.Tracedataparameterid, tracedataparameter.Tracedatadefinitionid, tracedataparameter.Siteid);
			if (traceDataParameter4Update == null)
			{
				throw new EntityNotFoundException(typeof(Tracedataparameter), $"{tracedataparameter.Tracedataparameterid},{tracedataparameter.Tracedatadefinitionid},{tracedataparameter.Siteid}");
			}
			tracedataparameter.CopyCommonFieldUpdatePrev(traceDataParameter4Update, systemTime, dbContext.Tid, text);
			tracedataparameter.CopyExtensionCollection(traceDataParameter4Update);
			list.Add(traceDataParameter4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
