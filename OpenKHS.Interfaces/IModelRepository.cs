using System.Collections.Generic;

namespace OpenKHS.Interfaces
{
    public interface IModelRepository<T> where T : IModel, new()
    {
        void Delete(T model);
        IList<T> Index();
        T Show(int id);
        void Store(T @new);
        void Update(T existing);
    }
}