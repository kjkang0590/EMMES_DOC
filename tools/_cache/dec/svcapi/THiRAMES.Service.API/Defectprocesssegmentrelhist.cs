using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CUS_DEFECTPROCESSSEGMENTRELHIST")]
public class Defectprocesssegmentrelhist : EntityTemplate
{
	public override string TableName => "CUS_DEFECTPROCESSSEGMENTRELHIST";

	public override string GroupName => "CUS_DEFECTPROCESSSEGMENTREL";

	public override string TableType => "HIST";

	[Key]
	[Column("LASTEVENTSEQ")]
	public long Lasteventseq { get; set; }

	[Required]
	[Column("PROCESSSEGMENTID")]
	[StringLength(40)]
	public string Processsegmentid { get; set; }

	[Required]
	[Column("DEFECTID")]
	[StringLength(40)]
	public string Defectid { get; set; }

	[Required]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }
}
