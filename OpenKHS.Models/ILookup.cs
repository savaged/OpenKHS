using System;

namespace OpenKHS.Models
{
    public interface ILookup : IModel
    {
        string Name { get; }
    }
}