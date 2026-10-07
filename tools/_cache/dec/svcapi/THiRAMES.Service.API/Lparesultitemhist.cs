using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CST_LPARESULTITEMHIST")]
public class Lparesultitemhist : EntityTemplate
{
	public override string TableName => "CST_LPARESULTITEMHIST";

	public override string GroupName => "CST_LPARESULTITEMHIST";

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
	[Column("LPAITEMID")]
	[StringLength(40)]
	public string Lpaitemid { get; set; }

	[Required]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Column("INSPUSER")]
	[StringLength(40)]
	public string Inspuser { get; set; }

	[Column("ITEMVALUE")]
	[StringLength(40)]
	public string Itemvalue { get; set; }
}
