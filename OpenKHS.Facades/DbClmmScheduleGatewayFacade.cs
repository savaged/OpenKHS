using System;
using System.Linq;
using OpenKHS.Interfaces;
using OpenKHS.Data;
using OpenKHS.Models;
using System.Collections.Generic;

namespace OpenKHS.Facades
{
    public class DbClmmGatewayFacade : IDataGatewayFacade<ClmmSchedule>
    {
        public IList<ClmmSchedule> Search(string field, object arg)
        {
            var list = new List<ClmmSchedule>();
            if (arg != null)
            {
                using (var db = new DatabaseContext())
                {

                }
            }
            return list;
        }

        public ClmmSchedule Show(int id)
        {
            throw new NotImplementedException();
        }

        public IList<ClmmSchedule> Index()
        {
            var list = new List<ClmmSchedule>();
            using (var db = new DatabaseContext())
            {
                list = db.ClmmSchedules.ToList();
            }
            return list;
        }

        public bool Store(ClmmSchedule model)
        {
            ValidateAction(Methods.Post, model);
            // TODO
            return false;
        }

        public bool Update(ClmmSchedule model)
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

        private void ValidateAction(Methods method, ClmmSchedule model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("Expected model of type " + typeof(ClmmSchedule) +
                    " never to be null when calling the " + method + " action.");
            }
        }
    }
}
