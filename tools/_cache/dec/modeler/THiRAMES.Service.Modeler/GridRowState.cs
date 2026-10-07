using System.Runtime.InteropServices;

namespace THiRAMES.Service.Modeler;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct GridRowState
{
	public const string ADD = "A";

	public const string UPDATE = "U";

	public const string DEL = "D";

	public const string REALDEL = "RD";

	public const string COPY = "C";
}
