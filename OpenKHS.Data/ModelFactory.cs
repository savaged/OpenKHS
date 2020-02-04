using System;
using System.Collections.Generic;
using System.Linq;
using OpenKHS.Models;

namespace OpenKHS.Data
{
    public class ModelFactory : IModelFactory
    {
        private readonly IDbContextFactory _dbContextFactory;

        public ModelFactory(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory ??
                throw new ArgumentNullException(nameof(dbContextFactory));
        }

        public T Create<T>() where T : class, IModel, new()
        {
            var model = new T();
            if (typeof(T) == typeof(ISchedule))
            { 
                var assignmentTypes = GetAssignmentTypes();
                if (typeof(T) == typeof(ClmmSchedule)) 
                {
                    model = new ClmmSchedule(assignmentTypes) as T;
                }
                else if (typeof(T) == typeof(PmSchedule))
                {
                    model = new PmSchedule(assignmentTypes) as T;
                }
            }
            return model;
        }

        private IList<AssignmentType> GetAssignmentTypes()
        {
            IList<AssignmentType> index;
            using (var context = _dbContextFactory.Create())
            {
                index = context.AssignmentTypes.ToList();
            }
            return index;
        }
    }
}