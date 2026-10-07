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
public class RESOURCEVENDORREL
{
	private static string _sqlGetResourceVendorRelSqlDatabase = "SELECT * FROM CIM_RESOURCEVENDORREL WHERE RESOURCEID=@RESOURCEID AND VENDORID=@VENDORID AND SITEID=@SITEID";

	private static string _sqlGetResourceVendorRel4UpdateSqlDatabase = "SELECT * FROM CIM_RESOURCEVENDORREL WITH(UPDLOCK) WHERE RESOURCEID=@RESOURCEID AND VENDORID=@VENDORID AND SITEID=@SITEID";

	private static string _sqlSelectResourceVendorRelSqlDatabase = "SELECT * FROM CIM_RESOURCEVENDORREL WHERE RESOURCEID=@RESOURCEID AND VENDORID=@VENDORID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectResourceVendorRel4UpdateSqlDatabase = "SELECT * FROM CIM_RESOURCEVENDORREL WITH(UPDLOCK) WHERE RESOURCEID=@RESOURCEID AND VENDORID=@VENDORID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetResourceVendorRelOracleDatabase = "SELECT * FROM CIM_RESOURCEVENDORREL WHERE RESOURCEID=:RESOURCEID AND VENDORID=:VENDORID AND SITEID=:SITEID";

	private static string _sqlGetResourceVendorRel4UpdateOracleDatabase = "SELECT * FROM CIM_RESOURCEVENDORREL WHERE RESOURCEID=:RESOURCEID AND VENDORID=:VENDORID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectResourceVendorRelOracleDatabase = "SELECT * FROM CIM_RESOURCEVENDORREL WHERE RESOURCEID=:RESOURCEID AND VENDORID=:VENDORID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectResourceVendorRel4UpdateOracleDatabase = "SELECT * FROM CIM_RESOURCEVENDORREL WHERE RESOURCEID=:RESOURCEID AND VENDORID=:VENDORID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Resourcevendorrel);

	public static Resourcevendorrel GetResourceVendorRel(IDbContext dbContext, string resourceid, string vendorid, string siteid)
	{
		string apiName = "GetResourceVendorRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{resourceid},{vendorid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetResourceVendorRelSqlDatabase : _sqlGetResourceVendorRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RESOURCEID", resourceid, typeOfThis));
		list.Add(dbContext.CreateParameter("VENDORID", vendorid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_RESOURCEVENDORREL", $"{resourceid},{vendorid},{siteid}"));
		}
		Resourcevendorrel? result = ContextManager.DirectEntityQuery<Resourcevendorrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{resourceid},{vendorid},{siteid}");
		}
		return result;
	}

	public static Resourcevendorrel GetResourceVendorRel4Update(IDbContext dbContext, string resourceid, string vendorid, string siteid)
	{
		string apiName = "GetResourceVendorRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{resourceid},{vendorid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetResourceVendorRel4UpdateSqlDatabase : _sqlGetResourceVendorRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RESOURCEID", resourceid, typeOfThis));
		list.Add(dbContext.CreateParameter("VENDORID", vendorid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_RESOURCEVENDORREL", $"{resourceid},{vendorid},{siteid}"));
		}
		Resourcevendorrel? result = ContextManager.DirectEntityQuery<Resourcevendorrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{resourceid},{vendorid},{siteid}");
		}
		return result;
	}

	public static Resourcevendorrel SelectResourceVendorRel(IDbContext dbContext, string resourceid, string vendorid, string siteid)
	{
		string apiName = "SelectResourceVendorRel";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{resourceid},{vendorid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectResourceVendorRelSqlDatabase : _sqlSelectResourceVendorRelOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RESOURCEID", resourceid, typeOfThis));
		list.Add(dbContext.CreateParameter("VENDORID", vendorid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_RESOURCEVENDORREL", $"{resourceid},{vendorid},{siteid}"));
		}
		Resourcevendorrel? result = ContextManager.DirectEntityQuery<Resourcevendorrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{resourceid},{vendorid},{siteid}");
		}
		return result;
	}

	public static Resourcevendorrel SelectResourceVendorRel4Update(IDbContext dbContext, string resourceid, string vendorid, string siteid)
	{
		string apiName = "SelectResourceVendorRel4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{resourceid},{vendorid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectResourceVendorRel4UpdateSqlDatabase : _sqlSelectResourceVendorRel4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("RESOURCEID", resourceid, typeOfThis));
		list.Add(dbContext.CreateParameter("VENDORID", vendorid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_RESOURCEVENDORREL", $"{resourceid},{vendorid},{siteid}"));
		}
		Resourcevendorrel? result = ContextManager.DirectEntityQuery<Resourcevendorrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{resourceid},{vendorid},{siteid}");
		}
		return result;
	}

	public static int UpsertResourceVendorRel(IDbContext dbContext, RequestType requestType, Resourcevendorrel[] resourceVendorRelList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateResourceVendorRelInternal(dbContext, resourceVendorRelList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateResourceVendorRel(dbContext, resourceVendorRelList, optionSet, saveHist), 
			RequestType.DELETE => DeleteResourceVendorRel(dbContext, resourceVendorRelList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteResourceVendorRel(dbContext, resourceVendorRelList, optionSet, saveHist), 
			_ => RealDeleteResourceVendorRel(dbContext, resourceVendorRelList, optionSet, saveHist), 
		};
	}

	private static int CreateResourceVendorRelInternal(IDbContext dbContext, Resourcevendorrel[] resourceVendorRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("resourceVendorRelList", resourceVendorRelList);
		string text = "CreateResourceVendorRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Resourcevendorrel> list = new List<Resourcevendorrel>();
		foreach (Resourcevendorrel obj in resourceVendorRelList)
		{
			Resourcevendorrel resourcevendorrel = new Resourcevendorrel();
			obj.CopyColumsTo(resourcevendorrel);
			resourcevendorrel.Activity = text;
			resourcevendorrel.CheckEntityUsable();
			obj.CopyCommonField(resourcevendorrel, systemTime, dbContext.Tid, isCreate: true);
			list.Add(resourcevendorrel);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateResourceVendorRel(IDbContext dbContext, Resourcevendorrel[] resourceVendorRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("resourceVendorRelList", resourceVendorRelList);
		string text = "UpdateResourceVendorRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Resourcevendorrel> list = new List<Resourcevendorrel>();
		foreach (Resourcevendorrel resourcevendorrel in resourceVendorRelList)
		{
			Resourcevendorrel resourceVendorRel4Update = GetResourceVendorRel4Update(dbContext, resourcevendorrel.Resourceid, resourcevendorrel.Vendorid, resourcevendorrel.Siteid);
			if (resourceVendorRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Resourcevendorrel), $"{resourcevendorrel.Resourceid},{resourcevendorrel.Vendorid},{resourcevendorrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Resourcevendorrel), $"{resourcevendorrel.Resourceid},{resourcevendorrel.Vendorid},{resourcevendorrel.Siteid}", resourceVendorRel4Update.Isusable);
			string activity = resourceVendorRel4Update.Activity;
			string customactivity = resourceVendorRel4Update.Customactivity;
			string isusable = resourceVendorRel4Update.Isusable;
			DateTime? createtime = resourceVendorRel4Update.Createtime;
			string creator = resourceVendorRel4Update.Creator;
			resourcevendorrel.CopyColumsTo(resourceVendorRel4Update);
			resourceVendorRel4Update.Prevactivity = activity;
			resourceVendorRel4Update.Prevcustomactivity = customactivity;
			resourceVendorRel4Update.Creator = creator;
			resourceVendorRel4Update.Createtime = createtime;
			resourceVendorRel4Update.Isusable = isusable;
			resourceVendorRel4Update.Activity = text;
			resourcevendorrel.CopyCommonField(resourceVendorRel4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(resourceVendorRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteResourceVendorRel(IDbContext dbContext, Resourcevendorrel[] resourceVendorRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("resourceVendorRelList", resourceVendorRelList);
		string text = "DeleteResourceVendorRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Resourcevendorrel> list = new List<Resourcevendorrel>();
		foreach (Resourcevendorrel resourcevendorrel in resourceVendorRelList)
		{
			Resourcevendorrel resourceVendorRel4Update = GetResourceVendorRel4Update(dbContext, resourcevendorrel.Resourceid, resourcevendorrel.Vendorid, resourcevendorrel.Siteid);
			if (resourceVendorRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Resourcevendorrel), $"{resourcevendorrel.Resourceid},{resourcevendorrel.Vendorid},{resourcevendorrel.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Resourcevendorrel), $"{resourcevendorrel.Resourceid},{resourcevendorrel.Vendorid},{resourcevendorrel.Siteid}", resourceVendorRel4Update.Isusable);
			resourceVendorRel4Update.Isusable = "UnUsable";
			resourcevendorrel.CopyCommonFieldUpdatePrev(resourceVendorRel4Update, systemTime, dbContext.Tid, text);
			resourcevendorrel.CopyExtensionCollection(resourceVendorRel4Update);
			list.Add(resourceVendorRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteResourceVendorRel(IDbContext dbContext, Resourcevendorrel[] resourceVendorRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("resourceVendorRelList", resourceVendorRelList);
		string text = "UnDeleteResourceVendorRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Resourcevendorrel> list = new List<Resourcevendorrel>();
		foreach (Resourcevendorrel resourcevendorrel in resourceVendorRelList)
		{
			Resourcevendorrel resourceVendorRel4Update = GetResourceVendorRel4Update(dbContext, resourcevendorrel.Resourceid, resourcevendorrel.Vendorid, resourcevendorrel.Siteid);
			if (resourceVendorRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Resourcevendorrel), $"{resourcevendorrel.Resourceid},{resourcevendorrel.Vendorid},{resourcevendorrel.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Resourcevendorrel), $"{resourcevendorrel.Resourceid},{resourcevendorrel.Vendorid},{resourcevendorrel.Siteid}", resourceVendorRel4Update.Isusable);
			resourceVendorRel4Update.Isusable = "Usable";
			resourcevendorrel.CopyCommonFieldUpdatePrev(resourceVendorRel4Update, systemTime, dbContext.Tid, text);
			resourcevendorrel.CopyExtensionCollection(resourceVendorRel4Update);
			list.Add(resourceVendorRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteResourceVendorRel(IDbContext dbContext, Resourcevendorrel[] resourceVendorRelList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("resourceVendorRelList", resourceVendorRelList);
		string text = "RealDeleteResourceVendorRel";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Resourcevendorrel> list = new List<Resourcevendorrel>();
		foreach (Resourcevendorrel resourcevendorrel in resourceVendorRelList)
		{
			Resourcevendorrel resourceVendorRel4Update = GetResourceVendorRel4Update(dbContext, resourcevendorrel.Resourceid, resourcevendorrel.Vendorid, resourcevendorrel.Siteid);
			if (resourceVendorRel4Update == null)
			{
				throw new EntityNotFoundException(typeof(Resourcevendorrel), $"{resourcevendorrel.Resourceid},{resourcevendorrel.Vendorid},{resourcevendorrel.Siteid}");
			}
			resourcevendorrel.CopyCommonFieldUpdatePrev(resourceVendorRel4Update, systemTime, dbContext.Tid, text);
			resourcevendorrel.CopyExtensionCollection(resourceVendorRel4Update);
			list.Add(resourceVendorRel4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
