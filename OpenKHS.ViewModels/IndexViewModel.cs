using System.Collections.ObjectModel;
using OpenKHS.Data;
using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public abstract class IndexViewModel<T> : ModelBoundViewModel
        where T : IModel
    {
        public IndexViewModel(
            IDbContextFactory dbContextFactory) 
            : base(dbContextFactory)
        {
            Index = new ObservableCollection<T>();
        }

        public ObservableCollection<T> Index { get; }

        public abstract void Load();
    }
}