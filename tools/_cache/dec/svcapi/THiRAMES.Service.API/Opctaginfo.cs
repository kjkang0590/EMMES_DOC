using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CST_OPCTAGINFO")]
public class Opctaginfo : EntityTemplate
{
	public override string TableName => "CST_OPCTAGINFO";

	public override string GroupName => "CST_OPCTAGINFO";

	public override string TableType => "MAIN";

	[Key]
	[Column("TAGID")]
	[StringLength(40)]
	public string Tagid { get; set; }

	[Key]
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
