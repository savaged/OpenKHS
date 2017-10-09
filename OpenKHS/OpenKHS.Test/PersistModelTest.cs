using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenKHS.Seeder;

namespace OpenKHS.Test
{
    [TestClass]
    public class PersistModelTest : TestBase
    {
        [TestMethod]
        public void TestCongregationDataDump()
        {
            var homeCong = FakeModelFactory.MakeFakeHomeCongregation();
            Assert.IsNotNull(homeCong.Name);
            Assert.IsTrue(homeCong.Name.Length > 0);
            Assert.IsNotNull(homeCong.Members);
            Assert.IsTrue(homeCong.Members.Count > 0);
            var json = homeCong.JsonEncode();
            Assert.IsNotNull(json);
            Assert.IsTrue(json.Length > 1000);
            var file = new FileInfo("test-cong.json");
            // TODO vm uses gateway to persist to file
            Assert.Fail("todo");
        }

        [TestMethod]
        public void TestClmmScheduleDump()
        {
            // TODO vm gets command to autofill calls model then facade to use gateway to persist
            Assert.Fail("todo");
        }

        [TestMethod]
        public void TestPmScheduleDump()
        {
            // TODO vm gets command to autofill calls model then facade to use gateway to persist
            Assert.Fail("todo");
        }

        [TestMethod]
        public void TestCoVisitClmmScheduleDump()
        {
            // TODO vm gets command to autofill calls model then facade to use gateway to persist
            Assert.Fail("todo");
        }

        [TestMethod]
        public void TestCoVisitPmScheduleDump()
        {
            // TODO vm gets command to autofill calls model then facade to use gateway to persist
            Assert.Fail("todo");
        }
    }
}
