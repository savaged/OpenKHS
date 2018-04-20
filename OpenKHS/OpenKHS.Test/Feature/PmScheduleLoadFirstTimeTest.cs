using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenKHS.Data;
using OpenKHS.Models;
using OpenKHS.ViewModels;

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

            Assert.IsNull(vm.ModelObject);
            
            vm.ViewWeekCmd.Execute(new DateTime(2018, 4, 20));

            Assert.IsNotNull(vm.ModelObject);
        }
    }
}
