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
public class TROUBLEDEFSTEPREL
{
	private static string _sqlGetTroubleDefStepRelSqlDatabase = "SELECT * FROM CIM_TROUBLEDEFSTEPREL WHERE TROUBLEDEFINITIONID=@TROUBLEDEFINITIONID AND TROUBLESTEPID=@TROUBLESTEPID AND SITEID=@SITEID";

	private static string _sqlGetTroubleDefStepRel4UpdateSqlDatabase = "SELECT * FROM CIM_TROUBLEDEFSTEPREL WITH(UPDLOCK) WHERE TROUBLEDEFINITIONID=@TROUBLEDEFINITIONID AND TROUBLESTEPID=@TROUBLESTEPID AND SITEID=@SITEID";

	private static string _sqlSelectTroubleDefStepRelSqlDatabase = "SELECT * FROM CIM_TROUBLEDEFSTEPREL WHERE TROUBLEDEFINITIONID=@TROUBLEDEFINITIONID AND TROUBLESTEPID=@TROUBLESTEPID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectTroubleDefStepRel4UpdateSqlDatabase = "SELECT * FROM CIM_TROUBLEDEFSTEPREL WITH(UPDLOCK) WHERE TROUBLEDEFINITIONID=@TROUBLEDEFINITIONID AND TROUBLESTEPID=@TROUBLESTEPID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetTroubleDefStepRelOracleDatabase = "SELECT * FROM CIM_TROUBLEDEFSTEPREL WHERE TROUBLEDEFINITIONID=:TROUBLEDEFINITIONID AND TROUBLESTEPID=:TROUBLESTEPID AND SITEID=:SITEID";

	private static string _sqlGetTroubleDefStepRel4UpdateOracleDatabase = "SELECT * FROM CIM_TROUBLEDEFSTEPREL WHERE TROUBLEDEFINITIONID=:TROUBLEDEFINITIONID AND TROUBLESTEPID=:TROUBLESTEPID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectTroubleDefStepRelOracleDatabase = "SELECT * FROM CIM_TROUBLEDEFSTEPREL WHERE TROUBLEDEFINITIONID=:TROUBLEDEFINITIONID AND TROUBLESTEPID=:TROUBLESTEPID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectTroubleDefStepRel4UpdateOracleDatabase = "SELECT * FROM CIM_TROUBLEDEFSTEPREL WHERE TROUBLEDEFINITIONID=:TROUBLEDEFINITIONID AND TROUBLESTEPID=:TROUBLESTEPID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Troubledefsteprel);

	public static Troubledefsteprel GetTroubleDefStepRel(IDbContext dbContext, string troubledefinitionid, string troublestepid, string siteid)
	{
		string apiName = "GetTroubleDefStepRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{troubledefinitionid},{troublestepid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetTroubleDefStepRelSqlDatabase : _sqlGetTroubleDefStepRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TROUBLEDEFINITIONID", troubledefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("TROUBLESTEPID", troublestepid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_TROUBLEDEFSTEPREL", $"{troubledefinitionid},{troublestepid},{siteid}"));
		}
		Troubledefsteprel? result = ContextManager.DirectEntityQuery<Troubledefsteprel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{troubledefinitionid},{troublestepid},{siteid}");
		}
		return result;
	}

	public static Troubledefsteprel GetTroubleDefStepRel4Update(IDbContext dbContext, string troubledefinitionid, string troublestepid, string siteid)
	{
		string apiName = "GetTroubleDefStepRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{troubledefinitionid},{troublestepid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetTroubleDefStepRel4UpdateSqlDatabase : _sqlGetTroubleDefStepRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TROUBLEDEFINITIONID", troubledefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("TROUBLESTEPID", troublestepid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_TROUBLEDEFSTEPREL", $"{troubledefinitionid},{troublestepid},{siteid}"));
		}
		Troubledefsteprel? result = ContextManager.DirectEntityQuery<Troubledefsteprel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{troubledefinitionid},{troublestepid},{siteid}");
		}
		return result;
	}

	public static Troubledefsteprel SelectTroubleDefStepRel(IDbContext dbContext, string troubledefinitionid, string troublestepid, string siteid)
	{
		string apiName = "SelectTroubleDefStepRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{troubledefinitionid},{troublestepid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectTroubleDefStepRelSqlDatabase : _sqlSelectTroubleDefStepRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TROUBLEDEFINITIONID", troubledefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("TROUBLESTEPID", troublestepid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_TROUBLEDEFSTEPREL", $"{troubledefinitionid},{troublestepid},{siteid}"));
		}
		Troubledefsteprel? result = ContextManager.DirectEntityQuery<Troubledefsteprel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{troubledefinitionid},{troublestepid},{siteid}");
		}
		return result;
	}

	public static Troubledefsteprel SelectTroubleDefStepRel4Update(IDbContext dbContext, string troubledefinitionid, string troublestepid, string siteid)
	{
		string apiName = "SelectTroubleDefStepRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{troubledefinitionid},{troublestepid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectTroubleDefStepRel4UpdateSqlDatabase : _sqlSelectTroubleDefStepRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TROUBLEDEFINITIONID", troubledefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("TROUBLESTEPID", troublestepid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_TROUBLEDEFSTEPREL", $"{troubledefinitionid},{troublestepid},{siteid}"));
		}
		Troubledefsteprel? result = ContextManager.DirectEntityQuery<Troubledefsteprel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{troubledefinitionid},{troublestepid},{siteid}");
		}
		return result;
	}

	public static int UpsertTroubleDefStepRel(IDbContext dbContext, RequestType requestType, Troubledefsteprel[] troubleDefStepRelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateTroubleDefStepRelInternal(dbContext, troubleDefStepRelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateTroubleDefStepRel(dbContext, troubleDefStepRelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteTroubleDefStepRel(dbContext, troubleDefStepRelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteTroubleDefStepRel(dbContext, troubleDefStepRelList, optionSet, saveHist), 
			_ => RealDeleteTroubleDefStepRel(dbContext, troubleDefStepRelList, optionSet, saveHist), 
		};
	}

	private static int CreateTroubleDefStepRelInternal(IDbContext dbContext, Troubledefsteprel[] troubleDefStepRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("troubleDefStepRelList", troubleDefStepRelList);
		string text = "CreateTroubleDefStepRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Troubledefsteprel> list = new List<Troubledefsteprel>();
		foreach (Troubledefsteprel obj in troubleDefStepRelList)
		{
			Troubledefsteprel troubledefsteprel = new Troubledefsteprel();
			obj.CopyColumsTo(troubledefsteprel);
			troubledefsteprel.Activity = text;
			troubledefsteprel.CheckEntityUsable();
			obj.CopyCommonField(troubledefsteprel, systemTime, dbContext.Tid, isCreate: true);
			list.Add(troubledefsteprel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateTroubleDefStepRel(IDbContext dbContext, Troubledefsteprel[] troubleDefStepRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("troubleDefStepRelList", troubleDefStepRelList);
		string text = "UpdateTroubleDefStepRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Troubledefsteprel> list = new List<Troubledefsteprel>();
		foreach (Troubledefsteprel troubledefsteprel in troubleDefStepRelList)
		{
			Troubledefsteprel troubleDefStepRel4Update = GetTroubleDefStepRel4Update(dbContext, troubledefsteprel.Troubledefinitionid, troubledefsteprel.Troublestepid, troubledefsteprel.Siteid);
			if (troubleDefStepRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Troubledefsteprel), $"{troubledefsteprel.Troubledefinitionid},{troubledefsteprel.Troublestepid},{troubledefsteprel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Troubledefsteprel), $"{troubledefsteprel.Troubledefinitionid},{troubledefsteprel.Troublestepid},{troubledefsteprel.Siteid}", troubleDefStepRel4Update.Isusable);
			string activity = troubleDefStepRel4Update.Activity;
			string customactivity = troubleDefStepRel4Update.Customactivity;
			string isusable = troubleDefStepRel4Update.Isusable;
			DateTime? createtime = troubleDefStepRel4Update.Createtime;
			string creator = troubleDefStepRel4Update.Creator;
			troubledefsteprel.CopyColumsTo(troubleDefStepRel4Update);
			troubleDefStepRel4Update.Prevactivity = activity;
			troubleDefStepRel4Update.Prevcustomactivity = customactivity;
			troubleDefStepRel4Update.Creator = creator;
			troubleDefStepRel4Update.Createtime = createtime;
			troubleDefStepRel4Update.Isusable = isusable;
			troubleDefStepRel4Update.Activity = text;
			troubledefsteprel.CopyCommonField(troubleDefStepRel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(troubleDefStepRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteTroubleDefStepRel(IDbContext dbContext, Troubledefsteprel[] troubleDefStepRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("troubleDefStepRelList", troubleDefStepRelList);
		string text = "DeleteTroubleDefStepRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Troubledefsteprel> list = new List<Troubledefsteprel>();
		foreach (Troubledefsteprel troubledefsteprel in troubleDefStepRelList)
		{
			Troubledefsteprel troubleDefStepRel4Update = GetTroubleDefStepRel4Update(dbContext, troubledefsteprel.Troubledefinitionid, troubledefsteprel.Troublestepid, troubledefsteprel.Siteid);
			if (troubleDefStepRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Troubledefsteprel), $"{troubledefsteprel.Troubledefinitionid},{troubledefsteprel.Troublestepid},{troubledefsteprel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Troubledefsteprel), $"{troubledefsteprel.Troubledefinitionid},{troubledefsteprel.Troublestepid},{troubledefsteprel.Siteid}", troubleDefStepRel4Update.Isusable);
			troubleDefStepRel4Update.Isusable = "UnUsable";
			troubledefsteprel.CopyCommonFieldUpdatePrev(troubleDefStepRel4Update, systemTime, dbContext.Tid, text);
			troubledefsteprel.CopyExtensionCollection(troubleDefStepRel4Update);
			list.Add(troubleDefStepRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteTroubleDefStepRel(IDbContext dbContext, Troubledefsteprel[] troubleDefStepRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("troubleDefStepRelList", troubleDefStepRelList);
		string text = "UnDeleteTroubleDefStepRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Troubledefsteprel> list = new List<Troubledefsteprel>();
		foreach (Troubledefsteprel troubledefsteprel in troubleDefStepRelList)
		{
			Troubledefsteprel troubleDefStepRel4Update = GetTroubleDefStepRel4Update(dbContext, troubledefsteprel.Troubledefinitionid, troubledefsteprel.Troublestepid, troubledefsteprel.Siteid);
			if (troubleDefStepRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Troubledefsteprel), $"{troubledefsteprel.Troubledefinitionid},{troubledefsteprel.Troublestepid},{troubledefsteprel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Troubledefsteprel), $"{troubledefsteprel.Troubledefinitionid},{troubledefsteprel.Troublestepid},{troubledefsteprel.Siteid}", troubleDefStepRel4Update.Isusable);
			troubleDefStepRel4Update.Isusable = "Usable";
			troubledefsteprel.CopyCommonFieldUpdatePrev(troubleDefStepRel4Update, systemTime, dbContext.Tid, text);
			troubledefsteprel.CopyExtensionCollection(troubleDefStepRel4Update);
			list.Add(troubleDefStepRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteTroubleDefStepRel(IDbContext dbContext, Troubledefsteprel[] troubleDefStepRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("troubleDefStepRelList", troubleDefStepRelList);
		string text = "RealDeleteTroubleDefStepRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Troubledefsteprel> list = new List<Troubledefsteprel>();
		foreach (Troubledefsteprel troubledefsteprel in troubleDefStepRelList)
		{
			Troubledefsteprel troubleDefStepRel4Update = GetTroubleDefStepRel4Update(dbContext, troubledefsteprel.Troubledefinitionid, troubledefsteprel.Troublestepid, troubledefsteprel.Siteid);
			if (troubleDefStepRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Troubledefsteprel), $"{troubledefsteprel.Troubledefinitionid},{troubledefsteprel.Troublestepid},{troubledefsteprel.Siteid}");
			}
			troubledefsteprel.CopyCommonFieldUpdatePrev(troubleDefStepRel4Update, systemTime, dbContext.Tid, text);
			troubledefsteprel.CopyExtensionCollection(troubleDefStepRel4Update);
			list.Add(troubleDefStepRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
