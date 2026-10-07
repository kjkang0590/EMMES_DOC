using CIM.MES.API.CDS;
using CIM.MES.Common;
using CIM.MES.Entity;
using CIM.MES.Framework;

namespace THiRAMES.Service.Modeler;

public class MD_CustomerSave : ModelerRuleBiz<Customer>
{
	private int CreateCustomer(IDbContext dbContext, Customer customer)
	{
		Customer customer4Update = CUSTOMER.GetCustomer4Update(dbContext, customer.Customerid, customer.Siteid);
		if (customer4Update != null)
		{
			UpdateCustomer(dbContext, customer, customer4Update);
			return 2;
		}
		return CUSTOMER.UpsertCustomer(dbContext, RequestType.CREATE, new Customer[1] { customer }, null, saveHist: true);
	}

	private int DeleteCustomer(IDbContext dbContext, Customer customer)
	{
		return CUSTOMER.UpsertCustomer(dbContext, RequestType.DELETE, new Customer[1] { customer }, null, saveHist: true);
	}

	public override void CreateAPI(IDbContext dbContext, Customer customer)
	{
		DBTransactionCheck(ACTIVITY, 2, CreateCustomer(dbContext, customer));
	}

	public override void DeleteAPI(IDbContext dbContext, Customer customer)
	{
		DBTransactionCheck(ACTIVITY, 2, DeleteCustomer(dbContext, customer));
	}

	public override void UpdateAPI(IDbContext dbContext, Customer customer)
	{
		UpdateCustomer(dbContext, customer, GetCustomer4Update(dbContext, customer));
	}

	private Customer GetCustomer4Update(IDbContext dbContext, Customer customer)
	{
		Customer customer4Update = CUSTOMER.GetCustomer4Update(dbContext, customer.Customerid, customer.Siteid);
		if (customer4Update == null)
		{
			throw new MesMultiLanguageException("E_MES_MODELER_006", "CUSTOMER", "CUSTOMERID: " + customer.Customerid + ", SITEID: " + customer.Siteid);
		}
		return customer4Update;
	}

	private void UpdateCustomer(IDbContext dbContext, Customer customer, Customer customerCurrent)
	{
		int num = 0;
		if ("UnUsable".Equals(customer.Isusable))
		{
			num += CUSTOMER.UpsertCustomer(dbContext, RequestType.DELETE, new Customer[1] { customer }, null, saveHist: true);
			DBTransactionCheck(ACTIVITY, 2, num);
			return;
		}
		bool flag = false;
		if ("UnUsable".Equals(customerCurrent.Isusable))
		{
			num += CUSTOMER.UpsertCustomer(dbContext, RequestType.UNDELETE, new Customer[1] { customer }, null, saveHist: true);
			flag = true;
		}
		num += CUSTOMER.UpsertCustomer(dbContext, RequestType.UPDATE, new Customer[1] { customer }, null, saveHist: true);
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
