using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using OpenKHS.Data;
using OpenKHS.Models;

namespace OpenKHS.Test.Unit
{
    [TestClass]
    public class ModelServiceTests
    {
        private IKernel _kernel;
        private IDbContextFactory _dbContextFactory;
        private IModelService _modelService;

        [TestInitialize]
        public void Init()
        {
            _kernel = new StandardKernel(
                new TestDbContextBindings("ModelServiceTests"));
            _dbContextFactory = _kernel.Get<IDbContextFactory>();
            _modelService = _kernel.Get<IModelService>();
        }

        [TestMethod]
        public void InsertModel()
        {
            var model = new LocalCongregationMember
            {
                Name = "An Ewmember"
            };
            _modelService.Insert(model);
            Assert.AreNotEqual(0, model.Id);

            using (var context = _dbContextFactory.Create())
            {
                var index = context.LocalCongregationMembers.ToList();
                Assert.IsNotNull(index);
                Assert.AreEqual(1, index.Count());
                Assert.IsNotNull(index.FirstOrDefault());
                Assert.AreEqual(model.Id, index.FirstOrDefault().Id);
                Assert.AreEqual(model.Name, index.FirstOrDefault().Name);
            }
        }

        [TestMethod]
        public void Index()
        {
            using (var context = _dbContextFactory.Create())
            {
                for (var i = 1; i < 6; i++)
                {
                    var example = new LocalCongregationMember
                    {
                        Name = "An Othermember"
                    };
                    context.Add(example);
                }
                context.SaveChanges();
            }
            var index = _modelService.GetIndex<LocalCongregationMember>();
            Assert.IsNotNull(index);
            Assert.AreEqual(5, index.Count());
        }

        [TestMethod]
        public void UpdateModel()
        {
            var example = new LocalCongregationMember
            {
                Name = "An Ewmember"
            };
            using (var context = _dbContextFactory.Create())
            {
                context.Add(example);
                context.SaveChanges();
            }
            example.Attendant = true;
            _modelService.Update(example);
            using (var context = _dbContextFactory.Create())
            {
                var updated = context.LocalCongregationMembers
                    .Single(m => m.Id == example.Id);
                Assert.IsNotNull(updated);
                Assert.AreEqual(example.Id, updated.Id);
                Assert.AreEqual(example.Attendant, updated.Attendant);
                Assert.IsTrue(updated.Attendant);
            }
        }


        [TestMethod]
        public void DeleteModel()
        {
            var example = new LocalCongregationMember
            {
                Name = "An Ewmember"
            };
            using (var context = _dbContextFactory.Create())
            {
                context.Add(example);
                context.SaveChanges();
            }
            _modelService.Delete(example);
            using (var context = _dbContextFactory.Create())
            {
                var deleted = context.LocalCongregationMembers
                    .SingleOrDefault(m => m.Id == example.Id);
                Assert.IsNull(deleted);
            }
        }

    }
}