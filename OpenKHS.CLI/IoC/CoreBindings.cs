using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Ninject.Modules;
using OpenKHS.Data;

namespace OpenKHS.CLI.IoC
{
    public class CoreBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IDbContextOptions>()
                .To<DbContextOptions<OpenKHSContext>>()
                .InSingletonScope();
            Bind<ConfiguredDbContextOptionsBuilder>().ToSelf();
        }
    }
}