using Microsoft.EntityFrameworkCore;

namespace OpenKHS.Data
{
    public class ConfiguredDbContextOptionsBuilder
    {
        public ConfiguredDbContextOptionsBuilder()
        {
            var optionsBuilder = 
               new DbContextOptionsBuilder<OpenKHSContext>();
            optionsBuilder.UseSqlite(
                StaticData.DbConnectionStrings.LIVE);    
            Options = optionsBuilder.Options;
        }

        public DbContextOptions<OpenKHSContext> Options { get; }
    }
}