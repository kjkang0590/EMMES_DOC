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
public class CLIENT
{
	private static string _sqlGetClientSqlDatabase = "SELECT * FROM CIM_CLIENT WHERE CLIENTID=@CLIENTID AND SITEID=@SITEID";

	private static string _sqlGetClient4UpdateSqlDatabase = "SELECT * FROM CIM_CLIENT WITH(UPDLOCK) WHERE CLIENTID=@CLIENTID AND SITEID=@SITEID";

	private static string _sqlSelectClientSqlDatabase = "SELECT * FROM CIM_CLIENT WHERE CLIENTID=@CLIENTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectClient4UpdateSqlDatabase = "SELECT * FROM CIM_CLIENT WITH(UPDLOCK) WHERE CLIENTID=@CLIENTID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetClientOracleDatabase = "SELECT * FROM CIM_CLIENT WHERE CLIENTID=:CLIENTID AND SITEID=:SITEID";

	private static string _sqlGetClient4UpdateOracleDatabase = "SELECT * FROM CIM_CLIENT WHERE CLIENTID=:CLIENTID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectClientOracleDatabase = "SELECT * FROM CIM_CLIENT WHERE CLIENTID=:CLIENTID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectClient4UpdateOracleDatabase = "SELECT * FROM CIM_CLIENT WHERE CLIENTID=:CLIENTID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Client);

	public static Client GetClient(IDbContext dbContext, string clientid, string siteid)
	{
		string apiName = "GetClient";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{clientid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetClientSqlDatabase : _sqlGetClientOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CLIENTID", clientid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_CLIENT", $"{clientid},{siteid}"));
		}
		Client? result = ContextManager.DirectEntityQuery<Client>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{clientid},{siteid}");
		}
		return result;
	}

	public static Client GetClient4Update(IDbContext dbContext, string clientid, string siteid)
	{
		string apiName = "GetClient4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{clientid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetClient4UpdateSqlDatabase : _sqlGetClient4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CLIENTID", clientid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_CLIENT", $"{clientid},{siteid}"));
		}
		Client? result = ContextManager.DirectEntityQuery<Client>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{clientid},{siteid}");
		}
		return result;
	}

	public static Client SelectClient(IDbContext dbContext, string clientid, string siteid)
	{
		string apiName = "SelectClient";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{clientid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectClientSqlDatabase : _sqlSelectClientOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CLIENTID", clientid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_CLIENT", $"{clientid},{siteid}"));
		}
		Client? result = ContextManager.DirectEntityQuery<Client>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{clientid},{siteid}");
		}
		return result;
	}

	public static Client SelectClient4Update(IDbContext dbContext, string clientid, string siteid)
	{
		string apiName = "SelectClient4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{clientid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectClient4UpdateSqlDatabase : _sqlSelectClient4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CLIENTID", clientid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_CLIENT", $"{clientid},{siteid}"));
		}
		Client? result = ContextManager.DirectEntityQuery<Client>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{clientid},{siteid}");
		}
		return result;
	}

	public static int UpsertClient(IDbContext dbContext, RequestType requestType, Client[] clientList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateClientInternal(dbContext, clientList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateClient(dbContext, clientList, optionSet, saveHist), 
			RequestType.DELETE => DeleteClient(dbContext, clientList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteClient(dbContext, clientList, optionSet, saveHist), 
			_ => RealDeleteClient(dbContext, clientList, optionSet, saveHist), 
		};
	}

	private static int CreateClientInternal(IDbContext dbContext, Client[] clientList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("clientList", clientList);
		string text = "CreateClient";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Client> list = new List<Client>();
		foreach (Client obj in clientList)
		{
			Client client = new Client();
			obj.CopyColumsTo(client);
			client.Activity = text;
			client.CheckEntityUsable();
			obj.CopyCommonField(client, systemTime, dbContext.Tid, isCreate: true);
			list.Add(client);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateClient(IDbContext dbContext, Client[] clientList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("clientList", clientList);
		string text = "UpdateClient";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Client> list = new List<Client>();
		foreach (Client client in clientList)
		{
			Client client4Update = GetClient4Update(dbContext, client.Clientid, client.Siteid);
			if (client4Update == null)
			{
				throw new EntityNotFoundException(typeof(Client), $"{client.Clientid},{client.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Client), $"{client.Clientid},{client.Siteid}", client4Update.Isusable);
			string activity = client4Update.Activity;
			string customactivity = client4Update.Customactivity;
			string isusable = client4Update.Isusable;
			DateTime? createtime = client4Update.Createtime;
			string creator = client4Update.Creator;
			client.CopyColumsTo(client4Update);
			client4Update.Prevactivity = activity;
			client4Update.Prevcustomactivity = customactivity;
			client4Update.Creator = creator;
			client4Update.Createtime = createtime;
			client4Update.Isusable = isusable;
			client4Update.Activity = text;
			client.CopyCommonField(client4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(client4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteClient(IDbContext dbContext, Client[] clientList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("clientList", clientList);
		string text = "DeleteClient";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Client> list = new List<Client>();
		foreach (Client client in clientList)
		{
			Client client4Update = GetClient4Update(dbContext, client.Clientid, client.Siteid);
			if (client4Update == null)
			{
				throw new EntityNotFoundException(typeof(Client), $"{client.Clientid},{client.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Client), $"{client.Clientid},{client.Siteid}", client4Update.Isusable);
			client4Update.Isusable = "UnUsable";
			client.CopyCommonFieldUpdatePrev(client4Update, systemTime, dbContext.Tid, text);
			client.CopyExtensionCollection(client4Update);
			list.Add(client4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteClient(IDbContext dbContext, Client[] clientList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("clientList", clientList);
		string text = "UnDeleteClient";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Client> list = new List<Client>();
		foreach (Client client in clientList)
		{
			Client client4Update = GetClient4Update(dbContext, client.Clientid, client.Siteid);
			if (client4Update == null)
			{
				throw new EntityNotFoundException(typeof(Client), $"{client.Clientid},{client.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Client), $"{client.Clientid},{client.Siteid}", client4Update.Isusable);
			client4Update.Isusable = "Usable";
			client.CopyCommonFieldUpdatePrev(client4Update, systemTime, dbContext.Tid, text);
			client.CopyExtensionCollection(client4Update);
			list.Add(client4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteClient(IDbContext dbContext, Client[] clientList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("clientList", clientList);
		string text = "RealDeleteClient";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Client> list = new List<Client>();
		foreach (Client client in clientList)
		{
			Client client4Update = GetClient4Update(dbContext, client.Clientid, client.Siteid);
			if (client4Update == null)
			{
				throw new EntityNotFoundException(typeof(Client), $"{client.Clientid},{client.Siteid}");
			}
			client.CopyCommonFieldUpdatePrev(client4Update, systemTime, dbContext.Tid, text);
			client.CopyExtensionCollection(client4Update);
			list.Add(client4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
