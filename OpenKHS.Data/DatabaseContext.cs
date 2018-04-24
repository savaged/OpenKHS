using System;
using Microsoft.EntityFrameworkCore;
using OpenKHS.Models;
using SQLitePCL;

namespace OpenKHS.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        { }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }

        public DbSet<Friend> Friends { get; set; }
        public DbSet<DateRange> UnavailablePeriods { get; set; }
        public DbSet<PmSchedule> PmSchedules { get; set; }
        public DbSet<ClmmSchedule> ClmmSchedules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var databaseFilePath = "OpenKHS.db";
                databaseFilePath = ApplicationData.ResourceLocation + databaseFilePath;
                optionsBuilder.UseSqlite($"Data source={databaseFilePath}");
            }
            Batteries.Init();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore(typeof(AssignmentTally));
        }
    }
}
