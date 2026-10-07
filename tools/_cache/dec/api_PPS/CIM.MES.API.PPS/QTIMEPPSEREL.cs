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
public class QTIMEPPSEREL
{
	private static string _sqlGetQtimePPSERelSqlDatabase = "SELECT * FROM CIM_QTIMEPPSEREL WHERE PRODUCTRULESYSID=@PRODUCTRULESYSID AND SITEID=@SITEID";

	private static string _sqlGetQtimePPSERel4UpdateSqlDatabase = "SELECT * FROM CIM_QTIMEPPSEREL WITH(UPDLOCK) WHERE PRODUCTRULESYSID=@PRODUCTRULESYSID AND SITEID=@SITEID";

	private static string _sqlSelectQtimePPSERelSqlDatabase = "SELECT * FROM CIM_QTIMEPPSEREL WHERE PRODUCTRULESYSID=@PRODUCTRULESYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectQtimePPSERel4UpdateSqlDatabase = "SELECT * FROM CIM_QTIMEPPSEREL WITH(UPDLOCK) WHERE PRODUCTRULESYSID=@PRODUCTRULESYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetQtimePPSERelOracleDatabase = "SELECT * FROM CIM_QTIMEPPSEREL WHERE PRODUCTRULESYSID=:PRODUCTRULESYSID AND SITEID=:SITEID";

	private static string _sqlGetQtimePPSERel4UpdateOracleDatabase = "SELECT * FROM CIM_QTIMEPPSEREL WHERE PRODUCTRULESYSID=:PRODUCTRULESYSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectQtimePPSERelOracleDatabase = "SELECT * FROM CIM_QTIMEPPSEREL WHERE PRODUCTRULESYSID=:PRODUCTRULESYSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectQtimePPSERel4UpdateOracleDatabase = "SELECT * FROM CIM_QTIMEPPSEREL WHERE PRODUCTRULESYSID=:PRODUCTRULESYSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Qtimeppserel);

	public static Qtimeppserel GetQtimePPSERel(IDbContext dbContext, string productrulesysid, string siteid)
	{
		string apiName = "GetQtimePPSERel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productrulesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetQtimePPSERelSqlDatabase : _sqlGetQtimePPSERelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTRULESYSID", productrulesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_QTIMEPPSEREL", $"{productrulesysid},{siteid}"));
		}
		Qtimeppserel? result = ContextManager.DirectEntityQuery<Qtimeppserel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productrulesysid},{siteid}");
		}
		return result;
	}

	public static Qtimeppserel GetQtimePPSERel4Update(IDbContext dbContext, string productrulesysid, string siteid)
	{
		string apiName = "GetQtimePPSERel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productrulesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetQtimePPSERel4UpdateSqlDatabase : _sqlGetQtimePPSERel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTRULESYSID", productrulesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_QTIMEPPSEREL", $"{productrulesysid},{siteid}"));
		}
		Qtimeppserel? result = ContextManager.DirectEntityQuery<Qtimeppserel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productrulesysid},{siteid}");
		}
		return result;
	}

	public static Qtimeppserel SelectQtimePPSERel(IDbContext dbContext, string productrulesysid, string siteid)
	{
		string apiName = "SelectQtimePPSERel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productrulesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectQtimePPSERelSqlDatabase : _sqlSelectQtimePPSERelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTRULESYSID", productrulesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_QTIMEPPSEREL", $"{productrulesysid},{siteid}"));
		}
		Qtimeppserel? result = ContextManager.DirectEntityQuery<Qtimeppserel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productrulesysid},{siteid}");
		}
		return result;
	}

	public static Qtimeppserel SelectQtimePPSERel4Update(IDbContext dbContext, string productrulesysid, string siteid)
	{
		string apiName = "SelectQtimePPSERel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{productrulesysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectQtimePPSERel4UpdateSqlDatabase : _sqlSelectQtimePPSERel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PRODUCTRULESYSID", productrulesysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_QTIMEPPSEREL", $"{productrulesysid},{siteid}"));
		}
		Qtimeppserel? result = ContextManager.DirectEntityQuery<Qtimeppserel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{productrulesysid},{siteid}");
		}
		return result;
	}

	public static int UpsertQtimePPSERel(IDbContext dbContext, RequestType requestType, Qtimeppserel[] qtimePPSERelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateQtimePPSERelInternal(dbContext, qtimePPSERelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateQtimePPSERel(dbContext, qtimePPSERelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteQtimePPSERel(dbContext, qtimePPSERelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteQtimePPSERel(dbContext, qtimePPSERelList, optionSet, saveHist), 
			_ => RealDeleteQtimePPSERel(dbContext, qtimePPSERelList, optionSet, saveHist), 
		};
	}

	private static int CreateQtimePPSERelInternal(IDbContext dbContext, Qtimeppserel[] qtimePPSERelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("qtimePPSERelList", qtimePPSERelList);
		string text = "CreateQtimePPSERel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Qtimeppserel> list = new List<Qtimeppserel>();
		foreach (Qtimeppserel obj in qtimePPSERelList)
		{
			Qtimeppserel qtimeppserel = new Qtimeppserel();
			obj.CopyColumsTo(qtimeppserel);
			qtimeppserel.Activity = text;
			qtimeppserel.CheckEntityUsable();
			obj.CopyCommonField(qtimeppserel, systemTime, dbContext.Tid, isCreate: true);
			list.Add(qtimeppserel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateQtimePPSERel(IDbContext dbContext, Qtimeppserel[] qtimePPSERelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("qtimePPSERelList", qtimePPSERelList);
		string text = "UpdateQtimePPSERel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Qtimeppserel> list = new List<Qtimeppserel>();
		foreach (Qtimeppserel qtimeppserel in qtimePPSERelList)
		{
			Qtimeppserel qtimePPSERel4Update = GetQtimePPSERel4Update(dbContext, qtimeppserel.Productrulesysid, qtimeppserel.Siteid);
			if (qtimePPSERel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Qtimeppserel), $"{qtimeppserel.Productrulesysid},{qtimeppserel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Qtimeppserel), $"{qtimeppserel.Productrulesysid},{qtimeppserel.Siteid}", qtimePPSERel4Update.Isusable);
			string activity = qtimePPSERel4Update.Activity;
			string customactivity = qtimePPSERel4Update.Customactivity;
			string isusable = qtimePPSERel4Update.Isusable;
			DateTime? createtime = qtimePPSERel4Update.Createtime;
			string creator = qtimePPSERel4Update.Creator;
			qtimeppserel.CopyColumsTo(qtimePPSERel4Update);
			qtimePPSERel4Update.Prevactivity = activity;
			qtimePPSERel4Update.Prevcustomactivity = customactivity;
			qtimePPSERel4Update.Creator = creator;
			qtimePPSERel4Update.Createtime = createtime;
			qtimePPSERel4Update.Isusable = isusable;
			qtimePPSERel4Update.Activity = text;
			qtimeppserel.CopyCommonField(qtimePPSERel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(qtimePPSERel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteQtimePPSERel(IDbContext dbContext, Qtimeppserel[] qtimePPSERelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("qtimePPSERelList", qtimePPSERelList);
		string text = "DeleteQtimePPSERel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Qtimeppserel> list = new List<Qtimeppserel>();
		foreach (Qtimeppserel qtimeppserel in qtimePPSERelList)
		{
			Qtimeppserel qtimePPSERel4Update = GetQtimePPSERel4Update(dbContext, qtimeppserel.Productrulesysid, qtimeppserel.Siteid);
			if (qtimePPSERel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Qtimeppserel), $"{qtimeppserel.Productrulesysid},{qtimeppserel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Qtimeppserel), $"{qtimeppserel.Productrulesysid},{qtimeppserel.Siteid}", qtimePPSERel4Update.Isusable);
			qtimePPSERel4Update.Isusable = "UnUsable";
			qtimeppserel.CopyCommonFieldUpdatePrev(qtimePPSERel4Update, systemTime, dbContext.Tid, text);
			qtimeppserel.CopyExtensionCollection(qtimePPSERel4Update);
			list.Add(qtimePPSERel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteQtimePPSERel(IDbContext dbContext, Qtimeppserel[] qtimePPSERelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("qtimePPSERelList", qtimePPSERelList);
		string text = "UnDeleteQtimePPSERel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Qtimeppserel> list = new List<Qtimeppserel>();
		foreach (Qtimeppserel qtimeppserel in qtimePPSERelList)
		{
			Qtimeppserel qtimePPSERel4Update = GetQtimePPSERel4Update(dbContext, qtimeppserel.Productrulesysid, qtimeppserel.Siteid);
			if (qtimePPSERel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Qtimeppserel), $"{qtimeppserel.Productrulesysid},{qtimeppserel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Qtimeppserel), $"{qtimeppserel.Productrulesysid},{qtimeppserel.Siteid}", qtimePPSERel4Update.Isusable);
			qtimePPSERel4Update.Isusable = "Usable";
			qtimeppserel.CopyCommonFieldUpdatePrev(qtimePPSERel4Update, systemTime, dbContext.Tid, text);
			qtimeppserel.CopyExtensionCollection(qtimePPSERel4Update);
			list.Add(qtimePPSERel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteQtimePPSERel(IDbContext dbContext, Qtimeppserel[] qtimePPSERelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("qtimePPSERelList", qtimePPSERelList);
		string text = "RealDeleteQtimePPSERel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Qtimeppserel> list = new List<Qtimeppserel>();
		foreach (Qtimeppserel qtimeppserel in qtimePPSERelList)
		{
			Qtimeppserel qtimePPSERel4Update = GetQtimePPSERel4Update(dbContext, qtimeppserel.Productrulesysid, qtimeppserel.Siteid);
			if (qtimePPSERel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Qtimeppserel), $"{qtimeppserel.Productrulesysid},{qtimeppserel.Siteid}");
			}
			qtimeppserel.CopyCommonFieldUpdatePrev(qtimePPSERel4Update, systemTime, dbContext.Tid, text);
			qtimeppserel.CopyExtensionCollection(qtimePPSERel4Update);
			list.Add(qtimePPSERel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
