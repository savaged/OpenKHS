
using System.Collections.Generic;

namespace OpenKHS.Interfaces
{
    public interface IDataGatewayFacade<T> where T : IModel, new()
    {
        bool Delete();
        IList<T> Index();
        T Show(int id);
        bool Store(T model);
        bool Update(T model);
    }
}