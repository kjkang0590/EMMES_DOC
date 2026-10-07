using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CST_PMDEFINITIONHIST")]
public class Pmdefinitionhist : EntityTemplate
{
	public override string TableName => "CST_PMDEFINITIONHIST";

	public override string GroupName => "CST_PMDEFINITIONHIST";

	public override string TableType => "HIST";

	[Key]
	[Column("LASTEVENTSEQ")]
	public string Lasteventseq { get; set; }

	[Column("PMDEFINITIONID")]
	[StringLength(40)]
	public string Pmdefinitionid { get; set; }

	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Column("PMSYSNAME")]
	[StringLength(40)]
	public string Pmsysname { get; set; }

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

	[Column("SCHEDULEUNIT")]
	[StringLength(40)]
	public string Scheduleunit { get; set; }

	[Column("SCHEDULETARGET")]
	[StringLength(40)]
	public string Scheduletarget { get; set; }

	[Column("SCHEDULEENDDATE")]
	[StringLength(40)]
	public string Scheduleenddate { get; set; }

	[Column("ISAUTOSCHEDULE")]
	[StringLength(40)]
	public string Isautoschedule { get; set; }

	[Column("NEXTSCHEDULEDATE")]
	[StringLength(40)]
	public string Nextscheduledate { get; set; }

	[Column("LINEID")]
	[StringLength(40)]
	public string Lineid { get; set; }

	[Column("VALIDSTARTTIME")]
	public DateTime? Validstarttime { get; set; }

	[Column("VALIDENDTIME")]
	public DateTime? Validendtime { get; set; }
}
