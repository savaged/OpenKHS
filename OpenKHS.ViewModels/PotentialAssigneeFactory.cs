using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenKHS.Data;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class PotentialAssigneeFactory : IPotentialAssigneeFactory
    {
        private readonly IModelService _modelService;
        private readonly IModelFactory  _modelFactory;
        private IList<AssignmentType> _assignmentTypes;

        public PotentialAssigneeFactory(
            IModelService modelService,
            IModelFactory modelFactory)
        {
            _modelService = modelService ??
                throw new ArgumentNullException(nameof(modelService));
            _modelFactory = modelFactory ??
                throw new ArgumentNullException(nameof(modelFactory));
            _assignmentTypes = new List<AssignmentType>();

            Attendants = new List<Assignee>();
        }

        public void Init()
        {
            InitialiseAssignmentTypes();
            Attendants = GetAttendants();
        }

        public IList<Assignee> Attendants { get; private set; }

        private IList<Assignee> GetAttendants()
        {
            var assignmentType = GetAssignmentType(nameof(Assignee.Attendant));
            var assignees = GetPotentialAssignees(assignmentType);
            var ordered = GetOrdered(assignees);
            return ordered;
        }

        private IList<Assignee> GetPotentialAssignees(AssignmentType assignmentType) 
        {
            var index = GetIndex<Assignee>(assignmentType);
            return index;
        }

        private IList<Assignee> GetOrdered(IList<Assignee> index)
        {
            var ordered = index.OrderBy(a => a.Assignments.FirstOrDefault());
            return ordered.ToList();
        }

        private AssignmentType GetAssignmentType(string assignmentName)
        {
            var value = _assignmentTypes.FirstOrDefault(
                t => t.Name == assignmentName);
            return value;
        }

        private IList<T> GetIndex<T>(AssignmentType assignmentType)
            where T : Assignee
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