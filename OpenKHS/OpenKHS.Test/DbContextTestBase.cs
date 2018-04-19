using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using OpenKHS.Data;
using SQLitePCL;

namespace OpenKHS.Test
{
    [TestClass]
    public class DbContextTestBase : TestBase
    {
        protected DbContextOptionsBuilder<DatabaseContext> OptionsBuilder;

        /// <summary>
        /// Starts a clock
        /// </summary>
        [TestInitialize]
        public override void Initialization()
        {
            OptionsBuilder = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase("DataSource=:memory:");
            Batteries.Init();
            using (var context = new DatabaseContext(OptionsBuilder.Options))
            {
                context.Database.EnsureCreated();
            }
            base.Initialization();
        }
    }
}
