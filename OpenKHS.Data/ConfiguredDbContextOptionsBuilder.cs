using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace OpenKHS.Data
{
    public abstract class ConfiguredDbContextOptionsBuilder 
        : IConfiguredDbContextOptionsBuilder
    {
        public ConfiguredDbContextOptionsBuilder(string dbConnectionString)
        {
            if (string.IsNullOrEmpty(dbConnectionString))
            {
                throw new ArgumentNullException(nameof(dbConnectionString));
            }
            Connection = new SqliteConnection(dbConnectionString);
            Init();
        }

        public ConfiguredDbContextOptionsBuilder(SqliteConnection connection)
        {
            Connection = connection ??
                throw new ArgumentNullException(nameof(connection));
            Init();
        }

        public SqliteConnection Connection { get; }

        public DbContextOptions<OpenKHSContext> Options { get; private set; }
        
        protected DbContextOptionsBuilder<OpenKHSContext> OptionsBuilder 
        { get; private set; }

        protected virtual void SetUseStatements()
        {
            OptionsBuilder.UseSqlite(Connection);
        }

        private void Init()
        {
            OptionsBuilder = new DbContextOptionsBuilder<OpenKHSContext>();
            SetUseStatements();
            Options = OptionsBuilder.Options;
        }
    }
}