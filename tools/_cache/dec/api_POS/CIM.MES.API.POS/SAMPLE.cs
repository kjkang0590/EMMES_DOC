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
public class SAMPLE
{
	private static string _sqlGetSampleSqlDatabase = "SELECT * FROM CIM_SAMPLE WHERE PRODUCTRULESYSID=@PRODUCTRULESYSID AND SITEID=@SITEID";

	private static string _sqlGetSample4UpdateSqlDatabase = "SELECT * FROM CIM_SAMPLE WITH(UPDLOCK) WHERE PRODUCTRULESYSID=@PRODUCTRULESYSID AND SITEID=@SITEID";

	private static string _sqlSelectSampleSqlDatabase = "SELECT * FROM CIM_SAMPLE WHERE PRODUCTRULESYSID=@PRODUCTRULESYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectSample4UpdateSqlDatabase = "SELECT * FROM CIM_SAMPLE WITH(UPDLOCK) WHERE PRODUCTRULESYSID=@PRODUCTRULESYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetSampleOracleDatabase = "SELECT * FROM CIM_SAMPLE WHERE PRODUCTRULESYSID=:PRODUCTRULESYSID AND SITEID=:SITEID";

	private static string _sqlGetSample4UpdateOracleDatabase = "SELECT * FROM CIM_SAMPLE WHERE PRODUCTRULESYSID=:PRODUCTRULESYSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectSampleOracleDatabase = "SELECT * FROM CIM_SAMPLE WHERE PRODUCTRULESYSID=:PRODUCTRULESYSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectSample4UpdateOracleDatabase = "SELECT * FROM CIM_SAMPLE WHERE PRODUCTRULESYSID=:PRODUCTRULESYSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Sample);

	public static Sample GetSample(IDbContext dbContext, string productrulesysid, string siteid)
	{
		string apiName = "GetSample";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productrulesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetSampleSqlDatabase : _sqlGetSampleOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTRULESYSID", productrulesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SAMPLE", $"{productrulesysid},{siteid}"));
		}
		Sample? result = ContextManager.DirectEntityQuery<Sample>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productrulesysid},{siteid}");
		}
		return result;
	}

	public static Sample GetSample4Update(IDbContext dbContext, string productrulesysid, string siteid)
	{
		string apiName = "GetSample4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productrulesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetSample4UpdateSqlDatabase : _sqlGetSample4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTRULESYSID", productrulesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_SAMPLE", $"{productrulesysid},{siteid}"));
		}
		Sample? result = ContextManager.DirectEntityQuery<Sample>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productrulesysid},{siteid}");
		}
		return result;
	}

	public static Sample SelectSample(IDbContext dbContext, string productrulesysid, string siteid)
	{
		string apiName = "SelectSample";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productrulesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectSampleSqlDatabase : _sqlSelectSampleOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTRULESYSID", productrulesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SAMPLE", $"{productrulesysid},{siteid}"));
		}
		Sample? result = ContextManager.DirectEntityQuery<Sample>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productrulesysid},{siteid}");
		}
		return result;
	}

	public static Sample SelectSample4Update(IDbContext dbContext, string productrulesysid, string siteid)
	{
		string apiName = "SelectSample4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productrulesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectSample4UpdateSqlDatabase : _sqlSelectSample4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTRULESYSID", productrulesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_SAMPLE", $"{productrulesysid},{siteid}"));
		}
		Sample? result = ContextManager.DirectEntityQuery<Sample>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productrulesysid},{siteid}");
		}
		return result;
	}

	public static int UpsertSample(IDbContext dbContext, RequestType requestType, Sample[] sampleList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateSampleInternal(dbContext, sampleList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateSample(dbContext, sampleList, optionSet, saveHist), 
			RequestType.DELETE => DeleteSample(dbContext, sampleList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteSample(dbContext, sampleList, optionSet, saveHist), 
			_ => RealDeleteSample(dbContext, sampleList, optionSet, saveHist), 
		};
	}

	private static int CreateSampleInternal(IDbContext dbContext, Sample[] sampleList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("sampleList", sampleList);
		string text = "CreateSample";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Sample> list = new List<Sample>();
		foreach (Sample obj in sampleList)
		{
			Sample sample = new Sample();
			obj.CopyColumsTo(sample);
			sample.Activity = text;
			sample.CheckEntityUsable();
			obj.CopyCommonField(sample, systemTime, dbContext.Tid, isCreate: true);
			list.Add(sample);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateSample(IDbContext dbContext, Sample[] sampleList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("sampleList", sampleList);
		string text = "UpdateSample";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Sample> list = new List<Sample>();
		foreach (Sample sample in sampleList)
		{
			Sample sample4Update = GetSample4Update(dbContext, sample.Productrulesysid, sample.Siteid);
			if (sample4Update == null)
			{
				throw new EntityNotFoundException(typeof(Sample), $"{sample.Productrulesysid},{sample.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Sample), $"{sample.Productrulesysid},{sample.Siteid}", sample4Update.Isusable);
			string activity = sample4Update.Activity;
			string customactivity = sample4Update.Customactivity;
			string isusable = sample4Update.Isusable;
			DateTime? createtime = sample4Update.Createtime;
			string creator = sample4Update.Creator;
			sample.CopyColumsTo(sample4Update);
			sample4Update.Prevactivity = activity;
			sample4Update.Prevcustomactivity = customactivity;
			sample4Update.Creator = creator;
			sample4Update.Createtime = createtime;
			sample4Update.Isusable = isusable;
			sample4Update.Activity = text;
			sample.CopyCommonField(sample4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(sample4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteSample(IDbContext dbContext, Sample[] sampleList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("sampleList", sampleList);
		string text = "DeleteSample";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Sample> list = new List<Sample>();
		foreach (Sample sample in sampleList)
		{
			Sample sample4Update = GetSample4Update(dbContext, sample.Productrulesysid, sample.Siteid);
			if (sample4Update == null)
			{
				throw new EntityNotFoundException(typeof(Sample), $"{sample.Productrulesysid},{sample.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Sample), $"{sample.Productrulesysid},{sample.Siteid}", sample4Update.Isusable);
			sample4Update.Isusable = "UnUsable";
			sample.CopyCommonFieldUpdatePrev(sample4Update, systemTime, dbContext.Tid, text);
			sample.CopyExtensionCollection(sample4Update);
			list.Add(sample4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteSample(IDbContext dbContext, Sample[] sampleList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("sampleList", sampleList);
		string text = "UnDeleteSample";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Sample> list = new List<Sample>();
		foreach (Sample sample in sampleList)
		{
			Sample sample4Update = GetSample4Update(dbContext, sample.Productrulesysid, sample.Siteid);
			if (sample4Update == null)
			{
				throw new EntityNotFoundException(typeof(Sample), $"{sample.Productrulesysid},{sample.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Sample), $"{sample.Productrulesysid},{sample.Siteid}", sample4Update.Isusable);
			sample4Update.Isusable = "Usable";
			sample.CopyCommonFieldUpdatePrev(sample4Update, systemTime, dbContext.Tid, text);
			sample.CopyExtensionCollection(sample4Update);
			list.Add(sample4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteSample(IDbContext dbContext, Sample[] sampleList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("sampleList", sampleList);
		string text = "RealDeleteSample";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Sample> list = new List<Sample>();
		foreach (Sample sample in sampleList)
		{
			Sample sample4Update = GetSample4Update(dbContext, sample.Productrulesysid, sample.Siteid);
			if (sample4Update == null)
			{
				throw new EntityNotFoundException(typeof(Sample), $"{sample.Productrulesysid},{sample.Siteid}");
			}
			sample.CopyCommonFieldUpdatePrev(sample4Update, systemTime, dbContext.Tid, text);
			sample.CopyExtensionCollection(sample4Update);
			list.Add(sample4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
