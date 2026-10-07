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
public class TABLECOLUMNINTERNAL
{
	private static string _sqlGetTableColumnInternalSqlDatabase = "SELECT * FROM CIM_TABLECOLUMNINTERNAL WHERE TABLENAME=@TABLENAME AND COLUMNNAME=@COLUMNNAME";

	private static string _sqlGetTableColumnInternal4UpdateSqlDatabase = "SELECT * FROM CIM_TABLECOLUMNINTERNAL WITH(UPDLOCK) WHERE TABLENAME=@TABLENAME AND COLUMNNAME=@COLUMNNAME";

	private static string _sqlSelectTableColumnInternalSqlDatabase = "SELECT * FROM CIM_TABLECOLUMNINTERNAL WHERE TABLENAME=@TABLENAME AND COLUMNNAME=@COLUMNNAME AND ISUSABLE='Usable'";

	private static string _sqlSelectTableColumnInternal4UpdateSqlDatabase = "SELECT * FROM CIM_TABLECOLUMNINTERNAL WITH(UPDLOCK) WHERE TABLENAME=@TABLENAME AND COLUMNNAME=@COLUMNNAME AND ISUSABLE='Usable'";

	private static string _sqlGetTableColumnInternalOracleDatabase = "SELECT * FROM CIM_TABLECOLUMNINTERNAL WHERE TABLENAME=:TABLENAME AND COLUMNNAME=:COLUMNNAME";

	private static string _sqlGetTableColumnInternal4UpdateOracleDatabase = "SELECT * FROM CIM_TABLECOLUMNINTERNAL WHERE TABLENAME=:TABLENAME AND COLUMNNAME=:COLUMNNAME FOR UPDATE";

	private static string _sqlSelectTableColumnInternalOracleDatabase = "SELECT * FROM CIM_TABLECOLUMNINTERNAL WHERE TABLENAME=:TABLENAME AND COLUMNNAME=:COLUMNNAME AND ISUSABLE='Usable'";

	private static string _sqlSelectTableColumnInternal4UpdateOracleDatabase = "SELECT * FROM CIM_TABLECOLUMNINTERNAL WHERE TABLENAME=:TABLENAME AND COLUMNNAME=:COLUMNNAME AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Tablecolumninternal);

	public static Tablecolumninternal GetTableColumnInternal(IDbContext dbContext, string tablename, string columnname)
	{
		string apiName = "GetTableColumnInternal";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tablename},{columnname}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetTableColumnInternalSqlDatabase : _sqlGetTableColumnInternalOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TABLENAME", tablename, typeOfThis));
		list.Add(dbContext.CreateParameter("COLUMNNAME", columnname, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_TABLECOLUMNINTERNAL", $"{tablename},{columnname}"));
		}
		Tablecolumninternal? result = ContextManager.DirectEntityQuery<Tablecolumninternal>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tablename},{columnname}");
		}
		return result;
	}

	public static Tablecolumninternal GetTableColumnInternal4Update(IDbContext dbContext, string tablename, string columnname)
	{
		string apiName = "GetTableColumnInternal4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tablename},{columnname}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetTableColumnInternal4UpdateSqlDatabase : _sqlGetTableColumnInternal4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TABLENAME", tablename, typeOfThis));
		list.Add(dbContext.CreateParameter("COLUMNNAME", columnname, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_TABLECOLUMNINTERNAL", $"{tablename},{columnname}"));
		}
		Tablecolumninternal? result = ContextManager.DirectEntityQuery<Tablecolumninternal>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tablename},{columnname}");
		}
		return result;
	}

	public static Tablecolumninternal SelectTableColumnInternal(IDbContext dbContext, string tablename, string columnname)
	{
		string apiName = "SelectTableColumnInternal";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tablename},{columnname}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectTableColumnInternalSqlDatabase : _sqlSelectTableColumnInternalOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TABLENAME", tablename, typeOfThis));
		list.Add(dbContext.CreateParameter("COLUMNNAME", columnname, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_TABLECOLUMNINTERNAL", $"{tablename},{columnname}"));
		}
		Tablecolumninternal? result = ContextManager.DirectEntityQuery<Tablecolumninternal>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tablename},{columnname}");
		}
		return result;
	}

	public static Tablecolumninternal SelectTableColumnInternal4Update(IDbContext dbContext, string tablename, string columnname)
	{
		string apiName = "SelectTableColumnInternal4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tablename},{columnname}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectTableColumnInternal4UpdateSqlDatabase : _sqlSelectTableColumnInternal4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TABLENAME", tablename, typeOfThis));
		list.Add(dbContext.CreateParameter("COLUMNNAME", columnname, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_TABLECOLUMNINTERNAL", $"{tablename},{columnname}"));
		}
		Tablecolumninternal? result = ContextManager.DirectEntityQuery<Tablecolumninternal>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tablename},{columnname}");
		}
		return result;
	}

	public static int UpsertTableColumnInternal(IDbContext dbContext, RequestType requestType, Tablecolumninternal[] tableColumnInternalList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateTableColumnInternalInternal(dbContext, tableColumnInternalList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateTableColumnInternal(dbContext, tableColumnInternalList, optionSet, saveHist), 
			RequestType.DELETE => DeleteTableColumnInternal(dbContext, tableColumnInternalList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteTableColumnInternal(dbContext, tableColumnInternalList, optionSet, saveHist), 
			_ => RealDeleteTableColumnInternal(dbContext, tableColumnInternalList, optionSet, saveHist), 
		};
	}

	private static int CreateTableColumnInternalInternal(IDbContext dbContext, Tablecolumninternal[] tableColumnInternalList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("tableColumnInternalList", tableColumnInternalList);
		string text = "CreateTableColumnInternal";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tablecolumninternal> list = new List<Tablecolumninternal>();
		foreach (Tablecolumninternal obj in tableColumnInternalList)
		{
			Tablecolumninternal tablecolumninternal = new Tablecolumninternal();
			obj.CopyColumsTo(tablecolumninternal);
			tablecolumninternal.Activity = text;
			tablecolumninternal.CheckEntityUsable();
			obj.CopyCommonField(tablecolumninternal, systemTime, dbContext.Tid, isCreate: true);
			list.Add(tablecolumninternal);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateTableColumnInternal(IDbContext dbContext, Tablecolumninternal[] tableColumnInternalList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("tableColumnInternalList", tableColumnInternalList);
		string text = "UpdateTableColumnInternal";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tablecolumninternal> list = new List<Tablecolumninternal>();
		foreach (Tablecolumninternal tablecolumninternal in tableColumnInternalList)
		{
			Tablecolumninternal tableColumnInternal4Update = GetTableColumnInternal4Update(dbContext, tablecolumninternal.Tablename, tablecolumninternal.Columnname);
			if (tableColumnInternal4Update == null)
			{
				throw new EntityNotFoundException(typeof(Tablecolumninternal), $"{tablecolumninternal.Tablename},{tablecolumninternal.Columnname}");
			}
			ParamChecker.EntityUsable(typeof(Tablecolumninternal), $"{tablecolumninternal.Tablename},{tablecolumninternal.Columnname}", tableColumnInternal4Update.Isusable);
			string activity = tableColumnInternal4Update.Activity;
			string customactivity = tableColumnInternal4Update.Customactivity;
			string isusable = tableColumnInternal4Update.Isusable;
			DateTime? createtime = tableColumnInternal4Update.Createtime;
			string creator = tableColumnInternal4Update.Creator;
			tablecolumninternal.CopyColumsTo(tableColumnInternal4Update);
			tableColumnInternal4Update.Prevactivity = activity;
			tableColumnInternal4Update.Prevcustomactivity = customactivity;
			tableColumnInternal4Update.Creator = creator;
			tableColumnInternal4Update.Createtime = createtime;
			tableColumnInternal4Update.Isusable = isusable;
			tableColumnInternal4Update.Activity = text;
			tablecolumninternal.CopyCommonField(tableColumnInternal4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(tableColumnInternal4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteTableColumnInternal(IDbContext dbContext, Tablecolumninternal[] tableColumnInternalList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("tableColumnInternalList", tableColumnInternalList);
		string text = "DeleteTableColumnInternal";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tablecolumninternal> list = new List<Tablecolumninternal>();
		foreach (Tablecolumninternal tablecolumninternal in tableColumnInternalList)
		{
			Tablecolumninternal tableColumnInternal4Update = GetTableColumnInternal4Update(dbContext, tablecolumninternal.Tablename, tablecolumninternal.Columnname);
			if (tableColumnInternal4Update == null)
			{
				throw new EntityNotFoundException(typeof(Tablecolumninternal), $"{tablecolumninternal.Tablename},{tablecolumninternal.Columnname}");
			}
			ParamChecker.EntityUsable(typeof(Tablecolumninternal), $"{tablecolumninternal.Tablename},{tablecolumninternal.Columnname}", tableColumnInternal4Update.Isusable);
			tableColumnInternal4Update.Isusable = "UnUsable";
			tablecolumninternal.CopyCommonFieldUpdatePrev(tableColumnInternal4Update, systemTime, dbContext.Tid, text);
			tablecolumninternal.CopyExtensionCollection(tableColumnInternal4Update);
			list.Add(tableColumnInternal4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteTableColumnInternal(IDbContext dbContext, Tablecolumninternal[] tableColumnInternalList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("tableColumnInternalList", tableColumnInternalList);
		string text = "UnDeleteTableColumnInternal";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tablecolumninternal> list = new List<Tablecolumninternal>();
		foreach (Tablecolumninternal tablecolumninternal in tableColumnInternalList)
		{
			Tablecolumninternal tableColumnInternal4Update = GetTableColumnInternal4Update(dbContext, tablecolumninternal.Tablename, tablecolumninternal.Columnname);
			if (tableColumnInternal4Update == null)
			{
				throw new EntityNotFoundException(typeof(Tablecolumninternal), $"{tablecolumninternal.Tablename},{tablecolumninternal.Columnname}");
			}
			ParamChecker.EntityUnUsable(typeof(Tablecolumninternal), $"{tablecolumninternal.Tablename},{tablecolumninternal.Columnname}", tableColumnInternal4Update.Isusable);
			tableColumnInternal4Update.Isusable = "Usable";
			tablecolumninternal.CopyCommonFieldUpdatePrev(tableColumnInternal4Update, systemTime, dbContext.Tid, text);
			tablecolumninternal.CopyExtensionCollection(tableColumnInternal4Update);
			list.Add(tableColumnInternal4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteTableColumnInternal(IDbContext dbContext, Tablecolumninternal[] tableColumnInternalList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("tableColumnInternalList", tableColumnInternalList);
		string text = "RealDeleteTableColumnInternal";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tablecolumninternal> list = new List<Tablecolumninternal>();
		foreach (Tablecolumninternal tablecolumninternal in tableColumnInternalList)
		{
			Tablecolumninternal tableColumnInternal4Update = GetTableColumnInternal4Update(dbContext, tablecolumninternal.Tablename, tablecolumninternal.Columnname);
			if (tableColumnInternal4Update == null)
			{
				throw new EntityNotFoundException(typeof(Tablecolumninternal), $"{tablecolumninternal.Tablename},{tablecolumninternal.Columnname}");
			}
			tablecolumninternal.CopyCommonFieldUpdatePrev(tableColumnInternal4Update, systemTime, dbContext.Tid, text);
			tablecolumninternal.CopyExtensionCollection(tableColumnInternal4Update);
			list.Add(tableColumnInternal4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
