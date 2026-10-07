using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CST_CALIBRATIONRESULTHIST")]
public class Calibrationresulthist : EntityTemplate
{
	public override string TableName => "CST_CALIBRATIONRESULTHIST";

	public override string GroupName => "CST_CALIBRATIONRESULTHIST";

	public override string TableType => "HIST";

	[Key]
	[Column("LASTEVENTSEQ")]
	public string Lasteventseq { get; set; }

	[Column("CALIBRATIONDEFINITIONID")]
	[StringLength(40)]
	public string Calibrationdefinitionid { get; set; }

	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

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
