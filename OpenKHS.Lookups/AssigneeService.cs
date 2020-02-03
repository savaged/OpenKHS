using System;
using System.Collections.Generic;
using System.Linq;
using OpenKHS.Data;
using OpenKHS.Models;

namespace OpenKHS.Lookups
{
    public class AssigneeService : IAssigneeService
    {
        private readonly IModelService _modelService;

        public AssigneeService(
            IModelService modelService)
        {
            _modelService = modelService ??
                throw new ArgumentNullException(nameof(modelService));
        }

        public IList<T> GetIndex<T>(AssignmentType assignmentType)
            where T : class, ICongregationMember
        {
            var lookup = new List<T>();
            var all = _modelService.GetIndex<T>();
            // TODO var filtered = all.Where(m => m.AssignmentType == assignmentType).ToList();
            foreach (var model in all)
            {
                lookup.Add(model);
            }
            return lookup;
        }
    }
}