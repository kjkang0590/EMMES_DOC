using System.Collections.Generic;
using System.Data;
using System.Linq;
using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_UserClassMenuRelSave : ModelerRuleBiz<Userclassmenurel>
{
	private void CreateUserClassMenuRel(IDbContext dbContext, Userclassmenurel userClassMenuRel)
	{
		if (USERCLASSMENUREL.GetUserClassMenuRel4Update(dbContext, userClassMenuRel.Userclassid, userClassMenuRel.Menuid, userClassMenuRel.Menuclassid, userClassMenuRel.Siteid) != null)
		{
			throw new MesMultiLanguageException(ModelerErrorCode.E_MES_MODELER_002, "USERCLASSMENUREL", "USERCLASSID: " + userClassMenuRel.Userclassid + ", MENUID: " + userClassMenuRel.Menuid + ", MENUCLASSID: " + userClassMenuRel.Menuclassid + ", SITEID: " + userClassMenuRel.Siteid);
		}
		DBTransactionCheck(ACTIVITY, 2, USERCLASSMENUREL.UpsertUserClassMenuRel(dbContext, RequestType.CREATE, new Userclassmenurel[1] { userClassMenuRel }, null, saveHist: true));
	}

	private int DeleteUserClassMenuRel(IDbContext dbContext, Userclassmenurel[] userClassMenuRelList)
	{
		return USERCLASSMENUREL.UpsertUserClassMenuRel(dbContext, RequestType.REALDELETE, userClassMenuRelList, null, saveHist: true);
	}

	public override void MessageValidation(IDbContext dbContext)
	{
	}

	public override void Process(IDbContext dbContext)
	{
		Userclassmenurel[] webdata = GetWebdata(dbContext);
		Userclassmenurel[] array = webdata;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Mandatory("USERCLASSID", "SITEID");
		}
		Userclassmenurel userclass = webdata.FirstOrDefault();
		Userclassmenurel[] webdataDATALIST = GetWebdataDATALIST(0, "MENULIST", delegate(Userclassmenurel[] objectlist)
		{
			foreach (Userclassmenurel userclassmenurel3 in objectlist)
			{
				userclassmenurel3.Mandatory("MENUCLASSID", "MENUID");
				userclassmenurel3.Userclassid = userclass.Userclassid;
				userclassmenurel3.Siteid = userclass.Siteid;
			}
		});
		DataSet dataSet = ExecuteQueryId(dbContext, "CDS_UserClassMenuRelList_100", dbContext.CreateParameter("USERCLASSID", userclass.Userclassid), dbContext.CreateParameter("SITEID", userclass.Siteid));
		List<Userclassmenurel> list = dbContext.ConvertToEntityObjectList<Userclassmenurel>(dataSet.Tables[0]);
		List<Userclassmenurel> list2 = new List<Userclassmenurel>();
		List<Userclassmenurel> list3 = new List<Userclassmenurel>();
		if (list != null)
		{
			if (webdataDATALIST == null || webdataDATALIST.Length < 1)
			{
				foreach (Userclassmenurel item3 in list)
				{
					Userclassmenurel userclassmenurel = new Userclassmenurel();
					item3.CopyColumsTo(userclassmenurel);
					SetCommonData(dbContext, item3, userclassmenurel, RequestType.REALDELETE);
					list2.Add(userclassmenurel);
				}
			}
			else
			{
				foreach (Userclassmenurel item2 in list)
				{
					if (webdataDATALIST.Where((Userclassmenurel r) => r.Userclassid == item2.Userclassid && r.Menuclassid == item2.Menuclassid && r.Menuid == item2.Menuid && r.Siteid == item2.Siteid).FirstOrDefault() == null)
					{
						Userclassmenurel userclassmenurel2 = new Userclassmenurel();
						item2.CopyColumsTo(userclassmenurel2);
						SetCommonData(dbContext, item2, userclassmenurel2, RequestType.CREATE);
						list2.Add(userclassmenurel2);
					}
				}
			}
		}
		array = webdataDATALIST;
		foreach (Userclassmenurel item in array)
		{
			if (list.Where((Userclassmenurel r) => r.Userclassid == item.Userclassid && r.Menuclassid == item.Menuclassid && r.Menuid == item.Menuid && r.Siteid == item.Siteid).FirstOrDefault() == null)
			{
				item.Isusable = "Usable";
				SetCommonData(dbContext, item, ACTIVITY, RequestType.CREATE);
				list3.Add(item);
			}
		}
		if (list2.Count() > 0)
		{
			DBTransactionCheck(ACTIVITY, list2.Count * 2, USERCLASSMENUREL.UpsertUserClassMenuRel(dbContext, RequestType.REALDELETE, list2.ToArray(), null, saveHist: true));
		}
		if (list3.Count > 0)
		{
			DBTransactionCheck(ACTIVITY, list3.Count * 2, USERCLASSMENUREL.UpsertUserClassMenuRel(dbContext, RequestType.CREATE, list3.ToArray(), null, saveHist: true));
		}
	}

	public override void CreateAPI(IDbContext dbContext, Userclassmenurel userclassmenurel)
	{
	}

	public override void DeleteAPI(IDbContext dbContext, Userclassmenurel userclassmenurel)
	{
	}

	public override void UpdateAPI(IDbContext dbContext, Userclassmenurel userclassmenurel)
	{
	}

	private Userclassmenurel GetUserClassMenuRel4Update(IDbContext dbContext, Userclassmenurel userClassMenuRel)
	{
		Userclassmenurel userClassMenuRel4Update = USERCLASSMENUREL.GetUserClassMenuRel4Update(dbContext, userClassMenuRel.Userclassid, userClassMenuRel.Menuid, userClassMenuRel.Menuclassid, userClassMenuRel.Siteid);
		if (userClassMenuRel4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "USERCLASSMENUREL", "USERCLASSID: " + userClassMenuRel.Userclassid + ", MENUID: " + userClassMenuRel.Menuid + ", MENUCLASSID: " + userClassMenuRel.Menuclassid + ", SITEID: " + userClassMenuRel.Siteid);
		}
		return userClassMenuRel4Update;
	}

	private void UpdateUserClassMenuRel(IDbContext dbContext, Userclassmenurel userClassMenuRel)
	{
		Userclassmenurel userClassMenuRel4Update = USERCLASSMENUREL.GetUserClassMenuRel4Update(dbContext, userClassMenuRel.Userclassid, userClassMenuRel.Menuid, userClassMenuRel.Menuclassid, userClassMenuRel.Siteid);
		if (userClassMenuRel4Update == null)
		{
			DBTransactionCheck(ACTIVITY, 2, USERCLASSMENUREL.UpsertUserClassMenuRel(dbContext, RequestType.CREATE, new Userclassmenurel[1] { userClassMenuRel }, null, saveHist: true));
			return;
		}
		int num = 0;
		bool flag = false;
		if ("UnUsable".Equals(userClassMenuRel4Update.Isusable))
		{
			num += USERCLASSMENUREL.UpsertUserClassMenuRel(dbContext, RequestType.UNDELETE, new Userclassmenurel[1] { userClassMenuRel }, null, saveHist: true);
			flag = true;
		}
		num += USERCLASSMENUREL.UpsertUserClassMenuRel(dbContext, RequestType.UPDATE, new Userclassmenurel[1] { userClassMenuRel }, null, saveHist: true);
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
