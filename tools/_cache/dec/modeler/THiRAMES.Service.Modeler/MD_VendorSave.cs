using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_VendorSave : ModelerRuleBiz<Vendor>
{
	private int CreateVendor(IDbContext dbContext, Vendor vendor)
	{
		Vendor vendor4Update = VENDOR.GetVendor4Update(dbContext, vendor.Vendorid, vendor.Siteid);
		if (vendor4Update != null)
		{
			UpdateVendor(dbContext, vendor, vendor4Update);
			return 2;
		}
		return VENDOR.UpsertVendor(dbContext, RequestType.CREATE, new Vendor[1] { vendor }, null, saveHist: true);
	}

	private int DeleteVendor(IDbContext dbContext, Vendor vendor)
	{
		return VENDOR.UpsertVendor(dbContext, RequestType.DELETE, new Vendor[1] { vendor }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Vendor vendor)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateVendor(dbContext, vendor));
	}

	public override void DeleteAPI(IDbContext dbContext, Vendor vendor)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteVendor(dbContext, vendor));
	}

	public override void UpdateAPI(IDbContext dbContext, Vendor vendor)
	{
		UpdateVendor(dbContext, vendor, GetVendor4Update(dbContext, vendor));
	}

	private Vendor GetVendor4Update(IDbContext dbContext, Vendor vendor)
	{
		Vendor vendor4Update = VENDOR.GetVendor4Update(dbContext, vendor.Vendorid, vendor.Siteid);
		if (vendor4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "VENDOR", "VENDOR: " + vendor.Vendorid + ", SITEID: " + vendor.Siteid);
		}
		return vendor4Update;
	}

	private void UpdateVendor(IDbContext dbContext, Vendor vendor, Vendor vendorCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(vendor.Isusable))
		{
			num += VENDOR.UpsertVendor(dbContext, RequestType.DELETE, new Vendor[1] { vendor }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(vendorCurrent.Isusable))
		{
			num += VENDOR.UpsertVendor(dbContext, RequestType.UNDELETE, new Vendor[1] { vendor }, null, saveHist: true);
			flag = true;
		}
		num += VENDOR.UpsertVendor(dbContext, RequestType.UPDATE, new Vendor[1] { vendor }, null, saveHist: true);
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
