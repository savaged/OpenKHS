using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using OpenKHS.Data;
using OpenKHS.Lookups;
using OpenKHS.Models;
using OpenKHS.ViewModels;

namespace OpenKHS.Test.Unit
{
    [TestClass]
    public class AssigneeServiceTests
    {
        private IKernel _kernel;
        private SqliteConnection _dbConnection;
        private IDbContextFactory _dbContextFactory;
        private IAssignmentTypeService _assignmentTypeService;
        private IAssigneeService _assigneeService;

        [TestInitialize]
        public void Init()
        {
            _kernel = new StandardKernel(
                new LookupsCoreBindings(),
                new ViewModelCoreBindings(),
                new TestDbContextBindings());
            _dbConnection = _kernel.Get<SqliteConnection>();
            _dbContextFactory = _kernel.Get<IDbContextFactory>();
            _assignmentTypeService = _kernel.Get<IAssignmentTypeService>();
            _assigneeService = _kernel.Get<IAssigneeService>();

            _dbConnection.Open();
        }

        [TestMethod]
        public void IndexTest()
        {
            try
            {
                using (var context = _dbContextFactory.Create())
                {
                    for (var i = 1; i < 17; i++)
                    {
                        var example = new Assignee
                        {
                            Name = "An Othermember"
                        };
                        if (i % 3 == 0)
                        {
                            example.Attendant = true;
                        }
                        context.Add(example);
                    }
                    context.SaveChanges();
                }
                var assignmentType = _assignmentTypeService.GetIndex()
                    .SingleOrDefault(m => m.Id == 1);
                var index = _assigneeService.GetIndex<Assignee>(
                    assignmentType);
                Assert.IsNotNull(index);
                Assert.AreEqual(4, index.Count());
            }
            finally
            {
                _dbConnection.Close();
            }
        }

    }
}