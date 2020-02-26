using System;
using System.Threading.Tasks;
using OpenKHS.Data;
using OpenKHS.Models;
using Savaged.BusyStateManager;

namespace OpenKHS.ViewModels
{
    public class ScheduleAdminViewModel<T> : MasterDetailViewModel<T>
        where T : ScheduleBase, new()
    {
        public ScheduleAdminViewModel(
            IBusyStateRegistry busyStateManager,
            IModelService modelService,
            IndexViewModel<T> indexViewModel,
            SelectedItemViewModel<T> selectedItemViewModel,
            IPotentialAssigneeFactory potentialAssigneeFactory) 
            : base(
                busyStateManager,
                modelService,
                indexViewModel,
                selectedItemViewModel)
        {
            PotentialAssigneeFactory = potentialAssigneeFactory ??
                throw new ArgumentNullException(nameof(potentialAssigneeFactory));
        }

        public override async Task LoadAsync()
        {
            PotentialAssigneeFactory.Init();
            await base.LoadAsync();
        }

        public IPotentialAssigneeFactory PotentialAssigneeFactory { get; }

    }
}