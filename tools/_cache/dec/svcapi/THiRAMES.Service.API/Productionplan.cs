using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("RPT_PRODUCTION_PLAN")]
public class Productionplan : EntityTemplate
{
	public override string TableName => "RPT_PRODUCTION_PLAN";

	public override string GroupName => "RPT_PRODUCTION_PLAN";

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

	[Column("PLAN_BM_SILO_INPUT")]
	public decimal? Plan_bm_silo_input { get; set; }

	[Column("PLAN_FIRING_INPUT")]
	public decimal? Plan_firing_input { get; set; }

	[Column("PLAN_FIRING_OUTPUT")]
	public decimal? Plan_firing_output { get; set; }

	[Column("PLAN_PREMIX_INPUT")]
	public decimal? Plan_premix_input { get; set; }

	[Column("PLAN_REACTOR_INPUT")]
	public decimal? Plan_reactor_input { get; set; }

	[Column("PLAN_DRY_INPUT")]
	public decimal? Plan_dry_input { get; set; }

	[Column("PLAN_DRY_OUTPUT")]
	public decimal? Plan_dry_output { get; set; }

	[Column("PLAN_LI2CO3_OUTPUT")]
	public decimal? Plan_li2co3_output { get; set; }

	[Column("PLAN_LI3PO4_OUTPUT")]
	public decimal? Plan_li3po4_output { get; set; }

	[Column("PLAN_PK1501_INPUT")]
	public decimal? Plan_pk1501_input { get; set; }

	[Column("PLAN_PK1502_INPUT")]
	public decimal? Plan_pk1502_input { get; set; }

	[Column("PLAN_PK1503_INPUT")]
	public decimal? Plan_pk1503_input { get; set; }

	[Column("PLAN_PK1504_INPUT")]
	public decimal? Plan_pk1504_input { get; set; }

	[Column("PLAN_CO_EXT_OUTPUT")]
	public decimal? Plan_co_ext_output { get; set; }

	[Column("PLAN_NI_EXT_OUTPUT")]
	public decimal? Plan_ni_ext_output { get; set; }

	[Column("PLAN_NI3SO4_OUTPUT")]
	public decimal? Plan_ni3so4_output { get; set; }

	[Column("PLAN_PREMIX_OUTPUT")]
	public decimal? Plan_premix_output { get; set; }

	[Column("PLAN_REACTOR_OUTPUT")]
	public decimal? Plan_reactor_output { get; set; }

	[Column("PLAN_V1517NCM_SULFATE_INPUT")]
	public decimal? Plan_v1517ncm_sulfate_input { get; set; }

	[Column("PLAN_V1523NM_SULFATE_INPUT")]
	public decimal? Plan_v1523nm_sulfate_input { get; set; }

	[Column("PLAN_V1526N_SULFATE_INPUT")]
	public decimal? Plan_v1526n_sulfate_input { get; set; }

	[Column("PLAN_V1531N_SULFATE_INPUT")]
	public decimal? Plan_v1531n_sulfate_input { get; set; }

	[Column("PLAN_CR_FEEDTANK_INPUT")]
	public decimal? Plan_cr_feedtank_input { get; set; }
}
