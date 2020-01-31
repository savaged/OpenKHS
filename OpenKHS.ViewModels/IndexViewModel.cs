using System.Collections.ObjectModel;
using OpenKHS.Data;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class IndexViewModel<T> : ModelBoundViewModel
        where T : class, IModel
    {
        public IndexViewModel(
            IModelService modelService) 
            : base(modelService)
        {
            Index = new ObservableCollection<T>();
        }

        public ObservableCollection<T> Index { get; }

        public virtual void Load()
        {
            Index.Clear();
            var index = ModelService.GetIndex<T>();
            foreach (var model in index)
            {
                Index.Add(model);
            }
        }

    }
}