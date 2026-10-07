using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CST_LPARESULT")]
public class Lparesult : EntityTemplate
{
	public override string TableName => "CST_LPARESULT";

	public override string GroupName => "CST_LPARESULT";

	public override string TableType => "MAIN";

	[Key]
	[Column("WORKDATE")]
	[StringLength(40)]
	public string Workdate { get; set; }

	[Key]
	[Column("LPAGROUP")]
	[StringLength(40)]
	public string Lpagroup { get; set; }

	[Key]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Column("LINEID")]
	[StringLength(40)]
	public string Lineid { get; set; }
}
