using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_DefectSave : ModelerRuleBiz<Defect>
{
	private int CreateDefect(IDbContext dbContext, Defect defect)
	{
		Defect defect4Update = DEFECT.GetDefect4Update(dbContext, defect.Defectid, defect.Siteid);
		if (defect4Update != null)
		{
			UpdateDefect(dbContext, defect, defect4Update);
			return 2;
		}
		return DEFECT.UpsertDefect(dbContext, RequestType.CREATE, new Defect[1] { defect }, null, saveHist: true);
	}

	private int DeleteDefect(IDbContext dbContext, Defect defect)
	{
		return DEFECT.UpsertDefect(dbContext, RequestType.DELETE, new Defect[1] { defect }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Defect defect)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateDefect(dbContext, defect));
	}

	public override void DeleteAPI(IDbContext dbContext, Defect defect)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteDefect(dbContext, defect));
	}

	public override void UpdateAPI(IDbContext dbContext, Defect defect)
	{
		UpdateDefect(dbContext, defect, GetDefect4Update(dbContext, defect));
	}

	private Defect GetDefect4Update(IDbContext dbContext, Defect defect)
	{
		Defect defect4Update = DEFECT.GetDefect4Update(dbContext, defect.Defectid, defect.Siteid);
		if (defect4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "DEFECT", "DEFECTID: " + defect.Defectid + ", SITEID: " + defect.Siteid);
		}
		return defect4Update;
	}

	private void UpdateDefect(IDbContext dbContext, Defect defect, Defect defectCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(defect.Isusable))
		{
			num += DEFECT.UpsertDefect(dbContext, RequestType.DELETE, new Defect[1] { defect }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(defectCurrent.Isusable))
		{
			num += DEFECT.UpsertDefect(dbContext, RequestType.UNDELETE, new Defect[1] { defect }, null, saveHist: true);
			flag = true;
		}
		num += DEFECT.UpsertDefect(dbContext, RequestType.UPDATE, new Defect[1] { defect }, null, saveHist: true);
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
