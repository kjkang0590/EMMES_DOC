using System;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.PMS;

[MESAPI]
public class PROCESSNODE
{
	private static string _sqlGetProcessNodeSqlDatabase = "SELECT * FROM CIM_PROCESSNODE WHERE PROCESSNODEID=@PROCESSNODEID AND SITEID=@SITEID";

	private static string _sqlGetProcessNode4UpdateSqlDatabase = "SELECT * FROM CIM_PROCESSNODE WITH(UPDLOCK) WHERE PROCESSNODEID=@PROCESSNODEID AND SITEID=@SITEID";

	private static string _sqlSelectProcessNodeSqlDatabase = "SELECT * FROM CIM_PROCESSNODE WHERE PROCESSNODEID=@PROCESSNODEID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessNode4UpdateSqlDatabase = "SELECT * FROM CIM_PROCESSNODE WITH(UPDLOCK) WHERE PROCESSNODEID=@PROCESSNODEID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetProcessNodeOracleDatabase = "SELECT * FROM CIM_PROCESSNODE WHERE PROCESSNODEID=:PROCESSNODEID AND SITEID=:SITEID";

	private static string _sqlGetProcessNode4UpdateOracleDatabase = "SELECT * FROM CIM_PROCESSNODE WHERE PROCESSNODEID=:PROCESSNODEID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectProcessNodeOracleDatabase = "SELECT * FROM CIM_PROCESSNODE WHERE PROCESSNODEID=:PROCESSNODEID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessNode4UpdateOracleDatabase = "SELECT * FROM CIM_PROCESSNODE WHERE PROCESSNODEID=:PROCESSNODEID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Processnode);

	private static string _sqlSelectNextProcessNodeListSqlDatabase = "SELECT NEXTNODE.* FROM CIM_PROCESSPATH PATH  JOIN CIM_PROCESSNODE NEXTNODE  ON PATH.NEXTPROCESSNODEID=NEXTNODE.PROCESSNODEID AND PATH.SITEID=NEXTNODE.SITEID AND NEXTNODE.ISUSABLE='Usable' WHERE CASE WHEN @PATHID IS NULL OR @PATHID='' OR PATH.PROCESSPATHID=@PATHID THEN 1 ELSE 0 END = 1 AND PATH.PROCESSNODEID=@CURRPROCESSNODEID AND PATH.ISUSABLE='Usable' AND PATH.SITEID=@SITEID";

	private static string _sqlSelectNextProcessNodeListOracleDatabase = "SELECT NEXTNODE.* FROM CIM_PROCESSPATH PATH JOIN CIM_PROCESSNODE NEXTNODE ON PATH.NEXTPROCESSNODEID=NEXTNODE.PROCESSNODEID AND PATH.SITEID=NEXTNODE.SITEID AND NEXTNODE.ISUSABLE='Usable' WHERE CASE WHEN :PATHID IS NULL OR :PATHID='' OR PATH.PROCESSPATHID=:PATHID THEN 1 ELSE 0 END = 1 AND PATH.PROCESSNODEID=:CURRPROCESSNODEID AND PATH.ISUSABLE='Usable' AND PATH.SITEID=:SITEID";

	private static Type typeOfProcessPath = typeof(Processpath);

	private static string _sqlSelectProcessDefinitionNodeSqlDatabase_1 = "SELECT * FROM CIM_PROCESSNODE WHERE PROCESSDEFINITIONID=@TOPPROCESSDEFINITIONID AND SUBPROCESSDEFINITIONID=@SUBPROCESSDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessDefinitionNodeSqlDatabase_2 = "SELECT * FROM CIM_PROCESSNODE WHERE PROCESSDEFINITIONID=@TOPPROCESSDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessDefinitionNodeOracleDatabase_1 = "SELECT * FROM CIM_PROCESSNODE WHERE PROCESSDEFINITIONID=:TOPPROCESSDEFINITIONID AND SUBPROCESSDEFINITIONID=:SUBPROCESSDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessDefinitionNodeOracleDatabase_2 = "SELECT * FROM CIM_PROCESSNODE WHERE PROCESSDEFINITIONID=:TOPPROCESSDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessDefinitionNodeListSqlDatabase = "SELECT * FROM CIM_PROCESSNODE WHERE PROCESSDEFINITIONID=@PPROCESSDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessDefinitionNodeListOracleDatabase = "SELECT * FROM CIM_PROCESSNODE WHERE PROCESSDEFINITIONID=:PPROCESSDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessNodeListSqlDatabase = "SELECT * FROM CIM_PROCESSNODE WHERE PROCESSDEFINITIONID=@PROCESSDEFINITIONID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessNodeListOracleDatabase = "SELECT * FROM CIM_PROCESSNODE WHERE PROCESSDEFINITIONID=:PROCESSDEFINITIONID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessStartNodeSqlDatabase = "SELECT * FROM CIM_PROCESSNODE  WHERE PROCESSDEFINITIONID=@PROCESSDEFINITIONID AND SITEID=@SITEID AND ISSTARTNODE='Y' AND ISUSABLE='Usable'";

	private static string _sqlSelectProcessStartNodeOracleDatabase = "SELECT * FROM CIM_PROCESSNODE WHERE PROCESSDEFINITIONID=:PROCESSDEFINITIONID AND SITEID=:SITEID AND ISSTARTNODE='Y' AND ISUSABLE='Usable'";

	public static Processnode GetProcessNode(IDbContext dbContext, string processnodeid, string siteid)
	{
		string apiName = "GetProcessNode";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processnodeid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProcessNodeSqlDatabase : _sqlGetProcessNodeOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSNODEID", processnodeid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PROCESSNODE", $"{processnodeid},{siteid}"));
		}
		Processnode? result = ContextManager.DirectEntityQuery<Processnode>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processnodeid},{siteid}");
		}
		return result;
	}

	public static Processnode GetProcessNode4Update(IDbContext dbContext, string processnodeid, string siteid)
	{
		string apiName = "GetProcessNode4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processnodeid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetProcessNode4UpdateSqlDatabase : _sqlGetProcessNode4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSNODEID", processnodeid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PROCESSNODE", $"{processnodeid},{siteid}"));
		}
		Processnode? result = ContextManager.DirectEntityQuery<Processnode>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processnodeid},{siteid}");
		}
		return result;
	}

	public static Processnode SelectProcessNode(IDbContext dbContext, string processnodeid, string siteid)
	{
		string apiName = "SelectProcessNode";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processnodeid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessNodeSqlDatabase : _sqlSelectProcessNodeOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSNODEID", processnodeid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_PROCESSNODE", $"{processnodeid},{siteid}"));
		}
		Processnode? result = ContextManager.DirectEntityQuery<Processnode>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processnodeid},{siteid}");
		}
		return result;
	}

	public static Processnode SelectProcessNode4Update(IDbContext dbContext, string processnodeid, string siteid)
	{
		string apiName = "SelectProcessNode4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processnodeid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessNode4UpdateSqlDatabase : _sqlSelectProcessNode4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSNODEID", processnodeid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_PROCESSNODE", $"{processnodeid},{siteid}"));
		}
		Processnode? result = ContextManager.DirectEntityQuery<Processnode>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processnodeid},{siteid}");
		}
		return result;
	}

	public static int UpsertProcessNode(IDbContext dbContext, RequestType requestType, Processnode[] processNodeList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateProcessNodeInternal(dbContext, processNodeList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateProcessNode(dbContext, processNodeList, optionSet, saveHist), 
			RequestType.DELETE => DeleteProcessNode(dbContext, processNodeList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteProcessNode(dbContext, processNodeList, optionSet, saveHist), 
			_ => RealDeleteProcessNode(dbContext, processNodeList, optionSet, saveHist), 
		};
	}

	private static int CreateProcessNodeInternal(IDbContext dbContext, Processnode[] processNodeList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processNodeList", processNodeList);
		string text = "CreateProcessNode";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processnode> list = new List<Processnode>();
		foreach (Processnode obj in processNodeList)
		{
			Processnode processnode = new Processnode();
			obj.CopyColumsTo(processnode);
			processnode.Activity = text;
			processnode.CheckEntityUsable();
			obj.CopyCommonField(processnode, systemTime, dbContext.Tid, isCreate: true);
			list.Add(processnode);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateProcessNode(IDbContext dbContext, Processnode[] processNodeList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processNodeList", processNodeList);
		string text = "UpdateProcessNode";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processnode> list = new List<Processnode>();
		foreach (Processnode processnode in processNodeList)
		{
			Processnode processNode4Update = GetProcessNode4Update(dbContext, processnode.Processnodeid, processnode.Siteid);
			if (processNode4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processnode), $"{processnode.Processnodeid},{processnode.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Processnode), $"{processnode.Processnodeid},{processnode.Siteid}", processNode4Update.Isusable);
			string activity = processNode4Update.Activity;
			string customactivity = processNode4Update.Customactivity;
			string isusable = processNode4Update.Isusable;
			DateTime? createtime = processNode4Update.Createtime;
			string creator = processNode4Update.Creator;
			processnode.CopyColumsTo(processNode4Update);
			processNode4Update.Prevactivity = activity;
			processNode4Update.Prevcustomactivity = customactivity;
			processNode4Update.Creator = creator;
			processNode4Update.Createtime = createtime;
			processNode4Update.Isusable = isusable;
			processNode4Update.Activity = text;
			processnode.CopyCommonField(processNode4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(processNode4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteProcessNode(IDbContext dbContext, Processnode[] processNodeList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processNodeList", processNodeList);
		string text = "DeleteProcessNode";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processnode> list = new List<Processnode>();
		foreach (Processnode processnode in processNodeList)
		{
			Processnode processNode4Update = GetProcessNode4Update(dbContext, processnode.Processnodeid, processnode.Siteid);
			if (processNode4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processnode), $"{processnode.Processnodeid},{processnode.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Processnode), $"{processnode.Processnodeid},{processnode.Siteid}", processNode4Update.Isusable);
			processNode4Update.Isusable = "UnUsable";
			processnode.CopyCommonFieldUpdatePrev(processNode4Update, systemTime, dbContext.Tid, text);
			processnode.CopyExtensionCollection(processNode4Update);
			list.Add(processNode4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteProcessNode(IDbContext dbContext, Processnode[] processNodeList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processNodeList", processNodeList);
		string text = "UnDeleteProcessNode";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processnode> list = new List<Processnode>();
		foreach (Processnode processnode in processNodeList)
		{
			Processnode processNode4Update = GetProcessNode4Update(dbContext, processnode.Processnodeid, processnode.Siteid);
			if (processNode4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processnode), $"{processnode.Processnodeid},{processnode.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Processnode), $"{processnode.Processnodeid},{processnode.Siteid}", processNode4Update.Isusable);
			processNode4Update.Isusable = "Usable";
			processnode.CopyCommonFieldUpdatePrev(processNode4Update, systemTime, dbContext.Tid, text);
			processnode.CopyExtensionCollection(processNode4Update);
			list.Add(processNode4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteProcessNode(IDbContext dbContext, Processnode[] processNodeList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("processNodeList", processNodeList);
		string text = "RealDeleteProcessNode";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Processnode> list = new List<Processnode>();
		foreach (Processnode processnode in processNodeList)
		{
			Processnode processNode4Update = GetProcessNode4Update(dbContext, processnode.Processnodeid, processnode.Siteid);
			if (processNode4Update == null)
			{
				throw new EntityNotFoundException(typeof(Processnode), $"{processnode.Processnodeid},{processnode.Siteid}");
			}
			processnode.CopyCommonFieldUpdatePrev(processNode4Update, systemTime, dbContext.Tid, text);
			processnode.CopyExtensionCollection(processNode4Update);
			list.Add(processNode4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static IList<Processnode> SelectNextProcessNodeList(IDbContext dbContext, string currentNodeId, string pathId, string siteId)
	{
		string apiName = "SelectNextProcessNodeList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{currentNodeId}.{pathId}.{siteId}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectNextProcessNodeListSqlDatabase : _sqlSelectNextProcessNodeListOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("CURRPROCESSNODEID", currentNodeId, typeOfProcessPath));
		list.Add(dbContext.CreateParameter("PATHID", pathId, typeOfProcessPath));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfProcessPath));
		IList<Processnode> result = ContextManager.DirectEntityQuery<Processnode>(dbContext, sql, list.ToArray(), fetchCustomColumns: false);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{currentNodeId}.{pathId}.{siteId}");
		}
		return result;
	}

	public static IList<Processnode> SelectNextSegmentNodeList(IDbContext dbContext, string topProcessDefinitionId, string processNodeId, string pathType, string siteId)
	{
		string apiName = "SelectNextSegmentNodeList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{topProcessDefinitionId}.{processNodeId}.{pathType}.{siteId}");
		}
		List<Processnode> list = new List<Processnode>();
		Processnode processnode = SelectProcessNode(dbContext, processNodeId, siteId);
		if (processnode == null)
		{
			throw new EntityNotFoundException(typeof(Processnode), processNodeId);
		}
		foreach (Processnode item in SelectNextProcessNodeList(dbContext, processNodeId, pathType, siteId))
		{
			if (item.Processnodetype == "P")
			{
				Processnode processnode2 = SelectProcessStartSegmentNode(dbContext, item.Subprocessdefinitionid, siteId);
				if (processnode2 != null)
				{
					list.Add(processnode2);
				}
			}
			else
			{
				Processnode processnode3 = SelectProcessNode(dbContext, item.Processnodeid, siteId);
				if (processnode3 != null)
				{
					list.Add(processnode3);
				}
			}
		}
		if (processnode.Isendnode == "Y")
		{
			string processdefinitionid = processnode.Processdefinitionid;
			Processnode processnode4 = SelectProcessDefinitionNode(dbContext, topProcessDefinitionId, processdefinitionid, siteId);
			if (processnode4 != null)
			{
				IList<Processnode> collection = SelectNextSegmentNodeList(dbContext, topProcessDefinitionId, processnode4.Processnodeid, pathType, siteId);
				list.AddRange(collection);
			}
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{topProcessDefinitionId}.{processNodeId}.{pathType}.{siteId}");
		}
		return list;
	}

	public static Processnode SelectNextSegmentNodeSingle(IDbContext dbContext, string topProcessDefinitionId, string processNodeId, string pathType, string siteId)
	{
		string apiName = "SelectNextSegmentNodeSingle";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{topProcessDefinitionId}.{processNodeId}.{pathType}.{siteId}");
		}
		IList<Processnode> list = SelectNextSegmentNodeList(dbContext, topProcessDefinitionId, processNodeId, pathType, siteId);
		if (list.Count > 1)
		{
			throw new MultipleNextNodesExistException(typeof(Processnode), processNodeId, string.Join(", ", list.Select((Processnode node) => node.Processnodeid).ToArray()));
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{topProcessDefinitionId}.{processNodeId}.{pathType}.{siteId}");
		}
		return list.FirstOrDefault();
	}

	public static Processnode SelectNextSegmentNodeSingleBySegment(IDbContext dbContext, string topProcessDefinitionId, string currentNodeId, string nextProcessSegmentid, string siteId)
	{
		string apiName = "SelectNextSegmentNodeSingleBySegment";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{topProcessDefinitionId}.{currentNodeId}.{nextProcessSegmentid}.{siteId}");
		}
		IList<Processnode> list = (from node in SelectNextSegmentNodeList(dbContext, topProcessDefinitionId, currentNodeId, null, siteId)
			where node.Processsegmentid == nextProcessSegmentid
			select node).ToList();
		if (list.Count > 1)
		{
			throw new MultipleNextNodesExistException(typeof(Processnode), currentNodeId, string.Join(", ", list.Select((Processnode node) => node.Processnodeid).ToArray()));
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{topProcessDefinitionId}.{currentNodeId}.{nextProcessSegmentid}.{siteId}");
		}
		return list.FirstOrDefault();
	}

	public static Processnode SelectProcessDefinitionNode(IDbContext dbContext, string topProcessDefinitionId, string subProcessDefinitionId, string siteId)
	{
		string apiName = "SelectProcessDefinitionNode";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{topProcessDefinitionId}.{subProcessDefinitionId}.{siteId}");
		}
		string text = null;
		List<MesParameter> list = new List<MesParameter>();
		text = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessDefinitionNodeSqlDatabase_1 : _sqlSelectProcessDefinitionNodeOracleDatabase_1);
		list.Add(dbContext.CreateParameter("TOPPROCESSDEFINITIONID", topProcessDefinitionId, typeOfThis));
		list.Add(dbContext.CreateParameter("SUBPROCESSDEFINITIONID", subProcessDefinitionId, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		IList<Processnode> source = ContextManager.DirectEntityQuery<Processnode>(dbContext, text, list.ToArray(), fetchCustomColumns: false);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{topProcessDefinitionId}.{subProcessDefinitionId}.{siteId}");
		}
		return source.FirstOrDefault();
	}

	public static IList<Processnode> SelectProcessDefinitionNodeList(IDbContext dbContext, string processDefinitionId, string siteId)
	{
		string apiName = "SelectProcessDefinitionNode";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processDefinitionId}.{siteId}");
		}
		string text = null;
		List<MesParameter> list = new List<MesParameter>();
		text = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessDefinitionNodeListSqlDatabase : _sqlSelectProcessDefinitionNodeListOracleDatabase);
		list.Add(dbContext.CreateParameter("PPROCESSDEFINITIONID", processDefinitionId, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		IList<Processnode> result = ContextManager.DirectEntityQuery<Processnode>(dbContext, text, list.ToArray(), fetchCustomColumns: false);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processDefinitionId}.{siteId}");
		}
		return result;
	}

	public static Processnode SelectProcessNode(IDbContext dbContext, string processDefinitionId, string subProcessOrSegmentId, string siteId, string nodeType, bool searchSubProcess)
	{
		string apiName = "SelectProcessDefinitionNode";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processDefinitionId}.{subProcessOrSegmentId}.{siteId}.{nodeType}.{searchSubProcess}");
		}
		IEnumerable<Processnode> source = from node in SelectProcessNodeList(dbContext, processDefinitionId, siteId, nodeType, searchSubProcess)
			where node.Subprocessdefinitionid == subProcessOrSegmentId || node.Processsegmentid == subProcessOrSegmentId
			select node;
		if (source.Count() > 1)
		{
			throw new MultipleNodesFoundException(processDefinitionId, subProcessOrSegmentId);
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processDefinitionId}.{subProcessOrSegmentId}.{siteId}.{nodeType}.{searchSubProcess}");
		}
		return source.FirstOrDefault();
	}

	public static IList<Processnode> SelectProcessNodeList(IDbContext dbContext, string processDefinitionId, string siteId, string nodeType, bool searchSubProcess)
	{
		string apiName = "SelectProcessNodeList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processDefinitionId}.{siteId}.{nodeType}.{searchSubProcess}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessNodeListSqlDatabase : _sqlSelectProcessNodeListOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSDEFINITIONID", processDefinitionId, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		IList<Processnode> list2 = ContextManager.DirectEntityQuery<Processnode>(dbContext, sql, list.ToArray(), fetchCustomColumns: false);
		List<Processnode> list3 = new List<Processnode>();
		foreach (Processnode item in list2)
		{
			if (!string.IsNullOrEmpty(nodeType))
			{
				if (item.Processnodetype == nodeType)
				{
					list3.Add(item);
				}
			}
			else
			{
				list3.Add(item);
			}
			if (searchSubProcess && nodeType != "P" && item.Processnodetype == "P")
			{
				list3.AddRange(SelectProcessNodeList(dbContext, item.Subprocessdefinitionid, siteId, "S", searchSubProcess: false));
			}
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processDefinitionId}.{siteId}.{nodeType}.{searchSubProcess}");
		}
		return list3;
	}

	public static Processnode SelectProcessSegmentNode(IDbContext dbContext, string topProcessDefinitionId, string processSegmentId, string siteId)
	{
		string apiName = "SelectProcessSegmentNode";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{topProcessDefinitionId}.{processSegmentId}.{siteId}");
		}
		Processnode result = SelectProcessNode(dbContext, topProcessDefinitionId, processSegmentId, siteId, "S", searchSubProcess: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{topProcessDefinitionId}.{processSegmentId}.{siteId}");
		}
		return result;
	}

	public static Processnode SelectProcessSegmentNode(IDbContext dbContext, string topProcessDefinitionId, string subProcessDefinitionId, string processSegmentId, string siteId)
	{
		string apiName = "SelectProcessSegmentNode";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{topProcessDefinitionId}.{subProcessDefinitionId}.{processSegmentId}.{siteId}");
		}
		Processnode processnode = SelectProcessDefinitionNode(dbContext, topProcessDefinitionId, subProcessDefinitionId, siteId);
		Processnode processnode2 = null;
		processnode2 = ((processnode == null) ? SelectProcessNode(dbContext, topProcessDefinitionId, processSegmentId, siteId, "S", searchSubProcess: false) : SelectProcessNode(dbContext, processnode.Subprocessdefinitionid, processSegmentId, siteId, "S", searchSubProcess: false));
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{topProcessDefinitionId}.{subProcessDefinitionId}.{processSegmentId}.{siteId}");
		}
		return processnode2;
	}

	public static Processnode SelectProcessStartSegmentNode(IDbContext dbContext, string processDefinitionId, string siteId)
	{
		string apiName = "SelectNextSegmentNodeList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processDefinitionId}.{siteId}");
		}
		Processnode processnode = SelectProcessStartNode(dbContext, processDefinitionId, siteId);
		if (processnode != null && processnode.Processnodetype == "P")
		{
			processnode = SelectProcessStartNode(dbContext, processnode.Subprocessdefinitionid, siteId);
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processDefinitionId}.{siteId}");
		}
		return processnode;
	}

	internal static Processnode SelectProcessStartNode(IDbContext dbContext, string processDefinitionId, string siteId)
	{
		string apiName = "SelectProcessStartNode";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{processDefinitionId}.{siteId}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectProcessStartNodeSqlDatabase : _sqlSelectProcessStartNodeOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("PROCESSDEFINITIONID", processDefinitionId, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		IList<Processnode> source = ContextManager.DirectEntityQuery<Processnode>(dbContext, sql, list.ToArray(), fetchCustomColumns: false);
		if (source.Count() > 1)
		{
			throw new MultipleStartNodesExistException(processDefinitionId, string.Join(", ", source.Select((Processnode node) => node.Processnodeid).ToArray()));
		}
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{processDefinitionId}.{siteId}");
		}
		return source.FirstOrDefault();
	}
}
