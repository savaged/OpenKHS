using System;
using System.Collections.Generic;
using System.Linq;
using OpenKHS.Data;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class AssigneeLookupService : IAssigneeLookupService
    {
        private readonly IModelService _modelService;
        private IList<AssignmentType> _assignmentTypes;

        public AssigneeLookupService(
            IModelService modelService)
        {
            _modelService = modelService ??
                throw new ArgumentNullException(nameof(modelService));
            _assignmentTypes = new List<AssignmentType>();
        }

        public IList<Assignee> Attendants  
        {
            get 
            {
                InitialiseAssignmentTypes();
                var assignmentType = _assignmentTypes.FirstOrDefault(
                    t => t.Name == nameof(Assignee.Attendant));
                var index = GetIndex<Assignee>(assignmentType);
                return index;
            }
        }

        private IList<T> GetIndex<T>(AssignmentType assignmentType)
            where T : class, IAssignee
        {
            var index = new List<T>();
            var all = _modelService.GetIndex<T>();
            var filtered = all.Where(
                m => m.CanAcceptAssignmentType(assignmentType)).ToList();
            foreach (var model in filtered)
            {
                index.Add(model);
            }
            return index;
        }

        private void InitialiseAssignmentTypes()
        {
            if (_assignmentTypes?.Count == 0)
            {
                _assignmentTypes = _modelService.GetIndex<AssignmentType>();
            }
        }
    }
}