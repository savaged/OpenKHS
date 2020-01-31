using OpenKHS.Data;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class LocalCongregationMembersViewModel
        : IndexViewModel<LocalCongregationMember>
    {
        public LocalCongregationMembersViewModel(
            IModelService modelService) 
            : base(modelService)
        {
        }

        public override void Load()
        {
            Index.Clear();
            var index = ModelService.GetIndex<LocalCongregationMember>();
            foreach (var model in index)
            {
                Index.Add(model);
            }
        }
    }
}