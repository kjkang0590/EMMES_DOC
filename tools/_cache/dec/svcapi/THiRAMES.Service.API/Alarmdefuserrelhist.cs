using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CST_ALARMDEFUSERRELHIST")]
public class Alarmdefuserrelhist : EntityTemplate
{
	public override string TableName => "CST_ALARMDEFUSERRELHIST";

	public override string GroupName => "CST_ALARMDEFUSERRELHIST";

	public override string TableType => "HIST";

	[Key]
	[Column("LASTEVENTSEQ")]
	public long Lasteventseq { get; set; }

	[Required]
	[Column("ALARMDEFINITIONID")]
	[StringLength(40)]
	public string Alarmdefinitionid { get; set; }

	[Required]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Column("USERCLASSID")]
	[StringLength(40)]
	public string Userclassid { get; set; }
}
