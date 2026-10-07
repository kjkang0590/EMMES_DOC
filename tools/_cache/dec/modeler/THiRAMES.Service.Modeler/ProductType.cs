using System.Runtime.InteropServices;

namespace THiRAMES.Service.Modeler;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct ProductType
{
	public const string ROH = "ROH";

	public const string HALB = "HALB";

	public const string FERT = "FERT";
}
