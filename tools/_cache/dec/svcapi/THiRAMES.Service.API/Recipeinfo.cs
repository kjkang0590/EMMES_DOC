using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CST_RECIPEINFO")]
public class Recipeinfo : EntityTemplate
{
	public override string TableName => "CST_RECIPEINFO";

	public override string GroupName => "CST_RECIPEINFO";

	public override string TableType => "MAIN";

	[Key]
	[Column("RECIPEITEMID")]
	[StringLength(40)]
	public string Recipeitemid { get; set; }

	[Key]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Required]
	[Column("RECIPEITEMNAME")]
	[StringLength(80)]
	public string Recipeitemname { get; set; }

	[Required]
	[Column("EQUIPMENTID")]
	[StringLength(40)]
	public string Equipmentid { get; set; }

	[Required]
	[Column("EQUIPMENTNAME")]
	[StringLength(80)]
	public string Equipmentname { get; set; }

	[Column("ROOTEQUIPMENTID")]
	[StringLength(40)]
	public string Rootequipmentid { get; set; }

	[Column("TAGID")]
	[StringLength(40)]
	public string Tagid { get; set; }

	[Column("UNITID")]
	[StringLength(40)]
	public string Unitid { get; set; }

	[Column("LCL")]
	[StringLength(40)]
	public string Lcl { get; set; }

	[Column("UCL")]
	[StringLength(40)]
	public string Ucl { get; set; }

	[Column("TARGET")]
	[StringLength(40)]
	public string Target { get; set; }

	[Column("INEQUATION")]
	[StringLength(80)]
	public string Inequation { get; set; }

	[Column("LSL")]
	[StringLength(40)]
	public string Lsl { get; set; }

	[Column("USL")]
	[StringLength(40)]
	public string Usl { get; set; }

	[Column("RECIPEDESCRIPTION")]
	[StringLength(4000)]
	public string Recipedescription { get; set; }

	[Column("UISEQUENCE")]
	public string Uisequence { get; set; }
}
