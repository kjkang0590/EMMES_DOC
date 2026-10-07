using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CUS_PRODUCTWORKORDERRELHIST")]
public class Productworkorderrelhist : EntityTemplate
{
	public override string TableName => "CUS_PRODUCTWORKORDERRELHIST";

	public override string GroupName => "CUS_PRODUCTWORKORDERRELHIST";

	public override string TableType => "HIST";

	[Key]
	[Column("LASTEVENTSEQ")]
	public long Lasteventseq { get; set; }

	[Required]
	[Column("PRODUCTDEFINITIONID")]
	[StringLength(40)]
	public string Productdefinitionid { get; set; }

	[Required]
	[Column("WORKORDERPRODUCTITEMID")]
	[StringLength(40)]
	public string Workorderproductitemid { get; set; }

	[Required]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Column("UISEQUENCE", TypeName = "numeric(4, 0)")]
	public int? Uisequence { get; set; }

	[Column("SCHEDULEUNIT")]
	[StringLength(40)]
	public string Scheduleunit { get; set; }
}
