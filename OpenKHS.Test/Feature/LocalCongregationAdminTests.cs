using System;
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
    public class LocalCongregationAdminTests
    {
        private IKernel _kernel;
        private SqliteConnection _dbConnection;
        private MainViewModel _mainViewModel;

        [TestInitialize]
        public void Init()
        {
            _kernel = new StandardKernel(new TestDbContextBindings());
            _dbConnection = _kernel.Get<SqliteConnection>();
            _mainViewModel = _kernel.Get<MainViewModel>() ??
                throw new InvalidOperationException(
                    $"Missing dependency! {nameof(MainViewModel)}");

            _dbConnection.Open();
        }

        [TestMethod]
        public async Task ListLocalCongregationTest()
        {
            try
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
                await _mainViewModel.LoadAsync();
                Assert.AreEqual(5, _mainViewModel.LocalCongregationAdminViewModel
                    .IndexViewModel.Index.Count());
            }
            finally
            {
                _dbConnection.Close();
            }
        }

        [TestMethod]
        public void AddAndSaveNewLocalCongregationMember()
        {
            try
            {
                _mainViewModel.LocalCongregationAdminViewModel.AddCmd.Execute(null);
                var model = _mainViewModel.LocalCongregationAdminViewModel.SelectedItemViewModel.SelectedItem;
                Assert.IsNotNull(model);
                model.Name = "An Ewmember";
                Assert.AreEqual(0, model.Id);
                _mainViewModel.LocalCongregationAdminViewModel.SelectedItemViewModel.SaveCmd.Execute(null);
                Assert.AreNotEqual(0, model.Id);
                var savedId = model.Id;
            
                var dbContextFactory = _kernel.Get<IDbContextFactory>();
                using (var context = dbContextFactory.Create())
                {
                    var saved = context.LocalCongregationMembers.Single(m => m.Id == savedId);
                    Assert.IsNotNull(saved);
                    Assert.AreEqual(model.Name, saved.Name);
                }
            }
            finally
            {
                _dbConnection.Close();
            }
        }

        [TestMethod]
        public async Task SelectAndUpdateLocalCongregationMember()
        {
            try
            {
                var example = new LocalCongregationMember
                {
                    Name = "An Exsitingmember"
                };
                var dbContextFactory = _kernel.Get<IDbContextFactory>();
                using (var context = dbContextFactory.Create())
                {
                    context.LocalCongregationMembers.Add(example);
                    context.SaveChanges();
                }
                await _mainViewModel.LoadAsync();
                var index = _mainViewModel.LocalCongregationAdminViewModel.IndexViewModel.Index;
                Assert.IsNotNull(index);
    
                // Simulate user selecting from list
                var model = index.FirstOrDefault(m => m.Name == example.Name);
                Assert.IsNotNull(model);
                _mainViewModel.LocalCongregationAdminViewModel.SelectedItemViewModel.SelectedItem = model;
                Assert.IsNotNull(_mainViewModel.LocalCongregationAdminViewModel.SelectedItemViewModel.SelectedItem);
    
                _mainViewModel.LocalCongregationAdminViewModel.SelectedItemViewModel.SelectedItem.Attendant = true;
                _mainViewModel.LocalCongregationAdminViewModel.SelectedItemViewModel.SaveCmd.Execute(null);
                using (var context = dbContextFactory.Create())
                {
                    var saved = context.LocalCongregationMembers.Single(m => m.Id == model.Id);
                    Assert.IsNotNull(saved);
                    Assert.AreEqual(model.Attendant, saved.Attendant);
                }
            }
            finally
            {
                _dbConnection.Close();
            }
        }

    }
}