using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("RPT_OPERATIONRATE_DEFINITION")]
public class Operationratedefinition : EntityTemplate
{
	public override string TableName => "RPT_OPERATIONRATE_DEFINITION";

	public override string GroupName => "RPT_OPERATIONRATE_DEFINITION";

	public override string TableType => "MAIN";

	[Key]
	[Column("ITEMID")]
	[StringLength(40)]
	public string Itemid { get; set; }

	[Key]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Required]
	[Column("ITEMNAME")]
	[StringLength(100)]
	public string Itemname { get; set; }

	[Column("PROCESSTYPE")]
	[StringLength(40)]
	public string Processtype { get; set; }

	[Required]
	[Column("UNIT")]
	[StringLength(40)]
	public string Unit { get; set; }

	[Required]
	[Column("ITEMCOUNT")]
	public int Itemcount { get; set; }

	[Required]
	[Column("ISUSETIMERATE")]
	[StringLength(40)]
	public string Isusetimerate { get; set; }

	[Required]
	[Column("ISUSEPERFORMANCERATE")]
	[StringLength(40)]
	public string Isuseperformancerate { get; set; }

	[Column("TIMERATE")]
	public decimal? Timerate { get; set; }

	[Column("PERFORMANCERATE")]
	public decimal? Performancerate { get; set; }

	[Column("COMPRERATE")]
	public decimal? Comprerate { get; set; }

	[Column("UISEQUENCE")]
	public int Uisequence { get; set; }

	[Column("RATETYPE")]
	[StringLength(40)]
	public string Ratetype { get; set; }

	[Column("RATEBASEVALUE")]
	[StringLength(40)]
	public string Ratebasevalue { get; set; }
}
