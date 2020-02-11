using System.Collections.Generic;
using System.Threading.Tasks;
using OpenKHS.Models;

namespace OpenKHS.Data
{
    public interface IModelService
    {
        Task DeleteAsync<T>(T model) where T : class, IModel;
        Task<IList<T>> GetIndexAsync<T>() where T : class, IModel;
        Task<T> GetAsync<T>(int id) where T : class, IModel;
        Task<T> CreateAsync<T>() where T : class, IModel, new();
        Task InsertAsync<T>(T model) where T : class, IModel;
        Task UpdateAsync<T>(T model) where T : class, IModel;
    }

}