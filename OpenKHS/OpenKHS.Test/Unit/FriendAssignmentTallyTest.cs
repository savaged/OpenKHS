
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
            Friend friend = null;
            friend = Friend.Swap(ref friend, new Friend(), AssignmentContext.Common);
            Assert.AreEqual((uint)1, friend.MeetingAssignmentTally);

            var replacement = new Friend();
            Assert.AreEqual((uint)0, replacement.MeetingAssignmentTally);
            replacement = Friend.Swap(ref friend, replacement, AssignmentContext.Common);
            Assert.AreEqual((uint)1, replacement.MeetingAssignmentTally);
            Assert.AreEqual((uint)0, friend.MeetingAssignmentTally);

            replacement = null;
            replacement = Friend.Swap(ref friend, replacement, AssignmentContext.Common);
            Assert.AreEqual((uint)0, friend.MeetingAssignmentTally);
        }
    }
}
