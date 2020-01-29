using Microsoft.EntityFrameworkCore;
using OpenKHS.Models;

namespace OpenKHS.Data
{
    public class OpenKHSContext : DbContext
    {
        public OpenKHSContext() { }

        public OpenKHSContext(DbContextOptions<OpenKHSContext> options)
            : base(options) { }

        public DbSet<AssignmentType> AssignmentTypes { get; set; }
        public DbSet<LocalCongregationMember> LocalCongregationMembers { get; set; } 
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<UnavailablePeriod> UnavailablePeriods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(
                    StaticData.DbConnectionStrings.LIVE);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LocalCongregationMember>().ToTable("LocalCongregationMembers");
            
            modelBuilder.Entity<AssignmentType>().ToTable("AssignmentTypes");
        }

    }
}
