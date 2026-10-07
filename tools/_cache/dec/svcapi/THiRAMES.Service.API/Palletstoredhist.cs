using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CUS_PALLETSTOREDHIST")]
public class Palletstoredhist : EntityTemplate
{
	public override string TableName => "CUS_PALLETSTOREDHIST";

	public override string GroupName => "CUS_PALLETSTOREDHIST";

	public override string TableType => "HIST";

	[Key]
	[Column("LASTEVENTSEQ")]
	public long Lasteventseq { get; set; }

	[Required]
	[Column("PALLETSTOREDNO")]
	[StringLength(40)]
	public string Palletstoredno { get; set; }

	[Required]
	[Column("PALLETID")]
	[StringLength(40)]
	public string Palletid { get; set; }

	[Required]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Column("STATE")]
	[StringLength(40)]
	public string State { get; set; }

	[Column("LOCATION")]
	[StringLength(40)]
	public string Location { get; set; }

	[Column("PALLETSTOREDDATE")]
	[StringLength(40)]
	public DateTime Palletstoreddate { get; set; }

	[Column("PALLETSTOREDTYPE")]
	[StringLength(40)]
	public string Palletstoredtype { get; set; }

	[Column("DELIVERYORDERID")]
	[StringLength(40)]
	public string Deliveryorderid { get; set; }

	[Column("DELIVERYITEMNO")]
	[StringLength(40)]
	public string Deliveryitemno { get; set; }

	[Column("CUSTOMERID")]
	[StringLength(40)]
	public string Customerid { get; set; }

	[Column("MATERIALCLASSID")]
	[StringLength(40)]
	public string Materialclassid { get; set; }

	[Column("MATERIALDEFINITIONID")]
	[StringLength(40)]
	public string Materialdefinitionid { get; set; }

	[Column("PRODUCTTYPE")]
	[StringLength(40)]
	public string Producttype { get; set; }

	[Column("QTY")]
	[StringLength(40)]
	public decimal? Qty { get; set; }

	[Column("UNITID")]
	[StringLength(40)]
	public string Unitid { get; set; }

	[Column("FROMLOCATION")]
	[StringLength(40)]
	public string Fromlocation { get; set; }

	[Column("SHIPPEDNO")]
	[StringLength(40)]
	public string Shippedno { get; set; }
}
