using OpenKHS.Data;

namespace OpenKHS.Test
{
    public class TestDbContextBindings : DbContextBindingsBase 
    {
        private readonly string dbSource;
        
        public TestDbContextBindings(string dbName)
        {
            dbSource = dbName ?? "test";
        }

        public override void Load()
        {
            Bind<IConfiguredDbContextOptionsBuilder>().To<TestDbContextOptionsBuilder>()
                .InSingletonScope()
                .WithConstructorArgument(dbSource);
            Bind<IDbContextFactory>().To<TestDbContextFactory>()
                .InSingletonScope();
            base.Load();
        }
    }
}