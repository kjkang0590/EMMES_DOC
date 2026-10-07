using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CST_BATTERYBARCODE")]
public class Batterybarcode : EntityTemplate
{
	public override string TableName => "CST_BATTERYBARCODE";

	public override string GroupName => "CST_BATTERYBARCODE";

	public override string TableType => "MAIN";

	[Key]
	[Column("LASTEVENTSEQ")]
	public long Lasteventseq { get; set; }

	[Required]
	[Column("BARCODEID")]
	[StringLength(40)]
	public string Barcodeid { get; set; }

	[Required]
	[Column("BATTERYTYPE")]
	[StringLength(40)]
	public string Batterytype { get; set; }

	[Column("WORKORDERID")]
	[StringLength(40)]
	public string Workorderid { get; set; }

	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Column("LINEID")]
	[StringLength(40)]
	public string Lineid { get; set; }

	[Column("MATERIALDEFINITIONID")]
	[StringLength(40)]
	public string Materialdefinitionid { get; set; }
}
