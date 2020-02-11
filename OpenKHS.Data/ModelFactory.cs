using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<T> CreateAsync<T>() where T : class, IModel, new()
        {
            var model = new T();
            if (model is ISchedule)
            { 
                var assignmentTypes = await GetAssignmentTypesAsync();
                if (model is ClmmSchedule) 
                {
                    model = new ClmmSchedule(assignmentTypes) as T;
                }
                else if (model is PmSchedule)
                {
                    model = new PmSchedule(assignmentTypes) as T;
                }
            }
            return model;
        }

        private async Task<IList<AssignmentType>> GetAssignmentTypesAsync()
        {
            var index = new List<AssignmentType>();
            using (var context = await _dbContextFactory.CreateAsync())
            {
                index = context.AssignmentTypes.ToList();
            }
            return index;
        }
    }
}