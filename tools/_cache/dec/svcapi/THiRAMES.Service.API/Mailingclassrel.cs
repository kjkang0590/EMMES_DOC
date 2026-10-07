using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CST_MAILINGCLASSREL")]
public class Mailingclassrel : EntityTemplate
{
	public override string TableName => "CST_MAILINGCLASSREL";

	public override string GroupName => "CST_MAILINGCLASSREL";

	public override string TableType => "MAIN";

	[Key]
	[Column("USERCLASSID")]
	[StringLength(40)]
	public string Userclassid { get; set; }

	[Key]
	[Column("USERID")]
	[StringLength(40)]
	public string Userid { get; set; }

	[Key]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Column("ALARMDELIVERYGROUPID")]
	[StringLength(40)]
	public string Alarmdeliverygroupid { get; set; }
}
