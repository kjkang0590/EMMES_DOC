using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace THiRAMES.Service.API;

[MESAPI]
public class PALLETSTORED
{
	private static string _sqlGetPalletstoredSqlDatabase = "SELECT * FROM CUS_PALLETSTORED WHERE PALLETSTOREDNO=@PALLETSTOREDNO AND PALLETID=@PALLETID AND SITEID=@SITEID";

	private static string _sqlGetPalletstored4UpdateSqlDatabase = "SELECT * FROM CUS_PALLETSTORED WITH(UPDLOCK) WHERE PALLETSTOREDNO=@PALLETSTOREDNO AND PALLETID=@PALLETID AND SITEID=@SITEID";

	private static string _sqlSelectPalletstoredSqlDatabase = "SELECT * FROM CUS_PALLETSTORED WHERE PALLETSTOREDNO=@PALLETSTOREDNO AND PALLETID=@PALLETID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectPalletstored4UpdateSqlDatabase = "SELECT * FROM CUS_PALLETSTORED WITH(UPDLOCK) WHERE PALLETSTOREDNO=@PALLETSTOREDNO AND PALLETID=@PALLETID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetPalletstoredOracleDatabase = "SELECT * FROM CUS_PALLETSTORED WHERE PALLETSTOREDNO=:PALLETSTOREDNO AND PALLETID=:PALLETID AND SITEID=:SITEID";

	private static string _sqlGetPalletstored4UpdateOracleDatabase = "SELECT * FROM CUS_PALLETSTORED WHERE PALLETSTOREDNO=:PALLETSTOREDNO AND PALLETID=:PALLETID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectPalletstoredOracleDatabase = "SELECT * FROM CUS_PALLETSTORED WHERE PALLETSTOREDNO=:PALLETSTOREDNO AND PALLETID=:PALLETID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectPalletstored4UpdateOracleDatabase = "SELECT * FROM CUS_PALLETSTORED WHERE PALLETSTOREDNO=:PALLETSTOREDNO AND PALLETID=:PALLETID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Palletstored);

	public static Palletstored GetPalletstored(IDbContext dbContext, string palletstoredno, string palletid, string siteid)
	{
		string apiName = "GetPalletstored";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{palletstoredno},{palletid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetPalletstoredSqlDatabase : _sqlGetPalletstoredOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PALLETSTOREDNO", palletstoredno));
		list.Add(dbContext.CreateParameter("PALLETID", palletid));
		list.Add(dbContext.CreateParameter("SITEID", siteid));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CUS_PALLETSTORED", $"{palletstoredno},{palletid},{siteid}"));
		}
		Palletstored result = ContextManager.DirectEntityQuery<Palletstored>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{palletstoredno},{palletid},{siteid}");
		}
		return result;
	}

	public static Palletstored GetPalletstored4Update(IDbContext dbContext, string palletstoredno, string palletid, string siteid)
	{
		string apiName = "GetPalletstored4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{palletstoredno},{palletid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetPalletstored4UpdateSqlDatabase : _sqlGetPalletstored4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PALLETSTOREDNO", palletstoredno));
		list.Add(dbContext.CreateParameter("PALLETID", palletid));
		list.Add(dbContext.CreateParameter("SITEID", siteid));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CUS_PALLETSTORED", $"{palletstoredno},{palletid},{siteid}"));
		}
		Palletstored result = ContextManager.DirectEntityQuery<Palletstored>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{palletstoredno},{palletid},{siteid}");
		}
		return result;
	}

	public static Palletstored SelectPalletstored(IDbContext dbContext, string palletstoredno, string palletid, string siteid)
	{
		string apiName = "SelectPalletstored";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{palletstoredno},{palletid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectPalletstoredSqlDatabase : _sqlSelectPalletstoredOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PALLETSTOREDNO", palletstoredno));
		list.Add(dbContext.CreateParameter("PALLETID", palletid));
		list.Add(dbContext.CreateParameter("SITEID", siteid));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CUS_PALLETSTORED", $"{palletstoredno},{palletid},{siteid}"));
		}
		Palletstored result = ContextManager.DirectEntityQuery<Palletstored>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{palletstoredno},{palletid},{siteid}");
		}
		return result;
	}

	public static Palletstored SelectPalletstored4Update(IDbContext dbContext, string palletstoredno, string palletid, string siteid)
	{
		string apiName = "SelectPalletstored4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{palletstoredno},{palletid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectPalletstored4UpdateSqlDatabase : _sqlSelectPalletstored4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PALLETSTOREDNO", palletstoredno));
		list.Add(dbContext.CreateParameter("PALLETID", palletid));
		list.Add(dbContext.CreateParameter("SITEID", siteid));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CUS_PALLETSTORED", $"{palletstoredno},{palletid},{siteid}"));
		}
		Palletstored result = ContextManager.DirectEntityQuery<Palletstored>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{palletstoredno},{palletid},{siteid}");
		}
		return result;
	}

	public static int UpsertPalletstored(IDbContext dbContext, RequestType requestType, Palletstored[] palletstoredList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreatePalletstoredInternal(dbContext, palletstoredList, optionSet, saveHist), 
			RequestType.UPDATE => UpdatePalletstored(dbContext, palletstoredList, optionSet, saveHist), 
			RequestType.DELETE => DeletePalletstored(dbContext, palletstoredList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeletePalletstored(dbContext, palletstoredList, optionSet, saveHist), 
			_ => RealDeletePalletstored(dbContext, palletstoredList, optionSet, saveHist), 
		};
	}

	private static int CreatePalletstoredInternal(IDbContext dbContext, Palletstored[] palletstoredList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("palletstoredList", palletstoredList);
		string text = "CreatePalletstored";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Palletstored> list = new List<Palletstored>();
		foreach (Palletstored palletstored in palletstoredList)
		{
			Palletstored palletstored2 = new Palletstored();
			palletstored.CopyColumsTo(palletstored2);
			palletstored2.Activity = text;
			palletstored2.CheckEntityUsable();
			palletstored.CopyCommonField(palletstored2, systemTime, dbContext.Tid, isCreate: true);
			list.Add(palletstored2);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdatePalletstored(IDbContext dbContext, Palletstored[] palletstoredList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("palletstoredList", palletstoredList);
		string text = "UpdatePalletstored";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Palletstored> list = new List<Palletstored>();
		foreach (Palletstored palletstored in palletstoredList)
		{
			Palletstored palletstored4Update = GetPalletstored4Update(dbContext, palletstored.Palletstoredno, palletstored.Palletid, palletstored.Siteid);
			if (palletstored4Update == null)
			{
				throw new EntityNotFoundException(typeof(Palletstored), $"{palletstored.Palletstoredno},{palletstored.Palletid},{palletstored.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Palletstored), $"{palletstored.Palletstoredno},{palletstored.Palletid},{palletstored.Siteid}", palletstored4Update.Isusable);
			string activity = palletstored4Update.Activity;
			string customactivity = palletstored4Update.Customactivity;
			string isusable = palletstored4Update.Isusable;
			DateTime? createtime = palletstored4Update.Createtime;
			string creator = palletstored4Update.Creator;
			palletstored.CopyColumsTo(palletstored4Update);
			palletstored4Update.Prevactivity = activity;
			palletstored4Update.Prevcustomactivity = customactivity;
			palletstored4Update.Creator = creator;
			palletstored4Update.Createtime = createtime;
			palletstored4Update.Isusable = isusable;
			palletstored4Update.Activity = text;
			palletstored.CopyCommonField(palletstored4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(palletstored4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeletePalletstored(IDbContext dbContext, Palletstored[] palletstoredList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("palletstoredList", palletstoredList);
		string text = "DeletePalletstored";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Palletstored> list = new List<Palletstored>();
		foreach (Palletstored palletstored in palletstoredList)
		{
			Palletstored palletstored4Update = GetPalletstored4Update(dbContext, palletstored.Palletstoredno, palletstored.Palletid, palletstored.Siteid);
			if (palletstored4Update == null)
			{
				throw new EntityNotFoundException(typeof(Palletstored), $"{palletstored.Palletstoredno},{palletstored.Palletid},{palletstored.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Palletstored), $"{palletstored.Palletstoredno},{palletstored.Palletid},{palletstored.Siteid}", palletstored4Update.Isusable);
			palletstored4Update.Isusable = "UnUsable";
			palletstored.CopyCommonFieldUpdatePrev(palletstored4Update, systemTime, dbContext.Tid, text);
			palletstored.CopyExtensionCollection(palletstored4Update);
			list.Add(palletstored4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeletePalletstored(IDbContext dbContext, Palletstored[] palletstoredList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("palletstoredList", palletstoredList);
		string text = "UnDeletePalletstored";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Palletstored> list = new List<Palletstored>();
		foreach (Palletstored palletstored in palletstoredList)
		{
			Palletstored palletstored4Update = GetPalletstored4Update(dbContext, palletstored.Palletstoredno, palletstored.Palletid, palletstored.Siteid);
			if (palletstored4Update == null)
			{
				throw new EntityNotFoundException(typeof(Palletstored), $"{palletstored.Palletstoredno},{palletstored.Palletid},{palletstored.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Palletstored), $"{palletstored.Palletstoredno},{palletstored.Palletid},{palletstored.Siteid}", palletstored4Update.Isusable);
			palletstored4Update.Isusable = "Usable";
			palletstored.CopyCommonFieldUpdatePrev(palletstored4Update, systemTime, dbContext.Tid, text);
			palletstored.CopyExtensionCollection(palletstored4Update);
			list.Add(palletstored4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeletePalletstored(IDbContext dbContext, Palletstored[] palletstoredList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("palletstoredList", palletstoredList);
		string text = "RealDeletePalletstored";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Palletstored> list = new List<Palletstored>();
		foreach (Palletstored palletstored in palletstoredList)
		{
			Palletstored palletstored4Update = GetPalletstored4Update(dbContext, palletstored.Palletstoredno, palletstored.Palletid, palletstored.Siteid);
			if (palletstored4Update == null)
			{
				throw new EntityNotFoundException(typeof(Palletstored), $"{palletstored.Palletstoredno},{palletstored.Palletid},{palletstored.Siteid}");
			}
			palletstored.CopyCommonFieldUpdatePrev(palletstored4Update, systemTime, dbContext.Tid, text);
			palletstored.CopyExtensionCollection(palletstored4Update);
			list.Add(palletstored4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
[Table("CUS_PALLETSTORED")]
public class Palletstored : EntityTemplate
{
	public override string TableName => "CUS_PALLETSTORED";

	public override string GroupName => "CUS_PALLETSTORED";

	public override string TableType => "MAIN";

	[Key]
	[Column("PALLETSTOREDNO")]
	[StringLength(40)]
	public string Palletstoredno { get; set; }

	[Key]
	[Column("PALLETID")]
	[StringLength(40)]
	public string Palletid { get; set; }

	[Key]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Column("PALLETSTOREDDATE")]
	[StringLength(40)]
	public DateTime Palletstoreddate { get; set; }

	[Column("PALLETSTOREDTYPE")]
	[StringLength(40)]
	public string Palletstoredtype { get; set; }

	[Column("DELIVERYORDERID")]
	[StringLength(40)]
	public string Deliveryorderid { get; set; }

	[Column("DELIVERYITEMNO")]
	[StringLength(40)]
	public string Deliveryitemno { get; set; }

	[Column("CUSTOMERID")]
	[StringLength(40)]
	public string Customerid { get; set; }

	[Column("MATERIALCLASSID")]
	[StringLength(40)]
	public string Materialclassid { get; set; }

	[Column("MATERIALDEFINITIONID")]
	[StringLength(40)]
	public string Materialdefinitionid { get; set; }

	[Column("PRODUCTTYPE")]
	[StringLength(40)]
	public string Producttype { get; set; }

	[Column("QTY")]
	[StringLength(40)]
	public decimal? Qty { get; set; }

	[Column("UNITID")]
	[StringLength(40)]
	public string Unitid { get; set; }

	[Column("FROMLOCATION")]
	[StringLength(40)]
	public string Fromlocation { get; set; }

	[Column("LOCATION")]
	[StringLength(40)]
	public string Location { get; set; }

	[Column("STATE")]
	[StringLength(40)]
	public string State { get; set; }

	[Column("SHIPPEDNO")]
	[StringLength(40)]
	public string Shippedno { get; set; }
}
