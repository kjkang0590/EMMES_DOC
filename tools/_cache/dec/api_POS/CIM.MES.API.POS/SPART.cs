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
public class SPART
{
	private static string _sqlGetSpartSqlDatabase = "SELECT * FROM CIM_SPART WHERE SPARTID=@SPARTID AND SITEID=@SITEID";

	private static string _sqlGetSpart4UpdateSqlDatabase = "SELECT * FROM CIM_SPART WITH(UPDLOCK) WHERE SPARTID=@SPARTID AND SITEID=@SITEID";

	private static string _sqlSelectSpartSqlDatabase = "SELECT * FROM CIM_SPART WHERE SPARTID=@SPARTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectSpart4UpdateSqlDatabase = "SELECT * FROM CIM_SPART WITH(UPDLOCK) WHERE SPARTID=@SPARTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetSpartOracleDatabase = "SELECT * FROM CIM_SPART WHERE SPARTID=:SPARTID AND SITEID=:SITEID";

	private static string _sqlGetSpart4UpdateOracleDatabase = "SELECT * FROM CIM_SPART WHERE SPARTID=:SPARTID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectSpartOracleDatabase = "SELECT * FROM CIM_SPART WHERE SPARTID=:SPARTID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectSpart4UpdateOracleDatabase = "SELECT * FROM CIM_SPART WHERE SPARTID=:SPARTID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Spart);

	public static int CompareSpartUsageCount(IDbContext dbContext, Spart[] spartList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spartList", spartList);
		string text = "CompareSpartUsageCount";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		int num = 0;
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		List<Spart> list = new List<Spart>();
		foreach (Spart spart in spartList)
		{
			ParamChecker.ArgumentNotNull("Spartid", spart.Spartid);
			ParamChecker.ArgumentNotNull("Siteid", spart.Siteid);
			string siteid = spart.Siteid;
			Spart spart2 = SelectSpart4Update(dbContext, spart.Spartid, siteid);
			if (spart2 == null)
			{
				throw new EntityNotFoundException(typeof(Spart), spart.Spartid);
			}
			if (spart2.Usagecount == spart2.Usagelimit)
			{
				spart2.Usagecount = 0;
				spart2.Prevstate = spart2.State;
				spart2.State = "Terminated";
			}
			spart.CopyCommonFieldUpdatePrev(spart2, systemTime, tid, text);
			spart.CopyExtensionCollection(spart2);
			list.Add(spart2);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static Spart GetSpart(IDbContext dbContext, string spartid, string siteid)
	{
		string apiName = "GetSpart";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{spartid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetSpartSqlDatabase : _sqlGetSpartOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SPARTID", spartid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SPART", $"{spartid},{siteid}"));
		}
		Spart? result = ContextManager.DirectEntityQuery<Spart>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{spartid},{siteid}");
		}
		return result;
	}

	public static Spart GetSpart4Update(IDbContext dbContext, string spartid, string siteid)
	{
		string apiName = "GetSpart4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{spartid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetSpart4UpdateSqlDatabase : _sqlGetSpart4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SPARTID", spartid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_SPART", $"{spartid},{siteid}"));
		}
		Spart? result = ContextManager.DirectEntityQuery<Spart>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{spartid},{siteid}");
		}
		return result;
	}

	public static Spart SelectSpart(IDbContext dbContext, string spartid, string siteid)
	{
		string apiName = "SelectSpart";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{spartid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectSpartSqlDatabase : _sqlSelectSpartOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SPARTID", spartid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SPART", $"{spartid},{siteid}"));
		}
		Spart? result = ContextManager.DirectEntityQuery<Spart>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{spartid},{siteid}");
		}
		return result;
	}

	public static Spart SelectSpart4Update(IDbContext dbContext, string spartid, string siteid)
	{
		string apiName = "SelectSpart4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{spartid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectSpart4UpdateSqlDatabase : _sqlSelectSpart4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SPARTID", spartid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_SPART", $"{spartid},{siteid}"));
		}
		Spart? result = ContextManager.DirectEntityQuery<Spart>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{spartid},{siteid}");
		}
		return result;
	}

	public static int UpsertSpart(IDbContext dbContext, RequestType requestType, Spart[] spartList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateSpartInternal(dbContext, spartList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateSpart(dbContext, spartList, optionSet, saveHist), 
			RequestType.DELETE => DeleteSpart(dbContext, spartList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteSpart(dbContext, spartList, optionSet, saveHist), 
			_ => RealDeleteSpart(dbContext, spartList, optionSet, saveHist), 
		};
	}

	private static int CreateSpartInternal(IDbContext dbContext, Spart[] spartList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spartList", spartList);
		string text = "CreateSpart";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spart> list = new List<Spart>();
		foreach (Spart obj in spartList)
		{
			Spart spart = new Spart();
			obj.CopyColumsTo(spart);
			spart.Activity = text;
			spart.CheckEntityUsable();
			obj.CopyCommonField(spart, systemTime, dbContext.Tid, isCreate: true);
			list.Add(spart);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateSpart(IDbContext dbContext, Spart[] spartList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spartList", spartList);
		string text = "UpdateSpart";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spart> list = new List<Spart>();
		foreach (Spart spart in spartList)
		{
			Spart spart4Update = GetSpart4Update(dbContext, spart.Spartid, spart.Siteid);
			if (spart4Update == null)
			{
				throw new EntityNotFoundException(typeof(Spart), $"{spart.Spartid},{spart.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Spart), $"{spart.Spartid},{spart.Siteid}", spart4Update.Isusable);
			string activity = spart4Update.Activity;
			string customactivity = spart4Update.Customactivity;
			string isusable = spart4Update.Isusable;
			DateTime? createtime = spart4Update.Createtime;
			string creator = spart4Update.Creator;
			spart.CopyColumsTo(spart4Update);
			spart4Update.Prevactivity = activity;
			spart4Update.Prevcustomactivity = customactivity;
			spart4Update.Creator = creator;
			spart4Update.Createtime = createtime;
			spart4Update.Isusable = isusable;
			spart4Update.Activity = text;
			spart.CopyCommonField(spart4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(spart4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteSpart(IDbContext dbContext, Spart[] spartList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spartList", spartList);
		string text = "DeleteSpart";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spart> list = new List<Spart>();
		foreach (Spart spart in spartList)
		{
			Spart spart4Update = GetSpart4Update(dbContext, spart.Spartid, spart.Siteid);
			if (spart4Update == null)
			{
				throw new EntityNotFoundException(typeof(Spart), $"{spart.Spartid},{spart.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Spart), $"{spart.Spartid},{spart.Siteid}", spart4Update.Isusable);
			spart4Update.Isusable = "UnUsable";
			spart.CopyCommonFieldUpdatePrev(spart4Update, systemTime, dbContext.Tid, text);
			spart.CopyExtensionCollection(spart4Update);
			list.Add(spart4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteSpart(IDbContext dbContext, Spart[] spartList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spartList", spartList);
		string text = "UnDeleteSpart";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spart> list = new List<Spart>();
		foreach (Spart spart in spartList)
		{
			Spart spart4Update = GetSpart4Update(dbContext, spart.Spartid, spart.Siteid);
			if (spart4Update == null)
			{
				throw new EntityNotFoundException(typeof(Spart), $"{spart.Spartid},{spart.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Spart), $"{spart.Spartid},{spart.Siteid}", spart4Update.Isusable);
			spart4Update.Isusable = "Usable";
			spart.CopyCommonFieldUpdatePrev(spart4Update, systemTime, dbContext.Tid, text);
			spart.CopyExtensionCollection(spart4Update);
			list.Add(spart4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteSpart(IDbContext dbContext, Spart[] spartList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("spartList", spartList);
		string text = "RealDeleteSpart";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Spart> list = new List<Spart>();
		foreach (Spart spart in spartList)
		{
			Spart spart4Update = GetSpart4Update(dbContext, spart.Spartid, spart.Siteid);
			if (spart4Update == null)
			{
				throw new EntityNotFoundException(typeof(Spart), $"{spart.Spartid},{spart.Siteid}");
			}
			spart.CopyCommonFieldUpdatePrev(spart4Update, systemTime, dbContext.Tid, text);
			spart.CopyExtensionCollection(spart4Update);
			list.Add(spart4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
