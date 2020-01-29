using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenKHS.Data.StaticData;

namespace OpenKHS.Test.Unit
{
    [TestClass]
    public class OpenKHSContextTests 
    {
        [TestMethod]
        public void GetAssignmentTypesTest()
        {
            var index = DbSeedData.GetAssignmentTypes();
            Assert.IsNotNull(index);
            Assert.AreEqual(27, index.Count());
        }
    }
}