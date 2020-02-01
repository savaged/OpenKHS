using OpenKHS.Data;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class LocalCongregationAdminViewModel 
        : MasterDetailViewModel<LocalCongregationMember>
    {
        public LocalCongregationAdminViewModel(
            IModelService modelService)
            : base(
                new IndexViewModel<LocalCongregationMember>(modelService),
                new SelectedItemViewModel<LocalCongregationMember>(modelService))
        {
        }
        
    }
}