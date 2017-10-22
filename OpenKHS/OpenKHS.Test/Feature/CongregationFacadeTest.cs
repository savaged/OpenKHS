using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenKHS.Seeder;
using Moq;
using OpenKHS.Interfaces;
using OpenKHS.Facades;
using OpenKHS.Models;
using Newtonsoft.Json;
using System.IO;

namespace OpenKHS.Test.Feature
{
    [TestClass]
    public class CongregationFacadeTest : TestBase
    {
        [TestMethod]
        public void TestCongregationWriteDataViaFacade()
        {
            var homeCong = FakeModelFactory.MakeFakeCongregation();
            Assert.IsNotNull(homeCong.Members);
            Assert.IsTrue(homeCong.Members.Count > 0);
            var mockResponse = JsonConvert.SerializeObject(true);
            var mockGateway = new Mock<IDataGateway>();
            mockGateway.Setup(g => g.Request(
                typeof(Congregation),
                Methods.Post,
                homeCong
                )).Returns(mockResponse);
            var f = new CongregationFacade(mockGateway.Object);
            var result = f.Store(homeCong);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestCongregationGetDataViaFacade()
        {
            var homeCong = FakeModelFactory.MakeFakeCongregation();
            Assert.IsNotNull(homeCong.Members);
            Assert.IsTrue(homeCong.Members.Count > 0);
            var json = homeCong.JsonEncode();
            Assert.IsNotNull(json);
            var mockResponse = json;
            var mockGateway = new Mock<IDataGateway>();
            mockGateway.Setup(g => g.Request(
                typeof(Congregation),
                Methods.Get,
                null
                )).Returns(mockResponse);
            var f = new CongregationFacade(mockGateway.Object);
            var retrievedCong = f.Show();
            Assert.IsNotNull(retrievedCong);
            Assert.IsNotNull(retrievedCong.Members);
            Assert.AreEqual(homeCong.Members.Count, retrievedCong.Members.Count);
        }

        [TestMethod]
        public void TestCongregationGetNewViaFacade()
        {
            var mockGateway = new Mock<IDataGateway>();
            mockGateway.Setup(g => g.Request(
                typeof(Congregation),
                Methods.Get,
                null
                )).Throws<FileNotFoundException>();
            var f = new CongregationFacade(mockGateway.Object);
            var retrievedCong = f.Show();
            Assert.IsNotNull(retrievedCong);
            Assert.IsNotNull(retrievedCong.Members);
            Assert.AreEqual(0, retrievedCong.Members.Count);
        }
    }
}
