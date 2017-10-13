
using Newtonsoft.Json;
using OpenKHS.Facades.Converters;
using OpenKHS.Interfaces;
using OpenKHS.Models;
using System.Collections.Generic;

namespace OpenKHS.Facades
{
    public class CongregationFacade
    {
        private IDataGateway _gateway;
        public CongregationFacade(IDataGateway gateway)
        {
            _gateway = gateway;
        }

        public Congregation GetCongregation()
        {
            var response = _gateway.Request(typeof(Congregation), Methods.Get, null);
            var cong = JsonConvert.DeserializeObject<Congregation>(response, new CongregationConverter());
            return cong;
        }

        public bool SaveCongregation(Congregation cong)
        {
            var rawResponse = _gateway.Request(cong.GetType(), Methods.Post, cong);
            var response = JsonConvert.DeserializeObject<bool>(rawResponse);
            return response;
        }

        public bool DeleteCongregation()
        {
            var rawResponse = _gateway.Request(typeof(Congregation), Methods.Delete, null);
            var response = JsonConvert.DeserializeObject<bool>(rawResponse);
            return response;
        }
    }
}
