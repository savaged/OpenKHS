using System;
using Microsoft.EntityFrameworkCore;

namespace OpenKHS.Data
{
    public abstract class ConfiguredDbContextOptionsBuilder 
        : IConfiguredDbContextOptionsBuilder
    {
        protected string DbSource { get; }
        protected DbContextOptionsBuilder<OpenKHSContext> OptionsBuilder { get; }

        public ConfiguredDbContextOptionsBuilder(string dbSource)
        {
            if (string.IsNullOrEmpty(dbSource))
            {
                throw new ArgumentNullException(nameof(dbSource));
            }
            DbSource = dbSource;
            OptionsBuilder = new DbContextOptionsBuilder<OpenKHSContext>();
            SetUseStatement();
            Options = OptionsBuilder.Options;
        }

        public DbContextOptions<OpenKHSContext> Options { get; }

        protected virtual void SetUseStatement()
        {
            OptionsBuilder.UseSqlite(DbSource);
        }
    }
}