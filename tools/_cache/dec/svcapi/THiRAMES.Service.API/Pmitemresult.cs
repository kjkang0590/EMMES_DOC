using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CST_PMITEMRESULT")]
public class Pmitemresult : EntityTemplate
{
	public override string TableName => "CST_PMITEMRESULT";

	public override string GroupName => "CST_PMITEMRESULT";

	public override string TableType => "MAIN";

	[Key]
	[Column("PMSYSID")]
	public long Pmsysid { get; set; }

	[Key]
	[Column("PMDEFINITIONID")]
	[StringLength(40)]
	public string Pmdefinitionid { get; set; }

	[Key]
	[Column("PMITEMID")]
	[StringLength(40)]
	public string Pmitemid { get; set; }

	[Key]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Column("PMTYPE")]
	[StringLength(40)]
	public string Pmtype { get; set; }

	[Column("UNITID")]
	[StringLength(40)]
	public string Unitid { get; set; }

	[Column("PMRESULT")]
	[StringLength(40)]
	public string Pmresult { get; set; }

	[Column("PMDETAILRESULT")]
	[StringLength(40)]
	public string Pmdetailresult { get; set; }

	[Column("LINEID")]
	[StringLength(40)]
	public string Lineid { get; set; }
}
