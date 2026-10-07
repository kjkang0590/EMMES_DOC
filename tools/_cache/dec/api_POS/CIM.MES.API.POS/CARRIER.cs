using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.API.CDS;
using CIM.MES.API.RDS;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.POS;

[MESAPI]
public class CARRIER
{
	private static string _sqlGetCarrierSqlDatabase = "SELECT * FROM CIM_CARRIER WHERE CARRIERID=@CARRIERID AND SITEID=@SITEID";

	private static string _sqlGetCarrier4UpdateSqlDatabase = "SELECT * FROM CIM_CARRIER WITH(UPDLOCK) WHERE CARRIERID=@CARRIERID AND SITEID=@SITEID";

	private static string _sqlSelectCarrierSqlDatabase = "SELECT * FROM CIM_CARRIER WHERE CARRIERID=@CARRIERID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectCarrier4UpdateSqlDatabase = "SELECT * FROM CIM_CARRIER WITH(UPDLOCK) WHERE CARRIERID=@CARRIERID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetCarrierOracleDatabase = "SELECT * FROM CIM_CARRIER WHERE CARRIERID=:CARRIERID AND SITEID=:SITEID";

	private static string _sqlGetCarrier4UpdateOracleDatabase = "SELECT * FROM CIM_CARRIER WHERE CARRIERID=:CARRIERID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectCarrierOracleDatabase = "SELECT * FROM CIM_CARRIER WHERE CARRIERID=:CARRIERID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectCarrier4UpdateOracleDatabase = "SELECT * FROM CIM_CARRIER WHERE CARRIERID=:CARRIERID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Carrier);

	public static Carrier GetCarrier(IDbContext dbContext, string carrierid, string siteid)
	{
		string apiName = "GetCarrier";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{carrierid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetCarrierSqlDatabase : _sqlGetCarrierOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CARRIERID", carrierid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_CARRIER", $"{carrierid},{siteid}"));
		}
		Carrier? result = ContextManager.DirectEntityQuery<Carrier>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{carrierid},{siteid}");
		}
		return result;
	}

	public static Carrier GetCarrier4Update(IDbContext dbContext, string carrierid, string siteid)
	{
		string apiName = "GetCarrier4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{carrierid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetCarrier4UpdateSqlDatabase : _sqlGetCarrier4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CARRIERID", carrierid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_CARRIER", $"{carrierid},{siteid}"));
		}
		Carrier? result = ContextManager.DirectEntityQuery<Carrier>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{carrierid},{siteid}");
		}
		return result;
	}

	public static Carrier SelectCarrier(IDbContext dbContext, string carrierid, string siteid)
	{
		string apiName = "SelectCarrier";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{carrierid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectCarrierSqlDatabase : _sqlSelectCarrierOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CARRIERID", carrierid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_CARRIER", $"{carrierid},{siteid}"));
		}
		Carrier? result = ContextManager.DirectEntityQuery<Carrier>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{carrierid},{siteid}");
		}
		return result;
	}

	public static Carrier SelectCarrier4Update(IDbContext dbContext, string carrierid, string siteid)
	{
		string apiName = "SelectCarrier4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{carrierid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectCarrier4UpdateSqlDatabase : _sqlSelectCarrier4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CARRIERID", carrierid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_CARRIER", $"{carrierid},{siteid}"));
		}
		Carrier? result = ContextManager.DirectEntityQuery<Carrier>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{carrierid},{siteid}");
		}
		return result;
	}

	public static int UpsertCarrier(IDbContext dbContext, RequestType requestType, Carrier[] carrierList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateCarrierInternal(dbContext, carrierList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateCarrier(dbContext, carrierList, optionSet, saveHist), 
			RequestType.DELETE => DeleteCarrier(dbContext, carrierList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteCarrier(dbContext, carrierList, optionSet, saveHist), 
			_ => RealDeleteCarrier(dbContext, carrierList, optionSet, saveHist), 
		};
	}

	private static int CreateCarrierInternal(IDbContext dbContext, Carrier[] carrierList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("carrierList", carrierList);
		string text = "CreateCarrier";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Carrier> list = new List<Carrier>();
		foreach (Carrier obj in carrierList)
		{
			Carrier carrier = new Carrier();
			obj.CopyColumsTo(carrier);
			carrier.Activity = text;
			carrier.CheckEntityUsable();
			obj.CopyCommonField(carrier, systemTime, dbContext.Tid, isCreate: true);
			list.Add(carrier);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateCarrier(IDbContext dbContext, Carrier[] carrierList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("carrierList", carrierList);
		string text = "UpdateCarrier";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Carrier> list = new List<Carrier>();
		foreach (Carrier carrier in carrierList)
		{
			Carrier carrier4Update = GetCarrier4Update(dbContext, carrier.Carrierid, carrier.Siteid);
			if (carrier4Update == null)
			{
				throw new EntityNotFoundException(typeof(Carrier), $"{carrier.Carrierid},{carrier.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Carrier), $"{carrier.Carrierid},{carrier.Siteid}", carrier4Update.Isusable);
			string activity = carrier4Update.Activity;
			string customactivity = carrier4Update.Customactivity;
			string isusable = carrier4Update.Isusable;
			DateTime? createtime = carrier4Update.Createtime;
			string creator = carrier4Update.Creator;
			carrier.CopyColumsTo(carrier4Update);
			carrier4Update.Prevactivity = activity;
			carrier4Update.Prevcustomactivity = customactivity;
			carrier4Update.Creator = creator;
			carrier4Update.Createtime = createtime;
			carrier4Update.Isusable = isusable;
			carrier4Update.Activity = text;
			carrier.CopyCommonField(carrier4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(carrier4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteCarrier(IDbContext dbContext, Carrier[] carrierList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("carrierList", carrierList);
		string text = "DeleteCarrier";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Carrier> list = new List<Carrier>();
		foreach (Carrier carrier in carrierList)
		{
			Carrier carrier4Update = GetCarrier4Update(dbContext, carrier.Carrierid, carrier.Siteid);
			if (carrier4Update == null)
			{
				throw new EntityNotFoundException(typeof(Carrier), $"{carrier.Carrierid},{carrier.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Carrier), $"{carrier.Carrierid},{carrier.Siteid}", carrier4Update.Isusable);
			carrier4Update.Isusable = "UnUsable";
			carrier.CopyCommonFieldUpdatePrev(carrier4Update, systemTime, dbContext.Tid, text);
			carrier.CopyExtensionCollection(carrier4Update);
			list.Add(carrier4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteCarrier(IDbContext dbContext, Carrier[] carrierList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("carrierList", carrierList);
		string text = "UnDeleteCarrier";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Carrier> list = new List<Carrier>();
		foreach (Carrier carrier in carrierList)
		{
			Carrier carrier4Update = GetCarrier4Update(dbContext, carrier.Carrierid, carrier.Siteid);
			if (carrier4Update == null)
			{
				throw new EntityNotFoundException(typeof(Carrier), $"{carrier.Carrierid},{carrier.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Carrier), $"{carrier.Carrierid},{carrier.Siteid}", carrier4Update.Isusable);
			carrier4Update.Isusable = "Usable";
			carrier.CopyCommonFieldUpdatePrev(carrier4Update, systemTime, dbContext.Tid, text);
			carrier.CopyExtensionCollection(carrier4Update);
			list.Add(carrier4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteCarrier(IDbContext dbContext, Carrier[] carrierList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("carrierList", carrierList);
		string text = "RealDeleteCarrier";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Carrier> list = new List<Carrier>();
		foreach (Carrier carrier in carrierList)
		{
			Carrier carrier4Update = GetCarrier4Update(dbContext, carrier.Carrierid, carrier.Siteid);
			if (carrier4Update == null)
			{
				throw new EntityNotFoundException(typeof(Carrier), $"{carrier.Carrierid},{carrier.Siteid}");
			}
			carrier.CopyCommonFieldUpdatePrev(carrier4Update, systemTime, dbContext.Tid, text);
			carrier.CopyExtensionCollection(carrier4Update);
			list.Add(carrier4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int ChangeCarrierState(IDbContext dbContext, Carrier[] carrierList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("carrierList", carrierList);
		string text = "ChangeCarrierState";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Carrier> list = new List<Carrier>();
		foreach (Carrier carrier in carrierList)
		{
			string state = carrier.State;
			ParamChecker.ArgumentNotNull("Carrierid", carrier.Carrierid);
			ParamChecker.ArgumentNotNull("State", carrier.State);
			ParamChecker.ArgumentNotNull("Siteid", carrier.Siteid);
			string siteid = carrier.Siteid;
			Carrier carrier2 = SelectCarrier4Update(dbContext, carrier.Carrierid, siteid);
			if (carrier2 == null)
			{
				throw new EntityNotFoundException(typeof(Carrier), $"{carrier.Carrierid},{siteid}");
			}
			if (STATE.SelectState(dbContext, typeof(CarrierState).Name, state, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(CarrierState), $"{typeof(CarrierState).Name},{state},{siteid}");
			}
			if (carrier.Assignqty.HasValue && !(carrier2.Assignqty == carrier.Assignqty))
			{
				carrier2.Assignqty = carrier.Assignqty;
			}
			if (carrier.Loadstate != null && carrier2.Loadstate != carrier.Loadstate)
			{
				carrier2.Loadstate = carrier.Loadstate;
			}
			carrier2.Prevstate = carrier2.State;
			carrier2.State = state;
			carrier.CopyCommonFieldUpdatePrev(carrier2, systemTime, tid, text);
			carrier.CopyExtensionCollection(carrier2);
			list.Add(carrier2);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int CleanCarrier(IDbContext dbContext, Carrier[] carrierList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("carrierList", carrierList);
		string text = "CleanCarrier";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Carrier> list = new List<Carrier>();
		foreach (Carrier carrier in carrierList)
		{
			ParamChecker.ArgumentNotNull("Carrierid", carrier.Carrierid);
			ParamChecker.ArgumentNotNull("Siteid", carrier.Siteid);
			string siteid = carrier.Siteid;
			Carrier carrier2 = SelectCarrier4Update(dbContext, carrier.Carrierid, siteid);
			if (carrier2 == null)
			{
				throw new EntityNotFoundException(typeof(Carrier), $"{carrier.Carrierid},{siteid}");
			}
			if (carrier2.Usagecount.Equals(carrier2.Usagecountlimit))
			{
				if (carrier2.Cleantype.Equals("COUNT"))
				{
					carrier2.Usagecount = 0;
					carrier2.Cleancount = carrier2.Cleancount.Add(1);
					carrier2.Lastcleantime = EntityHelper.FirstNotNull<DateTime?>(carrier.Lastcleantime, carrier.Modifytime, systemTime);
					carrier2.Nextcleantime = carrier.Nextcleantime;
					carrier.CopyCommonFieldUpdatePrev(carrier2, systemTime, tid, text);
					carrier.CopyExtensionCollection(carrier2);
					list.Add(carrier2);
				}
			}
			else if (carrier2.Usageperiod.Equals(carrier2.Usageperiodlimit) && carrier2.Cleantype.Equals("PERIOD"))
			{
				if (carrier.Cleanperiodunit.Equals("DAY"))
				{
					int days = (DateTime.Now - carrier.Modifytime).Days;
					carrier2.Cleanperiod = carrier2.Cleanperiod.Add(days);
				}
				else if (carrier.Cleanperiodunit.Equals("HOUR"))
				{
					int hours = (DateTime.Now - carrier.Modifytime).Hours;
					carrier2.Cleanperiod = carrier2.Cleanperiod.Add(hours);
				}
				else if (carrier.Cleanperiodunit.Equals("MIN"))
				{
					int minutes = (DateTime.Now - carrier.Modifytime).Minutes;
					carrier2.Cleanperiod = carrier2.Cleanperiod.Add(minutes);
				}
				carrier.CopyCommonFieldUpdatePrev(carrier2, systemTime, tid, text);
				carrier.CopyExtensionCollection(carrier2);
				list.Add(carrier2);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int CompareCarrierClean(IDbContext dbContext, Carrier[] carrierList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("carrierList", carrierList);
		string text = "CompareCarrierClean";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		int num = 0;
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		List<Carrier> list = new List<Carrier>();
		foreach (Carrier carrier in carrierList)
		{
			ParamChecker.ArgumentNotNull("Carrierid", carrier.Carrierid);
			ParamChecker.ArgumentNotNull("Siteid", carrier.Siteid);
			string siteid = carrier.Siteid;
			Carrier carrier2 = SelectCarrier4Update(dbContext, carrier.Carrierid, siteid);
			if (carrier2 == null)
			{
				throw new EntityNotFoundException(typeof(Carrier), carrier.Carrierid);
			}
			if (carrier.Cleantype.Equals("COUNT"))
			{
				if (carrier2.Cleancount == carrier2.Cleancountlimit)
				{
					carrier2.Cleancount = 0;
					carrier2.Prevstate = carrier2.State;
					carrier2.State = "Terminated";
				}
				carrier.CopyCommonFieldUpdatePrev(carrier2, systemTime, tid, text);
				carrier.CopyExtensionCollection(carrier2);
				list.Add(carrier2);
			}
			else if (carrier.Cleantype.Equals("PERIOD"))
			{
				if (carrier2.Cleanperiod == carrier2.Cleanperiodlimit)
				{
					carrier2.Cleanperiod = 0;
					carrier2.Prevstate = carrier2.State;
					carrier2.State = "Terminated";
				}
				carrier.CopyCommonFieldUpdatePrev(carrier2, systemTime, tid, text);
				carrier.CopyExtensionCollection(carrier2);
				list.Add(carrier2);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int CompareCarrierUsage(IDbContext dbContext, Carrier[] carrierList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("carrierList", carrierList);
		string apiName = "CompareCarrierUsage";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(apiName));
		int num = 0;
		ContextManager.GetSystemTime(dbContext);
		new List<Carrier>();
		foreach (Carrier carrier in carrierList)
		{
			ParamChecker.ArgumentNotNull("Carrierid", carrier.Carrierid);
			ParamChecker.ArgumentNotNull("Siteid", carrier.Siteid);
			string siteid = carrier.Siteid;
			Carrier carrier2 = SelectCarrier4Update(dbContext, carrier.Carrierid, siteid);
			if (carrier2 == null)
			{
				throw new EntityNotFoundException(typeof(Carrier), carrier.Carrierid);
			}
			if (carrier2.Usagetype.Equals("COUNT"))
			{
				if (carrier2.Usagecount.Equals(carrier2.Usagecountlimit))
				{
					num++;
				}
			}
			else if (carrier2.Usagetype.Equals("PERIOD") && carrier2.Usageperiod.Equals(carrier2.Usageperiodlimit))
			{
				num++;
			}
		}
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(apiName));
		return num;
	}

	public static int CreateCarrier(IDbContext dbContext, Carrier[] carrierList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("carrierList", carrierList);
		string text = "CreateCarrier";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Carrier> list = new List<Carrier>();
		foreach (Carrier carrier in carrierList)
		{
			Carrier carrier2 = new Carrier();
			carrier.CopyColumsTo(carrier2);
			ParamChecker.ArgumentNotNull("Carrierid", carrier2.Carrierid);
			ParamChecker.ArgumentNotNull("Carrierdefinitionid", carrier2.Carrierdefinitionid);
			ParamChecker.ArgumentNotNull("Siteid", carrier2.Siteid);
			string siteid = carrier2.Siteid;
			Carrierdefinition carrierdefinition;
			if ((carrierdefinition = CARRIERDEFINITION.SelectCarrierDefinition(dbContext, carrier2.Carrierdefinitionid, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Carrierdefinition), $"{carrier2.Carrierdefinitionid},{siteid}");
			}
			carrier2.Carrierclassid = carrierdefinition.Carrierclassid;
			carrier2.Materialtype = carrierdefinition.Materialtype;
			carrier2.Maxcapacity = carrierdefinition.Maxcapacity;
			carrier2.Slotqty = carrierdefinition.Slotqty;
			carrier2.Vendorid = carrierdefinition.Vendorid;
			carrier2.Usagetype = carrierdefinition.Usagetype;
			carrier2.Usagecountlimit = carrierdefinition.Usagecountlimit;
			carrier2.Usageperiodunit = carrierdefinition.Usageperiodunit;
			carrier2.Usageperiodlimit = carrierdefinition.Usageperiodlimit;
			carrier2.Cleantype = carrierdefinition.Cleantype;
			carrier2.Cleancountlimit = carrierdefinition.Cleancountlimit;
			carrier2.Cleanperiodunit = carrierdefinition.Cleanperiodunit;
			carrier2.Cleanperiodlimit = carrierdefinition.Cleanperiodlimit;
			carrier2.Repairtype = carrierdefinition.Repairtype;
			carrier2.Repaircountlimit = carrierdefinition.Repaircountlimit;
			carrier2.Repairperiodunit = carrierdefinition.Repairperiodunit;
			carrier2.Repairperiodlimit = carrierdefinition.Repairperiodlimit;
			carrier2.State = "Active";
			carrier2.Activity = text;
			carrier2.Isusable = "Usable";
			carrier.CopyCommonField(carrier2, systemTime, tid, isCreate: true);
			list.Add(carrier2);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int DekitCarrier(IDbContext dbContext, Carrier[] carrierList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("carrierList", carrierList);
		string text = "DekitCarrier";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Carrier> list = new List<Carrier>();
		foreach (Carrier carrier in carrierList)
		{
			_ = carrier.Carrierid;
			ParamChecker.ArgumentNotNull("Carrierid", carrier.Carrierid);
			ParamChecker.ArgumentNotNull("Siteid", carrier.Siteid);
			string siteid = carrier.Siteid;
			Carrier carrier2 = SelectCarrier4Update(dbContext, carrier.Carrierid, siteid);
			if (carrier2 == null)
			{
				throw new EntityNotFoundException(typeof(Carrier), $"{carrier.Carrierid},{siteid}");
			}
			carrier2.Equipmentid = "";
			carrier.CopyCommonFieldUpdatePrev(carrier2, systemTime, tid, text);
			carrier.CopyExtensionCollection(carrier2);
			list.Add(carrier2);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int HoldCarrier(IDbContext dbContext, Carrier[] carrierList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("carrierList", carrierList);
		string text = "HoldCarrier";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Carrier> list = new List<Carrier>();
		foreach (Carrier carrier in carrierList)
		{
			ParamChecker.ArgumentNotNull("Carrierid", carrier.Carrierid);
			ParamChecker.ArgumentNotNull("Siteid", carrier.Siteid);
			string siteid = carrier.Siteid;
			Carrier carrier2 = SelectCarrier4Update(dbContext, carrier.Carrierid, siteid);
			if (carrier2 == null)
			{
				throw new EntityNotFoundException(typeof(Carrier), $"{carrier.Carrierid},{siteid}");
			}
			carrier2.Prevstate = carrier2.State;
			carrier2.State = "Hold";
			carrier.CopyCommonFieldUpdatePrev(carrier2, systemTime, tid, text);
			carrier.CopyExtensionCollection(carrier2);
			list.Add(carrier2);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int IncreaseCarrierUsage(IDbContext dbContext, Carrier[] carrierList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("carrierList", carrierList);
		string text = "IncreaseCarrierUsage";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		int num = 0;
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		List<Carrier> list = new List<Carrier>();
		foreach (Carrier carrier in carrierList)
		{
			ParamChecker.ArgumentNotNull("Carrierid", carrier.Carrierid);
			ParamChecker.ArgumentNotNull("Siteid", carrier.Siteid);
			string siteid = carrier.Siteid;
			Carrier carrier2 = SelectCarrier4Update(dbContext, carrier.Carrierid, siteid);
			if (carrier2 == null)
			{
				throw new EntityNotFoundException(typeof(Carrier), $"{carrier.Carrierid},{siteid}");
			}
			if (carrier.Usagetype.Equals("COUNT"))
			{
				carrier2.Usagecount = carrier2.Usagecount.Add(1);
				carrier.CopyCommonFieldUpdatePrev(carrier2, systemTime, tid, text);
				carrier.CopyExtensionCollection(carrier2);
				list.Add(carrier2);
			}
			else if (carrier.Usagetype.Equals("PERIOD"))
			{
				if (carrier.Usageperiodunit.Equals("DAY"))
				{
					int days = (DateTime.Now - carrier.Modifytime).Days;
					carrier2.Usageperiod = carrier2.Usageperiod.Add(days);
				}
				else if (carrier.Usageperiodunit.Equals("HOUR"))
				{
					int hours = (DateTime.Now - carrier.Modifytime).Hours;
					carrier2.Usageperiod = carrier2.Usageperiod.Add(hours);
				}
				else if (carrier.Usageperiodunit.Equals("MIN"))
				{
					int minutes = (DateTime.Now - carrier.Modifytime).Minutes;
					carrier2.Usageperiod = carrier2.Usageperiod.Add(minutes);
				}
				carrier.CopyCommonFieldUpdatePrev(carrier2, systemTime, tid, text);
				carrier.CopyExtensionCollection(carrier2);
				list.Add(carrier2);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int KitCarrier(IDbContext dbContext, Carrier[] carrierList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("carrierList", carrierList);
		string text = "KitCarrier";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Carrier> list = new List<Carrier>();
		foreach (Carrier carrier in carrierList)
		{
			_ = carrier.Carrierid;
			string equipmentid = carrier.Equipmentid;
			ParamChecker.ArgumentNotNull("Carrierid", carrier.Carrierid);
			ParamChecker.ArgumentNotNull("Equipmentid", carrier.Equipmentid);
			ParamChecker.ArgumentNotNull("Siteid", carrier.Siteid);
			string siteid = carrier.Siteid;
			Carrier carrier2 = SelectCarrier4Update(dbContext, carrier.Carrierid, siteid);
			if (carrier2 == null)
			{
				throw new EntityNotFoundException(typeof(Carrier), $"{carrier.Carrierid},{siteid}");
			}
			if (EQUIPMENT.SelectEquipment(dbContext, equipmentid, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(Equipment), $"{equipmentid},{siteid}");
			}
			carrier2.Equipmentid = equipmentid;
			carrier.CopyCommonFieldUpdatePrev(carrier2, systemTime, tid, text);
			carrier.CopyExtensionCollection(carrier2);
			list.Add(carrier2);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int MoveCarrier(IDbContext dbContext, Carrier[] carrierList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("carrierList", carrierList);
		string text = "MoveCarrier";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Carrier> list = new List<Carrier>();
		foreach (Carrier carrier in carrierList)
		{
			_ = carrier.Carrierid;
			string location = carrier.Location;
			ParamChecker.ArgumentNotNull("Carrierid", carrier.Carrierid);
			ParamChecker.ArgumentNotNull("Location", carrier.Location);
			ParamChecker.ArgumentNotNull("Siteid", carrier.Siteid);
			string siteid = carrier.Siteid;
			Carrier carrier2 = SelectCarrier4Update(dbContext, carrier.Carrierid, siteid);
			if (carrier2 == null)
			{
				throw new EntityNotFoundException(typeof(Carrier), $"{carrier.Carrierid},{siteid}");
			}
			if (FACILITY.SelectFacility(dbContext, location, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(Facility), $"{location},{siteid}");
			}
			carrier2.Prevlocation = carrier2.Location;
			carrier2.Location = location;
			carrier.CopyCommonFieldUpdatePrev(carrier2, systemTime, tid, text);
			carrier.CopyExtensionCollection(carrier2);
			list.Add(carrier2);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int ReleaseHoldCarrier(IDbContext dbContext, Carrier[] carrierList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("carrierList", carrierList);
		string text = "ReleaseHoldCarrier";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Carrier> list = new List<Carrier>();
		foreach (Carrier carrier in carrierList)
		{
			string carrierid = carrier.Carrierid;
			ParamChecker.ArgumentNotNull("Carrierid", carrier.Carrierid);
			ParamChecker.ArgumentNotNull("Siteid", carrier.Siteid);
			string siteid = carrier.Siteid;
			Carrier carrier2 = SelectCarrier4Update(dbContext, carrier.Carrierid, siteid);
			if (carrier2 == null)
			{
				throw new EntityNotFoundException(typeof(Carrier), $"{carrier.Carrierid},{siteid}");
			}
			ParamChecker.EntityValidState(typeof(Carrier), carrierid, carrier2.State, "Hold");
			string prevstate = carrier2.Prevstate;
			carrier2.Prevstate = carrier2.State;
			carrier2.State = prevstate;
			carrier.CopyCommonFieldUpdatePrev(carrier2, systemTime, tid, text);
			carrier.CopyExtensionCollection(carrier2);
			list.Add(carrier2);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int TerminateCarrier(IDbContext dbContext, Carrier[] carrierList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("carrierList", carrierList);
		string text = "TerminateCarrier";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Carrier> list = new List<Carrier>();
		foreach (Carrier carrier in carrierList)
		{
			_ = carrier.Carrierid;
			ParamChecker.ArgumentNotNull("Carrierid", carrier.Carrierid);
			ParamChecker.ArgumentNotNull("Siteid", carrier.Siteid);
			string siteid = carrier.Siteid;
			Carrier carrier2 = SelectCarrier4Update(dbContext, carrier.Carrierid, siteid);
			if (carrier2 == null)
			{
				throw new EntityNotFoundException(typeof(Carrier), $"{carrier.Carrierid},{siteid}");
			}
			ParamChecker.EntityInvalidState(typeof(Carrier), carrier2.Carrierid, carrier2.State, "Terminated");
			if (carrier.Assignqty.HasValue && !(carrier2.Assignqty == carrier.Assignqty))
			{
				carrier2.Assignqty = carrier.Assignqty;
			}
			if (carrier.Loadstate != null && carrier2.Loadstate != carrier.Loadstate)
			{
				carrier2.Loadstate = carrier.Loadstate;
			}
			carrier2.Prevstate = carrier2.State;
			carrier2.State = "Terminated";
			carrier.CopyCommonFieldUpdatePrev(carrier2, systemTime, tid, text);
			carrier.CopyExtensionCollection(carrier2);
			list.Add(carrier2);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
