using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_WidgetSave : ModelerRuleBiz<Widget>
{
	private int CreateWidget(IDbContext dbContext, Widget widget)
	{
		Widget widget4Update = WIDGET.GetWidget4Update(dbContext, widget.Widgetid, widget.Product, widget.Widgettype, widget.Siteid);
		if (widget4Update != null)
		{
			UpdateWidget(dbContext, widget, widget4Update);
			return 2;
		}
		return WIDGET.UpsertWidget(dbContext, RequestType.CREATE, new Widget[1] { widget }, null, saveHist: true);
	}

	private void DeleteWidget(IDbContext dbContext, Widget widget)
	{
		DBTransactionCheck(ACTIVITY, 2, WIDGET.UpsertWidget(dbContext, RequestType.DELETE, new Widget[1] { widget }, null, saveHist: true));
	}

	public override void CreateAPI(IDbContext dbContext, Widget widget)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateWidget(dbContext, widget));
	}

	public override void DeleteAPI(IDbContext dbContext, Widget widget)
	{
		DeleteWidget(dbContext, widget);
	}

	public override void UpdateAPI(IDbContext dbContext, Widget widget)
	{
		UpdateWidget(dbContext, widget, GetWidget4Update(dbContext, widget));
	}

	private Widget GetWidget4Update(IDbContext dbContext, Widget widget)
	{
		Widget widget4Update = WIDGET.GetWidget4Update(dbContext, widget.Widgetid, widget.Product, widget.Widgettype, widget.Siteid);
		if (widget4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "WIDGET", "WIDGETID: " + widget.Widgetid + ", WIDGETTYPE: " + widget.Widgettype + ", SITEID: " + widget.Siteid);
		}
		return widget4Update;
	}

	private void UpdateWidget(IDbContext dbContext, Widget inputwidget, Widget storedWidget)
	{
		int num = 0;
		if ("UnUsable".Equals(inputwidget.Isusable) && "Usable".Equals(storedWidget.Isusable))
		{
			DBTransactionCheck(ACTIVITY, 2, WIDGET.UpsertWidget(dbContext, RequestType.DELETE, new Widget[1] { inputwidget }, null, saveHist: true));
			return;
		}
		bool flag = false;
		if ("Usable".Equals(inputwidget.Isusable) && "UnUsable".Equals(storedWidget.Isusable))
		{
			num += WIDGET.UpsertWidget(dbContext, RequestType.UNDELETE, new Widget[1] { inputwidget }, null, saveHist: true);
			flag = true;
		}
		num += WIDGET.UpsertWidget(dbContext, RequestType.UPDATE, new Widget[1] { inputwidget }, null, saveHist: true);
		if (flag)
		{
			DBTransactionCheck(ACTIVITY, 4, num);
		}
		else
		{
			DBTransactionCheck(ACTIVITY, 2, num);
		}
	}
}
