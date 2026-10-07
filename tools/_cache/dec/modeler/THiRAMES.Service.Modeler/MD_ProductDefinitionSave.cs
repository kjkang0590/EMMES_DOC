using System.Collections.Generic;
using CIM.MES.API.PPS;
using CIM.MES.API.RDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_ProductDefinitionSave : ModelerRuleBiz<Productdefinition>
{
	public void CreateProductDefinition(IDbContext dbContext, Dictionary<string, object> dic)
	{
		Productdefinition productdefinition = ConvertToEntityObject<Productdefinition>(dbContext, dic);
		SetCommonData(dbContext, productdefinition, ACTIVITY, RequestType.CREATE, base.RequestData.TID);
		DBTransactionCheck(ACTIVITY, 2, CreateProductDefinition(dbContext, productdefinition));
		if (dic["PRODUCTTYPE"].ToString() == "HALB")
		{
			DBTransactionCheck(ACTIVITY, 2, CreateMaterialDefinition(dbContext, dic));
		}
	}

	private int CreateProductDefinition(IDbContext dbContext, Productdefinition productDefinition)
	{
		Productdefinition productDefinition2 = PRODUCTDEFINITION.GetProductDefinition(dbContext, productDefinition.Productdefinitionid, productDefinition.Siteid);
		if (productDefinition2 != null)
		{
			UpdateProductDefinition(dbContext, productDefinition, productDefinition2);
			return 2;
		}
		return PRODUCTDEFINITION.UpsertProductDefinition(dbContext, RequestType.CREATE, new Productdefinition[1] { productDefinition }, null, saveHist: true);
	}

	private int CreateMaterialDefinition(IDbContext dbContext, Dictionary<string, object> dic)
	{
		NewData4SaveMaterialDefinition(dic);
		Materialdefinition materialdefinition = ConvertToEntityObject<Materialdefinition>(dbContext, dic);
		SetCommonData(dbContext, materialdefinition, ACTIVITY, RequestType.CREATE, base.RequestData.TID);
		Materialdefinition materialDefinition = MATERIALDEFINITION.GetMaterialDefinition(dbContext, materialdefinition.Materialdefinitionid, materialdefinition.Siteid);
		if (materialDefinition != null)
		{
			UpdateMaterialDefinition(dbContext, materialdefinition, materialDefinition);
			return 2;
		}
		return MATERIALDEFINITION.UpsertMaterialDefinition(dbContext, RequestType.CREATE, new Materialdefinition[1] { materialdefinition }, null, saveHist: true);
	}

	private static void NewData4SaveMaterialDefinition(Dictionary<string, object> dic)
	{
		dic.Add("MATERIALDEFINITIONID", dic["PRODUCTDEFINITIONID"]);
		dic.Add("MATERIALDEFINITIONNAME", dic["PRODUCTDEFINITIONNAME"]);
		dic.Add("MATERIALCLASSID", dic["PRODUCTCLASSID"]);
		dic.Add("ISQTYMANAGED", "Y");
	}

	public void DeleteProductDefinition(IDbContext dbContext, Dictionary<string, object> dic)
	{
		Productdefinition productdefinition = ConvertToEntityObject<Productdefinition>(dbContext, dic);
		SetCommonData(dbContext, productdefinition, ACTIVITY, RequestType.DELETE, base.RequestData.TID);
		if (dic["PRODUCTTYPE"].ToString() == "HALB")
		{
			int rowCount = DeleteProductDefinition(dbContext, productdefinition);
			DBTransactionCheck(ACTIVITY, 4, DeleteMaterialDefinition(dbContext, dic, rowCount));
		}
		else
		{
			DBTransactionCheck(ACTIVITY, 2, DeleteProductDefinition(dbContext, productdefinition));
		}
	}

	private int DeleteProductDefinition(IDbContext dbContext, Productdefinition productDefinition)
	{
		return PRODUCTDEFINITION.UpsertProductDefinition(dbContext, RequestType.DELETE, new Productdefinition[1] { productDefinition }, null, saveHist: true);
	}

	private int DeleteMaterialDefinition(IDbContext dbContext, Dictionary<string, object> dic, int rowCount)
	{
		NewData4SaveMaterialDefinition(dic);
		Materialdefinition materialdefinition = ConvertToEntityObject<Materialdefinition>(dbContext, dic);
		SetCommonData(dbContext, materialdefinition, ACTIVITY, RequestType.DELETE, base.RequestData.TID);
		rowCount += MATERIALDEFINITION.UpsertMaterialDefinition(dbContext, RequestType.DELETE, new Materialdefinition[1] { materialdefinition }, null, saveHist: true);
		return rowCount;
	}

	public override void MessageValidation(IDbContext dbContext)
	{
	}

	public override void Process(IDbContext dbContext)
	{
		foreach (Dictionary<string, object> wEBDATum in base.WEBDATA)
		{
			if (wEBDATum.ContainsKey("_ROW_STATE"))
			{
				switch (wEBDATum.ValidatedValue("_ROW_STATE"))
				{
				case "A":
					CreateProductDefinition(dbContext, wEBDATum);
					break;
				case "U":
					UpdateProductDefinition(dbContext, wEBDATum);
					break;
				case "D":
					DeleteProductDefinition(dbContext, wEBDATum);
					break;
				default:
					throw new MesMultiLanguageException("E_MES_MODELER_003", "_ROW_STATE", wEBDATum.ValidatedValue("_ROW_STATE"));
				}
			}
		}
	}

	public override void CreateAPI(IDbContext dbContext, Productdefinition productdefinition)
	{
	}

	public override void DeleteAPI(IDbContext dbContext, Productdefinition productdefinition)
	{
	}

	public override void UpdateAPI(IDbContext dbContext, Productdefinition productdefinition)
	{
	}

	public void UpdateProductDefinition(IDbContext dbContext, Dictionary<string, object> dic)
	{
		NewData4SaveMaterialDefinition(dic);
		Productdefinition productdefinition = ConvertToEntityObject<Productdefinition>(dbContext, dic);
		SetCommonData(dbContext, productdefinition, ACTIVITY, RequestType.UPDATE, base.RequestData.TID);
		Productdefinition productDefinition4Update = GetProductDefinition4Update(dbContext, productdefinition);
		if ("HALB".Equals(dic.ValidatedValue("PRODUCTTYPE")))
		{
			Materialdefinition materialdefinition = ConvertToEntityObject<Materialdefinition>(dbContext, dic);
			SetCommonData(dbContext, materialdefinition, ACTIVITY, RequestType.UPDATE, base.RequestData.TID);
			Materialdefinition materialDefinition4Update = GetMaterialDefinition4Update(dbContext, materialdefinition);
			UpdateProductDefinition(dbContext, productdefinition, productDefinition4Update);
			UpdateMaterialDefinition(dbContext, materialdefinition, materialDefinition4Update);
		}
		else
		{
			UpdateProductDefinition(dbContext, productdefinition, productDefinition4Update);
		}
	}

	private Productdefinition GetProductDefinition4Update(IDbContext dbContext, Productdefinition productDefinition)
	{
		Productdefinition productDefinition4Update = PRODUCTDEFINITION.GetProductDefinition4Update(dbContext, productDefinition.Productdefinitionid, productDefinition.Siteid);
		if (productDefinition4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "PRODUCTDEFINITION", "PRODUCTDEFINITIONID: " + productDefinition.Productdefinitionid + ", SITEID: " + productDefinition.Siteid);
		}
		return productDefinition4Update;
	}

	private Materialdefinition GetMaterialDefinition4Update(IDbContext dbContext, Materialdefinition materialDefinition)
	{
		Materialdefinition materialDefinition4Update = MATERIALDEFINITION.GetMaterialDefinition4Update(dbContext, materialDefinition.Materialdefinitionid, materialDefinition.Siteid);
		if (materialDefinition4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "MATERIALDEFINITION", "MATERIALDEFINITIONID: " + materialDefinition.Materialdefinitionid + ", SITEID: " + materialDefinition.Siteid);
		}
		return materialDefinition4Update;
	}

	private void UpdateProductDefinition(IDbContext dbContext, Productdefinition productDefinition, Productdefinition productDefinitionCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(productDefinition.Isusable))
		{
			num += PRODUCTDEFINITION.UpsertProductDefinition(dbContext, RequestType.DELETE, new Productdefinition[1] { productDefinition }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(productDefinitionCurrent.Isusable))
		{
			num += PRODUCTDEFINITION.UpsertProductDefinition(dbContext, RequestType.UNDELETE, new Productdefinition[1] { productDefinition }, null, saveHist: true);
			flag = true;
		}
		num += PRODUCTDEFINITION.UpsertProductDefinition(dbContext, RequestType.UPDATE, new Productdefinition[1] { productDefinition }, null, saveHist: true);
		if (flag)
		{
			DBTransactionCheck(ACTIVITY, 4, num);
		}
		else
		{
			DBTransactionCheck(ACTIVITY, 2, num);
		}
	}

	private void UpdateMaterialDefinition(IDbContext dbContext, Materialdefinition materialDefinition, Materialdefinition materialDefinitionCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(materialDefinition.Isusable))
		{
			num += MATERIALDEFINITION.UpsertMaterialDefinition(dbContext, RequestType.DELETE, new Materialdefinition[1] { materialDefinition }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(materialDefinitionCurrent.Isusable))
		{
			num += MATERIALDEFINITION.UpsertMaterialDefinition(dbContext, RequestType.UNDELETE, new Materialdefinition[1] { materialDefinition }, null, saveHist: true);
			flag = true;
		}
		num += MATERIALDEFINITION.UpsertMaterialDefinition(dbContext, RequestType.UPDATE, new Materialdefinition[1] { materialDefinition }, null, saveHist: true);
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
