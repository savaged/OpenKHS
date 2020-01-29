using Microsoft.EntityFrameworkCore;
using OpenKHS.Data;

namespace OpenKHS.Tests.Feature
{
    public class TestDbContextOptionsBuilder
        : ConfiguredDbContextOptionsBuilder
    {
        private readonly string _dbName;

        public TestDbContextOptionsBuilder(
            string dbConn, string dbName) 
            : base(dbConn)
        {
            _dbName = dbName ?? "test";
        }

        protected override void SetUseStatement()
        {
            OptionsBuilder.UseInMemoryDatabase(_dbName);
        }
    }
}