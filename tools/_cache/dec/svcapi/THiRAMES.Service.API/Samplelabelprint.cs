using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CST_SAMPLELABELPRINT")]
public class Samplelabelprint : EntityTemplate
{
	public override string TableName => "CST_SAMPLELABELPRINT";

	public override string GroupName => "CST_SAMPLELABELPRINT";

	public override string TableType => "MAIN";

	[Key]
	[Column("LASTEVENTSEQ")]
	public long Lasteventseq { get; set; }

	[Required]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Required]
	[Column("WORKDATE")]
	[StringLength(40)]
	public string Workdate { get; set; }

	[Column("INSPMETHOD")]
	[StringLength(40)]
	public string Inspmethod { get; set; }

	[Column("INSPTYPE")]
	[StringLength(40)]
	public string Insptype { get; set; }

	[Column("STARTLABELID")]
	[StringLength(40)]
	public string Startlabelid { get; set; }

	[Column("ENDLABELID")]
	[StringLength(40)]
	public string Endlabelid { get; set; }

	[Column("PRINTCOUNT")]
	public int Printcount { get; set; }

	[Column("PRINTERLOCATION")]
	[StringLength(40)]
	public string Printerlocation { get; set; }

	[Column("LINEID")]
	[StringLength(40)]
	public string Lineid { get; set; }

	[Column("PRINTCATEGORY")]
	[StringLength(40)]
	public string Printcategory { get; set; }
}
