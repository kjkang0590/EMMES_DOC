using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("IFS_MAT_MATERIALTRANSFER")]
public class Ifsmaterialtransfer : EntityTemplate
{
	public override string TableName => "IFS_MAT_MATERIALTRANSFER";

	public override string GroupName => "IFS_MAT_MATERIALTRANSFER";

	public override string TableType => "MAIN";

	[Key]
	[Column("EVENTSEQ")]
	public int Eventseq { get; set; }

	[Required]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Required]
	[Column("REQNO")]
	[StringLength(40)]
	public string Reqno { get; set; }

	[Required]
	[Column("SEQUENCE")]
	[StringLength(40)]
	public string Sequence { get; set; }

	[Required]
	[Column("FROMLOCATION")]
	[StringLength(40)]
	public string Fromlocation { get; set; }

	[Required]
	[Column("TOLOCATION")]
	[StringLength(40)]
	public string Tolocation { get; set; }

	[Required]
	[Column("ITEMID")]
	[StringLength(40)]
	public string Itemid { get; set; }

	[Required]
	[Column("MATERIALLOTID")]
	[StringLength(40)]
	public string Materiallotid { get; set; }

	[Required]
	[Column("QTY")]
	public decimal? Qty { get; set; }

	[Required]
	[Column("UNITID")]
	[StringLength(40)]
	public string Unitid { get; set; }

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
	[Column("IFFLAG")]
	[StringLength(40)]
	public string Ifflag { get; set; }

	[Column("ERRORMESSAGE")]
	[StringLength(2000)]
	public string Errormessage { get; set; }
}
