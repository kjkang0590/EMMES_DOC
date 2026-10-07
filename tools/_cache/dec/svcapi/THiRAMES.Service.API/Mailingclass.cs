using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CST_MAILINGCLASS")]
public class Mailingclass : EntityTemplate
{
	public override string TableName => "CST_MAILINGCLASS";

	public override string GroupName => "CST_MAILINGCLASS";

	public override string TableType => "MAIN";

	[Key]
	[Column("USERCLASSID")]
	[StringLength(40)]
	public string Userclassid { get; set; }

	[Key]
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

	[Column("ALARMDELIVERYGROUPID")]
	[StringLength(40)]
	public string Alarmdeliverygroupid { get; set; }

	[Column("ALARMDELIVERYGROUPNAME")]
	[StringLength(40)]
	public string Alarmdeliverygroupname { get; set; }
}
