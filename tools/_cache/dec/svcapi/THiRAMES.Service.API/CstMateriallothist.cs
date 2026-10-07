using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CST_MATERIALLOTHIST")]
public class CstMateriallothist : EntityTemplate
{
	public override string TableName => "CST_MATERIALLOTHIST";

	public override string GroupName => "CST_MATERIALLOTHIST";

	public override string TableType => "HIST";

	[Key]
	[Column("LASTEVENTSEQ")]
	public long Lasteventseq { get; set; }

	[Column("MATERIALLOTID")]
	[StringLength(40)]
	public string Materiallotid { get; set; }

	[Column("MATERIALDEFINITIONID")]
	[StringLength(40)]
	public string Materialdefinitionid { get; set; }

	[Column("LOCATION")]
	[StringLength(40)]
	public string Location { get; set; }

	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Column("MATERIALLOTNAME")]
	[StringLength(80)]
	public string Materiallotname { get; set; }

	[Column("MATERIALCLASSID")]
	[StringLength(40)]
	public string Materialclassid { get; set; }

	[Column("MATERIALTYPE")]
	[StringLength(40)]
	public string Materialtype { get; set; }

	[Column("PARENTMATERIALLOTID")]
	[StringLength(40)]
	public string Parentmateriallotid { get; set; }

	[Column("ROOTPARENTMATERIALLOTID")]
	[StringLength(40)]
	public string Rootparentmateriallotid { get; set; }

	[Column("STATE")]
	[StringLength(40)]
	public string State { get; set; }

	[Column("ORIGINALQTY")]
	public decimal? Originalqty { get; set; }

	[Column("QTY")]
	public decimal? Qty { get; set; }

	[Column("LOSSQTY")]
	public decimal? Lossqty { get; set; }

	[Column("UNITID")]
	[StringLength(40)]
	public string Unitid { get; set; }

	[Column("PRODUCTORDERID")]
	[StringLength(40)]
	public string Productorderid { get; set; }

	[Column("WORKORDERID")]
	[StringLength(40)]
	public string Workorderid { get; set; }

	[Column("EQUIPMENTID")]
	[StringLength(40)]
	public string Equipmentid { get; set; }

	[Column("PORTID")]
	[StringLength(40)]
	public string Portid { get; set; }

	[Column("RECEIVEDQTY")]
	public decimal? Receivedqty { get; set; }

	[Column("SOURCEINPUTID")]
	[StringLength(40)]
	public string Sourceinputid { get; set; }

	[Column("MERGEMATERIALLOTID")]
	[StringLength(40)]
	public string Mergemateriallotid { get; set; }

	[Column("VENDORID")]
	[StringLength(40)]
	public string Vendorid { get; set; }

	[Column("POSITION")]
	public int Position { get; set; }

	[Column("MOVETIME")]
	public DateTime? Movetime { get; set; }

	[Column("RECEIVEDTIME")]
	public DateTime? Receivedtime { get; set; }

	[Column("HOLDTIME")]
	public DateTime? Holdtime { get; set; }

	[Column("HOLDER")]
	[StringLength(40)]
	public string Holder { get; set; }

	[Column("RECLAIMCOUNT")]
	public int Reclaimcount { get; set; }

	[Column("TIMERSTARTTIME")]
	public DateTime? Timerstarttime { get; set; }

	[Column("TIMERENDTIME")]
	public DateTime? Timerendtime { get; set; }

	[Column("PREVSTATE")]
	[StringLength(40)]
	public string Prevstate { get; set; }

	[Column("PREVQTY")]
	public decimal? Prevqty { get; set; }

	[Column("PREVLOCATION")]
	[StringLength(40)]
	public string Prevlocation { get; set; }

	[Column("ISQTYMANAGED")]
	[StringLength(1)]
	public string Isqtymanaged { get; set; }

	[Column("HISTORYFLAG")]
	[StringLength(1)]
	public string Historyflag { get; set; }

	[Column("STOCKDATE")]
	public DateTime? Stockdate { get; set; }

	[Column("EXPIREDATE")]
	public DateTime? Expiredate { get; set; }

	[Column("PRODUCTDATE")]
	public DateTime? Productdate { get; set; }

	[Column("GRADE")]
	[StringLength(40)]
	public string Grade { get; set; }

	[Column("KITTINGTIME")]
	public DateTime? Kittingtime { get; set; }

	[Column("ISKITTING")]
	[StringLength(40)]
	public string Iskitting { get; set; }

	[Column("RESERVED01")]
	[StringLength(100)]
	public string Reserved01 { get; set; }

	[Column("RESERVED02")]
	[StringLength(100)]
	public string Reserved02 { get; set; }

	[Column("RESERVED03")]
	[StringLength(100)]
	public string Reserved03 { get; set; }

	[Column("RESERVED04")]
	[StringLength(100)]
	public string Reserved04 { get; set; }

	[Column("RESERVED05")]
	[StringLength(100)]
	public string Reserved05 { get; set; }

	[Column("RESERVED06")]
	[StringLength(100)]
	public string Reserved06 { get; set; }

	[Column("RESERVED07")]
	[StringLength(100)]
	public string Reserved07 { get; set; }

	[Column("RESERVED08")]
	[StringLength(100)]
	public string Reserved08 { get; set; }

	[Column("RESERVED09")]
	[StringLength(100)]
	public string Reserved09 { get; set; }

	[Column("INSPREQNO")]
	[StringLength(40)]
	public string Inspreqno { get; set; }
}
