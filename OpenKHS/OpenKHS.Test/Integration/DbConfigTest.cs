using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenKHS.Data;
using OpenKHS.Models;

namespace OpenKHS.Test.Integration
{
    [TestClass]
    public class DbConfigTest : DbContextTestBase
    {
        [TestMethod]
        public void IntegrationTestDbConfig()
        {
            var friend = new Friend();
            Assert.AreEqual(0, friend.Id);
            DbContext.Friends.Add(friend);
            var efDefaultId = friend.Id;
            Assert.AreNotEqual(0, efDefaultId);
            DbContext.SaveChanges();
            Assert.AreEqual(efDefaultId, friend.Id);
        }
    }
}
