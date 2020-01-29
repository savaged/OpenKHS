using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Ninject.Modules;
using OpenKHS.Data;

namespace OpenKHS.CLI.IoC
{
    public class DbContextBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IDbContextOptions>()
                .To<DbContextOptions<OpenKHSContext>>()
                .InSingletonScope();
            Bind<IDbContextFactory>().To<DbContextFactory>()
                .InSingletonScope();
        }
    }
}