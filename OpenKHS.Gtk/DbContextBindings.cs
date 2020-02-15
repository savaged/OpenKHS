using OpenKHS.Data;
using OpenKHS.Data.StaticData;

namespace OpenKHS.Gtk
{
    public class DbContextBindings : DbContextBindingsBase 
    {
        private readonly string dbSource;

        public DbContextBindings(string dbConn)
        {
            dbSource = dbConn ?? DbConnectionStrings.LIVE;
        }

        public override void Load()
        {
            Bind<IConfiguredDbContextOptionsBuilder>().To<DbContextOptionsBuilder>()
                .InSingletonScope()
                .WithConstructorArgument(dbSource);
            Bind<IDbContextFactory>().To<DbContextFactory>();
            base.Load();
        }
    }
} 
