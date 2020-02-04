using Microsoft.Data.Sqlite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using OpenKHS.Lookups;
using OpenKHS.Models;

namespace OpenKHS.Test.Unit
{
    [TestClass]
    public class AssignmentTypeTests
    {
        private IKernel _kernel;
        private SqliteConnection _dbConnection;

        [TestInitialize]
        public void Init()
        {
            _kernel = new StandardKernel(
                new LookupsCoreBindings(),
                new TestDbContextBindings());
            _dbConnection = _kernel.Get<SqliteConnection>();
            
            _dbConnection.Open();
        }

        [TestMethod]
        public void GetMatchingAssignmentTypeTest()
        {
            try
            {
                Assert.AreEqual(AssignmentType.Empty, AssignmentType.Empty);

                var lookupService = _kernel.Get<IAssignmentTypeService>();
                var assignmentTypes = lookupService.GetIndex();

                var assignmentType = AssignmentType.GetMatchingAssignmentType(
                    "bogus", assignmentTypes);
                Assert.IsNotNull(assignmentType);
                Assert.AreEqual(AssignmentType.Empty, assignmentType);

                assignmentType = AssignmentType.GetMatchingAssignmentType(
                    nameof(Assignee.Attendant), assignmentTypes);
                Assert.IsNotNull(assignmentType);
                Assert.AreEqual(nameof(Assignee.Attendant), assignmentType.Name);
            }
            finally
            {
                _dbConnection.Close();
            }
        }
    }
}