using System.Linq;
using Microsoft.EntityFrameworkCore;
using OpenKHS.Models;

namespace OpenKHS.Data
{
    public class OpenKHSContext : DbContext
    {
        public OpenKHSContext() { }

        public OpenKHSContext(
            DbContextOptions<OpenKHSContext> options)
            : base(options) { }

        public virtual void EnsureSeeded()
        {
            var assignmentTypes = AssignmentTypes;
            if (assignmentTypes.Count() == 0)
            {
                var defaults = StaticData.DbSeedData.GetAssignmentTypes();
                foreach (var assignmentType in defaults)
                {
                    AssignmentTypes.Add(assignmentType);
                }
                SaveChanges();
            }
        }

        public DbSet<AssignmentType> AssignmentTypes { get; set; }
        public DbSet<Assignee> Assignees { get; set; } 
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<ClmmSchedule> ClmmSchedules { get; set; }
        public DbSet<UnavailablePeriod> UnavailablePeriods { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(
                    StaticData.DbConnectionStrings.LIVE);
            }
        }

    }
}
