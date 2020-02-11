using System.Collections.Generic;
using System.Threading.Tasks;
using OpenKHS.Models;

namespace OpenKHS.Data
{
    public interface IModelService
    {
        Task DeleteAsync<T>(T model) where T : class, IModel;
        IList<T> GetIndex<T>() where T : class, IModel;
        T Get<T>(int id) where T : class, IModel;
        T Create<T>() where T : class, IModel, new();
        Task InsertAsync<T>(T model) where T : class, IModel;
        Task UpdateAsync<T>(T model) where T : class, IModel;
    }

}