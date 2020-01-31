using OpenKHS.Data;

namespace OpenKHS.CLI
{
    public class DbContextFactory : DbContextFactoryBase
    {
        public DbContextFactory(
            IConfiguredDbContextOptionsBuilder optionsBuilder) 
            : base(optionsBuilder)
        {
        }
    }
}