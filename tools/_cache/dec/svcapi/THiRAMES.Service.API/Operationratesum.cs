using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("RPT_OPERATIONRATE_SUM")]
public class Operationratesum : EntityTemplate
{
	public override string TableName => "RPT_OPERATIONRATE_SUM";

	public override string GroupName => "RPT_OPERATIONRATE_SUM";

	public override string TableType => "MAIN";

	[Key]
	[Column("WORKDATE")]
	[StringLength(40)]
	public string Workdate { get; set; }

	[Key]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Column("YEARMONTH")]
	[StringLength(40)]
	public string Yearmonth { get; set; }

	[Column("YEARWEEK")]
	[StringLength(40)]
	public string Yearweek { get; set; }

	[Column("TIME_PREV_BM_NORMAL_RATE")]
	public decimal? Time_prev_bm_normal_rate { get; set; }

	[Column("PER_PREV_BM_NORMAL_RATE")]
	public decimal? Per_prev_bm_normal_rate { get; set; }

	[Column("TIME_PREV_BM_NOCHARGE_RATE")]
	public decimal? Time_prev_bm_nocharge_rate { get; set; }

	[Column("PER_PREV_BM_NOCHARGE_RATE")]
	public decimal? Per_prev_bm_nocharge_rate { get; set; }

	[Column("TIME_PREV_DRY_RATE")]
	public decimal? Time_prev_dry_rate { get; set; }

	[Column("PER_PREV_DRY_RATE")]
	public decimal? Per_prev_dry_rate { get; set; }

	[Column("TIME_PREV_PACKING_RATE")]
	public decimal? Time_prev_packing_rate { get; set; }

	[Column("PER_PREV_PACKING_RATE")]
	public decimal? Per_prev_packing_rate { get; set; }

	[Column("TIME_BP_INPUT_RATE")]
	public decimal? Time_bp_input_rate { get; set; }

	[Column("PER_BP_INPUT_RATE")]
	public decimal? Per_bp_input_rate { get; set; }

	[Column("TIME_KILN_RATE")]
	public decimal? Time_kiln_rate { get; set; }

	[Column("PER_KILN_RATE")]
	public decimal? Per_kiln_rate { get; set; }

	[Column("TIME_OFF_GAS_RATE")]
	public decimal? Time_off_gas_rate { get; set; }

	[Column("PER_OFF_GAS_RATE")]
	public decimal? Per_off_gas_rate { get; set; }

	[Column("TIME_PREMIX_RATE")]
	public decimal? Time_premix_rate { get; set; }

	[Column("PER_PREMIX_RATE")]
	public decimal? Per_premix_rate { get; set; }

	[Column("TIME_R1401_HPAL_RATE")]
	public decimal? Time_r1401_hpal_rate { get; set; }

	[Column("PER_R1401_HPAL_RATE")]
	public decimal? Per_r1401_hpal_rate { get; set; }

	[Column("TIME_R1402_RATE")]
	public decimal? Time_r1402_rate { get; set; }

	[Column("PER_R1402_RATE")]
	public decimal? Per_r1402_rate { get; set; }

	[Column("TIME_CE1401_RATE")]
	public decimal? Time_ce1401_rate { get; set; }

	[Column("PER_CE1401_RATE")]
	public decimal? Per_ce1401_rate { get; set; }

	[Column("TIME_PK1402_RATE")]
	public decimal? Time_pk1402_rate { get; set; }

	[Column("PER_PK1402_RATE")]
	public decimal? Per_pk1402_rate { get; set; }

	[Column("TIME_LI_PACKING_RATE")]
	public decimal? Time_li_packing_rate { get; set; }

	[Column("PER_LI_PACKING_RATE")]
	public decimal? Per_li_packing_rate { get; set; }

	[Column("TIME_R1403_RATE")]
	public decimal? Time_r1403_rate { get; set; }

	[Column("PER_R1403_RATE")]
	public decimal? Per_r1403_rate { get; set; }

	[Column("TIME_CE1402_RATE")]
	public decimal? Time_ce1402_rate { get; set; }

	[Column("PER_CE1402_RATE")]
	public decimal? Per_ce1402_rate { get; set; }

	[Column("TIME_PK1501_RATE")]
	public decimal? Time_pk1501_rate { get; set; }

	[Column("PER_PK1501_RATE")]
	public decimal? Per_pk1501_rate { get; set; }

	[Column("TIME_PK1502_RATE")]
	public decimal? Time_pk1502_rate { get; set; }

	[Column("PER_PK1502_RATE")]
	public decimal? Per_pk1502_rate { get; set; }

	[Column("TIME_PK1503_RATE")]
	public decimal? Time_pk1503_rate { get; set; }

	[Column("PER_PK1503_RATE")]
	public decimal? Per_pk1503_rate { get; set; }

	[Column("TIME_PK1504_RATE")]
	public decimal? Time_pk1504_rate { get; set; }

	[Column("PER_PK1504_RATE")]
	public decimal? Per_pk1504_rate { get; set; }

	[Column("TIME_COALESCER_RATE")]
	public decimal? Time_coalescer_rate { get; set; }

	[Column("PER_COALESCER_RATE")]
	public decimal? Per_coalescer_rate { get; set; }

	[Column("TIME_CO_TRANSFER_RATE")]
	public decimal? Time_co_transfer_rate { get; set; }

	[Column("PER_CO_TRANSFER_RATE")]
	public decimal? Per_co_transfer_rate { get; set; }

	[Column("TIME_CRYSTALIZER_RATE")]
	public decimal? Time_crystalizer_rate { get; set; }

	[Column("PER_CRYSTALIZER_RATE")]
	public decimal? Per_crystalizer_rate { get; set; }

	[Column("TIME_PK1602_RATE")]
	public decimal? Time_pk1602_rate { get; set; }

	[Column("PER_PK1602_RATE")]
	public decimal? Per_pk1602_rate { get; set; }

	[Column("TIME_NI_PACKING_RATE")]
	public decimal? Time_ni_packing_rate { get; set; }

	[Column("PER_NI_PACKING_RATE")]
	public decimal? Per_ni_packing_rate { get; set; }

	[Column("TIME_PREV_BM_NORMAL_SUM")]
	public decimal? Time_prev_bm_normal_sum { get; set; }

	[Column("TIME_PREV_BM_NOCHARGE_SUM")]
	public decimal? Time_prev_bm_nocharge_sum { get; set; }

	[Column("TIME_PREV_DRY_SUM")]
	public decimal? Time_prev_dry_sum { get; set; }

	[Column("TIME_PREV_PACKING_SUM")]
	public decimal? Time_prev_packing_sum { get; set; }

	[Column("TIME_BP_INPUT_SUM")]
	public decimal? Time_bp_input_sum { get; set; }

	[Column("TIME_KILN_SUM")]
	public decimal? Time_kiln_sum { get; set; }

	[Column("TIME_OFF_GAS_SUM")]
	public decimal? Time_off_gas_sum { get; set; }

	[Column("TIME_PREMIX_SUM")]
	public decimal? Time_premix_sum { get; set; }

	[Column("TIME_R1401_HPAL_SUM")]
	public decimal? Time_r1401_hpal_sum { get; set; }

	[Column("TIME_R1402_SUM")]
	public decimal? Time_r1402_sum { get; set; }

	[Column("TIME_CE1401_SUM")]
	public decimal? Time_ce1401_sum { get; set; }

	[Column("TIME_PK1402_SUM")]
	public decimal? Time_pk1402_sum { get; set; }

	[Column("TIME_LI_PACKING_SUM")]
	public decimal? Time_li_packing_sum { get; set; }

	[Column("TIME_R1403_SUM")]
	public decimal? Time_r1403_sum { get; set; }

	[Column("TIME_CE1402_SUM")]
	public decimal? Time_ce1402_sum { get; set; }

	[Column("TIME_PK1501_SUM")]
	public decimal? Time_pk1501_sum { get; set; }

	[Column("TIME_PK1502_SUM")]
	public decimal? Time_pk1502_sum { get; set; }

	[Column("TIME_PK1503_SUM")]
	public decimal? Time_pk1503_sum { get; set; }

	[Column("TIME_PK1504_SUM")]
	public decimal? Time_pk1504_sum { get; set; }

	[Column("TIME_COALESCER_SUM")]
	public decimal? Time_coalescer_sum { get; set; }

	[Column("TIME_CO_TRANSFER_SUM")]
	public decimal? Time_co_transfer_sum { get; set; }

	[Column("TIME_CRYSTALIZER_SUM")]
	public decimal? Time_crystalizer_sum { get; set; }

	[Column("TIME_PK1602_SUM")]
	public decimal? Time_pk1602_sum { get; set; }

	[Column("TIME_NI_PACKING_SUM")]
	public decimal? Time_ni_packing_sum { get; set; }
}
