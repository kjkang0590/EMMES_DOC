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
public class PALLETLOT
{
	private static string _sqlGetPalletlotSqlDatabase = "SELECT * FROM CUS_PALLETLOT WHERE PALLETLOTID=@PALLETLOTID AND SITEID=@SITEID";

	private static string _sqlGetPalletlot4UpdateSqlDatabase = "SELECT * FROM CUS_PALLETLOT WITH(UPDLOCK) WHERE PALLETLOTID=@PALLETLOTID AND SITEID=@SITEID";

	private static string _sqlSelectPalletlotSqlDatabase = "SELECT * FROM CUS_PALLETLOT WHERE PALLETLOTID=@PALLETLOTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectPalletlot4UpdateSqlDatabase = "SELECT * FROM CUS_PALLETLOT WITH(UPDLOCK) WHERE PALLETLOTID=@PALLETLOTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetPalletlotOracleDatabase = "SELECT * FROM CUS_PALLETLOT WHERE PALLETLOTID=:PALLETLOTID AND SITEID=:SITEID";

	private static string _sqlGetPalletlot4UpdateOracleDatabase = "SELECT * FROM CUS_PALLETLOT WHERE PALLETLOTID=:PALLETLOTID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectPalletlotOracleDatabase = "SELECT * FROM CUS_PALLETLOT WHERE PALLETLOTID=:PALLETLOTID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectPalletlot4UpdateOracleDatabase = "SELECT * FROM CUS_PALLETLOT WHERE PALLETLOTID=:PALLETLOTID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Palletstored);

	public static Palletlot GetPalletlot(IDbContext dbContext, string palletlotid, string siteid)
	{
		string apiName = "GetPalletlot";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), string.Format("{0},{1},{2}", palletlotid, siteid));
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetPalletlotSqlDatabase : _sqlGetPalletlotOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PALLETLOTID", palletlotid));
		list.Add(dbContext.CreateParameter("SITEID", siteid));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CUS_PALLETLOT", $"{palletlotid},{siteid}"));
		}
		Palletlot result = ContextManager.DirectEntityQuery<Palletlot>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{palletlotid},{siteid}");
		}
		return result;
	}

	public static Palletlot GetPalletlot4Update(IDbContext dbContext, string palletlotid, string siteid)
	{
		string apiName = "GetPalletlot4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{palletlotid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetPalletlot4UpdateSqlDatabase : _sqlGetPalletlot4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PALLETLOTID", palletlotid));
		list.Add(dbContext.CreateParameter("SITEID", siteid));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CUS_PALLETLOT", $"{palletlotid},{siteid}"));
		}
		Palletlot result = ContextManager.DirectEntityQuery<Palletlot>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{palletlotid},{siteid}");
		}
		return result;
	}

	public static Palletlot SelectPalletlot(IDbContext dbContext, string palletlotid, string siteid)
	{
		string apiName = "SelectPalletlot";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{palletlotid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectPalletlotSqlDatabase : _sqlSelectPalletlotOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PALLETLOTID", palletlotid));
		list.Add(dbContext.CreateParameter("SITEID", siteid));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CUS_PALLETLOT", $"{palletlotid},{siteid}"));
		}
		Palletlot result = ContextManager.DirectEntityQuery<Palletlot>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{palletlotid},{siteid}");
		}
		return result;
	}

	public static Palletlot SelectPalletlot4Update(IDbContext dbContext, string palletlotid, string siteid)
	{
		string apiName = "SelectPalletlot4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{palletlotid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectPalletlot4UpdateSqlDatabase : _sqlSelectPalletlot4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PALLETLOTID", palletlotid));
		list.Add(dbContext.CreateParameter("SITEID", siteid));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CUS_PALLETLOT", $"{palletlotid},{siteid}"));
		}
		Palletlot result = ContextManager.DirectEntityQuery<Palletlot>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{palletlotid},{siteid}");
		}
		return result;
	}

	public static int UpsertPalletlot(IDbContext dbContext, RequestType requestType, Palletlot[] palletlotList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreatePalletlotInternal(dbContext, palletlotList, optionSet, saveHist), 
			RequestType.UPDATE => UpdatePalletlot(dbContext, palletlotList, optionSet, saveHist), 
			RequestType.DELETE => DeletePalletlot(dbContext, palletlotList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeletePalletlot(dbContext, palletlotList, optionSet, saveHist), 
			_ => RealDeletePalletstored(dbContext, palletlotList, optionSet, saveHist), 
		};
	}

	private static int CreatePalletlotInternal(IDbContext dbContext, Palletlot[] palletlotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("palletlotList", palletlotList);
		string text = "CreatePalletlot";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Palletlot> list = new List<Palletlot>();
		foreach (Palletlot palletlot in palletlotList)
		{
			Palletlot palletlot2 = new Palletlot();
			palletlot.CopyColumsTo(palletlot2);
			palletlot2.Activity = text;
			palletlot2.CheckEntityUsable();
			palletlot.CopyCommonField(palletlot2, systemTime, dbContext.Tid, isCreate: true);
			list.Add(palletlot2);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdatePalletlot(IDbContext dbContext, Palletlot[] palletlotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("palletlotList", palletlotList);
		string text = "UpdatePalletlot";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Palletlot> list = new List<Palletlot>();
		foreach (Palletlot palletlot in palletlotList)
		{
			Palletlot palletlot4Update = GetPalletlot4Update(dbContext, palletlot.Palletlotid, palletlot.Siteid);
			if (palletlot4Update == null)
			{
				throw new EntityNotFoundException(typeof(Palletlot), $"{palletlot.Palletlotid},{palletlot.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Palletlot), $"{palletlot.Palletlotid},{palletlot.Siteid}", palletlot4Update.Isusable);
			string activity = palletlot4Update.Activity;
			string customactivity = palletlot4Update.Customactivity;
			string isusable = palletlot4Update.Isusable;
			DateTime? createtime = palletlot4Update.Createtime;
			string creator = palletlot4Update.Creator;
			palletlot.CopyColumsTo(palletlot4Update);
			palletlot4Update.Prevactivity = activity;
			palletlot4Update.Prevcustomactivity = customactivity;
			palletlot4Update.Creator = creator;
			palletlot4Update.Createtime = createtime;
			palletlot4Update.Isusable = isusable;
			palletlot4Update.Activity = text;
			palletlot.CopyCommonField(palletlot4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(palletlot4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeletePalletlot(IDbContext dbContext, Palletlot[] palletlotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("palletlotList", palletlotList);
		string text = "DeletePalletlot";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Palletlot> list = new List<Palletlot>();
		foreach (Palletlot palletlot in palletlotList)
		{
			Palletlot palletlot4Update = GetPalletlot4Update(dbContext, palletlot.Palletlotid, palletlot.Siteid);
			if (palletlot4Update == null)
			{
				throw new EntityNotFoundException(typeof(Palletlot), $"{palletlot.Palletlotid},{palletlot.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Palletlot), $"{palletlot.Palletlotid},{palletlot.Siteid}", palletlot4Update.Isusable);
			palletlot4Update.Isusable = "UnUsable";
			palletlot.CopyCommonFieldUpdatePrev(palletlot4Update, systemTime, dbContext.Tid, text);
			palletlot.CopyExtensionCollection(palletlot4Update);
			list.Add(palletlot4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeletePalletlot(IDbContext dbContext, Palletlot[] palletlotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("palletlotList", palletlotList);
		string text = "UnDeletePalletlot";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Palletlot> list = new List<Palletlot>();
		foreach (Palletlot palletlot in palletlotList)
		{
			Palletlot palletlot4Update = GetPalletlot4Update(dbContext, palletlot.Palletlotid, palletlot.Siteid);
			if (palletlot4Update == null)
			{
				throw new EntityNotFoundException(typeof(Palletlot), $"{palletlot.Palletlotid},{palletlot.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Palletlot), $"{palletlot.Palletlotid},{palletlot.Siteid}", palletlot4Update.Isusable);
			palletlot4Update.Isusable = "Usable";
			palletlot.CopyCommonFieldUpdatePrev(palletlot4Update, systemTime, dbContext.Tid, text);
			palletlot.CopyExtensionCollection(palletlot4Update);
			list.Add(palletlot4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeletePalletstored(IDbContext dbContext, Palletlot[] palletlotList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("palletlotList", palletlotList);
		string text = "RealDeletePalletlot";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Palletlot> list = new List<Palletlot>();
		foreach (Palletlot palletlot in palletlotList)
		{
			Palletlot palletlot4Update = GetPalletlot4Update(dbContext, palletlot.Palletlotid, palletlot.Siteid);
			if (palletlot4Update == null)
			{
				throw new EntityNotFoundException(typeof(Palletlot), $"{palletlot.Palletlotid},{palletlot.Siteid}");
			}
			palletlot.CopyCommonFieldUpdatePrev(palletlot4Update, systemTime, dbContext.Tid, text);
			palletlot.CopyExtensionCollection(palletlot4Update);
			list.Add(palletlot4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
[Table("CUS_PALLETLOT")]
public class Palletlot : EntityTemplate
{
	public override string TableName => "CUS_PALLETLOT";

	public override string GroupName => "CUS_PALLETLOT";

	public override string TableType => "MAIN";

	[Key]
	[Column("PALLETLOTID")]
	[StringLength(40)]
	public string Palletlotid { get; set; }

	[Key]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Column("PALLETLOTNAME")]
	[StringLength(40)]
	public string Palletlotname { get; set; }

	[Column("MATERIALCLASSID")]
	[StringLength(40)]
	public string Materialclassid { get; set; }

	[Column("MATERIALDEFINITIONID")]
	[StringLength(40)]
	public string Materialdefinitionid { get; set; }

	[Column("MATERIALTYPE")]
	[StringLength(40)]
	public string Materialtype { get; set; }

	[Column("STATE")]
	[StringLength(40)]
	public string State { get; set; }

	[Column("ORIGINALQTY")]
	public decimal? Originalqty { get; set; }

	[Column("QTY")]
	public decimal? Qty { get; set; }

	[Column("LOSSQTY")]
	public decimal? Lossqty { get; set; }

	[Column("UNITID")]
	[StringLength(40)]
	public string Unitid { get; set; }

	[Column("LOCATION")]
	[StringLength(40)]
	public string Location { get; set; }

	[Column("DELIVERYORDERID")]
	[StringLength(40)]
	public string Deliveryorderid { get; set; }

	[Column("PRODUCTORDERID")]
	[StringLength(40)]
	public string Productorderid { get; set; }

	[Column("WORKORDERID")]
	[StringLength(40)]
	public string Workorderid { get; set; }

	[Column("CUSTOMERID")]
	[StringLength(40)]
	public string Customerid { get; set; }

	[Column("MOVETIME")]
	public DateTime? Movetime { get; set; }

	[Column("RECEIVEDTIME")]
	public DateTime? Receivedtime { get; set; }

	[Column("PREVSTATE")]
	[StringLength(40)]
	public string Prevstate { get; set; }

	[Column("PREVQTY")]
	public decimal? Prevqty { get; set; }

	[Column("PREVLOCATION")]
	[StringLength(40)]
	public string Prevlocation { get; set; }

	[Column("HISTORYFLAG")]
	[StringLength(1)]
	public string Historyflag { get; set; }

	[Column("STOCKDATE")]
	public DateTime? Stockdate { get; set; }

	[Column("GRADEID")]
	[StringLength(40)]
	public string Gradeid { get; set; }

	[Column("PALLETSTOREDNO")]
	[StringLength(40)]
	public string Palletstoredno { get; set; }

	[Column("PALLETSTOREDTYPE")]
	[StringLength(40)]
	public string Palletstoredtype { get; set; }

	[Column("GRADETYPE")]
	[StringLength(40)]
	public string Gradetype { get; set; }

	[Column("DELIVERYITEMNO")]
	[StringLength(40)]
	public string Deliveryitemno { get; set; }

	[Column("SHIPPEDNO")]
	[StringLength(40)]
	public string Shippedno { get; set; }
}
