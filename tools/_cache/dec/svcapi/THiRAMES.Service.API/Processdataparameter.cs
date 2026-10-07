using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CIM.MES.Entity;

namespace THiRAMES.Service.API;

[Table("CST_PROCESSDATAPARAMETER")]
public class Processdataparameter : EntityTemplate
{
	public override string TableName => "CST_PROCESSDATAPARAMETER";

	public override string GroupName => "CST_PROCESSDATAPARAMETER";

	public override string TableType => "MAIN";

	[Key]
	[Column("PROCESSDATAPARAMETERID")]
	[StringLength(100)]
	public string Processdataparameterid { get; set; }

	[Key]
	[Column("PROCESSDATADEFINITIONID")]
	[StringLength(100)]
	public string Processdatadefinitionid { get; set; }

	[Key]
	[Column("DATAMAPPINGTABLE")]
	[StringLength(100)]
	public string Datamappingtable { get; set; }

	[Key]
	[Column("SITEID")]
	[StringLength(40)]
	public string Siteid { get; set; }

	[Column("PROCESSDATAPARAMETERNAME")]
	[StringLength(100)]
	public string Processdataparametername { get; set; }

	[Required]
	[Column("DATAMAPPINGCOLUMN")]
	[StringLength(100)]
	public string Datamappingcolumn { get; set; }

	[Column("PROCESSDATACLASSID")]
	[StringLength(40)]
	public string Processdataclassid { get; set; }

	[Column("TARGET")]
	[StringLength(40)]
	public string Target { get; set; }

	[Column("LOWERLIMIT")]
	[StringLength(40)]
	public string Lowerlimit { get; set; }

	[Column("UPPERLIMIT")]
	[StringLength(40)]
	public string Upperlimit { get; set; }

	[Column("UNITID")]
	[StringLength(40)]
	public string Unitid { get; set; }

	[Column("UISEQUENCE")]
	public int Uisequence { get; set; }
}
