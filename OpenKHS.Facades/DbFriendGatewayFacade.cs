using System;
using System.Linq;
using OpenKHS.Interfaces;
using OpenKHS.Data;
using OpenKHS.Models;
using System.Collections.Generic;

namespace OpenKHS.Facades
{
    public class DbFriendGatewayFacade : IDataGatewayFacade<Friend>
    {
        public IList<Friend> Search(string field, object arg)
        {
            var list = new List<Friend>();
            if (arg != null)
            {
                using (var db = new DatabaseContext())
                {

                }
            }
            return list;
        }

        public Friend Show(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Friend> Index()
        {
            var list = new List<Friend>();
            using (var db = new DatabaseContext())
            {
                list = db.Friends.ToList();
            }
            return list;
        }

        public bool Store(Friend model)
        {
            ValidateAction(Methods.Post, model);
            // TODO
            return false;
        }

        public bool Update(Friend model)
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

        private void ValidateAction(Methods method, Friend model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("Expected model of type " + typeof(Friend) +
                    " never to be null when calling the " + method + " action.");
            }
        }
    }
}
