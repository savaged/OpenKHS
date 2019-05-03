using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenKHS.Models;

namespace OpenKHS.Test.Integration
{
    [TestClass]
    public class PmScheduleLoadFirstTimeTest : DbContextTestBase
    {
        [TestMethod]
        public void IntegrationTestDbConfig()
        {
            var friend = new LocalCongregationMember();
            Assert.AreEqual(0, friend.Id);
            DbContext.LocalCongregationMembers.Add(friend);
            var efDefaultId = friend.Id;
            Assert.AreNotEqual(0, efDefaultId);
            DbContext.SaveChanges();
            Assert.AreEqual(efDefaultId, friend.Id);
        }
    }
}
