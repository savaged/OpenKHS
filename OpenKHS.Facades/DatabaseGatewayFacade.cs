using System;
using System.Linq;
using OpenKHS.Interfaces;
using OpenKHS.Data;
using OpenKHS.Models;
using System.Collections.Generic;

namespace OpenKHS.Facades
{
    public class DatabaseGatewayFacade<T> : IDataGatewayFacade<T> where T : IModel, new()
    {
        public DatabaseGatewayFacade()
        {

        }

        public T Show(int id)
        {
            throw new NotImplementedException();
        }

        public IList<T> Index()
        {
            var list = new List<T>();
            // TODO
            return list;
        }

        public bool Store(T model)
        {
            ValidateAction(Methods.Post, model);
            // TODO
            return false;
        }

        public bool Update(T model)
        {
            ValidateAction(Methods.Put, model);
            // TODO
            return false;
        }

        public bool Delete()
        {
            // TODO
            return false;
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
