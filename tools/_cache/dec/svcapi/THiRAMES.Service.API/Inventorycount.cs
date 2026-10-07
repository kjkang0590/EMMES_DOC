using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CST_INVENTORYCOUNT")]
public class Inventorycount : EntityTemplate
{
	public override string TableName => "CST_INVENTORYCOUNT";

	public override string GroupName => "CST_INVENTORYCOUNT";

	public override string TableType => "MAIN";

	[Key]
	[Column("MATERIALLOTID")]
	[StringLength(40)]
	public string MaterialLotId { get; set; }

	[Key]
	[Column("MATERIALDEFINITIONID")]
	[StringLength(40)]
	public string MaterialDefinitionId { get; set; }

	[Key]
	[Column("LOCATION")]
	[StringLength(40)]
	public string Location { get; set; }

	[Key]
	[Column("WORKDATE")]
	[StringLength(40)]
	public string WorkDate { get; set; }

	[Key]
	[Column("SITEID")]
	[StringLength(40)]
	public string SiteId { get; set; }

	[Column("WORKYEARMONTH")]
	[StringLength(40)]
	public string WorkYearMonth { get; set; }

	[Column("QTY")]
	public decimal? Qty { get; set; }

	[Column("MATERIALTYPE")]
	[StringLength(40)]
	public string MaterialType { get; set; }

	[Column("LINEID")]
	[StringLength(40)]
	public string LineId { get; set; }
}
