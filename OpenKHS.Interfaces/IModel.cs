using System.Collections.Generic;
using System.ComponentModel;

namespace OpenKHS.Interfaces
{
    public interface IModel : IJsonEncode
    {
        event PropertyChangedEventHandler PropertyChanged;
        int Id { get; set; }
        bool IsNew { get; }
        IDictionary<string, object> GetData(bool withDisplayNames = false);
        string ToString();
    }
}