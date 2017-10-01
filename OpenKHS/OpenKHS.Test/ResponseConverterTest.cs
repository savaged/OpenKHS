using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using OpenKHS.Utils.DataGateway;
using System.Linq;

namespace OpenKHS.Test
{
    [TestClass]
    public class ResponseConverterTest : TestBase
    {
        [TestMethod]
        public void TestConvert()
        {
            var rawResponseContent = "{ \"data\":[{ \"id\":1,\"version\":\"1.0\"}] }";
            var response = JsonConvert.DeserializeObject<ResponseRootObject>(rawResponseContent, new ResponseConverter());
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
            Assert.IsNotNull(response.Data[0]);
            Assert.IsNotNull(response.Data[0].Field);
            Assert.AreEqual("1.0", response.Data[0].Field["version"]);
            Assert.AreEqual("1.0", response.Data[0]["version"]);
            Assert.AreEqual("1.0", response.Data.First()["version"]);
        }
    }
}
