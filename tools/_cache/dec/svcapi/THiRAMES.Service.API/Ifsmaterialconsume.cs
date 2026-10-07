using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("IFS_PRD_MATERIALCONSUME")]
public class Ifsmaterialconsume : EntityTemplate
{
	public override string TableName => "IFS_PRD_MATERIALCONSUME";

	public override string GroupName => "IFS_PRD_MATERIALCONSUME";

	public override string TableType => "MAIN";

	[Key]
	[Column("EVENTSEQ")]
	public int Eventseq { get; set; }

	[Required]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Required]
	[Column("PRODUCTORDERID")]
	[StringLength(40)]
	public string Productorderid { get; set; }

	[Required]
	[Column("WORKORDERID")]
	[StringLength(40)]
	public string Workorderid { get; set; }

	[Required]
	[Column("MATERIALDEFINITIONID")]
	[StringLength(40)]
	public string Materialdefinitionid { get; set; }

	[Column("MATERIALTYPE")]
	[StringLength(40)]
	public string Materialtype { get; set; }

	[Required]
	[Column("LOTID")]
	[StringLength(40)]
	public string Lotid { get; set; }

	[Required]
	[Column("WORKDATE")]
	[StringLength(40)]
	public string Workdate { get; set; }

	[Required]
	[Column("QTY")]
	public decimal? Qty { get; set; }

	[Required]
	[Column("UNITID")]
	[StringLength(40)]
	public string Unitid { get; set; }

	[Column("LOCATION")]
	[StringLength(40)]
	public string Location { get; set; }

	[Column("WORKCENTERTYPE")]
	[StringLength(40)]
	public string Workcentertype { get; set; }

	[Column("METALITEMID")]
	[StringLength(40)]
	public string Metalitemid { get; set; }

	[Column("METALLOTID")]
	[StringLength(40)]
	public string Metallotid { get; set; }

	[Column("METALQTY")]
	[StringLength(40)]
	public decimal? Metalqty { get; set; }

	[Column("METALUNITID")]
	[StringLength(40)]
	public string Metalunitid { get; set; }

	[Column("RESERVED01")]
	[StringLength(40)]
	public string Reserved01 { get; set; }

	[Column("RESERVED02")]
	[StringLength(40)]
	public string Reserved02 { get; set; }

	[Column("RESERVED03")]
	[StringLength(40)]
	public string Reserved03 { get; set; }

	[Column("RESERVED04")]
	[StringLength(40)]
	public string Reserved04 { get; set; }

	[Column("RESERVED05")]
	[StringLength(40)]
	public string Reserved05 { get; set; }

	[Column("RESERVED06")]
	[StringLength(40)]
	public string Reserved06 { get; set; }

	[Column("RESERVED07")]
	[StringLength(40)]
	public string Reserved07 { get; set; }

	[Column("RESERVED08")]
	[StringLength(40)]
	public string Reserved08 { get; set; }

	[Column("RESERVED09")]
	[StringLength(40)]
	public string Reserved09 { get; set; }

	[Required]
	[Column("CUDFLAG")]
	[StringLength(40)]
	public string Cudflag { get; set; }

	[Column("PROCESSTIME")]
	[StringLength(40)]
	public DateTime? Processtime { get; set; }

	[Required]
	[Column("CANCELEVENTID")]
	[StringLength(40)]
	public string Canceleventid { get; set; }

	[Required]
	[Column("IFFLAG")]
	[StringLength(40)]
	public string Ifflag { get; set; }

	[Column("ERRORMESSAGE")]
	[StringLength(2000)]
	public string Errormessage { get; set; }

	[Column("MESWORKDATE")]
	[StringLength(40)]
	public string Mesworkdate { get; set; }

	[Column("PRODUCTLOTID")]
	[StringLength(40)]
	public string Productlotid { get; set; }
}
