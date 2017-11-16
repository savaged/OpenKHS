using System;
using System.Collections.Generic;

namespace OpenKHS.Interfaces
{
    public interface IDataGateway
    {
        string Request(Type resource, Methods method, IDictionary<string, object> data);
    }
}
