using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CST_PMRESULTHIST")]
public class Pmresulthist : EntityTemplate
{
	public override string TableName => "CST_PMRESULTHIST";

	public override string GroupName => "CST_PMRESULTHIST";

	public override string TableType => "HIST";

	[Key]
	[Column("LASTEVENTSEQ")]
	public string Lasteventseq { get; set; }

	[Column("PMSYSID")]
	public long Pmsysid { get; set; }

	[Column("PMDEFINITIONID")]
	[StringLength(40)]
	public string Pmdefinitionid { get; set; }

	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Column("PMDEFINITIONAME")]
	[StringLength(2000)]
	public string Pmdefinitionname { get; set; }

	[Column("PMTYPE")]
	[StringLength(40)]
	public string Pmtype { get; set; }

	[Column("PROCESSTYPE")]
	[StringLength(40)]
	public string Processtype { get; set; }

	[Column("EQUIPMENTID")]
	[StringLength(40)]
	public string Equipmentid { get; set; }

	[Column("PARENTEQUIPMENTID")]
	[StringLength(40)]
	public string Parentequipmentid { get; set; }

	[Column("ROOTEQUIPMENTID")]
	[StringLength(40)]
	public string Rootequipmentid { get; set; }

	[Column("PROCESSSEGMENTID")]
	[StringLength(40)]
	public string Processsegmentid { get; set; }

	[Column("STATE")]
	[StringLength(40)]
	public string State { get; set; }

	[Column("MAINUSERID")]
	[StringLength(40)]
	public string Mainuserid { get; set; }

	[Column("SUBUSERID")]
	[StringLength(40)]
	public string Subuserid { get; set; }

	[Column("SCHEDULESTARTDATE")]
	public DateTime? Schedulestartdate { get; set; }

	[Column("SCHEDULEENDDATE")]
	public DateTime? Scheduleenddate { get; set; }

	[Column("STARTDATE")]
	public DateTime? Startdate { get; set; }

	[Column("ENDDATE")]
	public DateTime? Enddate { get; set; }

	[Column("LINEID")]
	[StringLength(40)]
	public string Lineid { get; set; }
}
