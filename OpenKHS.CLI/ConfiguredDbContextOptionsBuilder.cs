using System;
using Microsoft.EntityFrameworkCore;
using OpenKHS.Data;

namespace OpenKHS.CLI
{
    public class ConfiguredDbContextOptionsBuilder
    {
        public ConfiguredDbContextOptionsBuilder(
            DbContextOptions<OpenKHSContext> dbContextOptions)
        {
            if (dbContextOptions == null)
            {
                throw new ArgumentNullException(nameof(dbContextOptions));
            }
            var optionsBuilder = new DbContextOptionsBuilder(
                dbContextOptions);
            optionsBuilder.UseSqlite("Data Source=OpenKHS.db;");
        }
    }
}