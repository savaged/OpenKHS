using System;
using OpenKHS.Models;
using System.Collections.Generic;
using System.Linq;
using OpenKHS.Interfaces;

namespace OpenKHS.Data
{
    public class VisitingSpeakerRepository : ModelRepositoryBase, IModelRepository<VisitingSpeaker>
    {
        public VisitingSpeakerRepository(DatabaseContext dbContext) : base(dbContext) { }

        public IList<VisitingSpeaker> Index()
        {
            return DbContext.VisitingSpeakers.ToList();
        }

        public VisitingSpeaker Show(int id)
        {
            return DbContext.VisitingSpeakers.Single(m => m.Id == id);
        }

        public void Store(VisitingSpeaker @new)
        {
            ValidateStore(@new);
            DbContext.VisitingSpeakers.Add(@new);
        }

        public void Delete(VisitingSpeaker model)
        {
            if (model != null)
            {
                DbContext.VisitingSpeakers.Remove(model);
            }
        }
    }
}
