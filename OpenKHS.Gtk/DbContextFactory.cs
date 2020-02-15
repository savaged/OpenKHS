using OpenKHS.Data;

namespace OpenKHS.Gtk
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
