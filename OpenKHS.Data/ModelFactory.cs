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
            if (typeof(T) == typeof(ClmmSchedule)) 
            {
                IList<AssignmentType> assignmentTypes;
                using (var context = _dbContextFactory.Create())
                {
                    assignmentTypes = context.AssignmentTypes.ToList();
                }
                model = new ClmmSchedule(assignmentTypes) as T;
            };
            return model;
        }
    }
}