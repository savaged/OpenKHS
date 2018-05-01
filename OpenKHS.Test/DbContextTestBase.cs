using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using OpenKHS.Data;
using SQLitePCL;

namespace OpenKHS.Test
{
    [TestClass]
    public class DbContextTestBase : TestBase
    {
        protected DatabaseContext DbContext;

        /// <summary>
        /// Starts a clock
        /// </summary>
        [TestInitialize]
        public override void Initialization()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase("DataSource=:memory:");
            Batteries.Init();
            DbContext = new DatabaseContext(optionsBuilder.Options);

            DbContext.Database.EnsureCreated();
            
            base.Initialization();
        }
    }
}
