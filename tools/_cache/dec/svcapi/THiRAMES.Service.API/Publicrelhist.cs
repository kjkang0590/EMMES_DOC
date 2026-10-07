using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CST_PUBLICRELHIST")]
public class Publicrelhist : EntityTemplate
{
	public override string TableName => "CST_PUBLICRELHIST";

	public override string GroupName => "CST_PUBLICRELHIST";

	public override string TableType => "HIST";

	[Key]
	[Column("LASTEVENTSEQ")]
	public long Lasteventseq { get; set; }

	[Required]
	[Column("PARENTID")]
	[StringLength(40)]
	public string Parentid { get; set; }

	[Required]
	[Column("CHILDID")]
	[StringLength(40)]
	public string Childid { get; set; }

	[Required]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Column("RELTYPE")]
	[StringLength(40)]
	public string Reltype { get; set; }
}
