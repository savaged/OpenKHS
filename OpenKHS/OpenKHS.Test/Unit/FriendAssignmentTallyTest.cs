
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenKHS.Interfaces;
using OpenKHS.Models;

namespace OpenKHS.Test.Unit
{
    [TestClass]
    public class FriendAssignmentTallyTest : TestBase
    {
        [TestMethod]
        public void TestFriendAssignmentTallyIncrementAndReset()
        {
            var meeting = new PmSchedule();
            Friend friend = null;
            friend = Friend.Swap(ref friend, new Friend(), meeting, AssignmentContext.Common);
            Assert.AreEqual((uint)1, friend.MeetingAssignmentTally);

            var replacement = new Friend();
            Assert.AreEqual((uint)0, replacement.MeetingAssignmentTally);
            replacement = Friend.Swap(ref friend, replacement, meeting, AssignmentContext.Common);
            Assert.AreEqual((uint)1, replacement.MeetingAssignmentTally);
            Assert.AreEqual((uint)0, friend.MeetingAssignmentTally);

            replacement = null;
            replacement = Friend.Swap(ref friend, replacement, meeting, AssignmentContext.Common);
            Assert.AreEqual((uint)0, friend.MeetingAssignmentTally);
        }
    }
}
