using OpenKHS.Models;

namespace OpenKHS.Data
{
    public interface IModelFactory
    {
        T Create<T>() where T : class, IModel, new();
    }
}