using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using OpenKHS.Seeder;
using OpenKHS.Models;

namespace OpenKHS.Test
{
    [TestClass]
    public class FakeModelFactoryTest : TestBase
    {
        [TestMethod]
        public void TestFakeHomeCongregationMaker()
        {
            var homeCong = FakeModelFactory.MakeFakeHomeCongregation();
            Assert.IsNotNull(homeCong.Name);
            Assert.IsTrue(homeCong.Name.Length > 0);
            Assert.IsNotNull(homeCong.Members);
            Assert.IsTrue(homeCong.Members.Count > 0);
        }

        [TestMethod]
        public void TestFakePmScheduleMaker()
        {
            var pmSchedule = FakeModelFactory.MakeFakePmSchedule();
            Assert.IsNotNull(pmSchedule);
            Assert.IsNotNull(pmSchedule.Attendant);
            Assert.IsNotNull(pmSchedule.Chairman);
            Assert.IsNotNull(pmSchedule.Platform);
            Assert.IsNotNull(pmSchedule.PublicTalk);
            Assert.IsNotNull(pmSchedule.RovingMic1);
            Assert.IsNotNull(pmSchedule.RovingMic2);
            Assert.IsNotNull(pmSchedule.Security);
            Assert.IsNotNull(pmSchedule.SoundDesk);
            Assert.IsNotNull(pmSchedule.WtConductor);
            Assert.IsNotNull(pmSchedule.WtReader);

            Assert.IsNotNull(pmSchedule.Week);
            Assert.IsTrue(pmSchedule.Week > 0);
            Assert.IsTrue(pmSchedule.Week < 53);
        }

        [TestMethod]
        public void TestFakeClmmScheduleMaker()
        {
            var clmmSchedule = FakeModelFactory.MakeFakeClmmSchedule();
            Assert.IsNotNull(clmmSchedule);
            Assert.IsNotNull(clmmSchedule.Attendant);
            Assert.IsNull(clmmSchedule.SchoolTalk);
            Assert.IsNotNull(clmmSchedule.BibleReading);
            Assert.IsNotNull(clmmSchedule.BibleStudy);
            Assert.IsNotNull(clmmSchedule.CbsConductor);
            Assert.IsNotNull(clmmSchedule.CbsReader);
            Assert.IsNotNull(clmmSchedule.Chairman);
            Assert.IsNotNull(clmmSchedule.ClosingPrayer);
            Assert.IsNotNull(clmmSchedule.Gems);
            Assert.IsNotNull(clmmSchedule.InitialCall);
            Assert.IsNotNull(clmmSchedule.LacPart1);
            Assert.IsNotNull(clmmSchedule.LacPart2);
            Assert.IsNull(clmmSchedule.LacPart3);
            Assert.IsNotNull(clmmSchedule.OpeningPrayer);
            Assert.IsNotNull(clmmSchedule.Platform);
            Assert.IsNull(clmmSchedule.PresentationsForMonth);
            Assert.IsNotNull(clmmSchedule.ReturnVisit);
            Assert.IsNotNull(clmmSchedule.RovingMic1);
            Assert.IsNotNull(clmmSchedule.RovingMic2);
            Assert.IsNotNull(clmmSchedule.Security);
            Assert.IsNotNull(clmmSchedule.SoundDesk);
            Assert.IsNotNull(clmmSchedule.Treasures);

            Assert.IsNotNull(clmmSchedule.Week);
            Assert.IsTrue(clmmSchedule.Week > 0);
            Assert.IsTrue(clmmSchedule.Week < 53);
        }

        [TestMethod]
        public void TestFakeCircutVisitClmmScheduleMaker()
        {
            var coClmmSchedule = new FakeModelFactory().MakeCircuitVisitClmmSchedule();
            Assert.IsNotNull(coClmmSchedule);

            Assert.IsNotNull(coClmmSchedule.CircuitVisitOpeningTalk);
            Assert.IsNotNull(coClmmSchedule.CircuitVisitOpeningTalk.CircuitOverseer);

            Assert.IsNotNull(coClmmSchedule.CircuitVisitClosingTalk);
            Assert.IsNotNull(coClmmSchedule.CircuitVisitClosingTalk.CircuitOverseer);

            Assert.IsNotNull(coClmmSchedule.Week);
            Assert.IsTrue(coClmmSchedule.Week > 0);
            Assert.IsTrue(coClmmSchedule.Week < 53);
        }

        [TestMethod]
        public void TestFakeCircutVisitPmScheduleMaker()
        {
            var coPmSchedule = new FakeModelFactory().MakeCircuitVisitPmSchedule();
            Assert.IsNotNull(coPmSchedule);
            Assert.IsNotNull(coPmSchedule.PublicTalk);
            Assert.IsNotNull(coPmSchedule.PublicTalk.Friend);
            Assert.IsNotNull(coPmSchedule.ClosingTalk);
            Assert.IsNotNull(coPmSchedule.ClosingTalk.CircuitOverseer);
            Assert.AreEqual(coPmSchedule.PublicTalk.Friend.Lastname, coPmSchedule.ClosingTalk.CircuitOverseer.Lastname);
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
            Assert.IsNotNull(publicTalk.Friend.Firstname);
            Assert.IsNotNull(publicTalk.Friend.Lastname);
        }

        [TestMethod]
        public void TestFakeCongMemberWithPrivileges()
        {
            var privileges = new Privileges { Attendant = true };
            var congMemberWithPrivileges = new FakeModelFactory().MakeCongMemberWithPrivileges(true, privileges);
            Assert.IsInstanceOfType(congMemberWithPrivileges, typeof(Friend));
            Assert.IsNotNull(congMemberWithPrivileges.Privileges);
            Assert.IsTrue(congMemberWithPrivileges.Privileges.Attendant);
        }

        [TestMethod]
        public void TestFakeFriendMaker()
        {
            var friends = new FakeModelFactory().MakeFriends(40);
            Assert.AreEqual(40, friends.Count);
            Assert.AreNotEqual(friends.First().Lastname, friends.Last().Lastname);
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
            Assert.IsInstanceOfType(co, typeof(Friend));
            Assert.IsInstanceOfType(co.Wife, typeof(Friend));
        }

        [TestMethod]
        public void TestFakePrivilegesMaker()
        {
            var privileges = new FakeModelFactory().MakeRandomPrivileges(false);
            Assert.IsNotNull(privileges);
            Assert.IsInstanceOfType(privileges, typeof(Privileges));
            Assert.IsTrue(privileges.Count() > 0);
            
            privileges = new FakeModelFactory().MakeRandomPrivileges(true);
            Assert.IsNotNull(privileges);
            Assert.IsInstanceOfType(privileges, typeof(Privileges));
            Assert.IsTrue(privileges.Count() > 0);
        }

        [TestMethod]
        public void TestFakeCongregationMemberMaker()
        {
            var congMembers = new FakeModelFactory().MakeCongregationMembers(80);
            Assert.AreEqual(80, congMembers.Count);
            Assert.IsNotNull(congMembers.First().Privileges);
            Assert.IsTrue(congMembers.First().Privileges.Count() > 0);
        }

    }
}
