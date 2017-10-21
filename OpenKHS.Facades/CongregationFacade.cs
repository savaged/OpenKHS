
using Newtonsoft.Json;
using OpenKHS.Facades.Converters;
using OpenKHS.Interfaces;
using OpenKHS.Models;
using System;
using System.IO;

namespace OpenKHS.Facades
{
    public class CongregationFacade
    {
        private IDataGateway _gateway;
        public CongregationFacade(IDataGateway gateway)
        {
            _gateway = gateway;
        }

        public Congregation Show()
        {
            string response;
            var cong = new Congregation();
            var isNew = false;
            try
            {
                response = _gateway.Request(typeof(Congregation), Methods.Get, null);
            }
            catch (FileNotFoundException)
            {
                isNew = true;
                response = _gateway.Request(typeof(Congregation), Methods.Post, cong);
            }
            if (isNew)
            {
                return cong;
            }
            cong = JsonConvert.DeserializeObject<Congregation>(response, new CongregationConverter());
            return cong;
        }

        public bool Store(Congregation cong)
        {
            var rawResponse = _gateway.Request(cong.GetType(), Methods.Post, cong);
            var response = JsonConvert.DeserializeObject<bool>(rawResponse);
            return response;
        }

        public bool Delete()
        {
            var rawResponse = _gateway.Request(typeof(Congregation), Methods.Delete, null);
            var response = JsonConvert.DeserializeObject<bool>(rawResponse);
            return response;
        }
    }
}
