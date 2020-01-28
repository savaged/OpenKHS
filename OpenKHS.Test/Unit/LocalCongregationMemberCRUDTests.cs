using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenKHS.Data;
using OpenKHS.Models;

namespace OpenKHS.Test.Unit
{
    [TestClass]
    public class LocalCongregationMemberCRUDTests
    {
        private DbContextOptions<OpenKHSContext> _options;

        [TestInitialize]
        public void Init()
        {
            _options = new DbContextOptions<OpenKHSContext>();
            var optionsBuilder = new DbContextOptionsBuilder(_options);
            optionsBuilder.UseInMemoryDatabase("OpenKHS");
        }

        [TestMethod]
        public void CreateLocalCongregationMember()
        {
            using (var context = new OpenKHSContext(_options))
            {
                context.Database.EnsureCreated();
                var lcm = new LocalCongregationMember();
                context.Add(lcm);
                context.SaveChanges();
                Assert.AreNotEqual(0, lcm.Id);
            }
        }
    }
}