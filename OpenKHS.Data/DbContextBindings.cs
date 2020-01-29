using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Ninject.Modules;

namespace OpenKHS.Data
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