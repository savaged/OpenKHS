using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using OpenKHS.Data;
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
            // TODO extend DbContextBindings to make use of extended options builder
            _kernel = new StandardKernel(new DbContextBindings());

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