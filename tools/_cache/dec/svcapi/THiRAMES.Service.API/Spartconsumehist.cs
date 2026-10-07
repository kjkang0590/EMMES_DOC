using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CST_SPARTCONSUMEHIST")]
public class Spartconsumehist : EntityTemplate
{
	public override string TableName => "CST_SPARTCONSUMEHIST";

	public override string GroupName => "CST_SPARTCONSUMEHIST";

	public override string TableType => "HIST";

	[Key]
	[Column("LASTEVENTSEQ")]
	public long Lasteventseq { get; set; }

	[Column("BMID")]
	[StringLength(40)]
	public string Bmid { get; set; }

	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Column("SPARTDEFINITION")]
	[StringLength(40)]
	public string Spartdefinition { get; set; }

	[Column("QTY")]
	[StringLength(40)]
	public string Qty { get; set; }

	[Column("UNITID")]
	[StringLength(40)]
	public string Unitid { get; set; }

	[Column("PROCESSSEGMENTID")]
	[StringLength(40)]
	public string Processsegmentid { get; set; }

	[Column("EQUIPMENTID")]
	[StringLength(40)]
	public string Equipmentid { get; set; }

	[Column("LOCATION")]
	[StringLength(40)]
	public string Location { get; set; }

	[Column("LINEID")]
	[StringLength(40)]
	public string Lineid { get; set; }

	[Column("INTERFACEFLAG")]
	[StringLength(40)]
	public string Interfaceflag { get; set; }

	[Column("INTERFACEACTIONFLAG")]
	[StringLength(40)]
	public string Interfaceactionflag { get; set; }

	[Column("INTERFACETIME")]
	public DateTime? Interfacetime { get; set; }

	[Column("MAINUSERID")]
	[StringLength(40)]
	public string Mainuserid { get; set; }

	[Column("SUBUSERID")]
	[StringLength(40)]
	public string Subuserid { get; set; }

	[Column("PMSYSID")]
	[StringLength(40)]
	public string Pmsysid { get; set; }
}
