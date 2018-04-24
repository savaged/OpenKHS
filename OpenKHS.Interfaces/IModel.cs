using System.Collections.Generic;

namespace OpenKHS.Interfaces
{
    public interface IModel : IJsonEncode
    {
        int Id { get; set; }
        bool IsNew { get; }
        IDictionary<string, object> GetData(bool withDisplayNames = false);
        string ToString();
    }
}