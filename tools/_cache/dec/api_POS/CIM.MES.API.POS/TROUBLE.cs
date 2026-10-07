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
public class TROUBLE
{
	private static string _sqlGetTroubleSqlDatabase = "SELECT * FROM CIM_TROUBLE WHERE TROUBLEID=@TROUBLEID AND TROUBLEDEFINITIONID=@TROUBLEDEFINITIONID AND TROUBLESTEPID=@TROUBLESTEPID AND SITEID=@SITEID";

	private static string _sqlGetTrouble4UpdateSqlDatabase = "SELECT * FROM CIM_TROUBLE WITH(UPDLOCK) WHERE TROUBLEID=@TROUBLEID AND TROUBLEDEFINITIONID=@TROUBLEDEFINITIONID AND TROUBLESTEPID=@TROUBLESTEPID AND SITEID=@SITEID";

	private static string _sqlSelectTroubleSqlDatabase = "SELECT * FROM CIM_TROUBLE WHERE TROUBLEID=@TROUBLEID AND TROUBLEDEFINITIONID=@TROUBLEDEFINITIONID AND TROUBLESTEPID=@TROUBLESTEPID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectTrouble4UpdateSqlDatabase = "SELECT * FROM CIM_TROUBLE WITH(UPDLOCK) WHERE TROUBLEID=@TROUBLEID AND TROUBLEDEFINITIONID=@TROUBLEDEFINITIONID AND TROUBLESTEPID=@TROUBLESTEPID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetTroubleOracleDatabase = "SELECT * FROM CIM_TROUBLE WHERE TROUBLEID=:TROUBLEID AND TROUBLEDEFINITIONID=:TROUBLEDEFINITIONID AND TROUBLESTEPID=:TROUBLESTEPID AND SITEID=:SITEID";

	private static string _sqlGetTrouble4UpdateOracleDatabase = "SELECT * FROM CIM_TROUBLE WHERE TROUBLEID=:TROUBLEID AND TROUBLEDEFINITIONID=:TROUBLEDEFINITIONID AND TROUBLESTEPID=:TROUBLESTEPID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectTroubleOracleDatabase = "SELECT * FROM CIM_TROUBLE WHERE TROUBLEID=:TROUBLEID AND TROUBLEDEFINITIONID=:TROUBLEDEFINITIONID AND TROUBLESTEPID=:TROUBLESTEPID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectTrouble4UpdateOracleDatabase = "SELECT * FROM CIM_TROUBLE WHERE TROUBLEID=:TROUBLEID AND TROUBLEDEFINITIONID=:TROUBLEDEFINITIONID AND TROUBLESTEPID=:TROUBLESTEPID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Trouble);

	public static Trouble GetTrouble(IDbContext dbContext, string troubleid, string troubledefinitionid, string troublestepid, string siteid)
	{
		string apiName = "GetTrouble";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{troubleid},{troubledefinitionid},{troublestepid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetTroubleSqlDatabase : _sqlGetTroubleOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TROUBLEID", troubleid, typeOfThis));
		list.Add(dbContext.CreateParameter("TROUBLEDEFINITIONID", troubledefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("TROUBLESTEPID", troublestepid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_TROUBLE", $"{troubleid},{troubledefinitionid},{troublestepid},{siteid}"));
		}
		Trouble result = ContextManager.DirectEntityQuery<Trouble>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{troubleid},{troubledefinitionid},{troublestepid},{siteid}");
		}
		return result;
	}

	public static Trouble GetTrouble4Update(IDbContext dbContext, string troubleid, string troubledefinitionid, string troublestepid, string siteid)
	{
		string apiName = "GetTrouble4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{troubleid},{troubledefinitionid},{troublestepid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetTrouble4UpdateSqlDatabase : _sqlGetTrouble4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TROUBLEID", troubleid, typeOfThis));
		list.Add(dbContext.CreateParameter("TROUBLEDEFINITIONID", troubledefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("TROUBLESTEPID", troublestepid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_TROUBLE", $"{troubleid},{troubledefinitionid},{troublestepid},{siteid}"));
		}
		Trouble result = ContextManager.DirectEntityQuery<Trouble>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{troubleid},{troubledefinitionid},{troublestepid},{siteid}");
		}
		return result;
	}

	public static Trouble SelectTrouble(IDbContext dbContext, string troubleid, string troubledefinitionid, string troublestepid, string siteid)
	{
		string apiName = "SelectTrouble";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{troubleid},{troubledefinitionid},{troublestepid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectTroubleSqlDatabase : _sqlSelectTroubleOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TROUBLEID", troubleid, typeOfThis));
		list.Add(dbContext.CreateParameter("TROUBLEDEFINITIONID", troubledefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("TROUBLESTEPID", troublestepid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_TROUBLE", $"{troubleid},{troubledefinitionid},{troublestepid},{siteid}"));
		}
		Trouble result = ContextManager.DirectEntityQuery<Trouble>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{troubleid},{troubledefinitionid},{troublestepid},{siteid}");
		}
		return result;
	}

	public static Trouble SelectTrouble4Update(IDbContext dbContext, string troubleid, string troubledefinitionid, string troublestepid, string siteid)
	{
		string apiName = "SelectTrouble4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{troubleid},{troubledefinitionid},{troublestepid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectTrouble4UpdateSqlDatabase : _sqlSelectTrouble4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TROUBLEID", troubleid, typeOfThis));
		list.Add(dbContext.CreateParameter("TROUBLEDEFINITIONID", troubledefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("TROUBLESTEPID", troublestepid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_TROUBLE", $"{troubleid},{troubledefinitionid},{troublestepid},{siteid}"));
		}
		Trouble result = ContextManager.DirectEntityQuery<Trouble>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{troubleid},{troubledefinitionid},{troublestepid},{siteid}");
		}
		return result;
	}

	public static int UpsertTrouble(IDbContext dbContext, RequestType requestType, Trouble[] troubleList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateTroubleInternal(dbContext, troubleList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateTrouble(dbContext, troubleList, optionSet, saveHist), 
			RequestType.DELETE => DeleteTrouble(dbContext, troubleList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteTrouble(dbContext, troubleList, optionSet, saveHist), 
			_ => RealDeleteTrouble(dbContext, troubleList, optionSet, saveHist), 
		};
	}

	private static int CreateTroubleInternal(IDbContext dbContext, Trouble[] troubleList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("troubleList", troubleList);
		string text = "CreateTrouble";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Trouble> list = new List<Trouble>();
		foreach (Trouble obj in troubleList)
		{
			Trouble trouble = new Trouble();
			obj.CopyColumsTo(trouble);
			trouble.Activity = text;
			trouble.CheckEntityUsable();
			obj.CopyCommonField(trouble, systemTime, dbContext.Tid, isCreate: true);
			list.Add(trouble);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateTrouble(IDbContext dbContext, Trouble[] troubleList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("troubleList", troubleList);
		string text = "UpdateTrouble";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Trouble> list = new List<Trouble>();
		foreach (Trouble trouble in troubleList)
		{
			Trouble trouble4Update = GetTrouble4Update(dbContext, trouble.Troubleid, trouble.Troubledefinitionid, trouble.Troublestepid, trouble.Siteid);
			if (trouble4Update == null)
			{
				throw new EntityNotFoundException(typeof(Trouble), $"{trouble.Troubleid},{trouble.Troubledefinitionid},{trouble.Troublestepid},{trouble.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Trouble), $"{trouble.Troubleid},{trouble.Troubledefinitionid},{trouble.Troublestepid},{trouble.Siteid}", trouble4Update.Isusable);
			string activity = trouble4Update.Activity;
			string customactivity = trouble4Update.Customactivity;
			string isusable = trouble4Update.Isusable;
			DateTime? createtime = trouble4Update.Createtime;
			string creator = trouble4Update.Creator;
			trouble.CopyColumsTo(trouble4Update);
			trouble4Update.Prevactivity = activity;
			trouble4Update.Prevcustomactivity = customactivity;
			trouble4Update.Creator = creator;
			trouble4Update.Createtime = createtime;
			trouble4Update.Isusable = isusable;
			trouble4Update.Activity = text;
			trouble.CopyCommonField(trouble4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(trouble4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteTrouble(IDbContext dbContext, Trouble[] troubleList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("troubleList", troubleList);
		string text = "DeleteTrouble";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Trouble> list = new List<Trouble>();
		foreach (Trouble trouble in troubleList)
		{
			Trouble trouble4Update = GetTrouble4Update(dbContext, trouble.Troubleid, trouble.Troubledefinitionid, trouble.Troublestepid, trouble.Siteid);
			if (trouble4Update == null)
			{
				throw new EntityNotFoundException(typeof(Trouble), $"{trouble.Troubleid},{trouble.Troubledefinitionid},{trouble.Troublestepid},{trouble.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Trouble), $"{trouble.Troubleid},{trouble.Troubledefinitionid},{trouble.Troublestepid},{trouble.Siteid}", trouble4Update.Isusable);
			trouble4Update.Isusable = "UnUsable";
			trouble.CopyCommonFieldUpdatePrev(trouble4Update, systemTime, dbContext.Tid, text);
			trouble.CopyExtensionCollection(trouble4Update);
			list.Add(trouble4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteTrouble(IDbContext dbContext, Trouble[] troubleList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("troubleList", troubleList);
		string text = "UnDeleteTrouble";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Trouble> list = new List<Trouble>();
		foreach (Trouble trouble in troubleList)
		{
			Trouble trouble4Update = GetTrouble4Update(dbContext, trouble.Troubleid, trouble.Troubledefinitionid, trouble.Troublestepid, trouble.Siteid);
			if (trouble4Update == null)
			{
				throw new EntityNotFoundException(typeof(Trouble), $"{trouble.Troubleid},{trouble.Troubledefinitionid},{trouble.Troublestepid},{trouble.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Trouble), $"{trouble.Troubleid},{trouble.Troubledefinitionid},{trouble.Troublestepid},{trouble.Siteid}", trouble4Update.Isusable);
			trouble4Update.Isusable = "Usable";
			trouble.CopyCommonFieldUpdatePrev(trouble4Update, systemTime, dbContext.Tid, text);
			trouble.CopyExtensionCollection(trouble4Update);
			list.Add(trouble4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteTrouble(IDbContext dbContext, Trouble[] troubleList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("troubleList", troubleList);
		string text = "RealDeleteTrouble";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Trouble> list = new List<Trouble>();
		foreach (Trouble trouble in troubleList)
		{
			Trouble trouble4Update = GetTrouble4Update(dbContext, trouble.Troubleid, trouble.Troubledefinitionid, trouble.Troublestepid, trouble.Siteid);
			if (trouble4Update == null)
			{
				throw new EntityNotFoundException(typeof(Trouble), $"{trouble.Troubleid},{trouble.Troubledefinitionid},{trouble.Troublestepid},{trouble.Siteid}");
			}
			trouble.CopyCommonFieldUpdatePrev(trouble4Update, systemTime, dbContext.Tid, text);
			trouble.CopyExtensionCollection(trouble4Update);
			list.Add(trouble4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
