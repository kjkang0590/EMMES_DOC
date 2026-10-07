using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CST_ALARMDEFUSERREL")]
public class Alarmdefuserrel : EntityTemplate
{
	public override string TableName => "CST_ALARMDEFUSERREL";

	public override string GroupName => "CST_ALARMDEFUSERREL";

	public override string TableType => "MAIN";

	[Key]
	[Column("ALARMDEFINITIONID")]
	[StringLength(40)]
	public string Alarmdefinitionid { get; set; }

	[Key]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Column("USERCLASSID")]
	[StringLength(40)]
	public string Userclassid { get; set; }

	[Column("ALARMDELIVERYGROUPID")]
	[StringLength(40)]
	public string Alarmdeliverygroupid { get; set; }
}
