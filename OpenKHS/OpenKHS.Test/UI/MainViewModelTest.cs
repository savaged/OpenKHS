using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenKHS.Interfaces;
using OpenKHS.Models;
using OpenKHS.ViewModels;

namespace OpenKHS.Test.Unit
{
    [TestClass]
    public class MainViewModelTest : TestBase
    {
        [TestMethod]
        public void TestLoadNewCong()
        {
            var cong = new Congregation();
            var mockResponse = cong.ToString();
            var mockGateway = new Mock<IDataGateway>();
            mockGateway.Setup(g => g.Request(typeof(Congregation), Methods.Get, null)).Returns(mockResponse);
            var mvm = new MainViewModel(mockGateway.Object, null);
            Assert.IsNotNull(mvm.CongregationVM);
            var cvm = (CongregationViewModel)mvm.CongregationVM;
            Assert.IsNotNull(cvm.Members);
            Assert.AreEqual(1, cvm.Members.Count);
            Assert.AreEqual(string.Empty, cvm.Members[0]);
        }
        
    }
}
