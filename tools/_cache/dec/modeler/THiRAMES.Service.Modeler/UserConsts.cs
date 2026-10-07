using System.Runtime.InteropServices;

namespace THiRAMES.Service.Modeler;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct UserConsts
{
	public const string _ROW_STATE = "_ROW_STATE";

	public const string _ROW_INDEX = "_ROW_INDEX";

	public const string SITEID = "SITEID";

	public const string FROMTIME = "FROMTIME";

	public const string TOTIME = "TOTIME";

	public const string OLDCODE = "OLDCODE";

	public const string NEWCODE = "NEWCODE";

	public const string NEWNAME = "NEWNAME";
}
