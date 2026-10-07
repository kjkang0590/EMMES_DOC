using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CUS_PALLETLOTHIST")]
public class Palletlothist : EntityTemplate
{
	public override string TableName => "CUS_PALLETLOTHIST";

	public override string GroupName => "CUS_PALLETLOTHIST";

	public override string TableType => "HIST";

	[Key]
	[Column("LASTEVENTSEQ")]
	public long Lasteventseq { get; set; }

	[Required]
	[Column("PALLETLOTID")]
	[StringLength(40)]
	public string Palletlotid { get; set; }

	[Required]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Column("PALLETLOTNAME")]
	[StringLength(40)]
	public string Palletlotname { get; set; }

	[Column("MATERIALCLASSID")]
	[StringLength(40)]
	public string Materialclassid { get; set; }

	[Column("MATERIALDEFINITIONID")]
	[StringLength(40)]
	public string Materialdefinitionid { get; set; }

	[Column("MATERIALTYPE")]
	[StringLength(40)]
	public string Materialtype { get; set; }

	[Column("STATE")]
	[StringLength(40)]
	public string State { get; set; }

	[Column("ORIGINALQTY")]
	public decimal? originalqty { get; set; }

	[Column("QTY")]
	public decimal? Qty { get; set; }

	[Column("LOSSQTY")]
	public decimal? Lossqty { get; set; }

	[Column("UNITID")]
	[StringLength(40)]
	public string Unitid { get; set; }

	[Column("LOCATION")]
	[StringLength(40)]
	public string Location { get; set; }

	[Column("DELIVERYORDERID")]
	[StringLength(40)]
	public string Deliveryorderid { get; set; }

	[Column("PRODUCTORDERID")]
	[StringLength(40)]
	public string Productorderid { get; set; }

	[Column("WORKORDERID")]
	[StringLength(40)]
	public string Workorderid { get; set; }

	[Column("CUSTOMERID")]
	[StringLength(40)]
	public string Customerid { get; set; }

	[Column("MOVETIME")]
	public DateTime? Movetime { get; set; }

	[Column("RECEIVEDTIME")]
	public DateTime? Receivedtime { get; set; }

	[Column("PREVSTATE")]
	[StringLength(40)]
	public string Prevstate { get; set; }

	[Column("PREVQTY")]
	public decimal? Prevqty { get; set; }

	[Column("PREVLOCATION")]
	[StringLength(40)]
	public string Prevlocation { get; set; }

	[Column("HISTORYFLAG")]
	[StringLength(1)]
	public string Historyflag { get; set; }

	[Column("STOCKDATE")]
	public DateTime? Stockdate { get; set; }

	[Column("GRADEID")]
	[StringLength(40)]
	public string Gradeid { get; set; }

	[Column("PALLETSTOREDNO")]
	[StringLength(40)]
	public string Palletstoredno { get; set; }

	[Column("PALLETSTOREDTYPE")]
	[StringLength(40)]
	public string Palletstoredtype { get; set; }

	[Column("GRADETYPE")]
	[StringLength(40)]
	public string Gradetype { get; set; }

	[Column("DELIVERYITEMNO")]
	[StringLength(40)]
	public string Deliveryitemno { get; set; }

	[Column("SHIPPEDNO")]
	[StringLength(40)]
	public string Shippedno { get; set; }
}
