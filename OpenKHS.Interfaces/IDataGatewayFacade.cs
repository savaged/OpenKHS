
using System.Collections.Generic;

namespace OpenKHS.Interfaces
{
    public interface IDataGatewayFacade<T> where T : IModel, new()
    {
        IList<T> Search(string field, object arg);
        bool Delete();
        IList<T> Index();
        T Show(int id);
        bool Store(T model);
        bool Update(T model);
    }
}