using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("RPT_PRODUCTION_PREV_PLAN_RESULT")]
public class Productionprevplanresult : EntityTemplate
{
	public override string TableName => "RPT_PRODUCTION_PREV_PLAN_RESULT";

	public override string GroupName => "RPT_PRODUCTION_PREV_PLAN_RESULT";

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

	[Column("PLAN_BM_NORMAL_INPUT")]
	public decimal? Plan_bm_normal_input { get; set; }

	[Column("RESULT_BM_NORMAL_INPUT")]
	public decimal? Result_bm_normal_input { get; set; }

	[Column("PLAN_BP_NORMAL_OUTPUT")]
	public decimal? Plan_bp_normal_output { get; set; }

	[Column("RESULT_BP_NORMAL_OUTPUT")]
	public decimal? Result_bp_normal_output { get; set; }

	[Column("PLAN_BP_NODISC_INPUT")]
	public decimal? Plan_bp_nodisc_input { get; set; }

	[Column("RESULT_BP_NODISC_INPUT")]
	public decimal? Result_bp_nodisc_input { get; set; }

	[Column("PLAN_BP_NODISC_OUTPUT")]
	public decimal? Plan_bp_nodisc_output { get; set; }

	[Column("RESULT_BP_NODISC_OUTPUT")]
	public decimal? Result_bp_nodisc_output { get; set; }

	[Column("PROCESSTYPE")]
	[StringLength(40)]
	public string Processtype { get; set; }
}
