using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CST_CALIBRATIONDEFINITIONHIST")]
public class Calibrationdefinitionhist : EntityTemplate
{
	public override string TableName => "CST_CALIBRATIONDEFINITIONHIST";

	public override string GroupName => "CST_CALIBRATIONDEFINITIONHIST";

	public override string TableType => "HIST";

	[Key]
	[Column("LASTEVENTSEQ")]
	public long Lasteventseq { get; set; }

	[Required]
	[Column("CALIBRATIONDEFINITIONID")]
	[StringLength(40)]
	public string Calibrationdefinitionid { get; set; }

	[Required]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Column("CALIBRATIONDEFINITIONNAME")]
	[StringLength(200)]
	public string Calibrationdefinitionname { get; set; }

	[Column("CALIBRATIONCLASSID")]
	[StringLength(40)]
	public string Calibrationclassid { get; set; }

	[Column("CALIBRATIONTYPE")]
	[StringLength(40)]
	public string Calibrationtype { get; set; }

	[Column("PLANTID")]
	[StringLength(40)]
	public string Plantid { get; set; }

	[Column("LOCATION")]
	[StringLength(40)]
	public string Location { get; set; }

	[Column("LINEID")]
	[StringLength(40)]
	public string Lineid { get; set; }

	[Column("MEASURERANGE")]
	[StringLength(40)]
	public string Measurerange { get; set; }

	[Column("INTERVARLDAY")]
	public int Intervarlday { get; set; }

	[Column("CALIBRATIONCYCLE")]
	[StringLength(40)]
	public string Calibrationcycle { get; set; }

	[Column("CALIBRATIONDATE")]
	[StringLength(40)]
	public string Calibrationdate { get; set; }

	[Column("CALIBRATIONNEXTDATE")]
	[StringLength(40)]
	public string Calibrationnextdate { get; set; }

	[Column("CREATEDATE")]
	public DateTime? Createdate { get; set; }

	[Column("CALIBRATIONMODEL")]
	[StringLength(200)]
	public string Calibrationmodel { get; set; }

	[Column("EQUIPMENTID")]
	[StringLength(40)]
	public string Equipmentid { get; set; }

	[Column("DEPTID")]
	[StringLength(40)]
	public string Deptid { get; set; }

	[Column("MAKERCODEID")]
	[StringLength(40)]
	public string Makercodeid { get; set; }

	[Column("UNITID")]
	[StringLength(40)]
	public string Unitid { get; set; }

	[Column("EQUIPMENTNAME")]
	[StringLength(200)]
	public string Equipmentname { get; set; }
}
