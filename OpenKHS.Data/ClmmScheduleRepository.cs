using System;
using OpenKHS.Models;
using System.Collections.Generic;
using System.Linq;
using OpenKHS.Interfaces;

namespace OpenKHS.Data
{
    public class ClmmScheduleRepository : ModelRepositoryBase, IModelRepository<ClmmSchedule>
    {
        public ClmmScheduleRepository(DatabaseContext dbContext) : base(dbContext) { }

        public IList<ClmmSchedule> Index()
        {
            return DbContext.ClmmSchedules.ToList();
        }

        public ClmmSchedule Show(int id)
        {
            return DbContext.ClmmSchedules.Single(m => m.Id == id);
        }

        public void Store(ClmmSchedule @new)
        {
            ValidateStore(@new);
            DbContext.ClmmSchedules.Add(@new);
        }

        public void Delete(ClmmSchedule model)
        {
            DbContext.ClmmSchedules.Remove(model);
        }
    }
}
