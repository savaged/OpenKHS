using System;
using System.Collections.Generic;
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

        public IList<AssignmentType> GetIndex()
        {
            var lookup = new List<AssignmentType>();
            foreach (var model in _modelService.GetIndex<AssignmentType>())
            {
                lookup.Add(model);
            }
            return lookup;
        }
    }
}