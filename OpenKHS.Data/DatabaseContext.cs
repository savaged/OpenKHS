using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using OpenKHS.Models;

namespace OpenKHS.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        { }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }

        public DbSet<Friend> Friends { get; set; }
        public DbSet<PmSchedule> PmSchedules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var databaseFilePath = "OpenKHS.db";
                databaseFilePath = ApplicationData.ResourceLocation + databaseFilePath;
                optionsBuilder.UseSqlite($"Data source={databaseFilePath}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<AssignmentTally>();
        }
    }
}
