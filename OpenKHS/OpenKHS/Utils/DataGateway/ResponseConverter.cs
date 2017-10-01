
using System;
using Newtonsoft.Json.Converters;

namespace OpenKHS.Utils.DataGateway
{
    /// <summary>
    /// Custom converter for the core API object.
    /// </summary>
    /// <remarks>
    /// This depends on the API developer returning an array of model objects even
    /// if there is only one.
    /// </remarks>
    /// <inheritdoc />
    public class ResponseConverter : CustomCreationConverter<ResponseRootObject>
    {
        public override ResponseRootObject Create(Type T)
        {
            return new ResponseRootObject();
        }
    }
}

