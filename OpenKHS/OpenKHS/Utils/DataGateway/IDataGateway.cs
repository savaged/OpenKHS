
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenKHS.Utils.DataGateway
{
    public interface IDataGateway
    {
        Task<ResponseRootObject> Request(string resourceLocation, Methods method);

        Task<ResponseRootObject> Request(
            string resourceLocation, Methods method, Dictionary<string, object> data);
    }
}
