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
public class ATTACHMENTDOWN
{
	private static string _sqlGetAttachmentDownSqlDatabase = "SELECT * FROM CIM_ATTACHMENTDOWN WHERE ATTACHMENTDOWNSYSID=@ATTACHMENTDOWNSYSID AND SITEID=@SITEID";

	private static string _sqlGetAttachmentDown4UpdateSqlDatabase = "SELECT * FROM CIM_ATTACHMENTDOWN WITH(UPDLOCK) WHERE ATTACHMENTDOWNSYSID=@ATTACHMENTDOWNSYSID AND SITEID=@SITEID";

	private static string _sqlSelectAttachmentDownSqlDatabase = "SELECT * FROM CIM_ATTACHMENTDOWN WHERE ATTACHMENTDOWNSYSID=@ATTACHMENTDOWNSYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectAttachmentDown4UpdateSqlDatabase = "SELECT * FROM CIM_ATTACHMENTDOWN WITH(UPDLOCK) WHERE ATTACHMENTDOWNSYSID=@ATTACHMENTDOWNSYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetAttachmentDownOracleDatabase = "SELECT * FROM CIM_ATTACHMENTDOWN WHERE ATTACHMENTDOWNSYSID=:ATTACHMENTDOWNSYSID AND SITEID=:SITEID";

	private static string _sqlGetAttachmentDown4UpdateOracleDatabase = "SELECT * FROM CIM_ATTACHMENTDOWN WHERE ATTACHMENTDOWNSYSID=:ATTACHMENTDOWNSYSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectAttachmentDownOracleDatabase = "SELECT * FROM CIM_ATTACHMENTDOWN WHERE ATTACHMENTDOWNSYSID=:ATTACHMENTDOWNSYSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectAttachmentDown4UpdateOracleDatabase = "SELECT * FROM CIM_ATTACHMENTDOWN WHERE ATTACHMENTDOWNSYSID=:ATTACHMENTDOWNSYSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Attachmentdown);

	public static Attachmentdown GetAttachmentDown(IDbContext dbContext, string attachmentdownsysid, string siteid)
	{
		string apiName = "GetAttachmentDown";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{attachmentdownsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetAttachmentDownSqlDatabase : _sqlGetAttachmentDownOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ATTACHMENTDOWNSYSID", attachmentdownsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_ATTACHMENTDOWN", $"{attachmentdownsysid},{siteid}"));
		}
		Attachmentdown? result = ContextManager.DirectEntityQuery<Attachmentdown>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{attachmentdownsysid},{siteid}");
		}
		return result;
	}

	public static Attachmentdown GetAttachmentDown4Update(IDbContext dbContext, string attachmentdownsysid, string siteid)
	{
		string apiName = "GetAttachmentDown4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{attachmentdownsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetAttachmentDown4UpdateSqlDatabase : _sqlGetAttachmentDown4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ATTACHMENTDOWNSYSID", attachmentdownsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_ATTACHMENTDOWN", $"{attachmentdownsysid},{siteid}"));
		}
		Attachmentdown? result = ContextManager.DirectEntityQuery<Attachmentdown>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{attachmentdownsysid},{siteid}");
		}
		return result;
	}

	public static Attachmentdown SelectAttachmentDown(IDbContext dbContext, string attachmentdownsysid, string siteid)
	{
		string apiName = "SelectAttachmentDown";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{attachmentdownsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectAttachmentDownSqlDatabase : _sqlSelectAttachmentDownOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ATTACHMENTDOWNSYSID", attachmentdownsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_ATTACHMENTDOWN", $"{attachmentdownsysid},{siteid}"));
		}
		Attachmentdown? result = ContextManager.DirectEntityQuery<Attachmentdown>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{attachmentdownsysid},{siteid}");
		}
		return result;
	}

	public static Attachmentdown SelectAttachmentDown4Update(IDbContext dbContext, string attachmentdownsysid, string siteid)
	{
		string apiName = "SelectAttachmentDown4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{attachmentdownsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectAttachmentDown4UpdateSqlDatabase : _sqlSelectAttachmentDown4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ATTACHMENTDOWNSYSID", attachmentdownsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_ATTACHMENTDOWN", $"{attachmentdownsysid},{siteid}"));
		}
		Attachmentdown? result = ContextManager.DirectEntityQuery<Attachmentdown>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{attachmentdownsysid},{siteid}");
		}
		return result;
	}

	public static int UpsertAttachmentDown(IDbContext dbContext, RequestType requestType, Attachmentdown[] attachmentDownList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateAttachmentDownInternal(dbContext, attachmentDownList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateAttachmentDown(dbContext, attachmentDownList, optionSet, saveHist), 
			RequestType.DELETE => DeleteAttachmentDown(dbContext, attachmentDownList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteAttachmentDown(dbContext, attachmentDownList, optionSet, saveHist), 
			_ => RealDeleteAttachmentDown(dbContext, attachmentDownList, optionSet, saveHist), 
		};
	}

	private static int CreateAttachmentDownInternal(IDbContext dbContext, Attachmentdown[] attachmentDownList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("attachmentDownList", attachmentDownList);
		string text = "CreateAttachmentDown";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Attachmentdown> list = new List<Attachmentdown>();
		foreach (Attachmentdown obj in attachmentDownList)
		{
			Attachmentdown attachmentdown = new Attachmentdown();
			obj.CopyColumsTo(attachmentdown);
			attachmentdown.Activity = text;
			attachmentdown.Downloadtime = systemTime;
			attachmentdown.CheckEntityUsable();
			obj.CopyCommonField(attachmentdown, systemTime, dbContext.Tid, isCreate: true);
			list.Add(attachmentdown);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateAttachmentDown(IDbContext dbContext, Attachmentdown[] attachmentDownList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("attachmentDownList", attachmentDownList);
		string text = "UpdateAttachmentDown";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Attachmentdown> list = new List<Attachmentdown>();
		foreach (Attachmentdown attachmentdown in attachmentDownList)
		{
			Attachmentdown attachmentDown4Update = GetAttachmentDown4Update(dbContext, attachmentdown.Attachmentdownsysid, attachmentdown.Siteid);
			if (attachmentDown4Update == null)
			{
				throw new EntityNotFoundException(typeof(Attachmentdown), $"{attachmentdown.Attachmentdownsysid},{attachmentdown.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Attachmentdown), $"{attachmentdown.Attachmentdownsysid},{attachmentdown.Siteid}", attachmentDown4Update.Isusable);
			string activity = attachmentDown4Update.Activity;
			string customactivity = attachmentDown4Update.Customactivity;
			string isusable = attachmentDown4Update.Isusable;
			DateTime? createtime = attachmentDown4Update.Createtime;
			string creator = attachmentDown4Update.Creator;
			attachmentdown.CopyColumsTo(attachmentDown4Update);
			attachmentDown4Update.Prevactivity = activity;
			attachmentDown4Update.Prevcustomactivity = customactivity;
			attachmentDown4Update.Creator = creator;
			attachmentDown4Update.Createtime = createtime;
			attachmentDown4Update.Isusable = isusable;
			attachmentDown4Update.Activity = text;
			attachmentdown.CopyCommonField(attachmentDown4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(attachmentDown4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteAttachmentDown(IDbContext dbContext, Attachmentdown[] attachmentDownList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("attachmentDownList", attachmentDownList);
		string text = "DeleteAttachmentDown";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Attachmentdown> list = new List<Attachmentdown>();
		foreach (Attachmentdown attachmentdown in attachmentDownList)
		{
			Attachmentdown attachmentDown4Update = GetAttachmentDown4Update(dbContext, attachmentdown.Attachmentdownsysid, attachmentdown.Siteid);
			if (attachmentDown4Update == null)
			{
				throw new EntityNotFoundException(typeof(Attachmentdown), $"{attachmentdown.Attachmentdownsysid},{attachmentdown.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Attachmentdown), $"{attachmentdown.Attachmentdownsysid},{attachmentdown.Siteid}", attachmentDown4Update.Isusable);
			attachmentDown4Update.Isusable = "UnUsable";
			attachmentdown.CopyCommonFieldUpdatePrev(attachmentDown4Update, systemTime, dbContext.Tid, text);
			attachmentdown.CopyExtensionCollection(attachmentDown4Update);
			list.Add(attachmentDown4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteAttachmentDown(IDbContext dbContext, Attachmentdown[] attachmentDownList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("attachmentDownList", attachmentDownList);
		string text = "UnDeleteAttachmentDown";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Attachmentdown> list = new List<Attachmentdown>();
		foreach (Attachmentdown attachmentdown in attachmentDownList)
		{
			Attachmentdown attachmentDown4Update = GetAttachmentDown4Update(dbContext, attachmentdown.Attachmentdownsysid, attachmentdown.Siteid);
			if (attachmentDown4Update == null)
			{
				throw new EntityNotFoundException(typeof(Attachmentdown), $"{attachmentdown.Attachmentdownsysid},{attachmentdown.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Attachmentdown), $"{attachmentdown.Attachmentdownsysid},{attachmentdown.Siteid}", attachmentDown4Update.Isusable);
			attachmentDown4Update.Isusable = "Usable";
			attachmentdown.CopyCommonFieldUpdatePrev(attachmentDown4Update, systemTime, dbContext.Tid, text);
			attachmentdown.CopyExtensionCollection(attachmentDown4Update);
			list.Add(attachmentDown4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteAttachmentDown(IDbContext dbContext, Attachmentdown[] attachmentDownList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("attachmentDownList", attachmentDownList);
		string text = "RealDeleteAttachmentDown";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Attachmentdown> list = new List<Attachmentdown>();
		foreach (Attachmentdown attachmentdown in attachmentDownList)
		{
			Attachmentdown attachmentDown4Update = GetAttachmentDown4Update(dbContext, attachmentdown.Attachmentdownsysid, attachmentdown.Siteid);
			if (attachmentDown4Update == null)
			{
				throw new EntityNotFoundException(typeof(Attachmentdown), $"{attachmentdown.Attachmentdownsysid},{attachmentdown.Siteid}");
			}
			attachmentdown.CopyCommonFieldUpdatePrev(attachmentDown4Update, systemTime, dbContext.Tid, text);
			attachmentdown.CopyExtensionCollection(attachmentDown4Update);
			list.Add(attachmentDown4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
