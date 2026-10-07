using System.Collections.Generic;
using CIM.MES.API.PPS;
using CIM.MES.API.RDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_ProductClassSave : ModelerRuleBiz<Productclass>
{
	public void CreateProductClass(IDbContext dbContext, Dictionary<string, object> dic)
	{
		Productclass productclass = ConvertToEntityObject<Productclass>(dbContext, dic);
		SetCommonData(dbContext, productclass, ACTIVITY, RequestType.CREATE, base.RequestData.TID);
		int rowCount = CreateProductClass(dbContext, productclass);
		DBTransactionCheck(ACTIVITY, 2, CreateMaterialClass(dbContext, dic, rowCount));
	}

	private int CreateProductClass(IDbContext dbContext, Productclass productClass)
	{
		Productclass productClass2 = PRODUCTCLASS.GetProductClass(dbContext, productClass.Productclassid, productClass.Siteid);
		if (productClass2 != null)
		{
			UpdateProductClass(dbContext, productClass, productClass2);
			return 2;
		}
		return PRODUCTCLASS.UpsertProductClass(dbContext, RequestType.CREATE, new Productclass[1] { productClass }, null, saveHist: true);
	}

	private int CreateMaterialClass(IDbContext dbContext, Dictionary<string, object> dic, int rowCount)
	{
		NewData4SaveMaterialClass(dic);
		Materialclass materialclass = ConvertToEntityObject<Materialclass>(dbContext, dic);
		SetCommonData(dbContext, materialclass, ACTIVITY, RequestType.CREATE, base.RequestData.TID);
		Materialclass materialClass = MATERIALCLASS.GetMaterialClass(dbContext, materialclass.Materialclassid, materialclass.Siteid);
		if (materialClass != null)
		{
			UpdateMaterialClass(dbContext, materialclass, materialClass);
			return 2;
		}
		return MATERIALCLASS.UpsertMaterialClass(dbContext, RequestType.CREATE, new Materialclass[1] { materialclass }, null, saveHist: true);
	}

	private static void NewData4SaveMaterialClass(Dictionary<string, object> dic)
	{
		if (dic["PRODUCTCLASSID"] == null)
		{
			throw new MesMultiLanguageException(ModelerErrorCode.E_MES_MODELER_001, "PRODUCTCLASSID");
		}
		dic.Add("MATERIALCLASSID", dic["PRODUCTCLASSID"]);
		dic.Add("MATERIALCLASSNAME", dic["PRODUCTCLASSNAME"]);
	}

	public void DeleteProductClass(IDbContext dbContext, Dictionary<string, object> dic)
	{
		Productclass productclass = ConvertToEntityObject<Productclass>(dbContext, dic);
		SetCommonData(dbContext, productclass, ACTIVITY, RequestType.DELETE, base.RequestData.TID);
		int rowCount = DeleteProductClass(dbContext, productclass);
		DBTransactionCheck(ACTIVITY, 4, DeleteMaterialClass(dbContext, dic, rowCount));
	}

	private int DeleteProductClass(IDbContext dbContext, Productclass productClass)
	{
		return PRODUCTCLASS.UpsertProductClass(dbContext, RequestType.DELETE, new Productclass[1] { productClass }, null, saveHist: true);
	}

	private int DeleteMaterialClass(IDbContext dbContext, Dictionary<string, object> dic, int rowCount)
	{
		NewData4SaveMaterialClass(dic);
		Materialclass materialclass = ConvertToEntityObject<Materialclass>(dbContext, dic);
		SetCommonData(dbContext, materialclass, ACTIVITY, RequestType.DELETE, base.RequestData.TID);
		rowCount += MATERIALCLASS.UpsertMaterialClass(dbContext, RequestType.DELETE, new Materialclass[1] { materialclass }, null, saveHist: true);
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
					CreateProductClass(dbContext, wEBDATum);
					break;
				case "U":
					UpdateProductClass(dbContext, wEBDATum);
					break;
				case "D":
					DeleteProductClass(dbContext, wEBDATum);
					break;
				default:
					throw new MesMultiLanguageException("E_MES_MODELER_003", "_ROW_STATE", wEBDATum.ValidatedValue("_ROW_STATE"));
				}
			}
		}
	}

	public override void CreateAPI(IDbContext dbContext, Productclass productclass)
	{
	}

	public override void DeleteAPI(IDbContext dbContext, Productclass productclass)
	{
	}

	public override void UpdateAPI(IDbContext dbContext, Productclass productclass)
	{
	}

	public void UpdateProductClass(IDbContext dbContext, Dictionary<string, object> dic)
	{
		NewData4SaveMaterialClass(dic);
		Productclass productclass = ConvertToEntityObject<Productclass>(dbContext, dic);
		SetCommonData(dbContext, productclass, ACTIVITY, RequestType.UPDATE, base.RequestData.TID);
		Productclass productClass4Update = GetProductClass4Update(dbContext, productclass);
		UpdateProductClass(dbContext, productclass, productClass4Update);
		Materialclass materialclass = ConvertToEntityObject<Materialclass>(dbContext, dic);
		SetCommonData(dbContext, materialclass, ACTIVITY, RequestType.UPDATE, base.RequestData.TID);
		Materialclass materialClass4Update = GetMaterialClass4Update(dbContext, materialclass);
		UpdateMaterialClass(dbContext, materialclass, materialClass4Update);
	}

	private Productclass GetProductClass4Update(IDbContext dbContext, Productclass productClass)
	{
		Productclass productClass4Update = PRODUCTCLASS.GetProductClass4Update(dbContext, productClass.Productclassid, productClass.Siteid);
		if (productClass4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "PRODUCTCLASS", "PRODUCTCLASSID: " + productClass.Productclassid + ", SITEID: " + productClass.Siteid);
		}
		return productClass4Update;
	}

	private Materialclass GetMaterialClass4Update(IDbContext dbContext, Materialclass materialClass)
	{
		Materialclass materialClass4Update = MATERIALCLASS.GetMaterialClass4Update(dbContext, materialClass.Materialclassid, materialClass.Siteid);
		if (materialClass4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "MATERIALCLASS", "MATERIALCLASSID: " + materialClass.Materialclassid + ", SITEID: " + materialClass.Siteid);
		}
		return materialClass4Update;
	}

	private void UpdateProductClass(IDbContext dbContext, Productclass productClass, Productclass productClassCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(productClass.Isusable))
		{
			num += PRODUCTCLASS.UpsertProductClass(dbContext, RequestType.DELETE, new Productclass[1] { productClass }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(productClassCurrent.Isusable))
		{
			num += PRODUCTCLASS.UpsertProductClass(dbContext, RequestType.UNDELETE, new Productclass[1] { productClass }, null, saveHist: true);
			flag = true;
		}
		num += PRODUCTCLASS.UpsertProductClass(dbContext, RequestType.UPDATE, new Productclass[1] { productClass }, null, saveHist: true);
		if (flag)
		{
			DBTransactionCheck(ACTIVITY, 4, num);
		}
		else
		{
			DBTransactionCheck(ACTIVITY, 2, num);
		}
	}

	private void UpdateMaterialClass(IDbContext dbContext, Materialclass materialClass, Materialclass materialClassCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(materialClass.Isusable))
		{
			num += MATERIALCLASS.UpsertMaterialClass(dbContext, RequestType.DELETE, new Materialclass[1] { materialClass }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(materialClassCurrent.Isusable))
		{
			num += MATERIALCLASS.UpsertMaterialClass(dbContext, RequestType.UNDELETE, new Materialclass[1] { materialClass }, null, saveHist: true);
			flag = true;
		}
		num += MATERIALCLASS.UpsertMaterialClass(dbContext, RequestType.UPDATE, new Materialclass[1] { materialClass }, null, saveHist: true);
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
