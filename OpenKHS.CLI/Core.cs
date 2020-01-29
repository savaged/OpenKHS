using OpenKHS.CLI.IoC;
using Ninject;
using OpenKHS.CLI.Modules;

namespace OpenKHS.CLI
{
    class Core
    {
        private readonly IKernel _kernel;

        public Core()
        {
            _kernel = new StandardKernel(
                new CoreBindings(),
                new DbContextBindings(),
                new ModuleBindings());
        }

        public IModule MainModule => _kernel.Get<MainModule>();
    }
}