using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using OpenKHS.Data;
using OpenKHS.Models;
using OpenKHS.ViewModels;

namespace OpenKHS.Test.Unit
{
    [TestClass]
    public class ModelServiceTests
    {
        private IKernel _kernel;
        private SqliteConnection _dbConnection;
        private IDbContextFactory _dbContextFactory;
        private IModelService _modelService;

        [TestInitialize]
        public void Init()
        {
            _kernel = new StandardKernel(
                new ViewModelCoreBindings(),
                new TestDbContextBindings());
            _dbConnection = _kernel.Get<SqliteConnection>();
            _dbContextFactory = _kernel.Get<IDbContextFactory>();
            _modelService = _kernel.Get<IModelService>();

            _dbConnection.Open();
        }

        [TestMethod]
        public async Task InsertModel()
        {
            var model = new Assignee
            {
                Name = "An Ewmember"
            };
            try
            {
                await _modelService.InsertAsync(model);
                Assert.AreNotEqual(0, model.Id);

                using (var context = await _dbContextFactory.CreateAsync())
                {
                    var index = context.Assignees.ToList();
                    Assert.IsNotNull(index);
                    Assert.AreEqual(1, index.Count());
                    Assert.IsNotNull(index.FirstOrDefault());
                    Assert.AreEqual(model.Id, index.FirstOrDefault().Id);
                    Assert.AreEqual(model.Name, index.FirstOrDefault().Name);
                }
            }
            finally
            {
                _dbConnection.Close();
            }
        }

        [TestMethod]
        public async Task Index()
        {
            try
            {
                using (var context = await _dbContextFactory.CreateAsync())
                {
                    for (var i = 1; i < 6; i++)
                    {
                        var example = new Assignee
                        {
                            Name = "An Othermember"
                        };
                        context.Add(example);
                    }
                    await context.SaveChangesAsync();
                }
                var index = await _modelService.GetIndexAsync<Assignee>();
                Assert.IsNotNull(index);
                Assert.AreEqual(5, index.Count());
            }
            finally
            {
                _dbConnection.Close();
            }
        }

        [TestMethod]
        public async Task UpdateModel()
        {
            try
            {
                var example = new Assignee
                {
                    Name = "An Ewmember"
                };
                using (var context = await _dbContextFactory.CreateAsync())
                {
                    context.Add(example);
                    await context.SaveChangesAsync();
                }
                example.Attendant = true;
                await _modelService.UpdateAsync(example);
                using (var context = await _dbContextFactory.CreateAsync())
                {
                    var updated = context.Assignees
                        .Single(m => m.Id == example.Id);
                    Assert.IsNotNull(updated);
                    Assert.AreEqual(example.Id, updated.Id);
                    Assert.AreEqual(example.Attendant, updated.Attendant);
                    Assert.IsTrue(updated.Attendant);
                }
            }
            finally
            {
                _dbConnection.Close();
            }
        }


        [TestMethod]
        public async Task DeleteModel()
        {
            try
            {
                var example = new Assignee
                {
                    Name = "An Ewmember"
                };
                using (var context = await _dbContextFactory.CreateAsync())
                {
                    context.Add(example);
                    await context.SaveChangesAsync();
                }
                await _modelService.DeleteAsync(example);
                using (var context = await _dbContextFactory.CreateAsync())
                {
                    var deleted = context.Assignees
                        .SingleOrDefault(m => m.Id == example.Id);
                    Assert.IsNull(deleted);
                }
            }
            finally
            {
                _dbConnection.Close();
            }
        }

    }
}