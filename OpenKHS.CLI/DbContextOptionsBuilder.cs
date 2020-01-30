using OpenKHS.Data;
using OpenKHS.Data.StaticData;

namespace OpenKHS.CLI
{
    public class DbContextOptionsBuilder : ConfiguredDbContextOptionsBuilder
    {
        public DbContextOptionsBuilder()
            : base(DbConnectionStrings.LIVE) 
        {
        }
    }
}