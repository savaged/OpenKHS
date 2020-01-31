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
                new LocalCongregationMembersViewModel(modelService),
                new LocalCongregationMemberViewModel(modelService))
        {
        }

        public override void Load()
        {
            IndexViewModel.Load();
        }
        
    }
}