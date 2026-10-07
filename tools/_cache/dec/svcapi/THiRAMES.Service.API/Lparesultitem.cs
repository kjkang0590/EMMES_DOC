using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CST_LPARESULTITEM")]
public class Lparesultitem : EntityTemplate
{
	public override string TableName => "CST_LPARESULTITEM";

	public override string GroupName => "CST_LPARESULTITEM";

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
	[Column("LPAITEMID")]
	[StringLength(40)]
	public string Lpaitemid { get; set; }

	[Key]
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
