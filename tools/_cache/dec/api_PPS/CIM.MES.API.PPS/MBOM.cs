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
public class MBOM
{
	private static string _sqlGetMbomSqlDatabase = "SELECT * FROM CIM_MBOM WHERE PRODUCTRULESYSID=@PRODUCTRULESYSID AND MBOMSYSID=@MBOMSYSID AND SITEID=@SITEID";

	private static string _sqlGetMbom4UpdateSqlDatabase = "SELECT * FROM CIM_MBOM WITH(UPDLOCK) WHERE PRODUCTRULESYSID=@PRODUCTRULESYSID AND MBOMSYSID=@MBOMSYSID AND SITEID=@SITEID";

	private static string _sqlSelectMbomSqlDatabase = "SELECT * FROM CIM_MBOM WHERE PRODUCTRULESYSID=@PRODUCTRULESYSID AND MBOMSYSID=@MBOMSYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMbom4UpdateSqlDatabase = "SELECT * FROM CIM_MBOM WITH(UPDLOCK) WHERE PRODUCTRULESYSID=@PRODUCTRULESYSID AND MBOMSYSID=@MBOMSYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetMbomOracleDatabase = "SELECT * FROM CIM_MBOM WHERE PRODUCTRULESYSID=:PRODUCTRULESYSID AND MBOMSYSID=:MBOMSYSID AND SITEID=:SITEID";

	private static string _sqlGetMbom4UpdateOracleDatabase = "SELECT * FROM CIM_MBOM WHERE PRODUCTRULESYSID=:PRODUCTRULESYSID AND MBOMSYSID=:MBOMSYSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectMbomOracleDatabase = "SELECT * FROM CIM_MBOM WHERE PRODUCTRULESYSID=:PRODUCTRULESYSID AND MBOMSYSID=:MBOMSYSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectMbom4UpdateOracleDatabase = "SELECT * FROM CIM_MBOM WHERE PRODUCTRULESYSID=:PRODUCTRULESYSID AND MBOMSYSID=:MBOMSYSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Mbom);

	public static Mbom GetMbom(IDbContext dbContext, string productrulesysid, string mbomsysid, string siteid)
	{
		string apiName = "GetMbom";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productrulesysid},{mbomsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetMbomSqlDatabase : _sqlGetMbomOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTRULESYSID", productrulesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("MBOMSYSID", mbomsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MBOM", $"{productrulesysid},{mbomsysid},{siteid}"));
		}
		Mbom? result = ContextManager.DirectEntityQuery<Mbom>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productrulesysid},{mbomsysid},{siteid}");
		}
		return result;
	}

	public static Mbom GetMbom4Update(IDbContext dbContext, string productrulesysid, string mbomsysid, string siteid)
	{
		string apiName = "GetMbom4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productrulesysid},{mbomsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetMbom4UpdateSqlDatabase : _sqlGetMbom4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTRULESYSID", productrulesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("MBOMSYSID", mbomsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_MBOM", $"{productrulesysid},{mbomsysid},{siteid}"));
		}
		Mbom? result = ContextManager.DirectEntityQuery<Mbom>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productrulesysid},{mbomsysid},{siteid}");
		}
		return result;
	}

	public static Mbom SelectMbom(IDbContext dbContext, string productrulesysid, string mbomsysid, string siteid)
	{
		string apiName = "SelectMbom";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productrulesysid},{mbomsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMbomSqlDatabase : _sqlSelectMbomOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTRULESYSID", productrulesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("MBOMSYSID", mbomsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_MBOM", $"{productrulesysid},{mbomsysid},{siteid}"));
		}
		Mbom? result = ContextManager.DirectEntityQuery<Mbom>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productrulesysid},{mbomsysid},{siteid}");
		}
		return result;
	}

	public static Mbom SelectMbom4Update(IDbContext dbContext, string productrulesysid, string mbomsysid, string siteid)
	{
		string apiName = "SelectMbom4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productrulesysid},{mbomsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectMbom4UpdateSqlDatabase : _sqlSelectMbom4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTRULESYSID", productrulesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("MBOMSYSID", mbomsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_MBOM", $"{productrulesysid},{mbomsysid},{siteid}"));
		}
		Mbom? result = ContextManager.DirectEntityQuery<Mbom>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productrulesysid},{mbomsysid},{siteid}");
		}
		return result;
	}

	public static int UpsertMbom(IDbContext dbContext, RequestType requestType, Mbom[] mbomList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateMbomInternal(dbContext, mbomList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateMbom(dbContext, mbomList, optionSet, saveHist), 
			RequestType.DELETE => DeleteMbom(dbContext, mbomList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteMbom(dbContext, mbomList, optionSet, saveHist), 
			_ => RealDeleteMbom(dbContext, mbomList, optionSet, saveHist), 
		};
	}

	private static int CreateMbomInternal(IDbContext dbContext, Mbom[] mbomList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("mbomList", mbomList);
		string text = "CreateMbom";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Mbom> list = new List<Mbom>();
		foreach (Mbom obj in mbomList)
		{
			Mbom mbom = new Mbom();
			obj.CopyColumsTo(mbom);
			mbom.Activity = text;
			mbom.CheckEntityUsable();
			obj.CopyCommonField(mbom, systemTime, dbContext.Tid, isCreate: true);
			list.Add(mbom);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateMbom(IDbContext dbContext, Mbom[] mbomList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("mbomList", mbomList);
		string text = "UpdateMbom";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Mbom> list = new List<Mbom>();
		foreach (Mbom mbom in mbomList)
		{
			Mbom mbom4Update = GetMbom4Update(dbContext, mbom.Productrulesysid, mbom.Mbomsysid, mbom.Siteid);
			if (mbom4Update == null)
			{
				throw new EntityNotFoundException(typeof(Mbom), $"{mbom.Productrulesysid},{mbom.Mbomsysid},{mbom.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Mbom), $"{mbom.Productrulesysid},{mbom.Mbomsysid},{mbom.Siteid}", mbom4Update.Isusable);
			string activity = mbom4Update.Activity;
			string customactivity = mbom4Update.Customactivity;
			string isusable = mbom4Update.Isusable;
			DateTime? createtime = mbom4Update.Createtime;
			string creator = mbom4Update.Creator;
			mbom.CopyColumsTo(mbom4Update);
			mbom4Update.Prevactivity = activity;
			mbom4Update.Prevcustomactivity = customactivity;
			mbom4Update.Creator = creator;
			mbom4Update.Createtime = createtime;
			mbom4Update.Isusable = isusable;
			mbom4Update.Activity = text;
			mbom.CopyCommonField(mbom4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(mbom4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteMbom(IDbContext dbContext, Mbom[] mbomList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("mbomList", mbomList);
		string text = "DeleteMbom";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Mbom> list = new List<Mbom>();
		foreach (Mbom mbom in mbomList)
		{
			Mbom mbom4Update = GetMbom4Update(dbContext, mbom.Productrulesysid, mbom.Mbomsysid, mbom.Siteid);
			if (mbom4Update == null)
			{
				throw new EntityNotFoundException(typeof(Mbom), $"{mbom.Productrulesysid},{mbom.Mbomsysid},{mbom.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Mbom), $"{mbom.Productrulesysid},{mbom.Mbomsysid},{mbom.Siteid}", mbom4Update.Isusable);
			mbom4Update.Isusable = "UnUsable";
			mbom.CopyCommonFieldUpdatePrev(mbom4Update, systemTime, dbContext.Tid, text);
			mbom.CopyExtensionCollection(mbom4Update);
			list.Add(mbom4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteMbom(IDbContext dbContext, Mbom[] mbomList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("mbomList", mbomList);
		string text = "UnDeleteMbom";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Mbom> list = new List<Mbom>();
		foreach (Mbom mbom in mbomList)
		{
			Mbom mbom4Update = GetMbom4Update(dbContext, mbom.Productrulesysid, mbom.Mbomsysid, mbom.Siteid);
			if (mbom4Update == null)
			{
				throw new EntityNotFoundException(typeof(Mbom), $"{mbom.Productrulesysid},{mbom.Mbomsysid},{mbom.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Mbom), $"{mbom.Productrulesysid},{mbom.Mbomsysid},{mbom.Siteid}", mbom4Update.Isusable);
			mbom4Update.Isusable = "Usable";
			mbom.CopyCommonFieldUpdatePrev(mbom4Update, systemTime, dbContext.Tid, text);
			mbom.CopyExtensionCollection(mbom4Update);
			list.Add(mbom4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteMbom(IDbContext dbContext, Mbom[] mbomList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("mbomList", mbomList);
		string text = "RealDeleteMbom";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Mbom> list = new List<Mbom>();
		foreach (Mbom mbom in mbomList)
		{
			Mbom mbom4Update = GetMbom4Update(dbContext, mbom.Productrulesysid, mbom.Mbomsysid, mbom.Siteid);
			if (mbom4Update == null)
			{
				throw new EntityNotFoundException(typeof(Mbom), $"{mbom.Productrulesysid},{mbom.Mbomsysid},{mbom.Siteid}");
			}
			mbom.CopyCommonFieldUpdatePrev(mbom4Update, systemTime, dbContext.Tid, text);
			mbom.CopyExtensionCollection(mbom4Update);
			list.Add(mbom4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
