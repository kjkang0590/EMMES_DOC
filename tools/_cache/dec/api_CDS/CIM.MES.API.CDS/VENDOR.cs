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
public class VENDOR
{
	private static string _sqlGetVendorSqlDatabase = "SELECT * FROM CIM_VENDOR WHERE VENDORID=@VENDORID AND SITEID=@SITEID";

	private static string _sqlGetVendor4UpdateSqlDatabase = "SELECT * FROM CIM_VENDOR WITH(UPDLOCK) WHERE VENDORID=@VENDORID AND SITEID=@SITEID";

	private static string _sqlSelectVendorSqlDatabase = "SELECT * FROM CIM_VENDOR WHERE VENDORID=@VENDORID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectVendor4UpdateSqlDatabase = "SELECT * FROM CIM_VENDOR WITH(UPDLOCK) WHERE VENDORID=@VENDORID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetVendorOracleDatabase = "SELECT * FROM CIM_VENDOR WHERE VENDORID=:VENDORID AND SITEID=:SITEID";

	private static string _sqlGetVendor4UpdateOracleDatabase = "SELECT * FROM CIM_VENDOR WHERE VENDORID=:VENDORID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectVendorOracleDatabase = "SELECT * FROM CIM_VENDOR WHERE VENDORID=:VENDORID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectVendor4UpdateOracleDatabase = "SELECT * FROM CIM_VENDOR WHERE VENDORID=:VENDORID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Vendor);

	public static Vendor GetVendor(IDbContext dbContext, string vendorid, string siteid)
	{
		string apiName = "GetVendor";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{vendorid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetVendorSqlDatabase : _sqlGetVendorOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("VENDORID", vendorid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_VENDOR", $"{vendorid},{siteid}"));
		}
		Vendor? result = ContextManager.DirectEntityQuery<Vendor>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{vendorid},{siteid}");
		}
		return result;
	}

	public static Vendor GetVendor4Update(IDbContext dbContext, string vendorid, string siteid)
	{
		string apiName = "GetVendor4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{vendorid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetVendor4UpdateSqlDatabase : _sqlGetVendor4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("VENDORID", vendorid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_VENDOR", $"{vendorid},{siteid}"));
		}
		Vendor? result = ContextManager.DirectEntityQuery<Vendor>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{vendorid},{siteid}");
		}
		return result;
	}

	public static Vendor SelectVendor(IDbContext dbContext, string vendorid, string siteid)
	{
		string apiName = "SelectVendor";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{vendorid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectVendorSqlDatabase : _sqlSelectVendorOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("VENDORID", vendorid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_VENDOR", $"{vendorid},{siteid}"));
		}
		Vendor? result = ContextManager.DirectEntityQuery<Vendor>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{vendorid},{siteid}");
		}
		return result;
	}

	public static Vendor SelectVendor4Update(IDbContext dbContext, string vendorid, string siteid)
	{
		string apiName = "SelectVendor4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{vendorid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectVendor4UpdateSqlDatabase : _sqlSelectVendor4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("VENDORID", vendorid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_VENDOR", $"{vendorid},{siteid}"));
		}
		Vendor? result = ContextManager.DirectEntityQuery<Vendor>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{vendorid},{siteid}");
		}
		return result;
	}

	public static int UpsertVendor(IDbContext dbContext, RequestType requestType, Vendor[] vendorList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateVendorInternal(dbContext, vendorList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateVendor(dbContext, vendorList, optionSet, saveHist), 
			RequestType.DELETE => DeleteVendor(dbContext, vendorList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteVendor(dbContext, vendorList, optionSet, saveHist), 
			_ => RealDeleteVendor(dbContext, vendorList, optionSet, saveHist), 
		};
	}

	private static int CreateVendorInternal(IDbContext dbContext, Vendor[] vendorList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("vendorList", vendorList);
		string text = "CreateVendor";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Vendor> list = new List<Vendor>();
		foreach (Vendor obj in vendorList)
		{
			Vendor vendor = new Vendor();
			obj.CopyColumsTo(vendor);
			vendor.Activity = text;
			vendor.CheckEntityUsable();
			obj.CopyCommonField(vendor, systemTime, dbContext.Tid, isCreate: true);
			list.Add(vendor);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateVendor(IDbContext dbContext, Vendor[] vendorList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("vendorList", vendorList);
		string text = "UpdateVendor";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Vendor> list = new List<Vendor>();
		foreach (Vendor vendor in vendorList)
		{
			Vendor vendor4Update = GetVendor4Update(dbContext, vendor.Vendorid, vendor.Siteid);
			if (vendor4Update == null)
			{
				throw new EntityNotFoundException(typeof(Vendor), $"{vendor.Vendorid},{vendor.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Vendor), $"{vendor.Vendorid},{vendor.Siteid}", vendor4Update.Isusable);
			string activity = vendor4Update.Activity;
			string customactivity = vendor4Update.Customactivity;
			string isusable = vendor4Update.Isusable;
			DateTime? createtime = vendor4Update.Createtime;
			string creator = vendor4Update.Creator;
			vendor.CopyColumsTo(vendor4Update);
			vendor4Update.Prevactivity = activity;
			vendor4Update.Prevcustomactivity = customactivity;
			vendor4Update.Creator = creator;
			vendor4Update.Createtime = createtime;
			vendor4Update.Isusable = isusable;
			vendor4Update.Activity = text;
			vendor.CopyCommonField(vendor4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(vendor4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteVendor(IDbContext dbContext, Vendor[] vendorList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("vendorList", vendorList);
		string text = "DeleteVendor";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Vendor> list = new List<Vendor>();
		foreach (Vendor vendor in vendorList)
		{
			Vendor vendor4Update = GetVendor4Update(dbContext, vendor.Vendorid, vendor.Siteid);
			if (vendor4Update == null)
			{
				throw new EntityNotFoundException(typeof(Vendor), $"{vendor.Vendorid},{vendor.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Vendor), $"{vendor.Vendorid},{vendor.Siteid}", vendor4Update.Isusable);
			vendor4Update.Isusable = "UnUsable";
			vendor.CopyCommonFieldUpdatePrev(vendor4Update, systemTime, dbContext.Tid, text);
			vendor.CopyExtensionCollection(vendor4Update);
			list.Add(vendor4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteVendor(IDbContext dbContext, Vendor[] vendorList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("vendorList", vendorList);
		string text = "UnDeleteVendor";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Vendor> list = new List<Vendor>();
		foreach (Vendor vendor in vendorList)
		{
			Vendor vendor4Update = GetVendor4Update(dbContext, vendor.Vendorid, vendor.Siteid);
			if (vendor4Update == null)
			{
				throw new EntityNotFoundException(typeof(Vendor), $"{vendor.Vendorid},{vendor.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Vendor), $"{vendor.Vendorid},{vendor.Siteid}", vendor4Update.Isusable);
			vendor4Update.Isusable = "Usable";
			vendor.CopyCommonFieldUpdatePrev(vendor4Update, systemTime, dbContext.Tid, text);
			vendor.CopyExtensionCollection(vendor4Update);
			list.Add(vendor4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteVendor(IDbContext dbContext, Vendor[] vendorList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("vendorList", vendorList);
		string text = "RealDeleteVendor";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Vendor> list = new List<Vendor>();
		foreach (Vendor vendor in vendorList)
		{
			Vendor vendor4Update = GetVendor4Update(dbContext, vendor.Vendorid, vendor.Siteid);
			if (vendor4Update == null)
			{
				throw new EntityNotFoundException(typeof(Vendor), $"{vendor.Vendorid},{vendor.Siteid}");
			}
			vendor.CopyCommonFieldUpdatePrev(vendor4Update, systemTime, dbContext.Tid, text);
			vendor.CopyExtensionCollection(vendor4Update);
			list.Add(vendor4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
