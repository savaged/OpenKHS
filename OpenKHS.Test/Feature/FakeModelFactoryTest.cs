using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using OpenKHS.Seeder;
using OpenKHS.Models;
using System.Collections.Generic;
using System.Reflection;

namespace OpenKHS.Test.Feature
{
    [TestClass]
    public class FakeModelFactoryTest : TestBase
    {
        [TestMethod]
        public void TestFakeHomeCongregationMaker()
        {
            var homeCong = FakeModelFactory.MakeFakeCongregation();
            Assert.IsNotNull(homeCong.Members);
            Assert.IsTrue(homeCong.Members.Count > 0);
        }

        [TestMethod]
        public void TestFakePublicTalkMaker()
        {
            var publicTalk = new FakeModelFactory().MakePublicTalk();
            Assert.IsNotNull(publicTalk.Id);
            Assert.IsTrue(publicTalk.Id > 0);
            Assert.IsNotNull(publicTalk.Speaker);
            Assert.IsNotNull(publicTalk.Speaker.Name);
        }

        [TestMethod]
        public void TestFakeCongMemberWithPrivileges()
        {
            var privileges = new List<string> { "Attendant" };
            var congMemberWithPrivileges = new FakeModelFactory().MakeCongMemberWithPrivileges(privileges);
            Assert.IsInstanceOfType(congMemberWithPrivileges, typeof(LocalCongregationMember));
            Assert.IsTrue(congMemberWithPrivileges.Attendant);
        }

        [TestMethod]
        public void TestFakeCongMemberWithAssignmentsTally()
        {
            var privileges = new List<string> { "Attendant" };
            var congMember = new FakeModelFactory().MakeCongMemberWithAssignmentTally();
            Assert.IsTrue(congMember.MeetingAssignmentTally < 6);
        }

        [TestMethod]
        public void TestFakeCongMemberWithUnavailablePeriods()
        {
            var privileges = new List<string> { "Attendant" };
            var congMember = new FakeModelFactory().MakeCongMemberWithUnavailablePeriods();
            Assert.IsNotNull(congMember.UnavailablePeriods);
            Assert.IsTrue(congMember.UnavailablePeriods.Count == 1);
            Assert.IsNotNull(congMember.UnavailablePeriods[0]);
            Assert.IsNotNull(congMember.UnavailablePeriods[0].Start);
            Assert.IsNotNull(congMember.UnavailablePeriods[0].End);
        }

        [TestMethod]
        public void TestFakeSmallCongregationMemberMaker()
        {
            var friends = new FakeModelFactory().MakeCongregationMembers(40);
            Assert.AreEqual(40, friends.Count);
            Assert.AreNotEqual(friends.First().Name, friends.Last().Name);
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
            Assert.IsInstanceOfType(co.Name, typeof(string));
            Assert.IsInstanceOfType(co.Wife, typeof(string));
        }

        [TestMethod]
        public void TestFakePrivilegesMaker()
        {
            var factory = new FakeModelFactory();
            var friend = factory.MakeCongregationMembers(1).First();
            var friendWithRandomPrivileges = factory.AddRandomPrivileges(friend, false);
            Assert.IsNotNull(friendWithRandomPrivileges);
            Assert.IsInstanceOfType(friendWithRandomPrivileges, typeof(LocalCongregationMember));
            Assert.IsTrue(friendWithRandomPrivileges.CountPrivileges() > 0);
            
            friendWithRandomPrivileges = factory.AddPrivileges(friend, new List<string>{"WtReader"});
            Assert.IsNotNull(friendWithRandomPrivileges);
            Assert.IsInstanceOfType(friendWithRandomPrivileges, typeof(LocalCongregationMember));
            Assert.IsTrue(friendWithRandomPrivileges.CountPrivileges() > 0);
        }

        [TestMethod]
        public void TestFakeCongregationMemberMaker()
        {
            var congMembers = new FakeModelFactory().MakeCongregationMembersWithPrivildeges(80);
            Assert.AreEqual(80, congMembers.Count);
            Assert.IsTrue(congMembers.First().CountPrivileges() > 0);
        }
        
    }
}
