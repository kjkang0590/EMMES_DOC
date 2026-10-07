using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CST_CALIBRATIONRESULT")]
public class Calibrationresult : EntityTemplate
{
	public override string TableName => "CST_CALIBRATIONRESULT";

	public override string GroupName => "CST_CALIBRATIONRESULT";

	public override string TableType => "MAIN";

	[Key]
	[Column("CALIBRATIONDEFINITIONID")]
	[StringLength(40)]
	public string Calibrationdefinitionid { get; set; }

	[Key]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Key]
	[Column("CALIBRATIONDATE")]
	[StringLength(40)]
	public string Calibrationdate { get; set; }

	[Column("CORRECTIONID")]
	[StringLength(40)]
	public string Correctionid { get; set; }

	[Column("CALIBRATIONDOCUMENT")]
	[StringLength(200)]
	public string Calibrationdocument { get; set; }

	[Column("LINEID")]
	[StringLength(40)]
	public string Lineid { get; set; }
}
