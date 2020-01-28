using System;
using Microsoft.EntityFrameworkCore;
using OpenKHS.Models;

namespace OpenKHS.Data
{
    public class OpenKHSContext : DbContext
    {
        public OpenKHSContext() { }

        public OpenKHSContext(DbContextOptions<OpenKHSContext> options)
            : base(options) { }

        public DbSet<LocalCongregationMember> LocalCongregationMembers { get; set; } 
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<UnavailablePeriod> UnavailablePeriods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
            throw new InvalidOperationException("Db context needs setting!");   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssignmentType>().ToTable("AssignmentTypes");
            modelBuilder.Entity<LocalCongregationMember>().ToTable("LocalCongregationMembers");
        }
    }
}
