using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace OpenKHS.Utils.DataGateway
{
    [JsonConverter(typeof(ResponseConverter))]
    public sealed class ResponseRootObject
    {
        public ResponseRootObject()
        {
        }

        [JsonConstructor]
        public ResponseRootObject(ResponseDataObject[] data)
        {
            Data = data;
        }

        public ResponseDataObject[] Data { get; set; }

        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }
    }

    [JsonObject]
    public class ResponseDataObject
    {
        [JsonExtensionData]
        public IDictionary<string, JToken> Field { get; set; }

        public JToken this[string key] => Field[key];
    }
}
