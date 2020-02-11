using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IList<T>> GetIndexAsync<T>(AssignmentType assignmentType)
            where T : class, IAssignee
        {
            var lookup = new List<T>();
            var all = await _modelService.GetIndexAsync<T>();
            var filtered = all.Where(
                m => m.CanAcceptAssignmentType(assignmentType)).ToList();
            foreach (var model in filtered)
            {
                lookup.Add(model);
            }
            return lookup;
        }
    }
}