using Ninject.Modules;
using OpenKHS.CLI.Modules;

namespace OpenKHS.CLI.IoC
{
    public class ModuleBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<Main>().ToSelf();
        }
    }
}