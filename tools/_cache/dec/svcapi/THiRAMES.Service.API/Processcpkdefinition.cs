using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("RPT_PROCESSCPK_DEFINITION")]
public class Processcpkdefinition : EntityTemplate
{
	public override string TableName => "RPT_PROCESSCPK_DEFINITION";

	public override string GroupName => "RPT_PROCESSCPK_DEFINITION";

	public override string TableType => "MAIN";

	[Key]
	[Column("CPKITEMID")]
	[StringLength(40)]
	public string Cpkitemid { get; set; }

	[Key]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Required]
	[Column("CPKITEMNAME")]
	[StringLength(40)]
	public string Cpkitemname { get; set; }

	[Required]
	[Column("PROCESSTYPE")]
	[StringLength(40)]
	public string Processtype { get; set; }

	[Required]
	[Column("UNIT")]
	[StringLength(40)]
	public string Unit { get; set; }

	[Column("TARGET")]
	public decimal? Target { get; set; }

	[Column("USL")]
	public decimal? Usl { get; set; }

	[Column("LSL")]
	public decimal? Lsl { get; set; }

	[Column("CPKTARGET")]
	public decimal? Cpktarget { get; set; }

	[Column("CALCLOGIC")]
	[StringLength(400)]
	public string Calclogic { get; set; }

	[Column("TAGID")]
	[StringLength(100)]
	public string Tagid { get; set; }

	[Column("DCSTAGID")]
	[StringLength(40)]
	public string Dcstagid { get; set; }

	[Column("UISEQUENCE")]
	public int Uisequence { get; set; }
}
