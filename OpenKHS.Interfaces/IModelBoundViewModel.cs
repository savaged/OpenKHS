
using System.ComponentModel;

namespace OpenKHS.Interfaces
{
    public interface IModelBoundViewModel<T> : IViewModel
        where T : IModel
    {
        T Selected { get; set; }

        void Save();
    }
}
