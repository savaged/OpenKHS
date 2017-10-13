using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenKHS.Seeder;

namespace OpenKHS.Test
{
    [TestClass]
    public class PersistModelTest : TestBase
    {
        [TestMethod]
        public void TestCongregationCrudViaGateway()
        {
            var homeCong = FakeModelFactory.MakeFakeHomeCongregation();
            Assert.IsNotNull(homeCong.Name);
            Assert.IsTrue(homeCong.Name.Length > 0);
            Assert.IsNotNull(homeCong.Members);
            Assert.IsTrue(homeCong.Members.Count > 0);
            var json = homeCong.JsonEncode();
            Assert.IsNotNull(json);
            Assert.IsTrue(json.Length > 1000);
            var file = new FileInfo("test-cong.json");
            // TODO vm uses gateway to persist to file
            Assert.Fail("todo");
        }
    }
}
