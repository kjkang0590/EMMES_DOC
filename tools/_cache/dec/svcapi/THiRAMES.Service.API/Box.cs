using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CUS_BOX")]
public class Box : EntityTemplate
{
	public override string TableName => "CUS_BOX";

	public override string GroupName => "CUS_BOX";

	public override string TableType => "MAIN";

	[Key]
	[Column("BOXID")]
	[StringLength(40)]
	public string Boxid { get; set; }

	[Key]
	[Column("BOXTYPE")]
	[StringLength(40)]
	public string Boxtype { get; set; }

	[Key]
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
