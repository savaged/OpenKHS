using System;
using OpenKHS.Data;
using OpenKHS.Models;
using Savaged.BusyStateManager;

namespace OpenKHS.ViewModels
{
    public class ScheduleAdminViewModel<T> : MasterDetailViewModel<T>
        where T : class, IModel, new()
    {
        public ScheduleAdminViewModel(
            IBusyStateRegistry busyStateManager,
            IModelService modelService,
            IndexViewModel<T> indexViewModel,
            SelectedItemViewModel<T> selectedItemViewModel,
            IPotentialAssignmentsFactory potentialAssignmentsFactory) 
            : base(
                busyStateManager,
                modelService,
                indexViewModel,
                selectedItemViewModel)
        {
            PotentialAssignmentsFactory = potentialAssignmentsFactory ??
                throw new ArgumentNullException(nameof(potentialAssignmentsFactory));

            // TODO Register for a pre-saving event then remove all but selected assignments from the db context
        }

        public IPotentialAssignmentsFactory PotentialAssignmentsFactory { get; }

    }
}