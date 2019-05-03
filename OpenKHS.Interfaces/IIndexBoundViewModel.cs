using System.Collections.ObjectModel;

namespace OpenKHS.Interfaces
{
    public interface IIndexBoundViewModel<T> : IModelBoundViewModel<T>
        where T : IModel, new()
    {
        ObservableCollection<T> Index { get; set; }
        bool IsItemSelected { get; }
    }
}
