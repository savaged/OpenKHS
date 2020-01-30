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
            using (var context = DbContextFactory.Create())
            {
                foreach (var model in context.LocalCongregationMembers)
                {
                    Index.Add(model);
                }
            }
        }
    }
}