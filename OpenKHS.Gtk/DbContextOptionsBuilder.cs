using OpenKHS.Data;
using OpenKHS.Data.StaticData;

namespace OpenKHS.Gtk
{
    public class DbContextOptionsBuilder : ConfiguredDbContextOptionsBuilder
    {
        public DbContextOptionsBuilder()
            : base(DbConnectionStrings.LIVE) 
        {
        }
    }
}
