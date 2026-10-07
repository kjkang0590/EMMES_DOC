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
public class TABLECOLUMN
{
	private static string _sqlGetTableColumnSqlDatabase = "SELECT * FROM CIM_TABLECOLUMN WHERE TABLEID=@TABLEID AND COLUMNID=@COLUMNID";

	private static string _sqlGetTableColumn4UpdateSqlDatabase = "SELECT * FROM CIM_TABLECOLUMN WITH(UPDLOCK) WHERE TABLEID=@TABLEID AND COLUMNID=@COLUMNID";

	private static string _sqlSelectTableColumnSqlDatabase = "SELECT * FROM CIM_TABLECOLUMN WHERE TABLEID=@TABLEID AND COLUMNID=@COLUMNID AND ISUSABLE='Usable'";

	private static string _sqlSelectTableColumn4UpdateSqlDatabase = "SELECT * FROM CIM_TABLECOLUMN WITH(UPDLOCK) WHERE TABLEID=@TABLEID AND COLUMNID=@COLUMNID AND ISUSABLE='Usable'";

	private static string _sqlGetTableColumnOracleDatabase = "SELECT * FROM CIM_TABLECOLUMN WHERE TABLEID=:TABLEID AND COLUMNID=:COLUMNID";

	private static string _sqlGetTableColumn4UpdateOracleDatabase = "SELECT * FROM CIM_TABLECOLUMN WHERE TABLEID=:TABLEID AND COLUMNID=:COLUMNID FOR UPDATE";

	private static string _sqlSelectTableColumnOracleDatabase = "SELECT * FROM CIM_TABLECOLUMN WHERE TABLEID=:TABLEID AND COLUMNID=:COLUMNID AND ISUSABLE='Usable'";

	private static string _sqlSelectTableColumn4UpdateOracleDatabase = "SELECT * FROM CIM_TABLECOLUMN WHERE TABLEID=:TABLEID AND COLUMNID=:COLUMNID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Tablecolumn);

	public static Tablecolumn GetTableColumn(IDbContext dbContext, string tableid, int columnid)
	{
		string apiName = "GetTableColumn";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tableid},{columnid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetTableColumnSqlDatabase : _sqlGetTableColumnOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TABLEID", tableid, typeOfThis));
		list.Add(dbContext.CreateParameter("COLUMNID", columnid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_TABLECOLUMN", $"{tableid},{columnid}"));
		}
		Tablecolumn? result = ContextManager.DirectEntityQuery<Tablecolumn>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tableid},{columnid}");
		}
		return result;
	}

	public static Tablecolumn GetTableColumn4Update(IDbContext dbContext, string tableid, decimal columnid)
	{
		string apiName = "GetTableColumn4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tableid},{columnid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetTableColumn4UpdateSqlDatabase : _sqlGetTableColumn4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TABLEID", tableid, typeOfThis));
		list.Add(dbContext.CreateParameter("COLUMNID", columnid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_TABLECOLUMN", $"{tableid},{columnid}"));
		}
		Tablecolumn? result = ContextManager.DirectEntityQuery<Tablecolumn>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tableid},{columnid}");
		}
		return result;
	}

	public static Tablecolumn SelectTableColumn(IDbContext dbContext, string tableid, int columnid)
	{
		string apiName = "SelectTableColumn";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tableid},{columnid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectTableColumnSqlDatabase : _sqlSelectTableColumnOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TABLEID", tableid, typeOfThis));
		list.Add(dbContext.CreateParameter("COLUMNID", columnid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_TABLECOLUMN", $"{tableid},{columnid}"));
		}
		Tablecolumn? result = ContextManager.DirectEntityQuery<Tablecolumn>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tableid},{columnid}");
		}
		return result;
	}

	public static Tablecolumn SelectTableColumn4Update(IDbContext dbContext, string tableid, int columnid)
	{
		string apiName = "SelectTableColumn4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tableid},{columnid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectTableColumn4UpdateSqlDatabase : _sqlSelectTableColumn4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TABLEID", tableid, typeOfThis));
		list.Add(dbContext.CreateParameter("COLUMNID", columnid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_TABLECOLUMN", $"{tableid},{columnid}"));
		}
		Tablecolumn? result = ContextManager.DirectEntityQuery<Tablecolumn>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tableid},{columnid}");
		}
		return result;
	}

	public static int UpsertTableColumn(IDbContext dbContext, RequestType requestType, Tablecolumn[] tableColumnList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateTableColumnInternal(dbContext, tableColumnList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateTableColumn(dbContext, tableColumnList, optionSet, saveHist), 
			RequestType.DELETE => DeleteTableColumn(dbContext, tableColumnList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteTableColumn(dbContext, tableColumnList, optionSet, saveHist), 
			_ => RealDeleteTableColumn(dbContext, tableColumnList, optionSet, saveHist), 
		};
	}

	private static int CreateTableColumnInternal(IDbContext dbContext, Tablecolumn[] tableColumnList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("tableColumnList", tableColumnList);
		string text = "CreateTableColumn";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tablecolumn> list = new List<Tablecolumn>();
		foreach (Tablecolumn obj in tableColumnList)
		{
			Tablecolumn tablecolumn = new Tablecolumn();
			obj.CopyColumsTo(tablecolumn);
			tablecolumn.Activity = text;
			tablecolumn.CheckEntityUsable();
			obj.CopyCommonField(tablecolumn, systemTime, dbContext.Tid, isCreate: true);
			list.Add(tablecolumn);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateTableColumn(IDbContext dbContext, Tablecolumn[] tableColumnList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("tableColumnList", tableColumnList);
		string text = "UpdateTableColumn";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tablecolumn> list = new List<Tablecolumn>();
		foreach (Tablecolumn tablecolumn in tableColumnList)
		{
			Tablecolumn tableColumn4Update = GetTableColumn4Update(dbContext, tablecolumn.Tableid, tablecolumn.Columnid);
			if (tableColumn4Update == null)
			{
				throw new EntityNotFoundException(typeof(Tablecolumn), $"{tablecolumn.Tableid},{tablecolumn.Columnid}");
			}
			ParamChecker.EntityUsable(typeof(Tablecolumn), $"{tablecolumn.Tableid},{tablecolumn.Columnid}", tableColumn4Update.Isusable);
			string activity = tableColumn4Update.Activity;
			string customactivity = tableColumn4Update.Customactivity;
			string isusable = tableColumn4Update.Isusable;
			DateTime? createtime = tableColumn4Update.Createtime;
			string creator = tableColumn4Update.Creator;
			tablecolumn.CopyColumsTo(tableColumn4Update);
			tableColumn4Update.Prevactivity = activity;
			tableColumn4Update.Prevcustomactivity = customactivity;
			tableColumn4Update.Creator = creator;
			tableColumn4Update.Createtime = createtime;
			tableColumn4Update.Isusable = isusable;
			tableColumn4Update.Activity = text;
			tablecolumn.CopyCommonField(tableColumn4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(tableColumn4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteTableColumn(IDbContext dbContext, Tablecolumn[] tableColumnList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("tableColumnList", tableColumnList);
		string text = "DeleteTableColumn";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tablecolumn> list = new List<Tablecolumn>();
		foreach (Tablecolumn tablecolumn in tableColumnList)
		{
			Tablecolumn tableColumn4Update = GetTableColumn4Update(dbContext, tablecolumn.Tableid, tablecolumn.Columnid);
			if (tableColumn4Update == null)
			{
				throw new EntityNotFoundException(typeof(Tablecolumn), $"{tablecolumn.Tableid},{tablecolumn.Columnid}");
			}
			ParamChecker.EntityUsable(typeof(Tablecolumn), $"{tablecolumn.Tableid},{tablecolumn.Columnid}", tableColumn4Update.Isusable);
			tableColumn4Update.Isusable = "UnUsable";
			tablecolumn.CopyCommonFieldUpdatePrev(tableColumn4Update, systemTime, dbContext.Tid, text);
			tablecolumn.CopyExtensionCollection(tableColumn4Update);
			list.Add(tableColumn4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteTableColumn(IDbContext dbContext, Tablecolumn[] tableColumnList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("tableColumnList", tableColumnList);
		string text = "UnDeleteTableColumn";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tablecolumn> list = new List<Tablecolumn>();
		foreach (Tablecolumn tablecolumn in tableColumnList)
		{
			Tablecolumn tableColumn4Update = GetTableColumn4Update(dbContext, tablecolumn.Tableid, tablecolumn.Columnid);
			if (tableColumn4Update == null)
			{
				throw new EntityNotFoundException(typeof(Tablecolumn), $"{tablecolumn.Tableid},{tablecolumn.Columnid}");
			}
			ParamChecker.EntityUnUsable(typeof(Tablecolumn), $"{tablecolumn.Tableid},{tablecolumn.Columnid}", tableColumn4Update.Isusable);
			tableColumn4Update.Isusable = "Usable";
			tablecolumn.CopyCommonFieldUpdatePrev(tableColumn4Update, systemTime, dbContext.Tid, text);
			tablecolumn.CopyExtensionCollection(tableColumn4Update);
			list.Add(tableColumn4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteTableColumn(IDbContext dbContext, Tablecolumn[] tableColumnList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("tableColumnList", tableColumnList);
		string text = "RealDeleteTableColumn";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Tablecolumn> list = new List<Tablecolumn>();
		foreach (Tablecolumn tablecolumn in tableColumnList)
		{
			Tablecolumn tableColumn4Update = GetTableColumn4Update(dbContext, tablecolumn.Tableid, tablecolumn.Columnid);
			if (tableColumn4Update == null)
			{
				throw new EntityNotFoundException(typeof(Tablecolumn), $"{tablecolumn.Tableid},{tablecolumn.Columnid}");
			}
			tablecolumn.CopyCommonFieldUpdatePrev(tableColumn4Update, systemTime, dbContext.Tid, text);
			tablecolumn.CopyExtensionCollection(tableColumn4Update);
			list.Add(tableColumn4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
