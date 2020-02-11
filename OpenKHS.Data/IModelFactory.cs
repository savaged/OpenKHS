using System.Threading.Tasks;
using OpenKHS.Models;

namespace OpenKHS.Data
{
    public interface IModelFactory
    {
        Task<T> CreateAsync<T>() where T : class, IModel, new();
    }
}