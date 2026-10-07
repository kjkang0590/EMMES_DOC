using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.PMS;

[MESAPI]
public class PROCESSSEGMENTEQUIPMENTREL
{
	private static string _sqlGetProcessSegmentEquipmentRelSqlDatabase = "SELECT * FROM CIM_PROCESSSEGMENTEQUIPMENTREL WHERE PROCESSSEGMENTID=@PROCESSSEGMENTID AND EQUIPMENTID=@EQUIPMENTID AND SITEID=@SITEID";

	private static string _sqlGetProcessSegmentEquipmentRel4UpdateSqlDatabase = "SELECT * FROM CIM_PROCESSSEGMENTEQUIPMENTREL WITH(UPDLOCK) WHERE PROCESSSEGMENTID=@PROCESSSEGMENTID AND EQUIPMENTID=@EQUIPMENTID AND SITEID=@SITEID";

	private static string _sqlSelectProcessSegmentEquipmentRelSqlDatabase = "SELECT * FROM CIM_PROCESSSEGMENTEQUIPMENTREL WHERE PROCESSSEGMENTID=@PROCESSSEGMENTID AND EQUIPMENTID=@EQUIPMENTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessSegmentEquipmentRel4UpdateSqlDatabase = "SELECT * FROM CIM_PROCESSSEGMENTEQUIPMENTREL WITH(UPDLOCK) WHERE PROCESSSEGMENTID=@PROCESSSEGMENTID AND EQUIPMENTID=@EQUIPMENTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetProcessSegmentEquipmentRelOracleDatabase = "SELECT * FROM CIM_PROCESSSEGMENTEQUIPMENTREL WHERE PROCESSSEGMENTID=:PROCESSSEGMENTID AND EQUIPMENTID=:EQUIPMENTID AND SITEID=:SITEID";

	private static string _sqlGetProcessSegmentEquipmentRel4UpdateOracleDatabase = "SELECT * FROM CIM_PROCESSSEGMENTEQUIPMENTREL WHERE PROCESSSEGMENTID=:PROCESSSEGMENTID AND EQUIPMENTID=:EQUIPMENTID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectProcessSegmentEquipmentRelOracleDatabase = "SELECT * FROM CIM_PROCESSSEGMENTEQUIPMENTREL WHERE PROCESSSEGMENTID=:PROCESSSEGMENTID AND EQUIPMENTID=:EQUIPMENTID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessSegmentEquipmentRel4UpdateOracleDatabase = "SELECT * FROM CIM_PROCESSSEGMENTEQUIPMENTREL WHERE PROCESSSEGMENTID=:PROCESSSEGMENTID AND EQUIPMENTID=:EQUIPMENTID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Processsegmentequipmentrel);

	private static string _sqlSelectProcessSegmentEquipmentRelWithEquipmentSqlDatabase = "SELECT * FROM CIM_PROCESSSEGMENTEQUIPMENTREL WHERE EQUIPMENTID=@EQUIPMENTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessSegmentEquipmentRelWithEquipmentOracleDatabase = "SELECT * FROM CIM_PROCESSSEGMENTEQUIPMENTREL WHERE EQUIPMENTID=:EQUIPMENTID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessSegmentEquipmentRelWithProcesssegmentSqlDatabase = "SELECT * FROM CIM_PROCESSSEGMENTEQUIPMENTREL WHERE PROCESSSEGMENTID=@PROCESSSEGMENTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessSegmentEquipmentRelWithProcesssegmentOracleDatabase = "SELECT * FROM CIM_PROCESSSEGMENTEQUIPMENTREL WHERE PROCESSSEGMENTID=:PROCESSSEGMENTID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	public static Processsegmentequipmentrel GetProcessSegmentEquipmentRel(IDbContext dbContext, string processsegmentid, string equipmentid, string siteid)
	{
		string apiName = "GetProcessSegmentEquipmentRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processsegmentid},{equipmentid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProcessSegmentEquipmentRelSqlDatabase : _sqlGetProcessSegmentEquipmentRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PROCESSSEGMENTEQUIPMENTREL", $"{processsegmentid},{equipmentid},{siteid}"));
		}
		Processsegmentequipmentrel? result = ContextManager.DirectEntityQuery<Processsegmentequipmentrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processsegmentid},{equipmentid},{siteid}");
		}
		return result;
	}

	public static Processsegmentequipmentrel GetProcessSegmentEquipmentRel4Update(IDbContext dbContext, string processsegmentid, string equipmentid, string siteid)
	{
		string apiName = "GetProcessSegmentEquipmentRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processsegmentid},{equipmentid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProcessSegmentEquipmentRel4UpdateSqlDatabase : _sqlGetProcessSegmentEquipmentRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PROCESSSEGMENTEQUIPMENTREL", $"{processsegmentid},{equipmentid},{siteid}"));
		}
		Processsegmentequipmentrel? result = ContextManager.DirectEntityQuery<Processsegmentequipmentrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processsegmentid},{equipmentid},{siteid}");
		}
		return result;
	}

	public static Processsegmentequipmentrel SelectProcessSegmentEquipmentRel(IDbContext dbContext, string processsegmentid, string equipmentid, string siteid)
	{
		string apiName = "SelectProcessSegmentEquipmentRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processsegmentid},{equipmentid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessSegmentEquipmentRelSqlDatabase : _sqlSelectProcessSegmentEquipmentRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PROCESSSEGMENTEQUIPMENTREL", $"{processsegmentid},{equipmentid},{siteid}"));
		}
		Processsegmentequipmentrel? result = ContextManager.DirectEntityQuery<Processsegmentequipmentrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processsegmentid},{equipmentid},{siteid}");
		}
		return result;
	}

	public static Processsegmentequipmentrel SelectProcessSegmentEquipmentRel4Update(IDbContext dbContext, string processsegmentid, string equipmentid, string siteid)
	{
		string apiName = "SelectProcessSegmentEquipmentRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processsegmentid},{equipmentid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessSegmentEquipmentRel4UpdateSqlDatabase : _sqlSelectProcessSegmentEquipmentRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PROCESSSEGMENTEQUIPMENTREL", $"{processsegmentid},{equipmentid},{siteid}"));
		}
		Processsegmentequipmentrel? result = ContextManager.DirectEntityQuery<Processsegmentequipmentrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processsegmentid},{equipmentid},{siteid}");
		}
		return result;
	}

	public static int UpsertProcessSegmentEquipmentRel(IDbContext dbContext, RequestType requestType, Processsegmentequipmentrel[] processSegmentEquipmentRelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateProcessSegmentEquipmentRelInternal(dbContext, processSegmentEquipmentRelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateProcessSegmentEquipmentRel(dbContext, processSegmentEquipmentRelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteProcessSegmentEquipmentRel(dbContext, processSegmentEquipmentRelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteProcessSegmentEquipmentRel(dbContext, processSegmentEquipmentRelList, optionSet, saveHist), 
			_ => RealDeleteProcessSegmentEquipmentRel(dbContext, processSegmentEquipmentRelList, optionSet, saveHist), 
		};
	}

	private static int CreateProcessSegmentEquipmentRelInternal(IDbContext dbContext, Processsegmentequipmentrel[] processSegmentEquipmentRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processSegmentEquipmentRelList", processSegmentEquipmentRelList);
		string text = "CreateProcessSegmentEquipmentRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processsegmentequipmentrel> list = new List<Processsegmentequipmentrel>();
		foreach (Processsegmentequipmentrel obj in processSegmentEquipmentRelList)
		{
			Processsegmentequipmentrel processsegmentequipmentrel = new Processsegmentequipmentrel();
			obj.CopyColumsTo(processsegmentequipmentrel);
			processsegmentequipmentrel.Activity = text;
			processsegmentequipmentrel.CheckEntityUsable();
			obj.CopyCommonField(processsegmentequipmentrel, systemTime, dbContext.Tid, isCreate: true);
			list.Add(processsegmentequipmentrel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateProcessSegmentEquipmentRel(IDbContext dbContext, Processsegmentequipmentrel[] processSegmentEquipmentRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processSegmentEquipmentRelList", processSegmentEquipmentRelList);
		string text = "UpdateProcessSegmentEquipmentRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processsegmentequipmentrel> list = new List<Processsegmentequipmentrel>();
		foreach (Processsegmentequipmentrel processsegmentequipmentrel in processSegmentEquipmentRelList)
		{
			Processsegmentequipmentrel processSegmentEquipmentRel4Update = GetProcessSegmentEquipmentRel4Update(dbContext, processsegmentequipmentrel.Processsegmentid, processsegmentequipmentrel.Equipmentid, processsegmentequipmentrel.Siteid);
			if (processSegmentEquipmentRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentequipmentrel), $"{processsegmentequipmentrel.Processsegmentid},{processsegmentequipmentrel.Equipmentid},{processsegmentequipmentrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Processsegmentequipmentrel), $"{processsegmentequipmentrel.Processsegmentid},{processsegmentequipmentrel.Equipmentid},{processsegmentequipmentrel.Siteid}", processSegmentEquipmentRel4Update.Isusable);
			string activity = processSegmentEquipmentRel4Update.Activity;
			string customactivity = processSegmentEquipmentRel4Update.Customactivity;
			string isusable = processSegmentEquipmentRel4Update.Isusable;
			DateTime? createtime = processSegmentEquipmentRel4Update.Createtime;
			string creator = processSegmentEquipmentRel4Update.Creator;
			processsegmentequipmentrel.CopyColumsTo(processSegmentEquipmentRel4Update);
			processSegmentEquipmentRel4Update.Prevactivity = activity;
			processSegmentEquipmentRel4Update.Prevcustomactivity = customactivity;
			processSegmentEquipmentRel4Update.Creator = creator;
			processSegmentEquipmentRel4Update.Createtime = createtime;
			processSegmentEquipmentRel4Update.Isusable = isusable;
			processSegmentEquipmentRel4Update.Activity = text;
			processsegmentequipmentrel.CopyCommonField(processSegmentEquipmentRel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(processSegmentEquipmentRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteProcessSegmentEquipmentRel(IDbContext dbContext, Processsegmentequipmentrel[] processSegmentEquipmentRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processSegmentEquipmentRelList", processSegmentEquipmentRelList);
		string text = "DeleteProcessSegmentEquipmentRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processsegmentequipmentrel> list = new List<Processsegmentequipmentrel>();
		foreach (Processsegmentequipmentrel processsegmentequipmentrel in processSegmentEquipmentRelList)
		{
			Processsegmentequipmentrel processSegmentEquipmentRel4Update = GetProcessSegmentEquipmentRel4Update(dbContext, processsegmentequipmentrel.Processsegmentid, processsegmentequipmentrel.Equipmentid, processsegmentequipmentrel.Siteid);
			if (processSegmentEquipmentRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentequipmentrel), $"{processsegmentequipmentrel.Processsegmentid},{processsegmentequipmentrel.Equipmentid},{processsegmentequipmentrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Processsegmentequipmentrel), $"{processsegmentequipmentrel.Processsegmentid},{processsegmentequipmentrel.Equipmentid},{processsegmentequipmentrel.Siteid}", processSegmentEquipmentRel4Update.Isusable);
			processSegmentEquipmentRel4Update.Isusable = "UnUsable";
			processsegmentequipmentrel.CopyCommonFieldUpdatePrev(processSegmentEquipmentRel4Update, systemTime, dbContext.Tid, text);
			processsegmentequipmentrel.CopyExtensionCollection(processSegmentEquipmentRel4Update);
			list.Add(processSegmentEquipmentRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteProcessSegmentEquipmentRel(IDbContext dbContext, Processsegmentequipmentrel[] processSegmentEquipmentRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processSegmentEquipmentRelList", processSegmentEquipmentRelList);
		string text = "UnDeleteProcessSegmentEquipmentRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processsegmentequipmentrel> list = new List<Processsegmentequipmentrel>();
		foreach (Processsegmentequipmentrel processsegmentequipmentrel in processSegmentEquipmentRelList)
		{
			Processsegmentequipmentrel processSegmentEquipmentRel4Update = GetProcessSegmentEquipmentRel4Update(dbContext, processsegmentequipmentrel.Processsegmentid, processsegmentequipmentrel.Equipmentid, processsegmentequipmentrel.Siteid);
			if (processSegmentEquipmentRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentequipmentrel), $"{processsegmentequipmentrel.Processsegmentid},{processsegmentequipmentrel.Equipmentid},{processsegmentequipmentrel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Processsegmentequipmentrel), $"{processsegmentequipmentrel.Processsegmentid},{processsegmentequipmentrel.Equipmentid},{processsegmentequipmentrel.Siteid}", processSegmentEquipmentRel4Update.Isusable);
			processSegmentEquipmentRel4Update.Isusable = "Usable";
			processsegmentequipmentrel.CopyCommonFieldUpdatePrev(processSegmentEquipmentRel4Update, systemTime, dbContext.Tid, text);
			processsegmentequipmentrel.CopyExtensionCollection(processSegmentEquipmentRel4Update);
			list.Add(processSegmentEquipmentRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteProcessSegmentEquipmentRel(IDbContext dbContext, Processsegmentequipmentrel[] processSegmentEquipmentRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processSegmentEquipmentRelList", processSegmentEquipmentRelList);
		string text = "RealDeleteProcessSegmentEquipmentRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processsegmentequipmentrel> list = new List<Processsegmentequipmentrel>();
		foreach (Processsegmentequipmentrel processsegmentequipmentrel in processSegmentEquipmentRelList)
		{
			Processsegmentequipmentrel processSegmentEquipmentRel4Update = GetProcessSegmentEquipmentRel4Update(dbContext, processsegmentequipmentrel.Processsegmentid, processsegmentequipmentrel.Equipmentid, processsegmentequipmentrel.Siteid);
			if (processSegmentEquipmentRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processsegmentequipmentrel), $"{processsegmentequipmentrel.Processsegmentid},{processsegmentequipmentrel.Equipmentid},{processsegmentequipmentrel.Siteid}");
			}
			processsegmentequipmentrel.CopyCommonFieldUpdatePrev(processSegmentEquipmentRel4Update, systemTime, dbContext.Tid, text);
			processsegmentequipmentrel.CopyExtensionCollection(processSegmentEquipmentRel4Update);
			list.Add(processSegmentEquipmentRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static IList<Processsegmentequipmentrel> SelectProcessSegmentEquipmentRelWithEquipment(IDbContext dbContext, string equipmentid, string siteid)
	{
		string apiName = "SelectProcessSegmentEquipmentRelWithEquipment";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessSegmentEquipmentRelWithEquipmentSqlDatabase : _sqlSelectProcessSegmentEquipmentRelWithEquipmentOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PROCESSSEGMENTEQUIPMENTREL", $"{equipmentid},{siteid}"));
		}
		IList<Processsegmentequipmentrel> result = ContextManager.DirectEntityQuery<Processsegmentequipmentrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentid},{siteid}");
		}
		return result;
	}

	public static IList<Processsegmentequipmentrel> SelectProcessSegmentEquipmentRelWithProcesssegment(IDbContext dbContext, string processsegmentid, string siteid)
	{
		string apiName = "SelectProcessSegmentEquipmentRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processsegmentid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessSegmentEquipmentRelWithProcesssegmentSqlDatabase : _sqlSelectProcessSegmentEquipmentRelWithProcesssegmentOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PROCESSSEGMENTEQUIPMENTREL", $"{processsegmentid},{siteid}"));
		}
		IList<Processsegmentequipmentrel> result = ContextManager.DirectEntityQuery<Processsegmentequipmentrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processsegmentid},{siteid}");
		}
		return result;
	}
}
