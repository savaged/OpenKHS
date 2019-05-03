using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenKHS.Interfaces;
using OpenKHS.Models;

namespace OpenKHS.Test.Unit
{
    [TestClass]
    public class CongregationMemberAssignmentTallyTest
    {
        [TestMethod]
        public void TestCongregationMemberAssignmentTallyIncrementAndReset()
        {
            LocalCongregationMember friend = null;
            friend = LocalCongregationMember.Swap(ref friend, new LocalCongregationMember(), AssignmentContext.Common);
            Assert.AreEqual((uint)1, friend.MeetingAssignmentTally);

            var replacement = new LocalCongregationMember();
            Assert.AreEqual((uint)0, replacement.MeetingAssignmentTally);
            replacement = LocalCongregationMember.Swap(ref friend, replacement, AssignmentContext.Common);
            Assert.AreEqual((uint)1, replacement.MeetingAssignmentTally);
            Assert.AreEqual((uint)0, friend.MeetingAssignmentTally);

            replacement = null;
            replacement = LocalCongregationMember.Swap(ref friend, replacement, AssignmentContext.Common);
            Assert.AreEqual((uint)0, friend.MeetingAssignmentTally);
        }
    }
}
