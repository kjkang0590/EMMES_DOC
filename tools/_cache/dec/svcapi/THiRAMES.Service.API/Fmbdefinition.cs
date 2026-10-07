using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("RPT_FMBDEFINITION")]
public class Fmbdefinition : EntityTemplate
{
	public override string TableName => "RPT_FMBDEFINITION";

	public override string GroupName => "RPT_FMBDEFINITION";

	public override string TableType => "MAIN";

	[Key]
	[Column("TAGID")]
	[StringLength(100)]
	public string Tagid { get; set; }

	[Key]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Column("DCSTAGID")]
	[StringLength(40)]
	public string Dcstagid { get; set; }

	[Column("EQUIPMENTID")]
	[StringLength(40)]
	public string Equipmentid { get; set; }

	[Column("LSL")]
	[StringLength(20)]
	public string Lsl { get; set; }

	[Column("USL")]
	[StringLength(20)]
	public string Usl { get; set; }

	[Column("NOTOPERATINGVALUE")]
	[StringLength(20)]
	public string Notoperatingvalue { get; set; }

	[Required]
	[Column("ISAPPLY")]
	[StringLength(1)]
	public string Isapply { get; set; }

	[Column("SEQNO")]
	[StringLength(10)]
	public string Seqno { get; set; }
}
