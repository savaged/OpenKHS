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
        public void IntegrationTestCongregationCrudViaGateway()
        {
            var homeCong = FakeModelFactory.MakeFakeCongregation();
            Assert.IsNotNull(homeCong.Members);
            Assert.IsTrue(homeCong.Members.Count > 0);
            var json = homeCong.JsonEncode();
            Assert.IsNotNull(json);
            Assert.IsTrue(json.Length > 1000);
            var gateway = new Gateway();
            var f = new DataGatewayFacade<Congregation>(gateway);
            // create
            var result = f.Store(homeCong);
            Assert.IsTrue(result);
            // update
            var retrievedCong = f.Show(1);
            Assert.IsNotNull(retrievedCong);
            Assert.IsNotNull(retrievedCong.Members);
            Assert.AreEqual(homeCong.Members.Count, retrievedCong.Members.Count);
            // delete
            result = f.Delete();
            Assert.IsTrue(result);
        }
    }
}
