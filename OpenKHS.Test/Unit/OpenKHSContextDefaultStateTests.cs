using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenKHS.Data.StaticData;

namespace OpenKHS.Test.Unit
{
    [TestClass]
    public class OpenKHSContextDefaultStateTests 
    {
        [TestMethod]
        public void GetAssignmentTypesTest()
        {
            var index = DbSeedData.GetAssignmentTypes();
            Assert.IsNotNull(index);
            Assert.AreEqual(25, index.Count());
        }
    }
}
