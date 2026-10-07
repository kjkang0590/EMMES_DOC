using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CST_INCONGRUITY")]
public class Incongruity : EntityTemplate
{
	public override string TableName => "CST_INCONGRUITY";

	public override string GroupName => "CST_INCONGRUITY";

	public override string TableType => "MAIN";

	[Key]
	[Column("LOTID")]
	[StringLength(40)]
	public string Lotid { get; set; }

	[Key]
	[Column("INCONGRUITYTYPE")]
	[StringLength(40)]
	public string Incongruitytype { get; set; }

	[Key]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Column("OCCURRENCEDATE")]
	public DateTime? Occurrencedate { get; set; }

	[Column("WRITINGDEPT")]
	[StringLength(40)]
	public string Writingdept { get; set; }

	[Column("GRADE")]
	[StringLength(40)]
	public string Grade { get; set; }

	[Column("PROCESSSEGMENTID")]
	[StringLength(40)]
	public string Processsegmentid { get; set; }

	[Column("QTY")]
	[StringLength(40)]
	public string Qty { get; set; }

	[Column("WORKDATE")]
	public DateTime? Workdate { get; set; }

	[Column("WORKNO")]
	[StringLength(40)]
	public string Workno { get; set; }

	[Column("INCONGRUITYNOTE")]
	[StringLength(4000)]
	public string Incongruitynote { get; set; }

	[Column("CAUSE")]
	[StringLength(4000)]
	public string Cause { get; set; }

	[Column("MEASURES")]
	[StringLength(4000)]
	public string Measures { get; set; }

	[Column("MEASURESRESULT")]
	[StringLength(40)]
	public string Measuresresult { get; set; }

	[Column("PROCESSRESULT")]
	[StringLength(40)]
	public string Processresult { get; set; }

	[Column("PROCESSDATE")]
	[StringLength(40)]
	public string Processdate { get; set; }

	[Column("PROCESSDEPT")]
	[StringLength(40)]
	public string Processdept { get; set; }

	[Column("PROCESSOR")]
	[StringLength(40)]
	public string Processor { get; set; }

	[Column("APPROVALRESULT")]
	[StringLength(40)]
	public string Approvalresult { get; set; }

	[Column("ISNOTICE")]
	[StringLength(40)]
	public string Isnotice { get; set; }

	[Column("RELEASECODE")]
	[StringLength(100)]
	public string Releasecode { get; set; }

	[Column("LINEID")]
	[StringLength(100)]
	public string Lineid { get; set; }
}
