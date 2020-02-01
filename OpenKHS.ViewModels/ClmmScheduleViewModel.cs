using OpenKHS.Data;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class ClmmScheduleViewModel
        : MasterDetailViewModel<ClmmSchedule>
    {
        public ClmmScheduleViewModel(
            IModelService modelService)
            : base(
                new IndexViewModel<ClmmSchedule>(modelService),
                new SelectedItemViewModel<ClmmSchedule>(modelService))
        {
        }

    }
}