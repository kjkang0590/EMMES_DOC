using CIM.MES.API.DAS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_ProcessDataParameterSave : ModelerRuleBiz<Processdataparameter>
{
	private int CreateProcessDataParameter(IDbContext dbContext, Processdataparameter processDataParameter)
	{
		Processdataparameter processDataParameter2 = PROCESSDATAPARAMETER.GetProcessDataParameter(dbContext, processDataParameter.Processdataparameterid, processDataParameter.Processdatadefinitionid, processDataParameter.Siteid);
		if (processDataParameter2 != null)
		{
			UpdateProcessDataParameter(dbContext, processDataParameter, processDataParameter2);
			return 2;
		}
		return PROCESSDATAPARAMETER.UpsertProcessDataParameter(dbContext, RequestType.CREATE, new Processdataparameter[1] { processDataParameter }, null, saveHist: true);
	}

	private int DeleteProcessDataParameter(IDbContext dbContext, Processdataparameter processDataParameter)
	{
		return PROCESSDATAPARAMETER.UpsertProcessDataParameter(dbContext, RequestType.DELETE, new Processdataparameter[1] { processDataParameter }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Processdataparameter processdataparameter)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateProcessDataParameter(dbContext, processdataparameter));
	}

	public override void DeleteAPI(IDbContext dbContext, Processdataparameter processdataparameter)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteProcessDataParameter(dbContext, processdataparameter));
	}

	public override void UpdateAPI(IDbContext dbContext, Processdataparameter processdataparameter)
	{
		UpdateProcessDataParameter(dbContext, processdataparameter, GetProcessDataParameter4Update(dbContext, processdataparameter));
	}

	private Processdataparameter GetProcessDataParameter4Update(IDbContext dbContext, Processdataparameter processDataParameter)
	{
		Processdataparameter processDataParameter4Update = PROCESSDATAPARAMETER.GetProcessDataParameter4Update(dbContext, processDataParameter.Processdataparameterid, processDataParameter.Processdatadefinitionid, processDataParameter.Siteid);
		if (processDataParameter4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "PROCESSDATAPARAMETER", "PROCESSDATAPARAMETERID: " + processDataParameter.Processdataparameterid + ", PROCESSDATADEFINITIONID: " + processDataParameter.Processdatadefinitionid + ", SITEID: " + processDataParameter.Siteid);
		}
		return processDataParameter4Update;
	}

	private void UpdateProcessDataParameter(IDbContext dbContext, Processdataparameter processDataParameter, Processdataparameter processDataParameterCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(processDataParameter.Isusable))
		{
			num += PROCESSDATAPARAMETER.UpsertProcessDataParameter(dbContext, RequestType.DELETE, new Processdataparameter[1] { processDataParameter }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(processDataParameterCurrent.Isusable))
		{
			num += PROCESSDATAPARAMETER.UpsertProcessDataParameter(dbContext, RequestType.UNDELETE, new Processdataparameter[1] { processDataParameter }, null, saveHist: true);
			flag = true;
		}
		num += PROCESSDATAPARAMETER.UpsertProcessDataParameter(dbContext, RequestType.UPDATE, new Processdataparameter[1] { processDataParameter }, null, saveHist: true);
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
