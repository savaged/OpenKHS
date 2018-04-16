using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenKHS.Data;
using OpenKHS.Models;

namespace OpenKHS.Test.Integration
{
    [TestClass]
    public class DbConfigTest : TestBase
    {
        [TestMethod]
        public void IntegrationTestDbConfig()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase("DataSource=:memory:");

            SQLitePCL.Batteries.Init();

            using (var context = new DatabaseContext(optionsBuilder.Options))
            {
                context.Database.EnsureCreated();
            
                var friend = new Friend();
                Assert.AreEqual(0, friend.Id);
                context.Friends.Add(friend);
                var efDefaultId = friend.Id;
                Assert.AreNotEqual(0, efDefaultId);
                context.SaveChanges();
                Assert.AreEqual(efDefaultId, friend.Id);
            }
        }
    }
}
