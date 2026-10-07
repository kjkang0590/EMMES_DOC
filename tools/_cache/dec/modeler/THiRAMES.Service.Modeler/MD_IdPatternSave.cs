using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_IdPatternSave : ModelerRuleBiz<Idpattern>
{
	private int CreateIdPattern(IDbContext dbContext, Idpattern idpattern)
	{
		Idpattern idPattern4Update = IDPATTERN.GetIdPattern4Update(dbContext, idpattern.Idpatternid, idpattern.Siteid);
		if (idPattern4Update != null)
		{
			UpdateIdPattern(dbContext, idpattern, idPattern4Update);
			return 2;
		}
		return IDPATTERN.UpsertIdPattern(dbContext, RequestType.CREATE, new Idpattern[1] { idpattern }, null, saveHist: true);
	}

	private int DeleteIdPattern(IDbContext dbContext, Idpattern idpattern)
	{
		return IDPATTERN.UpsertIdPattern(dbContext, RequestType.DELETE, new Idpattern[1] { idpattern }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Idpattern idpattern)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateIdPattern(dbContext, idpattern));
	}

	public override void DeleteAPI(IDbContext dbContext, Idpattern idpattern)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteIdPattern(dbContext, idpattern));
	}

	public override void UpdateAPI(IDbContext dbContext, Idpattern idpattern)
	{
		UpdateIdPattern(dbContext, idpattern, GetIdPattern4Update(dbContext, idpattern));
	}

	private Idpattern GetIdPattern4Update(IDbContext dbContext, Idpattern idpattern)
	{
		Idpattern idPattern4Update = IDPATTERN.GetIdPattern4Update(dbContext, idpattern.Idpatternid, idpattern.Siteid);
		if (idPattern4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "IDPATTERN", "IDPATTERN: " + idpattern.Idpatternid + ", SITEID: " + idpattern.Siteid);
		}
		return idPattern4Update;
	}

	private void UpdateIdPattern(IDbContext dbContext, Idpattern idpattern, Idpattern idpatternCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(idpattern.Isusable))
		{
			num += IDPATTERN.UpsertIdPattern(dbContext, RequestType.DELETE, new Idpattern[1] { idpattern }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(idpatternCurrent.Isusable))
		{
			num += IDPATTERN.UpsertIdPattern(dbContext, RequestType.UNDELETE, new Idpattern[1] { idpattern }, null, saveHist: true);
			flag = true;
		}
		num += IDPATTERN.UpsertIdPattern(dbContext, RequestType.UPDATE, new Idpattern[1] { idpattern }, null, saveHist: true);
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
