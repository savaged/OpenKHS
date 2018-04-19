using System;
using Newtonsoft.Json;
using OpenKHS.Interfaces;
using OpenKHS.Models;
using System.Collections.Generic;
using System.IO;

namespace OpenKHS.Facades
{
    public class JsonDataGatewayFacade<T> where T : IModel, new()
    {
        private IDataGateway _gateway;
        private JsonSerializerSettings _settings;

        public JsonDataGatewayFacade(IDataGateway gateway)
        {
            _gateway = gateway;
            _settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        public T Show()
        {
            string response;
            var model = new T();
            var isNew = false;
            try
            {
                response = _gateway.Request(typeof(T), Methods.Get, null);
            }
            catch (FileNotFoundException)
            {
                isNew = true;
                response = _gateway.Request(typeof(T), Methods.Post, model.GetData());
            }
            if (isNew)
            {
                return model;
            }
            model = JsonConvert.DeserializeObject<T>(response, _settings);
            return model;
        }

        public bool Store(T model)
        {
            ValidateAction(Methods.Post, model);
            var rawResponse = _gateway.Request(model.GetType(), Methods.Post, model.GetData());
            var response = JsonConvert.DeserializeObject<bool>(rawResponse, _settings);
            return response;
        }

        public bool Update(T model)
        {
            ValidateAction(Methods.Put, model);
            var rawResponse = _gateway.Request(model.GetType(), Methods.Put, model.GetData());
            var response = JsonConvert.DeserializeObject<bool>(rawResponse, _settings);
            return response;
        }

        public bool Delete()
        {
            var rawResponse = _gateway.Request(typeof(T), Methods.Delete, null);
            var response = JsonConvert.DeserializeObject<bool>(rawResponse);
            return response;
        }

        private void ValidateAction(Methods method, T model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("Expected model of type " + typeof(T) +
                    " never to be null when calling the " + method + " action.");
            }
        }
    }
}
