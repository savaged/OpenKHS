using OpenKHS.Data;
using OpenKHS.Models;
using OpenKHS.Models.Utils;

namespace OpenKHS.ViewModels
{
    public class LocalCongregationMemberViewModel
        : SelectedItemViewModel<LocalCongregationMember>
    {
        public LocalCongregationMemberViewModel(
            IModelService modelService) 
            : base(modelService)
        {
        }

        public override bool CanSave => CanExecute && IsItemSelected;

        protected override void OnSave()
        {
            if (SelectedItem.IsNew())
            {
                ModelService.Insert(SelectedItem);
            }
            else
            {
                ModelService.Update(SelectedItem);
            }
        }
    }
}