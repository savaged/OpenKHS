using OpenKHS.Data;
using OpenKHS.Data.StaticData;

namespace OpenKHS.WPF
{
    public class DbContextOptionsBuilder : ConfiguredDbContextOptionsBuilder
    {
        public DbContextOptionsBuilder()
            : base(DbConnectionStrings.LIVE) 
        {
        }
    }
}