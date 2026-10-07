using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CST_SAMPLEPOINTHIST")]
public class Samplepointhist : EntityTemplate
{
	public override string TableName => "CST_SAMPLEPOINTHIST";

	public override string GroupName => "CST_SAMPLEPOINTHIST";

	public override string TableType => "HIST";

	[Key]
	[Column("LASTEVENTSEQ")]
	public long Lasteventseq { get; set; }

	[Required]
	[Column("SAMPLEPOINTID")]
	[StringLength(40)]
	public string Samplepointid { get; set; }

	[Required]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Column("SAMPLEPOINTNAME")]
	[StringLength(100)]
	public string Samplepointname { get; set; }

	[Column("SAMPLETYPE")]
	[StringLength(40)]
	public string Sampletype { get; set; }

	[Column("EQUIPMENTID")]
	[StringLength(40)]
	public string Equipmentid { get; set; }

	[Column("EQUIPMENTCLASSID")]
	[StringLength(40)]
	public string Equipmentclassid { get; set; }

	[Column("PROCESSSEGMENTID")]
	[StringLength(40)]
	public string Processsegmentid { get; set; }

	[Column("PROCESSTYPE")]
	[StringLength(40)]
	public string Processtype { get; set; }

	[Column("ROOTEQUIPMENTID")]
	[StringLength(40)]
	public string Rootequipmentid { get; set; }

	[Column("LINEID")]
	[StringLength(40)]
	public string Lineid { get; set; }

	[Column("SAMPLEFREQUENCY")]
	[StringLength(100)]
	public string Samplefrequency { get; set; }

	[Column("BATCHTIMEINTERVAL")]
	[StringLength(100)]
	public string Batchtimeinterval { get; set; }

	[Column("AFTERSAMPLEFREQUENCY")]
	[StringLength(100)]
	public string Aftersamplefrequency { get; set; }
}
