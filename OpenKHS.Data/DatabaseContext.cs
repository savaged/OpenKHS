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

        public DbSet<LocalCongregationMember> LocalCongregationMembers { get; set; }
        public DbSet<DateRange> UnavailablePeriods { get; set; }
        public DbSet<PmSchedule> PmSchedules { get; set; }
        public DbSet<ClmmSchedule> ClmmSchedules { get; set; }
        public DbSet<PublicTalk> PublicTalks { get; set; }
        public DbSet<VisitingSpeaker> VisitingSpeakers { get; set; }
        public DbSet<NeighbouringCongregation> NeighbouringCongregations { get; set; }

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

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<LocalCongregationMember>().HasIndex(f => f.Name).IsUnique();

            mb.Entity<PmSchedule>()
                .HasBaseType<Meeting>()
                .HasIndex(s => s.WeekStarting).IsUnique();

            mb.Entity<ClmmSchedule>()
                .HasBaseType<Meeting>()
                .HasIndex(s => s.WeekStarting).IsUnique();

            // TODO this looks like it needs rework or even removal and models to have relation IDs instead

            mb.Entity<LocalCongregationMember>().OwnsMany(m => m.UnavailablePeriods);

            mb.Entity<ClmmSchedule>().OwnsOne(m => m.AYttMBibleStudy, 
                p => p.OwnsOne(l => l.Assistant, 
                a => a.OwnsMany(m => m.UnavailablePeriods)));
            mb.Entity<ClmmSchedule>().OwnsOne(m => m.AYttMPart1,
                p => p.OwnsOne(l => l.Assistant,
                a => a.OwnsMany(m => m.UnavailablePeriods)));
            mb.Entity<ClmmSchedule>().OwnsOne(m => m.AYttMPart2,
                p => p.OwnsOne(l => l.Assistant,
                a => a.OwnsMany(m => m.UnavailablePeriods)));

            mb.Entity<ClmmSchedule>().OwnsOne(s => s.Attendant);
            mb.Entity<ClmmSchedule>().OwnsOne(s => s.Chairman);
            mb.Entity<ClmmSchedule>().OwnsOne(s => s.OpeningPrayer);
            mb.Entity<ClmmSchedule>().OwnsOne(s => s.Platform);
            mb.Entity<ClmmSchedule>().OwnsOne(s => s.SoundDesk);
            mb.Entity<ClmmSchedule>().OwnsOne(s => s.Security);
            mb.Entity<ClmmSchedule>().OwnsOne(s => s.RovingMic1);
            mb.Entity<ClmmSchedule>().OwnsOne(s => s.RovingMic2);
            mb.Entity<ClmmSchedule>().OwnsOne(s => s.BibleReading);
            mb.Entity<ClmmSchedule>().OwnsOne(s => s.CbsConductor);
            mb.Entity<ClmmSchedule>().OwnsOne(s => s.CbsReader);
            mb.Entity<ClmmSchedule>().OwnsOne(s => s.ClosingPrayer);
            mb.Entity<ClmmSchedule>().OwnsOne(s => s.Gems);
            mb.Entity<ClmmSchedule>().OwnsOne(s => s.Treasures);

            mb.Entity<PmSchedule>().OwnsOne(s => s.Attendant);
            mb.Entity<PmSchedule>().OwnsOne(s => s.Chairman);
            mb.Entity<PmSchedule>().OwnsOne(s => s.OpeningPrayer);
            mb.Entity<PmSchedule>().OwnsOne(s => s.Platform);
            mb.Entity<PmSchedule>().OwnsOne(s => s.SoundDesk);
            mb.Entity<PmSchedule>().OwnsOne(s => s.Security);
            mb.Entity<PmSchedule>().OwnsOne(s => s.RovingMic1);
            mb.Entity<PmSchedule>().OwnsOne(s => s.RovingMic2);
            mb.Entity<PmSchedule>().OwnsOne(s => s.WtConductor);
            mb.Entity<PmSchedule>().OwnsOne(s => s.WtReader);


            // TODO seed public talk outlines
        }
    }
}
