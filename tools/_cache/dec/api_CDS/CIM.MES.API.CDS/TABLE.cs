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
public class TABLE
{
	private static string _sqlGetTableSqlDatabase = "SELECT * FROM CIM_TABLE WHERE TABLEID=@TABLEID";

	private static string _sqlGetTable4UpdateSqlDatabase = "SELECT * FROM CIM_TABLE WITH(UPDLOCK) WHERE TABLEID=@TABLEID";

	private static string _sqlSelectTableSqlDatabase = "SELECT * FROM CIM_TABLE WHERE TABLEID=@TABLEID AND ISUSABLE='Usable'";

	private static string _sqlSelectTable4UpdateSqlDatabase = "SELECT * FROM CIM_TABLE WITH(UPDLOCK) WHERE TABLEID=@TABLEID AND ISUSABLE='Usable'";

	private static string _sqlGetTableOracleDatabase = "SELECT * FROM CIM_TABLE WHERE TABLEID=:TABLEID";

	private static string _sqlGetTable4UpdateOracleDatabase = "SELECT * FROM CIM_TABLE WHERE TABLEID=:TABLEID FOR UPDATE";

	private static string _sqlSelectTableOracleDatabase = "SELECT * FROM CIM_TABLE WHERE TABLEID=:TABLEID AND ISUSABLE='Usable'";

	private static string _sqlSelectTable4UpdateOracleDatabase = "SELECT * FROM CIM_TABLE WHERE TABLEID=:TABLEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Table);

	public static Table GetTable(IDbContext dbContext, string tableid)
	{
		string apiName = "GetTable";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tableid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetTableSqlDatabase : _sqlGetTableOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TABLEID", tableid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_TABLE", $"{tableid}"));
		}
		Table? result = ContextManager.DirectEntityQuery<Table>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tableid}");
		}
		return result;
	}

	public static Table GetTable4Update(IDbContext dbContext, string tableid)
	{
		string apiName = "GetTable4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tableid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetTable4UpdateSqlDatabase : _sqlGetTable4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TABLEID", tableid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_TABLE", $"{tableid}"));
		}
		Table? result = ContextManager.DirectEntityQuery<Table>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tableid}");
		}
		return result;
	}

	public static Table SelectTable(IDbContext dbContext, string tableid)
	{
		string apiName = "SelectTable";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tableid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectTableSqlDatabase : _sqlSelectTableOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TABLEID", tableid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_TABLE", $"{tableid}"));
		}
		Table? result = ContextManager.DirectEntityQuery<Table>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tableid}");
		}
		return result;
	}

	public static Table SelectTable4Update(IDbContext dbContext, string tableid)
	{
		string apiName = "SelectTable4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{tableid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectTable4UpdateSqlDatabase : _sqlSelectTable4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("TABLEID", tableid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_TABLE", $"{tableid}"));
		}
		Table? result = ContextManager.DirectEntityQuery<Table>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{tableid}");
		}
		return result;
	}

	public static int UpsertTable(IDbContext dbContext, RequestType requestType, Table[] tableList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateTableInternal(dbContext, tableList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateTable(dbContext, tableList, optionSet, saveHist), 
			RequestType.DELETE => DeleteTable(dbContext, tableList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteTable(dbContext, tableList, optionSet, saveHist), 
			_ => RealDeleteTable(dbContext, tableList, optionSet, saveHist), 
		};
	}

	private static int CreateTableInternal(IDbContext dbContext, Table[] tableList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("tableList", tableList);
		string text = "CreateTable";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Table> list = new List<Table>();
		foreach (Table obj in tableList)
		{
			Table table = new Table();
			obj.CopyColumsTo(table);
			table.Activity = text;
			table.CheckEntityUsable();
			obj.CopyCommonField(table, systemTime, dbContext.Tid, isCreate: true);
			list.Add(table);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateTable(IDbContext dbContext, Table[] tableList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("tableList", tableList);
		string text = "UpdateTable";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Table> list = new List<Table>();
		foreach (Table table in tableList)
		{
			Table table4Update = GetTable4Update(dbContext, table.Tableid);
			if (table4Update == null)
			{
				throw new EntityNotFoundException(typeof(Table), $"{table.Tableid}");
			}
			ParamChecker.EntityUsable(typeof(Table), $"{table.Tableid}", table4Update.Isusable);
			string activity = table4Update.Activity;
			string customactivity = table4Update.Customactivity;
			string isusable = table4Update.Isusable;
			DateTime? createtime = table4Update.Createtime;
			string creator = table4Update.Creator;
			table.CopyColumsTo(table4Update);
			table4Update.Prevactivity = activity;
			table4Update.Prevcustomactivity = customactivity;
			table4Update.Creator = creator;
			table4Update.Createtime = createtime;
			table4Update.Isusable = isusable;
			table4Update.Activity = text;
			table.CopyCommonField(table4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(table4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteTable(IDbContext dbContext, Table[] tableList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("tableList", tableList);
		string text = "DeleteTable";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Table> list = new List<Table>();
		foreach (Table table in tableList)
		{
			Table table4Update = GetTable4Update(dbContext, table.Tableid);
			if (table4Update == null)
			{
				throw new EntityNotFoundException(typeof(Table), $"{table.Tableid}");
			}
			ParamChecker.EntityUsable(typeof(Table), $"{table.Tableid}", table4Update.Isusable);
			table4Update.Isusable = "UnUsable";
			table.CopyCommonFieldUpdatePrev(table4Update, systemTime, dbContext.Tid, text);
			table.CopyExtensionCollection(table4Update);
			list.Add(table4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteTable(IDbContext dbContext, Table[] tableList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("tableList", tableList);
		string text = "UnDeleteTable";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Table> list = new List<Table>();
		foreach (Table table in tableList)
		{
			Table table4Update = GetTable4Update(dbContext, table.Tableid);
			if (table4Update == null)
			{
				throw new EntityNotFoundException(typeof(Table), $"{table.Tableid}");
			}
			ParamChecker.EntityUnUsable(typeof(Table), $"{table.Tableid}", table4Update.Isusable);
			table4Update.Isusable = "Usable";
			table.CopyCommonFieldUpdatePrev(table4Update, systemTime, dbContext.Tid, text);
			table.CopyExtensionCollection(table4Update);
			list.Add(table4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteTable(IDbContext dbContext, Table[] tableList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("tableList", tableList);
		string text = "RealDeleteTable";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Table> list = new List<Table>();
		foreach (Table table in tableList)
		{
			Table table4Update = GetTable4Update(dbContext, table.Tableid);
			if (table4Update == null)
			{
				throw new EntityNotFoundException(typeof(Table), $"{table.Tableid}");
			}
			table.CopyCommonFieldUpdatePrev(table4Update, systemTime, dbContext.Tid, text);
			table.CopyExtensionCollection(table4Update);
			list.Add(table4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
