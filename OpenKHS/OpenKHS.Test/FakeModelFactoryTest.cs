using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using OpenKHS.Seeder;

namespace OpenKHS.Test
{
    [TestClass]
    public class FakeModelFactoryTest : TestBase
    {
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
        public void TestFakeCongregationMemberMaker()
        {

        }
    }
}
