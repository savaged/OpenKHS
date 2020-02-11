using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using OpenKHS.Data;
using OpenKHS.Models;
using OpenKHS.ViewModels;

namespace OpenKHS.Test.Integration
{
    [TestClass]
    public class DbCRUDTests
    {
        [TestMethod]
        public async Task AssigneeCRUDTests()
        {
            var kernel = new StandardKernel(
                new ViewModelCoreBindings(),
                new TestDbContextBindings());
            var connection = kernel.Get<SqliteConnection>();
            var dbContextFactory = kernel.Get<IDbContextFactory>();            
            connection.Open();
            try
            {
                var modelId = 0;
                // Create
                using (var context = await dbContextFactory.CreateAsync())
                {
                    var model = new Assignee
                    {
                        Name = "Test Member"
                    };
                    context.Add(model);
                    context.SaveChanges();
                    modelId = model.Id;
                    Assert.AreNotEqual(0, modelId);
                    Assert.AreEqual("Test Member", model.Name);
                }
                // Read
                using (var context = await dbContextFactory.CreateAsync())
                {
                    var model = context.Assignees
                        .Single(m => m.Id == modelId);
                    Assert.AreEqual(modelId, model.Id);
                    Assert.AreNotEqual(0, modelId);
                }
                // Update
                using (var context = await dbContextFactory.CreateAsync())
                {
                    var model = context.Assignees
                        .Single(m => m.Id == modelId);
                    model.Name = "New Name";
                    context.SaveChanges();
                    Assert.AreNotEqual("Test Member", model.Name);
                    Assert.AreEqual("New Name", model.Name);
                    Assert.AreEqual(modelId, model.Id);
                }
                // Delete
                using (var context = await dbContextFactory.CreateAsync())
                {
                    var model = context.Assignees
                        .Single(m => m.Id == modelId);
                    Assert.AreEqual(modelId, model.Id);
                    context.Assignees.Remove(model);
                    context.SaveChanges();
                    var index = context.Assignees
                        .Where(m => m.Id == modelId)
                        .ToList();
                    Assert.AreEqual(0, index.Count);
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}