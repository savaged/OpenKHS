using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task ListClmmSchedulesTest()
        {
            try
            {
                var modelService = _kernel.Get<IModelService>();
                var dbContextFactory = _kernel.Get<IDbContextFactory>();
                using (var context = dbContextFactory.Create())
                {
                    for (var i = 1; i < 6; i++)
                    {
                        var model = modelService.Create<ClmmSchedule>();
                        context.Add(model);    
                    }
                    await context.SaveChangesAsync();
                }
                await _mainViewModel.ClmmScheduleAdminViewModel.LoadAsync();
                Assert.AreEqual(5, _mainViewModel.ClmmScheduleAdminViewModel
                    .IndexViewModel.Index.Count());
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
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
                _mainViewModel.ClmmScheduleAdminViewModel.AddCmd.Execute(null);
                var model = _mainViewModel
                    .ClmmScheduleAdminViewModel.SelectedItemViewModel.SelectedItem;
                Assert.IsNotNull(model);
                model.WeekStarting = DateTime.Now.AddMonths(1);
                Assert.AreEqual(0, model.Id);
                _mainViewModel.ClmmScheduleAdminViewModel
                    .SelectedItemViewModel.SaveCmd.Execute(null);
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
        public async Task SelectAndUpdateClmmSchedule()
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
                await _mainViewModel.ClmmScheduleAdminViewModel.LoadAsync();
                var index = _mainViewModel.ClmmScheduleAdminViewModel.IndexViewModel.Index;
                Assert.IsNotNull(index);
    
                // Simulate user selecting from list
                var model = index.FirstOrDefault(m => m.WeekStarting == example.WeekStarting);
                Assert.IsNotNull(model);
                _mainViewModel.ClmmScheduleAdminViewModel.SelectedItemViewModel.SelectedItem =
                    model;
                Assert.IsNotNull(
                    _mainViewModel.ClmmScheduleAdminViewModel.SelectedItemViewModel.SelectedItem);
    
                _mainViewModel.ClmmScheduleAdminViewModel
                    .SelectedItemViewModel.SelectedItem.WeekStarting = DateTime.Now.AddDays(14);
                _mainViewModel.ClmmScheduleAdminViewModel
                    .SelectedItemViewModel.SaveCmd.Execute(null);
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

        [TestMethod]
        public async Task SelectAndDeleteClmmSchedule()
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
                    await context.SaveChangesAsync();
                }
                await _mainViewModel.ClmmScheduleAdminViewModel.LoadAsync();
                var index = _mainViewModel.ClmmScheduleAdminViewModel.IndexViewModel.Index;
                Assert.IsNotNull(index);
    
                // Simulate user selecting from list
                var model = index.FirstOrDefault(m => m.WeekStarting == example.WeekStarting);
                Assert.IsNotNull(model);
                _mainViewModel.ClmmScheduleAdminViewModel.SelectedItemViewModel.SelectedItem = model;
                Assert.IsNotNull(_mainViewModel.ClmmScheduleAdminViewModel.SelectedItemViewModel.SelectedItem);
    
                _mainViewModel.ClmmScheduleAdminViewModel.SelectedItemViewModel.SaveCmd.Execute(null);
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
