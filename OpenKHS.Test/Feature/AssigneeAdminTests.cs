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
    public class AssigneeAdminTests
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

            Assert.IsTrue(_mainViewModel.CanExecute);

            _dbConnection.Open();
        }

        [TestMethod]
        public async Task ListAssigneeTest()
        {
            try
            {
                var dbContextFactory = _kernel.Get<IDbContextFactory>();
                using (var context = await dbContextFactory.CreateAsync())
                {
                    for (var i = 1; i < 6; i++)
                    {
                        var model = new Assignee
                        {
                            Id = i,
                            Name = "An Other"
                        };
                        context.Add(model);
                    }
                    await context.SaveChangesAsync();
                }
                await _mainViewModel.AssigneeAdminViewModel.LoadAsync();
                Assert.AreEqual(5, _mainViewModel.AssigneeAdminViewModel
                    .IndexViewModel.Index.Count());
            }
            finally
            {
                _dbConnection.Close();
            }
        }

        [TestMethod]
        public async Task AddAndSaveNewAssigneeMember()
        {
            try
            {
                _mainViewModel.AssigneeAdminViewModel.AddCmd.Execute(null);
                var model = _mainViewModel
                    .AssigneeAdminViewModel.SelectedItemViewModel.SelectedItem;
                Assert.IsNotNull(model);
                model.Name = "An Ewmember";
                Assert.AreEqual(0, model.Id);
                _mainViewModel.AssigneeAdminViewModel.SelectedItemViewModel.SaveCmd.Execute(null);
                Assert.AreNotEqual(0, model.Id);
                var savedId = model.Id;
            
                var dbContextFactory = _kernel.Get<IDbContextFactory>();
                using (var context = await dbContextFactory.CreateAsync())
                {
                    var saved = context.Assignees.Single(m => m.Id == savedId);
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
        public async Task SelectAndUpdateAssigneeMember()
        {
            try
            {
                var example = new Assignee
                {
                    Name = "An Exsitingmember"
                };
                var dbContextFactory = _kernel.Get<IDbContextFactory>();
                using (var context = await dbContextFactory.CreateAsync())
                {
                    context.Assignees.Add(example);
                    await context.SaveChangesAsync();
                }
                await _mainViewModel.AssigneeAdminViewModel.LoadAsync();
                var index = _mainViewModel.AssigneeAdminViewModel.IndexViewModel.Index;
                Assert.IsNotNull(index);
    
                // Simulate user selecting from list
                var model = index.FirstOrDefault(m => m.Name == example.Name);
                Assert.IsNotNull(model);
                _mainViewModel.AssigneeAdminViewModel.SelectedItemViewModel.SelectedItem = model;
                Assert.IsNotNull(_mainViewModel.AssigneeAdminViewModel.SelectedItemViewModel.SelectedItem);
    
                _mainViewModel.AssigneeAdminViewModel.SelectedItemViewModel.SelectedItem.Attendant = true;
                _mainViewModel.AssigneeAdminViewModel.SelectedItemViewModel.SaveCmd.Execute(null);
                using (var context = await dbContextFactory.CreateAsync())
                {
                    var saved = context.Assignees.Single(m => m.Id == model.Id);
                    Assert.IsNotNull(saved);
                    Assert.AreEqual(model.Attendant, saved.Attendant);
                }
            }
            finally
            {
                _dbConnection.Close();
            }
        }

        [TestMethod]
        public async Task SelectAndDeleteAssigneeMember()
        {
            try
            {
                var example = new Assignee
                {
                    Name = "An Exsitingmember"
                };
                var dbContextFactory = _kernel.Get<IDbContextFactory>();
                using (var context = await dbContextFactory.CreateAsync())
                {
                    context.Assignees.Add(example);
                    context.SaveChanges();
                }
                await _mainViewModel.AssigneeAdminViewModel.LoadAsync();
                var index = _mainViewModel.AssigneeAdminViewModel.IndexViewModel.Index;
                Assert.IsNotNull(index);
    
                // Simulate user selecting from list
                var model = index.FirstOrDefault(m => m.Name == example.Name);
                Assert.IsNotNull(model);
                _mainViewModel.AssigneeAdminViewModel.SelectedItemViewModel.SelectedItem = model;
                Assert.IsNotNull(_mainViewModel.AssigneeAdminViewModel.SelectedItemViewModel.SelectedItem);
    
                _mainViewModel.AssigneeAdminViewModel.SelectedItemViewModel.SaveCmd.Execute(null);
                using (var context = await dbContextFactory.CreateAsync())
                {
                    var saved = context.Assignees.Single(m => m.Id == model.Id);
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