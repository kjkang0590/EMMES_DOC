using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CST_OPCTAGINFOHIST")]
public class Opctaginfohist : EntityTemplate
{
	public override string TableName => "CST_OPCTAGINFOHIST";

	public override string GroupName => "CST_OPCTAGINFOHIST";

	public override string TableType => "HIST";

	[Key]
	[Column("LASTEVENTSEQ")]
	public long Lasteventseq { get; set; }

	[Required]
	[Column("TAGID")]
	[StringLength(40)]
	public string Tagid { get; set; }

	[Required]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Column("TAGNAME")]
	[StringLength(40)]
	public string Tagname { get; set; }

	[Column("EQUIPMENTID")]
	[StringLength(40)]
	public string Equipmentid { get; set; }

	[Column("EQUIPMENTCLASSID")]
	[StringLength(40)]
	public string Equipmentclassid { get; set; }

	[Column("ROOTEQUIPMENTID")]
	[StringLength(40)]
	public string Rootequipmentid { get; set; }

	[Column("PROCESSSEGMENTID")]
	[StringLength(40)]
	public string Processsegmentid { get; set; }

	[Column("PROCESSTYPE")]
	[StringLength(40)]
	public string Processtype { get; set; }

	[Column("LINEID")]
	[StringLength(40)]
	public string Lineid { get; set; }

	[Column("DCSTAGID")]
	[StringLength(40)]
	public string Dcstagid { get; set; }
}
