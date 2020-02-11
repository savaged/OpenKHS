using System;
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
    public class ClmmScheduleAssignmentTests
    {
        private IKernel _kernel;
        private SqliteConnection _dbConnection;
        private MainViewModel _mainViewModel;

        private ClmmSchedule _selectedSchedule;

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

            var dbContextFactory = _kernel.Get<IDbContextFactory>();
            using (var context = dbContextFactory.Create())
            {
                _selectedSchedule = new ClmmSchedule
                {
                    WeekStarting = DateTime.Now.AddMonths(1)
                };
                context.Add(_selectedSchedule);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void SelectAndSaveAssignment()
        {
            try
            {
                // TODO _selectedSchedule.Attendant1 = Selected Assignee
            }
            finally
            {
                _dbConnection.Close();
            }
        }

    }
}