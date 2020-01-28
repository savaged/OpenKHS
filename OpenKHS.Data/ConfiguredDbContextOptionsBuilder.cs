using Microsoft.EntityFrameworkCore;

namespace OpenKHS.Data
{
    public class ConfiguredDbContextOptionsBuilder
    {
        public ConfiguredDbContextOptionsBuilder()
        {
            var optionsBuilder = 
               new DbContextOptionsBuilder<OpenKHSContext>();
            optionsBuilder.UseSqlite("Data Source=OpenKHS.db;");    
            Options = optionsBuilder.Options;
        }

        public DbContextOptions<OpenKHSContext> Options { get; }
    }
}