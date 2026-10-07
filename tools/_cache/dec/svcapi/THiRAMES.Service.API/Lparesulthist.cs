using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CST_LPARESULTHIST")]
public class Lparesulthist : EntityTemplate
{
	public override string TableName => "CST_LPARESULTHIST";

	public override string GroupName => "CST_LPARESULTHIST";

	public override string TableType => "HIST";

	[Key]
	[Column("LASTEVENTSEQ")]
	public long Lasteventseq { get; set; }

	[Required]
	[Column("WORKDATE")]
	[StringLength(40)]
	public string Workdate { get; set; }

	[Required]
	[Column("LPAGROUP")]
	[StringLength(40)]
	public string Lpagroup { get; set; }

	[Required]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Column("LINEID")]
	[StringLength(40)]
	public string Lineid { get; set; }
}
