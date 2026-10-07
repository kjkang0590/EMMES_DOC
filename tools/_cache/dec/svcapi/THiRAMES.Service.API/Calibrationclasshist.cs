using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CST_CALIBRATIONCLASSHIST")]
public class Calibrationclasshist : EntityTemplate
{
	public override string TableName => "CST_CALIBRATIONCLASSHIST";

	public override string GroupName => "CST_CALIBRATIONCLASSHIST";

	public override string TableType => "HIST";

	[Key]
	[Column("LASTEVENTSEQ")]
	public string Lasteventseq { get; set; }

	[Column("CALIBRATIONCLASSID")]
	[StringLength(40)]
	public string Calibrationclassid { get; set; }

	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Column("CALIBRATIONCLASSNAME")]
	[StringLength(100)]
	public string Calibrationclassname { get; set; }

	[Column("LINEID")]
	[StringLength(40)]
	public string Lineid { get; set; }
}
