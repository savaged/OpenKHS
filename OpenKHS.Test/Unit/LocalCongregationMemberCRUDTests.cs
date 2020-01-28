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
            var optionsBuilder = new DbContextOptionsBuilder<OpenKHSContext>();
            optionsBuilder.UseInMemoryDatabase("Tests");
            _options = optionsBuilder.Options;
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