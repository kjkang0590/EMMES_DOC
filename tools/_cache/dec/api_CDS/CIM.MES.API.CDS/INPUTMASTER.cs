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
public class INPUTMASTER
{
	private static string _sqlGetInputMasterSqlDatabase = "SELECT * FROM CIM_INPUTMASTER WHERE MENUID=@MENUID AND LAYOUTID=@LAYOUTID AND SITEID=@SITEID AND TABLEID=@TABLEID AND COLUMNID=@COLUMNID AND INPUTCONTROLID=@INPUTCONTROLID";

	private static string _sqlGetInputMaster4UpdateSqlDatabase = "SELECT * FROM CIM_INPUTMASTER WITH(UPDLOCK) WHERE MENUID=@MENUID AND LAYOUTID=@LAYOUTID AND SITEID=@SITEID AND TABLEID=@TABLEID AND COLUMNID=@COLUMNID AND INPUTCONTROLID=@INPUTCONTROLID";

	private static string _sqlSelectInputMasterSqlDatabase = "SELECT * FROM CIM_INPUTMASTER WHERE MENUID=@MENUID AND LAYOUTID=@LAYOUTID AND SITEID=@SITEID AND TABLEID=@TABLEID AND COLUMNID=@COLUMNID AND INPUTCONTROLID=@INPUTCONTROLID AND ISUSABLE='Usable'";

	private static string _sqlSelectInputMaster4UpdateSqlDatabase = "SELECT * FROM CIM_INPUTMASTER WITH(UPDLOCK) WHERE MENUID=@MENUID AND LAYOUTID=@LAYOUTID AND SITEID=@SITEID AND TABLEID=@TABLEID AND COLUMNID=@COLUMNID AND INPUTCONTROLID=@INPUTCONTROLID AND ISUSABLE='Usable'";

	private static string _sqlGetInputMasterOracleDatabase = "SELECT * FROM CIM_INPUTMASTER WHERE MENUID=:MENUID AND LAYOUTID=:LAYOUTID AND SITEID=:SITEID AND TABLEID=:TABLEID AND COLUMNID=:COLUMNID AND INPUTCONTROLID=:INPUTCONTROLID";

	private static string _sqlGetInputMaster4UpdateOracleDatabase = "SELECT * FROM CIM_INPUTMASTER WHERE MENUID=:MENUID AND LAYOUTID=:LAYOUTID AND SITEID=:SITEID AND TABLEID=:TABLEID AND COLUMNID=:COLUMNID AND INPUTCONTROLID=:INPUTCONTROLID FOR UPDATE";

	private static string _sqlSelectInputMasterOracleDatabase = "SELECT * FROM CIM_INPUTMASTER WHERE MENUID=:MENUID AND LAYOUTID=:LAYOUTID AND SITEID=:SITEID AND TABLEID=:TABLEID AND COLUMNID=:COLUMNID AND INPUTCONTROLID=:INPUTCONTROLID AND ISUSABLE='Usable'";

	private static string _sqlSelectInputMaster4UpdateOracleDatabase = "SELECT * FROM CIM_INPUTMASTER WHERE MENUID=:MENUID AND LAYOUTID=:LAYOUTID AND SITEID=:SITEID AND TABLEID=:TABLEID AND COLUMNID=:COLUMNID AND INPUTCONTROLID=:INPUTCONTROLID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Inputmaster);

	public static Inputmaster GetInputMaster(IDbContext dbContext, string menuid, string layoutid, string siteid, string tableid, string columnid, string inputcontrolid)
	{
		string apiName = "GetInputMaster";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{menuid},{layoutid},{siteid},{tableid},{columnid},{inputcontrolid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetInputMasterSqlDatabase : _sqlGetInputMasterOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("LAYOUTID", layoutid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		list.Add(dbContext.CreateParameter("TABLEID", tableid, typeOfThis));
		list.Add(dbContext.CreateParameter("COLUMNID", columnid, typeOfThis));
		list.Add(dbContext.CreateParameter("INPUTCONTROLID", inputcontrolid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_INPUTMASTER", $"{menuid},{layoutid},{siteid},{tableid},{columnid},{inputcontrolid}"));
		}
		Inputmaster result = ContextManager.DirectEntityQuery<Inputmaster>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{menuid},{layoutid},{siteid},{tableid},{columnid},{inputcontrolid}");
		}
		return result;
	}

	public static Inputmaster GetInputMaster4Update(IDbContext dbContext, string menuid, string layoutid, string siteid, string tableid, string columnid, string inputcontrolid)
	{
		string apiName = "GetInputMaster4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{menuid},{layoutid},{siteid},{tableid},{columnid},{inputcontrolid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetInputMaster4UpdateSqlDatabase : _sqlGetInputMaster4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("LAYOUTID", layoutid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		list.Add(dbContext.CreateParameter("TABLEID", tableid, typeOfThis));
		list.Add(dbContext.CreateParameter("COLUMNID", columnid, typeOfThis));
		list.Add(dbContext.CreateParameter("INPUTCONTROLID", inputcontrolid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_INPUTMASTER", $"{menuid},{layoutid},{siteid},{tableid},{columnid},{inputcontrolid}"));
		}
		Inputmaster result = ContextManager.DirectEntityQuery<Inputmaster>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{menuid},{layoutid},{siteid},{tableid},{columnid},{inputcontrolid}");
		}
		return result;
	}

	public static Inputmaster SelectInputMaster(IDbContext dbContext, string menuid, string layoutid, string siteid, string tableid, string columnid, string inputcontrolid)
	{
		string apiName = "SelectInputMaster";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{menuid},{layoutid},{siteid},{tableid},{columnid},{inputcontrolid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectInputMasterSqlDatabase : _sqlSelectInputMasterOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("LAYOUTID", layoutid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		list.Add(dbContext.CreateParameter("TABLEID", tableid, typeOfThis));
		list.Add(dbContext.CreateParameter("COLUMNID", columnid, typeOfThis));
		list.Add(dbContext.CreateParameter("INPUTCONTROLID", inputcontrolid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_INPUTMASTER", $"{menuid},{layoutid},{siteid},{tableid},{columnid},{inputcontrolid}"));
		}
		Inputmaster result = ContextManager.DirectEntityQuery<Inputmaster>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{menuid},{layoutid},{siteid},{tableid},{columnid},{inputcontrolid}");
		}
		return result;
	}

	public static Inputmaster SelectInputMaster4Update(IDbContext dbContext, string menuid, string layoutid, string siteid, string tableid, string columnid, string inputcontrolid)
	{
		string apiName = "SelectInputMaster4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{menuid},{layoutid},{siteid},{tableid},{columnid},{inputcontrolid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectInputMaster4UpdateSqlDatabase : _sqlSelectInputMaster4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("MENUID", menuid, typeOfThis));
		list.Add(dbContext.CreateParameter("LAYOUTID", layoutid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		list.Add(dbContext.CreateParameter("TABLEID", tableid, typeOfThis));
		list.Add(dbContext.CreateParameter("COLUMNID", columnid, typeOfThis));
		list.Add(dbContext.CreateParameter("INPUTCONTROLID", inputcontrolid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_INPUTMASTER", $"{menuid},{layoutid},{siteid},{tableid},{columnid},{inputcontrolid}"));
		}
		Inputmaster result = ContextManager.DirectEntityQuery<Inputmaster>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{menuid},{layoutid},{siteid},{tableid},{columnid},{inputcontrolid}");
		}
		return result;
	}

	public static int UpsertInputMaster(IDbContext dbContext, RequestType requestType, Inputmaster[] inputMasterList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateInputMasterInternal(dbContext, inputMasterList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateInputMaster(dbContext, inputMasterList, optionSet, saveHist), 
			RequestType.DELETE => DeleteInputMaster(dbContext, inputMasterList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteInputMaster(dbContext, inputMasterList, optionSet, saveHist), 
			_ => RealDeleteInputMaster(dbContext, inputMasterList, optionSet, saveHist), 
		};
	}

	private static int CreateInputMasterInternal(IDbContext dbContext, Inputmaster[] inputMasterList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inputMasterList", inputMasterList);
		string text = "CreateInputMaster";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inputmaster> list = new List<Inputmaster>();
		foreach (Inputmaster obj in inputMasterList)
		{
			Inputmaster inputmaster = new Inputmaster();
			obj.CopyColumsTo(inputmaster);
			inputmaster.Activity = text;
			inputmaster.CheckEntityUsable();
			obj.CopyCommonField(inputmaster, systemTime, dbContext.Tid, isCreate: true);
			list.Add(inputmaster);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateInputMaster(IDbContext dbContext, Inputmaster[] inputMasterList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inputMasterList", inputMasterList);
		string text = "UpdateInputMaster";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inputmaster> list = new List<Inputmaster>();
		foreach (Inputmaster inputmaster in inputMasterList)
		{
			Inputmaster inputMaster4Update = GetInputMaster4Update(dbContext, inputmaster.Menuid, inputmaster.Layoutid, inputmaster.Siteid, inputmaster.Tableid, inputmaster.Columnid, inputmaster.Inputcontrolid);
			if (inputMaster4Update == null)
			{
				throw new EntityNotFoundException(typeof(Inputmaster), $"{inputmaster.Menuid},{inputmaster.Layoutid},{inputmaster.Siteid},{inputmaster.Tableid},{inputmaster.Columnid},{inputmaster.Inputcontrolid}");
			}
			ParamChecker.EntityUsable(typeof(Inputmaster), $"{inputmaster.Menuid},{inputmaster.Layoutid},{inputmaster.Siteid},{inputmaster.Tableid},{inputmaster.Columnid},{inputmaster.Inputcontrolid}", inputMaster4Update.Isusable);
			string activity = inputMaster4Update.Activity;
			string customactivity = inputMaster4Update.Customactivity;
			string isusable = inputMaster4Update.Isusable;
			DateTime? createtime = inputMaster4Update.Createtime;
			string creator = inputMaster4Update.Creator;
			inputmaster.CopyColumsTo(inputMaster4Update);
			inputMaster4Update.Prevactivity = activity;
			inputMaster4Update.Prevcustomactivity = customactivity;
			inputMaster4Update.Creator = creator;
			inputMaster4Update.Createtime = createtime;
			inputMaster4Update.Isusable = isusable;
			inputMaster4Update.Activity = text;
			inputmaster.CopyCommonField(inputMaster4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(inputMaster4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteInputMaster(IDbContext dbContext, Inputmaster[] inputMasterList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inputMasterList", inputMasterList);
		string text = "DeleteInputMaster";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inputmaster> list = new List<Inputmaster>();
		foreach (Inputmaster inputmaster in inputMasterList)
		{
			Inputmaster inputMaster4Update = GetInputMaster4Update(dbContext, inputmaster.Menuid, inputmaster.Layoutid, inputmaster.Siteid, inputmaster.Tableid, inputmaster.Columnid, inputmaster.Inputcontrolid);
			if (inputMaster4Update == null)
			{
				throw new EntityNotFoundException(typeof(Inputmaster), $"{inputmaster.Menuid},{inputmaster.Layoutid},{inputmaster.Siteid},{inputmaster.Tableid},{inputmaster.Columnid},{inputmaster.Inputcontrolid}");
			}
			ParamChecker.EntityUsable(typeof(Inputmaster), $"{inputmaster.Menuid},{inputmaster.Layoutid},{inputmaster.Siteid},{inputmaster.Tableid},{inputmaster.Columnid},{inputmaster.Inputcontrolid}", inputMaster4Update.Isusable);
			inputMaster4Update.Isusable = "UnUsable";
			inputmaster.CopyCommonFieldUpdatePrev(inputMaster4Update, systemTime, dbContext.Tid, text);
			inputmaster.CopyExtensionCollection(inputMaster4Update);
			list.Add(inputMaster4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteInputMaster(IDbContext dbContext, Inputmaster[] inputMasterList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inputMasterList", inputMasterList);
		string text = "UnDeleteInputMaster";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inputmaster> list = new List<Inputmaster>();
		foreach (Inputmaster inputmaster in inputMasterList)
		{
			Inputmaster inputMaster4Update = GetInputMaster4Update(dbContext, inputmaster.Menuid, inputmaster.Layoutid, inputmaster.Siteid, inputmaster.Tableid, inputmaster.Columnid, inputmaster.Inputcontrolid);
			if (inputMaster4Update == null)
			{
				throw new EntityNotFoundException(typeof(Inputmaster), $"{inputmaster.Menuid},{inputmaster.Layoutid},{inputmaster.Siteid},{inputmaster.Tableid},{inputmaster.Columnid},{inputmaster.Inputcontrolid}");
			}
			ParamChecker.EntityUnUsable(typeof(Inputmaster), $"{inputmaster.Menuid},{inputmaster.Layoutid},{inputmaster.Siteid},{inputmaster.Tableid},{inputmaster.Columnid},{inputmaster.Inputcontrolid}", inputMaster4Update.Isusable);
			inputMaster4Update.Isusable = "Usable";
			inputmaster.CopyCommonFieldUpdatePrev(inputMaster4Update, systemTime, dbContext.Tid, text);
			inputmaster.CopyExtensionCollection(inputMaster4Update);
			list.Add(inputMaster4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteInputMaster(IDbContext dbContext, Inputmaster[] inputMasterList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inputMasterList", inputMasterList);
		string text = "RealDeleteInputMaster";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Inputmaster> list = new List<Inputmaster>();
		foreach (Inputmaster inputmaster in inputMasterList)
		{
			Inputmaster inputMaster4Update = GetInputMaster4Update(dbContext, inputmaster.Menuid, inputmaster.Layoutid, inputmaster.Siteid, inputmaster.Tableid, inputmaster.Columnid, inputmaster.Inputcontrolid);
			if (inputMaster4Update == null)
			{
				throw new EntityNotFoundException(typeof(Inputmaster), $"{inputmaster.Menuid},{inputmaster.Layoutid},{inputmaster.Siteid},{inputmaster.Tableid},{inputmaster.Columnid},{inputmaster.Inputcontrolid}");
			}
			inputmaster.CopyCommonFieldUpdatePrev(inputMaster4Update, systemTime, dbContext.Tid, text);
			inputmaster.CopyExtensionCollection(inputMaster4Update);
			list.Add(inputMaster4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
