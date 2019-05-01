using System;
using System.Collections.Generic;

namespace OpenKHS.Interfaces
{
    public interface IRepositoryLookup
    {
        IDictionary<Type, object> Repositories { get; }

        IModelRepository<T> GetRelatedRepository<T>() where T : IModel, new();
    }
}