using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using OpenKHS.Data;
using OpenKHS.Models;

namespace OpenKHS.Test.Integration
{
    [TestClass]
    public class DbCRUDTests
    {
        [TestMethod]
        public void LocalCongregationMemberCRUDTests()
        {
            var kernel = new StandardKernel(
                new TestDbContextBindings("LocalCongregationMemberCRUDTests"));
            var dbContextFactory = kernel.Get<IDbContextFactory>();            

            var modelId = 0;
            // Create
            using (var context = dbContextFactory.Create())
            {
                var model = new LocalCongregationMember
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
            using (var context = dbContextFactory.Create())
            {
                var model = context.LocalCongregationMembers
                    .Single(m => m.Id == modelId);
                Assert.AreEqual(modelId, model.Id);
                Assert.AreNotEqual(0, modelId);
            }
            // Update
            using (var context = dbContextFactory.Create())
            {
                var model = context.LocalCongregationMembers
                    .Single(m => m.Id == modelId);
                model.Name = "New Name";
                context.SaveChanges();
                Assert.AreNotEqual("Test Member", model.Name);
                Assert.AreEqual("New Name", model.Name);
                Assert.AreEqual(modelId, model.Id);
            }
            // Delete
            using (var context = dbContextFactory.Create())
            {
                var model = context.LocalCongregationMembers
                    .Single(m => m.Id == modelId);
                Assert.AreEqual(modelId, model.Id);
                context.LocalCongregationMembers.Remove(model);
                context.SaveChanges();
                var index = context.LocalCongregationMembers
                    .Where(m => m.Id == modelId)
                    .ToList();
                Assert.AreEqual(0, index.Count);
            }
        }
    }
}