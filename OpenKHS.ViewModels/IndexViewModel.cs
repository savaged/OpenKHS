using System.Collections.ObjectModel;
using System.Threading.Tasks;
using OpenKHS.Data;
using OpenKHS.Models;
using Savaged.BusyStateManager;

namespace OpenKHS.ViewModels
{
    public class IndexViewModel<T> : ModelBoundViewModel
        where T : class, IModel
    {
        public IndexViewModel(
            IBusyStateRegistry busyStateManager,
            IModelService modelService) 
            : base(busyStateManager, modelService)
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