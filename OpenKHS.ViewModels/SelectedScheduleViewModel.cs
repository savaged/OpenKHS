using System;
using System.Linq;
using OpenKHS.Data;
using OpenKHS.Models;
using Savaged.BusyStateManager;

namespace OpenKHS.ViewModels
{
    public class SelectedScheduleViewModel<T> : SelectedItemViewModel<T>
        where T : ScheduleBase, new()
    {
        private readonly IPotentialAssigneeFactory _potentialAssigneeFactory;

        private int _attendant1AssigneeId;

        public SelectedScheduleViewModel(
            IBusyStateRegistry busyStateManager,
            IModelService modelService,
            IPotentialAssigneeFactory potentialAssigneeFactory)
            : base(busyStateManager, modelService)
        {
            _potentialAssigneeFactory = potentialAssigneeFactory ??
                throw new ArgumentNullException(nameof(potentialAssigneeFactory));
        }

        public int Attendant1AssigneeId
        {
            get => _attendant1AssigneeId;
            set 
            {
                _attendant1AssigneeId = value;
                if (SelectedItem?.Attendant1 == null)
                {
                    throw new InvalidOperationException(
                        $"{nameof(SelectedItem)}.{nameof(SelectedItem.Attendant1)} must be set!");
                }
                SelectedItem.Attendant1.Assignee = _potentialAssigneeFactory.Attendants
                    .FirstOrDefault(a => a.Id == value);
            } 
        }

    }
}