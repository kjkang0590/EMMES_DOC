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
public class TROUBLESTEPREL
{
	private static string _sqlGetTroubleStepRelSqlDatabase = "SELECT * FROM CIM_TROUBLESTEPREL WHERE RELATIONID=@RELATIONID AND TROUBLEID=@TROUBLEID AND TROUBLESTEPID=@TROUBLESTEPID AND TROUBLEDEFINITIONID=@TROUBLEDEFINITIONID AND SITEID=@SITEID";

	private static string _sqlGetTroubleStepRel4UpdateSqlDatabase = "SELECT * FROM CIM_TROUBLESTEPREL WITH(UPDLOCK) WHERE RELATIONID=@RELATIONID AND TROUBLEID=@TROUBLEID AND TROUBLESTEPID=@TROUBLESTEPID AND TROUBLEDEFINITIONID=@TROUBLEDEFINITIONID AND SITEID=@SITEID";

	private static string _sqlSelectTroubleStepRelSqlDatabase = "SELECT * FROM CIM_TROUBLESTEPREL WHERE RELATIONID=@RELATIONID AND TROUBLEID=@TROUBLEID AND TROUBLESTEPID=@TROUBLESTEPID AND TROUBLEDEFINITIONID=@TROUBLEDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectTroubleStepRel4UpdateSqlDatabase = "SELECT * FROM CIM_TROUBLESTEPREL WITH(UPDLOCK) WHERE RELATIONID=@RELATIONID AND TROUBLEID=@TROUBLEID AND TROUBLESTEPID=@TROUBLESTEPID AND TROUBLEDEFINITIONID=@TROUBLEDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetTroubleStepRelOracleDatabase = "SELECT * FROM CIM_TROUBLESTEPREL WHERE RELATIONID=:RELATIONID AND TROUBLEID=:TROUBLEID AND TROUBLESTEPID=:TROUBLESTEPID AND TROUBLEDEFINITIONID=:TROUBLEDEFINITIONID AND SITEID=:SITEID";

	private static string _sqlGetTroubleStepRel4UpdateOracleDatabase = "SELECT * FROM CIM_TROUBLESTEPREL WHERE RELATIONID=:RELATIONID AND TROUBLEID=:TROUBLEID AND TROUBLESTEPID=:TROUBLESTEPID AND TROUBLEDEFINITIONID=:TROUBLEDEFINITIONID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectTroubleStepRelOracleDatabase = "SELECT * FROM CIM_TROUBLESTEPREL WHERE RELATIONID=:RELATIONID AND TROUBLEID=:TROUBLEID AND TROUBLESTEPID=:TROUBLESTEPID AND TROUBLEDEFINITIONID=:TROUBLEDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectTroubleStepRel4UpdateOracleDatabase = "SELECT * FROM CIM_TROUBLESTEPREL WHERE RELATIONID=:RELATIONID AND TROUBLEID=:TROUBLEID AND TROUBLESTEPID=:TROUBLESTEPID AND TROUBLEDEFINITIONID=:TROUBLEDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Troublesteprel);

	public static Troublesteprel GetTroubleStepRel(IDbContext dbContext, string relationid, string troubleid, string troublestepid, string troubledefinitionid, string siteid)
	{
		string apiName = "GetTroubleStepRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{relationid},{troubleid},{troublestepid},{troubledefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetTroubleStepRelSqlDatabase : _sqlGetTroubleStepRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RELATIONID", relationid, typeOfThis));
		list.Add(dbContext.CreateParameter("TROUBLEID", troubleid, typeOfThis));
		list.Add(dbContext.CreateParameter("TROUBLESTEPID", troublestepid, typeOfThis));
		list.Add(dbContext.CreateParameter("TROUBLEDEFINITIONID", troubledefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_TROUBLESTEPREL", $"{relationid},{troubleid},{troublestepid},{troubledefinitionid},{siteid}"));
		}
		Troublesteprel result = ContextManager.DirectEntityQuery<Troublesteprel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{relationid},{troubleid},{troublestepid},{troubledefinitionid},{siteid}");
		}
		return result;
	}

	public static Troublesteprel GetTroubleStepRel4Update(IDbContext dbContext, string relationid, string troubleid, string troublestepid, string troubledefinitionid, string siteid)
	{
		string apiName = "GetTroubleStepRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{relationid},{troubleid},{troublestepid},{troubledefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetTroubleStepRel4UpdateSqlDatabase : _sqlGetTroubleStepRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RELATIONID", relationid, typeOfThis));
		list.Add(dbContext.CreateParameter("TROUBLEID", troubleid, typeOfThis));
		list.Add(dbContext.CreateParameter("TROUBLESTEPID", troublestepid, typeOfThis));
		list.Add(dbContext.CreateParameter("TROUBLEDEFINITIONID", troubledefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_TROUBLESTEPREL", $"{relationid},{troubleid},{troublestepid},{troubledefinitionid},{siteid}"));
		}
		Troublesteprel result = ContextManager.DirectEntityQuery<Troublesteprel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{relationid},{troubleid},{troublestepid},{troubledefinitionid},{siteid}");
		}
		return result;
	}

	public static Troublesteprel SelectTroubleStepRel(IDbContext dbContext, string relationid, string troubleid, string troublestepid, string troubledefinitionid, string siteid)
	{
		string apiName = "SelectTroubleStepRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{relationid},{troubleid},{troublestepid},{troubledefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectTroubleStepRelSqlDatabase : _sqlSelectTroubleStepRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RELATIONID", relationid, typeOfThis));
		list.Add(dbContext.CreateParameter("TROUBLEID", troubleid, typeOfThis));
		list.Add(dbContext.CreateParameter("TROUBLESTEPID", troublestepid, typeOfThis));
		list.Add(dbContext.CreateParameter("TROUBLEDEFINITIONID", troubledefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_TROUBLESTEPREL", $"{relationid},{troubleid},{troublestepid},{troubledefinitionid},{siteid}"));
		}
		Troublesteprel result = ContextManager.DirectEntityQuery<Troublesteprel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{relationid},{troubleid},{troublestepid},{troubledefinitionid},{siteid}");
		}
		return result;
	}

	public static Troublesteprel SelectTroubleStepRel4Update(IDbContext dbContext, string relationid, string troubleid, string troublestepid, string troubledefinitionid, string siteid)
	{
		string apiName = "SelectTroubleStepRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{relationid},{troubleid},{troublestepid},{troubledefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectTroubleStepRel4UpdateSqlDatabase : _sqlSelectTroubleStepRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RELATIONID", relationid, typeOfThis));
		list.Add(dbContext.CreateParameter("TROUBLEID", troubleid, typeOfThis));
		list.Add(dbContext.CreateParameter("TROUBLESTEPID", troublestepid, typeOfThis));
		list.Add(dbContext.CreateParameter("TROUBLEDEFINITIONID", troubledefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_TROUBLESTEPREL", $"{relationid},{troubleid},{troublestepid},{troubledefinitionid},{siteid}"));
		}
		Troublesteprel result = ContextManager.DirectEntityQuery<Troublesteprel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{relationid},{troubleid},{troublestepid},{troubledefinitionid},{siteid}");
		}
		return result;
	}

	public static int UpsertTroubleStepRel(IDbContext dbContext, RequestType requestType, Troublesteprel[] troubleStepRelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateTroubleStepRelInternal(dbContext, troubleStepRelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateTroubleStepRel(dbContext, troubleStepRelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteTroubleStepRel(dbContext, troubleStepRelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteTroubleStepRel(dbContext, troubleStepRelList, optionSet, saveHist), 
			_ => RealDeleteTroubleStepRel(dbContext, troubleStepRelList, optionSet, saveHist), 
		};
	}

	private static int CreateTroubleStepRelInternal(IDbContext dbContext, Troublesteprel[] troubleStepRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("troubleStepRelList", troubleStepRelList);
		string text = "CreateTroubleStepRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Troublesteprel> list = new List<Troublesteprel>();
		foreach (Troublesteprel obj in troubleStepRelList)
		{
			Troublesteprel troublesteprel = new Troublesteprel();
			obj.CopyColumsTo(troublesteprel);
			troublesteprel.Activity = text;
			troublesteprel.CheckEntityUsable();
			obj.CopyCommonField(troublesteprel, systemTime, dbContext.Tid, isCreate: true);
			list.Add(troublesteprel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateTroubleStepRel(IDbContext dbContext, Troublesteprel[] troubleStepRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("troubleStepRelList", troubleStepRelList);
		string text = "UpdateTroubleStepRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Troublesteprel> list = new List<Troublesteprel>();
		foreach (Troublesteprel troublesteprel in troubleStepRelList)
		{
			Troublesteprel troubleStepRel4Update = GetTroubleStepRel4Update(dbContext, troublesteprel.Relationid, troublesteprel.Troubleid, troublesteprel.Troublestepid, troublesteprel.Troubledefinitionid, troublesteprel.Siteid);
			if (troubleStepRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Troublesteprel), $"{troublesteprel.Relationid},{troublesteprel.Troubleid},{troublesteprel.Troublestepid},{troublesteprel.Troubledefinitionid},{troublesteprel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Troublesteprel), $"{troublesteprel.Relationid},{troublesteprel.Troubleid},{troublesteprel.Troublestepid},{troublesteprel.Troubledefinitionid},{troublesteprel.Siteid}", troubleStepRel4Update.Isusable);
			string activity = troubleStepRel4Update.Activity;
			string customactivity = troubleStepRel4Update.Customactivity;
			string isusable = troubleStepRel4Update.Isusable;
			DateTime? createtime = troubleStepRel4Update.Createtime;
			string creator = troubleStepRel4Update.Creator;
			troublesteprel.CopyColumsTo(troubleStepRel4Update);
			troubleStepRel4Update.Prevactivity = activity;
			troubleStepRel4Update.Prevcustomactivity = customactivity;
			troubleStepRel4Update.Creator = creator;
			troubleStepRel4Update.Createtime = createtime;
			troubleStepRel4Update.Isusable = isusable;
			troubleStepRel4Update.Activity = text;
			troublesteprel.CopyCommonField(troubleStepRel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(troubleStepRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteTroubleStepRel(IDbContext dbContext, Troublesteprel[] troubleStepRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("troubleStepRelList", troubleStepRelList);
		string text = "DeleteTroubleStepRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Troublesteprel> list = new List<Troublesteprel>();
		foreach (Troublesteprel troublesteprel in troubleStepRelList)
		{
			Troublesteprel troubleStepRel4Update = GetTroubleStepRel4Update(dbContext, troublesteprel.Relationid, troublesteprel.Troubleid, troublesteprel.Troublestepid, troublesteprel.Troubledefinitionid, troublesteprel.Siteid);
			if (troubleStepRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Troublesteprel), $"{troublesteprel.Relationid},{troublesteprel.Troubleid},{troublesteprel.Troublestepid},{troublesteprel.Troubledefinitionid},{troublesteprel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Troublesteprel), $"{troublesteprel.Relationid},{troublesteprel.Troubleid},{troublesteprel.Troublestepid},{troublesteprel.Troubledefinitionid},{troublesteprel.Siteid}", troubleStepRel4Update.Isusable);
			troubleStepRel4Update.Isusable = "UnUsable";
			troublesteprel.CopyCommonFieldUpdatePrev(troubleStepRel4Update, systemTime, dbContext.Tid, text);
			troublesteprel.CopyExtensionCollection(troubleStepRel4Update);
			list.Add(troubleStepRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteTroubleStepRel(IDbContext dbContext, Troublesteprel[] troubleStepRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("troubleStepRelList", troubleStepRelList);
		string text = "UnDeleteTroubleStepRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Troublesteprel> list = new List<Troublesteprel>();
		foreach (Troublesteprel troublesteprel in troubleStepRelList)
		{
			Troublesteprel troubleStepRel4Update = GetTroubleStepRel4Update(dbContext, troublesteprel.Relationid, troublesteprel.Troubleid, troublesteprel.Troublestepid, troublesteprel.Troubledefinitionid, troublesteprel.Siteid);
			if (troubleStepRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Troublesteprel), $"{troublesteprel.Relationid},{troublesteprel.Troubleid},{troublesteprel.Troublestepid},{troublesteprel.Troubledefinitionid},{troublesteprel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Troublesteprel), $"{troublesteprel.Relationid},{troublesteprel.Troubleid},{troublesteprel.Troublestepid},{troublesteprel.Troubledefinitionid},{troublesteprel.Siteid}", troubleStepRel4Update.Isusable);
			troubleStepRel4Update.Isusable = "Usable";
			troublesteprel.CopyCommonFieldUpdatePrev(troubleStepRel4Update, systemTime, dbContext.Tid, text);
			troublesteprel.CopyExtensionCollection(troubleStepRel4Update);
			list.Add(troubleStepRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteTroubleStepRel(IDbContext dbContext, Troublesteprel[] troubleStepRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("troubleStepRelList", troubleStepRelList);
		string text = "RealDeleteTroubleStepRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Troublesteprel> list = new List<Troublesteprel>();
		foreach (Troublesteprel troublesteprel in troubleStepRelList)
		{
			Troublesteprel troubleStepRel4Update = GetTroubleStepRel4Update(dbContext, troublesteprel.Relationid, troublesteprel.Troubleid, troublesteprel.Troublestepid, troublesteprel.Troubledefinitionid, troublesteprel.Siteid);
			if (troubleStepRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Troublesteprel), $"{troublesteprel.Relationid},{troublesteprel.Troubleid},{troublesteprel.Troublestepid},{troublesteprel.Troubledefinitionid},{troublesteprel.Siteid}");
			}
			troublesteprel.CopyCommonFieldUpdatePrev(troubleStepRel4Update, systemTime, dbContext.Tid, text);
			troublesteprel.CopyExtensionCollection(troubleStepRel4Update);
			list.Add(troubleStepRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
