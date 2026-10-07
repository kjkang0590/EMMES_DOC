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
public class DEFECTPROCESSSEGMENTREL
{
	private static string _sqlGetDefectprocesssegmentrelSqlDatabase = "SELECT * FROM CUS_DEFECTPROCESSSEGMENTREL WHERE DEFECTID=@DEFECTID AND PROCESSSEGMENTID=@PROCESSSEGMENTID AND SITEID=@SITEID";

	private static string _sqlGetDefectprocesssegmentrel4UpdateSqlDatabase = "SELECT * FROM CUS_DEFECTPROCESSSEGMENTREL WITH(UPDLOCK) WHERE DEFECTID=@DEFECTID AND PROCESSSEGMENTID=@PROCESSSEGMENTID AND SITEID=@SITEID";

	private static string _sqlSelectDefectprocesssegmentrelSqlDatabase = "SELECT * FROM CUS_DEFECTPROCESSSEGMENTREL WHERE DEFECTID=@DEFECTID AND PROCESSSEGMENTID=@PROCESSSEGMENTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectDefectprocesssegmentrel4UpdateSqlDatabase = "SELECT * FROM CUS_DEFECTPROCESSSEGMENTREL WITH(UPDLOCK) WHERE DEFECTID=@DEFECTID AND PROCESSSEGMENTID=@PROCESSSEGMENTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetDefectprocesssegmentrelOracleDatabase = "SELECT * FROM CUS_DEFECTPROCESSSEGMENTREL WHERE DEFECTID=:DEFECTID AND PROCESSSEGMENTID=:PROCESSSEGMENTID AND SITEID=:SITEID";

	private static string _sqlGetDefectprocesssegmentrel4UpdateOracleDatabase = "SELECT * FROM CUS_DEFECTPROCESSSEGMENTREL WHERE DEFECTID=:DEFECTID AND PROCESSSEGMENTID=:PROCESSSEGMENTID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectDefectprocesssegmentrelOracleDatabase = "SELECT * FROM CUS_DEFECTPROCESSSEGMENTREL WHERE DEFECTID=:DEFECTID AND PROCESSSEGMENTID=:PROCESSSEGMENTID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectDefectprocesssegmentrel4UpdateOracleDatabase = "SELECT * FROM CUS_DEFECTPROCESSSEGMENTREL WHERE DEFECTID=:DEFECTID AND PROCESSSEGMENTID=:PROCESSSEGMENTID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Defectprocesssegmentrel);

	public static Defectprocesssegmentrel GetDefectprocesssegmentrel(IDbContext dbContext, string defectid, string processsegmentid, string siteid)
	{
		string apiName = "GetDefectprocesssegmentrel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{defectid},{processsegmentid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetDefectprocesssegmentrelSqlDatabase : _sqlGetDefectprocesssegmentrelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DEFECTID", defectid));
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid));
		list.Add(dbContext.CreateParameter("SITEID", siteid));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CUS_DEFECTPROCESSSEGMENTREL", $"{defectid},{processsegmentid},{siteid}"));
		}
		Defectprocesssegmentrel result = ContextManager.DirectEntityQuery<Defectprocesssegmentrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{defectid},{processsegmentid},{siteid}");
		}
		return result;
	}

	public static Defectprocesssegmentrel GetDefectprocesssegmentrel4Update(IDbContext dbContext, string defectid, string processsegmentid, string siteid)
	{
		string apiName = "GetDefectprocesssegmentrel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{defectid},{processsegmentid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetDefectprocesssegmentrel4UpdateSqlDatabase : _sqlGetDefectprocesssegmentrel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DEFECTID", defectid));
		list.Add(dbContext.CreateParameter("SITEID", siteid));
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CUS_DEFECTPROCESSSEGMENTREL", $"{defectid},{processsegmentid},{siteid}"));
		}
		Defectprocesssegmentrel result = ContextManager.DirectEntityQuery<Defectprocesssegmentrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{defectid},{processsegmentid},{siteid}");
		}
		return result;
	}

	public static Defectprocesssegmentrel SelectDefectprocesssegmentrel(IDbContext dbContext, string defectid, string processsegmentid, string siteid)
	{
		string apiName = "SelectDefectprocesssegmentrel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{defectid},{processsegmentid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectDefectprocesssegmentrelSqlDatabase : _sqlSelectDefectprocesssegmentrelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DEFECTID", defectid));
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid));
		list.Add(dbContext.CreateParameter("SITEID", siteid));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CUS_DEFECTPROCESSSEGMENTREL", $"{defectid},{processsegmentid},{siteid}"));
		}
		Defectprocesssegmentrel result = ContextManager.DirectEntityQuery<Defectprocesssegmentrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{defectid},{processsegmentid},{siteid}");
		}
		return result;
	}

	public static Defectprocesssegmentrel SelectDefectprocesssegmentrel4Update(IDbContext dbContext, string defectid, string processsegmentid, string siteid)
	{
		string apiName = "SelectDefectprocesssegmentrel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{defectid},{processsegmentid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectDefectprocesssegmentrel4UpdateSqlDatabase : _sqlSelectDefectprocesssegmentrel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DEFECTID", defectid));
		list.Add(dbContext.CreateParameter("PROCESSSEGMENTID", processsegmentid));
		list.Add(dbContext.CreateParameter("SITEID", siteid));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CUS_DEFECTPROCESSSEGMENTREL", $"{defectid},{processsegmentid},{siteid}"));
		}
		Defectprocesssegmentrel result = ContextManager.DirectEntityQuery<Defectprocesssegmentrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{defectid},{processsegmentid},{siteid}");
		}
		return result;
	}

	public static int UpsertDefectprocesssegmentrel(IDbContext dbContext, RequestType requestType, Defectprocesssegmentrel[] defectprocesssegmentrelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateDefectprocesssegmentrelInternal(dbContext, defectprocesssegmentrelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateDefectprocesssegmentrel(dbContext, defectprocesssegmentrelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteDefectprocesssegmentrel(dbContext, defectprocesssegmentrelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteDefectprocesssegmentrel(dbContext, defectprocesssegmentrelList, optionSet, saveHist), 
			_ => RealDeleteDefectprocesssegmentrel(dbContext, defectprocesssegmentrelList, optionSet, saveHist), 
		};
	}

	private static int CreateDefectprocesssegmentrelInternal(IDbContext dbContext, Defectprocesssegmentrel[] defectprocesssegmentrelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("defectprocesssegmentrelList", defectprocesssegmentrelList);
		string text = "CreateDefectprocesssegmentrel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Defectprocesssegmentrel> list = new List<Defectprocesssegmentrel>();
		foreach (Defectprocesssegmentrel defectprocesssegmentrel in defectprocesssegmentrelList)
		{
			Defectprocesssegmentrel defectprocesssegmentrel2 = new Defectprocesssegmentrel();
			defectprocesssegmentrel.CopyColumsTo(defectprocesssegmentrel2);
			defectprocesssegmentrel2.Activity = text;
			defectprocesssegmentrel2.CheckEntityUsable();
			defectprocesssegmentrel.CopyCommonField(defectprocesssegmentrel2, systemTime, dbContext.Tid, isCreate: true);
			list.Add(defectprocesssegmentrel2);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateDefectprocesssegmentrel(IDbContext dbContext, Defectprocesssegmentrel[] defectprocesssegmentrelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("defectprocesssegmentrelList", defectprocesssegmentrelList);
		string text = "UpdateDefectprocesssegmentrel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Defectprocesssegmentrel> list = new List<Defectprocesssegmentrel>();
		foreach (Defectprocesssegmentrel defectprocesssegmentrel in defectprocesssegmentrelList)
		{
			Defectprocesssegmentrel defectprocesssegmentrel4Update = GetDefectprocesssegmentrel4Update(dbContext, defectprocesssegmentrel.Defectid, defectprocesssegmentrel.Processsegmentid, defectprocesssegmentrel.Siteid);
			if (defectprocesssegmentrel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Defectprocesssegmentrel), $"{defectprocesssegmentrel.Defectid},{defectprocesssegmentrel.Processsegmentid},{defectprocesssegmentrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Defectprocesssegmentrel), $"{defectprocesssegmentrel.Defectid},{defectprocesssegmentrel.Processsegmentid},{defectprocesssegmentrel.Siteid}", defectprocesssegmentrel4Update.Isusable);
			string activity = defectprocesssegmentrel4Update.Activity;
			string customactivity = defectprocesssegmentrel4Update.Customactivity;
			string isusable = defectprocesssegmentrel4Update.Isusable;
			DateTime? createtime = defectprocesssegmentrel4Update.Createtime;
			string creator = defectprocesssegmentrel4Update.Creator;
			defectprocesssegmentrel.CopyColumsTo(defectprocesssegmentrel4Update);
			defectprocesssegmentrel4Update.Prevactivity = activity;
			defectprocesssegmentrel4Update.Prevcustomactivity = customactivity;
			defectprocesssegmentrel4Update.Creator = creator;
			defectprocesssegmentrel4Update.Createtime = createtime;
			defectprocesssegmentrel4Update.Isusable = isusable;
			defectprocesssegmentrel4Update.Activity = text;
			defectprocesssegmentrel.CopyCommonField(defectprocesssegmentrel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(defectprocesssegmentrel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteDefectprocesssegmentrel(IDbContext dbContext, Defectprocesssegmentrel[] defectprocesssegmentrelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("defectprocesssegmentrelList", defectprocesssegmentrelList);
		string text = "DeleteDefectprocesssegmentrel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Defectprocesssegmentrel> list = new List<Defectprocesssegmentrel>();
		foreach (Defectprocesssegmentrel defectprocesssegmentrel in defectprocesssegmentrelList)
		{
			Defectprocesssegmentrel defectprocesssegmentrel4Update = GetDefectprocesssegmentrel4Update(dbContext, defectprocesssegmentrel.Defectid, defectprocesssegmentrel.Processsegmentid, defectprocesssegmentrel.Siteid);
			if (defectprocesssegmentrel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Defectprocesssegmentrel), $"{defectprocesssegmentrel.Defectid},{defectprocesssegmentrel.Processsegmentid},{defectprocesssegmentrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Defectprocesssegmentrel), $"{defectprocesssegmentrel.Defectid},{defectprocesssegmentrel.Processsegmentid},{defectprocesssegmentrel.Siteid}", defectprocesssegmentrel4Update.Isusable);
			defectprocesssegmentrel4Update.Isusable = "UnUsable";
			defectprocesssegmentrel.CopyCommonFieldUpdatePrev(defectprocesssegmentrel4Update, systemTime, dbContext.Tid, text);
			defectprocesssegmentrel.CopyExtensionCollection(defectprocesssegmentrel4Update);
			list.Add(defectprocesssegmentrel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteDefectprocesssegmentrel(IDbContext dbContext, Defectprocesssegmentrel[] defectprocesssegmentrelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("defectprocesssegmentrelList", defectprocesssegmentrelList);
		string text = "UnDeleteDefectprocesssegmentrel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Defectprocesssegmentrel> list = new List<Defectprocesssegmentrel>();
		foreach (Defectprocesssegmentrel defectprocesssegmentrel in defectprocesssegmentrelList)
		{
			Defectprocesssegmentrel defectprocesssegmentrel4Update = GetDefectprocesssegmentrel4Update(dbContext, defectprocesssegmentrel.Defectid, defectprocesssegmentrel.Processsegmentid, defectprocesssegmentrel.Siteid);
			if (defectprocesssegmentrel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Defectprocesssegmentrel), $"{defectprocesssegmentrel.Defectid},{defectprocesssegmentrel.Processsegmentid},{defectprocesssegmentrel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Defectprocesssegmentrel), $"{defectprocesssegmentrel.Defectid},{defectprocesssegmentrel.Processsegmentid},{defectprocesssegmentrel.Siteid}", defectprocesssegmentrel4Update.Isusable);
			defectprocesssegmentrel4Update.Isusable = "Usable";
			defectprocesssegmentrel.CopyCommonFieldUpdatePrev(defectprocesssegmentrel4Update, systemTime, dbContext.Tid, text);
			defectprocesssegmentrel.CopyExtensionCollection(defectprocesssegmentrel4Update);
			list.Add(defectprocesssegmentrel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteDefectprocesssegmentrel(IDbContext dbContext, Defectprocesssegmentrel[] defectprocesssegmentrelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("defectprocesssegmentrelList", defectprocesssegmentrelList);
		string text = "RealDeleteDefectprocesssegmentrel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Defectprocesssegmentrel> list = new List<Defectprocesssegmentrel>();
		foreach (Defectprocesssegmentrel defectprocesssegmentrel in defectprocesssegmentrelList)
		{
			Defectprocesssegmentrel defectprocesssegmentrel4Update = GetDefectprocesssegmentrel4Update(dbContext, defectprocesssegmentrel.Defectid, defectprocesssegmentrel.Processsegmentid, defectprocesssegmentrel.Siteid);
			if (defectprocesssegmentrel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Defectprocesssegmentrel), $"{defectprocesssegmentrel.Defectid},{defectprocesssegmentrel.Processsegmentid},{defectprocesssegmentrel.Siteid}");
			}
			defectprocesssegmentrel.CopyCommonFieldUpdatePrev(defectprocesssegmentrel4Update, systemTime, dbContext.Tid, text);
			defectprocesssegmentrel.CopyExtensionCollection(defectprocesssegmentrel4Update);
			list.Add(defectprocesssegmentrel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
[Table("CUS_DEFECTPROCESSSEGMENTREL")]
public class Defectprocesssegmentrel : EntityTemplate
{
	public override string TableName => "CUS_DEFECTPROCESSSEGMENTREL";

	public override string GroupName => "CUS_DEFECTPROCESSSEGMENTREL";

	public override string TableType => "MAIN";

	[Key]
	[Column("PROCESSSEGMENTID")]
	[StringLength(40)]
	public string Processsegmentid { get; set; }

	[Key]
	[Column("DEFECTID")]
	[StringLength(40)]
	public string Defectid { get; set; }

	[Key]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }
}
