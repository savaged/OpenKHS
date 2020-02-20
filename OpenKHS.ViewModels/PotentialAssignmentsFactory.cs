using System;
using System.Collections.Generic;
using System.Linq;
using OpenKHS.Data;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class PotentialAssignmentsFactory : IPotentialAssignmentsFactory
    {
        private readonly IModelService _modelService;
        private IList<AssignmentType> _assignmentTypes;

        public PotentialAssignmentsFactory(
            IModelService modelService)
        {
            _modelService = modelService ??
                throw new ArgumentNullException(nameof(modelService));
            _assignmentTypes = new List<AssignmentType>();
        }

        public IList<Assignment> Attendants
        {
            get
            {
                var assignmentType = GetAssignmentType(nameof(Assignee.Attendant));
                var assignees = GetPotentialAssignees(assignmentType);
                var ordered = GetOrdered(assignees);
                var potentialAssignments = new List<Assignment>();
                foreach (var assignee in ordered)
                {
                    potentialAssignments.Add(new Assignment(assignmentType, assignee));
                }
                return potentialAssignments;
            }
        }

        private IList<Assignee> GetPotentialAssignees(AssignmentType assignmentType) 
        {
            InitialiseAssignmentTypes();
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