using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CST_MAILINGCLASSHIST")]
public class Mailingclasshist : EntityTemplate
{
	public override string TableName => "CST_MAILINGCLASSHIST";

	public override string GroupName => "CST_MAILINGCLASSHIST";

	public override string TableType => "HIST";

	[Key]
	[Column("LASTEVENTSEQ")]
	public long Lasteventseq { get; set; }

	[Required]
	[Column("USERCLASSID")]
	[StringLength(40)]
	public string Userclassid { get; set; }

	[Required]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Column("USERCLASSNAME")]
	[StringLength(40)]
	public string Userclassname { get; set; }

	[Column("SHORTNAME")]
	[StringLength(40)]
	public string Shotname { get; set; }

	[Column("USERCLASSTYPE")]
	[StringLength(40)]
	public string Userclasstype { get; set; }

	[Column("DIVISION")]
	[StringLength(40)]
	public string Division { get; set; }

	[Column("UISEQUENCE", TypeName = "numeric(4, 0)")]
	public int? Uisequence { get; set; }
}
