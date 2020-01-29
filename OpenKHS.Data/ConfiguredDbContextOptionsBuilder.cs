using System;
using Microsoft.EntityFrameworkCore;

namespace OpenKHS.Data
{
    public class ConfiguredDbContextOptionsBuilder
    {
        public ConfiguredDbContextOptionsBuilder(string dbConn)
        {
            if (string.IsNullOrEmpty(dbConn))
            {
                throw new ArgumentNullException(nameof(dbConn));
            }
            var optionsBuilder = 
               new DbContextOptionsBuilder<OpenKHSContext>();
            optionsBuilder.UseSqlite(dbConn);    
            Options = optionsBuilder.Options;
        }

        public DbContextOptions<OpenKHSContext> Options { get; }
    }
}