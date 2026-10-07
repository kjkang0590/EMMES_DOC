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
public class TROUBLESTEP
{
	private static string _sqlGetTroubleStepSqlDatabase = "SELECT * FROM CIM_TROUBLESTEP WHERE TROUBLESTEPID=@TROUBLESTEPID AND SITEID=@SITEID";

	private static string _sqlGetTroubleStep4UpdateSqlDatabase = "SELECT * FROM CIM_TROUBLESTEP WITH(UPDLOCK) WHERE TROUBLESTEPID=@TROUBLESTEPID AND SITEID=@SITEID";

	private static string _sqlSelectTroubleStepSqlDatabase = "SELECT * FROM CIM_TROUBLESTEP WHERE TROUBLESTEPID=@TROUBLESTEPID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectTroubleStep4UpdateSqlDatabase = "SELECT * FROM CIM_TROUBLESTEP WITH(UPDLOCK) WHERE TROUBLESTEPID=@TROUBLESTEPID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetTroubleStepOracleDatabase = "SELECT * FROM CIM_TROUBLESTEP WHERE TROUBLESTEPID=:TROUBLESTEPID AND SITEID=:SITEID";

	private static string _sqlGetTroubleStep4UpdateOracleDatabase = "SELECT * FROM CIM_TROUBLESTEP WHERE TROUBLESTEPID=:TROUBLESTEPID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectTroubleStepOracleDatabase = "SELECT * FROM CIM_TROUBLESTEP WHERE TROUBLESTEPID=:TROUBLESTEPID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectTroubleStep4UpdateOracleDatabase = "SELECT * FROM CIM_TROUBLESTEP WHERE TROUBLESTEPID=:TROUBLESTEPID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Troublestep);

	public static Troublestep GetTroubleStep(IDbContext dbContext, string troublestepid, string siteid)
	{
		string apiName = "GetTroubleStep";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{troublestepid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetTroubleStepSqlDatabase : _sqlGetTroubleStepOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TROUBLESTEPID", troublestepid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_TROUBLESTEP", $"{troublestepid},{siteid}"));
		}
		Troublestep? result = ContextManager.DirectEntityQuery<Troublestep>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{troublestepid},{siteid}");
		}
		return result;
	}

	public static Troublestep GetTroubleStep4Update(IDbContext dbContext, string troublestepid, string siteid)
	{
		string apiName = "GetTroubleStep4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{troublestepid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetTroubleStep4UpdateSqlDatabase : _sqlGetTroubleStep4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TROUBLESTEPID", troublestepid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_TROUBLESTEP", $"{troublestepid},{siteid}"));
		}
		Troublestep? result = ContextManager.DirectEntityQuery<Troublestep>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{troublestepid},{siteid}");
		}
		return result;
	}

	public static Troublestep SelectTroubleStep(IDbContext dbContext, string troublestepid, string siteid)
	{
		string apiName = "SelectTroubleStep";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{troublestepid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectTroubleStepSqlDatabase : _sqlSelectTroubleStepOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TROUBLESTEPID", troublestepid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_TROUBLESTEP", $"{troublestepid},{siteid}"));
		}
		Troublestep? result = ContextManager.DirectEntityQuery<Troublestep>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{troublestepid},{siteid}");
		}
		return result;
	}

	public static Troublestep SelectTroubleStep4Update(IDbContext dbContext, string troublestepid, string siteid)
	{
		string apiName = "SelectTroubleStep4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{troublestepid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectTroubleStep4UpdateSqlDatabase : _sqlSelectTroubleStep4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TROUBLESTEPID", troublestepid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_TROUBLESTEP", $"{troublestepid},{siteid}"));
		}
		Troublestep? result = ContextManager.DirectEntityQuery<Troublestep>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{troublestepid},{siteid}");
		}
		return result;
	}

	public static int UpsertTroubleStep(IDbContext dbContext, RequestType requestType, Troublestep[] troubleStepList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateTroubleStepInternal(dbContext, troubleStepList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateTroubleStep(dbContext, troubleStepList, optionSet, saveHist), 
			RequestType.DELETE => DeleteTroubleStep(dbContext, troubleStepList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteTroubleStep(dbContext, troubleStepList, optionSet, saveHist), 
			_ => RealDeleteTroubleStep(dbContext, troubleStepList, optionSet, saveHist), 
		};
	}

	private static int CreateTroubleStepInternal(IDbContext dbContext, Troublestep[] troubleStepList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("troubleStepList", troubleStepList);
		string text = "CreateTroubleStep";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Troublestep> list = new List<Troublestep>();
		foreach (Troublestep obj in troubleStepList)
		{
			Troublestep troublestep = new Troublestep();
			obj.CopyColumsTo(troublestep);
			troublestep.Activity = text;
			troublestep.CheckEntityUsable();
			obj.CopyCommonField(troublestep, systemTime, dbContext.Tid, isCreate: true);
			list.Add(troublestep);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateTroubleStep(IDbContext dbContext, Troublestep[] troubleStepList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("troubleStepList", troubleStepList);
		string text = "UpdateTroubleStep";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Troublestep> list = new List<Troublestep>();
		foreach (Troublestep troublestep in troubleStepList)
		{
			Troublestep troubleStep4Update = GetTroubleStep4Update(dbContext, troublestep.Troublestepid, troublestep.Siteid);
			if (troubleStep4Update == null)
			{
				throw new EntityNotFoundException(typeof(Troublestep), $"{troublestep.Troublestepid},{troublestep.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Troublestep), $"{troublestep.Troublestepid},{troublestep.Siteid}", troubleStep4Update.Isusable);
			string activity = troubleStep4Update.Activity;
			string customactivity = troubleStep4Update.Customactivity;
			string isusable = troubleStep4Update.Isusable;
			DateTime? createtime = troubleStep4Update.Createtime;
			string creator = troubleStep4Update.Creator;
			troublestep.CopyColumsTo(troubleStep4Update);
			troubleStep4Update.Prevactivity = activity;
			troubleStep4Update.Prevcustomactivity = customactivity;
			troubleStep4Update.Creator = creator;
			troubleStep4Update.Createtime = createtime;
			troubleStep4Update.Isusable = isusable;
			troubleStep4Update.Activity = text;
			troublestep.CopyCommonField(troubleStep4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(troubleStep4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteTroubleStep(IDbContext dbContext, Troublestep[] troubleStepList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("troubleStepList", troubleStepList);
		string text = "DeleteTroubleStep";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Troublestep> list = new List<Troublestep>();
		foreach (Troublestep troublestep in troubleStepList)
		{
			Troublestep troubleStep4Update = GetTroubleStep4Update(dbContext, troublestep.Troublestepid, troublestep.Siteid);
			if (troubleStep4Update == null)
			{
				throw new EntityNotFoundException(typeof(Troublestep), $"{troublestep.Troublestepid},{troublestep.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Troublestep), $"{troublestep.Troublestepid},{troublestep.Siteid}", troubleStep4Update.Isusable);
			troubleStep4Update.Isusable = "UnUsable";
			troublestep.CopyCommonFieldUpdatePrev(troubleStep4Update, systemTime, dbContext.Tid, text);
			troublestep.CopyExtensionCollection(troubleStep4Update);
			list.Add(troubleStep4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteTroubleStep(IDbContext dbContext, Troublestep[] troubleStepList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("troubleStepList", troubleStepList);
		string text = "UnDeleteTroubleStep";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Troublestep> list = new List<Troublestep>();
		foreach (Troublestep troublestep in troubleStepList)
		{
			Troublestep troubleStep4Update = GetTroubleStep4Update(dbContext, troublestep.Troublestepid, troublestep.Siteid);
			if (troubleStep4Update == null)
			{
				throw new EntityNotFoundException(typeof(Troublestep), $"{troublestep.Troublestepid},{troublestep.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Troublestep), $"{troublestep.Troublestepid},{troublestep.Siteid}", troubleStep4Update.Isusable);
			troubleStep4Update.Isusable = "Usable";
			troublestep.CopyCommonFieldUpdatePrev(troubleStep4Update, systemTime, dbContext.Tid, text);
			troublestep.CopyExtensionCollection(troubleStep4Update);
			list.Add(troubleStep4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteTroubleStep(IDbContext dbContext, Troublestep[] troubleStepList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("troubleStepList", troubleStepList);
		string text = "RealDeleteTroubleStep";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Troublestep> list = new List<Troublestep>();
		foreach (Troublestep troublestep in troubleStepList)
		{
			Troublestep troubleStep4Update = GetTroubleStep4Update(dbContext, troublestep.Troublestepid, troublestep.Siteid);
			if (troubleStep4Update == null)
			{
				throw new EntityNotFoundException(typeof(Troublestep), $"{troublestep.Troublestepid},{troublestep.Siteid}");
			}
			troublestep.CopyCommonFieldUpdatePrev(troubleStep4Update, systemTime, dbContext.Tid, text);
			troublestep.CopyExtensionCollection(troubleStep4Update);
			list.Add(troubleStep4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
