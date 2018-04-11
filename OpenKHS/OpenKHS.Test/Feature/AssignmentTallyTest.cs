
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenKHS.Models;

namespace OpenKHS.Test.Feature
{
    [TestClass]
    public class AssignmentTallyTest : TestBase
    {
        [TestMethod]
        public void TestAssignmentTallyIncrementAndReset()
        {
            var assignmentTally = new AssignmentTally();
            Assert.AreEqual(assignmentTally, 0);
            assignmentTally++;
            Assert.AreEqual(assignmentTally, 1);

            Assert.IsTrue(assignmentTally == 1);

            Assert.AreEqual(assignmentTally, 1);
            Assert.AreEqual(1, assignmentTally);

            var another = assignmentTally;
            Assert.AreEqual(another, assignmentTally);
            Assert.IsTrue(assignmentTally == another);

            Assert.AreEqual(assignmentTally.ToString(), "1");
        }

        [TestMethod]
        public void TestAssignmentTallyCast()
        {
            var assignmentTally = new AssignmentTally();
            Assert.AreEqual(assignmentTally, 0);
            assignmentTally++;
            Assert.AreEqual(assignmentTally, 1);
            int i = (int)assignmentTally;
        }
    }
}
