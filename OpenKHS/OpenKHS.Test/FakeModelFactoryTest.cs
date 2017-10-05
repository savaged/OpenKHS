using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using OpenKHS.Seeder;
using OpenKHS.Models;

namespace OpenKHS.Test
{
    [TestClass]
    public class FakeModelFactoryTest : TestBase
    {
        [TestMethod]
        public void TestFakePmScheduleMaker()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestFakeClmmScheduleMaker()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestFakeFriendMaker()
        {
            var friends = new FakeModelFactory().MakeFriends(80);
            Assert.AreEqual(80, friends.Count);
            Assert.AreNotEqual(friends.First(), friends.Last());
            var sisterFound = false;
            foreach(var friend in friends)
            {
                if (!friend.Male)
                {
                    sisterFound = true;
                    break;
                }
            }
            Assert.IsTrue(sisterFound);
        }

        [TestMethod]
        public void TestFakeCongregationMaker()
        {
            var congregations = new FakeModelFactory().MakeCongregations(3);
            Assert.AreEqual(3, congregations.Count);
            Assert.AreNotEqual(congregations.First(), congregations.Last());
        }

        [TestMethod]
        public void TestFakeVisitingSpeakerMaker()
        {
            var visitingSpeakers = new FakeModelFactory().MakeVisitingSpeakers(6);
            Assert.AreEqual(6, visitingSpeakers.Count);
            Assert.AreNotEqual(visitingSpeakers.First(), visitingSpeakers.Last());
        }

        [TestMethod]
        public void TestFakeCircuitOverseerMaker()
        {
            var co = new FakeModelFactory().MakeCircuitOverseer();
            Assert.IsTrue(co.Male);
            Assert.IsFalse(co.Wife.Male);
        }

        [TestMethod]
        public void TestFakePrivilegesMaker()
        {
            var privileges = new FakeModelFactory().MakePrivileges(false);
            Assert.IsNotNull(privileges);
            Assert.IsInstanceOfType(privileges, typeof(Privileges));
            Assert.IsFalse(privileges.WtReader);
        }

        [TestMethod]
        public void TestFakeCongregationMemberMaker()
        {
            var congMembers = new FakeModelFactory().MakeCongregationMember(80);
            Assert.AreEqual(80, congMembers.Count);
            Assert.IsNotNull(congMembers.First().Privileges);
        }
    }
}
