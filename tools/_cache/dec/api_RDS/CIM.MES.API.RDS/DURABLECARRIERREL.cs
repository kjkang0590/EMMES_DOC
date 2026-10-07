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
public class DURABLECARRIERREL
{
	private static string _sqlGetDurableCarrierRelSqlDatabase = "SELECT * FROM CIM_DURABLECARRIERREL WHERE DURABLEID=@DURABLEID AND CARRIERID=@CARRIERID AND SLOTPOSITION=@SLOTPOSITION AND SITEID=@SITEID";

	private static string _sqlGetDurableCarrierRel4UpdateSqlDatabase = "SELECT * FROM CIM_DURABLECARRIERREL WITH(UPDLOCK) WHERE DURABLEID=@DURABLEID AND CARRIERID=@CARRIERID AND SLOTPOSITION=@SLOTPOSITION AND SITEID=@SITEID";

	private static string _sqlSelectDurableCarrierRelSqlDatabase = "SELECT * FROM CIM_DURABLECARRIERREL WHERE DURABLEID=@DURABLEID AND CARRIERID=@CARRIERID AND SLOTPOSITION=@SLOTPOSITION AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectDurableCarrierRel4UpdateSqlDatabase = "SELECT * FROM CIM_DURABLECARRIERREL WITH(UPDLOCK) WHERE DURABLEID=@DURABLEID AND CARRIERID=@CARRIERID AND SLOTPOSITION=@SLOTPOSITION AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetDurableCarrierRelOracleDatabase = "SELECT * FROM CIM_DURABLECARRIERREL WHERE DURABLEID=:DURABLEID AND CARRIERID=:CARRIERID AND SLOTPOSITION=:SLOTPOSITION AND SITEID=:SITEID";

	private static string _sqlGetDurableCarrierRel4UpdateOracleDatabase = "SELECT * FROM CIM_DURABLECARRIERREL WHERE DURABLEID=:DURABLEID AND CARRIERID=:CARRIERID AND SLOTPOSITION=:SLOTPOSITION AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectDurableCarrierRelOracleDatabase = "SELECT * FROM CIM_DURABLECARRIERREL WHERE DURABLEID=:DURABLEID AND CARRIERID=:CARRIERID AND SLOTPOSITION=:SLOTPOSITION AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectDurableCarrierRel4UpdateOracleDatabase = "SELECT * FROM CIM_DURABLECARRIERREL WHERE DURABLEID=:DURABLEID AND CARRIERID=:CARRIERID AND SLOTPOSITION=:SLOTPOSITION AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Durablecarrierrel);

	public static Durablecarrierrel GetDurableCarrierRel(IDbContext dbContext, string durableid, string carrierid, int slotposition, string siteid)
	{
		string apiName = "GetDurableCarrierRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{durableid},{carrierid},{slotposition},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetDurableCarrierRelSqlDatabase : _sqlGetDurableCarrierRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DURABLEID", durableid, typeOfThis));
		list.Add(dbContext.CreateParameter("CARRIERID", carrierid, typeOfThis));
		list.Add(dbContext.CreateParameter("SLOTPOSITION", slotposition, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_DURABLECARRIERREL", $"{durableid},{carrierid},{slotposition},{siteid}"));
		}
		Durablecarrierrel result = ContextManager.DirectEntityQuery<Durablecarrierrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{durableid},{carrierid},{slotposition},{siteid}");
		}
		return result;
	}

	public static Durablecarrierrel GetDurableCarrierRel4Update(IDbContext dbContext, string durableid, string carrierid, decimal slotposition, string siteid)
	{
		string apiName = "GetDurableCarrierRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{durableid},{carrierid},{slotposition},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetDurableCarrierRel4UpdateSqlDatabase : _sqlGetDurableCarrierRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DURABLEID", durableid, typeOfThis));
		list.Add(dbContext.CreateParameter("CARRIERID", carrierid, typeOfThis));
		list.Add(dbContext.CreateParameter("SLOTPOSITION", slotposition, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_DURABLECARRIERREL", $"{durableid},{carrierid},{slotposition},{siteid}"));
		}
		Durablecarrierrel result = ContextManager.DirectEntityQuery<Durablecarrierrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{durableid},{carrierid},{slotposition},{siteid}");
		}
		return result;
	}

	public static Durablecarrierrel SelectDurableCarrierRel(IDbContext dbContext, string durableid, string carrierid, int slotposition, string siteid)
	{
		string apiName = "SelectDurableCarrierRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{durableid},{carrierid},{slotposition},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectDurableCarrierRelSqlDatabase : _sqlSelectDurableCarrierRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DURABLEID", durableid, typeOfThis));
		list.Add(dbContext.CreateParameter("CARRIERID", carrierid, typeOfThis));
		list.Add(dbContext.CreateParameter("SLOTPOSITION", slotposition, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_DURABLECARRIERREL", $"{durableid},{carrierid},{slotposition},{siteid}"));
		}
		Durablecarrierrel result = ContextManager.DirectEntityQuery<Durablecarrierrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{durableid},{carrierid},{slotposition},{siteid}");
		}
		return result;
	}

	public static Durablecarrierrel SelectDurableCarrierRel4Update(IDbContext dbContext, string durableid, string carrierid, int slotposition, string siteid)
	{
		string apiName = "SelectDurableCarrierRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{durableid},{carrierid},{slotposition},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectDurableCarrierRel4UpdateSqlDatabase : _sqlSelectDurableCarrierRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DURABLEID", durableid, typeOfThis));
		list.Add(dbContext.CreateParameter("CARRIERID", carrierid, typeOfThis));
		list.Add(dbContext.CreateParameter("SLOTPOSITION", slotposition, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_DURABLECARRIERREL", $"{durableid},{carrierid},{slotposition},{siteid}"));
		}
		Durablecarrierrel result = ContextManager.DirectEntityQuery<Durablecarrierrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{durableid},{carrierid},{slotposition},{siteid}");
		}
		return result;
	}

	public static int UpsertDurableCarrierRel(IDbContext dbContext, RequestType requestType, Durablecarrierrel[] durableCarrierRelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateDurableCarrierRelInternal(dbContext, durableCarrierRelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateDurableCarrierRel(dbContext, durableCarrierRelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteDurableCarrierRel(dbContext, durableCarrierRelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteDurableCarrierRel(dbContext, durableCarrierRelList, optionSet, saveHist), 
			_ => RealDeleteDurableCarrierRel(dbContext, durableCarrierRelList, optionSet, saveHist), 
		};
	}

	private static int CreateDurableCarrierRelInternal(IDbContext dbContext, Durablecarrierrel[] durableCarrierRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("durableCarrierRelList", durableCarrierRelList);
		string text = "CreateDurableCarrierRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Durablecarrierrel> list = new List<Durablecarrierrel>();
		foreach (Durablecarrierrel obj in durableCarrierRelList)
		{
			Durablecarrierrel durablecarrierrel = new Durablecarrierrel();
			obj.CopyColumsTo(durablecarrierrel);
			durablecarrierrel.Activity = text;
			durablecarrierrel.CheckEntityUsable();
			obj.CopyCommonField(durablecarrierrel, systemTime, dbContext.Tid, isCreate: true);
			list.Add(durablecarrierrel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateDurableCarrierRel(IDbContext dbContext, Durablecarrierrel[] durableCarrierRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("durableCarrierRelList", durableCarrierRelList);
		string text = "UpdateDurableCarrierRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Durablecarrierrel> list = new List<Durablecarrierrel>();
		foreach (Durablecarrierrel durablecarrierrel in durableCarrierRelList)
		{
			Durablecarrierrel durableCarrierRel4Update = GetDurableCarrierRel4Update(dbContext, durablecarrierrel.Durableid, durablecarrierrel.Carrierid, durablecarrierrel.Slotposition, durablecarrierrel.Siteid);
			if (durableCarrierRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Durablecarrierrel), $"{durablecarrierrel.Durableid},{durablecarrierrel.Carrierid},{durablecarrierrel.Slotposition},{durablecarrierrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Durablecarrierrel), $"{durablecarrierrel.Durableid},{durablecarrierrel.Carrierid},{durablecarrierrel.Slotposition},{durablecarrierrel.Siteid}", durableCarrierRel4Update.Isusable);
			string activity = durableCarrierRel4Update.Activity;
			string customactivity = durableCarrierRel4Update.Customactivity;
			string isusable = durableCarrierRel4Update.Isusable;
			DateTime? createtime = durableCarrierRel4Update.Createtime;
			string creator = durableCarrierRel4Update.Creator;
			durablecarrierrel.CopyColumsTo(durableCarrierRel4Update);
			durableCarrierRel4Update.Prevactivity = activity;
			durableCarrierRel4Update.Prevcustomactivity = customactivity;
			durableCarrierRel4Update.Creator = creator;
			durableCarrierRel4Update.Createtime = createtime;
			durableCarrierRel4Update.Isusable = isusable;
			durableCarrierRel4Update.Activity = text;
			durablecarrierrel.CopyCommonField(durableCarrierRel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(durableCarrierRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteDurableCarrierRel(IDbContext dbContext, Durablecarrierrel[] durableCarrierRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("durableCarrierRelList", durableCarrierRelList);
		string text = "DeleteDurableCarrierRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Durablecarrierrel> list = new List<Durablecarrierrel>();
		foreach (Durablecarrierrel durablecarrierrel in durableCarrierRelList)
		{
			Durablecarrierrel durableCarrierRel4Update = GetDurableCarrierRel4Update(dbContext, durablecarrierrel.Durableid, durablecarrierrel.Carrierid, durablecarrierrel.Slotposition, durablecarrierrel.Siteid);
			if (durableCarrierRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Durablecarrierrel), $"{durablecarrierrel.Durableid},{durablecarrierrel.Carrierid},{durablecarrierrel.Slotposition},{durablecarrierrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Durablecarrierrel), $"{durablecarrierrel.Durableid},{durablecarrierrel.Carrierid},{durablecarrierrel.Slotposition},{durablecarrierrel.Siteid}", durableCarrierRel4Update.Isusable);
			durableCarrierRel4Update.Isusable = "UnUsable";
			durablecarrierrel.CopyCommonFieldUpdatePrev(durableCarrierRel4Update, systemTime, dbContext.Tid, text);
			durablecarrierrel.CopyExtensionCollection(durableCarrierRel4Update);
			list.Add(durableCarrierRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteDurableCarrierRel(IDbContext dbContext, Durablecarrierrel[] durableCarrierRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("durableCarrierRelList", durableCarrierRelList);
		string text = "UnDeleteDurableCarrierRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Durablecarrierrel> list = new List<Durablecarrierrel>();
		foreach (Durablecarrierrel durablecarrierrel in durableCarrierRelList)
		{
			Durablecarrierrel durableCarrierRel4Update = GetDurableCarrierRel4Update(dbContext, durablecarrierrel.Durableid, durablecarrierrel.Carrierid, durablecarrierrel.Slotposition, durablecarrierrel.Siteid);
			if (durableCarrierRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Durablecarrierrel), $"{durablecarrierrel.Durableid},{durablecarrierrel.Carrierid},{durablecarrierrel.Slotposition},{durablecarrierrel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Durablecarrierrel), $"{durablecarrierrel.Durableid},{durablecarrierrel.Carrierid},{durablecarrierrel.Slotposition},{durablecarrierrel.Siteid}", durableCarrierRel4Update.Isusable);
			durableCarrierRel4Update.Isusable = "Usable";
			durablecarrierrel.CopyCommonFieldUpdatePrev(durableCarrierRel4Update, systemTime, dbContext.Tid, text);
			durablecarrierrel.CopyExtensionCollection(durableCarrierRel4Update);
			list.Add(durableCarrierRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteDurableCarrierRel(IDbContext dbContext, Durablecarrierrel[] durableCarrierRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("durableCarrierRelList", durableCarrierRelList);
		string text = "RealDeleteDurableCarrierRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Durablecarrierrel> list = new List<Durablecarrierrel>();
		foreach (Durablecarrierrel durablecarrierrel in durableCarrierRelList)
		{
			Durablecarrierrel durableCarrierRel4Update = GetDurableCarrierRel4Update(dbContext, durablecarrierrel.Durableid, durablecarrierrel.Carrierid, durablecarrierrel.Slotposition, durablecarrierrel.Siteid);
			if (durableCarrierRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Durablecarrierrel), $"{durablecarrierrel.Durableid},{durablecarrierrel.Carrierid},{durablecarrierrel.Slotposition},{durablecarrierrel.Siteid}");
			}
			durablecarrierrel.CopyCommonFieldUpdatePrev(durableCarrierRel4Update, systemTime, dbContext.Tid, text);
			durablecarrierrel.CopyExtensionCollection(durableCarrierRel4Update);
			list.Add(durableCarrierRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
