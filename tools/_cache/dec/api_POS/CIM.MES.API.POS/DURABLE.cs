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
public class DURABLE
{
	private static string _sqlGetDurableSqlDatabase = "SELECT * FROM CIM_DURABLE WHERE DURABLEID=@DURABLEID AND SITEID=@SITEID";

	private static string _sqlGetDurable4UpdateSqlDatabase = "SELECT * FROM CIM_DURABLE WITH(UPDLOCK) WHERE DURABLEID=@DURABLEID AND SITEID=@SITEID";

	private static string _sqlSelectDurableSqlDatabase = "SELECT * FROM CIM_DURABLE WHERE DURABLEID=@DURABLEID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectDurable4UpdateSqlDatabase = "SELECT * FROM CIM_DURABLE WITH(UPDLOCK) WHERE DURABLEID=@DURABLEID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetDurableOracleDatabase = "SELECT * FROM CIM_DURABLE WHERE DURABLEID=:DURABLEID AND SITEID=:SITEID";

	private static string _sqlGetDurable4UpdateOracleDatabase = "SELECT * FROM CIM_DURABLE WHERE DURABLEID=:DURABLEID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectDurableOracleDatabase = "SELECT * FROM CIM_DURABLE WHERE DURABLEID=:DURABLEID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectDurable4UpdateOracleDatabase = "SELECT * FROM CIM_DURABLE WHERE DURABLEID=:DURABLEID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Durable);

	public static int AssignDurableToCarrier(IDbContext dbContext, Durable durable, Durablecarrierrel[] durableCarrierRelList, IOptionSet optionSet, bool saveDurableHist, bool saveDurableCarrierrelHist, bool saveCarrierHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("durable", durable);
		ParamChecker.ArgumentNotNullAndHasElement("durableCarrierRelList", durableCarrierRelList);
		string text = "AssignDurableToCarrier";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		int num = 0;
		List<Durable> list = new List<Durable>();
		List<Durablecarrierrel> list2 = new List<Durablecarrierrel>();
		List<Carrier> list3 = new List<Carrier>();
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		ParamChecker.ArgumentNotNull("Durableid", durable.Durableid);
		ParamChecker.ArgumentNotNull("Siteid", durable.Siteid);
		string durableid = durable.Durableid;
		string siteid = durable.Siteid;
		Durable durable2 = SelectDurable4Update(dbContext, durableid, siteid);
		if (durable2 == null)
		{
			throw new EntityNotFoundException(typeof(Durable), $"{durableid},{siteid}");
		}
		durable.CopyCommonFieldUpdatePrev(durable2, systemTime, dbContext.Tid, text);
		durable.CopyExtensionCollection(durable2);
		list.Add(durable2);
		foreach (Durablecarrierrel durablecarrierrel in durableCarrierRelList)
		{
			ParamChecker.ArgumentNotNull("Carrierid", durablecarrierrel.Carrierid);
			ParamChecker.ArgumentNotNull("Slotposition", durablecarrierrel.Slotposition);
			string carrierid = durablecarrierrel.Carrierid;
			Carrier carrier = CARRIER.SelectCarrier(dbContext, carrierid, siteid);
			if (carrier == null)
			{
				throw new EntityNotFoundException(typeof(Carrier), $"{carrierid},{siteid}");
			}
			Durablecarrierrel durablecarrierrel2 = new Durablecarrierrel();
			durablecarrierrel.CopyColumsTo(durablecarrierrel2);
			durablecarrierrel2.Durableid = durableid;
			durablecarrierrel2.Carrierid = durablecarrierrel.Carrierid;
			durablecarrierrel2.Slotposition = durablecarrierrel.Slotposition;
			durablecarrierrel2.Activity = text;
			durablecarrierrel2.Isusable = "Usable";
			durablecarrierrel.CopyCommonField(durablecarrierrel2, systemTime, dbContext.Tid, isCreate: true);
			list2.Add(durablecarrierrel2);
			durablecarrierrel.CopyCommonFieldUpdatePrev(carrier, systemTime, dbContext.Tid, text);
			list3.Add(carrier);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveDurableHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list2.ToArray(), saveDurableCarrierrelHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list3.ToArray(), saveCarrierHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int ChangeDurableState(IDbContext dbContext, Durable[] durableList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("durableList", durableList);
		string text = "ChangeDurableState";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Durable> list = new List<Durable>();
		foreach (Durable durable in durableList)
		{
			string state = durable.State;
			ParamChecker.ArgumentNotNull("Durableid", durable.Durableid);
			ParamChecker.ArgumentNotNull("State", durable.State);
			ParamChecker.ArgumentNotNull("Siteid", durable.Siteid);
			string siteid = durable.Siteid;
			Durable durable2 = SelectDurable4Update(dbContext, durable.Durableid, siteid);
			if (durable2 == null)
			{
				throw new EntityNotFoundException(typeof(Durable), $"{durable.Durableid},{siteid}");
			}
			if (STATE.SelectState(dbContext, typeof(DurableState).Name, state, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(DurableState), $"{typeof(DurableState).Name},{state},{siteid}");
			}
			durable2.Prevstate = durable2.State;
			durable2.State = state;
			durable.CopyCommonFieldUpdatePrev(durable2, systemTime, tid, text);
			durable.CopyExtensionCollection(durable2);
			list.Add(durable2);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int CleanDurable(IDbContext dbContext, Durable[] durableList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("durableList", durableList);
		string text = "CleanDurable";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		int num = 0;
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		List<Durable> list = new List<Durable>();
		foreach (Durable durable in durableList)
		{
			ParamChecker.ArgumentNotNull("Durableid", durable.Durableid);
			ParamChecker.ArgumentNotNull("Siteid", durable.Siteid);
			string siteid = durable.Siteid;
			Durable durable2 = SelectDurable4Update(dbContext, durable.Durableid, siteid);
			if (durable2 == null)
			{
				throw new EntityNotFoundException(typeof(Durable), $"{durable.Durableid},{siteid}");
			}
			if (durable.Usagecount.Equals(0) && durable.Usagetype.Equals("COUNT") && !durable.Usagecountlimit.Equals(0))
			{
				if (durable.Cleantype.Equals("COUNT"))
				{
					durable2.Usagecount = 0L;
					durable2.Cleancount = durable2.Cleancount.Add(1);
					durable2.Lastcleantime = EntityHelper.FirstNotNull<DateTime?>(durable.Lastcleantime, durable.Modifytime, systemTime);
					durable2.Nextcleantime = durable.Nextcleantime;
					durable.CopyCommonFieldUpdatePrev(durable2, systemTime, tid, text);
					durable.CopyExtensionCollection(durable2);
					list.Add(durable2);
				}
			}
			else if (durable.Usageperiod.Equals(0) && durable.Usagetype.Equals("PERIOD") && durable.Usageperiodlimit.Equals(0) && durable.Cleantype.Equals("PERIOD"))
			{
				if (durable.Cleanperiodunit.Equals("DAY"))
				{
					int days = (DateTime.Now - durable.Modifytime).Days;
					durable2.Cleanperiod = durable2.Cleanperiod.Add(days);
				}
				else if (durable.Cleanperiodunit.Equals("HOUR"))
				{
					int hours = (DateTime.Now - durable.Modifytime).Hours;
					durable2.Cleanperiod = durable2.Cleanperiod.Add(hours);
				}
				else if (durable.Cleanperiodunit.Equals("MIN"))
				{
					int minutes = (DateTime.Now - durable.Modifytime).Minutes;
					durable2.Cleanperiod = durable2.Cleanperiod.Add(minutes);
				}
				durable.CopyCommonFieldUpdatePrev(durable2, systemTime, tid, text);
				durable.CopyExtensionCollection(durable2);
				list.Add(durable2);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int CompareDurableClean(IDbContext dbContext, Durable[] durableList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("durableList", durableList);
		string text = "CompareDurableClean";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		int num = 0;
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		List<Durable> list = new List<Durable>();
		foreach (Durable durable in durableList)
		{
			ParamChecker.ArgumentNotNull("Durableid", durable.Durableid);
			ParamChecker.ArgumentNotNull("Siteid", durable.Siteid);
			string siteid = durable.Siteid;
			Durable durable2 = SelectDurable4Update(dbContext, durable.Durableid, siteid);
			if (durable2 == null)
			{
				throw new EntityNotFoundException(typeof(Durable), durable.Durableid);
			}
			if (durable.Cleantype.Equals("COUNT"))
			{
				if (durable2.Cleancount == durable2.Cleancountlimit)
				{
					durable2.Cleancount = 0;
					durable2.Prevstate = durable2.State;
					durable2.State = "Terminated";
				}
				durable.CopyCommonFieldUpdatePrev(durable2, systemTime, tid, text);
				durable.CopyExtensionCollection(durable2);
				list.Add(durable2);
			}
			else if (durable.Cleantype.Equals("PERIOD"))
			{
				if (durable2.Cleanperiod == durable2.Cleanperiodlimit)
				{
					durable2.Cleanperiod = 0;
					durable2.Prevstate = durable2.State;
					durable2.State = "Terminated";
				}
				durable.CopyCommonFieldUpdatePrev(durable2, systemTime, tid, text);
				durable.CopyExtensionCollection(durable2);
				list.Add(durable2);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int CompareDurableUsage(IDbContext dbContext, Durable[] durableList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("durableList", durableList);
		string apiName = "CompareDurableUsage";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(apiName));
		int num = 0;
		ContextManager.GetSystemTime(dbContext);
		new List<Durable>();
		foreach (Durable durable in durableList)
		{
			ParamChecker.ArgumentNotNull("Durableid", durable.Durableid);
			ParamChecker.ArgumentNotNull("Siteid", durable.Siteid);
			string siteid = durable.Siteid;
			Durable durable2 = SelectDurable4Update(dbContext, durable.Durableid, siteid);
			if (durable2 == null)
			{
				throw new EntityNotFoundException(typeof(Durable), durable.Durableid);
			}
			if (durable.Usagetype.Equals("COUNT"))
			{
				if (durable2.Usagecount.Equals(durable2.Usagecountlimit))
				{
					num++;
				}
			}
			else if (durable.Usagetype.Equals("PERIOD") && durable2.Usageperiod.Equals(durable2.Usageperiodlimit))
			{
				num++;
			}
		}
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(apiName));
		return num;
	}

	public static int CreateDurable(IDbContext dbContext, Durable[] durableList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		string text = "CreateDurable";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		ParamChecker.ArgumentNotNull("entityObjectList", durableList);
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Durable> list = new List<Durable>();
		foreach (Durable durable in durableList)
		{
			Durable durable2 = new Durable();
			durable.CopyColumsTo(durable2);
			ParamChecker.ArgumentNotNull("Durableid", durable2.Durableid);
			ParamChecker.ArgumentNotNull("Durabledefinitionid", durable2.Durabledefinitionid);
			ParamChecker.ArgumentNotNull("Siteid", durable2.Siteid);
			string siteid = durable2.Siteid;
			if (DURABLEDEFINITION.SelectDurableDefinition(dbContext, durable2.Durabledefinitionid, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(Durabledefinition), $"{durable2.Durabledefinitionid},{siteid}");
			}
			durable2.Activity = text;
			durable2.Isusable = "Usable";
			durable.CopyCommonField(durable2, systemTime, tid, isCreate: true);
			list.Add(durable2);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int DeassignDurableFromCarrier(IDbContext dbContext, Durable durable, Durablecarrierrel[] durablecarrierrelList, IOptionSet optionSet, bool saveDurableHist, bool saveDurableCarrierrelHist, bool saveCarrierHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("durable", durable);
		ParamChecker.ArgumentNotNullAndHasElement("durablecarrierrelList", durablecarrierrelList);
		string text = "DeassignDurableFromCarrier";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		int num = 0;
		List<Durable> list = new List<Durable>();
		List<Durablecarrierrel> list2 = new List<Durablecarrierrel>();
		List<Carrier> list3 = new List<Carrier>();
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		ParamChecker.ArgumentNotNull("Durableid", durable.Durableid);
		ParamChecker.ArgumentNotNull("Siteid", durable.Siteid);
		string durableid = durable.Durableid;
		string siteid = durable.Siteid;
		Durable durable2 = SelectDurable4Update(dbContext, durableid, siteid);
		if (durable2 == null)
		{
			throw new EntityNotFoundException(typeof(Durable), $"{durableid},{siteid}");
		}
		durable.CopyCommonFieldUpdatePrev(durable2, systemTime, dbContext.Tid, text);
		durable.CopyExtensionCollection(durable2);
		list.Add(durable2);
		foreach (Durablecarrierrel durablecarrierrel in durablecarrierrelList)
		{
			ParamChecker.ArgumentNotNull("Carrierid", durablecarrierrel.Carrierid);
			ParamChecker.ArgumentNotNull("Slotposition", durablecarrierrel.Slotposition);
			string carrierid = durablecarrierrel.Carrierid;
			int slotposition = durablecarrierrel.Slotposition;
			Carrier carrier = CARRIER.SelectCarrier4Update(dbContext, carrierid, siteid);
			if (carrier == null)
			{
				throw new EntityNotFoundException(typeof(Carrier), $"{carrierid},{siteid}");
			}
			Durablecarrierrel durablecarrierrel2 = DURABLECARRIERREL.SelectDurableCarrierRel4Update(dbContext, durableid, carrierid, slotposition, siteid);
			if (durablecarrierrel2 == null)
			{
				throw new EntityNotFoundException(typeof(Durablecarrierrel), durableid, carrierid, slotposition.ToString());
			}
			durablecarrierrel.CopyCommonFieldUpdatePrev(durablecarrierrel2, systemTime, dbContext.Tid, text);
			durablecarrierrel.CopyExtensionCollection(durablecarrierrel2);
			list2.Add(durablecarrierrel2);
			durablecarrierrel.CopyCommonFieldUpdatePrev(carrier, systemTime, dbContext.Tid, text);
			list3.Add(carrier);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveDurableHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list2.ToArray(), saveDurableCarrierrelHist);
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list3.ToArray(), saveCarrierHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int DekitDurable(IDbContext dbContext, Durable[] durableList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("durableList", durableList);
		string text = "DekitDurable";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Durable> list = new List<Durable>();
		foreach (Durable durable in durableList)
		{
			_ = durable.Durableid;
			ParamChecker.ArgumentNotNull("Durableid", durable.Durableid);
			ParamChecker.ArgumentNotNull("Siteid", durable.Siteid);
			string siteid = durable.Siteid;
			Durable durable2 = SelectDurable4Update(dbContext, durable.Durableid, siteid);
			if (durable2 == null)
			{
				throw new EntityNotFoundException(typeof(Durable), $"{durable.Durableid},{siteid}");
			}
			durable2.Equipmentid = "";
			durable.CopyCommonFieldUpdatePrev(durable2, systemTime, tid, text);
			durable.CopyExtensionCollection(durable2);
			list.Add(durable2);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static Durable GetDurable(IDbContext dbContext, string durableid, string siteid)
	{
		string apiName = "GetDurable";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{durableid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetDurableSqlDatabase : _sqlGetDurableOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DURABLEID", durableid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_DURABLE", $"{durableid},{siteid}"));
		}
		Durable? result = ContextManager.DirectEntityQuery<Durable>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{durableid},{siteid}");
		}
		return result;
	}

	public static Durable GetDurable4Update(IDbContext dbContext, string durableid, string siteid)
	{
		string apiName = "GetDurable4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{durableid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetDurable4UpdateSqlDatabase : _sqlGetDurable4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DURABLEID", durableid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_DURABLE", $"{durableid},{siteid}"));
		}
		Durable? result = ContextManager.DirectEntityQuery<Durable>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{durableid},{siteid}");
		}
		return result;
	}

	public static Durable SelectDurable(IDbContext dbContext, string durableid, string siteid)
	{
		string apiName = "SelectDurable";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{durableid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectDurableSqlDatabase : _sqlSelectDurableOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DURABLEID", durableid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_DURABLE", $"{durableid},{siteid}"));
		}
		Durable? result = ContextManager.DirectEntityQuery<Durable>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{durableid},{siteid}");
		}
		return result;
	}

	public static Durable SelectDurable4Update(IDbContext dbContext, string durableid, string siteid)
	{
		string apiName = "SelectDurable4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{durableid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectDurable4UpdateSqlDatabase : _sqlSelectDurable4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("DURABLEID", durableid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_DURABLE", $"{durableid},{siteid}"));
		}
		Durable? result = ContextManager.DirectEntityQuery<Durable>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{durableid},{siteid}");
		}
		return result;
	}

	public static int UpsertDurable(IDbContext dbContext, RequestType requestType, Durable[] durableList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateDurableInternal(dbContext, durableList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateDurable(dbContext, durableList, optionSet, saveHist), 
			RequestType.DELETE => DeleteDurable(dbContext, durableList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteDurable(dbContext, durableList, optionSet, saveHist), 
			_ => RealDeleteDurable(dbContext, durableList, optionSet, saveHist), 
		};
	}

	private static int CreateDurableInternal(IDbContext dbContext, Durable[] durableList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("durableList", durableList);
		string text = "CreateDurable";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Durable> list = new List<Durable>();
		foreach (Durable obj in durableList)
		{
			Durable durable = new Durable();
			obj.CopyColumsTo(durable);
			durable.Activity = text;
			durable.CheckEntityUsable();
			obj.CopyCommonField(durable, systemTime, dbContext.Tid, isCreate: true);
			list.Add(durable);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateDurable(IDbContext dbContext, Durable[] durableList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("durableList", durableList);
		string text = "UpdateDurable";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Durable> list = new List<Durable>();
		foreach (Durable durable in durableList)
		{
			Durable durable4Update = GetDurable4Update(dbContext, durable.Durableid, durable.Siteid);
			if (durable4Update == null)
			{
				throw new EntityNotFoundException(typeof(Durable), $"{durable.Durableid},{durable.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Durable), $"{durable.Durableid},{durable.Siteid}", durable4Update.Isusable);
			string activity = durable4Update.Activity;
			string customactivity = durable4Update.Customactivity;
			string isusable = durable4Update.Isusable;
			DateTime? createtime = durable4Update.Createtime;
			string creator = durable4Update.Creator;
			durable.CopyColumsTo(durable4Update);
			durable4Update.Prevactivity = activity;
			durable4Update.Prevcustomactivity = customactivity;
			durable4Update.Creator = creator;
			durable4Update.Createtime = createtime;
			durable4Update.Isusable = isusable;
			durable4Update.Activity = text;
			durable.CopyCommonField(durable4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(durable4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteDurable(IDbContext dbContext, Durable[] durableList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("durableList", durableList);
		string text = "DeleteDurable";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Durable> list = new List<Durable>();
		foreach (Durable durable in durableList)
		{
			Durable durable4Update = GetDurable4Update(dbContext, durable.Durableid, durable.Siteid);
			if (durable4Update == null)
			{
				throw new EntityNotFoundException(typeof(Durable), $"{durable.Durableid},{durable.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Durable), $"{durable.Durableid},{durable.Siteid}", durable4Update.Isusable);
			durable4Update.Isusable = "UnUsable";
			durable.CopyCommonFieldUpdatePrev(durable4Update, systemTime, dbContext.Tid, text);
			durable.CopyExtensionCollection(durable4Update);
			list.Add(durable4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteDurable(IDbContext dbContext, Durable[] durableList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("durableList", durableList);
		string text = "UnDeleteDurable";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Durable> list = new List<Durable>();
		foreach (Durable durable in durableList)
		{
			Durable durable4Update = GetDurable4Update(dbContext, durable.Durableid, durable.Siteid);
			if (durable4Update == null)
			{
				throw new EntityNotFoundException(typeof(Durable), $"{durable.Durableid},{durable.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Durable), $"{durable.Durableid},{durable.Siteid}", durable4Update.Isusable);
			durable4Update.Isusable = "Usable";
			durable.CopyCommonFieldUpdatePrev(durable4Update, systemTime, dbContext.Tid, text);
			durable.CopyExtensionCollection(durable4Update);
			list.Add(durable4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteDurable(IDbContext dbContext, Durable[] durableList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("durableList", durableList);
		string text = "RealDeleteDurable";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Durable> list = new List<Durable>();
		foreach (Durable durable in durableList)
		{
			Durable durable4Update = GetDurable4Update(dbContext, durable.Durableid, durable.Siteid);
			if (durable4Update == null)
			{
				throw new EntityNotFoundException(typeof(Durable), $"{durable.Durableid},{durable.Siteid}");
			}
			durable.CopyCommonFieldUpdatePrev(durable4Update, systemTime, dbContext.Tid, text);
			durable.CopyExtensionCollection(durable4Update);
			list.Add(durable4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int HoldDurable(IDbContext dbContext, Durable[] durableList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("durableList", durableList);
		string text = "HoldDurable";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Durable> list = new List<Durable>();
		foreach (Durable durable in durableList)
		{
			ParamChecker.ArgumentNotNull("Durableid", durable.Durableid);
			ParamChecker.ArgumentNotNull("Siteid", durable.Siteid);
			string siteid = durable.Siteid;
			Durable durable2 = SelectDurable4Update(dbContext, durable.Durableid, siteid);
			if (durable2 == null)
			{
				throw new EntityNotFoundException(typeof(Durable), $"{durable.Durableid},{siteid}");
			}
			durable2.Prevstate = durable2.State;
			durable2.State = "Hold";
			durable.CopyCommonFieldUpdatePrev(durable2, systemTime, tid, text);
			durable2.Customactivity = EntityHelper.FirstNotNull<string>(durable.Customactivity, durable2.Activity);
			durable.CopyExtensionCollection(durable2);
			list.Add(durable2);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int IncreaseDurableUsage(IDbContext dbContext, Durable[] durableList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("durableList", durableList);
		string text = "IncreaseDurableUsage";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		int num = 0;
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		List<Durable> list = new List<Durable>();
		foreach (Durable durable in durableList)
		{
			ParamChecker.ArgumentNotNull("Durableid", durable.Durableid);
			ParamChecker.ArgumentNotNull("Siteid", durable.Siteid);
			string siteid = durable.Siteid;
			Durable durable2 = SelectDurable4Update(dbContext, durable.Durableid, siteid);
			if (durable2 == null)
			{
				throw new EntityNotFoundException(typeof(Durable), durable.Durableid);
			}
			if (durable.Usagetype.Equals("COUNT"))
			{
				durable2.Usagecount = durable2.Usagecount.Add(1L);
				durable.CopyCommonFieldUpdatePrev(durable2, systemTime, tid, text);
				durable.CopyExtensionCollection(durable2);
				list.Add(durable2);
			}
			else if (durable.Usagetype.Equals("PERIOD"))
			{
				if (durable.Usageperiodunit.Equals("DAY"))
				{
					int days = (DateTime.Now - durable.Modifytime).Days;
					durable2.Usageperiod = durable2.Usageperiod.Add(days);
				}
				else if (durable.Usageperiodunit.Equals("HOUR"))
				{
					int hours = (DateTime.Now - durable.Modifytime).Hours;
					durable2.Usageperiod = durable2.Usageperiod.Add(hours);
				}
				else if (durable.Usageperiodunit.Equals("MIN"))
				{
					int minutes = (DateTime.Now - durable.Modifytime).Minutes;
					durable2.Usageperiod = durable2.Usageperiod.Add(minutes);
				}
				durable.CopyCommonFieldUpdatePrev(durable2, systemTime, tid, text);
				durable.CopyExtensionCollection(durable2);
				list.Add(durable2);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int KitDurable(IDbContext dbContext, Durable[] durableList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("durableList", durableList);
		string text = "KitDurable";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Durable> list = new List<Durable>();
		foreach (Durable durable in durableList)
		{
			_ = durable.Durableid;
			string equipmentid = durable.Equipmentid;
			ParamChecker.ArgumentNotNull("Durableid", durable.Durableid);
			ParamChecker.ArgumentNotNull("Equipmentid", durable.Equipmentid);
			ParamChecker.ArgumentNotNull("Siteid", durable.Siteid);
			string siteid = durable.Siteid;
			Durable durable2 = SelectDurable4Update(dbContext, durable.Durableid, siteid);
			if (durable2 == null)
			{
				throw new EntityNotFoundException(typeof(Durable), $"{durable.Durableid},{siteid}");
			}
			if (EQUIPMENT.SelectEquipment(dbContext, equipmentid, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(Equipment), $"{equipmentid},{siteid}");
			}
			durable2.Equipmentid = equipmentid;
			durable.CopyCommonFieldUpdatePrev(durable2, systemTime, tid, text);
			durable.CopyExtensionCollection(durable2);
			list.Add(durable2);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int MoveDurableLocation(IDbContext dbContext, Durable[] durableList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("durableList", durableList);
		string text = "MoveDurableLocation";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Durable> list = new List<Durable>();
		foreach (Durable durable in durableList)
		{
			_ = durable.Durableid;
			string location = durable.Location;
			ParamChecker.ArgumentNotNull("Durableid", durable.Durableid);
			ParamChecker.ArgumentNotNull("Facilityid", durable.Location);
			ParamChecker.ArgumentNotNull("Siteid", durable.Siteid);
			string siteid = durable.Siteid;
			Durable durable2 = SelectDurable4Update(dbContext, durable.Durableid, siteid);
			if (durable2 == null)
			{
				throw new EntityNotFoundException(typeof(Durable), $"{durable.Durableid},{siteid}");
			}
			if (FACILITY.SelectFacility(dbContext, location, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(Facility), $"{location},{siteid}");
			}
			durable2.Prevlocation = durable2.Location;
			durable2.Location = location;
			durable.CopyCommonFieldUpdatePrev(durable2, systemTime, tid, text);
			durable.CopyExtensionCollection(durable2);
			list.Add(durable2);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int ReleaseHoldDurable(IDbContext dbContext, Durable[] durableList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("durableList", durableList);
		string text = "ReleaseHoldDurable";
		_ = dbContext.Tid;
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Durable> list = new List<Durable>();
		foreach (Durable durable in durableList)
		{
			string durableid = durable.Durableid;
			ParamChecker.ArgumentNotNull("Durableid", durable.Durableid);
			ParamChecker.ArgumentNotNull("Siteid", durable.Siteid);
			string siteid = durable.Siteid;
			Durable durable2 = SelectDurable4Update(dbContext, durable.Durableid, siteid);
			if (durable2 == null)
			{
				throw new EntityNotFoundException(typeof(Durable), $"{durable.Durableid},{siteid}");
			}
			ParamChecker.EntityValidState(typeof(Durable), durableid, durable2.State, "Hold");
			string prevstate = durable2.Prevstate;
			durable2.Prevstate = durable2.State;
			durable2.State = prevstate;
			durable.CopyCommonFieldUpdatePrev(durable2, systemTime, dbContext.Tid, text);
			durable.CopyExtensionCollection(durable2);
			list.Add(durable2);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int TerminateDurable(IDbContext dbContext, Durable[] durableList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("durableList", durableList);
		string text = "TerminateDurable";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Durable> list = new List<Durable>();
		foreach (Durable durable in durableList)
		{
			string durableid = durable.Durableid;
			ParamChecker.ArgumentNotNull("Durableid", durable.Durableid);
			ParamChecker.ArgumentNotNull("Siteid", durable.Siteid);
			string siteid = durable.Siteid;
			Durable durable2 = SelectDurable4Update(dbContext, durable.Durableid, siteid);
			if (durable2 == null)
			{
				throw new EntityNotFoundException(typeof(Durable), $"{durable.Durableid},{siteid}");
			}
			ParamChecker.EntityInvalidState(typeof(Durable), durableid, durable2.State, "Terminated");
			durable2.Prevstate = durable2.State;
			durable2.State = "Terminated";
			durable.CopyCommonFieldUpdatePrev(durable2, systemTime, tid, text);
			durable.CopyExtensionCollection(durable2);
			list.Add(durable2);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
