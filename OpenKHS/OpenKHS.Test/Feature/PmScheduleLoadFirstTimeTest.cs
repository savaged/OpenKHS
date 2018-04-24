using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenKHS.Data;
using OpenKHS.Models;
using OpenKHS.ViewModels;
using OpenKHS.Models.Utils;

namespace OpenKHS.Test.Feature
{
    [TestClass]
    public class PmScheduleLoadFirstTimeTest : DbContextTestBase
    {
        [TestMethod]
        public void TestPmScheduleLoadFirstTime()
        {
            IList<Friend> congMembers;
            using (var db = new DatabaseContext())
            {
                congMembers = db.Friends.ToList();
            }
            var vm = new PmScheduleViewModel(congMembers);

            // Default empty schedule for new week
            vm.ViewWeekCmd.Execute(DateTime.Now);
            Assert.IsNotNull(vm.ModelObject);
            Assert.AreEqual(
                WeekNumberAdapter.GetFirstDateOfWeekIso8601(DateTime.Now), vm.ModelObject.WeekStarting);
        }
    }
}
