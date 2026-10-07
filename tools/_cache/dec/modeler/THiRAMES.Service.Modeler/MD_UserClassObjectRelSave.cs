using System.Collections.Generic;
using System.Data;
using System.Linq;
using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_UserClassObjectRelSave : ModelerRuleBiz<Userclassobjectrel>
{
	private int CreateUserClassObjectRel(IDbContext dbContext, Userclassobjectrel userClassObjectRel)
	{
		Userclassobjectrel userClassObjectRel4Update = USERCLASSOBJECTREL.GetUserClassObjectRel4Update(dbContext, userClassObjectRel.Userclassid, userClassObjectRel.Objectid, userClassObjectRel.Menuid, userClassObjectRel.Menuclassid, userClassObjectRel.Siteid);
		if (userClassObjectRel4Update != null)
		{
			UpdateUserClassObjectRel(dbContext, userClassObjectRel, userClassObjectRel4Update);
			return 2;
		}
		return USERCLASSOBJECTREL.UpsertUserClassObjectRel(dbContext, RequestType.CREATE, new Userclassobjectrel[1] { userClassObjectRel }, null, saveHist: true);
	}

	private int DeleteUserClassObjectRel(IDbContext dbContext, Userclassobjectrel userClassObjectRel)
	{
		return USERCLASSOBJECTREL.UpsertUserClassObjectRel(dbContext, RequestType.DELETE, new Userclassobjectrel[1] { userClassObjectRel }, null, saveHist: true);
	}

	public override void MessageValidation(IDbContext dbContext)
	{
	}

	public override void Process(IDbContext dbContext)
	{
		Userclassobjectrel[] webdata = GetWebdata(dbContext);
		Userclassobjectrel[] array = webdata;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Mandatory("DATALIST", "USERCLASSID", "MENUID", "MENUCLASSID", "SITEID");
		}
		Userclassobjectrel userclass = webdata.FirstOrDefault();
		Userclassobjectrel[] webdataDATALIST = GetWebdataDATALIST(0, "OBJECTIDLIST", delegate(Userclassobjectrel[] objectlist)
		{
			foreach (Userclassobjectrel userclassobjectrel3 in objectlist)
			{
				userclassobjectrel3.Mandatory("OBJECTID");
				userclassobjectrel3.Userclassid = userclass.Userclassid;
				userclassobjectrel3.Menuclassid = userclass.Menuclassid;
				userclassobjectrel3.Menuid = userclass.Menuid;
				userclassobjectrel3.Siteid = userclass.Siteid;
			}
		});
		List<Userclassobjectrel> list = new List<Userclassobjectrel>();
		List<Userclassobjectrel> list2 = new List<Userclassobjectrel>();
		DataSet dataSet = ExecuteQueryId(dbContext, "CDS_UserClassObjectRelList_100", dbContext.CreateParameter("USERCLASSID", userclass.Userclassid), dbContext.CreateParameter("MENUID", userclass.Menuid), dbContext.CreateParameter("MENUCLASSID", userclass.Menuclassid), dbContext.CreateParameter("SITEID", userclass.Siteid), dbContext.CreateParameter("ISUSABLE", "Usable"));
		List<Userclassobjectrel> list3 = dbContext.ConvertToEntityObjectList<Userclassobjectrel>(dataSet.Tables[0]);
		if (list3 != null)
		{
			if (webdataDATALIST == null || webdataDATALIST.Length < 1)
			{
				foreach (Userclassobjectrel item3 in list3)
				{
					Userclassobjectrel userclassobjectrel = new Userclassobjectrel();
					item3.CopyColumsTo(userclassobjectrel);
					SetCommonData(dbContext, item3, userclassobjectrel, RequestType.REALDELETE);
					list.Add(userclassobjectrel);
				}
			}
			else
			{
				foreach (Userclassobjectrel item2 in list3)
				{
					if (webdataDATALIST.Where((Userclassobjectrel r) => r.Userclassid == item2.Userclassid && r.Objectid == item2.Objectid && r.Menuclassid == item2.Menuclassid && r.Menuid == item2.Menuid && r.Siteid == item2.Siteid).FirstOrDefault() == null)
					{
						Userclassobjectrel userclassobjectrel2 = new Userclassobjectrel();
						item2.CopyColumsTo(userclassobjectrel2);
						SetCommonData(dbContext, item2, userclassobjectrel2, RequestType.REALDELETE);
						list.Add(userclassobjectrel2);
					}
				}
			}
		}
		array = webdataDATALIST;
		foreach (Userclassobjectrel item in array)
		{
			if (list3.Where((Userclassobjectrel r) => r.Userclassid == item.Userclassid && r.Objectid == item.Objectid && r.Menuclassid == item.Menuclassid && r.Menuid == item.Menuid && r.Siteid == item.Siteid).FirstOrDefault() == null)
			{
				item.Isusable = "Usable";
				SetCommonData(dbContext, item, ACTIVITY, RequestType.CREATE);
				list2.Add(item);
			}
		}
		if (list.Count() > 0)
		{
			DBTransactionCheck(ACTIVITY, list.Count * 2, USERCLASSOBJECTREL.UpsertUserClassObjectRel(dbContext, RequestType.REALDELETE, list.ToArray(), null, saveHist: true));
		}
		if (list2.Count > 0)
		{
			DBTransactionCheck(ACTIVITY, list2.Count * 2, USERCLASSOBJECTREL.UpsertUserClassObjectRel(dbContext, RequestType.CREATE, list2.ToArray(), null, saveHist: true));
		}
	}

	public override void CreateAPI(IDbContext dbContext, Userclassobjectrel userclassobjectrel)
	{
	}

	public override void DeleteAPI(IDbContext dbContext, Userclassobjectrel userclassobjectrel)
	{
	}

	public override void UpdateAPI(IDbContext dbContext, Userclassobjectrel userclassobjectrel)
	{
	}

	private Userclassobjectrel GetUserClassObjectRel4Update(IDbContext dbContext, Userclassobjectrel userClassObjectRel)
	{
		Userclassobjectrel userClassObjectRel4Update = USERCLASSOBJECTREL.GetUserClassObjectRel4Update(dbContext, userClassObjectRel.Userclassid, userClassObjectRel.Objectid, userClassObjectRel.Menuid, userClassObjectRel.Menuclassid, userClassObjectRel.Siteid);
		if (userClassObjectRel4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "USERCLASSOBJECTREL", "USERCLASSID: " + userClassObjectRel.Userclassid + ", OBJECTID: " + userClassObjectRel.Objectid + ", MENUID: " + userClassObjectRel.Menuid + ", MENUCLASSID: " + userClassObjectRel.Menuclassid + ", SITEID: " + userClassObjectRel.Siteid);
		}
		return userClassObjectRel4Update;
	}

	private void UpdateUserClassObjectRel(IDbContext dbContext, Userclassobjectrel userClassObjectRel, Userclassobjectrel userClassObjectRelCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(userClassObjectRel.Isusable))
		{
			num += USERCLASSOBJECTREL.UpsertUserClassObjectRel(dbContext, RequestType.DELETE, new Userclassobjectrel[1] { userClassObjectRel }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(userClassObjectRelCurrent.Isusable))
		{
			num += USERCLASSOBJECTREL.UpsertUserClassObjectRel(dbContext, RequestType.UNDELETE, new Userclassobjectrel[1] { userClassObjectRel }, null, saveHist: true);
			flag = true;
		}
		num += USERCLASSOBJECTREL.UpsertUserClassObjectRel(dbContext, RequestType.UPDATE, new Userclassobjectrel[1] { userClassObjectRel }, null, saveHist: true);
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
