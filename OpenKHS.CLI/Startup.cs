using OpenKHS.CLI.IoC;
using Ninject;

namespace OpenKHS.CLI
{
    class Startup
    {
        public Startup()
        {
            Kernel = new StandardKernel(new CoreBindings());
        }

        public IKernel Kernel { get; }
    }
}