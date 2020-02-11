using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OpenKHS.Models;

namespace OpenKHS.Data
{
    public class ModelService : IModelService
    {
        private readonly IDbContextFactory _dbContextFactory;
        private readonly IModelFactory _modelFactory;

        public ModelService(
            IDbContextFactory dbContextFactory,
            IModelFactory modelFactory)
        {
            _dbContextFactory = dbContextFactory ??
                throw new ArgumentNullException(nameof(dbContextFactory));
            _modelFactory = modelFactory ??
                throw new ArgumentNullException(nameof(modelFactory));
        }

        public IList<T> GetIndex<T>() where T : class, IModel
        {
            var index = new List<T>();
            using (var context = _dbContextFactory.Create())
            {
                var dbSet = GetDbSet<T>(context);
                foreach (var model in dbSet)
                {
                    index.Add(model as T);
                }
            }
            return index;
        }

        public T Get<T>(int id) where T : class, IModel
        {
            T model;
            using (var context = _dbContextFactory.Create())
            {
                var dbSet = GetDbSet<T>(context);
                model = dbSet.Find(id) as T;
            }
            return model;
        }

        public T Create<T>() where T : class, IModel, new()
        {
            T value = _modelFactory.Create<T>();
            return value;
        }

        public async Task InsertAsync<T>(T model) where T : class, IModel
        {
            if (model == null) return;

            using (var context = _dbContextFactory.Create())
            {
                var dbSet = GetDbSet<T>(context);
                dbSet.Add(model);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync<T>(T model) where T : class, IModel
        {
            if (model == null) return;

            using (var context = _dbContextFactory.Create())
            {
                context.Entry(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync<T>(T model) where T : class, IModel
        {
            if (model == null) return;

            using (var context = _dbContextFactory.Create())
            {
                context.Entry(model).State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }

        private DbSet<T> GetDbSet<T>(OpenKHSContext context) 
            where T : class, IModel
        {
            var @switch = new Dictionary<Type, object>
            {
                { typeof(ClmmSchedule), context.ClmmSchedules },
                { typeof(PmSchedule), context.PmSchedules },
                { typeof(Assignee), context.Assignees },
                { typeof(ClmmAssignment), context.ClmmAssignments },
                { typeof(PmAssignment), context.PmAssignments },
                { typeof(UnavailablePeriod), context.UnavailablePeriods},
                { typeof(AssignmentType), context.AssignmentTypes }
            };
            if (!@switch.ContainsKey(typeof(T)))
            {
                throw new InvalidOperationException("Missing a DbSet lookup!");
            }
            var value = @switch[typeof(T)] as DbSet<T>;
            return value;
        }
    }
}