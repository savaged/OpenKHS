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
        private int _attendant2AssigneeId;
        private int _attendant3AssigneeId;
        private int _attendant4AssigneeId;

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

        public int Attendant2AssigneeId
        {
            get => _attendant2AssigneeId;
            set 
            {
                _attendant2AssigneeId = value;
                if (SelectedItem?.Attendant2 == null)
                {
                    throw new InvalidOperationException(
                        $"{nameof(SelectedItem)}.{nameof(SelectedItem.Attendant2)} must be set!");
                }
                SelectedItem.Attendant2.Assignee = _potentialAssigneeFactory.Attendants
                    .FirstOrDefault(a => a.Id == value);
            } 
        }

        public int Attendant3AssigneeId
        {
            get => _attendant3AssigneeId;
            set 
            {
                _attendant3AssigneeId = value;
                if (SelectedItem?.Attendant3 == null)
                {
                    throw new InvalidOperationException(
                        $"{nameof(SelectedItem)}.{nameof(SelectedItem.Attendant3)} must be set!");
                }
                SelectedItem.Attendant3.Assignee = _potentialAssigneeFactory.Attendants
                    .FirstOrDefault(a => a.Id == value);
            } 
        }

        public int Attendant4AssigneeId
        {
            get => _attendant4AssigneeId;
            set 
            {
                _attendant4AssigneeId = value;
                if (SelectedItem?.Attendant4 == null)
                {
                    throw new InvalidOperationException(
                        $"{nameof(SelectedItem)}.{nameof(SelectedItem.Attendant4)} must be set!");
                }
                SelectedItem.Attendant4.Assignee = _potentialAssigneeFactory.Attendants
                    .FirstOrDefault(a => a.Id == value);
            } 
        }

    }
}