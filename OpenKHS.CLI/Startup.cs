using Microsoft.EntityFrameworkCore;
using OpenKHS.Data;

namespace OpenKHS.CLI
{
    class Startup
    {
        public Startup()
        {
            DbContextOptions = new DbContextOptions<OpenKHSContext>();
            var optionsBuilder = new DbContextOptionsBuilder(DbContextOptions);
            optionsBuilder.UseSqlite("Data Source=OpenKHS.db;");
        }

        public DbContextOptions<OpenKHSContext> DbContextOptions { get; }
    }
}