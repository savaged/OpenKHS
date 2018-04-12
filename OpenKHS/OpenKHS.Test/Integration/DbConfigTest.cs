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
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<DatabaseContext>()
                        .UseSqlite(connection)
                        .Options;

                using (var context = new DatabaseContext(options))
                {
                    context.Database.EnsureCreated();
                }

                using (var context = new DatabaseContext())
                {
                    var friend = new Friend();
                    Assert.AreEqual(0, friend.Id);
                    context.Friends.Add(friend);
                    var efDefaultId = friend.Id;
                    Assert.IsTrue(efDefaultId < 0);
                    context.SaveChanges();
                    Assert.AreNotEqual(efDefaultId, friend.Id);
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
