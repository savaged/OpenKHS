using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenKHS.Seeder;
using OpenKHS.Utils.DataGateway;
using OpenKHS.Facades;

namespace OpenKHS.Test.Integration
{
    [TestClass]
    public class PersistModelTest : TestBase
    {
        [TestMethod]
        public void IntegrationTestCongregationCrudViaGateway()
        {
            var homeCong = FakeModelFactory.MakeFakeHomeCongregation();
            Assert.IsNotNull(homeCong.Name);
            Assert.IsTrue(homeCong.Name.Length > 0);
            Assert.IsNotNull(homeCong.Members);
            Assert.IsTrue(homeCong.Members.Count > 0);
            var json = homeCong.JsonEncode();
            Assert.IsNotNull(json);
            Assert.IsTrue(json.Length > 1000);
            var gateway = new DataGateway();
            var f = new CongregationFacade(gateway);
            // create
            var result = f.SaveCongregation(homeCong);
            Assert.IsTrue(result);
            // update
            var retrievedCong = f.GetCongregation();
            Assert.IsNotNull(retrievedCong);
            Assert.AreEqual(homeCong.Name, retrievedCong.Name);
            Assert.IsNotNull(retrievedCong.Members);
            Assert.AreEqual(homeCong.Members.Count, retrievedCong.Members.Count);
            // delete
            result = f.DeleteCongregation();
            Assert.IsTrue(result);
        }
    }
}
