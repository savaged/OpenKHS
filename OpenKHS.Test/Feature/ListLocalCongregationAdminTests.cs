using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using OpenKHS.Data;
using OpenKHS.Data.StaticData;
using OpenKHS.ViewModels;

namespace OpenKHS.Test.Feature
{
    [TestClass]
    public class ListLocalCongregationAdminTests
    {
        private IKernel _kernel;
        private MainViewModel _mainViewModel;

        [TestInitialize]
        public void Init()
        {
            _kernel = new StandardKernel(new DbContextBindings(
                DbConnectionStrings.TEST));

            _mainViewModel = _kernel.Get<MainViewModel>() ??
                throw new InvalidOperationException(
                    $"Missing dependency! {nameof(MainViewModel)}");
        }

        [TestMethod]
        public void ListLocalCongregationTest()
        {
            _mainViewModel.Load();
            Assert.AreEqual(5, _mainViewModel.LocalCongregationAdminViewModel
                .IndexViewModel.Index.Count());
        }
    }
}