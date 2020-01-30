using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using OpenKHS.Data;
using OpenKHS.Models;
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
            _kernel = new StandardKernel(
                new TestDbContextBindings("ListLocalCongregationAdmin"));

            SetupTestData();

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

        private void SetupTestData()
        {
            var dbContextFactory = _kernel.Get<IDbContextFactory>();
            using (var context = dbContextFactory.Create())
            {
                for (var i = 1; i < 6; i++)
                {
                    var model = new LocalCongregationMember
                    {
                        Id = i,
                        Name = "An Other"
                    };
                    context.Add(model);
                }
                context.SaveChanges();
            }
        }
    }
}