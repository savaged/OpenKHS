using Microsoft.EntityFrameworkCore;
using OpenKHS.Data;

namespace OpenKHS.Test
{
    public class TestDbContextOptionsBuilder : ConfiguredDbContextOptionsBuilder
    {
        public TestDbContextOptionsBuilder(string dbSource)
            : base(dbSource) 
        {
        }

        protected override void SetUseStatement()
        {
            OptionsBuilder.UseInMemoryDatabase(DbSource);
        }
    }
}