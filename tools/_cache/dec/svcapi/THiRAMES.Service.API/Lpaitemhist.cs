using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CST_LPAITEMHIST")]
public class Lpaitemhist : EntityTemplate
{
	public override string TableName => "CST_LPAITEMHIST";

	public override string GroupName => "CST_LPAITEMHIST";

	public override string TableType => "HIST";

	[Key]
	[Column("LASTEVENTSEQ")]
	public long Lasteventseq { get; set; }

	[Required]
	[Column("LPAITEMID")]
	[StringLength(40)]
	public string Lpaitemid { get; set; }

	[Required]
	[Column("LPAGROUP")]
	[StringLength(40)]
	public string Lpagroup { get; set; }

	[Required]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Column("LPAITEMNAME")]
	[StringLength(4000)]
	public string Lpaitemname { get; set; }

	[Column("LPATYPE")]
	[StringLength(40)]
	public string Lpatype { get; set; }

	[Column("PROCESSSEGMENTTYPE")]
	[StringLength(40)]
	public string Processsegmenttype { get; set; }

	[Column("LPADIVISION")]
	[StringLength(40)]
	public string Lpadivision { get; set; }

	[Column("INSPMANAGER")]
	[StringLength(40)]
	public string Inspmanager { get; set; }

	[Column("UISEQUENCE")]
	public int Uisequence { get; set; }
}
