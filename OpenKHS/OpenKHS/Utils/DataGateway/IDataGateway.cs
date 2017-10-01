
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenKHS.Utils.DataGateway
{
    public interface IDataGateway
    {
        Task<ResponseRootObject> Request(string resourceLocation);

        Task<ResponseRootObject> Request(
            string resourceLocation, Dictionary<string, object> data);
    }
}
