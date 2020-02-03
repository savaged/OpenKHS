using OpenKHS.Models;

namespace OpenKHS.ViewModels
{
    public class ModelFactory : IModelFactory
    {
        public T Create<T>() where T : class, IModel
        {
            T model = default;
            // TODO create Assignment
            return model;
        }
    }
}