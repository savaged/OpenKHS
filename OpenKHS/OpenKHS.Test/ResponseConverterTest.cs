using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using OpenKHS.Models;
using OpenKHS.Facades.Converters;
using OpenKHS.Seeder;

namespace OpenKHS.Test
{
    [TestClass]
    public class ResponseConverterTest : TestBase
    {
        [TestMethod]
        public void TestConvert()
        {
            var cong = FakeModelFactory.MakeFakeHomeCongregation();
            var rawResponseContent = cong.ToString();
            var response = JsonConvert.DeserializeObject<Congregation>(rawResponseContent, new CongregationConverter());
            Assert.IsNotNull(response);
            Assert.AreEqual(cong.Name, response.Name);
            Assert.IsNotNull(response.Members);
            Assert.AreEqual(cong.Members.Count, response.Members.Count);
        }
    }
}
