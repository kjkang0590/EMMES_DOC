using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CST_PUBLICREL")]
public class Publicrel : EntityTemplate
{
	public override string TableName => "CST_PUBLICREL";

	public override string GroupName => "CST_PUBLICREL";

	public override string TableType => "MAIN";

	[Key]
	[Column("PARENTID")]
	[StringLength(100)]
	public string Parentid { get; set; }

	[Key]
	[Column("CHILDID")]
	[StringLength(100)]
	public string Childid { get; set; }

	[Key]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Column("RELTYPE")]
	[StringLength(40)]
	public string Reltype { get; set; }
}
