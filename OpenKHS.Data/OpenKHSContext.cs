using Microsoft.EntityFrameworkCore;
using OpenKHS.Models;

namespace OpenKHS.Data
{
    public class OpenKHSContext : DbContext
    {
        public DbSet<LocalCongregationMember> LocalCongregationMembers { get; set; } 
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<UnavailablePeriod> UnavailablePeriods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO inject the connection string
            optionsBuilder.UseSqlite("Data Source=OpenKHS.db;");
        }
    }
}
