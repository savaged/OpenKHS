using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OpenKHS.Models;

namespace OpenKHS.Data
{
    public class ModelService : IModelService
    {
        private readonly IDbContextFactory _dbContextFactory;

        public ModelService(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory ??
                throw new ArgumentNullException(nameof(dbContextFactory));
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

        public void Insert<T>(T model) where T : class, IModel
        {
            if (model == null) return;

            using (var context = _dbContextFactory.Create())
            {
                context.Entry(model).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update<T>(T model) where T : class, IModel
        {
            if (model == null) return;

            using (var context = _dbContextFactory.Create())
            {
                context.Entry(model).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete<T>(T model) where T : class, IModel
        {
            if (model == null) return;

            using (var context = _dbContextFactory.Create())
            {
                context.Entry(model).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        private DbSet<T> GetDbSet<T>(OpenKHSContext context) where T : class, IModel
        {
            var @switch = new Dictionary<Type, object>
            {
                { typeof(ClmmSchedule), context.ClmmSchedules },
                { typeof(LocalCongregationMember), context.LocalCongregationMembers },
                { typeof(Assignment), context.Assignments },
                { typeof(UnavailablePeriod), context.UnavailablePeriods},
                { typeof(AssignmentType), context.AssignmentTypes }
            };
            var value = @switch[typeof(T)] as DbSet<T>;
            return value;
        }
    }
}