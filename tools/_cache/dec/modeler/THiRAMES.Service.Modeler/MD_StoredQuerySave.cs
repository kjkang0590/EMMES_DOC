using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_StoredQuerySave : ModelerRuleBiz<Storedquery>
{
	private int CreateStoredQuery(IDbContext dbContext, Storedquery storedQuery)
	{
		Storedquery storedQuery4Update = CIM.MES.API.CDS.STOREDQUERY.GetStoredQuery4Update(dbContext, storedQuery.Storedqueryid, storedQuery.Storedqueryversion, storedQuery.Storedqueryclassid, storedQuery.Siteid);
		if (storedQuery4Update != null)
		{
			UpdateStoredQuery(dbContext, storedQuery, storedQuery4Update);
			return 2;
		}
		return CIM.MES.API.CDS.STOREDQUERY.UpsertStoredQuery(dbContext, RequestType.CREATE, new Storedquery[1] { storedQuery }, null, saveHist: true);
	}

	private int DeleteStoredQuery(IDbContext dbContext, Storedquery storedQuery)
	{
		return CIM.MES.API.CDS.STOREDQUERY.UpsertStoredQuery(dbContext, RequestType.DELETE, new Storedquery[1] { storedQuery }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Storedquery storedquery)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateStoredQuery(dbContext, storedquery));
	}

	public override void DeleteAPI(IDbContext dbContext, Storedquery storedquery)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteStoredQuery(dbContext, storedquery));
	}

	public override void UpdateAPI(IDbContext dbContext, Storedquery storedquery)
	{
		UpdateStoredQuery(dbContext, storedquery, GetStoredQuery4Update(dbContext, storedquery));
	}

	private Storedquery GetStoredQuery4Update(IDbContext dbContext, Storedquery storedQuery)
	{
		Storedquery storedQuery4Update = CIM.MES.API.CDS.STOREDQUERY.GetStoredQuery4Update(dbContext, storedQuery.Storedqueryid, storedQuery.Storedqueryversion, storedQuery.Storedqueryclassid, storedQuery.Siteid);
		if (storedQuery4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "STOREDQUERY", "STOREDQUERYID: " + storedQuery.Storedqueryid + ", STOREDQUERYVERSION: " + storedQuery.Storedqueryversion + ", STOREDQUERYCLASSID: " + storedQuery.Storedqueryclassid + ", SITEID: " + storedQuery.Siteid);
		}
		return storedQuery4Update;
	}

	private void UpdateStoredQuery(IDbContext dbContext, Storedquery storedQuery, Storedquery storedQueryCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(storedQuery.Isusable))
		{
			num += CIM.MES.API.CDS.STOREDQUERY.UpsertStoredQuery(dbContext, RequestType.DELETE, new Storedquery[1] { storedQuery }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(storedQueryCurrent.Isusable))
		{
			num += CIM.MES.API.CDS.STOREDQUERY.UpsertStoredQuery(dbContext, RequestType.UNDELETE, new Storedquery[1] { storedQuery }, null, saveHist: true);
			flag = true;
		}
		num += CIM.MES.API.CDS.STOREDQUERY.UpsertStoredQuery(dbContext, RequestType.UPDATE, new Storedquery[1] { storedQuery }, null, saveHist: true);
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
