using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using OpenKHS.Models;
using OpenKHS.Facades.Converters;
using OpenKHS.Seeder;

namespace OpenKHS.Test.Unit
{
    [TestClass]
    public class ResponseConverterTest : TestBase
    {
        [TestMethod]
        public void TestConvert()
        {
            var cong = FakeModelFactory.MakeFakeCongregation();
            var rawResponseContent = cong.ToString();
            var response = JsonConvert.DeserializeObject<Congregation>(rawResponseContent, new CongregationConverter());
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Members);
            Assert.AreEqual(cong.Members.Count, response.Members.Count);
            Assert.IsNotNull(cong.Members[0]);
            Assert.IsNotNull(cong.Members[0].UnavailablePeriods);
            Assert.AreEqual(0, cong.Members[0].UnavailablePeriods.Count);
        }
    }
}
