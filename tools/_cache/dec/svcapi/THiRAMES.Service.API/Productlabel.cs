using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CST_PRODUCTLABEL")]
public class Productlabel : EntityTemplate
{
	public override string TableName => "CST_PRODUCTLABEL";

	public override string GroupName => "CST_PRODUCTLABEL";

	public override string TableType => "MAIN";

	[Key]
	[Column("LOTID")]
	[StringLength(40)]
	public string Lotid { get; set; }

	[Key]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Required]
	[Column("QTY")]
	[StringLength(40)]
	public string Qty { get; set; }

	[Column("PRODUCTDEFINITIONID")]
	[StringLength(40)]
	public string Productdefinitionid { get; set; }

	[Column("PROCESSSEGMENTID")]
	[StringLength(40)]
	public string Processsegmentid { get; set; }

	[Column("ISREPACKINGFLAG")]
	[StringLength(40)]
	public string Isrepackingflag { get; set; }

	[Column("UNITID")]
	[StringLength(40)]
	public string Unitid { get; set; }

	[Column("PRINTCOUNT")]
	[StringLength(40)]
	public string Printcount { get; set; }

	[Column("LINEID")]
	[StringLength(40)]
	public string Lineid { get; set; }

	[Column("PRINTERID")]
	[StringLength(40)]
	public string Printerid { get; set; }
}
