using System;
using Microsoft.EntityFrameworkCore;

namespace OpenKHS.Data
{
    public class ConfiguredDbContextOptionsBuilder
    {
        private readonly string _dbConn;
        protected DbContextOptionsBuilder<OpenKHSContext> OptionsBuilder
        { get; }

        public ConfiguredDbContextOptionsBuilder(string dbConn)
        {
            if (string.IsNullOrEmpty(dbConn))
            {
                throw new ArgumentNullException(nameof(dbConn));
            }
            _dbConn = dbConn;
            OptionsBuilder = 
               new DbContextOptionsBuilder<OpenKHSContext>();
            SetUseStatement();    
            Options = OptionsBuilder.Options;
        }

        public DbContextOptions<OpenKHSContext> Options { get; }

        protected virtual void SetUseStatement()
        {
            OptionsBuilder.UseSqlite(_dbConn);
        }
    }
}