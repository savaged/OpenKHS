﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenKHS.Interfaces;
using OpenKHS.Models;
using OpenKHS.ViewModels;

namespace OpenKHS.Test.Unit
{
    [TestClass]
    public class MainViewModelTest : TestBase
    {
        [TestMethod]
        public void TestLoadNewCong()
        {
            // TODO rework this to use the in memory ORM
            var mockGateway = new Mock<IDataGateway>();
            mockGateway.Setup(g => g.Request(typeof(Congregation), Methods.Get, null)).Returns(
                new Congregation().ToString());
            mockGateway.Setup(g => g.Request(typeof(PmSchedules), Methods.Get, null)).Returns(
                new PmSchedules().ToString());
            // TODO tests for each section/main model object

            var mvm = new MainViewModel(null);
            Assert.IsNotNull(mvm.CongregationVM);
            var cvm = (CongregationViewModel)mvm.CongregationVM;
            Assert.IsNotNull(cvm.Index);
            Assert.AreEqual(1, cvm.Index.Count);
        }
        
    }
}
