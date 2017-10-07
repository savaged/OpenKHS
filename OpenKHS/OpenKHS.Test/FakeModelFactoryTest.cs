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
        public void TestFakePmScheduleMaker()
        {
            var pmSchedule = new FakeModelFactory().MakePmSchedule();
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
        }

        [TestMethod]
        public void TestFakeClmmScheduleMaker()
        {
            var clmmSchedule = new FakeModelFactory().MakeClmmSchedule();
            Assert.IsNotNull(clmmSchedule);
            Assert.IsNotNull(clmmSchedule.Attendant);
            Assert.IsNotNull(clmmSchedule.AyfmTalk);
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
            Assert.IsNotNull(clmmSchedule.LacPart3);
            Assert.IsNotNull(clmmSchedule.OpeningPrayer);
            Assert.IsNotNull(clmmSchedule.Platform);
            Assert.IsNotNull(clmmSchedule.PresentationsForMonth);
            Assert.IsNotNull(clmmSchedule.ReturnVisit);
            Assert.IsNotNull(clmmSchedule.RovingMic1);
            Assert.IsNotNull(clmmSchedule.RovingMic2);
            Assert.IsNotNull(clmmSchedule.Security);
            Assert.IsNotNull(clmmSchedule.SoundDesk);
            Assert.IsNotNull(clmmSchedule.Treasures);

            Assert.IsNotNull(clmmSchedule.Week);
        }

        [TestMethod]
        public void TestFakeCircutVisitClmmScheduleMaker()
        {
            var coClmmSchedule = new FakeModelFactory().MakeCircuitVisitClmmSchedule();
            Assert.IsNotNull(coClmmSchedule);
        }

        [TestMethod]
        public void TestFakeCircutVisitPmScheduleMaker()
        {
            var coPmSchedule = new FakeModelFactory().MakeCircuitVisitPmSchedule();
            Assert.IsNotNull(coPmSchedule);
        }

        [TestMethod]
        public void TestFakeCongMemberWithPrivileges()
        {
            var privileges = new Privileges { Attendant = true };
            var congMemberWithPrivileges = new FakeModelFactory().MakeCongMemberWithPrivileges(true, privileges);
            Assert.IsTrue(congMemberWithPrivileges.Male);
            Assert.IsNotNull(congMemberWithPrivileges.Privileges);
            Assert.IsTrue(congMemberWithPrivileges.Privileges.Attendant);
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
            var privileges = new FakeModelFactory().MakeRandomPrivileges(false);
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
