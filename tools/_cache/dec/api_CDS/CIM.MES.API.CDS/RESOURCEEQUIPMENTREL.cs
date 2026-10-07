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
public class RESOURCEEQUIPMENTREL
{
	private static string _sqlGetResourceEquipmentRelSqlDatabase = "SELECT * FROM CIM_RESOURCEEQUIPMENTREL WHERE RESOURCEID=@RESOURCEID AND EQUIPMENTID=@EQUIPMENTID AND SITEID=@SITEID";

	private static string _sqlGetResourceEquipmentRel4UpdateSqlDatabase = "SELECT * FROM CIM_RESOURCEEQUIPMENTREL WITH(UPDLOCK) WHERE RESOURCEID=@RESOURCEID AND EQUIPMENTID=@EQUIPMENTID AND SITEID=@SITEID";

	private static string _sqlSelectResourceEquipmentRelSqlDatabase = "SELECT * FROM CIM_RESOURCEEQUIPMENTREL WHERE RESOURCEID=@RESOURCEID AND EQUIPMENTID=@EQUIPMENTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectResourceEquipmentRel4UpdateSqlDatabase = "SELECT * FROM CIM_RESOURCEEQUIPMENTREL WITH(UPDLOCK) WHERE RESOURCEID=@RESOURCEID AND EQUIPMENTID=@EQUIPMENTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetResourceEquipmentRelOracleDatabase = "SELECT * FROM CIM_RESOURCEEQUIPMENTREL WHERE RESOURCEID=:RESOURCEID AND EQUIPMENTID=:EQUIPMENTID AND SITEID=:SITEID";

	private static string _sqlGetResourceEquipmentRel4UpdateOracleDatabase = "SELECT * FROM CIM_RESOURCEEQUIPMENTREL WHERE RESOURCEID=:RESOURCEID AND EQUIPMENTID=:EQUIPMENTID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectResourceEquipmentRelOracleDatabase = "SELECT * FROM CIM_RESOURCEEQUIPMENTREL WHERE RESOURCEID=:RESOURCEID AND EQUIPMENTID=:EQUIPMENTID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectResourceEquipmentRel4UpdateOracleDatabase = "SELECT * FROM CIM_RESOURCEEQUIPMENTREL WHERE RESOURCEID=:RESOURCEID AND EQUIPMENTID=:EQUIPMENTID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Resourceequipmentrel);

	public static Resourceequipmentrel GetResourceEquipmentRel(IDbContext dbContext, string resourceid, string equipmentid, string siteid)
	{
		string apiName = "GetResourceEquipmentRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{resourceid},{equipmentid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetResourceEquipmentRelSqlDatabase : _sqlGetResourceEquipmentRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RESOURCEID", resourceid, typeOfThis));
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_RESOURCEEQUIPMENTREL", $"{resourceid},{equipmentid},{siteid}"));
		}
		Resourceequipmentrel? result = ContextManager.DirectEntityQuery<Resourceequipmentrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{resourceid},{equipmentid},{siteid}");
		}
		return result;
	}

	public static Resourceequipmentrel GetResourceEquipmentRel4Update(IDbContext dbContext, string resourceid, string equipmentid, string siteid)
	{
		string apiName = "GetResourceEquipmentRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{resourceid},{equipmentid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetResourceEquipmentRel4UpdateSqlDatabase : _sqlGetResourceEquipmentRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RESOURCEID", resourceid, typeOfThis));
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_RESOURCEEQUIPMENTREL", $"{resourceid},{equipmentid},{siteid}"));
		}
		Resourceequipmentrel? result = ContextManager.DirectEntityQuery<Resourceequipmentrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{resourceid},{equipmentid},{siteid}");
		}
		return result;
	}

	public static Resourceequipmentrel SelectResourceEquipmentRel(IDbContext dbContext, string resourceid, string equipmentid, string siteid)
	{
		string apiName = "SelectResourceEquipmentRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{resourceid},{equipmentid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectResourceEquipmentRelSqlDatabase : _sqlSelectResourceEquipmentRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RESOURCEID", resourceid, typeOfThis));
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_RESOURCEEQUIPMENTREL", $"{resourceid},{equipmentid},{siteid}"));
		}
		Resourceequipmentrel? result = ContextManager.DirectEntityQuery<Resourceequipmentrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{resourceid},{equipmentid},{siteid}");
		}
		return result;
	}

	public static Resourceequipmentrel SelectResourceEquipmentRel4Update(IDbContext dbContext, string resourceid, string equipmentid, string siteid)
	{
		string apiName = "SelectResourceEquipmentRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{resourceid},{equipmentid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectResourceEquipmentRel4UpdateSqlDatabase : _sqlSelectResourceEquipmentRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RESOURCEID", resourceid, typeOfThis));
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_RESOURCEEQUIPMENTREL", $"{resourceid},{equipmentid},{siteid}"));
		}
		Resourceequipmentrel? result = ContextManager.DirectEntityQuery<Resourceequipmentrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{resourceid},{equipmentid},{siteid}");
		}
		return result;
	}

	public static int UpsertResourceEquipmentRel(IDbContext dbContext, RequestType requestType, Resourceequipmentrel[] resourceEquipmentRelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateResourceEquipmentRelInternal(dbContext, resourceEquipmentRelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateResourceEquipmentRel(dbContext, resourceEquipmentRelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteResourceEquipmentRel(dbContext, resourceEquipmentRelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteResourceEquipmentRel(dbContext, resourceEquipmentRelList, optionSet, saveHist), 
			_ => RealDeleteResourceEquipmentRel(dbContext, resourceEquipmentRelList, optionSet, saveHist), 
		};
	}

	private static int CreateResourceEquipmentRelInternal(IDbContext dbContext, Resourceequipmentrel[] resourceEquipmentRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("resourceEquipmentRelList", resourceEquipmentRelList);
		string text = "CreateResourceEquipmentRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Resourceequipmentrel> list = new List<Resourceequipmentrel>();
		foreach (Resourceequipmentrel obj in resourceEquipmentRelList)
		{
			Resourceequipmentrel resourceequipmentrel = new Resourceequipmentrel();
			obj.CopyColumsTo(resourceequipmentrel);
			resourceequipmentrel.Activity = text;
			resourceequipmentrel.CheckEntityUsable();
			obj.CopyCommonField(resourceequipmentrel, systemTime, dbContext.Tid, isCreate: true);
			list.Add(resourceequipmentrel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateResourceEquipmentRel(IDbContext dbContext, Resourceequipmentrel[] resourceEquipmentRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("resourceEquipmentRelList", resourceEquipmentRelList);
		string text = "UpdateResourceEquipmentRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Resourceequipmentrel> list = new List<Resourceequipmentrel>();
		foreach (Resourceequipmentrel resourceequipmentrel in resourceEquipmentRelList)
		{
			Resourceequipmentrel resourceEquipmentRel4Update = GetResourceEquipmentRel4Update(dbContext, resourceequipmentrel.Resourceid, resourceequipmentrel.Equipmentid, resourceequipmentrel.Siteid);
			if (resourceEquipmentRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Resourceequipmentrel), $"{resourceequipmentrel.Resourceid},{resourceequipmentrel.Equipmentid},{resourceequipmentrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Resourceequipmentrel), $"{resourceequipmentrel.Resourceid},{resourceequipmentrel.Equipmentid},{resourceequipmentrel.Siteid}", resourceEquipmentRel4Update.Isusable);
			string activity = resourceEquipmentRel4Update.Activity;
			string customactivity = resourceEquipmentRel4Update.Customactivity;
			string isusable = resourceEquipmentRel4Update.Isusable;
			DateTime? createtime = resourceEquipmentRel4Update.Createtime;
			string creator = resourceEquipmentRel4Update.Creator;
			resourceequipmentrel.CopyColumsTo(resourceEquipmentRel4Update);
			resourceEquipmentRel4Update.Prevactivity = activity;
			resourceEquipmentRel4Update.Prevcustomactivity = customactivity;
			resourceEquipmentRel4Update.Creator = creator;
			resourceEquipmentRel4Update.Createtime = createtime;
			resourceEquipmentRel4Update.Isusable = isusable;
			resourceEquipmentRel4Update.Activity = text;
			resourceequipmentrel.CopyCommonField(resourceEquipmentRel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(resourceEquipmentRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteResourceEquipmentRel(IDbContext dbContext, Resourceequipmentrel[] resourceEquipmentRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("resourceEquipmentRelList", resourceEquipmentRelList);
		string text = "DeleteResourceEquipmentRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Resourceequipmentrel> list = new List<Resourceequipmentrel>();
		foreach (Resourceequipmentrel resourceequipmentrel in resourceEquipmentRelList)
		{
			Resourceequipmentrel resourceEquipmentRel4Update = GetResourceEquipmentRel4Update(dbContext, resourceequipmentrel.Resourceid, resourceequipmentrel.Equipmentid, resourceequipmentrel.Siteid);
			if (resourceEquipmentRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Resourceequipmentrel), $"{resourceequipmentrel.Resourceid},{resourceequipmentrel.Equipmentid},{resourceequipmentrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Resourceequipmentrel), $"{resourceequipmentrel.Resourceid},{resourceequipmentrel.Equipmentid},{resourceequipmentrel.Siteid}", resourceEquipmentRel4Update.Isusable);
			resourceEquipmentRel4Update.Isusable = "UnUsable";
			resourceequipmentrel.CopyCommonFieldUpdatePrev(resourceEquipmentRel4Update, systemTime, dbContext.Tid, text);
			resourceequipmentrel.CopyExtensionCollection(resourceEquipmentRel4Update);
			list.Add(resourceEquipmentRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteResourceEquipmentRel(IDbContext dbContext, Resourceequipmentrel[] resourceEquipmentRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("resourceEquipmentRelList", resourceEquipmentRelList);
		string text = "UnDeleteResourceEquipmentRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Resourceequipmentrel> list = new List<Resourceequipmentrel>();
		foreach (Resourceequipmentrel resourceequipmentrel in resourceEquipmentRelList)
		{
			Resourceequipmentrel resourceEquipmentRel4Update = GetResourceEquipmentRel4Update(dbContext, resourceequipmentrel.Resourceid, resourceequipmentrel.Equipmentid, resourceequipmentrel.Siteid);
			if (resourceEquipmentRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Resourceequipmentrel), $"{resourceequipmentrel.Resourceid},{resourceequipmentrel.Equipmentid},{resourceequipmentrel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Resourceequipmentrel), $"{resourceequipmentrel.Resourceid},{resourceequipmentrel.Equipmentid},{resourceequipmentrel.Siteid}", resourceEquipmentRel4Update.Isusable);
			resourceEquipmentRel4Update.Isusable = "Usable";
			resourceequipmentrel.CopyCommonFieldUpdatePrev(resourceEquipmentRel4Update, systemTime, dbContext.Tid, text);
			resourceequipmentrel.CopyExtensionCollection(resourceEquipmentRel4Update);
			list.Add(resourceEquipmentRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteResourceEquipmentRel(IDbContext dbContext, Resourceequipmentrel[] resourceEquipmentRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("resourceEquipmentRelList", resourceEquipmentRelList);
		string text = "RealDeleteResourceEquipmentRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Resourceequipmentrel> list = new List<Resourceequipmentrel>();
		foreach (Resourceequipmentrel resourceequipmentrel in resourceEquipmentRelList)
		{
			Resourceequipmentrel resourceEquipmentRel4Update = GetResourceEquipmentRel4Update(dbContext, resourceequipmentrel.Resourceid, resourceequipmentrel.Equipmentid, resourceequipmentrel.Siteid);
			if (resourceEquipmentRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Resourceequipmentrel), $"{resourceequipmentrel.Resourceid},{resourceequipmentrel.Equipmentid},{resourceequipmentrel.Siteid}");
			}
			resourceequipmentrel.CopyCommonFieldUpdatePrev(resourceEquipmentRel4Update, systemTime, dbContext.Tid, text);
			resourceequipmentrel.CopyExtensionCollection(resourceEquipmentRel4Update);
			list.Add(resourceEquipmentRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
