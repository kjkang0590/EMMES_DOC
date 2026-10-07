using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CUS_BOXHIST")]
public class Boxhist : EntityTemplate
{
	public override string TableName => "CUS_BOXHIST";

	public override string GroupName => "CUS_BOXHIST";

	public override string TableType => "HIST";

	[Key]
	[Column("LASTEVENTSEQ")]
	public long Lasteventseq { get; set; }

	[Required]
	[Column("BOXID")]
	[StringLength(40)]
	public string Boxid { get; set; }

	[Required]
	[Column("BOXTYPE")]
	[StringLength(40)]
	public string Boxtype { get; set; }

	[Required]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Column("STATE")]
	[StringLength(40)]
	public string State { get; set; }

	[Column("PRINTCOUNT", TypeName = "numeric(4, 0)")]
	public int? Printcount { get; set; }

	[Column("EQUIPMENTID")]
	[StringLength(40)]
	public string Equipmentid { get; set; }

	[Column("BATCHID")]
	[StringLength(40)]
	public string Batchid { get; set; }
}
