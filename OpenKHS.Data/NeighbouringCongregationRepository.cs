using System;
using System.Collections.Generic;
using System.Linq;

using OpenKHS.Interfaces;
using OpenKHS.Models;

namespace OpenKHS.Data
{
    public class NeighbouringCongregationRepository
        : ModelRepositoryBase, IModelRepository<NeighbouringCongregation>
    {
        public NeighbouringCongregationRepository(DatabaseContext dbContext) : base(dbContext) { }

        public IList<NeighbouringCongregation> Index()
        {
            return DbContext.NeighbouringCongregations.ToList();
        }

        public NeighbouringCongregation Show(int id)
        {
            return DbContext.NeighbouringCongregations.Single(m => m.Id == id);
        }

        public void Store(NeighbouringCongregation @new)
        {
            ValidateStore(@new);
            if (DbContext.NeighbouringCongregations.Where(n => n.Name == @new.Name).Count() == 0)
            {
                DbContext.NeighbouringCongregations.Add(@new);
            }
        }

        public void Delete(NeighbouringCongregation model)
        {
            if (model != null)
            {
                DbContext.NeighbouringCongregations.Remove(model);
            }
        }
    }
}
