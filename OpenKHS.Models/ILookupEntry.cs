using System;

namespace OpenKHS.Models
{
    public interface ILookupEntry : IModel
    {
        string Name { get; }
    }
}