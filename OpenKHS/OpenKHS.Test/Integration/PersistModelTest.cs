using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenKHS.Seeder;
using OpenKHS.Data;
using OpenKHS.Models;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace OpenKHS.Test.Integration
{
    [TestClass]
    public class PersistModelTest : TestBase
    {
        [TestMethod]
        public void IntegrationTestCongregationCrudEntityFramework()
        {
            var homeCong = FakeModelFactory.MakeFakeCongregation();
            Assert.IsNotNull(homeCong.Members);
            Assert.IsTrue(homeCong.Members.Count > 0);
            var json = homeCong.JsonEncode();
            Assert.IsNotNull(json);
            Assert.IsTrue(json.Length > 1000);

            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase("DataSource=:memory:");
            Batteries.Init();

            using (var context = new DatabaseContext(optionsBuilder.Options))
            {
                context.Database.EnsureDeleted();
            }
            using (var context = new DatabaseContext(optionsBuilder.Options))
            {
                context.Database.EnsureCreated();
            }

            using (var context = new DatabaseContext(optionsBuilder.Options))
            {
                foreach (var friend in homeCong.Members)
                {
                    // create
                    context.Add(friend);
                }
                context.SaveChanges();
            }

            using (var context = new DatabaseContext(optionsBuilder.Options))
            {
                // read
                var retrievedCong = new Congregation
                {
                    Members = context.Friends.ToList()
                };
                Assert.IsNotNull(retrievedCong);
                Assert.IsNotNull(retrievedCong.Members);
                Assert.AreEqual(homeCong.Members.Count, retrievedCong.Members.Count);
            }

            string name;
            int id;
            using (var context = new DatabaseContext(optionsBuilder.Options))
            {
                var first = context.Friends.First();
                id = first.Id;
                name = first.Name;
                // update
                first.Name = "I Altered";
                context.SaveChanges();
            }
            using (var context = new DatabaseContext(optionsBuilder.Options))
            {
                // check updated
                var updated = context.Friends.Single(f => f.Id == id);
                Assert.AreNotEqual(name, updated.Name);
            }
            int tally;
            using (var context = new DatabaseContext(optionsBuilder.Options))
            {
                var first = context.Friends.First();
                id = first.Id;
                tally = first.MeetingAssignmentTally;
                // update
                first.MeetingAssignmentTally++;
                context.SaveChanges();
            }
            using (var context = new DatabaseContext(optionsBuilder.Options))
            {
                // check updated
                var updated = context.Friends.Single(f => f.Id == id);
                Assert.AreNotEqual(tally, updated.MeetingAssignmentTally);
            }

            using (var context = new DatabaseContext(optionsBuilder.Options))
            {
                foreach (var friend in context.Friends)
                {
                    // delete
                    context.Remove(friend);
                    context.SaveChanges();
                }
                Assert.AreEqual(0, context.Friends.ToList().Count);
            }

            // TODO get Tally working (currently ingnored by context
        }
    }
}
