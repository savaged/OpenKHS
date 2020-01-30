using System.Collections.Generic;
using OpenKHS.Models;

namespace OpenKHS.Data
{
    public interface IModelService
    {
        void Delete<T>(T model) where T : class, IModel;
        IList<T> GetIndex<T>() where T : class, IModel;
        T GetModel<T>(int id) where T : class, IModel;
        void Insert<T>(T model) where T : class, IModel;
        void Update<T>(T model) where T : class, IModel;
    }

}