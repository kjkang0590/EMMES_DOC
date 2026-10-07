using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_MultiLanguageSave : ModelerRuleBiz<Multilanguage>
{
	private int CreateMultiLanguage(IDbContext dbContext, Multilanguage multiLanguage)
	{
		Multilanguage multiLanguage4Update = MULTILANGUAGE.GetMultiLanguage4Update(dbContext, multiLanguage.Languagecodeid, multiLanguage.Codetype, multiLanguage.Language, multiLanguage.Siteid);
		if (multiLanguage4Update != null)
		{
			UpdateMultiLanguage(dbContext, multiLanguage, multiLanguage4Update);
			return 2;
		}
		return MULTILANGUAGE.UpsertMultiLanguage(dbContext, RequestType.CREATE, new Multilanguage[1] { multiLanguage }, null, saveHist: true);
	}

	private int DeleteMultiLanguage(IDbContext dbContext, Multilanguage multiLanguage)
	{
		return MULTILANGUAGE.UpsertMultiLanguage(dbContext, RequestType.DELETE, new Multilanguage[1] { multiLanguage }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Multilanguage multilanguage)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateMultiLanguage(dbContext, multilanguage));
	}

	public override void DeleteAPI(IDbContext dbContext, Multilanguage multilanguage)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteMultiLanguage(dbContext, multilanguage));
	}

	public override void UpdateAPI(IDbContext dbContext, Multilanguage multilanguage)
	{
		UpdateMultiLanguage(dbContext, multilanguage, GetMultiLanguage4Update(dbContext, multilanguage));
	}

	private Multilanguage GetMultiLanguage4Update(IDbContext dbContext, Multilanguage multiLanguage)
	{
		Multilanguage multiLanguage4Update = MULTILANGUAGE.GetMultiLanguage4Update(dbContext, multiLanguage.Languagecodeid, multiLanguage.Codetype, multiLanguage.Language, multiLanguage.Siteid);
		if (multiLanguage4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "MULTILANGUAGE", "LANGUAGECODEID: " + multiLanguage.Languagecodeid + ", CODETYPE: " + multiLanguage.Codetype + ", LANGUAGE: " + multiLanguage.Language + ", SITEID: " + multiLanguage.Siteid);
		}
		return multiLanguage4Update;
	}

	private void UpdateMultiLanguage(IDbContext dbContext, Multilanguage multiLanguage, Multilanguage multiLanguageCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(multiLanguage.Isusable))
		{
			num += MULTILANGUAGE.UpsertMultiLanguage(dbContext, RequestType.DELETE, new Multilanguage[1] { multiLanguage }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(multiLanguageCurrent.Isusable))
		{
			num += MULTILANGUAGE.UpsertMultiLanguage(dbContext, RequestType.UNDELETE, new Multilanguage[1] { multiLanguage }, null, saveHist: true);
			flag = true;
		}
		num += MULTILANGUAGE.UpsertMultiLanguage(dbContext, RequestType.UPDATE, new Multilanguage[1] { multiLanguage }, null, saveHist: true);
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
