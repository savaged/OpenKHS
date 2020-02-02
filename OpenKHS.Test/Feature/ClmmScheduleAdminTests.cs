using System;
using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using OpenKHS.Data;
using OpenKHS.Models;
using OpenKHS.ViewModels;

namespace OpenKHS.Test.Feature
{
    [TestClass]
    public class ClmmScheduleAdminTests
    {
        private IKernel _kernel;
        private SqliteConnection _dbConnection;
        private MainViewModel _mainViewModel;

        [TestInitialize]
        public void Init()
        {
            _kernel = new StandardKernel(
                new ViewModelCoreBindings(),
                new TestDbContextBindings());
            _dbConnection = _kernel.Get<SqliteConnection>();
            _mainViewModel = _kernel.Get<MainViewModel>() ??
                throw new InvalidOperationException(
                    $"Missing dependency! {nameof(MainViewModel)}");

            _dbConnection.Open();
        }

        [TestMethod]
        public void ListLocalCongregationTest()
        {
            try
            {
                var dbContextFactory = _kernel.Get<IDbContextFactory>();
                using (var context = dbContextFactory.Create())
                {
                    for (var i = 1; i < 6; i++)
                    {
                        var model = new ClmmSchedule
                        {
                            WeekStarting = DateTime.Now.AddMonths(1)
                        };
                        context.Add(model);
                    }
                    context.SaveChanges();
                }
                _mainViewModel.Load();
                Assert.AreEqual(5, _mainViewModel.ClmmScheduleViewModel
                    .IndexViewModel.Index.Count());
            }
            finally
            {
                _dbConnection.Close();
            }
        }

        [TestMethod]
        public void AddAndSaveNewClmmSchedule()
        {
            try
            {
                _mainViewModel.ClmmScheduleViewModel.AddCmd.Execute(null);
                var model = _mainViewModel.ClmmScheduleViewModel.SelectedItemViewModel.SelectedItem;
                Assert.IsNotNull(model);
                model.WeekStarting = DateTime.Now.AddMonths(1);
                Assert.AreEqual(0, model.Id);
                _mainViewModel.ClmmScheduleViewModel.SelectedItemViewModel.SaveCmd.Execute(null);
                Assert.AreNotEqual(0, model.Id);
                var savedId = model.Id;
            
                var dbContextFactory = _kernel.Get<IDbContextFactory>();
                using (var context = dbContextFactory.Create())
                {
                    var saved = context.ClmmSchedules.Single(m => m.Id == savedId);
                    Assert.IsNotNull(saved);
                    Assert.AreEqual(model.WeekStarting, saved.WeekStarting);
                }
            }
            finally
            {
                _dbConnection.Close();
            }
        }

        [TestMethod]
        public void SelectAndUpdateClmmSchedule()
        {
            try
            {
                var example = new ClmmSchedule
                {
                    WeekStarting = DateTime.Now.AddMonths(1)
                };
                var dbContextFactory = _kernel.Get<IDbContextFactory>();
                using (var context = dbContextFactory.Create())
                {
                    context.ClmmSchedules.Add(example);
                    context.SaveChanges();
                }
                _mainViewModel.Load();
                var index = _mainViewModel.ClmmScheduleViewModel.IndexViewModel.Index;
                Assert.IsNotNull(index);
    
                // Simulate user selecting from list
                var model = index.FirstOrDefault(m => m.WeekStarting == example.WeekStarting);
                Assert.IsNotNull(model);
                _mainViewModel.ClmmScheduleViewModel.SelectedItemViewModel.SelectedItem = model;
                Assert.IsNotNull(_mainViewModel.ClmmScheduleViewModel.SelectedItemViewModel.SelectedItem);
    
                _mainViewModel.ClmmScheduleViewModel.SelectedItemViewModel.SelectedItem.WeekStarting = 
                    DateTime.Now.AddDays(14);
                _mainViewModel.ClmmScheduleViewModel.SelectedItemViewModel.SaveCmd.Execute(null);
                using (var context = dbContextFactory.Create())
                {
                    var saved = context.ClmmSchedules.Single(m => m.Id == model.Id);
                    Assert.IsNotNull(saved);
                    Assert.AreEqual(model.WeekStarting, saved.WeekStarting);
                }
            }
            finally
            {
                _dbConnection.Close();
            }
        }

    }
}