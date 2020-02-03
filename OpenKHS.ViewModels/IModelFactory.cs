using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public interface IModelFactory
    {
        T Create<T>() where T : class, IModel, new();
    }
}