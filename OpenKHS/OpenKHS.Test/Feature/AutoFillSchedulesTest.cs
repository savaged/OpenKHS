using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenKHS.Models;

namespace OpenKHS.Test.Feature
{
    [TestClass]
    public class AutoFillSchedulesTest : TestBase
    {
        [TestMethod]
        public void TestPmScheduleAutoFill()
        {
            var pmSchedule = new PmSchedule();
            //TODO autofill
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
        public void TestClmmScheduleAutoFill()
        {
            var clmmSchedule = new ClmmSchedule();
            // TODO autofill
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
        public void TestCircutVisitClmmScheduleAutoFill()
        {
            var coClmmSchedule = new CircuitVisitClmmSchedule();
            // TODO autofill
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
        public void TestCircutVisitPmScheduleAutoFill()
        {
            var coPmSchedule = new CircuitVisitPmSchedule();
            // TODO autofill
            Assert.IsNotNull(coPmSchedule);
            Assert.IsNotNull(coPmSchedule.PublicTalk);
            Assert.IsNotNull(coPmSchedule.PublicTalk.Friend);
            Assert.IsNotNull(coPmSchedule.ClosingTalk);
            Assert.IsNotNull(coPmSchedule.ClosingTalk.CircuitOverseer);
            Assert.AreEqual(coPmSchedule.PublicTalk.Friend.Lastname, coPmSchedule.ClosingTalk.CircuitOverseer.Lastname);
        }
    }
}
