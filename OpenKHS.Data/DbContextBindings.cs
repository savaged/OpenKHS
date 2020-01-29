using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Ninject.Modules;

namespace OpenKHS.Data
{
    public class DbContextBindings : NinjectModule
    {
        private readonly string _dbConn;

        public DbContextBindings()
            : this(StaticData.DbConnectionStrings.LIVE)
        {
        }

        public DbContextBindings(string dbConn) 
        {
            _dbConn = dbConn ??
                throw new ArgumentNullException(nameof(dbConn));
        }

        public override void Load()
        {
            Bind<ConfiguredDbContextOptionsBuilder>().ToSelf()
                .InSingletonScope()
                .WithConstructorArgument(_dbConn);
            Bind<IDbContextOptions>()
                .To<DbContextOptions<OpenKHSContext>>()
                .InSingletonScope();
            Bind<IDbContextFactory>().To<DbContextFactory>()
                .InSingletonScope();
        }
    }
}