using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CST_SAVEEISTRACKINGMESSAGE")]
public class CstSaveeistrackingmessage : EntityTemplate
{
	public override string TableName => "CST_SAVEEISTRACKINGMESSAGE";

	public override string GroupName => "CST_SAVEEISTRACKINGMESSAGE";

	public override string TableType => "MAIN";

	[Key]
	[Column("MESSAGENAME")]
	[StringLength(40)]
	public string Messagename { get; set; }

	[Key]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Key]
	[Column("REQUESTID")]
	[StringLength(40)]
	public string Requestid { get; set; }

	[Key]
	[Column("CLIENTTIME")]
	public DateTime Clienttime { get; set; }

	[Key]
	[Column("STATUS")]
	[StringLength(40)]
	public string Status { get; set; }

	[Column("FROMEQUIPMENTID")]
	[StringLength(40)]
	public string Fromequipmentid { get; set; }

	[Column("TOEQUIPMENTID")]
	[StringLength(40)]
	public string Toequipmentid { get; set; }

	[Column("TARGET")]
	[StringLength(40)]
	public string Target { get; set; }

	[Column("VALUE1")]
	public decimal Value1 { get; set; }

	[Column("VALUE2")]
	public decimal Value2 { get; set; }

	[Column("VALUE3")]
	public decimal Value3 { get; set; }

	[Column("VALUE4")]
	public decimal Value4 { get; set; }

	[Column("ISAVAILABLE")]
	[StringLength(1)]
	public string Isavailable { get; set; }

	[Column("ISUSE")]
	[StringLength(1)]
	public string Isuse { get; set; }

	[Column("MESSAGE")]
	[StringLength(-1)]
	public string Message { get; set; }
}
