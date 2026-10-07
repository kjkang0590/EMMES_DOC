using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CST_BMRESULTHIST")]
public class Bmresulthist : EntityTemplate
{
	public override string TableName => "CST_BMRESULTHIST";

	public override string GroupName => "CST_BMRESULTHIST";

	public override string TableType => "HIST";

	[Key]
	[Column("LASTEVENTSEQ")]
	public long Lasteventseq { get; set; }

	[Required]
	[Column("BMID")]
	[StringLength(40)]
	public string Bmid { get; set; }

	[Required]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Column("EQUIPMENTID")]
	[StringLength(40)]
	public string Equipmentid { get; set; }

	[Column("STATE")]
	[StringLength(40)]
	public string State { get; set; }

	[Column("STATEDATETIME")]
	public DateTime? Statedatetime { get; set; }

	[Column("PREVSTATE")]
	[StringLength(40)]
	public string Prevstate { get; set; }

	[Column("PREVSTATEDATETIME")]
	public DateTime? Prevstatedatetime { get; set; }

	[Column("REQUESTUSERID")]
	[StringLength(40)]
	public string Requestuserid { get; set; }

	[Column("REQUESTDESCRIPTION")]
	[StringLength(40)]
	public string Requestdescription { get; set; }

	[Column("REQUESTDATETIME")]
	public DateTime? Requestdatetime { get; set; }

	[Column("MAINUSERID")]
	[StringLength(40)]
	public string Mainuserid { get; set; }

	[Column("SUBUSERID")]
	[StringLength(40)]
	public string Subuserid { get; set; }

	[Column("RECEIPTDESCRIPTION")]
	[StringLength(40)]
	public string Receiptdescription { get; set; }

	[Column("FAILURECODE")]
	[StringLength(40)]
	public string Failurecode { get; set; }

	[Column("FAILUREDATETIME")]
	public DateTime? Failuredatetime { get; set; }

	[Column("REPAIRECODE")]
	[StringLength(40)]
	public string Repairecode { get; set; }

	[Column("REPAIRESTARTDATETIME")]
	public DateTime? Repairestartdatetime { get; set; }

	[Column("REPAIREENDDATETIME")]
	public DateTime? Repaireenddatetime { get; set; }

	[Column("REPAIREDESCRIPTION")]
	[StringLength(40)]
	public string Repairedescription { get; set; }

	[Column("PROCESSTYPE")]
	[StringLength(40)]
	public string Processtype { get; set; }

	[Column("ROOTEQUIPMENTID")]
	[StringLength(40)]
	public string Rootequipmentid { get; set; }

	[Column("LINEID")]
	[StringLength(40)]
	public string Lineid { get; set; }

	[Column("PMSYSID")]
	public long Pmsysid { get; set; }

	[Column("RECEIPTDATETIME")]
	public DateTime? Receiptdatetime { get; set; }

	[Column("RESULTDATETIME")]
	public DateTime? Resultdatetime { get; set; }

	[Column("REQUESTCODE")]
	[StringLength(40)]
	public string Requestcode { get; set; }

	[Column("REQUESTTYPE")]
	[StringLength(40)]
	public string Requesttype { get; set; }

	[Column("MAINTENANCETIME")]
	[StringLength(40)]
	public string Maintenancetime { get; set; }
}
