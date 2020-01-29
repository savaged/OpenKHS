using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenKHS.ViewModels;

namespace OpenKHS.Test.Feature
{
    [TestClass]
    public class ListLocalCongregationAdminTests
    {
        private LocalCongregationAdminViewModel _localCongregationAdminViewModel;

        [TestInitialize]
        public void Init()
        {
            // IoC?
        }

        [TestMethod]
        public void ListLocalCongregationTest()
        {
            _localCongregationAdminViewModel.Load();
            Assert.AreEqual(10, _localCongregationAdminViewModel.IndexViewModel.Index.Count());
        }
    }
}