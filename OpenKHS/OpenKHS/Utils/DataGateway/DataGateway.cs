using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenKHS.Utils.DataGateway
{
    public class DataGateway : IDataGateway
    {
        public Task<ResponseRootObject> Request(string resourceLocation)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseRootObject> Request(string resourceLocation, Dictionary<string, object> data)
        {
            throw new NotImplementedException();
        }
    }
}
