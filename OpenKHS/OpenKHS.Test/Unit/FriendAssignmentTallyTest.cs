
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            friend = Friend.Swap(ref friend, new Friend());
            Assert.AreEqual(1, friend.AssignmentTally);

            var replacement = new Friend();
            Assert.AreEqual(0, replacement.AssignmentTally);
            replacement = Friend.Swap(ref friend, replacement);
            Assert.AreEqual(1, replacement.AssignmentTally);
            Assert.AreEqual(0, friend.AssignmentTally);

            replacement = null;
            replacement = Friend.Swap(ref friend, replacement);
            Assert.AreEqual(0, friend.AssignmentTally);
        }
    }
}
