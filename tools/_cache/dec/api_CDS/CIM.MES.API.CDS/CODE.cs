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
public class CODE
{
	private static string _sqlGetCodeSqlDatabase = "SELECT * FROM CIM_CODE WHERE CODEID=@CODEID AND CODECLASSID=@CODECLASSID AND SITEID=@SITEID";

	private static string _sqlGetCode4UpdateSqlDatabase = "SELECT * FROM CIM_CODE WITH(UPDLOCK) WHERE CODEID=@CODEID AND CODECLASSID=@CODECLASSID AND SITEID=@SITEID";

	private static string _sqlSelectCodeSqlDatabase = "SELECT * FROM CIM_CODE WHERE CODEID=@CODEID AND CODECLASSID=@CODECLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectCode4UpdateSqlDatabase = "SELECT * FROM CIM_CODE WITH(UPDLOCK) WHERE CODEID=@CODEID AND CODECLASSID=@CODECLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetCodeOracleDatabase = "SELECT * FROM CIM_CODE WHERE CODEID=:CODEID AND CODECLASSID=:CODECLASSID AND SITEID=:SITEID";

	private static string _sqlGetCode4UpdateOracleDatabase = "SELECT * FROM CIM_CODE WHERE CODEID=:CODEID AND CODECLASSID=:CODECLASSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectCodeOracleDatabase = "SELECT * FROM CIM_CODE WHERE CODEID=:CODEID AND CODECLASSID=:CODECLASSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectCode4UpdateOracleDatabase = "SELECT * FROM CIM_CODE WHERE CODEID=:CODEID AND CODECLASSID=:CODECLASSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Code);

	private static string _sqlGetCodeListSqlDatabase = "SELECT * FROM CIM_CODE WHERE CODECLASSID=@CODECLASSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetCodeListOracleDatabase = "SELECT * FROM CIM_CODE WHERE CODECLASSID=:CODECLASSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	public static Code GetCode(IDbContext dbContext, string codeid, string codeclassid, string siteid)
	{
		string apiName = "GetCode";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{codeid},{codeclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetCodeSqlDatabase : _sqlGetCodeOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CODEID", codeid, typeOfThis));
		list.Add(dbContext.CreateParameter("CODECLASSID", codeclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_CODE", $"{codeid},{codeclassid},{siteid}"));
		}
		Code? result = ContextManager.DirectEntityQuery<Code>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{codeid},{codeclassid},{siteid}");
		}
		return result;
	}

	public static Code GetCode4Update(IDbContext dbContext, string codeid, string codeclassid, string siteid)
	{
		string apiName = "GetCode4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{codeid},{codeclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetCode4UpdateSqlDatabase : _sqlGetCode4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CODEID", codeid, typeOfThis));
		list.Add(dbContext.CreateParameter("CODECLASSID", codeclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_CODE", $"{codeid},{codeclassid},{siteid}"));
		}
		Code? result = ContextManager.DirectEntityQuery<Code>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{codeid},{codeclassid},{siteid}");
		}
		return result;
	}

	public static Code SelectCode(IDbContext dbContext, string codeid, string codeclassid, string siteid)
	{
		string apiName = "SelectCode";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{codeid},{codeclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectCodeSqlDatabase : _sqlSelectCodeOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CODEID", codeid, typeOfThis));
		list.Add(dbContext.CreateParameter("CODECLASSID", codeclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_CODE", $"{codeid},{codeclassid},{siteid}"));
		}
		Code? result = ContextManager.DirectEntityQuery<Code>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{codeid},{codeclassid},{siteid}");
		}
		return result;
	}

	public static Code SelectCode4Update(IDbContext dbContext, string codeid, string codeclassid, string siteid)
	{
		string apiName = "SelectCode4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{codeid},{codeclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectCode4UpdateSqlDatabase : _sqlSelectCode4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CODEID", codeid, typeOfThis));
		list.Add(dbContext.CreateParameter("CODECLASSID", codeclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_CODE", $"{codeid},{codeclassid},{siteid}"));
		}
		Code? result = ContextManager.DirectEntityQuery<Code>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{codeid},{codeclassid},{siteid}");
		}
		return result;
	}

	public static IList<Code> SelectCodeList(IDbContext dbContext, string codeclassid, string siteid)
	{
		string apiName = "SelectCodeList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{codeclassid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetCodeListSqlDatabase : _sqlGetCodeListOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CODECLASSID", codeclassid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		IList<Code> source = ContextManager.DirectEntityQuery<Code>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{codeclassid},{siteid}");
		}
		return source.ToList();
	}

	public static int UpsertCode(IDbContext dbContext, RequestType requestType, Code[] codeList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateCodeInternal(dbContext, codeList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateCode(dbContext, codeList, optionSet, saveHist), 
			RequestType.DELETE => DeleteCode(dbContext, codeList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteCode(dbContext, codeList, optionSet, saveHist), 
			_ => RealDeleteCode(dbContext, codeList, optionSet, saveHist), 
		};
	}

	private static int CreateCodeInternal(IDbContext dbContext, Code[] codeList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("codeList", codeList);
		string text = "CreateCode";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Code> list = new List<Code>();
		foreach (Code obj in codeList)
		{
			Code code = new Code();
			obj.CopyColumsTo(code);
			code.Activity = text;
			code.CheckEntityUsable();
			obj.CopyCommonField(code, systemTime, dbContext.Tid, isCreate: true);
			list.Add(code);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateCode(IDbContext dbContext, Code[] codeList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("codeList", codeList);
		string text = "UpdateCode";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Code> list = new List<Code>();
		foreach (Code code in codeList)
		{
			Code code4Update = GetCode4Update(dbContext, code.Codeid, code.Codeclassid, code.Siteid);
			if (code4Update == null)
			{
				throw new EntityNotFoundException(typeof(Code), $"{code.Codeid},{code.Codeclassid},{code.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Code), $"{code.Codeid},{code.Codeclassid},{code.Siteid}", code4Update.Isusable);
			string activity = code4Update.Activity;
			string customactivity = code4Update.Customactivity;
			string isusable = code4Update.Isusable;
			DateTime? createtime = code4Update.Createtime;
			string creator = code4Update.Creator;
			code.CopyColumsTo(code4Update);
			code4Update.Prevactivity = activity;
			code4Update.Prevcustomactivity = customactivity;
			code4Update.Creator = creator;
			code4Update.Createtime = createtime;
			code4Update.Isusable = isusable;
			code4Update.Activity = text;
			code.CopyCommonField(code4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(code4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteCode(IDbContext dbContext, Code[] codeList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("codeList", codeList);
		string text = "DeleteCode";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Code> list = new List<Code>();
		foreach (Code code in codeList)
		{
			Code code4Update = GetCode4Update(dbContext, code.Codeid, code.Codeclassid, code.Siteid);
			if (code4Update == null)
			{
				throw new EntityNotFoundException(typeof(Code), $"{code.Codeid},{code.Codeclassid},{code.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Code), $"{code.Codeid},{code.Codeclassid},{code.Siteid}", code4Update.Isusable);
			code4Update.Isusable = "UnUsable";
			code.CopyCommonFieldUpdatePrev(code4Update, systemTime, dbContext.Tid, text);
			code.CopyExtensionCollection(code4Update);
			list.Add(code4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteCode(IDbContext dbContext, Code[] codeList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("codeList", codeList);
		string text = "UnDeleteCode";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Code> list = new List<Code>();
		foreach (Code code in codeList)
		{
			Code code4Update = GetCode4Update(dbContext, code.Codeid, code.Codeclassid, code.Siteid);
			if (code4Update == null)
			{
				throw new EntityNotFoundException(typeof(Code), $"{code.Codeid},{code.Codeclassid},{code.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Code), $"{code.Codeid},{code.Codeclassid},{code.Siteid}", code4Update.Isusable);
			code4Update.Isusable = "Usable";
			code.CopyCommonFieldUpdatePrev(code4Update, systemTime, dbContext.Tid, text);
			code.CopyExtensionCollection(code4Update);
			list.Add(code4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteCode(IDbContext dbContext, Code[] codeList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("codeList", codeList);
		string text = "RealDeleteCode";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Code> list = new List<Code>();
		foreach (Code code in codeList)
		{
			Code code4Update = GetCode4Update(dbContext, code.Codeid, code.Codeclassid, code.Siteid);
			if (code4Update == null)
			{
				throw new EntityNotFoundException(typeof(Code), $"{code.Codeid},{code.Codeclassid},{code.Siteid}");
			}
			code.CopyCommonFieldUpdatePrev(code4Update, systemTime, dbContext.Tid, text);
			code.CopyExtensionCollection(code4Update);
			list.Add(code4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
