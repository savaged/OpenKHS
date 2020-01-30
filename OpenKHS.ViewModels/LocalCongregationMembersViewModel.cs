using OpenKHS.Data;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class LocalCongregationMembersViewModel
        : IndexViewModel<LocalCongregationMember>
    {
        public LocalCongregationMembersViewModel(
            IDbContextFactory dbContextFactory) 
            : base(dbContextFactory)
        {
        }

        public override void Load()
        {
            Index.Clear();
            // TODO use model service
        }
    }
}