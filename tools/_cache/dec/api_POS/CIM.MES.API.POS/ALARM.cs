using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Common.Data;
using CIM.MES.Common.MessageSet;
using CIM.MES.Configuration;
using CIM.MES.Entity;
using CIM.MES.Framework;
using CIM.MES.Framework.Rule;
using CIM.MES.Logging;
using CIM.Util.Email;

namespace CIM.MES.API.POS;

[MESAPI]
public class ALARM
{
	private static string _sqlGetAlarmSqlDatabase = "SELECT * FROM CIM_ALARM WHERE ALARMSYSID=@ALARMSYSID AND SITEID=@SITEID";

	private static string _sqlGetAlarm4UpdateSqlDatabase = "SELECT * FROM CIM_ALARM WITH(UPDLOCK) WHERE ALARMSYSID=@ALARMSYSID AND SITEID=@SITEID";

	private static string _sqlSelectAlarmSqlDatabase = "SELECT * FROM CIM_ALARM WHERE ALARMSYSID=@ALARMSYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectAlarm4UpdateSqlDatabase = "SELECT * FROM CIM_ALARM WITH(UPDLOCK) WHERE ALARMSYSID=@ALARMSYSID AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetAlarmOracleDatabase = "SELECT * FROM CIM_ALARM WHERE ALARMSYSID=:ALARMSYSID AND SITEID=:SITEID";

	private static string _sqlGetAlarm4UpdateOracleDatabase = "SELECT * FROM CIM_ALARM WHERE ALARMSYSID=:ALARMSYSID AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectAlarmOracleDatabase = "SELECT * FROM CIM_ALARM WHERE ALARMSYSID=:ALARMSYSID AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectAlarm4UpdateOracleDatabase = "SELECT * FROM CIM_ALARM WHERE ALARMSYSID=:ALARMSYSID AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Alarm);

	public static Alarm GetAlarm(IDbContext dbContext, string alarmsysid, string siteid)
	{
		string apiName = "GetAlarm";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{alarmsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetAlarmSqlDatabase : _sqlGetAlarmOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ALARMSYSID", alarmsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_ALARM", $"{alarmsysid},{siteid}"));
		}
		Alarm? result = ContextManager.DirectEntityQuery<Alarm>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{alarmsysid},{siteid}");
		}
		return result;
	}

	public static Alarm GetAlarm4Update(IDbContext dbContext, string alarmsysid, string siteid)
	{
		string apiName = "GetAlarm4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{alarmsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetAlarm4UpdateSqlDatabase : _sqlGetAlarm4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ALARMSYSID", alarmsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_ALARM", $"{alarmsysid},{siteid}"));
		}
		Alarm? result = ContextManager.DirectEntityQuery<Alarm>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{alarmsysid},{siteid}");
		}
		return result;
	}

	public static Alarm SelectAlarm(IDbContext dbContext, string alarmsysid, string siteid)
	{
		string apiName = "SelectAlarm";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{alarmsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectAlarmSqlDatabase : _sqlSelectAlarmOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ALARMSYSID", alarmsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_ALARM", $"{alarmsysid},{siteid}"));
		}
		Alarm? result = ContextManager.DirectEntityQuery<Alarm>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{alarmsysid},{siteid}");
		}
		return result;
	}

	public static Alarm SelectAlarm4Update(IDbContext dbContext, string alarmsysid, string siteid)
	{
		string apiName = "SelectAlarm4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{alarmsysid},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectAlarm4UpdateSqlDatabase : _sqlSelectAlarm4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("ALARMSYSID", alarmsysid, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_ALARM", $"{alarmsysid},{siteid}"));
		}
		Alarm? result = ContextManager.DirectEntityQuery<Alarm>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{alarmsysid},{siteid}");
		}
		return result;
	}

	public static int UpsertAlarm(IDbContext dbContext, RequestType requestType, Alarm[] alarmList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateAlarmInternal(dbContext, alarmList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateAlarm(dbContext, alarmList, optionSet, saveHist), 
			RequestType.DELETE => DeleteAlarm(dbContext, alarmList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteAlarm(dbContext, alarmList, optionSet, saveHist), 
			_ => RealDeleteAlarm(dbContext, alarmList, optionSet, saveHist), 
		};
	}

	private static int CreateAlarmInternal(IDbContext dbContext, Alarm[] alarmList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmList", alarmList);
		string text = "CreateAlarm";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarm> list = new List<Alarm>();
		foreach (Alarm obj in alarmList)
		{
			Alarm alarm = new Alarm();
			obj.CopyColumsTo(alarm);
			alarm.Activity = text;
			alarm.CheckEntityUsable();
			obj.CopyCommonField(alarm, systemTime, dbContext.Tid, isCreate: true);
			list.Add(alarm);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateAlarm(IDbContext dbContext, Alarm[] alarmList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmList", alarmList);
		string text = "UpdateAlarm";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarm> list = new List<Alarm>();
		foreach (Alarm alarm in alarmList)
		{
			Alarm alarm4Update = GetAlarm4Update(dbContext, alarm.Alarmsysid, alarm.Siteid);
			if (alarm4Update == null)
			{
				throw new EntityNotFoundException(typeof(Alarm), $"{alarm.Alarmsysid},{alarm.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Alarm), $"{alarm.Alarmsysid},{alarm.Siteid}", alarm4Update.Isusable);
			string activity = alarm4Update.Activity;
			string customactivity = alarm4Update.Customactivity;
			string isusable = alarm4Update.Isusable;
			DateTime? createtime = alarm4Update.Createtime;
			string creator = alarm4Update.Creator;
			alarm.CopyColumsTo(alarm4Update);
			alarm4Update.Prevactivity = activity;
			alarm4Update.Prevcustomactivity = customactivity;
			alarm4Update.Creator = creator;
			alarm4Update.Createtime = createtime;
			alarm4Update.Isusable = isusable;
			alarm4Update.Activity = text;
			alarm.CopyCommonField(alarm4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(alarm4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteAlarm(IDbContext dbContext, Alarm[] alarmList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmList", alarmList);
		string text = "DeleteAlarm";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarm> list = new List<Alarm>();
		foreach (Alarm alarm in alarmList)
		{
			Alarm alarm4Update = GetAlarm4Update(dbContext, alarm.Alarmsysid, alarm.Siteid);
			if (alarm4Update == null)
			{
				throw new EntityNotFoundException(typeof(Alarm), $"{alarm.Alarmsysid},{alarm.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Alarm), $"{alarm.Alarmsysid},{alarm.Siteid}", alarm4Update.Isusable);
			alarm4Update.Isusable = "UnUsable";
			alarm.CopyCommonFieldUpdatePrev(alarm4Update, systemTime, dbContext.Tid, text);
			alarm.CopyExtensionCollection(alarm4Update);
			list.Add(alarm4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteAlarm(IDbContext dbContext, Alarm[] alarmList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmList", alarmList);
		string text = "UnDeleteAlarm";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarm> list = new List<Alarm>();
		foreach (Alarm alarm in alarmList)
		{
			Alarm alarm4Update = GetAlarm4Update(dbContext, alarm.Alarmsysid, alarm.Siteid);
			if (alarm4Update == null)
			{
				throw new EntityNotFoundException(typeof(Alarm), $"{alarm.Alarmsysid},{alarm.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Alarm), $"{alarm.Alarmsysid},{alarm.Siteid}", alarm4Update.Isusable);
			alarm4Update.Isusable = "Usable";
			alarm.CopyCommonFieldUpdatePrev(alarm4Update, systemTime, dbContext.Tid, text);
			alarm.CopyExtensionCollection(alarm4Update);
			list.Add(alarm4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteAlarm(IDbContext dbContext, Alarm[] alarmList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("alarmList", alarmList);
		string text = "RealDeleteAlarm";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarm> list = new List<Alarm>();
		foreach (Alarm alarm in alarmList)
		{
			Alarm alarm4Update = GetAlarm4Update(dbContext, alarm.Alarmsysid, alarm.Siteid);
			if (alarm4Update == null)
			{
				throw new EntityNotFoundException(typeof(Alarm), $"{alarm.Alarmsysid},{alarm.Siteid}");
			}
			alarm.CopyCommonFieldUpdatePrev(alarm4Update, systemTime, dbContext.Tid, text);
			alarm.CopyExtensionCollection(alarm4Update);
			list.Add(alarm4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int ClearAlarm(IDbContext dbContext, Alarm[] inputAlarmList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inputAlarmList", inputAlarmList);
		string text = "ClearAlarm";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		int num = 0;
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		List<Alarm> list = new List<Alarm>();
		foreach (Alarm alarm in inputAlarmList)
		{
			ParamChecker.ArgumentNotNull("Alarmsysid", alarm.Alarmsysid);
			ParamChecker.ArgumentNotNull("Siteid", alarm.Siteid);
			string siteid = alarm.Siteid;
			Alarm alarm2 = SelectAlarm4Update(dbContext, alarm.Alarmsysid, siteid);
			if (alarm2 == null)
			{
				throw new EntityNotFoundException(typeof(Alarm), $"{alarm.Alarmsysid},{alarm.Siteid}");
			}
			alarm2.State = "Clear";
			alarm2.Isusable = "UnUsable";
			alarm.CopyCommonFieldUpdatePrev(alarm2, systemTime, alarm.Tid, text);
			list.Add(alarm2);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	public static int ExecuteAlarmAction(IDbContext dbContext, Alarm alarm, ExecuteAlarmActionOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNull("alarm", alarm);
		string text = "ExecuteAlarmAction";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		ContextManager.GetSystemTime(dbContext);
		int num = 0;
		new List<Alarmactioninfo>();
		string alarmdefinitionid = alarm.Alarmdefinitionid;
		string alarmsourceid = alarm.Alarmsourceid;
		string alarmtype = alarm.Alarmtype;
		string nextTID = ContextManager.GetNextTID();
		string siteid = alarm.Siteid;
		string emailbody = null;
		bool flag = true;
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("ALARMDEFINITIONID", alarmdefinitionid);
		dictionary.Add("ALARMSOURCEID", alarmsourceid);
		dictionary.Add("ALARMTYPE", alarmtype);
		List<Alarmdefactionrel> source = ALARMDEFACTIONREL.SelectAlarmDefActionRelWithDynamicCondition(dbContext, dictionary, siteid).ToList();
		int num2 = 0;
		foreach (Alarmdefactionrel item in source.OrderBy((Alarmdefactionrel r) => r.Actionsequence))
		{
			bool flag2 = "Y".Equals(item.Isautoaction);
			string alarmactionid = item.Alarmactionid;
			if (ALARMACTION.SelectAlarmAction(dbContext, alarmactionid, siteid) == null)
			{
				throw new EntityNotFoundException(typeof(Alarmaction), alarmactionid);
			}
			if (!flag2)
			{
				break;
			}
			string text2 = null;
			if ("EMAIL".Equals(alarmactionid.ToUpper()))
			{
				text2 = item.Actionuserclassid;
				if (string.IsNullOrEmpty(text2))
				{
					continue;
				}
				string[] toAddress = SelectUserEmailList(dbContext, siteid, text2);
				string emailtitle = item.Emailtitle;
				string text3 = CreateAlarmInfoEmailBody(alarm, flag);
				string text4 = item.Emailbody;
				if (string.IsNullOrEmpty(text4))
				{
					text4 = text3;
					emailbody = text4;
				}
				else if (text4.Contains("[%USERPARAM]"))
				{
					text4 = text4.Replace("[%USERPARAM]", text3);
					emailbody = text4;
				}
				new SmtpEmailUtil(dbContext.Resolve<IMesConfiguration>()).SendEmailWithCredential(null, toAddress, emailtitle, text4, null, null, null, flag);
			}
			else
			{
				MessageData messageData = null;
				try
				{
					MessageData messageData2 = new MessageData();
					messageData2.COMMAND = alarmactionid;
					messageData2.DATADIC = optionSet?.ActionRuleParameter;
					messageData = dbContext.Resolve<IMesRuleManager>().RunMesRule(messageData2);
				}
				catch (Exception ex)
				{
					if (MesLogger.IsErrorEnabled("EXCEPTION"))
					{
						MesLogger.ErrorTid(dbContext.Tid, text, ex.ToString());
					}
					throw ex;
				}
				if (messageData == null || !messageData.ISSUCCESS)
				{
					if (MesLogger.IsErrorEnabled("EXCEPTION"))
					{
						MesLogger.ErrorTid(dbContext.Tid, text + "-" + alarmactionid, messageData.EXCEPTIONMESSAGE);
					}
					break;
				}
			}
			if (num2 == 0)
			{
				Alarm alarm2 = new Alarm();
				alarm.CopyColumsTo(alarm2);
				Alarmactioninfo alarmactioninfo = new Alarmactioninfo();
				alarm2.CopySameColumnsTo(alarmactioninfo, copyExtensionCollection: true);
				alarmactioninfo.Alarmactioninfosysid = nextTID;
				alarmactioninfo.Alarmactionid = item.Alarmactionid;
				alarmactioninfo.Emailbody = emailbody;
				alarmactioninfo.Actionuserclassid = text2;
				alarmactioninfo.Actionuserlist = string.Join(",", SelectUserList(dbContext, siteid, text2));
				num += ALARMACTIONINFO.UpsertAlarmActionInfo(dbContext, RequestType.CREATE, new Alarmactioninfo[1] { alarmactioninfo }, new OptionSet(), saveHist: true);
			}
			else
			{
				Alarmactioninfo alarmactioninfo2 = ALARMACTIONINFO.SelectAlarmActionInfo(dbContext, nextTID, siteid);
				Alarm alarm3 = new Alarm();
				alarm.CopyColumsTo(alarm3);
				alarmactioninfo2 = new Alarmactioninfo();
				alarm3.CopySameColumnsTo(alarmactioninfo2, copyExtensionCollection: true);
				alarmactioninfo2.Alarmactionid = item.Alarmactionid;
				alarmactioninfo2.Emailbody = emailbody;
				alarmactioninfo2.Actionuserclassid = text2;
				alarmactioninfo2.Actionuserlist = string.Join(",", SelectUserList(dbContext, siteid, text2));
				num += ALARMACTIONINFO.UpsertAlarmActionInfo(dbContext, RequestType.UPDATE, new Alarmactioninfo[1] { alarmactioninfo2 }, new OptionSet(), saveHist: true);
			}
			num2++;
		}
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static string[] SelectUserEmailList(IDbContext dbContext, string siteId, string userClassId)
	{
		List<string> list = new List<string>();
		string text = "SELECT*FROM CIM_USERCLASSREL WHERE SITEID=@SITEID AND ISUSABLE=@ISUSABLE AND USERCLASSID=@USERCLASSID";
		string text2 = "SELECT*FROM CIM_USERCLASSREL WHERE SITEID=:SITEID AND ISUSABLE=:ISUSABLE AND USERCLASSID=:USERCLASSID";
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? text : text2);
		List<MesParameter> list2 = new List<MesParameter>();
		list2.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		list2.Add(dbContext.CreateParameter("ISUSABLE", "Usable", typeOfThis));
		list2.Add(dbContext.CreateParameter("USERCLASSID", userClassId, typeOfThis));
		string[] array = (from r in ContextManager.DirectEntityQuery<Userclassrel>(dbContext, sql, list2.ToArray(), fetchCustomColumns: true)
			select r.Userid).Distinct().ToArray();
		foreach (string userid in array)
		{
			User user = USER.SelectUser(dbContext, userid, siteId);
			list.Add(user.Emailaddress);
		}
		return list.ToArray();
	}

	private static string[] SelectUserList(IDbContext dbContext, string siteId, string userClassId)
	{
		string text = "SELECT*FROM CIM_USERCLASSREL WHERE SITEID=@SITEID AND ISUSABLE=@ISUSABLE AND USERCLASSID=@USERCLASSID";
		string text2 = "SELECT*FROM CIM_USERCLASSREL WHERE SITEID=:SITEID AND ISUSABLE=:ISUSABLE AND USERCLASSID=:USERCLASSID";
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? text : text2);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("SITEID", siteId, typeOfThis));
		list.Add(dbContext.CreateParameter("ISUSABLE", "Usable", typeOfThis));
		list.Add(dbContext.CreateParameter("USERCLASSID", userClassId, typeOfThis));
		return (from r in ContextManager.DirectEntityQuery<Userclassrel>(dbContext, sql, list.ToArray(), fetchCustomColumns: true)
			select r.Userid).Distinct().ToArray();
	}

	private static string CreateAlarmInfoEmailBody(Alarm alarm, bool isHtml)
	{
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		if (isHtml)
		{
			stringBuilder.AppendLine("<br>");
		}
		else
		{
			stringBuilder.AppendLine();
		}
		PropertyInfo[] properties = alarm.GetType().GetProperties();
		foreach (PropertyInfo propertyInfo in properties)
		{
			if ("KEYCOLLECTION".Equals(propertyInfo.Name.ToUpper()) || "ENTITYSTATE".Equals(propertyInfo.Name.ToUpper()) || "ENTITYKEY".Equals(propertyInfo.Name.ToUpper()))
			{
				continue;
			}
			if ("VALUECOLLECTION".Equals(propertyInfo.Name.ToUpper()))
			{
				if (!(propertyInfo.ReflectedType == typeof(Hashtable)))
				{
					continue;
				}
				Hashtable hashtable = (Hashtable)propertyInfo.GetValue(alarm, null);
				foreach (string key in hashtable.Keys)
				{
					stringBuilder2.AppendLine(string.Join(":", key, Convert.ToString(hashtable[key])));
					if (isHtml)
					{
						stringBuilder.AppendLine("<br>");
					}
				}
			}
			else
			{
				stringBuilder.AppendLine(string.Join(":", propertyInfo.Name, Convert.ToString(propertyInfo.GetValue(alarm, null))));
				if (isHtml)
				{
					stringBuilder.AppendLine("<br>");
				}
			}
		}
		stringBuilder.AppendLine(stringBuilder2.ToString());
		return stringBuilder.ToString();
	}

	public static int SetAlarm(IDbContext dbContext, Alarm[] inputAlarmList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("inputAlarmList", inputAlarmList);
		string text = "ClearAlarm";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Alarm> list = new List<Alarm>();
		foreach (Alarm alarm in inputAlarmList)
		{
			ParamChecker.ArgumentNotNull("Alarmdefinitionid", alarm.Alarmdefinitionid);
			ParamChecker.ArgumentNotNull("Siteid", alarm.Siteid);
			string alarmdefinitionid = alarm.Alarmdefinitionid;
			string siteid = alarm.Siteid;
			string nextTID = ContextManager.GetNextTID();
			Alarmdefinition alarmdefinition = null;
			Alarm alarm2 = new Alarm();
			alarm.CopyColumsTo(alarm2);
			alarm2.Alarmsysid = nextTID;
			if ((alarmdefinition = ALARMDEFINITION.SelectAlarmDefinition(dbContext, alarmdefinitionid, alarm.Alarmsourceid, alarm.Alarmtype, siteid)) == null)
			{
				throw new EntityNotFoundException(typeof(Alarmdefinition), $"{alarmdefinitionid},{alarm.Alarmsourceid},{alarm.Alarmtype},{siteid}");
			}
			alarm2.Alarmclassid = alarmdefinition.Alarmclassid;
			alarm2.Alarmtype = alarmdefinition.Alarmtype;
			alarm2.Alarmlevel = alarmdefinition.Alarmlevel;
			alarm2.State = "Active";
			alarm2.Activity = text;
			alarm2.Isusable = "Usable";
			alarm.CopyCommonField(alarm2, systemTime, dbContext.Tid, isCreate: true);
			list.Add(alarm2);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
