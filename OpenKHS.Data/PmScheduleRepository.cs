using System;
using OpenKHS.Models;
using System.Collections.Generic;
using System.Linq;
using OpenKHS.Interfaces;

namespace OpenKHS.Data
{
    public class PmScheduleRepository : ModelRepositoryBase, IModelRepository<PmSchedule>
    {
        public PmScheduleRepository(DatabaseContext dbContext) : base(dbContext) { }

        public IList<PmSchedule> Index()
        {
            return DbContext.PmSchedules.ToList();
        }

        public PmSchedule Show(int id)
        {
            return DbContext.PmSchedules.Single(m => m.Id == id);
        }

        public void Store(PmSchedule @new)
        {
            ValidateStore(@new);
            DbContext.PmSchedules.Add(@new);
        }

        public void Delete(PmSchedule model)
        {
            if (model != null)
            {
                DbContext.PmSchedules.Remove(model);
            }
        }
    }
}
