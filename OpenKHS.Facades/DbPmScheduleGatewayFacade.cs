using System;
using System.Linq;
using OpenKHS.Interfaces;
using OpenKHS.Data;
using OpenKHS.Models;
using System.Collections.Generic;

namespace OpenKHS.Facades
{
    public class DbPmScheduleGatewayFacade : IDataGatewayFacade<PmSchedule>
    {
        public IList<PmSchedule> Search(string field, object arg)
        {
            var list = new List<PmSchedule>();
            if (arg != null)
            {
                using (var db = new DatabaseContext())
                {
                    
                }
            }
            return list;
        }

        public PmSchedule Show(int id)
        {
            throw new NotImplementedException();
        }

        public IList<PmSchedule> Index()
        {
            var list = new List<PmSchedule>();
            using (var db = new DatabaseContext())
            {
                list = db.PmSchedules.ToList();
            }
            return list;
        }

        public bool Store(PmSchedule model)
        {
            ValidateAction(Methods.Post, model);
            // TODO
            return false;
        }

        public bool Update(PmSchedule model)
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

        private void ValidateAction(Methods method, PmSchedule model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("Expected model of type " + typeof(PmSchedule) +
                    " never to be null when calling the " + method + " action.");
            }
        }
    }
}
