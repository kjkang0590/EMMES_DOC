using CIM.MES.API.RDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_PortSave : ModelerRuleBiz<Port>
{
	private int CreatePort(IDbContext dbContext, Port port)
	{
		Port port2 = PORT.GetPort(dbContext, port.Equipmentid, port.Portid, port.Siteid);
		if (port2 != null)
		{
			UpdatePort(dbContext, port, port2);
			return 2;
		}
		return PORT.UpsertPort(dbContext, RequestType.CREATE, new Port[1] { port }, null, saveHist: true);
	}

	private int DeletePort(IDbContext dbContext, Port port)
	{
		return PORT.UpsertPort(dbContext, RequestType.DELETE, new Port[1] { port }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Port port)
	{
		DBTransactionCheck(ACTIVITY, 2, CreatePort(dbContext, port));
	}

	public override void DeleteAPI(IDbContext dbContext, Port port)
	{
		DBTransactionCheck(ACTIVITY, 2, DeletePort(dbContext, port));
	}

	public override void UpdateAPI(IDbContext dbContext, Port port)
	{
		UpdatePort(dbContext, port, GetPort4Update(dbContext, port));
	}

	private Port GetPort4Update(IDbContext dbContext, Port port)
	{
		Port port4Update = PORT.GetPort4Update(dbContext, port.Equipmentid, port.Portid, port.Siteid);
		if (port4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "PORT", "EQUIPMENTID: " + port.Equipmentid + ", PORTID: " + port.Portid + ", SITEID: " + port.Siteid);
		}
		return port4Update;
	}

	private void UpdatePort(IDbContext dbContext, Port port, Port portCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(port.Isusable))
		{
			num += PORT.UpsertPort(dbContext, RequestType.DELETE, new Port[1] { port }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(portCurrent.Isusable))
		{
			num += PORT.UpsertPort(dbContext, RequestType.UNDELETE, new Port[1] { port }, null, saveHist: true);
			flag = true;
		}
		num += PORT.UpsertPort(dbContext, RequestType.UPDATE, new Port[1] { port }, null, saveHist: true);
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
