using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.RDS;

[MESAPI]
public class CARRIERDEFINITION
{
	private static string _sqlGetCarrierDefinitionSqlDatabase = "SELECT * FROM CIM_CARRIERDEFINITION WHERE CARRIERDEFINITIONID=@CARRIERDEFINITIONID AND SITEID=@SITEID";

	private static string _sqlGetCarrierDefinition4UpdateSqlDatabase = "SELECT * FROM CIM_CARRIERDEFINITION WITH(UPDLOCK) WHERE CARRIERDEFINITIONID=@CARRIERDEFINITIONID AND SITEID=@SITEID";

	private static string _sqlSelectCarrierDefinitionSqlDatabase = "SELECT * FROM CIM_CARRIERDEFINITION WHERE CARRIERDEFINITIONID=@CARRIERDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectCarrierDefinition4UpdateSqlDatabase = "SELECT * FROM CIM_CARRIERDEFINITION WITH(UPDLOCK) WHERE CARRIERDEFINITIONID=@CARRIERDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetCarrierDefinitionOracleDatabase = "SELECT * FROM CIM_CARRIERDEFINITION WHERE CARRIERDEFINITIONID=:CARRIERDEFINITIONID AND SITEID=:SITEID";

	private static string _sqlGetCarrierDefinition4UpdateOracleDatabase = "SELECT * FROM CIM_CARRIERDEFINITION WHERE CARRIERDEFINITIONID=:CARRIERDEFINITIONID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectCarrierDefinitionOracleDatabase = "SELECT * FROM CIM_CARRIERDEFINITION WHERE CARRIERDEFINITIONID=:CARRIERDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectCarrierDefinition4UpdateOracleDatabase = "SELECT * FROM CIM_CARRIERDEFINITION WHERE CARRIERDEFINITIONID=:CARRIERDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Carrierdefinition);

	public static Carrierdefinition GetCarrierDefinition(IDbContext dbContext, string carrierdefinitionid, string siteid)
	{
		string apiName = "GetCarrierDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{carrierdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetCarrierDefinitionSqlDatabase : _sqlGetCarrierDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CARRIERDEFINITIONID", carrierdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_CARRIERDEFINITION", $"{carrierdefinitionid},{siteid}"));
		}
		Carrierdefinition? result = ContextManager.DirectEntityQuery<Carrierdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{carrierdefinitionid},{siteid}");
		}
		return result;
	}

	public static Carrierdefinition GetCarrierDefinition4Update(IDbContext dbContext, string carrierdefinitionid, string siteid)
	{
		string apiName = "GetCarrierDefinition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{carrierdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetCarrierDefinition4UpdateSqlDatabase : _sqlGetCarrierDefinition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CARRIERDEFINITIONID", carrierdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_CARRIERDEFINITION", $"{carrierdefinitionid},{siteid}"));
		}
		Carrierdefinition? result = ContextManager.DirectEntityQuery<Carrierdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{carrierdefinitionid},{siteid}");
		}
		return result;
	}

	public static Carrierdefinition SelectCarrierDefinition(IDbContext dbContext, string carrierdefinitionid, string siteid)
	{
		string apiName = "SelectCarrierDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{carrierdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectCarrierDefinitionSqlDatabase : _sqlSelectCarrierDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CARRIERDEFINITIONID", carrierdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_CARRIERDEFINITION", $"{carrierdefinitionid},{siteid}"));
		}
		Carrierdefinition? result = ContextManager.DirectEntityQuery<Carrierdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{carrierdefinitionid},{siteid}");
		}
		return result;
	}

	public static Carrierdefinition SelectCarrierDefinition4Update(IDbContext dbContext, string carrierdefinitionid, string siteid)
	{
		string apiName = "SelectCarrierDefinition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{carrierdefinitionid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectCarrierDefinition4UpdateSqlDatabase : _sqlSelectCarrierDefinition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CARRIERDEFINITIONID", carrierdefinitionid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_CARRIERDEFINITION", $"{carrierdefinitionid},{siteid}"));
		}
		Carrierdefinition? result = ContextManager.DirectEntityQuery<Carrierdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{carrierdefinitionid},{siteid}");
		}
		return result;
	}

	public static int UpsertCarrierDefinition(IDbContext dbContext, RequestType requestType, Carrierdefinition[] carrierDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateCarrierDefinitionInternal(dbContext, carrierDefinitionList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateCarrierDefinition(dbContext, carrierDefinitionList, optionSet, saveHist), 
			RequestType.DELETE => DeleteCarrierDefinition(dbContext, carrierDefinitionList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteCarrierDefinition(dbContext, carrierDefinitionList, optionSet, saveHist), 
			_ => RealDeleteCarrierDefinition(dbContext, carrierDefinitionList, optionSet, saveHist), 
		};
	}

	private static int CreateCarrierDefinitionInternal(IDbContext dbContext, Carrierdefinition[] carrierDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("carrierDefinitionList", carrierDefinitionList);
		string text = "CreateCarrierDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Carrierdefinition> list = new List<Carrierdefinition>();
		foreach (Carrierdefinition obj in carrierDefinitionList)
		{
			Carrierdefinition carrierdefinition = new Carrierdefinition();
			obj.CopyColumsTo(carrierdefinition);
			carrierdefinition.Activity = text;
			carrierdefinition.CheckEntityUsable();
			obj.CopyCommonField(carrierdefinition, systemTime, dbContext.Tid, isCreate: true);
			list.Add(carrierdefinition);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateCarrierDefinition(IDbContext dbContext, Carrierdefinition[] carrierDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("carrierDefinitionList", carrierDefinitionList);
		string text = "UpdateCarrierDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Carrierdefinition> list = new List<Carrierdefinition>();
		foreach (Carrierdefinition carrierdefinition in carrierDefinitionList)
		{
			Carrierdefinition carrierDefinition4Update = GetCarrierDefinition4Update(dbContext, carrierdefinition.Carrierdefinitionid, carrierdefinition.Siteid);
			if (carrierDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Carrierdefinition), $"{carrierdefinition.Carrierdefinitionid},{carrierdefinition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Carrierdefinition), $"{carrierdefinition.Carrierdefinitionid},{carrierdefinition.Siteid}", carrierDefinition4Update.Isusable);
			string activity = carrierDefinition4Update.Activity;
			string customactivity = carrierDefinition4Update.Customactivity;
			string isusable = carrierDefinition4Update.Isusable;
			DateTime? createtime = carrierDefinition4Update.Createtime;
			string creator = carrierDefinition4Update.Creator;
			carrierdefinition.CopyColumsTo(carrierDefinition4Update);
			carrierDefinition4Update.Prevactivity = activity;
			carrierDefinition4Update.Prevcustomactivity = customactivity;
			carrierDefinition4Update.Creator = creator;
			carrierDefinition4Update.Createtime = createtime;
			carrierDefinition4Update.Isusable = isusable;
			carrierDefinition4Update.Activity = text;
			carrierdefinition.CopyCommonField(carrierDefinition4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(carrierDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteCarrierDefinition(IDbContext dbContext, Carrierdefinition[] carrierDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("carrierDefinitionList", carrierDefinitionList);
		string text = "DeleteCarrierDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Carrierdefinition> list = new List<Carrierdefinition>();
		foreach (Carrierdefinition carrierdefinition in carrierDefinitionList)
		{
			Carrierdefinition carrierDefinition4Update = GetCarrierDefinition4Update(dbContext, carrierdefinition.Carrierdefinitionid, carrierdefinition.Siteid);
			if (carrierDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Carrierdefinition), $"{carrierdefinition.Carrierdefinitionid},{carrierdefinition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Carrierdefinition), $"{carrierdefinition.Carrierdefinitionid},{carrierdefinition.Siteid}", carrierDefinition4Update.Isusable);
			carrierDefinition4Update.Isusable = "UnUsable";
			carrierdefinition.CopyCommonFieldUpdatePrev(carrierDefinition4Update, systemTime, dbContext.Tid, text);
			carrierdefinition.CopyExtensionCollection(carrierDefinition4Update);
			list.Add(carrierDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteCarrierDefinition(IDbContext dbContext, Carrierdefinition[] carrierDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("carrierDefinitionList", carrierDefinitionList);
		string text = "UnDeleteCarrierDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Carrierdefinition> list = new List<Carrierdefinition>();
		foreach (Carrierdefinition carrierdefinition in carrierDefinitionList)
		{
			Carrierdefinition carrierDefinition4Update = GetCarrierDefinition4Update(dbContext, carrierdefinition.Carrierdefinitionid, carrierdefinition.Siteid);
			if (carrierDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Carrierdefinition), $"{carrierdefinition.Carrierdefinitionid},{carrierdefinition.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Carrierdefinition), $"{carrierdefinition.Carrierdefinitionid},{carrierdefinition.Siteid}", carrierDefinition4Update.Isusable);
			carrierDefinition4Update.Isusable = "Usable";
			carrierdefinition.CopyCommonFieldUpdatePrev(carrierDefinition4Update, systemTime, dbContext.Tid, text);
			carrierdefinition.CopyExtensionCollection(carrierDefinition4Update);
			list.Add(carrierDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteCarrierDefinition(IDbContext dbContext, Carrierdefinition[] carrierDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("carrierDefinitionList", carrierDefinitionList);
		string text = "RealDeleteCarrierDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Carrierdefinition> list = new List<Carrierdefinition>();
		foreach (Carrierdefinition carrierdefinition in carrierDefinitionList)
		{
			Carrierdefinition carrierDefinition4Update = GetCarrierDefinition4Update(dbContext, carrierdefinition.Carrierdefinitionid, carrierdefinition.Siteid);
			if (carrierDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Carrierdefinition), $"{carrierdefinition.Carrierdefinitionid},{carrierdefinition.Siteid}");
			}
			carrierdefinition.CopyCommonFieldUpdatePrev(carrierDefinition4Update, systemTime, dbContext.Tid, text);
			carrierdefinition.CopyExtensionCollection(carrierDefinition4Update);
			list.Add(carrierDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
