using System;
using Microsoft.EntityFrameworkCore;
using OpenKHS.Models;

namespace OpenKHS.Data.DatabaseContext
{
    public class FriendContext : DbContext
    {
        public DbSet<Friend> Friends { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO move the hard-coded connection to app.config
            optionsBuilder.UseSqlServer(
                "Server = (localdb)\\mssqllocaldb; Database = OpenKHS; Trusted_Connection = True;");
        }
    }
}
