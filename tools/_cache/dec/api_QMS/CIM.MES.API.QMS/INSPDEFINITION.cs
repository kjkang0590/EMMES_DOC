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
public class INSPDEFINITION
{
	private static string _sqlGetInspDefinitionSqlDatabase = "SELECT * FROM CIM_INSPDEFINITION WHERE INSPDEFINITIONSYSID=@INSPDEFINITIONSYSID AND SITEID=@SITEID";

	private static string _sqlGetInspDefinition4UpdateSqlDatabase = "SELECT * FROM CIM_INSPDEFINITION WITH(UPDLOCK) WHERE INSPDEFINITIONSYSID=@INSPDEFINITIONSYSID AND SITEID=@SITEID";

	private static string _sqlSelectInspDefinitionSqlDatabase = "SELECT * FROM CIM_INSPDEFINITION WHERE INSPDEFINITIONSYSID=@INSPDEFINITIONSYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectInspDefinition4UpdateSqlDatabase = "SELECT * FROM CIM_INSPDEFINITION WITH(UPDLOCK) WHERE INSPDEFINITIONSYSID=@INSPDEFINITIONSYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetInspDefinitionOracleDatabase = "SELECT * FROM CIM_INSPDEFINITION WHERE INSPDEFINITIONSYSID=:INSPDEFINITIONSYSID AND SITEID=:SITEID";

	private static string _sqlGetInspDefinition4UpdateOracleDatabase = "SELECT * FROM CIM_INSPDEFINITION WHERE INSPDEFINITIONSYSID=:INSPDEFINITIONSYSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectInspDefinitionOracleDatabase = "SELECT * FROM CIM_INSPDEFINITION WHERE INSPDEFINITIONSYSID=:INSPDEFINITIONSYSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectInspDefinition4UpdateOracleDatabase = "SELECT * FROM CIM_INSPDEFINITION WHERE INSPDEFINITIONSYSID=:INSPDEFINITIONSYSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Inspdefinition);

	private static string _sqlSelectInspDefinitionListSqlDatabase = "SELECT * FROM CIM_INSPDEFINITION WHERE INSPTYPE=@INSPTYPE AND ITEMID=@ITEMID AND INSPSPEC=@INSPSPEC AND SITEID=@SITEID";

	private static string _sqlSelectInspDefinitionListOracleDatabase = "SELECT * FROM CIM_INSPDEFINITION WHERE INSPTYPE=:INSPTYPE AND ITEMID=:ITEMID AND INSPSPEC=:INSPSPEC AND SITEID=:SITEID";

	public static Inspdefinition GetInspDefinition(IDbContext dbContext, string inspdefinitionsysid, string siteid)
	{
		string apiName = "GetInspDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspdefinitionsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetInspDefinitionSqlDatabase : _sqlGetInspDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPDEFINITIONSYSID", inspdefinitionsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_INSPDEFINITION", $"{inspdefinitionsysid},{siteid}"));
		}
		Inspdefinition? result = ContextManager.DirectEntityQuery<Inspdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspdefinitionsysid},{siteid}");
		}
		return result;
	}

	public static Inspdefinition GetInspDefinition4Update(IDbContext dbContext, string inspdefinitionsysid, string siteid)
	{
		string apiName = "GetInspDefinition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspdefinitionsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetInspDefinition4UpdateSqlDatabase : _sqlGetInspDefinition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPDEFINITIONSYSID", inspdefinitionsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_INSPDEFINITION", $"{inspdefinitionsysid},{siteid}"));
		}
		Inspdefinition? result = ContextManager.DirectEntityQuery<Inspdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspdefinitionsysid},{siteid}");
		}
		return result;
	}

	public static Inspdefinition SelectInspDefinition(IDbContext dbContext, string inspdefinitionsysid, string siteid)
	{
		string apiName = "SelectInspDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspdefinitionsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectInspDefinitionSqlDatabase : _sqlSelectInspDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPDEFINITIONSYSID", inspdefinitionsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_INSPDEFINITION", $"{inspdefinitionsysid},{siteid}"));
		}
		Inspdefinition? result = ContextManager.DirectEntityQuery<Inspdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspdefinitionsysid},{siteid}");
		}
		return result;
	}

	public static Inspdefinition SelectInspDefinition4Update(IDbContext dbContext, string inspdefinitionsysid, string siteid)
	{
		string apiName = "SelectInspDefinition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspdefinitionsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectInspDefinition4UpdateSqlDatabase : _sqlSelectInspDefinition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPDEFINITIONSYSID", inspdefinitionsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_INSPDEFINITION", $"{inspdefinitionsysid},{siteid}"));
		}
		Inspdefinition? result = ContextManager.DirectEntityQuery<Inspdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspdefinitionsysid},{siteid}");
		}
		return result;
	}

	public static IList<Inspdefinition> SelectInspDefinitionList(IDbContext dbContext, string inspType, string itemId, string inspSpec, string siteid)
	{
		string apiName = "SelectInspDefinitionList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{inspType},{itemId},{inspSpec},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectInspDefinitionListSqlDatabase : _sqlSelectInspDefinitionListOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("INSPTYPE", inspType, typeOfThis));
		list.Add(dbContext.CreateParameter("ITEMID", itemId, typeOfThis));
		list.Add(dbContext.CreateParameter("INSPSPEC", inspSpec, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_INSPDEFINITION", $"{inspType},{itemId},{inspSpec},{siteid}"));
		}
		IList<Inspdefinition> result = ContextManager.DirectEntityQuery<Inspdefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{inspType},{itemId},{inspSpec},{siteid}");
		}
		return result;
	}

	public static int UpsertInspDefinition(IDbContext dbContext, RequestType requestType, Inspdefinition[] inspDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateInspDefinitionInternal(dbContext, inspDefinitionList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateInspDefinition(dbContext, inspDefinitionList, optionSet, saveHist), 
			RequestType.DELETE => DeleteInspDefinition(dbContext, inspDefinitionList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteInspDefinition(dbContext, inspDefinitionList, optionSet, saveHist), 
			_ => RealDeleteInspDefinition(dbContext, inspDefinitionList, optionSet, saveHist), 
		};
	}

	private static int CreateInspDefinitionInternal(IDbContext dbContext, Inspdefinition[] inspDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspDefinitionList", inspDefinitionList);
		string text = "CreateInspDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspdefinition> list = new List<Inspdefinition>();
		foreach (Inspdefinition obj in inspDefinitionList)
		{
			Inspdefinition inspdefinition = new Inspdefinition();
			obj.CopyColumsTo(inspdefinition);
			inspdefinition.Activity = text;
			inspdefinition.CheckEntityUsable();
			obj.CopyCommonField(inspdefinition, systemTime, dbContext.Tid, isCreate: true);
			list.Add(inspdefinition);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateInspDefinition(IDbContext dbContext, Inspdefinition[] inspDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspDefinitionList", inspDefinitionList);
		string text = "UpdateInspDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspdefinition> list = new List<Inspdefinition>();
		foreach (Inspdefinition inspdefinition in inspDefinitionList)
		{
			Inspdefinition inspDefinition4Update = GetInspDefinition4Update(dbContext, inspdefinition.Inspdefinitionsysid, inspdefinition.Siteid);
			if (inspDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Inspdefinition), $"{inspdefinition.Inspdefinitionsysid},{inspdefinition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Inspdefinition), $"{inspdefinition.Inspdefinitionsysid},{inspdefinition.Siteid}", inspDefinition4Update.Isusable);
			string activity = inspDefinition4Update.Activity;
			string customactivity = inspDefinition4Update.Customactivity;
			string isusable = inspDefinition4Update.Isusable;
			DateTime? createtime = inspDefinition4Update.Createtime;
			string creator = inspDefinition4Update.Creator;
			inspdefinition.CopyColumsTo(inspDefinition4Update);
			inspDefinition4Update.Prevactivity = activity;
			inspDefinition4Update.Prevcustomactivity = customactivity;
			inspDefinition4Update.Creator = creator;
			inspDefinition4Update.Createtime = createtime;
			inspDefinition4Update.Isusable = isusable;
			inspDefinition4Update.Activity = text;
			inspdefinition.CopyCommonField(inspDefinition4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(inspDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteInspDefinition(IDbContext dbContext, Inspdefinition[] inspDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspDefinitionList", inspDefinitionList);
		string text = "DeleteInspDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspdefinition> list = new List<Inspdefinition>();
		foreach (Inspdefinition inspdefinition in inspDefinitionList)
		{
			Inspdefinition inspDefinition4Update = GetInspDefinition4Update(dbContext, inspdefinition.Inspdefinitionsysid, inspdefinition.Siteid);
			if (inspDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Inspdefinition), $"{inspdefinition.Inspdefinitionsysid},{inspdefinition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Inspdefinition), $"{inspdefinition.Inspdefinitionsysid},{inspdefinition.Siteid}", inspDefinition4Update.Isusable);
			inspDefinition4Update.Isusable = "UnUsable";
			inspdefinition.CopyCommonFieldUpdatePrev(inspDefinition4Update, systemTime, dbContext.Tid, text);
			inspdefinition.CopyExtensionCollection(inspDefinition4Update);
			list.Add(inspDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteInspDefinition(IDbContext dbContext, Inspdefinition[] inspDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspDefinitionList", inspDefinitionList);
		string text = "UnDeleteInspDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspdefinition> list = new List<Inspdefinition>();
		foreach (Inspdefinition inspdefinition in inspDefinitionList)
		{
			Inspdefinition inspDefinition4Update = GetInspDefinition4Update(dbContext, inspdefinition.Inspdefinitionsysid, inspdefinition.Siteid);
			if (inspDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Inspdefinition), $"{inspdefinition.Inspdefinitionsysid},{inspdefinition.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Inspdefinition), $"{inspdefinition.Inspdefinitionsysid},{inspdefinition.Siteid}", inspDefinition4Update.Isusable);
			inspDefinition4Update.Isusable = "Usable";
			inspdefinition.CopyCommonFieldUpdatePrev(inspDefinition4Update, systemTime, dbContext.Tid, text);
			inspdefinition.CopyExtensionCollection(inspDefinition4Update);
			list.Add(inspDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteInspDefinition(IDbContext dbContext, Inspdefinition[] inspDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inspDefinitionList", inspDefinitionList);
		string text = "RealDeleteInspDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inspdefinition> list = new List<Inspdefinition>();
		foreach (Inspdefinition inspdefinition in inspDefinitionList)
		{
			Inspdefinition inspDefinition4Update = GetInspDefinition4Update(dbContext, inspdefinition.Inspdefinitionsysid, inspdefinition.Siteid);
			if (inspDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Inspdefinition), $"{inspdefinition.Inspdefinitionsysid},{inspdefinition.Siteid}");
			}
			inspdefinition.CopyCommonFieldUpdatePrev(inspDefinition4Update, systemTime, dbContext.Tid, text);
			inspdefinition.CopyExtensionCollection(inspDefinition4Update);
			list.Add(inspDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
