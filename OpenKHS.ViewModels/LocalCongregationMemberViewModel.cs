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

        public override bool CanSave => CanExecute && IsItemSelected;

        protected override void OnSave()
        {
            using (var context = DbContextFactory.Create())
            {
                context.SaveChanges();
            }
        }
    }
}