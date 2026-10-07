using System.Reflection;
using CIM.MES.Framework;
using CIM.MES.Framework.Rule;
using DryIoc;

namespace THiRAMES.Service.Modeler;

public class ModelerModule : IModule
{
	public void Load(IContainer container)
	{
		container.Resolve<IQueryManager>().Load(Assembly.GetExecutingAssembly());
	}
}
