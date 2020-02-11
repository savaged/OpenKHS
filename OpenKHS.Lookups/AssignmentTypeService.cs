using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenKHS.Data;
using OpenKHS.Models;

namespace OpenKHS.Lookups
{
    public class AssignmentTypeService : IAssignmentTypeService
    {
        private readonly IModelService _modelService;

        public AssignmentTypeService(
            IModelService modelService)
        {
            _modelService = modelService ??
                throw new ArgumentNullException(nameof(modelService));
        }

        public async Task<IList<AssignmentType>> GetIndexAsync()
        {
            var lookup = new List<AssignmentType>();
            foreach (var model in await _modelService.GetIndexAsync<AssignmentType>())
            {
                lookup.Add(model);
            }
            return lookup;
        }
    }
}