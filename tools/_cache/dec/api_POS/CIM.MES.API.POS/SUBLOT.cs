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
public class SUBLOT
{
	private static string _sqlGetSubLotSqlDatabase = "SELECT * FROM CIM_SUBLOT WHERE SUBLOTID=@SUBLOTID AND SITEID=@SITEID";

	private static string _sqlGetSubLot4UpdateSqlDatabase = "SELECT * FROM CIM_SUBLOT WITH(UPDLOCK) WHERE SUBLOTID=@SUBLOTID AND SITEID=@SITEID";

	private static string _sqlSelectSubLotSqlDatabase = "SELECT * FROM CIM_SUBLOT WHERE SUBLOTID=@SUBLOTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectSubLot4UpdateSqlDatabase = "SELECT * FROM CIM_SUBLOT WITH(UPDLOCK) WHERE SUBLOTID=@SUBLOTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetSubLotOracleDatabase = "SELECT * FROM CIM_SUBLOT WHERE SUBLOTID=:SUBLOTID AND SITEID=:SITEID";

	private static string _sqlGetSubLot4UpdateOracleDatabase = "SELECT * FROM CIM_SUBLOT WHERE SUBLOTID=:SUBLOTID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectSubLotOracleDatabase = "SELECT * FROM CIM_SUBLOT WHERE SUBLOTID=:SUBLOTID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectSubLot4UpdateOracleDatabase = "SELECT * FROM CIM_SUBLOT WHERE SUBLOTID=:SUBLOTID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Sublot);

	public static Sublot GetSubLot(IDbContext dbContext, string sublotid, string siteid)
	{
		string apiName = "GetSubLot";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{sublotid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetSubLotSqlDatabase : _sqlGetSubLotOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SUBLOTID", sublotid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SUBLOT", $"{sublotid},{siteid}"));
		}
		Sublot? result = ContextManager.DirectEntityQuery<Sublot>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{sublotid},{siteid}");
		}
		return result;
	}

	public static Sublot GetSubLot4Update(IDbContext dbContext, string sublotid, string siteid)
	{
		string apiName = "GetSubLot4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{sublotid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetSubLot4UpdateSqlDatabase : _sqlGetSubLot4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SUBLOTID", sublotid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_SUBLOT", $"{sublotid},{siteid}"));
		}
		Sublot? result = ContextManager.DirectEntityQuery<Sublot>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{sublotid},{siteid}");
		}
		return result;
	}

	public static Sublot SelectSubLot(IDbContext dbContext, string sublotid, string siteid)
	{
		string apiName = "SelectSubLot";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{sublotid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectSubLotSqlDatabase : _sqlSelectSubLotOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SUBLOTID", sublotid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_SUBLOT", $"{sublotid},{siteid}"));
		}
		Sublot? result = ContextManager.DirectEntityQuery<Sublot>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{sublotid},{siteid}");
		}
		return result;
	}

	public static Sublot SelectSubLot4Update(IDbContext dbContext, string sublotid, string siteid)
	{
		string apiName = "SelectSubLot4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{sublotid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectSubLot4UpdateSqlDatabase : _sqlSelectSubLot4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SUBLOTID", sublotid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_SUBLOT", $"{sublotid},{siteid}"));
		}
		Sublot? result = ContextManager.DirectEntityQuery<Sublot>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{sublotid},{siteid}");
		}
		return result;
	}

	public static int UpsertSubLot(IDbContext dbContext, RequestType requestType, Sublot[] subLotList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateSubLotInternal(dbContext, subLotList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateSubLot(dbContext, subLotList, optionSet, saveHist), 
			RequestType.DELETE => DeleteSubLot(dbContext, subLotList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteSubLot(dbContext, subLotList, optionSet, saveHist), 
			_ => RealDeleteSubLot(dbContext, subLotList, optionSet, saveHist), 
		};
	}

	private static int CreateSubLotInternal(IDbContext dbContext, Sublot[] subLotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("subLotList", subLotList);
		string text = "CreateSubLot";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Sublot> list = new List<Sublot>();
		foreach (Sublot obj in subLotList)
		{
			Sublot sublot = new Sublot();
			obj.CopyColumsTo(sublot);
			sublot.Activity = text;
			sublot.CheckEntityUsable();
			obj.CopyCommonField(sublot, systemTime, dbContext.Tid, isCreate: true);
			list.Add(sublot);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateSubLot(IDbContext dbContext, Sublot[] subLotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("subLotList", subLotList);
		string text = "UpdateSubLot";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Sublot> list = new List<Sublot>();
		foreach (Sublot sublot in subLotList)
		{
			Sublot subLot4Update = GetSubLot4Update(dbContext, sublot.Sublotid, sublot.Siteid);
			if (subLot4Update == null)
			{
				throw new EntityNotFoundException(typeof(Sublot), $"{sublot.Sublotid},{sublot.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Sublot), $"{sublot.Sublotid},{sublot.Siteid}", subLot4Update.Isusable);
			string activity = subLot4Update.Activity;
			string customactivity = subLot4Update.Customactivity;
			string isusable = subLot4Update.Isusable;
			DateTime? createtime = subLot4Update.Createtime;
			string creator = subLot4Update.Creator;
			sublot.CopyColumsTo(subLot4Update);
			subLot4Update.Prevactivity = activity;
			subLot4Update.Prevcustomactivity = customactivity;
			subLot4Update.Creator = creator;
			subLot4Update.Createtime = createtime;
			subLot4Update.Isusable = isusable;
			subLot4Update.Activity = text;
			sublot.CopyCommonField(subLot4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(subLot4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteSubLot(IDbContext dbContext, Sublot[] subLotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("subLotList", subLotList);
		string text = "DeleteSubLot";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Sublot> list = new List<Sublot>();
		foreach (Sublot sublot in subLotList)
		{
			Sublot subLot4Update = GetSubLot4Update(dbContext, sublot.Sublotid, sublot.Siteid);
			if (subLot4Update == null)
			{
				throw new EntityNotFoundException(typeof(Sublot), $"{sublot.Sublotid},{sublot.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Sublot), $"{sublot.Sublotid},{sublot.Siteid}", subLot4Update.Isusable);
			subLot4Update.Isusable = "UnUsable";
			sublot.CopyCommonFieldUpdatePrev(subLot4Update, systemTime, dbContext.Tid, text);
			sublot.CopyExtensionCollection(subLot4Update);
			list.Add(subLot4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteSubLot(IDbContext dbContext, Sublot[] subLotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("subLotList", subLotList);
		string text = "UnDeleteSubLot";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Sublot> list = new List<Sublot>();
		foreach (Sublot sublot in subLotList)
		{
			Sublot subLot4Update = GetSubLot4Update(dbContext, sublot.Sublotid, sublot.Siteid);
			if (subLot4Update == null)
			{
				throw new EntityNotFoundException(typeof(Sublot), $"{sublot.Sublotid},{sublot.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Sublot), $"{sublot.Sublotid},{sublot.Siteid}", subLot4Update.Isusable);
			subLot4Update.Isusable = "Usable";
			sublot.CopyCommonFieldUpdatePrev(subLot4Update, systemTime, dbContext.Tid, text);
			sublot.CopyExtensionCollection(subLot4Update);
			list.Add(subLot4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteSubLot(IDbContext dbContext, Sublot[] subLotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("subLotList", subLotList);
		string text = "RealDeleteSubLot";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Sublot> list = new List<Sublot>();
		foreach (Sublot sublot in subLotList)
		{
			Sublot subLot4Update = GetSubLot4Update(dbContext, sublot.Sublotid, sublot.Siteid);
			if (subLot4Update == null)
			{
				throw new EntityNotFoundException(typeof(Sublot), $"{sublot.Sublotid},{sublot.Siteid}");
			}
			sublot.CopyCommonFieldUpdatePrev(subLot4Update, systemTime, dbContext.Tid, text);
			sublot.CopyExtensionCollection(subLot4Update);
			list.Add(subLot4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
