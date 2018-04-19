using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenKHS.Seeder;
using OpenKHS.Data;
using OpenKHS.Facades;
using OpenKHS.Models;

namespace OpenKHS.Test.Integration
{
    [TestClass]
    public class PersistModelTest : TestBase
    {
        [TestMethod]
        public void IntegrationTestCongregationCrudViaJsonGateway()
        {
            var homeCong = FakeModelFactory.MakeFakeCongregation();
            Assert.IsNotNull(homeCong.Members);
            Assert.IsTrue(homeCong.Members.Count > 0);
            var json = homeCong.JsonEncode();
            Assert.IsNotNull(json);
            Assert.IsTrue(json.Length > 1000);
            var gateway = new JsonFileGateway();
            var f = new JsonDataGatewayFacade<Congregation>(gateway);
            // create
            var result = f.Store(homeCong);
            Assert.IsTrue(result);
            // update
            var retrievedCong = f.Show();
            Assert.IsNotNull(retrievedCong);
            Assert.IsNotNull(retrievedCong.Members);
            Assert.AreEqual(homeCong.Members.Count, retrievedCong.Members.Count);
            // delete
            result = f.Delete();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IntegrationTestCongregationCrudEntityFramework()
        {
            var homeCong = FakeModelFactory.MakeFakeCongregation();
            Assert.IsNotNull(homeCong.Members);
            Assert.IsTrue(homeCong.Members.Count > 0);
            var json = homeCong.JsonEncode();
            Assert.IsNotNull(json);
            Assert.IsTrue(json.Length > 1000);

            using (var context = new DatabaseContext(OptionsBuilder.Options))
            {
                foreach (var friend in homeCong.Members)
                {
                    // create
                    context.Add(friend);
                }
                context.SaveChanges();
            }

            using (var context = new DatabaseContext(OptionsBuilder.Options))
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
            using (var context = new DatabaseContext(OptionsBuilder.Options))
            {
                var first = context.Friends.First();
                id = first.Id;
                name = first.Name;
                // update
                first.Name = "I Altered";
                context.SaveChanges();
            }
            using (var context = new DatabaseContext(OptionsBuilder.Options))
            {
                // check updated
                var updated = context.Friends.Single(f => f.Id == id);
                Assert.AreNotEqual(name, updated.Name);
            }

            using (var context = new DatabaseContext(OptionsBuilder.Options))
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
