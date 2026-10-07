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
public class PORT
{
	private static string _sqlGetPortSqlDatabase = "SELECT * FROM CIM_PORT WHERE EQUIPMENTID=@EQUIPMENTID AND PORTID=@PORTID AND SITEID=@SITEID";

	private static string _sqlGetPort4UpdateSqlDatabase = "SELECT * FROM CIM_PORT WITH(UPDLOCK) WHERE EQUIPMENTID=@EQUIPMENTID AND PORTID=@PORTID AND SITEID=@SITEID";

	private static string _sqlSelectPortSqlDatabase = "SELECT * FROM CIM_PORT WHERE EQUIPMENTID=@EQUIPMENTID AND PORTID=@PORTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectPort4UpdateSqlDatabase = "SELECT * FROM CIM_PORT WITH(UPDLOCK) WHERE EQUIPMENTID=@EQUIPMENTID AND PORTID=@PORTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetPortOracleDatabase = "SELECT * FROM CIM_PORT WHERE EQUIPMENTID=:EQUIPMENTID AND PORTID=:PORTID AND SITEID=:SITEID";

	private static string _sqlGetPort4UpdateOracleDatabase = "SELECT * FROM CIM_PORT WHERE EQUIPMENTID=:EQUIPMENTID AND PORTID=:PORTID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectPortOracleDatabase = "SELECT * FROM CIM_PORT WHERE EQUIPMENTID=:EQUIPMENTID AND PORTID=:PORTID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectPort4UpdateOracleDatabase = "SELECT * FROM CIM_PORT WHERE EQUIPMENTID=:EQUIPMENTID AND PORTID=:PORTID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Port);

	public static int ChangePortState(IDbContext dbContext, Port[] portList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("portList", portList);
		string text = "ChangePortState";
		string tid = dbContext.Tid;
		MesLogger.InfoTid("API", tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Port> list = new List<Port>();
		_ = portList[0].Siteid;
		List<Port> list2 = new List<Port>();
		Port[] array = OrderById(portList);
		foreach (Port port in array)
		{
			ParamChecker.ArgumentNotNull("Equipmentid", port.Equipmentid);
			ParamChecker.ArgumentNotNull("Portid", port.Portid);
			ParamChecker.ArgumentNotNull("Siteid", port.Siteid);
			Port port2 = SelectPort4Update(dbContext, port.Equipmentid, port.Portid, port.Siteid);
			if (port2 == null)
			{
				throw new EntityNotFoundException(typeof(Port), $"{port.Equipmentid},{port.Portid},{port.Siteid}");
			}
			list2.Add(port2);
		}
		array = portList;
		foreach (Port port3 in array)
		{
			string accessmode = port3.Accessmode;
			string porttype = port3.Porttype;
			string state = port3.State;
			string transferstate = port3.Transferstate;
			string siteid = port3.Siteid;
			ParamChecker.ArgumentNotNull("Equipmentid", port3.Equipmentid);
			ParamChecker.ArgumentNotNull("Portid", port3.Portid);
			ParamChecker.ArgumentNotNull("Siteid", siteid);
			Port port4 = FindPort(list2.ToArray(), port3.Equipmentid, port3.Portid);
			if (port4 == null)
			{
				throw new EntityNotFoundException(typeof(Port), $"{port3.Equipmentid},{port3.Portid}");
			}
			if (MesLogger.IsDebugEnabled("API"))
			{
				MesLogger.DebugTidApi(tid, "Before Execute", port4);
			}
			if (!string.IsNullOrEmpty(state) && port4.State != state)
			{
				port4.Prevstate = port4.State;
				port4.State = state;
			}
			if (!string.IsNullOrEmpty(porttype))
			{
				port4.Porttype = porttype;
			}
			if (!string.IsNullOrEmpty(accessmode))
			{
				port4.Accessmode = accessmode;
			}
			if (!string.IsNullOrEmpty(transferstate))
			{
				port4.Transferstate = transferstate;
			}
			port3.CopyCommonFieldUpdatePrev(port4, systemTime, tid, text);
			port3.CopyExtensionCollection(port4);
			list.Add(port4);
			if (MesLogger.IsInfoEnabled("API"))
			{
				MesLogger.InfoTidApi(tid, "After Execute", port4);
			}
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static Port GetPort(IDbContext dbContext, string equipmentid, string portid, string siteid)
	{
		string apiName = "GetPort";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentid},{portid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetPortSqlDatabase : _sqlGetPortOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("PORTID", portid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PORT", $"{equipmentid},{portid},{siteid}"));
		}
		Port? result = ContextManager.DirectEntityQuery<Port>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentid},{portid},{siteid}");
		}
		return result;
	}

	public static Port GetPort4Update(IDbContext dbContext, string equipmentid, string portid, string siteid)
	{
		string apiName = "GetPort4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentid},{portid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetPort4UpdateSqlDatabase : _sqlGetPort4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("PORTID", portid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PORT", $"{equipmentid},{portid},{siteid}"));
		}
		Port? result = ContextManager.DirectEntityQuery<Port>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentid},{portid},{siteid}");
		}
		return result;
	}

	public static Port SelectPort(IDbContext dbContext, string equipmentid, string portid, string siteid)
	{
		string apiName = "SelectPort";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentid},{portid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectPortSqlDatabase : _sqlSelectPortOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("PORTID", portid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PORT", $"{equipmentid},{portid},{siteid}"));
		}
		Port? result = ContextManager.DirectEntityQuery<Port>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentid},{portid},{siteid}");
		}
		return result;
	}

	public static Port SelectPort4Update(IDbContext dbContext, string equipmentid, string portid, string siteid)
	{
		string apiName = "SelectPort4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{equipmentid},{portid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectPort4UpdateSqlDatabase : _sqlSelectPort4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("EQUIPMENTID", equipmentid, typeOfThis));
		list.Add(dbContext.CreateParameter("PORTID", portid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PORT", $"{equipmentid},{portid},{siteid}"));
		}
		Port? result = ContextManager.DirectEntityQuery<Port>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{equipmentid},{portid},{siteid}");
		}
		return result;
	}

	public static int UpsertPort(IDbContext dbContext, RequestType requestType, Port[] portList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreatePortInternal(dbContext, portList, optionSet, saveHist), 
			RequestType.UPDATE => UpdatePort(dbContext, portList, optionSet, saveHist), 
			RequestType.DELETE => DeletePort(dbContext, portList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeletePort(dbContext, portList, optionSet, saveHist), 
			_ => RealDeletePort(dbContext, portList, optionSet, saveHist), 
		};
	}

	private static int CreatePortInternal(IDbContext dbContext, Port[] portList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("portList", portList);
		string text = "CreatePort";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Port> list = new List<Port>();
		foreach (Port obj in portList)
		{
			Port port = new Port();
			obj.CopyColumsTo(port);
			port.Activity = text;
			port.CheckEntityUsable();
			obj.CopyCommonField(port, systemTime, dbContext.Tid, isCreate: true);
			list.Add(port);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdatePort(IDbContext dbContext, Port[] portList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("portList", portList);
		string text = "UpdatePort";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Port> list = new List<Port>();
		foreach (Port port in portList)
		{
			Port port4Update = GetPort4Update(dbContext, port.Equipmentid, port.Portid, port.Siteid);
			if (port4Update == null)
			{
				throw new EntityNotFoundException(typeof(Port), $"{port.Equipmentid},{port.Portid},{port.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Port), $"{port.Equipmentid},{port.Portid},{port.Siteid}", port4Update.Isusable);
			string activity = port4Update.Activity;
			string customactivity = port4Update.Customactivity;
			string isusable = port4Update.Isusable;
			DateTime? createtime = port4Update.Createtime;
			string creator = port4Update.Creator;
			port.CopyColumsTo(port4Update);
			port4Update.Prevactivity = activity;
			port4Update.Prevcustomactivity = customactivity;
			port4Update.Creator = creator;
			port4Update.Createtime = createtime;
			port4Update.Isusable = isusable;
			port4Update.Activity = text;
			port.CopyCommonField(port4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(port4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeletePort(IDbContext dbContext, Port[] portList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("portList", portList);
		string text = "DeletePort";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Port> list = new List<Port>();
		foreach (Port port in portList)
		{
			Port port4Update = GetPort4Update(dbContext, port.Equipmentid, port.Portid, port.Siteid);
			if (port4Update == null)
			{
				throw new EntityNotFoundException(typeof(Port), $"{port.Equipmentid},{port.Portid},{port.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Port), $"{port.Equipmentid},{port.Portid},{port.Siteid}", port4Update.Isusable);
			port4Update.Isusable = "UnUsable";
			port.CopyCommonFieldUpdatePrev(port4Update, systemTime, dbContext.Tid, text);
			port.CopyExtensionCollection(port4Update);
			list.Add(port4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeletePort(IDbContext dbContext, Port[] portList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("portList", portList);
		string text = "UnDeletePort";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Port> list = new List<Port>();
		foreach (Port port in portList)
		{
			Port port4Update = GetPort4Update(dbContext, port.Equipmentid, port.Portid, port.Siteid);
			if (port4Update == null)
			{
				throw new EntityNotFoundException(typeof(Port), $"{port.Equipmentid},{port.Portid},{port.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Port), $"{port.Equipmentid},{port.Portid},{port.Siteid}", port4Update.Isusable);
			port4Update.Isusable = "Usable";
			port.CopyCommonFieldUpdatePrev(port4Update, systemTime, dbContext.Tid, text);
			port.CopyExtensionCollection(port4Update);
			list.Add(port4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeletePort(IDbContext dbContext, Port[] portList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("portList", portList);
		string text = "RealDeletePort";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Port> list = new List<Port>();
		foreach (Port port in portList)
		{
			Port port4Update = GetPort4Update(dbContext, port.Equipmentid, port.Portid, port.Siteid);
			if (port4Update == null)
			{
				throw new EntityNotFoundException(typeof(Port), $"{port.Equipmentid},{port.Portid},{port.Siteid}");
			}
			port.CopyCommonFieldUpdatePrev(port4Update, systemTime, dbContext.Tid, text);
			port.CopyExtensionCollection(port4Update);
			list.Add(port4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	internal static Port[] OrderById(Port[] portList)
	{
		return (from item in portList
			orderby item.Equipmentid, item.Portid
			select item).ToArray();
	}

	public static Port FindPort(Port[] portList, string equipmentId, string portId)
	{
		return portList?.FirstOrDefault((Port item) => item.Equipmentid == equipmentId && item.Portid == portId);
	}
}
