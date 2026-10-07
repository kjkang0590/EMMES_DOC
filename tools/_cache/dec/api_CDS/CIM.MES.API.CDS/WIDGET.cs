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
public class WIDGET
{
	private static string _sqlGetWidgetSqlDatabase = "SELECT * FROM CIM_WIDGET WHERE WIDGETID=@WIDGETID AND PRODUCT=@PRODUCT AND WIDGETTYPE=@WIDGETTYPE AND SITEID=@SITEID";

	private static string _sqlGetWidget4UpdateSqlDatabase = "SELECT * FROM CIM_WIDGET WITH(UPDLOCK) WHERE  WIDGETID=@WIDGETID AND PRODUCT=@PRODUCT AND WIDGETTYPE=@WIDGETTYPE AND SITEID=@SITEID";

	private static string _sqlSelectWidgetSqlDatabase = "SELECT * FROM CIM_WIDGET WHERE WIDGETID=@WIDGETID AND PRODUCT=@PRODUCT AND WIDGETTYPE=@WIDGETTYPE AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectWidget4UpdateSqlDatabase = "SELECT * FROM CIM_WIDGET WITH(UPDLOCK) WHERE  WIDGETID=@WIDGETID AND PRODUCT=@PRODUCT AND WIDGETTYPE=@WIDGETTYPE AND SITEID=@SITEID AND ISUSABLE='Usable'";

	private static string _sqlGetWidgetOracleDatabase = "SELECT * FROM CIM_WIDGET WHERE WIDGETID=:WIDGETID AND PRODUCT=:PRODUCT AND WIDGETTYPE=:WIDGETTYPE AND SITEID=:SITEID";

	private static string _sqlGetWidget4UpdateOracleDatabase = "SELECT * FROM CIM_WIDGET WHERE WIDGETID=:WIDGETID AND PRODUCT=:PRODUCT AND WIDGETTYPE=:WIDGETTYPE AND SITEID=:SITEID FOR UPDATE";

	private static string _sqlSelectWidgetOracleDatabase = "SELECT * FROM CIM_WIDGET WHERE WIDGETID=:WIDGETID AND PRODUCT=:PRODUCT AND WIDGETTYPE=:WIDGETTYPE AND SITEID=:SITEID AND ISUSABLE='Usable'";

	private static string _sqlSelectWidget4UpdateOracleDatabase = "SELECT * FROM CIM_WIDGET WHERE WIDGETID=:WIDGETID AND PRODUCT=:PRODUCT AND WIDGETTYPE=:WIDGETTYPE AND SITEID=:SITEID AND ISUSABLE='Usable' FOR UPDATE";

	private static Type typeOfThis = typeof(Widget);

	public static Widget GetWidget(IDbContext dbContext, string widgetid, string product, string widgettype, string siteid)
	{
		string apiName = "GetWidget";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{widgetid},{product},{widgettype},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetWidgetSqlDatabase : _sqlGetWidgetOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("WIDGETID", widgetid, typeOfThis));
		list.Add(dbContext.CreateParameter("PRODUCT", product, typeOfThis));
		list.Add(dbContext.CreateParameter("WIDGETTYPE", widgettype, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_WIDGET", $"{widgetid},{product},{widgettype},{siteid}"));
		}
		Widget result = ContextManager.DirectEntityQuery<Widget>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{widgetid},{product},{widgettype},{siteid}");
		}
		return result;
	}

	public static Widget GetWidget4Update(IDbContext dbContext, string widgetid, string product, string widgettype, string siteid)
	{
		string apiName = "GetWidget4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{widgetid},{product},{widgettype},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlGetWidget4UpdateSqlDatabase : _sqlGetWidget4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("WIDGETID", widgetid, typeOfThis));
		list.Add(dbContext.CreateParameter("PRODUCT", product, typeOfThis));
		list.Add(dbContext.CreateParameter("WIDGETTYPE", widgettype, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_WIDGET", $"{widgetid},{product},{widgettype},{siteid}"));
		}
		Widget result = ContextManager.DirectEntityQuery<Widget>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{widgetid},{product},{widgettype},{siteid}");
		}
		return result;
	}

	public static Widget SelectWidget(IDbContext dbContext, string widgetid, string product, string widgettype, string siteid)
	{
		string apiName = "SelectWidget";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{widgetid},{product},{widgettype},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectWidgetSqlDatabase : _sqlSelectWidgetOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("WIDGETID", widgetid, typeOfThis));
		list.Add(dbContext.CreateParameter("PRODUCT", product, typeOfThis));
		list.Add(dbContext.CreateParameter("WIDGETTYPE", widgettype, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT", "CIM_WIDGET", $"{widgetid},{product},{widgettype},{siteid}"));
		}
		Widget result = ContextManager.DirectEntityQuery<Widget>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{widgetid},{product},{widgettype},{siteid}");
		}
		return result;
	}

	public static Widget SelectWidget4Update(IDbContext dbContext, string widgetid, string product, string widgettype, string siteid)
	{
		string apiName = "SelectWidget4Update";
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.StartApi(apiName), $"{widgetid},{product},{widgettype},{siteid}");
		}
		string sql = ((dbContext.DbType == DatabaseType.SqlDatabase) ? _sqlSelectWidget4UpdateSqlDatabase : _sqlSelectWidget4UpdateOracleDatabase);
		List<MesParameter> list = new List<MesParameter>();
		list.Add(dbContext.CreateParameter("WIDGETID", widgetid, typeOfThis));
		list.Add(dbContext.CreateParameter("PRODUCT", product, typeOfThis));
		list.Add(dbContext.CreateParameter("WIDGETTYPE", widgettype, typeOfThis));
		list.Add(dbContext.CreateParameter("SITEID", siteid, typeOfThis));
		if (MesLogger.IsInfoEnabled("FRAME"))
		{
			MesLogger.InfoTid("FRAME", dbContext.Tid, string.Format("{0}:{1}:{2}", "SELECT4UPDATE", "CIM_WIDGET", $"{widgetid},{product},{widgettype},{siteid}"));
		}
		Widget result = ContextManager.DirectEntityQuery<Widget>(dbContext, sql, list.ToArray(), fetchCustomColumns: true).FirstOrDefault();
		if (MesLogger.IsInfoEnabled("API"))
		{
			MesLogger.InfoTidApi(dbContext.Tid, MesLoggingFormat.EndApi(apiName), $"{widgetid},{product},{widgettype},{siteid}");
		}
		return result;
	}

	public static int UpsertWidget(IDbContext dbContext, RequestType requestType, Widget[] widgetList, IOptionSet optionSet, bool saveHist)
	{
		int num = 0;
		return requestType switch
		{
			RequestType.CREATE => CreateWidgetInternal(dbContext, widgetList, optionSet, saveHist), 
			RequestType.UPDATE => UpdateWidget(dbContext, widgetList, optionSet, saveHist), 
			RequestType.DELETE => DeleteWidget(dbContext, widgetList, optionSet, saveHist), 
			RequestType.UNDELETE => UnDeleteWidget(dbContext, widgetList, optionSet, saveHist), 
			_ => RealDeleteWidget(dbContext, widgetList, optionSet, saveHist), 
		};
	}

	private static int CreateWidgetInternal(IDbContext dbContext, Widget[] widgetList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("widgetList", widgetList);
		string text = "CreateWidget";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Widget> list = new List<Widget>();
		foreach (Widget obj in widgetList)
		{
			Widget widget = new Widget();
			obj.CopyColumsTo(widget);
			widget.Activity = text;
			widget.CheckEntityUsable();
			obj.CopyCommonField(widget, systemTime, dbContext.Tid, isCreate: true);
			list.Add(widget);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.CREATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UpdateWidget(IDbContext dbContext, Widget[] widgetList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("widgetList", widgetList);
		string text = "UpdateWidget";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Widget> list = new List<Widget>();
		foreach (Widget widget in widgetList)
		{
			Widget widget4Update = GetWidget4Update(dbContext, widget.Widgetid, widget.Product, widget.Widgettype, widget.Siteid);
			if (widget4Update == null)
			{
				throw new EntityNotFoundException(typeof(Widget), $"{widget.Widgetid},{widget.Product},{widget.Widgettype},{widget.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Widget), $"{widget.Widgetid},{widget.Product},{widget.Widgettype},{widget.Siteid}", widget4Update.Isusable);
			string activity = widget4Update.Activity;
			string customactivity = widget4Update.Customactivity;
			string isusable = widget4Update.Isusable;
			DateTime? createtime = widget4Update.Createtime;
			string creator = widget4Update.Creator;
			widget.CopyColumsTo(widget4Update);
			widget4Update.Prevactivity = activity;
			widget4Update.Prevcustomactivity = customactivity;
			widget4Update.Creator = creator;
			widget4Update.Createtime = createtime;
			widget4Update.Isusable = isusable;
			widget4Update.Activity = text;
			widget.CopyCommonField(widget4Update, systemTime, dbContext.Tid, isCreate: false);
			list.Add(widget4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int DeleteWidget(IDbContext dbContext, Widget[] widgetList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("widgetList", widgetList);
		string text = "DeleteWidget";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Widget> list = new List<Widget>();
		foreach (Widget widget in widgetList)
		{
			Widget widget4Update = GetWidget4Update(dbContext, widget.Widgetid, widget.Product, widget.Widgettype, widget.Siteid);
			if (widget4Update == null)
			{
				throw new EntityNotFoundException(typeof(Widget), $"{widget.Widgetid},{widget.Product},{widget.Widgettype},{widget.Siteid}");
			}
			ParamChecker.EntityUsable(typeof(Widget), $"{widget.Widgetid},{widget.Product},{widget.Widgettype},{widget.Siteid}", widget4Update.Isusable);
			widget4Update.Isusable = "UnUsable";
			widget.CopyCommonFieldUpdatePrev(widget4Update, systemTime, dbContext.Tid, text);
			widget.CopyExtensionCollection(widget4Update);
			list.Add(widget4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int UnDeleteWidget(IDbContext dbContext, Widget[] widgetList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("widgetList", widgetList);
		string text = "UnDeleteWidget";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Widget> list = new List<Widget>();
		foreach (Widget widget in widgetList)
		{
			Widget widget4Update = GetWidget4Update(dbContext, widget.Widgetid, widget.Product, widget.Widgettype, widget.Siteid);
			if (widget4Update == null)
			{
				throw new EntityNotFoundException(typeof(Widget), $"{widget.Widgetid},{widget.Product},{widget.Widgettype},{widget.Siteid}");
			}
			ParamChecker.EntityUnUsable(typeof(Widget), $"{widget.Widgetid},{widget.Product},{widget.Widgettype},{widget.Siteid}", widget4Update.Isusable);
			widget4Update.Isusable = "Usable";
			widget.CopyCommonFieldUpdatePrev(widget4Update, systemTime, dbContext.Tid, text);
			widget.CopyExtensionCollection(widget4Update);
			list.Add(widget4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.UPDATE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}

	private static int RealDeleteWidget(IDbContext dbContext, Widget[] widgetList, IOptionSet optionSet, bool saveHist)
	{
		ParamChecker.ArgumentNotNull("dbContext", dbContext);
		ParamChecker.ArgumentNotNullAndHasElement("widgetList", widgetList);
		string text = "RealDeleteWidget";
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.StartApi(text));
		DateTime systemTime = ContextManager.GetSystemTime(dbContext);
		int num = 0;
		List<Widget> list = new List<Widget>();
		foreach (Widget widget in widgetList)
		{
			Widget widget4Update = GetWidget4Update(dbContext, widget.Widgetid, widget.Product, widget.Widgettype, widget.Siteid);
			if (widget4Update == null)
			{
				throw new EntityNotFoundException(typeof(Widget), $"{widget.Widgetid},{widget.Product},{widget.Widgettype},{widget.Siteid}");
			}
			widget.CopyCommonFieldUpdatePrev(widget4Update, systemTime, dbContext.Tid, text);
			widget.CopyExtensionCollection(widget4Update);
			list.Add(widget4Update);
		}
		num += ContextManager.UpsertEntityWithFullColumn(dbContext, RequestType.REALDELETE, list.ToArray(), saveHist);
		MesLogger.InfoTid("API", dbContext.Tid, MesLoggingFormat.EndApi(text));
		return num;
	}
}
