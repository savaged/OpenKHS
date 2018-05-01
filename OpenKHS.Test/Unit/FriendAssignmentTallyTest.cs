
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenKHS.Interfaces;
using OpenKHS.Models;

namespace OpenKHS.Test.Unit
{
    [TestClass]
    public class CongregationMemberAssignmentTallyTest : TestBase
    {
        [TestMethod]
        public void TestCongregationMemberAssignmentTallyIncrementAndReset()
        {
            CongregationMember friend = null;
            friend = CongregationMember.Swap(ref friend, new CongregationMember(), AssignmentContext.Common);
            Assert.AreEqual((uint)1, friend.MeetingAssignmentTally);

            var replacement = new CongregationMember();
            Assert.AreEqual((uint)0, replacement.MeetingAssignmentTally);
            replacement = CongregationMember.Swap(ref friend, replacement, AssignmentContext.Common);
            Assert.AreEqual((uint)1, replacement.MeetingAssignmentTally);
            Assert.AreEqual((uint)0, friend.MeetingAssignmentTally);

            replacement = null;
            replacement = CongregationMember.Swap(ref friend, replacement, AssignmentContext.Common);
            Assert.AreEqual((uint)0, friend.MeetingAssignmentTally);
        }
    }
}
