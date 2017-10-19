
using System;

namespace OpenKHS.Interfaces
{
    public interface IDataGateway
    {
        string Request(Type resource, Methods method, IJsonEncode data);
    }
}
