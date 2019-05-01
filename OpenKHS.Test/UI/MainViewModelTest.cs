using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenKHS.ViewModels;
using OpenKHS.ViewModels.Utils;

namespace OpenKHS.Test.Unit
{
    [TestClass]
    public class MainViewModelTest : DbContextTestBase
    {
        [TestMethod]
        public void TestLoadNewCong()
        {
            // TODO tests for each section/main model object
            var repositoryLookup = new RepositoryLookup(DbContext);
            var mvm = new MainViewModel(repositoryLookup);
            Assert.IsNotNull(mvm.CongregationVM);
            var cvm = (CongregationViewModel)mvm.CongregationVM;
            Assert.IsNotNull(cvm.Index);
            Assert.AreEqual(0, cvm.Index.Count);

            var pmsvm = (PmScheduleViewModel)mvm.PmScheduleVM;
            Assert.IsNotNull(pmsvm.ModelObject);
            Assert.IsTrue(pmsvm.ModelObject.IsNew);

            var clmmsvm = (ClmmScheduleViewModel)mvm.ClmmScheduleVM;
            Assert.IsNotNull(clmmsvm.ModelObject);
            Assert.IsTrue(clmmsvm.ModelObject.IsNew);
        }
        
    }
}
