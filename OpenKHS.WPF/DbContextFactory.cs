using OpenKHS.Data;

namespace OpenKHS.WPF
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