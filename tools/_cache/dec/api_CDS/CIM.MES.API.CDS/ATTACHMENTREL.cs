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
public class ATTACHMENTREL
{
	private static string _sqlGetAttachmentRelSqlDatabase = "SELECT * FROM CIM_ATTACHMENTREL WHERE ATTACHMENTSYSID=@ATTACHMENTSYSID AND RELATIONID=@RELATIONID AND SITEID=@SITEID";

	private static string _sqlGetAttachmentRel4UpdateSqlDatabase = "SELECT * FROM CIM_ATTACHMENTREL WITH(UPDLOCK) WHERE ATTACHMENTSYSID=@ATTACHMENTSYSID AND RELATIONID=@RELATIONID AND SITEID=@SITEID";

	private static string _sqlSelectAttachmentRelSqlDatabase = "SELECT * FROM CIM_ATTACHMENTREL WHERE ATTACHMENTSYSID=@ATTACHMENTSYSID AND RELATIONID=@RELATIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectAttachmentRel4UpdateSqlDatabase = "SELECT * FROM CIM_ATTACHMENTREL WITH(UPDLOCK) WHERE ATTACHMENTSYSID=@ATTACHMENTSYSID AND RELATIONID=@RELATIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetAttachmentRelOracleDatabase = "SELECT * FROM CIM_ATTACHMENTREL WHERE ATTACHMENTSYSID=:ATTACHMENTSYSID AND RELATIONID=:RELATIONID AND SITEID=:SITEID";

	private static string _sqlGetAttachmentRel4UpdateOracleDatabase = "SELECT * FROM CIM_ATTACHMENTREL WHERE ATTACHMENTSYSID=:ATTACHMENTSYSID AND RELATIONID=:RELATIONID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectAttachmentRelOracleDatabase = "SELECT * FROM CIM_ATTACHMENTREL WHERE ATTACHMENTSYSID=:ATTACHMENTSYSID AND RELATIONID=:RELATIONID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectAttachmentRel4UpdateOracleDatabase = "SELECT * FROM CIM_ATTACHMENTREL WHERE ATTACHMENTSYSID=:ATTACHMENTSYSID AND RELATIONID=:RELATIONID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Attachmentrel);

	public static Attachmentrel GetAttachmentRel(IDbContext dbContext, string attachmentsysid, string relationid, string siteid)
	{
		string apiName = "GetAttachmentRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{attachmentsysid},{relationid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetAttachmentRelSqlDatabase : _sqlGetAttachmentRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ATTACHMENTSYSID", attachmentsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("RELATIONID", relationid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_ATTACHMENTREL", $"{attachmentsysid},{relationid},{siteid}"));
		}
		Attachmentrel? result = ContextManager.DirectEntityQuery<Attachmentrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{attachmentsysid},{relationid},{siteid}");
		}
		return result;
	}

	public static Attachmentrel GetAttachmentRel4Update(IDbContext dbContext, string attachmentsysid, string relationid, string siteid)
	{
		string apiName = "GetAttachmentRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{attachmentsysid},{relationid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetAttachmentRel4UpdateSqlDatabase : _sqlGetAttachmentRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ATTACHMENTSYSID", attachmentsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("RELATIONID", relationid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_ATTACHMENTREL", $"{attachmentsysid},{relationid},{siteid}"));
		}
		Attachmentrel? result = ContextManager.DirectEntityQuery<Attachmentrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{attachmentsysid},{relationid},{siteid}");
		}
		return result;
	}

	public static Attachmentrel SelectAttachmentRel(IDbContext dbContext, string attachmentsysid, string relationid, string siteid)
	{
		string apiName = "SelectAttachmentRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{attachmentsysid},{relationid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectAttachmentRelSqlDatabase : _sqlSelectAttachmentRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ATTACHMENTSYSID", attachmentsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("RELATIONID", relationid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_ATTACHMENTREL", $"{attachmentsysid},{relationid},{siteid}"));
		}
		Attachmentrel? result = ContextManager.DirectEntityQuery<Attachmentrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{attachmentsysid},{relationid},{siteid}");
		}
		return result;
	}

	public static Attachmentrel SelectAttachmentRel4Update(IDbContext dbContext, string attachmentsysid, string relationid, string siteid)
	{
		string apiName = "SelectAttachmentRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{attachmentsysid},{relationid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectAttachmentRel4UpdateSqlDatabase : _sqlSelectAttachmentRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ATTACHMENTSYSID", attachmentsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("RELATIONID", relationid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_ATTACHMENTREL", $"{attachmentsysid},{relationid},{siteid}"));
		}
		Attachmentrel? result = ContextManager.DirectEntityQuery<Attachmentrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{attachmentsysid},{relationid},{siteid}");
		}
		return result;
	}

	public static int UpsertAttachmentRel(IDbContext dbContext, RequestType requestType, Attachmentrel[] attachmentRelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateAttachmentRelInternal(dbContext, attachmentRelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateAttachmentRel(dbContext, attachmentRelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteAttachmentRel(dbContext, attachmentRelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteAttachmentRel(dbContext, attachmentRelList, optionSet, saveHist), 
			_ => RealDeleteAttachmentRel(dbContext, attachmentRelList, optionSet, saveHist), 
		};
	}

	private static int CreateAttachmentRelInternal(IDbContext dbContext, Attachmentrel[] attachmentRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("attachmentRelList", attachmentRelList);
		string text = "CreateAttachmentRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Attachmentrel> list = new List<Attachmentrel>();
		foreach (Attachmentrel obj in attachmentRelList)
		{
			Attachmentrel attachmentrel = new Attachmentrel();
			obj.CopyColumsTo(attachmentrel);
			attachmentrel.Activity = text;
			attachmentrel.CheckEntityUsable();
			obj.CopyCommonField(attachmentrel, systemTime, dbContext.Tid, isCreate: true);
			list.Add(attachmentrel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateAttachmentRel(IDbContext dbContext, Attachmentrel[] attachmentRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("attachmentRelList", attachmentRelList);
		string text = "UpdateAttachmentRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Attachmentrel> list = new List<Attachmentrel>();
		foreach (Attachmentrel attachmentrel in attachmentRelList)
		{
			Attachmentrel attachmentRel4Update = GetAttachmentRel4Update(dbContext, attachmentrel.Attachmentsysid, attachmentrel.Relationid, attachmentrel.Siteid);
			if (attachmentRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Attachmentrel), $"{attachmentrel.Attachmentsysid},{attachmentrel.Relationid},{attachmentrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Attachmentrel), $"{attachmentrel.Attachmentsysid},{attachmentrel.Relationid},{attachmentrel.Siteid}", attachmentRel4Update.Isusable);
			string activity = attachmentRel4Update.Activity;
			string customactivity = attachmentRel4Update.Customactivity;
			string isusable = attachmentRel4Update.Isusable;
			DateTime? createtime = attachmentRel4Update.Createtime;
			string creator = attachmentRel4Update.Creator;
			attachmentrel.CopyColumsTo(attachmentRel4Update);
			attachmentRel4Update.Prevactivity = activity;
			attachmentRel4Update.Prevcustomactivity = customactivity;
			attachmentRel4Update.Creator = creator;
			attachmentRel4Update.Createtime = createtime;
			attachmentRel4Update.Isusable = isusable;
			attachmentRel4Update.Activity = text;
			attachmentrel.CopyCommonField(attachmentRel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(attachmentRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteAttachmentRel(IDbContext dbContext, Attachmentrel[] attachmentRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("attachmentRelList", attachmentRelList);
		string text = "DeleteAttachmentRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Attachmentrel> list = new List<Attachmentrel>();
		foreach (Attachmentrel attachmentrel in attachmentRelList)
		{
			Attachmentrel attachmentRel4Update = GetAttachmentRel4Update(dbContext, attachmentrel.Attachmentsysid, attachmentrel.Relationid, attachmentrel.Siteid);
			if (attachmentRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Attachmentrel), $"{attachmentrel.Attachmentsysid},{attachmentrel.Relationid},{attachmentrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Attachmentrel), $"{attachmentrel.Attachmentsysid},{attachmentrel.Relationid},{attachmentrel.Siteid}", attachmentRel4Update.Isusable);
			attachmentRel4Update.Isusable = "UnUsable";
			attachmentrel.CopyCommonFieldUpdatePrev(attachmentRel4Update, systemTime, dbContext.Tid, text);
			attachmentrel.CopyExtensionCollection(attachmentRel4Update);
			list.Add(attachmentRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteAttachmentRel(IDbContext dbContext, Attachmentrel[] attachmentRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("attachmentRelList", attachmentRelList);
		string text = "UnDeleteAttachmentRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Attachmentrel> list = new List<Attachmentrel>();
		foreach (Attachmentrel attachmentrel in attachmentRelList)
		{
			Attachmentrel attachmentRel4Update = GetAttachmentRel4Update(dbContext, attachmentrel.Attachmentsysid, attachmentrel.Relationid, attachmentrel.Siteid);
			if (attachmentRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Attachmentrel), $"{attachmentrel.Attachmentsysid},{attachmentrel.Relationid},{attachmentrel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Attachmentrel), $"{attachmentrel.Attachmentsysid},{attachmentrel.Relationid},{attachmentrel.Siteid}", attachmentRel4Update.Isusable);
			attachmentRel4Update.Isusable = "Usable";
			attachmentrel.CopyCommonFieldUpdatePrev(attachmentRel4Update, systemTime, dbContext.Tid, text);
			attachmentrel.CopyExtensionCollection(attachmentRel4Update);
			list.Add(attachmentRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteAttachmentRel(IDbContext dbContext, Attachmentrel[] attachmentRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("attachmentRelList", attachmentRelList);
		string text = "RealDeleteAttachmentRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Attachmentrel> list = new List<Attachmentrel>();
		foreach (Attachmentrel attachmentrel in attachmentRelList)
		{
			Attachmentrel attachmentRel4Update = GetAttachmentRel4Update(dbContext, attachmentrel.Attachmentsysid, attachmentrel.Relationid, attachmentrel.Siteid);
			if (attachmentRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Attachmentrel), $"{attachmentrel.Attachmentsysid},{attachmentrel.Relationid},{attachmentrel.Siteid}");
			}
			attachmentrel.CopyCommonFieldUpdatePrev(attachmentRel4Update, systemTime, dbContext.Tid, text);
			attachmentrel.CopyExtensionCollection(attachmentRel4Update);
			list.Add(attachmentRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
