using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Logging;

namespace CIM.MES.API.POS;

[MESAPI]
public class IDINDEX
{
	private static object _generateSyncObject = new object();

	private static string _sqlGetIdIndexSqlDatabase = "SELECT * FROM CIM_IDINDEX WHERE IDINDEXID=@IDINDEXID AND SITEID=@SITEID";

	private static string _sqlGetIdIndex4UpdateSqlDatabase = "SELECT * FROM CIM_IDINDEX WITH(UPDLOCK) WHERE IDINDEXID=@IDINDEXID AND SITEID=@SITEID";

	private static string _sqlSelectIdIndexSqlDatabase = "SELECT * FROM CIM_IDINDEX WHERE IDINDEXID=@IDINDEXID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectIdIndex4UpdateSqlDatabase = "SELECT * FROM CIM_IDINDEX WITH(UPDLOCK) WHERE IDINDEXID=@IDINDEXID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetIdIndexOracleDatabase = "SELECT * FROM CIM_IDINDEX WHERE IDINDEXID=:IDINDEXID AND SITEID=:SITEID";

	private static string _sqlGetIdIndex4UpdateOracleDatabase = "SELECT * FROM CIM_IDINDEX WHERE IDINDEXID=:IDINDEXID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectIdIndexOracleDatabase = "SELECT * FROM CIM_IDINDEX WHERE IDINDEXID=:IDINDEXID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectIdIndex4UpdateOracleDatabase = "SELECT * FROM CIM_IDINDEX WHERE IDINDEXID=:IDINDEXID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Idindex);

	private static string _sqlSelectIdIndexListByPatternSqlDatabase = "SELECT * FROM CIM_IDINDEX WHERE IDPATTERNID=@IDPATTERNID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectIdIndexListByPatternOracleDatabase = "SELECT * FROM CIM_IDINDEX WHERE IDPATTERNID=:IDPATTERNID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectIdIndexListByPatternIndexNameSqlDatabase = "SELECT * FROM CIM_IDINDEX WHERE IDPATTERNID=@IDPATTERNID AND IDINDEXNAME=@IDINDEXNAME AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectIdIndexListByPatternIndexNameOracleDatabase = "SELECT * FROM CIM_IDINDEX WHERE IDPATTERNID=:IDPATTERNID AND IDINDEXNAME=:IDINDEXNAME AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectIdIndexListByPatternLikeNameSqlDatabase = "SELECT * FROM CIM_IDINDEX WHERE IDPATTERNID=@IDPATTERNID AND IDINDEXNAME LIKE @IDINDEXNAME AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectIdIndexListByPatternLikeNameOracleDatabase = "SELECT * FROM CIM_IDINDEX WHERE IDPATTERNID=:IDPATTERNID AND IDINDEXNAME LIKE :IDINDEXNAME AND SITEID=:SITEID AND ISUSABLE='Usable'";

	public static IList<string> GenerateIdByPattern(IDbContext dbContext, string idPatternId, string siteId, CommonSet commonSet, int count, bool commit, params string[] userDefineList)
	{
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi("GenerateIdByPattern"));
		IList<string> result = GenerateIdByPattern(dbContext, idPatternId, siteId, commonSet, count, commit, DateTime.Now, userDefineList);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi("GenerateIdByPattern"));
		return result;
	}

	public static IList<string> GenerateIdByPattern(IDbContext dbContext, string idPatternId, string siteId, CommonSet commonSet, int count, bool commit, DateTime currentTime, params string[] userDefineList)
	{
		List<string> list = null;
		bool flag = true;
		string text = "";
		Idindex idindex = null;
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		Idpattern idpattern = IDPATTERN.SelectIdPattern(dbContext, idPatternId, siteId);
		if (idpattern == null)
		{
			throw new EntityNotFoundException(typeof(Idpattern), idPatternId);
		}
		_ = idpattern.Format;
		if (!idpattern.Format.Contains("%"))
		{
			IList<Idindex> list2 = SelectIdIndexListByPattern(dbContext, idPatternId, siteId);
			if (list2.Count == 0)
			{
				flag = true;
			}
			else
			{
				idindex = list2.FirstOrDefault();
				_ = idindex.Idindexid;
				flag = false;
			}
		}
		else
		{
			ParamChecker.ArgumentNotNull("userDefineList", userDefineList);
			int num = idpattern.Format.Count((char ch) => ch == '%');
			if (num != userDefineList.Length)
			{
				throw new ArgumentOutOfRangeException("<%USERPARAM> Count: " + num + ", UserDefine Count: " + userDefineList.Length);
			}
			if (num > 0)
			{
				string[] stringToFormat = IdPatternModel.GetStringToFormat(idpattern.Format);
				foreach (KeyValuePair<string, string> item in GetPatternString(idpattern.Format, stringToFormat, 0, userDefineList, currentTime))
				{
					if (!item.Key.Contains("<"))
					{
						text += item.Value;
					}
				}
				IList<Idindex> list3 = SelectIdIndexListByPatternLikeName(dbContext, idPatternId, text, siteId);
				Idindex idindex2 = null;
				if (list3 != null && list3.Count > 0)
				{
					idindex2 = SelectIdIndex4Update(dbContext, list3.First().Idindexid, siteId);
				}
				idindex = idindex2;
				if (idindex == null)
				{
					flag = true;
				}
				else
				{
					flag = false;
					_ = idindex.Idindexid;
				}
			}
			else
			{
				flag = true;
			}
		}
		if (flag)
		{
			return idIndexCreate(dbContext, idindex, idpattern, siteId, commonSet, count, commit, systemTime, currentTime, userDefineList);
		}
		return idIndexUpdate(dbContext, idindex, idpattern, siteId, commonSet, count, commit, systemTime, currentTime, userDefineList);
	}

	private static List<string> idIndexCreate(IDbContext dbContext, Idindex idIndex, Idpattern idPattern, string siteId, CommonSet commonSet, int count, bool commit, DateTime workTime, DateTime currentTime, params string[] userDefineList)
	{
		List<string> list = new List<string>();
		string text = "";
		int num = 0;
		int num2 = 1;
		string text2 = "";
		string[] array = null;
		ArrayList arrayList = null;
		Idindex idindex = new Idindex();
		idindex.Idindexid = ContextManager.GetNextTID();
		idindex.Idpatternid = idPattern.Idpatternid;
		idindex.Siteid = siteId;
		if (!string.IsNullOrEmpty(idPattern.Startserial))
		{
			idindex.Currentindex = idPattern.Startserial;
		}
		else
		{
			idindex.Currentindex = "0";
		}
		num = int.Parse(idindex.Currentindex);
		array = IdPatternModel.GetStringToFormat(idPattern.Format);
		for (int i = 0; i < count; i++)
		{
			text = "";
			text2 = "";
			arrayList = GetPatternString(idPattern.Format, array, num, userDefineList, currentTime);
			if (i != count - 1)
			{
				num += num2;
			}
			foreach (KeyValuePair<string, string> item in arrayList)
			{
				if (!item.Key.Contains("<"))
				{
					text2 += item.Value;
				}
				text += item.Value;
			}
			list.Add(text);
		}
		idindex.Currentindex = num.ToString();
		idindex.Idindexname = text2;
		if (int.TryParse(idPattern.Endserial, out var result) && num > result)
		{
			throw new SerialOverflowException(num.ToString(), result.ToString());
		}
		commonSet.CopyCommonField(idindex, workTime, dbContext.Tid, isCreate: true);
		if (commit)
		{
			UpsertIdIndex(dbContext, RequestType.CREATE, new Idindex[1] { idindex }, null, saveHist: false);
		}
		arrayList?.Clear();
		return list;
	}

	private static List<string> idIndexUpdate(IDbContext dbContext, Idindex idIndex, Idpattern idPattern, string siteId, CommonSet commonSet, int count, bool commit, DateTime workTime, DateTime currentTime, params string[] userDefineList)
	{
		List<string> list = new List<string>();
		string text = "";
		int num = 0;
		int num2 = 1;
		string text2 = "";
		string[] array = null;
		ArrayList arrayList = null;
		if (idIndex.Currentindex != null)
		{
			num = int.Parse(idIndex.Currentindex);
		}
		array = IdPatternModel.GetStringToFormat(idPattern.Format);
		for (int i = 0; i < count; i++)
		{
			num += num2;
			text = "";
			text2 = "";
			arrayList = GetPatternString(idPattern.Format, array, num, userDefineList, currentTime);
			foreach (KeyValuePair<string, string> item in arrayList)
			{
				if (!item.Key.Contains("<"))
				{
					text2 += item.Value;
				}
				text += item.Value;
			}
			list.Add(text);
			arrayList?.Clear();
		}
		if (idIndex.Idindexname != text2)
		{
			num = ((!string.IsNullOrEmpty(idPattern.Startserial)) ? int.Parse(idPattern.Startserial) : 0);
			list = new List<string>();
			for (int j = 0; j < count; j++)
			{
				text = "";
				arrayList = GetPatternString(idPattern.Format, array, num, userDefineList, currentTime);
				if (j != count - 1)
				{
					num += num2;
				}
				foreach (KeyValuePair<string, string> item2 in arrayList)
				{
					text += item2.Value;
				}
				list.Add(text);
				arrayList?.Clear();
			}
		}
		idIndex.Idindexname = text2;
		idIndex.Currentindex = num.ToString();
		if (int.TryParse(idPattern.Endserial, out var result) && num > result)
		{
			throw new SerialOverflowException(num.ToString(), result.ToString());
		}
		commonSet.CopyCommonField(idIndex, workTime, dbContext.Tid, isCreate: false);
		if (commit)
		{
			UpsertIdIndex(dbContext, RequestType.UPDATE, new Idindex[1] { idIndex }, null, saveHist: false);
		}
		arrayList?.Clear();
		return list;
	}

	private static ArrayList GetPatternString(string format, string[] formats, int currentSerial, string[] userDefineList, DateTime currentTime)
	{
		ArrayList arrayList = new ArrayList();
		string text = "";
		int num = 0;
		for (int i = 0; i < formats.Length; i++)
		{
			text = (formats[i].Contains("<") ? formats[i].Substring(0, formats[i].IndexOf("<")) : ((!formats[i].Contains("YA@")) ? formats[i] : formats[i].Substring(0, formats[i].IndexOf("@") + 1)));
			switch (text)
			{
			case "Y":
			case "YY":
			case "Y1":
			case "YYYY":
				arrayList.Add(new KeyValuePair<string, string>(text, IdPatternModel.Convert_Year(text, currentTime)));
				break;
			case "YA@":
				arrayList.Add(new KeyValuePair<string, string>(text, IdPatternModel.Convert_YAS(formats[i], currentTime)));
				break;
			case "M":
			case "MM":
			case "M1":
			case "MA":
				arrayList.Add(new KeyValuePair<string, string>(text, IdPatternModel.Convert_Month(text, currentTime)));
				break;
			case "D":
			case "DD":
			case "D1":
			case "DDD":
				arrayList.Add(new KeyValuePair<string, string>(text, IdPatternModel.Convert_Day(text, currentTime)));
				break;
			case "WEEK":
				arrayList.Add(new KeyValuePair<string, string>(text, IdPatternModel.Convert_WeekOfMonth(currentTime)));
				break;
			case "SERALPH":
				arrayList.Add(new KeyValuePair<string, string>(formats[i], IdPatternModel.Convert_SERALPH(formats[i], currentSerial)));
				break;
			case "SERHEX":
				arrayList.Add(new KeyValuePair<string, string>(formats[i], IdPatternModel.Convert_SERHEX(formats[i], currentSerial)));
				break;
			case "SERNUM":
				arrayList.Add(new KeyValuePair<string, string>(formats[i], IdPatternModel.Convert_SERNUM(formats[i], currentSerial)));
				break;
			case "SERMIXED":
				arrayList.Add(new KeyValuePair<string, string>(formats[i], IdPatternModel.Convert_SERMIXED(formats[i], currentSerial)));
				break;
			case "%USERPARAM":
				arrayList.Add(new KeyValuePair<string, string>(formats[i], userDefineList[num]));
				num++;
				break;
			case "SERNUMEXTALPH":
				arrayList.Add(new KeyValuePair<string, string>(formats[i], IdPatternModel.Convert_SERNUMEXTALPH(formats[i], currentSerial)));
				break;
			case "SERHEX1NUM1":
				arrayList.Add(new KeyValuePair<string, string>(formats[i], IdPatternModel.Convert_SERHEX1NUM1(formats[i], currentSerial)));
				break;
			default:
				arrayList.Add(new KeyValuePair<string, string>(i.ToString(), text));
				break;
			}
		}
		return arrayList;
	}

	public static Idindex GetIdIndex(IDbContext dbContext, string idindexid, string siteid)
	{
		string apiName = "GetIdIndex";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{idindexid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetIdIndexSqlDatabase : _sqlGetIdIndexOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("IDINDEXID", idindexid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_IDINDEX", $"{idindexid},{siteid}"));
		}
		Idindex? result = ContextManager.DirectEntityQuery<Idindex>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{idindexid},{siteid}");
		}
		return result;
	}

	public static Idindex GetIdIndex4Update(IDbContext dbContext, string idindexid, string siteid)
	{
		string apiName = "GetIdIndex4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{idindexid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetIdIndex4UpdateSqlDatabase : _sqlGetIdIndex4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("IDINDEXID", idindexid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_IDINDEX", $"{idindexid},{siteid}"));
		}
		Idindex? result = ContextManager.DirectEntityQuery<Idindex>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{idindexid},{siteid}");
		}
		return result;
	}

	public static Idindex SelectIdIndex(IDbContext dbContext, string idindexid, string siteid)
	{
		string apiName = "SelectIdIndex";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{idindexid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectIdIndexSqlDatabase : _sqlSelectIdIndexOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("IDINDEXID", idindexid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_IDINDEX", $"{idindexid},{siteid}"));
		}
		Idindex? result = ContextManager.DirectEntityQuery<Idindex>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{idindexid},{siteid}");
		}
		return result;
	}

	public static Idindex SelectIdIndex4Update(IDbContext dbContext, string idindexid, string siteid)
	{
		string apiName = "SelectIdIndex4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{idindexid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectIdIndex4UpdateSqlDatabase : _sqlSelectIdIndex4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("IDINDEXID", idindexid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_IDINDEX", $"{idindexid},{siteid}"));
		}
		Idindex? result = ContextManager.DirectEntityQuery<Idindex>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{idindexid},{siteid}");
		}
		return result;
	}

	public static int UpsertIdIndex(IDbContext dbContext, RequestType requestType, Idindex[] idIndexList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateIdIndexInternal(dbContext, idIndexList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateIdIndex(dbContext, idIndexList, optionSet, saveHist), 
			RequestType.DELETE => DeleteIdIndex(dbContext, idIndexList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteIdIndex(dbContext, idIndexList, optionSet, saveHist), 
			_ => RealDeleteIdIndex(dbContext, idIndexList, optionSet, saveHist), 
		};
	}

	private static int CreateIdIndexInternal(IDbContext dbContext, Idindex[] idIndexList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("idIndexList", idIndexList);
		string text = "CreateIdIndex";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Idindex> list = new List<Idindex>();
		foreach (Idindex obj in idIndexList)
		{
			Idindex idindex = new Idindex();
			obj.CopyColumsTo(idindex);
			idindex.Activity = text;
			idindex.CheckEntityUsable();
			obj.CopyCommonField(idindex, systemTime, dbContext.Tid, isCreate: true);
			list.Add(idindex);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateIdIndex(IDbContext dbContext, Idindex[] idIndexList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("idIndexList", idIndexList);
		string text = "UpdateIdIndex";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Idindex> list = new List<Idindex>();
		foreach (Idindex idindex in idIndexList)
		{
			Idindex idIndex4Update = GetIdIndex4Update(dbContext, idindex.Idindexid, idindex.Siteid);
			if (idIndex4Update == null)
			{
				throw new EntityNotFoundException(typeof(Idindex), $"{idindex.Idindexid},{idindex.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Idindex), $"{idindex.Idindexid},{idindex.Siteid}", idIndex4Update.Isusable);
			string activity = idIndex4Update.Activity;
			string customactivity = idIndex4Update.Customactivity;
			string isusable = idIndex4Update.Isusable;
			DateTime? createtime = idIndex4Update.Createtime;
			string creator = idIndex4Update.Creator;
			idindex.CopyColumsTo(idIndex4Update);
			idIndex4Update.Prevactivity = activity;
			idIndex4Update.Prevcustomactivity = customactivity;
			idIndex4Update.Creator = creator;
			idIndex4Update.Createtime = createtime;
			idIndex4Update.Isusable = isusable;
			idIndex4Update.Activity = text;
			idindex.CopyCommonField(idIndex4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(idIndex4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteIdIndex(IDbContext dbContext, Idindex[] idIndexList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("idIndexList", idIndexList);
		string text = "DeleteIdIndex";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Idindex> list = new List<Idindex>();
		foreach (Idindex idindex in idIndexList)
		{
			Idindex idIndex4Update = GetIdIndex4Update(dbContext, idindex.Idindexid, idindex.Siteid);
			if (idIndex4Update == null)
			{
				throw new EntityNotFoundException(typeof(Idindex), $"{idindex.Idindexid},{idindex.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Idindex), $"{idindex.Idindexid},{idindex.Siteid}", idIndex4Update.Isusable);
			idIndex4Update.Isusable = "UnUsable";
			idindex.CopyCommonFieldUpdatePrev(idIndex4Update, systemTime, dbContext.Tid, text);
			idindex.CopyExtensionCollection(idIndex4Update);
			list.Add(idIndex4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteIdIndex(IDbContext dbContext, Idindex[] idIndexList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("idIndexList", idIndexList);
		string text = "UnDeleteIdIndex";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Idindex> list = new List<Idindex>();
		foreach (Idindex idindex in idIndexList)
		{
			Idindex idIndex4Update = GetIdIndex4Update(dbContext, idindex.Idindexid, idindex.Siteid);
			if (idIndex4Update == null)
			{
				throw new EntityNotFoundException(typeof(Idindex), $"{idindex.Idindexid},{idindex.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Idindex), $"{idindex.Idindexid},{idindex.Siteid}", idIndex4Update.Isusable);
			idIndex4Update.Isusable = "Usable";
			idindex.CopyCommonFieldUpdatePrev(idIndex4Update, systemTime, dbContext.Tid, text);
			idindex.CopyExtensionCollection(idIndex4Update);
			list.Add(idIndex4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteIdIndex(IDbContext dbContext, Idindex[] idIndexList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("idIndexList", idIndexList);
		string text = "RealDeleteIdIndex";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Idindex> list = new List<Idindex>();
		foreach (Idindex idindex in idIndexList)
		{
			Idindex idIndex4Update = GetIdIndex4Update(dbContext, idindex.Idindexid, idindex.Siteid);
			if (idIndex4Update == null)
			{
				throw new EntityNotFoundException(typeof(Idindex), $"{idindex.Idindexid},{idindex.Siteid}");
			}
			idindex.CopyCommonFieldUpdatePrev(idIndex4Update, systemTime, dbContext.Tid, text);
			idindex.CopyExtensionCollection(idIndex4Update);
			list.Add(idIndex4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	internal static IList<Idindex> SelectIdIndexListByPattern(IDbContext dbContext, string idPatternId, string siteId)
	{
		string apiName = "SelectIdIndexListByPattern";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{idPatternId},{siteId}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectIdIndexListByPatternSqlDatabase : _sqlSelectIdIndexListByPatternOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("IDPATTERNID", idPatternId, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		IList<Idindex> result = ContextManager.DirectEntityQuery<Idindex>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{idPatternId},{siteId}");
		}
		return result;
	}

	public static IList<Idindex> SelectIdIndexListByPatternIndexName(IDbContext dbContext, string idPatternId, string idIndexName, string siteId)
	{
		string apiName = "SelectIdIndexListByPatternIndexName";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{idPatternId},{idIndexName},{siteId}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectIdIndexListByPatternIndexNameSqlDatabase : _sqlSelectIdIndexListByPatternIndexNameOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("IDPATTERNID", idPatternId, typeOfThis));
		list.Add(dbContext.CreateParameter("IDINDEXNAME", idIndexName, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		IList<Idindex> result = ContextManager.DirectEntityQuery<Idindex>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{idPatternId},{idIndexName},{siteId}");
		}
		return result;
	}

	internal static IList<Idindex> SelectIdIndexListByPatternLikeName(IDbContext dbContext, string idPatternId, string idIndexNameLike, string siteId)
	{
		string apiName = "SelectIdIndexListByPatternLikeName";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{idPatternId},{idIndexNameLike},{siteId}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectIdIndexListByPatternLikeNameSqlDatabase : _sqlSelectIdIndexListByPatternLikeNameOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("IDPATTERNID", idPatternId, typeOfThis));
		list.Add(dbContext.CreateParameter("IDINDEXNAME", idIndexNameLike, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		IList<Idindex> result = ContextManager.DirectEntityQuery<Idindex>(dbContext, sql, list.ToArray(), fetchCustomColumns: true);
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{idPatternId},{idIndexNameLike},{siteId}");
		}
		return result;
	}
}
