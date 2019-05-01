using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenKHS.Data;
using OpenKHS.Models;
using OpenKHS.ViewModels;
using OpenKHS.Models.Utils;
using OpenKHS.ViewModels.Utils;

namespace OpenKHS.Test.Feature
{
    [TestClass]
    public class PmScheduleLoadFirstTimeTest : DbContextTestBase
    {
        [TestMethod]
        public void TestPmScheduleLoadFirstTime()
        {
            IList<LocalCongregationMember> congMembers;
            congMembers = DbContext.LocalCongregationMembers.ToList();
            var repositoryLookup = new RepositoryLookup(DbContext);
            var vm = new PmScheduleViewModel(repositoryLookup, congMembers);

            // Default empty schedule for new week
            Assert.IsNotNull(vm.ModelObject);
            Assert.AreEqual(
                WeekNumberAdapter.GetFirstDateOfWeekIso8601(DateTime.Now), vm.ModelObject.WeekStarting);
        }
    }
}
