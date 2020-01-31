using System.Data;
using Microsoft.Data.Sqlite;
using OpenKHS.Data;

namespace OpenKHS.Test
{
    public class TestDbContextBindings : DbContextBindingsBase 
    {
        public override void Load()
        {
            const string connectionString = "DataSource=:memory:";
            Bind<SqliteConnection>().ToSelf()
                .InSingletonScope()
                .WithConstructorArgument(connectionString);
            Bind<IConfiguredDbContextOptionsBuilder>().To<TestDbContextOptionsBuilder>()
                .InSingletonScope();
            Bind<IDbContextFactory>().To<TestDbContextFactory>()
                .InSingletonScope();
            base.Load();
        }
    }
}