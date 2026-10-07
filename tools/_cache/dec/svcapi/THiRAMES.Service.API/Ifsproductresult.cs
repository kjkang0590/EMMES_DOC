using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("IFS_PRD_PRODUCTRESULT")]
public class Ifsproductresult : EntityTemplate
{
	public override string TableName => "IFS_PRD_PRODUCTRESULT";

	public override string GroupName => "IFS_PRD_PRODUCTRESULT";

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
	[Column("PRODUCTDEFINITIONID")]
	[StringLength(40)]
	public string Productdefinitionid { get; set; }

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

	[Required]
	[Column("DOCUMENTID")]
	[StringLength(18)]
	public string Documentid { get; set; }
}
