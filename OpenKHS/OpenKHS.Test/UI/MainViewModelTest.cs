using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenKHS.Data;
using OpenKHS.Interfaces;
using OpenKHS.Models;
using OpenKHS.ViewModels;

namespace OpenKHS.Test.Unit
{
    [TestClass]
    public class MainViewModelTest : DbContextTestBase
    {
        [TestMethod]
        public void TestLoadNewCong()
        {
            // TODO tests for each section/main model object
            var mvm = new MainViewModel(null);
            Assert.IsNotNull(mvm.CongregationVM);
            var cvm = (CongregationViewModel)mvm.CongregationVM;
            Assert.IsNotNull(cvm.Index);
            Assert.AreEqual(1, cvm.Index.Count);
        }
        
    }
}
