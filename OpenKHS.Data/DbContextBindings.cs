using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Ninject.Modules;

namespace OpenKHS.Data
{
    public abstract class DbContextBindingsBase : NinjectModule
    {
        /// <summary>
        /// Sub-classes should have a Bind for their implementation 
        /// of the ConfiguredDbContextOptionsBuilder class and then
        /// call this base Load method.
        /// </summary>
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