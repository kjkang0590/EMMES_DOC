using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CST_INSPREQ")]
public class Inspreq : EntityTemplate
{
	public override string TableName => "CST_INSPREQ";

	public override string GroupName => "CST_INSPREQ";

	public override string TableType => "MAIN";

	[Key]
	[Column("INSPREQNO")]
	[StringLength(40)]
	public string Inspreqno { get; set; }

	[Key]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Required]
	[Column("INSPDEFINITIONSYSID")]
	[StringLength(40)]
	public string Inspdefinitionsysid { get; set; }

	[Required]
	[Column("COPERATOR")]
	[StringLength(40)]
	public string Coperator { get; set; }

	[Required]
	[Column("ITEMID")]
	[StringLength(40)]
	public string Itemid { get; set; }

	[Required]
	[Column("INSPTYPE")]
	[StringLength(40)]
	public string Insptype { get; set; }

	[Required]
	[Column("INSPSPEC")]
	[StringLength(40)]
	public string Inspspec { get; set; }

	[Required]
	[Column("REV")]
	public long Rev { get; set; }

	[Column("PROCESSDEFINITIONID")]
	[StringLength(40)]
	public string Processdefinitionid { get; set; }

	[Column("PROCESSSEGMENTID")]
	[StringLength(40)]
	public string Processsegmentid { get; set; }

	[Required]
	[Column("STATE")]
	[StringLength(40)]
	public string State { get; set; }

	[Required]
	[Column("INSPMETHOD")]
	[StringLength(40)]
	public string Inspmethod { get; set; }

	[Required]
	[Column("REPEATCOUNT")]
	public long Repeatcount { get; set; }

	[Required]
	[Column("CURRENTCOUNT")]
	public long Currentcount { get; set; }

	[Column("REQDATETIME")]
	public DateTime? Reqdatetime { get; set; }

	[Column("RECEPTDATETIME")]
	public DateTime? Receptdatetime { get; set; }

	[Column("FINALDATETIME")]
	public DateTime? Finaldatetime { get; set; }

	[Column("FINALJUDGE")]
	[StringLength(40)]
	public string Finaljudge { get; set; }

	[Column("MATERIALTYPE")]
	[StringLength(40)]
	public string Materialtype { get; set; }

	[Column("SAMPLEPOINTID")]
	[StringLength(40)]
	public string Samplepointid { get; set; }

	[Column("SAMPLELOTID")]
	[StringLength(40)]
	public string Samplelotid { get; set; }

	[Column("LOTID")]
	[StringLength(40)]
	public string Lotid { get; set; }

	[Column("QTY")]
	public decimal? Qty { get; set; }

	[Column("INSPRECEIPTTIME")]
	public DateTime? Inspreceipttime { get; set; }

	[Column("INSPSTARTTIME")]
	public DateTime? Inspstarttime { get; set; }

	[Column("INSPENDTIME")]
	public DateTime? Inspendtime { get; set; }

	[Column("INSPRECEIPTUSERID")]
	[StringLength(40)]
	public string Inspreceiptuserid { get; set; }

	[Column("INSPSTARTUSERID")]
	[StringLength(40)]
	public string Inspstartuserid { get; set; }

	[Column("INSPENDUSERID")]
	[StringLength(40)]
	public string Inspenduserid { get; set; }

	[Column("LOCATION")]
	[StringLength(40)]
	public string Location { get; set; }

	[Column("EQUIPMENTID")]
	[StringLength(40)]
	public string Equipmentid { get; set; }

	[Column("FINALUSERID")]
	[StringLength(40)]
	public string Finaluserid { get; set; }

	[Column("ERPINSPTYPE")]
	[StringLength(10)]
	public string Erpinsptype { get; set; }

	[Column("UNITID")]
	[StringLength(40)]
	public string Unitid { get; set; }
}
