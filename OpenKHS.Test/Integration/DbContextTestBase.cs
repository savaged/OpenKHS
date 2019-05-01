using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenKHS.Data;

namespace OpenKHS.Test.Integration
{
    [TestClass]
    public class DbContextTestBase
    {
        protected DatabaseContext DbContext;

        /// <summary>
        /// Starts a clock
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            var databaseFilePath = "OpenKHS.Test.db";
            
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlite($"Data source={databaseFilePath}")
                .ConfigureWarnings(w => w.Throw(CoreEventId.IncludeIgnoredWarning));

            DbContext = new DatabaseContext(optionsBuilder.Options);

            DbContext.Database.EnsureCreated();
        }
    }
}
