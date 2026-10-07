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
public class CODECLASS
{
	private static string _sqlGetCodeClassSqlDatabase = "SELECT * FROM CIM_CODECLASS WHERE CODECLASSID=@CODECLASSID AND SITEID=@SITEID";

	private static string _sqlGetCodeClass4UpdateSqlDatabase = "SELECT * FROM CIM_CODECLASS WITH(UPDLOCK) WHERE CODECLASSID=@CODECLASSID AND SITEID=@SITEID";

	private static string _sqlSelectCodeClassSqlDatabase = "SELECT * FROM CIM_CODECLASS WHERE CODECLASSID=@CODECLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectCodeClass4UpdateSqlDatabase = "SELECT * FROM CIM_CODECLASS WITH(UPDLOCK) WHERE CODECLASSID=@CODECLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetCodeClassOracleDatabase = "SELECT * FROM CIM_CODECLASS WHERE CODECLASSID=:CODECLASSID AND SITEID=:SITEID";

	private static string _sqlGetCodeClass4UpdateOracleDatabase = "SELECT * FROM CIM_CODECLASS WHERE CODECLASSID=:CODECLASSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectCodeClassOracleDatabase = "SELECT * FROM CIM_CODECLASS WHERE CODECLASSID=:CODECLASSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectCodeClass4UpdateOracleDatabase = "SELECT * FROM CIM_CODECLASS WHERE CODECLASSID=:CODECLASSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Codeclass);

	public static Codeclass GetCodeClass(IDbContext dbContext, string codeclassid, string siteid)
	{
		string apiName = "GetCodeClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{codeclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetCodeClassSqlDatabase : _sqlGetCodeClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CODECLASSID", codeclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_CODECLASS", $"{codeclassid},{siteid}"));
		}
		Codeclass? result = ContextManager.DirectEntityQuery<Codeclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{codeclassid},{siteid}");
		}
		return result;
	}

	public static Codeclass GetCodeClass4Update(IDbContext dbContext, string codeclassid, string siteid)
	{
		string apiName = "GetCodeClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{codeclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetCodeClass4UpdateSqlDatabase : _sqlGetCodeClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CODECLASSID", codeclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_CODECLASS", $"{codeclassid},{siteid}"));
		}
		Codeclass? result = ContextManager.DirectEntityQuery<Codeclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{codeclassid},{siteid}");
		}
		return result;
	}

	public static Codeclass SelectCodeClass(IDbContext dbContext, string codeclassid, string siteid)
	{
		string apiName = "SelectCodeClass";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{codeclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectCodeClassSqlDatabase : _sqlSelectCodeClassOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CODECLASSID", codeclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_CODECLASS", $"{codeclassid},{siteid}"));
		}
		Codeclass? result = ContextManager.DirectEntityQuery<Codeclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{codeclassid},{siteid}");
		}
		return result;
	}

	public static Codeclass SelectCodeClass4Update(IDbContext dbContext, string codeclassid, string siteid)
	{
		string apiName = "SelectCodeClass4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{codeclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectCodeClass4UpdateSqlDatabase : _sqlSelectCodeClass4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CODECLASSID", codeclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_CODECLASS", $"{codeclassid},{siteid}"));
		}
		Codeclass? result = ContextManager.DirectEntityQuery<Codeclass>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{codeclassid},{siteid}");
		}
		return result;
	}

	public static int UpsertCodeClass(IDbContext dbContext, RequestType requestType, Codeclass[] codeClassList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateCodeClassInternal(dbContext, codeClassList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateCodeClass(dbContext, codeClassList, optionSet, saveHist), 
			RequestType.DELETE => DeleteCodeClass(dbContext, codeClassList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteCodeClass(dbContext, codeClassList, optionSet, saveHist), 
			_ => RealDeleteCodeClass(dbContext, codeClassList, optionSet, saveHist), 
		};
	}

	private static int CreateCodeClassInternal(IDbContext dbContext, Codeclass[] codeClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("codeClassList", codeClassList);
		string text = "CreateCodeClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Codeclass> list = new List<Codeclass>();
		foreach (Codeclass obj in codeClassList)
		{
			Codeclass codeclass = new Codeclass();
			obj.CopyColumsTo(codeclass);
			codeclass.Activity = text;
			codeclass.CheckEntityUsable();
			obj.CopyCommonField(codeclass, systemTime, dbContext.Tid, isCreate: true);
			list.Add(codeclass);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateCodeClass(IDbContext dbContext, Codeclass[] codeClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("codeClassList", codeClassList);
		string text = "UpdateCodeClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Codeclass> list = new List<Codeclass>();
		foreach (Codeclass codeclass in codeClassList)
		{
			Codeclass codeClass4Update = GetCodeClass4Update(dbContext, codeclass.Codeclassid, codeclass.Siteid);
			if (codeClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Codeclass), $"{codeclass.Codeclassid},{codeclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Codeclass), $"{codeclass.Codeclassid},{codeclass.Siteid}", codeClass4Update.Isusable);
			string activity = codeClass4Update.Activity;
			string customactivity = codeClass4Update.Customactivity;
			string isusable = codeClass4Update.Isusable;
			DateTime? createtime = codeClass4Update.Createtime;
			string creator = codeClass4Update.Creator;
			codeclass.CopyColumsTo(codeClass4Update);
			codeClass4Update.Prevactivity = activity;
			codeClass4Update.Prevcustomactivity = customactivity;
			codeClass4Update.Creator = creator;
			codeClass4Update.Createtime = createtime;
			codeClass4Update.Isusable = isusable;
			codeClass4Update.Activity = text;
			codeclass.CopyCommonField(codeClass4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(codeClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteCodeClass(IDbContext dbContext, Codeclass[] codeClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("codeClassList", codeClassList);
		string text = "DeleteCodeClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Codeclass> list = new List<Codeclass>();
		foreach (Codeclass codeclass in codeClassList)
		{
			Codeclass codeClass4Update = GetCodeClass4Update(dbContext, codeclass.Codeclassid, codeclass.Siteid);
			if (codeClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Codeclass), $"{codeclass.Codeclassid},{codeclass.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Codeclass), $"{codeclass.Codeclassid},{codeclass.Siteid}", codeClass4Update.Isusable);
			codeClass4Update.Isusable = "UnUsable";
			codeclass.CopyCommonFieldUpdatePrev(codeClass4Update, systemTime, dbContext.Tid, text);
			codeclass.CopyExtensionCollection(codeClass4Update);
			list.Add(codeClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteCodeClass(IDbContext dbContext, Codeclass[] codeClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("codeClassList", codeClassList);
		string text = "UnDeleteCodeClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Codeclass> list = new List<Codeclass>();
		foreach (Codeclass codeclass in codeClassList)
		{
			Codeclass codeClass4Update = GetCodeClass4Update(dbContext, codeclass.Codeclassid, codeclass.Siteid);
			if (codeClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Codeclass), $"{codeclass.Codeclassid},{codeclass.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Codeclass), $"{codeclass.Codeclassid},{codeclass.Siteid}", codeClass4Update.Isusable);
			codeClass4Update.Isusable = "Usable";
			codeclass.CopyCommonFieldUpdatePrev(codeClass4Update, systemTime, dbContext.Tid, text);
			codeclass.CopyExtensionCollection(codeClass4Update);
			list.Add(codeClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteCodeClass(IDbContext dbContext, Codeclass[] codeClassList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("codeClassList", codeClassList);
		string text = "RealDeleteCodeClass";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Codeclass> list = new List<Codeclass>();
		foreach (Codeclass codeclass in codeClassList)
		{
			Codeclass codeClass4Update = GetCodeClass4Update(dbContext, codeclass.Codeclassid, codeclass.Siteid);
			if (codeClass4Update == null)
			{
				throw new EntityNotFoundException(typeof(Codeclass), $"{codeclass.Codeclassid},{codeclass.Siteid}");
			}
			codeclass.CopyCommonFieldUpdatePrev(codeClass4Update, systemTime, dbContext.Tid, text);
			codeclass.CopyExtensionCollection(codeClass4Update);
			list.Add(codeClass4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
