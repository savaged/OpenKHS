using System;
using Microsoft.EntityFrameworkCore;
using OpenKHS.Models;

namespace OpenKHS.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Friend> Friends { get; set; }
        public DbSet<PmSchedule> PmSchedules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO move the hard-coded connection to app.config
            optionsBuilder.UseSqlServer(
                "Server = (localdb)\\mssqllocaldb; Database = OpenKHS; Trusted_Connection = True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<AssignmentTally>();
        }
    }
}
