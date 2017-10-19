using System;
using Newtonsoft.Json.Converters;
using OpenKHS.Models;

namespace OpenKHS.Facades.Converters
{
    public class CongregationConverter : CustomCreationConverter<Congregation>
    {
        public override Congregation Create(Type T)
        {
            return new Congregation();
        }
    }
}
