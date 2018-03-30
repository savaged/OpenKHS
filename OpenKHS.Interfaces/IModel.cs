using System.Collections.Generic;

namespace OpenKHS.Interfaces
{
    public interface IModel : IJsonEncode
    {
        IDictionary<string, object> GetData(bool withDisplayNames = false);
        string ToString();
    }
}