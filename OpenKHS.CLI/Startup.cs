using OpenKHS.CLI.IoC;
using Ninject;
using OpenKHS.CLI.Modules;

namespace OpenKHS.CLI
{
    class Startup
    {
        private readonly IKernel _kernel;

        public Startup()
        {
            _kernel = new StandardKernel(
                new CoreBindings(),
                new DbContextBindings(),
                new ModuleBindings());
            Main = _kernel.Get<Main>();
        }

        public IModule Main { get; }
    }
}