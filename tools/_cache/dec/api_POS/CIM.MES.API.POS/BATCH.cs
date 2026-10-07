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
public class BATCH
{
	private static string _sqlGetBatchSqlDatabase = "SELECT * FROM CIM_BATCH WHERE BATCHID=@BATCHID AND SITEID=@SITEID";

	private static string _sqlGetBatch4UpdateSqlDatabase = "SELECT * FROM CIM_BATCH WITH(UPDLOCK) WHERE BATCHID=@BATCHID AND SITEID=@SITEID";

	private static string _sqlSelectBatchSqlDatabase = "SELECT * FROM CIM_BATCH WHERE BATCHID=@BATCHID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectBatch4UpdateSqlDatabase = "SELECT * FROM CIM_BATCH WITH(UPDLOCK) WHERE BATCHID=@BATCHID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetBatchOracleDatabase = "SELECT * FROM CIM_BATCH WHERE BATCHID=:BATCHID AND SITEID=:SITEID";

	private static string _sqlGetBatch4UpdateOracleDatabase = "SELECT * FROM CIM_BATCH WHERE BATCHID=:BATCHID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectBatchOracleDatabase = "SELECT * FROM CIM_BATCH WHERE BATCHID=:BATCHID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectBatch4UpdateOracleDatabase = "SELECT * FROM CIM_BATCH WHERE BATCHID=:BATCHID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Batch);

	public static Batch GetBatch(IDbContext dbContext, string batchid, string siteid)
	{
		string apiName = "GetBatch";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{batchid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetBatchSqlDatabase : _sqlGetBatchOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("BATCHID", batchid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_BATCH", $"{batchid},{siteid}"));
		}
		Batch? result = ContextManager.DirectEntityQuery<Batch>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{batchid},{siteid}");
		}
		return result;
	}

	public static Batch GetBatch4Update(IDbContext dbContext, string batchid, string siteid)
	{
		string apiName = "GetBatch4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{batchid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetBatch4UpdateSqlDatabase : _sqlGetBatch4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("BATCHID", batchid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_BATCH", $"{batchid},{siteid}"));
		}
		Batch? result = ContextManager.DirectEntityQuery<Batch>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{batchid},{siteid}");
		}
		return result;
	}

	public static Batch SelectBatch(IDbContext dbContext, string batchid, string siteid)
	{
		string apiName = "SelectBatch";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{batchid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectBatchSqlDatabase : _sqlSelectBatchOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("BATCHID", batchid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_BATCH", $"{batchid},{siteid}"));
		}
		Batch? result = ContextManager.DirectEntityQuery<Batch>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{batchid},{siteid}");
		}
		return result;
	}

	public static Batch SelectBatch4Update(IDbContext dbContext, string batchid, string siteid)
	{
		string apiName = "SelectBatch4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{batchid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectBatch4UpdateSqlDatabase : _sqlSelectBatch4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("BATCHID", batchid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_BATCH", $"{batchid},{siteid}"));
		}
		Batch? result = ContextManager.DirectEntityQuery<Batch>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{batchid},{siteid}");
		}
		return result;
	}

	public static int UpsertBatch(IDbContext dbContext, RequestType requestType, Batch[] batchList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateBatchInternal(dbContext, batchList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateBatch(dbContext, batchList, optionSet, saveHist), 
			RequestType.DELETE => DeleteBatch(dbContext, batchList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteBatch(dbContext, batchList, optionSet, saveHist), 
			_ => RealDeleteBatch(dbContext, batchList, optionSet, saveHist), 
		};
	}

	private static int CreateBatchInternal(IDbContext dbContext, Batch[] batchList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("batchList", batchList);
		string text = "CreateBatch";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Batch> list = new List<Batch>();
		foreach (Batch obj in batchList)
		{
			Batch batch = new Batch();
			obj.CopyColumsTo(batch);
			batch.Activity = text;
			batch.CheckEntityUsable();
			obj.CopyCommonField(batch, systemTime, dbContext.Tid, isCreate: true);
			list.Add(batch);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateBatch(IDbContext dbContext, Batch[] batchList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("batchList", batchList);
		string text = "UpdateBatch";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Batch> list = new List<Batch>();
		foreach (Batch batch in batchList)
		{
			Batch batch4Update = GetBatch4Update(dbContext, batch.Batchid, batch.Siteid);
			if (batch4Update == null)
			{
				throw new EntityNotFoundException(typeof(Batch), $"{batch.Batchid},{batch.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Batch), $"{batch.Batchid},{batch.Siteid}", batch4Update.Isusable);
			string activity = batch4Update.Activity;
			string customactivity = batch4Update.Customactivity;
			string isusable = batch4Update.Isusable;
			DateTime? createtime = batch4Update.Createtime;
			string creator = batch4Update.Creator;
			batch.CopyColumsTo(batch4Update);
			batch4Update.Prevactivity = activity;
			batch4Update.Prevcustomactivity = customactivity;
			batch4Update.Creator = creator;
			batch4Update.Createtime = createtime;
			batch4Update.Isusable = isusable;
			batch4Update.Activity = text;
			batch.CopyCommonField(batch4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(batch4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteBatch(IDbContext dbContext, Batch[] batchList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("batchList", batchList);
		string text = "DeleteBatch";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Batch> list = new List<Batch>();
		foreach (Batch batch in batchList)
		{
			Batch batch4Update = GetBatch4Update(dbContext, batch.Batchid, batch.Siteid);
			if (batch4Update == null)
			{
				throw new EntityNotFoundException(typeof(Batch), $"{batch.Batchid},{batch.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Batch), $"{batch.Batchid},{batch.Siteid}", batch4Update.Isusable);
			batch4Update.Isusable = "UnUsable";
			batch.CopyCommonFieldUpdatePrev(batch4Update, systemTime, dbContext.Tid, text);
			batch.CopyExtensionCollection(batch4Update);
			list.Add(batch4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteBatch(IDbContext dbContext, Batch[] batchList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("batchList", batchList);
		string text = "UnDeleteBatch";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Batch> list = new List<Batch>();
		foreach (Batch batch in batchList)
		{
			Batch batch4Update = GetBatch4Update(dbContext, batch.Batchid, batch.Siteid);
			if (batch4Update == null)
			{
				throw new EntityNotFoundException(typeof(Batch), $"{batch.Batchid},{batch.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Batch), $"{batch.Batchid},{batch.Siteid}", batch4Update.Isusable);
			batch4Update.Isusable = "Usable";
			batch.CopyCommonFieldUpdatePrev(batch4Update, systemTime, dbContext.Tid, text);
			batch.CopyExtensionCollection(batch4Update);
			list.Add(batch4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteBatch(IDbContext dbContext, Batch[] batchList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("batchList", batchList);
		string text = "RealDeleteBatch";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Batch> list = new List<Batch>();
		foreach (Batch batch in batchList)
		{
			Batch batch4Update = GetBatch4Update(dbContext, batch.Batchid, batch.Siteid);
			if (batch4Update == null)
			{
				throw new EntityNotFoundException(typeof(Batch), $"{batch.Batchid},{batch.Siteid}");
			}
			batch.CopyCommonFieldUpdatePrev(batch4Update, systemTime, dbContext.Tid, text);
			batch.CopyExtensionCollection(batch4Update);
			list.Add(batch4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int CreateBatch(IDbContext dbContext, Batch[] batchList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("entityObjectList", batchList);
		string text = "CreateBatch";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Batch> list = new List<Batch>();
		foreach (Batch batch in batchList)
		{
			Batch batch2 = new Batch();
			batch.CopyColumsTo(batch2);
			ParamChecker.ArgumentNotNull("Batchid", batch2.Batchid);
			ParamChecker.ArgumentNotNull("Siteid", batch2.Siteid);
			_ = batch2.Siteid;
			batch2.State = EntityHelper.FirstNotNull<string>(batch.State, "Active");
			batch2.Activity = text;
			batch2.Isusable = "Usable";
			batch.CopyCommonField(batch2, systemTime, dbContext.Tid, isCreate: true);
			list.Add(batch2);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
