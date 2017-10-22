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
        public void TestFakeMeetingPartMaker()
        {
            var meetingPart = new FakeModelFactory().MakeMeetingPart();
            Assert.IsNotNull(meetingPart);
            Assert.IsNotNull(meetingPart.Title);
            Assert.IsNotNull(meetingPart.Friend);
        }

        [TestMethod]
        public void TestFakeSchoolMeetingPartMaker()
        {
            var schoolMeetingPart = new FakeModelFactory().MakeSchoolPart(true);
            Assert.IsNotNull(schoolMeetingPart);
            Assert.IsNotNull(schoolMeetingPart.Title);
            Assert.IsNotNull(schoolMeetingPart.Student);
            Assert.IsNotNull(schoolMeetingPart.CounselPoint);
            Assert.IsTrue(schoolMeetingPart.CounselPoint > 0 && schoolMeetingPart.CounselPoint < 195);
        }

        [TestMethod]
        public void TestFakeAssistedSchoolMeetingPartMaker()
        {
            var assistedMeetingPart = new FakeModelFactory().MakeAssistedSchoolPart(false);
            Assert.IsNotNull(assistedMeetingPart);
            Assert.IsNotNull(assistedMeetingPart.Student);
            Assert.IsNotNull(assistedMeetingPart.Assistant);
        }

        [TestMethod]
        public void TestFakePublicTalkMaker()
        {
            var publicTalk = new FakeModelFactory().MakePublicTalk();
            Assert.IsNotNull(publicTalk.TalkNumber);
            Assert.IsTrue(publicTalk.TalkNumber > 0);
            Assert.IsNotNull(publicTalk.Friend);
            Assert.IsNotNull(publicTalk.Friend.Name);
        }

        [TestMethod]
        public void TestFakeCongMemberWithPrivileges()
        {
            var privileges = new List<string> { "Attendant" };
            var congMemberWithPrivileges = new FakeModelFactory().MakeCongMemberWithPrivileges(privileges);
            Assert.IsInstanceOfType(congMemberWithPrivileges, typeof(Friend));
            Assert.IsTrue(congMemberWithPrivileges.Attendant);
        }

        [TestMethod]
        public void TestFakeCongMemberWithAssignmentsTally()
        {
            var privileges = new List<string> { "Attendant" };
            var congMember = new FakeModelFactory().MakeCongMemberWithAssignmentTally();
            Assert.IsNotNull(congMember.AssignmentTally);
            Assert.IsTrue(congMember.AssignmentTally < 6);
        }

        [TestMethod]
        public void TestFakeFriendMaker()
        {
            var friends = new FakeModelFactory().MakeFriends(40);
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
            var friend = factory.MakeFriends(1).First();
            var friendWithRandomPrivileges = factory.AddRandomPrivileges(friend, false);
            Assert.IsNotNull(friendWithRandomPrivileges);
            Assert.IsInstanceOfType(friendWithRandomPrivileges, typeof(Friend));
            Assert.IsTrue(friendWithRandomPrivileges.CountPrivileges() > 0);
            
            friendWithRandomPrivileges = factory.AddPrivileges(friend, new List<string>{"WtReader"});
            Assert.IsNotNull(friendWithRandomPrivileges);
            Assert.IsInstanceOfType(friendWithRandomPrivileges, typeof(Friend));
            Assert.IsTrue(friendWithRandomPrivileges.CountPrivileges() > 0);
        }

        [TestMethod]
        public void TestFakeCongregationMemberMaker()
        {
            var congMembers = new FakeModelFactory().MakeCongregationMembers(80);
            Assert.AreEqual(80, congMembers.Count);
            Assert.IsTrue(congMembers.First().CountPrivileges() > 0);
        }
        
    }
}
