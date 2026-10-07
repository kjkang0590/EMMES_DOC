using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CST_MAILINGCLASSRELHIST")]
public class Mailingclassrelhist : EntityTemplate
{
	public override string TableName => "CST_MAILINGCLASSRELHIST";

	public override string GroupName => "CST_MAILINGCLASSRELHIST";

	public override string TableType => "HIST";

	[Key]
	[Column("LASTEVENTSEQ")]
	public long Lasteventseq { get; set; }

	[Required]
	[Column("USERCLASSID")]
	[StringLength(40)]
	public string Userclassid { get; set; }

	[Required]
	[Column("USERID")]
	[StringLength(40)]
	public string Userid { get; set; }

	[Required]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }
}
