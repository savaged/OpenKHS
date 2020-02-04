using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;
using OpenKHS.Data;

namespace OpenKHS.Test
{
    public class TestDbContextOptionsBuilder : ConfiguredDbContextOptionsBuilder
    {
        public static readonly ILoggerFactory MyLoggerFactory =
           LoggerFactory.Create(builder => { builder.AddConsole(); });

        public TestDbContextOptionsBuilder(SqliteConnection connection)
            : base(connection)
        {
        }

        protected override void SetUseStatements()
        {
            OptionsBuilder.UseLoggerFactory(MyLoggerFactory);
            base.SetUseStatements();
        }

    }
}