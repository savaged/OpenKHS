using OpenKHS.Data;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class LocalCongregationAdminViewModel 
        : MasterDetailViewModel<LocalCongregationMember>
    {
        public LocalCongregationAdminViewModel(
            IDbContextFactory dbContextFactory)
            : base(
                new LocalCongregationMembersViewModel(dbContextFactory),
                new LocalCongregationMemberViewModel(dbContextFactory))
        {
        }

        public override void Load()
        {
            IndexViewModel.Load();
        }
        
    }
}