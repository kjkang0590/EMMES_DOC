using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CST_CALIBRATIONCLASS")]
public class Calibrationclass : EntityTemplate
{
	public override string TableName => "CST_CALIBRATIONCLASS";

	public override string GroupName => "CST_CALIBRATIONCLASS";

	public override string TableType => "MAIN";

	[Key]
	[Column("CALIBRATIONCLASSID")]
	[StringLength(40)]
	public string Calibrationclassid { get; set; }

	[Key]
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
