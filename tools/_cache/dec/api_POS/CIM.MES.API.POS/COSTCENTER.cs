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
public class COSTCENTER
{
	private static string _sqlGetCostCenterSqlDatabase = "SELECT * FROM CIM_COSTCENTER WHERE COSTCENTERID=@COSTCENTERID AND SITEID=@SITEID";

	private static string _sqlGetCostCenter4UpdateSqlDatabase = "SELECT * FROM CIM_COSTCENTER WITH(UPDLOCK) WHERE COSTCENTERID=@COSTCENTERID AND SITEID=@SITEID";

	private static string _sqlSelectCostCenterSqlDatabase = "SELECT * FROM CIM_COSTCENTER WHERE COSTCENTERID=@COSTCENTERID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectCostCenter4UpdateSqlDatabase = "SELECT * FROM CIM_COSTCENTER WITH(UPDLOCK) WHERE COSTCENTERID=@COSTCENTERID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetCostCenterOracleDatabase = "SELECT * FROM CIM_COSTCENTER WHERE COSTCENTERID=:COSTCENTERID AND SITEID=:SITEID";

	private static string _sqlGetCostCenter4UpdateOracleDatabase = "SELECT * FROM CIM_COSTCENTER WHERE COSTCENTERID=:COSTCENTERID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectCostCenterOracleDatabase = "SELECT * FROM CIM_COSTCENTER WHERE COSTCENTERID=:COSTCENTERID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectCostCenter4UpdateOracleDatabase = "SELECT * FROM CIM_COSTCENTER WHERE COSTCENTERID=:COSTCENTERID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Costcenter);

	public static Costcenter GetCostCenter(IDbContext dbContext, string costcenterid, string siteid)
	{
		string apiName = "GetCostCenter";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{costcenterid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetCostCenterSqlDatabase : _sqlGetCostCenterOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("COSTCENTERID", costcenterid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_COSTCENTER", $"{costcenterid},{siteid}"));
		}
		Costcenter? result = ContextManager.DirectEntityQuery<Costcenter>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{costcenterid},{siteid}");
		}
		return result;
	}

	public static Costcenter GetCostCenter4Update(IDbContext dbContext, string costcenterid, string siteid)
	{
		string apiName = "GetCostCenter4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{costcenterid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetCostCenter4UpdateSqlDatabase : _sqlGetCostCenter4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("COSTCENTERID", costcenterid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_COSTCENTER", $"{costcenterid},{siteid}"));
		}
		Costcenter? result = ContextManager.DirectEntityQuery<Costcenter>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{costcenterid},{siteid}");
		}
		return result;
	}

	public static Costcenter SelectCostCenter(IDbContext dbContext, string costcenterid, string siteid)
	{
		string apiName = "SelectCostCenter";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{costcenterid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectCostCenterSqlDatabase : _sqlSelectCostCenterOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("COSTCENTERID", costcenterid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_COSTCENTER", $"{costcenterid},{siteid}"));
		}
		Costcenter? result = ContextManager.DirectEntityQuery<Costcenter>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{costcenterid},{siteid}");
		}
		return result;
	}

	public static Costcenter SelectCostCenter4Update(IDbContext dbContext, string costcenterid, string siteid)
	{
		string apiName = "SelectCostCenter4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{costcenterid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectCostCenter4UpdateSqlDatabase : _sqlSelectCostCenter4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("COSTCENTERID", costcenterid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_COSTCENTER", $"{costcenterid},{siteid}"));
		}
		Costcenter? result = ContextManager.DirectEntityQuery<Costcenter>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{costcenterid},{siteid}");
		}
		return result;
	}

	public static int UpsertCostCenter(IDbContext dbContext, RequestType requestType, Costcenter[] costCenterList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateCostCenterInternal(dbContext, costCenterList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateCostCenter(dbContext, costCenterList, optionSet, saveHist), 
			RequestType.DELETE => DeleteCostCenter(dbContext, costCenterList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteCostCenter(dbContext, costCenterList, optionSet, saveHist), 
			_ => RealDeleteCostCenter(dbContext, costCenterList, optionSet, saveHist), 
		};
	}

	private static int CreateCostCenterInternal(IDbContext dbContext, Costcenter[] costCenterList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("costCenterList", costCenterList);
		string text = "CreateCostCenter";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Costcenter> list = new List<Costcenter>();
		foreach (Costcenter obj in costCenterList)
		{
			Costcenter costcenter = new Costcenter();
			obj.CopyColumsTo(costcenter);
			costcenter.Activity = text;
			costcenter.CheckEntityUsable();
			obj.CopyCommonField(costcenter, systemTime, dbContext.Tid, isCreate: true);
			list.Add(costcenter);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateCostCenter(IDbContext dbContext, Costcenter[] costCenterList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("costCenterList", costCenterList);
		string text = "UpdateCostCenter";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Costcenter> list = new List<Costcenter>();
		foreach (Costcenter costcenter in costCenterList)
		{
			Costcenter costCenter4Update = GetCostCenter4Update(dbContext, costcenter.Costcenterid, costcenter.Siteid);
			if (costCenter4Update == null)
			{
				throw new EntityNotFoundException(typeof(Costcenter), $"{costcenter.Costcenterid},{costcenter.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Costcenter), $"{costcenter.Costcenterid},{costcenter.Siteid}", costCenter4Update.Isusable);
			string activity = costCenter4Update.Activity;
			string customactivity = costCenter4Update.Customactivity;
			string isusable = costCenter4Update.Isusable;
			DateTime? createtime = costCenter4Update.Createtime;
			string creator = costCenter4Update.Creator;
			costcenter.CopyColumsTo(costCenter4Update);
			costCenter4Update.Prevactivity = activity;
			costCenter4Update.Prevcustomactivity = customactivity;
			costCenter4Update.Creator = creator;
			costCenter4Update.Createtime = createtime;
			costCenter4Update.Isusable = isusable;
			costCenter4Update.Activity = text;
			costcenter.CopyCommonField(costCenter4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(costCenter4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteCostCenter(IDbContext dbContext, Costcenter[] costCenterList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("costCenterList", costCenterList);
		string text = "DeleteCostCenter";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Costcenter> list = new List<Costcenter>();
		foreach (Costcenter costcenter in costCenterList)
		{
			Costcenter costCenter4Update = GetCostCenter4Update(dbContext, costcenter.Costcenterid, costcenter.Siteid);
			if (costCenter4Update == null)
			{
				throw new EntityNotFoundException(typeof(Costcenter), $"{costcenter.Costcenterid},{costcenter.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Costcenter), $"{costcenter.Costcenterid},{costcenter.Siteid}", costCenter4Update.Isusable);
			costCenter4Update.Isusable = "UnUsable";
			costcenter.CopyCommonFieldUpdatePrev(costCenter4Update, systemTime, dbContext.Tid, text);
			costcenter.CopyExtensionCollection(costCenter4Update);
			list.Add(costCenter4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteCostCenter(IDbContext dbContext, Costcenter[] costCenterList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("costCenterList", costCenterList);
		string text = "UnDeleteCostCenter";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Costcenter> list = new List<Costcenter>();
		foreach (Costcenter costcenter in costCenterList)
		{
			Costcenter costCenter4Update = GetCostCenter4Update(dbContext, costcenter.Costcenterid, costcenter.Siteid);
			if (costCenter4Update == null)
			{
				throw new EntityNotFoundException(typeof(Costcenter), $"{costcenter.Costcenterid},{costcenter.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Costcenter), $"{costcenter.Costcenterid},{costcenter.Siteid}", costCenter4Update.Isusable);
			costCenter4Update.Isusable = "Usable";
			costcenter.CopyCommonFieldUpdatePrev(costCenter4Update, systemTime, dbContext.Tid, text);
			costcenter.CopyExtensionCollection(costCenter4Update);
			list.Add(costCenter4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteCostCenter(IDbContext dbContext, Costcenter[] costCenterList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("costCenterList", costCenterList);
		string text = "RealDeleteCostCenter";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Costcenter> list = new List<Costcenter>();
		foreach (Costcenter costcenter in costCenterList)
		{
			Costcenter costCenter4Update = GetCostCenter4Update(dbContext, costcenter.Costcenterid, costcenter.Siteid);
			if (costCenter4Update == null)
			{
				throw new EntityNotFoundException(typeof(Costcenter), $"{costcenter.Costcenterid},{costcenter.Siteid}");
			}
			costcenter.CopyCommonFieldUpdatePrev(costCenter4Update, systemTime, dbContext.Tid, text);
			costcenter.CopyExtensionCollection(costCenter4Update);
			list.Add(costCenter4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
