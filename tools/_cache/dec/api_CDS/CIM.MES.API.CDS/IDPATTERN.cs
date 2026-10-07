using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.CDS;

[MESAPI]
public class IDPATTERN
{
	private static string _sqlGetIdPatternSqlDatabase = "SELECT * FROM CIM_IDPATTERN WHERE IDPATTERNID=@IDPATTERNID AND SITEID=@SITEID";

	private static string _sqlGetIdPattern4UpdateSqlDatabase = "SELECT * FROM CIM_IDPATTERN WITH(UPDLOCK) WHERE IDPATTERNID=@IDPATTERNID AND SITEID=@SITEID";

	private static string _sqlSelectIdPatternSqlDatabase = "SELECT * FROM CIM_IDPATTERN WHERE IDPATTERNID=@IDPATTERNID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectIdPattern4UpdateSqlDatabase = "SELECT * FROM CIM_IDPATTERN WITH(UPDLOCK) WHERE IDPATTERNID=@IDPATTERNID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetIdPatternOracleDatabase = "SELECT * FROM CIM_IDPATTERN WHERE IDPATTERNID=:IDPATTERNID AND SITEID=:SITEID";

	private static string _sqlGetIdPattern4UpdateOracleDatabase = "SELECT * FROM CIM_IDPATTERN WHERE IDPATTERNID=:IDPATTERNID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectIdPatternOracleDatabase = "SELECT * FROM CIM_IDPATTERN WHERE IDPATTERNID=:IDPATTERNID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectIdPattern4UpdateOracleDatabase = "SELECT * FROM CIM_IDPATTERN WHERE IDPATTERNID=:IDPATTERNID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Idpattern);

	public static Idpattern GetIdPattern(IDbContext dbContext, string idpatternid, string siteid)
	{
		string apiName = "GetIdPattern";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{idpatternid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetIdPatternSqlDatabase : _sqlGetIdPatternOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("IDPATTERNID", idpatternid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_IDPATTERN", $"{idpatternid},{siteid}"));
		}
		Idpattern? result = ContextManager.DirectEntityQuery<Idpattern>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{idpatternid},{siteid}");
		}
		return result;
	}

	public static Idpattern GetIdPattern4Update(IDbContext dbContext, string idpatternid, string siteid)
	{
		string apiName = "GetIdPattern4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{idpatternid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetIdPattern4UpdateSqlDatabase : _sqlGetIdPattern4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("IDPATTERNID", idpatternid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_IDPATTERN", $"{idpatternid},{siteid}"));
		}
		Idpattern? result = ContextManager.DirectEntityQuery<Idpattern>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{idpatternid},{siteid}");
		}
		return result;
	}

	public static Idpattern SelectIdPattern(IDbContext dbContext, string idpatternid, string siteid)
	{
		string apiName = "SelectIdPattern";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{idpatternid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectIdPatternSqlDatabase : _sqlSelectIdPatternOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("IDPATTERNID", idpatternid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_IDPATTERN", $"{idpatternid},{siteid}"));
		}
		Idpattern? result = ContextManager.DirectEntityQuery<Idpattern>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{idpatternid},{siteid}");
		}
		return result;
	}

	public static Idpattern SelectIdPattern4Update(IDbContext dbContext, string idpatternid, string siteid)
	{
		string apiName = "SelectIdPattern4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{idpatternid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectIdPattern4UpdateSqlDatabase : _sqlSelectIdPattern4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("IDPATTERNID", idpatternid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_IDPATTERN", $"{idpatternid},{siteid}"));
		}
		Idpattern? result = ContextManager.DirectEntityQuery<Idpattern>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{idpatternid},{siteid}");
		}
		return result;
	}

	public static int UpsertIdPattern(IDbContext dbContext, RequestType requestType, Idpattern[] idPatternList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateIdPatternInternal(dbContext, idPatternList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateIdPattern(dbContext, idPatternList, optionSet, saveHist), 
			RequestType.DELETE => DeleteIdPattern(dbContext, idPatternList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteIdPattern(dbContext, idPatternList, optionSet, saveHist), 
			_ => RealDeleteIdPattern(dbContext, idPatternList, optionSet, saveHist), 
		};
	}

	private static int CreateIdPatternInternal(IDbContext dbContext, Idpattern[] idPatternList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("idPatternList", idPatternList);
		string text = "CreateIdPattern";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Idpattern> list = new List<Idpattern>();
		foreach (Idpattern obj in idPatternList)
		{
			Idpattern idpattern = new Idpattern();
			obj.CopyColumsTo(idpattern);
			idpattern.Activity = text;
			idpattern.CheckEntityUsable();
			obj.CopyCommonField(idpattern, systemTime, dbContext.Tid, isCreate: true);
			list.Add(idpattern);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateIdPattern(IDbContext dbContext, Idpattern[] idPatternList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("idPatternList", idPatternList);
		string text = "UpdateIdPattern";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Idpattern> list = new List<Idpattern>();
		foreach (Idpattern idpattern in idPatternList)
		{
			Idpattern idPattern4Update = GetIdPattern4Update(dbContext, idpattern.Idpatternid, idpattern.Siteid);
			if (idPattern4Update == null)
			{
				throw new EntityNotFoundException(typeof(Idpattern), $"{idpattern.Idpatternid},{idpattern.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Idpattern), $"{idpattern.Idpatternid},{idpattern.Siteid}", idPattern4Update.Isusable);
			string activity = idPattern4Update.Activity;
			string customactivity = idPattern4Update.Customactivity;
			string isusable = idPattern4Update.Isusable;
			DateTime? createtime = idPattern4Update.Createtime;
			string creator = idPattern4Update.Creator;
			idpattern.CopyColumsTo(idPattern4Update);
			idPattern4Update.Prevactivity = activity;
			idPattern4Update.Prevcustomactivity = customactivity;
			idPattern4Update.Creator = creator;
			idPattern4Update.Createtime = createtime;
			idPattern4Update.Isusable = isusable;
			idPattern4Update.Activity = text;
			idpattern.CopyCommonField(idPattern4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(idPattern4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteIdPattern(IDbContext dbContext, Idpattern[] idPatternList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("idPatternList", idPatternList);
		string text = "DeleteIdPattern";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Idpattern> list = new List<Idpattern>();
		foreach (Idpattern idpattern in idPatternList)
		{
			Idpattern idPattern4Update = GetIdPattern4Update(dbContext, idpattern.Idpatternid, idpattern.Siteid);
			if (idPattern4Update == null)
			{
				throw new EntityNotFoundException(typeof(Idpattern), $"{idpattern.Idpatternid},{idpattern.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Idpattern), $"{idpattern.Idpatternid},{idpattern.Siteid}", idPattern4Update.Isusable);
			idPattern4Update.Isusable = "UnUsable";
			idpattern.CopyCommonFieldUpdatePrev(idPattern4Update, systemTime, dbContext.Tid, text);
			idpattern.CopyExtensionCollection(idPattern4Update);
			list.Add(idPattern4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteIdPattern(IDbContext dbContext, Idpattern[] idPatternList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("idPatternList", idPatternList);
		string text = "UnDeleteIdPattern";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Idpattern> list = new List<Idpattern>();
		foreach (Idpattern idpattern in idPatternList)
		{
			Idpattern idPattern4Update = GetIdPattern4Update(dbContext, idpattern.Idpatternid, idpattern.Siteid);
			if (idPattern4Update == null)
			{
				throw new EntityNotFoundException(typeof(Idpattern), $"{idpattern.Idpatternid},{idpattern.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Idpattern), $"{idpattern.Idpatternid},{idpattern.Siteid}", idPattern4Update.Isusable);
			idPattern4Update.Isusable = "Usable";
			idpattern.CopyCommonFieldUpdatePrev(idPattern4Update, systemTime, dbContext.Tid, text);
			idpattern.CopyExtensionCollection(idPattern4Update);
			list.Add(idPattern4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteIdPattern(IDbContext dbContext, Idpattern[] idPatternList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("idPatternList", idPatternList);
		string text = "RealDeleteIdPattern";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Idpattern> list = new List<Idpattern>();
		foreach (Idpattern idpattern in idPatternList)
		{
			Idpattern idPattern4Update = GetIdPattern4Update(dbContext, idpattern.Idpatternid, idpattern.Siteid);
			if (idPattern4Update == null)
			{
				throw new EntityNotFoundException(typeof(Idpattern), $"{idpattern.Idpatternid},{idpattern.Siteid}");
			}
			idpattern.CopyCommonFieldUpdatePrev(idPattern4Update, systemTime, dbContext.Tid, text);
			idpattern.CopyExtensionCollection(idPattern4Update);
			list.Add(idPattern4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
