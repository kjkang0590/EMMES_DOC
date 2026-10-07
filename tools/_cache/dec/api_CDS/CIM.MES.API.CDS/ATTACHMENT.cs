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
public class ATTACHMENT
{
	private static string _sqlGetAttachmentSqlDatabase = "SELECT * FROM CIM_ATTACHMENT WHERE ATTACHMENTSYSID=@ATTACHMENTSYSID AND SITEID=@SITEID";

	private static string _sqlGetAttachment4UpdateSqlDatabase = "SELECT * FROM CIM_ATTACHMENT WITH(UPDLOCK) WHERE ATTACHMENTSYSID=@ATTACHMENTSYSID AND SITEID=@SITEID";

	private static string _sqlSelectAttachmentSqlDatabase = "SELECT * FROM CIM_ATTACHMENT WHERE ATTACHMENTSYSID=@ATTACHMENTSYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectAttachment4UpdateSqlDatabase = "SELECT * FROM CIM_ATTACHMENT WITH(UPDLOCK) WHERE ATTACHMENTSYSID=@ATTACHMENTSYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetAttachmentOracleDatabase = "SELECT * FROM CIM_ATTACHMENT WHERE ATTACHMENTSYSID=:ATTACHMENTSYSID AND SITEID=:SITEID";

	private static string _sqlGetAttachment4UpdateOracleDatabase = "SELECT * FROM CIM_ATTACHMENT WHERE ATTACHMENTSYSID=:ATTACHMENTSYSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectAttachmentOracleDatabase = "SELECT * FROM CIM_ATTACHMENT WHERE ATTACHMENTSYSID=:ATTACHMENTSYSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectAttachment4UpdateOracleDatabase = "SELECT * FROM CIM_ATTACHMENT WHERE ATTACHMENTSYSID=:ATTACHMENTSYSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Attachment);

	public static Attachment GetAttachment(IDbContext dbContext, string attachmentsysid, string siteid)
	{
		string apiName = "GetAttachment";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{attachmentsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetAttachmentSqlDatabase : _sqlGetAttachmentOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ATTACHMENTSYSID", attachmentsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_ATTACHMENT", $"{attachmentsysid},{siteid}"));
		}
		Attachment? result = ContextManager.DirectEntityQuery<Attachment>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{attachmentsysid},{siteid}");
		}
		return result;
	}

	public static Attachment GetAttachment4Update(IDbContext dbContext, string attachmentsysid, string siteid)
	{
		string apiName = "GetAttachment4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{attachmentsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetAttachment4UpdateSqlDatabase : _sqlGetAttachment4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ATTACHMENTSYSID", attachmentsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_ATTACHMENT", $"{attachmentsysid},{siteid}"));
		}
		Attachment? result = ContextManager.DirectEntityQuery<Attachment>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{attachmentsysid},{siteid}");
		}
		return result;
	}

	public static Attachment SelectAttachment(IDbContext dbContext, string attachmentsysid, string siteid)
	{
		string apiName = "SelectAttachment";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{attachmentsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectAttachmentSqlDatabase : _sqlSelectAttachmentOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ATTACHMENTSYSID", attachmentsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_ATTACHMENT", $"{attachmentsysid},{siteid}"));
		}
		Attachment? result = ContextManager.DirectEntityQuery<Attachment>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{attachmentsysid},{siteid}");
		}
		return result;
	}

	public static Attachment SelectAttachment4Update(IDbContext dbContext, string attachmentsysid, string siteid)
	{
		string apiName = "SelectAttachment4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{attachmentsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectAttachment4UpdateSqlDatabase : _sqlSelectAttachment4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ATTACHMENTSYSID", attachmentsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_ATTACHMENT", $"{attachmentsysid},{siteid}"));
		}
		Attachment? result = ContextManager.DirectEntityQuery<Attachment>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{attachmentsysid},{siteid}");
		}
		return result;
	}

	public static int UpsertAttachment(IDbContext dbContext, RequestType requestType, Attachment[] attachmentList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateAttachmentInternal(dbContext, attachmentList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateAttachment(dbContext, attachmentList, optionSet, saveHist), 
			RequestType.DELETE => DeleteAttachment(dbContext, attachmentList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteAttachment(dbContext, attachmentList, optionSet, saveHist), 
			_ => RealDeleteAttachment(dbContext, attachmentList, optionSet, saveHist), 
		};
	}

	private static int CreateAttachmentInternal(IDbContext dbContext, Attachment[] attachmentList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("attachmentList", attachmentList);
		string text = "CreateAttachment";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Attachment> list = new List<Attachment>();
		foreach (Attachment obj in attachmentList)
		{
			Attachment attachment = new Attachment();
			obj.CopyColumsTo(attachment);
			attachment.Activity = text;
			attachment.CheckEntityUsable();
			obj.CopyCommonField(attachment, systemTime, dbContext.Tid, isCreate: true);
			list.Add(attachment);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateAttachment(IDbContext dbContext, Attachment[] attachmentList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("attachmentList", attachmentList);
		string text = "UpdateAttachment";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Attachment> list = new List<Attachment>();
		foreach (Attachment attachment in attachmentList)
		{
			Attachment attachment4Update = GetAttachment4Update(dbContext, attachment.Attachmentsysid, attachment.Siteid);
			if (attachment4Update == null)
			{
				throw new EntityNotFoundException(typeof(Attachment), $"{attachment.Attachmentsysid},{attachment.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Attachment), $"{attachment.Attachmentsysid},{attachment.Siteid}", attachment4Update.Isusable);
			string activity = attachment4Update.Activity;
			string customactivity = attachment4Update.Customactivity;
			string isusable = attachment4Update.Isusable;
			DateTime? createtime = attachment4Update.Createtime;
			string creator = attachment4Update.Creator;
			attachment.CopyColumsTo(attachment4Update);
			attachment4Update.Prevactivity = activity;
			attachment4Update.Prevcustomactivity = customactivity;
			attachment4Update.Creator = creator;
			attachment4Update.Createtime = createtime;
			attachment4Update.Isusable = isusable;
			attachment4Update.Activity = text;
			attachment.CopyCommonField(attachment4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(attachment4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteAttachment(IDbContext dbContext, Attachment[] attachmentList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("attachmentList", attachmentList);
		string text = "DeleteAttachment";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Attachment> list = new List<Attachment>();
		foreach (Attachment attachment in attachmentList)
		{
			Attachment attachment4Update = GetAttachment4Update(dbContext, attachment.Attachmentsysid, attachment.Siteid);
			if (attachment4Update == null)
			{
				throw new EntityNotFoundException(typeof(Attachment), $"{attachment.Attachmentsysid},{attachment.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Attachment), $"{attachment.Attachmentsysid},{attachment.Siteid}", attachment4Update.Isusable);
			attachment4Update.Isusable = "UnUsable";
			attachment.CopyCommonFieldUpdatePrev(attachment4Update, systemTime, dbContext.Tid, text);
			attachment.CopyExtensionCollection(attachment4Update);
			list.Add(attachment4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteAttachment(IDbContext dbContext, Attachment[] attachmentList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("attachmentList", attachmentList);
		string text = "UnDeleteAttachment";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Attachment> list = new List<Attachment>();
		foreach (Attachment attachment in attachmentList)
		{
			Attachment attachment4Update = GetAttachment4Update(dbContext, attachment.Attachmentsysid, attachment.Siteid);
			if (attachment4Update == null)
			{
				throw new EntityNotFoundException(typeof(Attachment), $"{attachment.Attachmentsysid},{attachment.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Attachment), $"{attachment.Attachmentsysid},{attachment.Siteid}", attachment4Update.Isusable);
			attachment4Update.Isusable = "Usable";
			attachment.CopyCommonFieldUpdatePrev(attachment4Update, systemTime, dbContext.Tid, text);
			attachment.CopyExtensionCollection(attachment4Update);
			list.Add(attachment4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteAttachment(IDbContext dbContext, Attachment[] attachmentList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("attachmentList", attachmentList);
		string text = "RealDeleteAttachment";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Attachment> list = new List<Attachment>();
		foreach (Attachment attachment in attachmentList)
		{
			Attachment attachment4Update = GetAttachment4Update(dbContext, attachment.Attachmentsysid, attachment.Siteid);
			if (attachment4Update == null)
			{
				throw new EntityNotFoundException(typeof(Attachment), $"{attachment.Attachmentsysid},{attachment.Siteid}");
			}
			attachment.CopyCommonFieldUpdatePrev(attachment4Update, systemTime, dbContext.Tid, text);
			attachment.CopyExtensionCollection(attachment4Update);
			list.Add(attachment4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static List<string> CreateRelationId(int idCount)
	{
		ParamChecker.ArgumentNotNull("idCount", idCount);
		List<string> list = new List<string>();
		for (int i = 0; i < idCount; i++)
		{
			list.Add(ContextManager.GetNextTID());
		}
		return list;
	}
}
