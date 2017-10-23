
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
            var model = new Congregation();
            var isNew = false;
            try
            {
                response = _gateway.Request(typeof(Congregation), Methods.Get, null);
            }
            catch (FileNotFoundException)
            {
                isNew = true;
                response = _gateway.Request(typeof(Congregation), Methods.Post, model);
            }
            if (isNew)
            {
                return model;
            }
            model = JsonConvert.DeserializeObject<Congregation>(response, new CongregationConverter());
            return model;
        }

        public bool Store(Congregation model)
        {
            var rawResponse = _gateway.Request(model.GetType(), Methods.Post, model);
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
