using OpenKHS.Data;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class LocalCongregationMemberViewModel
        : SelectedItemViewModel<LocalCongregationMember>
    {
        public LocalCongregationMemberViewModel(
            IDbContextFactory dbContextFactory) 
            : base(dbContextFactory)
        {
        }

    }
}