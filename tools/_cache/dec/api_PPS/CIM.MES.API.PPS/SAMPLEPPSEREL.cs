using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.PPS;

[MESAPI]
public class SAMPLEPPSEREL
{
	private static string _sqlGetSamplePPSERelSqlDatabase = "SELECT * FROM CIM_SAMPLEPPSEREL WHERE PRODUCTRULESYSID=@PRODUCTRULESYSID AND SITEID=@SITEID";

	private static string _sqlGetSamplePPSERel4UpdateSqlDatabase = "SELECT * FROM CIM_SAMPLEPPSEREL WITH(UPDLOCK) WHERE PRODUCTRULESYSID=@PRODUCTRULESYSID AND SITEID=@SITEID";

	private static string _sqlSelectSamplePPSERelSqlDatabase = "SELECT * FROM CIM_SAMPLEPPSEREL WHERE PRODUCTRULESYSID=@PRODUCTRULESYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectSamplePPSERel4UpdateSqlDatabase = "SELECT * FROM CIM_SAMPLEPPSEREL WITH(UPDLOCK) WHERE PRODUCTRULESYSID=@PRODUCTRULESYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetSamplePPSERelOracleDatabase = "SELECT * FROM CIM_SAMPLEPPSEREL WHERE PRODUCTRULESYSID=:PRODUCTRULESYSID AND SITEID=:SITEID";

	private static string _sqlGetSamplePPSERel4UpdateOracleDatabase = "SELECT * FROM CIM_SAMPLEPPSEREL WHERE PRODUCTRULESYSID=:PRODUCTRULESYSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectSamplePPSERelOracleDatabase = "SELECT * FROM CIM_SAMPLEPPSEREL WHERE PRODUCTRULESYSID=:PRODUCTRULESYSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectSamplePPSERel4UpdateOracleDatabase = "SELECT * FROM CIM_SAMPLEPPSEREL WHERE PRODUCTRULESYSID=:PRODUCTRULESYSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Sampleppserel);

	public static Sampleppserel GetSamplePPSERel(IDbContext dbContext, string productrulesysid, string siteid)
	{
		string apiName = "GetSamplePPSERel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productrulesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetSamplePPSERelSqlDatabase : _sqlGetSamplePPSERelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTRULESYSID", productrulesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SAMPLEPPSEREL", $"{productrulesysid},{siteid}"));
		}
		Sampleppserel? result = ContextManager.DirectEntityQuery<Sampleppserel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productrulesysid},{siteid}");
		}
		return result;
	}

	public static Sampleppserel GetSamplePPSERel4Update(IDbContext dbContext, string productrulesysid, string siteid)
	{
		string apiName = "GetSamplePPSERel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productrulesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetSamplePPSERel4UpdateSqlDatabase : _sqlGetSamplePPSERel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTRULESYSID", productrulesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_SAMPLEPPSEREL", $"{productrulesysid},{siteid}"));
		}
		Sampleppserel? result = ContextManager.DirectEntityQuery<Sampleppserel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productrulesysid},{siteid}");
		}
		return result;
	}

	public static Sampleppserel SelectSamplePPSERel(IDbContext dbContext, string productrulesysid, string siteid)
	{
		string apiName = "SelectSamplePPSERel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productrulesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectSamplePPSERelSqlDatabase : _sqlSelectSamplePPSERelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTRULESYSID", productrulesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SAMPLEPPSEREL", $"{productrulesysid},{siteid}"));
		}
		Sampleppserel? result = ContextManager.DirectEntityQuery<Sampleppserel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productrulesysid},{siteid}");
		}
		return result;
	}

	public static Sampleppserel SelectSamplePPSERel4Update(IDbContext dbContext, string productrulesysid, string siteid)
	{
		string apiName = "SelectSamplePPSERel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productrulesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectSamplePPSERel4UpdateSqlDatabase : _sqlSelectSamplePPSERel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTRULESYSID", productrulesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_SAMPLEPPSEREL", $"{productrulesysid},{siteid}"));
		}
		Sampleppserel? result = ContextManager.DirectEntityQuery<Sampleppserel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productrulesysid},{siteid}");
		}
		return result;
	}

	public static int UpsertSamplePPSERel(IDbContext dbContext, RequestType requestType, Sampleppserel[] samplePPSERelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateSamplePPSERelInternal(dbContext, samplePPSERelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateSamplePPSERel(dbContext, samplePPSERelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteSamplePPSERel(dbContext, samplePPSERelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteSamplePPSERel(dbContext, samplePPSERelList, optionSet, saveHist), 
			_ => RealDeleteSamplePPSERel(dbContext, samplePPSERelList, optionSet, saveHist), 
		};
	}

	private static int CreateSamplePPSERelInternal(IDbContext dbContext, Sampleppserel[] samplePPSERelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("samplePPSERelList", samplePPSERelList);
		string text = "CreateSamplePPSERel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Sampleppserel> list = new List<Sampleppserel>();
		foreach (Sampleppserel obj in samplePPSERelList)
		{
			Sampleppserel sampleppserel = new Sampleppserel();
			obj.CopyColumsTo(sampleppserel);
			sampleppserel.Activity = text;
			sampleppserel.CheckEntityUsable();
			obj.CopyCommonField(sampleppserel, systemTime, dbContext.Tid, isCreate: true);
			list.Add(sampleppserel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateSamplePPSERel(IDbContext dbContext, Sampleppserel[] samplePPSERelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("samplePPSERelList", samplePPSERelList);
		string text = "UpdateSamplePPSERel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Sampleppserel> list = new List<Sampleppserel>();
		foreach (Sampleppserel sampleppserel in samplePPSERelList)
		{
			Sampleppserel samplePPSERel4Update = GetSamplePPSERel4Update(dbContext, sampleppserel.Productrulesysid, sampleppserel.Siteid);
			if (samplePPSERel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Sampleppserel), $"{sampleppserel.Productrulesysid},{sampleppserel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Sampleppserel), $"{sampleppserel.Productrulesysid},{sampleppserel.Siteid}", samplePPSERel4Update.Isusable);
			string activity = samplePPSERel4Update.Activity;
			string customactivity = samplePPSERel4Update.Customactivity;
			string isusable = samplePPSERel4Update.Isusable;
			DateTime? createtime = samplePPSERel4Update.Createtime;
			string creator = samplePPSERel4Update.Creator;
			sampleppserel.CopyColumsTo(samplePPSERel4Update);
			samplePPSERel4Update.Prevactivity = activity;
			samplePPSERel4Update.Prevcustomactivity = customactivity;
			samplePPSERel4Update.Creator = creator;
			samplePPSERel4Update.Createtime = createtime;
			samplePPSERel4Update.Isusable = isusable;
			samplePPSERel4Update.Activity = text;
			sampleppserel.CopyCommonField(samplePPSERel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(samplePPSERel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteSamplePPSERel(IDbContext dbContext, Sampleppserel[] samplePPSERelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("samplePPSERelList", samplePPSERelList);
		string text = "DeleteSamplePPSERel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Sampleppserel> list = new List<Sampleppserel>();
		foreach (Sampleppserel sampleppserel in samplePPSERelList)
		{
			Sampleppserel samplePPSERel4Update = GetSamplePPSERel4Update(dbContext, sampleppserel.Productrulesysid, sampleppserel.Siteid);
			if (samplePPSERel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Sampleppserel), $"{sampleppserel.Productrulesysid},{sampleppserel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Sampleppserel), $"{sampleppserel.Productrulesysid},{sampleppserel.Siteid}", samplePPSERel4Update.Isusable);
			samplePPSERel4Update.Isusable = "UnUsable";
			sampleppserel.CopyCommonFieldUpdatePrev(samplePPSERel4Update, systemTime, dbContext.Tid, text);
			sampleppserel.CopyExtensionCollection(samplePPSERel4Update);
			list.Add(samplePPSERel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteSamplePPSERel(IDbContext dbContext, Sampleppserel[] samplePPSERelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("samplePPSERelList", samplePPSERelList);
		string text = "UnDeleteSamplePPSERel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Sampleppserel> list = new List<Sampleppserel>();
		foreach (Sampleppserel sampleppserel in samplePPSERelList)
		{
			Sampleppserel samplePPSERel4Update = GetSamplePPSERel4Update(dbContext, sampleppserel.Productrulesysid, sampleppserel.Siteid);
			if (samplePPSERel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Sampleppserel), $"{sampleppserel.Productrulesysid},{sampleppserel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Sampleppserel), $"{sampleppserel.Productrulesysid},{sampleppserel.Siteid}", samplePPSERel4Update.Isusable);
			samplePPSERel4Update.Isusable = "Usable";
			sampleppserel.CopyCommonFieldUpdatePrev(samplePPSERel4Update, systemTime, dbContext.Tid, text);
			sampleppserel.CopyExtensionCollection(samplePPSERel4Update);
			list.Add(samplePPSERel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteSamplePPSERel(IDbContext dbContext, Sampleppserel[] samplePPSERelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("samplePPSERelList", samplePPSERelList);
		string text = "RealDeleteSamplePPSERel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Sampleppserel> list = new List<Sampleppserel>();
		foreach (Sampleppserel sampleppserel in samplePPSERelList)
		{
			Sampleppserel samplePPSERel4Update = GetSamplePPSERel4Update(dbContext, sampleppserel.Productrulesysid, sampleppserel.Siteid);
			if (samplePPSERel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Sampleppserel), $"{sampleppserel.Productrulesysid},{sampleppserel.Siteid}");
			}
			sampleppserel.CopyCommonFieldUpdatePrev(samplePPSERel4Update, systemTime, dbContext.Tid, text);
			sampleppserel.CopyExtensionCollection(samplePPSERel4Update);
			list.Add(samplePPSERel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
