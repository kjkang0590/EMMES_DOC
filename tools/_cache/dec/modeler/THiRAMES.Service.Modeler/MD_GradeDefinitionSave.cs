using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_GradeDefinitionSave : ModelerRuleBiz<Gradedefinition>
{
	private int CreateGradeDefinition(IDbContext dbContext, Gradedefinition gradeDefinition)
	{
		Gradedefinition gradeDefinition4Update = GRADEDEFINITION.GetGradeDefinition4Update(dbContext, gradeDefinition.Gradetype, gradeDefinition.Gradeid, gradeDefinition.Siteid);
		if (gradeDefinition4Update != null)
		{
			UpdateGradeDefinition(dbContext, gradeDefinition, gradeDefinition4Update);
			return 2;
		}
		return GRADEDEFINITION.UpsertGradeDefinition(dbContext, RequestType.CREATE, new Gradedefinition[1] { gradeDefinition }, null, saveHist: true);
	}

	private int DeleteGradeDefinition(IDbContext dbContext, Gradedefinition gradeDefinition)
	{
		return GRADEDEFINITION.UpsertGradeDefinition(dbContext, RequestType.DELETE, new Gradedefinition[1] { gradeDefinition }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Gradedefinition gradeDefinition)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateGradeDefinition(dbContext, gradeDefinition));
	}

	public override void DeleteAPI(IDbContext dbContext, Gradedefinition gradeDefinition)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteGradeDefinition(dbContext, gradeDefinition));
	}

	public override void UpdateAPI(IDbContext dbContext, Gradedefinition gradeDefinition)
	{
		UpdateGradeDefinition(dbContext, gradeDefinition, GetGradeDefinition4Update(dbContext, gradeDefinition));
	}

	private Gradedefinition GetGradeDefinition4Update(IDbContext dbContext, Gradedefinition gradeDefinition)
	{
		Gradedefinition gradeDefinition4Update = GRADEDEFINITION.GetGradeDefinition4Update(dbContext, gradeDefinition.Gradetype, gradeDefinition.Gradeid, gradeDefinition.Siteid);
		if (gradeDefinition4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "GRADEDEFINITION", "GRADETYPE: " + gradeDefinition.Gradetype + ", GRADEUD: " + gradeDefinition.Gradeid + ", SITEID: " + gradeDefinition.Siteid);
		}
		return gradeDefinition4Update;
	}

	private void UpdateGradeDefinition(IDbContext dbContext, Gradedefinition gradeDefinition, Gradedefinition gradeDefinitionCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(gradeDefinition.Isusable))
		{
			num += GRADEDEFINITION.UpsertGradeDefinition(dbContext, RequestType.DELETE, new Gradedefinition[1] { gradeDefinition }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(gradeDefinitionCurrent.Isusable))
		{
			num += GRADEDEFINITION.UpsertGradeDefinition(dbContext, RequestType.UNDELETE, new Gradedefinition[1] { gradeDefinition }, null, saveHist: true);
			flag = true;
		}
		num += GRADEDEFINITION.UpsertGradeDefinition(dbContext, RequestType.UPDATE, new Gradedefinition[1] { gradeDefinition }, null, saveHist: true);
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
