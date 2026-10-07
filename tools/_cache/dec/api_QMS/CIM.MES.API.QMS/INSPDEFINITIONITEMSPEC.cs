using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.QMS;

[MESAPI]
public class INSPDEFINITIONITEMSPEC
{
	private static string _sqlGetInspDefinitionItemSpecSqlDatabase = "SELECT * FROM CIM_INSPDEFINITIONITEMSPEC WHERE INSPDEFINITIONITEMSPECSYSID=@INSPDEFINITIONITEMSPECSYSID AND SITEID=@SITEID";

	private static string _sqlGetInspDefinitionItemSpec4UpdateSqlDatabase = "SELECT * FROM CIM_INSPDEFINITIONITEMSPEC WITH(UPDLOCK) WHERE INSPDEFINITIONITEMSPECSYSID=@INSPDEFINITIONITEMSPECSYSID AND SITEID=@SITEID";

	private static string _sqlSelectInspDefinitionItemSpecSqlDatabase = "SELECT * FROM CIM_INSPDEFINITIONITEMSPEC WHERE INSPDEFINITIONITEMSPECSYSID=@INSPDEFINITIONITEMSPECSYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectInspDefinitionItemSpec4UpdateSqlDatabase = "SELECT * FROM CIM_INSPDEFINITIONITEMSPEC WITH(UPDLOCK) WHERE INSPDEFINITIONITEMSPECSYSID=@INSPDEFINITIONITEMSPECSYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetInspDefinitionItemSpecOracleDatabase = "SELECT * FROM CIM_INSPDEFINITIONITEMSPEC WHERE INSPDEFINITIONITEMSPECSYSID=:INSPDEFINITIONITEMSPECSYSID AND SITEID=:SITEID";

	private static string _sqlGetInspDefinitionItemSpec4UpdateOracleDatabase = "SELECT * FROM CIM_INSPDEFINITIONITEMSPEC WHERE INSPDEFINITIONITEMSPECSYSID=:INSPDEFINITIONITEMSPECSYSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectInspDefinitionItemSpecOracleDatabase = "SELECT * FROM CIM_INSPDEFINITIONITEMSPEC WHERE INSPDEFINITIONITEMSPECSYSID=:INSPDEFINITIONITEMSPECSYSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectInspDefinitionItemSpec4UpdateOracleDatabase = "SELECT * FROM CIM_INSPDEFINITIONITEMSPEC WHERE INSPDEFINITIONITEMSPECSYSID=:INSPDEFINITIONITEMSPECSYSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Inspdefinitionitemspec);

	private static string _sqlSelectInspDefinitionItemSpecListSqlDatabase = "SELECT * FROM CIM_INSPDEFINITIONITEMSPEC WHERE INSPTYPE=@INSPTYPE AND ITEMID=@ITEMID AND REV=@REV AND COPERATOR=@COPERATOR AND INSPSPEC=@INSPSPEC AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectInspDefinitionItemSpecListOracleDatabase = "SELECT * FROM CIM_INSPDEFINITIONITEMSPEC WHERE INSPTYPE=:INSPTYPE AND ITEMID=:ITEMID AND REV=:REV AND COPERATOR=:COPERATOR AND INSPSPEC=:INSPSPEC AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectInspDefinitionItemSpecListByInspdefinitionsysidSqlDatabase = "SELECT * FROM CIM_INSPDEFINITIONITEMSPEC WHERE INSPDEFINITIONSYSID=@INSPDEFINITIONSYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectInspDefinitionItemSpecListByInspdefinitionsysidOracleDatabase = "SELECT * FROM CIM_INSPDEFINITIONITEMSPEC WHERE INSPDEFINITIONSYSID=:INSPDEFINITIONSYSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectInspDefinitionItemSpecListByInspreqSqlDatabase = "SELECT S.* FROM CIM_INSPREQ R INNER JOIN CIM_INSPDEFINITIONITEMSPEC S ON R.INSPDEFINITIONSYSID=S.INSPDEFINITIONSYSID AND R.SITEID=S.SITEID WHERE R.INSPREQNO=@INSPREQNO AND R.REPEATCOUNT=@REPEATCOUNT AND R.SITEID=@SITEID AND R.ISUSABLE='Usable'";

	private static string _sqlSelectInspDefinitionItemSpecListByInspreqOracleDatabase = "SELECT S.* FROM CIM_INSPREQ R INNER JOIN CIM_INSPDEFINITIONITEMSPEC S ON R.INSPDEFINITIONSYSID=S.INSPDEFINITIONSYSID AND R.SITEID=S.SITEID WHERE R.INSPREQNO=:INSPREQNO AND R.REPEATCOUNT=:REPEATCOUNT AND R.SITEID=:SITEID AND R.ISUSABLE='Usable'";

	public static Inspdefinitionitemspec GetInspDefinitionItemSpec(IDbContext dbContext, string inspdefinitionitemspecsysid, string siteid)
	{
		string apiName = "GetInspDefinitionItemSpec";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspdefinitionitemspecsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetInspDefinitionItemSpecSqlDatabase : _sqlGetInspDefinitionItemSpecOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPDEFINITIONITEMSPECSYSID", inspdefinitionitemspecsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_INSPDEFINITIONITEMSPEC", $"{inspdefinitionitemspecsysid},{siteid}"));
		}
		Inspdefinitionitemspec? result = ContextManager.DirectEntityQuery<Inspdefinitionitemspec>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspdefinitionitemspecsysid},{siteid}");
		}
		return result;
	}

	public static Inspdefinitionitemspec GetInspDefinitionItemSpec4Update(IDbContext dbContext, string inspdefinitionitemspecsysid, string siteid)
	{
		string apiName = "GetInspDefinitionItemSpec4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspdefinitionitemspecsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetInspDefinitionItemSpec4UpdateSqlDatabase : _sqlGetInspDefinitionItemSpec4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPDEFINITIONITEMSPECSYSID", inspdefinitionitemspecsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_INSPDEFINITIONITEMSPEC", $"{inspdefinitionitemspecsysid},{siteid}"));
		}
		Inspdefinitionitemspec? result = ContextManager.DirectEntityQuery<Inspdefinitionitemspec>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspdefinitionitemspecsysid},{siteid}");
		}
		return result;
	}

	public static Inspdefinitionitemspec SelectInspDefinitionItemSpec(IDbContext dbContext, string inspdefinitionitemspecsysid, string siteid)
	{
		string apiName = "SelectInspDefinitionItemSpec";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspdefinitionitemspecsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectInspDefinitionItemSpecSqlDatabase : _sqlSelectInspDefinitionItemSpecOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPDEFINITIONITEMSPECSYSID", inspdefinitionitemspecsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_INSPDEFINITIONITEMSPEC", $"{inspdefinitionitemspecsysid},{siteid}"));
		}
		Inspdefinitionitemspec? result = ContextManager.DirectEntityQuery<Inspdefinitionitemspec>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspdefinitionitemspecsysid},{siteid}");
		}
		return result;
	}

	public static Inspdefinitionitemspec SelectInspDefinitionItemSpec4Update(IDbContext dbContext, string inspdefinitionitemspecsysid, string siteid)
	{
		string apiName = "SelectInspDefinitionItemSpec4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspdefinitionitemspecsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectInspDefinitionItemSpec4UpdateSqlDatabase : _sqlSelectInspDefinitionItemSpec4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPDEFINITIONITEMSPECSYSID", inspdefinitionitemspecsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_INSPDEFINITIONITEMSPEC", $"{inspdefinitionitemspecsysid},{siteid}"));
		}
		Inspdefinitionitemspec? result = ContextManager.DirectEntityQuery<Inspdefinitionitemspec>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspdefinitionitemspecsysid},{siteid}");
		}
		return result;
	}

	public static IList<Inspdefinitionitemspec> SelectInspDefinitionItemSpecList(IDbContext dbContext, string inspType, string itemId, string rev, string coperator, string inspSpec, string siteid)
	{
		string apiName = "SelectInspDefinitionItemSpecList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspType},{itemId},{rev},{coperator},{inspSpec},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectInspDefinitionItemSpecListSqlDatabase : _sqlSelectInspDefinitionItemSpecListOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPTYPE", inspType, typeOfThis));
		list.Add(dbContext.CreateParameter("ITEMID", itemId, typeOfThis));
		list.Add(dbContext.CreateParameter("REV", rev, typeOfThis));
		list.Add(dbContext.CreateParameter("COPERATOR", coperator, typeOfThis));
		list.Add(dbContext.CreateParameter("INSPSPEC", inspSpec, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_INSPDEFINITIONITEMSPEC", $"{inspType},{itemId},{rev},{coperator},{inspSpec},{siteid}"));
		}
		IList<Inspdefinitionitemspec> result = ContextManager.DirectEntityQuery<Inspdefinitionitemspec>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspType},{itemId},{rev},{coperator},{inspSpec},{siteid}");
		}
		return result;
	}

	public static IList<Inspdefinitionitemspec> SelectInspDefinitionItemSpecListByInspdefinitionsysid(IDbContext dbContext, string inspdefinitionsysid, string siteid)
	{
		string apiName = "SelectInspDefinitionItemSpecListByInspdefinitionsysid";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspdefinitionsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectInspDefinitionItemSpecListByInspdefinitionsysidSqlDatabase : _sqlSelectInspDefinitionItemSpecListByInspdefinitionsysidOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPDEFINITIONSYSID", inspdefinitionsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_INSPDEFINITIONITEMSPEC", $"{inspdefinitionsysid},{siteid}"));
		}
		IList<Inspdefinitionitemspec> result = ContextManager.DirectEntityQuery<Inspdefinitionitemspec>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspdefinitionsysid},{siteid}");
		}
		return result;
	}

	public static IList<Inspdefinitionitemspec> SelectInspDefinitionItemSpecListByInspreq(IDbContext dbContext, string inspreqno, int repeatcount, string siteid)
	{
		string apiName = "SelectInspDefinitionItemSpecListByInspreq";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspreqno},{repeatcount},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectInspDefinitionItemSpecListByInspreqSqlDatabase : _sqlSelectInspDefinitionItemSpecListByInspreqOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPREQNO", inspreqno, typeOfThis));
		list.Add(dbContext.CreateParameter("REPEATCOUNT", repeatcount, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_INSPDEFINITIONITEMSPEC", $"{inspreqno},{repeatcount},{siteid}"));
		}
		IList<Inspdefinitionitemspec> result = ContextManager.DirectEntityQuery<Inspdefinitionitemspec>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspreqno},{repeatcount},{siteid}");
		}
		return result;
	}

	public static int UpsertInspDefinitionItemSpec(IDbContext dbContext, RequestType requestType, Inspdefinitionitemspec[] inspDefinitionItemSpecList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateInspDefinitionItemSpecInternal(dbContext, inspDefinitionItemSpecList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateInspDefinitionItemSpec(dbContext, inspDefinitionItemSpecList, optionSet, saveHist), 
			RequestType.DELETE => DeleteInspDefinitionItemSpec(dbContext, inspDefinitionItemSpecList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteInspDefinitionItemSpec(dbContext, inspDefinitionItemSpecList, optionSet, saveHist), 
			_ => RealDeleteInspDefinitionItemSpec(dbContext, inspDefinitionItemSpecList, optionSet, saveHist), 
		};
	}

	private static int CreateInspDefinitionItemSpecInternal(IDbContext dbContext, Inspdefinitionitemspec[] inspDefinitionItemSpecList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspDefinitionItemSpecList", inspDefinitionItemSpecList);
		string text = "CreateInspDefinitionItemSpec";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspdefinitionitemspec> list = new List<Inspdefinitionitemspec>();
		foreach (Inspdefinitionitemspec obj in inspDefinitionItemSpecList)
		{
			Inspdefinitionitemspec inspdefinitionitemspec = new Inspdefinitionitemspec();
			obj.CopyColumsTo(inspdefinitionitemspec);
			inspdefinitionitemspec.Activity = text;
			inspdefinitionitemspec.CheckEntityUsable();
			obj.CopyCommonField(inspdefinitionitemspec, systemTime, dbContext.Tid, isCreate: true);
			list.Add(inspdefinitionitemspec);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateInspDefinitionItemSpec(IDbContext dbContext, Inspdefinitionitemspec[] inspDefinitionItemSpecList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspDefinitionItemSpecList", inspDefinitionItemSpecList);
		string text = "UpdateInspDefinitionItemSpec";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspdefinitionitemspec> list = new List<Inspdefinitionitemspec>();
		foreach (Inspdefinitionitemspec inspdefinitionitemspec in inspDefinitionItemSpecList)
		{
			Inspdefinitionitemspec inspDefinitionItemSpec4Update = GetInspDefinitionItemSpec4Update(dbContext, inspdefinitionitemspec.Inspdefinitionitemspecsysid, inspdefinitionitemspec.Siteid);
			if (inspDefinitionItemSpec4Update == null)
			{
				throw new EntityNotFoundException(typeof(Inspdefinitionitemspec), $"{inspdefinitionitemspec.Inspdefinitionitemspecsysid},{inspdefinitionitemspec.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Inspdefinitionitemspec), $"{inspdefinitionitemspec.Inspdefinitionitemspecsysid},{inspdefinitionitemspec.Siteid}", inspDefinitionItemSpec4Update.Isusable);
			string activity = inspDefinitionItemSpec4Update.Activity;
			string customactivity = inspDefinitionItemSpec4Update.Customactivity;
			string isusable = inspDefinitionItemSpec4Update.Isusable;
			DateTime? createtime = inspDefinitionItemSpec4Update.Createtime;
			string creator = inspDefinitionItemSpec4Update.Creator;
			inspdefinitionitemspec.CopyColumsTo(inspDefinitionItemSpec4Update);
			inspDefinitionItemSpec4Update.Prevactivity = activity;
			inspDefinitionItemSpec4Update.Prevcustomactivity = customactivity;
			inspDefinitionItemSpec4Update.Creator = creator;
			inspDefinitionItemSpec4Update.Createtime = createtime;
			inspDefinitionItemSpec4Update.Isusable = isusable;
			inspDefinitionItemSpec4Update.Activity = text;
			inspdefinitionitemspec.CopyCommonField(inspDefinitionItemSpec4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(inspDefinitionItemSpec4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteInspDefinitionItemSpec(IDbContext dbContext, Inspdefinitionitemspec[] inspDefinitionItemSpecList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspDefinitionItemSpecList", inspDefinitionItemSpecList);
		string text = "DeleteInspDefinitionItemSpec";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspdefinitionitemspec> list = new List<Inspdefinitionitemspec>();
		foreach (Inspdefinitionitemspec inspdefinitionitemspec in inspDefinitionItemSpecList)
		{
			Inspdefinitionitemspec inspDefinitionItemSpec4Update = GetInspDefinitionItemSpec4Update(dbContext, inspdefinitionitemspec.Inspdefinitionitemspecsysid, inspdefinitionitemspec.Siteid);
			if (inspDefinitionItemSpec4Update == null)
			{
				throw new EntityNotFoundException(typeof(Inspdefinitionitemspec), $"{inspdefinitionitemspec.Inspdefinitionitemspecsysid},{inspdefinitionitemspec.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Inspdefinitionitemspec), $"{inspdefinitionitemspec.Inspdefinitionitemspecsysid},{inspdefinitionitemspec.Siteid}", inspDefinitionItemSpec4Update.Isusable);
			inspDefinitionItemSpec4Update.Isusable = "UnUsable";
			inspdefinitionitemspec.CopyCommonFieldUpdatePrev(inspDefinitionItemSpec4Update, systemTime, dbContext.Tid, text);
			inspdefinitionitemspec.CopyExtensionCollection(inspDefinitionItemSpec4Update);
			list.Add(inspDefinitionItemSpec4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteInspDefinitionItemSpec(IDbContext dbContext, Inspdefinitionitemspec[] inspDefinitionItemSpecList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspDefinitionItemSpecList", inspDefinitionItemSpecList);
		string text = "UnDeleteInspDefinitionItemSpec";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspdefinitionitemspec> list = new List<Inspdefinitionitemspec>();
		foreach (Inspdefinitionitemspec inspdefinitionitemspec in inspDefinitionItemSpecList)
		{
			Inspdefinitionitemspec inspDefinitionItemSpec4Update = GetInspDefinitionItemSpec4Update(dbContext, inspdefinitionitemspec.Inspdefinitionitemspecsysid, inspdefinitionitemspec.Siteid);
			if (inspDefinitionItemSpec4Update == null)
			{
				throw new EntityNotFoundException(typeof(Inspdefinitionitemspec), $"{inspdefinitionitemspec.Inspdefinitionitemspecsysid},{inspdefinitionitemspec.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Inspdefinitionitemspec), $"{inspdefinitionitemspec.Inspdefinitionitemspecsysid},{inspdefinitionitemspec.Siteid}", inspDefinitionItemSpec4Update.Isusable);
			inspDefinitionItemSpec4Update.Isusable = "Usable";
			inspdefinitionitemspec.CopyCommonFieldUpdatePrev(inspDefinitionItemSpec4Update, systemTime, dbContext.Tid, text);
			inspdefinitionitemspec.CopyExtensionCollection(inspDefinitionItemSpec4Update);
			list.Add(inspDefinitionItemSpec4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteInspDefinitionItemSpec(IDbContext dbContext, Inspdefinitionitemspec[] inspDefinitionItemSpecList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspDefinitionItemSpecList", inspDefinitionItemSpecList);
		string text = "RealDeleteInspDefinitionItemSpec";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspdefinitionitemspec> list = new List<Inspdefinitionitemspec>();
		foreach (Inspdefinitionitemspec inspdefinitionitemspec in inspDefinitionItemSpecList)
		{
			Inspdefinitionitemspec inspDefinitionItemSpec4Update = GetInspDefinitionItemSpec4Update(dbContext, inspdefinitionitemspec.Inspdefinitionitemspecsysid, inspdefinitionitemspec.Siteid);
			if (inspDefinitionItemSpec4Update == null)
			{
				throw new EntityNotFoundException(typeof(Inspdefinitionitemspec), $"{inspdefinitionitemspec.Inspdefinitionitemspecsysid},{inspdefinitionitemspec.Siteid}");
			}
			inspdefinitionitemspec.CopyCommonFieldUpdatePrev(inspDefinitionItemSpec4Update, systemTime, dbContext.Tid, text);
			inspdefinitionitemspec.CopyExtensionCollection(inspDefinitionItemSpec4Update);
			list.Add(inspDefinitionItemSpec4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
