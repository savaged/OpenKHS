using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using OpenKHS.Data;

namespace OpenKHS.Test
{
    public class TestDbContextOptionsBuilder : ConfiguredDbContextOptionsBuilder
    {
        public TestDbContextOptionsBuilder(SqliteConnection connection)
            : base(connection)
        {
        }

    }
}