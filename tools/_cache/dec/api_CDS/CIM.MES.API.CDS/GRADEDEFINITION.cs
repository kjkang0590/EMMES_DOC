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
public class GRADEDEFINITION
{
	private static string _sqlGetGradeDefinitionSqlDatabase = "SELECT * FROM CIM_GRADEDEFINITION WHERE GRADETYPE=@GRADETYPE AND GRADEID=@GRADEID AND SITEID=@SITEID";

	private static string _sqlGetGradeDefinition4UpdateSqlDatabase = "SELECT * FROM CIM_GRADEDEFINITION WITH(UPDLOCK) WHERE GRADETYPE=@GRADETYPE AND GRADEID=@GRADEID AND SITEID=@SITEID";

	private static string _sqlSelectGradeDefinitionSqlDatabase = "SELECT * FROM CIM_GRADEDEFINITION WHERE GRADETYPE=@GRADETYPE AND GRADEID=@GRADEID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectGradeDefinition4UpdateSqlDatabase = "SELECT * FROM CIM_GRADEDEFINITION WITH(UPDLOCK) WHERE GRADETYPE=@GRADETYPE AND GRADEID=@GRADEID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetGradeDefinitionOracleDatabase = "SELECT * FROM CIM_GRADEDEFINITION WHERE GRADETYPE=:GRADETYPE AND GRADEID=:GRADEID AND SITEID=:SITEID";

	private static string _sqlGetGradeDefinition4UpdateOracleDatabase = "SELECT * FROM CIM_GRADEDEFINITION WHERE GRADETYPE=:GRADETYPE AND GRADEID=:GRADEID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectGradeDefinitionOracleDatabase = "SELECT * FROM CIM_GRADEDEFINITION WHERE GRADETYPE=:GRADETYPE AND GRADEID=:GRADEID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectGradeDefinition4UpdateOracleDatabase = "SELECT * FROM CIM_GRADEDEFINITION WHERE GRADETYPE=:GRADETYPE AND GRADEID=:GRADEID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Gradedefinition);

	private static string _sqlSelectCountableGradeDefinitionSqlDatabase = "SELECT GRADEID FROM CIM_GRADEDEFINITION WHERE GRADETYPE=@GRADETYPE AND SITEID=@SITEID AND ISCOUNT=@ISCOUNT AND ISUSABLE='Usable'";

	private static string _sqlSelectCountableGradeDefinitionOracleDatabase = "SELECT GRADEID FROM CIM_GRADEDEFINITION WHERE GRADETYPE=:GRADETYPE AND SITEID=:SITEID AND ISCOUNT=:ISCOUNT AND ISUSABLE='Usable'";

	private static string _sqlSelectDefaultGradeDefinitionSqlDatabase = "SELECT * FROM CIM_GRADEDEFINITION WHERE GRADETYPE=@GRADETYPE AND SITEID=@SITEID AND ISDEFAULT=@ISDEFAULT AND ISUSABLE='Usable'";

	private static string _sqlSelectDefaultGradeDefinitionOracleDatabase = "SELECT * FROM CIM_GRADEDEFINITION WHERE GRADETYPE=:GRADETYPE AND SITEID=:SITEID AND ISDEFAULT=:ISDEFAULT AND ISUSABLE='Usable'";

	private static string _sqlSelectUnCountableGradeDefinitionSqlDatabase = "SELECT GRADEID FROM CIM_GRADEDEFINITION WHERE GRADETYPE=@GRADETYPE AND SITEID=@SITEID AND ISCOUNT<>@ISCOUNT AND ISUSABLE='Usable'";

	private static string _sqlSelectUnCountableGradeDefinitionOracleDatabase = "SELECT GRADEID FROM CIM_GRADEDEFINITION WHERE GRADETYPE=:GRADETYPE AND SITEID=:SITEID AND ISCOUNT<>:ISCOUNT AND ISUSABLE='Usable'";

	public static Gradedefinition GetGradeDefinition(IDbContext dbContext, string gradetype, string gradeid, string siteid)
	{
		string apiName = "GetGradeDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{gradetype},{gradeid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetGradeDefinitionSqlDatabase : _sqlGetGradeDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("GRADETYPE", gradetype, typeOfThis));
		list.Add(dbContext.CreateParameter("GRADEID", gradeid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_GRADEDEFINITION", $"{gradetype},{gradeid},{siteid}"));
		}
		Gradedefinition? result = ContextManager.DirectEntityQuery<Gradedefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{gradetype},{gradeid},{siteid}");
		}
		return result;
	}

	public static Gradedefinition GetGradeDefinition4Update(IDbContext dbContext, string gradetype, string gradeid, string siteid)
	{
		string apiName = "GetGradeDefinition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{gradetype},{gradeid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetGradeDefinition4UpdateSqlDatabase : _sqlGetGradeDefinition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("GRADETYPE", gradetype, typeOfThis));
		list.Add(dbContext.CreateParameter("GRADEID", gradeid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_GRADEDEFINITION", $"{gradetype},{gradeid},{siteid}"));
		}
		Gradedefinition? result = ContextManager.DirectEntityQuery<Gradedefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{gradetype},{gradeid},{siteid}");
		}
		return result;
	}

	public static Gradedefinition SelectGradeDefinition(IDbContext dbContext, string gradetype, string gradeid, string siteid)
	{
		string apiName = "SelectGradeDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{gradetype},{gradeid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectGradeDefinitionSqlDatabase : _sqlSelectGradeDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("GRADETYPE", gradetype, typeOfThis));
		list.Add(dbContext.CreateParameter("GRADEID", gradeid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_GRADEDEFINITION", $"{gradetype},{gradeid},{siteid}"));
		}
		Gradedefinition? result = ContextManager.DirectEntityQuery<Gradedefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{gradetype},{gradeid},{siteid}");
		}
		return result;
	}

	public static Gradedefinition SelectGradeDefinition4Update(IDbContext dbContext, string gradetype, string gradeid, string siteid)
	{
		string apiName = "SelectGradeDefinition4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{gradetype},{gradeid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectGradeDefinition4UpdateSqlDatabase : _sqlSelectGradeDefinition4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("GRADETYPE", gradetype, typeOfThis));
		list.Add(dbContext.CreateParameter("GRADEID", gradeid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_GRADEDEFINITION", $"{gradetype},{gradeid},{siteid}"));
		}
		Gradedefinition? result = ContextManager.DirectEntityQuery<Gradedefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{gradetype},{gradeid},{siteid}");
		}
		return result;
	}

	public static string GenerateSubMaterialGradeString(string gradeId, decimal? subMaterialQty)
	{
		if (string.IsNullOrEmpty(gradeId))
		{
			return "";
		}
		if (subMaterialQty.HasValue)
		{
			decimal? num = subMaterialQty;
			if (!((num.GetValueOrDefault() == default(decimal)) & num.HasValue))
			{
				string text = "";
				for (int i = 0; (double)i < (double)subMaterialQty.Value; i++)
				{
					text += gradeId;
				}
				return text;
			}
		}
		return "";
	}

	public static IList<string> SelectCountableGradeIdList(IDbContext dbContext, string gradetype, string siteid)
	{
		string apiName = "SelectCountableGradeIdList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{gradetype},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectCountableGradeDefinitionSqlDatabase : _sqlSelectCountableGradeDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("GRADETYPE", gradetype, typeOfThis));
		list.Add(dbContext.CreateParameter("ISCOUNT", "Y", typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		List<string> result = (from r in ContextManager.DirectEntityQuery<Gradedefinition>(dbContext, sql, list.ToArray())
			select r.Gradeid).ToList();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{gradetype},{siteid}");
		}
		return result;
	}

	public static Gradedefinition SelectDefaultGradeDefinition(IDbContext dbContext, string gradetype, string siteid)
	{
		string apiName = "SelectDefaultGradeDefinition";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{gradetype},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectDefaultGradeDefinitionSqlDatabase : _sqlSelectDefaultGradeDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("GRADETYPE", gradetype, typeOfThis));
		list.Add(dbContext.CreateParameter("ISDEFAULT", "Y", typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		Gradedefinition? result = ContextManager.DirectEntityQuery<Gradedefinition>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{gradetype},{siteid}");
		}
		return result;
	}

	public static string SelectDefaultGradeId(IDbContext dbContext, string gradetype, string siteid)
	{
		string apiName = "SelectDefaultGradeId";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{gradetype},{siteid}");
		}
		Gradedefinition gradedefinition = SelectDefaultGradeDefinition(dbContext, gradetype, siteid);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{gradetype},{siteid}");
		}
		if (gradedefinition != null)
		{
			return gradedefinition.Gradeid;
		}
		return "";
	}

	public static IList<string> SelectUnCountableGradeIdList(IDbContext dbContext, string gradeType, string siteId)
	{
		string apiName = "SelectUnCountableGradeIdList";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{gradeType},{siteId}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectUnCountableGradeDefinitionSqlDatabase : _sqlSelectUnCountableGradeDefinitionOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("GRADETYPE", gradeType, typeOfThis));
		list.Add(dbContext.CreateParameter("ISCOUNT", "Y", typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		List<string> result = (from r in ContextManager.DirectEntityQuery<Gradedefinition>(dbContext, sql, list.ToArray())
			select r.Gradeid).ToList();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{gradeType},{siteId}");
		}
		return result;
	}

	public static int UpsertGradeDefinition(IDbContext dbContext, RequestType requestType, Gradedefinition[] gradeDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateGradeDefinitionInternal(dbContext, gradeDefinitionList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateGradeDefinition(dbContext, gradeDefinitionList, optionSet, saveHist), 
			RequestType.DELETE => DeleteGradeDefinition(dbContext, gradeDefinitionList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteGradeDefinition(dbContext, gradeDefinitionList, optionSet, saveHist), 
			_ => RealDeleteGradeDefinition(dbContext, gradeDefinitionList, optionSet, saveHist), 
		};
	}

	private static int CreateGradeDefinitionInternal(IDbContext dbContext, Gradedefinition[] gradeDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("gradeDefinitionList", gradeDefinitionList);
		string text = "CreateGradeDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Gradedefinition> list = new List<Gradedefinition>();
		foreach (Gradedefinition obj in gradeDefinitionList)
		{
			Gradedefinition gradedefinition = new Gradedefinition();
			obj.CopyColumsTo(gradedefinition);
			gradedefinition.Activity = text;
			gradedefinition.CheckEntityUsable();
			obj.CopyCommonField(gradedefinition, systemTime, dbContext.Tid, isCreate: true);
			list.Add(gradedefinition);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateGradeDefinition(IDbContext dbContext, Gradedefinition[] gradeDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("gradeDefinitionList", gradeDefinitionList);
		string text = "UpdateGradeDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Gradedefinition> list = new List<Gradedefinition>();
		foreach (Gradedefinition gradedefinition in gradeDefinitionList)
		{
			Gradedefinition gradeDefinition4Update = GetGradeDefinition4Update(dbContext, gradedefinition.Gradetype, gradedefinition.Gradeid, gradedefinition.Siteid);
			if (gradeDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Gradedefinition), $"{gradedefinition.Gradetype},{gradedefinition.Gradeid},{gradedefinition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Gradedefinition), $"{gradedefinition.Gradetype},{gradedefinition.Gradeid},{gradedefinition.Siteid}", gradeDefinition4Update.Isusable);
			string activity = gradeDefinition4Update.Activity;
			string customactivity = gradeDefinition4Update.Customactivity;
			string isusable = gradeDefinition4Update.Isusable;
			DateTime? createtime = gradeDefinition4Update.Createtime;
			string creator = gradeDefinition4Update.Creator;
			gradedefinition.CopyColumsTo(gradeDefinition4Update);
			gradeDefinition4Update.Prevactivity = activity;
			gradeDefinition4Update.Prevcustomactivity = customactivity;
			gradeDefinition4Update.Creator = creator;
			gradeDefinition4Update.Createtime = createtime;
			gradeDefinition4Update.Isusable = isusable;
			gradeDefinition4Update.Activity = text;
			gradedefinition.CopyCommonField(gradeDefinition4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(gradeDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteGradeDefinition(IDbContext dbContext, Gradedefinition[] gradeDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("gradeDefinitionList", gradeDefinitionList);
		string text = "DeleteGradeDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Gradedefinition> list = new List<Gradedefinition>();
		foreach (Gradedefinition gradedefinition in gradeDefinitionList)
		{
			Gradedefinition gradeDefinition4Update = GetGradeDefinition4Update(dbContext, gradedefinition.Gradetype, gradedefinition.Gradeid, gradedefinition.Siteid);
			if (gradeDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Gradedefinition), $"{gradedefinition.Gradetype},{gradedefinition.Gradeid},{gradedefinition.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Gradedefinition), $"{gradedefinition.Gradetype},{gradedefinition.Gradeid},{gradedefinition.Siteid}", gradeDefinition4Update.Isusable);
			gradeDefinition4Update.Isusable = "UnUsable";
			gradedefinition.CopyCommonFieldUpdatePrev(gradeDefinition4Update, systemTime, dbContext.Tid, text);
			gradedefinition.CopyExtensionCollection(gradeDefinition4Update);
			list.Add(gradeDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteGradeDefinition(IDbContext dbContext, Gradedefinition[] gradeDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("gradeDefinitionList", gradeDefinitionList);
		string text = "UnDeleteGradeDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Gradedefinition> list = new List<Gradedefinition>();
		foreach (Gradedefinition gradedefinition in gradeDefinitionList)
		{
			Gradedefinition gradeDefinition4Update = GetGradeDefinition4Update(dbContext, gradedefinition.Gradetype, gradedefinition.Gradeid, gradedefinition.Siteid);
			if (gradeDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Gradedefinition), $"{gradedefinition.Gradetype},{gradedefinition.Gradeid},{gradedefinition.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Gradedefinition), $"{gradedefinition.Gradetype},{gradedefinition.Gradeid},{gradedefinition.Siteid}", gradeDefinition4Update.Isusable);
			gradeDefinition4Update.Isusable = "Usable";
			gradedefinition.CopyCommonFieldUpdatePrev(gradeDefinition4Update, systemTime, dbContext.Tid, text);
			gradedefinition.CopyExtensionCollection(gradeDefinition4Update);
			list.Add(gradeDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteGradeDefinition(IDbContext dbContext, Gradedefinition[] gradeDefinitionList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("gradeDefinitionList", gradeDefinitionList);
		string text = "RealDeleteGradeDefinition";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Gradedefinition> list = new List<Gradedefinition>();
		foreach (Gradedefinition gradedefinition in gradeDefinitionList)
		{
			Gradedefinition gradeDefinition4Update = GetGradeDefinition4Update(dbContext, gradedefinition.Gradetype, gradedefinition.Gradeid, gradedefinition.Siteid);
			if (gradeDefinition4Update == null)
			{
				throw new EntityNotFoundException(typeof(Gradedefinition), $"{gradedefinition.Gradetype},{gradedefinition.Gradeid},{gradedefinition.Siteid}");
			}
			gradedefinition.CopyCommonFieldUpdatePrev(gradeDefinition4Update, systemTime, dbContext.Tid, text);
			gradedefinition.CopyExtensionCollection(gradeDefinition4Update);
			list.Add(gradeDefinition4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
