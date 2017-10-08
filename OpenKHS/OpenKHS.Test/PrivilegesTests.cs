using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenKHS.Models;

namespace OpenKHS.Test
{
    [TestClass]
    public class PrivilegesTests : TestBase
    {
        [TestMethod]
        public void TestPrivilegesCount()
        {
            var priviliges = new Privileges
            {
                Attendant = true,
                WtReader = true
            };
            Assert.AreEqual(2, priviliges.Count());
        }
    }
}
