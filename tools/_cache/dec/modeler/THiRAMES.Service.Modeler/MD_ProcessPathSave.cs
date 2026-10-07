using CIM.MES.API.PMS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_ProcessPathSave : ModelerRuleBiz<Processpath>
{
	private int CreateProcessPath(IDbContext dbContext, Processpath processPath)
	{
		Processpath processPath2 = PROCESSPATH.GetProcessPath(dbContext, processPath.Processpathid, processPath.Processnodeid, processPath.Siteid);
		if (processPath2 != null)
		{
			UpdateProcessPath(dbContext, processPath, processPath2);
			return 2;
		}
		return PROCESSPATH.UpsertProcessPath(dbContext, RequestType.CREATE, new Processpath[1] { processPath }, null, saveHist: true);
	}

	private int DeleteProcessPath(IDbContext dbContext, Processpath processPath)
	{
		return PROCESSPATH.UpsertProcessPath(dbContext, RequestType.DELETE, new Processpath[1] { processPath }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Processpath processpath)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateProcessPath(dbContext, processpath));
	}

	public override void DeleteAPI(IDbContext dbContext, Processpath processpath)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteProcessPath(dbContext, processpath));
	}

	public override void UpdateAPI(IDbContext dbContext, Processpath processpath)
	{
		UpdateProcessPath(dbContext, processpath, GetProcessPath4Update(dbContext, processpath));
	}

	private Processpath GetProcessPath4Update(IDbContext dbContext, Processpath processPath)
	{
		Processpath processPath4Update = PROCESSPATH.GetProcessPath4Update(dbContext, processPath.Processpathid, processPath.Processnodeid, processPath.Siteid);
		if (processPath4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "PROCESSPATH", "PROCESSPATHID: " + processPath.Processpathid + ", PROCESSNODEID: " + processPath.Processnodeid + ", SITEID: " + processPath.Siteid);
		}
		return processPath4Update;
	}

	private void UpdateProcessPath(IDbContext dbContext, Processpath processPath, Processpath processPathCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(processPath.Isusable))
		{
			num += PROCESSPATH.UpsertProcessPath(dbContext, RequestType.DELETE, new Processpath[1] { processPath }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(processPathCurrent.Isusable))
		{
			num += PROCESSPATH.UpsertProcessPath(dbContext, RequestType.UNDELETE, new Processpath[1] { processPath }, null, saveHist: true);
			flag = true;
		}
		num += PROCESSPATH.UpsertProcessPath(dbContext, RequestType.UPDATE, new Processpath[1] { processPath }, null, saveHist: true);
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
